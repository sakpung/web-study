// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

using Leadtools.Demos;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.Automation;
using Leadtools.Annotations.WinForms;
using Leadtools.Drawing;
using System.Collections;
using Leadtools.Annotations.Rendering;


namespace DocumentWritersDemo
{
   /// <summary>
   /// This control contains an instance of RasterImageViewer plus
   /// a tool strip control for common operations
   /// </summary>
   public partial class ViewerControl : UserControl
   {
      // Minimum and maximum scale percentages allowed
      private const double _minimumViewerScalePercentage = 1;
      private const double _maximumViewerScalePercentage = 6400;

      //Interactive Modes
      ImageViewerNoneInteractiveMode _noneInteractiveMode = null;
      ImageViewerPanZoomInteractiveMode _panInteractiveMode = null;
      ImageViewerZoomToInteractiveMode _zoomToInteractiveMode = null;
      AutomationInteractiveMode _automationInteractiveMode = null;

      // Current interactive mode (with the mouse)
      private ViewerControlInteractiveMode _interactiveMode = ViewerControlInteractiveMode.SelectMode;

      // We will use annotations to draw the objects
      private RasterCodecs _rasterCodecsInstance;
      private AutomationManagerHelper _annotationsHelper;
      private AnnAutomationManager _annAutomationManager;
      private AnnAutomation _annAutomation;

      public ViewerControl()
      {
         InitializeComponent();

         InitInteractiveModes();
      }

      public ImageViewerNoneInteractiveMode noneInteractiveMode
      {
         get { return _noneInteractiveMode; }
         set { _noneInteractiveMode = value; }
      }

      public AutomationInteractiveMode automationInteractiveMode
      {
         get { return _automationInteractiveMode; }
         set { _automationInteractiveMode = value; }
      }

      public ImageViewerZoomToInteractiveMode ZoomToInteractiveMode
      {
         get
         {
            return _zoomToInteractiveMode;
         }
         set
         {
            _zoomToInteractiveMode = value;

         }
      }
      public ImageViewerPanZoomInteractiveMode PanInteractiveMode
      {
         get
         {
            return _panInteractiveMode;
         }
         set
         {
            _panInteractiveMode = value;

         }
      }


      public ImageViewerNoneInteractiveMode NoneInteractiveMod
      {
         get
         {
            return _noneInteractiveMode;
         }
         set
         {
            _noneInteractiveMode = value;

         }
      }

      private void InitInteractiveModes()
      {
         //None
         noneInteractiveMode = new ImageViewerNoneInteractiveMode();
         _rasterImageViewer.InteractiveModes.Add(noneInteractiveMode);

         automationInteractiveMode = new AutomationInteractiveMode();
         automationInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left | System.Windows.Forms.MouseButtons.Right;
         automationInteractiveMode.IdleCursor = Cursors.Default;
         automationInteractiveMode.WorkingCursor = Cursors.Default;
         _rasterImageViewer.InteractiveModes.Add(automationInteractiveMode);

         PanInteractiveMode = new ImageViewerPanZoomInteractiveMode();
         PanInteractiveMode.IdleCursor = Cursors.Hand;
         PanInteractiveMode.WorkingCursor = Cursors.Hand;
         PanInteractiveMode.IsEnabled = false;
         PanInteractiveMode.WorkOnBounds = true;
         PanInteractiveMode.EnablePan = true;
         PanInteractiveMode.EnableZoom = false;
         PanInteractiveMode.EnablePinchZoom = false;
         _rasterImageViewer.InteractiveModes.Add(PanInteractiveMode);

         ZoomToInteractiveMode = new ImageViewerZoomToInteractiveMode();
         ZoomToInteractiveMode.WorkCompleted += new EventHandler(zoomToMode_WorkCompleted);
         ZoomToInteractiveMode.IdleCursor = Cursors.Cross;
         ZoomToInteractiveMode.WorkingCursor = Cursors.Cross;
         ZoomToInteractiveMode.IsEnabled = false;
         ZoomToInteractiveMode.WorkOnBounds = true;
         _rasterImageViewer.InteractiveModes.Add(ZoomToInteractiveMode);

         automationInteractiveMode.IsEnabled = true;
         _rasterImageViewer.InteractiveModes.EnableById(automationInteractiveMode.Id);

      }

      void zoomToMode_WorkCompleted(object sender, EventArgs e)
      {
         BeginInvoke(new MethodInvoker(_selectModeToolStripButton.PerformClick));
      }

