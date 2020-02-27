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
Imports System.Text
Imports System.Collections.Generic

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.WinForms
Imports Leadtools.ImageProcessing
Imports Leadtools.Jpeg2000
Imports System.IO
Imports Leadtools.Controls
Imports Leadtools.Drawing
Imports Leadtools.Demos.Dialogs

Public Class MainForm
   Inherits System.Windows.Forms.Form

   Private components As System.ComponentModel.IContainer
   ''' <summary>
   ''' Required designer variable.
   ''' </summary>

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
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         CleanUp()
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
      Me.components = New System.ComponentModel.Container
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
      Me._mainMenu = New System.Windows.Forms.MainMenu(Me.components)
      Me._miFile = New System.Windows.Forms.MenuItem
      Me._miFileOpen = New System.Windows.Forms.MenuItem
      Me._miFileReadComposite = New System.Windows.Forms.MenuItem
      Me._miFileSeperator1 = New System.Windows.Forms.MenuItem
      Me._miFileClose = New System.Windows.Forms.MenuItem
      Me._miFileSeperator2 = New System.Windows.Forms.MenuItem
      Me._miFileSaveAs = New System.Windows.Forms.MenuItem
      Me._miFileSaveList = New System.Windows.Forms.MenuItem
      Me._miFileSaveComposite = New System.Windows.Forms.MenuItem
      Me._miFileAppendFrames = New System.Windows.Forms.MenuItem
      Me._miFileSeperator3 = New System.Windows.Forms.MenuItem
      Me._miFileExit = New System.Windows.Forms.MenuItem
      Me._miEdit = New System.Windows.Forms.MenuItem
      Me._miEditCopy = New System.Windows.Forms.MenuItem
      Me._miEditPaste = New System.Windows.Forms.MenuItem
      Me._miView = New System.Windows.Forms.MenuItem
      Me._miViewImages = New System.Windows.Forms.MenuItem
      Me._miViewSeparator1 = New System.Windows.Forms.MenuItem
      Me._miViewColor = New System.Windows.Forms.MenuItem
      Me._miViewOpacity = New System.Windows.Forms.MenuItem
      Me._miViewPreOpacity = New System.Windows.Forms.MenuItem
      Me._miAnimation = New System.Windows.Forms.MenuItem
      Me._miAnimationPlay = New System.Windows.Forms.MenuItem
      Me._miAnimationStop = New System.Windows.Forms.MenuItem
      Me._miAnimationSeperator1 = New System.Windows.Forms.MenuItem
      Me._miAnimationLoop = New System.Windows.Forms.MenuItem
      Me._miAnimationSeperator2 = New System.Windows.Forms.MenuItem
      Me._miAnimationSettings = New System.Windows.Forms.MenuItem
      Me._miAnimationSaveSettings = New System.Windows.Forms.MenuItem
      Me._miFileProcessing = New System.Windows.Forms.MenuItem
      Me._miFileProcessingFileInformation = New System.Windows.Forms.MenuItem
      Me._miFileProcessingSeperator1 = New System.Windows.Forms.MenuItem
      Me._miFileProcessingFragmentJPX = New System.Windows.Forms.MenuItem
      Me._miFileProcessingExtractFrames = New System.Windows.Forms.MenuItem
      Me._miBoxProcessing = New System.Windows.Forms.MenuItem
      Me._miBoxProcessingAppend = New System.Windows.Forms.MenuItem
      Me._miBPAppendIntellectualProperty = New System.Windows.Forms.MenuItem
      Me._miBPAppendDigitalSignature = New System.Windows.Forms.MenuItem
      Me._miBPAppendDesiredReproduction = New System.Windows.Forms.MenuItem
      Me._miBPAppendXML = New System.Windows.Forms.MenuItem
      Me._miBPAppendMPEG7 = New System.Windows.Forms.MenuItem
      Me._miBPAppendMediaData = New System.Windows.Forms.MenuItem
      Me._miBPAppendBinaryFilter = New System.Windows.Forms.MenuItem
      Me._miBPAppendAssociation = New System.Windows.Forms.MenuItem
      Me._miBPAppendFreeBox = New System.Windows.Forms.MenuItem
      Me._miBoxProcessingRead = New System.Windows.Forms.MenuItem
      Me._miBPReadIntellectualProperty = New System.Windows.Forms.MenuItem
      Me._miBPReadDigitalSignature = New System.Windows.Forms.MenuItem
      Me._miBPReadDesiredReproduction = New System.Windows.Forms.MenuItem
      Me._miBPReadXML = New System.Windows.Forms.MenuItem
      Me._miBPReadMPEG7 = New System.Windows.Forms.MenuItem
      Me._miBPReadMediaData = New System.Windows.Forms.MenuItem
      Me._miBPReadBinaryFilter = New System.Windows.Forms.MenuItem
      Me._miBPReadAssociation = New System.Windows.Forms.MenuItem
      Me._miBPReadFreeBox = New System.Windows.Forms.MenuItem
      Me._miGML = New System.Windows.Forms.MenuItem
      Me._miGMLAppend = New System.Windows.Forms.MenuItem
      Me._miGMLRead = New System.Windows.Forms.MenuItem
      Me._miWindow = New System.Windows.Forms.MenuItem
      Me._miWindowCascade = New System.Windows.Forms.MenuItem
      Me._miWindowTileHorizontally = New System.Windows.Forms.MenuItem
      Me._miWindowTileVertically = New System.Windows.Forms.MenuItem
      Me._miWindowArrangeIcons = New System.Windows.Forms.MenuItem
      Me._miWindowCloseAll = New System.Windows.Forms.MenuItem
      Me._miHelp = New System.Windows.Forms.MenuItem
      Me._miHelpAbout = New System.Windows.Forms.MenuItem
      Me.SuspendLayout()
      '
      '_mainMenu
      '
      Me._mainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFile, Me._miEdit, Me._miView, Me._miAnimation, Me._miFileProcessing, Me._miBoxProcessing, Me._miGML, Me._miWindow, Me._miHelp})
      '
      '_miFile
      '
      Me._miFile.Index = 0
      Me._miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFileOpen, Me._miFileReadComposite, Me._miFileSeperator1, Me._miFileClose, Me._miFileSeperator2, Me._miFileSaveAs, Me._miFileSaveList, Me._miFileSaveComposite, Me._miFileAppendFrames, Me._miFileSeperator3, Me._miFileExit})
      Me._miFile.Text = "&File"
      '
      '_miFileOpen
      '
      Me._miFileOpen.Index = 0
      Me._miFileOpen.RadioCheck = True
      Me._miFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
      Me._miFileOpen.Text = "&Open..."
      '
      '_miFileReadComposite
      '
      Me._miFileReadComposite.Index = 1
      Me._miFileReadComposite.Text = "Read &Composite..."
      '
      '_miFileSeperator1
      '
      Me._miFileSeperator1.Index = 2
      Me._miFileSeperator1.Text = "-"
      '
      '_miFileClose
      '
      Me._miFileClose.Index = 3
      Me._miFileClose.Text = "C&lose"
      '
      '_miFileSeperator2
      '
      Me._miFileSeperator2.Index = 4
      Me._miFileSeperator2.Text = "-"
      '
      '_miFileSaveAs
      '
      Me._miFileSaveAs.Index = 5
      Me._miFileSaveAs.RadioCheck = True
      Me._miFileSaveAs.Shortcut = System.Windows.Forms.Shortcut.CtrlS
      Me._miFileSaveAs.Text = "Sa&ve As..."
      '
      '_miFileSaveList
      '
      Me._miFileSaveList.Index = 6
      Me._miFileSaveList.Text = "&Save List..."
      '
      '_miFileSaveComposite
      '
      Me._miFileSaveComposite.Index = 7
      Me._miFileSaveComposite.Text = "S&ave Composite..."
      '
      '_miFileAppendFrames
      '
      Me._miFileAppendFrames.Index = 8
      Me._miFileAppendFrames.Text = "A&ppend Frames..."
      '
      '_miFileSeperator3
      '
      Me._miFileSeperator3.Index = 9
      Me._miFileSeperator3.Text = "-"
      '
      '_miFileExit
      '
      Me._miFileExit.Index = 10
      Me._miFileExit.RadioCheck = True
      Me._miFileExit.Text = "E&xit"
      '
      '_miEdit
      '
      Me._miEdit.Index = 1
      Me._miEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miEditCopy, Me._miEditPaste})
      Me._miEdit.Text = "&Edit"
      '
      '_miEditCopy
      '
      Me._miEditCopy.Index = 0
      Me._miEditCopy.RadioCheck = True
      Me._miEditCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC
      Me._miEditCopy.Text = "&Copy"
      '
      '_miEditPaste
      '
      Me._miEditPaste.Index = 1
      Me._miEditPaste.RadioCheck = True
      Me._miEditPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV
      Me._miEditPaste.Text = "&Paste"
      '
      '_miView
      '
      Me._miView.Index = 2
      Me._miView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miViewImages, Me._miViewSeparator1, Me._miViewColor, Me._miViewOpacity, Me._miViewPreOpacity})
      Me._miView.Text = "&View"
      '
      '_miViewImages
      '
      Me._miViewImages.Index = 0
      Me._miViewImages.Text = "&Images"
      '
      '_miViewSeparator1
      '
      Me._miViewSeparator1.Index = 1
      Me._miViewSeparator1.Text = "-"
      '
      '_miViewColor
      '
      Me._miViewColor.Index = 2
      Me._miViewColor.Text = "&Color Images"
      '
      '_miViewOpacity
      '
      Me._miViewOpacity.Index = 3
      Me._miViewOpacity.Text = "&Opacity Images"
      '
      '_miViewPreOpacity
      '
      Me._miViewPreOpacity.Index = 4
      Me._miViewPreOpacity.Text = "&PreOpacity Images"
      '
      '_miAnimation
      '
      Me._miAnimation.Index = 3
      Me._miAnimation.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miAnimationPlay, Me._miAnimationStop, Me._miAnimationSeperator1, Me._miAnimationLoop, Me._miAnimationSeperator2, Me._miAnimationSettings, Me._miAnimationSaveSettings})
      Me._miAnimation.Text = "&Animation"
      '
      '_miAnimationPlay
      '
      Me._miAnimationPlay.Index = 0
      Me._miAnimationPlay.Text = "&Play"
      '
      '_miAnimationStop
      '
      Me._miAnimationStop.Index = 1
      Me._miAnimationStop.Text = "&Stop"
      '
      '_miAnimationSeperator1
      '
      Me._miAnimationSeperator1.Index = 2
      Me._miAnimationSeperator1.Text = "-"
      '
      '_miAnimationLoop
      '
      Me._miAnimationLoop.Index = 3
      Me._miAnimationLoop.Text = "&Loop"
      '
      '_miAnimationSeperator2
      '
      Me._miAnimationSeperator2.Index = 4
      Me._miAnimationSeperator2.Text = "-"
      '
      '_miAnimationSettings
      '
      Me._miAnimationSettings.Index = 5
      Me._miAnimationSettings.Text = "Se&ttings..."
      '
      '_miAnimationSaveSettings
      '
      Me._miAnimationSaveSettings.Index = 6
      Me._miAnimationSaveSettings.Text = "S&ave Settings"
      '
      '_miFileProcessing
      '
      Me._miFileProcessing.Index = 4
      Me._miFileProcessing.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFileProcessingFileInformation, Me._miFileProcessingSeperator1, Me._miFileProcessingFragmentJPX, Me._miFileProcessingExtractFrames})
      Me._miFileProcessing.Text = "File &Processing"
      '
      '_miFileProcessingFileInformation
      '
      Me._miFileProcessingFileInformation.Index = 0
      Me._miFileProcessingFileInformation.Text = "File &Information"
      '
      '_miFileProcessingSeperator1
      '
      Me._miFileProcessingSeperator1.Index = 1
      Me._miFileProcessingSeperator1.Text = "-"
      '
      '_miFileProcessingFragmentJPX
      '
      Me._miFileProcessingFragmentJPX.Index = 2
      Me._miFileProcessingFragmentJPX.Text = "Fragment &Jpx"
      '
      '_miFileProcessingExtractFrames
      '
      Me._miFileProcessingExtractFrames.Index = 3
      Me._miFileProcessingExtractFrames.Text = "&Extract Frames"
      '
      '_miBoxProcessing
      '
      Me._miBoxProcessing.Index = 5
      Me._miBoxProcessing.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miBoxProcessingAppend, Me._miBoxProcessingRead})
      Me._miBoxProcessing.Text = "&Box Processing"
      '
      '_miBoxProcessingAppend
      '
      Me._miBoxProcessingAppend.Index = 0
      Me._miBoxProcessingAppend.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miBPAppendIntellectualProperty, Me._miBPAppendDigitalSignature, Me._miBPAppendDesiredReproduction, Me._miBPAppendXML, Me._miBPAppendMPEG7, Me._miBPAppendMediaData, Me._miBPAppendBinaryFilter, Me._miBPAppendAssociation, Me._miBPAppendFreeBox})
      Me._miBoxProcessingAppend.Text = "&Append"
      '
      '_miBPAppendIntellectualProperty
      '
      Me._miBPAppendIntellectualProperty.Index = 0
      Me._miBPAppendIntellectualProperty.Text = "&Intellectual Property"
      '
      '_miBPAppendDigitalSignature
      '
      Me._miBPAppendDigitalSignature.Index = 1
      Me._miBPAppendDigitalSignature.Text = "&Digital Signature"
      '
      '_miBPAppendDesiredReproduction
      '
      Me._miBPAppendDesiredReproduction.Index = 2
      Me._miBPAppendDesiredReproduction.Text = "Desired &Reproduction"
      '
      '_miBPAppendXML
      '
      Me._miBPAppendXML.Index = 3
      Me._miBPAppendXML.Text = "&XML"
      '
      '_miBPAppendMPEG7
      '
      Me._miBPAppendMPEG7.Index = 4
      Me._miBPAppendMPEG7.Text = "&MPEG7"
      '
      '_miBPAppendMediaData
      '
      Me._miBPAppendMediaData.Index = 5
      Me._miBPAppendMediaData.Text = "M&edia Data"
      '
      '_miBPAppendBinaryFilter
      '
      Me._miBPAppendBinaryFilter.Index = 6
      Me._miBPAppendBinaryFilter.Text = "&Binary Filter"
      '
      '_miBPAppendAssociation
      '
      Me._miBPAppendAssociation.Index = 7
      Me._miBPAppendAssociation.Text = "&Association"
      '
      '_miBPAppendFreeBox
      '
      Me._miBPAppendFreeBox.Index = 8
      Me._miBPAppendFreeBox.Text = "&Free Box"
      '
      '_miBoxProcessingRead
      '
      Me._miBoxProcessingRead.Index = 1
      Me._miBoxProcessingRead.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miBPReadIntellectualProperty, Me._miBPReadDigitalSignature, Me._miBPReadDesiredReproduction, Me._miBPReadXML, Me._miBPReadMPEG7, Me._miBPReadMediaData, Me._miBPReadBinaryFilter, Me._miBPReadAssociation, Me._miBPReadFreeBox})
      Me._miBoxProcessingRead.Text = "Read"
      '
      '_miBPReadIntellectualProperty
      '
      Me._miBPReadIntellectualProperty.Index = 0
      Me._miBPReadIntellectualProperty.Text = "&Intellectual Property"
      '
      '_miBPReadDigitalSignature
      '
      Me._miBPReadDigitalSignature.Index = 1
      Me._miBPReadDigitalSignature.Text = "&Digital Signature"
      '
      '_miBPReadDesiredReproduction
      '
      Me._miBPReadDesiredReproduction.Index = 2
      Me._miBPReadDesiredReproduction.Text = "Desired &Reproduction"
      '
      '_miBPReadXML
      '
      Me._miBPReadXML.Index = 3
      Me._miBPReadXML.Text = "&XML"
      '
      '_miBPReadMPEG7
      '
      Me._miBPReadMPEG7.Index = 4
      Me._miBPReadMPEG7.Text = "&MPEG7"
      '
      '_miBPReadMediaData
      '
      Me._miBPReadMediaData.Index = 5
      Me._miBPReadMediaData.Text = "M&edia Data"
      '
      '_miBPReadBinaryFilter
      '
      Me._miBPReadBinaryFilter.Index = 6
      Me._miBPReadBinaryFilter.Text = "&Binary Filter"
      '
      '_miBPReadAssociation
      '
      Me._miBPReadAssociation.Index = 7
      Me._miBPReadAssociation.Text = "&Association"
      '
      '_miBPReadFreeBox
      '
      Me._miBPReadFreeBox.Index = 8
      Me._miBPReadFreeBox.Text = "&Free Box"
      '
      '_miGML
      '
      Me._miGML.Index = 6
      Me._miGML.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miGMLAppend, Me._miGMLRead})
      Me._miGML.Text = "GML"
      '
      '_miGMLAppend
      '
      Me._miGMLAppend.Index = 0
      Me._miGMLAppend.Text = "&Append"
      '
      '_miGMLRead
      '
      Me._miGMLRead.Index = 1
      Me._miGMLRead.Text = "&Read"
      '
      '_miWindow
      '
      Me._miWindow.Index = 7
      Me._miWindow.MdiList = True
      Me._miWindow.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miWindowCascade, Me._miWindowTileHorizontally, Me._miWindowTileVertically, Me._miWindowArrangeIcons, Me._miWindowCloseAll})
      Me._miWindow.Text = "&Window"
      '
      '_miWindowCascade
      '
      Me._miWindowCascade.Index = 0
      Me._miWindowCascade.Shortcut = System.Windows.Forms.Shortcut.ShiftF5
      Me._miWindowCascade.Text = "&Cascade"
      '
      '_miWindowTileHorizontally
      '
      Me._miWindowTileHorizontally.Index = 1
      Me._miWindowTileHorizontally.Shortcut = System.Windows.Forms.Shortcut.ShiftF4
      Me._miWindowTileHorizontally.Text = "Tile &Horizontally"
      '
      '_miWindowTileVertically
      '
      Me._miWindowTileVertically.Index = 2
      Me._miWindowTileVertically.Text = "Tile &Vertically"
      '
      '_miWindowArrangeIcons
      '
      Me._miWindowArrangeIcons.Index = 3
      Me._miWindowArrangeIcons.Text = "Arrange &Icons"
      '
      '_miWindowCloseAll
      '
      Me._miWindowCloseAll.Index = 4
      Me._miWindowCloseAll.Text = "Close &All"
      '
      '_miHelp
      '
      Me._miHelp.Index = 8
      Me._miHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miHelpAbout})
      Me._miHelp.Text = "&Help"
      '
      '_miHelpAbout
      '
      Me._miHelpAbout.Index = 0
      Me._miHelpAbout.Text = "&About..."
      '
      'MainForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(705, 471)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.IsMdiContainer = True
      Me.Menu = Me._mainMenu
      Me.Name = "MainForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "MainForm"
      Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
      Me.ResumeLayout(False)

   End Sub
#End Region

   Private WithEvents _mainMenu As System.Windows.Forms.MainMenu
   Private WithEvents _miFile As System.Windows.Forms.MenuItem
   Private WithEvents _miFileOpen As System.Windows.Forms.MenuItem
   Private WithEvents _miFileReadComposite As System.Windows.Forms.MenuItem
   Private WithEvents _miFileSeperator1 As System.Windows.Forms.MenuItem
   Private WithEvents _miFileClose As System.Windows.Forms.MenuItem
   Private WithEvents _miFileSeperator2 As System.Windows.Forms.MenuItem
   Private WithEvents _miFileSaveAs As System.Windows.Forms.MenuItem
   Private WithEvents _miFileSaveList As System.Windows.Forms.MenuItem
   Private WithEvents _miFileSaveComposite As System.Windows.Forms.MenuItem
   Private WithEvents _miFileAppendFrames As System.Windows.Forms.MenuItem
   Private WithEvents _miFileSeperator3 As System.Windows.Forms.MenuItem
   Private WithEvents _miFileExit As System.Windows.Forms.MenuItem
   Private WithEvents _miEdit As System.Windows.Forms.MenuItem
   Private WithEvents _miEditCopy As System.Windows.Forms.MenuItem
   Private WithEvents _miEditPaste As System.Windows.Forms.MenuItem
   Private WithEvents _miView As System.Windows.Forms.MenuItem
   Private WithEvents _miViewImages As System.Windows.Forms.MenuItem
   Private WithEvents _miViewSeparator1 As System.Windows.Forms.MenuItem
   Private WithEvents _miViewColor As System.Windows.Forms.MenuItem
   Private WithEvents _miViewOpacity As System.Windows.Forms.MenuItem
   Private WithEvents _miViewPreOpacity As System.Windows.Forms.MenuItem
   Private WithEvents _miAnimation As System.Windows.Forms.MenuItem
   Private WithEvents _miAnimationPlay As System.Windows.Forms.MenuItem
   Private WithEvents _miAnimationStop As System.Windows.Forms.MenuItem
   Private WithEvents _miAnimationSeperator1 As System.Windows.Forms.MenuItem
   Private WithEvents _miAnimationLoop As System.Windows.Forms.MenuItem
   Private WithEvents _miAnimationSeperator2 As System.Windows.Forms.MenuItem
   Private WithEvents _miAnimationSettings As System.Windows.Forms.MenuItem
   Private WithEvents _miAnimationSaveSettings As System.Windows.Forms.MenuItem
   Private WithEvents _miFileProcessing As System.Windows.Forms.MenuItem
   Private WithEvents _miFileProcessingFileInformation As System.Windows.Forms.MenuItem
   Private WithEvents _miFileProcessingSeperator1 As System.Windows.Forms.MenuItem
   Private WithEvents _miFileProcessingFragmentJPX As System.Windows.Forms.MenuItem
   Private WithEvents _miFileProcessingExtractFrames As System.Windows.Forms.MenuItem
   Private WithEvents _miBoxProcessing As System.Windows.Forms.MenuItem
   Private WithEvents _miBoxProcessingAppend As System.Windows.Forms.MenuItem
   Private WithEvents _miBPAppendIntellectualProperty As System.Windows.Forms.MenuItem
   Private WithEvents _miBPAppendDigitalSignature As System.Windows.Forms.MenuItem
   Private WithEvents _miBPAppendDesiredReproduction As System.Windows.Forms.MenuItem
   Private WithEvents _miBPAppendXML As System.Windows.Forms.MenuItem
   Private WithEvents _miBPAppendMPEG7 As System.Windows.Forms.MenuItem
   Private WithEvents _miBPAppendMediaData As System.Windows.Forms.MenuItem
   Private WithEvents _miBPAppendBinaryFilter As System.Windows.Forms.MenuItem
   Private WithEvents _miBPAppendAssociation As System.Windows.Forms.MenuItem
   Private WithEvents _miBPAppendFreeBox As System.Windows.Forms.MenuItem
   Private WithEvents _miBoxProcessingRead As System.Windows.Forms.MenuItem
   Private WithEvents _miBPReadIntellectualProperty As System.Windows.Forms.MenuItem
   Private WithEvents _miBPReadDigitalSignature As System.Windows.Forms.MenuItem
   Private WithEvents _miBPReadDesiredReproduction As System.Windows.Forms.MenuItem
   Private WithEvents _miBPReadXML As System.Windows.Forms.MenuItem
   Private WithEvents _miBPReadMPEG7 As System.Windows.Forms.MenuItem
   Private WithEvents _miBPReadMediaData As System.Windows.Forms.MenuItem
   Private WithEvents _miBPReadBinaryFilter As System.Windows.Forms.MenuItem
   Private WithEvents _miBPReadAssociation As System.Windows.Forms.MenuItem
   Private WithEvents _miBPReadFreeBox As System.Windows.Forms.MenuItem
   Private WithEvents _miGML As System.Windows.Forms.MenuItem
   Private WithEvents _miGMLAppend As System.Windows.Forms.MenuItem
   Private WithEvents _miGMLRead As System.Windows.Forms.MenuItem
   Private WithEvents _miWindow As System.Windows.Forms.MenuItem
   Private WithEvents _miWindowCascade As System.Windows.Forms.MenuItem
   Private WithEvents _miWindowTileHorizontally As System.Windows.Forms.MenuItem
   Private WithEvents _miWindowTileVertically As System.Windows.Forms.MenuItem
   Private WithEvents _miWindowArrangeIcons As System.Windows.Forms.MenuItem
   Private WithEvents _miWindowCloseAll As System.Windows.Forms.MenuItem
   Private WithEvents _miHelp As System.Windows.Forms.MenuItem
   Private WithEvents _miHelpAbout As System.Windows.Forms.MenuItem
   Private _pasteCounter As Integer

   Private _codecs As RasterCodecs
   Private _fillColor As RasterColor
   Private _paintProperties As RasterPaintProperties
   Private _checkedWindowMenu As MenuItem
   Private _jpeg2000 As Jpeg2000Engine
   Private _noOpacityBitmap As RasterImage
   Private _noPreOpacityBitmap As RasterImage
   Private _animationTimer As Timer
   Private _openInitialPath As String = ""

   Public Property AnimationTimer() As Timer
      Get
         Return _animationTimer
      End Get
      Set(ByVal value As Timer)
         _animationTimer = value
      End Set
   End Property

   Public Property Codecs() As RasterCodecs
      Get
         Return _codecs
      End Get
      Set(ByVal value As RasterCodecs)
         _codecs = value
      End Set
   End Property

   Public Property NoOpacityBitmap() As RasterImage
      Get
         Return _noOpacityBitmap
      End Get
      Set(ByVal value As RasterImage)
         _noOpacityBitmap = value
      End Set
   End Property

   Public Property NoPreOpacityBitmap() As RasterImage
      Get
         Return _noPreOpacityBitmap
      End Get
      Set(ByVal value As RasterImage)
         _noPreOpacityBitmap = value
      End Set
   End Property

   Public Property Jpeg2000Eng() As Jpeg2000Engine
      Get
         Return _jpeg2000
      End Get
      Set(ByVal value As Jpeg2000Engine)
         _jpeg2000 = value
      End Set
   End Property

   Public ReadOnly Property ActiveViewerForm() As ViewerForm
      Get
         Return CType(ActiveMdiChild, ViewerForm)
      End Get
   End Property

   ''' <summary>
   ''' The main entry point for the application.
   ''' </summary>
   <STAThread()> _
   Shared Sub Main()
      
      If Not Support.SetLicense() Then
         Return
      End If

      Application.EnableVisualStyles()
      Application.DoEvents()

      Application.Run(New MainForm)
   End Sub

   Private Sub InitClass()
      Messager.Caption = "LEADTOOLS for .NET VB JPX Demo"
      Text = Messager.Caption

      _codecs = New RasterCodecs()

      Try
         Jpeg2000Eng = New Jpeg2000Engine()
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try

      _fillColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.White)
      _paintProperties = RasterPaintProperties.Default
      _paintProperties.PaintDisplayMode = _paintProperties.PaintDisplayMode Or RasterPaintDisplayModeFlags.ScaleToGray

      _checkedWindowMenu = _miWindowCascade
      _checkedWindowMenu.Checked = True

      Try
         NoOpacityBitmap = RasterImageConverter.ConvertFromImage(New Bitmap(Me.GetType(), "No_Opacity.bmp"), ConvertFromImageOptions.None)
         NoPreOpacityBitmap = RasterImageConverter.ConvertFromImage(New Bitmap(Me.GetType(), "No_PreOpacity.bmp"), ConvertFromImageOptions.None)

      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try

      AnimationTimer = New Timer()
      AddHandler AnimationTimer.Tick, AddressOf AnimationTimer_Tick

      LoadImage(True)
      UpdateControls()
   End Sub

   Private Sub CleanUp()
   End Sub

   Public Sub UpdateControls()
      Dim activeForm As ViewerForm = ActiveViewerForm

      EnableAndVisibleMenu(_miFileClose, Not IsNothing(activeForm))
      EnableAndVisibleMenu(_miFileSeperator2, Not IsNothing(activeForm))

      EnableAndVisibleMenu(_miFileSaveAs, Not IsNothing(activeForm))
      EnableAndVisibleMenu(_miFileSaveList, Not IsNothing(activeForm))
      EnableAndVisibleMenu(_miFileSaveComposite, Not IsNothing(activeForm))
      EnableAndVisibleMenu(_miFileAppendFrames, Not IsNothing(activeForm))
      EnableAndVisibleMenu(_miFileSeperator3, Not IsNothing(activeForm))

      EnableAndVisibleMenu(_miEditCopy, Not IsNothing(activeForm))
      _miEditPaste.Enabled = RasterClipboard.IsReady

      EnableAndVisibleMenu(_miView, Not IsNothing(activeForm))

      If (Not IsNothing(activeForm)) Then
         ClearCheck()
         _miViewImages.Enabled = activeForm.IsComposite
         _miViewSeparator1.Enabled = activeForm.IsComposite
         _miViewColor.Enabled = activeForm.IsComposite
         _miViewOpacity.Enabled = activeForm.IsComposite
         _miViewPreOpacity.Enabled = activeForm.IsComposite

         If (activeForm.IsComposite) Then
            SetCheck(ActiveViewerForm.ActiveList)
         End If
      End If

      EnableAndVisibleMenu(_miAnimation, Not IsNothing(activeForm))
      EnableAndVisibleMenu(_miAnimationPlay, Not IsNothing(activeForm))
      EnableAndVisibleMenu(_miAnimationStop, Not IsNothing(activeForm))
      EnableAndVisibleMenu(_miAnimationLoop, Not IsNothing(activeForm))

      If (Not IsNothing(activeForm)) Then
         _miAnimationLoop.Checked = ActiveViewerForm.LoopAnimation

         Dim enableAnimation As Boolean

         If (activeForm.ActiveList = ViewerForm.ActiveImageLists.ColorList OrElse _
             activeForm.ActiveList = ViewerForm.ActiveImageLists.ImagesList) Then
            enableAnimation = True
         Else
            enableAnimation = False
         End If

         _miAnimationPlay.Enabled = enableAnimation
         _miAnimationStop.Enabled = enableAnimation AndAlso activeForm.PlayingAnnimation
         _miAnimationLoop.Enabled = enableAnimation
      End If

      EnableAndVisibleMenu(_miAnimationSettings, Not IsNothing(activeForm))

      EnableAndVisibleMenu(_miWindow, Not IsNothing(activeForm))
   End Sub

   Private Sub EnableAndVisibleMenu(ByVal menu As MenuItem, ByVal value As Boolean)
      menu.Enabled = value
      menu.Visible = value
   End Sub

   Private Sub _miFileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileOpen.Click
      LoadImage(False)
      UpdateControls()
   End Sub

   Private Sub LoadImage(ByVal loadDefaultImage As Boolean)
      Dim loader As ImageFileLoader = New ImageFileLoader()

      Try
         loader.ShowLoadPagesDialog = True
         loader.OpenDialogInitialPath = _openInitialPath

         If loadDefaultImage Then
            If loader.Load(Me, DemosGlobal.ImagesFolder & "\image1.jpx", _codecs, 1, -1) Then
               NewImage(New ImageInformation(loader.Image, loader.FileName), True)
            End If
         Else
            If loader.Load(Me, _codecs, True) > 0 Then
               _openInitialPath = Path.GetDirectoryName(loader.FileName)
               NewImage(New ImageInformation(loader.Image, loader.FileName), True)
            End If
         End If
      Catch ex As Exception
         Messager.ShowFileOpenError(Me, loader.FileName, ex)
      End Try
   End Sub

   Private Sub _miFileReadComposite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileReadComposite.Click
      Dim ofd As New OpenFileDialog()

      ofd.Filter = "JPX JP2 Files(*.jpx*.jp2)|*.jpx;*.jp2|All Files(*.*)|*.*"
      ofd.Title = "Read Composite"

      If (ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         Dim wait As New WaitCursor()
         Try
            Dim imageList As List(Of CompositeJpxImages) = Jpeg2000Eng.LoadComposite(_codecs, ofd.FileName, 0, CodecsLoadByteOrder.BgrOrGray)

            NewImage(imageList, ofd.FileName)

            imageList.Clear()

         Catch ex As Exception
            Messager.ShowFileOpenError(Me, ofd.FileName, ex)
         Finally
            wait.Dispose()
         End Try
      End If
   End Sub

   Private Sub _miFileClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileClose.Click
      Dim activeForm As ViewerForm = ActiveViewerForm

      activeForm.Close()
   End Sub

   Private Sub _miFileSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileSaveAs.Click
      Dim saver As New ImageFileSaver()

      Try
         saver.Save(Me, _codecs, ActiveViewerForm.Viewer.Image)
      Catch ex As Exception
         Messager.ShowFileSaveError(Me, saver.FileName, ex)
      End Try
   End Sub

   Private Sub _miFileSaveList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileSaveList.Click
      Dim saveList As New SaveList(Me)

      saveList.ShowDialog()
   End Sub

   Private Sub _miFileSaveComposite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileSaveComposite.Click
      Dim saveComposite As New SaveComposite(Me, "Save Composite", "Save", True)

      saveComposite.ShowDialog()
   End Sub

   Private Sub _miFileAppendFrames_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileAppendFrames.Click
      Dim saveComposite As New SaveComposite(Me, "Append Frames", "Append", False)

      saveComposite.ShowDialog()
   End Sub

   Private Sub _miFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileExit.Click
      Close()
   End Sub

   Private Sub MainForm_MdiChildActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.MdiChildActivate
      UpdateControls()
   End Sub

   Private Sub _miEditCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miEditCopy.Click
      Try
         Dim wait As New WaitCursor
         Try
            RasterClipboard.Copy( _
               Me.Handle, _
               ImageToRun, _
               RasterClipboardCopyFlags.Empty Or _
               RasterClipboardCopyFlags.Dib Or _
               RasterClipboardCopyFlags.Palette Or _
               RasterClipboardCopyFlags.Region)
         Finally
            wait.Dispose()
         End Try
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateControls()
      End Try
   End Sub

   Private Sub _miEditPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miEditPaste.Click
      Try
         Dim wait As New WaitCursor
         Try
            Dim image As RasterImage = RasterClipboard.Paste(Me.Handle)

            Dim activeForm As ViewerForm = ActiveViewerForm

            If (Not IsNothing(image)) Then
               If (image.HasRegion AndAlso IsNothing(activeForm)) Then
                  image.MakeRegionEmpty()
               End If

               If (image.HasRegion) Then
                  ' make sure the images have the same BitsPerPixel and Palette
                  If (activeForm.Viewer.Image.BitsPerPixel > 8) Then
                     If (image.BitsPerPixel <> activeForm.Viewer.Image.BitsPerPixel) Then
                        Try
                           Dim colorRes As ColorResolutionCommand = New ColorResolutionCommand
                           colorRes.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel
                           colorRes.Order = activeForm.Viewer.Image.Order
                           colorRes.Mode = ColorResolutionCommandMode.InPlace
                           colorRes.Run(image)
                        Catch ex As Exception
                           Messager.ShowError(Me, ex)
                        End Try
                     End If
                  Else
                     Try
                        Dim colorRes As ColorResolutionCommand = New ColorResolutionCommand
                        colorRes.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel
                        colorRes.SetPalette(activeForm.Viewer.Image.GetPalette)
                        colorRes.PaletteFlags = ColorResolutionCommandPaletteFlags.UsePalette
                        colorRes.Mode = ColorResolutionCommandMode.InPlace
                        colorRes.Run(image)
                     Catch ex As Exception
                        Messager.ShowError(Me, ex)
                     End Try
                  End If
               Else
                  NewImage(New ImageInformation(image), False)
               End If
            End If
         Finally
            wait.Dispose()
         End Try
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateControls()
      End Try
   End Sub

   Private Sub _miView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miViewImages.Click, _
                                                                                                 _miViewColor.Click, _
                                                                                                 _miViewOpacity.Click, _
                                                                                                 _miViewPreOpacity.Click
      ClearCheck()

      Dim senderMenu As MenuItem = CType(sender, MenuItem)

      senderMenu.Checked = True

      ActiveViewerForm.ActiveList = CType(GetMenuIndex(senderMenu), ViewerForm.ActiveImageLists)
      ActiveViewerForm.FillImageList()
      UpdateControls()
   End Sub

   Private Function GetMenuIndex(ByVal menuItem As MenuItem) As Integer
      If (menuItem Is _miViewColor) Then
         Return 1
      ElseIf (menuItem Is _miViewOpacity) Then
         Return 2
      ElseIf (menuItem Is _miViewPreOpacity) Then
         Return 3
      Else
         Return 0
      End If
   End Function

   Public Sub ClearCheck()
      _miViewImages.Checked = False
      _miViewColor.Checked = False
      _miViewOpacity.Checked = False
      _miViewPreOpacity.Checked = False
   End Sub

   Private Sub _miAnimationPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miAnimationPlay.Click
      ActiveViewerForm.StopAnimation = False
      ActiveViewerForm.PlayingAnnimation = True

      AnimationTimer.Interval = Convert.ToInt32(ActiveViewerForm.AnimationDelay)
      AnimationTimer.Start()

      SetViewerLayout()

      UpdateMenusItems()
   End Sub

   Private Sub _miAnimationStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miAnimationStop.Click
      ActiveViewerForm.StopAnimation = True
      ActiveViewerForm.PlayingAnnimation = False

      SetViewerLayout()
   End Sub

   Private Sub _miAnimationLoop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miAnimationLoop.Click
      ActiveViewerForm.LoopAnimation = Not ActiveViewerForm.LoopAnimation
      _miAnimationLoop.Checked = ActiveViewerForm.LoopAnimation
   End Sub

   Private Sub _miAnimationSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miAnimationSettings.Click
      Dim settings As New AnimationSettings(ActiveViewerForm.AnimationDelay, _
                                             ActiveViewerForm.RenderWidth, _
                                             ActiveViewerForm.RenderHeight)

      If (settings.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         ActiveViewerForm.AnimationDelay = settings.AnnimationDelay
         ActiveViewerForm.RenderWidth = settings.RenderWidth
         ActiveViewerForm.RenderHeight = settings.RenderHeight
      End If
   End Sub

   Private Sub _miAnimationSaveSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miAnimationSaveSettings.Click
      Dim saveAnimationDialog As New SaveAnimation(Me)

      saveAnimationDialog.ShowDialog()
   End Sub

   Private Sub _miFileProcessingFileInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileProcessingFileInformation.Click
      Dim fileInformation As New FileInformation(Me)

      fileInformation.ShowDialog()
   End Sub

   Private Sub _miFileProcessingFragmentJPX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileProcessingFragmentJPX.Click
      Dim fragmentJPX As New FragmentJPX(Me)

      fragmentJPX.ShowDialog()
   End Sub

   Private Sub _miFileProcessingExtractFrames_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileProcessingExtractFrames.Click
      Dim extractFrames As New ExtractFrames(Me)

      extractFrames.ShowDialog()
   End Sub

   Private Sub _miBPAppendIntellectualProperty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miBPAppendIntellectualProperty.Click
      Dim intellectualPropertyDlg As New AppendCommon("Intellectual Property", False, Nothing)

      If (intellectualPropertyDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         Dim _iprBox As New IprBox()
         _iprBox.Data = intellectualPropertyDlg.AppendCommonData.data

         Try
            Jpeg2000Eng.AppendBox(intellectualPropertyDlg.Jpeg2000FileName, _iprBox)
            Messager.ShowInformation(Me, "Appending Succeeded!")
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try

      End If
   End Sub

   Private Sub _miBPAppendDigitalSignature_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miBPAppendDigitalSignature.Click
      Dim digitalSignatureDlg As New AppendDigitalSignature()

      If (digitalSignatureDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         Dim _digitalSignatureBox As New List(Of DigitalSignatureBox)
         Dim _digitalSignatureBoxNode As New DigitalSignatureBox()

         _digitalSignatureBoxNode.SignatureType = Convert.ToByte(digitalSignatureDlg.DigitalSignatureData.signatureType)
         _digitalSignatureBoxNode.PointerType = Convert.ToByte(digitalSignatureDlg.DigitalSignatureData.pointerType)
         _digitalSignatureBoxNode.Offset = Convert.ToByte(digitalSignatureDlg.DigitalSignatureData.offset)
         _digitalSignatureBoxNode.Length = digitalSignatureDlg.DigitalSignatureData.length
         _digitalSignatureBoxNode.Data = digitalSignatureDlg.DigitalSignatureData.data

         _digitalSignatureBox.Add(_digitalSignatureBoxNode)

         Try
            Jpeg2000Eng.AppendBoxes(digitalSignatureDlg.DigitalSignatureData.jPG2FileName, _digitalSignatureBox)
            Messager.ShowInformation(Me, "Appending Succeeded!")
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End If
   End Sub

   Private Sub _miBPAppendDesiredReproduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miBPAppendDesiredReproduction.Click
      Dim desiredReproductionDlg As New AppendCommon("Desired Reproduction", False, Nothing)

      If (desiredReproductionDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then

         Dim _gtsoBox As New GtsoBox()

         _gtsoBox.Data = desiredReproductionDlg.AppendCommonData.data

         Try
            Jpeg2000Eng.AppendBox(desiredReproductionDlg.Jpeg2000FileName, _gtsoBox)

            Messager.ShowInformation(Me, "Appending Succeeded!")
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End If
   End Sub

   Private Sub _miBPAppendXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miBPAppendXML.Click
      Dim xMLDlg As New AppendCommon("XML", False, Nothing)

      If (xMLDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         Dim _xmlBox As New List(Of XmlBox)
         Dim _xmlBoxNode As New XmlBox

         _xmlBoxNode.Data = xMLDlg.AppendCommonData.data

         _xmlBox.Add(_xmlBoxNode)

         Try
            Jpeg2000Eng.AppendBoxes(xMLDlg.Jpeg2000FileName, _xmlBox)

            Messager.ShowInformation(Me, "Appending Succeeded!")
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End If
   End Sub

   Private Sub _miBPAppendMPEG7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miBPAppendMPEG7.Click
      Dim mPEG7Dlg As New AppendCommon("MPEG7", False, Nothing)

      If (mPEG7Dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         Dim _mpeg7Box As New List(Of Mpeg7Box)
         Dim _mpeg7BoxNode As New Mpeg7Box()

         _mpeg7BoxNode.Data = mPEG7Dlg.AppendCommonData.data

         _mpeg7Box.Add(_mpeg7BoxNode)

         Try
            Jpeg2000Eng.AppendBoxes(mPEG7Dlg.Jpeg2000FileName, _mpeg7Box)

            Messager.ShowInformation(Me, "Appending Succeeded!")
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End If
   End Sub

   Private Sub _miBPAppendMediaData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miBPAppendMediaData.Click
      Dim mediaDataDlg As New AppendCommon("Media Data", False, Nothing)

      If (mediaDataDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         Dim _mediaDataBox As New List(Of MediaDataBox)
         Dim _mediaDataBoxNode As New MediaDataBox

         _mediaDataBoxNode.Data = mediaDataDlg.AppendCommonData.data

         _mediaDataBox.Add(_mediaDataBoxNode)

         Try
            Jpeg2000Eng.AppendBoxes(mediaDataDlg.Jpeg2000FileName, _mediaDataBox)

            Messager.ShowInformation(Me, "Appending Succeeded!")
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End If
   End Sub

   Private Sub _miBPAppendBinaryFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miBPAppendBinaryFilter.Click
      Dim binaryList As New List(Of String)
      binaryList.Add("Compressed with GZIP")
      binaryList.Add("Encrypted using DES")

      Dim binaryFilterDlg As New AppendCommon("Binary Filter", True, binaryList)

      If (binaryFilterDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         Dim _binaryFilterBox As New List(Of BinaryFilterBox)
         Dim _binaryFilterBoxNode As New BinaryFilterBox()

         _binaryFilterBoxNode.Data = binaryFilterDlg.AppendCommonData.data
         _binaryFilterBoxNode.FilterType = binaryFilterDlg.AppendCommonData.type

         _binaryFilterBox.Add(_binaryFilterBoxNode)

         Try
            Jpeg2000Eng.AppendBoxes(binaryFilterDlg.Jpeg2000FileName, _binaryFilterBox)

            Messager.ShowInformation(Me, "Appending Succeeded!")
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End If
   End Sub

   Private Sub _miBPAppendAssociation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miBPAppendAssociation.Click
      Dim associationDlg As New AppendCommon("Association", False, Nothing)

      If (associationDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         Dim _associationBox As New List(Of AssociationBox)
         Dim _associationBoxNode As New AssociationBox()

         _associationBoxNode.Data = associationDlg.AppendCommonData.data

         _associationBox.Add(_associationBoxNode)

         Try
            Jpeg2000Eng.AppendBoxes(associationDlg.Jpeg2000FileName, _associationBox)

            Messager.ShowInformation(Me, "Appending Succeeded!")
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End If
   End Sub

   Private Sub _miBPAppendFreeBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miBPAppendFreeBox.Click
      Dim freeBoxDlg As New AppendCommon("Free", False, Nothing)

      If (freeBoxDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
         Dim _freeBox As New List(Of FreeBox)
         Dim _freeBoxNode As New FreeBox()

         _freeBoxNode.Data = freeBoxDlg.AppendCommonData.data

         _freeBox.Add(_freeBoxNode)

         Try
            Jpeg2000Eng.AppendBoxes(freeBoxDlg.Jpeg2000FileName, _freeBox)

            Messager.ShowInformation(Me, "Appending Succeeded!")
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End If
   End Sub

   Private Sub _miBPReadIntellectualProperty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miBPReadIntellectualProperty.Click
      Dim intellectualProperty As New ReadCommon(Me, "Intellectual Property", False)

      Dim _readBox As New ReadBoxCommonStructure()
      _readBox.boxType = Jpeg2000BoxType.IprBox
      intellectualProperty.ReadBox = _readBox

      intellectualProperty.ShowDialog()
   End Sub

   Private Sub _miBPReadDigitalSignature_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miBPReadDigitalSignature.Click
      Dim readDigitalSignatureDlg As New ReadDigitalSignature(Me)

      readDigitalSignatureDlg.ShowDialog()
   End Sub

   Private Sub _miBPReadDesiredReproduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miBPReadDesiredReproduction.Click
      Dim desiredReproduction As New ReadCommon(Me, "Desired Reproduction", False)

      Dim _readBox As New ReadBoxCommonStructure()
      _readBox.boxType = Jpeg2000BoxType.GtsoBox
      desiredReproduction.ReadBox = _readBox

      desiredReproduction.ShowDialog()
   End Sub

   Private Sub _miBPReadXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miBPReadXML.Click
      Dim xML As New ReadCommon(Me, "XML", False)

      Dim _readBox As New ReadBoxCommonStructure()
      _readBox.boxType = Jpeg2000BoxType.XmlBox
      xML.ReadBox = _readBox

      xML.ShowDialog()
   End Sub

   Private Sub _miBPReadMPEG7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miBPReadMPEG7.Click
      Dim mPEG7 As New ReadCommon(Me, "MPEG7", False)

      Dim _readBox As New ReadBoxCommonStructure()
      _readBox.boxType = Jpeg2000BoxType.Mpeg7Box
      mPEG7.ReadBox = _readBox

      mPEG7.ShowDialog()
   End Sub

   Private Sub _miBPReadMediaData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miBPReadMediaData.Click
      Dim mediaData As New ReadCommon(Me, "Media Data", False)

      Dim _readBox As New ReadBoxCommonStructure()
      _readBox.boxType = Jpeg2000BoxType.MediaDataBox
      mediaData.ReadBox = _readBox

      mediaData.ShowDialog()
   End Sub

   Private Sub _miBPReadBinaryFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miBPReadBinaryFilter.Click
      Dim binaryFilter As New ReadCommon(Me, "Binary Filter", True)

      Dim _readBox As New ReadBoxCommonStructure()
      _readBox.boxType = Jpeg2000BoxType.BinaryFilterBox
      binaryFilter.ReadBox = _readBox

      binaryFilter.ShowDialog()
   End Sub

   Private Sub _miBPReadAssociation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miBPReadAssociation.Click
      Dim association As New ReadCommon(Me, "Association", False)

      Dim _readBox As New ReadBoxCommonStructure()
      _readBox.boxType = Jpeg2000BoxType.AssociationBox
      association.ReadBox = _readBox

      association.ShowDialog()
   End Sub

   Private Sub _miBPReadFreeBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miBPReadFreeBox.Click
      Dim freeBox As New ReadCommon(Me, "Free", False)

      Dim _readBox As New ReadBoxCommonStructure()
      _readBox.boxType = Jpeg2000BoxType.FreeBox
      freeBox.ReadBox = _readBox

      freeBox.ShowDialog()
   End Sub

   Private Sub _miGMLAppend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miGMLAppend.Click
      Dim appendGMLDataDlg As New AppendGMLData(Me)

      appendGMLDataDlg.ShowDialog()
   End Sub

   Private Sub _miGMLRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miGMLRead.Click
      Dim readGmlDialog As New ReadGML(Me)

      readGmlDialog.ShowDialog()
   End Sub


   Private Sub _miWindow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miWindowCascade.Click, _
                                                                                    _miWindowTileHorizontally.Click, _
                                                                                    _miWindowTileVertically.Click, _
                                                                                    _miWindowArrangeIcons.Click, _
                                                                                    _miWindowCloseAll.Click
      If (sender Is _miWindowCascade) Then
         LayoutMdi(MdiLayout.Cascade)
      ElseIf (sender Is _miWindowTileHorizontally) Then
         LayoutMdi(MdiLayout.TileHorizontal)
      ElseIf (sender Is _miWindowTileVertically) Then
         LayoutMdi(MdiLayout.TileVertical)
      ElseIf (sender Is _miWindowArrangeIcons) Then
         LayoutMdi(MdiLayout.ArrangeIcons)
      ElseIf (sender Is _miWindowCloseAll) Then
         While (MdiChildren.Length > 0)
            MdiChildren(0).Close()
         End While
         UpdateControls()
      End If
   End Sub

   Private Sub _miWindow_Popup(ByVal sender As Object, ByVal e As EventArgs) Handles _miWindow.Popup
      Dim enable As Boolean = (Not IsNothing(ActiveViewerForm))

      _miWindowCascade.Enabled = enable
      _miWindowTileHorizontally.Enabled = enable
      _miWindowTileVertically.Enabled = enable
      _miWindowArrangeIcons.Enabled = enable
      _miWindowCloseAll.Enabled = enable
   End Sub

   Private Sub _miHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miHelpAbout.Click
      Using aboutDialog As New AboutDialog("JPX", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub

   Private Function LoadImage() As ImageInformation

      Dim loader As New ImageFileLoader()

      Dim wait As New WaitCursor()
      Try
         If (loader.Load(Me, _codecs, False) > 0) Then
            Dim loadedImage As RasterImage = _codecs.Load(loader.FileName, 0, CodecsLoadByteOrder.BgrOrGray, 1, -1)
            If (loadedImage.HasRegion) Then
               loadedImage.MakeRegionEmpty()
               Return New ImageInformation(loadedImage, loader.FileName)
            End If
         End If
      Catch ex As Exception
         Messager.ShowFileOpenError(Me, loader.FileName, ex)
      Finally
         wait.Dispose()
      End Try

      Return Nothing
   End Function

   Private Sub NewImage(ByVal info As ImageInformation, ByVal isFile As Boolean)
      Dim child As New ViewerForm(Me, False)
      child.Initialize(info, _paintProperties, True, isFile)
      child.Show()
   End Sub

   Private Sub NewImage(ByVal compositeImage As List(Of CompositeJpxImages), ByVal fileName As String)
      Dim child As New ViewerForm(Me, True)
      child.Initialize(compositeImage, fileName, _paintProperties, True)
      child.Show()
   End Sub

   Private Property ImageToRun() As RasterImage
      Get
         Dim activeForm As ViewerForm = ActiveViewerForm

         Return activeForm.Viewer.Image
      End Get

      Set(ByVal value As RasterImage)
         If (Not IsNothing(value)) Then
            Dim activeForm As ViewerForm = ActiveViewerForm
            activeForm.Viewer.Image = value
         End If
      End Set
   End Property


   Public Sub SetCheck(ByVal ActiveList As ViewerForm.ActiveImageLists)
      Select Case (ActiveList)
         Case ViewerForm.ActiveImageLists.ImagesList
            _miViewImages.Checked = True

         Case ViewerForm.ActiveImageLists.ColorList
            _miViewColor.Checked = True

         Case ViewerForm.ActiveImageLists.OpacityList
            _miViewOpacity.Checked = True

         Case ViewerForm.ActiveImageLists.PreOpacityList
            _miViewPreOpacity.Checked = True
      End Select

   End Sub

   Private Sub AnimationTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
      PlayAnimation()
   End Sub


   Private Sub PlayAnimation()
      If ActiveViewerForm Is Nothing Then
         AnimationTimer.Stop()
         UpdateMenusItems()
         Return
      End If
      ActiveViewerForm.Viewer.BeginUpdate()
      Dim selectedIndex As Integer = Convert.ToInt32(ActiveViewerForm.ImageListControl.Items.GetSelected()(0).Tag) - 1

      If (selectedIndex < ActiveViewerForm.ImageListControl.Items.Count - 1 AndAlso Not ActiveViewerForm.StopAnimation) Then
         ActiveViewerForm.ImageListControl.Items(selectedIndex).IsSelected = False
         selectedIndex = selectedIndex + 1
      Else
         ActiveViewerForm.ImageListControl.Items(selectedIndex).IsSelected = False
         selectedIndex = 0

         If (Not ActiveViewerForm.LoopAnimation OrElse ActiveViewerForm.StopAnimation) Then

            AnimationTimer.Stop()
            ActiveViewerForm.PlayingAnnimation = False
            SetViewerLayout()

            UpdateMenusItems()
         End If
      End If

      ActiveViewerForm.ImageListControl.Items(selectedIndex).IsSelected = True

      ActiveViewerForm.Viewer.Image = ActiveViewerForm.ImageListControl.Items(selectedIndex).Image
      ActiveViewerForm.Viewer.Image.Page = ActiveViewerForm.ImageListControl.Items(selectedIndex).Image.Page

      ActiveViewerForm.Viewer.EndUpdate()
   End Sub

   Private Sub SetViewerLayout()
      If (ActiveViewerForm.PlayingAnnimation) Then
         ActiveViewerForm.Viewer.SuspendLayout()
         Dim Loc As Point = ActiveViewerForm.Viewer.Location
         ActiveViewerForm.Viewer.Zoom(Global.Leadtools.Controls.ControlSizeMode.Stretch, 1, ActiveViewerForm.Viewer.DefaultZoomOrigin)
         ActiveViewerForm.Viewer.Dock = DockStyle.None
         ActiveViewerForm.Viewer.Location = Loc
         ActiveViewerForm.Viewer.ClientSize = New Size(ActiveViewerForm.RenderWidth, ActiveViewerForm.RenderHeight)
         ActiveViewerForm.Viewer.ResumeLayout()
      Else
         ActiveViewerForm.Viewer.SuspendLayout()
         ActiveViewerForm.Viewer.Zoom(Global.Leadtools.Controls.ControlSizeMode.ActualSize, 1, ActiveViewerForm.Viewer.DefaultZoomOrigin)
         ActiveViewerForm.Viewer.Dock = DockStyle.Fill
         ActiveViewerForm.Viewer.ResumeLayout()
      End If
   End Sub

   Private Sub UpdateMenusItems()
      If ActiveViewerForm Is Nothing Then
         _miFile.Enabled = True
         _miEdit.Enabled = True
         _miView.Enabled = True

         _miAnimationPlay.Enabled = True
         _miAnimationStop.Enabled = False
         _miAnimationSeperator1.Enabled = True
         _miAnimationLoop.Enabled = True
         _miAnimationSettings.Enabled = True
         _miAnimationSaveSettings.Enabled = True

         _miFileProcessing.Enabled = True
         _miBoxProcessing.Enabled = True
         _miGML.Enabled = True
         _miWindow.Enabled = True
         _miHelp.Enabled = True
      Else
         _miFile.Enabled = Not ActiveViewerForm.PlayingAnnimation
         _miEdit.Enabled = Not ActiveViewerForm.PlayingAnnimation
         _miView.Enabled = Not ActiveViewerForm.PlayingAnnimation

         _miAnimationPlay.Enabled = Not ActiveViewerForm.PlayingAnnimation
         _miAnimationStop.Enabled = ActiveViewerForm.PlayingAnnimation
         _miAnimationSeperator1.Enabled = Not ActiveViewerForm.PlayingAnnimation
         _miAnimationLoop.Enabled = Not ActiveViewerForm.PlayingAnnimation
         _miAnimationSettings.Enabled = Not ActiveViewerForm.PlayingAnnimation
         _miAnimationSaveSettings.Enabled = Not ActiveViewerForm.PlayingAnnimation

         _miFileProcessing.Enabled = Not ActiveViewerForm.PlayingAnnimation
         _miBoxProcessing.Enabled = Not ActiveViewerForm.PlayingAnnimation
         _miGML.Enabled = Not ActiveViewerForm.PlayingAnnimation
         _miWindow.Enabled = Not ActiveViewerForm.PlayingAnnimation
         _miHelp.Enabled = Not ActiveViewerForm.PlayingAnnimation
      End If

   End Sub
End Class
