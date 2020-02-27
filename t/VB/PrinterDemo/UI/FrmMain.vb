' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.Runtime.InteropServices

Imports Leadtools
Imports Leadtools.Printer
Imports Leadtools.Document.Writer
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.Demos.Dialogs

Friend Structure JobInfoStruct
   Private _jobId As Integer
   Private _pageNo As Integer

   Public Sub New(ByVal jobIdValue As Integer, ByVal pageNoValue As Integer)
      _jobId = jobIdValue
      _pageNo = pageNoValue
   End Sub

   Public ReadOnly Property JobId() As Integer
      Get
         Return _jobId
      End Get
   End Property

   Public ReadOnly Property PageNo() As Integer
      Get
         Return _pageNo
      End Get
   End Property
End Structure

Partial Public Class FrmMain : Inherits Form
#Region "Windows Form Designer generated code"
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
      Me._mmMain = New System.Windows.Forms.MenuStrip
      Me._miFile = New System.Windows.Forms.ToolStripMenuItem
      Me._miSetActivePrinter = New System.Windows.Forms.ToolStripMenuItem
      Me._miPrintStartedPage = New System.Windows.Forms.ToolStripMenuItem
      Me._miSep2 = New System.Windows.Forms.ToolStripSeparator
      Me._miClearPrintedList = New System.Windows.Forms.ToolStripMenuItem
      Me._miSavePrintJobsAs = New System.Windows.Forms.ToolStripMenuItem
      Me._miRaster = New System.Windows.Forms.ToolStripMenuItem
      Me._miDocument = New System.Windows.Forms.ToolStripMenuItem
      Me._miSavePrintJobsAsAndClearList = New System.Windows.Forms.ToolStripMenuItem
      Me._miRasterClear = New System.Windows.Forms.ToolStripMenuItem
      Me._miDocumentClear = New System.Windows.Forms.ToolStripMenuItem
      Me._miSep3 = New System.Windows.Forms.ToolStripSeparator
      Me._miInstallPrinter = New System.Windows.Forms.ToolStripMenuItem
      Me._miUninstallPrinter = New System.Windows.Forms.ToolStripMenuItem
      Me._miSep1 = New System.Windows.Forms.ToolStripSeparator
      Me._miExit = New System.Windows.Forms.ToolStripMenuItem
      Me._miView = New System.Windows.Forms.ToolStripMenuItem
      Me._miNormal = New System.Windows.Forms.ToolStripMenuItem
      Me._miFit = New System.Windows.Forms.ToolStripMenuItem
      Me._miZoomIn = New System.Windows.Forms.ToolStripMenuItem
      Me._miZoomOut = New System.Windows.Forms.ToolStripMenuItem
      Me._miOptions = New System.Windows.Forms.ToolStripMenuItem
      Me._miEvents = New System.Windows.Forms.ToolStripMenuItem
      Me._miEventsEmf = New System.Windows.Forms.ToolStripMenuItem
      Me._miEventsJob = New System.Windows.Forms.ToolStripMenuItem
      Me._miPrinterLock = New System.Windows.Forms.ToolStripMenuItem
      Me._miLockPrinter = New System.Windows.Forms.ToolStripMenuItem
      Me._miUnLockPrinter = New System.Windows.Forms.ToolStripMenuItem
      Me._miPrinterSpecs = New System.Windows.Forms.ToolStripMenuItem
      Me._miViewOutputFile = New System.Windows.Forms.ToolStripMenuItem
      Me._miHelp = New System.Windows.Forms.ToolStripMenuItem
      Me._miAbout = New System.Windows.Forms.ToolStripMenuItem
      Me._miEventsEmf2 = New System.Windows.Forms.ToolStripMenuItem
      Me._miEventsJob2 = New System.Windows.Forms.ToolStripMenuItem
      Me._panelImageList = New System.Windows.Forms.Panel
      Me._lstBoxPages = New System.Windows.Forms.ListBox
      Me._panelPictureBox = New System.Windows.Forms.Panel
      Me._pictureBox = New ImageViewer
      Me.lockPrinterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.unlockPrinterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._miPrinterDefaultSpecs = New System.Windows.Forms.ToolStripMenuItem
      Me._mmMain.SuspendLayout()
      Me._panelImageList.SuspendLayout()
      Me._panelPictureBox.SuspendLayout()
      Me.SuspendLayout()
      '
      '_mmMain
      '
      Me._mmMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miFile, Me._miView, Me._miOptions, Me._miHelp})
      Me._mmMain.Location = New System.Drawing.Point(0, 0)
      Me._mmMain.Name = "_mmMain"
      Me._mmMain.Size = New System.Drawing.Size(533, 24)
      Me._mmMain.TabIndex = 0
      '
      '_miFile
      '
      Me._miFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miSetActivePrinter, Me._miPrintStartedPage, Me._miSep2, Me._miClearPrintedList, Me._miSavePrintJobsAs, Me._miSavePrintJobsAsAndClearList, Me._miSep3, Me._miInstallPrinter, Me._miUninstallPrinter, Me._miSep1, Me._miExit})
      Me._miFile.Name = "_miFile"
      Me._miFile.Size = New System.Drawing.Size(37, 20)
      Me._miFile.Text = "&File"
      '
      '_miSetActivePrinter
      '
      Me._miSetActivePrinter.Name = "_miSetActivePrinter"
      Me._miSetActivePrinter.Size = New System.Drawing.Size(244, 22)
      Me._miSetActivePrinter.Text = "&Set &Active Printer"
      '
      '_miPrintStartedPage
      '
      Me._miPrintStartedPage.Name = "_miPrintStartedPage"
      Me._miPrintStartedPage.Size = New System.Drawing.Size(244, 22)
      Me._miPrintStartedPage.Text = "&Print Start Page"
      '
      '_miSep2
      '
      Me._miSep2.Name = "_miSep2"
      Me._miSep2.Size = New System.Drawing.Size(241, 6)
      '
      '_miClearPrintedList
      '
      Me._miClearPrintedList.Name = "_miClearPrintedList"
      Me._miClearPrintedList.Size = New System.Drawing.Size(244, 22)
      Me._miClearPrintedList.Text = "&Clear Printed List"
      '
      '_miSavePrintJobsAs
      '
      Me._miSavePrintJobsAs.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miRaster, Me._miDocument})
      Me._miSavePrintJobsAs.Name = "_miSavePrintJobsAs"
      Me._miSavePrintJobsAs.Size = New System.Drawing.Size(244, 22)
      Me._miSavePrintJobsAs.Text = "&Save Print Jobs As"
      '
      '_miRaster
      '
      Me._miRaster.Name = "_miRaster"
      Me._miRaster.Size = New System.Drawing.Size(130, 22)
      Me._miRaster.Text = "&Image"
      '
      '_miDocument
      '
      Me._miDocument.Name = "_miDocument"
      Me._miDocument.Size = New System.Drawing.Size(130, 22)
      Me._miDocument.Text = "&Document"
      '
      '_miSavePrintJobsAsAndClearList
      '
      Me._miSavePrintJobsAsAndClearList.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miRasterClear, Me._miDocumentClear})
      Me._miSavePrintJobsAsAndClearList.Name = "_miSavePrintJobsAsAndClearList"
      Me._miSavePrintJobsAsAndClearList.Size = New System.Drawing.Size(244, 22)
      Me._miSavePrintJobsAsAndClearList.Text = "Save Print Jobs As And Clear List"
      '
      '_miRasterClear
      '
      Me._miRasterClear.Name = "_miRasterClear"
      Me._miRasterClear.Size = New System.Drawing.Size(130, 22)
      Me._miRasterClear.Text = "&Image"
      '
      '_miDocumentClear
      '
      Me._miDocumentClear.Name = "_miDocumentClear"
      Me._miDocumentClear.Size = New System.Drawing.Size(130, 22)
      Me._miDocumentClear.Text = "&Document"
      '
      '_miSep3
      '
      Me._miSep3.Name = "_miSep3"
      Me._miSep3.Size = New System.Drawing.Size(241, 6)
      '
      '_miInstallPrinter
      '
      Me._miInstallPrinter.Name = "_miInstallPrinter"
      Me._miInstallPrinter.Size = New System.Drawing.Size(244, 22)
      Me._miInstallPrinter.Text = "&Install Printer"
      '
      '_miUninstallPrinter
      '
      Me._miUninstallPrinter.Name = "_miUninstallPrinter"
      Me._miUninstallPrinter.Size = New System.Drawing.Size(244, 22)
      Me._miUninstallPrinter.Text = "&Uninstall Printer"
      '
      '_miSep1
      '
      Me._miSep1.Name = "_miSep1"
      Me._miSep1.Size = New System.Drawing.Size(241, 6)
      '
      '_miExit
      '
      Me._miExit.Name = "_miExit"
      Me._miExit.Size = New System.Drawing.Size(244, 22)
      Me._miExit.Text = "&Exit"
      '
      '_miView
      '
      Me._miView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miNormal, Me._miFit, Me._miZoomIn, Me._miZoomOut})
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
      Me._miNormal.Size = New System.Drawing.Size(151, 22)
      Me._miNormal.Text = "&Normal"
      '
      '_miFit
      '
      Me._miFit.Enabled = False
      Me._miFit.Name = "_miFit"
      Me._miFit.Size = New System.Drawing.Size(151, 22)
      Me._miFit.Text = "&Fit To Window"
      '
      '_miZoomIn
      '
      Me._miZoomIn.Enabled = False
      Me._miZoomIn.Name = "_miZoomIn"
      Me._miZoomIn.Size = New System.Drawing.Size(151, 22)
      Me._miZoomIn.Text = "Zoom &In (+)"
      '
      '_miZoomOut
      '
      Me._miZoomOut.Enabled = False
      Me._miZoomOut.Name = "_miZoomOut"
      Me._miZoomOut.Size = New System.Drawing.Size(151, 22)
      Me._miZoomOut.Text = "Zoom &Out (-)"
      '
      '_miOptions
      '
      Me._miOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miEvents, Me._miPrinterLock, Me._miPrinterSpecs, Me._miPrinterDefaultSpecs, Me._miViewOutputFile})
      Me._miOptions.Name = "_miOptions"
      Me._miOptions.Size = New System.Drawing.Size(61, 20)
      Me._miOptions.Text = "&Options"
      '
      '_miEvents
      '
      Me._miEvents.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miEventsEmf, Me._miEventsJob})
      Me._miEvents.Name = "_miEvents"
      Me._miEvents.Size = New System.Drawing.Size(195, 22)
      Me._miEvents.Text = "&Events"
      Me._miEvents.Visible = False
      '
      '_miEventsEmf
      '
      Me._miEventsEmf.CheckOnClick = True
      Me._miEventsEmf.Name = "_miEventsEmf"
      Me._miEventsEmf.Size = New System.Drawing.Size(127, 22)
      Me._miEventsEmf.Text = "&Emf Event"
      '
      '_miEventsJob
      '
      Me._miEventsJob.CheckOnClick = True
      Me._miEventsJob.Name = "_miEventsJob"
      Me._miEventsJob.Size = New System.Drawing.Size(127, 22)
      Me._miEventsJob.Text = "&Job Event"
      '
      '_miPrinterLock
      '
      Me._miPrinterLock.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miLockPrinter, Me._miUnLockPrinter})
      Me._miPrinterLock.Name = "_miPrinterLock"
      Me._miPrinterLock.Size = New System.Drawing.Size(195, 22)
      Me._miPrinterLock.Text = "&Printer Lock"
      '
      '_miLockPrinter
      '
      Me._miLockPrinter.Name = "_miLockPrinter"
      Me._miLockPrinter.Size = New System.Drawing.Size(149, 22)
      Me._miLockPrinter.Text = "&Lock Printer"
      '
      '_miUnLockPrinter
      '
      Me._miUnLockPrinter.Enabled = False
      Me._miUnLockPrinter.Name = "_miUnLockPrinter"
      Me._miUnLockPrinter.Size = New System.Drawing.Size(149, 22)
      Me._miUnLockPrinter.Text = "&Unlock Printer"
      '
      '_miPrinterSpecs
      '
      Me._miPrinterSpecs.Name = "_miPrinterSpecs"
      Me._miPrinterSpecs.Size = New System.Drawing.Size(195, 22)
      Me._miPrinterSpecs.Text = "Printer &Options"
      '
      '_miViewOutputFile
      '
      Me._miViewOutputFile.Checked = True
      Me._miViewOutputFile.CheckOnClick = True
      Me._miViewOutputFile.CheckState = System.Windows.Forms.CheckState.Checked
      Me._miViewOutputFile.Name = "_miViewOutputFile"
      Me._miViewOutputFile.Size = New System.Drawing.Size(195, 22)
      Me._miViewOutputFile.Text = "&View Output File"
      '
      '_miHelp
      '
      Me._miHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miAbout})
      Me._miHelp.Name = "_miHelp"
      Me._miHelp.Size = New System.Drawing.Size(44, 20)
      Me._miHelp.Text = "&Help"
      '
      '_miAbout
      '
      Me._miAbout.Name = "_miAbout"
      Me._miAbout.Size = New System.Drawing.Size(180, 22)
      Me._miAbout.Text = "&About Printer Demo"
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
      '_panelImageList
      '
      Me._panelImageList.Controls.Add(Me._lstBoxPages)
      Me._panelImageList.Dock = System.Windows.Forms.DockStyle.Left
      Me._panelImageList.Location = New System.Drawing.Point(0, 24)
      Me._panelImageList.Name = "_panelImageList"
      Me._panelImageList.Size = New System.Drawing.Size(182, 330)
      Me._panelImageList.TabIndex = 4
      '
      '_lstBoxPages
      '
      Me._lstBoxPages.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me._lstBoxPages.Dock = System.Windows.Forms.DockStyle.Fill
      Me._lstBoxPages.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
      Me._lstBoxPages.FormattingEnabled = True
      Me._lstBoxPages.ItemHeight = 150
      Me._lstBoxPages.Location = New System.Drawing.Point(0, 0)
      Me._lstBoxPages.Name = "_lstBoxPages"
      Me._lstBoxPages.Size = New System.Drawing.Size(182, 330)
      Me._lstBoxPages.TabIndex = 0
      '
      '_panelPictureBox
      '
      Me._panelPictureBox.AutoScroll = True
      Me._panelPictureBox.Controls.Add(Me._pictureBox)
      Me._panelPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me._panelPictureBox.Location = New System.Drawing.Point(182, 24)
      Me._panelPictureBox.Name = "_panelPictureBox"
      Me._panelPictureBox.Size = New System.Drawing.Size(351, 330)
      Me._panelPictureBox.TabIndex = 5
      '
      '_pictureBox
      '
      Me._pictureBox.BackColor = System.Drawing.SystemColors.ButtonFace
      Me._pictureBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me._pictureBox.AutoScroll = True
      Me._pictureBox.ScrollMode = ControlScrollMode.Auto
      Me._pictureBox.Location = New System.Drawing.Point(0, 0)
      Me._pictureBox.Name = "_pictureBox"
      Me._pictureBox.Size = New System.Drawing.Size(351, 330)
      Me._pictureBox.TabIndex = 0
      '
      'lockPrinterToolStripMenuItem
      '
      Me.lockPrinterToolStripMenuItem.Name = "lockPrinterToolStripMenuItem"
      Me.lockPrinterToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me.lockPrinterToolStripMenuItem.Text = "a"
      '
      'unlockPrinterToolStripMenuItem
      '
      Me.unlockPrinterToolStripMenuItem.Name = "unlockPrinterToolStripMenuItem"
      Me.unlockPrinterToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me.unlockPrinterToolStripMenuItem.Text = "a"
      '
      '_miPrinterDefaultSpecs
      '
      Me._miPrinterDefaultSpecs.Name = "_miPrinterDefaultSpecs"
      Me._miPrinterDefaultSpecs.Size = New System.Drawing.Size(195, 22)
      Me._miPrinterDefaultSpecs.Text = "Printer &User Options"
      '
      'FrmMain
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(533, 354)
      Me.Controls.Add(Me._panelPictureBox)
      Me.Controls.Add(Me._panelImageList)
      Me.Controls.Add(Me._mmMain)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MainMenuStrip = Me._mmMain
      Me.Name = "FrmMain"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "LEADTOOLS VB Printer Demo"
      Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
      Me._mmMain.ResumeLayout(False)
      Me._mmMain.PerformLayout()
      Me._panelImageList.ResumeLayout(False)
      Me._panelPictureBox.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _mmMain As System.Windows.Forms.MenuStrip
   Private WithEvents _miFile As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miSetActivePrinter As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miInstallPrinter As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miUninstallPrinter As System.Windows.Forms.ToolStripMenuItem
   Private _miSep1 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _miExit As System.Windows.Forms.ToolStripMenuItem
   Private _miHelp As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miAbout As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miLockPrinter As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miUnLockPrinter As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miEventsEmf As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miEventsJob As System.Windows.Forms.ToolStripMenuItem
   Private _miSavePrintJobsAs As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miPrintStartedPage As System.Windows.Forms.ToolStripMenuItem
   Private _panelImageList As System.Windows.Forms.Panel
   Private WithEvents _lstBoxPages As System.Windows.Forms.ListBox
   Private _panelPictureBox As System.Windows.Forms.Panel
   Private WithEvents _miClearPrintedList As System.Windows.Forms.ToolStripMenuItem
   Private _miViewOutputFile As System.Windows.Forms.ToolStripMenuItem
   Private _miSavePrintJobsAsAndClearList As System.Windows.Forms.ToolStripMenuItem
   Private _miSep2 As System.Windows.Forms.ToolStripSeparator
   Private _miSep3 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _miOptions As System.Windows.Forms.ToolStripMenuItem
   Private _miEvents As System.Windows.Forms.ToolStripMenuItem
   Private _miEventsEmf2 As System.Windows.Forms.ToolStripMenuItem
   Private _miEventsJob2 As System.Windows.Forms.ToolStripMenuItem
   Private _miPrinterLock As System.Windows.Forms.ToolStripMenuItem
   Private lockPrinterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private unlockPrinterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miRaster As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miDocument As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miRasterClear As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miDocumentClear As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miPrinterSpecs As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _pictureBox As ImageViewer
   Private _miView As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miNormal As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miFit As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miZoomIn As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents _miPrinterDefaultSpecs As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miZoomOut As System.Windows.Forms.ToolStripMenuItem
