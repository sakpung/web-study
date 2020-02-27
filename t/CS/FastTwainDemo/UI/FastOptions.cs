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
using Leadtools.Twain;
using Leadtools.Demos;
using Leadtools.Codecs;
using Leadtools.WinForms.CommonDialogs.File;

namespace CSFastTwainDemo
{
   /// <summary>
   /// Summary description for FastOptions.
   /// </summary>
   public class FastOptions : System.Windows.Forms.Form
   {
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.RadioButton _rdTransferFile;
      private System.Windows.Forms.RadioButton _rdTransferMemory;
      private System.Windows.Forms.RadioButton _rdTransferNative;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Label _lblBaseFileName;
      private System.Windows.Forms.TextBox _txtFileName;
      private System.Windows.Forms.Button _btnBrowse;
      private System.Windows.Forms.Label _lblOutputFileFormat;
      private System.Windows.Forms.ComboBox _cmbFileFormats;
      private System.Windows.Forms.Button _btnLEADFormats;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.CheckBox _cbUseBufferSize;
      private System.Windows.Forms.Label _lblBufferSize;
      private System.Windows.Forms.TextBox _txtBufferSize;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Button _btnCancel;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public FastOptions( )
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if(disposing)
         {
            if(components != null)
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
      private void InitializeComponent( )
      {
         System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FastOptions));
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._rdTransferNative = new System.Windows.Forms.RadioButton();
         this._rdTransferMemory = new System.Windows.Forms.RadioButton();
         this._rdTransferFile = new System.Windows.Forms.RadioButton();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this._btnLEADFormats = new System.Windows.Forms.Button();
         this._cmbFileFormats = new System.Windows.Forms.ComboBox();
         this._lblOutputFileFormat = new System.Windows.Forms.Label();
         this._btnBrowse = new System.Windows.Forms.Button();
         this._txtFileName = new System.Windows.Forms.TextBox();
         this._lblBaseFileName = new System.Windows.Forms.Label();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this._txtBufferSize = new System.Windows.Forms.TextBox();
         this._lblBufferSize = new System.Windows.Forms.Label();
         this._cbUseBufferSize = new System.Windows.Forms.CheckBox();
         this._btnOK = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._rdTransferNative);
         this.groupBox1.Controls.Add(this._rdTransferMemory);
         this.groupBox1.Controls.Add(this._rdTransferFile);
         this.groupBox1.Location = new System.Drawing.Point(8, 8);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(152, 192);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "&Transfer Mode ";
         // 
         // _rdTransferNative
         // 
         this._rdTransferNative.Location = new System.Drawing.Point(16, 136);
         this._rdTransferNative.Name = "_rdTransferNative";
         this._rdTransferNative.TabIndex = 3;
         this._rdTransferNative.Text = "&Native Mode";
         this._rdTransferNative.CheckedChanged += new System.EventHandler(this._rdTransferNative_CheckedChanged);
         // 
         // _rdTransferMemory
         // 
         this._rdTransferMemory.Location = new System.Drawing.Point(16, 84);
         this._rdTransferMemory.Name = "_rdTransferMemory";
         this._rdTransferMemory.TabIndex = 2;
         this._rdTransferMemory.Text = "Memor&y Mode";
         this._rdTransferMemory.CheckedChanged += new System.EventHandler(this._rdTransferMemory_CheckedChanged);
         // 
         // _rdTransferFile
         // 
         this._rdTransferFile.Location = new System.Drawing.Point(16, 32);
         this._rdTransferFile.Name = "_rdTransferFile";
         this._rdTransferFile.TabIndex = 1;
         this._rdTransferFile.Text = "&File Mode";
         this._rdTransferFile.CheckedChanged += new System.EventHandler(this._rdTransferFile_CheckedChanged);
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this._btnLEADFormats);
         this.groupBox2.Controls.Add(this._cmbFileFormats);
         this.groupBox2.Controls.Add(this._lblOutputFileFormat);
         this.groupBox2.Controls.Add(this._btnBrowse);
         this.groupBox2.Controls.Add(this._txtFileName);
         this.groupBox2.Controls.Add(this._lblBaseFileName);
         this.groupBox2.Location = new System.Drawing.Point(168, 8);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(328, 112);
         this.groupBox2.TabIndex = 4;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "&General Options ";
         // 
         // _btnLEADFormats
         // 
         this._btnLEADFormats.Location = new System.Drawing.Point(120, 80);
         this._btnLEADFormats.Name = "_btnLEADFormats";
         this._btnLEADFormats.Size = new System.Drawing.Size(200, 23);
         this._btnLEADFormats.TabIndex = 10;
         this._btnLEADFormats.Text = "LEADTOOLS Formats";
         this._btnLEADFormats.Click += new System.EventHandler(this._btnLEADFormats_Click);
         // 
         // _cmbFileFormats
         // 
         this._cmbFileFormats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbFileFormats.Location = new System.Drawing.Point(120, 48);
         this._cmbFileFormats.Name = "_cmbFileFormats";
         this._cmbFileFormats.Size = new System.Drawing.Size(200, 21);
         this._cmbFileFormats.TabIndex = 9;
         // 
         // _lblOutputFileFormat
         // 
         this._lblOutputFileFormat.Location = new System.Drawing.Point(16, 48);
         this._lblOutputFileFormat.Name = "_lblOutputFileFormat";
         this._lblOutputFileFormat.Size = new System.Drawing.Size(104, 24);
         this._lblOutputFileFormat.TabIndex = 8;
         this._lblOutputFileFormat.Text = "Output File F&ormat:";
         this._lblOutputFileFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // _btnBrowse
         // 
         this._btnBrowse.Location = new System.Drawing.Point(288, 16);
         this._btnBrowse.Name = "_btnBrowse";
         this._btnBrowse.Size = new System.Drawing.Size(32, 23);
         this._btnBrowse.TabIndex = 7;
         this._btnBrowse.Text = "...";
         this._btnBrowse.Click += new System.EventHandler(this._btnBrowse_Click);
         // 
         // _txtFileName
         // 
         this._txtFileName.Location = new System.Drawing.Point(120, 16);
         this._txtFileName.Name = "_txtFileName";
         this._txtFileName.ReadOnly = true;
         this._txtFileName.Size = new System.Drawing.Size(160, 20);
         this._txtFileName.TabIndex = 6;
         this._txtFileName.Text = "";
         this._txtFileName.TextChanged += new System.EventHandler(this._txtFileName_TextChanged);
         // 
         // _lblBaseFileName
         // 
         this._lblBaseFileName.Location = new System.Drawing.Point(32, 16);
         this._lblBaseFileName.Name = "_lblBaseFileName";
         this._lblBaseFileName.Size = new System.Drawing.Size(88, 24);
         this._lblBaseFileName.TabIndex = 5;
         this._lblBaseFileName.Text = "Base File N&ame:";
         this._lblBaseFileName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this._txtBufferSize);
         this.groupBox3.Controls.Add(this._lblBufferSize);
         this.groupBox3.Controls.Add(this._cbUseBufferSize);
         this.groupBox3.Location = new System.Drawing.Point(168, 120);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(328, 80);
         this.groupBox3.TabIndex = 11;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Transfer &Options";
         // 
         // _txtBufferSize
         // 
         this._txtBufferSize.Location = new System.Drawing.Point(128, 48);
         this._txtBufferSize.Name = "_txtBufferSize";
         this._txtBufferSize.Size = new System.Drawing.Size(192, 20);
         this._txtBufferSize.TabIndex = 14;
         this._txtBufferSize.Text = "";
         this._txtBufferSize.TextChanged += new System.EventHandler(this._txtBufferSize_TextChanged);
         // 
         // _lblBufferSize
         // 
         this._lblBufferSize.Location = new System.Drawing.Point(8, 48);
         this._lblBufferSize.Name = "_lblBufferSize";
         this._lblBufferSize.Size = new System.Drawing.Size(112, 24);
         this._lblBufferSize.TabIndex = 13;
         this._lblBufferSize.Text = "Custom &Buffer Size:";
         this._lblBufferSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // _cbUseBufferSize
         // 
         this._cbUseBufferSize.Location = new System.Drawing.Point(16, 24);
         this._cbUseBufferSize.Name = "_cbUseBufferSize";
         this._cbUseBufferSize.Size = new System.Drawing.Size(152, 16);
         this._cbUseBufferSize.TabIndex = 12;
         this._cbUseBufferSize.Text = "Use &Custom Buffer Size";
         this._cbUseBufferSize.CheckedChanged += new System.EventHandler(this._cbUseBufferSize_CheckedChanged);
         // 
         // _btnOK
         // 
         this._btnOK.Location = new System.Drawing.Point(504, 77);
         this._btnOK.Name = "_btnOK";
         this._btnOK.TabIndex = 15;
         this._btnOK.Text = "OK";
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(504, 109);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.TabIndex = 16;
         this._btnCancel.Text = "Cancel";
         // 
         // FastOptions
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(586, 208);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this.groupBox3);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FastOptions";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Fast Twain Options...";
         this.Load += new System.EventHandler(this.FastOptions_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox2.ResumeLayout(false);
         this.groupBox3.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion
      TwainTransferMode _transferMode;
      int _allBPPCount;
      int[] _bitsPerPixel;
      bool _formInitialized;
      RasterImageFormat _imageLEADFormat;
      int _nativeBPP;
      int[] _memoryFormatBPP;
      bool[] _memoryFormatMulti;
      RasterImageFormat[] _format;
      int _bufferSize;
      int _oldBufferSize;
      RasterCodecs _codecs;
      public TwainSession _session;

      private void FastOptions_Load(object sender, System.EventArgs e)
      {
         _memoryFormatBPP = new int[30];
         _memoryFormatMulti = new bool[30];
         _transferMode = TwainTransferMode.Native;

         _rdTransferFile.Enabled = false;
         _rdTransferMemory.Enabled = false;
         _rdTransferNative.Enabled = false;
         _txtFileName.Enabled = false;
         _btnBrowse.Enabled = false;
         _cmbFileFormats.Enabled = false;
         _btnLEADFormats.Enabled = false;
         _cbUseBufferSize.Enabled = false;
         _txtBufferSize.Enabled = false;

         if (MainForm.TwainAvailable)
            CheckTransferMode(sender, e);

         _btnOK.Enabled = false;

         _codecs = new RasterCodecs();
      }

      private void _cbUseBufferSize_CheckedChanged(object sender, System.EventArgs e)
      {
         if(!_formInitialized)
         {
            if(_cbUseBufferSize.Checked)
               _cbUseBufferSize.Checked = true;
            else
               _cbUseBufferSize.Checked = false;
         }

         _txtBufferSize.Enabled = _cbUseBufferSize.Checked;
      }

      private void _txtBufferSize_TextChanged(object sender, System.EventArgs e)
      {
         try
         {
            _bufferSize = Convert.ToInt32(_txtBufferSize.Text);
            _oldBufferSize = _bufferSize;

            _btnOK.Enabled = (_txtFileName.Text != "" && _txtBufferSize.Text != "");
         }
         catch(Exception ex)
         {
            _bufferSize = _oldBufferSize;
            _txtBufferSize.Text = Convert.ToString(_bufferSize);
            Messager.ShowError(this, ex);
         }
      }

      private string GetFormatFilter()
      {
         int selectedFormatIndex = _cmbFileFormats.SelectedIndex;
         RasterImageFormat myFormat = _format[selectedFormatIndex];

         string formatFilter = "All files (*.*)|*.*"; ;

         switch(myFormat)
         {
            case RasterImageFormat.Tif:
            case RasterImageFormat.FaxG4:
            case RasterImageFormat.FaxG32Dim:
            case RasterImageFormat.FaxG31Dim:
            case RasterImageFormat.FaxG31DimNoEol:
               formatFilter = "Tif files (*.tif)|*.tif";
               break;
            case RasterImageFormat.Bmp:
               formatFilter = "Bmp files (*.bmp)|*.bmp";
               break;
            case RasterImageFormat.Xbm:
               formatFilter = "Xbm files (*.xbm)|*.xbm";
               break;
            case RasterImageFormat.Jpeg:
            case RasterImageFormat.Jpeg411:
            case RasterImageFormat.Jpeg422:
               formatFilter = "Jpeg files (*.jpg)|*.jpg";
               break;
            case RasterImageFormat.Png:
               formatFilter = "Png files (*.png)|*.png";
               break;
            case RasterImageFormat.Exif:
               formatFilter = "Exit files (*.exif)|*.exif";
               break;
            case RasterImageFormat.Jbig:
               formatFilter = "Jbig files (*.jbg)|*.jbg";
               break;
         }

         return formatFilter;
      }

      private void _btnBrowse_Click(object sender, System.EventArgs e)
      {
         using(SaveFileDialog saveDialog = new SaveFileDialog())
         {
            saveDialog.Filter = GetFormatFilter();
            saveDialog.FilterIndex = 0;

            if(saveDialog.ShowDialog(this) == DialogResult.OK)
               _txtFileName.Text = saveDialog.FileName;
         }
      }

      private void _rdTransferFile_CheckedChanged(object sender, System.EventArgs e)
      {
         int format;
         string fileName;

         _transferMode = TwainTransferMode.File;
         _cmbFileFormats.Enabled = true;
         _btnBrowse.Enabled = true;

         fileName = this._txtFileName.Text;
         _btnOK.Enabled = (fileName != "");

         // disable other options
         _cbUseBufferSize.Enabled = false;
         _txtBufferSize.Enabled = false;
         _btnLEADFormats.Enabled = false;

         try
         {
            TwainCapability twnCap = _session.GetCapability(TwainCapabilityType.ImageImageFileFormat, TwainGetCapabilityMode.GetValues);

            switch(twnCap.Information.ContainerType)
            {
               case TwainContainerType.Enumeration:
                  {
                     _cmbFileFormats.Items.Clear();
                     int count = twnCap.EnumerationCapability.Count;
                     _format = new RasterImageFormat[count];
                     for(int i = 0; i < count; i++)
                     {
                        if(twnCap.EnumerationCapability.ItemType == TwainItemType.Uint16)
                        {
                           format = Convert.ToUInt16(twnCap.EnumerationCapability.GetValue(i));
                           AddScannerFormats(format, i);
                        }
                     }
                     break;
                  }
               case TwainContainerType.OneValue:
                  {
                     _cmbFileFormats.Items.Clear();
                     if(twnCap.OneValueCapability.ItemType == TwainItemType.Uint16)
                     {
                        _format = new RasterImageFormat[1];
                        format = Convert.ToUInt16(twnCap.OneValueCapability.Value);
                        AddScannerFormats(format, 0);
                     }
                     break;
                  }
            }

            _cmbFileFormats.SelectedIndex = 0;
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void _rdTransferMemory_CheckedChanged(object sender, System.EventArgs e)
      {
         string customBuffer;
         _transferMode = TwainTransferMode.Buffer;

         _cbUseBufferSize.Enabled = true;
         _txtBufferSize.Enabled = true;
         _cmbFileFormats.Enabled = true;
         _btnBrowse.Enabled = true;

         _formInitialized = true;
         _cbUseBufferSize_CheckedChanged(this, e);
         _formInitialized = false;

         customBuffer = " ";
         if(_cbUseBufferSize.Checked)
            customBuffer = _txtBufferSize.Text;

         if(customBuffer == "" || _txtFileName.Text == "")
            _btnOK.Enabled = false;
         else
            _btnOK.Enabled = true;

         FillMemoryFormats();

         // disable other options
         this._btnLEADFormats.Enabled = false;
      }

      private void _rdTransferNative_CheckedChanged(object sender, System.EventArgs e)
      {
         string fileName;
         _transferMode = TwainTransferMode.Native;

         _btnLEADFormats.Enabled = true;

         fileName = _txtFileName.Text;
         _btnOK.Enabled = (fileName != "");

         // disable other options
         _cmbFileFormats.Enabled = false;
         _cbUseBufferSize.Enabled = false;

         if(_txtBufferSize.Text == "")
            _txtBufferSize.Text = "0";

         _txtBufferSize.Enabled = false;
         _btnBrowse.Enabled = false;
      }

      private void AddScannerFormats(int format, int index)
      {
         TwainCapabilityValue formatValue = (TwainCapabilityValue)format;
         switch(formatValue)
         {
            case TwainCapabilityValue.FileFormatTiff:
               _cmbFileFormats.Items.Insert(index, "TIFF");
               _format[index] = RasterImageFormat.Tif;
               break;
            case TwainCapabilityValue.FileFormatBmp:
               _cmbFileFormats.Items.Insert(index, "BMP");
               _format[index] = RasterImageFormat.Bmp;
               break;
            case TwainCapabilityValue.FileFormatXbm:
               _cmbFileFormats.Items.Insert(index, "XBM");
               _format[index] = RasterImageFormat.Xbm;
               break;
            case TwainCapabilityValue.FileFormatJfif:
               _cmbFileFormats.Items.Insert(index, "JFIF");
               _format[index] = RasterImageFormat.Jpeg;
               break;
            case TwainCapabilityValue.FileFormatTiffMulti:
               _cmbFileFormats.Items.Insert(index, "TIFF MULTI");
               _format[index] = RasterImageFormat.Tif;
               break;
            case TwainCapabilityValue.FileFormatPng:
               _cmbFileFormats.Items.Insert(index, "PNG");
               _format[index] = RasterImageFormat.Png;
               break;
            case TwainCapabilityValue.FileFormatExif:
               _cmbFileFormats.Items.Insert(index, "EXIF");
               _format[index] = RasterImageFormat.Exif;
               break;
         }
      }

      private bool GetScannerBPP( )
      {
         TwainCapability twnCap;
         _allBPPCount = 0;

         try
         {
            twnCap = _session.GetCapability(TwainCapabilityType.ImageBitDepth, TwainGetCapabilityMode.GetCurrent);

            switch(twnCap.Information.ContainerType)
            {
               case TwainContainerType.OneValue:
                  {
                     _allBPPCount = 1;
                     _bitsPerPixel = new int[_allBPPCount];
                     if(twnCap.OneValueCapability.ItemType == TwainItemType.Uint16)
                        _bitsPerPixel[0] = Convert.ToUInt16(twnCap.OneValueCapability.Value);
                     break;
                  }
               case TwainContainerType.Enumeration:
                  {
                     int count = twnCap.EnumerationCapability.Count;
                     _allBPPCount = count;
                     _bitsPerPixel = new int[_allBPPCount];
                     for(int i = 0; i < _allBPPCount; i++)
                     {
                        if(twnCap.EnumerationCapability.ItemType == TwainItemType.Uint16)
                           _bitsPerPixel[i] = Convert.ToUInt16(twnCap.EnumerationCapability.GetValue(i));
                     }
                     break;
                  }
            }
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
            return false;
         }

         return (_allBPPCount > 0);
      }

      private void FillMemoryFormats( )
      {
         int k = 0;
         if(GetScannerBPP() == false)
         {
            _bitsPerPixel = new int[1];

            _allBPPCount = 1;
            _bitsPerPixel[0] = 1;
         }

         _format = new RasterImageFormat[30];
         _cmbFileFormats.Items.Clear();
         for(int i = 0; i < _allBPPCount; i++)
         {
            switch(_bitsPerPixel[i])
            {
               case 1:
                  // G4
                  _cmbFileFormats.Items.Add("Multipage CCITT G4 TIFF");
                  _format[k] = RasterImageFormat.FaxG4;
                  _memoryFormatBPP[k] = 1;
                  _memoryFormatMulti[k] = true;
                  k++;

                  _cmbFileFormats.Items.Add("Singlepage CCITT G4 TIFF");
                  _format[k] = RasterImageFormat.FaxG4;
                  _memoryFormatBPP[k] = 1;
                  _memoryFormatMulti[k] = false;
                  k++;

                  // G32D
                  _cmbFileFormats.Items.Add("Multipage CCITT G32D TIFF");
                  _format[k] = RasterImageFormat.FaxG32Dim;
                  _memoryFormatBPP[k] = 1;
                  _memoryFormatMulti[k] = true;
                  k++;

                  _cmbFileFormats.Items.Add("Singlepage CCITT G32D TIFF");
                  _format[k] = RasterImageFormat.FaxG32Dim;
                  _memoryFormatBPP[k] = 1;
                  _memoryFormatMulti[k] = false;
                  k++;

                  // G31D
                  _cmbFileFormats.Items.Add("Multipage CCITT G31D TIFF");
                  _format[k] = RasterImageFormat.FaxG31Dim;
                  _memoryFormatBPP[k] = 1;
                  _memoryFormatMulti[k] = true;
                  k++;

                  _cmbFileFormats.Items.Add("Singlepage CCITT G31D TIFF");
                  _format[k] = RasterImageFormat.FaxG31Dim;
                  _memoryFormatBPP[k] = 1;
                  _memoryFormatMulti[k] = false;
                  k++;

                  // G31D NOEOL
                  if(CheckG31DNOEOLCompression())
                  {
                     _cmbFileFormats.Items.Add("Singlepage CCITT G31D NOEOL (FAX)");
                     _format[k] = RasterImageFormat.FaxG31DimNoEol;
                     _memoryFormatBPP[k] = 1;
                     _memoryFormatMulti[k] = false;
                     k++;
                  }

                  // JBIG
                  _cmbFileFormats.Items.Add("Singlepage JBIG");
                  _format[k] = RasterImageFormat.Jbig;
                  _memoryFormatBPP[k] = 1;
                  _memoryFormatMulti[k] = false;
                  k++;

                  // TIF
                  _cmbFileFormats.Items.Add("Multipage Uncompressed 1-bit TIFF");
                  _format[k] = RasterImageFormat.Tif;
                  _memoryFormatBPP[k] = 1;
                  _memoryFormatMulti[k] = true;
                  k++;

                  _cmbFileFormats.Items.Add("Singlepage Uncompressed 1-bit TIFF");
                  _format[k] = RasterImageFormat.Tif;
                  _memoryFormatBPP[k] = 1;
                  _memoryFormatMulti[k] = false;
                  k++;
                  _cmbFileFormats.SelectedIndex = 0;
                  break;
               case 24:
                  // LEAD1JFIF
                  _cmbFileFormats.Items.Add("Singlepage JPEG Color 4:1:1");
                  _format[k] = RasterImageFormat.Jpeg411;
                  _memoryFormatBPP[k] = 24;
                  _memoryFormatMulti[k] = false;
                  k++;

                  // LEAD2JFIF
                  _cmbFileFormats.Items.Add("Singlepage JPEG Color 4:2:2");
                  _format[k] = RasterImageFormat.Jpeg422;
                  _memoryFormatBPP[k] = 24;
                  _memoryFormatMulti[k] = false;
                  k++;

                  // JPEG
                  _cmbFileFormats.Items.Add("Singlepage JPEG Color 4:4:4");
                  _format[k] = RasterImageFormat.Jpeg;
                  _memoryFormatBPP[k] = 24;
                  _memoryFormatMulti[k] = false;
                  k++;

                  // TIF
                  _cmbFileFormats.Items.Add("Multipage Uncompressed 24-bit TIFF");
                  _format[k] = RasterImageFormat.Tif;
                  _memoryFormatBPP[k] = 24;
                  _memoryFormatMulti[k] = true;
                  k++;

                  _cmbFileFormats.Items.Add("Single Uncompressed 24-bit TIFF");
                  _format[k] = RasterImageFormat.Tif;
                  _memoryFormatBPP[k] = 24;
                  _memoryFormatMulti[k] = false;
                  k++;
                  _cmbFileFormats.SelectedIndex = 0;
                  break;
               case 8:
                  // JPEG
                  _cmbFileFormats.Items.Add("Singlepage JPEG Grayscale 8-bit");
                  _format[k] = RasterImageFormat.Jpeg;
                  _memoryFormatBPP[k] = 8;
                  _memoryFormatMulti[k] = false;
                  k++;

                  // TIF
                  _cmbFileFormats.Items.Add("Multipage Uncompressed 8-bit TIFF");
                  _format[k] = RasterImageFormat.Tif;
                  _memoryFormatBPP[k] = 8;
                  _memoryFormatMulti[k] = true;
                  k++;

                  _cmbFileFormats.Items.Add("Single Uncompressed 8-bit TIFF");
                  _format[k] = RasterImageFormat.Tif;
                  _memoryFormatBPP[k] = 8;
                  _memoryFormatMulti[k] = false;
                  k++;
                  _cmbFileFormats.SelectedIndex = 0;
                  break;
               case 2:
               case 4:
                  // TIF
                  _cmbFileFormats.Items.Add("Multipage Uncompressed 4-bit TIFF");
                  _format[k] = RasterImageFormat.Tif;
                  _memoryFormatBPP[k] = 4;
                  _memoryFormatMulti[k] = true;
                  k++;

                  _cmbFileFormats.Items.Add("Single Uncompressed 4-bit TIFF");
                  _format[k] = RasterImageFormat.Tif;
                  _memoryFormatBPP[k] = 4;
                  _memoryFormatMulti[k] = false;
                  k++;
                  _cmbFileFormats.SelectedIndex = 0;
                  break;
               case 16:
                  // JPEG
                  _cmbFileFormats.Items.Add("Singlepage JPEG Grayscale 16-bit");
                  _format[k] = RasterImageFormat.Jpeg;
                  _memoryFormatBPP[k] = 16;
                  _memoryFormatMulti[k] = false;
                  k++;

                  // TIF
                  _cmbFileFormats.Items.Add("Multipage Uncompressed 16-bit TIFF");
                  _format[k] = RasterImageFormat.Tif;
                  _memoryFormatBPP[k] = 16;
                  _memoryFormatMulti[k] = true;
                  k++;

                  _cmbFileFormats.Items.Add("Single Uncompressed 16-bit TIFF");
                  _format[k] = RasterImageFormat.Tif;
                  _memoryFormatBPP[k] = 16;
                  _memoryFormatMulti[k] = false;
                  k++;
                  _cmbFileFormats.SelectedIndex = 0;
                  break;
               case 32:
                  // TIF
                  _cmbFileFormats.Items.Add("Multipage Uncompressed 32-bit TIFF");
                  _format[k] = RasterImageFormat.Tif;
                  _memoryFormatBPP[k] = 32;
                  _memoryFormatMulti[k] = true;
                  k++;

                  _cmbFileFormats.Items.Add("Single Uncompressed 32-bit TIFF");
                  _format[k] = RasterImageFormat.Tif;
                  _memoryFormatBPP[k] = 32;
                  _memoryFormatMulti[k] = false;
                  k++;
                  _cmbFileFormats.SelectedIndex = 0;
                  break;
               case 48:
                  // TIF
                  _cmbFileFormats.Items.Add("Multipage Uncompressed 48-bit TIFF");
                  _format[k] = RasterImageFormat.Tif;
                  _memoryFormatBPP[k] = 48;
                  _memoryFormatMulti[k] = true;
                  k++;

                  _cmbFileFormats.Items.Add("Single Uncompressed 48-bit TIFF");
                  _format[k] = RasterImageFormat.Tif;
                  _memoryFormatBPP[k] = 48;
                  _memoryFormatMulti[k] = false;
                  k++;
                  _cmbFileFormats.SelectedIndex = 0;
                  break;
               case 64:
                  // TIF
                  _cmbFileFormats.Items.Add("Multipage Uncompressed 64-bit TIFF");
                  _format[k] = RasterImageFormat.Tif;
                  _memoryFormatBPP[k] = 64;
                  _memoryFormatMulti[k] = true;
                  k++;

                  _cmbFileFormats.Items.Add("Single Uncompressed 64-bit TIFF");
                  _format[k] = RasterImageFormat.Tif;
                  _memoryFormatBPP[k] = 64;
                  _memoryFormatMulti[k] = false;
                  k++;
                  _cmbFileFormats.SelectedIndex = 0;
                  break;
            }
         }
      }

      private bool CheckG31DNOEOLCompression( )
      {
         int compression;
         bool compressionExit = false;
         TwainCapability twnCap;

         try
         {
            twnCap = _session.GetCapability(TwainCapabilityType.ImageCompression, TwainGetCapabilityMode.GetValues);

            switch(twnCap.Information.ContainerType)
            {
               case TwainContainerType.OneValue:
                  {
                     if(twnCap.OneValueCapability.ItemType == TwainItemType.Uint16)
                     {
                        compression = Convert.ToUInt16(twnCap.OneValueCapability.Value);

                        if(compression == (int)TwainCapabilityValue.CompressionGroup31D)
                           compressionExit = true;
                     }
                     break;
                  }
               case TwainContainerType.Enumeration:
                  {
                     int count = twnCap.EnumerationCapability.Count;
                     for(int i = 0; i < count; i++)
                     {
                        if(twnCap.EnumerationCapability.ItemType == TwainItemType.Uint16)
                        {
                           compression = Convert.ToUInt16(twnCap.EnumerationCapability.GetValue(i));

                           if(compression == (int)TwainCapabilityValue.CompressionGroup31D)
                           {
                              compressionExit = true;
                              break;
                           }
                        }
                     }
                     break;
                  }
            }
         }
         catch
         {
            return false;
         }

         return compressionExit;
      }

      private void CheckTransferMode(object sender, System.EventArgs e)
      {
         bool fileMode = false, memoryMode = false, nativeMode = false;
         int xfer = 0;
         TwainCapability twnCap = null;

         try
         {
            twnCap = _session.GetCapability(TwainCapabilityType.ImageTransferMechanism, TwainGetCapabilityMode.GetValues);

            switch(twnCap.Information.ContainerType)
            {
               case TwainContainerType.OneValue:
                  {
                     if(twnCap.OneValueCapability.ItemType == TwainItemType.Uint16)
                     {
                        xfer = Convert.ToUInt16(twnCap.OneValueCapability.Value);

                        if(xfer == (int)TwainCapabilityValue.TransferMechanismFile)
                           fileMode = true;
                        if(xfer == (int)TwainCapabilityValue.TransferMechanismMemory)
                           memoryMode = true;
                        if(xfer == (int)TwainCapabilityValue.TransferMechanismNative)
                           nativeMode = true;
                     }
                     break;
                  }
               case TwainContainerType.Enumeration:
                  {
                     int count = twnCap.EnumerationCapability.Count;
                     for(int i = 0; i < count; i++)
                     {
                        if(twnCap.EnumerationCapability.ItemType == TwainItemType.Uint16)
                        {
                           xfer = Convert.ToUInt16(twnCap.EnumerationCapability.GetValue(i));

                           if(xfer == (int)TwainCapabilityValue.TransferMechanismFile)
                              fileMode = true;
                           if(xfer == (int)TwainCapabilityValue.TransferMechanismMemory)
                              memoryMode = true;
                           if(xfer == (int)TwainCapabilityValue.TransferMechanismNative)
                              nativeMode = true;
                        }
                     }

                     break;
                  }
            }
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
            return;
         }

         _rdTransferFile.Enabled = fileMode;
         _rdTransferMemory.Enabled = memoryMode;
         _rdTransferNative.Enabled = nativeMode;

         if(memoryMode)
         {
            _rdTransferMemory.Checked = true;
            _rdTransferMemory_CheckedChanged(sender, e);
         }

         if(fileMode)
         {
            _rdTransferFile.Checked = true;
            _rdTransferFile_CheckedChanged(sender, e);
         }

         if(nativeMode)
         {
            _rdTransferNative.Checked = true;
            _rdTransferNative_CheckedChanged(sender, e);
         }

         _txtFileName_TextChanged(sender, e);
      }

      private void _btnLEADFormats_Click(object sender, System.EventArgs e)
      {
         RasterSaveDialog saveDlg = new RasterSaveDialog(_codecs);

         saveDlg.EnableSizing = true;
         saveDlg.FileFormatsList = new RasterSaveDialogFileFormatsList(RasterDialogFileFormatDataContent.Default);

         if(saveDlg.ShowDialog(this) == DialogResult.OK)
         {
            _txtFileName.Text = saveDlg.FileName;
            _nativeBPP = saveDlg.BitsPerPixel;
            _imageLEADFormat = saveDlg.Format;
         }

         DialogResult = DialogResult.None;
      }

      private void _btnOK_Click(object sender, System.EventArgs e)
      {
         RasterImageFormat format = RasterImageFormat.Tif;
         string baseFileName = "";
         bool multiPage = true;
         int bpp = 1;

         switch(_transferMode)
         {
            case TwainTransferMode.File:
               format = _format[_cmbFileFormats.SelectedIndex];
               if (!_cmbFileFormats.Text.Equals("TIFF MULTI"))
                  multiPage = false;
               break;
            case TwainTransferMode.Buffer:
               if(_cbUseBufferSize.Checked && _txtBufferSize.Text == "0")
               {
                  Messager.ShowError(this, "Please, enter valid custom buffer size");
                  return;
               }

               format = _format[_cmbFileFormats.SelectedIndex];
               bpp = _memoryFormatBPP[_cmbFileFormats.SelectedIndex];
               multiPage = _memoryFormatMulti[_cmbFileFormats.SelectedIndex];
               break;
            case TwainTransferMode.Native:
               format = _imageLEADFormat;
               bpp = _nativeBPP;
               break;
         }

         Hide();
         try
         {
            _session.EnableAcquireMultiPageEvent = false;
            baseFileName = _txtFileName.Text;

            _session.AcquireFast(baseFileName,
                                 TwainFastUserInterfaceFlags.Show | TwainFastUserInterfaceFlags.Modal,
                                 _transferMode,
                                 format,
                                 bpp,
                                 multiPage,
                                 _bufferSize,
                                 !_cbUseBufferSize.Checked);
            Messager.ShowInformation(this, "Process Completed");
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }

         DialogResult = DialogResult.OK;
      }

      private void _txtFileName_TextChanged(object sender, System.EventArgs e)
      {
         bool useBufferSize = true;
         if(this._cbUseBufferSize.Checked)
            useBufferSize = (_txtBufferSize.Text != "");

         _btnOK.Enabled = (_txtFileName.Text != "" && useBufferSize);
      }
   }
}
