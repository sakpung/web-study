Imports Microsoft.VisualBasic
Imports System
Imports Dicom.UI
Namespace DicomDemo
   Public Partial Class MainForm
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
         Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
         Me.searchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
         Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
         Me.clearLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
         Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
         Me.saveAsDicomFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
         Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
         Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
         Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
         Me.showHelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
         Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
         Me._menuStrip = New System.Windows.Forms.MenuStrip
         Me.dICOMSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
         Me.mPPSTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
         Me.serversToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
         Me.mWLScpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
         Me.toolStripComboBoxMWLScp = New System.Windows.Forms.ToolStripComboBox
         Me.mPPSScpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
         Me.toolStripComboBoxMPPSScp = New System.Windows.Forms.ToolStripComboBox
         Me.storeScpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
         Me.toolStripComboBoxStoreScp = New System.Windows.Forms.ToolStripComboBox
         Me._contextMenuStripLog = New System.Windows.Forms.ContextMenuStrip(Me.components)
         Me._ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
         Me.openFileDialog = New System.Windows.Forms.OpenFileDialog
         Me.statusStrip1 = New System.Windows.Forms.StatusStrip
         Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
         Me.toolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
         Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
         Me.toolStripStatusLabelMWL = New System.Windows.Forms.ToolStripStatusLabel
         Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
         Me.toolStripStatusLabelMPPS = New System.Windows.Forms.ToolStripStatusLabel
         Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
         Me.toolStripStatusLabelStore = New System.Windows.Forms.ToolStripStatusLabel
         Me._splitContainer3 = New System.Windows.Forms.SplitContainer
         Me.groupBox2 = New System.Windows.Forms.GroupBox
         Me._listViewWorkItems = New DicomDemo.MyListView
         Me._columnAccessionNum = New System.Windows.Forms.ColumnHeader
         Me._columnHeaderPatientId = New System.Windows.Forms.ColumnHeader
         Me._columnHeaderPatientName = New System.Windows.Forms.ColumnHeader
         Me._columnHeaderBirthdate = New System.Windows.Forms.ColumnHeader
         Me._columnHeaderGender = New System.Windows.Forms.ColumnHeader
         Me._columnHeaderScheduledStartDate = New System.Windows.Forms.ColumnHeader
         Me.columnHeaderModality = New System.Windows.Forms.ColumnHeader
         Me.columnHeaderScheduledStationAe = New System.Windows.Forms.ColumnHeader
         Me.columnHeaderDescription = New System.Windows.Forms.ColumnHeader
         Me._label2 = New System.Windows.Forms.Label
         Me.panel1 = New System.Windows.Forms.Panel
         Me.buttonCreateMPPS = New Dicom.UI.SplitButton
         Me.contextMenuStripMPPS = New System.Windows.Forms.ContextMenuStrip(Me.components)
         Me.panel3 = New System.Windows.Forms.Panel
         Me.groupBox3 = New System.Windows.Forms.GroupBox
         Me._propertyGrid = New System.Windows.Forms.PropertyGrid
         Me.panel4 = New System.Windows.Forms.Panel
         Me.buttonCancel = New System.Windows.Forms.Button
         Me.buttonSearch = New Dicom.UI.SplitButton
         Me.contextMenuStripMWL = New System.Windows.Forms.ContextMenuStrip(Me.components)
         Me.splitContainer1 = New System.Windows.Forms.SplitContainer
         Me.splitContainer2 = New System.Windows.Forms.SplitContainer
         Me.groupBox1 = New System.Windows.Forms.GroupBox
         Me.listViewInProgress = New System.Windows.Forms.ListView
         Me.columnHeaderAccessionNumber = New System.Windows.Forms.ColumnHeader
         Me.columnHeaderPatientId = New System.Windows.Forms.ColumnHeader
         Me.columnHeaderPPSModality = New System.Windows.Forms.ColumnHeader
         Me.columnHeaderPPSStartDate = New System.Windows.Forms.ColumnHeader
         Me.columnHeaderPPSStartTime = New System.Windows.Forms.ColumnHeader
         Me.columnHeaderPPSId = New System.Windows.Forms.ColumnHeader
         Me.columnHeaderPerformedStationAeTile = New System.Windows.Forms.ColumnHeader
         Me.columnHeaderPerformedStationName = New System.Windows.Forms.ColumnHeader
         Me.label1 = New System.Windows.Forms.Label
         Me.panel2 = New System.Windows.Forms.Panel
         Me.buttonCompleteMPPS = New System.Windows.Forms.Button
         Me.buttonCancelMPPS = New System.Windows.Forms.Button
         Me.buttonAddImage = New Dicom.UI.SplitButton
         Me.contextMenuStripStore = New System.Windows.Forms.ContextMenuStrip(Me.components)
         Me.buttonSetMPPS = New System.Windows.Forms.Button
         Me._richTextBoxLog = New System.Windows.Forms.RichTextBox
         Me._label5 = New System.Windows.Forms.Label
         Me._splitContainer1 = New System.Windows.Forms.SplitContainer
         Me._menuStrip.SuspendLayout()
         Me._contextMenuStripLog.SuspendLayout()
         Me.statusStrip1.SuspendLayout()
         Me._splitContainer3.Panel1.SuspendLayout()
         Me._splitContainer3.Panel2.SuspendLayout()
         Me._splitContainer3.SuspendLayout()
         Me.groupBox2.SuspendLayout()
         Me.panel1.SuspendLayout()
         Me.panel3.SuspendLayout()
         Me.groupBox3.SuspendLayout()
         Me.panel4.SuspendLayout()
         Me.splitContainer1.Panel1.SuspendLayout()
         Me.splitContainer1.Panel2.SuspendLayout()
         Me.splitContainer1.SuspendLayout()
         Me.splitContainer2.Panel1.SuspendLayout()
         Me.splitContainer2.SuspendLayout()
         Me.groupBox1.SuspendLayout()
         Me.panel2.SuspendLayout()
         Me._splitContainer1.Panel2.SuspendLayout()
         Me._splitContainer1.SuspendLayout()
         Me.SuspendLayout()
         '
         'fileToolStripMenuItem
         '
         Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.searchToolStripMenuItem, Me.toolStripSeparator1, Me.clearLogToolStripMenuItem, Me.toolStripSeparator3, Me.saveAsDicomFileToolStripMenuItem, Me.toolStripSeparator2, Me.exitToolStripMenuItem})
         Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
         Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
         Me.fileToolStripMenuItem.Text = "&File"
         '
         'searchToolStripMenuItem
         '
         Me.searchToolStripMenuItem.Name = "searchToolStripMenuItem"
         Me.searchToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
         Me.searchToolStripMenuItem.Text = "&Search"
         '
         'toolStripSeparator1
         '
         Me.toolStripSeparator1.Name = "toolStripSeparator1"
         Me.toolStripSeparator1.Size = New System.Drawing.Size(167, 6)
         '
         'clearLogToolStripMenuItem
         '
         Me.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem"
         Me.clearLogToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
         Me.clearLogToolStripMenuItem.Text = "&Clear Log"
         '
         'toolStripSeparator3
         '
         Me.toolStripSeparator3.Name = "toolStripSeparator3"
         Me.toolStripSeparator3.Size = New System.Drawing.Size(167, 6)
         '
         'saveAsDicomFileToolStripMenuItem
         '
         Me.saveAsDicomFileToolStripMenuItem.Name = "saveAsDicomFileToolStripMenuItem"
         Me.saveAsDicomFileToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
         Me.saveAsDicomFileToolStripMenuItem.Text = "&Save DICOM File..."
         '
         'toolStripSeparator2
         '
         Me.toolStripSeparator2.Name = "toolStripSeparator2"
         Me.toolStripSeparator2.Size = New System.Drawing.Size(167, 6)
         '
         'exitToolStripMenuItem
         '
         Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
         Me.exitToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
         Me.exitToolStripMenuItem.Text = "&Exit"
         '
         'helpToolStripMenuItem
         '
         Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.showHelpToolStripMenuItem, Me.aboutToolStripMenuItem})
         Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
         Me.helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
         Me.helpToolStripMenuItem.Text = "&Help"
         '
         'showHelpToolStripMenuItem
         '
         Me.showHelpToolStripMenuItem.Name = "showHelpToolStripMenuItem"
         Me.showHelpToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
         Me.showHelpToolStripMenuItem.Text = "Show &Help..."
         '
         'aboutToolStripMenuItem
         '
         Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
         Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
         Me.aboutToolStripMenuItem.Text = "&About..."
         '
         '_menuStrip
         '
         Me._menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.dICOMSettingsToolStripMenuItem, Me.mPPSTemplateToolStripMenuItem, Me.serversToolStripMenuItem, Me.helpToolStripMenuItem})
         Me._menuStrip.Location = New System.Drawing.Point(0, 0)
         Me._menuStrip.Name = "_menuStrip"
         Me._menuStrip.Size = New System.Drawing.Size(1276, 24)
         Me._menuStrip.TabIndex = 0
         Me._menuStrip.Text = "menuStrip1"
         '
         'dICOMSettingsToolStripMenuItem
         '
         Me.dICOMSettingsToolStripMenuItem.Name = "dICOMSettingsToolStripMenuItem"
         Me.dICOMSettingsToolStripMenuItem.Size = New System.Drawing.Size(112, 20)
         Me.dICOMSettingsToolStripMenuItem.Text = "&DICOM Settings..."
         '
         'mPPSTemplateToolStripMenuItem
         '
         Me.mPPSTemplateToolStripMenuItem.Name = "mPPSTemplateToolStripMenuItem"
         Me.mPPSTemplateToolStripMenuItem.Size = New System.Drawing.Size(135, 20)
         Me.mPPSTemplateToolStripMenuItem.Text = "&Edit MPPS Template..."
         '
         'serversToolStripMenuItem
         '
         Me.serversToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mWLScpToolStripMenuItem, Me.mPPSScpToolStripMenuItem, Me.storeScpToolStripMenuItem})
         Me.serversToolStripMenuItem.Name = "serversToolStripMenuItem"
         Me.serversToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
         Me.serversToolStripMenuItem.Text = "&Servers"
         '
         'mWLScpToolStripMenuItem
         '
         Me.mWLScpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripComboBoxMWLScp})
         Me.mWLScpToolStripMenuItem.Name = "mWLScpToolStripMenuItem"
         Me.mWLScpToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
         Me.mWLScpToolStripMenuItem.Text = "&MWL Scp"
         '
         'toolStripComboBoxMWLScp
         '
         Me.toolStripComboBoxMWLScp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.toolStripComboBoxMWLScp.Name = "toolStripComboBoxMWLScp"
         Me.toolStripComboBoxMWLScp.Size = New System.Drawing.Size(121, 23)
         '
         'mPPSScpToolStripMenuItem
         '
         Me.mPPSScpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripComboBoxMPPSScp})
         Me.mPPSScpToolStripMenuItem.Name = "mPPSScpToolStripMenuItem"
         Me.mPPSScpToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
         Me.mPPSScpToolStripMenuItem.Text = "M&PPS Scp"
         '
         'toolStripComboBoxMPPSScp
         '
         Me.toolStripComboBoxMPPSScp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.toolStripComboBoxMPPSScp.Name = "toolStripComboBoxMPPSScp"
         Me.toolStripComboBoxMPPSScp.Size = New System.Drawing.Size(121, 23)
         '
         'storeScpToolStripMenuItem
         '
         Me.storeScpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripComboBoxStoreScp})
         Me.storeScpToolStripMenuItem.Name = "storeScpToolStripMenuItem"
         Me.storeScpToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
         Me.storeScpToolStripMenuItem.Text = "&Store Scp"
         '
         'toolStripComboBoxStoreScp
         '
         Me.toolStripComboBoxStoreScp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.toolStripComboBoxStoreScp.Name = "toolStripComboBoxStoreScp"
         Me.toolStripComboBoxStoreScp.Size = New System.Drawing.Size(121, 23)
         '
         '_contextMenuStripLog
         '
         Me._contextMenuStripLog.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._ToolStripMenuItem1})
         Me._contextMenuStripLog.Name = "_contextMenuStripLog"
         Me._contextMenuStripLog.Size = New System.Drawing.Size(125, 26)
         '
         '_ToolStripMenuItem1
         '
         Me._ToolStripMenuItem1.Name = "_ToolStripMenuItem1"
         Me._ToolStripMenuItem1.Size = New System.Drawing.Size(124, 22)
         Me._ToolStripMenuItem1.Text = "&Clear Log"
         '
         'openFileDialog
         '
         Me.openFileDialog.Filter = "DICOM|*.dcm;*.dic|All Files|*.*"
         Me.openFileDialog.Multiselect = True
         Me.openFileDialog.Title = "Select Files To Add To MPPS"
         '
         'statusStrip1
         '
         Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel1, Me.toolStripProgressBar, Me.ToolStripStatusLabel2, Me.toolStripStatusLabelMWL, Me.ToolStripStatusLabel3, Me.toolStripStatusLabelMPPS, Me.ToolStripStatusLabel4, Me.toolStripStatusLabelStore})
         Me.statusStrip1.Location = New System.Drawing.Point(0, 710)
         Me.statusStrip1.Name = "statusStrip1"
         Me.statusStrip1.Size = New System.Drawing.Size(1276, 24)
         Me.statusStrip1.TabIndex = 2
         Me.statusStrip1.Text = "statusStrip1"
         '
         'toolStripStatusLabel1
         '
         Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
         Me.toolStripStatusLabel1.Size = New System.Drawing.Size(604, 19)
         Me.toolStripStatusLabel1.Spring = True
         '
         'toolStripProgressBar
         '
         Me.toolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
         Me.toolStripProgressBar.Name = "toolStripProgressBar"
         Me.toolStripProgressBar.Size = New System.Drawing.Size(250, 18)
         Me.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
         Me.toolStripProgressBar.Visible = False
         '
         'ToolStripStatusLabel2
         '
         Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
         Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(73, 19)
         Me.ToolStripStatusLabel2.Text = "MWL Server:"
         '
         'toolStripStatusLabelMWL
         '
         Me.toolStripStatusLabelMWL.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
         Me.toolStripStatusLabelMWL.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
         Me.toolStripStatusLabelMWL.Name = "toolStripStatusLabelMWL"
         Me.toolStripStatusLabelMWL.Size = New System.Drawing.Size(149, 19)
         Me.toolStripStatusLabelMWL.Text = "toolStripStatusLabelMWL"
         '
         'ToolStripStatusLabel3
         '
         Me.ToolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
         Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
         Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(80, 19)
         Me.ToolStripStatusLabel3.Text = "MPPS Server:"
         '
         'toolStripStatusLabelMPPS
         '
         Me.toolStripStatusLabelMPPS.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
         Me.toolStripStatusLabelMPPS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
         Me.toolStripStatusLabelMPPS.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
         Me.toolStripStatusLabelMPPS.Name = "toolStripStatusLabelMPPS"
         Me.toolStripStatusLabelMPPS.Size = New System.Drawing.Size(156, 19)
         Me.toolStripStatusLabelMPPS.Text = "toolStripStatusLabelMPPS"
         '
         'ToolStripStatusLabel4
         '
         Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
         Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(72, 19)
         Me.ToolStripStatusLabel4.Text = "Store Server:"
         '
         'toolStripStatusLabelStore
         '
         Me.toolStripStatusLabelStore.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
         Me.toolStripStatusLabelStore.Name = "toolStripStatusLabelStore"
         Me.toolStripStatusLabelStore.Size = New System.Drawing.Size(127, 19)
         Me.toolStripStatusLabelStore.Text = "toolStripStatusLabel4"
         '
         '_splitContainer3
         '
         Me._splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
         Me._splitContainer3.Location = New System.Drawing.Point(0, 0)
         Me._splitContainer3.Name = "_splitContainer3"
         Me._splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
         '
         '_splitContainer3.Panel1
         '
         Me._splitContainer3.Panel1.Controls.Add(Me.groupBox2)
         Me._splitContainer3.Panel1.Controls.Add(Me.panel3)
         '
         '_splitContainer3.Panel2
         '
         Me._splitContainer3.Panel2.Controls.Add(Me.splitContainer1)
         Me._splitContainer3.Size = New System.Drawing.Size(1276, 686)
         Me._splitContainer3.SplitterDistance = 231
         Me._splitContainer3.TabIndex = 0
         '
         'groupBox2
         '
         Me.groupBox2.Controls.Add(Me._listViewWorkItems)
         Me.groupBox2.Controls.Add(Me._label2)
         Me.groupBox2.Controls.Add(Me.panel1)
         Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill
         Me.groupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.groupBox2.Location = New System.Drawing.Point(274, 0)
         Me.groupBox2.Name = "groupBox2"
         Me.groupBox2.Size = New System.Drawing.Size(1002, 231)
         Me.groupBox2.TabIndex = 7
         Me.groupBox2.TabStop = False
         Me.groupBox2.Text = "2.  Create MPPS from worklist item"
         '
         '_listViewWorkItems
         '
         Me._listViewWorkItems.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._columnAccessionNum, Me._columnHeaderPatientId, Me._columnHeaderPatientName, Me._columnHeaderBirthdate, Me._columnHeaderGender, Me._columnHeaderScheduledStartDate, Me.columnHeaderModality, Me.columnHeaderScheduledStationAe, Me.columnHeaderDescription})
         Me._listViewWorkItems.Dock = System.Windows.Forms.DockStyle.Fill
         Me._listViewWorkItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._listViewWorkItems.FullRowSelect = True
         Me._listViewWorkItems.GridLines = True
         Me._listViewWorkItems.HideSelection = False
         Me._listViewWorkItems.Location = New System.Drawing.Point(3, 86)
         Me._listViewWorkItems.MultiSelect = False
         Me._listViewWorkItems.Name = "_listViewWorkItems"
         Me._listViewWorkItems.Size = New System.Drawing.Size(996, 142)
         Me._listViewWorkItems.StartedMPPS = CType(resources.GetObject("_listViewWorkItems.StartedMPPS"), System.Collections.Generic.List(Of System.Windows.Forms.ListViewItem))
         Me._listViewWorkItems.TabIndex = 1
         Me._listViewWorkItems.UseCompatibleStateImageBehavior = False
         Me._listViewWorkItems.View = System.Windows.Forms.View.Details
         '
         '_columnAccessionNum
         '
         Me._columnAccessionNum.Text = "Accession Number"
         Me._columnAccessionNum.Width = 125
         '
         '_columnHeaderPatientId
         '
         Me._columnHeaderPatientId.Text = "Patient ID"
         '
         '_columnHeaderPatientName
         '
         Me._columnHeaderPatientName.Text = "Patient Name"
         Me._columnHeaderPatientName.Width = 125
         '
         '_columnHeaderBirthdate
         '
         Me._columnHeaderBirthdate.Text = "Birthdate"
         Me._columnHeaderBirthdate.Width = 84
         '
         '_columnHeaderGender
         '
         Me._columnHeaderGender.Text = "Gender"
         '
         '_columnHeaderScheduledStartDate
         '
         Me._columnHeaderScheduledStartDate.Text = "Scheduled Start Date"
         Me._columnHeaderScheduledStartDate.Width = 75
         '
         'columnHeaderModality
         '
         Me.columnHeaderModality.Text = "Modality"
         '
         'columnHeaderScheduledStationAe
         '
         Me.columnHeaderScheduledStationAe.Text = "Scheduled Station AE"
         Me.columnHeaderScheduledStationAe.Width = 120
         '
         'columnHeaderDescription
         '
         Me.columnHeaderDescription.Text = "Scheduled Procedure Step Description"
         Me.columnHeaderDescription.Width = 197
         '
         '_label2
         '
         Me._label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._label2.Dock = System.Windows.Forms.DockStyle.Top
         Me._label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._label2.Location = New System.Drawing.Point(3, 68)
         Me._label2.Name = "_label2"
         Me._label2.Size = New System.Drawing.Size(996, 18)
         Me._label2.TabIndex = 0
         Me._label2.Text = "Worklist Items Found (Double click to see worklist dataset): "
         '
         'panel1
         '
         Me.panel1.Controls.Add(Me.buttonCreateMPPS)
         Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
         Me.panel1.Location = New System.Drawing.Point(3, 16)
         Me.panel1.Name = "panel1"
         Me.panel1.Size = New System.Drawing.Size(996, 52)
         Me.panel1.TabIndex = 5
         '
         'buttonCreateMPPS
         '
         Me.buttonCreateMPPS.AutoSize = True
         Me.buttonCreateMPPS.ContextMenuStrip = Me.contextMenuStripMPPS
         Me.buttonCreateMPPS.Enabled = False
         Me.buttonCreateMPPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.buttonCreateMPPS.ImageAlign = System.Drawing.ContentAlignment.TopCenter
         Me.buttonCreateMPPS.Location = New System.Drawing.Point(0, 0)
         Me.buttonCreateMPPS.Name = "buttonCreateMPPS"
         Me.buttonCreateMPPS.Size = New System.Drawing.Size(131, 51)
         Me.buttonCreateMPPS.TabIndex = 0
         Me.buttonCreateMPPS.Text = "Create MPPS..."
         Me.buttonCreateMPPS.UseVisualStyleBackColor = True
         '
         'contextMenuStripMPPS
         '
         Me.contextMenuStripMPPS.Name = "contextMenuStripMPPS"
         Me.contextMenuStripMPPS.Size = New System.Drawing.Size(61, 4)
         '
         'panel3
         '
         Me.panel3.Controls.Add(Me.groupBox3)
         Me.panel3.Dock = System.Windows.Forms.DockStyle.Left
         Me.panel3.Location = New System.Drawing.Point(0, 0)
         Me.panel3.Name = "panel3"
         Me.panel3.Size = New System.Drawing.Size(274, 231)
         Me.panel3.TabIndex = 6
         '
         'groupBox3
         '
         Me.groupBox3.Controls.Add(Me._propertyGrid)
         Me.groupBox3.Controls.Add(Me.panel4)
         Me.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill
         Me.groupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.groupBox3.Location = New System.Drawing.Point(0, 0)
         Me.groupBox3.Name = "groupBox3"
         Me.groupBox3.Size = New System.Drawing.Size(274, 231)
         Me.groupBox3.TabIndex = 3
         Me.groupBox3.TabStop = False
         Me.groupBox3.Text = "1.  Search for a work list item"
         '
         '_propertyGrid
         '
         Me._propertyGrid.Cursor = System.Windows.Forms.Cursors.HSplit
         Me._propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill
         Me._propertyGrid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._propertyGrid.HelpVisible = False
         Me._propertyGrid.Location = New System.Drawing.Point(3, 68)
         Me._propertyGrid.Name = "_propertyGrid"
         Me._propertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized
         Me._propertyGrid.Size = New System.Drawing.Size(268, 160)
         Me._propertyGrid.TabIndex = 2
         '
         'panel4
         '
         Me.panel4.Controls.Add(Me.buttonCancel)
         Me.panel4.Controls.Add(Me.buttonSearch)
         Me.panel4.Dock = System.Windows.Forms.DockStyle.Top
         Me.panel4.Location = New System.Drawing.Point(3, 16)
         Me.panel4.Name = "panel4"
         Me.panel4.Size = New System.Drawing.Size(268, 52)
         Me.panel4.TabIndex = 6
         '
         'buttonCancel
         '
         Me.buttonCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
         Me.buttonCancel.Location = New System.Drawing.Point(137, 0)
         Me.buttonCancel.Name = "buttonCancel"
         Me.buttonCancel.Size = New System.Drawing.Size(131, 51)
         Me.buttonCancel.TabIndex = 1
         Me.buttonCancel.Text = "Cancel"
         Me.buttonCancel.UseVisualStyleBackColor = True
         '
         'buttonSearch
         '
         Me.buttonSearch.AutoSize = True
         Me.buttonSearch.ContextMenuStrip = Me.contextMenuStripMWL
         Me.buttonSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.buttonSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter
         Me.buttonSearch.Location = New System.Drawing.Point(0, 0)
         Me.buttonSearch.Name = "buttonSearch"
         Me.buttonSearch.Size = New System.Drawing.Size(131, 51)
         Me.buttonSearch.TabIndex = 0
         Me.buttonSearch.Text = "Search"
         Me.buttonSearch.UseVisualStyleBackColor = True
         '
         'contextMenuStripMWL
         '
         Me.contextMenuStripMWL.Name = "contextMenuStripMPPS"
         Me.contextMenuStripMWL.Size = New System.Drawing.Size(61, 4)
         '
         'splitContainer1
         '
         Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
         Me.splitContainer1.Location = New System.Drawing.Point(0, 0)
         Me.splitContainer1.Name = "splitContainer1"
         Me.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
         '
         'splitContainer1.Panel1
         '
         Me.splitContainer1.Panel1.Controls.Add(Me.splitContainer2)
         '
         'splitContainer1.Panel2
         '
         Me.splitContainer1.Panel2.Controls.Add(Me._richTextBoxLog)
         Me.splitContainer1.Panel2.Controls.Add(Me._label5)
         Me.splitContainer1.Size = New System.Drawing.Size(1276, 451)
         Me.splitContainer1.SplitterDistance = 204
         Me.splitContainer1.TabIndex = 0
         '
         'splitContainer2
         '
         Me.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
         Me.splitContainer2.Location = New System.Drawing.Point(0, 0)
         Me.splitContainer2.Name = "splitContainer2"
         '
         'splitContainer2.Panel1
         '
         Me.splitContainer2.Panel1.Controls.Add(Me.groupBox1)
         Me.splitContainer2.Panel2Collapsed = True
         Me.splitContainer2.Size = New System.Drawing.Size(1276, 204)
         Me.splitContainer2.SplitterDistance = 422
         Me.splitContainer2.TabIndex = 0
         '
         'groupBox1
         '
         Me.groupBox1.Controls.Add(Me.listViewInProgress)
         Me.groupBox1.Controls.Add(Me.label1)
         Me.groupBox1.Controls.Add(Me.panel2)
         Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill
         Me.groupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.groupBox1.Location = New System.Drawing.Point(0, 0)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(1276, 204)
         Me.groupBox1.TabIndex = 9
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "3.  Work with in progress MPPS"
         '
         'listViewInProgress
         '
         Me.listViewInProgress.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeaderAccessionNumber, Me.columnHeaderPatientId, Me.columnHeaderPPSModality, Me.columnHeaderPPSStartDate, Me.columnHeaderPPSStartTime, Me.columnHeaderPPSId, Me.columnHeaderPerformedStationAeTile, Me.columnHeaderPerformedStationName})
         Me.listViewInProgress.Dock = System.Windows.Forms.DockStyle.Fill
         Me.listViewInProgress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.listViewInProgress.FullRowSelect = True
         Me.listViewInProgress.GridLines = True
         Me.listViewInProgress.HideSelection = False
         Me.listViewInProgress.Location = New System.Drawing.Point(3, 86)
         Me.listViewInProgress.MultiSelect = False
         Me.listViewInProgress.Name = "listViewInProgress"
         Me.listViewInProgress.Size = New System.Drawing.Size(1270, 115)
         Me.listViewInProgress.TabIndex = 6
         Me.listViewInProgress.UseCompatibleStateImageBehavior = False
         Me.listViewInProgress.View = System.Windows.Forms.View.Details
         '
         'columnHeaderAccessionNumber
         '
         Me.columnHeaderAccessionNumber.Text = "Accession Number"
         Me.columnHeaderAccessionNumber.Width = 125
         '
         'columnHeaderPatientId
         '
         Me.columnHeaderPatientId.Text = "Patient ID"
         '
         'columnHeaderPPSModality
         '
         Me.columnHeaderPPSModality.Text = "Modality"
         Me.columnHeaderPPSModality.Width = 84
         '
         'columnHeaderPPSStartDate
         '
         Me.columnHeaderPPSStartDate.Text = "PPS Start Date"
         '
         'columnHeaderPPSStartTime
         '
         Me.columnHeaderPPSStartTime.Text = "PPS Start Time"
         Me.columnHeaderPPSStartTime.Width = 75
         '
         'columnHeaderPPSId
         '
         Me.columnHeaderPPSId.Text = "PPS Id"
         '
         'columnHeaderPerformedStationAeTile
         '
         Me.columnHeaderPerformedStationAeTile.Text = "Performed Station AE"
         Me.columnHeaderPerformedStationAeTile.Width = 120
         '
         'columnHeaderPerformedStationName
         '
         Me.columnHeaderPerformedStationName.Text = "Performed Station Name"
         Me.columnHeaderPerformedStationName.Width = 197
         '
         'label1
         '
         Me.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me.label1.ContextMenuStrip = Me._contextMenuStripLog
         Me.label1.Dock = System.Windows.Forms.DockStyle.Top
         Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.label1.Location = New System.Drawing.Point(3, 68)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(1270, 18)
         Me.label1.TabIndex = 5
         Me.label1.Text = "In Progress MPPS:"
         '
         'panel2
         '
         Me.panel2.Controls.Add(Me.buttonCompleteMPPS)
         Me.panel2.Controls.Add(Me.buttonCancelMPPS)
         Me.panel2.Controls.Add(Me.buttonAddImage)
         Me.panel2.Controls.Add(Me.buttonSetMPPS)
         Me.panel2.Dock = System.Windows.Forms.DockStyle.Top
         Me.panel2.Location = New System.Drawing.Point(3, 16)
         Me.panel2.Name = "panel2"
         Me.panel2.Size = New System.Drawing.Size(1270, 52)
         Me.panel2.TabIndex = 8
         '
         'buttonCompleteMPPS
         '
         Me.buttonCompleteMPPS.Enabled = False
         Me.buttonCompleteMPPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.buttonCompleteMPPS.ImageAlign = System.Drawing.ContentAlignment.TopCenter
         Me.buttonCompleteMPPS.Location = New System.Drawing.Point(277, 1)
         Me.buttonCompleteMPPS.Name = "buttonCompleteMPPS"
         Me.buttonCompleteMPPS.Size = New System.Drawing.Size(131, 51)
         Me.buttonCompleteMPPS.TabIndex = 3
         Me.buttonCompleteMPPS.Text = "Complete MPPS ..."
         Me.buttonCompleteMPPS.UseVisualStyleBackColor = True
         '
         'buttonCancelMPPS
         '
         Me.buttonCancelMPPS.Enabled = False
         Me.buttonCancelMPPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.buttonCancelMPPS.ImageAlign = System.Drawing.ContentAlignment.TopCenter
         Me.buttonCancelMPPS.Location = New System.Drawing.Point(140, 0)
         Me.buttonCancelMPPS.Name = "buttonCancelMPPS"
         Me.buttonCancelMPPS.Size = New System.Drawing.Size(131, 51)
         Me.buttonCancelMPPS.TabIndex = 2
         Me.buttonCancelMPPS.Text = "Discontinue MPPS ..."
         Me.buttonCancelMPPS.UseVisualStyleBackColor = True
         '
         'buttonAddImage
         '
         Me.buttonAddImage.AutoSize = True
         Me.buttonAddImage.ContextMenuStrip = Me.contextMenuStripStore
         Me.buttonAddImage.Enabled = False
         Me.buttonAddImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.buttonAddImage.ImageAlign = System.Drawing.ContentAlignment.TopCenter
         Me.buttonAddImage.Location = New System.Drawing.Point(414, 1)
         Me.buttonAddImage.Name = "buttonAddImage"
         Me.buttonAddImage.Size = New System.Drawing.Size(131, 51)
         Me.buttonAddImage.TabIndex = 1
         Me.buttonAddImage.Text = "Add DICOM..."
         Me.buttonAddImage.UseVisualStyleBackColor = True
         '
         'contextMenuStripStore
         '
         Me.contextMenuStripStore.Name = "contextMenuStripMPPS"
         Me.contextMenuStripStore.Size = New System.Drawing.Size(61, 4)
         '
         'buttonSetMPPS
         '
         Me.buttonSetMPPS.Enabled = False
         Me.buttonSetMPPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.buttonSetMPPS.ImageAlign = System.Drawing.ContentAlignment.TopCenter
         Me.buttonSetMPPS.Location = New System.Drawing.Point(3, 0)
         Me.buttonSetMPPS.Name = "buttonSetMPPS"
         Me.buttonSetMPPS.Size = New System.Drawing.Size(131, 51)
         Me.buttonSetMPPS.TabIndex = 0
         Me.buttonSetMPPS.Text = "Update MPPS..."
         Me.buttonSetMPPS.UseVisualStyleBackColor = True
         '
         '_richTextBoxLog
         '
         Me._richTextBoxLog.ContextMenuStrip = Me._contextMenuStripLog
         Me._richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill
         Me._richTextBoxLog.Location = New System.Drawing.Point(0, 23)
         Me._richTextBoxLog.Name = "_richTextBoxLog"
         Me._richTextBoxLog.ReadOnly = True
         Me._richTextBoxLog.Size = New System.Drawing.Size(1276, 220)
         Me._richTextBoxLog.TabIndex = 3
         Me._richTextBoxLog.Text = ""
         Me._richTextBoxLog.WordWrap = False
         '
         '_label5
         '
         Me._label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._label5.ContextMenuStrip = Me._contextMenuStripLog
         Me._label5.Dock = System.Windows.Forms.DockStyle.Top
         Me._label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me._label5.Location = New System.Drawing.Point(0, 0)
         Me._label5.Name = "_label5"
         Me._label5.Size = New System.Drawing.Size(1276, 23)
         Me._label5.TabIndex = 4
         Me._label5.Text = "Log: (Right-click to clear)"
         '
         '_splitContainer1
         '
         Me._splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
         Me._splitContainer1.Location = New System.Drawing.Point(0, 24)
         Me._splitContainer1.Name = "_splitContainer1"
         Me._splitContainer1.Panel1Collapsed = True
         '
         '_splitContainer1.Panel2
         '
         Me._splitContainer1.Panel2.Controls.Add(Me._splitContainer3)
         Me._splitContainer1.Size = New System.Drawing.Size(1276, 686)
         Me._splitContainer1.SplitterDistance = 417
         Me._splitContainer1.TabIndex = 1
         '
         'MainForm
         '
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
         Me.ClientSize = New System.Drawing.Size(1276, 734)
         Me.Controls.Add(Me._splitContainer1)
         Me.Controls.Add(Me._menuStrip)
         Me.Controls.Add(Me.statusStrip1)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.MainMenuStrip = Me._menuStrip
         Me.MinimumSize = New System.Drawing.Size(640, 480)
         Me.Name = "MainForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "LEADTOOLS High Level DICOM MWL & MPPS SCU Demo - VB"
         Me._menuStrip.ResumeLayout(False)
         Me._menuStrip.PerformLayout()
         Me._contextMenuStripLog.ResumeLayout(False)
         Me.statusStrip1.ResumeLayout(False)
         Me.statusStrip1.PerformLayout()
         Me._splitContainer3.Panel1.ResumeLayout(False)
         Me._splitContainer3.Panel2.ResumeLayout(False)
         Me._splitContainer3.ResumeLayout(False)
         Me.groupBox2.ResumeLayout(False)
         Me.panel1.ResumeLayout(False)
         Me.panel1.PerformLayout()
         Me.panel3.ResumeLayout(False)
         Me.groupBox3.ResumeLayout(False)
         Me.panel4.ResumeLayout(False)
         Me.panel4.PerformLayout()
         Me.splitContainer1.Panel1.ResumeLayout(False)
         Me.splitContainer1.Panel2.ResumeLayout(False)
         Me.splitContainer1.ResumeLayout(False)
         Me.splitContainer2.Panel1.ResumeLayout(False)
         Me.splitContainer2.ResumeLayout(False)
         Me.groupBox1.ResumeLayout(False)
         Me.panel2.ResumeLayout(False)
         Me.panel2.PerformLayout()
         Me._splitContainer1.Panel2.ResumeLayout(False)
         Me._splitContainer1.ResumeLayout(False)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents clearLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _menuStrip As System.Windows.Forms.MenuStrip
      Private _contextMenuStripLog As System.Windows.Forms.ContextMenuStrip
      Private WithEvents searchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents showHelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private openFileDialog As System.Windows.Forms.OpenFileDialog
      Private statusStrip1 As System.Windows.Forms.StatusStrip
      Private toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
      Private toolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
      Private serversToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private mWLScpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents toolStripComboBoxMWLScp As System.Windows.Forms.ToolStripComboBox
      Private mPPSScpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents toolStripComboBoxMPPSScp As System.Windows.Forms.ToolStripComboBox
      Private storeScpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents toolStripComboBoxStoreScp As System.Windows.Forms.ToolStripComboBox
      Private _splitContainer3 As System.Windows.Forms.SplitContainer
      Private WithEvents _listViewWorkItems As MyListView
      Private _columnAccessionNum As System.Windows.Forms.ColumnHeader
      Private _columnHeaderPatientId As System.Windows.Forms.ColumnHeader
      Private _columnHeaderPatientName As System.Windows.Forms.ColumnHeader
      Private _columnHeaderBirthdate As System.Windows.Forms.ColumnHeader
      Private _columnHeaderGender As System.Windows.Forms.ColumnHeader
      Private _columnHeaderScheduledStartDate As System.Windows.Forms.ColumnHeader
      Private columnHeaderModality As System.Windows.Forms.ColumnHeader
      Private columnHeaderScheduledStationAe As System.Windows.Forms.ColumnHeader
      Private columnHeaderDescription As System.Windows.Forms.ColumnHeader
      Private _label2 As System.Windows.Forms.Label
      Private panel1 As System.Windows.Forms.Panel
      Private _propertyGrid As System.Windows.Forms.PropertyGrid
      Private WithEvents buttonCreateMPPS As SplitButton
      Private splitContainer1 As System.Windows.Forms.SplitContainer
      Private splitContainer2 As System.Windows.Forms.SplitContainer
      Private WithEvents listViewInProgress As System.Windows.Forms.ListView
      Private columnHeaderAccessionNumber As System.Windows.Forms.ColumnHeader
      Private columnHeaderPatientId As System.Windows.Forms.ColumnHeader
      Private columnHeaderPPSModality As System.Windows.Forms.ColumnHeader
      Private columnHeaderPPSStartDate As System.Windows.Forms.ColumnHeader
      Private columnHeaderPPSStartTime As System.Windows.Forms.ColumnHeader
      Private columnHeaderPPSId As System.Windows.Forms.ColumnHeader
      Private columnHeaderPerformedStationAeTile As System.Windows.Forms.ColumnHeader
      Private columnHeaderPerformedStationName As System.Windows.Forms.ColumnHeader
      Private label1 As System.Windows.Forms.Label
      Private panel2 As System.Windows.Forms.Panel
      Private WithEvents buttonAddImage As SplitButton
      Private WithEvents buttonSetMPPS As System.Windows.Forms.Button
      Private _richTextBoxLog As System.Windows.Forms.RichTextBox
      Private _label5 As System.Windows.Forms.Label
      Private _splitContainer1 As System.Windows.Forms.SplitContainer
      Private panel3 As System.Windows.Forms.Panel
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private groupBox2 As System.Windows.Forms.GroupBox
      Private groupBox3 As System.Windows.Forms.GroupBox
      Private WithEvents buttonCompleteMPPS As System.Windows.Forms.Button
      Private WithEvents buttonCancelMPPS As System.Windows.Forms.Button
      Private panel4 As System.Windows.Forms.Panel
      Private WithEvents buttonCancel As System.Windows.Forms.Button
      Private WithEvents buttonSearch As SplitButton
      Private WithEvents contextMenuStripMPPS As System.Windows.Forms.ContextMenuStrip
      Private WithEvents contextMenuStripMWL As System.Windows.Forms.ContextMenuStrip
      Private WithEvents contextMenuStripStore As System.Windows.Forms.ContextMenuStrip
      Private toolStripStatusLabelMWL As System.Windows.Forms.ToolStripStatusLabel
      Private toolStripStatusLabelMPPS As System.Windows.Forms.ToolStripStatusLabel
      Private toolStripStatusLabelStore As System.Windows.Forms.ToolStripStatusLabel
      Private WithEvents dICOMSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents mPPSTemplateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
      Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
      Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
      Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents saveAsDicomFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem

   End Class
End Namespace

