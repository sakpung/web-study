' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Annotations.Automation
Imports Leadtools.Annotations.WinForms
Imports Leadtools.Codecs
Imports Leadtools
Imports Leadtools.Annotations.Engine
Imports System.Xml
Imports Leadtools.Annotations.Designers
Imports Leadtools.Annotations.Rendering
Imports System
Imports Leadtools.Demos.Dialogs
Imports Leadtools.Controls

Partial Public Class MainForm : Inherits Form
   Private _containerNode As LayerNode = Nothing
   Private _layerContextMenu As New LayerContextMenu()
   Private _automationManager As AnnAutomationManager
   Private _managerHelper As AutomationManagerHelper = Nothing
   Private _imageViewer As AutomationImageViewer = Nothing
   Private _automation As AnnAutomation = Nothing

   Public Sub New()
      InitializeComponent()
      Text = "LEADTOOLS C# Annotations Layers Demo"
   End Sub

   <STAThread()> _
   Shared Sub Main()
      Dim startupMsgBox As StartupMessageBox = New StartupMessageBox("VBAnnotationsLayersDemo")
      If (startupMsgBox.ShowStartUpDialog) Then
         startupMsgBox.ShowDialog()
      End If
      

      If Not Support.SetLicense() Then
         Return
      End If

      If RasterSupport.IsLocked(RasterSupportType.Document) Then
         MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.Document.ToString()), "Warning")
         Return
      End If

      Application.EnableVisualStyles()
      Application.DoEvents()

      Application.Run(New MainForm())
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      If Not DesignMode Then
         _automationManager = AnnAutomationManager.Create(New AnnWinFormsRenderingEngine())

         _automationManager.RedactionRealizePassword = String.Empty
         _automationManager.CreateDefaultObjects()

         _managerHelper = New AutomationManagerHelper(_automationManager)
         _managerHelper.CreateToolBar()
         FlipReverseText(_automationManager.RenderingEngine, True)

         _managerHelper.ToolBar.Dock = DockStyle.Right
         _managerHelper.ToolBar.AutoSize = False
         _managerHelper.ToolBar.Width = 100
         _managerHelper.ToolBar.Appearance = ToolBarAppearance.Normal
         Me.Controls.Add(_managerHelper.ToolBar)
         _managerHelper.ToolBar.BringToFront()

         _imageViewer = New AutomationImageViewer()
         AddHandler _imageViewer.KeyDown, AddressOf _imageViewer_KeyDown
         _imageViewer.Dock = DockStyle.Fill
         Me.Controls.Add(_imageViewer)
         _imageViewer.BringToFront()

         Dim automationInteractiveMode As New AutomationInteractiveMode()
         automationInteractiveMode.MouseButtons = MouseButtons.Left Or MouseButtons.Right
         _imageViewer.InteractiveModes.Add(automationInteractiveMode)

         _imageViewer.UseDpi = False

         _imageViewer.Zoom(ControlSizeMode.FitWidth, 1, LeadPoint.Empty)
         _imageViewer.ImageHorizontalAlignment = ControlAlignment.Center
         _imageViewer.ImageBorderColor = Color.Black
         _imageViewer.BorderStyle = BorderStyle.Fixed3D
         _imageViewer.ImageBorderThickness = 1

         Using codec As New RasterCodecs()
            _imageViewer.Image = codec.Load(DemosGlobal.ImagesFolder + "\ocr1.tif")
            _imageViewer.AutomationDataProvider = New RasterImageAutomationDataProvider(_imageViewer.Image)
         End Using

         _automation = New AnnAutomation(_automationManager, _imageViewer)

         ' Update the container size
         _automation.Container.Size = _automation.Container.Mapper.SizeToContainerCoordinates(LeadSizeD.Create(_imageViewer.Image.ImageWidth, _imageViewer.Image.ImageHeight))

         AddHandler _automation.EditText, AddressOf automation_EditText
         AddHandler _automation.OnShowContextMenu, AddressOf automation_OnShowContextMenu
         AddHandler _automation.OnShowObjectProperties, AddressOf automation_OnShowObjectProperties
         AddHandler _automation.LockObject, AddressOf automation_LockObject
         AddHandler _automation.UnlockObject, AddressOf automation_UnlockObject
         AddHandler _automation.SetCursor, AddressOf automation_SetCursor
         AddHandler _automation.RestoreCursor, AddressOf automation_RestoreCursor

         _automation.Manager.Resources = Tools.LoadResources()
         _automation.Active = True

         _tvLayers.BeginUpdate()
         _tvLayers.HideSelection = False
         Dim layer As AnnLayer = AnnLayer.Create("Container")
         Dim children As AnnObjectCollection = _automation.Container.Children
         For Each annObject As AnnObject In children
            layer.Children.Add(annObject)
         Next

         _containerNode = New LayerNode(layer, Nothing, False)
         _containerNode.Tag = "Container"

         _tvLayers.Nodes.Add(_containerNode)
         _tvLayers.EndUpdate()
         CreateDefaultLayers()
         OnResize(EventArgs.Empty)
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub FlipReverseText(engine As AnnRenderingEngine, enable As Boolean)
      For Each renderer As AnnObjectRenderer In engine.Renderers.Values
         Dim annTextObjectRenderer As AnnTextObjectRenderer = TryCast(renderer, AnnTextObjectRenderer)
         If annTextObjectRenderer IsNot Nothing Then
            annTextObjectRenderer.FlipReverseText = enable
         End If
      Next
   End Sub

   Private Sub automation_EditText(sender As Object, e As AnnEditTextEventArgs)
      Dim text As New TextBox()
      Dim rc As New Rectangle(CInt(e.Bounds.Left), CInt(e.Bounds.Top), CInt(e.Bounds.Width), CInt(e.Bounds.Height))
      rc.Inflate(12, 12)
      text.Location = rc.Location
      text.Size = rc.Size
      text.AutoSize = False
      text.Tag = e.TextObject
      text.Text = e.TextObject.Text
      text.ForeColor = Color.FromName(TryCast(e.TextObject.TextForeground, AnnSolidColorBrush).Color)
      text.Font = AnnWinFormsRenderingEngine.ToFont(e.TextObject.Font)
      text.WordWrap = False
      text.AcceptsReturn = True
      text.Multiline = True
      text.Tag = e.TextObject

      AddHandler text.LostFocus, New EventHandler(AddressOf text_LostFocus)
      _imageViewer.Controls.Add(text)
      text.Focus()
      text.SelectAll()
   End Sub

   Private Sub RemoveText()
      If _imageViewer IsNot Nothing AndAlso _imageViewer.Controls IsNot Nothing Then
         For Each control As Control In _imageViewer.Controls
            If TypeOf control Is TextBox Then
               Dim textObject As AnnTextObject = TryCast(control.Tag, AnnTextObject)
               If textObject IsNot Nothing Then
                  textObject.Text = control.Text
               End If

               RemoveHandler control.LostFocus, New EventHandler(AddressOf text_LostFocus)
               _imageViewer.Controls.Remove(control)
            End If
         Next
      End If
   End Sub

   Private Sub text_LostFocus(sender As Object, e As EventArgs)
      RemoveText()
   End Sub

   Private Sub _viewer_TransformChanged(sender As Object, e As EventArgs)
      RemoveText()
   End Sub

   Private Shared Function CreateHilite(rect As LeadRectD) As AnnHiliteObject
      Dim annHiliteObject As New AnnHiliteObject()
      annHiliteObject.Rect = rect

      Return annHiliteObject
   End Function

   Private Function CreateRectangle(rect As LeadRectD, brush As AnnBrush, layer As AnnLayer) As AnnRectangleObject
      Dim annRectObject As New AnnRectangleObject()
      annRectObject.Rect = rect
      annRectObject.Fill = brush
      annRectObject.Stroke.Stroke = AnnSolidColorBrush.Create("yellow")
      _automation.Container.Children.Add(annRectObject)
      layer.Children.Add(annRectObject)

      Return annRectObject
   End Function

   Private Function CreateLayer(layerName As String) As AnnLayer
      Dim layer As AnnLayer = AnnLayer.Create(layerName)
      _automation.Container.Layers.Add(layer)
      _containerNode.Nodes.Add(New LayerNode(layer, _layerContextMenu))

      Return layer
   End Function

   Private Sub CreateDefaultLayers()
      Dim layers As String() = New String() {"Red", "Green", "Blue"}

      Dim rect As New LeadRectD(LeadPointD.Create(860, 700), LeadPointD.Create(5200, 1850))
      For Each layer As String In layers
         CreateRectangle(rect, AnnSolidColorBrush.Create(layer), CreateLayer(String.Format("{0} Layer", layer)))
         rect.Offset(360, 360)
      Next
   End Sub

   Private Sub _imageViewer_KeyDown(sender As Object, e As KeyEventArgs)
      If e.KeyCode = Keys.Delete Then
         If _automation IsNot Nothing Then
            _automation.DeleteSelectedObjects()
         End If
      End If
   End Sub

   Public Function GetSelectedNode() As LayerNode
      Return TryCast(_tvLayers.SelectedNode, LayerNode)
   End Function

   Protected Overrides Sub OnResize(e As EventArgs)
      RemoveText()
      MyBase.OnResize(e)
   End Sub

   Private Sub automation_SetCursor(sender As Object, e As AnnCursorEventArgs)
      Dim newCursor As Cursor = Nothing

      Select Case e.DesignerType
         Case AnnDesignerType.Draw
            If True Then
               Dim annAutomationObject As AnnAutomationObject = _automationManager.FindObjectById(e.Id)
               If annAutomationObject IsNot Nothing AndAlso annAutomationObject.UserData IsNot Nothing Then
                  newCursor = TryCast(annAutomationObject.DrawCursor, Cursor)
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

      If _imageViewer.Cursor <> newCursor Then
         _imageViewer.Cursor = newCursor
      End If
   End Sub

   Private Sub automation_RestoreCursor(sender As Object, e As EventArgs)
      If _imageViewer.Cursor <> Cursors.[Default] Then
         _imageViewer.Cursor = Cursors.[Default]
      End If
   End Sub

   Private Sub automation_OnShowContextMenu(sender As Object, e As AnnAutomationEventArgs)
      Dim annEditObject As AnnObject = _automation.CurrentEditObject
      If e IsNot Nothing Then
         Dim annAutomationObject As AnnAutomationObject = e.[Object]
         If annAutomationObject IsNot Nothing Then
            _imageViewer.AutomationInvalidate(LeadRectD.Empty)

            Dim contextMenu As ContextMenu = TryCast(annAutomationObject.ContextMenu, ContextMenu)
            If annAutomationObject IsNot Nothing AndAlso contextMenu IsNot Nothing Then
               Dim menu As ObjectContextMenu = TryCast(annAutomationObject.ContextMenu, ObjectContextMenu)
               Dim layer As AnnLayer = annEditObject.Layer
               If menu IsNot Nothing Then
                  If layer IsNot Nothing AndAlso Not layer.IsVisible Then
                     Return
                  End If

                  menu.Automation = TryCast(sender, AnnAutomation)
                  contextMenu.Show(Me, _imageViewer.PointToClient(Cursor.Position))
               End If
            End If
         End If
      Else
         Dim defaultMenu As New ManagerContextMenu()
         defaultMenu.Automation = TryCast(sender, AnnAutomation)
         defaultMenu.Show(Me, _imageViewer.PointToClient(Cursor.Position))
      End If
   End Sub

   Private Sub automation_OnShowObjectProperties(sender As Object, e As AnnAutomationEventArgs)
      Using dlg As AutomationUpdateObjectDialog = New AutomationUpdateObjectDialog()
         Dim automation As AnnAutomation = _automation

         If automation.CurrentEditObject IsNot Nothing Then
            ' If text, hide the note
            If automation.CurrentEditObject.Id = AnnObject.TextObjectId Then
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

   Private Sub automation_UnlockObject(sender As Object, e As AnnLockObjectEventArgs)
      Dim passwordDialog As New AutomationPasswordDialog()
      If passwordDialog.ShowDialog(Me) = DialogResult.OK Then
         e.Object.Unlock(passwordDialog.Password)
         If e.Object.IsLocked Then
            MessageBox.Show("You've entered an invalid password.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         End If
      Else
         e.Cancel = True
      End If
   End Sub

   Private Sub automation_LockObject(sender As Object, e As AnnLockObjectEventArgs)
      Dim passwordDialog As New AutomationPasswordDialog()
      passwordDialog.Lock = True
      If passwordDialog.ShowDialog(Me) = DialogResult.OK Then
         e.[Object].Lock(passwordDialog.Password)
      Else
         e.Cancel = True
      End If
   End Sub

   Private Sub _tvLayers_MouseUp(sender As Object, e As MouseEventArgs) Handles _tvLayers.MouseUp
      If e.Button = MouseButtons.Right Then
         ' Point where the mouse is clicked.
         Dim point As New Point(e.X, e.Y)

         ' Get the node that the user has clicked.
         Dim node As LayerNode = TryCast(_tvLayers.GetNodeAt(point), LayerNode)
         If node IsNot Nothing Then
            _layerContextMenu.Attach(node, _automation)
            _layerContextMenu.Show(Me, point)
         End If
      End If
   End Sub

   Private Sub _miSave_Click(sender As Object, e As EventArgs) Handles _miFileSave.Click
      Using saveFileDialog As New SaveFileDialog()
         saveFileDialog.Filter = "Annotations File|*.xml"
         If saveFileDialog.ShowDialog(Me) = DialogResult.OK Then
            Dim codecs As New AnnCodecs()
            codecs.Save(saveFileDialog.FileName, _automation.Container, AnnFormat.Annotations, 1)
         End If
      End Using
   End Sub

   Private Sub _tvLayers_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles _tvLayers.AfterCheck
      Dim node As LayerNode = TryCast(e.Node, LayerNode)

      If e.Action <> TreeViewAction.Unknown AndAlso node IsNot Nothing Then
         If node Is _containerNode Then
            _automation.Container.IsVisible = node.Checked
         Else
            If node.Layer IsNot Nothing Then
               node.Layer.IsVisible = node.Checked
            End If
         End If

         Dim editDesigner As AnnEditDesigner = TryCast(_automation.CurrentDesigner, AnnEditDesigner)
         If editDesigner IsNot Nothing Then
            editDesigner.[End]()
         End If
         _automation.Invalidate(LeadRectD.Empty)
      End If
   End Sub

   Private Sub _miLoad_Click(sender As Object, e As EventArgs) Handles _miFileLoad.Click
      Dim container As AnnContainer = _automation.Container
      Dim codecs As New AnnCodecs()

      Using openFileDialog As New OpenFileDialog()
         openFileDialog.Filter = "Annotations File|*.xml"

         If openFileDialog.ShowDialog(Me) = DialogResult.OK Then
            Dim tmpContainer As AnnContainer = Nothing
            Try
               tmpContainer = codecs.Load(openFileDialog.FileName, 1)
            Catch
               Messager.ShowError(Me, "Invalid Annotation File")
            End Try

            If tmpContainer IsNot Nothing Then
               _automation.SelectLayer(Nothing)
               container.Children.Clear()
               container.Layers.Clear()

               container.SelectionObject.SelectedObjects.Clear()
               For Each annObject As AnnObject In tmpContainer.Children
                  container.Children.Add(annObject)
               Next

               Dim tmpLayers As AnnLayerCollection = tmpContainer.Layers
               Dim containerLayers As AnnLayerCollection = _containerNode.Layer.Layers
               containerLayers.Clear()
               For Each layer As AnnLayer In tmpLayers
                  container.Layers.Add(layer)
               Next

               _tvLayers.BeginUpdate()
               _tvLayers.Nodes.Clear()
               _containerNode.Nodes.Clear()
               _tvLayers.Nodes.Add(_containerNode)
               AddLayersNodes(container.Layers, _containerNode)
               _tvLayers.EndUpdate()

               _automation.Invalidate(LeadRectD.Empty)
            End If

         End If
      End Using
   End Sub

   Private Sub AddLayerNode(layer As AnnLayer, parent As LayerNode)
      Dim layerNode As New LayerNode(layer, _layerContextMenu)
      parent.Nodes.Add(layerNode)
      AddLayersNodes(layer.Layers, layerNode)
   End Sub

   Private Sub AddLayersNodes(layers As AnnLayerCollection, parent As LayerNode)
      If layers IsNot Nothing AndAlso layers.Count > 0 Then
         For Each layer As AnnLayer In layers
            AddLayerNode(layer, parent)
         Next
      End If
   End Sub

   Private Sub _tvLayers_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles _tvLayers.NodeMouseClick
      Dim node As LayerNode = TryCast(e.Node, LayerNode)

      If node IsNot Nothing Then
         If node IsNot _containerNode Then
            _automation.SelectLayer(node.Layer)
         Else
            _automation.SelectLayer(Nothing)
         End If
      End If
   End Sub

   Private Sub _miHelpAbout_Click(sender As Object, e As EventArgs) Handles _miHelpAbout.Click
      Using aboutDialog As New AboutDialog("Annotations Layers", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub

   Private Sub CleanUp(disposing As Boolean)
      If disposing Then
         If _imageViewer IsNot Nothing Then
            _imageViewer.Dispose()
         End If

         If _managerHelper IsNot Nothing Then
            _managerHelper.Dispose()
         End If
      End If
   End Sub
End Class
