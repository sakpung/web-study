Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Namespace Leadtools.Dicom.Server.Manager
   Partial Public Class MainForm
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
         Me.components = New System.ComponentModel.Container
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me.toolStripClients = New System.Windows.Forms.ToolStrip
         Me.toolStripButtonViewAssociation = New System.Windows.Forms.ToolStripButton
         Me.toolStripButtonDisconnectClient = New System.Windows.Forms.ToolStripButton
         Me.labelServer = New System.Windows.Forms.Label
         Me.tabControl1 = New System.Windows.Forms.TabControl
         Me.tabPageAeTitles = New System.Windows.Forms.TabPage
         Me.toolStripContainer1 = New System.Windows.Forms.ToolStripContainer
         Me.listViewAeTitles = New System.Windows.Forms.ListView
         Me.columnHeaderAeTitle = New System.Windows.Forms.ColumnHeader
         Me.columnHeaderHostname = New System.Windows.Forms.ColumnHeader
         Me.columnHeaderPort = New System.Windows.Forms.ColumnHeader
         Me.columnHeaderSecurePort = New System.Windows.Forms.ColumnHeader
         Me.toolStripAeTitle = New System.Windows.Forms.ToolStrip
         Me.toolStripButtonAddAeTitle = New System.Windows.Forms.ToolStripButton
         Me.toolStripButtonEditAeTitle = New System.Windows.Forms.ToolStripButton
         Me.toolStripButtonDeleteAeTitle = New System.Windows.Forms.ToolStripButton
         Me.tabPageClients = New System.Windows.Forms.TabPage
         Me.toolStripContainer2 = New System.Windows.Forms.ToolStripContainer
         Me.listViewClients = New System.Windows.Forms.ListView
         Me.columnIpAddress = New System.Windows.Forms.ColumnHeader
         Me.columnAeTitle = New System.Windows.Forms.ColumnHeader
         Me.columnConnectTime = New System.Windows.Forms.ColumnHeader
         Me.columnLastAction = New System.Windows.Forms.ColumnHeader
         Me.toolStripMain = New System.Windows.Forms.ToolStrip
         Me.toolStripButtonAddServer = New System.Windows.Forms.ToolStripButton
         Me.toolStripButtonEditServer = New System.Windows.Forms.ToolStripButton
         Me.toolStripButtonDeleteServer = New System.Windows.Forms.ToolStripButton
         Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
         Me.toolStripButtonStart = New System.Windows.Forms.ToolStripButton
         Me.toolStripButtonPause = New System.Windows.Forms.ToolStripButton
         Me.toolStripButtonStop = New System.Windows.Forms.ToolStripButton
         Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
         Me.toolStripButtonStartAll = New System.Windows.Forms.ToolStripButton
         Me.toolStripButtonStopAll = New System.Windows.Forms.ToolStripButton
         Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
         Me.toolStripButtonEventLog = New System.Windows.Forms.ToolStripButton
         Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
         Me.toolStripButtonHelp = New System.Windows.Forms.ToolStripButton
         Me.notifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
         Me.contextMenuStripNotifyIcon = New System.Windows.Forms.ContextMenuStrip(Me.components)
         Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
         Me.labelServerIp = New System.Windows.Forms.Label
         Me.labelServerPort = New System.Windows.Forms.Label
         Me.labelIpAddress = New System.Windows.Forms.Label
         Me.labelPort = New System.Windows.Forms.Label
         Me.listViewOptions = New System.Windows.Forms.ListView
         Me.imageListOptions = New System.Windows.Forms.ImageList(Me.components)
         Me.label2 = New System.Windows.Forms.Label
         Me.labelError = New System.Windows.Forms.Label
         Me.comboBoxService = New Leadtools.Dicom.Server.Manager.ComboBoxImage
         Me.toolTip = New System.Windows.Forms.ToolTip(Me.components)
         Me.toolStripClients.SuspendLayout()
         Me.tabControl1.SuspendLayout()
         Me.tabPageAeTitles.SuspendLayout()
         Me.toolStripContainer1.ContentPanel.SuspendLayout()
         Me.toolStripContainer1.TopToolStripPanel.SuspendLayout()
         Me.toolStripContainer1.SuspendLayout()
         Me.toolStripAeTitle.SuspendLayout()
         Me.tabPageClients.SuspendLayout()
         Me.toolStripContainer2.ContentPanel.SuspendLayout()
         Me.toolStripContainer2.TopToolStripPanel.SuspendLayout()
         Me.toolStripContainer2.SuspendLayout()
         Me.toolStripMain.SuspendLayout()
         Me.contextMenuStripNotifyIcon.SuspendLayout()
         Me.SuspendLayout()
         '
         'toolStripClients
         '
         Me.toolStripClients.Dock = System.Windows.Forms.DockStyle.None
         Me.toolStripClients.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
         Me.toolStripClients.ImageScalingSize = New System.Drawing.Size(32, 32)
         Me.toolStripClients.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripButtonViewAssociation, Me.toolStripButtonDisconnectClient})
         Me.toolStripClients.Location = New System.Drawing.Point(0, 0)
         Me.toolStripClients.Name = "toolStripClients"
         Me.toolStripClients.Size = New System.Drawing.Size(360, 39)
         Me.toolStripClients.Stretch = True
         Me.toolStripClients.TabIndex = 3
         '
         'toolStripButtonViewAssociation
         '
         Me.toolStripButtonViewAssociation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonViewAssociation.Image = Global.My.Resources.Resources.ClientAssociation_Image
         Me.toolStripButtonViewAssociation.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonViewAssociation.Name = "toolStripButtonViewAssociation"
         Me.toolStripButtonViewAssociation.Size = New System.Drawing.Size(36, 36)
         Me.toolStripButtonViewAssociation.Text = "View Assocation"
         '
         'toolStripButtonDisconnectClient
         '
         Me.toolStripButtonDisconnectClient.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonDisconnectClient.Image = Global.My.Resources.Resources.ClientDisconnect_Image
         Me.toolStripButtonDisconnectClient.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonDisconnectClient.Name = "toolStripButtonDisconnectClient"
         Me.toolStripButtonDisconnectClient.Size = New System.Drawing.Size(36, 36)
         Me.toolStripButtonDisconnectClient.Text = "Disconnect Client"
         '
         'labelServer
         '
         Me.labelServer.AutoSize = True
         Me.labelServer.Location = New System.Drawing.Point(10, 37)
         Me.labelServer.Name = "labelServer"
         Me.labelServer.Size = New System.Drawing.Size(46, 13)
         Me.labelServer.TabIndex = 0
         Me.labelServer.Text = "Service:"
         '
         'tabControl1
         '
         Me.tabControl1.Controls.Add(Me.tabPageAeTitles)
         Me.tabControl1.Controls.Add(Me.tabPageClients)
         Me.tabControl1.Location = New System.Drawing.Point(12, 107)
         Me.tabControl1.Name = "tabControl1"
         Me.tabControl1.SelectedIndex = 0
         Me.tabControl1.Size = New System.Drawing.Size(374, 336)
         Me.tabControl1.TabIndex = 11
         '
         'tabPageAeTitles
         '
         Me.tabPageAeTitles.Controls.Add(Me.toolStripContainer1)
         Me.tabPageAeTitles.Location = New System.Drawing.Point(4, 22)
         Me.tabPageAeTitles.Name = "tabPageAeTitles"
         Me.tabPageAeTitles.Padding = New System.Windows.Forms.Padding(3)
         Me.tabPageAeTitles.Size = New System.Drawing.Size(366, 310)
         Me.tabPageAeTitles.TabIndex = 1
         Me.tabPageAeTitles.Text = "Client Nodes"
         Me.tabPageAeTitles.UseVisualStyleBackColor = True
         '
         'toolStripContainer1
         '
         Me.toolStripContainer1.BottomToolStripPanelVisible = False
         '
         'toolStripContainer1.ContentPanel
         '
         Me.toolStripContainer1.ContentPanel.Controls.Add(Me.listViewAeTitles)
         Me.toolStripContainer1.ContentPanel.Size = New System.Drawing.Size(360, 265)
         Me.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
         Me.toolStripContainer1.LeftToolStripPanelVisible = False
         Me.toolStripContainer1.Location = New System.Drawing.Point(3, 3)
         Me.toolStripContainer1.Name = "toolStripContainer1"
         Me.toolStripContainer1.RightToolStripPanelVisible = False
         Me.toolStripContainer1.Size = New System.Drawing.Size(360, 304)
         Me.toolStripContainer1.TabIndex = 4
         Me.toolStripContainer1.Text = "toolStripContainer1"
         '
         'toolStripContainer1.TopToolStripPanel
         '
         Me.toolStripContainer1.TopToolStripPanel.Controls.Add(Me.toolStripAeTitle)
         '
         'listViewAeTitles
         '
         Me.listViewAeTitles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeaderAeTitle, Me.columnHeaderHostname, Me.columnHeaderPort, Me.columnHeaderSecurePort})
         Me.listViewAeTitles.Dock = System.Windows.Forms.DockStyle.Fill
         Me.listViewAeTitles.FullRowSelect = True
         Me.listViewAeTitles.GridLines = True
         Me.listViewAeTitles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
         Me.listViewAeTitles.HideSelection = False
         Me.listViewAeTitles.Location = New System.Drawing.Point(0, 0)
         Me.listViewAeTitles.MultiSelect = False
         Me.listViewAeTitles.Name = "listViewAeTitles"
         Me.listViewAeTitles.Size = New System.Drawing.Size(360, 265)
         Me.listViewAeTitles.TabIndex = 3
         Me.listViewAeTitles.UseCompatibleStateImageBehavior = False
         Me.listViewAeTitles.View = System.Windows.Forms.View.Details
         '
         'columnHeaderAeTitle
         '
         Me.columnHeaderAeTitle.Text = "AE Title"
         Me.columnHeaderAeTitle.Width = 103
         '
         'columnHeaderHostname
         '
         Me.columnHeaderHostname.Text = "Address/Host Name"
         Me.columnHeaderHostname.Width = 118
         '
         'columnHeaderPort
         '
         Me.columnHeaderPort.Text = "Port"
         Me.columnHeaderPort.Width = 42
         '
         'columnHeaderSecurePort
         '
         Me.columnHeaderSecurePort.Text = "Secure Port"
         Me.columnHeaderSecurePort.Width = 100
         '
         'toolStripAeTitle
         '
         Me.toolStripAeTitle.Dock = System.Windows.Forms.DockStyle.None
         Me.toolStripAeTitle.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
         Me.toolStripAeTitle.ImageScalingSize = New System.Drawing.Size(32, 32)
         Me.toolStripAeTitle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripButtonAddAeTitle, Me.toolStripButtonEditAeTitle, Me.toolStripButtonDeleteAeTitle})
         Me.toolStripAeTitle.Location = New System.Drawing.Point(0, 0)
         Me.toolStripAeTitle.Name = "toolStripAeTitle"
         Me.toolStripAeTitle.Size = New System.Drawing.Size(360, 39)
         Me.toolStripAeTitle.Stretch = True
         Me.toolStripAeTitle.TabIndex = 6
         '
         'toolStripButtonAddAeTitle
         '
         Me.toolStripButtonAddAeTitle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonAddAeTitle.Image = Global.My.Resources.Resources.AeTitleAdd_Image
         Me.toolStripButtonAddAeTitle.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonAddAeTitle.Name = "toolStripButtonAddAeTitle"
         Me.toolStripButtonAddAeTitle.Size = New System.Drawing.Size(36, 36)
         Me.toolStripButtonAddAeTitle.Text = "Add AE Title"
         '
         'toolStripButtonEditAeTitle
         '
         Me.toolStripButtonEditAeTitle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonEditAeTitle.Image = Global.My.Resources.Resources.AeTitleEdit_Image
         Me.toolStripButtonEditAeTitle.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonEditAeTitle.Name = "toolStripButtonEditAeTitle"
         Me.toolStripButtonEditAeTitle.Size = New System.Drawing.Size(36, 36)
         Me.toolStripButtonEditAeTitle.Text = "Edit AE Title"
         '
         'toolStripButtonDeleteAeTitle
         '
         Me.toolStripButtonDeleteAeTitle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonDeleteAeTitle.Image = Global.My.Resources.Resources.AeTitleDelete_Image
         Me.toolStripButtonDeleteAeTitle.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonDeleteAeTitle.Name = "toolStripButtonDeleteAeTitle"
         Me.toolStripButtonDeleteAeTitle.Size = New System.Drawing.Size(36, 36)
         Me.toolStripButtonDeleteAeTitle.Text = "Delete AE Title"
         '
         'tabPageClients
         '
         Me.tabPageClients.Controls.Add(Me.toolStripContainer2)
         Me.tabPageClients.Location = New System.Drawing.Point(4, 22)
         Me.tabPageClients.Name = "tabPageClients"
         Me.tabPageClients.Padding = New System.Windows.Forms.Padding(3)
         Me.tabPageClients.Size = New System.Drawing.Size(366, 310)
         Me.tabPageClients.TabIndex = 2
         Me.tabPageClients.Text = "Current Connections"
         Me.tabPageClients.UseVisualStyleBackColor = True
         '
         'toolStripContainer2
         '
         '
         'toolStripContainer2.ContentPanel
         '
         Me.toolStripContainer2.ContentPanel.Controls.Add(Me.listViewClients)
         Me.toolStripContainer2.ContentPanel.Size = New System.Drawing.Size(360, 265)
         Me.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill
         Me.toolStripContainer2.Location = New System.Drawing.Point(3, 3)
         Me.toolStripContainer2.Name = "toolStripContainer2"
         Me.toolStripContainer2.Size = New System.Drawing.Size(360, 304)
         Me.toolStripContainer2.TabIndex = 0
         Me.toolStripContainer2.Text = "toolStripContainer2"
         '
         'toolStripContainer2.TopToolStripPanel
         '
         Me.toolStripContainer2.TopToolStripPanel.Controls.Add(Me.toolStripClients)
         '
         'listViewClients
         '
         Me.listViewClients.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnIpAddress, Me.columnAeTitle, Me.columnConnectTime, Me.columnLastAction})
         Me.listViewClients.Dock = System.Windows.Forms.DockStyle.Fill
         Me.listViewClients.FullRowSelect = True
         Me.listViewClients.GridLines = True
         Me.listViewClients.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
         Me.listViewClients.HideSelection = False
         Me.listViewClients.Location = New System.Drawing.Point(0, 0)
         Me.listViewClients.MultiSelect = False
         Me.listViewClients.Name = "listViewClients"
         Me.listViewClients.Size = New System.Drawing.Size(360, 265)
         Me.listViewClients.TabIndex = 2
         Me.listViewClients.UseCompatibleStateImageBehavior = False
         Me.listViewClients.View = System.Windows.Forms.View.Details
         '
         'columnIpAddress
         '
         Me.columnIpAddress.Text = "IP Address"
         Me.columnIpAddress.Width = 95
         '
         'columnAeTitle
         '
         Me.columnAeTitle.Text = "AETitle"
         Me.columnAeTitle.Width = 100
         '
         'columnConnectTime
         '
         Me.columnConnectTime.Text = "Connect Time"
         Me.columnConnectTime.Width = 100
         '
         'columnLastAction
         '
         Me.columnLastAction.Text = "Last Action"
         Me.columnLastAction.Width = 150
         '
         'toolStripMain
         '
         Me.toolStripMain.ImageScalingSize = New System.Drawing.Size(32, 32)
         Me.toolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripButtonAddServer, Me.toolStripButtonEditServer, Me.toolStripButtonDeleteServer, Me.toolStripSeparator1, Me.toolStripButtonStart, Me.toolStripButtonPause, Me.toolStripButtonStop, Me.toolStripSeparator2, Me.toolStripButtonStartAll, Me.toolStripButtonStopAll, Me.toolStripSeparator3, Me.toolStripButtonEventLog, Me.toolStripSeparator4, Me.toolStripButtonHelp})
         Me.toolStripMain.Location = New System.Drawing.Point(0, 0)
         Me.toolStripMain.Name = "toolStripMain"
         Me.toolStripMain.Size = New System.Drawing.Size(479, 39)
         Me.toolStripMain.TabIndex = 13
         Me.toolStripMain.Text = "toolStrip1"
         '
         'toolStripButtonAddServer
         '
         Me.toolStripButtonAddServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonAddServer.Image = Global.My.Resources.Resources.ServiceAdd_Image
         Me.toolStripButtonAddServer.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonAddServer.Name = "toolStripButtonAddServer"
         Me.toolStripButtonAddServer.Size = New System.Drawing.Size(36, 36)
         Me.toolStripButtonAddServer.Text = "toolStripButtonAddServer"
         Me.toolStripButtonAddServer.ToolTipText = "Add Server"
         '
         'toolStripButtonEditServer
         '
         Me.toolStripButtonEditServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonEditServer.Image = Global.My.Resources.Resources.ServiceEdit_Image
         Me.toolStripButtonEditServer.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonEditServer.Name = "toolStripButtonEditServer"
         Me.toolStripButtonEditServer.Size = New System.Drawing.Size(36, 36)
         Me.toolStripButtonEditServer.Text = "toolStripButton2"
         Me.toolStripButtonEditServer.ToolTipText = "Edit Server"
         '
         'toolStripButtonDeleteServer
         '
         Me.toolStripButtonDeleteServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonDeleteServer.Image = Global.My.Resources.Resources.ServiceDelete_Image
         Me.toolStripButtonDeleteServer.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonDeleteServer.Name = "toolStripButtonDeleteServer"
         Me.toolStripButtonDeleteServer.Size = New System.Drawing.Size(36, 36)
         Me.toolStripButtonDeleteServer.Text = "toolStripButton3"
         Me.toolStripButtonDeleteServer.ToolTipText = "Delete Server"
         '
         'toolStripSeparator1
         '
         Me.toolStripSeparator1.Name = "toolStripSeparator1"
         Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 39)
         '
         'toolStripButtonStart
         '
         Me.toolStripButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonStart.Image = Global.My.Resources.Resources.StartService_Image
         Me.toolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonStart.Name = "toolStripButtonStart"
         Me.toolStripButtonStart.Size = New System.Drawing.Size(36, 36)
         Me.toolStripButtonStart.Text = "toolStripButton4"
         Me.toolStripButtonStart.ToolTipText = "Start Server"
         '
         'toolStripButtonPause
         '
         Me.toolStripButtonPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonPause.Image = Global.My.Resources.Resources.PauseService_Image
         Me.toolStripButtonPause.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonPause.Name = "toolStripButtonPause"
         Me.toolStripButtonPause.Size = New System.Drawing.Size(36, 36)
         Me.toolStripButtonPause.Text = "toolStripButton5"
         Me.toolStripButtonPause.ToolTipText = "Pause Server"
         '
         'toolStripButtonStop
         '
         Me.toolStripButtonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonStop.Image = Global.My.Resources.Resources.StopService_Image
         Me.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonStop.Name = "toolStripButtonStop"
         Me.toolStripButtonStop.Size = New System.Drawing.Size(36, 36)
         Me.toolStripButtonStop.Text = "Stop"
         Me.toolStripButtonStop.ToolTipText = "Stop Server"
         '
         'toolStripSeparator2
         '
         Me.toolStripSeparator2.Name = "toolStripSeparator2"
         Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 39)
         '
         'toolStripButtonStartAll
         '
         Me.toolStripButtonStartAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonStartAll.Image = Global.My.Resources.Resources.start_all
         Me.toolStripButtonStartAll.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonStartAll.Name = "toolStripButtonStartAll"
         Me.toolStripButtonStartAll.Size = New System.Drawing.Size(36, 36)
         Me.toolStripButtonStartAll.Text = "Start All"
         Me.toolStripButtonStartAll.ToolTipText = "Start All Servers"
         '
         'toolStripButtonStopAll
         '
         Me.toolStripButtonStopAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonStopAll.Image = Global.My.Resources.Resources.stop_all
         Me.toolStripButtonStopAll.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonStopAll.Name = "toolStripButtonStopAll"
         Me.toolStripButtonStopAll.Size = New System.Drawing.Size(36, 36)
         Me.toolStripButtonStopAll.Text = "Stop All"
         Me.toolStripButtonStopAll.ToolTipText = "Stop All Servers"
         '
         'toolStripSeparator3
         '
         Me.toolStripSeparator3.Name = "toolStripSeparator3"
         Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 39)
         '
         'toolStripButtonEventLog
         '
         Me.toolStripButtonEventLog.CheckOnClick = True
         Me.toolStripButtonEventLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonEventLog.Image = Global.My.Resources.Resources.ActivityReports
         Me.toolStripButtonEventLog.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonEventLog.Name = "toolStripButtonEventLog"
         Me.toolStripButtonEventLog.Size = New System.Drawing.Size(36, 36)
         Me.toolStripButtonEventLog.Text = "Log"
         '
         'toolStripSeparator4
         '
         Me.toolStripSeparator4.Name = "toolStripSeparator4"
         Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 39)
         '
         'toolStripButtonHelp
         '
         Me.toolStripButtonHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me.toolStripButtonHelp.Image = Global.My.Resources.Resources.Help_Image
         Me.toolStripButtonHelp.ImageTransparentColor = System.Drawing.Color.Magenta
         Me.toolStripButtonHelp.Name = "toolStripButtonHelp"
         Me.toolStripButtonHelp.Size = New System.Drawing.Size(36, 36)
         Me.toolStripButtonHelp.Text = "Help"
         '
         'notifyIcon
         '
         Me.notifyIcon.ContextMenuStrip = Me.contextMenuStripNotifyIcon
         Me.notifyIcon.Icon = CType(resources.GetObject("notifyIcon.Icon"), System.Drawing.Icon)
         Me.notifyIcon.Text = "notifyIcon"
         '
         'contextMenuStripNotifyIcon
         '
         Me.contextMenuStripNotifyIcon.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.exitToolStripMenuItem})
         Me.contextMenuStripNotifyIcon.Name = "contextMenuStripNotifyIcon"
         Me.contextMenuStripNotifyIcon.Size = New System.Drawing.Size(93, 26)
         '
         'exitToolStripMenuItem
         '
         Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
         Me.exitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
         Me.exitToolStripMenuItem.Text = "&Exit"
         '
         'labelServerIp
         '
         Me.labelServerIp.AutoSize = True
         Me.labelServerIp.Location = New System.Drawing.Point(10, 82)
         Me.labelServerIp.Name = "labelServerIp"
         Me.labelServerIp.Size = New System.Drawing.Size(61, 13)
         Me.labelServerIp.TabIndex = 14
         Me.labelServerIp.Text = "IP Address:"
         '
         'labelServerPort
         '
         Me.labelServerPort.AutoSize = True
         Me.labelServerPort.Location = New System.Drawing.Point(254, 82)
         Me.labelServerPort.Name = "labelServerPort"
         Me.labelServerPort.Size = New System.Drawing.Size(29, 13)
         Me.labelServerPort.TabIndex = 15
         Me.labelServerPort.Text = "Port:"
         '
         'labelIpAddress
         '
         Me.labelIpAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.labelIpAddress.Location = New System.Drawing.Point(77, 82)
         Me.labelIpAddress.Name = "labelIpAddress"
         Me.labelIpAddress.Size = New System.Drawing.Size(154, 13)
         Me.labelIpAddress.TabIndex = 16
         Me.labelIpAddress.Text = "label4"
         '
         'labelPort
         '
         Me.labelPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.labelPort.Location = New System.Drawing.Point(289, 82)
         Me.labelPort.Name = "labelPort"
         Me.labelPort.Size = New System.Drawing.Size(98, 13)
         Me.labelPort.TabIndex = 17
         Me.labelPort.Text = "label5"
         '
         'listViewOptions
         '
         Me.listViewOptions.LargeImageList = Me.imageListOptions
         Me.listViewOptions.Location = New System.Drawing.Point(393, 54)
         Me.listViewOptions.Name = "listViewOptions"
         Me.listViewOptions.Size = New System.Drawing.Size(80, 389)
         Me.listViewOptions.TabIndex = 21
         Me.listViewOptions.UseCompatibleStateImageBehavior = False
         '
         'imageListOptions
         '
         Me.imageListOptions.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
         Me.imageListOptions.ImageSize = New System.Drawing.Size(32, 32)
         Me.imageListOptions.TransparentColor = System.Drawing.Color.Transparent
         '
         'label2
         '
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(390, 39)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(77, 13)
         Me.label2.TabIndex = 22
         Me.label2.Text = "AddIn Options:"
         '
         'labelError
         '
         Me.labelError.AutoSize = True
         Me.labelError.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.labelError.ForeColor = System.Drawing.Color.Red
         Me.labelError.Location = New System.Drawing.Point(13, 57)
         Me.labelError.Name = "labelError"
         Me.labelError.Size = New System.Drawing.Size(34, 13)
         Me.labelError.TabIndex = 25
         Me.labelError.Text = "Error"
         Me.labelError.Visible = False
         '
         'comboBoxService
         '
         Me.comboBoxService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.comboBoxService.FormattingEnabled = True
         Me.comboBoxService.Location = New System.Drawing.Point(13, 54)
         Me.comboBoxService.Name = "comboBoxService"
         Me.comboBoxService.Size = New System.Drawing.Size(374, 21)
         Me.comboBoxService.TabIndex = 12
         '
         'MainForm
         '
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(479, 451)
         Me.Controls.Add(Me.labelError)
         Me.Controls.Add(Me.label2)
         Me.Controls.Add(Me.labelIpAddress)
         Me.Controls.Add(Me.labelPort)
         Me.Controls.Add(Me.labelServerIp)
         Me.Controls.Add(Me.labelServerPort)
         Me.Controls.Add(Me.comboBoxService)
         Me.Controls.Add(Me.labelServer)
         Me.Controls.Add(Me.toolStripMain)
         Me.Controls.Add(Me.listViewOptions)
         Me.Controls.Add(Me.tabControl1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.MaximizeBox = False
         Me.Name = "MainForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "LEADTOOLS DICOM Server Manager - VB.Net"
         Me.toolStripClients.ResumeLayout(False)
         Me.toolStripClients.PerformLayout()
         Me.tabControl1.ResumeLayout(False)
         Me.tabPageAeTitles.ResumeLayout(False)
         Me.toolStripContainer1.ContentPanel.ResumeLayout(False)
         Me.toolStripContainer1.TopToolStripPanel.ResumeLayout(False)
         Me.toolStripContainer1.TopToolStripPanel.PerformLayout()
         Me.toolStripContainer1.ResumeLayout(False)
         Me.toolStripContainer1.PerformLayout()
         Me.toolStripAeTitle.ResumeLayout(False)
         Me.toolStripAeTitle.PerformLayout()
         Me.tabPageClients.ResumeLayout(False)
         Me.toolStripContainer2.ContentPanel.ResumeLayout(False)
         Me.toolStripContainer2.TopToolStripPanel.ResumeLayout(False)
         Me.toolStripContainer2.TopToolStripPanel.PerformLayout()
         Me.toolStripContainer2.ResumeLayout(False)
         Me.toolStripContainer2.PerformLayout()
         Me.toolStripMain.ResumeLayout(False)
         Me.toolStripMain.PerformLayout()
         Me.contextMenuStripNotifyIcon.ResumeLayout(False)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

        Private labelServer As System.Windows.Forms.Label
        Private WithEvents tabControl1 As System.Windows.Forms.TabControl
        Private tabPageAeTitles As System.Windows.Forms.TabPage
        Private WithEvents listViewAeTitles As System.Windows.Forms.ListView
        Private columnHeaderAeTitle As System.Windows.Forms.ColumnHeader
        Private columnHeaderHostname As System.Windows.Forms.ColumnHeader
        Private columnHeaderPort As System.Windows.Forms.ColumnHeader
        Private columnHeaderSecurePort As System.Windows.Forms.ColumnHeader
        Private toolStripContainer1 As System.Windows.Forms.ToolStripContainer
        Private toolStripAeTitle As System.Windows.Forms.ToolStrip
        Private WithEvents toolStripButtonAddAeTitle As System.Windows.Forms.ToolStripButton
        Private WithEvents toolStripButtonEditAeTitle As System.Windows.Forms.ToolStripButton
        Private WithEvents toolStripButtonDeleteAeTitle As System.Windows.Forms.ToolStripButton
        Private WithEvents comboBoxService As ComboBoxImage
        Private WithEvents toolStripMain As System.Windows.Forms.ToolStrip
        Private WithEvents toolStripButtonAddServer As System.Windows.Forms.ToolStripButton
        Private WithEvents toolStripButtonEditServer As System.Windows.Forms.ToolStripButton
        Private WithEvents toolStripButtonDeleteServer As System.Windows.Forms.ToolStripButton
        Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Private WithEvents toolStripButtonStart As System.Windows.Forms.ToolStripButton
        Private WithEvents toolStripButtonPause As System.Windows.Forms.ToolStripButton
        Private WithEvents toolStripButtonStop As System.Windows.Forms.ToolStripButton
        Private tabPageClients As System.Windows.Forms.TabPage
        Private WithEvents notifyIcon As System.Windows.Forms.NotifyIcon
        Private contextMenuStripNotifyIcon As System.Windows.Forms.ContextMenuStrip
        Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private toolStripContainer2 As System.Windows.Forms.ToolStripContainer
        Private listViewClients As System.Windows.Forms.ListView
        Private columnIpAddress As System.Windows.Forms.ColumnHeader
        Private columnAeTitle As System.Windows.Forms.ColumnHeader
        Private columnConnectTime As System.Windows.Forms.ColumnHeader
        Private WithEvents toolStripButtonViewAssociation As System.Windows.Forms.ToolStripButton
        Private WithEvents toolStripButtonDisconnectClient As System.Windows.Forms.ToolStripButton
        Private labelServerIp As System.Windows.Forms.Label
        Private labelServerPort As System.Windows.Forms.Label
        Private labelIpAddress As System.Windows.Forms.Label
        Private labelPort As System.Windows.Forms.Label
        Private columnLastAction As System.Windows.Forms.ColumnHeader
        Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
        Private WithEvents toolStripButtonStartAll As System.Windows.Forms.ToolStripButton
        Private WithEvents toolStripButtonStopAll As System.Windows.Forms.ToolStripButton
        Private toolStripClients As ToolStrip
        Private WithEvents listViewOptions As ListView
        Private label2 As Label
        Private imageListOptions As ImageList
        Private labelError As Label
        Private WithEvents toolStripButtonHelp As ToolStripButton
        Private toolStripSeparator3 As ToolStripSeparator
        Private WithEvents toolStripButtonEventLog As ToolStripButton
        Private toolStripSeparator4 As ToolStripSeparator
        Friend WithEvents toolTip As System.Windows.Forms.ToolTip
    End Class
End Namespace