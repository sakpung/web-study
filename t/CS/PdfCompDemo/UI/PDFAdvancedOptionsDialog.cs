// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PdfCompDemo
{
   /// <summary>
   /// Summary description for PdfAdvancedOptionsDialog.
   /// </summary>
   public class PdfAdvancedOptionsDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.GroupBox _gbCompressionTypes;
      private System.Windows.Forms.Label _lblBestQuality;
      private System.Windows.Forms.Label _lblBestCompression;
      private System.Windows.Forms.ComboBox _cmboSegmentationOptions;
      private System.Windows.Forms.CheckBox _cbSearchForBackground;
      private System.Windows.Forms.Label _lblSegmentationOptions;
      private System.Windows.Forms.GroupBox _gbSegmentationOptions;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOK;
      private Label _lblPictures;
      private Label _lbl1BPPImages;
      private Label _lbl2BPPImages;
      private ComboBox _cmbo1BPPImages;
      private ComboBox _cmbo2BPPImages;
      private TrackBar _trkbQFactor;
      private ComboBox _cmboPictures;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public PdfAdvancedOptionsDialog( )
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
         this._cmboSegmentationOptions = new System.Windows.Forms.ComboBox();
         this._cbSearchForBackground = new System.Windows.Forms.CheckBox();
         this._lblSegmentationOptions = new System.Windows.Forms.Label();
         this._gbSegmentationOptions = new System.Windows.Forms.GroupBox();
         this._gbCompressionTypes = new System.Windows.Forms.GroupBox();
         this._lblBestCompression = new System.Windows.Forms.Label();
         this._lblBestQuality = new System.Windows.Forms.Label();
         this._lblPictures = new System.Windows.Forms.Label();
         this._lbl1BPPImages = new System.Windows.Forms.Label();
         this._lbl2BPPImages = new System.Windows.Forms.Label();
         this._cmbo1BPPImages = new System.Windows.Forms.ComboBox();
         this._cmbo2BPPImages = new System.Windows.Forms.ComboBox();
         this._trkbQFactor = new System.Windows.Forms.TrackBar();
         this._cmboPictures = new System.Windows.Forms.ComboBox();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this._gbSegmentationOptions.SuspendLayout();
         this._gbCompressionTypes.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._trkbQFactor)).BeginInit();
         this.SuspendLayout();
         // 
         // _cmboSegmentationOptions
         // 
         this._cmboSegmentationOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmboSegmentationOptions.Items.AddRange(new object[] {
            "Favor 1 Bit segments",
            "Favor 2 Bit segments",
            "Force 1 Bit segments",
            "Force 2 Bit segments"});
         this._cmboSegmentationOptions.Location = new System.Drawing.Point(152, 19);
         this._cmboSegmentationOptions.Name = "_cmboSegmentationOptions";
         this._cmboSegmentationOptions.Size = new System.Drawing.Size(160, 21);
         this._cmboSegmentationOptions.TabIndex = 1;
         // 
         // _cbSearchForBackground
         // 
         this._cbSearchForBackground.Location = new System.Drawing.Point(16, 64);
         this._cbSearchForBackground.Name = "_cbSearchForBackground";
         this._cbSearchForBackground.Size = new System.Drawing.Size(160, 24);
         this._cbSearchForBackground.TabIndex = 2;
         this._cbSearchForBackground.Text = "Sea&rch for background";
         // 
         // _lblSegmentationOptions
         // 
         this._lblSegmentationOptions.Location = new System.Drawing.Point(8, 24);
         this._lblSegmentationOptions.Name = "_lblSegmentationOptions";
         this._lblSegmentationOptions.Size = new System.Drawing.Size(120, 24);
         this._lblSegmentationOptions.TabIndex = 0;
         this._lblSegmentationOptions.Text = "S&egmentation Options";
         // 
         // _gbSegmentationOptions
         // 
         this._gbSegmentationOptions.Controls.Add(this._lblSegmentationOptions);
         this._gbSegmentationOptions.Controls.Add(this._cbSearchForBackground);
         this._gbSegmentationOptions.Controls.Add(this._cmboSegmentationOptions);
         this._gbSegmentationOptions.Location = new System.Drawing.Point(16, 258);
         this._gbSegmentationOptions.Name = "_gbSegmentationOptions";
         this._gbSegmentationOptions.Size = new System.Drawing.Size(336, 104);
         this._gbSegmentationOptions.TabIndex = 1;
         this._gbSegmentationOptions.TabStop = false;
         this._gbSegmentationOptions.Text = "Segmentation Options";
         // 
         // _gbCompressionTypes
         // 
         this._gbCompressionTypes.Controls.Add(this._lblBestCompression);
         this._gbCompressionTypes.Controls.Add(this._lblBestQuality);
         this._gbCompressionTypes.Controls.Add(this._lblPictures);
         this._gbCompressionTypes.Controls.Add(this._lbl1BPPImages);
         this._gbCompressionTypes.Controls.Add(this._lbl2BPPImages);
         this._gbCompressionTypes.Controls.Add(this._cmbo1BPPImages);
         this._gbCompressionTypes.Controls.Add(this._cmbo2BPPImages);
         this._gbCompressionTypes.Controls.Add(this._trkbQFactor);
         this._gbCompressionTypes.Controls.Add(this._cmboPictures);
         this._gbCompressionTypes.Location = new System.Drawing.Point(16, 12);
         this._gbCompressionTypes.Name = "_gbCompressionTypes";
         this._gbCompressionTypes.Size = new System.Drawing.Size(336, 240);
         this._gbCompressionTypes.TabIndex = 0;
         this._gbCompressionTypes.TabStop = false;
         this._gbCompressionTypes.Text = "&CompressionTypes";
         // 
         // _lblBestCompression
         // 
         this._lblBestCompression.Location = new System.Drawing.Point(208, 156);
         this._lblBestCompression.Name = "_lblBestCompression";
         this._lblBestCompression.Size = new System.Drawing.Size(104, 16);
         this._lblBestCompression.TabIndex = 7;
         this._lblBestCompression.Text = "Best Compression";
         // 
         // _lblBestQuality
         // 
         this._lblBestQuality.Location = new System.Drawing.Point(15, 156);
         this._lblBestQuality.Name = "_lblBestQuality";
         this._lblBestQuality.Size = new System.Drawing.Size(98, 16);
         this._lblBestQuality.TabIndex = 6;
         this._lblBestQuality.Text = "Best Quality";
         // 
         // _lblPictures
         // 
         this._lblPictures.Location = new System.Drawing.Point(15, 119);
         this._lblPictures.Name = "_lblPictures";
         this._lblPictures.Size = new System.Drawing.Size(48, 16);
         this._lblPictures.TabIndex = 4;
         this._lblPictures.Text = "&Pictures";
         // 
         // _lbl1BPPImages
         // 
         this._lbl1BPPImages.Location = new System.Drawing.Point(15, 31);
         this._lbl1BPPImages.Name = "_lbl1BPPImages";
         this._lbl1BPPImages.Size = new System.Drawing.Size(88, 16);
         this._lbl1BPPImages.TabIndex = 0;
         this._lbl1BPPImages.Text = "&1BPP Images";
         // 
         // _lbl2BPPImages
         // 
         this._lbl2BPPImages.Location = new System.Drawing.Point(15, 71);
         this._lbl2BPPImages.Name = "_lbl2BPPImages";
         this._lbl2BPPImages.Size = new System.Drawing.Size(88, 24);
         this._lbl2BPPImages.TabIndex = 2;
         this._lbl2BPPImages.Text = "&2BPP Images";
         // 
         // _cmbo1BPPImages
         // 
         this._cmbo1BPPImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbo1BPPImages.Items.AddRange(new object[] {
            "ZIP",
            "Lempel Ziv Welch (LZW)",
            "Fax CCITT G3 1D",
            "Fax CCITT G3 2D",
            "Fax CCITT G4",
            "JBIG2"});
         this._cmbo1BPPImages.Location = new System.Drawing.Point(111, 31);
         this._cmbo1BPPImages.Name = "_cmbo1BPPImages";
         this._cmbo1BPPImages.Size = new System.Drawing.Size(184, 21);
         this._cmbo1BPPImages.TabIndex = 1;
         // 
         // _cmbo2BPPImages
         // 
         this._cmbo2BPPImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbo2BPPImages.Items.AddRange(new object[] {
            "ZIP",
            "Lempel Ziv Welch (LZW)"});
         this._cmbo2BPPImages.Location = new System.Drawing.Point(111, 71);
         this._cmbo2BPPImages.Name = "_cmbo2BPPImages";
         this._cmbo2BPPImages.Size = new System.Drawing.Size(184, 21);
         this._cmbo2BPPImages.TabIndex = 3;
         // 
         // _trkbQFactor
         // 
         this._trkbQFactor.Location = new System.Drawing.Point(15, 175);
         this._trkbQFactor.Maximum = 255;
         this._trkbQFactor.Minimum = 2;
         this._trkbQFactor.Name = "_trkbQFactor";
         this._trkbQFactor.RightToLeft = System.Windows.Forms.RightToLeft.No;
         this._trkbQFactor.Size = new System.Drawing.Size(304, 45);
         this._trkbQFactor.TabIndex = 8;
         this._trkbQFactor.TickFrequency = 10;
         this._trkbQFactor.Value = 2;
         // 
         // _cmboPictures
         // 
         this._cmboPictures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmboPictures.Items.AddRange(new object[] {
            "JPEG",
            "JPEG_YUV422",
            "JPEG_YUV411",
            "JPEG_PROGRESSIVE",
            "JPEG_PROGRESSIVE_ YUV422",
            "JPEG_PROGRESSIVE_ YUV411",
            "ZIP",
            "Lempel Ziv Welch (LZW)",
            "Jpeg2000(J2k)"});
         this._cmboPictures.Location = new System.Drawing.Point(111, 116);
         this._cmboPictures.Name = "_cmboPictures";
         this._cmboPictures.Size = new System.Drawing.Size(184, 21);
         this._cmboPictures.TabIndex = 5;
         this._cmboPictures.SelectedIndexChanged += new System.EventHandler(this._cmboPictures_SelectedIndexChanged);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(216, 400);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(112, 24);
         this._btnCancel.TabIndex = 3;
         this._btnCancel.Text = "Cancel";
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOK.Location = new System.Drawing.Point(32, 400);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(112, 24);
         this._btnOK.TabIndex = 2;
         this._btnOK.Text = "OK";
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // PdfAdvancedOptionsDialog
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(376, 438);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this._gbSegmentationOptions);
         this.Controls.Add(this._gbCompressionTypes);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PdfAdvancedOptionsDialog";
         this.ShowInTaskbar = false;
         this.Text = "Pdf Advanced Options";
         this.Load += new System.EventHandler(this.PdfAdvancedOptionsDialog_Load);
         this._gbSegmentationOptions.ResumeLayout(false);
         this._gbCompressionTypes.ResumeLayout(false);
         this._gbCompressionTypes.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._trkbQFactor)).EndInit();
         this.ResumeLayout(false);

      }
      #endregion

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


      private PdfAdvancedOptions _advancedOptions;

      private void PdfAdvancedOptionsDialog_Load(object sender, System.EventArgs e)
      {

         SetDialog();

      }

      private void SetDialog( )
      {
         _cmboSegmentationOptions.SelectedIndex = AdvancedOptions.SegmentationComboSel;
         _cmbo1BPPImages.SelectedIndex = AdvancedOptions.OneBitComboSel;
         _cmbo2BPPImages.SelectedIndex = AdvancedOptions.TwoBitComboSel;
         _cmboPictures.SelectedIndex = AdvancedOptions.PictComboSel;
         _trkbQFactor.Value = AdvancedOptions.QFactor;
         _cbSearchForBackground.Checked = AdvancedOptions.CheckBackground;

      }

      private void _btnOK_Click(object sender, System.EventArgs e)
      {
         AdvancedOptions.SegmentationComboSel = _cmboSegmentationOptions.SelectedIndex;
         AdvancedOptions.OneBitComboSel = _cmbo1BPPImages.SelectedIndex;
         AdvancedOptions.TwoBitComboSel = _cmbo2BPPImages.SelectedIndex;
         AdvancedOptions.PictComboSel = _cmboPictures.SelectedIndex;
         AdvancedOptions.QFactor = _trkbQFactor.Value;
         AdvancedOptions.CheckBackground = _cbSearchForBackground.Checked;


      }

      private void _cmboPictures_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         bool bStatus = (_cmboPictures.SelectedIndex < 6) || (_cmboPictures.SelectedIndex == 8);
         _trkbQFactor.Enabled = bStatus;
         _lblBestQuality.Enabled = bStatus;
         _lblBestCompression.Enabled = bStatus;

      }

   }
}
