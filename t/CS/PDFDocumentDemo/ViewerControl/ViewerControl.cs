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
using Leadtools.Drawing;
using Leadtools.Controls;
using Leadtools.Pdf;
using Leadtools.Annotations.WinForms;
using Leadtools.Demos;
using Leadtools.Codecs;

namespace PDFDocumentDemo.ViewerControl
{
   public partial class ViewerControl : UserControl
   {
      #region Private
      // Minimum and maximum scale percentages allowed
      private const double _minimumViewerScalePercentage = 1;
      private const double _maximumViewerScalePercentage = 6400;

      // Current interactive mode (with the mouse)
      private ViewerControlInteractiveMode _interactiveMode;

      //Interactive Modes
      ImageViewerNoneInteractiveMode _noneInteractiveMode;
      AutomationInteractiveMode _automationInteractiveMode;
      ImageViewerPanZoomInteractiveMode _panInteractiveMode;
      ImageViewerZoomToInteractiveMode _zoomToInteractiveMode;
      ImageViewerAddRegionInteractiveMode _regionInteractiveMode;
      ImageViewerRubberBandInteractiveMode _rectangleInteractiveMode;

      //Interactive mode public methods
      public ImageViewerNoneInteractiveMode NoneInteractiveMode
      {
         get
         { return _noneInteractiveMode; }
         set
         { _noneInteractiveMode = value; }
      }

      public AutomationInteractiveMode automationInteractiveMode
      {
         get { return _automationInteractiveMode; }
         set { _automationInteractiveMode = value; }
      }


      public ImageViewerPanZoomInteractiveMode PanInteractiveMode
      {
         get
         { return _panInteractiveMode; }
         set
         { _panInteractiveMode = value; }
      }



      public ImageViewerZoomToInteractiveMode ZoomToInteractiveMode
      {
         get
         { return _zoomToInteractiveMode; }
         set
         { _zoomToInteractiveMode = value; }
      }

      public ImageViewerAddRegionInteractiveMode RegionInteractiveMode
      {
         get { return _regionInteractiveMode; }
         set { _regionInteractiveMode = value; }
      }

      public ImageViewerRubberBandInteractiveMode RectangleInteractiveMode
      {
         get { return _rectangleInteractiveMode; }
         set { _rectangleInteractiveMode = value; }
      }

      // Current PDF document
      private PDFDocument _document;
      private bool _isNewDocument;

      // The selected text for each page
      private Dictionary<int, MyWord[]> _selectedText;

      // Current page number
      private int _currentPageNumber;

      // These are the hyperlinks and internal links of the current page
      // We group them here because we will check them often in the mouse move
      private struct PageLink
      {
         public LeadRect ImageBounds;     // The bounds of the link in image coordinates
         public int InternalLinkIndex;   // If not -1, the index into PDFDocument.InternalLinks
         public int HyperLinkIndex;      // If not -1, the index into PDFPage.Hyperlinks
      }

      private List<PageLink> _pageLinks;

      private void UpdatePageInfo()
      {
         StringBuilder sb = new StringBuilder();

         if (_document != null)
         {
            PDFDocumentPage page = _document.Pages[_currentPageNumber - 1];
            sb.AppendFormat(DemosGlobalization.GetResxString(GetType(), "resx_SizeBy"), page.WidthPixels, page.HeightPixels, page.WidthInches.ToString("F02"), page.HeightInches.ToString("F02"));
         }

         _pageInfoLabel.Text = sb.ToString();
      }

      private delegate void DoActionDelegate(string action, object data);

      private void DoAction(string action, object data)
      {
         // Raise the action event so the main form can handle it

         if (Action != null)
         {
            Action(this, new ActionEventArgs(action, data));
         }
      }
      #endregion Private

      #region Control
      public ViewerControl()
      {
         InitializeComponent();

         Leadtools.Controls.ControlDropShadowOptions dropShadow = this._rasterImageViewer.ImageDropShadow;
         dropShadow.IsVisible = true;
         this._rasterImageViewer.ImageDropShadow = dropShadow;

         //Initialize Interactive modes
         InitializeInteractivemodes();
      }

