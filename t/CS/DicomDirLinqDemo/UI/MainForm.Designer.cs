namespace CSDicomDirLinqDemo.UI
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
           this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
           this.statusStrip1 = new System.Windows.Forms.StatusStrip();
           this.splitContainerLeft = new System.Windows.Forms.SplitContainer();
           this.treeViewDicomDir = new System.Windows.Forms.TreeView();
           this.label1 = new System.Windows.Forms.Label();
           this.panel1 = new System.Windows.Forms.Panel();
           this.txtElementValue = new System.Windows.Forms.TextBox();
           this.label3 = new System.Windows.Forms.Label();
           this.splitContainer1 = new System.Windows.Forms.SplitContainer();
           this.richTextBoxLinqInfo = new System.Windows.Forms.RichTextBox();
           this.label4 = new System.Windows.Forms.Label();
           this.splitter1 = new System.Windows.Forms.Splitter();
           this.tabControl = new System.Windows.Forms.TabControl();
           this.tabPageQuery = new System.Windows.Forms.TabPage();
           this.richTextBoxScript = new System.Windows.Forms.RichTextBox();
           this.tabPageResults = new System.Windows.Forms.TabPage();
           this.webBrowserResults = new System.Windows.Forms.WebBrowser();
           this.tabPageViewer = new System.Windows.Forms.TabPage();
           this.imageList = new System.Windows.Forms.ImageList(this.components);
           this.linkLabelDownloadDicomDir = new System.Windows.Forms.LinkLabel();
           this.queryPanel = new System.Windows.Forms.FlowLayoutPanel();
           this.label2 = new System.Windows.Forms.Label();
           this.menuStrip1 = new System.Windows.Forms.MenuStrip();
           this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
           this.toolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
           this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
           this.downloadSampleDICOMDIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
           this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
           this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.toolStrip1 = new System.Windows.Forms.ToolStrip();
           this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
           this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
           this.toolStripButtonExecute = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonThumbnails = new System.Windows.Forms.ToolStripButton();
           this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
           this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
           this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
           this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
           this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
           this.toolTip = new System.Windows.Forms.ToolTip(this.components);
           this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
           this.toolStripContainer1.ContentPanel.SuspendLayout();
           this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
           this.toolStripContainer1.SuspendLayout();
           this.splitContainerLeft.Panel1.SuspendLayout();
           this.splitContainerLeft.Panel2.SuspendLayout();
           this.splitContainerLeft.SuspendLayout();
           this.panel1.SuspendLayout();
           this.splitContainer1.Panel1.SuspendLayout();
           this.splitContainer1.Panel2.SuspendLayout();
           this.splitContainer1.SuspendLayout();
           this.tabControl.SuspendLayout();
           this.tabPageQuery.SuspendLayout();
           this.tabPageResults.SuspendLayout();
           this.menuStrip1.SuspendLayout();
           this.toolStrip1.SuspendLayout();
           this.SuspendLayout();
           // 
           // toolStripContainer1
           // 
           // 
           // toolStripContainer1.BottomToolStripPanel
           // 
           this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
           // 
           // toolStripContainer1.ContentPanel
           // 
           this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainerLeft);
           this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1032, 569);
           this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
           this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
           this.toolStripContainer1.Name = "toolStripContainer1";
           this.toolStripContainer1.Size = new System.Drawing.Size(1032, 670);
           this.toolStripContainer1.TabIndex = 0;
           this.toolStripContainer1.Text = "toolStripContainer1";
           // 
           // toolStripContainer1.TopToolStripPanel
           // 
           this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
           this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
           // 
           // statusStrip1
           // 
           this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
           this.statusStrip1.Location = new System.Drawing.Point(0, 0);
           this.statusStrip1.Name = "statusStrip1";
           this.statusStrip1.Size = new System.Drawing.Size(1032, 22);
           this.statusStrip1.TabIndex = 0;
           this.statusStrip1.Text = "statusStrip1";
           // 
           // splitContainerLeft
           // 
           this.splitContainerLeft.AllowDrop = true;
           this.splitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
           this.splitContainerLeft.Location = new System.Drawing.Point(0, 0);
           this.splitContainerLeft.Name = "splitContainerLeft";
           // 
           // splitContainerLeft.Panel1
           // 
           this.splitContainerLeft.Panel1.AllowDrop = true;
           this.splitContainerLeft.Panel1.Controls.Add(this.treeViewDicomDir);
           this.splitContainerLeft.Panel1.Controls.Add(this.label1);
           this.splitContainerLeft.Panel1.Controls.Add(this.panel1);
           // 
           // splitContainerLeft.Panel2
           // 
           this.splitContainerLeft.Panel2.Controls.Add(this.splitContainer1);
           this.splitContainerLeft.Size = new System.Drawing.Size(1032, 569);
           this.splitContainerLeft.SplitterDistance = 304;
           this.splitContainerLeft.TabIndex = 1;
           // 
           // treeViewDicomDir
           // 
           this.treeViewDicomDir.AllowDrop = true;
           this.treeViewDicomDir.Dock = System.Windows.Forms.DockStyle.Fill;
           this.treeViewDicomDir.FullRowSelect = true;
           this.treeViewDicomDir.Location = new System.Drawing.Point(0, 13);
           this.treeViewDicomDir.Name = "treeViewDicomDir";
           this.treeViewDicomDir.Size = new System.Drawing.Size(304, 463);
           this.treeViewDicomDir.TabIndex = 1;
           this.treeViewDicomDir.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeViewDicomDir_DragDrop);
           this.treeViewDicomDir.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDicomDir_AfterSelect);
           this.treeViewDicomDir.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeViewDicomDir_DragEnter);
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Dock = System.Windows.Forms.DockStyle.Top;
           this.label1.Location = new System.Drawing.Point(0, 0);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(64, 13);
           this.label1.TabIndex = 0;
           this.label1.Text = "DICOMDIR:";
           // 
           // panel1
           // 
           this.panel1.Controls.Add(this.txtElementValue);
           this.panel1.Controls.Add(this.label3);
           this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
           this.panel1.Location = new System.Drawing.Point(0, 476);
           this.panel1.Name = "panel1";
           this.panel1.Size = new System.Drawing.Size(304, 93);
           this.panel1.TabIndex = 4;
           // 
           // txtElementValue
           // 
           this.txtElementValue.Dock = System.Windows.Forms.DockStyle.Fill;
           this.txtElementValue.Location = new System.Drawing.Point(0, 13);
           this.txtElementValue.Multiline = true;
           this.txtElementValue.Name = "txtElementValue";
           this.txtElementValue.ReadOnly = true;
           this.txtElementValue.Size = new System.Drawing.Size(304, 80);
           this.txtElementValue.TabIndex = 1;
           // 
           // label3
           // 
           this.label3.AutoSize = true;
           this.label3.Dock = System.Windows.Forms.DockStyle.Top;
           this.label3.Location = new System.Drawing.Point(0, 0);
           this.label3.Name = "label3";
           this.label3.Size = new System.Drawing.Size(78, 13);
           this.label3.TabIndex = 0;
           this.label3.Text = "Element Value:";
           // 
           // splitContainer1
           // 
           this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
           this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
           this.splitContainer1.Location = new System.Drawing.Point(0, 0);
           this.splitContainer1.Name = "splitContainer1";
           // 
           // splitContainer1.Panel1
           // 
           this.splitContainer1.Panel1.Controls.Add(this.richTextBoxLinqInfo);
           this.splitContainer1.Panel1.Controls.Add(this.label4);
           this.splitContainer1.Panel1.Controls.Add(this.splitter1);
           this.splitContainer1.Panel1.Controls.Add(this.tabControl);
           // 
           // splitContainer1.Panel2
           // 
           this.splitContainer1.Panel2.Controls.Add(this.linkLabelDownloadDicomDir);
           this.splitContainer1.Panel2.Controls.Add(this.queryPanel);
           this.splitContainer1.Panel2.Controls.Add(this.label2);
           this.splitContainer1.Size = new System.Drawing.Size(724, 569);
           this.splitContainer1.SplitterDistance = 559;
           this.splitContainer1.TabIndex = 1;
           // 
           // richTextBoxLinqInfo
           // 
           this.richTextBoxLinqInfo.Dock = System.Windows.Forms.DockStyle.Fill;
           this.richTextBoxLinqInfo.Location = new System.Drawing.Point(0, 423);
           this.richTextBoxLinqInfo.Name = "richTextBoxLinqInfo";
           this.richTextBoxLinqInfo.ReadOnly = true;
           this.richTextBoxLinqInfo.Size = new System.Drawing.Size(559, 146);
           this.richTextBoxLinqInfo.TabIndex = 2;
           this.richTextBoxLinqInfo.Text = "";
           // 
           // label4
           // 
           this.label4.AutoSize = true;
           this.label4.Dock = System.Windows.Forms.DockStyle.Top;
           this.label4.Location = new System.Drawing.Point(0, 410);
           this.label4.Name = "label4";
           this.label4.Size = new System.Drawing.Size(85, 13);
           this.label4.TabIndex = 3;
           this.label4.Text = "Linq Information:";
           // 
           // splitter1
           // 
           this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
           this.splitter1.Location = new System.Drawing.Point(0, 407);
           this.splitter1.Name = "splitter1";
           this.splitter1.Size = new System.Drawing.Size(559, 3);
           this.splitter1.TabIndex = 1;
           this.splitter1.TabStop = false;
           // 
           // tabControl
           // 
           this.tabControl.Controls.Add(this.tabPageQuery);
           this.tabControl.Controls.Add(this.tabPageResults);
           this.tabControl.Controls.Add(this.tabPageViewer);
           this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
           this.tabControl.ImageList = this.imageList;
           this.tabControl.Location = new System.Drawing.Point(0, 0);
           this.tabControl.Name = "tabControl";
           this.tabControl.SelectedIndex = 0;
           this.tabControl.Size = new System.Drawing.Size(559, 407);
           this.tabControl.TabIndex = 0;
           // 
           // tabPageQuery
           // 
           this.tabPageQuery.Controls.Add(this.richTextBoxScript);
           this.tabPageQuery.ImageIndex = 0;
           this.tabPageQuery.Location = new System.Drawing.Point(4, 23);
           this.tabPageQuery.Name = "tabPageQuery";
           this.tabPageQuery.Padding = new System.Windows.Forms.Padding(3);
           this.tabPageQuery.Size = new System.Drawing.Size(551, 380);
           this.tabPageQuery.TabIndex = 0;
           this.tabPageQuery.Text = "Linq Query";
           this.tabPageQuery.UseVisualStyleBackColor = true;
           // 
           // richTextBoxScript
           // 
           this.richTextBoxScript.CausesValidation = false;
           this.richTextBoxScript.DetectUrls = false;
           this.richTextBoxScript.Dock = System.Windows.Forms.DockStyle.Fill;
           this.richTextBoxScript.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.richTextBoxScript.Location = new System.Drawing.Point(3, 3);
           this.richTextBoxScript.Name = "richTextBoxScript";
           this.richTextBoxScript.Size = new System.Drawing.Size(545, 374);
           this.richTextBoxScript.TabIndex = 1;
           this.richTextBoxScript.Text = "";
           this.richTextBoxScript.WordWrap = false;
           // 
           // tabPageResults
           // 
           this.tabPageResults.Controls.Add(this.webBrowserResults);
           this.tabPageResults.ImageIndex = 1;
           this.tabPageResults.Location = new System.Drawing.Point(4, 23);
           this.tabPageResults.Name = "tabPageResults";
           this.tabPageResults.Padding = new System.Windows.Forms.Padding(3);
           this.tabPageResults.Size = new System.Drawing.Size(551, 380);
           this.tabPageResults.TabIndex = 1;
           this.tabPageResults.Text = "Results";
           this.tabPageResults.UseVisualStyleBackColor = true;
           // 
           // webBrowserResults
           // 
           this.webBrowserResults.Dock = System.Windows.Forms.DockStyle.Fill;
           this.webBrowserResults.Location = new System.Drawing.Point(3, 3);
           this.webBrowserResults.MinimumSize = new System.Drawing.Size(20, 20);
           this.webBrowserResults.Name = "webBrowserResults";
           this.webBrowserResults.Size = new System.Drawing.Size(545, 374);
           this.webBrowserResults.TabIndex = 0;
           this.webBrowserResults.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowserResults_Navigating);
           // 
           // tabPageViewer
           // 
           this.tabPageViewer.ImageIndex = 2;
           this.tabPageViewer.Location = new System.Drawing.Point(4, 23);
           this.tabPageViewer.Name = "tabPageViewer";
           this.tabPageViewer.Padding = new System.Windows.Forms.Padding(3);
           this.tabPageViewer.Size = new System.Drawing.Size(551, 380);
           this.tabPageViewer.TabIndex = 2;
           this.tabPageViewer.Text = "Viewer";
           this.tabPageViewer.UseVisualStyleBackColor = true;
           // 
           // imageList
           // 
           this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
           this.imageList.TransparentColor = System.Drawing.Color.Transparent;
           this.imageList.Images.SetKeyName(0, "lightning.png");
           this.imageList.Images.SetKeyName(1, "application_view_detail.png");
           this.imageList.Images.SetKeyName(2, "image.png");
           // 
           // linkLabelDownloadDicomDir
           // 
           this.linkLabelDownloadDicomDir.AutoSize = true;
           this.linkLabelDownloadDicomDir.Location = new System.Drawing.Point(8, 429);
           this.linkLabelDownloadDicomDir.Name = "linkLabelDownloadDicomDir";
           this.linkLabelDownloadDicomDir.Size = new System.Drawing.Size(150, 13);
           this.linkLabelDownloadDicomDir.TabIndex = 1;
           this.linkLabelDownloadDicomDir.TabStop = true;
           this.linkLabelDownloadDicomDir.Text = "Download Sample DICOMDIR";
           this.linkLabelDownloadDicomDir.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDownloadDicomDir_LinkClicked_1);
           // 
           // queryPanel
           // 
           this.queryPanel.AutoScroll = true;
           this.queryPanel.Dock = System.Windows.Forms.DockStyle.Top;
           this.queryPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
           this.queryPanel.Location = new System.Drawing.Point(0, 85);
           this.queryPanel.Name = "queryPanel";
           this.queryPanel.Size = new System.Drawing.Size(161, 323);
           this.queryPanel.TabIndex = 0;
           this.queryPanel.WrapContents = false;
           // 
           // label2
           // 
           this.label2.Dock = System.Windows.Forms.DockStyle.Top;
           this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.label2.Location = new System.Drawing.Point(0, 0);
           this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 15);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(161, 85);
           this.label2.TabIndex = 0;
           this.label2.Text = "Click one of the sample queries below to add to the query editor.  Click the exec" +
               "ute icon to execute the query using the loaded DICOMDIR.";
           // 
           // menuStrip1
           // 
           this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
           this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.helpToolStripMenuItem1});
           this.menuStrip1.Location = new System.Drawing.Point(0, 0);
           this.menuStrip1.Name = "menuStrip1";
           this.menuStrip1.Size = new System.Drawing.Size(1032, 24);
           this.menuStrip1.TabIndex = 0;
           this.menuStrip1.Text = "menuStrip1";
           // 
           // toolStripMenuItemFile
           // 
           this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpen,
            this.toolStripMenuItem1,
            this.downloadSampleDICOMDIRToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
           this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
           this.toolStripMenuItemFile.Size = new System.Drawing.Size(37, 20);
           this.toolStripMenuItemFile.Text = "&File";
           // 
           // toolStripMenuItemOpen
           // 
           this.toolStripMenuItemOpen.Name = "toolStripMenuItemOpen";
           this.toolStripMenuItemOpen.Size = new System.Drawing.Size(239, 22);
           this.toolStripMenuItemOpen.Text = "&Open...";
           this.toolStripMenuItemOpen.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
           // 
           // toolStripMenuItem1
           // 
           this.toolStripMenuItem1.Name = "toolStripMenuItem1";
           this.toolStripMenuItem1.Size = new System.Drawing.Size(236, 6);
           // 
           // downloadSampleDICOMDIRToolStripMenuItem
           // 
           this.downloadSampleDICOMDIRToolStripMenuItem.Name = "downloadSampleDICOMDIRToolStripMenuItem";
           this.downloadSampleDICOMDIRToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
           this.downloadSampleDICOMDIRToolStripMenuItem.Text = "Download Sample DICOMDIR...";
           this.downloadSampleDICOMDIRToolStripMenuItem.Click += new System.EventHandler(this.downloadSampleDICOMDIRToolStripMenuItem_Click);
           // 
           // toolStripSeparator3
           // 
           this.toolStripSeparator3.Name = "toolStripSeparator3";
           this.toolStripSeparator3.Size = new System.Drawing.Size(236, 6);
           // 
           // exitToolStripMenuItem
           // 
           this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
           this.exitToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
           this.exitToolStripMenuItem.Text = "&Exit";
           this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
           // 
           // helpToolStripMenuItem1
           // 
           this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
           this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
           this.helpToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
           this.helpToolStripMenuItem1.Text = "&Help";
           // 
           // aboutToolStripMenuItem
           // 
           this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
           this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
           this.aboutToolStripMenuItem.Text = "&About...";
           this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
           // 
           // toolStrip1
           // 
           this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
           this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
           this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpen,
            this.toolStripSeparator2,
            this.toolStripButtonExecute,
            this.toolStripButtonThumbnails});
           this.toolStrip1.Location = new System.Drawing.Point(3, 24);
           this.toolStrip1.Name = "toolStrip1";
           this.toolStrip1.Size = new System.Drawing.Size(196, 55);
           this.toolStrip1.TabIndex = 1;
           // 
           // toolStripButtonOpen
           // 
           this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonOpen.Image = global::CSDicomDirLinqDemo.Properties.Resources.Folder_Open;
           this.toolStripButtonOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
           this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonOpen.Name = "toolStripButtonOpen";
           this.toolStripButtonOpen.Size = new System.Drawing.Size(52, 52);
           this.toolStripButtonOpen.ToolTipText = "Open DICOMDIR";
           this.toolStripButtonOpen.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
           // 
           // toolStripSeparator2
           // 
           this.toolStripSeparator2.Name = "toolStripSeparator2";
           this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
           // 
           // toolStripButtonExecute
           // 
           this.toolStripButtonExecute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonExecute.Image = global::CSDicomDirLinqDemo.Properties.Resources.Autoplay;
           this.toolStripButtonExecute.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
           this.toolStripButtonExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonExecute.Name = "toolStripButtonExecute";
           this.toolStripButtonExecute.Size = new System.Drawing.Size(52, 52);
           this.toolStripButtonExecute.ToolTipText = "Execute script";
           this.toolStripButtonExecute.Click += new System.EventHandler(this.toolStripButtonExecute_Click);
           // 
           // toolStripButtonThumbnails
           // 
           this.toolStripButtonThumbnails.Checked = true;
           this.toolStripButtonThumbnails.CheckOnClick = true;
           this.toolStripButtonThumbnails.CheckState = System.Windows.Forms.CheckState.Checked;
           this.toolStripButtonThumbnails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonThumbnails.Image = global::CSDicomDirLinqDemo.Properties.Resources.generic_picture;
           this.toolStripButtonThumbnails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
           this.toolStripButtonThumbnails.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonThumbnails.Name = "toolStripButtonThumbnails";
           this.toolStripButtonThumbnails.Size = new System.Drawing.Size(52, 52);
           this.toolStripButtonThumbnails.Text = "toolStripButtonThumbnails";
           this.toolStripButtonThumbnails.ToolTipText = "View Thumbnails";
           this.toolStripButtonThumbnails.CheckedChanged += new System.EventHandler(this.toolStripButtonThumbnails_CheckedChanged);
           // 
           // toolStripStatusLabel
           // 
           this.toolStripStatusLabel.Name = "toolStripStatusLabel";
           this.toolStripStatusLabel.Size = new System.Drawing.Size(1017, 17);
           this.toolStripStatusLabel.Spring = true;
           // 
           // toolStripProgressBar
           // 
           this.toolStripProgressBar.MarqueeAnimationSpeed = 0;
           this.toolStripProgressBar.Name = "toolStripProgressBar";
           this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
           this.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
           this.toolStripProgressBar.Visible = false;
           // 
           // toolStripMenuItem2
           // 
           this.toolStripMenuItem2.Name = "toolStripMenuItem2";
           this.toolStripMenuItem2.Size = new System.Drawing.Size(6, 6);
           // 
           // helpToolStripMenuItem
           // 
           this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
           this.helpToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
           // 
           // toolStripSeparator1
           // 
           this.toolStripSeparator1.Name = "toolStripSeparator1";
           this.toolStripSeparator1.Size = new System.Drawing.Size(6, 6);
           // 
           // openFileDialog
           // 
           this.openFileDialog.Filter = "DICOM Basic Directory|DICOMDIR|All Files|*.*";
           this.openFileDialog.Title = "Load DICOM Basic Directory";
           // 
           // toolTip
           // 
           this.toolTip.ToolTipTitle = "Query";
           // 
           // MainForm
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(1032, 670);
           this.Controls.Add(this.toolStripContainer1);
           this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
           this.MainMenuStrip = this.menuStrip1;
           this.Name = "MainForm";
           this.Text = "MainForm";
           this.Load += new System.EventHandler(this.MainForm_Load);
           this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
           this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
           this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
           this.toolStripContainer1.ContentPanel.ResumeLayout(false);
           this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
           this.toolStripContainer1.TopToolStripPanel.PerformLayout();
           this.toolStripContainer1.ResumeLayout(false);
           this.toolStripContainer1.PerformLayout();
           this.splitContainerLeft.Panel1.ResumeLayout(false);
           this.splitContainerLeft.Panel1.PerformLayout();
           this.splitContainerLeft.Panel2.ResumeLayout(false);
           this.splitContainerLeft.ResumeLayout(false);
           this.panel1.ResumeLayout(false);
           this.panel1.PerformLayout();
           this.splitContainer1.Panel1.ResumeLayout(false);
           this.splitContainer1.Panel1.PerformLayout();
           this.splitContainer1.Panel2.ResumeLayout(false);
           this.splitContainer1.Panel2.PerformLayout();
           this.splitContainer1.ResumeLayout(false);
           this.tabControl.ResumeLayout(false);
           this.tabPageQuery.ResumeLayout(false);
           this.tabPageResults.ResumeLayout(false);
           this.menuStrip1.ResumeLayout(false);
           this.menuStrip1.PerformLayout();
           this.toolStrip1.ResumeLayout(false);
           this.toolStrip1.PerformLayout();
           this.ResumeLayout(false);

        }

        #endregion        

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.SplitContainer splitContainerLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;       
        private System.Windows.Forms.TreeView treeViewDicomDir;
        private System.Windows.Forms.RichTextBox richTextBoxScript;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2; 
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtElementValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageQuery;
        private System.Windows.Forms.TabPage tabPageResults;        
        private System.Windows.Forms.WebBrowser webBrowserResults;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TabPage tabPageViewer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;        
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;        
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel queryPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonExecute;
        private System.Windows.Forms.ToolStripButton toolStripButtonThumbnails;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.RichTextBox richTextBoxLinqInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.LinkLabel linkLabelDownloadDicomDir;
        private System.Windows.Forms.ToolStripMenuItem downloadSampleDICOMDIRToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;        
    }
}