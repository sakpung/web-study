// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Pdf;
using Leadtools.Annotations.Engine;
using Leadtools.Pdf.Annotations;
using Leadtools.Annotations.Designers;
using Leadtools.Annotations.Rendering;
using Leadtools.Annotations.Automation;
using Leadtools.Annotations.WinForms;
using Leadtools.Controls;

namespace PDFDocumentDemo.Annotations
{
   public class DocumentAnnotations
   {
      // The MainForm
      private MainForm _mainForm;

      // The current PDF document
      private PDFDocument _pdfDocument;
      public PDFDocument PDFDocument
      {
         get { return _pdfDocument; }
      }

      // The automation manager, this is a static member that gets initialized once
      private AnnAutomationManager _automationManager;

      // The viewer - our automation control
      private AutomationImageViewer _viewer;

      // The annotations control, where the toolbar and comments list stays
      private AnnotationsControl _annotationsControl;

      // The automation control, responsible for UI
      private AnnAutomation _automation;
      public AnnAutomation Automation
      {
         get { return _automation; }
      }

      // Annotation manager helper (holds the annotations UI resources such as context menus and toolbar)
      private AutomationManagerHelper _automationManagerHelper;
      public AutomationManagerHelper AutomationManagerHelper
      {
         get { return _automationManagerHelper; }
      }

      // Current page number
      private int _currentPageNumber;
      public int CurrentPageNumber
      {
         get { return _currentPageNumber; }
      }

      // Annotation container for each page
      private AnnContainer[] _annotationContainers;
      public AnnContainer[] AnnotationContainers
      {
         get { return _annotationContainers; }
      }

      public DocumentAnnotations(MainForm mainForm)
      {
         _mainForm = mainForm;
         _viewer = _mainForm.AnnotationsViewer;

         _annotationsControl = _mainForm.AnnotationsControl;
         _annotationsControl.DocumentAnnotations = this;
         _viewer.AutomationDoubleClick += new EventHandler<AnnPointerEventArgs>(_viewer_AutomationDoubleClick);

         // Create custom bitmaps
         //CreateBitmaps();
         _automationManager = AnnAutomationManager.Create(new AnnWinFormsRenderingEngine());
         _automationManager.CreateDefaultObjects();
         _automationManager.EnableToolTip = true;
         _automationManagerHelper = new AutomationManagerHelper(_automationManager);

         CreateAutomationObjects();

         // Hook to the current object ID changed, we want to draw an annotation if text is selected
         _automationManager.CurrentObjectIdChanged += new EventHandler(_automationManager_CurrentObjectIdChanged);

         _annotationsControl.CreateToolBar();

         // Create the context menu for the objects
         CreateObjectContextMenus();

         // Add the objects to the main menu
         AddToolsToMenu();

         // No annotation object
         SetNoneObject();

         // Add digital signature object to automation manager
         AddSignatureToAnnManager();
      }

      private void AddSignatureToAnnManager()
      {
         AnnAutomationObject signatureObject = CreateSignatureAutomationObject();
         _automationManager.Objects.Add(signatureObject);
      }

      private void _automationManager_CurrentObjectIdChanged(object sender, EventArgs e)
      {
         if (!IsEnabled || !IsAnnotationsVisible || _automation == null)
            return;

         AnnObject createdObject = null;

         // See if the new designer is one of the review objects
         int currentObjectId = _automationManager.CurrentObjectId;
         if (currentObjectId == AnnObject.TextHiliteObjectId ||
            currentObjectId == AnnObject.TextStrikeoutObjectId ||
            currentObjectId == AnnObject.TextUnderlineObjectId)
         {
            // See if we have object selected
            if (_mainForm.IsTextSelected)
            {
               // Go back to none object, invoke this because we are already in the
               // handler for CurrentObjectIdChanged
               _mainForm.BeginInvoke(new MethodInvoker(SetNoneObject));
               createdObject = CreatePDFReviewObject(currentObjectId);
            }
         }

         _mainForm.BeginInvoke(new UpdatePDFObjectsDelegate(UpdatePDFObjects), new object[] { createdObject });
      }

      private void CreateAutomationObjects()
      {
         AnnRenderingEngine renderingEngine = _automationManager.RenderingEngine;

         // Save the thumb location style
         IAnnThumbStyle locationThumbStyle = renderingEngine.Renderers[AnnObject.PolylineObjectId].LocationsThumbStyle;

         // Save the AnnRectangleRenderer, we need it for drawing review objects
         IAnnObjectRenderer rectangleRenderer = _automationManager.RenderingEngine.Renderers[AnnObject.RectangleObjectId];

         // Clear
         _automationManager.RenderingEngine.Renderers.Clear();

         // Re-add the rectangle renderer
         _automationManager.RenderingEngine.Renderers.Add(AnnObject.RectangleObjectId, rectangleRenderer);

         // Create the annotation objects, PDF specific
         AnnAutomationObject lineAutomationObject = CreateLineAutomationObject();
         AnnAutomationObject pointerAutomationObject = CreatePointerAutomationObject();
         AnnAutomationObject polylineAutomationObject = CreatePolylineAutomationObject();
         AnnAutomationObject polygonAutomationObject = CreatePolygonAutomationObject();
         AnnAutomationObject rectangleAutomationObject = CreateRectangleAutomationObject();
         AnnAutomationObject ellipseAutomationObject = CreateEllipseAutomationObject();
         AnnAutomationObject pencilAutomationObject = CreatePencilAutomationObject();
         AnnAutomationObject textAutomationObject = CreateTextAutomationObject();
         AnnAutomationObject textPointerAutomationObject = CreateTextPointerAutomationObject();
         AnnAutomationObject noteAutomationObject = CreateNoteAutomationObject();
         AnnAutomationObject highlightAutomationObject = CreateHighlightAutomationObject();
         AnnAutomationObject strikeoutAutomationObject = CreateStrikeoutAutomationObject();
         AnnAutomationObject underlineAutomationObject = CreateUnderlineAutomationObject();

         //Remove the default objects
         _automationManager.Objects.Clear();

         // Add the annotation objects, PDF specific
         _automationManager.Objects.Add(lineAutomationObject);
         _automationManager.Objects.Add(pointerAutomationObject);
         _automationManager.Objects.Add(polylineAutomationObject);
         _automationManager.Objects.Add(polygonAutomationObject);
         _automationManager.Objects.Add(rectangleAutomationObject);
         _automationManager.Objects.Add(ellipseAutomationObject);
         _automationManager.Objects.Add(pencilAutomationObject);
         _automationManager.Objects.Add(textAutomationObject);
         _automationManager.Objects.Add(textPointerAutomationObject);
         _automationManager.Objects.Add(noteAutomationObject);
         _automationManager.Objects.Add(highlightAutomationObject);
         _automationManager.Objects.Add(strikeoutAutomationObject);
         _automationManager.Objects.Add(underlineAutomationObject);

         // Disable rotation
         foreach (AnnAutomationObject automationObject in _automationManager.Objects)
         {
            // Disable the rotation points
            automationObject.UseRotateThumbs = false;
         }

         foreach (IAnnObjectRenderer renderer in renderingEngine.Renderers.Values)
         {
            renderer.LocationsThumbStyle = locationThumbStyle;
         }
      }

