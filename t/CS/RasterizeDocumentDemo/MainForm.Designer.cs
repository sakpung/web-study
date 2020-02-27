namespace RasterizeDocumentDemo
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
         this._mainMenuStrip = new System.Windows.Forms.MenuStrip();
         this._fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._fileExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._helpAboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._optionsTabControl = new System.Windows.Forms.TabControl();
         this._rasterizeDocumentOptionsTabPage = new System.Windows.Forms.TabPage();
         this._rasterizeDocumentOptionsControl = new RasterizeDocumentDemo.UserControls.RasterizeDocumentOptionsControl();
         this._pdfOptionsTabPage = new System.Windows.Forms.TabPage();
         this._pdfOptionsControl = new RasterizeDocumentDemo.UserControls.PdfOptionsControl();
         this._xpsOptionsTabPage = new System.Windows.Forms.TabPage();
         this._xpsOptionsControl = new RasterizeDocumentDemo.UserControls.XpsOptionsControl();
         this._xlsOptionsTabPage = new System.Windows.Forms.TabPage();
         this._xlsOptionsControl = new RasterizeDocumentDemo.UserControls.XlsOptionsControl();
         this._rtfOptionsTabPage = new System.Windows.Forms.TabPage();
         this._rtfOptionsControl = new RasterizeDocumentDemo.UserControls.RtfOptionsControl();
         this._txtOptionsTabPage = new System.Windows.Forms.TabPage();
         this._txtOptionsControl = new RasterizeDocumentDemo.UserControls.TxtOptionsControl();
         this._docOptionsTabPage = new System.Windows.Forms.TabPage();
         this._docOptionsControl = new RasterizeDocumentDemo.UserControls.DocOptionsControl();
         this._getDocumentInformationButton = new System.Windows.Forms.Button();
         this._loadDocumentInViewerButton = new System.Windows.Forms.Button();
         this._documentInfoControl = new RasterizeDocumentDemo.UserControls.DocumentInfoControl();
         this._documentPathControl = new RasterizeDocumentDemo.UserControls.DocumentPathControl();
         this._mainMenuStrip.SuspendLayout();
         this._optionsTabControl.SuspendLayout();
         this._rasterizeDocumentOptionsTabPage.SuspendLayout();
         this._pdfOptionsTabPage.SuspendLayout();
         this._xpsOptionsTabPage.SuspendLayout();
         this._xlsOptionsTabPage.SuspendLayout();
         this._rtfOptionsTabPage.SuspendLayout();
         this._txtOptionsTabPage.SuspendLayout();
         this._docOptionsTabPage.SuspendLayout();
         this.SuspendLayout();
         // 
         // _mainMenuStrip
         // 
         this._mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem,
            this._helpToolStripMenuItem});
         this._mainMenuStrip.Location = new System.Drawing.Point(0, 0);
         this._mainMenuStrip.Name = "_mainMenuStrip";
         this._mainMenuStrip.Size = new System.Drawing.Size(741, 24);
         this._mainMenuStrip.TabIndex = 0;
         // 
         // _fileToolStripMenuItem
         // 
         this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileExitToolStripMenuItem});
         this._fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
         this._fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this._fileToolStripMenuItem.Text = "&File";
         // 
         // _fileExitToolStripMenuItem
         // 
         this._fileExitToolStripMenuItem.Name = "_fileExitToolStripMenuItem";
         this._fileExitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
         this._fileExitToolStripMenuItem.Text = "E&xit";
         this._fileExitToolStripMenuItem.Click += new System.EventHandler(this._fileExitToolStripMenuItem_Click);
         // 
         // _helpToolStripMenuItem
         // 
         this._helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._helpAboutToolStripMenuItem});
         this._helpToolStripMenuItem.Name = "_helpToolStripMenuItem";
         this._helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
         this._helpToolStripMenuItem.Text = "&Help";
         // 
         // _helpAboutToolStripMenuItem
         // 
         this._helpAboutToolStripMenuItem.Name = "_helpAboutToolStripMenuItem";
         this._helpAboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
         this._helpAboutToolStripMenuItem.Text = "&About...";
         this._helpAboutToolStripMenuItem.Click += new System.EventHandler(this._helpAboutToolStripMenuItem_Click);
         // 
         // _optionsTabControl
         // 
         this._optionsTabControl.Controls.Add(this._rasterizeDocumentOptionsTabPage);
         this._optionsTabControl.Controls.Add(this._pdfOptionsTabPage);
         this._optionsTabControl.Controls.Add(this._xpsOptionsTabPage);
         this._optionsTabControl.Controls.Add(this._xlsOptionsTabPage);
         this._optionsTabControl.Controls.Add(this._rtfOptionsTabPage);
         this._optionsTabControl.Controls.Add(this._txtOptionsTabPage);
         this._optionsTabControl.Controls.Add(this._docOptionsTabPage);
         this._optionsTabControl.Location = new System.Drawing.Point(13, 28);
         this._optionsTabControl.Name = "_optionsTabControl";
         this._optionsTabControl.SelectedIndex = 0;
         this._optionsTabControl.Size = new System.Drawing.Size(520, 270);
         this._optionsTabControl.TabIndex = 1;
         // 
         // _rasterizeDocumentOptionsTabPage
         // 
         this._rasterizeDocumentOptionsTabPage.Controls.Add(this._rasterizeDocumentOptionsControl);
         this._rasterizeDocumentOptionsTabPage.Location = new System.Drawing.Point(4, 22);
         this._rasterizeDocumentOptionsTabPage.Name = "_rasterizeDocumentOptionsTabPage";
         this._rasterizeDocumentOptionsTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._rasterizeDocumentOptionsTabPage.Size = new System.Drawing.Size(512, 244);
         this._rasterizeDocumentOptionsTabPage.TabIndex = 0;
         this._rasterizeDocumentOptionsTabPage.Text = "Rasterize Document";
         this._rasterizeDocumentOptionsTabPage.UseVisualStyleBackColor = true;
         // 
         // _rasterizeDocumentOptionsControl
         // 
         this._rasterizeDocumentOptionsControl.Location = new System.Drawing.Point(8, 8);
         this._rasterizeDocumentOptionsControl.Name = "_rasterizeDocumentOptionsControl";
         this._rasterizeDocumentOptionsControl.Size = new System.Drawing.Size(500, 230);
         this._rasterizeDocumentOptionsControl.TabIndex = 0;
         // 
         // _pdfOptionsTabPage
         // 
         this._pdfOptionsTabPage.Controls.Add(this._pdfOptionsControl);
         this._pdfOptionsTabPage.Location = new System.Drawing.Point(4, 22);
         this._pdfOptionsTabPage.Name = "_pdfOptionsTabPage";
         this._pdfOptionsTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._pdfOptionsTabPage.Size = new System.Drawing.Size(512, 244);
         this._pdfOptionsTabPage.TabIndex = 1;
         this._pdfOptionsTabPage.Text = "PDF";
         this._pdfOptionsTabPage.UseVisualStyleBackColor = true;
         // 
         // _pdfOptionsControl
         // 
         this._pdfOptionsControl.Location = new System.Drawing.Point(8, 8);
         this._pdfOptionsControl.Name = "_pdfOptionsControl";
         this._pdfOptionsControl.Size = new System.Drawing.Size(500, 230);
         this._pdfOptionsControl.TabIndex = 0;
         // 
         // _xpsOptionsTabPage
         // 
         this._xpsOptionsTabPage.Controls.Add(this._xpsOptionsControl);
         this._xpsOptionsTabPage.Location = new System.Drawing.Point(4, 22);
         this._xpsOptionsTabPage.Name = "_xpsOptionsTabPage";
         this._xpsOptionsTabPage.Size = new System.Drawing.Size(512, 244);
         this._xpsOptionsTabPage.TabIndex = 2;
         this._xpsOptionsTabPage.Text = "XPS";
         this._xpsOptionsTabPage.UseVisualStyleBackColor = true;
         // 
         // _xpsOptionsControl
         // 
         this._xpsOptionsControl.Location = new System.Drawing.Point(8, 8);
         this._xpsOptionsControl.Name = "_xpsOptionsControl";
         this._xpsOptionsControl.Size = new System.Drawing.Size(500, 230);
         this._xpsOptionsControl.TabIndex = 0;
         // 
         // _xlsOptionsTabPage
         // 
         this._xlsOptionsTabPage.Controls.Add(this._xlsOptionsControl);
         this._xlsOptionsTabPage.Location = new System.Drawing.Point(4, 22);
         this._xlsOptionsTabPage.Name = "_xlsOptionsTabPage";
         this._xlsOptionsTabPage.Size = new System.Drawing.Size(512, 244);
         this._xlsOptionsTabPage.TabIndex = 3;
         this._xlsOptionsTabPage.Text = "XLS";
         this._xlsOptionsTabPage.UseVisualStyleBackColor = true;
         // 
         // _xlsOptionsControl
         // 
         this._xlsOptionsControl.Location = new System.Drawing.Point(8, 8);
         this._xlsOptionsControl.Name = "_xlsOptionsControl";
         this._xlsOptionsControl.Size = new System.Drawing.Size(500, 230);
         this._xlsOptionsControl.TabIndex = 0;
         // 
         // _rtfOptionsTabPage
         // 
         this._rtfOptionsTabPage.Controls.Add(this._rtfOptionsControl);
         this._rtfOptionsTabPage.Location = new System.Drawing.Point(4, 22);
         this._rtfOptionsTabPage.Name = "_rtfOptionsTabPage";
         this._rtfOptionsTabPage.Size = new System.Drawing.Size(512, 244);
         this._rtfOptionsTabPage.TabIndex = 4;
         this._rtfOptionsTabPage.Text = "RTF";
         this._rtfOptionsTabPage.UseVisualStyleBackColor = true;
         // 
         // _rtfOptionsControl
         // 
         this._rtfOptionsControl.Location = new System.Drawing.Point(8, 8);
         this._rtfOptionsControl.Name = "_rtfOptionsControl";
         this._rtfOptionsControl.Size = new System.Drawing.Size(500, 230);
         this._rtfOptionsControl.TabIndex = 0;
         // 
         // _txtOptionsTabPage
         // 
         this._txtOptionsTabPage.Controls.Add(this._txtOptionsControl);
         this._txtOptionsTabPage.Location = new System.Drawing.Point(4, 22);
         this._txtOptionsTabPage.Name = "_txtOptionsTabPage";
         this._txtOptionsTabPage.Size = new System.Drawing.Size(512, 244);
         this._txtOptionsTabPage.TabIndex = 5;
         this._txtOptionsTabPage.Text = "TXT";
         this._txtOptionsTabPage.UseVisualStyleBackColor = true;
         // 
         // _txtOptionsControl
         // 
         this._txtOptionsControl.Location = new System.Drawing.Point(8, 8);
         this._txtOptionsControl.Name = "_txtOptionsControl";
         this._txtOptionsControl.Size = new System.Drawing.Size(500, 230);
         this._txtOptionsControl.TabIndex = 0;
         // 
         // _docOptionsTabPage
         // 
         this._docOptionsTabPage.Controls.Add(this._docOptionsControl);
         this._docOptionsTabPage.Location = new System.Drawing.Point(4, 22);
         this._docOptionsTabPage.Name = "_docOptionsTabPage";
         this._docOptionsTabPage.Size = new System.Drawing.Size(512, 244);
         this._docOptionsTabPage.TabIndex = 6;
         this._docOptionsTabPage.Text = "DOC / DOCX";
         this._docOptionsTabPage.UseVisualStyleBackColor = true;
         // 
         // _docOptionsControl
         // 
         this._docOptionsControl.Location = new System.Drawing.Point(8, 8);
         this._docOptionsControl.Name = "_docOptionsControl";
         this._docOptionsControl.Size = new System.Drawing.Size(500, 230);
         this._docOptionsControl.TabIndex = 0;
         // 
         // _getDocumentInformationButton
         // 
         this._getDocumentInformationButton.Location = new System.Drawing.Point(548, 380);
         this._getDocumentInformationButton.Name = "_getDocumentInformationButton";
         this._getDocumentInformationButton.Size = new System.Drawing.Size(181, 23);
         this._getDocumentInformationButton.TabIndex = 4;
         this._getDocumentInformationButton.Text = "Get document &information";
         this._getDocumentInformationButton.UseVisualStyleBackColor = true;
         this._getDocumentInformationButton.Click += new System.EventHandler(this._getDocumentInformationButton_Click);
         // 
         // _loadDocumentInViewerButton
         // 
         this._loadDocumentInViewerButton.Location = new System.Drawing.Point(548, 409);
         this._loadDocumentInViewerButton.Name = "_loadDocumentInViewerButton";
         this._loadDocumentInViewerButton.Size = new System.Drawing.Size(181, 23);
         this._loadDocumentInViewerButton.TabIndex = 5;
         this._loadDocumentInViewerButton.Text = "&Load document in the viewer";
         this._loadDocumentInViewerButton.UseVisualStyleBackColor = true;
         this._loadDocumentInViewerButton.Click += new System.EventHandler(this._loadDocumentInViewerButton_Click);
         // 
         // _documentInfoControl
         // 
         this._documentInfoControl.Location = new System.Drawing.Point(9, 380);
         this._documentInfoControl.Name = "_documentInfoControl";
         this._documentInfoControl.Size = new System.Drawing.Size(520, 200);
         this._documentInfoControl.TabIndex = 3;
         // 
         // _documentPathControl
         // 
         this._documentPathControl.Location = new System.Drawing.Point(12, 304);
         this._documentPathControl.Name = "_documentPathControl";
         this._documentPathControl.Size = new System.Drawing.Size(520, 70);
         this._documentPathControl.TabIndex = 2;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(741, 590);
         this.Controls.Add(this._loadDocumentInViewerButton);
         this.Controls.Add(this._documentInfoControl);
         this.Controls.Add(this._getDocumentInformationButton);
         this.Controls.Add(this._documentPathControl);
         this.Controls.Add(this._optionsTabControl);
         this.Controls.Add(this._mainMenuStrip);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MinimizeBox = false;
         this.Name = "MainForm";
         this.Text = "MainForm";
         this._mainMenuStrip.ResumeLayout(false);
         this._mainMenuStrip.PerformLayout();
         this._optionsTabControl.ResumeLayout(false);
         this._rasterizeDocumentOptionsTabPage.ResumeLayout(false);
         this._pdfOptionsTabPage.ResumeLayout(false);
         this._xpsOptionsTabPage.ResumeLayout(false);
         this._xlsOptionsTabPage.ResumeLayout(false);
         this._rtfOptionsTabPage.ResumeLayout(false);
         this._txtOptionsTabPage.ResumeLayout(false);
         this._docOptionsTabPage.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip _mainMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fileExitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _helpToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _helpAboutToolStripMenuItem;
      private System.Windows.Forms.TabControl _optionsTabControl;
      private System.Windows.Forms.TabPage _rasterizeDocumentOptionsTabPage;
      private System.Windows.Forms.TabPage _pdfOptionsTabPage;
      private System.Windows.Forms.TabPage _xpsOptionsTabPage;
      private System.Windows.Forms.TabPage _xlsOptionsTabPage;
      private System.Windows.Forms.TabPage _rtfOptionsTabPage;
      private System.Windows.Forms.TabPage _txtOptionsTabPage;
      private RasterizeDocumentDemo.UserControls.RasterizeDocumentOptionsControl _rasterizeDocumentOptionsControl;
      private RasterizeDocumentDemo.UserControls.PdfOptionsControl _pdfOptionsControl;
      private RasterizeDocumentDemo.UserControls.XpsOptionsControl _xpsOptionsControl;
      private RasterizeDocumentDemo.UserControls.XlsOptionsControl _xlsOptionsControl;
      private RasterizeDocumentDemo.UserControls.RtfOptionsControl _rtfOptionsControl;
      private RasterizeDocumentDemo.UserControls.TxtOptionsControl _txtOptionsControl;
      private RasterizeDocumentDemo.UserControls.DocOptionsControl _docOptionsControl;
      private RasterizeDocumentDemo.UserControls.DocumentPathControl _documentPathControl;
      private System.Windows.Forms.Button _getDocumentInformationButton;
      private RasterizeDocumentDemo.UserControls.DocumentInfoControl _documentInfoControl;
      private System.Windows.Forms.Button _loadDocumentInViewerButton;
      private System.Windows.Forms.TabPage _docOptionsTabPage;
   }
}

