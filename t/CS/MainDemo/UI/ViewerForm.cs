// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Controls;
using Leadtools.Demos;
using Leadtools.Drawing;

namespace MainDemo
{
   public partial class ViewerForm : Form
   {
      private ImageViewer _viewer;
      private string _name;
      public string FileName { get { return _name; } }
      private LeadPoint pt = LeadPoint.Empty;
      //Interactive Modes
      ImageViewerNoneInteractiveMode _noneInteractiveMode;
      ImageViewerFloaterInteractiveMode _floaterInteractiveMode;
      ImageViewerPanZoomInteractiveMode _panInteractiveMode;
      ImageViewerCenterAtInteractiveMode _centerAtInteractiveMode;
      ImageViewerZoomToInteractiveMode _zoomToInteractiveMode;
      ImageViewerPanZoomInteractiveMode _scaleInteractiveMode;
      ImageViewerPagerInteractiveMode _pagerInteractiveMode;
      ImageViewerMagnifyGlassInteractiveMode _magnifyGlassInteractiveMode;
      ImageViewerAddRegionInteractiveMode _regionInteractiveMode;
      ImageViewerRubberBandInteractiveMode _rectangleInteractiveMode;
      ImageViewerAddMagicWandInteractivMode _addMagicWandInteractivMode;

      //Interactive mode public methods
      public ImageViewerNoneInteractiveMode NoneInteractiveMode
      {
         get
         { return _noneInteractiveMode; }
         set
         { _noneInteractiveMode = value; }
      }

      public ImageViewerFloaterInteractiveMode FloaterInteractiveMode
      {
         get
         { return _floaterInteractiveMode; }
         set
         { _floaterInteractiveMode = value; }
      }

      public ImageViewerPanZoomInteractiveMode PanInteractiveMode
      {
         get
         { return _panInteractiveMode; }
         set
         { _panInteractiveMode = value; }
      }

      public ImageViewerCenterAtInteractiveMode CenterAtInteractiveMode
      {
         get
         { return _centerAtInteractiveMode; }
         set
         { _centerAtInteractiveMode = value; }
      }

      public ImageViewerAddMagicWandInteractivMode AddMagicWandInteractivMode
      {
         get
         { return _addMagicWandInteractivMode; }
         set
         { _addMagicWandInteractivMode = value; }
      }
      


      public ImageViewerZoomToInteractiveMode ZoomToInteractiveMode
      {
         get
         { return _zoomToInteractiveMode; }
         set
         { _zoomToInteractiveMode = value; }
      }

      public ImageViewerPanZoomInteractiveMode ScaleInteractiveMode
      {
         get
         { return _scaleInteractiveMode; }
         set
         { _scaleInteractiveMode = value; }
      }

      public ImageViewerPagerInteractiveMode PagerInteractiveMode
      {
         get
         { return _pagerInteractiveMode; }
         set
         { _pagerInteractiveMode = value; }
      }

      public ImageViewerMagnifyGlassInteractiveMode MagnifyGlassInteractiveMode
      {
         get
         { return _magnifyGlassInteractiveMode; }
         set
         { _magnifyGlassInteractiveMode = value; }
      }

      public ImageViewerAddRegionInteractiveMode RegionInteractiveMode
      {
         get { return _regionInteractiveMode; }
         set { _regionInteractiveMode = value; }
      }

      public ImageViewerRubberBandInteractiveMode RectangleInteractiveMode
      {
         get { return _rectangleInteractiveMode; }
         set { _rectangleInteractiveMode = value; }
      }

      public ViewerForm()
      {
         InitializeComponent();

         this.WindowState = FormWindowState.Maximized;

         InitClass();

      }

      private void InitClass()
      {
         _viewer = new ImageViewer();
         _viewer.Dock = DockStyle.Fill;
         _viewer.BorderStyle = BorderStyle.None;
         _viewer.TransformChanged += new EventHandler(_viewer_TransformChanged);
         _viewer.DragEnter += new DragEventHandler(_viewer_DragEnter);
         _viewer.DragDrop += new DragEventHandler(_viewer_DragDrop);
         _viewer.InteractiveModes.CollectionChanged += new EventHandler<NotifyLeadCollectionChangedEventArgs>(InteractiveModes_CollectionChanged);
         _viewer.KeyDown += new KeyEventHandler(_viewer_KeyDown);
         _viewer.PropertyChanged += new PropertyChangedEventHandler(_viewer_PropertyChanged);
         _viewer.ViewHorizontalAlignment = ControlAlignment.Near;
         _viewer.ViewVerticalAlignment = ControlAlignment.Near;
         Controls.Add(_viewer);
         _viewer.BringToFront();
         _viewer.AllowDrop = true;
         _viewer.ScrollMode = ControlScrollMode.Auto;
         _viewer.MouseUp += new MouseEventHandler(_viewer_MouseUp);

         //Initialize Interactive modes
         InitializeInteractivemodes();
      }

