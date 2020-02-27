// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Drawing;
using System.Drawing.Drawing2D;

using Leadtools;
using Leadtools.Ocr;
using Leadtools.Drawing;
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.Designers;

namespace OcrDemo
{
   public class ZoneAnnotationObjectEditDesigner : AnnRectangleEditDesigner
   {
      public ZoneAnnotationObjectEditDesigner(IAnnAutomationControl automationControl, AnnContainer container, ZoneAnnotationObject zoneAnnotationObject)
         : base(automationControl, container, zoneAnnotationObject)
      {
      }

      protected override void Move(double offsetX, double offsetY)
      {
         (this.TargetObject as ZoneAnnotationObject).ClearTableCells();
         base.Move(offsetX, offsetY);
      }

      protected override void MoveThumb(int controlPointIndex, LeadPointD pt)
      {
         LeadPointD[] locations = GetThumbLocations();

         // This event gets fired event on small fraction differences so we are giving the user some margin to 
         // be able to select the control point without deleting the table cells
         if ((locations[controlPointIndex].X != pt.X && Math.Abs(locations[controlPointIndex].X - pt.X) > 1) ||
             (locations[controlPointIndex].Y != pt.Y && Math.Abs(locations[controlPointIndex].Y - pt.Y) > 1))
         {
            (this.TargetObject as ZoneAnnotationObject).ClearTableCells();
         }
         base.MoveThumb(controlPointIndex, pt);
      }

   }
}
