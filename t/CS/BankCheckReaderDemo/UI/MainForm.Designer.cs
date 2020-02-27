namespace CSBankCheckReader
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
         this._splMain = new System.Windows.Forms.SplitContainer();
         this.dataGridView1 = new System.Windows.Forms.DataGridView();
         this._fieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this._value = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this._splViewerList = new System.Windows.Forms.SplitContainer();
         this.rasterImageViewer1 = new Leadtools.Controls.ImageViewer();
         this._tsViewer = new System.Windows.Forms.ToolStrip();
         this._btnPanTool = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
         this._btnZoomNormal = new System.Windows.Forms.ToolStripButton();
         this._btnFit = new System.Windows.Forms.ToolStripButton();
         this._btnFitWidth = new System.Windows.Forms.ToolStripButton();
         this._btnZoomIn = new System.Windows.Forms.ToolStripButton();
         this._btnZoomOut = new System.Windows.Forms.ToolStripButton();
         this._btnZoomDrawTool = new System.Windows.Forms.ToolStripButton();
         this._btnUseDpi = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.imageViewerField = new Leadtools.Controls.ImageViewer();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemEngine = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemLanguages = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemComponents = new System.Windows.Forms.ToolStripMenuItem();
         this.micrFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._miFontUnknown = new System.Windows.Forms.ToolStripMenuItem();
         this._miFontE13B = new System.Windows.Forms.ToolStripMenuItem();
         this._miFontCMC7 = new System.Windows.Forms.ToolStripMenuItem();
         this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemHowTo = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
         ((System.ComponentModel.ISupportInitialize)(this._splMain)).BeginInit();
         this._splMain.Panel1.SuspendLayout();
         this._splMain.Panel2.SuspendLayout();
         this._splMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._splViewerList)).BeginInit();
         this._splViewerList.Panel1.SuspendLayout();
         this._splViewerList.Panel2.SuspendLayout();
         this._splViewerList.SuspendLayout();
         this._tsViewer.SuspendLayout();
         this.menuStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // _splMain
         // 
         this._splMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._splMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this._splMain.Location = new System.Drawing.Point(0, 24);
         this._splMain.Name = "_splMain";
         // 
         // _splMain.Panel1
         // 
         this._splMain.Panel1.Controls.Add(this.dataGridView1);
         this._splMain.Panel1MinSize = 484;
         // 
         // _splMain.Panel2
         // 
         this._splMain.Panel2.Controls.Add(this._splViewerList);
         this._splMain.Size = new System.Drawing.Size(1197, 721);
         this._splMain.SplitterDistance = 484;
         this._splMain.TabIndex = 3;
         // 
         // dataGridView1
         // 
         this.dataGridView1.AllowUserToAddRows = false;
         this.dataGridView1.AllowUserToDeleteRows = false;
         this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._fieldName,
            this._value});
         this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridView1.Location = new System.Drawing.Point(0, 0);
         this.dataGridView1.Name = "dataGridView1";
         this.dataGridView1.Size = new System.Drawing.Size(480, 717);
         this.dataGridView1.TabIndex = 0;
         this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
         // 
         // _fieldName
         // 
         this._fieldName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
         this._fieldName.Frozen = true;
         this._fieldName.HeaderText = "Field Name";
         this._fieldName.Name = "_fieldName";
         this._fieldName.ReadOnly = true;
         this._fieldName.Width = 85;
         // 
         // _value
         // 
         this._value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
         this._value.Frozen = true;
         this._value.HeaderText = "Value";
         this._value.Name = "_value";
         this._value.ReadOnly = true;
         this._value.Width = 59;
         // 
         // _splViewerList
         // 
         this._splViewerList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._splViewerList.Dock = System.Windows.Forms.DockStyle.Fill;
         this._splViewerList.Location = new System.Drawing.Point(0, 0);
         this._splViewerList.Name = "_splViewerList";
         this._splViewerList.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // _splViewerList.Panel1
         // 
         this._splViewerList.Panel1.Controls.Add(this.rasterImageViewer1);
         this._splViewerList.Panel1.Controls.Add(this._tsViewer);
         // 
         // _splViewerList.Panel2
         // 
         this._splViewerList.Panel2.Controls.Add(this.imageViewerField);
         this._splViewerList.Size = new System.Drawing.Size(709, 721);
         this._splViewerList.SplitterDistance = 464;
         this._splViewerList.TabIndex = 0;
         // 
         // rasterImageViewer1
         // 
         this.rasterImageViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.rasterImageViewer1.ImageHorizontalAlignment = Leadtools.Controls.ControlAlignment.Near;
         this.rasterImageViewer1.ImageVerticalAlignment = Leadtools.Controls.ControlAlignment.Near;
         this.rasterImageViewer1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.rasterImageViewer1.IsSyncSource = true;
         this.rasterImageViewer1.IsSyncTarget = true;
         this.rasterImageViewer1.ItemPadding = new System.Windows.Forms.Padding(1);
         this.rasterImageViewer1.Location = new System.Drawing.Point(0, 53);
         this.rasterImageViewer1.Name = "rasterImageViewer1";
         this.rasterImageViewer1.Size = new System.Drawing.Size(705, 407);
         this.rasterImageViewer1.TabIndex = 5;
         this.rasterImageViewer1.UseDpi = true;
         // 
         // _tsViewer
         // 
         this._tsViewer.ImageScalingSize = new System.Drawing.Size(20, 20);
         this._tsViewer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnPanTool,
            this.toolStripSeparator7,
            this._btnZoomNormal,
            this._btnFit,
            this._btnFitWidth,
            this._btnZoomIn,
            this._btnZoomOut,
            this._btnZoomDrawTool,
            this._btnUseDpi,
            this.toolStripSeparator2});
         this._tsViewer.Location = new System.Drawing.Point(0, 0);
         this._tsViewer.Name = "_tsViewer";
         this._tsViewer.RightToLeft = System.Windows.Forms.RightToLeft.No;
         this._tsViewer.Size = new System.Drawing.Size(705, 53);
         this._tsViewer.TabIndex = 4;
         this._tsViewer.Text = "toolStrip2";
         // 
         // _btnPanTool
         // 
         this._btnPanTool.AutoSize = false;
         this._btnPanTool.CheckOnClick = true;
         this._btnPanTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnPanTool.Image = ((System.Drawing.Image)(resources.GetObject("_btnPanTool.Image")));
         this._btnPanTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnPanTool.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnPanTool.Name = "_btnPanTool";
         this._btnPanTool.Size = new System.Drawing.Size(50, 50);
         this._btnPanTool.Text = "Pan";
         this._btnPanTool.Click += new System.EventHandler(this._btnPanTool_Click);
         // 
         // toolStripSeparator7
         // 
         this.toolStripSeparator7.Name = "toolStripSeparator7";
         this.toolStripSeparator7.Size = new System.Drawing.Size(6, 53);
         // 
         // _btnZoomNormal
         // 
         this._btnZoomNormal.AutoSize = false;
         this._btnZoomNormal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnZoomNormal.Image = ((System.Drawing.Image)(resources.GetObject("_btnZoomNormal.Image")));
         this._btnZoomNormal.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnZoomNormal.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnZoomNormal.Name = "_btnZoomNormal";
         this._btnZoomNormal.Size = new System.Drawing.Size(50, 50);
         this._btnZoomNormal.Text = "Normal";
         this._btnZoomNormal.Click += new System.EventHandler(this._btnZoomNormal_Click);
         // 
         // _btnFit
         // 
         this._btnFit.AutoSize = false;
         this._btnFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnFit.Image = ((System.Drawing.Image)(resources.GetObject("_btnFit.Image")));
         this._btnFit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnFit.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnFit.Name = "_btnFit";
         this._btnFit.Size = new System.Drawing.Size(50, 50);
         this._btnFit.Text = "Fit To Window";
         this._btnFit.Click += new System.EventHandler(this._btnFit_Click);
         // 
         // _btnFitWidth
         // 
         this._btnFitWidth.AutoSize = false;
         this._btnFitWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnFitWidth.Image = ((System.Drawing.Image)(resources.GetObject("_btnFitWidth.Image")));
         this._btnFitWidth.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnFitWidth.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnFitWidth.Name = "_btnFitWidth";
         this._btnFitWidth.Size = new System.Drawing.Size(50, 50);
         this._btnFitWidth.Text = "Fit To Image Width";
         this._btnFitWidth.Click += new System.EventHandler(this._btnFitWidth_Click);
         // 
         // _btnZoomIn
         // 
         this._btnZoomIn.AutoSize = false;
         this._btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("_btnZoomIn.Image")));
         this._btnZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnZoomIn.Name = "_btnZoomIn";
         this._btnZoomIn.Size = new System.Drawing.Size(50, 50);
         this._btnZoomIn.Text = "Zoom In";
         this._btnZoomIn.Click += new System.EventHandler(this._btnZoomIn_Click);
         // 
         // _btnZoomOut
         // 
         this._btnZoomOut.AutoSize = false;
         this._btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("_btnZoomOut.Image")));
         this._btnZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnZoomOut.Name = "_btnZoomOut";
         this._btnZoomOut.Size = new System.Drawing.Size(50, 50);
         this._btnZoomOut.Text = "Zoom Out";
         this._btnZoomOut.Click += new System.EventHandler(this._btnZoomOut_Click);
         // 
         // _btnZoomDrawTool
         // 
         this._btnZoomDrawTool.AutoSize = false;
         this._btnZoomDrawTool.CheckOnClick = true;
         this._btnZoomDrawTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnZoomDrawTool.Image = ((System.Drawing.Image)(resources.GetObject("_btnZoomDrawTool.Image")));
         this._btnZoomDrawTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnZoomDrawTool.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnZoomDrawTool.Name = "_btnZoomDrawTool";
         this._btnZoomDrawTool.Size = new System.Drawing.Size(50, 50);
         this._btnZoomDrawTool.Text = "Zoom To Selection";
         this._btnZoomDrawTool.Click += new System.EventHandler(this._btnZoomDrawTool_Click);
         // 
         // _btnUseDpi
         // 
         this._btnUseDpi.AutoSize = false;
         this._btnUseDpi.Checked = true;
         this._btnUseDpi.CheckOnClick = true;
         this._btnUseDpi.CheckState = System.Windows.Forms.CheckState.Checked;
         this._btnUseDpi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnUseDpi.Image = ((System.Drawing.Image)(resources.GetObject("_btnUseDpi.Image")));
         this._btnUseDpi.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnUseDpi.ImageTransparentColor = System.Drawing.Color.Black;
         this._btnUseDpi.Margin = new System.Windows.Forms.Padding(0);
         this._btnUseDpi.Name = "_btnUseDpi";
         this._btnUseDpi.Size = new System.Drawing.Size(50, 50);
         this._btnUseDpi.Text = "toolStripButton1";
         this._btnUseDpi.ToolTipText = "Ignore Image DPI When Viewing";
         this._btnUseDpi.Click += new System.EventHandler(this._btnUseDpi_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(6, 53);
         // 
         // imageViewerField
         // 
         this.imageViewerField.Dock = System.Windows.Forms.DockStyle.Fill;
         this.imageViewerField.IsSyncSource = true;
         this.imageViewerField.IsSyncTarget = true;
         this.imageViewerField.ItemHorizontalAlignment = Leadtools.Controls.ControlAlignment.Near;
         this.imageViewerField.ItemPadding = new System.Windows.Forms.Padding(1);
         this.imageViewerField.ItemVerticalAlignment = Leadtools.Controls.ControlAlignment.Near;
         this.imageViewerField.Location = new System.Drawing.Point(0, 0);
         this.imageViewerField.Name = "imageViewerField";
         this.imageViewerField.Size = new System.Drawing.Size(705, 249);
         this.imageViewerField.TabIndex = 4;
         this.imageViewerField.UseDpi = true;
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this._menuItemEngine,
            this.helpToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(1197, 24);
         this.menuStrip1.TabIndex = 4;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "File";
         // 
         // openToolStripMenuItem
         // 
         this.openToolStripMenuItem.Name = "openToolStripMenuItem";
         this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
         this.openToolStripMenuItem.Text = "Open";
         this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
         // 
         // closeToolStripMenuItem
         // 
         this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
         this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
         this.closeToolStripMenuItem.Text = "Close";
         this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
         this.exitToolStripMenuItem.Text = "Exit";
         this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
         // 
         // _menuItemEngine
         // 
         this._menuItemEngine.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemLanguages,
            this._menuItemComponents,
            this.micrFontToolStripMenuItem});
         this._menuItemEngine.Name = "_menuItemEngine";
         this._menuItemEngine.Size = new System.Drawing.Size(55, 20);
         this._menuItemEngine.Text = "Engine";
         // 
         // _menuItemLanguages
         // 
         this._menuItemLanguages.Name = "_menuItemLanguages";
         this._menuItemLanguages.Size = new System.Drawing.Size(152, 22);
         this._menuItemLanguages.Text = "Languages";
         this._menuItemLanguages.Click += new System.EventHandler(this._menuItemLanguages_Click);
         // 
         // _menuItemComponents
         // 
         this._menuItemComponents.Name = "_menuItemComponents";
         this._menuItemComponents.Size = new System.Drawing.Size(152, 22);
         this._menuItemComponents.Text = "Components";
         this._menuItemComponents.Click += new System.EventHandler(this._menuItemComponents_Click);
         // 
         // micrFontToolStripMenuItem
         // 
         this.micrFontToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miFontUnknown,
            this._miFontE13B,
            this._miFontCMC7});
         this.micrFontToolStripMenuItem.Name = "micrFontToolStripMenuItem";
         this.micrFontToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.micrFontToolStripMenuItem.Text = "Micr Font";
         // 
         // _miFontUnknown
         // 
         this._miFontUnknown.Checked = true;
         this._miFontUnknown.CheckOnClick = true;
         this._miFontUnknown.CheckState = System.Windows.Forms.CheckState.Checked;
         this._miFontUnknown.Name = "_miFontUnknown";
         this._miFontUnknown.Size = new System.Drawing.Size(152, 22);
         this._miFontUnknown.Text = "Unknown";
         this._miFontUnknown.Click += new System.EventHandler(this._miFontType_Click);
         // 
         // _miFontE13B
         // 
         this._miFontE13B.CheckOnClick = true;
         this._miFontE13B.Name = "_miFontE13B";
         this._miFontE13B.Size = new System.Drawing.Size(152, 22);
         this._miFontE13B.Text = "E13B";
         this._miFontE13B.Click += new System.EventHandler(this._miFontType_Click);
         // 
         // _miFontCMC7
         // 
         this._miFontCMC7.CheckOnClick = true;
         this._miFontCMC7.Name = "_miFontCMC7";
         this._miFontCMC7.Size = new System.Drawing.Size(152, 22);
         this._miFontCMC7.Text = "CMC7";
         this._miFontCMC7.Click += new System.EventHandler(this._miFontType_Click);
         // 
         // helpToolStripMenuItem
         // 
         this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
         this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
         this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
         this.helpToolStripMenuItem.Text = "Help";
         // 
         // aboutToolStripMenuItem
         // 
         this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
         this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
         this.aboutToolStripMenuItem.Text = "About";
         this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
         // 
         // _menuItemHowTo
         // 
         this._menuItemHowTo.Name = "_menuItemHowTo";
         this._menuItemHowTo.Size = new System.Drawing.Size(32, 19);
         // 
         // _menuItemAbout
         // 
         this._menuItemAbout.Name = "_menuItemAbout";
         this._menuItemAbout.Size = new System.Drawing.Size(32, 19);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1197, 745);
         this.Controls.Add(this._splMain);
         this.Controls.Add(this.menuStrip1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "MainForm";
         this.Text = "LEADTOOLS Bank Check Reader";
         this._splMain.Panel1.ResumeLayout(false);
         this._splMain.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._splMain)).EndInit();
         this._splMain.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
         this._splViewerList.Panel1.ResumeLayout(false);
         this._splViewerList.Panel1.PerformLayout();
         this._splViewerList.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._splViewerList)).EndInit();
         this._splViewerList.ResumeLayout(false);
         this._tsViewer.ResumeLayout(false);
         this._tsViewer.PerformLayout();
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.SplitContainer _splMain;
      private System.Windows.Forms.SplitContainer _splViewerList;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem _menuItemHowTo;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAbout;
      private System.Windows.Forms.ToolStripMenuItem _menuItemLanguages;
      private System.Windows.Forms.ToolStripMenuItem _menuItemComponents;
      private System.Windows.Forms.ToolStripMenuItem _menuItemEngine;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
      private System.Windows.Forms.DataGridView dataGridView1;
      private Leadtools.Controls.ImageViewer imageViewerField;
      private System.Windows.Forms.ToolStrip _tsViewer;
      private System.Windows.Forms.ToolStripButton _btnZoomNormal;
      private System.Windows.Forms.ToolStripButton _btnFit;
      private System.Windows.Forms.ToolStripButton _btnFitWidth;
      private System.Windows.Forms.ToolStripButton _btnZoomIn;
      private System.Windows.Forms.ToolStripButton _btnZoomOut;
      private System.Windows.Forms.ToolStripButton _btnZoomDrawTool;
      private System.Windows.Forms.ToolStripButton _btnUseDpi;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripButton _btnPanTool;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
      private Leadtools.Controls.ImageViewer rasterImageViewer1;
      private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
      private System.Windows.Forms.DataGridViewTextBoxColumn _fieldName;
      private System.Windows.Forms.DataGridViewTextBoxColumn _value;
      private System.Windows.Forms.ToolStripMenuItem micrFontToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _miFontUnknown;
      private System.Windows.Forms.ToolStripMenuItem _miFontE13B;
      private System.Windows.Forms.ToolStripMenuItem _miFontCMC7;
   }
}

