' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Diagnostics
Imports System.Collections.Generic

Imports Leadtools
Imports Leadtools.Controls
Imports Leadtools.Document.Viewer
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.Designers
Imports Leadtools.Annotations.Rendering
Imports Leadtools.Annotations.Automation
Imports Leadtools.Annotations.WinForms
Imports System
Imports Leadtools.Demos
Imports Leadtools.Document

' Contains the annotations menu and toolbar part of the viewer
Partial Public Class MainForm
   Private Sub BindAnnotationsItems()
      ' Menu
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .ToolStripItem = _annotationsToolStripMenuItem, _
         .UpdateVisible = True, _
         .CanRun = Function(documentViewer As DocumentViewer, value As Object)
                      Return documentViewer IsNot Nothing AndAlso documentViewer.HasDocument AndAlso documentViewer.Annotations IsNot Nothing

                   End Function _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsUserModeDesign, _
         .ToolStripItem = _userModeDesignToolStripMenuItem, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsUserModeRun, _
         .ToolStripItem = _userModeRunToolStripMenuItem, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsUserModeRender, _
         .ToolStripItem = _userModeRenderToolStripMenuItem, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
          .CommandName = DocumentViewerCommands.AnnotationsBringToFront, _
         .ToolStripItem = _alignBringToFrontToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsSendToBack, _
         .ToolStripItem = _alignSendToBackToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsBringToFirst, _
         .ToolStripItem = _alignBringToFirstToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsSendToLast, _
         .ToolStripItem = _alignSendToLastToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsFlip, _
         .ToolStripItem = _flipVerticalToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsReverse, _
         .ToolStripItem = _flipHorizontalToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsGroup, _
         .ToolStripItem = _groupSelectedObjectsToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsUngroup, _
         .ToolStripItem = _groupUngroupToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsLock, _
         .ToolStripItem = _securityLockToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsUnlock, _
         .ToolStripItem = _securityUnlockToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsResetRotatePoints, _
         .ToolStripItem = _resetRotatePointsToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsAntiAlias, _
         .ToolStripItem = _antiAliasToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsProperties, _
         .ToolStripItem = _annotationsPropertiesToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsUseRotateThumbs, _
         .ToolStripItem = _behaviorUseRotateThumbsToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsEnableToolTips, _
         .ToolStripItem = _behaviorEnableToolTipToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsRenderOnThumbnails, _
         .ToolStripItem = _behaviorRenderOnThumbnailsToolStripMenuItem _
      })

      ' Toolbar
   End Sub

   Private Sub _annotationsToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs)
      If _automationManagerHelper Is Nothing Then
         Return
      End If

      Dim designMode As Boolean = (_automationManagerHelper.AutomationManager.UserMode = AnnUserMode.Design)

      ' Only the user mode is available
      For Each item As ToolStripItem In _annotationsToolStripMenuItem.DropDownItems
         Dim menuItem As ToolStripMenuItem = TryCast(item, ToolStripMenuItem)
         If menuItem IsNot Nothing Then
            If menuItem IsNot _userModeToolStripMenuItem Then
               menuItem.Available = designMode
            End If
         Else
            Dim separator As ToolStripSeparator = TryCast(item, ToolStripSeparator)
            separator.Available = designMode
         End If
      Next
   End Sub

   Private Sub _behaviorToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs)
      If _automationManagerHelper Is Nothing Then
         Return
      End If

      _behaviorDeselectOnDownToolStripMenuItem.Checked = _automationManagerHelper.AutomationManager.DeselectOnDown
      _behaviorRestrictDesignersToolStripMenuItem.Checked = _automationManagerHelper.AutomationManager.RestrictDesigners
      _behaviorRubberbandSelectToolStripMenuItem.Checked = Not _automationManagerHelper.AutomationManager.ForceSelectionModifierKey

   End Sub

   Private Sub _behaviorDeselectOnDownToolStripMenuItem_Click(sender As Object, e As EventArgs)
      If _automationManagerHelper Is Nothing Then
         Return
      End If

      _automationManagerHelper.AutomationManager.DeselectOnDown = Not _automationManagerHelper.AutomationManager.DeselectOnDown
   End Sub


   Private Sub _behaviorRestrictDesignersToolStripMenuItem_Click(sender As Object, e As EventArgs)
      If _automationManagerHelper Is Nothing Then
         Return
      End If

      _automationManagerHelper.AutomationManager.RestrictDesigners = Not _automationManagerHelper.AutomationManager.RestrictDesigners
   End Sub

   Private Sub _behaviorRubberbandSelectToolStripMenuItem_Click(sender As Object, e As EventArgs)
      If _automationManagerHelper Is Nothing Then
         Return
      End If

      _automationManagerHelper.AutomationManager.ForceSelectionModifierKey = Not _automationManagerHelper.AutomationManager.ForceSelectionModifierKey
   End Sub

   Private Sub _currentObjectToolStripMenuItem_Click(sender As Object, e As EventArgs)
      Dim automationManager As AnnAutomationManager = _automationManagerHelper.AutomationManager
      Using dlg As CurrentObjectDialog = New CurrentObjectDialog(automationManager)
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            automationManager.CurrentObjectId = dlg.ObjectId
            If automationManager.CurrentObjectId = AnnObject.RubberStampObjectId Then
               automationManager.CurrentRubberStampType = dlg.RubberStampType
            End If
         End If
      End Using
   End Sub

   ' Automation manager helper
   Private _automationManagerHelper As AutomationManagerHelper

   ' Control to use when the a text object is being edited
   Private _automationTextBox As AutomationTextBox

   ' The annotations object lisy
   Private _automationObjectsList As AutomationObjectsListControl

   ' So we can switch the renderers when doing custom rendering more
   Private _originalRenderers As Dictionary(Of Integer, IAnnObjectRenderer)
   Private _renderModeRenderers As Dictionary(Of Integer, IAnnObjectRenderer)

   Private Sub InitAutomation()
      If _documentViewer.Annotations Is Nothing Then
         Return
      End If

      ' Get the automation manager from the document viewer
      Dim automationManager As AnnAutomationManager = _documentViewer.Annotations.AutomationManager
      AddHandler automationManager.UserModeChanged, Sub(sender, e)
                                                       ' Hide show the toolbars
                                                       _rightPanel.Visible = (automationManager.UserMode <> AnnUserMode.Render)

                                                       If automationManager.UserMode = AnnUserMode.Render Then
                                                          ' Setup our custom renderer
                                                          automationManager.RenderingEngine.Renderers = _renderModeRenderers
                                                       Else
                                                          automationManager.RenderingEngine.Renderers = _originalRenderers
                                                       End If

                                                    End Sub

      ' Create the manager helper. This sets the rendering engine
      _automationManagerHelper = New AutomationManagerHelper(automationManager)

      ' Save the rendering engine
      _originalRenderers = automationManager.RenderingEngine.Renderers
      ' And create the render mode renderers, make a copy of it
      _renderModeRenderers = New Dictionary(Of Integer, IAnnObjectRenderer)()
      For Each item As KeyValuePair(Of Integer, IAnnObjectRenderer) In _originalRenderers
         _renderModeRenderers.Add(item.Key, item.Value)
      Next

      ' Tell the document viewer that automation manager helper is created
      _documentViewer.Annotations.Initialize()

      ' Update our automation objects (set transparency, etc)
      _automationManagerHelper.UpdateAutomationObjects()

      ' Craete the toolbar
      _automationManagerHelper.ModifyToolBarParentVisiblity = True
      _automationManagerHelper.CreateToolBar()
      Dim toolBar As ToolBar = _automationManagerHelper.ToolBar
      toolBar.Dock = DockStyle.Fill
      toolBar.AutoSize = True
      toolBar.BorderStyle = BorderStyle.None
      toolBar.Appearance = ToolBarAppearance.Flat
      _annotationsToolBarPanel.Controls.Add(toolBar)
      toolBar.BringToFront()

      ' Create the objects list
      _automationObjectsList = New AutomationObjectsListControl()

      If _automationObjectsList IsNot Nothing Then
         _automationObjectsList.Dock = DockStyle.Fill
         _automationObjectsList.BorderStyle = BorderStyle.None
         _annotationsObjectsPanel.Controls.Add(_automationObjectsList)
         _automationObjectsList.BringToFront()
      End If
   End Sub

   Private Sub UpdateAnnotationsControlsVisiblity()
      If _documentViewer.Annotations Is Nothing Then
         _annotationsToolStripMenuItem.Visible = False
         _rightPanel.Visible = False
      Else
         _annotationsToolStripMenuItem.Visible = True
         _rightPanel.Visible = (_documentViewer.Annotations.AutomationManager.UserMode <> AnnUserMode.Render)

         Dim isEnabled As Boolean = (_documentViewer.Annotations.Automation IsNot Nothing)
         _annotationsToolStripMenuItem.Available = isEnabled
         _rightPanel.Enabled = isEnabled
      End If
   End Sub

   Private Sub HandleCreateAutomation()
      UpdateAnnotationsControlsVisiblity()

      If Not _documentViewer.HasDocument Then
         Return
      End If

      ' Get the automation object from the document viewer
      Dim automation As AnnAutomation = _documentViewer.Annotations.Automation
      If automation Is Nothing Then
         Return
      End If

      ' Optional: If the document is PDF then switch annotations to use PDF mode
      ' This will instruct the document viewer to render automation in a similar manner to Adobe Acrobat where
      If String.Compare(_documentViewer.Document.MimeType, "application/pdf", True) = 0 Then
         automation.Manager.UsePDFMode = True
      Else
         automation.Manager.UsePDFMode = False
      End If

      Dim automationControl As IAnnAutomationControl = _documentViewer.Annotations.AutomationControl

      ' Hook to the events
      AddHandler automationControl.AutomationTransformChanged, AddressOf automation_TransformChanged
      AddHandler automation.SetCursor, AddressOf automation_SetCursor
      AddHandler automation.RestoreCursor, AddressOf automation_RestoreCursor
      AddHandler automation.ToolTip, AddressOf automation_ToolTip
      AddHandler automation.OnShowObjectProperties, AddressOf automation_OnShowObjectProperties
      AddHandler automation.OnShowContextMenu, AddressOf automation_OnShowContextMenu
      AddHandler automation.EditText, AddressOf automation_EditText
      AddHandler automation.EditContent, AddressOf automation_EditContent
      AddHandler automation.LockObject, AddressOf automation_LockObject
      AddHandler automation.UnlockObject, AddressOf automation_UnlockObject
      AddHandler automation.DeserializeObjectError, AddressOf automation_DeserializeObjectError

      Dim imageViewer As ImageViewer = _documentViewer.View.ImageViewer

      ' Give it to the objects list

      If _automationObjectsList IsNot Nothing Then
         _automationObjectsList.Automation = automation
         _automationObjectsList.ImageViewer = imageViewer
         _automationObjectsList.Populate()
      End If
   End Sub

   Private Sub HandleDestroyAutomation()
      If Not _documentViewer.HasDocument Then
         Return
      End If

      RemoveAutomationTextBox(True)

      ' Get the automation object from the document viewer
      Dim automation As AnnAutomation = _documentViewer.Annotations.Automation
      If automation Is Nothing Then
         Return
      End If

      ' Remove it to the objects list
      If _automationObjectsList IsNot Nothing Then
         _automationObjectsList.Automation = Nothing
         _automationObjectsList.ImageViewer = Nothing
      End If

      Dim imageViewer As ImageViewer = _documentViewer.View.ImageViewer

      Dim automationControl As IAnnAutomationControl = _documentViewer.Annotations.AutomationControl

      ' Unhook from the events
      RemoveHandler automationControl.AutomationTransformChanged, AddressOf automation_TransformChanged
      RemoveHandler automation.SetCursor, AddressOf automation_SetCursor
      RemoveHandler automation.RestoreCursor, AddressOf automation_RestoreCursor
      RemoveHandler automation.ToolTip, AddressOf automation_ToolTip
      RemoveHandler automation.OnShowObjectProperties, AddressOf automation_OnShowObjectProperties
      RemoveHandler automation.OnShowContextMenu, AddressOf automation_OnShowContextMenu
      RemoveHandler automation.EditText, AddressOf automation_EditText
      RemoveHandler automation.EditContent, AddressOf automation_EditContent
      RemoveHandler automation.LockObject, AddressOf automation_LockObject
      RemoveHandler automation.UnlockObject, AddressOf automation_UnlockObject
      RemoveHandler automation.DeserializeObjectError, AddressOf automation_DeserializeObjectError
   End Sub

   Private Sub HandleContainersAddedOrRemoved()
      If _automationObjectsList IsNot Nothing Then
         _automationObjectsList.Populate()
      End If
   End Sub

   Private Sub HandleAnnotationsPagesDisabledEnabled()
      _automationObjectsList.HandleAnnotationsPagesDisabledEnabled()
   End Sub

   Private Sub automation_TransformChanged(sender As Object, e As EventArgs)
      If _automationTextBox IsNot Nothing Then
         RemoveAutomationTextBox(True)
      End If
   End Sub

   Private Sub automation_SetCursor(ByVal sender As Object, ByVal e As AnnCursorEventArgs)
      ' If there's an interactive mode working and its not automation, then dont do anything
      Dim imageViewer As ImageViewer = _documentViewer.View.ImageViewer
      If Not imageViewer.WorkingInteractiveMode Is Nothing AndAlso imageViewer.WorkingInteractiveMode.Id <> DocumentViewer.AnnotationsInteractiveModeId Then
         Return
      End If

      Dim automation As AnnAutomation = TryCast(sender, AnnAutomation)
      Dim newCursor As Cursor = Nothing

      If automation.ActiveContainer Is Nothing OrElse (Not automation.ActiveContainer.IsEnabled) Then
         newCursor = Cursors.Default
      Else
         Select Case e.DesignerType
            Case AnnDesignerType.Draw
               Dim allow As Boolean = True

               Dim drawDesigner As AnnDrawDesigner = TryCast(automation.CurrentDesigner, AnnDrawDesigner)
               If Not drawDesigner Is Nothing AndAlso (Not drawDesigner.IsTargetObjectAdded) AndAlso Not e.PointerEvent Is Nothing Then
                  ' See if we can draw or not
                  Dim container As AnnContainer = automation.ActiveContainer

                  allow = False

                  If Not automation.HitTestContainer(e.PointerEvent.Location, False) Is Nothing Then
                     allow = True
                  End If
               End If

               If allow Then
                  Dim annAutomationObject As AnnAutomationObject = automation.Manager.FindObjectById(e.Id)
                  If Not annAutomationObject Is Nothing Then
                     newCursor = TryCast(annAutomationObject.DrawCursor, Cursor)
                  End If
               Else
                  newCursor = Cursors.No
               End If

            Case AnnDesignerType.Edit
               If e.IsRotateCenter Then
                  newCursor = AutomationManagerHelper.AutomationCursors(CursorType.RotateCenterControlPoint)
               ElseIf e.IsRotateGripper Then
                  newCursor = AutomationManagerHelper.AutomationCursors(CursorType.RotateGripperControlPoint)
               ElseIf e.ThumbIndex < 0 Then
                  If Not e.DragDropEvent Is Nothing AndAlso (Not e.DragDropEvent.Allowed) Then
                     newCursor = Cursors.No
                  Else
                     newCursor = AutomationManagerHelper.AutomationCursors(CursorType.SelectedObject)
                  End If
               Else
                  newCursor = AutomationManagerHelper.AutomationCursors(CursorType.ControlPoint)
               End If

            Case AnnDesignerType.Run
               newCursor = AutomationManagerHelper.AutomationCursors(CursorType.Run)

            Case Else
               newCursor = AutomationManagerHelper.AutomationCursors(CursorType.SelectObject)
         End Select
      End If

      If Not imageViewer.Cursor Is newCursor Then
         imageViewer.Cursor = newCursor
      End If
   End Sub

   Private Sub automation_RestoreCursor(sender As Object, e As EventArgs)
      Dim imageViewer As ImageViewer = _documentViewer.View.ImageViewer
      Dim cursor As Cursor = Cursors.[Default]
      Dim interactiveModeCursor As Cursor = Nothing

      ' See if we have an interactive mode, use its cursor

      ' Is any working?
      If imageViewer.WorkingInteractiveMode IsNot Nothing Then
         interactiveModeCursor = imageViewer.WorkingInteractiveMode.WorkingCursor
         ' is any hit-testing?
      ElseIf imageViewer.HitTestStateInteractiveMode IsNot Nothing Then
         interactiveModeCursor = imageViewer.HitTestStateInteractiveMode.HitTestStateCursor
         ' is any idle?
      ElseIf imageViewer.IdleInteractiveMode IsNot Nothing Then
         interactiveModeCursor = imageViewer.IdleInteractiveMode.IdleCursor
      End If

      If interactiveModeCursor IsNot Nothing Then
         cursor = interactiveModeCursor
      End If

      If imageViewer IsNot Nothing AndAlso imageViewer.Cursor <> cursor Then
         imageViewer.Cursor = cursor
      End If
   End Sub

   Private Sub automation_ToolTip(sender As Object, e As AnnToolTipEventArgs)
      Dim imageViewer As ImageViewer = _documentViewer.View.ImageViewer
      If e.AnnotationObject Is Nothing Then
         _automationManagerHelper.SetToolTip(Nothing, String.Empty)
         Return
      End If

      ' If text, show the text value
      Dim textObject As AnnTextObject = TryCast(e.AnnotationObject, AnnTextObject)
      If textObject IsNot Nothing Then
         _automationManagerHelper.SetToolTip(imageViewer, textObject.Text)
         Return
      End If

      ' If ruler, show its length
      Dim rulerObject As AnnPolyRulerObject = TryCast(e.AnnotationObject, AnnPolyRulerObject)
      If rulerObject IsNot Nothing Then
         _automationManagerHelper.SetToolTip(imageViewer, rulerObject.GetRulerLengthAsString(1))
         Return
      End If

      ' If it has content, show that
      If e.AnnotationObject.Metadata.ContainsKey(AnnObject.ContentMetadataKey) Then
         Dim content As String = e.AnnotationObject.Metadata(AnnObject.ContentMetadataKey)
         _automationManagerHelper.SetToolTip(imageViewer, content)
         Return
      End If

      ' Optionally show its name ...
      '
      '         var automationObject = _automationManagerHelper.AutomationManager.FindObjectById(e.AnnotationObject.Id);
      '         _automationManagerHelper.SetToolTip(imageViewer, automationObject.Name);
      '         

   End Sub

   Private Sub automation_OnShowObjectProperties(sender As Object, e As AnnAutomationEventArgs)
      ' Get the automation object from the document viewer
      Dim automation As AnnAutomation = _documentViewer.Annotations.Automation
      If automation Is Nothing Then
         Return
      End If

      Using dlg As AutomationUpdateObjectDialog = New AutomationUpdateObjectDialog()
         If automation.CurrentEditObject IsNot Nothing Then
            Dim isSelectionObject As Boolean = TypeOf automation.CurrentEditObject Is AnnSelectionObject
            ' If is is a text or selection , hide the content
            If TypeOf automation.CurrentEditObject Is AnnTextObject OrElse isSelectionObject Then
               ' if text object, we cannot do that. Ignore, the EditText will fire
               dlg.SetPageVisible(AutomationUpdateObjectDialogPage.Content, False)

               If isSelectionObject Then
                  dlg.SetPageVisible(AutomationUpdateObjectDialogPage.Reviews, False)
               End If
            End If
         End If

         dlg.UserName = _documentViewer.UserName
         dlg.Automation = automation
         dlg.ShowDialog(Me)

         e.Cancel = Not dlg.IsModified
      End Using
   End Sub

   Private Sub automation_OnShowContextMenu(sender As Object, e As AnnAutomationEventArgs)
      Dim automation As AnnAutomation = _documentViewer.Annotations.Automation
      If automation Is Nothing Then
         Return
      End If

      Dim imageViewer As ImageViewer = _documentViewer.View.ImageViewer

      Dim position As Point = imageViewer.PointToClient(Cursor.Position)
      If e IsNot Nothing AndAlso e.[Object] IsNot Nothing Then
         automation.Invalidate(LeadRectD.Empty)
         Dim automationObject As AnnAutomationObject = TryCast(e.[Object], AnnAutomationObject)
         If automationObject IsNot Nothing Then
            Dim contextMenu As ObjectContextMenu = TryCast(automationObject.ContextMenu, ObjectContextMenu)
            If contextMenu IsNot Nothing Then
               contextMenu.Automation = automation
               contextMenu.Show(imageViewer, position)
            End If
         End If
      Else
         If _viewContextMenu Is Nothing Then
            _viewContextMenu = New ViewContextMenu(_documentViewer, AddressOf Me.DoSelectAllText)
         End If

         _viewContextMenu.Show(imageViewer, position)
      End If
   End Sub

   Private Sub automation_EditText(sender As Object, e As AnnEditTextEventArgs)
      Dim automation As AnnAutomation = _documentViewer.Annotations.Automation
      If automation Is Nothing Then
         Return
      End If

      RemoveAutomationTextBox(True)

      If e.TextObject Is Nothing Then
         Return
      End If

      Dim imageViewer As ImageViewer = _documentViewer.View.ImageViewer

      _automationTextBox = New AutomationTextBox(imageViewer, automation, e, AddressOf RemoveAutomationTextBox)

      ' we haven't changed yet
      e.Cancel = True
   End Sub

   Private Sub automation_EditContent(sender As Object, e As AnnEditContentEventArgs)
      Dim automation As AnnAutomation = _documentViewer.Annotations.Automation
      If automation Is Nothing Then
         Return
      End If

      e.Cancel = True

      RemoveAutomationTextBox(True)

      Dim targetObject As AnnObject = e.TargetObject

      If targetObject Is Nothing Then
         Return
      End If

      ' if text object, we cannot do that. Ignore, the EditText will fire
      Dim textObject As AnnTextObject = TryCast(targetObject, AnnTextObject)
      If textObject IsNot Nothing Then
         Return
      End If

      If TypeOf sender Is AnnDrawDesigner AndAlso targetObject.Id <> AnnObject.StickyNoteObjectId Then
         Return
      End If

      Using dlg As AutomationUpdateObjectDialog = New AutomationUpdateObjectDialog()
         dlg.SetPageVisible(AutomationUpdateObjectDialogPage.Properties, False)
         dlg.SetPageVisible(AutomationUpdateObjectDialogPage.Reviews, False)
         dlg.TargetObject = targetObject

         If dlg.ShowDialog(Me) = DialogResult.OK Then
            e.Cancel = False
            automation.InvalidateObject(targetObject)
         End If
      End Using
   End Sub

   Private Sub RemoveAutomationTextBox(update As Boolean)
      If _automationTextBox Is Nothing Then
         Return
      End If

      _automationTextBox.Remove(update)
      _automationTextBox.Dispose()
      _automationTextBox = Nothing

      Dim automation As AnnAutomation = _documentViewer.Annotations.Automation
      If automation.CurrentEditObject IsNot Nothing Then
         automation.InvalidateObject(automation.CurrentEditObject)
      End If
   End Sub

   Private Sub automation_LockObject(sender As Object, e As AnnLockObjectEventArgs)
      Dim automation As AnnAutomation = _documentViewer.Annotations.Automation
      If automation Is Nothing Then
         Return
      End If

      Using dlg As AutomationPasswordDialog = New AutomationPasswordDialog()
         dlg.Lock = True
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            e.Password = dlg.Password
         Else
            e.Cancel = True
         End If
      End Using
   End Sub

   Private Sub automation_UnlockObject(sender As Object, e As AnnLockObjectEventArgs)
      Dim automation As AnnAutomation = _documentViewer.Annotations.Automation
      If automation Is Nothing Then
         Return
      End If

      e.Cancel = True
      Using dlg As AutomationPasswordDialog = New AutomationPasswordDialog()
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            e.[Object].Unlock(dlg.Password)
            If e.[Object].IsLocked Then
               Helper.ShowWarning(Me, "Invalid password")
            End If

            automation.Invalidate(LeadRectD.Empty)
         End If
      End Using
   End Sub

   Private Sub automation_DeserializeObjectError(sender As Object, e As AnnSerializeObjectEventArgs)
      ' In case you need to skip objects or create them yourself
      Debug.WriteLine("Object could not be de-serialized: {0}", e.TypeName)
      e.SkipObject = True
   End Sub

   Private Sub _customizeRenderModeToolStripMenuItem_Click(sender As Object, e As EventArgs)
      Using dlg As CustomRenderModeDialog = New CustomRenderModeDialog()
         dlg.AutomationManager = _automationManagerHelper.AutomationManager
         dlg.AllRenderers = _originalRenderers
         dlg.CurrentRenderers = _renderModeRenderers

         If dlg.ShowDialog(Me) = DialogResult.OK Then
            ' Get the results
            _renderModeRenderers.Clear()
            For Each item As KeyValuePair(Of Integer, IAnnObjectRenderer) In dlg.ResultRenderers
               _renderModeRenderers.Add(item.Key, item.Value)
            Next

            _documentViewer.View.Invalidate()
            If _documentViewer.Thumbnails IsNot Nothing Then
               _documentViewer.Thumbnails.Invalidate()
            End If
         End If
      End Using
   End Sub

   Private Sub _redactionOptionsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
      If _cache Is Nothing Then
         Helper.ShowInformation(Me, "This feature is only available when a Document Cache is used")
         Return
      End If

      Dim dlg As DocumentRedactionOptionsDialog = New DocumentRedactionOptionsDialog()

      If True Then
         dlg.Options = _documentViewer.Document.Annotations.RedactionOptions.Clone()

         If dlg.ShowDialog() = DialogResult.OK Then
            Dim saveToCache As Boolean = Not _documentViewer.Document.Annotations.RedactionOptions.ViewOptions.Equals(dlg.Options.ViewOptions)
            _documentViewer.Document.Annotations.RedactionOptions = dlg.Options

            If saveToCache Then

               Try
                  Dim document As LEADDocument = _documentViewer.Document

                  ' Since we are saving the document manually to the cache, update these values:
                  document.AutoSaveToCache = False
                  document.AutoDeleteFromCache = False
                  Dim annotations As DocumentViewerAnnotations = _documentViewer.Annotations
                  ' If any of the annotation containers have been modified, save it into the document so the converter gets the latest version
                  If annotations IsNot Nothing AndAlso annotations.IsContainerModified(0) Then
                     Dim operation As BusyOperation(Of Boolean) = New BusyOperation(Of Boolean)("Updating the document annotations") With {
      .Begin = Sub()
                  BeginBusyOperation()

                  ShowBusyDialog(False, "Updating the document annotations")
               End Sub,
      .InThread = Function()
                     _documentViewer.PrepareToSave()
                     Return True
                  End Function,
      .[End] = Sub()
                  EndBusyOperation()
               End Sub,
      .ThenInvoke = Sub()
                       SaveDocumentToCache(_documentViewer.Document, False)
                       LoadDocumentFromCache(_documentViewer.Document.DocumentId)
                    End Sub,
      .[Error] = Sub(ex As Exception)
                    Helper.ShowError(Me, ex)
                 End Sub
   }
                     operation.Run(Me)
                  Else
                     SaveDocumentToCache(_documentViewer.Document, False)
                     LoadDocumentFromCache(_documentViewer.Document.DocumentId)
                  End If

               Catch ex As Exception
                  Helper.ShowError(Me, ex)
               End Try
            End If
         End If
      End If
   End Sub
End Class
