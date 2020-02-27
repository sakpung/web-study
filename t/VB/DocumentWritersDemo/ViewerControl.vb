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
Imports System

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.Automation
Imports Leadtools.Annotations.WinForms
Imports Leadtools.Drawing
Imports System.Collections
Imports Leadtools.Annotations.Rendering


Namespace DocumentWritersDemo
   ''' <summary>
   ''' This control contains an instance of RasterImageViewer plus
   ''' a tool strip control for common operations
   ''' </summary>
   Partial Public Class ViewerControl
      Inherits UserControl
      ' Minimum and maximum scale percentages allowed
      Private Const _minimumViewerScalePercentage As Double = 1
      Private Const _maximumViewerScalePercentage As Double = 6400

      'Interactive Modes
      Private _noneInteractiveMode As ImageViewerNoneInteractiveMode = Nothing
      Private _panInteractiveMode As ImageViewerPanZoomInteractiveMode = Nothing
      Private _zoomToInteractiveMode As ImageViewerZoomToInteractiveMode = Nothing
      Private _automationInteractiveMode As AutomationInteractiveMode = Nothing

      ' Current interactive mode (with the mouse)
      Private _interactiveMode As ViewerControlInteractiveMode = ViewerControlInteractiveMode.SelectMode

      ' We will use annotations to draw the objects
      Private _rasterCodecsInstance As RasterCodecs
      Private _annotationsHelper As AutomationManagerHelper
      Private _annAutomationManager As AnnAutomationManager
      Private _annAutomation As AnnAutomation

      Public Sub New()
         InitializeComponent()

         InitInteractiveModes()
      End Sub

      Public Property noneInteractiveMode() As ImageViewerNoneInteractiveMode
         Get
            Return _noneInteractiveMode
         End Get
         Set(value As ImageViewerNoneInteractiveMode)
            _noneInteractiveMode = value
         End Set
      End Property

      Public Property automationInteractiveMode() As AutomationInteractiveMode
         Get
            Return _automationInteractiveMode
         End Get
         Set(value As AutomationInteractiveMode)
            _automationInteractiveMode = value
         End Set
      End Property

      Public Property ZoomToInteractiveMode() As ImageViewerZoomToInteractiveMode
         Get
            Return _zoomToInteractiveMode
         End Get
         Set(value As ImageViewerZoomToInteractiveMode)

            _zoomToInteractiveMode = value
         End Set
      End Property
      Public Property PanInteractiveMode() As ImageViewerPanZoomInteractiveMode
         Get
            Return _panInteractiveMode
         End Get
         Set(value As ImageViewerPanZoomInteractiveMode)

            _panInteractiveMode = value
         End Set
      End Property


      Public Property NoneInteractiveMod() As ImageViewerNoneInteractiveMode
         Get
            Return _noneInteractiveMode
         End Get
         Set(value As ImageViewerNoneInteractiveMode)

            _noneInteractiveMode = value
         End Set
      End Property

      Private Sub InitInteractiveModes()
         'None
         noneInteractiveMode = New ImageViewerNoneInteractiveMode()
         _rasterImageViewer.InteractiveModes.Add(noneInteractiveMode)

         automationInteractiveMode = New AutomationInteractiveMode()
         automationInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left Or System.Windows.Forms.MouseButtons.Right
         automationInteractiveMode.IdleCursor = Cursors.Default
         automationInteractiveMode.WorkingCursor = Cursors.Default
         _rasterImageViewer.InteractiveModes.Add(automationInteractiveMode)

         PanInteractiveMode = New ImageViewerPanZoomInteractiveMode()
         PanInteractiveMode.IdleCursor = Cursors.Hand
         PanInteractiveMode.WorkingCursor = Cursors.Hand
         PanInteractiveMode.IsEnabled = False
         PanInteractiveMode.WorkOnBounds = True
         PanInteractiveMode.EnablePan = True
         PanInteractiveMode.EnableZoom = False
         PanInteractiveMode.EnablePinchZoom = False
         _rasterImageViewer.InteractiveModes.Add(PanInteractiveMode)

         ZoomToInteractiveMode = New ImageViewerZoomToInteractiveMode()
         AddHandler ZoomToInteractiveMode.WorkCompleted, AddressOf zoomToMode_WorkCompleted
         ZoomToInteractiveMode.IdleCursor = Cursors.Cross
         ZoomToInteractiveMode.WorkingCursor = Cursors.Cross
         ZoomToInteractiveMode.IsEnabled = False
         ZoomToInteractiveMode.WorkOnBounds = True
         _rasterImageViewer.InteractiveModes.Add(ZoomToInteractiveMode)

         automationInteractiveMode.IsEnabled = True
         _rasterImageViewer.InteractiveModes.EnableById(automationInteractiveMode.Id)

      End Sub

      Private Sub zoomToMode_WorkCompleted(sender As Object, e As EventArgs)
         BeginInvoke(New MethodInvoker(AddressOf _selectModeToolStripButton.PerformClick))
      End Sub

      Protected Overrides Sub OnLoad(e As EventArgs)
         Try
            If Not DesignMode Then
               ' Use ScaleToGray for optimum viewing
               Dim props As RasterPaintProperties = _rasterImageViewer.PaintProperties
               props.PaintDisplayMode = props.PaintDisplayMode Or RasterPaintDisplayModeFlags.ScaleToGray
               _rasterImageViewer.PaintProperties = props

               ' Pad the viewer
               Dim padding As Padding = _rasterImageViewer.Padding
               padding.All = 10
               _rasterImageViewer.Padding = padding

               ' These events are needed and not visible from the designer, so
               ' hook into them here
               AddHandler _pageToolStripTextBox.LostFocus, AddressOf _pageToolStripTextBox_LostFocus

               ' Call the transform changed event
               _rasterImageViewer_TransformChanged(_rasterImageViewer, EventArgs.Empty)

               _mousePositionLabel.Text = String.Empty

               ' Initialize the annotation objects
               InitAnnotations()
            End If

            MyBase.OnLoad(e)
         Catch ex As RasterException
            Messager.ShowError(Me, ex)
         End Try
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
            _titleLabel.Text = value
         End Set
      End Property

      ''' <summary>
      ''' Called by the main form to get/set the title (the name of the document)
      ''' </summary>
      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public Property RasterCodecsInstance() As RasterCodecs
         Get
            Return _rasterCodecsInstance
         End Get
         Set(value As RasterCodecs)
            _rasterCodecsInstance = value
         End Set
      End Property

      ''' <summary>
      ''' Called by the main form to change the page viewing mode (from the main menu)
      ''' </summary>
      Public Sub FitPage(fitWidth As Boolean)
         ' Since we are doing more than one operation on the viewer, it is
         ' recommended to disable then re-enable updates on the viewer to
         ' minimize flickering

         _rasterImageViewer.BeginUpdate()

         _rasterImageViewer.Zoom(ControlSizeMode.None, 1, _rasterImageViewer.DefaultZoomOrigin)

         If fitWidth Then
            _rasterImageViewer.Zoom(ControlSizeMode.FitWidth, 1, _rasterImageViewer.DefaultZoomOrigin)
         Else
            _rasterImageViewer.Zoom(ControlSizeMode.Fit, 1, _rasterImageViewer.DefaultZoomOrigin)
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
         Dim percentage As Double = _rasterImageViewer.ScaleFactor * 100.0

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
      End Sub

      ''' <summary>
      ''' Called by the main form to get the current size mode value
      ''' </summary>
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

            For Each mode As ImageViewerInteractiveMode In _rasterImageViewer.InteractiveModes
               mode.IsEnabled = False
            Next

            If _annAutomationManager IsNot Nothing Then
               ' Set the RasterImageViewer interactive mode accordingly
               Select Case _interactiveMode
                  Case ViewerControlInteractiveMode.SelectMode
                     automationInteractiveMode.IsEnabled = True
                     _rasterImageViewer.InteractiveModes.EnableById(automationInteractiveMode.Id)
                     Automation.Cancel()
                     Exit Select

                  Case ViewerControlInteractiveMode.PanMode
                     _rasterImageViewer.InteractiveModes.EnableById(PanInteractiveMode.Id)
                     Automation.Cancel()
                     Exit Select
                  Case ViewerControlInteractiveMode.ZoomToSelectionMode
                     _rasterImageViewer.InteractiveModes.EnableById(ZoomToInteractiveMode.Id)
                     Automation.Cancel()
                     Exit Select
               End Select
            End If

            UpdateUIState()
         End Set
      End Property

      ''' <summary>
      ''' Called by the main form to get the automation manager object
      ''' </summary>
      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property AutomationManager() As AnnAutomationManager
         Get
            If DesignMode Then
               Return Nothing
            End If

            Return _annAutomationManager
         End Get
      End Property

      ''' <summary>
      ''' Called by the main form to get the automation object
      ''' </summary>
      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property Automation() As AnnAutomation
         Get
            If DesignMode Then
               Return Nothing
            End If

            Return _annAutomation
         End Get
      End Property

      ''' <summary>
      ''' Called by the main form to set a new document into the viewer
      ''' </summary>
      Public Sub SetDocument(image As RasterImage)
         Try

            If _annAutomationManager IsNot Nothing Then
               _rasterImageViewer.Image = image

               'we shoud reset viewer transforms before creating automation and setting its container size
               ResetViewerTransforms()

               'Set Container Size
               If _annAutomation.Container Is Nothing Then
                  _annAutomation.Containers.Add(New AnnContainer())
                  _annAutomation.Container.Mapper.MapResolutions(image.XResolution, image.YResolution, image.XResolution, image.YResolution)
               End If

               _annAutomation.Container.Size = _annAutomation.Container.Mapper.SizeToContainerCoordinates(LeadSizeD.Create(image.ImageWidth, image.ImageHeight))

               SetViewerTransforms()

               UpdateUIState()
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub SetViewerTransforms()
         _rasterImageViewer.Zoom(ControlSizeMode.Fit, 1, _rasterImageViewer.DefaultZoomOrigin)
         _rasterImageViewer.UseDpi = True
      End Sub

      Private Sub ResetViewerTransforms()
         _rasterImageViewer.Zoom(ControlSizeMode.ActualSize, 1, _rasterImageViewer.DefaultZoomOrigin)
         _rasterImageViewer.UseDpi = False
      End Sub

      ''' <summary>
      ''' Called by the main form to get the image in the viewer
      ''' </summary>
      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property RasterImage() As RasterImage
         Get
            Return _rasterImageViewer.Image
         End Get
      End Property

      ''' <summary>
      ''' Called by the main form to get the viewer
      ''' </summary>
      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property RasterImageViewer() As ImageViewer
         Get
            Return _rasterImageViewer
         End Get
      End Property

      ''' <summary>
      ''' Called by the main form to add a new page to the document
      ''' </summary>
      Public Sub AddPage(page As RasterImage, width As Integer, height As Integer)
         _rasterImageViewer.Image.AddPage(page)

         ResetViewerTransforms()

         Dim container As New AnnContainer()
         container.Mapper = _annAutomation.Container.Mapper.Clone()
         container.Size = container.Mapper.SizeToContainerCoordinates(LeadSizeD.Create(width, height))

         SetViewerTransforms()

         _annAutomation.Containers.Add(container)
      End Sub

      ''' <summary>
      ''' Called by the main form to delete the current page
      ''' </summary>
      Public Sub DeleteCurrentPage()
         ' Delete the current page automation
         Dim pageNumber As Integer = _rasterImageViewer.Image.Page

         _annAutomation.Containers.RemoveAt(pageNumber - 1)
         _rasterImageViewer.Image.RemovePageAt(pageNumber)
      End Sub

      ''' <summary>
      ''' Called by the main form when the page number changes
      ''' </summary>
      Public Sub SetCurrentPageNumber(pageNumber As Integer)
         Try
            'Activate current container and disable All others
            If _rasterImageViewer.Image IsNot Nothing Then
               _rasterImageViewer.Image.Page = pageNumber
            End If

            If _annAutomation.Containers.Count >= pageNumber Then
               Dim currentContainer As AnnContainer = _annAutomation.Containers(pageNumber - 1)
               currentContainer.IsVisible = True
               currentContainer.IsEnabled = True

               For Each container As AnnContainer In _annAutomation.Containers
                  If currentContainer Is container Then
                     Continue For
                  End If

                  container.IsVisible = False
                  container.IsEnabled = False
               Next

               _annAutomation.ActiveContainer = currentContainer
            End If


            _annAutomation.Invalidate(LeadRectD.Empty)
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub


      Private Sub MyTestMenuItemHandler(sender As Object, e As EventArgs)
         MessageBox.Show("Test clicked")
      End Sub

      Private Sub CustomizeAutomationMenu()
         Dim autoObj As AnnAutomationObject = _annAutomationManager.FindObjectById(AnnObject.LineObjectId)
         If autoObj IsNot Nothing Then
            If autoObj.ContextMenu IsNot Nothing Then
               Dim menu As ObjectContextMenu = TryCast(autoObj.ContextMenu, ObjectContextMenu)
               If menu IsNot Nothing Then
                  menu.MenuItems.RemoveAt(13)
                  'Unlock
                  menu.MenuItems.RemoveAt(12)
                  'Lock
                  menu.MenuItems.RemoveAt(11)
                  'Separator
                  menu.MenuItems.RemoveAt(10)
                  'Reverse
                  menu.MenuItems.RemoveAt(9)
                  'Flip
                  'Separator
                  menu.MenuItems.RemoveAt(8)
               End If
            End If

            autoObj = _annAutomationManager.FindObjectById(AnnObject.PolygonObjectId)
            If autoObj IsNot Nothing AndAlso autoObj.ObjectTemplate IsNot Nothing Then
               Dim polygon As AnnPolylineObject = TryCast(autoObj.ObjectTemplate, AnnPolylineObject)
               polygon.IsClosed = True
               polygon.FillRule = AnnFillRule.Nonzero
            End If

            autoObj = _annAutomationManager.FindObjectById(AnnObject.ClosedCurveObjectId)
            If autoObj IsNot Nothing AndAlso autoObj.ObjectTemplate IsNot Nothing Then
               Dim closedCurve As AnnCurveObject = TryCast(autoObj.ObjectTemplate, AnnCurveObject)
               closedCurve.IsClosed = True
               closedCurve.FillRule = AnnFillRule.Nonzero
            End If

            ' Group
            autoObj = _annAutomationManager.FindObjectById(AnnObject.PolygonObjectId)
            If autoObj IsNot Nothing AndAlso autoObj.ObjectTemplate IsNot Nothing Then
               Dim polygon As AnnPolylineObject = TryCast(autoObj.ObjectTemplate, AnnPolylineObject)
               polygon.IsClosed = True
               polygon.FillRule = AnnFillRule.Nonzero
            End If

            autoObj = _annAutomationManager.FindObjectById(AnnObject.ClosedCurveObjectId)
            If autoObj IsNot Nothing AndAlso autoObj.ObjectTemplate IsNot Nothing Then
               Dim closedCurve As AnnCurveObject = TryCast(autoObj.ObjectTemplate, AnnCurveObject)
               closedCurve.IsClosed = True
               closedCurve.FillRule = AnnFillRule.Nonzero
            End If
            ' Group
            autoObj = _annAutomationManager.FindObjectById(AnnObject.GroupObjectId)
            If autoObj IsNot Nothing Then
               Dim menu As New ObjectContextMenu()

               menu = TryCast(autoObj.ContextMenu, ObjectContextMenu)
               If menu IsNot Nothing Then
                  menu.MenuItems.RemoveAt(16)
                  'Ungroup
                  menu.MenuItems.RemoveAt(15)
                  'Group
                  menu.MenuItems.RemoveAt(14)
                  'Separator
                  menu.MenuItems.RemoveAt(13)
                  'Unlock
                  menu.MenuItems.RemoveAt(12)
                  'Lock
                  menu.MenuItems.RemoveAt(11)
                  'Separator
                  menu.MenuItems.RemoveAt(10)
                  'Reverse
                  menu.MenuItems.RemoveAt(9)
                  'Flip
                  'Separator
                  menu.MenuItems.RemoveAt(8)
               End If


               If menu IsNot Nothing Then
                  ' Remove the 'Control Points' item
                  menu.MenuItems.RemoveAt(8)
                  menu.MenuItems.RemoveAt(7)

               End If
            End If
         End If

      End Sub

      Private Sub InitAnnotations()
         Try
            _annAutomationManager = AnnAutomationManager.Create(New AnnWinFormsRenderingEngine())
            _annotationsHelper = New AutomationManagerHelper(_annAutomationManager)

            ' Disable the rotation
            _annAutomationManager.RotateModifierKey = AnnKeys.None

            _annAutomationManager.CreateDefaultObjects()

            _annAutomation = New AnnAutomation(_annAutomationManager, _rasterImageViewer)
            AddHandler _annAutomation.OnShowContextMenu, AddressOf _automation_OnShowContextMenu
            AddHandler _annAutomation.OnShowObjectProperties, AddressOf automation_OnShowObjectProperties
            AddHandler _annAutomation.Container.Children.CollectionChanged, AddressOf Children_CollectionChanged
            AddHandler _annAutomation.AfterObjectChanged, AddressOf automation_AfterObjectChanged
            AddHandler _annAutomation.UndoRedoChanged, AddressOf automation_UndoRedoChanged
            AddHandler _annAutomation.LockObject, AddressOf _annAutomation_LockObject
            AddHandler _annAutomation.UnlockObject, AddressOf _annAutomation_UnlockObject

            _annAutomation.Active = True
            automationInteractiveMode.AutomationControl = _rasterImageViewer

            ' Remove the following automation objects since we will not use them in this
            ' demo
            RemoveObject(_annAutomationManager, AnnObject.HotspotObjectId)
            RemoveObject(_annAutomationManager, AnnObject.FreehandHotspotObjectId)
            RemoveObject(_annAutomationManager, AnnObject.ButtonObjectId)
            RemoveObject(_annAutomationManager, AnnObject.AudioObjectId)
            RemoveObject(_annAutomationManager, AnnObject.EncryptObjectId)
            RemoveObject(_annAutomationManager, AnnObject.PointObjectId)
            RemoveObject(_annAutomationManager, AnnObject.RedactionObjectId)
            RemoveObject(_annAutomationManager, AnnObject.TextRollupObjectId)

            ' Remove the Flip, reverse, lock, unlock items from the PopUp menus
            ' and remove the "Control Points' item form the dfault menu
            CustomizeAutomationMenu()


            ' Disable the rotation points
            For Each autObj As AnnAutomationObject In _annAutomationManager.Objects
               autObj.UseRotateThumbs = False
            Next

            _annotationsHelper.CreateToolBar()

            Dim tb As ToolBar = _annotationsHelper.ToolBar
            tb.AutoSize = True
            tb.Dock = DockStyle.Right
            Me.Controls.Add(tb)
            tb.BringToFront()
            tb.Appearance = ToolBarAppearance.Flat

            _rasterImageViewer.BringToFront()
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub


      Private Sub _annAutomation_LockObject(sender As Object, e As AnnLockObjectEventArgs)
         Dim passwordDialog As New AutomationPasswordDialog()
         passwordDialog.Lock = True
         If passwordDialog.ShowDialog(Me) = DialogResult.OK Then
            e.Password = passwordDialog.Password
         Else
            e.Cancel = True
         End If
      End Sub

      Private Sub _annAutomation_UnlockObject(sender As Object, e As AnnLockObjectEventArgs)
         e.Cancel = True
         'PasswordDialog
         Dim passwordDialog As New AutomationPasswordDialog()
         If passwordDialog.ShowDialog(Me) = DialogResult.OK Then
            e.[Object].Unlock(passwordDialog.Password)
            If e.[Object].IsLocked Then
               MessageBox.Show("You've entered an invalid password.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            Automation.Invalidate(LeadRectD.Empty)
         End If
      End Sub

      Private Shared Sub RemoveObject(automationManager As AnnAutomationManager, objectId As Integer)
         For i As Integer = 0 To automationManager.Objects.Count - 1
            If automationManager.Objects(i).Id = objectId Then
               automationManager.Objects.RemoveAt(i)
               Return
            End If
         Next
      End Sub

      Private Sub automation_OnShowObjectProperties(sender As Object, e As AnnAutomationEventArgs)
         Dim automation As AnnAutomation = TryCast(sender, AnnAutomation)

         Using dlg As AutomationUpdateObjectDialog = New AutomationUpdateObjectDialog()
            If automation.CurrentEditObject IsNot Nothing Then
               ' If stick note or text, hide the note
               If automation.CurrentEditObject.Id = AnnObject.StickyNoteObjectId OrElse TypeOf automation.CurrentEditObject Is AnnTextObject Then
                  ' if text object, we cannot do that. Ignore, the EditText will fire
                  dlg.SetPageVisible(AutomationUpdateObjectDialogPage.Content, False)
               End If
            End If

            dlg.Automation = automation

            Try
               dlg.ShowDialog(Me)
               e.Cancel = Not dlg.IsModified
            Catch ex As Exception
               MessageBox.Show(ex.Message)
            End Try
         End Using
      End Sub

      Private Sub _automation_OnShowContextMenu(sender As Object, e As AnnAutomationEventArgs)
         If e IsNot Nothing AndAlso e.Object IsNot Nothing Then
            _rasterImageViewer.AutomationInvalidate(LeadRectD.Empty)
            Dim annAutomationObject As AnnAutomationObject = TryCast(e.Object, AnnAutomationObject)
            If annAutomationObject IsNot Nothing Then
               Dim menu As ObjectContextMenu = TryCast(annAutomationObject.ContextMenu, ObjectContextMenu)
               If menu IsNot Nothing Then
                  menu.Automation = TryCast(sender, AnnAutomation)
                  menu.Show(Me, RasterImageViewer.PointToClient(Cursor.Position))
               End If
            End If
         Else
            Dim defaultMenu As New ManagerContextMenu()
            defaultMenu.Automation = TryCast(sender, AnnAutomation)
            defaultMenu.Show(Me, _rasterImageViewer.PointToClient(Cursor.Position))
         End If
      End Sub
      Private Sub Children_CollectionChanged(sender As Object, e As AnnNotifyCollectionChangedEventArgs)
         UpdateAll()
      End Sub

      Private Sub automation_UndoRedoChanged(sender As Object, e As EventArgs)
         UpdateAll()
      End Sub

      Private Sub automation_AfterObjectChanged(sender As Object, e As AnnAfterObjectChangedEventArgs)
         UpdateAll()
      End Sub

      Private Sub UpdateAll()
         BeginInvoke(New MethodInvoker(AddressOf DoUpdate))
      End Sub

      Private Sub DoUpdate()
         UpdateUIState()
         DoAction("UpdateUIState", Nothing)
      End Sub
      Private Sub UpdateZoomValueFromControl()
         If _rasterImageViewer.Image IsNot Nothing Then
            Dim factor As Double = _rasterImageViewer.ScaleFactor * 100.0
            _zoomToolStripComboBox.Text = factor.ToString("F1") & "%"
         Else
            _zoomToolStripComboBox.Text = String.Empty
         End If
      End Sub

      Private Sub UpdateUIState()
         ' Update the UI controls states

         _fitPageWidthToolStripButton.Checked = _rasterImageViewer.SizeMode = ControlSizeMode.FitWidth
         _fitPageToolStripButton.Checked = _rasterImageViewer.SizeMode = ControlSizeMode.Fit

         _selectModeToolStripButton.Checked = _interactiveMode = ViewerControlInteractiveMode.SelectMode
         _panModeToolStripButton.Checked = _interactiveMode = ViewerControlInteractiveMode.PanMode
         _zoomToSelectionModeToolStripButton.Checked = _interactiveMode = ViewerControlInteractiveMode.ZoomToSelectionMode

         Dim automation__1 As AnnAutomation = Automation
         If automation__1 IsNot Nothing Then
            _bringToFrontToolStripButton.Enabled = automation__1.CanBringToFront
            _sendToBackToolStripButton.Enabled = automation__1.CanSendToBack
            _bringToFirstToolStripButton.Enabled = automation__1.CanBringToFirst
            _sendToLastToolStripButton.Enabled = automation__1.CanSendToLast
            _propertiesToolStripButton.Enabled = automation__1.CanShowObjectProperties
         Else
            _bringToFrontToolStripButton.Enabled = False
            _sendToBackToolStripButton.Enabled = False
            _bringToFirstToolStripButton.Enabled = False
            _sendToLastToolStripButton.Enabled = False
            _propertiesToolStripButton.Enabled = False
         End If

         If _rasterImageViewer.Image IsNot Nothing Then
            If Not _toolStrip.Enabled Then
               _toolStrip.Enabled = True
            End If

            Dim currentPage As Integer = _rasterImageViewer.Image.Page
            Dim pageCount As Integer = _rasterImageViewer.Image.PageCount

            _pageToolStripTextBox.Text = currentPage.ToString()
            _pageToolStripLabel.Text = "/ " & pageCount.ToString()

            _previousPageToolStripButton.Enabled = currentPage > 1
            _nextPageToolStripButton.Enabled = currentPage < pageCount
         Else
            _pageToolStripTextBox.Text = "0"
            _pageToolStripLabel.Text = "/ 0"

            _zoomToolStripComboBox.Text = String.Empty

            _toolStrip.Enabled = False
         End If
      End Sub

      Private Sub _rasterImageViewer_TransformChanged(sender As Object, e As EventArgs) Handles _rasterImageViewer.TransformChanged
         If Not DesignMode AndAlso IsHandleCreated Then
            UpdateZoomValueFromControl()
            UpdateUIState()
         End If
      End Sub

      Private Sub _previousPageToolStripButton_Click(sender As Object, e As EventArgs) Handles _previousPageToolStripButton.Click
         TryGotoPage(_rasterImageViewer.Image.Page - 1)
      End Sub

      Private Sub _nextPageToolStripButton_Click(sender As Object, e As EventArgs) Handles _nextPageToolStripButton.Click
         TryGotoPage(_rasterImageViewer.Image.Page + 1)
      End Sub

      Private Sub _pageToolStripTextBox_LostFocus(sender As Object, e As EventArgs)
         _pageToolStripTextBox.Text = _rasterImageViewer.Image.Page.ToString()
      End Sub

      Private Sub _pageToolStripTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _pageToolStripTextBox.KeyPress
         If e.KeyChar = CChar(Microsoft.VisualBasic.ChrW(Keys.Return)) Then
            ' User has pressed enter, go to the new page number

            Dim str As String = _pageToolStripTextBox.Text.Trim()

            ' Try to parse the integer value
            Dim pageNumber As Integer
            If Integer.TryParse(str, pageNumber) Then
               TryGotoPage(pageNumber)
            End If

            _pageToolStripTextBox.Text = _rasterImageViewer.Image.Page.ToString()
         End If
      End Sub

      Private Sub TryGotoPage(pageNumber As Integer)
         ' Check if the index is valid
         If pageNumber >= 1 AndAlso pageNumber <= _rasterImageViewer.Image.PageCount Then
            ' Yes, fire the event to the main form
            DoAction("PageNumberChanged", pageNumber)
         End If
      End Sub

      Private Sub _zoomOutToolStripButton_Click(sender As Object, e As EventArgs) Handles _zoomOutToolStripButton.Click
         ZoomViewer(True)
      End Sub

      Private Sub _zoomInToolStripButton_Click(sender As Object, e As EventArgs) Handles _zoomInToolStripButton.Click
         ZoomViewer(False)
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
                  UpdateZoomValueFromControl()
               End If
            End If
         End If
      End Sub

      Private Sub SetViewerZoomPercentage(percentage As Double)
         ' Normalize the percentage based on min/max value allowed
         percentage = Math.Max(_minimumViewerScalePercentage, Math.Min(_maximumViewerScalePercentage, percentage))

         If Math.Abs(_rasterImageViewer.ScaleFactor * 100.0 - percentage) > 0.01 Then
            ' Save the current center location in the viewer, we will use it later to
            ' re-center the viewer

            Dim LeadPhysicalViewRectangle As LeadRectD = _rasterImageViewer.GetItemViewBounds(_rasterImageViewer.ActiveItem, ImageViewerItemPart.Image, True)
            Dim LeadLogicalViewRectangle As LeadRectD = _rasterImageViewer.GetItemBounds(_rasterImageViewer.ActiveItem, ImageViewerItemPart.Image)

            Dim PhysicalViewRectangle As New Rectangle(CInt(LeadPhysicalViewRectangle.Left), CInt(LeadPhysicalViewRectangle.Top), CInt(LeadPhysicalViewRectangle.Width), CInt(LeadPhysicalViewRectangle.Height))
            Dim LogicalViewRectangle As New Rectangle(CInt(LeadLogicalViewRectangle.Left), CInt(LeadLogicalViewRectangle.Top), CInt(LeadLogicalViewRectangle.Width), CInt(LeadLogicalViewRectangle.Height))

            Dim rc As Rectangle = Rectangle.Intersect(PhysicalViewRectangle, LogicalViewRectangle)
            Dim center As New PointF(rc.Left + rc.Width \ 2, rc.Top + rc.Right \ 2)

            Dim LeadM As LeadMatrix = _rasterImageViewer.ImageTransform
            Dim M As New Matrix(CSng(LeadM.M11), CSng(LeadM.M12), CSng(LeadM.M21), CSng(LeadM.M22), CSng(LeadM.OffsetX), CSng(LeadM.OffsetY))
            Dim trans As New Transformer(M)
            center = trans.PointToLogical(center)

            _rasterImageViewer.BeginUpdate()

            ' Switch to normal size mode if we are not in it
            If _rasterImageViewer.SizeMode <> ControlSizeMode.ActualSize Then
               _rasterImageViewer.Zoom(ControlSizeMode.ActualSize, 1, _rasterImageViewer.DefaultZoomOrigin)
            End If

            ' Zoom
            _rasterImageViewer.Zoom(ControlSizeMode.None, percentage / 100.0, _rasterImageViewer.DefaultZoomOrigin)

            ' Go back to original center point
            LeadM = _rasterImageViewer.ImageTransform
            M = New Matrix(CSng(LeadM.M11), CSng(LeadM.M12), CSng(LeadM.M21), CSng(LeadM.M22), CSng(LeadM.OffsetX), CSng(LeadM.OffsetY))
            trans.Transform = M
            center = trans.PointToPhysical(center)

            _rasterImageViewer.CenterAtPoint(LeadPoint.Create(CInt(Math.Truncate(center.X)), CInt(Math.Truncate(center.Y))))

            _rasterImageViewer.EndUpdate()

            _rasterImageViewer_TransformChanged(_rasterImageViewer, EventArgs.Empty)

            UpdateUIState()
         End If
      End Sub

      Private Sub _fitPageWidthToolStripButton_Click(sender As Object, e As EventArgs) Handles _fitPageWidthToolStripButton.Click
         FitPage(True)
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


      Private Sub _bringToFrontToolStripButton_Click(sender As Object, e As EventArgs) Handles _bringToFrontToolStripButton.Click
         Dim automation__1 As AnnAutomation = Automation
         automation__1.BringToFront(False)
      End Sub

      Private Sub _sendToBackToolStripButton_Click(sender As Object, e As EventArgs) Handles _sendToBackToolStripButton.Click
         Dim automation__1 As AnnAutomation = Automation
         automation__1.SendToBack(False)
      End Sub

      Private Sub _bringToFirstToolStripButton_Click(sender As Object, e As EventArgs) Handles _bringToFirstToolStripButton.Click
         Dim automation__1 As AnnAutomation = Automation
         automation__1.BringToFront(True)
      End Sub

      Private Sub _sendToLastToolStripButton_Click(sender As Object, e As EventArgs) Handles _sendToLastToolStripButton.Click
         Dim automation__1 As AnnAutomation = Automation
         automation__1.SendToBack(False)
      End Sub

      Private Sub _propertiesToolStripButton_Click(sender As Object, e As EventArgs) Handles _propertiesToolStripButton.Click
         Dim automation__1 As AnnAutomation = Automation
         automation__1.ShowObjectProperties()
      End Sub

      Private Sub DoAction(action As String, data As Object)
         ' Raise the action event so the main form can handle it

         RaiseEvent Action(Me, New ActionEventArgs(action, data))
      End Sub

      Private Sub _rasterImageViewer_MouseMove(sender As Object, e As MouseEventArgs) Handles _rasterImageViewer.MouseMove
         Dim str As String

         If _rasterImageViewer.Image IsNot Nothing Then
            ' Show the mouse position in physical and logical (inches) coordinates

            Dim physical As New PointF(e.X, e.Y)
            Dim pixels As PointF

            Dim LeadM As LeadMatrix = _rasterImageViewer.ImageTransform
            Dim M As New Matrix(CSng(LeadM.M11), CSng(LeadM.M12), CSng(LeadM.M21), CSng(LeadM.M22), CSng(LeadM.OffsetX), CSng(LeadM.OffsetY))
            Dim trans As New Transformer(M)
            pixels = trans.PointToLogical(physical)

            ' Convert the logical point to inches            
            Dim inches As LeadPointD = Automation.Container.Mapper.PointFromContainerCoordinates(LeadPointD.Create(CInt(Math.Truncate(pixels.X)), CInt(Math.Truncate(pixels.Y))), AnnFixedStateOperations.Scrolling Or AnnFixedStateOperations.Zooming)

            str = String.Format("{0},{1} px {2},{3} in", CInt(Math.Truncate(pixels.X)), CInt(Math.Truncate(pixels.Y)), inches.X.ToString("F02"), inches.Y.ToString("F02"))
         Else
            str = String.Empty
         End If

         _mousePositionLabel.Text = str
      End Sub

      Private Sub _rasterImageViewer_MouseDown(sender As Object, e As MouseEventArgs) Handles _rasterImageViewer.MouseDown

         Dim physical As New PointF(e.X, e.Y)
         Dim pixels As PointF

         Dim LeadM As LeadMatrix = _rasterImageViewer.ImageTransform
         Dim M As New Matrix(CSng(LeadM.M11), CSng(LeadM.M12), CSng(LeadM.M21), CSng(LeadM.M22), CSng(LeadM.OffsetX), CSng(LeadM.OffsetY))
         Dim trans As New Transformer(M)
         pixels = trans.PointToLogical(physical)


         Dim bookmarkPosition As New Point(CInt(Math.Truncate(pixels.X)), CInt(Math.Truncate(pixels.Y)))

         If pixels.X < 0 Then
            bookmarkPosition.X = 0
         End If
         If pixels.X > _rasterImageViewer.Image.Width Then
            bookmarkPosition.X = _rasterImageViewer.Image.Width
         End If

         If pixels.Y < 0 Then
            bookmarkPosition.Y = 0
         End If
         If pixels.Y > _rasterImageViewer.Image.Height Then
            bookmarkPosition.Y = _rasterImageViewer.Image.Height
         End If

         DoAction("UpdateBookmarkPosition", bookmarkPosition)

      End Sub
   End Class
End Namespace
