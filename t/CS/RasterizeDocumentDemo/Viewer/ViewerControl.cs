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
using System.IO;
using System.Drawing.Drawing2D;

using Leadtools.Demos;
using Leadtools;
using Leadtools.Controls;
using Leadtools.Drawing;
using Leadtools.Codecs;

namespace RasterizeDocumentDemo.Viewer
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

      private RasterCodecs _rasterCodecsInstance;
      // Current document
      private string _documentFileName;

      // Ruler size and edges
      private const int _rulerEdge = 10;
      private const int _rulerSize = 20;

      // Default ruler resolution
      private float _defaultRulerXResolution;
      private float _defaultRulerYResolution;

      // The ruler properties
      private RulerPainter _rulerPainter = new RulerPainter();
      private Rectangle _horizontalRulerBounds;
      private Rectangle _verticalRulerBounds;
      private double _horizontalRulerLength;
      private double _verticalRulerLength;
      private float _horizontalRulerResolution;
      private float _verticalRulerResolution;
      private int _horizontalRulerOrigin;
      private int _verticalRulerOrigin;

      private ImageViewerPanZoomInteractiveMode panZoomMode;
      private ImageViewerZoomToInteractiveMode zoomToMode;

      // The viewer transform matrix
      private LeadMatrix _viewerTransform;

      public ViewerControl()
      {
         InitializeComponent();

         InitInteractiveModes();

         _imageList.Items.Clear();

         if (!DesignMode)
         {
            // For smooth rulers
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
         }
      }

      private void InitInteractiveModes()
      {
         _imageViewer.InteractiveModes.BeginUpdate();
         _imageViewer.InteractiveModes.Clear();

         panZoomMode = new ImageViewerPanZoomInteractiveMode();
         panZoomMode.IdleCursor = Cursors.Hand;
         panZoomMode.WorkingCursor = Cursors.Hand;
         panZoomMode.IsEnabled = true;
         panZoomMode.WorkOnBounds = true;
         _imageViewer.InteractiveModes.Add(panZoomMode);

         zoomToMode = new ImageViewerZoomToInteractiveMode();
         zoomToMode.WorkCompleted += new EventHandler(zoomToMode_WorkCompleted);
         zoomToMode.IdleCursor = Cursors.Cross;
         zoomToMode.WorkingCursor = Cursors.Cross;
         zoomToMode.IsEnabled = true;
         zoomToMode.WorkOnBounds = true;
         _imageViewer.InteractiveModes.Add(zoomToMode);

         _imageViewer.InteractiveModes.EndUpdate();
      }

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
         {
            SetMode(panZoomMode);
            // High-quality paint
            HighQualityPaintScaling = true;

            // These events are needed and not visible from the designer, so
            // hook into them here
            _zoomToolStripComboBox.LostFocus += new EventHandler(_zoomToolStripComboBox_LostFocus);
            _pageToolStripTextBox.LostFocus += new EventHandler(_pageToolStripTextBox_LostFocus);

            // Call the transform changed event
            _imageViewer_TransformChanged(_imageViewer, EventArgs.Empty);

            _mousePositionLabel.Text = string.Empty;

            // Move the viewer to the left and down to make room for the rulers
            _imageViewer.Dock = DockStyle.Fill;
            _imageViewer.BringToFront();
            Rectangle rc = _imageViewer.Bounds;

            // Get its bounds
            int rulerOverallSize = _rulerEdge * 2 + _rulerSize;
            rc.X += rulerOverallSize;
            rc.Y += rulerOverallSize;
            rc.Width -= rulerOverallSize;
            rc.Height -= rulerOverallSize;

            _imageViewer.Dock = DockStyle.None;
            _imageViewer.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            _imageViewer.Bounds = rc;

            using (Graphics g = CreateGraphics())
            {
               _defaultRulerXResolution = g.DpiX;
               _defaultRulerYResolution = g.DpiY;
            }

            _rulerPainter.FontFamilyName = Font.FontFamily.Name;
         }

         base.OnLoad(e);
      }

      public void SetMode(ImageViewerInteractiveMode modeToSet)
      {
         if (_imageViewer.Image == null)
            return;

         _imageViewer.InteractiveModes.BeginUpdate();
         foreach (ImageViewerInteractiveMode mode in _imageViewer.InteractiveModes)
         {
            if (mode == modeToSet)
               mode.IsEnabled = true;
            else
               mode.IsEnabled = false;
         }
         _imageViewer.InteractiveModes.EndUpdate();
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

         _imageViewer.BeginUpdate();

         ControlSizeMode sizeMode = ControlSizeMode.Fit;

         if (fitWidth)
         {
            sizeMode = ControlSizeMode.FitWidth;
         }

         _imageViewer.Zoom(sizeMode, 1, _imageViewer.DefaultZoomOrigin);

         _imageViewer.EndUpdate();

         UpdateUIState();
      }

      /// <summary>
      /// Zoom the viewer in our out
      /// </summary>
      /// <param name="zoomOut"></param>
      public void ZoomViewer(bool zoomOut)
      {
         // Get the current scale factor
         double percentage = _imageViewer.XScaleFactor * 100.0;

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
      /// Called by the main form to get/set the current ruler unit
      /// </summary>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool RulerInInches
      {
         get
         {
            return (_rulerPainter.Unit == RulerPainterUnit.Inch);
         }
         set
         {
            RulerPainterUnit newUnit = (value) ? RulerPainterUnit.Inch : RulerPainterUnit.Millimeter;

            if (newUnit != _rulerPainter.Unit)
            {
               _rulerPainter.Unit = newUnit;
               UpdateRulers();
               UpdatePageInfo();
               Invalidate();
            }
         }
      }

      /// <summary>
      /// Called by the main form to set a new document into the viewer
      /// </summary>
      public void SetDocument(string documentFileName, int firstPageNumber, int lastPageNumber, RasterCodecs rasterCodecsInstance)
      {
         _documentFileName = documentFileName;
         _rasterCodecsInstance = rasterCodecsInstance;

         // Create the pages thumbnails
         _imageList.Items.Clear();
         for (int pageNumber = firstPageNumber; pageNumber <= lastPageNumber; pageNumber++)
         {
            RasterImage thumbnailImage = _rasterCodecsInstance.Load(_documentFileName, 160, 160, 0, RasterSizeFlags.Resample, CodecsLoadByteOrder.BgrOrGray, pageNumber, pageNumber);
            if (thumbnailImage != null)
            {
               int viewPageNumber = pageNumber - firstPageNumber + 1;
               ImageViewerItem item = new ImageViewerItem();
               item.Image = thumbnailImage;
               item.Tag = pageNumber;
               item.Text = "Page " + viewPageNumber.ToString();
               _imageList.Items.Add(item);
            }
            _imageList.Items[0].IsSelected = true;
         }

         UpdateImageInfo();
         UpdatePageInfo();
         UpdateUIState();
      }

      /// <summary>
      /// Called by the main form to get the viewer
      /// </summary>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public ImageViewer ImageViewer
      {
         get
         {
            return _imageViewer;
         }
      }

      /// <summary>
      /// Called by the main form to get the first loaded page index
      /// </summary>
      public int FirstPage
      {
         get
         {
            if (PagesCount > 0)
               return (int)_imageList.Items[0].Tag;

            return 0;
         }
      }

      /// <summary>
      /// Called by the main form to get the last loaded page index
      /// </summary>
      public int LastPage
      {
         get
         {
            if (PagesCount > 0)
               return (int)_imageList.Items[PagesCount - 1].Tag;

            return 0;
         }
      }

      /// <summary>
      /// Called by the main form to get the current page index
      /// </summary>
      public int CurrentPage
      {
         get
         {
            if(_imageList.ActiveItem != null)
               return (int)_imageList.ActiveItem.Tag;

            return 0;
         }
      }

      /// <summary>
      /// Called by the main form to get the total pages count
      /// </summary>
      public int PagesCount
      {
         get
         {
            return _imageList.Items.Count;
         }
      }

      /// <summary>
      /// Called by the main form to get/set the paint scaling
      /// </summary>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool HighQualityPaintScaling
      {
         get
         {
            RasterPaintProperties props = _imageViewer.PaintProperties;

            bool highQuality =
               (props.PaintDisplayMode & RasterPaintDisplayModeFlags.ScaleToGray) == RasterPaintDisplayModeFlags.ScaleToGray &&
               (props.PaintDisplayMode & RasterPaintDisplayModeFlags.Bicubic) == RasterPaintDisplayModeFlags.Bicubic;

            return highQuality;
         }
         set
         {
            RasterPaintProperties props = _imageViewer.PaintProperties;

            if (value)
            {
               // Set the paint scaling to ScaleToGray (for 1-bit images) and Bicubic (for color images)
               props.PaintDisplayMode |= RasterPaintDisplayModeFlags.ScaleToGray | RasterPaintDisplayModeFlags.Bicubic;
            }
            else
            {
               // Set to highest speed
               props.PaintDisplayMode &= ~(RasterPaintDisplayModeFlags.ScaleToGray | RasterPaintDisplayModeFlags.Bicubic);
            }

            _imageViewer.PaintProperties = props;
            _imageList.PaintProperties = props;
         }
      }

      private void UpdateImageInfo()
      {
         if (!string.IsNullOrEmpty(_documentFileName))
         {
            if (!_imageInfoTableLayoutPanel.Visible)
            {
               _imageInfoTableLayoutPanel.Visible = true;
            }

            // Update the info panel with current image information
            RasterImage image = _imageViewer.Image;

            long fileLength;

            try
            {
               FileInfo fi = new FileInfo(_documentFileName);
               fileLength = fi.Length;
            }
            catch (Exception)
            {
               fileLength = 0;
            }

            _imageInfoFileSizeValueLabel.Text = string.Format("{0} KB ({1} Bytes)", ((double)fileLength / 1024.0).ToString("0.00"), fileLength.ToString("#,#"));

            // The rest (size, bits/pixel) etc gets updated when the page is updated
         }
         else
         {
            _imageInfoTableLayoutPanel.Visible = false;
         }
      }

      private void UpdatePageInfo()
      {
         RasterImage image = _imageViewer.Image;
         if (image != null)
         {
            long dataSize = image.DataSize;
            _imageInfoMemorySizeValueLabel.Text = string.Format("{0} KB ({1} Bytes)", ((double)dataSize / 1024.0).ToString("0.00"), dataSize.ToString("#,#"));
            _imageInfoBitsPerPixelValueLabel.Text = image.BitsPerPixel.ToString();

            _imageInfoPageSizePixelsLabel.Text = string.Format("{0} x {1}   pixels", image.ImageWidth, image.ImageHeight);

            int xResolution = image.XResolution;
            int yResolution = image.YResolution;
            _imageInfoPageSizeResolutionLabel.Text = string.Format("{0} x {1}   pixels/inch", xResolution, yResolution);

            float cxInches = (float)image.ImageWidth / (float)xResolution;
            float cyInches = (float)image.ImageHeight / (float)yResolution;

            if (RulerInInches)
            {
               _imageInfoPageSizeLogicalLabel.Text = string.Format("{0} x {1}   inches", cxInches.ToString("0.00"), cyInches.ToString("0.00"));
            }
            else
            {
               // The ruler is in metric
               double cxMM = InchesToMM(cxInches);
               double cyMM = InchesToMM(cyInches);
               _imageInfoPageSizeLogicalLabel.Text = string.Format("{0} x {1}   cm", (cxMM / 10.0).ToString("0.00"), (cyMM / 10.0).ToString("0.00"));
            }
         }
      }

      private void UpdateZoomValueFromControl()
      {
         // We are invoking this instead of changing the properties
         // directly because the Text value of a combo box is not
         // updated till after the lost focus or enter event is exited
         BeginInvoke(new MethodInvoker(delegate()
         {
            if (_imageViewer.Image != null)
            {
               double factor = _imageViewer.XScaleFactor * 100.0;
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

         _fitPageWidthToolStripButton.Checked = _imageViewer.SizeMode == ControlSizeMode.FitWidth;
         _fitPageToolStripButton.Checked = _imageViewer.SizeMode == ControlSizeMode.Fit;
         _useDpiToolStripButton.Checked = _imageViewer.UseDpi;

         _panModeToolStripButton.Checked = panZoomMode.IsEnabled;
         _zoomToSelectionModeToolStripButton.Checked = zoomToMode.IsEnabled;

         if (_imageViewer.Image != null)
         {
            if (!_toolStrip.Enabled)
            {
               _toolStrip.Enabled = true;
            }

            int currentPage = CurrentPage;
            int pageCount = PagesCount;

            _pageToolStripTextBox.Text = GetViewPageString(currentPage);
            _pageToolStripLabel.Text = "/ " + pageCount.ToString();

            _pageToolStripTextBox.Enabled = pageCount > 1;

            _previousPageToolStripButton.Enabled = currentPage > FirstPage;
            _nextPageToolStripButton.Enabled = currentPage < LastPage;

            UpdatePageInfo();
         }
         else
         {
            if (_toolStrip.Enabled)
            {
               _toolStrip.Enabled = false;
            }

            _pageToolStripTextBox.Text = "0";
            _pageToolStripLabel.Text = "/ 0";

            _zoomToolStripComboBox.Text = string.Empty;
         }
      }

      private void _imageViewer_TransformChanged(object sender, EventArgs e)
      {
         if (!DesignMode && IsHandleCreated)
         {
            _viewerTransform = _imageViewer.ViewTransform;

            UpdateZoomValueFromControl();
            UpdateUIState();
            UpdateRulers();
         }
      }

      private void _previousPageToolStripButton_Click(object sender, EventArgs e)
      {
         int currentPage = CurrentPage;
         TryGotoPage(currentPage - 1);
      }

      private void _nextPageToolStripButton_Click(object sender, EventArgs e)
      {
         int currentPage = CurrentPage;
         TryGotoPage(currentPage + 1);
      }

      private void _pageToolStripTextBox_LostFocus(object sender, EventArgs e)
      {
         _pageToolStripTextBox.Text = GetViewPageString(CurrentPage);
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
               TryGotoPage(pageNumber + FirstPage - 1);

            _pageToolStripTextBox.Text = GetViewPageString(CurrentPage);
         }
      }

      private string GetViewPageString(int page)
      {
         return (page - FirstPage + 1).ToString();
      }

      public void TryGotoPage(int pageNumber)
      {
         // Check if the index is valid
         if (pageNumber >= FirstPage && pageNumber <= LastPage)
         {
            int page = pageNumber - FirstPage;
            // Set the page number in the image list
            _imageList.BeginUpdate();

            for (int i = 0; i < PagesCount; i++)
            {
               ImageViewerItem item = _imageList.Items[i];

               if ((int)item.Tag == pageNumber)
                  item.IsSelected = true;
               else
                  item.IsSelected = false;
            }

            _imageList.EnsureItemVisible(_imageList.Items[page]);
            _imageList.EndUpdate();
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
               {
                  str = str.Remove(str.Length - 1, 1).Trim();
               }

               // Try to parse the new zoom value
               double percentage;
               if (double.TryParse(str, out percentage))
               {
                  SetViewerZoomPercentage(percentage);
               }

               UpdateZoomValueFromControl();
            }
         }
      }

      private void SetViewerZoomPercentage(double percentage)
      {
         // Normalize the percentage based on min/max value allowed
         percentage = Math.Max(_minimumViewerScalePercentage, Math.Min(_maximumViewerScalePercentage, percentage));

         if (Math.Abs(_imageViewer.XScaleFactor * 100.0 - percentage) > 0.01)
         {
            _imageViewer.BeginUpdate();

            // Zoom
            double scaleFactor = percentage / 100.0;

            _imageViewer.Zoom(ControlSizeMode.None, scaleFactor, _imageViewer.DefaultZoomOrigin);

            _imageViewer.EndUpdate();

            _imageViewer_TransformChanged(_imageViewer, EventArgs.Empty);

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

      private void _useDpiToolStripButton_Click(object sender, EventArgs e)
      {
         _imageViewer.UseDpi = !_imageViewer.UseDpi;
      }

      private void _panModeToolStripButton_Click(object sender, EventArgs e)
      {
         SetMode(panZoomMode); ;
      }

      private void _zoomToSelectionModeToolStripButton_Click(object sender, EventArgs e)
      {
         SetMode(zoomToMode);
      }

      void zoomToMode_WorkCompleted(object sender, EventArgs e)
      {
         BeginInvoke(new MethodInvoker(_panModeToolStripButton.PerformClick));
      }

      private void _imageViewer_MouseMove(object sender, MouseEventArgs e)
      {
         string str = string.Empty;

         if (_imageViewer.Image != null)
         {
            // Show the mouse position in physical and logical (inches) coordinates
            if (_imageViewer.DisplayRectangle.Contains(e.X, e.Y))
            {
               LeadPoint physical = LeadPoint.Create(e.X, e.Y);
               LeadPoint pixels = _imageViewer.ConvertPoint(null, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, physical);

               // Convert the logical point to inches
               PointF inches = PointF.Empty;
               inches.X = (float)pixels.X / (float)_imageViewer.Image.XResolution;
               inches.Y = (float)pixels.Y / (float)_imageViewer.Image.YResolution;

               str = string.Format("{0},{1} px {2},{3} in", (int)pixels.X, (int)pixels.Y, inches.X.ToString("F02"), inches.Y.ToString("F02"));
            }
         }

         _mousePositionLabel.Text = str;
      }

      private void _imageList_SelectedItemsChanged(object sender, EventArgs e)
      {
         //Find the selected item and set it to be the Active Item
         //Load the full resolution page
         for (int i = 0; i < PagesCount; i++)
         {
            if (_imageList.Items[i].IsSelected)
            {
               _imageList.ActiveItem = _imageList.Items[i];
               _imageViewer.Image = _rasterCodecsInstance.Load(_documentFileName, (int)_imageList.Items[i].Tag);
            }
         }

         UpdateUIState();
      }

      private void UpdateRulers()
      {
         RasterImage image = _imageViewer.Image;
         if (image == null)
         {
            return;
         }

         _horizontalRulerResolution = _defaultRulerXResolution;
         _verticalRulerResolution = _defaultRulerXResolution;

         // Update the ruler lengths
         if (_imageViewer.UseDpi)
         {
            _horizontalRulerLength = (double)(image.ImageWidth) / image.XResolution;
            _verticalRulerLength = (double)(image.ImageHeight) / image.YResolution;
         }
         else
         {
            _horizontalRulerLength = (double)(image.ImageWidth) / _defaultRulerXResolution;
            _verticalRulerLength = (double)(image.ImageHeight) / _defaultRulerYResolution;
         }

         // The length is in inches, see if we need it in mm
         if (_rulerPainter.Unit == RulerPainterUnit.Millimeter)
         {
            _horizontalRulerLength = InchesToMM(_horizontalRulerLength);
            _verticalRulerLength = InchesToMM(_verticalRulerLength);
         }

         // Update the ruler bounds
         _horizontalRulerBounds = new Rectangle(_imageViewer.Left - (_rulerEdge), _imageViewer.Top - (_rulerEdge + _rulerSize), ClientSize.Width, _rulerSize);
         _verticalRulerBounds = new Rectangle(_imageViewer.Left - (_rulerEdge + _rulerSize), _imageViewer.Top - (_rulerEdge), _rulerSize, ClientSize.Height);

         LeadPoint pt = _imageViewer.ConvertPoint(null, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, LeadPoint.Empty);

         _horizontalRulerOrigin = (int)pt.X + _rulerEdge;
         _verticalRulerOrigin = (int)pt.Y + _rulerEdge;

         Invalidate();
      }

      private static double InchesToMM(double inchesValue)
      {
         // The length is in inches, see if we need it in mm
         const double mmRatio = 25.400000025908000026426160026955;
         double mmValue = inchesValue * mmRatio;
         return mmValue;
      }

      protected override void OnPaint(PaintEventArgs e)
      {
         if (_imageViewer.Image != null)
         {
            Graphics g = e.Graphics;

            // Paint the horizontal ruler
            Rectangle bounds = _horizontalRulerBounds;
            _rulerPainter.Orientation = RulerPainterOrientation.Horizontal;
            _rulerPainter.Resolution = _horizontalRulerResolution;
            _rulerPainter.ScaleFactor = _imageViewer.XScaleFactor;
            _rulerPainter.OriginPixelOffset = _horizontalRulerOrigin;
            _rulerPainter.Length = _horizontalRulerLength;
            _rulerPainter.Paint(g, bounds);

            // Paint the vertical ruler
            bounds = _verticalRulerBounds;
            _rulerPainter.Orientation = RulerPainterOrientation.Vertical;
            _rulerPainter.Resolution = _verticalRulerResolution;
            _rulerPainter.ScaleFactor = _imageViewer.YScaleFactor;
            _rulerPainter.OriginPixelOffset = _verticalRulerOrigin;
            _rulerPainter.Length = _verticalRulerLength;
            _rulerPainter.Paint(g, bounds);
         }
      }
   }
}
