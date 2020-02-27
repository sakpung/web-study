// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Annotations.Rendering;
using Leadtools.Annotations.Engine;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Leadtools.Annotations.UserMedicalPack
{
   public class AnnParallelLinesObjectRenderer : AnnObjectRenderer
   {
      public override void Render(AnnContainerMapper mapper, AnnObject annObject)
      {
         if (mapper == null) ExceptionHelper.ArgumentNullException("mapper");
         if (annObject == null) ExceptionHelper.ArgumentNullException("annObject");

         AnnWinFormsRenderingEngine engine = RenderingEngine as AnnWinFormsRenderingEngine;

         if (engine != null && engine.Context != null)
         {
            Graphics context = engine.Context;
            int count = annObject.Points.Count / 2;

            if (count > 1)
            {
               LeadPointD[] tmpPoints = mapper.PointsFromContainerCoordinates(annObject.Points.ToArray(), annObject.FixedStateOperations);
               PointF[] points = AnnWinFormsRenderingEngine.ToPoints(tmpPoints);

               if (annObject.SupportsStroke && annObject.Stroke != null)
               {
                  using (Pen pen = AnnWinFormsRenderingEngine.ToPen(mapper.StrokeFromContainerCoordinates(annObject.Stroke, annObject.FixedStateOperations), annObject.Opacity))
                  {
                     for (int i = 0; i < count; i++)
                     {
                        int index = 2 * i;
                        context.DrawLine(pen, points[index], points[index + 1]);
                     }
                  }
               }
            }
         }
      }
   }
}
