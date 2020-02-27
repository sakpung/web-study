// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.Svg;

namespace ImageViewerDemo
{
   public partial class MainForm : Form
   {
      public MainForm()
      {
         InitializeComponent();
      }

      protected override void OnLoad(EventArgs e)
      {
         if (!this.DesignMode)
            InitDemo();

         base.OnLoad(e);
      }

      // Name of last image file loaded successfully
      private string _imageFileName;

      // Options to use when loading the image
      private DemoOptions _demoOptions;

      // LEADTOOLS object used to load image files
      private RasterCodecs _rasterCodecs;

      // LEADTOOLS control to view images
      private ImageViewer _imageViewer;

      // Image viewer layours used in this demo
      private readonly ImageViewerViewLayout[] _viewLayouts =
      {
         // Single images (only one visible at any time)
         new ImageViewerSingleViewLayout(),
         // Vertical with a single column
         new ImageViewerVerticalViewLayout { Columns = 1 },
         // Vertical with two columns (double)
         new ImageViewerVerticalViewLayout { Columns = 2 },
         // Horizontal with single row
         new ImageViewerHorizontalViewLayout { Rows = 1 }
      };

      private void InitDemo()
      {
         Messager.Caption = "C# Image Viewer Demo";
         Text = Messager.Caption;

         _imageInfoLabel.Text = String.Empty;
         _imageInfoLabel.Text = String.Empty;

         // Load the last options used
         _demoOptions = new DemoOptions();

         // Initialize the LEADTOOLS object used to load image files
         _rasterCodecs = new RasterCodecs();
         // Load documents at 300 DPI for better viewing
         _rasterCodecs.Options.RasterizeDocument.Load.Resolution = 300;

         // Initialize the LEADTOOLS control used to view images
         InitImageViewer();

         // Load the default image
#if LT_CLICKONCE
         var defaultFileName = Path.Combine(Application.StartupPath, @"Documents\Leadtools.pdf");
#else
         var defaultFileName = Path.Combine(DemosGlobal.ImagesFolder, @"Leadtools.pdf");
#endif // #if LT_CLICKONCE

         if (!string.IsNullOrEmpty(defaultFileName) && File.Exists(defaultFileName))
            LoadImage(defaultFileName);
      }

      private void InitImageViewer()
      {
         // Create the control
         _imageViewer = new ImageViewer(_viewLayouts[1]);
         _imageViewer.BackColor = SystemColors.AppWorkspace;
         _imageViewer.Dock = DockStyle.Fill;

         // Use the image true resolution
         _imageViewer.UseDpi = true;

         // We want some padding between the overall viewer and the pages, so
         _imageViewer.ViewPadding = new Padding(10);

         // Center the pages horizontally and vertically in the viewer
         _imageViewer.ViewHorizontalAlignment = ControlAlignment.Center;
         _imageViewer.ViewVerticalAlignment = ControlAlignment.Center;

         // Add some spacing between the pages
         _imageViewer.ItemSpacing = new LeadSize(8, 8);

         // Add a border to each page
         _imageViewer.ItemBorderThickness = 2;
         _imageViewer.ItemBorderColor = Color.Black;

         // Since we can load SVG documents that has no background color, set one
         _imageViewer.ImageBackgroundColor = Color.White;

         this.Controls.Add(_imageViewer);
         _imageViewer.BringToFront();

         // Add the pan/zoom interactive mode
         var panZoomMode = new ImageViewerPanZoomInteractiveMode
         {
            DoubleTapSizeMode = ControlSizeMode.ActualSize
         };

         _imageViewer.InteractiveModes.Add(panZoomMode);
      }

      private void _exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void _aboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (var aboutDialog = new AboutDialog("Image Viewer", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _openToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (var dlg = new LoadFileDialog())
         {
            // Clone the options, if Cancel, we do not want them changed
            dlg.ImageFileName = _imageFileName;
            dlg.DemoOptions = _demoOptions.Clone();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               // Copy the options (exluding the current file name)
               _demoOptions = dlg.DemoOptions.Clone();

               // Load the image
               LoadImage(dlg.ImageFileName);
            }
         }
      }

      private void _loadToolStripButton_Click(object sender, EventArgs e)
      {
         _openToolStripMenuItem.PerformClick();
      }

      private void _layoutToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         _singleLayoutToolStripMenuItem.Checked = (_imageViewer.ViewLayout == _viewLayouts[0]);
         _verticalLayoutToolStripMenuItem.Checked = (_imageViewer.ViewLayout == _viewLayouts[1]);
         _doubleLayoutToolStripMenuItem.Checked = (_imageViewer.ViewLayout == _viewLayouts[2]);
         _horizontalLayoutToolStripMenuItem.Checked = (_imageViewer.ViewLayout == _viewLayouts[3]);
      }

