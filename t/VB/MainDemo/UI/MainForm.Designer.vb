Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
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
         If disposing Then
            CleanUp()
         End If
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me._mainMenu = New System.Windows.Forms.MenuStrip()
         Me._menuItemFile = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemFileOpen = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemFileSave = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemFileSep1 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemFileOpenRaw = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemFileSaveRaw = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemFileSep2 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemFileTwainSelectSource = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemFileTwainAcquire = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemFileSep3 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemFileWiaAcquire = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemFileSep4 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemFilePrint = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemFilePrintPreview = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemFileSep5 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemFileExit = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEdit = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEditCut = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEditCopy = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEditPaste = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEditSep1 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemEditCombine = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEditSep2 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemEditRegion = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEditRegionNone = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEditRegionRectangle = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEditRegionEllipse = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEditRegionFreehand = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEditRegionMagicWand = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEditCancelRegion = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPage = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPageFirst = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPagePrevious = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPageNext = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPageLast = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPageSep1 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemPageAdd = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPageDeleteCurrentPage = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemView = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewSizeMode = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewSizeModeNormal = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewSizeModeStretch = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewSizeModeFitAlways = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewSizeModeFitWidth = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewSizeModeFit = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewSizeModeSep1 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemViewSizeModeSnap = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewAlignMode = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewAlignModeHorizontal = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewAlignModeHorizontalNear = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewAlignModeHorizontalCenter = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewAlignModeHorizontalFar = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewAlignModeVertical = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewAlignModeVerticalNear = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewAlignModeVerticalCenter = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewAlignModeVerticalFar = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewZoom = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewZoomIn = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewZoomOut = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewZoomSep1 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemViewZoomNormal = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewZoomValue = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewInteractive = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewInteractiveNone = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewInteractivePan = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewInteractiveCenterAt = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewInteractiveZoomTo = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewInteractiveScale = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewInteractiveMagnifyGlass = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewInteractivePage = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewInteractiveSep1 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemViewInteractivePanWindow = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewSep1 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemViewPadding = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewPaddingFrame = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewPaddingFrameShadow = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewPaddingBorder = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewSep2 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemViewPalette = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewSep3 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemViewPaint = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewPaintIntensity = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewPaintContrast = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewPaintGamma = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemImage = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemImageFlip = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemImageFastFlipHorizontal = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemImageFastFlipVertical = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemImageFlipSep1 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemImageFlipCustom = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemImageDeskew = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemImageBlankPageDetection = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemImageColorType = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemImageRotate = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemImageRotateFast90 = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemImageRotateFast180 = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemImageRotateFast270 = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemImageRotatSep1 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemImageRotateCustom = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemImageShear = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemImageAutoTrim = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemImageTrim = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemImageSep1 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemDocument = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemDocumentSmooth = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemDocumentLineRemove = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemDocumentDotRemove = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemDocumentInvertedText = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemDocumentBorderRemove = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemDocumentHolePunchRemove = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemDocumentDespeckle = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemImageSep2 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemImageResize = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemImageInformation = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffects = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsBlur = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsBlurMotionBlur = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsBlurAntiAlias = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsBlurAverage = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsNoise = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsNoiseMedian = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsNoiseAddNoise = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsNoiseMax = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsNoiseMin = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsSharpen = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsSharpenUnsharpMask = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsSharpenSharpen = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffects3DEffects = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffects3DEffectsEmboss = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsArtistic = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsArtisticOilify = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsTexture = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsTextureUnderlay = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsPixelate = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsPixelateMosaic = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsEdge = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsEdgeDetector = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsEdgeContour = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsSpecial = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsSpecialGaussian = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsSpatial = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsSpatialSpatialFilters = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsBinary = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsBinaryBinaryFilters = New System.Windows.Forms.ToolStripMenuItem()
#If LEADTOOLS_V20_OR_LATER Then
         Me._menuItemEffectsOther = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEffectsOtherWienerFilter = New System.Windows.Forms.ToolStripMenuItem()
