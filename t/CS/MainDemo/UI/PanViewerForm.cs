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

using Leadtools.Controls;

namespace MainDemo
{
   public partial class PanViewerForm : Form
   {
      private ImageViewerPanControl _panViewer;

      public PanViewerForm()
      {
         InitializeComponent();

         InitClass();
      }

      private void InitClass()
      {
         PictureBox PanViewerPicture = new PictureBox();
         PanViewerPicture.Width = 400;
         PanViewerPicture.Dock = DockStyle.Fill;
         PanViewerPicture.BorderStyle = BorderStyle.None;
         Controls.Add(PanViewerPicture);
         PanViewerPicture.BringToFront();

         _panViewer = new ImageViewerPanControl();
         _panViewer.BorderPen = new Pen(Brushes.Red);
         _panViewer.EnablePan = true;
         _panViewer.OutsideBrush = new SolidBrush(Color.FromArgb(128, 0, 0, 0));
         _panViewer.MouseButton = System.Windows.Forms.MouseButtons.Left;
         _panViewer.WorkingCursor = Cursors.Hand;
         _panViewer.Control = PanViewerPicture;
      }

      private void PanViewerForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         e.Cancel = true;
         Visible = false;
         ((MainForm)Owner).UpdateControls();
      }

      public void SetViewer(ImageViewer viewer)
      {
         _panViewer.ImageViewer = viewer;
      }

      private void PanViewerForm_SizeChanged(object sender, EventArgs e)
      {
         if (_panViewer != null)
            _panViewer.ImageViewer.Invalidate();
      }
   }
}
