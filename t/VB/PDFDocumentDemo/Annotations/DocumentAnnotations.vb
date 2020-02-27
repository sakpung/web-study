' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Pdf
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.BatesStamp
Imports Leadtools.Pdf.Annotations
Imports Leadtools.Annotations.Designers
Imports Leadtools.Annotations.Rendering
Imports Leadtools.Annotations.Automation
Imports Leadtools.Annotations.WinForms
Imports Leadtools.Controls

Namespace PDFDocumentDemo.Annotations
   Public Class DocumentAnnotations
      ' The MainForm
      Private _mainForm As MainForm

      ' The current PDF document
      Private _pdfDocument As PDFDocument
      Public ReadOnly Property PDFDocument() As PDFDocument
         Get
            Return _pdfDocument
         End Get
      End Property

      ' The automation manager, this is a static member that gets initialized once
      Private _automationManager As AnnAutomationManager

      ' The viewer - our automation control
      Private _viewer As AutomationImageViewer

      ' The annotations control, where the toolbar and comments list stays
      Private _annotationsControl As AnnotationsControl

      ' The automation control, responsible for UI
      Private _automation As AnnAutomation
      Public ReadOnly Property Automation() As AnnAutomation
         Get
            Return _automation
         End Get
      End Property

      ' Annotation manager helper (holds the annotations UI resources such as context menus and toolbar)
      Private _automationManagerHelper As AutomationManagerHelper
      Public ReadOnly Property AutomationManagerHelper() As AutomationManagerHelper
         Get
            Return _automationManagerHelper
         End Get
      End Property

      ' Current page number
      Private _currentPageNumber As Integer
      Public ReadOnly Property CurrentPageNumber() As Integer
         Get
            Return _currentPageNumber
         End Get
      End Property

      ' Annotation container for each page
      Private _annotationContainers As AnnContainer()
      Public ReadOnly Property AnnotationContainers() As AnnContainer()
         Get
            Return _annotationContainers
         End Get
      End Property

      Public Sub New(ByVal mainForm As MainForm)
         _mainForm = mainForm
         _viewer = _mainForm.AnnotationsViewer

         _annotationsControl = _mainForm.AnnotationsControl
         _annotationsControl.DocumentAnnotations = Me
         AddHandler _viewer.AutomationDoubleClick, AddressOf _viewer_AutomationDoubleClick

         ' Create custom bitmaps
         'CreateBitmaps();
         _automationManager = AnnAutomationManager.Create(New AnnWinFormsRenderingEngine())
         _automationManager.CreateDefaultObjects()
         _automationManager.EnableToolTip = True
         _automationManagerHelper = New AutomationManagerHelper(_automationManager)

         CreateAutomationObjects()

         ' Hook to the current object ID changed, we want to draw an annotation if text is selected
         AddHandler _automationManager.CurrentObjectIdChanged, AddressOf _automationManager_CurrentObjectIdChanged

         _annotationsControl.CreateToolBar()

         ' Create the context menu for the objects
         CreateObjectContextMenus()

         ' Add the objects to the main menu
         AddToolsToMenu()

         ' No annotation object
         SetNoneObject()

         'Add digital signature object to automation manager
         AddSignatureToAnnManager()

      End Sub

      Private Sub AddSignatureToAnnManager()
         Dim signatureObject As AnnAutomationObject = CreateSignatureAutomationObject()
         _automationManager.Objects.Add(signatureObject)
      End Sub

      Private Sub _automationManager_CurrentObjectIdChanged(ByVal sender As Object, ByVal e As EventArgs)
         If (Not IsEnabled) OrElse (Not IsAnnotationsVisible) OrElse _automation Is Nothing Then
            Return
         End If

         Dim createdObject As AnnObject = Nothing

         ' See if the new designer is one of the review objects
         Dim currentObjectId As Integer = _automationManager.CurrentObjectId
         If currentObjectId = AnnObject.TextHiliteObjectId OrElse currentObjectId = AnnObject.TextStrikeoutObjectId OrElse currentObjectId = AnnObject.TextUnderlineObjectId Then
            ' See if we have object selected
            If _mainForm.IsTextSelected Then
               ' Go back to none object, invoke this because we are already in the
               ' handler for CurrentObjectIdChanged
               _mainForm.BeginInvoke(New MethodInvoker(AddressOf SetNoneObject))
               createdObject = CreatePDFReviewObject(currentObjectId)
            End If
         End If

         _mainForm.BeginInvoke(New UpdatePDFObjectsDelegate(AddressOf UpdatePDFObjects), New Object() {createdObject})
      End Sub

      Private Sub CreateAutomationObjects()
         Dim renderingEngine As AnnRenderingEngine = _automationManager.RenderingEngine

         ' Save the thumb location style
         Dim locationThumbStyle As IAnnThumbStyle = renderingEngine.Renderers(AnnObject.PolylineObjectId).LocationsThumbStyle

         ' Save the AnnRectangleRenderer, we need it for drawing review objects
         Dim rectangleRenderer As IAnnObjectRenderer = _automationManager.RenderingEngine.Renderers(AnnObject.RectangleObjectId)

         ' Clear
         _automationManager.RenderingEngine.Renderers.Clear()

         ' Re-add the rectangle renderer
         _automationManager.RenderingEngine.Renderers.Add(AnnObject.RectangleObjectId, rectangleRenderer)

         ' Create the annotation objects, PDF specific
         Dim lineAutomationObject As AnnAutomationObject = CreateLineAutomationObject()
         Dim pointerAutomationObject As AnnAutomationObject = CreatePointerAutomationObject()
         Dim polylineAutomationObject As AnnAutomationObject = CreatePolylineAutomationObject()
         Dim polygonAutomationObject As AnnAutomationObject = CreatePolygonAutomationObject()
         Dim rectangleAutomationObject As AnnAutomationObject = CreateRectangleAutomationObject()
         Dim ellipseAutomationObject As AnnAutomationObject = CreateEllipseAutomationObject()
         Dim pencilAutomationObject As AnnAutomationObject = CreatePencilAutomationObject()
         Dim textAutomationObject As AnnAutomationObject = CreateTextAutomationObject()
         Dim textPointerAutomationObject As AnnAutomationObject = CreateTextPointerAutomationObject()
         Dim noteAutomationObject As AnnAutomationObject = CreateNoteAutomationObject()
         Dim highlightAutomationObject As AnnAutomationObject = CreateHighlightAutomationObject()
         Dim strikeoutAutomationObject As AnnAutomationObject = CreateStrikeoutAutomationObject()
         Dim underlineAutomationObject As AnnAutomationObject = CreateUnderlineAutomationObject()

         'Remove the default objects
         _automationManager.Objects.Clear()

         ' Add the annotation objects, PDF specific
         _automationManager.Objects.Add(lineAutomationObject)
         _automationManager.Objects.Add(pointerAutomationObject)
         _automationManager.Objects.Add(polylineAutomationObject)
         _automationManager.Objects.Add(polygonAutomationObject)
         _automationManager.Objects.Add(rectangleAutomationObject)
         _automationManager.Objects.Add(ellipseAutomationObject)
         _automationManager.Objects.Add(pencilAutomationObject)
         _automationManager.Objects.Add(textAutomationObject)
         _automationManager.Objects.Add(textPointerAutomationObject)
         _automationManager.Objects.Add(noteAutomationObject)
         _automationManager.Objects.Add(highlightAutomationObject)
         _automationManager.Objects.Add(strikeoutAutomationObject)
         _automationManager.Objects.Add(underlineAutomationObject)

         ' Disable rotation
         For Each automationObject As AnnAutomationObject In _automationManager.Objects
            ' Disable the rotation points
            automationObject.UseRotateThumbs = False
         Next automationObject

         For Each renderer As IAnnObjectRenderer In renderingEngine.Renderers.Values
            renderer.LocationsThumbStyle = locationThumbStyle
         Next renderer
      End Sub

      Private Function CreateLineAutomationObject() As AnnAutomationObject
         Dim automationObj As AnnAutomationObject = New AnnAutomationObject()

         automationObj.Id = AnnObject.LineObjectId
         automationObj.Name = "Line"
         automationObj.DrawDesignerType = GetType(AnnLineDrawDesigner)
         automationObj.EditDesignerType = GetType(AnnPolylineEditDesigner)

         Dim annObj As AnnPolylineObject = New AnnPolylineObject()
         automationObj.ObjectTemplate = annObj
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.LineObjectId)

         ' Set its renderer
         _automationManager.RenderingEngine.Renderers(automationObj.Id) = New AnnPolylineObjectRenderer()

         Return automationObj
      End Function

      Private Function CreatePointerAutomationObject() As AnnAutomationObject
         Dim automationObj As AnnAutomationObject = New AnnAutomationObject()

         automationObj.Id = AnnObject.PointerObjectId
         automationObj.Name = "Line"
         automationObj.DrawDesignerType = GetType(AnnLineDrawDesigner)
         automationObj.EditDesignerType = GetType(AnnPolylineEditDesigner)

         Dim annObj As AnnPointerObject = New AnnPointerObject()
         automationObj.ObjectTemplate = annObj
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.PointerObjectId)

         ' Set its renderer
         _automationManager.RenderingEngine.Renderers(automationObj.Id) = New AnnPointerObjectRenderer()

         Return automationObj
      End Function

      Private Function CreatePolylineAutomationObject() As AnnAutomationObject
         Dim automationObj As AnnAutomationObject = New AnnAutomationObject()

         automationObj.Id = AnnObject.PolylineObjectId
         automationObj.Name = "Polyline"
         automationObj.DrawDesignerType = GetType(AnnPolylineDrawDesigner)
         automationObj.EditDesignerType = GetType(AnnPolylineEditDesigner)

         Dim annObj As AnnPolylineObject = New AnnPolylineObject()
         automationObj.ObjectTemplate = annObj
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.PolylineObjectId)

         ' Set its renderer
         _automationManager.RenderingEngine.Renderers(automationObj.Id) = New AnnPolylineObjectRenderer()

         Return automationObj
      End Function

      Private Function CreatePolygonAutomationObject() As AnnAutomationObject
         Dim automationObj As AnnAutomationObject = New AnnAutomationObject()

         automationObj.Id = AnnObject.PolygonObjectId
         automationObj.Name = "Polygon"
         automationObj.DrawDesignerType = GetType(AnnPolylineDrawDesigner)
         automationObj.EditDesignerType = GetType(AnnPolylineEditDesigner)

         Dim annObj As AnnPolylineObject = New AnnPolylineObject()
         annObj.IsClosed = True
         automationObj.ObjectTemplate = annObj
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.PolygonObjectId)

         ' Set its renderer
         _automationManager.RenderingEngine.Renderers(automationObj.Id) = New AnnPolylineObjectRenderer()

         Return automationObj
      End Function

      Private Function CreatePencilAutomationObject() As AnnAutomationObject
         Dim automationObj As AnnAutomationObject = New AnnAutomationObject()

         automationObj.Id = AnnObject.FreehandObjectId
         automationObj.Name = "Pencil"
         automationObj.DrawDesignerType = GetType(AnnFreehandDrawDesigner)
         automationObj.EditDesignerType = GetType(AnnPolylineEditDesigner)

         Dim annObj As AnnPolylineObject = New AnnPolylineObject()
         automationObj.ObjectTemplate = annObj
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.FreehandObjectId)

         ' Set its renderer
         _automationManager.RenderingEngine.Renderers(automationObj.Id) = New AnnPolylineObjectRenderer()

         Return automationObj
      End Function

      Private Function CreateRectangleAutomationObject() As AnnAutomationObject
         Dim automationObj As AnnAutomationObject = New AnnAutomationObject()

         automationObj.Id = AnnObject.RectangleObjectId
         automationObj.Name = "Rectangle"
         automationObj.DrawDesignerType = GetType(AnnRectangleDrawDesigner)
         automationObj.EditDesignerType = GetType(AnnRectangleEditDesigner)

         Dim annObj As AnnRectangleObject = New AnnRectangleObject()
         automationObj.ObjectTemplate = annObj
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.RectangleObjectId)

         ' Set its renderer
         _automationManager.RenderingEngine.Renderers(automationObj.Id) = New AnnRectangleObjectRenderer()

         Return automationObj
      End Function

      Private Function CreateEllipseAutomationObject() As AnnAutomationObject
         Dim automationObj As AnnAutomationObject = New AnnAutomationObject()

         automationObj.Id = AnnObject.EllipseObjectId
         automationObj.Name = "Ellipse"
         automationObj.DrawDesignerType = GetType(AnnRectangleDrawDesigner)
         automationObj.EditDesignerType = GetType(AnnRectangleEditDesigner)

         Dim annObj As AnnEllipseObject = New AnnEllipseObject()
         automationObj.ObjectTemplate = annObj
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.EllipseObjectId)

         ' Set its renderer
         _automationManager.RenderingEngine.Renderers(automationObj.Id) = New AnnEllipseObjectRenderer()

         Return automationObj
      End Function

      Private Function CreateTextAutomationObject() As AnnAutomationObject
         Dim automationObj As AnnAutomationObject = New AnnAutomationObject()

         automationObj.Id = AnnObject.TextObjectId
         automationObj.Name = "Text"
         automationObj.DrawDesignerType = GetType(AnnRectangleDrawDesigner)
         automationObj.EditDesignerType = GetType(AnnTextEditDesigner)

         Dim annObj As AnnTextObject = New AnnTextObject()
         automationObj.ObjectTemplate = annObj
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.TextObjectId)

         ' Set its renderer
         _automationManager.RenderingEngine.Renderers(automationObj.Id) = New AnnTextObjectRenderer()

         Return automationObj
      End Function

      Private Function CreateTextPointerAutomationObject() As AnnAutomationObject
         Dim automationObj As AnnAutomationObject = New AnnAutomationObject()

         automationObj.Id = AnnObject.TextPointerObjectId
         automationObj.Name = "TextPointer"
         automationObj.DrawDesignerType = GetType(AnnTextPointerDrawDesigner)
         automationObj.EditDesignerType = GetType(AnnTextPointerEditDesigner)

         Dim annObj As AnnTextPointerObject = New AnnTextPointerObject()
         annObj.UseKnee = True
         automationObj.ObjectTemplate = annObj
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.TextPointerObjectId)

         ' Set its renderer
         _automationManager.RenderingEngine.Renderers(automationObj.Id) = New AnnTextPointerObjectRenderer()

         Return automationObj
      End Function

      Private Function CreateNoteAutomationObject() As AnnAutomationObject
         Dim automationObj As AnnAutomationObject = New AnnAutomationObject()

         automationObj.Id = AnnObject.StickyNoteObjectId
         automationObj.Name = "Sticky Note"
         automationObj.DrawDesignerType = GetType(AnnStickyNoteDrawDesigner)
         automationObj.EditDesignerType = GetType(AnnEditDesigner)

         Dim annObj As AnnStickyNoteObject = New AnnStickyNoteObject()
         automationObj.ObjectTemplate = annObj
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.NoteObjectId)

         ' Set its renderer
         _automationManager.RenderingEngine.Renderers(automationObj.Id) = New AnnStickyNoteObjectRenderer()

         Return automationObj
      End Function

      Private Function CreateHighlightAutomationObject() As AnnAutomationObject
         Dim automationObj As AnnAutomationObject = New AnnAutomationObject()

         automationObj.Id = AnnObject.TextHiliteObjectId
         automationObj.Name = "Highlight Text"
         automationObj.DrawDesignerType = GetType(AnnTextReviewDrawDesigner)
         automationObj.EditDesignerType = GetType(AnnTextReviewEditDesigner)

         Dim annObj As AnnTextHiliteObject = New AnnTextHiliteObject()
         annObj.Fill = AnnSolidColorBrush.Create("yellow")
         automationObj.ObjectTemplate = annObj
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.TextHiliteObjectId)

         ' Set its renderer
         _automationManager.RenderingEngine.Renderers(automationObj.Id) = New AnnTextHiliteObjectRenderer()

         Return automationObj
      End Function

      Private Function CreateStrikeoutAutomationObject() As AnnAutomationObject
         Dim automationObj As AnnAutomationObject = New AnnAutomationObject()

         automationObj.Id = AnnObject.TextStrikeoutObjectId
         automationObj.Name = "Strikeout Text"
         automationObj.DrawDesignerType = GetType(AnnTextReviewDrawDesigner)
         automationObj.EditDesignerType = GetType(AnnTextReviewEditDesigner)

         Dim annObj As AnnTextStrikeoutObject = New AnnTextStrikeoutObject()
         automationObj.ObjectTemplate = annObj
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.TextStrikeoutObjectId)

         ' Set its renderer
         _automationManager.RenderingEngine.Renderers(automationObj.Id) = New AnnTextStrikeoutObjectRenderer()

         Return automationObj
      End Function

      Private Function CreateUnderlineAutomationObject() As AnnAutomationObject
         Dim automationObj As AnnAutomationObject = New AnnAutomationObject()

         automationObj.Id = AnnObject.TextUnderlineObjectId
         automationObj.Name = "Underline Text"
         automationObj.DrawDesignerType = GetType(AnnTextReviewDrawDesigner)
         automationObj.EditDesignerType = GetType(AnnTextReviewEditDesigner)

         Dim annObj As AnnTextUnderlineObject = New AnnTextUnderlineObject()
         automationObj.ObjectTemplate = annObj
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.TextUnderlineObjectId)

         ' Set its renderer
         _automationManager.RenderingEngine.Renderers(automationObj.Id) = New AnnTextUnderlineObjectRenderer()

         Return automationObj
      End Function

      Private Function CreateSignatureAutomationObject() As AnnAutomationObject
         Dim automationObj As New AnnAutomationObject()

         automationObj.Id = AnnSignatureObject.SignatureObjectID
         automationObj.Name = "Signature"
         automationObj.DrawDesignerType = GetType(AnnRectangleDrawDesigner)
         automationObj.EditDesignerType = GetType(AnnRectangleEditDesigner)

         Dim annObj As New AnnSignatureObject()

         automationObj.ObjectTemplate = annObj
         automationObj.ToolBarImage = Nothing

         ' Set its renderer
         _automationManager.RenderingEngine.Renderers(automationObj.Id) = New AnnSignatureObjectRenderer()

         Return automationObj
      End Function

      Private Sub _automation_OnShowObjectPropertiesFunc(ByVal sender As Object, ByVal e As EventArgs)
         Dim automation__1 As AnnAutomation = Automation
         'sender as AnnAutomation;
         automation__1.ShowObjectProperties()
      End Sub


      Private Sub CreateObjectContextMenus()
         ' Create the context menus to use with the objects
         Dim cm As ContextMenu = New ContextMenu()
         cm.MenuItems.Add(New MenuItem("&Delete", AddressOf _automation_DeleteSelectedObject))
         cm.MenuItems.Add(New MenuItem("&Properties...", AddressOf _automation_OnShowObjectPropertiesFunc))

         For Each automationObj As AnnAutomationObject In _automationManager.Objects
            If (automationObj IsNot Nothing) AndAlso (automationObj.Id <> AnnObject.None) AndAlso (automationObj.ContextMenu IsNot Nothing) Then
               automationObj.ContextMenu = cm
            End If
         Next automationObj
      End Sub

      Private Function GetAutomationObjectToolbarImage(ByVal automationObjectID As Integer) As Object
         Dim toolBarImage As Object = Nothing

         Dim automationObject As AnnAutomationObject = _automationManager.FindObjectById(automationObjectID)
         If Not automationObject Is Nothing Then
            toolBarImage = automationObject.ToolBarImage
         End If

         Return toolBarImage
      End Function

      Private Sub AddToolsToMenu()
         Dim annotationsMenuItem As ToolStripMenuItem = _mainForm.AnnotationsMenuItem

         Dim eventHandler As EventHandler = New EventHandler(AddressOf annotationObjectMenuItem_Click)

         For Each automationObj As AnnAutomationObject In _automationManager.Objects
            ' Check if the object has a toolbar button
            If automationObj.ToolBarImage IsNot Nothing AndAlso automationObj.Id <> AnnObject.None Then
               Dim menuItem As ToolStripMenuItem = New ToolStripMenuItem()
               menuItem.Text = automationObj.Name
               menuItem.ToolTipText = automationObj.Name

               menuItem.Image = CType(automationObj.ToolBarImage, Image)

               ' Set the tag to the object ID, makes it easier to track
               menuItem.Tag = automationObj.Id
               AddHandler menuItem.Click, eventHandler

               annotationsMenuItem.DropDownItems.Add(menuItem)
            End If
         Next automationObj
      End Sub

      Private Sub annotationObjectMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
         Dim menuItem As ToolStripMenuItem = CType(IIf(TypeOf sender Is ToolStripMenuItem, sender, Nothing), ToolStripMenuItem)
         Dim objectId As Integer = CInt(menuItem.Tag)
         _automationManager.CurrentObjectId = objectId
      End Sub

      Private Sub SetNoneObject()
         _automationManager.CurrentObjectId = AnnObject.None
      End Sub

      Private Sub _automation_DeleteSelectedObject(ByVal sender As Object, ByVal e As EventArgs)
         DeleteSelectedObject()
      End Sub

      Public Sub DeleteSelectedObject()
         If Not _automation Is Nothing AndAlso _automation.CanDeleteObjects Then
            _automation.DeleteSelectedObjects()

            ' Re-populate the comments list
            _annotationsControl.Populate()
         End If
      End Sub

      ' Viewer events
      Private Sub _viewer_AutomationDoubleClick(ByVal sender As Object, ByVal e As AnnPointerEventArgs)
         ' User double clicks the viewer, check if any object, if so "run" it
         If (Not IsEnabled) OrElse (Not IsAnnotationsVisible) OrElse _automation Is Nothing OrElse e.Button <> AnnMouseButton.Left Then
            Return
         End If

         ' Check if we have an object selected
         Dim annObj As AnnObject = _automation.CurrentEditObject
         If annObj IsNot Nothing AndAlso annObj.Id <> AnnObject.TextObjectId AndAlso annObj.Id <> AnnObject.None Then
            ShowObjectContent(annObj)
         End If
      End Sub

      Public Sub InteractiveModeChanged(ByVal interactiveMode As ViewerControl.ViewerControlInteractiveMode)
         If interactiveMode = ViewerControl.ViewerControlInteractiveMode.SelectMode Then
            EnableUI(True)
         Else
            ' Cancel any current UI annotations operations
            If Not _automation Is Nothing Then
               _automation.Cancel()
               _automation.Invalidate(LeadRectD.Empty)

               SetNoneObject()

               EnableUI(False)
            End If
         End If
      End Sub

      ' Automation events
      Private Sub _automation_OnShowContextMenu(ByVal sender As Object, ByVal e As AnnAutomationEventArgs)
         If Not e Is Nothing AndAlso Not e.Object Is Nothing Then
            _viewer.AutomationInvalidate(LeadRectD.Empty)
            Dim annAutomationObject As AnnAutomationObject = CType(IIf(TypeOf e.Object Is AnnAutomationObject, e.Object, Nothing), AnnAutomationObject)
            If annAutomationObject IsNot Nothing AndAlso annAutomationObject.Id <> AnnObject.None Then
               Dim menu As ContextMenu = CType(IIf(TypeOf annAutomationObject.ContextMenu Is ContextMenu, annAutomationObject.ContextMenu, Nothing), ContextMenu)
               If Not menu Is Nothing Then
                  menu.Show(_viewer, _viewer.PointToClient(Cursor.Position))
               End If
            End If
         End If
      End Sub

      Private Sub _automation_EditText(ByVal sender As Object, ByVal e As AnnEditTextEventArgs)
         Dim text As TextBox = New TextBox()
         Dim rc As Rectangle = New Rectangle(CInt(e.Bounds.Left), CInt(e.Bounds.Top), CInt(e.Bounds.Width), CInt(e.Bounds.Height))
         rc.Inflate(12, 12)
         text.Location = rc.Location
         text.Size = rc.Size
         text.AutoSize = False
         text.Tag = e.TextObject
         text.Text = e.TextObject.Text
         text.ForeColor = Color.FromName((CType(IIf(TypeOf e.TextObject.TextForeground Is AnnSolidColorBrush, e.TextObject.TextForeground, Nothing), AnnSolidColorBrush)).Color)
         text.AcceptsReturn = True
         text.Multiline = True
         text.Font = AnnWinFormsRenderingEngine.ToFont(e.TextObject.Font)
         text.WordWrap = False
         text.Tag = e.TextObject

         AddHandler text.LostFocus, AddressOf text_LostFocus

         Dim automationControl As Control = CType(IIf(TypeOf _automation.AutomationControl Is Control, _automation.AutomationControl, Nothing), Control)
         automationControl.Controls.Add(text)
         text.Focus()
      End Sub

      Private _editDesigner As AnnEditDesigner = Nothing

      Private Sub _automation_CurrentDesignerChanged(ByVal sender As Object, ByVal e As EventArgs)
         ' If we have an edit designer hooked, unhook it
         If Not _editDesigner Is Nothing Then
            '_editDesigner.Edit -= new EventHandler<AnnEditDesignerEventArgs>(editDesigner_Edit);
            _editDesigner = Nothing
         End If

         ' Monitor when a draw designer has finished, so we can 
         ' obtain the newly added object
         Dim drawDesigner As AnnDrawDesigner = CType(IIf(TypeOf _automation.CurrentDesigner Is AnnDrawDesigner, _automation.CurrentDesigner, Nothing), AnnDrawDesigner)
         If Not drawDesigner Is Nothing Then
            ' Hook to its draw event
            AddHandler drawDesigner.Draw, AddressOf drawDesigner_Draw

            ' If this is review draw designer, set the object ID, we will use it when the designer ends
            Dim reviewDrawDesigner As AnnTextReviewDrawDesigner = CType(IIf(TypeOf drawDesigner Is AnnTextReviewDrawDesigner, drawDesigner, Nothing), AnnTextReviewDrawDesigner)
            'if (reviewDrawDesigner != null)
            '   reviewDrawDesigner.PDFObjectId = _automationManager.CurrentObjectId;
         End If
         'else
         '{
         '   // Monitor when an edit designer has finished, so we can
         '   // update the corresponding PDF object
         '   AnnEditDesigner editDesigner = _automation.CurrentDesigner as AnnEditDesigner;
         '   if (editDesigner != null)
         '   {
         '      // Hook to its edit event
         '      _editDesigner = editDesigner;
         '      _hasEditDesignerWorked = false;
         '      //_editDesigner.Edit += new EventHandler<AnnEditDesignerEventArgs>(editDesigner_Edit);
         '   }
         '}

         ' Let the annotation control know
         '_annotationsControl.UpdateSelectedObject()

         EndTextEditor()
      End Sub

      Private Sub drawDesigner_Draw(ByVal sender As Object, ByVal e As AnnDrawDesignerEventArgs)
         If e.OperationStatus = AnnDesignerOperationStatus.End OrElse e.OperationStatus = AnnDesignerOperationStatus.Canceled Then
            ' Object has finished drawing, unhook from the event
            Dim drawDesigner As AnnDrawDesigner = CType(IIf(TypeOf sender Is AnnDrawDesigner, sender, Nothing), AnnDrawDesigner)
            RemoveHandler drawDesigner.Draw, AddressOf drawDesigner_Draw

            ' If the object has been created successfully and is not the select object, then create the
            ' PDF annotation object that corresponds to the ann object
            If e.OperationStatus = AnnDesignerOperationStatus.End AndAlso (Not e.Cancel) AndAlso e.Object.Id <> AnnObject.SelectObjectId Then
               ' Check if this a review draw designer
               Dim reviewDrawDesigner As AnnTextReviewDrawDesigner = CType(IIf(TypeOf sender Is AnnTextReviewDrawDesigner, sender, Nothing), AnnTextReviewDrawDesigner)

               Dim createdObject As AnnObject = Nothing

               If Not reviewDrawDesigner Is Nothing Then
                  e.Cancel = True

                  ' Highlight the text, get the rectangle object bounds.
                  Dim rectObject As AnnTextReviewObject = CType(IIf(TypeOf e.Object Is AnnTextReviewObject, e.Object, Nothing), AnnTextReviewObject)
                  Dim objectBounds As LeadRectD = rectObject.GetRectangles()(0)

                  ' Convert to image coordinates, so first from container to screen then use the viewer
                  objectBounds = _automation.Container.Mapper.RectFromContainerCoordinates(objectBounds, rectObject.FixedStateOperations)
                  Dim rect As LeadRect = New LeadRect(CInt(objectBounds.X), CInt(objectBounds.Y), CInt(objectBounds.Width), CInt(objectBounds.Height))
                  rect = _viewer.ConvertRect(Nothing, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, rect)

                  Dim bounds As LeadRect = LeadRect.Create(rect.X, rect.Y, rect.Width, rect.Height)

                  _mainForm.HighlightText(bounds)

                  ' Create a PDF review object from the highlighted text, the object ID is what we set when the designer started
                  createdObject = CreatePDFReviewObject(reviewDrawDesigner.TargetObject.Id)
               End If

               _mainForm.BeginInvoke(New UpdatePDFObjectsDelegate(AddressOf UpdatePDFObjects), New Object() {createdObject})
            End If
         End If
      End Sub

      Private Delegate Sub UpdatePDFObjectsDelegate(ByVal createdObj As AnnObject)
      Private Sub UpdatePDFObjects(ByVal createdObj As AnnObject)
         If Not createdObj Is Nothing Then
            _mainForm.ClearTextSelection()
            _automation.SelectObject(createdObj)
         End If

         _annotationsControl.Populate()
         '_annotationsControl.UpdateSelectedObject()
      End Sub

      Private Sub text_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
         EndTextEditor()
      End Sub

      Private Sub AutomationControl_AutomationTransformChanged(ByVal sender As Object, ByVal e As EventArgs)
         EndTextEditor()
      End Sub

      Private Sub EndTextEditor()
         Dim automationControl As Control = CType(IIf(TypeOf _automation.AutomationControl Is Control, _automation.AutomationControl, Nothing), Control)

         For Each control As Control In automationControl.Controls
            If TypeOf control Is TextBox Then
               Dim textObject As AnnTextObject = CType(IIf(TypeOf control.Tag Is AnnTextObject, control.Tag, Nothing), AnnTextObject)
               If Not textObject Is Nothing Then
                  textObject.Text = control.Text
               End If

               RemoveHandler control.LostFocus, AddressOf text_LostFocus
               automationControl.Controls.Remove(control)
            End If
         Next control
      End Sub

      Public ReadOnly Property IsEnabled() As Boolean
         Get
            Return _automationManagerHelper.ToolBar.Enabled
         End Get
      End Property

      Private _isAnnotationsVisible As Boolean = True
      Public Property IsAnnotationsVisible() As Boolean
         Get
            Return _isAnnotationsVisible
         End Get
         Set(value As Boolean)
            _isAnnotationsVisible = value
            _annotationContainers(_automation.ActiveContainer.PageNumber - 1).IsVisible = _isAnnotationsVisible
            EnableUI(value)
         End Set
      End Property

      Private Sub EnableUI(ByVal enable As Boolean)
         If Not _automationManagerHelper Is Nothing Then
            _automationManagerHelper.ToolBar.Enabled = enable
            _annotationsControl.Enabled = enable
         End If
      End Sub

      Public Shared Sub SetRasterCodecsOptions(ByVal pdfDocument_Renamed As PDFDocument, ByVal rasterCodecs As RasterCodecs, ByVal pageNumber As Integer)
         ' If the PDF page has annotations, then do not draw them on the image
         Dim pdfPage As PDFDocumentPage = pdfDocument_Renamed.Pages(pageNumber - 1)
         Dim annotations As IList(Of PDFAnnotation) = pdfPage.Annotations
         If Not annotations Is Nothing AndAlso annotations.Count > 0 Then
            rasterCodecs.Options.Pdf.Load.HideAnnotations = True
         Else
            rasterCodecs.Options.Pdf.Load.HideAnnotations = False
         End If
      End Sub

      Private Function CreatePDFReviewObject(objectId As Integer) As AnnObject
         ' Get the selected words
         Dim selectedText As Dictionary(Of Integer, MyWord()) = _mainForm.SelectedText

         Dim words As MyWord() = Nothing
         If selectedText IsNot Nothing AndAlso selectedText.ContainsKey(_currentPageNumber) Then
            words = selectedText(_currentPageNumber)
         End If

         If words Is Nothing OrElse words.Length = 0 Then
            Return Nothing
         End If

         ' Create the new PDF object
         Dim pdfObject As AnnObject = Nothing

         Select Case objectId
            Case AnnObject.TextStrikeoutObjectId
               pdfObject = New AnnTextStrikeoutObject()
               Exit Select

            Case AnnObject.TextUnderlineObjectId
               pdfObject = New AnnTextUnderlineObject()
               Exit Select

            Case Else
               pdfObject = New AnnTextHiliteObject()
               Exit Select
         End Select

         ' Set the points
         Dim annObject__1 As AnnTextReviewObject = TryCast(pdfObject, AnnTextReviewObject)

         annObject__1.Points.Clear()
         Dim currentBounds As LeadRect = LeadRect.Empty

         Dim wordIndex As Integer = 0
         Dim wordCount As Integer = words.Length

         While wordIndex < wordCount
            Dim bounds As LeadRect = LeadRect.Empty

            Dim more As Boolean = True
            While more AndAlso wordIndex < wordCount
               Dim word As MyWord = words(wordIndex)

               If bounds.IsEmpty Then
                  bounds = word.Bounds
               Else
                  bounds = LeadRect.Union(bounds, word.Bounds)
               End If

               ' Check if need more rects
               more = wordIndex < wordCount AndAlso Not word.IsEndOfLine
               wordIndex += 1
            End While

            ' Add current bounds

            ' Convert to viewer coordinates (physical)
            Dim rect As New LeadRect(bounds.X, bounds.Y, bounds.Width, bounds.Height)
            rect = _viewer.ConvertRect(Nothing, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, rect)

            ' Convert to annotation
            Dim segmentBounds As LeadRectD = LeadRectD.Create(rect.X, rect.Y, rect.Width, rect.Height)
            segmentBounds = _automation.Container.Mapper.RectToContainerCoordinates(segmentBounds)

            'Add the rectangle of the segment to the highlight object
            annObject__1.AddRectangle(segmentBounds)
            UpdateObjectsMetadata(New AnnObjectCollection(New AnnObject() {annObject__1}))
         End While

         ' Add the object
         _automation.Container.Children.Add(annObject__1)

         Return annObject__1
      End Function

      Public Sub SetDocument(ByVal document As PDFDocument)
         If Not _automation Is Nothing Then
            ' Delete current automation
            _automation.Detach()
            _automationManager.Automations.Remove(_automation)
            RemoveHandler _automation.AfterObjectChanged, AddressOf _automation_AfterObjectChanged
            RemoveHandler _automation.OnShowObjectProperties, AddressOf _automation_OnShowObjectProperties
            RemoveHandler _automation.OnShowContextMenu, AddressOf _automation_OnShowContextMenu
            RemoveHandler _automation.EditText, AddressOf _automation_EditText
            RemoveHandler _automation.CurrentDesignerChanged, AddressOf _automation_CurrentDesignerChanged
            RemoveHandler _automation.ActiveContainerChanged, AddressOf _automation_ActiveContainerChanged
            RemoveHandler _automation.AutomationControl.AutomationTransformChanged, AddressOf AutomationControl_AutomationTransformChanged
            RemoveHandler _automation.Edit, AddressOf _automation_Edit
            _automation = Nothing
         End If

         _pdfDocument = document
         _currentPageNumber = -1

         If Not _pdfDocument Is Nothing Then
            _automationManager.EnableToolTip = True
            ' Create the automation object (for UI)
            _automation = New AnnAutomation(_automationManager, _viewer)
            AddHandler _automation.AfterObjectChanged, AddressOf _automation_AfterObjectChanged
            AddHandler _automation.OnShowObjectProperties, AddressOf _automation_OnShowObjectProperties
            AddHandler _automation.OnShowContextMenu, AddressOf _automation_OnShowContextMenu
            AddHandler _automation.EditText, AddressOf _automation_EditText
            AddHandler _automation.CurrentDesignerChanged, AddressOf _automation_CurrentDesignerChanged
            AddHandler _automation.ActiveContainerChanged, AddressOf _automation_ActiveContainerChanged
            AddHandler _automation.AutomationControl.AutomationTransformChanged, AddressOf AutomationControl_AutomationTransformChanged
            AddHandler _automation.Edit, AddressOf _automation_Edit
            AddHandler _automation.ToolTip, AddressOf _automation_ToolTip

            ' Set it as active
            _automation.Active = True

            _automation.Containers.Clear()

            ' Create and populate the annotation containers for each page

            ' PDF page coordinates is in 1/72 of an inch, annotation coordinates is in 1/720,

            Dim pageCount As Integer = document.Pages.Count
            _annotationContainers = New AnnContainer(pageCount - 1) {}

            Dim pageNumber As Integer = 1
            Do While pageNumber <= pageCount
               ' Add the PDF annotations objects
               Dim pdfPage As PDFDocumentPage = _pdfDocument.Pages(pageNumber - 1)

               Dim annContainer As AnnContainer = New AnnContainer()

               ' PDF page coordinates is in 1/72 of an inch, annotation coordinates is in 1/720, 
               annContainer.Size = LeadSizeD.Create(pdfPage.Width * 10, pdfPage.Height * 10)

               annContainer.PageNumber = pageNumber

               If pdfPage.Annotations IsNot Nothing AndAlso pdfPage.Annotations.Count > 0 Then
                  AnnPDFConvertor.ConvertFromPDF(pdfPage.Annotations, annContainer, LeadSizeD.Create(pdfPage.Width, pdfPage.Height))
               End If

               ' if we have Signatures add them to the active container.
               If pdfPage.Signatures IsNot Nothing AndAlso pdfPage.Signatures.Count > 0 Then
                  AddSignaturesObjectsToContainer(pdfPage.Signatures, annContainer, LeadSizeD.Create(pdfPage.Width, pdfPage.Height))
               End If

               _annotationContainers(pageNumber - 1) = annContainer
               _automation.Containers.Add(annContainer)
               pageNumber += 1
            Loop

            _annotationsControl.Automation = _automation
            _annotationsControl.Populate()
         End If

         ' Enable PDF Mode
         _automationManager.UsePDFMode = True

      End Sub


      Private Sub _automation_ToolTip(sender As Object, e As AnnToolTipEventArgs)
         If e.AnnotationObject IsNot Nothing AndAlso TypeOf e.AnnotationObject Is AnnSignatureObject Then
            'Draw border around the AnnSignatureObject
            TryCast(e.AnnotationObject, AnnSignatureObject).DrawBorder = True
            _automation.Invalidate(LeadRectD.Empty)
         Else
            For Each annObject As AnnObject In _automation.Container.Children
               'Remove the border from AnnSignatureObject
               If TypeOf annObject Is AnnSignatureObject Then
                  TryCast(annObject, AnnSignatureObject).DrawBorder = False
               End If
            Next

            _automation.Invalidate(LeadRectD.Empty)
         End If
      End Sub

      Private Sub _automation_Edit(sender As Object, e As AnnEditDesignerEventArgs)
         ' if we edit "AnnSignatureObject" check the "AnnEditDesignerOperation" if it is None. If ok, open "SignatureValidationStatusDialog".
         Dim signatureObject As AnnSignatureObject = TryCast(e.[Object], AnnSignatureObject)

         If signatureObject IsNot Nothing AndAlso e.Operation = AnnEditDesignerOperation.None Then
            Using validationStatusDialog As New SignatureValidationStatusDialog(signatureObject.Signature)
               validationStatusDialog.ShowDialog()
               signatureObject.IsSelected = False
            End Using
         End If
      End Sub

      Private Sub _automation_ActiveContainerChanged(ByVal sender As Object, ByVal e As EventArgs)
         If Not _automation.ActiveContainer Is Nothing Then
            Dim pageNumber As Integer = _automation.Containers.IndexOf(_automation.ActiveContainer) + 1

            If pageNumber > 0 AndAlso pageNumber <> CurrentPageNumber AndAlso CurrentPageNumber <> -1 Then
               _mainForm.GotoPage(pageNumber, True)
            End If
         End If
      End Sub

      Private Sub _automation_OnShowObjectProperties(ByVal sender As Object, ByVal e As AnnAutomationEventArgs)
         If Not _automation Is Nothing AndAlso _automation.CanShowObjectProperties Then
            ' Get the current selected object
            Dim annObject As AnnObject = _automation.CurrentEditObject
            Debug.Assert(Not annObject Is Nothing)

            Dim dlg As AutomationUpdateObjectDialog = New AutomationUpdateObjectDialog()
            Try
               dlg.InitialPage = AutomationUpdateObjectDialogPage.Properties

               If _automation.CurrentEditObject IsNot Nothing AndAlso (_automation.CurrentEditObject.Id = annObject.StickyNoteObjectId OrElse TypeOf _automation.CurrentEditObject Is AnnTextObject) Then
                  ' if text object, we cannot do that. Ignore, the EditText will fire
                  dlg.SetPageVisible(AutomationUpdateObjectDialogPage.Content, False)
               End If

               dlg.Automation = _automation
               dlg.ShowDialog(_mainForm)
            Finally
               CType(dlg, IDisposable).Dispose()
            End Try
         End If
      End Sub

      Private Sub _automation_AfterObjectChanged(ByVal sender As Object, ByVal e As AnnAfterObjectChangedEventArgs)
         If e.Objects Is Nothing OrElse e.Objects.Count = 0 Then
            Return
         End If

         Select Case e.ChangeType
            Case AnnObjectChangedType.DesignerEdit
               Dim editDesigner As AnnEditDesigner = CType(IIf(TypeOf _automation.CurrentDesigner Is AnnEditDesigner, _automation.CurrentDesigner, Nothing), AnnEditDesigner)
               If Not editDesigner Is Nothing AndAlso editDesigner.IsModified Then
                  UpdateObjectsMetadata(e.Objects)
                  editDesigner.IsModified = False
               End If

            Case AnnObjectChangedType.None

            Case Else
               UpdateObjectsMetadata(e.Objects)
         End Select
      End Sub


      Private Sub AddSignaturesObjectsToContainer(signatures As IList(Of PDFSignature), container As AnnContainer, pdfPageSize As LeadSizeD)
         If signatures.Count = 0 OrElse container Is Nothing Then
            Return
         End If

         For Each signature As PDFSignature In signatures
            Dim signatureObject As New AnnSignatureObject()

            signatureObject.Signature = signature

            signatureObject.Rect = FromPDFRect(signature.Bounds, pdfPageSize)

            container.Children.Add(signatureObject)
         Next
      End Sub

      Public Function FromPDFRect(bounds As PDFRect, pageSize As LeadSizeD) As LeadRectD
         'Use "AnnPDFConvertor.ConvertFromPDF" to convert signature object bounds from PDFCoordinates to AnnotationCoordinates.
         Dim annContainer As New AnnContainer()
         annContainer.PageNumber = 1

         ' PDF is in bottom-left mode , we need to convert it in top-left mode
         bounds.Bottom = pageSize.Height - bounds.Bottom
         bounds.Top = pageSize.Height - bounds.Top

         Dim annotations As IList(Of PDFAnnotation) = New List(Of PDFAnnotation)()

         Dim pdfRectangleAnnotation As New PDFRectangleAnnotation()
         pdfRectangleAnnotation.PageNumber = 1
         pdfRectangleAnnotation.Bounds = bounds

         annotations.Add(pdfRectangleAnnotation)

         AnnPDFConvertor.ConvertFromPDF(annotations, annContainer, LeadSizeD.Create(pageSize.Width, pageSize.Height))

         Return annContainer.Children(0).Bounds
      End Function

      Private Sub UpdateObjectsMetadata(ByVal annObjects As AnnObjectCollection)
         If annObjects Is Nothing OrElse annObjects.Count = 0 Then
            Return
         End If

         Dim now As String = AnnObject.DateToString(DateTime.Now)
         Dim keys As String() = {AnnObject.AuthorMetadataKey, AnnObject.CreatedMetadataKey, AnnObject.ModifiedMetadataKey}
         Dim values As String() = {Environment.UserName, now, now}

         For Each annObject As AnnObject In annObjects
            UpdateObjectMetadata(annObject, keys, values)
         Next annObject
      End Sub

      Private Sub UpdateObjectMetadata(ByVal annObject As AnnObject, ByVal keys As String(), ByVal values As String())
         Dim selectionObject As AnnSelectionObject = CType(IIf(TypeOf annObject Is AnnSelectionObject, annObject, Nothing), AnnSelectionObject)
         If Not selectionObject Is Nothing Then
            For Each child As AnnObject In selectionObject.SelectedObjects
               UpdateObjectMetadata(child, keys, values)
            Next child
         Else
            Dim i As Integer = 0
            Do While i < keys.Length
               annObject.Metadata(keys(i)) = values(i)
               i += 1
            Loop
         End If
      End Sub

      Public Sub SaveDocument(fileName As String)
         ' Get a list of all the annotations in this document

         Dim fileAnnotations As New List(Of PDFAnnotation)()

         ' Loop through the containers
         For Each container As AnnContainer In _annotationContainers
            Dim pageAnnotations As New List(Of PDFAnnotation)()
            AnnPDFConvertor.ConvertToPDF(container, pageAnnotations, _pdfDocument.Pages(0).Height)
            fileAnnotations.AddRange(pageAnnotations)
         Next

         ' Make the file writeable if exists
         If File.Exists(fileName) Then
            MakeWriteable(fileName)
         End If

         ' Load the original file in a PDFFile object
         Dim file__1 As New PDFFile(_pdfDocument.FileName, _pdfDocument.Password)
         file__1.DocumentProperties = _pdfDocument.DocumentProperties

         ' Write it to the new file
         file__1.WriteAnnotations(fileAnnotations, fileName)
      End Sub

      Private Shared Sub MakeWriteable(ByVal fileName As String)
         ' Remove read-only if there
         Dim attr As FileAttributes = File.GetAttributes(fileName)
         attr = attr And Not FileAttributes.ReadOnly
         File.SetAttributes(fileName, attr)
      End Sub

      Public Sub SetCurrentPageNumber(ByVal pageNumber As Integer)
         If _currentPageNumber = pageNumber Then
            Return
         End If

         For Each container As AnnContainer In _annotationContainers
            container.IsVisible = False
         Next container

         _currentPageNumber = pageNumber

         If _currentPageNumber <> -1 Then
            ' Set the container for the page
            Dim container As AnnContainer = _annotationContainers(_currentPageNumber - 1)
            '_automation.AttachContainer(container, null);
            If (Not container.IsVisible) Then
               container.IsVisible = True
            End If
            _automation.ActiveContainer = container
         End If
      End Sub

      Public Sub SelectNextPreviousObject(ByVal [next] As Boolean)
         Dim container As AnnContainer = _automation.Container

         ' Get the current selected object, or the first object in the container
         Dim currentSelectedObject As AnnObject = Nothing

         If container.SelectionObject.SelectedObjects.Count > 0 Then
            currentSelectedObject = container.SelectionObject.SelectedObjects(0)
         ElseIf container.Children.Count > 0 Then
            currentSelectedObject = container.Children(0)
         End If

         If currentSelectedObject Is Nothing Then
            Return
         End If

         ' If we only have one object, select it
         If container.Children.Count = 1 Then
            _automation.SelectObject(container.Children(0))
         Else
            ' Find the next (or previous object) in the container
            Dim selectedIndex As Integer = container.Children.IndexOf(currentSelectedObject)
            Dim newSelectedIndex As Integer

            If [next] Then
               newSelectedIndex = selectedIndex + 1
            Else
               newSelectedIndex = selectedIndex - 1
            End If

            Dim count As Integer = container.Children.Count

            If newSelectedIndex >= count Then
               newSelectedIndex = 0
            ElseIf newSelectedIndex < 0 Then
               newSelectedIndex = count - 1
            End If

            If newSelectedIndex <> selectedIndex Then
               ' prevent the demo to select signature object as PDF Annotation object.
               If container.Children(newSelectedIndex).Id = AnnObject.None Then
                  _automation.SelectObject(container.Children(newSelectedIndex))
                  SelectNextPreviousObject([next])
               Else
                  _automation.SelectObject(container.Children(newSelectedIndex))
               End If
            End If
         End If
      End Sub

      Public Sub SelectObject(ByVal annObj As AnnObject)
         ' Selets an object, it might not be in this container
         For Each container As AnnContainer In _annotationContainers
            If container.Children.Contains(annObj) Then
               Dim pageNumber As Integer = container.PageNumber

               If pageNumber <> _currentPageNumber Then
                  _mainForm.GotoPage(pageNumber, True)
               End If
               Exit For
            End If
         Next container

         ' Here, everything is ready, just select the object
         _automation.SelectObject(annObj)
      End Sub

      Public Sub ShowObjectContent(ByVal annObj As AnnObject)
         If TypeOf annObj Is AnnTextObject Then
            ' Nothing to do, text content is not used.
            MessageBox.Show(_viewer, "Text objects do not use content", "PDF Document Demo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
         End If

         Dim dlg As AutomationUpdateObjectDialog = New AutomationUpdateObjectDialog()
         Try
            dlg.InitialPage = AutomationUpdateObjectDialogPage.Content
            dlg.Automation = _automation
            If dlg.ShowDialog(_mainForm) = DialogResult.OK Then
               _automation.Invalidate(LeadRectD.Empty)
            End If
         Finally
            CType(dlg, IDisposable).Dispose()
         End Try
      End Sub
   End Class
End Namespace