#End If
         Me._menuItemColor = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorAutoBinarize = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorInvert = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorGrayScale = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorWindowLevel = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorIntensityDetect = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorSolarize = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorPosterize = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorSep1 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemColorAdjust = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorAdjustBrightness = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorAdjustContrast = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorAdjustHue = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorAdjustSaturation = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorAdjustGammaCorrect = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorAdjustBalanceColors = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorAdjustTemperature = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorTransform = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorTransformHalftone = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorTransformColorResolution = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorTransformGrayScaleFactor = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorSwapColorOrder = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorHistogram = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorHistogramEqualize = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorHistogramStretchIntensity = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorHistogramContrast = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorMatchHistogram = New System.Windows.Forms.ToolStripMenuItem
         Me._menuItemColorSep2 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemColorFill = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorSeparation = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorSeparationRGB = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorSeparationCMYK = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorSeparationHSV = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorSeparationHLS = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorSeparationCMY = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorSeparationAlpha = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorSep3 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemColorUniqueColors = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorSep4 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemColorSwapColors = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemSegmentation = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemSegmentationGWire = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemSegmentationKmeans = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemSegmentationOtsu = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemSegmentationLambda = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemSegmentationLevelset = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemSegmentationShrinkWrap = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemSegmentationTAD = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemSegmentationSRAD = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemSegmentationWatershed = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemDetection = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemGlareDetection = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemSignalToNoiseRatio = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemColorBlurDetection = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemTextBlurDetector = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemMICRDetection = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemMRZDetection = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPreferences = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPreferencesProgressBar = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPreferencesLoadTextFile = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPreferencesPaintProperties = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPreferencesAnimateRegions = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPreferencesUseDpi = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPreferencesLoadCompressed = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemSupportVectorFiles = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemLoadingCorruptedImages = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPreferencesLoadMultithreaded = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemWindow = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemWindowCascade = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemWindowTileHorizontally = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemWindowTileVertically = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemWindowArrangeIcons = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemWindowCloseAll = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemHelp = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemPreferVector = New System.Windows.Forms.ToolStripMenuItem()
         Me._mainMenu.SuspendLayout()
         Me.SuspendLayout()
         '
         '_mainMenu
         '
         Me._mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemFile, Me._menuItemEdit, Me._menuItemPage, Me._menuItemView, Me._menuItemImage, Me._menuItemEffects, Me._menuItemColor, Me._menuItemSegmentation, Me._menuItemDetection, Me._menuItemPreferences, Me._menuItemWindow, Me._menuItemHelp})
         resources.ApplyResources(Me._mainMenu, "_mainMenu")
         Me._mainMenu.Name = "_mainMenu"
         Me._mainMenu.Stretch = False
         '
         '_menuItemFile
         '
         Me._menuItemFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemFileOpen, Me._menuItemFileSave, Me._menuItemFileSep1, Me._menuItemFileOpenRaw, Me._menuItemFileSaveRaw, Me._menuItemFileSep2, Me._menuItemFileTwainSelectSource, Me._menuItemFileTwainAcquire, Me._menuItemFileSep3, Me._menuItemFileWiaAcquire, Me._menuItemFileSep4, Me._menuItemFilePrint, Me._menuItemFilePrintPreview, Me._menuItemFileSep5, Me._menuItemFileExit})
         Me._menuItemFile.Name = "_menuItemFile"
         resources.ApplyResources(Me._menuItemFile, "_menuItemFile")
         '
         '_menuItemFileOpen
         '
         Me._menuItemFileOpen.Name = "_menuItemFileOpen"
         resources.ApplyResources(Me._menuItemFileOpen, "_menuItemFileOpen")
         '
         '_menuItemFileSave
         '
         Me._menuItemFileSave.Name = "_menuItemFileSave"
         resources.ApplyResources(Me._menuItemFileSave, "_menuItemFileSave")
         '
         '_menuItemFileSep1
         '
         Me._menuItemFileSep1.Name = "_menuItemFileSep1"
         resources.ApplyResources(Me._menuItemFileSep1, "_menuItemFileSep1")
         '
         '_menuItemFileOpenRaw
         '
         Me._menuItemFileOpenRaw.Name = "_menuItemFileOpenRaw"
         resources.ApplyResources(Me._menuItemFileOpenRaw, "_menuItemFileOpenRaw")
         '
         '_menuItemFileSaveRaw
         '
         Me._menuItemFileSaveRaw.Name = "_menuItemFileSaveRaw"
         resources.ApplyResources(Me._menuItemFileSaveRaw, "_menuItemFileSaveRaw")
         '
         '_menuItemFileSep2
         '
         Me._menuItemFileSep2.Name = "_menuItemFileSep2"
         resources.ApplyResources(Me._menuItemFileSep2, "_menuItemFileSep2")
         '
         '_menuItemFileTwainSelectSource
         '
         Me._menuItemFileTwainSelectSource.Name = "_menuItemFileTwainSelectSource"
         resources.ApplyResources(Me._menuItemFileTwainSelectSource, "_menuItemFileTwainSelectSource")
         '
         '_menuItemFileTwainAcquire
         '
         Me._menuItemFileTwainAcquire.Name = "_menuItemFileTwainAcquire"
         resources.ApplyResources(Me._menuItemFileTwainAcquire, "_menuItemFileTwainAcquire")
         '
         '_menuItemFileSep3
         '
         Me._menuItemFileSep3.Name = "_menuItemFileSep3"
         resources.ApplyResources(Me._menuItemFileSep3, "_menuItemFileSep3")
         '
         '_menuItemFileWiaAcquire
         '
         Me._menuItemFileWiaAcquire.Name = "_menuItemFileWiaAcquire"
         resources.ApplyResources(Me._menuItemFileWiaAcquire, "_menuItemFileWiaAcquire")
         '
         '_menuItemFileSep4
         '
         Me._menuItemFileSep4.Name = "_menuItemFileSep4"
         resources.ApplyResources(Me._menuItemFileSep4, "_menuItemFileSep4")
         '
         '_menuItemFilePrint
         '
         Me._menuItemFilePrint.Name = "_menuItemFilePrint"
         resources.ApplyResources(Me._menuItemFilePrint, "_menuItemFilePrint")
         '
         '_menuItemFilePrintPreview
         '
         Me._menuItemFilePrintPreview.Name = "_menuItemFilePrintPreview"
         resources.ApplyResources(Me._menuItemFilePrintPreview, "_menuItemFilePrintPreview")
         '
         '_menuItemFileSep5
         '
         Me._menuItemFileSep5.Name = "_menuItemFileSep5"
         resources.ApplyResources(Me._menuItemFileSep5, "_menuItemFileSep5")
         '
         '_menuItemFileExit
         '
         Me._menuItemFileExit.Name = "_menuItemFileExit"
         resources.ApplyResources(Me._menuItemFileExit, "_menuItemFileExit")
         '
         '_menuItemEdit
         '
         Me._menuItemEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemEditCut, Me._menuItemEditCopy, Me._menuItemEditPaste, Me._menuItemEditSep1, Me._menuItemEditCombine, Me._menuItemEditSep2, Me._menuItemEditRegion, Me._menuItemEditCancelRegion})
         Me._menuItemEdit.Name = "_menuItemEdit"
         resources.ApplyResources(Me._menuItemEdit, "_menuItemEdit")
         '
         '_menuItemEditCut
         '
         Me._menuItemEditCut.Name = "_menuItemEditCut"
         resources.ApplyResources(Me._menuItemEditCut, "_menuItemEditCut")
         '
         '_menuItemEditCopy
         '
         Me._menuItemEditCopy.Name = "_menuItemEditCopy"
         resources.ApplyResources(Me._menuItemEditCopy, "_menuItemEditCopy")
         '
         '_menuItemEditPaste
         '
         Me._menuItemEditPaste.Name = "_menuItemEditPaste"
         resources.ApplyResources(Me._menuItemEditPaste, "_menuItemEditPaste")
         '
         '_menuItemEditSep1
         '
         Me._menuItemEditSep1.Name = "_menuItemEditSep1"
         resources.ApplyResources(Me._menuItemEditSep1, "_menuItemEditSep1")
         '
         '_menuItemEditCombine
         '
         Me._menuItemEditCombine.Name = "_menuItemEditCombine"
         resources.ApplyResources(Me._menuItemEditCombine, "_menuItemEditCombine")
         '
         '_menuItemEditSep2
         '
         Me._menuItemEditSep2.Name = "_menuItemEditSep2"
         resources.ApplyResources(Me._menuItemEditSep2, "_menuItemEditSep2")
         '
         '_menuItemEditRegion
         '
         Me._menuItemEditRegion.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemEditRegionNone, Me._menuItemEditRegionRectangle, Me._menuItemEditRegionEllipse, Me._menuItemEditRegionFreehand, Me._menuItemEditRegionMagicWand})
         Me._menuItemEditRegion.Name = "_menuItemEditRegion"
         resources.ApplyResources(Me._menuItemEditRegion, "_menuItemEditRegion")
         '
         '_menuItemEditRegionNone
         '
         Me._menuItemEditRegionNone.Name = "_menuItemEditRegionNone"
         resources.ApplyResources(Me._menuItemEditRegionNone, "_menuItemEditRegionNone")
         '
         '_menuItemEditRegionRectangle
         '
         Me._menuItemEditRegionRectangle.Name = "_menuItemEditRegionRectangle"
         resources.ApplyResources(Me._menuItemEditRegionRectangle, "_menuItemEditRegionRectangle")
         '
         '_menuItemEditRegionEllipse
         '
         Me._menuItemEditRegionEllipse.Name = "_menuItemEditRegionEllipse"
         resources.ApplyResources(Me._menuItemEditRegionEllipse, "_menuItemEditRegionEllipse")
         '
         '_menuItemEditRegionFreehand
         '
         Me._menuItemEditRegionFreehand.Name = "_menuItemEditRegionFreehand"
         resources.ApplyResources(Me._menuItemEditRegionFreehand, "_menuItemEditRegionFreehand")
         '
         '_menuItemEditRegionMagicWand
         '
         Me._menuItemEditRegionMagicWand.Name = "_menuItemEditRegionMagicWand"
         resources.ApplyResources(Me._menuItemEditRegionMagicWand, "_menuItemEditRegionMagicWand")
         '
         '_menuItemEditCancelRegion
         '
         Me._menuItemEditCancelRegion.Name = "_menuItemEditCancelRegion"
         resources.ApplyResources(Me._menuItemEditCancelRegion, "_menuItemEditCancelRegion")
         '
         '_menuItemPage
         '
         Me._menuItemPage.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemPageFirst, Me._menuItemPagePrevious, Me._menuItemPageNext, Me._menuItemPageLast, Me._menuItemPageSep1, Me._menuItemPageAdd, Me._menuItemPageDeleteCurrentPage})
         Me._menuItemPage.Name = "_menuItemPage"
         resources.ApplyResources(Me._menuItemPage, "_menuItemPage")
         '
         '_menuItemPageFirst
         '
         Me._menuItemPageFirst.Name = "_menuItemPageFirst"
         resources.ApplyResources(Me._menuItemPageFirst, "_menuItemPageFirst")
         '
         '_menuItemPagePrevious
         '
         Me._menuItemPagePrevious.Name = "_menuItemPagePrevious"
         resources.ApplyResources(Me._menuItemPagePrevious, "_menuItemPagePrevious")
         '
         '_menuItemPageNext
         '
         Me._menuItemPageNext.Name = "_menuItemPageNext"
         resources.ApplyResources(Me._menuItemPageNext, "_menuItemPageNext")
         '
         '_menuItemPageLast
         '
         Me._menuItemPageLast.Name = "_menuItemPageLast"
         resources.ApplyResources(Me._menuItemPageLast, "_menuItemPageLast")
         '
         '_menuItemPageSep1
         '
         Me._menuItemPageSep1.Name = "_menuItemPageSep1"
         resources.ApplyResources(Me._menuItemPageSep1, "_menuItemPageSep1")
         '
         '_menuItemPageAdd
         '
         Me._menuItemPageAdd.Name = "_menuItemPageAdd"
         resources.ApplyResources(Me._menuItemPageAdd, "_menuItemPageAdd")
         '
         '_menuItemPageDeleteCurrentPage
         '
         Me._menuItemPageDeleteCurrentPage.Name = "_menuItemPageDeleteCurrentPage"
         resources.ApplyResources(Me._menuItemPageDeleteCurrentPage, "_menuItemPageDeleteCurrentPage")
         '
         '_menuItemView
         '
         Me._menuItemView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemViewSizeMode, Me._menuItemViewAlignMode, Me._menuItemViewZoom, Me._menuItemViewInteractive, Me._menuItemViewSep1, Me._menuItemViewPadding, Me._menuItemViewSep2, Me._menuItemViewPalette, Me._menuItemViewSep3, Me._menuItemViewPaint})
         Me._menuItemView.Name = "_menuItemView"
         resources.ApplyResources(Me._menuItemView, "_menuItemView")
         '
         '_menuItemViewSizeMode
         '
         Me._menuItemViewSizeMode.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemViewSizeModeNormal, Me._menuItemViewSizeModeStretch, Me._menuItemViewSizeModeFitAlways, Me._menuItemViewSizeModeFitWidth, Me._menuItemViewSizeModeFit, Me._menuItemViewSizeModeSep1, Me._menuItemViewSizeModeSnap})
         Me._menuItemViewSizeMode.Name = "_menuItemViewSizeMode"
         resources.ApplyResources(Me._menuItemViewSizeMode, "_menuItemViewSizeMode")
         '
         '_menuItemViewSizeModeNormal
         '
         Me._menuItemViewSizeModeNormal.Name = "_menuItemViewSizeModeNormal"
         resources.ApplyResources(Me._menuItemViewSizeModeNormal, "_menuItemViewSizeModeNormal")
         '
         '_menuItemViewSizeModeStretch
         '
         Me._menuItemViewSizeModeStretch.Name = "_menuItemViewSizeModeStretch"
         resources.ApplyResources(Me._menuItemViewSizeModeStretch, "_menuItemViewSizeModeStretch")
         '
         '_menuItemViewSizeModeFitAlways
         '
         Me._menuItemViewSizeModeFitAlways.Name = "_menuItemViewSizeModeFitAlways"
         resources.ApplyResources(Me._menuItemViewSizeModeFitAlways, "_menuItemViewSizeModeFitAlways")
         '
         '_menuItemViewSizeModeFitWidth
         '
         Me._menuItemViewSizeModeFitWidth.Name = "_menuItemViewSizeModeFitWidth"
         resources.ApplyResources(Me._menuItemViewSizeModeFitWidth, "_menuItemViewSizeModeFitWidth")
         '
         '_menuItemViewSizeModeFit
         '
         Me._menuItemViewSizeModeFit.Name = "_menuItemViewSizeModeFit"
         resources.ApplyResources(Me._menuItemViewSizeModeFit, "_menuItemViewSizeModeFit")
         '
         '_menuItemViewSizeModeSep1
         '
         Me._menuItemViewSizeModeSep1.Name = "_menuItemViewSizeModeSep1"
         resources.ApplyResources(Me._menuItemViewSizeModeSep1, "_menuItemViewSizeModeSep1")
         '
         '_menuItemViewSizeModeSnap
         '
         Me._menuItemViewSizeModeSnap.Name = "_menuItemViewSizeModeSnap"
         resources.ApplyResources(Me._menuItemViewSizeModeSnap, "_menuItemViewSizeModeSnap")
         '
         '_menuItemViewAlignMode
         '
         Me._menuItemViewAlignMode.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemViewAlignModeHorizontal, Me._menuItemViewAlignModeVertical})
         Me._menuItemViewAlignMode.Name = "_menuItemViewAlignMode"
         resources.ApplyResources(Me._menuItemViewAlignMode, "_menuItemViewAlignMode")
         '
         '_menuItemViewAlignModeHorizontal
         '
         Me._menuItemViewAlignModeHorizontal.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemViewAlignModeHorizontalNear, Me._menuItemViewAlignModeHorizontalCenter, Me._menuItemViewAlignModeHorizontalFar})
         Me._menuItemViewAlignModeHorizontal.Name = "_menuItemViewAlignModeHorizontal"
         resources.ApplyResources(Me._menuItemViewAlignModeHorizontal, "_menuItemViewAlignModeHorizontal")
         '
         '_menuItemViewAlignModeHorizontalNear
         '
         Me._menuItemViewAlignModeHorizontalNear.Name = "_menuItemViewAlignModeHorizontalNear"
         resources.ApplyResources(Me._menuItemViewAlignModeHorizontalNear, "_menuItemViewAlignModeHorizontalNear")
         '
         '_menuItemViewAlignModeHorizontalCenter
         '
         Me._menuItemViewAlignModeHorizontalCenter.Name = "_menuItemViewAlignModeHorizontalCenter"
         resources.ApplyResources(Me._menuItemViewAlignModeHorizontalCenter, "_menuItemViewAlignModeHorizontalCenter")
         '
         '_menuItemViewAlignModeHorizontalFar
         '
         Me._menuItemViewAlignModeHorizontalFar.Name = "_menuItemViewAlignModeHorizontalFar"
         resources.ApplyResources(Me._menuItemViewAlignModeHorizontalFar, "_menuItemViewAlignModeHorizontalFar")
         '
         '_menuItemViewAlignModeVertical
         '
         Me._menuItemViewAlignModeVertical.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemViewAlignModeVerticalNear, Me._menuItemViewAlignModeVerticalCenter, Me._menuItemViewAlignModeVerticalFar})
         Me._menuItemViewAlignModeVertical.Name = "_menuItemViewAlignModeVertical"
         resources.ApplyResources(Me._menuItemViewAlignModeVertical, "_menuItemViewAlignModeVertical")
         '
         '_menuItemViewAlignModeVerticalNear
         '
         Me._menuItemViewAlignModeVerticalNear.Name = "_menuItemViewAlignModeVerticalNear"
         resources.ApplyResources(Me._menuItemViewAlignModeVerticalNear, "_menuItemViewAlignModeVerticalNear")
         '
         '_menuItemViewAlignModeVerticalCenter
         '
         Me._menuItemViewAlignModeVerticalCenter.Name = "_menuItemViewAlignModeVerticalCenter"
         resources.ApplyResources(Me._menuItemViewAlignModeVerticalCenter, "_menuItemViewAlignModeVerticalCenter")
         '
         '_menuItemViewAlignModeVerticalFar
         '
         Me._menuItemViewAlignModeVerticalFar.Name = "_menuItemViewAlignModeVerticalFar"
         resources.ApplyResources(Me._menuItemViewAlignModeVerticalFar, "_menuItemViewAlignModeVerticalFar")
         '
         '_menuItemViewZoom
         '
         Me._menuItemViewZoom.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemViewZoomIn, Me._menuItemViewZoomOut, Me._menuItemViewZoomSep1, Me._menuItemViewZoomNormal, Me._menuItemViewZoomValue})
         Me._menuItemViewZoom.Name = "_menuItemViewZoom"
         resources.ApplyResources(Me._menuItemViewZoom, "_menuItemViewZoom")
         '
         '_menuItemViewZoomIn
         '
         Me._menuItemViewZoomIn.Name = "_menuItemViewZoomIn"
         resources.ApplyResources(Me._menuItemViewZoomIn, "_menuItemViewZoomIn")
         '
         '_menuItemViewZoomOut
         '
         Me._menuItemViewZoomOut.Name = "_menuItemViewZoomOut"
         resources.ApplyResources(Me._menuItemViewZoomOut, "_menuItemViewZoomOut")
         '
         '_menuItemViewZoomSep1
         '
         Me._menuItemViewZoomSep1.Name = "_menuItemViewZoomSep1"
         resources.ApplyResources(Me._menuItemViewZoomSep1, "_menuItemViewZoomSep1")
         '
         '_menuItemViewZoomNormal
         '
         Me._menuItemViewZoomNormal.Name = "_menuItemViewZoomNormal"
         resources.ApplyResources(Me._menuItemViewZoomNormal, "_menuItemViewZoomNormal")
         '
         '_menuItemViewZoomValue
         '
         Me._menuItemViewZoomValue.Name = "_menuItemViewZoomValue"
         resources.ApplyResources(Me._menuItemViewZoomValue, "_menuItemViewZoomValue")
         '
         '_menuItemViewInteractive
         '
         Me._menuItemViewInteractive.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemViewInteractiveNone, Me._menuItemViewInteractivePan, Me._menuItemViewInteractiveCenterAt, Me._menuItemViewInteractiveZoomTo, Me._menuItemViewInteractiveScale, Me._menuItemViewInteractiveMagnifyGlass, Me._menuItemViewInteractivePage, Me._menuItemViewInteractiveSep1, Me._menuItemViewInteractivePanWindow})
         Me._menuItemViewInteractive.Name = "_menuItemViewInteractive"
         resources.ApplyResources(Me._menuItemViewInteractive, "_menuItemViewInteractive")
         '
         '_menuItemViewInteractiveNone
         '
         Me._menuItemViewInteractiveNone.Name = "_menuItemViewInteractiveNone"
         resources.ApplyResources(Me._menuItemViewInteractiveNone, "_menuItemViewInteractiveNone")
         '
         '_menuItemViewInteractivePan
         '
         Me._menuItemViewInteractivePan.Name = "_menuItemViewInteractivePan"
         resources.ApplyResources(Me._menuItemViewInteractivePan, "_menuItemViewInteractivePan")
         '
         '_menuItemViewInteractiveCenterAt
         '
         Me._menuItemViewInteractiveCenterAt.Name = "_menuItemViewInteractiveCenterAt"
         resources.ApplyResources(Me._menuItemViewInteractiveCenterAt, "_menuItemViewInteractiveCenterAt")
         '
         '_menuItemViewInteractiveZoomTo
         '
         Me._menuItemViewInteractiveZoomTo.Name = "_menuItemViewInteractiveZoomTo"
         resources.ApplyResources(Me._menuItemViewInteractiveZoomTo, "_menuItemViewInteractiveZoomTo")
         '
         '_menuItemViewInteractiveScale
         '
         Me._menuItemViewInteractiveScale.Name = "_menuItemViewInteractiveScale"
         resources.ApplyResources(Me._menuItemViewInteractiveScale, "_menuItemViewInteractiveScale")
         '
         '_menuItemViewInteractiveMagnifyGlass
         '
         Me._menuItemViewInteractiveMagnifyGlass.Name = "_menuItemViewInteractiveMagnifyGlass"
         resources.ApplyResources(Me._menuItemViewInteractiveMagnifyGlass, "_menuItemViewInteractiveMagnifyGlass")
         '
         '_menuItemViewInteractivePage
         '
         Me._menuItemViewInteractivePage.Name = "_menuItemViewInteractivePage"
         resources.ApplyResources(Me._menuItemViewInteractivePage, "_menuItemViewInteractivePage")
         '
         '_menuItemViewInteractiveSep1
         '
         Me._menuItemViewInteractiveSep1.Name = "_menuItemViewInteractiveSep1"
         resources.ApplyResources(Me._menuItemViewInteractiveSep1, "_menuItemViewInteractiveSep1")
         '
         '_menuItemViewInteractivePanWindow
         '
         Me._menuItemViewInteractivePanWindow.Name = "_menuItemViewInteractivePanWindow"
         resources.ApplyResources(Me._menuItemViewInteractivePanWindow, "_menuItemViewInteractivePanWindow")
         '
         '_menuItemViewSep1
         '
         Me._menuItemViewSep1.Name = "_menuItemViewSep1"
         resources.ApplyResources(Me._menuItemViewSep1, "_menuItemViewSep1")
         '
         '_menuItemViewPadding
         '
         Me._menuItemViewPadding.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemViewPaddingFrame, Me._menuItemViewPaddingFrameShadow, Me._menuItemViewPaddingBorder})
         Me._menuItemViewPadding.Name = "_menuItemViewPadding"
         resources.ApplyResources(Me._menuItemViewPadding, "_menuItemViewPadding")
         '
         '_menuItemViewPaddingFrame
         '
         Me._menuItemViewPaddingFrame.Name = "_menuItemViewPaddingFrame"
         resources.ApplyResources(Me._menuItemViewPaddingFrame, "_menuItemViewPaddingFrame")
         '
         '_menuItemViewPaddingFrameShadow
         '
         Me._menuItemViewPaddingFrameShadow.Name = "_menuItemViewPaddingFrameShadow"
         resources.ApplyResources(Me._menuItemViewPaddingFrameShadow, "_menuItemViewPaddingFrameShadow")
         '
         '_menuItemViewPaddingBorder
         '
         Me._menuItemViewPaddingBorder.Name = "_menuItemViewPaddingBorder"
         resources.ApplyResources(Me._menuItemViewPaddingBorder, "_menuItemViewPaddingBorder")
         '
         '_menuItemViewSep2
         '
         Me._menuItemViewSep2.Name = "_menuItemViewSep2"
         resources.ApplyResources(Me._menuItemViewSep2, "_menuItemViewSep2")
         '
         '_menuItemViewPalette
         '
         Me._menuItemViewPalette.Name = "_menuItemViewPalette"
         resources.ApplyResources(Me._menuItemViewPalette, "_menuItemViewPalette")
         '
         '_menuItemViewSep3
         '
         Me._menuItemViewSep3.Name = "_menuItemViewSep3"
         resources.ApplyResources(Me._menuItemViewSep3, "_menuItemViewSep3")
         '
         '_menuItemViewPaint
         '
         Me._menuItemViewPaint.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemViewPaintIntensity, Me._menuItemViewPaintContrast, Me._menuItemViewPaintGamma})
         Me._menuItemViewPaint.Name = "_menuItemViewPaint"
         resources.ApplyResources(Me._menuItemViewPaint, "_menuItemViewPaint")
         '
         '_menuItemViewPaintIntensity
         '
         Me._menuItemViewPaintIntensity.Name = "_menuItemViewPaintIntensity"
         resources.ApplyResources(Me._menuItemViewPaintIntensity, "_menuItemViewPaintIntensity")
         '
         '_menuItemViewPaintContrast
         '
         Me._menuItemViewPaintContrast.Name = "_menuItemViewPaintContrast"
         resources.ApplyResources(Me._menuItemViewPaintContrast, "_menuItemViewPaintContrast")
         '
         '_menuItemViewPaintGamma
         '
         Me._menuItemViewPaintGamma.Name = "_menuItemViewPaintGamma"
         resources.ApplyResources(Me._menuItemViewPaintGamma, "_menuItemViewPaintGamma")
         '
         '_menuItemImage
         '
         Me._menuItemImage.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemImageFlip, Me._menuItemImageDeskew, Me._menuItemImageBlankPageDetection, Me._menuItemImageColorType, Me._menuItemImageRotate, Me._menuItemImageShear, Me._menuItemImageAutoTrim, Me._menuItemImageTrim, Me._menuItemImageSep1, Me._menuItemDocument, Me._menuItemImageSep2, Me._menuItemImageResize, Me.toolStripSeparator3, Me._menuItemImageInformation})
         Me._menuItemImage.Name = "_menuItemImage"
         resources.ApplyResources(Me._menuItemImage, "_menuItemImage")
         '
         '_menuItemImageFlip
         '
         Me._menuItemImageFlip.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemImageFastFlipHorizontal, Me._menuItemImageFastFlipVertical, Me._menuItemImageFlipSep1, Me._menuItemImageFlipCustom})
         Me._menuItemImageFlip.Name = "_menuItemImageFlip"
         resources.ApplyResources(Me._menuItemImageFlip, "_menuItemImageFlip")
         '
         '_menuItemImageFastFlipHorizontal
         '
         Me._menuItemImageFastFlipHorizontal.Name = "_menuItemImageFastFlipHorizontal"
         resources.ApplyResources(Me._menuItemImageFastFlipHorizontal, "_menuItemImageFastFlipHorizontal")
         '
         '_menuItemImageFastFlipVertical
         '
         Me._menuItemImageFastFlipVertical.Name = "_menuItemImageFastFlipVertical"
         resources.ApplyResources(Me._menuItemImageFastFlipVertical, "_menuItemImageFastFlipVertical")
         '
         '_menuItemImageFlipSep1
         '
         Me._menuItemImageFlipSep1.Name = "_menuItemImageFlipSep1"
         resources.ApplyResources(Me._menuItemImageFlipSep1, "_menuItemImageFlipSep1")
         '
         '_menuItemImageFlipCustom
         '
         Me._menuItemImageFlipCustom.Name = "_menuItemImageFlipCustom"
         resources.ApplyResources(Me._menuItemImageFlipCustom, "_menuItemImageFlipCustom")
         '
         '_menuItemImageDeskew
         '
         Me._menuItemImageDeskew.Name = "_menuItemImageDeskew"
         resources.ApplyResources(Me._menuItemImageDeskew, "_menuItemImageDeskew")
         '
         '_menuItemImageBlankPageDetection
         '
         Me._menuItemImageBlankPageDetection.Name = "_menuItemImageBlankPageDetection"
         resources.ApplyResources(Me._menuItemImageBlankPageDetection, "_menuItemImageBlankPageDetection")
         '
         '_menuItemImageColorType
         '
         Me._menuItemImageColorType.Name = "_menuItemImageColorType"
         resources.ApplyResources(Me._menuItemImageColorType, "_menuItemImageColorType")
         '
         '_menuItemImageRotate
         '
         Me._menuItemImageRotate.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemImageRotateFast90, Me._menuItemImageRotateFast180, Me._menuItemImageRotateFast270, Me._menuItemImageRotatSep1, Me._menuItemImageRotateCustom})
         Me._menuItemImageRotate.Name = "_menuItemImageRotate"
         resources.ApplyResources(Me._menuItemImageRotate, "_menuItemImageRotate")
         '
         '_menuItemImageRotateFast90
         '
         Me._menuItemImageRotateFast90.Name = "_menuItemImageRotateFast90"
         resources.ApplyResources(Me._menuItemImageRotateFast90, "_menuItemImageRotateFast90")
         '
         '_menuItemImageRotateFast180
         '
         Me._menuItemImageRotateFast180.Name = "_menuItemImageRotateFast180"
         resources.ApplyResources(Me._menuItemImageRotateFast180, "_menuItemImageRotateFast180")
         '
         '_menuItemImageRotateFast270
         '
         Me._menuItemImageRotateFast270.Name = "_menuItemImageRotateFast270"
         resources.ApplyResources(Me._menuItemImageRotateFast270, "_menuItemImageRotateFast270")
         '
         '_menuItemImageRotatSep1
         '
         Me._menuItemImageRotatSep1.Name = "_menuItemImageRotatSep1"
         resources.ApplyResources(Me._menuItemImageRotatSep1, "_menuItemImageRotatSep1")
         '
         '_menuItemImageRotateCustom
         '
         Me._menuItemImageRotateCustom.Name = "_menuItemImageRotateCustom"
         resources.ApplyResources(Me._menuItemImageRotateCustom, "_menuItemImageRotateCustom")
         '
         '_menuItemImageShear
         '
         Me._menuItemImageShear.Name = "_menuItemImageShear"
         resources.ApplyResources(Me._menuItemImageShear, "_menuItemImageShear")
         '
         '_menuItemImageAutoTrim
         '
         Me._menuItemImageAutoTrim.Name = "_menuItemImageAutoTrim"
         resources.ApplyResources(Me._menuItemImageAutoTrim, "_menuItemImageAutoTrim")
         '
         '_menuItemImageTrim
         '
         Me._menuItemImageTrim.Name = "_menuItemImageTrim"
         resources.ApplyResources(Me._menuItemImageTrim, "_menuItemImageTrim")
         '
         '_menuItemImageSep1
         '
         Me._menuItemImageSep1.Name = "_menuItemImageSep1"
         resources.ApplyResources(Me._menuItemImageSep1, "_menuItemImageSep1")
         '
         '_menuItemDocument
         '
         Me._menuItemDocument.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemDocumentSmooth, Me._menuItemDocumentLineRemove, Me._menuItemDocumentDotRemove, Me._menuItemDocumentInvertedText, Me._menuItemDocumentBorderRemove, Me._menuItemDocumentHolePunchRemove, Me._menuItemDocumentDespeckle})
         Me._menuItemDocument.Name = "_menuItemDocument"
         resources.ApplyResources(Me._menuItemDocument, "_menuItemDocument")
         '
         '_menuItemDocumentSmooth
         '
         Me._menuItemDocumentSmooth.Name = "_menuItemDocumentSmooth"
         resources.ApplyResources(Me._menuItemDocumentSmooth, "_menuItemDocumentSmooth")
         '
         '_menuItemDocumentLineRemove
         '
         Me._menuItemDocumentLineRemove.Name = "_menuItemDocumentLineRemove"
         resources.ApplyResources(Me._menuItemDocumentLineRemove, "_menuItemDocumentLineRemove")
         '
         '_menuItemDocumentDotRemove
         '
         Me._menuItemDocumentDotRemove.Name = "_menuItemDocumentDotRemove"
         resources.ApplyResources(Me._menuItemDocumentDotRemove, "_menuItemDocumentDotRemove")
         '
         '_menuItemDocumentInvertedText
         '
         Me._menuItemDocumentInvertedText.Name = "_menuItemDocumentInvertedText"
         resources.ApplyResources(Me._menuItemDocumentInvertedText, "_menuItemDocumentInvertedText")
         '
         '_menuItemDocumentBorderRemove
         '
         Me._menuItemDocumentBorderRemove.Name = "_menuItemDocumentBorderRemove"
         resources.ApplyResources(Me._menuItemDocumentBorderRemove, "_menuItemDocumentBorderRemove")
         '
         '_menuItemDocumentHolePunchRemove
         '
         Me._menuItemDocumentHolePunchRemove.Name = "_menuItemDocumentHolePunchRemove"
         resources.ApplyResources(Me._menuItemDocumentHolePunchRemove, "_menuItemDocumentHolePunchRemove")
         '
         '_menuItemDocumentDespeckle
         '
         Me._menuItemDocumentDespeckle.Name = "_menuItemDocumentDespeckle"
         resources.ApplyResources(Me._menuItemDocumentDespeckle, "_menuItemDocumentDespeckle")
         '
         '_menuItemImageSep2
         '
         Me._menuItemImageSep2.Name = "_menuItemImageSep2"
         resources.ApplyResources(Me._menuItemImageSep2, "_menuItemImageSep2")
         '
         '_menuItemImageResize
         '
         Me._menuItemImageResize.Name = "_menuItemImageResize"
         resources.ApplyResources(Me._menuItemImageResize, "_menuItemImageResize")
         '
         'toolStripSeparator3
         '
         Me.toolStripSeparator3.Name = "toolStripSeparator3"
         resources.ApplyResources(Me.toolStripSeparator3, "toolStripSeparator3")
         '
         '_menuItemImageInformation
         '
         Me._menuItemImageInformation.Name = "_menuItemImageInformation"
         resources.ApplyResources(Me._menuItemImageInformation, "_menuItemImageInformation")
         '
         '_menuItemEffects
         '
