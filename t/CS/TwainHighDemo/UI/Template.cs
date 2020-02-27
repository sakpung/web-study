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

namespace TwainHighDemo
{
   /// <summary>
   /// Summary description for Template.
   /// </summary>
   public class Template : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Label _lblYRes;
      private System.Windows.Forms.Label _lblXRes;
      private System.Windows.Forms.TextBox _txtFrameBottom;
      private System.Windows.Forms.TextBox _txtFrameRight;
      private System.Windows.Forms.TextBox _txtFrameTop;
      private System.Windows.Forms.TextBox _txtFrameLeft;
      private System.Windows.Forms.Label _lblFrameBottom;
      private System.Windows.Forms.Label _lblFrameRight;
      private System.Windows.Forms.Label _lblFrameTop;
      private System.Windows.Forms.Label _lblFrameLeft;
      private System.Windows.Forms.ComboBox _cmbUnit;
      private System.Windows.Forms.Label _lblUnit;
      private System.Windows.Forms.RadioButton _rdNative;
      private System.Windows.Forms.RadioButton _rdMemory;
      private System.Windows.Forms.RadioButton _rdFile;
      private System.Windows.Forms.Label _lblFileName;
      private System.Windows.Forms.TextBox _txtFileName;
      private System.Windows.Forms.Button _btnBrowse;
      private System.Windows.Forms.Label _lblFormat;
      private System.Windows.Forms.ComboBox _cmbFileFormat;
      private System.Windows.Forms.Label _lblCompression;
      private System.Windows.Forms.Label _lblPixelType;
      private System.Windows.Forms.ComboBox _cmbPixelType;
      private System.Windows.Forms.Label _lblOrientation;
      private System.Windows.Forms.ComboBox _cmbOrientation;
      private System.Windows.Forms.Label _lblHalftone;
      private System.Windows.Forms.ComboBox _cmbHalftone;
      private System.Windows.Forms.Label _lblContrast;
      private System.Windows.Forms.ComboBox _cmbContrast;
      private System.Windows.Forms.Label _lblBrightness;
      private System.Windows.Forms.ComboBox _cmbBrightness;
      private System.Windows.Forms.Label _lblHighlight;
      private System.Windows.Forms.ComboBox _cmbHighlight;
      private System.Windows.Forms.Button _btnLoad;
      private System.Windows.Forms.Button _btnSave;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.GroupBox _gbImageFrame;
      private System.Windows.Forms.GroupBox _gbTransferMode;
      private System.Windows.Forms.GroupBox _gbFileOptions;
      private System.Windows.Forms.GroupBox _gbMemoryOptions;
      private System.Windows.Forms.GroupBox _gbImgeEfx;
      private System.Windows.Forms.ComboBox _cmbXRes;
      private System.Windows.Forms.ComboBox _cmbYRes;
      private System.Windows.Forms.ComboBox _cmbCompression;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public Template( )
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
         System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Template));
         this._gbImageFrame = new System.Windows.Forms.GroupBox();
         this._cmbYRes = new System.Windows.Forms.ComboBox();
         this._cmbXRes = new System.Windows.Forms.ComboBox();
         this._lblYRes = new System.Windows.Forms.Label();
         this._lblXRes = new System.Windows.Forms.Label();
         this._txtFrameBottom = new System.Windows.Forms.TextBox();
         this._txtFrameRight = new System.Windows.Forms.TextBox();
         this._txtFrameTop = new System.Windows.Forms.TextBox();
         this._txtFrameLeft = new System.Windows.Forms.TextBox();
         this._lblFrameBottom = new System.Windows.Forms.Label();
         this._lblFrameRight = new System.Windows.Forms.Label();
         this._lblFrameTop = new System.Windows.Forms.Label();
         this._lblFrameLeft = new System.Windows.Forms.Label();
         this._cmbUnit = new System.Windows.Forms.ComboBox();
         this._lblUnit = new System.Windows.Forms.Label();
         this._gbTransferMode = new System.Windows.Forms.GroupBox();
         this._rdNative = new System.Windows.Forms.RadioButton();
         this._rdMemory = new System.Windows.Forms.RadioButton();
         this._rdFile = new System.Windows.Forms.RadioButton();
         this._gbFileOptions = new System.Windows.Forms.GroupBox();
         this._cmbFileFormat = new System.Windows.Forms.ComboBox();
         this._lblFormat = new System.Windows.Forms.Label();
         this._btnBrowse = new System.Windows.Forms.Button();
         this._txtFileName = new System.Windows.Forms.TextBox();
         this._lblFileName = new System.Windows.Forms.Label();
         this._gbMemoryOptions = new System.Windows.Forms.GroupBox();
         this._cmbCompression = new System.Windows.Forms.ComboBox();
         this._lblCompression = new System.Windows.Forms.Label();
         this._gbImgeEfx = new System.Windows.Forms.GroupBox();
         this._cmbHighlight = new System.Windows.Forms.ComboBox();
         this._lblHighlight = new System.Windows.Forms.Label();
         this._cmbBrightness = new System.Windows.Forms.ComboBox();
         this._lblBrightness = new System.Windows.Forms.Label();
         this._cmbContrast = new System.Windows.Forms.ComboBox();
         this._lblContrast = new System.Windows.Forms.Label();
         this._cmbHalftone = new System.Windows.Forms.ComboBox();
         this._lblHalftone = new System.Windows.Forms.Label();
         this._cmbOrientation = new System.Windows.Forms.ComboBox();
         this._lblOrientation = new System.Windows.Forms.Label();
         this._cmbPixelType = new System.Windows.Forms.ComboBox();
         this._lblPixelType = new System.Windows.Forms.Label();
         this._btnLoad = new System.Windows.Forms.Button();
         this._btnSave = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._gbImageFrame.SuspendLayout();
         this._gbTransferMode.SuspendLayout();
         this._gbFileOptions.SuspendLayout();
         this._gbMemoryOptions.SuspendLayout();
         this._gbImgeEfx.SuspendLayout();
         this.SuspendLayout();
         // 
         // _gbImageFrame
         // 
         this._gbImageFrame.Controls.Add(this._cmbYRes);
         this._gbImageFrame.Controls.Add(this._cmbXRes);
         this._gbImageFrame.Controls.Add(this._lblYRes);
         this._gbImageFrame.Controls.Add(this._lblXRes);
         this._gbImageFrame.Controls.Add(this._txtFrameBottom);
         this._gbImageFrame.Controls.Add(this._txtFrameRight);
         this._gbImageFrame.Controls.Add(this._txtFrameTop);
         this._gbImageFrame.Controls.Add(this._txtFrameLeft);
         this._gbImageFrame.Controls.Add(this._lblFrameBottom);
         this._gbImageFrame.Controls.Add(this._lblFrameRight);
         this._gbImageFrame.Controls.Add(this._lblFrameTop);
         this._gbImageFrame.Controls.Add(this._lblFrameLeft);
         this._gbImageFrame.Controls.Add(this._cmbUnit);
         this._gbImageFrame.Controls.Add(this._lblUnit);
         this._gbImageFrame.Location = new System.Drawing.Point(8, 8);
         this._gbImageFrame.Name = "_gbImageFrame";
         this._gbImageFrame.Size = new System.Drawing.Size(184, 240);
         this._gbImageFrame.TabIndex = 0;
         this._gbImageFrame.TabStop = false;
         this._gbImageFrame.Text = "Image Frame";
         // 
         // _cmbYRes
         // 
         this._cmbYRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbYRes.Location = new System.Drawing.Point(72, 208);
         this._cmbYRes.Name = "_cmbYRes";
         this._cmbYRes.Size = new System.Drawing.Size(100, 21);
         this._cmbYRes.TabIndex = 15;
         // 
         // _cmbXRes
         // 
         this._cmbXRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbXRes.Location = new System.Drawing.Point(72, 176);
         this._cmbXRes.Name = "_cmbXRes";
         this._cmbXRes.Size = new System.Drawing.Size(100, 21);
         this._cmbXRes.TabIndex = 14;
         // 
         // _lblYRes
         // 
         this._lblYRes.Location = new System.Drawing.Point(8, 208);
         this._lblYRes.Name = "_lblYRes";
         this._lblYRes.Size = new System.Drawing.Size(72, 23);
         this._lblYRes.TabIndex = 13;
         this._lblYRes.Text = "YResolution:";
         // 
         // _lblXRes
         // 
         this._lblXRes.Location = new System.Drawing.Point(8, 176);
         this._lblXRes.Name = "_lblXRes";
         this._lblXRes.Size = new System.Drawing.Size(72, 23);
         this._lblXRes.TabIndex = 11;
         this._lblXRes.Text = "XResolution:";
         // 
         // _txtFrameBottom
         // 
         this._txtFrameBottom.Location = new System.Drawing.Point(72, 144);
         this._txtFrameBottom.Name = "_txtFrameBottom";
         this._txtFrameBottom.TabIndex = 10;
         this._txtFrameBottom.Text = "";
         // 
         // _txtFrameRight
         // 
         this._txtFrameRight.Location = new System.Drawing.Point(72, 112);
         this._txtFrameRight.Name = "_txtFrameRight";
         this._txtFrameRight.TabIndex = 8;
         this._txtFrameRight.Text = "";
         // 
         // _txtFrameTop
         // 
         this._txtFrameTop.Location = new System.Drawing.Point(72, 80);
         this._txtFrameTop.Name = "_txtFrameTop";
         this._txtFrameTop.TabIndex = 6;
         this._txtFrameTop.Text = "";
         // 
         // _txtFrameLeft
         // 
         this._txtFrameLeft.Location = new System.Drawing.Point(72, 48);
         this._txtFrameLeft.Name = "_txtFrameLeft";
         this._txtFrameLeft.TabIndex = 4;
         this._txtFrameLeft.Text = "";
         // 
         // _lblFrameBottom
         // 
         this._lblFrameBottom.Location = new System.Drawing.Point(8, 144);
         this._lblFrameBottom.Name = "_lblFrameBottom";
         this._lblFrameBottom.Size = new System.Drawing.Size(48, 23);
         this._lblFrameBottom.TabIndex = 9;
         this._lblFrameBottom.Text = "Bottom:";
         // 
         // _lblFrameRight
         // 
         this._lblFrameRight.Location = new System.Drawing.Point(8, 112);
         this._lblFrameRight.Name = "_lblFrameRight";
         this._lblFrameRight.Size = new System.Drawing.Size(40, 23);
         this._lblFrameRight.TabIndex = 7;
         this._lblFrameRight.Text = "Right:";
         // 
         // _lblFrameTop
         // 
         this._lblFrameTop.Location = new System.Drawing.Point(8, 80);
         this._lblFrameTop.Name = "_lblFrameTop";
         this._lblFrameTop.Size = new System.Drawing.Size(40, 23);
         this._lblFrameTop.TabIndex = 5;
         this._lblFrameTop.Text = "Top:";
         // 
         // _lblFrameLeft
         // 
         this._lblFrameLeft.Location = new System.Drawing.Point(8, 48);
         this._lblFrameLeft.Name = "_lblFrameLeft";
         this._lblFrameLeft.Size = new System.Drawing.Size(32, 23);
         this._lblFrameLeft.TabIndex = 3;
         this._lblFrameLeft.Text = "Lef:";
         // 
         // _cmbUnit
         // 
         this._cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbUnit.Location = new System.Drawing.Point(72, 16);
         this._cmbUnit.Name = "_cmbUnit";
         this._cmbUnit.Size = new System.Drawing.Size(100, 21);
         this._cmbUnit.TabIndex = 2;
         this._cmbUnit.SelectedIndexChanged += new System.EventHandler(this._cmbUnit_SelectedIndexChanged);
         // 
         // _lblUnit
         // 
         this._lblUnit.Location = new System.Drawing.Point(8, 16);
         this._lblUnit.Name = "_lblUnit";
         this._lblUnit.Size = new System.Drawing.Size(32, 23);
         this._lblUnit.TabIndex = 1;
         this._lblUnit.Text = "Unit:";
         // 
         // _gbTransferMode
         // 
         this._gbTransferMode.Controls.Add(this._rdNative);
         this._gbTransferMode.Controls.Add(this._rdMemory);
         this._gbTransferMode.Controls.Add(this._rdFile);
         this._gbTransferMode.Location = new System.Drawing.Point(200, 8);
         this._gbTransferMode.Name = "_gbTransferMode";
         this._gbTransferMode.Size = new System.Drawing.Size(224, 64);
         this._gbTransferMode.TabIndex = 1;
         this._gbTransferMode.TabStop = false;
         this._gbTransferMode.Text = "Transfer Mode";
         // 
         // _rdNative
         // 
         this._rdNative.Location = new System.Drawing.Point(160, 24);
         this._rdNative.Name = "_rdNative";
         this._rdNative.Size = new System.Drawing.Size(56, 24);
         this._rdNative.TabIndex = 2;
         this._rdNative.Text = "Native";
         this._rdNative.Click += new System.EventHandler(this._rdNative_Click);
         // 
         // _rdMemory
         // 
         this._rdMemory.Location = new System.Drawing.Point(72, 24);
         this._rdMemory.Name = "_rdMemory";
         this._rdMemory.Size = new System.Drawing.Size(64, 24);
         this._rdMemory.TabIndex = 1;
         this._rdMemory.Text = "Memory";
         this._rdMemory.Click += new System.EventHandler(this._rdMemory_Click);
         // 
         // _rdFile
         // 
         this._rdFile.Location = new System.Drawing.Point(8, 24);
         this._rdFile.Name = "_rdFile";
         this._rdFile.Size = new System.Drawing.Size(48, 24);
         this._rdFile.TabIndex = 0;
         this._rdFile.Text = "File";
         this._rdFile.Click += new System.EventHandler(this._rdFile_Click);
         // 
         // _gbFileOptions
         // 
         this._gbFileOptions.Controls.Add(this._cmbFileFormat);
         this._gbFileOptions.Controls.Add(this._lblFormat);
         this._gbFileOptions.Controls.Add(this._btnBrowse);
         this._gbFileOptions.Controls.Add(this._txtFileName);
         this._gbFileOptions.Controls.Add(this._lblFileName);
         this._gbFileOptions.Location = new System.Drawing.Point(200, 80);
         this._gbFileOptions.Name = "_gbFileOptions";
         this._gbFileOptions.Size = new System.Drawing.Size(224, 96);
         this._gbFileOptions.TabIndex = 2;
         this._gbFileOptions.TabStop = false;
         this._gbFileOptions.Text = "File Mode Options";
         // 
         // _cmbFileFormat
         // 
         this._cmbFileFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbFileFormat.Location = new System.Drawing.Point(64, 64);
         this._cmbFileFormat.Name = "_cmbFileFormat";
         this._cmbFileFormat.Size = new System.Drawing.Size(152, 21);
         this._cmbFileFormat.TabIndex = 4;
         // 
         // _lblFormat
         // 
         this._lblFormat.Location = new System.Drawing.Point(8, 64);
         this._lblFormat.Name = "_lblFormat";
         this._lblFormat.Size = new System.Drawing.Size(48, 23);
         this._lblFormat.TabIndex = 3;
         this._lblFormat.Text = "Format:";
         // 
         // _btnBrowse
         // 
         this._btnBrowse.Location = new System.Drawing.Point(184, 32);
         this._btnBrowse.Name = "_btnBrowse";
         this._btnBrowse.Size = new System.Drawing.Size(32, 23);
         this._btnBrowse.TabIndex = 2;
         this._btnBrowse.Text = "...";
         this._btnBrowse.Click += new System.EventHandler(this._btnBrowse_Click);
         // 
         // _txtFileName
         // 
         this._txtFileName.Location = new System.Drawing.Point(64, 32);
         this._txtFileName.Name = "_txtFileName";
         this._txtFileName.Size = new System.Drawing.Size(112, 20);
         this._txtFileName.TabIndex = 1;
         this._txtFileName.Text = "";
         this._txtFileName.TextChanged += new System.EventHandler(this._txtFileName_TextChanged);
         // 
         // _lblFileName
         // 
         this._lblFileName.Location = new System.Drawing.Point(8, 32);
         this._lblFileName.Name = "_lblFileName";
         this._lblFileName.Size = new System.Drawing.Size(64, 23);
         this._lblFileName.TabIndex = 0;
         this._lblFileName.Text = "File Name:";
         // 
         // _gbMemoryOptions
         // 
         this._gbMemoryOptions.Controls.Add(this._cmbCompression);
         this._gbMemoryOptions.Controls.Add(this._lblCompression);
         this._gbMemoryOptions.Location = new System.Drawing.Point(200, 184);
         this._gbMemoryOptions.Name = "_gbMemoryOptions";
         this._gbMemoryOptions.Size = new System.Drawing.Size(224, 64);
         this._gbMemoryOptions.TabIndex = 3;
         this._gbMemoryOptions.TabStop = false;
         this._gbMemoryOptions.Text = "Memory Mode Options";
         // 
         // _cmbCompression
         // 
         this._cmbCompression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbCompression.Location = new System.Drawing.Point(88, 24);
         this._cmbCompression.Name = "_cmbCompression";
         this._cmbCompression.Size = new System.Drawing.Size(121, 21);
         this._cmbCompression.TabIndex = 1;
         // 
         // _lblCompression
         // 
         this._lblCompression.Location = new System.Drawing.Point(8, 24);
         this._lblCompression.Name = "_lblCompression";
         this._lblCompression.Size = new System.Drawing.Size(80, 16);
         this._lblCompression.TabIndex = 0;
         this._lblCompression.Text = "Compression:";
         // 
         // _gbImgeEfx
         // 
         this._gbImgeEfx.Controls.Add(this._cmbHighlight);
         this._gbImgeEfx.Controls.Add(this._lblHighlight);
         this._gbImgeEfx.Controls.Add(this._cmbBrightness);
         this._gbImgeEfx.Controls.Add(this._lblBrightness);
         this._gbImgeEfx.Controls.Add(this._cmbContrast);
         this._gbImgeEfx.Controls.Add(this._lblContrast);
         this._gbImgeEfx.Controls.Add(this._cmbHalftone);
         this._gbImgeEfx.Controls.Add(this._lblHalftone);
         this._gbImgeEfx.Controls.Add(this._cmbOrientation);
         this._gbImgeEfx.Controls.Add(this._lblOrientation);
         this._gbImgeEfx.Controls.Add(this._cmbPixelType);
         this._gbImgeEfx.Controls.Add(this._lblPixelType);
         this._gbImgeEfx.Location = new System.Drawing.Point(432, 8);
         this._gbImgeEfx.Name = "_gbImgeEfx";
         this._gbImgeEfx.Size = new System.Drawing.Size(208, 240);
         this._gbImgeEfx.TabIndex = 4;
         this._gbImgeEfx.TabStop = false;
         this._gbImgeEfx.Text = "Image Effects";
         // 
         // _cmbHighlight
         // 
         this._cmbHighlight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbHighlight.Location = new System.Drawing.Point(72, 192);
         this._cmbHighlight.Name = "_cmbHighlight";
         this._cmbHighlight.Size = new System.Drawing.Size(121, 21);
         this._cmbHighlight.TabIndex = 11;
         // 
         // _lblHighlight
         // 
         this._lblHighlight.Location = new System.Drawing.Point(8, 192);
         this._lblHighlight.Name = "_lblHighlight";
         this._lblHighlight.Size = new System.Drawing.Size(56, 23);
         this._lblHighlight.TabIndex = 10;
         this._lblHighlight.Text = "Highlight:";
         // 
         // _cmbBrightness
         // 
         this._cmbBrightness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbBrightness.Location = new System.Drawing.Point(72, 160);
         this._cmbBrightness.Name = "_cmbBrightness";
         this._cmbBrightness.Size = new System.Drawing.Size(121, 21);
         this._cmbBrightness.TabIndex = 9;
         // 
         // _lblBrightness
         // 
         this._lblBrightness.Location = new System.Drawing.Point(8, 160);
         this._lblBrightness.Name = "_lblBrightness";
         this._lblBrightness.Size = new System.Drawing.Size(64, 23);
         this._lblBrightness.TabIndex = 8;
         this._lblBrightness.Text = "Brightness:";
         // 
         // _cmbContrast
         // 
         this._cmbContrast.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbContrast.Location = new System.Drawing.Point(72, 128);
         this._cmbContrast.Name = "_cmbContrast";
         this._cmbContrast.Size = new System.Drawing.Size(121, 21);
         this._cmbContrast.TabIndex = 7;
         // 
         // _lblContrast
         // 
         this._lblContrast.Location = new System.Drawing.Point(8, 128);
         this._lblContrast.Name = "_lblContrast";
         this._lblContrast.Size = new System.Drawing.Size(56, 23);
         this._lblContrast.TabIndex = 6;
         this._lblContrast.Text = "Contrast:";
         // 
         // _cmbHalftone
         // 
         this._cmbHalftone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbHalftone.Location = new System.Drawing.Point(72, 96);
         this._cmbHalftone.Name = "_cmbHalftone";
         this._cmbHalftone.Size = new System.Drawing.Size(121, 21);
         this._cmbHalftone.TabIndex = 5;
         // 
         // _lblHalftone
         // 
         this._lblHalftone.Location = new System.Drawing.Point(8, 96);
         this._lblHalftone.Name = "_lblHalftone";
         this._lblHalftone.Size = new System.Drawing.Size(56, 23);
         this._lblHalftone.TabIndex = 4;
         this._lblHalftone.Text = "Halftone:";
         // 
         // _cmbOrientation
         // 
         this._cmbOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbOrientation.Location = new System.Drawing.Point(72, 64);
         this._cmbOrientation.Name = "_cmbOrientation";
         this._cmbOrientation.Size = new System.Drawing.Size(121, 21);
         this._cmbOrientation.TabIndex = 3;
         // 
         // _lblOrientation
         // 
         this._lblOrientation.Location = new System.Drawing.Point(8, 64);
         this._lblOrientation.Name = "_lblOrientation";
         this._lblOrientation.Size = new System.Drawing.Size(64, 23);
         this._lblOrientation.TabIndex = 2;
         this._lblOrientation.Text = "Orientation:";
         // 
         // _cmbPixelType
         // 
         this._cmbPixelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbPixelType.Location = new System.Drawing.Point(72, 32);
         this._cmbPixelType.Name = "_cmbPixelType";
         this._cmbPixelType.Size = new System.Drawing.Size(121, 21);
         this._cmbPixelType.TabIndex = 1;
         // 
         // _lblPixelType
         // 
         this._lblPixelType.Location = new System.Drawing.Point(8, 32);
         this._lblPixelType.Name = "_lblPixelType";
         this._lblPixelType.Size = new System.Drawing.Size(64, 23);
         this._lblPixelType.TabIndex = 0;
         this._lblPixelType.Text = "Pixel Type:";
         // 
         // _btnLoad
         // 
         this._btnLoad.Location = new System.Drawing.Point(167, 256);
         this._btnLoad.Name = "_btnLoad";
         this._btnLoad.TabIndex = 5;
         this._btnLoad.Text = "Load";
         this._btnLoad.Click += new System.EventHandler(this._btnLoad_Click);
         // 
         // _btnSave
         // 
         this._btnSave.Location = new System.Drawing.Point(247, 256);
         this._btnSave.Name = "_btnSave";
         this._btnSave.TabIndex = 6;
         this._btnSave.Text = "Save";
         this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
         // 
         // _btnOK
         // 
         this._btnOK.Location = new System.Drawing.Point(327, 256);
         this._btnOK.Name = "_btnOK";
         this._btnOK.TabIndex = 7;
         this._btnOK.Text = "OK";
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(407, 256);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.TabIndex = 8;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // Template
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(648, 286);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this._btnSave);
         this.Controls.Add(this._btnLoad);
         this.Controls.Add(this._gbImgeEfx);
         this.Controls.Add(this._gbMemoryOptions);
         this.Controls.Add(this._gbFileOptions);
         this.Controls.Add(this._gbTransferMode);
         this.Controls.Add(this._gbImageFrame);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "Template";
         this.Text = "LEAD Template";
         this.Load += new System.EventHandler(this.Template_Load);
         this._gbImageFrame.ResumeLayout(false);
         this._gbTransferMode.ResumeLayout(false);
         this._gbFileOptions.ResumeLayout(false);
         this._gbMemoryOptions.ResumeLayout(false);
         this._gbImgeEfx.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion

      public TwainSession _twainSession = null;
      public TwainTransferMode _transferMode = TwainTransferMode.Native;
      public int _transferComp;
      public int _transferFormat;
      public string _transferFile;
      private TwainImageUnit[] _unitsValue;
      private TwainCapabilityValue[] _pixelValue;
      private TwainPaperOrientation[] _orientationValue;
      private TwainCapabilityValue[] _compressionValue;
      private TwainCapabilityValue[] _formatValue;
      private int _selectedUnitsIndex = 0;

      private void Template_Load(object sender, System.EventArgs e)
      {
         InitializeTemplate();
      }

      private void InitializeTemplate( )
      {
         _unitsValue = new TwainImageUnit[6];
         _pixelValue = new TwainCapabilityValue[9];
         _orientationValue = new TwainPaperOrientation[4];
         _compressionValue = new TwainCapabilityValue[14];
         _formatValue = new TwainCapabilityValue[10];
         _compressionValue = new TwainCapabilityValue[14];
         _formatValue = new TwainCapabilityValue[10];

         FillUnitsCap();
         FillFrameCaps();
         FillXYRes();
         FillTransferMode();
         FillPixelType();
         FillOrientation();
         FillEffectsCap(TwainCapabilityType.ImageContrast);
         FillEffectsCap(TwainCapabilityType.ImageBrightness);
         FillEffectsCap(TwainCapabilityType.ImageHighlight);
         FillHalftones();
      }

      private void FillUnitsCap( )
      {
         /* ICAP_UNITS */
         _cmbUnit.Items.Clear();

         try
         {
            TwainCapability twnCap = _twainSession.GetCapability(TwainCapabilityType.ImageUnits, TwainGetCapabilityMode.GetValues);
            _cmbUnit.Enabled = true;

            switch(twnCap.Information.ContainerType)
            {
               case TwainContainerType.OneValue:
                  {
                     object item = twnCap.OneValueCapability.Value;
                     TwainImageUnit itemValue = (TwainImageUnit)Convert.ToUInt16(item);
                     switch(itemValue)
                     {
                        case TwainImageUnit.Centimeters:
                           _cmbUnit.Items.Add("Centimeters");
                           break;
                        case TwainImageUnit.Inches:
                           _cmbUnit.Items.Add("Inches");
                           break;
                        case TwainImageUnit.Picas:
                           _cmbUnit.Items.Add("Picas");
                           break;
                        case TwainImageUnit.Pixels:
                           _cmbUnit.Items.Add("Pixels");
                           break;
                        case TwainImageUnit.Points:
                           _cmbUnit.Items.Add("Points");
                           break;
                        case TwainImageUnit.Twips:
                           _cmbUnit.Items.Add("Twips");
                           break;
                     }

                     _unitsValue[0] = itemValue;
                     _cmbUnit.SelectedIndex = 0;
                     break;
                  }
               case TwainContainerType.Enumeration:
                  {
                     int itemsCount = twnCap.EnumerationCapability.Count;
                     for(int i = 0; i < itemsCount; i++)
                     {
                        object item = twnCap.EnumerationCapability.GetValue(i);
                        TwainImageUnit itemValue = (TwainImageUnit)Convert.ToUInt16(item);
                        switch(itemValue)
                        {
                           case TwainImageUnit.Centimeters:
                              _cmbUnit.Items.Add("Centimeters");
                              break;
                           case TwainImageUnit.Inches:
                              _cmbUnit.Items.Add("Inches");
                              break;
                           case TwainImageUnit.Picas:
                              _cmbUnit.Items.Add("Picas");
                              break;
                           case TwainImageUnit.Pixels:
                              _cmbUnit.Items.Add("Pixels");
                              break;
                           case TwainImageUnit.Points:
                              _cmbUnit.Items.Add("Points");
                              break;
                           case TwainImageUnit.Twips:
                              _cmbUnit.Items.Add("Twips");
                              break;
                        }

                        _unitsValue[i] = itemValue;
                     }

                     _cmbUnit.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex;
                     break;
                  }
            }

            _selectedUnitsIndex = _cmbUnit.SelectedIndex;
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("Get TwainCapabilityType.ImageUnits returns {0}", ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
            _cmbUnit.Enabled = false;
         }
      }

      private void FillFrameCaps( )
      {
         /* ICAP_FRAMES */
         _txtFrameLeft.Text = "";
         _txtFrameTop.Text = "";
         _txtFrameRight.Text = "";
         _txtFrameBottom.Text = "";

         try
         {
            TwainCapability twnCap = _twainSession.GetCapability(TwainCapabilityType.ImageFrames, TwainGetCapabilityMode.GetValues);

            _txtFrameLeft.Enabled = true;
            _txtFrameTop.Enabled = true;
            _txtFrameRight.Enabled = true;
            _txtFrameBottom.Enabled = true;

            TwainFrame twnFrame = new TwainFrame();
            switch(twnCap.Information.ContainerType)
            {
               case TwainContainerType.OneValue:
                  {
                     object item = twnCap.OneValueCapability.Value;
                     twnFrame = (TwainFrame)item;
                     break;
                  }
               case TwainContainerType.Enumeration:
                  {
                     object item = twnCap.EnumerationCapability.GetValue(twnCap.EnumerationCapability.CurrentIndex);
                     twnFrame = (TwainFrame)item;
                     break;
                  }
            }

            _txtFrameLeft.Text = twnFrame.LeftMargin.ToString();
            _txtFrameTop.Text = twnFrame.TopMargin.ToString();
            _txtFrameRight.Text = twnFrame.RightMargin.ToString();
            _txtFrameBottom.Text = twnFrame.BottomMargin.ToString();
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("Get TwainCapabilityType.ImageFrames returns {0}", ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);

            _txtFrameLeft.Enabled = false;
            _txtFrameTop.Enabled = false;
            _txtFrameRight.Enabled = false;
            _txtFrameBottom.Enabled = false;
         }
      }

      private void FillXYRes( )
      {
         /* ICAP_XRESOLUTION and ICAP_YRESOLUTION */
         _cmbXRes.Items.Clear();
         _cmbYRes.Items.Clear();

         /* ICAP_XRESOLUTION */
         try
         {
            TwainCapability twnCap = _twainSession.GetCapability(TwainCapabilityType.ImageXResolution, TwainGetCapabilityMode.GetValues);
            _cmbXRes.Enabled = true;

            switch(twnCap.Information.ContainerType)
            {
               case TwainContainerType.OneValue:
                  {
                     object item = twnCap.OneValueCapability.Value;
                     float fix32Value = (float)Convert.ToDouble(item);
                     _cmbXRes.Items.Add(fix32Value.ToString());

                     _cmbXRes.SelectedIndex = 0;
                     break;
                  }
               case TwainContainerType.Enumeration:
                  {
                     object item;
                     float fix32Value;

                     int itemsCount = twnCap.EnumerationCapability.Count;
                     for(int i = 0; i < itemsCount; i++)
                     {
                        item = twnCap.EnumerationCapability.GetValue(i);
                        fix32Value = (float)Convert.ToDouble(item);
                        _cmbXRes.Items.Add(fix32Value.ToString());
                     }

                     _cmbXRes.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex;
                     break;
                  }
               case TwainContainerType.Range:
                  {
                     float minValue = (float)Convert.ToDouble(twnCap.RangeCapability.MinimumValue);
                     float maxValue = (float)Convert.ToDouble(twnCap.RangeCapability.MaximumValue);
                     float stepSize = (float)Convert.ToDouble(twnCap.RangeCapability.StepSize);
                     float currentValue = (float)Convert.ToDouble(twnCap.RangeCapability.CurrentValue);

                     int i = 0;
                     int selIndex = 0;

                     _cmbXRes.Items.Add(minValue.ToString());
                     if(minValue == currentValue)
                        selIndex = i;

                     float tempValue = minValue + stepSize;
                     while(tempValue <= maxValue)
                     {
                        i++;
                        _cmbXRes.Items.Add(tempValue.ToString());
                        if(tempValue == currentValue)
                           selIndex = i;

                        tempValue = tempValue + stepSize;
                     }

                     _cmbXRes.SelectedIndex = selIndex;
                     break;
                  }
            }
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("Get TwainCapabilityType.ImageXResolution returns {0}", ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);

            _cmbXRes.Enabled = false;
         }

         /* ICAP_YRESOLUTION */
         try
         {
            TwainCapability twnCap = _twainSession.GetCapability(TwainCapabilityType.ImageYResolution, TwainGetCapabilityMode.GetValues);
            _cmbYRes.Enabled = true;

            switch(twnCap.Information.ContainerType)
            {
               case TwainContainerType.OneValue:
                  {
                     object item = twnCap.OneValueCapability.Value;
                     float fix32Value = (float)Convert.ToDouble(item);
                     _cmbYRes.Items.Add(fix32Value.ToString());

                     _cmbYRes.SelectedIndex = 0;
                     break;
                  }
               case TwainContainerType.Enumeration:
                  {
                     object item;
                     float fix32Value;

                     int itemsCount = twnCap.EnumerationCapability.Count;
                     for(int i = 0; i < itemsCount; i++)
                     {
                        item = twnCap.EnumerationCapability.GetValue(i);
                        fix32Value = (float)Convert.ToDouble(item);
                        _cmbYRes.Items.Add(fix32Value.ToString());
                     }

                     _cmbYRes.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex;
                     break;
                  }
               case TwainContainerType.Range:
                  {
                     float minValue = (float)Convert.ToDouble(twnCap.RangeCapability.MinimumValue);
                     float maxValue = (float)Convert.ToDouble(twnCap.RangeCapability.MaximumValue);
                     float stepSize = (float)Convert.ToDouble(twnCap.RangeCapability.StepSize);
                     float currentValue = (float)Convert.ToDouble(twnCap.RangeCapability.CurrentValue);

                     int i = 0;
                     int selIndex = 0;

                     _cmbYRes.Items.Add(minValue.ToString());
                     if(minValue == currentValue)
                        selIndex = i;

                     float tempValue = minValue + stepSize;
                     while(tempValue <= maxValue)
                     {
                        i++;
                        _cmbYRes.Items.Add(tempValue.ToString());
                        if(tempValue == currentValue)
                           selIndex = i;

                        tempValue = tempValue + stepSize;
                     }

                     _cmbYRes.SelectedIndex = selIndex;
                     break;
                  }
            }
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("Get TwainCapabilityType.ImageYResolution returns {0}", ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);

            _cmbYRes.Enabled = false;
         }
      }

      private void FillTransferMode( )
      {
         bool fileMode, nativeMode, memoryMode;

         _rdFile.Checked = false;
         _rdMemory.Checked = false;
         _rdNative.Checked = false;
         fileMode = nativeMode = memoryMode = false;

         /* ICAP_XFERMECH */
         try
         {
            TwainCapability twnCap = _twainSession.GetCapability(TwainCapabilityType.ImageTransferMechanism, TwainGetCapabilityMode.GetValues);

            switch(twnCap.Information.ContainerType)
            {
               case TwainContainerType.OneValue:
                  {
                     object item = twnCap.OneValueCapability.Value;
                     TwainCapabilityValue itemValue = (TwainCapabilityValue)Convert.ToUInt16(item);
                     switch(itemValue)
                     {
                        case TwainCapabilityValue.TransferMechanismFile:
                           _rdFile.Enabled = true;
                           fileMode = true;
                           break;
                        case TwainCapabilityValue.TransferMechanismMemory:
                           _rdMemory.Enabled = true;
                           memoryMode = true;
                           break;
                        case TwainCapabilityValue.TransferMechanismNative:
                           _rdNative.Enabled = true;
                           nativeMode = true;
                           break;
                     }

                     break;
                  }
               case TwainContainerType.Enumeration:
                  {
                     int itemsCount = twnCap.EnumerationCapability.Count;
                     for(int i = 0; i < itemsCount; i++)
                     {
                        object item = twnCap.EnumerationCapability.GetValue(i);
                        TwainCapabilityValue itemValue = (TwainCapabilityValue)Convert.ToUInt16(item);
                        switch(itemValue)
                        {
                           case TwainCapabilityValue.TransferMechanismFile:
                              _rdFile.Enabled = true;
                              fileMode = true;
                              break;
                           case TwainCapabilityValue.TransferMechanismMemory:
                              _rdMemory.Enabled = true;
                              memoryMode = true;
                              break;
                           case TwainCapabilityValue.TransferMechanismNative:
                              _rdNative.Enabled = true;
                              nativeMode = true;
                              break;
                        }
                     }
                     break;
                  }
            }
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("Get TwainCapabilityType.ImageTranserMechanism returns {0}", ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);

            _rdFile.Enabled = false;
            _rdMemory.Enabled = false;
            _rdNative.Enabled = false;
         }

         if(fileMode)
            EnableFileMode();

         if(memoryMode)
            EnableMemoryMode();

         if(nativeMode)
            EnableNativeMode();
      }

      private void EnableFileMode( )
      {
         _transferMode = TwainTransferMode.File;

         /* Enable file options */
         _txtFileName.Enabled = true;
         _btnBrowse.Enabled = true;
         _cmbFileFormat.Enabled = true;

         /* Disable other options */
         _cmbCompression.Enabled = false;

         /* select file radio and deselect others */
         _rdFile.Checked = true;
         _rdMemory.Checked = false;
         _rdNative.Checked = false;

         /* ICAP_IMAGEFILEFORMAT */
         FillImageFileFormat();

         CheckOkButton();
      }

      private void FillImageFileFormat( )
      {
         /* ICAP_IMAGEFILEFORMAT */

         try
         {
            TwainCapability twnCap = _twainSession.GetCapability(TwainCapabilityType.ImageImageFileFormat, TwainGetCapabilityMode.GetValues);

            _txtFileName.Enabled = true;
            _btnBrowse.Enabled = true;
            _cmbFileFormat.Enabled = true;
            _cmbFileFormat.Items.Clear();

            switch(twnCap.Information.ContainerType)
            {
               case TwainContainerType.OneValue:
                  {
                     object item = twnCap.OneValueCapability.Value;
                     TwainCapabilityValue itemValue = (TwainCapabilityValue)Convert.ToUInt16(item);
                     switch(itemValue)
                     {
                        case TwainCapabilityValue.FileFormatTiff:
                           _cmbFileFormat.Items.Add("TIFF");
                           break;
                        case TwainCapabilityValue.FileFormatPict:
                           _cmbFileFormat.Items.Add("PICT");
                           break;
                        case TwainCapabilityValue.FileFormatBmp:
                           _cmbFileFormat.Items.Add("BMP");
                           break;
                        case TwainCapabilityValue.FileFormatXbm:
                           _cmbFileFormat.Items.Add("XBM");
                           break;
                        case TwainCapabilityValue.FileFormatJfif:
                           _cmbFileFormat.Items.Add("JFIF");
                           break;
                        case TwainCapabilityValue.FileFormatFpx:
                           _cmbFileFormat.Items.Add("FPX");
                           break;
                        case TwainCapabilityValue.FileFormatTiffMulti:
                           _cmbFileFormat.Items.Add("TIFFMULTI");
                           break;
                        case TwainCapabilityValue.FileFormatPng:
                           _cmbFileFormat.Items.Add("PNG");
                           break;
                        case TwainCapabilityValue.FileFormatSpiff:
                           _cmbFileFormat.Items.Add("SPIFF");
                           break;
                        case TwainCapabilityValue.FileFormatExif:
                           _cmbFileFormat.Items.Add("EXIF");
                           break;
                     }

                     _formatValue[0] = itemValue;
                     _cmbFileFormat.SelectedIndex = 0;
                     break;
                  }
               case TwainContainerType.Enumeration:
                  {
                     int itemsCount = twnCap.EnumerationCapability.Count;
                     for(int i = 0; i < itemsCount; i++)
                     {
                        object item = twnCap.EnumerationCapability.GetValue(i);
                        TwainCapabilityValue itemValue = (TwainCapabilityValue)Convert.ToUInt16(item);
                        switch(itemValue)
                        {
                           case TwainCapabilityValue.FileFormatTiff:
                              _cmbFileFormat.Items.Add("TIFF");
                              break;
                           case TwainCapabilityValue.FileFormatPict:
                              _cmbFileFormat.Items.Add("PICT");
                              break;
                           case TwainCapabilityValue.FileFormatBmp:
                              _cmbFileFormat.Items.Add("BMP");
                              break;
                           case TwainCapabilityValue.FileFormatXbm:
                              _cmbFileFormat.Items.Add("XBM");
                              break;
                           case TwainCapabilityValue.FileFormatJfif:
                              _cmbFileFormat.Items.Add("JFIF");
                              break;
                           case TwainCapabilityValue.FileFormatFpx:
                              _cmbFileFormat.Items.Add("FPX");
                              break;
                           case TwainCapabilityValue.FileFormatTiffMulti:
                              _cmbFileFormat.Items.Add("TIFFMULTI");
                              break;
                           case TwainCapabilityValue.FileFormatPng:
                              _cmbFileFormat.Items.Add("PNG");
                              break;
                           case TwainCapabilityValue.FileFormatSpiff:
                              _cmbFileFormat.Items.Add("SPIFF");
                              break;
                           case TwainCapabilityValue.FileFormatExif:
                              _cmbFileFormat.Items.Add("EXIF");
                              break;
                        }

                        _formatValue[i] = itemValue;
                     }

                     _cmbFileFormat.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex;
                     break;
                  }
            }
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("Get TwainCapabilityType.ImageImageFileFormat returns {0}", ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);

            /* disable all file modes controls */
            _txtFileName.Enabled = false;
            _btnBrowse.Enabled = false;
            _cmbFileFormat.Enabled = false;
         }
      }

      private void EnableMemoryMode( )
      {
         _transferMode = TwainTransferMode.Buffer;

         /* Enable memory options */
         _cmbCompression.Enabled = true;

         /* Disable other options */
         _txtFileName.Enabled = false;
         _btnBrowse.Enabled = false;
         _cmbFileFormat.Enabled = false;

         /* select memory radio and deselect others */
         _rdMemory.Checked = true;
         _rdFile.Checked = false;
         _rdNative.Checked = false;

         /* ICAP_COMPRESSION */
         FillCompression();

         CheckOkButton();
      }

      private void FillCompression( )
      {
         /* ICAP_COMPRESSION */

         try
         {
            TwainCapability twnCap = _twainSession.GetCapability(TwainCapabilityType.ImageCompression, TwainGetCapabilityMode.GetValues);

            _cmbCompression.Enabled = true;
            _cmbCompression.Items.Clear();

            switch(twnCap.Information.ContainerType)
            {
               case TwainContainerType.OneValue:
                  {
                     object item = twnCap.OneValueCapability.Value;
                     TwainCapabilityValue itemValue = (TwainCapabilityValue)Convert.ToUInt16(item);
                     switch(itemValue)
                     {
                        case TwainCapabilityValue.CompressionNone:
                           _cmbCompression.Items.Add("NONE");
                           break;
                        case TwainCapabilityValue.CompressionPackBits:
                           _cmbCompression.Items.Add("PACKBITS");
                           break;
                        case TwainCapabilityValue.CompressionGroup31D:
                           _cmbCompression.Items.Add("GROUP31D");
                           break;
                        case TwainCapabilityValue.CompressionGroup31DEol:
                           _cmbCompression.Items.Add("GROUP31DEOL");
                           break;
                        case TwainCapabilityValue.CompressionGroup32D:
                           _cmbCompression.Items.Add("GROUP32D");
                           break;
                        case TwainCapabilityValue.CompressionGroup4:
                           _cmbCompression.Items.Add("GROUP4");
                           break;
                        case TwainCapabilityValue.CompressionJpeg:
                           _cmbCompression.Items.Add("JPEG");
                           break;
                        case TwainCapabilityValue.CompressionLzw:
                           _cmbCompression.Items.Add("LZW");
                           break;
                        case TwainCapabilityValue.CompressionJbig:
                           _cmbCompression.Items.Add("JBIG");
                           break;
                        case TwainCapabilityValue.CompressionPng:
                           _cmbCompression.Items.Add("PNG");
                           break;
                        case TwainCapabilityValue.CompressionRle4:
                           _cmbCompression.Items.Add("RLE4");
                           break;
                        case TwainCapabilityValue.CompressionRle8:
                           _cmbCompression.Items.Add("RLE8");
                           break;
                        case TwainCapabilityValue.CompressionBitFields:
                           _cmbCompression.Items.Add("BITFIELDS");
                           break;
                     }

                     _compressionValue[0] = itemValue;
                     _cmbCompression.SelectedIndex = 0;
                     break;
                  }
               case TwainContainerType.Enumeration:
                  {
                     int itemsCount = twnCap.EnumerationCapability.Count;
                     for(int i = 0; i < itemsCount; i++)
                     {
                        object item = twnCap.EnumerationCapability.GetValue(i);
                        TwainCapabilityValue itemValue = (TwainCapabilityValue)Convert.ToUInt16(item);
                        switch(itemValue)
                        {
                           case TwainCapabilityValue.CompressionNone:
                              _cmbCompression.Items.Add("NONE");
                              break;
                           case TwainCapabilityValue.CompressionPackBits:
                              _cmbCompression.Items.Add("PACKBITS");
                              break;
                           case TwainCapabilityValue.CompressionGroup31D:
                              _cmbCompression.Items.Add("GROUP31D");
                              break;
                           case TwainCapabilityValue.CompressionGroup31DEol:
                              _cmbCompression.Items.Add("GROUP31DEOL");
                              break;
                           case TwainCapabilityValue.CompressionGroup32D:
                              _cmbCompression.Items.Add("GROUP32D");
                              break;
                           case TwainCapabilityValue.CompressionGroup4:
                              _cmbCompression.Items.Add("GROUP4");
                              break;
                           case TwainCapabilityValue.CompressionJpeg:
                              _cmbCompression.Items.Add("JPEG");
                              break;
                           case TwainCapabilityValue.CompressionLzw:
                              _cmbCompression.Items.Add("LZW");
                              break;
                           case TwainCapabilityValue.CompressionJbig:
                              _cmbCompression.Items.Add("JBIG");
                              break;
                           case TwainCapabilityValue.CompressionPng:
                              _cmbCompression.Items.Add("PNG");
                              break;
                           case TwainCapabilityValue.CompressionRle4:
                              _cmbCompression.Items.Add("RLE4");
                              break;
                           case TwainCapabilityValue.CompressionRle8:
                              _cmbCompression.Items.Add("RLE8");
                              break;
                           case TwainCapabilityValue.CompressionBitFields:
                              _cmbCompression.Items.Add("BITFIELDS");
                              break;
                        }

                        _compressionValue[i] = itemValue;
                     }

                     _cmbCompression.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex;
                     break;
                  }
            }
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("Get TwainCapabilityType.ImageCompression returns {0}", ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
            _cmbCompression.Enabled = false;
         }
      }

      private void EnableNativeMode( )
      {
         _transferMode = TwainTransferMode.Native;

         /* Disable other options */
         _cmbCompression.Enabled = false;

         _txtFileName.Enabled = false;
         _btnBrowse.Enabled = false;
         _cmbFileFormat.Enabled = false;

         /* select native radio and deselect others */
         _rdNative.Checked = true;
         _rdMemory.Checked = false;
         _rdFile.Checked = false;

         CheckOkButton();
      }

      private void CheckOkButton( )
      {
         bool okEnabled = true;
         bool frameEnabled = true;
         bool fileEnabled = true;

         frameEnabled = _txtFrameLeft.Enabled;
         if(frameEnabled)
         {
            if(_txtFrameLeft.Text.Length == 0 || _txtFrameTop.Text.Length == 0 ||
                _txtFrameRight.Text.Length == 0 || _txtFrameBottom.Text.Length == 0)
               okEnabled = false;
         }
         else
            okEnabled = true;

         fileEnabled = _txtFileName.Enabled;
         if(fileEnabled)
         {
            if(_txtFileName.Text.Length == 0)
               okEnabled = false;
         }

         _btnOK.Enabled = okEnabled;
      }

      private void _rdFile_Click(object sender, System.EventArgs e)
      {
         EnableFileMode();
      }

      private void _rdMemory_Click(object sender, System.EventArgs e)
      {
         EnableMemoryMode();
      }

      private void _rdNative_Click(object sender, System.EventArgs e)
      {
         EnableNativeMode();
      }

      private void FillPixelType( )
      {
         /* ICAP_PIXELTYPE */
         try
         {
            TwainCapability twnCap = _twainSession.GetCapability(TwainCapabilityType.ImagePixelType, TwainGetCapabilityMode.GetValues);

            _cmbPixelType.Enabled = true;
            _cmbPixelType.Items.Clear();

            switch(twnCap.Information.ContainerType)
            {
               case TwainContainerType.OneValue:
                  {
                     object item = twnCap.OneValueCapability.Value;
                     TwainCapabilityValue itemValue = (TwainCapabilityValue)Convert.ToUInt16(item);
                     switch(itemValue)
                     {
                        case TwainCapabilityValue.PixelTypeBW:
                           _cmbPixelType.Items.Add("BW");
                           break;
                        case TwainCapabilityValue.PixelTypeGray:
                           _cmbPixelType.Items.Add("GRAY");
                           break;
                        case TwainCapabilityValue.PixelTypeRgb:
                           _cmbPixelType.Items.Add("RGB");
                           break;
                        case TwainCapabilityValue.PixelTypePalette:
                           _cmbPixelType.Items.Add("PALETTE");
                           break;
                        case TwainCapabilityValue.PixelTypeCmy:
                           _cmbPixelType.Items.Add("CMY");
                           break;
                        case TwainCapabilityValue.PixelTypeCmyk:
                           _cmbPixelType.Items.Add("CMYK");
                           break;
                        case TwainCapabilityValue.PixelTypeYuv:
                           _cmbPixelType.Items.Add("YUV");
                           break;
                        case TwainCapabilityValue.PixelTypeYuvk:
                           _cmbPixelType.Items.Add("YUVK");
                           break;
                        case TwainCapabilityValue.PixelTypeCieXyz:
                           _cmbPixelType.Items.Add("CIEXYZ");
                           break;
                     }

                     _pixelValue[0] = itemValue;
                     _cmbPixelType.SelectedIndex = 0;
                     break;
                  }
               case TwainContainerType.Enumeration:
                  {
                     int itemsCount = twnCap.EnumerationCapability.Count;
                     for(int i = 0; i < itemsCount; i++)
                     {
                        object item = twnCap.EnumerationCapability.GetValue(i);
                        TwainCapabilityValue itemValue = (TwainCapabilityValue)Convert.ToUInt16(item);
                        switch(itemValue)
                        {
                           case TwainCapabilityValue.PixelTypeBW:
                              _cmbPixelType.Items.Add("BW");
                              break;
                           case TwainCapabilityValue.PixelTypeGray:
                              _cmbPixelType.Items.Add("GRAY");
                              break;
                           case TwainCapabilityValue.PixelTypeRgb:
                              _cmbPixelType.Items.Add("RGB");
                              break;
                           case TwainCapabilityValue.PixelTypePalette:
                              _cmbPixelType.Items.Add("PALETTE");
                              break;
                           case TwainCapabilityValue.PixelTypeCmy:
                              _cmbPixelType.Items.Add("CMY");
                              break;
                           case TwainCapabilityValue.PixelTypeCmyk:
                              _cmbPixelType.Items.Add("CMYK");
                              break;
                           case TwainCapabilityValue.PixelTypeYuv:
                              _cmbPixelType.Items.Add("YUV");
                              break;
                           case TwainCapabilityValue.PixelTypeYuvk:
                              _cmbPixelType.Items.Add("YUVK");
                              break;
                           case TwainCapabilityValue.PixelTypeCieXyz:
                              _cmbPixelType.Items.Add("CIEXYZ");
                              break;
                        }

                        _pixelValue[i] = itemValue;
                     }

                     _cmbPixelType.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex;
                     break;
                  }
            }
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("Get TwainCapabilityType.ImagePixelType returns {0}", ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
            _cmbPixelType.Enabled = false;
         }
      }

      private void FillOrientation( )
      {
         /* ICAP_ORIENTATION */
         try
         {
            TwainCapability twnCap = _twainSession.GetCapability(TwainCapabilityType.ImageOrientation, TwainGetCapabilityMode.GetValues);

            _cmbOrientation.Enabled = true;
            _cmbOrientation.Items.Clear();

            switch(twnCap.Information.ContainerType)
            {
               case TwainContainerType.OneValue:
                  {
                     object item = twnCap.OneValueCapability.Value;
                     TwainPaperOrientation itemValue = (TwainPaperOrientation)Convert.ToUInt16(item);
                     switch(itemValue)
                     {
                        case TwainPaperOrientation.Rotate0:
                           _cmbOrientation.Items.Add("ROT0");
                           break;
                        case TwainPaperOrientation.Rotate90:
                           _cmbOrientation.Items.Add("ROT90");
                           break;
                        case TwainPaperOrientation.Rotate180:
                           _cmbOrientation.Items.Add("ROT180");
                           break;
                        case TwainPaperOrientation.Rotate270:
                           _cmbOrientation.Items.Add("ROT270");
                           break;
                     }

                     _orientationValue[0] = itemValue;
                     _cmbOrientation.SelectedIndex = 0;
                     break;
                  }
               case TwainContainerType.Enumeration:
                  {
                     int itemsCount = twnCap.EnumerationCapability.Count;
                     for(int i = 0; i < itemsCount; i++)
                     {
                        object item = twnCap.EnumerationCapability.GetValue(i);
                        TwainPaperOrientation itemValue = (TwainPaperOrientation)Convert.ToUInt16(item);
                        switch(itemValue)
                        {
                           case TwainPaperOrientation.Rotate0:
                              _cmbOrientation.Items.Add("ROT0");
                              break;
                           case TwainPaperOrientation.Rotate90:
                              _cmbOrientation.Items.Add("ROT90");
                              break;
                           case TwainPaperOrientation.Rotate180:
                              _cmbOrientation.Items.Add("ROT180");
                              break;
                           case TwainPaperOrientation.Rotate270:
                              _cmbOrientation.Items.Add("ROT270");
                              break;
                        }

                        _orientationValue[i] = itemValue;
                     }

                     _cmbOrientation.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex;
                     break;
                  }
            }
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("Get TwainCapabilityType.ImageOrientation returns {0}", ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
            _cmbOrientation.Enabled = false;
         }
      }

      private void FillEffectsCap(TwainCapabilityType capType)
      {
         /* ICAP_CONTRAST, ICAP_BRIGHTNESS, ICAP_HIGHLIGHT */
         try
         {
            TwainCapability twnCap = _twainSession.GetCapability(capType, TwainGetCapabilityMode.GetValues);

            ComboBox tempCombo = new ComboBox();
            switch(capType)
            {
               case TwainCapabilityType.ImageContrast:
                  _cmbContrast.Enabled = true;
                  _cmbContrast.Items.Clear();
                  tempCombo = _cmbContrast;
                  break;
               case TwainCapabilityType.ImageBrightness:
                  _cmbBrightness.Enabled = true;
                  _cmbBrightness.Items.Clear();
                  tempCombo = _cmbBrightness;
                  break;
               case TwainCapabilityType.ImageHighlight:
                  _cmbHighlight.Enabled = true;
                  _cmbHighlight.Items.Clear();
                  tempCombo = _cmbHighlight;
                  break;
            }

            switch(twnCap.Information.ContainerType)
            {
               case TwainContainerType.OneValue:
                  {
                     object item = twnCap.OneValueCapability.Value;
                     float fix32Value = (float)Convert.ToDouble(item);
                     tempCombo.Items.Add(fix32Value.ToString());

                     tempCombo.SelectedIndex = 0;
                     break;
                  }
               case TwainContainerType.Enumeration:
                  {
                     object item;
                     float fix32Value;

                     int itemsCount = twnCap.EnumerationCapability.Count;
                     for(int i = 0; i < itemsCount; i++)
                     {
                        item = twnCap.EnumerationCapability.GetValue(i);
                        fix32Value = (float)Convert.ToDouble(item);
                        tempCombo.Items.Add(fix32Value.ToString());
                     }

                     tempCombo.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex;
                     break;
                  }
               case TwainContainerType.Range:
                  {
                     float minValue = (float)Convert.ToDouble(twnCap.RangeCapability.MinimumValue);
                     float maxValue = (float)Convert.ToDouble(twnCap.RangeCapability.MaximumValue);
                     float stepSize = (float)Convert.ToDouble(twnCap.RangeCapability.StepSize);
                     float currentValue = (float)Convert.ToDouble(twnCap.RangeCapability.CurrentValue);

                     int i = 0;
                     int selIndex = 0;

                     tempCombo.Items.Add(minValue.ToString());
                     if(minValue == currentValue)
                        selIndex = i;

                     float tempValue = minValue + stepSize;
                     while(tempValue <= maxValue)
                     {
                        i++;
                        tempCombo.Items.Add(tempValue.ToString());
                        if(tempValue == currentValue)
                           selIndex = i;

                        tempValue = tempValue + stepSize;
                     }

                     tempCombo.SelectedIndex = selIndex;
                     break;
                  }
            }
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("Get {0} returns {1}", capType.ToString(), ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);

            switch(capType)
            {
               case TwainCapabilityType.ImageContrast:
                  _cmbContrast.Enabled = false;
                  break;
               case TwainCapabilityType.ImageBrightness:
                  _cmbBrightness.Enabled = false;
                  break;
               case TwainCapabilityType.ImageHighlight:
                  _cmbHighlight.Enabled = false;
                  break;
            }
         }
      }

      private void FillHalftones( )
      {
         /* ICAP_HALFTONES */
         try
         {
            TwainCapability twnCap = _twainSession.GetCapability(TwainCapabilityType.ImageHalftones, TwainGetCapabilityMode.GetValues);
            _cmbHalftone.Enabled = true;
            _cmbHalftone.Items.Clear();

            switch(twnCap.Information.ContainerType)
            {
               case TwainContainerType.OneValue:
                  {
                     object item;
                     string stringValue;

                     item = twnCap.OneValueCapability.Value;
                     stringValue = (string)Convert.ToString(item);
                     _cmbHalftone.Items.Add(stringValue);
                     _cmbHalftone.SelectedIndex = 0;
                     break;
                  }
               case TwainContainerType.Enumeration:
                  {
                     object item;
                     string stringValue;

                     int itemsCount = twnCap.EnumerationCapability.Count;
                     for(int i = 0; i < itemsCount; i++)
                     {
                        item = twnCap.EnumerationCapability.GetValue(i);
                        stringValue = (string)Convert.ToString(item);
                        _cmbHalftone.Items.Add(stringValue);
                     }

                     _cmbHalftone.SelectedIndex = twnCap.EnumerationCapability.CurrentIndex;
                     break;
                  }
               case TwainContainerType.Array:
                  {
                     object item;
                     string stringValue;

                     int itemsCount = twnCap.ArrayCapability.Count;
                     for(int i = 0; i < itemsCount; i++)
                     {
                        item = twnCap.ArrayCapability.GetValue(i);
                        stringValue = (string)Convert.ToString(item);
                        _cmbHalftone.Items.Add(stringValue);
                     }

                     _cmbHalftone.SelectedIndex = 0;
                     break;
                  }
            }
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("Get TwainCapabilityType.ImageHalftones returns {0}", ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
            _cmbHalftone.Enabled = false;
         }
      }

      private string GetFileFormatString( )
      {
         string filter = "All Files (*.*)|*.*";
         switch(_formatValue[_cmbFileFormat.SelectedIndex])
         {
            case TwainCapabilityValue.FileFormatTiff:
               filter = "TIFF Files|*.tif";
               break;
            case TwainCapabilityValue.FileFormatPict:
               filter = "PICT Files|*.pct";
               break;
            case TwainCapabilityValue.FileFormatBmp:
               filter = "BMP Files|*.bmp";
               break;
            case TwainCapabilityValue.FileFormatXbm:
               filter = "XBM Files|*.xbm";
               break;
            case TwainCapabilityValue.FileFormatJfif:
               filter = "JFIF Files|*.jpg";
               break;
            case TwainCapabilityValue.FileFormatFpx:
               filter = "FPX Files|*.fpx";
               break;
            case TwainCapabilityValue.FileFormatTiffMulti:
               filter = "TIFF Multi Files|*.tif";
               break;
            case TwainCapabilityValue.FileFormatPng:
               filter = "PNG Files|*.png";
               break;
            case TwainCapabilityValue.FileFormatSpiff:
               filter = "SPIFF Files|*.spif";
               break;
            case TwainCapabilityValue.FileFormatExif:
               filter = "EXIF Files|*.xif";
               break;
         }
         return filter;
      }

      private void _btnBrowse_Click(object sender, System.EventArgs e)
      {
         using(SaveFileDialog saveDialog = new SaveFileDialog())
         {
            saveDialog.Filter = GetFileFormatString();
            saveDialog.FilterIndex = 0;

            if(saveDialog.ShowDialog(this) == DialogResult.OK)
               _txtFileName.Text = saveDialog.FileName;

            DialogResult = DialogResult.None;
         }
      }

      private void _btnLoad_Click(object sender, System.EventArgs e)
      {
         using(OpenFileDialog openDialog = new OpenFileDialog())
         {
            openDialog.Filter = "LEAD Twain Template Files (*.ltt)|*.ltt";
            openDialog.FilterIndex = 0;

            if(openDialog.ShowDialog(this) == DialogResult.OK)
            {
               try
               {
                  _twainSession.LoadTemplateFile(openDialog.FileName);
                  InitializeTemplate();
               }
               catch(Exception ex)
               {
                  Messager.ShowError(this, ex);
               }
            }

            DialogResult = DialogResult.None;
         }
      }

      private void _btnSave_Click(object sender, System.EventArgs e)
      {
         SetCapabilities();
         using(SaveFileDialog saveDialog = new SaveFileDialog())
         {
            saveDialog.Filter = "LEAD Twain Template Files (*.ltt)|*.ltt";
            saveDialog.FilterIndex = 0;

            if(saveDialog.ShowDialog(this) == DialogResult.OK)
            {
               try
               {
                  _twainSession.SaveTemplateFile(saveDialog.FileName);
               }
               catch(Exception ex)
               {
                  Messager.ShowError(this, ex);
               }
            }

            DialogResult = DialogResult.None;
         }
      }

      private void _btnOK_Click(object sender, System.EventArgs e)
      {
         SetCapabilities();
         DialogResult = DialogResult.OK;
      }

      private void SetCapabilities( )
      {
         SetUnitsCapability();
         SetOrientationCapability();
         SetFramesCapability();
         SetXYResCapability();
         SetXferCapability();
         SetPixelTypeCapability();
         SetContrastCapability();
         SetBrightnessCapability();
         SetHighlightCapability();
         SetHalftonesCapability();
      }

      private void MySetCapability(TwainCapabilityType capType, TwainItemType itemType, object data)
      {
         using (TwainCapability twnCap = new TwainCapability())
         {
            twnCap.Information.Type = capType;
            twnCap.Information.ContainerType = TwainContainerType.OneValue;

            twnCap.OneValueCapability.ItemType = itemType;
            twnCap.OneValueCapability.Value = data;

            _twainSession.SetCapability(twnCap, TwainSetCapabilityMode.Set);
         }
      }

      private void SetUnitsCapability( )
      {
         try
         {
            _twainSession.ImageUnit = _unitsValue[_cmbUnit.SelectedIndex];
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("Set TwainCapabilityType.ImageUnits returns {0}", ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
         }
      }

      private void SetFramesCapability( )
      {
         TwainFrame frame = new TwainFrame();
         try
         {
            frame.LeftMargin = (float)Convert.ToDouble(_txtFrameLeft.Text);
            frame.TopMargin = (float)Convert.ToDouble(_txtFrameTop.Text);
            frame.RightMargin = (float)Convert.ToDouble(_txtFrameRight.Text);
            frame.BottomMargin = (float)Convert.ToDouble(_txtFrameBottom.Text);

            _twainSession.ImageFrame = frame;
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("Set TwainCapabilityType.ImageFrames returns {0}", ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
         }
      }

      private void SetXYResCapability( )
      {
         try
         {
            float xRes = (float)Convert.ToDouble(_cmbXRes.SelectedItem);
            float yRes = (float)Convert.ToDouble(_cmbYRes.SelectedItem);

            _twainSession.Resolution = new SizeF(xRes, yRes);
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("Set TwainCapabilityType.ImageXResolution Or TwainCapabilityType.ImageYResolution returns {0}", ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
         }
      }

      private void SetXferCapability( )
      {
         switch(_transferMode)
         {
            case TwainTransferMode.Native:
               /* do nothing */
               break;
            case TwainTransferMode.Buffer:
               _transferComp = (int)_compressionValue[_cmbCompression.SelectedIndex];
               break;
            case TwainTransferMode.File:
               {
                  if(_txtFileName.Text == "")
                     return;

                  _transferFile = _txtFileName.Text;

                  /* ICAP_IMAGEFILEFORMAT */
                  _transferFormat = (int)_formatValue[_cmbFileFormat.SelectedIndex];
               }
               break;
         }

         try
         {
            TwainTransferOptions to = _twainSession.TransferOptions;
            to.TransferMode = _transferMode;
            to.FileFormat = (RasterImageFormat)_transferFormat;
            to.FileName = _transferFile;
            to.CompressionMode = (TwainCompressionMode)_transferComp;
            _twainSession.TransferOptions = to;
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("SetTransferOptions returns {0}", ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
         }
      }

      private void SetPixelTypeCapability( )
      {
         int bpp = (int)TwainCapabilityValue.PixelTypeBW;
         switch(_pixelValue[_cmbPixelType.SelectedIndex])
         {
            case TwainCapabilityValue.PixelTypeBW:
               bpp = 1;
               break;
            case TwainCapabilityValue.PixelTypeGray:
               bpp = 8;
               break;
            case TwainCapabilityValue.PixelTypeRgb:
               bpp = 24;
               break;
            case TwainCapabilityValue.PixelTypePalette:
               bpp = 8;
               break;
         }

         try
         {
            MySetCapability(TwainCapabilityType.ImagePixelType, TwainItemType.Uint16, _pixelValue[_cmbPixelType.SelectedIndex]);
            _twainSession.ImageBitsPerPixel = bpp;
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("Set TwainCapabilityType.ImagePixelType returns {0}", ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
         }
      }

      private void SetOrientationCapability( )
      {
         try
         {
            TwainAcquirePageOptions pageOpts = _twainSession.AcquirePageOptions;
            pageOpts.PaperSize = TwainPaperSize.UsLetter;
            pageOpts.PaperOrientation = _orientationValue[_cmbOrientation.SelectedIndex];
            _twainSession.AcquirePageOptions = pageOpts;
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("Set TwainCapabilityType.ImageOrientation returns {0}", ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
         }
      }

      private void SetContrastCapability( )
      {
         try
         {
            float contrast = (float)Convert.ToDouble(_cmbContrast.SelectedItem);
            TwainImageEffects ie = _twainSession.ImageEffects;
            ie.Contrast = contrast;
            _twainSession.ImageEffects = ie;
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("Set TwainCapabilityType.ImageContrast returns {0}", ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
         }
      }

      private void SetBrightnessCapability( )
      {
         try
         {
            float brightness = (float)Convert.ToDouble(_cmbBrightness.SelectedItem);
            TwainImageEffects ie = _twainSession.ImageEffects;
            ie.Brightness = brightness;
            _twainSession.ImageEffects = ie;
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("Set TwainCapabilityType.ImageBrightness returns {0}", ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
         }
      }

      private void SetHighlightCapability( )
      {
         try
         {
            float highlight = (float)Convert.ToDouble(_cmbHighlight.SelectedItem);
            TwainImageEffects ie = _twainSession.ImageEffects;
            ie.Highlight = highlight;
            _twainSession.ImageEffects = ie;
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("Set TwainCapabilityType.ImageHighLight returns {0}", ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
         }
      }

      private void SetHalftonesCapability()
      {
         try
         {
            MySetCapability(TwainCapabilityType.ImageHalftones, TwainItemType.Str32, _cmbHalftone.GetItemText(_cmbHalftone.SelectedItem));
         }
         catch (Exception ex)
         {
            string errorMsg = string.Format("Set TwainCapabilityType.ImageHalftones returns {0}", ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
         }
      }

      private void _txtFileName_TextChanged(object sender, System.EventArgs e)
      {
         CheckOkButton();
      }

      private void _cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
      {
         SetUnitsCapability();
         FillFrameCaps();
         FillXYRes();
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         MySetCapability(TwainCapabilityType.ImageUnits, TwainItemType.Uint16, (int)_unitsValue[_selectedUnitsIndex]);
      }
   }
}
