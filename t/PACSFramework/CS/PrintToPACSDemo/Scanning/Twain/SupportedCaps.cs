// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Leadtools.Twain;

namespace PrintToPACSDemo
{
   /// <summary>
   /// Summary description for SupportedCaps.
   /// </summary>
   public class SupportedCaps : System.Windows.Forms.Form
   {
      private System.Windows.Forms.GroupBox _gbCaps;
      private System.Windows.Forms.Label _lblCaps;
      private System.Windows.Forms.Label _lblCapsCount;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.ListBox _lstCaps;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public SupportedCaps( )
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupportedCaps));
         this._gbCaps = new System.Windows.Forms.GroupBox();
         this._lstCaps = new System.Windows.Forms.ListBox();
         this._lblCapsCount = new System.Windows.Forms.Label();
         this._lblCaps = new System.Windows.Forms.Label();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbCaps.SuspendLayout();
         this.SuspendLayout();
         // 
         // _gbCaps
         // 
         this._gbCaps.Controls.Add(this._lstCaps);
         this._gbCaps.Controls.Add(this._lblCapsCount);
         this._gbCaps.Controls.Add(this._lblCaps);
         this._gbCaps.Location = new System.Drawing.Point(8, 8);
         this._gbCaps.Name = "_gbCaps";
         this._gbCaps.Size = new System.Drawing.Size(296, 264);
         this._gbCaps.TabIndex = 0;
         this._gbCaps.TabStop = false;
         // 
         // _lstCaps
         // 
         this._lstCaps.Location = new System.Drawing.Point(16, 40);
         this._lstCaps.Name = "_lstCaps";
         this._lstCaps.Size = new System.Drawing.Size(264, 212);
         this._lstCaps.TabIndex = 2;
         // 
         // _lblCapsCount
         // 
         this._lblCapsCount.Location = new System.Drawing.Point(176, 16);
         this._lblCapsCount.Name = "_lblCapsCount";
         this._lblCapsCount.Size = new System.Drawing.Size(112, 16);
         this._lblCapsCount.TabIndex = 1;
         // 
         // _lblCaps
         // 
         this._lblCaps.Location = new System.Drawing.Point(16, 16);
         this._lblCaps.Name = "_lblCaps";
         this._lblCaps.Size = new System.Drawing.Size(168, 16);
         this._lblCaps.TabIndex = 0;
         this._lblCaps.Text = "Supported Capabilities Count = ";
         // 
         // _btnOk
         // 
         this._btnOk.Location = new System.Drawing.Point(119, 280);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(75, 23);
         this._btnOk.TabIndex = 1;
         this._btnOk.Text = "OK";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // SupportedCaps
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(312, 310);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gbCaps);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SupportedCaps";
         this.Text = "Supported Capabilities";
         this.Load += new System.EventHandler(this.SupportedCaps_Load);
         this._gbCaps.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion
      public TwainCapabilityType[] _caps = null;

      private void SupportedCaps_Load(object sender, System.EventArgs e)
      {
         int availableCapsCount = _caps.Length;
         for(int i = 0; i < _caps.Length; i++)
         {
            switch(_caps[i])
            {
               case TwainCapabilityType.CustomBase:
                  _lstCaps.Items.Add("CAP_CUSTOMBASE");
                  break;
               case TwainCapabilityType.TransferCount:
                  _lstCaps.Items.Add("CAP_XFERCOUNT");
                  break;
               case TwainCapabilityType.ImageCompression:
                  _lstCaps.Items.Add("ICAP_COMPRESSION");
                  break;
               case TwainCapabilityType.ImagePixelType:
                  _lstCaps.Items.Add("ICAP_PIXELTYPE");
                  break;
               case TwainCapabilityType.ImageUnits:
                  _lstCaps.Items.Add("ICAP_UNITS");
                  break;
               case TwainCapabilityType.ImageTransferMechanism:
                  _lstCaps.Items.Add("ICAP_XFERMECH");
                  break;
               case TwainCapabilityType.Author:
                  _lstCaps.Items.Add("CAP_AUTHOR");
                  break;
               case TwainCapabilityType.Caption:
                  _lstCaps.Items.Add("CAP_CAPTION");
                  break;
               case TwainCapabilityType.FeederEnabled:
                  _lstCaps.Items.Add("CAP_FEEDERENABLED");
                  break;
               case TwainCapabilityType.FeederLoaded:
                  _lstCaps.Items.Add("CAP_FEEDERLOADED");
                  break;
               case TwainCapabilityType.TimeDate:
                  _lstCaps.Items.Add("CAP_TIMEDATE");
                  break;
               case TwainCapabilityType.SupportedCaps:
                  _lstCaps.Items.Add("CAP_SUPPORTEDCAPS");
                  break;
               case TwainCapabilityType.ExtendedCaps:
                  _lstCaps.Items.Add("CAP_EXTENDEDCAPS");
                  break;
               case TwainCapabilityType.AutoFeed:
                  _lstCaps.Items.Add("CAP_AUTOFEED");
                  break;
               case TwainCapabilityType.ClearPage:
                  _lstCaps.Items.Add("CAP_CLEARPAGE");
                  break;
               case TwainCapabilityType.FeedPage:
                  _lstCaps.Items.Add("CAP_FEEDPAGE");
                  break;
               case TwainCapabilityType.RewindPage:
                  _lstCaps.Items.Add("CAP_REWINDPAGE");
                  break;
               case TwainCapabilityType.Indicators:
                  _lstCaps.Items.Add("CAP_INDICATORS");
                  break;
               case TwainCapabilityType.SupportedCapsExt:
                  _lstCaps.Items.Add("CAP_SUPPORTEDCAPSEXT");
                  break;
               case TwainCapabilityType.PaperDetectable:
                  _lstCaps.Items.Add("CAP_PAPERDETECTABLE");
                  break;
               case TwainCapabilityType.UIControllable:
                  _lstCaps.Items.Add("CAP_UICONTROLLABLE");
                  break;
               case TwainCapabilityType.DeviceOnline:
                  _lstCaps.Items.Add("CAP_DEVICEONLINE");
                  break;
               case TwainCapabilityType.AutoScan:
                  _lstCaps.Items.Add("CAP_AUTOSCAN");
                  break;
               case TwainCapabilityType.ThumbnailsEnabled:
                  _lstCaps.Items.Add("CAP_THUMBNAILSENABLED");
                  break;
               case TwainCapabilityType.Duplex:
                  _lstCaps.Items.Add("CAP_DUPLEX");
                  break;
               case TwainCapabilityType.DuplexEnabled:
                  _lstCaps.Items.Add("CAP_DUPLEXENABLED");
                  break;
               case TwainCapabilityType.EnabledSuiOnly:
                  _lstCaps.Items.Add("CAP_ENABLEDSUIONLY");
                  break;
               case TwainCapabilityType.CustomDSData:
                  _lstCaps.Items.Add("CAP_CUSTOMDSDATA");
                  break;
               case TwainCapabilityType.Endorser:
                  _lstCaps.Items.Add("CAP_ENDORSER");
                  break;
               case TwainCapabilityType.JobControl:
                  _lstCaps.Items.Add("CAP_JOBCONTROL");
                  break;
               case TwainCapabilityType.Alarms:
                  _lstCaps.Items.Add("CAP_ALARMS");
                  break;
               case TwainCapabilityType.AlarmVolume:
                  _lstCaps.Items.Add("CAP_ALARMVOLUME");
                  break;
               case TwainCapabilityType.AutomaticCapture:
                  _lstCaps.Items.Add("CAP_AUTOMATICCAPTURE");
                  break;
               case TwainCapabilityType.TimeBeforeFirstCapture:
                  _lstCaps.Items.Add("CAP_TIMEBEFOREFIRSTCAPTURE");
                  break;
               case TwainCapabilityType.TimeBetweenCaptures:
                  _lstCaps.Items.Add("CAP_TIMEBETWEENCAPTURES");
                  break;
               case TwainCapabilityType.ClearBuffers:
                  _lstCaps.Items.Add("CAP_CLEARBUFFERS");
                  break;
               case TwainCapabilityType.MaxBatchBuffers:
                  _lstCaps.Items.Add("CAP_MAXBATCHBUFFERS");
                  break;
               case TwainCapabilityType.DeviceTimeDate:
                  _lstCaps.Items.Add("CAP_DEVICETIMEDATE");
                  break;
               case TwainCapabilityType.PowerSupply:
                  _lstCaps.Items.Add("CAP_POWERSUPPLY");
                  break;
               case TwainCapabilityType.CameraPreviewUI:
                  _lstCaps.Items.Add("CAP_CAMERAPREVIEWUI");
                  break;
               case TwainCapabilityType.DeviceEvent:
                  _lstCaps.Items.Add("CAP_DEVICEEVENT");
                  break;
               case TwainCapabilityType.SerialNumber:
                  _lstCaps.Items.Add("CAP_SERIALNUMBER");
                  break;
               case TwainCapabilityType.Printer:
                  _lstCaps.Items.Add("CAP_PRINTER");
                  break;
               case TwainCapabilityType.PrinterEnabled:
                  _lstCaps.Items.Add("CAP_PRINTERENABLED");
                  break;
               case TwainCapabilityType.PrinterIndex:
                  _lstCaps.Items.Add("CAP_PRINTERINDEX");
                  break;
               case TwainCapabilityType.PrinterMode:
                  _lstCaps.Items.Add("CAP_PRINTERMODE");
                  break;
               case TwainCapabilityType.PrinterString:
                  _lstCaps.Items.Add("CAP_PRINTERSTRING");
                  break;
               case TwainCapabilityType.PrinterSuffix:
                  _lstCaps.Items.Add("CAP_PRINTERSUFFIX");
                  break;
               case TwainCapabilityType.Language:
                  _lstCaps.Items.Add("CAP_LANGUAGE");
                  break;
               case TwainCapabilityType.FeederAlignment:
                  _lstCaps.Items.Add("CAP_FEEDERALIGNMENT");
                  break;
               case TwainCapabilityType.FeederOrder:
                  _lstCaps.Items.Add("CAP_FEEDERORDER");
                  break;
               case TwainCapabilityType.ReacquireAllowed:
                  _lstCaps.Items.Add("CAP_REACQUIREALLOWED");
                  break;
               case TwainCapabilityType.BatteryMinutes:
                  _lstCaps.Items.Add("CAP_BATTERYMINUTES");
                  break;
               case TwainCapabilityType.BatteryPercentage:
                  _lstCaps.Items.Add("CAP_BATTERYPERCENTAGE");
                  break;
               case TwainCapabilityType.ImageAutoBright:
                  _lstCaps.Items.Add("ICAP_AUTOBRIGHT");
                  break;
               case TwainCapabilityType.ImageBrightness:
                  _lstCaps.Items.Add("ICAP_BRIGHTNESS");
                  break;
               case TwainCapabilityType.ImageContrast:
                  _lstCaps.Items.Add("ICAP_CONTRAST");
                  break;
               case TwainCapabilityType.ImageCustomHalftone:
                  _lstCaps.Items.Add("ICAP_CUSTHALFTONE");
                  break;
               case TwainCapabilityType.ImageExposureTime:
                  _lstCaps.Items.Add("ICAP_EXPOSURETIME");
                  break;
               case TwainCapabilityType.ImageFilter:
                  _lstCaps.Items.Add("ICAP_FILTER");
                  break;
               case TwainCapabilityType.ImageFlashUsed:
                  _lstCaps.Items.Add("ICAP_FLASHUSED");
                  break;
               case TwainCapabilityType.ImageGamma:
                  _lstCaps.Items.Add("ICAP_GAMMA");
                  break;
               case TwainCapabilityType.ImageHalftones:
                  _lstCaps.Items.Add("ICAP_HALFTONES");
                  break;
               case TwainCapabilityType.ImageHighlight:
                  _lstCaps.Items.Add("ICAP_HIGHLIGHT");
                  break;
               case TwainCapabilityType.ImageImageFileFormat:
                  _lstCaps.Items.Add("ICAP_IMAGEFILEFORMAT");
                  break;
               case TwainCapabilityType.ImageLampState:
                  _lstCaps.Items.Add("ICAP_LAMPSTATE");
                  break;
               case TwainCapabilityType.ImageLightSource:
                  _lstCaps.Items.Add("ICAP_LIGHTSOURCE");
                  break;
               case TwainCapabilityType.ImageOrientation:
                  _lstCaps.Items.Add("ICAP_ORIENTATION");
                  break;
               case TwainCapabilityType.ImagePhysicalWidth:
                  _lstCaps.Items.Add("ICAP_PHYSICALWIDTH");
                  break;
               case TwainCapabilityType.ImagePhysicalHeight:
                  _lstCaps.Items.Add("ICAP_PHYSICALHEIGHT");
                  break;
               case TwainCapabilityType.ImageShadow:
                  _lstCaps.Items.Add("ICAP_SHADOW");
                  break;
               case TwainCapabilityType.ImageFrames:
                  _lstCaps.Items.Add("ICAP_FRAMES");
                  break;
               case TwainCapabilityType.ImageXNativeResolution:
                  _lstCaps.Items.Add("ICAP_XNATIVERESOLUTION");
                  break;
               case TwainCapabilityType.ImageYNativeResolution:
                  _lstCaps.Items.Add("ICAP_YNATIVERESOLUTION");
                  break;
               case TwainCapabilityType.ImageXResolution:
                  _lstCaps.Items.Add("ICAP_XRESOLUTION");
                  break;
               case TwainCapabilityType.ImageYResolution:
                  _lstCaps.Items.Add("ICAP_YRESOLUTION");
                  break;
               case TwainCapabilityType.ImageMaxFrames:
                  _lstCaps.Items.Add("ICAP_MAXFRAMES");
                  break;
               case TwainCapabilityType.ImageTiles:
                  _lstCaps.Items.Add("ICAP_TILES");
                  break;
               case TwainCapabilityType.ImageBitOrder:
                  _lstCaps.Items.Add("ICAP_BITORDER");
                  break;
               case TwainCapabilityType.ImageCcittKFactor:
                  _lstCaps.Items.Add("ICAP_CCITTKFACTOR");
                  break;
               case TwainCapabilityType.ImageLightPath:
                  _lstCaps.Items.Add("ICAP_LIGHTPATH");
                  break;
               case TwainCapabilityType.ImagePixelFlavor:
                  _lstCaps.Items.Add("ICAP_PIXELFLAVOR");
                  break;
               case TwainCapabilityType.ImagePlanarChunky:
                  _lstCaps.Items.Add("ICAP_PLANARCHUNKY");
                  break;
               case TwainCapabilityType.ImageRotation:
                  _lstCaps.Items.Add("ICAP_ROTATION");
                  break;
               case TwainCapabilityType.ImageSupportedSizes:
                  _lstCaps.Items.Add("ICAP_SUPPORTEDSIZES");
                  break;
               case TwainCapabilityType.ImageThreshold:
                  _lstCaps.Items.Add("ICAP_THRESHOLD");
                  break;
               case TwainCapabilityType.ImageXScaling:
                  _lstCaps.Items.Add("ICAP_XSCALING");
                  break;
               case TwainCapabilityType.ImageYScaling:
                  _lstCaps.Items.Add("ICAP_YSCALING");
                  break;
               case TwainCapabilityType.ImageBitOrderCodes:
                  _lstCaps.Items.Add("ICAP_BITORDERCODES");
                  break;
               case TwainCapabilityType.ImagePixelFlavorCodes:
                  _lstCaps.Items.Add("ICAP_PIXELFLAVORCODES");
                  break;
               case TwainCapabilityType.ImageJpegPixelType:
                  _lstCaps.Items.Add("ICAP_JPEGPIXELTYPE");
                  break;
               case TwainCapabilityType.ImageTimeFill:
                  _lstCaps.Items.Add("ICAP_TIMEFILL");
                  break;
               case TwainCapabilityType.ImageBitDepth:
                  _lstCaps.Items.Add("ICAP_BITDEPTH");
                  break;
               case TwainCapabilityType.ImageBitDepthReduction:
                  _lstCaps.Items.Add("ICAP_BITDEPTHREDUCTION");
                  break;
               case TwainCapabilityType.ImageUndefinedImageSize:
                  _lstCaps.Items.Add("ICAP_UNDEFINEDIMAGESIZE");
                  break;
               case TwainCapabilityType.ImageImageDataSet:
                  _lstCaps.Items.Add("ICAP_IMAGEDATASET");
                  break;
               case TwainCapabilityType.ImageExtImageInfo:
                  _lstCaps.Items.Add("ICAP_EXTIMAGEINFO");
                  break;
               case TwainCapabilityType.ImageMinimumHeight:
                  _lstCaps.Items.Add("ICAP_MINIMUMHEIGHT");
                  break;
               case TwainCapabilityType.ImageMinimumWidth:
                  _lstCaps.Items.Add("ICAP_MINIMUMWIDTH");
                  break;
               case TwainCapabilityType.ImageFlipRotation:
                  _lstCaps.Items.Add("ICAP_FLIPROTATION");
                  break;
               case TwainCapabilityType.ImageBarcodeDetectionEnabled:
                  _lstCaps.Items.Add("ICAP_BARCODEDETECTIONENABLED");
                  break;
               case TwainCapabilityType.ImageSupportedBarcodeTypes:
                  _lstCaps.Items.Add("ICAP_SUPPORTEDBARCODETYPES");
                  break;
               case TwainCapabilityType.ImageBarcodeMaxSearchPriorities:
                  _lstCaps.Items.Add("ICAP_BARCODEMAXSEARCHPRIORITIES");
                  break;
               case TwainCapabilityType.ImageBarcodeSearchPriorities:
                  _lstCaps.Items.Add("ICAP_BARCODESEARCHPRIORITIES");
                  break;
               case TwainCapabilityType.ImageBarcodeSearchMode:
                  _lstCaps.Items.Add("ICAP_BARCODESEARCHMODE");
                  break;
               case TwainCapabilityType.ImageBarcodeMaxRetries:
                  _lstCaps.Items.Add("ICAP_BARCODEMAXRETRIES");
                  break;
               case TwainCapabilityType.ImageBarcodeTimeout:
                  _lstCaps.Items.Add("ICAP_BARCODETIMEOUT");
                  break;
               case TwainCapabilityType.ImageZoomFactor:
                  _lstCaps.Items.Add("ICAP_ZOOMFACTOR");
                  break;
               case TwainCapabilityType.ImagePatchCodeDetectionEnabled:
                  _lstCaps.Items.Add("ICAP_PATCHCODEDETECTIONENABLED");
                  break;
               case TwainCapabilityType.ImageSupportedPatchCodeTypes:
                  _lstCaps.Items.Add("ICAP_SUPPORTEDPATCHCODETYPES");
                  break;
               case TwainCapabilityType.ImagePatchCodeMaxSearchPriorities:
                  _lstCaps.Items.Add("ICAP_PATCHCODEMAXSEARCHPRIORITIES");
                  break;
               case TwainCapabilityType.ImagePatchCodeSearchPriorities:
                  _lstCaps.Items.Add("ICAP_PATCHCODESEARCHPRIORITIES");
                  break;
               case TwainCapabilityType.ImagePatchCodeSearchMode:
                  _lstCaps.Items.Add("ICAP_PATCHCODESEARCHMODE");
                  break;
               case TwainCapabilityType.ImagePatchCodeMaxRetries:
                  _lstCaps.Items.Add("ICAP_PATCHCODEMAXRETRIES");
                  break;
               case TwainCapabilityType.ImagePatchCodeTimeout:
                  _lstCaps.Items.Add("ICAP_PATCHCODETIMEOUT");
                  break;
               case TwainCapabilityType.ImageFlashUsed2:
                  _lstCaps.Items.Add("ICAP_FLASHUSED2");
                  break;
               case TwainCapabilityType.ImageImageFilter:
                  _lstCaps.Items.Add("ICAP_IMAGEFILTER");
                  break;
               case TwainCapabilityType.ImageNoiseFilter:
                  _lstCaps.Items.Add("ICAP_NOISEFILTER");
                  break;
               case TwainCapabilityType.ImageOverScan:
                  _lstCaps.Items.Add("ICAP_OVERSCAN");
                  break;
               case TwainCapabilityType.ImageAutomaticBorderDetection:
                  _lstCaps.Items.Add("ICAP_AUTOMATICBORDERDETECTION");
                  break;
               case TwainCapabilityType.ImageAutomaticDeskew:
                  _lstCaps.Items.Add("ICAP_AUTOMATICDESKEW");
                  break;
               case TwainCapabilityType.ImageAutomaticRotate:
                  _lstCaps.Items.Add("ICAP_AUTOMATICROTATE");
                  break;
               case TwainCapabilityType.ImageJpegQuality:
                  _lstCaps.Items.Add("ICAP_JPEGQUALITY");
                  break;
               case TwainCapabilityType.AudioAudioFileFormat:
                  _lstCaps.Items.Add("ACAP_AUDIOFILEFORMAT");
                  break;
               case TwainCapabilityType.AudioTransferMechanism:
                  _lstCaps.Items.Add("ACAP_XFERMECH");
                  break;
               default:
                  availableCapsCount--;
                  break;
            }
         }

         _lblCapsCount.Text = availableCapsCount.ToString();
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         DialogResult = DialogResult.OK;
      }
   }
}
