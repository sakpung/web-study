namespace OcrMultiEngineDemo
{
   partial class MainForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if(disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this._mainMenuStrip = new System.Windows.Forms.MenuStrip();
         this._fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._fileOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._fileCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._fileSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._fileConvertLDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._fileSep2ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._fileScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._scanSelectSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._scanAcquireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._fileSep3ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._fileExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._editCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._editPasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewZoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewZoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._viewFitWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewFitPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._engineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._engineSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._engineComponentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._engineLanguagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._pagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._pagesInsertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._pagesDeleteCurrentPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._pagesSaveProcessingImageToDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._pagesDetectPageLanguagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._pagesSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._pagesProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processAllPagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._processFlipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processReverseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processRotate90ClockwiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processRotate90CounterClockwiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processSep2ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._processPreprocessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processPreprocessGetDeskewAngleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processPreprocessGetRotateAngleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processPreprocessIsInvertedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processPreprocessSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._processPreprocessDeskewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processPreprocessRotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processPreprocessInvertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processPreprocessAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._documentCleanupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processAutoCropToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processDespeckleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processErodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processDilateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processUnditherTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processFixBrokenLettersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processLineRemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._binarizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processAutoBinarizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processDynamicBinarizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._brightnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processHisogramEqualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processAutoLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processContrastBrightnessIntensityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._dualPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processPageSplitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processExpandContentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this._manualPerspectiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._inversePerspectiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._perspectiveDeskewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._ocrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._ocrZonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._zonesAutoZoneDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._zonesAutoZoneCurrentPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._zonesSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._zonesUpdateZonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._zonesSep2ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._zonesLoadZonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._zonesSaveZonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._zonesSep3ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._loadAllPagesZonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._saveAllPagesZonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._zonesSep4ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._clearAllPagesZonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._zonesSep5ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._zonesShowZonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._zonesShowZoneNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._ocrSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._ocrRecognizeDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._ocrRecognizePageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._ocrSaveDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._ocrSep2ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._ocrShowRecognizedWordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._ocrSaveRecognizedDataAsXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._ocrSpellCheckEngineStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._ocrOmrOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._preferencesUseProgressBarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._helpAboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._mainToolStrip = new System.Windows.Forms.ToolStrip();
         this._openDocumentToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this._autoZoneDocumentToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._autoZonePageToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._recognizeDocumentToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._recognizePageToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._saveDocumentToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._mainStatusStrip = new System.Windows.Forms.StatusStrip();
         this._timingDescriptionToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
         this._timingToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
         this._cellIndexStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
         this._activeSpellCheckerDescriptionToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
         this._activeSpellCheckerToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
         this._mainSplitter = new System.Windows.Forms.Splitter();
         this._viewerControl = new OcrMultiEngineDemo.ViewerControl.ViewerControl();
         this._pagesControl = new OcrMultiEngineDemo.PagesControl.PagesControl();
         this._unwarpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._mainMenuStrip.SuspendLayout();
         this._mainToolStrip.SuspendLayout();
         this._mainStatusStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // _mainMenuStrip
         // 
         this._mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem,
            this._editToolStripMenuItem,
            this._viewToolStripMenuItem,
            this._engineToolStripMenuItem,
            this._pagesToolStripMenuItem,
            this._ocrToolStripMenuItem,
            this._preferencesToolStripMenuItem,
            this._helpToolStripMenuItem});
         resources.ApplyResources(this._mainMenuStrip, "_mainMenuStrip");
         this._mainMenuStrip.Name = "_mainMenuStrip";
         // 
         // _fileToolStripMenuItem
         // 
         this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileOpenToolStripMenuItem,
            this._fileCloseToolStripMenuItem,
            this._fileSep1ToolStripMenuItem,
            this._fileConvertLDToolStripMenuItem,
            this._fileSep2ToolStripMenuItem,
            this._fileScanToolStripMenuItem,
            this._fileSep3ToolStripMenuItem,
            this._fileExitToolStripMenuItem});
         this._fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
         resources.ApplyResources(this._fileToolStripMenuItem, "_fileToolStripMenuItem");
         this._fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this._fileToolStripMenuItem_DropDownOpening);
         // 
         // _fileOpenToolStripMenuItem
         // 
         this._fileOpenToolStripMenuItem.Image = global::OcrMultiEngineDemo.Properties.Resources.OpenDocument;
         this._fileOpenToolStripMenuItem.Name = "_fileOpenToolStripMenuItem";
         resources.ApplyResources(this._fileOpenToolStripMenuItem, "_fileOpenToolStripMenuItem");
         this._fileOpenToolStripMenuItem.Click += new System.EventHandler(this._fileOpenToolStripMenuItem_Click);
         // 
         // _fileCloseToolStripMenuItem
         // 
         this._fileCloseToolStripMenuItem.Name = "_fileCloseToolStripMenuItem";
         resources.ApplyResources(this._fileCloseToolStripMenuItem, "_fileCloseToolStripMenuItem");
         this._fileCloseToolStripMenuItem.Click += new System.EventHandler(this._fileCloseToolStripMenuItem_Click);
         // 
         // _fileSep1ToolStripMenuItem
         // 
         this._fileSep1ToolStripMenuItem.Name = "_fileSep1ToolStripMenuItem";
         resources.ApplyResources(this._fileSep1ToolStripMenuItem, "_fileSep1ToolStripMenuItem");
         // 
         // _fileConvertLDToolStripMenuItem
         // 
         this._fileConvertLDToolStripMenuItem.Name = "_fileConvertLDToolStripMenuItem";
         resources.ApplyResources(this._fileConvertLDToolStripMenuItem, "_fileConvertLDToolStripMenuItem");
         this._fileConvertLDToolStripMenuItem.Click += new System.EventHandler(this._fileConvertLDToolStripMenuItem_Click);
         // 
         // _fileSep2ToolStripMenuItem
         // 
         this._fileSep2ToolStripMenuItem.Name = "_fileSep2ToolStripMenuItem";
         resources.ApplyResources(this._fileSep2ToolStripMenuItem, "_fileSep2ToolStripMenuItem");
         // 
         // _fileScanToolStripMenuItem
         // 
         this._fileScanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._scanSelectSourceToolStripMenuItem,
            this._scanAcquireToolStripMenuItem});
         this._fileScanToolStripMenuItem.Name = "_fileScanToolStripMenuItem";
         resources.ApplyResources(this._fileScanToolStripMenuItem, "_fileScanToolStripMenuItem");
         // 
         // _scanSelectSourceToolStripMenuItem
         // 
         this._scanSelectSourceToolStripMenuItem.Name = "_scanSelectSourceToolStripMenuItem";
         resources.ApplyResources(this._scanSelectSourceToolStripMenuItem, "_scanSelectSourceToolStripMenuItem");
         this._scanSelectSourceToolStripMenuItem.Click += new System.EventHandler(this._scanSelectSourceToolStripMenuItem_Click);
         // 
         // _scanAcquireToolStripMenuItem
         // 
         this._scanAcquireToolStripMenuItem.Name = "_scanAcquireToolStripMenuItem";
         resources.ApplyResources(this._scanAcquireToolStripMenuItem, "_scanAcquireToolStripMenuItem");
         this._scanAcquireToolStripMenuItem.Click += new System.EventHandler(this._scanAcquireToolStripMenuItem_Click);
         // 
         // _fileSep3ToolStripMenuItem
         // 
         this._fileSep3ToolStripMenuItem.Name = "_fileSep3ToolStripMenuItem";
         resources.ApplyResources(this._fileSep3ToolStripMenuItem, "_fileSep3ToolStripMenuItem");
         // 
         // _fileExitToolStripMenuItem
         // 
         this._fileExitToolStripMenuItem.Name = "_fileExitToolStripMenuItem";
         resources.ApplyResources(this._fileExitToolStripMenuItem, "_fileExitToolStripMenuItem");
         this._fileExitToolStripMenuItem.Click += new System.EventHandler(this._fileExitToolStripMenuItem_Click);
         // 
         // _editToolStripMenuItem
         // 
         this._editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._editCopyToolStripMenuItem,
            this._editPasteToolStripMenuItem});
         this._editToolStripMenuItem.Name = "_editToolStripMenuItem";
         resources.ApplyResources(this._editToolStripMenuItem, "_editToolStripMenuItem");
         this._editToolStripMenuItem.DropDownOpening += new System.EventHandler(this._editToolStripMenuItem_DropDownOpening);
         // 
         // _editCopyToolStripMenuItem
         // 
         this._editCopyToolStripMenuItem.Name = "_editCopyToolStripMenuItem";
         resources.ApplyResources(this._editCopyToolStripMenuItem, "_editCopyToolStripMenuItem");
         this._editCopyToolStripMenuItem.Click += new System.EventHandler(this._editCopyToolStripMenuItem_Click);
         // 
         // _editPasteToolStripMenuItem
         // 
         this._editPasteToolStripMenuItem.Name = "_editPasteToolStripMenuItem";
         resources.ApplyResources(this._editPasteToolStripMenuItem, "_editPasteToolStripMenuItem");
         this._editPasteToolStripMenuItem.Click += new System.EventHandler(this._editPasteToolStripMenuItem_Click);
         // 
         // _viewToolStripMenuItem
         // 
         this._viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._viewZoomOutToolStripMenuItem,
            this._viewZoomInToolStripMenuItem,
            this._viewSep1ToolStripMenuItem,
            this._viewFitWidthToolStripMenuItem,
            this._viewFitPageToolStripMenuItem});
         this._viewToolStripMenuItem.Name = "_viewToolStripMenuItem";
         resources.ApplyResources(this._viewToolStripMenuItem, "_viewToolStripMenuItem");
         this._viewToolStripMenuItem.DropDownOpening += new System.EventHandler(this._viewToolStripMenuItem_DropDownOpening);
         // 
         // _viewZoomOutToolStripMenuItem
         // 
         this._viewZoomOutToolStripMenuItem.Image = global::OcrMultiEngineDemo.Properties.Resources.ZoomOut;
         this._viewZoomOutToolStripMenuItem.Name = "_viewZoomOutToolStripMenuItem";
         resources.ApplyResources(this._viewZoomOutToolStripMenuItem, "_viewZoomOutToolStripMenuItem");
         this._viewZoomOutToolStripMenuItem.Click += new System.EventHandler(this._viewZoomOutToolStripMenuItem_Click);
         // 
         // _viewZoomInToolStripMenuItem
         // 
         this._viewZoomInToolStripMenuItem.Image = global::OcrMultiEngineDemo.Properties.Resources.ZoomIn;
         this._viewZoomInToolStripMenuItem.Name = "_viewZoomInToolStripMenuItem";
         resources.ApplyResources(this._viewZoomInToolStripMenuItem, "_viewZoomInToolStripMenuItem");
         this._viewZoomInToolStripMenuItem.Click += new System.EventHandler(this._viewZoomInToolStripMenuItem_Click);
         // 
         // _viewSep1ToolStripMenuItem
         // 
         this._viewSep1ToolStripMenuItem.Name = "_viewSep1ToolStripMenuItem";
         resources.ApplyResources(this._viewSep1ToolStripMenuItem, "_viewSep1ToolStripMenuItem");
         // 
         // _viewFitWidthToolStripMenuItem
         // 
         this._viewFitWidthToolStripMenuItem.Image = global::OcrMultiEngineDemo.Properties.Resources.FitPageWidth;
         this._viewFitWidthToolStripMenuItem.Name = "_viewFitWidthToolStripMenuItem";
         resources.ApplyResources(this._viewFitWidthToolStripMenuItem, "_viewFitWidthToolStripMenuItem");
         this._viewFitWidthToolStripMenuItem.Click += new System.EventHandler(this._viewFitWidthToolStripMenuItem_Click);
         // 
         // _viewFitPageToolStripMenuItem
         // 
         this._viewFitPageToolStripMenuItem.Image = global::OcrMultiEngineDemo.Properties.Resources.FitPage;
         this._viewFitPageToolStripMenuItem.Name = "_viewFitPageToolStripMenuItem";
         resources.ApplyResources(this._viewFitPageToolStripMenuItem, "_viewFitPageToolStripMenuItem");
         this._viewFitPageToolStripMenuItem.Click += new System.EventHandler(this._viewFitPageToolStripMenuItem_Click);
         // 
         // _engineToolStripMenuItem
         // 
         this._engineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._engineSettingsToolStripMenuItem,
            this._engineComponentsToolStripMenuItem,
            this._engineLanguagesToolStripMenuItem});
         this._engineToolStripMenuItem.Name = "_engineToolStripMenuItem";
         resources.ApplyResources(this._engineToolStripMenuItem, "_engineToolStripMenuItem");
         // 
         // _engineSettingsToolStripMenuItem
         // 
         this._engineSettingsToolStripMenuItem.Name = "_engineSettingsToolStripMenuItem";
         resources.ApplyResources(this._engineSettingsToolStripMenuItem, "_engineSettingsToolStripMenuItem");
         this._engineSettingsToolStripMenuItem.Click += new System.EventHandler(this._engineSettingsToolStripMenuItem_Click);
         // 
         // _engineComponentsToolStripMenuItem
         // 
         this._engineComponentsToolStripMenuItem.Name = "_engineComponentsToolStripMenuItem";
         resources.ApplyResources(this._engineComponentsToolStripMenuItem, "_engineComponentsToolStripMenuItem");
         this._engineComponentsToolStripMenuItem.Click += new System.EventHandler(this._engineComponentsToolStripMenuItem_Click);
         // 
         // _engineLanguagesToolStripMenuItem
         // 
         this._engineLanguagesToolStripMenuItem.Name = "_engineLanguagesToolStripMenuItem";
         resources.ApplyResources(this._engineLanguagesToolStripMenuItem, "_engineLanguagesToolStripMenuItem");
         this._engineLanguagesToolStripMenuItem.Click += new System.EventHandler(this._engineLanguagesToolStripMenuItem_Click);
         // 
         // _pagesToolStripMenuItem
         // 
         this._pagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._pagesInsertToolStripMenuItem,
            this._pagesDeleteCurrentPageToolStripMenuItem,
            this._pagesSaveProcessingImageToDiskToolStripMenuItem,
            this._pagesDetectPageLanguagesToolStripMenuItem,
            this._pagesSep1ToolStripMenuItem,
            this._pagesProcessToolStripMenuItem});
         this._pagesToolStripMenuItem.Name = "_pagesToolStripMenuItem";
         resources.ApplyResources(this._pagesToolStripMenuItem, "_pagesToolStripMenuItem");
         this._pagesToolStripMenuItem.DropDownOpening += new System.EventHandler(this._pagesToolStripMenuItem_DropDownOpening);
         // 
         // _pagesInsertToolStripMenuItem
         // 
         this._pagesInsertToolStripMenuItem.Image = global::OcrMultiEngineDemo.Properties.Resources.InsertPage;
         this._pagesInsertToolStripMenuItem.Name = "_pagesInsertToolStripMenuItem";
         resources.ApplyResources(this._pagesInsertToolStripMenuItem, "_pagesInsertToolStripMenuItem");
         this._pagesInsertToolStripMenuItem.Click += new System.EventHandler(this._pagesInsertToolStripMenuItem_Click);
         // 
         // _pagesDeleteCurrentPageToolStripMenuItem
         // 
         this._pagesDeleteCurrentPageToolStripMenuItem.Image = global::OcrMultiEngineDemo.Properties.Resources.DeletePage;
         this._pagesDeleteCurrentPageToolStripMenuItem.Name = "_pagesDeleteCurrentPageToolStripMenuItem";
         resources.ApplyResources(this._pagesDeleteCurrentPageToolStripMenuItem, "_pagesDeleteCurrentPageToolStripMenuItem");
         this._pagesDeleteCurrentPageToolStripMenuItem.Click += new System.EventHandler(this._pagesDeleteCurrentPageToolStripMenuItem_Click);
         // 
         // _pagesSaveProcessingImageToDiskToolStripMenuItem
         // 
         this._pagesSaveProcessingImageToDiskToolStripMenuItem.Name = "_pagesSaveProcessingImageToDiskToolStripMenuItem";
         resources.ApplyResources(this._pagesSaveProcessingImageToDiskToolStripMenuItem, "_pagesSaveProcessingImageToDiskToolStripMenuItem");
         this._pagesSaveProcessingImageToDiskToolStripMenuItem.Click += new System.EventHandler(this._pagesSaveProcessingImageToDiskToolStripMenuItem_Click);
         // 
         // _pagesDetectPageLanguagesToolStripMenuItem
         // 
         this._pagesDetectPageLanguagesToolStripMenuItem.Name = "_pagesDetectPageLanguagesToolStripMenuItem";
         resources.ApplyResources(this._pagesDetectPageLanguagesToolStripMenuItem, "_pagesDetectPageLanguagesToolStripMenuItem");
         this._pagesDetectPageLanguagesToolStripMenuItem.Click += new System.EventHandler(this._pagesDetectPageLanguagesToolStripMenuItem_Click);
         // 
         // _pagesSep1ToolStripMenuItem
         // 
         this._pagesSep1ToolStripMenuItem.Name = "_pagesSep1ToolStripMenuItem";
         resources.ApplyResources(this._pagesSep1ToolStripMenuItem, "_pagesSep1ToolStripMenuItem");
         // 
         // _pagesProcessToolStripMenuItem
         // 
         this._pagesProcessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._processAllPagesToolStripMenuItem,
            this._processSep1ToolStripMenuItem,
            this._processFlipToolStripMenuItem,
            this._processReverseToolStripMenuItem,
            this._processRotate90ClockwiseToolStripMenuItem,
            this._processRotate90CounterClockwiseToolStripMenuItem,
            this._processSep2ToolStripMenuItem,
            this._processPreprocessToolStripMenuItem,
            this._documentCleanupToolStripMenuItem,
            this._binarizationToolStripMenuItem,
            this._brightnessToolStripMenuItem,
            this._dualPageToolStripMenuItem,
            this.toolStripSeparator1,
            this._manualPerspectiveToolStripMenuItem,
            this._inversePerspectiveToolStripMenuItem,
            this._perspectiveDeskewToolStripMenuItem,
            this._unwarpToolStripMenuItem});
         this._pagesProcessToolStripMenuItem.Name = "_pagesProcessToolStripMenuItem";
         resources.ApplyResources(this._pagesProcessToolStripMenuItem, "_pagesProcessToolStripMenuItem");
         // 
         // _processAllPagesToolStripMenuItem
         // 
         this._processAllPagesToolStripMenuItem.Name = "_processAllPagesToolStripMenuItem";
         resources.ApplyResources(this._processAllPagesToolStripMenuItem, "_processAllPagesToolStripMenuItem");
         this._processAllPagesToolStripMenuItem.Click += new System.EventHandler(this._processAllPagesToolStripMenuItem_Click);
         // 
         // _processSep1ToolStripMenuItem
         // 
         this._processSep1ToolStripMenuItem.Name = "_processSep1ToolStripMenuItem";
         resources.ApplyResources(this._processSep1ToolStripMenuItem, "_processSep1ToolStripMenuItem");
         // 
         // _processFlipToolStripMenuItem
         // 
         this._processFlipToolStripMenuItem.Name = "_processFlipToolStripMenuItem";
         resources.ApplyResources(this._processFlipToolStripMenuItem, "_processFlipToolStripMenuItem");
         this._processFlipToolStripMenuItem.Click += new System.EventHandler(this._processFlipToolStripMenuItem_Click);
         // 
         // _processReverseToolStripMenuItem
         // 
         this._processReverseToolStripMenuItem.Name = "_processReverseToolStripMenuItem";
         resources.ApplyResources(this._processReverseToolStripMenuItem, "_processReverseToolStripMenuItem");
         this._processReverseToolStripMenuItem.Click += new System.EventHandler(this._processReverseToolStripMenuItem_Click);
         // 
         // _processRotate90ClockwiseToolStripMenuItem
         // 
         this._processRotate90ClockwiseToolStripMenuItem.Name = "_processRotate90ClockwiseToolStripMenuItem";
         resources.ApplyResources(this._processRotate90ClockwiseToolStripMenuItem, "_processRotate90ClockwiseToolStripMenuItem");
         this._processRotate90ClockwiseToolStripMenuItem.Click += new System.EventHandler(this._processRotate90ClockwiseToolStripMenuItem_Click);
         // 
         // _processRotate90CounterClockwiseToolStripMenuItem
         // 
         this._processRotate90CounterClockwiseToolStripMenuItem.Name = "_processRotate90CounterClockwiseToolStripMenuItem";
         resources.ApplyResources(this._processRotate90CounterClockwiseToolStripMenuItem, "_processRotate90CounterClockwiseToolStripMenuItem");
         this._processRotate90CounterClockwiseToolStripMenuItem.Click += new System.EventHandler(this._processRotate90CounterClockwiseToolStripMenuItem_Click);
         // 
         // _processSep2ToolStripMenuItem
         // 
         this._processSep2ToolStripMenuItem.Name = "_processSep2ToolStripMenuItem";
         resources.ApplyResources(this._processSep2ToolStripMenuItem, "_processSep2ToolStripMenuItem");
         // 
         // _processPreprocessToolStripMenuItem
         // 
         this._processPreprocessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._processPreprocessGetDeskewAngleToolStripMenuItem,
            this._processPreprocessGetRotateAngleToolStripMenuItem,
            this._processPreprocessIsInvertedToolStripMenuItem,
            this._processPreprocessSep1ToolStripMenuItem,
            this._processPreprocessDeskewToolStripMenuItem,
            this._processPreprocessRotateToolStripMenuItem,
            this._processPreprocessInvertToolStripMenuItem,
            this._processPreprocessAllToolStripMenuItem});
         this._processPreprocessToolStripMenuItem.Name = "_processPreprocessToolStripMenuItem";
         resources.ApplyResources(this._processPreprocessToolStripMenuItem, "_processPreprocessToolStripMenuItem");
         // 
         // _processPreprocessGetDeskewAngleToolStripMenuItem
         // 
         this._processPreprocessGetDeskewAngleToolStripMenuItem.Name = "_processPreprocessGetDeskewAngleToolStripMenuItem";
         resources.ApplyResources(this._processPreprocessGetDeskewAngleToolStripMenuItem, "_processPreprocessGetDeskewAngleToolStripMenuItem");
         this._processPreprocessGetDeskewAngleToolStripMenuItem.Click += new System.EventHandler(this._processPreprocessGetDeskewAngleToolStripMenuItem_Click);
         // 
         // _processPreprocessGetRotateAngleToolStripMenuItem
         // 
         this._processPreprocessGetRotateAngleToolStripMenuItem.Name = "_processPreprocessGetRotateAngleToolStripMenuItem";
         resources.ApplyResources(this._processPreprocessGetRotateAngleToolStripMenuItem, "_processPreprocessGetRotateAngleToolStripMenuItem");
         this._processPreprocessGetRotateAngleToolStripMenuItem.Click += new System.EventHandler(this._processPreprocessGetRotateAngleToolStripMenuItem_Click);
         // 
         // _processPreprocessIsInvertedToolStripMenuItem
         // 
         this._processPreprocessIsInvertedToolStripMenuItem.Name = "_processPreprocessIsInvertedToolStripMenuItem";
         resources.ApplyResources(this._processPreprocessIsInvertedToolStripMenuItem, "_processPreprocessIsInvertedToolStripMenuItem");
         this._processPreprocessIsInvertedToolStripMenuItem.Click += new System.EventHandler(this._processPreprocessIsInvertedToolStripMenuItem_Click);
         // 
         // _processPreprocessSep1ToolStripMenuItem
         // 
         this._processPreprocessSep1ToolStripMenuItem.Name = "_processPreprocessSep1ToolStripMenuItem";
         resources.ApplyResources(this._processPreprocessSep1ToolStripMenuItem, "_processPreprocessSep1ToolStripMenuItem");
         // 
         // _processPreprocessDeskewToolStripMenuItem
         // 
         this._processPreprocessDeskewToolStripMenuItem.Name = "_processPreprocessDeskewToolStripMenuItem";
         resources.ApplyResources(this._processPreprocessDeskewToolStripMenuItem, "_processPreprocessDeskewToolStripMenuItem");
         this._processPreprocessDeskewToolStripMenuItem.Click += new System.EventHandler(this._processPreprocessDeskewToolStripMenuItem_Click);
         // 
         // _processPreprocessRotateToolStripMenuItem
         // 
         this._processPreprocessRotateToolStripMenuItem.Name = "_processPreprocessRotateToolStripMenuItem";
         resources.ApplyResources(this._processPreprocessRotateToolStripMenuItem, "_processPreprocessRotateToolStripMenuItem");
         this._processPreprocessRotateToolStripMenuItem.Click += new System.EventHandler(this._processPreprocessRotateToolStripMenuItem_Click);
         // 
         // _processPreprocessInvertToolStripMenuItem
         // 
         this._processPreprocessInvertToolStripMenuItem.Name = "_processPreprocessInvertToolStripMenuItem";
         resources.ApplyResources(this._processPreprocessInvertToolStripMenuItem, "_processPreprocessInvertToolStripMenuItem");
         this._processPreprocessInvertToolStripMenuItem.Click += new System.EventHandler(this._processPreprocessInvertToolStripMenuItem_Click);
         // 
         // _processPreprocessAllToolStripMenuItem
         // 
         this._processPreprocessAllToolStripMenuItem.Name = "_processPreprocessAllToolStripMenuItem";
         resources.ApplyResources(this._processPreprocessAllToolStripMenuItem, "_processPreprocessAllToolStripMenuItem");
         this._processPreprocessAllToolStripMenuItem.Click += new System.EventHandler(this._processPreprocessAllToolStripMenuItem_Click);
         // 
         // _documentCleanupToolStripMenuItem
         // 
         this._documentCleanupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._processAutoCropToolStripMenuItem,
            this._processDespeckleToolStripMenuItem,
            this._processErodeToolStripMenuItem,
            this._processDilateToolStripMenuItem,
            this._processUnditherTextToolStripMenuItem,
            this._processFixBrokenLettersToolStripMenuItem,
            this._processLineRemoveToolStripMenuItem});
         this._documentCleanupToolStripMenuItem.Name = "_documentCleanupToolStripMenuItem";
         resources.ApplyResources(this._documentCleanupToolStripMenuItem, "_documentCleanupToolStripMenuItem");
         this._documentCleanupToolStripMenuItem.DropDownOpening += new System.EventHandler(this._documentCleanupToolStripMenuItem_DropDownOpening);
         // 
         // _processAutoCropToolStripMenuItem
         // 
         this._processAutoCropToolStripMenuItem.Name = "_processAutoCropToolStripMenuItem";
         resources.ApplyResources(this._processAutoCropToolStripMenuItem, "_processAutoCropToolStripMenuItem");
         this._processAutoCropToolStripMenuItem.Click += new System.EventHandler(this._processAutoCropToolStripMenuItem_Click);
         // 
         // _processDespeckleToolStripMenuItem
         // 
         this._processDespeckleToolStripMenuItem.Name = "_processDespeckleToolStripMenuItem";
         resources.ApplyResources(this._processDespeckleToolStripMenuItem, "_processDespeckleToolStripMenuItem");
         this._processDespeckleToolStripMenuItem.Click += new System.EventHandler(this._processDespeckleToolStripMenuItem_Click);
         // 
         // _processErodeToolStripMenuItem
         // 
         this._processErodeToolStripMenuItem.Name = "_processErodeToolStripMenuItem";
         resources.ApplyResources(this._processErodeToolStripMenuItem, "_processErodeToolStripMenuItem");
         this._processErodeToolStripMenuItem.Click += new System.EventHandler(this._processErodeToolStripMenuItem_Click);
         // 
         // _processDilateToolStripMenuItem
         // 
         this._processDilateToolStripMenuItem.Name = "_processDilateToolStripMenuItem";
         resources.ApplyResources(this._processDilateToolStripMenuItem, "_processDilateToolStripMenuItem");
         this._processDilateToolStripMenuItem.Click += new System.EventHandler(this._processDilateToolStripMenuItem_Click);
         // 
         // _processUnditherTextToolStripMenuItem
         // 
         this._processUnditherTextToolStripMenuItem.Name = "_processUnditherTextToolStripMenuItem";
         resources.ApplyResources(this._processUnditherTextToolStripMenuItem, "_processUnditherTextToolStripMenuItem");
         this._processUnditherTextToolStripMenuItem.Click += new System.EventHandler(this._processUnditherTextToolStripMenuItem_Click);
         // 
         // _processFixBrokenLettersToolStripMenuItem
         // 
         this._processFixBrokenLettersToolStripMenuItem.Name = "_processFixBrokenLettersToolStripMenuItem";
         resources.ApplyResources(this._processFixBrokenLettersToolStripMenuItem, "_processFixBrokenLettersToolStripMenuItem");
         this._processFixBrokenLettersToolStripMenuItem.Click += new System.EventHandler(this._processFixBrokenLettersToolStripMenuItem_Click);
         // 
         // _processLineRemoveToolStripMenuItem
         // 
         this._processLineRemoveToolStripMenuItem.Name = "_processLineRemoveToolStripMenuItem";
         resources.ApplyResources(this._processLineRemoveToolStripMenuItem, "_processLineRemoveToolStripMenuItem");
         this._processLineRemoveToolStripMenuItem.Click += new System.EventHandler(this._processLineRemoveToolStripMenuItem_Click);
         // 
         // _binarizationToolStripMenuItem
         // 
         this._binarizationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._processAutoBinarizeToolStripMenuItem,
            this._processDynamicBinarizeToolStripMenuItem});
         this._binarizationToolStripMenuItem.Name = "_binarizationToolStripMenuItem";
         resources.ApplyResources(this._binarizationToolStripMenuItem, "_binarizationToolStripMenuItem");
         // 
         // _processAutoBinarizeToolStripMenuItem
         // 
         this._processAutoBinarizeToolStripMenuItem.Name = "_processAutoBinarizeToolStripMenuItem";
         resources.ApplyResources(this._processAutoBinarizeToolStripMenuItem, "_processAutoBinarizeToolStripMenuItem");
         this._processAutoBinarizeToolStripMenuItem.Click += new System.EventHandler(this._processAutoBinarizeToolStripMenuItem_Click);
         // 
         // _processDynamicBinarizeToolStripMenuItem
         // 
         this._processDynamicBinarizeToolStripMenuItem.Name = "_processDynamicBinarizeToolStripMenuItem";
         resources.ApplyResources(this._processDynamicBinarizeToolStripMenuItem, "_processDynamicBinarizeToolStripMenuItem");
         this._processDynamicBinarizeToolStripMenuItem.Click += new System.EventHandler(this._processDynamicBinarizeToolStripMenuItem_Click);
         // 
         // _brightnessToolStripMenuItem
         // 
         this._brightnessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._processHisogramEqualToolStripMenuItem,
            this._processAutoLevelToolStripMenuItem,
            this._processContrastBrightnessIntensityToolStripMenuItem});
         this._brightnessToolStripMenuItem.Name = "_brightnessToolStripMenuItem";
         resources.ApplyResources(this._brightnessToolStripMenuItem, "_brightnessToolStripMenuItem");
         // 
         // _processHisogramEqualToolStripMenuItem
         // 
         this._processHisogramEqualToolStripMenuItem.Name = "_processHisogramEqualToolStripMenuItem";
         resources.ApplyResources(this._processHisogramEqualToolStripMenuItem, "_processHisogramEqualToolStripMenuItem");
         this._processHisogramEqualToolStripMenuItem.Click += new System.EventHandler(this._processHisogramEqualToolStripMenuItem_Click);
         // 
         // _processAutoLevelToolStripMenuItem
         // 
         this._processAutoLevelToolStripMenuItem.Name = "_processAutoLevelToolStripMenuItem";
         resources.ApplyResources(this._processAutoLevelToolStripMenuItem, "_processAutoLevelToolStripMenuItem");
         this._processAutoLevelToolStripMenuItem.Click += new System.EventHandler(this._processAutoLevelToolStripMenuItem_Click);
         // 
         // _processContrastBrightnessIntensityToolStripMenuItem
         // 
         this._processContrastBrightnessIntensityToolStripMenuItem.Name = "_processContrastBrightnessIntensityToolStripMenuItem";
         resources.ApplyResources(this._processContrastBrightnessIntensityToolStripMenuItem, "_processContrastBrightnessIntensityToolStripMenuItem");
         this._processContrastBrightnessIntensityToolStripMenuItem.Click += new System.EventHandler(this._processContrastBrightnessIntensityToolStripMenuItem_Click);
         // 
         // _dualPageToolStripMenuItem
         // 
         this._dualPageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._processPageSplitterToolStripMenuItem,
            this._processExpandContentToolStripMenuItem});
         this._dualPageToolStripMenuItem.Name = "_dualPageToolStripMenuItem";
         resources.ApplyResources(this._dualPageToolStripMenuItem, "_dualPageToolStripMenuItem");
         // 
         // _processPageSplitterToolStripMenuItem
         // 
         this._processPageSplitterToolStripMenuItem.Name = "_processPageSplitterToolStripMenuItem";
         resources.ApplyResources(this._processPageSplitterToolStripMenuItem, "_processPageSplitterToolStripMenuItem");
         this._processPageSplitterToolStripMenuItem.Click += new System.EventHandler(this._processPageSplitterToolStripMenuItem_Click);
         // 
         // _processExpandContentToolStripMenuItem
         // 
         this._processExpandContentToolStripMenuItem.Name = "_processExpandContentToolStripMenuItem";
         resources.ApplyResources(this._processExpandContentToolStripMenuItem, "_processExpandContentToolStripMenuItem");
         this._processExpandContentToolStripMenuItem.Click += new System.EventHandler(this._processExpandContentToolStripMenuItem_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
         // 
         // _manualPerspectiveToolStripMenuItem
         // 
         this._manualPerspectiveToolStripMenuItem.Name = "_manualPerspectiveToolStripMenuItem";
         resources.ApplyResources(this._manualPerspectiveToolStripMenuItem, "_manualPerspectiveToolStripMenuItem");
         this._manualPerspectiveToolStripMenuItem.Click += new System.EventHandler(this._manualPerspectiveToolStripMenuItem_Click);
         // 
         // _inversePerspectiveToolStripMenuItem
         // 
         this._inversePerspectiveToolStripMenuItem.Name = "_inversePerspectiveToolStripMenuItem";
         resources.ApplyResources(this._inversePerspectiveToolStripMenuItem, "_inversePerspectiveToolStripMenuItem");
         this._inversePerspectiveToolStripMenuItem.Click += new System.EventHandler(this._inversePerspectiveToolStripMenuItem_Click);
         // 
         // _perspectiveDeskewToolStripMenuItem
         // 
         this._perspectiveDeskewToolStripMenuItem.Name = "_perspectiveDeskewToolStripMenuItem";
         resources.ApplyResources(this._perspectiveDeskewToolStripMenuItem, "_perspectiveDeskewToolStripMenuItem");
         this._perspectiveDeskewToolStripMenuItem.Click += new System.EventHandler(this._perspectiveDeskewToolStripMenuItem_Click);
         // 
         // _ocrToolStripMenuItem
         // 
         this._ocrToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ocrZonesToolStripMenuItem,
            this._ocrSep1ToolStripMenuItem,
            this._ocrRecognizeDocumentToolStripMenuItem,
            this._ocrRecognizePageToolStripMenuItem,
            this._ocrSaveDocumentToolStripMenuItem,
            this._ocrSep2ToolStripMenuItem,
            this._ocrShowRecognizedWordsToolStripMenuItem,
            this._ocrSaveRecognizedDataAsXmlToolStripMenuItem,
            this._ocrSpellCheckEngineStripMenuItem,
            this._ocrOmrOptionsToolStripMenuItem});
         this._ocrToolStripMenuItem.Name = "_ocrToolStripMenuItem";
         resources.ApplyResources(this._ocrToolStripMenuItem, "_ocrToolStripMenuItem");
         this._ocrToolStripMenuItem.DropDownOpening += new System.EventHandler(this._ocrToolStripMenuItem_DropDownOpening);
         // 
         // _ocrZonesToolStripMenuItem
         // 
         this._ocrZonesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._zonesAutoZoneDocumentToolStripMenuItem,
            this._zonesAutoZoneCurrentPageToolStripMenuItem,
            this._zonesSep1ToolStripMenuItem,
            this._zonesUpdateZonesToolStripMenuItem,
            this._zonesSep2ToolStripMenuItem,
            this._zonesLoadZonesToolStripMenuItem,
            this._zonesSaveZonesToolStripMenuItem,
            this._zonesSep3ToolStripMenuItem,
            this._loadAllPagesZonesToolStripMenuItem,
            this._saveAllPagesZonesToolStripMenuItem,
            this._zonesSep4ToolStripMenuItem,
            this._clearAllPagesZonesToolStripMenuItem,
            this._zonesSep5ToolStripMenuItem,
            this._zonesShowZonesToolStripMenuItem,
            this._zonesShowZoneNamesToolStripMenuItem});
         this._ocrZonesToolStripMenuItem.Name = "_ocrZonesToolStripMenuItem";
         resources.ApplyResources(this._ocrZonesToolStripMenuItem, "_ocrZonesToolStripMenuItem");
         this._ocrZonesToolStripMenuItem.DropDownOpening += new System.EventHandler(this._ocrZonesToolStripMenuItem_DropDownOpening);
         // 
         // _zonesAutoZoneDocumentToolStripMenuItem
         // 
         this._zonesAutoZoneDocumentToolStripMenuItem.Image = global::OcrMultiEngineDemo.Properties.Resources.AutoZoneDocument;
         this._zonesAutoZoneDocumentToolStripMenuItem.Name = "_zonesAutoZoneDocumentToolStripMenuItem";
         resources.ApplyResources(this._zonesAutoZoneDocumentToolStripMenuItem, "_zonesAutoZoneDocumentToolStripMenuItem");
         this._zonesAutoZoneDocumentToolStripMenuItem.Click += new System.EventHandler(this._zonesAutoZoneDocumentToolStripMenuItem_Click);
         // 
         // _zonesAutoZoneCurrentPageToolStripMenuItem
         // 
         this._zonesAutoZoneCurrentPageToolStripMenuItem.Image = global::OcrMultiEngineDemo.Properties.Resources.AutoZonePage;
         this._zonesAutoZoneCurrentPageToolStripMenuItem.Name = "_zonesAutoZoneCurrentPageToolStripMenuItem";
         resources.ApplyResources(this._zonesAutoZoneCurrentPageToolStripMenuItem, "_zonesAutoZoneCurrentPageToolStripMenuItem");
         this._zonesAutoZoneCurrentPageToolStripMenuItem.Click += new System.EventHandler(this._zonesAutoZoneCurrentPageToolStripMenuItem_Click);
         // 
         // _zonesSep1ToolStripMenuItem
         // 
         this._zonesSep1ToolStripMenuItem.Name = "_zonesSep1ToolStripMenuItem";
         resources.ApplyResources(this._zonesSep1ToolStripMenuItem, "_zonesSep1ToolStripMenuItem");
         // 
         // _zonesUpdateZonesToolStripMenuItem
         // 
         this._zonesUpdateZonesToolStripMenuItem.Image = global::OcrMultiEngineDemo.Properties.Resources.ZoneProperties;
         this._zonesUpdateZonesToolStripMenuItem.Name = "_zonesUpdateZonesToolStripMenuItem";
         resources.ApplyResources(this._zonesUpdateZonesToolStripMenuItem, "_zonesUpdateZonesToolStripMenuItem");
         this._zonesUpdateZonesToolStripMenuItem.Click += new System.EventHandler(this._zonesUpdateZonesToolStripMenuItem_Click);
         // 
         // _zonesSep2ToolStripMenuItem
         // 
         this._zonesSep2ToolStripMenuItem.Name = "_zonesSep2ToolStripMenuItem";
         resources.ApplyResources(this._zonesSep2ToolStripMenuItem, "_zonesSep2ToolStripMenuItem");
         // 
         // _zonesLoadZonesToolStripMenuItem
         // 
         this._zonesLoadZonesToolStripMenuItem.Name = "_zonesLoadZonesToolStripMenuItem";
         resources.ApplyResources(this._zonesLoadZonesToolStripMenuItem, "_zonesLoadZonesToolStripMenuItem");
         this._zonesLoadZonesToolStripMenuItem.Click += new System.EventHandler(this._zonesLoadZonesToolStripMenuItem_Click);
         // 
         // _zonesSaveZonesToolStripMenuItem
         // 
         this._zonesSaveZonesToolStripMenuItem.Name = "_zonesSaveZonesToolStripMenuItem";
         resources.ApplyResources(this._zonesSaveZonesToolStripMenuItem, "_zonesSaveZonesToolStripMenuItem");
         this._zonesSaveZonesToolStripMenuItem.Click += new System.EventHandler(this._zonesSaveZonesToolStripMenuItem_Click);
         // 
         // _zonesSep3ToolStripMenuItem
         // 
         this._zonesSep3ToolStripMenuItem.Name = "_zonesSep3ToolStripMenuItem";
         resources.ApplyResources(this._zonesSep3ToolStripMenuItem, "_zonesSep3ToolStripMenuItem");
         // 
         // _loadAllPagesZonesToolStripMenuItem
         // 
         this._loadAllPagesZonesToolStripMenuItem.Name = "_loadAllPagesZonesToolStripMenuItem";
         resources.ApplyResources(this._loadAllPagesZonesToolStripMenuItem, "_loadAllPagesZonesToolStripMenuItem");
         this._loadAllPagesZonesToolStripMenuItem.Click += new System.EventHandler(this._loadAllPagesZonesToolStripMenuItem_Click);
         // 
         // _saveAllPagesZonesToolStripMenuItem
         // 
         this._saveAllPagesZonesToolStripMenuItem.Name = "_saveAllPagesZonesToolStripMenuItem";
         resources.ApplyResources(this._saveAllPagesZonesToolStripMenuItem, "_saveAllPagesZonesToolStripMenuItem");
         this._saveAllPagesZonesToolStripMenuItem.Click += new System.EventHandler(this._saveAllPagesZonesToolStripMenuItem_Click);
         // 
         // _zonesSep4ToolStripMenuItem
         // 
         this._zonesSep4ToolStripMenuItem.Name = "_zonesSep4ToolStripMenuItem";
         resources.ApplyResources(this._zonesSep4ToolStripMenuItem, "_zonesSep4ToolStripMenuItem");
         // 
         // _clearAllPagesZonesToolStripMenuItem
         // 
         this._clearAllPagesZonesToolStripMenuItem.Name = "_clearAllPagesZonesToolStripMenuItem";
         resources.ApplyResources(this._clearAllPagesZonesToolStripMenuItem, "_clearAllPagesZonesToolStripMenuItem");
         this._clearAllPagesZonesToolStripMenuItem.Click += new System.EventHandler(this._clearAllPagesZonesToolStripMenuItem_Click);
         // 
         // _zonesSep5ToolStripMenuItem
         // 
         this._zonesSep5ToolStripMenuItem.Name = "_zonesSep5ToolStripMenuItem";
         resources.ApplyResources(this._zonesSep5ToolStripMenuItem, "_zonesSep5ToolStripMenuItem");
         // 
         // _zonesShowZonesToolStripMenuItem
         // 
         this._zonesShowZonesToolStripMenuItem.Image = global::OcrMultiEngineDemo.Properties.Resources.ShowZones;
         this._zonesShowZonesToolStripMenuItem.Name = "_zonesShowZonesToolStripMenuItem";
         resources.ApplyResources(this._zonesShowZonesToolStripMenuItem, "_zonesShowZonesToolStripMenuItem");
         this._zonesShowZonesToolStripMenuItem.Click += new System.EventHandler(this._zonesShowZonesToolStripMenuItem_Click);
         // 
         // _zonesShowZoneNamesToolStripMenuItem
         // 
         this._zonesShowZoneNamesToolStripMenuItem.Image = global::OcrMultiEngineDemo.Properties.Resources.ShowZoneName;
         this._zonesShowZoneNamesToolStripMenuItem.Name = "_zonesShowZoneNamesToolStripMenuItem";
         resources.ApplyResources(this._zonesShowZoneNamesToolStripMenuItem, "_zonesShowZoneNamesToolStripMenuItem");
         this._zonesShowZoneNamesToolStripMenuItem.Click += new System.EventHandler(this._zonesShowZoneNamesToolStripMenuItem_Click);
         // 
         // _ocrSep1ToolStripMenuItem
         // 
         this._ocrSep1ToolStripMenuItem.Name = "_ocrSep1ToolStripMenuItem";
         resources.ApplyResources(this._ocrSep1ToolStripMenuItem, "_ocrSep1ToolStripMenuItem");
         // 
         // _ocrRecognizeDocumentToolStripMenuItem
         // 
         this._ocrRecognizeDocumentToolStripMenuItem.Image = global::OcrMultiEngineDemo.Properties.Resources.RecognizeAllPages;
         this._ocrRecognizeDocumentToolStripMenuItem.Name = "_ocrRecognizeDocumentToolStripMenuItem";
         resources.ApplyResources(this._ocrRecognizeDocumentToolStripMenuItem, "_ocrRecognizeDocumentToolStripMenuItem");
         this._ocrRecognizeDocumentToolStripMenuItem.Click += new System.EventHandler(this._ocrRecognizeDocumentToolStripMenuItem_Click);
         // 
         // _ocrRecognizePageToolStripMenuItem
         // 
         this._ocrRecognizePageToolStripMenuItem.Image = global::OcrMultiEngineDemo.Properties.Resources.RecognizePage;
         this._ocrRecognizePageToolStripMenuItem.Name = "_ocrRecognizePageToolStripMenuItem";
         resources.ApplyResources(this._ocrRecognizePageToolStripMenuItem, "_ocrRecognizePageToolStripMenuItem");
         this._ocrRecognizePageToolStripMenuItem.Click += new System.EventHandler(this._ocrRecognizePageToolStripMenuItem_Click);
         // 
         // _ocrSaveDocumentToolStripMenuItem
         // 
         this._ocrSaveDocumentToolStripMenuItem.Image = global::OcrMultiEngineDemo.Properties.Resources.SaveDocument;
         this._ocrSaveDocumentToolStripMenuItem.Name = "_ocrSaveDocumentToolStripMenuItem";
         resources.ApplyResources(this._ocrSaveDocumentToolStripMenuItem, "_ocrSaveDocumentToolStripMenuItem");
         this._ocrSaveDocumentToolStripMenuItem.Click += new System.EventHandler(this._ocrSaveDocumentToolStripMenuItem_Click);
         // 
         // _ocrSep2ToolStripMenuItem
         // 
         this._ocrSep2ToolStripMenuItem.Name = "_ocrSep2ToolStripMenuItem";
         resources.ApplyResources(this._ocrSep2ToolStripMenuItem, "_ocrSep2ToolStripMenuItem");
         // 
         // _ocrShowRecognizedWordsToolStripMenuItem
         // 
         this._ocrShowRecognizedWordsToolStripMenuItem.Name = "_ocrShowRecognizedWordsToolStripMenuItem";
         resources.ApplyResources(this._ocrShowRecognizedWordsToolStripMenuItem, "_ocrShowRecognizedWordsToolStripMenuItem");
         this._ocrShowRecognizedWordsToolStripMenuItem.Click += new System.EventHandler(this._ocrShowRecognizedWordsToolStripMenuItem_Click);
         // 
         // _ocrSaveRecognizedDataAsXmlToolStripMenuItem
         // 
         this._ocrSaveRecognizedDataAsXmlToolStripMenuItem.Name = "_ocrSaveRecognizedDataAsXmlToolStripMenuItem";
         resources.ApplyResources(this._ocrSaveRecognizedDataAsXmlToolStripMenuItem, "_ocrSaveRecognizedDataAsXmlToolStripMenuItem");
         this._ocrSaveRecognizedDataAsXmlToolStripMenuItem.Click += new System.EventHandler(this._ocrSaveRecognizedDataAsXmlToolStripMenuItem_Click);
         // 
         // _ocrSpellCheckEngineStripMenuItem
         // 
         this._ocrSpellCheckEngineStripMenuItem.Name = "_ocrSpellCheckEngineStripMenuItem";
         resources.ApplyResources(this._ocrSpellCheckEngineStripMenuItem, "_ocrSpellCheckEngineStripMenuItem");
         this._ocrSpellCheckEngineStripMenuItem.Click += new System.EventHandler(this._ocrSpellCheckEngineStripMenuItem_Click);
         // 
         // _ocrOmrOptionsToolStripMenuItem
         // 
         this._ocrOmrOptionsToolStripMenuItem.Name = "_ocrOmrOptionsToolStripMenuItem";
         resources.ApplyResources(this._ocrOmrOptionsToolStripMenuItem, "_ocrOmrOptionsToolStripMenuItem");
         this._ocrOmrOptionsToolStripMenuItem.Click += new System.EventHandler(this._ocrOmrOptionsToolStripMenuItem_Click);
         // 
         // _preferencesToolStripMenuItem
         // 
         this._preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._preferencesUseProgressBarsToolStripMenuItem});
         this._preferencesToolStripMenuItem.Name = "_preferencesToolStripMenuItem";
         resources.ApplyResources(this._preferencesToolStripMenuItem, "_preferencesToolStripMenuItem");
         // 
         // _preferencesUseProgressBarsToolStripMenuItem
         // 
         this._preferencesUseProgressBarsToolStripMenuItem.Name = "_preferencesUseProgressBarsToolStripMenuItem";
         resources.ApplyResources(this._preferencesUseProgressBarsToolStripMenuItem, "_preferencesUseProgressBarsToolStripMenuItem");
         this._preferencesUseProgressBarsToolStripMenuItem.Click += new System.EventHandler(this._preferencesUseProgressBarsToolStripMenuItem_Click);
         // 
         // _helpToolStripMenuItem
         // 
         this._helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._helpAboutToolStripMenuItem});
         this._helpToolStripMenuItem.Name = "_helpToolStripMenuItem";
         resources.ApplyResources(this._helpToolStripMenuItem, "_helpToolStripMenuItem");
         // 
         // _helpAboutToolStripMenuItem
         // 
         this._helpAboutToolStripMenuItem.Name = "_helpAboutToolStripMenuItem";
         resources.ApplyResources(this._helpAboutToolStripMenuItem, "_helpAboutToolStripMenuItem");
         this._helpAboutToolStripMenuItem.Click += new System.EventHandler(this._helpAboutToolStripMenuItem_Click);
         // 
         // _mainToolStrip
         // 
         this._mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openDocumentToolStripButton,
            this._toolStripSeparator1,
            this._autoZoneDocumentToolStripButton,
            this._autoZonePageToolStripButton,
            this._recognizeDocumentToolStripButton,
            this._recognizePageToolStripButton,
            this._saveDocumentToolStripButton});
         resources.ApplyResources(this._mainToolStrip, "_mainToolStrip");
         this._mainToolStrip.Name = "_mainToolStrip";
         // 
         // _openDocumentToolStripButton
         // 
         this._openDocumentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._openDocumentToolStripButton.Image = global::OcrMultiEngineDemo.Properties.Resources.OpenDocument;
         resources.ApplyResources(this._openDocumentToolStripButton, "_openDocumentToolStripButton");
         this._openDocumentToolStripButton.Name = "_openDocumentToolStripButton";
         this._openDocumentToolStripButton.Click += new System.EventHandler(this._openDocumentToolStripButton_Click);
         // 
         // _toolStripSeparator1
         // 
         this._toolStripSeparator1.Name = "_toolStripSeparator1";
         resources.ApplyResources(this._toolStripSeparator1, "_toolStripSeparator1");
         // 
         // _autoZoneDocumentToolStripButton
         // 
         this._autoZoneDocumentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._autoZoneDocumentToolStripButton.Image = global::OcrMultiEngineDemo.Properties.Resources.AutoZoneDocument;
         resources.ApplyResources(this._autoZoneDocumentToolStripButton, "_autoZoneDocumentToolStripButton");
         this._autoZoneDocumentToolStripButton.Name = "_autoZoneDocumentToolStripButton";
         this._autoZoneDocumentToolStripButton.Click += new System.EventHandler(this._autoZoneDocumentToolStripButton_Click);
         // 
         // _autoZonePageToolStripButton
         // 
         this._autoZonePageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._autoZonePageToolStripButton.Image = global::OcrMultiEngineDemo.Properties.Resources.AutoZonePage;
         resources.ApplyResources(this._autoZonePageToolStripButton, "_autoZonePageToolStripButton");
         this._autoZonePageToolStripButton.Name = "_autoZonePageToolStripButton";
         this._autoZonePageToolStripButton.Click += new System.EventHandler(this._autoZonePageToolStripButton_Click);
         // 
         // _recognizeDocumentToolStripButton
         // 
         this._recognizeDocumentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._recognizeDocumentToolStripButton.Image = global::OcrMultiEngineDemo.Properties.Resources.RecognizeAllPages;
         resources.ApplyResources(this._recognizeDocumentToolStripButton, "_recognizeDocumentToolStripButton");
         this._recognizeDocumentToolStripButton.Name = "_recognizeDocumentToolStripButton";
         this._recognizeDocumentToolStripButton.Click += new System.EventHandler(this._recognizeDocumentToolStripButton_Click);
         // 
         // _recognizePageToolStripButton
         // 
         this._recognizePageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._recognizePageToolStripButton.Image = global::OcrMultiEngineDemo.Properties.Resources.RecognizePage;
         resources.ApplyResources(this._recognizePageToolStripButton, "_recognizePageToolStripButton");
         this._recognizePageToolStripButton.Name = "_recognizePageToolStripButton";
         this._recognizePageToolStripButton.Click += new System.EventHandler(this._recognizePageToolStripButton_Click);
         // 
         // _saveDocumentToolStripButton
         // 
         this._saveDocumentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._saveDocumentToolStripButton.Image = global::OcrMultiEngineDemo.Properties.Resources.SaveDocument;
         resources.ApplyResources(this._saveDocumentToolStripButton, "_saveDocumentToolStripButton");
         this._saveDocumentToolStripButton.Name = "_saveDocumentToolStripButton";
         this._saveDocumentToolStripButton.Click += new System.EventHandler(this._saveDocumentToolStripButton_Click);
         // 
         // _mainStatusStrip
         // 
         this._mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._timingDescriptionToolStripStatusLabel,
            this._timingToolStripStatusLabel,
            this._cellIndexStatusLabel,
            this._activeSpellCheckerDescriptionToolStripStatusLabel,
            this._activeSpellCheckerToolStripStatusLabel});
         resources.ApplyResources(this._mainStatusStrip, "_mainStatusStrip");
         this._mainStatusStrip.Name = "_mainStatusStrip";
         // 
         // _timingDescriptionToolStripStatusLabel
         // 
         this._timingDescriptionToolStripStatusLabel.Name = "_timingDescriptionToolStripStatusLabel";
         resources.ApplyResources(this._timingDescriptionToolStripStatusLabel, "_timingDescriptionToolStripStatusLabel");
         // 
         // _timingToolStripStatusLabel
         // 
         resources.ApplyResources(this._timingToolStripStatusLabel, "_timingToolStripStatusLabel");
         this._timingToolStripStatusLabel.Name = "_timingToolStripStatusLabel";
         // 
         // _cellIndexStatusLabel
         // 
         this._cellIndexStatusLabel.Name = "_cellIndexStatusLabel";
         resources.ApplyResources(this._cellIndexStatusLabel, "_cellIndexStatusLabel");
         // 
         // _activeSpellCheckerDescriptionToolStripStatusLabel
         // 
         this._activeSpellCheckerDescriptionToolStripStatusLabel.Name = "_activeSpellCheckerDescriptionToolStripStatusLabel";
         resources.ApplyResources(this._activeSpellCheckerDescriptionToolStripStatusLabel, "_activeSpellCheckerDescriptionToolStripStatusLabel");
         // 
         // _activeSpellCheckerToolStripStatusLabel
         // 
         this._activeSpellCheckerToolStripStatusLabel.Name = "_activeSpellCheckerToolStripStatusLabel";
         resources.ApplyResources(this._activeSpellCheckerToolStripStatusLabel, "_activeSpellCheckerToolStripStatusLabel");
         // 
         // _mainSplitter
         // 
         resources.ApplyResources(this._mainSplitter, "_mainSplitter");
         this._mainSplitter.Name = "_mainSplitter";
         this._mainSplitter.TabStop = false;
         // 
         // _viewerControl
         // 
         resources.ApplyResources(this._viewerControl, "_viewerControl");
         this._viewerControl.Name = "_viewerControl";
         this._viewerControl.Action += new System.EventHandler<OcrMultiEngineDemo.ActionEventArgs>(this._viewerControl_Action);
         // 
         // _pagesControl
         // 
         resources.ApplyResources(this._pagesControl, "_pagesControl");
         this._pagesControl.Name = "_pagesControl";
         this._pagesControl.Action += new System.EventHandler<OcrMultiEngineDemo.ActionEventArgs>(this._pagesControl_Action);
         // 
         // _unwarpToolStripMenuItem
         // 
         this._unwarpToolStripMenuItem.Name = "_unwarpToolStripMenuItem";
         resources.ApplyResources(this._unwarpToolStripMenuItem, "_unwarpToolStripMenuItem");
         this._unwarpToolStripMenuItem.Click += new System.EventHandler(this._unwarpToolStripMenuItem_Click);
         // 
         // MainForm
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._viewerControl);
         this.Controls.Add(this._mainSplitter);
         this.Controls.Add(this._pagesControl);
         this.Controls.Add(this._mainStatusStrip);
         this.Controls.Add(this._mainToolStrip);
         this.Controls.Add(this._mainMenuStrip);
         this.MainMenuStrip = this._mainMenuStrip;
         this.Name = "MainForm";
         this.Resize += new System.EventHandler(this.MainForm_Resize);
         this._mainMenuStrip.ResumeLayout(false);
         this._mainMenuStrip.PerformLayout();
         this._mainToolStrip.ResumeLayout(false);
         this._mainToolStrip.PerformLayout();
         this._mainStatusStrip.ResumeLayout(false);
         this._mainStatusStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip _mainMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fileOpenToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fileCloseToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _fileSep2ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fileScanToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _scanSelectSourceToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _scanAcquireToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _fileSep3ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fileExitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _editToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _editCopyToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _editPasteToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewZoomOutToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewZoomInToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _viewSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewFitWidthToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewFitPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _engineToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _engineSettingsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _engineComponentsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _engineLanguagesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _pagesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _pagesInsertToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _pagesDeleteCurrentPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _pagesSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _pagesProcessToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processFlipToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processRotate90ClockwiseToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _ocrToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _ocrZonesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _zonesAutoZoneDocumentToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _zonesAutoZoneCurrentPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _zonesSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _zonesUpdateZonesToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _zonesSep2ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _zonesLoadZonesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _zonesSaveZonesToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _zonesSep5ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _zonesShowZonesToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _ocrSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _helpToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _helpAboutToolStripMenuItem;
      private System.Windows.Forms.ToolStrip _mainToolStrip;
      private System.Windows.Forms.ToolStripButton _openDocumentToolStripButton;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton _autoZoneDocumentToolStripButton;
      private System.Windows.Forms.ToolStripButton _autoZonePageToolStripButton;
      private System.Windows.Forms.StatusStrip _mainStatusStrip;
      private OcrMultiEngineDemo.PagesControl.PagesControl _pagesControl;
      private System.Windows.Forms.Splitter _mainSplitter;
      private OcrMultiEngineDemo.ViewerControl.ViewerControl _viewerControl;
      private System.Windows.Forms.ToolStripMenuItem _processAllPagesToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _processSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processReverseToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processRotate90CounterClockwiseToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _ocrShowRecognizedWordsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _preferencesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _preferencesUseProgressBarsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _zonesShowZoneNamesToolStripMenuItem;
      private System.Windows.Forms.ToolStripStatusLabel _timingToolStripStatusLabel;
      private System.Windows.Forms.ToolStripStatusLabel _timingDescriptionToolStripStatusLabel;
      private System.Windows.Forms.ToolStripSeparator _fileSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fileConvertLDToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _ocrOmrOptionsToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _processSep2ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processPreprocessToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processPreprocessGetDeskewAngleToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processPreprocessGetRotateAngleToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processPreprocessIsInvertedToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _processPreprocessSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processPreprocessDeskewToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processPreprocessRotateToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processPreprocessInvertToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processPreprocessAllToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _zonesSep3ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _loadAllPagesZonesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _saveAllPagesZonesToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _zonesSep4ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _clearAllPagesZonesToolStripMenuItem;
      private System.Windows.Forms.ToolStripStatusLabel _cellIndexStatusLabel;
      private System.Windows.Forms.ToolStripMenuItem _ocrSaveRecognizedDataAsXmlToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _pagesSaveProcessingImageToDiskToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _ocrSpellCheckEngineStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _documentCleanupToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processAutoCropToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processDespeckleToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processErodeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processDilateToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processUnditherTextToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processFixBrokenLettersToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _binarizationToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processAutoBinarizeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processDynamicBinarizeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _brightnessToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processHisogramEqualToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processAutoLevelToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processContrastBrightnessIntensityToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _dualPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processPageSplitterToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processExpandContentToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processLineRemoveToolStripMenuItem;
      private System.Windows.Forms.ToolStripButton _recognizeDocumentToolStripButton;
      private System.Windows.Forms.ToolStripButton _recognizePageToolStripButton;
      private System.Windows.Forms.ToolStripButton _saveDocumentToolStripButton;
      private System.Windows.Forms.ToolStripMenuItem _ocrRecognizeDocumentToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _ocrRecognizePageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _ocrSaveDocumentToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _ocrSep2ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _pagesDetectPageLanguagesToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem _manualPerspectiveToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _inversePerspectiveToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _perspectiveDeskewToolStripMenuItem;
      private System.Windows.Forms.ToolStripStatusLabel _activeSpellCheckerDescriptionToolStripStatusLabel;
      private System.Windows.Forms.ToolStripStatusLabel _activeSpellCheckerToolStripStatusLabel;
      private System.Windows.Forms.ToolStripMenuItem _unwarpToolStripMenuItem;
   }
}

