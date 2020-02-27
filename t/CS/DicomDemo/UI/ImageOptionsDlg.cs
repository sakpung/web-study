// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;

using Leadtools.DicomDemos;

using Leadtools;
using Leadtools.Dicom;
using Leadtools.Codecs;
using Leadtools.Demos;

namespace DicomDemo
{
   /// <summary>
   /// Summary description for ImageOptionsDlg.
   /// </summary>
   public class ImageOptionsDlg : System.Windows.Forms.Form
   {
      private System.Windows.Forms.GroupBox groupBox1;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;
      private System.Windows.Forms.RadioButton radioButtonNone;
      private System.Windows.Forms.RadioButton radioButtonRunLength;
      private System.Windows.Forms.RadioButton radioButtonJpegLossless;
      private System.Windows.Forms.RadioButton radioButtonJPEGLossy;
      private System.Windows.Forms.RadioButton radioButtonJ2kLossless;
      private System.Windows.Forms.RadioButton radioButtonJ2kLossy;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button buttonJ2kOptions;
      private System.Windows.Forms.NumericUpDown numericUpDownQFactor;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.RadioButton radioButtonMonochrome;
      private System.Windows.Forms.RadioButton radioButtonPalette;
      private System.Windows.Forms.RadioButton radioButtonRGB;
      private System.Windows.Forms.RadioButton radioButton8;
      private System.Windows.Forms.RadioButton radioButton12;
      private System.Windows.Forms.RadioButton radioButton16;
      private System.Windows.Forms.RadioButton radioButton24;

      private DicomDataSet ds;
      private DicomElement element;

      private DicomImageCompressionType _Compression;
      private int _BitsPerPixel;
      private string _TransferSyntax;
      private bool _UseNewImageFile;
      private bool _ForceNewImageFileName;
      private RasterImage _raster;
      private System.Windows.Forms.Button buttonOriginal;
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.GroupBox groupBox4;
      private System.Windows.Forms.CheckBox checkBoxUseExistingImage;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox textBoxNewImageFileName;
      private System.Windows.Forms.Button buttonSelectNewImage;
      private RadioButton radioButtonJpegLsLossy;
      private RadioButton radioButtonJpegLsLossless;
      private DicomImagePhotometricInterpretationType _PhotoMetric;


      public bool UseNewImageFile
      {
         get
         {
            return _UseNewImageFile;
         }
      }
      public bool ForceNewImageFileName
      {
         get
         {
            return _ForceNewImageFileName;
         }
         set
         {
            _ForceNewImageFileName = value;
         }
      }

      public RasterImage NewImage
      {
         get
         {
            return _raster;
         }
      }
      public DicomImageCompressionType Compression
      {
         get
         {
            return _Compression;
         }
      }

      public int BitsPerPixel
      {
         get
         {
            return _BitsPerPixel;
         }
      }

      public int QFactor
      {
         get
         {
            return Convert.ToInt32(numericUpDownQFactor.Value);
         }
      }

      public string TransferSyntax
      {
         get
         {
            return _TransferSyntax;
         }
      }

      public DicomImagePhotometricInterpretationType PhotoMetric
      {
         get
         {
            return _PhotoMetric;
         }
      }