#If LEADTOOLS_V20_OR_LATER Then
         Me._menuItemEffects.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemEffectsBlur, Me._menuItemEffectsNoise, Me._menuItemEffectsSharpen, Me._menuItemEffects3DEffects, Me._menuItemEffectsArtistic, Me._menuItemEffectsTexture, _
          Me._menuItemEffectsPixelate, Me._menuItemEffectsEdge, Me._menuItemEffectsSpecial, Me._menuItemEffectsSpatial, Me._menuItemEffectsBinary, Me._menuItemEffectsOther})
#Else
         Me._menuItemEffects.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemEffectsBlur, Me._menuItemEffectsNoise, Me._menuItemEffectsSharpen, Me._menuItemEffects3DEffects, Me._menuItemEffectsArtistic, Me._menuItemEffectsTexture, Me._menuItemEffectsPixelate, Me._menuItemEffectsEdge, Me._menuItemEffectsSpecial, Me._menuItemEffectsSpatial, Me._menuItemEffectsBinary})
#End If
         Me._menuItemEffects.Name = "_menuItemEffects"
         resources.ApplyResources(Me._menuItemEffects, "_menuItemEffects")
         '
         '_menuItemEffectsBlur
         '
         Me._menuItemEffectsBlur.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemEffectsBlurMotionBlur, Me._menuItemEffectsBlurAntiAlias, Me._menuItemEffectsBlurAverage})
         Me._menuItemEffectsBlur.Name = "_menuItemEffectsBlur"
         resources.ApplyResources(Me._menuItemEffectsBlur, "_menuItemEffectsBlur")
         '
         '_menuItemEffectsBlurMotionBlur
         '
         Me._menuItemEffectsBlurMotionBlur.Name = "_menuItemEffectsBlurMotionBlur"
         resources.ApplyResources(Me._menuItemEffectsBlurMotionBlur, "_menuItemEffectsBlurMotionBlur")
         '
         '_menuItemEffectsBlurAntiAlias
         '
         Me._menuItemEffectsBlurAntiAlias.Name = "_menuItemEffectsBlurAntiAlias"
         resources.ApplyResources(Me._menuItemEffectsBlurAntiAlias, "_menuItemEffectsBlurAntiAlias")
         '
         '_menuItemEffectsBlurAverage
         '
         Me._menuItemEffectsBlurAverage.Name = "_menuItemEffectsBlurAverage"
         resources.ApplyResources(Me._menuItemEffectsBlurAverage, "_menuItemEffectsBlurAverage")
         '
         '_menuItemEffectsNoise
         '
         Me._menuItemEffectsNoise.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemEffectsNoiseMedian, Me._menuItemEffectsNoiseAddNoise, Me._menuItemEffectsNoiseMax, Me._menuItemEffectsNoiseMin})
         Me._menuItemEffectsNoise.Name = "_menuItemEffectsNoise"
         resources.ApplyResources(Me._menuItemEffectsNoise, "_menuItemEffectsNoise")
         '
         '_menuItemEffectsNoiseMedian
         '
         Me._menuItemEffectsNoiseMedian.Name = "_menuItemEffectsNoiseMedian"
         resources.ApplyResources(Me._menuItemEffectsNoiseMedian, "_menuItemEffectsNoiseMedian")
         '
         '_menuItemEffectsNoiseAddNoise
         '
         Me._menuItemEffectsNoiseAddNoise.Name = "_menuItemEffectsNoiseAddNoise"
         resources.ApplyResources(Me._menuItemEffectsNoiseAddNoise, "_menuItemEffectsNoiseAddNoise")
         '
         '_menuItemEffectsNoiseMax
         '
         Me._menuItemEffectsNoiseMax.Name = "_menuItemEffectsNoiseMax"
         resources.ApplyResources(Me._menuItemEffectsNoiseMax, "_menuItemEffectsNoiseMax")
         '
         '_menuItemEffectsNoiseMin
         '
         Me._menuItemEffectsNoiseMin.Name = "_menuItemEffectsNoiseMin"
         resources.ApplyResources(Me._menuItemEffectsNoiseMin, "_menuItemEffectsNoiseMin")
         '
         '_menuItemEffectsSharpen
         '
         Me._menuItemEffectsSharpen.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemEffectsSharpenUnsharpMask, Me._menuItemEffectsSharpenSharpen})
         Me._menuItemEffectsSharpen.Name = "_menuItemEffectsSharpen"
         resources.ApplyResources(Me._menuItemEffectsSharpen, "_menuItemEffectsSharpen")
         '
         '_menuItemEffectsSharpenUnsharpMask
         '
         Me._menuItemEffectsSharpenUnsharpMask.Name = "_menuItemEffectsSharpenUnsharpMask"
         resources.ApplyResources(Me._menuItemEffectsSharpenUnsharpMask, "_menuItemEffectsSharpenUnsharpMask")
         '
         '_menuItemEffectsSharpenSharpen
         '
         Me._menuItemEffectsSharpenSharpen.Name = "_menuItemEffectsSharpenSharpen"
         resources.ApplyResources(Me._menuItemEffectsSharpenSharpen, "_menuItemEffectsSharpenSharpen")
         '
         '_menuItemEffects3DEffects
         '
         Me._menuItemEffects3DEffects.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemEffects3DEffectsEmboss})
         Me._menuItemEffects3DEffects.Name = "_menuItemEffects3DEffects"
         resources.ApplyResources(Me._menuItemEffects3DEffects, "_menuItemEffects3DEffects")
         '
         '_menuItemEffects3DEffectsEmboss
         '
         Me._menuItemEffects3DEffectsEmboss.Name = "_menuItemEffects3DEffectsEmboss"
         resources.ApplyResources(Me._menuItemEffects3DEffectsEmboss, "_menuItemEffects3DEffectsEmboss")
         '
         '_menuItemEffectsArtistic
         '
         Me._menuItemEffectsArtistic.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemEffectsArtisticOilify})
         Me._menuItemEffectsArtistic.Name = "_menuItemEffectsArtistic"
         resources.ApplyResources(Me._menuItemEffectsArtistic, "_menuItemEffectsArtistic")
         '
         '_menuItemEffectsArtisticOilify
         '
         Me._menuItemEffectsArtisticOilify.Name = "_menuItemEffectsArtisticOilify"
         resources.ApplyResources(Me._menuItemEffectsArtisticOilify, "_menuItemEffectsArtisticOilify")
         '
         '_menuItemEffectsTexture
         '
         Me._menuItemEffectsTexture.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemEffectsTextureUnderlay})
         Me._menuItemEffectsTexture.Name = "_menuItemEffectsTexture"
         resources.ApplyResources(Me._menuItemEffectsTexture, "_menuItemEffectsTexture")
         '
         '_menuItemEffectsTextureUnderlay
         '
         Me._menuItemEffectsTextureUnderlay.Name = "_menuItemEffectsTextureUnderlay"
         resources.ApplyResources(Me._menuItemEffectsTextureUnderlay, "_menuItemEffectsTextureUnderlay")
         '
         '_menuItemEffectsPixelate
         '
         Me._menuItemEffectsPixelate.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemEffectsPixelateMosaic})
         Me._menuItemEffectsPixelate.Name = "_menuItemEffectsPixelate"
         resources.ApplyResources(Me._menuItemEffectsPixelate, "_menuItemEffectsPixelate")
         '
         '_menuItemEffectsPixelateMosaic
         '
         Me._menuItemEffectsPixelateMosaic.Name = "_menuItemEffectsPixelateMosaic"
         resources.ApplyResources(Me._menuItemEffectsPixelateMosaic, "_menuItemEffectsPixelateMosaic")
         '
         '_menuItemEffectsEdge
         '
         Me._menuItemEffectsEdge.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemEffectsEdgeDetector, Me._menuItemEffectsEdgeContour})
         Me._menuItemEffectsEdge.Name = "_menuItemEffectsEdge"
         resources.ApplyResources(Me._menuItemEffectsEdge, "_menuItemEffectsEdge")
         '
         '_menuItemEffectsEdgeDetector
         '
         Me._menuItemEffectsEdgeDetector.Name = "_menuItemEffectsEdgeDetector"
         resources.ApplyResources(Me._menuItemEffectsEdgeDetector, "_menuItemEffectsEdgeDetector")
         '
         '_menuItemEffectsEdgeContour
         '
         Me._menuItemEffectsEdgeContour.Name = "_menuItemEffectsEdgeContour"
         resources.ApplyResources(Me._menuItemEffectsEdgeContour, "_menuItemEffectsEdgeContour")
         '
         '_menuItemEffectsSpecial
         '
         Me._menuItemEffectsSpecial.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemEffectsSpecialGaussian})
         Me._menuItemEffectsSpecial.Name = "_menuItemEffectsSpecial"
         resources.ApplyResources(Me._menuItemEffectsSpecial, "_menuItemEffectsSpecial")
         '
         '_menuItemEffectsSpecialGaussian
         '
         Me._menuItemEffectsSpecialGaussian.Name = "_menuItemEffectsSpecialGaussian"
         resources.ApplyResources(Me._menuItemEffectsSpecialGaussian, "_menuItemEffectsSpecialGaussian")
         '
         '_menuItemEffectsSpatial
         '
         Me._menuItemEffectsSpatial.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemEffectsSpatialSpatialFilters})
         Me._menuItemEffectsSpatial.Name = "_menuItemEffectsSpatial"
         resources.ApplyResources(Me._menuItemEffectsSpatial, "_menuItemEffectsSpatial")
         '
         '_menuItemEffectsSpatialSpatialFilters
         '
         Me._menuItemEffectsSpatialSpatialFilters.Name = "_menuItemEffectsSpatialSpatialFilters"
         resources.ApplyResources(Me._menuItemEffectsSpatialSpatialFilters, "_menuItemEffectsSpatialSpatialFilters")
         '
         '_menuItemEffectsBinary
         '
         Me._menuItemEffectsBinary.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemEffectsBinaryBinaryFilters})
         Me._menuItemEffectsBinary.Name = "_menuItemEffectsBinary"
         resources.ApplyResources(Me._menuItemEffectsBinary, "_menuItemEffectsBinary")
         '
         '_menuItemEffectsBinaryBinaryFilters
         '
         Me._menuItemEffectsBinaryBinaryFilters.Name = "_menuItemEffectsBinaryBinaryFilters"
         resources.ApplyResources(Me._menuItemEffectsBinaryBinaryFilters, "_menuItemEffectsBinaryBinaryFilters")
