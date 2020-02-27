// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

using Leadtools;
using Leadtools.Annotations.Automation;
using Leadtools.Annotations.Core;
using Leadtools.Annotations.Rendering;
using Leadtools.WinForms;

namespace Leadtools.Annotations.WinForms
{
   // RasterImageViewer with Annotations automations support
   // Derives from RasterImageViewer and implements IAnnAutomationControl

   [Designer("Leadtools.WinForms.Design.RasterImageViewerDesigner, Leadtools.WinForms.Design, Version=17.5.4.0, Culture=neutral, PublicKeyToken=9cf889f53ea9b907")]
   [ToolboxBitmap(typeof(Bitmap))]
   [DefaultProperty("ScaleFactor")]
   [DefaultEvent("TransformChanged")]
   public class AutomationRasterImageViewer : RasterImageViewer, IAnnAutomationControl
   {
      // Current container
      private AnnContainer _container;

      public AutomationRasterImageViewer()
      {
      }

      // Turn anti aliasing on and off
      private bool _antiAlias;
      public bool AntiAlias
      {
         get { return _antiAlias; }
         set { _antiAlias = value; }
      }

      // Inform the automation that UseDpi has changed for correct rendering
      protected override void OnUseDpiChanged(EventArgs e)
      {
         base.OnUseDpiChanged(e);

         // Fire the AutomationUseDpiChanged event
         if (IsAutomationAttached && AutomationUseDpiChanged != null)
         {
            AutomationUseDpiChanged(this, EventArgs.Empty);
         }
      }

      // When the RasterImage object in the viewer changes, it might have a new size (for example, if the user
      // resizes the image), we need to inform the automation of this to resize the container accordingly
      protected override void OnImageChanged(EventArgs e)
      {
         base.OnImageChanged(e);

         // Fire the AutomationSizeChanged event
         if (IsAutomationAttached && AutomationSizeChanged != null)
         {
            AutomationSizeChanged(this, EventArgs.Empty);
         }
      }

      // Inform the automation that the current transformation has changed, user scrolled or zoomed
      protected override void OnTransformChanged(EventArgs e)
      {
         base.OnTransformChanged(e);

         // Fire the AutomationTransformChanged event
         if (IsAutomationAttached && AutomationTransformChanged != null)
         {
            AutomationTransformChanged(this, EventArgs.Empty);
         }
      }

      private void RenderContainer(PaintEventArgs e, AnnWinFormsRenderingEngine engine, AnnContainer container)
      {
         // Attach to the current container and graphics.
         Graphics graphics = e.Graphics;
         Rectangle clipRectangle = e.ClipRectangle;

         try
         {
            engine.Attach(container, graphics);

            // Render the annotatirons
            LeadRectD rc = LeadRectD.Create(clipRectangle.X, clipRectangle.Y, clipRectangle.Width, clipRectangle.Height);
            rc = container.Mapper.RectToContainerCoordinates(rc);
            engine.Render(rc, true);
         }
         finally
         {
            engine.Detach();
         }
      }