      public ImageOptionsDlg(DicomDataSet ds, DicomElement element)
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();
         _ForceNewImageFileName = false;
         buttonJ2kOptions.Visible = false;
         this.ds = ds;
         this.element = element;
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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.radioButtonJpegLsLossy = new System.Windows.Forms.RadioButton();
         this.radioButtonJpegLsLossless = new System.Windows.Forms.RadioButton();
         this.buttonJ2kOptions = new System.Windows.Forms.Button();
         this.numericUpDownQFactor = new System.Windows.Forms.NumericUpDown();
         this.label1 = new System.Windows.Forms.Label();
         this.radioButtonJ2kLossy = new System.Windows.Forms.RadioButton();
         this.radioButtonJ2kLossless = new System.Windows.Forms.RadioButton();
         this.radioButtonJPEGLossy = new System.Windows.Forms.RadioButton();
         this.radioButtonJpegLossless = new System.Windows.Forms.RadioButton();
         this.radioButtonRunLength = new System.Windows.Forms.RadioButton();
         this.radioButtonNone = new System.Windows.Forms.RadioButton();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.buttonOK = new System.Windows.Forms.Button();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.radioButtonRGB = new System.Windows.Forms.RadioButton();
         this.radioButtonPalette = new System.Windows.Forms.RadioButton();
         this.radioButtonMonochrome = new System.Windows.Forms.RadioButton();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.radioButton24 = new System.Windows.Forms.RadioButton();
         this.radioButton16 = new System.Windows.Forms.RadioButton();
         this.radioButton12 = new System.Windows.Forms.RadioButton();
         this.radioButton8 = new System.Windows.Forms.RadioButton();
         this.buttonOriginal = new System.Windows.Forms.Button();
         this.groupBox4 = new System.Windows.Forms.GroupBox();
         this.buttonSelectNewImage = new System.Windows.Forms.Button();
         this.textBoxNewImageFileName = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.checkBoxUseExistingImage = new System.Windows.Forms.CheckBox();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQFactor)).BeginInit();
         this.groupBox2.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.groupBox4.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.radioButtonJpegLsLossy);
         this.groupBox1.Controls.Add(this.radioButtonJpegLsLossless);
         this.groupBox1.Controls.Add(this.buttonJ2kOptions);
         this.groupBox1.Controls.Add(this.numericUpDownQFactor);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this.radioButtonJ2kLossy);
         this.groupBox1.Controls.Add(this.radioButtonJ2kLossless);
         this.groupBox1.Controls.Add(this.radioButtonJPEGLossy);
         this.groupBox1.Controls.Add(this.radioButtonJpegLossless);
         this.groupBox1.Controls.Add(this.radioButtonRunLength);
         this.groupBox1.Controls.Add(this.radioButtonNone);
         this.groupBox1.Location = new System.Drawing.Point(8, 8);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(160, 288);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Compression";
         // 
         // radioButtonJpegLsLossy
         // 
         this.radioButtonJpegLsLossy.Location = new System.Drawing.Point(16, 144);
         this.radioButtonJpegLsLossy.Name = "radioButtonJpegLsLossy";
         this.radioButtonJpegLsLossy.Size = new System.Drawing.Size(120, 24);
         this.radioButtonJpegLsLossy.TabIndex = 11;
         this.radioButtonJpegLsLossy.Text = "JPEG-LS Lossy";
         this.radioButtonJpegLsLossy.CheckedChanged += new System.EventHandler(this.radioButtonJPEGLSLossy_CheckedChanged);
         // 
         // radioButtonJpegLsLossless
         // 
         this.radioButtonJpegLsLossless.Location = new System.Drawing.Point(16, 120);
         this.radioButtonJpegLsLossless.Name = "radioButtonJpegLsLossless";
         this.radioButtonJpegLsLossless.Size = new System.Drawing.Size(128, 24);
         this.radioButtonJpegLsLossless.TabIndex = 10;
         this.radioButtonJpegLsLossless.Text = "JPEG-LS Lossless";
         this.radioButtonJpegLsLossless.CheckedChanged += new System.EventHandler(this.radioButtonJPEGLSLossless_CheckedChanged);
         // 
         // buttonJ2kOptions
         // 
         this.buttonJ2kOptions.Location = new System.Drawing.Point(16, 256);
         this.buttonJ2kOptions.Name = "buttonJ2kOptions";
         this.buttonJ2kOptions.Size = new System.Drawing.Size(112, 23);
         this.buttonJ2kOptions.TabIndex = 9;
         this.buttonJ2kOptions.Text = "Options...";
         // 
         // numericUpDownQFactor
         // 
         this.numericUpDownQFactor.Enabled = false;
         this.numericUpDownQFactor.Location = new System.Drawing.Point(72, 224);
         this.numericUpDownQFactor.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
         this.numericUpDownQFactor.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
         this.numericUpDownQFactor.Name = "numericUpDownQFactor";
         this.numericUpDownQFactor.Size = new System.Drawing.Size(56, 20);
         this.numericUpDownQFactor.TabIndex = 8;
         this.numericUpDownQFactor.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(16, 228);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(48, 16);
         this.label1.TabIndex = 6;
         this.label1.Text = "QFactor:";
         // 
         // radioButtonJ2kLossy
         // 
         this.radioButtonJ2kLossy.Location = new System.Drawing.Point(16, 192);
         this.radioButtonJ2kLossy.Name = "radioButtonJ2kLossy";
         this.radioButtonJ2kLossy.Size = new System.Drawing.Size(120, 24);
         this.radioButtonJ2kLossy.TabIndex = 5;
         this.radioButtonJ2kLossy.Text = "JPEG 2000 Lossy";
         this.radioButtonJ2kLossy.CheckedChanged += new System.EventHandler(this.radioButtonJ2kLossy_CheckedChanged);
         // 
         // radioButtonJ2kLossless
         // 
         this.radioButtonJ2kLossless.Location = new System.Drawing.Point(16, 168);
         this.radioButtonJ2kLossless.Name = "radioButtonJ2kLossless";
         this.radioButtonJ2kLossless.Size = new System.Drawing.Size(128, 24);
         this.radioButtonJ2kLossless.TabIndex = 4;
         this.radioButtonJ2kLossless.Text = "JPEG 2000 Lossless";
         this.radioButtonJ2kLossless.CheckedChanged += new System.EventHandler(this.radioButtonJ2kLossless_CheckedChanged);
         // 
         // radioButtonJPEGLossy
         // 
         this.radioButtonJPEGLossy.Location = new System.Drawing.Point(16, 96);
         this.radioButtonJPEGLossy.Name = "radioButtonJPEGLossy";
         this.radioButtonJPEGLossy.Size = new System.Drawing.Size(104, 24);
         this.radioButtonJPEGLossy.TabIndex = 3;
         this.radioButtonJPEGLossy.Text = "JPEG Lossy";
         this.radioButtonJPEGLossy.CheckedChanged += new System.EventHandler(this.radioButtonJPEGLossy_CheckedChanged);
         // 
         // radioButtonJpegLossless
         // 
         this.radioButtonJpegLossless.Location = new System.Drawing.Point(16, 72);
         this.radioButtonJpegLossless.Name = "radioButtonJpegLossless";
         this.radioButtonJpegLossless.Size = new System.Drawing.Size(104, 24);
         this.radioButtonJpegLossless.TabIndex = 2;
         this.radioButtonJpegLossless.Text = "JPEG Lossless";
         this.radioButtonJpegLossless.CheckedChanged += new System.EventHandler(this.radioButtonJpegLossless_CheckedChanged);
         // 
         // radioButtonRunLength
         // 
         this.radioButtonRunLength.Location = new System.Drawing.Point(16, 48);
         this.radioButtonRunLength.Name = "radioButtonRunLength";
         this.radioButtonRunLength.Size = new System.Drawing.Size(104, 24);
         this.radioButtonRunLength.TabIndex = 1;
         this.radioButtonRunLength.Text = "Run Length";
         this.radioButtonRunLength.CheckedChanged += new System.EventHandler(this.radioButtonRunLength_CheckedChanged);
         // 
         // radioButtonNone
         // 
         this.radioButtonNone.Location = new System.Drawing.Point(16, 24);
         this.radioButtonNone.Name = "radioButtonNone";
         this.radioButtonNone.Size = new System.Drawing.Size(104, 24);
         this.radioButtonNone.TabIndex = 0;
         this.radioButtonNone.Text = "None";
         this.radioButtonNone.CheckedChanged += new System.EventHandler(this.radioButtonNone_CheckedChanged);
         // 
         // buttonCancel
         // 
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(493, 312);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 1;
         this.buttonCancel.Text = "&Cancel";
         // 
         // buttonOK
         // 
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(408, 312);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 2;
         this.buttonOK.Text = "&OK";
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.radioButtonRGB);
         this.groupBox2.Controls.Add(this.radioButtonPalette);
         this.groupBox2.Controls.Add(this.radioButtonMonochrome);
         this.groupBox2.Location = new System.Drawing.Point(176, 8);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(176, 120);
         this.groupBox2.TabIndex = 3;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Photometric Interpretation";
         // 
         // radioButtonRGB
         // 
         this.radioButtonRGB.Location = new System.Drawing.Point(16, 72);
         this.radioButtonRGB.Name = "radioButtonRGB";
         this.radioButtonRGB.Size = new System.Drawing.Size(104, 24);
         this.radioButtonRGB.TabIndex = 2;
         this.radioButtonRGB.Text = "RGB";
         this.radioButtonRGB.CheckedChanged += new System.EventHandler(this.radioButtonRGB_CheckedChanged);
         // 
         // radioButtonPalette
         // 
         this.radioButtonPalette.Location = new System.Drawing.Point(16, 48);
         this.radioButtonPalette.Name = "radioButtonPalette";
         this.radioButtonPalette.Size = new System.Drawing.Size(104, 24);
         this.radioButtonPalette.TabIndex = 1;
         this.radioButtonPalette.Text = "Palette";
         this.radioButtonPalette.CheckedChanged += new System.EventHandler(this.radioButtonPalette_CheckedChanged);
         // 
         // radioButtonMonochrome
         // 
         this.radioButtonMonochrome.Location = new System.Drawing.Point(16, 24);
         this.radioButtonMonochrome.Name = "radioButtonMonochrome";
         this.radioButtonMonochrome.Size = new System.Drawing.Size(104, 24);
         this.radioButtonMonochrome.TabIndex = 0;
         this.radioButtonMonochrome.Text = "Monochrome 2";
         this.radioButtonMonochrome.CheckedChanged += new System.EventHandler(this.radioButtonMonochrome_CheckedChanged);
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this.radioButton24);
         this.groupBox3.Controls.Add(this.radioButton16);
         this.groupBox3.Controls.Add(this.radioButton12);
         this.groupBox3.Controls.Add(this.radioButton8);
         this.groupBox3.Location = new System.Drawing.Point(368, 8);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(200, 120);
         this.groupBox3.TabIndex = 4;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Bits Per Pixel";
         // 
         // radioButton24
         // 
         this.radioButton24.Enabled = false;
         this.radioButton24.Location = new System.Drawing.Point(16, 88);
         this.radioButton24.Name = "radioButton24";
         this.radioButton24.Size = new System.Drawing.Size(104, 16);
         this.radioButton24.TabIndex = 3;
         this.radioButton24.Text = "24";
         this.radioButton24.CheckedChanged += new System.EventHandler(this.radioButton24_CheckedChanged);
         // 
         // radioButton16
         // 
         this.radioButton16.Enabled = false;
         this.radioButton16.Location = new System.Drawing.Point(16, 64);
         this.radioButton16.Name = "radioButton16";
         this.radioButton16.Size = new System.Drawing.Size(104, 24);
         this.radioButton16.TabIndex = 2;
         this.radioButton16.Text = "16";
         this.radioButton16.CheckedChanged += new System.EventHandler(this.radioButton16_CheckedChanged);
         // 
         // radioButton12
         // 
         this.radioButton12.Enabled = false;
         this.radioButton12.Location = new System.Drawing.Point(16, 48);
         this.radioButton12.Name = "radioButton12";
         this.radioButton12.Size = new System.Drawing.Size(104, 16);
         this.radioButton12.TabIndex = 1;
         this.radioButton12.Text = "12";
         this.radioButton12.CheckedChanged += new System.EventHandler(this.radioButton12_CheckedChanged);
         // 
         // radioButton8
         // 
         this.radioButton8.Enabled = false;
         this.radioButton8.Location = new System.Drawing.Point(16, 24);
         this.radioButton8.Name = "radioButton8";
         this.radioButton8.Size = new System.Drawing.Size(104, 24);
         this.radioButton8.TabIndex = 0;
         this.radioButton8.Text = "8";
         this.radioButton8.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
         // 
         // buttonOriginal
         // 
         this.buttonOriginal.Location = new System.Drawing.Point(8, 312);
         this.buttonOriginal.Name = "buttonOriginal";
         this.buttonOriginal.Size = new System.Drawing.Size(75, 23);
         this.buttonOriginal.TabIndex = 5;
         this.buttonOriginal.Text = "Default";
         this.buttonOriginal.Click += new System.EventHandler(this.buttonOriginal_Click);
         // 
         // groupBox4
         // 
         this.groupBox4.Controls.Add(this.buttonSelectNewImage);
         this.groupBox4.Controls.Add(this.textBoxNewImageFileName);
         this.groupBox4.Controls.Add(this.label2);
         this.groupBox4.Controls.Add(this.checkBoxUseExistingImage);
         this.groupBox4.Location = new System.Drawing.Point(176, 136);
         this.groupBox4.Name = "groupBox4";
         this.groupBox4.Size = new System.Drawing.Size(392, 120);
         this.groupBox4.TabIndex = 6;
         this.groupBox4.TabStop = false;
         this.groupBox4.Text = "Image File";
         // 
         // buttonSelectNewImage
         // 
         this.buttonSelectNewImage.Location = new System.Drawing.Point(304, 88);
         this.buttonSelectNewImage.Name = "buttonSelectNewImage";
         this.buttonSelectNewImage.Size = new System.Drawing.Size(80, 24);
         this.buttonSelectNewImage.TabIndex = 3;
         this.buttonSelectNewImage.Text = "Select File...";
         this.buttonSelectNewImage.Click += new System.EventHandler(this.buttonSelectNewImage_Click);
         // 
         // textBoxNewImageFileName
         // 
         this.textBoxNewImageFileName.Location = new System.Drawing.Point(16, 88);
         this.textBoxNewImageFileName.Name = "textBoxNewImageFileName";
         this.textBoxNewImageFileName.ReadOnly = true;
         this.textBoxNewImageFileName.Size = new System.Drawing.Size(280, 20);
         this.textBoxNewImageFileName.TabIndex = 2;
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(16, 64);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(160, 16);
         this.label2.TabIndex = 1;
         this.label2.Text = "New Image File Name";
         // 
         // checkBoxUseExistingImage
         // 
         this.checkBoxUseExistingImage.Location = new System.Drawing.Point(16, 24);
         this.checkBoxUseExistingImage.Name = "checkBoxUseExistingImage";
         this.checkBoxUseExistingImage.Size = new System.Drawing.Size(144, 16);
         this.checkBoxUseExistingImage.TabIndex = 0;
         this.checkBoxUseExistingImage.Text = "Use Existing Image";
         this.checkBoxUseExistingImage.CheckedChanged += new System.EventHandler(this.checkBoxUseExistingImage_CheckedChanged);
         // 
         // ImageOptionsDlg
         // 
         this.AcceptButton = this.buttonOK;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(578, 346);
         this.Controls.Add(this.groupBox4);
         this.Controls.Add(this.buttonOriginal);
         this.Controls.Add(this.groupBox3);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ImageOptionsDlg";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Image Options";
         this.Load += new System.EventHandler(this.ImageOptionsDlg_Load);
         this.Closed += new System.EventHandler(this.ImageOptionsDlg_Closed);
         this.groupBox1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQFactor)).EndInit();
         this.groupBox2.ResumeLayout(false);
         this.groupBox3.ResumeLayout(false);
         this.groupBox4.ResumeLayout(false);
         this.groupBox4.PerformLayout();
         this.ResumeLayout(false);

      }
      #endregion

      private void radioButtonJPEGLossy_CheckedChanged(object sender, System.EventArgs e)
      {
         numericUpDownQFactor.Enabled = radioButtonJPEGLossy.Checked;
         if (radioButtonJPEGLossy.Checked)
         {
            _Compression = DicomImageCompressionType.JpegLossy;
            _TransferSyntax = DicomUidType.JPEGBaseline1;
         }
      }

      private void radioButtonJPEGLSLossless_CheckedChanged(object sender, EventArgs e)
      {
         if (radioButtonJpegLsLossless.Checked)
         {
            _Compression = DicomImageCompressionType.JpegLsLossless;
            _TransferSyntax = DicomUidType.JPEGLSLossless;
         }
      }

      private void radioButtonJPEGLSLossy_CheckedChanged(object sender, EventArgs e)
      {
         numericUpDownQFactor.Enabled = radioButtonJpegLsLossy.Checked;
         if (radioButtonJpegLsLossy.Checked)
         {
            _Compression = DicomImageCompressionType.JpegLsLossy;
            _TransferSyntax = DicomUidType.JPEGLSLossy;
         }
      }

      private void radioButtonJ2kLossy_CheckedChanged(object sender, System.EventArgs e)
      {
         numericUpDownQFactor.Enabled = radioButtonJ2kLossy.Checked;
         if (radioButtonJ2kLossy.Checked)
         {
            _Compression = DicomImageCompressionType.J2kLossy;
            _TransferSyntax = DicomUidType.JPEG2000;
         }
      }

      private void radioButtonPalette_CheckedChanged(object sender, System.EventArgs e)
      {
         radioButton8.Enabled = radioButtonPalette.Checked;
         radioButton8.Checked = true;
         //radioButton12.Enabled = radioButtonPalette.Checked;

         if (radioButtonPalette.Checked)
         {
            _PhotoMetric = DicomImagePhotometricInterpretationType.PaletteColor;
         }
      }

      private void radioButtonMonochrome_CheckedChanged(object sender, System.EventArgs e)
      {
         radioButton8.Enabled = radioButtonMonochrome.Checked;
         radioButton12.Enabled = radioButtonMonochrome.Checked;
         radioButton16.Enabled = radioButtonMonochrome.Checked;

         if (radioButtonMonochrome.Checked)
         {
            if (radioButton24.Checked)
               radioButton16.Checked = true;
            _PhotoMetric = DicomImagePhotometricInterpretationType.Monochrome2;
         }
      }

      private void radioButtonRGB_CheckedChanged(object sender, System.EventArgs e)
      {
         radioButton24.Enabled = radioButtonRGB.Checked;
         radioButton24.Checked = true;

         if (radioButtonRGB.Checked)
         {
            _PhotoMetric = DicomImagePhotometricInterpretationType.Rgb;
         }
      }

      private void ImageOptionsDlg_Closed(object sender, System.EventArgs e)
      {
         if (DialogResult == DialogResult.OK)
         {

         }
      }

      private void radioButtonNone_CheckedChanged(object sender, System.EventArgs e)
      {
         if (radioButtonNone.Checked)
         {
            _Compression = DicomImageCompressionType.None;
            _TransferSyntax = DicomUidType.ImplicitVRLittleEndian;
         }
      }

      private void radioButtonRunLength_CheckedChanged(object sender, System.EventArgs e)
      {
         if (radioButtonRunLength.Checked)
         {
            _Compression = DicomImageCompressionType.Rle;
            _TransferSyntax = DicomUidType.RLELossless;
         }
      }

      private void radioButtonJpegLossless_CheckedChanged(object sender, System.EventArgs e)
      {
         if (radioButtonJpegLossless.Checked)
         {
            _Compression = DicomImageCompressionType.JpegLossless;
            _TransferSyntax = DicomUidType.JPEGLosslessNonhier14B;
         }
      }

      private void radioButtonJ2kLossless_CheckedChanged(object sender, System.EventArgs e)
      {
         if (radioButtonJ2kLossless.Checked)
         {
            _Compression = DicomImageCompressionType.J2kLossless;
            _TransferSyntax = DicomUidType.JPEG2000LosslessOnly;
         }
      }

      private void radioButton8_CheckedChanged(object sender, System.EventArgs e)
      {
         if (radioButton8.Checked)
         {
            _BitsPerPixel = 8;
         }
      }

      private void radioButton12_CheckedChanged(object sender, System.EventArgs e)
      {
         if (radioButton12.Checked)
         {
            _BitsPerPixel = 12;
         }
      }

      private void radioButton16_CheckedChanged(object sender, System.EventArgs e)
      {
         if (radioButton16.Checked)
         {
            _BitsPerPixel = 16;
         }
      }

      private void radioButton24_CheckedChanged(object sender, System.EventArgs e)
      {
         if (radioButton24.Checked)
         {
            _BitsPerPixel = 24;
         }
      }

      private void ImageOptionsDlg_Load(object sender, System.EventArgs e)
      {
#if !LEADTOOLS_V175_OR_LATER
         radioButtonJpegLsLossless.Enabled = false;
         radioButtonJpegLsLossy.Enabled = false;
#endif
         SetDefaults();
      }

      private void SetDefaults()
      {
         DicomImageInformation imageInfo;

         try
         {
            imageInfo = ds.GetImageInformation(element, 0);

            //
            // Initialize Bits Per Pixel
            //
            if (imageInfo.BitsPerPixel == 8)
               radioButton8.Checked = true;
            else if (imageInfo.BitsPerPixel == 12)
               radioButton12.Checked = true;
            else if (imageInfo.BitsPerPixel == 16)
               radioButton16.Checked = true;
            else if (imageInfo.BitsPerPixel == 24)
               radioButton24.Checked = true;

            //
            // Initialize Photometric Interpretation
            //
            if(imageInfo.PhotometricInterpretation == DicomImagePhotometricInterpretationType.Monochrome2)
               radioButtonMonochrome.Checked = true;
            else if(imageInfo.PhotometricInterpretation == DicomImagePhotometricInterpretationType.PaletteColor)
               radioButtonPalette.Checked = true;
            else if(imageInfo.PhotometricInterpretation == DicomImagePhotometricInterpretationType.Rgb)
               radioButtonRGB.Checked = true;

            //
            // Initialize Compression
            //
            if (imageInfo.Compression == DicomImageCompressionType.None)
               radioButtonNone.Checked = true;
            else if (imageInfo.Compression == DicomImageCompressionType.JpegLossy)
               radioButtonJPEGLossy.Checked = true;
            else if (imageInfo.Compression == DicomImageCompressionType.JpegLossless)
               radioButtonJpegLossless.Checked = true;
            else if (imageInfo.Compression == DicomImageCompressionType.JpegLsLossy)
               radioButtonJpegLsLossy.Checked = true;
            else if (imageInfo.Compression == DicomImageCompressionType.JpegLsLossless)
               radioButtonJpegLsLossless.Checked = true;
            else if (imageInfo.Compression == DicomImageCompressionType.J2kLossy)
               radioButtonJ2kLossy.Checked = true;
            else if (imageInfo.Compression == DicomImageCompressionType.J2kLossless)
               radioButtonJ2kLossless.Checked = true;
            else if (imageInfo.Compression == DicomImageCompressionType.Rle)
               radioButtonRunLength.Checked = true;
            checkBoxUseExistingImage.Checked = true;
            buttonSelectNewImage.Enabled = false;
         }
         catch
         {
            radioButton24.Checked = true;
            radioButtonRGB.Checked = true;
            radioButtonNone.Checked = true;
            checkBoxUseExistingImage.Checked = false;
            buttonSelectNewImage.Enabled = true;
         }

         textBoxNewImageFileName.Text = "";
         _TransferSyntax = Utils.GetStringValue(ds, DemoDicomTags.TransferSyntaxUID);

         _UseNewImageFile = !checkBoxUseExistingImage.Checked;
      }

      private void buttonOriginal_Click(object sender, System.EventArgs e)
      {
         SetDefaults();
      }

      private void buttonSelectNewImage_Click(object sender, System.EventArgs e)
      {
         DICOMImageFileLoader loader = new DICOMImageFileLoader();
         using(RasterCodecs codecs = new RasterCodecs())
         {
            if(loader.Load(this, codecs, true) && (loader.Image != null))
            {
               _raster = loader.Image;
               textBoxNewImageFileName.Text = loader.FileName;
            }
         }
      }

      private void checkBoxUseExistingImage_CheckedChanged(object sender, System.EventArgs e)
      {
         buttonSelectNewImage.Enabled = !buttonSelectNewImage.Enabled;
         _UseNewImageFile = !_UseNewImageFile;
      }
   }

   public class DICOMImageFileLoader
   {
      public enum Filter
      {
         AllFiles
      }

      private struct LoadFormat
      {
         private string _name;
         private string _extensions;
         private Filter _filter;

         private LoadFormat(string name, string extensions, Filter filter)
         {
            _name = name;
            _extensions = extensions;
            _filter = filter;
         }

         public string Name
         {
            get { return _name; }
         }

         public string Extensions
         {
            get { return _extensions; }
         }

         public Filter Filter
         {
            get { return _filter; }
         }

         public override string ToString()
         {
            return string.Format("{0} ({1})|{2}", Name, Extensions, Extensions);
         }

         public static readonly LoadFormat[] Entries = new LoadFormat[]
         {
            new LoadFormat("All Files",      "*.*", Filter.AllFiles)
         };
      }

      public static int GetFilterIndex(Filter filter)
      {
         for (int i = 0; i < LoadFormat.Entries.Length; i++)
         {
            if (filter == LoadFormat.Entries[i].Filter)
               return i + 1;
         }

         return 1;
      }

      private static int _filterIndex = 1;
      private string _fileName;
      private RasterImage _image;
      private bool _loadOnlyOnePage = false;

      public DICOMImageFileLoader()
      {
      }

      public string FileName
      {
         get { return _fileName; }
      }

      public RasterImage Image
      {
         get { return _image; }
      }

      public bool LoadOnlyOnePage
      {
         get { return _loadOnlyOnePage; }
         set { _loadOnlyOnePage = value; }
      }

      public static int FilterIndex
      {
         get { return _filterIndex; }
         set { _filterIndex = value; }
      }

      public bool Load(IWin32Window owner, RasterCodecs codecs, bool autoLoad)
      {
         _fileName = string.Empty;
         _image = null;

         StringBuilder sb = new StringBuilder();
         for (int i = 0; i < LoadFormat.Entries.Length; i++)
         {
            sb.Append(LoadFormat.Entries[i].ToString());
            if (i != (LoadFormat.Entries.Length - 1))
               sb.Append("|");
         }

         OpenFileDialog ofd = new OpenFileDialog();
         ofd.Filter = sb.ToString();
         ofd.FilterIndex = _filterIndex;

         bool ok = false;

         try
         {
            if (ofd.ShowDialog(owner) == DialogResult.OK)
            {
               _fileName = ofd.FileName;
               ok = true;

               _filterIndex = ofd.FilterIndex;

               CodecsImageInfo info;

               using (WaitCursor wait = new WaitCursor())
                  info = codecs.GetInformation(ofd.FileName, true);
               if (autoLoad && ok)
                  using (WaitCursor wait = new WaitCursor())
                  {
                     _image = codecs.Load(ofd.FileName, 0, CodecsLoadByteOrder.BgrOrGray, 1, 1);
                  }
            }
            else
            {
               ok = true;
            }
         }
         catch
         {
            MessageBox.Show("Failed to load image.\nPlease note that, you can't use this dialog to load a DICOM file as an image.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ok = false;
         }
         return ok;
      }
   }
}
