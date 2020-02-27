' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
' Uncomment this to use the pre v19 Leadtools.Annotations.WinForms.AutomationImageViewer
' which derives from ImageViewer
' Leave this commented out to use the new Leadtools.Annotations.WinForms.ImageViewerAutomationControl which
' contains an ImageViewer instance (doesn't derive from it)
'#define USE_ImageViewerAutomationControl

Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Collections.Generic
Imports System.Reflection
Imports System

Imports Leadtools
Imports Leadtools.Annotations
Imports Leadtools.Drawing
Imports Leadtools.Annotations.Automation
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.WinForms
Imports Leadtools.Annotations.Rendering
Imports Leadtools.Annotations.Designers
Imports Leadtools.Controls

''' <summary>
''' Summary description for AnnotationsForm.
''' </summary>
Public Class AnnotationsForm
   Inherits System.Windows.Forms.Form


   Public Event AutomationTextAdded As EventHandler
   Public Event AutomationTextRemoved As EventHandler
   Protected Sub OnAutomationTextAdded(args As EventArgs)
      RaiseEvent AutomationTextAdded(Me, args)
   End Sub

   Protected Sub OnAutomationTextRemoved(args As EventArgs)
      RaiseEvent AutomationTextRemoved(Me, args)
   End Sub

   Private _isEditingText As Boolean = False

   Public Property IsEditingText() As Boolean
      Get
         If Automation.CurrentDesigner IsNot Nothing Then
            Dim annRichTextEditDesigner As AnnRichTextEditDesigner = TryCast(Automation.CurrentDesigner, AnnRichTextEditDesigner)
            If annRichTextEditDesigner IsNot Nothing Then
               _isEditingText = annRichTextEditDesigner.IsEditingText

            End If
         End If
         Return _isEditingText
      End Get
      Set(value As Boolean)
         _isEditingText = value
      End Set
   End Property

   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.Container = Nothing

   Public Sub New()
      '
      ' Required for Windows Form Designer support
      '
      InitializeComponent()
   End Sub

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing Then
         CleanUp(disposing)

         If components IsNot Nothing Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

#Region "Windows Form Designer generated code"
   ''' <summary>
   ''' Required method for Designer support - do not modify
   ''' the contents of this method with the code editor.
   ''' </summary>
   Private Sub InitializeComponent()
      Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(AnnotationsForm))
      Me.SuspendLayout()
      ' 
      ' AnnotationsForm
      ' 
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(292, 271)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "AnnotationsForm"
      Me.Text = "w4"
      Me.TransparencyKey = System.Drawing.Color.White
      Me.ResumeLayout(False)

   End Sub
#End Region

   Private _automationControl As IAnnAutomationControl

#If Not USE_ImageViewerAutomationControl Then
   Private _viewer As ImageViewer
#Else
		Private _viewer As AutomationImageViewer
#End If

   Private Sub InitClass()
#If Not USE_ImageViewerAutomationControl Then
      _viewer = New ImageViewer()
      Dim automationControl As ImageViewerAutomationControl = New ImageViewerAutomationControl()
      automationControl.ImageViewer = _viewer
      _automationControl = automationControl
#Else
			_viewer = New AutomationImageViewer()
			_automationControl = _viewer
#End If
      _viewer.BorderStyle = BorderStyle.None
      Controls.Add(_viewer)
      _viewer.BringToFront()

      AddHandler _viewer.MouseMove, AddressOf _viewer_MouseMove
      AddHandler _viewer.KeyDown, AddressOf _viewer_KeyDown

      ' Use an elliptical magnifying glass with a thick green cross
      '_viewer.MagnifyGlass.Size = new Size(200, 200);
      '         _viewer.MagnifyGlass.BorderColor = Color.Red;
      '         _viewer.MagnifyGlass.BorderWidth = 2;
      '         _viewer.MagnifyGlass.Crosshair = RasterMagnifyGlassCrosshair.Fine;
      '         _viewer.MagnifyGlass.CrosshairColor = Color.Green;
      '         _viewer.MagnifyGlass.CrosshairWidth = 1;
      '         _viewer.MagnifyGlass.RoundRectangleEllipseSize = new Size(30, 30);
      '        _viewer.MagnifyGlass.ScaleFactor = 2;
      '         _viewer.MagnifyGlass.Shape = RasterMagnifyGlassShape.RoundRectangle;

      _viewer.UseDpi = False
      _viewer.Focus()
      AddHandler _viewer.TransformChanged, AddressOf _viewer_TransformChanged
   End Sub

   Private Sub _viewer_TransformChanged(sender As Object, e As EventArgs)
      RemoveAutomationTextBox(True)
   End Sub

   Private Sub CleanUp(disposing As Boolean)
      If disposing Then
#If Not USE_ImageViewerAutomationControl Then
         Dim automationControl As ImageViewerAutomationControl = TryCast(_automationControl, ImageViewerAutomationControl)
         If automationControl IsNot Nothing Then
            automationControl.Dispose()
         End If
#End If

         If _viewer IsNot Nothing Then
            _viewer.Dispose()
         End If
      End If
   End Sub

   Public ReadOnly Property MainForm() As MainForm
      Get
         Return TryCast(MdiParent, MainForm)
      End Get
   End Property

   Public ReadOnly Property Viewer() As ImageViewer
      Get
         Return _viewer
      End Get
   End Property

   Public ReadOnly Property AutomationControl() As IAnnAutomationControl
      Get
         Return _automationControl
      End Get
   End Property

   Public ReadOnly Property Automation() As AnnAutomation
      Get
         If _automationControl IsNot Nothing Then
            Return TryCast(_automationControl.AutomationObject, AnnAutomation)
         Else
            Return Nothing
         End If
      End Get
   End Property

   Private _automationInteractiveMode As AutomationInteractiveMode

   Public Property AutomationInteractiveMode() As AutomationInteractiveMode
      Get
         Return _automationInteractiveMode
      End Get
      Set(value As AutomationInteractiveMode)
         _automationInteractiveMode = value
      End Set
   End Property

   Private _automationTextBox As AutomationTextBox

   Private _panZoomInteractiveMode As ImageViewerPanZoomInteractiveMode

   Public Property PanZoomInteractiveMode() As ImageViewerPanZoomInteractiveMode
      Get
         Return _panZoomInteractiveMode
      End Get
      Set(value As ImageViewerPanZoomInteractiveMode)
         _panZoomInteractiveMode = value
      End Set
   End Property

   Private _magnifyGlassInteractiveMode As ImageViewerMagnifyGlassInteractiveMode

   Public Property MagnifyGlassInteractiveMode() As ImageViewerMagnifyGlassInteractiveMode
      Get
         Return _magnifyGlassInteractiveMode
      End Get
      Set(value As ImageViewerMagnifyGlassInteractiveMode)
         _magnifyGlassInteractiveMode = value
      End Set
   End Property

   Private Sub InitInteractiveModes()
      _automationInteractiveMode = New AutomationInteractiveMode()
      ' Don't set the cursors, AnnAutomation will take care of it
      _automationInteractiveMode.AutomationControl = _automationControl

      _magnifyGlassInteractiveMode = New ImageViewerMagnifyGlassInteractiveMode()
      _magnifyGlassInteractiveMode.IdleCursor = Cursors.Cross
      _magnifyGlassInteractiveMode.WorkingCursor = Cursors.Cross

      _panZoomInteractiveMode = New ImageViewerPanZoomInteractiveMode()
      _panZoomInteractiveMode.IdleCursor = Cursors.SizeAll
      _panZoomInteractiveMode.WorkingCursor = Cursors.SizeAll

      Dim modes As ImageViewerInteractiveMode() = {_automationInteractiveMode, _panZoomInteractiveMode, _magnifyGlassInteractiveMode}
      _viewer.InteractiveModes.BeginUpdate()
      For Each mode As ImageViewerInteractiveMode In modes
         mode.IsEnabled = False

         Dim spyglass As ImageViewerSpyGlassInteractiveMode = TryCast(mode, ImageViewerSpyGlassInteractiveMode)
         If spyglass IsNot Nothing Then
            mode.IdleCursor = Cursors.Cross
            spyglass.Shape = ImageViewerSpyGlassShape.Rectangle
         End If

         _viewer.InteractiveModes.Add(mode)
      Next
      _automationInteractiveMode.IsEnabled = True
      _viewer.InteractiveModes.EndUpdate()
   End Sub

   Public Sub Initialize(paintProperties As RasterPaintProperties, image As RasterImage, fileName As String, pageNumber As Integer)
      InitClass()
      Text = fileName
      _viewer.Image = image
      _automationControl.AutomationDataProvider = New RasterImageAutomationDataProvider(image)
      UpdatePaintProperties(paintProperties)
      InitInteractiveModes()

      Dim automation As New AnnAutomation(MainForm.AutomationManager, _automationControl)
      ' Update the container size
      automation.Container.Size = automation.Container.Mapper.SizeToContainerCoordinates(LeadSizeD.Create(_viewer.Image.ImageWidth, _viewer.Image.ImageHeight))

      AddHandler automation.EditText, AddressOf automation_EditText
      AddHandler automation.EditContent, AddressOf automation_EditContent
      AddHandler automation.Container.Children.CollectionChanged, AddressOf Children_CollectionChanged
      automation.Container.Mapper.FontRelativeToDevice = False
      AddHandler automation.AfterObjectChanged, AddressOf automation_AfterObjectChanged
      AddHandler automation.CurrentDesignerChanged, AddressOf automation_CurrentDesignerChanged
      AddHandler automation.UndoRedoChanged, AddressOf automation_UndoRedoChanged
      AddHandler automation.OnShowContextMenu, AddressOf automation_OnShowContextMenu
      AddHandler automation.OnShowObjectProperties, AddressOf automation_OnShowObjectProperties
      AddHandler automation.LockObject, AddressOf automation_LockObject
      AddHandler automation.UnlockObject, AddressOf automation_UnlockObject
      AddHandler automation.DeserializeObjectError, AddressOf automation_DeserializeObjectError
      AddHandler automation.SetCursor, AddressOf automation_SetCursor
      AddHandler automation.RestoreCursor, AddressOf automation_RestoreCursor
      AddHandler automation.ToolTip, AddressOf automation_ToolTip

      MainForm.UpdateControls()
   End Sub


   Private Sub automation_ToolTip(sender As Object, e As AnnToolTipEventArgs)
      If e.AnnotationObject IsNot Nothing Then
         Dim text As AnnTextObject = TryCast(e.AnnotationObject, AnnTextObject)
         Dim toolTipText As String = String.Empty

         If text IsNot Nothing Then
            toolTipText = text.Text
         Else
            Dim ruler As AnnPolyRulerObject = TryCast(e.AnnotationObject, AnnPolyRulerObject)
            If ruler IsNot Nothing Then
               If ruler.MeasurementUnit = AnnUnit.Pixel Then
                  Dim lengthInUnits As LeadLengthD = ruler.GetRulerLength(1)
                  Dim lengthInPixels As Double = Automation.Container.Mapper.LengthFromContainerCoordinates(lengthInUnits, AnnFixedStateOperations.Scrolling Or AnnFixedStateOperations.Zooming)
                  toolTipText = String.Format("{0} {1}", Math.Round(lengthInPixels, 2), ruler.UnitsAbbreviation(AnnUnit.Pixel))
               Else
                  toolTipText = ruler.GetRulerLengthAsString(Automation.Container.Mapper.CalibrationScale)
               End If
            Else
               Dim richText As AnnRichTextObject = TryCast(e.AnnotationObject, AnnRichTextObject)
               If richText IsNot Nothing Then
                  toolTipText = richText.ToString()
               Else
                  Dim annAutomationObject As AnnAutomationObject = MainForm.ManagerHelper.AutomationManager.FindObjectById(e.AnnotationObject.Id)
                  toolTipText = annAutomationObject.Name
               End If
            End If
         End If

         MainForm.ManagerHelper.SetToolTip(_viewer, toolTipText)
      Else
         MainForm.ManagerHelper.SetToolTip(Nothing, String.Empty)
      End If
   End Sub

   Private Sub automation_RestoreCursor(sender As Object, e As EventArgs)
      If Viewer.Cursor <> Cursors.Default Then
         Viewer.Cursor = Cursors.Default
      End If
   End Sub


   Private Sub automation_SetCursor(sender As Object, e As AnnCursorEventArgs)
      If Not _automationInteractiveMode.IsEnabled Then
         Return
      End If

      Dim automation As AnnAutomation = TryCast(sender, AnnAutomation)
      Dim newCursor As Cursor = Nothing

      Select Case e.DesignerType
         Case AnnDesignerType.Draw
            If True Then
               Dim allow As Boolean = True

               Dim drawDesigner As AnnDrawDesigner = TryCast(automation.CurrentDesigner, AnnDrawDesigner)
               If drawDesigner IsNot Nothing AndAlso Not drawDesigner.IsTargetObjectAdded AndAlso e.PointerEvent IsNot Nothing Then
                  ' See if we can draw or not
                  Dim container As AnnContainer = automation.ActiveContainer

                  allow = False

                  If automation.HitTestContainer(e.PointerEvent.Location, False) IsNot Nothing Then
                     allow = True
                  End If
               End If

               If allow Then
                  Dim annAutomationObject As AnnAutomationObject = automation.Manager.FindObjectById(e.Id)
                  If annAutomationObject IsNot Nothing Then
                     newCursor = TryCast(annAutomationObject.DrawCursor, Cursor)
                  End If
               Else
                  newCursor = Cursors.No
               End If
            End If
            Exit Select

         Case AnnDesignerType.Edit
            If True Then
               If e.IsRotateCenter Then
                  newCursor = AutomationManagerHelper.AutomationCursors(CursorType.RotateCenterControlPoint)
               ElseIf e.IsRotateGripper Then
                  newCursor = AutomationManagerHelper.AutomationCursors(CursorType.RotateGripperControlPoint)
               ElseIf e.ThumbIndex < 0 Then
                  If e.DragDropEvent IsNot Nothing AndAlso Not e.DragDropEvent.Allowed Then
                     newCursor = Cursors.No
                  Else
                     newCursor = AutomationManagerHelper.AutomationCursors(CursorType.SelectedObject)
                  End If
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

      If Viewer.Cursor <> newCursor Then
         Viewer.Cursor = newCursor
      End If
   End Sub

   Private Sub automation_DeserializeObjectError(sender As Object, e As AnnSerializeObjectEventArgs)
      If String.Compare(e.TypeName, GetType(AnnRichTextObject).FullName) = 0 Then
         e.AnnObject = New AnnRichTextObject()
      End If
   End Sub

   Private Sub automation_EditText(sender As Object, e As AnnEditTextEventArgs)
      RemoveAutomationTextBox(True)

      If e.TextObject Is Nothing Then
         Return
      End If

      _automationTextBox = New AutomationTextBox(_viewer, Me.Automation, e, AddressOf RemoveAutomationTextBox)
      OnAutomationTextAdded(EventArgs.Empty)
   End Sub

   Private Sub RemoveAutomationTextBox(update As Boolean)
      If _automationTextBox Is Nothing Then
         Return
      End If

      _automationTextBox.Remove(update)

      If _automationTextBox Is Nothing Then
         _automationTextBox.Dispose()
         _automationTextBox = Nothing
      End If

      OnAutomationTextRemoved(EventArgs.Empty)
   End Sub

   Private Sub automation_EditContent(sender As Object, e As AnnEditContentEventArgs)
      Dim annObject As AnnObject = e.TargetObject

      If annObject Is Nothing OrElse Not annObject.SupportsContent OrElse TypeOf annObject Is AnnSelectionObject Then
         Return
      End If

      If TypeOf sender Is AnnDrawDesigner AndAlso annObject.Id <> annObject.StickyNoteObjectId Then
         Return
      End If

      Using dlg As AutomationUpdateObjectDialog = New AutomationUpdateObjectDialog()
         dlg.Automation = Me.Automation
         dlg.SetPageVisible(AutomationUpdateObjectDialogPage.Properties, False)
         dlg.SetPageVisible(AutomationUpdateObjectDialogPage.Reviews, False)
         dlg.TargetObject = annObject

         If dlg.ShowDialog(Me) = DialogResult.OK Then
            Automation.InvalidateObject(annObject)
         End If
      End Using
   End Sub


   Private Sub automation_UnlockObject(sender As Object, e As AnnLockObjectEventArgs)
      e.Cancel = True
      'PasswordDialog
      Dim passwordDialog As New AutomationPasswordDialog()
      If passwordDialog.ShowDialog(Me) = DialogResult.OK Then
         e.[Object].Unlock(passwordDialog.Password)

         Dim checkObject As AnnObject = Nothing

         Dim selectionObject As AnnSelectionObject = TryCast(e.[Object], AnnSelectionObject)
         If selectionObject IsNot Nothing Then
            If selectionObject.SelectedObjects.Count > 0 Then
               'checking first object is enough
               checkObject = selectionObject.SelectedObjects(0)
            End If
         Else
            checkObject = e.[Object]
         End If

         If checkObject.IsLocked Then
            MessageBox.Show("You've entered an invalid password.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         End If

         Automation.Invalidate(LeadRectD.Empty)
      End If
   End Sub

   Private Sub automation_LockObject(sender As Object, e As AnnLockObjectEventArgs)
      Dim passwordDialog As New AutomationPasswordDialog()
      passwordDialog.Lock = True
      If passwordDialog.ShowDialog(Me) = DialogResult.OK Then
         e.Password = passwordDialog.Password
      Else
         e.Cancel = True
      End If
   End Sub

   Private Sub automation_OnShowObjectProperties(sender As Object, e As AnnAutomationEventArgs)
      Using dlg As AutomationUpdateObjectDialog = New AutomationUpdateObjectDialog()
         Dim automation As AnnAutomation = Me.Automation

         Dim currentObject As AnnObject = automation.CurrentEditObject
         Dim isSelectionObject As Boolean = TypeOf currentObject Is AnnSelectionObject

         If currentObject IsNot Nothing Then
            If Not currentObject.SupportsContent OrElse isSelectionObject Then
               dlg.SetPageVisible(AutomationUpdateObjectDialogPage.Content, False)
               If isSelectionObject Then
                  dlg.SetPageVisible(AutomationUpdateObjectDialogPage.Reviews, False)
               End If
            End If
         End If

         dlg.Automation = automation

         Try
            dlg.ShowDialog(Me)
            e.Cancel = Not dlg.IsModified
            MainForm.UpdateControls()
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      End Using
   End Sub

   Private Sub automation_OnShowContextMenu(sender As Object, e As AnnAutomationEventArgs)
      If e IsNot Nothing AndAlso e.Object IsNot Nothing Then
         _automationControl.AutomationInvalidate(LeadRectD.Empty)
         Dim annAutomationObject As AnnAutomationObject = TryCast(e.Object, AnnAutomationObject)
         If annAutomationObject IsNot Nothing Then
            Dim menu As ObjectContextMenu = TryCast(annAutomationObject.ContextMenu, ObjectContextMenu)
            If menu IsNot Nothing Then
               menu.Automation = TryCast(sender, AnnAutomation)
               menu.Show(Me, _viewer.PointToClient(Cursor.Position))
            End If
         End If
      Else
         Dim defaultMenu As New ManagerContextMenu()
         defaultMenu.Automation = TryCast(sender, AnnAutomation)
         AddHandler defaultMenu.Collapse, AddressOf defaultMenu_Collapse
         defaultMenu.Show(Me, _viewer.PointToClient(Cursor.Position))
      End If
   End Sub

   Private Sub defaultMenu_Collapse(sender As Object, e As EventArgs)
      MainForm.UpdateControls()
   End Sub

   Private Sub AnnotationsForm_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs)Handles Me.Closing
      Dim automation__1 As AnnAutomation = Automation
      If automation__1 IsNot Nothing Then
         RemoveHandler automation__1.EditText, AddressOf automation_EditText
         RemoveHandler automation__1.EditContent, AddressOf automation_EditContent
         RemoveHandler automation__1.Container.Children.CollectionChanged, AddressOf Children_CollectionChanged
         automation__1.Container.Mapper.FontRelativeToDevice = False
         RemoveHandler automation__1.AfterObjectChanged, AddressOf automation_AfterObjectChanged
         RemoveHandler automation__1.CurrentDesignerChanged, AddressOf automation_CurrentDesignerChanged
         RemoveHandler automation__1.UndoRedoChanged, AddressOf automation_UndoRedoChanged
         RemoveHandler automation__1.OnShowContextMenu, AddressOf automation_OnShowContextMenu
         RemoveHandler automation__1.OnShowObjectProperties, AddressOf automation_OnShowObjectProperties
         RemoveHandler automation__1.LockObject, AddressOf automation_LockObject
         RemoveHandler automation__1.UnlockObject, AddressOf automation_UnlockObject
         RemoveHandler automation__1.DeserializeObjectError, AddressOf automation_DeserializeObjectError
         RemoveHandler automation__1.SetCursor, AddressOf automation_SetCursor
         RemoveHandler automation__1.RestoreCursor, AddressOf automation_RestoreCursor

         If Not e.Cancel Then
            MainForm.AutomationManager.Automations.Remove(automation__1)
         End If
      End If
   End Sub


   Public Sub UpdatePaintProperties(paintProperties As RasterPaintProperties)
      '_viewer.PaintProperties = paintProperties;
   End Sub

   Private Sub automation_CurrentDesignerChanged(sender As Object, e As EventArgs)
      MainForm.CurrentDesignerChanged()
      MainForm.UpdateControls()
   End Sub

   Private Sub automation_AfterObjectChanged(sender As Object, e As AnnAfterObjectChangedEventArgs)
      If MainForm.RedactionMessage AndAlso e.ChangeType = AnnObjectChangedType.RealizeRedaction Then
         Messager.ShowInformation(Me, "When restoring a realized redaction object, the redaction object must be in its original location.")
         MainForm.RedactionMessage = False
      End If
      MainForm.UpdateControls()
   End Sub

   Private Sub Children_CollectionChanged(sender As Object, e As AnnNotifyCollectionChangedEventArgs)
      MainForm.UpdateControls()
   End Sub

   Private Sub _viewer_MouseMove(sender As Object, e As MouseEventArgs)
      If Automation IsNot Nothing AndAlso Automation.Container IsNot Nothing Then
         Dim physical As New LeadPointD(e.X, e.Y)
         Dim logical As LeadPointD = Automation.Container.Mapper.PointToContainerCoordinates(physical)
         MainForm.SetStatusBarText(String.Format("{0}, {1} ({2}, {3})", physical.X, physical.Y, logical.X, logical.Y))
      Else
         MainForm.SetStatusBarText(String.Format("{0}, {1}", e.X, e.Y))
      End If
   End Sub

   Private Sub automation_UndoRedoChanged(sender As Object, e As EventArgs)
      MainForm.UpdateControls()
   End Sub

   Private Sub automation_ImageDirtyChanged(sender As Object, e As EventArgs)
      MainForm.UpdateControls()
   End Sub

   Private Sub _viewer_KeyDown(sender As Object, e As KeyEventArgs)
      If Not e.Handled Then
         If e.KeyCode = Keys.Add OrElse e.KeyCode = Keys.Oemplus OrElse e.KeyCode = Keys.Subtract OrElse e.KeyCode = Keys.OemMinus Then
            e.Handled = True

            MainForm.Zoom(e.KeyCode = Keys.Add OrElse e.KeyCode = Keys.Oemplus)
         End If
      End If
   End Sub

   Public Sub UpdateAntiAlias(value As Boolean)
      _automationControl.AutomationAntiAlias = value
   End Sub
End Class
