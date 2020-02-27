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
   public class AnnIntersectionObjectRenderer : AnnTowLinesObjectRenderer
   {
      public override void Render(AnnContainerMapper mapper, AnnObject annObject)
      {
         if (mapper == null) ExceptionHelper.ArgumentNullException("mapper");
         if (annObject == null) ExceptionHelper.ArgumentNullException("annObject");

         AnnWinFormsRenderingEngine engine = RenderingEngine as AnnWinFormsRenderingEngine;

         if (engine != null && engine.Context != null)
         {
            base.Render(mapper, annObject);

            AnnIntersectionPointObject annIntersectionPointObject = annObject as AnnIntersectionPointObject;
            if (annIntersectionPointObject != null)
            {
               int count = annIntersectionPointObject.Points.Count;
               if (count < 2)
                  return;

               LeadPointD[] leadPoints = mapper.PointsFromContainerCoordinates(annIntersectionPointObject.Points.ToArray(), annIntersectionPointObject.FixedStateOperations);
               PointF[] points = AnnWinFormsRenderingEngine.ToPoints(leadPoints);

               if (annIntersectionPointObject.SupportsStroke && annIntersectionPointObject.Stroke != null)
               {
                  using (Pen pen = AnnWinFormsRenderingEngine.ToPen(mapper.StrokeFromContainerCoordinates(annIntersectionPointObject.Stroke, annIntersectionPointObject.FixedStateOperations), annIntersectionPointObject.Opacity))
                  {
                     if (points.Length > 2)
                     {
                        LeadPointD LeadIntersectionPoint = annIntersectionPointObject.IntersectionPoint;
                        LeadIntersectionPoint = mapper.PointFromContainerCoordinates(LeadIntersectionPoint, annIntersectionPointObject.FixedStateOperations);
                        PointF intersectionPoint = new PointF((float)LeadIntersectionPoint.X, (float)LeadIntersectionPoint.Y);

                        double radius = mapper.LengthFromContainerCoordinates(annIntersectionPointObject.IntersectionPointRadius, annIntersectionPointObject.FixedStateOperations);
                        DrawPoint(annIntersectionPointObject, engine.Context, intersectionPoint, radius);

                        if (points.Length < 5 && annIntersectionPointObject.IntersectionInsideContainer)
                        {
                           pen.Brush = Brushes.Blue;
                           pen.DashStyle = DashStyle.DashDotDot;
                           engine.Context.DrawLine(pen, points[3], intersectionPoint);
                        }
                     }
                  }
               }
            }
         }
      }

      private void DrawPoint(AnnIntersectionPointObject annObject, Graphics context, PointF point, double radius)
      {
         LeadRectD pointBounds = new LeadRectD(point.X - radius, point.Y - radius, radius * 2, radius * 2);
         LeadPointD topLeft = pointBounds.TopLeft;
         LeadPointD topRight = pointBounds.TopRight;
         LeadPointD bottomLeft = pointBounds.BottomLeft;
         LeadPointD bottomRight = pointBounds.BottomRight;

         using (Pen pen = AnnWinFormsRenderingEngine.ToPen(AnnStroke.Create(AnnSolidColorBrush.Create("green"), annObject.Stroke.StrokeThickness), annObject.Opacity))
         {
            context.DrawLine(pen, new PointF((float)topLeft.X, (float)topLeft.Y), new PointF((float)bottomRight.X, (float)bottomRight.Y));
            context.DrawLine(pen, new PointF((float)bottomLeft.X, (float)bottomLeft.Y), new PointF((float)topRight.X, (float)topRight.Y));
            context.DrawLine(pen, new PointF((float)point.X, (float)(point.Y - pointBounds.Width / 2)), new PointF((float)point.X, (float)(point.Y + pointBounds.Width / 2)));
            context.DrawLine(pen, new PointF((float)point.X - (float)pointBounds.Width / 2, (float)(point.Y)), new PointF((float)point.X + (float)pointBounds.Width / 2, (float)(point.Y)));
         }
      }
   }

}
