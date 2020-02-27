// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Controls;
using Leadtools.Demos;
using Leadtools.Drawing;

namespace AbcDemo
{
   /// <summary>
   /// Summary description for ViewerForm.
   /// </summary>
   public class ViewerForm : System.Windows.Forms.Form
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public ViewerForm()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
         InitClass();
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            if (components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ViewerForm));
         // 
         // ViewerForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(292, 273);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "ViewerForm";
         this.ShowInTaskbar = false;
         this.Text = "ViewerForm";
         this.Closed += new System.EventHandler(this.ViewerForm_Closed);

      }
      #endregion

      private ImageViewer _viewer;
      private string _name;
      private bool _originalViewer;

      private void InitClass()
      {
         _viewer = new ImageViewer();
         _viewer.Dock = DockStyle.Fill;
         _viewer.DragEnter += new DragEventHandler(_viewer_DragEnter);
         _viewer.DragDrop += new DragEventHandler(_viewer_DragDrop);
         _viewer.KeyDown += new KeyEventHandler(_viewer_KeyDown);
         Controls.Add(_viewer);
         _viewer.BringToFront();
         _viewer.AllowDrop = true;

         _viewer.Zoom(ControlSizeMode.ActualSize, 1.0, _viewer.DefaultZoomOrigin);
      }

      public void Initialize(ImageInformation info, RasterPaintProperties paintProperties, bool snap)
      {
         _viewer.BeginUpdate();
         UpdatePaintProperties(paintProperties);
         _viewer.Image = info.Image;
         if (_viewer.Image != null)
            _viewer.Image.Changed += new EventHandler<RasterImageChangedEventArgs>(Image_Changed);
         _name = info.Name;
         UpdateCaption();
         _viewer.EndUpdate();

         if (snap)
            Snap();
      }

      public void UpdatePaintProperties(RasterPaintProperties paintProperties)
      {
         _viewer.PaintProperties = paintProperties;
      }

      private void UpdateCaption()
      {
         Text = _name;
      }

      public bool OriginalViewer
      {
         get
         {
            return _originalViewer;
         }
         set
         {
            _originalViewer = value;
         }
      }

      public RasterImage Image
      {
         get
         {
            return _viewer.Image;
         }
         set
         {
            _viewer.Image = value;
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
         Screen workingScreen = Screen.FromRectangle(new Rectangle(this.Location, this.Size));
         if ((_viewer.Image.Height < workingScreen.WorkingArea.Height) && (_viewer.Width < workingScreen.WorkingArea.Width))
            ClientSize = new Size(_viewer.ViewSize.Width, _viewer.ViewSize.Height);
      }

      private void _viewer_DragEnter(object sender, DragEventArgs e)
      {
         if (Tools.CanDrop(e.Data))
            e.Effect = DragDropEffects.Copy;
      }

      private void _viewer_DragDrop(object sender, DragEventArgs e)
      {
         if (Tools.CanDrop(e.Data))
         {
            string[] files = Tools.GetDropFiles(e.Data);
            if (files != null)
               ((MainForm)MdiParent).LoadDropFiles(this, files);
         }
      }

      private void _viewer_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
      {
         if (!e.Handled)
         {
            if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
            {
               e.Handled = true;

               ((MainForm)MdiParent)._miView_Click(((MainForm)MdiParent).ZoomIn, null);
            }
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
               e.Handled = true;

               ((MainForm)MdiParent)._miView_Click(((MainForm)MdiParent).ZoomOut, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
               e.Handled = true;

               ((MainForm)MdiParent).StopSaving = true;
            }
         }
      }

      private void ViewerForm_Closed(object sender, System.EventArgs e)
      {
         if (_originalViewer)
         {
            ((MainForm)MdiParent).ViewerOpened = false;

            if (((MainForm)MdiParent).MdiChildren.Length > 1)
            {
               ((MainForm)MdiParent).MdiChildren[1].Close();
               ((MainForm)MdiParent).UpdateControls();
               ((MainForm)MdiParent).ShowSave = false;
               ((MainForm)MdiParent).PreviousCheckQuality.Checked = false;
            }
         }
      }
   }
}
