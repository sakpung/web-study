' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Collections.Generic
Imports System.IO
Imports System.Drawing.Drawing2D

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.WinForms
Imports GrayScaleDemo.Leadtools.Demos
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.ImageProcessing
Imports Leadtools.Dicom
Imports Leadtools.Drawing
Imports Leadtools.Controls
Imports Leadtools.Demos.Dialogs
Imports System


Public Class MainForm
   Inherits System.Windows.Forms.Form
   Private _mmMain As System.Windows.Forms.MainMenu
   Private _miFile As System.Windows.Forms.MenuItem
   Private WithEvents _miFileExit As System.Windows.Forms.MenuItem
   Private _miHelp As System.Windows.Forms.MenuItem
   Private WithEvents _miHelpAbout As System.Windows.Forms.MenuItem
   Private _menuItemPage As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemPageFirst As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemPagePrevious As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemPageNext As System.Windows.Forms.MenuItem
   Private WithEvents _menuItemPageLast As System.Windows.Forms.MenuItem
   Private components As IContainer
   Private _menuItemEffect As MenuItem
   Private _isSegmentation As Boolean = False
   Public CopyedImage As RasterImage
   Private _childPath As List(Of ViewerImages)
   Private _directoryPath As String
   Private _rawdataLoad As RawData
   Private _rawdataSave As RawData
   Private _paintProperties As RasterPaintProperties

   Public Property IsSegmentation() As Boolean
      Get
         Return _isSegmentation
      End Get
      Set(value As Boolean)
         _isSegmentation = value
      End Set
   End Property

   Private _menuItemImageRotate As MenuItem
   Private WithEvents _menuItemFileOpen As MenuItem
   Private WithEvents _menuItemFileSave As MenuItem
   Private WithEvents _menuItemLUTInvert As MenuItem
   Private _menuItemWindow As MenuItem
   Private WithEvents _menuItemWindowCascade As MenuItem
   Private WithEvents _menuItemWindowTileHorizontally As MenuItem
   Private WithEvents _menuItemWindowTileVertically As MenuItem
   Private WithEvents _menuItemWindowArrangeIcons As MenuItem
   Private WithEvents _menuItemWindowCloseAll As MenuItem
   Private WithEvents _menuItemEdit As MenuItem
   Private _menuItemRegion As MenuItem
   Private WithEvents _menuItemRegionRectangle As MenuItem
   Private WithEvents _menuItemRegionEllipse As MenuItem
   Private WithEvents _menuItemRegionFreehand As MenuItem
   Private WithEvents _menuItemRegionCancel As MenuItem
   Private _menuItemColor As MenuItem
   Private WithEvents _menuItemColorHistogram As MenuItem
   Private WithEvents _menuItemFillCommand As MenuItem
   Private WithEvents _menuItemAddBorderToRegion As MenuItem
   Private WithEvents _menuItemSetPixelColor As MenuItem
   Private menuItem9 As MenuItem
   Private WithEvents _menuItemEffectsBlurAvg As MenuItem
   Private menuItem10 As MenuItem
   Private WithEvents _menuItemEffectNoiseMax As MenuItem
   Private WithEvents _menuItemEffectNoiseMin As MenuItem
   Private WithEvents _menuItemEffectNoiseMedian As MenuItem
   Private menuItem11 As MenuItem
   Private WithEvents _menuItemEffectsSharpenSharpen As MenuItem
   Private WithEvents _menuItemEffectsSharpenUnsharpen As MenuItem
   Private menuItem12 As MenuItem
   Private WithEvents _menuItemEffectsEdgesDetection As MenuItem
   Private WithEvents _menuItemEffectsEdgeContour As MenuItem
   Private menuItem13 As MenuItem
   Private WithEvents _menuItemImage As MenuItem
   Private WithEvents _menuItemEffectsSpecialGauissian As MenuItem
   Private WithEvents _menuItemImageFlipH As MenuItem
   Private WithEvents _menuItemImageFlipV As MenuItem
   Private menuItem1 As MenuItem
   Private WithEvents _menuItemColorAdjustContrast As MenuItem
   Private WithEvents _menuItemColorAdjustBrightness As MenuItem
   Private menuItem3 As MenuItem
   Private WithEvents _menuItemColorHistogramEqualizer As MenuItem
   Private WithEvents _menuItemColorHistogramAdaptiveContrast As MenuItem
   Private WithEvents _menuItemColorHistogramLocalEqualizer As MenuItem
   Private WithEvents _menuItemColorAdjustAutoLevel As MenuItem
   Private WithEvents _menuItemColorAdjustAutoContrast As MenuItem
   Private WithEvents _menuItemColorHistogramIntensity As MenuItem
   Private menuItem4 As MenuItem
   Private WithEvents _menuItemImageDeskew As MenuItem
   Private WithEvents _menuItemImageBlankPageDetection As MenuItem
   Private WithEvents _menuItemImageRotateFast90 As MenuItem
   Private WithEvents _menuItemImageRotateFast180 As MenuItem
   Private WithEvents _menuItemRotateFast270 As MenuItem
   Private WithEvents _menuItemRotateCustom As MenuItem
   Private WithEvents _menuItemImageShear As MenuItem
   Private WithEvents _menuItemColorAutoBinarize As MenuItem
   Private WithEvents _menuItemColorIntensityDetect As MenuItem
   Private _menuItemSegmentation As MenuItem
   Private WithEvents _menuItemSegmentationKMeans As MenuItem
   Private WithEvents _menuItemSegmentationOtsu As MenuItem
   Private WithEvents _menuItemSegmentationLambda As MenuItem
   Private WithEvents _menuItemSegmentationLevelSet As MenuItem
   Private WithEvents _menuItemSegmentationTDAFilter As MenuItem
   Private WithEvents _menuItemSegmentationSRADFilter As MenuItem
   Private _menuItemDocument As MenuItem
   Private WithEvents _menuItemDocumentAutoCrop As MenuItem
   Private WithEvents _menuItemDocumentDespeckle As MenuItem
   Private WithEvents _menuItemDocumentErode As MenuItem
   Private WithEvents _menuItemDocumentDilate As MenuItem
   Private WithEvents _menuItemDocumentUnditherText As MenuItem
   Private WithEvents _menuItemDocumentFixBrokenLetters As MenuItem
   Private WithEvents _menuItemSegmentationInvPerspective As MenuItem
   Private WithEvents _menuItemSegmentationShrinkTool As MenuItem
   Private WithEvents _menuItemSegmentationGWireTool As MenuItem
   Private _menuItemMedical As MenuItem
   Private WithEvents _menuItemMedicalAnisotropicDiffusion As MenuItem
   Private WithEvents _menuItemMedicalDigitalSubtract As MenuItem
   Private WithEvents _menuItemMedicalMeanShift As MenuItem
   Private WithEvents _menuItemMedicalMultiscaleEnhancement As MenuItem
   Private WithEvents _menuItemMedicalSelectData As MenuItem
   Private WithEvents _menuItemMedicalShiftData As MenuItem
   Private WithEvents _menuItemMedicalSigma As MenuItem
   Private WithEvents _menuItemMedicalTissueEqualize As MenuItem
   Private WithEvents _menuItemMedicalSkeleton As MenuItem
   Private menuItem7 As MenuItem
   Private menuItem8 As MenuItem
   Private menuItem14 As MenuItem
   Private menuItem15 As MenuItem
   Private menuItem16 As MenuItem
   Private WithEvents _menuItemRegionNone As MenuItem
   Private WithEvents _menuItemRegionRoundRectangle As MenuItem
   Private WithEvents _menuItemRegionAutoSegment As MenuItem
   Private WithEvents _menuItemRegionCombine As MenuItem
   Private WithEvents _menuItemWLManually As MenuItem
   Private menuItem5 As MenuItem
   Private WithEvents _menuItemImageDataInvert As MenuItem
   Private _menuItemWL As MenuItem
   Private WithEvents _menuItemSensitivity As MenuItem
   Private _menuItemView As MenuItem
   Private WithEvents _menuItemViewMagnifyGlass As MenuItem
   Private WithEvents _menuItemInterActiveNone As MenuItem
   Private WithEvents _menuItemCombine As MenuItem
   Private WithEvents _menuItemCopyImage As MenuItem
   Private WithEvents _menuItemImageInfo As MenuItem
   Private WithEvents _menuItemLineHistogram As MenuItem
   Private _menuItemSeparation As MenuItem
   Private WithEvents _menuItemSepRGB As MenuItem
   Private WithEvents _menuItemSepCMYK As MenuItem
   Private WithEvents _menuItemSepHSV As MenuItem
   Private WithEvents _menuItemSepHLS As MenuItem
   Private WithEvents _menuItemSepCMY As MenuItem
   Private WithEvents _menuItemSepAlpha As MenuItem
   Private WithEvents _menuItemMerge As MenuItem
   Private WithEvents _menuItemSepYUV As MenuItem
   Private WithEvents _menuItemSepXYZ As MenuItem
   Private WithEvents _menuItemSepLAB As MenuItem
   Private WithEvents _menuItemSepYCRCB As MenuItem
   Private WithEvents _menuItemSepSCT As MenuItem
   Private WithEvents _menuItemMagGlassSettings As MenuItem
   Private _menuItemInteractive As MenuItem
   Private _menuItemSize As MenuItem
   Private WithEvents _menuItemSizeFit As MenuItem
   Private WithEvents _menuItemSizeNormal As MenuItem
   Private WithEvents _menuItemInterActivePan As MenuItem
   Private WithEvents _menuItemUndo As MenuItem
   Private WithEvents _menuItemRedo As MenuItem
   Private menuItem6 As MenuItem
   Private WithEvents _menuItemCLAHE As MenuItem
   Private menuItem17 As MenuItem
   Private menuItem20 As MenuItem
   Private WithEvents _menuItemCopy As MenuItem
   Private WithEvents _menuItemPaste As MenuItem
   Private WithEvents _menuItemOpenRaw As MenuItem
   Private WithEvents _menuItemSaveRaw As MenuItem
   Private menuItem21 As MenuItem
   Private WithEvents _menuItemSegmentationWatershed As MenuItem
   Private WithEvents _menuItemDeskewToolStrip As MenuItem
   Private _menuItemEffectFlip As MenuItem
   Private WithEvents _menuItemColorGrayScale As MenuItem
   Private WithEvents _miBackgroundRemoval As MenuItem
   Private WithEvents _menuItemColorResolution As MenuItem

   Public Sub New()
      InitializeComponent()
   End Sub

   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing Then
         If components IsNot Nothing Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

