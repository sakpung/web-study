// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

using Leadtools;

namespace MrcSegmentationDemo
{
   /// <summary>
   /// Summary description for Options.
   /// </summary>
   public class Options : System.Windows.Forms.Form
   {
      private System.Windows.Forms.TabControl tanctrlOptions;
      private System.Windows.Forms.TabPage tabMrcCompressions;
      private System.Windows.Forms.TabPage tabPDFCompressions;
      private System.Windows.Forms.TabPage tabCombine;
      private System.Windows.Forms.TabPage tabColors;
      private System.Windows.Forms.ComboBox _cb1BitTxtMaskCom;
      private System.Windows.Forms.Label _lbl1BitTxtMaskCom;
      private System.Windows.Forms.ComboBox _cb2BitGrayscaleCom;
      private System.Windows.Forms.Label _lblMrcCom6;
      private System.Windows.Forms.ComboBox _cb2BitTxtClrCom;
      private System.Windows.Forms.Label _lblMrcCom5;
      private System.Windows.Forms.TextBox _txtGrayscaleFactor;
      private System.Windows.Forms.Label _lblMrcCom4;
      private System.Windows.Forms.ComboBox _cb8BitGrayCom;
      private System.Windows.Forms.Label _lblMrcCom3;
      private System.Windows.Forms.TextBox _txtMrcClrQualityFactor;
      private System.Windows.Forms.Label _lblMrcCom2;
      private System.Windows.Forms.ComboBox _cb24BitClrPicCom;
      private System.Windows.Forms.Label _lblMrcCom1;
      private System.Windows.Forms.ComboBox _cb1BitCom;
      private System.Windows.Forms.Label _lbl1BitCom;
      private System.Windows.Forms.ComboBox _cb2BitCom;
      private System.Windows.Forms.Label _lblPDFCom3;
      private System.Windows.Forms.TextBox _txtPDFClrQualityFactor;
      private System.Windows.Forms.Label _lblPDFCom2;
      private System.Windows.Forms.ComboBox _cbPicCom;
      private System.Windows.Forms.Label _lblPDFCom1;
      private System.Windows.Forms.GroupBox _groupBox2;
      private System.Windows.Forms.CheckBox _chckSearchForBackBG;
      private System.Windows.Forms.ComboBox _cbTypes;
      private System.Windows.Forms.TextBox _txtClrThreshold;
      private System.Windows.Forms.TextBox _txtQuality;
      private System.Windows.Forms.TrackBar _tbClrThreshold;
      private System.Windows.Forms.TrackBar _tbQuality;
      private System.Windows.Forms.Label _lblSeg6;
      private System.Windows.Forms.Label _lblSeg5;
      private System.Windows.Forms.Label _lblSeg4;
      private System.Windows.Forms.ComboBox _cbOutputImage;
      private System.Windows.Forms.GroupBox _groupBox1;
      private System.Windows.Forms.TextBox _txtCombineThreshold;
      private System.Windows.Forms.TextBox _txtCleanSize;
      private System.Windows.Forms.TextBox _txtBgThreshold;
      private System.Windows.Forms.TrackBar _tbCombineThreshold;
      private System.Windows.Forms.TrackBar _tbCleanSize;
      private System.Windows.Forms.Label _lblSeg3;
      private System.Windows.Forms.Label _lblSeg2;
      private System.Windows.Forms.Label _lblSeg1;
      private System.Windows.Forms.ComboBox _cbInputImage;
      private System.Windows.Forms.ComboBox _cbCombiningType;
      private System.Windows.Forms.TextBox _txtCombiningFactor;
      private System.Windows.Forms.TrackBar _tbCombiningFactor;
      private System.Windows.Forms.Label _lblCombine2;
      private System.Windows.Forms.Label _lblCombine1;
      private System.Windows.Forms.Button _btnFGClr;
      private System.Windows.Forms.Label _lblForegroundClr;
      private System.Windows.Forms.Button _btnBGClr;
      private System.Windows.Forms.Label _lblBackgroundClr;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.TabPage _tabSegmentation;
      private System.Windows.Forms.TrackBar _tbBgThreshold;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public Options( )
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
         FillControls();
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
         this.tanctrlOptions = new System.Windows.Forms.TabControl();
         this.tabMrcCompressions = new System.Windows.Forms.TabPage();
         this._cb1BitTxtMaskCom = new System.Windows.Forms.ComboBox();
         this._lbl1BitTxtMaskCom = new System.Windows.Forms.Label();
         this._cb2BitGrayscaleCom = new System.Windows.Forms.ComboBox();
         this._lblMrcCom6 = new System.Windows.Forms.Label();
         this._cb2BitTxtClrCom = new System.Windows.Forms.ComboBox();
         this._lblMrcCom5 = new System.Windows.Forms.Label();
         this._txtGrayscaleFactor = new System.Windows.Forms.TextBox();
         this._lblMrcCom4 = new System.Windows.Forms.Label();
         this._cb8BitGrayCom = new System.Windows.Forms.ComboBox();
         this._lblMrcCom3 = new System.Windows.Forms.Label();
         this._txtMrcClrQualityFactor = new System.Windows.Forms.TextBox();
         this._lblMrcCom2 = new System.Windows.Forms.Label();
         this._cb24BitClrPicCom = new System.Windows.Forms.ComboBox();
         this._lblMrcCom1 = new System.Windows.Forms.Label();
         this.tabPDFCompressions = new System.Windows.Forms.TabPage();
         this._cb1BitCom = new System.Windows.Forms.ComboBox();
         this._lbl1BitCom = new System.Windows.Forms.Label();
         this._cb2BitCom = new System.Windows.Forms.ComboBox();
         this._lblPDFCom3 = new System.Windows.Forms.Label();
         this._txtPDFClrQualityFactor = new System.Windows.Forms.TextBox();
         this._lblPDFCom2 = new System.Windows.Forms.Label();
         this._cbPicCom = new System.Windows.Forms.ComboBox();
         this._lblPDFCom1 = new System.Windows.Forms.Label();
         this._tabSegmentation = new System.Windows.Forms.TabPage();
         this._groupBox2 = new System.Windows.Forms.GroupBox();
         this._chckSearchForBackBG = new System.Windows.Forms.CheckBox();
         this._cbTypes = new System.Windows.Forms.ComboBox();
         this._txtClrThreshold = new System.Windows.Forms.TextBox();
         this._txtQuality = new System.Windows.Forms.TextBox();
         this._tbClrThreshold = new System.Windows.Forms.TrackBar();
         this._tbQuality = new System.Windows.Forms.TrackBar();
         this._lblSeg6 = new System.Windows.Forms.Label();
         this._lblSeg5 = new System.Windows.Forms.Label();
         this._lblSeg4 = new System.Windows.Forms.Label();
         this._cbOutputImage = new System.Windows.Forms.ComboBox();
         this._groupBox1 = new System.Windows.Forms.GroupBox();
         this._txtCombineThreshold = new System.Windows.Forms.TextBox();
         this._txtCleanSize = new System.Windows.Forms.TextBox();
         this._txtBgThreshold = new System.Windows.Forms.TextBox();
         this._tbCombineThreshold = new System.Windows.Forms.TrackBar();
         this._tbCleanSize = new System.Windows.Forms.TrackBar();
         this._tbBgThreshold = new System.Windows.Forms.TrackBar();
         this._lblSeg3 = new System.Windows.Forms.Label();
         this._lblSeg2 = new System.Windows.Forms.Label();
         this._lblSeg1 = new System.Windows.Forms.Label();
         this._cbInputImage = new System.Windows.Forms.ComboBox();
         this.tabCombine = new System.Windows.Forms.TabPage();
         this._cbCombiningType = new System.Windows.Forms.ComboBox();
         this._txtCombiningFactor = new System.Windows.Forms.TextBox();
         this._tbCombiningFactor = new System.Windows.Forms.TrackBar();
         this._lblCombine2 = new System.Windows.Forms.Label();
         this._lblCombine1 = new System.Windows.Forms.Label();
         this.tabColors = new System.Windows.Forms.TabPage();
         this._btnFGClr = new System.Windows.Forms.Button();
         this._lblForegroundClr = new System.Windows.Forms.Label();
         this._btnBGClr = new System.Windows.Forms.Button();
         this._lblBackgroundClr = new System.Windows.Forms.Label();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this.tanctrlOptions.SuspendLayout();
         this.tabMrcCompressions.SuspendLayout();
         this.tabPDFCompressions.SuspendLayout();
         this._tabSegmentation.SuspendLayout();
         this._groupBox2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._tbClrThreshold)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbQuality)).BeginInit();
         this._groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._tbCombineThreshold)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbCleanSize)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbBgThreshold)).BeginInit();
         this.tabCombine.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._tbCombiningFactor)).BeginInit();
         this.tabColors.SuspendLayout();
         this.SuspendLayout();
         // 
         // tanctrlOptions
         // 
         this.tanctrlOptions.Controls.Add(this.tabMrcCompressions);
         this.tanctrlOptions.Controls.Add(this.tabPDFCompressions);
         this.tanctrlOptions.Controls.Add(this._tabSegmentation);
         this.tanctrlOptions.Controls.Add(this.tabCombine);
         this.tanctrlOptions.Controls.Add(this.tabColors);
         this.tanctrlOptions.Location = new System.Drawing.Point(8, 8);
         this.tanctrlOptions.Name = "tanctrlOptions";
         this.tanctrlOptions.SelectedIndex = 0;
         this.tanctrlOptions.Size = new System.Drawing.Size(408, 360);
         this.tanctrlOptions.TabIndex = 0;
         this.tanctrlOptions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tanctrlOptions_KeyDown);
         // 
         // tabMrcCompressions
         // 
         this.tabMrcCompressions.Controls.Add(this._cb1BitTxtMaskCom);
         this.tabMrcCompressions.Controls.Add(this._lbl1BitTxtMaskCom);
         this.tabMrcCompressions.Controls.Add(this._cb2BitGrayscaleCom);
         this.tabMrcCompressions.Controls.Add(this._lblMrcCom6);
         this.tabMrcCompressions.Controls.Add(this._cb2BitTxtClrCom);
         this.tabMrcCompressions.Controls.Add(this._lblMrcCom5);
         this.tabMrcCompressions.Controls.Add(this._txtGrayscaleFactor);
         this.tabMrcCompressions.Controls.Add(this._lblMrcCom4);
         this.tabMrcCompressions.Controls.Add(this._cb8BitGrayCom);
         this.tabMrcCompressions.Controls.Add(this._lblMrcCom3);
         this.tabMrcCompressions.Controls.Add(this._txtMrcClrQualityFactor);
         this.tabMrcCompressions.Controls.Add(this._lblMrcCom2);
         this.tabMrcCompressions.Controls.Add(this._cb24BitClrPicCom);
         this.tabMrcCompressions.Controls.Add(this._lblMrcCom1);
         this.tabMrcCompressions.Location = new System.Drawing.Point(4, 22);
         this.tabMrcCompressions.Name = "tabMrcCompressions";
         this.tabMrcCompressions.Size = new System.Drawing.Size(400, 334);
         this.tabMrcCompressions.TabIndex = 0;
         this.tabMrcCompressions.Text = "Mrc Compressions";
         // 
         // _cb1BitTxtMaskCom
         // 
         this._cb1BitTxtMaskCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cb1BitTxtMaskCom.Location = new System.Drawing.Point(21, 278);
         this._cb1BitTxtMaskCom.Name = "_cb1BitTxtMaskCom";
         this._cb1BitTxtMaskCom.Size = new System.Drawing.Size(205, 21);
         this._cb1BitTxtMaskCom.TabIndex = 13;
         this._cb1BitTxtMaskCom.SelectedIndexChanged += new System.EventHandler(this._cb1BitTxtMaskCom_SelectedIndexChanged);
         // 
         // _lbl1BitTxtMaskCom
         // 
         this._lbl1BitTxtMaskCom.Location = new System.Drawing.Point(21, 262);
         this._lbl1BitTxtMaskCom.Name = "_lbl1BitTxtMaskCom";
         this._lbl1BitTxtMaskCom.Size = new System.Drawing.Size(176, 16);
         this._lbl1BitTxtMaskCom.TabIndex = 12;
         this._lbl1BitTxtMaskCom.Text = "1-Bit Text/&Mask Compression";
         // 
         // _cb2BitGrayscaleCom
         // 
         this._cb2BitGrayscaleCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cb2BitGrayscaleCom.Location = new System.Drawing.Point(21, 234);
         this._cb2BitGrayscaleCom.Name = "_cb2BitGrayscaleCom";
         this._cb2BitGrayscaleCom.Size = new System.Drawing.Size(205, 21);
         this._cb2BitGrayscaleCom.TabIndex = 11;
         this._cb2BitGrayscaleCom.SelectedIndexChanged += new System.EventHandler(this._cb2BitGrayscaleCom_SelectedIndexChanged);
         // 
         // _lblMrcCom6
         // 
         this._lblMrcCom6.Location = new System.Drawing.Point(21, 218);
         this._lblMrcCom6.Name = "_lblMrcCom6";
         this._lblMrcCom6.Size = new System.Drawing.Size(176, 16);
         this._lblMrcCom6.TabIndex = 10;
         this._lblMrcCom6.Text = "2-Bit G&rayscale Compression";
         // 
         // _cb2BitTxtClrCom
         // 
         this._cb2BitTxtClrCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cb2BitTxtClrCom.Location = new System.Drawing.Point(21, 192);
         this._cb2BitTxtClrCom.Name = "_cb2BitTxtClrCom";
         this._cb2BitTxtClrCom.Size = new System.Drawing.Size(205, 21);
         this._cb2BitTxtClrCom.TabIndex = 9;
         this._cb2BitTxtClrCom.SelectedIndexChanged += new System.EventHandler(this._cb2BitTxtClrCom_SelectedIndexChanged);
         // 
         // _lblMrcCom5
         // 
         this._lblMrcCom5.Location = new System.Drawing.Point(21, 174);
         this._lblMrcCom5.Name = "_lblMrcCom5";
         this._lblMrcCom5.Size = new System.Drawing.Size(176, 16);
         this._lblMrcCom5.TabIndex = 8;
         this._lblMrcCom5.Text = "2-Bit Te&xt Colored Compression";
         // 
         // _txtGrayscaleFactor
         // 
         this._txtGrayscaleFactor.Enabled = false;
         this._txtGrayscaleFactor.Location = new System.Drawing.Point(168, 144);
         this._txtGrayscaleFactor.MaxLength = 3;
         this._txtGrayscaleFactor.Name = "_txtGrayscaleFactor";
         this._txtGrayscaleFactor.Size = new System.Drawing.Size(56, 20);
         this._txtGrayscaleFactor.TabIndex = 7;
         this._txtGrayscaleFactor.Leave += new System.EventHandler(this._txtGrayscaleFactor_Leave);
         this._txtGrayscaleFactor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txt_KeyPress);
         // 
         // _lblMrcCom4
         // 
         this._lblMrcCom4.Location = new System.Drawing.Point(20, 146);
         this._lblMrcCom4.Name = "_lblMrcCom4";
         this._lblMrcCom4.Size = new System.Drawing.Size(136, 16);
         this._lblMrcCom4.TabIndex = 6;
         this._lblMrcCom4.Text = "&Grayscale Quality Factor";
         // 
         // _cb8BitGrayCom
         // 
         this._cb8BitGrayCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cb8BitGrayCom.Location = new System.Drawing.Point(18, 115);
         this._cb8BitGrayCom.Name = "_cb8BitGrayCom";
         this._cb8BitGrayCom.Size = new System.Drawing.Size(205, 21);
         this._cb8BitGrayCom.TabIndex = 5;
         this._cb8BitGrayCom.SelectedIndexChanged += new System.EventHandler(this._cb8BitGrayCom_SelectedIndexChanged);
         // 
         // _lblMrcCom3
         // 
         this._lblMrcCom3.Location = new System.Drawing.Point(20, 96);
         this._lblMrcCom3.Name = "_lblMrcCom3";
         this._lblMrcCom3.Size = new System.Drawing.Size(176, 16);
         this._lblMrcCom3.TabIndex = 4;
         this._lblMrcCom3.Text = "&8-Bit Grayscale Compression";
         // 
         // _txtMrcClrQualityFactor
         // 
         this._txtMrcClrQualityFactor.Location = new System.Drawing.Point(168, 63);
         this._txtMrcClrQualityFactor.MaxLength = 3;
         this._txtMrcClrQualityFactor.Name = "_txtMrcClrQualityFactor";
         this._txtMrcClrQualityFactor.Size = new System.Drawing.Size(56, 20);
         this._txtMrcClrQualityFactor.TabIndex = 3;
         this._txtMrcClrQualityFactor.Leave += new System.EventHandler(this._txtMrcClrQualityFactor_Leave);
         this._txtMrcClrQualityFactor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txt_KeyPress);
         // 
         // _lblMrcCom2
         // 
         this._lblMrcCom2.Location = new System.Drawing.Point(22, 64);
         this._lblMrcCom2.Name = "_lblMrcCom2";
         this._lblMrcCom2.Size = new System.Drawing.Size(108, 16);
         this._lblMrcCom2.TabIndex = 2;
         this._lblMrcCom2.Text = "Color &Quality Factor";
         // 
         // _cb24BitClrPicCom
         // 
         this._cb24BitClrPicCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cb24BitClrPicCom.Location = new System.Drawing.Point(19, 35);
         this._cb24BitClrPicCom.Name = "_cb24BitClrPicCom";
         this._cb24BitClrPicCom.Size = new System.Drawing.Size(205, 21);
         this._cb24BitClrPicCom.TabIndex = 1;
         this._cb24BitClrPicCom.SelectedIndexChanged += new System.EventHandler(this._cb24BitClrPicCom_SelectedIndexChanged);
         // 
         // _lblMrcCom1
         // 
         this._lblMrcCom1.Location = new System.Drawing.Point(20, 16);
         this._lblMrcCom1.Name = "_lblMrcCom1";
         this._lblMrcCom1.Size = new System.Drawing.Size(176, 16);
         this._lblMrcCom1.TabIndex = 0;
         this._lblMrcCom1.Text = "2&4-Bit Color Picture Compression";
         // 
         // tabPDFCompressions
         // 
         this.tabPDFCompressions.Controls.Add(this._cb1BitCom);
         this.tabPDFCompressions.Controls.Add(this._lbl1BitCom);
         this.tabPDFCompressions.Controls.Add(this._cb2BitCom);
         this.tabPDFCompressions.Controls.Add(this._lblPDFCom3);
         this.tabPDFCompressions.Controls.Add(this._txtPDFClrQualityFactor);
         this.tabPDFCompressions.Controls.Add(this._lblPDFCom2);
         this.tabPDFCompressions.Controls.Add(this._cbPicCom);
         this.tabPDFCompressions.Controls.Add(this._lblPDFCom1);
         this.tabPDFCompressions.Location = new System.Drawing.Point(4, 22);
         this.tabPDFCompressions.Name = "tabPDFCompressions";
         this.tabPDFCompressions.Size = new System.Drawing.Size(400, 334);
         this.tabPDFCompressions.TabIndex = 1;
         this.tabPDFCompressions.Text = "PDF Compressions";
         // 
         // _cb1BitCom
         // 
         this._cb1BitCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cb1BitCom.Location = new System.Drawing.Point(19, 158);
         this._cb1BitCom.Name = "_cb1BitCom";
         this._cb1BitCom.Size = new System.Drawing.Size(205, 21);
         this._cb1BitCom.TabIndex = 7;
         this._cb1BitCom.SelectedIndexChanged += new System.EventHandler(this._cb1BitCom_SelectedIndexChanged);
         // 
         // _lbl1BitCom
         // 
         this._lbl1BitCom.Location = new System.Drawing.Point(19, 142);
         this._lbl1BitCom.Name = "_lbl1BitCom";
         this._lbl1BitCom.Size = new System.Drawing.Size(176, 16);
         this._lbl1BitCom.TabIndex = 6;
         this._lbl1BitCom.Text = "&1-Bit Compression";
         // 
         // _cb2BitCom
         // 
         this._cb2BitCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cb2BitCom.Location = new System.Drawing.Point(19, 110);
         this._cb2BitCom.Name = "_cb2BitCom";
         this._cb2BitCom.Size = new System.Drawing.Size(205, 21);
         this._cb2BitCom.TabIndex = 5;
         this._cb2BitCom.SelectedIndexChanged += new System.EventHandler(this._cb2BitCom_SelectedIndexChanged);
         // 
         // _lblPDFCom3
         // 
         this._lblPDFCom3.Location = new System.Drawing.Point(19, 94);
         this._lblPDFCom3.Name = "_lblPDFCom3";
         this._lblPDFCom3.Size = new System.Drawing.Size(176, 16);
         this._lblPDFCom3.TabIndex = 4;
         this._lblPDFCom3.Text = "&2-Bit Compression";
         // 
         // _txtPDFClrQualityFactor
         // 
         this._txtPDFClrQualityFactor.Location = new System.Drawing.Point(168, 63);
         this._txtPDFClrQualityFactor.MaxLength = 3;
         this._txtPDFClrQualityFactor.Name = "_txtPDFClrQualityFactor";
         this._txtPDFClrQualityFactor.Size = new System.Drawing.Size(56, 20);
         this._txtPDFClrQualityFactor.TabIndex = 3;
         this._txtPDFClrQualityFactor.Leave += new System.EventHandler(this._txtPDFClrQualityFactor_Leave);
         this._txtPDFClrQualityFactor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txt_KeyPress);
         // 
         // _lblPDFCom2
         // 
         this._lblPDFCom2.Location = new System.Drawing.Point(22, 64);
         this._lblPDFCom2.Name = "_lblPDFCom2";
         this._lblPDFCom2.Size = new System.Drawing.Size(108, 16);
         this._lblPDFCom2.TabIndex = 2;
         this._lblPDFCom2.Text = "Color &Quality Factor";
         // 
         // _cbPicCom
         // 
         this._cbPicCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbPicCom.Location = new System.Drawing.Point(19, 35);
         this._cbPicCom.Name = "_cbPicCom";
         this._cbPicCom.Size = new System.Drawing.Size(205, 21);
         this._cbPicCom.TabIndex = 1;
         this._cbPicCom.SelectedIndexChanged += new System.EventHandler(this._cbPicCom_SelectedIndexChanged);
         // 
         // _lblPDFCom1
         // 
         this._lblPDFCom1.Location = new System.Drawing.Point(20, 16);
         this._lblPDFCom1.Name = "_lblPDFCom1";
         this._lblPDFCom1.Size = new System.Drawing.Size(176, 16);
         this._lblPDFCom1.TabIndex = 0;
         this._lblPDFCom1.Text = "&Picture Compression";
         // 
         // _tabSegmentation
         // 
         this._tabSegmentation.Controls.Add(this._groupBox2);
         this._tabSegmentation.Controls.Add(this._groupBox1);
         this._tabSegmentation.Location = new System.Drawing.Point(4, 22);
         this._tabSegmentation.Name = "_tabSegmentation";
         this._tabSegmentation.Size = new System.Drawing.Size(400, 334);
         this._tabSegmentation.TabIndex = 2;
         this._tabSegmentation.Text = "Segmentation";
         // 
         // _groupBox2
         // 
         this._groupBox2.Controls.Add(this._chckSearchForBackBG);
         this._groupBox2.Controls.Add(this._cbTypes);
         this._groupBox2.Controls.Add(this._txtClrThreshold);
         this._groupBox2.Controls.Add(this._txtQuality);
         this._groupBox2.Controls.Add(this._tbClrThreshold);
         this._groupBox2.Controls.Add(this._tbQuality);
         this._groupBox2.Controls.Add(this._lblSeg6);
         this._groupBox2.Controls.Add(this._lblSeg5);
         this._groupBox2.Controls.Add(this._lblSeg4);
         this._groupBox2.Controls.Add(this._cbOutputImage);
         this._groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._groupBox2.Location = new System.Drawing.Point(24, 168);
         this._groupBox2.Name = "_groupBox2";
         this._groupBox2.Size = new System.Drawing.Size(360, 152);
         this._groupBox2.TabIndex = 1;
         this._groupBox2.TabStop = false;
         this._groupBox2.Text = "&Output Image Quality";
         // 
         // _chckSearchForBackBG
         // 
         this._chckSearchForBackBG.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._chckSearchForBackBG.Location = new System.Drawing.Point(200, 120);
         this._chckSearchForBackBG.Name = "_chckSearchForBackBG";
         this._chckSearchForBackBG.Size = new System.Drawing.Size(152, 24);
         this._chckSearchForBackBG.TabIndex = 9;
         this._chckSearchForBackBG.Text = "Searc&h For Background";
         this._chckSearchForBackBG.CheckedChanged += new System.EventHandler(this._chckSearchForBackBG_CheckedChanged);
         // 
         // _cbTypes
         // 
         this._cbTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbTypes.Location = new System.Drawing.Point(48, 120);
         this._cbTypes.Name = "_cbTypes";
         this._cbTypes.Size = new System.Drawing.Size(121, 21);
         this._cbTypes.TabIndex = 8;
         this._cbTypes.SelectedIndexChanged += new System.EventHandler(this._cbTypes_SelectedIndexChanged);
         // 
         // _txtClrThreshold
         // 
         this._txtClrThreshold.Location = new System.Drawing.Point(304, 85);
         this._txtClrThreshold.Name = "_txtClrThreshold";
         this._txtClrThreshold.Size = new System.Drawing.Size(48, 20);
         this._txtClrThreshold.TabIndex = 5;
         this._txtClrThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txt_KeyPress);
         this._txtClrThreshold.TextChanged += new System.EventHandler(this._txtClrThreshold_TextChanged);
         // 
         // _txtQuality
         // 
         this._txtQuality.Location = new System.Drawing.Point(304, 55);
         this._txtQuality.Name = "_txtQuality";
         this._txtQuality.Size = new System.Drawing.Size(48, 20);
         this._txtQuality.TabIndex = 2;
         this._txtQuality.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txt_KeyPress);
         this._txtQuality.TextChanged += new System.EventHandler(this._txtQuality_TextChanged);
         // 
         // _tbClrThreshold
         // 
         this._tbClrThreshold.AutoSize = false;
         this._tbClrThreshold.Location = new System.Drawing.Point(134, 83);
         this._tbClrThreshold.Maximum = 100;
         this._tbClrThreshold.Name = "_tbClrThreshold";
         this._tbClrThreshold.Size = new System.Drawing.Size(168, 24);
         this._tbClrThreshold.TabIndex = 6;
         this._tbClrThreshold.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbClrThreshold.Scroll += new System.EventHandler(this._tbClrThreshold_Scroll);
         // 
         // _tbQuality
         // 
         this._tbQuality.AutoSize = false;
         this._tbQuality.Location = new System.Drawing.Point(134, 54);
         this._tbQuality.Maximum = 100;
         this._tbQuality.Name = "_tbQuality";
         this._tbQuality.Size = new System.Drawing.Size(168, 24);
         this._tbQuality.TabIndex = 3;
         this._tbQuality.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbQuality.Scroll += new System.EventHandler(this._tbQuality_Scroll);
         // 
         // _lblSeg6
         // 
         this._lblSeg6.Location = new System.Drawing.Point(8, 121);
         this._lblSeg6.Name = "_lblSeg6";
         this._lblSeg6.Size = new System.Drawing.Size(40, 15);
         this._lblSeg6.TabIndex = 7;
         this._lblSeg6.Text = "&Type:";
         // 
         // _lblSeg5
         // 
         this._lblSeg5.Location = new System.Drawing.Point(8, 89);
         this._lblSeg5.Name = "_lblSeg5";
         this._lblSeg5.Size = new System.Drawing.Size(100, 15);
         this._lblSeg5.TabIndex = 4;
         this._lblSeg5.Text = "Co&lor Threshold:";
         // 
         // _lblSeg4
         // 
         this._lblSeg4.Location = new System.Drawing.Point(8, 57);
         this._lblSeg4.Name = "_lblSeg4";
         this._lblSeg4.Size = new System.Drawing.Size(128, 15);
         this._lblSeg4.TabIndex = 1;
         this._lblSeg4.Text = "&Quality %:";
         // 
         // _cbOutputImage
         // 
         this._cbOutputImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbOutputImage.Location = new System.Drawing.Point(10, 24);
         this._cbOutputImage.Name = "_cbOutputImage";
         this._cbOutputImage.Size = new System.Drawing.Size(156, 21);
         this._cbOutputImage.TabIndex = 0;
         this._cbOutputImage.SelectedIndexChanged += new System.EventHandler(this._cbOutputImage_SelectedIndexChanged);
         // 
         // _groupBox1
         // 
         this._groupBox1.Controls.Add(this._txtCombineThreshold);
         this._groupBox1.Controls.Add(this._txtCleanSize);
         this._groupBox1.Controls.Add(this._txtBgThreshold);
         this._groupBox1.Controls.Add(this._tbCombineThreshold);
         this._groupBox1.Controls.Add(this._tbCleanSize);
         this._groupBox1.Controls.Add(this._tbBgThreshold);
         this._groupBox1.Controls.Add(this._lblSeg3);
         this._groupBox1.Controls.Add(this._lblSeg2);
         this._groupBox1.Controls.Add(this._lblSeg1);
         this._groupBox1.Controls.Add(this._cbInputImage);
         this._groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._groupBox1.Location = new System.Drawing.Point(24, 16);
         this._groupBox1.Name = "_groupBox1";
         this._groupBox1.Size = new System.Drawing.Size(360, 152);
         this._groupBox1.TabIndex = 0;
         this._groupBox1.TabStop = false;
         this._groupBox1.Text = "&Input Image Quality";
         // 
         // _txtCombineThreshold
         // 
         this._txtCombineThreshold.Location = new System.Drawing.Point(304, 117);
         this._txtCombineThreshold.Name = "_txtCombineThreshold";
         this._txtCombineThreshold.Size = new System.Drawing.Size(48, 20);
         this._txtCombineThreshold.TabIndex = 8;
         this._txtCombineThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txt_KeyPress);
         this._txtCombineThreshold.TextChanged += new System.EventHandler(this._txtCombineThreshold_TextChanged);
         // 
         // _txtCleanSize
         // 
         this._txtCleanSize.Location = new System.Drawing.Point(304, 85);
         this._txtCleanSize.Name = "_txtCleanSize";
         this._txtCleanSize.Size = new System.Drawing.Size(48, 20);
         this._txtCleanSize.TabIndex = 5;
         this._txtCleanSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txt_KeyPress);
         this._txtCleanSize.TextChanged += new System.EventHandler(this._txtCleanSize_TextChanged);
         // 
         // _txtBgThreshold
         // 
         this._txtBgThreshold.Location = new System.Drawing.Point(304, 55);
         this._txtBgThreshold.Name = "_txtBgThreshold";
         this._txtBgThreshold.Size = new System.Drawing.Size(48, 20);
         this._txtBgThreshold.TabIndex = 2;
         this._txtBgThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txt_KeyPress);
         this._txtBgThreshold.TextChanged += new System.EventHandler(this._txtBgThreshold_TextChanged);
         // 
         // _tbCombineThreshold
         // 
         this._tbCombineThreshold.AutoSize = false;
         this._tbCombineThreshold.Location = new System.Drawing.Point(133, 116);
         this._tbCombineThreshold.Maximum = 300;
         this._tbCombineThreshold.Name = "_tbCombineThreshold";
         this._tbCombineThreshold.Size = new System.Drawing.Size(168, 24);
         this._tbCombineThreshold.TabIndex = 9;
         this._tbCombineThreshold.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbCombineThreshold.Scroll += new System.EventHandler(this._tbCombineThreshold_Scroll);
         // 
         // _tbCleanSize
         // 
         this._tbCleanSize.AutoSize = false;
         this._tbCleanSize.Location = new System.Drawing.Point(134, 83);
         this._tbCleanSize.Name = "_tbCleanSize";
         this._tbCleanSize.Size = new System.Drawing.Size(168, 24);
         this._tbCleanSize.TabIndex = 6;
         this._tbCleanSize.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbCleanSize.Scroll += new System.EventHandler(this._tbCleanSize_Scroll);
         // 
         // _tbBgThreshold
         // 
         this._tbBgThreshold.AutoSize = false;
         this._tbBgThreshold.Location = new System.Drawing.Point(134, 54);
         this._tbBgThreshold.Maximum = 100;
         this._tbBgThreshold.Name = "_tbBgThreshold";
         this._tbBgThreshold.Size = new System.Drawing.Size(168, 24);
         this._tbBgThreshold.TabIndex = 3;
         this._tbBgThreshold.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbBgThreshold.Scroll += new System.EventHandler(this._tbbgThreshold_Scroll);
         // 
         // _lblSeg3
         // 
         this._lblSeg3.Location = new System.Drawing.Point(8, 121);
         this._lblSeg3.Name = "_lblSeg3";
         this._lblSeg3.Size = new System.Drawing.Size(112, 15);
         this._lblSeg3.TabIndex = 7;
         this._lblSeg3.Text = "Co&mbine Threshold:";
         // 
         // _lblSeg2
         // 
         this._lblSeg2.Location = new System.Drawing.Point(8, 89);
         this._lblSeg2.Name = "_lblSeg2";
         this._lblSeg2.Size = new System.Drawing.Size(100, 15);
         this._lblSeg2.TabIndex = 4;
         this._lblSeg2.Text = "Clean Si&ze:";
         // 
         // _lblSeg1
         // 
         this._lblSeg1.Location = new System.Drawing.Point(8, 57);
         this._lblSeg1.Name = "_lblSeg1";
         this._lblSeg1.Size = new System.Drawing.Size(128, 15);
         this._lblSeg1.TabIndex = 1;
         this._lblSeg1.Text = "&Background Threshold:";
         // 
         // _cbInputImage
         // 
         this._cbInputImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbInputImage.Location = new System.Drawing.Point(12, 22);
         this._cbInputImage.Name = "_cbInputImage";
         this._cbInputImage.Size = new System.Drawing.Size(156, 21);
         this._cbInputImage.TabIndex = 0;
         this._cbInputImage.SelectedIndexChanged += new System.EventHandler(this._cbInputImage_SelectedIndexChanged);
         // 
         // tabCombine
         // 
         this.tabCombine.Controls.Add(this._cbCombiningType);
         this.tabCombine.Controls.Add(this._txtCombiningFactor);
         this.tabCombine.Controls.Add(this._tbCombiningFactor);
         this.tabCombine.Controls.Add(this._lblCombine2);
         this.tabCombine.Controls.Add(this._lblCombine1);
         this.tabCombine.Location = new System.Drawing.Point(4, 22);
         this.tabCombine.Name = "tabCombine";
         this.tabCombine.Size = new System.Drawing.Size(400, 334);
         this.tabCombine.TabIndex = 3;
         this.tabCombine.Text = "Combine";
         // 
         // _cbCombiningType
         // 
         this._cbCombiningType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbCombiningType.Location = new System.Drawing.Point(153, 56);
         this._cbCombiningType.Name = "_cbCombiningType";
         this._cbCombiningType.Size = new System.Drawing.Size(121, 21);
         this._cbCombiningType.TabIndex = 4;
         this._cbCombiningType.SelectedIndexChanged += new System.EventHandler(this._cbCombiningType_SelectedIndexChanged);
         // 
         // _txtCombiningFactor
         // 
         this._txtCombiningFactor.Location = new System.Drawing.Point(320, 24);
         this._txtCombiningFactor.Name = "_txtCombiningFactor";
         this._txtCombiningFactor.Size = new System.Drawing.Size(48, 20);
         this._txtCombiningFactor.TabIndex = 1;
         this._txtCombiningFactor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txt_KeyPress);
         this._txtCombiningFactor.TextChanged += new System.EventHandler(this._txtCombiningFactor_TextChanged);
         // 
         // _tbCombiningFactor
         // 
         this._tbCombiningFactor.AutoSize = false;
         this._tbCombiningFactor.Location = new System.Drawing.Point(144, 24);
         this._tbCombiningFactor.Maximum = 100;
         this._tbCombiningFactor.Name = "_tbCombiningFactor";
         this._tbCombiningFactor.Size = new System.Drawing.Size(168, 24);
         this._tbCombiningFactor.TabIndex = 2;
         this._tbCombiningFactor.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbCombiningFactor.Scroll += new System.EventHandler(this._tbCombiningFactor_Scroll);
         // 
         // _lblCombine2
         // 
         this._lblCombine2.Location = new System.Drawing.Point(24, 56);
         this._lblCombine2.Name = "_lblCombine2";
         this._lblCombine2.Size = new System.Drawing.Size(88, 15);
         this._lblCombine2.TabIndex = 3;
         this._lblCombine2.Text = "Combining &Type";
         // 
         // _lblCombine1
         // 
         this._lblCombine1.Location = new System.Drawing.Point(24, 24);
         this._lblCombine1.Name = "_lblCombine1";
         this._lblCombine1.Size = new System.Drawing.Size(100, 15);
         this._lblCombine1.TabIndex = 0;
         this._lblCombine1.Text = "Combining &Factor";
         // 
         // tabColors
         // 
         this.tabColors.Controls.Add(this._btnFGClr);
         this.tabColors.Controls.Add(this._lblForegroundClr);
         this.tabColors.Controls.Add(this._btnBGClr);
         this.tabColors.Controls.Add(this._lblBackgroundClr);
         this.tabColors.Location = new System.Drawing.Point(4, 22);
         this.tabColors.Name = "tabColors";
         this.tabColors.Size = new System.Drawing.Size(400, 334);
         this.tabColors.TabIndex = 4;
         this.tabColors.Text = "Colors";
         // 
         // _btnFGClr
         // 
         this._btnFGClr.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnFGClr.Location = new System.Drawing.Point(192, 24);
         this._btnFGClr.Name = "_btnFGClr";
         this._btnFGClr.Size = new System.Drawing.Size(80, 32);
         this._btnFGClr.TabIndex = 2;
         this._btnFGClr.Text = "&Foreground";
         this._btnFGClr.Click += new System.EventHandler(this._btnFGClr_Click);
         // 
         // _lblForegroundClr
         // 
         this._lblForegroundClr.BackColor = System.Drawing.Color.Black;
         this._lblForegroundClr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblForegroundClr.Location = new System.Drawing.Point(192, 64);
         this._lblForegroundClr.Name = "_lblForegroundClr";
         this._lblForegroundClr.Size = new System.Drawing.Size(80, 32);
         this._lblForegroundClr.TabIndex = 3;
         // 
         // _btnBGClr
         // 
         this._btnBGClr.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnBGClr.Location = new System.Drawing.Point(104, 24);
         this._btnBGClr.Name = "_btnBGClr";
         this._btnBGClr.Size = new System.Drawing.Size(80, 32);
         this._btnBGClr.TabIndex = 0;
         this._btnBGClr.Text = "&Background";
         this._btnBGClr.Click += new System.EventHandler(this._btnBGClr_Click);
         // 
         // _lblBackgroundClr
         // 
         this._lblBackgroundClr.BackColor = System.Drawing.Color.White;
         this._lblBackgroundClr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblBackgroundClr.Location = new System.Drawing.Point(104, 64);
         this._lblBackgroundClr.Name = "_lblBackgroundClr";
         this._lblBackgroundClr.Size = new System.Drawing.Size(80, 32);
         this._lblBackgroundClr.TabIndex = 1;
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(128, 376);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(75, 23);
         this._btnOk.TabIndex = 1;
         this._btnOk.Text = "&Ok";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(224, 376);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "&Cancel";
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // Options
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(426, 407);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this.tanctrlOptions);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Options";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Options";
         this.Load += new System.EventHandler(this.Options_Load);
         this.tanctrlOptions.ResumeLayout(false);
         this.tabMrcCompressions.ResumeLayout(false);
         this.tabMrcCompressions.PerformLayout();
         this.tabPDFCompressions.ResumeLayout(false);
         this.tabPDFCompressions.PerformLayout();
         this._tabSegmentation.ResumeLayout(false);
         this._groupBox2.ResumeLayout(false);
         this._groupBox2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._tbClrThreshold)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbQuality)).EndInit();
         this._groupBox1.ResumeLayout(false);
         this._groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._tbCombineThreshold)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbCleanSize)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbBgThreshold)).EndInit();
         this.tabCombine.ResumeLayout(false);
         this.tabCombine.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._tbCombiningFactor)).EndInit();
         this.tabColors.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion

      public Color backgroundColor;
      public Color foregroundColor;

      //    Mrc:
      public int tempPictureCoder;
      public int tempGrayscaleCoder8Bit;
      public int tempTextCoder2Bit;
      public int tempGrayscaleCoder2Bit;
      public int tempMaskCode;
      public int tempQFactor;
      public int tempGSQFactor;

      //    PDF:
      public int tempPDFPictureCoder;
      public int tempPDFTextCoder2Bit;
      public int tempPDFMaskCoder;
      public int tempPDFQFactor;

      //    Segmentation
      public int tempInputImageType;
      public int tempOutputImageType;

      public int tempBGThreshold;
      public int tempCleanSize;
      public int tempCombineThreshold;
      public int tempQuality;
      public int tempClrThreshold;
      public int tempTypeIndex;
      public bool tempCheck;

      public int tempUserDefineBGThreshold;
      public int tempUserDefineCleanSize;
      public int tempUserDefineCombineThreshold;
      public int tempUserDefineQuality;
      public int tempUserDefineClrThreshold;
      public int tempUserDefineTypeIndex;
      public bool tempUserDefineCheck;

      //    Combine
      public int tempCombineType;
      public int tempCombineFactor;

      private void FillControls( )
      {
         //    Mrc: 24-Bit Color Picture Compression
         _cb24BitClrPicCom.Items.Add("Wavelet CMW");
         _cb24BitClrPicCom.Items.Add("Lossless Wavelet CMW");
         _cb24BitClrPicCom.Items.Add("LEAD CMP");
         _cb24BitClrPicCom.Items.Add("JPEG");
         _cb24BitClrPicCom.Items.Add("Lossless JPEG");
         _cb24BitClrPicCom.Items.Add("JPEG YUV 4:2:2");
         _cb24BitClrPicCom.Items.Add("JPEG YUV 4:1:1");
         _cb24BitClrPicCom.Items.Add("JPEG Progressive");
         _cb24BitClrPicCom.Items.Add("JPEG Progressive YUV 4:2:2");
         _cb24BitClrPicCom.Items.Add("JPEG Progressive YUV 4:1:1");

         //    Mrc: 8-Bit Grayscale Compression
         _cb8BitGrayCom.Items.Add("Lossless CMW 8-bit");
         _cb8BitGrayCom.Items.Add("Grayscale CMW 8-bit");
         _cb8BitGrayCom.Items.Add("Grayscale CMP 8-bit");
         _cb8BitGrayCom.Items.Add("Lossless JPEG 8-bit");
         _cb8BitGrayCom.Items.Add("Grayscale JPEG 8-bit");
         _cb8BitGrayCom.Items.Add("Grayscale JPEG Progressive 8-bit");

         //    Mrc: 2-Bit Text Colored Compression
         _cb2BitTxtClrCom.Items.Add("Text JBIG 2-bit");
         _cb2BitTxtClrCom.Items.Add("Text GIF 2-bit");

         //    Mrc: 2-Bit Grayscale Compression
         _cb2BitGrayscaleCom.Items.Add("Grayscale JBIG 2-bit");

         //    Mrc: 1-Bit Text/Mask Compression
         _cb1BitTxtMaskCom.Items.Add("JBIG");
         _cb1BitTxtMaskCom.Items.Add("Fax G4");
         _cb1BitTxtMaskCom.Items.Add("Fax G3(1D)");
         _cb1BitTxtMaskCom.Items.Add("Fax G3(2D)");

         //    PDF: Picture Compression
         _cbPicCom.Items.Add("JPEG");
         _cbPicCom.Items.Add("JPEG YUV 4:2:2");
         _cbPicCom.Items.Add("JPEG YUV 4:1:1");
         _cbPicCom.Items.Add("JPEG Progressive");
         _cbPicCom.Items.Add("JPEG Progressive YUV 4:2:2");
         _cbPicCom.Items.Add("ZIP");
         _cbPicCom.Items.Add("LZW");

         //    PDF: 2-Bit Compression
         _cb2BitCom.Items.Add("ZIP 2-bit");
         _cb2BitCom.Items.Add("LZW 2-bit");

         //    PDF: 1-Bit Compression
         _cb1BitCom.Items.Add("ZIP 1-bit");
         _cb1BitCom.Items.Add("LZW 1-bit");
         _cb1BitCom.Items.Add("Fax G3(1D)");
         _cb1BitCom.Items.Add("Fax G3(2D)");
         _cb1BitCom.Items.Add("Fax G4");
         _cb1BitCom.Items.Add("JBIG2");

         //    Segmentation: Input Image Quality
         _cbInputImage.Items.Add("Auto Select");
         _cbInputImage.Items.Add("Noisy Image");
         _cbInputImage.Items.Add("Scanned Image");
         _cbInputImage.Items.Add("Printed Image");
         _cbInputImage.Items.Add("Computer Generated Image");
         _cbInputImage.Items.Add("Photo");
         _cbInputImage.Items.Add("User Defined");

         //    Segmentation: Output Image Quality
         _cbOutputImage.Items.Add("Auto Select");
         _cbOutputImage.Items.Add("Poor Quality");
         _cbOutputImage.Items.Add("Average Quality");
         _cbOutputImage.Items.Add("Good Quality");
         _cbOutputImage.Items.Add("Excellent Quality");
         _cbOutputImage.Items.Add("User Defined");

         //    Segmentation: Type
         _cbTypes.Items.Add("Favor 1 bit segments");
         _cbTypes.Items.Add("Favor 2 bit segments");
         _cbTypes.Items.Add("Force 1 bit segments");
         _cbTypes.Items.Add("Force 2 bit segments");

         //    Combine: Combining Type
         _cbCombiningType.Items.Add("Force");
         _cbCombiningType.Items.Add("Force Similar");
         _cbCombiningType.Items.Add("Try");
      }

      private void InputImageEnables(bool enable)
      {
         //    Enable Text boxes...
         _txtBgThreshold.Enabled = enable;
         _txtCleanSize.Enabled = enable;
         _txtCombineThreshold.Enabled = enable;

         //    Enable Scrolls...
         _tbBgThreshold.Enabled = enable;
         _tbCleanSize.Enabled = enable;
         _tbCombineThreshold.Enabled = enable;
      }

      private void OutputImageEnables(bool enable)
      {
         //    Enable Text boxes...
         _txtQuality.Enabled = enable;
         _txtClrThreshold.Enabled = enable;

         //    Enable Scrolls...
         _tbQuality.Enabled = enable;
         _tbClrThreshold.Enabled = enable;

         //    Enable Combo boxes...
         _cbTypes.Enabled = enable;

         //    Enable Check Boxes...
         _chckSearchForBackBG.Enabled = enable;
      }

      public void SetSelections( )
      {
         //    Mrc:
         _cb24BitClrPicCom.SelectedIndex = tempPictureCoder;
         _cb8BitGrayCom.SelectedIndex = tempGrayscaleCoder8Bit;
         _cb2BitTxtClrCom.SelectedIndex = tempTextCoder2Bit;
         _cb2BitGrayscaleCom.SelectedIndex = tempGrayscaleCoder2Bit;
         _cb1BitTxtMaskCom.SelectedIndex = tempMaskCode;
         _txtMrcClrQualityFactor.Text = tempQFactor.ToString();
         _txtGrayscaleFactor.Text = tempGSQFactor.ToString();

         //    PDF:
         _cbPicCom.SelectedIndex = tempPDFPictureCoder;
         _cb2BitCom.SelectedIndex = tempPDFTextCoder2Bit;
         _cb1BitCom.SelectedIndex = tempPDFMaskCoder;
         _txtPDFClrQualityFactor.Text = tempPDFQFactor.ToString();

         //    Segmentation
         _cbInputImage.SelectedIndex = tempInputImageType;
         _cbOutputImage.SelectedIndex = tempOutputImageType;

         if(tempInputImageType != 6)
         {
            _txtBgThreshold.Text = tempBGThreshold.ToString();
            _txtCleanSize.Text = tempCleanSize.ToString();
            _txtCombineThreshold.Text = tempCombineThreshold.ToString();
            _txtQuality.Text = tempQuality.ToString();
            _txtClrThreshold.Text = tempClrThreshold.ToString();
            _cbTypes.SelectedIndex = tempTypeIndex;
            _chckSearchForBackBG.Checked = tempCheck;
         }
         else
         {
            _txtBgThreshold.Text = tempUserDefineBGThreshold.ToString();
            _txtCleanSize.Text = tempUserDefineCleanSize.ToString();
            _txtCombineThreshold.Text = tempUserDefineCombineThreshold.ToString();
            _txtQuality.Text = tempUserDefineQuality.ToString();
            _txtClrThreshold.Text = tempUserDefineClrThreshold.ToString();
            _cbTypes.SelectedIndex = tempUserDefineTypeIndex;
            _chckSearchForBackBG.Checked = tempUserDefineCheck;
         }

         //    Combine
         _cbCombiningType.SelectedIndex = tempCombineType;
         _txtCombiningFactor.Text = tempCombineFactor.ToString();
      }

      private void Options_Load(object sender, System.EventArgs e)
      {
         _lblBackgroundClr.BackColor = Color.FromArgb(backgroundColor.R, backgroundColor.G, backgroundColor.B);
         _lblForegroundClr.BackColor = Color.FromArgb(foregroundColor.R, foregroundColor.G, foregroundColor.B);
      }


      //    Click Functions...
      private void _btnBGClr_Click(object sender, System.EventArgs e)
      {
         ColorDialog colorDlg = new ColorDialog();

         colorDlg.Color = backgroundColor;
         if(colorDlg.ShowDialog() == DialogResult.OK)
         {
            _lblBackgroundClr.BackColor = colorDlg.Color;
            backgroundColor = colorDlg.Color;
         }
      }

      private void _btnFGClr_Click(object sender, System.EventArgs e)
      {
         ColorDialog colorDlg = new ColorDialog();

         colorDlg.Color = foregroundColor;
         if (colorDlg.ShowDialog() == DialogResult.OK)
         {
            _lblForegroundClr.BackColor = colorDlg.Color;
            foregroundColor = colorDlg.Color;
         }
      }


      //    SelectedIndexChanged Functions...
      private void _cb24BitClrPicCom_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         switch(_cb24BitClrPicCom.SelectedIndex)
         {
            case 1:
            case 4:
               _txtMrcClrQualityFactor.Enabled = false;
               break;
            default:
               _txtMrcClrQualityFactor.Enabled = true;
               break;
         }

         tempPictureCoder = _cb24BitClrPicCom.SelectedIndex;
      }

      private void _cb8BitGrayCom_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         switch(_cb8BitGrayCom.SelectedIndex)
         {
            case 0:
            case 3:
               _txtGrayscaleFactor.Enabled = false;
               break;
            default:
               _txtGrayscaleFactor.Enabled = true;
               break;
         }

         tempGrayscaleCoder8Bit = _cb8BitGrayCom.SelectedIndex;
      }

      private void _cb2BitTxtClrCom_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         tempTextCoder2Bit = _cb2BitTxtClrCom.SelectedIndex;
      }

      private void _cb2BitGrayscaleCom_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         tempGrayscaleCoder2Bit = _cb2BitGrayscaleCom.SelectedIndex;
      }

      private void _cb1BitTxtMaskCom_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         tempMaskCode = _cb1BitTxtMaskCom.SelectedIndex;
      }

      private void _cbPicCom_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         switch(_cbPicCom.SelectedIndex)
         {
            case 6:
            case 7:
               _txtPDFClrQualityFactor.Enabled = false;
               break;
            default:
               _txtPDFClrQualityFactor.Enabled = true;
               break;
         }

         tempPDFPictureCoder = _cbPicCom.SelectedIndex;
      }

      private void _cb2BitCom_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         tempPDFTextCoder2Bit = _cb2BitCom.SelectedIndex;
      }

      private void _cb1BitCom_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         tempPDFMaskCoder = _cb1BitCom.SelectedIndex;
      }

      private void _cbInputImage_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         bool enableControls = false;
         tempInputImageType = _cbInputImage.SelectedIndex;

         switch(_cbInputImage.SelectedIndex)
         {
            case 0:
               tempBGThreshold = 15;
               tempCleanSize = 7;
               tempCombineThreshold = 100;
               break;
            case 1:
               tempBGThreshold = 25;
               tempCleanSize = 10;
               tempCombineThreshold = 125;
               break;
            case 2:
               tempBGThreshold = 15;
               tempCleanSize = 8;
               tempCombineThreshold = 100;
               break;
            case 3:
               tempBGThreshold = 10;
               tempCleanSize = 7;
               tempCombineThreshold = 100;
               break;
            case 4:
               tempBGThreshold = 10;
               tempCleanSize = 3;
               tempCombineThreshold = 75;
               break;
            case 5:
               tempBGThreshold = 0;
               tempCleanSize = 3;
               tempCombineThreshold = 75;
               break;
            default:
               tempBGThreshold = tempUserDefineBGThreshold;
               tempCleanSize = tempUserDefineCleanSize;
               tempCombineThreshold = tempUserDefineCombineThreshold;

               enableControls = true;

               break;
         }
         _txtBgThreshold.Text = tempBGThreshold.ToString();
         _txtCleanSize.Text = tempCleanSize.ToString();
         _txtCombineThreshold.Text = tempCombineThreshold.ToString();

         InputImageEnables(enableControls);
      }

      private void _cbOutputImage_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         bool enableControls = false;
         tempOutputImageType = _cbOutputImage.SelectedIndex;

         switch(_cbOutputImage.SelectedIndex)
         {
            case 0:
               tempQuality = 50;
               tempClrThreshold = 25;
               _cbTypes.SelectedIndex = 1;
               _chckSearchForBackBG.Checked = false;
               break;
            case 1:
               tempQuality = 0;
               tempClrThreshold = 30;
               _cbTypes.SelectedIndex = 2;
               _chckSearchForBackBG.Checked = true;
               break;
            case 2:
               tempQuality = 50;
               tempClrThreshold = 25;
               _cbTypes.SelectedIndex = 0;
               _chckSearchForBackBG.Checked = true;
               break;
            case 3:
               tempQuality = 75;
               tempClrThreshold = 25;
               _cbTypes.SelectedIndex = 1;
               _chckSearchForBackBG.Checked = false;
               break;
            case 4:
               tempQuality = 100;
               tempClrThreshold = 25;
               _cbTypes.SelectedIndex = 3;
               _chckSearchForBackBG.Checked = false;
               break;
            default:
               tempQuality = tempUserDefineQuality;
               tempClrThreshold = tempUserDefineClrThreshold;
               _cbTypes.SelectedIndex = tempUserDefineTypeIndex;
               _chckSearchForBackBG.Checked = tempUserDefineCheck;

               enableControls = true;
               break;
         }
         _txtQuality.Text = tempQuality.ToString();
         _txtClrThreshold.Text = tempClrThreshold.ToString();
         tempTypeIndex = _cbTypes.SelectedIndex;
         tempCheck = _chckSearchForBackBG.Checked;

         OutputImageEnables(enableControls);
      }

      private void _cbTypes_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         tempUserDefineTypeIndex = _cbTypes.SelectedIndex;
      }

      private void _cbCombiningType_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         tempCombineType = _cbCombiningType.SelectedIndex;
      }


      //    TextChanged Functions...
      private void _txtBgThreshold_TextChanged(object sender, System.EventArgs e)
      {
         if(tempInputImageType == 6)
         {
            if(_txtBgThreshold.Text.Length == 0)
               _txtBgThreshold.Text = "0";

            tempUserDefineBGThreshold = Math.Max(0, Math.Min(Int32.Parse(_txtBgThreshold.Text), 100));
            _txtBgThreshold.Text = tempUserDefineBGThreshold.ToString();
            _txtBgThreshold.SelectionStart = _txtBgThreshold.Text.Length;

            _tbBgThreshold.Value = tempUserDefineBGThreshold;
         }
         else
         {
            if(_txtBgThreshold.Text.Length == 0)
               _txtBgThreshold.Text = "0";

            tempBGThreshold = Math.Max(0, Math.Min(Int32.Parse(_txtBgThreshold.Text), 100));
            _txtBgThreshold.Text = tempBGThreshold.ToString();
            _txtBgThreshold.SelectionStart = _txtBgThreshold.Text.Length;

            _tbBgThreshold.Value = tempBGThreshold;
         }
      }

      private void _txtCleanSize_TextChanged(object sender, System.EventArgs e)
      {
         if(tempInputImageType == 6)
         {
            if(_txtCleanSize.Text.Length == 0)
               _txtCleanSize.Text = "0";

            tempUserDefineCleanSize = Math.Max(0, Math.Min(Int32.Parse(_txtCleanSize.Text), 10));
            _txtCleanSize.Text = tempUserDefineCleanSize.ToString();
            _txtCleanSize.SelectionStart = _txtCleanSize.Text.Length;

            _tbCleanSize.Value = tempUserDefineCleanSize;
         }
         else
         {
            if(_txtCleanSize.Text.Length == 0)
               _txtCleanSize.Text = "0";

            tempCleanSize = Math.Max(0, Math.Min(Int32.Parse(_txtCleanSize.Text), 10));
            _txtCleanSize.Text = tempCleanSize.ToString();
            _txtCleanSize.SelectionStart = _txtCleanSize.Text.Length;

            _tbCleanSize.Value = tempCleanSize;
         }
      }

      private void _txtCombineThreshold_TextChanged(object sender, System.EventArgs e)
      {
         if(tempInputImageType == 6)
         {
            if(_txtCombineThreshold.Text.Length == 0)
               _txtCombineThreshold.Text = "0";

            tempUserDefineCombineThreshold = Math.Max(0, Math.Min(Int32.Parse(_txtCombineThreshold.Text), 300));
            _txtCombineThreshold.Text = tempUserDefineCombineThreshold.ToString();
            _txtCombineThreshold.SelectionStart = _txtCombineThreshold.Text.Length;

            _tbCombineThreshold.Value = tempUserDefineCombineThreshold;
         }
         else
         {
            if(_txtCombineThreshold.Text.Length == 0)
               _txtCombineThreshold.Text = "0";

            tempCombineThreshold = Math.Max(0, Math.Min(Int32.Parse(_txtCombineThreshold.Text), 300));
            _txtCombineThreshold.Text = tempCombineThreshold.ToString();
            _txtCombineThreshold.SelectionStart = _txtCombineThreshold.Text.Length;

            _tbCombineThreshold.Value = tempCombineThreshold;
         }
      }

      private void _txtQuality_TextChanged(object sender, System.EventArgs e)
      {
         if(tempOutputImageType == 5)
         {
            if(_txtQuality.Text.Length == 0)
               _txtQuality.Text = "0";

            tempUserDefineQuality = Math.Max(0, Math.Min(Int32.Parse(_txtQuality.Text), 100));
            _txtQuality.Text = tempUserDefineQuality.ToString();
            _txtQuality.SelectionStart = _txtQuality.Text.Length;

            _tbQuality.Value = tempUserDefineQuality;
         }
         else
         {
            if(_txtQuality.Text.Length == 0)
               _txtQuality.Text = "0";

            tempQuality = Math.Max(0, Math.Min(Int32.Parse(_txtQuality.Text), 100));
            _txtQuality.Text = tempQuality.ToString();
            _txtQuality.SelectionStart = _txtQuality.Text.Length;

            _tbQuality.Value = tempQuality;
         }
      }

      private void _txtClrThreshold_TextChanged(object sender, System.EventArgs e)
      {
         if(tempOutputImageType == 5)
         {
            if(_txtClrThreshold.Text.Length == 0)
               _txtClrThreshold.Text = "0";

            tempUserDefineClrThreshold = Math.Max(0, Math.Min(Int32.Parse(_txtClrThreshold.Text), 100));
            _txtClrThreshold.Text = tempUserDefineClrThreshold.ToString();
            _txtClrThreshold.SelectionStart = _txtClrThreshold.Text.Length;

            _tbClrThreshold.Value = tempUserDefineClrThreshold;
         }
         else
         {
            if(_txtClrThreshold.Text.Length == 0)
               _txtClrThreshold.Text = "0";

            tempClrThreshold = Math.Max(0, Math.Min(Int32.Parse(_txtClrThreshold.Text), 100));
            _txtClrThreshold.Text = tempClrThreshold.ToString();
            _txtClrThreshold.SelectionStart = _txtClrThreshold.Text.Length;

            _tbClrThreshold.Value = tempClrThreshold;
         }
      }

      private void _txtCombiningFactor_TextChanged(object sender, System.EventArgs e)
      {
         if(_txtCombiningFactor.Text.Length == 0)
            _txtCombiningFactor.Text = "0";

         tempCombineFactor = Math.Max(0, Math.Min(Int32.Parse(_txtCombiningFactor.Text), 100));
         _txtCombiningFactor.Text = tempCombineFactor.ToString();
         _txtCombiningFactor.SelectionStart = _txtCombiningFactor.Text.Length;

         _tbCombiningFactor.Value = tempCombineFactor;
      }


      //    Scroll Functions...
      private void _tbbgThreshold_Scroll(object sender, System.EventArgs e)
      {
         _txtBgThreshold.Text = _tbBgThreshold.Value.ToString();
      }

      private void _tbCleanSize_Scroll(object sender, System.EventArgs e)
      {
         _txtCleanSize.Text = _tbCleanSize.Value.ToString();
      }

      private void _tbCombineThreshold_Scroll(object sender, System.EventArgs e)
      {
         _txtCombineThreshold.Text = _tbCombineThreshold.Value.ToString();
      }

      private void _tbQuality_Scroll(object sender, System.EventArgs e)
      {
         _txtQuality.Text = _tbQuality.Value.ToString();
      }

      private void _tbClrThreshold_Scroll(object sender, System.EventArgs e)
      {
         _txtClrThreshold.Text = _tbClrThreshold.Value.ToString();
      }

      private void _tbCombiningFactor_Scroll(object sender, System.EventArgs e)
      {
         _txtCombiningFactor.Text = _tbCombiningFactor.Value.ToString();
      }


      //    CheckedChanged Functions...
      private void _chckSearchForBackBG_CheckedChanged(object sender, System.EventArgs e)
      {
         tempUserDefineCheck = _chckSearchForBackBG.Checked;
      }

      //    Key Press Function...
      private void _txt_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
      {
         if(!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            e.Handled = true;
      }

      private void tanctrlOptions_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
      {
         if(!e.Handled)
         {
            if(e.KeyCode == Keys.Escape)
            {
               e.Handled = true;

               _btnCancel_Click(_btnCancel, null);
            }
         }
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      private void _btnCancel_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      private void _txtMrcClrQualityFactor_Leave(object sender, EventArgs e)
      {
         if (_txtMrcClrQualityFactor.Text.Length == 0)
            _txtMrcClrQualityFactor.Text = "2";

         tempQFactor = Math.Max(2, Math.Min(Int32.Parse(_txtMrcClrQualityFactor.Text), 255));
         _txtMrcClrQualityFactor.Text = tempQFactor.ToString();
         _txtMrcClrQualityFactor.SelectionStart = _txtMrcClrQualityFactor.Text.Length;
      }

      private void _txtGrayscaleFactor_Leave(object sender, EventArgs e)
      {
         if (_txtGrayscaleFactor.Text.Length == 0)
            _txtGrayscaleFactor.Text = "2";

         tempGSQFactor = Math.Max(2, Math.Min(Int32.Parse(_txtGrayscaleFactor.Text), 255));
         _txtGrayscaleFactor.Text = tempGSQFactor.ToString();
         _txtGrayscaleFactor.SelectionStart = _txtGrayscaleFactor.Text.Length;
      }

      private void _txtPDFClrQualityFactor_Leave(object sender, EventArgs e)
      {
         if (_txtPDFClrQualityFactor.Text.Length == 0)
            _txtPDFClrQualityFactor.Text = "2";

         tempPDFQFactor = Math.Max(2, Math.Min(Int32.Parse(_txtPDFClrQualityFactor.Text), 255));
         _txtPDFClrQualityFactor.Text = tempPDFQFactor.ToString();
         _txtPDFClrQualityFactor.SelectionStart = _txtPDFClrQualityFactor.Text.Length;
      }
   }
}
