namespace WebViewerConfiguration
{
   partial class Form1
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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.groupBoxTroubleShooting = new System.Windows.Forms.GroupBox();
         this.dataGridView1 = new System.Windows.Forms.DataGridView();
         this.ColumnProblem = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnLink = new System.Windows.Forms.DataGridViewLinkColumn();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.lblPort = new System.Windows.Forms.Label();
         this.lblIPAddress = new System.Windows.Forms.Label();
         this.lblServerName = new System.Windows.Forms.Label();
         this.lblConnection = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.btnFix = new System.Windows.Forms.Button();
         this.btnRun = new System.Windows.Forms.Button();
         this.radioButtonMedical = new System.Windows.Forms.RadioButton();
         this.radioButtonDental = new System.Windows.Forms.RadioButton();
         this.listViewStatus = new System.Windows.Forms.ListView();
         this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.clearStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.upgradeDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.enableRunViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.useWCFServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.useASPNETServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.create3DServiceInstallerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.configure3DServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.download3DImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparatorExtraOptions = new System.Windows.Forms.ToolStripSeparator();
         this.silentRegisterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparatorExtraOptions2 = new System.Windows.Forms.ToolStripSeparator();
         this.startLeadtoolsMedical3DProxyexeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.stopLeadtoolsMedical3DProxyexeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.deleteLeadtoolsMedical3DProxyexeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.registerLeadtoolsMedical3DProxyexeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparatorExtraOptions3 = new System.Windows.Forms.ToolStripSeparator();
         this.installLeadtoolsMedical3DProxyexeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.buttonOK = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.groupBoxTroubleShooting.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
         this.tableLayoutPanel1.SuspendLayout();
         this.contextMenuStrip.SuspendLayout();
         this.menuStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this.groupBoxTroubleShooting);
         this.groupBox1.Controls.Add(this.tableLayoutPanel1);
         this.groupBox1.Controls.Add(this.lblConnection);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Location = new System.Drawing.Point(12, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(688, 345);
         this.groupBox1.TabIndex = 1;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Server Database:";
         // 
         // groupBoxTroubleShooting
         // 
         this.groupBoxTroubleShooting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxTroubleShooting.Controls.Add(this.dataGridView1);
         this.groupBoxTroubleShooting.Location = new System.Drawing.Point(6, 111);
         this.groupBoxTroubleShooting.Name = "groupBoxTroubleShooting";
         this.groupBoxTroubleShooting.Size = new System.Drawing.Size(676, 234);
         this.groupBoxTroubleShooting.TabIndex = 7;
         this.groupBoxTroubleShooting.TabStop = false;
         this.groupBoxTroubleShooting.Text = "Troubleshooting";
         // 
         // dataGridView1
         // 
         this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
         this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnProblem,
            this.ColumnLink});
         this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridView1.Location = new System.Drawing.Point(3, 16);
         this.dataGridView1.Name = "dataGridView1";
         this.dataGridView1.Size = new System.Drawing.Size(670, 215);
         this.dataGridView1.TabIndex = 0;
         // 
         // ColumnProblem
         // 
         this.ColumnProblem.HeaderText = "Problem";
         this.ColumnProblem.Name = "ColumnProblem";
         // 
         // ColumnLink
         // 
         this.ColumnLink.HeaderText = "Link";
         this.ColumnLink.Name = "ColumnLink";
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel1.ColumnCount = 3;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
         this.tableLayoutPanel1.Controls.Add(this.lblPort, 2, 0);
         this.tableLayoutPanel1.Controls.Add(this.lblIPAddress, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.lblServerName, 0, 0);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 19);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 1;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(673, 37);
         this.tableLayoutPanel1.TabIndex = 6;
         // 
         // lblPort
         // 
         this.lblPort.AutoSize = true;
         this.lblPort.Location = new System.Drawing.Point(451, 0);
         this.lblPort.Name = "lblPort";
         this.lblPort.Size = new System.Drawing.Size(0, 13);
         this.lblPort.TabIndex = 2;
         // 
         // lblIPAddress
         // 
         this.lblIPAddress.AutoSize = true;
         this.lblIPAddress.Location = new System.Drawing.Point(227, 0);
         this.lblIPAddress.Name = "lblIPAddress";
         this.lblIPAddress.Size = new System.Drawing.Size(0, 13);
         this.lblIPAddress.TabIndex = 1;
         // 
         // lblServerName
         // 
         this.lblServerName.AutoSize = true;
         this.lblServerName.Location = new System.Drawing.Point(3, 0);
         this.lblServerName.Name = "lblServerName";
         this.lblServerName.Size = new System.Drawing.Size(0, 13);
         this.lblServerName.TabIndex = 0;
         // 
         // lblConnection
         // 
         this.lblConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.lblConnection.AutoEllipsis = true;
         this.lblConnection.Location = new System.Drawing.Point(12, 83);
         this.lblConnection.Name = "lblConnection";
         this.lblConnection.Size = new System.Drawing.Size(670, 51);
         this.lblConnection.TabIndex = 1;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(6, 59);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(111, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "Database Information:";
         // 
         // btnFix
         // 
         this.btnFix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.btnFix.Location = new System.Drawing.Point(12, 538);
         this.btnFix.Name = "btnFix";
         this.btnFix.Size = new System.Drawing.Size(75, 23);
         this.btnFix.TabIndex = 3;
         this.btnFix.Text = "Fix Problems";
         this.btnFix.UseVisualStyleBackColor = true;
         this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
         // 
         // btnRun
         // 
         this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnRun.Location = new System.Drawing.Point(548, 538);
         this.btnRun.Name = "btnRun";
         this.btnRun.Size = new System.Drawing.Size(75, 43);
         this.btnRun.TabIndex = 5;
         this.btnRun.Text = "Run Viewer";
         this.btnRun.UseVisualStyleBackColor = true;
         this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
         // 
         // radioButtonMedical
         // 
         this.radioButtonMedical.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.radioButtonMedical.AutoSize = true;
         this.radioButtonMedical.Location = new System.Drawing.Point(638, 541);
         this.radioButtonMedical.Name = "radioButtonMedical";
         this.radioButtonMedical.Size = new System.Drawing.Size(62, 17);
         this.radioButtonMedical.TabIndex = 6;
         this.radioButtonMedical.TabStop = true;
         this.radioButtonMedical.Text = "Medical";
         this.radioButtonMedical.UseVisualStyleBackColor = true;
         // 
         // radioButtonDental
         // 
         this.radioButtonDental.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.radioButtonDental.AutoSize = true;
         this.radioButtonDental.Location = new System.Drawing.Point(638, 564);
         this.radioButtonDental.Name = "radioButtonDental";
         this.radioButtonDental.Size = new System.Drawing.Size(56, 17);
         this.radioButtonDental.TabIndex = 7;
         this.radioButtonDental.TabStop = true;
         this.radioButtonDental.Text = "Dental";
         this.radioButtonDental.UseVisualStyleBackColor = true;
         // 
         // listViewStatus
         // 
         this.listViewStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listViewStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
         this.listViewStatus.ContextMenuStrip = this.contextMenuStrip;
         this.listViewStatus.Location = new System.Drawing.Point(12, 363);
         this.listViewStatus.Name = "listViewStatus";
         this.listViewStatus.Size = new System.Drawing.Size(688, 162);
         this.listViewStatus.TabIndex = 2;
         this.listViewStatus.UseCompatibleStateImageBehavior = false;
         this.listViewStatus.View = System.Windows.Forms.View.Details;
         // 
         // columnHeader1
         // 
         this.columnHeader1.Text = "Status";
         // 
         // columnHeader2
         // 
         this.columnHeader2.Text = "";
         // 
         // columnHeader3
         // 
         this.columnHeader3.Text = "";
         // 
         // contextMenuStrip
         // 
         this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearStatusToolStripMenuItem});
         this.contextMenuStrip.Name = "contextMenuStrip";
         this.contextMenuStrip.Size = new System.Drawing.Size(137, 26);
         // 
         // clearStatusToolStripMenuItem
         // 
         this.clearStatusToolStripMenuItem.Name = "clearStatusToolStripMenuItem";
         this.clearStatusToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
         this.clearStatusToolStripMenuItem.Text = "Clear Status";
         this.clearStatusToolStripMenuItem.Click += new System.EventHandler(this.clearStatusToolStripMenuItem_Click);
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(712, 24);
         this.menuStrip1.TabIndex = 0;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upgradeDatabaseToolStripMenuItem,
            this.enableRunViewerToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "File";
         // 
         // upgradeDatabaseToolStripMenuItem
         // 
         this.upgradeDatabaseToolStripMenuItem.Name = "upgradeDatabaseToolStripMenuItem";
         this.upgradeDatabaseToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
         this.upgradeDatabaseToolStripMenuItem.Text = "Upgrade Database";
         this.upgradeDatabaseToolStripMenuItem.Click += new System.EventHandler(this.upgradeDatabaseToolStripMenuItem_Click);
         // 
         // enableRunViewerToolStripMenuItem
         // 
         this.enableRunViewerToolStripMenuItem.Name = "enableRunViewerToolStripMenuItem";
         this.enableRunViewerToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
         this.enableRunViewerToolStripMenuItem.Text = "Enable \'Run Viewer\'";
         this.enableRunViewerToolStripMenuItem.Click += new System.EventHandler(this.enableRunViewerToolStripMenuItem_Click);
         // 
         // optionsToolStripMenuItem
         // 
         this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.useASPNETServiceToolStripMenuItem,
            this.useWCFServiceToolStripMenuItem,
            this.toolStripSeparator1,
            this.create3DServiceInstallerToolStripMenuItem,
            this.configure3DServiceToolStripMenuItem,
            this.toolStripSeparator2,
            this.download3DImagesToolStripMenuItem,
            this.toolStripSeparatorExtraOptions,
            this.silentRegisterToolStripMenuItem,
            this.toolStripSeparatorExtraOptions2,
            this.startLeadtoolsMedical3DProxyexeToolStripMenuItem,
            this.stopLeadtoolsMedical3DProxyexeToolStripMenuItem,
            this.deleteLeadtoolsMedical3DProxyexeToolStripMenuItem,
            this.registerLeadtoolsMedical3DProxyexeToolStripMenuItem,
            this.toolStripSeparatorExtraOptions3,
            this.installLeadtoolsMedical3DProxyexeToolStripMenuItem});
         this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
         this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
         this.optionsToolStripMenuItem.Text = "Options";
         // 
         // useWCFServiceToolStripMenuItem
         // 
         this.useWCFServiceToolStripMenuItem.Name = "useWCFServiceToolStripMenuItem";
         this.useWCFServiceToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
         this.useWCFServiceToolStripMenuItem.Text = "Use &WCF Service";
         this.useWCFServiceToolStripMenuItem.Click += new System.EventHandler(this.useWCFServiceToolStripMenuItem_Click);
         // 
         // useASPNETServiceToolStripMenuItem
         // 
         this.useASPNETServiceToolStripMenuItem.Name = "useASPNETServiceToolStripMenuItem";
         this.useASPNETServiceToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
         this.useASPNETServiceToolStripMenuItem.Text = "Use &ASP.NET Service";
         this.useASPNETServiceToolStripMenuItem.Click += new System.EventHandler(this.useASPNETServiceToolStripMenuItem_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(275, 6);
         // 
         // create3DServiceInstallerToolStripMenuItem
         // 
         this.create3DServiceInstallerToolStripMenuItem.Name = "create3DServiceInstallerToolStripMenuItem";
         this.create3DServiceInstallerToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
         this.create3DServiceInstallerToolStripMenuItem.Text = "Create Web Service &Installer...";
         this.create3DServiceInstallerToolStripMenuItem.Click += new System.EventHandler(this.create3DServiceInstallerToolStripMenuItem_Click);
         // 
         // configure3DServiceToolStripMenuItem
         // 
         this.configure3DServiceToolStripMenuItem.Name = "configure3DServiceToolStripMenuItem";
         this.configure3DServiceToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
         this.configure3DServiceToolStripMenuItem.Text = "Change Web Service &Location...";
         this.configure3DServiceToolStripMenuItem.Click += new System.EventHandler(this.changeServiceLocationToolStripMenuItem_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(275, 6);
         // 
         // download3DImagesToolStripMenuItem
         // 
         this.download3DImagesToolStripMenuItem.Name = "download3DImagesToolStripMenuItem";
         this.download3DImagesToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
         this.download3DImagesToolStripMenuItem.Text = "Download 3D Images...";
         this.download3DImagesToolStripMenuItem.Click += new System.EventHandler(this.download3DImagesToolStripMenuItem_Click);
         // 
         // toolStripSeparatorExtraOptions
         // 
         this.toolStripSeparatorExtraOptions.Name = "toolStripSeparatorExtraOptions";
         this.toolStripSeparatorExtraOptions.Size = new System.Drawing.Size(275, 6);
         // 
         // silentRegisterToolStripMenuItem
         // 
         this.silentRegisterToolStripMenuItem.Name = "silentRegisterToolStripMenuItem";
         this.silentRegisterToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
         this.silentRegisterToolStripMenuItem.Text = "Silent Register";
         this.silentRegisterToolStripMenuItem.Click += new System.EventHandler(this.silentRegisterToolStripMenuItem_Click);
         // 
         // toolStripSeparatorExtraOptions2
         // 
         this.toolStripSeparatorExtraOptions2.Name = "toolStripSeparatorExtraOptions2";
         this.toolStripSeparatorExtraOptions2.Size = new System.Drawing.Size(275, 6);
         // 
         // startLeadtoolsMedical3DProxyexeToolStripMenuItem
         // 
         this.startLeadtoolsMedical3DProxyexeToolStripMenuItem.Name = "startLeadtoolsMedical3DProxyexeToolStripMenuItem";
         this.startLeadtoolsMedical3DProxyexeToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
         this.startLeadtoolsMedical3DProxyexeToolStripMenuItem.Text = "Start Leadtools.Medical3DProxy.exe";
         this.startLeadtoolsMedical3DProxyexeToolStripMenuItem.Click += new System.EventHandler(this.startLeadtoolsMedical3DProxyexeToolStripMenuItem_Click);
         // 
         // stopLeadtoolsMedical3DProxyexeToolStripMenuItem
         // 
         this.stopLeadtoolsMedical3DProxyexeToolStripMenuItem.Name = "stopLeadtoolsMedical3DProxyexeToolStripMenuItem";
         this.stopLeadtoolsMedical3DProxyexeToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
         this.stopLeadtoolsMedical3DProxyexeToolStripMenuItem.Text = "Stop Leadtools.Medical3DProxy.exe";
         this.stopLeadtoolsMedical3DProxyexeToolStripMenuItem.Click += new System.EventHandler(this.stopLeadtoolsMedical3DProxyexeToolStripMenuItem_Click);
         // 
         // deleteLeadtoolsMedical3DProxyexeToolStripMenuItem
         // 
         this.deleteLeadtoolsMedical3DProxyexeToolStripMenuItem.Name = "deleteLeadtoolsMedical3DProxyexeToolStripMenuItem";
         this.deleteLeadtoolsMedical3DProxyexeToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
         this.deleteLeadtoolsMedical3DProxyexeToolStripMenuItem.Text = "Delete Leadtools.Medical3DProxy.exe";
         this.deleteLeadtoolsMedical3DProxyexeToolStripMenuItem.Click += new System.EventHandler(this.deleteLeadtoolsMedical3DProxyexeToolStripMenuItem_Click);
         // 
         // registerLeadtoolsMedical3DProxyexeToolStripMenuItem
         // 
         this.registerLeadtoolsMedical3DProxyexeToolStripMenuItem.Name = "registerLeadtoolsMedical3DProxyexeToolStripMenuItem";
         this.registerLeadtoolsMedical3DProxyexeToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
         this.registerLeadtoolsMedical3DProxyexeToolStripMenuItem.Text = "Register Leadtools.Medical3DProxy.exe";
         this.registerLeadtoolsMedical3DProxyexeToolStripMenuItem.Click += new System.EventHandler(this.registerLeadtoolsMedical3DProxyexeToolStripMenuItem_Click);
         // 
         // toolStripSeparatorExtraOptions3
         // 
         this.toolStripSeparatorExtraOptions3.Name = "toolStripSeparatorExtraOptions3";
         this.toolStripSeparatorExtraOptions3.Size = new System.Drawing.Size(275, 6);
         // 
         // installLeadtoolsMedical3DProxyexeToolStripMenuItem
         // 
         this.installLeadtoolsMedical3DProxyexeToolStripMenuItem.Name = "installLeadtoolsMedical3DProxyexeToolStripMenuItem";
         this.installLeadtoolsMedical3DProxyexeToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
         this.installLeadtoolsMedical3DProxyexeToolStripMenuItem.Text = "Install Leadtools.Medical3DProxy.exe";
         this.installLeadtoolsMedical3DProxyexeToolStripMenuItem.Click += new System.EventHandler(this.installLeadtoolsMedical3DProxyexeToolStripMenuItem_Click);
         // 
         // buttonOK
         // 
         this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonOK.Location = new System.Drawing.Point(625, 538);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 8;
         this.buttonOK.Text = "OK";
         this.buttonOK.UseVisualStyleBackColor = true;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(712, 588);
         this.Controls.Add(this.menuStrip1);
         this.Controls.Add(this.listViewStatus);
         this.Controls.Add(this.radioButtonDental);
         this.Controls.Add(this.radioButtonMedical);
         this.Controls.Add(this.btnRun);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.btnFix);
         this.Controls.Add(this.buttonOK);
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "Form1";
         this.ShowIcon = false;
         this.Text = "Medical Web Viewer Configuration";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
         this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBoxTroubleShooting.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.contextMenuStrip.ResumeLayout(false);
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Button btnFix;
      private System.Windows.Forms.Label lblConnection;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label lblServerName;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label lblPort;
      private System.Windows.Forms.Label lblIPAddress;
      private System.Windows.Forms.Button btnRun;
      private System.Windows.Forms.RadioButton radioButtonMedical;
      private System.Windows.Forms.RadioButton radioButtonDental;
      private System.Windows.Forms.ListView listViewStatus;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ColumnHeader columnHeader2;
      private System.Windows.Forms.ColumnHeader columnHeader3;
      private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem clearStatusToolStripMenuItem;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem upgradeDatabaseToolStripMenuItem;
      private System.Windows.Forms.GroupBox groupBoxTroubleShooting;
      private System.Windows.Forms.DataGridView dataGridView1;
      private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProblem;
      private System.Windows.Forms.DataGridViewLinkColumn ColumnLink;
      private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem useWCFServiceToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem useASPNETServiceToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem enableRunViewerToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem configure3DServiceToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem create3DServiceInstallerToolStripMenuItem;
      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem silentRegisterToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem download3DImagesToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripMenuItem registerLeadtoolsMedical3DProxyexeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem startLeadtoolsMedical3DProxyexeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem stopLeadtoolsMedical3DProxyexeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem deleteLeadtoolsMedical3DProxyexeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem installLeadtoolsMedical3DProxyexeToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparatorExtraOptions;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparatorExtraOptions2;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparatorExtraOptions3;
   }
}

