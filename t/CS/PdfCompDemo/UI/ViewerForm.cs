// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

using Leadtools;
using Leadtools.Controls;
using Leadtools.Demos;
using Leadtools.Drawing;

namespace PdfCompDemo
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
         this.BackColor = System.Drawing.SystemColors.AppWorkspace;
         this.ClientSize = new System.Drawing.Size(292, 271);
         this.Cursor = System.Windows.Forms.Cursors.Default;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "ViewerForm";
         this.ShowInTaskbar = false;
         this.Text = "ViewerForm";
         this.Closing += new System.ComponentModel.CancelEventHandler(this.ViewerForm_Closing);
         this.MdiChildActivate += new System.EventHandler(this.ViewerForm_MdiChildActivate);
         this.Activated += new System.EventHandler(this.ViewerForm_MdiChildActivate);
         this.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewerForm_Paint);

      }
      #endregion

      internal PdfStandardOptions StandardOptions
      {
         get
         {
            return _standardOptions;
         }
         set
         {
            _standardOptions = value;
         }
      }

      internal PdfAdvancedOptions AdvancedOptions
      {
         get
         {
            return _advancedOptions;
         }
         set
         {
            _advancedOptions = value;
         }
      }

      public RasterImage Image
      {
         get
         {
            return _tempImage;
         }
      }

      public ImageViewer Viewer
      {
         get
         {
            return _viewer;
         }
      }

      private ImageViewer _viewer;
      private RasterImage _tempImage;
      private string _name;
      private PdfStandardOptions _standardOptions;
      private PdfAdvancedOptions _advancedOptions;
      private RectangleF _drawRect;



      private void InitClass()
      {
         _viewer = new ImageViewer();

         _viewer.Dock = DockStyle.Fill;
         _viewer.BorderStyle = BorderStyle.None;
         _viewer.DragEnter += new DragEventHandler(_viewer_DragEnter);
         _viewer.DragDrop += new DragEventHandler(_viewer_DragDrop);
         _viewer.DoubleClick += new EventHandler(_viewer_DoubleClick);

         Controls.Add(_viewer);
         _viewer.BringToFront();
         _viewer.AllowDrop = true;

      }

      public void Initialize(ImageInformation info, RasterPaintProperties paintProperties, bool snap)
      {
         _viewer.BeginUpdate();
         UpdatePaintProperties(paintProperties);
         _viewer.Image = info.Image;
         _tempImage = _viewer.Image.CloneAll();
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

      private void UpdateCaption()
      {
         //Do nothing now
         Text = string.Format("{0} ", _name, _viewer.Image.Page, _viewer.Image.PageCount);
      }

      private void Image_Changed(object sender, RasterImageChangedEventArgs e)
      {
         UpdateCaption();
         if (MdiParent != null)
            ((MainForm)MdiParent).UpdateControls();
      }

      public void Snap()
      {
         _viewer.ClientSize = _viewer.DisplayRectangle.Size;
         ClientSize = _viewer.ClientSize;
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

      private void ViewerForm_MdiChildActivate(object sender, System.EventArgs e)
      {
         if (MdiParent != null)
            ((MainForm)MdiParent).UpdateControls();
      }


      private void ViewerForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
      {
         Color drawColor;

         if (_viewer.Image != null)
         {
            if (_viewer.Image.Width >= 150 && _viewer.Image.Height >= 150)
            {
               _viewer.Image = _tempImage.CloneAll();

               using (RasterImageGdiPlusGraphicsContainer container = new RasterImageGdiPlusGraphicsContainer(_viewer.Image))
               {

                  // Create string to draw.
                  String drawString = "";


                  if (StandardOptions.Added)
                  {
                     drawString += " Status : ADDED\n";
                     drawString += " Index: ";
                     drawString += StandardOptions.PageNumber;
                     if (!StandardOptions.NOMRC)
                     {
                        drawString += "\n";
                        drawString += " Input Quality: ";

                        switch (StandardOptions.InputImageComboSel)
                        {
                           case 0:
                              drawString += "Auto";
                              break;
                           case 1:
                              drawString += "Noisy";
                              break;
                           case 2:
                              drawString += "Scanned";
                              break;
                           case 3:
                              drawString += "Printed";
                              break;
                           case 4:
                              drawString += "Computer Generated";
                              break;
                           case 5:
                              drawString += "Photo";
                              break;
                           case 6:
                              drawString += "User Defined";
                              break;
                        }

                        drawString += "\n Output Quality : ";
                        switch (StandardOptions.OutputImageComboSel)
                        {
                           case 0:
                              drawString += "Auto";
                              break;
                           case 1:
                              drawString += "Poor";
                              break;
                           case 2:
                              drawString += "Average";
                              break;
                           case 3:
                              drawString += "Good";
                              break;
                           case 4:
                              drawString += "Excellent";
                              break;
                           case 5:
                              drawString += "User Defined";
                              break;
                        }
                     }
                     drawColor = Color.Green;
                  }
                  else
                  {
                     drawString += " Status : NOT ADDED";
                     drawColor = Color.Red;
                  }

                  // Create font and brush.
                  int fontSize = 12;
                  LinearGradientBrush gradientBrush;
                  Font drawFont = new Font("Arial", fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
                  SolidBrush drawBrush = new SolidBrush(Color.Black);

                  // Set format of string.
                  SizeF size = container.Graphics.MeasureString(drawString, drawFont);
                  Pen pen = new Pen(drawColor, 0);
                  container.Graphics.DrawRectangle(pen, 0, 0, _viewer.Image.Width, size.Height);

                  _drawRect = new RectangleF(0, 0, _viewer.Image.Width, size.Height);

                  StringFormat drawFormat = new StringFormat();
                  drawFormat.Alignment = StringAlignment.Center;
                  gradientBrush = new LinearGradientBrush(_drawRect, drawColor, Color.White, LinearGradientMode.ForwardDiagonal);

                  container.Graphics.FillRectangle(gradientBrush, _drawRect);

                  container.Graphics.DrawString(drawString, drawFont, drawBrush, _drawRect);//,drawFormat);               
               }
            }
         }
      }

      private void _viewer_DoubleClick(object sender, EventArgs e)
      {
         _viewer.MouseMove += new MouseEventHandler(_viewer_MouseMove);
      }


      private void _viewer_MouseMove(object sender, MouseEventArgs e)
      {
         if (e.X >= _drawRect.X &&
            e.X <= _drawRect.X + _drawRect.Width &&
            e.Y >= _drawRect.Y &&
            e.Y <= _drawRect.Y + _drawRect.Height)
         {
            ((MainForm)MdiParent).PdfOptionsAddDialog();
            ViewerForm.ActiveForm.Refresh();
         }
         _viewer.MouseMove -= new MouseEventHandler(_viewer_MouseMove);

      }

      private void ViewerForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         if (MdiParent != null)
            ((MainForm)MdiParent).DeletePage();
      }
   }
}