      private void InitializeInteractivemodes()
      {
         //None
         NoneInteractiveMode = new ImageViewerNoneInteractiveMode();
         _rasterImageViewer.InteractiveModes.Add(NoneInteractiveMode);
         //Annotations
         automationInteractiveMode = new AutomationInteractiveMode();
         automationInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left | System.Windows.Forms.MouseButtons.Right;
         automationInteractiveMode.IdleCursor = Cursors.Default;
         automationInteractiveMode.WorkingCursor = Cursors.Default;
         _rasterImageViewer.InteractiveModes.Add(automationInteractiveMode);
         //Pan
         PanInteractiveMode = new ImageViewerPanZoomInteractiveMode();
         PanInteractiveMode.EnablePan = true;
         PanInteractiveMode.EnableZoom = false;
         PanInteractiveMode.EnablePinchZoom = false;
         PanInteractiveMode.WorkOnBounds = true;
         _rasterImageViewer.InteractiveModes.Add(PanInteractiveMode);
         //ZoomTo
         ZoomToInteractiveMode = new ImageViewerZoomToInteractiveMode();
         ZoomToInteractiveMode.WorkOnBounds = true;
         ZoomToInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle;
         ZoomToInteractiveMode.WorkCompleted+=new EventHandler(ZoomToInteractiveMode_WorkCompleted);
         _rasterImageViewer.InteractiveModes.Add(ZoomToInteractiveMode);
         //Region
         RegionInteractiveMode = new ImageViewerAddRegionInteractiveMode();
         RegionInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle;
         RegionInteractiveMode.AutoRegionToFloater = true;
         RegionInteractiveMode.WorkOnBounds = true;
         _rasterImageViewer.InteractiveModes.Add(RegionInteractiveMode);
         //Rectangle
         RectangleInteractiveMode = new ImageViewerRubberBandInteractiveMode();
         RectangleInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle;
         RectangleInteractiveMode.WorkOnBounds = true;
         RectangleInteractiveMode.RubberBandCompleted+=new EventHandler<ImageViewerRubberBandEventArgs>(RectangleInteractiveMode_RubberBandCompleted);
         _rasterImageViewer.InteractiveModes.Add(RectangleInteractiveMode);

         automationInteractiveMode.IsEnabled = true;
         _rasterImageViewer.InteractiveModes.EnableById(automationInteractiveMode.Id);
      }

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
         {
            // We cannot run without document support
            if (!RasterSupport.IsLocked(RasterSupportType.Document))
            {
               InitViewer();

               // These events are needed and not visible from the designer, so hook into them here
               _zoomToolStripComboBox.LostFocus += new EventHandler(_zoomToolStripComboBox_LostFocus);
               _pageToolStripTextBox.LostFocus += new EventHandler(_pageToolStripTextBox_LostFocus);

               // Call the transform changed event
               _rasterImageViewer_TransformChanged(_rasterImageViewer, EventArgs.Empty);

               InteractiveMode = ViewerControlInteractiveMode.SelectMode;

               _mousePositionLabel.Text = string.Empty;
            }
         }

         base.OnLoad(e);
      }
      #endregion Control

      #region Public
      /// <summary>
      /// The instance of RasterImageViewer used in this viewer
      /// </summary>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public AutomationImageViewer RasterImageViewer
      {
         get
         {
            return _rasterImageViewer;
         }
      }

      /// <summary>
      /// Called by the main form to set the new document
      /// </summary>
      public void SetDocument(PDFDocument document, Dictionary<int, MyWord[]> selectedText)
      {
         _document = document;
         _selectedText = selectedText;
         _currentPageNumber = 1;
         _isNewDocument = true;

         UpdatePageInfo();
         UpdateUIState();
      }

      public void RunLink(PDFDocument document, PDFPageFitType pageFitType, int zoomPercent)
      {
         _rasterImageViewer.BeginUpdate();

         ControlSizeMode sizeMode;

         switch (pageFitType)
         {
            case PDFPageFitType.FitWidth:
            case PDFPageFitType.FitWidthBounds:
               sizeMode = ControlSizeMode.FitWidth;
               break;

            case PDFPageFitType.FitHeight:
            case PDFPageFitType.FitHeightBounds:
            case PDFPageFitType.FitBounds:
               sizeMode = ControlSizeMode.Fit;
               break;

            case PDFPageFitType.Default:
            default:
               sizeMode = ControlSizeMode.ActualSize;
               break;
         }

         if (sizeMode != ControlSizeMode.ActualSize)
         {
            FitPage(sizeMode == ControlSizeMode.FitWidth);
         }
         else
         {
            if (zoomPercent != 0)
            {
               SetViewerZoomPercentage(zoomPercent);
            }
         }

         _rasterImageViewer.ScrollOffset = LeadPoint.Empty;
         _rasterImageViewer.EndUpdate();
      }

