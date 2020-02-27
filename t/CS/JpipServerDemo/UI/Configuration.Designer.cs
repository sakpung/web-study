namespace JpipServerDemo
{
   partial class Configuration
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
         this.tbcMain = new System.Windows.Forms.TabControl();
         this.tbpServer = new System.Windows.Forms.TabPage();
         this.chkServerUnlimitedBandWidth = new System.Windows.Forms.CheckBox();
         this.grpALiases = new System.Windows.Forms.GroupBox();
         this.btnBrowsePath = new System.Windows.Forms.Button();
         this.txtAliasPath = new System.Windows.Forms.TextBox();
         this.txtAlias = new System.Windows.Forms.TextBox();
         this.lblPath = new System.Windows.Forms.Label();
         this.lblAlias = new System.Windows.Forms.Label();
         this.btnAdd = new System.Windows.Forms.Button();
         this.btnRemove = new System.Windows.Forms.Button();
         this.lsvAliases = new System.Windows.Forms.ListView();
         this.clmhALias = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.clmhPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.label1 = new System.Windows.Forms.Label();
         this.mtxtServerBandwidth = new System.Windows.Forms.MaskedTextBox();
         this.lbMaxlSeverBandwidth = new System.Windows.Forms.Label();
         this.lblCacheSizeMB = new System.Windows.Forms.Label();
         this.mtxtCacheSize = new System.Windows.Forms.MaskedTextBox();
         this.lblCacheSize = new System.Windows.Forms.Label();
         this.btnBrowseCache = new System.Windows.Forms.Button();
         this.txtCacheFolder = new System.Windows.Forms.TextBox();
         this.lblCacheFolder = new System.Windows.Forms.Label();
         this.btnBrowseImages = new System.Windows.Forms.Button();
         this.txtImagesFolder = new System.Windows.Forms.TextBox();
         this.lblImages = new System.Windows.Forms.Label();
         this.mtxtPort = new System.Windows.Forms.MaskedTextBox();
         this.lblPort = new System.Windows.Forms.Label();
         this.txtIpAddress = new System.Windows.Forms.TextBox();
         this.lblIpAddress = new System.Windows.Forms.Label();
         this.lblServerName = new System.Windows.Forms.Label();
         this.txtServerName = new System.Windows.Forms.TextBox();
         this.tbpClients = new System.Windows.Forms.TabPage();
         this.chkClientUnlimitedBandWidth = new System.Windows.Forms.CheckBox();
         this.lblConnectionIdleSeconds = new System.Windows.Forms.Label();
         this.mtxtConnectionIdleTimeout = new System.Windows.Forms.MaskedTextBox();
         this.lblConnectionIdle = new System.Windows.Forms.Label();
         this.lblConnectionBWKBS = new System.Windows.Forms.Label();
         this.mtxtConnectionBW = new System.Windows.Forms.MaskedTextBox();
         this.lblConnectionBW = new System.Windows.Forms.Label();
         this.lblSessionLifeSeconds = new System.Windows.Forms.Label();
         this.mtxtMaxSessionLife = new System.Windows.Forms.MaskedTextBox();
         this.lblMaxSessionLife = new System.Windows.Forms.Label();
         this.mtxtMaxClients = new System.Windows.Forms.MaskedTextBox();
         this.lblMaxClients = new System.Windows.Forms.Label();
         this.tbpCommunication = new System.Windows.Forms.TabPage();
         this.chkCommunicationUnlimitedRequest = new System.Windows.Forms.CheckBox();
         this.lblChunkBytes = new System.Windows.Forms.Label();
         this.lblChunkSize = new System.Windows.Forms.Label();
         this.mtxtChunkSize = new System.Windows.Forms.MaskedTextBox();
         this.lblRequestTimeoutSeconds = new System.Windows.Forms.Label();
         this.lblRequesttimeout = new System.Windows.Forms.Label();
         this.mtxtRequestTimeout = new System.Windows.Forms.MaskedTextBox();
         this.lblHandshaketimeoutSeconds = new System.Windows.Forms.Label();
         this.lblHandshakeTimeout = new System.Windows.Forms.Label();
         this.mtxtHandshakeTimeout = new System.Windows.Forms.MaskedTextBox();
         this.lblMaxTRansport = new System.Windows.Forms.Label();
         this.mtxtMaxTransport = new System.Windows.Forms.MaskedTextBox();
         this.tbpImages = new System.Windows.Forms.TabPage();
         this.chkImageParsingTimeout = new System.Windows.Forms.CheckBox();
         this.mtxtPartitionSize = new System.Windows.Forms.MaskedTextBox();
         this.lblPartitionSizeBytes = new System.Windows.Forms.Label();
         this.lblPartionSize = new System.Windows.Forms.Label();
         this.lblParsingTimeoutSeconds = new System.Windows.Forms.Label();
         this.chkDivideSuperBoxes = new System.Windows.Forms.CheckBox();
         this.mtxtParsingTimeout = new System.Windows.Forms.MaskedTextBox();
         this.lblParsingTimeout = new System.Windows.Forms.Label();
         this.tbpLoggin = new System.Windows.Forms.TabPage();
         this.grpFileLog = new System.Windows.Forms.GroupBox();
         this.button1 = new System.Windows.Forms.Button();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.chkLogInformation = new System.Windows.Forms.CheckBox();
         this.chkLogDebug = new System.Windows.Forms.CheckBox();
         this.chkLogWarnings = new System.Windows.Forms.CheckBox();
         this.chkLogErrors = new System.Windows.Forms.CheckBox();
         this.txtLogFile = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.chkEnableLog = new System.Windows.Forms.CheckBox();
         this.tbpServerDelegation = new System.Windows.Forms.TabPage();
         this.mtxtDelegatedServerLoad = new System.Windows.Forms.MaskedTextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.mtxtDelegatedServerPort = new System.Windows.Forms.MaskedTextBox();
         this.txtDelegatedServerIP = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.btnAddDelegatedServer = new System.Windows.Forms.Button();
         this.btnRemoveDelegatedServer = new System.Windows.Forms.Button();
         this.lsvServers = new System.Windows.Forms.ListView();
         this.clmServerIp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.clmServerPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.clmServerLoad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.btnOK = new System.Windows.Forms.Button();
         this.btnApply = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
         this.btnReset = new System.Windows.Forms.Button();
         this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
         this.btnImportImage = new System.Windows.Forms.Button();
         this.tbcMain.SuspendLayout();
         this.tbpServer.SuspendLayout();
         this.grpALiases.SuspendLayout();
         this.tbpClients.SuspendLayout();
         this.tbpCommunication.SuspendLayout();
         this.tbpImages.SuspendLayout();
         this.tbpLoggin.SuspendLayout();
         this.grpFileLog.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.tbpServerDelegation.SuspendLayout();
         this.SuspendLayout();
         // 
         // tbcMain
         // 
         this.tbcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tbcMain.Controls.Add(this.tbpServer);
         this.tbcMain.Controls.Add(this.tbpClients);
         this.tbcMain.Controls.Add(this.tbpCommunication);
         this.tbcMain.Controls.Add(this.tbpImages);
         this.tbcMain.Controls.Add(this.tbpLoggin);
         this.tbcMain.Controls.Add(this.tbpServerDelegation);
         this.tbcMain.Location = new System.Drawing.Point(-2, 7);
         this.tbcMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.tbcMain.Name = "tbcMain";
         this.tbcMain.SelectedIndex = 0;
         this.tbcMain.Size = new System.Drawing.Size(509, 415);
         this.tbcMain.TabIndex = 0;
         // 
         // tbpServer
         // 
         this.tbpServer.Controls.Add(this.btnImportImage);
         this.tbpServer.Controls.Add(this.chkServerUnlimitedBandWidth);
         this.tbpServer.Controls.Add(this.grpALiases);
         this.tbpServer.Controls.Add(this.label1);
         this.tbpServer.Controls.Add(this.mtxtServerBandwidth);
         this.tbpServer.Controls.Add(this.lbMaxlSeverBandwidth);
         this.tbpServer.Controls.Add(this.lblCacheSizeMB);
         this.tbpServer.Controls.Add(this.mtxtCacheSize);
         this.tbpServer.Controls.Add(this.lblCacheSize);
         this.tbpServer.Controls.Add(this.btnBrowseCache);
         this.tbpServer.Controls.Add(this.txtCacheFolder);
         this.tbpServer.Controls.Add(this.lblCacheFolder);
         this.tbpServer.Controls.Add(this.btnBrowseImages);
         this.tbpServer.Controls.Add(this.txtImagesFolder);
         this.tbpServer.Controls.Add(this.lblImages);
         this.tbpServer.Controls.Add(this.mtxtPort);
         this.tbpServer.Controls.Add(this.lblPort);
         this.tbpServer.Controls.Add(this.txtIpAddress);
         this.tbpServer.Controls.Add(this.lblIpAddress);
         this.tbpServer.Controls.Add(this.lblServerName);
         this.tbpServer.Controls.Add(this.txtServerName);
         this.tbpServer.Location = new System.Drawing.Point(4, 22);
         this.tbpServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.tbpServer.Name = "tbpServer";
         this.tbpServer.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.tbpServer.Size = new System.Drawing.Size(501, 389);
         this.tbpServer.TabIndex = 0;
         this.tbpServer.Text = "Server Settings";
         this.tbpServer.UseVisualStyleBackColor = true;
         // 
         // chkServerUnlimitedBandWidth
         // 
         this.chkServerUnlimitedBandWidth.AutoSize = true;
         this.chkServerUnlimitedBandWidth.Checked = true;
         this.chkServerUnlimitedBandWidth.CheckState = System.Windows.Forms.CheckState.Checked;
         this.chkServerUnlimitedBandWidth.Location = new System.Drawing.Point(255, 147);
         this.chkServerUnlimitedBandWidth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.chkServerUnlimitedBandWidth.Name = "chkServerUnlimitedBandWidth";
         this.chkServerUnlimitedBandWidth.Size = new System.Drawing.Size(69, 17);
         this.chkServerUnlimitedBandWidth.TabIndex = 19;
         this.chkServerUnlimitedBandWidth.Text = "Unlimited";
         this.chkServerUnlimitedBandWidth.UseVisualStyleBackColor = true;
         this.chkServerUnlimitedBandWidth.CheckedChanged += new System.EventHandler(this.chkServerUnlimitedBandWidth_CheckedChanged);
         // 
         // grpALiases
         // 
         this.grpALiases.Controls.Add(this.btnBrowsePath);
         this.grpALiases.Controls.Add(this.txtAliasPath);
         this.grpALiases.Controls.Add(this.txtAlias);
         this.grpALiases.Controls.Add(this.lblPath);
         this.grpALiases.Controls.Add(this.lblAlias);
         this.grpALiases.Controls.Add(this.btnAdd);
         this.grpALiases.Controls.Add(this.btnRemove);
         this.grpALiases.Controls.Add(this.lsvAliases);
         this.grpALiases.Location = new System.Drawing.Point(8, 198);
         this.grpALiases.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.grpALiases.Name = "grpALiases";
         this.grpALiases.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.grpALiases.Size = new System.Drawing.Size(479, 144);
         this.grpALiases.TabIndex = 18;
         this.grpALiases.TabStop = false;
         this.grpALiases.Text = "Alias Folders";
         // 
         // btnBrowsePath
         // 
         this.btnBrowsePath.Location = new System.Drawing.Point(449, 14);
         this.btnBrowsePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.btnBrowsePath.Name = "btnBrowsePath";
         this.btnBrowsePath.Size = new System.Drawing.Size(25, 19);
         this.btnBrowsePath.TabIndex = 4;
         this.btnBrowsePath.Text = "...";
         this.btnBrowsePath.UseVisualStyleBackColor = true;
         this.btnBrowsePath.Click += new System.EventHandler(this.btnBrowsePath_Click);
         // 
         // txtAliasPath
         // 
         this.txtAliasPath.Location = new System.Drawing.Point(196, 14);
         this.txtAliasPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.txtAliasPath.Name = "txtAliasPath";
         this.txtAliasPath.Size = new System.Drawing.Size(248, 20);
         this.txtAliasPath.TabIndex = 3;
         // 
         // txtAlias
         // 
         this.txtAlias.Location = new System.Drawing.Point(39, 14);
         this.txtAlias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.txtAlias.Name = "txtAlias";
         this.txtAlias.Size = new System.Drawing.Size(117, 20);
         this.txtAlias.TabIndex = 1;
         // 
         // lblPath
         // 
         this.lblPath.AutoSize = true;
         this.lblPath.Location = new System.Drawing.Point(161, 17);
         this.lblPath.Name = "lblPath";
         this.lblPath.Size = new System.Drawing.Size(32, 13);
         this.lblPath.TabIndex = 2;
         this.lblPath.Text = "Pa&th:";
         // 
         // lblAlias
         // 
         this.lblAlias.AutoSize = true;
         this.lblAlias.Location = new System.Drawing.Point(6, 17);
         this.lblAlias.Name = "lblAlias";
         this.lblAlias.Size = new System.Drawing.Size(32, 13);
         this.lblAlias.TabIndex = 0;
         this.lblAlias.Text = "&Alias:";
         // 
         // btnAdd
         // 
         this.btnAdd.Location = new System.Drawing.Point(5, 38);
         this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.btnAdd.Name = "btnAdd";
         this.btnAdd.Size = new System.Drawing.Size(64, 26);
         this.btnAdd.TabIndex = 5;
         this.btnAdd.Text = "A&dd";
         this.btnAdd.UseVisualStyleBackColor = true;
         this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
         // 
         // btnRemove
         // 
         this.btnRemove.Location = new System.Drawing.Point(5, 68);
         this.btnRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.btnRemove.Name = "btnRemove";
         this.btnRemove.Size = new System.Drawing.Size(64, 26);
         this.btnRemove.TabIndex = 6;
         this.btnRemove.Text = "&Remove";
         this.btnRemove.UseVisualStyleBackColor = true;
         this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
         // 
         // lsvAliases
         // 
         this.lsvAliases.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmhALias,
            this.clmhPath});
         this.lsvAliases.FullRowSelect = true;
         this.lsvAliases.Location = new System.Drawing.Point(75, 38);
         this.lsvAliases.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.lsvAliases.Name = "lsvAliases";
         this.lsvAliases.Size = new System.Drawing.Size(370, 95);
         this.lsvAliases.TabIndex = 7;
         this.lsvAliases.UseCompatibleStateImageBehavior = false;
         this.lsvAliases.View = System.Windows.Forms.View.Details;
         // 
         // clmhALias
         // 
         this.clmhALias.Text = "Alias";
         this.clmhALias.Width = 138;
         // 
         // clmhPath
         // 
         this.clmhPath.Text = "Path";
         this.clmhPath.Width = 278;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(227, 148);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(24, 13);
         this.label1.TabIndex = 14;
         this.label1.Text = "B/s";
         // 
         // mtxtServerBandwidth
         // 
         this.mtxtServerBandwidth.HidePromptOnLeave = true;
         this.mtxtServerBandwidth.Location = new System.Drawing.Point(138, 143);
         this.mtxtServerBandwidth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.mtxtServerBandwidth.Mask = "0000000000";
         this.mtxtServerBandwidth.Name = "mtxtServerBandwidth";
         this.mtxtServerBandwidth.Size = new System.Drawing.Size(86, 20);
         this.mtxtServerBandwidth.TabIndex = 13;
         // 
         // lbMaxlSeverBandwidth
         // 
         this.lbMaxlSeverBandwidth.AutoSize = true;
         this.lbMaxlSeverBandwidth.Location = new System.Drawing.Point(6, 147);
         this.lbMaxlSeverBandwidth.Name = "lbMaxlSeverBandwidth";
         this.lbMaxlSeverBandwidth.Size = new System.Drawing.Size(120, 13);
         this.lbMaxlSeverBandwidth.TabIndex = 12;
         this.lbMaxlSeverBandwidth.Text = "Ma&x. Server Bandwidth:";
         // 
         // lblCacheSizeMB
         // 
         this.lblCacheSizeMB.AutoSize = true;
         this.lblCacheSizeMB.Location = new System.Drawing.Point(227, 170);
         this.lblCacheSizeMB.Name = "lblCacheSizeMB";
         this.lblCacheSizeMB.Size = new System.Drawing.Size(23, 13);
         this.lblCacheSizeMB.TabIndex = 17;
         this.lblCacheSizeMB.Text = "MB";
         // 
         // mtxtCacheSize
         // 
         this.mtxtCacheSize.HidePromptOnLeave = true;
         this.mtxtCacheSize.Location = new System.Drawing.Point(138, 166);
         this.mtxtCacheSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.mtxtCacheSize.Mask = "00000";
         this.mtxtCacheSize.Name = "mtxtCacheSize";
         this.mtxtCacheSize.Size = new System.Drawing.Size(86, 20);
         this.mtxtCacheSize.TabIndex = 16;
         this.mtxtCacheSize.ValidatingType = typeof(int);
         // 
         // lblCacheSize
         // 
         this.lblCacheSize.AutoSize = true;
         this.lblCacheSize.Location = new System.Drawing.Point(6, 169);
         this.lblCacheSize.Name = "lblCacheSize";
         this.lblCacheSize.Size = new System.Drawing.Size(64, 13);
         this.lblCacheSize.TabIndex = 15;
         this.lblCacheSize.Text = "Cache &Size:";
         // 
         // btnBrowseCache
         // 
         this.btnBrowseCache.Location = new System.Drawing.Point(415, 80);
         this.btnBrowseCache.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.btnBrowseCache.Name = "btnBrowseCache";
         this.btnBrowseCache.Size = new System.Drawing.Size(25, 19);
         this.btnBrowseCache.TabIndex = 11;
         this.btnBrowseCache.Text = "...";
         this.btnBrowseCache.UseVisualStyleBackColor = true;
         this.btnBrowseCache.Click += new System.EventHandler(this.btnBrowseCache_Click);
         // 
         // txtCacheFolder
         // 
         this.txtCacheFolder.Location = new System.Drawing.Point(90, 80);
         this.txtCacheFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.txtCacheFolder.Name = "txtCacheFolder";
         this.txtCacheFolder.Size = new System.Drawing.Size(320, 20);
         this.txtCacheFolder.TabIndex = 10;
         // 
         // lblCacheFolder
         // 
         this.lblCacheFolder.AutoSize = true;
         this.lblCacheFolder.Location = new System.Drawing.Point(5, 80);
         this.lblCacheFolder.Name = "lblCacheFolder";
         this.lblCacheFolder.Size = new System.Drawing.Size(73, 13);
         this.lblCacheFolder.TabIndex = 9;
         this.lblCacheFolder.Text = "&Cache Folder:";
         // 
         // btnBrowseImages
         // 
         this.btnBrowseImages.Location = new System.Drawing.Point(415, 58);
         this.btnBrowseImages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.btnBrowseImages.Name = "btnBrowseImages";
         this.btnBrowseImages.Size = new System.Drawing.Size(25, 19);
         this.btnBrowseImages.TabIndex = 8;
         this.btnBrowseImages.Text = "...";
         this.btnBrowseImages.UseVisualStyleBackColor = true;
         this.btnBrowseImages.Click += new System.EventHandler(this.btnBrowseImages_Click);
         // 
         // txtImagesFolder
         // 
         this.txtImagesFolder.Location = new System.Drawing.Point(90, 57);
         this.txtImagesFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.txtImagesFolder.Name = "txtImagesFolder";
         this.txtImagesFolder.Size = new System.Drawing.Size(320, 20);
         this.txtImagesFolder.TabIndex = 7;
         // 
         // lblImages
         // 
         this.lblImages.AutoSize = true;
         this.lblImages.Location = new System.Drawing.Point(5, 57);
         this.lblImages.Name = "lblImages";
         this.lblImages.Size = new System.Drawing.Size(76, 13);
         this.lblImages.TabIndex = 6;
         this.lblImages.Text = "Images &Folder:";
         // 
         // mtxtPort
         // 
         this.mtxtPort.HidePromptOnLeave = true;
         this.mtxtPort.Location = new System.Drawing.Point(324, 32);
         this.mtxtPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.mtxtPort.Mask = "00000";
         this.mtxtPort.Name = "mtxtPort";
         this.mtxtPort.Size = new System.Drawing.Size(86, 20);
         this.mtxtPort.TabIndex = 5;
         this.mtxtPort.ValidatingType = typeof(int);
         // 
         // lblPort
         // 
         this.lblPort.AutoSize = true;
         this.lblPort.Location = new System.Drawing.Point(285, 35);
         this.lblPort.Name = "lblPort";
         this.lblPort.Size = new System.Drawing.Size(29, 13);
         this.lblPort.TabIndex = 4;
         this.lblPort.Text = "&Port:";
         // 
         // txtIpAddress
         // 
         this.txtIpAddress.Location = new System.Drawing.Point(90, 32);
         this.txtIpAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.txtIpAddress.Name = "txtIpAddress";
         this.txtIpAddress.Size = new System.Drawing.Size(190, 20);
         this.txtIpAddress.TabIndex = 3;
         this.txtIpAddress.Validating += new System.ComponentModel.CancelEventHandler(this.txtIpAddress_Validating);
         // 
         // lblIpAddress
         // 
         this.lblIpAddress.AutoSize = true;
         this.lblIpAddress.Location = new System.Drawing.Point(6, 32);
         this.lblIpAddress.Name = "lblIpAddress";
         this.lblIpAddress.Size = new System.Drawing.Size(61, 13);
         this.lblIpAddress.TabIndex = 2;
         this.lblIpAddress.Text = "&IP Address:";
         // 
         // lblServerName
         // 
         this.lblServerName.AutoSize = true;
         this.lblServerName.Location = new System.Drawing.Point(6, 8);
         this.lblServerName.Name = "lblServerName";
         this.lblServerName.Size = new System.Drawing.Size(38, 13);
         this.lblServerName.TabIndex = 0;
         this.lblServerName.Text = "&Name:";
         // 
         // txtServerName
         // 
         this.txtServerName.Location = new System.Drawing.Point(90, 8);
         this.txtServerName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.txtServerName.Name = "txtServerName";
         this.txtServerName.Size = new System.Drawing.Size(190, 20);
         this.txtServerName.TabIndex = 1;
         // 
         // tbpClients
         // 
         this.tbpClients.Controls.Add(this.chkClientUnlimitedBandWidth);
         this.tbpClients.Controls.Add(this.lblConnectionIdleSeconds);
         this.tbpClients.Controls.Add(this.mtxtConnectionIdleTimeout);
         this.tbpClients.Controls.Add(this.lblConnectionIdle);
         this.tbpClients.Controls.Add(this.lblConnectionBWKBS);
         this.tbpClients.Controls.Add(this.mtxtConnectionBW);
         this.tbpClients.Controls.Add(this.lblConnectionBW);
         this.tbpClients.Controls.Add(this.lblSessionLifeSeconds);
         this.tbpClients.Controls.Add(this.mtxtMaxSessionLife);
         this.tbpClients.Controls.Add(this.lblMaxSessionLife);
         this.tbpClients.Controls.Add(this.mtxtMaxClients);
         this.tbpClients.Controls.Add(this.lblMaxClients);
         this.tbpClients.Location = new System.Drawing.Point(4, 22);
         this.tbpClients.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.tbpClients.Name = "tbpClients";
         this.tbpClients.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.tbpClients.Size = new System.Drawing.Size(501, 337);
         this.tbpClients.TabIndex = 1;
         this.tbpClients.Text = "Clients Settings";
         this.tbpClients.UseVisualStyleBackColor = true;
         // 
         // chkClientUnlimitedBandWidth
         // 
         this.chkClientUnlimitedBandWidth.AutoSize = true;
         this.chkClientUnlimitedBandWidth.Checked = true;
         this.chkClientUnlimitedBandWidth.CheckState = System.Windows.Forms.CheckState.Checked;
         this.chkClientUnlimitedBandWidth.Location = new System.Drawing.Point(279, 73);
         this.chkClientUnlimitedBandWidth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.chkClientUnlimitedBandWidth.Name = "chkClientUnlimitedBandWidth";
         this.chkClientUnlimitedBandWidth.Size = new System.Drawing.Size(69, 17);
         this.chkClientUnlimitedBandWidth.TabIndex = 11;
         this.chkClientUnlimitedBandWidth.Text = "Unlimited";
         this.chkClientUnlimitedBandWidth.UseVisualStyleBackColor = true;
         this.chkClientUnlimitedBandWidth.CheckedChanged += new System.EventHandler(this.chkClientUnlimitedBandWidth_CheckedChanged);
         // 
         // lblConnectionIdleSeconds
         // 
         this.lblConnectionIdleSeconds.AutoSize = true;
         this.lblConnectionIdleSeconds.Location = new System.Drawing.Point(251, 28);
         this.lblConnectionIdleSeconds.Name = "lblConnectionIdleSeconds";
         this.lblConnectionIdleSeconds.Size = new System.Drawing.Size(49, 13);
         this.lblConnectionIdleSeconds.TabIndex = 4;
         this.lblConnectionIdleSeconds.Text = "Seconds";
         // 
         // mtxtConnectionIdleTimeout
         // 
         this.mtxtConnectionIdleTimeout.HidePromptOnLeave = true;
         this.mtxtConnectionIdleTimeout.Location = new System.Drawing.Point(163, 28);
         this.mtxtConnectionIdleTimeout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.mtxtConnectionIdleTimeout.Mask = "0000000";
         this.mtxtConnectionIdleTimeout.Name = "mtxtConnectionIdleTimeout";
         this.mtxtConnectionIdleTimeout.Size = new System.Drawing.Size(86, 20);
         this.mtxtConnectionIdleTimeout.TabIndex = 3;
         this.mtxtConnectionIdleTimeout.ValidatingType = typeof(int);
         // 
         // lblConnectionIdle
         // 
         this.lblConnectionIdle.AutoSize = true;
         this.lblConnectionIdle.Location = new System.Drawing.Point(5, 32);
         this.lblConnectionIdle.Name = "lblConnectionIdle";
         this.lblConnectionIdle.Size = new System.Drawing.Size(119, 13);
         this.lblConnectionIdle.TabIndex = 2;
         this.lblConnectionIdle.Text = "&Connection Idle Timout:";
         // 
         // lblConnectionBWKBS
         // 
         this.lblConnectionBWKBS.AutoSize = true;
         this.lblConnectionBWKBS.Location = new System.Drawing.Point(251, 73);
         this.lblConnectionBWKBS.Name = "lblConnectionBWKBS";
         this.lblConnectionBWKBS.Size = new System.Drawing.Size(24, 13);
         this.lblConnectionBWKBS.TabIndex = 10;
         this.lblConnectionBWKBS.Text = "B/s";
         // 
         // mtxtConnectionBW
         // 
         this.mtxtConnectionBW.HidePromptOnLeave = true;
         this.mtxtConnectionBW.Location = new System.Drawing.Point(162, 73);
         this.mtxtConnectionBW.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.mtxtConnectionBW.Mask = "0000000000";
         this.mtxtConnectionBW.Name = "mtxtConnectionBW";
         this.mtxtConnectionBW.Size = new System.Drawing.Size(86, 20);
         this.mtxtConnectionBW.TabIndex = 9;
         this.mtxtConnectionBW.ValidatingType = typeof(int);
         // 
         // lblConnectionBW
         // 
         this.lblConnectionBW.AutoSize = true;
         this.lblConnectionBW.Location = new System.Drawing.Point(5, 76);
         this.lblConnectionBW.Name = "lblConnectionBW";
         this.lblConnectionBW.Size = new System.Drawing.Size(143, 13);
         this.lblConnectionBW.TabIndex = 8;
         this.lblConnectionBW.Text = "Ma&x. Connection Bandwidth:";
         // 
         // lblSessionLifeSeconds
         // 
         this.lblSessionLifeSeconds.AutoSize = true;
         this.lblSessionLifeSeconds.Location = new System.Drawing.Point(251, 50);
         this.lblSessionLifeSeconds.Name = "lblSessionLifeSeconds";
         this.lblSessionLifeSeconds.Size = new System.Drawing.Size(49, 13);
         this.lblSessionLifeSeconds.TabIndex = 7;
         this.lblSessionLifeSeconds.Text = "Seconds";
         // 
         // mtxtMaxSessionLife
         // 
         this.mtxtMaxSessionLife.HidePromptOnLeave = true;
         this.mtxtMaxSessionLife.Location = new System.Drawing.Point(162, 50);
         this.mtxtMaxSessionLife.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.mtxtMaxSessionLife.Mask = "0000000000";
         this.mtxtMaxSessionLife.Name = "mtxtMaxSessionLife";
         this.mtxtMaxSessionLife.Size = new System.Drawing.Size(86, 20);
         this.mtxtMaxSessionLife.TabIndex = 6;
         this.mtxtMaxSessionLife.ValidatingType = typeof(int);
         // 
         // lblMaxSessionLife
         // 
         this.lblMaxSessionLife.AutoSize = true;
         this.lblMaxSessionLife.Location = new System.Drawing.Point(6, 54);
         this.lblMaxSessionLife.Name = "lblMaxSessionLife";
         this.lblMaxSessionLife.Size = new System.Drawing.Size(112, 13);
         this.lblMaxSessionLife.TabIndex = 5;
         this.lblMaxSessionLife.Text = "M&ax. Session Lifetime:";
         // 
         // mtxtMaxClients
         // 
         this.mtxtMaxClients.HidePromptOnLeave = true;
         this.mtxtMaxClients.Location = new System.Drawing.Point(162, 6);
         this.mtxtMaxClients.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.mtxtMaxClients.Mask = "00000";
         this.mtxtMaxClients.Name = "mtxtMaxClients";
         this.mtxtMaxClients.Size = new System.Drawing.Size(86, 20);
         this.mtxtMaxClients.TabIndex = 1;
         this.mtxtMaxClients.ValidatingType = typeof(int);
         // 
         // lblMaxClients
         // 
         this.lblMaxClients.AutoSize = true;
         this.lblMaxClients.Location = new System.Drawing.Point(5, 10);
         this.lblMaxClients.Name = "lblMaxClients";
         this.lblMaxClients.Size = new System.Drawing.Size(98, 13);
         this.lblMaxClients.TabIndex = 0;
         this.lblMaxClients.Text = "&Max. Clients Count:";
         // 
         // tbpCommunication
         // 
         this.tbpCommunication.Controls.Add(this.chkCommunicationUnlimitedRequest);
         this.tbpCommunication.Controls.Add(this.lblChunkBytes);
         this.tbpCommunication.Controls.Add(this.lblChunkSize);
         this.tbpCommunication.Controls.Add(this.mtxtChunkSize);
         this.tbpCommunication.Controls.Add(this.lblRequestTimeoutSeconds);
         this.tbpCommunication.Controls.Add(this.lblRequesttimeout);
         this.tbpCommunication.Controls.Add(this.mtxtRequestTimeout);
         this.tbpCommunication.Controls.Add(this.lblHandshaketimeoutSeconds);
         this.tbpCommunication.Controls.Add(this.lblHandshakeTimeout);
         this.tbpCommunication.Controls.Add(this.mtxtHandshakeTimeout);
         this.tbpCommunication.Controls.Add(this.lblMaxTRansport);
         this.tbpCommunication.Controls.Add(this.mtxtMaxTransport);
         this.tbpCommunication.Location = new System.Drawing.Point(4, 22);
         this.tbpCommunication.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.tbpCommunication.Name = "tbpCommunication";
         this.tbpCommunication.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.tbpCommunication.Size = new System.Drawing.Size(501, 337);
         this.tbpCommunication.TabIndex = 2;
         this.tbpCommunication.Text = "Communication Settings";
         this.tbpCommunication.UseVisualStyleBackColor = true;
         // 
         // chkCommunicationUnlimitedRequest
         // 
         this.chkCommunicationUnlimitedRequest.AutoSize = true;
         this.chkCommunicationUnlimitedRequest.Location = new System.Drawing.Point(317, 53);
         this.chkCommunicationUnlimitedRequest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.chkCommunicationUnlimitedRequest.Name = "chkCommunicationUnlimitedRequest";
         this.chkCommunicationUnlimitedRequest.Size = new System.Drawing.Size(69, 17);
         this.chkCommunicationUnlimitedRequest.TabIndex = 20;
         this.chkCommunicationUnlimitedRequest.Text = "Unlimited";
         this.chkCommunicationUnlimitedRequest.UseVisualStyleBackColor = true;
         this.chkCommunicationUnlimitedRequest.CheckedChanged += new System.EventHandler(this.chkCommunicationUnlimitedRequest_CheckedChanged);
         // 
         // lblChunkBytes
         // 
         this.lblChunkBytes.AutoSize = true;
         this.lblChunkBytes.Location = new System.Drawing.Point(261, 76);
         this.lblChunkBytes.Name = "lblChunkBytes";
         this.lblChunkBytes.Size = new System.Drawing.Size(33, 13);
         this.lblChunkBytes.TabIndex = 10;
         this.lblChunkBytes.Text = "Bytes";
         // 
         // lblChunkSize
         // 
         this.lblChunkSize.AutoSize = true;
         this.lblChunkSize.Location = new System.Drawing.Point(5, 76);
         this.lblChunkSize.Name = "lblChunkSize";
         this.lblChunkSize.Size = new System.Drawing.Size(64, 13);
         this.lblChunkSize.TabIndex = 8;
         this.lblChunkSize.Text = "&Chunk Size:";
         // 
         // mtxtChunkSize
         // 
         this.mtxtChunkSize.HidePromptOnLeave = true;
         this.mtxtChunkSize.Location = new System.Drawing.Point(170, 74);
         this.mtxtChunkSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.mtxtChunkSize.Mask = "00000";
         this.mtxtChunkSize.Name = "mtxtChunkSize";
         this.mtxtChunkSize.Size = new System.Drawing.Size(86, 20);
         this.mtxtChunkSize.TabIndex = 9;
         this.mtxtChunkSize.ValidatingType = typeof(int);
         // 
         // lblRequestTimeoutSeconds
         // 
         this.lblRequestTimeoutSeconds.AutoSize = true;
         this.lblRequestTimeoutSeconds.Location = new System.Drawing.Point(261, 54);
         this.lblRequestTimeoutSeconds.Name = "lblRequestTimeoutSeconds";
         this.lblRequestTimeoutSeconds.Size = new System.Drawing.Size(49, 13);
         this.lblRequestTimeoutSeconds.TabIndex = 7;
         this.lblRequestTimeoutSeconds.Text = "Seconds";
         // 
         // lblRequesttimeout
         // 
         this.lblRequesttimeout.AutoSize = true;
         this.lblRequesttimeout.Location = new System.Drawing.Point(5, 53);
         this.lblRequesttimeout.Name = "lblRequesttimeout";
         this.lblRequesttimeout.Size = new System.Drawing.Size(91, 13);
         this.lblRequesttimeout.TabIndex = 5;
         this.lblRequesttimeout.Text = "&Request Timeout:";
         // 
         // mtxtRequestTimeout
         // 
         this.mtxtRequestTimeout.HidePromptOnLeave = true;
         this.mtxtRequestTimeout.Location = new System.Drawing.Point(170, 51);
         this.mtxtRequestTimeout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.mtxtRequestTimeout.Mask = "00000";
         this.mtxtRequestTimeout.Name = "mtxtRequestTimeout";
         this.mtxtRequestTimeout.Size = new System.Drawing.Size(86, 20);
         this.mtxtRequestTimeout.TabIndex = 6;
         this.mtxtRequestTimeout.ValidatingType = typeof(int);
         // 
         // lblHandshaketimeoutSeconds
         // 
         this.lblHandshaketimeoutSeconds.AutoSize = true;
         this.lblHandshaketimeoutSeconds.Location = new System.Drawing.Point(261, 31);
         this.lblHandshaketimeoutSeconds.Name = "lblHandshaketimeoutSeconds";
         this.lblHandshaketimeoutSeconds.Size = new System.Drawing.Size(49, 13);
         this.lblHandshaketimeoutSeconds.TabIndex = 4;
         this.lblHandshaketimeoutSeconds.Text = "Seconds";
         // 
         // lblHandshakeTimeout
         // 
         this.lblHandshakeTimeout.AutoSize = true;
         this.lblHandshakeTimeout.Location = new System.Drawing.Point(5, 30);
         this.lblHandshakeTimeout.Name = "lblHandshakeTimeout";
         this.lblHandshakeTimeout.Size = new System.Drawing.Size(106, 13);
         this.lblHandshakeTimeout.TabIndex = 2;
         this.lblHandshakeTimeout.Text = "&Handshake Timeout:";
         // 
         // mtxtHandshakeTimeout
         // 
         this.mtxtHandshakeTimeout.HidePromptOnLeave = true;
         this.mtxtHandshakeTimeout.Location = new System.Drawing.Point(170, 28);
         this.mtxtHandshakeTimeout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.mtxtHandshakeTimeout.Mask = "00000";
         this.mtxtHandshakeTimeout.Name = "mtxtHandshakeTimeout";
         this.mtxtHandshakeTimeout.Size = new System.Drawing.Size(86, 20);
         this.mtxtHandshakeTimeout.TabIndex = 3;
         this.mtxtHandshakeTimeout.ValidatingType = typeof(int);
         // 
         // lblMaxTRansport
         // 
         this.lblMaxTRansport.AutoSize = true;
         this.lblMaxTRansport.Location = new System.Drawing.Point(7, 6);
         this.lblMaxTRansport.Name = "lblMaxTRansport";
         this.lblMaxTRansport.Size = new System.Drawing.Size(143, 13);
         this.lblMaxTRansport.TabIndex = 0;
         this.lblMaxTRansport.Text = "&Max. Transport Connections:";
         // 
         // mtxtMaxTransport
         // 
         this.mtxtMaxTransport.HidePromptOnLeave = true;
         this.mtxtMaxTransport.Location = new System.Drawing.Point(171, 5);
         this.mtxtMaxTransport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.mtxtMaxTransport.Mask = "00000";
         this.mtxtMaxTransport.Name = "mtxtMaxTransport";
         this.mtxtMaxTransport.Size = new System.Drawing.Size(86, 20);
         this.mtxtMaxTransport.TabIndex = 1;
         this.mtxtMaxTransport.ValidatingType = typeof(int);
         // 
         // tbpImages
         // 
         this.tbpImages.Controls.Add(this.chkImageParsingTimeout);
         this.tbpImages.Controls.Add(this.mtxtPartitionSize);
         this.tbpImages.Controls.Add(this.lblPartitionSizeBytes);
         this.tbpImages.Controls.Add(this.lblPartionSize);
         this.tbpImages.Controls.Add(this.lblParsingTimeoutSeconds);
         this.tbpImages.Controls.Add(this.chkDivideSuperBoxes);
         this.tbpImages.Controls.Add(this.mtxtParsingTimeout);
         this.tbpImages.Controls.Add(this.lblParsingTimeout);
         this.tbpImages.Location = new System.Drawing.Point(4, 22);
         this.tbpImages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.tbpImages.Name = "tbpImages";
         this.tbpImages.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.tbpImages.Size = new System.Drawing.Size(501, 337);
         this.tbpImages.TabIndex = 3;
         this.tbpImages.Text = "Images";
         this.tbpImages.UseVisualStyleBackColor = true;
         // 
         // chkImageParsingTimeout
         // 
         this.chkImageParsingTimeout.AutoSize = true;
         this.chkImageParsingTimeout.Location = new System.Drawing.Point(337, 8);
         this.chkImageParsingTimeout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.chkImageParsingTimeout.Name = "chkImageParsingTimeout";
         this.chkImageParsingTimeout.Size = new System.Drawing.Size(69, 17);
         this.chkImageParsingTimeout.TabIndex = 21;
         this.chkImageParsingTimeout.Text = "Unlimited";
         this.chkImageParsingTimeout.UseVisualStyleBackColor = true;
         this.chkImageParsingTimeout.CheckedChanged += new System.EventHandler(this.chkImageParsingTimeout_CheckedChanged);
         // 
         // mtxtPartitionSize
         // 
         this.mtxtPartitionSize.HidePromptOnLeave = true;
         this.mtxtPartitionSize.Location = new System.Drawing.Point(189, 34);
         this.mtxtPartitionSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.mtxtPartitionSize.Mask = "00000";
         this.mtxtPartitionSize.Name = "mtxtPartitionSize";
         this.mtxtPartitionSize.Size = new System.Drawing.Size(86, 20);
         this.mtxtPartitionSize.TabIndex = 4;
         this.mtxtPartitionSize.ValidatingType = typeof(int);
         // 
         // lblPartitionSizeBytes
         // 
         this.lblPartitionSizeBytes.AutoSize = true;
         this.lblPartitionSizeBytes.Location = new System.Drawing.Point(280, 34);
         this.lblPartitionSizeBytes.Name = "lblPartitionSizeBytes";
         this.lblPartitionSizeBytes.Size = new System.Drawing.Size(32, 13);
         this.lblPartitionSizeBytes.TabIndex = 5;
         this.lblPartitionSizeBytes.Text = "bytes";
         // 
         // lblPartionSize
         // 
         this.lblPartionSize.AutoSize = true;
         this.lblPartionSize.Location = new System.Drawing.Point(5, 34);
         this.lblPartionSize.Name = "lblPartionSize";
         this.lblPartionSize.Size = new System.Drawing.Size(171, 13);
         this.lblPartionSize.TabIndex = 3;
         this.lblPartionSize.Text = "Partition boxes which size exceeds";
         // 
         // lblParsingTimeoutSeconds
         // 
         this.lblParsingTimeoutSeconds.AutoSize = true;
         this.lblParsingTimeoutSeconds.Location = new System.Drawing.Point(280, 8);
         this.lblParsingTimeoutSeconds.Name = "lblParsingTimeoutSeconds";
         this.lblParsingTimeoutSeconds.Size = new System.Drawing.Size(49, 13);
         this.lblParsingTimeoutSeconds.TabIndex = 2;
         this.lblParsingTimeoutSeconds.Text = "Seconds";
         // 
         // chkDivideSuperBoxes
         // 
         this.chkDivideSuperBoxes.AutoSize = true;
         this.chkDivideSuperBoxes.Checked = true;
         this.chkDivideSuperBoxes.CheckState = System.Windows.Forms.CheckState.Checked;
         this.chkDivideSuperBoxes.Location = new System.Drawing.Point(8, 59);
         this.chkDivideSuperBoxes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.chkDivideSuperBoxes.Name = "chkDivideSuperBoxes";
         this.chkDivideSuperBoxes.Size = new System.Drawing.Size(197, 17);
         this.chkDivideSuperBoxes.TabIndex = 6;
         this.chkDivideSuperBoxes.Text = "Divide &Super Boxes into Placholders";
         this.chkDivideSuperBoxes.UseVisualStyleBackColor = true;
         // 
         // mtxtParsingTimeout
         // 
         this.mtxtParsingTimeout.HidePromptOnLeave = true;
         this.mtxtParsingTimeout.Location = new System.Drawing.Point(189, 8);
         this.mtxtParsingTimeout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.mtxtParsingTimeout.Mask = "00000";
         this.mtxtParsingTimeout.Name = "mtxtParsingTimeout";
         this.mtxtParsingTimeout.Size = new System.Drawing.Size(86, 20);
         this.mtxtParsingTimeout.TabIndex = 1;
         this.mtxtParsingTimeout.ValidatingType = typeof(int);
         // 
         // lblParsingTimeout
         // 
         this.lblParsingTimeout.AutoSize = true;
         this.lblParsingTimeout.Location = new System.Drawing.Point(5, 11);
         this.lblParsingTimeout.Name = "lblParsingTimeout";
         this.lblParsingTimeout.Size = new System.Drawing.Size(86, 13);
         this.lblParsingTimeout.TabIndex = 0;
         this.lblParsingTimeout.Text = "&Parsing Timeout:";
         // 
         // tbpLoggin
         // 
         this.tbpLoggin.Controls.Add(this.grpFileLog);
         this.tbpLoggin.Controls.Add(this.chkEnableLog);
         this.tbpLoggin.Location = new System.Drawing.Point(4, 22);
         this.tbpLoggin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.tbpLoggin.Name = "tbpLoggin";
         this.tbpLoggin.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.tbpLoggin.Size = new System.Drawing.Size(501, 337);
         this.tbpLoggin.TabIndex = 4;
         this.tbpLoggin.Text = "Logging";
         this.tbpLoggin.UseVisualStyleBackColor = true;
         // 
         // grpFileLog
         // 
         this.grpFileLog.Controls.Add(this.button1);
         this.grpFileLog.Controls.Add(this.groupBox2);
         this.grpFileLog.Controls.Add(this.txtLogFile);
         this.grpFileLog.Controls.Add(this.label2);
         this.grpFileLog.Location = new System.Drawing.Point(9, 27);
         this.grpFileLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.grpFileLog.Name = "grpFileLog";
         this.grpFileLog.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.grpFileLog.Size = new System.Drawing.Size(424, 150);
         this.grpFileLog.TabIndex = 1;
         this.grpFileLog.TabStop = false;
         this.grpFileLog.Text = "File Logging:";
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(394, 24);
         this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(25, 19);
         this.button1.TabIndex = 12;
         this.button1.Text = "...";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.chkLogInformation);
         this.groupBox2.Controls.Add(this.chkLogDebug);
         this.groupBox2.Controls.Add(this.chkLogWarnings);
         this.groupBox2.Controls.Add(this.chkLogErrors);
         this.groupBox2.Location = new System.Drawing.Point(12, 54);
         this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.groupBox2.Size = new System.Drawing.Size(203, 81);
         this.groupBox2.TabIndex = 0;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Filter Logs Types:";
         // 
         // chkLogInformation
         // 
         this.chkLogInformation.AutoSize = true;
         this.chkLogInformation.Location = new System.Drawing.Point(5, 26);
         this.chkLogInformation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.chkLogInformation.Name = "chkLogInformation";
         this.chkLogInformation.Size = new System.Drawing.Size(78, 17);
         this.chkLogInformation.TabIndex = 0;
         this.chkLogInformation.Text = "Information";
         this.chkLogInformation.UseVisualStyleBackColor = true;
         // 
         // chkLogDebug
         // 
         this.chkLogDebug.AutoSize = true;
         this.chkLogDebug.Location = new System.Drawing.Point(5, 59);
         this.chkLogDebug.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.chkLogDebug.Name = "chkLogDebug";
         this.chkLogDebug.Size = new System.Drawing.Size(58, 17);
         this.chkLogDebug.TabIndex = 2;
         this.chkLogDebug.Text = "Debug";
         this.chkLogDebug.UseVisualStyleBackColor = true;
         // 
         // chkLogWarnings
         // 
         this.chkLogWarnings.AutoSize = true;
         this.chkLogWarnings.Location = new System.Drawing.Point(114, 26);
         this.chkLogWarnings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.chkLogWarnings.Name = "chkLogWarnings";
         this.chkLogWarnings.Size = new System.Drawing.Size(71, 17);
         this.chkLogWarnings.TabIndex = 1;
         this.chkLogWarnings.Text = "Warnings";
         this.chkLogWarnings.UseVisualStyleBackColor = true;
         // 
         // chkLogErrors
         // 
         this.chkLogErrors.AutoSize = true;
         this.chkLogErrors.Location = new System.Drawing.Point(114, 59);
         this.chkLogErrors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.chkLogErrors.Name = "chkLogErrors";
         this.chkLogErrors.Size = new System.Drawing.Size(53, 17);
         this.chkLogErrors.TabIndex = 3;
         this.chkLogErrors.Text = "Errors";
         this.chkLogErrors.UseVisualStyleBackColor = true;
         // 
         // txtLogFile
         // 
         this.txtLogFile.Location = new System.Drawing.Point(88, 23);
         this.txtLogFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.txtLogFile.Name = "txtLogFile";
         this.txtLogFile.Size = new System.Drawing.Size(301, 20);
         this.txtLogFile.TabIndex = 1;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(9, 23);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(73, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "Log file name:";
         // 
         // chkEnableLog
         // 
         this.chkEnableLog.AutoSize = true;
         this.chkEnableLog.Checked = true;
         this.chkEnableLog.CheckState = System.Windows.Forms.CheckState.Checked;
         this.chkEnableLog.Location = new System.Drawing.Point(5, 5);
         this.chkEnableLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.chkEnableLog.Name = "chkEnableLog";
         this.chkEnableLog.Size = new System.Drawing.Size(100, 17);
         this.chkEnableLog.TabIndex = 0;
         this.chkEnableLog.Text = "&Enable Logging";
         this.chkEnableLog.UseVisualStyleBackColor = true;
         // 
         // tbpServerDelegation
         // 
         this.tbpServerDelegation.Controls.Add(this.mtxtDelegatedServerLoad);
         this.tbpServerDelegation.Controls.Add(this.label5);
         this.tbpServerDelegation.Controls.Add(this.mtxtDelegatedServerPort);
         this.tbpServerDelegation.Controls.Add(this.txtDelegatedServerIP);
         this.tbpServerDelegation.Controls.Add(this.label3);
         this.tbpServerDelegation.Controls.Add(this.label4);
         this.tbpServerDelegation.Controls.Add(this.btnAddDelegatedServer);
         this.tbpServerDelegation.Controls.Add(this.btnRemoveDelegatedServer);
         this.tbpServerDelegation.Controls.Add(this.lsvServers);
         this.tbpServerDelegation.Location = new System.Drawing.Point(4, 22);
         this.tbpServerDelegation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.tbpServerDelegation.Name = "tbpServerDelegation";
         this.tbpServerDelegation.Size = new System.Drawing.Size(501, 337);
         this.tbpServerDelegation.TabIndex = 5;
         this.tbpServerDelegation.Text = "Server Delegation";
         this.tbpServerDelegation.UseVisualStyleBackColor = true;
         // 
         // mtxtDelegatedServerLoad
         // 
         this.mtxtDelegatedServerLoad.HidePromptOnLeave = true;
         this.mtxtDelegatedServerLoad.Location = new System.Drawing.Point(80, 63);
         this.mtxtDelegatedServerLoad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.mtxtDelegatedServerLoad.Mask = "000";
         this.mtxtDelegatedServerLoad.Name = "mtxtDelegatedServerLoad";
         this.mtxtDelegatedServerLoad.Size = new System.Drawing.Size(86, 20);
         this.mtxtDelegatedServerLoad.TabIndex = 5;
         this.mtxtDelegatedServerLoad.ValidatingType = typeof(int);
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(5, 63);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(68, 13);
         this.label5.TabIndex = 4;
         this.label5.Text = "Server &Load:";
         // 
         // mtxtDelegatedServerPort
         // 
         this.mtxtDelegatedServerPort.HidePromptOnLeave = true;
         this.mtxtDelegatedServerPort.Location = new System.Drawing.Point(80, 37);
         this.mtxtDelegatedServerPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.mtxtDelegatedServerPort.Mask = "000";
         this.mtxtDelegatedServerPort.Name = "mtxtDelegatedServerPort";
         this.mtxtDelegatedServerPort.Size = new System.Drawing.Size(86, 20);
         this.mtxtDelegatedServerPort.TabIndex = 3;
         this.mtxtDelegatedServerPort.ValidatingType = typeof(int);
         // 
         // txtDelegatedServerIP
         // 
         this.txtDelegatedServerIP.Location = new System.Drawing.Point(80, 11);
         this.txtDelegatedServerIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.txtDelegatedServerIP.Name = "txtDelegatedServerIP";
         this.txtDelegatedServerIP.Size = new System.Drawing.Size(163, 20);
         this.txtDelegatedServerIP.TabIndex = 1;
         this.txtDelegatedServerIP.Validating += new System.ComponentModel.CancelEventHandler(this.txtIpAddress_Validating);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(5, 37);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(29, 13);
         this.label3.TabIndex = 2;
         this.label3.Text = "&Port:";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(5, 11);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(54, 13);
         this.label4.TabIndex = 0;
         this.label4.Text = "&Server IP:";
         // 
         // btnAddDelegatedServer
         // 
         this.btnAddDelegatedServer.Location = new System.Drawing.Point(5, 94);
         this.btnAddDelegatedServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.btnAddDelegatedServer.Name = "btnAddDelegatedServer";
         this.btnAddDelegatedServer.Size = new System.Drawing.Size(64, 26);
         this.btnAddDelegatedServer.TabIndex = 6;
         this.btnAddDelegatedServer.Text = "&Add";
         this.btnAddDelegatedServer.UseVisualStyleBackColor = true;
         this.btnAddDelegatedServer.Click += new System.EventHandler(this.btnAddDelegatedServer_Click);
         // 
         // btnRemoveDelegatedServer
         // 
         this.btnRemoveDelegatedServer.Location = new System.Drawing.Point(5, 122);
         this.btnRemoveDelegatedServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.btnRemoveDelegatedServer.Name = "btnRemoveDelegatedServer";
         this.btnRemoveDelegatedServer.Size = new System.Drawing.Size(64, 27);
         this.btnRemoveDelegatedServer.TabIndex = 7;
         this.btnRemoveDelegatedServer.Text = "&Remove";
         this.btnRemoveDelegatedServer.UseVisualStyleBackColor = true;
         this.btnRemoveDelegatedServer.Click += new System.EventHandler(this.btnRemoveDelegatedServer_Click);
         // 
         // lsvServers
         // 
         this.lsvServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmServerIp,
            this.clmServerPort,
            this.clmServerLoad});
         this.lsvServers.FullRowSelect = true;
         this.lsvServers.Location = new System.Drawing.Point(75, 94);
         this.lsvServers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.lsvServers.Name = "lsvServers";
         this.lsvServers.Size = new System.Drawing.Size(412, 95);
         this.lsvServers.TabIndex = 8;
         this.lsvServers.UseCompatibleStateImageBehavior = false;
         this.lsvServers.View = System.Windows.Forms.View.Details;
         // 
         // clmServerIp
         // 
         this.clmServerIp.Text = "IP Address";
         this.clmServerIp.Width = 216;
         // 
         // clmServerPort
         // 
         this.clmServerPort.Text = "Port";
         this.clmServerPort.Width = 105;
         // 
         // clmServerLoad
         // 
         this.clmServerLoad.Text = "Server Load";
         this.clmServerLoad.Width = 131;
         // 
         // btnOK
         // 
         this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point(301, 426);
         this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(64, 22);
         this.btnOK.TabIndex = 1;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // btnApply
         // 
         this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnApply.Location = new System.Drawing.Point(370, 426);
         this.btnApply.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.btnApply.Name = "btnApply";
         this.btnApply.Size = new System.Drawing.Size(64, 22);
         this.btnApply.TabIndex = 2;
         this.btnApply.Text = "&Apply";
         this.btnApply.UseVisualStyleBackColor = true;
         this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnCancel.CausesValidation = false;
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(440, 426);
         this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(64, 22);
         this.btnCancel.TabIndex = 3;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // btnReset
         // 
         this.btnReset.Location = new System.Drawing.Point(3, 376);
         this.btnReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.btnReset.Name = "btnReset";
         this.btnReset.Size = new System.Drawing.Size(64, 22);
         this.btnReset.TabIndex = 4;
         this.btnReset.Text = "&Reset";
         this.btnReset.UseVisualStyleBackColor = true;
         this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
         // 
         // openFileDialog1
         // 
         this.openFileDialog1.CheckFileExists = false;
         // 
         // btnImportImage
         // 
         this.btnImportImage.Location = new System.Drawing.Point(322, 106);
         this.btnImportImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.btnImportImage.Name = "btnImportImage";
         this.btnImportImage.Size = new System.Drawing.Size(118, 29);
         this.btnImportImage.TabIndex = 20;
         this.btnImportImage.Text = "Import image file...";
         this.btnImportImage.UseVisualStyleBackColor = true;
         this.btnImportImage.Click += new System.EventHandler(this.btnImportImage_Click);
         // 
         // Configuration
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(506, 453);
         this.Controls.Add(this.btnReset);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnApply);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.tbcMain);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Configuration";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Configuration";
         this.tbcMain.ResumeLayout(false);
         this.tbpServer.ResumeLayout(false);
         this.tbpServer.PerformLayout();
         this.grpALiases.ResumeLayout(false);
         this.grpALiases.PerformLayout();
         this.tbpClients.ResumeLayout(false);
         this.tbpClients.PerformLayout();
         this.tbpCommunication.ResumeLayout(false);
         this.tbpCommunication.PerformLayout();
         this.tbpImages.ResumeLayout(false);
         this.tbpImages.PerformLayout();
         this.tbpLoggin.ResumeLayout(false);
         this.tbpLoggin.PerformLayout();
         this.grpFileLog.ResumeLayout(false);
         this.grpFileLog.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.tbpServerDelegation.ResumeLayout(false);
         this.tbpServerDelegation.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabControl tbcMain;
      private System.Windows.Forms.TabPage tbpServer;
      private System.Windows.Forms.TabPage tbpClients;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.MaskedTextBox mtxtServerBandwidth;
      private System.Windows.Forms.Label lbMaxlSeverBandwidth;
      private System.Windows.Forms.Label lblCacheSizeMB;
      private System.Windows.Forms.MaskedTextBox mtxtCacheSize;
      private System.Windows.Forms.Label lblCacheSize;
      private System.Windows.Forms.Button btnBrowseCache;
      private System.Windows.Forms.TextBox txtCacheFolder;
      private System.Windows.Forms.Label lblCacheFolder;
      private System.Windows.Forms.Button btnBrowseImages;
      private System.Windows.Forms.TextBox txtImagesFolder;
      private System.Windows.Forms.Label lblImages;
      private System.Windows.Forms.MaskedTextBox mtxtPort;
      private System.Windows.Forms.Label lblPort;
      private System.Windows.Forms.TextBox txtIpAddress;
      private System.Windows.Forms.Label lblIpAddress;
      private System.Windows.Forms.Label lblServerName;
      private System.Windows.Forms.TextBox txtServerName;
      private System.Windows.Forms.Label lblConnectionIdleSeconds;
      private System.Windows.Forms.MaskedTextBox mtxtConnectionIdleTimeout;
      private System.Windows.Forms.Label lblConnectionIdle;
      private System.Windows.Forms.Label lblConnectionBWKBS;
      private System.Windows.Forms.MaskedTextBox mtxtConnectionBW;
      private System.Windows.Forms.Label lblConnectionBW;
      private System.Windows.Forms.Label lblSessionLifeSeconds;
      private System.Windows.Forms.MaskedTextBox mtxtMaxSessionLife;
      private System.Windows.Forms.Label lblMaxSessionLife;
      private System.Windows.Forms.MaskedTextBox mtxtMaxClients;
      private System.Windows.Forms.Label lblMaxClients;
      private System.Windows.Forms.TabPage tbpCommunication;
      private System.Windows.Forms.Label lblMaxTRansport;
      private System.Windows.Forms.MaskedTextBox mtxtMaxTransport;
      private System.Windows.Forms.Label lblHandshakeTimeout;
      private System.Windows.Forms.MaskedTextBox mtxtHandshakeTimeout;
      private System.Windows.Forms.Label lblHandshaketimeoutSeconds;
      private System.Windows.Forms.Label lblRequestTimeoutSeconds;
      private System.Windows.Forms.Label lblRequesttimeout;
      private System.Windows.Forms.MaskedTextBox mtxtRequestTimeout;
      private System.Windows.Forms.Label lblChunkBytes;
      private System.Windows.Forms.Label lblChunkSize;
      private System.Windows.Forms.MaskedTextBox mtxtChunkSize;
      private System.Windows.Forms.TabPage tbpImages;
      private System.Windows.Forms.MaskedTextBox mtxtParsingTimeout;
      private System.Windows.Forms.Label lblParsingTimeout;
      private System.Windows.Forms.CheckBox chkDivideSuperBoxes;
      private System.Windows.Forms.GroupBox grpALiases;
      private System.Windows.Forms.Button btnAdd;
      private System.Windows.Forms.Button btnRemove;
      private System.Windows.Forms.ListView lsvAliases;
      private System.Windows.Forms.Label lblPath;
      private System.Windows.Forms.Label lblAlias;
      private System.Windows.Forms.TextBox txtAliasPath;
      private System.Windows.Forms.TextBox txtAlias;
      private System.Windows.Forms.Button btnBrowsePath;
      private System.Windows.Forms.ColumnHeader clmhALias;
      private System.Windows.Forms.ColumnHeader clmhPath;
      private System.Windows.Forms.Label lblParsingTimeoutSeconds;
      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.Button btnApply;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
      private System.Windows.Forms.Label lblPartitionSizeBytes;
      private System.Windows.Forms.Label lblPartionSize;
      private System.Windows.Forms.MaskedTextBox mtxtPartitionSize;
      private System.Windows.Forms.TabPage tbpLoggin;
      private System.Windows.Forms.CheckBox chkEnableLog;
      private System.Windows.Forms.GroupBox grpFileLog;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.CheckBox chkLogInformation;
      private System.Windows.Forms.CheckBox chkLogDebug;
      private System.Windows.Forms.CheckBox chkLogWarnings;
      private System.Windows.Forms.CheckBox chkLogErrors;
      private System.Windows.Forms.TextBox txtLogFile;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Button btnReset;
      private System.Windows.Forms.TabPage tbpServerDelegation;
      private System.Windows.Forms.MaskedTextBox mtxtDelegatedServerPort;
      private System.Windows.Forms.TextBox txtDelegatedServerIP;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Button btnAddDelegatedServer;
      private System.Windows.Forms.Button btnRemoveDelegatedServer;
      private System.Windows.Forms.ListView lsvServers;
      private System.Windows.Forms.ColumnHeader clmServerIp;
      private System.Windows.Forms.ColumnHeader clmServerPort;
      private System.Windows.Forms.MaskedTextBox mtxtDelegatedServerLoad;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.ColumnHeader clmServerLoad;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.OpenFileDialog openFileDialog1;
      private System.Windows.Forms.CheckBox chkServerUnlimitedBandWidth;
      private System.Windows.Forms.CheckBox chkClientUnlimitedBandWidth;
      private System.Windows.Forms.CheckBox chkCommunicationUnlimitedRequest;
      private System.Windows.Forms.CheckBox chkImageParsingTimeout;
      private System.Windows.Forms.Button btnImportImage;
   }
}