      protected override void OnLoad(EventArgs e)
      {
         try
         {
            if (!DesignMode)
            {
               // Use ScaleToGray for optimum viewing
               RasterPaintProperties props = _rasterImageViewer.PaintProperties;
               props.PaintDisplayMode |= RasterPaintDisplayModeFlags.ScaleToGray;
               _rasterImageViewer.PaintProperties = props;

               // Pad the viewer
               Padding padding = _rasterImageViewer.Padding;
               padding.All = 10;
               _rasterImageViewer.Padding = padding;

               // These events are needed and not visible from the designer, so
               // hook into them here
               _pageToolStripTextBox.LostFocus += new EventHandler(_pageToolStripTextBox_LostFocus);

               // Call the transform changed event
               _rasterImageViewer_TransformChanged(_rasterImageViewer, EventArgs.Empty);

               _mousePositionLabel.Text = string.Empty;

               // Initialize the annotation objects
               InitAnnotations();
            }

            base.OnLoad(e);
         }
         catch (Leadtools.RasterException ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      /// <summary>
      /// Called by the main form to get/set the title (the name of the document)
      /// </summary>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public string Title
      {
         get
         {
            return _titleLabel.Text;
         }
         set
         {
            _titleLabel.Text = value;
         }
      }

      /// <summary>
      /// Called by the main form to get/set the title (the name of the document)
      /// </summary>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public RasterCodecs RasterCodecsInstance
      {
         get
         {
            return _rasterCodecsInstance;
         }
         set
         {
            _rasterCodecsInstance = value;
         }
      }

      /// <summary>
      /// Called by the main form to change the page viewing mode (from the main menu)
      /// </summary>
      public void FitPage(bool fitWidth)
      {
         // Since we are doing more than one operation on the viewer, it is
         // recommended to disable then re-enable updates on the viewer to
         // minimize flickering

         _rasterImageViewer.BeginUpdate();

         _rasterImageViewer.Zoom(ControlSizeMode.None, 1, _rasterImageViewer.DefaultZoomOrigin);

         if (fitWidth)
            _rasterImageViewer.Zoom(ControlSizeMode.FitWidth, 1, _rasterImageViewer.DefaultZoomOrigin);
         else
            _rasterImageViewer.Zoom(ControlSizeMode.Fit, 1, _rasterImageViewer.DefaultZoomOrigin);

         _rasterImageViewer.EndUpdate();

         UpdateUIState();
      }

      /// <summary>
      /// Zoom the viewer in our out
      /// </summary>
      /// <param name="zoomOut"></param>
      public void ZoomViewer(bool zoomOut)
      {
         // Get the current scale factor
         double percentage = _rasterImageViewer.ScaleFactor * 100.0;

         // The valid scale factors are here
         double[] validPercentages =
         {
            _minimumViewerScalePercentage, 6.25, 12.5, 25, 33.3, 50, 66.7, 73.6, 92.5, 100,
            125, 150, 200, 300, 400, 600, 800, 1200, 1600, 2400,
            3200, _maximumViewerScalePercentage
         };

         // Find out where we are, move to the next one up or down depending on 'zoomOut'
         if (zoomOut)
         {
            for (int i = validPercentages.Length - 1; i >= 0; i--)
            {
               if (percentage > validPercentages[i])
               {
                  percentage = validPercentages[i];
                  break;
               }
            }
         }
         else
         {
            for (int i = 0; i < validPercentages.Length; i++)
            {
               if (percentage < validPercentages[i])
               {
                  percentage = validPercentages[i];
                  break;
               }
            }
         }

         SetViewerZoomPercentage(percentage);
      }

      /// <summary>
      /// Called by the main form to get the current size mode value
      /// </summary>
      public ControlSizeMode CurrentSizeMode
      {
         get
         {
            return _rasterImageViewer.SizeMode;
         }
      }

      /// <summary>
      /// This event is fired by the control when an action occurs that must be handled by
      /// the owner (the main form)
      /// </summary>
      public event EventHandler<ActionEventArgs> Action;

      /// <summary>
      /// Current interactive mode (what happens when the user uses the mouse on the viewer)
      /// </summary>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public ViewerControlInteractiveMode InteractiveMode
      {
         get
         {
            return _interactiveMode;
         }
         set
         {
            _interactiveMode = value;

            foreach (ImageViewerInteractiveMode mode in _rasterImageViewer.InteractiveModes)
            {
               mode.IsEnabled = false;
            }

            if (_annAutomationManager != null)
            {
               // Set the RasterImageViewer interactive mode accordingly
               switch (_interactiveMode)
               {
                  case ViewerControlInteractiveMode.SelectMode:
                     automationInteractiveMode.IsEnabled = true;
                     _rasterImageViewer.InteractiveModes.EnableById(automationInteractiveMode.Id);
                     Automation.Cancel();
                     break;

                  case ViewerControlInteractiveMode.PanMode:
                     _rasterImageViewer.InteractiveModes.EnableById(PanInteractiveMode.Id);
                     Automation.Cancel();
                     break;
                  case ViewerControlInteractiveMode.ZoomToSelectionMode:
                     _rasterImageViewer.InteractiveModes.EnableById(ZoomToInteractiveMode.Id);
                     Automation.Cancel();
                     break;
               }
            }

            UpdateUIState();
         }
      }

      /// <summary>
      /// Called by the main form to get the automation manager object
      /// </summary>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public AnnAutomationManager AutomationManager
      {
         get
         {
            if (DesignMode)
               return null;

            return _annAutomationManager;
         }
      }

      /// <summary>
      /// Called by the main form to get the automation object
      /// </summary>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public AnnAutomation Automation
      {
         get
         {
            if (DesignMode)
               return null;

            return _annAutomation;
         }
      }

      /// <summary>
      /// Called by the main form to set a new document into the viewer
      /// </summary>
      public void SetDocument(RasterImage image)
      {
         try
         {

            if (_annAutomationManager != null)
            {
               _rasterImageViewer.Image = image;

               //we shoud reset viewer transforms before creating automation and setting its container size
               ResetViewerTransforms();

               //Set Container Size
               if (_annAutomation.Container == null)
               {
                  _annAutomation.Containers.Add(new AnnContainer());
                  _annAutomation.Container.Mapper.MapResolutions(image.XResolution, image.YResolution, image.XResolution, image.YResolution);
               }

               _annAutomation.Container.Size = _annAutomation.Container.Mapper.SizeToContainerCoordinates(LeadSizeD.Create(image.ImageWidth, image.ImageHeight));

               SetViewerTransforms();

               UpdateUIState();
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void SetViewerTransforms()
      {
         _rasterImageViewer.Zoom(ControlSizeMode.Fit, 1, _rasterImageViewer.DefaultZoomOrigin);
         _rasterImageViewer.UseDpi = true;
      }

      private void ResetViewerTransforms()
      {
         _rasterImageViewer.Zoom(ControlSizeMode.ActualSize, 1, _rasterImageViewer.DefaultZoomOrigin);
         _rasterImageViewer.UseDpi = false;
      }

      /// <summary>
      /// Called by the main form to get the image in the viewer
      /// </summary>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public RasterImage RasterImage
      {
         get
         {
            return _rasterImageViewer.Image;
         }
      }

      /// <summary>
      /// Called by the main form to get the viewer
      /// </summary>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public ImageViewer RasterImageViewer
      {
         get
         {
            return _rasterImageViewer;
         }
      }

      /// <summary>
      /// Called by the main form to add a new page to the document
      /// </summary>
      public void AddPage(RasterImage page, int width, int height)
      {
         _rasterImageViewer.Image.AddPage(page);

         ResetViewerTransforms();

         AnnContainer container = new AnnContainer();
         container.Mapper = _annAutomation.Container.Mapper.Clone();
         container.Size = container.Mapper.SizeToContainerCoordinates(LeadSizeD.Create(width, height));

         SetViewerTransforms();

         _annAutomation.Containers.Add(container);
      }

      /// <summary>
      /// Called by the main form to delete the current page
      /// </summary>
      public void DeleteCurrentPage()
      {
         // Delete the current page automation
         int pageNumber = _rasterImageViewer.Image.Page;

         _annAutomation.Containers.RemoveAt(pageNumber - 1);
         _rasterImageViewer.Image.RemovePageAt(pageNumber);
      }

      /// <summary>
      /// Called by the main form when the page number changes
      /// </summary>
      public void SetCurrentPageNumber(int pageNumber)
      {
         try
         {
            //Activate current container and disable All others
            if (_rasterImageViewer.Image != null)
            {
               _rasterImageViewer.Image.Page = pageNumber;
            }

            if (_annAutomation.Containers.Count >= pageNumber)
            {
               var currentContainer = _annAutomation.Containers[pageNumber - 1];
               currentContainer.IsVisible = true;
               currentContainer.IsEnabled = true;

               foreach (var container in _annAutomation.Containers)
               {
                  if (currentContainer == container)
                     continue;

                  container.IsVisible = false;
                  container.IsEnabled = false;
               }

               _annAutomation.ActiveContainer = currentContainer;
            }

            _annAutomation.Invalidate(LeadRectD.Empty);

         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }


      private void MyTestMenuItemHandler(object sender, EventArgs e)
      {
         MessageBox.Show("Test clicked");
      }

      private void CustomizeAutomationMenu()
      {
         AnnAutomationObject autoObj = _annAutomationManager.FindObjectById(AnnObject.LineObjectId);
         if (autoObj != null)
         {
            if (autoObj.ContextMenu != null)
            {
               ObjectContextMenu menu = autoObj.ContextMenu as ObjectContextMenu;
               if (menu != null)
               {
                  menu.MenuItems.RemoveAt(13);  //Unlock
                  menu.MenuItems.RemoveAt(12);  //Lock
                  menu.MenuItems.RemoveAt(11);  //Separator
                  menu.MenuItems.RemoveAt(10);  //Reverse
                  menu.MenuItems.RemoveAt(9);   //Flip
                  menu.MenuItems.RemoveAt(8);   //Separator
               }
            }

            autoObj = _annAutomationManager.FindObjectById(AnnObject.PolygonObjectId);
            if (autoObj != null && autoObj.ObjectTemplate != null)
            {
               AnnPolylineObject polygon = autoObj.ObjectTemplate as AnnPolylineObject;
               polygon.IsClosed = true;
               polygon.FillRule = AnnFillRule.Nonzero;
            }

            autoObj = _annAutomationManager.FindObjectById(AnnObject.ClosedCurveObjectId);
            if (autoObj != null && autoObj.ObjectTemplate != null)
            {
               AnnCurveObject closedCurve = autoObj.ObjectTemplate as AnnCurveObject;
               closedCurve.IsClosed = true;
               closedCurve.FillRule = AnnFillRule.Nonzero;
            }

            // Group
            autoObj = _annAutomationManager.FindObjectById(AnnObject.PolygonObjectId);
            if (autoObj != null && autoObj.ObjectTemplate != null)
            {
               AnnPolylineObject polygon = autoObj.ObjectTemplate as AnnPolylineObject;
               polygon.IsClosed = true;
               polygon.FillRule = AnnFillRule.Nonzero;
            }

            autoObj = _annAutomationManager.FindObjectById(AnnObject.ClosedCurveObjectId);
            if (autoObj != null && autoObj.ObjectTemplate != null)
            {
               AnnCurveObject closedCurve = autoObj.ObjectTemplate as AnnCurveObject;
               closedCurve.IsClosed = true;
               closedCurve.FillRule = AnnFillRule.Nonzero;
            }
            // Group
            autoObj = _annAutomationManager.FindObjectById(AnnObject.GroupObjectId);
            if (autoObj != null)
            {
               ObjectContextMenu menu = new ObjectContextMenu();

               menu = autoObj.ContextMenu as ObjectContextMenu;
               if (menu != null)
               {
                  menu.MenuItems.RemoveAt(16);  //Ungroup
                  menu.MenuItems.RemoveAt(15);  //Group
                  menu.MenuItems.RemoveAt(14);  //Separator
                  menu.MenuItems.RemoveAt(13);  //Unlock
                  menu.MenuItems.RemoveAt(12);  //Lock
                  menu.MenuItems.RemoveAt(11);  //Separator
                  menu.MenuItems.RemoveAt(10);  //Reverse
                  menu.MenuItems.RemoveAt(9);   //Flip
                  menu.MenuItems.RemoveAt(8);   //Separator
               }


               if (menu != null)
               {
                  // Remove the 'Control Points' item
                  menu.MenuItems.RemoveAt(8);
                  menu.MenuItems.RemoveAt(7);
               }

            }
         }

      }

      private void InitAnnotations()
      {
         try
         {
            _annAutomationManager = AnnAutomationManager.Create(new AnnWinFormsRenderingEngine());
            _annotationsHelper = new AutomationManagerHelper(_annAutomationManager);

            // Disable the rotation
            _annAutomationManager.RotateModifierKey = AnnKeys.None;

            _annAutomationManager.CreateDefaultObjects();

            _annAutomation = new AnnAutomation(_annAutomationManager, _rasterImageViewer);
            _annAutomation.OnShowContextMenu += new EventHandler<AnnAutomationEventArgs>(_automation_OnShowContextMenu);
            _annAutomation.OnShowObjectProperties += new EventHandler<AnnAutomationEventArgs>(automation_OnShowObjectProperties);
            _annAutomation.Container.Children.CollectionChanged += new EventHandler<AnnNotifyCollectionChangedEventArgs>(Children_CollectionChanged);
            _annAutomation.AfterObjectChanged += new EventHandler<AnnAfterObjectChangedEventArgs>(automation_AfterObjectChanged);
            _annAutomation.UndoRedoChanged += new EventHandler(automation_UndoRedoChanged);
            _annAutomation.LockObject += _annAutomation_LockObject;
            _annAutomation.UnlockObject += _annAutomation_UnlockObject;
            _annAutomation.Active = true;
            automationInteractiveMode.AutomationControl = _rasterImageViewer;

            // Remove the following automation objects since we will not use them in this
            // demo
            RemoveObject(_annAutomationManager, AnnObject.HotspotObjectId);
            RemoveObject(_annAutomationManager, AnnObject.FreehandHotspotObjectId);
            RemoveObject(_annAutomationManager, AnnObject.ButtonObjectId);
            RemoveObject(_annAutomationManager, AnnObject.AudioObjectId);
            RemoveObject(_annAutomationManager, AnnObject.EncryptObjectId);
            RemoveObject(_annAutomationManager, AnnObject.PointObjectId);
            RemoveObject(_annAutomationManager, AnnObject.RedactionObjectId);
            RemoveObject(_annAutomationManager, AnnObject.TextRollupObjectId);

            // Remove the Flip, reverse, lock, unlock items from the PopUp menus
            // and remove the "Control Points' item form the dfault menu
            CustomizeAutomationMenu();


            // Disable the rotation points
            foreach (AnnAutomationObject autObj in _annAutomationManager.Objects)
               autObj.UseRotateThumbs = false;

            _annotationsHelper.CreateToolBar();

            ToolBar tb = _annotationsHelper.ToolBar;
            tb.AutoSize = true;
            tb.Dock = DockStyle.Right;
            this.Controls.Add(tb);
            tb.BringToFront();
            tb.Appearance = ToolBarAppearance.Flat;

            _rasterImageViewer.BringToFront();
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      void _annAutomation_LockObject(object sender, AnnLockObjectEventArgs e)
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
      void _annAutomation_UnlockObject(object sender, AnnLockObjectEventArgs e)
      {
         e.Cancel = true;
         //PasswordDialog
         AutomationPasswordDialog passwordDialog = new AutomationPasswordDialog();
         if (passwordDialog.ShowDialog(this) == DialogResult.OK)
         {
            e.Object.Unlock(passwordDialog.Password);
            if (e.Object.IsLocked)
            {
               MessageBox.Show("You've entered an invalid password.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Automation.Invalidate(LeadRectD.Empty);
         }
      }

      private static void RemoveObject(AnnAutomationManager automationManager, int objectId)
      {
         for (int i = 0; i < automationManager.Objects.Count; i++)
         {
            if (automationManager.Objects[i].Id == objectId)
            {
               automationManager.Objects.RemoveAt(i);
               return;
            }
         }
      }

      void automation_OnShowObjectProperties(object sender, AnnAutomationEventArgs e)
      {
         AnnAutomation automation = sender as AnnAutomation;

         using (var dlg = new AutomationUpdateObjectDialog())
         {
            if (automation.CurrentEditObject != null)
            {
               // If stick note or text, hide the note
               if (automation.CurrentEditObject.Id == AnnObject.StickyNoteObjectId || automation.CurrentEditObject is AnnTextObject)
               {
                  // if text object, we cannot do that. Ignore, the EditText will fire
                  dlg.SetPageVisible(AutomationUpdateObjectDialogPage.Content, false);
               }
            }

            dlg.Automation = automation;

            try
            {
               dlg.ShowDialog(this);
               e.Cancel = !dlg.IsModified;
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
         }
      }

      void _automation_OnShowContextMenu(object sender, AnnAutomationEventArgs e)
      {
         if (e != null && e.Object != null)
         {
            _rasterImageViewer.AutomationInvalidate(LeadRectD.Empty);
            AnnAutomationObject annAutomationObject = e.Object as AnnAutomationObject;
            if (annAutomationObject != null)
            {
               ObjectContextMenu menu = annAutomationObject.ContextMenu as ObjectContextMenu;
               if (menu != null)
               {
                  menu.Automation = sender as AnnAutomation;
                  menu.Show(this, RasterImageViewer.PointToClient(Cursor.Position));
               }
            }
         }
         else
         {
            ManagerContextMenu defaultMenu = new ManagerContextMenu();
            defaultMenu.Automation = sender as AnnAutomation;
            defaultMenu.Show(this, _rasterImageViewer.PointToClient(Cursor.Position));
         }
      }
      void Children_CollectionChanged(object sender, AnnNotifyCollectionChangedEventArgs e)
      {
         UpdateAll();
      }

      private void automation_UndoRedoChanged(object sender, EventArgs e)
      {
         UpdateAll();
      }

      private void automation_AfterObjectChanged(object sender, AnnAfterObjectChangedEventArgs e)
      {
         UpdateAll();
      }

      private void UpdateAll()
      {
         BeginInvoke(new MethodInvoker(DoUpdate));
      }

      private void DoUpdate()
      {
         UpdateUIState();
         DoAction("UpdateUIState", null);
      }

      private void UpdateZoomValueFromControl()
      {
         // We are invoking this instead of changing the properties
         // directly because the Text value of a combo box is not
         // updated till after the lost focus or enter event is exited
         BeginInvoke(new MethodInvoker(delegate()
         {
            if (_rasterImageViewer.Image != null)
            {
               double factor = _rasterImageViewer.ScaleFactor * 100.0;
               _zoomToolStripComboBox.Text = factor.ToString("F1") + "%";
            }
            else
            {
               _zoomToolStripComboBox.Text = string.Empty;
            }
         }));
      }

      private void UpdateUIState()
      {
         // Update the UI controls states

         _fitPageWidthToolStripButton.Checked = _rasterImageViewer.SizeMode == ControlSizeMode.FitWidth;
         _fitPageToolStripButton.Checked = _rasterImageViewer.SizeMode == ControlSizeMode.Fit;

         _selectModeToolStripButton.Checked = _interactiveMode == ViewerControlInteractiveMode.SelectMode;
         _panModeToolStripButton.Checked = _interactiveMode == ViewerControlInteractiveMode.PanMode;
         _zoomToSelectionModeToolStripButton.Checked = _interactiveMode == ViewerControlInteractiveMode.ZoomToSelectionMode;

         AnnAutomation automation = Automation;
         if (automation != null)
         {
            _bringToFrontToolStripButton.Enabled = automation.CanBringToFront;
            _sendToBackToolStripButton.Enabled = automation.CanSendToBack;
            _bringToFirstToolStripButton.Enabled = automation.CanBringToFirst;
            _sendToLastToolStripButton.Enabled = automation.CanSendToLast;
            _propertiesToolStripButton.Enabled = automation.CanShowObjectProperties;
         }
         else
         {
            _bringToFrontToolStripButton.Enabled = false;
            _sendToBackToolStripButton.Enabled = false;
            _bringToFirstToolStripButton.Enabled = false;
            _sendToLastToolStripButton.Enabled = false;
            _propertiesToolStripButton.Enabled = false;
         }

         if (_rasterImageViewer.Image != null)
         {
            if (!_toolStrip.Enabled)
               _toolStrip.Enabled = true;

            int currentPage = _rasterImageViewer.Image.Page;
            int pageCount = _rasterImageViewer.Image.PageCount;

            _pageToolStripTextBox.Text = currentPage.ToString();
            _pageToolStripLabel.Text = "/ " + pageCount.ToString();

            _previousPageToolStripButton.Enabled = currentPage > 1;
            _nextPageToolStripButton.Enabled = currentPage < pageCount;
         }
         else
         {
            _pageToolStripTextBox.Text = "0";
            _pageToolStripLabel.Text = "/ 0";

            _zoomToolStripComboBox.Text = string.Empty;

            _toolStrip.Enabled = false;
         }
      }

      private void _rasterImageViewer_TransformChanged(object sender, EventArgs e)
      {
         if (!DesignMode && IsHandleCreated)
         {
            UpdateZoomValueFromControl();
            UpdateUIState();
         }
      }

      private void _previousPageToolStripButton_Click(object sender, EventArgs e)
      {
         TryGotoPage(_rasterImageViewer.Image.Page - 1);
      }

      private void _nextPageToolStripButton_Click(object sender, EventArgs e)
      {
         TryGotoPage(_rasterImageViewer.Image.Page + 1);
      }

      private void _pageToolStripTextBox_LostFocus(object sender, EventArgs e)
      {
         _pageToolStripTextBox.Text = _rasterImageViewer.Image.Page.ToString();
      }

      private void _pageToolStripTextBox_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (e.KeyChar == (char)Keys.Return)
         {
            // User has pressed enter, go to the new page number

            string str = _pageToolStripTextBox.Text.Trim();

            // Try to parse the integer value
            int pageNumber;
            if (int.TryParse(str, out pageNumber))
               TryGotoPage(pageNumber);

            _pageToolStripTextBox.Text = _rasterImageViewer.Image.Page.ToString();
         }
      }

      private void TryGotoPage(int pageNumber)
      {
         // Check if the index is valid
         if (pageNumber >= 1 && pageNumber <= _rasterImageViewer.Image.PageCount)
         {
            // Yes, fire the event to the main form
            DoAction("PageNumberChanged", pageNumber);
         }
      }

      private void _zoomOutToolStripButton_Click(object sender, EventArgs e)
      {
         ZoomViewer(true);
      }

      private void _zoomInToolStripButton_Click(object sender, EventArgs e)
      {
         ZoomViewer(false);
      }

      private void _zoomToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         // Parse the new zoom value
         string str = _zoomToolStripComboBox.Text.Trim();

         switch (str)
         {
            case "Actual Size":
               SetViewerZoomPercentage(100);
               break;

            case "Fit Page":
               _fitPageToolStripButton.PerformClick();
               break;

            case "Fit Width":
               _fitPageWidthToolStripButton.PerformClick();
               break;

            default:
               if (!string.IsNullOrEmpty(str))
               {
                  double val = double.Parse(str.Substring(0, str.Length - 1));
                  SetViewerZoomPercentage(val);
               }
               break;
         }
      }

      private void _zoomToolStripComboBox_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (e.KeyChar == (char)Keys.Return)
         {
            // User has pressed enter, parse the new zoom value

            string str = _zoomToolStripComboBox.Text.Trim();

            if (!string.IsNullOrEmpty(str))
            {
               // Remove the % sign if present
               if (str.EndsWith("%"))
                  str = str.Remove(str.Length - 1, 1).Trim();

               // Try to parse the new zoom value
               double percentage;
               if (double.TryParse(str, out percentage))
                  SetViewerZoomPercentage(percentage);

               UpdateZoomValueFromControl();
            }
         }
      }

      private void SetViewerZoomPercentage(double percentage)
      {
         // Normalize the percentage based on min/max value allowed
         percentage = Math.Max(_minimumViewerScalePercentage, Math.Min(_maximumViewerScalePercentage, percentage));

         if (Math.Abs(_rasterImageViewer.ScaleFactor * 100.0 - percentage) > 0.01)
         {
            // Save the current center location in the viewer, we will use it later to
            // re-center the viewer

            LeadRectD LeadPhysicalViewRectangle = _rasterImageViewer.GetItemViewBounds(_rasterImageViewer.ActiveItem, ImageViewerItemPart.Image, true);
            LeadRectD LeadLogicalViewRectangle = _rasterImageViewer.GetItemBounds(_rasterImageViewer.ActiveItem, ImageViewerItemPart.Image);

            Rectangle PhysicalViewRectangle = new Rectangle((int)LeadPhysicalViewRectangle.Left, (int)LeadPhysicalViewRectangle.Top, (int)LeadPhysicalViewRectangle.Width, (int)LeadPhysicalViewRectangle.Height);
            Rectangle LogicalViewRectangle = new Rectangle((int)LeadLogicalViewRectangle.Left, (int)LeadLogicalViewRectangle.Top, (int)LeadLogicalViewRectangle.Width, (int)LeadLogicalViewRectangle.Height);

            Rectangle rc = Rectangle.Intersect(PhysicalViewRectangle, LogicalViewRectangle);
            PointF center = new PointF(rc.Left + rc.Width / 2, rc.Top + rc.Right / 2);

            LeadMatrix LeadM = _rasterImageViewer.ImageTransform;
            Matrix M = new Matrix((float)LeadM.M11, (float)LeadM.M12, (float)LeadM.M21, (float)LeadM.M22, (float)LeadM.OffsetX, (float)LeadM.OffsetY);
            Transformer trans = new Transformer(M);
            center = trans.PointToLogical(center);

            _rasterImageViewer.BeginUpdate();

            // Switch to normal size mode if we are not in it
            if (_rasterImageViewer.SizeMode != ControlSizeMode.ActualSize)
               _rasterImageViewer.Zoom(ControlSizeMode.ActualSize, 1, _rasterImageViewer.DefaultZoomOrigin);

            // Zoom
            _rasterImageViewer.Zoom(ControlSizeMode.None, percentage / 100.0, _rasterImageViewer.DefaultZoomOrigin);

            // Go back to original center point
            LeadM = _rasterImageViewer.ImageTransform;
            M = new Matrix((float)LeadM.M11, (float)LeadM.M12, (float)LeadM.M21, (float)LeadM.M22, (float)LeadM.OffsetX, (float)LeadM.OffsetY);
            trans.Transform = M;
            center = trans.PointToPhysical(center);

            _rasterImageViewer.CenterAtPoint(LeadPoint.Create((int)center.X, (int)center.Y));

            _rasterImageViewer.EndUpdate();

            _rasterImageViewer_TransformChanged(_rasterImageViewer, EventArgs.Empty);

            UpdateUIState();
         }
      }

      private void _fitPageWidthToolStripButton_Click(object sender, EventArgs e)
      {
         FitPage(true);
      }

      private void _fitPageToolStripButton_Click(object sender, EventArgs e)
      {
         FitPage(false);
      }

      private void _selectModeToolStripButton_Click(object sender, EventArgs e)
      {
         InteractiveMode = ViewerControlInteractiveMode.SelectMode;
      }

      private void _panModeToolStripButton_Click(object sender, EventArgs e)
      {
         InteractiveMode = ViewerControlInteractiveMode.PanMode;
      }

      private void _zoomToSelectionModeToolStripButton_Click(object sender, EventArgs e)
      {
         InteractiveMode = ViewerControlInteractiveMode.ZoomToSelectionMode;
      }


      private void _bringToFrontToolStripButton_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = Automation;
         automation.BringToFront(false);
      }

      private void _sendToBackToolStripButton_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = Automation;
         automation.SendToBack(false);
      }

      private void _bringToFirstToolStripButton_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = Automation;
         automation.BringToFront(true);
      }

      private void _sendToLastToolStripButton_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = Automation;
         automation.SendToBack(false);
      }

      private void _propertiesToolStripButton_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = Automation;
         automation.ShowObjectProperties();
      }

      private void DoAction(string action, object data)
      {
         // Raise the action event so the main form can handle it

         if (Action != null)
            Action(this, new ActionEventArgs(action, data));
      }

      private void _rasterImageViewer_MouseMove(object sender, MouseEventArgs e)
      {
         string str;

         if (_rasterImageViewer.Image != null)
         {
            // Show the mouse position in physical and logical (inches) coordinates

            PointF physical = new PointF(e.X, e.Y);
            PointF pixels;

            LeadMatrix LeadM = _rasterImageViewer.ImageTransform;
            Matrix M = new Matrix((float)LeadM.M11, (float)LeadM.M12, (float)LeadM.M21, (float)LeadM.M22, (float)LeadM.OffsetX, (float)LeadM.OffsetY);
            Transformer trans = new Transformer(M);
            pixels = trans.PointToLogical(physical);

            // Convert the logical point to inches            
            LeadPointD inches = Automation.Container.Mapper.PointFromContainerCoordinates(LeadPointD.Create((int)pixels.X, (int)pixels.Y), AnnFixedStateOperations.Scrolling | AnnFixedStateOperations.Zooming);

            str = string.Format("{0},{1} px {2},{3} in", (int)pixels.X, (int)pixels.Y, inches.X.ToString("F02"), inches.Y.ToString("F02"));
         }
         else
            str = string.Empty;

         _mousePositionLabel.Text = str;
      }

      private void _rasterImageViewer_MouseDown(object sender, MouseEventArgs e)
      {

         PointF physical = new PointF(e.X, e.Y);
         PointF pixels;

         LeadMatrix LeadM = _rasterImageViewer.ImageTransform;
         Matrix M = new Matrix((float)LeadM.M11, (float)LeadM.M12, (float)LeadM.M21, (float)LeadM.M22, (float)LeadM.OffsetX, (float)LeadM.OffsetY);
         Transformer trans = new Transformer(M);
         pixels = trans.PointToLogical(physical);


         Point bookmarkPosition = new Point((int)pixels.X, (int)pixels.Y);

         if (pixels.X < 0)
            bookmarkPosition.X = 0;
         if (pixels.X > _rasterImageViewer.Image.Width)
            bookmarkPosition.X = _rasterImageViewer.Image.Width;

         if (pixels.Y < 0)
            bookmarkPosition.Y = 0;
         if (pixels.Y > _rasterImageViewer.Image.Height)
            bookmarkPosition.Y = _rasterImageViewer.Image.Height;

         DoAction("UpdateBookmarkPosition", bookmarkPosition);

      }
   }
}
