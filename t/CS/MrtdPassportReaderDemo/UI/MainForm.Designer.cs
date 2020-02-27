namespace MrtdPassportReaderDemo
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
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.dGV_Results = new System.Windows.Forms.DataGridView();
         this.dGV_Errors = new System.Windows.Forms.DataGridView();
         this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this._splViewerList = new System.Windows.Forms.SplitContainer();
         this.rasterImageViewer1 = new Leadtools.Controls.ImageViewer();
         this._tsViewer = new System.Windows.Forms.ToolStrip();
         this._btnPanTool = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
         this._btnZoomNormal = new System.Windows.Forms.ToolStripButton();
         this._btnFit = new System.Windows.Forms.ToolStripButton();
         this._btnFitWidth = new System.Windows.Forms.ToolStripButton();
         this._btnRetry = new System.Windows.Forms.ToolStripButton();
         this._btnRotateLeft = new System.Windows.Forms.ToolStripButton();
         this._btnRotateRight = new System.Windows.Forms.ToolStripButton();
         this._btnZoomIn = new System.Windows.Forms.ToolStripButton();
         this._btnZoomOut = new System.Windows.Forms.ToolStripButton();
         this._btnZoomDrawTool = new System.Windows.Forms.ToolStripButton();
         this._btnUseDpi = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.panel1 = new System.Windows.Forms.Panel();
         this._tB_readonlyMRZCode = new System.Windows.Forms.TextBox();
         this._tB_MRZCode = new System.Windows.Forms.TextBox();
         this._btn_Edit = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.scanImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.enableImprovingResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemHowTo = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
         this._dataElement = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this._value = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this._code = new System.Windows.Forms.DataGridViewTextBoxColumn();
         //((System.ComponentModel.ISupportInitialize)(this._splMain)).BeginInit();
         this._splMain.Panel1.SuspendLayout();
         this._splMain.Panel2.SuspendLayout();
         this._splMain.SuspendLayout();
         //((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dGV_Results)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dGV_Errors)).BeginInit();
         //((System.ComponentModel.ISupportInitialize)(this._splViewerList)).BeginInit();
         this._splViewerList.Panel1.SuspendLayout();
         this._splViewerList.Panel2.SuspendLayout();
         this._splViewerList.SuspendLayout();
         this._tsViewer.SuspendLayout();
         this.panel1.SuspendLayout();
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
         this._splMain.Panel1.Controls.Add(this.splitContainer1);
         this._splMain.Panel1MinSize = 484;
         // 
         // _splMain.Panel2
         // 
         this._splMain.Panel2.Controls.Add(this._splViewerList);
         this._splMain.Size = new System.Drawing.Size(1197, 721);
         this._splMain.SplitterDistance = 644;
         this._splMain.TabIndex = 3;
         // 
         // splitContainer1
         // 
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.Location = new System.Drawing.Point(0, 0);
         this.splitContainer1.Name = "splitContainer1";
         this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.dGV_Results);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.dGV_Errors);
         this.splitContainer1.Size = new System.Drawing.Size(640, 717);
         this.splitContainer1.SplitterDistance = 358;
         this.splitContainer1.TabIndex = 1;
         // 
         // dGV_Results
         // 
         this.dGV_Results.AllowUserToAddRows = false;
         this.dGV_Results.AllowUserToDeleteRows = false;
         this.dGV_Results.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dGV_Results.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._dataElement,
            this._value,
            this._code});
         this.dGV_Results.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dGV_Results.Location = new System.Drawing.Point(0, 0);
         this.dGV_Results.MultiSelect = false;
         this.dGV_Results.Name = "dGV_Results";
         this.dGV_Results.ReadOnly = true;
         this.dGV_Results.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.dGV_Results.Size = new System.Drawing.Size(640, 358);
         this.dGV_Results.TabIndex = 0;
         this.dGV_Results.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_Results_CellClick);
         // 
         // dGV_Errors
         // 
         this.dGV_Errors.AllowUserToAddRows = false;
         this.dGV_Errors.AllowUserToDeleteRows = false;
         this.dGV_Errors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dGV_Errors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
         this.dGV_Errors.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dGV_Errors.Location = new System.Drawing.Point(0, 0);
         this.dGV_Errors.Name = "dGV_Errors";
         this.dGV_Errors.ReadOnly = true;
         this.dGV_Errors.Size = new System.Drawing.Size(640, 355);
         this.dGV_Errors.TabIndex = 1;
         // 
         // dataGridViewTextBoxColumn1
         // 
         this.dataGridViewTextBoxColumn1.Frozen = true;
         this.dataGridViewTextBoxColumn1.HeaderText = "Errors";
         this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
         this.dataGridViewTextBoxColumn1.ReadOnly = true;
         this.dataGridViewTextBoxColumn1.Width = 400;
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
         this._splViewerList.Panel2.Controls.Add(this.panel1);
         this._splViewerList.Panel2.Controls.Add(this._btn_Edit);
         this._splViewerList.Panel2.Controls.Add(this.label1);
         this._splViewerList.Size = new System.Drawing.Size(549, 721);
         this._splViewerList.SplitterDistance = 464;
         this._splViewerList.TabIndex = 0;
         // 
         // rasterImageViewer1
         // 
         this.rasterImageViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.rasterImageViewer1.ImageBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this.rasterImageViewer1.ImageHorizontalAlignment = Leadtools.Controls.ControlAlignment.Near;
         this.rasterImageViewer1.ImageVerticalAlignment = Leadtools.Controls.ControlAlignment.Near;
         this.rasterImageViewer1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this.rasterImageViewer1.ItemSizeMode = Leadtools.Controls.ControlSizeMode.Fit;
         this.rasterImageViewer1.Location = new System.Drawing.Point(0, 53);
         this.rasterImageViewer1.Name = "rasterImageViewer1";
         this.rasterImageViewer1.Size = new System.Drawing.Size(545, 407);
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
            this._btnRetry,
            this._btnRotateLeft,
            this._btnRotateRight,
            this._btnZoomIn,
            this._btnZoomOut,
            this._btnZoomDrawTool,
            this._btnUseDpi,
            this.toolStripSeparator2});
         this._tsViewer.Location = new System.Drawing.Point(0, 0);
         this._tsViewer.Name = "_tsViewer";
         this._tsViewer.RightToLeft = System.Windows.Forms.RightToLeft.No;
         this._tsViewer.Size = new System.Drawing.Size(545, 53);
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
         // _btnRetry
         // 
         this._btnRetry.AutoSize = false;
         this._btnRetry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnRetry.Image = ((System.Drawing.Image)(resources.GetObject("_btnRetry.Image")));
         this._btnRetry.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnRetry.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnRetry.Name = "_btnRetry";
         this._btnRetry.Size = new System.Drawing.Size(50, 50);
         this._btnRetry.Text = "Retry";
         this._btnRetry.Click += new System.EventHandler(this._btnRetry_Click);
         // 
         // _btnRotateLeft
         // 
         this._btnRotateLeft.AutoSize = false;
         this._btnRotateLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnRotateLeft.Image = ((System.Drawing.Image)(resources.GetObject("_btnRotateLeft.Image")));
         this._btnRotateLeft.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnRotateLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnRotateLeft.Name = "_btnRotateLeft";
         this._btnRotateLeft.Size = new System.Drawing.Size(50, 50);
         this._btnRotateLeft.Text = "Rotate Left";
         this._btnRotateLeft.Click += new System.EventHandler(this._btnRotateLeft_Click);
         // 
         // _btnRotateRight
         // 
         this._btnRotateRight.AutoSize = false;
         this._btnRotateRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnRotateRight.Image = ((System.Drawing.Image)(resources.GetObject("_btnRotateRight.Image")));
         this._btnRotateRight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._btnRotateRight.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnRotateRight.Name = "_btnRotateRight";
         this._btnRotateRight.Size = new System.Drawing.Size(50, 50);
         this._btnRotateRight.Text = "Rotate Right";
         this._btnRotateRight.Click += new System.EventHandler(this._btnRotateRight_Click);
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
         // panel1
         // 
         this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.panel1.Controls.Add(this._tB_readonlyMRZCode);
         this.panel1.Controls.Add(this._tB_MRZCode);
         this.panel1.Location = new System.Drawing.Point(4, 84);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(543, 167);
         this.panel1.TabIndex = 4;
         // 
         // _tB_readonlyMRZCode
         // 
         this._tB_readonlyMRZCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._tB_readonlyMRZCode.BackColor = System.Drawing.SystemColors.InactiveCaption;
         this._tB_readonlyMRZCode.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._tB_readonlyMRZCode.ForeColor = System.Drawing.Color.DarkRed;
         this._tB_readonlyMRZCode.Location = new System.Drawing.Point(372, 73);
         this._tB_readonlyMRZCode.Multiline = true;
         this._tB_readonlyMRZCode.Name = "_tB_readonlyMRZCode";
         this._tB_readonlyMRZCode.ReadOnly = true;
         this._tB_readonlyMRZCode.Size = new System.Drawing.Size(0, 10);
         this._tB_readonlyMRZCode.TabIndex = 2;
         this._tB_readonlyMRZCode.Visible = false;
         this._tB_readonlyMRZCode.TextChanged += new System.EventHandler(this._tB_readonlyMRZCode_TextChanged);
         this._tB_readonlyMRZCode.Resize += new System.EventHandler(this._tB_readonlyMRZCode_Resize);
         // 
         // _tB_MRZCode
         // 
         this._tB_MRZCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._tB_MRZCode.Dock = System.Windows.Forms.DockStyle.Fill;
         this._tB_MRZCode.Font = new System.Drawing.Font("Consolas", 12F);
         this._tB_MRZCode.Location = new System.Drawing.Point(0, 0);
         this._tB_MRZCode.Multiline = true;
         this._tB_MRZCode.Name = "_tB_MRZCode";
         this._tB_MRZCode.Size = new System.Drawing.Size(543, 167);
         this._tB_MRZCode.TabIndex = 1;
         this._tB_MRZCode.Visible = false;
         // 
         // _btn_Edit
         // 
         this._btn_Edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._btn_Edit.Location = new System.Drawing.Point(419, 21);
         this._btn_Edit.Name = "_btn_Edit";
         this._btn_Edit.Size = new System.Drawing.Size(116, 39);
         this._btn_Edit.TabIndex = 2;
         this._btn_Edit.Text = "Edit";
         this._btn_Edit.UseVisualStyleBackColor = true;
         this._btn_Edit.Click += new System.EventHandler(this._btn_Edit_Click);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Tahoma", 26F);
         this.label1.Location = new System.Drawing.Point(100, 21);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(263, 42);
         this.label1.TabIndex = 0;
         this.label1.Text = "MRZ Characters";
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
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
            this.scanImageToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "File";
         // 
         // openToolStripMenuItem
         // 
         this.openToolStripMenuItem.Name = "openToolStripMenuItem";
         this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
         this.openToolStripMenuItem.Text = "Open";
         this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
         // 
         // scanImageToolStripMenuItem
         // 
         this.scanImageToolStripMenuItem.Name = "scanImageToolStripMenuItem";
         this.scanImageToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
         this.scanImageToolStripMenuItem.Text = "Scan Page";
         this.scanImageToolStripMenuItem.Click += new System.EventHandler(this.scanImageToolStripMenuItem_Click);
         // 
         // closeToolStripMenuItem
         // 
         this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
         this.closeToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
         this.closeToolStripMenuItem.Text = "Close";
         this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
         this.exitToolStripMenuItem.Text = "Exit";
         this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
         // 
         // optionsToolStripMenuItem
         // 
         this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableImprovingResultsToolStripMenuItem});
         this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
         this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
         this.optionsToolStripMenuItem.Text = "Options";
         // 
         // enableImprovingResultsToolStripMenuItem
         // 
         this.enableImprovingResultsToolStripMenuItem.Name = "enableImprovingResultsToolStripMenuItem";
         this.enableImprovingResultsToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
         this.enableImprovingResultsToolStripMenuItem.Text = "Enable Improving Results";
         this.enableImprovingResultsToolStripMenuItem.Click += new System.EventHandler(this.enableImprovingResultsToolStripMenuItem_Click);
         // 
         // helpToolStripMenuItem
         // 
         this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.informationToolStripMenuItem});
         this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
         this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
         this.helpToolStripMenuItem.Text = "Help";
         // 
         // aboutToolStripMenuItem
         // 
         this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
         this.aboutToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
         this.aboutToolStripMenuItem.Text = "About";
         this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
         // 
         // informationToolStripMenuItem
         // 
         this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
         this.informationToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
         this.informationToolStripMenuItem.Text = "How To Use";
         this.informationToolStripMenuItem.Click += new System.EventHandler(this.informationToolStripMenuItem_Click);
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
         // _dataElement
         // 
         this._dataElement.FillWeight = 70F;
         this._dataElement.Frozen = true;
         this._dataElement.HeaderText = "Data Element";
         this._dataElement.Name = "_dataElement";
         this._dataElement.ReadOnly = true;
         this._dataElement.Width = 200;
         // 
         // _value
         // 
         this._value.FillWeight = 70F;
         this._value.Frozen = true;
         this._value.HeaderText = "Value";
         this._value.Name = "_value";
         this._value.ReadOnly = true;
         this._value.Width = 200;
         // 
         // _code
         // 
         this._code.FillWeight = 70F;
         this._code.HeaderText = "Code";
         this._code.Name = "_code";
         this._code.ReadOnly = true;
         this._code.Width = 300;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1197, 745);
         this.Controls.Add(this._splMain);
         this.Controls.Add(this.menuStrip1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "MainForm";
         this.Text = "LEADTOOLS MRTD Reader Demo";
         this.Load += new System.EventHandler(this.MainForm_Load);
         this._splMain.Panel1.ResumeLayout(false);
         this._splMain.Panel2.ResumeLayout(false);
         //((System.ComponentModel.ISupportInitialize)(this._splMain)).EndInit();
         this._splMain.ResumeLayout(false);
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         //((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
         this.splitContainer1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dGV_Results)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dGV_Errors)).EndInit();
         this._splViewerList.Panel1.ResumeLayout(false);
         this._splViewerList.Panel1.PerformLayout();
         this._splViewerList.Panel2.ResumeLayout(false);
         this._splViewerList.Panel2.PerformLayout();
         //((System.ComponentModel.ISupportInitialize)(this._splViewerList)).EndInit();
         this._splViewerList.ResumeLayout(false);
         this._tsViewer.ResumeLayout(false);
         this._tsViewer.PerformLayout();
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
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
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
      private System.Windows.Forms.DataGridView dGV_Results;
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
      private System.Windows.Forms.Button _btn_Edit;
      private System.Windows.Forms.TextBox _tB_MRZCode;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.TextBox _tB_readonlyMRZCode;
      private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.DataGridView dGV_Errors;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
      private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem enableImprovingResultsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem scanImageToolStripMenuItem;
      private System.Windows.Forms.ToolStripButton _btnRetry;
      private System.Windows.Forms.ToolStripButton _btnRotateRight;
      private System.Windows.Forms.ToolStripButton _btnRotateLeft;
      private System.Windows.Forms.DataGridViewTextBoxColumn _dataElement;
      private System.Windows.Forms.DataGridViewTextBoxColumn _value;
      private System.Windows.Forms.DataGridViewTextBoxColumn _code;
   }
}

