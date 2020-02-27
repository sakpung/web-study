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
   public class AnnTowLinesObjectRenderer : AnnObjectRenderer
   {

      private bool _linesAsRulers = false;
      protected virtual bool LinesAsRulers
      {
         get { return _linesAsRulers; }
         set { _linesAsRulers = value; }
      }

      public override void Render(AnnContainerMapper mapper, AnnObject annObject)
      {
         if (mapper == null) ExceptionHelper.ArgumentNullException("mapper");
         if (annObject == null) ExceptionHelper.ArgumentNullException("annObject");

         AnnWinFormsRenderingEngine engine = RenderingEngine as AnnWinFormsRenderingEngine;

         if (engine != null && engine.Context != null)
         {
            LeadPointD[] leadPoints = annObject.Points.ToArray();
            int linesCount = leadPoints.Length / 2;
            if (linesCount > 0)
            {
               if (annObject.SupportsStroke && annObject.Stroke != null)
               {

                  leadPoints = mapper.PointsFromContainerCoordinates(leadPoints, annObject.FixedStateOperations);
                  PointF[] points = AnnWinFormsRenderingEngine.ToPoints(leadPoints);

                  using (Pen pen = AnnWinFormsRenderingEngine.ToPen(mapper.StrokeFromContainerCoordinates(annObject.Stroke, annObject.FixedStateOperations), annObject.Opacity))
                  {
                     for (int i = 0; i < linesCount; ++i)
                     {
                        
                        if(_linesAsRulers)
                        {
                           AnnPolyRulerObject ruler = new AnnPolyRulerObject();
                           ruler.Stroke = annObject.Stroke.Clone();
                           ruler.TickMarksStroke = ruler.Stroke;
                           ruler.Opacity = annObject.Opacity;
                           ruler.FixedStateOperations = annObject.FixedStateOperations;

                           ruler.Points.Clear();
                           ruler.Points.Add(annObject.Points[2 * i]);
                           ruler.Points.Add(annObject.Points[2 * i + 1]);

                           annObject.Labels["angle" + i.ToString()] = ruler.Labels["RulerLength"];

                           AnnPolyRulerObjectRenderer renderer = new AnnPolyRulerObjectRenderer();
                           renderer.Initialize(engine);
                           renderer.Render(mapper, ruler);
                        }
                        else
                        {
                           engine.Context.DrawLine(pen, points[2 * i], points[2 * i + 1]);
                        }
                     }
                  }
               }
            }
         }
      }
   }
}
