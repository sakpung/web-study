// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Leadtools.Annotations;

namespace Leadtools.Demos
{
   /// <summary>
   /// Summary description for AnnotationsSaveFormatDialog.
   /// </summary>
   public class AnnotationsSaveFormatDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.GroupBox _gbNonTiff;
      private System.Windows.Forms.RadioButton _rbSerialize;
      private System.Windows.Forms.GroupBox _gbTiff;
      private System.Windows.Forms.RadioButton _rbTiffTags;
      private System.Windows.Forms.RadioButton _rbNoTiffTags;
      private System.Windows.Forms.GroupBox _gbTag;
      private System.Windows.Forms.RadioButton _rbTagWang;
      private System.Windows.Forms.RadioButton _rbTagLEAD;
      private System.Windows.Forms.RadioButton _rbTagSerialize;
      private System.Windows.Forms.RadioButton _rbXml;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public AnnotationsSaveFormatDialog()
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
      protected override void Dispose( bool disposing )
      {
         if( disposing )
         {
            if(components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._gbNonTiff = new System.Windows.Forms.GroupBox();
         this._rbXml = new System.Windows.Forms.RadioButton();
         this._rbSerialize = new System.Windows.Forms.RadioButton();
         this._gbTiff = new System.Windows.Forms.GroupBox();
         this._gbTag = new System.Windows.Forms.GroupBox();
         this._rbTagWang = new System.Windows.Forms.RadioButton();
         this._rbTagLEAD = new System.Windows.Forms.RadioButton();
         this._rbTagSerialize = new System.Windows.Forms.RadioButton();
         this._rbNoTiffTags = new System.Windows.Forms.RadioButton();
         this._rbTiffTags = new System.Windows.Forms.RadioButton();
         this._gbNonTiff.SuspendLayout();
         this._gbTiff.SuspendLayout();
         this._gbTag.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(480, 24);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(75, 23);
         this._btnOk.TabIndex = 2;
         this._btnOk.Text = "OK";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(480, 56);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 3;
         this._btnCancel.Text = "Cancel";
         // 
         // _gbNonTiff
         // 
         this._gbNonTiff.Controls.Add(this._rbXml);
         this._gbNonTiff.Controls.Add(this._rbSerialize);
         this._gbNonTiff.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbNonTiff.Location = new System.Drawing.Point(16, 16);
         this._gbNonTiff.Name = "_gbNonTiff";
         this._gbNonTiff.Size = new System.Drawing.Size(448, 100);
         this._gbNonTiff.TabIndex = 0;
         this._gbNonTiff.TabStop = false;
         this._gbNonTiff.Text = "When saving non TIFF files (Objects are saved in \"FileName\".ann):";
         // 
         // _rbXml
         // 
         this._rbXml.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbXml.Location = new System.Drawing.Point(24, 55);
         this._rbXml.Name = "_rbXml";
         this._rbXml.Size = new System.Drawing.Size(392, 24);
         this._rbXml.TabIndex = 3;
         this._rbXml.Text = "XML Format (Compatible with LEADTOOLS Win32)";
         // 
         // _rbSerialize
         // 
         this._rbSerialize.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbSerialize.Location = new System.Drawing.Point(24, 32);
         this._rbSerialize.Name = "_rbSerialize";
         this._rbSerialize.Size = new System.Drawing.Size(392, 24);
         this._rbSerialize.TabIndex = 0;
         this._rbSerialize.Text = "Serialize Format (Not compatible with LEADTOOLS Win32 annotations)";
         // 
         // _gbTiff
         // 
         this._gbTiff.Controls.Add(this._gbTag);
         this._gbTiff.Controls.Add(this._rbNoTiffTags);
         this._gbTiff.Controls.Add(this._rbTiffTags);
         this._gbTiff.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbTiff.Location = new System.Drawing.Point(16, 131);
         this._gbTiff.Name = "_gbTiff";
         this._gbTiff.Size = new System.Drawing.Size(448, 264);
         this._gbTiff.TabIndex = 1;
         this._gbTiff.TabStop = false;
         this._gbTiff.Text = "When saving TIFF files:";
         // 
         // _gbTag
         // 
         this._gbTag.Controls.Add(this._rbTagWang);
         this._gbTag.Controls.Add(this._rbTagLEAD);
         this._gbTag.Controls.Add(this._rbTagSerialize);
         this._gbTag.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbTag.Location = new System.Drawing.Point(24, 72);
         this._gbTag.Name = "_gbTag";
         this._gbTag.Size = new System.Drawing.Size(408, 128);
         this._gbTag.TabIndex = 2;
         this._gbTag.TabStop = false;
         this._gbTag.Text = "TIFF tag format:";
         // 
         // _rbTagWang
         // 
         this._rbTagWang.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbTagWang.Location = new System.Drawing.Point(24, 88);
         this._rbTagWang.Name = "_rbTagWang";
         this._rbTagWang.Size = new System.Drawing.Size(368, 24);
         this._rbTagWang.TabIndex = 2;
         this._rbTagWang.Text = "Wang tag (Compatible with LEADTOOLS Win32)";
         // 
         // _rbTagLEAD
         // 
         this._rbTagLEAD.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbTagLEAD.Location = new System.Drawing.Point(24, 56);
         this._rbTagLEAD.Name = "_rbTagLEAD";
         this._rbTagLEAD.Size = new System.Drawing.Size(368, 24);
         this._rbTagLEAD.TabIndex = 1;
         this._rbTagLEAD.Text = "LEAD tag (Compatible with LEADTOOLS Win32 annotations)";
         // 
         // _rbTagSerialize
         // 
         this._rbTagSerialize.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbTagSerialize.Location = new System.Drawing.Point(24, 24);
         this._rbTagSerialize.Name = "_rbTagSerialize";
         this._rbTagSerialize.Size = new System.Drawing.Size(368, 24);
         this._rbTagSerialize.TabIndex = 0;
         this._rbTagSerialize.Text = "Serialize tag (Not compatible with LEADTOOLS Win32 annotations)";
         // 
         // _rbNoTiffTags
         // 
         this._rbNoTiffTags.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbNoTiffTags.Location = new System.Drawing.Point(24, 224);
         this._rbNoTiffTags.Name = "_rbNoTiffTags";
         this._rbNoTiffTags.Size = new System.Drawing.Size(392, 24);
         this._rbNoTiffTags.TabIndex = 1;
         this._rbNoTiffTags.Text = "Do not save as a TIFF tag (Use the same format as in non TIFF files)";
         this._rbNoTiffTags.CheckedChanged += new System.EventHandler(this._rbNoTiffTags_CheckedChanged);
         // 
         // _rbTiffTags
         // 
         this._rbTiffTags.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._rbTiffTags.Location = new System.Drawing.Point(24, 32);
         this._rbTiffTags.Name = "_rbTiffTags";
         this._rbTiffTags.Size = new System.Drawing.Size(392, 24);
         this._rbTiffTags.TabIndex = 0;
         this._rbTiffTags.Text = "Save as a TIFF tag (Objects are embedded in the TIFF file)";
         this._rbTiffTags.CheckedChanged += new System.EventHandler(this._rbTiffTags_CheckedChanged);
         // 
         // AnnotationsSaveFormatDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(570, 408);
         this.Controls.Add(this._gbTiff);
         this.Controls.Add(this._gbNonTiff);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AnnotationsSaveFormatDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Annotations Save Format";
         this.Load += new System.EventHandler(this.AnnotationsSaveFormatDialog_Load);
         this._gbNonTiff.ResumeLayout(false);
         this._gbTiff.ResumeLayout(false);
         this._gbTag.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion

      public AnnCodecsFormat SaveFormat;
      public bool TiffTags;
      public AnnCodecsTagFormat TagFormat;

      private void AnnotationsSaveFormatDialog_Load(object sender, System.EventArgs e)
      {
         _rbSerialize.Checked = SaveFormat == AnnCodecsFormat.Serialize;
         _rbXml.Checked = SaveFormat == AnnCodecsFormat.Xml;

         _rbTiffTags.Checked = TiffTags;
         _rbNoTiffTags.Checked = !TiffTags;

         _rbTagSerialize.Checked = TagFormat == AnnCodecsTagFormat.Serialize;
         _rbTagLEAD.Checked = TagFormat == AnnCodecsTagFormat.Tiff;
         _rbTagWang.Checked = TagFormat == AnnCodecsTagFormat.Wang;

         UpdateControls();
      }

      private void _rbTiffTags_CheckedChanged(object sender, System.EventArgs e)
      {
         UpdateControls();
      }

      private void _rbNoTiffTags_CheckedChanged(object sender, System.EventArgs e)
      {
         UpdateControls();
      }

      private void UpdateControls()
      {
         _gbTag.Enabled = _rbTiffTags.Checked;
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         if(_rbSerialize.Checked)
            SaveFormat = AnnCodecsFormat.Serialize;
         else if(_rbXml.Checked)
            SaveFormat = AnnCodecsFormat.Xml;

         TiffTags = _rbTiffTags.Checked;

         if(_rbTagSerialize.Checked)
            TagFormat = AnnCodecsTagFormat.Serialize;
         else if(_rbTagLEAD.Checked)
            TagFormat = AnnCodecsTagFormat.Tiff;
         else if(_rbTagWang.Checked)
            TagFormat = AnnCodecsTagFormat.Wang;
      }
   }
}
