namespace OcrDemo
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
         this._fileSetPDFLoadResolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
         this._pageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._pageSaveProcessingImageToDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._pageDetectPageLanguagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._pageSaveRecognizedDataAsXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._pageCloseCurrentPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._processToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
         this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
         this._manualPerspectiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._inversePerspectiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._perspectiveDeskewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._unwarpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._zonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
         this._recognizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._recognizeRecognizeDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._recognizeRecognizePageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._ocrSep2ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._recognizeSpellCheckEngineStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._recognizeOmrOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this._recognizeSaveAfterRecognizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._documentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._documentCreateDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._documentLoadDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this._documentAddCurrentPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._documentInsertPagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._documentRemoveCurrentPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._documentClearDocumentPagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this._documentSaveDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._documentSaveRecognizedDataAsXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
         this._documentCloseDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
         this._activeSpellCheckerDescriptionToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
         this._activeSpellCheckerToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
         this._mainSplitContainer = new System.Windows.Forms.SplitContainer();
         this._pagesControl = new OcrDemo.PagesControl.PagesControl();
         this._viewerVertSplitContainer = new System.Windows.Forms.SplitContainer();
         this._viewerHorzSplitContainer = new System.Windows.Forms.SplitContainer();
         this._viewerControl = new OcrDemo.ViewerControl.ViewerControl();
         this._pageTextControl = new OcrDemo.PageTextControl.PageTextControl();
         this._documentInfoControl = new OcrDemo.DocumentInfoControl.DocumentInfoControl();
         this._mainMenuStrip.SuspendLayout();
         this._mainToolStrip.SuspendLayout();
         this._mainStatusStrip.SuspendLayout();
         //((System.ComponentModel.ISupportInitialize)(this._mainSplitContainer)).BeginInit();
         this._mainSplitContainer.Panel1.SuspendLayout();
         this._mainSplitContainer.Panel2.SuspendLayout();
         this._mainSplitContainer.SuspendLayout();
         //((System.ComponentModel.ISupportInitialize)(this._viewerVertSplitContainer)).BeginInit();
         this._viewerVertSplitContainer.Panel1.SuspendLayout();
         this._viewerVertSplitContainer.Panel2.SuspendLayout();
         this._viewerVertSplitContainer.SuspendLayout();
         //((System.ComponentModel.ISupportInitialize)(this._viewerHorzSplitContainer)).BeginInit();
         this._viewerHorzSplitContainer.Panel1.SuspendLayout();
         this._viewerHorzSplitContainer.Panel2.SuspendLayout();
         this._viewerHorzSplitContainer.SuspendLayout();
         this.SuspendLayout();
         // 
         // _mainMenuStrip
         // 
         this._mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem,
            this._editToolStripMenuItem,
            this._viewToolStripMenuItem,
            this._engineToolStripMenuItem,
            this._pageToolStripMenuItem,
            this._processToolStripMenuItem,
            this._zonesToolStripMenuItem,
            this._recognizeToolStripMenuItem,
            this._documentToolStripMenuItem,
            this._preferencesToolStripMenuItem,
            this._helpToolStripMenuItem});
         this._mainMenuStrip.Location = new System.Drawing.Point(0, 0);
         this._mainMenuStrip.Name = "_mainMenuStrip";
         this._mainMenuStrip.Size = new System.Drawing.Size(984, 24);
         this._mainMenuStrip.TabIndex = 0;
         this._mainMenuStrip.Text = "menuStrip1";
         // 
         // _fileToolStripMenuItem
         // 
         this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileOpenToolStripMenuItem,
            this._fileSetPDFLoadResolutionToolStripMenuItem,
            this._fileSep1ToolStripMenuItem,
            this._fileConvertLDToolStripMenuItem,
            this._fileSep2ToolStripMenuItem,
            this._fileScanToolStripMenuItem,
            this._fileSep3ToolStripMenuItem,
            this._fileExitToolStripMenuItem});
         this._fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
         this._fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this._fileToolStripMenuItem.Text = "&File";
         this._fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this._fileToolStripMenuItem_DropDownOpening);
         // 
         // _fileOpenToolStripMenuItem
         // 
         this._fileOpenToolStripMenuItem.Image = global::OcrDemo.Properties.Resources.OpenDocument;
         this._fileOpenToolStripMenuItem.Name = "_fileOpenToolStripMenuItem";
         this._fileOpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
         this._fileOpenToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
         this._fileOpenToolStripMenuItem.Text = "&Open...";
         this._fileOpenToolStripMenuItem.Click += new System.EventHandler(this._fileOpenToolStripMenuItem_Click);
         // 
         // _fileSetPDFLoadResolutionToolStripMenuItem
         // 
         this._fileSetPDFLoadResolutionToolStripMenuItem.Name = "_fileSetPDFLoadResolutionToolStripMenuItem";
         this._fileSetPDFLoadResolutionToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
         this._fileSetPDFLoadResolutionToolStripMenuItem.Text = "Set PDF Load &Resolution...";
         this._fileSetPDFLoadResolutionToolStripMenuItem.Click += new System.EventHandler(this._fileSetPDFLoadResolutionToolStripMenuItem_Click);
         // 
         // _fileSep1ToolStripMenuItem
         // 
         this._fileSep1ToolStripMenuItem.Name = "_fileSep1ToolStripMenuItem";
         this._fileSep1ToolStripMenuItem.Size = new System.Drawing.Size(208, 6);
         // 
         // _fileConvertLDToolStripMenuItem
         // 
         this._fileConvertLDToolStripMenuItem.Name = "_fileConvertLDToolStripMenuItem";
         this._fileConvertLDToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
         this._fileConvertLDToolStripMenuItem.Text = "&Convert LTD...";
         this._fileConvertLDToolStripMenuItem.Click += new System.EventHandler(this._fileConvertLDToolStripMenuItem_Click);
         // 
         // _fileSep2ToolStripMenuItem
         // 
         this._fileSep2ToolStripMenuItem.Name = "_fileSep2ToolStripMenuItem";
         this._fileSep2ToolStripMenuItem.Size = new System.Drawing.Size(208, 6);
         // 
         // _fileScanToolStripMenuItem
         // 
         this._fileScanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._scanSelectSourceToolStripMenuItem,
            this._scanAcquireToolStripMenuItem});
         this._fileScanToolStripMenuItem.Name = "_fileScanToolStripMenuItem";
         this._fileScanToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
         this._fileScanToolStripMenuItem.Text = "S&can";
         // 
         // _scanSelectSourceToolStripMenuItem
         // 
         this._scanSelectSourceToolStripMenuItem.Name = "_scanSelectSourceToolStripMenuItem";
         this._scanSelectSourceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this._scanSelectSourceToolStripMenuItem.Text = "&Select source...";
         this._scanSelectSourceToolStripMenuItem.Click += new System.EventHandler(this._scanSelectSourceToolStripMenuItem_Click);
         // 
         // _scanAcquireToolStripMenuItem
         // 
         this._scanAcquireToolStripMenuItem.Name = "_scanAcquireToolStripMenuItem";
         this._scanAcquireToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this._scanAcquireToolStripMenuItem.Text = "&Acquire...";
         this._scanAcquireToolStripMenuItem.Click += new System.EventHandler(this._scanAcquireToolStripMenuItem_Click);
         // 
         // _fileSep3ToolStripMenuItem
         // 
         this._fileSep3ToolStripMenuItem.Name = "_fileSep3ToolStripMenuItem";
         this._fileSep3ToolStripMenuItem.Size = new System.Drawing.Size(208, 6);
         // 
         // _fileExitToolStripMenuItem
         // 
         this._fileExitToolStripMenuItem.Name = "_fileExitToolStripMenuItem";
         this._fileExitToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
         this._fileExitToolStripMenuItem.Text = "E&xit";
         this._fileExitToolStripMenuItem.Click += new System.EventHandler(this._fileExitToolStripMenuItem_Click);
         // 
         // _editToolStripMenuItem
         // 
         this._editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._editCopyToolStripMenuItem,
            this._editPasteToolStripMenuItem});
         this._editToolStripMenuItem.Name = "_editToolStripMenuItem";
         this._editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
         this._editToolStripMenuItem.Text = "&Edit";
         this._editToolStripMenuItem.DropDownOpening += new System.EventHandler(this._editToolStripMenuItem_DropDownOpening);
         // 
         // _editCopyToolStripMenuItem
         // 
         this._editCopyToolStripMenuItem.Name = "_editCopyToolStripMenuItem";
         this._editCopyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
         this._editCopyToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
         this._editCopyToolStripMenuItem.Text = "&Copy";
         this._editCopyToolStripMenuItem.Click += new System.EventHandler(this._editCopyToolStripMenuItem_Click);
         // 
         // _editPasteToolStripMenuItem
         // 
         this._editPasteToolStripMenuItem.Name = "_editPasteToolStripMenuItem";
         this._editPasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.V)));
         this._editPasteToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
         this._editPasteToolStripMenuItem.Text = "&Paste";
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
         this._viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
         this._viewToolStripMenuItem.Text = "&View";
         this._viewToolStripMenuItem.DropDownOpening += new System.EventHandler(this._viewToolStripMenuItem_DropDownOpening);
         // 
         // _viewZoomOutToolStripMenuItem
         // 
         this._viewZoomOutToolStripMenuItem.Image = global::OcrDemo.Properties.Resources.ZoomOut;
         this._viewZoomOutToolStripMenuItem.Name = "_viewZoomOutToolStripMenuItem";
         this._viewZoomOutToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
         this._viewZoomOutToolStripMenuItem.Text = "Zoom &out";
         this._viewZoomOutToolStripMenuItem.Click += new System.EventHandler(this._viewZoomOutToolStripMenuItem_Click);
         // 
         // _viewZoomInToolStripMenuItem
         // 
         this._viewZoomInToolStripMenuItem.Image = global::OcrDemo.Properties.Resources.ZoomIn;
         this._viewZoomInToolStripMenuItem.Name = "_viewZoomInToolStripMenuItem";
         this._viewZoomInToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
         this._viewZoomInToolStripMenuItem.Text = "Zoom &in";
         this._viewZoomInToolStripMenuItem.Click += new System.EventHandler(this._viewZoomInToolStripMenuItem_Click);
         // 
         // _viewSep1ToolStripMenuItem
         // 
         this._viewSep1ToolStripMenuItem.Name = "_viewSep1ToolStripMenuItem";
         this._viewSep1ToolStripMenuItem.Size = new System.Drawing.Size(124, 6);
         // 
         // _viewFitWidthToolStripMenuItem
         // 
         this._viewFitWidthToolStripMenuItem.Image = global::OcrDemo.Properties.Resources.FitPageWidth;
         this._viewFitWidthToolStripMenuItem.Name = "_viewFitWidthToolStripMenuItem";
         this._viewFitWidthToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
         this._viewFitWidthToolStripMenuItem.Text = "Fit &width";
         this._viewFitWidthToolStripMenuItem.Click += new System.EventHandler(this._viewFitWidthToolStripMenuItem_Click);
         // 
         // _viewFitPageToolStripMenuItem
         // 
         this._viewFitPageToolStripMenuItem.Image = global::OcrDemo.Properties.Resources.FitPage;
         this._viewFitPageToolStripMenuItem.Name = "_viewFitPageToolStripMenuItem";
         this._viewFitPageToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
         this._viewFitPageToolStripMenuItem.Text = "&Fit page";
         this._viewFitPageToolStripMenuItem.Click += new System.EventHandler(this._viewFitPageToolStripMenuItem_Click);
         // 
         // _engineToolStripMenuItem
         // 
         this._engineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._engineSettingsToolStripMenuItem,
            this._engineComponentsToolStripMenuItem,
            this._engineLanguagesToolStripMenuItem});
         this._engineToolStripMenuItem.Name = "_engineToolStripMenuItem";
         this._engineToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
         this._engineToolStripMenuItem.Text = "En&gine";
         // 
         // _engineSettingsToolStripMenuItem
         // 
         this._engineSettingsToolStripMenuItem.Name = "_engineSettingsToolStripMenuItem";
         this._engineSettingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this._engineSettingsToolStripMenuItem.Text = "&Settings...";
         this._engineSettingsToolStripMenuItem.Click += new System.EventHandler(this._engineSettingsToolStripMenuItem_Click);
         // 
         // _engineComponentsToolStripMenuItem
         // 
         this._engineComponentsToolStripMenuItem.Name = "_engineComponentsToolStripMenuItem";
         this._engineComponentsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this._engineComponentsToolStripMenuItem.Text = "&Components...";
         this._engineComponentsToolStripMenuItem.Click += new System.EventHandler(this._engineComponentsToolStripMenuItem_Click);
         // 
         // _engineLanguagesToolStripMenuItem
         // 
         this._engineLanguagesToolStripMenuItem.Name = "_engineLanguagesToolStripMenuItem";
         this._engineLanguagesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this._engineLanguagesToolStripMenuItem.Text = "&Languages...";
         this._engineLanguagesToolStripMenuItem.Click += new System.EventHandler(this._engineLanguagesToolStripMenuItem_Click);
         // 
         // _pageToolStripMenuItem
         // 
         this._pageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._pageSaveProcessingImageToDiskToolStripMenuItem,
            this._pageDetectPageLanguagesToolStripMenuItem,
            this._pageSaveRecognizedDataAsXmlToolStripMenuItem,
            this._pageCloseCurrentPageToolStripMenuItem});
         this._pageToolStripMenuItem.Name = "_pageToolStripMenuItem";
         this._pageToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
         this._pageToolStripMenuItem.Text = "&Page";
         this._pageToolStripMenuItem.DropDownOpening += new System.EventHandler(this._pageToolStripMenuItem_DropDownOpening);
         // 
         // _pageSaveProcessingImageToDiskToolStripMenuItem
         // 
         this._pageSaveProcessingImageToDiskToolStripMenuItem.Name = "_pageSaveProcessingImageToDiskToolStripMenuItem";
         this._pageSaveProcessingImageToDiskToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
         this._pageSaveProcessingImageToDiskToolStripMenuItem.Text = "&Save processing image to disk...";
         this._pageSaveProcessingImageToDiskToolStripMenuItem.Click += new System.EventHandler(this._pagesSaveProcessingImageToDiskToolStripMenuItem_Click);
         // 
         // _pageDetectPageLanguagesToolStripMenuItem
         // 
         this._pageDetectPageLanguagesToolStripMenuItem.Name = "_pageDetectPageLanguagesToolStripMenuItem";
         this._pageDetectPageLanguagesToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
         this._pageDetectPageLanguagesToolStripMenuItem.Text = "Detect current page languages...";
         this._pageDetectPageLanguagesToolStripMenuItem.Click += new System.EventHandler(this._pagesDetectPageLanguagesToolStripMenuItem_Click);
         // 
         // _pageSaveRecognizedDataAsXmlToolStripMenuItem
         // 
         this._pageSaveRecognizedDataAsXmlToolStripMenuItem.Name = "_pageSaveRecognizedDataAsXmlToolStripMenuItem";
         this._pageSaveRecognizedDataAsXmlToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
         this._pageSaveRecognizedDataAsXmlToolStripMenuItem.Text = "Save recognized data as &XML...";
         this._pageSaveRecognizedDataAsXmlToolStripMenuItem.Click += new System.EventHandler(this._pageSaveRecognizedDataAsXmlToolStripMenuItem_Click);
         // 
         // _pageCloseCurrentPageToolStripMenuItem
         // 
         this._pageCloseCurrentPageToolStripMenuItem.Name = "_pageCloseCurrentPageToolStripMenuItem";
         this._pageCloseCurrentPageToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
         this._pageCloseCurrentPageToolStripMenuItem.Text = "&Close current page";
         this._pageCloseCurrentPageToolStripMenuItem.Click += new System.EventHandler(this._pageCloseCurrentPageToolStripMenuItem_Click);
         // 
         // _processToolStripMenuItem
         // 
         this._processToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.toolStripSeparator5,
            this._manualPerspectiveToolStripMenuItem,
            this._inversePerspectiveToolStripMenuItem,
            this._perspectiveDeskewToolStripMenuItem,
            this._unwarpToolStripMenuItem});
         this._processToolStripMenuItem.Name = "_processToolStripMenuItem";
         this._processToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
         this._processToolStripMenuItem.Text = "Pr&ocess";
         this._processToolStripMenuItem.DropDownOpening += new System.EventHandler(this._processToolStripMenuItem_DropDownOpening);
         // 
         // _processAllPagesToolStripMenuItem
         // 
         this._processAllPagesToolStripMenuItem.Name = "_processAllPagesToolStripMenuItem";
         this._processAllPagesToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
         this._processAllPagesToolStripMenuItem.Text = "&All pages";
         this._processAllPagesToolStripMenuItem.ToolTipText = "Process all pages or only current page";
         this._processAllPagesToolStripMenuItem.Click += new System.EventHandler(this._processAllPagesToolStripMenuItem_Click);
         // 
         // _processSep1ToolStripMenuItem
         // 
         this._processSep1ToolStripMenuItem.Name = "_processSep1ToolStripMenuItem";
         this._processSep1ToolStripMenuItem.Size = new System.Drawing.Size(225, 6);
         // 
         // _processFlipToolStripMenuItem
         // 
         this._processFlipToolStripMenuItem.Name = "_processFlipToolStripMenuItem";
         this._processFlipToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
         this._processFlipToolStripMenuItem.Text = "&Flip";
         this._processFlipToolStripMenuItem.ToolTipText = "Flips the document from top to bottom";
         this._processFlipToolStripMenuItem.Click += new System.EventHandler(this._processFlipToolStripMenuItem_Click);
         // 
         // _processReverseToolStripMenuItem
         // 
         this._processReverseToolStripMenuItem.Name = "_processReverseToolStripMenuItem";
         this._processReverseToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
         this._processReverseToolStripMenuItem.Text = "R&everse";
         this._processReverseToolStripMenuItem.ToolTipText = "Reverses the document (left to right) to produce a mirror image";
         this._processReverseToolStripMenuItem.Click += new System.EventHandler(this._processReverseToolStripMenuItem_Click);
         // 
         // _processRotate90ClockwiseToolStripMenuItem
         // 
         this._processRotate90ClockwiseToolStripMenuItem.Name = "_processRotate90ClockwiseToolStripMenuItem";
         this._processRotate90ClockwiseToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
         this._processRotate90ClockwiseToolStripMenuItem.Text = "R&otate 90° clockwise";
         this._processRotate90ClockwiseToolStripMenuItem.ToolTipText = "Rotate the document 90 degrees clockwise";
         this._processRotate90ClockwiseToolStripMenuItem.Click += new System.EventHandler(this._processRotate90ClockwiseToolStripMenuItem_Click);
         // 
         // _processRotate90CounterClockwiseToolStripMenuItem
         // 
         this._processRotate90CounterClockwiseToolStripMenuItem.Name = "_processRotate90CounterClockwiseToolStripMenuItem";
         this._processRotate90CounterClockwiseToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
         this._processRotate90CounterClockwiseToolStripMenuItem.Text = "Ro&tate 90° counter-clockwise";
         this._processRotate90CounterClockwiseToolStripMenuItem.ToolTipText = "Rotate the document 90 degrees counter-clockwise";
         this._processRotate90CounterClockwiseToolStripMenuItem.Click += new System.EventHandler(this._processRotate90CounterClockwiseToolStripMenuItem_Click);
         // 
         // _processSep2ToolStripMenuItem
         // 
         this._processSep2ToolStripMenuItem.Name = "_processSep2ToolStripMenuItem";
         this._processSep2ToolStripMenuItem.Size = new System.Drawing.Size(225, 6);
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
         this._processPreprocessToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
         this._processPreprocessToolStripMenuItem.Text = "Prep&rocess";
         // 
         // _processPreprocessGetDeskewAngleToolStripMenuItem
         // 
         this._processPreprocessGetDeskewAngleToolStripMenuItem.Name = "_processPreprocessGetDeskewAngleToolStripMenuItem";
         this._processPreprocessGetDeskewAngleToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
         this._processPreprocessGetDeskewAngleToolStripMenuItem.Text = "Get &deskew angle...";
         this._processPreprocessGetDeskewAngleToolStripMenuItem.Click += new System.EventHandler(this._processPreprocessGetDeskewAngleToolStripMenuItem_Click);
         // 
         // _processPreprocessGetRotateAngleToolStripMenuItem
         // 
         this._processPreprocessGetRotateAngleToolStripMenuItem.Name = "_processPreprocessGetRotateAngleToolStripMenuItem";
         this._processPreprocessGetRotateAngleToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
         this._processPreprocessGetRotateAngleToolStripMenuItem.Text = "Get &rotate angle...";
         this._processPreprocessGetRotateAngleToolStripMenuItem.Click += new System.EventHandler(this._processPreprocessGetRotateAngleToolStripMenuItem_Click);
         // 
         // _processPreprocessIsInvertedToolStripMenuItem
         // 
         this._processPreprocessIsInvertedToolStripMenuItem.Name = "_processPreprocessIsInvertedToolStripMenuItem";
         this._processPreprocessIsInvertedToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
         this._processPreprocessIsInvertedToolStripMenuItem.Text = "Is &Inverted...";
         this._processPreprocessIsInvertedToolStripMenuItem.Click += new System.EventHandler(this._processPreprocessIsInvertedToolStripMenuItem_Click);
         // 
         // _processPreprocessSep1ToolStripMenuItem
         // 
         this._processPreprocessSep1ToolStripMenuItem.Name = "_processPreprocessSep1ToolStripMenuItem";
         this._processPreprocessSep1ToolStripMenuItem.Size = new System.Drawing.Size(172, 6);
         // 
         // _processPreprocessDeskewToolStripMenuItem
         // 
         this._processPreprocessDeskewToolStripMenuItem.Name = "_processPreprocessDeskewToolStripMenuItem";
         this._processPreprocessDeskewToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
         this._processPreprocessDeskewToolStripMenuItem.Text = "&Deskew";
         this._processPreprocessDeskewToolStripMenuItem.Click += new System.EventHandler(this._processPreprocessDeskewToolStripMenuItem_Click);
         // 
         // _processPreprocessRotateToolStripMenuItem
         // 
         this._processPreprocessRotateToolStripMenuItem.Name = "_processPreprocessRotateToolStripMenuItem";
         this._processPreprocessRotateToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
         this._processPreprocessRotateToolStripMenuItem.Text = "&Rotate";
         this._processPreprocessRotateToolStripMenuItem.Click += new System.EventHandler(this._processPreprocessRotateToolStripMenuItem_Click);
         // 
         // _processPreprocessInvertToolStripMenuItem
         // 
         this._processPreprocessInvertToolStripMenuItem.Name = "_processPreprocessInvertToolStripMenuItem";
         this._processPreprocessInvertToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
         this._processPreprocessInvertToolStripMenuItem.Text = "&Invert";
         this._processPreprocessInvertToolStripMenuItem.Click += new System.EventHandler(this._processPreprocessInvertToolStripMenuItem_Click);
         // 
         // _processPreprocessAllToolStripMenuItem
         // 
         this._processPreprocessAllToolStripMenuItem.Name = "_processPreprocessAllToolStripMenuItem";
         this._processPreprocessAllToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
         this._processPreprocessAllToolStripMenuItem.Text = "All";
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
         this._documentCleanupToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
         this._documentCleanupToolStripMenuItem.Text = "&Document clean up";
         // 
         // _processAutoCropToolStripMenuItem
         // 
         this._processAutoCropToolStripMenuItem.Name = "_processAutoCropToolStripMenuItem";
         this._processAutoCropToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
         this._processAutoCropToolStripMenuItem.Text = "Auto &Crop";
         this._processAutoCropToolStripMenuItem.ToolTipText = "Trims the document by removing blank space around the edges";
         this._processAutoCropToolStripMenuItem.Click += new System.EventHandler(this._processAutoCropToolStripMenuItem_Click);
         // 
         // _processDespeckleToolStripMenuItem
         // 
         this._processDespeckleToolStripMenuItem.Name = "_processDespeckleToolStripMenuItem";
         this._processDespeckleToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
         this._processDespeckleToolStripMenuItem.Text = "Des&peckle";
         this._processDespeckleToolStripMenuItem.ToolTipText = "Removes speckles from the document. Typically, this function is used to clean up " +
    "scanned images (such as FAX images)";
         this._processDespeckleToolStripMenuItem.Click += new System.EventHandler(this._processDespeckleToolStripMenuItem_Click);
         // 
         // _processErodeToolStripMenuItem
         // 
         this._processErodeToolStripMenuItem.Name = "_processErodeToolStripMenuItem";
         this._processErodeToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
         this._processErodeToolStripMenuItem.Text = "&Erode";
         this._processErodeToolStripMenuItem.ToolTipText = "Shrinks black objects in the document";
         this._processErodeToolStripMenuItem.Click += new System.EventHandler(this._processErodeToolStripMenuItem_Click);
         // 
         // _processDilateToolStripMenuItem
         // 
         this._processDilateToolStripMenuItem.Name = "_processDilateToolStripMenuItem";
         this._processDilateToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
         this._processDilateToolStripMenuItem.Text = "D&ilate";
         this._processDilateToolStripMenuItem.ToolTipText = "Enlarges black objects in the document";
         this._processDilateToolStripMenuItem.Click += new System.EventHandler(this._processDilateToolStripMenuItem_Click);
         // 
         // _processUnditherTextToolStripMenuItem
         // 
         this._processUnditherTextToolStripMenuItem.Name = "_processUnditherTextToolStripMenuItem";
         this._processUnditherTextToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
         this._processUnditherTextToolStripMenuItem.Text = "&Undither text";
         this._processUnditherTextToolStripMenuItem.ToolTipText = "Sharpen the text on this document if the document was converted with dithered tex" +
    "t from a higher bits/pixel";
         this._processUnditherTextToolStripMenuItem.Click += new System.EventHandler(this._processUnditherTextToolStripMenuItem_Click);
         // 
         // _processFixBrokenLettersToolStripMenuItem
         // 
         this._processFixBrokenLettersToolStripMenuItem.Name = "_processFixBrokenLettersToolStripMenuItem";
         this._processFixBrokenLettersToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
         this._processFixBrokenLettersToolStripMenuItem.Text = "Fi&x broken letters";
         this._processFixBrokenLettersToolStripMenuItem.ToolTipText = "Enlarge text lines to fix broken letters in the document";
         this._processFixBrokenLettersToolStripMenuItem.Click += new System.EventHandler(this._processFixBrokenLettersToolStripMenuItem_Click);
         // 
         // _processLineRemoveToolStripMenuItem
         // 
         this._processLineRemoveToolStripMenuItem.Name = "_processLineRemoveToolStripMenuItem";
         this._processLineRemoveToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
         this._processLineRemoveToolStripMenuItem.Text = "&Line remove";
         this._processLineRemoveToolStripMenuItem.ToolTipText = "Removes horizontal and vertical lines in a 1-bit black and white image";
         this._processLineRemoveToolStripMenuItem.Click += new System.EventHandler(this._processLineRemoveToolStripMenuItem_Click);
         // 
         // _binarizationToolStripMenuItem
         // 
         this._binarizationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._processAutoBinarizeToolStripMenuItem,
            this._processDynamicBinarizeToolStripMenuItem});
         this._binarizationToolStripMenuItem.Name = "_binarizationToolStripMenuItem";
         this._binarizationToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
         this._binarizationToolStripMenuItem.Text = "&Binarization";
         // 
         // _processAutoBinarizeToolStripMenuItem
         // 
         this._processAutoBinarizeToolStripMenuItem.Name = "_processAutoBinarizeToolStripMenuItem";
         this._processAutoBinarizeToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
         this._processAutoBinarizeToolStripMenuItem.Text = "&Auto";
         this._processAutoBinarizeToolStripMenuItem.ToolTipText = "Convert the document to 1 bits/pixel (bitonal) by applying binary segmentation";
         this._processAutoBinarizeToolStripMenuItem.Click += new System.EventHandler(this._processAutoBinarizeToolStripMenuItem_Click);
         // 
         // _processDynamicBinarizeToolStripMenuItem
         // 
         this._processDynamicBinarizeToolStripMenuItem.Name = "_processDynamicBinarizeToolStripMenuItem";
         this._processDynamicBinarizeToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
         this._processDynamicBinarizeToolStripMenuItem.Text = "&Dynamic";
         this._processDynamicBinarizeToolStripMenuItem.ToolTipText = "Converts an image into a black and white image without changing its bits per pixe" +
    "l by using a local threshold value for each pixel of the image";
         this._processDynamicBinarizeToolStripMenuItem.Click += new System.EventHandler(this._processDynamicBinarizeToolStripMenuItem_Click);
         // 
         // _brightnessToolStripMenuItem
         // 
         this._brightnessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._processHisogramEqualToolStripMenuItem,
            this._processAutoLevelToolStripMenuItem,
            this._processContrastBrightnessIntensityToolStripMenuItem});
         this._brightnessToolStripMenuItem.Name = "_brightnessToolStripMenuItem";
         this._brightnessToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
         this._brightnessToolStripMenuItem.Text = "Bright&ness";
         // 
         // _processHisogramEqualToolStripMenuItem
         // 
         this._processHisogramEqualToolStripMenuItem.Name = "_processHisogramEqualToolStripMenuItem";
         this._processHisogramEqualToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
         this._processHisogramEqualToolStripMenuItem.Text = "&Hisogram Equalize";
         this._processHisogramEqualToolStripMenuItem.ToolTipText = "Linearizes the number of pixels, in an image, based on the specified color space." +
    " This can be used to bring out the detail in dark areas of an image";
         this._processHisogramEqualToolStripMenuItem.Click += new System.EventHandler(this._processHisogramEqualToolStripMenuItem_Click);
         // 
         // _processAutoLevelToolStripMenuItem
         // 
         this._processAutoLevelToolStripMenuItem.Name = "_processAutoLevelToolStripMenuItem";
         this._processAutoLevelToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
         this._processAutoLevelToolStripMenuItem.Text = "&Auto level";
         this._processAutoLevelToolStripMenuItem.ToolTipText = "Applies one of several types of automatic color leveling to an image";
         this._processAutoLevelToolStripMenuItem.Click += new System.EventHandler(this._processAutoLevelToolStripMenuItem_Click);
         // 
         // _processContrastBrightnessIntensityToolStripMenuItem
         // 
         this._processContrastBrightnessIntensityToolStripMenuItem.Name = "_processContrastBrightnessIntensityToolStripMenuItem";
         this._processContrastBrightnessIntensityToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
         this._processContrastBrightnessIntensityToolStripMenuItem.Text = "&Contrast/Brightnesst/Intensity...";
         this._processContrastBrightnessIntensityToolStripMenuItem.ToolTipText = "Applies contrast, brightness and intensity adjustments to enhance the image tonal" +
    " range";
         this._processContrastBrightnessIntensityToolStripMenuItem.Click += new System.EventHandler(this._processContrastBrightnessIntensityToolStripMenuItem_Click);
         // 
         // _dualPageToolStripMenuItem
         // 
         this._dualPageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._processPageSplitterToolStripMenuItem,
            this._processExpandContentToolStripMenuItem});
         this._dualPageToolStripMenuItem.Name = "_dualPageToolStripMenuItem";
         this._dualPageToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
         this._dualPageToolStripMenuItem.Text = "D&ual Page";
         // 
         // _processPageSplitterToolStripMenuItem
         // 
         this._processPageSplitterToolStripMenuItem.Name = "_processPageSplitterToolStripMenuItem";
         this._processPageSplitterToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
         this._processPageSplitterToolStripMenuItem.Text = "Page &Splitter";
         this._processPageSplitterToolStripMenuItem.Click += new System.EventHandler(this._processPageSplitterToolStripMenuItem_Click);
         // 
         // _processExpandContentToolStripMenuItem
         // 
         this._processExpandContentToolStripMenuItem.Name = "_processExpandContentToolStripMenuItem";
         this._processExpandContentToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
         this._processExpandContentToolStripMenuItem.Text = "E&xpand Content";
         this._processExpandContentToolStripMenuItem.Click += new System.EventHandler(this._processExpandContentToolStripMenuItem_Click);
         // 
         // toolStripSeparator5
         // 
         this.toolStripSeparator5.Name = "toolStripSeparator5";
         this.toolStripSeparator5.Size = new System.Drawing.Size(225, 6);
         // 
         // _manualPerspectiveToolStripMenuItem
         // 
         this._manualPerspectiveToolStripMenuItem.Name = "_manualPerspectiveToolStripMenuItem";
         this._manualPerspectiveToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
         this._manualPerspectiveToolStripMenuItem.Text = "&Manual Perspective...";
         this._manualPerspectiveToolStripMenuItem.Click += new System.EventHandler(this._manualPerspectiveToolStripMenuItem_Click);
         // 
         // _inversePerspectiveToolStripMenuItem
         // 
         this._inversePerspectiveToolStripMenuItem.Name = "_inversePerspectiveToolStripMenuItem";
         this._inversePerspectiveToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
         this._inversePerspectiveToolStripMenuItem.Text = "Inverse Perspective...";
         this._inversePerspectiveToolStripMenuItem.Click += new System.EventHandler(this._inversePerspectiveToolStripMenuItem_Click);
         // 
         // _perspectiveDeskewToolStripMenuItem
         // 
         this._perspectiveDeskewToolStripMenuItem.Name = "_perspectiveDeskewToolStripMenuItem";
         this._perspectiveDeskewToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
         this._perspectiveDeskewToolStripMenuItem.Text = "&Perspective Deskew";
         this._perspectiveDeskewToolStripMenuItem.Click += new System.EventHandler(this._perspectiveDeskewToolStripMenuItem_Click);
         // 
         // _unwarpToolStripMenuItem
         // 
         this._unwarpToolStripMenuItem.Name = "_unwarpToolStripMenuItem";
         this._unwarpToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
         this._unwarpToolStripMenuItem.Text = "Un&Warp...";
         this._unwarpToolStripMenuItem.Click += new System.EventHandler(this._unwarpToolStripMenuItem_Click);
         // 
         // _zonesToolStripMenuItem
         // 
         this._zonesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
         this._zonesToolStripMenuItem.Name = "_zonesToolStripMenuItem";
         this._zonesToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
         this._zonesToolStripMenuItem.Text = "&Zones";
         this._zonesToolStripMenuItem.DropDownOpening += new System.EventHandler(this._zonesToolStripMenuItem_DropDownOpening);
         // 
         // _zonesAutoZoneDocumentToolStripMenuItem
         // 
         this._zonesAutoZoneDocumentToolStripMenuItem.Image = global::OcrDemo.Properties.Resources.AutoZoneDocument;
         this._zonesAutoZoneDocumentToolStripMenuItem.Name = "_zonesAutoZoneDocumentToolStripMenuItem";
         this._zonesAutoZoneDocumentToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
         this._zonesAutoZoneDocumentToolStripMenuItem.Text = "&Auto zone document";
         this._zonesAutoZoneDocumentToolStripMenuItem.Click += new System.EventHandler(this._zonesAutoZoneDocumentToolStripMenuItem_Click);
         // 
         // _zonesAutoZoneCurrentPageToolStripMenuItem
         // 
         this._zonesAutoZoneCurrentPageToolStripMenuItem.Image = global::OcrDemo.Properties.Resources.AutoZonePage;
         this._zonesAutoZoneCurrentPageToolStripMenuItem.Name = "_zonesAutoZoneCurrentPageToolStripMenuItem";
         this._zonesAutoZoneCurrentPageToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
         this._zonesAutoZoneCurrentPageToolStripMenuItem.Text = "Auto zone &current page";
         this._zonesAutoZoneCurrentPageToolStripMenuItem.Click += new System.EventHandler(this._zonesAutoZoneCurrentPageToolStripMenuItem_Click);
         // 
         // _zonesSep1ToolStripMenuItem
         // 
         this._zonesSep1ToolStripMenuItem.Name = "_zonesSep1ToolStripMenuItem";
         this._zonesSep1ToolStripMenuItem.Size = new System.Drawing.Size(223, 6);
         // 
         // _zonesUpdateZonesToolStripMenuItem
         // 
         this._zonesUpdateZonesToolStripMenuItem.Image = global::OcrDemo.Properties.Resources.ZoneProperties;
         this._zonesUpdateZonesToolStripMenuItem.Name = "_zonesUpdateZonesToolStripMenuItem";
         this._zonesUpdateZonesToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
         this._zonesUpdateZonesToolStripMenuItem.Text = "&Update zones...";
         this._zonesUpdateZonesToolStripMenuItem.Click += new System.EventHandler(this._zonesUpdateZonesToolStripMenuItem_Click);
         // 
         // _zonesSep2ToolStripMenuItem
         // 
         this._zonesSep2ToolStripMenuItem.Name = "_zonesSep2ToolStripMenuItem";
         this._zonesSep2ToolStripMenuItem.Size = new System.Drawing.Size(223, 6);
         // 
         // _zonesLoadZonesToolStripMenuItem
         // 
         this._zonesLoadZonesToolStripMenuItem.Name = "_zonesLoadZonesToolStripMenuItem";
         this._zonesLoadZonesToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
         this._zonesLoadZonesToolStripMenuItem.Text = "&Load zones to current page...";
         this._zonesLoadZonesToolStripMenuItem.Click += new System.EventHandler(this._zonesLoadZonesToolStripMenuItem_Click);
         // 
         // _zonesSaveZonesToolStripMenuItem
         // 
         this._zonesSaveZonesToolStripMenuItem.Name = "_zonesSaveZonesToolStripMenuItem";
         this._zonesSaveZonesToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
         this._zonesSaveZonesToolStripMenuItem.Text = "&Save current page zones...";
         this._zonesSaveZonesToolStripMenuItem.Click += new System.EventHandler(this._zonesSaveZonesToolStripMenuItem_Click);
         // 
         // _zonesSep3ToolStripMenuItem
         // 
         this._zonesSep3ToolStripMenuItem.Name = "_zonesSep3ToolStripMenuItem";
         this._zonesSep3ToolStripMenuItem.Size = new System.Drawing.Size(223, 6);
         // 
         // _loadAllPagesZonesToolStripMenuItem
         // 
         this._loadAllPagesZonesToolStripMenuItem.Name = "_loadAllPagesZonesToolStripMenuItem";
         this._loadAllPagesZonesToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
         this._loadAllPagesZonesToolStripMenuItem.Text = "Load all pages zones...";
         this._loadAllPagesZonesToolStripMenuItem.Click += new System.EventHandler(this._loadAllPagesZonesToolStripMenuItem_Click);
         // 
         // _saveAllPagesZonesToolStripMenuItem
         // 
         this._saveAllPagesZonesToolStripMenuItem.Name = "_saveAllPagesZonesToolStripMenuItem";
         this._saveAllPagesZonesToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
         this._saveAllPagesZonesToolStripMenuItem.Text = "Save all pages zones...";
         this._saveAllPagesZonesToolStripMenuItem.Click += new System.EventHandler(this._saveAllPagesZonesToolStripMenuItem_Click);
         // 
         // _zonesSep4ToolStripMenuItem
         // 
         this._zonesSep4ToolStripMenuItem.Name = "_zonesSep4ToolStripMenuItem";
         this._zonesSep4ToolStripMenuItem.Size = new System.Drawing.Size(223, 6);
         // 
         // _clearAllPagesZonesToolStripMenuItem
         // 
         this._clearAllPagesZonesToolStripMenuItem.Name = "_clearAllPagesZonesToolStripMenuItem";
         this._clearAllPagesZonesToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
         this._clearAllPagesZonesToolStripMenuItem.Text = "Clear all pages zones";
         this._clearAllPagesZonesToolStripMenuItem.Click += new System.EventHandler(this._clearAllPagesZonesToolStripMenuItem_Click);
         // 
         // _zonesSep5ToolStripMenuItem
         // 
         this._zonesSep5ToolStripMenuItem.Name = "_zonesSep5ToolStripMenuItem";
         this._zonesSep5ToolStripMenuItem.Size = new System.Drawing.Size(223, 6);
         // 
         // _zonesShowZonesToolStripMenuItem
         // 
         this._zonesShowZonesToolStripMenuItem.Image = global::OcrDemo.Properties.Resources.ShowZones;
         this._zonesShowZonesToolStripMenuItem.Name = "_zonesShowZonesToolStripMenuItem";
         this._zonesShowZonesToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
         this._zonesShowZonesToolStripMenuItem.Text = "Show &zones";
         this._zonesShowZonesToolStripMenuItem.Click += new System.EventHandler(this._zonesShowZonesToolStripMenuItem_Click);
         // 
         // _zonesShowZoneNamesToolStripMenuItem
         // 
         this._zonesShowZoneNamesToolStripMenuItem.Image = global::OcrDemo.Properties.Resources.ShowZoneName;
         this._zonesShowZoneNamesToolStripMenuItem.Name = "_zonesShowZoneNamesToolStripMenuItem";
         this._zonesShowZoneNamesToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
         this._zonesShowZoneNamesToolStripMenuItem.Text = "Show zone &names";
         this._zonesShowZoneNamesToolStripMenuItem.Click += new System.EventHandler(this._zonesShowZoneNamesToolStripMenuItem_Click);
         // 
         // _recognizeToolStripMenuItem
         // 
         this._recognizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._recognizeRecognizeDocumentToolStripMenuItem,
            this._recognizeRecognizePageToolStripMenuItem,
            this._ocrSep2ToolStripMenuItem,
            this._recognizeSpellCheckEngineStripMenuItem,
            this._recognizeOmrOptionsToolStripMenuItem,
            this.toolStripSeparator1,
            this._recognizeSaveAfterRecognizeToolStripMenuItem});
         this._recognizeToolStripMenuItem.Name = "_recognizeToolStripMenuItem";
         this._recognizeToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
         this._recognizeToolStripMenuItem.Text = "&Recognize";
         this._recognizeToolStripMenuItem.DropDownOpening += new System.EventHandler(this._recognizeToolStripMenuItem_DropDownOpening);
         // 
         // _recognizeRecognizeDocumentToolStripMenuItem
         // 
         this._recognizeRecognizeDocumentToolStripMenuItem.Image = global::OcrDemo.Properties.Resources.RecognizeAllPages;
         this._recognizeRecognizeDocumentToolStripMenuItem.Name = "_recognizeRecognizeDocumentToolStripMenuItem";
         this._recognizeRecognizeDocumentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
         this._recognizeRecognizeDocumentToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
         this._recognizeRecognizeDocumentToolStripMenuItem.Text = "&Recognize document";
         this._recognizeRecognizeDocumentToolStripMenuItem.ToolTipText = "Recognize all the pages in the document";
         this._recognizeRecognizeDocumentToolStripMenuItem.Click += new System.EventHandler(this._recognizeRecognizeDocumentToolStripMenuItem_Click);
         // 
         // _recognizeRecognizePageToolStripMenuItem
         // 
         this._recognizeRecognizePageToolStripMenuItem.Image = global::OcrDemo.Properties.Resources.RecognizePage;
         this._recognizeRecognizePageToolStripMenuItem.Name = "_recognizeRecognizePageToolStripMenuItem";
         this._recognizeRecognizePageToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
         this._recognizeRecognizePageToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
         this._recognizeRecognizePageToolStripMenuItem.Text = "Recognize current &page";
         this._recognizeRecognizePageToolStripMenuItem.ToolTipText = "Recognize the current page";
         this._recognizeRecognizePageToolStripMenuItem.Click += new System.EventHandler(this._recognizeRecognizePageToolStripMenuItem_Click);
         // 
         // _ocrSep2ToolStripMenuItem
         // 
         this._ocrSep2ToolStripMenuItem.Name = "_ocrSep2ToolStripMenuItem";
         this._ocrSep2ToolStripMenuItem.Size = new System.Drawing.Size(229, 6);
         // 
         // _recognizeSpellCheckEngineStripMenuItem
         // 
         this._recognizeSpellCheckEngineStripMenuItem.Name = "_recognizeSpellCheckEngineStripMenuItem";
         this._recognizeSpellCheckEngineStripMenuItem.Size = new System.Drawing.Size(232, 22);
         this._recognizeSpellCheckEngineStripMenuItem.Text = "Spell check &engine...";
         this._recognizeSpellCheckEngineStripMenuItem.Click += new System.EventHandler(this._recognizeSpellCheckEngineStripMenuItem_Click);
         // 
         // _recognizeOmrOptionsToolStripMenuItem
         // 
         this._recognizeOmrOptionsToolStripMenuItem.Name = "_recognizeOmrOptionsToolStripMenuItem";
         this._recognizeOmrOptionsToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
         this._recognizeOmrOptionsToolStripMenuItem.Text = "&OMR Options...";
         this._recognizeOmrOptionsToolStripMenuItem.Click += new System.EventHandler(this._recognizeOmrOptionsToolStripMenuItem_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(229, 6);
         // 
         // _recognizeSaveAfterRecognizeToolStripMenuItem
         // 
         this._recognizeSaveAfterRecognizeToolStripMenuItem.Name = "_recognizeSaveAfterRecognizeToolStripMenuItem";
         this._recognizeSaveAfterRecognizeToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
         this._recognizeSaveAfterRecognizeToolStripMenuItem.Text = "&Save after Recognize";
         this._recognizeSaveAfterRecognizeToolStripMenuItem.Click += new System.EventHandler(this._recognizeSaveAfterRecognizeToolStripMenuItem_Click);
         // 
         // _documentToolStripMenuItem
         // 
         this._documentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._documentCreateDocumentToolStripMenuItem,
            this._documentLoadDocumentToolStripMenuItem,
            this.toolStripSeparator2,
            this._documentAddCurrentPageToolStripMenuItem,
            this._documentInsertPagesToolStripMenuItem,
            this._documentRemoveCurrentPageToolStripMenuItem,
            this._documentClearDocumentPagesToolStripMenuItem,
            this.toolStripSeparator3,
            this._documentSaveDocumentToolStripMenuItem,
            this._documentSaveRecognizedDataAsXmlToolStripMenuItem,
            this.toolStripSeparator4,
            this._documentCloseDocumentToolStripMenuItem});
         this._documentToolStripMenuItem.Name = "_documentToolStripMenuItem";
         this._documentToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
         this._documentToolStripMenuItem.Text = "&Document";
         this._documentToolStripMenuItem.DropDownOpening += new System.EventHandler(this._documentToolStripMenuItem_DropDownOpening);
         // 
         // _documentCreateDocumentToolStripMenuItem
         // 
         this._documentCreateDocumentToolStripMenuItem.Name = "_documentCreateDocumentToolStripMenuItem";
         this._documentCreateDocumentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
         this._documentCreateDocumentToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
         this._documentCreateDocumentToolStripMenuItem.Text = "&Create Document...";
         this._documentCreateDocumentToolStripMenuItem.ToolTipText = "Create document";
         this._documentCreateDocumentToolStripMenuItem.Click += new System.EventHandler(this._documentCreateDocumentToolStripMenuItem_Click);
         // 
         // _documentLoadDocumentToolStripMenuItem
         // 
         this._documentLoadDocumentToolStripMenuItem.Name = "_documentLoadDocumentToolStripMenuItem";
         this._documentLoadDocumentToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
         this._documentLoadDocumentToolStripMenuItem.Text = "&Load Document...";
         this._documentLoadDocumentToolStripMenuItem.ToolTipText = "Load document";
         this._documentLoadDocumentToolStripMenuItem.Click += new System.EventHandler(this._documentLoadDocumentToolStripMenuItem_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(232, 6);
         // 
         // _documentAddCurrentPageToolStripMenuItem
         // 
         this._documentAddCurrentPageToolStripMenuItem.Name = "_documentAddCurrentPageToolStripMenuItem";
         this._documentAddCurrentPageToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
         this._documentAddCurrentPageToolStripMenuItem.Text = "&Add current page";
         this._documentAddCurrentPageToolStripMenuItem.ToolTipText = "Add current page";
         this._documentAddCurrentPageToolStripMenuItem.Click += new System.EventHandler(this._documentAddCurrentPageToolStripMenuItem_Click);
         // 
         // _documentInsertPagesToolStripMenuItem
         // 
         this._documentInsertPagesToolStripMenuItem.Image = global::OcrDemo.Properties.Resources.InsertPage;
         this._documentInsertPagesToolStripMenuItem.Name = "_documentInsertPagesToolStripMenuItem";
         this._documentInsertPagesToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
         this._documentInsertPagesToolStripMenuItem.Text = "&Insert pages...";
         this._documentInsertPagesToolStripMenuItem.ToolTipText = "Insert pages (Memory mode only)";
         this._documentInsertPagesToolStripMenuItem.Click += new System.EventHandler(this._documentInsertPagesToolStripMenuItem_Click);
         // 
         // _documentRemoveCurrentPageToolStripMenuItem
         // 
         this._documentRemoveCurrentPageToolStripMenuItem.Name = "_documentRemoveCurrentPageToolStripMenuItem";
         this._documentRemoveCurrentPageToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
         this._documentRemoveCurrentPageToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
         this._documentRemoveCurrentPageToolStripMenuItem.Text = "&Remove current page";
         this._documentRemoveCurrentPageToolStripMenuItem.ToolTipText = "Remove current page (Memory mode only)";
         this._documentRemoveCurrentPageToolStripMenuItem.Click += new System.EventHandler(this._documentRemoveCurrentPageToolStripMenuItem_Click);
         // 
         // _documentClearDocumentPagesToolStripMenuItem
         // 
         this._documentClearDocumentPagesToolStripMenuItem.Name = "_documentClearDocumentPagesToolStripMenuItem";
         this._documentClearDocumentPagesToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
         this._documentClearDocumentPagesToolStripMenuItem.Text = "Cl&ear document pages";
         this._documentClearDocumentPagesToolStripMenuItem.ToolTipText = "Clear document pages (Memory mode only)";
         this._documentClearDocumentPagesToolStripMenuItem.Click += new System.EventHandler(this._documentClearDocumentPagesToolStripMenuItem_Click);
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(232, 6);
         // 
         // _documentSaveDocumentToolStripMenuItem
         // 
         this._documentSaveDocumentToolStripMenuItem.Image = global::OcrDemo.Properties.Resources.SaveDocument;
         this._documentSaveDocumentToolStripMenuItem.Name = "_documentSaveDocumentToolStripMenuItem";
         this._documentSaveDocumentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
         this._documentSaveDocumentToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
         this._documentSaveDocumentToolStripMenuItem.Text = "&Save document";
         this._documentSaveDocumentToolStripMenuItem.ToolTipText = "Save recognized document";
         this._documentSaveDocumentToolStripMenuItem.Click += new System.EventHandler(this._documentSaveDocumentToolStripMenuItem_Click);
         // 
         // _documentSaveRecognizedDataAsXmlToolStripMenuItem
         // 
         this._documentSaveRecognizedDataAsXmlToolStripMenuItem.Name = "_documentSaveRecognizedDataAsXmlToolStripMenuItem";
         this._documentSaveRecognizedDataAsXmlToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
         this._documentSaveRecognizedDataAsXmlToolStripMenuItem.Text = "Save recognized data as &XML...";
         this._documentSaveRecognizedDataAsXmlToolStripMenuItem.ToolTipText = "Save recognized data as XML (Memory mode only)";
         this._documentSaveRecognizedDataAsXmlToolStripMenuItem.Click += new System.EventHandler(this._documentSaveRecognizedDataAsXmlToolStripMenuItem_Click);
         // 
         // toolStripSeparator4
         // 
         this.toolStripSeparator4.Name = "toolStripSeparator4";
         this.toolStripSeparator4.Size = new System.Drawing.Size(232, 6);
         // 
         // _documentCloseDocumentToolStripMenuItem
         // 
         this._documentCloseDocumentToolStripMenuItem.Name = "_documentCloseDocumentToolStripMenuItem";
         this._documentCloseDocumentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
         this._documentCloseDocumentToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
         this._documentCloseDocumentToolStripMenuItem.Text = "Cl&ose Document";
         this._documentCloseDocumentToolStripMenuItem.ToolTipText = "Close document";
         this._documentCloseDocumentToolStripMenuItem.Click += new System.EventHandler(this._documentCloseDocumentToolStripMenuItem_Click);
         // 
         // _preferencesToolStripMenuItem
         // 
         this._preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._preferencesUseProgressBarsToolStripMenuItem});
         this._preferencesToolStripMenuItem.Name = "_preferencesToolStripMenuItem";
         this._preferencesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
         this._preferencesToolStripMenuItem.Text = "Prefere&nces";
         // 
         // _preferencesUseProgressBarsToolStripMenuItem
         // 
         this._preferencesUseProgressBarsToolStripMenuItem.Name = "_preferencesUseProgressBarsToolStripMenuItem";
         this._preferencesUseProgressBarsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
         this._preferencesUseProgressBarsToolStripMenuItem.Text = "&Use progress bars";
         this._preferencesUseProgressBarsToolStripMenuItem.Click += new System.EventHandler(this._preferencesUseProgressBarsToolStripMenuItem_Click);
         // 
         // _helpToolStripMenuItem
         // 
         this._helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._helpAboutToolStripMenuItem});
         this._helpToolStripMenuItem.Name = "_helpToolStripMenuItem";
         this._helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
         this._helpToolStripMenuItem.Text = "&Help";
         // 
         // _helpAboutToolStripMenuItem
         // 
         this._helpAboutToolStripMenuItem.Name = "_helpAboutToolStripMenuItem";
         this._helpAboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
         this._helpAboutToolStripMenuItem.Text = "&About...";
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
         this._mainToolStrip.Location = new System.Drawing.Point(0, 24);
         this._mainToolStrip.Name = "_mainToolStrip";
         this._mainToolStrip.Size = new System.Drawing.Size(984, 25);
         this._mainToolStrip.TabIndex = 1;
         this._mainToolStrip.Text = "toolStrip1";
         // 
         // _openDocumentToolStripButton
         // 
         this._openDocumentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._openDocumentToolStripButton.Image = global::OcrDemo.Properties.Resources.OpenDocument;
         this._openDocumentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._openDocumentToolStripButton.Name = "_openDocumentToolStripButton";
         this._openDocumentToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._openDocumentToolStripButton.ToolTipText = "Open document from disk";
         this._openDocumentToolStripButton.Click += new System.EventHandler(this._openDocumentToolStripButton_Click);
         // 
         // _toolStripSeparator1
         // 
         this._toolStripSeparator1.Name = "_toolStripSeparator1";
         this._toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // _autoZoneDocumentToolStripButton
         // 
         this._autoZoneDocumentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._autoZoneDocumentToolStripButton.Image = global::OcrDemo.Properties.Resources.AutoZoneDocument;
         this._autoZoneDocumentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._autoZoneDocumentToolStripButton.Name = "_autoZoneDocumentToolStripButton";
         this._autoZoneDocumentToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._autoZoneDocumentToolStripButton.ToolTipText = "Auto-locate the zones of all pages in this document";
         this._autoZoneDocumentToolStripButton.Click += new System.EventHandler(this._autoZoneDocumentToolStripButton_Click);
         // 
         // _autoZonePageToolStripButton
         // 
         this._autoZonePageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._autoZonePageToolStripButton.Image = global::OcrDemo.Properties.Resources.AutoZonePage;
         this._autoZonePageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._autoZonePageToolStripButton.Name = "_autoZonePageToolStripButton";
         this._autoZonePageToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._autoZonePageToolStripButton.ToolTipText = "Auto-locate the zones in the current page";
         this._autoZonePageToolStripButton.Click += new System.EventHandler(this._autoZonePageToolStripButton_Click);
         // 
         // _recognizeDocumentToolStripButton
         // 
         this._recognizeDocumentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._recognizeDocumentToolStripButton.Image = global::OcrDemo.Properties.Resources.RecognizeAllPages;
         this._recognizeDocumentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._recognizeDocumentToolStripButton.Name = "_recognizeDocumentToolStripButton";
         this._recognizeDocumentToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._recognizeDocumentToolStripButton.Text = "toolStripButton2";
         this._recognizeDocumentToolStripButton.ToolTipText = "Recognize all the pages in the document";
         this._recognizeDocumentToolStripButton.Click += new System.EventHandler(this._recognizeDocumentToolStripButton_Click);
         // 
         // _recognizePageToolStripButton
         // 
         this._recognizePageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._recognizePageToolStripButton.Image = global::OcrDemo.Properties.Resources.RecognizePage;
         this._recognizePageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._recognizePageToolStripButton.Name = "_recognizePageToolStripButton";
         this._recognizePageToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._recognizePageToolStripButton.ToolTipText = "Recognize the current page";
         this._recognizePageToolStripButton.Click += new System.EventHandler(this._recognizePageToolStripButton_Click);
         // 
         // _saveDocumentToolStripButton
         // 
         this._saveDocumentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._saveDocumentToolStripButton.Image = global::OcrDemo.Properties.Resources.SaveDocument;
         this._saveDocumentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._saveDocumentToolStripButton.Name = "_saveDocumentToolStripButton";
         this._saveDocumentToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._saveDocumentToolStripButton.ToolTipText = "Save recognized document";
         this._saveDocumentToolStripButton.Click += new System.EventHandler(this._saveDocumentToolStripButton_Click);
         // 
         // _mainStatusStrip
         // 
         this._mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._timingDescriptionToolStripStatusLabel,
            this._timingToolStripStatusLabel,
            this._activeSpellCheckerDescriptionToolStripStatusLabel,
            this._activeSpellCheckerToolStripStatusLabel});
         this._mainStatusStrip.Location = new System.Drawing.Point(0, 609);
         this._mainStatusStrip.Name = "_mainStatusStrip";
         this._mainStatusStrip.Size = new System.Drawing.Size(984, 22);
         this._mainStatusStrip.TabIndex = 2;
         this._mainStatusStrip.Text = "statusStrip1";
         // 
         // _timingDescriptionToolStripStatusLabel
         // 
         this._timingDescriptionToolStripStatusLabel.Name = "_timingDescriptionToolStripStatusLabel";
         this._timingDescriptionToolStripStatusLabel.Size = new System.Drawing.Size(85, 17);
         this._timingDescriptionToolStripStatusLabel.Text = "Last operation:";
         // 
         // _timingToolStripStatusLabel
         // 
         this._timingToolStripStatusLabel.AutoSize = false;
         this._timingToolStripStatusLabel.Name = "_timingToolStripStatusLabel";
         this._timingToolStripStatusLabel.Size = new System.Drawing.Size(400, 17);
         this._timingToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _activeSpellCheckerDescriptionToolStripStatusLabel
         // 
         this._activeSpellCheckerDescriptionToolStripStatusLabel.Name = "_activeSpellCheckerDescriptionToolStripStatusLabel";
         this._activeSpellCheckerDescriptionToolStripStatusLabel.Size = new System.Drawing.Size(117, 17);
         this._activeSpellCheckerDescriptionToolStripStatusLabel.Text = "Active Spell Checker:";
         // 
         // _activeSpellCheckerToolStripStatusLabel
         // 
         this._activeSpellCheckerToolStripStatusLabel.Name = "_activeSpellCheckerToolStripStatusLabel";
         this._activeSpellCheckerToolStripStatusLabel.Size = new System.Drawing.Size(36, 17);
         this._activeSpellCheckerToolStripStatusLabel.Text = "None";
         // 
         // _mainSplitContainer
         // 
         this._mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this._mainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
         this._mainSplitContainer.Location = new System.Drawing.Point(0, 49);
         this._mainSplitContainer.Name = "_mainSplitContainer";
         // 
         // _mainSplitContainer.Panel1
         // 
         this._mainSplitContainer.Panel1.Controls.Add(this._pagesControl);
         // 
         // _mainSplitContainer.Panel2
         // 
         this._mainSplitContainer.Panel2.Controls.Add(this._viewerVertSplitContainer);
         this._mainSplitContainer.Size = new System.Drawing.Size(984, 560);
         this._mainSplitContainer.SplitterDistance = 204;
         this._mainSplitContainer.TabIndex = 3;
         // 
         // _pagesControl
         // 
         this._pagesControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this._pagesControl.Location = new System.Drawing.Point(0, 0);
         this._pagesControl.Name = "_pagesControl";
         this._pagesControl.Size = new System.Drawing.Size(204, 560);
         this._pagesControl.TabIndex = 7;
         this._pagesControl.Action += new System.EventHandler<OcrDemo.ActionEventArgs>(this._pagesControl_Action);
         // 
         // _viewerVertSplitContainer
         // 
         this._viewerVertSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this._viewerVertSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
         this._viewerVertSplitContainer.Location = new System.Drawing.Point(0, 0);
         this._viewerVertSplitContainer.Name = "_viewerVertSplitContainer";
         // 
         // _viewerVertSplitContainer.Panel1
         // 
         this._viewerVertSplitContainer.Panel1.Controls.Add(this._viewerHorzSplitContainer);
         // 
         // _viewerVertSplitContainer.Panel2
         // 
         this._viewerVertSplitContainer.Panel2.Controls.Add(this._documentInfoControl);
         this._viewerVertSplitContainer.Size = new System.Drawing.Size(776, 560);
         this._viewerVertSplitContainer.SplitterDistance = 589;
         this._viewerVertSplitContainer.TabIndex = 0;
         // 
         // _viewerHorzSplitContainer
         // 
         this._viewerHorzSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this._viewerHorzSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
         this._viewerHorzSplitContainer.Location = new System.Drawing.Point(0, 0);
         this._viewerHorzSplitContainer.Name = "_viewerHorzSplitContainer";
         this._viewerHorzSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // _viewerHorzSplitContainer.Panel1
         // 
         this._viewerHorzSplitContainer.Panel1.Controls.Add(this._viewerControl);
         // 
         // _viewerHorzSplitContainer.Panel2
         // 
         this._viewerHorzSplitContainer.Panel2.Controls.Add(this._pageTextControl);
         this._viewerHorzSplitContainer.Size = new System.Drawing.Size(589, 560);
         this._viewerHorzSplitContainer.SplitterDistance = 425;
         this._viewerHorzSplitContainer.TabIndex = 0;
         // 
         // _viewerControl
         // 
         this._viewerControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this._viewerControl.Location = new System.Drawing.Point(0, 0);
         this._viewerControl.Name = "_viewerControl";
         this._viewerControl.Size = new System.Drawing.Size(589, 425);
         this._viewerControl.TabIndex = 7;
         this._viewerControl.Action += new System.EventHandler<OcrDemo.ActionEventArgs>(this._viewerControl_Action);
         // 
         // _pageTextControl
         // 
         this._pageTextControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._pageTextControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this._pageTextControl.Location = new System.Drawing.Point(0, 0);
         this._pageTextControl.Name = "_pageTextControl";
         this._pageTextControl.Size = new System.Drawing.Size(589, 131);
         this._pageTextControl.TabIndex = 1;
         // 
         // _documentInfoControl
         // 
         this._documentInfoControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this._documentInfoControl.Location = new System.Drawing.Point(0, 0);
         this._documentInfoControl.Name = "_documentInfoControl";
         this._documentInfoControl.Size = new System.Drawing.Size(183, 560);
         this._documentInfoControl.TabIndex = 0;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(984, 631);
         this.Controls.Add(this._mainSplitContainer);
         this.Controls.Add(this._mainStatusStrip);
         this.Controls.Add(this._mainToolStrip);
         this.Controls.Add(this._mainMenuStrip);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this._mainMenuStrip;
         this.Name = "MainForm";
         this.Text = "C# OCR Demo";
         this.Resize += new System.EventHandler(this.MainForm_Resize);
         this._mainMenuStrip.ResumeLayout(false);
         this._mainMenuStrip.PerformLayout();
         this._mainToolStrip.ResumeLayout(false);
         this._mainToolStrip.PerformLayout();
         this._mainStatusStrip.ResumeLayout(false);
         this._mainStatusStrip.PerformLayout();
         this._mainSplitContainer.Panel1.ResumeLayout(false);
         this._mainSplitContainer.Panel2.ResumeLayout(false);
         //((System.ComponentModel.ISupportInitialize)(this._mainSplitContainer)).EndInit();
         this._mainSplitContainer.ResumeLayout(false);
         this._viewerVertSplitContainer.Panel1.ResumeLayout(false);
         this._viewerVertSplitContainer.Panel2.ResumeLayout(false);
         //((System.ComponentModel.ISupportInitialize)(this._viewerVertSplitContainer)).EndInit();
         this._viewerVertSplitContainer.ResumeLayout(false);
         this._viewerHorzSplitContainer.Panel1.ResumeLayout(false);
         this._viewerHorzSplitContainer.Panel2.ResumeLayout(false);
         //((System.ComponentModel.ISupportInitialize)(this._viewerHorzSplitContainer)).EndInit();
         this._viewerHorzSplitContainer.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip _mainMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fileOpenToolStripMenuItem;
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
      private System.Windows.Forms.ToolStripMenuItem _pageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _pageCloseCurrentPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _recognizeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _helpToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _helpAboutToolStripMenuItem;
      private System.Windows.Forms.ToolStrip _mainToolStrip;
      private System.Windows.Forms.ToolStripButton _openDocumentToolStripButton;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton _autoZoneDocumentToolStripButton;
      private System.Windows.Forms.ToolStripButton _autoZonePageToolStripButton;
      private System.Windows.Forms.StatusStrip _mainStatusStrip;
      private System.Windows.Forms.ToolStripMenuItem _preferencesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _preferencesUseProgressBarsToolStripMenuItem;
      private System.Windows.Forms.ToolStripStatusLabel _timingToolStripStatusLabel;
      private System.Windows.Forms.ToolStripStatusLabel _timingDescriptionToolStripStatusLabel;
      private System.Windows.Forms.ToolStripSeparator _fileSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fileConvertLDToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _recognizeOmrOptionsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _pageSaveProcessingImageToDiskToolStripMenuItem;
      private System.Windows.Forms.ToolStripButton _recognizeDocumentToolStripButton;
      private System.Windows.Forms.ToolStripButton _recognizePageToolStripButton;
      private System.Windows.Forms.ToolStripButton _saveDocumentToolStripButton;
      private System.Windows.Forms.ToolStripMenuItem _recognizeRecognizeDocumentToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _recognizeRecognizePageToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _ocrSep2ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _pageDetectPageLanguagesToolStripMenuItem;
      private System.Windows.Forms.SplitContainer _mainSplitContainer;
      private PagesControl.PagesControl _pagesControl;
      private System.Windows.Forms.SplitContainer _viewerVertSplitContainer;
      private System.Windows.Forms.SplitContainer _viewerHorzSplitContainer;
      private ViewerControl.ViewerControl _viewerControl;
      private PageTextControl.PageTextControl _pageTextControl;
      private DocumentInfoControl.DocumentInfoControl _documentInfoControl;
      private System.Windows.Forms.ToolStripMenuItem _documentToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _documentInsertPagesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _documentCreateDocumentToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripMenuItem _documentAddCurrentPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _documentRemoveCurrentPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _documentClearDocumentPagesToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripMenuItem _documentCloseDocumentToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _recognizeSpellCheckEngineStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processAllPagesToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _processSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processFlipToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processReverseToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processRotate90ClockwiseToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processRotate90CounterClockwiseToolStripMenuItem;
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
      private System.Windows.Forms.ToolStripMenuItem _documentCleanupToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processAutoCropToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processDespeckleToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processErodeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processDilateToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processUnditherTextToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processFixBrokenLettersToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processLineRemoveToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _binarizationToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processAutoBinarizeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processDynamicBinarizeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _brightnessToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processHisogramEqualToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processAutoLevelToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processContrastBrightnessIntensityToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _zonesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _zonesAutoZoneDocumentToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _zonesAutoZoneCurrentPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _zonesSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _zonesUpdateZonesToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _zonesSep2ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _zonesLoadZonesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _zonesSaveZonesToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _zonesSep3ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _loadAllPagesZonesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _saveAllPagesZonesToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _zonesSep4ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _clearAllPagesZonesToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _zonesSep5ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _zonesShowZonesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _zonesShowZoneNamesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _documentSaveDocumentToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem _recognizeSaveAfterRecognizeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _documentLoadDocumentToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
      private System.Windows.Forms.ToolStripMenuItem _dualPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processPageSplitterToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _processExpandContentToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fileSetPDFLoadResolutionToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
      private System.Windows.Forms.ToolStripMenuItem _inversePerspectiveToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _perspectiveDeskewToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _manualPerspectiveToolStripMenuItem;
      private System.Windows.Forms.ToolStripStatusLabel _activeSpellCheckerDescriptionToolStripStatusLabel;
      private System.Windows.Forms.ToolStripStatusLabel _activeSpellCheckerToolStripStatusLabel;
      private System.Windows.Forms.ToolStripMenuItem _pageSaveRecognizedDataAsXmlToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _documentSaveRecognizedDataAsXmlToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _unwarpToolStripMenuItem;
   }
}