#If LEADTOOLS_V20_OR_LATER Then
         ' 
         ' _menuItemEffectsOther
         ' 
         Me._menuItemEffectsOther.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemEffectsOtherWienerFilter})
         Me._menuItemEffectsOther.Name = "_menuItemEffectsOther"
         resources.ApplyResources(Me._menuItemEffectsOther, "_menuItemEffectsOther")
         ' 
         ' _menuItemEffectsBinaryBinaryFilters _menuItemEffectsOtherWienerFilter
         ' 
         Me._menuItemEffectsOtherWienerFilter.Name = "_menuItemEffectsOtherWienerFilter"
         resources.ApplyResources(Me._menuItemEffectsOtherWienerFilter, "_menuItemEffectsOtherWienerFilter")
#End If
         '
         '_menuItemColor
         '
         Me._menuItemColor.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemColorAutoBinarize, Me._menuItemColorInvert, Me._menuItemColorGrayScale, Me._menuItemColorWindowLevel, Me._menuItemColorIntensityDetect, Me._menuItemColorSolarize, Me._menuItemColorPosterize, Me._menuItemColorSep1, Me._menuItemColorAdjust, Me._menuItemColorTransform, Me._menuItemColorSwapColorOrder, Me._menuItemColorHistogram, Me._menuItemColorSep2, Me._menuItemColorFill, Me._menuItemColorSeparation, Me._menuItemColorSep3, Me._menuItemColorUniqueColors, Me._menuItemColorSep4, Me._menuItemColorSwapColors})
         Me._menuItemColor.Name = "_menuItemColor"
         resources.ApplyResources(Me._menuItemColor, "_menuItemColor")
         '
         '_menuItemColorAutoBinarize
         '
         Me._menuItemColorAutoBinarize.Name = "_menuItemColorAutoBinarize"
         resources.ApplyResources(Me._menuItemColorAutoBinarize, "_menuItemColorAutoBinarize")
         '
         '_menuItemColorInvert
         '
         Me._menuItemColorInvert.Name = "_menuItemColorInvert"
         resources.ApplyResources(Me._menuItemColorInvert, "_menuItemColorInvert")
         '
         '_menuItemColorGrayScale
         '
         Me._menuItemColorGrayScale.Name = "_menuItemColorGrayScale"
         resources.ApplyResources(Me._menuItemColorGrayScale, "_menuItemColorGrayScale")
         '
         '_menuItemColorWindowLevel
         '
         resources.ApplyResources(Me._menuItemColorWindowLevel, "_menuItemColorWindowLevel")
         Me._menuItemColorWindowLevel.Name = "_menuItemColorWindowLevel"
         '
         '_menuItemColorIntensityDetect
         '
         Me._menuItemColorIntensityDetect.Name = "_menuItemColorIntensityDetect"
         resources.ApplyResources(Me._menuItemColorIntensityDetect, "_menuItemColorIntensityDetect")
         '
         '_menuItemColorSolarize
         '
         Me._menuItemColorSolarize.Name = "_menuItemColorSolarize"
         resources.ApplyResources(Me._menuItemColorSolarize, "_menuItemColorSolarize")
         '
         '_menuItemColorPosterize
         '
         Me._menuItemColorPosterize.Name = "_menuItemColorPosterize"
         resources.ApplyResources(Me._menuItemColorPosterize, "_menuItemColorPosterize")
         '
         '_menuItemColorSep1
         '
         Me._menuItemColorSep1.Name = "_menuItemColorSep1"
         resources.ApplyResources(Me._menuItemColorSep1, "_menuItemColorSep1")
         '
         '_menuItemColorAdjust
         '
         Me._menuItemColorAdjust.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemColorAdjustBrightness, Me._menuItemColorAdjustContrast, Me._menuItemColorAdjustHue, Me._menuItemColorAdjustSaturation, Me._menuItemColorAdjustGammaCorrect, Me._menuItemColorAdjustBalanceColors, Me._menuItemColorAdjustTemperature})
         Me._menuItemColorAdjust.Name = "_menuItemColorAdjust"
         resources.ApplyResources(Me._menuItemColorAdjust, "_menuItemColorAdjust")
         '
         '_menuItemColorAdjustBrightness
         '
         Me._menuItemColorAdjustBrightness.Name = "_menuItemColorAdjustBrightness"
         resources.ApplyResources(Me._menuItemColorAdjustBrightness, "_menuItemColorAdjustBrightness")
         '
         '_menuItemColorAdjustContrast
         '
         Me._menuItemColorAdjustContrast.Name = "_menuItemColorAdjustContrast"
         resources.ApplyResources(Me._menuItemColorAdjustContrast, "_menuItemColorAdjustContrast")
         '
         '_menuItemColorAdjustHue
         '
         Me._menuItemColorAdjustHue.Name = "_menuItemColorAdjustHue"
         resources.ApplyResources(Me._menuItemColorAdjustHue, "_menuItemColorAdjustHue")
         '
         '_menuItemColorAdjustSaturation
         '
         Me._menuItemColorAdjustSaturation.Name = "_menuItemColorAdjustSaturation"
         resources.ApplyResources(Me._menuItemColorAdjustSaturation, "_menuItemColorAdjustSaturation")
         '
         '_menuItemColorAdjustGammaCorrect
         '
         Me._menuItemColorAdjustGammaCorrect.Name = "_menuItemColorAdjustGammaCorrect"
         resources.ApplyResources(Me._menuItemColorAdjustGammaCorrect, "_menuItemColorAdjustGammaCorrect")
         '
         '_menuItemColorAdjustBalanceColors
         '
         Me._menuItemColorAdjustBalanceColors.Name = "_menuItemColorAdjustBalanceColors"
         resources.ApplyResources(Me._menuItemColorAdjustBalanceColors, "_menuItemColorAdjustBalanceColors")
         '
         '_menuItemColorAdjustTemperature
         '
         Me._menuItemColorAdjustTemperature.Name = "_menuItemColorAdjustTemperature"
         resources.ApplyResources(Me._menuItemColorAdjustTemperature, "_menuItemColorAdjustTemperature")
         '
         '_menuItemColorTransform
         '
         Me._menuItemColorTransform.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemColorTransformHalftone, Me._menuItemColorTransformColorResolution, Me._menuItemColorTransformGrayScaleFactor})
         Me._menuItemColorTransform.Name = "_menuItemColorTransform"
         resources.ApplyResources(Me._menuItemColorTransform, "_menuItemColorTransform")
         '
         '_menuItemColorTransformHalftone
         '
         Me._menuItemColorTransformHalftone.Name = "_menuItemColorTransformHalftone"
         resources.ApplyResources(Me._menuItemColorTransformHalftone, "_menuItemColorTransformHalftone")
         '
         '_menuItemColorTransformColorResolution
         '
         Me._menuItemColorTransformColorResolution.Name = "_menuItemColorTransformColorResolution"
         resources.ApplyResources(Me._menuItemColorTransformColorResolution, "_menuItemColorTransformColorResolution")
         '
         '_menuItemColorTransformGrayScaleFactor
         '
         Me._menuItemColorTransformGrayScaleFactor.Name = "_menuItemColorTransformGrayScaleFactor"
         resources.ApplyResources(Me._menuItemColorTransformGrayScaleFactor, "_menuItemColorTransformGrayScaleFactor")
         '
         '_menuItemColorSwapColorOrder
         '
         Me._menuItemColorSwapColorOrder.Name = "_menuItemColorSwapColorOrder"
         resources.ApplyResources(Me._menuItemColorSwapColorOrder, "_menuItemColorSwapColorOrder")
         '
         '_menuItemColorHistogram
         '
         Me._menuItemColorHistogram.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemColorHistogramEqualize, Me._menuItemColorHistogramStretchIntensity, Me._menuItemColorHistogramContrast, Me._menuItemColorMatchHistogram})
         Me._menuItemColorHistogram.Name = "_menuItemColorHistogram"
         resources.ApplyResources(Me._menuItemColorHistogram, "_menuItemColorHistogram")
         '
         '_menuItemColorHistogramEqualize
         '
         Me._menuItemColorHistogramEqualize.Name = "_menuItemColorHistogramEqualize"
         resources.ApplyResources(Me._menuItemColorHistogramEqualize, "_menuItemColorHistogramEqualize")
         '
         '_menuItemColorHistogramStretchIntensity
         '
         Me._menuItemColorHistogramStretchIntensity.Name = "_menuItemColorHistogramStretchIntensity"
         resources.ApplyResources(Me._menuItemColorHistogramStretchIntensity, "_menuItemColorHistogramStretchIntensity")
         '
         '_menuItemColorHistogramContrast
         '
         Me._menuItemColorHistogramContrast.Name = "_menuItemColorHistogramContrast"
         resources.ApplyResources(Me._menuItemColorHistogramContrast, "_menuItemColorHistogramContrast")
         '
         ' _menuItemColorMatchHistogram
         '
         Me._menuItemColorMatchHistogram.Name = "_menuItemColorMatchHistogram"
         resources.ApplyResources(Me._menuItemColorMatchHistogram, "_menuItemColorMatchHistogram")
         '
         '_menuItemColorSep2
         '
         Me._menuItemColorSep2.Name = "_menuItemColorSep2"
         resources.ApplyResources(Me._menuItemColorSep2, "_menuItemColorSep2")
         '
         '_menuItemColorFill
         '
         Me._menuItemColorFill.Name = "_menuItemColorFill"
         resources.ApplyResources(Me._menuItemColorFill, "_menuItemColorFill")
         '
         '_menuItemColorSeparation
         '
         Me._menuItemColorSeparation.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemColorSeparationRGB, Me._menuItemColorSeparationCMYK, Me._menuItemColorSeparationHSV, Me._menuItemColorSeparationHLS, Me._menuItemColorSeparationCMY, Me._menuItemColorSeparationAlpha})
         Me._menuItemColorSeparation.Name = "_menuItemColorSeparation"
         resources.ApplyResources(Me._menuItemColorSeparation, "_menuItemColorSeparation")
         '
         '_menuItemColorSeparationRGB
         '
         Me._menuItemColorSeparationRGB.Name = "_menuItemColorSeparationRGB"
         resources.ApplyResources(Me._menuItemColorSeparationRGB, "_menuItemColorSeparationRGB")
         '
         '_menuItemColorSeparationCMYK
         '
         Me._menuItemColorSeparationCMYK.Name = "_menuItemColorSeparationCMYK"
         resources.ApplyResources(Me._menuItemColorSeparationCMYK, "_menuItemColorSeparationCMYK")
         '
         '_menuItemColorSeparationHSV
         '
         Me._menuItemColorSeparationHSV.Name = "_menuItemColorSeparationHSV"
         resources.ApplyResources(Me._menuItemColorSeparationHSV, "_menuItemColorSeparationHSV")
         '
         '_menuItemColorSeparationHLS
         '
         Me._menuItemColorSeparationHLS.Name = "_menuItemColorSeparationHLS"
         resources.ApplyResources(Me._menuItemColorSeparationHLS, "_menuItemColorSeparationHLS")
         '
         '_menuItemColorSeparationCMY
         '
         Me._menuItemColorSeparationCMY.Name = "_menuItemColorSeparationCMY"
         resources.ApplyResources(Me._menuItemColorSeparationCMY, "_menuItemColorSeparationCMY")
         '
         '_menuItemColorSeparationAlpha
         '
         Me._menuItemColorSeparationAlpha.Name = "_menuItemColorSeparationAlpha"
         resources.ApplyResources(Me._menuItemColorSeparationAlpha, "_menuItemColorSeparationAlpha")
         '
         '_menuItemColorSep3
         '
         Me._menuItemColorSep3.Name = "_menuItemColorSep3"
         resources.ApplyResources(Me._menuItemColorSep3, "_menuItemColorSep3")
         '
         '_menuItemColorUniqueColors
         '
         Me._menuItemColorUniqueColors.Name = "_menuItemColorUniqueColors"
         resources.ApplyResources(Me._menuItemColorUniqueColors, "_menuItemColorUniqueColors")
         '
         '_menuItemColorSep4
         '
         Me._menuItemColorSep4.Name = "_menuItemColorSep4"
         resources.ApplyResources(Me._menuItemColorSep4, "_menuItemColorSep4")
         '
         '_menuItemColorSwapColors
         '
         Me._menuItemColorSwapColors.Name = "_menuItemColorSwapColors"
         resources.ApplyResources(Me._menuItemColorSwapColors, "_menuItemColorSwapColors")
         '
         '_menuItemSegmentation
         '
         Me._menuItemSegmentation.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemSegmentationGWire, Me._menuItemSegmentationKmeans, Me._menuItemSegmentationOtsu, Me._menuItemSegmentationLambda, Me._menuItemSegmentationLevelset, Me._menuItemSegmentationShrinkWrap, Me._menuItemSegmentationTAD, Me._menuItemSegmentationSRAD, Me._menuItemSegmentationWatershed})
         Me._menuItemSegmentation.Name = "_menuItemSegmentation"
         resources.ApplyResources(Me._menuItemSegmentation, "_menuItemSegmentation")
         '
         '_menuItemSegmentationGWire
         '
         Me._menuItemSegmentationGWire.Name = "_menuItemSegmentationGWire"
         resources.ApplyResources(Me._menuItemSegmentationGWire, "_menuItemSegmentationGWire")
         '
         '_menuItemSegmentationKmeans
         '
         Me._menuItemSegmentationKmeans.Name = "_menuItemSegmentationKmeans"
         resources.ApplyResources(Me._menuItemSegmentationKmeans, "_menuItemSegmentationKmeans")
         '
         '_menuItemSegmentationOtsu
         '
         Me._menuItemSegmentationOtsu.Name = "_menuItemSegmentationOtsu"
         resources.ApplyResources(Me._menuItemSegmentationOtsu, "_menuItemSegmentationOtsu")
         '
         '_menuItemSegmentationLambda
         '
         Me._menuItemSegmentationLambda.Name = "_menuItemSegmentationLambda"
         resources.ApplyResources(Me._menuItemSegmentationLambda, "_menuItemSegmentationLambda")
         '
         '_menuItemSegmentationLevelset
         '
         Me._menuItemSegmentationLevelset.Name = "_menuItemSegmentationLevelset"
         resources.ApplyResources(Me._menuItemSegmentationLevelset, "_menuItemSegmentationLevelset")
         '
         '_menuItemSegmentationShrinkWrap
         '
         Me._menuItemSegmentationShrinkWrap.Name = "_menuItemSegmentationShrinkWrap"
         resources.ApplyResources(Me._menuItemSegmentationShrinkWrap, "_menuItemSegmentationShrinkWrap")
         '
         '_menuItemSegmentationTAD
         '
         Me._menuItemSegmentationTAD.Name = "_menuItemSegmentationTAD"
         resources.ApplyResources(Me._menuItemSegmentationTAD, "_menuItemSegmentationTAD")
         '
         '_menuItemSegmentationSRAD
         '
         Me._menuItemSegmentationSRAD.Name = "_menuItemSegmentationSRAD"
         resources.ApplyResources(Me._menuItemSegmentationSRAD, "_menuItemSegmentationSRAD")
         '
         '_menuItemSegmentationWatershed
         '
         Me._menuItemSegmentationWatershed.Name = "_menuItemSegmentationWatershed"
         resources.ApplyResources(Me._menuItemSegmentationWatershed, "_menuItemSegmentationWatershed")
         '
         '_menuItemDetection
         '
         Me._menuItemDetection.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemGlareDetection, Me._menuItemSignalToNoiseRatio, Me._menuItemColorBlurDetection, Me._menuItemTextBlurDetector, Me._menuItemMICRDetection, Me._menuItemMRZDetection})
         Me._menuItemDetection.Name = "_menuItemDetection"
         resources.ApplyResources(Me._menuItemDetection, "_menuItemDetection")
         '
         '_menuItemGlareDetection
         '
         Me._menuItemGlareDetection.Name = "_menuItemGlareDetection"
         resources.ApplyResources(Me._menuItemGlareDetection, "_menuItemGlareDetection")
         '
         '_menuItemSignalToNoiseRatio
         '
         Me._menuItemSignalToNoiseRatio.Name = "_menuItemSignalToNoiseRatio"
         resources.ApplyResources(Me._menuItemSignalToNoiseRatio, "_menuItemSignalToNoiseRatio")
         '
         '_menuItemColorBlurDetection
         '
         Me._menuItemColorBlurDetection.Name = "_menuItemColorBlurDetection"
         resources.ApplyResources(Me._menuItemColorBlurDetection, "_menuItemColorBlurDetection")
         '
         '_menuItemTextBlurDetector
         '
         Me._menuItemTextBlurDetector.Name = "_menuItemTextBlurDetector"
         resources.ApplyResources(Me._menuItemTextBlurDetector, "_menuItemTextBlurDetector")
         '
         '_menuItemMICRDetection
         '
         Me._menuItemMICRDetection.Name = "_menuItemMICRDetection"
         resources.ApplyResources(Me._menuItemMICRDetection, "_menuItemMICRDetection")
         '
         '_menuItemMRZDetection
         '
         Me._menuItemMRZDetection.Name = "_menuItemMRZDetection"
         resources.ApplyResources(Me._menuItemMRZDetection, "_menuItemMRZDetection")
         '
         '_menuItemPreferences
         '
         Me._menuItemPreferences.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemPreferencesProgressBar, Me._menuItemPreferencesLoadTextFile, Me._menuItemPreferencesPaintProperties, Me._menuItemPreferencesAnimateRegions, Me._menuItemPreferencesUseDpi, Me._menuItemPreferencesLoadCompressed, Me._menuItemSupportVectorFiles, Me._menuItemLoadingCorruptedImages, Me._menuItemPreferencesLoadMultithreaded, Me._menuItemPreferVector})
         Me._menuItemPreferences.Name = "_menuItemPreferences"
         resources.ApplyResources(Me._menuItemPreferences, "_menuItemPreferences")
         '
         '_menuItemPreferencesProgressBar
         '
         Me._menuItemPreferencesProgressBar.Name = "_menuItemPreferencesProgressBar"
         resources.ApplyResources(Me._menuItemPreferencesProgressBar, "_menuItemPreferencesProgressBar")
         '
         '_menuItemPreferencesLoadTextFile
         '
         Me._menuItemPreferencesLoadTextFile.Name = "_menuItemPreferencesLoadTextFile"
         resources.ApplyResources(Me._menuItemPreferencesLoadTextFile, "_menuItemPreferencesLoadTextFile")
         '
         '_menuItemPreferencesPaintProperties
         '
         Me._menuItemPreferencesPaintProperties.Name = "_menuItemPreferencesPaintProperties"
         resources.ApplyResources(Me._menuItemPreferencesPaintProperties, "_menuItemPreferencesPaintProperties")
         '
         '_menuItemPreferencesAnimateRegions
         '
         Me._menuItemPreferencesAnimateRegions.Name = "_menuItemPreferencesAnimateRegions"
         resources.ApplyResources(Me._menuItemPreferencesAnimateRegions, "_menuItemPreferencesAnimateRegions")
         '
         '_menuItemPreferencesUseDpi
         '
         Me._menuItemPreferencesUseDpi.Name = "_menuItemPreferencesUseDpi"
         resources.ApplyResources(Me._menuItemPreferencesUseDpi, "_menuItemPreferencesUseDpi")
         '
         '_menuItemPreferencesLoadCompressed
         '
         Me._menuItemPreferencesLoadCompressed.Name = "_menuItemPreferencesLoadCompressed"
         resources.ApplyResources(Me._menuItemPreferencesLoadCompressed, "_menuItemPreferencesLoadCompressed")
         '
         '_menuItemSupportVectorFiles
         '
         Me._menuItemSupportVectorFiles.Name = "_menuItemSupportVectorFiles"
         resources.ApplyResources(Me._menuItemSupportVectorFiles, "_menuItemSupportVectorFiles")
         '
         '_menuItemLoadingCorruptedImages
         '
         Me._menuItemLoadingCorruptedImages.Name = "_menuItemLoadingCorruptedImages"
         resources.ApplyResources(Me._menuItemLoadingCorruptedImages, "_menuItemLoadingCorruptedImages")
         '
         '_menuItemPreferencesLoadMultithreaded
         '
         Me._menuItemPreferencesLoadMultithreaded.Name = "_menuItemPreferencesLoadMultithreaded"
         resources.ApplyResources(Me._menuItemPreferencesLoadMultithreaded, "_menuItemPreferencesLoadMultithreaded")
         '
         '_menuItemWindow
         '
         Me._menuItemWindow.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemWindowCascade, Me._menuItemWindowTileHorizontally, Me._menuItemWindowTileVertically, Me._menuItemWindowArrangeIcons, Me._menuItemWindowCloseAll})
         Me._menuItemWindow.Name = "_menuItemWindow"
         resources.ApplyResources(Me._menuItemWindow, "_menuItemWindow")
         '
         '_menuItemWindowCascade
         '
         Me._menuItemWindowCascade.Name = "_menuItemWindowCascade"
         resources.ApplyResources(Me._menuItemWindowCascade, "_menuItemWindowCascade")
         '
         '_menuItemWindowTileHorizontally
         '
         Me._menuItemWindowTileHorizontally.Name = "_menuItemWindowTileHorizontally"
         resources.ApplyResources(Me._menuItemWindowTileHorizontally, "_menuItemWindowTileHorizontally")
         '
         '_menuItemWindowTileVertically
         '
         Me._menuItemWindowTileVertically.Name = "_menuItemWindowTileVertically"
         resources.ApplyResources(Me._menuItemWindowTileVertically, "_menuItemWindowTileVertically")
         '
         '_menuItemWindowArrangeIcons
         '
         Me._menuItemWindowArrangeIcons.Name = "_menuItemWindowArrangeIcons"
         resources.ApplyResources(Me._menuItemWindowArrangeIcons, "_menuItemWindowArrangeIcons")
         '
         '_menuItemWindowCloseAll
         '
         Me._menuItemWindowCloseAll.Name = "_menuItemWindowCloseAll"
         resources.ApplyResources(Me._menuItemWindowCloseAll, "_menuItemWindowCloseAll")
         '
         '_menuItemHelp
         '
         Me._menuItemHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemHelpAbout})
         Me._menuItemHelp.Name = "_menuItemHelp"
         resources.ApplyResources(Me._menuItemHelp, "_menuItemHelp")
         '
         '_menuItemHelpAbout
         '
         Me._menuItemHelpAbout.Name = "_menuItemHelpAbout"
         resources.ApplyResources(Me._menuItemHelpAbout, "_menuItemHelpAbout")
         '
         ' _menuItemPreferVector
         ' 
         Me._menuItemPreferVector.Name = "_menuItemPreferVector"
         resources.ApplyResources(Me._menuItemPreferVector, "_menuItemPreferVector")
         ' 
         ' 
         'MainForm
         '
         Me.AllowDrop = True
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me._mainMenu)
         Me.IsMdiContainer = True
         Me.MainMenuStrip = Me._mainMenu
         Me.Name = "MainForm"
         Me._mainMenu.ResumeLayout(False)
         Me._mainMenu.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub
      Private WithEvents _mainMenu As System.Windows.Forms.MenuStrip
      Private WithEvents _menuItemFile As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemFileOpen As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemFileSave As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemFileSep1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemFileOpenRaw As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemFileSaveRaw As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemFileSep2 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemFileTwainSelectSource As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemFileTwainAcquire As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemFileSep3 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemFilePrint As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemFilePrintPreview As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemFileSep5 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemFileExit As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEdit As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEditCut As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEditCopy As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEditPaste As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEditSep1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemEditCombine As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEditSep2 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemEditRegion As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEditRegionNone As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEditRegionRectangle As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEditRegionEllipse As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEditRegionFreehand As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEditRegionMagicWand As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEditCancelRegion As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemPage As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemPageFirst As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemPagePrevious As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemPageNext As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemPageLast As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemPageSep1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemPageAdd As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemPageDeleteCurrentPage As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemView As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewSizeMode As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewSizeModeNormal As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewSizeModeStretch As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewSizeModeFitAlways As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewSizeModeFitWidth As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewSizeModeFit As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewSizeModeSep1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemViewSizeModeSnap As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewAlignMode As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewAlignModeHorizontal As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewAlignModeHorizontalNear As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewAlignModeHorizontalCenter As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewAlignModeHorizontalFar As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewAlignModeVertical As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewAlignModeVerticalNear As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewAlignModeVerticalCenter As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewAlignModeVerticalFar As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewZoom As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewZoomIn As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewZoomOut As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewZoomSep1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemViewZoomNormal As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewZoomValue As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewInteractive As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewInteractiveNone As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewInteractivePan As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewInteractiveCenterAt As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewInteractiveZoomTo As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewInteractiveScale As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewInteractiveMagnifyGlass As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewInteractivePage As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewInteractiveSep1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemViewInteractivePanWindow As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewSep1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemViewPadding As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewPaddingFrame As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewPaddingFrameShadow As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewPaddingBorder As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewSep2 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemViewPalette As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewSep3 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemViewPaint As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewPaintIntensity As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewPaintContrast As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewPaintGamma As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemImage As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemImageFlip As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemImageFastFlipHorizontal As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemImageFastFlipVertical As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemImageFlipSep1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemImageFlipCustom As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemImageDeskew As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemImageRotate As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemImageRotateFast90 As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemImageRotateFast180 As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemImageRotateFast270 As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemImageRotatSep1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemImageRotateCustom As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemImageShear As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemImageAutoTrim As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemImageTrim As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemImageSep1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemDocument As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemDocumentSmooth As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemDocumentLineRemove As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemDocumentDotRemove As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemDocumentInvertedText As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemDocumentBorderRemove As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemDocumentHolePunchRemove As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemDocumentDespeckle As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemImageSep2 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemImageResize As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemImageInformation As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffects As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsBlur As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsBlurMotionBlur As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsBlurAntiAlias As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsBlurAverage As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsNoise As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsNoiseMedian As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsNoiseAddNoise As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsNoiseMax As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsNoiseMin As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsSharpen As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsSharpenUnsharpMask As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsSharpenSharpen As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffects3DEffects As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffects3DEffectsEmboss As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsArtistic As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsArtisticOilify As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsTexture As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsTextureUnderlay As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsPixelate As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsPixelateMosaic As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsEdge As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsEdgeDetector As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsEdgeContour As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsSpecial As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsSpecialGaussian As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsSpatial As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsSpatialSpatialFilters As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsBinary As System.Windows.Forms.ToolStripMenuItem
