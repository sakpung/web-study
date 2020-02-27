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
using Leadtools.Demos;

namespace TwainDemo
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Template));
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
         resources.ApplyResources(this._gbImageFrame, "_gbImageFrame");
         this._gbImageFrame.Name = "_gbImageFrame";
         this._gbImageFrame.TabStop = false;
         // 
         // _cmbYRes
         // 
         this._cmbYRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         resources.ApplyResources(this._cmbYRes, "_cmbYRes");
         this._cmbYRes.Name = "_cmbYRes";
         // 
         // _cmbXRes
         // 
         this._cmbXRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         resources.ApplyResources(this._cmbXRes, "_cmbXRes");
         this._cmbXRes.Name = "_cmbXRes";
         // 
         // _lblYRes
         // 
         resources.ApplyResources(this._lblYRes, "_lblYRes");
         this._lblYRes.Name = "_lblYRes";
         // 
         // _lblXRes
         // 
         resources.ApplyResources(this._lblXRes, "_lblXRes");
         this._lblXRes.Name = "_lblXRes";
         // 
         // _txtFrameBottom
         // 
         resources.ApplyResources(this._txtFrameBottom, "_txtFrameBottom");
         this._txtFrameBottom.Name = "_txtFrameBottom";
         // 
         // _txtFrameRight
         // 
         resources.ApplyResources(this._txtFrameRight, "_txtFrameRight");
         this._txtFrameRight.Name = "_txtFrameRight";
         // 
         // _txtFrameTop
         // 
         resources.ApplyResources(this._txtFrameTop, "_txtFrameTop");
         this._txtFrameTop.Name = "_txtFrameTop";
         // 
         // _txtFrameLeft
         // 
         resources.ApplyResources(this._txtFrameLeft, "_txtFrameLeft");
         this._txtFrameLeft.Name = "_txtFrameLeft";
         // 
         // _lblFrameBottom
         // 
         resources.ApplyResources(this._lblFrameBottom, "_lblFrameBottom");
         this._lblFrameBottom.Name = "_lblFrameBottom";
         // 
         // _lblFrameRight
         // 
         resources.ApplyResources(this._lblFrameRight, "_lblFrameRight");
         this._lblFrameRight.Name = "_lblFrameRight";
         // 
         // _lblFrameTop
         // 
         resources.ApplyResources(this._lblFrameTop, "_lblFrameTop");
         this._lblFrameTop.Name = "_lblFrameTop";
         // 
         // _lblFrameLeft
         // 
         resources.ApplyResources(this._lblFrameLeft, "_lblFrameLeft");
         this._lblFrameLeft.Name = "_lblFrameLeft";
         // 
         // _cmbUnit
         // 
         this._cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         resources.ApplyResources(this._cmbUnit, "_cmbUnit");
         this._cmbUnit.Name = "_cmbUnit";
         this._cmbUnit.SelectedIndexChanged += new System.EventHandler(this._cmbUnit_SelectedIndexChanged);
         // 
         // _lblUnit
         // 
         resources.ApplyResources(this._lblUnit, "_lblUnit");
         this._lblUnit.Name = "_lblUnit";
         // 
         // _gbTransferMode
         // 
         this._gbTransferMode.Controls.Add(this._rdNative);
         this._gbTransferMode.Controls.Add(this._rdMemory);
         this._gbTransferMode.Controls.Add(this._rdFile);
         resources.ApplyResources(this._gbTransferMode, "_gbTransferMode");
         this._gbTransferMode.Name = "_gbTransferMode";
         this._gbTransferMode.TabStop = false;
         // 
         // _rdNative
         // 
         resources.ApplyResources(this._rdNative, "_rdNative");
         this._rdNative.Name = "_rdNative";
         this._rdNative.Click += new System.EventHandler(this._rdNative_Click);
         // 
         // _rdMemory
         // 
         resources.ApplyResources(this._rdMemory, "_rdMemory");
         this._rdMemory.Name = "_rdMemory";
         this._rdMemory.Click += new System.EventHandler(this._rdMemory_Click);
         // 
         // _rdFile
         // 
         resources.ApplyResources(this._rdFile, "_rdFile");
         this._rdFile.Name = "_rdFile";
         this._rdFile.Click += new System.EventHandler(this._rdFile_Click);
         // 
         // _gbFileOptions
         // 
         this._gbFileOptions.Controls.Add(this._cmbFileFormat);
         this._gbFileOptions.Controls.Add(this._lblFormat);
         this._gbFileOptions.Controls.Add(this._btnBrowse);
         this._gbFileOptions.Controls.Add(this._txtFileName);
         this._gbFileOptions.Controls.Add(this._lblFileName);
         resources.ApplyResources(this._gbFileOptions, "_gbFileOptions");
         this._gbFileOptions.Name = "_gbFileOptions";
         this._gbFileOptions.TabStop = false;
         // 
         // _cmbFileFormat
         // 
         this._cmbFileFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         resources.ApplyResources(this._cmbFileFormat, "_cmbFileFormat");
         this._cmbFileFormat.Name = "_cmbFileFormat";
         // 
         // _lblFormat
         // 
         resources.ApplyResources(this._lblFormat, "_lblFormat");
         this._lblFormat.Name = "_lblFormat";
         // 
         // _btnBrowse
         // 
         resources.ApplyResources(this._btnBrowse, "_btnBrowse");
         this._btnBrowse.Name = "_btnBrowse";
         this._btnBrowse.Click += new System.EventHandler(this._btnBrowse_Click);
         // 
         // _txtFileName
         // 
         resources.ApplyResources(this._txtFileName, "_txtFileName");
         this._txtFileName.Name = "_txtFileName";
         this._txtFileName.TextChanged += new System.EventHandler(this._txtFileName_TextChanged);
         // 
         // _lblFileName
         // 
         resources.ApplyResources(this._lblFileName, "_lblFileName");
         this._lblFileName.Name = "_lblFileName";
         // 
         // _gbMemoryOptions
         // 
         this._gbMemoryOptions.Controls.Add(this._cmbCompression);
         this._gbMemoryOptions.Controls.Add(this._lblCompression);
         resources.ApplyResources(this._gbMemoryOptions, "_gbMemoryOptions");
         this._gbMemoryOptions.Name = "_gbMemoryOptions";
         this._gbMemoryOptions.TabStop = false;
         // 
         // _cmbCompression
         // 
         this._cmbCompression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         resources.ApplyResources(this._cmbCompression, "_cmbCompression");
         this._cmbCompression.Name = "_cmbCompression";
         // 
         // _lblCompression
         // 
         resources.ApplyResources(this._lblCompression, "_lblCompression");
         this._lblCompression.Name = "_lblCompression";
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
         resources.ApplyResources(this._gbImgeEfx, "_gbImgeEfx");
         this._gbImgeEfx.Name = "_gbImgeEfx";
         this._gbImgeEfx.TabStop = false;
         // 
         // _cmbHighlight
         // 
         this._cmbHighlight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         resources.ApplyResources(this._cmbHighlight, "_cmbHighlight");
         this._cmbHighlight.Name = "_cmbHighlight";
         // 
         // _lblHighlight
         // 
         resources.ApplyResources(this._lblHighlight, "_lblHighlight");
         this._lblHighlight.Name = "_lblHighlight";
         // 
         // _cmbBrightness
         // 
         this._cmbBrightness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         resources.ApplyResources(this._cmbBrightness, "_cmbBrightness");
         this._cmbBrightness.Name = "_cmbBrightness";
         // 
         // _lblBrightness
         // 
         resources.ApplyResources(this._lblBrightness, "_lblBrightness");
         this._lblBrightness.Name = "_lblBrightness";
         // 
         // _cmbContrast
         // 
         this._cmbContrast.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         resources.ApplyResources(this._cmbContrast, "_cmbContrast");
         this._cmbContrast.Name = "_cmbContrast";
         // 
         // _lblContrast
         // 
         resources.ApplyResources(this._lblContrast, "_lblContrast");
         this._lblContrast.Name = "_lblContrast";
         // 
         // _cmbHalftone
         // 
         this._cmbHalftone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         resources.ApplyResources(this._cmbHalftone, "_cmbHalftone");
         this._cmbHalftone.Name = "_cmbHalftone";
         // 
         // _lblHalftone
         // 
         resources.ApplyResources(this._lblHalftone, "_lblHalftone");
         this._lblHalftone.Name = "_lblHalftone";
         // 
         // _cmbOrientation
         // 
         this._cmbOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         resources.ApplyResources(this._cmbOrientation, "_cmbOrientation");
         this._cmbOrientation.Name = "_cmbOrientation";
         // 
         // _lblOrientation
         // 
         resources.ApplyResources(this._lblOrientation, "_lblOrientation");
         this._lblOrientation.Name = "_lblOrientation";
         // 
         // _cmbPixelType
         // 
         this._cmbPixelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         resources.ApplyResources(this._cmbPixelType, "_cmbPixelType");
         this._cmbPixelType.Name = "_cmbPixelType";
         // 
         // _lblPixelType
         // 
         resources.ApplyResources(this._lblPixelType, "_lblPixelType");
         this._lblPixelType.Name = "_lblPixelType";
         // 
         // _btnLoad
         // 
         resources.ApplyResources(this._btnLoad, "_btnLoad");
         this._btnLoad.Name = "_btnLoad";
         this._btnLoad.Click += new System.EventHandler(this._btnLoad_Click);
         // 
         // _btnSave
         // 
         resources.ApplyResources(this._btnSave, "_btnSave");
         this._btnSave.Name = "_btnSave";
         this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
         // 
         // _btnOK
         // 
         resources.ApplyResources(this._btnOK, "_btnOK");
         this._btnOK.Name = "_btnOK";
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // Template
         // 
         this.AcceptButton = this._btnOK;
         resources.ApplyResources(this, "$this");
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this._btnSave);
         this.Controls.Add(this._btnLoad);
         this.Controls.Add(this._gbImgeEfx);
         this.Controls.Add(this._gbMemoryOptions);
         this.Controls.Add(this._gbFileOptions);
         this.Controls.Add(this._gbTransferMode);
         this.Controls.Add(this._gbImageFrame);
         this.Name = "Template";
         this.Load += new System.EventHandler(this.Template_Load);
         this._gbImageFrame.ResumeLayout(false);
         this._gbImageFrame.PerformLayout();
         this._gbTransferMode.ResumeLayout(false);
         this._gbFileOptions.ResumeLayout(false);
         this._gbFileOptions.PerformLayout();
         this._gbMemoryOptions.ResumeLayout(false);
         this._gbImgeEfx.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion

      public TwainSession _twainSession = null;
      public TwainTransferMechanism _transferMode = TwainTransferMechanism.Native;
      private TwainCapabilityValue[] _unitsValue;
      private TwainCapabilityValue[] _pixelValue;
      private TwainCapabilityValue[] _orientationValue;
      private TwainCapabilityValue[] _compressionValue;
      private TwainFileFormat[] _formatValue;
      private int _selectedUnitsIndex = 0;

      private void Template_Load(object sender, System.EventArgs e)
      {
         InitializeTemplate();
      }

      private void InitializeTemplate( )
      {
         _unitsValue = new TwainCapabilityValue[6];
         _pixelValue = new TwainCapabilityValue[9];
         _orientationValue = new TwainCapabilityValue[4];
         _compressionValue = new TwainCapabilityValue[14];
         _compressionValue = new TwainCapabilityValue[14];
         _formatValue = new TwainFileFormat[10];

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
                     TwainCapabilityValue itemValue = (TwainCapabilityValue)Convert.ToUInt16(item);
                     switch(itemValue)
                     {
                        case TwainCapabilityValue.UnitCentimeters:
                           _cmbUnit.Items.Add(DemosGlobalization.GetResxString(GetType(),"resx_Centimeters")); 
                           break;
                        case TwainCapabilityValue.UnitInches:
                           _cmbUnit.Items.Add(DemosGlobalization.GetResxString(GetType(),"resx_Inches"));
                           break;
                        case TwainCapabilityValue.UnitPicas:
                           _cmbUnit.Items.Add(DemosGlobalization.GetResxString(GetType(),"resx_Picas"));
                           break;
                        case TwainCapabilityValue.UnitPixels:
                           _cmbUnit.Items.Add(DemosGlobalization.GetResxString(GetType(),"resx_Pixels"));
                           break;
                        case TwainCapabilityValue.UnitPoints:
                           _cmbUnit.Items.Add(DemosGlobalization.GetResxString(GetType(),"resx_Points"));
                           break;
                        case TwainCapabilityValue.UnitTwips:
                           _cmbUnit.Items.Add(DemosGlobalization.GetResxString(GetType(),"resx_Twips"));
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
                        TwainCapabilityValue itemValue = (TwainCapabilityValue)Convert.ToUInt16(item);
                        switch(itemValue)
                        {
                           case TwainCapabilityValue.UnitCentimeters:
                              _cmbUnit.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_Centimeters"));
                              break;
                           case TwainCapabilityValue.UnitInches:
                              _cmbUnit.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_Inches"));
                              break;
                           case TwainCapabilityValue.UnitPicas:
                              _cmbUnit.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_Picas"));
                              break;
                           case TwainCapabilityValue.UnitPixels:
                              _cmbUnit.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_Pixels"));
                              break;
                           case TwainCapabilityValue.UnitPoints:
                              _cmbUnit.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_Points"));
                              break;
                           case TwainCapabilityValue.UnitTwips:
                              _cmbUnit.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_Twips"));
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
            string errorMsg = string.Format("{0} TwainCapabilityType.ImageUnits {1} {2}", DemosGlobalization.GetResxString(GetType(), "resx_Get"), DemosGlobalization.GetResxString(GetType(), "resx_Returns"), ex.Message);
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
            string errorMsg = string.Format("{0} TwainCapabilityType.ImageFrames {1} {2}", DemosGlobalization.GetResxString(GetType(), "resx_Get"), DemosGlobalization.GetResxString(GetType(), "resx_Returns"), ex.Message);            
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
            string errorMsg = string.Format("{0} TwainCapabilityType.ImageXResolution {1} {2}", DemosGlobalization.GetResxString(GetType(), "resx_Get"), DemosGlobalization.GetResxString(GetType(), "resx_Returns"), ex.Message);   
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
            string errorMsg = string.Format("{0} TwainCapabilityType.ImageYResolution {1} {2}", DemosGlobalization.GetResxString(GetType(), "resx_Get"), DemosGlobalization.GetResxString(GetType(), "resx_Returns"), ex.Message);
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
                        object current = twnCap.EnumerationCapability.GetValue(twnCap.EnumerationCapability.CurrentIndex);

                        TwainCapabilityValue itemValue = (TwainCapabilityValue)Convert.ToUInt16(item);
                        TwainCapabilityValue currentValue = (TwainCapabilityValue)Convert.ToUInt16(current);
                        switch(itemValue)
                        {
                           case TwainCapabilityValue.TransferMechanismFile:
                              _rdFile.Enabled = true;
                              if (currentValue == itemValue)
                                 fileMode = true;
                              break;
                           case TwainCapabilityValue.TransferMechanismMemory:
                              _rdMemory.Enabled = true;
                              if (currentValue == itemValue)
                                 memoryMode = true;
                              break;
                           case TwainCapabilityValue.TransferMechanismNative:
                              _rdNative.Enabled = true;
                              if (currentValue == itemValue)
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
            string errorMsg = string.Format("{0} TwainCapabilityType.ImageTranserMechanism {1} {2}", DemosGlobalization.GetResxString(GetType(), "resx_Get"), DemosGlobalization.GetResxString(GetType(), "resx_Returns"), ex.Message);
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
         _transferMode = TwainTransferMechanism.File;

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
                     TwainFileFormat itemValue = (TwainFileFormat)Convert.ToUInt16(item);
                     switch(itemValue)
                     {
                        case TwainFileFormat.Tiff:
                           _cmbFileFormat.Items.Add("TIFF");
                           break;
                        case TwainFileFormat.Pict:
                           _cmbFileFormat.Items.Add("PICT");
                           break;
                        case TwainFileFormat.Bmp:
                           _cmbFileFormat.Items.Add("BMP");
                           break;
                        case TwainFileFormat.Xbm:
                           _cmbFileFormat.Items.Add("XBM");
                           break;
                        case TwainFileFormat.Jfif:
                           _cmbFileFormat.Items.Add("JFIF");
                           break;
                        case TwainFileFormat.Fpx:
                           _cmbFileFormat.Items.Add("FPX");
                           break;
                        case TwainFileFormat.TiffMulti:
                           _cmbFileFormat.Items.Add("TIFFMULTI");
                           break;
                        case TwainFileFormat.Png:
                           _cmbFileFormat.Items.Add("PNG");
                           break;
                        case TwainFileFormat.Spiff:
                           _cmbFileFormat.Items.Add("SPIFF");
                           break;
                        case TwainFileFormat.Exif:
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
                        TwainFileFormat itemValue = (TwainFileFormat)Convert.ToUInt16(item);
                        switch(itemValue)
                        {
                           case TwainFileFormat.Tiff:
                              _cmbFileFormat.Items.Add("TIFF");
                              break;
                           case TwainFileFormat.Pict:
                              _cmbFileFormat.Items.Add("PICT");
                              break;
                           case TwainFileFormat.Bmp:
                              _cmbFileFormat.Items.Add("BMP");
                              break;
                           case TwainFileFormat.Xbm:
                              _cmbFileFormat.Items.Add("XBM");
                              break;
                           case TwainFileFormat.Jfif:
                              _cmbFileFormat.Items.Add("JFIF");
                              break;
                           case TwainFileFormat.Fpx:
                              _cmbFileFormat.Items.Add("FPX");
                              break;
                           case TwainFileFormat.TiffMulti:
                              _cmbFileFormat.Items.Add("TIFFMULTI");
                              break;
                           case TwainFileFormat.Png:
                              _cmbFileFormat.Items.Add("PNG");
                              break;
                           case TwainFileFormat.Spiff:
                              _cmbFileFormat.Items.Add("SPIFF");
                              break;
                           case TwainFileFormat.Exif:
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
            string errorMsg = string.Format("{0} TwainCapabilityType.ImageImageFileFormat {1} {2}", DemosGlobalization.GetResxString(GetType(), "resx_Get"), DemosGlobalization.GetResxString(GetType(), "resx_Returns"), ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);

            /* disable all file modes controls */
            _txtFileName.Enabled = false;
            _btnBrowse.Enabled = false;
            _cmbFileFormat.Enabled = false;
         }
      }

      private void EnableMemoryMode( )
      {
         _transferMode = TwainTransferMechanism.Memory;

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
            string errorMsg = string.Format("{0} TwainCapabilityType.ImageCompression {1} {2}", DemosGlobalization.GetResxString(GetType(), "resx_Get"), DemosGlobalization.GetResxString(GetType(), "resx_Returns"), ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
            _cmbCompression.Enabled = false;
         }
      }

      private void EnableNativeMode( )
      {
         _transferMode = TwainTransferMechanism.Native;

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
            string errorMsg = string.Format("{0} TwainCapabilityType.ImagePixelType {1} {2}", DemosGlobalization.GetResxString(GetType(), "resx_Get"), DemosGlobalization.GetResxString(GetType(), "resx_Returns"), ex.Message);
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
                     TwainCapabilityValue itemValue = (TwainCapabilityValue)Convert.ToUInt16(item);
                     switch(itemValue)
                     {
                        case TwainCapabilityValue.OrientationRot0:
                           _cmbOrientation.Items.Add("ROT0");
                           break;
                        case TwainCapabilityValue.OrientationRot90:
                           _cmbOrientation.Items.Add("ROT90");
                           break;
                        case TwainCapabilityValue.OrientationRot180:
                           _cmbOrientation.Items.Add("ROT180");
                           break;
                        case TwainCapabilityValue.OrientationRot270:
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
                        TwainCapabilityValue itemValue = (TwainCapabilityValue)Convert.ToUInt16(item);
                        switch(itemValue)
                        {
                           case TwainCapabilityValue.OrientationRot0:
                              _cmbOrientation.Items.Add("ROT0");
                              break;
                           case TwainCapabilityValue.OrientationRot90:
                              _cmbOrientation.Items.Add("ROT90");
                              break;
                           case TwainCapabilityValue.OrientationRot180:
                              _cmbOrientation.Items.Add("ROT180");
                              break;
                           case TwainCapabilityValue.OrientationRot270:
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
            string errorMsg = string.Format("{0} TwainCapabilityType.ImageOrientation {1} {2}", DemosGlobalization.GetResxString(GetType(), "resx_Get"), DemosGlobalization.GetResxString(GetType(), "resx_Returns"), ex.Message);
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
            string errorMsg = string.Format("{0} {1} {2} {3}", DemosGlobalization.GetResxString(GetType(), "resx_Get"),capType.ToString(), DemosGlobalization.GetResxString(GetType(), "resx_Returns"), ex.Message);
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
            string errorMsg = string.Format("{0} TwainCapabilityType.ImageHalftones {1} {2}", DemosGlobalization.GetResxString(GetType(), "resx_Get"), DemosGlobalization.GetResxString(GetType(), "resx_Returns"), ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
            _cmbHalftone.Enabled = false;
         }
      }

      private string GetFileFormatString( )
      {
         string filter = "All Files (*.*)|*.*";
         switch(_formatValue[_cmbFileFormat.SelectedIndex])
         {
            case TwainFileFormat.Tiff:
               filter = "TIFF Files|*.tif";
               break;
            case TwainFileFormat.Pict:
               filter = "PICT Files|*.pct";
               break;
            case TwainFileFormat.Bmp:
               filter = "BMP Files|*.bmp";
               break;
            case TwainFileFormat.Xbm:
               filter = "XBM Files|*.xbm";
               break;
            case TwainFileFormat.Jfif:
               filter = "JFIF Files|*.jpg";
               break;
            case TwainFileFormat.Fpx:
               filter = "FPX Files|*.fpx";
               break;
            case TwainFileFormat.TiffMulti:
               filter = "TIFF Multi Files|*.tif";
               break;
            case TwainFileFormat.Png:
               filter = "PNG Files|*.png";
               break;
            case TwainFileFormat.Spiff:
               filter = "SPIFF Files|*.spif";
               break;
            case TwainFileFormat.Exif:
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
            MySetCapability(TwainCapabilityType.ImageUnits, TwainItemType.Uint16, _unitsValue[_cmbUnit.SelectedIndex]);
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("{0} TwainCapabilityType.ImageUnits {1} {2}", DemosGlobalization.GetResxString(GetType(), "resx_Set"), DemosGlobalization.GetResxString(GetType(), "resx_Returns"), ex.Message);
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

            MySetCapability(TwainCapabilityType.ImageFrames, TwainItemType.Frame, frame);
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("{0} TwainCapabilityType.ImageFrames {1} {2}", DemosGlobalization.GetResxString(GetType(), "resx_Set"), DemosGlobalization.GetResxString(GetType(), "resx_Returns"), ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
         }
      }

      private void SetXYResCapability( )
      {
         try
         {
            float xRes = (float)Convert.ToDouble(_cmbXRes.SelectedItem);
            MySetCapability(TwainCapabilityType.ImageXResolution, TwainItemType.Fix32, xRes);
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("{0} TwainCapabilityType.ImageXResolution {1} {2}", DemosGlobalization.GetResxString(GetType(), "resx_Set"), DemosGlobalization.GetResxString(GetType(), "resx_Returns"), ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
         }

         try
         {
            float yRes = (float)Convert.ToDouble(_cmbYRes.SelectedItem);
            MySetCapability(TwainCapabilityType.ImageYResolution, TwainItemType.Fix32, yRes);
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("{0} TwainCapabilityType.ImageYResolution {1} {2}", DemosGlobalization.GetResxString(GetType(), "resx_Set"), DemosGlobalization.GetResxString(GetType(), "resx_Returns"), ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
         }
      }

      private void SetXferCapability( )
      {
         try
         {
            MySetCapability(TwainCapabilityType.ImageTransferMechanism, TwainItemType.Uint16, (UInt16)_transferMode);
         }
         catch
         {
            return;
         }

         switch(_transferMode)
         {
            case TwainTransferMechanism.Native:
               /* do nothing */
               break;
            case TwainTransferMechanism.Memory:
               {
                  try
                  {
                     /* ICAP_COMPRESSION */
                     MySetCapability(TwainCapabilityType.ImageCompression, TwainItemType.Uint16, _compressionValue[_cmbCompression.SelectedIndex]);
                  }
                  catch
                  {
                  }
               }
               break;
            case TwainTransferMechanism.File:
               {
                  if(_txtFileName.Text == "")
                     return;

                  try
                  {
                     /* ICAP_IMAGEFILEFORMAT */
                     MySetCapability(TwainCapabilityType.ImageImageFileFormat, TwainItemType.Uint16, (UInt16)_formatValue[_cmbFileFormat.SelectedIndex]);

                     TwainProperties twnProps = _twainSession.Properties;
                     TwainDataTransferProperties dataTransfer = twnProps.DataTransfer;
                     dataTransfer.FileName = _txtFileName.Text;
                     dataTransfer.ScanFileFormat = _formatValue[_cmbFileFormat.SelectedIndex];
                     twnProps.DataTransfer = dataTransfer;
                     _twainSession.Properties = twnProps;
                  }
                  catch
                  {
                  }
               }
               break;
         }
      }

      private void SetPixelTypeCapability( )
      {
         try
         {
            MySetCapability(TwainCapabilityType.ImagePixelType, TwainItemType.Uint16, _pixelValue[_cmbPixelType.SelectedIndex]);
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("{0} TwainCapabilityType.ImagePixelType {1} {2}", DemosGlobalization.GetResxString(GetType(), "resx_Set"), DemosGlobalization.GetResxString(GetType(), "resx_Returns"), ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
         }
      }

      private void SetOrientationCapability( )
      {
         try
         {
            MySetCapability(TwainCapabilityType.ImageOrientation, TwainItemType.Uint16, _orientationValue[_cmbOrientation.SelectedIndex]);
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("{0} TwainCapabilityType.ImageOrientation {1} {2}", DemosGlobalization.GetResxString(GetType(), "resx_Set"), DemosGlobalization.GetResxString(GetType(), "resx_Returns"), ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
         }
      }

      private void SetContrastCapability( )
      {
         try
         {
            float contrast = (float)Convert.ToDouble(_cmbContrast.SelectedItem);
            MySetCapability(TwainCapabilityType.ImageContrast, TwainItemType.Fix32, contrast);
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("{0} TwainCapabilityType.ImageContrast {1} {2}", DemosGlobalization.GetResxString(GetType(), "resx_Set"), DemosGlobalization.GetResxString(GetType(), "resx_Returns"), ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
         }
      }

      private void SetBrightnessCapability( )
      {
         try
         {
            float brightness = (float)Convert.ToDouble(_cmbBrightness.SelectedItem);
            MySetCapability(TwainCapabilityType.ImageBrightness, TwainItemType.Fix32, brightness);
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("{0} TwainCapabilityType.ImageBrightness {1} {2}", DemosGlobalization.GetResxString(GetType(), "resx_Set"), DemosGlobalization.GetResxString(GetType(), "resx_Returns"), ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
         }
      }

      private void SetHighlightCapability( )
      {
         try
         {
            float highlight = (float)Convert.ToDouble(_cmbHighlight.SelectedItem);
            MySetCapability(TwainCapabilityType.ImageHighlight, TwainItemType.Fix32, highlight);
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("{0} TwainCapabilityType.ImageHighLight {1} {2}", DemosGlobalization.GetResxString(GetType(), "resx_Set"), DemosGlobalization.GetResxString(GetType(), "resx_Returns"), ex.Message);
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
            string errorMsg = string.Format("{0} TwainCapabilityType.ImageHalftones {1} {2}", DemosGlobalization.GetResxString(GetType(), "resx_Set"), DemosGlobalization.GetResxString(GetType(), "resx_Returns"), ex.Message);
            MainForm.AddErrorToErrorList(errorMsg);
         }
      }

      private void _txtFileName_TextChanged(object sender, System.EventArgs e)
      {
         CheckOkButton();
      }

      private void _cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
      {
         _cmbXRes.Enabled = (_unitsValue[_cmbUnit.SelectedIndex] == TwainCapabilityValue.UnitPixels) ? false : true;
         _cmbYRes.Enabled = (_unitsValue[_cmbUnit.SelectedIndex] == TwainCapabilityValue.UnitPixels) ? false : true;

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
