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
   public class AnnCobbAngleObjectRenderer : AnnTowLinesObjectRenderer
   {
      public override void Render(AnnContainerMapper mapper, AnnObject annObject)
      {
         if (mapper == null) ExceptionHelper.ArgumentNullException("mapper");
         if (annObject == null) ExceptionHelper.ArgumentNullException("annObject");

         AnnWinFormsRenderingEngine engine = RenderingEngine as AnnWinFormsRenderingEngine;

         if (engine != null && engine.Context != null)
         {
            base.Render(mapper, annObject);

            AnnCobbAngleObject annCobbAngleObject = annObject as AnnCobbAngleObject;
            if (annCobbAngleObject != null)
            {
               base.LinesAsRulers = annCobbAngleObject.LinesAsRulers;

               int count = annCobbAngleObject.Points.Count;
               if (count < 2)
                  return;

               LeadPointD[] leadPoints = mapper.PointsFromContainerCoordinates(annCobbAngleObject.Points.ToArray(), annCobbAngleObject.FixedStateOperations);
               PointF[] points = AnnWinFormsRenderingEngine.ToPoints(leadPoints);

               if (annCobbAngleObject.SupportsStroke && annCobbAngleObject.Stroke != null)
               {
                  using (Pen pen = AnnWinFormsRenderingEngine.ToPen(mapper.StrokeFromContainerCoordinates(annCobbAngleObject.Stroke, annCobbAngleObject.FixedStateOperations), annCobbAngleObject.Opacity))
                  {
                     if (points.Length > 3)
                     {
                        AnnCobbAngleData cobbAngleData = annCobbAngleObject.CobbAngleData;
                        LeadPointD firstPoint = mapper.PointFromContainerCoordinates(cobbAngleData.FirstPoint, annCobbAngleObject.FixedStateOperations);
                        LeadPointD secondPoint = mapper.PointFromContainerCoordinates(cobbAngleData.SecondPoint, annCobbAngleObject.FixedStateOperations);
                        LeadPointD intersectionPoint = mapper.PointFromContainerCoordinates(cobbAngleData.IntersectionPoint, annCobbAngleObject.FixedStateOperations);

                        pen.Brush = Brushes.Blue;
                        pen.DashPattern = new float[] { 4, 2, 2, 2, 2, 2 };
                        engine.Context.DrawLine(pen, new PointF((float)firstPoint.X, (float)firstPoint.Y), new PointF((float)intersectionPoint.X, (float)intersectionPoint.Y));
                        engine.Context.DrawLine(pen, new PointF((float)secondPoint.X, (float)secondPoint.Y), new PointF((float)intersectionPoint.X, (float)intersectionPoint.Y));

                        //Draw angle label
                        if (annCobbAngleObject.Labels.ContainsKey("CobbAngle"))
                        {
                           AnnLabel label = annCobbAngleObject.Labels["CobbAngle"];
                           if (label != null)
                           {
                              string precisionFormat = string.Format("XXX:F{0}", annCobbAngleObject.AnglePrecision);
                              precisionFormat = precisionFormat.Replace("XXX", "{0");
                              precisionFormat = string.Format("{0}{1}", precisionFormat, "}");

                              string angle = string.Format(precisionFormat, cobbAngleData.Angle);
                              angle = string.Format("{0} {1}", angle, "\u00B0");

                              label.Text = angle;
                              label.Foreground = AnnSolidColorBrush.Create("White");
                              label.Background = AnnSolidColorBrush.Create("Blue");
                              label.OriginalPosition = cobbAngleData.IntersectionPoint;
                           }
                        }
                     }
                  }
               }
            }
         }
      }
   }
}
