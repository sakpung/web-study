namespace PDFFormsDemo
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this._mmMain = new System.Windows.Forms.MainMenu(this.components);
         this._miFile = new System.Windows.Forms.MenuItem();
         this._miFileOpen = new System.Windows.Forms.MenuItem();
         this._miFileLoadDataFromXML = new System.Windows.Forms.MenuItem();
         this._miFileSaveDataToXML = new System.Windows.Forms.MenuItem();
         this._miFileSep1 = new System.Windows.Forms.MenuItem();
         this._miFilePrint = new System.Windows.Forms.MenuItem();
         this._miFileSep2 = new System.Windows.Forms.MenuItem();
         this._miFileClose = new System.Windows.Forms.MenuItem();
         this._miFileExit = new System.Windows.Forms.MenuItem();
         this._miView = new System.Windows.Forms.MenuItem();
         this._miViewSizeMode = new System.Windows.Forms.MenuItem();
         this._miViewSizeModeActualSize = new System.Windows.Forms.MenuItem();
         this._miViewSizeModeStretch = new System.Windows.Forms.MenuItem();
         this._miViewSizeModeFitAlways = new System.Windows.Forms.MenuItem();
         this._miViewSizeModeFitWidth = new System.Windows.Forms.MenuItem();
         this._miViewSizeModeFit = new System.Windows.Forms.MenuItem();
         this._miViewSizeModeFitHeight = new System.Windows.Forms.MenuItem();
         this._miViewZoom = new System.Windows.Forms.MenuItem();
         this._miViewZoom25 = new System.Windows.Forms.MenuItem();
         this._miViewZoom50 = new System.Windows.Forms.MenuItem();
         this._miViewZoom75 = new System.Windows.Forms.MenuItem();
         this._miViewZoom100 = new System.Windows.Forms.MenuItem();
         this._miViewZoom125 = new System.Windows.Forms.MenuItem();
         this._miViewZoom150 = new System.Windows.Forms.MenuItem();
         this._miViewZoom200 = new System.Windows.Forms.MenuItem();
         this._miViewUseSVGMode = new System.Windows.Forms.MenuItem();
         this._miMultiPage = new System.Windows.Forms.MenuItem();
         this._miMultiPageFirst = new System.Windows.Forms.MenuItem();
         this._miMultiPagePrevious = new System.Windows.Forms.MenuItem();
         this._miMultiPageNext = new System.Windows.Forms.MenuItem();
         this._miMultiPageLast = new System.Windows.Forms.MenuItem();
         this._miMultiPageSep = new System.Windows.Forms.MenuItem();
         this._miMultiPageGoto = new System.Windows.Forms.MenuItem();
         this._miHelp = new System.Windows.Forms.MenuItem();
         this._miHelpAbout = new System.Windows.Forms.MenuItem();
         this._imageViewer = new Leadtools.Controls.ImageViewer();
         this._imageViewerPanel = new System.Windows.Forms.Panel();
         this._imageList = new Leadtools.Controls.ImageViewer();
         this._imageListPanel = new System.Windows.Forms.Panel();
         this._mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
         this._formFieldToolTip = new System.Windows.Forms.ToolTip(this.components);
         this._formFieldContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
         this._propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._mainTableLayoutPanel.SuspendLayout();
         this.SuspendLayout();
         // 
         // _mmMain
         // 
         this._mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFile,
            this._miView,
            this._miMultiPage,
            this._miHelp});
         // 
         // _miFile
         // 
         this._miFile.Index = 0;
         this._miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFileOpen,
            this._miFileLoadDataFromXML,
            this._miFileSaveDataToXML,
            this._miFileSep1,
            this._miFilePrint,
            this._miFileSep2,
            this._miFileClose,
            this._miFileExit});
         this._miFile.Text = "&File";
         // 
         // _miFileOpen
         // 
         this._miFileOpen.Index = 0;
         this._miFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
         this._miFileOpen.Text = "&Open PDF...";
         this._miFileOpen.Click += new System.EventHandler(this._miFileOpen_Click);
         // 
         // _miFileLoadDataFromXML
         // 
         this._miFileLoadDataFromXML.Index = 1;
         this._miFileLoadDataFromXML.Shortcut = System.Windows.Forms.Shortcut.CtrlL;
         this._miFileLoadDataFromXML.Text = "&Load Data From XML...";
         this._miFileLoadDataFromXML.Click += new System.EventHandler(this._miFileLoadDataFromXML_Click);
         // 
         // _miFileSaveDataToXML
         // 
         this._miFileSaveDataToXML.Index = 2;
         this._miFileSaveDataToXML.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
         this._miFileSaveDataToXML.Text = "&Save Data To XML...";
         this._miFileSaveDataToXML.Click += new System.EventHandler(this._miFileSaveDataToXML_Click);
         // 
         // _miFileSep
         // 
         this._miFileSep1.Index = 3;
         this._miFileSep1.Text = "-";
         // 
         // _miFilePrint
         // 
         this._miFilePrint.Index = 4;
         this._miFilePrint.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
         this._miFilePrint.Text = "&Print";
         this._miFilePrint.Click += new System.EventHandler(this._miFilePrint_Click);
         // 
         // _miFileSep2
         // 
         this._miFileSep2.Index = 5;
         this._miFileSep2.Text = "-";
         // 
         // _miFileClose
         // 
         this._miFileClose.Index = 6;
         this._miFileClose.Text = "&Close";
         this._miFileClose.Click += new System.EventHandler(this._miFileClose_Click);
         // 
         // _miFileExit
         // 
         this._miFileExit.Index = 7;
         this._miFileExit.Text = "E&xit";
         this._miFileExit.Click += new System.EventHandler(this._miFileExit_Click);
         // 
         // _miView
         // 
         this._miView.Index = 1;
         this._miView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miViewSizeMode,
            this._miViewZoom,
            this._miViewUseSVGMode});
         this._miView.Text = "&View";
         // 
         // _miViewSizeMode
         // 
         this._miViewSizeMode.Index = 0;
         this._miViewSizeMode.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miViewSizeModeActualSize,
            this._miViewSizeModeStretch,
            this._miViewSizeModeFitAlways,
            this._miViewSizeModeFitWidth,
            this._miViewSizeModeFit,
            this._miViewSizeModeFitHeight});
         this._miViewSizeMode.Text = "&Size Mode";
         // 
         // _miViewSizeModeActualSize
         // 
         this._miViewSizeModeActualSize.Index = 0;
         this._miViewSizeModeActualSize.Text = "&ActualSize";
         this._miViewSizeModeActualSize.Click += new System.EventHandler(this._miViewSizeMode_Click);
         // 
         // _miViewSizeModeStretch
         // 
         this._miViewSizeModeStretch.Index = 1;
         this._miViewSizeModeStretch.Text = "&Stretch";
         this._miViewSizeModeStretch.Click += new System.EventHandler(this._miViewSizeMode_Click);
         // 
         // _miViewSizeModeFitAlways
         // 
         this._miViewSizeModeFitAlways.Index = 2;
         this._miViewSizeModeFitAlways.Text = "Fit &Always";
         this._miViewSizeModeFitAlways.Click += new System.EventHandler(this._miViewSizeMode_Click);
         // 
         // _miViewSizeModeFitWidth
         // 
         this._miViewSizeModeFitWidth.Index = 3;
         this._miViewSizeModeFitWidth.Text = "Fit &Width";
         this._miViewSizeModeFitWidth.Click += new System.EventHandler(this._miViewSizeMode_Click);
         // 
         // _miViewSizeModeFit
         // 
         this._miViewSizeModeFit.Index = 4;
         this._miViewSizeModeFit.Text = "&Fit";
         this._miViewSizeModeFit.Click += new System.EventHandler(this._miViewSizeMode_Click);
         // 
         // _miViewSizeModeFitHeight
         // 
         this._miViewSizeModeFitHeight.Index = 5;
         this._miViewSizeModeFitHeight.Text = "&FitHeight";
         this._miViewSizeModeFitHeight.Click += new System.EventHandler(this._miViewSizeMode_Click);
         // 
         // _miViewZoom
         // 
         this._miViewZoom.Index = 1;
         this._miViewZoom.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miViewZoom25,
            this._miViewZoom50,
            this._miViewZoom75,
            this._miViewZoom100,
            this._miViewZoom125,
            this._miViewZoom150,
            this._miViewZoom200});
         this._miViewZoom.Text = "&Zoom";
         // 
         // _miViewZoom25
         // 
         this._miViewZoom25.Index = 0;
         this._miViewZoom25.Text = "25%";
         this._miViewZoom25.Click += new System.EventHandler(this._miViewZoom_Click);
         // 
         // _miViewZoom50
         // 
         this._miViewZoom50.Index = 1;
         this._miViewZoom50.Text = "50%";
         this._miViewZoom50.Click += new System.EventHandler(this._miViewZoom_Click);
         // 
         // _miViewZoom75
         // 
         this._miViewZoom75.Index = 2;
         this._miViewZoom75.Text = "75%";
         this._miViewZoom75.Click += new System.EventHandler(this._miViewZoom_Click);
         // 
         // _miViewZoom100
         // 
         this._miViewZoom100.Index = 3;
         this._miViewZoom100.Text = "100%";
         this._miViewZoom100.Click += new System.EventHandler(this._miViewZoom_Click);
         // 
         // _miViewZoom125
         // 
         this._miViewZoom125.Index = 4;
         this._miViewZoom125.Text = "125%";
         this._miViewZoom125.Click += new System.EventHandler(this._miViewZoom_Click);
         // 
         // _miViewZoom150
         // 
         this._miViewZoom150.Index = 5;
         this._miViewZoom150.Text = "150%";
         this._miViewZoom150.Click += new System.EventHandler(this._miViewZoom_Click);
         // 
         // _miViewZoom200
         // 
         this._miViewZoom200.Index = 6;
         this._miViewZoom200.Text = "200%";
         this._miViewZoom200.Click += new System.EventHandler(this._miViewZoom_Click);
         // 
         // _miViewUseSVGMode
         // 
         this._miViewUseSVGMode.Index = 2;
         this._miViewUseSVGMode.Text = "Use SVG &Mode";
         this._miViewUseSVGMode.Click += new System.EventHandler(this._miViewSVGMode_Click);
         // 
         // _miMultiPage
         // 
         this._miMultiPage.Index = 2;
         this._miMultiPage.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miMultiPageFirst,
            this._miMultiPagePrevious,
            this._miMultiPageNext,
            this._miMultiPageLast,
            this._miMultiPageSep,
            this._miMultiPageGoto});
         this._miMultiPage.Text = "&Multi-Page";
         // 
         // _miMultiPageFirst
         // 
         this._miMultiPageFirst.Index = 0;
         this._miMultiPageFirst.Text = "First";
         this._miMultiPageFirst.Click += new System.EventHandler(this._miMultiPage_Click);
         // 
         // _miMultiPagePrevious
         // 
         this._miMultiPagePrevious.Index = 1;
         this._miMultiPagePrevious.Text = "Previous";
         this._miMultiPagePrevious.Click += new System.EventHandler(this._miMultiPage_Click);
         // 
         // _miMultiPageNext
         // 
         this._miMultiPageNext.Index = 2;
         this._miMultiPageNext.Text = "Next";
         this._miMultiPageNext.Click += new System.EventHandler(this._miMultiPage_Click);
         // 
         // _miMultiPageLast
         // 
         this._miMultiPageLast.Index = 3;
         this._miMultiPageLast.Text = "Last";
         this._miMultiPageLast.Click += new System.EventHandler(this._miMultiPage_Click);
         // 
         // _miMultiPageSep
         // 
         this._miMultiPageSep.Index = 4;
         this._miMultiPageSep.Text = "-";
         // 
         // _miMultiPageGoto
         // 
         this._miMultiPageGoto.Index = 5;
         this._miMultiPageGoto.Text = "Go To Page";
         this._miMultiPageGoto.Click += new System.EventHandler(this._miMultiPage_Click);
         // 
         // _miHelp
         // 
         this._miHelp.Index = 3;
         this._miHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miHelpAbout});
         this._miHelp.Text = "&Help";
         // 
         // _miHelpAbout
         // 
         this._miHelpAbout.Index = 0;
         this._miHelpAbout.Text = "&About...";
         this._miHelpAbout.Click += new System.EventHandler(this._miHelpAbout_Click);
         // 
         // _imageViewer
         // 
         this._imageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
         this._imageViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._imageViewer.BackColor = System.Drawing.SystemColors.InactiveCaption;
         this._imageViewer.ImageBackgroundColor = System.Drawing.Color.White;
         this._imageViewer.AutoDisposeImages = false;
         this._imageViewer.ViewHorizontalAlignment = Leadtools.Controls.ControlAlignment.Center;
         this._imageViewer.ViewVerticalAlignment = Leadtools.Controls.ControlAlignment.Center;
         this._imageViewer.UseDpi = true;
         this._imageViewer.Zoom(Leadtools.Controls.ControlSizeMode.ActualSize, 1, _imageViewer.DefaultZoomOrigin);
         this._imageViewer.PostRender += _imageViewer_PostRender;
         this._imageViewer.TransformChanged += _imageViewer_TransformChanged;
         this._imageViewer.LostFocus += _imageViewer_LostFocus;
         // 
         // _imageViewerPanel
         // 
         this._imageViewerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this._imageViewerPanel.Location = new System.Drawing.Point(153, 3);
         this._imageViewerPanel.Name = "_imageViewerPanel";
         this._imageViewerPanel.Size = new System.Drawing.Size(544, 379);
         this._imageViewerPanel.Margin = new System.Windows.Forms.Padding(0);
         this._imageViewerPanel.TabIndex = 0;
         this._imageViewerPanel.Controls.Add(_imageViewer);
         // 
         // _imageList
         // 
         this._imageList.ViewLayout = new Leadtools.Controls.ImageViewerVerticalViewLayout() { Columns = 1 };
         this._imageList.Dock = System.Windows.Forms.DockStyle.Fill;
         this._imageList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._imageList.BackColor = System.Drawing.SystemColors.ActiveCaption;
         this._imageList.ImageBackgroundColor = System.Drawing.Color.White;
         this._imageList.ViewHorizontalAlignment = Leadtools.Controls.ControlAlignment.Center;
         this._imageList.UseDpi = true;
         this._imageList.ItemSize = new Leadtools.LeadSize(100, 120);
         this._imageList.ItemSpacing = new Leadtools.LeadSize(20, 20);
         this._imageList.SelectedItemBorderColor = System.Drawing.Color.Blue;
         this._imageList.ItemBorderThickness = 2;
         this._imageList.ItemSizeMode = Leadtools.Controls.ControlSizeMode.Fit;
         this._imageList.InteractiveModes.Add(new Leadtools.Controls.ImageViewerSelectItemsInteractiveMode() { SelectionMode = Leadtools.Controls.ImageViewerSelectionMode.Single });
         this._imageList.Items.Clear();
         this._imageList.SelectedItemsChanged += _imageList_SelectedItemsChanged;
         // 
         // _imageListPanel
         // 
         this._imageListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this._imageListPanel.Location = new System.Drawing.Point(3, 3);
         this._imageListPanel.Name = "_imageListPanel";
         this._imageListPanel.Size = new System.Drawing.Size(144, 379);
         this._imageListPanel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
         this._imageListPanel.TabIndex = 1;
         this._imageListPanel.Controls.Add(_imageList);
         // 
         // _mainTableLayoutPanel
         // 
         this._mainTableLayoutPanel.ColumnCount = 2;
         this._mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
         this._mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this._mainTableLayoutPanel.Controls.Add(this._imageViewerPanel, 1, 0);
         this._mainTableLayoutPanel.Controls.Add(this._imageListPanel, 0, 0);
         this._mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this._mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
         this._mainTableLayoutPanel.Name = "_mainTableLayoutPanel";
         this._mainTableLayoutPanel.RowCount = 1;
         this._mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this._mainTableLayoutPanel.Size = new System.Drawing.Size(700, 385);
         this._mainTableLayoutPanel.TabIndex = 2;
         // 
         // _formFieldToolTip
         // 
         this._formFieldToolTip.ShowAlways = true;
         // 
         // _formFieldContextMenu
         // 
         this._formFieldContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._propertiesToolStripMenuItem});
         this._formFieldContextMenu.Name = "_formFieldContextMenu";
         this._formFieldContextMenu.Size = new System.Drawing.Size(153, 48);
         // 
         // _propertiesToolStripMenuItem
         // 
         this._propertiesToolStripMenuItem.Name = "_propertiesToolStripMenuItem";
         this._propertiesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this._propertiesToolStripMenuItem.Text = "Properties";
         this._propertiesToolStripMenuItem.Click += _propertiesToolStripMenuItem_Click;
         // 
         // MainForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(700, 385);
         this.Controls.Add(this._mainTableLayoutPanel);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Menu = this._mmMain;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this._mainTableLayoutPanel.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.MainMenu _mmMain;
      private System.Windows.Forms.MenuItem _miFile;
      private System.Windows.Forms.MenuItem _miFileOpen;
      private System.Windows.Forms.MenuItem _miFileLoadDataFromXML;
      private System.Windows.Forms.MenuItem _miFileSaveDataToXML;
      private System.Windows.Forms.MenuItem _miFileSep1;
      private System.Windows.Forms.MenuItem _miFilePrint;
      private System.Windows.Forms.MenuItem _miFileSep2;
      private System.Windows.Forms.MenuItem _miFileClose;
      private System.Windows.Forms.MenuItem _miFileExit;
      private System.Windows.Forms.MenuItem _miHelp;
      private System.Windows.Forms.MenuItem _miHelpAbout;
      private System.Windows.Forms.Panel _imageViewerPanel;
      private System.Windows.Forms.Panel _imageListPanel;
      private Leadtools.Controls.ImageViewer _imageList;
      private Leadtools.Controls.ImageViewer _imageViewer;
      private System.Windows.Forms.TableLayoutPanel _mainTableLayoutPanel;
      private System.Windows.Forms.ToolTip _formFieldToolTip;
      private System.Windows.Forms.ContextMenuStrip _formFieldContextMenu;
      private System.Windows.Forms.ToolStripMenuItem _propertiesToolStripMenuItem;
      private System.Windows.Forms.MenuItem _miView;
      private System.Windows.Forms.MenuItem _miViewSizeMode;
      private System.Windows.Forms.MenuItem _miViewSizeModeActualSize;
      private System.Windows.Forms.MenuItem _miViewSizeModeStretch;
      private System.Windows.Forms.MenuItem _miViewSizeModeFitAlways;
      private System.Windows.Forms.MenuItem _miViewSizeModeFitWidth;
      private System.Windows.Forms.MenuItem _miViewSizeModeFit;
      private System.Windows.Forms.MenuItem _miViewSizeModeFitHeight;
      private System.Windows.Forms.MenuItem _miViewZoom;
      private System.Windows.Forms.MenuItem _miViewZoom25;
      private System.Windows.Forms.MenuItem _miViewZoom50;
      private System.Windows.Forms.MenuItem _miViewZoom75;
      private System.Windows.Forms.MenuItem _miViewZoom100;
      private System.Windows.Forms.MenuItem _miViewZoom125;
      private System.Windows.Forms.MenuItem _miViewZoom150;
      private System.Windows.Forms.MenuItem _miViewZoom200;
      private System.Windows.Forms.MenuItem _miViewUseSVGMode;
      private System.Windows.Forms.MenuItem _miMultiPage;
      private System.Windows.Forms.MenuItem _miMultiPageFirst;
      private System.Windows.Forms.MenuItem _miMultiPagePrevious;
      private System.Windows.Forms.MenuItem _miMultiPageNext;
      private System.Windows.Forms.MenuItem _miMultiPageLast;
      private System.Windows.Forms.MenuItem _miMultiPageSep;
      private System.Windows.Forms.MenuItem _miMultiPageGoto;
   }
}