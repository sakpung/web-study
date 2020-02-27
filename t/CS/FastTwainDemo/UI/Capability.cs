// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using Leadtools.Twain;
using Leadtools.Demos;

namespace CSFastTwainDemo
{
   /// <summary>
   /// Summary description for CapabilityDialog.
   /// </summary>
   public class CapabilityDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.ComboBox _cmbCapabilityName;
      private System.Windows.Forms.TextBox _txtCapabilityValue;
      private System.Windows.Forms.ComboBox _cmbCapabilityValue;
      private System.Windows.Forms.Label _lblCapabilityValueNote;
      private System.Windows.Forms.Button _btnCapability;
      private System.Windows.Forms.Label _lblValue;
      private System.Windows.Forms.Label _lblCapability;
      private System.Windows.Forms.Button _btnClose;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public CapabilityDialog( )
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
         System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CapabilityDialog));
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._lblCapabilityValueNote = new System.Windows.Forms.Label();
         this._cmbCapabilityValue = new System.Windows.Forms.ComboBox();
         this._txtCapabilityValue = new System.Windows.Forms.TextBox();
         this._lblValue = new System.Windows.Forms.Label();
         this._cmbCapabilityName = new System.Windows.Forms.ComboBox();
         this._lblCapability = new System.Windows.Forms.Label();
         this._btnCapability = new System.Windows.Forms.Button();
         this._btnClose = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._lblCapabilityValueNote);
         this.groupBox1.Controls.Add(this._cmbCapabilityValue);
         this.groupBox1.Controls.Add(this._txtCapabilityValue);
         this.groupBox1.Controls.Add(this._lblValue);
         this.groupBox1.Controls.Add(this._cmbCapabilityName);
         this.groupBox1.Controls.Add(this._lblCapability);
         this.groupBox1.Location = new System.Drawing.Point(8, 8);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(352, 128);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         // 
         // _lblCapabilityValueNote
         // 
         this._lblCapabilityValueNote.Location = new System.Drawing.Point(72, 96);
         this._lblCapabilityValueNote.Name = "_lblCapabilityValueNote";
         this._lblCapabilityValueNote.Size = new System.Drawing.Size(272, 23);
         this._lblCapabilityValueNote.TabIndex = 5;
         // 
         // _cmbCapabilityValue
         // 
         this._cmbCapabilityValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbCapabilityValue.Location = new System.Drawing.Point(72, 64);
         this._cmbCapabilityValue.Name = "_cmbCapabilityValue";
         this._cmbCapabilityValue.Size = new System.Drawing.Size(272, 21);
         this._cmbCapabilityValue.TabIndex = 4;
         // 
         // _txtCapabilityValue
         // 
         this._txtCapabilityValue.Location = new System.Drawing.Point(72, 64);
         this._txtCapabilityValue.Name = "_txtCapabilityValue";
         this._txtCapabilityValue.Size = new System.Drawing.Size(272, 20);
         this._txtCapabilityValue.TabIndex = 3;
         this._txtCapabilityValue.Text = "";
         this._txtCapabilityValue.TextChanged += new System.EventHandler(this._txtCapabilityValue_TextChanged);
         // 
         // _lblValue
         // 
         this._lblValue.Location = new System.Drawing.Point(24, 64);
         this._lblValue.Name = "_lblValue";
         this._lblValue.Size = new System.Drawing.Size(48, 23);
         this._lblValue.TabIndex = 2;
         this._lblValue.Text = "Value:";
         this._lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // _cmbCapabilityName
         // 
         this._cmbCapabilityName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbCapabilityName.Location = new System.Drawing.Point(72, 24);
         this._cmbCapabilityName.Name = "_cmbCapabilityName";
         this._cmbCapabilityName.Size = new System.Drawing.Size(272, 21);
         this._cmbCapabilityName.TabIndex = 1;
         this._cmbCapabilityName.SelectedIndexChanged += new System.EventHandler(this._cmbCapabilityName_SelectedIndexChanged);
         // 
         // _lblCapability
         // 
         this._lblCapability.Location = new System.Drawing.Point(8, 24);
         this._lblCapability.Name = "_lblCapability";
         this._lblCapability.Size = new System.Drawing.Size(64, 23);
         this._lblCapability.TabIndex = 0;
         this._lblCapability.Text = "Capability:";
         this._lblCapability.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // _btnCapability
         // 
         this._btnCapability.Location = new System.Drawing.Point(368, 45);
         this._btnCapability.Name = "_btnCapability";
         this._btnCapability.Size = new System.Drawing.Size(96, 23);
         this._btnCapability.TabIndex = 2;
         this._btnCapability.Text = "Capability";
         this._btnCapability.Click += new System.EventHandler(this._btnCapability_Click);
         // 
         // _btnClose
         // 
         this._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnClose.Location = new System.Drawing.Point(368, 77);
         this._btnClose.Name = "_btnClose";
         this._btnClose.Size = new System.Drawing.Size(96, 23);
         this._btnClose.TabIndex = 3;
         this._btnClose.Text = "Close";
         this._btnClose.Click += new System.EventHandler(this._btnClose_Click);
         // 
         // CapabilityDialog
         // 
         this.AcceptButton = this._btnCapability;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._btnClose;
         this.ClientSize = new System.Drawing.Size(474, 144);
         this.Controls.Add(this._btnClose);
         this.Controls.Add(this._btnCapability);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "CapabilityDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Set / Get Capability";
         this.Load += new System.EventHandler(this.CapabilityDialog_Load);
         this.groupBox1.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion
      public bool _useGetCapability;
      public TwainSession _session;
      TwainCapabilityType[] _capType;
      TwainCapabilityValue[] _capValue;

      private void CapabilityDialog_Load(object sender, System.EventArgs e)
      {
         if(_useGetCapability)
         {
            Text = "Get Capability";
            _btnCapability.Text = "Get Capability";

            _txtCapabilityValue.Visible = false;
            _cmbCapabilityValue.Visible = false;
            _lblCapabilityValueNote.Visible = false;
            _lblValue.Visible = false;
         }
         else
         {
            Text = "Set Capability";
            _btnCapability.Text = "Set Capability";

            _txtCapabilityValue.Visible = true;
            _cmbCapabilityValue.Visible = true;
            _lblCapabilityValueNote.Visible = true;
            _lblValue.Visible = true;
         }

         FillCapabiliyName();
      }

      private void FillCapabiliyName( )
      {
         _capType = new TwainCapabilityType[117];

         _cmbCapabilityName.Items.Add("CAP_ALARMS");
         _cmbCapabilityName.Items.Add("CAP_ALARMVOLUME");
         _cmbCapabilityName.Items.Add("CAP_AUTHOR");
         _cmbCapabilityName.Items.Add("CAP_AUTOFEED");
         _cmbCapabilityName.Items.Add("CAP_AUTOMATICCAPTURE");
         _cmbCapabilityName.Items.Add("CAP_AUTOSCAN");
         _cmbCapabilityName.Items.Add("CAP_CAPTION");
         _cmbCapabilityName.Items.Add("CAP_CLEARBUFFERS");
         _cmbCapabilityName.Items.Add("CAP_CLEARPAGE");
         _cmbCapabilityName.Items.Add("CAP_DEVICEEVENT");
         _cmbCapabilityName.Items.Add("CAP_DEVICETIMEDATE");
         _cmbCapabilityName.Items.Add("CAP_DUPLEXENABLED");
         _cmbCapabilityName.Items.Add("CAP_ENDORSER");
         _cmbCapabilityName.Items.Add("CAP_FEEDERALIGNMENT");
         _cmbCapabilityName.Items.Add("CAP_FEEDERENABLED");
         _cmbCapabilityName.Items.Add("CAP_FEEDERORDER");
         _cmbCapabilityName.Items.Add("CAP_FEEDPAGE");
         _cmbCapabilityName.Items.Add("CAP_INDICATORS");
         _cmbCapabilityName.Items.Add("CAP_JOBCONTROL");
         _cmbCapabilityName.Items.Add("CAP_LANGUAGE");
         _cmbCapabilityName.Items.Add("CAP_MAXBATCHBUFFERS");
         _cmbCapabilityName.Items.Add("CAP_PRINTER");
         _cmbCapabilityName.Items.Add("CAP_PRINTERENABLED");
         _cmbCapabilityName.Items.Add("CAP_PRINTERINDEX");
         _cmbCapabilityName.Items.Add("CAP_PRINTERMODE");
         _cmbCapabilityName.Items.Add("CAP_PRINTERSTRING");
         _cmbCapabilityName.Items.Add("CAP_PRINTERSUFFIX");
         _cmbCapabilityName.Items.Add("CAP_REWINDPAGE");
         _cmbCapabilityName.Items.Add("CAP_THUMBNAILSENABLED");
         _cmbCapabilityName.Items.Add("CAP_TIMEBEFOREFIRSTCAPTURE");
         _cmbCapabilityName.Items.Add("CAP_TIMEBETWEENCAPTURES");
         _cmbCapabilityName.Items.Add("CAP_XFERCOUNT");
         _cmbCapabilityName.Items.Add("ICAP_AUTOBRIGHT");
         _cmbCapabilityName.Items.Add("ICAP_AUTOMATICBORDERDETECTION");
         _cmbCapabilityName.Items.Add("ICAP_AUTOMATICDESKEW");
         _cmbCapabilityName.Items.Add("ICAP_AUTOMATICROTATE");
         _cmbCapabilityName.Items.Add("ICAP_BARCODEDETECTIONENABLED");
         _cmbCapabilityName.Items.Add("ICAP_BARCODEMAXRETRIES");
         _cmbCapabilityName.Items.Add("ICAP_BARCODEMAXSEARCHPRIORITIES");
         _cmbCapabilityName.Items.Add("ICAP_BARCODESEARCHMODE");
         _cmbCapabilityName.Items.Add("ICAP_BARCODESEARCHPRIORITIES");
         _cmbCapabilityName.Items.Add("ICAP_BARCODETIMEOUT");
         _cmbCapabilityName.Items.Add("ICAP_BITDEPTH");
         _cmbCapabilityName.Items.Add("ICAP_BITDEPTHREDUCTION");
         _cmbCapabilityName.Items.Add("ICAP_BITORDER");
         _cmbCapabilityName.Items.Add("ICAP_BITORDERCODES");
         _cmbCapabilityName.Items.Add("ICAP_BRIGHTNESS");
         _cmbCapabilityName.Items.Add("ICAP_CCITTKFACTOR");
         _cmbCapabilityName.Items.Add("ICAP_COMPRESSION");
         _cmbCapabilityName.Items.Add("ICAP_CONTRAST");
         _cmbCapabilityName.Items.Add("ICAP_CUSTHALFTONE");
         _cmbCapabilityName.Items.Add("ICAP_EXPOSURETIME");
         _cmbCapabilityName.Items.Add("ICAP_EXTIMAGEINFO");
         _cmbCapabilityName.Items.Add("ICAP_FILTER");
         _cmbCapabilityName.Items.Add("ICAP_FLASHUSED");
         _cmbCapabilityName.Items.Add("ICAP_FLASHUSED2");
         _cmbCapabilityName.Items.Add("ICAP_FLIPROTATION");
         _cmbCapabilityName.Items.Add("ICAP_GAMMA");
         _cmbCapabilityName.Items.Add("ICAP_HALFTONES");
         _cmbCapabilityName.Items.Add("ICAP_HIGHLIGHT");
         _cmbCapabilityName.Items.Add("ICAP_IMAGEDATASET");
         _cmbCapabilityName.Items.Add("ICAP_IMAGEFILEFORMAT");
         _cmbCapabilityName.Items.Add("ICAP_IMAGEFILTER");
         _cmbCapabilityName.Items.Add("ICAP_JPEGPIXELTYPE");
         _cmbCapabilityName.Items.Add("ICAP_JPEGQUALITY");
         _cmbCapabilityName.Items.Add("ICAP_LAMPSTATE");
         _cmbCapabilityName.Items.Add("ICAP_LIGHTPATH");
         _cmbCapabilityName.Items.Add("ICAP_LIGHTSOURCE");
         _cmbCapabilityName.Items.Add("ICAP_MAXFRAMES");
         _cmbCapabilityName.Items.Add("ICAP_NOISEFILTER");
         _cmbCapabilityName.Items.Add("ICAP_ORIENTATION");
         _cmbCapabilityName.Items.Add("ICAP_OVERSCAN");
         _cmbCapabilityName.Items.Add("ICAP_PATCHCODEDETECTIONENABLED");
         _cmbCapabilityName.Items.Add("ICAP_PATCHCODEMAXRETRIES");
         _cmbCapabilityName.Items.Add("ICAP_PATCHCODEMAXSEARCHPRIORITIES");
         _cmbCapabilityName.Items.Add("ICAP_PATCHCODESEARCHMODE");
         _cmbCapabilityName.Items.Add("ICAP_PATCHCODESEARCHPRIORITIES");
         _cmbCapabilityName.Items.Add("ICAP_PATCHCODETIMEOUT");
         _cmbCapabilityName.Items.Add("ICAP_PIXELFLAVOR");
         _cmbCapabilityName.Items.Add("ICAP_PIXELFLAVORCODES");
         _cmbCapabilityName.Items.Add("ICAP_PIXELTYPE");
         _cmbCapabilityName.Items.Add("ICAP_PLANARCHUNKY");
         _cmbCapabilityName.Items.Add("ICAP_ROTATION");
         _cmbCapabilityName.Items.Add("ICAP_SHADOW");
         _cmbCapabilityName.Items.Add("ICAP_SUPPORTEDSIZES");
         _cmbCapabilityName.Items.Add("ICAP_THRESHOLD");
         _cmbCapabilityName.Items.Add("ICAP_TILES");
         _cmbCapabilityName.Items.Add("ICAP_TIMEFILL");
         _cmbCapabilityName.Items.Add("ICAP_UNDEFINEDIMAGESIZE");
         _cmbCapabilityName.Items.Add("ICAP_UNITS");
         _cmbCapabilityName.Items.Add("ICAP_XFERMECH");
         _cmbCapabilityName.Items.Add("ICAP_XRESOLUTION");
         _cmbCapabilityName.Items.Add("ICAP_XSCALING");
         _cmbCapabilityName.Items.Add("ICAP_YRESOLUTION");
         _cmbCapabilityName.Items.Add("ICAP_YSCALING");
         _cmbCapabilityName.Items.Add("ICAP_ZOOMFACTOR");
         _cmbCapabilityName.SelectedIndex = 0;

         _capType[0] = TwainCapabilityType.Alarms;
         _capType[1] = TwainCapabilityType.AlarmVolume;
         _capType[2] = TwainCapabilityType.Author;
         _capType[3] = TwainCapabilityType.AutoFeed;
         _capType[4] = TwainCapabilityType.AutomaticCapture;
         _capType[5] = TwainCapabilityType.AutoScan;
         _capType[6] = TwainCapabilityType.Caption;
         _capType[7] = TwainCapabilityType.ClearBuffers;
         _capType[8] = TwainCapabilityType.ClearPage;
         _capType[9] = TwainCapabilityType.DeviceEvent;
         _capType[10] = TwainCapabilityType.DeviceTimeDate;
         _capType[11] = TwainCapabilityType.DuplexEnabled;
         _capType[12] = TwainCapabilityType.Endorser;
         _capType[13] = TwainCapabilityType.FeederAlignment;
         _capType[14] = TwainCapabilityType.FeederEnabled;
         _capType[15] = TwainCapabilityType.FeederOrder;
         _capType[16] = TwainCapabilityType.FeedPage;
         _capType[17] = TwainCapabilityType.Indicators;
         _capType[18] = TwainCapabilityType.JobControl;
         _capType[19] = TwainCapabilityType.Language;
         _capType[20] = TwainCapabilityType.MaxBatchBuffers;
         _capType[21] = TwainCapabilityType.Printer;
         _capType[22] = TwainCapabilityType.PrinterEnabled;
         _capType[23] = TwainCapabilityType.PrinterIndex;
         _capType[24] = TwainCapabilityType.PrinterMode;
         _capType[25] = TwainCapabilityType.PrinterString;
         _capType[26] = TwainCapabilityType.PrinterSuffix;
         _capType[27] = TwainCapabilityType.RewindPage;
         _capType[28] = TwainCapabilityType.ThumbnailsEnabled;
         _capType[29] = TwainCapabilityType.TimeBeforeFirstCapture;
         _capType[30] = TwainCapabilityType.TimeBetweenCaptures;
         _capType[31] = TwainCapabilityType.TransferCount;
         _capType[32] = TwainCapabilityType.ImageAutoBright;
         _capType[33] = TwainCapabilityType.ImageAutomaticBorderDetection;
         _capType[34] = TwainCapabilityType.ImageAutomaticDeskew;
         _capType[35] = TwainCapabilityType.ImageAutomaticRotate;
         _capType[36] = TwainCapabilityType.ImageBarcodeDetectionEnabled;
         _capType[37] = TwainCapabilityType.ImageBarcodeMaxRetries;
         _capType[38] = TwainCapabilityType.ImageBarcodeMaxSearchPriorities;
         _capType[39] = TwainCapabilityType.ImageBarcodeSearchMode;
         _capType[40] = TwainCapabilityType.ImageBarcodeSearchPriorities;
         _capType[41] = TwainCapabilityType.ImageBarcodeTimeout;
         _capType[42] = TwainCapabilityType.ImageBitDepth;
         _capType[43] = TwainCapabilityType.ImageBitDepthReduction;
         _capType[44] = TwainCapabilityType.ImageBitOrder;
         _capType[45] = TwainCapabilityType.ImageBitOrderCodes;
         _capType[46] = TwainCapabilityType.ImageBrightness;
         _capType[47] = TwainCapabilityType.ImageCcittKFactor;
         _capType[48] = TwainCapabilityType.ImageCompression;
         _capType[49] = TwainCapabilityType.ImageContrast;
         _capType[50] = TwainCapabilityType.ImageCustomHalftone;
         _capType[51] = TwainCapabilityType.ImageExposureTime;
         _capType[52] = TwainCapabilityType.ImageExtImageInfo;
         _capType[53] = TwainCapabilityType.ImageFilter;
         _capType[54] = TwainCapabilityType.ImageFlashUsed;
         _capType[55] = TwainCapabilityType.ImageFlashUsed2;
         _capType[56] = TwainCapabilityType.ImageFlipRotation;
         _capType[57] = TwainCapabilityType.ImageGamma;
         _capType[58] = TwainCapabilityType.ImageHalftones;
         _capType[59] = TwainCapabilityType.ImageHighlight;
         _capType[60] = TwainCapabilityType.ImageImageDataSet;
         _capType[61] = TwainCapabilityType.ImageImageFileFormat;
         _capType[62] = TwainCapabilityType.ImageImageFilter;
         _capType[63] = TwainCapabilityType.ImageJpegPixelType;
         _capType[64] = TwainCapabilityType.ImageJpegQuality;
         _capType[65] = TwainCapabilityType.ImageLampState;
         _capType[66] = TwainCapabilityType.ImageLightPath;
         _capType[67] = TwainCapabilityType.ImageLightSource;
         _capType[68] = TwainCapabilityType.ImageMaxFrames;
         _capType[69] = TwainCapabilityType.ImageNoiseFilter;
         _capType[70] = TwainCapabilityType.ImageOrientation;
         _capType[71] = TwainCapabilityType.ImageOverScan;
         _capType[72] = TwainCapabilityType.ImagePatchCodeDetectionEnabled;
         _capType[73] = TwainCapabilityType.ImagePatchCodeMaxRetries;
         _capType[74] = TwainCapabilityType.ImagePatchCodeMaxSearchPriorities;
         _capType[75] = TwainCapabilityType.ImagePatchCodeSearchMode;
         _capType[76] = TwainCapabilityType.ImagePatchCodeSearchPriorities;
         _capType[77] = TwainCapabilityType.ImagePatchCodeTimeout;
         _capType[78] = TwainCapabilityType.ImagePixelFlavor;
         _capType[79] = TwainCapabilityType.ImagePixelFlavorCodes;
         _capType[80] = TwainCapabilityType.ImagePixelType;
         _capType[81] = TwainCapabilityType.ImagePlanarChunky;
         _capType[82] = TwainCapabilityType.ImageRotation;
         _capType[83] = TwainCapabilityType.ImageShadow;
         _capType[84] = TwainCapabilityType.ImageSupportedSizes;
         _capType[85] = TwainCapabilityType.ImageThreshold;
         _capType[86] = TwainCapabilityType.ImageTiles;
         _capType[87] = TwainCapabilityType.ImageTimeFill;
         _capType[88] = TwainCapabilityType.ImageUndefinedImageSize;
         _capType[89] = TwainCapabilityType.ImageUnits;
         _capType[90] = TwainCapabilityType.ImageTransferMechanism;
         _capType[91] = TwainCapabilityType.ImageXResolution;
         _capType[92] = TwainCapabilityType.ImageXScaling;
         _capType[93] = TwainCapabilityType.ImageYResolution;
         _capType[94] = TwainCapabilityType.ImageYScaling;
         _capType[95] = TwainCapabilityType.ImageZoomFactor;

         if(_useGetCapability) /* read-only capabilities */
         {
            _cmbCapabilityName.Items.Add("CAP_BATTERYMINUTES");
            _cmbCapabilityName.Items.Add("CAP_BATTERYPERCENTAGE");
            _cmbCapabilityName.Items.Add("CAP_CAMERAPREVIEWUI");
            _cmbCapabilityName.Items.Add("CAP_CUSTOMDSDATA");
            _cmbCapabilityName.Items.Add("CAP_DEVICEONLINE");
            _cmbCapabilityName.Items.Add("CAP_DUPLEX");
            _cmbCapabilityName.Items.Add("CAP_ENABLEDSUIONLY");
            _cmbCapabilityName.Items.Add("CAP_FEEDERLOADED");
            _cmbCapabilityName.Items.Add("CAP_PAPERDETECTABLE");
            _cmbCapabilityName.Items.Add("CAP_POWERSUPPLY");
            _cmbCapabilityName.Items.Add("CAP_SERIALNUMBER");
            _cmbCapabilityName.Items.Add("ICAP_SUPPORTEDBARCODETYPES");
            _cmbCapabilityName.Items.Add("ICAP_SUPPORTEDPATCHCODETYPES");
            _cmbCapabilityName.Items.Add("CAP_TIMEDATE");
            _cmbCapabilityName.Items.Add("CAP_UICONTROLLABLE");
            _cmbCapabilityName.Items.Add("ICAP_MINIMUMHEIGHT");
            _cmbCapabilityName.Items.Add("ICAP_MINIMUMWIDTH");
            _cmbCapabilityName.Items.Add("ICAP_PHYSICALHEIGHT");
            _cmbCapabilityName.Items.Add("ICAP_PHYSICALWIDTH");
            _cmbCapabilityName.Items.Add("ICAP_XNATIVERESOLUTION");
            _cmbCapabilityName.Items.Add("ICAP_YNATIVERESOLUTION");

            _capType[96] = TwainCapabilityType.BatteryMinutes;
            _capType[97] = TwainCapabilityType.BatteryPercentage;
            _capType[98] = TwainCapabilityType.CameraPreviewUI;
            _capType[99] = TwainCapabilityType.CustomDSData;
            _capType[100] = TwainCapabilityType.DeviceOnline;
            _capType[101] = TwainCapabilityType.Duplex;
            _capType[102] = TwainCapabilityType.EnabledSuiOnly;
            _capType[103] = TwainCapabilityType.FeederLoaded;
            _capType[104] = TwainCapabilityType.PaperDetectable;
            _capType[105] = TwainCapabilityType.PowerSupply;
            _capType[106] = TwainCapabilityType.SerialNumber;
            _capType[107] = TwainCapabilityType.ImageSupportedBarcodeTypes;
            _capType[108] = TwainCapabilityType.ImageSupportedPatchCodeTypes;
            _capType[109] = TwainCapabilityType.TimeDate;
            _capType[110] = TwainCapabilityType.UIControllable;
            _capType[111] = TwainCapabilityType.ImageMinimumHeight;
            _capType[112] = TwainCapabilityType.ImageMinimumWidth;
            _capType[113] = TwainCapabilityType.ImagePhysicalHeight;
            _capType[114] = TwainCapabilityType.ImagePhysicalWidth;
            _capType[115] = TwainCapabilityType.ImageXNativeResolution;
            _capType[116] = TwainCapabilityType.ImageYNativeResolution;
         }
         else
            FillCapabilityComboValue(TwainCapabilityType.Alarms);
      }

      private void FillCapabilityEditValue(TwainCapabilityType capability)
      {
         switch(capability)
         {
            case TwainCapabilityType.TransferCount: /* CAP_XFERCOUNT ... -1 -1 to 2power 15 */
               _lblCapabilityValueNote.Text = "-1 ... 32768";
               break;
            case TwainCapabilityType.Author: /* CAP_AUTHOR ... any text */
               _lblCapabilityValueNote.Text = "Any Text";
               break;
            case TwainCapabilityType.Caption: /* CAP_CAPTION ... any text */
               _lblCapabilityValueNote.Text = "Any Text";
               break;
            case TwainCapabilityType.Endorser: /* CAP_ENDORSER ... any value */
               _lblCapabilityValueNote.Text = "Any Numeric Value";
               break;
            case TwainCapabilityType.AlarmVolume: /* CAP_ALARMVOLUME ... 0 to 100 */
               _lblCapabilityValueNote.Text = "0 ... 100";
               break;
            case TwainCapabilityType.AutomaticCapture: /* CAP_AUTOMATICCAPTURE ... 0 or greater */
               _lblCapabilityValueNote.Text = ">= 0";
               break;
            case TwainCapabilityType.TimeBeforeFirstCapture: /* CAP_TIMEBEFOREFIRSTCAPTURE ... 0 or greater */
               _lblCapabilityValueNote.Text = ">= 0";
               break;
            case TwainCapabilityType.TimeBetweenCaptures: /* CAP_TIMEBETWEENCAPTURES ... 0 or greater */
               _lblCapabilityValueNote.Text = ">= 0";
               break;
            case TwainCapabilityType.MaxBatchBuffers: /* CAP_MAXBATCHBUFFERS ... 1 or greater */
               _lblCapabilityValueNote.Text = ">= 1";
               break;
            case TwainCapabilityType.DeviceTimeDate: /* CAP_DEVICETIMEDATE ... any date */
               _lblCapabilityValueNote.Text = "Any Date";
               break;
            case TwainCapabilityType.PrinterIndex: /* CAP_PRINTERINDEX ... any UINT32 value */
               _lblCapabilityValueNote.Text = "Any Numeric Value";
               break;
            case TwainCapabilityType.PrinterString: /* CAP_PRINTERSTRING ... any string */
               _lblCapabilityValueNote.Text = "Any String";
               break;
            case TwainCapabilityType.PrinterSuffix: /* CAP_PRINTERSUFFIX ... any string */
               _lblCapabilityValueNote.Text = "Any String";
               break;
            case TwainCapabilityType.ImageBrightness: /* ICAP_BRIGHTNESS ... -1000 to +1000 */
               _lblCapabilityValueNote.Text = "-1000 ... +1000";
               break;
            case TwainCapabilityType.ImageContrast: /* ICAP_CONTRAST ...  -1000 to +1000 */
               _lblCapabilityValueNote.Text = "-1000 ... +1000";
               break;
            case TwainCapabilityType.ImageCustomHalftone: /* ICAP_CUSTHALFTONE ... any value UINT8 */
               _lblCapabilityValueNote.Text = "Any value";
               break;
            case TwainCapabilityType.ImageExposureTime: /* ICAP_EXPOSURETIME ... >0 */
               _lblCapabilityValueNote.Text = "> 0";
               break;
            case TwainCapabilityType.ImageHalftones: /* ICAP_HALFTONES ... string */
               _lblCapabilityValueNote.Text = "String";
               break;
            case TwainCapabilityType.ImageHighlight: /* ICAP_HIGHLIGHT ... 0 to 255 */
               _lblCapabilityValueNote.Text = "0 ... 255";
               break;
            case TwainCapabilityType.ImageShadow: /* ICAP_SHADOW ... 0 to 255 */
               _lblCapabilityValueNote.Text = "0 ... 255";
               break;
            case TwainCapabilityType.ImageXResolution: /* ICAP_XRESOLUTION ... >0 */
               _lblCapabilityValueNote.Text = "> 0";
               break;
            case TwainCapabilityType.ImageYResolution: /* ICAP_YRESOLUTION ... >0 */
               _lblCapabilityValueNote.Text = "> 0";
               break;
            case TwainCapabilityType.ImageMaxFrames: /* ICAP_MAXFRAMES ... 1 to 2 power 16 */
               _lblCapabilityValueNote.Text = "1 ... 65536";
               break;
            case TwainCapabilityType.ImageCcittKFactor: /* ICAP_CCITTKFACTOR ... 1 to 2 power 16 */
               _lblCapabilityValueNote.Text = "1 ... 65536";
               break;
            case TwainCapabilityType.ImageRotation: /* ICAP_ROTATION ... -360 to 360 */
               _lblCapabilityValueNote.Text = "-360 ... 360";
               break;
            case TwainCapabilityType.ImageThreshold: /* ICAP_THRESHOLD ... 0 to 255 */
               _lblCapabilityValueNote.Text = "0 ... 255";
               break;
            case TwainCapabilityType.ImageXScaling: /* ICAP_XSCALING ... 0.0 to 1.0 */
               _lblCapabilityValueNote.Text = "0.0 ... 1.0";
               break;
            case TwainCapabilityType.ImageYScaling: /* ICAP_YSCALING ... 0.0 to 1.0 */
               _lblCapabilityValueNote.Text = "0.0 ... 1.0";
               break;
            case TwainCapabilityType.ImageTimeFill: /* ICAP_TIMEFILL ... 1 to 2 power 16 */
               _lblCapabilityValueNote.Text = "1 ... 65536";
               break;
            case TwainCapabilityType.ImageBitDepth: /* ICAP_BITDEPTH ... >= 1 */
               _lblCapabilityValueNote.Text = ">= 1";
               break;
            case TwainCapabilityType.ImageImageDataSet: /* ICAP_IMAGEDATASET ... any integer value */
               _lblCapabilityValueNote.Text = "Any Numeric Value";
               break;
            case TwainCapabilityType.ImageBarcodeMaxSearchPriorities: /* ICAP_BARCODEMAXSEARCHPRIORITIES ... integer value */
               _lblCapabilityValueNote.Text = "Any Numeric Value";
               break;
            case TwainCapabilityType.ImageBarcodeMaxRetries: /* ICAP_BARCODEMAXRETRIES ... integer value */
               _lblCapabilityValueNote.Text = "Any Numeric Value";
               break;
            case TwainCapabilityType.ImageBarcodeTimeout:/* ICAP_BARCODETIMEOUT ... integer value */
               _lblCapabilityValueNote.Text = "Any Numeric Value";
               break;
            case TwainCapabilityType.ImageZoomFactor: /* ICAP_ZOOMFACTOR ... integer value */
               _lblCapabilityValueNote.Text = "Any Numeric Value";
               break;
            case TwainCapabilityType.ImagePatchCodeMaxSearchPriorities: /* ICAP_PATCHCODEMAXSEARCHPRIORITIES ... integer value */
               _lblCapabilityValueNote.Text = "Any Numeric Value";
               break;
            case TwainCapabilityType.ImagePatchCodeMaxRetries: /* ICAP_PATCHCODEMAXRETRIES ... integer value */
               _lblCapabilityValueNote.Text = "Any Numeric Value";
               break;
            case TwainCapabilityType.ImagePatchCodeTimeout: /* ICAP_PATCHCODETIMEOUT ... integer value */
               _lblCapabilityValueNote.Text = "Any Numeric Value";
               break;
            case TwainCapabilityType.ImageGamma: /* ICAP_GAMMA ... any float value */
               _lblCapabilityValueNote.Text = "Any Float Value";
               break;
         }
      }

      private void FillCapabilityComboValue(TwainCapabilityType capability)
      {
         // show the combo box control
         _cmbCapabilityValue.Visible = true;
         _cmbCapabilityValue.Items.Clear();

         // hide the other controls
         _txtCapabilityValue.Visible = false;
         _lblCapabilityValueNote.Visible = false;

         // enable the "Set Capability" button
         _btnCapability.Enabled = true;

         switch(capability)
         {
            case TwainCapabilityType.ClearBuffers:  /* CAP_CLEARBUFFERS */
               _cmbCapabilityValue.Items.Add("TWCB_AUTO");
               _cmbCapabilityValue.Items.Add("TWCB_CLEAR");
               _cmbCapabilityValue.Items.Add("TWCB_NOCLEAR");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[3];
               _capValue[0] = TwainCapabilityValue.ClearBuffersAuto;
               _capValue[1] = TwainCapabilityValue.ClearBuffersClear;
               _capValue[2] = TwainCapabilityValue.ClearBuffersNoClear;
               break;
            case TwainCapabilityType.ImageBitDepthReduction: /* ICAP_BITDEPTHREDUCTION */
               _cmbCapabilityValue.Items.Add("TWBR_THRESHOLD");
               _cmbCapabilityValue.Items.Add("TWBR_HALFTONES");
               _cmbCapabilityValue.Items.Add("TWBR_CUSTHALFTONE");
               _cmbCapabilityValue.Items.Add("TWBR_DIFFUSION");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[4];
               _capValue[0] = TwainCapabilityValue.BitDepthReductionThreshold;
               _capValue[1] = TwainCapabilityValue.BitDepthReductionHalftone;
               ;
               _capValue[2] = TwainCapabilityValue.BitDepthReductionCustomHalftone;
               _capValue[3] = TwainCapabilityValue.BitDepthReductionDiffusion;
               break;
            case TwainCapabilityType.ImageBitOrder: /* ICAP_BITORDER */
               _cmbCapabilityValue.Items.Add("TWBO_LSBFIRST");
               _cmbCapabilityValue.Items.Add("TWBO_MSBFIRST");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[2];
               _capValue[0] = TwainCapabilityValue.BitOrderLsbFirst;
               _capValue[1] = TwainCapabilityValue.BitOrderMsbFirst;
               break;
            case TwainCapabilityType.ImageCompression: /* ICAP_COMPRESSION */
               _cmbCapabilityValue.Items.Add("TWCP_NONE");
               _cmbCapabilityValue.Items.Add("TWCP_PACKBITS");
               _cmbCapabilityValue.Items.Add("TWCP_GROUP31D");
               _cmbCapabilityValue.Items.Add("TWCP_GROUP31DEOL");
               _cmbCapabilityValue.Items.Add("TWCP_GROUP32D");
               _cmbCapabilityValue.Items.Add("TWCP_GROUP4");
               _cmbCapabilityValue.Items.Add("TWCP_JPEG");
               _cmbCapabilityValue.Items.Add("TWCP_LZW");
               _cmbCapabilityValue.Items.Add("TWCP_JBIG");
               _cmbCapabilityValue.Items.Add("TWCP_PNG");
               _cmbCapabilityValue.Items.Add("TWCP_RLE4");
               _cmbCapabilityValue.Items.Add("TWCP_RLE8");
               _cmbCapabilityValue.Items.Add("TWCP_BITFIELDS");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[13];
               _capValue[0] = TwainCapabilityValue.CompressionNone;
               _capValue[1] = TwainCapabilityValue.CompressionPackBits;
               _capValue[2] = TwainCapabilityValue.CompressionGroup31D;
               _capValue[3] = TwainCapabilityValue.CompressionGroup31DEol;
               _capValue[4] = TwainCapabilityValue.CompressionGroup32D;
               _capValue[5] = TwainCapabilityValue.CompressionGroup4;
               _capValue[6] = TwainCapabilityValue.CompressionJpeg;
               _capValue[7] = TwainCapabilityValue.CompressionLzw;
               _capValue[8] = TwainCapabilityValue.CompressionJbig;
               _capValue[9] = TwainCapabilityValue.CompressionPng;
               _capValue[10] = TwainCapabilityValue.CompressionRle4;
               _capValue[11] = TwainCapabilityValue.CompressionRle8;
               _capValue[12] = TwainCapabilityValue.CompressionBitFields;
               break;
            case TwainCapabilityType.ImageFilter: /* ICAP_FILTER */
               _cmbCapabilityValue.Items.Add("TWFT_RED");
               _cmbCapabilityValue.Items.Add("TWFT_GREEN");
               _cmbCapabilityValue.Items.Add("TWFT_BLUE");
               _cmbCapabilityValue.Items.Add("TWFT_NONE");
               _cmbCapabilityValue.Items.Add("TWFT_WHITE");
               _cmbCapabilityValue.Items.Add("TWFT_CYAN");
               _cmbCapabilityValue.Items.Add("TWFT_MAGENTA");
               _cmbCapabilityValue.Items.Add("TWFT_YELLOW");
               _cmbCapabilityValue.Items.Add("TWFT_BLACK");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[9];
               _capValue[0] = TwainCapabilityValue.FilterRed;
               _capValue[1] = TwainCapabilityValue.FilterGreen;
               _capValue[2] = TwainCapabilityValue.FilterBlue;
               _capValue[3] = TwainCapabilityValue.FilterNone;
               _capValue[4] = TwainCapabilityValue.FilterWhite;
               _capValue[5] = TwainCapabilityValue.FilterCyan;
               _capValue[6] = TwainCapabilityValue.FilterMagenta;
               _capValue[7] = TwainCapabilityValue.FilterYellow;
               _capValue[8] = TwainCapabilityValue.FilterBlack;
               break;
            case TwainCapabilityType.ImageFlashUsed2: /* ICAP_FLASHUSED2 */
               _cmbCapabilityValue.Items.Add("TWFL_NONE");
               _cmbCapabilityValue.Items.Add("TWFL_OFF");
               _cmbCapabilityValue.Items.Add("TWFL_ON");
               _cmbCapabilityValue.Items.Add("TWFL_AUTO");
               _cmbCapabilityValue.Items.Add("TWFL_REDEYE");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[5];
               _capValue[0] = TwainCapabilityValue.FlashUsed2None;
               _capValue[1] = TwainCapabilityValue.FlashUsed2Off;
               _capValue[2] = TwainCapabilityValue.FlashUsed2On;
               _capValue[3] = TwainCapabilityValue.FlashUsed2Auto;
               _capValue[4] = TwainCapabilityValue.FlashUsed2Redeye;
               break;
            case TwainCapabilityType.ImageImageFileFormat: /* ICAP_IMAGEFILEFORMAT */
               _cmbCapabilityValue.Items.Add("TWFF_TIFF");
               _cmbCapabilityValue.Items.Add("TWFF_PICT");
               _cmbCapabilityValue.Items.Add("TWFF_BMP");
               _cmbCapabilityValue.Items.Add("TWFF_XBM");
               _cmbCapabilityValue.Items.Add("TWFF_JFIF");
               _cmbCapabilityValue.Items.Add("TWFF_FPX");
               _cmbCapabilityValue.Items.Add("TWFF_TIFFMULTI");
               _cmbCapabilityValue.Items.Add("TWFF_PNG");
               _cmbCapabilityValue.Items.Add("TWFF_SPIFF");
               _cmbCapabilityValue.Items.Add("TWFF_EXIF");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[10];
               _capValue[0] = TwainCapabilityValue.FileFormatTiff;
               _capValue[1] = TwainCapabilityValue.FileFormatPict;
               _capValue[2] = TwainCapabilityValue.FileFormatBmp;
               _capValue[3] = TwainCapabilityValue.FileFormatXbm;
               _capValue[4] = TwainCapabilityValue.FileFormatJfif;
               _capValue[5] = TwainCapabilityValue.FileFormatFpx;
               _capValue[6] = TwainCapabilityValue.FileFormatTiffMulti;
               _capValue[7] = TwainCapabilityValue.FileFormatPng;
               _capValue[8] = TwainCapabilityValue.FileFormatSpiff;
               _capValue[9] = TwainCapabilityValue.FileFormatExif;
               break;
            case TwainCapabilityType.ImageImageFilter: /* ICAP_IMAGEFILTER */
               _cmbCapabilityValue.Items.Add("TWIF_NONE");
               _cmbCapabilityValue.Items.Add("TWIF_AUTO");
               _cmbCapabilityValue.Items.Add("TWIF_LOWPASS");
               _cmbCapabilityValue.Items.Add("TWIF_BANDPASS");
               _cmbCapabilityValue.Items.Add("TWIF_HIGHPASS");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[5];
               _capValue[0] = TwainCapabilityValue.ImageFilterNone;
               _capValue[1] = TwainCapabilityValue.ImageFilterAuto;
               _capValue[2] = TwainCapabilityValue.ImageFilterLowPass;
               _capValue[3] = TwainCapabilityValue.ImageFilterBandPass;
               _capValue[4] = TwainCapabilityValue.ImageFilterHighPass;
               break;
            case TwainCapabilityType.ImageLightPath: /* ICAP_LIGHTPATH */
               _cmbCapabilityValue.Items.Add("TWLP_REFLECTIVE");
               _cmbCapabilityValue.Items.Add("TWLP_TRANSMISSIVE");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[2];
               _capValue[0] = TwainCapabilityValue.LightPathReflective;
               _capValue[1] = TwainCapabilityValue.LightPathTransmissive;
               break;
            case TwainCapabilityType.ImageLightSource: /* ICAP_LIGHTSOURCE */
               _cmbCapabilityValue.Items.Add("TWLS_RED");
               _cmbCapabilityValue.Items.Add("TWLS_GREEN");
               _cmbCapabilityValue.Items.Add("TWLS_BLUE");
               _cmbCapabilityValue.Items.Add("TWLS_NONE");
               _cmbCapabilityValue.Items.Add("TWLS_WHITE");
               _cmbCapabilityValue.Items.Add("TWLS_UV");
               _cmbCapabilityValue.Items.Add("TWLS_IR");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[7];
               _capValue[0] = TwainCapabilityValue.LightSourceRed;
               _capValue[1] = TwainCapabilityValue.LightSourceGreen;
               _capValue[2] = TwainCapabilityValue.LightSourceBlue;
               _capValue[3] = TwainCapabilityValue.LightSourceNone;
               _capValue[4] = TwainCapabilityValue.LightSourceWhite;
               _capValue[5] = TwainCapabilityValue.LightSourceUV;
               _capValue[6] = TwainCapabilityValue.LightSourceIR;
               break;
            case TwainCapabilityType.ImageNoiseFilter: /* ICAP_NOISEFILTER */
               _cmbCapabilityValue.Items.Add("TWNF_NONE");
               _cmbCapabilityValue.Items.Add("TWNF_AUTO");
               _cmbCapabilityValue.Items.Add("TWNF_LONEPIXEL");
               _cmbCapabilityValue.Items.Add("TWNF_MAJORITYRULE");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[4];
               _capValue[0] = TwainCapabilityValue.NoiseFilterNone;
               _capValue[1] = TwainCapabilityValue.NoiseFilterAuto;
               _capValue[2] = TwainCapabilityValue.NoiseFilterLonePixel;
               _capValue[3] = TwainCapabilityValue.NoiseFilterMajorityRule;
               break;
            case TwainCapabilityType.ImageOrientation:/* ICAP_ORIENTATION */
               _cmbCapabilityValue.Items.Add("TWOR_ROT0");
               _cmbCapabilityValue.Items.Add("TWOR_ROT90");
               _cmbCapabilityValue.Items.Add("TWOR_ROT180");
               _cmbCapabilityValue.Items.Add("TWOR_ROT270");
               _cmbCapabilityValue.Items.Add("TWOR_PORTRAIT");
               _cmbCapabilityValue.Items.Add("TWOR_LANDSCAPE");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[6];
               _capValue[0] = TwainCapabilityValue.OrientationRot0;
               _capValue[1] = TwainCapabilityValue.OrientationRot90;
               _capValue[2] = TwainCapabilityValue.OrientationRot180;
               _capValue[3] = TwainCapabilityValue.OrientationRot270;
               _capValue[4] = TwainCapabilityValue.OrientationPortrait;
               _capValue[5] = TwainCapabilityValue.OrientationLandscape;
               break;
            case TwainCapabilityType.ImageOverScan:/* ICAP_OVERSCAN */
               _cmbCapabilityValue.Items.Add("TWOV_NONE");
               _cmbCapabilityValue.Items.Add("TWOV_AUTO");
               _cmbCapabilityValue.Items.Add("TWOV_TOPBOTTOM");
               _cmbCapabilityValue.Items.Add("TWOV_LEFTRIGHT");
               _cmbCapabilityValue.Items.Add("TWOV_ALL");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[5];
               _capValue[0] = TwainCapabilityValue.OverScanNone;
               _capValue[1] = TwainCapabilityValue.OverScanAuto;
               _capValue[2] = TwainCapabilityValue.OverScanTopBottom;
               _capValue[3] = TwainCapabilityValue.OverScanLeftRight;
               _capValue[4] = TwainCapabilityValue.OverScanAll;
               break;
            case TwainCapabilityType.ImagePlanarChunky: /* ICAP_PLANARCHUNKY */
               _cmbCapabilityValue.Items.Add("TWPC_CHUNKY");
               _cmbCapabilityValue.Items.Add("TWPC_PLANAR");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[2];
               _capValue[0] = TwainCapabilityValue.PlanarChunkyChunky;
               _capValue[1] = TwainCapabilityValue.PlanarChunkyPlanar;
               break;
            case TwainCapabilityType.ImagePixelFlavor: /* ICAP_PIXELFLAVOR */
               _cmbCapabilityValue.Items.Add("TWPF_CHOCOLATE");
               _cmbCapabilityValue.Items.Add("TWPF_VANILLA");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[2];
               _capValue[0] = TwainCapabilityValue.PixelFlavorChocolate;
               _capValue[1] = TwainCapabilityValue.PixelFlavorVanilla;
               break;
            case TwainCapabilityType.ImagePixelType: /* ICAP_PIXELTYPE */
               _cmbCapabilityValue.Items.Add("TWPT_BW");
               _cmbCapabilityValue.Items.Add("TWPT_GRAY");
               _cmbCapabilityValue.Items.Add("TWPT_RGB");
               _cmbCapabilityValue.Items.Add("TWPT_PALETTE");
               _cmbCapabilityValue.Items.Add("TWPT_CMY");
               _cmbCapabilityValue.Items.Add("TWPT_CMYK");
               _cmbCapabilityValue.Items.Add("TWPT_YUV");
               _cmbCapabilityValue.Items.Add("TWPT_YUVK");
               _cmbCapabilityValue.Items.Add("TWPT_CIEXYZ");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[9];
               _capValue[0] = TwainCapabilityValue.PixelTypeBW;
               _capValue[1] = TwainCapabilityValue.PixelTypeGray;
               _capValue[2] = TwainCapabilityValue.PixelTypeRgb;
               _capValue[3] = TwainCapabilityValue.PixelTypePalette;
               _capValue[4] = TwainCapabilityValue.PixelTypeCmy;
               _capValue[5] = TwainCapabilityValue.PixelTypeCmyk;
               _capValue[6] = TwainCapabilityValue.PixelTypeYuv;
               _capValue[7] = TwainCapabilityValue.PixelTypeYuvk;
               _capValue[8] = TwainCapabilityValue.PixelTypeCieXyz;
               break;
            case TwainCapabilityType.ImageSupportedSizes: /* ICAP_SUPPORTEDSIZES */
               _cmbCapabilityValue.Items.Add("TWSS_NONE");
               _cmbCapabilityValue.Items.Add("TWSS_A4LETTER");
               _cmbCapabilityValue.Items.Add("TWSS_B5LETTER");
               _cmbCapabilityValue.Items.Add("TWSS_USLETTER");
               _cmbCapabilityValue.Items.Add("TWSS_USLEGAL");
               _cmbCapabilityValue.Items.Add("TWSS_A5");
               _cmbCapabilityValue.Items.Add("TWSS_B4");
               _cmbCapabilityValue.Items.Add("TWSS_B6");
               _cmbCapabilityValue.Items.Add("TWSS_USLEDGER");
               _cmbCapabilityValue.Items.Add("TWSS_USEXECUTIVE");
               _cmbCapabilityValue.Items.Add("TWSS_A3");
               _cmbCapabilityValue.Items.Add("TWSS_B3");
               _cmbCapabilityValue.Items.Add("TWSS_A6");
               _cmbCapabilityValue.Items.Add("TWSS_C4");
               _cmbCapabilityValue.Items.Add("TWSS_C5");
               _cmbCapabilityValue.Items.Add("TWSS_C6");
               _cmbCapabilityValue.Items.Add("TWSS_4A0");
               _cmbCapabilityValue.Items.Add("TWSS_2A0");
               _cmbCapabilityValue.Items.Add("TWSS_A0");
               _cmbCapabilityValue.Items.Add("TWSS_A1");
               _cmbCapabilityValue.Items.Add("TWSS_A2");
               _cmbCapabilityValue.Items.Add("TWSS_A4");
               _cmbCapabilityValue.Items.Add("TWSS_A7");
               _cmbCapabilityValue.Items.Add("TWSS_A8");
               _cmbCapabilityValue.Items.Add("TWSS_A9");
               _cmbCapabilityValue.Items.Add("TWSS_A10");
               _cmbCapabilityValue.Items.Add("TWSS_ISOB0");
               _cmbCapabilityValue.Items.Add("TWSS_ISOB1");
               _cmbCapabilityValue.Items.Add("TWSS_ISOB2");
               _cmbCapabilityValue.Items.Add("TWSS_ISOB3");
               _cmbCapabilityValue.Items.Add("TWSS_ISOB4");
               _cmbCapabilityValue.Items.Add("TWSS_ISOB5");
               _cmbCapabilityValue.Items.Add("TWSS_ISOB6");
               _cmbCapabilityValue.Items.Add("TWSS_ISOB7");
               _cmbCapabilityValue.Items.Add("TWSS_ISOB8");
               _cmbCapabilityValue.Items.Add("TWSS_ISOB9");
               _cmbCapabilityValue.Items.Add("TWSS_ISOB10");
               _cmbCapabilityValue.Items.Add("TWSS_JISB0");
               _cmbCapabilityValue.Items.Add("TWSS_JISB1");
               _cmbCapabilityValue.Items.Add("TWSS_JISB2");
               _cmbCapabilityValue.Items.Add("TWSS_JISB3");
               _cmbCapabilityValue.Items.Add("TWSS_JISB4");
               _cmbCapabilityValue.Items.Add("TWSS_JISB5");
               _cmbCapabilityValue.Items.Add("TWSS_JISB6");
               _cmbCapabilityValue.Items.Add("TWSS_JISB7");
               _cmbCapabilityValue.Items.Add("TWSS_JISB8");
               _cmbCapabilityValue.Items.Add("TWSS_JISB9");
               _cmbCapabilityValue.Items.Add("TWSS_JISB10");
               _cmbCapabilityValue.Items.Add("TWSS_C0");
               _cmbCapabilityValue.Items.Add("TWSS_C1");
               _cmbCapabilityValue.Items.Add("TWSS_C2");
               _cmbCapabilityValue.Items.Add("TWSS_C3");
               _cmbCapabilityValue.Items.Add("TWSS_C7");
               _cmbCapabilityValue.Items.Add("TWSS_C8");
               _cmbCapabilityValue.Items.Add("TWSS_C9");
               _cmbCapabilityValue.Items.Add("TWSS_C10");
               _cmbCapabilityValue.Items.Add("TWSS_USSTATEMENT");
               _cmbCapabilityValue.Items.Add("TWSS_BUSINESSCARD");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[56];
               _capValue[0] = TwainCapabilityValue.SupportedSizesNone;
               _capValue[1] = TwainCapabilityValue.SupportedSizesA4Letter;
               _capValue[2] = TwainCapabilityValue.SupportedSizesB5Letter;
               _capValue[3] = TwainCapabilityValue.SupportedSizesUsLetter;
               _capValue[4] = TwainCapabilityValue.SupportedSizesUsLegal;
               _capValue[5] = TwainCapabilityValue.SupportedSizesA5;
               _capValue[6] = TwainCapabilityValue.SupportedSizesB4;
               _capValue[7] = TwainCapabilityValue.SupportedSizesB6;
               _capValue[8] = TwainCapabilityValue.SupportedSizesUsLedger;
               _capValue[9] = TwainCapabilityValue.SupportedSizesUsExecutive;
               _capValue[10] = TwainCapabilityValue.SupportedSizesA3;
               _capValue[11] = TwainCapabilityValue.SupportedSizesB3;
               _capValue[12] = TwainCapabilityValue.SupportedSizesA6;
               _capValue[13] = TwainCapabilityValue.SupportedSizesC4;
               _capValue[14] = TwainCapabilityValue.SupportedSizesC6;
               _capValue[15] = TwainCapabilityValue.SupportedSizes4A0;
               _capValue[16] = TwainCapabilityValue.SupportedSizes2A0;
               _capValue[17] = TwainCapabilityValue.SupportedSizesA0;
               _capValue[18] = TwainCapabilityValue.SupportedSizesA1;
               _capValue[19] = TwainCapabilityValue.SupportedSizesA2;
               _capValue[20] = TwainCapabilityValue.SupportedSizesA4;
               _capValue[21] = TwainCapabilityValue.SupportedSizesA7;
               _capValue[22] = TwainCapabilityValue.SupportedSizesA8;
               _capValue[23] = TwainCapabilityValue.SupportedSizesA9;
               _capValue[24] = TwainCapabilityValue.SupportedSizesA10;
               _capValue[25] = TwainCapabilityValue.SupportedSizesIsoB0;
               _capValue[26] = TwainCapabilityValue.SupportedSizesIsoB1;
               _capValue[27] = TwainCapabilityValue.SupportedSizesIsoB2;
               _capValue[28] = TwainCapabilityValue.SupportedSizesIsoB3;
               _capValue[29] = TwainCapabilityValue.SupportedSizesIsoB4;
               _capValue[30] = TwainCapabilityValue.SupportedSizesIsoB5;
               _capValue[31] = TwainCapabilityValue.SupportedSizesIsoB6;
               _capValue[32] = TwainCapabilityValue.SupportedSizesIsoB7;
               _capValue[33] = TwainCapabilityValue.SupportedSizesIsoB8;
               _capValue[34] = TwainCapabilityValue.SupportedSizesIsoB9;
               _capValue[35] = TwainCapabilityValue.SupportedSizesIsoB10;
               _capValue[36] = TwainCapabilityValue.SupportedSizesJisB0;
               _capValue[37] = TwainCapabilityValue.SupportedSizesJisB1;
               _capValue[38] = TwainCapabilityValue.SupportedSizesJisB2;
               _capValue[39] = TwainCapabilityValue.SupportedSizesJisB4;
               _capValue[40] = TwainCapabilityValue.SupportedSizesJisB5;
               _capValue[41] = TwainCapabilityValue.SupportedSizesJisB6;
               _capValue[42] = TwainCapabilityValue.SupportedSizesJisB7;
               _capValue[43] = TwainCapabilityValue.SupportedSizesJisB8;
               _capValue[44] = TwainCapabilityValue.SupportedSizesJisB9;
               _capValue[45] = TwainCapabilityValue.SupportedSizesJisB10;
               _capValue[46] = TwainCapabilityValue.SupportedSizesC0;
               _capValue[47] = TwainCapabilityValue.SupportedSizesC1;
               _capValue[48] = TwainCapabilityValue.SupportedSizesC2;
               _capValue[49] = TwainCapabilityValue.SupportedSizesC3;
               _capValue[50] = TwainCapabilityValue.SupportedSizesC7;
               _capValue[51] = TwainCapabilityValue.SupportedSizesC8;
               _capValue[52] = TwainCapabilityValue.SupportedSizesC9;
               _capValue[53] = TwainCapabilityValue.SupportedSizesC10;
               _capValue[54] = TwainCapabilityValue.SupportedSizesUsStatement;
               _capValue[55] = TwainCapabilityValue.SupportedSizesBusinessCard;
               break;
            case TwainCapabilityType.ImageTransferMechanism: /* ICAP_XFERMECH */
               _cmbCapabilityValue.Items.Add("TWSX_NATIVE");
               _cmbCapabilityValue.Items.Add("TWSX_FILE");
               _cmbCapabilityValue.Items.Add("TWSX_MEMORY");
               _cmbCapabilityValue.Items.Add("TWSX_FILE2");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[4];
               _capValue[0] = TwainCapabilityValue.TransferMechanismNative;
               _capValue[1] = TwainCapabilityValue.TransferMechanismFile;
               _capValue[2] = TwainCapabilityValue.TransferMechanismMemory;
               _capValue[3] = TwainCapabilityValue.TransferMechanismFile2;
               break;
            case TwainCapabilityType.ImageUnits: /* ICAP_UNITS */
               _cmbCapabilityValue.Items.Add("TWUN_INCHES");
               _cmbCapabilityValue.Items.Add("TWUN_CENTIMETERS");
               _cmbCapabilityValue.Items.Add("TWUN_PICAS");
               _cmbCapabilityValue.Items.Add("TWUN_POINTS");
               _cmbCapabilityValue.Items.Add("TWUN_TWIPS");
               _cmbCapabilityValue.Items.Add("TWUN_PIXELS");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[6];
               _capValue[0] = TwainCapabilityValue.UnitInches;
               _capValue[1] = TwainCapabilityValue.UnitCentimeters;
               _capValue[2] = TwainCapabilityValue.UnitPicas;
               _capValue[3] = TwainCapabilityValue.UnitPoints;
               _capValue[4] = TwainCapabilityValue.UnitTwips;
               _capValue[5] = TwainCapabilityValue.UnitPixels;
               break;
            case TwainCapabilityType.FeederEnabled: /* CAP_FEEDERENABLED */
               _cmbCapabilityValue.Items.Add("TRUE");
               _cmbCapabilityValue.Items.Add("FALSE");
               _cmbCapabilityValue.SelectedIndex = 0;
               break;
            case TwainCapabilityType.AutoFeed: /* CAP_AUTOFEED */
               _cmbCapabilityValue.Items.Add("TRUE");
               _cmbCapabilityValue.Items.Add("FALSE");
               _cmbCapabilityValue.SelectedIndex = 0;
               break;
            case TwainCapabilityType.ClearPage: /* CAP_CLEARPAGE */
               _cmbCapabilityValue.Items.Add("TRUE");
               _cmbCapabilityValue.Items.Add("FALSE");
               _cmbCapabilityValue.SelectedIndex = 0;
               break;
            case TwainCapabilityType.FeedPage: /* CAP_FEEDPAGE */
               _cmbCapabilityValue.Items.Add("TRUE");
               _cmbCapabilityValue.Items.Add("FALSE");
               _cmbCapabilityValue.SelectedIndex = 0;
               break;
            case TwainCapabilityType.RewindPage: /* CAP_REWINDPAGE */
               _cmbCapabilityValue.Items.Add("TRUE");
               _cmbCapabilityValue.Items.Add("FALSE");
               _cmbCapabilityValue.SelectedIndex = 0;
               break;
            case TwainCapabilityType.Indicators: /* CAP_INDICATORS */
               _cmbCapabilityValue.Items.Add("TRUE");
               _cmbCapabilityValue.Items.Add("FALSE");
               _cmbCapabilityValue.SelectedIndex = 0;
               break;
            case TwainCapabilityType.AutoScan: /* CAP_AUTOSCAN */
               _cmbCapabilityValue.Items.Add("TRUE");
               _cmbCapabilityValue.Items.Add("FALSE");
               _cmbCapabilityValue.SelectedIndex = 0;
               break;
            case TwainCapabilityType.ThumbnailsEnabled: /* CAP_THUMBNAILSENABLED */
               _cmbCapabilityValue.Items.Add("TRUE");
               _cmbCapabilityValue.Items.Add("FALSE");
               _cmbCapabilityValue.SelectedIndex = 0;
               break;
            case TwainCapabilityType.DuplexEnabled: /* CAP_DUPLEXENABLED */
               _cmbCapabilityValue.Items.Add("TRUE");
               _cmbCapabilityValue.Items.Add("FALSE");
               _cmbCapabilityValue.SelectedIndex = 0;
               break;
            case TwainCapabilityType.JobControl: /* CAP_JOBCONTROL */
               _cmbCapabilityValue.Items.Add("TWJC_NONE");
               _cmbCapabilityValue.Items.Add("TWJC_JSIC");
               _cmbCapabilityValue.Items.Add("TWJC_JSIS");
               _cmbCapabilityValue.Items.Add("TWJC_JSXC");
               _cmbCapabilityValue.Items.Add("TWJC_JSXS");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[5];
               _capValue[0] = TwainCapabilityValue.JobControlNone;
               _capValue[1] = TwainCapabilityValue.JobControlJsic;
               _capValue[2] = TwainCapabilityValue.JobControlJsis;
               _capValue[3] = TwainCapabilityValue.JobControlJsxc;
               _capValue[4] = TwainCapabilityValue.JobControlJsxs;
               break;
            case TwainCapabilityType.Alarms: /* CAP_ALARMS */
               _cmbCapabilityValue.Items.Add("TWAL_ALARM");
               _cmbCapabilityValue.Items.Add("TWAL_FEEDERERROR");
               _cmbCapabilityValue.Items.Add("TWAL_FEEDERWARNING");
               _cmbCapabilityValue.Items.Add("TWAL_BARCODE");
               _cmbCapabilityValue.Items.Add("TWAL_DOUBLEFEED");
               _cmbCapabilityValue.Items.Add("TWAL_JAM");
               _cmbCapabilityValue.Items.Add("TWAL_PATCHCODE");
               _cmbCapabilityValue.Items.Add("TWAL_POWER");
               _cmbCapabilityValue.Items.Add("TWAL_SKEW");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[9];
               _capValue[0] = TwainCapabilityValue.AlarmsAlarm;
               _capValue[1] = TwainCapabilityValue.AlarmsFeederError;
               _capValue[2] = TwainCapabilityValue.AlarmsFeederWarning;
               _capValue[3] = TwainCapabilityValue.AlarmsBarcode;
               _capValue[4] = TwainCapabilityValue.AlarmsDoubleFeed;
               _capValue[5] = TwainCapabilityValue.AlarmsJam;
               _capValue[6] = TwainCapabilityValue.AlarmsPatchCode;
               _capValue[7] = TwainCapabilityValue.AlarmsPower;
               _capValue[8] = TwainCapabilityValue.AlarmsSkew;
               break;
            case TwainCapabilityType.DeviceEvent: /* CAP_DEVICEEVENT */
               _cmbCapabilityValue.Items.Add("TWDE_CUSTOMEVENTS");
               _cmbCapabilityValue.Items.Add("TWDE_CHECKAUTOMATICCAPTURE");
               _cmbCapabilityValue.Items.Add("TWDE_CHECKBATTERY");
               _cmbCapabilityValue.Items.Add("TWDE_CHECKDEVICEONLINE");
               _cmbCapabilityValue.Items.Add("TWDE_CHECKFLASH");
               _cmbCapabilityValue.Items.Add("TWDE_CHECKPOWERSUPPLY");
               _cmbCapabilityValue.Items.Add("TWDE_CHECKRESOLUTION");
               _cmbCapabilityValue.Items.Add("TWDE_DEVICEADDED");
               _cmbCapabilityValue.Items.Add("TWDE_DEVICEOFFLINE");
               _cmbCapabilityValue.Items.Add("TWDE_DEVICEREADY");
               _cmbCapabilityValue.Items.Add("TWDE_DEVICEREMOVED");
               _cmbCapabilityValue.Items.Add("TWDE_IMAGECAPTURED");
               _cmbCapabilityValue.Items.Add("TWDE_IMAGEDELETED");
               _cmbCapabilityValue.Items.Add("TWDE_PAPERDOUBLEFEED");
               _cmbCapabilityValue.Items.Add("TWDE_PAPERJAM");
               _cmbCapabilityValue.Items.Add("TWDE_LAMPFAILURE");
               _cmbCapabilityValue.Items.Add("TWDE_POWERSAVE");
               _cmbCapabilityValue.Items.Add("TWDE_POWERSAVENOTIFY");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[18];
               _capValue[0] = TwainCapabilityValue.DeviceEventCustomEvents;
               _capValue[1] = TwainCapabilityValue.DeviceEventCheckAutomaticCapture;
               _capValue[2] = TwainCapabilityValue.DeviceEventCheckBattery;
               _capValue[3] = TwainCapabilityValue.DeviceEventCheckDeviceOnline;
               _capValue[4] = TwainCapabilityValue.DeviceEventCheckFlash;
               _capValue[5] = TwainCapabilityValue.DeviceEventCheckPowerSupply;
               _capValue[6] = TwainCapabilityValue.DeviceEventCheckResolution;
               _capValue[7] = TwainCapabilityValue.DeviceEventDeviceAdded;
               _capValue[8] = TwainCapabilityValue.DeviceEventDeviceOffline;
               _capValue[9] = TwainCapabilityValue.DeviceEventDeviceReady;
               _capValue[10] = TwainCapabilityValue.DeviceEventDeviceRemoved;
               _capValue[11] = TwainCapabilityValue.DeviceEventImageCaptured;
               _capValue[12] = TwainCapabilityValue.DeviceEventImageDeleted;
               _capValue[13] = TwainCapabilityValue.DeviceEventPaperDoubleFeed;
               _capValue[14] = TwainCapabilityValue.DeviceEventPaperJam;
               _capValue[15] = TwainCapabilityValue.DeviceEventLampFailure;
               _capValue[16] = TwainCapabilityValue.DeviceEventPowerSave;
               _capValue[17] = TwainCapabilityValue.DeviceEventPowerSaveNotify;
               break;
            case TwainCapabilityType.Printer: /* CAP_PRINTER */
               _cmbCapabilityValue.Items.Add("TWPR_IMPRINTERTOPBEFORE");
               _cmbCapabilityValue.Items.Add("TWPR_IMPRINTERTOPAFTER");
               _cmbCapabilityValue.Items.Add("TWPR_IMPRINTERBOTTOMBEFORE");
               _cmbCapabilityValue.Items.Add("TWPR_IMPRINTERBOTTOMAFTER");
               _cmbCapabilityValue.Items.Add("TWPR_ENDORSERTOPBEFORE");
               _cmbCapabilityValue.Items.Add("TWPR_ENDORSERTOPAFTER");
               _cmbCapabilityValue.Items.Add("TWPR_ENDORSERBOTTOMBEFORE");
               _cmbCapabilityValue.Items.Add("TWPR_ENDORSERBOTTOMAFTER");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[8];
               _capValue[0] = TwainCapabilityValue.PrinterImprinterTopBefore;
               _capValue[1] = TwainCapabilityValue.PrinterImprinterTopAfter;
               _capValue[2] = TwainCapabilityValue.PrinterImprinterBottomBefore;
               _capValue[3] = TwainCapabilityValue.PrinterImprinterBottomAfter;
               _capValue[4] = TwainCapabilityValue.PrinterEndorserTopBefore;
               _capValue[5] = TwainCapabilityValue.PrinterEndorserTopAfter;
               _capValue[6] = TwainCapabilityValue.PrinterEndorserBottomBefore;
               _capValue[7] = TwainCapabilityValue.PrinterEndorserBottomAfter;
               break;
            case TwainCapabilityType.PrinterEnabled: /* CAP_PRINTERENABLED */
               _cmbCapabilityValue.Items.Add("TRUE");
               _cmbCapabilityValue.Items.Add("FALSE");
               _cmbCapabilityValue.SelectedIndex = 0;
               break;
            case TwainCapabilityType.PrinterMode: /* CAP_PRINTERMODE */
               _cmbCapabilityValue.Items.Add("TWPM_SINGLESTRING");
               _cmbCapabilityValue.Items.Add("TWPM_MULTISTRING");
               _cmbCapabilityValue.Items.Add("TWPM_COMPOUNDSTRING");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[3];
               _capValue[0] = TwainCapabilityValue.PrinterModeSingleString;
               _capValue[1] = TwainCapabilityValue.PrinterModeMultiString;
               _capValue[2] = TwainCapabilityValue.PrinterModeCompoundString;
               break;
            case TwainCapabilityType.Language: /* CAP_LANGUAGE */
               _cmbCapabilityValue.Items.Add("TWLG_DAN");
               _cmbCapabilityValue.Items.Add("TWLG_DUT");
               _cmbCapabilityValue.Items.Add("TWLG_ENG");
               _cmbCapabilityValue.Items.Add("TWLG_FCF");
               _cmbCapabilityValue.Items.Add("TWLG_FIN");
               _cmbCapabilityValue.Items.Add("TWLG_FRN");
               _cmbCapabilityValue.Items.Add("TWLG_GER");
               _cmbCapabilityValue.Items.Add("TWLG_ICE");
               _cmbCapabilityValue.Items.Add("TWLG_ITN");
               _cmbCapabilityValue.Items.Add("TWLG_NOR");
               _cmbCapabilityValue.Items.Add("TWLG_POR");
               _cmbCapabilityValue.Items.Add("TWLG_SPA");
               _cmbCapabilityValue.Items.Add("TWLG_SWE");
               _cmbCapabilityValue.Items.Add("TWLG_USA");
               _cmbCapabilityValue.Items.Add("TWLG_USERLOCALE");
               _cmbCapabilityValue.Items.Add("TWLG_AFRIKAANS");
               _cmbCapabilityValue.Items.Add("TWLG_ALBANIA");
               _cmbCapabilityValue.Items.Add("TWLG_ARABIC");
               _cmbCapabilityValue.Items.Add("TWLG_ARABIC_ALGERIA");
               _cmbCapabilityValue.Items.Add("TWLG_ARABIC_BAHRAIN");
               _cmbCapabilityValue.Items.Add("TWLG_ARABIC_EGYPT");
               _cmbCapabilityValue.Items.Add("TWLG_ARABIC_IRAQ");
               _cmbCapabilityValue.Items.Add("TWLG_ARABIC_JORDAN");
               _cmbCapabilityValue.Items.Add("TWLG_ARABIC_KUWAIT");
               _cmbCapabilityValue.Items.Add("TWLG_ARABIC_LEBANON");
               _cmbCapabilityValue.Items.Add("TWLG_ARABIC_LIBYA");
               _cmbCapabilityValue.Items.Add("TWLG_ARABIC_MOROCCO");
               _cmbCapabilityValue.Items.Add("TWLG_ARABIC_OMAN");
               _cmbCapabilityValue.Items.Add("TWLG_ARABIC_QATAR");
               _cmbCapabilityValue.Items.Add("TWLG_ARABIC_SAUDIARABIA");
               _cmbCapabilityValue.Items.Add("TWLG_ARABIC_SYRIA");
               _cmbCapabilityValue.Items.Add("TWLG_ARABIC_TUNISIA");
               _cmbCapabilityValue.Items.Add("TWLG_ARABIC_UAE");
               _cmbCapabilityValue.Items.Add("TWLG_ARABIC_YEMEN");
               _cmbCapabilityValue.Items.Add("TWLG_BASQUE");
               _cmbCapabilityValue.Items.Add("TWLG_BYELORUSSIAN");
               _cmbCapabilityValue.Items.Add("TWLG_BULGARIAN");
               _cmbCapabilityValue.Items.Add("TWLG_CATALAN");
               _cmbCapabilityValue.Items.Add("TWLG_CHINESE");
               _cmbCapabilityValue.Items.Add("TWLG_CHINESE_HONGKONG");
               _cmbCapabilityValue.Items.Add("TWLG_CHINESE_PRC");
               _cmbCapabilityValue.Items.Add("TWLG_CHINESE_SINGAPORE");
               _cmbCapabilityValue.Items.Add("TWLG_CHINESE_SIMPLIFIED");
               _cmbCapabilityValue.Items.Add("TWLG_CHINESE_TAIWAN");
               _cmbCapabilityValue.Items.Add("TWLG_CHINESE_TRADITIONAL");
               _cmbCapabilityValue.Items.Add("TWLG_CROATIA");
               _cmbCapabilityValue.Items.Add("TWLG_CZECH");
               _cmbCapabilityValue.Items.Add("TWLG_DANISH");
               _cmbCapabilityValue.Items.Add("TWLG_DUTCH");
               _cmbCapabilityValue.Items.Add("TWLG_DUTCH_BELGIAN");
               _cmbCapabilityValue.Items.Add("TWLG_ENGLISH");
               _cmbCapabilityValue.Items.Add("TWLG_ENGLISH_AUSTRALIAN");
               _cmbCapabilityValue.Items.Add("TWLG_ENGLISH_CANADIAN");
               _cmbCapabilityValue.Items.Add("TWLG_ENGLISH_IRELAND");
               _cmbCapabilityValue.Items.Add("TWLG_ENGLISH_NEWZEALAND");
               _cmbCapabilityValue.Items.Add("TWLG_ENGLISH_SOUTHAFRICA");
               _cmbCapabilityValue.Items.Add("TWLG_ENGLISH_UK");
               _cmbCapabilityValue.Items.Add("TWLG_ENGLISH_USA");
               _cmbCapabilityValue.Items.Add("TWLG_ESTONIAN");
               _cmbCapabilityValue.Items.Add("TWLG_FAEROESE");
               _cmbCapabilityValue.Items.Add("TWLG_FARSI");
               _cmbCapabilityValue.Items.Add("TWLG_FINNISH");
               _cmbCapabilityValue.Items.Add("TWLG_FRENCH");
               _cmbCapabilityValue.Items.Add("TWLG_FRENCH_BELGIAN");
               _cmbCapabilityValue.Items.Add("TWLG_FRENCH_CANADIAN");
               _cmbCapabilityValue.Items.Add("TWLG_FRENCH_LUXEMBOURG");
               _cmbCapabilityValue.Items.Add("TWLG_FRENCH_SWISS");
               _cmbCapabilityValue.Items.Add("TWLG_GERMAN");
               _cmbCapabilityValue.Items.Add("TWLG_GERMAN_AUSTRIAN");
               _cmbCapabilityValue.Items.Add("TWLG_GERMAN_LUXEMBOURG");
               _cmbCapabilityValue.Items.Add("TWLG_GERMAN_LIECHTENSTEIN");
               _cmbCapabilityValue.Items.Add("TWLG_GERMAN_SWISS");
               _cmbCapabilityValue.Items.Add("TWLG_GREEK");
               _cmbCapabilityValue.Items.Add("TWLG_HEBREW");
               _cmbCapabilityValue.Items.Add("TWLG_HUNGARIAN");
               _cmbCapabilityValue.Items.Add("TWLG_ICELANDIC");
               _cmbCapabilityValue.Items.Add("TWLG_INDONESIAN");
               _cmbCapabilityValue.Items.Add("TWLG_ITALIAN");
               _cmbCapabilityValue.Items.Add("TWLG_ITALIAN_SWISS");
               _cmbCapabilityValue.Items.Add("TWLG_JAPANESE");
               _cmbCapabilityValue.Items.Add("TWLG_KOREAN");
               _cmbCapabilityValue.Items.Add("TWLG_KOREAN_JOHAB");
               _cmbCapabilityValue.Items.Add("TWLG_LATVIAN");
               _cmbCapabilityValue.Items.Add("TWLG_LITHUANIAN");
               _cmbCapabilityValue.Items.Add("TWLG_NORWEGIAN");
               _cmbCapabilityValue.Items.Add("TWLG_NORWEGIAN_BOKMAL");
               _cmbCapabilityValue.Items.Add("TWLG_NORWEGIAN_NYNORSK");
               _cmbCapabilityValue.Items.Add("TWLG_POLISH");
               _cmbCapabilityValue.Items.Add("TWLG_PORTUGUESE");
               _cmbCapabilityValue.Items.Add("TWLG_PORTUGUESE_BRAZIL");
               _cmbCapabilityValue.Items.Add("TWLG_ROMANIAN");
               _cmbCapabilityValue.Items.Add("TWLG_RUSSIAN");
               _cmbCapabilityValue.Items.Add("TWLG_SERBIAN_LATIN");
               _cmbCapabilityValue.Items.Add("TWLG_SLOVAK");
               _cmbCapabilityValue.Items.Add("TWLG_SLOVENIAN");
               _cmbCapabilityValue.Items.Add("TWLG_SPANISH");
               _cmbCapabilityValue.Items.Add("TWLG_SPANISH_MEXICAN");
               _cmbCapabilityValue.Items.Add("TWLG_SPANISH_MODERN");
               _cmbCapabilityValue.Items.Add("TWLG_SWEDISH");
               _cmbCapabilityValue.Items.Add("TWLG_THAI");
               _cmbCapabilityValue.Items.Add("TWLG_TURKISH");
               _cmbCapabilityValue.Items.Add("TWLG_UKRANIAN");
               _cmbCapabilityValue.Items.Add("TWLG_ASSAMESE");
               _cmbCapabilityValue.Items.Add("TWLG_BENGALI");
               _cmbCapabilityValue.Items.Add("TWLG_BIHARI");
               _cmbCapabilityValue.Items.Add("TWLG_BODO");
               _cmbCapabilityValue.Items.Add("TWLG_DOGRI");
               _cmbCapabilityValue.Items.Add("TWLG_GUJARATI");
               _cmbCapabilityValue.Items.Add("TWLG_HARYANVI");
               _cmbCapabilityValue.Items.Add("TWLG_HINDI");
               _cmbCapabilityValue.Items.Add("TWLG_KANNADA");
               _cmbCapabilityValue.Items.Add("TWLG_KASHMIRI");
               _cmbCapabilityValue.Items.Add("TWLG_MALAYALAM");
               _cmbCapabilityValue.Items.Add("TWLG_MARATHI");
               _cmbCapabilityValue.Items.Add("TWLG_MARWARI");
               _cmbCapabilityValue.Items.Add("TWLG_MEGHALAYAN");
               _cmbCapabilityValue.Items.Add("TWLG_MIZO");
               _cmbCapabilityValue.Items.Add("TWLG_NAGA");
               _cmbCapabilityValue.Items.Add("TWLG_ORISSI");
               _cmbCapabilityValue.Items.Add("TWLG_PUNJABI");
               _cmbCapabilityValue.Items.Add("TWLG_PUSHTU");
               _cmbCapabilityValue.Items.Add("TWLG_SERBIAN_CYRILLIC");
               _cmbCapabilityValue.Items.Add("TWLG_SIKKIMI");
               _cmbCapabilityValue.Items.Add("TWLG_SWEDISH_FINLAND");
               _cmbCapabilityValue.Items.Add("TWLG_TAMIL");
               _cmbCapabilityValue.Items.Add("TWLG_TELUGU");
               _cmbCapabilityValue.Items.Add("TWLG_TRIPURI");
               _cmbCapabilityValue.Items.Add("TWLG_URDU");
               _cmbCapabilityValue.Items.Add("TWLG_VIETNAMESE");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[129];
               _capValue[0] = TwainCapabilityValue.LanguageDan;
               _capValue[1] = TwainCapabilityValue.LanguageDut;
               _capValue[2] = TwainCapabilityValue.LanguageEng;
               _capValue[3] = TwainCapabilityValue.LanguageFcf;
               _capValue[4] = TwainCapabilityValue.LanguageFin;
               _capValue[5] = TwainCapabilityValue.LanguageFrn;
               _capValue[6] = TwainCapabilityValue.LanguageGer;
               _capValue[7] = TwainCapabilityValue.LanguageIce;
               _capValue[8] = TwainCapabilityValue.LanguageItn;
               _capValue[9] = TwainCapabilityValue.LanguageNor;
               _capValue[10] = TwainCapabilityValue.LanguagePor;
               _capValue[11] = TwainCapabilityValue.LanguageSpa;
               _capValue[12] = TwainCapabilityValue.LanguageSwe;
               _capValue[13] = TwainCapabilityValue.LanguageUsa;
               _capValue[14] = TwainCapabilityValue.LanguageUserLocale;
               _capValue[15] = TwainCapabilityValue.LanguageAfrikaans;
               _capValue[16] = TwainCapabilityValue.LanguageAlbania;
               _capValue[17] = TwainCapabilityValue.LanguageArabic;
               _capValue[18] = TwainCapabilityValue.LanguageArabicAlgeria;
               _capValue[19] = TwainCapabilityValue.LanguageArabicBahrain;
               _capValue[20] = TwainCapabilityValue.LanguageArabicEgypt;
               _capValue[21] = TwainCapabilityValue.LanguageArabicIraq;
               _capValue[22] = TwainCapabilityValue.LanguageArabicJordan;
               _capValue[23] = TwainCapabilityValue.LanguageArabicKuwait;
               _capValue[24] = TwainCapabilityValue.LanguageArabicLebanon;
               _capValue[25] = TwainCapabilityValue.LanguageArabicLibya;
               _capValue[26] = TwainCapabilityValue.LanguageArabicMorocco;
               _capValue[27] = TwainCapabilityValue.LanguageArabicOman;
               _capValue[28] = TwainCapabilityValue.LanguageArabicQatar;
               _capValue[29] = TwainCapabilityValue.LanguageArabicSaudiArabia;
               _capValue[30] = TwainCapabilityValue.LanguageArabicSyria;
               _capValue[31] = TwainCapabilityValue.LanguageArabicTunisia;
               _capValue[32] = TwainCapabilityValue.LanguageArabicUae;
               _capValue[33] = TwainCapabilityValue.LanguageArabicYemen;
               _capValue[34] = TwainCapabilityValue.LanguageBasque;
               _capValue[35] = TwainCapabilityValue.LanguageByelorussian;
               _capValue[36] = TwainCapabilityValue.LanguageBulgarian;
               _capValue[37] = TwainCapabilityValue.LanguageCatalan;
               _capValue[38] = TwainCapabilityValue.LanguageChinese;
               _capValue[39] = TwainCapabilityValue.LanguageChineseHongKong;
               _capValue[40] = TwainCapabilityValue.LanguageChinesePrc;
               _capValue[41] = TwainCapabilityValue.LanguageChineseSimplified;
               _capValue[42] = TwainCapabilityValue.LanguageChineseSingapore;
               _capValue[43] = TwainCapabilityValue.LanguageChineseTaiwan;
               _capValue[44] = TwainCapabilityValue.LanguageChineseTraditional;
               _capValue[45] = TwainCapabilityValue.LanguageCroatia;
               _capValue[46] = TwainCapabilityValue.LanguageCzech;
               _capValue[47] = TwainCapabilityValue.LanguageDanish;
               _capValue[48] = TwainCapabilityValue.LanguageDutch;
               _capValue[49] = TwainCapabilityValue.LanguageDutchBelgian;
               _capValue[50] = TwainCapabilityValue.LanguageEnglish;
               _capValue[51] = TwainCapabilityValue.LanguageEnglishAustralian;
               _capValue[52] = TwainCapabilityValue.LanguageEnglishCanadian;
               _capValue[53] = TwainCapabilityValue.LanguageEnglishIreland;
               _capValue[54] = TwainCapabilityValue.LanguageEnglishNewZealand;
               _capValue[55] = TwainCapabilityValue.LanguageEnglishSouthAfrica;
               _capValue[56] = TwainCapabilityValue.LanguageEnglishUK;
               _capValue[57] = TwainCapabilityValue.LanguageEnglishUsa;
               _capValue[58] = TwainCapabilityValue.LanguageEstonian;
               _capValue[59] = TwainCapabilityValue.LanguageFaeroese;
               _capValue[60] = TwainCapabilityValue.LanguageFarsi;
               _capValue[61] = TwainCapabilityValue.LanguageFinnish;
               _capValue[62] = TwainCapabilityValue.LanguageFrench;
               _capValue[63] = TwainCapabilityValue.LanguageFrenchBelgian;
               _capValue[64] = TwainCapabilityValue.LanguageFrenchCanadian;
               _capValue[65] = TwainCapabilityValue.LanguageFrenchLuxembourg;
               _capValue[66] = TwainCapabilityValue.LanguageFrenchSwiss;
               _capValue[67] = TwainCapabilityValue.LanguageGerman;
               _capValue[68] = TwainCapabilityValue.LanguageGermanAustrian;
               _capValue[69] = TwainCapabilityValue.LanguageGermanLuxembourg;
               _capValue[70] = TwainCapabilityValue.LanguageGermanLiechtenstein;
               _capValue[71] = TwainCapabilityValue.LanguageGermanSwiss;
               _capValue[72] = TwainCapabilityValue.LanguageGreek;
               _capValue[73] = TwainCapabilityValue.LanguageHebrew;
               _capValue[74] = TwainCapabilityValue.LanguageHungarian;
               _capValue[75] = TwainCapabilityValue.LanguageIcelandic;
               _capValue[76] = TwainCapabilityValue.LanguageIndonesian;
               _capValue[77] = TwainCapabilityValue.LanguageItalian;
               _capValue[78] = TwainCapabilityValue.LanguageItalianSwiss;
               _capValue[79] = TwainCapabilityValue.LanguageJapanese;
               _capValue[80] = TwainCapabilityValue.LanguageKorean;
               _capValue[81] = TwainCapabilityValue.LanguageKoreanJohab;
               _capValue[82] = TwainCapabilityValue.LanguageLatvian;
               _capValue[83] = TwainCapabilityValue.LanguageLithuanian;
               _capValue[84] = TwainCapabilityValue.LanguageNorwegian;
               _capValue[85] = TwainCapabilityValue.LanguageNorwegianBokmal;
               _capValue[86] = TwainCapabilityValue.LanguageNorwegianNynorsk;
               _capValue[87] = TwainCapabilityValue.LanguagePolish;
               _capValue[88] = TwainCapabilityValue.LanguagePortuguese;
               _capValue[89] = TwainCapabilityValue.LanguagePortugueseBrazil;
               _capValue[90] = TwainCapabilityValue.LanguageRomanian;
               _capValue[91] = TwainCapabilityValue.LanguageRussian;
               _capValue[92] = TwainCapabilityValue.LanguageSerbianLatin;
               _capValue[93] = TwainCapabilityValue.LanguageSlovak;
               _capValue[94] = TwainCapabilityValue.LanguageSlovenian;
               _capValue[95] = TwainCapabilityValue.LanguageSpanish;
               _capValue[96] = TwainCapabilityValue.LanguageSpanishMexican;
               _capValue[97] = TwainCapabilityValue.LanguageSpanishModern;
               _capValue[98] = TwainCapabilityValue.LanguageSwedish;
               _capValue[99] = TwainCapabilityValue.LanguageThai;
               _capValue[100] = TwainCapabilityValue.LanguageTurkish;
               _capValue[101] = TwainCapabilityValue.LanguageUkranian;
               _capValue[102] = TwainCapabilityValue.LanguageAssamese;
               _capValue[103] = TwainCapabilityValue.LanguageBengali;
               _capValue[104] = TwainCapabilityValue.LanguageBihari;
               _capValue[105] = TwainCapabilityValue.LanguageBodo;
               _capValue[106] = TwainCapabilityValue.LanguageDogri;
               _capValue[107] = TwainCapabilityValue.LanguageGujarati;
               _capValue[108] = TwainCapabilityValue.LanguageHaryanvi;
               _capValue[109] = TwainCapabilityValue.LanguageHindi;
               _capValue[110] = TwainCapabilityValue.LanguageKannada;
               _capValue[111] = TwainCapabilityValue.LanguageKashmiri;
               _capValue[112] = TwainCapabilityValue.LanguageMalayalam;
               _capValue[113] = TwainCapabilityValue.LanguageMarathi;
               _capValue[114] = TwainCapabilityValue.LanguageMarwari;
               _capValue[115] = TwainCapabilityValue.LanguageMeghalayan;
               _capValue[116] = TwainCapabilityValue.LanguageMizo;
               _capValue[117] = TwainCapabilityValue.LanguageNaga;
               _capValue[118] = TwainCapabilityValue.LanguageOrissi;
               _capValue[119] = TwainCapabilityValue.LanguagePunjabi;
               _capValue[120] = TwainCapabilityValue.LanguagePushtu;
               _capValue[121] = TwainCapabilityValue.LanguageSerbianCyrillic;
               _capValue[122] = TwainCapabilityValue.LanguageSikkimi;
               _capValue[123] = TwainCapabilityValue.LanguageSwedishFinland;
               _capValue[124] = TwainCapabilityValue.LanguageTamil;
               _capValue[125] = TwainCapabilityValue.LanguageTelugu;
               _capValue[126] = TwainCapabilityValue.LanguageTripuri;
               _capValue[127] = TwainCapabilityValue.LanguageUrdu;
               _capValue[128] = TwainCapabilityValue.LanguageVietnamese;
               break;
            case TwainCapabilityType.FeederAlignment: /* CAP_FEEDERALIGNMENT */
               _cmbCapabilityValue.Items.Add("TWFA_NONE");
               _cmbCapabilityValue.Items.Add("TWFA_LEFT");
               _cmbCapabilityValue.Items.Add("TWFA_CENTER");
               _cmbCapabilityValue.Items.Add("TWFA_RIGHT");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[4];
               _capValue[0] = TwainCapabilityValue.FeederAlignmentNone;
               _capValue[1] = TwainCapabilityValue.FeederAlignmentLeft;
               _capValue[2] = TwainCapabilityValue.FeederAlignmentCenter;
               _capValue[3] = TwainCapabilityValue.FeederAlignmentRight;
               break;
            case TwainCapabilityType.FeederOrder: /* CAP_FEEDERORDER */
               _cmbCapabilityValue.Items.Add("TWFO_FIRSTPAGEFIRST");
               _cmbCapabilityValue.Items.Add("TWFO_LASTPAGEFIRST");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[2];
               _capValue[0] = TwainCapabilityValue.FeederOrderFirstPageFirst;
               _capValue[1] = TwainCapabilityValue.FeederOrderLastPageFirst;
               break;
            case TwainCapabilityType.ImageFlashUsed: /* ICAP_FLASHUSED */
               _cmbCapabilityValue.Items.Add("TRUE");
               _cmbCapabilityValue.Items.Add("FALSE");
               _cmbCapabilityValue.SelectedIndex = 0;
               break;
            case TwainCapabilityType.ImageAutomaticBorderDetection: /* ICAP_AUTOMATICBORDERDETECTION */
               _cmbCapabilityValue.Items.Add("TRUE");
               _cmbCapabilityValue.Items.Add("FALSE");
               _cmbCapabilityValue.SelectedIndex = 0;
               break;
            case TwainCapabilityType.ImageLampState: /* ICAP_LAMPSTATE */
               _cmbCapabilityValue.Items.Add("TRUE");
               _cmbCapabilityValue.Items.Add("FALSE");
               _cmbCapabilityValue.SelectedIndex = 0;
               break;
            case TwainCapabilityType.ImageBitOrderCodes: /* ICAP_BITORDERCODES */
               _cmbCapabilityValue.Items.Add("TWBO_LSBFIRST");
               _cmbCapabilityValue.Items.Add("TWBO_MSBFIRST");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[2];
               _capValue[0] = TwainCapabilityValue.BitOrderLsbFirst;
               _capValue[1] = TwainCapabilityValue.BitOrderMsbFirst;
               break;
            case TwainCapabilityType.ImagePixelFlavorCodes: /* ICAP_PIXELFLAVORCODES */
               _cmbCapabilityValue.Items.Add("TWPF_CHOCOLATE");
               _cmbCapabilityValue.Items.Add("TWPF_VANILLA");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[2];
               _capValue[0] = TwainCapabilityValue.PixelFlavorChocolate;
               _capValue[1] = TwainCapabilityValue.PixelFlavorVanilla;
               break;
            case TwainCapabilityType.ImageJpegPixelType: /* ICAP_JPEGPIXELTYPE */
               _cmbCapabilityValue.Items.Add("TWPT_BW");
               _cmbCapabilityValue.Items.Add("TWPT_GRAY");
               _cmbCapabilityValue.Items.Add("TWPT_RGB");
               _cmbCapabilityValue.Items.Add("TWPT_PALETTE");
               _cmbCapabilityValue.Items.Add("TWPT_CMY");
               _cmbCapabilityValue.Items.Add("TWPT_CMYK");
               _cmbCapabilityValue.Items.Add("TWPT_YUV");
               _cmbCapabilityValue.Items.Add("TWPT_YUVK");
               _cmbCapabilityValue.Items.Add("TWPT_CIEXYZ");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[9];
               _capValue[0] = TwainCapabilityValue.PixelTypeBW;
               _capValue[1] = TwainCapabilityValue.PixelTypeGray;
               _capValue[2] = TwainCapabilityValue.PixelTypeRgb;
               _capValue[3] = TwainCapabilityValue.PixelTypePalette;
               _capValue[4] = TwainCapabilityValue.PixelTypeCmy;
               _capValue[5] = TwainCapabilityValue.PixelTypeCmyk;
               _capValue[6] = TwainCapabilityValue.PixelTypeYuv;
               _capValue[7] = TwainCapabilityValue.PixelTypeYuvk;
               _capValue[8] = TwainCapabilityValue.PixelTypeCieXyz;
               break;
            case TwainCapabilityType.ImageUndefinedImageSize: /* ICAP_UNDEFINEDIMAGESIZE */
               _cmbCapabilityValue.Items.Add("TRUE");
               _cmbCapabilityValue.Items.Add("FALSE");
               _cmbCapabilityValue.SelectedIndex = 0;
               break;
            case TwainCapabilityType.ImageFlipRotation: /* ICAP_FLIPROTATION */
               _cmbCapabilityValue.Items.Add("TWFR_BOOK");
               _cmbCapabilityValue.Items.Add("TWFR_FANFOLD");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[2];
               _capValue[0] = TwainCapabilityValue.FlipRotationBook;
               _capValue[1] = TwainCapabilityValue.FlipRotationFanfold;
               break;
            case TwainCapabilityType.ImageBarcodeDetectionEnabled: /* ICAP_BARCODEDETECTIONENABLED */
               _cmbCapabilityValue.Items.Add("TRUE");
               _cmbCapabilityValue.Items.Add("FALSE");
               _cmbCapabilityValue.SelectedIndex = 0;
               break;
            case TwainCapabilityType.ImageExtImageInfo: /* ICAP_EXTIMAGEINFO */
               _cmbCapabilityValue.Items.Add("TRUE");
               _cmbCapabilityValue.Items.Add("FALSE");
               _cmbCapabilityValue.SelectedIndex = 0;
               break;
            case TwainCapabilityType.ImageBarcodeSearchPriorities: /* ICAP_BARCODESEARCHPRIORITIES */
               _cmbCapabilityValue.Items.Add("TWBT_3OF9");
               _cmbCapabilityValue.Items.Add("TWBT_2OF5INTERLEAVED");
               _cmbCapabilityValue.Items.Add("TWBT_2OF5NONINTERLEAVED");
               _cmbCapabilityValue.Items.Add("TWBT_CODE93");
               _cmbCapabilityValue.Items.Add("TWBT_CODE128");
               _cmbCapabilityValue.Items.Add("TWBT_UCC128");
               _cmbCapabilityValue.Items.Add("TWBT_CODABAR");
               _cmbCapabilityValue.Items.Add("TWBT_UPCA");
               _cmbCapabilityValue.Items.Add("TWBT_UPCE");
               _cmbCapabilityValue.Items.Add("TWBT_EAN8");
               _cmbCapabilityValue.Items.Add("TWBT_EAN13");
               _cmbCapabilityValue.Items.Add("TWBT_POSTNET");
               _cmbCapabilityValue.Items.Add("TWBT_PDF417");
               _cmbCapabilityValue.Items.Add("TWBT_2OF5INDUSTRIAL");
               _cmbCapabilityValue.Items.Add("TWBT_2OF5MATRIX");
               _cmbCapabilityValue.Items.Add("TWBT_2OF5DATALOGIC");
               _cmbCapabilityValue.Items.Add("TWBT_2OF5IATA");
               _cmbCapabilityValue.Items.Add("TWBT_3OF9FULLASCII");
               _cmbCapabilityValue.Items.Add("TWBT_CODABARWITHSTARTSTOP");
               _cmbCapabilityValue.Items.Add("TWBT_MAXICODE");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[20];
               _capValue[0] = TwainCapabilityValue.BarcodeType3Of9;
               _capValue[1] = TwainCapabilityValue.BarcodeType2Of5Interleaved;
               _capValue[2] = TwainCapabilityValue.BarcodeType2Of5NonInterleaved;
               _capValue[3] = TwainCapabilityValue.BarcodeTypeCode93;
               _capValue[4] = TwainCapabilityValue.BarcodeTypeCode128;
               _capValue[5] = TwainCapabilityValue.BarcodeTypeUcc128;
               _capValue[6] = TwainCapabilityValue.BarcodeTypeCodaBar;
               _capValue[7] = TwainCapabilityValue.BarcodeTypeUpca;
               _capValue[8] = TwainCapabilityValue.BarcodeTypeUpce;
               _capValue[9] = TwainCapabilityValue.BarcodeTypeEan8;
               _capValue[10] = TwainCapabilityValue.BarcodeTypeEan13;
               _capValue[11] = TwainCapabilityValue.BarcodeTypePostNet;
               _capValue[12] = TwainCapabilityValue.BarcodeTypePdf417;
               _capValue[13] = TwainCapabilityValue.BarcodeType2Of5Industrial;
               _capValue[14] = TwainCapabilityValue.BarcodeType2Of5Matrix;
               _capValue[15] = TwainCapabilityValue.BarcodeType2Of5DataLogic;
               _capValue[16] = TwainCapabilityValue.BarcodeType2Of5Iata;
               _capValue[17] = TwainCapabilityValue.BarcodeType3Of9FullAscii;
               _capValue[18] = TwainCapabilityValue.BarcodeTypeCodaBarWithStartStop;
               _capValue[19] = TwainCapabilityValue.BarcodeTypeMaxiCode;
               break;
            case TwainCapabilityType.ImageBarcodeSearchMode: /* ICAP_BARCODESEARCHMODE */
               _cmbCapabilityValue.Items.Add("TWBD_HORZ");
               _cmbCapabilityValue.Items.Add("TWBD_VERT");
               _cmbCapabilityValue.Items.Add("TWBD_HORZVERT");
               _cmbCapabilityValue.Items.Add("TWBD_VERTHORZ");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[4];
               _capValue[0] = TwainCapabilityValue.BarcodeSearchModeHorz;
               _capValue[1] = TwainCapabilityValue.BarcodeSearchModeVert;
               _capValue[2] = TwainCapabilityValue.BarcodeSearchModeHorzVert;
               _capValue[3] = TwainCapabilityValue.BarcodeSearchModeVertHorz;
               break;
            case TwainCapabilityType.ImagePatchCodeDetectionEnabled: /* ICAP_PATCHCODEDETECTIONENABLED */
               _cmbCapabilityValue.Items.Add("TRUE");
               _cmbCapabilityValue.Items.Add("FALSE");
               _cmbCapabilityValue.SelectedIndex = 0;
               break;
            case TwainCapabilityType.ImagePatchCodeSearchPriorities: /* ICAP_PATCHCODESEARCHPRIORITIES */
               _cmbCapabilityValue.Items.Add("TWPCH_PATCH1");
               _cmbCapabilityValue.Items.Add("TWPCH_PATCH2");
               _cmbCapabilityValue.Items.Add("TWPCH_PATCH3");
               _cmbCapabilityValue.Items.Add("TWPCH_PATCH4");
               _cmbCapabilityValue.Items.Add("TWPCH_PATCH6");
               _cmbCapabilityValue.Items.Add("TWPCH_PATCHT");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[6];
               _capValue[0] = TwainCapabilityValue.PatchCodePatch1;
               _capValue[1] = TwainCapabilityValue.PatchCodePatch2;
               _capValue[2] = TwainCapabilityValue.PatchCodePatch3;
               _capValue[3] = TwainCapabilityValue.PatchCodePatch4;
               _capValue[4] = TwainCapabilityValue.PatchCodePatch6;
               _capValue[5] = TwainCapabilityValue.PatchCodePatchT;
               break;
            case TwainCapabilityType.ImagePatchCodeSearchMode: /* ICAP_PATCHCODESEARCHMODE */
               _cmbCapabilityValue.Items.Add("TWBD_HORZ");
               _cmbCapabilityValue.Items.Add("TWBD_VERT");
               _cmbCapabilityValue.Items.Add("TWBD_HORZVERT");
               _cmbCapabilityValue.Items.Add("TWBD_VERTHORZ");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[4];
               _capValue[0] = TwainCapabilityValue.BarcodeSearchModeHorz;
               _capValue[1] = TwainCapabilityValue.BarcodeSearchModeVert;
               _capValue[2] = TwainCapabilityValue.BarcodeSearchModeHorzVert;
               _capValue[3] = TwainCapabilityValue.BarcodeSearchModeVertHorz;
               break;
            case TwainCapabilityType.ImageAutomaticDeskew: /* ICAP_AUTOMATICDESKEW */
               _cmbCapabilityValue.Items.Add("TRUE");
               _cmbCapabilityValue.Items.Add("FALSE");
               _cmbCapabilityValue.SelectedIndex = 0;
               break;
            case TwainCapabilityType.ImageAutomaticRotate: /* ICAP_AUTOMATICROTATE */
               _cmbCapabilityValue.Items.Add("TRUE");
               _cmbCapabilityValue.Items.Add("FALSE");
               _cmbCapabilityValue.SelectedIndex = 0;
               break;
            case TwainCapabilityType.ImageJpegQuality: /* ICAP_JPEGQUALITY */
               _cmbCapabilityValue.Items.Add("TWJQ_UNKNOWN");
               _cmbCapabilityValue.Items.Add("TWJQ_LOW");
               _cmbCapabilityValue.Items.Add("TWJQ_MEDIUM");
               _cmbCapabilityValue.Items.Add("TWJQ_HIGH");
               _cmbCapabilityValue.SelectedIndex = 0;

               _capValue = new TwainCapabilityValue[4];
               _capValue[0] = TwainCapabilityValue.JpegQualityUnknown;
               _capValue[1] = TwainCapabilityValue.JpegQualityLow;
               _capValue[2] = TwainCapabilityValue.JpegQualityMedium;
               _capValue[3] = TwainCapabilityValue.JpegQualityHigh;
               break;
            case TwainCapabilityType.ImageAutoBright: /* ICAP_AUTOBRIGHT */
               _cmbCapabilityValue.Items.Add("TRUE");
               _cmbCapabilityValue.Items.Add("FALSE");
               _cmbCapabilityValue.SelectedIndex = 0;
               break;
            case TwainCapabilityType.ImageTiles: /* ICAP_TILES */
               _cmbCapabilityValue.Items.Add("TRUE");
               _cmbCapabilityValue.Items.Add("FALSE");
               _cmbCapabilityValue.SelectedIndex = 0;
               break;
            default:
               // hide the combo box contorl
               _cmbCapabilityValue.Visible = false;

               // show the other controls
               _txtCapabilityValue.Visible = true;
               _lblCapabilityValueNote.Visible = true;
               FillCapabilityEditValue(capability);

               // disable the "Set Capability" button
               _btnCapability.Enabled = false;

               // make sure Capability Text box value is empty
               _txtCapabilityValue.Text = "";
               break;
         }
      }

      private void _cmbCapabilityName_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         if(!_useGetCapability)
         {
            int capabilityIndex = _cmbCapabilityName.SelectedIndex;
            TwainCapabilityType cap = _capType[capabilityIndex];

            FillCapabilityComboValue(cap);
         }
      }

      private void SetCapabilityValue(TwainCapabilityType cap)
      {
         using (TwainCapability twCap = new TwainCapability())
         {
            try
            {
               switch (cap)
               {
                  case TwainCapabilityType.Alarms:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.Array;

                     twCap.ArrayCapability.Count = 1;
                     twCap.ArrayCapability.ItemType = TwainItemType.Uint16;
                     twCap.ArrayCapability.SetValue(0, _capValue[_cmbCapabilityValue.SelectedIndex]);
                     break;
                  case TwainCapabilityType.AlarmVolume:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Int32;
                     twCap.OneValueCapability.Value = Convert.ToInt32(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.Author:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Str128;
                     twCap.OneValueCapability.Value = _txtCapabilityValue.Text;
                     break;
                  case TwainCapabilityType.AutoFeed:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Bool;
                     twCap.OneValueCapability.Value = (_cmbCapabilityValue.SelectedIndex == 0) ? true : false;
                     break;
                  case TwainCapabilityType.AutomaticCapture:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Int32;
                     twCap.OneValueCapability.Value = Convert.ToInt32(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.AutoScan:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Bool;
                     twCap.OneValueCapability.Value = (_cmbCapabilityValue.SelectedIndex == 0) ? true : false;
                     break;
                  case TwainCapabilityType.Caption:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Str255;
                     twCap.OneValueCapability.Value = _txtCapabilityValue.Text;
                     break;
                  case TwainCapabilityType.ClearBuffers:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ClearPage:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Bool;
                     twCap.OneValueCapability.Value = (_cmbCapabilityValue.SelectedIndex == 0) ? true : false;
                     break;
                  case TwainCapabilityType.DeviceEvent:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.Array;

                     twCap.ArrayCapability.ItemType = TwainItemType.Uint16;
                     twCap.ArrayCapability.Count = 1;
                     twCap.ArrayCapability.SetValue(0, _capValue[_cmbCapabilityValue.SelectedIndex]);
                     break;
                  case TwainCapabilityType.DuplexEnabled:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Bool;
                     twCap.OneValueCapability.Value = (_cmbCapabilityValue.SelectedIndex == 0) ? true : false;
                     break;
                  case TwainCapabilityType.Endorser:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint32;
                     twCap.OneValueCapability.Value = Convert.ToUInt32(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.FeederAlignment:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint32;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.FeederEnabled:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Bool;
                     twCap.OneValueCapability.Value = (_cmbCapabilityValue.SelectedIndex == 0) ? true : false;
                     break;
                  case TwainCapabilityType.FeederOrder:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.FeedPage:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Bool;
                     twCap.OneValueCapability.Value = (_cmbCapabilityValue.SelectedIndex == 0) ? true : false;
                     break;
                  case TwainCapabilityType.Indicators:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Bool;
                     twCap.OneValueCapability.Value = (_cmbCapabilityValue.SelectedIndex == 0) ? true : false;
                     break;
                  case TwainCapabilityType.JobControl:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.Language:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.MaxBatchBuffers:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint32;
                     twCap.OneValueCapability.Value = Convert.ToUInt32(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.Printer:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.PrinterEnabled:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Bool;
                     twCap.OneValueCapability.Value = (_cmbCapabilityValue.SelectedIndex == 0) ? true : false;
                     break;
                  case TwainCapabilityType.PrinterIndex:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint32;
                     twCap.OneValueCapability.Value = Convert.ToUInt32(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.PrinterMode:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.PrinterString:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Str255;
                     twCap.OneValueCapability.Value = _txtCapabilityValue.Text;
                     break;
                  case TwainCapabilityType.PrinterSuffix:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Str255;
                     twCap.OneValueCapability.Value = _txtCapabilityValue.Text;
                     break;
                  case TwainCapabilityType.RewindPage:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Bool;
                     twCap.OneValueCapability.Value = (_cmbCapabilityValue.SelectedIndex == 0) ? true : false;
                     break;
                  case TwainCapabilityType.ThumbnailsEnabled:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Bool;
                     twCap.OneValueCapability.Value = (_cmbCapabilityValue.SelectedIndex == 0) ? true : false;
                     break;
                  case TwainCapabilityType.TimeBeforeFirstCapture:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Int32;
                     twCap.OneValueCapability.Value = Convert.ToInt32(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.TimeBetweenCaptures:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Int32;
                     twCap.OneValueCapability.Value = Convert.ToInt32(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.TransferCount:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Int16;
                     twCap.OneValueCapability.Value = Convert.ToInt16(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImageAutoBright:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Bool;
                     twCap.OneValueCapability.Value = (_cmbCapabilityValue.SelectedIndex == 0) ? true : false;
                     break;
                  case TwainCapabilityType.ImageAutomaticBorderDetection:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Bool;
                     twCap.OneValueCapability.Value = (_cmbCapabilityValue.SelectedIndex == 0) ? true : false;
                     break;
                  case TwainCapabilityType.ImageAutomaticDeskew:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Bool;
                     twCap.OneValueCapability.Value = (_cmbCapabilityValue.SelectedIndex == 0) ? true : false;
                     break;
                  case TwainCapabilityType.ImageAutomaticRotate:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Bool;
                     twCap.OneValueCapability.Value = (_cmbCapabilityValue.SelectedIndex == 0) ? true : false;
                     break;
                  case TwainCapabilityType.ImageBarcodeDetectionEnabled:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Bool;
                     twCap.OneValueCapability.Value = (_cmbCapabilityValue.SelectedIndex == 0) ? true : false;
                     break;
                  case TwainCapabilityType.ImageBarcodeMaxRetries:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint32;
                     twCap.OneValueCapability.Value = Convert.ToUInt32(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImageBarcodeMaxSearchPriorities:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint32;
                     twCap.OneValueCapability.Value = Convert.ToUInt32(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImageBarcodeSearchMode:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImageBarcodeSearchPriorities:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.Array;

                     twCap.ArrayCapability.ItemType = TwainItemType.Uint16;
                     twCap.ArrayCapability.Count = 1;
                     twCap.ArrayCapability.SetValue(0, _capValue[_cmbCapabilityValue.SelectedIndex]);
                     break;
                  case TwainCapabilityType.ImageBarcodeTimeout:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint32;
                     twCap.OneValueCapability.Value = Convert.ToUInt32(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImageBitDepth:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = Convert.ToUInt16(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImageBitDepthReduction:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImageBitOrder:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImageBitOrderCodes:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImageBrightness:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Fix32;
                     twCap.OneValueCapability.Value = Convert.ToSingle(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImageCcittKFactor:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = Convert.ToUInt16(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImageCompression:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImageContrast:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Fix32;
                     twCap.OneValueCapability.Value = Convert.ToSingle(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImageCustomHalftone:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint8;
                     twCap.OneValueCapability.Value = Convert.ToByte(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImageExposureTime:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Fix32;
                     twCap.OneValueCapability.Value = Convert.ToSingle(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImageExtImageInfo:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Bool;
                     twCap.OneValueCapability.Value = (_cmbCapabilityValue.SelectedIndex == 0) ? true : false;
                     break;
                  case TwainCapabilityType.ImageFilter:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImageFlashUsed:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Bool;
                     twCap.OneValueCapability.Value = (_cmbCapabilityValue.SelectedIndex == 0) ? true : false;
                     break;
                  case TwainCapabilityType.ImageFlashUsed2:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImageFlipRotation:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImageGamma:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Fix32;
                     twCap.OneValueCapability.Value = Convert.ToSingle(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImageHalftones:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Str32;
                     twCap.OneValueCapability.Value = _txtCapabilityValue.Text;
                     break;
                  case TwainCapabilityType.ImageHighlight:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Fix32;
                     twCap.OneValueCapability.Value = Convert.ToSingle(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImageImageDataSet:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint32;
                     twCap.OneValueCapability.Value = Convert.ToUInt32(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImageImageFileFormat:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImageImageFilter:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImageJpegPixelType:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImageJpegQuality:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Int16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImageLampState:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Int16;
                     twCap.OneValueCapability.Value = (_cmbCapabilityValue.SelectedIndex == 0) ? true : false;
                     break;
                  case TwainCapabilityType.ImageLightPath:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImageLightSource:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImageMaxFrames:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = Convert.ToUInt16(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImageNoiseFilter:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImageOrientation:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImageOverScan:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImagePatchCodeDetectionEnabled:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Bool;
                     twCap.OneValueCapability.Value = (_cmbCapabilityValue.SelectedIndex == 0) ? true : false;
                     break;
                  case TwainCapabilityType.ImagePatchCodeMaxRetries:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint32;
                     twCap.OneValueCapability.Value = Convert.ToUInt32(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImagePatchCodeMaxSearchPriorities:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint32;
                     twCap.OneValueCapability.Value = Convert.ToUInt32(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImagePatchCodeSearchMode:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImagePatchCodeSearchPriorities:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.Array;

                     twCap.ArrayCapability.ItemType = TwainItemType.Uint16;
                     twCap.ArrayCapability.Count = 1;
                     twCap.ArrayCapability.SetValue(0, _capValue[_cmbCapabilityValue.SelectedIndex]);
                     break;
                  case TwainCapabilityType.ImagePatchCodeTimeout:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint32;
                     twCap.OneValueCapability.Value = Convert.ToUInt32(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImagePixelFlavor:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImagePixelFlavorCodes:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImagePixelType:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImagePlanarChunky:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImageRotation:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Fix32;
                     twCap.OneValueCapability.Value = Convert.ToSingle(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImageShadow:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Fix32;
                     twCap.OneValueCapability.Value = Convert.ToSingle(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImageSupportedSizes:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImageThreshold:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Fix32;
                     twCap.OneValueCapability.Value = Convert.ToSingle(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImageTiles:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Bool;
                     twCap.OneValueCapability.Value = (_cmbCapabilityValue.SelectedIndex == 0) ? true : false;
                     break;
                  case TwainCapabilityType.ImageTimeFill:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = Convert.ToUInt16(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImageUndefinedImageSize:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Bool;
                     twCap.OneValueCapability.Value = (_cmbCapabilityValue.SelectedIndex == 0) ? true : false;
                     break;
                  case TwainCapabilityType.ImageUnits:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImageTransferMechanism:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Uint16;
                     twCap.OneValueCapability.Value = _capValue[_cmbCapabilityValue.SelectedIndex];
                     break;
                  case TwainCapabilityType.ImageXResolution:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Fix32;
                     twCap.OneValueCapability.Value = Convert.ToSingle(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImageXScaling:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Fix32;
                     twCap.OneValueCapability.Value = Convert.ToSingle(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImageYResolution:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Fix32;
                     twCap.OneValueCapability.Value = Convert.ToSingle(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImageYScaling:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Fix32;
                     twCap.OneValueCapability.Value = Convert.ToSingle(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.ImageZoomFactor:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Int16;
                     twCap.OneValueCapability.Value = Convert.ToInt16(_txtCapabilityValue.Text);
                     break;
                  case TwainCapabilityType.DeviceTimeDate:
                     twCap.Information.Type = cap;
                     twCap.Information.ContainerType = TwainContainerType.OneValue;

                     twCap.OneValueCapability.ItemType = TwainItemType.Str32;
                     twCap.OneValueCapability.Value = _txtCapabilityValue.Text;
                     break;
               }
            }
            catch
            {
               Messager.ShowError(this, "The passed value is invalid");
               return;
            }

            try
            {
               _session.SetCapability(twCap, TwainSetCapabilityMode.Set);
               Messager.ShowInformation(this, string.Format("{0} value is set", twCap.Information.Type.ToString()));
            }
            catch (Exception ex)
            {
               Messager.ShowError(this, ex);
            }
         }
      }

      private void GetCurrentCapabilityValue(TwainCapabilityType cap)
      {
         try
         {
            TwainCapability twainCap = _session.GetCapability(cap, TwainGetCapabilityMode.GetCurrent);

            object twainValue = null;
            switch(twainCap.Information.ContainerType)
            {
               case TwainContainerType.OneValue:
                  twainValue = twainCap.OneValueCapability.Value;
                  break;
               case TwainContainerType.Enumeration:
                  twainValue = twainCap.EnumerationCapability.GetValue(twainCap.EnumerationCapability.CurrentIndex);
                  break;
               case TwainContainerType.Array:
                  twainValue = twainCap.ArrayCapability.GetValue(0);
                  break;
               case TwainContainerType.Range:
                  twainValue = twainCap.RangeCapability.DefaultValue;
                  break;
            }

            string msg = string.Format("Current value for {0} = {1}", twainCap.Information.Type.ToString(), Convert.ToString(twainValue));
            Messager.ShowInformation(this, msg);
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void _btnCapability_Click(object sender, System.EventArgs e)
      {
         int capabilityIndex = _cmbCapabilityName.SelectedIndex;
         TwainCapabilityType cap = _capType[capabilityIndex];

         if(!_useGetCapability)
            SetCapabilityValue(cap);
         else
            GetCurrentCapabilityValue(cap);
      }

      private void _btnClose_Click(object sender, System.EventArgs e)
      {
         DialogResult = DialogResult.OK;
      }

      private void _txtCapabilityValue_TextChanged(object sender, System.EventArgs e)
      {
         if(!_useGetCapability)
         {
            if(_txtCapabilityValue.Text != "")
               _btnCapability.Enabled = true;
            else
               _btnCapability.Enabled = false;
         }
      }
   }
}
