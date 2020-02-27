' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

Imports Leadtools
Imports Leadtools.Controls
Imports Leadtools.Ocr
Imports Leadtools.Annotations.Automation
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.Designers
Imports Leadtools.Annotations.WinForms
Imports Leadtools.Drawing
Imports System

Namespace OcrDemo.ViewerControl
   ''' <summary>
   ''' This control contains an instance of RasterImageViewer plus
   ''' a tool strip control for common operations
   ''' </summary>
   Partial Public Class ViewerControl
      Inherits UserControl
      ' Minimum and maximum scale percentages allowed
      Private Const _minimumViewerScalePercentage As Double = 1
      Private Const _maximumViewerScalePercentage As Double = 6400
      Private _automationInteractiveMode As AutomationInteractiveMode = Nothing
      Private _panInteractiveMode As ImageViewerPanZoomInteractiveMode = Nothing
      Private _zoomToInteractiveMode As ImageViewerZoomToInteractiveMode = Nothing
      Private _noneInteractiveMode As ImageViewerNoneInteractiveMode = Nothing

      ' Current 0-based page index and number of pages
      Private _currentPageIndex As Integer = -1
      Private _pageCount As Integer = 0

      ' Current interactive mode (with the mouse)
      Private _interactiveMode As ViewerControlInteractiveMode = ViewerControlInteractiveMode.SelectMode

      ' Current OCR page
      Private _ocrPage As IOcrPage

      ' Current document title
      Private _title As String

      ' We will use annotations to paint and edit the zones
      Private _annAutomationManager As AnnAutomationManager
      Private _annAutomation As AnnAutomation
      Private _automationManagerHelper As AutomationManagerHelper = Nothing

      Private _ignoreAddRemove As Boolean
      Private _setSelect As Boolean

      Public Sub New()
         InitializeComponent()
      End Sub

      Protected Overrides Sub OnLoad(e As EventArgs)
         If Not DesignMode Then
            ' Use ScaleToGray and Bicubic for optimum viewing of black/white and color images
            Dim props As RasterPaintProperties = _rasterImageViewer.PaintProperties
            props.PaintDisplayMode = props.PaintDisplayMode Or RasterPaintDisplayModeFlags.ScaleToGray Or RasterPaintDisplayModeFlags.Bicubic
            _rasterImageViewer.PaintProperties = props

            ' Pad the viewer
            _rasterImageViewer.ViewMargin = New Padding(10)
            _rasterImageViewer.ViewBorderThickness = 1
            _automationInteractiveMode = New AutomationInteractiveMode()
            _noneInteractiveMode = New ImageViewerNoneInteractiveMode()
            _panInteractiveMode = New ImageViewerPanZoomInteractiveMode()
            _panInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left
            _panInteractiveMode.IdleCursor = Cursors.Hand
            _panInteractiveMode.WorkingCursor = Cursors.Hand
            _zoomToInteractiveMode = New ImageViewerZoomToInteractiveMode()
            AddHandler _zoomToInteractiveMode.RubberBandCompleted, AddressOf _rasterImageViewer_InteractiveZoomTo

            _rasterImageViewer.InteractiveModes.BeginUpdate()
            _rasterImageViewer.InteractiveModes.Add(_noneInteractiveMode)
            _rasterImageViewer.InteractiveModes.Add(_automationInteractiveMode)
            _rasterImageViewer.InteractiveModes.Add(_panInteractiveMode)
            _rasterImageViewer.InteractiveModes.Add(_zoomToInteractiveMode)
            _rasterImageViewer.InteractiveModes.EndUpdate()

            DisableInteractiveModes()

            _rasterImageViewer.InteractiveModes.EnableById(_automationInteractiveMode.Id)

            ' These events are needed and not visible from the designer, so
            ' hook into them here
            AddHandler _zoomToolStripComboBox.LostFocus, AddressOf _zoomToolStripComboBox_LostFocus
            AddHandler _pageToolStripTextBox.LostFocus, AddressOf _pageToolStripTextBox_LostFocus

            ' Call the transform changed event
            _rasterImageViewer_TransformChanged(_rasterImageViewer, EventArgs.Empty)

            FitPage(False)

            _mousePositionLabel.Text = String.Empty

            ' Initialize the annotation objects
            InitAnnotations()
         End If

         MyBase.OnLoad(e)
      End Sub

      Public Sub DisableInteractiveModes()
         For Each mode As ImageViewerInteractiveMode In _rasterImageViewer.InteractiveModes
            mode.IsEnabled = False
         Next
      End Sub

      Private Sub _rasterImageViewer_InteractiveZoomTo(sender As Object, e As ImageViewerRubberBandEventArgs)
         ' Go back to selection mode
         ' We must invoke this because the select button will change the
         ' interactive mode of the viewer and hence, cancel the current
         ' operation
         BeginInvoke(New MethodInvoker(AddressOf _selectModeToolStripButton.PerformClick))
      End Sub

      ''' <summary>
      ''' Called by the main form to get/set the title (the name of the document)
      ''' </summary>
      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public Property Title() As String
         Get
            Return _titleLabel.Text
         End Get
         Set(value As String)
            _title = value
            UpdateTitle()
         End Set
      End Property

      ''' <summary>
      ''' Called by the main form to set the current 0-based page index and number of pages
      ''' </summary>
      Public Sub SetPages(currentPageIndex As Integer, pageCount As Integer)
         _currentPageIndex = currentPageIndex
         _pageCount = pageCount
         UpdateUIState()
      End Sub

      ''' <summary>
      ''' Called by the main form to get the current raster image
      ''' </summary>
      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property RasterImage() As RasterImage
         Get
            Return _rasterImageViewer.Image
         End Get
      End Property

      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property ImageViewer() As AutomationImageViewer
         Get
            Return _rasterImageViewer
         End Get
      End Property

      ''' <summary>
      ''' Called by the main form to set the new raster image and OCR page
      ''' </summary>
      ''' <param name="image"></param>
      ''' <param name="ocrPage"></param>
      Public Sub SetImageAndPage(image As RasterImage, ocrPage As IOcrPage)
         _ocrPage = ocrPage
         Dim options As ImageViewerAutoResetOptions = _rasterImageViewer.AutoResetOptions
         ' save
         _rasterImageViewer.AutoResetOptions = ImageViewerAutoResetOptions.None
         _rasterImageViewer.Image = image
         _rasterImageViewer.AutoResetOptions = options

         If image IsNot Nothing Then

            Dim saveMapper As AnnContainerMapper = _annAutomation.Container.Mapper.Clone()
            Dim identityMapper As AnnContainerMapper = New AnnContainerMapper(saveMapper.SourceDpiX, saveMapper.SourceDpiY, saveMapper.SourceDpiX, saveMapper.SourceDpiY)
            identityMapper.UpdateTransform(LeadMatrix.Identity)

            _annAutomation.Container.Mapper = identityMapper

            'Set Container Size
            If Not _annAutomation Is Nothing Then
               _annAutomation.Container.Size = identityMapper.SizeToContainerCoordinates(LeadSizeD.Create(image.ImageWidth, image.ImageHeight))
            End If

            _annAutomation.Container.Mapper = saveMapper

            ' Converts the zones to annotation objects
            ZonesUpdated()
            _rasterImageViewer.ViewBorderThickness = 1
         Else
            _rasterImageViewer.ViewBorderThickness = 0
         End If

         UpdateTitle()
         UpdateUIState()
      End Sub

      ''' <summary>
      ''' Called by the main form to change the page viewing mode (from the main menu)
      ''' </summary>
      Public Sub FitPage(fitWidth As Boolean)
         ' Since we are doing more than one operation on the viewer, it is
         ' recommended to disable then re-enable updates on the viewer to
         ' minimize flickering

         _rasterImageViewer.BeginUpdate()

         If fitWidth Then
            _rasterImageViewer.Zoom(ControlSizeMode.FitWidth, 1, _rasterImageViewer.DefaultZoomOrigin)
         Else
            _rasterImageViewer.Zoom(ControlSizeMode.FitAlways, 1, _rasterImageViewer.DefaultZoomOrigin)
         End If

         _rasterImageViewer.EndUpdate()

         UpdateUIState()
      End Sub

      ''' <summary>
      ''' Zoom the viewer in our out
      ''' </summary>
      ''' <param name="zoomOut"></param>
      Public Sub ZoomViewer(zoomOut As Boolean)
         ' Get the current scale factor
         Dim percentage As Double = _rasterImageViewer.XScaleFactor * 100.0

         ' The valid scale factors are here
         Dim validPercentages As Double() = {_minimumViewerScalePercentage, 6.25, 12.5, 25, 33.3, 50, _
          66.7, 73.6, 92.5, 100, 125, 150, _
          200, 300, 400, 600, 800, 1200, _
          1600, 2400, 3200, _maximumViewerScalePercentage}

         ' Find out where we are, move to the next one up or down depending on 'zoomOut'
         If zoomOut Then
            For i As Integer = validPercentages.Length - 1 To 0 Step -1
               If percentage > validPercentages(i) Then
                  percentage = validPercentages(i)
                  Exit For
               End If
            Next
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

      ''' <summary>
      ''' Called by the main form to get the current size mode value
      ''' </summary>
      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property CurrentSizeMode() As ControlSizeMode
         Get
            Return _rasterImageViewer.SizeMode
         End Get
      End Property

      ''' <summary>
      ''' This event is fired by the control when an action occurs that must be handled by
      ''' the owner (the main form)
      ''' </summary>
      Public Event Action As EventHandler(Of ActionEventArgs)

      ''' <summary>
      ''' Current interactive mode (what happens when the user uses the mouse on the viewer)
      ''' </summary>
      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public Property InteractiveMode() As ViewerControlInteractiveMode
         Get
            Return _interactiveMode
         End Get
         Set(value As ViewerControlInteractiveMode)
            _interactiveMode = value
            If _annAutomationManager IsNot Nothing Then
               ' Set the RasterImageViewer interactive mode accordingly
               Select Case _interactiveMode
                  Case ViewerControlInteractiveMode.SelectMode
                     _rasterImageViewer.InteractiveModes.EnableById(_automationInteractiveMode.Id)
                     _annAutomationManager.CurrentObjectId = AnnObject.None
                     _annAutomation.Cancel()
                     Exit Select

                  Case ViewerControlInteractiveMode.PanMode
                     _rasterImageViewer.InteractiveModes.EnableById(_panInteractiveMode.Id)
                     _annAutomationManager.CurrentObjectId = AnnObject.None
                     _annAutomation.Cancel()
                     Exit Select

                  Case ViewerControlInteractiveMode.ZoomToSelectionMode
                     _rasterImageViewer.InteractiveModes.EnableById(_zoomToInteractiveMode.Id)
                     _annAutomationManager.CurrentObjectId = AnnObject.None
                     _annAutomation.Cancel()
                     Exit Select

                  Case ViewerControlInteractiveMode.DrawZoneMode
                     _rasterImageViewer.InteractiveModes.EnableById(_automationInteractiveMode.Id)
                     _annAutomationManager.CurrentObjectId = AnnObject.UserObjectId
                     Exit Select
               End Select
            End If

            UpdateUIState()
         End Set
      End Property

      ''' <summary>
      ''' Called by the main form to show/hide the zones
      ''' </summary>
      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public Property ShowZones() As Boolean
         Get
            Return _showZonesToolStripButton.Checked
         End Get
         Set(value As Boolean)
            _showZonesToolStripButton.Checked = value

            ' Show hide the zones
            If _annAutomation IsNot Nothing Then
               _annAutomation.Cancel()

               For Each obj As AnnObject In _annAutomation.Container.Children
                  obj.IsVisible = value
               Next
            End If

            If Not _showZonesToolStripButton.Checked AndAlso _interactiveMode = ViewerControlInteractiveMode.DrawZoneMode Then
               _interactiveMode = ViewerControlInteractiveMode.SelectMode
            End If

            _rasterImageViewer.Invalidate()
            UpdateUIState()
         End Set
      End Property

      ''' <summary>
      ''' Called by the main form to show/hide the zone names
      ''' </summary>
      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public Property ShowZoneNames() As Boolean
         Get
            Return _showZoneNameToolStripButton.Checked
         End Get
         Set(value As Boolean)
            _showZoneNameToolStripButton.Checked = value

            ' Show hide the zones
            If _annAutomation IsNot Nothing Then
               For Each obj As ZoneAnnotationObject In _annAutomation.Container.Children
                  obj.Label.IsVisible = value
               Next
            End If

            _rasterImageViewer.Invalidate()
            UpdateUIState()
         End Set
      End Property

      ''' <summary>
      ''' Called from the main form when the zones are updated
      ''' </summary>
      Public Sub ZonesUpdated()
         ' Stop updating the viewer
         _rasterImageViewer.BeginUpdate()

         ' Remove all the annotations objects and re-add them from the zones
         If _annAutomation IsNot Nothing Then
            _annAutomation.Cancel()
            _annAutomation.Container.Children.Clear()
         End If

         _ignoreAddRemove = True
         _setSelect = True
         ' Get the rectangle automation object so we can use the template
         ' to create the new annotation objects

         Dim isVisible As Boolean = _showZonesToolStripButton.Checked AndAlso Not MainForm.PerspectiveDeskewActive AndAlso Not MainForm.UnWarpActive
         Dim isNameVisible As Boolean = _showZoneNameToolStripButton.Checked

         If (_ocrPage IsNot Nothing AndAlso _ocrPage.Zones IsNot Nothing AndAlso _ocrPage.Zones.Count > 0) Then
            For i As Integer = 0 To _ocrPage.Zones.Count - 1
               Dim zone As OcrZone = _ocrPage.Zones(i)

               Dim zoneObject As New ZoneAnnotationObject()
               zoneObject.SetZone(_ocrPage, i, isVisible, isNameVisible)

               _annAutomation.Container.Children.Add(zoneObject)

               ' Now we can calculate the object bounds correctly
               Dim rc As LeadRect = zone.Bounds
               Dim rect As LeadRectD = BoundsToAnnotations(zoneObject, rc, _annAutomation.Container)
               zoneObject.Rect = rect
            Next
         End If

         _ignoreAddRemove = False

         ' Re-update the viewer
         _rasterImageViewer.EndUpdate()

         _rasterImageViewer.Invalidate()
         UpdateUIState()
      End Sub

      Public Sub ClearZones()
         _rasterImageViewer.BeginUpdate()
         _annAutomation.Container.Children.Clear()
         _rasterImageViewer.EndUpdate()
      End Sub

      Private Function BoundsFromAnnotations(rectObject As AnnRectangleObject, container As AnnContainer) As LeadRect
         ' Convert a rectangle from annotation object to logical coordinates (top-left)
         Dim temp As LeadRectD = container.Mapper.RectFromContainerCoordinates(rectObject.Rect, AnnFixedStateOperations.None)
         If temp.IsEmpty() Then
            Return LeadRect.Empty()
         End If

         temp = _rasterImageViewer.ConvertRect(Nothing, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, temp)
         Dim rect As LeadRect = temp.ToLeadRect()
         Return rect
      End Function

      Private Function BoundsToAnnotations(rectObject As AnnRectangleObject, rect As LeadRect, container As AnnContainer) As LeadRectD
         ' Convert a rectangle from logical (top-left) to annotation object coordinates
         Dim rc As LeadRectD = rect.ToLeadRectD()
         rc = _rasterImageViewer.ConvertRect(Nothing, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, rc)
         rc = container.Mapper.RectToContainerCoordinates(rc)
         Return rc
      End Function

      ''' <summary>
      ''' Called by the main form to get/set the selected zone index
      ''' </summary>
      Public ReadOnly Property SelectedZoneIndex() As Integer
         Get
            ' Get it from the current edit object in the annotations
            Dim index As Integer = -1

            Dim zoneObj As ZoneAnnotationObject = TryCast(_annAutomation.CurrentEditObject, ZoneAnnotationObject)
            If zoneObj IsNot Nothing Then
               index = zoneObj.ZoneIndex
            End If

            Return index
         End Get
      End Property

      Private Function CreateZoneAutomationObject() As AnnAutomationObject
         Dim automationObj As New AnnAutomationObject()
         Dim zoneAnnotationObject As New ZoneAnnotationObject()

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

         ' Disable the rotation points
         automationObj.UseRotateThumbs = False
         Return automationObj

      End Function
      Private Sub InitAnnotations()
         _annAutomationManager = New AnnAutomationManager()

         ' Disable the rotation
         _annAutomationManager.RotateModifierKey = AnnKeys.None
         _annAutomationManager.EditObjectAfterDraw = False

         _annAutomationManager.CreateDefaultObjects()

         _annAutomation = New AnnAutomation(_annAutomationManager, _rasterImageViewer)
         AddHandler _annAutomation.AfterObjectChanged, AddressOf _annAutomation_AfterObjectChanged
         AddHandler _annAutomation.Container.ObjectAdded, AddressOf _annAutomationObjects_ItemAdded
         AddHandler _annAutomation.Container.ObjectRemoved, AddressOf _annAutomationObjects_ItemRemoved
         AddHandler _annAutomation.OnShowContextMenu, AddressOf _annAutomation_OnShowContextMenu
         AddHandler _annAutomation.Draw, AddressOf _annAutomation_Draw
         AddHandler _annAutomation.SetCursor, AddressOf _annAutomation_SetCursor
         AddHandler _annAutomation.RestoreCursor, AddressOf _annAutomation_RestoreCursor
         ' We are not going to do undo/redeo
         _annAutomation.UndoCapacity = 0
         ' Set this as the one and only active automation object so mouse and keyboard events
         ' get to it
         _annAutomation.Active = True
         _annAutomation.DefaultCurrentObjectId = AnnObject.None


         ' Get the rectangle and select objects
         Dim selectAutomationObject As AnnAutomationObject = GetAutomationObject(_annAutomationManager, AnnObject.SelectObjectId)

         Dim zoneAutomationObject As AnnAutomationObject = CreateZoneAutomationObject()
         _automationManagerHelper = New AutomationManagerHelper(_annAutomationManager)

         Dim zoneObjectRenderer As New ZoneAnnotationObjectRenderer()
         Dim annRectangleObjectRenderer As IAnnObjectRenderer = _annAutomationManager.RenderingEngine.Renderers(AnnObject.RectangleObjectId)
         zoneObjectRenderer.LocationsThumbStyle = annRectangleObjectRenderer.LocationsThumbStyle
         zoneObjectRenderer.RotateCenterThumbStyle = annRectangleObjectRenderer.RotateCenterThumbStyle
         zoneObjectRenderer.RotateGripperThumbStyle = annRectangleObjectRenderer.RotateGripperThumbStyle

         _annAutomationManager.Objects.Clear()

         Dim cm As New ContextMenu()
         cm.MenuItems.Add(New MenuItem("&Delete", AddressOf _zoneDeleteMenuItem_Click))
         cm.MenuItems.Add(New MenuItem("-", TryCast(Nothing, EventHandler)))
         cm.MenuItems.Add(New MenuItem("&Properties...", AddressOf _zonePropertiesMenuItem_Click))

         zoneAutomationObject.ContextMenu = cm

         _annAutomationManager.RenderingEngine.Renderers(AnnObject.UserObjectId) = zoneObjectRenderer

         _annAutomationManager.Objects.Add(selectAutomationObject)
         _annAutomationManager.Objects.Add(zoneAutomationObject)

         ' Disable Annotation selection object since we don't want users to group annotation objects.
         Dim selectionObject As AnnAutomationObject = _annAutomationManager.FindObjectById(AnnObject.SelectObjectId)
         selectionObject.DrawDesignerType = Nothing
      End Sub

      Private Sub _annAutomation_RestoreCursor(sender As Object, e As EventArgs)
         If _rasterImageViewer.Cursor <> Cursors.Default Then
            _rasterImageViewer.Cursor = Cursors.Default
         End If
      End Sub

      Private Sub _annAutomation_SetCursor(sender As Object, e As AnnCursorEventArgs)
         ' If there's an interactive mode working and its not automation, then don't do anything
         If Not _automationInteractiveMode.IsEnabled Then
            Return
         End If

         Dim newCursor As Cursor = Nothing

         Select Case e.DesignerType
            Case AnnDesignerType.Draw
               If True Then
                  newCursor = Cursors.Cross
               End If
               Exit Select

            Case AnnDesignerType.Edit
               If True Then
                  If e.IsRotateCenter Then
                     newCursor = AutomationManagerHelper.AutomationCursors(CursorType.RotateCenterControlPoint)
                  ElseIf e.IsRotateGripper Then
                     newCursor = AutomationManagerHelper.AutomationCursors(CursorType.RotateGripperControlPoint)
                  ElseIf e.ThumbIndex < 0 Then
                     newCursor = AutomationManagerHelper.AutomationCursors(CursorType.SelectedObject)
                  Else
                     newCursor = AutomationManagerHelper.AutomationCursors(CursorType.ControlPoint)
                  End If

               End If
               Exit Select

            Case AnnDesignerType.Run
               If True Then
                  newCursor = AutomationManagerHelper.AutomationCursors(CursorType.Run)
               End If
               Exit Select
            Case Else

               newCursor = AutomationManagerHelper.AutomationCursors(CursorType.SelectObject)
               Exit Select

         End Select

         If _rasterImageViewer.Cursor <> newCursor Then
            _rasterImageViewer.Cursor = newCursor
         End If
      End Sub

      Private Shared Function GetAutomationObject(automationManager As AnnAutomationManager, id As Integer) As AnnAutomationObject
         For Each obj As AnnAutomationObject In automationManager.Objects
            If obj.Id = id Then
               Return obj
            End If
         Next

         Return Nothing
      End Function

      Private Shared Function RestrictZoneBoundsToPage(ocrPage As IOcrPage, bounds As LeadRect) As LeadRect
         If bounds.IsEmpty() Then
            Return bounds
         End If

         Dim pageBounds As LeadRect = New LeadRect(0, 0, ocrPage.Width, ocrPage.Height)
         bounds = LeadRect.Intersect(pageBounds, bounds)
         Return bounds
      End Function

      Private Sub _annAutomation_OnShowContextMenu(sender As Object, e As AnnAutomationEventArgs)
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

      Private Sub _annAutomation_Draw(sender As Object, e As AnnDrawDesignerEventArgs)
         If Not (e.OperationStatus = AnnDesignerOperationStatus.End) Then
            Return
         End If

         ' Add a new zone from the annotation rectangle object
         Dim zoneObject As ZoneAnnotationObject = TryCast(e.Object, ZoneAnnotationObject)

         If zoneObject Is Nothing Then
            Return
         End If

         Dim zone As New OcrZone()
         zone.Bounds = RestrictZoneBoundsToPage(_ocrPage, BoundsFromAnnotations(zoneObject, _annAutomation.Container))
         If (zone.Bounds.IsEmpty()) Then
            InteractiveMode = ViewerControlInteractiveMode.DrawZoneMode
            Return
         Else
            _ocrPage.Zones.Add(zone)
         End If

         ' Set the zone
         zoneObject.SetZone(_ocrPage, _ocrPage.Zones.Count - 1, _showZonesToolStripButton.Checked, _showZoneNameToolStripButton.Checked)

         ZonesUpdated()

         InteractiveMode = ViewerControlInteractiveMode.DrawZoneMode
         UpdateUIState()
      End Sub

      Private Sub _annAutomationObjects_ItemAdded(sender As Object, e As AnnObjectCollectionEventArgs)
         If e.Object Is Nothing Then
            Return
         End If
         ' Check if we are updating the zones, no need for this
         If _ignoreAddRemove Then
            Return
         End If


         '''/ Add a new zone from the annotation rectangle object
         'ZoneAnnotationObject zoneObject = e.Object as ZoneAnnotationObject;

         'OcrZone zone = new OcrZone();
         'zone.Bounds = RestrictZoneBoundsToPage(_ocrPage, BoundsFromAnnotations(zoneObject, _annAutomation.Container));
         '_ocrPage.Zones.Add(zone);

         '''/ Set the zone
         'zoneObject.SetZone(_ocrPage, _ocrPage.Zones.Count - 1, _showZonesToolStripButton.Checked, _showZoneNameToolStripButton.Checked);

         '''/ Convert the pen width to logical units in case we are zoomed in
         'if (e.Object.SupportsStroke && e.Object.Stroke != null)
         '{
         '   //leadlengthd penwidth = e.object.stroke.strokethickness;
         '   //leadpointd[] pts = { new leadpointd(penwidth.value, penwidth.value) };
         '   //pts = _annautomation.container.mapper.pointsfromcontainercoordinates(pts, annfixedstateoperations.none);
         '   //penwidth = new leadlengthd(pts[0].x);
         '   //e.object.stroke.strokethickness = penwidth;
         '}

         'InteractiveMode = ViewerControlInteractiveMode.DrawZoneMode;
         'UpdateUIState();
      End Sub

      Private Sub _annAutomationObjects_ItemRemoved(sender As Object, e As AnnObjectCollectionEventArgs)
         ' Check if we are updating the zones, no need for this
         If _ignoreAddRemove Then
            Return
         End If
         ' User deleted the annotation object, delete the corresponding zone
         Dim zoneObject As ZoneAnnotationObject = TryCast(e.Object, ZoneAnnotationObject)
         If zoneObject IsNot Nothing Then
            If _setSelect Then
               InteractiveMode = ViewerControlInteractiveMode.SelectMode
               Return
            End If
            _setSelect = True
            Dim index As Integer = zoneObject.ZoneIndex
            _ocrPage.Zones.RemoveAt(index)

            ' Reset all the zones
            For i As Integer = 0 To _annAutomation.Container.Children.Count - 1
               zoneObject = TryCast(_annAutomation.Container.Children(i), ZoneAnnotationObject)
               zoneObject.SetZone(_ocrPage, i, _showZonesToolStripButton.Checked, _showZoneNameToolStripButton.Checked)
            Next

            ' We should mark the page as unrecognized since we updated its zones
            _ocrPage.Unrecognize()
            ' Update the thumbnail(s)
            DoAction("RefreshPagesControl", False)
         End If
      End Sub

      Private Sub _annAutomation_AfterObjectChanged(sender As Object, e As AnnAfterObjectChangedEventArgs)
         ' The annotation object has been changed, update the corresponding zone
         Select Case e.ChangeType
            Case AnnObjectChangedType.DesignerEdit
               If True Then
                  ' The object moved or re-sized, update the bounds
                  Dim zoneObject As ZoneAnnotationObject = TryCast(e.Objects(0), ZoneAnnotationObject)

                  Dim zone As OcrZone = _ocrPage.Zones(zoneObject.ZoneIndex)
                  zone.Bounds = RestrictZoneBoundsToPage(_ocrPage, BoundsFromAnnotations(zoneObject, _annAutomation.Container))

                  Dim zoneChanged As Boolean = False
                  If _ocrPage.Zones(zoneObject.ZoneIndex).Bounds <> zone.Bounds Then
                     zoneChanged = True
                  End If

                  _ocrPage.Zones(zoneObject.ZoneIndex) = zone

                  If zoneChanged Then
                     _rasterImageViewer.BeginUpdate()

                     ' We should mark the page as unrecognized since we updated its zones
                     _ocrPage.Unrecognize()
                     ' Update the thumbnail(s)
                     DoAction("RefreshPagesControl", False)

                     _rasterImageViewer.EndUpdate()
                  End If
               End If
               Exit Select
         End Select
      End Sub

      Private Sub _zoneDeleteMenuItem_Click(sender As Object, e As EventArgs)
         _setSelect = False
         _annAutomation.DeleteSelectedObjects()
      End Sub

      Private Sub _zonePropertiesMenuItem_Click(sender As Object, e As EventArgs)
         _zonePropertiesToolStripButton.PerformClick()
      End Sub

      Private Sub UpdateZoomValueFromControlDelegate()
         If Not _rasterImageViewer.Image Is Nothing Then
            Dim factor As Double = _rasterImageViewer.XScaleFactor * 100.0
            _zoomToolStripComboBox.Text = factor.ToString("F1") & "%"
         Else
            _zoomToolStripComboBox.Text = String.Empty
         End If
      End Sub
      Private Sub UpdateZoomValueFromControl()
         BeginInvoke(New MethodInvoker(AddressOf UpdateZoomValueFromControlDelegate))
      End Sub

      Public Sub UpdateUIState()
         ' Update the UI controls states

         _fitPageWidthToolStripButton.Checked = _rasterImageViewer.SizeMode = ControlSizeMode.FitWidth
         _fitPageToolStripButton.Checked = _rasterImageViewer.SizeMode = ControlSizeMode.Fit

         _selectModeToolStripButton.Checked = _interactiveMode = ViewerControlInteractiveMode.SelectMode
         _panModeToolStripButton.Checked = _interactiveMode = ViewerControlInteractiveMode.PanMode
         _zoomToSelectionModeToolStripButton.Checked = _interactiveMode = ViewerControlInteractiveMode.ZoomToSelectionMode
         _drawZoneModeToolStripButton.Checked = _interactiveMode = ViewerControlInteractiveMode.DrawZoneMode
         _drawZoneModeToolStripButton.Enabled = _showZonesToolStripButton.Checked

         _zonePropertiesToolStripButton.Enabled = _ocrPage IsNot Nothing

         If _rasterImageViewer.Image IsNot Nothing Then
            If Not _toolStrip.Enabled Then
               _toolStrip.Enabled = True
            End If

            _pageToolStripTextBox.Text = (_currentPageIndex + 1).ToString()
            _pageToolStripLabel.Text = "/ " & _pageCount.ToString()

            _previousPageToolStripButton.Enabled = _currentPageIndex > 0 AndAlso Not MainForm.PerspectiveDeskewActive
            _nextPageToolStripButton.Enabled = _currentPageIndex < (_pageCount - 1) AndAlso Not MainForm.PerspectiveDeskewActive
            _pageToolStripTextBox.Enabled = Not MainForm.PerspectiveDeskewActive
            _pageToolStripLabel.Enabled = Not MainForm.PerspectiveDeskewActive
            _panModeToolStripButton.Enabled = Not MainForm.PerspectiveDeskewActive
            _drawZoneModeToolStripButton.Enabled = Not MainForm.PerspectiveDeskewActive
            _zonePropertiesToolStripButton.Enabled = Not MainForm.PerspectiveDeskewActive
            _showZonesToolStripButton.Enabled = Not MainForm.PerspectiveDeskewActive
            _showZoneNameToolStripButton.Enabled = Not MainForm.PerspectiveDeskewActive
         Else
            _pageToolStripTextBox.Text = "0"
            _pageToolStripLabel.Text = "/ 0"

            _zoomToolStripComboBox.Text = String.Empty

            _toolStrip.Enabled = False
         End If
      End Sub

      Private Sub UpdateTitle()
         ' Add the current page info (size, dpi and bpp) to the title label

         Dim sb As New StringBuilder()

         If _title IsNot Nothing Then
            sb.Append(_title)
         End If

         If _rasterImageViewer.Image IsNot Nothing Then
            Dim image As RasterImage = _rasterImageViewer.Image

            sb.AppendFormat(" - Size: {0} by {1} px, dpi: {2} by {3}, Bits/Pixel: {4}", image.ImageWidth, image.ImageHeight, image.XResolution, image.YResolution, image.BitsPerPixel)
         End If

         _titleLabel.Text = sb.ToString()
      End Sub

      Private Sub _rasterImageViewer_TransformChanged(sender As Object, e As EventArgs) Handles _rasterImageViewer.TransformChanged
         If IsHandleCreated Then
            UpdateZoomValueFromControl()
            UpdateUIState()
         End If
      End Sub

      Private Sub _previousPageToolStripButton_Click(sender As Object, e As EventArgs) Handles _previousPageToolStripButton.Click
         TryGotoPage(_currentPageIndex - 1)
      End Sub

      Private Sub _nextPageToolStripButton_Click(sender As Object, e As EventArgs) Handles _nextPageToolStripButton.Click
         TryGotoPage(_currentPageIndex + 1)
      End Sub

      Private Sub _pageToolStripTextBox_LostFocus(sender As Object, e As EventArgs)
         _pageToolStripTextBox.Text = (_currentPageIndex + 1).ToString()
      End Sub

      Private Sub _pageToolStripTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _pageToolStripTextBox.KeyPress
         If e.KeyChar = CChar(Microsoft.VisualBasic.ChrW(Keys.Return)) Then
            ' User has pressed enter, go to the new page number

            Dim str As String = _pageToolStripTextBox.Text.Trim()

            ' Try to parse the integer value
            Dim pageNumber As Integer
            If Integer.TryParse(str, pageNumber) Then
               TryGotoPage(pageNumber - 1)
            End If

            _pageToolStripTextBox.Text = (_currentPageIndex + 1).ToString()
         End If
      End Sub

      Private Sub TryGotoPage(pageIndex As Integer)
         ' Check if the index is valid
         If pageIndex >= 0 AndAlso pageIndex < _pageCount Then
            ' Yes, fire the event to the main form
            DoAction("PageIndexChanged", pageIndex)
         End If
      End Sub

      Private Sub _zoomOutToolStripButton_Click(sender As Object, e As EventArgs) Handles _zoomOutToolStripButton.Click
         ZoomViewer(True)
      End Sub

      Private Sub _zoomInToolStripButton_Click(sender As Object, e As EventArgs) Handles _zoomInToolStripButton.Click
         ZoomViewer(False)
      End Sub

      Private Sub _zoomToolStripComboBox_LostFocus(sender As Object, e As EventArgs)
         UpdateZoomValueFromControl()
      End Sub

      Private Sub _zoomToolStripComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _zoomToolStripComboBox.SelectedIndexChanged
         ' Parse the new zoom value
         Dim str As String = _zoomToolStripComboBox.Text.Trim()

         Select Case str
            Case "Actual Size"
               SetViewerZoomPercentage(100)
               Exit Select

            Case "Fit Page"
               _fitPageToolStripButton.PerformClick()
               Exit Select

            Case "Fit Width"
               _fitPageWidthToolStripButton.PerformClick()
               Exit Select
            Case Else

               If Not String.IsNullOrEmpty(str) Then
                  Dim val As Double = Double.Parse(str.Substring(0, str.Length - 1))
                  SetViewerZoomPercentage(val)
               End If
               Exit Select
         End Select
         ZonesUpdated()
      End Sub

      Private Sub _zoomToolStripComboBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _zoomToolStripComboBox.KeyPress
         If e.KeyChar = CChar(Microsoft.VisualBasic.ChrW(Keys.Return)) Then
            ' User has pressed enter, parse the new zoom value

            Dim str As String = _zoomToolStripComboBox.Text.Trim()

            If Not String.IsNullOrEmpty(str) Then
               ' Remove the % sign if present
               If str.EndsWith("%") Then
                  str = str.Remove(str.Length - 1, 1).Trim()
               End If

               ' Try to parse the new zoom value
               Dim percentage As Double
               If Double.TryParse(str, percentage) Then
                  SetViewerZoomPercentage(percentage)
               End If

               UpdateZoomValueFromControl()
               ZonesUpdated()
            End If
         End If
      End Sub

      Private Sub SetViewerZoomPercentage(percentage As Double)
         ' Normalize the percentage based on min/max value allowed
         percentage = Math.Max(_minimumViewerScalePercentage, Math.Min(_maximumViewerScalePercentage, percentage))

         If Math.Abs(_rasterImageViewer.XScaleFactor * 100.0 - percentage) > 0.01 Then
            ' Save the current center location in the viewer, we will use it later to
            ' re-center the viewer
            Dim rc As Rectangle = Rectangle.Intersect(_rasterImageViewer.DisplayRectangle, _rasterImageViewer.ClientRectangle)
            Dim center As New PointF(rc.Left + rc.Width \ 2, rc.Top + rc.Right \ 2)

            Dim trans As New Transformer(ToMatrix(_rasterImageViewer.ImageTransform))
            center = trans.PointToLogical(center)


            _rasterImageViewer.BeginUpdate()

            ' Switch to normal size mode if we are not in it
            If _rasterImageViewer.SizeMode <> ControlSizeMode.None Then
               _rasterImageViewer.Zoom(ControlSizeMode.None, _rasterImageViewer.ScaleFactor, _rasterImageViewer.DefaultZoomOrigin)
            End If


            ' Zoom
            _rasterImageViewer.Zoom(_rasterImageViewer.SizeMode, percentage / 100.0, _rasterImageViewer.DefaultZoomOrigin)
            ' Go back to original center point

            trans = New Transformer(ToMatrix(_rasterImageViewer.ImageTransform))
            center = trans.PointToPhysical(center)

            Dim lPoint As New LeadPoint(Point.Round(center).X, Point.Round(center).Y)
            _rasterImageViewer.CenterAtPoint(lPoint)

            _rasterImageViewer.EndUpdate()

            _rasterImageViewer_TransformChanged(_rasterImageViewer, EventArgs.Empty)

            UpdateUIState()
         End If
      End Sub

      Private Function ToMatrix(LMatrix As LeadMatrix) As Matrix
         Return New Matrix(CSng(LMatrix.M11), CSng(LMatrix.M12), CSng(LMatrix.M21), CSng(LMatrix.M22), CSng(LMatrix.OffsetX), CSng(LMatrix.OffsetY))
      End Function

      Private Sub _fitPageWidthToolStripButton_Click(sender As Object, e As EventArgs) Handles _fitPageWidthToolStripButton.Click
         FitPage(True)
         ZonesUpdated()
      End Sub

      Private Sub _fitPageToolStripButton_Click(sender As Object, e As EventArgs) Handles _fitPageToolStripButton.Click
         FitPage(False)
      End Sub

      Private Sub _selectModeToolStripButton_Click(sender As Object, e As EventArgs) Handles _selectModeToolStripButton.Click
         InteractiveMode = ViewerControlInteractiveMode.SelectMode
      End Sub

      Private Sub _panModeToolStripButton_Click(sender As Object, e As EventArgs) Handles _panModeToolStripButton.Click
         InteractiveMode = ViewerControlInteractiveMode.PanMode
      End Sub

      Private Sub _zoomToSelectionModeToolStripButton_Click(sender As Object, e As EventArgs) Handles _zoomToSelectionModeToolStripButton.Click
         InteractiveMode = ViewerControlInteractiveMode.ZoomToSelectionMode
      End Sub

      Private Sub _drawZoneModeToolStripButton_Click(sender As Object, e As EventArgs) Handles _drawZoneModeToolStripButton.Click
         InteractiveMode = ViewerControlInteractiveMode.DrawZoneMode
      End Sub

      Private Sub _zonePropertiesToolStripButton_Click(sender As Object, e As EventArgs) Handles _zonePropertiesToolStripButton.Click
         DoAction("ShowZoneProperties", Nothing)
      End Sub

      Private Sub _showZonesToolStripButton_Click(sender As Object, e As EventArgs) Handles _showZonesToolStripButton.Click
         _showZonesToolStripButton.Checked = Not _showZonesToolStripButton.Checked
         ShowZones = _showZonesToolStripButton.Checked
         _rasterImageViewer.Invalidate()
      End Sub

      Private Sub _showZoneNameToolStripButton_Click(sender As Object, e As EventArgs) Handles _showZoneNameToolStripButton.Click
         _showZoneNameToolStripButton.Checked = Not _showZoneNameToolStripButton.Checked
         ShowZoneNames = _showZoneNameToolStripButton.Checked
         _rasterImageViewer.Invalidate()
      End Sub

      Private Sub DoAction(action As String, data As Object)
         ' Raise the action event so the main form can handle it

         RaiseEvent Action(Me, New ActionEventArgs(action, data))
      End Sub

      Private Sub _rasterImageViewer_MouseMove(sender As Object, e As MouseEventArgs) Handles _rasterImageViewer.MouseMove
         Dim str As String

         If _rasterImageViewer.Image IsNot Nothing AndAlso _ocrPage IsNot Nothing Then
            ' Show the mouse position in physical and logical (inches) coordinates

            Dim physical As New PointF(e.X, e.Y)
            Dim pixels As PointF

            Dim trans As New Transformer(ToMatrix(_rasterImageViewer.ImageTransform))
            pixels = trans.PointToLogical(physical)

            Dim lPoint As New LeadPoint(CInt(Math.Truncate(Math.Abs(pixels.X))), CInt(Math.Truncate(Math.Abs(pixels.Y))))
            Dim zoneIndex As Integer = _ocrPage.HitTestZone(lPoint)
            str = String.Format("{0},{1} px", CInt(Math.Truncate(pixels.X)), CInt(Math.Truncate(pixels.Y)))
         Else
            str = String.Empty
         End If

         _mousePositionLabel.Text = str
      End Sub

      Private Sub _rasterImageViewer_PostImagePaint(sender As Object, e As ImageViewerRenderEventArgs) Handles _rasterImageViewer.PostRender
         ' If this page is recognized, show info
         If _ocrPage IsNot Nothing AndAlso _ocrPage.IsRecognized Then
            Dim g As Graphics = e.PaintEventArgs.Graphics

            Dim text As String = "Page is recognized"
            Dim textSize As SizeF = g.MeasureString(text, _rasterImageViewer.Font)
            Dim textRect As New RectangleF(2, 2, textSize.Width, textSize.Height)

            Using textBrush As Brush = New SolidBrush(Color.FromArgb(128, Color.Black))
               g.FillRectangle(textBrush, textRect)
               g.DrawString(text, _rasterImageViewer.Font, Brushes.White, textRect.Location)
            End Using
         End If
      End Sub


      Private Function GetMatrixFromLeadMatrix(matrix As LeadMatrix) As Matrix
         Return New Matrix(CSng(matrix.M11), CSng(matrix.M12), CSng(matrix.M21), CSng(matrix.M22), CSng(matrix.OffsetX), CSng(matrix.OffsetY))
      End Function

      Public Function PhysicalToLogical(physical As LeadPoint) As LeadPoint
         Dim pixelsF As New PointF(physical.X, physical.Y)

         Using m As Matrix = GetMatrixFromLeadMatrix(_rasterImageViewer.GetImageTransformWithDpi(True))
            Dim trans As New Transformer(m)
            pixelsF = trans.PointToLogical(pixelsF)
         End Using

         Dim pixels As Point = Point.Round(pixelsF)
         Return New LeadPoint(pixels.X, pixels.Y)
      End Function
   End Class
End Namespace
