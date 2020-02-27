' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Collections.Specialized
Imports Microsoft.Win32

Imports Leadtools
Imports Leadtools.Dicom
Imports Leadtools.DicomDemos
Imports Leadtools.Demos.Database
Imports Leadtools.Demos
Imports System.Collections.Generic


Namespace DicomDemo
   ''' <summary>
   ''' Summary description for Form1.
   ''' </summary>
   Public Class MainForm : Inherits System.Windows.Forms.Form
      Private statusBar1 As System.Windows.Forms.StatusBar
      Private statusBarPanelConnect As System.Windows.Forms.StatusBarPanel
      Private panelLog As System.Windows.Forms.Panel
      Private splitter1 As System.Windows.Forms.Splitter
      Private panelTabs As System.Windows.Forms.Panel
      Private WithEvents tabControlServer As System.Windows.Forms.TabControl
      Private tabPageDatabase As System.Windows.Forms.TabPage
      Private label1 As System.Windows.Forms.Label
      Private WithEvents toolBarMain As System.Windows.Forms.ToolBar
      Private tabPageUsers As System.Windows.Forms.TabPage
      Private toolBarButtonActive As System.Windows.Forms.ToolBarButton
      Private toolBarButtonOptions As System.Windows.Forms.ToolBarButton
      Private WithEvents dataGridDicom As System.Windows.Forms.DataGrid
      Private components As System.ComponentModel.IContainer

      Private usersDB As UsersDB = New UsersDB(Application.StartupPath & "\UsersVB.xml")
      Private dicomDB As DicomDB = New DicomDB(Application.StartupPath & "\DicomVB.xml")
      Private dicomServer As Server = New Server()

      Public Delegate Sub LogDelegate(ByVal action As String, ByVal Log As String)
      Public Delegate Sub LogTagDelegate(ByVal action As String, ByVal Log As String, ByVal tag As Object)

      Private toolBarButtonImport As System.Windows.Forms.ToolBarButton
      Private imageListToolbar As System.Windows.Forms.ImageList
      Private tabPageClients As System.Windows.Forms.TabPage
      Private WithEvents dataGridUsers As System.Windows.Forms.DataGrid
      Private toolBarButtonUserAdd As System.Windows.Forms.ToolBarButton
      Private toolBarButtonUserModify As System.Windows.Forms.ToolBarButton
      Private toolBarButtonDelete As System.Windows.Forms.ToolBarButton
      Private toolBarButton1 As System.Windows.Forms.ToolBarButton
      Private toolBarButton2 As System.Windows.Forms.ToolBarButton
      Private toolBarButton3 As System.Windows.Forms.ToolBarButton
      Private toolBarButtonClearLog As System.Windows.Forms.ToolBarButton
      Private toolBarButtonDisconnect As System.Windows.Forms.ToolBarButton
      Private columnHeader1 As System.Windows.Forms.ColumnHeader
      Private columnHeader2 As System.Windows.Forms.ColumnHeader
      Private columnHeader3 As System.Windows.Forms.ColumnHeader
      Private columnHeader5 As System.Windows.Forms.ColumnHeader
      Private listViewClients As System.Windows.Forms.ListView
      Private toolBarButton4 As System.Windows.Forms.ToolBarButton
      Private toolBarButtonAssociation As System.Windows.Forms.ToolBarButton
      Private WithEvents listViewLog As System.Windows.Forms.ListView
      Private columnHeader6 As System.Windows.Forms.ColumnHeader
      Private columnHeader7 As System.Windows.Forms.ColumnHeader
      Private columnHeader8 As System.Windows.Forms.ColumnHeader
      Private imageListLog As System.Windows.Forms.ImageList
      Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
      Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
      Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
      Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
      Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
      Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
      Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
      Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
      Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
      Private toolBarButtonExit As System.Windows.Forms.ToolBarButton

      Public ReadOnly Property DicomData() As DicomDB
         Get
            Return dicomDB
         End Get
      End Property

      Public ReadOnly Property UsersData() As UsersDB
         Get
            Return usersDB
         End Get
      End Property

      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         Logger.Initialize(listViewLog)
      End Sub

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            If Not components Is Nothing Then
               components.Dispose()
               ForceCloseClients()
            End If
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
         Me.statusBar1 = New System.Windows.Forms.StatusBar
         Me.statusBarPanelConnect = New System.Windows.Forms.StatusBarPanel
         Me.panelLog = New System.Windows.Forms.Panel
         Me.listViewLog = New System.Windows.Forms.ListView
         Me.columnHeader6 = New System.Windows.Forms.ColumnHeader
         Me.columnHeader7 = New System.Windows.Forms.ColumnHeader
         Me.imageListLog = New System.Windows.Forms.ImageList(Me.components)
         Me.label1 = New System.Windows.Forms.Label
         Me.splitter1 = New System.Windows.Forms.Splitter
         Me.toolBarMain = New System.Windows.Forms.ToolBar
         Me.toolBarButtonImport = New System.Windows.Forms.ToolBarButton
         Me.toolBarButtonActive = New System.Windows.Forms.ToolBarButton
         Me.toolBarButton3 = New System.Windows.Forms.ToolBarButton
         Me.toolBarButtonClearLog = New System.Windows.Forms.ToolBarButton
         Me.toolBarButtonOptions = New System.Windows.Forms.ToolBarButton
         Me.toolBarButton1 = New System.Windows.Forms.ToolBarButton
         Me.toolBarButtonUserAdd = New System.Windows.Forms.ToolBarButton
         Me.toolBarButtonUserModify = New System.Windows.Forms.ToolBarButton
         Me.toolBarButtonDelete = New System.Windows.Forms.ToolBarButton
         Me.toolBarButton4 = New System.Windows.Forms.ToolBarButton
         Me.toolBarButtonAssociation = New System.Windows.Forms.ToolBarButton
         Me.toolBarButtonDisconnect = New System.Windows.Forms.ToolBarButton
         Me.toolBarButton2 = New System.Windows.Forms.ToolBarButton
         Me.toolBarButtonExit = New System.Windows.Forms.ToolBarButton
         Me.imageListToolbar = New System.Windows.Forms.ImageList(Me.components)
         Me.panelTabs = New System.Windows.Forms.Panel
         Me.tabControlServer = New System.Windows.Forms.TabControl
         Me.tabPageDatabase = New System.Windows.Forms.TabPage
         Me.dataGridDicom = New System.Windows.Forms.DataGrid
         Me.tabPageUsers = New System.Windows.Forms.TabPage
         Me.dataGridUsers = New System.Windows.Forms.DataGrid
         Me.tabPageClients = New System.Windows.Forms.TabPage
         Me.listViewClients = New System.Windows.Forms.ListView
         Me.columnHeader8 = New System.Windows.Forms.ColumnHeader
         Me.columnHeader1 = New System.Windows.Forms.ColumnHeader
         Me.columnHeader2 = New System.Windows.Forms.ColumnHeader
         Me.columnHeader3 = New System.Windows.Forms.ColumnHeader
         Me.columnHeader5 = New System.Windows.Forms.ColumnHeader
         Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
         Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle
         Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
         Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
         Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
         Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
         Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
         Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
         Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
         CType(Me.statusBarPanelConnect, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.panelLog.SuspendLayout()
         Me.panelTabs.SuspendLayout()
         Me.tabControlServer.SuspendLayout()
         Me.tabPageDatabase.SuspendLayout()
         CType(Me.dataGridDicom, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.tabPageUsers.SuspendLayout()
         CType(Me.dataGridUsers, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.tabPageClients.SuspendLayout()
         Me.SuspendLayout()
         '
         'statusBar1
         '
         Me.statusBar1.Location = New System.Drawing.Point(0, 343)
         Me.statusBar1.Name = "statusBar1"
         Me.statusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.statusBarPanelConnect})
         Me.statusBar1.Size = New System.Drawing.Size(544, 22)
         Me.statusBar1.TabIndex = 0
         '
         'statusBarPanelConnect
         '
         Me.statusBarPanelConnect.Name = "statusBarPanelConnect"
         Me.statusBarPanelConnect.Text = "Connected"
         '
         'panelLog
         '
         Me.panelLog.Controls.Add(Me.listViewLog)
         Me.panelLog.Controls.Add(Me.label1)
         Me.panelLog.Dock = System.Windows.Forms.DockStyle.Bottom
         Me.panelLog.Location = New System.Drawing.Point(0, 243)
         Me.panelLog.Name = "panelLog"
         Me.panelLog.Size = New System.Drawing.Size(544, 100)
         Me.panelLog.TabIndex = 1
         '
         'listViewLog
         '
         Me.listViewLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader6, Me.columnHeader7})
         Me.listViewLog.Dock = System.Windows.Forms.DockStyle.Fill
         Me.listViewLog.FullRowSelect = True
         Me.listViewLog.GridLines = True
         Me.listViewLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
         Me.listViewLog.Location = New System.Drawing.Point(0, 16)
         Me.listViewLog.Name = "listViewLog"
         Me.listViewLog.Size = New System.Drawing.Size(544, 84)
         Me.listViewLog.SmallImageList = Me.imageListLog
         Me.listViewLog.TabIndex = 1
         Me.listViewLog.UseCompatibleStateImageBehavior = False
         Me.listViewLog.View = System.Windows.Forms.View.Details
         '
         'columnHeader6
         '
         Me.columnHeader6.Text = "Action"
         Me.columnHeader6.Width = 100
         '
         'columnHeader7
         '
         Me.columnHeader7.Text = "Info"
         Me.columnHeader7.Width = 200
         '
         'imageListLog
         '
         Me.imageListLog.ImageStream = CType(resources.GetObject("imageListLog.ImageStream"), System.Windows.Forms.ImageListStreamer)
         Me.imageListLog.TransparentColor = System.Drawing.Color.Transparent
         Me.imageListLog.Images.SetKeyName(0, "")
         '
         'label1
         '
         Me.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me.label1.Dock = System.Windows.Forms.DockStyle.Top
         Me.label1.Location = New System.Drawing.Point(0, 0)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(544, 16)
         Me.label1.TabIndex = 0
         Me.label1.Text = "Log: (Double click item with image icon to see dataset)"
         '
         'splitter1
         '
         Me.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
         Me.splitter1.Location = New System.Drawing.Point(0, 240)
         Me.splitter1.Name = "splitter1"
         Me.splitter1.Size = New System.Drawing.Size(544, 3)
         Me.splitter1.TabIndex = 2
         Me.splitter1.TabStop = False
         '
         'toolBarMain
         '
         Me.toolBarMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
         Me.toolBarMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.toolBarButtonImport, Me.toolBarButtonActive, Me.toolBarButton3, Me.toolBarButtonClearLog, Me.toolBarButtonOptions, Me.toolBarButton1, Me.toolBarButtonUserAdd, Me.toolBarButtonUserModify, Me.toolBarButtonDelete, Me.toolBarButton4, Me.toolBarButtonAssociation, Me.toolBarButtonDisconnect, Me.toolBarButton2, Me.toolBarButtonExit})
         Me.toolBarMain.DropDownArrows = True
         Me.toolBarMain.ImageList = Me.imageListToolbar
         Me.toolBarMain.Location = New System.Drawing.Point(0, 0)
         Me.toolBarMain.Name = "toolBarMain"
         Me.toolBarMain.ShowToolTips = True
         Me.toolBarMain.Size = New System.Drawing.Size(544, 42)
         Me.toolBarMain.TabIndex = 3
         '
         'toolBarButtonImport
         '
         Me.toolBarButtonImport.ImageIndex = 0
         Me.toolBarButtonImport.Name = "toolBarButtonImport"
         Me.toolBarButtonImport.Text = "Import"
         Me.toolBarButtonImport.ToolTipText = "Import file"
         '
         'toolBarButtonActive
         '
         Me.toolBarButtonActive.ImageIndex = 1
         Me.toolBarButtonActive.Name = "toolBarButtonActive"
         Me.toolBarButtonActive.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
         Me.toolBarButtonActive.Text = "Active"
         Me.toolBarButtonActive.ToolTipText = "Start/stop server"
         '
         'toolBarButton3
         '
         Me.toolBarButton3.Name = "toolBarButton3"
         Me.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
         '
         'toolBarButtonClearLog
         '
         Me.toolBarButtonClearLog.ImageIndex = 7
         Me.toolBarButtonClearLog.Name = "toolBarButtonClearLog"
         Me.toolBarButtonClearLog.Text = "Clear"
         Me.toolBarButtonClearLog.ToolTipText = "Clear log"
         '
         'toolBarButtonOptions
         '
         Me.toolBarButtonOptions.ImageIndex = 2
         Me.toolBarButtonOptions.Name = "toolBarButtonOptions"
         Me.toolBarButtonOptions.Text = "Options"
         Me.toolBarButtonOptions.ToolTipText = "Server options"
         '
         'toolBarButton1
         '
         Me.toolBarButton1.Name = "toolBarButton1"
         Me.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
         '
         'toolBarButtonUserAdd
         '
         Me.toolBarButtonUserAdd.Enabled = False
         Me.toolBarButtonUserAdd.ImageIndex = 4
         Me.toolBarButtonUserAdd.Name = "toolBarButtonUserAdd"
         Me.toolBarButtonUserAdd.Text = "Add"
         Me.toolBarButtonUserAdd.ToolTipText = "Add User"
         '
         'toolBarButtonUserModify
         '
         Me.toolBarButtonUserModify.Enabled = False
         Me.toolBarButtonUserModify.ImageIndex = 6
         Me.toolBarButtonUserModify.Name = "toolBarButtonUserModify"
         Me.toolBarButtonUserModify.Text = "Modify"
         Me.toolBarButtonUserModify.ToolTipText = "Modify user"
         '
         'toolBarButtonDelete
         '
         Me.toolBarButtonDelete.Enabled = False
         Me.toolBarButtonDelete.ImageIndex = 5
         Me.toolBarButtonDelete.Name = "toolBarButtonDelete"
         Me.toolBarButtonDelete.Text = "Delete"
         Me.toolBarButtonDelete.ToolTipText = "Delete user"
         '
         'toolBarButton4
         '
         Me.toolBarButton4.Name = "toolBarButton4"
         Me.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
         '
         'toolBarButtonAssociation
         '
         Me.toolBarButtonAssociation.Enabled = False
         Me.toolBarButtonAssociation.ImageIndex = 9
         Me.toolBarButtonAssociation.Name = "toolBarButtonAssociation"
         Me.toolBarButtonAssociation.Text = "Association"
         Me.toolBarButtonAssociation.ToolTipText = "View association"
         '
         'toolBarButtonDisconnect
         '
         Me.toolBarButtonDisconnect.Enabled = False
         Me.toolBarButtonDisconnect.ImageIndex = 8
         Me.toolBarButtonDisconnect.Name = "toolBarButtonDisconnect"
         Me.toolBarButtonDisconnect.Text = "Close"
         Me.toolBarButtonDisconnect.ToolTipText = "Close user connection"
         '
         'toolBarButton2
         '
         Me.toolBarButton2.Name = "toolBarButton2"
         Me.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
         '
         'toolBarButtonExit
         '
         Me.toolBarButtonExit.ImageIndex = 3
         Me.toolBarButtonExit.Name = "toolBarButtonExit"
         Me.toolBarButtonExit.Text = "Exit"
         Me.toolBarButtonExit.ToolTipText = "Exit application"
         '
         'imageListToolbar
         '
         Me.imageListToolbar.ImageStream = CType(resources.GetObject("imageListToolbar.ImageStream"), System.Windows.Forms.ImageListStreamer)
         Me.imageListToolbar.TransparentColor = System.Drawing.Color.Transparent
         Me.imageListToolbar.Images.SetKeyName(0, "")
         Me.imageListToolbar.Images.SetKeyName(1, "")
         Me.imageListToolbar.Images.SetKeyName(2, "")
         Me.imageListToolbar.Images.SetKeyName(3, "")
         Me.imageListToolbar.Images.SetKeyName(4, "")
         Me.imageListToolbar.Images.SetKeyName(5, "")
         Me.imageListToolbar.Images.SetKeyName(6, "")
         Me.imageListToolbar.Images.SetKeyName(7, "")
         Me.imageListToolbar.Images.SetKeyName(8, "")
         Me.imageListToolbar.Images.SetKeyName(9, "")
         '
         'panelTabs
         '
         Me.panelTabs.Controls.Add(Me.tabControlServer)
         Me.panelTabs.Dock = System.Windows.Forms.DockStyle.Fill
         Me.panelTabs.Location = New System.Drawing.Point(0, 42)
         Me.panelTabs.Name = "panelTabs"
         Me.panelTabs.Size = New System.Drawing.Size(544, 198)
         Me.panelTabs.TabIndex = 4
         '
         'tabControlServer
         '
         Me.tabControlServer.Controls.Add(Me.tabPageDatabase)
         Me.tabControlServer.Controls.Add(Me.tabPageUsers)
         Me.tabControlServer.Controls.Add(Me.tabPageClients)
         Me.tabControlServer.Dock = System.Windows.Forms.DockStyle.Fill
         Me.tabControlServer.Location = New System.Drawing.Point(0, 0)
         Me.tabControlServer.Name = "tabControlServer"
         Me.tabControlServer.SelectedIndex = 0
         Me.tabControlServer.Size = New System.Drawing.Size(544, 198)
         Me.tabControlServer.TabIndex = 0
         '
         'tabPageDatabase
         '
         Me.tabPageDatabase.Controls.Add(Me.dataGridDicom)
         Me.tabPageDatabase.Location = New System.Drawing.Point(4, 22)
         Me.tabPageDatabase.Name = "tabPageDatabase"
         Me.tabPageDatabase.Size = New System.Drawing.Size(536, 172)
         Me.tabPageDatabase.TabIndex = 0
         Me.tabPageDatabase.Text = "Database"
         '
         'dataGridDicom
         '
         Me.dataGridDicom.CaptionText = "Dicom Server Database"
         Me.dataGridDicom.DataMember = ""
         Me.dataGridDicom.Dock = System.Windows.Forms.DockStyle.Fill
         Me.dataGridDicom.HeaderForeColor = System.Drawing.SystemColors.ControlText
         Me.dataGridDicom.Location = New System.Drawing.Point(0, 0)
         Me.dataGridDicom.Name = "dataGridDicom"
         Me.dataGridDicom.ReadOnly = True
         Me.dataGridDicom.Size = New System.Drawing.Size(536, 172)
         Me.dataGridDicom.TabIndex = 0
         Me.dataGridDicom.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1, Me.DataGridTableStyle2})
         '
         'tabPageUsers
         '
         Me.tabPageUsers.Controls.Add(Me.dataGridUsers)
         Me.tabPageUsers.Location = New System.Drawing.Point(4, 22)
         Me.tabPageUsers.Name = "tabPageUsers"
         Me.tabPageUsers.Size = New System.Drawing.Size(536, 172)
         Me.tabPageUsers.TabIndex = 1
         Me.tabPageUsers.Text = "Users"
         '
         'dataGridUsers
         '
         Me.dataGridUsers.CaptionText = "Valid server users"
         Me.dataGridUsers.DataMember = ""
         Me.dataGridUsers.Dock = System.Windows.Forms.DockStyle.Fill
         Me.dataGridUsers.HeaderForeColor = System.Drawing.SystemColors.ControlText
         Me.dataGridUsers.Location = New System.Drawing.Point(0, 0)
         Me.dataGridUsers.Name = "dataGridUsers"
         Me.dataGridUsers.ReadOnly = True
         Me.dataGridUsers.Size = New System.Drawing.Size(536, 172)
         Me.dataGridUsers.TabIndex = 2
         '
         'tabPageClients
         '
         Me.tabPageClients.Controls.Add(Me.listViewClients)
         Me.tabPageClients.Location = New System.Drawing.Point(4, 22)
         Me.tabPageClients.Name = "tabPageClients"
         Me.tabPageClients.Size = New System.Drawing.Size(536, 172)
         Me.tabPageClients.TabIndex = 2
         Me.tabPageClients.Text = "Clients"
         '
         'listViewClients
         '
         Me.listViewClients.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader8, Me.columnHeader1, Me.columnHeader2, Me.columnHeader3, Me.columnHeader5})
         Me.listViewClients.Dock = System.Windows.Forms.DockStyle.Fill
         Me.listViewClients.FullRowSelect = True
         Me.listViewClients.GridLines = True
         Me.listViewClients.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
         Me.listViewClients.HideSelection = False
         Me.listViewClients.Location = New System.Drawing.Point(0, 0)
         Me.listViewClients.MultiSelect = False
         Me.listViewClients.Name = "listViewClients"
         Me.listViewClients.Size = New System.Drawing.Size(536, 172)
         Me.listViewClients.TabIndex = 0
         Me.listViewClients.UseCompatibleStateImageBehavior = False
         Me.listViewClients.View = System.Windows.Forms.View.Details
         '
         'columnHeader8
         '
         Me.columnHeader8.Text = "Id"
         Me.columnHeader8.Width = 100
         '
         'columnHeader1
         '
         Me.columnHeader1.Text = "AETitle"
         Me.columnHeader1.Width = 100
         '
         'columnHeader2
         '
         Me.columnHeader2.Text = "Host"
         Me.columnHeader2.Width = 100
         '
         'columnHeader3
         '
         Me.columnHeader3.Text = "Connect Time"
         Me.columnHeader3.Width = 100
         '
         'columnHeader5
         '
         Me.columnHeader5.Text = "Last Action"
         Me.columnHeader5.Width = 100
         '
         'DataGridTableStyle1
         '
         Me.DataGridTableStyle1.DataGrid = Me.dataGridDicom
         Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
         Me.DataGridTableStyle1.MappingName = "Patients"
         '
         'DataGridTableStyle2
         '
         Me.DataGridTableStyle2.DataGrid = Me.dataGridDicom
         Me.DataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7})
         Me.DataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
         Me.DataGridTableStyle2.MappingName = "Studies"
         '
         'DataGridTextBoxColumn1
         '
         Me.DataGridTextBoxColumn1.Format = ""
         Me.DataGridTextBoxColumn1.FormatInfo = Nothing
         Me.DataGridTextBoxColumn1.HeaderText = "StudyInstanceUID"
         Me.DataGridTextBoxColumn1.MappingName = "StudyInstanceUID"
         Me.DataGridTextBoxColumn1.Width = 75
         '
         'DataGridTextBoxColumn2
         '
         Me.DataGridTextBoxColumn2.Format = ""
         Me.DataGridTextBoxColumn2.FormatInfo = Nothing
         Me.DataGridTextBoxColumn2.HeaderText = "StudyDate"
         Me.DataGridTextBoxColumn2.MappingName = "StudyDate"
         Me.DataGridTextBoxColumn2.Width = 75
         '
         'DataGridTextBoxColumn3
         '
         Me.DataGridTextBoxColumn3.Format = "hh:mm:ss.ff"
         Me.DataGridTextBoxColumn3.FormatInfo = Nothing
         Me.DataGridTextBoxColumn3.HeaderText = "StudyTime"
         Me.DataGridTextBoxColumn3.MappingName = "StudyTime"
         Me.DataGridTextBoxColumn3.Width = 75
         '
         'DataGridTextBoxColumn4
         '
         Me.DataGridTextBoxColumn4.Format = ""
         Me.DataGridTextBoxColumn4.FormatInfo = Nothing
         Me.DataGridTextBoxColumn4.HeaderText = "AccessionNumber"
         Me.DataGridTextBoxColumn4.MappingName = "AccessionNumber"
         Me.DataGridTextBoxColumn4.Width = 75
         '
         'DataGridTextBoxColumn5
         '
         Me.DataGridTextBoxColumn5.Format = ""
         Me.DataGridTextBoxColumn5.FormatInfo = Nothing
         Me.DataGridTextBoxColumn5.HeaderText = "StudyID"
         Me.DataGridTextBoxColumn5.MappingName = "StudyID"
         Me.DataGridTextBoxColumn5.Width = 75
         '
         'DataGridTextBoxColumn6
         '
         Me.DataGridTextBoxColumn6.Format = ""
         Me.DataGridTextBoxColumn6.FormatInfo = Nothing
         Me.DataGridTextBoxColumn6.HeaderText = "StudyDescription"
         Me.DataGridTextBoxColumn6.MappingName = "StudyDescription"
         Me.DataGridTextBoxColumn6.Width = 75
         '
         'DataGridTextBoxColumn7
         '
         Me.DataGridTextBoxColumn7.Format = ""
         Me.DataGridTextBoxColumn7.FormatInfo = Nothing
         Me.DataGridTextBoxColumn7.HeaderText = "ReferringDrName"
         Me.DataGridTextBoxColumn7.MappingName = "ReferringDrName"
         Me.DataGridTextBoxColumn7.Width = 75
         '
         'MainForm
         '
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(544, 365)
         Me.Controls.Add(Me.panelTabs)
         Me.Controls.Add(Me.toolBarMain)
         Me.Controls.Add(Me.splitter1)
         Me.Controls.Add(Me.panelLog)
         Me.Controls.Add(Me.statusBar1)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.Name = "MainForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "LEADTOOLS Dicom Server (VB.NET)"
         CType(Me.statusBarPanelConnect, System.ComponentModel.ISupportInitialize).EndInit()
         Me.panelLog.ResumeLayout(False)
         Me.panelTabs.ResumeLayout(False)
         Me.tabControlServer.ResumeLayout(False)
         Me.tabPageDatabase.ResumeLayout(False)
         CType(Me.dataGridDicom, System.ComponentModel.ISupportInitialize).EndInit()
         Me.tabPageUsers.ResumeLayout(False)
         CType(Me.dataGridUsers, System.ComponentModel.ISupportInitialize).EndInit()
         Me.tabPageClients.ResumeLayout(False)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub
#End Region

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread()>
        Shared Sub Main(ByVal args() As String)
            Application.EnableVisualStyles()
#If LEADTOOLS_V175_OR_LATER Then
            If Not Support.SetLicense() Then
                Return
            End If
#Else
         Support.Unlock(False)
#End If


#If LEADTOOLS_V175_OR_LATER Then
            If (RasterSupport.IsLocked(RasterSupportType.DicomCommunication)) Then
                MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.DicomCommunication.ToString()), "Warning")
                Return
            End If
#Else
         If (RasterSupport.IsLocked(RasterSupportType.MedicalNet)) Then
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.MedicalNet.ToString()), "Warning")
            Return
         End If
#End If

            If DemosGlobal.MustRestartElevated() Then
                DemosGlobal.TryRestartElevated(args)
                Return
            End If

            Utils.EngineStartup()
            Utils.DicomNetStartup()

            Application.Run(New MainForm())
        End Sub

        Private Sub AddUser()
         Dim dlgUsers As UserPropertiesDlg = New UserPropertiesDlg()

         dlgUsers.Edit = False
         If dlgUsers.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Dim userInfo As UserInfo = dlgUsers.User

            usersDB.AddUser(userInfo)
            usersDB.Save()
         End If
      End Sub

      Private Sub ModifyUser()
         If dataGridUsers.CurrentRowIndex = -1 Then
            Exit Sub
         End If

         Dim id As String
         Dim dlgUsers As UserPropertiesDlg = New UserPropertiesDlg()

         id = usersDB.DB.Tables("Users").Rows(dataGridUsers.CurrentRowIndex)("Id").ToString()
         dlgUsers.Edit = True
         dlgUsers.User = usersDB.LoadUser(id)
         If dlgUsers.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            usersDB.UpdateUser(dlgUsers.User)
            usersDB.Save()
         End If
      End Sub

      Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
         If Not e.Cancel Then
            For Each client As KeyValuePair(Of String, Client) In dicomServer.Clients
               If client.Value.IsConnected() Then
                  client.Value.CloseForced(True)
               End If
               client.Value.Terminate()
            Next
         End If

      End Sub

      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

         If (Not Directory.Exists(dicomServer.ImageDir)) Then
            Directory.CreateDirectory(dicomServer.ImageDir)
         End If

         LoadSettings()
         dicomDB.ImageDir = dicomServer.ImageDir
         If dicomDB.NeedImport Then
            '
            ' We just created a new dicom database. Therefore, we need to import 
            '  some images.  By default we will import any dicom file installed
            '  by LEADTOOLS.
            '
            LoadDefaultImages()
         End If

         dicomServer.usersDB = usersDB
         dicomServer.dicomDB = dicomDB
         dicomServer.mf = Me
         StartServer()

         dataGridDicom.DataSource = dicomDB.DB
         'AddTableStyles(dataGridDicom, dicomDB)

         '
         ' Remove duplicated columns from the datagrid
         '
         RemoveColumn(dataGridDicom, "Studies", "PatientID")
         RemoveColumn(dataGridDicom, "Studies", "PatientName")
         RemoveColumn(dataGridDicom, "Series", "StudyInstanceUID")
         RemoveColumn(dataGridDicom, "Series", "PatientID")
         RemoveColumn(dataGridDicom, "Images", "StudyInstanceUID")
         RemoveColumn(dataGridDicom, "Images", "PatientID")
         RemoveColumn(dataGridDicom, "Images", "SeriesInstanceUID")
         dataGridDicom.DataMember = "Patients"

         dataGridUsers.DataSource = usersDB.DB
         AddTableStyles(dataGridUsers, usersDB)
         dataGridUsers.DataMember = "Users"
         RemoveColumn(dataGridUsers, "Users", "Id")

         AddHandler Application.ApplicationExit, AddressOf Application_ApplicationExit
      End Sub

      Private Sub LoadDefaultImages()
         Dim importFiles As StringCollection = New StringCollection()
         Dim local As RegistryKey = Registry.LocalMachine
#If LTV19_CONFIG Then
         Dim lead As RegistryKey = local.OpenSubKey("SOFTWARE\LEAD Technologies, Inc.\19")
#ElseIf LTV18_CONFIG Then
         Dim lead As RegistryKey = local.OpenSubKey("SOFTWARE\LEAD Technologies, Inc.\18")
#ElseIf LTV175_CONFIG Then
         Dim lead As RegistryKey = local.OpenSubKey("SOFTWARE\LEAD Technologies, Inc.\17.5")
#ElseIf LTV17_CONFIG Then
         Dim lead As RegistryKey = local.OpenSubKey("SOFTWARE\LEAD Technologies, Inc.\17")
#ElseIf LTV16_CONFIG Then
         Dim lead As RegistryKey = local.OpenSubKey("SOFTWARE\LEAD Technologies, Inc.\16")
#Else
         Dim lead As RegistryKey = local.OpenSubKey("SOFTWARE\LEAD Technologies, Inc.\15")
#End If
         Dim dlgImport As ImportDefaultDlg = New ImportDefaultDlg()

         If Not lead Is Nothing Then
            Dim keys As String() = lead.GetSubKeyNames()

            For Each key As String In keys
               If key.IndexOf("14.0") <> -1 Then
                  Dim app As RegistryKey = lead.OpenSubKey(key)
                  Dim rootDir As String = app.GetValue("RootDir").ToString()
                  Dim files As String() = Nothing

                  files = Directory.GetFiles(rootDir & "\images", "*.dcm")
                  For Each file As String In files
                     importFiles.Add(file)
                  Next file
               End If
            Next key
         End If

         Dim dicomImagesFolder As String = DemosGlobal.ImagesFolder
         If (dicomImagesFolder.Length > 0) Then
            Dim fileName As String = dicomImagesFolder + "\IMAGE1.dcm"
            importFiles.Add(fileName)

            fileName = dicomImagesFolder + "\IMAGE2.dcm"
            importFiles.Add(fileName)

            fileName = dicomImagesFolder + "\IMAGE3.dcm"
            importFiles.Add(fileName)
         End If

         dlgImport.FillFileList(importFiles)
         If dlgImport.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim cursor As WaitCursor = New WaitCursor()

            ' Import LEAD installed dicom files.
            For Each file As String In importFiles
               Dim ret As InsertReturn

               ret = dicomDB.Insert(file)
               Select Case ret
                  Case InsertReturn.Success
                     Logger.Log("Import", file)
                  Case InsertReturn.Exists
                     Logger.Log("Import", file & " not imported.  Record already exists")

                  Case InsertReturn.Error
                     Logger.Log("Import", file & " not imported.  Error during import")
               End Select
            Next file

            ' Import additional directory of files
            If Directory.Exists(dlgImport.AdditionalDir) Then
               Dim userFiles As String()

               userFiles = Directory.GetFiles(dlgImport.AdditionalDir, "*.*")
               For Each file As String In userFiles
                  Dim ret As InsertReturn

                  ret = dicomDB.Insert(file)
                  Select Case ret
                     Case InsertReturn.Success
                        Logger.Log("Import", file)
                     Case InsertReturn.Exists
                        Logger.Log("Import", file & " not imported.  Record already exists")

                     Case InsertReturn.Error
                        Logger.Log("Import", file & " not imported.  Error during import")
                  End Select
               Next file
            End If
         End If
      End Sub

      Private Sub DeleteUser()
         Dim id As String

         If dataGridUsers.CurrentRowIndex = -1 Then
            Return
         End If

         id = usersDB.DB.Tables("Users").Rows(dataGridUsers.CurrentRowIndex)("Id").ToString()
         usersDB.RemoveUser(id)
         usersDB.Save()
      End Sub

      Private Sub toolBarMain_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles toolBarMain.ButtonClick
         Select Case e.Button.Text
            Case "Import"
               Import()
            Case "Clear"
               listViewLog.Items.Clear()
            Case "Active"
               SetServerStatus()
            Case "Options"
               ChangeOptions()
            Case "Add"
               AddUser()
            Case "Modify"
               ModifyUser()
            Case "Delete"
               DeleteUser()
            Case "Association"
               DisplayAssociate()
            Case "Close"
               CloseClient()
            Case "Exit"
               Close()
         End Select
      End Sub

      Private Sub Import()
         Dim dlgOpen As OpenFileDialog = New OpenFileDialog()

         dlgOpen.Title = "Import Dicom File"
         dlgOpen.Filter = "Dicom Files (*.dcm;*.dic)| *.dcm;*.dic|All files (*.*)|*.*"
         dlgOpen.Multiselect = True
         If dlgOpen.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim cursor As WaitCursor = New WaitCursor()
            For Each file As String In dlgOpen.FileNames
               Dim ret As InsertReturn

               ret = dicomDB.Insert(file)
               Select Case ret
                  Case InsertReturn.Success
                     Logger.Log("Import", file)
                  Case InsertReturn.Exists
                     Logger.Log("Import", file & " not imported.  Record already exists")

                  Case InsertReturn.Error
                     Logger.Log("Import", file & " not imported.  Error during import")
               End Select
            Next file
            cursor = Nothing
         End If
      End Sub

      Private Sub SetServerStatus()
         If (Not toolBarButtonActive.Pushed) Then
            StopServer()
         Else
            StartServer()
         End If
      End Sub

      Private Sub StopServer()
         Dim e As CancelEventArgs = New CancelEventArgs()

         MainForm_Closing(Me, e)
         If (Not e.Cancel) OrElse dicomServer.Clients.Count = 0 Then
            dicomServer.Clients.Clear()
            listViewClients.Items.Clear()
            dicomServer.Close()
            Logger.Log("Shutdown", "Server stopped")
            toolBarButtonActive.Pushed = False
         End If
      End Sub

      Private Sub StartServer()
         Dim ret As DicomExceptionCode

         ret = dicomServer.Listen()
         toolBarButtonActive.Pushed = (ret = DicomExceptionCode.Success)
      End Sub

      Private Sub AddTableStyles(ByVal dg As DataGrid, ByVal db As DBBase)
         For Each table As DataTable In db.DB.Tables
            Dim style As DataGridTableStyle = New DataGridTableStyle()

            style.MappingName = table.TableName
            dg.DataMember = table.TableName
            dg.TableStyles.Add(style)
         Next table
      End Sub

      Private Sub RemoveColumn(ByVal dg As DataGrid, ByVal table As String, ByVal column As String)
         Dim style As DataGridTableStyle = dg.TableStyles(table)

         If Not style Is Nothing Then
            Dim gridColumn As DataGridColumnStyle = style.GridColumnStyles(column)

            If Not gridColumn Is Nothing Then
               style.GridColumnStyles.Remove(gridColumn)
            End If
         End If
      End Sub

      Public Sub Log(ByVal action As String, ByVal text As String)
         If Me.InvokeRequired Then
            Me.Invoke(New LogDelegate(AddressOf Logger.Log), New Object() {action, text})
         Else
            Logger.Log(action, text)
         End If
      End Sub

      Public Sub Log(ByVal action As String, ByVal text As String, ByVal tag As Object)
         If Me.InvokeRequired Then
            Me.Invoke(New LogTagDelegate(AddressOf Logger.Log), New Object() {action, text, tag})
         Else
            Logger.Log(action, text, tag)
         End If
      End Sub


      Private Sub Application_ApplicationExit(ByVal sender As Object, ByVal e As EventArgs)
         Utils.EngineShutdown()
         Utils.DicomNetShutdown()
      End Sub

      Private Sub datagrid_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dataGridDicom.CurrentCellChanged, dataGridUsers.CurrentCellChanged
         Dim dg As DataGrid = TryCast(sender, DataGrid)

         dg.Select(dg.CurrentCell.RowNumber)
      End Sub

      Private Sub tabControlServer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabControlServer.SelectedIndexChanged
         Dim page As TabPage = tabControlServer.TabPages(tabControlServer.SelectedIndex)
         Dim enable As Boolean = page.Text = "Users"

         toolBarButtonUserAdd.Enabled = enable
         toolBarButtonUserModify.Enabled = enable
         toolBarButtonDelete.Enabled = enable

         enable = page.Text = "Clients"
         toolBarButtonDisconnect.Enabled = enable And listViewClients.SelectedItems.Count > 0
         toolBarButtonAssociation.Enabled = enable And listViewClients.SelectedItems.Count > 0
      End Sub

      ''' <summary>
      ''' Add client to the client list view.
      ''' </summary>
      ''' <param name="hClient">Client network handle.</param>
      ''' <param name="ipAddress">Client ip address.</param>
      ''' <param name="time">Date & time client connected to server.</param>
      Public Sub AddClient(ByVal client As Client, ByVal time As DateTime)
         If Logger.DisableLogging = False Then
            Dim item As ListViewItem

            AddHandler client.Timer.Tick, AddressOf Timer_Tick
            item = listViewClients.Items.Add(client.PeerAddress)
            item.Tag = client
            item.SubItems.Add("")
            item.SubItems.Add(client.PeerAddress)
            item.SubItems.Add(time.ToString())
            item.SubItems.Add("Connect")
            item.Selected = True
         End If
      End Sub

      Public Sub UpdateClient(ByVal client As Client, ByVal aeTitle As String, ByVal action As String)
         Dim item As ListViewItem = FindClient(client)

         If Not item Is Nothing Then
            If aeTitle.Length > 0 Then
               item.SubItems(1).Text = aeTitle
            End If
            item.SubItems(4).Text = action
         End If
      End Sub

      Public Delegate Function FindClientDelegate(ByVal client As Client) As ListViewItem

      Public Function FindClient(ByVal client As Client) As ListViewItem
         If InvokeRequired Then
            Invoke(New FindClientDelegate(AddressOf FindClient), client)
         Else
            For Each item As ListViewItem In listViewClients.Items
               Dim ci As Client = TryCast(item.Tag, Client)

               If ci Is client Then
                  Return item
               End If
            Next item
         End If
         Return Nothing
      End Function

      Public Sub RemoveClient(ByVal client As Client)
         Dim item As ListViewItem = FindClient(client)

         If Not item Is Nothing Then
            Dim ci As Client = TryCast(item.Tag, Client)

            ci.Timer.Stop()
            listViewClients.Items.Remove(item)
         End If
      End Sub

      Public Sub EnableTimer(ByVal client As Client, ByVal aeTitle As String, ByVal enable As Boolean)
         Dim item As ListViewItem = FindClient(client)

         If Not item Is Nothing Then
            Dim ci As Client = TryCast(item.Tag, Client)
            Dim ui As UserInfo = usersDB.LoadUser(client.PeerAddress, aeTitle)

            If enable AndAlso ui.Timeout > 0 Then
               ci.Timer.Interval = (ui.Timeout * 60) * 1000
               ci.Timer.Start()
            Else
               ci.Timer.Stop()
            End If
         End If
      End Sub

      Private Sub Timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
         Dim dt As DicomTimer = TryCast(sender, DicomTimer)
         Dim item As ListViewItem = FindClient(dt.Client)

         If Not item Is Nothing Then
            If dt.Client.IsConnected() Then
               dicomServer.CloseClient(dt.Client)
            End If
            dt.Stop()
            listViewClients.Items.Remove(item)
         End If
      End Sub

      Private Sub CloseClient()
         Dim item As ListViewItem = listViewClients.SelectedItems(0)
         Dim client As Client = TryCast(item.Tag, Client)

         client.Timer.Stop()
         If MessageBox.Show("Forcefully close client?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
            dicomServer.CloseClient(client)
            listViewClients.Items.Remove(item)
         Else
            client.Timer.Start()
         End If
      End Sub

      Private Sub DisplayAssociate()
         Dim item As ListViewItem = listViewClients.SelectedItems(0)
         Dim dlgAssociate As AssociationDlg = New AssociationDlg(TryCast(item.Tag, Client))

         dlgAssociate.ShowDialog(Me)
      End Sub

      Private Sub ChangeOptions()
         Dim dlgOptions As New OptionsDlg()

         '
         ' Initialize server options
         '
         dlgOptions.AETitle = dicomServer.CalledAE
         dlgOptions.ImageDir = dicomServer.ImageDir
         dlgOptions.sIPAddress = dicomServer.IPAddress
         dlgOptions.Port = dicomServer.Port
         dlgOptions.Timeout = dicomServer.Timeout
         dlgOptions.MaxClients = dicomServer.Peers
         dlgOptions.IsSecure = dicomServer.IsSecure

#If LEADTOOLS_V17_OR_LATER Then
         dlgOptions.IpType = dicomServer.IpType
#End If

         '
         ' Initialize log options
         '
         dlgOptions.SaveCSReceived = dicomServer.SaveCSReceived
         dlgOptions.SaveDSReceived = dicomServer.SaveDSReceived
         dlgOptions.SaveDSSent = dicomServer.SaveDSSent
         dlgOptions.LogDir = dicomServer.LogDir
         dlgOptions.DisableLogging = Logger.DisableLogging

         If dlgOptions.ShowDialog() = DialogResult.OK Then
            Dim restart As Boolean = False

            dicomServer.CalledAE = dlgOptions.AETitle
            dicomServer.Timeout = dlgOptions.Timeout
            dicomServer.ImageDir = dlgOptions.ImageDir
            dicomDB.ImageDir = dicomServer.ImageDir

#If LEADTOOLS_V17_OR_LATER Then
            If dicomServer.IpType <> dlgOptions.IpType Then
               restart = True
               dicomServer.IpType = dlgOptions.IpType
            End If
#End If

            If dicomServer.IPAddress <> dlgOptions.sIPAddress Then
               restart = True
               dicomServer.IPAddress = dlgOptions.sIPAddress
            End If

            If dicomServer.Port <> dlgOptions.Port Then
               restart = True
               dicomServer.Port = dlgOptions.Port
            End If

            If dicomServer.Peers <> dlgOptions.MaxClients Then
               restart = True
               dicomServer.Peers = dlgOptions.MaxClients
            End If
            If dlgOptions.IsSecure <> dicomServer.IsSecure Then
               restart = True
               dicomServer.IsSecure = dlgOptions.IsSecure
            End If

            If restart Then
               StopServer()
               StartServer()
            End If

            dicomServer.SaveCSReceived = dlgOptions.SaveCSReceived
            dicomServer.SaveDSReceived = dlgOptions.SaveDSReceived
            dicomServer.SaveDSSent = dlgOptions.SaveDSSent
            dicomServer.LogDir = dlgOptions.LogDir
            Logger.DisableLogging = dlgOptions.DisableLogging
         End If
      End Sub

      Private Sub MainForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
         If dicomServer.Clients.Count > 0 Then
            Dim msg As String

            If dicomServer.Clients.Count > 1 Then
               msg = "There are " & dicomServer.Clients.Count.ToString() & " connected!  Do you wish to shutdown?"
            Else
               msg = "There is 1 client connected! Do you wish to shutdown?"
            End If

            tabControlServer.SelectedTab = tabPageClients
            e.Cancel = MessageBox.Show(msg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No
            If Not e.Cancel Then
               ForceCloseClients()
            End If
         End If
      End Sub

      Private Sub ForceCloseClients()
         If dicomServer.Clients.Count > 0 Then
            For Each client As KeyValuePair(Of String, Client) In dicomServer.Clients
               If client.Value.IsConnected() Then
                  client.Value.CloseForced(True)
               End If
               client.Value.Terminate()
            Next
         End If
      End Sub

      Private ReadOnly Property Is64() As Boolean
         Get
            Return IntPtr.Size = 8
         End Get
      End Property

      Private Sub LoadSettings()
         Dim user As RegistryKey = Registry.CurrentUser

         Dim settingsString As String
#If LTV20_CONFIG Then
         settingsString = "SOFTWARE\LEAD Technologies, Inc.\20\DICOMSVRCSHAR20_Dotnet4"
#End If
         If Is64 Then
            settingsString &= "_x64"
         End If

         Dim settings As RegistryKey = user.OpenSubKey(settingsString, True)
         If settings Is Nothing Then
            ' We haven't saved any setting yet. Will use the default settings.
            Return
         End If

         dicomServer.CalledAE = Convert.ToString(settings.GetValue("AETitle", "LEAD_SERVER"))
         dicomServer.Port = Convert.ToInt32(settings.GetValue("Port", 104))
         dicomServer.Peers = Convert.ToInt32(settings.GetValue("Peers", 5))
         dicomServer.IPAddress = Convert.ToString(settings.GetValue("IPAddress"))
         Dim sValue As String = Convert.ToString(settings.GetValue("IpType"))
         If String.IsNullOrEmpty(sValue) Then
            dicomServer.IpType = DicomNetIpTypeFlags.Ipv4
         Else
            dicomServer.IpType = CType(DemosGlobal.StringToEnum(GetType(DicomNetIpTypeFlags), sValue), DicomNetIpTypeFlags)
         End If
         dicomServer.Timeout = Convert.ToInt32(settings.GetValue("Timeout", 0))
         dicomServer.LogDir = Convert.ToString(settings.GetValue("LogDir"))
         dicomServer.ImageDir = Convert.ToString(settings.GetValue("ImageDir"))
         dicomServer.SaveCSReceived = Convert.ToBoolean(settings.GetValue("SaveCSReceived"))
         dicomServer.SaveDSReceived = Convert.ToBoolean(settings.GetValue("SaveDSReceived"))
         dicomServer.SaveDSSent = Convert.ToBoolean(settings.GetValue("SaveDSSent"))
         Logger.DisableLogging = Convert.ToBoolean(settings.GetValue("DisableLogging"))
      End Sub

      Private Sub SaveSettings()
         Dim user As RegistryKey = Registry.CurrentUser
         Dim settingsString As String
#If LTV20_CONFIG Then
         settingsString = "SOFTWARE\LEAD Technologies, Inc.\20\DICOMSVRCSHAR20_Dotnet4"
#End If
         If Is64 Then
            settingsString &= "_x64"
         End If

         Dim settings As RegistryKey = user.OpenSubKey(settingsString, True)
         If settings Is Nothing Then
            ' We haven't saved any setting yet. Will use the default settings.
            Return
         End If

         If settings Is Nothing Then
            settings = user.CreateSubKey(settingsString)
         End If

         settings.SetValue("AETitle", dicomServer.CalledAE)
         settings.SetValue("Port", dicomServer.Port)
         settings.SetValue("Peers", dicomServer.Peers)
         settings.SetValue("IPAddress", dicomServer.IPAddress)
         settings.SetValue("Timeout", dicomServer.Timeout)
         settings.SetValue("LogDir", dicomServer.LogDir)
         settings.SetValue("ImageDir", dicomServer.ImageDir)
         settings.SetValue("SaveCSReceived", dicomServer.SaveCSReceived)
         settings.SetValue("SaveDSReceived", dicomServer.SaveDSReceived)
         settings.SetValue("SaveDSSent", dicomServer.SaveDSSent)
         settings.SetValue("DisableLogging", Logger.DisableLogging)
         settings.Close()
      End Sub

      Private Sub MainForm_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
         SaveSettings()
      End Sub

      Private Sub listViewLog_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles listViewLog.DoubleClick
         Dim file As String

         If listViewLog.SelectedItems.Count = 0 Then
            Return
         End If

         file = TryCast(listViewLog.SelectedItems(0).Tag, String)
         If Not file Is Nothing AndAlso file.Length > 0 Then
            Dim dlgInfo As DicomInfoDlg = New DicomInfoDlg()

            If dlgInfo.UpdateTree(file) = DicomExceptionCode.Success Then
               dlgInfo.ShowDialog(Me)
            End If
         End If
      End Sub

      Public Function GetSelectedRows(ByVal dg As DataGrid) As ArrayList
         Dim al As ArrayList = New ArrayList()
         Dim cm As CurrencyManager = CType(Me.BindingContext(dg.DataSource, dg.DataMember), CurrencyManager)
         Dim dv As DataView = CType(cm.List, DataView)

         Dim i As Integer = 0
         Do While i < dv.Count

            If dg.IsSelected(i) Then
               al.Add(i)
            End If
            i += 1
         Loop

         Return al
      End Function

      Private Sub dataGridDicom_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dataGridDicom.KeyDown
         Dim rows As ArrayList = GetSelectedRows(dataGridDicom)

         If e.KeyCode = Keys.Delete AndAlso rows.Count > 0 Then
            Dim table As String = ""
            Dim field As String = ""

            Select Case dataGridDicom.DataMember
               Case "Patients"
                  table = "Patients"
                  field = "PatientID"

               Case "Patients.Studies"
                  table = "Studies"
                  field = "StudyInstanceUID"

               Case "Patients.Studies.Series"
                  table = "Series"
                  field = "SeriesInstanceUID"

               Case "Patients.Studies.Series.Images"
                  table = "Images"
                  field = "SOPInstanceUID"

            End Select

            For Each row As Integer In rows
               Dim key As String

               key = dicomDB.DB.Tables(table).Rows(row)(field).ToString()
               dicomDB.Delete(table, field, key)
            Next row

            dicomDB.Save()
         End If
      End Sub
   End Class
End Namespace