      private void _layoutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Select the layout
         if (sender == _singleLayoutToolStripMenuItem)
            _imageViewer.ViewLayout = _viewLayouts[0];
         else if (sender == _verticalLayoutToolStripMenuItem)
            _imageViewer.ViewLayout = _viewLayouts[1];
         else if (sender == _doubleLayoutToolStripMenuItem)
            _imageViewer.ViewLayout = _viewLayouts[2];
         else if (sender == _horizontalLayoutToolStripMenuItem)
            _imageViewer.ViewLayout = _viewLayouts[3];
      }

      private void LoadImage(string imageFileName)
      {
         try
         {
            using (var wait = new WaitCursor())
            {
               // Get the image number of pages
               int pageCount;
               using (var imageInfo = _rasterCodecs.GetInformation(imageFileName, true))
               {
                  pageCount = imageInfo.TotalPages;
               }

               // At this point, we can probably load this image, so save it
               _imageFileName = imageFileName;

               // See if we can load this image as SVG
               // If the user selected that and if the format supports it
               var useSVG = (_demoOptions.UseSVG && _rasterCodecs.CanLoadSvg(imageFileName));

               // See if we need the virtualizer
               // If the user selected that and if we have more than one page
               var useVirtualizer = (_demoOptions.UseVirtiualizer && pageCount > 1);

               // We are ready
               // Ensure that the image viewer will not perform any unnecessary calculations in the middle of adding
               // and removing items
               _imageViewer.BeginUpdate();

               try
               {
                  // Remove the previous pages
                  _imageViewer.Items.Clear();

                  // Set the image info label
                  this.Text = string.Format("{0} - {1}", imageFileName, Messager.Caption);
                  _imageInfoLabel.Text = string.Format("Pages:{0} - Use SVG:{1} - Use Virtualizer:{2}",
                     pageCount, useSVG ? "Yes" : "No", useVirtualizer ? "Yes" : "No");

                  if (useVirtualizer)
                  {
                     LoadPagesWithVirtualizer(imageFileName, pageCount, useSVG);
                  }
                  else
                  {
                     LoadPagesDirect(imageFileName, pageCount, useSVG);
                  }
               }
               finally
               {
                  _imageViewer.EndUpdate();
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void LoadPagesWithVirtualizer(string imageFileName, int pageCount, bool useSVG)
      {
         // Load the pages using a virtualizer

         // Note that the code below will get the width and height for each page indvidually
         // This is important because some file formats such as PDF, DOCX and TIFF supports pages
         // with different sizes.
         // If this behavior is not desired, then the code can be optimized by only obtaining the size
         // of the first page and re-using it for all items

         // First thing, we need to add empty items that are the same size as each page
         for (var pageNumber = 1; pageNumber <= pageCount; pageNumber++)
         {
            // This page size in pixels
            LeadSize pagePixelSize;
            LeadSizeD resolution;

            using (var imageInfo = _rasterCodecs.GetInformation(imageFileName, false, pageNumber))
            {
               pagePixelSize = new LeadSize(imageInfo.Width, imageInfo.Height);
               resolution = new LeadSizeD(imageInfo.XResolution, imageInfo.YResolution);
            }

            // Set up the item with the size and resolution
            var item = new ImageViewerItem
            {
               ImageSize = pagePixelSize,
               Resolution = resolution
            };

            // Add it to the viewer
            _imageViewer.Items.Add(item);
         }

         // All the items are added and ready, create a new virtualizer and use it
         var virtualizer = new MyImageViewerVirtualizer(imageFileName, _rasterCodecs, useSVG);
         _imageViewer.Virtualizer = virtualizer;
      }

      private void LoadPagesDirect(string imageFileName, int pageCount, bool useSVG)
      {
         // Loads all the pages into the viewer
         for (var pageNumber = 1; pageNumber <= pageCount; pageNumber++)
         {
            if (useSVG)
            {
               // Load it as an SVG and add it
               var svgDocument = _rasterCodecs.LoadSvg(imageFileName, pageNumber, null) as SvgDocument;

               // Ensure the SVG optimized for fast viewing
               OptimizeForView(svgDocument);
               this._imageViewer.Items.AddFromSvgDocument(svgDocument);
            }
            else
            {
               // Load it as a raster image and add it
               var rasterImage = _rasterCodecs.Load(imageFileName, pageNumber);
               this._imageViewer.Items.AddFromImage(rasterImage, 1);
            }
         }
      }

      internal static void OptimizeForView(SvgDocument svgDocument)
      {
         // Ensure the SVG optimized for fast viewing
         if (!svgDocument.IsFlat)
            svgDocument.Flat(null);

         if (!svgDocument.Bounds.IsValid || svgDocument.Bounds.IsTrimmed)
            svgDocument.CalculateBounds(false);

         if (!svgDocument.IsRenderOptimized)
            svgDocument.BeginRenderOptimize();
      }
   }
}
