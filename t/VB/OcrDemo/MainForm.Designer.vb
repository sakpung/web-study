Namespace OcrDemo
   Partial Class MainForm
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(disposing As Boolean)
         If disposing AndAlso (components IsNot Nothing) Then
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
         Me._mainMenuStrip = New System.Windows.Forms.MenuStrip()
         Me._fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._fileOpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._fileSetPDFLoadResolutionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._fileSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._fileConvertLDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._fileSep2ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._fileScanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._scanSelectSourceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._scanAcquireToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._fileSep3ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._fileExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._editToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._editCopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._editPasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._viewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._viewZoomOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._viewZoomInToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._viewSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._viewFitWidthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._viewFitPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._engineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._engineSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._engineComponentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._engineLanguagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._pageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._pageSaveProcessingImageToDiskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._pageDetectPageLanguagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._pageSaveRecognizedDataAsXmlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._pageCloseCurrentPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processAllPagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._processFlipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processReverseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processRotate90ClockwiseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processRotate90CounterClockwiseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processSep2ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._processPreprocessToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processPreprocessGetDeskewAngleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processPreprocessGetRotateAngleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processPreprocessIsInvertedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processPreprocessSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._processPreprocessDeskewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processPreprocessRotateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processPreprocessInvertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processPreprocessAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._documentCleanupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processAutoCropToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processDespeckleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processErodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processDilateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processUnditherTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processFixBrokenLettersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processLineRemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._binarizationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processAutoBinarizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processDynamicBinarizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._brightnessToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processHisogramEqualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processAutoLevelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processContrastBrightnessIntensityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._dualPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processPageSplitterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processExpandContentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._processSep3ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._manualPerspectiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._inversePerspectiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._perspectiveDeskewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._zonesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._zonesAutoZoneDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._zonesAutoZoneCurrentPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._zonesSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._zonesUpdateZonesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._zonesSep2ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._zonesLoadZonesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._zonesSaveZonesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._zonesSep3ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._loadAllPagesZonesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._saveAllPagesZonesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._zonesSep4ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._clearAllPagesZonesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._zonesSep5ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._zonesShowZonesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._zonesShowZoneNamesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._recognizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._recognizeRecognizeDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._recognizeRecognizePageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._ocrSep2ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._recognizeSpellCheckEngineStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._recognizeOmrOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
         Me._recognizeSaveAfterRecognizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._documentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._documentCreateDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._documentLoadDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
         Me._documentAddCurrentPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._documentInsertPagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._documentRemoveCurrentPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._documentClearDocumentPagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
         Me._documentSaveRecognizedDataAsXmlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._documentSaveDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
         Me._documentCloseDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._preferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._preferencesUseProgressBarsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._helpAboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._mainToolStrip = New System.Windows.Forms.ToolStrip()
         Me._openDocumentToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
         Me._autoZoneDocumentToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._autoZonePageToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._recognizeDocumentToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._recognizePageToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._saveDocumentToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._mainStatusStrip = New System.Windows.Forms.StatusStrip()
         Me._timingDescriptionToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
         Me._timingToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
         Me._activeSpellCheckerDescriptionToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
         Me._activeSpellCheckerToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
         Me._mainSplitContainer = New System.Windows.Forms.SplitContainer()
         Me._pagesControl = New OcrDemo.PagesControl.PagesControl()
         Me._viewerVertSplitContainer = New System.Windows.Forms.SplitContainer()
         Me._viewerHorzSplitContainer = New System.Windows.Forms.SplitContainer()
         Me._viewerControl = New OcrDemo.ViewerControl.ViewerControl()
         Me._pageTextControl = New OcrDemo.PageTextControl.PageTextControl()
         Me._documentInfoControl = New OcrDemo.DocumentInfoControl.DocumentInfoControl()
         Me._unwarpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._mainMenuStrip.SuspendLayout()
         Me._mainToolStrip.SuspendLayout()
         Me._mainStatusStrip.SuspendLayout()
         '((System.ComponentModel.ISupportInitialize)(this._mainSplitContainer)).BeginInit();
         Me._mainSplitContainer.Panel1.SuspendLayout()
         Me._mainSplitContainer.Panel2.SuspendLayout()
         Me._mainSplitContainer.SuspendLayout()
         '((System.ComponentModel.ISupportInitialize)(this._viewerVertSplitContainer)).BeginInit();
         Me._viewerVertSplitContainer.Panel1.SuspendLayout()
         Me._viewerVertSplitContainer.Panel2.SuspendLayout()
         Me._viewerVertSplitContainer.SuspendLayout()
         '((System.ComponentModel.ISupportInitialize)(this._viewerHorzSplitContainer)).BeginInit();
         Me._viewerHorzSplitContainer.Panel1.SuspendLayout()
         Me._viewerHorzSplitContainer.Panel2.SuspendLayout()
         Me._viewerHorzSplitContainer.SuspendLayout()
         Me.SuspendLayout()
         '
         '_mainMenuStrip
         '
         Me._mainMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._fileToolStripMenuItem, Me._editToolStripMenuItem, Me._viewToolStripMenuItem, Me._engineToolStripMenuItem, Me._pageToolStripMenuItem, Me._processToolStripMenuItem, Me._zonesToolStripMenuItem, Me._recognizeToolStripMenuItem, Me._documentToolStripMenuItem, Me._preferencesToolStripMenuItem, Me._helpToolStripMenuItem})
         Me._mainMenuStrip.Location = New System.Drawing.Point(0, 0)
         Me._mainMenuStrip.Name = "_mainMenuStrip"
         Me._mainMenuStrip.Size = New System.Drawing.Size(984, 24)
         Me._mainMenuStrip.TabIndex = 0
         Me._mainMenuStrip.Text = "menuStrip1"
         '
         '_fileToolStripMenuItem
         '
         Me._fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._fileOpenToolStripMenuItem, Me._fileSetPDFLoadResolutionToolStripMenuItem, Me._fileSep1ToolStripMenuItem, Me._fileConvertLDToolStripMenuItem, Me._fileSep2ToolStripMenuItem, Me._fileScanToolStripMenuItem, Me._fileSep3ToolStripMenuItem, Me._fileExitToolStripMenuItem})
         Me._fileToolStripMenuItem.Name = "_fileToolStripMenuItem"
         Me._fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
         Me._fileToolStripMenuItem.Text = "&File"
         '
         '_fileOpenToolStripMenuItem
         '
         Me._fileOpenToolStripMenuItem.Image = Global.OcrDemo.Resources.OpenDocument
         Me._fileOpenToolStripMenuItem.Name = "_fileOpenToolStripMenuItem"
         Me._fileOpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
         Me._fileOpenToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
         Me._fileOpenToolStripMenuItem.Text = "&Open..."
         '
         '_fileSetPDFLoadResolutionToolStripMenuItem
         '
         Me._fileSetPDFLoadResolutionToolStripMenuItem.Name = "_fileSetPDFLoadResolutionToolStripMenuItem"
         Me._fileSetPDFLoadResolutionToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
         Me._fileSetPDFLoadResolutionToolStripMenuItem.Text = "Set PDF Load &Resolution..."
         '
         '_fileSep1ToolStripMenuItem
         '
         Me._fileSep1ToolStripMenuItem.Name = "_fileSep1ToolStripMenuItem"
         Me._fileSep1ToolStripMenuItem.Size = New System.Drawing.Size(208, 6)
         '
         '_fileConvertLDToolStripMenuItem
         '
         Me._fileConvertLDToolStripMenuItem.Name = "_fileConvertLDToolStripMenuItem"
         Me._fileConvertLDToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
         Me._fileConvertLDToolStripMenuItem.Text = "&Convert LTD..."
         '
         '_fileSep2ToolStripMenuItem
         '
         Me._fileSep2ToolStripMenuItem.Name = "_fileSep2ToolStripMenuItem"
         Me._fileSep2ToolStripMenuItem.Size = New System.Drawing.Size(208, 6)
         '
         '_fileScanToolStripMenuItem
         '
         Me._fileScanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._scanSelectSourceToolStripMenuItem, Me._scanAcquireToolStripMenuItem})
         Me._fileScanToolStripMenuItem.Name = "_fileScanToolStripMenuItem"
         Me._fileScanToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
         Me._fileScanToolStripMenuItem.Text = "S&can"
         '
         '_scanSelectSourceToolStripMenuItem
         '
         Me._scanSelectSourceToolStripMenuItem.Name = "_scanSelectSourceToolStripMenuItem"
         Me._scanSelectSourceToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
         Me._scanSelectSourceToolStripMenuItem.Text = "&Select source..."
         '
         '_scanAcquireToolStripMenuItem
         '
         Me._scanAcquireToolStripMenuItem.Name = "_scanAcquireToolStripMenuItem"
         Me._scanAcquireToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
         Me._scanAcquireToolStripMenuItem.Text = "&Acquire..."
         '
         '_fileSep3ToolStripMenuItem
         '
         Me._fileSep3ToolStripMenuItem.Name = "_fileSep3ToolStripMenuItem"
         Me._fileSep3ToolStripMenuItem.Size = New System.Drawing.Size(208, 6)
         '
         '_fileExitToolStripMenuItem
         '
         Me._fileExitToolStripMenuItem.Name = "_fileExitToolStripMenuItem"
         Me._fileExitToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
         Me._fileExitToolStripMenuItem.Text = "E&xit"
         '
         '_editToolStripMenuItem
         '
         Me._editToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._editCopyToolStripMenuItem, Me._editPasteToolStripMenuItem})
         Me._editToolStripMenuItem.Name = "_editToolStripMenuItem"
         Me._editToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
         Me._editToolStripMenuItem.Text = "&Edit"
         '
         '_editCopyToolStripMenuItem
         '
         Me._editCopyToolStripMenuItem.Name = "_editCopyToolStripMenuItem"
         Me._editCopyToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
               Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
         Me._editCopyToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
         Me._editCopyToolStripMenuItem.Text = "&Copy"
         '
         '_editPasteToolStripMenuItem
         '
         Me._editPasteToolStripMenuItem.Name = "_editPasteToolStripMenuItem"
         Me._editPasteToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
               Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
         Me._editPasteToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
         Me._editPasteToolStripMenuItem.Text = "&Paste"
         '
         '_viewToolStripMenuItem
         '
         Me._viewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._viewZoomOutToolStripMenuItem, Me._viewZoomInToolStripMenuItem, Me._viewSep1ToolStripMenuItem, Me._viewFitWidthToolStripMenuItem, Me._viewFitPageToolStripMenuItem})
         Me._viewToolStripMenuItem.Name = "_viewToolStripMenuItem"
         Me._viewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
         Me._viewToolStripMenuItem.Text = "&View"
         '
         '_viewZoomOutToolStripMenuItem
         '
         Me._viewZoomOutToolStripMenuItem.Image = Global.OcrDemo.Resources.ZoomOut
         Me._viewZoomOutToolStripMenuItem.Name = "_viewZoomOutToolStripMenuItem"
         Me._viewZoomOutToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
         Me._viewZoomOutToolStripMenuItem.Text = "Zoom &out"
         '
         '_viewZoomInToolStripMenuItem
         '
         Me._viewZoomInToolStripMenuItem.Image = Global.OcrDemo.Resources.ZoomIn
         Me._viewZoomInToolStripMenuItem.Name = "_viewZoomInToolStripMenuItem"
         Me._viewZoomInToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
         Me._viewZoomInToolStripMenuItem.Text = "Zoom &in"
         '
         '_viewSep1ToolStripMenuItem
         '
         Me._viewSep1ToolStripMenuItem.Name = "_viewSep1ToolStripMenuItem"
         Me._viewSep1ToolStripMenuItem.Size = New System.Drawing.Size(124, 6)
         '
         '_viewFitWidthToolStripMenuItem
         '
         Me._viewFitWidthToolStripMenuItem.Image = Global.OcrDemo.Resources.FitPageWidth
         Me._viewFitWidthToolStripMenuItem.Name = "_viewFitWidthToolStripMenuItem"
         Me._viewFitWidthToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
         Me._viewFitWidthToolStripMenuItem.Text = "Fit &width"
         '
         '_viewFitPageToolStripMenuItem
         '
         Me._viewFitPageToolStripMenuItem.Image = Global.OcrDemo.Resources.FitPage
         Me._viewFitPageToolStripMenuItem.Name = "_viewFitPageToolStripMenuItem"
         Me._viewFitPageToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
         Me._viewFitPageToolStripMenuItem.Text = "&Fit page"
         '
         '_engineToolStripMenuItem
         '
         Me._engineToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._engineSettingsToolStripMenuItem, Me._engineComponentsToolStripMenuItem, Me._engineLanguagesToolStripMenuItem})
         Me._engineToolStripMenuItem.Name = "_engineToolStripMenuItem"
         Me._engineToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
         Me._engineToolStripMenuItem.Text = "En&gine"
         '
         '_engineSettingsToolStripMenuItem
         '
         Me._engineSettingsToolStripMenuItem.Name = "_engineSettingsToolStripMenuItem"
         Me._engineSettingsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
         Me._engineSettingsToolStripMenuItem.Text = "&Settings..."
         '
         '_engineComponentsToolStripMenuItem
         '
         Me._engineComponentsToolStripMenuItem.Name = "_engineComponentsToolStripMenuItem"
         Me._engineComponentsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
         Me._engineComponentsToolStripMenuItem.Text = "&Components..."
         '
         '_engineLanguagesToolStripMenuItem
         '
         Me._engineLanguagesToolStripMenuItem.Name = "_engineLanguagesToolStripMenuItem"
         Me._engineLanguagesToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
         Me._engineLanguagesToolStripMenuItem.Text = "&Languages..."
         '
         '_pageToolStripMenuItem
         '
         Me._pageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._pageSaveProcessingImageToDiskToolStripMenuItem, Me._pageDetectPageLanguagesToolStripMenuItem, Me._pageSaveRecognizedDataAsXmlToolStripMenuItem, Me._pageCloseCurrentPageToolStripMenuItem})
         Me._pageToolStripMenuItem.Name = "_pageToolStripMenuItem"
         Me._pageToolStripMenuItem.Size = New System.Drawing.Size(45, 20)
         Me._pageToolStripMenuItem.Text = "&Page"
         '
         '_pageSaveProcessingImageToDiskToolStripMenuItem
         '
         Me._pageSaveProcessingImageToDiskToolStripMenuItem.Name = "_pageSaveProcessingImageToDiskToolStripMenuItem"
         Me._pageSaveProcessingImageToDiskToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
         Me._pageSaveProcessingImageToDiskToolStripMenuItem.Text = "&Save processing image to disk..."
         '
         '_pageDetectPageLanguagesToolStripMenuItem
         '
         Me._pageDetectPageLanguagesToolStripMenuItem.Name = "_pageDetectPageLanguagesToolStripMenuItem"
         Me._pageDetectPageLanguagesToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
         Me._pageDetectPageLanguagesToolStripMenuItem.Text = "Detect current page languages..."
         '
         '_pageSaveRecognizedDataAsXmlToolStripMenuItem
         '
         Me._pageSaveRecognizedDataAsXmlToolStripMenuItem.Name = "_pageSaveRecognizedDataAsXmlToolStripMenuItem"
         Me._pageSaveRecognizedDataAsXmlToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
         Me._pageSaveRecognizedDataAsXmlToolStripMenuItem.Text = "Save recognized data as &XML..."
         '
         '_pageCloseCurrentPageToolStripMenuItem
         '
         Me._pageCloseCurrentPageToolStripMenuItem.Name = "_pageCloseCurrentPageToolStripMenuItem"
         Me._pageCloseCurrentPageToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
         Me._pageCloseCurrentPageToolStripMenuItem.Text = "&Close current page"
         '
         '_processToolStripMenuItem
         '
         Me._processToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._processAllPagesToolStripMenuItem, Me._processSep1ToolStripMenuItem, Me._processFlipToolStripMenuItem, Me._processReverseToolStripMenuItem, Me._processRotate90ClockwiseToolStripMenuItem, Me._processRotate90CounterClockwiseToolStripMenuItem, Me._processSep2ToolStripMenuItem, Me._processPreprocessToolStripMenuItem, Me._documentCleanupToolStripMenuItem, Me._binarizationToolStripMenuItem, Me._brightnessToolStripMenuItem, Me._dualPageToolStripMenuItem, Me._processSep3ToolStripMenuItem, Me._manualPerspectiveToolStripMenuItem, Me._inversePerspectiveToolStripMenuItem, Me._perspectiveDeskewToolStripMenuItem, Me._unwarpToolStripMenuItem})
         Me._processToolStripMenuItem.Name = "_processToolStripMenuItem"
         Me._processToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
         Me._processToolStripMenuItem.Text = "Pr&ocess"
         '
         '_processAllPagesToolStripMenuItem
         '
         Me._processAllPagesToolStripMenuItem.Name = "_processAllPagesToolStripMenuItem"
         Me._processAllPagesToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
         Me._processAllPagesToolStripMenuItem.Text = "&All pages"
         Me._processAllPagesToolStripMenuItem.ToolTipText = "Process all pages or only current page"
         '
         '_processSep1ToolStripMenuItem
         '
         Me._processSep1ToolStripMenuItem.Name = "_processSep1ToolStripMenuItem"
         Me._processSep1ToolStripMenuItem.Size = New System.Drawing.Size(225, 6)
         '
         '_processFlipToolStripMenuItem
         '
         Me._processFlipToolStripMenuItem.Name = "_processFlipToolStripMenuItem"
         Me._processFlipToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
         Me._processFlipToolStripMenuItem.Text = "&Flip"
         Me._processFlipToolStripMenuItem.ToolTipText = "Flips the document from top to bottom"
         '
         '_processReverseToolStripMenuItem
         '
         Me._processReverseToolStripMenuItem.Name = "_processReverseToolStripMenuItem"
         Me._processReverseToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
         Me._processReverseToolStripMenuItem.Text = "R&everse"
         Me._processReverseToolStripMenuItem.ToolTipText = "Reverses the document (left to right) to produce a mirror image"
         '
         '_processRotate90ClockwiseToolStripMenuItem
         '
         Me._processRotate90ClockwiseToolStripMenuItem.Name = "_processRotate90ClockwiseToolStripMenuItem"
         Me._processRotate90ClockwiseToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
         Me._processRotate90ClockwiseToolStripMenuItem.Text = "R&otate 90° clockwise"
         Me._processRotate90ClockwiseToolStripMenuItem.ToolTipText = "Rotate the document 90 degrees clockwise"
         '
         '_processRotate90CounterClockwiseToolStripMenuItem
         '
         Me._processRotate90CounterClockwiseToolStripMenuItem.Name = "_processRotate90CounterClockwiseToolStripMenuItem"
         Me._processRotate90CounterClockwiseToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
         Me._processRotate90CounterClockwiseToolStripMenuItem.Text = "Ro&tate 90° counter-clockwise"
         Me._processRotate90CounterClockwiseToolStripMenuItem.ToolTipText = "Rotate the document 90 degrees counter-clockwise"
         '
         '_processSep2ToolStripMenuItem
         '
         Me._processSep2ToolStripMenuItem.Name = "_processSep2ToolStripMenuItem"
         Me._processSep2ToolStripMenuItem.Size = New System.Drawing.Size(225, 6)
         '
         '_processPreprocessToolStripMenuItem
         '
         Me._processPreprocessToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._processPreprocessGetDeskewAngleToolStripMenuItem, Me._processPreprocessGetRotateAngleToolStripMenuItem, Me._processPreprocessIsInvertedToolStripMenuItem, Me._processPreprocessSep1ToolStripMenuItem, Me._processPreprocessDeskewToolStripMenuItem, Me._processPreprocessRotateToolStripMenuItem, Me._processPreprocessInvertToolStripMenuItem, Me._processPreprocessAllToolStripMenuItem})
         Me._processPreprocessToolStripMenuItem.Name = "_processPreprocessToolStripMenuItem"
         Me._processPreprocessToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
         Me._processPreprocessToolStripMenuItem.Text = "Prep&rocess"
         '
         '_processPreprocessGetDeskewAngleToolStripMenuItem
         '
         Me._processPreprocessGetDeskewAngleToolStripMenuItem.Name = "_processPreprocessGetDeskewAngleToolStripMenuItem"
         Me._processPreprocessGetDeskewAngleToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
         Me._processPreprocessGetDeskewAngleToolStripMenuItem.Text = "Get &deskew angle..."
         '
         '_processPreprocessGetRotateAngleToolStripMenuItem
         '
         Me._processPreprocessGetRotateAngleToolStripMenuItem.Name = "_processPreprocessGetRotateAngleToolStripMenuItem"
         Me._processPreprocessGetRotateAngleToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
         Me._processPreprocessGetRotateAngleToolStripMenuItem.Text = "Get &rotate angle..."
         '
         '_processPreprocessIsInvertedToolStripMenuItem
         '
         Me._processPreprocessIsInvertedToolStripMenuItem.Name = "_processPreprocessIsInvertedToolStripMenuItem"
         Me._processPreprocessIsInvertedToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
         Me._processPreprocessIsInvertedToolStripMenuItem.Text = "Is &Inverted..."
         '
         '_processPreprocessSep1ToolStripMenuItem
         '
         Me._processPreprocessSep1ToolStripMenuItem.Name = "_processPreprocessSep1ToolStripMenuItem"
         Me._processPreprocessSep1ToolStripMenuItem.Size = New System.Drawing.Size(172, 6)
         '
         '_processPreprocessDeskewToolStripMenuItem
         '
         Me._processPreprocessDeskewToolStripMenuItem.Name = "_processPreprocessDeskewToolStripMenuItem"
         Me._processPreprocessDeskewToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
         Me._processPreprocessDeskewToolStripMenuItem.Text = "&Deskew"
         '
         '_processPreprocessRotateToolStripMenuItem
         '
         Me._processPreprocessRotateToolStripMenuItem.Name = "_processPreprocessRotateToolStripMenuItem"
         Me._processPreprocessRotateToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
         Me._processPreprocessRotateToolStripMenuItem.Text = "&Rotate"
         '
         '_processPreprocessInvertToolStripMenuItem
         '
         Me._processPreprocessInvertToolStripMenuItem.Name = "_processPreprocessInvertToolStripMenuItem"
         Me._processPreprocessInvertToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
         Me._processPreprocessInvertToolStripMenuItem.Text = "&Invert"
         '
         '_processPreprocessAllToolStripMenuItem
         '
         Me._processPreprocessAllToolStripMenuItem.Name = "_processPreprocessAllToolStripMenuItem"
         Me._processPreprocessAllToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
         Me._processPreprocessAllToolStripMenuItem.Text = "All"
         '
         '_documentCleanupToolStripMenuItem
         '
         Me._documentCleanupToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._processAutoCropToolStripMenuItem, Me._processDespeckleToolStripMenuItem, Me._processErodeToolStripMenuItem, Me._processDilateToolStripMenuItem, Me._processUnditherTextToolStripMenuItem, Me._processFixBrokenLettersToolStripMenuItem, Me._processLineRemoveToolStripMenuItem})
         Me._documentCleanupToolStripMenuItem.Name = "_documentCleanupToolStripMenuItem"
         Me._documentCleanupToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
         Me._documentCleanupToolStripMenuItem.Text = "&Document clean up"
         '
         '_processAutoCropToolStripMenuItem
         '
         Me._processAutoCropToolStripMenuItem.Name = "_processAutoCropToolStripMenuItem"
         Me._processAutoCropToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
         Me._processAutoCropToolStripMenuItem.Text = "Auto &Crop"
         Me._processAutoCropToolStripMenuItem.ToolTipText = "Trims the document by removing blank space around the edges"
         '
         '_processDespeckleToolStripMenuItem
         '
         Me._processDespeckleToolStripMenuItem.Name = "_processDespeckleToolStripMenuItem"
         Me._processDespeckleToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
         Me._processDespeckleToolStripMenuItem.Text = "Des&peckle"
         Me._processDespeckleToolStripMenuItem.ToolTipText = "Removes speckles from the document. Typically, this function is used to clean up " & _
       "scanned images (such as FAX images)"
         '
         '_processErodeToolStripMenuItem
         '
         Me._processErodeToolStripMenuItem.Name = "_processErodeToolStripMenuItem"
         Me._processErodeToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
         Me._processErodeToolStripMenuItem.Text = "&Erode"
         Me._processErodeToolStripMenuItem.ToolTipText = "Shrinks black objects in the document"
         '
         '_processDilateToolStripMenuItem
         '
         Me._processDilateToolStripMenuItem.Name = "_processDilateToolStripMenuItem"
         Me._processDilateToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
         Me._processDilateToolStripMenuItem.Text = "D&ilate"
         Me._processDilateToolStripMenuItem.ToolTipText = "Enlarges black objects in the document"
         '
         '_processUnditherTextToolStripMenuItem
         '
         Me._processUnditherTextToolStripMenuItem.Name = "_processUnditherTextToolStripMenuItem"
         Me._processUnditherTextToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
         Me._processUnditherTextToolStripMenuItem.Text = "&Undither text"
         Me._processUnditherTextToolStripMenuItem.ToolTipText = "Sharpen the text on this document if the document was converted with dithered tex" & _
       "t from a higher bits/pixel"
         '
         '_processFixBrokenLettersToolStripMenuItem
         '
         Me._processFixBrokenLettersToolStripMenuItem.Name = "_processFixBrokenLettersToolStripMenuItem"
         Me._processFixBrokenLettersToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
         Me._processFixBrokenLettersToolStripMenuItem.Text = "Fi&x broken letters"
         Me._processFixBrokenLettersToolStripMenuItem.ToolTipText = "Enlarge text lines to fix broken letters in the document"
         '
         '_processLineRemoveToolStripMenuItem
         '
         Me._processLineRemoveToolStripMenuItem.Name = "_processLineRemoveToolStripMenuItem"
         Me._processLineRemoveToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
         Me._processLineRemoveToolStripMenuItem.Text = "&Line remove"
         Me._processLineRemoveToolStripMenuItem.ToolTipText = "Removes horizontal and vertical lines in a 1-bit black and white image"
         '
         '_binarizationToolStripMenuItem
         '
         Me._binarizationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._processAutoBinarizeToolStripMenuItem, Me._processDynamicBinarizeToolStripMenuItem})
         Me._binarizationToolStripMenuItem.Name = "_binarizationToolStripMenuItem"
         Me._binarizationToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
         Me._binarizationToolStripMenuItem.Text = "&Binarization"
         '
         '_processAutoBinarizeToolStripMenuItem
         '
         Me._processAutoBinarizeToolStripMenuItem.Name = "_processAutoBinarizeToolStripMenuItem"
         Me._processAutoBinarizeToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
         Me._processAutoBinarizeToolStripMenuItem.Text = "&Auto"
         Me._processAutoBinarizeToolStripMenuItem.ToolTipText = "Convert the document to 1 bits/pixel (bitonal) by applying binary segmentation"
         '
         '_processDynamicBinarizeToolStripMenuItem
         '
         Me._processDynamicBinarizeToolStripMenuItem.Name = "_processDynamicBinarizeToolStripMenuItem"
         Me._processDynamicBinarizeToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
         Me._processDynamicBinarizeToolStripMenuItem.Text = "&Dynamic"
         Me._processDynamicBinarizeToolStripMenuItem.ToolTipText = "Converts an image into a black and white image without changing its bits per pixe" & _
       "l by using a local threshold value for each pixel of the image"
         '
         '_brightnessToolStripMenuItem
         '
         Me._brightnessToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._processHisogramEqualToolStripMenuItem, Me._processAutoLevelToolStripMenuItem, Me._processContrastBrightnessIntensityToolStripMenuItem})
         Me._brightnessToolStripMenuItem.Name = "_brightnessToolStripMenuItem"
         Me._brightnessToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
         Me._brightnessToolStripMenuItem.Text = "Bright&ness"
         '
         '_processHisogramEqualToolStripMenuItem
         '
         Me._processHisogramEqualToolStripMenuItem.Name = "_processHisogramEqualToolStripMenuItem"
         Me._processHisogramEqualToolStripMenuItem.Size = New System.Drawing.Size(242, 22)
         Me._processHisogramEqualToolStripMenuItem.Text = "&Hisogram Equalize"
         Me._processHisogramEqualToolStripMenuItem.ToolTipText = "Linearizes the number of pixels, in an image, based on the specified color space." & _
       " This can be used to bring out the detail in dark areas of an image"
         '
         '_processAutoLevelToolStripMenuItem
         '
         Me._processAutoLevelToolStripMenuItem.Name = "_processAutoLevelToolStripMenuItem"
         Me._processAutoLevelToolStripMenuItem.Size = New System.Drawing.Size(242, 22)
         Me._processAutoLevelToolStripMenuItem.Text = "&Auto level"
         Me._processAutoLevelToolStripMenuItem.ToolTipText = "Applies one of several types of automatic color leveling to an image"
         '
         '_processContrastBrightnessIntensityToolStripMenuItem
         '
         Me._processContrastBrightnessIntensityToolStripMenuItem.Name = "_processContrastBrightnessIntensityToolStripMenuItem"
         Me._processContrastBrightnessIntensityToolStripMenuItem.Size = New System.Drawing.Size(242, 22)
         Me._processContrastBrightnessIntensityToolStripMenuItem.Text = "&Contrast/Brightnesst/Intensity..."
         Me._processContrastBrightnessIntensityToolStripMenuItem.ToolTipText = "Applies contrast, brightness and intensity adjustments to enhance the image tonal" & _
       " range"
         '
         '_dualPageToolStripMenuItem
         '
         Me._dualPageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._processPageSplitterToolStripMenuItem, Me._processExpandContentToolStripMenuItem})
         Me._dualPageToolStripMenuItem.Name = "_dualPageToolStripMenuItem"
         Me._dualPageToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
         Me._dualPageToolStripMenuItem.Text = "D&ual Page"
         '
         '_processPageSplitterToolStripMenuItem
         '
         Me._processPageSplitterToolStripMenuItem.Name = "_processPageSplitterToolStripMenuItem"
         Me._processPageSplitterToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
         Me._processPageSplitterToolStripMenuItem.Text = "Page &Splitter"
         '
         '_processExpandContentToolStripMenuItem
         '
         Me._processExpandContentToolStripMenuItem.Name = "_processExpandContentToolStripMenuItem"
         Me._processExpandContentToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
         Me._processExpandContentToolStripMenuItem.Text = "E&xpand Content"
         '
         '_processSep3ToolStripMenuItem
         '
         Me._processSep3ToolStripMenuItem.Name = "_processSep3ToolStripMenuItem"
         Me._processSep3ToolStripMenuItem.Size = New System.Drawing.Size(225, 6)
         '
         '_manualPerspectiveToolStripMenuItem
         '
         Me._manualPerspectiveToolStripMenuItem.Name = "_manualPerspectiveToolStripMenuItem"
         Me._manualPerspectiveToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
         Me._manualPerspectiveToolStripMenuItem.Text = "&Manual Perspective..."
         Me._manualPerspectiveToolStripMenuItem.ToolTipText = "Manual perspective deskew"
         '
         '_inversePerspectiveToolStripMenuItem
         '
         Me._inversePerspectiveToolStripMenuItem.Name = "_inversePerspectiveToolStripMenuItem"
         Me._inversePerspectiveToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
         Me._inversePerspectiveToolStripMenuItem.Text = "&Inverse Perspective..."
         Me._inversePerspectiveToolStripMenuItem.ToolTipText = "Inverse perspective deskew"
         '
         '_perspectiveDeskewToolStripMenuItem
         '
         Me._perspectiveDeskewToolStripMenuItem.Name = "_perspectiveDeskewToolStripMenuItem"
         Me._perspectiveDeskewToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
         Me._perspectiveDeskewToolStripMenuItem.Text = "&Perspective Deskew"
         Me._perspectiveDeskewToolStripMenuItem.ToolTipText = "Perspective deskew"
         '
         '_zonesToolStripMenuItem
         '
         Me._zonesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._zonesAutoZoneDocumentToolStripMenuItem, Me._zonesAutoZoneCurrentPageToolStripMenuItem, Me._zonesSep1ToolStripMenuItem, Me._zonesUpdateZonesToolStripMenuItem, Me._zonesSep2ToolStripMenuItem, Me._zonesLoadZonesToolStripMenuItem, Me._zonesSaveZonesToolStripMenuItem, Me._zonesSep3ToolStripMenuItem, Me._loadAllPagesZonesToolStripMenuItem, Me._saveAllPagesZonesToolStripMenuItem, Me._zonesSep4ToolStripMenuItem, Me._clearAllPagesZonesToolStripMenuItem, Me._zonesSep5ToolStripMenuItem, Me._zonesShowZonesToolStripMenuItem, Me._zonesShowZoneNamesToolStripMenuItem})
         Me._zonesToolStripMenuItem.Name = "_zonesToolStripMenuItem"
         Me._zonesToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
         Me._zonesToolStripMenuItem.Text = "&Zones"
         '
         '_zonesAutoZoneDocumentToolStripMenuItem
         '
         Me._zonesAutoZoneDocumentToolStripMenuItem.Image = Global.OcrDemo.Resources.AutoZoneDocument
         Me._zonesAutoZoneDocumentToolStripMenuItem.Name = "_zonesAutoZoneDocumentToolStripMenuItem"
         Me._zonesAutoZoneDocumentToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
         Me._zonesAutoZoneDocumentToolStripMenuItem.Text = "&Auto zone document"
         '
         '_zonesAutoZoneCurrentPageToolStripMenuItem
         '
         Me._zonesAutoZoneCurrentPageToolStripMenuItem.Image = Global.OcrDemo.Resources.AutoZonePage
         Me._zonesAutoZoneCurrentPageToolStripMenuItem.Name = "_zonesAutoZoneCurrentPageToolStripMenuItem"
         Me._zonesAutoZoneCurrentPageToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
         Me._zonesAutoZoneCurrentPageToolStripMenuItem.Text = "Auto zone &current page"
         '
         '_zonesSep1ToolStripMenuItem
         '
         Me._zonesSep1ToolStripMenuItem.Name = "_zonesSep1ToolStripMenuItem"
         Me._zonesSep1ToolStripMenuItem.Size = New System.Drawing.Size(223, 6)
         '
         '_zonesUpdateZonesToolStripMenuItem
         '
         Me._zonesUpdateZonesToolStripMenuItem.Image = Global.OcrDemo.Resources.ZoneProperties
         Me._zonesUpdateZonesToolStripMenuItem.Name = "_zonesUpdateZonesToolStripMenuItem"
         Me._zonesUpdateZonesToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
         Me._zonesUpdateZonesToolStripMenuItem.Text = "&Update zones..."
         '
         '_zonesSep2ToolStripMenuItem
         '
         Me._zonesSep2ToolStripMenuItem.Name = "_zonesSep2ToolStripMenuItem"
         Me._zonesSep2ToolStripMenuItem.Size = New System.Drawing.Size(223, 6)
         '
         '_zonesLoadZonesToolStripMenuItem
         '
         Me._zonesLoadZonesToolStripMenuItem.Name = "_zonesLoadZonesToolStripMenuItem"
         Me._zonesLoadZonesToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
         Me._zonesLoadZonesToolStripMenuItem.Text = "&Load zones to current page..."
         '
         '_zonesSaveZonesToolStripMenuItem
         '
         Me._zonesSaveZonesToolStripMenuItem.Name = "_zonesSaveZonesToolStripMenuItem"
         Me._zonesSaveZonesToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
         Me._zonesSaveZonesToolStripMenuItem.Text = "&Save current page zones..."
         '
         '_zonesSep3ToolStripMenuItem
         '
         Me._zonesSep3ToolStripMenuItem.Name = "_zonesSep3ToolStripMenuItem"
         Me._zonesSep3ToolStripMenuItem.Size = New System.Drawing.Size(223, 6)
         '
         '_loadAllPagesZonesToolStripMenuItem
         '
         Me._loadAllPagesZonesToolStripMenuItem.Name = "_loadAllPagesZonesToolStripMenuItem"
         Me._loadAllPagesZonesToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
         Me._loadAllPagesZonesToolStripMenuItem.Text = "Load all pages zones..."
         '
         '_saveAllPagesZonesToolStripMenuItem
         '
         Me._saveAllPagesZonesToolStripMenuItem.Name = "_saveAllPagesZonesToolStripMenuItem"
         Me._saveAllPagesZonesToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
         Me._saveAllPagesZonesToolStripMenuItem.Text = "Save all pages zones..."
         '
         '_zonesSep4ToolStripMenuItem
         '
         Me._zonesSep4ToolStripMenuItem.Name = "_zonesSep4ToolStripMenuItem"
         Me._zonesSep4ToolStripMenuItem.Size = New System.Drawing.Size(223, 6)
         '
         '_clearAllPagesZonesToolStripMenuItem
         '
         Me._clearAllPagesZonesToolStripMenuItem.Name = "_clearAllPagesZonesToolStripMenuItem"
         Me._clearAllPagesZonesToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
         Me._clearAllPagesZonesToolStripMenuItem.Text = "Clear all pages zones"
         '
         '_zonesSep5ToolStripMenuItem
         '
         Me._zonesSep5ToolStripMenuItem.Name = "_zonesSep5ToolStripMenuItem"
         Me._zonesSep5ToolStripMenuItem.Size = New System.Drawing.Size(223, 6)
         '
         '_zonesShowZonesToolStripMenuItem
         '
         Me._zonesShowZonesToolStripMenuItem.Image = Global.OcrDemo.Resources.ShowZones
         Me._zonesShowZonesToolStripMenuItem.Name = "_zonesShowZonesToolStripMenuItem"
         Me._zonesShowZonesToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
         Me._zonesShowZonesToolStripMenuItem.Text = "Show &zones"
         '
         '_zonesShowZoneNamesToolStripMenuItem
         '
         Me._zonesShowZoneNamesToolStripMenuItem.Image = Global.OcrDemo.Resources.ShowZoneName
         Me._zonesShowZoneNamesToolStripMenuItem.Name = "_zonesShowZoneNamesToolStripMenuItem"
         Me._zonesShowZoneNamesToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
         Me._zonesShowZoneNamesToolStripMenuItem.Text = "Show zone &names"
         '
         '_recognizeToolStripMenuItem
         '
         Me._recognizeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._recognizeRecognizeDocumentToolStripMenuItem, Me._recognizeRecognizePageToolStripMenuItem, Me._ocrSep2ToolStripMenuItem, Me._recognizeSpellCheckEngineStripMenuItem, Me._recognizeOmrOptionsToolStripMenuItem, Me.toolStripSeparator1, Me._recognizeSaveAfterRecognizeToolStripMenuItem})
         Me._recognizeToolStripMenuItem.Name = "_recognizeToolStripMenuItem"
         Me._recognizeToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
         Me._recognizeToolStripMenuItem.Text = "&Recognize"
         '
         '_recognizeRecognizeDocumentToolStripMenuItem
         '
         Me._recognizeRecognizeDocumentToolStripMenuItem.Image = Global.OcrDemo.Resources.RecognizeAllPages
         Me._recognizeRecognizeDocumentToolStripMenuItem.Name = "_recognizeRecognizeDocumentToolStripMenuItem"
         Me._recognizeRecognizeDocumentToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
         Me._recognizeRecognizeDocumentToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
         Me._recognizeRecognizeDocumentToolStripMenuItem.Text = "&Recognize document"
         Me._recognizeRecognizeDocumentToolStripMenuItem.ToolTipText = "Recognize all the pages in the document"
         '
         '_recognizeRecognizePageToolStripMenuItem
         '
         Me._recognizeRecognizePageToolStripMenuItem.Image = Global.OcrDemo.Resources.RecognizePage
         Me._recognizeRecognizePageToolStripMenuItem.Name = "_recognizeRecognizePageToolStripMenuItem"
         Me._recognizeRecognizePageToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
         Me._recognizeRecognizePageToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
         Me._recognizeRecognizePageToolStripMenuItem.Text = "Recognize current &page"
         Me._recognizeRecognizePageToolStripMenuItem.ToolTipText = "Recognize the current page"
         '
         '_ocrSep2ToolStripMenuItem
         '
         Me._ocrSep2ToolStripMenuItem.Name = "_ocrSep2ToolStripMenuItem"
         Me._ocrSep2ToolStripMenuItem.Size = New System.Drawing.Size(229, 6)
         '
         '_recognizeSpellCheckEngineStripMenuItem
         '
         Me._recognizeSpellCheckEngineStripMenuItem.Name = "_recognizeSpellCheckEngineStripMenuItem"
         Me._recognizeSpellCheckEngineStripMenuItem.Size = New System.Drawing.Size(232, 22)
         Me._recognizeSpellCheckEngineStripMenuItem.Text = "Spell check &engine..."
         '
         '_recognizeOmrOptionsToolStripMenuItem
         '
         Me._recognizeOmrOptionsToolStripMenuItem.Name = "_recognizeOmrOptionsToolStripMenuItem"
         Me._recognizeOmrOptionsToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
         Me._recognizeOmrOptionsToolStripMenuItem.Text = "&OMR Options..."
         '
         'toolStripSeparator1
         '
         Me.toolStripSeparator1.Name = "toolStripSeparator1"
         Me.toolStripSeparator1.Size = New System.Drawing.Size(229, 6)
         '
         '_recognizeSaveAfterRecognizeToolStripMenuItem
         '
         Me._recognizeSaveAfterRecognizeToolStripMenuItem.Name = "_recognizeSaveAfterRecognizeToolStripMenuItem"
         Me._recognizeSaveAfterRecognizeToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
         Me._recognizeSaveAfterRecognizeToolStripMenuItem.Text = "&Save after Recognize"
         '
         '_documentToolStripMenuItem
         '
         Me._documentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._documentCreateDocumentToolStripMenuItem, Me._documentLoadDocumentToolStripMenuItem, Me.toolStripSeparator2, Me._documentAddCurrentPageToolStripMenuItem, Me._documentInsertPagesToolStripMenuItem, Me._documentRemoveCurrentPageToolStripMenuItem, Me._documentClearDocumentPagesToolStripMenuItem, Me.toolStripSeparator3, Me._documentSaveRecognizedDataAsXmlToolStripMenuItem, Me._documentSaveDocumentToolStripMenuItem, Me.toolStripSeparator4, Me._documentCloseDocumentToolStripMenuItem})
         Me._documentToolStripMenuItem.Name = "_documentToolStripMenuItem"
         Me._documentToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
         Me._documentToolStripMenuItem.Text = "&Document"
         '
         '_documentCreateDocumentToolStripMenuItem
         '
         Me._documentCreateDocumentToolStripMenuItem.Name = "_documentCreateDocumentToolStripMenuItem"
         Me._documentCreateDocumentToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
         Me._documentCreateDocumentToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
         Me._documentCreateDocumentToolStripMenuItem.Text = "&Create Document..."
         Me._documentCreateDocumentToolStripMenuItem.ToolTipText = "Create document"
         '
         '_documentLoadDocumentToolStripMenuItem
         '
         Me._documentLoadDocumentToolStripMenuItem.Name = "_documentLoadDocumentToolStripMenuItem"
         Me._documentLoadDocumentToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
         Me._documentLoadDocumentToolStripMenuItem.Text = "&Load Document..."
         Me._documentLoadDocumentToolStripMenuItem.ToolTipText = "Load document"
         '
         'toolStripSeparator2
         '
         Me.toolStripSeparator2.Name = "toolStripSeparator2"
         Me.toolStripSeparator2.Size = New System.Drawing.Size(232, 6)
         '
         '_documentAddCurrentPageToolStripMenuItem
         '
         Me._documentAddCurrentPageToolStripMenuItem.Name = "_documentAddCurrentPageToolStripMenuItem"
         Me._documentAddCurrentPageToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
         Me._documentAddCurrentPageToolStripMenuItem.Text = "&Add current page"
         Me._documentAddCurrentPageToolStripMenuItem.ToolTipText = "Add current page"
         '
         '_documentInsertPagesToolStripMenuItem
         '
         Me._documentInsertPagesToolStripMenuItem.Image = Global.OcrDemo.Resources.InsertPage
         Me._documentInsertPagesToolStripMenuItem.Name = "_documentInsertPagesToolStripMenuItem"
         Me._documentInsertPagesToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
         Me._documentInsertPagesToolStripMenuItem.Text = "&Insert pages..."
         Me._documentInsertPagesToolStripMenuItem.ToolTipText = "Insert pages (Memory mode only)"
         '
         '_documentRemoveCurrentPageToolStripMenuItem
         '
         Me._documentRemoveCurrentPageToolStripMenuItem.Name = "_documentRemoveCurrentPageToolStripMenuItem"
         Me._documentRemoveCurrentPageToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
         Me._documentRemoveCurrentPageToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
         Me._documentRemoveCurrentPageToolStripMenuItem.Text = "&Remove current page"
         Me._documentRemoveCurrentPageToolStripMenuItem.ToolTipText = "Remove current page (Memory mode only)"
         '
         '_documentClearDocumentPagesToolStripMenuItem
         '
         Me._documentClearDocumentPagesToolStripMenuItem.Name = "_documentClearDocumentPagesToolStripMenuItem"
         Me._documentClearDocumentPagesToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
         Me._documentClearDocumentPagesToolStripMenuItem.Text = "Cl&ear document pages"
         Me._documentClearDocumentPagesToolStripMenuItem.ToolTipText = "Clear document pages (Memory mode only)"
         '
         'toolStripSeparator3
         '
         Me.toolStripSeparator3.Name = "toolStripSeparator3"
         Me.toolStripSeparator3.Size = New System.Drawing.Size(232, 6)
         '
         '_documentSaveRecognizedDataAsXmlToolStripMenuItem
         '
         Me._documentSaveRecognizedDataAsXmlToolStripMenuItem.Name = "_documentSaveRecognizedDataAsXmlToolStripMenuItem"
         Me._documentSaveRecognizedDataAsXmlToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
         Me._documentSaveRecognizedDataAsXmlToolStripMenuItem.Text = "Save recognized data as &XML..."
         Me._documentSaveRecognizedDataAsXmlToolStripMenuItem.ToolTipText = "Save recognized data as XML (Memory mode only)"
         '
         '_documentSaveDocumentToolStripMenuItem
         '
         Me._documentSaveDocumentToolStripMenuItem.Image = Global.OcrDemo.Resources.SaveDocument
         Me._documentSaveDocumentToolStripMenuItem.Name = "_documentSaveDocumentToolStripMenuItem"
         Me._documentSaveDocumentToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
         Me._documentSaveDocumentToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
         Me._documentSaveDocumentToolStripMenuItem.Text = "&Save document"
         Me._documentSaveDocumentToolStripMenuItem.ToolTipText = "Save recognized document"
         '
         'toolStripSeparator4
         '
         Me.toolStripSeparator4.Name = "toolStripSeparator4"
         Me.toolStripSeparator4.Size = New System.Drawing.Size(232, 6)
         '
         '_documentCloseDocumentToolStripMenuItem
         '
         Me._documentCloseDocumentToolStripMenuItem.Name = "_documentCloseDocumentToolStripMenuItem"
         Me._documentCloseDocumentToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
         Me._documentCloseDocumentToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
         Me._documentCloseDocumentToolStripMenuItem.Text = "Cl&ose Document"
         Me._documentCloseDocumentToolStripMenuItem.ToolTipText = "Close document (Memory mode only)"
         '
         '_preferencesToolStripMenuItem
         '
         Me._preferencesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._preferencesUseProgressBarsToolStripMenuItem})
         Me._preferencesToolStripMenuItem.Name = "_preferencesToolStripMenuItem"
         Me._preferencesToolStripMenuItem.Size = New System.Drawing.Size(80, 20)
         Me._preferencesToolStripMenuItem.Text = "Prefere&nces"
         '
         '_preferencesUseProgressBarsToolStripMenuItem
         '
         Me._preferencesUseProgressBarsToolStripMenuItem.Name = "_preferencesUseProgressBarsToolStripMenuItem"
         Me._preferencesUseProgressBarsToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
         Me._preferencesUseProgressBarsToolStripMenuItem.Text = "&Use progress bars"
         '
         '_helpToolStripMenuItem
         '
         Me._helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._helpAboutToolStripMenuItem})
         Me._helpToolStripMenuItem.Name = "_helpToolStripMenuItem"
         Me._helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
         Me._helpToolStripMenuItem.Text = "&Help"
         '
         '_helpAboutToolStripMenuItem
         '
         Me._helpAboutToolStripMenuItem.Name = "_helpAboutToolStripMenuItem"
         Me._helpAboutToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
         Me._helpAboutToolStripMenuItem.Text = "&About..."
         '
         '_mainToolStrip
         '
         Me._mainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._openDocumentToolStripButton, Me._toolStripSeparator1, Me._autoZoneDocumentToolStripButton, Me._autoZonePageToolStripButton, Me._recognizeDocumentToolStripButton, Me._recognizePageToolStripButton, Me._saveDocumentToolStripButton})
         Me._mainToolStrip.Location = New System.Drawing.Point(0, 24)
         Me._mainToolStrip.Name = "_mainToolStrip"
         Me._mainToolStrip.Size = New System.Drawing.Size(984, 25)
         Me._mainToolStrip.TabIndex = 1
         Me._mainToolStrip.Text = "toolStrip1"
         '
         '_openDocumentToolStripButton
         '
         Me._openDocumentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._openDocumentToolStripButton.Image = Global.OcrDemo.Resources.OpenDocument
         Me._openDocumentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._openDocumentToolStripButton.Name = "_openDocumentToolStripButton"
         Me._openDocumentToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._openDocumentToolStripButton.ToolTipText = "Open document from disk"
         '
         '_toolStripSeparator1
         '
         Me._toolStripSeparator1.Name = "_toolStripSeparator1"
         Me._toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
         '
         '_autoZoneDocumentToolStripButton
         '
         Me._autoZoneDocumentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._autoZoneDocumentToolStripButton.Image = Global.OcrDemo.Resources.AutoZoneDocument
         Me._autoZoneDocumentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._autoZoneDocumentToolStripButton.Name = "_autoZoneDocumentToolStripButton"
         Me._autoZoneDocumentToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._autoZoneDocumentToolStripButton.ToolTipText = "Auto-locate the zones of all pages in this document"
         '
         '_autoZonePageToolStripButton
         '
         Me._autoZonePageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._autoZonePageToolStripButton.Image = Global.OcrDemo.Resources.AutoZonePage
         Me._autoZonePageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._autoZonePageToolStripButton.Name = "_autoZonePageToolStripButton"
         Me._autoZonePageToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._autoZonePageToolStripButton.ToolTipText = "Auto-locate the zones in the current page"
         '
         '_recognizeDocumentToolStripButton
         '
         Me._recognizeDocumentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._recognizeDocumentToolStripButton.Image = Global.OcrDemo.Resources.RecognizeAllPages
         Me._recognizeDocumentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._recognizeDocumentToolStripButton.Name = "_recognizeDocumentToolStripButton"
         Me._recognizeDocumentToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._recognizeDocumentToolStripButton.Text = "toolStripButton2"
         Me._recognizeDocumentToolStripButton.ToolTipText = "Recognize all the pages in the document"
         '
         '_recognizePageToolStripButton
         '
         Me._recognizePageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._recognizePageToolStripButton.Image = Global.OcrDemo.Resources.RecognizePage
         Me._recognizePageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._recognizePageToolStripButton.Name = "_recognizePageToolStripButton"
         Me._recognizePageToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._recognizePageToolStripButton.ToolTipText = "Recognize the current page"
         '
         '_saveDocumentToolStripButton
         '
         Me._saveDocumentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._saveDocumentToolStripButton.Image = Global.OcrDemo.Resources.SaveDocument
         Me._saveDocumentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._saveDocumentToolStripButton.Name = "_saveDocumentToolStripButton"
         Me._saveDocumentToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._saveDocumentToolStripButton.ToolTipText = "Save recognized document"
         '
         '_mainStatusStrip
         '
         Me._mainStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._timingDescriptionToolStripStatusLabel, Me._timingToolStripStatusLabel, Me._activeSpellCheckerDescriptionToolStripStatusLabel, Me._activeSpellCheckerToolStripStatusLabel})
         Me._mainStatusStrip.Location = New System.Drawing.Point(0, 609)
         Me._mainStatusStrip.Name = "_mainStatusStrip"
         Me._mainStatusStrip.Size = New System.Drawing.Size(984, 22)
         Me._mainStatusStrip.TabIndex = 2
         Me._mainStatusStrip.Text = "statusStrip1"
         '
         '_timingDescriptionToolStripStatusLabel
         '
         Me._timingDescriptionToolStripStatusLabel.Name = "_timingDescriptionToolStripStatusLabel"
         Me._timingDescriptionToolStripStatusLabel.Size = New System.Drawing.Size(85, 17)
         Me._timingDescriptionToolStripStatusLabel.Text = "Last operation:"
         '
         '_timingToolStripStatusLabel
         '
         Me._timingToolStripStatusLabel.AutoSize = False
         Me._timingToolStripStatusLabel.Name = "_timingToolStripStatusLabel"
         Me._timingToolStripStatusLabel.Size = New System.Drawing.Size(400, 17)
         Me._timingToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_activeSpellCheckerDescriptionToolStripStatusLabel
         '
         Me._activeSpellCheckerDescriptionToolStripStatusLabel.Name = "_activeSpellCheckerDescriptionToolStripStatusLabel"
         Me._activeSpellCheckerDescriptionToolStripStatusLabel.Size = New System.Drawing.Size(117, 17)
         Me._activeSpellCheckerDescriptionToolStripStatusLabel.Text = "Active Spell Checker:"
         '
         '_activeSpellCheckerToolStripStatusLabel
         '
         Me._activeSpellCheckerToolStripStatusLabel.AutoSize = False
         Me._activeSpellCheckerToolStripStatusLabel.Name = "_activeSpellCheckerToolStripStatusLabel"
         Me._activeSpellCheckerToolStripStatusLabel.Size = New System.Drawing.Size(50, 17)
         Me._activeSpellCheckerToolStripStatusLabel.Text = "None"
         Me._activeSpellCheckerToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_mainSplitContainer
         '
         Me._mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
         Me._mainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
         Me._mainSplitContainer.Location = New System.Drawing.Point(0, 49)
         Me._mainSplitContainer.Name = "_mainSplitContainer"
         '
         '_mainSplitContainer.Panel1
         '
         Me._mainSplitContainer.Panel1.Controls.Add(Me._pagesControl)
         '
         '_mainSplitContainer.Panel2
         '
         Me._mainSplitContainer.Panel2.Controls.Add(Me._viewerVertSplitContainer)
         Me._mainSplitContainer.Size = New System.Drawing.Size(984, 560)
         Me._mainSplitContainer.SplitterDistance = 204
         Me._mainSplitContainer.TabIndex = 3
         '
         '_pagesControl
         '
         Me._pagesControl.Dock = System.Windows.Forms.DockStyle.Fill
         Me._pagesControl.Location = New System.Drawing.Point(0, 0)
         Me._pagesControl.Name = "_pagesControl"
         Me._pagesControl.Size = New System.Drawing.Size(204, 560)
         Me._pagesControl.TabIndex = 7
         '
         '_viewerVertSplitContainer
         '
         Me._viewerVertSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
         Me._viewerVertSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
         Me._viewerVertSplitContainer.Location = New System.Drawing.Point(0, 0)
         Me._viewerVertSplitContainer.Name = "_viewerVertSplitContainer"
         '
         '_viewerVertSplitContainer.Panel1
         '
         Me._viewerVertSplitContainer.Panel1.Controls.Add(Me._viewerHorzSplitContainer)
         '
         '_viewerVertSplitContainer.Panel2
         '
         Me._viewerVertSplitContainer.Panel2.Controls.Add(Me._documentInfoControl)
         Me._viewerVertSplitContainer.Size = New System.Drawing.Size(776, 560)
         Me._viewerVertSplitContainer.SplitterDistance = 589
         Me._viewerVertSplitContainer.TabIndex = 0
         '
         '_viewerHorzSplitContainer
         '
         Me._viewerHorzSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
         Me._viewerHorzSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
         Me._viewerHorzSplitContainer.Location = New System.Drawing.Point(0, 0)
         Me._viewerHorzSplitContainer.Name = "_viewerHorzSplitContainer"
         Me._viewerHorzSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
         '
         '_viewerHorzSplitContainer.Panel1
         '
         Me._viewerHorzSplitContainer.Panel1.Controls.Add(Me._viewerControl)
         '
         '_viewerHorzSplitContainer.Panel2
         '
         Me._viewerHorzSplitContainer.Panel2.Controls.Add(Me._pageTextControl)
         Me._viewerHorzSplitContainer.Size = New System.Drawing.Size(589, 560)
         Me._viewerHorzSplitContainer.SplitterDistance = 425
         Me._viewerHorzSplitContainer.TabIndex = 0
         '
         '_viewerControl
         '
         Me._viewerControl.Dock = System.Windows.Forms.DockStyle.Fill
         Me._viewerControl.Location = New System.Drawing.Point(0, 0)
         Me._viewerControl.Name = "_viewerControl"
         Me._viewerControl.Size = New System.Drawing.Size(589, 425)
         Me._viewerControl.TabIndex = 7
         '
         '_pageTextControl
         '
         Me._pageTextControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._pageTextControl.Dock = System.Windows.Forms.DockStyle.Fill
         Me._pageTextControl.Location = New System.Drawing.Point(0, 0)
         Me._pageTextControl.Name = "_pageTextControl"
         Me._pageTextControl.Size = New System.Drawing.Size(589, 131)
         Me._pageTextControl.TabIndex = 1
         '
         '_documentInfoControl
         '
         Me._documentInfoControl.Dock = System.Windows.Forms.DockStyle.Fill
         Me._documentInfoControl.Location = New System.Drawing.Point(0, 0)
         Me._documentInfoControl.Name = "_documentInfoControl"
         Me._documentInfoControl.Size = New System.Drawing.Size(183, 560)
         Me._documentInfoControl.TabIndex = 0
         '
         '_unwarpToolStripMenuItem
         '
         Me._unwarpToolStripMenuItem.Name = "_unwarpToolStripMenuItem"
         Me._unwarpToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
         Me._unwarpToolStripMenuItem.Text = "Un&Warp..."
         '
         'MainForm
         '
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(984, 631)
         Me.Controls.Add(Me._mainSplitContainer)
         Me.Controls.Add(Me._mainStatusStrip)
         Me.Controls.Add(Me._mainToolStrip)
         Me.Controls.Add(Me._mainMenuStrip)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.MainMenuStrip = Me._mainMenuStrip
         Me.Name = "MainForm"
         Me.Text = "VB.NET OCR Demo"
         Me._mainMenuStrip.ResumeLayout(False)
         Me._mainMenuStrip.PerformLayout()
         Me._mainToolStrip.ResumeLayout(False)
         Me._mainToolStrip.PerformLayout()
         Me._mainStatusStrip.ResumeLayout(False)
         Me._mainStatusStrip.PerformLayout()
         Me._mainSplitContainer.Panel1.ResumeLayout(False)
         Me._mainSplitContainer.Panel2.ResumeLayout(False)
         'CType(Me._mainSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
         Me._mainSplitContainer.ResumeLayout(False)
         Me._viewerVertSplitContainer.Panel1.ResumeLayout(False)
         Me._viewerVertSplitContainer.Panel2.ResumeLayout(False)
         'CType(Me._viewerVertSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
         Me._viewerVertSplitContainer.ResumeLayout(False)
         Me._viewerHorzSplitContainer.Panel1.ResumeLayout(False)
         Me._viewerHorzSplitContainer.Panel2.ResumeLayout(False)
         'CType(Me._viewerHorzSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
         Me._viewerHorzSplitContainer.ResumeLayout(False)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _mainMenuStrip As System.Windows.Forms.MenuStrip
      Private WithEvents _fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _fileOpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _fileSep2ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private _fileScanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _scanSelectSourceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _scanAcquireToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _fileSep3ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _fileExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _editToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _editCopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _editPasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _viewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _viewZoomOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _viewZoomInToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _viewSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _viewFitWidthToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _viewFitPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _engineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _engineSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _engineComponentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _engineLanguagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _pageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _pageCloseCurrentPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _recognizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _helpAboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _mainToolStrip As System.Windows.Forms.ToolStrip
      Private WithEvents _openDocumentToolStripButton As System.Windows.Forms.ToolStripButton
      Private _toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _autoZoneDocumentToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _autoZonePageToolStripButton As System.Windows.Forms.ToolStripButton
      Private _mainStatusStrip As System.Windows.Forms.StatusStrip
      Private _preferencesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _preferencesUseProgressBarsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _timingDescriptionToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
      Private _timingToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
      Private _activeSpellCheckerDescriptionToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
      Private _activeSpellCheckerToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
      Private _fileSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _fileConvertLDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _recognizeOmrOptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _pageSaveProcessingImageToDiskToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _recognizeDocumentToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _recognizePageToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _saveDocumentToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _recognizeRecognizeDocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _recognizeRecognizePageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _ocrSep2ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _pageDetectPageLanguagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _mainSplitContainer As System.Windows.Forms.SplitContainer
      Private WithEvents _pagesControl As PagesControl.PagesControl
      Private _viewerVertSplitContainer As System.Windows.Forms.SplitContainer
      Private _viewerHorzSplitContainer As System.Windows.Forms.SplitContainer
      Private WithEvents _viewerControl As ViewerControl.ViewerControl
      Private _pageTextControl As PageTextControl.PageTextControl
      Private _documentInfoControl As DocumentInfoControl.DocumentInfoControl
      Private WithEvents _documentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _documentInsertPagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _documentCreateDocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _documentAddCurrentPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _documentRemoveCurrentPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _documentClearDocumentPagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _documentCloseDocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _recognizeSpellCheckEngineStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processAllPagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _processSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _processFlipToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processReverseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processRotate90ClockwiseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processRotate90CounterClockwiseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _processSep2ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private _processPreprocessToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processPreprocessGetDeskewAngleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processPreprocessGetRotateAngleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processPreprocessIsInvertedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _processPreprocessSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _processPreprocessDeskewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processPreprocessRotateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processPreprocessInvertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processPreprocessAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _documentCleanupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processAutoCropToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processDespeckleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processErodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processDilateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processUnditherTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processFixBrokenLettersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processLineRemoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _binarizationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processAutoBinarizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processDynamicBinarizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _brightnessToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processHisogramEqualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processAutoLevelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processContrastBrightnessIntensityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _zonesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _zonesAutoZoneDocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _zonesAutoZoneCurrentPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _zonesSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _zonesUpdateZonesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _zonesSep2ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _zonesLoadZonesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _zonesSaveZonesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _zonesSep3ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _manualPerspectiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _inversePerspectiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _perspectiveDeskewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _loadAllPagesZonesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _saveAllPagesZonesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _zonesSep4ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _clearAllPagesZonesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _zonesSep5ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _zonesShowZonesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _zonesShowZoneNamesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _documentSaveDocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _recognizeSaveAfterRecognizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _documentLoadDocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
      Private _dualPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processPageSplitterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _processExpandContentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _processSep3ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _fileSetPDFLoadResolutionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _pageSaveRecognizedDataAsXmlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _documentSaveRecognizedDataAsXmlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Friend WithEvents _unwarpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   End Class
End Namespace