#End Region

   <DllImport("kernel32.dll")> _
   Shared Function GlobalLock(ByVal hMem As IntPtr) As IntPtr
   End Function

   <DllImport("kernel32.dll")> _
   Shared Function GlobalUnlock(ByVal hMem As IntPtr) As Boolean
   End Function

   <DllImport("kernel32.dll")> _
   Shared Function GlobalFree(ByVal hMem As IntPtr) As Boolean
   End Function

   'Dotnet does not have functions to add or remove font files, we will have to use the API ones
   <DllImport("gdi32")> _
   Shared Function AddFontResource(ByVal lpFileName As String) As Integer
   End Function
   <DllImport("gdi32")> _
   Shared Function RemoveFontResource(ByVal lpFileName As String) As Integer
   End Function

   Private Const DM_OUT_BUFFER As Int32 = 14

#Region "Main..."
   ''' <summary>
   ''' The main entry point for the application.
   ''' </summary>
   <STAThread()> _
   Shared Sub Main(ByVal args As String())
      Try
         

         If Not Support.SetLicense() Then
            Return
         End If

         If args.Length > 0 Then
            FrmMain.StartedPrinter = args(0)

         End If

         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)
         Application.Run(New FrmMain())
      Catch
      End Try
   End Sub
#End Region

#Region "Constructor..."
   Public Sub New()
      Try
         If InitClass() Then
            InitializeComponent()
         Else
            Close()
         End If
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Error)
         Close()
      End Try
   End Sub
#End Region

#Region "Fields..."
   Private _printDocument As PrintDocument = New PrintDocument()
   Private _printer As Printer
   Private _frmProgress As FrmProgress = New FrmProgress()
   Private _lstMetaFiles As List(Of IntPtr) = New List(Of IntPtr)()
   Private _lstJobInfo As List(Of JobInfoStruct) = New List(Of JobInfoStruct)()
   Private _pageNo As Integer = 0
   Private _jobId As Integer = 0
   Private _currentPrinterName As String = String.Empty
   Private Shared StartedPrinter As String = String.Empty
   Private bSelectedPrinter As Boolean = True
   Private _codec As RasterCodecs
   Private _tempFiles As List(Of String) = New List(Of String)()
   'Array to hold the font names
   Dim _fonts As List(Of String) = New List(Of String)()
   'Path to save the font files to
   Dim _fontsPath As String
#End Region

#Region "Properties..."
   Private ReadOnly Property ReceiveJobEvent() As Boolean
      Get
         Return _miEventsJob.Checked
      End Get
   End Property

   Private ReadOnly Property ReceiveEmfEvent() As Boolean
      Get
         Return _miEventsEmf.Checked
      End Get
   End Property

   Private ReadOnly Property ViewOutputFile() As Boolean
      Get
         If _miViewOutputFile Is Nothing Then
            Return True
         End If

         Return _miViewOutputFile.Checked
      End Get
   End Property
#End Region

#Region "Events..."
   Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
      Try
         _codec = New RasterCodecs()

         Me._miPrinterDefaultSpecs.Visible = True

         If bSelectedPrinter = False Then
            Me.Close()
         Else
            AddHandler _printDocument.PrintPage, AddressOf _printDocument_PrintPage
         End If

         _miViewOutputFile.Checked = True
         Me.Text = "LEADTOOLS VB Printer Demo - Active printer is: " & _currentPrinterName

         Dim newGuid As String = Guid.NewGuid().ToString("N")
         'Get the path to the shared documents
         _fontsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), newGuid)
         Directory.CreateDirectory(_fontsPath)
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Finally
      End Try
   End Sub

   Private Sub FrmMain_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Resize
      _pictureBox.Invalidate()
      _lstBoxPages.Invalidate()
   End Sub

   Private Sub _printDocument_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
      DrawStartedPage(e.Graphics)
   End Sub

   Private Sub _pictureBox_Paint(ByVal sender As Object, ByVal e As ImageViewerRenderEventArgs) Handles _pictureBox.Render
      If _lstBoxPages.Items.Count = 0 OrElse _pictureBox.Image Is Nothing Then
         DrawStartedPage(e.PaintEventArgs.Graphics)
         _miNormal.Enabled = False
         _miFit.Enabled = False
         _miZoomIn.Enabled = False
         _miZoomOut.Enabled = False
      Else
         _miNormal.Enabled = True
         _miFit.Enabled = True
         _miZoomIn.Enabled = True
         _miZoomOut.Enabled = True
      End If

   End Sub


   Public Sub _printer_EmfEvent(ByVal sender As Object, ByVal e As EmfEventArgs)
      Me.Enabled = False
      Dim tempFile As String = Path.GetTempFileName()
      _tempFiles.Add(tempFile)
      File.WriteAllBytes(tempFile, e.Stream.ToArray())

      Dim metaFile As Metafile = New Metafile(e.Stream)
      _pageNo += 1

      If _frmProgress.Visible Then
         _frmProgress.SetProgressState(_pageNo, _jobId)
      End If

      Dim emfImage As Image = metaFile.GetThumbnailImage(_lstBoxPages.Width, _lstBoxPages.ItemHeight, Nothing, IntPtr.Zero)
      Dim nLastIndex As Integer = _lstBoxPages.Items.Add(emfImage)
      _lstMetaFiles.Add(metaFile.GetHenhmetafile())
      _lstJobInfo.Add(New JobInfoStruct(_jobId, _pageNo))
   End Sub

   Public Sub _printer_JobEvent(ByVal sender As Object, ByVal e As JobEventArgs)
      If e.JobEventState = EventState.JobStart Then
         Me.Enabled = True
         Me.BringToFront()
         Me.Focus()
         _pageNo = 0
         _jobId = e.JobID
         If (Not _frmProgress.Visible) Then
            _frmProgress = New FrmProgress(e.PrinterName, _printer)
            _frmProgress.Show()
         End If
      ElseIf e.JobEventState = EventState.JobEnd Then
         _frmProgress.Close()
         'job-end event we may have embedded font attached to the job
         'we will save the font files so we can use them when saving
         AddAndInstallFonts(e.JobID)
         Me.Enabled = True
         _lstBoxPages.SelectedIndex = 0
         Me.BringToFront()
         Me.Focus()
      End If
   End Sub

   Private Sub _miSetActivePrinter_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miSetActivePrinter.Click
      Try
         GetPrinterName(False)
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Sub _miInstallPrinter_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miInstallPrinter.Click
      Try
         Dim frmInstallPrinter As FrmInstallPrinter = New FrmInstallPrinter()
         Dim dialogResult As DialogResult = frmInstallPrinter.ShowDialog()

         If dialogResult = dialogResult.OK Then
            Dim newPrinterName As String = frmInstallPrinter.PrinterName
            Dim newPrinterPassword As String = frmInstallPrinter.PrinterPassword

            Dim bSuccess As Boolean = PrintingUtilities.InstallNewPrinter(newPrinterName, newPrinterPassword)

            If bSuccess Then
               _currentPrinterName = newPrinterName
               SetCurrentPrinter()

            End If
         End If
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Function UninstallPrinter(ByVal printerName As String) As DialogResult
      Dim dialogResult As DialogResult = dialogResult.Ignore

      Try
         Dim warningMessage As String = String.Format("Are you sure you want to remove the {0} printer from the system?", printerName)
         dialogResult = MessageBox.Show(warningMessage, "LEADTOOLS Printer Demo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

         If dialogResult = dialogResult.Yes Then
            Dim printerInfo As PrinterInfo = New PrinterInfo()
            printerInfo.PrinterName = printerName
            printerInfo.MonitorName = printerName
            printerInfo.PortName = printerName

            Printer.UnInstall(printerInfo)
            MessageBox.Show("Uninstall Printer Completed Successfully", "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Catch Ex As Exception
         MessageBox.Show(Ex.ToString(), "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try

      Return dialogResult
   End Function

   Private Sub _miUninstallPrinter_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miUninstallPrinter.Click
      Try
         Dim frmUninstallPrinter As FrmUninstallPrinter = New FrmUninstallPrinter()
         Dim dialogResult As DialogResult = frmUninstallPrinter.ShowDialog()

         If dialogResult = dialogResult.OK Then
            Dim printerName As String = frmUninstallPrinter.PrinterName

            If (printerName = _currentPrinterName) AndAlso IsCurrentPrinterLocked() Then
               UnLockPrinter()
               If IsCurrentPrinterLocked() Then
                  Return
               End If
            End If

            If UninstallPrinter(printerName) = dialogResult.Yes Then
               If printerName = _currentPrinterName Then
                  If (Not GetPrinterName(True)) Then
                     Me.Close()
                  End If
               End If
            End If
         End If
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Sub _miLockPrinter_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miLockPrinter.Click
      Try
         LockPrinter()
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Sub _miUnLockPrinter_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miUnLockPrinter.Click
      Try
         UnLockPrinter()
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Sub _miPrintCurrentPage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miPrintStartedPage.Click
      Try
         If IsCurrentPrinterLocked() Then
            UnLockPrinter()
         End If

         If IsCurrentPrinterLocked() = False Then
            Me.Enabled = False
            _printDocument.PrinterSettings.PrinterName = _currentPrinterName
            _printer.Specifications.DimensionsInInches = False

            _printDocument.DefaultPageSettings.Landscape = Not _printer.Specifications.PortraitOrient

            If _printer.Specifications.PaperID = 0 Then
               Dim paperSize As PaperSize = New PaperSize()
               paperSize.PaperName = _printer.Specifications.PaperSizeName
               paperSize.Height = Convert.ToInt32(_printer.Specifications.PaperHeight) * 100
               paperSize.Width = Convert.ToInt32(_printer.Specifications.PaperWidth) * 100
               _printDocument.DefaultPageSettings.PaperSize = paperSize
            Else
               If _printer.Specifications.PaperID < _printDocument.DefaultPageSettings.PrinterSettings.PaperSizes.Count Then
                  _printDocument.DefaultPageSettings.PaperSize.RawKind = _printer.Specifications.PaperID
               End If
            End If

            Dim paperResolution As PrinterResolution = New PrinterResolution()
            paperResolution.X = _printer.Specifications.YResolution
            paperResolution.Y = _printer.Specifications.YResolution

            _printDocument.DefaultPageSettings.PrinterResolution = paperResolution
            _printDocument.Print()
         End If
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Finally
         Me.Enabled = True
      End Try
   End Sub

   Private Sub _miClearPrintedList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miClearPrintedList.Click
      Try
         ClearList()
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Sub _miEventsEmf_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miEventsEmf.Click
      Try
         If ReceiveEmfEvent Then
            AddHandler _printer.EmfEvent, AddressOf _printer_EmfEvent
         Else
            RemoveHandler _printer.EmfEvent, AddressOf _printer_EmfEvent
            MessageBox.Show("By disabling this event, you will not see a thumbnail of the printed document in the list on the left.", "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End If
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Sub _miEventsJob_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miEventsJob.Click
      Try
         If ReceiveJobEvent Then
            AddHandler _printer.JobEvent, AddressOf _printer_JobEvent
         Else
            RemoveHandler _printer.JobEvent, AddressOf _printer_JobEvent
            MessageBox.Show("By disabling this event, you will not get any information on the print job.", "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End If
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Sub _miAbout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miAbout.Click
      Try
         Using aboutDialog As New AboutDialog("Printer", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Sub _miExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miExit.Click
      Try
         Me.Close()
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Sub _lstBoxPages_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _lstBoxPages.SelectedIndexChanged
      Try
         If _lstBoxPages.Items.Count > 0 Then
            Dim oldScaleFactor As Double = _pictureBox.ScaleFactor

            If oldScaleFactor <= 0 Then
               oldScaleFactor = 1
            End If

            If Not _pictureBox.Image Is Nothing Then
               _pictureBox.Image.Dispose()
            End If

            Dim buffer As Byte() = File.ReadAllBytes(_tempFiles(_lstBoxPages.SelectedIndex))
            Dim stream As MemoryStream = New MemoryStream(buffer)
            _pictureBox.Image = _codec.Load(stream, 24, CodecsLoadByteOrder.BgrOrGray, 1, 1)

            If _miFit.Checked Then
               View_Clicked(_miFit, New EventArgs())
            Else
               _pictureBox.Zoom(ControlSizeMode.None, oldScaleFactor, _pictureBox.DefaultZoomOrigin)
            End If

            stream.Close()
         End If

         _pictureBox.Invalidate()
         _lstBoxPages.Invalidate()
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Function GetFitRect(ByVal rect As Rectangle, ByVal width As Integer, ByVal height As Integer) As Rectangle
      Dim newWidth As Integer = 0
      Dim newHeight As Integer = 0

      newHeight = rect.Height
      newWidth = Convert.ToInt32(newHeight * width / height)

      If newWidth > rect.Width Then
         newWidth = rect.Width
         newHeight = Convert.ToInt32(newWidth * height / width)
      End If

      Return New Rectangle(rect.Left, rect.Top, newWidth, newHeight)
   End Function

   Private Sub _lstBoxPages_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles _lstBoxPages.DrawItem
      Try
         If e.Index >= 0 Then
            Dim graphics As Graphics = e.Graphics
            Dim fontSize As Single = 1
            Dim brush As Brush = Brushes.LightBlue

            If e.Index = _lstBoxPages.SelectedIndex Then
               fontSize = 5
               brush = Brushes.Blue
            End If
            Dim rect As Rectangle = e.Bounds
            rect.Inflate(New Size(-30, -5))
            Dim thumbnailRect As Rectangle = New Rectangle(rect.Left, rect.Top, rect.Width, rect.Height - 20)
            graphics.FillRectangle(Brushes.Pink, New Rectangle(rect.Left, rect.Top, rect.Width, rect.Height))
            graphics.FillRectangle(Brushes.White, New Rectangle(rect.Left, rect.Top, rect.Width, rect.Height - 20))
            graphics.DrawRectangle(New Pen(brush, fontSize), New Rectangle(rect.Left, rect.Top, rect.Width, rect.Height))
            graphics.DrawImage((TryCast(_lstBoxPages.Items(e.Index), Image)), thumbnailRect)
            graphics.DrawString("Page " & _lstJobInfo(e.Index).PageNo.ToString() & ", Job ID " & _lstJobInfo(e.Index).JobId.ToString(), Me.Font, Brushes.Black, rect.Left + 2, rect.Bottom - 20)
         End If
      Catch
      End Try
   End Sub

   Private Sub _miFile_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _miFile.DropDownOpening
      Try
         Dim bItemsExist As Boolean = (_lstMetaFiles.Count > 0)

         _miClearPrintedList.Enabled = bItemsExist
         _miSavePrintJobsAs.Enabled = bItemsExist
         _miSavePrintJobsAsAndClearList.Enabled = bItemsExist
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Sub _miPrinterLock_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _miOptions.DropDownOpening
      Try
         Dim bEnableUnLockPrinter As Boolean = _printer.IsPrinterLocked()
         _miLockPrinter.Enabled = Not bEnableUnLockPrinter
         _miUnLockPrinter.Enabled = bEnableUnLockPrinter
         _miPrinterSpecs.Enabled = _miLockPrinter.Enabled
      Catch Ex As PrinterDriverException
         If Ex.Code = PrinterDriverExceptionCode.PrinterCannotBeLocked Then
            _miLockPrinter.Enabled = False
            _miUnLockPrinter.Enabled = False
            _miPrinterSpecs.Enabled = True
         End If
      End Try
   End Sub

   Private Sub FrmMain_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
   End Sub

   Private Sub _miRaster_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miRaster.Click
      Try
         Cursor = Cursors.WaitCursor
         SavePrintedJobsRaster()
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub _miDocument_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miDocument.Click
      Try
         Cursor = Cursors.WaitCursor
         SavePrintedJobsDocument()
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Finally
         Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub _miDocumentClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miDocumentClear.Click
      Try
         Cursor = Cursors.WaitCursor
         If SavePrintedJobsDocument() = DialogResult.OK Then
            ClearList()
         End If
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub _miRasterClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miRasterClear.Click
      Try
         Cursor = Cursors.WaitCursor
         If SavePrintedJobsRaster() = DialogResult.OK Then
            ClearList()
         End If
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub _lstBoxPages_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles _lstBoxPages.KeyDown
      Try
         If e.KeyCode = Keys.Delete AndAlso _lstBoxPages.SelectedItems.Count = 1 Then
            Dim index As Integer = _lstBoxPages.SelectedIndex

            If _lstBoxPages.SelectedIndex = _lstBoxPages.Items.Count - 1 AndAlso _lstBoxPages.Items.Count > 1 Then
               _lstBoxPages.SelectedIndex = 0
            ElseIf _lstBoxPages.Items.Count > 1 Then
               _lstBoxPages.SelectedIndex = index + 1
            End If

            TryCast(_lstBoxPages.Items(index), Image).Dispose()
            _lstBoxPages.Items.RemoveAt(index)

            Dim emf As Metafile = New Metafile(_lstMetaFiles(index), True)
            emf.Dispose()
            _lstMetaFiles.RemoveAt(index)
            _lstJobInfo.RemoveAt(index)

            If File.Exists(_tempFiles(index)) Then
               File.Delete(_tempFiles(index))
            End If

            _tempFiles.RemoveAt(index)

            If _lstBoxPages.Items.Count = 0 Then
               'We dont have any page left, delete font files
               DeleteAndUninstallFonts()

               _pictureBox.Image = Nothing
            End If
         ElseIf e.KeyCode = Keys.Add Then
            View_Clicked(_miZoomIn, New EventArgs())
         ElseIf e.KeyCode = Keys.Subtract Then
            View_Clicked(_miZoomOut, New EventArgs())
         End If
      Catch e1 As ArgumentOutOfRangeException
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Sub _miPrinterSpecs_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miPrinterSpecs.Click
      _printDocument.PrinterSettings.PrinterName = _currentPrinterName
      Dim specDialog As FrmSpecifications = New FrmSpecifications(_printer.Specifications, _printDocument)

      If specDialog.ShowDialog(Me) = DialogResult.OK Then
         Dim printerSpecs As PrinterSpecifications = New PrinterSpecifications()
         printerSpecs.MarginsPrinter = specDialog.MarginsPrinter
         printerSpecs.PaperID = specDialog.PaperID
         printerSpecs.PortraitOrient = specDialog.Portrait
         printerSpecs.PrintQuality = specDialog.PrintQuality
         printerSpecs.YResolution = specDialog.PrintQuality

         _printer.Specifications = printerSpecs
      End If
   End Sub

   Private Sub _miPrinterDefaultSpecs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miPrinterDefaultSpecs.Click
      _printDocument.PrinterSettings.PrinterName = _currentPrinterName
      Dim specDialog As FrmSpecifications = New FrmSpecifications(_printer.UserDefaultSpecifications, _printDocument)

      If specDialog.ShowDialog(Me) = DialogResult.OK Then
         Dim printerSpecs As PrinterSpecifications = New PrinterSpecifications()
         printerSpecs.MarginsPrinter = specDialog.MarginsPrinter
         printerSpecs.PaperID = specDialog.PaperID
         printerSpecs.PortraitOrient = specDialog.Portrait
         printerSpecs.PrintQuality = specDialog.PrintQuality
         printerSpecs.YResolution = specDialog.PrintQuality

         _printer.UserDefaultSpecifications = printerSpecs
      End If
   End Sub

   Private Sub FrmMain_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
      Try
         DeleteTempFiles()
         'Application will exit, delete font files
         DeleteAndUninstallFonts()

         If (Directory.Exists(_fontsPath)) Then
            Directory.Delete(_fontsPath, True)
         End If

         If Not _codec Is Nothing Then
            _codec.Dispose()
         End If
      Catch ex As Exception
         Console.WriteLine(ex.Message)
      End Try
   End Sub


   Private Sub View_Clicked(sender As Object, e As EventArgs) Handles _miNormal.Click, _miFit.Click, _miZoomIn.Click, _miZoomOut.Click
      _miNormal.Checked = False
      _miFit.Checked = False
      _miZoomIn.Checked = False
      _miZoomOut.Checked = False

      Dim sizeMode As ControlSizeMode = ControlSizeMode.None
      Dim scaleFactor As Double = _pictureBox.ScaleFactor

      If sender Is _miNormal Then
         sizeMode = ControlSizeMode.ActualSize
         scaleFactor = 1.0
         _miNormal.Checked = True
      ElseIf sender Is _miFit Then
         sizeMode = ControlSizeMode.FitAlways
         scaleFactor = 1.0
         _miFit.Checked = True
      ElseIf sender Is _miZoomIn Then
         sizeMode = ControlSizeMode.None
         scaleFactor += 0.1
         _miZoomIn.Checked = True
      ElseIf sender Is _miZoomOut Then
         sizeMode = ControlSizeMode.None
         If scaleFactor > 1 Then
            scaleFactor -= 0.1
         End If
         _miZoomOut.Checked = True
      End If

      Try
         _pictureBox.Zoom(sizeMode, scaleFactor, _pictureBox.DefaultZoomOrigin)
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try
   End Sub

   Private Sub _pictureBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles _pictureBox.KeyDown
      Try
         If e.KeyCode = Keys.Add Then
            View_Clicked(_miZoomIn, New EventArgs())
         ElseIf e.KeyCode = Keys.Subtract Then
            View_Clicked(_miZoomOut, New EventArgs())
         End If
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub
#End Region

#Region "Methods..."
   Private Function InitClass() As Boolean
      If RasterSupport.IsLocked(RasterSupportType.PrintDriver) Then
         Throw New Exception("Printer driver capability is required.")
      End If

      If FrmMain.StartedPrinter = String.Empty Then
         bSelectedPrinter = GetPrinterName(True)
      Else
         bSelectedPrinter = True
         _currentPrinterName = FrmMain.StartedPrinter
         SetCurrentPrinter()
      End If

      Return bSelectedPrinter
   End Function

   'On job-end event we will get the embedded fonts generated by the print job if any exist
   Public Sub AddAndInstallFonts(ByVal nJobID As Integer)
      Dim arrFonts As String() = _printer.GetEmbeddedFonts(_fontsPath, nJobID)
      If Not arrFonts Is Nothing AndAlso arrFonts.Length > 0 Then
         _fonts.AddRange(arrFonts)

         For Each strFont As String In arrFonts
            AddFontResource(_fontsPath & "\" & strFont)
         Next strFont
      End If

   End Sub

   'Delete the font files if we dont need them anymore
   Public Sub DeleteAndUninstallFonts()
      For Each strFont As String In _fonts
         If File.Exists(_fontsPath & "\" & strFont) Then
            RemoveFontResource(_fontsPath & "\" & strFont)
            File.Delete(_fontsPath & "\" & strFont)
         End If
      Next strFont
      _fonts.Clear()
   End Sub

   Private Function SavePrintedJobsRaster() As DialogResult
      Dim result As System.Windows.Forms.DialogResult = DialogResult.Cancel

      Cursor = Cursors.WaitCursor
      Dim saver As ImageFileSaver = New ImageFileSaver()

      If saver.Save(Me, _codec, _tempFiles, ViewOutputFile) Then
         result = DialogResult.OK
      End If

      Return result
   End Function

   Private Sub SaveAsEmf(ByVal fileName As String)
      Dim index As Integer = fileName.LastIndexOf(Path.GetExtension(fileName))

      Dim i As Integer = 0
      Do While i < _tempFiles.Count
         Dim destFileName As String = fileName.Insert(index, "_" & (i + 1).ToString())
         File.Copy(_tempFiles(i), destFileName)
         i += 1
      Loop

      If ViewOutputFile Then
         System.Diagnostics.Process.Start(fileName.Insert(index, "_1"))
      End If
   End Sub

   Private Function SavePrintedJobsDocument() As DialogResult
      Dim result As System.Windows.Forms.DialogResult = DialogResult.Cancel

      Try
         Dim saveFileDialog As SaveFileDialog = New SaveFileDialog()
         Dim strFilter As String = String.Empty
         strFilter = "(*.PDF Files)|*.pdf|(*.PDFA Files)|*.pdf|(*.Doc Files)|*.doc|(*.RTF Files)|*.rtf|(*.Text Files)|*.txt|(*.HTML Files)|*.html|(*.DOCX Files)|*.docx|(*.XPS Files)|*.xps|(*.XLS Files)|*.xls"
         saveFileDialog.Filter = strFilter
         result = saveFileDialog.ShowDialog()

         If result = DialogResult.OK Then
            Application.DoEvents()
            Cursor = Cursors.WaitCursor
            Dim documentFormat As DocumentFormat = documentFormat.User
            Dim documentOptions As DocumentOptions = Nothing
            Dim PdfdocumentOptions As PdfDocumentOptions = New PdfDocumentOptions()
            Dim fileName As String = saveFileDialog.FileName

            Select Case saveFileDialog.FilterIndex
               Case 1
                  documentFormat = documentFormat.Pdf
                  documentOptions = New PdfDocumentOptions()
                  TryCast(documentOptions, PdfDocumentOptions).DocumentType = PdfDocumentType.Pdf
                  TryCast(documentOptions, PdfDocumentOptions).FontEmbedMode = DocumentFontEmbedMode.Auto

               Case 2
                  documentFormat = documentFormat.Pdf
                  documentOptions = New PdfDocumentOptions()
                  TryCast(documentOptions, PdfDocumentOptions).DocumentType = PdfDocumentType.PdfA
                  TryCast(documentOptions, PdfDocumentOptions).FontEmbedMode = DocumentFontEmbedMode.Auto
                  TryCast(documentOptions, PdfDocumentOptions).ImageOverText = True

               Case 3
                  documentFormat = documentFormat.Doc
                  documentOptions = New DocDocumentOptions()
                  TryCast(documentOptions, DocDocumentOptions).TextMode = DocumentTextMode.Framed
               Case 4
                  documentFormat = documentFormat.Rtf
                  documentOptions = New RtfDocumentOptions()
                  TryCast(documentOptions, RtfDocumentOptions).TextMode = DocumentTextMode.Framed
               Case 5
                  documentFormat = documentFormat.Text
                  documentOptions = New TextDocumentOptions()
                  TryCast(documentOptions, TextDocumentOptions).DocumentType = TextDocumentType.Unicode
                  TryCast(documentOptions, TextDocumentOptions).Formatted = True

               Case 6
                  documentFormat = documentFormat.Html
                  documentOptions = New HtmlDocumentOptions()
                  TryCast(documentOptions, HtmlDocumentOptions).FontEmbedMode = DocumentFontEmbedMode.Auto

               Case 7
                  documentFormat = documentFormat.Docx
                  documentOptions = New DocxDocumentOptions()
                  TryCast(documentOptions, DocxDocumentOptions).TextMode = DocumentTextMode.Framed
               Case 8
                  documentFormat = documentFormat.Xps
                  documentOptions = New XpsDocumentOptions()
               Case 9
                  documentFormat = documentFormat.Xls
                  documentOptions = New XlsDocumentOptions()

               Case 10
                  SaveAsEmf(fileName)
                  Return result
            End Select

            Dim documentWriter As DocumentWriter = New DocumentWriter()
            documentWriter.SetOptions(documentFormat, documentOptions)
            documentWriter.BeginDocument(fileName, documentFormat)

            For Each metaFile As IntPtr In _lstMetaFiles
               Dim documentPage As DocumentWriterEmfPage = New DocumentWriterEmfPage()

               Dim index As Integer = _lstMetaFiles.IndexOf(metaFile)
               documentPage.EmfHandle = metaFile

               If saveFileDialog.FilterIndex = 2 Then
                  documentPage.Image = _codec.Load(_tempFiles(index))
               End If

               documentWriter.AddPage(documentPage)
            Next metaFile
            documentWriter.EndDocument()

            If ViewOutputFile Then
               System.Diagnostics.Process.Start(fileName)
            End If
         End If
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try

      Return result
   End Function

   Private Sub ClearList()
      Try
         For Each image As Image In _lstBoxPages.Items
            image.Dispose()
         Next image

         For Each emf As IntPtr In _lstMetaFiles
            Dim metaFile As Metafile = New Metafile(emf, True)
            metaFile.Dispose()
         Next emf
         _lstBoxPages.Items.Clear()
         _lstMetaFiles.Clear()
         _lstJobInfo.Clear()
         DeleteTempFiles()
         'Clear the font files when we delete all the jobs
         DeleteAndUninstallFonts()

         _tempFiles.Clear()

         If Not _pictureBox.Image Is Nothing Then
            _pictureBox.Image.Dispose()
            _pictureBox.Image = Nothing
         End If
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Function GetPrinterName(ByVal bShowInstall As Boolean) As Boolean
      Try
         Dim currentPrinterName As String = String.Empty

         If (Not bShowInstall) Then
            currentPrinterName = _currentPrinterName
         End If

         Dim frmGetPrinterName As FrmGetPrinterName = New FrmGetPrinterName(currentPrinterName)
         Dim dialogResult As DialogResult = frmGetPrinterName.ShowDialog()

         If dialogResult = dialogResult.OK AndAlso frmGetPrinterName.PrinterName <> _currentPrinterName Then
            _currentPrinterName = frmGetPrinterName.PrinterName
            SetCurrentPrinter()
            Return True
         Else
            Return False
         End If
      Catch
         Return False
      End Try
   End Function

   Private Sub LockPrinter()
      Try
         Dim frmPassword As FrmPassword = New FrmPassword(True)
         Dim dialogResult As DialogResult = frmPassword.ShowDialog()

         If dialogResult = dialogResult.OK Then
            Dim lockPassword As String = frmPassword.Password
            _printer.Lock(lockPassword)

            If IsCurrentPrinterLocked() Then
               MessageBox.Show("Printer is locked.  You will no longer be able to print to it.", "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
               MessageBox.Show("Incorrect password.", "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
         End If
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Sub UnLockPrinter()
      Try
         Dim frmPassword As FrmPassword = New FrmPassword(False)
         Dim dialogResult As DialogResult = frmPassword.ShowDialog()

         If dialogResult = dialogResult.OK Then
            Dim unLockPassword As String = frmPassword.Password
            _printer.UnLock(unLockPassword)

            If IsCurrentPrinterLocked() = False Then
               MessageBox.Show("Printer is unlocked.", "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
               MessageBox.Show("Incorrect password.", "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
         End If
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Function IsCurrentPrinterLocked() As Boolean
      Dim bPrinterLocked As Boolean = True

      Try
         bPrinterLocked = _printer.IsPrinterLocked()
      Catch Ex As PrinterDriverException
         If Ex.Code = PrinterDriverExceptionCode.PrinterCannotBeLocked Then
            bPrinterLocked = False
         End If
      End Try

      Return bPrinterLocked
   End Function

   Private Sub SetDefaultSpecs(ByVal printer As Printer)
      Dim specs As PrinterSpecifications = New PrinterSpecifications()
      specs.DimensionsInInches = True

      If PrinterSettings.InstalledPrinters.Count > 0 Then
         specs.MarginsPrinter = PrinterSettings.InstalledPrinters(0)
      End If

      specs.PaperHeight = 11
      specs.PaperID = 0
      specs.PaperSizeName = "Custom"
      specs.PaperWidth = 8
      specs.PortraitOrient = True
      specs.PrintQuality = -3
      specs.YResolution = 300

      printer.Specifications = specs
   End Sub

   Private Sub SetCurrentPrinter()
      Try

         Try
            _printer.Dispose()
         Catch ex As Exception

         End Try

         _printer = New Printer(_currentPrinterName)

         AddHandler _printer.EmfEvent, AddressOf _printer_EmfEvent

         AddHandler _printer.JobEvent, AddressOf _printer_JobEvent

         Me.Text = "LEADTOOLS VB Printer Demo - Active printer is: " & _currentPrinterName
      Catch Ex As Exception
         MessageBox.Show(Ex.Message, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Sub DrawStartedPage(ByVal graphics As Graphics)
      Try
         Const leftLocation As Single = 10
         Const topLocation As Single = 20
         Dim pointF As PointF = New PointF(leftLocation, topLocation)

         Dim drawingText As String = Constants.vbLf & "   LEADTOOLS Printer Main Demo" & Constants.vbLf & "   ------------------------------------------------------------ " & Constants.vbLf & "   This demo program demonstrates the usage of the LEADTOOLS Printer functionality. " & Constants.vbLf & "   ------------------------------------------------------------ " & Constants.vbLf + Constants.vbLf & "   You can use this demo in one of two ways: " & Constants.vbLf + Constants.vbLf & "   Printing from other applications: " & Constants.vbLf & "   1 - Print from any application to the currently selected printer (see the demo caption for the currently selected printer). " & Constants.vbLf & "   2 - From the main menu, select ""File | Save As"", then save the printed document as PDF, DOC, etc, or as a supported raster format. " & Constants.vbLf & "         You can repeat the save as many times as necessary. " & Constants.vbLf + Constants.vbLf & "   Printing from this application: " & Constants.vbLf & "   1 - From the main menu, select ""File | Print Start Page"", to print the contents of this page. " & Constants.vbLf & "   2 - From the main menu, select ""File | Save As"", then save the printed document as PDF, DOC, etc, or as a supported raster format. " & Constants.vbLf & "         You can repeat the save as many times as necessary. "

         Dim drawingFont As Font = New Font("Times New Roman", 11, FontStyle.Regular)
         Dim brush As Brush = Brushes.Blue
         graphics.DrawString(drawingText, drawingFont, brush, pointF)
      Catch
      End Try
   End Sub

   Private Sub DeleteTempFiles()
      For Each tempFile As String In _tempFiles
         If File.Exists(tempFile) Then
            File.Delete(tempFile)
         End If
      Next tempFile
   End Sub
#End Region

End Class
