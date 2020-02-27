// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
// Uncomment this to use the pre v19 Leadtools.Annotations.WinForms.AutomationImageViewer
// which derives from ImageViewer
// Leave this commented out to use the new Leadtools.Annotations.WinForms.ImageViewerAutomationControl which
// contains an ImageViewer instance (doesn't derive from it)
//#define USE_ImageViewerAutomationControl

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

using Leadtools.Demos;
using Leadtools;
using Leadtools.Annotations;
using Leadtools.Drawing;
using Leadtools.Annotations.Automation;
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.WinForms;
using Leadtools.Annotations.Rendering;
using Leadtools.Annotations.Designers;
using Leadtools.Controls;

namespace AnnotationsDemo
{
   /// <summary>
   /// Summary description for AnnotationsForm.
   /// </summary>
   public class AnnotationsForm : System.Windows.Forms.Form
   {

      public event EventHandler AutomationTextAdded;
      public event EventHandler AutomationTextRemoved;
      protected void OnAutomationTextAdded(EventArgs args)
      {
         if (AutomationTextAdded != null)
         {
            AutomationTextAdded(this, args);
         }
      }

      protected void OnAutomationTextRemoved(EventArgs args)
      {
         if (AutomationTextRemoved != null)
         {
            AutomationTextRemoved(this, args);
         }
      }



      private bool _isEditingText = false;

      public bool IsEditingText
      {
         get
         {
            if (Automation.CurrentDesigner != null)
            {
               AnnRichTextEditDesigner annRichTextEditDesigner = Automation.CurrentDesigner as AnnRichTextEditDesigner;
               if (annRichTextEditDesigner != null)
               {
                  _isEditingText = annRichTextEditDesigner.IsEditingText;
               }

            }
            return _isEditingText;
         }
         set { _isEditingText = value; }
      }

      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public AnnotationsForm()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            CleanUp(disposing);

            if (components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnnotationsForm));
         this.SuspendLayout();
         // 
         // AnnotationsForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(292, 271);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "AnnotationsForm";
         this.Text = "w4";
         this.TransparencyKey = System.Drawing.Color.White;
         this.Closing += new System.ComponentModel.CancelEventHandler(this.AnnotationsForm_Closing);
         this.ResumeLayout(false);

      }
      #endregion

      private IAnnAutomationControl _automationControl;

#if !USE_ImageViewerAutomationControl
      private ImageViewer _viewer;
#else
      private AutomationImageViewer _viewer;
