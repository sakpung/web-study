// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Leadtools;
using Leadtools.Pdf;
using Leadtools.Annotations.Engine;

using Leadtools.Annotations.Designers;
using Leadtools.Annotations.Rendering;
using Leadtools.Annotations.Automation;

namespace PDFDocumentDemo
{
   public class AnnSignatureObject : AnnHiliteObject
   {
      // Set the object id "AnnObject.None" to skip adding it to the "AutomationObjectsListControl".
      public const int SignatureObjectID = -2000;

      public AnnSignatureObject()
         : base()
      {
         this.SetId(SignatureObjectID);

         this.HiliteColor = "blue";
         this.Opacity = 0.75;
      }

      protected override AnnObject Create()
      {
         return new AnnSignatureObject();
      }

      public override bool SupportsSelectionStroke
      {
         get { return true; }
      }

      public override void Translate(double offsetX, double offsetY)
      {
         return;
      }

      public PDFSignature Signature { get; set; }
      public bool DrawBorder { get; set; }
   }

   public class AnnSignatureObjectRenderer : AnnHiliteObjectRenderer
   {
      public AnnSignatureObjectRenderer()
      {
         this.LocationsThumbStyle = null;
         this.RotateCenterThumbStyle = null;
         this.RotateGripperThumbStyle = null;
      }

      public override void Render(AnnContainerMapper mapper, AnnObject annObject)
      {
         if (mapper == null) ExceptionHelper.ArgumentNullException("mapper");
         if (annObject == null) ExceptionHelper.ArgumentNullException("annObject");

         AnnWinFormsRenderingEngine engine = RenderingEngine as AnnWinFormsRenderingEngine;
         if (engine != null && engine.Context != null)
         {
            AnnSignatureObject signatureObject = annObject as AnnSignatureObject;
            if (signatureObject != null)
            {
               if (signatureObject.IsSelected)
               {
                  base.Render(mapper, signatureObject);
               }
               //When the mouse is over the "SignatureObject" this property set to true, check its value to draw a border around it.
               else if (signatureObject.DrawBorder)
               {
                  Pen pen = new Pen(new SolidBrush(Color.Black), 1);
                  pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;

                  LeadRectD leadRect = mapper.RectFromContainerCoordinates(signatureObject.Rect, signatureObject.FixedStateOperations);
                  Rectangle rect = new Rectangle(
                     (int)leadRect.X,
                     (int)leadRect.Y,
                     (int)leadRect.Width,
                     (int)leadRect.Height
                     );

                  engine.Context.DrawRectangle(pen, rect);
               }
            }
         }
      }
   }
}
