' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Net
Imports System.Configuration

Imports Microsoft.Win32

Imports Leadtools
Imports Leadtools.Dicom
Imports Leadtools.Controls
Imports Leadtools.DicomDemos
Imports Leadtools.DicomDemos.Scu
Imports Leadtools.DicomDemos.Scu.CFind
Imports Leadtools.Demos.Dialogs

Namespace DicomDemo
   ''' <summary>
   ''' Summary description for Form1.
   ''' </summary>
   Public Class MainForm : Inherits System.Windows.Forms.Form
      Private panel1 As System.Windows.Forms.Panel
      Private label1 As System.Windows.Forms.Label
      Private WithEvents propertyGridSearch As System.Windows.Forms.PropertyGrid
      Private panel2 As System.Windows.Forms.Panel
      Private WithEvents buttonSearch As System.Windows.Forms.Button
      Private splitter1 As System.Windows.Forms.Splitter
      Private components As System.ComponentModel.IContainer
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>

      Private query As CFindQuery = New CFindQuery()
      Private panel3 As System.Windows.Forms.Panel
      Private splitter2 As System.Windows.Forms.Splitter
      Private panel4 As System.Windows.Forms.Panel
      Private label2 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private WithEvents buttonOptions As System.Windows.Forms.Button
      Private cfind As CFind = New CFind()
      Private dcmQuery As CFindQuery = New CFindQuery()

      Private server As DicomServer = New DicomServer()
      Private AETitle As String = "CLIENT1"
      Private GroupLengthDataElements As Boolean = False

      Private mainMenu1 As System.Windows.Forms.MainMenu
      Private menuItem1 As System.Windows.Forms.MenuItem
      Private WithEvents menuItemFileExit As System.Windows.Forms.MenuItem
      Private WithEvents listViewStudies As System.Windows.Forms.ListView
      Private columnHeader1 As System.Windows.Forms.ColumnHeader
      Private columnHeader2 As System.Windows.Forms.ColumnHeader
      Private columnHeader3 As System.Windows.Forms.ColumnHeader
      Private columnHeader4 As System.Windows.Forms.ColumnHeader
      Private columnHeader5 As System.Windows.Forms.ColumnHeader
      Private columnHeader6 As System.Windows.Forms.ColumnHeader
      Private WithEvents listViewSeries As System.Windows.Forms.ListView
      Private columnHeader7 As System.Windows.Forms.ColumnHeader
      Private columnHeader8 As System.Windows.Forms.ColumnHeader
      Private columnHeader9 As System.Windows.Forms.ColumnHeader
      Private columnHeader10 As System.Windows.Forms.ColumnHeader
      Private panel5 As System.Windows.Forms.Panel
      Private splitter3 As System.Windows.Forms.Splitter
      Private label4 As System.Windows.Forms.Label
      Private WithEvents panel6 As System.Windows.Forms.Panel
      Private splitter4 As System.Windows.Forms.Splitter
      Private columnHeader11 As System.Windows.Forms.ColumnHeader
      Private Log As System.Windows.Forms.RichTextBox
      Private label5 As System.Windows.Forms.Label
      Private WithEvents menuItemClearLog As System.Windows.Forms.MenuItem
      Private menuItem3 As System.Windows.Forms.MenuItem
      Private WithEvents menuItemHelp As System.Windows.Forms.MenuItem
      Private WithEvents menuItemAbout As System.Windows.Forms.MenuItem
      Private WithEvents ImageList As ImageViewer
      Private Port As Integer = 1000

      Private Const CONFIGURATION_IMPLEMENTATIONCLASS As String = "1.2.840.114257.1123456"
      Private Const CONFIGURATION_IMPLEMENTATIONVERSIONNAME As String = "1"
      Friend WithEvents menuItemOptions As System.Windows.Forms.MenuItem
      Friend WithEvents menuItemIPv4 As System.Windows.Forms.MenuItem
      Friend WithEvents menuItemIPv6 As System.Windows.Forms.MenuItem
      Friend WithEvents menuItemIpv4Ipv6 As System.Windows.Forms.MenuItem
      Private Const CONFIGURATION_PROTOCOLVERSION As String = "1"
    
        Private _settingsLocation As String = "SOFTWARE\LEAD Technologies, Inc.\17\VBNet_DicomFindMove17"

      Private _ipType As DicomNetIpTypeFlags = DicomNetIpTypeFlags.Ipv4


      Public Delegate Sub AddLog(ByVal action As String, ByVal logText As String)

      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()
      End Sub

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            If Not components Is Nothing Then
               components.Dispose()
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
         Dim _imageViewerHorizontalViewLayout As ImageViewerHorizontalViewLayout = New ImageViewerHorizontalViewLayout()
         _imageViewerHorizontalViewLayout.Rows = 1
         Me.components = New System.ComponentModel.Container
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me.panel1 = New System.Windows.Forms.Panel
         Me.propertyGridSearch = New System.Windows.Forms.PropertyGrid
         Me.label1 = New System.Windows.Forms.Label
         Me.panel2 = New System.Windows.Forms.Panel
         Me.buttonSearch = New System.Windows.Forms.Button
         Me.buttonOptions = New System.Windows.Forms.Button
         Me.splitter1 = New System.Windows.Forms.Splitter
         Me.panel3 = New System.Windows.Forms.Panel
         Me.listViewStudies = New System.Windows.Forms.ListView
         Me.columnHeader1 = New System.Windows.Forms.ColumnHeader
         Me.columnHeader2 = New System.Windows.Forms.ColumnHeader
         Me.columnHeader3 = New System.Windows.Forms.ColumnHeader
         Me.columnHeader4 = New System.Windows.Forms.ColumnHeader
         Me.columnHeader5 = New System.Windows.Forms.ColumnHeader
         Me.columnHeader6 = New System.Windows.Forms.ColumnHeader
         Me.label2 = New System.Windows.Forms.Label
         Me.splitter2 = New System.Windows.Forms.Splitter
         Me.panel4 = New System.Windows.Forms.Panel
         Me.listViewSeries = New System.Windows.Forms.ListView
         Me.columnHeader7 = New System.Windows.Forms.ColumnHeader
         Me.columnHeader8 = New System.Windows.Forms.ColumnHeader
         Me.columnHeader9 = New System.Windows.Forms.ColumnHeader
         Me.columnHeader10 = New System.Windows.Forms.ColumnHeader
         Me.columnHeader11 = New System.Windows.Forms.ColumnHeader
         Me.label3 = New System.Windows.Forms.Label
         Me.mainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
         Me.menuItem1 = New System.Windows.Forms.MenuItem
         Me.menuItemClearLog = New System.Windows.Forms.MenuItem
         Me.menuItem3 = New System.Windows.Forms.MenuItem
         Me.menuItemFileExit = New System.Windows.Forms.MenuItem
         Me.menuItemOptions = New System.Windows.Forms.MenuItem
         Me.menuItemIPv4 = New System.Windows.Forms.MenuItem
         Me.menuItemIPv6 = New System.Windows.Forms.MenuItem
         Me.menuItemIpv4Ipv6 = New System.Windows.Forms.MenuItem
         Me.menuItemHelp = New System.Windows.Forms.MenuItem
         Me.menuItemAbout = New System.Windows.Forms.MenuItem
         Me.panel5 = New System.Windows.Forms.Panel
         Me.Log = New System.Windows.Forms.RichTextBox
         Me.label4 = New System.Windows.Forms.Label
         Me.splitter3 = New System.Windows.Forms.Splitter
         Me.panel6 = New System.Windows.Forms.Panel
         Me.ImageList = New Leadtools.Controls.ImageViewer(_imageViewerHorizontalViewLayout)
         Me.label5 = New System.Windows.Forms.Label
         Me.splitter4 = New System.Windows.Forms.Splitter
         Me.panel1.SuspendLayout()
         Me.panel2.SuspendLayout()
         Me.panel3.SuspendLayout()
         Me.panel4.SuspendLayout()
         Me.panel5.SuspendLayout()
         Me.panel6.SuspendLayout()
         Me.SuspendLayout()
         '
         'panel1
         '
         Me.panel1.Controls.Add(Me.propertyGridSearch)
         Me.panel1.Controls.Add(Me.label1)
         Me.panel1.Controls.Add(Me.panel2)
         Me.panel1.Dock = System.Windows.Forms.DockStyle.Left
         Me.panel1.Location = New System.Drawing.Point(0, 0)
         Me.panel1.Name = "panel1"
         Me.panel1.Size = New System.Drawing.Size(192, 713)
         Me.panel1.TabIndex = 0
         '
         'propertyGridSearch
         '
         Me.propertyGridSearch.Cursor = System.Windows.Forms.Cursors.HSplit
         Me.propertyGridSearch.Dock = System.Windows.Forms.DockStyle.Fill
         Me.propertyGridSearch.HelpVisible = False
         Me.propertyGridSearch.LineColor = System.Drawing.SystemColors.ScrollBar
         Me.propertyGridSearch.Location = New System.Drawing.Point(0, 16)
         Me.propertyGridSearch.Name = "propertyGridSearch"
         Me.propertyGridSearch.PropertySort = System.Windows.Forms.PropertySort.Categorized
         Me.propertyGridSearch.Size = New System.Drawing.Size(192, 657)
         Me.propertyGridSearch.TabIndex = 1
         '
         'label1
         '
         Me.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me.label1.Dock = System.Windows.Forms.DockStyle.Top
         Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.label1.Location = New System.Drawing.Point(0, 0)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(192, 16)
         Me.label1.TabIndex = 0
         Me.label1.Text = "Search Params:"
         '
         'panel2
         '
         Me.panel2.Controls.Add(Me.buttonSearch)
         Me.panel2.Controls.Add(Me.buttonOptions)
         Me.panel2.Dock = System.Windows.Forms.DockStyle.Bottom
         Me.panel2.Location = New System.Drawing.Point(0, 673)
         Me.panel2.Name = "panel2"
         Me.panel2.Size = New System.Drawing.Size(192, 40)
         Me.panel2.TabIndex = 2
         '
         'buttonSearch
         '
         Me.buttonSearch.Dock = System.Windows.Forms.DockStyle.Fill
         Me.buttonSearch.Location = New System.Drawing.Point(75, 0)
         Me.buttonSearch.Name = "buttonSearch"
         Me.buttonSearch.Size = New System.Drawing.Size(117, 40)
         Me.buttonSearch.TabIndex = 0
         Me.buttonSearch.Text = "Search"
         '
         'buttonOptions
         '
         Me.buttonOptions.Dock = System.Windows.Forms.DockStyle.Left
         Me.buttonOptions.Location = New System.Drawing.Point(0, 0)
         Me.buttonOptions.Name = "buttonOptions"
         Me.buttonOptions.Size = New System.Drawing.Size(75, 40)
         Me.buttonOptions.TabIndex = 1
         Me.buttonOptions.Text = "Options"
         '
         'splitter1
         '
         Me.splitter1.Location = New System.Drawing.Point(192, 0)
         Me.splitter1.Name = "splitter1"
         Me.splitter1.Size = New System.Drawing.Size(3, 713)
         Me.splitter1.TabIndex = 1
         Me.splitter1.TabStop = False
         '
         'panel3
         '
         Me.panel3.Controls.Add(Me.listViewStudies)
         Me.panel3.Controls.Add(Me.label2)
         Me.panel3.Dock = System.Windows.Forms.DockStyle.Top
         Me.panel3.Location = New System.Drawing.Point(195, 0)
         Me.panel3.Name = "panel3"
         Me.panel3.Size = New System.Drawing.Size(693, 208)
         Me.panel3.TabIndex = 2
         '
         'listViewStudies
         '
         Me.listViewStudies.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2, Me.columnHeader3, Me.columnHeader4, Me.columnHeader5, Me.columnHeader6})
         Me.listViewStudies.Dock = System.Windows.Forms.DockStyle.Fill
         Me.listViewStudies.FullRowSelect = True
         Me.listViewStudies.GridLines = True
         Me.listViewStudies.HideSelection = False
         Me.listViewStudies.Location = New System.Drawing.Point(0, 16)
         Me.listViewStudies.Name = "listViewStudies"
         Me.listViewStudies.Size = New System.Drawing.Size(693, 192)
         Me.listViewStudies.TabIndex = 0
         Me.listViewStudies.UseCompatibleStateImageBehavior = False
         Me.listViewStudies.View = System.Windows.Forms.View.Details
         '
         'columnHeader1
         '
         Me.columnHeader1.Text = "Patient Name"
         '
         'columnHeader2
         '
         Me.columnHeader2.Text = "Patient ID"
         '
         'columnHeader3
         '
         Me.columnHeader3.Text = "Accession #"
         '
         'columnHeader4
         '
         Me.columnHeader4.Text = "Study Date"
         '
         'columnHeader5
         '
         Me.columnHeader5.Text = "Refer Dr Name"
         '
         'columnHeader6
         '
         Me.columnHeader6.Text = "Description"
         '
         'label2
         '
         Me.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me.label2.Dock = System.Windows.Forms.DockStyle.Top
         Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.label2.Location = New System.Drawing.Point(0, 0)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(693, 16)
         Me.label2.TabIndex = 1
         Me.label2.Text = "Studies Found: (Select item to retrieve series)"
         '
         'splitter2
         '
         Me.splitter2.Dock = System.Windows.Forms.DockStyle.Top
         Me.splitter2.Location = New System.Drawing.Point(195, 208)
         Me.splitter2.Name = "splitter2"
         Me.splitter2.Size = New System.Drawing.Size(693, 3)
         Me.splitter2.TabIndex = 3
         Me.splitter2.TabStop = False
         '
         'panel4
         '
         Me.panel4.Controls.Add(Me.listViewSeries)
         Me.panel4.Controls.Add(Me.label3)
         Me.panel4.Dock = System.Windows.Forms.DockStyle.Top
         Me.panel4.Location = New System.Drawing.Point(195, 211)
         Me.panel4.Name = "panel4"
         Me.panel4.Size = New System.Drawing.Size(693, 219)
         Me.panel4.TabIndex = 4
         '
         'listViewSeries
         '
         Me.listViewSeries.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader7, Me.columnHeader8, Me.columnHeader9, Me.columnHeader10, Me.columnHeader11})
         Me.listViewSeries.Dock = System.Windows.Forms.DockStyle.Fill
         Me.listViewSeries.FullRowSelect = True
         Me.listViewSeries.GridLines = True
         Me.listViewSeries.HideSelection = False
         Me.listViewSeries.Location = New System.Drawing.Point(0, 16)
         Me.listViewSeries.Name = "listViewSeries"
         Me.listViewSeries.Size = New System.Drawing.Size(693, 203)
         Me.listViewSeries.TabIndex = 1
         Me.listViewSeries.UseCompatibleStateImageBehavior = False
         Me.listViewSeries.View = System.Windows.Forms.View.Details
         '
         'columnHeader7
         '
         Me.columnHeader7.Text = "Date"
         '
         'columnHeader8
         '
         Me.columnHeader8.Text = "Series Number"
         '
         'columnHeader9
         '
         Me.columnHeader9.Text = "Description"
         '
         'columnHeader10
         '
         Me.columnHeader10.Text = "Modality"
         '
         'columnHeader11
         '
         Me.columnHeader11.Text = "Number of Instances"
         '
         'label3
         '
         Me.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me.label3.Dock = System.Windows.Forms.DockStyle.Top
         Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.label3.Location = New System.Drawing.Point(0, 0)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(693, 16)
         Me.label3.TabIndex = 0
         Me.label3.Text = "Series Found: (Double click to retrieve images)"
         '
         'mainMenu1
         '
         Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItem1, Me.menuItemOptions, Me.menuItemHelp})
         '
         'menuItem1
         '
         Me.menuItem1.Index = 0
         Me.menuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemClearLog, Me.menuItem3, Me.menuItemFileExit})
         Me.menuItem1.Text = "&File"
         '
         'menuItemClearLog
         '
         Me.menuItemClearLog.Index = 0
         Me.menuItemClearLog.Text = "&Clear Log"
         '
         'menuItem3
         '
         Me.menuItem3.Index = 1
         Me.menuItem3.Text = "-"
         '
         'menuItemFileExit
         '
         Me.menuItemFileExit.Index = 2
         Me.menuItemFileExit.Shortcut = System.Windows.Forms.Shortcut.AltF4
         Me.menuItemFileExit.Text = "&Exit"
         '
         'menuItemOptions
         '
         Me.menuItemOptions.Index = 1
         Me.menuItemOptions.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemIPv4, Me.menuItemIPv6, Me.menuItemIpv4Ipv6})
         Me.menuItemOptions.Text = "&Options"
         '
         'menuItemIPv4
         '
         Me.menuItemIPv4.Index = 0
         Me.menuItemIPv4.Text = "IPv4"
         '
         'menuItemIPv6
         '
         Me.menuItemIPv6.Index = 1
         Me.menuItemIPv6.Text = "IPv6"
         '
         'menuItemIpv4Ipv6
         '
         Me.menuItemIpv4Ipv6.Index = 2
         Me.menuItemIpv4Ipv6.Text = "IPv4 or IPv6"
         '
         'menuItemHelp
         '
         Me.menuItemHelp.Index = 2
         Me.menuItemHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemAbout})
         Me.menuItemHelp.Text = "&Help"
         '
         'menuItemAbout
         '
         Me.menuItemAbout.Index = 0
         Me.menuItemAbout.Text = "&About"
         '
         'panel5
         '
         Me.panel5.Controls.Add(Me.Log)
         Me.panel5.Controls.Add(Me.label4)
         Me.panel5.Dock = System.Windows.Forms.DockStyle.Bottom
         Me.panel5.Location = New System.Drawing.Point(195, 593)
         Me.panel5.Name = "panel5"
         Me.panel5.Size = New System.Drawing.Size(693, 120)
         Me.panel5.TabIndex = 5
         '
         'Log
         '
         Me.Log.Dock = System.Windows.Forms.DockStyle.Fill
         Me.Log.Location = New System.Drawing.Point(0, 16)
         Me.Log.Name = "Log"
         Me.Log.ReadOnly = True
         Me.Log.Size = New System.Drawing.Size(693, 104)
         Me.Log.TabIndex = 1
         Me.Log.Text = ""
         '
         'label4
         '
         Me.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me.label4.Dock = System.Windows.Forms.DockStyle.Top
         Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.label4.Location = New System.Drawing.Point(0, 0)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(693, 16)
         Me.label4.TabIndex = 0
         Me.label4.Text = "Log:"
         '
         'splitter3
         '
         Me.splitter3.Dock = System.Windows.Forms.DockStyle.Bottom
         Me.splitter3.Location = New System.Drawing.Point(195, 591)
         Me.splitter3.Name = "splitter3"
         Me.splitter3.Size = New System.Drawing.Size(693, 2)
         Me.splitter3.TabIndex = 6
         Me.splitter3.TabStop = False
         '
         'panel6
         '
         Me.panel6.Controls.Add(Me.ImageList)
         Me.panel6.Controls.Add(Me.label5)
         Me.panel6.Dock = System.Windows.Forms.DockStyle.Fill
         Me.panel6.Location = New System.Drawing.Point(195, 430)
         Me.panel6.Name = "panel6"
         Me.panel6.Size = New System.Drawing.Size(693, 161)
         Me.panel6.TabIndex = 7
         '
         'ImageList
         '
         Me.ImageList.AutoDisposeImages = False
         Me.ImageList.Dock = System.Windows.Forms.DockStyle.Top
         Me.ImageList.Location = New System.Drawing.Point(0, 16)
         Me.ImageList.Name = "ImageList"
         Me.ImageList.Size = New System.Drawing.Size(693, 64)
         Me.ImageList.TabIndex = 7
         '
         'label5
         '
         Me.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me.label5.Dock = System.Windows.Forms.DockStyle.Top
         Me.label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.label5.Location = New System.Drawing.Point(0, 0)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(693, 16)
         Me.label5.TabIndex = 0
         Me.label5.Text = "Images:"
         '
         'splitter4
         '
         Me.splitter4.Dock = System.Windows.Forms.DockStyle.Top
         Me.splitter4.Location = New System.Drawing.Point(195, 430)
         Me.splitter4.Name = "splitter4"
         Me.splitter4.Size = New System.Drawing.Size(693, 3)
         Me.splitter4.TabIndex = 8
         Me.splitter4.TabStop = False
         '
         'MainForm
         '
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(888, 713)
         Me.Controls.Add(Me.splitter4)
         Me.Controls.Add(Me.panel6)
         Me.Controls.Add(Me.panel4)
         Me.Controls.Add(Me.splitter3)
         Me.Controls.Add(Me.panel5)
         Me.Controls.Add(Me.splitter2)
         Me.Controls.Add(Me.panel3)
         Me.Controls.Add(Me.splitter1)
         Me.Controls.Add(Me.panel1)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.Menu = Me.mainMenu1
         Me.MinimumSize = New System.Drawing.Size(640, 480)
         Me.Name = "MainForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "LEADTOOLS Dicom Client Demo - VB.NET"
         Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
         Me.panel1.ResumeLayout(False)
         Me.panel2.ResumeLayout(False)
         Me.panel3.ResumeLayout(False)
         Me.panel4.ResumeLayout(False)
         Me.panel5.ResumeLayout(False)
         Me.panel6.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub
#End Region

      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      <STAThread()> _
      Shared Sub Main(ByVal  args As String())

         

         If Not Support.SetLicense() Then
            Return
         End If

         If (RasterSupport.IsLocked(RasterSupportType.DicomCommunication)) Then
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.DicomCommunication.ToString()), "Warning")
            Return
         End If


        If DemosGlobal.MustRestartElevated() Then
            DemosGlobal.TryRestartElevated(args)
            Return
        End If

            Utils.EngineStartup()
            Utils.DicomNetStartup()

            Try
                Application.Run(New MainForm())
            Catch e1 As Exception
            Finally
                Utils.EngineShutdown()
                Utils.DicomNetShutdown()
            End Try
      End Sub

      ' Raster viewer object.
      Private _viewer As ImageViewer

      Private Sub LoadSettings()
         Dim user As RegistryKey = Registry.CurrentUser
         Dim settings As RegistryKey = user.OpenSubKey(_settingsLocation, True)
         If settings Is Nothing Then
            '
                ' We haven't saved any setting yet.  Will use the default
                '  settings.
                Return
            End If

            server.AETitle = Convert.ToString(settings.GetValue("ServerAE"))
         server.Port = Convert.ToInt32(settings.GetValue("ServerPort", 104))
         GroupLengthDataElements = Convert.ToBoolean(settings.GetValue("GroupLengthDataElements", False))

            Dim sValue As String = Convert.ToString(settings.GetValue("ServerIpType"))
            If String.IsNullOrEmpty(sValue) Then
                server.IpType = DicomNetIpTypeFlags.Ipv4
            Else
                server.IpType = CType(DemosGlobal.StringToEnum(GetType(DicomNetIpTypeFlags), sValue), DicomNetIpTypeFlags)
            End If
            _ipType = server.IpType

            server.Address = IPAddress.Parse(Convert.ToString(settings.GetValue("ServerAddress", "127.0.0.1")))
            server.Timeout = Convert.ToInt32(settings.GetValue("ServerTimeout", 0))
         AETitle = Convert.ToString(settings.GetValue("ClientAE"))
         Port = Convert.ToInt32(settings.GetValue("ClientPort", 1000))
      End Sub

      Private Sub SaveSettings()
         Dim user As RegistryKey = Registry.CurrentUser
         Dim settings As RegistryKey = user.OpenSubKey(_settingsLocation, True)
         If settings Is Nothing Then
            settings = user.CreateSubKey(_settingsLocation)
         End If

         settings.SetValue("ServerAE", server.AETitle)
            settings.SetValue("ServerPort", server.Port)
            settings.SetValue("ServerAddress", server.Address.ToString())
            settings.SetValue("ServerTimeout", server.Timeout)
            settings.SetValue("ClientAE", AETitle)
            settings.SetValue("ClientPort", Port)

         settings.SetValue("ServerIpType", server.IpType.ToString())
         settings.SetValue("GroupLengthDataElements", GroupLengthDataElements)

            settings.Close()
      End Sub

      Private Sub UpdateCFindOptions()
#If LEADTOOLS_V19_OR_LATER Then
         cfind.Flags = DicomNetFlags.None
         If GroupLengthDataElements Then
            cfind.Flags = cfind.Flags Or DicomNetFlags.SendDataWithGroupLengthStandardDataElements
         End If
#End If
      End Sub

        Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
#If LTV19_CONFIG Then
         _settingsLocation = "SOFTWARE\LEAD Technologies, Inc.\19\VBNet_DicomFindMove19"
#ElseIf LTV20_CONFIG Then
         _settingsLocation = "SOFTWARE\LEAD Technologies, Inc.\20\VBNet_DicomFindMove20"
#End If

         ' Initialize the raster viewer object
         _viewer = New ImageViewer()
         _viewer.Dock = DockStyle.Fill
         panel6.Controls.Add(_viewer)
         _viewer.BringToFront()

         cfind.ImplementationClass = CONFIGURATION_IMPLEMENTATIONCLASS
         cfind.ProtocolVersion = CONFIGURATION_PROTOCOLVERSION
         cfind.ImplementationVersionName = CONFIGURATION_IMPLEMENTATIONVERSIONNAME
         LoadSettings()
         UpdateCFindOptions()

         SizeColumns(listViewStudies)
         SizeColumns(listViewSeries)

         AddHandler cfind.Status, AddressOf cfind_Status
         AddHandler cfind.FindComplete, AddressOf cfind_FindComplete
         AddHandler cfind.MoveComplete, AddressOf cfind_MoveComplete
            propertyGridSearch.SelectedObject = query

      End Sub

      Private Sub buttonOptions_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonOptions.Click
         Dim options As OptionsDialog = New OptionsDialog()

         options.ServerIp.Text = server.Address.ToString()
         options.ServerAE.Text = server.AETitle
         options.ServerPort.Text = server.Port.ToString()
         options.Timeout.Text = server.Timeout.ToString()
         options.ClientAE.Text = AETitle
         options.ClientPort.Text = Port.ToString()
         options.GroupLengthDataElements = GroupLengthDataElements
         If options.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            server.AETitle = options.ServerAE.Text
            server.Port = Convert.ToInt32(options.ServerPort.Text)
            server.Address = IPAddress.Parse(options.ServerIp.Text)
            server.Timeout = Convert.ToInt32(options.Timeout.Text)
            AETitle = options.ClientAE.Text
            Port = Convert.ToInt32(options.ClientPort.Text)
            GroupLengthDataElements = options.GroupLengthDataElements
            SaveSettings()
            UpdateCFindOptions()
         End If
      End Sub

      Private Sub menuItemFileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemFileExit.Click
         Application.Exit()
      End Sub

      Private Sub listViewStudies_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles listViewStudies.Resize
         SizeColumns(listViewStudies)
      End Sub

      Private Sub SizeColumns(ByVal lv As ListView)
         For Each header As ColumnHeader In lv.Columns
            header.Width = CInt(lv.Width / lv.Columns.Count)
         Next header
      End Sub

      Private Sub listViewSeries_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles listViewSeries.Resize
         SizeColumns(listViewSeries)
      End Sub

      Private Sub MainForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
         panel3.Height = Convert.ToInt32(ClientSize.Height * 0.15)
         panel4.Height = Convert.ToInt32(ClientSize.Height * 0.15)
         panel5.Height = Convert.ToInt32(ClientSize.Height * 0.15)
         panel6.Height = Convert.ToInt32(ClientSize.Height * 0.55)
      End Sub

      Private Sub buttonSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonSearch.Click
         _viewer.Image = Nothing
         listViewStudies.Items.Clear()
         listViewSeries.Items.Clear()
         ImageList.Items.Clear()
         EnableItems(False)
         cfind.Find(server, FindType.Study, dcmQuery, AETitle)
      End Sub

      Public Sub LogText(ByVal action As String, ByVal logMessage As String)
         If Me.InvokeRequired Then
            Me.Invoke(New AddLog(AddressOf LogText), New Object() {action, logMessage})
         Else
            AddAction(action)
            Log.AppendText(logMessage)
            Log.AppendText(Constants.vbCrLf)
         End If
      End Sub

      Private Sub AddAction(ByVal action As String)
         Dim oldColor As System.Drawing.Color = Log.SelectionColor

         Log.SelectionLength = 0
         Log.SelectionStart = Log.Text.Length
         Log.SelectionColor = Color.Blue
         Log.SelectionFont = New Font(Log.SelectionFont, FontStyle.Bold)
         Log.AppendText(action & ": ")

         Log.SelectionColor = oldColor
      End Sub

      Private Sub cfind_Status(ByVal sender As Object, ByVal e As StatusEventArgs)
         Dim message As String = "Unknown Error"
         Dim action As String = ""
         Dim done As Boolean = False

         If e.Type = StatusType.Error Then
            action = "Error"
            message = "Error occurred." & Constants.vbCrLf
            message &= Constants.vbTab & "Error code is:" & Constants.vbTab + e.Error.ToString()
         Else
            Select Case e.Type
               Case StatusType.ConnectFailed
                  action = "Connect"
                  message = "Operation failed."
                  done = True
               Case StatusType.ConnectSucceeded
                  action = "Connect"
                  message = "Operation succeeded." & Constants.vbCrLf
                  message &= Constants.vbTab & "Peer Address:" & Constants.vbTab + e.PeerIP.ToString() & Constants.vbCrLf
                  message &= Constants.vbTab & "Peer Port:" & Constants.vbTab + Constants.vbTab + e.PeerPort.ToString()
               Case StatusType.SendAssociateRequest
                  action = "Associate Request"
                  message = "Request sent."
               Case StatusType.ReceiveAssociateAccept
                  action = "Associate Accept"
                  message = "Received." & Constants.vbCrLf
                  message &= Constants.vbTab & "Calling AE:" & Constants.vbTab + e.CallingAE & Constants.vbCrLf
                  message &= Constants.vbTab & "Called AE:" & Constants.vbTab + e.CalledAE
               Case StatusType.ReceiveAssociateRequest
                  action = "Associate Request"
                  message = "Received." & Constants.vbCrLf
                  message &= Constants.vbTab & "Calling AE:" & Constants.vbTab + e.CallingAE & Constants.vbCrLf
                  message &= Constants.vbTab & "Called AE:" & Constants.vbTab + e.CalledAE
               Case StatusType.ReceiveAssociateReject
                  action = "Associate Reject"
                  message = "Received Associate Reject!"
                  message += vbCr & vbLf & vbTab & "Source: " & e.Source.ToString()
                  message += vbCr & vbLf & vbTab & "Result: " & e.Result.ToString()
                  message += vbCr & vbLf & vbTab & "Reason: " & e.Reason.ToString()
                  done = True
               Case StatusType.AbstractSyntaxNotSupported
                  action = "Error"
                  message = "Abstract Syntax NOT supported!"
                  done = True
               Case StatusType.SendCFindRequest
                  action = "C-FIND"
                  message = "Sending request"
               Case StatusType.ReceiveCFindResponse
                  action = "C-FIND"
                  If e.Error = DicomExceptionCode.Success Then
                     message = "Operation completed successfully."
                  Else

                     If e.Status = DicomCommandStatusType.Pending Then
                        message = "Additional operations pending."
                     Else
                        message = "Error in response Status code is: " & e.Status.ToString()
                     End If
                  End If
               Case StatusType.ConnectionClosed
                  action = "Connect"
                  message = "Network Connection closed!"
                  done = True
               Case StatusType.ProcessTerminated
                  action = ""
                  message = "Process has been terminated!"
                  done = True
               Case StatusType.SendReleaseRequest
                  action = "Release Request"
                  message = "Request sent."
               Case StatusType.ReceiveReleaseResponse
                  action = "Release Response"
                  message = "Response received."
                  done = True
               Case StatusType.SendCMoveRequest
                  action = "C-MOVE"
                  message = "Sending request"
               Case StatusType.ReceiveCMoveResponse
                  action = "C-MOVE"
                  message = "Received response" & Constants.vbCrLf
                  message &= Constants.vbTab & "Status: " & e.Status.ToString() & Constants.vbCrLf
                  message &= Constants.vbTab & "Number Completed: " & e.NumberCompleted.ToString() & Constants.vbCrLf
                  message &= Constants.vbTab & "Number Remaining: " & e.NumberRemaining.ToString()
               Case StatusType.SendCStoreResponse
                  action = "C-STORE"
                  message = "Sending response"
               Case StatusType.ReceiveCStoreRequest
                  action = "C-STORE"
                  message = "Received request"
               Case StatusType.Timeout
                  message = "Communication timeout. Process will be terminated."
                  done = True
            End Select
         End If
         LogText(action, message)
         If done Then
            EnableItems(True)
         End If
      End Sub

      Private Sub propertyGridSearch_PropertyValueChanged(ByVal s As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles propertyGridSearch.PropertyValueChanged
         Select Case e.ChangedItem.Label
            Case "PatientName"
               dcmQuery.PatientName = e.ChangedItem.Value.ToString()
            Case "PatientID"
               dcmQuery.PatientID = e.ChangedItem.Value.ToString()
            Case "StudyID"
               dcmQuery.StudyID = e.ChangedItem.Value.ToString()
            Case "StudyStartDate"
               dcmQuery.StudyStartDate = CDate(e.ChangedItem.Value)
            Case "StudyEndDate"
               dcmQuery.StudyEndDate = Convert.ToDateTime(e.ChangedItem.Value)
            Case "ReferringPhysiciansName"
               dcmQuery.ReferringPhysiciansName = e.ChangedItem.Value.ToString()
            Case "AccessionNo"
               dcmQuery.AccessionNo = e.ChangedItem.Value.ToString()
            Case "StudyInstanceUid"
               dcmQuery.StudyInstanceUid = e.ChangedItem.Value.ToString()
         End Select
      End Sub

      Public Delegate Sub StartUpdateDelegate(ByVal lv As ListView)
      Private Sub StartUpdate(ByVal lv As ListView)
         If InvokeRequired Then
            Invoke(New StartUpdateDelegate(AddressOf StartUpdate), lv)
         Else
            lv.Items.Clear()
            lv.BeginUpdate()
         End If
      End Sub

      Public Delegate Sub EndUpdateDelegate(ByVal lv As ListView)
      Private Sub EndUpdate(ByVal lv As ListView)
         If InvokeRequired Then
            Invoke(New EndUpdateDelegate(AddressOf EndUpdate), lv)
         Else
            lv.EndUpdate()
         End If
      End Sub

      Public Delegate Sub AddStudyItemDelegate(ByVal ds As DicomDataSet)
      Private Sub AddStudyItem(ByVal ds As DicomDataSet)
         Dim item As ListViewItem
         Dim tagValue As String

         If InvokeRequired Then
            Invoke(New AddStudyItemDelegate(AddressOf AddStudyItem), ds)
         Else
            tagValue = Utils.GetStringValue(ds, DemoDicomTags.PatientName)
            item = listViewStudies.Items.Add(tagValue)

            tagValue = Utils.GetStringValue(ds, DemoDicomTags.PatientID)
            item.SubItems.Add(tagValue)

            tagValue = Utils.GetStringValue(ds, DemoDicomTags.AccessionNumber)
            item.SubItems.Add(tagValue)

            tagValue = Utils.GetStringValue(ds, DemoDicomTags.StudyDate)
            item.SubItems.Add(tagValue)

            tagValue = Utils.GetStringValue(ds, DemoDicomTags.ReferringPhysicianName)
            item.SubItems.Add(tagValue)

            tagValue = Utils.GetStringValue(ds, DemoDicomTags.StudyDescription)
            item.SubItems.Add(tagValue)

            item.Tag = Utils.GetStringValue(ds, DemoDicomTags.StudyInstanceUID)
         End If
      End Sub

      Public Delegate Sub AddSeriesItemDelegate(ByVal ds As DicomDataSet)
      Private Sub AddSeriesItem(ByVal ds As DicomDataSet)
         Dim item As ListViewItem
         Dim tagValue As String

         If InvokeRequired Then
            Invoke(New AddSeriesItemDelegate(AddressOf AddSeriesItem), ds)
         Else
            tagValue = Utils.GetStringValue(ds, DemoDicomTags.SeriesDate)
            item = listViewSeries.Items.Add(tagValue)

            tagValue = Utils.GetStringValue(ds, DemoDicomTags.SeriesNumber)
            item.SubItems.Add(tagValue)

            tagValue = Utils.GetStringValue(ds, DemoDicomTags.SeriesDescription)
            item.SubItems.Add(tagValue)

            tagValue = Utils.GetStringValue(ds, DemoDicomTags.Modality)
            item.SubItems.Add(tagValue)

            tagValue = Utils.GetStringValue(ds, DemoDicomTags.NumberOfSeriesRelatedInstances)
            item.SubItems.Add(tagValue)

            item.Tag = Utils.GetStringValue(ds, DemoDicomTags.SeriesInstanceUID)
         End If
      End Sub

      Private Sub cfind_FindComplete(ByVal sender As Object, ByVal e As FindCompleteEventArgs)
         Select Case e.Type
            Case FindType.Study
               StartUpdate(listViewStudies)
               For Each ds As DicomDataSet In e.Datasets
                  AddStudyItem(ds)
               Next ds
               EndUpdate(listViewStudies)

            Case FindType.StudySeries
               StartUpdate(listViewSeries)
               For Each ds As DicomDataSet In e.Datasets
                  AddSeriesItem(ds)
               Next ds
               EndUpdate(listViewSeries)
         End Select

      End Sub

     Private Sub listViewStudies_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles listViewStudies.SelectedIndexChanged
       If listViewStudies.SelectedItems.Count = 0 Then
         Return
       End If

       Dim study As String = TryCast(listViewStudies.SelectedItems(0).Tag, String)



       ImageList.Items.Clear()
       _viewer.Image = Nothing
       If Nothing IsNot study AndAlso study.Length > 0 Then
         Dim query As New CFindQuery()

         query.StudyInstanceUid = study
         query.PatientID = listViewStudies.SelectedItems(0).SubItems(1).Text
         EnableItems(False)
         cfind.Find(server, FindType.StudySeries, query, AETitle)
       End If
     End Sub

      Private Sub panel6_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles panel6.SizeChanged
         ImageList.Height = Convert.ToInt32(panel6.ClientSize.Height * 0.25)
      End Sub

     Private Sub listViewSeries_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles listViewSeries.DoubleClick
       If listViewStudies.SelectedItems.Count = 0 Then
         Return
       End If

       ImageList.Items.Clear()

       Dim patientID, studyInstance, seriesInstance As String



       patientID = listViewStudies.SelectedItems(0).SubItems(1).Text
       studyInstance = TryCast(listViewStudies.SelectedItems(0).Tag, String)
       seriesInstance = TryCast(listViewSeries.SelectedItems(0).Tag, String)

       EnableItems(False)
       cfind.MoveSeries(server, AETitle, patientID, studyInstance, seriesInstance, Port)
     End Sub


      Private Sub cfind_MoveComplete(ByVal sender As Object, ByVal e As MoveCompleteEventArgs)
         If InvokeRequired Then
            Invoke(New MoveCompleteEventHandler(AddressOf cfind_MoveComplete), sender, e)
         Else
            ImageList.BeginUpdate()
            For Each ds As DicomDataSet In e.Datasets
               Dim element As DicomElement

               Try
                  element = ds.FindFirstElement(Nothing, DemoDicomTags.PixelData, True)
                  If element Is Nothing Then
                     Continue For
                  End If

                  Dim i As Integer = 0
                  Do While i < ds.GetImageCount(element)
                     Dim image As RasterImage
                     Dim info As DicomImageInformation = ds.GetImageInformation(element, i)

                     If info.IsGray Then
                        image = ds.GetImage(element, i, 0, RasterByteOrder.Gray, DicomGetImageFlags.AutoApplyModalityLut Or DicomGetImageFlags.AutoApplyVoiLut Or DicomGetImageFlags.AllowRangeExpansion)
                     Else
                        image = ds.GetImage(element, i, 0, RasterByteOrder.Rgb, DicomGetImageFlags.AutoApplyModalityLut Or DicomGetImageFlags.AutoApplyVoiLut Or DicomGetImageFlags.AllowRangeExpansion)
                     End If
                     If Not image Is Nothing Then
                        Dim item As ImageViewerItem = New ImageViewerItem()

                        item.Text = ""
                        item.Image = image
                        ImageList.Items.Insert(ImageList.Items.Count, item)
                     End If
                     i += 1
                  Loop
               Catch de As DicomException
                  Dim eventArg As StatusEventArgs = New StatusEventArgs()

                  eventArg._Error = de.Code
                  eventArg._Type = StatusType.Error
                  cfind_Status(Me, eventArg)
               End Try
            Next ds
            If ImageList.Items.Count > 0 Then
               ImageList.Items(0).IsSelected = True
               SetImage(ImageList.Items.GetSelected()(0))
            End If
            ImageList.EndUpdate()
         End If

      End Sub

      Public Delegate Sub EnableItemsDelegate(ByVal enable As Boolean)
      Public Sub EnableItems(ByVal enable As Boolean)
         If InvokeRequired Then
            Invoke(New EnableItemsDelegate(AddressOf EnableItems), enable)
         Else
            listViewStudies.Enabled = enable
            listViewSeries.Enabled = enable
            buttonSearch.Enabled = enable
         End If
      End Sub

      Private Sub menuItemClearLog_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemClearLog.Click
         Log.Clear()
      End Sub

      Private Sub menuItemAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemHelp.Click, menuItemAbout.Click
         Using aboutDialog As New AboutDialog("Dicom Client", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub SetImage(ByVal item As ImageViewerItem)
         _viewer.Image = item.Image.Clone()
      End Sub

      Private Sub MainForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
         cfind.Terminate()
      End Sub

      Private Sub ImageList_SelectedItemsChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImageList.SelectedItemsChanged
         If ImageList.Items.GetSelected().Length > 0 Then
            SetImage(ImageList.Items.GetSelected()(0))
         End If
      End Sub

        Private Sub menuItemIPv4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItemIPv4.Click
         If _ipType <> DicomNetIpTypeFlags.Ipv4 Then
            _ipType = DicomNetIpTypeFlags.Ipv4
            server.IpType = _ipType
            SaveSettings()
         End If
      End Sub

        Private Sub menuItemIPv6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItemIPv6.Click
            If _ipType <> DicomNetIpTypeFlags.Ipv6 Then
                _ipType = DicomNetIpTypeFlags.Ipv6
                server.IpType = _ipType
                SaveSettings()
            End If
        End Sub

        Private Sub menuItemIpv4Ipv6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItemIpv4Ipv6.Click
            If _ipType <> DicomNetIpTypeFlags.Ipv4OrIpv6 Then
                _ipType = DicomNetIpTypeFlags.Ipv4OrIpv6
                server.IpType = _ipType
                SaveSettings()
            End If
        End Sub

        Private Sub menuItemOptions_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItemOptions.Popup
         menuItemIPv4.Checked = (_ipType = DicomNetIpTypeFlags.Ipv4)
            menuItemIPv6.Checked = (_ipType = DicomNetIpTypeFlags.Ipv6)
            menuItemIpv4Ipv6.Checked = (_ipType = DicomNetIpTypeFlags.Ipv4OrIpv6)
            menuItemIpv4Ipv6.Enabled = DemosGlobal.IsOnVistaOrLater
      End Sub

        Private Sub MainForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
            If Not cfind Is Nothing Then
                cfind.Terminate()
            End If
        End Sub
    End Class
End Namespace
