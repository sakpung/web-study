namespace ConversionServiceConfigDemo
{
   partial class MainForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this._lblJPEGInputDirectory = new System.Windows.Forms.Label();
         this._txtJPEGInputPath = new System.Windows.Forms.TextBox();
         this._txtPDFInputPath = new System.Windows.Forms.TextBox();
         this._lblPDFInputPath = new System.Windows.Forms.Label();
         this._btnBrowseJPEGInputPath = new System.Windows.Forms.Button();
         this._btnBrowsePDFInputPath = new System.Windows.Forms.Button();
         this._gbFilePaths = new System.Windows.Forms.GroupBox();
         this._txtOutputPath = new System.Windows.Forms.TextBox();
         this._btnBrowseOutputPath = new System.Windows.Forms.Button();
         this._lblOutputPath = new System.Windows.Forms.Label();
         this._nudConversionFrequency = new System.Windows.Forms.NumericUpDown();
         this._lblConversionFrequency = new System.Windows.Forms.Label();
         this._btnApply = new System.Windows.Forms.Button();
         this._chkDeleteSource = new System.Windows.Forms.CheckBox();
         this._lblMoveSourceTo = new System.Windows.Forms.Label();
         this._btnBrowseMoveSourceTo = new System.Windows.Forms.Button();
         this._txtMoveSourceTo = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this._gbSourceFile = new System.Windows.Forms.GroupBox();
         this.label1 = new System.Windows.Forms.Label();
         this._lblConversionStatus = new System.Windows.Forms.Label();
         this._btnInstallService = new System.Windows.Forms.Button();
         this._gbConversionService = new System.Windows.Forms.GroupBox();
         this._btnUninstallService = new System.Windows.Forms.Button();
         this._gbPlatform = new System.Windows.Forms.GroupBox();
         this._rbInstall32Bit = new System.Windows.Forms.RadioButton();
         this._rbInstall64Bit = new System.Windows.Forms.RadioButton();
         this._gbFilePaths.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._nudConversionFrequency)).BeginInit();
         this._gbSourceFile.SuspendLayout();
         this._gbConversionService.SuspendLayout();
         this._gbPlatform.SuspendLayout();
         this.SuspendLayout();
         // 
         // _lblJPEGInputDirectory
         // 
         this._lblJPEGInputDirectory.AutoSize = true;
         this._lblJPEGInputDirectory.Location = new System.Drawing.Point(20, 31);
         this._lblJPEGInputDirectory.Name = "_lblJPEGInputDirectory";
         this._lblJPEGInputDirectory.Size = new System.Drawing.Size(361, 13);
         this._lblJPEGInputDirectory.TabIndex = 0;
         this._lblJPEGInputDirectory.Text = "JPEG Input Path (images placed in this directory will be converted to JPEG)";
         // 
         // _txtJPEGInputPath
         // 
         this._txtJPEGInputPath.Location = new System.Drawing.Point(23, 64);
         this._txtJPEGInputPath.Name = "_txtJPEGInputPath";
         this._txtJPEGInputPath.Size = new System.Drawing.Size(221, 20);
         this._txtJPEGInputPath.TabIndex = 1;
         // 
         // _txtPDFInputPath
         // 
         this._txtPDFInputPath.Location = new System.Drawing.Point(23, 135);
         this._txtPDFInputPath.Name = "_txtPDFInputPath";
         this._txtPDFInputPath.Size = new System.Drawing.Size(221, 20);
         this._txtPDFInputPath.TabIndex = 3;
         // 
         // _lblPDFInputPath
         // 
         this._lblPDFInputPath.AutoSize = true;
         this._lblPDFInputPath.Location = new System.Drawing.Point(20, 102);
         this._lblPDFInputPath.Name = "_lblPDFInputPath";
         this._lblPDFInputPath.Size = new System.Drawing.Size(349, 13);
         this._lblPDFInputPath.TabIndex = 2;
         this._lblPDFInputPath.Text = "PDF Input Path (images placed in this directory will be converted to PDF)";
         // 
         // _btnBrowseJPEGInputPath
         // 
         this._btnBrowseJPEGInputPath.Location = new System.Drawing.Point(269, 64);
         this._btnBrowseJPEGInputPath.Name = "_btnBrowseJPEGInputPath";
         this._btnBrowseJPEGInputPath.Size = new System.Drawing.Size(32, 20);
         this._btnBrowseJPEGInputPath.TabIndex = 4;
         this._btnBrowseJPEGInputPath.Text = "...";
         this._btnBrowseJPEGInputPath.UseVisualStyleBackColor = true;
         this._btnBrowseJPEGInputPath.Click += new System.EventHandler(this._btnBrowseJPEGInputPath_Click);
         // 
         // _btnBrowsePDFInputPath
         // 
         this._btnBrowsePDFInputPath.Location = new System.Drawing.Point(269, 135);
         this._btnBrowsePDFInputPath.Name = "_btnBrowsePDFInputPath";
         this._btnBrowsePDFInputPath.Size = new System.Drawing.Size(32, 20);
         this._btnBrowsePDFInputPath.TabIndex = 5;
         this._btnBrowsePDFInputPath.Text = "...";
         this._btnBrowsePDFInputPath.UseVisualStyleBackColor = true;
         this._btnBrowsePDFInputPath.Click += new System.EventHandler(this._btnBrowsePDFInputPath_Click);
         // 
         // _gbFilePaths
         // 
         this._gbFilePaths.Controls.Add(this._txtOutputPath);
         this._gbFilePaths.Controls.Add(this._btnBrowseOutputPath);
         this._gbFilePaths.Controls.Add(this._lblOutputPath);
         this._gbFilePaths.Controls.Add(this._txtPDFInputPath);
         this._gbFilePaths.Controls.Add(this._btnBrowsePDFInputPath);
         this._gbFilePaths.Controls.Add(this._lblJPEGInputDirectory);
         this._gbFilePaths.Controls.Add(this._btnBrowseJPEGInputPath);
         this._gbFilePaths.Controls.Add(this._txtJPEGInputPath);
         this._gbFilePaths.Controls.Add(this._lblPDFInputPath);
         this._gbFilePaths.Location = new System.Drawing.Point(15, 65);
         this._gbFilePaths.Name = "_gbFilePaths";
         this._gbFilePaths.Size = new System.Drawing.Size(393, 248);
         this._gbFilePaths.TabIndex = 6;
         this._gbFilePaths.TabStop = false;
         this._gbFilePaths.Text = "File Paths";
         // 
         // _txtOutputPath
         // 
         this._txtOutputPath.Location = new System.Drawing.Point(23, 208);
         this._txtOutputPath.Name = "_txtOutputPath";
         this._txtOutputPath.Size = new System.Drawing.Size(221, 20);
         this._txtOutputPath.TabIndex = 7;
         // 
         // _btnBrowseOutputPath
         // 
         this._btnBrowseOutputPath.Location = new System.Drawing.Point(269, 208);
         this._btnBrowseOutputPath.Name = "_btnBrowseOutputPath";
         this._btnBrowseOutputPath.Size = new System.Drawing.Size(32, 20);
         this._btnBrowseOutputPath.TabIndex = 8;
         this._btnBrowseOutputPath.Text = "...";
         this._btnBrowseOutputPath.UseVisualStyleBackColor = true;
         this._btnBrowseOutputPath.Click += new System.EventHandler(this._btnBrowseOutputPath_Click);
         // 
         // _lblOutputPath
         // 
         this._lblOutputPath.AutoSize = true;
         this._lblOutputPath.Location = new System.Drawing.Point(20, 175);
         this._lblOutputPath.Name = "_lblOutputPath";
         this._lblOutputPath.Size = new System.Drawing.Size(64, 13);
         this._lblOutputPath.TabIndex = 6;
         this._lblOutputPath.Text = "Output Path";
         // 
         // _nudConversionFrequency
         // 
         this._nudConversionFrequency.Location = new System.Drawing.Point(17, 383);
         this._nudConversionFrequency.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
         this._nudConversionFrequency.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
         this._nudConversionFrequency.Name = "_nudConversionFrequency";
         this._nudConversionFrequency.Size = new System.Drawing.Size(162, 20);
         this._nudConversionFrequency.TabIndex = 7;
         this._nudConversionFrequency.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
         // 
         // _lblConversionFrequency
         // 
         this._lblConversionFrequency.AutoSize = true;
         this._lblConversionFrequency.Location = new System.Drawing.Point(17, 351);
         this._lblConversionFrequency.Name = "_lblConversionFrequency";
         this._lblConversionFrequency.Size = new System.Drawing.Size(162, 13);
         this._lblConversionFrequency.TabIndex = 8;
         this._lblConversionFrequency.Text = "Conversion Frequency (seconds)";
         // 
         // _btnApply
         // 
         this._btnApply.Location = new System.Drawing.Point(210, 371);
         this._btnApply.Name = "_btnApply";
         this._btnApply.Size = new System.Drawing.Size(128, 32);
         this._btnApply.TabIndex = 9;
         this._btnApply.Text = "Apply";
         this._btnApply.UseVisualStyleBackColor = true;
         this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
         // 
         // _chkDeleteSource
         // 
         this._chkDeleteSource.AutoSize = true;
         this._chkDeleteSource.Location = new System.Drawing.Point(28, 102);
         this._chkDeleteSource.Name = "_chkDeleteSource";
         this._chkDeleteSource.Size = new System.Drawing.Size(94, 17);
         this._chkDeleteSource.TabIndex = 10;
         this._chkDeleteSource.Text = "Delete Source";
         this._chkDeleteSource.UseVisualStyleBackColor = true;
         this._chkDeleteSource.CheckedChanged += new System.EventHandler(this._chkDeleteSource_CheckedChanged);
         // 
         // _lblMoveSourceTo
         // 
         this._lblMoveSourceTo.AutoSize = true;
         this._lblMoveSourceTo.Location = new System.Drawing.Point(25, 142);
         this._lblMoveSourceTo.Name = "_lblMoveSourceTo";
         this._lblMoveSourceTo.Size = new System.Drawing.Size(116, 13);
         this._lblMoveSourceTo.TabIndex = 11;
         this._lblMoveSourceTo.Text = "\'Move Source To\' Path";
         // 
         // _btnBrowseMoveSourceTo
         // 
         this._btnBrowseMoveSourceTo.Location = new System.Drawing.Point(275, 175);
         this._btnBrowseMoveSourceTo.Name = "_btnBrowseMoveSourceTo";
         this._btnBrowseMoveSourceTo.Size = new System.Drawing.Size(32, 20);
         this._btnBrowseMoveSourceTo.TabIndex = 13;
         this._btnBrowseMoveSourceTo.Text = "...";
         this._btnBrowseMoveSourceTo.UseVisualStyleBackColor = true;
         this._btnBrowseMoveSourceTo.Click += new System.EventHandler(this._btnBrowseMoveSourceTo_Click);
         // 
         // _txtMoveSourceTo
         // 
         this._txtMoveSourceTo.Location = new System.Drawing.Point(28, 175);
         this._txtMoveSourceTo.Name = "_txtMoveSourceTo";
         this._txtMoveSourceTo.Size = new System.Drawing.Size(221, 20);
         this._txtMoveSourceTo.TabIndex = 12;
         // 
         // label2
         // 
         this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
         this.label2.Location = new System.Drawing.Point(25, 37);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(273, 47);
         this.label2.TabIndex = 14;
         this.label2.Text = "If the \'Delete Source\' option is not selected, source files will be moved to the " +
    "\'Move Source To\' Path after converting.";
         this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _gbSourceFile
         // 
         this._gbSourceFile.Controls.Add(this.label2);
         this._gbSourceFile.Controls.Add(this._lblMoveSourceTo);
         this._gbSourceFile.Controls.Add(this._txtMoveSourceTo);
         this._gbSourceFile.Controls.Add(this._chkDeleteSource);
         this._gbSourceFile.Controls.Add(this._btnBrowseMoveSourceTo);
         this._gbSourceFile.Location = new System.Drawing.Point(444, 65);
         this._gbSourceFile.Name = "_gbSourceFile";
         this._gbSourceFile.Size = new System.Drawing.Size(324, 248);
         this._gbSourceFile.TabIndex = 15;
         this._gbSourceFile.TabStop = false;
         this._gbSourceFile.Text = "Source File";
         // 
         // label1
         // 
         this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
         this.label1.Location = new System.Drawing.Point(12, 18);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(753, 44);
         this.label1.TabIndex = 16;
         this.label1.Text = resources.GetString("label1.Text");
         // 
         // _lblConversionStatus
         // 
         this._lblConversionStatus.AutoSize = true;
         this._lblConversionStatus.Location = new System.Drawing.Point(20, 37);
         this._lblConversionStatus.Name = "_lblConversionStatus";
         this._lblConversionStatus.Size = new System.Drawing.Size(96, 13);
         this._lblConversionStatus.TabIndex = 17;
         this._lblConversionStatus.Text = "ConversionStatus: ";
         // 
         // _btnInstallService
         // 
         this._btnInstallService.Location = new System.Drawing.Point(16, 171);
         this._btnInstallService.Name = "_btnInstallService";
         this._btnInstallService.Size = new System.Drawing.Size(128, 32);
         this._btnInstallService.TabIndex = 18;
         this._btnInstallService.Text = "Install Service";
         this._btnInstallService.UseVisualStyleBackColor = true;
         this._btnInstallService.Click += new System.EventHandler(this._btnInstallService_Click);
         // 
         // _gbConversionService
         // 
         this._gbConversionService.Controls.Add(this._btnUninstallService);
         this._gbConversionService.Controls.Add(this._gbPlatform);
         this._gbConversionService.Controls.Add(this._btnInstallService);
         this._gbConversionService.Controls.Add(this._lblConversionStatus);
         this._gbConversionService.Location = new System.Drawing.Point(15, 453);
         this._gbConversionService.Name = "_gbConversionService";
         this._gbConversionService.Size = new System.Drawing.Size(393, 217);
         this._gbConversionService.TabIndex = 19;
         this._gbConversionService.TabStop = false;
         this._gbConversionService.Text = "Conversion Service";
         // 
         // _btnUninstallService
         // 
         this._btnUninstallService.Location = new System.Drawing.Point(224, 173);
         this._btnUninstallService.Name = "_btnUninstallService";
         this._btnUninstallService.Size = new System.Drawing.Size(128, 32);
         this._btnUninstallService.TabIndex = 26;
         this._btnUninstallService.Text = "Uninstall Service";
         this._btnUninstallService.UseVisualStyleBackColor = true;
         this._btnUninstallService.Click += new System.EventHandler(this._btnUninstallService_Click);
         // 
         // _gbPlatform
         // 
         this._gbPlatform.Controls.Add(this._rbInstall32Bit);
         this._gbPlatform.Controls.Add(this._rbInstall64Bit);
         this._gbPlatform.Location = new System.Drawing.Point(16, 69);
         this._gbPlatform.Name = "_gbPlatform";
         this._gbPlatform.Size = new System.Drawing.Size(163, 77);
         this._gbPlatform.TabIndex = 24;
         this._gbPlatform.TabStop = false;
         this._gbPlatform.Text = "Platform";
         // 
         // _rbInstall32Bit
         // 
         this._rbInstall32Bit.AutoSize = true;
         this._rbInstall32Bit.Checked = true;
         this._rbInstall32Bit.Location = new System.Drawing.Point(16, 27);
         this._rbInstall32Bit.Name = "_rbInstall32Bit";
         this._rbInstall32Bit.Size = new System.Drawing.Size(121, 17);
         this._rbInstall32Bit.TabIndex = 20;
         this._rbInstall32Bit.TabStop = true;
         this._rbInstall32Bit.Text = "Install 32 Bit Service";
         this._rbInstall32Bit.UseVisualStyleBackColor = true;
         // 
         // _rbInstall64Bit
         // 
         this._rbInstall64Bit.AutoSize = true;
         this._rbInstall64Bit.Location = new System.Drawing.Point(16, 50);
         this._rbInstall64Bit.Name = "_rbInstall64Bit";
         this._rbInstall64Bit.Size = new System.Drawing.Size(121, 17);
         this._rbInstall64Bit.TabIndex = 21;
         this._rbInstall64Bit.TabStop = true;
         this._rbInstall64Bit.Text = "Install 64 Bit Service";
         this._rbInstall64Bit.UseVisualStyleBackColor = true;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(783, 693);
         this.Controls.Add(this._gbConversionService);
         this.Controls.Add(this.label1);
         this.Controls.Add(this._gbSourceFile);
         this.Controls.Add(this._btnApply);
         this.Controls.Add(this._lblConversionFrequency);
         this.Controls.Add(this._nudConversionFrequency);
         this.Controls.Add(this._gbFilePaths);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "MainForm";
         this.Text = "MainForm";
         this.Load += new System.EventHandler(this.Form1_Load);
         this._gbFilePaths.ResumeLayout(false);
         this._gbFilePaths.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._nudConversionFrequency)).EndInit();
         this._gbSourceFile.ResumeLayout(false);
         this._gbSourceFile.PerformLayout();
         this._gbConversionService.ResumeLayout(false);
         this._gbConversionService.PerformLayout();
         this._gbPlatform.ResumeLayout(false);
         this._gbPlatform.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _lblJPEGInputDirectory;
      private System.Windows.Forms.TextBox _txtJPEGInputPath;
      private System.Windows.Forms.TextBox _txtPDFInputPath;
      private System.Windows.Forms.Label _lblPDFInputPath;
      private System.Windows.Forms.Button _btnBrowseJPEGInputPath;
      private System.Windows.Forms.Button _btnBrowsePDFInputPath;
      private System.Windows.Forms.GroupBox _gbFilePaths;
      private System.Windows.Forms.NumericUpDown _nudConversionFrequency;
      private System.Windows.Forms.Label _lblConversionFrequency;
      private System.Windows.Forms.Button _btnApply;
      private System.Windows.Forms.TextBox _txtOutputPath;
      private System.Windows.Forms.Button _btnBrowseOutputPath;
      private System.Windows.Forms.Label _lblOutputPath;
      private System.Windows.Forms.CheckBox _chkDeleteSource;
      private System.Windows.Forms.Label _lblMoveSourceTo;
      private System.Windows.Forms.Button _btnBrowseMoveSourceTo;
      private System.Windows.Forms.TextBox _txtMoveSourceTo;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.GroupBox _gbSourceFile;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label _lblConversionStatus;
      private System.Windows.Forms.Button _btnInstallService;
      private System.Windows.Forms.GroupBox _gbConversionService;
      private System.Windows.Forms.RadioButton _rbInstall64Bit;
      private System.Windows.Forms.RadioButton _rbInstall32Bit;
      private System.Windows.Forms.GroupBox _gbPlatform;
      private System.Windows.Forms.Button _btnUninstallService;
   }
}

