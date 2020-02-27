using System.Windows.Forms;
namespace Leadtools.Dicom.Server.Manager
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
           this.toolStripClients = new System.Windows.Forms.ToolStrip();
           this.toolStripButtonViewAssociation = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonDisconnectClient = new System.Windows.Forms.ToolStripButton();
           this.labelServer = new System.Windows.Forms.Label();
           this.tabControl1 = new System.Windows.Forms.TabControl();
           this.tabPageAeTitles = new System.Windows.Forms.TabPage();
           this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
           this.listViewAeTitles = new System.Windows.Forms.ListView();
           this.columnHeaderAeTitle = new System.Windows.Forms.ColumnHeader();
           this.columnHeaderHostname = new System.Windows.Forms.ColumnHeader();
           this.columnHeaderPort = new System.Windows.Forms.ColumnHeader();
           this.columnHeaderSecurePort = new System.Windows.Forms.ColumnHeader();
           this.toolStripAeTitle = new System.Windows.Forms.ToolStrip();
           this.toolStripButtonAddAeTitle = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonEditAeTitle = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonDeleteAeTitle = new System.Windows.Forms.ToolStripButton();
           this.tabPageClients = new System.Windows.Forms.TabPage();
           this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
           this.listViewClients = new System.Windows.Forms.ListView();
           this.columnIpAddress = new System.Windows.Forms.ColumnHeader();
           this.columnAeTitle = new System.Windows.Forms.ColumnHeader();
           this.columnConnectTime = new System.Windows.Forms.ColumnHeader();
           this.columnLastAction = new System.Windows.Forms.ColumnHeader();
           this.toolStripMain = new System.Windows.Forms.ToolStrip();
           this.toolStripButtonAddServer = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonEditServer = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonDeleteServer = new System.Windows.Forms.ToolStripButton();
           this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
           this.toolStripButtonStart = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonPause = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
           this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
           this.toolStripButtonStartAll = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonStopAll = new System.Windows.Forms.ToolStripButton();
           this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
           this.toolStripButtonEventLog = new System.Windows.Forms.ToolStripButton();
           this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
           this.toolStripButtonHelp = new System.Windows.Forms.ToolStripButton();
           this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
           this.contextMenuStripNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
           this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.labelServerIp = new System.Windows.Forms.Label();
           this.labelServerPort = new System.Windows.Forms.Label();
           this.labelIpAddress = new System.Windows.Forms.Label();
           this.labelPort = new System.Windows.Forms.Label();
           this.listViewOptions = new System.Windows.Forms.ListView();
           this.imageListOptions = new System.Windows.Forms.ImageList(this.components);
           this.label2 = new System.Windows.Forms.Label();
           this.labelError = new System.Windows.Forms.Label();
           this.comboBoxService = new Leadtools.Dicom.Server.Manager.ComboBoxImage();
           this.toolTip = new System.Windows.Forms.ToolTip(this.components);
           this.toolStripClients.SuspendLayout();
           this.tabControl1.SuspendLayout();
           this.tabPageAeTitles.SuspendLayout();
           this.toolStripContainer1.ContentPanel.SuspendLayout();
           this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
           this.toolStripContainer1.SuspendLayout();
           this.toolStripAeTitle.SuspendLayout();
           this.tabPageClients.SuspendLayout();
           this.toolStripContainer2.ContentPanel.SuspendLayout();
           this.toolStripContainer2.TopToolStripPanel.SuspendLayout();
           this.toolStripContainer2.SuspendLayout();
           this.toolStripMain.SuspendLayout();
           this.contextMenuStripNotifyIcon.SuspendLayout();
           this.SuspendLayout();
           // 
           // toolStripClients
           // 
           this.toolStripClients.Dock = System.Windows.Forms.DockStyle.None;
           this.toolStripClients.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
           this.toolStripClients.ImageScalingSize = new System.Drawing.Size(32, 32);
           this.toolStripClients.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonViewAssociation,
            this.toolStripButtonDisconnectClient});
           this.toolStripClients.Location = new System.Drawing.Point(0, 0);
           this.toolStripClients.Name = "toolStripClients";
           this.toolStripClients.Size = new System.Drawing.Size(360, 39);
           this.toolStripClients.Stretch = true;
           this.toolStripClients.TabIndex = 3;
           // 
           // toolStripButtonViewAssociation
           // 
           this.toolStripButtonViewAssociation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonViewAssociation.Image = global::Leadtools.Dicom.Server.Manager.Properties.Resources.ClientAssociation_Image;
           this.toolStripButtonViewAssociation.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonViewAssociation.Name = "toolStripButtonViewAssociation";
           this.toolStripButtonViewAssociation.Size = new System.Drawing.Size(36, 36);
           this.toolStripButtonViewAssociation.Text = "View Assocation";
           this.toolStripButtonViewAssociation.Click += new System.EventHandler(this.toolStripButtonViewAssociation_Click);
           // 
           // toolStripButtonDisconnectClient
           // 
           this.toolStripButtonDisconnectClient.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonDisconnectClient.Image = global::Leadtools.Dicom.Server.Manager.Properties.Resources.ClientDisconnect_Image;
           this.toolStripButtonDisconnectClient.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonDisconnectClient.Name = "toolStripButtonDisconnectClient";
           this.toolStripButtonDisconnectClient.Size = new System.Drawing.Size(36, 36);
           this.toolStripButtonDisconnectClient.Text = "Disconnect Client";
           this.toolStripButtonDisconnectClient.Click += new System.EventHandler(this.toolStripButtonDisconnectClient_Click);
           // 
           // labelServer
           // 
           this.labelServer.AutoSize = true;
           this.labelServer.Location = new System.Drawing.Point(10, 37);
           this.labelServer.Name = "labelServer";
           this.labelServer.Size = new System.Drawing.Size(46, 13);
           this.labelServer.TabIndex = 0;
           this.labelServer.Text = "Service:";
           // 
           // tabControl1
           // 
           this.tabControl1.Controls.Add(this.tabPageAeTitles);
           this.tabControl1.Controls.Add(this.tabPageClients);
           this.tabControl1.Location = new System.Drawing.Point(12, 107);
           this.tabControl1.Name = "tabControl1";
           this.tabControl1.SelectedIndex = 0;
           this.tabControl1.Size = new System.Drawing.Size(374, 336);
           this.tabControl1.TabIndex = 11;
           this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
           // 
           // tabPageAeTitles
           // 
           this.tabPageAeTitles.Controls.Add(this.toolStripContainer1);
           this.tabPageAeTitles.Location = new System.Drawing.Point(4, 22);
           this.tabPageAeTitles.Name = "tabPageAeTitles";
           this.tabPageAeTitles.Padding = new System.Windows.Forms.Padding(3);
           this.tabPageAeTitles.Size = new System.Drawing.Size(366, 310);
           this.tabPageAeTitles.TabIndex = 1;
           this.tabPageAeTitles.Text = "Client Nodes";
           this.tabPageAeTitles.UseVisualStyleBackColor = true;
           // 
           // toolStripContainer1
           // 
           this.toolStripContainer1.BottomToolStripPanelVisible = false;
           // 
           // toolStripContainer1.ContentPanel
           // 
           this.toolStripContainer1.ContentPanel.Controls.Add(this.listViewAeTitles);
           this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(360, 265);
           this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
           this.toolStripContainer1.LeftToolStripPanelVisible = false;
           this.toolStripContainer1.Location = new System.Drawing.Point(3, 3);
           this.toolStripContainer1.Name = "toolStripContainer1";
           this.toolStripContainer1.RightToolStripPanelVisible = false;
           this.toolStripContainer1.Size = new System.Drawing.Size(360, 304);
           this.toolStripContainer1.TabIndex = 4;
           this.toolStripContainer1.Text = "toolStripContainer1";
           // 
           // toolStripContainer1.TopToolStripPanel
           // 
           this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripAeTitle);
           // 
           // listViewAeTitles
           // 
           this.listViewAeTitles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAeTitle,
            this.columnHeaderHostname,
            this.columnHeaderPort,
            this.columnHeaderSecurePort});
           this.listViewAeTitles.Dock = System.Windows.Forms.DockStyle.Fill;
           this.listViewAeTitles.FullRowSelect = true;
           this.listViewAeTitles.GridLines = true;
           this.listViewAeTitles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
           this.listViewAeTitles.HideSelection = false;
           this.listViewAeTitles.Location = new System.Drawing.Point(0, 0);
           this.listViewAeTitles.MultiSelect = false;
           this.listViewAeTitles.Name = "listViewAeTitles";
           this.listViewAeTitles.Size = new System.Drawing.Size(360, 265);
           this.listViewAeTitles.TabIndex = 3;
           this.listViewAeTitles.UseCompatibleStateImageBehavior = false;
           this.listViewAeTitles.View = System.Windows.Forms.View.Details;
           this.listViewAeTitles.DoubleClick += new System.EventHandler(this.listViewAeTitles_DoubleClick);
           // 
           // columnHeaderAeTitle
           // 
           this.columnHeaderAeTitle.Text = "AE Title";
           this.columnHeaderAeTitle.Width = 103;
           // 
           // columnHeaderHostname
           // 
           this.columnHeaderHostname.Text = "Address/Host Name";
           this.columnHeaderHostname.Width = 118;
           // 
           // columnHeaderPort
           // 
           this.columnHeaderPort.Text = "Port";
           this.columnHeaderPort.Width = 42;
           // 
           // columnHeaderSecurePort
           // 
           this.columnHeaderSecurePort.Text = "Secure Port";
           this.columnHeaderSecurePort.Width = 100;
           // 
           // toolStripAeTitle
           // 
           this.toolStripAeTitle.Dock = System.Windows.Forms.DockStyle.None;
           this.toolStripAeTitle.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
           this.toolStripAeTitle.ImageScalingSize = new System.Drawing.Size(32, 32);
           this.toolStripAeTitle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddAeTitle,
            this.toolStripButtonEditAeTitle,
            this.toolStripButtonDeleteAeTitle});
           this.toolStripAeTitle.Location = new System.Drawing.Point(0, 0);
           this.toolStripAeTitle.Name = "toolStripAeTitle";
           this.toolStripAeTitle.Size = new System.Drawing.Size(360, 39);
           this.toolStripAeTitle.Stretch = true;
           this.toolStripAeTitle.TabIndex = 6;
           // 
           // toolStripButtonAddAeTitle
           // 
           this.toolStripButtonAddAeTitle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonAddAeTitle.Image = global::Leadtools.Dicom.Server.Manager.Properties.Resources.AeTitleAdd_Image;
           this.toolStripButtonAddAeTitle.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonAddAeTitle.Name = "toolStripButtonAddAeTitle";
           this.toolStripButtonAddAeTitle.Size = new System.Drawing.Size(36, 36);
           this.toolStripButtonAddAeTitle.Text = "Add AE Title";
           this.toolStripButtonAddAeTitle.Click += new System.EventHandler(this.toolStripButtonAddAeTitle_Click);
           // 
           // toolStripButtonEditAeTitle
           // 
           this.toolStripButtonEditAeTitle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonEditAeTitle.Image = global::Leadtools.Dicom.Server.Manager.Properties.Resources.AeTitleEdit_Image;
           this.toolStripButtonEditAeTitle.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonEditAeTitle.Name = "toolStripButtonEditAeTitle";
           this.toolStripButtonEditAeTitle.Size = new System.Drawing.Size(36, 36);
           this.toolStripButtonEditAeTitle.Text = "Edit AE Title";
           this.toolStripButtonEditAeTitle.Click += new System.EventHandler(this.toolStripButtonEditAeTitle_Click);
           // 
           // toolStripButtonDeleteAeTitle
           // 
           this.toolStripButtonDeleteAeTitle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonDeleteAeTitle.Image = global::Leadtools.Dicom.Server.Manager.Properties.Resources.AeTitleDelete_Image;
           this.toolStripButtonDeleteAeTitle.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonDeleteAeTitle.Name = "toolStripButtonDeleteAeTitle";
           this.toolStripButtonDeleteAeTitle.Size = new System.Drawing.Size(36, 36);
           this.toolStripButtonDeleteAeTitle.Text = "Delete AE Title";
           this.toolStripButtonDeleteAeTitle.Click += new System.EventHandler(this.toolStripButtonDeleteAeTitle_Click);
           // 
           // tabPageClients
           // 
           this.tabPageClients.Controls.Add(this.toolStripContainer2);
           this.tabPageClients.Location = new System.Drawing.Point(4, 22);
           this.tabPageClients.Name = "tabPageClients";
           this.tabPageClients.Padding = new System.Windows.Forms.Padding(3);
           this.tabPageClients.Size = new System.Drawing.Size(366, 310);
           this.tabPageClients.TabIndex = 2;
           this.tabPageClients.Text = "Current Connections";
           this.tabPageClients.UseVisualStyleBackColor = true;
           // 
           // toolStripContainer2
           // 
           // 
           // toolStripContainer2.ContentPanel
           // 
           this.toolStripContainer2.ContentPanel.Controls.Add(this.listViewClients);
           this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(360, 265);
           this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
           this.toolStripContainer2.Location = new System.Drawing.Point(3, 3);
           this.toolStripContainer2.Name = "toolStripContainer2";
           this.toolStripContainer2.Size = new System.Drawing.Size(360, 304);
           this.toolStripContainer2.TabIndex = 0;
           this.toolStripContainer2.Text = "toolStripContainer2";
           // 
           // toolStripContainer2.TopToolStripPanel
           // 
           this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.toolStripClients);
           // 
           // listViewClients
           // 
           this.listViewClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnIpAddress,
            this.columnAeTitle,
            this.columnConnectTime,
            this.columnLastAction});
           this.listViewClients.Dock = System.Windows.Forms.DockStyle.Fill;
           this.listViewClients.FullRowSelect = true;
           this.listViewClients.GridLines = true;
           this.listViewClients.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
           this.listViewClients.HideSelection = false;
           this.listViewClients.Location = new System.Drawing.Point(0, 0);
           this.listViewClients.MultiSelect = false;
           this.listViewClients.Name = "listViewClients";
           this.listViewClients.Size = new System.Drawing.Size(360, 265);
           this.listViewClients.TabIndex = 2;
           this.listViewClients.UseCompatibleStateImageBehavior = false;
           this.listViewClients.View = System.Windows.Forms.View.Details;
           // 
           // columnIpAddress
           // 
           this.columnIpAddress.Text = "IP Address";
           this.columnIpAddress.Width = 95;
           // 
           // columnAeTitle
           // 
           this.columnAeTitle.Text = "AETitle";
           this.columnAeTitle.Width = 100;
           // 
           // columnConnectTime
           // 
           this.columnConnectTime.Text = "Connect Time";
           this.columnConnectTime.Width = 100;
           // 
           // columnLastAction
           // 
           this.columnLastAction.Text = "Last Action";
           this.columnLastAction.Width = 150;
           // 
           // toolStripMain
           // 
           this.toolStripMain.ImageScalingSize = new System.Drawing.Size(32, 32);
           this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddServer,
            this.toolStripButtonEditServer,
            this.toolStripButtonDeleteServer,
            this.toolStripSeparator1,
            this.toolStripButtonStart,
            this.toolStripButtonPause,
            this.toolStripButtonStop,
            this.toolStripSeparator2,
            this.toolStripButtonStartAll,
            this.toolStripButtonStopAll,
            this.toolStripSeparator3,
            this.toolStripButtonEventLog,
            this.toolStripSeparator4,
            this.toolStripButtonHelp});
           this.toolStripMain.Location = new System.Drawing.Point(0, 0);
           this.toolStripMain.Name = "toolStripMain";
           this.toolStripMain.Size = new System.Drawing.Size(479, 39);
           this.toolStripMain.TabIndex = 13;
           this.toolStripMain.Text = "toolStrip1";
           // 
           // toolStripButtonAddServer
           // 
           this.toolStripButtonAddServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonAddServer.Image = global::Leadtools.Dicom.Server.Manager.Properties.Resources.ServiceAdd_Image;
           this.toolStripButtonAddServer.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonAddServer.Name = "toolStripButtonAddServer";
           this.toolStripButtonAddServer.Size = new System.Drawing.Size(36, 36);
           this.toolStripButtonAddServer.Text = "toolStripButtonAddServer";
           this.toolStripButtonAddServer.ToolTipText = "Add Server";
           this.toolStripButtonAddServer.Click += new System.EventHandler(this.buttonServiceAdd_Click);
           // 
           // toolStripButtonEditServer
           // 
           this.toolStripButtonEditServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonEditServer.Image = global::Leadtools.Dicom.Server.Manager.Properties.Resources.ServiceEdit_Image;
           this.toolStripButtonEditServer.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonEditServer.Name = "toolStripButtonEditServer";
           this.toolStripButtonEditServer.Size = new System.Drawing.Size(36, 36);
           this.toolStripButtonEditServer.Text = "toolStripButton2";
           this.toolStripButtonEditServer.ToolTipText = "Edit Server";
           this.toolStripButtonEditServer.Click += new System.EventHandler(this.buttonServiceEdit_Click);
           // 
           // toolStripButtonDeleteServer
           // 
           this.toolStripButtonDeleteServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonDeleteServer.Image = global::Leadtools.Dicom.Server.Manager.Properties.Resources.ServiceDelete_Image;
           this.toolStripButtonDeleteServer.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonDeleteServer.Name = "toolStripButtonDeleteServer";
           this.toolStripButtonDeleteServer.Size = new System.Drawing.Size(36, 36);
           this.toolStripButtonDeleteServer.Text = "toolStripButton3";
           this.toolStripButtonDeleteServer.ToolTipText = "Delete Server";
           this.toolStripButtonDeleteServer.Click += new System.EventHandler(this.toolStripButtonDeleteServer_Click);
           // 
           // toolStripSeparator1
           // 
           this.toolStripSeparator1.Name = "toolStripSeparator1";
           this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
           // 
           // toolStripButtonStart
           // 
           this.toolStripButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonStart.Image = global::Leadtools.Dicom.Server.Manager.Properties.Resources.StartService_Image;
           this.toolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonStart.Name = "toolStripButtonStart";
           this.toolStripButtonStart.Size = new System.Drawing.Size(36, 36);
           this.toolStripButtonStart.Text = "toolStripButton4";
           this.toolStripButtonStart.ToolTipText = "Start Server";
           this.toolStripButtonStart.Click += new System.EventHandler(this.buttonStart_Click);
           // 
           // toolStripButtonPause
           // 
           this.toolStripButtonPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonPause.Image = global::Leadtools.Dicom.Server.Manager.Properties.Resources.PauseService_Image;
           this.toolStripButtonPause.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonPause.Name = "toolStripButtonPause";
           this.toolStripButtonPause.Size = new System.Drawing.Size(36, 36);
           this.toolStripButtonPause.Text = "toolStripButton5";
           this.toolStripButtonPause.ToolTipText = "Pause Server";
           this.toolStripButtonPause.Click += new System.EventHandler(this.buttonPause_Click);
           // 
           // toolStripButtonStop
           // 
           this.toolStripButtonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonStop.Image = global::Leadtools.Dicom.Server.Manager.Properties.Resources.StopService_Image;
           this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonStop.Name = "toolStripButtonStop";
           this.toolStripButtonStop.Size = new System.Drawing.Size(36, 36);
           this.toolStripButtonStop.Text = "Stop";
           this.toolStripButtonStop.ToolTipText = "Stop Server";
           this.toolStripButtonStop.Click += new System.EventHandler(this.buttonStop_Click);
           // 
           // toolStripSeparator2
           // 
           this.toolStripSeparator2.Name = "toolStripSeparator2";
           this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
           // 
           // toolStripButtonStartAll
           // 
           this.toolStripButtonStartAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonStartAll.Image = global::Leadtools.Dicom.Server.Manager.Properties.Resources.start_all;
           this.toolStripButtonStartAll.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonStartAll.Name = "toolStripButtonStartAll";
           this.toolStripButtonStartAll.Size = new System.Drawing.Size(36, 36);
           this.toolStripButtonStartAll.Text = "Start All";
           this.toolStripButtonStartAll.ToolTipText = "Start All Servers";
           this.toolStripButtonStartAll.Click += new System.EventHandler(this.toolStripButtonStartAll_Click);
           // 
           // toolStripButtonStopAll
           // 
           this.toolStripButtonStopAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonStopAll.Image = global::Leadtools.Dicom.Server.Manager.Properties.Resources.stop_all;
           this.toolStripButtonStopAll.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonStopAll.Name = "toolStripButtonStopAll";
           this.toolStripButtonStopAll.Size = new System.Drawing.Size(36, 36);
           this.toolStripButtonStopAll.Text = "Stop All";
           this.toolStripButtonStopAll.ToolTipText = "Stop All Servers";
           this.toolStripButtonStopAll.Click += new System.EventHandler(this.toolStripButtonStopAll_Click);
           // 
           // toolStripSeparator3
           // 
           this.toolStripSeparator3.Name = "toolStripSeparator3";
           this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
           // 
           // toolStripButtonEventLog
           // 
           this.toolStripButtonEventLog.CheckOnClick = true;
           this.toolStripButtonEventLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonEventLog.Image = global::Leadtools.Dicom.Server.Manager.Properties.Resources.ActivityReports;
           this.toolStripButtonEventLog.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonEventLog.Name = "toolStripButtonEventLog";
           this.toolStripButtonEventLog.Size = new System.Drawing.Size(36, 36);
           this.toolStripButtonEventLog.Text = "Log";
           this.toolStripButtonEventLog.Click += new System.EventHandler(this.toolStripButtonEventLog_Click);
           // 
           // toolStripSeparator4
           // 
           this.toolStripSeparator4.Name = "toolStripSeparator4";
           this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
           // 
           // toolStripButtonHelp
           // 
           this.toolStripButtonHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonHelp.Image = global::Leadtools.Dicom.Server.Manager.Properties.Resources.Help_Image;
           this.toolStripButtonHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonHelp.Name = "toolStripButtonHelp";
           this.toolStripButtonHelp.Size = new System.Drawing.Size(36, 36);
           this.toolStripButtonHelp.Text = "Help";
           this.toolStripButtonHelp.Click += new System.EventHandler(this.toolStripButtonHelp_Click);
           // 
           // notifyIcon
           // 
           this.notifyIcon.ContextMenuStrip = this.contextMenuStripNotifyIcon;
           this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
           this.notifyIcon.Text = "notifyIcon";
           this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
           // 
           // contextMenuStripNotifyIcon
           // 
           this.contextMenuStripNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
           this.contextMenuStripNotifyIcon.Name = "contextMenuStripNotifyIcon";
           this.contextMenuStripNotifyIcon.Size = new System.Drawing.Size(93, 26);
           // 
           // exitToolStripMenuItem
           // 
           this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
           this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
           this.exitToolStripMenuItem.Text = "&Exit";
           this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
           // 
           // labelServerIp
           // 
           this.labelServerIp.AutoSize = true;
           this.labelServerIp.Location = new System.Drawing.Point(10, 82);
           this.labelServerIp.Name = "labelServerIp";
           this.labelServerIp.Size = new System.Drawing.Size(61, 13);
           this.labelServerIp.TabIndex = 14;
           this.labelServerIp.Text = "IP Address:";
           // 
           // labelServerPort
           // 
           this.labelServerPort.AutoSize = true;
           this.labelServerPort.Location = new System.Drawing.Point(254, 82);
           this.labelServerPort.Name = "labelServerPort";
           this.labelServerPort.Size = new System.Drawing.Size(29, 13);
           this.labelServerPort.TabIndex = 15;
           this.labelServerPort.Text = "Port:";
           // 
           // labelIpAddress
           // 
           this.labelIpAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.labelIpAddress.Location = new System.Drawing.Point(77, 82);
           this.labelIpAddress.Name = "labelIpAddress";
           this.labelIpAddress.Size = new System.Drawing.Size(154, 13);
           this.labelIpAddress.TabIndex = 16;
           this.labelIpAddress.Text = "label4";
           // 
           // labelPort
           // 
           this.labelPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.labelPort.Location = new System.Drawing.Point(289, 82);
           this.labelPort.Name = "labelPort";
           this.labelPort.Size = new System.Drawing.Size(98, 13);
           this.labelPort.TabIndex = 17;
           this.labelPort.Text = "label5";
           // 
           // listViewOptions
           // 
           this.listViewOptions.LargeImageList = this.imageListOptions;
           this.listViewOptions.Location = new System.Drawing.Point(393, 54);
           this.listViewOptions.Name = "listViewOptions";
           this.listViewOptions.Size = new System.Drawing.Size(80, 389);
           this.listViewOptions.TabIndex = 21;
           this.listViewOptions.UseCompatibleStateImageBehavior = false;
           this.listViewOptions.DoubleClick += new System.EventHandler(this.listViewOptions_DoubleClick);
           // 
           // imageListOptions
           // 
           this.imageListOptions.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
           this.imageListOptions.ImageSize = new System.Drawing.Size(32, 32);
           this.imageListOptions.TransparentColor = System.Drawing.Color.Transparent;
           // 
           // label2
           // 
           this.label2.AutoSize = true;
           this.label2.Location = new System.Drawing.Point(390, 39);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(77, 13);
           this.label2.TabIndex = 22;
           this.label2.Text = "AddIn Options:";
           // 
           // labelError
           // 
           this.labelError.AutoSize = true;
           this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.labelError.ForeColor = System.Drawing.Color.Red;
           this.labelError.Location = new System.Drawing.Point(13, 57);
           this.labelError.Name = "labelError";
           this.labelError.Size = new System.Drawing.Size(34, 13);
           this.labelError.TabIndex = 25;
           this.labelError.Text = "Error";
           this.labelError.Visible = false;
           // 
           // comboBoxService
           // 
           this.comboBoxService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this.comboBoxService.FormattingEnabled = true;
           this.comboBoxService.Location = new System.Drawing.Point(13, 54);
           this.comboBoxService.Name = "comboBoxService";
           this.comboBoxService.Size = new System.Drawing.Size(374, 21);
           this.comboBoxService.TabIndex = 12;
           this.comboBoxService.SelectedIndexChanged += new System.EventHandler(this.comboBoxService_SelectedIndexChanged);
           this.comboBoxService.DropDown += new System.EventHandler(this.comboBoxService_DropDown);
           // 
           // MainForm
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(479, 451);
           this.Controls.Add(this.labelError);
           this.Controls.Add(this.label2);
           this.Controls.Add(this.labelIpAddress);
           this.Controls.Add(this.labelPort);
           this.Controls.Add(this.labelServerIp);
           this.Controls.Add(this.labelServerPort);
           this.Controls.Add(this.comboBoxService);
           this.Controls.Add(this.labelServer);
           this.Controls.Add(this.toolStripMain);
           this.Controls.Add(this.listViewOptions);
           this.Controls.Add(this.tabControl1);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
           this.MaximizeBox = false;
           this.Name = "MainForm";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
           this.Text = "LEADTOOLS DICOM Server Manager - C#";
           this.Load += new System.EventHandler(this.MainForm_Load);
           this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
           this.Shown += new System.EventHandler(this.MainForm_Shown);
           this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
           this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
           this.toolStripClients.ResumeLayout(false);
           this.toolStripClients.PerformLayout();
           this.tabControl1.ResumeLayout(false);
           this.tabPageAeTitles.ResumeLayout(false);
           this.toolStripContainer1.ContentPanel.ResumeLayout(false);
           this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
           this.toolStripContainer1.TopToolStripPanel.PerformLayout();
           this.toolStripContainer1.ResumeLayout(false);
           this.toolStripContainer1.PerformLayout();
           this.toolStripAeTitle.ResumeLayout(false);
           this.toolStripAeTitle.PerformLayout();
           this.tabPageClients.ResumeLayout(false);
           this.toolStripContainer2.ContentPanel.ResumeLayout(false);
           this.toolStripContainer2.TopToolStripPanel.ResumeLayout(false);
           this.toolStripContainer2.TopToolStripPanel.PerformLayout();
           this.toolStripContainer2.ResumeLayout(false);
           this.toolStripContainer2.PerformLayout();
           this.toolStripMain.ResumeLayout(false);
           this.toolStripMain.PerformLayout();
           this.contextMenuStripNotifyIcon.ResumeLayout(false);
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageAeTitles;
        private System.Windows.Forms.ListView listViewAeTitles;
        private System.Windows.Forms.ColumnHeader columnHeaderAeTitle;
        private System.Windows.Forms.ColumnHeader columnHeaderHostname;
        private System.Windows.Forms.ColumnHeader columnHeaderPort;
        private System.Windows.Forms.ColumnHeader columnHeaderSecurePort;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStripAeTitle;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddAeTitle;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditAeTitle;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteAeTitle;
        private ComboBoxImage comboBoxService;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddServer;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditServer;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteServer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonStart;
        private System.Windows.Forms.ToolStripButton toolStripButtonPause;
        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
        private System.Windows.Forms.TabPage tabPageClients;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private System.Windows.Forms.ListView listViewClients;
        private System.Windows.Forms.ColumnHeader columnIpAddress;
        private System.Windows.Forms.ColumnHeader columnAeTitle;
        private System.Windows.Forms.ColumnHeader columnConnectTime;
        private System.Windows.Forms.ToolStripButton toolStripButtonViewAssociation;
        private System.Windows.Forms.ToolStripButton toolStripButtonDisconnectClient;
        private System.Windows.Forms.Label labelServerIp;
        private System.Windows.Forms.Label labelServerPort;
        private System.Windows.Forms.Label labelIpAddress;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.ColumnHeader columnLastAction;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonStartAll;
        private System.Windows.Forms.ToolStripButton toolStripButtonStopAll;
        private ToolStrip toolStripClients;
        private ListView listViewOptions;
        private Label label2;
        private ImageList imageListOptions;
        private Label labelError;
       private ToolStripButton toolStripButtonHelp;
       private ToolStripSeparator toolStripSeparator3;
       private ToolStripButton toolStripButtonEventLog;
       private ToolStripSeparator toolStripSeparator4;
       private ToolTip toolTip;
    }
}