#If LEADTOOLS_V20_OR_LATER Then
      Private _menuItemEffectsOther As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEffectsOtherWienerFilter As System.Windows.Forms.ToolStripMenuItem
#End If
      Private WithEvents _menuItemEffectsBinaryBinaryFilters As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColor As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorInvert As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorGrayScale As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorWindowLevel As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorIntensityDetect As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorSolarize As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorPosterize As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorSep1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemColorAdjust As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorAdjustBrightness As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorAdjustContrast As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorAdjustHue As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorAdjustSaturation As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorAdjustGammaCorrect As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorAdjustBalanceColors As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorTransform As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorSwapColorOrder As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorTransformHalftone As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorTransformColorResolution As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorTransformGrayScaleFactor As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorHistogram As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorHistogramEqualize As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorHistogramStretchIntensity As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorHistogramContrast As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorMatchHistogram As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorSep2 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemColorFill As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorSeparation As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorSeparationRGB As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorSeparationCMYK As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorSeparationHSV As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorSeparationHLS As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorSeparationCMY As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorSeparationAlpha As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorSep3 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemColorUniqueColors As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorSep4 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemColorSwapColors As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemPreferences As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemPreferencesProgressBar As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemPreferencesLoadTextFile As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemPreferencesPaintProperties As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemWindow As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemWindowCascade As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemWindowTileHorizontally As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemWindowTileVertically As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemWindowArrangeIcons As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemWindowCloseAll As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemHelp As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemHelpAbout As System.Windows.Forms.ToolStripMenuItem
      Friend WithEvents _menuItemPreferencesAnimateRegions As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemPreferencesUseDpi As System.Windows.Forms.ToolStripMenuItem
      Friend WithEvents _menuItemImageBlankPageDetection As System.Windows.Forms.ToolStripMenuItem
      Friend WithEvents _menuItemFileWiaAcquire As System.Windows.Forms.ToolStripMenuItem
      Friend WithEvents _menuItemFileSep4 As System.Windows.Forms.ToolStripSeparator
      Friend WithEvents _menuItemColorAutoBinarize As System.Windows.Forms.ToolStripMenuItem
      Friend WithEvents _menuItemPreferencesLoadCompressed As System.Windows.Forms.ToolStripMenuItem
      Friend WithEvents _menuItemPreferencesLoadMultithreaded As System.Windows.Forms.ToolStripMenuItem
      Friend WithEvents _menuItemImageColorType As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemSupportVectorFiles As System.Windows.Forms.ToolStripMenuItem
      Friend WithEvents _menuItemColorAdjustTemperature As System.Windows.Forms.ToolStripMenuItem
      Friend WithEvents _menuItemLoadingCorruptedImages As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemSegmentation As System.Windows.Forms.ToolStripMenuItem
      Private _menuItemDetection As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemSegmentationGWire As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemSegmentationKmeans As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemSegmentationOtsu As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemSegmentationLambda As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemSegmentationLevelset As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemSegmentationShrinkWrap As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemSegmentationTAD As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemSegmentationSRAD As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemSegmentationWatershed As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemGlareDetection As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemSignalToNoiseRatio As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemTextBlurDetector As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemMICRDetection As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemMRZDetection As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemColorBlurDetection As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemPreferVector As System.Windows.Forms.ToolStripMenuItem
#End Region

   End Class
End Namespace