#endif

      private void InitClass()
      {
#if !USE_ImageViewerAutomationControl
         _viewer = new ImageViewer();
         var automationControl = new ImageViewerAutomationControl();
         automationControl.ImageViewer = _viewer;
         _automationControl = automationControl;
#else
         _viewer = new AutomationImageViewer();
         _automationControl = _viewer;
#endif
         _viewer.BorderStyle = BorderStyle.None;
         Controls.Add(_viewer);
         _viewer.BringToFront();

         _viewer.MouseMove += new MouseEventHandler(_viewer_MouseMove);
         _viewer.KeyDown += new KeyEventHandler(_viewer_KeyDown);
         _viewer.UseDpi = false;
         _viewer.Focus();
         _viewer.TransformChanged += new EventHandler(_viewer_TransformChanged);
      }

      void _viewer_TransformChanged(object sender, EventArgs e)
      {
         RemoveAutomationTextBox(true);
      }

      private void CleanUp(bool disposing)
      {
         if (disposing)
         {
#if !USE_ImageViewerAutomationControl
            var automationControl = _automationControl as ImageViewerAutomationControl;
            if (automationControl != null)
               automationControl.Dispose();
#endif

            if (_viewer != null)
               _viewer.Dispose();
         }
      }

      public MainForm MainForm
      {
         get
         {
            return MdiParent as MainForm;
         }
      }

      public ImageViewer Viewer
      {
         get
         {
            return _viewer;
         }
      }

      public IAnnAutomationControl AutomationControl
      {
         get
         {
            return _automationControl;
         }
      }

      public AnnAutomation Automation
      {
         get
         {
            if (_automationControl != null)
               return _automationControl.AutomationObject as AnnAutomation;
            else
               return null;
         }
      }

      private AutomationInteractiveMode _automationInteractiveMode;

      public AutomationInteractiveMode AutomationInteractiveMode
      {
         get { return _automationInteractiveMode; }
         set { _automationInteractiveMode = value; }
      }

      private AutomationTextBox _automationTextBox;

      private ImageViewerPanZoomInteractiveMode _panZoomInteractiveMode;

      public ImageViewerPanZoomInteractiveMode PanZoomInteractiveMode
      {
         get { return _panZoomInteractiveMode; }
         set { _panZoomInteractiveMode = value; }
      }

      ImageViewerMagnifyGlassInteractiveMode _magnifyGlassInteractiveMode;

      public ImageViewerMagnifyGlassInteractiveMode MagnifyGlassInteractiveMode
      {
         get { return _magnifyGlassInteractiveMode; }
         set { _magnifyGlassInteractiveMode = value; }
      }

      private void InitInteractiveModes()
      {
         _automationInteractiveMode = new AutomationInteractiveMode();
         // Don't set the cursors, AnnAutomation will take care of it
         _automationInteractiveMode.AutomationControl = _automationControl;

         _magnifyGlassInteractiveMode = new ImageViewerMagnifyGlassInteractiveMode();
         _magnifyGlassInteractiveMode.IdleCursor = Cursors.Cross;
         _magnifyGlassInteractiveMode.WorkingCursor = Cursors.Cross;

         _panZoomInteractiveMode = new ImageViewerPanZoomInteractiveMode();
         _panZoomInteractiveMode.IdleCursor = Cursors.SizeAll;
         _panZoomInteractiveMode.WorkingCursor = Cursors.SizeAll;

         ImageViewerInteractiveMode[] modes =
         {
            _automationInteractiveMode,
            _panZoomInteractiveMode,
            _magnifyGlassInteractiveMode
         };
         _viewer.InteractiveModes.BeginUpdate();
         foreach (var mode in modes)
         {
            mode.IsEnabled = false;

            var spyglass = mode as ImageViewerSpyGlassInteractiveMode;
            if (spyglass != null)
            {
               mode.IdleCursor = Cursors.Cross;
               spyglass.Shape = ImageViewerSpyGlassShape.Rectangle;
            }

            _viewer.InteractiveModes.Add(mode);
         }
         _automationInteractiveMode.IsEnabled = true;
         _viewer.InteractiveModes.EndUpdate();
      }

      public void Initialize(RasterPaintProperties paintProperties, RasterImage image, string fileName, int pageNumber)
      {
         InitClass();
         Text = fileName;
         _viewer.Image = image;
         _automationControl.AutomationDataProvider = new RasterImageAutomationDataProvider(image);
         UpdatePaintProperties(paintProperties);
         InitInteractiveModes();

         AnnAutomation automation = new AnnAutomation(MainForm.AutomationManager, _automationControl);
         // Update the container size
         automation.Container.Size = automation.Container.Mapper.SizeToContainerCoordinates(LeadSizeD.Create(_viewer.Image.ImageWidth, _viewer.Image.ImageHeight));

         automation.EditText += new EventHandler<AnnEditTextEventArgs>(automation_EditText);
         automation.EditContent += new EventHandler<AnnEditContentEventArgs>(automation_EditContent);
         automation.Container.Children.CollectionChanged += new EventHandler<AnnNotifyCollectionChangedEventArgs>(Children_CollectionChanged);
         automation.Container.Mapper.FontRelativeToDevice = false;
         automation.AfterObjectChanged += new EventHandler<AnnAfterObjectChangedEventArgs>(automation_AfterObjectChanged);
         automation.CurrentDesignerChanged += new EventHandler(automation_CurrentDesignerChanged);
         automation.UndoRedoChanged += new EventHandler(automation_UndoRedoChanged);
         automation.OnShowContextMenu += new EventHandler<AnnAutomationEventArgs>(automation_OnShowContextMenu);
         automation.OnShowObjectProperties += new EventHandler<AnnAutomationEventArgs>(automation_OnShowObjectProperties);
         automation.LockObject += new EventHandler<AnnLockObjectEventArgs>(automation_LockObject);
         automation.UnlockObject += new EventHandler<AnnLockObjectEventArgs>(automation_UnlockObject);
         automation.DeserializeObjectError += new EventHandler<AnnSerializeObjectEventArgs>(automation_DeserializeObjectError);
         automation.SetCursor += new EventHandler<AnnCursorEventArgs>(automation_SetCursor);
         automation.RestoreCursor += new EventHandler(automation_RestoreCursor);
         automation.ToolTip += new EventHandler<AnnToolTipEventArgs>(automation_ToolTip);

         MainForm.UpdateControls();
      }

      void automation_ToolTip(object sender, AnnToolTipEventArgs e)
      {
         if (e.AnnotationObject != null)
         {
            AnnTextObject text = e.AnnotationObject as AnnTextObject;
            string toolTipText = string.Empty;

            if (text != null)
            {
               toolTipText = text.Text;
            }
            else
            {
               AnnPolyRulerObject ruler = e.AnnotationObject as AnnPolyRulerObject;
               if (ruler != null)
               {
                  if (ruler.MeasurementUnit == AnnUnit.Pixel)
                  {
                     LeadLengthD lengthInUnits = ruler.GetRulerLength(1);
                     double lengthInPixels = Automation.Container.Mapper.LengthFromContainerCoordinates(lengthInUnits, AnnFixedStateOperations.Scrolling | AnnFixedStateOperations.Zooming);
                     toolTipText = string.Format("{0} {1}", Math.Round(lengthInPixels, 2), ruler.UnitsAbbreviation[AnnUnit.Pixel]);
                  }
                  else
                  {
                     toolTipText = ruler.GetRulerLengthAsString(Automation.Container.Mapper.CalibrationScale);
                  }
               }
               else
               {
                  AnnRichTextObject richText = e.AnnotationObject as AnnRichTextObject;
                  if (richText != null)
                  {
                     toolTipText = richText.ToString();
                  }
                  else
                  {
                     AnnStickyNoteObject stickyNote = e.AnnotationObject as AnnStickyNoteObject;
                     if (stickyNote != null)
                     {
                        toolTipText = stickyNote.Metadata[AnnObject.ContentMetadataKey];
                     }
                     else
                     {
                        AnnAutomationObject annAutomationObject = MainForm.ManagerHelper.AutomationManager.FindObjectById(e.AnnotationObject.Id);
                        toolTipText = annAutomationObject.Name;
                     }
                  }
               }
            }

            MainForm.ManagerHelper.SetToolTip(_viewer, toolTipText);
         }
         else
         {
            MainForm.ManagerHelper.SetToolTip(null, string.Empty);
         }
      }

      void automation_RestoreCursor(object sender, EventArgs e)
      {
         if (Viewer.Cursor != Cursors.Default)
            Viewer.Cursor = Cursors.Default;
      }

      void automation_SetCursor(object sender, AnnCursorEventArgs e)
      {
         if (!_automationInteractiveMode.IsEnabled)
            return;

         var automation = sender as AnnAutomation;
         Cursor newCursor = null;

         switch (e.DesignerType)
         {
            case AnnDesignerType.Draw:
               {
                  var allow = true;

                  var drawDesigner = automation.CurrentDesigner as AnnDrawDesigner;
                  if (drawDesigner != null && !drawDesigner.IsTargetObjectAdded && e.PointerEvent != null)
                  {
                     // See if we can draw or not
                     var container = automation.ActiveContainer;

                     allow = false;

                     if (automation.HitTestContainer(e.PointerEvent.Location, false) != null)
                        allow = true;
                  }

                  if (allow)
                  {
                     var annAutomationObject = automation.Manager.FindObjectById(e.Id);
                     if (annAutomationObject != null)
                        newCursor = annAutomationObject.DrawCursor as Cursor;
                  }
                  else
                  {
                     newCursor = Cursors.No;
                  }
               }
               break;

            case AnnDesignerType.Edit:
               {
                  if (e.IsRotateCenter)
                     newCursor = AutomationManagerHelper.AutomationCursors[CursorType.RotateCenterControlPoint];
                  else if (e.IsRotateGripper)
                  {
                     newCursor = AutomationManagerHelper.AutomationCursors[CursorType.RotateGripperControlPoint];
                  }
                  else if (e.ThumbIndex < 0)
                  {
                     if (e.DragDropEvent != null && !e.DragDropEvent.Allowed)
                        newCursor = Cursors.No;
                     else
                        newCursor = AutomationManagerHelper.AutomationCursors[CursorType.SelectedObject];
                  }
                  else
                  {
                     newCursor = AutomationManagerHelper.AutomationCursors[CursorType.ControlPoint];
                  }

               }
               break;

            case AnnDesignerType.Run:
               {
                  newCursor = AutomationManagerHelper.AutomationCursors[CursorType.Run];
               }
               break;

            default:
               newCursor = AutomationManagerHelper.AutomationCursors[CursorType.SelectObject];
               break;

         }

         if (Viewer.Cursor != newCursor)
            Viewer.Cursor = newCursor;
      }

      void automation_DeserializeObjectError(object sender, AnnSerializeObjectEventArgs e)
      {
         if (string.Compare(e.TypeName, typeof(AnnRichTextObject).FullName) == 0)
         {
            e.AnnObject = new AnnRichTextObject();
         }

      }

      void automation_EditText(object sender, AnnEditTextEventArgs e)
      {
         RemoveAutomationTextBox(true);

         if (e.TextObject == null)
            return;

         _automationTextBox = new AutomationTextBox(_viewer, this.Automation, e, RemoveAutomationTextBox);
         OnAutomationTextAdded(EventArgs.Empty);
      }

      private void RemoveAutomationTextBox(bool update)
      {
         if (_automationTextBox == null)
            return;

         _automationTextBox.Remove(update);

         if (_automationTextBox != null)
         {
            _automationTextBox.Dispose();
            _automationTextBox = null;
         }

         OnAutomationTextRemoved(EventArgs.Empty);
      }

      void automation_EditContent(object sender, AnnEditContentEventArgs e)
      {
         AnnObject annObject = e.TargetObject;

         if (annObject == null || !annObject.SupportsContent || annObject is AnnSelectionObject)
            return;

         if (sender is AnnDrawDesigner && annObject.Id != AnnObject.StickyNoteObjectId)
            return;

         using (var dlg = new AutomationUpdateObjectDialog())
         {
            dlg.Automation = this.Automation;
            dlg.SetPageVisible(AutomationUpdateObjectDialogPage.Properties, false);
            dlg.SetPageVisible(AutomationUpdateObjectDialogPage.Reviews, false);
            dlg.TargetObject = annObject;

            if (dlg.ShowDialog(this) == DialogResult.OK)
               Automation.InvalidateObject(annObject);
         }
      }

      void automation_UnlockObject(object sender, AnnLockObjectEventArgs e)
      {
         e.Cancel = true;
         //PasswordDialog
         AutomationPasswordDialog passwordDialog = new AutomationPasswordDialog();
         if (passwordDialog.ShowDialog(this) == DialogResult.OK)
         {
            e.Object.Unlock(passwordDialog.Password);

            AnnObject checkObject = null;

            AnnSelectionObject selectionObject = e.Object as AnnSelectionObject;
            if(selectionObject != null)
            {
               if(selectionObject.SelectedObjects.Count > 0)
               {
                  //checking first object is enough
                  checkObject = selectionObject.SelectedObjects[0];
               }
            }
            else
            {
               checkObject = e.Object;
            }

            if (checkObject.IsLocked)
            {
               MessageBox.Show("You've entered an invalid password.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Automation.Invalidate(LeadRectD.Empty);
         }
      }

      void automation_LockObject(object sender, AnnLockObjectEventArgs e)
      {
         AutomationPasswordDialog passwordDialog = new AutomationPasswordDialog();
         passwordDialog.Lock = true;
         if (passwordDialog.ShowDialog(this) == DialogResult.OK)
         {
            e.Password = passwordDialog.Password;
         }
         else
            e.Cancel = true;
      }

      void automation_OnShowObjectProperties(object sender, AnnAutomationEventArgs e)
      {
         using (var dlg = new AutomationUpdateObjectDialog())
         {
            var automation = this.Automation;
            var currentObject = automation.CurrentEditObject;
            var isSelectionObject = currentObject is AnnSelectionObject;

            if (currentObject != null)
            {
               if (!currentObject.SupportsContent || isSelectionObject)
               {
                  dlg.SetPageVisible(AutomationUpdateObjectDialogPage.Content, false);
                  if (isSelectionObject)
                  {
                     dlg.SetPageVisible(AutomationUpdateObjectDialogPage.Reviews, false);
                  }
               }
            }

            dlg.Automation = automation;

            try
            {
               dlg.ShowDialog(this);
               e.Cancel = !dlg.IsModified;
               MainForm.UpdateControls();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
         }
      }

      void automation_OnShowContextMenu(object sender, AnnAutomationEventArgs e)
      {
         if (e != null && e.Object != null)
         {
            _automationControl.AutomationInvalidate(LeadRectD.Empty);
            AnnAutomationObject annAutomationObject = e.Object as AnnAutomationObject;
            if (annAutomationObject != null)
            {
               ObjectContextMenu menu = annAutomationObject.ContextMenu as ObjectContextMenu;
               if (menu != null)
               {
                  menu.Automation = sender as AnnAutomation;
                  menu.Show(this, _viewer.PointToClient(Cursor.Position));
               }
            }
         }
         else
         {
            ManagerContextMenu defaultMenu = new ManagerContextMenu();
            defaultMenu.Automation = sender as AnnAutomation;
            defaultMenu.Collapse += defaultMenu_Collapse;
            defaultMenu.Show(this, _viewer.PointToClient(Cursor.Position));
         }
      }

      private void defaultMenu_Collapse(object sender, EventArgs e)
      {
         MainForm.UpdateControls();
      }

      private void AnnotationsForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         AnnAutomation automation = Automation;
         if (automation != null)
         {
            automation.EditText -= new EventHandler<AnnEditTextEventArgs>(automation_EditText);
            automation.EditContent -= new EventHandler<AnnEditContentEventArgs>(automation_EditContent);
            automation.Container.Children.CollectionChanged -= new EventHandler<AnnNotifyCollectionChangedEventArgs>(Children_CollectionChanged);
            automation.Container.Mapper.FontRelativeToDevice = false;
            automation.AfterObjectChanged -= new EventHandler<AnnAfterObjectChangedEventArgs>(automation_AfterObjectChanged);
            automation.CurrentDesignerChanged -= new EventHandler(automation_CurrentDesignerChanged);
            automation.UndoRedoChanged -= new EventHandler(automation_UndoRedoChanged);
            automation.OnShowContextMenu -= new EventHandler<AnnAutomationEventArgs>(automation_OnShowContextMenu);
            automation.OnShowObjectProperties -= new EventHandler<AnnAutomationEventArgs>(automation_OnShowObjectProperties);
            automation.LockObject -= new EventHandler<AnnLockObjectEventArgs>(automation_LockObject);
            automation.UnlockObject -= new EventHandler<AnnLockObjectEventArgs>(automation_UnlockObject);
            automation.DeserializeObjectError -= new EventHandler<AnnSerializeObjectEventArgs>(automation_DeserializeObjectError);
            automation.SetCursor -= new EventHandler<AnnCursorEventArgs>(automation_SetCursor);
            automation.RestoreCursor -= new EventHandler(automation_RestoreCursor);

            if (!e.Cancel)
            {
               MainForm.AutomationManager.Automations.Remove(automation);
            }
         }
      }


      public void UpdatePaintProperties(RasterPaintProperties paintProperties)
      {
         //_viewer.PaintProperties = paintProperties;
      }

      private void automation_CurrentDesignerChanged(object sender, EventArgs e)
      {
         MainForm.CurrentDesignerChanged();
         MainForm.UpdateControls();
      }

      private void automation_AfterObjectChanged(object sender, AnnAfterObjectChangedEventArgs e)
      {
         if (MainForm.RedactionMessage && e.ChangeType == AnnObjectChangedType.RealizeRedaction)
         {
            Messager.ShowInformation(this, "When restoring a realized redaction object, the redaction object must be in its original location.");
            MainForm.RedactionMessage = false;
         }
         MainForm.UpdateControls();
      }

      void Children_CollectionChanged(object sender, AnnNotifyCollectionChangedEventArgs e)
      {
         MainForm.UpdateControls();
      }

      private void _viewer_MouseMove(object sender, MouseEventArgs e)
      {
         if (Automation != null && Automation.Container != null)
         {
            LeadPointD physical = new LeadPointD(e.X, e.Y);
            LeadPointD logical = Automation.Container.Mapper.PointToContainerCoordinates(physical);
            MainForm.SetStatusBarText(string.Format("{0}, {1} ({2}, {3})", physical.X, physical.Y, logical.X, logical.Y));
         }
         else
            MainForm.SetStatusBarText(string.Format("{0}, {1}", e.X, e.Y));
      }

      private void automation_UndoRedoChanged(object sender, EventArgs e)
      {
         MainForm.UpdateControls();
      }

      private void automation_ImageDirtyChanged(object sender, EventArgs e)
      {
         MainForm.UpdateControls();
      }

      private void _viewer_KeyDown(object sender, KeyEventArgs e)
      {
         if (!e.Handled)
         {
            if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
               e.Handled = true;

               MainForm.Zoom(e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus);
            }
         }
      }

      public void UpdateAntiAlias(bool value)
      {
         _automationControl.AutomationAntiAlias = value;
      }
   }
}