#Region "Windows Form Designer generated code"
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
      Me._mmMain = New System.Windows.Forms.MainMenu(Me.components)
      Me._miFile = New System.Windows.Forms.MenuItem()
      Me._menuItemFileOpen = New System.Windows.Forms.MenuItem()
      Me._menuItemFileSave = New System.Windows.Forms.MenuItem()
      Me.menuItem7 = New System.Windows.Forms.MenuItem()
      Me._menuItemOpenRaw = New System.Windows.Forms.MenuItem()
      Me._menuItemSaveRaw = New System.Windows.Forms.MenuItem()
      Me.menuItem21 = New System.Windows.Forms.MenuItem()
      Me._miFileExit = New System.Windows.Forms.MenuItem()
      Me._menuItemEdit = New System.Windows.Forms.MenuItem()
      Me._menuItemUndo = New System.Windows.Forms.MenuItem()
      Me._menuItemRedo = New System.Windows.Forms.MenuItem()
      Me.menuItem6 = New System.Windows.Forms.MenuItem()
      Me._menuItemRegion = New System.Windows.Forms.MenuItem()
      Me._menuItemRegionNone = New System.Windows.Forms.MenuItem()
      Me._menuItemRegionRectangle = New System.Windows.Forms.MenuItem()
      Me._menuItemRegionRoundRectangle = New System.Windows.Forms.MenuItem()
      Me._menuItemRegionEllipse = New System.Windows.Forms.MenuItem()
      Me._menuItemRegionFreehand = New System.Windows.Forms.MenuItem()
      Me._menuItemRegionAutoSegment = New System.Windows.Forms.MenuItem()
      Me._menuItemAddBorderToRegion = New System.Windows.Forms.MenuItem()
      Me._menuItemRegionCombine = New System.Windows.Forms.MenuItem()
      Me._menuItemRegionCancel = New System.Windows.Forms.MenuItem()
      Me.menuItem17 = New System.Windows.Forms.MenuItem()
      Me._menuItemMagGlassSettings = New System.Windows.Forms.MenuItem()
      Me.menuItem20 = New System.Windows.Forms.MenuItem()
      Me._menuItemCopy = New System.Windows.Forms.MenuItem()
      Me._menuItemPaste = New System.Windows.Forms.MenuItem()
      Me._menuItemPage = New System.Windows.Forms.MenuItem()
      Me._menuItemPageFirst = New System.Windows.Forms.MenuItem()
      Me._menuItemPagePrevious = New System.Windows.Forms.MenuItem()
      Me._menuItemPageNext = New System.Windows.Forms.MenuItem()
      Me._menuItemPageLast = New System.Windows.Forms.MenuItem()
      Me._menuItemView = New System.Windows.Forms.MenuItem()
      Me._menuItemWL = New System.Windows.Forms.MenuItem()
      Me._menuItemWLManually = New System.Windows.Forms.MenuItem()
      Me._menuItemSensitivity = New System.Windows.Forms.MenuItem()
      Me._menuItemInteractive = New System.Windows.Forms.MenuItem()
      Me._menuItemInterActiveNone = New System.Windows.Forms.MenuItem()
      Me._menuItemViewMagnifyGlass = New System.Windows.Forms.MenuItem()
      Me._menuItemInterActivePan = New System.Windows.Forms.MenuItem()
      Me._menuItemSize = New System.Windows.Forms.MenuItem()
      Me._menuItemSizeNormal = New System.Windows.Forms.MenuItem()
      Me._menuItemSizeFit = New System.Windows.Forms.MenuItem()
      Me._menuItemImage = New System.Windows.Forms.MenuItem()
      Me.menuItem4 = New System.Windows.Forms.MenuItem()
      Me._menuItemColorHistogram = New System.Windows.Forms.MenuItem()
      Me._menuItemImageInfo = New System.Windows.Forms.MenuItem()
      Me._menuItemLineHistogram = New System.Windows.Forms.MenuItem()
      Me.menuItem15 = New System.Windows.Forms.MenuItem()
      Me._menuItemEffectFlip = New System.Windows.Forms.MenuItem()
      Me._menuItemImageFlipH = New System.Windows.Forms.MenuItem()
      Me._menuItemImageFlipV = New System.Windows.Forms.MenuItem()
      Me._menuItemImageDeskew = New System.Windows.Forms.MenuItem()
      Me._menuItemImageShear = New System.Windows.Forms.MenuItem()
      Me._menuItemImageRotate = New System.Windows.Forms.MenuItem()
      Me._menuItemImageRotateFast90 = New System.Windows.Forms.MenuItem()
      Me._menuItemImageRotateFast180 = New System.Windows.Forms.MenuItem()
      Me._menuItemRotateFast270 = New System.Windows.Forms.MenuItem()
      Me._menuItemRotateCustom = New System.Windows.Forms.MenuItem()
      Me.menuItem16 = New System.Windows.Forms.MenuItem()
      Me._menuItemImageBlankPageDetection = New System.Windows.Forms.MenuItem()
      Me._menuItemCombine = New System.Windows.Forms.MenuItem()
      Me._menuItemCopyImage = New System.Windows.Forms.MenuItem()
      Me._menuItemEffect = New System.Windows.Forms.MenuItem()
      Me.menuItem9 = New System.Windows.Forms.MenuItem()
      Me._menuItemEffectsBlurAvg = New System.Windows.Forms.MenuItem()
      Me.menuItem12 = New System.Windows.Forms.MenuItem()
      Me._menuItemEffectsEdgesDetection = New System.Windows.Forms.MenuItem()
      Me._menuItemEffectsEdgeContour = New System.Windows.Forms.MenuItem()
      Me.menuItem10 = New System.Windows.Forms.MenuItem()
      Me._menuItemEffectNoiseMax = New System.Windows.Forms.MenuItem()
      Me._menuItemEffectNoiseMin = New System.Windows.Forms.MenuItem()
      Me._menuItemEffectNoiseMedian = New System.Windows.Forms.MenuItem()
      Me.menuItem11 = New System.Windows.Forms.MenuItem()
      Me._menuItemEffectsSharpenSharpen = New System.Windows.Forms.MenuItem()
      Me._menuItemEffectsSharpenUnsharpen = New System.Windows.Forms.MenuItem()
      Me.menuItem13 = New System.Windows.Forms.MenuItem()
      Me._menuItemEffectsSpecialGauissian = New System.Windows.Forms.MenuItem()
      Me._menuItemColor = New System.Windows.Forms.MenuItem()
      Me._menuItemColorGrayScale = New System.Windows.Forms.MenuItem()
      Me._menuItemColorResolution = New System.Windows.Forms.MenuItem()
      Me.menuItem5 = New System.Windows.Forms.MenuItem()
      Me._menuItemLUTInvert = New System.Windows.Forms.MenuItem()
      Me._menuItemImageDataInvert = New System.Windows.Forms.MenuItem()
      Me._menuItemFillCommand = New System.Windows.Forms.MenuItem()
      Me.menuItem8 = New System.Windows.Forms.MenuItem()
      Me.menuItem1 = New System.Windows.Forms.MenuItem()
      Me._menuItemColorAdjustAutoLevel = New System.Windows.Forms.MenuItem()
      Me._menuItemColorAdjustAutoContrast = New System.Windows.Forms.MenuItem()
      Me._menuItemColorHistogramIntensity = New System.Windows.Forms.MenuItem()
      Me._menuItemColorAdjustContrast = New System.Windows.Forms.MenuItem()
      Me._menuItemColorAdjustBrightness = New System.Windows.Forms.MenuItem()
      Me.menuItem3 = New System.Windows.Forms.MenuItem()
      Me._menuItemColorHistogramEqualizer = New System.Windows.Forms.MenuItem()
      Me._menuItemColorHistogramAdaptiveContrast = New System.Windows.Forms.MenuItem()
      Me._menuItemColorHistogramLocalEqualizer = New System.Windows.Forms.MenuItem()
      Me.menuItem14 = New System.Windows.Forms.MenuItem()
      Me._menuItemColorAutoBinarize = New System.Windows.Forms.MenuItem()
      Me._menuItemColorIntensityDetect = New System.Windows.Forms.MenuItem()
      Me._menuItemSetPixelColor = New System.Windows.Forms.MenuItem()
      Me._menuItemSeparation = New System.Windows.Forms.MenuItem()
      Me._menuItemSepRGB = New System.Windows.Forms.MenuItem()
      Me._menuItemSepCMYK = New System.Windows.Forms.MenuItem()
      Me._menuItemSepHSV = New System.Windows.Forms.MenuItem()
      Me._menuItemSepHLS = New System.Windows.Forms.MenuItem()
      Me._menuItemSepCMY = New System.Windows.Forms.MenuItem()
      Me._menuItemSepAlpha = New System.Windows.Forms.MenuItem()
      Me._menuItemSepYUV = New System.Windows.Forms.MenuItem()
      Me._menuItemSepXYZ = New System.Windows.Forms.MenuItem()
      Me._menuItemSepLAB = New System.Windows.Forms.MenuItem()
      Me._menuItemSepYCRCB = New System.Windows.Forms.MenuItem()
      Me._menuItemSepSCT = New System.Windows.Forms.MenuItem()
      Me._menuItemMerge = New System.Windows.Forms.MenuItem()
      Me._menuItemMedical = New System.Windows.Forms.MenuItem()
      Me._menuItemMedicalAnisotropicDiffusion = New System.Windows.Forms.MenuItem()
      Me._menuItemMedicalDigitalSubtract = New System.Windows.Forms.MenuItem()
      Me._menuItemMedicalMeanShift = New System.Windows.Forms.MenuItem()
      Me._menuItemMedicalMultiscaleEnhancement = New System.Windows.Forms.MenuItem()
      Me._menuItemMedicalSelectData = New System.Windows.Forms.MenuItem()
      Me._menuItemMedicalShiftData = New System.Windows.Forms.MenuItem()
      Me._menuItemMedicalSigma = New System.Windows.Forms.MenuItem()
      Me._menuItemMedicalTissueEqualize = New System.Windows.Forms.MenuItem()
      Me._menuItemMedicalSkeleton = New System.Windows.Forms.MenuItem()
      Me._menuItemCLAHE = New System.Windows.Forms.MenuItem()
      Me._miBackgroundRemoval = New System.Windows.Forms.MenuItem()
      Me._menuItemSegmentation = New System.Windows.Forms.MenuItem()
      Me._menuItemSegmentationKMeans = New System.Windows.Forms.MenuItem()
      Me._menuItemSegmentationOtsu = New System.Windows.Forms.MenuItem()
      Me._menuItemSegmentationLevelSet = New System.Windows.Forms.MenuItem()
      Me._menuItemSegmentationLambda = New System.Windows.Forms.MenuItem()
      Me._menuItemSegmentationGWireTool = New System.Windows.Forms.MenuItem()
      Me._menuItemSegmentationInvPerspective = New System.Windows.Forms.MenuItem()
      Me._menuItemSegmentationShrinkTool = New System.Windows.Forms.MenuItem()
      Me._menuItemSegmentationTDAFilter = New System.Windows.Forms.MenuItem()
      Me._menuItemSegmentationSRADFilter = New System.Windows.Forms.MenuItem()
      Me._menuItemSegmentationWatershed = New System.Windows.Forms.MenuItem()
      Me._menuItemDeskewToolStrip = New System.Windows.Forms.MenuItem()
      Me._menuItemDocument = New System.Windows.Forms.MenuItem()
      Me._menuItemDocumentAutoCrop = New System.Windows.Forms.MenuItem()
      Me._menuItemDocumentDespeckle = New System.Windows.Forms.MenuItem()
      Me._menuItemDocumentErode = New System.Windows.Forms.MenuItem()
      Me._menuItemDocumentDilate = New System.Windows.Forms.MenuItem()
      Me._menuItemDocumentUnditherText = New System.Windows.Forms.MenuItem()
      Me._menuItemDocumentFixBrokenLetters = New System.Windows.Forms.MenuItem()
      Me._menuItemWindow = New System.Windows.Forms.MenuItem()
      Me._menuItemWindowCascade = New System.Windows.Forms.MenuItem()
      Me._menuItemWindowTileHorizontally = New System.Windows.Forms.MenuItem()
      Me._menuItemWindowTileVertically = New System.Windows.Forms.MenuItem()
      Me._menuItemWindowArrangeIcons = New System.Windows.Forms.MenuItem()
      Me._menuItemWindowCloseAll = New System.Windows.Forms.MenuItem()
      Me._miHelp = New System.Windows.Forms.MenuItem()
      Me._miHelpAbout = New System.Windows.Forms.MenuItem()
      Me.SuspendLayout()
      ' 
      ' _mmMain
      ' 
      Me._mmMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFile, Me._menuItemEdit, Me._menuItemPage, Me._menuItemView, Me._menuItemImage, Me._menuItemEffect, _
       Me._menuItemColor, Me._menuItemMedical, Me._menuItemSegmentation, Me._menuItemDocument, Me._menuItemWindow, Me._miHelp})
      ' 
      ' _miFile
      ' 
      Me._miFile.Index = 0
      Me._miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemFileOpen, Me._menuItemFileSave, Me.menuItem7, Me._menuItemOpenRaw, Me._menuItemSaveRaw, Me.menuItem21, _
       Me._miFileExit})
      Me._miFile.Text = "&File"
      ' 
      ' _menuItemFileOpen
      ' 
      Me._menuItemFileOpen.Index = 0
      Me._menuItemFileOpen.Text = "&Open"
      ' 
      ' _menuItemFileSave
      ' 
      Me._menuItemFileSave.Index = 1
      Me._menuItemFileSave.Text = "&Save"
      ' 
      ' menuItem7
      ' 
      Me.menuItem7.Index = 2
      Me.menuItem7.Text = "-"
      ' 
      ' _menuItemOpenRaw
      ' 
      Me._menuItemOpenRaw.Index = 3
      Me._menuItemOpenRaw.Text = "Open Raw"
      ' 
      ' _menuItemSaveRaw
      ' 
      Me._menuItemSaveRaw.Index = 4
      Me._menuItemSaveRaw.Text = "Save Raw"
      ' 
      ' menuItem21
      ' 
      Me.menuItem21.Index = 5
      Me.menuItem21.Text = "-"
      ' 
      ' _miFileExit
      ' 
      Me._miFileExit.Index = 6
      Me._miFileExit.Text = "E&xit"
      ' 
      ' _menuItemEdit
      ' 
      Me._menuItemEdit.Index = 1
      Me._menuItemEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemUndo, Me._menuItemRedo, Me.menuItem6, Me._menuItemRegion, Me._menuItemRegionCombine, Me._menuItemRegionCancel, _
       Me.menuItem17, Me._menuItemMagGlassSettings, Me.menuItem20, Me._menuItemCopy, Me._menuItemPaste})
      Me._menuItemEdit.Text = "&Edit"
      ' 
      ' _menuItemUndo
      ' 
      Me._menuItemUndo.Index = 0
      Me._menuItemUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ
      Me._menuItemUndo.Text = "Undo"
      ' 
      ' _menuItemRedo
      ' 
      Me._menuItemRedo.Index = 1
      Me._menuItemRedo.Shortcut = System.Windows.Forms.Shortcut.CtrlY
      Me._menuItemRedo.Text = "Redo"
      ' 
      ' menuItem6
      ' 
      Me.menuItem6.Index = 2
      Me.menuItem6.Text = "-"
      ' 
      ' _menuItemRegion
      ' 
      Me._menuItemRegion.Index = 3
      Me._menuItemRegion.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemRegionNone, Me._menuItemRegionRectangle, Me._menuItemRegionRoundRectangle, Me._menuItemRegionEllipse, Me._menuItemRegionFreehand, Me._menuItemRegionAutoSegment, _
       Me._menuItemAddBorderToRegion})
      Me._menuItemRegion.Text = "&Region"
      ' 
      ' _menuItemRegionNone
      ' 
      Me._menuItemRegionNone.Index = 0
      Me._menuItemRegionNone.Text = "None"
      ' 
      ' _menuItemRegionRectangle
      ' 
      Me._menuItemRegionRectangle.Index = 1
      Me._menuItemRegionRectangle.Text = "Rectangle"
      ' 
      ' _menuItemRegionRoundRectangle
      ' 
      Me._menuItemRegionRoundRectangle.Index = 2
      Me._menuItemRegionRoundRectangle.Text = "Round Rectangle"
      ' 
      ' _menuItemRegionEllipse
      ' 
      Me._menuItemRegionEllipse.Index = 3
      Me._menuItemRegionEllipse.Text = "Ellipse"
      ' 
      ' _menuItemRegionFreehand
      ' 
      Me._menuItemRegionFreehand.Index = 4
      Me._menuItemRegionFreehand.Text = "Free Hand"
      ' 
      ' _menuItemRegionAutoSegment
      ' 
      Me._menuItemRegionAutoSegment.Index = 5
      Me._menuItemRegionAutoSegment.Text = "Auto Segment"
      ' 
      ' _menuItemAddBorderToRegion
      ' 
      Me._menuItemAddBorderToRegion.Index = 6
      Me._menuItemAddBorderToRegion.Text = "Border"
      ' 
      ' _menuItemRegionCombine
      ' 
      Me._menuItemRegionCombine.Index = 4
      Me._menuItemRegionCombine.Shortcut = System.Windows.Forms.Shortcut.CtrlC
      Me._menuItemRegionCombine.Text = "Combine Region"
      ' 
      ' _menuItemRegionCancel
      ' 
      Me._menuItemRegionCancel.Index = 5
      Me._menuItemRegionCancel.Shortcut = System.Windows.Forms.Shortcut.CtrlX
      Me._menuItemRegionCancel.Text = "Cancel Region"
      Me._menuItemRegionCancel.Visible = False
      ' 
      ' menuItem17
      ' 
      Me.menuItem17.Index = 6
      Me.menuItem17.Text = "-"
      ' 
      ' _menuItemMagGlassSettings
      ' 
      Me._menuItemMagGlassSettings.Index = 7
      Me._menuItemMagGlassSettings.Text = "Magnify Glass Settings ..."
      ' 
      ' menuItem20
      ' 
      Me.menuItem20.Index = 8
      Me.menuItem20.Text = "-"
      ' 
      ' _menuItemCopy
      ' 
      Me._menuItemCopy.Index = 9
      Me._menuItemCopy.Text = "Copy"
      ' 
      ' _menuItemPaste
      ' 
      Me._menuItemPaste.Index = 10
      Me._menuItemPaste.Text = "Paste"
      ' 
      ' _menuItemPage
      ' 
      Me._menuItemPage.Index = 2
      Me._menuItemPage.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemPageFirst, Me._menuItemPagePrevious, Me._menuItemPageNext, Me._menuItemPageLast})
      Me._menuItemPage.Text = "&Page"
      Me._menuItemPage.Visible = False
      ' 
      ' _menuItemPageFirst
      ' 
      Me._menuItemPageFirst.Index = 0
      Me._menuItemPageFirst.RadioCheck = True
      Me._menuItemPageFirst.Text = "&First"
      ' 
      ' _menuItemPagePrevious
      ' 
      Me._menuItemPagePrevious.Index = 1
      Me._menuItemPagePrevious.RadioCheck = True
      Me._menuItemPagePrevious.Text = "&Previous"
      ' 
      ' _menuItemPageNext
      ' 
      Me._menuItemPageNext.Index = 2
      Me._menuItemPageNext.RadioCheck = True
      Me._menuItemPageNext.Text = "&Next"
      ' 
      ' _menuItemPageLast
      ' 
      Me._menuItemPageLast.Index = 3
      Me._menuItemPageLast.RadioCheck = True
      Me._menuItemPageLast.Text = "&Last"
      ' 
      ' _menuItemView
      ' 
      Me._menuItemView.Index = 3
      Me._menuItemView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemWL, Me._menuItemInteractive, Me._menuItemSize})
      Me._menuItemView.Text = "View"
      Me._menuItemView.Visible = False
      ' 
      ' _menuItemWL
      ' 
      Me._menuItemWL.Index = 0
      Me._menuItemWL.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemWLManually, Me._menuItemSensitivity})
      Me._menuItemWL.Text = "Window Level"
      ' 
      ' _menuItemWLManually
      ' 
      Me._menuItemWLManually.Index = 0
      Me._menuItemWLManually.Text = "Set W \ L Manually"
      ' 
      ' _menuItemSensitivity
      ' 
      Me._menuItemSensitivity.Index = 1
      Me._menuItemSensitivity.Text = "Sensitivity "
      ' 
      ' _menuItemInteractive
      ' 
      Me._menuItemInteractive.Index = 1
      Me._menuItemInteractive.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemInterActiveNone, Me._menuItemViewMagnifyGlass, Me._menuItemInterActivePan})
      Me._menuItemInteractive.Text = "Interactive"
      ' 
      ' _menuItemInterActiveNone
      ' 
      Me._menuItemInterActiveNone.Index = 0
      Me._menuItemInterActiveNone.Text = "None"
      ' 
      ' _menuItemViewMagnifyGlass
      ' 
      Me._menuItemViewMagnifyGlass.Index = 1
      Me._menuItemViewMagnifyGlass.Text = "&Magnify Glass"
      ' 
      ' _menuItemInterActivePan
      ' 
      Me._menuItemInterActivePan.Index = 2
      Me._menuItemInterActivePan.Text = "Pan"
      ' 
      ' _menuItemSize
      ' 
      Me._menuItemSize.Index = 2
      Me._menuItemSize.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemSizeNormal, Me._menuItemSizeFit})
      Me._menuItemSize.Text = "Size Mode"
      ' 
      ' _menuItemSizeNormal
      ' 
      Me._menuItemSizeNormal.Checked = True
      Me._menuItemSizeNormal.Index = 0
      Me._menuItemSizeNormal.Text = "Normal"
      ' 
      ' _menuItemSizeFit
      ' 
      Me._menuItemSizeFit.Index = 1
      Me._menuItemSizeFit.Text = "Fit"
      ' 
      ' _menuItemImage
      ' 
      Me._menuItemImage.Index = 4
      Me._menuItemImage.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItem4, Me.menuItem15, Me._menuItemEffectFlip, Me._menuItemImageDeskew, Me._menuItemImageShear, Me._menuItemImageRotate, _
       Me.menuItem16, Me._menuItemImageBlankPageDetection, Me._menuItemCombine, Me._menuItemCopyImage})
      Me._menuItemImage.Text = "Image"
      Me._menuItemImage.Visible = False
      ' 
      ' menuItem4
      ' 
      Me.menuItem4.Index = 0
      Me.menuItem4.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemColorHistogram, Me._menuItemImageInfo, Me._menuItemLineHistogram})
      Me.menuItem4.Text = "Analysis"
      ' 
      ' _menuItemColorHistogram
      ' 
      Me._menuItemColorHistogram.Index = 0
      Me._menuItemColorHistogram.Text = "Histogram ..."
      ' 
      ' _menuItemImageInfo
      ' 
      Me._menuItemImageInfo.Index = 1
      Me._menuItemImageInfo.Text = "Image Info ..."
      ' 
      ' _menuItemLineHistogram
      ' 
      Me._menuItemLineHistogram.Index = 2
      Me._menuItemLineHistogram.Text = "Line Histogram ..."
      ' 
      ' menuItem15
      ' 
      Me.menuItem15.Index = 1
      Me.menuItem15.Text = "-"
      ' 
      ' _menuItemEffectFlip
      ' 
      Me._menuItemEffectFlip.Index = 2
      Me._menuItemEffectFlip.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemImageFlipH, Me._menuItemImageFlipV})
      Me._menuItemEffectFlip.Text = "&Flip"
      ' 
      ' _menuItemImageFlipH
      ' 
      Me._menuItemImageFlipH.Index = 0
      Me._menuItemImageFlipH.Text = "Horizontal"
      ' 
      ' _menuItemImageFlipV
      ' 
      Me._menuItemImageFlipV.Index = 1
      Me._menuItemImageFlipV.Text = "Vertical"
      ' 
      ' _menuItemImageDeskew
      ' 
      Me._menuItemImageDeskew.Index = 3
      Me._menuItemImageDeskew.Text = "Deskew"
      ' 
      ' _menuItemImageShear
      ' 
      Me._menuItemImageShear.Index = 4
      Me._menuItemImageShear.Text = "Shear"
      ' 
      ' _menuItemImageRotate
      ' 
      Me._menuItemImageRotate.Index = 5
      Me._menuItemImageRotate.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemImageRotateFast90, Me._menuItemImageRotateFast180, Me._menuItemRotateFast270, Me._menuItemRotateCustom})
      Me._menuItemImageRotate.Text = "&Rotate"
      ' 
      ' _menuItemImageRotateFast90
      ' 
      Me._menuItemImageRotateFast90.Index = 0
      Me._menuItemImageRotateFast90.Text = "9&0° clockwise"
      ' 
      ' _menuItemImageRotateFast180
      ' 
      Me._menuItemImageRotateFast180.Index = 1
      Me._menuItemImageRotateFast180.Text = "1&80° clockwise"
      ' 
      ' _menuItemRotateFast270
      ' 
      Me._menuItemRotateFast270.Index = 2
      Me._menuItemRotateFast270.Text = "2&70° clockwise"
      ' 
      ' _menuItemRotateCustom
      ' 
      Me._menuItemRotateCustom.Index = 3
      Me._menuItemRotateCustom.Text = "&Custom..."
      ' 
      ' menuItem16
      ' 
      Me.menuItem16.Index = 6
      Me.menuItem16.Text = "-"
      ' 
      ' _menuItemImageBlankPageDetection
      ' 
      Me._menuItemImageBlankPageDetection.Index = 7
      Me._menuItemImageBlankPageDetection.Text = "Blank Page Detection"
      ' 
      ' _menuItemCombine
      ' 
      Me._menuItemCombine.Index = 8
      Me._menuItemCombine.Text = "Combine ..."
      ' 
      ' _menuItemCopyImage
      ' 
      Me._menuItemCopyImage.Index = 9
      Me._menuItemCopyImage.Text = "Copy "
      ' 
      ' _menuItemEffect
      ' 
      Me._menuItemEffect.Index = 5
      Me._menuItemEffect.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItem9, Me.menuItem12, Me.menuItem10, Me.menuItem11, Me.menuItem13})
      Me._menuItemEffect.Text = "Effec&ts"
      Me._menuItemEffect.Visible = False
      ' 
      ' menuItem9
      ' 
      Me.menuItem9.Index = 0
      Me.menuItem9.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemEffectsBlurAvg})
      Me.menuItem9.Text = "Blur "
      ' 
      ' _menuItemEffectsBlurAvg
      ' 
      Me._menuItemEffectsBlurAvg.Index = 0
      Me._menuItemEffectsBlurAvg.Text = "Average"
      ' 
      ' menuItem12
      ' 
      Me.menuItem12.Index = 1
      Me.menuItem12.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemEffectsEdgesDetection, Me._menuItemEffectsEdgeContour})
      Me.menuItem12.Text = "Edge"
      ' 
      ' _menuItemEffectsEdgesDetection
      ' 
      Me._menuItemEffectsEdgesDetection.Index = 0
      Me._menuItemEffectsEdgesDetection.Text = "Detection"
      ' 
      ' _menuItemEffectsEdgeContour
      ' 
      Me._menuItemEffectsEdgeContour.Index = 1
      Me._menuItemEffectsEdgeContour.Text = "Contour"
      ' 
      ' menuItem10
      ' 
      Me.menuItem10.Index = 2
      Me.menuItem10.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemEffectNoiseMax, Me._menuItemEffectNoiseMin, Me._menuItemEffectNoiseMedian})
      Me.menuItem10.Text = "Noise "
      ' 
      ' _menuItemEffectNoiseMax
      ' 
      Me._menuItemEffectNoiseMax.Index = 0
      Me._menuItemEffectNoiseMax.Text = "Maximum"
      ' 
      ' _menuItemEffectNoiseMin
      ' 
      Me._menuItemEffectNoiseMin.Index = 1
      Me._menuItemEffectNoiseMin.Text = "Minimum"
      ' 
      ' _menuItemEffectNoiseMedian
      ' 
      Me._menuItemEffectNoiseMedian.Index = 2
      Me._menuItemEffectNoiseMedian.Text = "Median"
      ' 
      ' menuItem11
      ' 
      Me.menuItem11.Index = 3
      Me.menuItem11.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemEffectsSharpenSharpen, Me._menuItemEffectsSharpenUnsharpen})
      Me.menuItem11.Text = "Sharpen"
      ' 
      ' _menuItemEffectsSharpenSharpen
      ' 
      Me._menuItemEffectsSharpenSharpen.Index = 0
      Me._menuItemEffectsSharpenSharpen.Text = "Sharpen"
      ' 
      ' _menuItemEffectsSharpenUnsharpen
      ' 
      Me._menuItemEffectsSharpenUnsharpen.Index = 1
      Me._menuItemEffectsSharpenUnsharpen.Text = "Unsharpen"
      ' 
      ' menuItem13
      ' 
      Me.menuItem13.Index = 4
      Me.menuItem13.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemEffectsSpecialGauissian})
      Me.menuItem13.Text = "Special"
      ' 
      ' _menuItemEffectsSpecialGauissian
      ' 
      Me._menuItemEffectsSpecialGauissian.Index = 0
      Me._menuItemEffectsSpecialGauissian.Text = "Gauissian"
      ' 
      ' _menuItemColor
      ' 
      Me._menuItemColor.Index = 6
      Me._menuItemColor.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemColorGrayScale, Me._menuItemColorResolution, Me.menuItem5, Me._menuItemFillCommand, Me.menuItem8, Me.menuItem1, _
       Me.menuItem3, Me.menuItem14, Me._menuItemSetPixelColor, Me._menuItemSeparation, Me._menuItemMerge})
      Me._menuItemColor.Text = "&Color"
      Me._menuItemColor.Visible = False
      ' 
      ' _menuItemColorGrayScale
      ' 
      Me._menuItemColorGrayScale.Index = 0
      Me._menuItemColorGrayScale.Text = "Gray Scale..."
      ' 
      ' _menuItemColorResolution
      ' 
      Me._menuItemColorResolution.Index = 1
      Me._menuItemColorResolution.Text = "Color Resolution..."
      ' 
      ' menuItem5
      ' 
      Me.menuItem5.Index = 2
      Me.menuItem5.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemLUTInvert, Me._menuItemImageDataInvert})
      Me.menuItem5.Text = "Invert"
      ' 
      ' _menuItemLUTInvert
      ' 
      Me._menuItemLUTInvert.Index = 0
      Me._menuItemLUTInvert.Text = "LUT invert "
      ' 
      ' _menuItemImageDataInvert
      ' 
      Me._menuItemImageDataInvert.Index = 1
      Me._menuItemImageDataInvert.Text = "Image data invert"
      ' 
      ' _menuItemFillCommand
      ' 
      Me._menuItemFillCommand.Index = 3
      Me._menuItemFillCommand.Text = "Fill"
      ' 
      ' menuItem8
      ' 
      Me.menuItem8.Index = 4
      Me.menuItem8.Text = "-"
      ' 
      ' menuItem1
      ' 
      Me.menuItem1.Index = 5
      Me.menuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemColorAdjustAutoLevel, Me._menuItemColorAdjustAutoContrast, Me._menuItemColorHistogramIntensity, Me._menuItemColorAdjustContrast, Me._menuItemColorAdjustBrightness})
      Me.menuItem1.Text = "Adjust"
      ' 
      ' _menuItemColorAdjustAutoLevel
      ' 
      Me._menuItemColorAdjustAutoLevel.Index = 0
      Me._menuItemColorAdjustAutoLevel.Text = "Auto Level"
      ' 
      ' _menuItemColorAdjustAutoContrast
      ' 
      Me._menuItemColorAdjustAutoContrast.Index = 1
      Me._menuItemColorAdjustAutoContrast.Text = "Auto Contrast"
      ' 
      ' _menuItemColorHistogramIntensity
      ' 
      Me._menuItemColorHistogramIntensity.Index = 2
      Me._menuItemColorHistogramIntensity.Text = "Auto Intensity"
      ' 
      ' _menuItemColorAdjustContrast
      ' 
      Me._menuItemColorAdjustContrast.Index = 3
      Me._menuItemColorAdjustContrast.Text = "Contrast"
      ' 
      ' _menuItemColorAdjustBrightness
      ' 
      Me._menuItemColorAdjustBrightness.Index = 4
      Me._menuItemColorAdjustBrightness.Text = "Brightness"
      ' 
      ' menuItem3
      ' 
      Me.menuItem3.Index = 6
      Me.menuItem3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemColorHistogramEqualizer, Me._menuItemColorHistogramAdaptiveContrast, Me._menuItemColorHistogramLocalEqualizer})
      Me.menuItem3.Text = "Histogram"
      ' 
      ' _menuItemColorHistogramEqualizer
      ' 
      Me._menuItemColorHistogramEqualizer.Index = 0
      Me._menuItemColorHistogramEqualizer.Text = "Equalizer"
      ' 
      ' _menuItemColorHistogramAdaptiveContrast
      ' 
      Me._menuItemColorHistogramAdaptiveContrast.Index = 1
      Me._menuItemColorHistogramAdaptiveContrast.Text = "Adaptive Contrast"
      ' 
      ' _menuItemColorHistogramLocalEqualizer
      ' 
      Me._menuItemColorHistogramLocalEqualizer.Index = 2
      Me._menuItemColorHistogramLocalEqualizer.Text = "Local Equalizer"
      ' 
      ' menuItem14
      ' 
      Me.menuItem14.Index = 7
      Me.menuItem14.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemColorAutoBinarize, Me._menuItemColorIntensityDetect})
      Me.menuItem14.Text = "Threshold"
      ' 
      ' _menuItemColorAutoBinarize
      ' 
      Me._menuItemColorAutoBinarize.Index = 0
      Me._menuItemColorAutoBinarize.Text = "Auto Binarize"
      ' 
      ' _menuItemColorIntensityDetect
      ' 
      Me._menuItemColorIntensityDetect.Index = 1
      Me._menuItemColorIntensityDetect.Text = "Intensity Detect"
      ' 
      ' _menuItemSetPixelColor
      ' 
      Me._menuItemSetPixelColor.Index = 8
      Me._menuItemSetPixelColor.Text = "SetPixelColor"
      ' 
      ' _menuItemSeparation
      ' 
      Me._menuItemSeparation.Index = 9
      Me._menuItemSeparation.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemSepRGB, Me._menuItemSepCMYK, Me._menuItemSepHSV, Me._menuItemSepHLS, Me._menuItemSepCMY, Me._menuItemSepAlpha, _
       Me._menuItemSepYUV, Me._menuItemSepXYZ, Me._menuItemSepLAB, Me._menuItemSepYCRCB, Me._menuItemSepSCT})
      Me._menuItemSeparation.Text = "S&eparation"
      ' 
      ' _menuItemSepRGB
      ' 
      Me._menuItemSepRGB.Index = 0
      Me._menuItemSepRGB.Text = "&RGB"
      ' 
      ' _menuItemSepCMYK
      ' 
      Me._menuItemSepCMYK.Index = 1
      Me._menuItemSepCMYK.Text = "CMY&K"
      ' 
      ' _menuItemSepHSV
      ' 
      Me._menuItemSepHSV.Index = 2
      Me._menuItemSepHSV.Text = "HS&V"
      ' 
      ' _menuItemSepHLS
      ' 
      Me._menuItemSepHLS.Index = 3
      Me._menuItemSepHLS.Text = "&HLS"
      ' 
      ' _menuItemSepCMY
      ' 
      Me._menuItemSepCMY.Index = 4
      Me._menuItemSepCMY.Text = "&CMY"
      ' 
      ' _menuItemSepAlpha
      ' 
      Me._menuItemSepAlpha.Index = 5
      Me._menuItemSepAlpha.Text = "&Alpha"
      ' 
      ' _menuItemSepYUV
      ' 
      Me._menuItemSepYUV.Index = 6
      Me._menuItemSepYUV.Text = "&YUV"
      ' 
      ' _menuItemSepXYZ
      ' 
      Me._menuItemSepXYZ.Index = 7
      Me._menuItemSepXYZ.Text = "&XYZ"
      ' 
      ' _menuItemSepLAB
      ' 
      Me._menuItemSepLAB.Index = 8
      Me._menuItemSepLAB.Text = "&LAB"
      ' 
      ' _menuItemSepYCRCB
      ' 
      Me._menuItemSepYCRCB.Index = 9
      Me._menuItemSepYCRCB.Text = "YCRC&B"
      ' 
      ' _menuItemSepSCT
      ' 
      Me._menuItemSepSCT.Index = 10
      Me._menuItemSepSCT.Text = "&SCT"
      ' 
      ' _menuItemMerge
      ' 
      Me._menuItemMerge.Index = 10
      Me._menuItemMerge.Text = "Merge ..."
      ' 
      ' _menuItemMedical
      ' 
      Me._menuItemMedical.Index = 7
      Me._menuItemMedical.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemMedicalAnisotropicDiffusion, Me._menuItemMedicalDigitalSubtract, Me._menuItemMedicalMeanShift, Me._menuItemMedicalMultiscaleEnhancement, Me._menuItemMedicalSelectData, Me._menuItemMedicalShiftData, _
       Me._menuItemMedicalSigma, Me._menuItemMedicalTissueEqualize, Me._menuItemMedicalSkeleton, Me._menuItemCLAHE, Me._miBackgroundRemoval})
      Me._menuItemMedical.Text = "Medical"
      Me._menuItemMedical.Visible = False
      ' 
      ' _menuItemMedicalAnisotropicDiffusion
      ' 
      Me._menuItemMedicalAnisotropicDiffusion.Index = 0
      Me._menuItemMedicalAnisotropicDiffusion.Text = "Anisotropic Diffusion"
      ' 
      ' _menuItemMedicalDigitalSubtract
      ' 
      Me._menuItemMedicalDigitalSubtract.Index = 1
      Me._menuItemMedicalDigitalSubtract.Text = "Digital Subtract"
      ' 
      ' _menuItemMedicalMeanShift
      ' 
      Me._menuItemMedicalMeanShift.Index = 2
      Me._menuItemMedicalMeanShift.Text = "Mean Shift"
      ' 
      ' _menuItemMedicalMultiscaleEnhancement
      ' 
      Me._menuItemMedicalMultiscaleEnhancement.Index = 3
      Me._menuItemMedicalMultiscaleEnhancement.Text = "Multiscale Enhancement"
      ' 
      ' _menuItemMedicalSelectData
      ' 
      Me._menuItemMedicalSelectData.Index = 4
      Me._menuItemMedicalSelectData.Text = "Select Data"
      ' 
      ' _menuItemMedicalShiftData
      ' 
      Me._menuItemMedicalShiftData.Index = 5
      Me._menuItemMedicalShiftData.Text = "Shift Data"
      ' 
      ' _menuItemMedicalSigma
      ' 
      Me._menuItemMedicalSigma.Index = 6
      Me._menuItemMedicalSigma.Text = "Sigma"
      ' 
      ' _menuItemMedicalTissueEqualize
      ' 
      Me._menuItemMedicalTissueEqualize.Index = 7
      Me._menuItemMedicalTissueEqualize.Text = "Tissue Equalize"
      ' 
      ' _menuItemMedicalSkeleton
      ' 
      Me._menuItemMedicalSkeleton.Index = 8
      Me._menuItemMedicalSkeleton.Text = "Skeleton"
      ' 
      ' _menuItemCLAHE
      ' 
      Me._menuItemCLAHE.Index = 9
      Me._menuItemCLAHE.Text = "CLAHE..."
      ' 
      ' _miBackgroundRemoval
      ' 
      Me._miBackgroundRemoval.Index = 10
      Me._miBackgroundRemoval.Text = "&Background Removal..."
      ' 
      ' _menuItemSegmentation
      ' 
      Me._menuItemSegmentation.Index = 8
      Me._menuItemSegmentation.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemSegmentationKMeans, Me._menuItemSegmentationOtsu, Me._menuItemSegmentationLevelSet, Me._menuItemSegmentationLambda, Me._menuItemSegmentationGWireTool, Me._menuItemSegmentationInvPerspective, _
       Me._menuItemSegmentationShrinkTool, Me._menuItemSegmentationTDAFilter, Me._menuItemSegmentationSRADFilter, Me._menuItemSegmentationWatershed, Me._menuItemDeskewToolStrip})
      Me._menuItemSegmentation.Text = "Segmentation"
      ' 
      ' _menuItemSegmentationKMeans
      ' 
      Me._menuItemSegmentationKMeans.Index = 0
      Me._menuItemSegmentationKMeans.Text = "KMeans"
      ' 
      ' _menuItemSegmentationOtsu
      ' 
      Me._menuItemSegmentationOtsu.Index = 1
      Me._menuItemSegmentationOtsu.Text = "Otsu"
      ' 
      ' _menuItemSegmentationLevelSet
      ' 
      Me._menuItemSegmentationLevelSet.Index = 2
      Me._menuItemSegmentationLevelSet.Text = "Level Set"
      ' 
      ' _menuItemSegmentationLambda
      ' 
      Me._menuItemSegmentationLambda.Index = 3
      Me._menuItemSegmentationLambda.Text = "Lambda Connectedness"
      ' 
      ' _menuItemSegmentationGWireTool
      ' 
      Me._menuItemSegmentationGWireTool.Index = 4
      Me._menuItemSegmentationGWireTool.Text = "GWire Tool"
      ' 
      ' _menuItemSegmentationInvPerspective
      ' 
      Me._menuItemSegmentationInvPerspective.Index = 5
      Me._menuItemSegmentationInvPerspective.Text = "Inv Perspective"
      ' 
      ' _menuItemSegmentationShrinkTool
      ' 
      Me._menuItemSegmentationShrinkTool.Index = 6
      Me._menuItemSegmentationShrinkTool.Text = "Shrink Tool"
      ' 
      ' _menuItemSegmentationTDAFilter
      ' 
      Me._menuItemSegmentationTDAFilter.Index = 7
      Me._menuItemSegmentationTDAFilter.Text = "TAD Filter"
      ' 
      ' _menuItemSegmentationSRADFilter
      ' 
      Me._menuItemSegmentationSRADFilter.Index = 8
      Me._menuItemSegmentationSRADFilter.Text = "SRAD Filter"
      ' 
      ' _menuItemSegmentationWatershed
      ' 
      Me._menuItemSegmentationWatershed.Index = 9
      Me._menuItemSegmentationWatershed.Text = "&Watershed..."
      ' 
      ' _menuItemDeskewToolStrip
      ' 
      Me._menuItemDeskewToolStrip.Index = 10
      Me._menuItemDeskewToolStrip.Text = "Perspective Deskew"
      ' 
      ' _menuItemDocument
      ' 
      Me._menuItemDocument.Index = 9
      Me._menuItemDocument.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemDocumentAutoCrop, Me._menuItemDocumentDespeckle, Me._menuItemDocumentErode, Me._menuItemDocumentDilate, Me._menuItemDocumentUnditherText, Me._menuItemDocumentFixBrokenLetters})
      Me._menuItemDocument.Text = "Document clean up"
      Me._menuItemDocument.Visible = False
      ' 
      ' _menuItemDocumentAutoCrop
      ' 
      Me._menuItemDocumentAutoCrop.Index = 0
      Me._menuItemDocumentAutoCrop.Text = "Auto Crop"
      ' 
      ' _menuItemDocumentDespeckle
      ' 
      Me._menuItemDocumentDespeckle.Index = 1
      Me._menuItemDocumentDespeckle.Text = "Despeckle"
      ' 
      ' _menuItemDocumentErode
      ' 
      Me._menuItemDocumentErode.Index = 2
      Me._menuItemDocumentErode.Text = "Erode"
      ' 
      ' _menuItemDocumentDilate
      ' 
      Me._menuItemDocumentDilate.Index = 3
      Me._menuItemDocumentDilate.Text = "Dilate"
      ' 
      ' _menuItemDocumentUnditherText
      ' 
      Me._menuItemDocumentUnditherText.Index = 4
      Me._menuItemDocumentUnditherText.Text = "Undither text"
      ' 
      ' _menuItemDocumentFixBrokenLetters
      ' 
      Me._menuItemDocumentFixBrokenLetters.Index = 5
      Me._menuItemDocumentFixBrokenLetters.Text = "Fix broken letters"
      ' 
      ' _menuItemWindow
      ' 
      Me._menuItemWindow.Index = 10
      Me._menuItemWindow.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemWindowCascade, Me._menuItemWindowTileHorizontally, Me._menuItemWindowTileVertically, Me._menuItemWindowArrangeIcons, Me._menuItemWindowCloseAll})
      Me._menuItemWindow.Text = "&Window"
      Me._menuItemWindow.Visible = False
      ' 
      ' _menuItemWindowCascade
      ' 
      Me._menuItemWindowCascade.Index = 0
      Me._menuItemWindowCascade.Text = "&Cascade"
      ' 
      ' _menuItemWindowTileHorizontally
      ' 
      Me._menuItemWindowTileHorizontally.Index = 1
      Me._menuItemWindowTileHorizontally.Text = "Tile &Horizontally"
      ' 
      ' _menuItemWindowTileVertically
      ' 
      Me._menuItemWindowTileVertically.Index = 2
      Me._menuItemWindowTileVertically.Text = "Tile &Vertically"
      ' 
      ' _menuItemWindowArrangeIcons
      ' 
      Me._menuItemWindowArrangeIcons.Index = 3
      Me._menuItemWindowArrangeIcons.Text = "Arrange &Icons"
      ' 
      ' _menuItemWindowCloseAll
      ' 
      Me._menuItemWindowCloseAll.Index = 4
      Me._menuItemWindowCloseAll.Text = "Close &All"
      ' 
      ' _miHelp
      ' 
      Me._miHelp.Index = 11
      Me._miHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miHelpAbout})
      Me._miHelp.Text = "&Help"
      ' 
      ' _miHelpAbout
      ' 
      Me._miHelpAbout.Index = 0
      Me._miHelpAbout.Text = "&About..."
      ' 
      ' MainForm
      ' 
      Me.AllowDrop = True
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(894, 289)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Menu = Me._mmMain
      Me.Name = "MainForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "LEADTOOLS for .NET VB Gray Scale Demo"
      Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
      Me.ResumeLayout(False)

   End Sub
