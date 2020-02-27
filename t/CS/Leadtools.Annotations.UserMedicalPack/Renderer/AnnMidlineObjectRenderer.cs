// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

using Leadtools.Annotations.Rendering;
using Leadtools.Annotations.Engine;

namespace Leadtools.Annotations.UserMedicalPack
{
   public class AnnMidlineObjectRenderer : AnnTowLinesObjectRenderer
   {
      public override void Render(AnnContainerMapper mapper, AnnObject annObject)
      {
         if (mapper == null) ExceptionHelper.ArgumentNullException("mapper");
         if (annObject == null) ExceptionHelper.ArgumentNullException("annObject");

         AnnWinFormsRenderingEngine engine = RenderingEngine as AnnWinFormsRenderingEngine;

         if (engine != null && engine.Context != null)
         {
            base.Render(mapper, annObject);

            AnnMidlineObject annMidlineObject = annObject as AnnMidlineObject;
            if (annMidlineObject != null)
            {
               LeadPointD[] leadPoints = annMidlineObject.Points.ToArray();
               int linesCount = leadPoints.Length / 2;
               if (linesCount > 0)
               {
                  PointF[] linesCenters = new PointF[linesCount];
                  leadPoints = mapper.PointsFromContainerCoordinates(leadPoints, annMidlineObject.FixedStateOperations);
                  PointF[] points = AnnWinFormsRenderingEngine.ToPoints(leadPoints);

                  if (annMidlineObject.SupportsStroke && annMidlineObject.Stroke != null)
                  {
                     double radius = mapper.LengthFromContainerCoordinates(annMidlineObject.CenterPointRadius, annMidlineObject.FixedStateOperations);
                     using (Pen pen = AnnWinFormsRenderingEngine.ToPen(mapper.StrokeFromContainerCoordinates(annMidlineObject.Stroke, annMidlineObject.FixedStateOperations), annMidlineObject.Opacity))
                     {
                        for (int i = 0; i < linesCount; ++i)
                        {
                           PointF firstPoint = points[2 * i];
                           PointF secondPoint = points[2 * i + 1];

                           PointF center = new PointF((firstPoint.X + secondPoint.X) / 2, (firstPoint.Y + secondPoint.Y) / 2);
                           DrawPoint(annMidlineObject, engine.Context, center, radius);

                           linesCenters[i] = center;
                        }

                        if (linesCount > 1)
                        {
                           int count = linesCount - 1;
                           for (int i = 0; i < count; ++i)
                              engine.Context.DrawLine(pen, linesCenters[i], linesCenters[i + 1]); // draw midline
                        }
                     }
                  }
               }
            }
         }
      }

      private void DrawPoint(AnnMidlineObject annObject, Graphics context, PointF point, double radius)
      {
         LeadRectD pointBounds = new LeadRectD(point.X - radius, point.Y - radius, radius * 2, radius * 2);
         LeadPointD topLeft = pointBounds.TopLeft;
         LeadPointD topRight = pointBounds.TopRight;
         LeadPointD bottomLeft = pointBounds.BottomLeft;
         LeadPointD bottomRight = pointBounds.BottomRight;

         using (Pen pen = AnnWinFormsRenderingEngine.ToPen(AnnStroke.Create(AnnSolidColorBrush.Create("blue"), annObject.Stroke.StrokeThickness), annObject.Opacity))
         {
            context.DrawLine(pen, new PointF((float)topLeft.X, (float)topLeft.Y), new PointF((float)bottomRight.X, (float)bottomRight.Y));
            context.DrawLine(pen, new PointF((float)bottomLeft.X, (float)bottomLeft.Y), new PointF((float)topRight.X, (float)topRight.Y));
            context.DrawLine(pen, new PointF((float)point.X, (float)(point.Y - pointBounds.Width / 2)), new PointF((float)point.X, (float)(point.Y + pointBounds.Width / 2)));
            context.DrawLine(pen, new PointF((float)point.X - (float)pointBounds.Width / 2, (float)(point.Y)), new PointF((float)point.X + (float)pointBounds.Width / 2, (float)(point.Y)));
         }
      }
   }
}
