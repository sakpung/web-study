Imports Microsoft.VisualBasic
Imports System

   Partial Public Class Configuration
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing AndAlso (Not components Is Nothing) Then
            components.Dispose()
         End If
         MyBase.Dispose(disposing)
      End Sub

#Region "Windows Form Designer generated code"

      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
      Me.tbcMain = New System.Windows.Forms.TabControl()
      Me.tbpServer = New System.Windows.Forms.TabPage()
      Me.chkServerUnlimitedBandWidth = New System.Windows.Forms.CheckBox()
      Me.grpALiases = New System.Windows.Forms.GroupBox()
      Me.btnBrowsePath = New System.Windows.Forms.Button()
      Me.txtAliasPath = New System.Windows.Forms.TextBox()
      Me.txtAlias = New System.Windows.Forms.TextBox()
      Me.lblPath = New System.Windows.Forms.Label()
      Me.lblAlias = New System.Windows.Forms.Label()
      Me.btnAdd = New System.Windows.Forms.Button()
      Me.btnRemove = New System.Windows.Forms.Button()
      Me.lsvAliases = New System.Windows.Forms.ListView()
      Me.clmhALias = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clmhPath = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.label1 = New System.Windows.Forms.Label()
      Me.mtxtServerBandwidth = New System.Windows.Forms.MaskedTextBox()
      Me.lbMaxlSeverBandwidth = New System.Windows.Forms.Label()
      Me.lblCacheSizeMB = New System.Windows.Forms.Label()
      Me.mtxtCacheSize = New System.Windows.Forms.MaskedTextBox()
      Me.lblCacheSize = New System.Windows.Forms.Label()
      Me.btnBrowseCache = New System.Windows.Forms.Button()
      Me.txtCacheFolder = New System.Windows.Forms.TextBox()
      Me.lblCacheFolder = New System.Windows.Forms.Label()
      Me.btnBrowseImages = New System.Windows.Forms.Button()
      Me.txtImagesFolder = New System.Windows.Forms.TextBox()
      Me.lblImages = New System.Windows.Forms.Label()
      Me.mtxtPort = New System.Windows.Forms.MaskedTextBox()
      Me.lblPort = New System.Windows.Forms.Label()
      Me.txtIpAddress = New System.Windows.Forms.TextBox()
      Me.lblIpAddress = New System.Windows.Forms.Label()
      Me.lblServerName = New System.Windows.Forms.Label()
      Me.txtServerName = New System.Windows.Forms.TextBox()
      Me.tbpClients = New System.Windows.Forms.TabPage()
      Me.chkClientUnlimitedBandWidth = New System.Windows.Forms.CheckBox()
      Me.lblConnectionIdleSeconds = New System.Windows.Forms.Label()
      Me.mtxtConnectionIdleTimeout = New System.Windows.Forms.MaskedTextBox()
      Me.lblConnectionIdle = New System.Windows.Forms.Label()
      Me.lblConnectionBWKBS = New System.Windows.Forms.Label()
      Me.mtxtConnectionBW = New System.Windows.Forms.MaskedTextBox()
      Me.lblConnectionBW = New System.Windows.Forms.Label()
      Me.lblSessionLifeSeconds = New System.Windows.Forms.Label()
      Me.mtxtMaxSessionLife = New System.Windows.Forms.MaskedTextBox()
      Me.lblMaxSessionLife = New System.Windows.Forms.Label()
      Me.mtxtMaxClients = New System.Windows.Forms.MaskedTextBox()
      Me.lblMaxClients = New System.Windows.Forms.Label()
      Me.tbpCommunication = New System.Windows.Forms.TabPage()
      Me.chkCommunicationUnlimitedRequest = New System.Windows.Forms.CheckBox()
      Me.lblChunkBytes = New System.Windows.Forms.Label()
      Me.lblChunkSize = New System.Windows.Forms.Label()
      Me.mtxtChunkSize = New System.Windows.Forms.MaskedTextBox()
      Me.lblRequestTimeoutSeconds = New System.Windows.Forms.Label()
      Me.lblRequesttimeout = New System.Windows.Forms.Label()
      Me.mtxtRequestTimeout = New System.Windows.Forms.MaskedTextBox()
      Me.lblHandshaketimeoutSeconds = New System.Windows.Forms.Label()
      Me.lblHandshakeTimeout = New System.Windows.Forms.Label()
      Me.mtxtHandshakeTimeout = New System.Windows.Forms.MaskedTextBox()
      Me.lblMaxTRansport = New System.Windows.Forms.Label()
      Me.mtxtMaxTransport = New System.Windows.Forms.MaskedTextBox()
      Me.tbpImages = New System.Windows.Forms.TabPage()
      Me.chkImageParsingTimeout = New System.Windows.Forms.CheckBox()
      Me.mtxtPartitionSize = New System.Windows.Forms.MaskedTextBox()
      Me.lblPartitionSizeBytes = New System.Windows.Forms.Label()
      Me.lblPartionSize = New System.Windows.Forms.Label()
      Me.lblParsingTimeoutSeconds = New System.Windows.Forms.Label()
      Me.chkDivideSuperBoxes = New System.Windows.Forms.CheckBox()
      Me.mtxtParsingTimeout = New System.Windows.Forms.MaskedTextBox()
      Me.lblParsingTimeout = New System.Windows.Forms.Label()
      Me.tbpLoggin = New System.Windows.Forms.TabPage()
      Me.grpFileLog = New System.Windows.Forms.GroupBox()
      Me.button1 = New System.Windows.Forms.Button()
      Me.groupBox2 = New System.Windows.Forms.GroupBox()
      Me.chkLogInformation = New System.Windows.Forms.CheckBox()
      Me.chkLogDebug = New System.Windows.Forms.CheckBox()
      Me.chkLogWarnings = New System.Windows.Forms.CheckBox()
      Me.chkLogErrors = New System.Windows.Forms.CheckBox()
      Me.txtLogFile = New System.Windows.Forms.TextBox()
      Me.label2 = New System.Windows.Forms.Label()
      Me.chkEnableLog = New System.Windows.Forms.CheckBox()
      Me.tbpServerDelegation = New System.Windows.Forms.TabPage()
      Me.mtxtDelegatedServerLoad = New System.Windows.Forms.MaskedTextBox()
      Me.label5 = New System.Windows.Forms.Label()
      Me.mtxtDelegatedServerPort = New System.Windows.Forms.MaskedTextBox()
      Me.txtDelegatedServerIP = New System.Windows.Forms.TextBox()
      Me.label3 = New System.Windows.Forms.Label()
      Me.label4 = New System.Windows.Forms.Label()
      Me.btnAddDelegatedServer = New System.Windows.Forms.Button()
      Me.btnRemoveDelegatedServer = New System.Windows.Forms.Button()
      Me.lsvServers = New System.Windows.Forms.ListView()
      Me.clmServerIp = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clmServerPort = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clmServerLoad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.btnOK = New System.Windows.Forms.Button()
      Me.btnApply = New System.Windows.Forms.Button()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.folderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.btnImportImage = New System.Windows.Forms.Button()
      Me.tbcMain.SuspendLayout()
      Me.tbpServer.SuspendLayout()
      Me.grpALiases.SuspendLayout()
      Me.tbpClients.SuspendLayout()
      Me.tbpCommunication.SuspendLayout()
      Me.tbpImages.SuspendLayout()
      Me.tbpLoggin.SuspendLayout()
      Me.grpFileLog.SuspendLayout()
      Me.groupBox2.SuspendLayout()
      Me.tbpServerDelegation.SuspendLayout()
      Me.SuspendLayout()
      '
      'tbcMain
      '
      Me.tbcMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbcMain.Controls.Add(Me.tbpServer)
      Me.tbcMain.Controls.Add(Me.tbpClients)
      Me.tbcMain.Controls.Add(Me.tbpCommunication)
      Me.tbcMain.Controls.Add(Me.tbpImages)
      Me.tbcMain.Controls.Add(Me.tbpLoggin)
      Me.tbcMain.Controls.Add(Me.tbpServerDelegation)
      Me.tbcMain.Location = New System.Drawing.Point(-2, 8)
      Me.tbcMain.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.tbcMain.Name = "tbcMain"
      Me.tbcMain.SelectedIndex = 0
      Me.tbcMain.Size = New System.Drawing.Size(509, 412)
      Me.tbcMain.TabIndex = 0
      '
      'tbpServer
      '
      Me.tbpServer.Controls.Add(Me.btnImportImage)
      Me.tbpServer.Controls.Add(Me.chkServerUnlimitedBandWidth)
      Me.tbpServer.Controls.Add(Me.grpALiases)
      Me.tbpServer.Controls.Add(Me.label1)
      Me.tbpServer.Controls.Add(Me.mtxtServerBandwidth)
      Me.tbpServer.Controls.Add(Me.lbMaxlSeverBandwidth)
      Me.tbpServer.Controls.Add(Me.lblCacheSizeMB)
      Me.tbpServer.Controls.Add(Me.mtxtCacheSize)
      Me.tbpServer.Controls.Add(Me.lblCacheSize)
      Me.tbpServer.Controls.Add(Me.btnBrowseCache)
      Me.tbpServer.Controls.Add(Me.txtCacheFolder)
      Me.tbpServer.Controls.Add(Me.lblCacheFolder)
      Me.tbpServer.Controls.Add(Me.btnBrowseImages)
      Me.tbpServer.Controls.Add(Me.txtImagesFolder)
      Me.tbpServer.Controls.Add(Me.lblImages)
      Me.tbpServer.Controls.Add(Me.mtxtPort)
      Me.tbpServer.Controls.Add(Me.lblPort)
      Me.tbpServer.Controls.Add(Me.txtIpAddress)
      Me.tbpServer.Controls.Add(Me.lblIpAddress)
      Me.tbpServer.Controls.Add(Me.lblServerName)
      Me.tbpServer.Controls.Add(Me.txtServerName)
      Me.tbpServer.Location = New System.Drawing.Point(4, 22)
      Me.tbpServer.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.tbpServer.Name = "tbpServer"
      Me.tbpServer.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.tbpServer.Size = New System.Drawing.Size(501, 386)
      Me.tbpServer.TabIndex = 0
      Me.tbpServer.Text = "Server Settings"
      Me.tbpServer.UseVisualStyleBackColor = True
      '
      'chkServerUnlimitedBandWidth
      '
      Me.chkServerUnlimitedBandWidth.AutoSize = True
      Me.chkServerUnlimitedBandWidth.Checked = True
      Me.chkServerUnlimitedBandWidth.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkServerUnlimitedBandWidth.Location = New System.Drawing.Point(255, 147)
      Me.chkServerUnlimitedBandWidth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.chkServerUnlimitedBandWidth.Name = "chkServerUnlimitedBandWidth"
      Me.chkServerUnlimitedBandWidth.Size = New System.Drawing.Size(69, 17)
      Me.chkServerUnlimitedBandWidth.TabIndex = 19
      Me.chkServerUnlimitedBandWidth.Text = "Unlimited"
      Me.chkServerUnlimitedBandWidth.UseVisualStyleBackColor = True
      '
      'grpALiases
      '
      Me.grpALiases.Controls.Add(Me.btnBrowsePath)
      Me.grpALiases.Controls.Add(Me.txtAliasPath)
      Me.grpALiases.Controls.Add(Me.txtAlias)
      Me.grpALiases.Controls.Add(Me.lblPath)
      Me.grpALiases.Controls.Add(Me.lblAlias)
      Me.grpALiases.Controls.Add(Me.btnAdd)
      Me.grpALiases.Controls.Add(Me.btnRemove)
      Me.grpALiases.Controls.Add(Me.lsvAliases)
      Me.grpALiases.Location = New System.Drawing.Point(9, 199)
      Me.grpALiases.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.grpALiases.Name = "grpALiases"
      Me.grpALiases.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.grpALiases.Size = New System.Drawing.Size(479, 144)
      Me.grpALiases.TabIndex = 18
      Me.grpALiases.TabStop = False
      Me.grpALiases.Text = "Alias Folders"
      '
      'btnBrowsePath
      '
      Me.btnBrowsePath.Location = New System.Drawing.Point(449, 14)
      Me.btnBrowsePath.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.btnBrowsePath.Name = "btnBrowsePath"
      Me.btnBrowsePath.Size = New System.Drawing.Size(25, 19)
      Me.btnBrowsePath.TabIndex = 4
      Me.btnBrowsePath.Text = "..."
      Me.btnBrowsePath.UseVisualStyleBackColor = True
      '
      'txtAliasPath
      '
      Me.txtAliasPath.Location = New System.Drawing.Point(196, 14)
      Me.txtAliasPath.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.txtAliasPath.Name = "txtAliasPath"
      Me.txtAliasPath.Size = New System.Drawing.Size(248, 20)
      Me.txtAliasPath.TabIndex = 3
      '
      'txtAlias
      '
      Me.txtAlias.Location = New System.Drawing.Point(39, 14)
      Me.txtAlias.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.txtAlias.Name = "txtAlias"
      Me.txtAlias.Size = New System.Drawing.Size(117, 20)
      Me.txtAlias.TabIndex = 1
      '
      'lblPath
      '
      Me.lblPath.AutoSize = True
      Me.lblPath.Location = New System.Drawing.Point(161, 17)
      Me.lblPath.Name = "lblPath"
      Me.lblPath.Size = New System.Drawing.Size(32, 13)
      Me.lblPath.TabIndex = 2
      Me.lblPath.Text = "Pa&th:"
      '
      'lblAlias
      '
      Me.lblAlias.AutoSize = True
      Me.lblAlias.Location = New System.Drawing.Point(6, 17)
      Me.lblAlias.Name = "lblAlias"
      Me.lblAlias.Size = New System.Drawing.Size(32, 13)
      Me.lblAlias.TabIndex = 0
      Me.lblAlias.Text = "&Alias:"
      '
      'btnAdd
      '
      Me.btnAdd.Location = New System.Drawing.Point(5, 38)
      Me.btnAdd.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.btnAdd.Name = "btnAdd"
      Me.btnAdd.Size = New System.Drawing.Size(64, 26)
      Me.btnAdd.TabIndex = 5
      Me.btnAdd.Text = "A&dd"
      Me.btnAdd.UseVisualStyleBackColor = True
      '
      'btnRemove
      '
      Me.btnRemove.Location = New System.Drawing.Point(5, 68)
      Me.btnRemove.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.btnRemove.Name = "btnRemove"
      Me.btnRemove.Size = New System.Drawing.Size(64, 26)
      Me.btnRemove.TabIndex = 6
      Me.btnRemove.Text = "&Remove"
      Me.btnRemove.UseVisualStyleBackColor = True
      '
      'lsvAliases
      '
      Me.lsvAliases.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmhALias, Me.clmhPath})
      Me.lsvAliases.FullRowSelect = True
      Me.lsvAliases.Location = New System.Drawing.Point(75, 38)
      Me.lsvAliases.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.lsvAliases.Name = "lsvAliases"
      Me.lsvAliases.Size = New System.Drawing.Size(370, 95)
      Me.lsvAliases.TabIndex = 7
      Me.lsvAliases.UseCompatibleStateImageBehavior = False
      Me.lsvAliases.View = System.Windows.Forms.View.Details
      '
      'clmhALias
      '
      Me.clmhALias.Text = "Alias"
      Me.clmhALias.Width = 138
      '
      'clmhPath
      '
      Me.clmhPath.Text = "Path"
      Me.clmhPath.Width = 278
      '
      'label1
      '
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(225, 146)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(24, 13)
      Me.label1.TabIndex = 14
      Me.label1.Text = "B/s"
      '
      'mtxtServerBandwidth
      '
      Me.mtxtServerBandwidth.HidePromptOnLeave = True
      Me.mtxtServerBandwidth.Location = New System.Drawing.Point(138, 143)
      Me.mtxtServerBandwidth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.mtxtServerBandwidth.Mask = "0000000000"
      Me.mtxtServerBandwidth.Name = "mtxtServerBandwidth"
      Me.mtxtServerBandwidth.Size = New System.Drawing.Size(86, 20)
      Me.mtxtServerBandwidth.TabIndex = 13
      '
      'lbMaxlSeverBandwidth
      '
      Me.lbMaxlSeverBandwidth.AutoSize = True
      Me.lbMaxlSeverBandwidth.Location = New System.Drawing.Point(6, 147)
      Me.lbMaxlSeverBandwidth.Name = "lbMaxlSeverBandwidth"
      Me.lbMaxlSeverBandwidth.Size = New System.Drawing.Size(120, 13)
      Me.lbMaxlSeverBandwidth.TabIndex = 12
      Me.lbMaxlSeverBandwidth.Text = "Ma&x. Server Bandwidth:"
      '
      'lblCacheSizeMB
      '
      Me.lblCacheSizeMB.AutoSize = True
      Me.lblCacheSizeMB.Location = New System.Drawing.Point(225, 169)
      Me.lblCacheSizeMB.Name = "lblCacheSizeMB"
      Me.lblCacheSizeMB.Size = New System.Drawing.Size(23, 13)
      Me.lblCacheSizeMB.TabIndex = 17
      Me.lblCacheSizeMB.Text = "MB"
      '
      'mtxtCacheSize
      '
      Me.mtxtCacheSize.HidePromptOnLeave = True
      Me.mtxtCacheSize.Location = New System.Drawing.Point(138, 166)
      Me.mtxtCacheSize.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.mtxtCacheSize.Mask = "00000"
      Me.mtxtCacheSize.Name = "mtxtCacheSize"
      Me.mtxtCacheSize.Size = New System.Drawing.Size(86, 20)
      Me.mtxtCacheSize.TabIndex = 16
      Me.mtxtCacheSize.ValidatingType = GetType(Integer)
      '
      'lblCacheSize
      '
      Me.lblCacheSize.AutoSize = True
      Me.lblCacheSize.Location = New System.Drawing.Point(6, 169)
      Me.lblCacheSize.Name = "lblCacheSize"
      Me.lblCacheSize.Size = New System.Drawing.Size(64, 13)
      Me.lblCacheSize.TabIndex = 15
      Me.lblCacheSize.Text = "Cache &Size:"
      '
      'btnBrowseCache
      '
      Me.btnBrowseCache.Location = New System.Drawing.Point(415, 80)
      Me.btnBrowseCache.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.btnBrowseCache.Name = "btnBrowseCache"
      Me.btnBrowseCache.Size = New System.Drawing.Size(25, 19)
      Me.btnBrowseCache.TabIndex = 11
      Me.btnBrowseCache.Text = "..."
      Me.btnBrowseCache.UseVisualStyleBackColor = True
      '
      'txtCacheFolder
      '
      Me.txtCacheFolder.Location = New System.Drawing.Point(90, 80)
      Me.txtCacheFolder.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.txtCacheFolder.Name = "txtCacheFolder"
      Me.txtCacheFolder.Size = New System.Drawing.Size(320, 20)
      Me.txtCacheFolder.TabIndex = 10
      '
      'lblCacheFolder
      '
      Me.lblCacheFolder.AutoSize = True
      Me.lblCacheFolder.Location = New System.Drawing.Point(5, 80)
      Me.lblCacheFolder.Name = "lblCacheFolder"
      Me.lblCacheFolder.Size = New System.Drawing.Size(73, 13)
      Me.lblCacheFolder.TabIndex = 9
      Me.lblCacheFolder.Text = "&Cache Folder:"
      '
      'btnBrowseImages
      '
      Me.btnBrowseImages.Location = New System.Drawing.Point(415, 58)
      Me.btnBrowseImages.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.btnBrowseImages.Name = "btnBrowseImages"
      Me.btnBrowseImages.Size = New System.Drawing.Size(25, 19)
      Me.btnBrowseImages.TabIndex = 8
      Me.btnBrowseImages.Text = "..."
      Me.btnBrowseImages.UseVisualStyleBackColor = True
      '
      'txtImagesFolder
      '
      Me.txtImagesFolder.Location = New System.Drawing.Point(90, 57)
      Me.txtImagesFolder.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.txtImagesFolder.Name = "txtImagesFolder"
      Me.txtImagesFolder.Size = New System.Drawing.Size(320, 20)
      Me.txtImagesFolder.TabIndex = 7
      '
      'lblImages
      '
      Me.lblImages.AutoSize = True
      Me.lblImages.Location = New System.Drawing.Point(5, 57)
      Me.lblImages.Name = "lblImages"
      Me.lblImages.Size = New System.Drawing.Size(76, 13)
      Me.lblImages.TabIndex = 6
      Me.lblImages.Text = "Images &Folder:"
      '
      'mtxtPort
      '
      Me.mtxtPort.HidePromptOnLeave = True
      Me.mtxtPort.Location = New System.Drawing.Point(324, 32)
      Me.mtxtPort.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.mtxtPort.Mask = "00000"
      Me.mtxtPort.Name = "mtxtPort"
      Me.mtxtPort.Size = New System.Drawing.Size(86, 20)
      Me.mtxtPort.TabIndex = 5
      Me.mtxtPort.ValidatingType = GetType(Integer)
      '
      'lblPort
      '
      Me.lblPort.AutoSize = True
      Me.lblPort.Location = New System.Drawing.Point(285, 35)
      Me.lblPort.Name = "lblPort"
      Me.lblPort.Size = New System.Drawing.Size(29, 13)
      Me.lblPort.TabIndex = 4
      Me.lblPort.Text = "&Port:"
      '
      'txtIpAddress
      '
      Me.txtIpAddress.Location = New System.Drawing.Point(90, 32)
      Me.txtIpAddress.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.txtIpAddress.Name = "txtIpAddress"
      Me.txtIpAddress.Size = New System.Drawing.Size(190, 20)
      Me.txtIpAddress.TabIndex = 3
      '
      'lblIpAddress
      '
      Me.lblIpAddress.AutoSize = True
      Me.lblIpAddress.Location = New System.Drawing.Point(6, 32)
      Me.lblIpAddress.Name = "lblIpAddress"
      Me.lblIpAddress.Size = New System.Drawing.Size(61, 13)
      Me.lblIpAddress.TabIndex = 2
      Me.lblIpAddress.Text = "&IP Address:"
      '
      'lblServerName
      '
      Me.lblServerName.AutoSize = True
      Me.lblServerName.Location = New System.Drawing.Point(6, 8)
      Me.lblServerName.Name = "lblServerName"
      Me.lblServerName.Size = New System.Drawing.Size(38, 13)
      Me.lblServerName.TabIndex = 0
      Me.lblServerName.Text = "&Name:"
      '
      'txtServerName
      '
      Me.txtServerName.Location = New System.Drawing.Point(90, 8)
      Me.txtServerName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.txtServerName.Name = "txtServerName"
      Me.txtServerName.Size = New System.Drawing.Size(190, 20)
      Me.txtServerName.TabIndex = 1
      '
      'tbpClients
      '
      Me.tbpClients.Controls.Add(Me.chkClientUnlimitedBandWidth)
      Me.tbpClients.Controls.Add(Me.lblConnectionIdleSeconds)
      Me.tbpClients.Controls.Add(Me.mtxtConnectionIdleTimeout)
      Me.tbpClients.Controls.Add(Me.lblConnectionIdle)
      Me.tbpClients.Controls.Add(Me.lblConnectionBWKBS)
      Me.tbpClients.Controls.Add(Me.mtxtConnectionBW)
      Me.tbpClients.Controls.Add(Me.lblConnectionBW)
      Me.tbpClients.Controls.Add(Me.lblSessionLifeSeconds)
      Me.tbpClients.Controls.Add(Me.mtxtMaxSessionLife)
      Me.tbpClients.Controls.Add(Me.lblMaxSessionLife)
      Me.tbpClients.Controls.Add(Me.mtxtMaxClients)
      Me.tbpClients.Controls.Add(Me.lblMaxClients)
      Me.tbpClients.Location = New System.Drawing.Point(4, 22)
      Me.tbpClients.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.tbpClients.Name = "tbpClients"
      Me.tbpClients.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.tbpClients.Size = New System.Drawing.Size(501, 375)
      Me.tbpClients.TabIndex = 1
      Me.tbpClients.Text = "Clients Settings"
      Me.tbpClients.UseVisualStyleBackColor = True
      '
      'chkClientUnlimitedBandWidth
      '
      Me.chkClientUnlimitedBandWidth.AutoSize = True
      Me.chkClientUnlimitedBandWidth.Checked = True
      Me.chkClientUnlimitedBandWidth.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkClientUnlimitedBandWidth.Location = New System.Drawing.Point(279, 73)
      Me.chkClientUnlimitedBandWidth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.chkClientUnlimitedBandWidth.Name = "chkClientUnlimitedBandWidth"
      Me.chkClientUnlimitedBandWidth.Size = New System.Drawing.Size(69, 17)
      Me.chkClientUnlimitedBandWidth.TabIndex = 11
      Me.chkClientUnlimitedBandWidth.Text = "Unlimited"
      Me.chkClientUnlimitedBandWidth.UseVisualStyleBackColor = True
      '
      'lblConnectionIdleSeconds
      '
      Me.lblConnectionIdleSeconds.AutoSize = True
      Me.lblConnectionIdleSeconds.Location = New System.Drawing.Point(251, 28)
      Me.lblConnectionIdleSeconds.Name = "lblConnectionIdleSeconds"
      Me.lblConnectionIdleSeconds.Size = New System.Drawing.Size(49, 13)
      Me.lblConnectionIdleSeconds.TabIndex = 4
      Me.lblConnectionIdleSeconds.Text = "Seconds"
      '
      'mtxtConnectionIdleTimeout
      '
      Me.mtxtConnectionIdleTimeout.HidePromptOnLeave = True
      Me.mtxtConnectionIdleTimeout.Location = New System.Drawing.Point(163, 28)
      Me.mtxtConnectionIdleTimeout.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.mtxtConnectionIdleTimeout.Mask = "0000000"
      Me.mtxtConnectionIdleTimeout.Name = "mtxtConnectionIdleTimeout"
      Me.mtxtConnectionIdleTimeout.Size = New System.Drawing.Size(86, 20)
      Me.mtxtConnectionIdleTimeout.TabIndex = 3
      Me.mtxtConnectionIdleTimeout.ValidatingType = GetType(Integer)
      '
      'lblConnectionIdle
      '
      Me.lblConnectionIdle.AutoSize = True
      Me.lblConnectionIdle.Location = New System.Drawing.Point(5, 32)
      Me.lblConnectionIdle.Name = "lblConnectionIdle"
      Me.lblConnectionIdle.Size = New System.Drawing.Size(119, 13)
      Me.lblConnectionIdle.TabIndex = 2
      Me.lblConnectionIdle.Text = "&Connection Idle Timout:"
      '
      'lblConnectionBWKBS
      '
      Me.lblConnectionBWKBS.AutoSize = True
      Me.lblConnectionBWKBS.Location = New System.Drawing.Point(251, 73)
      Me.lblConnectionBWKBS.Name = "lblConnectionBWKBS"
      Me.lblConnectionBWKBS.Size = New System.Drawing.Size(24, 13)
      Me.lblConnectionBWKBS.TabIndex = 10
      Me.lblConnectionBWKBS.Text = "B/s"
      '
      'mtxtConnectionBW
      '
      Me.mtxtConnectionBW.HidePromptOnLeave = True
      Me.mtxtConnectionBW.Location = New System.Drawing.Point(162, 73)
      Me.mtxtConnectionBW.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.mtxtConnectionBW.Mask = "0000000000"
      Me.mtxtConnectionBW.Name = "mtxtConnectionBW"
      Me.mtxtConnectionBW.Size = New System.Drawing.Size(86, 20)
      Me.mtxtConnectionBW.TabIndex = 9
      Me.mtxtConnectionBW.ValidatingType = GetType(Integer)
      '
      'lblConnectionBW
      '
      Me.lblConnectionBW.AutoSize = True
      Me.lblConnectionBW.Location = New System.Drawing.Point(5, 76)
      Me.lblConnectionBW.Name = "lblConnectionBW"
      Me.lblConnectionBW.Size = New System.Drawing.Size(143, 13)
      Me.lblConnectionBW.TabIndex = 8
      Me.lblConnectionBW.Text = "Ma&x. Connection Bandwidth:"
      '
      'lblSessionLifeSeconds
      '
      Me.lblSessionLifeSeconds.AutoSize = True
      Me.lblSessionLifeSeconds.Location = New System.Drawing.Point(251, 50)
      Me.lblSessionLifeSeconds.Name = "lblSessionLifeSeconds"
      Me.lblSessionLifeSeconds.Size = New System.Drawing.Size(49, 13)
      Me.lblSessionLifeSeconds.TabIndex = 7
      Me.lblSessionLifeSeconds.Text = "Seconds"
      '
      'mtxtMaxSessionLife
      '
      Me.mtxtMaxSessionLife.HidePromptOnLeave = True
      Me.mtxtMaxSessionLife.Location = New System.Drawing.Point(162, 50)
      Me.mtxtMaxSessionLife.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.mtxtMaxSessionLife.Mask = "0000000000"
      Me.mtxtMaxSessionLife.Name = "mtxtMaxSessionLife"
      Me.mtxtMaxSessionLife.Size = New System.Drawing.Size(86, 20)
      Me.mtxtMaxSessionLife.TabIndex = 6
      Me.mtxtMaxSessionLife.ValidatingType = GetType(Integer)
      '
      'lblMaxSessionLife
      '
      Me.lblMaxSessionLife.AutoSize = True
      Me.lblMaxSessionLife.Location = New System.Drawing.Point(6, 54)
      Me.lblMaxSessionLife.Name = "lblMaxSessionLife"
      Me.lblMaxSessionLife.Size = New System.Drawing.Size(112, 13)
      Me.lblMaxSessionLife.TabIndex = 5
      Me.lblMaxSessionLife.Text = "M&ax. Session Lifetime:"
      '
      'mtxtMaxClients
      '
      Me.mtxtMaxClients.HidePromptOnLeave = True
      Me.mtxtMaxClients.Location = New System.Drawing.Point(162, 6)
      Me.mtxtMaxClients.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.mtxtMaxClients.Mask = "00000"
      Me.mtxtMaxClients.Name = "mtxtMaxClients"
      Me.mtxtMaxClients.Size = New System.Drawing.Size(86, 20)
      Me.mtxtMaxClients.TabIndex = 1
      Me.mtxtMaxClients.ValidatingType = GetType(Integer)
      '
      'lblMaxClients
      '
      Me.lblMaxClients.AutoSize = True
      Me.lblMaxClients.Location = New System.Drawing.Point(5, 10)
      Me.lblMaxClients.Name = "lblMaxClients"
      Me.lblMaxClients.Size = New System.Drawing.Size(98, 13)
      Me.lblMaxClients.TabIndex = 0
      Me.lblMaxClients.Text = "&Max. Clients Count:"
      '
      'tbpCommunication
      '
      Me.tbpCommunication.Controls.Add(Me.chkCommunicationUnlimitedRequest)
      Me.tbpCommunication.Controls.Add(Me.lblChunkBytes)
      Me.tbpCommunication.Controls.Add(Me.lblChunkSize)
      Me.tbpCommunication.Controls.Add(Me.mtxtChunkSize)
      Me.tbpCommunication.Controls.Add(Me.lblRequestTimeoutSeconds)
      Me.tbpCommunication.Controls.Add(Me.lblRequesttimeout)
      Me.tbpCommunication.Controls.Add(Me.mtxtRequestTimeout)
      Me.tbpCommunication.Controls.Add(Me.lblHandshaketimeoutSeconds)
      Me.tbpCommunication.Controls.Add(Me.lblHandshakeTimeout)
      Me.tbpCommunication.Controls.Add(Me.mtxtHandshakeTimeout)
      Me.tbpCommunication.Controls.Add(Me.lblMaxTRansport)
      Me.tbpCommunication.Controls.Add(Me.mtxtMaxTransport)
      Me.tbpCommunication.Location = New System.Drawing.Point(4, 22)
      Me.tbpCommunication.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.tbpCommunication.Name = "tbpCommunication"
      Me.tbpCommunication.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.tbpCommunication.Size = New System.Drawing.Size(501, 375)
      Me.tbpCommunication.TabIndex = 2
      Me.tbpCommunication.Text = "Communication Settings"
      Me.tbpCommunication.UseVisualStyleBackColor = True
      '
      'chkCommunicationUnlimitedRequest
      '
      Me.chkCommunicationUnlimitedRequest.AutoSize = True
      Me.chkCommunicationUnlimitedRequest.Location = New System.Drawing.Point(318, 53)
      Me.chkCommunicationUnlimitedRequest.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.chkCommunicationUnlimitedRequest.Name = "chkCommunicationUnlimitedRequest"
      Me.chkCommunicationUnlimitedRequest.Size = New System.Drawing.Size(69, 17)
      Me.chkCommunicationUnlimitedRequest.TabIndex = 11
      Me.chkCommunicationUnlimitedRequest.Text = "Unlimited"
      Me.chkCommunicationUnlimitedRequest.UseVisualStyleBackColor = True
      '
      'lblChunkBytes
      '
      Me.lblChunkBytes.AutoSize = True
      Me.lblChunkBytes.Location = New System.Drawing.Point(261, 76)
      Me.lblChunkBytes.Name = "lblChunkBytes"
      Me.lblChunkBytes.Size = New System.Drawing.Size(33, 13)
      Me.lblChunkBytes.TabIndex = 10
      Me.lblChunkBytes.Text = "Bytes"
      '
      'lblChunkSize
      '
      Me.lblChunkSize.AutoSize = True
      Me.lblChunkSize.Location = New System.Drawing.Point(5, 76)
      Me.lblChunkSize.Name = "lblChunkSize"
      Me.lblChunkSize.Size = New System.Drawing.Size(64, 13)
      Me.lblChunkSize.TabIndex = 8
      Me.lblChunkSize.Text = "&Chunk Size:"
      '
      'mtxtChunkSize
      '
      Me.mtxtChunkSize.HidePromptOnLeave = True
      Me.mtxtChunkSize.Location = New System.Drawing.Point(170, 74)
      Me.mtxtChunkSize.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.mtxtChunkSize.Mask = "00000"
      Me.mtxtChunkSize.Name = "mtxtChunkSize"
      Me.mtxtChunkSize.Size = New System.Drawing.Size(86, 20)
      Me.mtxtChunkSize.TabIndex = 9
      Me.mtxtChunkSize.ValidatingType = GetType(Integer)
      '
      'lblRequestTimeoutSeconds
      '
      Me.lblRequestTimeoutSeconds.AutoSize = True
      Me.lblRequestTimeoutSeconds.Location = New System.Drawing.Point(261, 54)
      Me.lblRequestTimeoutSeconds.Name = "lblRequestTimeoutSeconds"
      Me.lblRequestTimeoutSeconds.Size = New System.Drawing.Size(49, 13)
      Me.lblRequestTimeoutSeconds.TabIndex = 7
      Me.lblRequestTimeoutSeconds.Text = "Seconds"
      '
      'lblRequesttimeout
      '
      Me.lblRequesttimeout.AutoSize = True
      Me.lblRequesttimeout.Location = New System.Drawing.Point(5, 53)
      Me.lblRequesttimeout.Name = "lblRequesttimeout"
      Me.lblRequesttimeout.Size = New System.Drawing.Size(91, 13)
      Me.lblRequesttimeout.TabIndex = 5
      Me.lblRequesttimeout.Text = "&Request Timeout:"
      '
      'mtxtRequestTimeout
      '
      Me.mtxtRequestTimeout.HidePromptOnLeave = True
      Me.mtxtRequestTimeout.Location = New System.Drawing.Point(170, 51)
      Me.mtxtRequestTimeout.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.mtxtRequestTimeout.Mask = "00000"
      Me.mtxtRequestTimeout.Name = "mtxtRequestTimeout"
      Me.mtxtRequestTimeout.Size = New System.Drawing.Size(86, 20)
      Me.mtxtRequestTimeout.TabIndex = 6
      Me.mtxtRequestTimeout.ValidatingType = GetType(Integer)
      '
      'lblHandshaketimeoutSeconds
      '
      Me.lblHandshaketimeoutSeconds.AutoSize = True
      Me.lblHandshaketimeoutSeconds.Location = New System.Drawing.Point(261, 31)
      Me.lblHandshaketimeoutSeconds.Name = "lblHandshaketimeoutSeconds"
      Me.lblHandshaketimeoutSeconds.Size = New System.Drawing.Size(49, 13)
      Me.lblHandshaketimeoutSeconds.TabIndex = 4
      Me.lblHandshaketimeoutSeconds.Text = "Seconds"
      '
      'lblHandshakeTimeout
      '
      Me.lblHandshakeTimeout.AutoSize = True
      Me.lblHandshakeTimeout.Location = New System.Drawing.Point(5, 30)
      Me.lblHandshakeTimeout.Name = "lblHandshakeTimeout"
      Me.lblHandshakeTimeout.Size = New System.Drawing.Size(106, 13)
      Me.lblHandshakeTimeout.TabIndex = 2
      Me.lblHandshakeTimeout.Text = "&Handshake Timeout:"
      '
      'mtxtHandshakeTimeout
      '
      Me.mtxtHandshakeTimeout.HidePromptOnLeave = True
      Me.mtxtHandshakeTimeout.Location = New System.Drawing.Point(170, 28)
      Me.mtxtHandshakeTimeout.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.mtxtHandshakeTimeout.Mask = "00000"
      Me.mtxtHandshakeTimeout.Name = "mtxtHandshakeTimeout"
      Me.mtxtHandshakeTimeout.Size = New System.Drawing.Size(86, 20)
      Me.mtxtHandshakeTimeout.TabIndex = 3
      Me.mtxtHandshakeTimeout.ValidatingType = GetType(Integer)
      '
      'lblMaxTRansport
      '
      Me.lblMaxTRansport.AutoSize = True
      Me.lblMaxTRansport.Location = New System.Drawing.Point(7, 6)
      Me.lblMaxTRansport.Name = "lblMaxTRansport"
      Me.lblMaxTRansport.Size = New System.Drawing.Size(143, 13)
      Me.lblMaxTRansport.TabIndex = 0
      Me.lblMaxTRansport.Text = "&Max. Transport Connections:"
      '
      'mtxtMaxTransport
      '
      Me.mtxtMaxTransport.HidePromptOnLeave = True
      Me.mtxtMaxTransport.Location = New System.Drawing.Point(171, 5)
      Me.mtxtMaxTransport.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.mtxtMaxTransport.Mask = "00000"
      Me.mtxtMaxTransport.Name = "mtxtMaxTransport"
      Me.mtxtMaxTransport.Size = New System.Drawing.Size(86, 20)
      Me.mtxtMaxTransport.TabIndex = 1
      Me.mtxtMaxTransport.ValidatingType = GetType(Integer)
      '
      'tbpImages
      '
      Me.tbpImages.Controls.Add(Me.chkImageParsingTimeout)
      Me.tbpImages.Controls.Add(Me.mtxtPartitionSize)
      Me.tbpImages.Controls.Add(Me.lblPartitionSizeBytes)
      Me.tbpImages.Controls.Add(Me.lblPartionSize)
      Me.tbpImages.Controls.Add(Me.lblParsingTimeoutSeconds)
      Me.tbpImages.Controls.Add(Me.chkDivideSuperBoxes)
      Me.tbpImages.Controls.Add(Me.mtxtParsingTimeout)
      Me.tbpImages.Controls.Add(Me.lblParsingTimeout)
      Me.tbpImages.Location = New System.Drawing.Point(4, 22)
      Me.tbpImages.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.tbpImages.Name = "tbpImages"
      Me.tbpImages.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.tbpImages.Size = New System.Drawing.Size(501, 375)
      Me.tbpImages.TabIndex = 3
      Me.tbpImages.Text = "Images"
      Me.tbpImages.UseVisualStyleBackColor = True
      '
      'chkImageParsingTimeout
      '
      Me.chkImageParsingTimeout.AutoSize = True
      Me.chkImageParsingTimeout.Location = New System.Drawing.Point(337, 8)
      Me.chkImageParsingTimeout.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.chkImageParsingTimeout.Name = "chkImageParsingTimeout"
      Me.chkImageParsingTimeout.Size = New System.Drawing.Size(69, 17)
      Me.chkImageParsingTimeout.TabIndex = 7
      Me.chkImageParsingTimeout.Text = "Unlimited"
      Me.chkImageParsingTimeout.UseVisualStyleBackColor = True
      '
      'mtxtPartitionSize
      '
      Me.mtxtPartitionSize.HidePromptOnLeave = True
      Me.mtxtPartitionSize.Location = New System.Drawing.Point(189, 34)
      Me.mtxtPartitionSize.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.mtxtPartitionSize.Mask = "00000"
      Me.mtxtPartitionSize.Name = "mtxtPartitionSize"
      Me.mtxtPartitionSize.Size = New System.Drawing.Size(86, 20)
      Me.mtxtPartitionSize.TabIndex = 4
      Me.mtxtPartitionSize.ValidatingType = GetType(Integer)
      '
      'lblPartitionSizeBytes
      '
      Me.lblPartitionSizeBytes.AutoSize = True
      Me.lblPartitionSizeBytes.Location = New System.Drawing.Point(280, 34)
      Me.lblPartitionSizeBytes.Name = "lblPartitionSizeBytes"
      Me.lblPartitionSizeBytes.Size = New System.Drawing.Size(32, 13)
      Me.lblPartitionSizeBytes.TabIndex = 5
      Me.lblPartitionSizeBytes.Text = "bytes"
      '
      'lblPartionSize
      '
      Me.lblPartionSize.AutoSize = True
      Me.lblPartionSize.Location = New System.Drawing.Point(5, 34)
      Me.lblPartionSize.Name = "lblPartionSize"
      Me.lblPartionSize.Size = New System.Drawing.Size(171, 13)
      Me.lblPartionSize.TabIndex = 3
      Me.lblPartionSize.Text = "Partition boxes which size exceeds"
      '
      'lblParsingTimeoutSeconds
      '
      Me.lblParsingTimeoutSeconds.AutoSize = True
      Me.lblParsingTimeoutSeconds.Location = New System.Drawing.Point(280, 8)
      Me.lblParsingTimeoutSeconds.Name = "lblParsingTimeoutSeconds"
      Me.lblParsingTimeoutSeconds.Size = New System.Drawing.Size(49, 13)
      Me.lblParsingTimeoutSeconds.TabIndex = 2
      Me.lblParsingTimeoutSeconds.Text = "Seconds"
      '
      'chkDivideSuperBoxes
      '
      Me.chkDivideSuperBoxes.AutoSize = True
      Me.chkDivideSuperBoxes.Checked = True
      Me.chkDivideSuperBoxes.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkDivideSuperBoxes.Location = New System.Drawing.Point(8, 59)
      Me.chkDivideSuperBoxes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.chkDivideSuperBoxes.Name = "chkDivideSuperBoxes"
      Me.chkDivideSuperBoxes.Size = New System.Drawing.Size(197, 17)
      Me.chkDivideSuperBoxes.TabIndex = 6
      Me.chkDivideSuperBoxes.Text = "Divide &Super Boxes into Placholders"
      Me.chkDivideSuperBoxes.UseVisualStyleBackColor = True
      '
      'mtxtParsingTimeout
      '
      Me.mtxtParsingTimeout.HidePromptOnLeave = True
      Me.mtxtParsingTimeout.Location = New System.Drawing.Point(189, 8)
      Me.mtxtParsingTimeout.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.mtxtParsingTimeout.Mask = "00000"
      Me.mtxtParsingTimeout.Name = "mtxtParsingTimeout"
      Me.mtxtParsingTimeout.Size = New System.Drawing.Size(86, 20)
      Me.mtxtParsingTimeout.TabIndex = 1
      Me.mtxtParsingTimeout.ValidatingType = GetType(Integer)
      '
      'lblParsingTimeout
      '
      Me.lblParsingTimeout.AutoSize = True
      Me.lblParsingTimeout.Location = New System.Drawing.Point(5, 11)
      Me.lblParsingTimeout.Name = "lblParsingTimeout"
      Me.lblParsingTimeout.Size = New System.Drawing.Size(86, 13)
      Me.lblParsingTimeout.TabIndex = 0
      Me.lblParsingTimeout.Text = "&Parsing Timeout:"
      '
      'tbpLoggin
      '
      Me.tbpLoggin.Controls.Add(Me.grpFileLog)
      Me.tbpLoggin.Controls.Add(Me.chkEnableLog)
      Me.tbpLoggin.Location = New System.Drawing.Point(4, 22)
      Me.tbpLoggin.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.tbpLoggin.Name = "tbpLoggin"
      Me.tbpLoggin.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.tbpLoggin.Size = New System.Drawing.Size(501, 375)
      Me.tbpLoggin.TabIndex = 4
      Me.tbpLoggin.Text = "Logging"
      Me.tbpLoggin.UseVisualStyleBackColor = True
      '
      'grpFileLog
      '
      Me.grpFileLog.Controls.Add(Me.button1)
      Me.grpFileLog.Controls.Add(Me.groupBox2)
      Me.grpFileLog.Controls.Add(Me.txtLogFile)
      Me.grpFileLog.Controls.Add(Me.label2)
      Me.grpFileLog.Location = New System.Drawing.Point(9, 27)
      Me.grpFileLog.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.grpFileLog.Name = "grpFileLog"
      Me.grpFileLog.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.grpFileLog.Size = New System.Drawing.Size(424, 150)
      Me.grpFileLog.TabIndex = 1
      Me.grpFileLog.TabStop = False
      Me.grpFileLog.Text = "File Logging:"
      '
      'button1
      '
      Me.button1.Location = New System.Drawing.Point(394, 24)
      Me.button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.button1.Name = "button1"
      Me.button1.Size = New System.Drawing.Size(25, 19)
      Me.button1.TabIndex = 12
      Me.button1.Text = "..."
      Me.button1.UseVisualStyleBackColor = True
      '
      'groupBox2
      '
      Me.groupBox2.Controls.Add(Me.chkLogInformation)
      Me.groupBox2.Controls.Add(Me.chkLogDebug)
      Me.groupBox2.Controls.Add(Me.chkLogWarnings)
      Me.groupBox2.Controls.Add(Me.chkLogErrors)
      Me.groupBox2.Location = New System.Drawing.Point(12, 54)
      Me.groupBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.groupBox2.Name = "groupBox2"
      Me.groupBox2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.groupBox2.Size = New System.Drawing.Size(203, 81)
      Me.groupBox2.TabIndex = 0
      Me.groupBox2.TabStop = False
      Me.groupBox2.Text = "Filter Logs Types:"
      '
      'chkLogInformation
      '
      Me.chkLogInformation.AutoSize = True
      Me.chkLogInformation.Location = New System.Drawing.Point(5, 26)
      Me.chkLogInformation.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.chkLogInformation.Name = "chkLogInformation"
      Me.chkLogInformation.Size = New System.Drawing.Size(78, 17)
      Me.chkLogInformation.TabIndex = 0
      Me.chkLogInformation.Text = "Information"
      Me.chkLogInformation.UseVisualStyleBackColor = True
      '
      'chkLogDebug
      '
      Me.chkLogDebug.AutoSize = True
      Me.chkLogDebug.Location = New System.Drawing.Point(5, 59)
      Me.chkLogDebug.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.chkLogDebug.Name = "chkLogDebug"
      Me.chkLogDebug.Size = New System.Drawing.Size(58, 17)
      Me.chkLogDebug.TabIndex = 2
      Me.chkLogDebug.Text = "Debug"
      Me.chkLogDebug.UseVisualStyleBackColor = True
      '
      'chkLogWarnings
      '
      Me.chkLogWarnings.AutoSize = True
      Me.chkLogWarnings.Location = New System.Drawing.Point(114, 26)
      Me.chkLogWarnings.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.chkLogWarnings.Name = "chkLogWarnings"
      Me.chkLogWarnings.Size = New System.Drawing.Size(71, 17)
      Me.chkLogWarnings.TabIndex = 1
      Me.chkLogWarnings.Text = "Warnings"
      Me.chkLogWarnings.UseVisualStyleBackColor = True
      '
      'chkLogErrors
      '
      Me.chkLogErrors.AutoSize = True
      Me.chkLogErrors.Location = New System.Drawing.Point(114, 59)
      Me.chkLogErrors.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.chkLogErrors.Name = "chkLogErrors"
      Me.chkLogErrors.Size = New System.Drawing.Size(53, 17)
      Me.chkLogErrors.TabIndex = 3
      Me.chkLogErrors.Text = "Errors"
      Me.chkLogErrors.UseVisualStyleBackColor = True
      '
      'txtLogFile
      '
      Me.txtLogFile.Location = New System.Drawing.Point(88, 23)
      Me.txtLogFile.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.txtLogFile.Name = "txtLogFile"
      Me.txtLogFile.Size = New System.Drawing.Size(301, 20)
      Me.txtLogFile.TabIndex = 1
      '
      'label2
      '
      Me.label2.AutoSize = True
      Me.label2.Location = New System.Drawing.Point(9, 23)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(73, 13)
      Me.label2.TabIndex = 0
      Me.label2.Text = "Log file name:"
      '
      'chkEnableLog
      '
      Me.chkEnableLog.AutoSize = True
      Me.chkEnableLog.Checked = True
      Me.chkEnableLog.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkEnableLog.Location = New System.Drawing.Point(5, 5)
      Me.chkEnableLog.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.chkEnableLog.Name = "chkEnableLog"
      Me.chkEnableLog.Size = New System.Drawing.Size(100, 17)
      Me.chkEnableLog.TabIndex = 0
      Me.chkEnableLog.Text = "&Enable Logging"
      Me.chkEnableLog.UseVisualStyleBackColor = True
      '
      'tbpServerDelegation
      '
      Me.tbpServerDelegation.Controls.Add(Me.mtxtDelegatedServerLoad)
      Me.tbpServerDelegation.Controls.Add(Me.label5)
      Me.tbpServerDelegation.Controls.Add(Me.mtxtDelegatedServerPort)
      Me.tbpServerDelegation.Controls.Add(Me.txtDelegatedServerIP)
      Me.tbpServerDelegation.Controls.Add(Me.label3)
      Me.tbpServerDelegation.Controls.Add(Me.label4)
      Me.tbpServerDelegation.Controls.Add(Me.btnAddDelegatedServer)
      Me.tbpServerDelegation.Controls.Add(Me.btnRemoveDelegatedServer)
      Me.tbpServerDelegation.Controls.Add(Me.lsvServers)
      Me.tbpServerDelegation.Location = New System.Drawing.Point(4, 22)
      Me.tbpServerDelegation.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.tbpServerDelegation.Name = "tbpServerDelegation"
      Me.tbpServerDelegation.Size = New System.Drawing.Size(501, 375)
      Me.tbpServerDelegation.TabIndex = 5
      Me.tbpServerDelegation.Text = "Server Delegation"
      Me.tbpServerDelegation.UseVisualStyleBackColor = True
      '
      'mtxtDelegatedServerLoad
      '
      Me.mtxtDelegatedServerLoad.HidePromptOnLeave = True
      Me.mtxtDelegatedServerLoad.Location = New System.Drawing.Point(80, 63)
      Me.mtxtDelegatedServerLoad.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.mtxtDelegatedServerLoad.Mask = "000"
      Me.mtxtDelegatedServerLoad.Name = "mtxtDelegatedServerLoad"
      Me.mtxtDelegatedServerLoad.Size = New System.Drawing.Size(86, 20)
      Me.mtxtDelegatedServerLoad.TabIndex = 5
      Me.mtxtDelegatedServerLoad.ValidatingType = GetType(Integer)
      '
      'label5
      '
      Me.label5.AutoSize = True
      Me.label5.Location = New System.Drawing.Point(5, 63)
      Me.label5.Name = "label5"
      Me.label5.Size = New System.Drawing.Size(68, 13)
      Me.label5.TabIndex = 4
      Me.label5.Text = "Server &Load:"
      '
      'mtxtDelegatedServerPort
      '
      Me.mtxtDelegatedServerPort.HidePromptOnLeave = True
      Me.mtxtDelegatedServerPort.Location = New System.Drawing.Point(80, 37)
      Me.mtxtDelegatedServerPort.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.mtxtDelegatedServerPort.Mask = "000"
      Me.mtxtDelegatedServerPort.Name = "mtxtDelegatedServerPort"
      Me.mtxtDelegatedServerPort.Size = New System.Drawing.Size(86, 20)
      Me.mtxtDelegatedServerPort.TabIndex = 3
      Me.mtxtDelegatedServerPort.ValidatingType = GetType(Integer)
      '
      'txtDelegatedServerIP
      '
      Me.txtDelegatedServerIP.Location = New System.Drawing.Point(80, 11)
      Me.txtDelegatedServerIP.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.txtDelegatedServerIP.Name = "txtDelegatedServerIP"
      Me.txtDelegatedServerIP.Size = New System.Drawing.Size(163, 20)
      Me.txtDelegatedServerIP.TabIndex = 1
      '
      'label3
      '
      Me.label3.AutoSize = True
      Me.label3.Location = New System.Drawing.Point(5, 37)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(29, 13)
      Me.label3.TabIndex = 2
      Me.label3.Text = "&Port:"
      '
      'label4
      '
      Me.label4.AutoSize = True
      Me.label4.Location = New System.Drawing.Point(5, 11)
      Me.label4.Name = "label4"
      Me.label4.Size = New System.Drawing.Size(54, 13)
      Me.label4.TabIndex = 0
      Me.label4.Text = "&Server IP:"
      '
      'btnAddDelegatedServer
      '
      Me.btnAddDelegatedServer.Location = New System.Drawing.Point(5, 94)
      Me.btnAddDelegatedServer.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.btnAddDelegatedServer.Name = "btnAddDelegatedServer"
      Me.btnAddDelegatedServer.Size = New System.Drawing.Size(64, 26)
      Me.btnAddDelegatedServer.TabIndex = 6
      Me.btnAddDelegatedServer.Text = "&Add"
      Me.btnAddDelegatedServer.UseVisualStyleBackColor = True
      '
      'btnRemoveDelegatedServer
      '
      Me.btnRemoveDelegatedServer.Location = New System.Drawing.Point(5, 122)
      Me.btnRemoveDelegatedServer.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.btnRemoveDelegatedServer.Name = "btnRemoveDelegatedServer"
      Me.btnRemoveDelegatedServer.Size = New System.Drawing.Size(64, 27)
      Me.btnRemoveDelegatedServer.TabIndex = 7
      Me.btnRemoveDelegatedServer.Text = "&Remove"
      Me.btnRemoveDelegatedServer.UseVisualStyleBackColor = True
      '
      'lsvServers
      '
      Me.lsvServers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmServerIp, Me.clmServerPort, Me.clmServerLoad})
      Me.lsvServers.FullRowSelect = True
      Me.lsvServers.Location = New System.Drawing.Point(75, 94)
      Me.lsvServers.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.lsvServers.Name = "lsvServers"
      Me.lsvServers.Size = New System.Drawing.Size(412, 95)
      Me.lsvServers.TabIndex = 8
      Me.lsvServers.UseCompatibleStateImageBehavior = False
      Me.lsvServers.View = System.Windows.Forms.View.Details
      '
      'clmServerIp
      '
      Me.clmServerIp.Text = "IP Address"
      Me.clmServerIp.Width = 216
      '
      'clmServerPort
      '
      Me.clmServerPort.Text = "Port"
      Me.clmServerPort.Width = 105
      '
      'clmServerLoad
      '
      Me.clmServerLoad.Text = "Server Load"
      Me.clmServerLoad.Width = 131
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Location = New System.Drawing.Point(301, 424)
      Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(64, 22)
      Me.btnOK.TabIndex = 1
      Me.btnOK.Text = "OK"
      Me.btnOK.UseVisualStyleBackColor = True
      '
      'btnApply
      '
      Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnApply.Location = New System.Drawing.Point(370, 424)
      Me.btnApply.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.btnApply.Name = "btnApply"
      Me.btnApply.Size = New System.Drawing.Size(64, 22)
      Me.btnApply.TabIndex = 2
      Me.btnApply.Text = "&Apply"
      Me.btnApply.UseVisualStyleBackColor = True
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.CausesValidation = False
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(440, 424)
      Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(64, 22)
      Me.btnCancel.TabIndex = 3
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'btnReset
      '
      Me.btnReset.Location = New System.Drawing.Point(3, 394)
      Me.btnReset.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(64, 22)
      Me.btnReset.TabIndex = 4
      Me.btnReset.Text = "&Reset"
      Me.btnReset.UseVisualStyleBackColor = True
      '
      'openFileDialog1
      '
      Me.openFileDialog1.CheckFileExists = False
      '
      'btnImportImage
      '
      Me.btnImportImage.Location = New System.Drawing.Point(322, 104)
      Me.btnImportImage.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.btnImportImage.Name = "btnImportImage"
      Me.btnImportImage.Size = New System.Drawing.Size(118, 29)
      Me.btnImportImage.TabIndex = 21
      Me.btnImportImage.Text = "Import image file..."
      Me.btnImportImage.UseVisualStyleBackColor = True
      '
      'Configuration
      '
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(506, 451)
      Me.Controls.Add(Me.btnReset)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnApply)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.tbcMain)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Configuration"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Configuration"
      Me.tbcMain.ResumeLayout(False)
      Me.tbpServer.ResumeLayout(False)
      Me.tbpServer.PerformLayout()
      Me.grpALiases.ResumeLayout(False)
      Me.grpALiases.PerformLayout()
      Me.tbpClients.ResumeLayout(False)
      Me.tbpClients.PerformLayout()
      Me.tbpCommunication.ResumeLayout(False)
      Me.tbpCommunication.PerformLayout()
      Me.tbpImages.ResumeLayout(False)
      Me.tbpImages.PerformLayout()
      Me.tbpLoggin.ResumeLayout(False)
      Me.tbpLoggin.PerformLayout()
      Me.grpFileLog.ResumeLayout(False)
      Me.grpFileLog.PerformLayout()
      Me.groupBox2.ResumeLayout(False)
      Me.groupBox2.PerformLayout()
      Me.tbpServerDelegation.ResumeLayout(False)
      Me.tbpServerDelegation.PerformLayout()
      Me.ResumeLayout(False)

