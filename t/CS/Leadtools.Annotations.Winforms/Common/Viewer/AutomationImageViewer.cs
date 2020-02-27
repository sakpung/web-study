// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Leadtools.Annotations.Engine;
using Leadtools.Annotations.Rendering;
using Leadtools.Annotations.Automation;
using Leadtools.Controls;

namespace Leadtools.Annotations.WinForms
{
   // This version of IAnnAutomationControl derives from the image viewer
   public class AutomationImageViewer : ImageViewer, IAnnAutomationControl
   {
      public AutomationImageViewer()
      {
      }

      // Automation object
      private AnnAutomation _automationObject;
      public virtual object AutomationObject
      {
         get { return _automationObject; }
         set { _automationObject = value as AnnAutomation; }
      }

      // Pointer events
      public event EventHandler<AnnPointerEventArgs> AutomationPointerDown;
      public event EventHandler<AnnPointerEventArgs> AutomationPointerMove;
      public event EventHandler<AnnPointerEventArgs> AutomationPointerUp;
      public event EventHandler<AnnPointerEventArgs> AutomationDoubleClick;

      public virtual void OnAutomationPointerDown(AnnPointerEventArgs e)
      {
         if (this.AutomationPointerDown != null)
            this.AutomationPointerDown(this, e);
      }

      public virtual void OnAutomationPointerMove(AnnPointerEventArgs e)
      {
         if (this.AutomationPointerMove != null)
            this.AutomationPointerMove(this, e);
      }

      public virtual void OnAutomationPointerUp(AnnPointerEventArgs e)
      {
         if (this.AutomationPointerUp != null)
            this.AutomationPointerUp(this, e);
      }

      public virtual void OnAutomationDoubleClick(AnnPointerEventArgs e)
      {
         if (this.AutomationDoubleClick != null)
            this.AutomationDoubleClick(this, e);
      }

      // Resolution
      public virtual double AutomationDpiX
      {
         get { return 96; }
      }

      public virtual double AutomationDpiY
      {
         get { return 96; }
      }

      // Enabled/Focus
      public virtual bool AutomationEnabled
      {
         get { return this.Enabled; }
      }

      public event EventHandler AutomationEnabledChanged;
      protected override void OnEnabledChanged(EventArgs e)
      {
         if (this.AutomationEnabledChanged != null)
            this.AutomationEnabledChanged(this, EventArgs.Empty);

         base.OnEnabledChanged(e);
      }

      public event EventHandler AutomationGotFocus;
      protected override void OnGotFocus(EventArgs e)
      {
         if (this.AutomationGotFocus != null)
            this.AutomationGotFocus(this, EventArgs.Empty);

         base.OnGotFocus(e);
      }

      public event EventHandler AutomationLostFocus;
      protected override void OnLostFocus(EventArgs e)
      {
         if (this.AutomationLostFocus != null)
            this.AutomationLostFocus(this, EventArgs.Empty);

         base.OnLostFocus(e);
      }

      // Automation items properties

      public event EventHandler AutomationSizeChanged;

      protected override void OnItemChanged(ImageViewerItemChangedEventArgs e)
      {
         switch (e.Reason)
         {
            case ImageViewerItemChangedReason.Url:
            case ImageViewerItemChangedReason.Image:
            case ImageViewerItemChangedReason.ImageChanged:
            case ImageViewerItemChangedReason.Size:
            case ImageViewerItemChangedReason.Transform:
            case ImageViewerItemChangedReason.Visibility:
               // When the item size changes (or the image inside the item, it might have a new size - for example, if the user
               // resizes the image), we need to inform the automation of this to resize the container accordingly
               // Fire the AutomationSizeChanged event
               if (AutomationTransformChanged != null)
                  AutomationTransformChanged(this, EventArgs.Empty);
               if (AutomationSizeChanged != null)
                  AutomationSizeChanged(this, EventArgs.Empty);
               break;

            default:
               break;
         }

         base.OnItemChanged(e);
      }

      // Annotations toolkit will handle the DPI, so always return the transform without one
      public virtual LeadMatrix AutomationTransform
      {
         get { return this.GetImageTransformWithDpi(false); }
      }

      public event EventHandler AutomationTransformChanged;

      // Inform the automation that the current transformation has changed, user scrolled or zoomed
      public override void OnTransformChanged(EventArgs e)
      {
         base.OnTransformChanged(e);

         // Fire the AutomationTransformChanged event
         if (AutomationTransformChanged != null)
            AutomationTransformChanged(this, EventArgs.Empty);
      }

      public virtual bool AutomationUseDpi
      {
         get { return this.UseDpi; }
      }

      public event EventHandler AutomationUseDpiChanged;