      /// <summary>
      /// Called by the main form when the page number of the image is changed
      /// </summary>
      public void SetCurrentPageNumber(int pageNumber, RasterImage pageImage)
      {
         _currentPageNumber = pageNumber;

         ImageViewerAutoResetOptions savedOptions = _rasterImageViewer.AutoResetOptions;
         _rasterImageViewer.AutoResetOptions = ImageViewerAutoResetOptions.None;
         _rasterImageViewer.Image = pageImage;
         _rasterImageViewer.AutoResetOptions = savedOptions;

         if (_isNewDocument)
         {
            // Fit page when new document is set
            _isNewDocument = false;
            FitPage(false);
         }

         // Build the page internal links
         _pageLinks = new List<PageLink>();

         // Loop through the document internal links
         if (_document != null)
         {
            // Get the page
            PDFDocumentPage page = _document.Pages[_currentPageNumber - 1];

            if (_document.InternalLinks != null)
            {
               for (int i = 0; i < _document.InternalLinks.Count; i++)
               {
                  if (_document.InternalLinks[i].SourcePageNumber == pageNumber)
                  {
                     // Our page
                     PageLink link = new PageLink();
                     link.InternalLinkIndex = i;
                     link.HyperLinkIndex = -1;
                     // The internal links bounds are in PDF page coordinates, not objects
                     link.ImageBounds = ToLeadRect(page.ConvertRect(PDFCoordinateType.Pdf, PDFCoordinateType.Pixel, _document.InternalLinks[i].SourceBounds));
                     _pageLinks.Add(link);
                  }
               }
            }

            // Now add all hyperlinks
            if (page.Hyperlinks != null)
            {
               for (int i = 0; i < page.Hyperlinks.Count; i++)
               {
                  PageLink link = new PageLink();
                  link.HyperLinkIndex = i;
                  link.InternalLinkIndex = -1;
                  link.ImageBounds = ToLeadRect(page.ConvertRect(PDFCoordinateType.Pdf, PDFCoordinateType.Pixel, page.Hyperlinks[i].Bounds));
                  _pageLinks.Add(link);
               }
            }
         }

         UpdatePageInfo();
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

         _rasterImageViewer.Zoom(ControlSizeMode.None, 1, _rasterImageViewer.DefaultZoomOrigin);

         if (fitWidth)
         {
            _rasterImageViewer.Zoom(ControlSizeMode.FitWidth, 1, _rasterImageViewer.DefaultZoomOrigin);
         }
         else
         {
            _rasterImageViewer.Zoom(ControlSizeMode.FitAlways, 1, _rasterImageViewer.DefaultZoomOrigin);
         }

         _rasterImageViewer.EndUpdate();

         UpdateUIState();
      }