#End Region

   <STAThread()> _
   Shared Sub Main()
      If Not Support.SetLicense() Then
         Return
      End If

      If RasterSupport.IsLocked(RasterSupportType.Medical) Then
         MessageBox.Show("Medical support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Return
      End If

      Application.Run(New MainForm())
   End Sub

   Private _codecs As RasterCodecs

   Private Sub MainForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
      UpdateMyControls()
      Messager.Caption = "LEADTOOLS for .NET VB Gray Scale Demo"
      Text = Messager.Caption
      Me.IsMdiContainer = True
      _childPath = New List(Of ViewerImages)()
      _directoryPath = String.Empty

      _codecs = New RasterCodecs()
      _rawdataLoad = RawData.[Default]
      _rawdataSave = RawData.[Default]

      _paintProperties = RasterPaintProperties.[Default]
      _paintProperties.PaintDisplayMode = _paintProperties.PaintDisplayMode Or RasterPaintDisplayModeFlags.ScaleToGray
      _paintProperties.PaintDisplayMode = _paintProperties.PaintDisplayMode Or RasterPaintDisplayModeFlags.Bicubic

   End Sub

   Public Sub UpdateMyControls()
      Try
         Dim activeForm As ViewerForm = TryCast(ActiveMdiChild, ViewerForm)
         EnableAndVisibleMenu(_menuItemPage, activeForm IsNot Nothing)
         EnableAndVisibleMenu(_menuItemWindow, activeForm IsNot Nothing)
         EnableAndVisibleMenu(_menuItemEffect, activeForm IsNot Nothing)
         'EnableAndVisibleMenu(_menuItemEdit, activeForm != null);
         EnableAndVisibleMenu(_menuItemColor, activeForm IsNot Nothing)
         EnableAndVisibleMenu(_menuItemImage, activeForm IsNot Nothing)
         EnableAndVisibleMenu(_menuItemMedical, activeForm IsNot Nothing)
         EnableAndVisibleMenu(_menuItemView, activeForm IsNot Nothing)
         EnableAndVisibleMenu(_menuItemDocument, activeForm IsNot Nothing)
         EnableAndVisibleMenu(_menuItemSegmentation, activeForm IsNot Nothing)
         EnableMenu(_menuItemFileSave, activeForm IsNot Nothing)
         EnableMenu(_menuItemSaveRaw, activeForm IsNot Nothing)
         EnableMenu(_menuItemRegion, activeForm IsNot Nothing)
         EnableMenu(_menuItemCopy, activeForm IsNot Nothing)
         EnableMenu(_menuItemRedo, activeForm IsNot Nothing)
         EnableMenu(_menuItemUndo, activeForm IsNot Nothing)
         EnableMenu(_menuItemMagGlassSettings, activeForm IsNot Nothing)
         EnableMenu(_menuItemRegionCombine, activeForm IsNot Nothing)

         If activeForm Is Nothing Then
            If CopyedImage IsNot Nothing Then
               CopyedImage.Dispose()
            End If
            CopyedImage = Nothing
            _menuItemPaste.Enabled = False
            Return
         End If
         _menuItemPaste.Enabled = CopyedImage IsNot Nothing
         Dim tmpImg As RasterImage = If((activeForm.Viewer.Floater IsNot Nothing), activeForm.Viewer.Floater, activeForm.Image)

         EnableMenu(_menuItemDeskewToolStrip, tmpImg.BitsPerPixel = 8 OrElse tmpImg.BitsPerPixel = 24 OrElse tmpImg.BitsPerPixel = 32)
         'EnableMenu(_menuItemColorResolution, !tmpImg.Signed);

         EnableMenu(_menuItemImageBlankPageDetection, tmpImg.BitsPerPixel <> 12 And tmpImg.BitsPerPixel <> 16 And tmpImg.BitsPerPixel <> 48 And tmpImg.BitsPerPixel <> 64)

         EnableAndVisibleMenu(_menuItemWL, activeForm.ImageCategory = ImageCategory.GrayScale_8_12_16_BPP)
         EnableMenu(_menuItemDocumentAutoCrop, Not tmpImg.Signed)
         EnableMenu(_menuItemDocumentDespeckle, Not tmpImg.Signed)
         EnableMenu(_menuItemSetPixelColor, Not tmpImg.Signed)
         EnableMenu(_menuItemColorAutoBinarize, Not tmpImg.Signed AndAlso tmpImg.BitsPerPixel = 8)
         EnableMenu(_menuItemColorIntensityDetect, Not tmpImg.Signed)
         EnableMenu(_menuItemEffectsEdgeContour, Not tmpImg.Signed)

         EnableMenu(_menuItemSeparation, Not tmpImg.Signed)
         EnableMenu(_menuItemColorAdjustAutoLevel, Not (tmpImg.Signed OrElse (activeForm.ImageCategory = ImageCategory.GrayScale_8_12_16_BPP AndAlso activeForm.Image.BitsPerPixel <> 8)))
         EnableMenu(_menuItemColorAdjustAutoContrast, Not (tmpImg.Signed OrElse (activeForm.ImageCategory = ImageCategory.GrayScale_8_12_16_BPP AndAlso activeForm.Image.BitsPerPixel <> 8)))
         EnableMenu(_menuItemColorHistogramIntensity, Not (tmpImg.Signed OrElse (activeForm.ImageCategory = ImageCategory.GrayScale_8_12_16_BPP AndAlso activeForm.Image.BitsPerPixel <> 8)))
         'EnableMenu(_menuItemFastMagicWandCommand, tmpImg.BitsPerPixel == 8);
         EnableMenu(_menuItemCLAHE, tmpImg.BitsPerPixel = 8 OrElse tmpImg.BitsPerPixel = 16)
         EnableMenu(_miBackgroundRemoval, tmpImg.BitsPerPixel = 16)
         EnableMenu(_menuItemMedicalMultiscaleEnhancement, activeForm.ImageCategory <> ImageCategory.GrayScale_32_48_BPP)
         EnableMenu(_menuItemMedicalTissueEqualize, activeForm.ImageCategory <> ImageCategory.GrayScale_32_48_BPP AndAlso activeForm.ImageCategory <> ImageCategory.OneBitImage)
         EnableMenu(_menuItemMedicalSigma, activeForm.ImageCategory <> ImageCategory.GrayScale_32_48_BPP AndAlso activeForm.ImageCategory <> ImageCategory.OneBitImage)

         If activeForm IsNot Nothing Then
            EnableAndVisibleMenu(_menuItemPage, activeForm.Image.PageCount > 1)
            EnableAndVisibleMenu(_menuItemPageFirst, activeForm.Image.PageCount > 1)
            EnableAndVisibleMenu(_menuItemPagePrevious, activeForm.Image.PageCount > 1)
            EnableAndVisibleMenu(_menuItemPageNext, activeForm.Image.PageCount > 1)
            EnableAndVisibleMenu(_menuItemPageLast, activeForm.Image.PageCount > 1)

            If activeForm.Image.PageCount > 1 Then
               _menuItemPageFirst.Enabled = activeForm.Image.Page > 1
               _menuItemPagePrevious.Enabled = activeForm.Image.Page > 1
               _menuItemPageNext.Enabled = activeForm.Image.Page <> activeForm.Image.PageCount
               _menuItemPageLast.Enabled = activeForm.Image.Page <> activeForm.Image.PageCount
            End If
         End If

         If activeForm.Viewer.Floater IsNot Nothing Then
            _menuItemUndo.Enabled = activeForm.FloaterImageIndex <> 0
            _menuItemRedo.Enabled = activeForm.FloaterImageIndex < activeForm.floaterImageslist.Count - 1
         Else
            _menuItemUndo.Enabled = activeForm.ImageIndex <> 0
            _menuItemRedo.Enabled = activeForm.ImageIndex < activeForm.imageslist.Count - 1
         End If

         Dim en As Boolean = Not (tmpImg.GrayscaleMode <> RasterGrayscaleMode.None AndAlso tmpImg.BitsPerPixel > 16)

         EnableMenu(_menuItemPage, Not _isSegmentation)
         EnableMenu(_menuItemWindow, Not _isSegmentation)
         EnableMenu(_menuItemFileSave, Not _isSegmentation)
         EnableMenu(_menuItemEffect, en AndAlso Not _isSegmentation)
         'EnableMenu(_menuItemEdit, !_isSegmentation);
         EnableMenu(_menuItemColor, en AndAlso Not _isSegmentation)
         EnableMenu(_menuItemImage, Not _isSegmentation)
         EnableMenu(_menuItemDocument, en AndAlso Not _isSegmentation)
         EnableMenu(_menuItemMedical, Not _isSegmentation)

         EnableMenu(_menuItemColorHistogram, en)
         EnableMenu(_menuItemImageInfo, en)
         EnableMenu(_menuItemLineHistogram, en)
         EnableMenu(_menuItemImageDeskew, en)
         EnableMenu(_menuItemMedicalSkeleton, en)
         EnableMenu(_menuItemMedicalDigitalSubtract, en)

         en = activeForm.ImageCategory = ImageCategory.GrayScale_8_12_16_BPP
         EnableMenu(_menuItemMedicalAnisotropicDiffusion, Not tmpImg.Signed AndAlso (activeForm.ImageCategory = ImageCategory.GrayScale_8_12_16_BPP AndAlso tmpImg.BitsPerPixel <> 8))
         EnableMenu(_menuItemMedicalSelectData, en AndAlso Not tmpImg.Signed AndAlso activeForm.Viewer.Floater Is Nothing)
         EnableMenu(_menuItemMedicalShiftData, en)

         EnableMenu(_menuItemSegmentation, Not _isSegmentation)
         EnableMenu(_menuItemDeskewToolStrip, tmpImg.BitsPerPixel = 8 OrElse tmpImg.BitsPerPixel = 24 OrElse tmpImg.BitsPerPixel = 32)
         EnableMenu(_menuItemMerge, Not tmpImg.Signed)

         EnableMenu(_menuItemLUTInvert, activeForm.ImageCategory = ImageCategory.GrayScale_8_12_16_BPP AndAlso tmpImg.BitsPerPixel <> 8)

         _menuItemRegionRectangle.Checked = (activeForm.RegionType = RegionType.RECTANGLE)
         _menuItemRegionEllipse.Checked = (activeForm.RegionType = RegionType.ELLIPSE)
         _menuItemRegionRoundRectangle.Checked = (activeForm.RegionType = RegionType.ROUND_RECTANGLE)
         _menuItemRegionFreehand.Checked = (activeForm.RegionType = RegionType.FREE_HAND)
         _menuItemRegionAutoSegment.Checked = (activeForm.RegionType = RegionType.AUTO_SEGMENT)
         '_menuItemFastMagicWandCommand.Checked = (activeForm.RegionType == RegionType.FAST_MAGIC_WAND);
         _menuItemRegionNone.Checked = (activeForm.RegionType = RegionType.NONE)
         _menuItemAddBorderToRegion.Checked = (activeForm.RegionType = RegionType.ADD_BORDER_TO_REGION)


         _menuItemViewMagnifyGlass.Checked = (activeForm.Viewer.InteractiveModes.FindById(activeForm.MagnifyGlassInteractiveMode.Id).IsEnabled)
         _menuItemInterActiveNone.Checked = (activeForm.Viewer.InteractiveModes.FindById(activeForm.NoneInteractiveMode.Id).IsEnabled OrElse activeForm.Viewer.InteractiveModes.FindById(activeForm.FloaterInteractiveMode.Id).IsEnabled)
         _menuItemInterActivePan.Checked = (activeForm.Viewer.InteractiveModes.FindById(activeForm.PanInteractiveMode.Id).IsEnabled)

         _menuItemSizeFit.Checked = (activeForm.Viewer.SizeMode = ControlSizeMode.FitAlways)
         _menuItemSizeNormal.Checked = ((activeForm.Viewer.SizeMode = ControlSizeMode.ActualSize) OrElse (activeForm.Viewer.SizeMode = ControlSizeMode.None))
      Catch generatedExceptionName As Exception
         'ex
      End Try
   End Sub

   Private Sub _miFileExit_Click(sender As Object, e As System.EventArgs) Handles _miFileExit.Click
      Close()
   End Sub

   Private Sub _miHelpAbout_Click(sender As Object, e As System.EventArgs) Handles _miHelpAbout.Click
      Using aboutDialog As New AboutDialog("Gray Scale", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub

   Private Sub EnableAndVisibleMenu(menu As MenuItem, value As Boolean)
      menu.Enabled = value
      menu.Visible = value
   End Sub

   Private Sub EnableMenu(menu As MenuItem, value As Boolean)
      menu.Enabled = value
   End Sub

   Private Sub _menuItemPage_Click(sender As Object, e As System.EventArgs) Handles _menuItemPageFirst.Click, _menuItemPagePrevious.Click, _menuItemPageNext.Click, _menuItemPageLast.Click
      Dim activeForm As ViewerForm = TryCast(ActiveMdiChild, ViewerForm)
      Try
         If sender Is _menuItemPageFirst Then
            activeForm.Viewer.Image.Page = 1
         ElseIf sender Is _menuItemPagePrevious Then
            activeForm.Viewer.Image.Page -= 1
         ElseIf sender Is _menuItemPageNext Then
            activeForm.Viewer.Image.Page += 1
         ElseIf sender Is _menuItemPageLast Then
            activeForm.Viewer.Image.Page = activeForm.Viewer.Image.PageCount
         End If

         activeForm.page()
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateMyControls()
      End Try
   End Sub

   Private Sub open_Click(sender As Object, e As EventArgs) Handles _menuItemFileOpen.Click
      Dim loader As New ImageFileLoader()
      Try
         loader.ShowLoadPagesDialog = True
         loader.OpenDialogInitialPath = _directoryPath
         If loader.Load(Me, _codecs, True) > 0 Then
            Dim child As New ViewerForm(Me)
            child.MdiParent = Me
            child.WindowState = FormWindowState.Normal
            child.Initialize()
            child.myLoad(loader.Image, loader.FileName)
            AddHandler child.FormClosed, AddressOf form_FormClosed
            child.Show()
            child.Id = Me.MdiChildren.Length - 1
            If Path.GetDirectoryName(loader.FileName) IsNot Nothing Then
               _directoryPath = Path.GetDirectoryName(loader.FileName)
            End If
            _childPath.Add(New ViewerImages(loader.FileName, child.Id, child.Image))
         End If
         Dim activeForm As ViewerForm = TryCast(ActiveMdiChild, ViewerForm)
         activeForm.UpdateAfterCommandExecution()
         UpdateMyControls()
      Catch ex As Exception
         Messager.ShowFileOpenError(Me, loader.FileName, ex)
      End Try
   End Sub

   Private Sub save_Click(sender As Object, e As EventArgs) Handles _menuItemFileSave.Click
      TryCast(ActiveMdiChild, ViewerForm).save()
      UpdateMyControls()
   End Sub

   Private Sub _menuItemWindow_Click(sender As Object, e As EventArgs) Handles _menuItemWindowCascade.Click, _menuItemWindowTileHorizontally.Click, _menuItemWindowTileVertically.Click, _menuItemWindowArrangeIcons.Click, _menuItemWindowCloseAll.Click
      If sender Is _menuItemWindowCascade Then
         LayoutMdi(MdiLayout.Cascade)
      ElseIf sender Is _menuItemWindowTileHorizontally Then
         LayoutMdi(MdiLayout.TileHorizontal)
      ElseIf sender Is _menuItemWindowTileVertically Then
         LayoutMdi(MdiLayout.TileVertical)
      ElseIf sender Is _menuItemWindowArrangeIcons Then
         LayoutMdi(MdiLayout.ArrangeIcons)
      ElseIf sender Is _menuItemWindowCloseAll Then
         While MdiChildren.Length > 0
            MdiChildren(0).Close()
         End While
         UpdateMyControls()
      End If
   End Sub

   Private Sub _menuItem_WL_Click(sender As Object, e As EventArgs) Handles _menuItemWLManually.Click
      Dim activeForm As ViewerForm = TryCast(ActiveMdiChild, ViewerForm)
      activeForm.WLManually()
   End Sub

   Private Sub _menuItem_Click(sender As Object, e As EventArgs) Handles _menuItemUndo.Click, _menuItemRedo.Click, _menuItemRegionCombine.Click, _menuItemRegionCancel.Click, _menuItemMagGlassSettings.Click, _menuItemCopy.Click, _menuItemPaste.Click, _menuItemColorHistogram.Click, _menuItemImageInfo.Click, _menuItemLineHistogram.Click, _menuItemImageFlipH.Click, _menuItemImageFlipV.Click, _menuItemImageDeskew.Click, _menuItemImageShear.Click, _menuItemImageRotateFast90.Click, _menuItemImageRotateFast180.Click, _menuItemRotateFast270.Click, _menuItemRotateCustom.Click, _menuItemImageBlankPageDetection.Click, _menuItemCombine.Click, _menuItemCopyImage.Click, _menuItemEffectsBlurAvg.Click, _menuItemEffectsEdgesDetection.Click, _menuItemEffectsEdgeContour.Click, _menuItemEffectNoiseMax.Click, _menuItemEffectNoiseMin.Click, _menuItemEffectNoiseMedian.Click, _menuItemEffectsSharpenSharpen.Click, _menuItemEffectsSharpenUnsharpen.Click, _menuItemEffectsSpecialGauissian.Click, _menuItemColorGrayScale.Click, _menuItemColorResolution.Click, _menuItemLUTInvert.Click, _menuItemImageDataInvert.Click, _menuItemFillCommand.Click, _menuItemColorAdjustAutoLevel.Click, _menuItemColorAdjustAutoContrast.Click, _menuItemColorHistogramIntensity.Click, _menuItemColorAdjustContrast.Click, _menuItemColorAdjustBrightness.Click, _menuItemColorHistogramEqualizer.Click, _menuItemColorHistogramAdaptiveContrast.Click, _menuItemColorHistogramLocalEqualizer.Click, _menuItemColorAutoBinarize.Click, _menuItemColorIntensityDetect.Click, _menuItemMerge.Click, _menuItemMedicalAnisotropicDiffusion.Click, _menuItemMedicalDigitalSubtract.Click, _menuItemMedicalMeanShift.Click, _menuItemMedicalMultiscaleEnhancement.Click, _menuItemMedicalSelectData.Click, _menuItemMedicalShiftData.Click, _menuItemMedicalSigma.Click, _menuItemMedicalTissueEqualize.Click, _menuItemMedicalSkeleton.Click, _menuItemCLAHE.Click, _miBackgroundRemoval.Click, _menuItemSegmentationKMeans.Click, _menuItemSegmentationOtsu.Click, _menuItemSegmentationLevelSet.Click, _menuItemSegmentationLambda.Click, _menuItemSegmentationGWireTool.Click, _menuItemSegmentationInvPerspective.Click, _menuItemSegmentationShrinkTool.Click, _menuItemSegmentationTDAFilter.Click, _menuItemSegmentationSRADFilter.Click, _menuItemSegmentationWatershed.Click, _menuItemDeskewToolStrip.Click, _menuItemDocumentAutoCrop.Click, _menuItemDocumentDespeckle.Click, _menuItemDocumentErode.Click, _menuItemDocumentDilate.Click, _menuItemDocumentUnditherText.Click, _menuItemDocumentFixBrokenLetters.Click
      Dim activeForm As ViewerForm = TryCast(ActiveMdiChild, ViewerForm)
      Try
         If sender Is _menuItemFillCommand Then
            activeForm.fillCommand()
            'else if (sender == _menuItemFastMagicWandCommand)
            '   activeForm.fastMagicWandCommand();
         ElseIf sender Is _menuItemColorHistogram Then
            activeForm.histogram()
         ElseIf sender Is _menuItemRegionCancel Then
            If activeForm.Viewer.Floater IsNot Nothing Then
               activeForm.Viewer.Floater = Nothing
            End If
         ElseIf sender Is _menuItemLUTInvert OrElse sender Is _menuItemImageDataInvert Then
            activeForm.InvertByCommand = True
            If sender Is _menuItemLUTInvert Then
               activeForm.invert(True)
            Else
               activeForm.invert(False)
            End If
         ElseIf sender Is _miBackgroundRemoval Then
            activeForm.BackgroundRemoval(Me)
         ElseIf sender Is _menuItemImageFlipH Then
            activeForm.flip(True)
         ElseIf sender Is _menuItemImageFlipV Then
            activeForm.flip(False)
         ElseIf sender Is _menuItemEffectsBlurAvg Then
            activeForm.average()
         ElseIf sender Is _menuItemEffectNoiseMax Then
            activeForm.noiseMax()
         ElseIf sender Is _menuItemEffectNoiseMin Then
            activeForm.noiseMin()
         ElseIf sender Is _menuItemEffectNoiseMedian Then
            activeForm.noiseMedian()
         ElseIf sender Is _menuItemEffectsSharpenSharpen Then
            activeForm.sharpen()
         ElseIf sender Is _menuItemEffectsSharpenUnsharpen Then
            activeForm.unSharpen()
         ElseIf sender Is _menuItemEffectsEdgesDetection Then
            activeForm.edgeDetection()
         ElseIf sender Is _menuItemEffectsEdgeContour Then
            activeForm.edgeContour()
         ElseIf sender Is _menuItemEffectsSpecialGauissian Then
            activeForm.gauissian()
         ElseIf sender Is _menuItemColorAdjustContrast Then
            activeForm.contrast()
         ElseIf sender Is _menuItemColorAdjustBrightness Then
            activeForm.brightness()
         ElseIf sender Is _menuItemColorHistogramEqualizer Then
            activeForm.histogramEqualizer()
         ElseIf sender Is _menuItemColorHistogramAdaptiveContrast Then
            activeForm.histogramAdaptiveContrast()
         ElseIf sender Is _menuItemColorHistogramLocalEqualizer Then
            activeForm.histogramLocalEqualizer()
         ElseIf sender Is _menuItemColorAdjustAutoLevel Then
            activeForm.autoLevel()
         ElseIf sender Is _menuItemColorAdjustAutoContrast Then
            activeForm.autoContrast()
         ElseIf sender Is _menuItemColorHistogramIntensity Then
            activeForm.autoIntensity()
         ElseIf sender Is _menuItemImageDeskew Then
            activeForm.deskew()
         ElseIf sender Is _menuItemImageBlankPageDetection Then
            activeForm.blankPageDetection()
         ElseIf sender Is _menuItemImageRotateFast90 Then
            activeForm.rotate(90)
         ElseIf sender Is _menuItemImageRotateFast180 Then
            activeForm.rotate(180)
         ElseIf sender Is _menuItemRotateFast270 Then
            activeForm.rotate(270)
         ElseIf sender Is _menuItemRotateCustom Then
            activeForm.rotate(-1)
         ElseIf sender Is _menuItemImageShear Then
            activeForm.shear()
         ElseIf sender Is _menuItemColorAutoBinarize Then
            activeForm.autoBinarize()
         ElseIf sender Is _menuItemColorIntensityDetect Then
            activeForm.intensityDetect()
         ElseIf sender Is _menuItemSegmentationKMeans Then
            activeForm.KMeans()
         ElseIf sender Is _menuItemSegmentationOtsu Then
            activeForm.Otsu(Me)
         ElseIf sender Is _menuItemSegmentationLambda Then
            activeForm.Lambda()
         ElseIf sender Is _menuItemSegmentationLevelSet Then
            activeForm.LevelSet()
         ElseIf sender Is _menuItemSegmentationTDAFilter Then
            activeForm.TDAFilter()
         ElseIf sender Is _menuItemSegmentationSRADFilter Then
            activeForm.SRADFilter()
         ElseIf sender Is _menuItemDocumentAutoCrop Then
            activeForm.AutoCrop()
         ElseIf sender Is _menuItemDocumentDespeckle Then
            activeForm.Despeckle()
         ElseIf sender Is _menuItemDocumentErode Then
            activeForm.Erode()
         ElseIf sender Is _menuItemDocumentDilate Then
            activeForm.Dilate()
         ElseIf sender Is _menuItemDocumentUnditherText Then
            activeForm.UnditherText()
         ElseIf sender Is _menuItemDocumentFixBrokenLetters Then
            activeForm.FixBrokenLetters()
         ElseIf sender Is _menuItemSegmentationInvPerspective Then
            activeForm.invPerspective(Me)
            _isSegmentation = True
            activeForm.IsPerspective = True
         ElseIf sender Is _menuItemSegmentationShrinkTool Then
            activeForm.IsRegion = True
            activeForm.ShrinkTool(Me)
            _isSegmentation = True
         ElseIf sender Is _menuItemSegmentationGWireTool Then
            activeForm.gWireTool(Me)
            _isSegmentation = True
            activeForm.IsPerspective = True
         ElseIf sender Is _menuItemMedicalAnisotropicDiffusion Then
            activeForm.AnisotropicDiffusion()
         ElseIf sender Is _menuItemMedicalDigitalSubtract Then
            activeForm.DigitalSubtract()
         ElseIf sender Is _menuItemMedicalMeanShift Then
            activeForm.MeanShift()
         ElseIf sender Is _menuItemMedicalMultiscaleEnhancement Then
            activeForm.MultiscaleEnhancement(Me)
         ElseIf sender Is _menuItemMedicalSelectData Then
            activeForm.SelectData()
         ElseIf sender Is _menuItemMedicalShiftData Then
            activeForm.ShiftData()
         ElseIf sender Is _menuItemMedicalSigma Then
            activeForm.Sigma()
         ElseIf sender Is _menuItemMedicalTissueEqualize Then
            activeForm.TissueEqualize()
         ElseIf sender Is _menuItemMedicalSkeleton Then
            activeForm.Skeleton()
         ElseIf sender Is _menuItemRegionCombine Then
            activeForm.CombineFloater()
         ElseIf sender Is _menuItemCombine Then
            activeForm.CombineImage()
         ElseIf sender Is _menuItemCopyImage Then
            activeForm.CopyImage()
         ElseIf sender Is _menuItemImageInfo Then
            activeForm.StatisticsInformation()
         ElseIf sender Is _menuItemLineHistogram Then
            activeForm.LineHistogram()
         ElseIf sender Is _menuItemMerge Then
            activeForm.Merge()
         ElseIf sender Is _menuItemMagGlassSettings Then
            activeForm.MagnifyGlass()
         ElseIf sender Is _menuItemUndo Then
            activeForm.Undo()
         ElseIf sender Is _menuItemRedo Then
            activeForm.Redo()
         ElseIf sender Is _menuItemCLAHE Then
            activeForm.CLAHE()
         ElseIf sender Is _menuItemCopy Then
            Copy()
         ElseIf sender Is _menuItemPaste Then
            Paste()
            activeForm = TryCast(ActiveMdiChild, ViewerForm)
         ElseIf sender Is _menuItemSegmentationWatershed Then
            _isSegmentation = True
            activeForm.Watershed(Me)
         ElseIf sender Is _menuItemDeskewToolStrip Then
            activeForm.Auto3DDeskew()
         ElseIf sender Is _menuItemColorGrayScale Then
            Dim dlg As New GrayScaleDialog()
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               activeForm.Grayscale(dlg.BitsPerPixel)
            End If
         ElseIf sender Is _menuItemColorResolution Then
            Dim dlg As New ColorResolutionDialog(activeForm.Viewer.Image, _paintProperties)
            dlg.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               activeForm.ColorResolution(dlg.BitsPerPixel, dlg.Order, dlg.DitheringMethod, dlg.PaletteFlags)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
      Finally
         If activeForm IsNot Nothing Then
            activeForm.UpdateAfterCommandExecution()
         End If
         UpdateMyControls()
      End Try
   End Sub

   Private Sub MainForm_MdiChildActivate(sender As Object, e As EventArgs) Handles Me.MdiChildActivate
      UpdateMyControls()
   End Sub

   Private Sub form_FormClosed(sender As Object, e As EventArgs)
      Dim i As Integer = 0
      Try
         Dim child As ViewerForm = CType(sender, ViewerForm)
         For Each tmp As ViewerImages In _childPath
            If tmp.ChildFormId = child.Id Then
               Exit For
            Else
               i += 1
            End If
         Next

         _childPath.RemoveAt(i)

         For x As Integer = i To _childPath.Count - 1
            _childPath(x).ChildFormId -= 1
         Next
         For x As Integer = i To Me.MdiChildren.Length - 1
            CType(Me.MdiChildren(x), ViewerForm).Id = CType(Me.MdiChildren(x), ViewerForm).Id - 1
         Next
      Catch generatedExceptionName As Exception
         'ex
      End Try
   End Sub

   Private Sub Region_Click(sender As Object, e As EventArgs) Handles _menuItemRegionNone.Click, _menuItemRegionRectangle.Click, _menuItemRegionRoundRectangle.Click, _menuItemRegionEllipse.Click, _menuItemRegionFreehand.Click, _menuItemRegionAutoSegment.Click, _menuItemAddBorderToRegion.Click
      Dim activeForm As ViewerForm = TryCast(ActiveMdiChild, ViewerForm)
      activeForm.DisableInteractiveModes(activeForm.Viewer)
      If activeForm.Viewer.Floater IsNot Nothing Then
         activeForm.Viewer.CombineFloater(True)
      End If

      activeForm.Viewer.InteractiveModes.EnableById(activeForm.NoneInteractiveMode.Id)
      activeForm.Viewer.InteractiveModes.BeginUpdate()


      If sender Is _menuItemRegionRectangle Then
         activeForm.RegionInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle
         activeForm.RegionInteractiveMode.IsEnabled = True
         activeForm.RegionType = RegionType.RECTANGLE
      ElseIf sender Is _menuItemRegionEllipse Then
         activeForm.RegionType = RegionType.ELLIPSE
         activeForm.RegionInteractiveMode.Shape = ImageViewerRubberBandShape.Ellipse
         activeForm.RegionInteractiveMode.IsEnabled = True
      ElseIf sender Is _menuItemRegionFreehand Then
         activeForm.RegionType = RegionType.FREE_HAND
         activeForm.RegionInteractiveMode.Shape = ImageViewerRubberBandShape.Freehand
         activeForm.RegionInteractiveMode.IsEnabled = True
         activeForm.freeHand()
      ElseIf sender Is _menuItemAddBorderToRegion Then
         activeForm.RegionType = RegionType.ADD_BORDER_TO_REGION
      ElseIf sender Is _menuItemRegionNone Then
         activeForm.RegionType = RegionType.NONE
      ElseIf sender Is _menuItemRegionRoundRectangle Then
         activeForm.RegionInteractiveMode.Shape = ImageViewerRubberBandShape.RoundRectangle
         activeForm.RegionInteractiveMode.IsEnabled = True
         activeForm.RegionType = RegionType.ROUND_RECTANGLE
      ElseIf sender Is _menuItemRegionAutoSegment Then
         activeForm.RegionType = RegionType.AUTO_SEGMENT
      End If


      activeForm.Viewer.InteractiveModes.EndUpdate()

      UpdateMyControls()
      activeForm.UpdateAfterCommandExecution()
   End Sub

   Private Sub _menuItemSensitivity_Click(sender As Object, e As EventArgs) Handles _menuItemSensitivity.Click
      Dim activeForm As ViewerForm = TryCast(ActiveMdiChild, ViewerForm)
      activeForm.Sensitivity()
   End Sub

   Private Sub interactiveMode_Click(sender As Object, e As EventArgs) Handles _menuItemInterActiveNone.Click, _menuItemViewMagnifyGlass.Click, _menuItemInterActivePan.Click
      Dim activeForm As ViewerForm = TryCast(ActiveMdiChild, ViewerForm)

      activeForm.DisableInteractiveModes(activeForm.Viewer)
      If sender Is _menuItemViewMagnifyGlass Then
         activeForm.Viewer.InteractiveModes.EnableById(activeForm.MagnifyGlassInteractiveMode.Id)
         activeForm.RegionType = RegionType.NONE
         activeForm.Viewer.Floater = Nothing
         activeForm.Viewer.Invalidate()
      ElseIf sender Is _menuItemInterActiveNone Then
         If activeForm.Viewer.Floater Is Nothing Then
            activeForm.Viewer.InteractiveModes.EnableById(activeForm.NoneInteractiveMode.Id)
         Else
            activeForm.Viewer.InteractiveModes.EnableById(activeForm.FloaterInteractiveMode.Id)
         End If
      ElseIf sender Is _menuItemInterActivePan Then
         activeForm.Viewer.InteractiveModes.EnableById(activeForm.PanInteractiveMode.Id)
      End If
      UpdateMyControls()
   End Sub

   Private Sub _menuItemSep_Click(sender As Object, e As EventArgs) Handles _menuItemSepRGB.Click, _menuItemSepCMYK.Click, _menuItemSepHSV.Click, _menuItemSepHLS.Click, _menuItemSepCMY.Click, _menuItemSepAlpha.Click, _menuItemSepYUV.Click, _menuItemSepXYZ.Click, _menuItemSepLAB.Click, _menuItemSepYCRCB.Click, _menuItemSepSCT.Click
      Dim activeForm As ViewerForm = TryCast(ActiveMdiChild, ViewerForm)

      If sender Is _menuItemSepRGB Then
         activeForm.SepType = SeparationType.RGB
      ElseIf sender Is _menuItemSepHSV Then
         activeForm.SepType = SeparationType.HSV
      ElseIf sender Is _menuItemSepHLS Then
         activeForm.SepType = SeparationType.HLS
      ElseIf sender Is _menuItemSepCMYK Then
         activeForm.SepType = SeparationType.CMYK
      ElseIf sender Is _menuItemSepCMY Then
         activeForm.SepType = SeparationType.CMY
      ElseIf sender Is _menuItemSepAlpha Then
         activeForm.SepType = SeparationType.ALPHA
      ElseIf sender Is _menuItemSepYUV Then
         activeForm.SepType = SeparationType.YUV
      ElseIf sender Is _menuItemSepXYZ Then
         activeForm.SepType = SeparationType.XYZ
      ElseIf sender Is _menuItemSepLAB Then
         activeForm.SepType = SeparationType.LAB
      ElseIf sender Is _menuItemSepYCRCB Then
         activeForm.SepType = SeparationType.YCRCB
      ElseIf sender Is _menuItemSepSCT Then
         activeForm.SepType = SeparationType.SCT
      End If

      activeForm.Separation()
   End Sub

   Private Sub MainForm_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
      If Tools.CanDrop(e.Data) Then
         e.Effect = DragDropEffects.Copy
      End If
   End Sub

   Private Sub MainForm_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
      If Tools.CanDrop(e.Data) Then
         Dim files As String() = Tools.GetDropFiles(e.Data)
         If files IsNot Nothing Then
            LoadDropFiles(Nothing, files)
         End If
      End If
   End Sub

   Public Sub LoadDropFiles(viewer As ViewerForm, files As String())
      Try
         If files IsNot Nothing Then
            For i As Integer = 0 To files.Length - 1
               Try
                  Dim image As RasterImage = _codecs.Load(files(i))
                  Dim info As New ImageInformation(image, files(i))
                  If i = 0 AndAlso viewer IsNot Nothing Then
                     viewer.Initialize()
                  Else
                     Dim child As New ViewerForm(Me)
                     child.MdiParent = Me
                     child.WindowState = FormWindowState.Normal
                     child.Initialize()
                     child.myLoad(image, info.Name)
                     child.Show()
                  End If
               Catch ex As Exception
                  Messager.ShowFileOpenError(Me, files(i), ex)
               End Try
            Next
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateMyControls()
      End Try
   End Sub

   Private Sub _menuItemSize_Click(sender As Object, e As EventArgs) Handles _menuItemSizeNormal.Click, _menuItemSizeFit.Click
      Dim activeForm As ViewerForm = TryCast(ActiveMdiChild, ViewerForm)

      If sender Is _menuItemSizeNormal Then
         activeForm.Viewer.Zoom(ControlSizeMode.ActualSize, 1, activeForm.Viewer.DefaultZoomOrigin)
      ElseIf sender Is _menuItemSizeFit Then
         activeForm.Viewer.Zoom(ControlSizeMode.FitAlways, 1, activeForm.Viewer.DefaultZoomOrigin)
      End If
      UpdateMyControls()

   End Sub

   Public Sub Copy()
      Dim activeForm As ViewerForm = TryCast(ActiveMdiChild, ViewerForm)
      If CopyedImage IsNot Nothing Then
         CopyedImage.Dispose()
      End If

      If activeForm.Viewer.Floater Is Nothing Then
         RasterClipboard.Copy(activeForm.Handle, activeForm.Viewer.Image, RasterClipboardCopyFlags.Dib)
         CopyedImage = New RasterImage(activeForm.Viewer.Image)
      Else
         RasterClipboard.Copy(activeForm.Handle, activeForm.Viewer.Floater, RasterClipboardCopyFlags.Dib)
         CopyedImage = New RasterImage(activeForm.Viewer.Floater)
      End If

      CopyedImage.SetRegion(Nothing, Nothing, RasterRegionCombineMode.[Set])
   End Sub

   Private Sub NewImage(info As ImageInformation)
      Dim child As New ViewerForm(Me)
      child.MdiParent = Me
      child.Initialize()
      child.myLoad(info.Image, info.Name)
      AddHandler child.FormClosed, AddressOf form_FormClosed

      child.Viewer.Zoom(ControlSizeMode.ActualSize, 1, child.Viewer.DefaultZoomOrigin)
      child.Viewer.InteractiveModes.BeginUpdate()
      child.NoneInteractiveMode.IsEnabled = True

      'Set the DoubleTapSizeMode property for all ImageViewerPanZoomInteractiveModes to use the current size mode of the image viewer control
      For Each mode As ImageViewerInteractiveMode In child.Viewer.InteractiveModes
         If TypeOf mode Is ImageViewerPanZoomInteractiveMode Then
            CType(mode, ImageViewerPanZoomInteractiveMode).DoubleTapSizeMode = child.Viewer.SizeMode
         End If
      Next

      child.Viewer.InteractiveModes.EndUpdate()
      child.Show()
   End Sub

   Public Sub Paste()
      Try
         Using wait As New WaitCursor()
            Dim image As RasterImage = Nothing
            If CopyedImage IsNot Nothing AndAlso (CopyedImage.BitsPerPixel = 16 OrElse CopyedImage.BitsPerPixel = 12) Then
               image = CopyedImage.Clone()
            Else
               image = RasterClipboard.Paste(Me.Handle)
            End If

            If image IsNot Nothing Then
               Dim activeForm As ViewerForm = TryCast(ActiveMdiChild, ViewerForm)

               If image.HasRegion AndAlso activeForm Is Nothing Then
                  image.MakeRegionEmpty()
               End If

               If image.HasRegion Then

                  ' make sure the images have the same BitsPerPixel and Palette
                  If activeForm.Viewer.Image.BitsPerPixel > 8 Then
                     If image.BitsPerPixel <> activeForm.Viewer.Image.BitsPerPixel Then
                        Try
                           Dim colorRes As New ColorResolutionCommand()
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
                        Dim colorRes As New ColorResolutionCommand()
                        colorRes.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel
                        colorRes.SetPalette(activeForm.Viewer.Image.GetPalette())
                        colorRes.PaletteFlags = ColorResolutionCommandPaletteFlags.UsePalette
                        colorRes.Mode = ColorResolutionCommandMode.InPlace
                        colorRes.Run(image)
                     Catch ex As Exception
                        Messager.ShowError(Me, ex)
                     End Try
                  End If
                  activeForm.Viewer.Floater = image
                  activeForm.Viewer.FloaterOpacity = 1.0
                  Dim MyMatrix As LeadMatrix = activeForm.Viewer.ImageTransform
                  Dim m As New Matrix(CSng(MyMatrix.M11), CSng(MyMatrix.M12), CSng(MyMatrix.M21), CSng(MyMatrix.M22), CSng(MyMatrix.OffsetX), CSng(MyMatrix.OffsetY))
                  Dim t As New Transformer(m)

                  Dim FloaterPosition As New Point(CInt(activeForm.Viewer.FloaterTransform.OffsetX), CInt(activeForm.Viewer.FloaterTransform.OffsetY))

                  Dim floatertransform As LeadMatrix = activeForm.Viewer.FloaterTransform
                  floatertransform.OffsetX = Point.Round(t.PointToLogical(Point.Empty)).X
                  floatertransform.OffsetY = Point.Round(t.PointToLogical(Point.Empty)).Y
                  activeForm.Viewer.FloaterTransform = floatertransform

                  activeForm.Viewer.InteractiveModes.BeginUpdate()
                  activeForm.FloaterInteractiveMode.IsEnabled = True
                  activeForm.Viewer.InteractiveModes.EndUpdate()
               Else
                  NewImage(New ImageInformation(image) With { _
                    .Name = "Clipboard Data" _
                  })
               End If
            End If
         End Using
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateMyControls()
      End Try
   End Sub

   Private Sub _menuItemOpenRaw_Click(sender As Object, e As EventArgs) Handles _menuItemOpenRaw.Click
      Try
         Dim ofd As New OpenFileDialog()
         ofd.Filter = "All Files (*.*)|*.*|RAW (*.raw)|*.raw|Fax (*.fax)|*.fax|ABIC (*.abic;*.abc)|*.abic;*.abc"
         ofd.FilterIndex = 1
         If ofd.ShowDialog(Me) = DialogResult.OK Then
            LoadRaw(ofd.FileName)
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateMyControls()
      End Try
   End Sub

   Private Sub _menuItemSaveRaw_Click(sender As Object, e As EventArgs) Handles _menuItemSaveRaw.Click
      Dim saver As New ImageFileSaver()

      Try
         Dim sfd As New SaveFileDialog()
         sfd.Filter = "RAW (*.raw)|*.raw|Fax (*.fax)|*.fax"
         sfd.FilterIndex = 1
         If sfd.ShowDialog(Me) = DialogResult.OK Then
            SaveRaw(sfd.FileName)
         End If
      Catch ex As Exception
         Messager.ShowFileSaveError(Me, saver.FileName, ex)
      End Try
   End Sub


   Private Sub LoadRaw(fileName As String)
      Dim handler As EventHandler(Of CodecsLoadInformationEventArgs) = Nothing
      Try
         Dim dlg As New RawDialog(True)
         dlg.CurrentRawData = _rawdataLoad
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            Dim imageInfo As New ImageInformation()
            imageInfo.Name = fileName
            _rawdataLoad = dlg.CurrentRawData

            handler = New EventHandler(Of CodecsLoadInformationEventArgs)(AddressOf codecs_LoadInformation)
            _codecs.Options.Load.Format = _rawdataLoad.Format
            AddHandler _codecs.LoadInformation, AddressOf codecs_LoadInformation

            Using wait As New WaitCursor()
               imageInfo.Image = _codecs.Load(fileName)

               Dim cmd As New MinMaxValuesCommand()
               cmd.Run(imageInfo.Image)
               Dim highValue As Integer = cmd.MaximumValue
               Dim lowValue As Integer = cmd.MinimumValue

               Dim child As New ViewerForm(Me)
               child.MdiParent = Me
               child.WindowState = FormWindowState.Normal
               child.Initialize()
               child.myLoad(imageInfo.Image, imageInfo.Name)
               AddHandler child.FormClosed, AddressOf form_FormClosed
               child.Show()
               child.Id = Me.MdiChildren.Length - 1
               If Path.GetDirectoryName(imageInfo.Name) IsNot Nothing Then
                  _directoryPath = Path.GetDirectoryName(imageInfo.Name)
               End If
               _childPath.Add(New ViewerImages(imageInfo.Name, child.Id, child.Image))
            End Using
         End If
      Catch ex As Exception
         MessageBox.Show("Invalid File Parameter " + ex.Message)
      Finally
         RemoveHandler _codecs.LoadInformation, handler
         _codecs.Options.Load.Format = RasterImageFormat.Unknown
      End Try
   End Sub

   Private Sub codecs_LoadInformation(sender As Object, e As CodecsLoadInformationEventArgs)
      ' Set the information
      e.Format = _rawdataLoad.Format
      e.Width = _rawdataLoad.Width
      e.Height = _rawdataLoad.Height
      e.BitsPerPixel = _rawdataLoad.BitsPerPixel
      e.XResolution = _rawdataLoad.XResolution
      e.YResolution = _rawdataLoad.YResolution
      e.Offset = _rawdataLoad.Offset
      e.WhiteOnBlack = _rawdataLoad.WhiteOnBlack

      If _rawdataLoad.Padding Then
         e.Pad4 = True
      End If

      e.Order = _rawdataLoad.Order

      If _rawdataLoad.ReverseBits Then
         e.LeastSignificantBitFirst = True
      End If

      e.ViewPerspective = _rawdataLoad.ViewPerspective

      ' If image is palettized create a grayscale palette
      If _rawdataLoad.PaletteEnabled Then
         If e.BitsPerPixel <= 8 Then
            If Not _rawdataLoad.FixedPalette Then
               Dim colors As Integer = 1 << e.BitsPerPixel
               Dim palette As RasterColor() = New RasterColor(colors - 1) {}
               For i As Integer = 0 To palette.Length - 1
                  Dim val As Byte = CByte((i * 256) / colors)
                  palette(i) = New RasterColor(val, val, val)
               Next

               e.SetPalette(palette)
            Else
               e.SetPalette(RasterPalette.Fixed(e.BitsPerPixel))
            End If
         End If
      End If
   End Sub


   Private Sub SaveRaw(fileName As String)
      Dim activeForm As ViewerForm = TryCast(ActiveMdiChild, ViewerForm)

      Dim dlg As New RawDialog(False)
      _rawdataSave.Width = activeForm.Viewer.Image.Width
      _rawdataSave.Height = activeForm.Viewer.Image.Height
      _rawdataSave.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel
      dlg.CurrentRawData = _rawdataSave
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         Dim imageInfo As New ImageInformation()
         _rawdataSave = dlg.CurrentRawData
         Try
            Using wait As New WaitCursor()
               ' Set RAW options
               _codecs.Options.Raw.Save.Pad4 = _rawdataSave.Padding
               _codecs.Options.Raw.Save.ReverseBits = _rawdataSave.ReverseBits
               _codecs.Options.Save.OptimizedPalette = False
               If _rawdataSave.Format = RasterImageFormat.Unknown Then
                  _rawdataSave.Format = RasterImageFormat.Raw
               End If

               Dim fs As FileStream = File.Create(fileName)
               Using fs
                  _codecs.Save(activeForm.Viewer.Image, fs, _rawdataSave.Offset, _rawdataSave.Format, _rawdataSave.BitsPerPixel, 1, _
                   1, 1, CodecsSavePageMode.Overwrite)
                  fs.Close()
               End Using
            End Using
         Catch ex As Exception
            MessageBox.Show("Invalid File Parameter " + ex.Message)
         End Try
      End If
   End Sub

   Private Sub _menuItemSetPixelColor_Click(sender As Object, e As EventArgs) Handles _menuItemSetPixelColor.Click
      Dim activeForm As ViewerForm = TryCast(ActiveMdiChild, ViewerForm)
      activeForm.setPixelColor()
   End Sub

   Private Sub _menuItemImage_Popup(sender As Object, e As EventArgs) Handles _menuItemImage.Popup
      _menuItemCopyImage.Enabled = Me.MdiChildren.Length > 1

      Dim activeForm As ViewerForm = TryCast(ActiveMdiChild, ViewerForm)
      _menuItemImageDeskew.Enabled = (activeForm.Viewer.Floater Is Nothing)
   End Sub

   Private Sub _menuItemEdit_Popup(sender As Object, e As EventArgs) Handles _menuItemEdit.Popup
      Dim activeForm As ViewerForm = TryCast(ActiveMdiChild, ViewerForm)

      _menuItemPaste.Enabled = RasterClipboard.IsReady

      If activeForm IsNot Nothing Then
         EnableAndVisibleMenu(_menuItemRegionCancel, activeForm.Viewer.Floater IsNot Nothing)
         EnableAndVisibleMenu(_menuItemRegionCombine, activeForm.Viewer.Floater IsNot Nothing)
      End If
   End Sub
End Class
