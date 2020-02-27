namespace OcrTwainScanningDemo
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
         if(disposing && (components != null))
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
         this._msMain = new System.Windows.Forms.MenuStrip();
         this._miFile = new System.Windows.Forms.ToolStripMenuItem();
         this._miFileExit = new System.Windows.Forms.ToolStripMenuItem();
         this._miTwain = new System.Windows.Forms.ToolStripMenuItem();
         this._miTwainSelectSource = new System.Windows.Forms.ToolStripMenuItem();
         this._miOcr = new System.Windows.Forms.ToolStripMenuItem();
         this._miOcrSettings = new System.Windows.Forms.ToolStripMenuItem();
         this._miOcrComponents = new System.Windows.Forms.ToolStripMenuItem();
         this._miHelp = new System.Windows.Forms.ToolStripMenuItem();
         this._miHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
         this._gbEngines = new System.Windows.Forms.GroupBox();
         this._lblOcrEngineName = new System.Windows.Forms.Label();
         this._lblOcrEngine = new System.Windows.Forms.Label();
         this._lblTwainSourceName = new System.Windows.Forms.Label();
         this._lblTwainSource = new System.Windows.Forms.Label();
         this._lblInfo = new System.Windows.Forms.Label();
         this._gbFinalDocument = new System.Windows.Forms.GroupBox();
         this._btnFinalDocumentFileName = new System.Windows.Forms.Button();
         this._tbFinalDocumentFileName = new System.Windows.Forms.TextBox();
         this._lblFinalDocumentFormat = new System.Windows.Forms.Label();
         this._lblFinalDocumentFileName = new System.Windows.Forms.Label();
         this._btnScan = new System.Windows.Forms.Button();
         this._documentFormatSelector = new Leadtools.Demos.DocumentFormatSelector();
         this._msMain.SuspendLayout();
         this._gbEngines.SuspendLayout();
         this._gbFinalDocument.SuspendLayout();
         this.SuspendLayout();
         // 
         // _msMain
         // 
         this._msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miFile,
            this._miTwain,
            this._miOcr,
            this._miHelp});
         this._msMain.Location = new System.Drawing.Point(0, 0);
         this._msMain.Name = "_msMain";
         this._msMain.Size = new System.Drawing.Size(649, 24);
         this._msMain.TabIndex = 0;
         // 
         // _miFile
         // 
         this._miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miFileExit});
         this._miFile.Name = "_miFile";
         this._miFile.Size = new System.Drawing.Size(37, 20);
         this._miFile.Text = "&File";
         // 
         // _miFileExit
         // 
         this._miFileExit.Name = "_miFileExit";
         this._miFileExit.Size = new System.Drawing.Size(92, 22);
         this._miFileExit.Text = "E&xit";
         this._miFileExit.Click += new System.EventHandler(this._miFileExit_Click);
         // 
         // _miTwain
         // 
         this._miTwain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miTwainSelectSource});
         this._miTwain.Name = "_miTwain";
         this._miTwain.Size = new System.Drawing.Size(51, 20);
         this._miTwain.Text = "&Twain";
         // 
         // _miTwainSelectSource
         // 
         this._miTwainSelectSource.Name = "_miTwainSelectSource";
         this._miTwainSelectSource.Size = new System.Drawing.Size(153, 22);
         this._miTwainSelectSource.Text = "&Select Source...";
         this._miTwainSelectSource.Click += new System.EventHandler(this._miTwainSelectSource_Click);
         // 
         // _miOcr
         // 
         this._miOcr.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miOcrSettings,
            this._miOcrComponents});
         this._miOcr.Name = "_miOcr";
         this._miOcr.Size = new System.Drawing.Size(43, 20);
         this._miOcr.Text = "&OCR";
         // 
         // _miOcrSettings
         // 
         this._miOcrSettings.Name = "_miOcrSettings";
         this._miOcrSettings.Size = new System.Drawing.Size(152, 22);
         this._miOcrSettings.Text = "&Settings...";
         this._miOcrSettings.Click += new System.EventHandler(this._miOcrSettings_Click);
         // 
         // _miOcrComponents
         // 
         this._miOcrComponents.Name = "_miOcrComponents";
         this._miOcrComponents.Size = new System.Drawing.Size(152, 22);
         this._miOcrComponents.Text = "&Components...";
         this._miOcrComponents.Click += new System.EventHandler(this._miOcrComponents_Click);
         // 
         // _miHelp
         // 
         this._miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miHelpAbout});
         this._miHelp.Name = "_miHelp";
         this._miHelp.Size = new System.Drawing.Size(44, 20);
         this._miHelp.Text = "&Help";
         // 
         // _miHelpAbout
         // 
         this._miHelpAbout.Name = "_miHelpAbout";
         this._miHelpAbout.Size = new System.Drawing.Size(116, 22);
         this._miHelpAbout.Text = "&About...";
         this._miHelpAbout.Click += new System.EventHandler(this._miHelpAbout_Click);
         // 
         // _gbEngines
         // 
         this._gbEngines.Controls.Add(this._lblOcrEngineName);
         this._gbEngines.Controls.Add(this._lblOcrEngine);
         this._gbEngines.Controls.Add(this._lblTwainSourceName);
         this._gbEngines.Controls.Add(this._lblTwainSource);
         this._gbEngines.Location = new System.Drawing.Point(15, 153);
         this._gbEngines.Name = "_gbEngines";
         this._gbEngines.Size = new System.Drawing.Size(619, 102);
         this._gbEngines.TabIndex = 2;
         this._gbEngines.TabStop = false;
         this._gbEngines.Text = "Engines to use in scan and convert:";
         // 
         // _lblOcrEngineName
         // 
         this._lblOcrEngineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblOcrEngineName.Location = new System.Drawing.Point(102, 64);
         this._lblOcrEngineName.Name = "_lblOcrEngineName";
         this._lblOcrEngineName.Size = new System.Drawing.Size(325, 23);
         this._lblOcrEngineName.TabIndex = 3;
         this._lblOcrEngineName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblOcrEngine
         // 
         this._lblOcrEngine.Location = new System.Drawing.Point(10, 64);
         this._lblOcrEngine.Name = "_lblOcrEngine";
         this._lblOcrEngine.Size = new System.Drawing.Size(86, 23);
         this._lblOcrEngine.TabIndex = 2;
         this._lblOcrEngine.Text = "OCR engine:";
         this._lblOcrEngine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblTwainSourceName
         // 
         this._lblTwainSourceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblTwainSourceName.Location = new System.Drawing.Point(102, 31);
         this._lblTwainSourceName.Name = "_lblTwainSourceName";
         this._lblTwainSourceName.Size = new System.Drawing.Size(325, 23);
         this._lblTwainSourceName.TabIndex = 1;
         this._lblTwainSourceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblTwainSource
         // 
         this._lblTwainSource.Location = new System.Drawing.Point(10, 31);
         this._lblTwainSource.Name = "_lblTwainSource";
         this._lblTwainSource.Size = new System.Drawing.Size(86, 23);
         this._lblTwainSource.TabIndex = 0;
         this._lblTwainSource.Text = "Twain source:";
         this._lblTwainSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblInfo
         // 
         this._lblInfo.AutoSize = true;
         this._lblInfo.Location = new System.Drawing.Point(12, 39);
         this._lblInfo.Name = "_lblInfo";
         this._lblInfo.Size = new System.Drawing.Size(622, 91);
         this._lblInfo.TabIndex = 1;
         this._lblInfo.Text = resources.GetString("_lblInfo.Text");
         // 
         // _gbFinalDocument
         // 
         this._gbFinalDocument.Controls.Add(this._documentFormatSelector);
         this._gbFinalDocument.Controls.Add(this._btnFinalDocumentFileName);
         this._gbFinalDocument.Controls.Add(this._tbFinalDocumentFileName);
         this._gbFinalDocument.Controls.Add(this._lblFinalDocumentFormat);
         this._gbFinalDocument.Controls.Add(this._lblFinalDocumentFileName);
         this._gbFinalDocument.Location = new System.Drawing.Point(15, 274);
         this._gbFinalDocument.Name = "_gbFinalDocument";
         this._gbFinalDocument.Size = new System.Drawing.Size(619, 138);
         this._gbFinalDocument.TabIndex = 3;
         this._gbFinalDocument.TabStop = false;
         this._gbFinalDocument.Text = "Final document properties:";
         // 
         // _btnFinalDocumentFileName
         // 
         this._btnFinalDocumentFileName.Location = new System.Drawing.Point(433, 46);
         this._btnFinalDocumentFileName.Name = "_btnFinalDocumentFileName";
         this._btnFinalDocumentFileName.Size = new System.Drawing.Size(29, 23);
         this._btnFinalDocumentFileName.TabIndex = 2;
         this._btnFinalDocumentFileName.Text = "&...";
         this._btnFinalDocumentFileName.UseVisualStyleBackColor = true;
         this._btnFinalDocumentFileName.Click += new System.EventHandler(this._btnFinalDocumentFileName_Click);
         // 
         // _tbFinalDocumentFileName
         // 
         this._tbFinalDocumentFileName.Location = new System.Drawing.Point(13, 48);
         this._tbFinalDocumentFileName.Name = "_tbFinalDocumentFileName";
         this._tbFinalDocumentFileName.Size = new System.Drawing.Size(414, 20);
         this._tbFinalDocumentFileName.TabIndex = 1;
         this._tbFinalDocumentFileName.TextChanged += new System.EventHandler(this._tbFinalDocumentFileName_TextChanged);
         // 
         // _lblFinalDocumentFormat
         // 
         this._lblFinalDocumentFormat.AutoSize = true;
         this._lblFinalDocumentFormat.Location = new System.Drawing.Point(10, 89);
         this._lblFinalDocumentFormat.Name = "_lblFinalDocumentFormat";
         this._lblFinalDocumentFormat.Size = new System.Drawing.Size(276, 13);
         this._lblFinalDocumentFormat.TabIndex = 3;
         this._lblFinalDocumentFormat.Text = "Document format to use when saving the final document:";
         this._lblFinalDocumentFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblFinalDocumentFileName
         // 
         this._lblFinalDocumentFileName.AutoSize = true;
         this._lblFinalDocumentFileName.Location = new System.Drawing.Point(10, 31);
         this._lblFinalDocumentFileName.Name = "_lblFinalDocumentFileName";
         this._lblFinalDocumentFileName.Size = new System.Drawing.Size(157, 13);
         this._lblFinalDocumentFileName.TabIndex = 0;
         this._lblFinalDocumentFileName.Text = "&File name of the final document:";
         this._lblFinalDocumentFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _btnScan
         // 
         this._btnScan.Location = new System.Drawing.Point(15, 431);
         this._btnScan.Name = "_btnScan";
         this._btnScan.Size = new System.Drawing.Size(75, 23);
         this._btnScan.TabIndex = 4;
         this._btnScan.Text = "&Scan...";
         this._btnScan.UseVisualStyleBackColor = true;
         this._btnScan.Click += new System.EventHandler(this._btnScan_Click);
         // 
         // _documentFormatSelector
         // 
         this._documentFormatSelector.Location = new System.Drawing.Point(13, 106);
         this._documentFormatSelector.Name = "_documentFormatSelector";
         this._documentFormatSelector.Size = new System.Drawing.Size(449, 23);
         this._documentFormatSelector.TabIndex = 4;
         this._documentFormatSelector.SelectedFormatChanged += new System.EventHandler<System.EventArgs>(this._documentFormatSelector_SelectedFormatChanged);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(649, 468);
         this.Controls.Add(this._btnScan);
         this.Controls.Add(this._gbFinalDocument);
         this.Controls.Add(this._lblInfo);
         this.Controls.Add(this._gbEngines);
         this.Controls.Add(this._msMain);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this._msMain;
         this.MaximizeBox = false;
         this.Name = "MainForm";
         this.Text = "MainForm";
         this._msMain.ResumeLayout(false);
         this._msMain.PerformLayout();
         this._gbEngines.ResumeLayout(false);
         this._gbFinalDocument.ResumeLayout(false);
         this._gbFinalDocument.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip _msMain;
      private System.Windows.Forms.ToolStripMenuItem _miFile;
      private System.Windows.Forms.ToolStripMenuItem _miFileExit;
      private System.Windows.Forms.ToolStripMenuItem _miHelp;
      private System.Windows.Forms.ToolStripMenuItem _miHelpAbout;
      private System.Windows.Forms.ToolStripMenuItem _miOcr;
      private System.Windows.Forms.ToolStripMenuItem _miOcrSettings;
      private System.Windows.Forms.ToolStripMenuItem _miOcrComponents;
      private System.Windows.Forms.ToolStripMenuItem _miTwain;
      private System.Windows.Forms.ToolStripMenuItem _miTwainSelectSource;
      private System.Windows.Forms.GroupBox _gbEngines;
      private System.Windows.Forms.Label _lblOcrEngineName;
      private System.Windows.Forms.Label _lblOcrEngine;
      private System.Windows.Forms.Label _lblTwainSourceName;
      private System.Windows.Forms.Label _lblTwainSource;
      private System.Windows.Forms.Label _lblInfo;
      private System.Windows.Forms.GroupBox _gbFinalDocument;
      private System.Windows.Forms.Label _lblFinalDocumentFormat;
      private System.Windows.Forms.Label _lblFinalDocumentFileName;
      private System.Windows.Forms.TextBox _tbFinalDocumentFileName;
      private System.Windows.Forms.Button _btnFinalDocumentFileName;
      private System.Windows.Forms.Button _btnScan;
      private Leadtools.Demos.DocumentFormatSelector _documentFormatSelector;
   }
}

