Imports Leadtools
Imports Leadtools.Annotations.Automation
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.WinForms
Imports Leadtools.Controls
Imports Leadtools.Drawing
Imports Leadtools.Forms.Processing.Omr.Fields
Imports Leadtools.Forms.Processing.Omr
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.Ocr
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Linq
Imports System.Windows.Forms
Imports Leadtools.Barcode
Imports Microsoft.VisualBasic

Partial Public Class ViewerControl
   Inherits UserControl

   Private Enum ZoneType
      OmrField
      Barcode
      Text
      None
      Image
   End Enum

   Private currentZoneType As ZoneType = ZoneType.None
   Private Const clrOmrField As String = "Green"
   Private Const clrBarcode As String = "Blue"
   Private Const clrText As String = "Red"
   Private Const clrImage As String = "Yellow"
   Private Const clrDefault As String = "Red"
   Private Const clrOmrCollection As String = "Green"
   Private Const clrOmrBubble As String = "Green"
   Private timer As Timer

   ' Minimum and maximum scale percentages allowed
   Private Const _minimumViewerScalePercentage As Double = 1
   Private Const _maximumViewerScalePercentage As Double = 6400
   Private _automationInteractiveMode As AutomationInteractiveMode = Nothing
   Private _panInteractiveMode As ImageViewerPanZoomInteractiveMode = Nothing
   Private _zoomToInteractiveMode As ImageViewerZoomToInteractiveMode = Nothing
   Private _noneInteractiveMode As ImageViewerNoneInteractiveMode = Nothing
   Private autoPanInteractiveMode As ImageViewerAutoPanInteractiveMode = Nothing
   ' Current 0-based page index and number of pages
   Private _currentPageIndex As Integer = -1
   Private _pageCount As Integer = 0

   ' Current interactive mode (with the mouse)
   Private _interactiveMode As ViewerControlInteractiveMode = ViewerControlInteractiveMode.SelectMode
   Private _annAutomationManager As AnnAutomationManager
   Private _annAutomation As AnnAutomation
   Private _automationManagerHelper As AutomationManagerHelper = Nothing
   Private _templateFrm As ITemplateForm
   Private _currentFileName As String = ""
   Private _regionHighlight As AnnHiliteObject = New AnnHiliteObject()

   Public ReadOnly Property TemplateForm As ITemplateForm
      Get
         Return _templateFrm
      End Get
   End Property

   Public Event CloseRequested As EventHandler(Of CloseRequestArgs)

   Public Sub New()
      InitializeComponent()
      timer = New Timer()
      AddHandler timer.Tick, AddressOf Timer_Tick
      timer.Interval = CInt(TimeSpan.FromMinutes(Settings.Default.AutoSaveDelay).TotalMilliseconds)
      timer.Start()
   End Sub

   Private Sub Timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
      If Settings.Default.AutoSaveEnabled AndAlso _templateFrm IsNot Nothing Then
         Dim cf As String = _currentFileName
         Dim appData As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
         Dim backup As String = Path.Combine(appData, Settings.Default.AutoSaveFilename)
         SaveTemplate(backup)
         _currentFileName = cf
      End If
   End Sub

   Friend Sub Deactivate()
      If pvf IsNot Nothing AndAlso Not pvf.IsDisposed AndAlso pvf.Visible Then
         pvf.Hide()
      End If
   End Sub

   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      If Not DesignMode Then
         Dim props As RasterPaintProperties = _rasterImageViewer.PaintProperties
         props.PaintDisplayMode = props.PaintDisplayMode Or RasterPaintDisplayModeFlags.ScaleToGray Or RasterPaintDisplayModeFlags.Bicubic
         _rasterImageViewer.PaintProperties = props
         _rasterImageViewer.ViewMargin = New Padding(10)
         _rasterImageViewer.ViewBorderThickness = 1
         _automationInteractiveMode = New AutomationInteractiveMode()
         _noneInteractiveMode = New ImageViewerNoneInteractiveMode()
         _panInteractiveMode = New ImageViewerPanZoomInteractiveMode()
         _panInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left
         _panInteractiveMode.IdleCursor = Cursors.Hand
         _panInteractiveMode.WorkingCursor = Cursors.Hand
         autoPanInteractiveMode = New ImageViewerAutoPanInteractiveMode()
         _zoomToInteractiveMode = New ImageViewerZoomToInteractiveMode()
         AddHandler _zoomToInteractiveMode.RubberBandCompleted, AddressOf _rasterImageViewer_InteractiveZoomTo
         autoPanInteractiveMode.BeginDelay = 100
         autoPanInteractiveMode.PanDelay = 100
         _rasterImageViewer.InteractiveModes.BeginUpdate()
         _rasterImageViewer.InteractiveModes.Add(autoPanInteractiveMode)
         _rasterImageViewer.InteractiveModes.Add(_noneInteractiveMode)
         _rasterImageViewer.InteractiveModes.Add(_automationInteractiveMode)
         _rasterImageViewer.InteractiveModes.Add(_panInteractiveMode)
         _rasterImageViewer.InteractiveModes.Add(_zoomToInteractiveMode)
         _rasterImageViewer.InteractiveModes.EndUpdate()
         EnableInteractiveMode(_automationInteractiveMode.Id)
         AddHandler _zoomToolStripComboBox.LostFocus, AddressOf _zoomToolStripComboBox_LostFocus
         AddHandler _pageToolStripTextBox.LostFocus, AddressOf _pageToolStripTextBox_LostFocus
         _rasterImageViewer_TransformChanged(_rasterImageViewer, EventArgs.Empty)
         FitPage(False)
         _mousePositionLabel.Text = String.Empty
         InitAnnotations()
      End If

      MyBase.OnLoad(e)
   End Sub

   Public Sub EnableInteractiveMode(ByVal id As Integer)
      _rasterImageViewer.InteractiveModes.BeginUpdate()

      For Each mode As ImageViewerInteractiveMode In _rasterImageViewer.InteractiveModes

         If mode.Id <> ImageViewerInteractiveMode.AutoPanModeId AndAlso mode.Id <> id Then
            mode.IsEnabled = False
         Else
            mode.IsEnabled = True
         End If
      Next

      _rasterImageViewer.InteractiveModes.EndUpdate()
   End Sub

   Private Sub _rasterImageViewer_InteractiveZoomTo(ByVal sender As Object, ByVal e As ImageViewerRubberBandEventArgs)
   End Sub

   Public Sub SetPages(ByVal currentPageIndex As Integer, ByVal pageCount As Integer)
      _currentPageIndex = currentPageIndex
      _pageCount = pageCount
      UpdateUIState()
   End Sub

   Friend Sub Cleanup()
      timer.[Stop]()
      Dim folder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
      Dim backup As String = Path.Combine(folder, Settings.Default.AutoSaveFilename)

      If File.Exists(backup) Then
         File.Delete(backup)
      End If
   End Sub

   Friend Sub LoadAutosave()
      Dim folder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
      Dim backup As String = Path.Combine(folder, Settings.Default.AutoSaveFilename)
      LoadTemplate(backup)
      _currentFileName = ""
   End Sub

   Friend Function IsAutosavePresent() As Boolean
      Dim folder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
      Dim backup As String = Path.Combine(folder, Settings.Default.AutoSaveFilename)
      Return File.Exists(backup)
   End Function

   <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
   Public ReadOnly Property RasterImage As RasterImage
      Get
         Return _rasterImageViewer.Image
      End Get
   End Property

   Private Sub SetImageAndPage(ByVal image As RasterImage)
      BuildNewTree()
      SetPages(0, _templateFrm.Pages.Count)
      TryGotoPage(0)
      ToggleUIEnables(True)

      If image IsNot Nothing Then
         Dim saveMapper As AnnContainerMapper = _annAutomation.Container.Mapper.Clone()
         Dim identityMapper As AnnContainerMapper = New AnnContainerMapper(saveMapper.SourceDpiX, saveMapper.SourceDpiY, saveMapper.SourceDpiX, saveMapper.SourceDpiY)
         identityMapper.UpdateTransform(LeadMatrix.Identity)
         _annAutomation.Container.Mapper = identityMapper
         If _annAutomation IsNot Nothing Then _annAutomation.Container.Size = identityMapper.SizeToContainerCoordinates(LeadSizeD.Create(image.ImageWidth, image.ImageHeight))
         _annAutomation.Container.Mapper = saveMapper
         ZonesUpdated()
         _rasterImageViewer.ViewBorderThickness = 1
      Else
         _rasterImageViewer.ViewBorderThickness = 0
      End If

      UpdateUIState()
   End Sub

   Private Sub ToggleUIEnables(ByVal val As Boolean)
      saveasToolStripMenuItem.Enabled = val
      saveToolStripMenuItem.Enabled = val
      editToolStripMenuItem.Enabled = val
      closeToolStripMenuItem.Enabled = val
   End Sub

   Private Sub BuildNewTree()
      trvForm.Nodes.Clear()
      Dim rootNode As TreeNode = New TreeNode(_templateFrm.Name)
      trvForm.Nodes.Add(rootNode)

      For i As Integer = 0 To _templateFrm.Pages.Count - 1
         Dim pg As Page = _templateFrm.Pages(i)

         If String.IsNullOrWhiteSpace(pg.PageName) Then
            pg.PageName = "Page " & pg.PageNumber.ToString()
         End If

         Dim pageNode As TreeNode = New TreeNode(pg.PageName)
         pageNode.Name = pageNode.Text
         pageNode.Expand()

         For j As Integer = 0 To pg.Fields.Count - 1
            Dim branch As TreeNode = CreateNewNode(pg.Fields(j))
            branch.Collapse(True)
            pageNode.Nodes.Add(branch)
         Next

         rootNode.Nodes.Add(pageNode)
      Next

      rootNode.Expand()
   End Sub

   Private Sub AddNode(ByVal ff As Field)
      Dim node As TreeNode = CreateNewNode(ff)

      If TypeOf ff Is OmrField Then
         Dim orf As OmrField = CType(ff, OmrField)
         ReNumberElements(node, orf, RowNumberDialog.GetFriendlyFieldTemplate(orf.Options.FieldOrientation), 1)
      End If

      trvForm.Nodes(0).Nodes(_currentPageIndex).Nodes.Add(node)
      trvForm.Nodes(0).Nodes(_currentPageIndex).Expand()
      node.Expand()
   End Sub

   Private Function CreateNewNode(ByVal ff As Field) As TreeNode
      Dim node As TreeNode = New TreeNode(ff.Name)
      node.Name = ff.Name
      Dim page As Integer = ff.PageNumber
      node.Tag = New Tuple(Of String, LeadRect, Integer)(GetZoneColor(ff), ff.Bounds, page)

      If TypeOf ff Is OmrField Then
         Dim omr As OmrField = CType(ff, OmrField)

         For i As Integer = 0 To omr.Fields.Count - 1
            Dim omrCollection As OmrCollection = omr.Fields(i)
            Dim ocNode As TreeNode = New TreeNode(omrCollection.Name)
            ocNode.Name = omrCollection.Name
            ocNode.Tag = New Tuple(Of String, LeadRect, Integer)(GetZoneColor(omrCollection), omrCollection.Bounds, page)

            If omr.FieldBubbleLayoutType = OmrFieldBubbleLayoutType.BubbleWithLabel Then

               For j As Integer = 0 To omrCollection.Fields.Count - 1
                  Dim bub As OmrBubble = omrCollection.Fields(j)
                  Dim ss As TreeNode = New TreeNode(bub.Value)
                  ss.Name = bub.Value
                  ss.Tag = New Tuple(Of String, LeadRect, Integer)(GetZoneColor(bub), bub.Bounds, page)
                  ocNode.Nodes.Add(ss)
               Next

               ocNode.Expand()
            End If

            node.Nodes.Add(ocNode)
         Next

         node.Expand()
      End If

      Return node
   End Function

   Private Sub DeleteNode(ByVal node As TreeNode)
      Dim text As String = node.Text

      If MessageBox.Show(String.Format("Are you sure you want to delete ""{0}""?", text), "Confirm", MessageBoxButtons.YesNo) = DialogResult.Yes Then
         Dim index As Integer = node.Index
         trvForm.Nodes(0).Nodes(_currentPageIndex).Nodes.RemoveAt(index)
         _templateFrm.Pages(_currentPageIndex).Fields.RemoveAt(index)
         ZonesUpdated()
      End If
   End Sub

   Private Sub MoveNode(ByVal node As TreeNode, ByVal direction As Integer)
      Dim index As Integer = node.Index
      Dim ex As Boolean = node.IsExpanded
      trvForm.Nodes(0).Nodes(_currentPageIndex).Nodes.RemoveAt(index)
      trvForm.Nodes(0).Nodes(_currentPageIndex).Nodes.Insert(index + direction, node)
      Dim ff As Field = _templateFrm.Pages(_currentPageIndex).Fields(index)
      _templateFrm.Pages(_currentPageIndex).Fields.RemoveAt(index)
      _templateFrm.Pages(_currentPageIndex).Fields.Insert(index + direction, ff)

      If ex Then
         node.Expand()
      End If
   End Sub

   Private Sub MovePage(ByVal node As TreeNode, ByVal direction As Integer)
      Dim index As Integer = node.Index
      Dim ex As Boolean = node.IsExpanded
      trvForm.Nodes(0).Nodes.RemoveAt(index)
      trvForm.Nodes(0).Nodes.Insert(index + direction, node)
      Dim page As Page = _templateFrm.Pages(index)
      _templateFrm.Pages.RemoveAt(index)
      _templateFrm.Pages.Insert(index + direction, page)

      If ex Then
         node.Expand()
      End If
   End Sub

   Private Sub DeletePage(ByVal node As TreeNode)
      If _templateFrm.Pages.Count = 1 Then
         MessageBox.Show("Templates must have at least one page.")
         Return
      End If

      If MessageBox.Show(String.Format("Are you sure you want to delete ""{0}""?", node.Text), "Confirm", MessageBoxButtons.YesNo) = DialogResult.Yes Then
         Dim index As Integer = node.Index
         trvForm.Nodes(0).Nodes.RemoveAt(index)
         _templateFrm.Pages.RemoveAt(index)
         _templateFrm.Pages.Update()
         _pageCount -= 1
         ZonesUpdated()

         If _currentPageIndex = index Then
            _currentPageIndex = Math.Max(_currentPageIndex - 1, 0)
         End If

         TryGotoPage(_currentPageIndex)
      End If
   End Sub

   Public Sub FitPage(ByVal fitWidth As Boolean)
      _rasterImageViewer.BeginUpdate()

      If fitWidth Then
         _rasterImageViewer.Zoom(ControlSizeMode.FitWidth, 1, _rasterImageViewer.DefaultZoomOrigin)
      Else
         _rasterImageViewer.Zoom(ControlSizeMode.FitAlways, 1, _rasterImageViewer.DefaultZoomOrigin)
      End If

      _rasterImageViewer.EndUpdate()
      UpdateUIState()
   End Sub

   Public Sub ZoomViewer(ByVal zoomOut As Boolean)
      Dim percentage As Double = _rasterImageViewer.XScaleFactor * 100.0
      Dim validPercentages As Double() = {_minimumViewerScalePercentage, 6.25, 12.5, 25, 33.3, 50, 66.7, 73.6, 92.5, 100, 125, 150, 200, 300, 400, 600, 800, 1200, 1600, 2400, 3200, _maximumViewerScalePercentage}

      If zoomOut Then

         Dim i As Integer = (validPercentages.Length - 1)
         Do While (i >= 0)
            If (percentage > validPercentages(i)) Then
               percentage = validPercentages(i)
               Exit Do
            End If

            i = (i - 1)
         Loop
      Else
         For i As Integer = 0 To validPercentages.Length - 1

            If percentage < validPercentages(i) Then
               percentage = validPercentages(i)
               Exit For
            End If
         Next
      End If

      SetViewerZoomPercentage(percentage)
      ZonesUpdated()
   End Sub

   <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
   Public Property InteractiveMode As ViewerControlInteractiveMode
      Get
         Return _interactiveMode
      End Get
      Set(ByVal value As ViewerControlInteractiveMode)
         _interactiveMode = value

         If _interactiveMode <> ViewerControlInteractiveMode.DrawZoneMode Then
            SetZoneTSButtonCheckFalse()
         End If

         If _annAutomationManager IsNot Nothing Then

            Select Case _interactiveMode
               Case ViewerControlInteractiveMode.SelectMode
                  EnableInteractiveMode(_automationInteractiveMode.Id)
                  _annAutomationManager.CurrentObjectId = AnnObject.None
                  _annAutomation.DefaultCurrentObjectId = AnnObject.None
                  _annAutomation.Cancel()
               Case ViewerControlInteractiveMode.PanMode
                  EnableInteractiveMode(_panInteractiveMode.Id)
                  _annAutomationManager.CurrentObjectId = AnnObject.None
                  _annAutomation.DefaultCurrentObjectId = AnnObject.None
                  _annAutomation.Cancel()
               Case ViewerControlInteractiveMode.ZoomToSelectionMode
                  EnableInteractiveMode(_zoomToInteractiveMode.Id)
                  _annAutomationManager.CurrentObjectId = AnnObject.None
                  _annAutomation.DefaultCurrentObjectId = AnnObject.None
                  _annAutomation.Cancel()
               Case ViewerControlInteractiveMode.DrawZoneMode
                  EnableInteractiveMode(_automationInteractiveMode.Id)
                  _annAutomationManager.CurrentObjectId = AnnObject.UserObjectId
                  _annAutomation.DefaultCurrentObjectId = AnnObject.UserObjectId
            End Select
         End If

         UpdateUIState()
      End Set
   End Property

   <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
   Public Property ShowZones As Boolean
      Get
         Return _showZonesToolStripButton.Checked
      End Get
      Set(ByVal value As Boolean)
         _showZonesToolStripButton.Checked = value

         If _annAutomation IsNot Nothing Then
            _annAutomation.Cancel()

            For Each obj As AnnObject In _annAutomation.Container.Children
               obj.IsVisible = value
            Next

            _regionHighlight.IsVisible = False
         End If

         If Not _showZonesToolStripButton.Checked AndAlso _interactiveMode = ViewerControlInteractiveMode.DrawZoneMode Then InteractiveMode = ViewerControlInteractiveMode.SelectMode
         _rasterImageViewer.Invalidate()
         UpdateUIState()
      End Set
   End Property

   Public Sub ZonesUpdated()
      _rasterImageViewer.BeginUpdate()

      If _annAutomation IsNot Nothing Then
         _annAutomation.Cancel()
         _annAutomation.Container.Children.Clear()
         _annAutomation.Container.Children.Add(_regionHighlight)
      End If

      If Not _showZonesToolStripButton.Checked Then
         _rasterImageViewer.EndUpdate()
         _rasterImageViewer.Invalidate()
         Return
      End If

      Dim isVisible As Boolean = _showZonesToolStripButton.Checked AndAlso Not MainForm.PerspectiveDeskewActive AndAlso Not MainForm.UnWarpActive
      Dim formPage As Page = If(_currentPageIndex >= 0 AndAlso _currentPageIndex < _templateFrm.Pages.Count, _templateFrm.Pages(_currentPageIndex), Nothing)

      If formPage IsNot Nothing AndAlso formPage.Fields.Count > 0 Then

         For i As Integer = 0 To formPage.Fields.Count - 1
            Dim f As Field = formPage.Fields(i)
            Dim ao As AnnRectangleObject = New AnnRectangleObject()
            ao = CreateAnnotation(f)
            _annAutomation.Container.Children.Add(ao)

            If tsToggleSubzones.Checked AndAlso TypeOf f Is OmrField Then
               Dim omr As OmrField = TryCast(f, OmrField)

               For j As Integer = 0 To omr.Fields.Count - 1
                  _annAutomation.Container.Children.Add(CreateAnnotation(omr.Fields(j)))
               Next
            End If
         Next
      End If

      _rasterImageViewer.EndUpdate()
      _rasterImageViewer.Invalidate()
      UpdateUIState()
   End Sub

   Private Function CreateAnnotation(ByVal f As OmrCollection) As AnnObject
      Dim ao As AnnRectangleObject = New AnnRectangleObject()
      Dim rc As LeadRect = f.Bounds
      Dim rect As LeadRectD = BoundsToAnnotations(rc, _annAutomation.Container)
      ao.Rect = rect
      Dim color As String = GetZoneColor(f)
      ao.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create(color), New LeadLengthD(1))
      ao.Tag = f
      Return ao
   End Function

   Private Function CreateAnnotation(ByVal f As Field) As AnnRectangleObject
      Dim ao As AnnRectangleObject = New AnnRectangleObject()
      Dim rc As LeadRect = f.Bounds
      Dim rect As LeadRectD = BoundsToAnnotations(rc, _annAutomation.Container)
      ao.Rect = rect
      Dim color As String = GetZoneColor(f)
      ao.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create(color), New LeadLengthD(1))
      ao.Tag = f
      Return ao
   End Function

   Private Function GetZoneColor(ByVal f As OmrBubble) As String
      Return clrOmrBubble
   End Function

   Private Function GetZoneColor(ByVal f As OmrCollection) As String
      Return clrOmrCollection
   End Function

   Private Function GetZoneColor(ByVal f As Field) As String
      Dim color As String = String.Empty

      If TypeOf f Is OmrField Then
         color = clrOmrField
      End If

      If TypeOf f Is BarcodeField Then
         color = clrBarcode
      End If

      If TypeOf f Is OcrField Then
         color = clrText
      End If

      If TypeOf f Is ImageField Then
         color = clrImage
      End If

      Return If(String.IsNullOrWhiteSpace(color), clrDefault, color)
   End Function

   Private Function GetZoneColor(ByVal omrField As ZoneType) As String
      Select Case omrField
         Case ZoneType.OmrField
            Return clrOmrField
         Case ZoneType.Barcode
            Return clrBarcode
         Case ZoneType.Text
            Return clrText
         Case ZoneType.Image
            Return clrImage
         Case Else
            Return clrDefault
      End Select
   End Function

   Private Function BoundsFromAnnotations(ByVal rectObject As AnnRectangleObject, ByVal container As AnnContainer) As LeadRect
      Dim temp As LeadRectD = container.Mapper.RectFromContainerCoordinates(rectObject.Rect, AnnFixedStateOperations.None)
      temp = _rasterImageViewer.ConvertRect(Nothing, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, temp)
      Dim rc As RectangleF = New RectangleF(CSng(temp.X), CSng(temp.Y), CSng(temp.Width), CSng(temp.Height))
      Dim rect As LeadRect = New LeadRect(CInt(Math.Ceiling(rc.X)), CInt(Math.Ceiling(rc.Y)), CInt(Math.Ceiling(rc.Width)), CInt(Math.Ceiling(rc.Height)))
      Return rect
   End Function

   Private Function BoundsToAnnotations(ByVal rect As LeadRect, ByVal container As AnnContainer) As LeadRectD
      Dim rc As LeadRectD = rect.ToLeadRectD()
      rc = _rasterImageViewer.ConvertRect(Nothing, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, rc)
      rc = container.Mapper.RectToContainerCoordinates(rc)
      Return rc
   End Function

   Private Function CreateZoneAutomationObject() As AnnAutomationObject
      Dim automationObj As AnnAutomationObject = New AnnAutomationObject()
      Dim zoneAnnotationObject As ZoneAnnotationObject = New ZoneAnnotationObject()
      Dim rectAutomationObject As AnnAutomationObject = GetAutomationObject(_annAutomationManager, AnnObject.RectangleObjectId)
      Dim rectObject As AnnRectangleObject = TryCast(rectAutomationObject.ObjectTemplate, AnnRectangleObject)
      zoneAnnotationObject.Stroke = If(rectObject.Stroke IsNot Nothing, TryCast(rectObject.Stroke.Clone(), AnnStroke), Nothing)
      zoneAnnotationObject.Fill = If(rectObject.Fill IsNot Nothing, TryCast(rectObject.Fill.Clone(), AnnBrush), Nothing)
      zoneAnnotationObject.CellPen = AnnStroke.Create(AnnSolidColorBrush.Create("Blue"), New LeadLengthD(1))
      automationObj.Id = AnnObject.UserObjectId
      automationObj.Name = zoneAnnotationObject.FriendlyName
      automationObj.ObjectTemplate = zoneAnnotationObject
      automationObj.DrawDesignerType = rectAutomationObject.DrawDesignerType
      automationObj.EditDesignerType = GetType(ZoneAnnotationObjectEditDesigner)
      automationObj.RunDesignerType = rectAutomationObject.RunDesignerType
      automationObj.DrawCursor = rectAutomationObject.DrawCursor
      automationObj.UseRotateThumbs = False
      Return automationObj
   End Function

   Private Sub InitAnnotations()
      _annAutomationManager = New AnnAutomationManager()
      _annAutomationManager.RotateModifierKey = AnnKeys.None
      _annAutomationManager.EditObjectAfterDraw = False
      _annAutomationManager.CreateDefaultObjects()
      _annAutomation = New AnnAutomation(_annAutomationManager, _rasterImageViewer)
      AddHandler _annAutomation.OnShowContextMenu, AddressOf _annAutomation_OnShowContextMenu
      AddHandler _annAutomation.Draw, AddressOf _annAutomation_Draw
      AddHandler _annAutomation.SetCursor, AddressOf _annAutomation_SetCursor
      AddHandler _annAutomation.RestoreCursor, AddressOf _annAutomation_RestoreCursor
      _annAutomation.UndoCapacity = 0
      _annAutomation.Active = True
      _annAutomation.DefaultCurrentObjectId = AnnObject.None
      Dim selectAutomationObject As AnnAutomationObject = GetAutomationObject(_annAutomationManager, AnnObject.SelectObjectId)
      Dim zoneAutomationObject As AnnAutomationObject = CreateZoneAutomationObject()
      _automationManagerHelper = New AutomationManagerHelper(_annAutomationManager)
      Dim zoneObjectRenderer As ZoneAnnotationObjectRenderer = New ZoneAnnotationObjectRenderer()
      Dim annRectangleObjectRenderer As IAnnObjectRenderer = _annAutomationManager.RenderingEngine.Renderers(AnnObject.RectangleObjectId)
      zoneObjectRenderer.LocationsThumbStyle = annRectangleObjectRenderer.LocationsThumbStyle
      zoneObjectRenderer.RotateCenterThumbStyle = annRectangleObjectRenderer.RotateCenterThumbStyle
      zoneObjectRenderer.RotateGripperThumbStyle = annRectangleObjectRenderer.RotateGripperThumbStyle
      _annAutomationManager.Objects.Clear()
      Dim cm As ContextMenu = New ContextMenu()
      cm.MenuItems.Add(New MenuItem("&Delete", AddressOf _zoneDeleteMenuItem_Click))
      cm.MenuItems.Add(New MenuItem("-", TryCast(Nothing, EventHandler)))
      zoneAutomationObject.ContextMenu = cm
      _annAutomationManager.RenderingEngine.Renderers(AnnObject.UserObjectId) = zoneObjectRenderer
      _annAutomationManager.Objects.Add(selectAutomationObject)
      _annAutomationManager.Objects.Add(zoneAutomationObject)
      Dim selectionObject As AnnAutomationObject = _annAutomationManager.FindObjectById(AnnObject.SelectObjectId)
      selectionObject.DrawDesignerType = Nothing
   End Sub

   Private Sub _annAutomation_RestoreCursor(ByVal sender As Object, ByVal e As EventArgs)
      If _rasterImageViewer.Cursor <> Cursors.[Default] AndAlso InteractiveMode = ViewerControlInteractiveMode.SelectMode Then
         _rasterImageViewer.Cursor = Cursors.[Default]
      ElseIf InteractiveMode = ViewerControlInteractiveMode.DrawZoneMode Then
         _rasterImageViewer.Cursor = Cursors.Cross
      End If
   End Sub

   Private Sub _annAutomation_SetCursor(ByVal sender As Object, ByVal e As AnnCursorEventArgs)
      If Not _automationInteractiveMode.IsEnabled Then Return
      Dim newCursor As Cursor = Nothing

      Select Case e.DesignerType
         Case AnnDesignerType.Draw
            newCursor = Cursors.Cross
         Case AnnDesignerType.Edit

            If e.IsRotateCenter Then
               newCursor = AutomationManagerHelper.AutomationCursors(CursorType.RotateCenterControlPoint)
            ElseIf e.IsRotateGripper Then
               newCursor = AutomationManagerHelper.AutomationCursors(CursorType.RotateGripperControlPoint)
            ElseIf e.ThumbIndex < 0 Then
               newCursor = AutomationManagerHelper.AutomationCursors(CursorType.SelectedObject)
            Else
               newCursor = AutomationManagerHelper.AutomationCursors(CursorType.ControlPoint)
            End If

         Case AnnDesignerType.Run
            newCursor = AutomationManagerHelper.AutomationCursors(CursorType.Run)
         Case Else
            newCursor = Cursors.Cross
      End Select

      If _rasterImageViewer.Cursor <> newCursor Then _rasterImageViewer.Cursor = newCursor
   End Sub

   Private Shared Function GetAutomationObject(ByVal automationManager As AnnAutomationManager, ByVal id As Integer) As AnnAutomationObject
      For Each obj As AnnAutomationObject In automationManager.Objects
         If obj.Id = id Then Return obj
      Next

      Return Nothing
   End Function

   Private Shared Function RestrictZoneBoundsToPage(ByVal image As RasterImage, ByVal bounds As LeadRect) As LeadRect
      Dim pageBounds As LeadRect = New LeadRect(0, 0, image.ImageWidth, image.ImageHeight)
      Dim rc As LeadRect = bounds
      rc = LeadRect.Intersect(pageBounds, rc)
      Return rc
   End Function

   Private Sub _annAutomation_OnShowContextMenu(ByVal sender As Object, ByVal e As AnnAutomationEventArgs)
      If e IsNot Nothing AndAlso e.Object IsNot Nothing Then
         Dim annAutomationObject As AnnAutomationObject = TryCast(e.Object, AnnAutomationObject)

         If annAutomationObject IsNot Nothing Then
            Dim menu As ContextMenu = TryCast(annAutomationObject.ContextMenu, ContextMenu)

            If menu IsNot Nothing Then
               menu.Show(Me, _rasterImageViewer.PointToClient(Cursor.Position))
            End If
         End If
      End If
   End Sub

   Private Sub _annAutomation_Draw(ByVal sender As Object, ByVal e As AnnDrawDesignerEventArgs)
      Dim zoneObject As ZoneAnnotationObject = TryCast(e.Object, ZoneAnnotationObject)
      If zoneObject Is Nothing Then Return
      Dim ao As AnnRectangleObject = New AnnRectangleObject()
      Dim rc As LeadRect = zoneObject.Bounds.ToLeadRect()
      Dim rect As LeadRectD = BoundsToAnnotations(rc, _annAutomation.Container)
      ao.Rect = rect

      If Not (e.OperationStatus = AnnDesignerOperationStatus.[End]) Then
         Return
      End If

      Dim lr As LeadRect = New LeadRect(CInt(rect.X), CInt(rect.Y), CInt(rect.Width), CInt(rect.Height))
      lr = RestrictZoneBoundsToPage(_templateFrm.Pages(_currentPageIndex).Image, BoundsFromAnnotations(zoneObject, _annAutomation.Container))
      zoneObject.Rect = BoundsToAnnotations(lr, _annAutomation.Container)
      Dim newField As Field = Nothing

      Select Case currentZoneType
         Case ZoneType.OmrField
            newField = CreateOmrRegion(lr)
         Case ZoneType.Barcode
            newField = CreateBarcodeField(lr)
         Case ZoneType.Text
            newField = CreateTextField(lr)
         Case ZoneType.Image
            newField = CreateImageField(lr)
         Case ZoneType.None
         Case Else
      End Select

      If newField IsNot Nothing Then
         newField.PageNumber = _currentPageIndex + 1

         If newField.Tag Is Nothing Then
            newField.Tag = False
         End If

         Dim formPage As Page = _templateFrm.Pages(_currentPageIndex)
         Dim success As Boolean = False

         Try
            formPage.Fields.Add(newField)
            success = True
         Catch ex As Exception
            MessageBox.Show(Me.Parent, "Unable to add this field:" & Constants.vbLf & ex.Message)
            success = False
         End Try

         If success Then
            AddNode(newField)
         End If
      End If

      ZonesUpdated()
      InteractiveMode = ViewerControlInteractiveMode.DrawZoneMode
      UpdateUIState()
   End Sub

   Private Function CreateImageField(ByVal lr As LeadRect) As Field
      Dim imField As ImageField = New ImageField()
      imField.Bounds = lr
      imField.Name = GetFreeFieldName()
      Dim tid As TextInputDialog = New TextInputDialog(imField.Name)

      If tid.ShowDialog() = DialogResult.OK Then
         imField.Name = tid.Value
         Return imField
      End If

      Return Nothing
   End Function

   Private Function CreateBarcodeField(ByVal lr As LeadRect) As Field
      Dim bcff As BarcodeField = New BarcodeField()
      bcff.Bounds = lr
      bcff.Symbology = BarcodeSymbology.Unknown
      bcff.Name = GetFreeFieldName()
      Dim bcffd As BarcodeFieldDialog = New BarcodeFieldDialog(bcff, _rasterImageViewer.Image.Clone())

      If bcffd.ShowDialog() = DialogResult.OK Then
         Return bcff
      End If

      Return Nothing
   End Function

   Private Function CreateTextField(ByVal lr As LeadRect) As Field
      Dim ff As OcrField = New OcrField()
      ff.Name = GetFreeFieldName()
      Dim tid As TextInputDialog = New TextInputDialog(ff.Name)

      If tid.ShowDialog() = DialogResult.OK Then
         ff.Name = tid.Value
         ff.Bounds = lr
         Return ff
      End If

      Return Nothing
   End Function

   Private Function GetFreeFieldName() As String
      Dim formPage As Page = _templateFrm.Pages(_currentPageIndex)
      Dim i As Integer = 0
      Dim newName As String = String.Empty

      While True
         newName = String.Format("New Field {0}", i)
         If Not formPage.Fields.[Select](Function(a) a.Name).Contains(newName) Then Exit While
         i += 1
      End While

      Return newName
   End Function

   Private Function CreateOmrRegion(ByVal lr As LeadRect) As Field
      Dim current As Cursor = Me.Cursor

      Try
         Dim formPage As Page = _templateFrm.Pages(_currentPageIndex)
         Dim omrField As OmrField = New OmrField()
         omrField.Bounds = lr
         omrField.PageNumber = _currentPageIndex + 1
         omrField.Name = GetFreeFieldName()
         Me.Cursor = Cursors.WaitCursor
         _templateFrm.ExtractInfo(_currentPageIndex + 1, New Field() {omrField})
         Me.Cursor = current

         For i As Integer = 0 To omrField.Fields.Count - 1

            If String.IsNullOrWhiteSpace(omrField.Fields(i).Name) Then
               omrField.Fields(i).Name = String.Format("Area {0}", i.ToString())
            End If
         Next

         Dim options As OmrFieldOptions = omrField.Options
         options.GradeThisField = omrField.FieldBubbleLayoutType = OmrFieldBubbleLayoutType.None AndAlso omrField.RowsCount >= omrField.ColumnsCount AndAlso (omrField.ColumnsCount = 4 OrElse omrField.ColumnsCount = 5)
         omrField.Options = options
         Dim dlg As OmrFieldDialog = New OmrFieldDialog(omrField, formPage.Image.Clone())

         If dlg.ShowDialog() = DialogResult.OK Then
            Return omrField
         End If

      Catch ex As Exception
         Return Nothing
      Finally
         Me.Cursor = current
      End Try

      Return Nothing
   End Function

   Private Sub _zoneDeleteMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      _annAutomation.DeleteSelectedObjects()
   End Sub

   Private Sub UpdateZoomValueFromControl()
      BeginInvoke(New MethodInvoker(Sub()
                                       If _rasterImageViewer.Image IsNot Nothing Then
                                          Dim factor As Double = _rasterImageViewer.XScaleFactor * 100.0
                                          _zoomToolStripComboBox.Text = factor.ToString("F1") & "%"
                                       Else
                                          _zoomToolStripComboBox.Text = String.Empty
                                       End If
                                    End Sub))
   End Sub

   Public Sub UpdateUIState()
      If _templateFrm Is Nothing OrElse _templateFrm.Pages Is Nothing Then
         _pageToolStripTextBox.Text = "0"
         _pageToolStripLabel.Text = "/ 0"
         _zoomToolStripComboBox.Text = String.Empty
         _toolStrip.Enabled = False
         Return
      End If

      Dim formPage As Page = If(_currentPageIndex >= 0 AndAlso _currentPageIndex < _templateFrm.Pages.Count, _templateFrm.Pages(_currentPageIndex), Nothing)
      _fitPageWidthToolStripButton.Checked = _rasterImageViewer.SizeMode = ControlSizeMode.FitWidth
      _fitPageToolStripButton.Checked = _rasterImageViewer.SizeMode = ControlSizeMode.Fit
      _zoomToSelectionModeToolStripButton.Checked = _interactiveMode = ViewerControlInteractiveMode.ZoomToSelectionMode

      If _rasterImageViewer.Image IsNot Nothing Then
         If Not _toolStrip.Enabled Then _toolStrip.Enabled = True
         _pageToolStripTextBox.Text = (_currentPageIndex + 1).ToString()
         _pageToolStripLabel.Text = "/ " & _pageCount.ToString()
         _previousPageToolStripButton.Enabled = _currentPageIndex > 0 AndAlso Not MainForm.PerspectiveDeskewActive
         _nextPageToolStripButton.Enabled = _currentPageIndex < (_pageCount - 1) AndAlso Not MainForm.PerspectiveDeskewActive
         _pageToolStripTextBox.Enabled = Not MainForm.PerspectiveDeskewActive
         _pageToolStripLabel.Enabled = Not MainForm.PerspectiveDeskewActive
         _showZonesToolStripButton.Enabled = Not MainForm.PerspectiveDeskewActive
      End If
   End Sub

   Private Sub _rasterImageViewer_TransformChanged(ByVal sender As Object, ByVal e As EventArgs)
      If IsHandleCreated Then
         UpdateZoomValueFromControl()
         UpdateUIState()
      End If
   End Sub

   Private Sub _previousPageToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs)
      TryGotoPage(_currentPageIndex + -1)
   End Sub

   Private Sub _nextPageToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs)
      TryGotoPage(_currentPageIndex + 1)
   End Sub

   Private Sub _pageToolStripTextBox_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
      _pageToolStripTextBox.Text = (_currentPageIndex + 1).ToString()
   End Sub

   Private Sub _pageToolStripTextBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
      If (e.KeyChar = CType(Microsoft.VisualBasic.ChrW(Keys.Return), Char)) Then
         Dim str As String = _pageToolStripTextBox.Text.Trim()
         Dim pageNumber As Integer
         If Integer.TryParse(str, pageNumber) Then TryGotoPage(pageNumber - 1)
         _pageToolStripTextBox.Text = (_currentPageIndex + 1).ToString()
      End If
   End Sub

   Private Sub TryGotoPage(ByVal pageIndex As Integer)
      If pageIndex >= 0 AndAlso pageIndex < _pageCount Then
         _rasterImageViewer.BeginUpdate()
         _currentPageIndex = pageIndex
         _rasterImageViewer.Image = _templateFrm.Pages(_currentPageIndex).Image.Clone()
         _rasterImageViewer.EndUpdate()
         _rasterImageViewer.Invalidate()
         ZonesUpdated()
      End If
   End Sub

   Private Sub _zoomOutToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs)
      ZoomViewer(True)
   End Sub

   Private Sub _zoomInToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs)
      ZoomViewer(False)
   End Sub

   Private Sub _zoomToolStripComboBox_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
      UpdateZoomValueFromControl()
   End Sub

   Private Sub _zoomToolStripComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
      Dim str As String = _zoomToolStripComboBox.Text.Trim()

      Select Case str
         Case "Actual Size"
            SetViewerZoomPercentage(100)
         Case "Fit Page"
            _fitPageToolStripButton.PerformClick()
         Case "Fit Width"
            _fitPageWidthToolStripButton.PerformClick()
         Case Else

            If Not String.IsNullOrEmpty(str) Then
               Dim val As Double = Double.Parse(str.Substring(0, str.Length - 1))
               SetViewerZoomPercentage(val)
            End If
      End Select

      ZonesUpdated()
   End Sub

   Private Sub _zoomToolStripComboBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
      If (e.KeyChar = CType(Microsoft.VisualBasic.ChrW(Keys.Return), Char)) Then
         Dim str As String = _zoomToolStripComboBox.Text.Trim()

         If Not String.IsNullOrEmpty(str) Then
            If str.EndsWith("%") Then str = str.Remove(str.Length - 1, 1).Trim()
            Dim percentage As Double
            If Double.TryParse(str, percentage) Then SetViewerZoomPercentage(percentage)
            UpdateZoomValueFromControl()
            ZonesUpdated()
         End If
      End If
   End Sub

   Private Sub SetViewerZoomPercentage(ByVal percentage As Double)
      If _rasterImageViewer.Image Is Nothing Then
         Return
      End If

      percentage = Math.Max(_minimumViewerScalePercentage, Math.Min(_maximumViewerScalePercentage, percentage))

      If Math.Abs(_rasterImageViewer.XScaleFactor * 100.0 - percentage) > 0.01 Then
         Dim rc As Rectangle = Rectangle.Intersect(_rasterImageViewer.DisplayRectangle, _rasterImageViewer.ClientRectangle)
         Dim center As PointF = New PointF(Convert.ToSingle(rc.Left + rc.Width / 2), Convert.ToSingle(rc.Top + rc.Right / 2))
         Dim trans As Transformer = New Transformer(ToMatrix(_rasterImageViewer.ImageTransform))
         center = trans.PointToLogical(center)
         _rasterImageViewer.BeginUpdate()
         If _rasterImageViewer.SizeMode <> ControlSizeMode.None Then _rasterImageViewer.Zoom(ControlSizeMode.None, _rasterImageViewer.ScaleFactor, _rasterImageViewer.DefaultZoomOrigin)
         _rasterImageViewer.Zoom(_rasterImageViewer.SizeMode, percentage / 100.0, _rasterImageViewer.DefaultZoomOrigin)
         trans = New Transformer(ToMatrix(_rasterImageViewer.ImageTransform))
         center = trans.PointToPhysical(center)
         Dim lPoint As LeadPoint = New LeadPoint(Point.Round(center).X, Point.Round(center).Y)
         _rasterImageViewer.CenterAtPoint(lPoint)
         _rasterImageViewer.EndUpdate()
         _rasterImageViewer_TransformChanged(_rasterImageViewer, EventArgs.Empty)
         UpdateUIState()
      End If
   End Sub

   Private Function ToMatrix(ByVal LMatrix As LeadMatrix) As Matrix
      Return New Matrix(CSng(LMatrix.M11), CSng(LMatrix.M12), CSng(LMatrix.M21), CSng(LMatrix.M22), CSng(LMatrix.OffsetX), CSng(LMatrix.OffsetY))
   End Function

   Private Sub _fitPageWidthToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs)
      FitPage(True)
      ZonesUpdated()
   End Sub

   Private Sub _fitPageToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs)
      FitPage(False)
   End Sub

   Private Sub _selectModeToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs)
      InteractiveMode = ViewerControlInteractiveMode.SelectMode
   End Sub

   Private Sub _panModeToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs)
      InteractiveMode = ViewerControlInteractiveMode.PanMode
   End Sub

   Private Sub _zoomToSelectionModeToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs)
      InteractiveMode = ViewerControlInteractiveMode.ZoomToSelectionMode
   End Sub

   Private Sub _zonePropertiesToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs)
   End Sub

   Private Sub _showZonesToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs)
      ShowZones = _showZonesToolStripButton.Checked
      tsToggleSubzones.Enabled = _showZonesToolStripButton.Checked
      tsToggleSubzones.Checked = tsToggleSubzones.Checked AndAlso tsToggleSubzones.Enabled
      ZonesUpdated()
      _rasterImageViewer.Invalidate()
   End Sub

   Private Sub tzOMRREgion_Click(ByVal sender As Object, ByVal e As EventArgs)
      PrepareAnnotationObject(ZoneType.OmrField)
      Dim isChecked As Boolean = (TryCast(sender, ToolStripButton)).Checked
      SetZoneTSButtonCheckState(isChecked)
      tsZOMRRegion.Checked = isChecked
      currentZoneType = If(tsZOMRRegion.Checked, ZoneType.OmrField, ZoneType.None)
   End Sub

   Private Sub tzBarcode_Click(ByVal sender As Object, ByVal e As EventArgs)
      PrepareAnnotationObject(ZoneType.Barcode)
      Dim isChecked As Boolean = (TryCast(sender, ToolStripButton)).Checked
      SetZoneTSButtonCheckState(isChecked)
      tszBarcode.Checked = isChecked
      currentZoneType = If(tszBarcode.Checked, ZoneType.Barcode, ZoneType.None)
   End Sub

   Private Sub tzOCR_Click(ByVal sender As Object, ByVal e As EventArgs)
      PrepareAnnotationObject(ZoneType.Text)
      Dim isChecked As Boolean = (TryCast(sender, ToolStripButton)).Checked
      SetZoneTSButtonCheckState(isChecked)
      tsZOCR.Checked = isChecked
      currentZoneType = If(tsZOCR.Checked, ZoneType.Text, ZoneType.None)
   End Sub

   Private Sub tszImage_Click(ByVal sender As Object, ByVal e As EventArgs)
      PrepareAnnotationObject(ZoneType.Image)
      Dim isChecked As Boolean = (TryCast(sender, ToolStripButton)).Checked
      SetZoneTSButtonCheckState(isChecked)
      tszImage.Checked = isChecked
      currentZoneType = If(tszImage.Checked, ZoneType.Image, ZoneType.None)
   End Sub

   Private Sub PrepareAnnotationObject(ByVal zoneType As ZoneType)
      Dim obj As AnnAutomationObject = _annAutomationManager.FindObjectById(AnnObject.UserObjectId)

      If obj IsNot Nothing Then
         obj.ObjectTemplate.Stroke.Stroke = New AnnSolidColorBrush() With {
             .Color = GetZoneColor(zoneType)
         }
      End If
   End Sub

   Private Sub SetZoneTSButtonCheckState(ByVal isChecked As Boolean)
      SetZoneTSButtonCheckFalse()
      InteractiveMode = If(isChecked, ViewerControlInteractiveMode.DrawZoneMode, ViewerControlInteractiveMode.SelectMode)
   End Sub

   Private Sub SetZoneTSButtonCheckFalse()
      tszBarcode.Checked = False
      tsZOCR.Checked = False
      tsZOMRRegion.Checked = False
   End Sub

   Private Sub _rasterImageViewer_MouseHover(ByVal sender As Object, ByVal e As EventArgs)
   End Sub

   Private Function GetMatrixFromLeadMatrix(ByVal matrix As LeadMatrix) As Matrix
      Return New Matrix(CSng(matrix.M11), CSng(matrix.M12), CSng(matrix.M21), CSng(matrix.M22), CSng(matrix.OffsetX), CSng(matrix.OffsetY))
   End Function

   Private Function PhysicalToLogical(ByVal x As Integer, ByVal y As Integer) As LeadPoint
      Return PhysicalToLogical(New LeadPoint(x, y))
   End Function

   Public Function PhysicalToLogical(ByVal physical As LeadPoint) As LeadPoint
      Dim pixelsF As PointF = New PointF(physical.X, physical.Y)

      Using m As Matrix = GetMatrixFromLeadMatrix(_rasterImageViewer.GetImageTransformWithDpi(True))
         Dim trans As Transformer = New Transformer(m)
         pixelsF = trans.PointToLogical(pixelsF)
      End Using

      Dim pixels As Point = Point.Round(pixelsF)
      Return New LeadPoint(pixels.X, pixels.Y)
   End Function

   Private Sub newToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      If _templateFrm IsNot Nothing AndAlso _templateFrm.Pages.Count > 0 Then
         Dim dr As DialogResult = MessageBox.Show(Me.ParentForm, "Save changes?", "Closing", MessageBoxButtons.YesNoCancel)
         Dim saved As Boolean = False

         If dr = DialogResult.Yes Then
            saved = DoSave()
         End If

         If dr = DialogResult.No OrElse saved Then
            OnCloseRequested(CloseRequestArgs.ClosingReason.ExplicitNew)
         End If
      Else
         CreateNewTemplate()
      End If
   End Sub

   Public Sub AddPagesToTemplate(Optional ByVal startingPageIndex As Integer = 0)
      Dim ntd As NewTemplateDialog = If(startingPageIndex = 0, New NewTemplateDialog(), New NewTemplateDialog(startingPageIndex))

      If ntd.ShowDialog() = DialogResult.OK Then
         Dim image As RasterImage = ntd.LoadedImage.CloneAll()
         Dim bo As CreateNewTemplateOperation = New CreateNewTemplateOperation(image, _templateFrm)
         bo.Start()

         If bo.IsLoadingError Then

            If _templateFrm.Pages.Count > 0 Then
               MessageBox.Show("Some pages did not have any OMR marks detected.  Only pages with OMR marks have been added to the template.")
            Else
               MessageBox.Show("No OMR marks were detected on any page in the input document.  Please use a document with OMR marks present on at least one page.")
               Return
            End If
         End If

         If startingPageIndex = 0 Then
            Me._templateFrm.Name = ntd.TemplateName
         End If

         If ntd.LoadedImage IsNot Nothing AndAlso _templateFrm IsNot Nothing Then
            Dim current As Cursor = Me.Cursor
            Me.Cursor = Cursors.WaitCursor
            SetImageAndPage(image)
            _currentFileName = Path.ChangeExtension(ntd.FileName, MainForm.TEMPLATE_EXT)
            Me.Cursor = current
         End If

         image.Dispose()
      End If

      ntd.Dispose()
   End Sub

   Public Sub CreateNewTemplate()
      Dim engine As OmrEngine = MainForm.GetOmrEngine()
      Me._templateFrm = engine.CreateTemplateForm()
      Me._templateFrm.AutoEstimateMissingOmr = MainForm.AutoEstimateMissingOmr
      AddPagesToTemplate()
   End Sub

   Private Sub openToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      CloseCurrentTemplate(CloseRequestArgs.ClosingReason.ToLoadExisting)
   End Sub

   Public Sub ShowLoadTemplate()
      Dim input As String = ""

      If MainForm.ChooseTemplate(input) Then
         LoadTemplate(input)
      End If
   End Sub

   Private Sub saveasToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      DoSaveAs()
   End Sub

   Private Function DoSaveAs() As Boolean
      Dim sfd As SaveFileDialog = New SaveFileDialog()
      sfd.Filter = String.Format("Lead Omr Template|*{0}", MainForm.TEMPLATE_EXT)
      sfd.Title = "Save Omr Template As"

      If String.IsNullOrWhiteSpace(_currentFileName) = False Then
         Dim file As String = Path.GetFileName(_currentFileName)
         Dim dir As String = Path.GetDirectoryName(_currentFileName)
         sfd.InitialDirectory = dir
         sfd.FileName = file
      End If

      If sfd.ShowDialog() = DialogResult.OK Then
         Return SaveTemplate(sfd.FileName)
      End If

      Return False
   End Function

   Private Sub saveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      DoSave()
   End Sub

   Public Function DoSave() As Boolean
      If _templateFrm Is Nothing OrElse _templateFrm.Pages.Count = 0 Then
         Return True
      End If

      If String.IsNullOrEmpty(_currentFileName) Then
         Return DoSaveAs()
      Else
         Return SaveTemplate(_currentFileName)
      End If
   End Function

   Private Function SaveTemplate(ByVal fname As String) As Boolean
      Dim success As Boolean = True
      fname = Path.ChangeExtension(fname, MainForm.TEMPLATE_EXT)
      _currentFileName = fname
      Dim fs As FileStream = Nothing

      Try
         fs = New FileStream(fname, FileMode.OpenOrCreate, FileAccess.Write)
         _templateFrm.Save(fs)
      Catch ex As Exception
         success = False
         MessageBox.Show(String.Format("Unable to save form template:" & Constants.vbLf & "{0}", ex.Message))
      Finally

         If fs IsNot Nothing Then
            fs.Close()
         End If
      End Try

      Return success
   End Function

   Private Sub LoadTemplate(ByVal selectedPath As String)
      _templateFrm = MainForm.GetOmrEngine().CreateTemplateForm()
      Dim current As Cursor = Me.Cursor
      Me.Cursor = Cursors.WaitCursor
      Dim success As Boolean = True

      Using fs As FileStream = New FileStream(selectedPath, FileMode.Open, FileAccess.Read)

         Try
            _templateFrm.Load(fs)
         Catch __unusedException1__ As Exception
            success = False
         Finally
            Me.Cursor = current
            fs.Close()
         End Try
      End Using

      If success AndAlso _templateFrm.Pages.Count > 0 Then
         _currentFileName = selectedPath
         SetImageAndPage(_templateFrm.Pages(0).Image)
      Else
         MessageBox.Show("Unable to load form template.")
      End If
   End Sub

   Public Sub AssignTemplate(ByVal _templateFrmParam As ITemplateForm)
      Me._templateFrm = _templateFrmParam
      SetImageAndPage(_templateFrm.Pages(0).Image)
   End Sub

   Private Sub trvForm_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
      Dim node As TreeNode = trvForm.GetNodeAt(e.Location)

      If node Is Nothing OrElse node.Tag Is Nothing Then
         DisableHilite()
         Return
      End If

      Dim hiliteParams As Tuple(Of String, LeadRect, Integer) = CType(node.Tag, Tuple(Of String, LeadRect, Integer))

      If hiliteParams.Item3 = _currentPageIndex + 1 Then
         EnableHiLite(hiliteParams.Item1, hiliteParams.Item2)
      End If
   End Sub

   Private Sub EnableHiLite(ByVal color As String, ByVal rc As LeadRect)
      _rasterImageViewer.BeginUpdate()
      Dim rect As LeadRectD = BoundsToAnnotations(rc, _annAutomation.Container)
      _regionHighlight.Rect = rect
      _regionHighlight.HiliteColor = color
      _regionHighlight.IsVisible = True
      _rasterImageViewer.EndUpdate()
      _rasterImageViewer.Invalidate()
   End Sub

   Private Sub trvForm_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
      If Me.ContainsFocus Then
         DisableHilite()
      End If
   End Sub

   Private Sub DisableHilite()
      _rasterImageViewer.BeginUpdate()
      _regionHighlight.IsVisible = False
      _rasterImageViewer.EndUpdate()
      _rasterImageViewer.Invalidate()
   End Sub

   Private _preventExpand As Boolean = False
   Private _lastMouseDown As DateTime = DateTime.Now

   Private Sub trvForm_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As TreeNodeMouseClickEventArgs)
      Dim node As TreeNode = e.Node
      EditNode(node)
   End Sub

   Private Sub EditNode(ByVal node As TreeNode)
      If node Is Nothing Then
         Return
      End If

      Dim path As String() = node.FullPath.Split(New String() {trvForm.PathSeparator}, StringSplitOptions.None)

      If path.Length = 1 Then
         Dim fsd As FormSpecificDialog = New FormSpecificDialog(_templateFrm)

         If fsd.ShowDialog() = DialogResult.OK Then
            node.Name = _templateFrm.Name
            node.Text = _templateFrm.Name
         End If

         Return
      End If

      Dim pg As Page = Nothing

      If path.Length >= 2 Then
         pg = _templateFrm.Pages.FirstOrDefault(Function(f) f.PageName = path(1))
      End If

      Dim field As Field = Nothing

      If path.Length >= 3 AndAlso pg IsNot Nothing Then
         Dim fieldName As String = path(2)
         field = pg.Fields.FirstOrDefault(Function(f) f.Name = fieldName)
      ElseIf pg IsNot Nothing Then
         EditNode(pg, node)
      End If

      Dim omr As OmrField = Nothing
      Dim coll As OmrCollection = Nothing

      If path.Length >= 4 AndAlso field IsNot Nothing Then
         omr = TryCast(field, OmrField)

         If omr IsNot Nothing Then
            coll = omr.Fields.Find(Function(c) c.Name = path(3))
         End If
      ElseIf field IsNot Nothing Then
         EditNode(field, node)
      End If

      If path.Length >= 5 AndAlso coll IsNot Nothing Then

         If coll.Fields.Count >= node.Index Then
            coll.Fields(node.Index) = EditNode(coll.Fields(node.Index), node)
         End If
      ElseIf coll IsNot Nothing Then
         Dim isGraded As Boolean = (CType(field, OmrField)).Options.GradeThisField
         EditNode(coll, node, isGraded)
      End If
   End Sub

   Private Function EditNode(ByVal f As OmrBubble, ByVal node As TreeNode) As OmrBubble
      EnableHiLite(GetZoneColor(f), f.Bounds)
      Dim tid As TextInputDialog = New TextInputDialog(f.Value)

      If tid.ShowDialog() = DialogResult.OK Then
         f.Value = tid.Value
         node.Text = f.Value
         node.Name = f.Value
      End If

      DisableHilite()
      Return f
   End Function

   Private Sub EditNode(ByVal f As OmrCollection, ByVal node As TreeNode, ByVal isGraded As Boolean)
      If node.Tag IsNot Nothing Then
         Dim hlp As Tuple(Of String, LeadRect, Integer) = CType(node.Tag, Tuple(Of String, LeadRect, Integer))
         EnableHiLite(hlp.Item1, hlp.Item2)
         TryGotoPage(hlp.Item3 - 1)
      End If

      Dim ocd As OmrCollectionDialog = New OmrCollectionDialog(f, isGraded)

      If ocd.ShowDialog() = DialogResult.OK Then
         node.Text = f.Name
         node.Name = f.Name
      End If

      DisableHilite()
   End Sub

   Private Sub EditNode(ByVal f As Field, ByVal node As TreeNode)
      EnableHiLite(GetZoneColor(f), f.Bounds)
      TryGotoPage(f.PageNumber - 1)
      Dim updateIdentifier As Boolean = _templateFrm.IdentifierFieldId IsNot Nothing AndAlso f.Name = _templateFrm.IdentifierFieldId.FieldName AndAlso f.PageNumber = _templateFrm.IdentifierFieldId.PageNumber

      If TypeOf f Is BarcodeField Then
         Dim bcffd As BarcodeFieldDialog = New BarcodeFieldDialog(TryCast(f, BarcodeField), _rasterImageViewer.Image.Clone())

         If bcffd.ShowDialog() = DialogResult.OK Then
            node.Text = f.Name
            node.Name = f.Name
         End If
      End If

      If TypeOf f Is OmrField Then
         Dim offd As OmrFieldDialog = New OmrFieldDialog(TryCast(f, OmrField), _templateFrm.Pages(f.PageNumber - 1).Image.Clone())

         If offd.ShowDialog() = DialogResult.OK Then
            Dim newNode As TreeNode = CreateNewNode(f)
            node.Text = newNode.Text
            node.Name = newNode.Name
            node.Nodes.Clear()
            Dim newSubnodes As TreeNode() = New TreeNode(newNode.GetNodeCount(False) - 1) {}
            newNode.Nodes.CopyTo(newSubnodes, 0)
            node.Nodes.AddRange(newSubnodes)
         End If
      End If

      If TypeOf f Is OcrField OrElse TypeOf f Is ImageField Then
         Dim tid As TextInputDialog = New TextInputDialog(f.Name)

         If tid.ShowDialog() = DialogResult.OK Then
            f.Name = tid.Value
            node.Text = f.Name
            node.Name = f.Name
         End If
      End If

      If updateIdentifier Then
         _templateFrm.IdentifierFieldId = New FieldId(f.PageNumber, f.Name)
      End If

      DisableHilite()
   End Sub

   Private Sub EditNode(ByVal pg As Page, ByVal node As TreeNode)
      Dim tid As TextInputDialog = New TextInputDialog(pg.PageName)

      If tid.ShowDialog() = DialogResult.OK Then
         pg.PageName = tid.Value
         node.Text = pg.PageName
         node.Name = pg.PageName
      End If
   End Sub

   Private Sub trvForm_BeforeCollapse(ByVal sender As Object, ByVal e As TreeViewCancelEventArgs)
      e.Cancel = _preventExpand
      _preventExpand = False
   End Sub

   Private Sub trvForm_BeforeExpand(ByVal sender As Object, ByVal e As TreeViewCancelEventArgs)
      e.Cancel = _preventExpand
      _preventExpand = False
   End Sub

   Private Sub trvForm_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
      Dim delta As Integer = CInt(DateTime.Now.Subtract(_lastMouseDown).TotalMilliseconds)
      _preventExpand = (delta < SystemInformation.DoubleClickTime)
      _lastMouseDown = DateTime.Now
   End Sub

   Private Sub trvForm_NodeMouseClick(ByVal sender As Object, ByVal e As TreeNodeMouseClickEventArgs)
      If e.Button = MouseButtons.Right Then
         trvForm.SelectedNode = e.Node
         Dim cms As ContextMenuStrip = BuildContextMenu(e.Node)
         cms.Show(trvForm, e.Location, ToolStripDropDownDirection.[Default])
      End If

      Dim ff As String = GetNodeUnderlyingType(e.Node.FullPath.Split(New String() {trvForm.PathSeparator}, StringSplitOptions.None))

      If ff = "Page" Then
         TryGotoPage(e.Node.Index)
      End If
   End Sub

   Private Function BuildContextMenu(ByVal node As TreeNode) As ContextMenuStrip
      Dim cms As ContextMenuStrip = New ContextMenuStrip()
      Dim ff As String = GetNodeUnderlyingType(node.FullPath.Split(New String() {trvForm.PathSeparator}, StringSplitOptions.None))
      cms.Items.Add("Edit Node", Nothing, New EventHandler(Sub(sender As Object, e As EventArgs)
                                                              EditNode(node)
                                                           End Sub))

      If node.Nodes.Count > 0 Then
         cms.Items.Add(New ToolStripSeparator())

         If node.IsExpanded Then
            cms.Items.Add("Collapse", Nothing, New EventHandler(Sub(sender As Object, e As EventArgs)
                                                                   node.Collapse()
                                                                End Sub))
         Else
            cms.Items.Add("Expand", Nothing, New EventHandler(Sub(sender As Object, e As EventArgs)
                                                                 node.Expand()
                                                              End Sub))
         End If
      End If

      If ff = "OmrField" Then
         cms.Items.Add(New ToolStripSeparator())
         cms.Items.Add("Renumber Items...", Nothing, New EventHandler(Sub(sender As Object, e As EventArgs)
                                                                         ReNumberElements(node)
                                                                      End Sub))
         cms.Items.Add("Rename to Note", Nothing, New EventHandler(Sub(sender As Object, e As EventArgs)
                                                                      RenameElementsFromNote(node)
                                                                   End Sub))
      End If

      If ff = "Page" Then
         cms.Items.Add(New ToolStripSeparator())
         Dim max As Integer = node.Parent.GetNodeCount(False)
         Dim deletePage As ToolStripMenuItem = New ToolStripMenuItem("&Delete Page", Nothing, AddressOf deletePageToolStripMenuItem_Click)
         deletePage.Enabled = _templateFrm.Pages.Count > 0
         cms.Items.Add(deletePage)
         cms.Items.Add(New ToolStripSeparator())
         Dim tsmiMovePageUp As ToolStripMenuItem = New ToolStripMenuItem("Move Page &Up", Nothing, AddressOf movePageUpToolStripMenuItem_Click)
         tsmiMovePageUp.Enabled = node.Index > 0
         cms.Items.Add(tsmiMovePageUp)
         Dim tsmiMovePageDown As ToolStripMenuItem = New ToolStripMenuItem("Move Page &Down", Nothing, AddressOf movePageDownToolStripMenuItem_Click)
         tsmiMovePageDown.Enabled = node.Index < max - 1
         cms.Items.Add(tsmiMovePageDown)
      End If

      If ff = "Field" OrElse ff = "OmrField" Then
         cms.Items.Add(New ToolStripSeparator())
         Dim tsmiUp As ToolStripMenuItem = New ToolStripMenuItem("Move Up", Nothing, New EventHandler(Sub(sender As Object, e As EventArgs)
                                                                                                         MoveNode(node, -1)
                                                                                                      End Sub))
         tsmiUp.Enabled = node.Index > 0
         cms.Items.Add(tsmiUp)
         Dim tsmiDown As ToolStripMenuItem = New ToolStripMenuItem("Move Down", Nothing, New EventHandler(Sub(sender As Object, e As EventArgs)
                                                                                                             MoveNode(node, 1)
                                                                                                          End Sub))
         Dim max As Integer = node.Parent.GetNodeCount(False)
         tsmiDown.Enabled = node.Index < max - 1
         cms.Items.Add(tsmiDown)
         cms.Items.Add(New ToolStripSeparator())
         cms.Items.Add("Delete", Nothing, New EventHandler(Sub(sender As Object, e As EventArgs)
                                                              DeleteNode(node)
                                                           End Sub))
      End If

      Return cms
   End Function

   Private Sub RenameElementsFromNote(ByVal node As TreeNode)
      Dim path As String() = node.FullPath.Split(New String() {trvForm.PathSeparator}, StringSplitOptions.None)
      Dim omrField As OmrField = TryCast(_templateFrm.Pages.FirstOrDefault(Function(f) f.PageName = path(1)).Fields.FirstOrDefault(Function(f) f.Name = path(2)), OmrField)

      If omrField Is Nothing Then
         Return
      End If

      For i As Integer = 0 To omrField.Fields.Count - 1
         Dim f As OmrCollection = omrField.Fields(i)
         Dim subNode As TreeNode = node.Nodes(i)
         Dim displayText As String = If(String.IsNullOrWhiteSpace(f.Note), f.Name, f.Note)
         f.Name = displayText
         subNode.Text = displayText
         subNode.Name = displayText
      Next
   End Sub

   Private Function GetNodeUnderlyingType(ByVal v As String()) As String
      Dim types As String() = New String() {"Template", "Page", "Field", "OmrCollection", "OmrBubble"}

      If v.Length <> 3 Then
         Return types(v.Length - 1)
      End If

      Dim pg As Page = _templateFrm.Pages.FirstOrDefault(Function(f) f.PageName = v(1))

      If pg IsNot Nothing Then
         Return If(TryCast(pg.Fields.FirstOrDefault(Function(f) f.Name = v(2)), OmrField) IsNot Nothing, "OmrField", "Field")
      End If

      Return String.Empty
   End Function

   Private Sub ReNumberElements(ByVal node As TreeNode)
      Dim path As String() = node.FullPath.Split(New String() {trvForm.PathSeparator}, StringSplitOptions.None)
      Dim omrField As OmrField = TryCast(_templateFrm.Pages.FirstOrDefault(Function(f) f.PageName = path(1)).Fields.FirstOrDefault(Function(f) f.Name = path(2)), OmrField)

      If omrField Is Nothing Then
         Return
      End If

      Dim rnd As RowNumberDialog = New RowNumberDialog(omrField)

      If rnd.ShowDialog() = DialogResult.OK Then
         ReNumberElements(node, omrField, rnd.Template, rnd.StartingValue)
      End If
   End Sub

   Private Shared Sub ReNumberElements(ByVal node As TreeNode, ByVal omrField As OmrField, ByVal text As String, ByVal value As Integer)
      For i As Integer = 0 To omrField.Fields.Count - 1
         Dim f As OmrCollection = omrField.Fields(i)
         Dim subNode As TreeNode = node.Nodes(i)
         Dim displayText As String = text.Replace("%", (value + i).ToString())
         f.Name = displayText
         subNode.Text = displayText
         subNode.Name = displayText
      Next
   End Sub

   Private Sub _rasterImageViewer_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs)
      If _rasterImageViewer.Image Is Nothing Then
         Return
      End If

      Dim logicalPoint As LeadPoint = PhysicalToLogical(e.X, e.Y)
      Dim pageNode As TreeNode = trvForm.Nodes(0).Nodes(_templateFrm.Pages(_currentPageIndex).PageName)
      Dim hitField As Field = _templateFrm.Pages(_currentPageIndex).Fields.FirstOrDefault(Function(f) f.Bounds.Contains(logicalPoint))

      If hitField IsNot Nothing AndAlso pageNode IsNot Nothing Then
         Dim fieldNode As TreeNode = pageNode.Nodes(hitField.Name)
         Dim hitOmrField As OmrField = TryCast(hitField, OmrField)

         If hitOmrField IsNot Nothing AndAlso fieldNode IsNot Nothing Then
            Dim hitColl As OmrCollection = hitOmrField.Fields.FirstOrDefault(Function(f) f.Bounds.Contains(logicalPoint))

            If hitColl IsNot Nothing Then
               Dim colNode As TreeNode = fieldNode.Nodes(hitColl.Name)

               If colNode IsNot Nothing Then

                  If hitOmrField.FieldBubbleLayoutType = OmrFieldBubbleLayoutType.BubbleWithLabel Then

                     If hitColl.Fields.Any(Function(f) f.Bounds.Contains(logicalPoint)) Then
                        Dim hitBubble As OmrBubble = hitColl.Fields.FirstOrDefault(Function(f) f.Bounds.Contains(logicalPoint))
                        Dim index As Integer = hitColl.Fields.IndexOf(hitBubble)
                        Dim bubbleNode As TreeNode = colNode.Nodes(index)

                        If colNode.Nodes.Count >= index Then
                           hitColl.Fields(bubbleNode.Index) = EditNode(hitColl.Fields(bubbleNode.Index), bubbleNode)
                        End If
                     Else
                        EditNode(hitColl, colNode, hitOmrField.Options.GradeThisField)
                     End If
                  Else
                     EditNode(hitColl, colNode, hitOmrField.Options.GradeThisField)
                  End If
               End If
            Else
               EditNode(hitOmrField, fieldNode)
            End If
         ElseIf fieldNode IsNot Nothing Then
            EditNode(hitField, fieldNode)
         End If
      ElseIf pageNode IsNot Nothing Then
         EditNode(_templateFrm.Pages(_currentPageIndex), pageNode)
      End If
   End Sub

   Private Sub tsToggleSubzones_Click(ByVal sender As Object, ByVal e As EventArgs)
      ZonesUpdated()
   End Sub

   Private Sub _rasterImageViewer_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
      If currentZoneType <> ZoneType.None OrElse _rasterImageViewer.Image Is Nothing OrElse _templateFrm Is Nothing OrElse _templateFrm.Pages Is Nothing OrElse _templateFrm.Pages.Count = 0 Then
         Return
      End If

      Dim cursor As Cursor = _rasterImageViewer.Cursor
      Dim c As Cursor = Cursors.Cross
      Dim logicalPoint As LeadPoint = PhysicalToLogical(e.X, e.Y)
      Dim hitField As Field = _templateFrm.Pages(_currentPageIndex).Fields.FirstOrDefault(Function(f) f.Bounds.Contains(logicalPoint))

      If hitField IsNot Nothing Then
         Dim hitOmrField As OmrField = TryCast(hitField, OmrField)

         If hitOmrField IsNot Nothing Then
            Dim hitColl As OmrCollection = hitOmrField.Fields.FirstOrDefault(Function(f) f.Bounds.Contains(logicalPoint))

            If hitColl IsNot Nothing Then

               If hitOmrField.FieldBubbleLayoutType = OmrFieldBubbleLayoutType.BubbleWithLabel Then

                  If hitColl.Fields.Any(Function(f) f.Bounds.Contains(logicalPoint)) Then
                     Dim hitBubble As OmrBubble = hitColl.Fields.FirstOrDefault(Function(f) f.Bounds.Contains(logicalPoint))
                     EnableHiLite(GetZoneColor(hitBubble), hitBubble.Bounds)
                  Else
                     EnableHiLite(GetZoneColor(hitColl), hitColl.Bounds)
                  End If
               Else
                  EnableHiLite(GetZoneColor(hitColl), hitColl.Bounds)
               End If
            Else
               EnableHiLite(GetZoneColor(hitOmrField), hitOmrField.Bounds)
            End If
         ElseIf hitField IsNot Nothing Then
            EnableHiLite(GetZoneColor(hitField), hitField.Bounds)
         End If
      Else
         DisableHilite()
      End If

      Return
   End Sub

   Private Sub _rasterImageViewer_Leave(ByVal sender As Object, ByVal e As EventArgs)
   End Sub

   Private Sub optionsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim od As OptionsDialog = New OptionsDialog(MainForm.AutoEstimateMissingOmr)
      od.ShowDialog()
      MainForm.AutoEstimateMissingOmr = od.AutoEstimateMissingOmr
      timer.Interval = CInt(TimeSpan.FromMinutes(Settings.Default.AutoSaveDelay).TotalMilliseconds)
   End Sub

   Private Sub addPageToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      AddPagesToTemplate(_templateFrm.Pages.Count)
      TryGotoPage(_templateFrm.Pages.Count - 1)
   End Sub

   Private Sub deletePageToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      DeletePage(trvForm.Nodes(0).Nodes(_currentPageIndex))
   End Sub

   Private Sub movePageUpToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      MovePage(trvForm.Nodes(0).Nodes(_currentPageIndex), -1)
   End Sub

   Private Sub movePageDownToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      MovePage(trvForm.Nodes(0).Nodes(_currentPageIndex), 1)
   End Sub

   Private Sub editToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      For i As Integer = 0 To editToolStripMenuItem.DropDownItems.Count - 1
         editToolStripMenuItem.DropDownItems(i).Enabled = _templateFrm IsNot Nothing
      Next

      If _templateFrm Is Nothing Then
         Return
      End If

      Dim node As TreeNode = trvForm.Nodes(0).Nodes(_currentPageIndex)
      Dim max As Integer = node.Parent.GetNodeCount(False)
      movePageUpToolStripMenuItem.Enabled = node.Index > 0
      movePageDownToolStripMenuItem.Enabled = node.Index < max - 1
      editNodeToolStripMenuItem.Enabled = trvForm.SelectedNode IsNot Nothing
   End Sub

   Private Sub deskewToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim rc As RasterCommand = New DeskewCommand()
      ExecuteRasterCommand(rc)
   End Sub

   Private Sub ExecuteRasterCommand(ByVal rc As RasterCommand)
      Dim image As RasterImage = _templateFrm.Pages(_currentPageIndex).Image

      If _templateFrm.Pages(_currentPageIndex).Fields.Count > 0 Then
         Dim dr As DialogResult = MessageBox.Show("This will delete the fields on this page.  Are you sure?", "Confirm", MessageBoxButtons.YesNo)

         If dr = DialogResult.No Then
            Return
         End If
      End If

      Dim current As Cursor = Me.Cursor

      Try
         Me.Cursor = Cursors.WaitCursor
         rc.Run(image)
      Catch __unusedException1__ As Exception
         MessageBox.Show("Performing this will invalidate the image.")
      Finally
         Me.Cursor = current
      End Try
   End Sub

   Private Sub by90DegreesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim rc As RotateCommand = New RotateCommand(9000, RotateCommandFlags.None, RasterColor.Black)
      ExecuteRasterCommand(rc)
   End Sub

   Private Sub by180DegreesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim rc As RotateCommand = New RotateCommand(18000, RotateCommandFlags.None, RasterColor.Black)
      ExecuteRasterCommand(rc)
   End Sub

   Private Sub by270DegreesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim rc As RotateCommand = New RotateCommand(27000, RotateCommandFlags.None, RasterColor.Black)
      ExecuteRasterCommand(rc)
   End Sub

   Private Sub horizontallyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim rc As RasterCommand = New FlipCommand(True)
      ExecuteRasterCommand(rc)
   End Sub

   Private Sub verticallyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim rc As RasterCommand = New FlipCommand(False)
      ExecuteRasterCommand(rc)
   End Sub

   Private pvf As PanViewerForm

   Private Sub tssShowPanWindow_Click(ByVal sender As Object, ByVal e As EventArgs)
      If pvf Is Nothing Then
         pvf = New PanViewerForm()
         pvf.Owner = Me.ParentForm
      End If

      If _rasterImageViewer.Image IsNot Nothing Then
         pvf.SetViewer(_rasterImageViewer)
      Else
         pvf.SetViewer(Nothing)
      End If

      If pvf.Visible = False Then
         pvf.Show()
      End If
   End Sub

   Private Sub aboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim ab As Demos.Dialogs.AboutDialog = New Demos.Dialogs.AboutDialog("OMR Processing", Demos.Dialogs.ProgrammingInterface.VB)
      ab.ShowDialog(Me.ParentForm)
   End Sub

   Private Sub closeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      CloseCurrentTemplate(CloseRequestArgs.ClosingReason.RevertToIntro)
   End Sub

   Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      CloseCurrentTemplate(CloseRequestArgs.ClosingReason.ApplicationExiting)
   End Sub

   Private Sub CloseCurrentTemplate(ByVal closeReason As CloseRequestArgs.ClosingReason)
      If _templateFrm IsNot Nothing Then
         Dim saveHandled As Boolean = DoCloseTemplate()

         If saveHandled Then
            OnCloseRequested(closeReason)
         End If
      Else
         OnCloseRequested(closeReason)
      End If
   End Sub

   Public Function DoCloseTemplate() As Boolean
      If _templateFrm Is Nothing OrElse _templateFrm.Pages.Count = 0 Then
         Return True
      End If

      Dim saved As Boolean = False
      Dim dr As DialogResult = MessageBox.Show(Me.ParentForm, "Save changes to the current template?", "Closing", MessageBoxButtons.YesNoCancel)

      If dr = DialogResult.Yes Then
         saved = DoSave()
      ElseIf dr = DialogResult.No Then
         Return True
      ElseIf dr = DialogResult.Cancel Then
         Return False
      End If

      Return saved
   End Function

   Private Sub OnCloseRequested(ByVal state As CloseRequestArgs.ClosingReason)
      RaiseEvent CloseRequested(Me, New CloseRequestArgs(state))
   End Sub

   Private Sub editNodeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim node As TreeNode = trvForm.SelectedNode
      EditNode(node)
   End Sub

   Private Sub trvForm_AfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs)
      Dim node As TreeNode = e.Node

      If node Is Nothing OrElse node.Tag Is Nothing Then
         DisableHilite()
         Return
      End If

      Dim hiliteParams As Tuple(Of String, LeadRect, Integer) = CType(node.Tag, Tuple(Of String, LeadRect, Integer))

      If hiliteParams.Item3 = _currentPageIndex + 1 Then
         EnableHiLite(hiliteParams.Item1, hiliteParams.Item2)
      End If
   End Sub

   Private Sub trvForm_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
      If trvForm.SelectedNode Is Nothing Then
         Return
      End If

      Dim node As TreeNode = trvForm.SelectedNode
      Dim ff As String = GetNodeUnderlyingType(node.FullPath.Split(New String() {trvForm.PathSeparator}, StringSplitOptions.None))

      If e.KeyCode = Keys.Delete AndAlso (ff = "Field" OrElse ff = "OmrField") Then
         DeleteNode(trvForm.SelectedNode)
      ElseIf e.KeyCode = Keys.Delete AndAlso ff = "Page" Then
         DeletePage(node)
      ElseIf e.KeyCode = Keys.Enter Then
         EditNode(node)
      End If
   End Sub

   Private Sub informationToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim id As InfoDialog = New InfoDialog()
      id.ShowDialog(Me.ParentForm)
   End Sub
End Class
