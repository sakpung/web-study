namespace SharePointDemo
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
         this._fileOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._fileSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._fileExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewZoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewZoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._viewFitPageWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewFitPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._pagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._pagesPreviousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._pagesNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._interactiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._interactiveSelectModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._interactivePanModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._interactiveZoomToSelectionModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._sharePointServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._sharePointServerPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._sharePointServerRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._sharePointServerSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._sharePointServerUploadCurrentImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._helpAboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewerControl = new SharePointDemo.ViewerControl();
         this._serverControl = new SharePointDemo.ServerControl();
         this._verticalSplitter = new System.Windows.Forms.Splitter();
         this._mainMenuStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // _mainMenuStrip
         // 
         this._mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem,
            this._viewToolStripMenuItem,
            this._pagesToolStripMenuItem,
            this._interactiveToolStripMenuItem,
            this._sharePointServerToolStripMenuItem,
            this._helpToolStripMenuItem});
         this._mainMenuStrip.Location = new System.Drawing.Point(0, 0);
         this._mainMenuStrip.Name = "_mainMenuStrip";
         this._mainMenuStrip.Size = new System.Drawing.Size(802, 24);
         this._mainMenuStrip.TabIndex = 0;
         this._mainMenuStrip.Text = "menuStrip1";
         // 
         // _fileToolStripMenuItem
         // 
         this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileOpenToolStripMenuItem,
            this._fileSep1ToolStripMenuItem,
            this._fileExitToolStripMenuItem});
         this._fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
         this._fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
         this._fileToolStripMenuItem.Text = "&File";
         // 
         // _fileOpenToolStripMenuItem
         // 
         this._fileOpenToolStripMenuItem.Name = "_fileOpenToolStripMenuItem";
         this._fileOpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
         this._fileOpenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this._fileOpenToolStripMenuItem.Text = "&Open...";
         this._fileOpenToolStripMenuItem.Click += new System.EventHandler(this._fileOpenToolStripMenuItem_Click);
         // 
         // _fileSep1ToolStripMenuItem
         // 
         this._fileSep1ToolStripMenuItem.Name = "_fileSep1ToolStripMenuItem";
         this._fileSep1ToolStripMenuItem.Size = new System.Drawing.Size(149, 6);
         // 
         // _fileExitToolStripMenuItem
         // 
         this._fileExitToolStripMenuItem.Name = "_fileExitToolStripMenuItem";
         this._fileExitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this._fileExitToolStripMenuItem.Text = "E&xit";
         this._fileExitToolStripMenuItem.Click += new System.EventHandler(this._fileExitToolStripMenuItem_Click);
         // 
         // _viewToolStripMenuItem
         // 
         this._viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._viewZoomOutToolStripMenuItem,
            this._viewZoomInToolStripMenuItem,
            this._viewSep1ToolStripMenuItem,
            this._viewFitPageWidthToolStripMenuItem,
            this._viewFitPageToolStripMenuItem});
         this._viewToolStripMenuItem.Name = "_viewToolStripMenuItem";
         this._viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
         this._viewToolStripMenuItem.Text = "&View";
         this._viewToolStripMenuItem.DropDownOpening += new System.EventHandler(this._viewToolStripMenuItem_DropDownOpening);
         // 
         // _viewZoomOutToolStripMenuItem
         // 
         this._viewZoomOutToolStripMenuItem.Image = global::SharePointDemo.Properties.Resources.ZoomOut;
         this._viewZoomOutToolStripMenuItem.Name = "_viewZoomOutToolStripMenuItem";
         this._viewZoomOutToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
         this._viewZoomOutToolStripMenuItem.Text = "Zoom &out";
         this._viewZoomOutToolStripMenuItem.Click += new System.EventHandler(this._viewZoomOutToolStripMenuItem_Click);
         // 
         // _viewZoomInToolStripMenuItem
         // 
         this._viewZoomInToolStripMenuItem.Image = global::SharePointDemo.Properties.Resources.ZoomIn;
         this._viewZoomInToolStripMenuItem.Name = "_viewZoomInToolStripMenuItem";
         this._viewZoomInToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
         this._viewZoomInToolStripMenuItem.Text = "Zoom &in";
         this._viewZoomInToolStripMenuItem.Click += new System.EventHandler(this._viewZoomInToolStripMenuItem_Click);
         // 
         // _viewSep1ToolStripMenuItem
         // 
         this._viewSep1ToolStripMenuItem.Name = "_viewSep1ToolStripMenuItem";
         this._viewSep1ToolStripMenuItem.Size = new System.Drawing.Size(139, 6);
         // 
         // _viewFitPageWidthToolStripMenuItem
         // 
         this._viewFitPageWidthToolStripMenuItem.Image = global::SharePointDemo.Properties.Resources.FitPageWidth;
         this._viewFitPageWidthToolStripMenuItem.Name = "_viewFitPageWidthToolStripMenuItem";
         this._viewFitPageWidthToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
         this._viewFitPageWidthToolStripMenuItem.Text = "Fit page &width";
         this._viewFitPageWidthToolStripMenuItem.Click += new System.EventHandler(this._viewFitPageWidthToolStripMenuItem_Click);
         // 
         // _viewFitPageToolStripMenuItem
         // 
         this._viewFitPageToolStripMenuItem.Image = global::SharePointDemo.Properties.Resources.FitPage;
         this._viewFitPageToolStripMenuItem.Name = "_viewFitPageToolStripMenuItem";
         this._viewFitPageToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
         this._viewFitPageToolStripMenuItem.Text = "&Fit page";
         this._viewFitPageToolStripMenuItem.Click += new System.EventHandler(this._viewFitPageToolStripMenuItem_Click);
         // 
         // _pagesToolStripMenuItem
         // 
         this._pagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._pagesPreviousToolStripMenuItem,
            this._pagesNextToolStripMenuItem});
         this._pagesToolStripMenuItem.Name = "_pagesToolStripMenuItem";
         this._pagesToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
         this._pagesToolStripMenuItem.Text = "&Pages";
         this._pagesToolStripMenuItem.DropDownOpening += new System.EventHandler(this._pagesToolStripMenuItem_DropDownOpening);
         // 
         // _pagesPreviousToolStripMenuItem
         // 
         this._pagesPreviousToolStripMenuItem.Image = global::SharePointDemo.Properties.Resources.PreviousPage;
         this._pagesPreviousToolStripMenuItem.Name = "_pagesPreviousToolStripMenuItem";
         this._pagesPreviousToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
         this._pagesPreviousToolStripMenuItem.Text = "&Previous";
         this._pagesPreviousToolStripMenuItem.Click += new System.EventHandler(this._pagesPreviousToolStripMenuItem_Click);
         // 
         // _pagesNextToolStripMenuItem
         // 
         this._pagesNextToolStripMenuItem.Image = global::SharePointDemo.Properties.Resources.NextPage;
         this._pagesNextToolStripMenuItem.Name = "_pagesNextToolStripMenuItem";
         this._pagesNextToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
         this._pagesNextToolStripMenuItem.Text = "&Next";
         this._pagesNextToolStripMenuItem.Click += new System.EventHandler(this._pagesNextToolStripMenuItem_Click);
         // 
         // _interactiveToolStripMenuItem
         // 
         this._interactiveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._interactiveSelectModeToolStripMenuItem,
            this._interactivePanModeToolStripMenuItem,
            this._interactiveZoomToSelectionModeToolStripMenuItem});
         this._interactiveToolStripMenuItem.Name = "_interactiveToolStripMenuItem";
         this._interactiveToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
         this._interactiveToolStripMenuItem.Text = "&Interactive";
         this._interactiveToolStripMenuItem.DropDownOpening += new System.EventHandler(this._interactiveToolStripMenuItem_DropDownOpening);
         // 
         // _interactiveSelectModeToolStripMenuItem
         // 
         this._interactiveSelectModeToolStripMenuItem.Image = global::SharePointDemo.Properties.Resources.SelectMode;
         this._interactiveSelectModeToolStripMenuItem.Name = "_interactiveSelectModeToolStripMenuItem";
         this._interactiveSelectModeToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
         this._interactiveSelectModeToolStripMenuItem.Text = "&Select mode";
         this._interactiveSelectModeToolStripMenuItem.Click += new System.EventHandler(this._interactiveSelectModeToolStripMenuItem_Click);
         // 
         // _interactivePanModeToolStripMenuItem
         // 
         this._interactivePanModeToolStripMenuItem.Image = global::SharePointDemo.Properties.Resources.PanMode;
         this._interactivePanModeToolStripMenuItem.Name = "_interactivePanModeToolStripMenuItem";
         this._interactivePanModeToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
         this._interactivePanModeToolStripMenuItem.Text = "&Pan mode";
         this._interactivePanModeToolStripMenuItem.Click += new System.EventHandler(this._interactivePanModeToolStripMenuItem_Click);
         // 
         // _interactiveZoomToSelectionModeToolStripMenuItem
         // 
         this._interactiveZoomToSelectionModeToolStripMenuItem.Image = global::SharePointDemo.Properties.Resources.ZoomSelectionMode;
         this._interactiveZoomToSelectionModeToolStripMenuItem.Name = "_interactiveZoomToSelectionModeToolStripMenuItem";
         this._interactiveZoomToSelectionModeToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
         this._interactiveZoomToSelectionModeToolStripMenuItem.Text = "&Zoom to selection mode";
         this._interactiveZoomToSelectionModeToolStripMenuItem.Click += new System.EventHandler(this._interactiveZoomToSelectionModeToolStripMenuItem_Click);
         // 
         // _sharePointServerToolStripMenuItem
         // 
         this._sharePointServerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._sharePointServerPropertiesToolStripMenuItem,
            this._sharePointServerRefreshToolStripMenuItem,
            this._sharePointServerSep1ToolStripMenuItem,
            this._sharePointServerUploadCurrentImageToolStripMenuItem});
         this._sharePointServerToolStripMenuItem.Name = "_sharePointServerToolStripMenuItem";
         this._sharePointServerToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
         this._sharePointServerToolStripMenuItem.Text = "&SharePoint Server";
         this._sharePointServerToolStripMenuItem.DropDownOpening += new System.EventHandler(this._sharePointServerToolStripMenuItem_DropDownOpening);
         // 
         // _sharePointServerPropertiesToolStripMenuItem
         // 
         this._sharePointServerPropertiesToolStripMenuItem.Image = global::SharePointDemo.Properties.Resources.Server;
         this._sharePointServerPropertiesToolStripMenuItem.Name = "_sharePointServerPropertiesToolStripMenuItem";
         this._sharePointServerPropertiesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
         this._sharePointServerPropertiesToolStripMenuItem.Text = "&Properties...";
         this._sharePointServerPropertiesToolStripMenuItem.Click += new System.EventHandler(this._sharePointServerPropertiesToolStripMenuItem_Click);
         // 
         // _sharePointServerRefreshToolStripMenuItem
         // 
         this._sharePointServerRefreshToolStripMenuItem.Image = global::SharePointDemo.Properties.Resources.Refresh;
         this._sharePointServerRefreshToolStripMenuItem.Name = "_sharePointServerRefreshToolStripMenuItem";
         this._sharePointServerRefreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
         this._sharePointServerRefreshToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
         this._sharePointServerRefreshToolStripMenuItem.Text = "&Refresh";
         this._sharePointServerRefreshToolStripMenuItem.Click += new System.EventHandler(this._sharePointServerRefreshToolStripMenuItem_Click);
         // 
         // _sharePointServerSep1ToolStripMenuItem
         // 
         this._sharePointServerSep1ToolStripMenuItem.Name = "_sharePointServerSep1ToolStripMenuItem";
         this._sharePointServerSep1ToolStripMenuItem.Size = new System.Drawing.Size(185, 6);
         // 
         // _sharePointServerUploadCurrentImageToolStripMenuItem
         // 
         this._sharePointServerUploadCurrentImageToolStripMenuItem.Name = "_sharePointServerUploadCurrentImageToolStripMenuItem";
         this._sharePointServerUploadCurrentImageToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
         this._sharePointServerUploadCurrentImageToolStripMenuItem.Text = "&Upload current image...";
         this._sharePointServerUploadCurrentImageToolStripMenuItem.Click += new System.EventHandler(this._sharePointServerUploadCurrentImageToolStripMenuItem_Click);
         // 
         // _helpToolStripMenuItem
         // 
         this._helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._helpAboutToolStripMenuItem});
         this._helpToolStripMenuItem.Name = "_helpToolStripMenuItem";
         this._helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
         this._helpToolStripMenuItem.Text = "&Help";
         // 
         // _helpAboutToolStripMenuItem
         // 
         this._helpAboutToolStripMenuItem.Name = "_helpAboutToolStripMenuItem";
         this._helpAboutToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
         this._helpAboutToolStripMenuItem.Text = "&About...";
         this._helpAboutToolStripMenuItem.Click += new System.EventHandler(this._helpAboutToolStripMenuItem_Click);
         // 
         // _viewerControl
         // 
         this._viewerControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this._viewerControl.Location = new System.Drawing.Point(304, 24);
         this._viewerControl.Name = "_viewerControl";
         this._viewerControl.RasterImage = null;
         this._viewerControl.Size = new System.Drawing.Size(498, 508);
         this._viewerControl.TabIndex = 2;
         this._viewerControl.OpenFileClicked += new System.EventHandler<System.EventArgs>(this._viewerControl_OpenFileClicked);
         this._viewerControl.UploadClicked += new System.EventHandler<System.EventArgs>(this._viewerControl_UploadClicked);
         // 
         // _serverControl
         // 
         this._serverControl.Dock = System.Windows.Forms.DockStyle.Left;
         this._serverControl.Location = new System.Drawing.Point(0, 24);
         this._serverControl.Name = "_serverControl";
         this._serverControl.Size = new System.Drawing.Size(304, 508);
         this._serverControl.TabIndex = 3;
         this._serverControl.RefreshClicked += new System.EventHandler<System.EventArgs>(this._serverControl_RefreshClicked);
         this._serverControl.DownloadClicked += new System.EventHandler<System.EventArgs>(this._serverControl_DownloadClicked);
         this._serverControl.ServerClicked += new System.EventHandler<System.EventArgs>(this._serverControl_ServerClicked);
         // 
         // _verticalSplitter
         // 
         this._verticalSplitter.Location = new System.Drawing.Point(304, 24);
         this._verticalSplitter.Name = "_verticalSplitter";
         this._verticalSplitter.Size = new System.Drawing.Size(3, 508);
         this._verticalSplitter.TabIndex = 4;
         this._verticalSplitter.TabStop = false;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(802, 532);
         this.Controls.Add(this._verticalSplitter);
         this.Controls.Add(this._viewerControl);
         this.Controls.Add(this._serverControl);
         this.Controls.Add(this._mainMenuStrip);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this._mainMenuStrip;
         this.Name = "MainForm";
         this.Text = "MainForm";
         this._mainMenuStrip.ResumeLayout(false);
         this._mainMenuStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip _mainMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fileExitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _helpToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _helpAboutToolStripMenuItem;
      private ViewerControl _viewerControl;
      private System.Windows.Forms.ToolStripMenuItem _viewToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewZoomInToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewZoomOutToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _viewSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewFitPageWidthToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewFitPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _pagesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _pagesNextToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _pagesPreviousToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _interactiveToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _interactiveSelectModeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _interactivePanModeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _interactiveZoomToSelectionModeToolStripMenuItem;
      private ServerControl _serverControl;
      private System.Windows.Forms.ToolStripMenuItem _sharePointServerToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _sharePointServerPropertiesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _sharePointServerRefreshToolStripMenuItem;
      private System.Windows.Forms.Splitter _verticalSplitter;
      private System.Windows.Forms.ToolStripMenuItem _fileOpenToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _fileSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _sharePointServerSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _sharePointServerUploadCurrentImageToolStripMenuItem;
   }
}