      void _viewer_PropertyChanged(object sender, PropertyChangedEventArgs e)
      {
         switch (e.PropertyName)
         {
            case "FloaterOpacity":
               ((MainForm)MdiParent).SetFloaterPaintValues();
               break;
            case "Floater":
               break;
         }
      }

      void _viewer_TransformChanged(object sender, EventArgs e)
      {
         ((MainForm)MdiParent).UpdateControls();
      }

      void InteractiveModes_CollectionChanged(object sender, NotifyLeadCollectionChangedEventArgs e)
      {

      }

      private void InitializeInteractivemodes()
      {
         _viewer.InteractiveModes.BeginUpdate(); 
         //None
         NoneInteractiveMode = new ImageViewerNoneInteractiveMode();
         NoneInteractiveMode.IsEnabled = true;
         _viewer.InteractiveModes.Add(NoneInteractiveMode);
         //Floater
         FloaterInteractiveMode = new ImageViewerFloaterInteractiveMode();
         FloaterInteractiveMode.EnablePan = true;
         FloaterInteractiveMode.EnableZoom = false;
         FloaterInteractiveMode.EnablePinchZoom = false;
         FloaterInteractiveMode.WorkOnBounds = true;
         FloaterInteractiveMode.FloaterRegionRenderMode = ControlRegionRenderMode.Animated;
         _viewer.InteractiveModes.Add(FloaterInteractiveMode);
         //Pan
         PanInteractiveMode = new ImageViewerPanZoomInteractiveMode();
         PanInteractiveMode.EnablePan = true;
         PanInteractiveMode.EnableZoom = false;
         PanInteractiveMode.EnablePinchZoom = false;
         PanInteractiveMode.WorkOnBounds = true;
         _viewer.InteractiveModes.Add(PanInteractiveMode);
         //CenterAt         
         CenterAtInteractiveMode = new ImageViewerCenterAtInteractiveMode();
         CenterAtInteractiveMode.WorkOnBounds = true;
         _viewer.InteractiveModes.Add(CenterAtInteractiveMode);
         //Add Magic Wand
         AddMagicWandInteractivMode = new ImageViewerAddMagicWandInteractivMode();
         AddMagicWandInteractivMode.Threshold = 100;
         AddMagicWandInteractivMode.IsEnabled = false;
         AddMagicWandInteractivMode.WorkOnBounds = true;
         AddMagicWandInteractivMode.WorkCompleted += new EventHandler(AddMagicWandInteractivMode_WorkCompleted);
         _viewer.InteractiveModes.Add(AddMagicWandInteractivMode);
         //ZoomTo
         ZoomToInteractiveMode = new ImageViewerZoomToInteractiveMode();
         ZoomToInteractiveMode.WorkOnBounds = true;
         ZoomToInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle;
         _viewer.InteractiveModes.Add(ZoomToInteractiveMode);
         //Scale
         ScaleInteractiveMode = new ImageViewerPanZoomInteractiveMode();
         ScaleInteractiveMode.ZoomKeyModifier = Keys.None;
         ScaleInteractiveMode.EnablePan = false;
         ScaleInteractiveMode.EnableZoom = true;
         ScaleInteractiveMode.EnablePinchZoom = false;
         ScaleInteractiveMode.WorkOnBounds = true;
         _viewer.InteractiveModes.Add(ScaleInteractiveMode);
         //Pager
         PagerInteractiveMode = new ImageViewerPagerInteractiveMode();
         PagerInteractiveMode.WorkOnBounds = true;
         _viewer.InteractiveModes.Add(PagerInteractiveMode);
         //MagnifyGlass
         MagnifyGlassInteractiveMode = new ImageViewerMagnifyGlassInteractiveMode();
         MagnifyGlassInteractiveMode.BorderPen = new Pen(Brushes.Red);
         MagnifyGlassInteractiveMode.Crosshair = ImageViewerSpyGlassCrosshair.Fine;
         MagnifyGlassInteractiveMode.CrosshairPen = new Pen(Brushes.Red);
         MagnifyGlassInteractiveMode.WorkOnBounds = true;
         _viewer.InteractiveModes.Add(MagnifyGlassInteractiveMode);
         //Region
         RegionInteractiveMode = new ImageViewerAddRegionInteractiveMode();
         RegionInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle;
         RegionInteractiveMode.AutoRegionToFloater = true;
         RegionInteractiveMode.WorkOnBounds = true;
         RegionInteractiveMode.WorkCompleted += new EventHandler(RegionInteractiveMode_WorkCompleted);
         RegionInteractiveMode.IsEnabled = false;
         _viewer.InteractiveModes.Add(RegionInteractiveMode);
         //Rectangle
         RectangleInteractiveMode = new ImageViewerRubberBandInteractiveMode();
         RectangleInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle;
         RectangleInteractiveMode.WorkOnBounds = true;
         _viewer.InteractiveModes.Add(RectangleInteractiveMode);

         _viewer.InteractiveModes.EndUpdate(); 
      }

