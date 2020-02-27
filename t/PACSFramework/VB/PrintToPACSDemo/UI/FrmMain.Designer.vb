Imports Microsoft.VisualBasic
Imports System
Namespace PrintToPACSDemo
   Partial Public Class FrmMain
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
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
Me._mmMain = New System.Windows.Forms.MenuStrip
Me._miFile = New System.Windows.Forms.ToolStripMenuItem
Me._miOpen = New System.Windows.Forms.ToolStripMenuItem
Me.toolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator
Me._miSaveAsDICOM = New System.Windows.Forms.ToolStripMenuItem
Me._miStoreToPACS = New System.Windows.Forms.ToolStripMenuItem
Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
Me._miExit = New System.Windows.Forms.ToolStripMenuItem
Me._miEdit = New System.Windows.Forms.ToolStripMenuItem
Me._miPaste = New System.Windows.Forms.ToolStripMenuItem
Me.toolStripSeparator25 = New System.Windows.Forms.ToolStripSeparator
Me._miRotate90 = New System.Windows.Forms.ToolStripMenuItem
Me.toolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator
Me._miDeleteAll = New System.Windows.Forms.ToolStripMenuItem
Me._miDeleteSelected = New System.Windows.Forms.ToolStripMenuItem
Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
Me._miResetInfo = New System.Windows.Forms.ToolStripMenuItem
Me._miView = New System.Windows.Forms.ToolStripMenuItem
Me._miNormal = New System.Windows.Forms.ToolStripMenuItem
Me._miFit = New System.Windows.Forms.ToolStripMenuItem
Me._miZoomIn = New System.Windows.Forms.ToolStripMenuItem
Me._miZoomOut = New System.Windows.Forms.ToolStripMenuItem
Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
Me._miResample = New System.Windows.Forms.ToolStripMenuItem
Me.toolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator
Me._miViewLog = New System.Windows.Forms.ToolStripMenuItem
Me._miCapture = New System.Windows.Forms.ToolStripMenuItem
Me._miCaptureActiveWindow = New System.Windows.Forms.ToolStripMenuItem
Me._miCaptureFullScreen = New System.Windows.Forms.ToolStripMenuItem
Me._miCaptureSelectedObject = New System.Windows.Forms.ToolStripMenuItem
Me._miCaptureSelectedArea = New System.Windows.Forms.ToolStripMenuItem
Me.toolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator
Me._miCaptureStopCapture = New System.Windows.Forms.ToolStripMenuItem
Me.toolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator
Me._miCaptureOptionsMenu = New System.Windows.Forms.ToolStripMenuItem
Me._miCaptureAreaOptions = New System.Windows.Forms.ToolStripMenuItem
Me._miCaptureOptions = New System.Windows.Forms.ToolStripMenuItem
Me._miCaptureObjectOptions = New System.Windows.Forms.ToolStripMenuItem
Me._miAcquire = New System.Windows.Forms.ToolStripMenuItem
Me._miAcquireTwain = New System.Windows.Forms.ToolStripMenuItem
Me._miTwainAcquire = New System.Windows.Forms.ToolStripMenuItem
Me.toolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator
Me._miTemplate = New System.Windows.Forms.ToolStripMenuItem
Me._miTemplateLEAD = New System.Windows.Forms.ToolStripMenuItem
Me._miTemplateShowCaps = New System.Windows.Forms.ToolStripMenuItem
Me.toolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator
Me._miTemplateShowErrors = New System.Windows.Forms.ToolStripMenuItem
Me._miTwainSelectSource = New System.Windows.Forms.ToolStripMenuItem
Me._miWia = New System.Windows.Forms.ToolStripMenuItem
Me._miWiaVersion = New System.Windows.Forms.ToolStripMenuItem
Me._miWiaSelectSource = New System.Windows.Forms.ToolStripMenuItem
Me._miWiaAcquire = New System.Windows.Forms.ToolStripMenuItem
Me.toolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator
Me._miWiaOptions = New System.Windows.Forms.ToolStripMenuItem
Me._miOptionsAcquireOptions = New System.Windows.Forms.ToolStripMenuItem
Me.toolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator
Me._miOptionsShowUI = New System.Windows.Forms.ToolStripMenuItem
Me._miWiaCapabilities = New System.Windows.Forms.ToolStripMenuItem
Me._miCapabilitiesShowCapabilities = New System.Windows.Forms.ToolStripMenuItem
Me._miCapabilitiesShowFormats = New System.Windows.Forms.ToolStripMenuItem
Me._miWiaProperties = New System.Windows.Forms.ToolStripMenuItem
Me._miPropertiesWiaProperties = New System.Windows.Forms.ToolStripMenuItem
Me.toolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator
Me._miPropertiesShowErrors = New System.Windows.Forms.ToolStripMenuItem
Me._miOptions = New System.Windows.Forms.ToolStripMenuItem
Me._miSettings = New System.Windows.Forms.ToolStripMenuItem
Me._miHelp = New System.Windows.Forms.ToolStripMenuItem
Me._miShowHelp = New System.Windows.Forms.ToolStripMenuItem
Me._miHowToUse = New System.Windows.Forms.ToolStripMenuItem
Me.toolStripSeparator26 = New System.Windows.Forms.ToolStripSeparator
Me._miAbout = New System.Windows.Forms.ToolStripMenuItem
Me._miEventsEmf2 = New System.Windows.Forms.ToolStripMenuItem
Me._miEventsJob2 = New System.Windows.Forms.ToolStripMenuItem
Me._panelPictureBox = New System.Windows.Forms.Panel
Me._tbTableLayout = New System.Windows.Forms.TableLayoutPanel
Me._gbDicomInfo = New System.Windows.Forms.GroupBox
Me._tbPropertyGrid = New System.Windows.Forms.TableLayoutPanel
Me.panel6 = New System.Windows.Forms.Panel
Me._cmbSopClasses = New System.Windows.Forms.ComboBox
Me.label7 = New System.Windows.Forms.Label
Me._grpBoxPictureBox = New System.Windows.Forms.GroupBox
Me._tbPicture = New System.Windows.Forms.TableLayoutPanel
Me._btnNext = New System.Windows.Forms.Button
Me._btnPrev = New System.Windows.Forms.Button
Me._lblPageInfo = New System.Windows.Forms.Label
Me._btnWIAAquire = New System.Windows.Forms.Button
Me._btnTwainAquire = New System.Windows.Forms.Button
Me._btnScreenCapture = New System.Windows.Forms.Button
Me._btnOpenImage = New System.Windows.Forms.Button
Me.groupBox2 = New System.Windows.Forms.GroupBox
Me._txtPrinterName = New System.Windows.Forms.TextBox
Me.label12 = New System.Windows.Forms.Label
Me._grpImgInfo = New System.Windows.Forms.GroupBox
Me._tbDicomInfo = New System.Windows.Forms.TabControl
Me._pageDataSet = New System.Windows.Forms.TabPage
Me._tbOpenDataSet = New System.Windows.Forms.TableLayoutPanel
Me.label10 = New System.Windows.Forms.Label
Me.groupBox4 = New System.Windows.Forms.GroupBox
Me._txtDataSet = New System.Windows.Forms.TextBox
Me._btnBrowseDataSet = New System.Windows.Forms.Button
Me.panel8 = New System.Windows.Forms.Panel
Me.label19 = New System.Windows.Forms.Label
Me.label14 = New System.Windows.Forms.Label
Me._btnTransferLoadedStudies = New System.Windows.Forms.Button
Me.panel7 = New System.Windows.Forms.Panel
Me.label18 = New System.Windows.Forms.Label
Me.label13 = New System.Windows.Forms.Label
Me._btnTransferLoadedPatient = New System.Windows.Forms.Button
Me.label6 = New System.Windows.Forms.Label
Me._lstDSStudies = New System.Windows.Forms.ListView
Me.columnHeader12 = New System.Windows.Forms.ColumnHeader
Me.columnHeader13 = New System.Windows.Forms.ColumnHeader
Me.columnHeader14 = New System.Windows.Forms.ColumnHeader
Me.columnHeader15 = New System.Windows.Forms.ColumnHeader
Me.columnHeader16 = New System.Windows.Forms.ColumnHeader
Me._lstDSPatient = New System.Windows.Forms.ListView
Me.columnHeader17 = New System.Windows.Forms.ColumnHeader
Me.columnHeader18 = New System.Windows.Forms.ColumnHeader
Me.columnHeader19 = New System.Windows.Forms.ColumnHeader
Me.columnHeader20 = New System.Windows.Forms.ColumnHeader
Me._cmResultQuery = New System.Windows.Forms.ContextMenuStrip(Me.components)
Me._miDeleteSelectedDataSet = New System.Windows.Forms.ToolStripMenuItem
Me.toolStripSeparator22 = New System.Windows.Forms.ToolStripSeparator
Me._miClearResult = New System.Windows.Forms.ToolStripMenuItem
Me.label8 = New System.Windows.Forms.Label
Me.label15 = New System.Windows.Forms.Label
Me._pageSCPQuery = New System.Windows.Forms.TabPage
Me._tbQuerySCPList = New System.Windows.Forms.TableLayoutPanel
Me._grpSCPServers = New System.Windows.Forms.GroupBox
Me._btnSCPQuery = New System.Windows.Forms.Button
Me._cbSCPServers = New System.Windows.Forms.ComboBox
Me.panel10 = New System.Windows.Forms.Panel
Me.label23 = New System.Windows.Forms.Label
Me.label24 = New System.Windows.Forms.Label
Me._btnTransferSCPStudies = New System.Windows.Forms.Button
Me.panel9 = New System.Windows.Forms.Panel
Me.label21 = New System.Windows.Forms.Label
Me.label22 = New System.Windows.Forms.Label
Me._btnTransferSCPPatient = New System.Windows.Forms.Button
Me.label2 = New System.Windows.Forms.Label
Me._lstSCPStudies = New System.Windows.Forms.ListView
Me._columnHeader7 = New System.Windows.Forms.ColumnHeader
Me._columnHeader8 = New System.Windows.Forms.ColumnHeader
Me._columnHeader9 = New System.Windows.Forms.ColumnHeader
Me._columnHeader10 = New System.Windows.Forms.ColumnHeader
Me._columnHeader11 = New System.Windows.Forms.ColumnHeader
Me._lstSCPPatient = New System.Windows.Forms.ListView
Me._columnHeader1 = New System.Windows.Forms.ColumnHeader
Me._columnHeader2 = New System.Windows.Forms.ColumnHeader
Me._columnHeader3 = New System.Windows.Forms.ColumnHeader
Me._columnHeader4 = New System.Windows.Forms.ColumnHeader
Me._gbSearchParams = New System.Windows.Forms.GroupBox
Me._pgSearchSCP = New System.Windows.Forms.PropertyGrid
Me._cnmnuClearSearch = New System.Windows.Forms.ContextMenuStrip(Me.components)
Me._miClearSearch = New System.Windows.Forms.ToolStripMenuItem
Me.label1 = New System.Windows.Forms.Label
Me.label16 = New System.Windows.Forms.Label
Me.label17 = New System.Windows.Forms.Label
Me.label20 = New System.Windows.Forms.Label
Me._pageMWLQuery = New System.Windows.Forms.TabPage
Me._tbQueryMWList = New System.Windows.Forms.TableLayoutPanel
Me._toolStripMWLSearch = New System.Windows.Forms.ToolStrip
Me._toolBtnPatient = New System.Windows.Forms.ToolStripButton
Me._toolLblMWLType = New System.Windows.Forms.ToolStripLabel
Me._grpMWLQuery = New System.Windows.Forms.GroupBox
Me._btnMWLQuery = New System.Windows.Forms.Button
Me._cbMWLServers = New System.Windows.Forms.ComboBox
Me.panel12 = New System.Windows.Forms.Panel
Me.label28 = New System.Windows.Forms.Label
Me.label29 = New System.Windows.Forms.Label
Me._btnTransferMWL = New System.Windows.Forms.Button
Me._lstMWLItems = New System.Windows.Forms.ListView
Me.columnHeader26 = New System.Windows.Forms.ColumnHeader
Me.columnHeader27 = New System.Windows.Forms.ColumnHeader
Me.columnHeader28 = New System.Windows.Forms.ColumnHeader
Me.columnHeader29 = New System.Windows.Forms.ColumnHeader
Me.columnHeader21 = New System.Windows.Forms.ColumnHeader
Me.columnHeader22 = New System.Windows.Forms.ColumnHeader
Me.columnHeader23 = New System.Windows.Forms.ColumnHeader
Me.columnHeader24 = New System.Windows.Forms.ColumnHeader
Me.columnHeader25 = New System.Windows.Forms.ColumnHeader
Me.columnHeader30 = New System.Windows.Forms.ColumnHeader
Me._gbMWLSearch = New System.Windows.Forms.GroupBox
Me._pgSearchMWL = New System.Windows.Forms.PropertyGrid
Me.label11 = New System.Windows.Forms.Label
Me.label25 = New System.Windows.Forms.Label
Me.label26 = New System.Windows.Forms.Label
Me.label27 = New System.Windows.Forms.Label
Me._grpStoreServers = New System.Windows.Forms.GroupBox
Me._btnPACSSettings = New System.Windows.Forms.Button
Me._btnPushToPACS = New System.Windows.Forms.Button
Me._cbStoreServers = New System.Windows.Forms.ComboBox
Me.label9 = New System.Windows.Forms.Label
Me._panelImageList = New System.Windows.Forms.Panel
Me._cnmnuClearDicom = New System.Windows.Forms.ContextMenuStrip(Me.components)
Me._miClearPG = New System.Windows.Forms.ToolStripMenuItem
Me._clmnPNMWL = New System.Windows.Forms.DataGridViewTextBoxColumn
Me._clmnANMWL = New System.Windows.Forms.DataGridViewTextBoxColumn
Me._clmnPIDMWL = New System.Windows.Forms.DataGridViewTextBoxColumn
Me._clmnSSAEMWL = New System.Windows.Forms.DataGridViewTextBoxColumn
Me._clmnSSMWL = New System.Windows.Forms.DataGridViewTextBoxColumn
Me._clmnBDMWL = New System.Windows.Forms.DataGridViewTextBoxColumn
Me._clmnGMWL = New System.Windows.Forms.DataGridViewTextBoxColumn
Me._clmnSPRrocMWL = New System.Windows.Forms.DataGridViewTextBoxColumn
Me._clmnMODMWL = New System.Windows.Forms.DataGridViewTextBoxColumn
Me._gbRecognized = New System.Windows.Forms.GroupBox
Me.label3 = New System.Windows.Forms.Label
Me.listView1 = New System.Windows.Forms.ListView
Me.columnHeader1 = New System.Windows.Forms.ColumnHeader
Me.columnHeader2 = New System.Windows.Forms.ColumnHeader
Me.columnHeader3 = New System.Windows.Forms.ColumnHeader
Me.columnHeader4 = New System.Windows.Forms.ColumnHeader
Me.columnHeader5 = New System.Windows.Forms.ColumnHeader
Me.listView2 = New System.Windows.Forms.ListView
Me.columnHeader6 = New System.Windows.Forms.ColumnHeader
Me.columnHeader7 = New System.Windows.Forms.ColumnHeader
Me.columnHeader8 = New System.Windows.Forms.ColumnHeader
Me.columnHeader9 = New System.Windows.Forms.ColumnHeader
Me.columnHeader10 = New System.Windows.Forms.ColumnHeader
Me.columnHeader11 = New System.Windows.Forms.ColumnHeader
Me.panel2 = New System.Windows.Forms.Panel
Me.button1 = New System.Windows.Forms.Button
Me.groupBox1 = New System.Windows.Forms.GroupBox
Me.propertyGrid1 = New System.Windows.Forms.PropertyGrid
Me.panel3 = New System.Windows.Forms.Panel
Me.comboBox1 = New System.Windows.Forms.ComboBox
Me.label4 = New System.Windows.Forms.Label
Me.label5 = New System.Windows.Forms.Label
Me._toolbarMain = New System.Windows.Forms.ToolStrip
Me._toolBtnOpenRaster = New System.Windows.Forms.ToolStripButton
Me.toolStripSeparator23 = New System.Windows.Forms.ToolStripSeparator
Me._toolBtnStoreToPacs = New System.Windows.Forms.ToolStripButton
Me._toolBtnSaveDicom = New System.Windows.Forms.ToolStripButton
Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
Me._toolBtnCLearInfo = New System.Windows.Forms.ToolStripButton
Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
Me._toolBtnDeleteAll = New System.Windows.Forms.ToolStripButton
Me._toolBtnDeleteSelected = New System.Windows.Forms.ToolStripButton
Me.toolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
Me._toolBtnTwain = New System.Windows.Forms.ToolStripButton
Me._toolBtnWia = New System.Windows.Forms.ToolStripButton
Me.toolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator
Me._toolBtnRotate = New System.Windows.Forms.ToolStripButton
Me.toolStripSeparator24 = New System.Windows.Forms.ToolStripSeparator
Me._toolBtnScreenCapture = New System.Windows.Forms.ToolStripButton
Me.toolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator
Me._toolBtnViewLog = New System.Windows.Forms.ToolStripButton
Me.toolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
Me._toolBtnSettings = New System.Windows.Forms.ToolStripButton
Me.toolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
Me._toolBtnHelp = New System.Windows.Forms.ToolStripButton
Me._cmListBox = New System.Windows.Forms.ContextMenuStrip(Me.components)
Me._cmiViewMode = New System.Windows.Forms.ToolStripMenuItem
Me._cmiExpanded = New System.Windows.Forms.ToolStripMenuItem
Me._cmiCondensed = New System.Windows.Forms.ToolStripMenuItem
Me.toolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
Me._cmiDeleteAll = New System.Windows.Forms.ToolStripMenuItem
Me._cmiDeleteSelected = New System.Windows.Forms.ToolStripMenuItem
Me._lstBoxPages = New PrintToPACSDemo.ListImageBox
Me._mmMain.SuspendLayout()
Me._panelPictureBox.SuspendLayout()
Me._tbTableLayout.SuspendLayout()
Me._gbDicomInfo.SuspendLayout()
Me._tbPropertyGrid.SuspendLayout()
Me.panel6.SuspendLayout()
Me._grpBoxPictureBox.SuspendLayout()
Me._tbPicture.SuspendLayout()
Me.groupBox2.SuspendLayout()
Me._grpImgInfo.SuspendLayout()
Me._tbDicomInfo.SuspendLayout()
Me._pageDataSet.SuspendLayout()
Me._tbOpenDataSet.SuspendLayout()
Me.groupBox4.SuspendLayout()
Me.panel8.SuspendLayout()
Me.panel7.SuspendLayout()
Me._cmResultQuery.SuspendLayout()
Me._pageSCPQuery.SuspendLayout()
Me._tbQuerySCPList.SuspendLayout()
Me._grpSCPServers.SuspendLayout()
Me.panel10.SuspendLayout()
Me.panel9.SuspendLayout()
Me._gbSearchParams.SuspendLayout()
Me._cnmnuClearSearch.SuspendLayout()
Me._pageMWLQuery.SuspendLayout()
Me._tbQueryMWList.SuspendLayout()
Me._toolStripMWLSearch.SuspendLayout()
Me._grpMWLQuery.SuspendLayout()
Me.panel12.SuspendLayout()
Me._gbMWLSearch.SuspendLayout()
Me._grpStoreServers.SuspendLayout()
Me._cnmnuClearDicom.SuspendLayout()
Me.panel2.SuspendLayout()
Me.panel3.SuspendLayout()
Me._toolbarMain.SuspendLayout()
Me._cmListBox.SuspendLayout()
Me.SuspendLayout()
'
'_mmMain
'
Me._mmMain.BackColor = System.Drawing.SystemColors.Control
Me._mmMain.GripMargin = New System.Windows.Forms.Padding(0)
Me._mmMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miFile, Me._miEdit, Me._miView, Me._miCapture, Me._miAcquire, Me._miOptions, Me._miHelp})
Me._mmMain.Location = New System.Drawing.Point(0, 0)
Me._mmMain.Name = "_mmMain"
Me._mmMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
Me._mmMain.ShowItemToolTips = True
Me._mmMain.Size = New System.Drawing.Size(1014, 24)
Me._mmMain.Stretch = False
Me._mmMain.TabIndex = 0
'
'_miFile
'
Me._miFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miOpen, Me.toolStripSeparator10, Me._miSaveAsDICOM, Me._miStoreToPACS, Me.toolStripSeparator1, Me._miExit})
Me._miFile.Name = "_miFile"
Me._miFile.Size = New System.Drawing.Size(37, 20)
Me._miFile.Text = "&File"
'
'_miOpen
'
Me._miOpen.Image = Global.Resources.LoadRaster
Me._miOpen.Name = "_miOpen"
Me._miOpen.Size = New System.Drawing.Size(170, 22)
Me._miOpen.Text = "&Open..."
'
'toolStripSeparator10
'
Me.toolStripSeparator10.Name = "toolStripSeparator10"
Me.toolStripSeparator10.Size = New System.Drawing.Size(167, 6)
'
'_miSaveAsDICOM
'
Me._miSaveAsDICOM.Image = Global.Resources.StorePACS_32
Me._miSaveAsDICOM.Name = "_miSaveAsDICOM"
Me._miSaveAsDICOM.Size = New System.Drawing.Size(170, 22)
Me._miSaveAsDICOM.Text = "&Save DICOM File..."
'
'_miStoreToPACS
'
Me._miStoreToPACS.Image = Global.Resources.SaveDICOM
Me._miStoreToPACS.Name = "_miStoreToPACS"
Me._miStoreToPACS.Size = New System.Drawing.Size(170, 22)
Me._miStoreToPACS.Text = "Sto&re to PACS"
'
'toolStripSeparator1
'
Me.toolStripSeparator1.Name = "toolStripSeparator1"
Me.toolStripSeparator1.Size = New System.Drawing.Size(167, 6)
'
'_miExit
'
Me._miExit.Name = "_miExit"
Me._miExit.Size = New System.Drawing.Size(170, 22)
Me._miExit.Text = "&Exit"
'
'_miEdit
'
Me._miEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miPaste, Me.toolStripSeparator25, Me._miRotate90, Me.toolStripSeparator11, Me._miDeleteAll, Me._miDeleteSelected, Me.toolStripSeparator2, Me._miResetInfo})
Me._miEdit.Name = "_miEdit"
Me._miEdit.Size = New System.Drawing.Size(39, 20)
Me._miEdit.Text = "&Edit"
'
'_miPaste
'
Me._miPaste.Name = "_miPaste"
Me._miPaste.Size = New System.Drawing.Size(196, 22)
Me._miPaste.Text = "&Paste "
'
'toolStripSeparator25
'
Me.toolStripSeparator25.Name = "toolStripSeparator25"
Me.toolStripSeparator25.Size = New System.Drawing.Size(193, 6)
'
'_miRotate90
'
Me._miRotate90.Image = Global.Resources.Rotate
Me._miRotate90.Name = "_miRotate90"
Me._miRotate90.Size = New System.Drawing.Size(196, 22)
Me._miRotate90.Text = "Ro&tate 90 degree"
'
'toolStripSeparator11
'
Me.toolStripSeparator11.Name = "toolStripSeparator11"
Me.toolStripSeparator11.Size = New System.Drawing.Size(193, 6)
'
'_miDeleteAll
'
Me._miDeleteAll.Image = Global.Resources.DeleteImage
Me._miDeleteAll.Name = "_miDeleteAll"
Me._miDeleteAll.Size = New System.Drawing.Size(196, 22)
Me._miDeleteAll.Text = "&Delete All Pages"
'
'_miDeleteSelected
'
Me._miDeleteSelected.Image = Global.Resources.DeleteSelectImage
Me._miDeleteSelected.Name = "_miDeleteSelected"
Me._miDeleteSelected.Size = New System.Drawing.Size(196, 22)
Me._miDeleteSelected.Text = "Delete &Selected Page(s)"
'
'toolStripSeparator2
'
Me.toolStripSeparator2.Name = "toolStripSeparator2"
Me.toolStripSeparator2.Size = New System.Drawing.Size(193, 6)
'
'_miResetInfo
'
Me._miResetInfo.Image = Global.Resources.ClearDICOM
Me._miResetInfo.Name = "_miResetInfo"
Me._miResetInfo.Size = New System.Drawing.Size(196, 22)
Me._miResetInfo.Text = "&Reset DICOM Info"
'
'_miView
'
Me._miView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miNormal, Me._miFit, Me._miZoomIn, Me._miZoomOut, Me.toolStripSeparator3, Me._miResample, Me.toolStripSeparator12, Me._miViewLog})
Me._miView.Name = "_miView"
Me._miView.Size = New System.Drawing.Size(44, 20)
Me._miView.Text = "&View"
'
'_miNormal
'
Me._miNormal.Checked = True
Me._miNormal.CheckState = System.Windows.Forms.CheckState.Checked
Me._miNormal.Enabled = False
Me._miNormal.Name = "_miNormal"
Me._miNormal.Size = New System.Drawing.Size(189, 22)
Me._miNormal.Text = "&Normal"
'
'_miFit
'
Me._miFit.Enabled = False
Me._miFit.Name = "_miFit"
Me._miFit.Size = New System.Drawing.Size(189, 22)
Me._miFit.Text = "&Fit To Window"
'
'_miZoomIn
'
Me._miZoomIn.Enabled = False
Me._miZoomIn.Name = "_miZoomIn"
Me._miZoomIn.Size = New System.Drawing.Size(189, 22)
Me._miZoomIn.Text = "Zoom &In (+)"
'
'_miZoomOut
'
Me._miZoomOut.Enabled = False
Me._miZoomOut.Name = "_miZoomOut"
Me._miZoomOut.Size = New System.Drawing.Size(189, 22)
Me._miZoomOut.Text = "Zoom &Out (-)"
'
'toolStripSeparator3
'
Me.toolStripSeparator3.Name = "toolStripSeparator3"
Me.toolStripSeparator3.Size = New System.Drawing.Size(186, 6)
'
'_miResample
'
Me._miResample.Name = "_miResample"
Me._miResample.Size = New System.Drawing.Size(189, 22)
Me._miResample.Text = "&Resample Paint Mode"
'
'toolStripSeparator12
'
Me.toolStripSeparator12.Name = "toolStripSeparator12"
Me.toolStripSeparator12.Size = New System.Drawing.Size(186, 6)
'
'_miViewLog
'
Me._miViewLog.Image = Global.Resources.ViewLog
Me._miViewLog.Name = "_miViewLog"
Me._miViewLog.Size = New System.Drawing.Size(189, 22)
Me._miViewLog.Text = "Show &Log..."
'
'_miCapture
'
Me._miCapture.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miCaptureActiveWindow, Me._miCaptureFullScreen, Me._miCaptureSelectedObject, Me._miCaptureSelectedArea, Me.toolStripSeparator13, Me._miCaptureStopCapture, Me.toolStripSeparator19, Me._miCaptureOptionsMenu})
Me._miCapture.Name = "_miCapture"
Me._miCapture.Size = New System.Drawing.Size(61, 20)
Me._miCapture.Text = "&Capture"
'
'_miCaptureActiveWindow
'
Me._miCaptureActiveWindow.Name = "_miCaptureActiveWindow"
Me._miCaptureActiveWindow.Size = New System.Drawing.Size(156, 22)
Me._miCaptureActiveWindow.Text = "Active &Window"
'
'_miCaptureFullScreen
'
Me._miCaptureFullScreen.Name = "_miCaptureFullScreen"
Me._miCaptureFullScreen.Size = New System.Drawing.Size(156, 22)
Me._miCaptureFullScreen.Text = "&Full Screen"
'
'_miCaptureSelectedObject
'
Me._miCaptureSelectedObject.Name = "_miCaptureSelectedObject"
Me._miCaptureSelectedObject.Size = New System.Drawing.Size(156, 22)
Me._miCaptureSelectedObject.Text = "&Selected Object"
'
'_miCaptureSelectedArea
'
Me._miCaptureSelectedArea.Name = "_miCaptureSelectedArea"
Me._miCaptureSelectedArea.Size = New System.Drawing.Size(156, 22)
Me._miCaptureSelectedArea.Text = "Selected &Area"
'
'toolStripSeparator13
'
Me.toolStripSeparator13.Name = "toolStripSeparator13"
Me.toolStripSeparator13.Size = New System.Drawing.Size(153, 6)
'
'_miCaptureStopCapture
'
Me._miCaptureStopCapture.Enabled = False
Me._miCaptureStopCapture.Name = "_miCaptureStopCapture"
Me._miCaptureStopCapture.Size = New System.Drawing.Size(156, 22)
Me._miCaptureStopCapture.Text = "St&op Capture"
'
'toolStripSeparator19
'
Me.toolStripSeparator19.Name = "toolStripSeparator19"
Me.toolStripSeparator19.Size = New System.Drawing.Size(153, 6)
'
'_miCaptureOptionsMenu
'
Me._miCaptureOptionsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miCaptureAreaOptions, Me._miCaptureOptions, Me._miCaptureObjectOptions})
Me._miCaptureOptionsMenu.Name = "_miCaptureOptionsMenu"
Me._miCaptureOptionsMenu.Size = New System.Drawing.Size(156, 22)
Me._miCaptureOptionsMenu.Text = " &Options"
'
'_miCaptureAreaOptions
'
Me._miCaptureAreaOptions.Name = "_miCaptureAreaOptions"
Me._miCaptureAreaOptions.Size = New System.Drawing.Size(208, 22)
Me._miCaptureAreaOptions.Text = "Capture &Area Options..."
'
'_miCaptureOptions
'
Me._miCaptureOptions.Name = "_miCaptureOptions"
Me._miCaptureOptions.Size = New System.Drawing.Size(208, 22)
Me._miCaptureOptions.Text = "&Capture Options..."
'
'_miCaptureObjectOptions
'
Me._miCaptureObjectOptions.Name = "_miCaptureObjectOptions"
Me._miCaptureObjectOptions.Size = New System.Drawing.Size(208, 22)
Me._miCaptureObjectOptions.Text = "Capture &Object Options..."
'
'_miAcquire
'
Me._miAcquire.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miAcquireTwain, Me._miWia})
Me._miAcquire.Name = "_miAcquire"
Me._miAcquire.Size = New System.Drawing.Size(60, 20)
Me._miAcquire.Text = "&Acquire"
'
'_miAcquireTwain
'
Me._miAcquireTwain.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miTwainAcquire, Me.toolStripSeparator15, Me._miTemplate, Me._miTwainSelectSource})
Me._miAcquireTwain.Name = "_miAcquireTwain"
Me._miAcquireTwain.Size = New System.Drawing.Size(106, 22)
Me._miAcquireTwain.Text = "&Twain"
'
'_miTwainAcquire
'
Me._miTwainAcquire.Image = Global.Resources.TWAINAquire
Me._miTwainAcquire.Name = "_miTwainAcquire"
Me._miTwainAcquire.Size = New System.Drawing.Size(153, 22)
Me._miTwainAcquire.Text = "Ac&quire"
'
'toolStripSeparator15
'
Me.toolStripSeparator15.Name = "toolStripSeparator15"
Me.toolStripSeparator15.Size = New System.Drawing.Size(150, 6)
'
'_miTemplate
'
Me._miTemplate.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miTemplateLEAD, Me._miTemplateShowCaps, Me.toolStripSeparator14, Me._miTemplateShowErrors})
Me._miTemplate.Name = "_miTemplate"
Me._miTemplate.Size = New System.Drawing.Size(153, 22)
Me._miTemplate.Text = "Te&mplate"
'
'_miTemplateLEAD
'
Me._miTemplateLEAD.Name = "_miTemplateLEAD"
Me._miTemplateLEAD.Size = New System.Drawing.Size(234, 22)
Me._miTemplateLEAD.Text = "&LEAD Template..."
'
'_miTemplateShowCaps
'
Me._miTemplateShowCaps.Name = "_miTemplateShowCaps"
Me._miTemplateShowCaps.Size = New System.Drawing.Size(234, 22)
Me._miTemplateShowCaps.Text = "Show Supported &Capabilities..."
'
'toolStripSeparator14
'
Me.toolStripSeparator14.Name = "toolStripSeparator14"
Me.toolStripSeparator14.Size = New System.Drawing.Size(231, 6)
'
'_miTemplateShowErrors
'
Me._miTemplateShowErrors.Name = "_miTemplateShowErrors"
Me._miTemplateShowErrors.Size = New System.Drawing.Size(234, 22)
Me._miTemplateShowErrors.Text = "Show &Error Codes..."
'
'_miTwainSelectSource
'
Me._miTwainSelectSource.Name = "_miTwainSelectSource"
Me._miTwainSelectSource.Size = New System.Drawing.Size(153, 22)
Me._miTwainSelectSource.Text = "&Select Source..."
'
'_miWia
'
Me._miWia.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miWiaVersion, Me._miWiaSelectSource, Me._miWiaAcquire, Me.toolStripSeparator17, Me._miWiaOptions, Me._miWiaCapabilities, Me._miWiaProperties})
Me._miWia.Name = "_miWia"
Me._miWia.Size = New System.Drawing.Size(106, 22)
Me._miWia.Text = "&Wia"
'
'_miWiaVersion
'
Me._miWiaVersion.Name = "_miWiaVersion"
Me._miWiaVersion.Size = New System.Drawing.Size(158, 22)
Me._miWiaVersion.Text = "Wia &Version..."
'
'_miWiaSelectSource
'
Me._miWiaSelectSource.Name = "_miWiaSelectSource"
Me._miWiaSelectSource.Size = New System.Drawing.Size(158, 22)
Me._miWiaSelectSource.Text = "&Select Source..."
'
'_miWiaAcquire
'
Me._miWiaAcquire.Image = Global.Resources.WIAAcquire
Me._miWiaAcquire.Name = "_miWiaAcquire"
Me._miWiaAcquire.Size = New System.Drawing.Size(158, 22)
Me._miWiaAcquire.Text = "Ac&quire"
'
'toolStripSeparator17
'
Me.toolStripSeparator17.Name = "toolStripSeparator17"
Me.toolStripSeparator17.Size = New System.Drawing.Size(155, 6)
'
'_miWiaOptions
'
Me._miWiaOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miOptionsAcquireOptions, Me.toolStripSeparator16, Me._miOptionsShowUI})
Me._miWiaOptions.Name = "_miWiaOptions"
Me._miWiaOptions.Size = New System.Drawing.Size(158, 22)
Me._miWiaOptions.Text = "Wia &Options"
'
'_miOptionsAcquireOptions
'
Me._miOptionsAcquireOptions.Name = "_miOptionsAcquireOptions"
Me._miOptionsAcquireOptions.Size = New System.Drawing.Size(231, 22)
Me._miOptionsAcquireOptions.Text = "Acquire &Options..."
'
'toolStripSeparator16
'
Me.toolStripSeparator16.Name = "toolStripSeparator16"
Me.toolStripSeparator16.Size = New System.Drawing.Size(228, 6)
'
'_miOptionsShowUI
'
Me._miOptionsShowUI.Name = "_miOptionsShowUI"
Me._miOptionsShowUI.Size = New System.Drawing.Size(231, 22)
Me._miOptionsShowUI.Text = "Show Acquire User &Interface..."
'
'_miWiaCapabilities
'
Me._miWiaCapabilities.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miCapabilitiesShowCapabilities, Me._miCapabilitiesShowFormats})
Me._miWiaCapabilities.Name = "_miWiaCapabilities"
Me._miWiaCapabilities.Size = New System.Drawing.Size(158, 22)
Me._miWiaCapabilities.Text = "Wia &Capabilities"
'
'_miCapabilitiesShowCapabilities
'
Me._miCapabilitiesShowCapabilities.Name = "_miCapabilitiesShowCapabilities"
Me._miCapabilitiesShowCapabilities.Size = New System.Drawing.Size(234, 22)
Me._miCapabilitiesShowCapabilities.Text = "Show Supported &Capabilities..."
'
'_miCapabilitiesShowFormats
'
Me._miCapabilitiesShowFormats.Name = "_miCapabilitiesShowFormats"
Me._miCapabilitiesShowFormats.Size = New System.Drawing.Size(234, 22)
Me._miCapabilitiesShowFormats.Text = "Show Supported &Formats..."
'
'_miWiaProperties
'
Me._miWiaProperties.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miPropertiesWiaProperties, Me.toolStripSeparator18, Me._miPropertiesShowErrors})
Me._miWiaProperties.Name = "_miWiaProperties"
Me._miWiaProperties.Size = New System.Drawing.Size(158, 22)
Me._miWiaProperties.Text = "Wia &Properties"
'
'_miPropertiesWiaProperties
'
Me._miPropertiesWiaProperties.Name = "_miPropertiesWiaProperties"
Me._miPropertiesWiaProperties.Size = New System.Drawing.Size(201, 22)
Me._miPropertiesWiaProperties.Text = "&WIA Properties..."
'
'toolStripSeparator18
'
Me.toolStripSeparator18.Name = "toolStripSeparator18"
Me.toolStripSeparator18.Size = New System.Drawing.Size(198, 6)
'
'_miPropertiesShowErrors
'
Me._miPropertiesShowErrors.Name = "_miPropertiesShowErrors"
Me._miPropertiesShowErrors.Size = New System.Drawing.Size(201, 22)
Me._miPropertiesShowErrors.Text = "Show Properties &Errors..."
'
'_miOptions
'
Me._miOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miSettings})
Me._miOptions.Name = "_miOptions"
Me._miOptions.Size = New System.Drawing.Size(61, 20)
Me._miOptions.Text = "&Options"
'
'_miSettings
'
Me._miSettings.Image = Global.Resources.AppSettings
Me._miSettings.Name = "_miSettings"
Me._miSettings.Size = New System.Drawing.Size(125, 22)
Me._miSettings.Text = "&Settings..."
'
'_miHelp
'
Me._miHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miShowHelp, Me._miHowToUse, Me.toolStripSeparator26, Me._miAbout})
Me._miHelp.Name = "_miHelp"
Me._miHelp.Size = New System.Drawing.Size(44, 20)
Me._miHelp.Text = "&Help"
'
'_miShowHelp
'
Me._miShowHelp.Image = Global.Resources.Help
Me._miShowHelp.Name = "_miShowHelp"
Me._miShowHelp.Size = New System.Drawing.Size(213, 22)
Me._miShowHelp.Text = "&Show Help..."
'
'_miHowToUse
'
Me._miHowToUse.Name = "_miHowToUse"
Me._miHowToUse.Size = New System.Drawing.Size(213, 22)
Me._miHowToUse.Text = "&How To Use..."
'
'toolStripSeparator26
'
Me.toolStripSeparator26.Name = "toolStripSeparator26"
Me.toolStripSeparator26.Size = New System.Drawing.Size(210, 6)
'
'_miAbout
'
Me._miAbout.Name = "_miAbout"
Me._miAbout.Size = New System.Drawing.Size(213, 22)
Me._miAbout.Text = "&About PrintToPACS Demo"
'
'_miEventsEmf2
'
Me._miEventsEmf2.Name = "_miEventsEmf2"
Me._miEventsEmf2.Size = New System.Drawing.Size(152, 22)
Me._miEventsEmf2.Text = "a"
'
'_miEventsJob2
'
Me._miEventsJob2.Name = "_miEventsJob2"
Me._miEventsJob2.Size = New System.Drawing.Size(152, 22)
Me._miEventsJob2.Text = "a"
'
'_panelPictureBox
'
Me._panelPictureBox.AutoScroll = True
Me._panelPictureBox.Controls.Add(Me._tbTableLayout)
Me._panelPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
Me._panelPictureBox.Location = New System.Drawing.Point(0, 55)
Me._panelPictureBox.Name = "_panelPictureBox"
Me._panelPictureBox.Size = New System.Drawing.Size(1014, 679)
Me._panelPictureBox.TabIndex = 5
'
'_tbTableLayout
'
Me._tbTableLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
Me._tbTableLayout.ColumnCount = 3
Me._tbTableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
Me._tbTableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
Me._tbTableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 308.0!))
Me._tbTableLayout.Controls.Add(Me._gbDicomInfo, 2, 1)
Me._tbTableLayout.Controls.Add(Me._grpBoxPictureBox, 0, 0)
Me._tbTableLayout.Controls.Add(Me._grpImgInfo, 1, 0)
Me._tbTableLayout.Controls.Add(Me._grpStoreServers, 2, 0)
Me._tbTableLayout.Dock = System.Windows.Forms.DockStyle.Fill
Me._tbTableLayout.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me._tbTableLayout.Location = New System.Drawing.Point(0, 0)
Me._tbTableLayout.Name = "_tbTableLayout"
Me._tbTableLayout.RowCount = 3
Me._tbTableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
Me._tbTableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
Me._tbTableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 155.0!))
Me._tbTableLayout.Size = New System.Drawing.Size(1014, 679)
Me._tbTableLayout.TabIndex = 0
'
'_gbDicomInfo
'
Me._gbDicomInfo.Controls.Add(Me._tbPropertyGrid)
Me._gbDicomInfo.Dock = System.Windows.Forms.DockStyle.Fill
Me._gbDicomInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
Me._gbDicomInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me._gbDicomInfo.Location = New System.Drawing.Point(705, 89)
Me._gbDicomInfo.Name = "_gbDicomInfo"
Me._gbDicomInfo.Size = New System.Drawing.Size(303, 426)
Me._gbDicomInfo.TabIndex = 10
Me._gbDicomInfo.TabStop = False
Me._gbDicomInfo.Text = "DICOM Information to be used with image"
'
'_tbPropertyGrid
'
Me._tbPropertyGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me._tbPropertyGrid.ColumnCount = 1
Me._tbPropertyGrid.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
Me._tbPropertyGrid.Controls.Add(Me.panel6, 0, 0)
Me._tbPropertyGrid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me._tbPropertyGrid.Location = New System.Drawing.Point(3, 23)
Me._tbPropertyGrid.Name = "_tbPropertyGrid"
Me._tbPropertyGrid.RowCount = 2
Me._tbPropertyGrid.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
Me._tbPropertyGrid.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
Me._tbPropertyGrid.Size = New System.Drawing.Size(294, 400)
Me._tbPropertyGrid.TabIndex = 3
'
'panel6
'
Me.panel6.Controls.Add(Me._cmbSopClasses)
Me.panel6.Controls.Add(Me.label7)
Me.panel6.Dock = System.Windows.Forms.DockStyle.Top
Me.panel6.Location = New System.Drawing.Point(3, 3)
Me.panel6.Name = "panel6"
Me.panel6.Size = New System.Drawing.Size(288, 24)
Me.panel6.TabIndex = 3
'
'_cmbSopClasses
'
Me._cmbSopClasses.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me._cmbSopClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me._cmbSopClasses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me._cmbSopClasses.FormattingEnabled = True
Me._cmbSopClasses.Items.AddRange(New Object() {"Secondary Capture", "SC multi frame 8-bit gray", "SC multi frame 24-bit color", "Encapsulated PDF"})
Me._cmbSopClasses.Location = New System.Drawing.Point(104, 3)
Me._cmbSopClasses.Name = "_cmbSopClasses"
Me._cmbSopClasses.Size = New System.Drawing.Size(178, 21)
Me._cmbSopClasses.TabIndex = 0
'
'label7
'
Me.label7.AutoSize = True
Me.label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label7.Location = New System.Drawing.Point(3, 6)
Me.label7.Name = "label7"
Me.label7.Size = New System.Drawing.Size(69, 13)
Me.label7.TabIndex = 1
Me.label7.Text = "DICOM Type"
'
'_grpBoxPictureBox
'
Me._grpBoxPictureBox.Controls.Add(Me._tbPicture)
Me._grpBoxPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
Me._grpBoxPictureBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me._grpBoxPictureBox.Location = New System.Drawing.Point(6, 6)
Me._grpBoxPictureBox.Name = "_grpBoxPictureBox"
Me._tbTableLayout.SetRowSpan(Me._grpBoxPictureBox, 2)
Me._grpBoxPictureBox.Size = New System.Drawing.Size(271, 509)
Me._grpBoxPictureBox.TabIndex = 13
Me._grpBoxPictureBox.TabStop = False
Me._grpBoxPictureBox.Text = "Obtain an Image from source or print from another application:"
'
'_tbPicture
'
Me._tbPicture.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me._tbPicture.ColumnCount = 4
Me._tbPicture.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
Me._tbPicture.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
Me._tbPicture.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
Me._tbPicture.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69.0!))
Me._tbPicture.Controls.Add(Me._btnNext, 2, 4)
Me._tbPicture.Controls.Add(Me._btnPrev, 0, 4)
Me._tbPicture.Controls.Add(Me._lblPageInfo, 1, 4)
Me._tbPicture.Controls.Add(Me._btnWIAAquire, 2, 2)
Me._tbPicture.Controls.Add(Me._btnTwainAquire, 0, 2)
Me._tbPicture.Controls.Add(Me._btnScreenCapture, 2, 1)
Me._tbPicture.Controls.Add(Me._btnOpenImage, 0, 1)
Me._tbPicture.Controls.Add(Me.groupBox2, 0, 0)
Me._tbPicture.Location = New System.Drawing.Point(3, 33)
Me._tbPicture.Name = "_tbPicture"
Me._tbPicture.RowCount = 6
Me._tbPicture.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
Me._tbPicture.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
Me._tbPicture.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
Me._tbPicture.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
Me._tbPicture.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
Me._tbPicture.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
Me._tbPicture.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
Me._tbPicture.Size = New System.Drawing.Size(265, 473)
Me._tbPicture.TabIndex = 13
'
'_btnNext
'
Me._btnNext.AutoSize = True
Me._btnNext.Dock = System.Windows.Forms.DockStyle.Right
Me._btnNext.Enabled = False
Me._btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me._btnNext.Location = New System.Drawing.Point(234, 123)
Me._btnNext.Name = "_btnNext"
Me._btnNext.Size = New System.Drawing.Size(28, 24)
Me._btnNext.TabIndex = 21
Me._btnNext.Text = "->"
Me._btnNext.UseVisualStyleBackColor = True
'
'_btnPrev
'
Me._btnPrev.AutoSize = True
Me._btnPrev.Dock = System.Windows.Forms.DockStyle.Left
Me._btnPrev.Enabled = False
Me._btnPrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me._btnPrev.Location = New System.Drawing.Point(3, 123)
Me._btnPrev.Name = "_btnPrev"
Me._btnPrev.Size = New System.Drawing.Size(28, 24)
Me._btnPrev.TabIndex = 20
Me._btnPrev.Text = "<-"
Me._btnPrev.UseVisualStyleBackColor = True
'
'_lblPageInfo
'
Me._lblPageInfo.AutoSize = True
Me._tbPicture.SetColumnSpan(Me._lblPageInfo, 2)
Me._lblPageInfo.Dock = System.Windows.Forms.DockStyle.Fill
Me._lblPageInfo.Location = New System.Drawing.Point(43, 120)
Me._lblPageInfo.Name = "_lblPageInfo"
Me._lblPageInfo.Size = New System.Drawing.Size(150, 30)
Me._lblPageInfo.TabIndex = 19
Me._lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'_btnWIAAquire
'
Me._tbPicture.SetColumnSpan(Me._btnWIAAquire, 2)
Me._btnWIAAquire.Dock = System.Windows.Forms.DockStyle.Right
Me._btnWIAAquire.Enabled = False
Me._btnWIAAquire.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me._btnWIAAquire.Location = New System.Drawing.Point(142, 73)
Me._btnWIAAquire.Name = "_btnWIAAquire"
Me._btnWIAAquire.Size = New System.Drawing.Size(120, 24)
Me._btnWIAAquire.TabIndex = 17
Me._btnWIAAquire.Text = "WIA Aquire"
Me._btnWIAAquire.UseVisualStyleBackColor = True
'
'_btnTwainAquire
'
Me._tbPicture.SetColumnSpan(Me._btnTwainAquire, 2)
Me._btnTwainAquire.Enabled = False
Me._btnTwainAquire.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me._btnTwainAquire.Location = New System.Drawing.Point(3, 73)
Me._btnTwainAquire.Name = "_btnTwainAquire"
Me._btnTwainAquire.Size = New System.Drawing.Size(105, 23)
Me._btnTwainAquire.TabIndex = 16
Me._btnTwainAquire.Text = "Twain Aquire ..."
Me._btnTwainAquire.UseVisualStyleBackColor = True
'
'_btnScreenCapture
'
Me._tbPicture.SetColumnSpan(Me._btnScreenCapture, 2)
Me._btnScreenCapture.Dock = System.Windows.Forms.DockStyle.Right
Me._btnScreenCapture.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me._btnScreenCapture.Location = New System.Drawing.Point(142, 43)
Me._btnScreenCapture.Name = "_btnScreenCapture"
Me._btnScreenCapture.Size = New System.Drawing.Size(120, 24)
Me._btnScreenCapture.TabIndex = 15
Me._btnScreenCapture.Text = "Screen Capture..."
Me._btnScreenCapture.UseVisualStyleBackColor = True
'
'_btnOpenImage
'
Me._tbPicture.SetColumnSpan(Me._btnOpenImage, 2)
Me._btnOpenImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me._btnOpenImage.Location = New System.Drawing.Point(3, 43)
Me._btnOpenImage.Name = "_btnOpenImage"
Me._btnOpenImage.Size = New System.Drawing.Size(105, 23)
Me._btnOpenImage.TabIndex = 14
Me._btnOpenImage.Text = "From File..."
Me._btnOpenImage.UseVisualStyleBackColor = True
'
'groupBox2
'
Me._tbPicture.SetColumnSpan(Me.groupBox2, 4)
Me.groupBox2.Controls.Add(Me._txtPrinterName)
Me.groupBox2.Controls.Add(Me.label12)
Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill
Me.groupBox2.Location = New System.Drawing.Point(3, 3)
Me.groupBox2.Name = "groupBox2"
Me.groupBox2.Size = New System.Drawing.Size(259, 34)
Me.groupBox2.TabIndex = 0
Me.groupBox2.TabStop = False
'
'_txtPrinterName
'
Me._txtPrinterName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me._txtPrinterName.BackColor = System.Drawing.Color.White
Me._txtPrinterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me._txtPrinterName.Location = New System.Drawing.Point(95, 10)
Me._txtPrinterName.Name = "_txtPrinterName"
Me._txtPrinterName.ReadOnly = True
Me._txtPrinterName.Size = New System.Drawing.Size(158, 20)
Me._txtPrinterName.TabIndex = 20
'
'label12
'
Me.label12.AutoSize = True
Me.label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label12.ForeColor = System.Drawing.Color.Red
Me.label12.Location = New System.Drawing.Point(6, 10)
Me.label12.Name = "label12"
Me.label12.Size = New System.Drawing.Size(71, 13)
Me.label12.TabIndex = 19
Me.label12.Text = "Printer Name:"
'
'_grpImgInfo
'
Me._grpImgInfo.Controls.Add(Me._tbDicomInfo)
Me._grpImgInfo.Dock = System.Windows.Forms.DockStyle.Fill
Me._grpImgInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me._grpImgInfo.Location = New System.Drawing.Point(286, 6)
Me._grpImgInfo.Name = "_grpImgInfo"
Me._tbTableLayout.SetRowSpan(Me._grpImgInfo, 2)
Me._grpImgInfo.Size = New System.Drawing.Size(410, 509)
Me._grpImgInfo.TabIndex = 14
Me._grpImgInfo.TabStop = False
Me._grpImgInfo.Text = "Populate Image Information From:"
'
'_tbDicomInfo
'
Me._tbDicomInfo.AllowDrop = True
Me._tbDicomInfo.Controls.Add(Me._pageDataSet)
Me._tbDicomInfo.Controls.Add(Me._pageSCPQuery)
Me._tbDicomInfo.Controls.Add(Me._pageMWLQuery)
Me._tbDicomInfo.Dock = System.Windows.Forms.DockStyle.Fill
Me._tbDicomInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me._tbDicomInfo.Location = New System.Drawing.Point(3, 16)
Me._tbDicomInfo.Name = "_tbDicomInfo"
Me._tbDicomInfo.SelectedIndex = 0
Me._tbDicomInfo.Size = New System.Drawing.Size(404, 490)
Me._tbDicomInfo.TabIndex = 9
'
'_pageDataSet
'
Me._pageDataSet.Controls.Add(Me._tbOpenDataSet)
Me._pageDataSet.Location = New System.Drawing.Point(4, 22)
Me._pageDataSet.Name = "_pageDataSet"
Me._pageDataSet.Padding = New System.Windows.Forms.Padding(3)
Me._pageDataSet.Size = New System.Drawing.Size(396, 464)
Me._pageDataSet.TabIndex = 1
Me._pageDataSet.Text = "Existing DICOM DataSet"
Me._pageDataSet.UseVisualStyleBackColor = True
'
'_tbOpenDataSet
'
Me._tbOpenDataSet.ColumnCount = 2
Me._tbOpenDataSet.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
Me._tbOpenDataSet.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78.0!))
Me._tbOpenDataSet.Controls.Add(Me.label10, 1, 0)
Me._tbOpenDataSet.Controls.Add(Me.groupBox4, 0, 0)
Me._tbOpenDataSet.Controls.Add(Me.panel8, 1, 5)
Me._tbOpenDataSet.Controls.Add(Me.panel7, 1, 3)
Me._tbOpenDataSet.Controls.Add(Me.label6, 0, 4)
Me._tbOpenDataSet.Controls.Add(Me._lstDSStudies, 0, 5)
Me._tbOpenDataSet.Controls.Add(Me._lstDSPatient, 0, 3)
Me._tbOpenDataSet.Controls.Add(Me.label8, 0, 2)
Me._tbOpenDataSet.Controls.Add(Me.label15, 0, 1)
Me._tbOpenDataSet.Dock = System.Windows.Forms.DockStyle.Fill
Me._tbOpenDataSet.Location = New System.Drawing.Point(3, 3)
Me._tbOpenDataSet.Name = "_tbOpenDataSet"
Me._tbOpenDataSet.RowCount = 6
Me._tbOpenDataSet.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
Me._tbOpenDataSet.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
Me._tbOpenDataSet.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
Me._tbOpenDataSet.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
Me._tbOpenDataSet.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
Me._tbOpenDataSet.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
Me._tbOpenDataSet.Size = New System.Drawing.Size(390, 458)
Me._tbOpenDataSet.TabIndex = 11
'
'label10
'
Me.label10.Dock = System.Windows.Forms.DockStyle.Top
Me.label10.Location = New System.Drawing.Point(315, 0)
Me.label10.Name = "label10"
Me.label10.Size = New System.Drawing.Size(72, 16)
Me.label10.TabIndex = 53
Me.label10.Text = "iii) Transfer"
'
'groupBox4
'
Me.groupBox4.Controls.Add(Me._txtDataSet)
Me.groupBox4.Controls.Add(Me._btnBrowseDataSet)
Me.groupBox4.Dock = System.Windows.Forms.DockStyle.Top
Me.groupBox4.Location = New System.Drawing.Point(3, 3)
Me.groupBox4.Name = "groupBox4"
Me.groupBox4.Size = New System.Drawing.Size(306, 44)
Me.groupBox4.TabIndex = 26
Me.groupBox4.TabStop = False
Me.groupBox4.Text = "i) Browse for DataSet"
'
'_txtDataSet
'
Me._txtDataSet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me._txtDataSet.Location = New System.Drawing.Point(89, 18)
Me._txtDataSet.Name = "_txtDataSet"
Me._txtDataSet.Size = New System.Drawing.Size(211, 20)
Me._txtDataSet.TabIndex = 22
'
'_btnBrowseDataSet
'
Me._btnBrowseDataSet.Location = New System.Drawing.Point(6, 16)
Me._btnBrowseDataSet.Name = "_btnBrowseDataSet"
Me._btnBrowseDataSet.Size = New System.Drawing.Size(75, 23)
Me._btnBrowseDataSet.TabIndex = 21
Me._btnBrowseDataSet.Text = "Browse..."
Me._btnBrowseDataSet.UseVisualStyleBackColor = True
'
'panel8
'
Me.panel8.Controls.Add(Me.label19)
Me.panel8.Controls.Add(Me.label14)
Me.panel8.Controls.Add(Me._btnTransferLoadedStudies)
Me.panel8.Dock = System.Windows.Forms.DockStyle.Fill
Me.panel8.Location = New System.Drawing.Point(315, 287)
Me.panel8.Name = "panel8"
Me.panel8.Size = New System.Drawing.Size(72, 168)
Me.panel8.TabIndex = 16
'
'label19
'
Me.label19.Dock = System.Windows.Forms.DockStyle.Top
Me.label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label19.Location = New System.Drawing.Point(0, 0)
Me.label19.Name = "label19"
Me.label19.Size = New System.Drawing.Size(72, 34)
Me.label19.TabIndex = 40
Me.label19.Text = "Transfer Study"
'
'label14
'
Me.label14.AutoSize = True
Me.label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label14.Location = New System.Drawing.Point(22, 37)
Me.label14.Name = "label14"
Me.label14.Size = New System.Drawing.Size(21, 13)
Me.label14.TabIndex = 39
Me.label14.Text = ">>"
'
'_btnTransferLoadedStudies
'
Me._btnTransferLoadedStudies.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me._btnTransferLoadedStudies.Enabled = False
Me._btnTransferLoadedStudies.Image = Global.Resources.TransferStudy
Me._btnTransferLoadedStudies.Location = New System.Drawing.Point(0, 53)
Me._btnTransferLoadedStudies.Name = "_btnTransferLoadedStudies"
Me._btnTransferLoadedStudies.Size = New System.Drawing.Size(70, 59)
Me._btnTransferLoadedStudies.TabIndex = 2
Me._btnTransferLoadedStudies.UseVisualStyleBackColor = True
'
'panel7
'
Me.panel7.Controls.Add(Me.label18)
Me.panel7.Controls.Add(Me.label13)
Me.panel7.Controls.Add(Me._btnTransferLoadedPatient)
Me.panel7.Dock = System.Windows.Forms.DockStyle.Fill
Me.panel7.Location = New System.Drawing.Point(315, 93)
Me.panel7.Name = "panel7"
Me.panel7.Size = New System.Drawing.Size(72, 168)
Me.panel7.TabIndex = 15
'
'label18
'
Me.label18.AutoSize = True
Me.label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label18.Location = New System.Drawing.Point(22, 39)
Me.label18.Name = "label18"
Me.label18.Size = New System.Drawing.Size(21, 13)
Me.label18.TabIndex = 38
Me.label18.Text = ">>"
'
'label13
'
Me.label13.Dock = System.Windows.Forms.DockStyle.Top
Me.label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label13.Location = New System.Drawing.Point(0, 0)
Me.label13.Name = "label13"
Me.label13.Size = New System.Drawing.Size(72, 34)
Me.label13.TabIndex = 36
Me.label13.Text = "Transfer Patient"
'
'_btnTransferLoadedPatient
'
Me._btnTransferLoadedPatient.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me._btnTransferLoadedPatient.Enabled = False
Me._btnTransferLoadedPatient.Image = Global.Resources.TransferPatientInfo
Me._btnTransferLoadedPatient.Location = New System.Drawing.Point(0, 53)
Me._btnTransferLoadedPatient.Name = "_btnTransferLoadedPatient"
Me._btnTransferLoadedPatient.Size = New System.Drawing.Size(70, 60)
Me._btnTransferLoadedPatient.TabIndex = 2
Me._btnTransferLoadedPatient.UseVisualStyleBackColor = True
'
'label6
'
Me.label6.AutoSize = True
Me.label6.BackColor = System.Drawing.Color.DimGray
Me._tbOpenDataSet.SetColumnSpan(Me.label6, 2)
Me.label6.Dock = System.Windows.Forms.DockStyle.Fill
Me.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight
Me.label6.Location = New System.Drawing.Point(3, 264)
Me.label6.Name = "label6"
Me.label6.Size = New System.Drawing.Size(384, 20)
Me.label6.TabIndex = 14
Me.label6.Text = "Studies Found"
Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'_lstDSStudies
'
Me._lstDSStudies.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader12, Me.columnHeader13, Me.columnHeader14, Me.columnHeader15, Me.columnHeader16})
Me._lstDSStudies.Dock = System.Windows.Forms.DockStyle.Fill
Me._lstDSStudies.FullRowSelect = True
Me._lstDSStudies.GridLines = True
Me._lstDSStudies.HideSelection = False
Me._lstDSStudies.Location = New System.Drawing.Point(3, 287)
Me._lstDSStudies.MultiSelect = False
Me._lstDSStudies.Name = "_lstDSStudies"
Me._lstDSStudies.Size = New System.Drawing.Size(306, 168)
Me._lstDSStudies.TabIndex = 12
Me._lstDSStudies.UseCompatibleStateImageBehavior = False
Me._lstDSStudies.View = System.Windows.Forms.View.Details
'
'columnHeader12
'
Me.columnHeader12.Text = "Study Id"
Me.columnHeader12.Width = 90
'
'columnHeader13
'
Me.columnHeader13.Text = "Referring Physician"
Me.columnHeader13.Width = 112
'
'columnHeader14
'
Me.columnHeader14.Text = "Accession Number"
Me.columnHeader14.Width = 151
'
'columnHeader15
'
Me.columnHeader15.Text = "Study Date"
Me.columnHeader15.Width = 111
'
'columnHeader16
'
Me.columnHeader16.Text = "Study Time"
Me.columnHeader16.Width = 137
'
'_lstDSPatient
'
Me._lstDSPatient.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader17, Me.columnHeader18, Me.columnHeader19, Me.columnHeader20})
Me._lstDSPatient.ContextMenuStrip = Me._cmResultQuery
Me._lstDSPatient.Dock = System.Windows.Forms.DockStyle.Fill
Me._lstDSPatient.FullRowSelect = True
Me._lstDSPatient.GridLines = True
Me._lstDSPatient.HideSelection = False
Me._lstDSPatient.Location = New System.Drawing.Point(3, 93)
Me._lstDSPatient.MultiSelect = False
Me._lstDSPatient.Name = "_lstDSPatient"
Me._lstDSPatient.Size = New System.Drawing.Size(306, 168)
Me._lstDSPatient.TabIndex = 11
Me._lstDSPatient.UseCompatibleStateImageBehavior = False
Me._lstDSPatient.View = System.Windows.Forms.View.Details
'
'columnHeader17
'
Me.columnHeader17.Text = "Patient Name"
Me.columnHeader17.Width = 86
'
'columnHeader18
'
Me.columnHeader18.Text = "Patient ID"
Me.columnHeader18.Width = 95
'
'columnHeader19
'
Me.columnHeader19.Text = "Patient Sex"
Me.columnHeader19.Width = 110
'
'columnHeader20
'
Me.columnHeader20.Text = "Birth Date"
Me.columnHeader20.Width = 162
'
'_cmResultQuery
'
Me._cmResultQuery.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miDeleteSelectedDataSet, Me.toolStripSeparator22, Me._miClearResult})
Me._cmResultQuery.Name = "_cmResultQuery"
Me._cmResultQuery.Size = New System.Drawing.Size(155, 54)
'
'_miDeleteSelectedDataSet
'
Me._miDeleteSelectedDataSet.Name = "_miDeleteSelectedDataSet"
Me._miDeleteSelectedDataSet.Size = New System.Drawing.Size(154, 22)
Me._miDeleteSelectedDataSet.Text = "Delete Selected"
'
'toolStripSeparator22
'
Me.toolStripSeparator22.Name = "toolStripSeparator22"
Me.toolStripSeparator22.Size = New System.Drawing.Size(151, 6)
'
'_miClearResult
'
Me._miClearResult.Name = "_miClearResult"
Me._miClearResult.Size = New System.Drawing.Size(154, 22)
Me._miClearResult.Text = "Clear Results"
'
'label8
'
Me.label8.AutoSize = True
Me.label8.BackColor = System.Drawing.Color.DimGray
Me._tbOpenDataSet.SetColumnSpan(Me.label8, 2)
Me.label8.Dock = System.Windows.Forms.DockStyle.Fill
Me.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight
Me.label8.Location = New System.Drawing.Point(3, 70)
Me.label8.Name = "label8"
Me.label8.Size = New System.Drawing.Size(384, 20)
Me.label8.TabIndex = 13
Me.label8.Text = "Patients Found"
Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'label15
'
Me.label15.AutoSize = True
Me.label15.Dock = System.Windows.Forms.DockStyle.Fill
Me.label15.Location = New System.Drawing.Point(3, 50)
Me.label15.Name = "label15"
Me.label15.Size = New System.Drawing.Size(306, 20)
Me.label15.TabIndex = 54
Me.label15.Text = "ii) Select Patient or Study:"
Me.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'_pageSCPQuery
'
Me._pageSCPQuery.Controls.Add(Me._tbQuerySCPList)
Me._pageSCPQuery.Location = New System.Drawing.Point(4, 22)
Me._pageSCPQuery.Name = "_pageSCPQuery"
Me._pageSCPQuery.Padding = New System.Windows.Forms.Padding(3)
Me._pageSCPQuery.Size = New System.Drawing.Size(396, 464)
Me._pageSCPQuery.TabIndex = 0
Me._pageSCPQuery.Text = "PACS"
Me._pageSCPQuery.UseVisualStyleBackColor = True
'
'_tbQuerySCPList
'
Me._tbQuerySCPList.ColumnCount = 3
Me._tbQuerySCPList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
Me._tbQuerySCPList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
Me._tbQuerySCPList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72.0!))
Me._tbQuerySCPList.Controls.Add(Me._grpSCPServers, 1, 1)
Me._tbQuerySCPList.Controls.Add(Me.panel10, 2, 6)
Me._tbQuerySCPList.Controls.Add(Me.panel9, 2, 4)
Me._tbQuerySCPList.Controls.Add(Me.label2, 0, 5)
Me._tbQuerySCPList.Controls.Add(Me._lstSCPStudies, 0, 6)
Me._tbQuerySCPList.Controls.Add(Me._lstSCPPatient, 0, 4)
Me._tbQuerySCPList.Controls.Add(Me._gbSearchParams, 0, 1)
Me._tbQuerySCPList.Controls.Add(Me.label1, 0, 3)
Me._tbQuerySCPList.Controls.Add(Me.label16, 0, 0)
Me._tbQuerySCPList.Controls.Add(Me.label17, 0, 2)
Me._tbQuerySCPList.Controls.Add(Me.label20, 2, 0)
Me._tbQuerySCPList.Dock = System.Windows.Forms.DockStyle.Fill
Me._tbQuerySCPList.Location = New System.Drawing.Point(3, 3)
Me._tbQuerySCPList.Name = "_tbQuerySCPList"
Me._tbQuerySCPList.RowCount = 7
Me._tbQuerySCPList.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
Me._tbQuerySCPList.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
Me._tbQuerySCPList.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
Me._tbQuerySCPList.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
Me._tbQuerySCPList.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
Me._tbQuerySCPList.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
Me._tbQuerySCPList.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
Me._tbQuerySCPList.Size = New System.Drawing.Size(390, 458)
Me._tbQuerySCPList.TabIndex = 10
'
'_grpSCPServers
'
Me._grpSCPServers.Controls.Add(Me._btnSCPQuery)
Me._grpSCPServers.Controls.Add(Me._cbSCPServers)
Me._grpSCPServers.Dock = System.Windows.Forms.DockStyle.Fill
Me._grpSCPServers.Location = New System.Drawing.Point(171, 23)
Me._grpSCPServers.Name = "_grpSCPServers"
Me._grpSCPServers.Size = New System.Drawing.Size(144, 119)
Me._grpSCPServers.TabIndex = 21
Me._grpSCPServers.TabStop = False
Me._grpSCPServers.Text = "Query Servers"
'
'_btnSCPQuery
'
Me._btnSCPQuery.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me._btnSCPQuery.AutoSize = True
Me._btnSCPQuery.Location = New System.Drawing.Point(78, 51)
Me._btnSCPQuery.MaximumSize = New System.Drawing.Size(67, 35)
Me._btnSCPQuery.Name = "_btnSCPQuery"
Me._btnSCPQuery.Size = New System.Drawing.Size(60, 24)
Me._btnSCPQuery.TabIndex = 10
Me._btnSCPQuery.Text = "Query"
Me._btnSCPQuery.UseVisualStyleBackColor = True
'
'_cbSCPServers
'
Me._cbSCPServers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me._cbSCPServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me._cbSCPServers.FormattingEnabled = True
Me._cbSCPServers.Location = New System.Drawing.Point(9, 19)
Me._cbSCPServers.Name = "_cbSCPServers"
Me._cbSCPServers.Size = New System.Drawing.Size(129, 21)
Me._cbSCPServers.TabIndex = 11
'
'panel10
'
Me.panel10.Controls.Add(Me.label23)
Me.panel10.Controls.Add(Me.label24)
Me.panel10.Controls.Add(Me._btnTransferSCPStudies)
Me.panel10.Dock = System.Windows.Forms.DockStyle.Fill
Me.panel10.Location = New System.Drawing.Point(321, 334)
Me.panel10.Name = "panel10"
Me.panel10.Size = New System.Drawing.Size(66, 121)
Me.panel10.TabIndex = 20
'
'label23
'
Me.label23.Dock = System.Windows.Forms.DockStyle.Top
Me.label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label23.Location = New System.Drawing.Point(0, 0)
Me.label23.Name = "label23"
Me.label23.Size = New System.Drawing.Size(66, 34)
Me.label23.TabIndex = 60
Me.label23.Text = "Transfer Study"
'
'label24
'
Me.label24.AutoSize = True
Me.label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label24.Location = New System.Drawing.Point(20, 40)
Me.label24.Name = "label24"
Me.label24.Size = New System.Drawing.Size(21, 13)
Me.label24.TabIndex = 59
Me.label24.Text = ">>"
'
'_btnTransferSCPStudies
'
Me._btnTransferSCPStudies.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me._btnTransferSCPStudies.Enabled = False
Me._btnTransferSCPStudies.Image = Global.Resources.TransferStudy
Me._btnTransferSCPStudies.Location = New System.Drawing.Point(3, 56)
Me._btnTransferSCPStudies.Name = "_btnTransferSCPStudies"
Me._btnTransferSCPStudies.Size = New System.Drawing.Size(60, 38)
Me._btnTransferSCPStudies.TabIndex = 2
Me._btnTransferSCPStudies.UseVisualStyleBackColor = True
'
'panel9
'
Me.panel9.Controls.Add(Me.label21)
Me.panel9.Controls.Add(Me.label22)
Me.panel9.Controls.Add(Me._btnTransferSCPPatient)
Me.panel9.Dock = System.Windows.Forms.DockStyle.Fill
Me.panel9.Location = New System.Drawing.Point(321, 188)
Me.panel9.Name = "panel9"
Me.panel9.Size = New System.Drawing.Size(66, 120)
Me.panel9.TabIndex = 16
'
'label21
'
Me.label21.AutoSize = True
Me.label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label21.Location = New System.Drawing.Point(20, 40)
Me.label21.Name = "label21"
Me.label21.Size = New System.Drawing.Size(21, 13)
Me.label21.TabIndex = 59
Me.label21.Text = ">>"
'
'label22
'
Me.label22.Dock = System.Windows.Forms.DockStyle.Top
Me.label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label22.Location = New System.Drawing.Point(0, 0)
Me.label22.Name = "label22"
Me.label22.Size = New System.Drawing.Size(66, 34)
Me.label22.TabIndex = 58
Me.label22.Text = "Transfer Patient"
'
'_btnTransferSCPPatient
'
Me._btnTransferSCPPatient.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me._btnTransferSCPPatient.Enabled = False
Me._btnTransferSCPPatient.Image = Global.Resources.TransferPatientInfo
Me._btnTransferSCPPatient.Location = New System.Drawing.Point(3, 56)
Me._btnTransferSCPPatient.Name = "_btnTransferSCPPatient"
Me._btnTransferSCPPatient.Size = New System.Drawing.Size(60, 38)
Me._btnTransferSCPPatient.TabIndex = 2
Me._btnTransferSCPPatient.UseVisualStyleBackColor = True
'
'label2
'
Me.label2.AutoSize = True
Me.label2.BackColor = System.Drawing.Color.DimGray
Me._tbQuerySCPList.SetColumnSpan(Me.label2, 3)
Me.label2.Dock = System.Windows.Forms.DockStyle.Fill
Me.label2.ForeColor = System.Drawing.Color.White
Me.label2.Location = New System.Drawing.Point(3, 311)
Me.label2.Name = "label2"
Me.label2.Size = New System.Drawing.Size(384, 20)
Me.label2.TabIndex = 14
Me.label2.Text = "Studies Found"
Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'_lstSCPStudies
'
Me._lstSCPStudies.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._columnHeader7, Me._columnHeader8, Me._columnHeader9, Me._columnHeader10, Me._columnHeader11})
Me._tbQuerySCPList.SetColumnSpan(Me._lstSCPStudies, 2)
Me._lstSCPStudies.ContextMenuStrip = Me._cmResultQuery
Me._lstSCPStudies.Dock = System.Windows.Forms.DockStyle.Fill
Me._lstSCPStudies.FullRowSelect = True
Me._lstSCPStudies.GridLines = True
Me._lstSCPStudies.HideSelection = False
Me._lstSCPStudies.Location = New System.Drawing.Point(3, 334)
Me._lstSCPStudies.MultiSelect = False
Me._lstSCPStudies.Name = "_lstSCPStudies"
Me._lstSCPStudies.Size = New System.Drawing.Size(312, 121)
Me._lstSCPStudies.TabIndex = 12
Me._lstSCPStudies.UseCompatibleStateImageBehavior = False
Me._lstSCPStudies.View = System.Windows.Forms.View.Details
'
'_columnHeader7
'
Me._columnHeader7.Text = "Study Id"
Me._columnHeader7.Width = 120
'
'_columnHeader8
'
Me._columnHeader8.Text = "Referring Physician"
Me._columnHeader8.Width = 123
'
'_columnHeader9
'
Me._columnHeader9.Text = "Accession Number"
Me._columnHeader9.Width = 114
'
'_columnHeader10
'
Me._columnHeader10.Text = "Study Date"
Me._columnHeader10.Width = 115
'
'_columnHeader11
'
Me._columnHeader11.Text = "Study Time"
Me._columnHeader11.Width = 128
'
'_lstSCPPatient
'
Me._lstSCPPatient.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._columnHeader1, Me._columnHeader2, Me._columnHeader3, Me._columnHeader4})
Me._tbQuerySCPList.SetColumnSpan(Me._lstSCPPatient, 2)
Me._lstSCPPatient.ContextMenuStrip = Me._cmResultQuery
Me._lstSCPPatient.Dock = System.Windows.Forms.DockStyle.Fill
Me._lstSCPPatient.FullRowSelect = True
Me._lstSCPPatient.GridLines = True
Me._lstSCPPatient.HideSelection = False
Me._lstSCPPatient.Location = New System.Drawing.Point(3, 188)
Me._lstSCPPatient.MultiSelect = False
Me._lstSCPPatient.Name = "_lstSCPPatient"
Me._lstSCPPatient.Size = New System.Drawing.Size(312, 120)
Me._lstSCPPatient.TabIndex = 11
Me._lstSCPPatient.UseCompatibleStateImageBehavior = False
Me._lstSCPPatient.View = System.Windows.Forms.View.Details
'
'_columnHeader1
'
Me._columnHeader1.Text = "Patient Name"
Me._columnHeader1.Width = 90
'
'_columnHeader2
'
Me._columnHeader2.Text = "Patient ID"
Me._columnHeader2.Width = 104
'
'_columnHeader3
'
Me._columnHeader3.Text = "Patient Sex"
Me._columnHeader3.Width = 118
'
'_columnHeader4
'
Me._columnHeader4.Text = "Birth Date"
Me._columnHeader4.Width = 89
'
'_gbSearchParams
'
Me._gbSearchParams.Controls.Add(Me._pgSearchSCP)
Me._gbSearchParams.Dock = System.Windows.Forms.DockStyle.Fill
Me._gbSearchParams.Location = New System.Drawing.Point(3, 23)
Me._gbSearchParams.Name = "_gbSearchParams"
Me._gbSearchParams.Size = New System.Drawing.Size(162, 119)
Me._gbSearchParams.TabIndex = 9
Me._gbSearchParams.TabStop = False
Me._gbSearchParams.Text = "Search Params"
'
'_pgSearchSCP
'
Me._pgSearchSCP.ContextMenuStrip = Me._cnmnuClearSearch
Me._pgSearchSCP.Cursor = System.Windows.Forms.Cursors.HSplit
Me._pgSearchSCP.Dock = System.Windows.Forms.DockStyle.Fill
Me._pgSearchSCP.HelpVisible = False
Me._pgSearchSCP.Location = New System.Drawing.Point(3, 16)
Me._pgSearchSCP.Name = "_pgSearchSCP"
Me._pgSearchSCP.PropertySort = System.Windows.Forms.PropertySort.NoSort
Me._pgSearchSCP.Size = New System.Drawing.Size(156, 100)
Me._pgSearchSCP.TabIndex = 9
Me._pgSearchSCP.ToolbarVisible = False
'
'_cnmnuClearSearch
'
Me._cnmnuClearSearch.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miClearSearch})
Me._cnmnuClearSearch.Name = "_cnmnuDicomInfo"
Me._cnmnuClearSearch.Size = New System.Drawing.Size(102, 26)
'
'_miClearSearch
'
Me._miClearSearch.Name = "_miClearSearch"
Me._miClearSearch.Size = New System.Drawing.Size(101, 22)
Me._miClearSearch.Text = "Clear"
'
'label1
'
Me.label1.AutoSize = True
Me.label1.BackColor = System.Drawing.Color.DimGray
Me._tbQuerySCPList.SetColumnSpan(Me.label1, 3)
Me.label1.Dock = System.Windows.Forms.DockStyle.Fill
Me.label1.ForeColor = System.Drawing.Color.White
Me.label1.Location = New System.Drawing.Point(3, 165)
Me.label1.Name = "label1"
Me.label1.Size = New System.Drawing.Size(384, 20)
Me.label1.TabIndex = 13
Me.label1.Text = "Patients Found"
Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'label16
'
Me.label16.AutoSize = True
Me.label16.Dock = System.Windows.Forms.DockStyle.Fill
Me.label16.Location = New System.Drawing.Point(3, 0)
Me.label16.Name = "label16"
Me.label16.Size = New System.Drawing.Size(162, 20)
Me.label16.TabIndex = 22
Me.label16.Text = "i) Query PACS"
'
'label17
'
Me.label17.AutoSize = True
Me.label17.Dock = System.Windows.Forms.DockStyle.Fill
Me.label17.Location = New System.Drawing.Point(3, 145)
Me.label17.Name = "label17"
Me.label17.Size = New System.Drawing.Size(162, 20)
Me.label17.TabIndex = 23
Me.label17.Text = "ii) Select Patient or Study:"
Me.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'label20
'
Me.label20.AutoSize = True
Me.label20.Dock = System.Windows.Forms.DockStyle.Top
Me.label20.Location = New System.Drawing.Point(321, 0)
Me.label20.Name = "label20"
Me.label20.Size = New System.Drawing.Size(66, 13)
Me.label20.TabIndex = 24
Me.label20.Text = "iii) Transfer"
Me.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'_pageMWLQuery
'
Me._pageMWLQuery.Controls.Add(Me._tbQueryMWList)
Me._pageMWLQuery.Location = New System.Drawing.Point(4, 22)
Me._pageMWLQuery.Name = "_pageMWLQuery"
Me._pageMWLQuery.Padding = New System.Windows.Forms.Padding(3)
Me._pageMWLQuery.Size = New System.Drawing.Size(398, 464)
Me._pageMWLQuery.TabIndex = 2
Me._pageMWLQuery.Text = "Modality Work List "
Me._pageMWLQuery.UseVisualStyleBackColor = True
'
'_tbQueryMWList
'
Me._tbQueryMWList.ColumnCount = 3
Me._tbQueryMWList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
Me._tbQueryMWList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
Me._tbQueryMWList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72.0!))
Me._tbQueryMWList.Controls.Add(Me._toolStripMWLSearch, 0, 1)
Me._tbQueryMWList.Controls.Add(Me._grpMWLQuery, 1, 2)
Me._tbQueryMWList.Controls.Add(Me.panel12, 2, 5)
Me._tbQueryMWList.Controls.Add(Me._lstMWLItems, 0, 5)
Me._tbQueryMWList.Controls.Add(Me._gbMWLSearch, 0, 2)
Me._tbQueryMWList.Controls.Add(Me.label11, 0, 4)
Me._tbQueryMWList.Controls.Add(Me.label25, 0, 0)
Me._tbQueryMWList.Controls.Add(Me.label26, 0, 3)
Me._tbQueryMWList.Controls.Add(Me.label27, 2, 0)
Me._tbQueryMWList.Dock = System.Windows.Forms.DockStyle.Fill
Me._tbQueryMWList.Location = New System.Drawing.Point(3, 3)
Me._tbQueryMWList.Name = "_tbQueryMWList"
Me._tbQueryMWList.RowCount = 6
Me._tbQueryMWList.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
Me._tbQueryMWList.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
Me._tbQueryMWList.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
Me._tbQueryMWList.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
Me._tbQueryMWList.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
Me._tbQueryMWList.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
Me._tbQueryMWList.Size = New System.Drawing.Size(392, 458)
Me._tbQueryMWList.TabIndex = 11
'
'_toolStripMWLSearch
'
Me._tbQueryMWList.SetColumnSpan(Me._toolStripMWLSearch, 3)
Me._toolStripMWLSearch.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._toolBtnPatient, Me._toolLblMWLType})
Me._toolStripMWLSearch.Location = New System.Drawing.Point(0, 20)
Me._toolStripMWLSearch.Name = "_toolStripMWLSearch"
Me._toolStripMWLSearch.Size = New System.Drawing.Size(392, 25)
Me._toolStripMWLSearch.TabIndex = 18
Me._toolStripMWLSearch.Text = "toolStrip2"
'
'_toolBtnPatient
'
Me._toolBtnPatient.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me._toolBtnPatient.Image = CType(resources.GetObject("_toolBtnPatient.Image"), System.Drawing.Image)
Me._toolBtnPatient.ImageTransparentColor = System.Drawing.Color.Magenta
Me._toolBtnPatient.Name = "_toolBtnPatient"
Me._toolBtnPatient.Size = New System.Drawing.Size(23, 22)
Me._toolBtnPatient.Text = "Edit Dataset"
'
'_toolLblMWLType
'
Me._toolLblMWLType.Name = "_toolLblMWLType"
Me._toolLblMWLType.Size = New System.Drawing.Size(110, 22)
Me._toolLblMWLType.Text = "Broad Based Search"
'
'_grpMWLQuery
'
Me._grpMWLQuery.Controls.Add(Me._btnMWLQuery)
Me._grpMWLQuery.Controls.Add(Me._cbMWLServers)
Me._grpMWLQuery.Dock = System.Windows.Forms.DockStyle.Fill
Me._grpMWLQuery.Location = New System.Drawing.Point(173, 48)
Me._grpMWLQuery.Name = "_grpMWLQuery"
Me._grpMWLQuery.Size = New System.Drawing.Size(144, 144)
Me._grpMWLQuery.TabIndex = 17
Me._grpMWLQuery.TabStop = False
Me._grpMWLQuery.Text = "Query Servers"
'
'_btnMWLQuery
'
Me._btnMWLQuery.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me._btnMWLQuery.AutoSize = True
Me._btnMWLQuery.Location = New System.Drawing.Point(78, 46)
Me._btnMWLQuery.MaximumSize = New System.Drawing.Size(67, 35)
Me._btnMWLQuery.Name = "_btnMWLQuery"
Me._btnMWLQuery.Size = New System.Drawing.Size(60, 24)
Me._btnMWLQuery.TabIndex = 10
Me._btnMWLQuery.Text = "Query"
Me._btnMWLQuery.UseVisualStyleBackColor = True
'
'_cbMWLServers
'
Me._cbMWLServers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me._cbMWLServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me._cbMWLServers.FormattingEnabled = True
Me._cbMWLServers.Location = New System.Drawing.Point(9, 19)
Me._cbMWLServers.Name = "_cbMWLServers"
Me._cbMWLServers.Size = New System.Drawing.Size(129, 21)
Me._cbMWLServers.TabIndex = 11
'
'panel12
'
Me.panel12.Controls.Add(Me.label28)
Me.panel12.Controls.Add(Me.label29)
Me.panel12.Controls.Add(Me._btnTransferMWL)
Me.panel12.Dock = System.Windows.Forms.DockStyle.Fill
Me.panel12.Location = New System.Drawing.Point(323, 238)
Me.panel12.Name = "panel12"
Me.panel12.Size = New System.Drawing.Size(66, 217)
Me.panel12.TabIndex = 16
'
'label28
'
Me.label28.Dock = System.Windows.Forms.DockStyle.Top
Me.label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label28.Location = New System.Drawing.Point(0, 0)
Me.label28.Name = "label28"
Me.label28.Size = New System.Drawing.Size(66, 49)
Me.label28.TabIndex = 58
Me.label28.Text = "Transfer Patient And Study"
'
'label29
'
Me.label29.AutoSize = True
Me.label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label29.Location = New System.Drawing.Point(21, 49)
Me.label29.Name = "label29"
Me.label29.Size = New System.Drawing.Size(21, 13)
Me.label29.TabIndex = 57
Me.label29.Text = ">>"
'
'_btnTransferMWL
'
Me._btnTransferMWL.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me._btnTransferMWL.Enabled = False
Me._btnTransferMWL.Image = Global.Resources.TransferWorkItem
Me._btnTransferMWL.Location = New System.Drawing.Point(0, 75)
Me._btnTransferMWL.Name = "_btnTransferMWL"
Me._btnTransferMWL.Size = New System.Drawing.Size(64, 54)
Me._btnTransferMWL.TabIndex = 2
Me._btnTransferMWL.UseVisualStyleBackColor = True
'
'_lstMWLItems
'
Me._lstMWLItems.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader26, Me.columnHeader27, Me.columnHeader28, Me.columnHeader29, Me.columnHeader21, Me.columnHeader22, Me.columnHeader23, Me.columnHeader24, Me.columnHeader25, Me.columnHeader30})
Me._tbQueryMWList.SetColumnSpan(Me._lstMWLItems, 2)
Me._lstMWLItems.ContextMenuStrip = Me._cmResultQuery
Me._lstMWLItems.Dock = System.Windows.Forms.DockStyle.Fill
Me._lstMWLItems.FullRowSelect = True
Me._lstMWLItems.GridLines = True
Me._lstMWLItems.HideSelection = False
Me._lstMWLItems.Location = New System.Drawing.Point(3, 238)
Me._lstMWLItems.MultiSelect = False
Me._lstMWLItems.Name = "_lstMWLItems"
Me._lstMWLItems.Size = New System.Drawing.Size(314, 217)
Me._lstMWLItems.TabIndex = 11
Me._lstMWLItems.UseCompatibleStateImageBehavior = False
Me._lstMWLItems.View = System.Windows.Forms.View.Details
'
'columnHeader26
'
Me.columnHeader26.Text = "Accession Number"
Me.columnHeader26.Width = 90
'
'columnHeader27
'
Me.columnHeader27.Text = "Patient ID"
Me.columnHeader27.Width = 104
'
'columnHeader28
'
Me.columnHeader28.Text = "Patient Name"
Me.columnHeader28.Width = 118
'
'columnHeader29
'
Me.columnHeader29.Text = "Birth Date"
Me.columnHeader29.Width = 89
'
'columnHeader21
'
Me.columnHeader21.Text = "Gender"
'
'columnHeader22
'
Me.columnHeader22.Text = "Scheduled Start Date"
'
'columnHeader23
'
Me.columnHeader23.Text = "Modality"
'
'columnHeader24
'
Me.columnHeader24.Text = "Scheduled Station AE"
'
'columnHeader25
'
Me.columnHeader25.Text = "Scheduled Procedure Step Description"
'
'columnHeader30
'
Me.columnHeader30.Text = "Requested Procedure ID"
'
'_gbMWLSearch
'
Me._gbMWLSearch.Controls.Add(Me._pgSearchMWL)
Me._gbMWLSearch.Dock = System.Windows.Forms.DockStyle.Fill
Me._gbMWLSearch.Location = New System.Drawing.Point(3, 48)
Me._gbMWLSearch.Name = "_gbMWLSearch"
Me._gbMWLSearch.Size = New System.Drawing.Size(164, 144)
Me._gbMWLSearch.TabIndex = 9
Me._gbMWLSearch.TabStop = False
Me._gbMWLSearch.Text = "Search Params"
'
'_pgSearchMWL
'
Me._pgSearchMWL.ContextMenuStrip = Me._cnmnuClearSearch
Me._pgSearchMWL.Cursor = System.Windows.Forms.Cursors.HSplit
Me._pgSearchMWL.Dock = System.Windows.Forms.DockStyle.Fill
Me._pgSearchMWL.HelpVisible = False
Me._pgSearchMWL.Location = New System.Drawing.Point(3, 16)
Me._pgSearchMWL.Name = "_pgSearchMWL"
Me._pgSearchMWL.PropertySort = System.Windows.Forms.PropertySort.NoSort
Me._pgSearchMWL.Size = New System.Drawing.Size(158, 125)
Me._pgSearchMWL.TabIndex = 9
Me._pgSearchMWL.ToolbarVisible = False
'
'label11
'
Me.label11.AutoSize = True
Me.label11.BackColor = System.Drawing.Color.DimGray
Me._tbQueryMWList.SetColumnSpan(Me.label11, 3)
Me.label11.Dock = System.Windows.Forms.DockStyle.Fill
Me.label11.ForeColor = System.Drawing.Color.White
Me.label11.Location = New System.Drawing.Point(3, 215)
Me.label11.Name = "label11"
Me.label11.Size = New System.Drawing.Size(386, 20)
Me.label11.TabIndex = 13
Me.label11.Text = "Patients Found"
Me.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'label25
'
Me.label25.AutoSize = True
Me.label25.Dock = System.Windows.Forms.DockStyle.Fill
Me.label25.Location = New System.Drawing.Point(3, 0)
Me.label25.Name = "label25"
Me.label25.Size = New System.Drawing.Size(164, 20)
Me.label25.TabIndex = 19
Me.label25.Text = "i) Query Work List"
Me.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'label26
'
Me.label26.AutoSize = True
Me.label26.Dock = System.Windows.Forms.DockStyle.Fill
Me.label26.Location = New System.Drawing.Point(3, 195)
Me.label26.Name = "label26"
Me.label26.Size = New System.Drawing.Size(164, 20)
Me.label26.TabIndex = 20
Me.label26.Text = "ii) Select Patient:"
Me.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'label27
'
Me.label27.AutoSize = True
Me.label27.Dock = System.Windows.Forms.DockStyle.Fill
Me.label27.Location = New System.Drawing.Point(323, 0)
Me.label27.Name = "label27"
Me.label27.Size = New System.Drawing.Size(66, 20)
Me.label27.TabIndex = 21
Me.label27.Text = "iii) Transfer"
Me.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'_grpStoreServers
'
Me._grpStoreServers.Controls.Add(Me._btnPACSSettings)
Me._grpStoreServers.Controls.Add(Me._btnPushToPACS)
Me._grpStoreServers.Controls.Add(Me._cbStoreServers)
Me._grpStoreServers.Controls.Add(Me.label9)
Me._grpStoreServers.Dock = System.Windows.Forms.DockStyle.Fill
Me._grpStoreServers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me._grpStoreServers.Location = New System.Drawing.Point(705, 6)
Me._grpStoreServers.Name = "_grpStoreServers"
Me._grpStoreServers.Size = New System.Drawing.Size(303, 74)
Me._grpStoreServers.TabIndex = 15
Me._grpStoreServers.TabStop = False
Me._grpStoreServers.Text = "Push To PACS"
'
'_btnPACSSettings
'
Me._btnPACSSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me._btnPACSSettings.Location = New System.Drawing.Point(14, 46)
Me._btnPACSSettings.Name = "_btnPACSSettings"
Me._btnPACSSettings.Size = New System.Drawing.Size(98, 24)
Me._btnPACSSettings.TabIndex = 14
Me._btnPACSSettings.Text = "PACS Settings..."
Me._btnPACSSettings.UseVisualStyleBackColor = True
'
'_btnPushToPACS
'
Me._btnPushToPACS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me._btnPushToPACS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me._btnPushToPACS.Location = New System.Drawing.Point(194, 46)
Me._btnPushToPACS.Name = "_btnPushToPACS"
Me._btnPushToPACS.Size = New System.Drawing.Size(98, 24)
Me._btnPushToPACS.TabIndex = 13
Me._btnPushToPACS.Text = "Push To PACS"
Me._btnPushToPACS.UseVisualStyleBackColor = True
'
'_cbStoreServers
'
Me._cbStoreServers.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me._cbStoreServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me._cbStoreServers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me._cbStoreServers.FormattingEnabled = True
Me._cbStoreServers.Location = New System.Drawing.Point(93, 18)
Me._cbStoreServers.Name = "_cbStoreServers"
Me._cbStoreServers.Size = New System.Drawing.Size(199, 21)
Me._cbStoreServers.TabIndex = 12
'
'label9
'
Me.label9.AutoSize = True
Me.label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label9.Location = New System.Drawing.Point(11, 21)
Me.label9.Name = "label9"
Me.label9.Size = New System.Drawing.Size(74, 13)
Me.label9.TabIndex = 11
Me.label9.Text = "PACS Archive"
'
'_panelImageList
'
Me._panelImageList.Dock = System.Windows.Forms.DockStyle.Fill
Me._panelImageList.Location = New System.Drawing.Point(3, 532)
Me._panelImageList.Name = "_panelImageList"
Me._panelImageList.Size = New System.Drawing.Size(708, 150)
Me._panelImageList.TabIndex = 11
'
'_cnmnuClearDicom
'
Me._cnmnuClearDicom.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miClearPG})
Me._cnmnuClearDicom.Name = "_cnmnuDicomInfo"
Me._cnmnuClearDicom.Size = New System.Drawing.Size(102, 26)
'
'_miClearPG
'
Me._miClearPG.Name = "_miClearPG"
Me._miClearPG.Size = New System.Drawing.Size(101, 22)
Me._miClearPG.Text = "Clear"
'
'_clmnPNMWL
'
Me._clmnPNMWL.HeaderText = "Patient Name"
Me._clmnPNMWL.Name = "_clmnPNMWL"
Me._clmnPNMWL.ReadOnly = True
'
'_clmnANMWL
'
Me._clmnANMWL.HeaderText = "Accession Number"
Me._clmnANMWL.Name = "_clmnANMWL"
Me._clmnANMWL.ReadOnly = True
'
'_clmnPIDMWL
'
Me._clmnPIDMWL.HeaderText = "Patient ID"
Me._clmnPIDMWL.Name = "_clmnPIDMWL"
Me._clmnPIDMWL.ReadOnly = True
'
'_clmnSSAEMWL
'
Me._clmnSSAEMWL.HeaderText = "Scheduled Station AE"
Me._clmnSSAEMWL.Name = "_clmnSSAEMWL"
Me._clmnSSAEMWL.ReadOnly = True
'
'_clmnSSMWL
'
Me._clmnSSMWL.HeaderText = "Scheduled Start Date"
Me._clmnSSMWL.Name = "_clmnSSMWL"
Me._clmnSSMWL.ReadOnly = True
'
'_clmnBDMWL
'
Me._clmnBDMWL.HeaderText = "Birth Date"
Me._clmnBDMWL.Name = "_clmnBDMWL"
Me._clmnBDMWL.ReadOnly = True
'
'_clmnGMWL
'
Me._clmnGMWL.HeaderText = "Gender"
Me._clmnGMWL.Name = "_clmnGMWL"
Me._clmnGMWL.ReadOnly = True
'
'_clmnSPRrocMWL
'
Me._clmnSPRrocMWL.HeaderText = "Scheduled Procedure Step Description"
Me._clmnSPRrocMWL.Name = "_clmnSPRrocMWL"
Me._clmnSPRrocMWL.ReadOnly = True
'
'_clmnMODMWL
'
Me._clmnMODMWL.HeaderText = "Modality"
Me._clmnMODMWL.Name = "_clmnMODMWL"
Me._clmnMODMWL.ReadOnly = True
'
'_gbRecognized
'
Me._gbRecognized.Dock = System.Windows.Forms.DockStyle.Fill
Me._gbRecognized.Location = New System.Drawing.Point(232, 272)
Me._gbRecognized.Name = "_gbRecognized"
Me._gbRecognized.Size = New System.Drawing.Size(394, 109)
Me._gbRecognized.TabIndex = 8
Me._gbRecognized.TabStop = False
Me._gbRecognized.Text = "Recognized Text"
'
'label3
'
Me.label3.AutoSize = True
Me.label3.Dock = System.Windows.Forms.DockStyle.Top
Me.label3.Location = New System.Drawing.Point(3, 406)
Me.label3.Name = "label3"
Me.label3.Size = New System.Drawing.Size(544, 13)
Me.label3.TabIndex = 14
Me.label3.Text = "Studies Found"
'
'listView1
'
Me.listView1.Location = New System.Drawing.Point(0, 0)
Me.listView1.Name = "listView1"
Me.listView1.Size = New System.Drawing.Size(121, 97)
Me.listView1.TabIndex = 0
Me.listView1.UseCompatibleStateImageBehavior = False
'
'columnHeader1
'
Me.columnHeader1.Text = "Date"
'
'columnHeader2
'
Me.columnHeader2.Text = "Series Number"
'
'columnHeader3
'
Me.columnHeader3.Text = "Description"
'
'columnHeader4
'
Me.columnHeader4.Text = "Modality"
'
'columnHeader5
'
Me.columnHeader5.Text = "Number of Instances"
'
'listView2
'
Me.listView2.Location = New System.Drawing.Point(0, 0)
Me.listView2.Name = "listView2"
Me.listView2.Size = New System.Drawing.Size(121, 97)
Me.listView2.TabIndex = 0
Me.listView2.UseCompatibleStateImageBehavior = False
'
'columnHeader6
'
Me.columnHeader6.Text = "Patient Name"
Me.columnHeader6.Width = 6
'
'columnHeader7
'
Me.columnHeader7.Text = "Patient ID"
Me.columnHeader7.Width = 12
'
'columnHeader8
'
Me.columnHeader8.Text = "Accession Number"
Me.columnHeader8.Width = 12
'
'columnHeader9
'
Me.columnHeader9.Text = "Study Date"
'
'columnHeader10
'
Me.columnHeader10.Text = "Referring Physicians Name"
'
'columnHeader11
'
Me.columnHeader11.Text = "Description"
'
'panel2
'
Me.panel2.Controls.Add(Me.button1)
Me.panel2.Dock = System.Windows.Forms.DockStyle.Fill
Me.panel2.Location = New System.Drawing.Point(553, 3)
Me.panel2.Name = "panel2"
Me.panel2.Size = New System.Drawing.Size(138, 24)
Me.panel2.TabIndex = 9
'
'button1
'
Me.button1.Location = New System.Drawing.Point(0, 0)
Me.button1.Name = "button1"
Me.button1.Size = New System.Drawing.Size(75, 23)
Me.button1.TabIndex = 0
'
'groupBox1
'
Me.groupBox1.Location = New System.Drawing.Point(0, 0)
Me.groupBox1.Name = "groupBox1"
Me.groupBox1.Size = New System.Drawing.Size(200, 100)
Me.groupBox1.TabIndex = 0
Me.groupBox1.TabStop = False
'
'propertyGrid1
'
Me.propertyGrid1.Location = New System.Drawing.Point(0, 0)
Me.propertyGrid1.Name = "propertyGrid1"
Me.propertyGrid1.Size = New System.Drawing.Size(130, 130)
Me.propertyGrid1.TabIndex = 0
'
'panel3
'
Me.panel3.Controls.Add(Me.comboBox1)
Me.panel3.Controls.Add(Me.label4)
Me.panel3.Dock = System.Windows.Forms.DockStyle.Fill
Me.panel3.Location = New System.Drawing.Point(3, 3)
Me.panel3.Name = "panel3"
Me.panel3.Size = New System.Drawing.Size(544, 24)
Me.panel3.TabIndex = 10
'
'comboBox1
'
Me.comboBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.comboBox1.FormattingEnabled = True
Me.comboBox1.Location = New System.Drawing.Point(78, 3)
Me.comboBox1.Name = "comboBox1"
Me.comboBox1.Size = New System.Drawing.Size(463, 21)
Me.comboBox1.TabIndex = 9
'
'label4
'
Me.label4.AutoSize = True
Me.label4.Location = New System.Drawing.Point(3, 6)
Me.label4.Name = "label4"
Me.label4.Size = New System.Drawing.Size(69, 13)
Me.label4.TabIndex = 8
Me.label4.Text = "Query Server"
'
'label5
'
Me.label5.AutoSize = True
Me.label5.Dock = System.Windows.Forms.DockStyle.Top
Me.label5.Location = New System.Drawing.Point(3, 249)
Me.label5.Name = "label5"
Me.label5.Size = New System.Drawing.Size(544, 13)
Me.label5.TabIndex = 13
Me.label5.Text = "Patients Found"
'
'_toolbarMain
'
Me._toolbarMain.ImageScalingSize = New System.Drawing.Size(24, 24)
Me._toolbarMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._toolBtnOpenRaster, Me.toolStripSeparator23, Me._toolBtnStoreToPacs, Me._toolBtnSaveDicom, Me.toolStripSeparator4, Me._toolBtnCLearInfo, Me.toolStripSeparator5, Me._toolBtnDeleteAll, Me._toolBtnDeleteSelected, Me.toolStripSeparator6, Me._toolBtnTwain, Me._toolBtnWia, Me.toolStripSeparator21, Me._toolBtnRotate, Me.toolStripSeparator24, Me._toolBtnScreenCapture, Me.toolStripSeparator20, Me._toolBtnViewLog, Me.toolStripSeparator7, Me._toolBtnSettings, Me.toolStripSeparator8, Me._toolBtnHelp})
Me._toolbarMain.Location = New System.Drawing.Point(0, 24)
Me._toolbarMain.Name = "_toolbarMain"
Me._toolbarMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
Me._toolbarMain.Size = New System.Drawing.Size(1014, 31)
Me._toolbarMain.TabIndex = 6
Me._toolbarMain.TabStop = True
'
'_toolBtnOpenRaster
'
Me._toolBtnOpenRaster.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me._toolBtnOpenRaster.Image = Global.Resources.LoadRaster
Me._toolBtnOpenRaster.ImageTransparentColor = System.Drawing.Color.Magenta
Me._toolBtnOpenRaster.Name = "_toolBtnOpenRaster"
Me._toolBtnOpenRaster.Size = New System.Drawing.Size(28, 28)
Me._toolBtnOpenRaster.Text = "Open Image"
'
'toolStripSeparator23
'
Me.toolStripSeparator23.Name = "toolStripSeparator23"
Me.toolStripSeparator23.Size = New System.Drawing.Size(6, 31)
'
'_toolBtnStoreToPacs
'
Me._toolBtnStoreToPacs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me._toolBtnStoreToPacs.Image = Global.Resources.StorePACS_48
Me._toolBtnStoreToPacs.ImageTransparentColor = System.Drawing.Color.Magenta
Me._toolBtnStoreToPacs.Name = "_toolBtnStoreToPacs"
Me._toolBtnStoreToPacs.Size = New System.Drawing.Size(28, 28)
Me._toolBtnStoreToPacs.Text = "Store To PACS"
'
'_toolBtnSaveDicom
'
Me._toolBtnSaveDicom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me._toolBtnSaveDicom.Image = Global.Resources.SaveDICOM
Me._toolBtnSaveDicom.ImageTransparentColor = System.Drawing.Color.Magenta
Me._toolBtnSaveDicom.Name = "_toolBtnSaveDicom"
Me._toolBtnSaveDicom.Size = New System.Drawing.Size(28, 28)
Me._toolBtnSaveDicom.Text = "Save DICOM"
'
'toolStripSeparator4
'
Me.toolStripSeparator4.Name = "toolStripSeparator4"
Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 31)
'
'_toolBtnCLearInfo
'
Me._toolBtnCLearInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me._toolBtnCLearInfo.Image = Global.Resources.ClearDICOM
Me._toolBtnCLearInfo.ImageTransparentColor = System.Drawing.Color.Magenta
Me._toolBtnCLearInfo.Name = "_toolBtnCLearInfo"
Me._toolBtnCLearInfo.Size = New System.Drawing.Size(28, 28)
Me._toolBtnCLearInfo.Text = "Clear DICOM Info"
'
'toolStripSeparator5
'
Me.toolStripSeparator5.Name = "toolStripSeparator5"
Me.toolStripSeparator5.Size = New System.Drawing.Size(6, 31)
'
'_toolBtnDeleteAll
'
Me._toolBtnDeleteAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me._toolBtnDeleteAll.Image = Global.Resources.DeleteImage
Me._toolBtnDeleteAll.ImageTransparentColor = System.Drawing.Color.Magenta
Me._toolBtnDeleteAll.Name = "_toolBtnDeleteAll"
Me._toolBtnDeleteAll.Size = New System.Drawing.Size(28, 28)
Me._toolBtnDeleteAll.Text = "Delete All Images"
'
'_toolBtnDeleteSelected
'
Me._toolBtnDeleteSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me._toolBtnDeleteSelected.Image = Global.Resources.DeleteSelectImage
Me._toolBtnDeleteSelected.ImageTransparentColor = System.Drawing.Color.Magenta
Me._toolBtnDeleteSelected.Name = "_toolBtnDeleteSelected"
Me._toolBtnDeleteSelected.Size = New System.Drawing.Size(28, 28)
Me._toolBtnDeleteSelected.Text = "Delete Selected Image(s)"
'
'toolStripSeparator6
'
Me.toolStripSeparator6.Name = "toolStripSeparator6"
Me.toolStripSeparator6.Size = New System.Drawing.Size(6, 31)
'
'_toolBtnTwain
'
Me._toolBtnTwain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me._toolBtnTwain.Image = Global.Resources.TWAINAquire
Me._toolBtnTwain.ImageTransparentColor = System.Drawing.Color.Magenta
Me._toolBtnTwain.Name = "_toolBtnTwain"
Me._toolBtnTwain.Size = New System.Drawing.Size(28, 28)
Me._toolBtnTwain.Text = "Twain Acquire "
'
'_toolBtnWia
'
Me._toolBtnWia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me._toolBtnWia.Image = Global.Resources.WIAAcquire
Me._toolBtnWia.ImageTransparentColor = System.Drawing.Color.Magenta
Me._toolBtnWia.Name = "_toolBtnWia"
Me._toolBtnWia.Size = New System.Drawing.Size(28, 28)
Me._toolBtnWia.Text = "WIA Acquire"
'
'toolStripSeparator21
'
Me.toolStripSeparator21.Name = "toolStripSeparator21"
Me.toolStripSeparator21.Size = New System.Drawing.Size(6, 31)
'
'_toolBtnRotate
'
Me._toolBtnRotate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me._toolBtnRotate.Image = Global.Resources.Rotate
Me._toolBtnRotate.ImageTransparentColor = System.Drawing.Color.Magenta
Me._toolBtnRotate.Name = "_toolBtnRotate"
Me._toolBtnRotate.Size = New System.Drawing.Size(28, 28)
Me._toolBtnRotate.Text = "Rotate 90"
'
'toolStripSeparator24
'
Me.toolStripSeparator24.Name = "toolStripSeparator24"
Me.toolStripSeparator24.Size = New System.Drawing.Size(6, 31)
'
'_toolBtnScreenCapture
'
Me._toolBtnScreenCapture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me._toolBtnScreenCapture.Image = Global.Resources.ScreenCapture
Me._toolBtnScreenCapture.ImageTransparentColor = System.Drawing.Color.Magenta
Me._toolBtnScreenCapture.Name = "_toolBtnScreenCapture"
Me._toolBtnScreenCapture.Size = New System.Drawing.Size(28, 28)
Me._toolBtnScreenCapture.Text = "Screen Capture"
'
'toolStripSeparator20
'
Me.toolStripSeparator20.Name = "toolStripSeparator20"
Me.toolStripSeparator20.Size = New System.Drawing.Size(6, 31)
'
'_toolBtnViewLog
'
Me._toolBtnViewLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me._toolBtnViewLog.Image = Global.Resources.ViewLog
Me._toolBtnViewLog.ImageTransparentColor = System.Drawing.Color.Magenta
Me._toolBtnViewLog.Name = "_toolBtnViewLog"
Me._toolBtnViewLog.Size = New System.Drawing.Size(28, 28)
Me._toolBtnViewLog.Text = "Show/Hide Log Window"
'
'toolStripSeparator7
'
Me.toolStripSeparator7.Name = "toolStripSeparator7"
Me.toolStripSeparator7.Size = New System.Drawing.Size(6, 31)
'
'_toolBtnSettings
'
Me._toolBtnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me._toolBtnSettings.Image = Global.Resources.AppSettings
Me._toolBtnSettings.ImageTransparentColor = System.Drawing.Color.Magenta
Me._toolBtnSettings.Name = "_toolBtnSettings"
Me._toolBtnSettings.Size = New System.Drawing.Size(28, 28)
Me._toolBtnSettings.Text = "Settings"
'
'toolStripSeparator8
'
Me.toolStripSeparator8.Name = "toolStripSeparator8"
Me.toolStripSeparator8.Size = New System.Drawing.Size(6, 31)
'
'_toolBtnHelp
'
Me._toolBtnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me._toolBtnHelp.Image = Global.Resources.Help
Me._toolBtnHelp.ImageTransparentColor = System.Drawing.Color.Magenta
Me._toolBtnHelp.Name = "_toolBtnHelp"
Me._toolBtnHelp.Size = New System.Drawing.Size(28, 28)
Me._toolBtnHelp.Text = "Help"
'
'_cmListBox
'
Me._cmListBox.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._cmiViewMode, Me.toolStripSeparator9, Me._cmiDeleteAll, Me._cmiDeleteSelected})
Me._cmListBox.Name = "_cnmnuDicomInfo"
Me._cmListBox.Size = New System.Drawing.Size(157, 76)
'
'_cmiViewMode
'
Me._cmiViewMode.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._cmiExpanded, Me._cmiCondensed})
Me._cmiViewMode.Name = "_cmiViewMode"
Me._cmiViewMode.Size = New System.Drawing.Size(156, 22)
Me._cmiViewMode.Text = "&View Mode"
'
'_cmiExpanded
'
Me._cmiExpanded.Name = "_cmiExpanded"
Me._cmiExpanded.Size = New System.Drawing.Size(134, 22)
Me._cmiExpanded.Text = "&Expanded"
'
'_cmiCondensed
'
Me._cmiCondensed.Name = "_cmiCondensed"
Me._cmiCondensed.Size = New System.Drawing.Size(134, 22)
Me._cmiCondensed.Text = "Condensed"
'
'toolStripSeparator9
'
Me.toolStripSeparator9.Name = "toolStripSeparator9"
Me.toolStripSeparator9.Size = New System.Drawing.Size(153, 6)
'
'_cmiDeleteAll
'
Me._cmiDeleteAll.Name = "_cmiDeleteAll"
Me._cmiDeleteAll.Size = New System.Drawing.Size(156, 22)
Me._cmiDeleteAll.Text = "&Delete All Items"
'
'_cmiDeleteSelected
'
Me._cmiDeleteSelected.Name = "_cmiDeleteSelected"
Me._cmiDeleteSelected.Size = New System.Drawing.Size(156, 22)
Me._cmiDeleteSelected.Text = "Delete &Selected"
'
'_lstBoxPages
'
Me._lstBoxPages.AutoScroll = True
Me._lstBoxPages.BackColor = System.Drawing.SystemColors.AppWorkspace
Me._lstBoxPages.Dock = System.Windows.Forms.DockStyle.Fill
Me._lstBoxPages.ExpansionButtonLocation = System.Windows.Forms.AnchorStyles.Left
Me._lstBoxPages.ItemHeight = 120
Me._lstBoxPages.Location = New System.Drawing.Point(0, 0)
Me._lstBoxPages.Name = "_lstBoxPages"
Me._lstBoxPages.SelectedGroupIndex = -1
Me._lstBoxPages.SelectedIndex = -1
Me._lstBoxPages.SelectedItem = Nothing
Me._lstBoxPages.SelectedItemGroupIndex = -1
Me._lstBoxPages.Size = New System.Drawing.Size(150, 678)
Me._lstBoxPages.TabIndex = 0
Me._lstBoxPages.ViewMode = PrintToPACSDemo.ThumbMode.Condensed
'
'FrmMain
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(1014, 734)
Me.Controls.Add(Me._panelPictureBox)
Me.Controls.Add(Me._toolbarMain)
Me.Controls.Add(Me._mmMain)
Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
Me.MainMenuStrip = Me._mmMain
Me.MinimumSize = New System.Drawing.Size(1022, 768)
Me.Name = "FrmMain"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "LEADTOOLS VB Print to PACS"
Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
Me._mmMain.ResumeLayout(False)
Me._mmMain.PerformLayout()
Me._panelPictureBox.ResumeLayout(False)
Me._tbTableLayout.ResumeLayout(False)
Me._gbDicomInfo.ResumeLayout(False)
Me._tbPropertyGrid.ResumeLayout(False)
Me.panel6.ResumeLayout(False)
Me.panel6.PerformLayout()
Me._grpBoxPictureBox.ResumeLayout(False)
Me._tbPicture.ResumeLayout(False)
Me._tbPicture.PerformLayout()
Me.groupBox2.ResumeLayout(False)
Me.groupBox2.PerformLayout()
Me._grpImgInfo.ResumeLayout(False)
Me._tbDicomInfo.ResumeLayout(False)
Me._pageDataSet.ResumeLayout(False)
Me._tbOpenDataSet.ResumeLayout(False)
Me._tbOpenDataSet.PerformLayout()
Me.groupBox4.ResumeLayout(False)
Me.groupBox4.PerformLayout()
Me.panel8.ResumeLayout(False)
Me.panel8.PerformLayout()
Me.panel7.ResumeLayout(False)
Me.panel7.PerformLayout()
Me._cmResultQuery.ResumeLayout(False)
Me._pageSCPQuery.ResumeLayout(False)
Me._tbQuerySCPList.ResumeLayout(False)
Me._tbQuerySCPList.PerformLayout()
Me._grpSCPServers.ResumeLayout(False)
Me._grpSCPServers.PerformLayout()
Me.panel10.ResumeLayout(False)
Me.panel10.PerformLayout()
Me.panel9.ResumeLayout(False)
Me.panel9.PerformLayout()
Me._gbSearchParams.ResumeLayout(False)
Me._cnmnuClearSearch.ResumeLayout(False)
Me._pageMWLQuery.ResumeLayout(False)
Me._tbQueryMWList.ResumeLayout(False)
Me._tbQueryMWList.PerformLayout()
Me._toolStripMWLSearch.ResumeLayout(False)
Me._toolStripMWLSearch.PerformLayout()
Me._grpMWLQuery.ResumeLayout(False)
Me._grpMWLQuery.PerformLayout()
Me.panel12.ResumeLayout(False)
Me.panel12.PerformLayout()
Me._gbMWLSearch.ResumeLayout(False)
Me._grpStoreServers.ResumeLayout(False)
Me._grpStoreServers.PerformLayout()
Me._cnmnuClearDicom.ResumeLayout(False)
Me.panel2.ResumeLayout(False)
Me.panel3.ResumeLayout(False)
Me.panel3.PerformLayout()
Me._toolbarMain.ResumeLayout(False)
Me._toolbarMain.PerformLayout()
Me._cmListBox.ResumeLayout(False)
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
#End Region

   Private _mmMain As System.Windows.Forms.MenuStrip
   Private _miHelp As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miAbout As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _lstBoxPages As ListImageBox
   Private _panelPictureBox As System.Windows.Forms.Panel
   Private _miEventsEmf2 As System.Windows.Forms.ToolStripMenuItem
   Private _miEventsJob2 As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miView As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miNormal As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miFit As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miZoomIn As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miZoomOut As System.Windows.Forms.ToolStripMenuItem
   Private _tbTableLayout As System.Windows.Forms.TableLayoutPanel
   Private _gbRecognized As System.Windows.Forms.GroupBox
   Private WithEvents _miShowHelp As System.Windows.Forms.ToolStripMenuItem
   Private _cnmnuClearDicom As System.Windows.Forms.ContextMenuStrip
   Private WithEvents _miClearPG As System.Windows.Forms.ToolStripMenuItem
   Private _gbDicomInfo As System.Windows.Forms.GroupBox
   Private _tbDicomInfo As System.Windows.Forms.TabControl
   Private _pageDataSet As System.Windows.Forms.TabPage
   Private _pageSCPQuery As System.Windows.Forms.TabPage
   Private _tbQuerySCPList As System.Windows.Forms.TableLayoutPanel

   Private _clmnANMWL As System.Windows.Forms.DataGridViewTextBoxColumn
   Private _clmnPIDMWL As System.Windows.Forms.DataGridViewTextBoxColumn
   Private _clmnPNMWL As System.Windows.Forms.DataGridViewTextBoxColumn
   Private _clmnBDMWL As System.Windows.Forms.DataGridViewTextBoxColumn
   Private _clmnGMWL As System.Windows.Forms.DataGridViewTextBoxColumn
   Private _clmnSSMWL As System.Windows.Forms.DataGridViewTextBoxColumn
   Private _clmnMODMWL As System.Windows.Forms.DataGridViewTextBoxColumn
   Private _clmnSSAEMWL As System.Windows.Forms.DataGridViewTextBoxColumn
   Private _clmnSPRrocMWL As System.Windows.Forms.DataGridViewTextBoxColumn
   Private WithEvents _cmResultQuery As System.Windows.Forms.ContextMenuStrip
   Private WithEvents _miClearResult As System.Windows.Forms.ToolStripMenuItem
   Private _cnmnuClearSearch As System.Windows.Forms.ContextMenuStrip
   Private WithEvents _miClearSearch As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miEdit As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miDeleteAll As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miFile As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miSaveAsDICOM As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miStoreToPACS As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _miExit As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _lstSCPPatient As System.Windows.Forms.ListView
   Private _columnHeader1 As System.Windows.Forms.ColumnHeader
   Private _columnHeader2 As System.Windows.Forms.ColumnHeader
   Private _columnHeader3 As System.Windows.Forms.ColumnHeader
   Private _columnHeader4 As System.Windows.Forms.ColumnHeader
   Private label2 As System.Windows.Forms.Label
   Private WithEvents _lstSCPStudies As System.Windows.Forms.ListView
   Private _columnHeader7 As System.Windows.Forms.ColumnHeader
   Private _columnHeader8 As System.Windows.Forms.ColumnHeader
   Private _columnHeader9 As System.Windows.Forms.ColumnHeader
   Private _columnHeader10 As System.Windows.Forms.ColumnHeader
   Private _columnHeader11 As System.Windows.Forms.ColumnHeader
   Private label1 As System.Windows.Forms.Label
   Private _tbOpenDataSet As System.Windows.Forms.TableLayoutPanel
   Private label6 As System.Windows.Forms.Label
   Private WithEvents _lstDSStudies As System.Windows.Forms.ListView
   Private columnHeader12 As System.Windows.Forms.ColumnHeader
   Private columnHeader13 As System.Windows.Forms.ColumnHeader
   Private columnHeader14 As System.Windows.Forms.ColumnHeader
   Private columnHeader15 As System.Windows.Forms.ColumnHeader
   Private columnHeader16 As System.Windows.Forms.ColumnHeader
   Private WithEvents _lstDSPatient As System.Windows.Forms.ListView
   Private columnHeader17 As System.Windows.Forms.ColumnHeader
   Private columnHeader18 As System.Windows.Forms.ColumnHeader
   Private columnHeader19 As System.Windows.Forms.ColumnHeader
   Private columnHeader20 As System.Windows.Forms.ColumnHeader
   Private label8 As System.Windows.Forms.Label
   Private label3 As System.Windows.Forms.Label
   Private listView1 As System.Windows.Forms.ListView
   Private columnHeader1 As System.Windows.Forms.ColumnHeader
   Private columnHeader2 As System.Windows.Forms.ColumnHeader
   Private columnHeader3 As System.Windows.Forms.ColumnHeader
   Private columnHeader4 As System.Windows.Forms.ColumnHeader
   Private columnHeader5 As System.Windows.Forms.ColumnHeader
   Private listView2 As System.Windows.Forms.ListView
   Private columnHeader6 As System.Windows.Forms.ColumnHeader
   Private columnHeader7 As System.Windows.Forms.ColumnHeader
   Private columnHeader8 As System.Windows.Forms.ColumnHeader
   Private columnHeader9 As System.Windows.Forms.ColumnHeader
   Private columnHeader10 As System.Windows.Forms.ColumnHeader
   Private columnHeader11 As System.Windows.Forms.ColumnHeader
   Private panel2 As System.Windows.Forms.Panel
   Private button1 As System.Windows.Forms.Button
   Private groupBox1 As System.Windows.Forms.GroupBox
   Private propertyGrid1 As System.Windows.Forms.PropertyGrid
   Private panel3 As System.Windows.Forms.Panel
   Private comboBox1 As System.Windows.Forms.ComboBox
   Private label4 As System.Windows.Forms.Label
   Private label5 As System.Windows.Forms.Label
   Private _gbSearchParams As System.Windows.Forms.GroupBox
   Private _pgSearchSCP As System.Windows.Forms.PropertyGrid
   Private _tbPropertyGrid As System.Windows.Forms.TableLayoutPanel
   Private panel6 As System.Windows.Forms.Panel
   Private WithEvents _cmbSopClasses As System.Windows.Forms.ComboBox
   Private label7 As System.Windows.Forms.Label
   Private WithEvents _miOpen As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miResetInfo As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miDeleteSelected As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miViewLog As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Private _toolbarMain As System.Windows.Forms.ToolStrip
   Private WithEvents _toolBtnStoreToPacs As System.Windows.Forms.ToolStripButton
   Private WithEvents _toolBtnSaveDicom As System.Windows.Forms.ToolStripButton
   Private toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _toolBtnCLearInfo As System.Windows.Forms.ToolStripButton
   Private toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _toolBtnDeleteAll As System.Windows.Forms.ToolStripButton
   Private WithEvents _toolBtnDeleteSelected As System.Windows.Forms.ToolStripButton
   Private toolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _toolBtnViewLog As System.Windows.Forms.ToolStripButton
   Private toolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _toolBtnSettings As System.Windows.Forms.ToolStripButton
   Private toolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _toolBtnHelp As System.Windows.Forms.ToolStripButton
   Private WithEvents _cmListBox As System.Windows.Forms.ContextMenuStrip
   Private _cmiViewMode As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _cmiDeleteAll As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _cmiDeleteSelected As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _cmiExpanded As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _cmiCondensed As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _miPaste As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
   Private _miCapture As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miCaptureActiveWindow As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miCaptureFullScreen As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miCaptureSelectedObject As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miCaptureSelectedArea As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _miCaptureStopCapture As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator19 As System.Windows.Forms.ToolStripSeparator
   Private _miCaptureOptionsMenu As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miCaptureAreaOptions As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miCaptureOptions As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miCaptureObjectOptions As System.Windows.Forms.ToolStripMenuItem
   Private _miOptions As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miSettings As System.Windows.Forms.ToolStripMenuItem
   Private panel7 As System.Windows.Forms.Panel
   Private WithEvents _btnTransferLoadedPatient As System.Windows.Forms.Button
   Private panel9 As System.Windows.Forms.Panel
   Private WithEvents _btnTransferSCPPatient As System.Windows.Forms.Button
   Private _pageMWLQuery As System.Windows.Forms.TabPage
   Private _tbQueryMWList As System.Windows.Forms.TableLayoutPanel
   Private panel12 As System.Windows.Forms.Panel
   Private WithEvents _btnTransferMWL As System.Windows.Forms.Button
   Private _gbMWLSearch As System.Windows.Forms.GroupBox
   Private _pgSearchMWL As System.Windows.Forms.PropertyGrid
   Private label11 As System.Windows.Forms.Label
   Private WithEvents _lstMWLItems As System.Windows.Forms.ListView
   Private columnHeader26 As System.Windows.Forms.ColumnHeader
   Private columnHeader27 As System.Windows.Forms.ColumnHeader
   Private columnHeader28 As System.Windows.Forms.ColumnHeader
   Private columnHeader29 As System.Windows.Forms.ColumnHeader
   Private columnHeader21 As System.Windows.Forms.ColumnHeader
   Private columnHeader22 As System.Windows.Forms.ColumnHeader
   Private columnHeader23 As System.Windows.Forms.ColumnHeader
   Private columnHeader24 As System.Windows.Forms.ColumnHeader
   Private columnHeader25 As System.Windows.Forms.ColumnHeader
   Private columnHeader30 As System.Windows.Forms.ColumnHeader
   Private _panelImageList As System.Windows.Forms.Panel
   Private WithEvents _miResample As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
   Private _miAcquire As System.Windows.Forms.ToolStripMenuItem
   Private _miAcquireTwain As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miTwainAcquire As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
   Private _miTemplate As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miTemplateLEAD As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miTemplateShowCaps As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _miTemplateShowErrors As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miTwainSelectSource As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miWia As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miWiaVersion As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miWiaSelectSource As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miWiaAcquire As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _miWiaOptions As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miOptionsAcquireOptions As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _miOptionsShowUI As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miWiaCapabilities As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miCapabilitiesShowCapabilities As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miCapabilitiesShowFormats As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miWiaProperties As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miPropertiesWiaProperties As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _miPropertiesShowErrors As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator20 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _toolBtnTwain As System.Windows.Forms.ToolStripButton
   Private WithEvents _toolBtnWia As System.Windows.Forms.ToolStripButton
   Private toolStripSeparator21 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _toolBtnScreenCapture As System.Windows.Forms.ToolStripButton
   Private panel10 As System.Windows.Forms.Panel
   Private WithEvents _btnTransferSCPStudies As System.Windows.Forms.Button
   Private WithEvents _miDeleteSelectedDataSet As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator22 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _toolBtnOpenRaster As System.Windows.Forms.ToolStripButton
   Private toolStripSeparator23 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _toolBtnRotate As System.Windows.Forms.ToolStripButton
   Private toolStripSeparator24 As System.Windows.Forms.ToolStripSeparator
   Private toolStripSeparator25 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _miRotate90 As System.Windows.Forms.ToolStripMenuItem
   Private _grpBoxPictureBox As System.Windows.Forms.GroupBox
   Private _tbPicture As System.Windows.Forms.TableLayoutPanel
   Private groupBox2 As System.Windows.Forms.GroupBox
   Private _txtPrinterName As System.Windows.Forms.TextBox
   Private label12 As System.Windows.Forms.Label
   Private WithEvents _btnPrev As System.Windows.Forms.Button
   Private _lblPageInfo As System.Windows.Forms.Label
   Private WithEvents _btnWIAAquire As System.Windows.Forms.Button
   Private WithEvents _btnTwainAquire As System.Windows.Forms.Button
   Private WithEvents _btnScreenCapture As System.Windows.Forms.Button
   Private WithEvents _btnOpenImage As System.Windows.Forms.Button
   Private WithEvents _btnNext As System.Windows.Forms.Button
   Private groupBox4 As System.Windows.Forms.GroupBox
   Private _txtDataSet As System.Windows.Forms.TextBox
   Private WithEvents _btnBrowseDataSet As System.Windows.Forms.Button
   Private _grpImgInfo As System.Windows.Forms.GroupBox
   Private _grpStoreServers As System.Windows.Forms.GroupBox
   Private WithEvents _btnPushToPACS As System.Windows.Forms.Button
   Private WithEvents _cbStoreServers As System.Windows.Forms.ComboBox
   Private label9 As System.Windows.Forms.Label
   Private WithEvents _btnPACSSettings As System.Windows.Forms.Button
   Private _grpSCPServers As System.Windows.Forms.GroupBox
   Private WithEvents _btnSCPQuery As System.Windows.Forms.Button
   Private _cbSCPServers As System.Windows.Forms.ComboBox
   Private _grpMWLQuery As System.Windows.Forms.GroupBox
   Private WithEvents _btnMWLQuery As System.Windows.Forms.Button
   Private _cbMWLServers As System.Windows.Forms.ComboBox
   Private _toolStripMWLSearch As System.Windows.Forms.ToolStrip
   Private WithEvents _toolBtnPatient As System.Windows.Forms.ToolStripButton
   Private _toolLblMWLType As System.Windows.Forms.ToolStripLabel
   Private label10 As System.Windows.Forms.Label
   Private label18 As System.Windows.Forms.Label
   Private label13 As System.Windows.Forms.Label
   Private panel8 As System.Windows.Forms.Panel
   Private label19 As System.Windows.Forms.Label
   Private label14 As System.Windows.Forms.Label
   Private WithEvents _btnTransferLoadedStudies As System.Windows.Forms.Button
   Private label15 As System.Windows.Forms.Label
   Private label16 As System.Windows.Forms.Label
   Private label17 As System.Windows.Forms.Label
   Private label20 As System.Windows.Forms.Label
   Private label21 As System.Windows.Forms.Label
   Private label22 As System.Windows.Forms.Label
   Private label23 As System.Windows.Forms.Label
   Private label24 As System.Windows.Forms.Label
   Private label28 As System.Windows.Forms.Label
   Private label29 As System.Windows.Forms.Label
   Private label25 As System.Windows.Forms.Label
   Private label26 As System.Windows.Forms.Label
   Private label27 As System.Windows.Forms.Label
   Private WithEvents _miHowToUse As System.Windows.Forms.ToolStripMenuItem
   Private toolStripSeparator26 As System.Windows.Forms.ToolStripSeparator

   End Class
End Namespace