      private AnnAutomationObject CreateLineAutomationObject()
      {
         AnnAutomationObject automationObj = new AnnAutomationObject();

         automationObj.Id = AnnObject.LineObjectId;
         automationObj.Name = "Line";
         automationObj.DrawDesignerType = typeof(AnnLineDrawDesigner);
         automationObj.EditDesignerType = typeof(AnnPolylineEditDesigner);

         AnnPolylineObject annObj = new AnnPolylineObject();
         automationObj.ObjectTemplate = annObj;
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.LineObjectId);

         // Set its renderer
         _automationManager.RenderingEngine.Renderers[automationObj.Id] = new AnnPolylineObjectRenderer();

         return automationObj;
      }

      private AnnAutomationObject CreatePointerAutomationObject()
      {
         AnnAutomationObject automationObj = new AnnAutomationObject();

         automationObj.Id = AnnObject.PointerObjectId;
         automationObj.Name = "Line";
         automationObj.DrawDesignerType = typeof(AnnLineDrawDesigner);
         automationObj.EditDesignerType = typeof(AnnPolylineEditDesigner);

         AnnPointerObject annObj = new AnnPointerObject();
         automationObj.ObjectTemplate = annObj;
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.PointerObjectId);

         // Set its renderer
         _automationManager.RenderingEngine.Renderers[automationObj.Id] = new AnnPointerObjectRenderer();

