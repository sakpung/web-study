namespace PrinterDemo
{
   partial class FrmMain
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
         this._mmMain = new System.Windows.Forms.MenuStrip();
         this._miFile = new System.Windows.Forms.ToolStripMenuItem();
         this._miSetActivePrinter = new System.Windows.Forms.ToolStripMenuItem();
         this._miPrintStartedPage = new System.Windows.Forms.ToolStripMenuItem();
         this._miSep2 = new System.Windows.Forms.ToolStripSeparator();
         this._miClearPrintedList = new System.Windows.Forms.ToolStripMenuItem();
         this._miSavePrintJobsAs = new System.Windows.Forms.ToolStripMenuItem();
         this._miRaster = new System.Windows.Forms.ToolStripMenuItem();
         this._miDocument = new System.Windows.Forms.ToolStripMenuItem();
         this._miSavePrintJobsAsAndClearList = new System.Windows.Forms.ToolStripMenuItem();
         this._miRasterClear = new System.Windows.Forms.ToolStripMenuItem();
         this._miDocumentClear = new System.Windows.Forms.ToolStripMenuItem();
         this._miSep3 = new System.Windows.Forms.ToolStripSeparator();
         this._miInstallPrinter = new System.Windows.Forms.ToolStripMenuItem();
         this._miUninstallPrinter = new System.Windows.Forms.ToolStripMenuItem();
         this._miSep1 = new System.Windows.Forms.ToolStripSeparator();
         this._miExit = new System.Windows.Forms.ToolStripMenuItem();
         this._miView = new System.Windows.Forms.ToolStripMenuItem();
         this._miNormal = new System.Windows.Forms.ToolStripMenuItem();
         this._miFit = new System.Windows.Forms.ToolStripMenuItem();
         this._miZoomIn = new System.Windows.Forms.ToolStripMenuItem();
         this._miZoomOut = new System.Windows.Forms.ToolStripMenuItem();
         this._miOptions = new System.Windows.Forms.ToolStripMenuItem();
         this._miEvents = new System.Windows.Forms.ToolStripMenuItem();
         this._miEventsEmf = new System.Windows.Forms.ToolStripMenuItem();
         this._miEventsJob = new System.Windows.Forms.ToolStripMenuItem();
         this._miPrinterLock = new System.Windows.Forms.ToolStripMenuItem();
         this._miLockPrinter = new System.Windows.Forms.ToolStripMenuItem();
         this._miUnLockPrinter = new System.Windows.Forms.ToolStripMenuItem();
         this._miPrinterSpecs = new System.Windows.Forms.ToolStripMenuItem();
         this._miViewOutputFile = new System.Windows.Forms.ToolStripMenuItem();
         this._miHelp = new System.Windows.Forms.ToolStripMenuItem();
         this._miAbout = new System.Windows.Forms.ToolStripMenuItem();
         this._miEventsEmf2 = new System.Windows.Forms.ToolStripMenuItem();
         this._miEventsJob2 = new System.Windows.Forms.ToolStripMenuItem();
         this._panelImageList = new System.Windows.Forms.Panel();
         this._lstBoxPages = new System.Windows.Forms.ListBox();
         this._panelPictureBox = new System.Windows.Forms.Panel();
         this._pictureBox = new Leadtools.Controls.ImageViewer();
         this.lockPrinterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.unlockPrinterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._miPrinterDefaultSpecs = new System.Windows.Forms.ToolStripMenuItem();
         this._mmMain.SuspendLayout();
         this._panelImageList.SuspendLayout();
         this._panelPictureBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _mmMain
         // 
         this._mmMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miFile,
            this._miView,
            this._miOptions,
            this._miHelp});
         this._mmMain.Location = new System.Drawing.Point(0, 0);
         this._mmMain.Name = "_mmMain";
         this._mmMain.Size = new System.Drawing.Size(533, 24);
         this._mmMain.TabIndex = 0;
         // 
         // _miFile
         // 
         this._miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miSetActivePrinter,
            this._miPrintStartedPage,
            this._miSep2,
            this._miClearPrintedList,
            this._miSavePrintJobsAs,
            this._miSavePrintJobsAsAndClearList,
            this._miSep3,
            this._miInstallPrinter,
            this._miUninstallPrinter,
            this._miSep1,
            this._miExit});
         this._miFile.Name = "_miFile";
         this._miFile.Size = new System.Drawing.Size(37, 20);
         this._miFile.Text = "&File";
         this._miFile.DropDownOpening += new System.EventHandler(this._miFile_DropDownOpening);
         // 
         // _miSetActivePrinter
         // 
         this._miSetActivePrinter.Name = "_miSetActivePrinter";
         this._miSetActivePrinter.Size = new System.Drawing.Size(244, 22);
         this._miSetActivePrinter.Text = "&Set &Active Printer";
         this._miSetActivePrinter.Click += new System.EventHandler(this._miSetActivePrinter_Click);
         // 
         // _miPrintStartedPage
         // 
         this._miPrintStartedPage.Name = "_miPrintStartedPage";
         this._miPrintStartedPage.Size = new System.Drawing.Size(244, 22);
         this._miPrintStartedPage.Text = "&Print Start Page";
         this._miPrintStartedPage.Click += new System.EventHandler(this._miPrintCurrentPage_Click);
         // 
         // _miSep2
         // 
         this._miSep2.Name = "_miSep2";
         this._miSep2.Size = new System.Drawing.Size(241, 6);
         // 
         // _miClearPrintedList
         // 
         this._miClearPrintedList.Name = "_miClearPrintedList";
         this._miClearPrintedList.Size = new System.Drawing.Size(244, 22);
         this._miClearPrintedList.Text = "&Clear Printed List";
         this._miClearPrintedList.Click += new System.EventHandler(this._miClearPrintedList_Click);
         // 
         // _miSavePrintJobsAs
         // 
         this._miSavePrintJobsAs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miRaster,
            this._miDocument});
         this._miSavePrintJobsAs.Name = "_miSavePrintJobsAs";
         this._miSavePrintJobsAs.Size = new System.Drawing.Size(244, 22);
         this._miSavePrintJobsAs.Text = "&Save Print Jobs As";
         // 
         // _miRaster
         // 
         this._miRaster.Name = "_miRaster";
         this._miRaster.Size = new System.Drawing.Size(130, 22);
         this._miRaster.Text = "&Image";
         this._miRaster.Click += new System.EventHandler(this._miRaster_Click);
         // 
         // _miDocument
         // 
         this._miDocument.Name = "_miDocument";
         this._miDocument.Size = new System.Drawing.Size(130, 22);
         this._miDocument.Text = "&Document";
         this._miDocument.Click += new System.EventHandler(this._miDocument_Click);
         // 
         // _miSavePrintJobsAsAndClearList
         // 
         this._miSavePrintJobsAsAndClearList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miRasterClear,
            this._miDocumentClear});
         this._miSavePrintJobsAsAndClearList.Name = "_miSavePrintJobsAsAndClearList";
         this._miSavePrintJobsAsAndClearList.Size = new System.Drawing.Size(244, 22);
         this._miSavePrintJobsAsAndClearList.Text = "Save Print Jobs As And Clear List";
         // 
         // _miRasterClear
         // 
         this._miRasterClear.Name = "_miRasterClear";
         this._miRasterClear.Size = new System.Drawing.Size(130, 22);
         this._miRasterClear.Text = "&Image";
         this._miRasterClear.Click += new System.EventHandler(this._miRasterClear_Click);
         // 
         // _miDocumentClear
         // 
         this._miDocumentClear.Name = "_miDocumentClear";
         this._miDocumentClear.Size = new System.Drawing.Size(130, 22);
         this._miDocumentClear.Text = "&Document";
         this._miDocumentClear.Click += new System.EventHandler(this._miDocumentClear_Click);
         // 
         // _miSep3
         // 
         this._miSep3.Name = "_miSep3";
         this._miSep3.Size = new System.Drawing.Size(241, 6);
         // 
         // _miInstallPrinter
         // 
         this._miInstallPrinter.Name = "_miInstallPrinter";
         this._miInstallPrinter.Size = new System.Drawing.Size(244, 22);
         this._miInstallPrinter.Text = "&Install Printer";
         this._miInstallPrinter.Click += new System.EventHandler(this._miInstallPrinter_Click);
         // 
         // _miUninstallPrinter
         // 
         this._miUninstallPrinter.Name = "_miUninstallPrinter";
         this._miUninstallPrinter.Size = new System.Drawing.Size(244, 22);
         this._miUninstallPrinter.Text = "&Uninstall Printer";
         this._miUninstallPrinter.Click += new System.EventHandler(this._miUninstallPrinter_Click);
         // 
         // _miSep1
         // 
         this._miSep1.Name = "_miSep1";
         this._miSep1.Size = new System.Drawing.Size(241, 6);
         // 
         // _miExit
         // 
         this._miExit.Name = "_miExit";
         this._miExit.Size = new System.Drawing.Size(244, 22);
         this._miExit.Text = "&Exit";
         this._miExit.Click += new System.EventHandler(this._miExit_Click);
         // 
         // _miView
         // 
         this._miView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miNormal,
            this._miFit,
            this._miZoomIn,
            this._miZoomOut});
         this._miView.Name = "_miView";
         this._miView.Size = new System.Drawing.Size(44, 20);
         this._miView.Text = "&View";
         // 
         // _miNormal
         // 
         this._miNormal.Checked = true;
         this._miNormal.CheckState = System.Windows.Forms.CheckState.Checked;
         this._miNormal.Enabled = false;
         this._miNormal.Name = "_miNormal";
         this._miNormal.Size = new System.Drawing.Size(151, 22);
         this._miNormal.Text = "&Normal";
         this._miNormal.Click += new System.EventHandler(this.View_Clicked);
         // 
         // _miFit
         // 
         this._miFit.Enabled = false;
         this._miFit.Name = "_miFit";
         this._miFit.Size = new System.Drawing.Size(151, 22);
         this._miFit.Text = "&Fit To Window";
         this._miFit.Click += new System.EventHandler(this.View_Clicked);
         // 
         // _miZoomIn
         // 
         this._miZoomIn.Enabled = false;
         this._miZoomIn.Name = "_miZoomIn";
         this._miZoomIn.Size = new System.Drawing.Size(151, 22);
         this._miZoomIn.Text = "Zoom &In (+)";
         this._miZoomIn.Click += new System.EventHandler(this.View_Clicked);
         // 
         // _miZoomOut
         // 
         this._miZoomOut.Enabled = false;
         this._miZoomOut.Name = "_miZoomOut";
         this._miZoomOut.Size = new System.Drawing.Size(151, 22);
         this._miZoomOut.Text = "Zoom &Out (-)";
         this._miZoomOut.Click += new System.EventHandler(this.View_Clicked);
         // 
         // _miOptions
         // 
         this._miOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miEvents,
            this._miPrinterLock,
            this._miPrinterSpecs,
            this._miPrinterDefaultSpecs,
            this._miViewOutputFile});
         this._miOptions.Name = "_miOptions";
         this._miOptions.Size = new System.Drawing.Size(61, 20);
         this._miOptions.Text = "&Options";
         this._miOptions.DropDownOpening += new System.EventHandler(this._miPrinterLock_DropDownOpening);
         // 
         // _miEvents
         // 
         this._miEvents.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miEventsEmf,
            this._miEventsJob});
         this._miEvents.Name = "_miEvents";
         this._miEvents.Size = new System.Drawing.Size(195, 22);
         this._miEvents.Text = "&Events";
         this._miEvents.Visible = false;
         // 
         // _miEventsEmf
         // 
         this._miEventsEmf.CheckOnClick = true;
         this._miEventsEmf.Name = "_miEventsEmf";
         this._miEventsEmf.Size = new System.Drawing.Size(127, 22);
         this._miEventsEmf.Text = "&Emf Event";
         this._miEventsEmf.Click += new System.EventHandler(this._miEventsEmf_Click);
         // 
         // _miEventsJob
         // 
         this._miEventsJob.CheckOnClick = true;
         this._miEventsJob.Name = "_miEventsJob";
         this._miEventsJob.Size = new System.Drawing.Size(127, 22);
         this._miEventsJob.Text = "&Job Event";
         this._miEventsJob.Click += new System.EventHandler(this._miEventsJob_Click);
         // 
         // _miPrinterLock
         // 
         this._miPrinterLock.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miLockPrinter,
            this._miUnLockPrinter});
         this._miPrinterLock.Name = "_miPrinterLock";
         this._miPrinterLock.Size = new System.Drawing.Size(195, 22);
         this._miPrinterLock.Text = "&Printer Lock";
         // 
         // _miLockPrinter
         // 
         this._miLockPrinter.Name = "_miLockPrinter";
         this._miLockPrinter.Size = new System.Drawing.Size(149, 22);
         this._miLockPrinter.Text = "&Lock Printer";
         this._miLockPrinter.Click += new System.EventHandler(this._miLockPrinter_Click);
         // 
         // _miUnLockPrinter
         // 
         this._miUnLockPrinter.Enabled = false;
         this._miUnLockPrinter.Name = "_miUnLockPrinter";
         this._miUnLockPrinter.Size = new System.Drawing.Size(149, 22);
         this._miUnLockPrinter.Text = "&Unlock Printer";
         this._miUnLockPrinter.Click += new System.EventHandler(this._miUnLockPrinter_Click);
         // 
         // _miPrinterSpecs
         // 
         this._miPrinterSpecs.Name = "_miPrinterSpecs";
         this._miPrinterSpecs.Size = new System.Drawing.Size(195, 22);
         this._miPrinterSpecs.Text = "Printer &Options";
         this._miPrinterSpecs.Click += new System.EventHandler(this._miPrinterSpecs_Click);
         // 
         // _miViewOutputFile
         // 
         this._miViewOutputFile.Checked = true;
         this._miViewOutputFile.CheckOnClick = true;
         this._miViewOutputFile.CheckState = System.Windows.Forms.CheckState.Checked;
         this._miViewOutputFile.Name = "_miViewOutputFile";
         this._miViewOutputFile.Size = new System.Drawing.Size(195, 22);
         this._miViewOutputFile.Text = "&View Output File";
         // 
         // _miHelp
         // 
         this._miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miAbout});
         this._miHelp.Name = "_miHelp";
         this._miHelp.Size = new System.Drawing.Size(44, 20);
         this._miHelp.Text = "&Help";
         // 
         // _miAbout
         // 
         this._miAbout.Name = "_miAbout";
         this._miAbout.Size = new System.Drawing.Size(180, 22);
         this._miAbout.Text = "&About Printer Demo";
         this._miAbout.Click += new System.EventHandler(this._miAbout_Click);
         // 
         // _miEventsEmf2
         // 
         this._miEventsEmf2.Name = "_miEventsEmf2";
         this._miEventsEmf2.Size = new System.Drawing.Size(152, 22);
         this._miEventsEmf2.Text = "a";
         // 
         // _miEventsJob2
         // 
         this._miEventsJob2.Name = "_miEventsJob2";
         this._miEventsJob2.Size = new System.Drawing.Size(152, 22);
         this._miEventsJob2.Text = "a";
         // 
         // _panelImageList
         // 
         this._panelImageList.Controls.Add(this._lstBoxPages);
         this._panelImageList.Dock = System.Windows.Forms.DockStyle.Left;
         this._panelImageList.Location = new System.Drawing.Point(0, 24);
         this._panelImageList.Name = "_panelImageList";
         this._panelImageList.Size = new System.Drawing.Size(182, 330);
         this._panelImageList.TabIndex = 4;
         // 
         // _lstBoxPages
         // 
         this._lstBoxPages.BackColor = System.Drawing.SystemColors.AppWorkspace;
         this._lstBoxPages.Dock = System.Windows.Forms.DockStyle.Fill;
         this._lstBoxPages.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
         this._lstBoxPages.FormattingEnabled = true;
         this._lstBoxPages.ItemHeight = 150;
         this._lstBoxPages.Location = new System.Drawing.Point(0, 0);
         this._lstBoxPages.Name = "_lstBoxPages";
         this._lstBoxPages.Size = new System.Drawing.Size(182, 330);
         this._lstBoxPages.TabIndex = 0;
         this._lstBoxPages.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this._lstBoxPages_DrawItem);
         this._lstBoxPages.SelectedIndexChanged += new System.EventHandler(this._lstBoxPages_SelectedIndexChanged);
         this._lstBoxPages.KeyDown += new System.Windows.Forms.KeyEventHandler(this._lstBoxPages_KeyDown);
         // 
         // _panelPictureBox
         // 
         this._panelPictureBox.AutoScroll = true;
         this._panelPictureBox.Controls.Add(this._pictureBox);
         this._panelPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this._panelPictureBox.Location = new System.Drawing.Point(182, 24);
         this._panelPictureBox.Name = "_panelPictureBox";
         this._panelPictureBox.Size = new System.Drawing.Size(351, 330);
         this._panelPictureBox.TabIndex = 5;
         // 
         // _pictureBox
         // 
         this._pictureBox.BackColor = System.Drawing.SystemColors.ButtonFace;
         this._pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this._pictureBox.Location = new System.Drawing.Point(0, 0);
         this._pictureBox.Name = "_pictureBox";
         this._pictureBox.Size = new System.Drawing.Size(351, 330);
         this._pictureBox.TabIndex = 0;
         this._pictureBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this._pictureBox_KeyDown);
         this._pictureBox.Render += new System.EventHandler<Leadtools.Controls.ImageViewerRenderEventArgs>(this._pictureBox_Paint);
         // 
         // lockPrinterToolStripMenuItem
         // 
         this.lockPrinterToolStripMenuItem.Name = "lockPrinterToolStripMenuItem";
         this.lockPrinterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.lockPrinterToolStripMenuItem.Text = "a";
         // 
         // unlockPrinterToolStripMenuItem
         // 
         this.unlockPrinterToolStripMenuItem.Name = "unlockPrinterToolStripMenuItem";
         this.unlockPrinterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.unlockPrinterToolStripMenuItem.Text = "a";
         // 
         // _miPrinterDefaultSpecs
         // 
         this._miPrinterDefaultSpecs.Name = "_miPrinterDefaultSpecs";
         this._miPrinterDefaultSpecs.Size = new System.Drawing.Size(195, 22);
         this._miPrinterDefaultSpecs.Text = "Printer &User Options";
         this._miPrinterDefaultSpecs.Click += new System.EventHandler(this._miPrinterDefaultSpecs_Click);
         // 
         // FrmMain
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(533, 354);
         this.Controls.Add(this._panelPictureBox);
         this.Controls.Add(this._panelImageList);
         this.Controls.Add(this._mmMain);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this._mmMain;
         this.Name = "FrmMain";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "LEADTOOLS C# Printer Demo";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.Load += new System.EventHandler(this.FrmMain_Load);
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
         this.Resize += new System.EventHandler(this.FrmMain_Resize);
         this._mmMain.ResumeLayout(false);
         this._mmMain.PerformLayout();
         this._panelImageList.ResumeLayout(false);
         this._panelPictureBox.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip _mmMain;
      private System.Windows.Forms.ToolStripMenuItem _miFile;
      private System.Windows.Forms.ToolStripMenuItem _miSetActivePrinter;
      private System.Windows.Forms.ToolStripMenuItem _miInstallPrinter;
      private System.Windows.Forms.ToolStripMenuItem _miUninstallPrinter;
      private System.Windows.Forms.ToolStripSeparator _miSep1;
      private System.Windows.Forms.ToolStripMenuItem _miExit;
      private System.Windows.Forms.ToolStripMenuItem _miHelp;
      private System.Windows.Forms.ToolStripMenuItem _miAbout;
      private System.Windows.Forms.ToolStripMenuItem _miLockPrinter;
      private System.Windows.Forms.ToolStripMenuItem _miUnLockPrinter;
      private System.Windows.Forms.ToolStripMenuItem _miEventsEmf;
      private System.Windows.Forms.ToolStripMenuItem _miEventsJob;
      private System.Windows.Forms.ToolStripMenuItem _miSavePrintJobsAs;
      private System.Windows.Forms.ToolStripMenuItem _miPrintStartedPage;
      private System.Windows.Forms.Panel _panelImageList;
      private System.Windows.Forms.ListBox _lstBoxPages;
      private System.Windows.Forms.Panel _panelPictureBox;
      private System.Windows.Forms.ToolStripMenuItem _miClearPrintedList;
      private System.Windows.Forms.ToolStripMenuItem _miViewOutputFile;
      private System.Windows.Forms.ToolStripMenuItem _miSavePrintJobsAsAndClearList;
      private System.Windows.Forms.ToolStripSeparator _miSep2;
      private System.Windows.Forms.ToolStripSeparator _miSep3;
      private System.Windows.Forms.ToolStripMenuItem _miOptions;
      private System.Windows.Forms.ToolStripMenuItem _miEvents;
      private System.Windows.Forms.ToolStripMenuItem _miEventsEmf2;
      private System.Windows.Forms.ToolStripMenuItem _miEventsJob2;
      private System.Windows.Forms.ToolStripMenuItem _miPrinterLock;
      private System.Windows.Forms.ToolStripMenuItem lockPrinterToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem unlockPrinterToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _miRaster;
      private System.Windows.Forms.ToolStripMenuItem _miDocument;
      private System.Windows.Forms.ToolStripMenuItem _miRasterClear;
      private System.Windows.Forms.ToolStripMenuItem _miDocumentClear;
      private System.Windows.Forms.ToolStripMenuItem _miPrinterSpecs;
      private Leadtools.Controls.ImageViewer _pictureBox;
      private System.Windows.Forms.ToolStripMenuItem _miView;
      private System.Windows.Forms.ToolStripMenuItem _miNormal;
      private System.Windows.Forms.ToolStripMenuItem _miFit;
      private System.Windows.Forms.ToolStripMenuItem _miZoomIn;
      private System.Windows.Forms.ToolStripMenuItem _miZoomOut;
      private System.Windows.Forms.ToolStripMenuItem _miPrinterDefaultSpecs;

   }
}

