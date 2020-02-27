using Leadtools;
using Leadtools.Annotations.Automation;
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.WinForms;
using Leadtools.Controls;
using Leadtools.Drawing;
using Leadtools.Forms.Processing.Omr.Fields;
using Leadtools.Forms.Processing.Omr;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Core;
using Leadtools.Ocr;

using OmrProcessingDemo.UI;
using OmrProcessingDemo.UI.ViewerControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OmrProcessingDemo.ViewerControl
{
   /// <summary>
   /// This control contains an instance of RasterImageViewer plus
   /// a tool strip control for common operations
   /// </summary>
   public partial class ViewerControl : UserControl
   {
      #region Members
      private enum ZoneType
      {
         OmrField,
         Barcode,
         Text,
         None,
         Image
      }

      private ZoneType currentZoneType = ZoneType.None;

      // annotation highlights
      private const string clrOmrField = "Green";
      private const string clrBarcode = "Blue";
      private const string clrText = "Red";
      private const string clrImage = "Yellow";
      private const string clrDefault = "Red";
      private const string clrOmrCollection = "Green";
      private const string clrOmrBubble = "Green";

      private Timer timer;

      // Minimum and maximum scale percentages allowed
      private const double _minimumViewerScalePercentage = 1;
      private const double _maximumViewerScalePercentage = 6400;
      private AutomationInteractiveMode _automationInteractiveMode = null;
      private ImageViewerPanZoomInteractiveMode _panInteractiveMode = null;
      private ImageViewerZoomToInteractiveMode _zoomToInteractiveMode = null;
      private ImageViewerNoneInteractiveMode _noneInteractiveMode = null;
      private ImageViewerAutoPanInteractiveMode autoPanInteractiveMode = null;
      // Current 0-based page index and number of pages
      private int _currentPageIndex = -1;
      private int _pageCount = 0;

      // Current interactive mode (with the mouse)
      private ViewerControlInteractiveMode _interactiveMode = ViewerControlInteractiveMode.SelectMode;

      // We will use annotations to paint and edit the zones
      private AnnAutomationManager _annAutomationManager;
      private AnnAutomation _annAutomation;
      private AutomationManagerHelper _automationManagerHelper = null;

      private ITemplateForm templateForm;

      private string currentFileName = "";

      AnnHiliteObject regionHighlight = new AnnHiliteObject();

      public ITemplateForm TemplateForm
      {
         get { return templateForm; }
      }

      public EventHandler<CloseRequestArgs> CloseRequested;
      #endregion

      #region Initialization
      public ViewerControl()
      {
         InitializeComponent();

         timer = new Timer();
         timer.Tick += Timer_Tick;
         timer.Interval = (int)TimeSpan.FromMinutes(Properties.Settings.Default.AutoSaveDelay).TotalMilliseconds;
         timer.Start();
      }

      private void Timer_Tick(object sender, EventArgs e)
      {
         if (Properties.Settings.Default.AutoSaveEnabled && templateForm != null)
         {
            string cf = currentFileName;

            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string backup = Path.Combine(appData, Properties.Settings.Default.AutoSaveFilename);

            SaveTemplate(backup);

            currentFileName = cf;
         }
         //autosave
      }

      internal void Deactivate()
      {
         if (pvf != null && !pvf.IsDisposed && pvf.Visible)
         {
            pvf.Hide();
         }
      }

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
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
            autoPanInteractiveMode = new ImageViewerAutoPanInteractiveMode();
            //autoPanInteractiveMode.MouseButtons = MouseButtons.None;
            _zoomToInteractiveMode = new ImageViewerZoomToInteractiveMode();
            _zoomToInteractiveMode.RubberBandCompleted += new EventHandler<ImageViewerRubberBandEventArgs>(_rasterImageViewer_InteractiveZoomTo);

            autoPanInteractiveMode.BeginDelay = 100;
            autoPanInteractiveMode.PanDelay = 100;

            _rasterImageViewer.InteractiveModes.BeginUpdate();
            _rasterImageViewer.InteractiveModes.Add(autoPanInteractiveMode);
            _rasterImageViewer.InteractiveModes.Add(_noneInteractiveMode);
            _rasterImageViewer.InteractiveModes.Add(_automationInteractiveMode);
            _rasterImageViewer.InteractiveModes.Add(_panInteractiveMode);
            _rasterImageViewer.InteractiveModes.Add(_zoomToInteractiveMode);

            _rasterImageViewer.InteractiveModes.EndUpdate();
            
            EnableInteractiveMode(_automationInteractiveMode.Id);

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
      #endregion

      public void EnableInteractiveMode(int id)
      {
         _rasterImageViewer.InteractiveModes.BeginUpdate();

         foreach (ImageViewerInteractiveMode mode in _rasterImageViewer.InteractiveModes)
         {
            if (mode.Id != ImageViewerInteractiveMode.AutoPanModeId && mode.Id != id)
               mode.IsEnabled = false;
            else
               mode.IsEnabled = true;
         }

         _rasterImageViewer.InteractiveModes.EndUpdate();
      }

      void _rasterImageViewer_InteractiveZoomTo(object sender, ImageViewerRubberBandEventArgs e)
      {
         // Go back to selection mode
         // We must invoke this because the select button will change the
         // interactive mode of the viewer and hence, cancel the current
         // operation
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

      internal void Cleanup()
      {
         timer.Stop();

         //remove backup
         string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
         string backup = Path.Combine(folder, Properties.Settings.Default.AutoSaveFilename);

         if (File.Exists(backup))
         {
            File.Delete(backup);
         }
      }

      internal void LoadAutosave()
      {
         string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
         string backup = Path.Combine(folder, Properties.Settings.Default.AutoSaveFilename);

         LoadTemplate(backup);

         currentFileName = "";
      }

      internal bool IsAutosavePresent()
      {
         string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
         string backup = Path.Combine(folder, Properties.Settings.Default.AutoSaveFilename);

         return File.Exists(backup);
      }

      /// <summary>
      /// Called by the main form to get the current raster image
      /// </summary>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public RasterImage RasterImage
      {
         get { return _rasterImageViewer.Image; }
      }

      private void SetImageAndPage(RasterImage image)
      {
         BuildNewTree();

         SetPages(0, templateForm.Pages.Count);
         TryGotoPage(0);

         ToggleUIEnables(true);

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

         UpdateUIState();
      }

      private void ToggleUIEnables(bool val)
      {
         saveasToolStripMenuItem.Enabled = val;
         saveToolStripMenuItem.Enabled = val;
         editToolStripMenuItem.Enabled = val;
         closeToolStripMenuItem.Enabled = val;
      }

      #region Treeview
      private void BuildNewTree()
      {
         trvForm.Nodes.Clear();

         TreeNode rootNode = new TreeNode(templateForm.Name);
         trvForm.Nodes.Add(rootNode);

         for (int i = 0; i < templateForm.Pages.Count; i++)
         {
            Page pg = templateForm.Pages[i];

            if (string.IsNullOrWhiteSpace(pg.PageName))
            {
               pg.PageName = "Page " + pg.PageNumber.ToString();
            }

            TreeNode pageNode = new TreeNode(pg.PageName);
            pageNode.Name = pageNode.Text;
            pageNode.Expand();


            for (int j = 0; j < pg.Fields.Count; j++)
            {
               TreeNode branch = CreateNewNode(pg.Fields[j]);
               branch.Collapse(true);
               pageNode.Nodes.Add(branch);
            }

            rootNode.Nodes.Add(pageNode);
         }

         rootNode.Expand();

      }

      private void AddNode(Field ff)
      {
         TreeNode node = CreateNewNode(ff);

         if (ff is OmrField)
         {
            OmrField orf = (OmrField)ff;
            ReNumberElements(node, orf, RowNumberDialog.GetFriendlyFieldTemplate(orf.Options.FieldOrientation), 1);
         }

         trvForm.Nodes[0].Nodes[_currentPageIndex].Nodes.Add(node);
         trvForm.Nodes[0].Nodes[_currentPageIndex].Expand();
         node.Expand();
      }

      private TreeNode CreateNewNode(Field ff)
      {
         TreeNode node = new TreeNode(ff.Name);
         node.Name = ff.Name;

         int page = ff.PageNumber;

         node.Tag = new Tuple<string, LeadRect, int>(GetZoneColor(ff), ff.Bounds, page);


         if (ff is OmrField)
         {
            OmrField omr = (OmrField)ff;

            for (int i = 0; i < omr.Fields.Count; i++)
            {
               OmrCollection omrCollection = omr.Fields[i];

               TreeNode ocNode = new TreeNode(omrCollection.Name);
               ocNode.Name = omrCollection.Name;
               ocNode.Tag = new Tuple<string, LeadRect, int>(GetZoneColor(omrCollection), omrCollection.Bounds, page);

               if (omr.FieldBubbleLayoutType == OmrFieldBubbleLayoutType.BubbleWithLabel)
               {
                  for (int j = 0; j < omrCollection.Fields.Count; j++)
                  {
                     OmrBubble bub = omrCollection.Fields[j];
                     TreeNode ss = new TreeNode(bub.Value);
                     ss.Name = bub.Value;
                     ss.Tag = new Tuple<string, LeadRect, int>(GetZoneColor(bub), bub.Bounds, page);

                     ocNode.Nodes.Add(ss);
                  }

                  ocNode.Expand();
               }

               node.Nodes.Add(ocNode);
            }

            node.Expand();
         }

         return node;
      }

      private void DeleteNode(TreeNode node)
      {
         string text = node.Text;
         if (MessageBox.Show(string.Format("Are you sure you want to delete \"{0}\"?", text), "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
         {
            int index = node.Index;

            trvForm.Nodes[0].Nodes[_currentPageIndex].Nodes.RemoveAt(index);
            templateForm.Pages[_currentPageIndex].Fields.RemoveAt(index);

            ZonesUpdated();
         }
      }

      private void MoveNode(TreeNode node, int direction)
      {
         int index = node.Index;
         bool ex = node.IsExpanded;
         trvForm.Nodes[0].Nodes[_currentPageIndex].Nodes.RemoveAt(index);

         trvForm.Nodes[0].Nodes[_currentPageIndex].Nodes.Insert(index + direction, node);

         Field ff = templateForm.Pages[_currentPageIndex].Fields[index];
         templateForm.Pages[_currentPageIndex].Fields.RemoveAt(index);
         templateForm.Pages[_currentPageIndex].Fields.Insert(index + direction, ff);

         if (ex)
         {
            node.Expand();
         }
      }

      private void MovePage(TreeNode node, int direction)
      {
         int index = node.Index;
         bool ex = node.IsExpanded;
         trvForm.Nodes[0].Nodes.RemoveAt(index);

         trvForm.Nodes[0].Nodes.Insert(index + direction, node);

         Page page = templateForm.Pages[index];
         templateForm.Pages.RemoveAt(index);
         templateForm.Pages.Insert(index + direction, page);

         if (ex)
         {
            node.Expand();
         }
      }
      private void DeletePage(TreeNode node)
      {
         if (TemplateForm.Pages.Count == 1)
         {
            MessageBox.Show("Templates must have at least one page.");

            return;
         }

         if (MessageBox.Show(string.Format("Are you sure you want to delete \"{0}\"?", node.Text), "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
         {
            int index = node.Index;

            trvForm.Nodes[0].Nodes.RemoveAt(index);
            templateForm.Pages.RemoveAt(index);
            templateForm.Pages.Update();

            _pageCount--;

            ZonesUpdated();

            if (_currentPageIndex == index)
            {
               _currentPageIndex = Math.Max(_currentPageIndex - 1, 0);
            }

            TryGotoPage(_currentPageIndex);
         }
      }
      #endregion

      #region NavigationAndView
      /// <summary>
      /// Called by the main form to change the page viewing mode (from the main menu)
      /// </summary>
      public void FitPage(bool fitWidth)
      {
         // Since we are doing more than one operation on the viewer, it is
         // recommended to disable then re-enable updates on the viewer to
         // minimize flickering
         _rasterImageViewer.BeginUpdate();

         if (fitWidth)
            _rasterImageViewer.Zoom(ControlSizeMode.FitWidth, 1, _rasterImageViewer.DefaultZoomOrigin);
         else
            _rasterImageViewer.Zoom(ControlSizeMode.FitAlways, 1, _rasterImageViewer.DefaultZoomOrigin);

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
         ZonesUpdated();
      }

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

            if (_interactiveMode != ViewerControlInteractiveMode.DrawZoneMode)
            {
               SetZoneTSButtonCheckFalse();
            }

            if (_annAutomationManager != null)
            {
               // Set the RasterImageViewer interactive mode accordingly
               switch (_interactiveMode)
               {
                  case ViewerControlInteractiveMode.SelectMode:
                     EnableInteractiveMode(_automationInteractiveMode.Id);
                     _annAutomationManager.CurrentObjectId = AnnObject.None;
                     _annAutomation.DefaultCurrentObjectId = AnnObject.None;
                     _annAutomation.Cancel();
                     break;

                  case ViewerControlInteractiveMode.PanMode:
                     EnableInteractiveMode(_panInteractiveMode.Id);
                     _annAutomationManager.CurrentObjectId = AnnObject.None;
                     _annAutomation.DefaultCurrentObjectId = AnnObject.None;
                     _annAutomation.Cancel();
                     break;

                  case ViewerControlInteractiveMode.ZoomToSelectionMode:
                     EnableInteractiveMode(_zoomToInteractiveMode.Id);
                     _annAutomationManager.CurrentObjectId = AnnObject.None;
                     _annAutomation.DefaultCurrentObjectId = AnnObject.None;
                     _annAutomation.Cancel();
                     break;

                  case ViewerControlInteractiveMode.DrawZoneMode:
                     EnableInteractiveMode(_automationInteractiveMode.Id);
                     _annAutomationManager.CurrentObjectId = AnnObject.UserObjectId;
                     _annAutomation.DefaultCurrentObjectId = AnnObject.UserObjectId;
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
            if (_annAutomation != null)
            {
               _annAutomation.Cancel();

               foreach (AnnObject obj in _annAutomation.Container.Children)
                  obj.IsVisible = value;

               regionHighlight.IsVisible = false;
            }

            if (!_showZonesToolStripButton.Checked && _interactiveMode == ViewerControlInteractiveMode.DrawZoneMode)
               InteractiveMode = ViewerControlInteractiveMode.SelectMode;

            _rasterImageViewer.Invalidate();
            UpdateUIState();
         }
      }

      #endregion

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

            _annAutomation.Container.Children.Add(regionHighlight);
         }


         if (!_showZonesToolStripButton.Checked)
         {
            _rasterImageViewer.EndUpdate();
            _rasterImageViewer.Invalidate();
            return;
         }

         // Get the rectangle automation object so we can use the template
         // to create the new annotation objects
         bool isVisible = _showZonesToolStripButton.Checked && !MainForm.PerspectiveDeskewActive && !MainForm.UnWarpActive;

         Page formPage = _currentPageIndex >= 0 && _currentPageIndex < templateForm.Pages.Count ? templateForm.Pages[_currentPageIndex] : null;

         if (formPage != null && formPage.Fields.Count > 0)
         {
            for (int i = 0; i < formPage.Fields.Count; i++)
            {
               Field f = formPage.Fields[i];

               AnnRectangleObject ao = new AnnRectangleObject();
               ao = CreateAnnotation(f);
               _annAutomation.Container.Children.Add(ao);

               if (tsToggleSubzones.Checked && f is OmrField)
               {
                  OmrField omr = f as OmrField;

                  for (int j = 0; j < omr.Fields.Count; j++)
                  {
                     _annAutomation.Container.Children.Add(CreateAnnotation(omr.Fields[j]));
                  }
               }
            }
         }


         // Re-update the viewer
         _rasterImageViewer.EndUpdate();

         _rasterImageViewer.Invalidate();
         UpdateUIState();
      }

      private AnnObject CreateAnnotation(OmrCollection f)
      {
         AnnRectangleObject ao = new AnnRectangleObject();

         LeadRect rc = f.Bounds;
         LeadRectD rect = BoundsToAnnotations(rc, _annAutomation.Container);
         ao.Rect = rect;

         string color = GetZoneColor(f);

         ao.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create(color), new LeadLengthD(1));
         ao.Tag = f;

         return ao;
      }

      private AnnRectangleObject CreateAnnotation(Field f)
      {
         AnnRectangleObject ao = new AnnRectangleObject();

         LeadRect rc = f.Bounds;
         LeadRectD rect = BoundsToAnnotations(rc, _annAutomation.Container);
         ao.Rect = rect;

         string color = GetZoneColor(f);

         ao.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create(color), new LeadLengthD(1));
         ao.Tag = f;

         return ao;
      }
      private string GetZoneColor(OmrBubble f)
      {
         return clrOmrBubble;
      }

      private string GetZoneColor(OmrCollection f)
      {
         return clrOmrCollection;
      }

      private string GetZoneColor(Field f)
      {
         string color = string.Empty;

         if (f is OmrField)
         {
            color = clrOmrField;
         }

         if (f is BarcodeField)
         {
            color = clrBarcode;
         }

         if (f is OcrField)
         {
            color = clrText;
         }

         if (f is ImageField)
         {
            color = clrImage;
         }

         return string.IsNullOrWhiteSpace(color) ? clrDefault : color;
      }

      private string GetZoneColor(ZoneType omrField)
      {
         switch (omrField)
         {
            case ZoneType.OmrField:
               return clrOmrField;
            case ZoneType.Barcode:
               return clrBarcode;
            case ZoneType.Text:
               return clrText;
            case ZoneType.Image:
               return clrImage;
            case ZoneType.None:
            default:
               return clrDefault;
         }
      }

      private LeadRect BoundsFromAnnotations(AnnRectangleObject rectObject, AnnContainer container)
      {
         // Convert a rectangle from annotation object to logical coordinates (top-left)
         LeadRectD temp = container.Mapper.RectFromContainerCoordinates(rectObject.Rect, AnnFixedStateOperations.None);
         temp = _rasterImageViewer.ConvertRect(null, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, temp);

         RectangleF rc = new RectangleF((float)temp.X, (float)temp.Y, (float)temp.Width, (float)temp.Height);
         LeadRect rect = new LeadRect((int)Math.Ceiling(rc.X), (int)Math.Ceiling(rc.Y), (int)Math.Ceiling(rc.Width), (int)Math.Ceiling(rc.Height));
         return rect;
      }

      private LeadRectD BoundsToAnnotations(LeadRect rect, AnnContainer container)
      {
         // Convert a rectangle from logical (top-left) to annotation object coordinates
         LeadRectD rc = rect.ToLeadRectD();
         rc = _rasterImageViewer.ConvertRect(null, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, rc);
         rc = container.Mapper.RectToContainerCoordinates(rc);
         return rc;
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

         zoneAutomationObject.ContextMenu = cm;

         _annAutomationManager.RenderingEngine.Renderers[AnnObject.UserObjectId] = zoneObjectRenderer;

         _annAutomationManager.Objects.Add(selectAutomationObject);
         _annAutomationManager.Objects.Add(zoneAutomationObject);

         // Disable Annotation selection object since we don't want users to group annotation objects.
         var selectionObject = _annAutomationManager.FindObjectById(AnnObject.SelectObjectId);
         selectionObject.DrawDesignerType = null;
      }

      #region AutomationEvents

      void _annAutomation_RestoreCursor(object sender, EventArgs e)
      {
         if (_rasterImageViewer.Cursor != Cursors.Default && InteractiveMode == ViewerControlInteractiveMode.SelectMode)
         {
            _rasterImageViewer.Cursor = Cursors.Default;
         }
         else if (InteractiveMode == ViewerControlInteractiveMode.DrawZoneMode)
         {
            _rasterImageViewer.Cursor = Cursors.Cross;
         }
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
               //newCursor = AutomationManagerHelper.AutomationCursors[CursorType.SelectObject];
               newCursor = Cursors.Cross;
               break;

         }

         if (_rasterImageViewer.Cursor != newCursor)
            _rasterImageViewer.Cursor = newCursor;
      }

      private static AnnAutomationObject GetAutomationObject(AnnAutomationManager automationManager, int id)
      {
         foreach (AnnAutomationObject obj in automationManager.Objects)
         {
            if (obj.Id == id)
               return obj;
         }

         return null;
      }

      private static LeadRect RestrictZoneBoundsToPage(RasterImage image, LeadRect bounds)
      {
         LeadRect pageBounds = new LeadRect(0, 0, image.ImageWidth, image.ImageHeight);
         LeadRect rc = bounds;

         rc = LeadRect.Intersect(pageBounds, rc);
         return rc;
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
         // Add a new zone from the annotation rectangle object
         ZoneAnnotationObject zoneObject = e.Object as ZoneAnnotationObject;

         if (zoneObject == null)
            return;

         AnnRectangleObject ao = new AnnRectangleObject();

         LeadRect rc = zoneObject.Bounds.ToLeadRect();
         LeadRectD rect = BoundsToAnnotations(rc, _annAutomation.Container);
         ao.Rect = rect;

         if (!(e.OperationStatus == AnnDesignerOperationStatus.End))
         {
            return;
         }

         LeadRect lr = new LeadRect((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
         lr = RestrictZoneBoundsToPage(templateForm.Pages[_currentPageIndex].Image, BoundsFromAnnotations(zoneObject, _annAutomation.Container));

         zoneObject.Rect = BoundsToAnnotations(lr, _annAutomation.Container);

         Field newField = null;

         switch (currentZoneType)
         {
            case ZoneType.OmrField:
               newField = CreateOmrRegion(lr);
               break;
            case ZoneType.Barcode:
               newField = CreateBarcodeField(lr);
               break;
            case ZoneType.Text:
               newField = CreateTextField(lr);
               break;
            case ZoneType.Image:
               newField = CreateImageField(lr);
               break;
            case ZoneType.None:
               break;
            default:
               break;
         }

         if (newField != null)
         {
            newField.PageNumber = _currentPageIndex + 1;
            if (newField.Tag == null)
            {
               newField.Tag = false;
            }

            Page formPage = templateForm.Pages[_currentPageIndex];
            bool success = false;
            try
            {
               formPage.Fields.Add(newField);
               success = true;
            }
            catch (Exception ex)
            {
               MessageBox.Show(this.Parent, "Unable to add this field:\n" + ex.Message);
               success = false;
            }

            if (success)
            {
               AddNode(newField);
            }
         }

         ZonesUpdated();
         // Convert the pen width to logical units in case we are zoomed in
         InteractiveMode = ViewerControlInteractiveMode.DrawZoneMode;
         UpdateUIState();
      }

      private Field CreateImageField(LeadRect lr)
      {
         ImageField imField = new ImageField();
         imField.Bounds = lr;

         imField.Name = GetFreeFieldName();

         TextInputDialog tid = new TextInputDialog(imField.Name);
         if (tid.ShowDialog() == DialogResult.OK)
         {
            imField.Name = tid.Value;

            return imField;
         }

         return null;
      }

      private Field CreateBarcodeField(LeadRect lr)
      {
         BarcodeField bcff = new BarcodeField();
         bcff.Bounds = lr;
         bcff.Symbology = Leadtools.Barcode.BarcodeSymbology.Unknown;
         bcff.Name = GetFreeFieldName();

         BarcodeFieldDialog bcffd = new UI.BarcodeFieldDialog(bcff, _rasterImageViewer.Image.Clone());
         if (bcffd.ShowDialog() == DialogResult.OK)
         {
            return bcff;
         }
         return null;
      }

      private Field CreateTextField(LeadRect lr)
      {
         OcrField ff = new OcrField();
         ff.Name = GetFreeFieldName();

         TextInputDialog tid = new TextInputDialog(ff.Name);

         if (tid.ShowDialog() == DialogResult.OK)
         {
            ff.Name = tid.Value;
            ff.Bounds = lr;

            return ff;
         }

         return null;
      }

      private string GetFreeFieldName()
      {
         //Look for a field name that does not exist
         Page formPage = templateForm.Pages[_currentPageIndex];

         int i = 0;
         string newName = String.Empty;
         while (true)
         {
            newName = String.Format("New Field {0}", i);
            if (!formPage.Fields.Select(a => a.Name).Contains(newName))
               break;
            i++;
         }

         return newName;
      }

      private Field CreateOmrRegion(LeadRect lr)
      {
         Cursor current = this.Cursor;

         try
         {
            Page formPage = templateForm.Pages[_currentPageIndex];

            OmrField omrField = new OmrField();
            omrField.Bounds = lr;
            omrField.PageNumber = _currentPageIndex + 1;
            omrField.Name = GetFreeFieldName();

            this.Cursor = Cursors.WaitCursor;

            templateForm.ExtractInfo(_currentPageIndex + 1, new Field[] { omrField });

            this.Cursor = current;

            for (int i = 0; i < omrField.Fields.Count; i++)
            {
               if (string.IsNullOrWhiteSpace(omrField.Fields[i].Name))
               {
                  omrField.Fields[i].Name = string.Format("Area {0}", i.ToString());
               }
            }

            //OmrRegionFieldDialog dlg = new OmrRegionFieldDialog(omrField);
            OmrFieldOptions options = omrField.Options;
            options.GradeThisField =  omrField.FieldBubbleLayoutType == OmrFieldBubbleLayoutType.None && omrField.RowsCount >= omrField.ColumnsCount && (omrField.ColumnsCount == 4 || omrField.ColumnsCount == 5);

            omrField.Options = options;

            OmrFieldDialog dlg = new OmrFieldDialog(omrField, formPage.Image.Clone());
            if (dlg.ShowDialog() == DialogResult.OK)
            {
               return omrField;
            }
         }
         catch (Exception)
         {
            return null;
         }
         finally
         {
            this.Cursor = current;
         }


         return null;
      }



      private void _zoneDeleteMenuItem_Click(object sender, EventArgs e)
      {
         _annAutomation.DeleteSelectedObjects();
      }

      #endregion


      private void UpdateZoomValueFromControl()
      {
         // We are invoking this instead of changing the properties
         // directly because the Text value of a combo box is not
         // updated till after the lost focus or enter event is exited
         BeginInvoke(new MethodInvoker(delegate ()
         {
            if (_rasterImageViewer.Image != null)
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
         if (templateForm == null || templateForm.Pages == null)
         {
            _pageToolStripTextBox.Text = "0";
            _pageToolStripLabel.Text = "/ 0";

            _zoomToolStripComboBox.Text = string.Empty;

            _toolStrip.Enabled = false;

            return;
         }

         Page formPage = _currentPageIndex >= 0 && _currentPageIndex < templateForm.Pages.Count ? templateForm.Pages[_currentPageIndex] : null;

         // Update the UI controls states
         _fitPageWidthToolStripButton.Checked = _rasterImageViewer.SizeMode == ControlSizeMode.FitWidth;
         _fitPageToolStripButton.Checked = _rasterImageViewer.SizeMode == ControlSizeMode.Fit;

         _zoomToSelectionModeToolStripButton.Checked = _interactiveMode == ViewerControlInteractiveMode.ZoomToSelectionMode;

         if (_rasterImageViewer.Image != null)
         {
            if (!_toolStrip.Enabled)
               _toolStrip.Enabled = true;

            _pageToolStripTextBox.Text = (_currentPageIndex + 1).ToString();
            _pageToolStripLabel.Text = "/ " + _pageCount.ToString();

            _previousPageToolStripButton.Enabled = _currentPageIndex > 0 && !MainForm.PerspectiveDeskewActive;
            _nextPageToolStripButton.Enabled = _currentPageIndex < (_pageCount - 1) && !MainForm.PerspectiveDeskewActive;
            _pageToolStripTextBox.Enabled = !MainForm.PerspectiveDeskewActive;
            _pageToolStripLabel.Enabled = !MainForm.PerspectiveDeskewActive;
            _showZonesToolStripButton.Enabled = !MainForm.PerspectiveDeskewActive;
         }
      }

      private void _rasterImageViewer_TransformChanged(object sender, EventArgs e)
      {
         if (IsHandleCreated)
         {
            UpdateZoomValueFromControl();
            UpdateUIState();
         }
      }

      #region NagivationAndViewEventHandles
      private void _previousPageToolStripButton_Click(object sender, EventArgs e)
      {
         TryGotoPage(_currentPageIndex + -1);
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
         if (e.KeyChar == (char)Keys.Return)
         {
            // User has pressed enter, go to the new page number

            string str = _pageToolStripTextBox.Text.Trim();

            // Try to parse the integer value
            int pageNumber;
            if (int.TryParse(str, out pageNumber))
               TryGotoPage(pageNumber - 1);

            _pageToolStripTextBox.Text = (_currentPageIndex + 1).ToString();
         }
      }

      private void TryGotoPage(int pageIndex)
      {
         // Check if the index is valid
         if (pageIndex >= 0 && pageIndex < _pageCount)
         {
            _rasterImageViewer.BeginUpdate();

            _currentPageIndex = pageIndex;
            _rasterImageViewer.Image = templateForm.Pages[_currentPageIndex].Image.Clone();

            _rasterImageViewer.EndUpdate();
            _rasterImageViewer.Invalidate();

            ZonesUpdated();
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
         ZonesUpdated();
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
               ZonesUpdated();
            }
         }
      }

      private void SetViewerZoomPercentage(double percentage)
      {
         if (_rasterImageViewer.Image == null)
         {
            return;
         }

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
      #endregion

      #region Toolbar
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

      private void _zonePropertiesToolStripButton_Click(object sender, EventArgs e)
      {

      }

      private void _showZonesToolStripButton_Click(object sender, EventArgs e)
      {
         ShowZones = _showZonesToolStripButton.Checked;
         tsToggleSubzones.Enabled = _showZonesToolStripButton.Checked;
         tsToggleSubzones.Checked = tsToggleSubzones.Checked && tsToggleSubzones.Enabled;

         ZonesUpdated();

         _rasterImageViewer.Invalidate();
      }

      private void tzOMRREgion_Click(object sender, EventArgs e)
      {
         PrepareAnnotationObject(ZoneType.OmrField);

         bool isChecked = (sender as ToolStripButton).Checked;
         SetZoneTSButtonCheckState(isChecked);

         tsZOMRRegion.Checked = isChecked;
         currentZoneType = tsZOMRRegion.Checked ? ZoneType.OmrField : ZoneType.None;
      }

      private void tzBarcode_Click(object sender, EventArgs e)
      {
         PrepareAnnotationObject(ZoneType.Barcode);

         bool isChecked = (sender as ToolStripButton).Checked;
         SetZoneTSButtonCheckState(isChecked);

         tszBarcode.Checked = isChecked;
         currentZoneType = tszBarcode.Checked ? ZoneType.Barcode : ZoneType.None;
      }

      private void tzOCR_Click(object sender, EventArgs e)
      {
         PrepareAnnotationObject(ZoneType.Text);

         bool isChecked = (sender as ToolStripButton).Checked;
         SetZoneTSButtonCheckState(isChecked);

         tsZOCR.Checked = isChecked;
         currentZoneType = tsZOCR.Checked ? ZoneType.Text : ZoneType.None;
      }

      private void tszImage_Click(object sender, EventArgs e)
      {
         PrepareAnnotationObject(ZoneType.Image);

         bool isChecked = (sender as ToolStripButton).Checked;
         SetZoneTSButtonCheckState(isChecked);

         tszImage.Checked = isChecked;
         currentZoneType = tszImage.Checked ? ZoneType.Image : ZoneType.None;
      }


      private void PrepareAnnotationObject(ZoneType zoneType)
      {
         AnnAutomationObject obj = _annAutomationManager.FindObjectById(AnnObject.UserObjectId);
         if (obj != null)
         {
            obj.ObjectTemplate.Stroke.Stroke = new AnnSolidColorBrush() { Color = GetZoneColor(zoneType) };
         }
      }

      private void SetZoneTSButtonCheckState(bool isChecked)
      {
         SetZoneTSButtonCheckFalse();

         InteractiveMode = isChecked ? ViewerControlInteractiveMode.DrawZoneMode : ViewerControlInteractiveMode.SelectMode;
      }

      private void SetZoneTSButtonCheckFalse()
      {
         tszBarcode.Checked = false;
         tsZOCR.Checked = false;
         tsZOMRRegion.Checked = false;
      }

      #endregion

      private void _rasterImageViewer_MouseHover(object sender, EventArgs e)
      {
      }

      private Matrix GetMatrixFromLeadMatrix(LeadMatrix matrix)
      {
         return new Matrix((float)matrix.M11, (float)matrix.M12, (float)matrix.M21, (float)matrix.M22, (float)matrix.OffsetX, (float)matrix.OffsetY);
      }
      private LeadPoint PhysicalToLogical(int x, int y)
      {
         return PhysicalToLogical(new LeadPoint(x, y));
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

      #region Menubar Events
      private void newToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (templateForm != null && templateForm.Pages.Count > 0)
         {
            DialogResult dr = MessageBox.Show(this.ParentForm, "Save changes?", "Closing", MessageBoxButtons.YesNoCancel);

            bool saved = false;
            if (dr == DialogResult.Yes)
            {
               saved = DoSave();
            }

            if (dr == DialogResult.No || saved)
            {
               OnCloseRequested(CloseRequestArgs.ClosingReason.ExplicitNew);
            }
         }
         else
         {
            CreateNewTemplate();
         }
      }

      public void AddPagesToTemplate(int startingPageIndex = 0)
      {
         NewTemplateDialog ntd = startingPageIndex == 0 ? new NewTemplateDialog() : new NewTemplateDialog(startingPageIndex);
         if (ntd.ShowDialog() == DialogResult.OK)
         {
            RasterImage image = ntd.LoadedImage.CloneAll();
            CreateNewTemplateOperation bo = new CreateNewTemplateOperation(image, templateForm);
            bo.Start();

            if (bo.IsLoadingError)
            {
               if (templateForm.Pages.Count > 0)
               {
                  MessageBox.Show("Some pages did not have any OMR marks detected.  Only pages with OMR marks have been added to the template.");
               }
               else
               {
                  MessageBox.Show("No OMR marks were detected on any page in the input document.  Please use a document with OMR marks present on at least one page.");
                  return;
               }
            }

            if (startingPageIndex == 0)
            {
               this.templateForm.Name = ntd.TemplateName;
            }

            if (ntd.LoadedImage != null && templateForm != null)
            {
               Cursor current = this.Cursor;
               this.Cursor = Cursors.WaitCursor;

               SetImageAndPage(image);
               currentFileName = Path.ChangeExtension(ntd.FileName, MainForm.TEMPLATE_EXT);

               this.Cursor = current;
            }

            image.Dispose();
         }

         ntd.Dispose();
      }

      public void CreateNewTemplate()
      {
         OmrEngine engine = MainForm.GetOmrEngine();
         this.templateForm = engine.CreateTemplateForm();
         this.templateForm.AutoEstimateMissingOmr = MainForm.AutoEstimateMissingOmr;
         AddPagesToTemplate();
      }

      private void openToolStripMenuItem_Click(object sender, EventArgs e)
      {
         CloseCurrentTemplate(CloseRequestArgs.ClosingReason.ToLoadExisting);
      }

      public void ShowLoadTemplate()
      {
         string input = "";

         if (MainForm.ChooseTemplate(out input))
         {
            LoadTemplate(input);
         }
      }

      private void saveasToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DoSaveAs();
      }

      private bool DoSaveAs()
      {
         SaveFileDialog sfd = new SaveFileDialog();
         sfd.Filter = String.Format("Lead Omr Template|*{0}", MainForm.TEMPLATE_EXT);
         sfd.Title = "Save Omr Template As";

         if (string.IsNullOrWhiteSpace(currentFileName) == false)
         {
            string file = Path.GetFileName(currentFileName);
            string dir = Path.GetDirectoryName(currentFileName);

            sfd.InitialDirectory = dir;
            sfd.FileName = file;
         }

         if (sfd.ShowDialog() == DialogResult.OK)
         {
            return SaveTemplate(sfd.FileName);
         }

         return false;
      }


      private void saveToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DoSave();
      }

      public bool DoSave()
      {
         if (templateForm == null || templateForm.Pages.Count == 0)
         {
            return true;
         }

         if (string.IsNullOrEmpty(currentFileName))
         {
            return DoSaveAs();
         }
         else
         {
            return SaveTemplate(currentFileName);
         }
      }

      #endregion

      private bool SaveTemplate(string fname)
      {
         bool success = true;

         fname = Path.ChangeExtension(fname, MainForm.TEMPLATE_EXT);

         currentFileName = fname;
         FileStream fs = null;

         try
         {
            fs = new FileStream(fname, FileMode.OpenOrCreate, FileAccess.Write);
            templateForm.Save(fs);
         }
         catch (Exception ex)
         {
            success = false;
            MessageBox.Show(string.Format("Unable to save form template:\n{0}", ex.Message));
         }
         finally
         {
            if (fs != null)
            {
               fs.Close();
            }
         }

         return success;
      }

      private void LoadTemplate(string selectedPath)
      {
         templateForm = MainForm.GetOmrEngine().CreateTemplateForm();

         Cursor current = this.Cursor;
         this.Cursor = Cursors.WaitCursor;

         bool success = true;

         using (FileStream fs = new FileStream(selectedPath, FileMode.Open, FileAccess.Read))
         {
            try
            {
               templateForm.Load(fs);
            }
            catch (Exception)
            {
               success = false;
            }
            finally
            {
               this.Cursor = current;
               fs.Close();
            }
         }

         //templateForm = OmrTemplateForm;

         if (success && templateForm.Pages.Count > 0)
         {
            currentFileName = selectedPath;
            SetImageAndPage(templateForm.Pages[0].Image);
         }
         else
         {
            MessageBox.Show("Unable to load form template.");
         }
      }

      public void AssignTemplate(ITemplateForm templateForm)
      {
         this.templateForm = templateForm;
         SetImageAndPage(templateForm.Pages[0].Image);
      }

      private void trvForm_MouseMove(object sender, MouseEventArgs e)
      {
         TreeNode node = trvForm.GetNodeAt(e.Location);

         if (node == null || node.Tag == null)
         {
            DisableHilite();
            return;
         }

         Tuple<string, LeadRect, int> hiliteParams = (Tuple<string, LeadRect, int>)node.Tag;

         if (hiliteParams.Item3 == _currentPageIndex + 1)
         {
            EnableHiLite(hiliteParams.Item1, hiliteParams.Item2);
         }
      }

      private void EnableHiLite(string color, LeadRect rc)
      {
         _rasterImageViewer.BeginUpdate();

         LeadRectD rect = BoundsToAnnotations(rc, _annAutomation.Container);
         regionHighlight.Rect = rect;
         regionHighlight.HiliteColor = color;

         regionHighlight.IsVisible = true;

         // Re-update the viewer
         _rasterImageViewer.EndUpdate();

         _rasterImageViewer.Invalidate();
      }


      private void trvForm_MouseLeave(object sender, EventArgs e)
      {
         if (this.ContainsFocus)
         {
            DisableHilite();
         }
      }

      private void DisableHilite()
      {
         // Stop updating the viewer
         _rasterImageViewer.BeginUpdate();

         regionHighlight.IsVisible = false;

         // Re-update the viewer
         _rasterImageViewer.EndUpdate();
         _rasterImageViewer.Invalidate();
      }

      private bool _preventExpand = false;
      private DateTime _lastMouseDown = DateTime.Now;
      private void trvForm_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
      {
         TreeNode node = e.Node;

         EditNode(node);
      }

      private void EditNode(TreeNode node)
      {
         if (node == null)
         {
            return;
         }

         string[] path = node.FullPath.Split(new string[] { trvForm.PathSeparator }, StringSplitOptions.None);

         if (path.Length == 1)
         {
            FormSpecificDialog fsd = new FormSpecificDialog(templateForm);

            if (fsd.ShowDialog() == DialogResult.OK)
            {
               node.Name = templateForm.Name;
               node.Text = templateForm.Name;
            }

            return;
         }

         // extract the page
         Page pg = null;
         if (path.Length >= 2)
         {
            pg = templateForm.Pages.FirstOrDefault(f => f.PageName == path[1]);
         }

         // extract the field or edit the page
         Field field = null;
         if (path.Length >= 3 && pg != null)
         {
            string fieldName = path[2];
            field = pg.Fields.FirstOrDefault(f => f.Name == fieldName);
         }
         else if (pg != null)
         {
            EditNode(pg, node);
         }

         // extract the omrfield, omrcollection (if necessary) or edit the field
         OmrField omr = null;
         OmrCollection coll = null;
         if (path.Length >= 4 && field != null)
         {
            omr = field as OmrField;

            if (omr != null)
            {
               coll = omr.Fields.Find(c => c.Name == path[3]);
            }
         }
         else if (field != null)
         {
            EditNode(field, node);
         }

         // all the way at the end of tree as possible means we're on an actual bubble (labelled only)
         if (path.Length >= 5 && coll != null)
         {
            if (coll.Fields.Count >= node.Index)
            {
               coll.Fields[node.Index] = EditNode(coll.Fields[node.Index], node);
            }
         }
         else if (coll != null)
         {
            bool isGraded = ((OmrField)field).Options.GradeThisField;

            EditNode(coll, node, isGraded);
         }
      }

      private OmrBubble EditNode(OmrBubble f, TreeNode node)
      {
         EnableHiLite(GetZoneColor(f), f.Bounds);

         TextInputDialog tid = new TextInputDialog(f.Value);
         if (tid.ShowDialog() == DialogResult.OK)
         {
            f.Value = tid.Value;
            node.Text = f.Value;
            node.Name = f.Value;
         }

         DisableHilite();

         return f;
      }

      private void EditNode(OmrCollection f, TreeNode node, bool isGraded)
      {
         if (node.Tag != null)
         {
            Tuple<string, LeadRect, int> hlp = (Tuple<string, LeadRect, int>)node.Tag;

            EnableHiLite(hlp.Item1, hlp.Item2);

            TryGotoPage(hlp.Item3 - 1);
         }


         UI.ViewerControl.OmrCollectionDialog ocd = new UI.ViewerControl.OmrCollectionDialog(f, isGraded);
         if (ocd.ShowDialog() == DialogResult.OK)
         {
            node.Text = f.Name;
            node.Name = f.Name;
         }

         DisableHilite();
      }

      private void EditNode(Field f, TreeNode node)
      {
         EnableHiLite(GetZoneColor(f), f.Bounds);

         TryGotoPage(f.PageNumber - 1);

         bool updateIdentifier = templateForm.IdentifierFieldId != null && f.Name == templateForm.IdentifierFieldId.FieldName && f.PageNumber == templateForm.IdentifierFieldId.PageNumber;

         if (f is BarcodeField)
         {
            BarcodeFieldDialog bcffd = new UI.BarcodeFieldDialog(f as BarcodeField, _rasterImageViewer.Image.Clone());
            if (bcffd.ShowDialog() == DialogResult.OK)
            {
               node.Text = f.Name;
               node.Name = f.Name;
            }
         }

         if (f is OmrField)
         {
            OmrFieldDialog offd = new OmrFieldDialog(f as OmrField, templateForm.Pages[f.PageNumber - 1].Image.Clone());
            if (offd.ShowDialog() == DialogResult.OK)
            {
               TreeNode newNode = CreateNewNode(f);
               node.Text = newNode.Text;
               node.Name = newNode.Name;
               node.Nodes.Clear();

               TreeNode[] newSubnodes = new TreeNode[newNode.GetNodeCount(false)];
               newNode.Nodes.CopyTo(newSubnodes, 0);
               node.Nodes.AddRange(newSubnodes);
            }
         }

         if (f is OcrField || f is ImageField)
         {
            TextInputDialog tid = new TextInputDialog(f.Name);
            if (tid.ShowDialog() == DialogResult.OK)
            {
               f.Name = tid.Value;
               node.Text = f.Name;
               node.Name = f.Name;
            }
         }

         if (updateIdentifier)
         {
            templateForm.IdentifierFieldId = new FieldId(f.PageNumber, f.Name);
         }

          DisableHilite();
      }

      private void EditNode(Page pg, TreeNode node)
      {
         TextInputDialog tid = new TextInputDialog(pg.PageName);
         if (tid.ShowDialog() == DialogResult.OK)
         {
            pg.PageName = tid.Value;
            node.Text = pg.PageName;
            node.Name = pg.PageName;
         }
      }


      private void trvForm_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
      {
         e.Cancel = _preventExpand;
         _preventExpand = false;
      }

      private void trvForm_BeforeExpand(object sender, TreeViewCancelEventArgs e)
      {
         e.Cancel = _preventExpand;
         _preventExpand = false;
      }
      private void trvForm_MouseDown(object sender, MouseEventArgs e)
      {
         int delta = (int)DateTime.Now.Subtract(_lastMouseDown).TotalMilliseconds;
         _preventExpand = (delta < SystemInformation.DoubleClickTime);
         _lastMouseDown = DateTime.Now;
      }

      private void trvForm_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
      {
         if (e.Button == MouseButtons.Right)
         {
            trvForm.SelectedNode = e.Node;
            ContextMenuStrip cms = BuildContextMenu(e.Node);
            cms.Show(trvForm, e.Location, ToolStripDropDownDirection.Default);
         }

         string ff = GetNodeUnderlyingType(e.Node.FullPath.Split(new string[] { trvForm.PathSeparator }, StringSplitOptions.None));

         if (ff == "Page")
         {
            TryGotoPage(e.Node.Index);
         }
      }

      private ContextMenuStrip BuildContextMenu(TreeNode node)
      {
         ContextMenuStrip cms = new ContextMenuStrip();
         string ff = GetNodeUnderlyingType(node.FullPath.Split(new string[] { trvForm.PathSeparator }, StringSplitOptions.None));

         cms.Items.Add("Edit Node", null, new EventHandler(delegate (object sender, EventArgs e) { EditNode(node); }));

         if (node.Nodes.Count > 0)
         {
            cms.Items.Add(new ToolStripSeparator());
            if (node.IsExpanded)
            {
               cms.Items.Add("Collapse", null, new EventHandler(delegate (object sender, EventArgs e) { node.Collapse(); }));
            }
            else
            {
               cms.Items.Add("Expand", null, new EventHandler(delegate (object sender, EventArgs e) { node.Expand(); }));
            }
         }

         if (ff == "OmrField")
         {
            cms.Items.Add(new ToolStripSeparator());
            cms.Items.Add("Renumber Items...", null, new EventHandler(delegate (object sender, EventArgs e) { ReNumberElements(node); }));

            cms.Items.Add("Rename to Note", null, new EventHandler(delegate (object sender, EventArgs e) { RenameElementsFromNote(node); }));
         }

         if (ff == "Page")
         {
            cms.Items.Add(new ToolStripSeparator());

            int max = node.Parent.GetNodeCount(false);

            ToolStripMenuItem deletePage = new ToolStripMenuItem("&Delete Page", null, deletePageToolStripMenuItem_Click);
            deletePage.Enabled = templateForm.Pages.Count > 0;
            cms.Items.Add(deletePage);

            cms.Items.Add(new ToolStripSeparator());
            ToolStripMenuItem tsmiMovePageUp = new ToolStripMenuItem("Move Page &Up", null, movePageUpToolStripMenuItem_Click);
            tsmiMovePageUp.Enabled = node.Index > 0;
            cms.Items.Add(tsmiMovePageUp);

            ToolStripMenuItem tsmiMovePageDown = new ToolStripMenuItem("Move Page &Down", null, movePageDownToolStripMenuItem_Click);
            tsmiMovePageDown.Enabled = node.Index < max - 1;
            cms.Items.Add(tsmiMovePageDown);
         }

         if (ff == "Field" || ff == "OmrField")
         {
            cms.Items.Add(new ToolStripSeparator());
            ToolStripMenuItem tsmiUp = new ToolStripMenuItem("Move Up", null, new EventHandler(delegate (object sender, EventArgs e) { MoveNode(node, -1); }));
            tsmiUp.Enabled = node.Index > 0;
            cms.Items.Add(tsmiUp);

            ToolStripMenuItem tsmiDown = new ToolStripMenuItem("Move Down", null, new EventHandler(delegate (object sender, EventArgs e) { MoveNode(node, 1); }));
            int max = node.Parent.GetNodeCount(false);
            tsmiDown.Enabled = node.Index < max - 1;
            cms.Items.Add(tsmiDown);

            cms.Items.Add(new ToolStripSeparator());
            cms.Items.Add("Delete", null, new EventHandler(delegate (object sender, EventArgs e) { DeleteNode(node); }));
         }

         return cms;
      }

      private void RenameElementsFromNote(TreeNode node)
      {
         string[] path = node.FullPath.Split(new string[] { trvForm.PathSeparator }, StringSplitOptions.None);

         OmrField omrField = templateForm.Pages.FirstOrDefault(f => f.PageName == path[1]).Fields.FirstOrDefault(f => f.Name == path[2]) as OmrField;

         if (omrField == null)
         {
            return;
         }

         for (int i = 0; i < omrField.Fields.Count; i++)
         {
            OmrCollection f = omrField.Fields[i];
            TreeNode sub = node.Nodes[i];
            string displayText = string.IsNullOrWhiteSpace(f.Note) ? f.Name : f.Note;

            f.Name = displayText;
            sub.Text = displayText;
            sub.Name = displayText;
         }
      }

      private string GetNodeUnderlyingType(string[] v)
      {
         string[] types = new string[] { "Template", "Page", "Field", "OmrCollection", "OmrBubble" };

         if (v.Length != 3)
         {
            return types[v.Length - 1];
         }

         Page pg = templateForm.Pages.FirstOrDefault(f => f.PageName == v[1]);
         if (pg != null)
         {
            return pg.Fields.FirstOrDefault(f => f.Name == v[2]) as OmrField != null ? "OmrField" : "Field";
         }

         return string.Empty;
      }

      private void ReNumberElements(TreeNode node)
      {
         string[] path = node.FullPath.Split(new string[] { trvForm.PathSeparator }, StringSplitOptions.None);

         OmrField omrField = templateForm.Pages.FirstOrDefault(f => f.PageName == path[1]).Fields.FirstOrDefault(f => f.Name == path[2]) as OmrField;

         if (omrField == null)
         {
            return;
         }

         RowNumberDialog rnd = new UI.RowNumberDialog(omrField);

         if (rnd.ShowDialog() == DialogResult.OK)
         {
            ReNumberElements(node, omrField, rnd.Template, rnd.StartingValue);
         }
      }

      private static void ReNumberElements(TreeNode node, OmrField omrField, string text, int value)
      {
         for (int i = 0; i < omrField.Fields.Count; i++)
         {
            OmrCollection f = omrField.Fields[i];
            TreeNode sub = node.Nodes[i];
            string displayText = text.Replace("%", (value + i).ToString());

            f.Name = displayText;
            sub.Text = displayText;
            sub.Name = displayText;
         }
      }

      private void _rasterImageViewer_MouseDoubleClick(object sender, MouseEventArgs e)
      {
         if (_rasterImageViewer.Image == null)
         {
            return;
         }

         LeadPoint logicalPoint = PhysicalToLogical(e.X, e.Y);

         TreeNode pageNode = trvForm.Nodes[0].Nodes[templateForm.Pages[_currentPageIndex].PageName];
         Field hitField = templateForm.Pages[_currentPageIndex].Fields.FirstOrDefault(f => f.Bounds.Contains(logicalPoint));

         // see if a Field was hit
         if (hitField != null && pageNode != null)
         {
            TreeNode fieldNode = pageNode.Nodes[hitField.Name];
            OmrField hitOmrField = hitField as OmrField;

            // see if the hit field is an OmrField and ensure the field's node is extracted
            if (hitOmrField != null && fieldNode != null)
            {
               OmrCollection hitColl = hitOmrField.Fields.FirstOrDefault(f => f.Bounds.Contains(logicalPoint));
               // see if a collection was hit in the field
               if (hitColl != null)
               {
                  TreeNode colNode = fieldNode.Nodes[hitColl.Name];
                  if (colNode != null)
                  {
                     // only check bubbles if the field layout is BubbleWithLabel
                     if (hitOmrField.FieldBubbleLayoutType == OmrFieldBubbleLayoutType.BubbleWithLabel)
                     {
                        // see if any bubbles were struck
                        if (hitColl.Fields.Any(f => f.Bounds.Contains(logicalPoint)))
                        {
                           // if so, extract the hit bubble
                           OmrBubble hitBubble = hitColl.Fields.FirstOrDefault(f => f.Bounds.Contains(logicalPoint));
                           int index = hitColl.Fields.IndexOf(hitBubble);
                           TreeNode bubbleNode = colNode.Nodes[index];

                           // finally, edit the bubble in-place
                           if (colNode.Nodes.Count >= index)
                           {
                              hitColl.Fields[bubbleNode.Index] = EditNode(hitColl.Fields[bubbleNode.Index], bubbleNode);
                           }
                        }
                        else
                        {
                           // if collection hit but not bubble, edit collection
                           EditNode(hitColl, colNode, hitOmrField.Options.GradeThisField);
                        }
                     }
                     else
                     {
                        // if collection hit and not BubbleWithLabel, edit collection regardless
                        EditNode(hitColl, colNode, hitOmrField.Options.GradeThisField);
                     }
                  }
               }
               else
               {
                  // if field hit but not collection, edit field
                  EditNode(hitOmrField, fieldNode);
               }
            }
            else if (fieldNode != null)
            {
               // if field hit but it's not OmrField, only edit it
               EditNode(hitField, fieldNode);
            }
         }
         else if (pageNode != null)
         {
            // otherwise if nothing hit, edit page
            EditNode(templateForm.Pages[_currentPageIndex], pageNode);
         }
      }

      private void tsToggleSubzones_Click(object sender, EventArgs e)
      {
         ZonesUpdated();
      }

      private void _rasterImageViewer_MouseMove(object sender, MouseEventArgs e)
      {
         if (currentZoneType != ZoneType.None || _rasterImageViewer.Image == null || templateForm == null || templateForm.Pages == null ||templateForm.Pages.Count == 0)
         {
            return;
         }
         Cursor cursor = _rasterImageViewer.Cursor;
         Cursor c = Cursors.Cross;
         LeadPoint logicalPoint = PhysicalToLogical(e.X, e.Y);

         Field hitField = templateForm.Pages[_currentPageIndex].Fields.FirstOrDefault(f => f.Bounds.Contains(logicalPoint));

         // see if a Field was hit
         if (hitField != null)
         {
            OmrField hitOmrField = hitField as OmrField;

            // see if the hit field is an OmrField and ensure the field's node is extracted
            if (hitOmrField != null)
            {
               OmrCollection hitColl = hitOmrField.Fields.FirstOrDefault(f => f.Bounds.Contains(logicalPoint));
               // see if a collection was hit in the field
               if (hitColl != null)
               {
                  // only check bubbles if the field layout is BubbleWithLabel
                  if (hitOmrField.FieldBubbleLayoutType == OmrFieldBubbleLayoutType.BubbleWithLabel)
                  {
                     // see if any bubbles were struck
                     if (hitColl.Fields.Any(f => f.Bounds.Contains(logicalPoint)))
                     {
                        // if so, extract the hit bubble
                        OmrBubble hitBubble = hitColl.Fields.FirstOrDefault(f => f.Bounds.Contains(logicalPoint));
                        EnableHiLite(GetZoneColor(hitBubble), hitBubble.Bounds);
                     }
                     else
                     {
                        // if collection hit but not bubble, edit collection
                        EnableHiLite(GetZoneColor(hitColl), hitColl.Bounds);
                     }
                  }
                  else
                  {
                     // if collection hit and not BubbleWithLabel, edit collection regardless
                     EnableHiLite(GetZoneColor(hitColl), hitColl.Bounds);
                  }
               }
               else
               {
                  // if field hit but not collection, edit field
                  EnableHiLite(GetZoneColor(hitOmrField), hitOmrField.Bounds);
               }
            }
            else if (hitField != null)
            {
               EnableHiLite(GetZoneColor(hitField), hitField.Bounds);
            }
         }
         else
         {
            DisableHilite();
         }


         return;
      }

      private void _rasterImageViewer_Leave(object sender, EventArgs e)
      {

      }

      private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OptionsDialog od = new OptionsDialog(MainForm.AutoEstimateMissingOmr);

         od.ShowDialog();

         MainForm.AutoEstimateMissingOmr = od.AutoEstimateMissingOmr;

         timer.Interval = (int)TimeSpan.FromMinutes(Properties.Settings.Default.AutoSaveDelay).TotalMilliseconds;
      }

      private void addPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AddPagesToTemplate(templateForm.Pages.Count);

         TryGotoPage(templateForm.Pages.Count - 1);
      }

      private void deletePageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DeletePage(trvForm.Nodes[0].Nodes[_currentPageIndex]);
      }

      private void movePageUpToolStripMenuItem_Click(object sender, EventArgs e)
      {
         MovePage(trvForm.Nodes[0].Nodes[_currentPageIndex], -1);
      }

      private void movePageDownToolStripMenuItem_Click(object sender, EventArgs e)
      {
         MovePage(trvForm.Nodes[0].Nodes[_currentPageIndex], 1);
      }

      private void editToolStripMenuItem_Click(object sender, EventArgs e)
      {
         for (int i = 0; i < editToolStripMenuItem.DropDownItems.Count; i++)
         {
            editToolStripMenuItem.DropDownItems[i].Enabled = templateForm != null;
         }

         if (templateForm == null)
         {
            return;
         }

         TreeNode node = trvForm.Nodes[0].Nodes[_currentPageIndex];
         int max = node.Parent.GetNodeCount(false);

         movePageUpToolStripMenuItem.Enabled = node.Index > 0;
         movePageDownToolStripMenuItem.Enabled = node.Index < max - 1;

         editNodeToolStripMenuItem.Enabled = trvForm.SelectedNode != null;
      }

      private void deskewToolStripMenuItem_Click(object sender, EventArgs e)
      {
         RasterCommand rc = new DeskewCommand();

         ExecuteRasterCommand(rc);
      }

      private void ExecuteRasterCommand(RasterCommand rc)
      {
         RasterImage image = templateForm.Pages[_currentPageIndex].Image;

         if (templateForm.Pages[_currentPageIndex].Fields.Count > 0)
         {
            DialogResult dr = MessageBox.Show("This will delete the fields on this page.  Are you sure?", "Confirm", MessageBoxButtons.YesNo);

            if (dr == DialogResult.No)
            {
               return;
            }
         }

         Cursor current = this.Cursor;

         try
         {
            this.Cursor = Cursors.WaitCursor;
            rc.Run(image);
         }
         catch (Exception)
         {
            MessageBox.Show("Performing this will invalidate the image.");
         }
         finally
         {
            this.Cursor = current;
         }
      }

      private void by90DegreesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         RotateCommand rc = new RotateCommand(9000, RotateCommandFlags.None, RasterColor.Black);
         ExecuteRasterCommand(rc);
      }

      private void by180DegreesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         RotateCommand rc = new RotateCommand(18000, RotateCommandFlags.None, RasterColor.Black);
         ExecuteRasterCommand(rc);
      }

      private void by270DegreesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         RotateCommand rc = new RotateCommand(27000, RotateCommandFlags.None, RasterColor.Black);
         ExecuteRasterCommand(rc);
      }

      private void horizontallyToolStripMenuItem_Click(object sender, EventArgs e)
      {
         RasterCommand rc = new FlipCommand(true);
         ExecuteRasterCommand(rc);
      }

      private void verticallyToolStripMenuItem_Click(object sender, EventArgs e)
      {
         RasterCommand rc = new FlipCommand(false);
         ExecuteRasterCommand(rc);
      }

      PanViewerForm pvf;
      private void tssShowPanWindow_Click(object sender, EventArgs e)
      {
         if (pvf == null)
         {
            pvf = new PanViewerForm();
            pvf.Owner = this.ParentForm;
         }

         if (_rasterImageViewer.Image != null)
         {
            pvf.SetViewer(_rasterImageViewer);
         }
         else
         {
            pvf.SetViewer(null);
         }

         if (pvf.Visible == false)
         {
            pvf.Show();
         }
      }

      private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Leadtools.Demos.Dialogs.AboutDialog ab = new Leadtools.Demos.Dialogs.AboutDialog("OMR Processing", Leadtools.Demos.Dialogs.ProgrammingInterface.CS);
         ab.ShowDialog(this.ParentForm);
      }

      private void closeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         CloseCurrentTemplate(CloseRequestArgs.ClosingReason.RevertToIntro);
      }

      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         CloseCurrentTemplate(CloseRequestArgs.ClosingReason.ApplicationExiting);
      }
      private void CloseCurrentTemplate(CloseRequestArgs.ClosingReason closeReason)
      {
         if (templateForm != null)
         {
            bool saveHandled = DoCloseTemplate();
            if (saveHandled)
            {
               OnCloseRequested(closeReason);
            }
         }
         else
         {
            OnCloseRequested(closeReason);
         }
      }

      public bool DoCloseTemplate()
      {
         if (templateForm == null || templateForm.Pages.Count == 0)
         {
            return true;
         }

         bool saved = false;
         DialogResult dr = MessageBox.Show(this.ParentForm, "Save changes to the current template?", "Closing", MessageBoxButtons.YesNoCancel);

         if (dr == DialogResult.Yes)
         {
            saved = DoSave();
         }
         else if (dr == DialogResult.No)
         {
            return true;
         }
         else if (dr == DialogResult.Cancel)
         {
            return false;
         }

         return saved;
      }

      private void OnCloseRequested(CloseRequestArgs.ClosingReason state)
      {
         if (CloseRequested != null)
         {
            CloseRequested(this, new CloseRequestArgs(state));
         }
      }

      private void editNodeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         TreeNode node = trvForm.SelectedNode;

         EditNode(node);
      }

      private void trvForm_AfterSelect(object sender, TreeViewEventArgs e)
      {
         TreeNode node = e.Node;

         if (node == null || node.Tag == null)
         {
            DisableHilite();
            return;
         }

         Tuple<string, LeadRect, int> hiliteParams = (Tuple<string, LeadRect, int>)node.Tag;

         if (hiliteParams.Item3 == _currentPageIndex + 1)
         {
            EnableHiLite(hiliteParams.Item1, hiliteParams.Item2);
         }
      }

      private void trvForm_KeyUp(object sender, KeyEventArgs e)
      {
         if (trvForm.SelectedNode == null)
         {
            return;
         }

         TreeNode node = trvForm.SelectedNode;
         string ff = GetNodeUnderlyingType(node.FullPath.Split(new string[] { trvForm.PathSeparator }, StringSplitOptions.None));

         if (e.KeyCode == Keys.Delete && (ff == "Field" || ff == "OmrField"))
         {
            DeleteNode(trvForm.SelectedNode);
         }
         else if (e.KeyCode == Keys.Delete && ff == "Page")
         {
            DeletePage(node);
         }
         else if (e.KeyCode == Keys.Enter)
         {
            EditNode(node);
         }
      }

      private void informationToolStripMenuItem_Click(object sender, EventArgs e)
      {
         InfoDialog id = new InfoDialog();
         id.ShowDialog(this.ParentForm);
      }
   }
}