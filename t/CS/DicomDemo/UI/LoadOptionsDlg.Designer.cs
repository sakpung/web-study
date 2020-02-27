namespace DicomDemo.UI
{
   partial class LoadOptionsDlg
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
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
         this.buttonOK = new System.Windows.Forms.Button();
         this.groupBoxGetImageFlags = new System.Windows.Forms.GroupBox();
         this.checkBoxLoadCorrupted = new System.Windows.Forms.CheckBox();
         this.checkBoxKeepColorPalette = new System.Windows.Forms.CheckBox();
         this.checkBoxAutoDetectInvalidRleCompression = new System.Windows.Forms.CheckBox();
         this.labelSeparator = new System.Windows.Forms.Label();
         this.checkBoxAutoScaleVoiLut = new System.Windows.Forms.CheckBox();
         this.checkBoxAutoApplyVoiLut = new System.Windows.Forms.CheckBox();
         this.checkBoxAutoScaleModalityLut = new System.Windows.Forms.CheckBox();
         this.checkBoxAutoApplyModalityLut = new System.Windows.Forms.CheckBox();
         this.buttonRestoreDefaults = new System.Windows.Forms.Button();
         this.checkBoxRleSwapSegments = new System.Windows.Forms.CheckBox();
         this.checkBoxAutoLoadOverlays = new System.Windows.Forms.CheckBox();
         this.groupBoxGetImageFlags.SuspendLayout();
         this.SuspendLayout();
         // 
         // buttonOK
         // 
         this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(341, 195);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 2;
         this.buttonOK.Text = "&OK";
         this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
         // 
         // groupBoxGetImageFlags
         // 
         this.groupBoxGetImageFlags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxGetImageFlags.Controls.Add(this.checkBoxAutoLoadOverlays);
         this.groupBoxGetImageFlags.Controls.Add(this.checkBoxRleSwapSegments);
         this.groupBoxGetImageFlags.Controls.Add(this.checkBoxLoadCorrupted);
         this.groupBoxGetImageFlags.Controls.Add(this.checkBoxKeepColorPalette);
         this.groupBoxGetImageFlags.Controls.Add(this.checkBoxAutoDetectInvalidRleCompression);
         this.groupBoxGetImageFlags.Controls.Add(this.labelSeparator);
         this.groupBoxGetImageFlags.Controls.Add(this.checkBoxAutoScaleVoiLut);
         this.groupBoxGetImageFlags.Controls.Add(this.checkBoxAutoApplyVoiLut);
         this.groupBoxGetImageFlags.Controls.Add(this.checkBoxAutoScaleModalityLut);
         this.groupBoxGetImageFlags.Controls.Add(this.checkBoxAutoApplyModalityLut);
         this.groupBoxGetImageFlags.Location = new System.Drawing.Point(12, 8);
         this.groupBoxGetImageFlags.Name = "groupBoxGetImageFlags";
         this.groupBoxGetImageFlags.Size = new System.Drawing.Size(404, 161);
         this.groupBoxGetImageFlags.TabIndex = 0;
         this.groupBoxGetImageFlags.TabStop = false;
         this.groupBoxGetImageFlags.Text = "GetImage Flags";
         // 
         // checkBoxLoadCorrupted
         // 
         this.checkBoxLoadCorrupted.AutoSize = true;
         this.checkBoxLoadCorrupted.Location = new System.Drawing.Point(11, 137);
         this.checkBoxLoadCorrupted.Name = "checkBoxLoadCorrupted";
         this.checkBoxLoadCorrupted.Size = new System.Drawing.Size(99, 17);
         this.checkBoxLoadCorrupted.TabIndex = 7;
         this.checkBoxLoadCorrupted.Text = "Load Corrupted";
         this.checkBoxLoadCorrupted.UseVisualStyleBackColor = true;
         this.checkBoxLoadCorrupted.CheckedChanged += new System.EventHandler(this.checkBoxLoadCorrupted_CheckedChanged);
         // 
         // checkBoxKeepColorPalette
         // 
         this.checkBoxKeepColorPalette.AutoSize = true;
         this.checkBoxKeepColorPalette.Location = new System.Drawing.Point(11, 112);
         this.checkBoxKeepColorPalette.Name = "checkBoxKeepColorPalette";
         this.checkBoxKeepColorPalette.Size = new System.Drawing.Size(114, 17);
         this.checkBoxKeepColorPalette.TabIndex = 6;
         this.checkBoxKeepColorPalette.Text = "Keep Color Palette";
         this.checkBoxKeepColorPalette.UseVisualStyleBackColor = true;
         this.checkBoxKeepColorPalette.CheckedChanged += new System.EventHandler(this.checkBoxKeepColorPalette_CheckedChanged);
         // 
         // checkBoxAutoDetectInvalidRleCompression
         // 
         this.checkBoxAutoDetectInvalidRleCompression.AutoSize = true;
         this.checkBoxAutoDetectInvalidRleCompression.Location = new System.Drawing.Point(11, 88);
         this.checkBoxAutoDetectInvalidRleCompression.Name = "checkBoxAutoDetectInvalidRleCompression";
         this.checkBoxAutoDetectInvalidRleCompression.Size = new System.Drawing.Size(204, 17);
         this.checkBoxAutoDetectInvalidRleCompression.TabIndex = 5;
         this.checkBoxAutoDetectInvalidRleCompression.Text = "Auto-Detect Invalid RLE Compression";
         this.checkBoxAutoDetectInvalidRleCompression.UseVisualStyleBackColor = true;
         this.checkBoxAutoDetectInvalidRleCompression.CheckedChanged += new System.EventHandler(this.checkBoxAutoDetectInvalidRleCompression_CheckedChanged);
         // 
         // labelSeparator
         // 
         this.labelSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.labelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.labelSeparator.Location = new System.Drawing.Point(2, 74);
         this.labelSeparator.Name = "labelSeparator";
         this.labelSeparator.Size = new System.Drawing.Size(402, 2);
         this.labelSeparator.TabIndex = 4;
         // 
         // checkBoxAutoScaleVoiLut
         // 
         this.checkBoxAutoScaleVoiLut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.checkBoxAutoScaleVoiLut.AutoSize = true;
         this.checkBoxAutoScaleVoiLut.Location = new System.Drawing.Point(229, 48);
         this.checkBoxAutoScaleVoiLut.Name = "checkBoxAutoScaleVoiLut";
         this.checkBoxAutoScaleVoiLut.Size = new System.Drawing.Size(123, 17);
         this.checkBoxAutoScaleVoiLut.TabIndex = 3;
         this.checkBoxAutoScaleVoiLut.Text = "Auto-Scale VOI LUT";
         this.checkBoxAutoScaleVoiLut.UseVisualStyleBackColor = true;
         this.checkBoxAutoScaleVoiLut.CheckedChanged += new System.EventHandler(this.checkBoxAutoScaleVoiLut_CheckedChanged);
         // 
         // checkBoxAutoApplyVoiLut
         // 
         this.checkBoxAutoApplyVoiLut.AutoSize = true;
         this.checkBoxAutoApplyVoiLut.Location = new System.Drawing.Point(11, 48);
         this.checkBoxAutoApplyVoiLut.Name = "checkBoxAutoApplyVoiLut";
         this.checkBoxAutoApplyVoiLut.Size = new System.Drawing.Size(122, 17);
         this.checkBoxAutoApplyVoiLut.TabIndex = 1;
         this.checkBoxAutoApplyVoiLut.Text = "Auto-Apply VOI LUT";
         this.checkBoxAutoApplyVoiLut.UseVisualStyleBackColor = true;
         this.checkBoxAutoApplyVoiLut.CheckedChanged += new System.EventHandler(this.checkBoxAutoApplyVoiLut_CheckedChanged);
         // 
         // checkBoxAutoScaleModalityLut
         // 
         this.checkBoxAutoScaleModalityLut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.checkBoxAutoScaleModalityLut.AutoSize = true;
         this.checkBoxAutoScaleModalityLut.Location = new System.Drawing.Point(229, 23);
         this.checkBoxAutoScaleModalityLut.Name = "checkBoxAutoScaleModalityLut";
         this.checkBoxAutoScaleModalityLut.Size = new System.Drawing.Size(144, 17);
         this.checkBoxAutoScaleModalityLut.TabIndex = 2;
         this.checkBoxAutoScaleModalityLut.Text = "Auto-Scale Modality LUT";
         this.checkBoxAutoScaleModalityLut.UseVisualStyleBackColor = true;
         this.checkBoxAutoScaleModalityLut.CheckedChanged += new System.EventHandler(this.checkBoxAutoScaleModalityLut_CheckedChanged);
         // 
         // checkBoxAutoApplyModalityLut
         // 
         this.checkBoxAutoApplyModalityLut.AutoSize = true;
         this.checkBoxAutoApplyModalityLut.Location = new System.Drawing.Point(11, 23);
         this.checkBoxAutoApplyModalityLut.Name = "checkBoxAutoApplyModalityLut";
         this.checkBoxAutoApplyModalityLut.Size = new System.Drawing.Size(143, 17);
         this.checkBoxAutoApplyModalityLut.TabIndex = 0;
         this.checkBoxAutoApplyModalityLut.Text = "Auto-Apply Modality LUT";
         this.checkBoxAutoApplyModalityLut.UseVisualStyleBackColor = true;
         this.checkBoxAutoApplyModalityLut.CheckedChanged += new System.EventHandler(this.checkBoxAutoApplyModalityLut_CheckedChanged);
         // 
         // buttonRestoreDefaults
         // 
         this.buttonRestoreDefaults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonRestoreDefaults.Location = new System.Drawing.Point(12, 195);
         this.buttonRestoreDefaults.Name = "buttonRestoreDefaults";
         this.buttonRestoreDefaults.Size = new System.Drawing.Size(97, 23);
         this.buttonRestoreDefaults.TabIndex = 1;
         this.buttonRestoreDefaults.Text = "Restore Defaults";
         this.buttonRestoreDefaults.UseVisualStyleBackColor = true;
         this.buttonRestoreDefaults.Click += new System.EventHandler(this.buttonRestoreDefaults_Click);
         // 
         // checkBoxRleSwapSegments
         // 
         this.checkBoxRleSwapSegments.AutoSize = true;
         this.checkBoxRleSwapSegments.Location = new System.Drawing.Point(229, 88);
         this.checkBoxRleSwapSegments.Name = "checkBoxRleSwapSegments";
         this.checkBoxRleSwapSegments.Size = new System.Drawing.Size(163, 17);
         this.checkBoxRleSwapSegments.TabIndex = 8;
         this.checkBoxRleSwapSegments.Text = "Always Swap RLE Segments";
         this.checkBoxRleSwapSegments.UseVisualStyleBackColor = true;
         this.checkBoxRleSwapSegments.CheckedChanged += new System.EventHandler(this.checkBoxRleSwapSegments_CheckedChanged);
         // 
         // checkBoxAutoLoadOverlays
         // 
         this.checkBoxAutoLoadOverlays.AutoSize = true;
         this.checkBoxAutoLoadOverlays.Location = new System.Drawing.Point(229, 112);
         this.checkBoxAutoLoadOverlays.Name = "checkBoxAutoLoadOverlays";
         this.checkBoxAutoLoadOverlays.Size = new System.Drawing.Size(119, 17);
         this.checkBoxAutoLoadOverlays.TabIndex = 9;
         this.checkBoxAutoLoadOverlays.Text = "Auto Load Overlays";
         this.checkBoxAutoLoadOverlays.UseVisualStyleBackColor = true;
         this.checkBoxAutoLoadOverlays.CheckedChanged += new System.EventHandler(this.checkBoxAutoLoadOverlays_CheckedChanged);
         // 
         // LoadOptionsDlg
         // 
         this.AcceptButton = this.buttonOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.buttonOK;
         this.ClientSize = new System.Drawing.Size(428, 227);
         this.Controls.Add(this.buttonRestoreDefaults);
         this.Controls.Add(this.groupBoxGetImageFlags);
         this.Controls.Add(this.buttonOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "LoadOptionsDlg";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Load Options";
         this.Load += new System.EventHandler(this.LoadOptionsDlg_Load);
         this.groupBoxGetImageFlags.ResumeLayout(false);
         this.groupBoxGetImageFlags.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.GroupBox groupBoxGetImageFlags;
      private System.Windows.Forms.CheckBox checkBoxKeepColorPalette;
      private System.Windows.Forms.CheckBox checkBoxAutoDetectInvalidRleCompression;
      private System.Windows.Forms.Label labelSeparator;
      private System.Windows.Forms.CheckBox checkBoxAutoScaleVoiLut;
      private System.Windows.Forms.CheckBox checkBoxAutoApplyVoiLut;
      private System.Windows.Forms.CheckBox checkBoxAutoScaleModalityLut;
      private System.Windows.Forms.CheckBox checkBoxAutoApplyModalityLut;
      private System.Windows.Forms.Button buttonRestoreDefaults;
      private System.Windows.Forms.CheckBox checkBoxLoadCorrupted;
      private System.Windows.Forms.CheckBox checkBoxAutoLoadOverlays;
      private System.Windows.Forms.CheckBox checkBoxRleSwapSegments;
   }
}