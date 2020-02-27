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
using Leadtools.ColorConversion;
using Leadtools.Demos;

namespace ColorConversionDemo
{
   /// <summary>
   /// Summary description for ConvertToDialog.
   /// </summary>
   public class ConvertToDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.CheckBox _cbFit;
      private System.Windows.Forms.Panel _pnlViewer;
      private System.Windows.Forms.GroupBox _gbSwapColors;
      private System.Windows.Forms.ComboBox _cbColorFormat;
      private System.Windows.Forms.Label _lblWarning;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public ConvertToDialog(RasterImage image, ConversionColorFormat srcFormat)
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
         InitClass(image, srcFormat);
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
         this._btnOK = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._pnlViewer = new System.Windows.Forms.Panel();
         this._cbFit = new System.Windows.Forms.CheckBox();
         this._gbSwapColors = new System.Windows.Forms.GroupBox();
         this._lblWarning = new System.Windows.Forms.Label();
         this._cbColorFormat = new System.Windows.Forms.ComboBox();
         this._gbSwapColors.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOK.Location = new System.Drawing.Point(456, 328);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(75, 23);
         this._btnOK.TabIndex = 3;
         this._btnOK.Text = "OK";
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(456, 360);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 4;
         this._btnCancel.Text = "Cancel";
         // 
         // _pnlViewer
         // 
         this._pnlViewer.Location = new System.Drawing.Point(8, 40);
         this._pnlViewer.Name = "_pnlViewer";
         this._pnlViewer.Size = new System.Drawing.Size(528, 208);
         this._pnlViewer.TabIndex = 1;
         // 
         // _cbFit
         // 
         this._cbFit.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._cbFit.Location = new System.Drawing.Point(8, 8);
         this._cbFit.Name = "_cbFit";
         this._cbFit.Size = new System.Drawing.Size(80, 24);
         this._cbFit.TabIndex = 0;
         this._cbFit.Text = "&Fit Image";
         this._cbFit.CheckedChanged += new System.EventHandler(this._cbFit_CheckedChanged);
         // 
         // _gbSwapColors
         // 
         this._gbSwapColors.Controls.Add(this._lblWarning);
         this._gbSwapColors.Controls.Add(this._cbColorFormat);
         this._gbSwapColors.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbSwapColors.Location = new System.Drawing.Point(8, 256);
         this._gbSwapColors.Name = "_gbSwapColors";
         this._gbSwapColors.Size = new System.Drawing.Size(432, 128);
         this._gbSwapColors.TabIndex = 2;
         this._gbSwapColors.TabStop = false;
         this._gbSwapColors.Text = "&Swap Colors:";
         // 
         // _lblWarning
         // 
         this._lblWarning.ForeColor = System.Drawing.Color.Red;
         this._lblWarning.Location = new System.Drawing.Point(16, 64);
         this._lblWarning.Name = "_lblWarning";
         this._lblWarning.Size = new System.Drawing.Size(400, 48);
         this._lblWarning.TabIndex = 1;
         this._lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _cbColorFormat
         // 
         this._cbColorFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbColorFormat.Location = new System.Drawing.Point(16, 32);
         this._cbColorFormat.Name = "_cbColorFormat";
         this._cbColorFormat.Size = new System.Drawing.Size(168, 21);
         this._cbColorFormat.TabIndex = 0;
         this._cbColorFormat.SelectedIndexChanged += new System.EventHandler(this._cbColorFormat_SelectedIndexChanged);
         // 
         // ConvertToDialog
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(546, 400);
         this.Controls.Add(this._gbSwapColors);
         this.Controls.Add(this._pnlViewer);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this._cbFit);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ConvertToDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Convert";
         this._gbSwapColors.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion

      private ImageViewer _viewer;
      private ConversionColorFormat _srcFormat;

      // Original image Buffer
      private byte[] _orgBuffer;

      // original image Width
      private int _width;

      // original image Height
      private int _height;

      // original image bytes/line
      private int _bytesPerLine;

      private RasterImage _resultImage;

      private struct ConvertItem
      {
         public ConversionColorFormat Format;
         public string Name;

         public ConvertItem(ConversionColorFormat f, string n)
         {
            Format = f;
            Name = n;
         }

         public override string ToString()
         {
            return Name;
         }
      }

      private static ConvertItem[] _convertItems =
      {
         new ConvertItem(ConversionColorFormat.Rgb, "RGB"),
         new ConvertItem(ConversionColorFormat.Yuv, "YUV"),
         new ConvertItem(ConversionColorFormat.Cmyk, "CMYK"),
         new ConvertItem(ConversionColorFormat.Hsv, "HSV"),
         new ConvertItem(ConversionColorFormat.Cmy, "CMY"),
         new ConvertItem(ConversionColorFormat.Hls, "HLS"),
         new ConvertItem(ConversionColorFormat.Yiq, "YIQ"),
         new ConvertItem(ConversionColorFormat.Lab, "LAB"),
         new ConvertItem(ConversionColorFormat.Xyz, "XYZ"),
         new ConvertItem(ConversionColorFormat.Yuy2, "YUY2"),
         new ConvertItem(ConversionColorFormat.Yvu9, "YVU9"),
         new ConvertItem(ConversionColorFormat.Uyvy, "UYVY"),
         new ConvertItem(ConversionColorFormat.Ycc, "YCC"),
      };

      private void InitClass(RasterImage image, ConversionColorFormat srcFormat)
      {
         _viewer = new ImageViewer();
         _viewer.BackColor = Color.DarkGray;
         _viewer.ViewHorizontalAlignment = ControlAlignment.Near;
         _viewer.Dock = DockStyle.Fill;
         _pnlViewer.Controls.Add(_viewer);
         _viewer.BringToFront();
         _viewer.Zoom(ControlSizeMode.Fit, 1, _viewer.DefaultZoomOrigin);

         _cbFit.Checked = _viewer.SizeMode == ControlSizeMode.Fit;

         // Start up the Color conversion toolkit.
         RasterColorConverterEngine.Startup();
         RasterImage tempImage = image.Clone();
         if (tempImage.ViewPerspective != RasterViewPerspective.TopLeft)
            tempImage.ChangeViewPerspective(RasterViewPerspective.TopLeft);

         _width = tempImage.Width;
         _height = tempImage.Height;
         _bytesPerLine = tempImage.BytesPerLine;

         _orgBuffer = new byte[_bytesPerLine * _height];

         tempImage.Access();

         for (int y = 0; y < _height - 1; y++)
            tempImage.GetRow(y, _orgBuffer, (y * _width * 3), _width * 3);

         _viewer.Image = tempImage;

         tempImage.Release();

         _srcFormat = srcFormat;

         foreach (ConvertItem i in _convertItems)
         {
            _cbColorFormat.Items.Add(i);
            if (i.Format == ConversionColorFormat.Yuv)
               _cbColorFormat.SelectedItem = i;
         }

         UpdateMyControls();
      }

      private void _cbFit_CheckedChanged(object sender, System.EventArgs e)
      {
         ControlSizeMode sizeMode = ControlSizeMode.ActualSize;

         if (_cbFit.Checked)
            sizeMode = ControlSizeMode.Fit;

         _viewer.Zoom(sizeMode, 1, _viewer.DefaultZoomOrigin);
      }

      private void _cbColorFormat_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         ConvertItem item = (ConvertItem)_cbColorFormat.SelectedItem;
         UpdateMyControls();
         ConvertToColorSpace(item.Format);
      }

      private void ConvertToColorSpace(ConversionColorFormat colorFormat)
      {
         if (_btnOK.Enabled)
         {
            using (WaitCursor wait = new WaitCursor())
            {
               try
               {
                  int bufferSize;

                  if (colorFormat == ConversionColorFormat.Cmyk)
                     bufferSize = (_bytesPerLine * _height) + ((_bytesPerLine * _height) / 3);
                  else
                     bufferSize = _bytesPerLine * _height;

                  byte[] newBuffer = new byte[bufferSize];

                  RasterColorConverterEngine.ConvertDirect(
                     _srcFormat,
                     colorFormat,
                     _orgBuffer,
                     0,
                     newBuffer,
                     0,
                     _width,
                     _height,
                     0,
                     0);

                  RasterColorConverterEngine.ConvertDirectToImage(
                     colorFormat,
                     _srcFormat,
                     newBuffer,
                     0,
                     _viewer.Image,
                     _width,
                     _height,
                     0,
                     (_bytesPerLine - _width * 3));

                  _viewer.Invalidate();

                  foreach (ConvertItem i in _convertItems)
                  {
                     if (i.Format == colorFormat)
                        MainForm.ConversionType = i.Name;
                  }
               }
               catch (Exception ex)
               {
                  Messager.ShowError(this, ex.Message);
               }
            }
         }
      }

      private void _btnOK_Click(object sender, System.EventArgs e)
      {
         _viewer.AutoDisposeImages = false;
         _resultImage = _viewer.Image;
         _viewer.Image = null;
         _viewer.AutoDisposeImages = true;
      }

      public RasterImage ResultImage
      {
         get
         {
            return _resultImage;
         }
      }

      private void UpdateMyControls()
      {
         bool enableOkButton = true;
         string warningMessage = string.Empty;

         // For YVU9, the image must have a width and height that is a multiple of 4
         // For YUY2 and UYVY, the width and height that is a multiple of 2

         ConvertItem item = (ConvertItem)_cbColorFormat.SelectedItem;
         if (item.Format == ConversionColorFormat.Yvu9)
         {
            if ((_width % 4) != 0 || (_height % 4) != 0)
            {
               enableOkButton = false;
               warningMessage = string.Format("For YVU9 color format, the image must have a width and height value that is a multiple of 4.{0}Current image has a width of {1} and height of {2} pixels.", Environment.NewLine, _width, _height);
            }
         }
         else if (item.Format == ConversionColorFormat.Yuy2 || item.Format == ConversionColorFormat.Uyvy)
         {
            if ((_width % 2) != 0 || (_height % 2) != 0)
            {
               enableOkButton = false;
               warningMessage = string.Format("For YUY2 and UYVY color format, the image must have a width and height value that is a multiple of 2.{0}Current image has a width of {1} and height of {2} pixels.", Environment.NewLine, _width, _height);
            }
         }

         _btnOK.Enabled = enableOkButton;
         _lblWarning.Text = warningMessage;
      }
   }
}