      /// <summary>
      /// Zoom the viewer in our out
      /// </summary>
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
      }

      public void DisableAllInteractiveModes(AutomationImageViewer CurrentViewer)
      {
         foreach (ImageViewerInteractiveMode mode in CurrentViewer.InteractiveModes)
            mode.IsEnabled = false;
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

            DisableAllInteractiveModes(RasterImageViewer);
            // Set the RasterImageViewer interactive mode accordingly
            switch (_interactiveMode)
            {
               case ViewerControlInteractiveMode.SelectMode:
                  automationInteractiveMode.IsEnabled = true;
                  RasterImageViewer.InteractiveModes.EnableById(automationInteractiveMode.Id);
                  break;

               case ViewerControlInteractiveMode.HighlightTextMode:
                  RectangleInteractiveMode.IsEnabled = true;
                  RasterImageViewer.InteractiveModes.EnableById(RectangleInteractiveMode.Id);
                  break;

               case ViewerControlInteractiveMode.PanMode:
                  PanInteractiveMode.IsEnabled = true;
                  RasterImageViewer.InteractiveModes.EnableById(PanInteractiveMode.Id);
                  break;

               case ViewerControlInteractiveMode.ZoomToSelectionMode:
                  ZoomToInteractiveMode.IsEnabled = true;
                  RasterImageViewer.InteractiveModes.EnableById(ZoomToInteractiveMode.Id);
                  break;
            }

            if (InteractiveModeChanged != null)
               InteractiveModeChanged(this, EventArgs.Empty);

            UpdateUIState();
         }
      }

      public event EventHandler InteractiveModeChanged;

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool HighlightObjects
      {
         get
         {
            return _highlightObjectsToolStripButton.Checked;
         }
         set
         {
            _highlightObjectsToolStripButton.Checked = value;
            _rasterImageViewer.Invalidate();
         }
      }

      /// <summary>
      /// This event is fired by the control when an action occurs that must be handled by
      /// the owner (the main form)
      /// </summary>
      public event EventHandler<ActionEventArgs> Action;
      #endregion Public

      #region Viewer
      private void InitViewer()
      {
         // Use ScaleToGray and Bicubic for optimum viewing of black/white and color images
         RasterPaintProperties props = _rasterImageViewer.PaintProperties;
         props.PaintDisplayMode |= RasterPaintDisplayModeFlags.ScaleToGray | RasterPaintDisplayModeFlags.Bicubic;
         _rasterImageViewer.PaintProperties = props;

         // Pad the viewer
         Padding tempPadding = _rasterImageViewer.Padding;
         tempPadding.All = 16;
         _rasterImageViewer.Padding = tempPadding;

         _rasterImageViewer.ViewMargin = Padding.Empty;
         _rasterImageViewer.ImageBorderThickness = 0;
         ControlDropShadowOptions dropShadow = _rasterImageViewer.ImageDropShadow;
         dropShadow.IsVisible = false;
         _rasterImageViewer.ImageDropShadow = dropShadow;
         // Set the cursors
         NoneInteractiveMode.WorkingCursor = NoneInteractiveMode.IdleCursor = Cursors.Arrow;
         PanInteractiveMode.WorkingCursor = PanInteractiveMode.IdleCursor = Cursors.Hand;
         ZoomToInteractiveMode.WorkingCursor = ZoomToInteractiveMode.IdleCursor = Cursors.Cross;
         RegionInteractiveMode.WorkingCursor = RegionInteractiveMode.IdleCursor = Cursors.Cross;
         RectangleInteractiveMode.WorkingCursor = RectangleInteractiveMode.IdleCursor = Cursors.Cross;
      }

      void _rasterImageViewer_PostRender(object sender, Leadtools.Controls.ImageViewerRenderEventArgs e)
      {
         PDFDocumentPage page = _document.Pages[_currentPageNumber - 1];
         if (_selectedText != null && _selectedText[_currentPageNumber] != null)
         {
            HighlightSelectedWords(e.PaintEventArgs.Graphics);
         }

         if (HighlightObjects && _document != null)
         {
            HighlightObjectsData data = new HighlightObjectsData();
            data.TextBrush = new SolidBrush(Color.FromArgb(128, Color.Yellow));
            data.RetangleBrush = new SolidBrush(Color.FromArgb(128, Color.Black));
            data.ImageBrush = new SolidBrush(Color.FromArgb(128, Color.Red));
            data.HyperlinkBrush = new SolidBrush(Color.FromArgb(128, Color.Blue));
            data.InternalLinkBrush = new SolidBrush(Color.FromArgb(128, Color.Green));

            DrawHighlightObjects(e.PaintEventArgs.Graphics, data, page);
            DrawLegends(e.PaintEventArgs.Graphics, data);

            data.TextBrush.Dispose();
            data.RetangleBrush.Dispose();
            data.ImageBrush.Dispose();
            data.HyperlinkBrush.Dispose();
            data.InternalLinkBrush.Dispose();
         }

         if (_highlightSelectedImageObject && !HighlightObjects)
         {
            using(Brush imageBrush = new SolidBrush(Color.FromArgb(128, Color.Red)))
            {
               DrawHighlightImageObject(e.PaintEventArgs.Graphics, imageBrush, page);
            }
         }
      }

      private void _rasterImageViewer_TransformChanged(object sender, EventArgs e)
      {
         if (IsHandleCreated && !DesignMode)
         {
            UpdateZoomValueFromControl();
            UpdateUIState();
         }
      }

      void RectangleInteractiveMode_RubberBandCompleted(object sender, ImageViewerRubberBandEventArgs e)
      {
         Rectangle pixels = new Rectangle(e.InteractiveEventArgs.Origin.X, e.InteractiveEventArgs.Origin.Y, e.InteractiveEventArgs.Position.X - e.InteractiveEventArgs.Origin.X, e.InteractiveEventArgs.Position.Y - e.InteractiveEventArgs.Origin.Y);

         if (pixels.Left > pixels.Right)
         {
            pixels = Rectangle.FromLTRB(pixels.Right, pixels.Top, pixels.Left, pixels.Bottom);
         }
         if (pixels.Top > pixels.Bottom)
         {
            pixels = Rectangle.FromLTRB(pixels.Left, pixels.Bottom, pixels.Right, pixels.Top);
         }

         if (pixels.Width > 2 && pixels.Height > 2)
         {
            RectangleF pixelsF = pixels;


            LeadMatrix mm = _rasterImageViewer.GetImageTransformWithDpi(true);
            Matrix m = new Matrix((float)mm.M11, (float)mm.M12, (float)mm.M21, (float)mm.M22, (float)mm.OffsetX, (float)mm.OffsetY);
            Transformer trans = new Transformer(m);
            pixelsF = trans.RectangleToLogical(pixelsF);


            pixelsF = RectangleF.Intersect(new RectangleF(0, 0, _rasterImageViewer.Image.ImageWidth, _rasterImageViewer.Image.ImageHeight), pixelsF);
            pixels = Rectangle.Round(pixelsF);

            LeadRect bounds = new LeadRect(pixels.X, pixels.Y, pixels.Width, pixels.Height);
            BeginInvoke(new DoActionDelegate(DoAction), new object[] { "HighlightText", bounds });
         }

         // Go back to selection mode
         // We must invoke this because the select button will change the
         // interactive mode of the viewer and hence, cancel the current
         // operation
         BeginInvoke(new MethodInvoker(DoSelectMode));
      }

      void ZoomToInteractiveMode_WorkCompleted(object sender, EventArgs e)
      {
         // Go back to selection mode
         // We must invoke this because the select button will change the
         // interactive mode of the viewer and hence, cancel the current
         // operation
         BeginInvoke(new MethodInvoker(DoSelectMode));
      }

      private void _rasterImageViewer_MouseMove(object sender, MouseEventArgs e)
      {
         string str = String.Empty;

         RasterImage image = _rasterImageViewer.Image;
         if (image != null)
         {
            LeadPoint pixels = PhysicalToLogical(new LeadPoint(e.X, e.Y));

            if (pixels.X >= 0 && pixels.X <= image.ImageWidth &&
               pixels.Y >= 0 && pixels.Y <= image.ImageHeight)
            {
               str = string.Format("{0},{1} px", (int)pixels.X, (int)pixels.Y);
            }

            _mousePositionLabel.Text = str;

            if (InteractiveMode == ViewerControlInteractiveMode.HighlightTextMode ||
               InteractiveMode == ViewerControlInteractiveMode.SelectMode)
            {
               // See if we are over a hyper or internal link
               if (_document != null && _pageLinks != null)
               {
                  bool overLink = false;

                  foreach (PageLink link in _pageLinks)
                  {
                     // We pre-calculated the link bounds in image coordinates
                     if (link.ImageBounds.Contains(pixels))
                     {
                        // Yes, change cursor to Hand
                        _rasterImageViewer.Cursor = Cursors.Hand;
                        overLink = true;
                        break;
                     }
                  }

                  if (!overLink)
                  {
                     _rasterImageViewer.Cursor = Cursors.Default;
                  }
               }
            }
         }
      }

      private bool _highlightSelectedImageObject = false;
      public bool HighlightSelectedImageObject
      {
         get { return _highlightSelectedImageObject; }
         set { _highlightSelectedImageObject = value; }
      }

      private PDFObject _selectedPdfImageObject = new PDFObject();
      private void _rasterImageViewer_MouseDown(object sender, MouseEventArgs e)
      {
         _highlightSelectedImageObject = false;
         LeadPoint pixels = PhysicalToLogical(new LeadPoint(e.X, e.Y));

         try
         {
            if (e.Button == MouseButtons.Right)
            {
               PDFObject pdfImageObject = HitTestPDFImageObject(pixels);
               LeadRect pdfImageObjectBounds = ToLeadRect(pdfImageObject.Bounds);
               if (!pdfImageObjectBounds.IsEmpty)
               {
                  _selectedPdfImageObject = pdfImageObject;

                  // Highlight image object
                  _highlightSelectedImageObject = true;

                  // User right clicked on valid PDF image object, so show context menu to allow him/her to save image
                  ContextMenu cm = new ContextMenu();
                  cm.MenuItems.Add(new MenuItem("&Save As...", _pdfObject_SavePDFImageObjectAs));
                  this.ContextMenu = cm;
               }
               else
               {
                  this.ContextMenu = null;
                  _highlightSelectedImageObject = false;
               }
            }
            else
            {
               if (InteractiveMode == ViewerControlInteractiveMode.HighlightTextMode ||
               InteractiveMode == ViewerControlInteractiveMode.SelectMode)
               {
                  // See if we are over a hyper or internal link
                  if (_document != null && _pageLinks != null)
                  {
                     foreach (PageLink link in _pageLinks)
                     {

                        // We pre-calculated the link bounds in image coordinates
                        if (link.ImageBounds.Contains(pixels))
                        {
                           if (link.HyperLinkIndex != -1)
                           {
                              PDFHyperlink hyperlink = _document.Pages[_currentPageNumber - 1].Hyperlinks[link.HyperLinkIndex];
                              DoAction("GotoHyperlink", hyperlink);
                           }
                           else if (link.InternalLinkIndex != -1)
                           {
                              PDFInternalLink internalLink = _document.InternalLinks[link.InternalLinkIndex];
                              DoAction("GotoInternalLink", internalLink);
                           }
                        }
                     }
                  }
               }
            }
         }
         finally
         {
            _rasterImageViewer.Invalidate();
         }
      }

      private void _pdfObject_SavePDFImageObjectAs(object sender, EventArgs e)
      {
         ImageFileSaver saver = new ImageFileSaver();
         try
         {
            RasterImage image = _document.DecodeImage(_selectedPdfImageObject.ImageObjectNumber);
            using(RasterCodecs codecs = new RasterCodecs())
            {
               DemosGlobal.SetDefaultComments(image, codecs);
               saver.Save(this, codecs, image);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowFileSaveError(this, saver.FileName, ex);
         }
      }

      PDFObject HitTestPDFImageObject(LeadPoint pt)
      {
         PDFObject retObject = new PDFObject();

         PDFDocumentPage page = _document.Pages[_currentPageNumber - 1];
         if (page.Objects != null && page.Objects.Count > 0)
         {
            foreach (PDFObject obj in page.Objects)
            {
               if (obj.ObjectType == PDFObjectType.Image)
               {
                  PDFRect tempPDFRect = page.ConvertRect(PDFCoordinateType.Pdf, PDFCoordinateType.Pixel, obj.Bounds);
                  LeadRect objectRect = ToLeadRect(tempPDFRect);
                  if (objectRect.Contains(pt))
                  {
                     // Point in rect then user pressed over image object, so return it.
                     retObject = obj;
                     break;
                  }
               }
            }
         }

         return retObject;
      }

      private LeadPoint PhysicalToLogical(LeadPoint physical)
      {
         PointF pixelsF = new PointF(physical.X, physical.Y);
         LeadMatrix mm = _rasterImageViewer.GetImageTransformWithDpi(true);
         Matrix m = new Matrix((float)mm.M11, (float)mm.M12, (float)mm.M21, (float)mm.M22, (float)mm.OffsetX, (float)mm.OffsetY);
         Transformer trans = new Transformer(m);
         pixelsF = trans.PointToLogical(pixelsF);

         Point pixels = Point.Round(pixelsF);
         return new LeadPoint(pixels.X, pixels.Y);
      }

      struct HighlightObjectsData
      {
         public Brush TextBrush;
         public Brush RetangleBrush;
         public Brush ImageBrush;
         public Brush HyperlinkBrush;
         public Brush InternalLinkBrush;
      }

      private void _rasterImageViewer_PostImagePaint(object sender, PaintEventArgs e)
      {
         if (_selectedText != null && _selectedText[_currentPageNumber] != null)
         {
            HighlightSelectedWords(e.Graphics);
         }

         if (HighlightObjects && _document != null)
         {
            PDFDocumentPage page = _document.Pages[_currentPageNumber - 1];

            HighlightObjectsData data = new HighlightObjectsData();
            data.TextBrush = new SolidBrush(Color.FromArgb(128, Color.Yellow));
            data.RetangleBrush = new SolidBrush(Color.FromArgb(128, Color.Black));
            data.ImageBrush = new SolidBrush(Color.FromArgb(128, Color.Red));
            data.HyperlinkBrush = new SolidBrush(Color.FromArgb(128, Color.Blue));
            data.InternalLinkBrush = new SolidBrush(Color.FromArgb(128, Color.Green));

            DrawHighlightObjects(e.Graphics, data, page);
            DrawLegends(e.Graphics, data);

            data.TextBrush.Dispose();
            data.RetangleBrush.Dispose();
            data.ImageBrush.Dispose();
            data.HyperlinkBrush.Dispose();
            data.InternalLinkBrush.Dispose();
         }
      }

      private void HighlightSelectedWords(Graphics g)
      {
         MyWord[] words = _selectedText[_currentPageNumber];

         // Highlight the selected words
         using (Brush brush = new SolidBrush(Color.FromArgb(128, SystemColors.Highlight)))
         {
            LeadMatrix mm = _rasterImageViewer.GetImageTransformWithDpi(true);
            Matrix m = new Matrix((float)mm.M11, (float)mm.M12, (float)mm.M21, (float)mm.M22, (float)mm.OffsetX, (float)mm.OffsetY);
            Transformer trans = new Transformer(m);

            // Clip to the current image bounds
            RectangleF clipRect = new RectangleF(0, 0, _rasterImageViewer.Image.ImageWidth, _rasterImageViewer.Image.ImageHeight);
            clipRect = trans.RectangleToPhysical(clipRect);
            g.SetClip(clipRect);

            LeadRect lineBounds = LeadRect.Empty;

            foreach (MyWord word in words)
            {
               // Get the word boundaries
               if (lineBounds.IsEmpty)
               {
                  lineBounds = word.Bounds;
               }
               else
               {
                  lineBounds = LeadRect.Union(lineBounds, word.Bounds);
               }

               if (word.IsEndOfLine)
               {
                  // Highlight this line
                  HighlightLine(g, trans, brush, lineBounds);
                  lineBounds = LeadRect.Empty;
               }
            }

            if (!lineBounds.IsEmpty)
            {
               HighlightLine(g, trans, brush, lineBounds);
            }
         }
      }

      private static void HighlightLine(Graphics g, Transformer trans, Brush brush, LeadRect bounds)
      {
         // Convert to physical coordinates
         RectangleF rc = new RectangleF(bounds.X, bounds.Y, bounds.Width, bounds.Height + 4);
         rc = trans.RectangleToPhysical(rc);

         g.FillRectangle(brush, rc);
      }

      private static LeadRect ToLeadRect(PDFRect rect)
      {
         return LeadRect.FromLTRB((int)rect.Left, (int)rect.Top, (int)rect.Right, (int)rect.Bottom);
      }

      private static RectangleF ToRectangleF(PDFRect rect)
      {
         RectangleF rc = RectangleF.FromLTRB((float)rect.Left, (float)rect.Top, (float)rect.Right, (float)rect.Bottom);
         rc.Inflate(2, 2);
         return rc;
      }

      private static void DrawRectangle(Graphics g, Brush brush, RectangleF rc)
      {
         g.FillRectangle(brush, rc);
         g.DrawRectangle(Pens.Black, rc.X, rc.Y, rc.Width, rc.Height);
      }

      private void DrawHighlightObjects(Graphics g, HighlightObjectsData data, PDFDocumentPage page)
      {

         LeadMatrix mm = _rasterImageViewer.GetImageTransformWithDpi(true);
         Matrix m = new Matrix((float)mm.M11, (float)mm.M12, (float)mm.M21, (float)mm.M22, (float)mm.OffsetX, (float)mm.OffsetY);
         Transformer trans = new Transformer(m);

         // Clip to the current image bounds
         RectangleF clipRect = new RectangleF(0, 0, _rasterImageViewer.Image.ImageWidth, _rasterImageViewer.Image.ImageHeight);
         clipRect = trans.RectangleToPhysical(clipRect);
         g.SetClip(clipRect);

         // Draw objects
         if (page.Objects != null)
         {
            foreach (PDFObject obj in page.Objects)
            {
               RectangleF rc = ToRectangleF(page.ConvertRect(PDFCoordinateType.Pdf, PDFCoordinateType.Pixel, obj.Bounds));
               rc = trans.RectangleToPhysical(rc);

               // Highlight it
               Brush brush;

               if (obj.ObjectType == PDFObjectType.Image)
               {
                  brush = data.ImageBrush;
               }
               else if (obj.ObjectType == PDFObjectType.Rectangle)
               {
                  brush = data.RetangleBrush;
               }
               else
               {
                  brush = data.TextBrush;
               }

               DrawRectangle(g, brush, rc);
            }
         }

         // Draw internal and hyper links
         foreach (PageLink link in _pageLinks)
         {
            RectangleF rc = trans.RectangleToPhysical(new RectangleF(link.ImageBounds.X, link.ImageBounds.Y, link.ImageBounds.Width, link.ImageBounds.Height));

            Brush brush;
            if (link.InternalLinkIndex != -1)
            {
               brush = data.InternalLinkBrush;
            }
            else
            {
               brush = data.HyperlinkBrush;
            }

            DrawRectangle(g, brush, rc);
         }

      }

      private void DrawLegends(Graphics g, HighlightObjectsData data)
      {
         GraphicsState state = g.Save();
         g.ResetClip();

         SizeF textSize = g.MeasureString("WWW", Font);
         RectangleF rc = new RectangleF(0, 0, _rasterImageViewer.ClientRectangle.Width, textSize.Height);
         g.FillRectangle(Brushes.White, rc);
         g.DrawString("Legends: ", Font, Brushes.Black, 0, 0);

         float x = g.MeasureString("Legends: ", Font).Width + 1;

         string[] texts =
         {
            "Text",
            "Rectangle",
            "Image",
            "Hyperlink",
            "InternalLink",
         };

         Brush[] brushes =
         {
            data.TextBrush,
            data.RetangleBrush,
            data.ImageBrush,
            data.HyperlinkBrush,
            data.InternalLinkBrush,
         };

         rc.Inflate(-1, -2);
         rc.Width = rc.Height;

         for (int i = 0; i < texts.Length; i++)
         {
            rc.X = x;

            DrawRectangle(g, brushes[i], rc);
            x += rc.Width + 1;

            g.DrawString(texts[i], Font, Brushes.Black, x, 1);
            x += g.MeasureString(texts[i], Font).Width + 8;
         }

         g.Restore(state);
      }

      private void DrawHighlightImageObject(Graphics g, Brush imageBrush, PDFDocumentPage page)
      {
         LeadMatrix mm = _rasterImageViewer.GetImageTransformWithDpi(true);
         Matrix m = new Matrix((float)mm.M11, (float)mm.M12, (float)mm.M21, (float)mm.M22, (float)mm.OffsetX, (float)mm.OffsetY);
         Transformer trans = new Transformer(m);

         // Clip to the current image bounds
         RectangleF clipRect = new RectangleF(0, 0, _rasterImageViewer.Image.ImageWidth, _rasterImageViewer.Image.ImageHeight);
         clipRect = trans.RectangleToPhysical(clipRect);
         g.SetClip(clipRect);

         // Draw image object
         RectangleF rc = ToRectangleF(page.ConvertRect(PDFCoordinateType.Pdf, PDFCoordinateType.Pixel, _selectedPdfImageObject.Bounds));
         if (!rc.IsEmpty)
         {
            rc = trans.RectangleToPhysical(rc);

            // Highlight it
            DrawRectangle(g, imageBrush, rc);
         }
      }
      #endregion Viewer

      #region UI
      private void UpdateUIState()
      {
         // Update the UI controls states

         _fitPageWidthToolStripButton.Checked = _rasterImageViewer.SizeMode == ControlSizeMode.FitWidth;
         _fitPageToolStripButton.Checked = _rasterImageViewer.SizeMode == ControlSizeMode.FitAlways;

         _selectModeToolStripButton.Checked = _interactiveMode == ViewerControlInteractiveMode.SelectMode;
         _highlightTextModeToolStripButton.Checked = _interactiveMode == ViewerControlInteractiveMode.HighlightTextMode;
         _panModeToolStripButton.Checked = _interactiveMode == ViewerControlInteractiveMode.PanMode;
         _zoomToSelectionModeToolStripButton.Checked = _interactiveMode == ViewerControlInteractiveMode.ZoomToSelectionMode;

         if (_document != null)
         {
            if (!_toolStrip.Enabled)
            {
               _toolStrip.Enabled = true;
            }

            int pageNumber = _currentPageNumber;
            int pageCount = _document.Pages.Count;

            _pageToolStripTextBox.Text = pageNumber.ToString();
            _pageToolStripLabel.Text = "/ " + pageCount.ToString();
            _pageToolStripTextBox.Enabled = pageCount > 1;

            _previousPageToolStripButton.Enabled = pageNumber > 1;
            _nextPageToolStripButton.Enabled = pageNumber < pageCount;
         }
         else
         {
            _pageToolStripTextBox.Text = "0";
            _pageToolStripLabel.Text = "/ 0";

            _zoomToolStripComboBox.Text = string.Empty;

            _toolStrip.Enabled = false;
         }
      }

      private void UpdateZoomValueFromControl()
      {
         // We are invoking this instead of changing the properties
         // directly because the Text value of a combo box is not
         // updated till after the lost focus or enter event is exited
         BeginInvoke(new MethodInvoker(delegate()
         {
            if (_document != null)
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

      private void _previousPageToolStripButton_Click(object sender, EventArgs e)
      {
         TryGotoPage(_currentPageNumber - 1);
      }

      private void _nextPageToolStripButton_Click(object sender, EventArgs e)
      {
         TryGotoPage(_currentPageNumber + 1);
      }

      private void _pageToolStripTextBox_LostFocus(object sender, EventArgs e)
      {
         _pageToolStripTextBox.Text = _currentPageNumber.ToString();
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
            {
               TryGotoPage(pageNumber);
            }

            _pageToolStripTextBox.Text = _currentPageNumber.ToString();
         }
      }

      private void TryGotoPage(int pageNumber)
      {
         // Check if the page number is valid
         if (_document != null && pageNumber >= 1 && pageNumber <= _document.Pages.Count)
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

      private void _zoomToolStripComboBox_LostFocus(object sender, EventArgs e)
      {
         UpdateZoomValueFromControl();
      }

      private void _zoomToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         // Parse the new zoom value
         string str = _zoomToolStripComboBox.Text.Trim();

         if (string.IsNullOrEmpty(str))
            return;

         ComponentResourceManager resources = new ComponentResourceManager(typeof(ViewerControl));

         if (str.Equals(resources.GetString("resx_ActualSize")))
            SetViewerZoomPercentage(100);

         else if (str.Equals(resources.GetString("resx_FitPage")))
            FitPage(false);

         else if (str.Equals(resources.GetString("resx_FitWidth")))
            FitPage(true);

         else
         {
            double val = double.Parse(str.Substring(0, str.Length - 1));
            SetViewerZoomPercentage(val);
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
         DoSelectMode();
      }

      private void DoSelectMode()
      {
         InteractiveMode = ViewerControlInteractiveMode.SelectMode;
      }

      private void _highlightTextModeToolStripButton_Click(object sender, EventArgs e)
      {
         InteractiveMode = ViewerControlInteractiveMode.HighlightTextMode;
      }

      private void _panModeToolStripButton_Click(object sender, EventArgs e)
      {
         InteractiveMode = ViewerControlInteractiveMode.PanMode;
      }

      private void _zoomToSelectionModeToolStripButton_Click(object sender, EventArgs e)
      {
         InteractiveMode = ViewerControlInteractiveMode.ZoomToSelectionMode;
      }

      private void _highlightObjectsToolStripButton_Click(object sender, EventArgs e)
      {
         HighlightObjects = !HighlightObjects;
      }
      #endregion UI
   }
}