      // Override this property to call OnUseDpiChanged when UseDpi change
      public override bool UseDpi
      {
         get
         {
            return base.UseDpi;
         }
         set
         {
            if (base.UseDpi != value)
            {
               base.UseDpi = value;
               if (AutomationUseDpiChanged != null)
                  AutomationUseDpiChanged(this, EventArgs.Empty);
            }
         }
      }

      public virtual double AutomationXResolution
      {
         get
         {
            return this.ImageResolution.Width;
         }
      }

      public virtual double AutomationYResolution
      {
         get
         {
            return this.ImageResolution.Height;
         }
      }

      // Rendering
      public virtual void AutomationInvalidate(LeadRectD rc)
      {
         if (rc.IsEmpty)
         {
            Invalidate();
         }
         else
         {
            var rect = new Rectangle((int)(rc.X + .5), (int)(rc.Y + .5), (int)(rc.Width + .5), (int)(rc.Height + .5));
            Invalidate(rect);
         }
      }

      // Turn anti aliasing on and off
      private bool _antiAlias;
      public virtual bool AutomationAntiAlias
      {
         get
         {
            return _antiAlias;
         }
         set
         {
            _antiAlias = value;
            Invalidate();
         }
      }

      private AnnRenderingEngine _engine;
      public virtual AnnRenderingEngine RenderingEngine
      {
         get
         {
            return _engine;
         }
         set
         {
            _engine = value;
         }
      }

      protected override void OnPostRender(ImageViewerRenderEventArgs e)
      {
         if (e == null) throw new ArgumentNullException("e");

         var engine = _engine as AnnWinFormsRenderingEngine;
         var context = e.PaintEventArgs.Graphics;
         var saveSmoothingMode = context.SmoothingMode;

         bool runMode = false;
         if (_automationObject != null && _automationObject.Manager != null)
            runMode = (_automationObject.Manager.UserMode == AnnUserMode.Run);

         try
         {
            // Set the anti alias mode
            if (this.AutomationAntiAlias)
            {
               if (context.SmoothingMode != SmoothingMode.AntiAlias)
                  context.SmoothingMode = SmoothingMode.AntiAlias;
            }
            else
            {
               if (context.SmoothingMode != SmoothingMode.Default)
                  context.SmoothingMode = SmoothingMode.Default;
            }

            // Render all containers
            if (_getContainersCallback != null)
            {
               // Using multi-containers
               var containers = _getContainersCallback();
               foreach (var container in containers)
                  RenderContainer(e.PaintEventArgs, engine, container, runMode);
            }
            else
            {
               // Using single-containers, just render the active
               RenderContainer(e.PaintEventArgs, engine, _container, runMode);
            }
         }
         finally
         {
            if (context.SmoothingMode != saveSmoothingMode)
               context.SmoothingMode = saveSmoothingMode;
         }
         base.OnPostRender(e);
      }

      private static void RenderContainer(PaintEventArgs e, AnnWinFormsRenderingEngine engine, AnnContainer container, bool runMode)
      {
         // Attach to the current container and graphics.
         var context = e.Graphics;
         var clipRectangle = e.ClipRectangle;

         engine.Attach(container, context);

         try
         {
            // Render the annotatirons
            var rc = LeadRectD.Create(clipRectangle.X, clipRectangle.Y, clipRectangle.Width, clipRectangle.Height);
            rc = container.Mapper.RectToContainerCoordinates(rc);
            engine.Render(rc, runMode);
         }
         finally
         {
            engine.Detach();
         }
      }

      // Containers support
      // Multi container support
      private AnnAutomationControlGetContainersCallback _getContainersCallback;
      public virtual AnnAutomationControlGetContainersCallback AutomationGetContainersCallback
      {
         get { return _getContainersCallback; }
         set { _getContainersCallback = value; }
      }

      private int _containerIndex = -1;
      public virtual int AutomationContainerIndex
      {
         get { return _containerIndex; }
         set { _containerIndex = value; }
      }

      // Single container support
      private AnnContainer _container;
      public virtual void AutomationAttach(AnnContainer container)
      {
         _container = container;
      }

      public virtual void AutomationDetach()
      {
         _container = null;
      }

      public AnnContainer AutomationContainer
      {
         get { return _container; }
      }

      // Data provider for the images
      private AnnDataProvider _dataProvider;
      public virtual AnnDataProvider AutomationDataProvider
      {
         get { return _dataProvider; }
         set { _dataProvider = value; }
      }

      // Scroll Offset values for viewer
      public virtual LeadPoint AutomationScrollOffset
      {
         get { return this.ScrollOffset; }
      }

      public virtual double AutomationRotateAngle
      {
         get { return this.RotateAngle; }
      }

      public virtual double AutomationScaleFactor
      {
         get { return this.ScaleFactor; }
      }

      private bool _isAutomationEventsHooked;
      public virtual bool IsAutomationEventsHooked
      {
         get { return _isAutomationEventsHooked; }
         set { _isAutomationEventsHooked = value; }
      }
   }
}
