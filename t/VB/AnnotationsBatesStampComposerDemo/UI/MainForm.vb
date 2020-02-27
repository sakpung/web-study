' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Drawing
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Drawing.Printing
Imports System.Text
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Reflection

Imports Leadtools
Imports Leadtools.Annotations
Imports Leadtools.WinForms
Imports Leadtools.Codecs
Imports Leadtools.Internal

Imports Leadtools.Drawing
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.Automation
Imports Leadtools.Annotations.Designers
Imports Leadtools.Annotations.Rendering
Imports System.Media
Imports System.Diagnostics
Imports Leadtools.Annotations.WinForms
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.Annotations.BatesStamp
Imports Leadtools.Controls
Imports System

Imports Leadtools.Demos.Dialogs

''' <summary>
''' Summary description for MainForm.
''' </summary>
'''
Public Class MainForm
   Inherits System.Windows.Forms.Form
   Private _randomNumber As New Random()
   Private _managerHelper As AutomationManagerHelper = Nothing
   Private _batesStampComposer As New AnnBatesStampComposer()
   Private _batesStampContainer As New AnnContainer()
   Private _openInitialPath As String = String.Empty

   Public ReadOnly Property ManagerHelper() As AutomationManagerHelper
      Get
         Return _managerHelper
      End Get
   End Property

   Private _mainMenu As System.Windows.Forms.MainMenu
   Private _menuItemFile As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemFileOpen As System.Windows.Forms.MenuItem
   Private _menuItemFileSep1 As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemFileExit As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemFilePrint As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemFilePrintPreview As System.Windows.Forms.MenuItem
   Private _menuItemFileSep2 As System.Windows.Forms.MenuItem
   Private _menuItemFileSep3 As System.Windows.Forms.MenuItem
   Private _menuItemHelp As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemHelpAbout As System.Windows.Forms.MenuItem
   Private _menuItemWindow As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemWindowCascade As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemWindowTileHorizontally As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemWindowTileVertically As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemWindowArrangeIcons As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemWindowCloseAll As System.Windows.Forms.MenuItem
   Private _menuItemView As System.Windows.Forms.MenuItem
   Private _menuItemViewSizeMode As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemViewSizeModeNormal As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemViewSizeModeStretch As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemViewSizeModeFitAlways As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemViewSizeModeFitWidth As System.Windows.Forms.MenuItem
   Private _menuItemViewZoom As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemViewZoomIn As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemViewZoomOut As System.Windows.Forms.MenuItem
   Private _menuItemViewZoomSep1 As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemViewZoomNormal As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemViewPaintProperties As System.Windows.Forms.MenuItem
   Private _menuItemViewSep1 As System.Windows.Forms.MenuItem
   Private WithEvents _toolBarMain As System.Windows.Forms.ToolBar
   Private _tbbSave As System.Windows.Forms.ToolBarButton
   Private _tbbOpen As System.Windows.Forms.ToolBarButton
   Private WithEvents _menuItemFileSaveBatesStamp As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemFileSaveImage As System.Windows.Forms.MenuItem
   Private _tbbZoomIn As System.Windows.Forms.ToolBarButton
   Private _tbbZoomOut As System.Windows.Forms.ToolBarButton
   Private _tbbNoZoom As System.Windows.Forms.ToolBarButton
   Private _sbMain As System.Windows.Forms.StatusBar
   Private _tbbSep3 As System.Windows.Forms.ToolBarButton
   Private WithEvents _menuItemViewZoomValue As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemViewSizeModeFit As System.Windows.Forms.MenuItem
   Private _menuItemViewSep2 As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemViewUseDpi As MenuItem
   Private _menuItemBatesStamp As MenuItem
   Private WithEvents _menuItemBatesStampProperties As MenuItem
   Private WithEvents _menuItemAnnotationsBurnBatesStamp As MenuItem
   Private WithEvents _menuItemFileSaveImageAs As MenuItem
   Private components As IContainer

   Public Sub New()
      '
      ' Required for Windows Form Designer support
      '
      InitializeComponent()

      '
      ' TODO: Add any constructor code after InitializeComponent call
      '
      InitClass()
   End Sub

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing Then
         CleanUp()

         If components IsNot Nothing Then
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
      Me.components = New System.ComponentModel.Container()
      Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
      Me._mainMenu = New System.Windows.Forms.MainMenu(Me.components)
      Me._menuItemFile = New System.Windows.Forms.MenuItem()
      Me._menuItemFileOpen = New System.Windows.Forms.MenuItem()
      Me._menuItemFileSaveImage = New System.Windows.Forms.MenuItem()
      Me._menuItemFileSaveImageAs = New System.Windows.Forms.MenuItem()
      Me._menuItemFileSaveBatesStamp = New System.Windows.Forms.MenuItem()
      Me._menuItemFileSep1 = New System.Windows.Forms.MenuItem()
      Me._menuItemFilePrint = New System.Windows.Forms.MenuItem()
      Me._menuItemFilePrintPreview = New System.Windows.Forms.MenuItem()
      Me._menuItemFileSep2 = New System.Windows.Forms.MenuItem()
      Me._menuItemFileSep3 = New System.Windows.Forms.MenuItem()
      Me._menuItemFileExit = New System.Windows.Forms.MenuItem()
      Me._menuItemView = New System.Windows.Forms.MenuItem()
      Me._menuItemViewSizeMode = New System.Windows.Forms.MenuItem()
      Me._menuItemViewSizeModeNormal = New System.Windows.Forms.MenuItem()
      Me._menuItemViewSizeModeStretch = New System.Windows.Forms.MenuItem()
      Me._menuItemViewSizeModeFitAlways = New System.Windows.Forms.MenuItem()
      Me._menuItemViewSizeModeFitWidth = New System.Windows.Forms.MenuItem()
      Me._menuItemViewSizeModeFit = New System.Windows.Forms.MenuItem()
      Me._menuItemViewZoom = New System.Windows.Forms.MenuItem()
      Me._menuItemViewZoomIn = New System.Windows.Forms.MenuItem()
      Me._menuItemViewZoomOut = New System.Windows.Forms.MenuItem()
      Me._menuItemViewZoomValue = New System.Windows.Forms.MenuItem()
      Me._menuItemViewZoomSep1 = New System.Windows.Forms.MenuItem()
      Me._menuItemViewZoomNormal = New System.Windows.Forms.MenuItem()
      Me._menuItemViewSep1 = New System.Windows.Forms.MenuItem()
      Me._menuItemViewPaintProperties = New System.Windows.Forms.MenuItem()
      Me._menuItemViewUseDpi = New System.Windows.Forms.MenuItem()
      Me._menuItemViewSep2 = New System.Windows.Forms.MenuItem()
      Me._menuItemBatesStamp = New System.Windows.Forms.MenuItem()
      Me._menuItemBatesStampProperties = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsBurnBatesStamp = New System.Windows.Forms.MenuItem()
      Me._menuItemWindow = New System.Windows.Forms.MenuItem()
      Me._menuItemWindowCascade = New System.Windows.Forms.MenuItem()
      Me._menuItemWindowTileHorizontally = New System.Windows.Forms.MenuItem()
      Me._menuItemWindowTileVertically = New System.Windows.Forms.MenuItem()
      Me._menuItemWindowArrangeIcons = New System.Windows.Forms.MenuItem()
      Me._menuItemWindowCloseAll = New System.Windows.Forms.MenuItem()
      Me._menuItemHelp = New System.Windows.Forms.MenuItem()
      Me._menuItemHelpAbout = New System.Windows.Forms.MenuItem()
      Me._toolBarMain = New System.Windows.Forms.ToolBar()
      Me._tbbOpen = New System.Windows.Forms.ToolBarButton()
      Me._tbbSave = New System.Windows.Forms.ToolBarButton()
      Me._tbbSep3 = New System.Windows.Forms.ToolBarButton()
      Me._tbbZoomIn = New System.Windows.Forms.ToolBarButton()
      Me._tbbZoomOut = New System.Windows.Forms.ToolBarButton()
      Me._tbbNoZoom = New System.Windows.Forms.ToolBarButton()
      Me._sbMain = New System.Windows.Forms.StatusBar()
      Me.SuspendLayout()
      ' 
      ' _mainMenu
      ' 
      Me._mainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemFile, Me._menuItemView, Me._menuItemBatesStamp, Me._menuItemWindow, Me._menuItemHelp})
      ' 
      ' _menuItemFile
      ' 
      Me._menuItemFile.Index = 0
      Me._menuItemFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemFileOpen, Me._menuItemFileSaveImage, Me._menuItemFileSaveImageAs, Me._menuItemFileSaveBatesStamp, Me._menuItemFileSep1, Me._menuItemFilePrint, _
       Me._menuItemFilePrintPreview, Me._menuItemFileSep2, Me._menuItemFileSep3, Me._menuItemFileExit})
      Me._menuItemFile.Text = "&File"
      ' 
      ' _menuItemFileOpen
      ' 
      Me._menuItemFileOpen.Index = 0
      Me._menuItemFileOpen.RadioCheck = True
      Me._menuItemFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
      Me._menuItemFileOpen.Text = "&Open..."
      ' 
      ' _menuItemFileSaveImage
      ' 
      Me._menuItemFileSaveImage.Index = 1
      Me._menuItemFileSaveImage.Shortcut = System.Windows.Forms.Shortcut.CtrlS
      Me._menuItemFileSaveImage.Text = "&Save Image"
      ' 
      ' _menuItemFileSaveImageAs
      ' 
      Me._menuItemFileSaveImageAs.Index = 2
      Me._menuItemFileSaveImageAs.Text = "Save Image &As..."
      ' 
      ' _menuItemFileSaveBatesStamp
      ' 
      Me._menuItemFileSaveBatesStamp.Enabled = False
      Me._menuItemFileSaveBatesStamp.Index = 3
      Me._menuItemFileSaveBatesStamp.RadioCheck = True
      Me._menuItemFileSaveBatesStamp.Text = "Save &Bates Stamp"
      ' 
      ' _menuItemFileSep1
      ' 
      Me._menuItemFileSep1.Index = 4
      Me._menuItemFileSep1.RadioCheck = True
      Me._menuItemFileSep1.Text = "-"
      ' 
      ' _menuItemFilePrint
      ' 
      Me._menuItemFilePrint.Index = 5
      Me._menuItemFilePrint.RadioCheck = True
      Me._menuItemFilePrint.Shortcut = System.Windows.Forms.Shortcut.CtrlP
      Me._menuItemFilePrint.Text = "&Print..."
      ' 
      ' _menuItemFilePrintPreview
      ' 
      Me._menuItemFilePrintPreview.Index = 6
      Me._menuItemFilePrintPreview.RadioCheck = True
      Me._menuItemFilePrintPreview.Text = "Print Pre&view..."
      ' 
      ' _menuItemFileSep2
      ' 
      Me._menuItemFileSep2.Index = 7
      Me._menuItemFileSep2.RadioCheck = True
      Me._menuItemFileSep2.Text = "-"
      ' 
      ' _menuItemFileSep3
      ' 
      Me._menuItemFileSep3.Index = 8
      Me._menuItemFileSep3.RadioCheck = True
      Me._menuItemFileSep3.Text = "-"
      ' 
      ' _menuItemFileExit
      ' 
      Me._menuItemFileExit.Index = 9
      Me._menuItemFileExit.RadioCheck = True
      Me._menuItemFileExit.Text = "E&xit"
      ' 
      ' _menuItemView
      ' 
      Me._menuItemView.Index = 1
      Me._menuItemView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemViewSizeMode, Me._menuItemViewZoom, Me._menuItemViewSep1, Me._menuItemViewPaintProperties, Me._menuItemViewUseDpi, Me._menuItemViewSep2})
      Me._menuItemView.Text = "&View"
      ' 
      ' _menuItemViewSizeMode
      ' 
      Me._menuItemViewSizeMode.Index = 0
      Me._menuItemViewSizeMode.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemViewSizeModeNormal, Me._menuItemViewSizeModeStretch, Me._menuItemViewSizeModeFitAlways, Me._menuItemViewSizeModeFitWidth, Me._menuItemViewSizeModeFit})
      Me._menuItemViewSizeMode.RadioCheck = True
      Me._menuItemViewSizeMode.Text = "&Size Mode"
      ' 
      ' _menuItemViewSizeModeNormal
      ' 
      Me._menuItemViewSizeModeNormal.Index = 0
      Me._menuItemViewSizeModeNormal.RadioCheck = True
      Me._menuItemViewSizeModeNormal.Text = "&Normal"
      ' 
      ' _menuItemViewSizeModeStretch
      ' 
      Me._menuItemViewSizeModeStretch.Index = 1
      Me._menuItemViewSizeModeStretch.RadioCheck = True
      Me._menuItemViewSizeModeStretch.Text = "&Stretch"
      ' 
      ' _menuItemViewSizeModeFitAlways
      ' 
      Me._menuItemViewSizeModeFitAlways.Index = 2
      Me._menuItemViewSizeModeFitAlways.RadioCheck = True
      Me._menuItemViewSizeModeFitAlways.Text = "Fit &Always"
      ' 
      ' _menuItemViewSizeModeFitWidth
      ' 
      Me._menuItemViewSizeModeFitWidth.Index = 3
      Me._menuItemViewSizeModeFitWidth.RadioCheck = True
      Me._menuItemViewSizeModeFitWidth.Text = "Fit &Width"
      ' 
      ' _menuItemViewSizeModeFit
      ' 
      Me._menuItemViewSizeModeFit.Index = 4
      Me._menuItemViewSizeModeFit.RadioCheck = True
      Me._menuItemViewSizeModeFit.Text = "&Fit"
      ' 
      ' _menuItemViewZoom
      ' 
      Me._menuItemViewZoom.Index = 1
      Me._menuItemViewZoom.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemViewZoomIn, Me._menuItemViewZoomOut, Me._menuItemViewZoomValue, Me._menuItemViewZoomSep1, Me._menuItemViewZoomNormal})
      Me._menuItemViewZoom.RadioCheck = True
      Me._menuItemViewZoom.Text = "&Zoom"
      ' 
      ' _menuItemViewZoomIn
      ' 
      Me._menuItemViewZoomIn.Index = 0
      Me._menuItemViewZoomIn.RadioCheck = True
      Me._menuItemViewZoomIn.Text = "&In"
      ' 
      ' _menuItemViewZoomOut
      ' 
      Me._menuItemViewZoomOut.Index = 1
      Me._menuItemViewZoomOut.RadioCheck = True
      Me._menuItemViewZoomOut.Text = "&Out"
      ' 
      ' _menuItemViewZoomValue
      ' 
      Me._menuItemViewZoomValue.Index = 2
      Me._menuItemViewZoomValue.Text = "&Value..."
      ' 
      ' _menuItemViewZoomSep1
      ' 
      Me._menuItemViewZoomSep1.Index = 3
      Me._menuItemViewZoomSep1.RadioCheck = True
      Me._menuItemViewZoomSep1.Text = "-"
      ' 
      ' _menuItemViewZoomNormal
      ' 
      Me._menuItemViewZoomNormal.Index = 4
      Me._menuItemViewZoomNormal.RadioCheck = True
      Me._menuItemViewZoomNormal.Text = "&Normal (100%)"
      ' 
      ' _menuItemViewSep1
      ' 
      Me._menuItemViewSep1.Index = 2
      Me._menuItemViewSep1.RadioCheck = True
      Me._menuItemViewSep1.Text = "-"
      ' 
      ' _menuItemViewPaintProperties
      ' 
      Me._menuItemViewPaintProperties.Index = 3
      Me._menuItemViewPaintProperties.RadioCheck = True
      Me._menuItemViewPaintProperties.Text = "&Paint Properties..."
      ' 
      ' _menuItemViewUseDpi
      ' 
      Me._menuItemViewUseDpi.Index = 4
      Me._menuItemViewUseDpi.Text = "&Use Dpi"
      ' 
      ' _menuItemViewSep2
      ' 
      Me._menuItemViewSep2.Index = 5
      Me._menuItemViewSep2.Text = "-"
      ' 
      ' _menuItemBatesStamp
      ' 
      Me._menuItemBatesStamp.Index = 2
      Me._menuItemBatesStamp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemBatesStampProperties, Me._menuItemAnnotationsBurnBatesStamp})
      Me._menuItemBatesStamp.Text = "&Bates Stamp"
      ' 
      ' _menuItemBatesStampProperties
      ' 
      Me._menuItemBatesStampProperties.Index = 0
      Me._menuItemBatesStampProperties.Text = "Bates Stamp &Properties"
      ' 
      ' _menuItemAnnotationsBurnBatesStamp
      ' 
      Me._menuItemAnnotationsBurnBatesStamp.Index = 1
      Me._menuItemAnnotationsBurnBatesStamp.Text = "Burn Bates &Stamp"
      ' 
      ' _menuItemWindow
      ' 
      Me._menuItemWindow.Index = 3
      Me._menuItemWindow.MdiList = True
      Me._menuItemWindow.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemWindowCascade, Me._menuItemWindowTileHorizontally, Me._menuItemWindowTileVertically, Me._menuItemWindowArrangeIcons, Me._menuItemWindowCloseAll})
      Me._menuItemWindow.Text = "&Window"
      ' 
      ' _menuItemWindowCascade
      ' 
      Me._menuItemWindowCascade.Index = 0
      Me._menuItemWindowCascade.RadioCheck = True
      Me._menuItemWindowCascade.Shortcut = System.Windows.Forms.Shortcut.ShiftF5
      Me._menuItemWindowCascade.Text = "&Cascade"
      ' 
      ' _menuItemWindowTileHorizontally
      ' 
      Me._menuItemWindowTileHorizontally.Index = 1
      Me._menuItemWindowTileHorizontally.RadioCheck = True
      Me._menuItemWindowTileHorizontally.Shortcut = System.Windows.Forms.Shortcut.ShiftF4
      Me._menuItemWindowTileHorizontally.Text = "Tile &Horizontally"
      ' 
      ' _menuItemWindowTileVertically
      ' 
      Me._menuItemWindowTileVertically.Index = 2
      Me._menuItemWindowTileVertically.RadioCheck = True
      Me._menuItemWindowTileVertically.Text = "Tile &Vertically"
      ' 
      ' _menuItemWindowArrangeIcons
      ' 
      Me._menuItemWindowArrangeIcons.Index = 3
      Me._menuItemWindowArrangeIcons.RadioCheck = True
      Me._menuItemWindowArrangeIcons.Text = "Arrange &Icons"
      ' 
      ' _menuItemWindowCloseAll
      ' 
      Me._menuItemWindowCloseAll.Index = 4
      Me._menuItemWindowCloseAll.RadioCheck = True
      Me._menuItemWindowCloseAll.Text = "Close &All"
      ' 
      ' _menuItemHelp
      ' 
      Me._menuItemHelp.Index = 4
      Me._menuItemHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemHelpAbout})
      Me._menuItemHelp.Text = "&Help"
      ' 
      ' _menuItemHelpAbout
      ' 
      Me._menuItemHelpAbout.Index = 0
      Me._menuItemHelpAbout.RadioCheck = True
      Me._menuItemHelpAbout.Text = "&About..."
      ' 
      ' _toolBarMain
      ' 
      Me._toolBarMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me._toolBarMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me._tbbOpen, Me._tbbSave, Me._tbbSep3, Me._tbbZoomIn, Me._tbbZoomOut, Me._tbbNoZoom})
      Me._toolBarMain.DropDownArrows = True
      Me._toolBarMain.Location = New System.Drawing.Point(0, 0)
      Me._toolBarMain.Name = "_toolBarMain"
      Me._toolBarMain.ShowToolTips = True
      Me._toolBarMain.Size = New System.Drawing.Size(768, 28)
      Me._toolBarMain.TabIndex = 0
      ' 
      ' _tbbOpen
      ' 
      Me._tbbOpen.ImageIndex = 0
      Me._tbbOpen.Name = "_tbbOpen"
      Me._tbbOpen.ToolTipText = "Open File"
      ' 
      ' _tbbSave
      ' 
      Me._tbbSave.ImageIndex = 1
      Me._tbbSave.Name = "_tbbSave"
      Me._tbbSave.ToolTipText = "Save Image"
      ' 
      ' _tbbSep3
      ' 
      Me._tbbSep3.Name = "_tbbSep3"
      Me._tbbSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      ' 
      ' _tbbZoomIn
      ' 
      Me._tbbZoomIn.ImageIndex = 7
      Me._tbbZoomIn.Name = "_tbbZoomIn"
      Me._tbbZoomIn.ToolTipText = "Zoom In"
      ' 
      ' _tbbZoomOut
      ' 
      Me._tbbZoomOut.ImageIndex = 8
      Me._tbbZoomOut.Name = "_tbbZoomOut"
      Me._tbbZoomOut.ToolTipText = "Zoom Out"
      ' 
      ' _tbbNoZoom
      ' 
      Me._tbbNoZoom.ImageIndex = 9
      Me._tbbNoZoom.Name = "_tbbNoZoom"
      Me._tbbNoZoom.ToolTipText = "No Zoom (100%)"
      ' 
      ' _sbMain
      ' 
      Me._sbMain.Location = New System.Drawing.Point(0, 593)
      Me._sbMain.Name = "_sbMain"
      Me._sbMain.Size = New System.Drawing.Size(768, 22)
      Me._sbMain.TabIndex = 2
      ' 
      ' MainForm
      ' 
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(768, 615)
      Me.Controls.Add(Me._sbMain)
      Me.Controls.Add(Me._toolBarMain)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.IsMdiContainer = True
      Me.Menu = Me._mainMenu
      Me.Name = "MainForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "MainForm"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
