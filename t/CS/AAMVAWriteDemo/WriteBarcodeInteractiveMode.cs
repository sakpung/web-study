using Leadtools;
using Leadtools.Barcode;
using Leadtools.Controls;
using System;
using System.Windows.Forms;

namespace AAMVAWriteDemo
{
   public class WriteBarcodeInteractiveMode : ImageViewerInteractiveMode
   {

      private PDF417BarcodeWriteOptions _writeOptions;
      private BarcodeEngine _engine;
      private bool _bigEnoughForBarcode;
      private byte[] _data;
      public WriteBarcodeInteractiveMode(BarcodeEngine engine, byte[] data, PDF417BarcodeWriteOptions writeOptions) : base()
      {
         _data = data;
         _engine = engine;
         _writeOptions = writeOptions;
         _bigEnoughForBarcode = false;
      }

      public override string Name
      {
         get { return "WriteBarcode"; }
      }

      public override int Id
      {
         get
         {
            return ImageViewerInteractiveMode.UserModeId - 1;
         }
      }

      public PDF417BarcodeWriteOptions WriteOptions
      {
         get
         {
            return _writeOptions;
         }

         set
         {
            _writeOptions = value;

            if (this.ImageViewer.Items.Count < 1)
               return;
            var item = this.ImageViewer.Items[0];
            if (item == null)
               return;

            if (item.Floater != null)
            {
               item.Floater.Dispose();
               item.Floater = null;
            }
            this.ImageViewer.Invalidate();
            TryAddFloater(item);
         }
      }


      public BarcodeEngine Engine
      {
         get
         {
            return _engine;
         }

         set
         {
            _engine = value;
         }
      }

      public override void Start(ImageViewer imageViewer)
      {
         base.Start(imageViewer);
         var service = base.InteractiveService;

         
         service.Move += new EventHandler<InteractiveEventArgs>(service_Move);
         service.DoubleTap += new EventHandler<InteractiveEventArgs>(service_DoubleTap);
      }

      public override void Stop(ImageViewer imageViewer)
      {
         if (IsStarted)
         {
            var service = base.InteractiveService;
            service.Move -= new EventHandler<InteractiveEventArgs>(service_Move);
            service.DoubleTap -= new EventHandler<InteractiveEventArgs>(service_DoubleTap);
            base.Stop(imageViewer);
         }
      }

      private void service_DoubleTap(object sender, InteractiveEventArgs e)
      {
         var item = this.ImageViewer.Items[0];
         if (item == null)
            return;

         e.IsHandled = true;

         this.OnWorkStarted(EventArgs.Empty);
         if(_bigEnoughForBarcode)
         {
            item.CombineFloater(item, false);
         }
         else
         {
            //Open a message box;
            MessageBox.Show("With the given PDF417 Write Options, the barcode is too large for the " +
               "image currently in the viewer. Change write options and/or open a larger image.",
               "Barcode Too Large");
         }


         this.OnWorkCompleted(EventArgs.Empty);
      }

      private void TryAddFloater(ImageViewerItem item)
      {
         PDF417BarcodeData barcodeData = (PDF417BarcodeData)BarcodeData.CreateDefaultBarcodeData(BarcodeSymbology.PDF417);
         barcodeData.SetData(_data);
         _engine.Writer.CalculateBarcodeDataBounds(LeadRect.Empty,
                                                   item.Image.XResolution,
                                                   item.Image.YResolution,
                                                   barcodeData,
                                                   _writeOptions);
         if (barcodeData.Rect.Width <= item.Image.Width && barcodeData.Rect.Height <= item.Image.Height)
         {
            _bigEnoughForBarcode = true;
            this.ImageViewer.Cursor = System.Windows.Forms.Cursors.Default;
            RasterImage floaterImage = RasterImage.Create(barcodeData.Rect.Width,
                                       barcodeData.Rect.Height,
                                       32,
                                       Math.Max(item.Image.XResolution, item.Image.YResolution),
                                       RasterColor.Create(0, 255, 255, 255));

            _engine.Writer.WriteBarcode(floaterImage, barcodeData, _writeOptions);
            item.Floater = floaterImage;
            item.FloaterOpacity = 0.5;
         }
         else
         {
            this.ImageViewer.Cursor = System.Windows.Forms.Cursors.No;
            _bigEnoughForBarcode = false;
         }
      }

      private void service_Move(object sender, InteractiveEventArgs e)
      {
         if (this.ImageViewer.Items.Count < 1)
            return;
         var item = this.ImageViewer.Items[0];
         if (item == null)
            return;

         e.IsHandled = true;

         this.OnWorkStarted(EventArgs.Empty);
         if(!item.HasFloater)
         {
            TryAddFloater(item);
         }
         else
         {
            LeadMatrix matrix = new LeadMatrix();

            LeadPoint positionImage = ImageViewer.ConvertPoint(ImageViewer.Items[0],
               ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, LeadPoint.Create(e.Position.X, e.Position.Y));

            matrix.OffsetX = positionImage.X - item.Floater.Width / 2;
            matrix.OffsetY = positionImage.Y - item.Floater.Height / 2;
            item.FloaterTransform = matrix;
         }
         this.OnWorkCompleted(EventArgs.Empty);
      }
   }
}
