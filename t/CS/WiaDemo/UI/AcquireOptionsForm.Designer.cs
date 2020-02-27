namespace WiaDemo
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AcquireOptionsForm));
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
         resources.ApplyResources(this._gbTransferMode, "_gbTransferMode");
         this._gbTransferMode.Name = "_gbTransferMode";
         this._gbTransferMode.TabStop = false;
         // 
         // _rdMemoryMode
         // 
         resources.ApplyResources(this._rdMemoryMode, "_rdMemoryMode");
         this._rdMemoryMode.Name = "_rdMemoryMode";
         this._rdMemoryMode.TabStop = true;
         this._rdMemoryMode.UseVisualStyleBackColor = true;
         this._rdMemoryMode.Click += new System.EventHandler(this._rdMemoryMode_Click);
         // 
         // _rdFileMode
         // 
         resources.ApplyResources(this._rdFileMode, "_rdFileMode");
         this._rdFileMode.Name = "_rdFileMode";
         this._rdFileMode.TabStop = true;
         this._rdFileMode.UseVisualStyleBackColor = true;
         this._rdFileMode.Click += new System.EventHandler(this._rdFileMode_Click);
         // 
         // _gbFileModeOptions
         // 
         resources.ApplyResources(this._gbFileModeOptions, "_gbFileModeOptions");
         this._gbFileModeOptions.Controls.Add(this._cbAppendToFile);
         this._gbFileModeOptions.Controls.Add(this._cbOverwriteExisting);
         this._gbFileModeOptions.Controls.Add(this._cbSaveToOneFile);
         this._gbFileModeOptions.Controls.Add(this._btnBrowse);
         this._gbFileModeOptions.Controls.Add(this._tbFileName);
         this._gbFileModeOptions.Controls.Add(this._lblFileName);
         this._gbFileModeOptions.Name = "_gbFileModeOptions";
         this._gbFileModeOptions.TabStop = false;
         // 
         // _cbAppendToFile
         // 
         resources.ApplyResources(this._cbAppendToFile, "_cbAppendToFile");
         this._cbAppendToFile.Name = "_cbAppendToFile";
         this._cbAppendToFile.UseVisualStyleBackColor = true;
         this._cbAppendToFile.Click += new System.EventHandler(this._cbAppendToFile_Click);
         // 
         // _cbOverwriteExisting
         // 
         resources.ApplyResources(this._cbOverwriteExisting, "_cbOverwriteExisting");
         this._cbOverwriteExisting.Name = "_cbOverwriteExisting";
         this._cbOverwriteExisting.UseVisualStyleBackColor = true;
         this._cbOverwriteExisting.Click += new System.EventHandler(this._cbOverwriteExisting_Click);
         // 
         // _cbSaveToOneFile
         // 
         resources.ApplyResources(this._cbSaveToOneFile, "_cbSaveToOneFile");
         this._cbSaveToOneFile.Name = "_cbSaveToOneFile";
         this._cbSaveToOneFile.UseVisualStyleBackColor = true;
         // 
         // _btnBrowse
         // 
         resources.ApplyResources(this._btnBrowse, "_btnBrowse");
         this._btnBrowse.Name = "_btnBrowse";
         this._btnBrowse.UseVisualStyleBackColor = true;
         this._btnBrowse.Click += new System.EventHandler(this._btnBrowse_Click);
         // 
         // _tbFileName
         // 
         resources.ApplyResources(this._tbFileName, "_tbFileName");
         this._tbFileName.Name = "_tbFileName";
         this._tbFileName.ReadOnly = true;
         this._tbFileName.TextChanged += new System.EventHandler(this._tbFileName_TextChanged);
         // 
         // _lblFileName
         // 
         resources.ApplyResources(this._lblFileName, "_lblFileName");
         this._lblFileName.Name = "_lblFileName";
         // 
         // _gbTransferBufferOptions
         // 
         resources.ApplyResources(this._gbTransferBufferOptions, "_gbTransferBufferOptions");
         this._gbTransferBufferOptions.Controls.Add(this._numMemoryBufferSize);
         this._gbTransferBufferOptions.Controls.Add(this._cbEnableDoubleBuffer);
         this._gbTransferBufferOptions.Controls.Add(this._lblMemoryBufferSize);
         this._gbTransferBufferOptions.Name = "_gbTransferBufferOptions";
         this._gbTransferBufferOptions.TabStop = false;
         // 
         // _numMemoryBufferSize
         // 
         resources.ApplyResources(this._numMemoryBufferSize, "_numMemoryBufferSize");
         this._numMemoryBufferSize.Maximum = new decimal(new int[] {
            65535000,
            0,
            0,
            0});
         this._numMemoryBufferSize.Name = "_numMemoryBufferSize";
         this._numMemoryBufferSize.Leave += new System.EventHandler(this._numMemoryBufferSize_Leave);
         // 
         // _cbEnableDoubleBuffer
         // 
         resources.ApplyResources(this._cbEnableDoubleBuffer, "_cbEnableDoubleBuffer");
         this._cbEnableDoubleBuffer.Name = "_cbEnableDoubleBuffer";
         this._cbEnableDoubleBuffer.UseVisualStyleBackColor = true;
         // 
         // _lblMemoryBufferSize
         // 
         resources.ApplyResources(this._lblMemoryBufferSize, "_lblMemoryBufferSize");
         this._lblMemoryBufferSize.Name = "_lblMemoryBufferSize";
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOk
         // 
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.Name = "_btnOk";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // AcquireOptionsForm
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
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