// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Drawing;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Svg;
using Leadtools.Controls;

namespace ImageViewerDemo
{
   class MyImageViewerVirtualizer : ImageViewerVirtualizer
   {
      // The file containing the image
      private string _imageFileName;
      // The LEADTOOLS Raster Codecs objects to use when loading the images (or SVG)
      private RasterCodecs _rasterCodecs;
      private bool _useSVG;

      public MyImageViewerVirtualizer(string imageFileName, RasterCodecs rasterCodecs, bool useSVG) :
         base()
      {
         // Save the parameters
         _imageFileName = imageFileName;
         _rasterCodecs = rasterCodecs;
         _useSVG = useSVG;

         // Number of items to keep cached in memory, the default is 16. Changing to 8
         this.MaximumItems = 8;
      }

      protected override object LoadItem(ImageViewerItem item)
      {
         // This method is called when an item comes into view
         // and is not cached in memory

         // For this example, all we need is to load the image
         // from the original file. But we can also load other
         // state and data from a database or using deserilization.

         // In our demo, the item index is the page index
         // However, we can use the item .Tag property or derive our
         // own class to hold the data needed to load the page

         // Index is 0-based, so add 1 to get the page number
         var pageNumber = this.ImageViewer.Items.IndexOf(item) + 1;
            
         // Load the page and return it
         if (_useSVG)
         {
            var svgDocument = _rasterCodecs.LoadSvg(_imageFileName, pageNumber, null) as SvgDocument;

            // Ensure the SVG optimized for fast viewing
            MainForm.OptimizeForView(svgDocument);

            return svgDocument;
         }
         else
         {
            var rasterImage = _rasterCodecs.Load(_imageFileName, 0, CodecsLoadByteOrder.BgrOrGray, pageNumber, pageNumber);
            return rasterImage;
         }
      }

      protected override void SaveItem(ImageViewerItem item, object data)
      {
         // This method is called when an item is about to be deleted
         // from the cache. In this example, we do not have anything to do
         // but you can modify the code if your application needs to serialize
         // data to disk or a database for example
      }
            
      protected override void DeleteItem(ImageViewerItem item, object data)
      {
         // This method is called when the item is no longer used
         // In this example, we simply dispose the RasterImage/SvgDocument we loaded

         // Check if it is a raster image
         var rasterImage = data as RasterImage;
         if (rasterImage != null)
         {
            rasterImage.Dispose();
            return;
         }

         // Check if it is an SVG document
         var svgDocument = data as SvgDocument;
         if (svgDocument != null)
         {
            svgDocument.Dispose();
            return;
         }
      }

      protected override void RenderItemPlaceholder(ImageViewerRenderEventArgs e)
      {
         // This method is called while an item is being loaded and give us a chance
         // to offer a hint to the user

         // Lets render a Loading ... message on the item
         var transform = this.ImageViewer.GetItemImageTransform(e.Item);
            
         var graphics = e.PaintEventArgs.Graphics;
         var pt = LeadPointD.Create(0, 0);
         pt = transform.Transform(pt);
         graphics.DrawString("Loading...", this.ImageViewer.Font, Brushes.Black, (float)pt.X, (float)pt.Y);
      }
   }
}
