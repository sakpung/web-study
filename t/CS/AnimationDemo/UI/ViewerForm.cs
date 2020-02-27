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
using Leadtools.Demos;
using Leadtools.Controls;

using Leadtools.Drawing;

namespace AnimationDemo
{
   public partial class ViewerForm : Form
   {
      public ViewerForm( )
      {
         InitializeComponent();

         InitClass();
      }

      private RasterPictureBox _viewer;
      private string _name;

      private void InitClass( )
      {
         _viewer = new RasterPictureBox();
         _viewer.Dock = DockStyle.Fill;
         _viewer.BorderStyle = BorderStyle.None;
         _viewer.FrameChanged += new EventHandler<RasterPictureBoxFrameChangedEventArgs>(_viewer_FrameChanged);
         Controls.Add(_viewer);
         _viewer.BringToFront();
      }

      void _viewer_FrameChanged(object sender, RasterPictureBoxFrameChangedEventArgs e)
      {
         UpdateCaption();
         if (MdiParent != null)
            ((MainForm)MdiParent).UpdateControls();
       }

      public void Initialize(ImageInformation info, RasterPaintProperties paintProperties, bool animateRegions, bool snap, bool useDpi, RasterPictureBoxAnimationMode animationMode)
      {
         _viewer.BeginUpdate();
         UpdatePaintProperties(paintProperties);
         _viewer.Image = info.Image;
         _viewer.UseDpi = useDpi;
         _viewer.AnimationMode = animationMode;
         if(_viewer.Image != null)
            _viewer.Image.Changed += new EventHandler<RasterImageChangedEventArgs>(Image_Changed);

         if (Image.Width > this.Viewer.Size.Width || Image.Height > this.Viewer.Size.Height)
            this.Viewer.SizeMode = RasterPictureBoxSizeMode.Fit;

         _name = info.Name;
         UpdateCaption();
         _viewer.EndUpdate();
      }

      public void UpdatePaintProperties(RasterPaintProperties paintProperties)
      {
         _viewer.PaintProperties = paintProperties;
         _viewer.Refresh();
      }

      private void UpdateCaption( )
      {
         Text = string.Format("{0} - Page {1}:{2}", _name, _viewer.Image.Page, _viewer.Image.PageCount);
      }

      public RasterImage Image
      {
         get
         {
            return _viewer.Image;
         }
      }

      public RasterPictureBox Viewer
      {
         get
         {
            return _viewer;
         }
      }

      public string Title
      {
         get
         {
            return _name;
         }
      }

      private void Image_Changed(object sender, RasterImageChangedEventArgs e)
      {
         UpdateCaption();
         if(MdiParent != null)
            ((MainForm)MdiParent).UpdateControls();
      }
   }
}
