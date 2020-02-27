namespace DicomVideoCaptureDemo
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
         this._menu_main = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._mi_NewFile = new System.Windows.Forms.ToolStripMenuItem();
         this._mi_OpenFile = new System.Windows.Forms.ToolStripMenuItem();
         this._mi_CloseFile = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this._mi_SaveFile = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this._mi_Exit = new System.Windows.Forms.ToolStripMenuItem();
         this._mi_View = new System.Windows.Forms.ToolStripMenuItem();
         this._mi_Toolbar = new System.Windows.Forms.ToolStripMenuItem();
         this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._mi_VideoDevice = new System.Windows.Forms.ToolStripMenuItem();
         this._mi_AudioDevice = new System.Windows.Forms.ToolStripMenuItem();
         this._mi_captureProperties = new System.Windows.Forms.ToolStripMenuItem();
         this._mi_compressionSettings = new System.Windows.Forms.ToolStripMenuItem();
         this.captureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._mi_StartCaptureIntoDicomFile = new System.Windows.Forms.ToolStripMenuItem();
         this._mi_StopCapture = new System.Windows.Forms.ToolStripMenuItem();
         this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._mi_About = new System.Windows.Forms.ToolStripMenuItem();
         this._toolbar_Main = new System.Windows.Forms.ToolStrip();
         this._tS_New = new System.Windows.Forms.ToolStripButton();
         this._tS_Open = new System.Windows.Forms.ToolStripButton();
         this._tS_Save = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this._tS_Help = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
         this._tS_ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this._panel_FileTree = new System.Windows.Forms.Panel();
         this._treeView = new System.Windows.Forms.TreeView();
         this._panel_CapturePanel = new System.Windows.Forms.Panel();
         this._menu_main.SuspendLayout();
         this._toolbar_Main.SuspendLayout();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this._panel_FileTree.SuspendLayout();
         this.SuspendLayout();
         // 
         // _menu_main
         // 
         this._menu_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this._mi_View,
            this.optionsToolStripMenuItem,
            this.captureToolStripMenuItem,
            this.helpToolStripMenuItem});
         this._menu_main.Location = new System.Drawing.Point(0, 0);
         this._menu_main.Name = "_menu_main";
         this._menu_main.Size = new System.Drawing.Size(1037, 24);
         this._menu_main.TabIndex = 0;
         this._menu_main.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mi_NewFile,
            this._mi_OpenFile,
            this._mi_CloseFile,
            this.toolStripSeparator1,
            this._mi_SaveFile,
            this.toolStripSeparator2,
            this._mi_Exit});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "&File";
         // 
         // _mi_NewFile
         // 
         this._mi_NewFile.Name = "_mi_NewFile";
         this._mi_NewFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
         this._mi_NewFile.Size = new System.Drawing.Size(218, 22);
         this._mi_NewFile.Text = "&New DICOM File...";
         this._mi_NewFile.Click += new System.EventHandler(this._mi_NewFile_Click);
         // 
         // _mi_OpenFile
         // 
         this._mi_OpenFile.Name = "_mi_OpenFile";
         this._mi_OpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
         this._mi_OpenFile.Size = new System.Drawing.Size(218, 22);
         this._mi_OpenFile.Text = "&Open DICOM File...";
         this._mi_OpenFile.Click += new System.EventHandler(this._mi_OpenFile_Click);
         // 
         // _mi_CloseFile
         // 
         this._mi_CloseFile.Name = "_mi_CloseFile";
         this._mi_CloseFile.Size = new System.Drawing.Size(218, 22);
         this._mi_CloseFile.Text = "&Close DICOM File";
         this._mi_CloseFile.Click += new System.EventHandler(this._mi_CloseFile_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(215, 6);
         // 
         // _mi_SaveFile
         // 
         this._mi_SaveFile.Name = "_mi_SaveFile";
         this._mi_SaveFile.Size = new System.Drawing.Size(218, 22);
         this._mi_SaveFile.Text = "Save DICOM File &As...";
         this._mi_SaveFile.Click += new System.EventHandler(this._mi_SaveFile_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(215, 6);
         // 
         // _mi_Exit
         // 
         this._mi_Exit.Name = "_mi_Exit";
         this._mi_Exit.Size = new System.Drawing.Size(218, 22);
         this._mi_Exit.Text = "E&xit";
         this._mi_Exit.Click += new System.EventHandler(this._mi_Exit_Click);
         // 
         // _mi_View
         // 
         this._mi_View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mi_Toolbar});
         this._mi_View.Name = "_mi_View";
         this._mi_View.Size = new System.Drawing.Size(44, 20);
         this._mi_View.Text = "&View";
         // 
         // _mi_Toolbar
         // 
         this._mi_Toolbar.Name = "_mi_Toolbar";
         this._mi_Toolbar.Size = new System.Drawing.Size(152, 22);
         this._mi_Toolbar.Text = "&Toolbar";
         this._mi_Toolbar.Click += new System.EventHandler(this._mi_Toolbar_Click);
         // 
         // optionsToolStripMenuItem
         // 
         this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mi_VideoDevice,
            this._mi_AudioDevice,
            this._mi_captureProperties,
            this._mi_compressionSettings});
         this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
         this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
         this.optionsToolStripMenuItem.Text = "&Options";
         // 
         // _mi_VideoDevice
         // 
         this._mi_VideoDevice.Name = "_mi_VideoDevice";
         this._mi_VideoDevice.Size = new System.Drawing.Size(198, 22);
         this._mi_VideoDevice.Text = "&Video Device";
         // 
         // _mi_AudioDevice
         // 
         this._mi_AudioDevice.Name = "_mi_AudioDevice";
         this._mi_AudioDevice.Size = new System.Drawing.Size(198, 22);
         this._mi_AudioDevice.Text = "&Audio Device";
         // 
         // _mi_captureProperties
         // 
         this._mi_captureProperties.Name = "_mi_captureProperties";
         this._mi_captureProperties.Size = new System.Drawing.Size(198, 22);
         this._mi_captureProperties.Text = "&Capture Properties...";
         this._mi_captureProperties.Click += new System.EventHandler(this._mi_captureProperties_Click);
         // 
         // _mi_compressionSettings
         // 
         this._mi_compressionSettings.Name = "_mi_compressionSettings";
         this._mi_compressionSettings.Size = new System.Drawing.Size(198, 22);
         this._mi_compressionSettings.Text = "C&ompression Settings...";
         this._mi_compressionSettings.Click += new System.EventHandler(this._mi_compressionSettings_Click);
         // 
         // captureToolStripMenuItem
         // 
         this.captureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mi_StartCaptureIntoDicomFile,
            this._mi_StopCapture});
         this.captureToolStripMenuItem.Name = "captureToolStripMenuItem";
         this.captureToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
         this.captureToolStripMenuItem.Text = "&Capture";
         // 
         // _mi_StartCaptureIntoDicomFile
         // 
         this._mi_StartCaptureIntoDicomFile.Name = "_mi_StartCaptureIntoDicomFile";
         this._mi_StartCaptureIntoDicomFile.Size = new System.Drawing.Size(230, 22);
         this._mi_StartCaptureIntoDicomFile.Text = "&Start Capture Into DICOM File";
         this._mi_StartCaptureIntoDicomFile.Click += new System.EventHandler(this._mi_StartCaptureIntoDicomFile_Click);
         // 
         // _mi_StopCapture
         // 
         this._mi_StopCapture.Name = "_mi_StopCapture";
         this._mi_StopCapture.Size = new System.Drawing.Size(230, 22);
         this._mi_StopCapture.Text = "Stop &Capture";
         this._mi_StopCapture.Click += new System.EventHandler(this._mi_StopCapture_Click);
         // 
         // helpToolStripMenuItem
         // 
         this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mi_About});
         this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
         this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
         this.helpToolStripMenuItem.Text = "&Help";
         // 
         // _mi_About
         // 
         this._mi_About.Name = "_mi_About";
         this._mi_About.Size = new System.Drawing.Size(152, 22);
         this._mi_About.Text = "&About...";
         this._mi_About.Click += new System.EventHandler(this._mi_About_Click);
         // 
         // _toolbar_Main
         // 
         this._toolbar_Main.BackColor = System.Drawing.SystemColors.Control;
         this._toolbar_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tS_New,
            this._tS_Open,
            this._tS_Save,
            this.toolStripSeparator3,
            this._tS_Help,
            this.toolStripSeparator4,
            this._tS_ProgressBar});
         this._toolbar_Main.Location = new System.Drawing.Point(0, 24);
         this._toolbar_Main.Name = "_toolbar_Main";
         this._toolbar_Main.Size = new System.Drawing.Size(1037, 25);
         this._toolbar_Main.TabIndex = 2;
         this._toolbar_Main.Text = "toolStrip1";
         // 
         // _tS_New
         // 
         this._tS_New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._tS_New.Image = ((System.Drawing.Image)(resources.GetObject("_tS_New.Image")));
         this._tS_New.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._tS_New.Name = "_tS_New";
         this._tS_New.Size = new System.Drawing.Size(23, 22);
         this._tS_New.Text = "New Dicom File";
         this._tS_New.Click += new System.EventHandler(this.toolStripButton1_Click);
         // 
         // _tS_Open
         // 
         this._tS_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._tS_Open.Image = ((System.Drawing.Image)(resources.GetObject("_tS_Open.Image")));
         this._tS_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._tS_Open.Name = "_tS_Open";
         this._tS_Open.Size = new System.Drawing.Size(23, 22);
         this._tS_Open.Text = "Open Dicom File";
         this._tS_Open.Click += new System.EventHandler(this.toolStripButton2_Click);
         // 
         // _tS_Save
         // 
         this._tS_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._tS_Save.Image = ((System.Drawing.Image)(resources.GetObject("_tS_Save.Image")));
         this._tS_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._tS_Save.Name = "_tS_Save";
         this._tS_Save.Size = new System.Drawing.Size(23, 22);
         this._tS_Save.Text = "Save Dicom File";
         this._tS_Save.Click += new System.EventHandler(this.toolStripButton3_Click);
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
         // 
         // _tS_Help
         // 
         this._tS_Help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._tS_Help.Image = ((System.Drawing.Image)(resources.GetObject("_tS_Help.Image")));
         this._tS_Help.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._tS_Help.Name = "_tS_Help";
         this._tS_Help.Size = new System.Drawing.Size(23, 22);
         this._tS_Help.Text = "Help";
         this._tS_Help.Click += new System.EventHandler(this.toolStripButton4_Click);
         // 
         // toolStripSeparator4
         // 
         this.toolStripSeparator4.Name = "toolStripSeparator4";
         this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
         // 
         // _tS_ProgressBar
         // 
         this._tS_ProgressBar.Name = "_tS_ProgressBar";
         this._tS_ProgressBar.Size = new System.Drawing.Size(100, 22);
         // 
         // splitContainer1
         // 
         this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.splitContainer1.Location = new System.Drawing.Point(0, 49);
         this.splitContainer1.Name = "splitContainer1";
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this._panel_FileTree);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this._panel_CapturePanel);
         this.splitContainer1.Size = new System.Drawing.Size(1037, 754);
         this.splitContainer1.SplitterDistance = 302;
         this.splitContainer1.TabIndex = 3;
         // 
         // _panel_FileTree
         // 
         this._panel_FileTree.BackColor = System.Drawing.SystemColors.Window;
         this._panel_FileTree.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._panel_FileTree.Controls.Add(this._treeView);
         this._panel_FileTree.Dock = System.Windows.Forms.DockStyle.Fill;
         this._panel_FileTree.Location = new System.Drawing.Point(0, 0);
         this._panel_FileTree.Name = "_panel_FileTree";
         this._panel_FileTree.Size = new System.Drawing.Size(298, 750);
         this._panel_FileTree.TabIndex = 0;
         // 
         // _treeView
         // 
         this._treeView.Dock = System.Windows.Forms.DockStyle.Fill;
         this._treeView.Location = new System.Drawing.Point(0, 0);
         this._treeView.Name = "_treeView";
         this._treeView.Size = new System.Drawing.Size(294, 746);
         this._treeView.TabIndex = 0;
         this._treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._treeView_NodeMouseDoubleClick);
         // 
         // _panel_CapturePanel
         // 
         this._panel_CapturePanel.BackColor = System.Drawing.SystemColors.Window;
         this._panel_CapturePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._panel_CapturePanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this._panel_CapturePanel.Location = new System.Drawing.Point(0, 0);
         this._panel_CapturePanel.Name = "_panel_CapturePanel";
         this._panel_CapturePanel.Size = new System.Drawing.Size(727, 750);
         this._panel_CapturePanel.TabIndex = 1;
         this._panel_CapturePanel.Resize += new System.EventHandler(this._panel_CapturePanel_Resize);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1037, 803);
         this.Controls.Add(this.splitContainer1);
         this.Controls.Add(this._toolbar_Main);
         this.Controls.Add(this._menu_main);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this._menu_main;
         this.Name = "MainForm";
         this.Text = "C# DICOM Video Capture Demo";
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this._menu_main.ResumeLayout(false);
         this._menu_main.PerformLayout();
         this._toolbar_Main.ResumeLayout(false);
         this._toolbar_Main.PerformLayout();
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         this.splitContainer1.ResumeLayout(false);
         this._panel_FileTree.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip _menu_main;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _mi_NewFile;
      private System.Windows.Forms.ToolStripMenuItem _mi_OpenFile;
      private System.Windows.Forms.ToolStripMenuItem _mi_CloseFile;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem _mi_SaveFile;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripMenuItem _mi_Exit;
      private System.Windows.Forms.ToolStripMenuItem _mi_View;
      private System.Windows.Forms.ToolStripMenuItem _mi_Toolbar;
      private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _mi_VideoDevice;
      private System.Windows.Forms.ToolStripMenuItem _mi_AudioDevice;
      private System.Windows.Forms.ToolStripMenuItem captureToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _mi_captureProperties;
      private System.Windows.Forms.ToolStripMenuItem _mi_compressionSettings;
      private System.Windows.Forms.ToolStripMenuItem _mi_StartCaptureIntoDicomFile;
      private System.Windows.Forms.ToolStripMenuItem _mi_StopCapture;
      private System.Windows.Forms.ToolStripMenuItem _mi_About;
      private System.Windows.Forms.ToolStrip _toolbar_Main;
      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.ToolStripButton _tS_New;
      private System.Windows.Forms.ToolStripButton _tS_Open;
      private System.Windows.Forms.ToolStripButton _tS_Save;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripButton _tS_Help;
      private System.Windows.Forms.Panel _panel_FileTree;
      private System.Windows.Forms.Panel _panel_CapturePanel;
      private System.Windows.Forms.TreeView _treeView;
      private System.Windows.Forms.ToolStripProgressBar _tS_ProgressBar;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;

   }
}