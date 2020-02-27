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

using Leadtools;
using Leadtools.Controls;
using Leadtools.Ocr;
using Leadtools.Annotations.Automation;
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.Designers;
using Leadtools.Annotations.WinForms;
using Leadtools.Drawing;

namespace OcrDemo.ViewerControl
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
      private AutomationInteractiveMode _automationInteractiveMode = null;
      private ImageViewerPanZoomInteractiveMode _panInteractiveMode = null;
      private ImageViewerZoomToInteractiveMode _zoomToInteractiveMode = null;
      private ImageViewerNoneInteractiveMode _noneInteractiveMode = null;

      // Current 0-based page index and number of pages
      private int _currentPageIndex = -1;
      private int _pageCount = 0;

      // Current interactive mode (with the mouse)
      private ViewerControlInteractiveMode _interactiveMode = ViewerControlInteractiveMode.SelectMode;

      // Current OCR page
      private IOcrPage _ocrPage;

      // Current document title
      private string _title;

      // We will use annotations to paint and edit the zones
      private AnnAutomationManager _annAutomationManager;
      private AnnAutomation _annAutomation;
      private AutomationManagerHelper _automationManagerHelper = null;

      private bool _ignoreAddRemove;
      private bool _setSelect;

      public ViewerControl()
      {
         InitializeComponent();
      }

      protected override void OnLoad(EventArgs e)
      {
         if(!DesignMode)
         {
            // Use ScaleToGray and Bicubic for optimum viewing of black/white and color images
            RasterPaintProperties props = _rasterImageViewer.PaintProperties;
            props.PaintDisplayMode |= RasterPaintDisplayModeFlags.ScaleToGray | RasterPaintDisplayModeFlags.Bicubic;
            _rasterImageViewer.PaintProperties = props;

            // Pad the viewer
            _rasterImageViewer.ViewMargin = new Padding(10);
            _rasterImageViewer.ViewBorderThickness = 1;
            _automationInteractiveMode = new AutomationInteractiveMode();
            _noneInteractiveMode = new ImageViewerNoneInteractiveMode();
            _panInteractiveMode = new ImageViewerPanZoomInteractiveMode();
            _panInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left;
            _panInteractiveMode.IdleCursor = Cursors.Hand;
            _panInteractiveMode.WorkingCursor = Cursors.Hand;
            _zoomToInteractiveMode = new ImageViewerZoomToInteractiveMode();
            _zoomToInteractiveMode.RubberBandCompleted += new EventHandler<ImageViewerRubberBandEventArgs>(_rasterImageViewer_InteractiveZoomTo);

            _rasterImageViewer.InteractiveModes.BeginUpdate();
            _rasterImageViewer.InteractiveModes.Add(_noneInteractiveMode);
            _rasterImageViewer.InteractiveModes.Add(_automationInteractiveMode);
            _rasterImageViewer.InteractiveModes.Add(_panInteractiveMode);
            _rasterImageViewer.InteractiveModes.Add(_zoomToInteractiveMode);
            _rasterImageViewer.InteractiveModes.EndUpdate();

            DisableInteractiveModes();

            _rasterImageViewer.InteractiveModes.EnableById(_automationInteractiveMode.Id);

            // These events are needed and not visible from the designer, so
            // hook into them here
            _zoomToolStripComboBox.LostFocus += new EventHandler(_zoomToolStripComboBox_LostFocus);
            _pageToolStripTextBox.LostFocus += new EventHandler(_pageToolStripTextBox_LostFocus);

            // Call the transform changed event
            _rasterImageViewer_TransformChanged(_rasterImageViewer, EventArgs.Empty);

            FitPage(false);

            _mousePositionLabel.Text = string.Empty;

            // Initialize the annotation objects
            InitAnnotations();
         }

         base.OnLoad(e);
      }

      public void DisableInteractiveModes()
      {
         foreach (ImageViewerInteractiveMode mode in _rasterImageViewer.InteractiveModes)
         {
            mode.IsEnabled = false;
         }
      }

      void _rasterImageViewer_InteractiveZoomTo(object sender, ImageViewerRubberBandEventArgs e)
      {
         // Go back to selection mode
         // We must invoke this because the select button will change the
         // interactive mode of the viewer and hence, cancel the current
         // operation
         BeginInvoke(new MethodInvoker(_selectModeToolStripButton.PerformClick));
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
            _title = value;
            UpdateTitle();
         }
      }

      /// <summary>
      /// Called by the main form to set the current 0-based page index and number of pages
      /// </summary>
      public void SetPages(int currentPageIndex, int pageCount)
      {
         _currentPageIndex = currentPageIndex;
         _pageCount = pageCount;
         UpdateUIState();
      }

      /// <summary>
      /// Called by the main form to get the current raster image
      /// </summary>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public RasterImage RasterImage
      {
         get { return _rasterImageViewer.Image; }
      }

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public AutomationImageViewer ImageViewer
      {
         get { return _rasterImageViewer; }
      }

      /// <summary>
      /// Called by the main form to set the new raster image and OCR page
      /// </summary>
      /// <param name="image"></param>
      /// <param name="ocrPage"></param>
      public void SetImageAndPage(RasterImage image, IOcrPage ocrPage)
      {
         _ocrPage = ocrPage;
         var options = _rasterImageViewer.AutoResetOptions; // save
         _rasterImageViewer.AutoResetOptions = ImageViewerAutoResetOptions.None;
         _rasterImageViewer.Image = image;
         _rasterImageViewer.AutoResetOptions = options;

         if (image != null)
         {
            AnnContainerMapper saveMapper = _annAutomation.Container.Mapper.Clone();
            AnnContainerMapper identityMapper = new AnnContainerMapper(saveMapper.SourceDpiX, saveMapper.SourceDpiY, saveMapper.SourceDpiX, saveMapper.SourceDpiY);
            identityMapper.UpdateTransform(LeadMatrix.Identity);

            _annAutomation.Container.Mapper = identityMapper;

            //Set Container Size
            if (_annAutomation != null)
               _annAutomation.Container.Size = identityMapper.SizeToContainerCoordinates(LeadSizeD.Create(image.ImageWidth, image.ImageHeight));

            _annAutomation.Container.Mapper = saveMapper;

            // Converts the zones to annotation objects
            ZonesUpdated();
            _rasterImageViewer.ViewBorderThickness = 1;
         }
         else
         {
            _rasterImageViewer.ViewBorderThickness = 0;
         }

         UpdateTitle();
         UpdateUIState();
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
         
         if(fitWidth)
            _rasterImageViewer.Zoom(ControlSizeMode.FitWidth,1,_rasterImageViewer.DefaultZoomOrigin);
         else
            _rasterImageViewer.Zoom(ControlSizeMode.FitAlways,1,_rasterImageViewer.DefaultZoomOrigin);

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
         double percentage = _rasterImageViewer.XScaleFactor * 100.0;

         // The valid scale factors are here
         double[] validPercentages =
         {
            _minimumViewerScalePercentage, 6.25, 12.5, 25, 33.3, 50, 66.7, 73.6, 92.5, 100,
            125, 150, 200, 300, 400, 600, 800, 1200, 1600, 2400,
            3200, _maximumViewerScalePercentage
         };

         // Find out where we are, move to the next one up or down depending on 'zoomOut'
         if(zoomOut)
         {
            for(int i = validPercentages.Length - 1; i >= 0; i--)
            {
               if(percentage > validPercentages[i])
               {
                  percentage = validPercentages[i];
                  break;
               }
            }
         }
         else
         {
            for(int i = 0; i < validPercentages.Length; i++)
            {
               if(percentage < validPercentages[i])
               {
                  percentage = validPercentages[i];
                  break;
               }
            }
         }

         SetViewerZoomPercentage(percentage);
         ZonesUpdated();
      }

      /// <summary>
      /// Called by the main form to get the current size mode value
      /// </summary>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
            if(_annAutomationManager != null)
            {
               // Set the RasterImageViewer interactive mode accordingly
               switch (_interactiveMode)
               {
                  case ViewerControlInteractiveMode.SelectMode:
                     _rasterImageViewer.InteractiveModes.EnableById(_automationInteractiveMode.Id);
                     _annAutomationManager.CurrentObjectId = AnnObject.None;
                     _annAutomation.Cancel();
                     break;

                  case ViewerControlInteractiveMode.PanMode:
                     _rasterImageViewer.InteractiveModes.EnableById(_panInteractiveMode.Id);
                     _annAutomationManager.CurrentObjectId = AnnObject.None;
                     _annAutomation.Cancel();
                     break;

                  case ViewerControlInteractiveMode.ZoomToSelectionMode:
                     _rasterImageViewer.InteractiveModes.EnableById(_zoomToInteractiveMode.Id);
                     _annAutomationManager.CurrentObjectId = AnnObject.None;
                     _annAutomation.Cancel();
                     break;

                  case ViewerControlInteractiveMode.DrawZoneMode:
                     _rasterImageViewer.InteractiveModes.EnableById(_automationInteractiveMode.Id);
                     _annAutomationManager.CurrentObjectId = AnnObject.UserObjectId;
                     break;
               }
            }

            UpdateUIState();
         }
      }

      /// <summary>
      /// Called by the main form to show/hide the zones
      /// </summary>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool ShowZones
      {
         get
         {
            return _showZonesToolStripButton.Checked;
         }
         set
         {
            _showZonesToolStripButton.Checked = value;

            // Show hide the zones
            if(_annAutomation != null)
            {
               _annAutomation.Cancel();

               foreach(AnnObject obj in _annAutomation.Container.Children)
                  obj.IsVisible = value;
            }

            if(!_showZonesToolStripButton.Checked && _interactiveMode == ViewerControlInteractiveMode.DrawZoneMode)
               _interactiveMode = ViewerControlInteractiveMode.SelectMode;

            _rasterImageViewer.Invalidate();
            UpdateUIState();
         }
      }

      /// <summary>
      /// Called by the main form to show/hide the zone names
      /// </summary>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool ShowZoneNames
      {
         get
         {
            return _showZoneNameToolStripButton.Checked;
         }
         set
         {
            _showZoneNameToolStripButton.Checked = value;

            // Show hide the zones
            if(_annAutomation != null)
            {
               foreach (ZoneAnnotationObject obj in _annAutomation.Container.Children)
                  obj.Label.IsVisible = value;
            }

            _rasterImageViewer.Invalidate();
            UpdateUIState();
         }
      }

      /// <summary>
      /// Called from the main form when the zones are updated
      /// </summary>
      public void ZonesUpdated()
      {
         // Stop updating the viewer
         _rasterImageViewer.BeginUpdate();

         // Remove all the annotations objects and re-add them from the zones
         if (_annAutomation != null)
         {
            _annAutomation.Cancel();
            _annAutomation.Container.Children.Clear();
         }

         _ignoreAddRemove = true;
         _setSelect = true;
         // Get the rectangle automation object so we can use the template
         // to create the new annotation objects

         bool isVisible = _showZonesToolStripButton.Checked && !MainForm.PerspectiveDeskewActive && !MainForm.UnWarpActive;
         bool isNameVisible = _showZoneNameToolStripButton.Checked;

         if (_ocrPage != null && _ocrPage.Zones != null && _ocrPage.Zones.Count > 0)
         {
            for (int i = 0; i < _ocrPage.Zones.Count; i++)
            {
               OcrZone zone = _ocrPage.Zones[i];

               ZoneAnnotationObject zoneObject = new ZoneAnnotationObject();
               zoneObject.SetZone(_ocrPage, i, isVisible, isNameVisible);

               _annAutomation.Container.Children.Add(zoneObject);

               // Now we can calculate the object bounds correctly
               LeadRect rc = zone.Bounds;
               LeadRectD rect = BoundsToAnnotations(zoneObject, rc, _annAutomation.Container);
               zoneObject.Rect = rect;
            }
         }

         _ignoreAddRemove = false;

         // Re-update the viewer
         _rasterImageViewer.EndUpdate();

         _rasterImageViewer.Invalidate();
         UpdateUIState();
      }

      public void ClearZones()
      {
         _rasterImageViewer.BeginUpdate();
         _annAutomation.Container.Children.Clear();
         _rasterImageViewer.EndUpdate();
      }

      private LeadRect BoundsFromAnnotations(AnnRectangleObject rectObject, AnnContainer container)
      {
         // Convert a rectangle from annotation object to logical coordinates (top-left)
         LeadRectD temp = container.Mapper.RectFromContainerCoordinates(rectObject.Rect, AnnFixedStateOperations.None);
         if (temp.IsEmpty) return LeadRect.Empty;

         temp = _rasterImageViewer.ConvertRect(null, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, temp);
         LeadRect rect = temp.ToLeadRect();
         return rect;
      }

      private LeadRectD BoundsToAnnotations(AnnRectangleObject rectObject, LeadRect rect, AnnContainer container)
      {
         // Convert a rectangle from logical (top-left) to annotation object coordinates
         LeadRectD rc = rect.ToLeadRectD();
         rc = _rasterImageViewer.ConvertRect(null, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, rc);
         rc = container.Mapper.RectToContainerCoordinates(rc);
         return rc;
      }

      /// <summary>
      /// Called by the main form to get/set the selected zone index
      /// </summary>
      public int SelectedZoneIndex
      {
         get
         {
            // Get it from the current edit object in the annotations
            int index = -1;

            ZoneAnnotationObject zoneObj = _annAutomation.CurrentEditObject as ZoneAnnotationObject;
            if (zoneObj != null)
               index = zoneObj.ZoneIndex;

            return index;
         }
      }

      AnnAutomationObject CreateZoneAutomationObject()
      {
         AnnAutomationObject automationObj = new AnnAutomationObject();
         ZoneAnnotationObject zoneAnnotationObject = new ZoneAnnotationObject();

         AnnAutomationObject rectAutomationObject = GetAutomationObject(_annAutomationManager, AnnObject.RectangleObjectId);
         AnnRectangleObject rectObject = rectAutomationObject.ObjectTemplate as AnnRectangleObject;

         zoneAnnotationObject.Stroke = rectObject.Stroke != null ? rectObject.Stroke.Clone() as AnnStroke : null;
         zoneAnnotationObject.Fill = rectObject.Fill != null ? rectObject.Fill.Clone() as AnnBrush : null;
         zoneAnnotationObject.CellPen = AnnStroke.Create(AnnSolidColorBrush.Create("Blue"), new LeadLengthD(1));

         automationObj.Id = AnnObject.UserObjectId;
         automationObj.Name = zoneAnnotationObject.FriendlyName;
         automationObj.ObjectTemplate = zoneAnnotationObject;
         automationObj.DrawDesignerType = rectAutomationObject.DrawDesignerType;
         automationObj.EditDesignerType = typeof(ZoneAnnotationObjectEditDesigner);
         automationObj.RunDesignerType = rectAutomationObject.RunDesignerType;
         automationObj.DrawCursor = rectAutomationObject.DrawCursor;

         // Disable the rotation points
         automationObj.UseRotateThumbs = false;
         return automationObj;

      }
      private void InitAnnotations()
      {
         _annAutomationManager = new AnnAutomationManager();

         // Disable the rotation
         _annAutomationManager.RotateModifierKey = AnnKeys.None;
         _annAutomationManager.EditObjectAfterDraw = false;

         _annAutomationManager.CreateDefaultObjects();

         _annAutomation = new AnnAutomation(_annAutomationManager, _rasterImageViewer);
         _annAutomation.AfterObjectChanged += new EventHandler<AnnAfterObjectChangedEventArgs>(_annAutomation_AfterObjectChanged);
         _annAutomation.Container.ObjectAdded += new EventHandler<AnnObjectCollectionEventArgs>(_annAutomationObjects_ItemAdded);
         _annAutomation.Container.ObjectRemoved += new EventHandler<AnnObjectCollectionEventArgs>(_annAutomationObjects_ItemRemoved);
         _annAutomation.OnShowContextMenu += new EventHandler<AnnAutomationEventArgs>(_annAutomation_OnShowContextMenu);
         _annAutomation.Draw += new EventHandler<AnnDrawDesignerEventArgs>(_annAutomation_Draw);
         _annAutomation.SetCursor += new EventHandler<AnnCursorEventArgs>(_annAutomation_SetCursor);
         _annAutomation.RestoreCursor += new EventHandler(_annAutomation_RestoreCursor);
         // We are not going to do undo/redeo
         _annAutomation.UndoCapacity = 0;
         // Set this as the one and only active automation object so mouse and keyboard events
         // get to it
         _annAutomation.Active = true;
         _annAutomation.DefaultCurrentObjectId = AnnObject.None;


         // Get the rectangle and select objects
         AnnAutomationObject selectAutomationObject = GetAutomationObject(_annAutomationManager, AnnObject.SelectObjectId);

         AnnAutomationObject zoneAutomationObject = CreateZoneAutomationObject();
         _automationManagerHelper = new AutomationManagerHelper(_annAutomationManager);

         ZoneAnnotationObjectRenderer zoneObjectRenderer = new ZoneAnnotationObjectRenderer();
         IAnnObjectRenderer annRectangleObjectRenderer = _annAutomationManager.RenderingEngine.Renderers[AnnObject.RectangleObjectId];
         zoneObjectRenderer.LocationsThumbStyle = annRectangleObjectRenderer.LocationsThumbStyle;
         zoneObjectRenderer.RotateCenterThumbStyle = annRectangleObjectRenderer.RotateCenterThumbStyle;
         zoneObjectRenderer.RotateGripperThumbStyle = annRectangleObjectRenderer.RotateGripperThumbStyle;

         _annAutomationManager.Objects.Clear();

         ContextMenu cm = new ContextMenu();
         cm.MenuItems.Add(new MenuItem("&Delete", _zoneDeleteMenuItem_Click));
         cm.MenuItems.Add(new MenuItem("-", null as EventHandler));
         cm.MenuItems.Add(new MenuItem("&Properties...", _zonePropertiesMenuItem_Click));

         zoneAutomationObject.ContextMenu = cm;

         _annAutomationManager.RenderingEngine.Renderers[AnnObject.UserObjectId] = zoneObjectRenderer;

         _annAutomationManager.Objects.Add(selectAutomationObject);
         _annAutomationManager.Objects.Add(zoneAutomationObject);

         // Disable Annotation selection object since we don't want users to group annotation objects.
         var selectionObject = _annAutomationManager.FindObjectById(AnnObject.SelectObjectId);
         selectionObject.DrawDesignerType = null;
      }

      void _annAutomation_RestoreCursor(object sender, EventArgs e)
      {
         if (_rasterImageViewer.Cursor != Cursors.Default)
            _rasterImageViewer.Cursor = Cursors.Default;
      }

      private void _annAutomation_SetCursor(object sender, AnnCursorEventArgs e)
      {
         // If there's an interactive mode working and its not automation, then don't do anything
         if (!_automationInteractiveMode.IsEnabled)
            return;

         Cursor newCursor = null;

         switch (e.DesignerType)
         {
            case AnnDesignerType.Draw:
               {
                  newCursor = Cursors.Cross;
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

         if (_rasterImageViewer.Cursor != newCursor)
            _rasterImageViewer.Cursor = newCursor;
      }

      private static AnnAutomationObject GetAutomationObject(AnnAutomationManager automationManager, int id)
      {
         foreach(AnnAutomationObject obj in automationManager.Objects)
         {
            if(obj.Id == id)
               return obj;
         }

         return null;
      }

      private static LeadRect RestrictZoneBoundsToPage(IOcrPage ocrPage, LeadRect bounds)
      {
         if (bounds.IsEmpty) return bounds;

         LeadRect pageBounds = new LeadRect(0, 0, ocrPage.Width, ocrPage.Height);
         bounds = LeadRect.Intersect(pageBounds, bounds);
         return bounds;
      }

      void _annAutomation_OnShowContextMenu(object sender, AnnAutomationEventArgs e)
      {
         if (e != null && e.Object != null)
         {
            AnnAutomationObject annAutomationObject = e.Object as AnnAutomationObject;
            if (annAutomationObject != null)
            {
               ContextMenu menu = annAutomationObject.ContextMenu as ContextMenu;
               if (menu != null)
               {
                  menu.Show(this, _rasterImageViewer.PointToClient(Cursor.Position));
               }
            }
         }
      }

      void _annAutomation_Draw(object sender, AnnDrawDesignerEventArgs e)
      {
         if (!(e.OperationStatus == AnnDesignerOperationStatus.End))
            return;

         // Add a new zone from the annotation rectangle object
         ZoneAnnotationObject zoneObject = e.Object as ZoneAnnotationObject;

         if (zoneObject == null)
            return;

         OcrZone zone = new OcrZone();
         zone.Bounds = RestrictZoneBoundsToPage(_ocrPage, BoundsFromAnnotations(zoneObject, _annAutomation.Container));
         if (!zone.Bounds.IsEmpty)
            _ocrPage.Zones.Add(zone);
         else
         {
            InteractiveMode = ViewerControlInteractiveMode.DrawZoneMode;
            return;
         }

         // Set the zone
         zoneObject.SetZone(_ocrPage, _ocrPage.Zones.Count - 1, _showZonesToolStripButton.Checked, _showZoneNameToolStripButton.Checked);

         ZonesUpdated();
         InteractiveMode = ViewerControlInteractiveMode.DrawZoneMode;
         UpdateUIState();
      }

      private void _annAutomationObjects_ItemAdded(object sender, AnnObjectCollectionEventArgs e)
      {
         if (e.Object == null)
            return;
         // Check if we are updating the zones, no need for this
         if (_ignoreAddRemove)
            return;


         //// Add a new zone from the annotation rectangle object
         //ZoneAnnotationObject zoneObject = e.Object as ZoneAnnotationObject;

         //OcrZone zone = new OcrZone();
         //zone.Bounds = RestrictZoneBoundsToPage(_ocrPage, BoundsFromAnnotations(zoneObject, _annAutomation.Container));
         //_ocrPage.Zones.Add(zone);

         //// Set the zone
         //zoneObject.SetZone(_ocrPage, _ocrPage.Zones.Count - 1, _showZonesToolStripButton.Checked, _showZoneNameToolStripButton.Checked);

         //// Convert the pen width to logical units in case we are zoomed in
         //if (e.Object.SupportsStroke && e.Object.Stroke != null)
         //{
         //   //leadlengthd penwidth = e.object.stroke.strokethickness;
         //   //leadpointd[] pts = { new leadpointd(penwidth.value, penwidth.value) };
         //   //pts = _annautomation.container.mapper.pointsfromcontainercoordinates(pts, annfixedstateoperations.none);
         //   //penwidth = new leadlengthd(pts[0].x);
         //   //e.object.stroke.strokethickness = penwidth;
         //}

         //InteractiveMode = ViewerControlInteractiveMode.DrawZoneMode;
         //UpdateUIState();
      }

      private void _annAutomationObjects_ItemRemoved(object sender, AnnObjectCollectionEventArgs e)
      {
         // Check if we are updating the zones, no need for this
         if (_ignoreAddRemove)
            return;
         // User deleted the annotation object, delete the corresponding zone
         ZoneAnnotationObject zoneObject = e.Object as ZoneAnnotationObject;
         if (zoneObject != null)
         {
            if (_setSelect)
            {
               InteractiveMode = ViewerControlInteractiveMode.SelectMode;
               return;
            }
            _setSelect = true;
            int index = zoneObject.ZoneIndex;
            _ocrPage.Zones.RemoveAt(index);

            // Reset all the zones
            for (int i = 0; i < _annAutomation.Container.Children.Count; i++)
            {
               zoneObject = _annAutomation.Container.Children[i] as ZoneAnnotationObject;
               zoneObject.SetZone(_ocrPage, i, _showZonesToolStripButton.Checked, _showZoneNameToolStripButton.Checked);
            }

            // We should mark the page as unrecognized since we updated its zones
            _ocrPage.Unrecognize();
            // Update the thumbnail(s)
            DoAction("RefreshPagesControl", false);
         }
      }

      private void _annAutomation_AfterObjectChanged(object sender, AnnAfterObjectChangedEventArgs e)
      {
         // The annotation object has been changed, update the corresponding zone
         switch (e.ChangeType)
         {
            case AnnObjectChangedType.DesignerEdit:
               {
                  // The object moved or re-sized, update the bounds
                  ZoneAnnotationObject zoneObject = e.Objects[0] as ZoneAnnotationObject;

                  OcrZone zone = _ocrPage.Zones[zoneObject.ZoneIndex];
                  zone.Bounds = RestrictZoneBoundsToPage(_ocrPage, BoundsFromAnnotations(zoneObject, _annAutomation.Container));

                  bool zoneChanged = false;
                  if (_ocrPage.Zones[zoneObject.ZoneIndex].Bounds != zone.Bounds)
                     zoneChanged = true;

                  _ocrPage.Zones[zoneObject.ZoneIndex] = zone;

                  if (zoneChanged)
                  {
                     _rasterImageViewer.BeginUpdate();

                     // We should mark the page as unrecognized since we updated its zones
                     _ocrPage.Unrecognize();
                     // Update the thumbnail(s)
                     DoAction("RefreshPagesControl", false);

                     _rasterImageViewer.EndUpdate();
                  }
               }
               break;
         }
      }

      private void _zoneDeleteMenuItem_Click(object sender, EventArgs e)
      {
         _setSelect = false;
         _annAutomation.DeleteSelectedObjects();
      }

      private void _zonePropertiesMenuItem_Click(object sender, EventArgs e)
      {
         _zonePropertiesToolStripButton.PerformClick();
      }

      private void UpdateZoomValueFromControl()
      {
         // We are invoking this instead of changing the properties
         // directly because the Text value of a combo box is not
         // updated till after the lost focus or enter event is exited
         BeginInvoke(new MethodInvoker(delegate()
         {
            if(_rasterImageViewer.Image != null)
            {
               double factor = _rasterImageViewer.XScaleFactor * 100.0;
               _zoomToolStripComboBox.Text = factor.ToString("F1") + "%";
            }
            else
            {
               _zoomToolStripComboBox.Text = string.Empty;
            }
         }));
      }

      public void UpdateUIState()
      {
         // Update the UI controls states
         _fitPageWidthToolStripButton.Checked = _rasterImageViewer.SizeMode == ControlSizeMode.FitWidth;
         _fitPageToolStripButton.Checked = _rasterImageViewer.SizeMode == ControlSizeMode.Fit;

         _selectModeToolStripButton.Checked = _interactiveMode == ViewerControlInteractiveMode.SelectMode;
         _panModeToolStripButton.Checked = _interactiveMode == ViewerControlInteractiveMode.PanMode;
         _zoomToSelectionModeToolStripButton.Checked = _interactiveMode == ViewerControlInteractiveMode.ZoomToSelectionMode;
         _drawZoneModeToolStripButton.Checked = _interactiveMode == ViewerControlInteractiveMode.DrawZoneMode ;
         _drawZoneModeToolStripButton.Enabled = _showZonesToolStripButton.Checked;

         _zonePropertiesToolStripButton.Enabled = _ocrPage != null;

         if(_rasterImageViewer.Image != null)
         {
            if(!_toolStrip.Enabled)
               _toolStrip.Enabled = true;

            _pageToolStripTextBox.Text = (_currentPageIndex + 1).ToString();
            _pageToolStripLabel.Text = "/ " + _pageCount.ToString();

            _previousPageToolStripButton.Enabled = _currentPageIndex > 0 && !MainForm.PerspectiveDeskewActive;
            _nextPageToolStripButton.Enabled = _currentPageIndex < (_pageCount - 1) && !MainForm.PerspectiveDeskewActive;
            _pageToolStripTextBox.Enabled = !MainForm.PerspectiveDeskewActive;
            _pageToolStripLabel.Enabled = !MainForm.PerspectiveDeskewActive;
            _panModeToolStripButton.Enabled = !MainForm.PerspectiveDeskewActive;
            _drawZoneModeToolStripButton.Enabled = !MainForm.PerspectiveDeskewActive;
            _zonePropertiesToolStripButton.Enabled = !MainForm.PerspectiveDeskewActive;
            _showZonesToolStripButton.Enabled = !MainForm.PerspectiveDeskewActive;
            _showZoneNameToolStripButton.Enabled = !MainForm.PerspectiveDeskewActive;
         }
         else
         {
            _pageToolStripTextBox.Text = "0";
            _pageToolStripLabel.Text = "/ 0";

            _zoomToolStripComboBox.Text = string.Empty;

            _toolStrip.Enabled = false;
         }
      }

      private void UpdateTitle()
      {
         // Add the current page info (size, dpi and bpp) to the title label

         StringBuilder sb = new StringBuilder();

         if(_title != null)
            sb.Append(_title);

         if(_rasterImageViewer.Image != null)
         {
            RasterImage image = _rasterImageViewer.Image;

            sb.AppendFormat(" - Size: {0} by {1} px, dpi: {2} by {3}, Bits/Pixel: {4}", image.ImageWidth, image.ImageHeight, image.XResolution, image.YResolution, image.BitsPerPixel);
         }

         _titleLabel.Text = sb.ToString();
      }

      private void _rasterImageViewer_TransformChanged(object sender, EventArgs e)
      {
         if(IsHandleCreated)
         {
            UpdateZoomValueFromControl();
            UpdateUIState();
         }
      }

      private void _previousPageToolStripButton_Click(object sender, EventArgs e)
      {
         TryGotoPage(_currentPageIndex - 1);
      }

      private void _nextPageToolStripButton_Click(object sender, EventArgs e)
      {
         TryGotoPage(_currentPageIndex + 1);
      }

      private void _pageToolStripTextBox_LostFocus(object sender, EventArgs e)
      {
         _pageToolStripTextBox.Text = (_currentPageIndex + 1).ToString();
      }

      private void _pageToolStripTextBox_KeyPress(object sender, KeyPressEventArgs e)
      {
         if(e.KeyChar == (char)Keys.Return)
         {
            // User has pressed enter, go to the new page number

            string str = _pageToolStripTextBox.Text.Trim();

            // Try to parse the integer value
            int pageNumber;
            if(int.TryParse(str, out pageNumber))
               TryGotoPage(pageNumber - 1);

            _pageToolStripTextBox.Text = (_currentPageIndex + 1).ToString();
         }
      }

      private void TryGotoPage(int pageIndex)
      {
         // Check if the index is valid
         if(pageIndex >= 0 && pageIndex < _pageCount)
         {
            // Yes, fire the event to the main form
            DoAction("PageIndexChanged", pageIndex);
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

      private void _zoomToolStripComboBox_LostFocus(object sender, EventArgs e)
      {
         UpdateZoomValueFromControl();
      }

      private void _zoomToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         // Parse the new zoom value
         string str = _zoomToolStripComboBox.Text.Trim();

         switch(str)
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
               if(!string.IsNullOrEmpty(str))
               {
                  double val = double.Parse(str.Substring(0, str.Length - 1));
                  SetViewerZoomPercentage(val);
               }
               break;
         }
         ZonesUpdated();
      }

      private void _zoomToolStripComboBox_KeyPress(object sender, KeyPressEventArgs e)
      {
         if(e.KeyChar == (char)Keys.Return)
         {
            // User has pressed enter, parse the new zoom value

            string str = _zoomToolStripComboBox.Text.Trim();

            if(!string.IsNullOrEmpty(str))
            {
               // Remove the % sign if present
               if(str.EndsWith("%"))
                  str = str.Remove(str.Length - 1, 1).Trim();

               // Try to parse the new zoom value
               double percentage;
               if(double.TryParse(str, out percentage))
                  SetViewerZoomPercentage(percentage);

               UpdateZoomValueFromControl();
               ZonesUpdated();
            }
         }
      }

      private void SetViewerZoomPercentage(double percentage)
      {
         // Normalize the percentage based on min/max value allowed
         percentage = Math.Max(_minimumViewerScalePercentage, Math.Min(_maximumViewerScalePercentage, percentage));

         if (Math.Abs(_rasterImageViewer.XScaleFactor * 100.0 - percentage) > 0.01)
         {
            // Save the current center location in the viewer, we will use it later to
            // re-center the viewer
            Rectangle rc = Rectangle.Intersect(_rasterImageViewer.DisplayRectangle, _rasterImageViewer.ClientRectangle);
            PointF center = new PointF(rc.Left + rc.Width / 2, rc.Top + rc.Right / 2);

            Transformer trans = new Transformer(ToMatrix(_rasterImageViewer.ImageTransform));
            center = trans.PointToLogical(center);


            _rasterImageViewer.BeginUpdate();

            // Switch to normal size mode if we are not in it
            if (_rasterImageViewer.SizeMode != ControlSizeMode.None)
               _rasterImageViewer.Zoom(ControlSizeMode.None, _rasterImageViewer.ScaleFactor, _rasterImageViewer.DefaultZoomOrigin);


            // Zoom
            _rasterImageViewer.Zoom(_rasterImageViewer.SizeMode, percentage / 100.0, _rasterImageViewer.DefaultZoomOrigin);
            // Go back to original center point

            trans = new Transformer(ToMatrix(_rasterImageViewer.ImageTransform));
            center = trans.PointToPhysical(center);

            LeadPoint lPoint = new LeadPoint(Point.Round(center).X, Point.Round(center).Y);
            _rasterImageViewer.CenterAtPoint(lPoint);

            _rasterImageViewer.EndUpdate();

            _rasterImageViewer_TransformChanged(_rasterImageViewer, EventArgs.Empty);

            UpdateUIState();
         }
      }

      private Matrix ToMatrix(LeadMatrix LMatrix)
      {
         return new Matrix((float)LMatrix.M11, (float)LMatrix.M12, (float)LMatrix.M21, (float)LMatrix.M22, (float)LMatrix.OffsetX, (float)LMatrix.OffsetY);
      }

      private void _fitPageWidthToolStripButton_Click(object sender, EventArgs e)
      {
         FitPage(true);
         ZonesUpdated();
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

      private void _drawZoneModeToolStripButton_Click(object sender, EventArgs e)
      {
         InteractiveMode = ViewerControlInteractiveMode.DrawZoneMode;
      }

      private void _zonePropertiesToolStripButton_Click(object sender, EventArgs e)
      {
         DoAction("ShowZoneProperties", null);
      }

      private void _showZonesToolStripButton_Click(object sender, EventArgs e)
      {
         _showZonesToolStripButton.Checked = !_showZonesToolStripButton.Checked;
         ShowZones = _showZonesToolStripButton.Checked;
         _rasterImageViewer.Invalidate();
      }

      private void _showZoneNameToolStripButton_Click(object sender, EventArgs e)
      {
         _showZoneNameToolStripButton.Checked = !_showZoneNameToolStripButton.Checked;
         ShowZoneNames = _showZoneNameToolStripButton.Checked;
         _rasterImageViewer.Invalidate();
      }

      private void DoAction(string action, object data)
      {
         // Raise the action event so the main form can handle it

         if(Action != null)
            Action(this, new ActionEventArgs(action, data));
      }

      private void _rasterImageViewer_MouseMove(object sender, MouseEventArgs e)
      {
         string str;

         if (_rasterImageViewer.Image != null && _ocrPage != null)
         {
            // Show the mouse position in physical and logical (inches) coordinates

            PointF physical = new PointF(e.X, e.Y);
            PointF pixels;

            Transformer trans = new Transformer(ToMatrix(_rasterImageViewer.ImageTransform));
            pixels = trans.PointToLogical(physical);

            LeadPoint lPoint = new LeadPoint((int)Math.Abs(pixels.X), (int)Math.Abs(pixels.Y));
            int zoneIndex = _ocrPage.HitTestZone(lPoint);
            str = string.Format("{0},{1} px", (int)pixels.X, (int)pixels.Y);
         }
         else
            str = string.Empty;

         _mousePositionLabel.Text = str;
      }

      private void _rasterImageViewer_PostImagePaint(object sender, ImageViewerRenderEventArgs e)
      {
         // If this page is recognized, show info
         if (_ocrPage != null && _ocrPage.IsRecognized)
         {
            Graphics g = e.PaintEventArgs.Graphics;

            string text = "Page is recognized";
            SizeF textSize = g.MeasureString(text, _rasterImageViewer.Font);
            RectangleF textRect = new RectangleF(2, 2, textSize.Width, textSize.Height);

            using (Brush textBrush = new SolidBrush(Color.FromArgb(128, Color.Black)))
            {
               g.FillRectangle(textBrush, textRect);
               g.DrawString(text, _rasterImageViewer.Font, Brushes.White, textRect.Location);
            }
         }
      }

      private Matrix GetMatrixFromLeadMatrix(LeadMatrix matrix)
      {
         return new Matrix((float)matrix.M11, (float)matrix.M12, (float)matrix.M21, (float)matrix.M22, (float)matrix.OffsetX, (float)matrix.OffsetY);
      }

      public LeadPoint PhysicalToLogical(LeadPoint physical)
      {
         PointF pixelsF = new PointF(physical.X, physical.Y);

         using (Matrix m = GetMatrixFromLeadMatrix(_rasterImageViewer.GetImageTransformWithDpi(true)))
         {
            Transformer trans = new Transformer(m);
            pixelsF = trans.PointToLogical(pixelsF);
         }

         Point pixels = Point.Round(pixelsF);
         return new LeadPoint(pixels.X, pixels.Y);
      }
   }
}