      // Paint the annotations using the rendering engine (with anti-alias support)
      protected override void OnPostImagePaint(PaintEventArgs e)
      {
         if (IsAutomationAttached)
         {
            AnnWinFormsRenderingEngine engine = _engine as AnnWinFormsRenderingEngine;

            try
            {
               // Set the anti alias mode
               e.Graphics.SmoothingMode = AntiAlias ? SmoothingMode.AntiAlias : SmoothingMode.None;


               // Render all containers
               if (_automationGetContainersCallback != null)
               {
                  // Using multi-containers
                  AnnContainerCollection containers = _automationGetContainersCallback();
                  foreach (AnnContainer container in containers)
                     RenderContainer(e, engine, container);
               }
               else
               {
                  // Using single-containers, just render the active
                  RenderContainer(e, engine, _container);
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
         }

         base.OnPostImagePaint(e);
      }

      // Fire the AutomationPointerDown event
      protected override void OnMouseDown(MouseEventArgs e)
      {
         base.OnMouseDown(e);

         if (!IsAutomationAttached || !AutomationEnabled)
            return;

         if (AutomationPointerDown != null)
         {
            // Convert the point to automation location
            LeadPointD location = LeadPointD.Create(e.Location.X, e.Location.Y);
            if (e.Button == MouseButtons.Left)

               AutomationPointerDown(this, AnnPointerEventArgs.Create(AnnMouseButton.Left, location));

            if (e.Button == MouseButtons.Right)
               AutomationPointerDown(this, AnnPointerEventArgs.Create(AnnMouseButton.Right, location));
         }
      }

      // Fire the AutomationPointerMove event
      protected override void OnMouseMove(MouseEventArgs e)
      {
         base.OnMouseMove(e);

         if (!IsAutomationAttached || !AutomationEnabled)
            return;

         if (AutomationPointerMove != null)
         {
            // Convert the point to automation location
            LeadPointD location = LeadPointD.Create(e.Location.X, e.Location.Y);
            AutomationPointerMove(this, AnnPointerEventArgs.Create(AnnMouseButton.Left, location));
         }
      }

      // Fire the AutomationPointerUp event
      protected override void OnMouseUp(MouseEventArgs e)
      {
         base.OnMouseUp(e);

         if (!IsAutomationAttached || !AutomationEnabled)
            return;

         if (AutomationPointerUp != null)
         {
            // Convert the point to automation location
            if (e.Button == MouseButtons.Left)
            {
               LeadPointD location = LeadPointD.Create(e.Location.X, e.Location.Y);
               AutomationPointerUp(this, AnnPointerEventArgs.Create(AnnMouseButton.Left, location));
            }
         }
      }

      // Fire the AutomationDoubleClickevent
      protected override void OnMouseDoubleClick(MouseEventArgs e)
      {
         base.OnMouseDoubleClick(e);

         if (!IsAutomationAttached || !AutomationEnabled)
            return;

         if (AutomationDoubleClick != null)
         {
            // Convert the point to automation location
            if (e.Button == MouseButtons.Left)
            {
               LeadPointD location = LeadPointD.Create(e.Location.X, e.Location.Y);
               AutomationDoubleClick(this, AnnPointerEventArgs.Create(AnnMouseButton.Left, location));
            }
         }
      }

      #region IAnnAutomationControl Members

      // Return the current screen DPI
      public double AutomationDpiX
      {
         get { return 96; }
      }

      public double AutomationDpiY
      {
         get { return 96; }
      }

      // Get a value indicating whether the automation should take the image DPI (resolution) into consideration when viewing
      public bool AutomationUseDpi
      {
         get { return this.UseDpi; }
      }

      // Get the image DPI (resolution)
      public double AutomationXResolution
      {
         get { return ImageDpiX; }
      }

      public double AutomationYResolution
      {
         get { return ImageDpiY; }
      }

      // Automation is enabled when the interactive mode is set to none, otherwise, the user
      // is performing actions like zoom to rect or panning
      public bool AutomationEnabled
      {
         get { return InteractiveMode == RasterViewerInteractiveMode.None; }
      }

      // Get the automation size in pixels, in this case, the size of the current image
      public LeadSizeD AutomationSize
      {
         get { return LeadSizeD.Create(ImageSize.Width, ImageSize.Height); }
      }

      // Get the current transformation
      // Use the viewer current transform, if the viewer is rotated or flipped by a view perspective, then add this into the calculation
      public LeadMatrix AutomationTransform
      {
         get
         {
            using (Matrix transform = this.Transform.Clone())
            {
               RasterImage image = this.Image;
               if (image != null)
               {
                  using (Matrix m = GetViewPerspectiveTransform(image.ViewPerspective, UseDpi, image.ImageWidth, image.ImageHeight))
                  {
                     if (!m.IsIdentity)
                     {
                        // The viewer is currently rotated or flipped, add it to the calculation
                        transform.Multiply(m);
                     }
                  }
               }

               return LeadMatrix.Create(transform.Elements[0], transform.Elements[1], transform.Elements[2], transform.Elements[3], transform.Elements[4], transform.Elements[5]);
            }
         }
      }

      // Automation events
      public event EventHandler<AnnPointerEventArgs> AutomationPointerDown;
      public event EventHandler<AnnPointerEventArgs> AutomationPointerMove;
      public event EventHandler<AnnPointerEventArgs> AutomationPointerUp;
      public event EventHandler<AnnPointerEventArgs> AutomationDoubleClick;
      public event EventHandler AutomationGotFocus;
      public event EventHandler AutomationLostFocus;

      public event EventHandler AutomationUseDpiChanged;
      public event EventHandler AutomationEnabledChanged;
      public event EventHandler AutomationSizeChanged;
      public event EventHandler AutomationTransformChanged;

      protected override void OnGotFocus(EventArgs e)
      {
         if (IsAutomationAttached && AutomationEnabled)
         {
            if (AutomationGotFocus != null)
               AutomationGotFocus(this, e);
         }

         base.OnGotFocus(e);
      }

      protected override void OnLostFocus(EventArgs e)
      {
         if (IsAutomationAttached && AutomationEnabled)
         {
            if (AutomationLostFocus != null)
               AutomationLostFocus(this, e);
         }

         base.OnLostFocus(e);
      }

      private bool _isAttached = false;

      // This method is called when AnnAutomation is created, attach the container
      public void AutomationAttach(AnnContainer container)
      {
         if (_container != container)
         {
            // Save the container, we need it
            _container = container;
            // Create the rendering engint
            //_engine.AttachContainer(container);
         }
         _isAttached = true;
      }

      // This method is called when the AnnAutomation is detached (removed)
      public void AutomationDetach()
      {
         //_container = null;
         _isAttached = false;
         //_engine = null;
      }

      private AnnAutomationControlGetContainersCallback _automationGetContainersCallback;
      public AnnAutomationControlGetContainersCallback AutomationGetContainersCallback
      {
         get { return _automationGetContainersCallback; }
         set { _automationGetContainersCallback = value; }
      }

      // Get the current container
      public AnnContainer AutomationContainer
      {
         get { return _container; }
      }

      // Get the current offset for the automation, no special code here, just 0,0
      public LeadPointD AutomationOffset
      {
         get { return LeadPointD.Create(0, 0); }
      }

      // Called to invalidate an area on the viewer
      public void AutomationInvalidate(LeadRectD rc)
      {
         if (rc.IsEmpty)
         {
            Invalidate();
         }
         else
         {
            Rectangle rect = new Rectangle((int)(rc.Left + .5), (int)(rc.Top + .5), (int)(rc.Width + .5), (int)(rc.Height + .5));
            Invalidate(rect);
         }
      }

      // Return the current rendering engine
      private AnnRenderingEngine _engine;
      public AnnRenderingEngine RenderingEngine
      {
         get { return _engine; }
         set { _engine = value as AnnWinFormsRenderingEngine; }
      }

      // Return the current image, used by the redaction and encrypt objects
      public RasterImage AutomationImage
      {
         get { return Image; }
      }

      #endregion IAnnAutomationControl Members

      private bool IsAutomationAttached
      {
         get
         {
            return _engine != null;
         }
      }

      // Helper method to get the view perspective transformation if the viewer is rotated or flipped
      private Matrix GetViewPerspectiveTransform(RasterViewPerspective viewPerspective, bool useDpi, int imageWidth, int imageHeight)
      {
         Matrix matrix = new Matrix();

         int scaleX = 1;
         int scaleY = 1;
         int angle = 0;
         int translateX = 0;
         int translateY = 0;

         switch (viewPerspective)
         {
            case RasterViewPerspective.TopLeft: // None
               break;

            case RasterViewPerspective.BottomLeft180: // H
               //case RasterViewPerspective.TopRight:
               scaleX = -1;
               translateX = imageWidth;
               break;

            case RasterViewPerspective.TopLeft180: // HV R180
               //case RasterViewPerspective.BottomRight: // HV R180
               scaleX = -1;
               scaleY = -1;
               translateX = imageWidth;
               translateY = imageHeight;
               break;

            case RasterViewPerspective.BottomLeft: // V
               scaleY = -1;
               translateY = imageHeight;
               break;

            case RasterViewPerspective.BottomLeft90: // V R90 Done
               //case RasterViewPerspective.LeftTop:
               scaleY = -1;
               angle = 90;
               break;

            case RasterViewPerspective.BottomLeft270: // R90
               //case RasterViewPerspective.RightBottom: // R90
               scaleY = -1;
               angle = 270;

               translateX = imageWidth;
               translateY = imageHeight;

               break;

            case RasterViewPerspective.TopLeft90: // R90
               //case RasterViewPerspective.RightTop: // R90
               angle = 90;
               translateX = imageWidth;

               break;
            case RasterViewPerspective.TopLeft270: // R270
               //case RasterViewPerspective.LeftBottom:
               angle = 270;
               translateY = imageHeight;
               break;
         }

         float ratioX = 1;
         float ratioY = 1;

         if (UseDpi)
         {
            ratioX = (float)(96.0 / ImageDpiX);
            ratioY = (float)(96.0 / ImageDpiY);
         }

         if (scaleX != 1 || scaleY != 1 || angle != 0)
         {
            matrix.Translate(translateX * ratioX, translateY * ratioX);
            matrix.Rotate(angle);
            matrix.Scale(scaleX, scaleY);
         }

         return new Matrix();
      }
   }
}