      void AddMagicWandInteractivMode_WorkCompleted(object sender, EventArgs e)
      {
         if (_viewer.Image.GetRegionBounds(null).Width > 0)
         {
            _viewer.Image.MakeRegionEmpty();
            _viewer.InteractiveModes.BeginUpdate();
            FloaterInteractiveMode.DoubleTapSizeMode = _viewer.SizeMode;
            FloaterInteractiveMode.IsEnabled = true;
            _viewer.InteractiveModes.EndUpdate();
         }
      }

      void RegionInteractiveMode_WorkCompleted(object sender, EventArgs e)
      {
         if (_viewer.Image.GetRegionBounds(null).Width > 0)
         {
            _viewer.ActiveItem.ImageRegionToFloater();
               _viewer.WorkingInteractiveMode.IsEnabled = false;
               _viewer.Image.MakeRegionEmpty();

               FloaterInteractiveMode.AutoItemMode = ImageViewerAutoItemMode.AutoSetActive;
               FloaterInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left;
               FloaterInteractiveMode.FloaterOpacity = 0.5;
               FloaterInteractiveMode.FloaterRegionRenderMode = ControlRegionRenderMode.Animated;
               FloaterInteractiveMode.Item = _viewer.ActiveItem;
               _viewer.InteractiveModes.BeginUpdate();
               FloaterInteractiveMode.IsEnabled = true;
               _viewer.InteractiveModes.EndUpdate();
}

         ((MainForm)MdiParent).UpdateControls();
      }      

     

      void _viewer_MouseUp(object sender, MouseEventArgs e)
      {
         base.OnMouseUp(e);
      }

      public void Initialize(ImageInformation info, RasterPaintProperties paintProperties, bool animateRegions, bool snap, bool useDpi)
      {
         _viewer.BeginUpdate();
         UpdateAnimateRegions(animateRegions);
         UpdatePaintProperties(paintProperties);
         _viewer.Image = info.Image;
         _viewer.UseDpi = useDpi;
         if (_viewer.Image != null)
            _viewer.Image.Changed += new EventHandler<RasterImageChangedEventArgs>(Image_Changed);
         _name = info.Name;
         if (snap)
            Snap();
         UpdateCaption();
         _viewer.EndUpdate();
      }

      public void UpdatePaintProperties(RasterPaintProperties paintProperties)
      {
         _viewer.PaintProperties = paintProperties;
      }

      public void UpdateAnimateRegions(bool animateRegions)
      {
         LeadRectD rc = _viewer.GetItemBounds(_viewer.ActiveItem, ImageViewerItemPart.Floater);

         if (animateRegions)
            _viewer.ImageRegionRenderMode = ControlRegionRenderMode.Animated;
         else
            _viewer.ImageRegionRenderMode = ControlRegionRenderMode.Fixed;
         _viewer.FloaterRegionRenderMode = _viewer.ImageRegionRenderMode;
      }

      private void UpdateCaption()
      {
         if (_viewer.Image.PageCount > 1)
            Text = string.Format("{0} - " + DemosGlobalization.GetResxString(GetType(), "Resx_Page") + " {1}:{2}", System.IO.Path.GetFileName(_name), _viewer.Image.Page, _viewer.Image.PageCount);
         else
            Text = string.Format("{0}", System.IO.Path.GetFileName(_name));         
      }

      public RasterImage Image
      {
         get
         {
            return _viewer.Image;
         }
      }

      public ImageViewer Viewer
      {
         get
         {
            return _viewer;
         }
      }

      private void Image_Changed(object sender, RasterImageChangedEventArgs e)
      {
         UpdateCaption();
         if (MdiParent != null)
            ((MainForm)MdiParent).UpdateControls();
      }


      private void _viewer_SizeModeChanged(object sender, EventArgs e)
      {
         ((MainForm)MdiParent).UpdateControls();
      }

      public void Snap()
      {
         if (_viewer.ViewBounds.Width <= 0)
         {
            _viewer.ClientSize = new Size((int)_viewer.Bounds.Width, (int)_viewer.Bounds.Height);
            ClientSize = new Size((int)_viewer.Bounds.Width, (int)_viewer.Bounds.Height);
         }
         else
         {
            _viewer.ClientSize = new Size(_viewer.ViewBounds.Size.Width, _viewer.ViewBounds.Size.Height);
            ClientSize = new Size(_viewer.ViewBounds.Size.Width, _viewer.ViewBounds.Size.Height);
         }
      }

      private void _viewer_DragEnter(object sender, DragEventArgs e)
      {
         if (CanFocus)
         {
            if (Tools.CanDrop(e.Data))
               e.Effect = DragDropEffects.Copy;
         }
      }

      private void _viewer_DragDrop(object sender, DragEventArgs e)
      {
         if (CanFocus)
         {
            if (Tools.CanDrop(e.Data))
            {
               string[] files = Tools.GetDropFiles(e.Data);
               if (files != null)
                  ((MainForm)MdiParent).LoadDropFiles(this, files);
            }
         }
      }

      private void _viewer_KeyDown(object sender, KeyEventArgs e)
      {
         if (!e.Handled)
         {
            if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
               e.Handled = true;

               ((MainForm)MdiParent).Zoom(e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus);
            }
         }
      }
   }
}
