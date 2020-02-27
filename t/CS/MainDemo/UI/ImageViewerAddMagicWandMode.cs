// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;

using Leadtools.Controls.Internal;
using Leadtools.Drawing;
using System.Drawing;

namespace Leadtools.Controls
{
   public class ImageViewerAddMagicWandInteractivMode : ImageViewerInteractiveMode
   {
      private int _threshold = 25;

      public ImageViewerAddMagicWandInteractivMode() { }

      public override string Name
      {
         get { return "AddMagicWand"; }
      }

      public int Threshold
      {
         get { return _threshold; }
         set { _threshold = value; }
      }

      public override int Id
      {
         get { return ImageViewerInteractiveMode.UserModeId; }
      }
      public override void Start(ImageViewer imageViewer)
      {
         base.Start(imageViewer);
         InteractiveService service = base.InteractiveService;
         service.Tap += new EventHandler<InteractiveEventArgs>(service_Tap);
      }

      public override void Stop(ImageViewer imageViewer)
      {
         if (IsStarted)
         {
            InteractiveService service = base.InteractiveService;
            service.Tap -= new EventHandler<InteractiveEventArgs>(service_Tap);
            base.Stop(imageViewer);
         }
      }

      private void service_Tap(object sender, InteractiveEventArgs e)
      {
         if (CanStartWork(e))
         {
            e.IsHandled = true;
            OnWorkStarted(EventArgs.Empty);

            ImageViewer imageViewer = this.ImageViewer;

            imageViewer.BeginRender();
            AddMagicWand(e.Origin);
            imageViewer.EndRender();

            OnWorkCompleted(EventArgs.Empty);
         }
      }

      private void AddMagicWand(LeadPoint MagicWandPoint)
      {
         ImageViewer imageViewer = this.ImageViewer;

         LeadMatrix MyMatrix = imageViewer.ImageTransform;
         Transformer t = new Transformer(new System.Drawing.Drawing2D.Matrix((float)MyMatrix.M11, (float)MyMatrix.M12, (float)MyMatrix.M21, (float)MyMatrix.M22, (float)MyMatrix.OffsetX, (float)MyMatrix.OffsetY));

         LeadPoint pt = MagicWandPoint;

         pt = imageViewer.Image.PointToImage(RasterViewPerspective.TopLeft, pt);

         PointF ptF = t.PointToLogical(new PointF(pt.X, pt.Y));

         RasterColor lowerColor = new RasterColor(Threshold, Threshold, Threshold);
         RasterColor upperColor = new RasterColor(Threshold, Threshold, Threshold);

         if (((int)ptF.X > imageViewer.Image.Width) || ((int)ptF.Y > imageViewer.Image.Height))
            return;
         else
         {
            if (((int)ptF.X > 0) && ((int)ptF.Y > 0))
            {
               imageViewer.Image.AddMagicWandToRegion((int)ptF.X, (int)ptF.Y, lowerColor, upperColor, RasterRegionCombineMode.Set);
               imageViewer.ActiveItem.ImageRegionToFloater();
               imageViewer.Image.SetRegion(null, null, RasterRegionCombineMode.Set);
            }
         }
      }
   }
}