         return automationObj;
      }

      private AnnAutomationObject CreatePolylineAutomationObject()
      {
         AnnAutomationObject automationObj = new AnnAutomationObject();

         automationObj.Id = AnnObject.PolylineObjectId;
         automationObj.Name = "Polyline";
         automationObj.DrawDesignerType = typeof(AnnPolylineDrawDesigner);
         automationObj.EditDesignerType = typeof(AnnPolylineEditDesigner);

         AnnPolylineObject annObj = new AnnPolylineObject();
         automationObj.ObjectTemplate = annObj;
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.PolylineObjectId);

         // Set its renderer
         _automationManager.RenderingEngine.Renderers[automationObj.Id] = new AnnPolylineObjectRenderer();

         return automationObj;
      }

      private AnnAutomationObject CreatePolygonAutomationObject()
      {
         AnnAutomationObject automationObj = new AnnAutomationObject();

         automationObj.Id = AnnObject.PolygonObjectId;
         automationObj.Name = "Polygon";
         automationObj.DrawDesignerType = typeof(AnnPolylineDrawDesigner);
         automationObj.EditDesignerType = typeof(AnnPolylineEditDesigner);

         AnnPolylineObject annObj = new AnnPolylineObject();
         annObj.IsClosed = true;
         automationObj.ObjectTemplate = annObj;
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.PolygonObjectId);

         // Set its renderer
         _automationManager.RenderingEngine.Renderers[automationObj.Id] = new AnnPolylineObjectRenderer();

         return automationObj;
      }

      private AnnAutomationObject CreatePencilAutomationObject()
      {
         AnnAutomationObject automationObj = new AnnAutomationObject();

         automationObj.Id = AnnObject.FreehandObjectId;
         automationObj.Name = "Pencil";
         automationObj.DrawDesignerType = typeof(AnnFreehandDrawDesigner);
         automationObj.EditDesignerType = typeof(AnnPolylineEditDesigner);

         AnnPolylineObject annObj = new AnnPolylineObject();
         automationObj.ObjectTemplate = annObj;
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.FreehandObjectId);

         // Set its renderer
         _automationManager.RenderingEngine.Renderers[automationObj.Id] = new AnnPolylineObjectRenderer();

         return automationObj;
      }

      private AnnAutomationObject CreateRectangleAutomationObject()
      {
         AnnAutomationObject automationObj = new AnnAutomationObject();

         automationObj.Id = AnnObject.RectangleObjectId;
         automationObj.Name = "Rectangle";
         automationObj.DrawDesignerType = typeof(AnnRectangleDrawDesigner);
         automationObj.EditDesignerType = typeof(AnnRectangleEditDesigner);

         AnnRectangleObject annObj = new AnnRectangleObject();
         automationObj.ObjectTemplate = annObj;
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.RectangleObjectId);

         // Set its renderer
         _automationManager.RenderingEngine.Renderers[automationObj.Id] = new AnnRectangleObjectRenderer();

         return automationObj;
      }

      private AnnAutomationObject CreateEllipseAutomationObject()
      {
         AnnAutomationObject automationObj = new AnnAutomationObject();

         automationObj.Id = AnnObject.EllipseObjectId;
         automationObj.Name = "Ellipse";
         automationObj.DrawDesignerType = typeof(AnnRectangleDrawDesigner);
         automationObj.EditDesignerType = typeof(AnnRectangleEditDesigner);

         AnnEllipseObject annObj = new AnnEllipseObject();
         automationObj.ObjectTemplate = annObj;
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.EllipseObjectId);

         // Set its renderer
         _automationManager.RenderingEngine.Renderers[automationObj.Id] = new AnnEllipseObjectRenderer();

         return automationObj;
      }

      private AnnAutomationObject CreateTextAutomationObject()
      {
         AnnAutomationObject automationObj = new AnnAutomationObject();

         automationObj.Id = AnnObject.TextObjectId;
         automationObj.Name = "Text";
         automationObj.DrawDesignerType = typeof(AnnRectangleDrawDesigner);
         automationObj.EditDesignerType = typeof(AnnTextEditDesigner);

         AnnTextObject annObj = new AnnTextObject();
         automationObj.ObjectTemplate = annObj;
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.TextObjectId);

         // Set its renderer
         _automationManager.RenderingEngine.Renderers[automationObj.Id] = new AnnTextObjectRenderer();

         return automationObj;
      }

      private AnnAutomationObject CreateTextPointerAutomationObject()
      {
         AnnAutomationObject automationObj = new AnnAutomationObject();

         automationObj.Id = AnnObject.TextPointerObjectId;
         automationObj.Name = "TextPointer";
         automationObj.DrawDesignerType = typeof(AnnTextPointerDrawDesigner);
         automationObj.EditDesignerType = typeof(AnnTextPointerEditDesigner);

         AnnTextPointerObject annObj = new AnnTextPointerObject();
         annObj.UseKnee = true;
         automationObj.ObjectTemplate = annObj;
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.TextPointerObjectId);

         // Set its renderer
         _automationManager.RenderingEngine.Renderers[automationObj.Id] = new AnnTextPointerObjectRenderer();

         return automationObj;
      }

      private AnnAutomationObject CreateNoteAutomationObject()
      {
         AnnAutomationObject automationObj = new AnnAutomationObject();

         automationObj.Id = AnnObject.StickyNoteObjectId;
         automationObj.Name = "Sticky Note";
         automationObj.DrawDesignerType = typeof(AnnStickyNoteDrawDesigner);
         automationObj.EditDesignerType = typeof(AnnEditDesigner);

         AnnStickyNoteObject annObj = new AnnStickyNoteObject();
         automationObj.ObjectTemplate = annObj;
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.NoteObjectId);

         // Set its renderer
         _automationManager.RenderingEngine.Renderers[automationObj.Id] = new AnnStickyNoteObjectRenderer();

         return automationObj;
      }

      private AnnAutomationObject CreateHighlightAutomationObject()
      {
         AnnAutomationObject automationObj = new AnnAutomationObject();

         automationObj.Id = AnnObject.TextHiliteObjectId;
         automationObj.Name = "Highlight Text";
         automationObj.DrawDesignerType = typeof(AnnTextReviewDrawDesigner);
         automationObj.EditDesignerType = typeof(AnnTextReviewEditDesigner);

         AnnTextHiliteObject annObj = new AnnTextHiliteObject();
         annObj.Fill = AnnSolidColorBrush.Create("yellow");
         automationObj.ObjectTemplate = annObj;
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.TextHiliteObjectId);

         // Set its renderer
         _automationManager.RenderingEngine.Renderers[automationObj.Id] = new AnnTextHiliteObjectRenderer();

         return automationObj;
      }

      private AnnAutomationObject CreateStrikeoutAutomationObject()
      {
         AnnAutomationObject automationObj = new AnnAutomationObject();

         automationObj.Id = AnnObject.TextStrikeoutObjectId;
         automationObj.Name = "Strikeout Text";
         automationObj.DrawDesignerType = typeof(AnnTextReviewDrawDesigner);
         automationObj.EditDesignerType = typeof(AnnTextReviewEditDesigner);

         AnnTextStrikeoutObject annObj = new AnnTextStrikeoutObject();
         automationObj.ObjectTemplate = annObj;
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.TextStrikeoutObjectId);

         // Set its renderer
         _automationManager.RenderingEngine.Renderers[automationObj.Id] = new AnnTextStrikeoutObjectRenderer();

         return automationObj;
      }

      private AnnAutomationObject CreateUnderlineAutomationObject()
      {
         AnnAutomationObject automationObj = new AnnAutomationObject();

         automationObj.Id = AnnObject.TextUnderlineObjectId;
         automationObj.Name = "Underline Text";
         automationObj.DrawDesignerType = typeof(AnnTextReviewDrawDesigner);
         automationObj.EditDesignerType = typeof(AnnTextReviewEditDesigner);

         AnnTextUnderlineObject annObj = new AnnTextUnderlineObject();
         automationObj.ObjectTemplate = annObj;
         automationObj.ToolBarImage = GetAutomationObjectToolbarImage(AnnObject.TextUnderlineObjectId);

         // Set its renderer
         _automationManager.RenderingEngine.Renderers[automationObj.Id] = new AnnTextUnderlineObjectRenderer();

         return automationObj;
      }

      private AnnAutomationObject CreateSignatureAutomationObject()
      {
         AnnAutomationObject automationObj = new AnnAutomationObject();

         automationObj.Id = AnnSignatureObject.SignatureObjectID;
         automationObj.Name = "Signature";
         automationObj.DrawDesignerType = typeof(AnnRectangleDrawDesigner);
         automationObj.EditDesignerType = typeof(AnnRectangleEditDesigner);

         AnnSignatureObject annObj = new AnnSignatureObject();

         automationObj.ObjectTemplate = annObj;
         automationObj.ToolBarImage = null;

         // Set its renderer
         _automationManager.RenderingEngine.Renderers[automationObj.Id] = new AnnSignatureObjectRenderer();

         return automationObj;
      }

      private void _automation_OnShowObjectPropertiesFunc(object sender, EventArgs e)
      {
         AnnAutomation automation = Automation;//sender as AnnAutomation;
         automation.ShowObjectProperties();
      }


      private void CreateObjectContextMenus()
      {
         // Create the context menus to use with the objects
         ContextMenu cm = new ContextMenu();
         cm.MenuItems.Add(new MenuItem("&Delete", _automation_DeleteSelectedObject));
         cm.MenuItems.Add(new MenuItem("&Properties...", _automation_OnShowObjectPropertiesFunc));

         foreach (AnnAutomationObject automationObj in _automationManager.Objects)
         {
            if ((automationObj != null) && (automationObj.Id != AnnObject.None) && (automationObj.ContextMenu != null))
            {
               automationObj.ContextMenu = cm;
            }
         }
      }

      private object GetAutomationObjectToolbarImage(int automationObjectID)
      {
         object toolBarImage = null;

         var automationObject = _automationManager.FindObjectById(automationObjectID);
         if (automationObject != null)
         {
            toolBarImage = automationObject.ToolBarImage;
         }

         return toolBarImage;
      }

      private void AddToolsToMenu()
      {
         ToolStripMenuItem annotationsMenuItem = _mainForm.AnnotationsMenuItem;

         EventHandler eventHandler = new EventHandler(annotationObjectMenuItem_Click);

         foreach (AnnAutomationObject automationObj in _automationManager.Objects)
         {
            // Check if the object has a toolbar button
            if (automationObj.ToolBarImage != null && automationObj.Id != AnnObject.None)
            {
               ToolStripMenuItem menuItem = new ToolStripMenuItem();
               menuItem.Text = automationObj.Name;
               menuItem.ToolTipText = automationObj.Name;

               menuItem.Image = (Image)automationObj.ToolBarImage;

               // Set the tag to the object ID, makes it easier to track
               menuItem.Tag = automationObj.Id;
               menuItem.Click += new EventHandler(eventHandler);

               annotationsMenuItem.DropDownItems.Add(menuItem);
            }
         }
      }

      private void annotationObjectMenuItem_Click(object sender, EventArgs e)
      {
         ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
         int objectId = (int)menuItem.Tag;
         _automationManager.CurrentObjectId = objectId;
      }

      private void SetNoneObject()
      {
         _automationManager.CurrentObjectId = AnnObject.None;
      }

      private void _automation_DeleteSelectedObject(object sender, EventArgs e)
      {
         DeleteSelectedObject();
      }

      public void DeleteSelectedObject()
      {
         if (_automation != null && _automation.CanDeleteObjects)
         {
            _automation.DeleteSelectedObjects();

            // Re-populate the comments list
            _annotationsControl.Populate();
         }
      }

      // Viewer events
      private void _viewer_AutomationDoubleClick(object sender, AnnPointerEventArgs e)
      {
         // User double clicks the viewer, check if any object, if so "run" it
         if (!IsEnabled || !IsAnnotationsVisible || _automation == null || e.Button != AnnMouseButton.Left)
            return;

         // Check if we have an object selected
         AnnObject annObj = _automation.CurrentEditObject;
         if (annObj != null && annObj.Id != AnnObject.TextObjectId && annObj.Id != AnnObject.None)
         {
            ShowObjectContent(annObj);
         }
      }

      public void InteractiveModeChanged(ViewerControl.ViewerControlInteractiveMode interactiveMode)
      {
         if (interactiveMode == ViewerControl.ViewerControlInteractiveMode.SelectMode)
         {
            EnableUI(true);
         }
         else
         {
            // Cancel any current UI annotations operations
            if (_automation != null)
            {
               _automation.Cancel();
               _automation.Invalidate(LeadRectD.Empty);

               SetNoneObject();

               EnableUI(false);
            }
         }
      }

      // Automation events
      private void _automation_OnShowContextMenu(object sender, AnnAutomationEventArgs e)
      {
         if (e != null && e.Object != null)
         {
            _viewer.AutomationInvalidate(LeadRectD.Empty);
            AnnAutomationObject annAutomationObject = e.Object as AnnAutomationObject;
            if (annAutomationObject != null && annAutomationObject.Id != AnnObject.None)
            {
               var menu = annAutomationObject.ContextMenu as ContextMenu;
               if (menu != null)
               {
                  menu.Show(_viewer, _viewer.PointToClient(Cursor.Position));
               }
            }
         }
      }

      private void _automation_EditText(object sender, AnnEditTextEventArgs e)
      {
         TextBox text = new TextBox();
         Rectangle rc = new Rectangle((int)e.Bounds.Left, (int)e.Bounds.Top, (int)e.Bounds.Width, (int)e.Bounds.Height);
         rc.Inflate(12, 12);
         text.Location = rc.Location;
         text.Size = rc.Size;
         text.AutoSize = false;
         text.Tag = e.TextObject;
         text.Text = e.TextObject.Text;
         text.ForeColor = Color.FromName((e.TextObject.TextForeground as AnnSolidColorBrush).Color);
         text.AcceptsReturn = true;
         text.Multiline = true;
         text.Font = AnnWinFormsRenderingEngine.ToFont(e.TextObject.Font);
         text.WordWrap = false;
         text.Tag = e.TextObject;

         text.LostFocus += new EventHandler(text_LostFocus);

         Control automationControl = _automation.AutomationControl as Control;
         automationControl.Controls.Add(text);
         text.Focus();
      }

      private AnnEditDesigner _editDesigner = null;

      private void _automation_CurrentDesignerChanged(object sender, EventArgs e)
      {
         // If we have an edit designer hooked, unhook it
         if (_editDesigner != null)
         {
            //_editDesigner.Edit -= new EventHandler<AnnEditDesignerEventArgs>(editDesigner_Edit);
            _editDesigner = null;
         }

         // Monitor when a draw designer has finished, so we can 
         // obtain the newly added object
         AnnDrawDesigner drawDesigner = _automation.CurrentDesigner as AnnDrawDesigner;
         if (drawDesigner != null)
         {
            // Hook to its draw event
            drawDesigner.Draw += new EventHandler<AnnDrawDesignerEventArgs>(drawDesigner_Draw);

            // If this is review draw designer, set the object ID, we will use it when the designer ends
            AnnTextReviewDrawDesigner reviewDrawDesigner = drawDesigner as AnnTextReviewDrawDesigner;
            //if (reviewDrawDesigner != null)
            //   reviewDrawDesigner.PDFObjectId = _automationManager.CurrentObjectId;
         }
         //else
         //{
         //   // Monitor when an edit designer has finished, so we can
         //   // update the corresponding PDF object
         //   AnnEditDesigner editDesigner = _automation.CurrentDesigner as AnnEditDesigner;
         //   if (editDesigner != null)
         //   {
         //      // Hook to its edit event
         //      _editDesigner = editDesigner;
         //      _hasEditDesignerWorked = false;
         //      //_editDesigner.Edit += new EventHandler<AnnEditDesignerEventArgs>(editDesigner_Edit);
         //   }
         //}

         // Let the annotation control know

         EndTextEditor();
      }

      private void drawDesigner_Draw(object sender, AnnDrawDesignerEventArgs e)
      {
         if (e.OperationStatus == AnnDesignerOperationStatus.End ||
            e.OperationStatus == AnnDesignerOperationStatus.Canceled)
         {
            // Object has finished drawing, unhook from the event
            AnnDrawDesigner drawDesigner = sender as AnnDrawDesigner;
            drawDesigner.Draw -= new EventHandler<AnnDrawDesignerEventArgs>(drawDesigner_Draw);

            // If the object has been created successfully and is not the select object, then create the
            // PDF annotation object that corresponds to the ann object
            if (e.OperationStatus == AnnDesignerOperationStatus.End && !e.Cancel && e.Object.Id != AnnObject.SelectObjectId)
            {
               // Check if this a review draw designer
               AnnTextReviewDrawDesigner reviewDrawDesigner = sender as AnnTextReviewDrawDesigner;

               AnnObject createdObject = null;

               if (reviewDrawDesigner != null)
               {
                  e.Cancel = true;

                  // Highlight the text, get the rectangle object bounds.
                  AnnTextReviewObject rectObject = e.Object as AnnTextReviewObject;
                  LeadRectD objectBounds = rectObject.GetRectangles()[0];

                  // Convert to image coordinates, so first from container to screen then use the viewer
                  objectBounds = _automation.Container.Mapper.RectFromContainerCoordinates(objectBounds, rectObject.FixedStateOperations);
                  LeadRect rect = new LeadRect((int)objectBounds.X, (int)objectBounds.Y, (int)objectBounds.Width, (int)objectBounds.Height);
                  rect = _viewer.ConvertRect(null, Leadtools.Controls.ImageViewerCoordinateType.Control, Leadtools.Controls.ImageViewerCoordinateType.Image, rect);

                  LeadRect bounds = LeadRect.Create(rect.X, rect.Y, rect.Width, rect.Height);

                  _mainForm.HighlightText(bounds);

                  // Create a PDF review object from the highlighted text, the object ID is what we set when the designer started
                  createdObject = CreatePDFReviewObject(reviewDrawDesigner.TargetObject.Id);
               }

               _mainForm.BeginInvoke(new UpdatePDFObjectsDelegate(UpdatePDFObjects), new object[] { createdObject });
            }
         }
      }

      private delegate void UpdatePDFObjectsDelegate(AnnObject createdObj);
      private void UpdatePDFObjects(AnnObject createdObj)
      {
         if (createdObj != null)
         {
            _mainForm.ClearTextSelection();
            _automation.SelectObject(createdObj);
         }

         _annotationsControl.Populate();
      }

      private void text_LostFocus(object sender, EventArgs e)
      {
         EndTextEditor();
      }

      private void AutomationControl_AutomationTransformChanged(object sender, EventArgs e)
      {
         EndTextEditor();
      }

      private void EndTextEditor()
      {
         Control automationControl = _automation.AutomationControl as Control;

         foreach (Control control in automationControl.Controls)
         {
            if (control is TextBox)
            {
               AnnTextObject textObject = control.Tag as AnnTextObject;
               if (textObject != null)
               {
                  textObject.Text = control.Text;
               }

               control.LostFocus -= new EventHandler(text_LostFocus);
               automationControl.Controls.Remove(control);
            }
         }
      }

      public bool IsEnabled
      {
         get
         {
            return _automationManagerHelper.ToolBar.Enabled;
         }
      }

      private bool _isAnnotationsVisible = true;
      public bool IsAnnotationsVisible
      {
         get
         {
            // All are the same, just return the value for the first page
            return _isAnnotationsVisible;
         }
         set
         {
            _isAnnotationsVisible = value;
            _annotationContainers[_automation.ActiveContainer.PageNumber - 1].IsVisible = _isAnnotationsVisible;
            EnableUI(value);
         }
      }

      private void EnableUI(bool enable)
      {
         if (_automationManagerHelper != null)
         {
            _automationManagerHelper.ToolBar.Enabled = enable;
            _annotationsControl.Enabled = enable;
         }
      }

      public static void SetRasterCodecsOptions(PDFDocument pdfDocument, RasterCodecs rasterCodecs, int pageNumber)
      {
         // If the PDF page has annotations, then do not draw them on the image
         PDFDocumentPage pdfPage = pdfDocument.Pages[pageNumber - 1];
         IList<PDFAnnotation> annotations = pdfPage.Annotations;
         if (annotations != null && annotations.Count > 0)
         {
            rasterCodecs.Options.Pdf.Load.HideAnnotations = true;
         }
         else
         {
            rasterCodecs.Options.Pdf.Load.HideAnnotations = false;
         }
      }

      private AnnObject CreatePDFReviewObject(int objectId)
      {
         // Get the selected words
         Dictionary<int, MyWord[]> selectedText = _mainForm.SelectedText;

         MyWord[] words = null;
         if (selectedText != null && selectedText.ContainsKey(_currentPageNumber))
         {
            words = selectedText[_currentPageNumber];
         }

         if (words == null || words.Length == 0)
            return null;

         // Create the new PDF object
         AnnObject pdfObject = null;

         switch (objectId)
         {
            case AnnObject.TextStrikeoutObjectId:
               pdfObject = new AnnTextStrikeoutObject();
               break;

            case AnnObject.TextUnderlineObjectId:
               pdfObject = new AnnTextUnderlineObject();
               break;

            case AnnObject.TextHiliteObjectId:
            default:
               pdfObject = new AnnTextHiliteObject();
               break;
         }

         // Set the points
         AnnTextReviewObject annObject = pdfObject as AnnTextReviewObject;

         annObject.Points.Clear();
         LeadRect currentBounds = LeadRect.Empty;

         int wordIndex = 0;
         int wordCount = words.Length;

         while (wordIndex < wordCount)
         {
            LeadRect bounds = LeadRect.Empty;

            bool more = true;
            while (more && wordIndex < wordCount)
            {
               MyWord word = words[wordIndex];

               if (bounds.IsEmpty)
                  bounds = word.Bounds;
               else
                  bounds = LeadRect.Union(bounds, word.Bounds);

               // Check if need more rects
               more = wordIndex < wordCount && !word.IsEndOfLine;
               wordIndex++;
            }

            // Add current bounds

            // Convert to viewer coordinates (physical)
            LeadRect rect = new LeadRect(bounds.X, bounds.Y, bounds.Width, bounds.Height);
            rect = _viewer.ConvertRect(null, Leadtools.Controls.ImageViewerCoordinateType.Image, Leadtools.Controls.ImageViewerCoordinateType.Control, rect);

            // Convert to annotation
            LeadRectD segmentBounds = LeadRectD.Create(rect.X, rect.Y, rect.Width, rect.Height);
            segmentBounds = _automation.Container.Mapper.RectToContainerCoordinates(segmentBounds);

            //Add the rectangle of the segment to the highlight object
            annObject.AddRectangle(segmentBounds);
            UpdateObjectsMetadata(new AnnObjectCollection(new AnnObject[] { annObject }));
         }

         // Add the object
         _automation.Container.Children.Add(annObject);

         return annObject;
      }

      public void SetDocument(PDFDocument document)
      {
         if (_automation != null)
         {
            // Delete current automation
            _automation.Detach();
            _automationManager.Automations.Remove(_automation);
            _automation.AfterObjectChanged -= new EventHandler<AnnAfterObjectChangedEventArgs>(_automation_AfterObjectChanged);
            _automation.OnShowObjectProperties -= new EventHandler<AnnAutomationEventArgs>(_automation_OnShowObjectProperties);
            _automation.OnShowContextMenu -= new EventHandler<AnnAutomationEventArgs>(_automation_OnShowContextMenu);
            _automation.EditText -= new EventHandler<AnnEditTextEventArgs>(_automation_EditText);
            _automation.CurrentDesignerChanged -= new EventHandler(_automation_CurrentDesignerChanged);
            _automation.ActiveContainerChanged -= new EventHandler(_automation_ActiveContainerChanged);
            _automation.AutomationControl.AutomationTransformChanged -= new EventHandler(AutomationControl_AutomationTransformChanged);
            _automation.Edit -= new EventHandler<AnnEditDesignerEventArgs>(_automation_Edit);
            _automation = null;
         }

         _pdfDocument = document;
         _currentPageNumber = -1;

         if (_pdfDocument != null)
         {
            _automationManager.EnableToolTip = true;
            // Create the automation object (for UI)
            _automation = new AnnAutomation(_automationManager, _viewer);
            _automation.AfterObjectChanged += new EventHandler<AnnAfterObjectChangedEventArgs>(_automation_AfterObjectChanged);
            _automation.OnShowObjectProperties += new EventHandler<AnnAutomationEventArgs>(_automation_OnShowObjectProperties);
            _automation.OnShowContextMenu += new EventHandler<AnnAutomationEventArgs>(_automation_OnShowContextMenu);
            _automation.EditText += new EventHandler<AnnEditTextEventArgs>(_automation_EditText);
            _automation.CurrentDesignerChanged += new EventHandler(_automation_CurrentDesignerChanged);
            _automation.ActiveContainerChanged += new EventHandler(_automation_ActiveContainerChanged);
            _automation.AutomationControl.AutomationTransformChanged += new EventHandler(AutomationControl_AutomationTransformChanged);
            _automation.Edit += new EventHandler<AnnEditDesignerEventArgs>(_automation_Edit);
            _automation.ToolTip += _automation_ToolTip;

            // Set it as active
            _automation.Active = true;

            _automation.Containers.Clear();

            // Create and populate the annotation containers for each page

            // PDF page coordinates is in 1/72 of an inch, annotation coordinates is in 1/720,

            int pageCount = document.Pages.Count;
            _annotationContainers = new AnnContainer[pageCount];

            for (int pageNumber = 1; pageNumber <= pageCount; pageNumber++)
            {
               // Add the PDF annotations objects
               PDFDocumentPage pdfPage = _pdfDocument.Pages[pageNumber - 1];

               AnnContainer annContainer = new AnnContainer();

               // PDF page coordinates is in 1/72 of an inch, annotation coordinates is in 1/720, 
               annContainer.Size = LeadSizeD.Create(pdfPage.Width * 10, pdfPage.Height * 10);

               annContainer.PageNumber = pageNumber;

               if (pdfPage.Annotations != null && pdfPage.Annotations.Count > 0)
               {
                  AnnPDFConvertor.ConvertFromPDF(pdfPage.Annotations, annContainer, LeadSizeD.Create(pdfPage.Width, pdfPage.Height));
               }

               // if we have Signatures add them to the active container.
               if (pdfPage.Signatures != null && pdfPage.Signatures.Count > 0)
               {
                  AddSignaturesObjectsToContainer(pdfPage.Signatures, annContainer, LeadSizeD.Create(pdfPage.Width, pdfPage.Height));
               }

               _annotationContainers[pageNumber - 1] = annContainer;
               _automation.Containers.Add(annContainer);
            }

            _annotationsControl.Automation = _automation;
            _annotationsControl.Populate();
         }

         // Enable PDF Mode
         _automationManager.UsePDFMode = true;
      }

      void _automation_ToolTip(object sender, AnnToolTipEventArgs e)
      {
         if (e.AnnotationObject != null && e.AnnotationObject is AnnSignatureObject)
         {
            //Draw border around the AnnSignatureObject
            (e.AnnotationObject as AnnSignatureObject).DrawBorder = true;
            _automation.Invalidate(LeadRectD.Empty);
         }
         else
         {
            foreach (AnnObject annObject in _automation.Container.Children)
            {
               //Remove the border from AnnSignatureObject
               if (annObject is AnnSignatureObject)
                  (annObject as AnnSignatureObject).DrawBorder = false;
            }

            _automation.Invalidate(LeadRectD.Empty);
         }
      }

      void _automation_Edit(object sender, AnnEditDesignerEventArgs e)
      {
         // if we edit "AnnSignatureObject" check the "AnnEditDesignerOperation" if it is None. If ok, open "SignatureValidationStatusDialog".
         AnnSignatureObject signatureObject = e.Object as AnnSignatureObject;

         if (signatureObject != null && e.Operation == AnnEditDesignerOperation.None)
         {
            using (SignatureValidationStatusDialog validationStatusDialog = new SignatureValidationStatusDialog(signatureObject.Signature))
            {
               validationStatusDialog.ShowDialog();
               signatureObject.IsSelected = false;
            }
         }
      }

      void _automation_ActiveContainerChanged(object sender, EventArgs e)
      {
         if (_automation.ActiveContainer != null)
         {
            int pageNumber = _automation.Containers.IndexOf(_automation.ActiveContainer) + 1;

            if (pageNumber > 0 && pageNumber != CurrentPageNumber && CurrentPageNumber != -1)
            {
               _mainForm.GotoPage(pageNumber, true);
            }
         }
      }

      void _automation_OnShowObjectProperties(object sender, AnnAutomationEventArgs e)
      {
         if (_automation != null && _automation.CanShowObjectProperties)
         {
            // Get the current selected object
            AnnObject annObject = _automation.CurrentEditObject;
            Debug.Assert(annObject != null);

            using (AutomationUpdateObjectDialog dlg = new AutomationUpdateObjectDialog())
            {
               dlg.InitialPage = AutomationUpdateObjectDialogPage.Properties;

               if (_automation.CurrentEditObject != null && (_automation.CurrentEditObject.Id == AnnObject.StickyNoteObjectId || _automation.CurrentEditObject is AnnTextObject))
               {
                  // if text object, we cannot do that. Ignore, the EditText will fire
                  dlg.SetPageVisible(AutomationUpdateObjectDialogPage.Content, false);
               }

               dlg.Automation = _automation;

               dlg.ShowDialog(_mainForm);
            }
         }
      }

      private void _automation_AfterObjectChanged(object sender, AnnAfterObjectChangedEventArgs e)
      {
         if (e.Objects == null || e.Objects.Count == 0)
            return;

         switch (e.ChangeType)
         {
            case AnnObjectChangedType.DesignerEdit:
               AnnEditDesigner editDesigner = _automation.CurrentDesigner as AnnEditDesigner;
               if (editDesigner != null && editDesigner.IsModified)
               {
                  UpdateObjectsMetadata(e.Objects);
                  editDesigner.IsModified = false;
               }
               break;

            case AnnObjectChangedType.None:
               break;

            case AnnObjectChangedType.Added:
            case AnnObjectChangedType.Modified:
            case AnnObjectChangedType.DesignerDraw:
            default:
               UpdateObjectsMetadata(e.Objects);
               break;
         }
      }

      private void AddSignaturesObjectsToContainer(IList<PDFSignature> signatures, AnnContainer container, LeadSizeD pdfPageSize)
      {
         if (signatures.Count == 0 || container == null)
            return;

         foreach (var signature in signatures)
         {
            AnnSignatureObject signatureObject = new AnnSignatureObject();

            signatureObject.Signature = signature;

            signatureObject.Rect = FromPDFRect(signature.Bounds, pdfPageSize);

            container.Children.Add(signatureObject);
         }
      }

      public LeadRectD FromPDFRect(PDFRect bounds, LeadSizeD pageSize)
      {
         //Use "AnnPDFConvertor.ConvertFromPDF" to convert signature object bounds from PDFCoordinates to AnnotationCoordinates.
         AnnContainer annContainer = new AnnContainer();
         annContainer.PageNumber = 1;

         // PDF is in bottom-left mode , we need to convert it in top-left mode
         bounds.Bottom = pageSize.Height - bounds.Bottom;
         bounds.Top = pageSize.Height - bounds.Top;

         IList<PDFAnnotation> annotations = new List<PDFAnnotation>();

         PDFRectangleAnnotation pdfRectangleAnnotation = new PDFRectangleAnnotation();
         pdfRectangleAnnotation.PageNumber = 1;
         pdfRectangleAnnotation.Bounds = bounds;

         annotations.Add(pdfRectangleAnnotation);

         AnnPDFConvertor.ConvertFromPDF(annotations, annContainer, LeadSizeD.Create(pageSize.Width, pageSize.Height));

         return annContainer.Children[0].Bounds;
      }

      private void UpdateObjectsMetadata(AnnObjectCollection annObjects)
      {
         if (annObjects == null || annObjects.Count == 0)
            return;

         string now = AnnObject.DateToString(DateTime.Now);
         string[] keys = { AnnObject.AuthorMetadataKey, AnnObject.CreatedMetadataKey, AnnObject.ModifiedMetadataKey };
         string[] values = { Environment.UserName, now, now };

         foreach (AnnObject annObject in annObjects)
            UpdateObjectMetadata(annObject, keys, values);
      }

      private void UpdateObjectMetadata(AnnObject annObject, string[] keys, string[] values)
      {
         AnnSelectionObject selectionObject = annObject as AnnSelectionObject;
         if (selectionObject != null)
         {
            foreach (AnnObject child in selectionObject.SelectedObjects)
               UpdateObjectMetadata(child, keys, values);
         }
         else
         {
            for (int i = 0; i < keys.Length; i++)
               annObject.Metadata[keys[i]] = values[i];
         }
      }


      public void SaveDocument(string fileName)
      {
         // Get a list of all the annotations in this document

         List<PDFAnnotation> fileAnnotations = new List<PDFAnnotation>();

         // Loop through the containers
         foreach (AnnContainer container in _annotationContainers)
         {
            List<PDFAnnotation> pageAnnotations = new List<PDFAnnotation>();
            AnnPDFConvertor.ConvertToPDF(container, pageAnnotations, _pdfDocument.Pages[0].Height);
            fileAnnotations.AddRange(pageAnnotations);
         }

         // Make the file writeable if exists
         if (File.Exists(fileName))
            MakeWriteable(fileName);

         // Load the original file in a PDFFile object
         PDFFile file = new PDFFile(_pdfDocument.FileName, _pdfDocument.Password);
         file.DocumentProperties = _pdfDocument.DocumentProperties;

         // Write it to the new file
         file.WriteAnnotations(fileAnnotations, fileName);
      }

      private static void MakeWriteable(string fileName)
      {
         // Remove read-only if there
         FileAttributes attr = File.GetAttributes(fileName);
         attr &= ~FileAttributes.ReadOnly;
         File.SetAttributes(fileName, attr);
      }

      public void SetCurrentPageNumber(int pageNumber)
      {
         if (_currentPageNumber == pageNumber)
            return;

         foreach (var container in _annotationContainers)
         {
            container.IsVisible = false;
         }

         _currentPageNumber = pageNumber;

         if (_currentPageNumber != -1)
         {
            // Set the container for the page
            AnnContainer container = _annotationContainers[_currentPageNumber - 1];
            //_automation.AttachContainer(container, null);
            if (!container.IsVisible)
               container.IsVisible = true;
            _automation.ActiveContainer = container;
         }
      }

      public void SelectNextPreviousObject(bool next)
      {
         AnnContainer container = _automation.Container;

         // Get the current selected object, or the first object in the container
         AnnObject currentSelectedObject = null;

         if (container.SelectionObject.SelectedObjects.Count > 0)
            currentSelectedObject = container.SelectionObject.SelectedObjects[0];
         else if (container.Children.Count > 0)
            currentSelectedObject = container.Children[0];

         if (currentSelectedObject == null)
            return;

         // If we only have one object, select it
         if (container.Children.Count == 1)
         {
            _automation.SelectObject(container.Children[0]);
         }
         else
         {
            // Find the next (or previous object) in the container
            int selectedIndex = container.Children.IndexOf(currentSelectedObject);
            int newSelectedIndex;

            if (next)
               newSelectedIndex = selectedIndex + 1;
            else
               newSelectedIndex = selectedIndex - 1;

            int count = container.Children.Count;

            if (newSelectedIndex >= count)
               newSelectedIndex = 0;
            else if (newSelectedIndex < 0)
               newSelectedIndex = count - 1;

            if (newSelectedIndex != selectedIndex)
            {
               // prevent the demo to select signature object as PDF Annotation object.
               if (container.Children[newSelectedIndex].Id == AnnObject.None)
               {
                  _automation.SelectObject(container.Children[newSelectedIndex]);
                  SelectNextPreviousObject(next);
               }
               else
               {
                  _automation.SelectObject(container.Children[newSelectedIndex]);
               }
            }
         }
      }

      public void SelectObject(AnnObject annObj)
      {
         // Selets an object, it might not be in this container
         foreach (var container in _annotationContainers)
         {
            if (container.Children.Contains(annObj))
            {
               int pageNumber = container.PageNumber;

               if (pageNumber != _currentPageNumber)
               {
                  _mainForm.GotoPage(pageNumber, true);
               }
               break;
            }
         }

         // Here, everything is ready, just select the object
         _automation.SelectObject(annObj);
      }

      public void ShowObjectContent(AnnObject annObj)
      {
         if (annObj is AnnTextObject)
         {
            // Nothing to do, text content is not used.
            MessageBox.Show(_viewer, "Text objects do not use content", "PDF Document Demo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
         }

         using (AutomationUpdateObjectDialog dlg = new AutomationUpdateObjectDialog())
         {
            dlg.InitialPage = AutomationUpdateObjectDialogPage.Content;
            dlg.Automation = _automation;
            if (dlg.ShowDialog(_mainForm) == DialogResult.OK)
            {
               _automation.Invalidate(LeadRectD.Empty);
            }
         }
      }
   }
}
