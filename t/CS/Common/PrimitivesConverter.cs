// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using Leadtools;

namespace Leadtools.Demos
{
   internal class PrimitivesConverter
   {
      public static LeadMatrix Convert(Matrix matrix)
      {
         if (matrix.IsIdentity)
            return LeadMatrix.Identity;

         return new LeadMatrix(matrix.Elements[0], matrix.Elements[1], matrix.Elements[2], matrix.Elements[3], matrix.Elements[4], matrix.Elements[5]);
      }

      public static Matrix Convert(LeadMatrix matrix)
      {
         if (matrix.IsIdentity)
            return new Matrix();

         return new Matrix((float)matrix.M11, (float)matrix.M12, (float)matrix.M21, (float)matrix.M22, (float)matrix.OffsetX, (float)matrix.OffsetY);
      }

      public static LeadPoint Convert(Point pt)
      {
         return new LeadPoint(pt.X, pt.Y);
      }

      public static Point Convert(LeadPoint pt)
      {
         return new Point(pt.X, pt.Y);
      }

      public static LeadPointD Convert(PointF pt)
      {
         return new LeadPointD(pt.X, pt.Y);
      }

      public static PointF Convert(LeadPointD pt)
      {
         return new PointF((float)pt.X, (float)pt.Y);
      }

      public static LeadRect Convert(Rectangle rc)
      {
         return new LeadRect(rc.X, rc.Y, rc.Width, rc.Height);
      }

      public static Rectangle Convert(LeadRect rc)
      {
         return new Rectangle(rc.X, rc.Y, rc.Width, rc.Height);
      }

      public static LeadRectD Convert(RectangleF rc)
      {
         return new LeadRectD(rc.X, rc.Y, rc.Width, rc.Height);
      }

      public static RectangleF Convert(LeadRectD rc)
      {
         return new RectangleF((float)rc.X, (float)rc.Y, (float)rc.Width, (float)rc.Height);
      }

      public static LeadSize Convert(Size size)
      {
         return new LeadSize(size.Width, size.Height);
      }

      public static Size Convert(LeadSize size)
      {
         return new Size(size.Width, size.Height);
      }

      public static LeadSizeD Convert(SizeF size)
      {
         return new LeadSizeD(size.Width, size.Height);
      }

      public static SizeF Convert(LeadSizeD size)
      {
         return new SizeF((float)size.Width, (float)size.Height);
      }
   }
}
