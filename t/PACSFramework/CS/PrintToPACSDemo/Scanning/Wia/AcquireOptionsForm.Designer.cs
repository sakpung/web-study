namespace PrintToPACSDemo
{
   partial class AcquireOptionsForm
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
         this._gbTransferMode = new System.Windows.Forms.GroupBox();
         this._rdMemoryMode = new System.Windows.Forms.RadioButton();
         this._rdFileMode = new System.Windows.Forms.RadioButton();
         this._gbFileModeOptions = new System.Windows.Forms.GroupBox();
         this._cbAppendToFile = new System.Windows.Forms.CheckBox();
         this._cbOverwriteExisting = new System.Windows.Forms.CheckBox();
         this._cbSaveToOneFile = new System.Windows.Forms.CheckBox();
         this._btnBrowse = new System.Windows.Forms.Button();
         this._tbFileName = new System.Windows.Forms.TextBox();
         this._lblFileName = new System.Windows.Forms.Label();
         this._gbTransferBufferOptions = new System.Windows.Forms.GroupBox();
         this._numMemoryBufferSize = new System.Windows.Forms.NumericUpDown();
         this._cbEnableDoubleBuffer = new System.Windows.Forms.CheckBox();
         this._lblMemoryBufferSize = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbTransferMode.SuspendLayout();
         this._gbFileModeOptions.SuspendLayout();
         this._gbTransferBufferOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numMemoryBufferSize)).BeginInit();
         this.SuspendLayout();
         // 
         // _gbTransferMode
         // 
         this._gbTransferMode.Controls.Add(this._rdMemoryMode);
         this._gbTransferMode.Controls.Add(this._rdFileMode);
         this._gbTransferMode.Location = new System.Drawing.Point(12, 12);
         this._gbTransferMode.Name = "_gbTransferMode";
         this._gbTransferMode.Size = new System.Drawing.Size(252, 89);
         this._gbTransferMode.TabIndex = 0;
         this._gbTransferMode.TabStop = false;
         this._gbTransferMode.Text = "Transfer Mode";
         // 
         // _rdMemoryMode
         // 
         this._rdMemoryMode.AutoSize = true;
         this._rdMemoryMode.Location = new System.Drawing.Point(9, 38);
         this._rdMemoryMode.Name = "_rdMemoryMode";
         this._rdMemoryMode.Size = new System.Drawing.Size(92, 17);
         this._rdMemoryMode.TabIndex = 0;
         this._rdMemoryMode.TabStop = true;
         this._rdMemoryMode.Text = "Memory Mode";
         this._rdMemoryMode.UseVisualStyleBackColor = true;
         this._rdMemoryMode.Click += new System.EventHandler(this._rdMemoryMode_Click);
         // 
         // _rdFileMode
         // 
         this._rdFileMode.AutoSize = true;
         this._rdFileMode.Location = new System.Drawing.Point(139, 38);
         this._rdFileMode.Name = "_rdFileMode";
         this._rdFileMode.Size = new System.Drawing.Size(71, 17);
         this._rdFileMode.TabIndex = 1;
         this._rdFileMode.TabStop = true;
         this._rdFileMode.Text = "File Mode";
         this._rdFileMode.UseVisualStyleBackColor = true;
         this._rdFileMode.Click += new System.EventHandler(this._rdFileMode_Click);
         // 
         // _gbFileModeOptions
         // 
         this._gbFileModeOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)));
         this._gbFileModeOptions.Controls.Add(this._cbAppendToFile);
         this._gbFileModeOptions.Controls.Add(this._cbOverwriteExisting);
         this._gbFileModeOptions.Controls.Add(this._cbSaveToOneFile);
         this._gbFileModeOptions.Controls.Add(this._btnBrowse);
         this._gbFileModeOptions.Controls.Add(this._tbFileName);
         this._gbFileModeOptions.Controls.Add(this._lblFileName);
         this._gbFileModeOptions.Location = new System.Drawing.Point(12, 107);
         this._gbFileModeOptions.Name = "_gbFileModeOptions";
         this._gbFileModeOptions.Size = new System.Drawing.Size(252, 151);
         this._gbFileModeOptions.TabIndex = 1;
         this._gbFileModeOptions.TabStop = false;
         this._gbFileModeOptions.Text = "File Mode Options";
         // 
         // _cbAppendToFile
         // 
         this._cbAppendToFile.AutoSize = true;
         this._cbAppendToFile.Location = new System.Drawing.Point(9, 108);
         this._cbAppendToFile.Name = "_cbAppendToFile";
         this._cbAppendToFile.Size = new System.Drawing.Size(98, 17);
         this._cbAppendToFile.TabIndex = 6;
         this._cbAppendToFile.Text = "Append To File";
         this._cbAppendToFile.UseVisualStyleBackColor = true;
         this._cbAppendToFile.Click += new System.EventHandler(this._cbAppendToFile_Click);
         // 
         // _cbOverwriteExisting
         // 
         this._cbOverwriteExisting.AutoSize = true;
         this._cbOverwriteExisting.Location = new System.Drawing.Point(9, 85);
         this._cbOverwriteExisting.Name = "_cbOverwriteExisting";
         this._cbOverwriteExisting.Size = new System.Drawing.Size(110, 17);
         this._cbOverwriteExisting.TabIndex = 5;
         this._cbOverwriteExisting.Text = "Overwrite Existing";
         this._cbOverwriteExisting.UseVisualStyleBackColor = true;
         this._cbOverwriteExisting.Click += new System.EventHandler(this._cbOverwriteExisting_Click);
         // 
         // _cbSaveToOneFile
         // 
         this._cbSaveToOneFile.AutoSize = true;
         this._cbSaveToOneFile.Location = new System.Drawing.Point(9, 62);
         this._cbSaveToOneFile.Name = "_cbSaveToOneFile";
         this._cbSaveToOneFile.Size = new System.Drawing.Size(109, 17);
         this._cbSaveToOneFile.TabIndex = 4;
         this._cbSaveToOneFile.Text = "Save To One File";
         this._cbSaveToOneFile.UseVisualStyleBackColor = true;
         // 
         // _btnBrowse
         // 
         this._btnBrowse.Location = new System.Drawing.Point(217, 23);
         this._btnBrowse.Name = "_btnBrowse";
         this._btnBrowse.Size = new System.Drawing.Size(29, 23);
         this._btnBrowse.TabIndex = 3;
         this._btnBrowse.Text = "&...";
         this._btnBrowse.UseVisualStyleBackColor = true;
         this._btnBrowse.Click += new System.EventHandler(this._btnBrowse_Click);
         // 
         // _tbFileName
         // 
         this._tbFileName.Location = new System.Drawing.Point(66, 25);
         this._tbFileName.Name = "_tbFileName";
         this._tbFileName.ReadOnly = true;
         this._tbFileName.Size = new System.Drawing.Size(144, 20);
         this._tbFileName.TabIndex = 2;
         this._tbFileName.TextChanged += new System.EventHandler(this._tbFileName_TextChanged);
         // 
         // _lblFileName
         // 
         this._lblFileName.AutoSize = true;
         this._lblFileName.Location = new System.Drawing.Point(6, 28);
         this._lblFileName.Name = "_lblFileName";
         this._lblFileName.Size = new System.Drawing.Size(54, 13);
         this._lblFileName.TabIndex = 0;
         this._lblFileName.Text = "File Name";
         // 
         // _gbTransferBufferOptions
         // 
         this._gbTransferBufferOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._gbTransferBufferOptions.Controls.Add(this._numMemoryBufferSize);
         this._gbTransferBufferOptions.Controls.Add(this._cbEnableDoubleBuffer);
         this._gbTransferBufferOptions.Controls.Add(this._lblMemoryBufferSize);
         this._gbTransferBufferOptions.Location = new System.Drawing.Point(270, 12);
         this._gbTransferBufferOptions.Name = "_gbTransferBufferOptions";
         this._gbTransferBufferOptions.Size = new System.Drawing.Size(229, 89);
         this._gbTransferBufferOptions.TabIndex = 1;
         this._gbTransferBufferOptions.TabStop = false;
         this._gbTransferBufferOptions.Text = "Transfer Buffer Options";
         // 
         // _numMemoryBufferSize
         // 
         this._numMemoryBufferSize.Location = new System.Drawing.Point(145, 24);
         this._numMemoryBufferSize.Maximum = new decimal(new int[] {
            65535000,
            0,
            0,
            0});
         this._numMemoryBufferSize.Name = "_numMemoryBufferSize";
         this._numMemoryBufferSize.Size = new System.Drawing.Size(78, 20);
         this._numMemoryBufferSize.TabIndex = 9;
         this._numMemoryBufferSize.Leave += new System.EventHandler(this._numMemoryBufferSize_Leave);
         // 
         // _cbEnableDoubleBuffer
         // 
         this._cbEnableDoubleBuffer.AutoSize = true;
         this._cbEnableDoubleBuffer.Location = new System.Drawing.Point(9, 55);
         this._cbEnableDoubleBuffer.Name = "_cbEnableDoubleBuffer";
         this._cbEnableDoubleBuffer.Size = new System.Drawing.Size(127, 17);
         this._cbEnableDoubleBuffer.TabIndex = 8;
         this._cbEnableDoubleBuffer.Text = "Enable Double Buffer";
         this._cbEnableDoubleBuffer.UseVisualStyleBackColor = true;
         // 
         // _lblMemoryBufferSize
         // 
         this._lblMemoryBufferSize.AutoSize = true;
         this._lblMemoryBufferSize.Location = new System.Drawing.Point(6, 26);
         this._lblMemoryBufferSize.Name = "_lblMemoryBufferSize";
         this._lblMemoryBufferSize.Size = new System.Drawing.Size(133, 13);
         this._lblMemoryBufferSize.TabIndex = 0;
         this._lblMemoryBufferSize.Text = "Memory Buffer Size (Bytes)";
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(421, 234);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(80, 24);
         this._btnCancel.TabIndex = 10;
         this._btnCancel.Text = "&Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOk
         // 
         this._btnOk.Location = new System.Drawing.Point(335, 234);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(80, 24);
         this._btnOk.TabIndex = 9;
         this._btnOk.Text = "&OK";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // AcquireOptionsForm
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(511, 270);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._gbTransferBufferOptions);
         this.Controls.Add(this._gbFileModeOptions);
         this.Controls.Add(this._gbTransferMode);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AcquireOptionsForm";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "WIA Acquire Options";
         this.Load += new System.EventHandler(this.AcquireOptionsForm_Load);
         this._gbTransferMode.ResumeLayout(false);
         this._gbTransferMode.PerformLayout();
         this._gbFileModeOptions.ResumeLayout(false);
         this._gbFileModeOptions.PerformLayout();
         this._gbTransferBufferOptions.ResumeLayout(false);
         this._gbTransferBufferOptions.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numMemoryBufferSize)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbTransferMode;
      private System.Windows.Forms.GroupBox _gbFileModeOptions;
      private System.Windows.Forms.GroupBox _gbTransferBufferOptions;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.RadioButton _rdMemoryMode;
      private System.Windows.Forms.RadioButton _rdFileMode;
      private System.Windows.Forms.Label _lblFileName;
      private System.Windows.Forms.Button _btnBrowse;
      private System.Windows.Forms.TextBox _tbFileName;
      private System.Windows.Forms.CheckBox _cbAppendToFile;
      private System.Windows.Forms.CheckBox _cbOverwriteExisting;
      private System.Windows.Forms.CheckBox _cbSaveToOneFile;
      private System.Windows.Forms.Label _lblMemoryBufferSize;
      private System.Windows.Forms.CheckBox _cbEnableDoubleBuffer;
      private System.Windows.Forms.NumericUpDown _numMemoryBufferSize;
   }
}