End Sub

#End Region

      Private tbcMain As System.Windows.Forms.TabControl
      Private tbpServer As System.Windows.Forms.TabPage
      Private tbpClients As System.Windows.Forms.TabPage
      Private label1 As System.Windows.Forms.Label
      Private mtxtServerBandwidth As System.Windows.Forms.MaskedTextBox
      Private lbMaxlSeverBandwidth As System.Windows.Forms.Label
      Private lblCacheSizeMB As System.Windows.Forms.Label
      Private mtxtCacheSize As System.Windows.Forms.MaskedTextBox
      Private lblCacheSize As System.Windows.Forms.Label
      Private WithEvents btnBrowseCache As System.Windows.Forms.Button
      Private txtCacheFolder As System.Windows.Forms.TextBox
      Private lblCacheFolder As System.Windows.Forms.Label
      Private WithEvents btnBrowseImages As System.Windows.Forms.Button
      Private txtImagesFolder As System.Windows.Forms.TextBox
      Private lblImages As System.Windows.Forms.Label
      Private mtxtPort As System.Windows.Forms.MaskedTextBox
      Private lblPort As System.Windows.Forms.Label
      Private WithEvents txtIpAddress As System.Windows.Forms.TextBox
      Private lblIpAddress As System.Windows.Forms.Label
      Private lblServerName As System.Windows.Forms.Label
      Private txtServerName As System.Windows.Forms.TextBox
      Private lblConnectionIdleSeconds As System.Windows.Forms.Label
      Private mtxtConnectionIdleTimeout As System.Windows.Forms.MaskedTextBox
      Private lblConnectionIdle As System.Windows.Forms.Label
      Private lblConnectionBWKBS As System.Windows.Forms.Label
      Private mtxtConnectionBW As System.Windows.Forms.MaskedTextBox
      Private lblConnectionBW As System.Windows.Forms.Label
      Private lblSessionLifeSeconds As System.Windows.Forms.Label
      Private mtxtMaxSessionLife As System.Windows.Forms.MaskedTextBox
      Private lblMaxSessionLife As System.Windows.Forms.Label
      Private mtxtMaxClients As System.Windows.Forms.MaskedTextBox
      Private lblMaxClients As System.Windows.Forms.Label
      Private tbpCommunication As System.Windows.Forms.TabPage
      Private lblMaxTRansport As System.Windows.Forms.Label
      Private mtxtMaxTransport As System.Windows.Forms.MaskedTextBox
      Private lblHandshakeTimeout As System.Windows.Forms.Label
      Private mtxtHandshakeTimeout As System.Windows.Forms.MaskedTextBox
      Private lblHandshaketimeoutSeconds As System.Windows.Forms.Label
      Private lblRequestTimeoutSeconds As System.Windows.Forms.Label
      Private lblRequesttimeout As System.Windows.Forms.Label
      Private mtxtRequestTimeout As System.Windows.Forms.MaskedTextBox
      Private lblChunkBytes As System.Windows.Forms.Label
      Private lblChunkSize As System.Windows.Forms.Label
      Private mtxtChunkSize As System.Windows.Forms.MaskedTextBox
      Private tbpImages As System.Windows.Forms.TabPage
      Private mtxtParsingTimeout As System.Windows.Forms.MaskedTextBox
      Private lblParsingTimeout As System.Windows.Forms.Label
      Private chkDivideSuperBoxes As System.Windows.Forms.CheckBox
      Private grpALiases As System.Windows.Forms.GroupBox
      Private WithEvents btnAdd As System.Windows.Forms.Button
      Private WithEvents btnRemove As System.Windows.Forms.Button
      Private lsvAliases As System.Windows.Forms.ListView
      Private lblPath As System.Windows.Forms.Label
      Private lblAlias As System.Windows.Forms.Label
      Private txtAliasPath As System.Windows.Forms.TextBox
      Private txtAlias As System.Windows.Forms.TextBox
      Private WithEvents btnBrowsePath As System.Windows.Forms.Button
      Private clmhALias As System.Windows.Forms.ColumnHeader
      Private clmhPath As System.Windows.Forms.ColumnHeader
      Private lblParsingTimeoutSeconds As System.Windows.Forms.Label
      Private WithEvents btnOK As System.Windows.Forms.Button
      Private WithEvents btnApply As System.Windows.Forms.Button
      Private btnCancel As System.Windows.Forms.Button
      Private folderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
      Private lblPartitionSizeBytes As System.Windows.Forms.Label
      Private lblPartionSize As System.Windows.Forms.Label
      Private mtxtPartitionSize As System.Windows.Forms.MaskedTextBox
      Private tbpLoggin As System.Windows.Forms.TabPage
      Private chkEnableLog As System.Windows.Forms.CheckBox
      Private grpFileLog As System.Windows.Forms.GroupBox
      Private groupBox2 As System.Windows.Forms.GroupBox
      Private chkLogInformation As System.Windows.Forms.CheckBox
      Private chkLogDebug As System.Windows.Forms.CheckBox
      Private chkLogWarnings As System.Windows.Forms.CheckBox
      Private chkLogErrors As System.Windows.Forms.CheckBox
      Private txtLogFile As System.Windows.Forms.TextBox
      Private label2 As System.Windows.Forms.Label
      Private WithEvents btnReset As System.Windows.Forms.Button
      Private tbpServerDelegation As System.Windows.Forms.TabPage
      Private mtxtDelegatedServerPort As System.Windows.Forms.MaskedTextBox
      Private WithEvents txtDelegatedServerIP As System.Windows.Forms.TextBox
      Private label3 As System.Windows.Forms.Label
      Private label4 As System.Windows.Forms.Label
      Private WithEvents btnAddDelegatedServer As System.Windows.Forms.Button
      Private WithEvents btnRemoveDelegatedServer As System.Windows.Forms.Button
      Private lsvServers As System.Windows.Forms.ListView
      Private clmServerIp As System.Windows.Forms.ColumnHeader
      Private clmServerPort As System.Windows.Forms.ColumnHeader
      Private mtxtDelegatedServerLoad As System.Windows.Forms.MaskedTextBox
      Private label5 As System.Windows.Forms.Label
      Private clmServerLoad As System.Windows.Forms.ColumnHeader
      Private WithEvents button1 As System.Windows.Forms.Button
      Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
      Private WithEvents chkServerUnlimitedBandWidth As System.Windows.Forms.CheckBox
      Private WithEvents chkClientUnlimitedBandWidth As System.Windows.Forms.CheckBox
      Friend WithEvents chkCommunicationUnlimitedRequest As System.Windows.Forms.CheckBox
   Friend WithEvents chkImageParsingTimeout As System.Windows.Forms.CheckBox
   Private WithEvents btnImportImage As System.Windows.Forms.Button
   End Class
