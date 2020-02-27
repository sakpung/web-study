using Leadtools;
using Leadtools.Codecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmrDemo.Operations
{
   class FileLoadOperation : BusyOperation
   {
      string[] files;
      private int maxHeight;


      public const string OriginalImage = "OriginalImage";
      public const string FormName = "FormName";

      public EventHandler<RasterImageLoadedEventArgs> ImageLoaded;
      public EventHandler<ErrorEventArgs> ImageLoadError;

      public FileLoadOperation(string[] files, int maxHeight)
      {
         this.files = files;
         this.maxHeight = maxHeight;
      }

      protected override void Run()
      {
         int ticker = 0;
         int step = (int)(100 / files.Length);

         RasterCodecs codecs = new RasterCodecs();

         for (int i = 0; i < files.Length; i++)
         {
            string file = files[i];
            Progress(ticker += step, $"Loading {file}...");

            try
            {
               RasterImage image = codecs.Load(file);
               image.CustomData.Add(FormName, System.IO.Path.GetFileName(file));

               double scaleFactor = maxHeight / (double)image.ImageHeight;

               int maxWidth = (int)(image.ImageWidth * scaleFactor);

               RasterImage th = image.CreateThumbnail(maxWidth, maxHeight, image.BitsPerPixel, image.ViewPerspective, RasterSizeFlags.None);

               th.CustomData.Add(OriginalImage, image);

               OnImageLoaded(th);
            }
            catch (Exception ex)
            {
               OnImageLoadError(file, ex.Message);
            }
         }

         base.Run();
      }

      private void OnImageLoadError(string file, string message)
      {
         if (ImageLoadError != null)
         {
            ImageLoadError(this, new ErrorEventArgs(file, message));
         }
      }

      private void OnImageLoaded(RasterImage th)
      {
         if (ImageLoaded != null)
         {
            ImageLoaded(this, new RasterImageLoadedEventArgs(th));
         }
      }
   }

   class RasterImageLoadedEventArgs : EventArgs
   {
      private RasterImage th;

       public RasterImage PackedImage { get { return th; } }
      public RasterImageLoadedEventArgs(RasterImage th)
      {
         this.th = th;
      }
   }

   class ErrorEventArgs : EventArgs
   {
      private string filename;
      private string reason;

      public string Filename { get { return filename; } }
      public string Reason { get { return reason; } }

      public ErrorEventArgs(string filename, string reason)
      {
         this.filename = filename;
         this.reason = reason;
      }
   }
}