#End Region

   ''' <summary>
   ''' The main entry point for the application.
   ''' </summary>
   <STAThread()> _
   Shared Sub Main()
      Dim startupMsgBox As StartupMessageBox = New StartupMessageBox("VBAnnotationsBatesStampComposerDemo")
      If (startupMsgBox.ShowStartUpDialog) Then
         startupMsgBox.ShowDialog()
      End If
      

      If Not Support.SetLicense() Then
         Return
      End If

      If RasterSupport.IsLocked(RasterSupportType.Document) Then
         MessageBox.Show([String].Format("{0} Support is locked!", RasterSupportType.Document.ToString()), "Warning")
         Return
      End If

      Application.EnableVisualStyles()
      Application.DoEvents()

      Application.Run(New MainForm())
   End Sub

   Private _codecs As RasterCodecs
   Private _annCodecs As AnnCodecs
   Private _printDocument As PrintDocument
   Private _paintProperties As RasterPaintProperties
   Private _automationManager As AnnAutomationManager

   Private Shared ReadOnly _minimumScaleFactor As Single = 0.05F
   Private Shared ReadOnly _maximumScaleFactor As Single = 11.0F

   Public ReadOnly Property AutomationManager() As AnnAutomationManager
      Get
         Return _automationManager
      End Get
   End Property

   Public ReadOnly Property AnnCodecs() As AnnCodecs
      Get
         Return _annCodecs
      End Get
   End Property

   Private Sub InitClass()
      Messager.Caption = "LEADTOOLS VB BatesStamp Composer Demo"
      Text = Messager.Caption

      _codecs = New RasterCodecs()
      _annCodecs = New AnnCodecs()
      Dim options As New AnnDeserializeOptions()

      _annCodecs.DeserializeOptions = options

      _paintProperties = RasterPaintProperties.[Default]
      _paintProperties.PaintDisplayMode = _paintProperties.PaintDisplayMode Or RasterPaintDisplayModeFlags.ScaleToGray

      Try

         If PrinterSettings.InstalledPrinters IsNot Nothing AndAlso PrinterSettings.InstalledPrinters.Count > 0 Then
            _printDocument = New PrintDocument()
            AddHandler _printDocument.BeginPrint, AddressOf _printDocument_BeginPrint
            AddHandler _printDocument.PrintPage, AddressOf _printDocument_PrintPage
            AddHandler _printDocument.EndPrint, AddressOf _printDocument_EndPrint
         Else
            _printDocument = Nothing
         End If
      Catch generatedExceptionName As Exception
         _printDocument = Nothing
      End Try

      InitToolbar()
      InitAutomation()

      LoadImage(True)

      UpdateControls()
   End Sub

   Private Sub InitToolbar()
      Dim btmp As New Bitmap([GetType](), "MainToolbar.bmp")
      btmp.MakeTransparent(btmp.GetPixel(0, 0))

      _toolBarMain.ImageList = New ImageList()
      _toolBarMain.ImageList.ImageSize = New Size(btmp.Height, btmp.Height)
      _toolBarMain.ImageList.Images.AddStrip(btmp)
   End Sub

   Private Sub InitAutomation()
      _automationManager = New AnnAutomationManager()
      _automationManager.CreateDefaultObjects()
      _managerHelper = New AutomationManagerHelper(_automationManager)
   End Sub

   Public Sub UpdateControls()
      Dim annForm As AnnotationsForm = ActiveAnnotationsForm

      If annForm Is Nothing Then
         _menuItemFileSaveImage.Enabled = False
         _menuItemFileSaveImage.Visible = False
         _menuItemFileSaveImageAs.Enabled = False
         _menuItemFileSaveImageAs.Visible = False
         _menuItemFileSaveBatesStamp.Enabled = False
         _menuItemFileSaveBatesStamp.Visible = False
         _tbbSave.Enabled = False
         _tbbSave.Visible = False

         _menuItemFilePrint.Enabled = False
         _menuItemFilePrint.Visible = False
         _menuItemFilePrintPreview.Enabled = False
         _menuItemFilePrintPreview.Visible = False
         _menuItemFileSep2.Visible = False

         _menuItemView.Enabled = False
         _menuItemView.Visible = False

         _menuItemWindow.Enabled = False
         _menuItemWindow.Visible = False

         _tbbSep3.Visible = False
         _tbbZoomIn.Visible = False
         _tbbZoomOut.Visible = False
         _tbbNoZoom.Visible = False

         _menuItemBatesStamp.Visible = False
      Else
         Dim automation As AnnAutomation = annForm.Automation
         Dim viewer As ImageViewer = annForm.Viewer

         Dim designMode As Boolean = _automationManager.UserMode = AnnUserMode.Design

         _menuItemFileSaveImage.Enabled = True
         _menuItemFileSaveImage.Visible = True
         _menuItemFileSaveImageAs.Enabled = True
         _menuItemFileSaveImageAs.Visible = True

         If _batesStampComposer IsNot Nothing AndAlso _batesStampComposer.Stamps.Count > 0 Then
            _menuItemFileSaveBatesStamp.Enabled = True
         End If

         _menuItemFileSaveBatesStamp.Visible = True
         _tbbSave.Enabled = True
         _tbbSave.Visible = True

         _menuItemFilePrint.Enabled = _printDocument IsNot Nothing
         _menuItemFilePrint.Visible = _printDocument IsNot Nothing
         _menuItemFilePrintPreview.Enabled = _printDocument IsNot Nothing AndAlso DialogUtilities.CanRunPrintPreview
         _menuItemFilePrintPreview.Visible = _printDocument IsNot Nothing AndAlso DialogUtilities.CanRunPrintPreview
         _menuItemFileSep2.Visible = _printDocument IsNot Nothing

         _menuItemView.Enabled = True
         _menuItemView.Visible = True

         _menuItemViewSizeModeNormal.Checked = (viewer.SizeMode = ControlSizeMode.None)
         _menuItemViewSizeModeStretch.Checked = (viewer.SizeMode = ControlSizeMode.Stretch)
         _menuItemViewSizeModeFitAlways.Checked = (viewer.SizeMode = ControlSizeMode.FitAlways)
         _menuItemViewSizeModeFitWidth.Checked = (viewer.SizeMode = ControlSizeMode.FitWidth)
         _menuItemViewSizeModeFit.Checked = (viewer.SizeMode = ControlSizeMode.Fit)
         _menuItemViewZoom.Enabled = (viewer.SizeMode = ControlSizeMode.None)

         _menuItemViewUseDpi.Checked = viewer.UseDpi

         _menuItemWindow.Enabled = True
         _menuItemWindow.Visible = True

         _tbbSep3.Visible = True

         _tbbZoomIn.Visible = True
         _tbbZoomOut.Visible = True
         _tbbNoZoom.Visible = True

         _tbbZoomIn.Enabled = _menuItemViewZoom.Enabled
         _tbbZoomOut.Enabled = _menuItemViewZoom.Enabled
         _tbbNoZoom.Enabled = _menuItemViewZoom.Enabled

         _menuItemBatesStamp.Visible = True
      End If
   End Sub

   Private Sub CleanUp()
      _managerHelper.Dispose()
   End Sub

   Private ReadOnly Property ActiveAnnotationsForm() As AnnotationsForm
      Get
         Return TryCast(ActiveMdiChild, AnnotationsForm)
      End Get
   End Property

   Private Sub MainForm_MdiChildActivate(sender As Object, e As System.EventArgs)Handles Me.MdiChildActivate
      If ActiveMdiChild IsNot Nothing Then
         Dim annForm As AnnotationsForm = TryCast(ActiveMdiChild, AnnotationsForm)
         Dim automation As AnnAutomation = annForm.Automation
         If Not automation.Active Then
            automation.Active = True
         End If
      End If

      UpdateControls()
   End Sub

   Private Sub _menuItemFileOpen_Click(sender As Object, e As System.EventArgs)Handles _menuItemFileOpen.Click
      LoadImage(False)
   End Sub

   Private Sub LoadImage(loadDefaultImage As Boolean)
      Dim loader As New ImageFileLoader()
      Dim bLoaded As Boolean = False

      loader.OpenDialogInitialPath = _openInitialPath
      Try
         loader.LoadOnlyOnePage = True

         If loadDefaultImage Then
#If LT_CLICKONCE Then
					bLoaded = loader.Load(Me, "clean.tif", _codecs, 1, 1)
#Else
#End If

            bLoaded = loader.Load(Me, DemosGlobal.ImagesFolder + "\ocr1.tif", _codecs, 1, 1)
         Else
            bLoaded = loader.Load(Me, _codecs, True) > 0
         End If

         If bLoaded Then
            _openInitialPath = Path.GetDirectoryName(loader.FileName)
            loader.Image.ChangeViewPerspective(RasterViewPerspective.TopLeft)
            NewAnnotationForm(loader.Image, loader.FileName)
         End If
      Catch ex As Exception
         If TypeOf ex Is TargetInvocationException AndAlso ex.InnerException IsNot Nothing Then
            Messager.ShowFileOpenError(Me, loader.FileName, ex.InnerException)
         Else
            Messager.ShowFileOpenError(Me, loader.FileName, ex)
         End If
      End Try
   End Sub

   Private Sub NewAnnotationForm(image As RasterImage, fileName As String)
      Dim child As New AnnotationsForm()
      child.MdiParent = Me
      child.Initialize(_paintProperties, image, fileName)
      child.WindowState = FormWindowState.Maximized

      Dim automation As AnnAutomation = child.Automation
      Dim mainContainer As AnnContainer = automation.Container

      _batesStampContainer.Size = mainContainer.Size
      _batesStampContainer.Mapper = mainContainer.Mapper.Clone()

      'Clear old ones
      _batesStampComposer.TargetContainers.Clear()

      'Attach batesStampContainer to _batesStampComposer to start applying stamp to it
      _batesStampComposer.TargetContainers.Add(_batesStampContainer)

      'Insert bates stamp container below all containers , to draw annotations objects above bates stamp
      automation.Containers.Insert(0, _batesStampContainer)

      automation.Invalidate(LeadRectD.Empty)

      child.Show()
   End Sub

   Private Sub _menuItemFileSaveImage_Click(sender As Object, e As System.EventArgs)Handles _menuItemFileSaveImage.Click
      Try
         Save(True, ActiveAnnotationsForm.Viewer.Image.OriginalFormat)
      Catch ex As Exception
         If TypeOf ex Is TargetInvocationException AndAlso ex.InnerException IsNot Nothing Then
            Messager.ShowFileSaveError(Me, ActiveAnnotationsForm.Text, ex.InnerException)
         Else
            Messager.ShowFileSaveError(Me, ActiveAnnotationsForm.Text, ex)
         End If
      End Try
   End Sub

   Private Sub _menuItemFileSaveImageAs_Click(sender As Object, e As EventArgs)Handles _menuItemFileSaveImageAs.Click
      Dim saver As New ImageFileSaver()

      Try
         Dim activeForm As AnnotationsForm = ActiveAnnotationsForm

         If saver.Save(Me, _codecs, activeForm.Viewer.Image) Then
            activeForm.Text = saver.FileName
            Save(False, saver.Format)
         End If
      Catch ex As Exception
         If TypeOf ex Is TargetInvocationException AndAlso ex.InnerException IsNot Nothing Then
            Messager.ShowFileSaveError(Me, saver.FileName, ex.InnerException)
         Else
            Messager.ShowFileSaveError(Me, saver.FileName, ex)
         End If
      End Try
   End Sub

   Private Sub _menuItemFileSaveBatesStamp_Click(sender As Object, e As System.EventArgs)Handles _menuItemFileSaveBatesStamp.Click
      Try
         Using saveDialog As New SaveFileDialog()
            saveDialog.Filter = "Xml Files | *.xml"
            saveDialog.DefaultExt = "xml"
            saveDialog.Title = "Save Bates Stamp"

            If saveDialog.ShowDialog() = DialogResult.OK Then
               SaveBatesStamp(saveDialog.FileName, _batesStampComposer)
            End If
         End Using
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try
   End Sub


   Private Sub _menuItemFilePrint_Click(sender As Object, e As System.EventArgs)Handles _menuItemFilePrint.Click
      If _printDocument IsNot Nothing Then
         Try
            Dim image As RasterImage = ActiveAnnotationsForm.Viewer.Image
            _printDocument.PrinterSettings.MinimumPage = 1
            _printDocument.PrinterSettings.MaximumPage = image.PageCount
            _printDocument.PrinterSettings.FromPage = 1
            _printDocument.PrinterSettings.ToPage = image.PageCount

            _printDocument.Print()
         Catch
         End Try
      End If
   End Sub

   Private Sub _menuItemFilePrintPreview_Click(sender As Object, e As System.EventArgs)Handles _menuItemFilePrintPreview.Click
      If _printDocument IsNot Nothing Then
         Try
            Using dlg As New PrintPreviewDialog()
               Dim image As RasterImage = ActiveAnnotationsForm.Viewer.Image
               _printDocument.PrinterSettings.MinimumPage = 1
               _printDocument.PrinterSettings.MaximumPage = image.PageCount
               _printDocument.PrinterSettings.FromPage = 1
               _printDocument.PrinterSettings.ToPage = image.PageCount

               dlg.Document = _printDocument
               dlg.WindowState = FormWindowState.Maximized
               dlg.ShowDialog(Me)
            End Using
         Catch
         End Try
      End If
   End Sub

   Private Sub _printDocument_BeginPrint(sender As Object, e As PrintEventArgs)
      ' Our document has only 1 page so there is no need to reset the print page number
   End Sub

   Private Sub _printDocument_PrintPage(sender As Object, e As PrintPageEventArgs)
      Dim form As AnnotationsForm = ActiveAnnotationsForm
      Dim image As RasterImage = form.Viewer.Image
      Dim g As Graphics = e.Graphics

      Dim pageBounds As Rectangle = e.PageBounds
      Dim bounds As LeadRect = LeadRect.Create(pageBounds.X, pageBounds.Y, pageBounds.Width, pageBounds.Height)

      Dim destRect As LeadRect = RasterImage.CalculatePaintModeRectangle(image.ImageWidth, image.ImageHeight, bounds, RasterPaintSizeMode.Fit, RasterPaintAlignMode.Near, RasterPaintAlignMode.Near)

      Dim container As AnnContainer = _batesStampContainer

      RasterImagePainter.Paint(image, g, destRect, RasterPaintProperties.[Default])

      Dim mapper As AnnContainerMapper = container.Mapper
      container.Mapper = New AnnContainerMapper(96, 96, 96, 96)

      Dim engine As New AnnWinFormsRenderingEngine(container, g)

      Dim viewer As ImageViewer = ActiveAnnotationsForm.Viewer
      engine.BurnToRectWithDpi(container.Mapper.RectToContainerCoordinates(destRect.ToLeadRectD()), 96, 96, 96, 96)

      container.Mapper = mapper

      ' Inform the printer whether we have no more pages to print
      e.HasMorePages = False
   End Sub

   Private Sub _printDocument_EndPrint(sender As Object, e As PrintEventArgs)
      ' Nothing to do here
   End Sub

   Private Sub _menuItemFileExit_Click(sender As Object, e As System.EventArgs)Handles _menuItemFileExit.Click
      Close()
   End Sub

   Private Sub _toolBarMain_ButtonClick(sender As Object, e As System.Windows.Forms.ToolBarButtonClickEventArgs)Handles _toolBarMain.ButtonClick
      If e.Button Is _tbbOpen Then
         _menuItemFileOpen.PerformClick()
      ElseIf e.Button Is _tbbSave Then
         _menuItemFileSaveImage.PerformClick()
      ElseIf e.Button Is _tbbZoomIn Then
         _menuItemViewZoomIn.PerformClick()
      ElseIf e.Button Is _tbbZoomOut Then
         _menuItemViewZoomOut.PerformClick()
      ElseIf e.Button Is _tbbNoZoom Then
         _menuItemViewZoomNormal.PerformClick()
      End If
   End Sub

   Private Sub _menuItemViewSizeMode_Click(sender As Object, e As System.EventArgs)Handles _menuItemViewSizeModeNormal.Click,_menuItemViewSizeModeStretch.Click,_menuItemViewSizeModeFitAlways.Click,_menuItemViewSizeModeFitWidth.Click,_menuItemViewSizeModeFit.Click
      Dim activeForm As AnnotationsForm = ActiveAnnotationsForm

      activeForm.Viewer.BeginUpdate()

      Dim viewer As ImageViewer = activeForm.Viewer
      Dim defaultZoomOrigin As LeadPoint = viewer.DefaultZoomOrigin
      If sender Is _menuItemViewSizeModeNormal Then
         viewer.Zoom(ControlSizeMode.ActualSize, 1, defaultZoomOrigin)
      ElseIf sender Is _menuItemViewSizeModeFitAlways Then
         viewer.Zoom(ControlSizeMode.FitAlways, 1, defaultZoomOrigin)
      ElseIf sender Is _menuItemViewSizeModeFitWidth Then
         viewer.Zoom(ControlSizeMode.FitWidth, 1, defaultZoomOrigin)
      ElseIf sender Is _menuItemViewSizeModeStretch Then
         viewer.Zoom(ControlSizeMode.Stretch, 1, defaultZoomOrigin)
      ElseIf sender Is _menuItemViewSizeModeFit Then
         viewer.Zoom(ControlSizeMode.Fit, 1, defaultZoomOrigin)
      End If

      activeForm.Viewer.EndUpdate()

      UpdateControls()
   End Sub

   Public Sub Zoom(zoomIn As Boolean)
      If zoomIn Then
         _menuItemViewZoomIn.PerformClick()
      Else
         _menuItemViewZoomOut.PerformClick()
      End If
   End Sub

   Private Sub _menuItemViewZoom_Click(sender As Object, e As System.EventArgs)Handles _menuItemViewZoomIn.Click,_menuItemViewZoomOut.Click,_menuItemViewZoomValue.Click,_menuItemViewZoomNormal.Click
      ' get the current center in logical units
      Dim viewer As ImageViewer = ActiveAnnotationsForm.Viewer
      ' get the active viewer
      Dim defaultZoomOrigin As LeadPoint = viewer.DefaultZoomOrigin

      ' zoom
      Dim scaleFactor As Double = viewer.ScaleFactor

      Const ratio As Single = 1.2F

      If sender Is _menuItemViewZoomIn Then
         scaleFactor *= ratio
      ElseIf sender Is _menuItemViewZoomOut Then
         scaleFactor /= ratio
      ElseIf sender Is _menuItemViewZoomNormal Then
         scaleFactor = 1
         viewer.Zoom(ControlSizeMode.None, 1, defaultZoomOrigin)
      Else
         Dim dlg As New ZoomDialog()
         dlg.Value = CInt(Math.Truncate(scaleFactor * 100))
         dlg.MinimumValue = CInt(Math.Truncate(_minimumScaleFactor * 100.0F))
         dlg.MaximumValue = CInt(Math.Truncate(_maximumScaleFactor * 100.0F))

         If dlg.ShowDialog(Me) = DialogResult.OK Then
            scaleFactor = CSng(dlg.Value) / 100.0F
         End If
      End If

      scaleFactor = Math.Max(_minimumScaleFactor, Math.Min(_maximumScaleFactor, scaleFactor))

      If viewer.ScaleFactor <> scaleFactor Then
         viewer.Zoom(ControlSizeMode.None, scaleFactor, defaultZoomOrigin)
      End If
   End Sub

   Private Sub _menuItemViewPaintProperties_Click(sender As Object, e As System.EventArgs)Handles _menuItemViewPaintProperties.Click
      Dim dlg As New PaintPropertiesDialog()
      dlg.PaintProperties = _paintProperties
      AddHandler dlg.Apply, AddressOf PaintPropertiesDialog_Apply
      dlg.ShowDialog(Me)
   End Sub

   Private Sub PaintPropertiesDialog_Apply(sender As Object, e As EventArgs)
      Dim dlg As PaintPropertiesDialog = TryCast(sender, PaintPropertiesDialog)
      _paintProperties = dlg.PaintProperties
      For Each i As AnnotationsForm In MdiChildren
         i.UpdatePaintProperties(_paintProperties)
      Next
   End Sub

   Private Sub _menuItemBatesStampProperties_Click(sender As Object, e As EventArgs)Handles _menuItemBatesStampProperties.Click
      Try
         Dim activeAutomationForm As AnnotationsForm = ActiveAnnotationsForm
         'Remove the old attached containers
         _batesStampComposer.TargetContainers.Clear()
         Dim batesStampDialog As New BatesStampDialog(activeAutomationForm.Viewer.Image, _batesStampComposer)
         batesStampDialog.ShowDialog()

         'Attach new container to let and to apply bates stamp to it
         _batesStampComposer.TargetContainers.Add(_batesStampContainer)
         activeAutomationForm.Automation.Invalidate(LeadRectD.Empty)
         UpdateControls()
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try
   End Sub

   Private Sub _menuItemAnnotationsBurnBatesStamp_Click(sender As Object, e As System.EventArgs) Handles _menuItemAnnotationsBurnBatesStamp.Click
      Dim activeForm As AnnotationsForm = ActiveAnnotationsForm
      If activeForm Is Nothing Then
         Return
      End If

      Dim rasterImage As RasterImage = activeForm.Viewer.Image

      Try
         Dim renderingEngine As AnnWinFormsRenderingEngine = New AnnWinFormsRenderingEngine()
         renderingEngine.Renderers = _managerHelper.AutomationManager.RenderingEngine.Renderers
         renderingEngine.Resources = _automationManager.Resources

         Dim autoResetOptions As ImageViewerAutoResetOptions = activeForm.Viewer.AutoResetOptions
         activeForm.Viewer.AutoResetOptions = ImageViewerAutoResetOptions.None
         activeForm.Viewer.Image = renderingEngine.RenderOnImage(_batesStampContainer, rasterImage)
         activeForm.Viewer.AutoResetOptions = autoResetOptions

      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateControls()
      End Try
   End Sub

   Private Sub _menuItemWindow_Click(sender As Object, e As System.EventArgs) Handles _menuItemWindowCascade.Click, _menuItemWindowTileHorizontally.Click, _menuItemWindowTileVertically.Click, _menuItemWindowArrangeIcons.Click, _menuItemWindowCloseAll.Click
      If sender Is _menuItemWindowCascade Then
         LayoutMdi(MdiLayout.Cascade)
      ElseIf sender Is _menuItemWindowTileHorizontally Then
         LayoutMdi(MdiLayout.TileHorizontal)
      ElseIf sender Is _menuItemWindowTileVertically Then
         LayoutMdi(MdiLayout.TileVertical)
      ElseIf sender Is _menuItemWindowArrangeIcons Then
         LayoutMdi(MdiLayout.ArrangeIcons)
      ElseIf sender Is _menuItemWindowCloseAll Then
         Dim i As Integer
         For i = MdiChildren.Length - 1 To 0 Step -1
            MdiChildren(i).Close()
         Next

         UpdateControls()
      End If
   End Sub

   Private Sub _menuItemHelpAbout_Click(sender As Object, e As System.EventArgs)Handles _menuItemHelpAbout.Click
      Using aboutDialog As New AboutDialog("BatesStampComposer", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub

   Public Sub SetStatusBarText(text As String)
      _sbMain.Text = text
   End Sub

   Public Sub Save(saveImage As Boolean, format As RasterImageFormat)
      Dim form As AnnotationsForm = ActiveAnnotationsForm
      Dim automation As AnnAutomation = form.Automation
      Dim image As RasterImage = form.Viewer.Image

      If saveImage Then
         Try
            _codecs.Save(image, form.Text, image.OriginalFormat, image.BitsPerPixel)
         Catch ex As RasterException
            If ex.Code = RasterExceptionCode.BitsPerPixel Then
               _codecs.Save(image, form.Text, image.OriginalFormat, 0)
            End If
         End Try

         format = image.OriginalFormat
      End If
   End Sub

   Private Sub SaveBatesStamp(fileName As String, composer As AnnBatesStampComposer)
      Try
         AnnBatesStampComposer.Save(fileName, composer)
      Catch ex As Exception
         If TypeOf ex Is TargetInvocationException AndAlso ex.InnerException IsNot Nothing Then
            Messager.ShowError(Me, ex.InnerException)
         Else
            Messager.ShowError(Me, ex)
         End If
      End Try
   End Sub

   Private Sub _menuItemViewUseDpi_Click(sender As Object, e As EventArgs)Handles _menuItemViewUseDpi.Click
      _menuItemViewUseDpi.Checked = Not _menuItemViewUseDpi.Checked
      ActiveAnnotationsForm.Viewer.UseDpi = _menuItemViewUseDpi.Checked
   End Sub

   Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs)Handles Me.FormClosing
      _managerHelper.Dispose()
      _batesStampComposer.Dispose()
      _batesStampComposer = Nothing
   End Sub
End Class
