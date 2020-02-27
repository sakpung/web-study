// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Drawing.Drawing2D;

using Leadtools;

namespace SvgDemo
{
   internal static class Tools
   {
      public static Matrix ToMatrix(LeadMatrix matrix)
      {
         if (matrix.IsIdentity)
            return new Matrix();
         else
            return new Matrix((float)matrix.M11, (float)matrix.M12, (float)matrix.M21, (float)matrix.M22, (float)matrix.OffsetX, (float)matrix.OffsetY);
      }

      public static int ToInt(double val)
      {
         return (val < 0.0) ? (int)(val - 0.5) : (int)(val + 0.5);
      }


      public static LeadRectD GetBoundingRect(LeadPointD[] points)
      {
         double xmin = points[0].X;
         double ymin = points[0].Y;
         double xmax = xmin;
         double ymax = ymin;

         for (int i = 1; i < points.Length; i++)
         {
            if (points[i].X < xmin) xmin = points[i].X;
            if (points[i].X > xmax) xmax = points[i].X;
            if (points[i].Y < ymin) ymin = points[i].Y;
            if (points[i].Y > ymax) ymax = points[i].Y;
         }

         return LeadRectD.FromLTRB(xmin, ymin, xmax, ymax);
      }

      public static LeadPointD[] GetCornerPoints(LeadRectD rect)
      {
         bool isEmpty = rect.IsEmpty;
         LeadPointD[] corners =
         {
            !isEmpty ? LeadPointD.Create(rect.Left, rect.Top) : LeadPointD.Create(0, 0),
            !isEmpty ? LeadPointD.Create(rect.Right, rect.Top) : LeadPointD.Create(0, 0),
            !isEmpty ? LeadPointD.Create(rect.Right, rect.Bottom) : LeadPointD.Create(0, 0),
            !isEmpty ? LeadPointD.Create(rect.Left, rect.Bottom) : LeadPointD.Create(0, 0),
         };

         return corners;
      }
   }
}
