namespace PDFDocumentDemo
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
         this._openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._fileSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._exportTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._fileSep2ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._fontsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._fileSep3ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._editToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
         this._copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._editSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._clearSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._editSep2ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._findNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._findPreviousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._fitWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._fitPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewSep2ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._thumbnailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._bookmarksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._signaturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewSep3ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._highlightObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._pageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._previousPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._nextPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._gotoPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._interactiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._selectModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._highlightTextModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._panModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._zoomToModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._annotationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._showAnnotationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._annotationsObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._annotationsSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._selectNextObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._selectPreviousObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._annotationsSep2ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._objectPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._objectContentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._deleteObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._mainToolStrip = new System.Windows.Forms.ToolStrip();
         this._openToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this._findToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
         this._findPreviousToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._findNextToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._bottomPanel = new System.Windows.Forms.Panel();
         this._splitter = new System.Windows.Forms.Splitter();
         this._viewerControl = new PDFDocumentDemo.ViewerControl.ViewerControl();
         this._pagesControl = new PDFDocumentDemo.PagesControl.PagesControl();
         this._annotationsControl = new PDFDocumentDemo.Annotations.AnnotationsControl();
         this._mainMenuStrip.SuspendLayout();
         this._mainToolStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // _mainMenuStrip
         // 
         this._mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem,
            this._editToolStripMenuItem2,
            this._viewToolStripMenuItem,
            this._pageToolStripMenuItem,
            this._interactiveToolStripMenuItem,
            this._annotationsToolStripMenuItem,
            this._helpToolStripMenuItem});
         resources.ApplyResources(this._mainMenuStrip, "_mainMenuStrip");
         this._mainMenuStrip.Name = "_mainMenuStrip";
         // 
         // _fileToolStripMenuItem
         // 
         this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openToolStripMenuItem,
            this._saveToolStripMenuItem,
            this._saveAsToolStripMenuItem,
            this._closeToolStripMenuItem,
            this._fileSep1ToolStripMenuItem,
            this._exportTextToolStripMenuItem,
            this._fileSep2ToolStripMenuItem,
            this._propertiesToolStripMenuItem,
            this._fontsToolStripMenuItem,
            this._fileSep3ToolStripMenuItem,
            this._exitToolStripMenuItem});
         this._fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
         resources.ApplyResources(this._fileToolStripMenuItem, "_fileToolStripMenuItem");
         this._fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this._fileToolStripMenuItem_DropDownOpening);
         // 
         // _openToolStripMenuItem
         // 
         this._openToolStripMenuItem.Image = global::PDFDocumentDemo.Properties.Resources.OpenDocument;
         this._openToolStripMenuItem.Name = "_openToolStripMenuItem";
         resources.ApplyResources(this._openToolStripMenuItem, "_openToolStripMenuItem");
         this._openToolStripMenuItem.Click += new System.EventHandler(this._openToolStripMenuItem_Click);
         // 
         // _saveToolStripMenuItem
         // 
         this._saveToolStripMenuItem.Image = global::PDFDocumentDemo.Properties.Resources.SaveDocument;
         this._saveToolStripMenuItem.Name = "_saveToolStripMenuItem";
         resources.ApplyResources(this._saveToolStripMenuItem, "_saveToolStripMenuItem");
         this._saveToolStripMenuItem.Click += new System.EventHandler(this._saveToolStripMenuItem_Click);
         // 
         // _saveAsToolStripMenuItem
         // 
         this._saveAsToolStripMenuItem.Name = "_saveAsToolStripMenuItem";
         resources.ApplyResources(this._saveAsToolStripMenuItem, "_saveAsToolStripMenuItem");
         this._saveAsToolStripMenuItem.Click += new System.EventHandler(this._saveAsToolStripMenuItem_Click);
         // 
         // _closeToolStripMenuItem
         // 
         this._closeToolStripMenuItem.Name = "_closeToolStripMenuItem";
         resources.ApplyResources(this._closeToolStripMenuItem, "_closeToolStripMenuItem");
         this._closeToolStripMenuItem.Click += new System.EventHandler(this._closeToolStripMenuItem_Click);
         // 
         // _fileSep1ToolStripMenuItem
         // 
         this._fileSep1ToolStripMenuItem.Name = "_fileSep1ToolStripMenuItem";
         resources.ApplyResources(this._fileSep1ToolStripMenuItem, "_fileSep1ToolStripMenuItem");
         // 
         // _exportTextToolStripMenuItem
         // 
         this._exportTextToolStripMenuItem.Name = "_exportTextToolStripMenuItem";
         resources.ApplyResources(this._exportTextToolStripMenuItem, "_exportTextToolStripMenuItem");
         this._exportTextToolStripMenuItem.Click += new System.EventHandler(this._exportTextToolStripMenuItem_Click);
         // 
         // _fileSep2ToolStripMenuItem
         // 
         this._fileSep2ToolStripMenuItem.Name = "_fileSep2ToolStripMenuItem";
         resources.ApplyResources(this._fileSep2ToolStripMenuItem, "_fileSep2ToolStripMenuItem");
         // 
         // _propertiesToolStripMenuItem
         // 
         this._propertiesToolStripMenuItem.Name = "_propertiesToolStripMenuItem";
         resources.ApplyResources(this._propertiesToolStripMenuItem, "_propertiesToolStripMenuItem");
         this._propertiesToolStripMenuItem.Click += new System.EventHandler(this._propertiesToolStripMenuItem_Click);
         // 
         // _fontsToolStripMenuItem
         // 
         this._fontsToolStripMenuItem.Name = "_fontsToolStripMenuItem";
         resources.ApplyResources(this._fontsToolStripMenuItem, "_fontsToolStripMenuItem");
         this._fontsToolStripMenuItem.Click += new System.EventHandler(this._fontsToolStripMenuItem_Click);
         // 
         // _fileSep3ToolStripMenuItem
         // 
         this._fileSep3ToolStripMenuItem.Name = "_fileSep3ToolStripMenuItem";
         resources.ApplyResources(this._fileSep3ToolStripMenuItem, "_fileSep3ToolStripMenuItem");
         // 
         // _exitToolStripMenuItem
         // 
         this._exitToolStripMenuItem.Name = "_exitToolStripMenuItem";
         resources.ApplyResources(this._exitToolStripMenuItem, "_exitToolStripMenuItem");
         this._exitToolStripMenuItem.Click += new System.EventHandler(this._exitToolStripMenuItem_Click);
         // 
         // _editToolStripMenuItem2
         // 
         this._editToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._copyToolStripMenuItem,
            this._editSep1ToolStripMenuItem,
            this._selectAllToolStripMenuItem,
            this._clearSelectionToolStripMenuItem,
            this._editSep2ToolStripMenuItem,
            this._findToolStripMenuItem,
            this._findNextToolStripMenuItem,
            this._findPreviousToolStripMenuItem});
         this._editToolStripMenuItem2.Name = "_editToolStripMenuItem2";
         resources.ApplyResources(this._editToolStripMenuItem2, "_editToolStripMenuItem2");
         this._editToolStripMenuItem2.DropDownOpening += new System.EventHandler(this._editToolStripMenuItem_DropDownOpening);
         // 
         // _copyToolStripMenuItem
         // 
         this._copyToolStripMenuItem.Image = global::PDFDocumentDemo.Properties.Resources.Copy;
         this._copyToolStripMenuItem.Name = "_copyToolStripMenuItem";
         resources.ApplyResources(this._copyToolStripMenuItem, "_copyToolStripMenuItem");
         this._copyToolStripMenuItem.Click += new System.EventHandler(this._copyToolStripMenuItem_Click);
         // 
         // _editSep1ToolStripMenuItem
         // 
         this._editSep1ToolStripMenuItem.Name = "_editSep1ToolStripMenuItem";
         resources.ApplyResources(this._editSep1ToolStripMenuItem, "_editSep1ToolStripMenuItem");
         // 
         // _selectAllToolStripMenuItem
         // 
         this._selectAllToolStripMenuItem.Name = "_selectAllToolStripMenuItem";
         resources.ApplyResources(this._selectAllToolStripMenuItem, "_selectAllToolStripMenuItem");
         this._selectAllToolStripMenuItem.Click += new System.EventHandler(this._selectAllToolStripMenuItem_Click);
         // 
         // _clearSelectionToolStripMenuItem
         // 
         this._clearSelectionToolStripMenuItem.Name = "_clearSelectionToolStripMenuItem";
         resources.ApplyResources(this._clearSelectionToolStripMenuItem, "_clearSelectionToolStripMenuItem");
         this._clearSelectionToolStripMenuItem.Click += new System.EventHandler(this._clearSelectionToolStripMenuItem_Click);
         // 
         // _editSep2ToolStripMenuItem
         // 
         this._editSep2ToolStripMenuItem.Name = "_editSep2ToolStripMenuItem";
         resources.ApplyResources(this._editSep2ToolStripMenuItem, "_editSep2ToolStripMenuItem");
         // 
         // _findToolStripMenuItem
         // 
         this._findToolStripMenuItem.Image = global::PDFDocumentDemo.Properties.Resources.Find;
         this._findToolStripMenuItem.Name = "_findToolStripMenuItem";
         resources.ApplyResources(this._findToolStripMenuItem, "_findToolStripMenuItem");
         this._findToolStripMenuItem.Click += new System.EventHandler(this._findToolStripMenuItem_Click);
         // 
         // _findNextToolStripMenuItem
         // 
         this._findNextToolStripMenuItem.Image = global::PDFDocumentDemo.Properties.Resources.FindNext;
         this._findNextToolStripMenuItem.Name = "_findNextToolStripMenuItem";
         resources.ApplyResources(this._findNextToolStripMenuItem, "_findNextToolStripMenuItem");
         this._findNextToolStripMenuItem.Click += new System.EventHandler(this._findNextToolStripMenuItem_Click);
         // 
         // _findPreviousToolStripMenuItem
         // 
         this._findPreviousToolStripMenuItem.Image = global::PDFDocumentDemo.Properties.Resources.FindPrevious;
         this._findPreviousToolStripMenuItem.Name = "_findPreviousToolStripMenuItem";
         resources.ApplyResources(this._findPreviousToolStripMenuItem, "_findPreviousToolStripMenuItem");
         this._findPreviousToolStripMenuItem.Click += new System.EventHandler(this._findPreviousToolStripMenuItem_Click);
         // 
         // _viewToolStripMenuItem
         // 
         this._viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._zoomOutToolStripMenuItem,
            this._zoomInToolStripMenuItem,
            this._viewSep1ToolStripMenuItem,
            this._fitWidthToolStripMenuItem,
            this._fitPageToolStripMenuItem,
            this._viewSep2ToolStripMenuItem,
            this._thumbnailsToolStripMenuItem,
            this._bookmarksToolStripMenuItem,
            this._signaturesToolStripMenuItem,
            this._viewSep3ToolStripMenuItem,
            this._highlightObjectsToolStripMenuItem});
         this._viewToolStripMenuItem.Name = "_viewToolStripMenuItem";
         resources.ApplyResources(this._viewToolStripMenuItem, "_viewToolStripMenuItem");
         this._viewToolStripMenuItem.DropDownOpening += new System.EventHandler(this._viewToolStripMenuItem_DropDownOpening);
         // 
         // _zoomOutToolStripMenuItem
         // 
         this._zoomOutToolStripMenuItem.Image = global::PDFDocumentDemo.Properties.Resources.ZoomOut;
         this._zoomOutToolStripMenuItem.Name = "_zoomOutToolStripMenuItem";
         resources.ApplyResources(this._zoomOutToolStripMenuItem, "_zoomOutToolStripMenuItem");
         this._zoomOutToolStripMenuItem.Click += new System.EventHandler(this._zoomOutToolStripMenuItem_Click);
         // 
         // _zoomInToolStripMenuItem
         // 
         this._zoomInToolStripMenuItem.Image = global::PDFDocumentDemo.Properties.Resources.ZoomIn;
         this._zoomInToolStripMenuItem.Name = "_zoomInToolStripMenuItem";
         resources.ApplyResources(this._zoomInToolStripMenuItem, "_zoomInToolStripMenuItem");
         this._zoomInToolStripMenuItem.Click += new System.EventHandler(this._zoomInToolStripMenuItem_Click);
         // 
         // _viewSep1ToolStripMenuItem
         // 
         this._viewSep1ToolStripMenuItem.Name = "_viewSep1ToolStripMenuItem";
         resources.ApplyResources(this._viewSep1ToolStripMenuItem, "_viewSep1ToolStripMenuItem");
         // 
         // _fitWidthToolStripMenuItem
         // 
         this._fitWidthToolStripMenuItem.Image = global::PDFDocumentDemo.Properties.Resources.FitPageWidth;
         this._fitWidthToolStripMenuItem.Name = "_fitWidthToolStripMenuItem";
         resources.ApplyResources(this._fitWidthToolStripMenuItem, "_fitWidthToolStripMenuItem");
         this._fitWidthToolStripMenuItem.Click += new System.EventHandler(this._fitWidthToolStripMenuItem_Click);
         // 
         // _fitPageToolStripMenuItem
         // 
         this._fitPageToolStripMenuItem.Image = global::PDFDocumentDemo.Properties.Resources.FitPage;
         this._fitPageToolStripMenuItem.Name = "_fitPageToolStripMenuItem";
         resources.ApplyResources(this._fitPageToolStripMenuItem, "_fitPageToolStripMenuItem");
         this._fitPageToolStripMenuItem.Click += new System.EventHandler(this._fitPageToolStripMenuItem_Click);
         // 
         // _viewSep2ToolStripMenuItem
         // 
         this._viewSep2ToolStripMenuItem.Name = "_viewSep2ToolStripMenuItem";
         resources.ApplyResources(this._viewSep2ToolStripMenuItem, "_viewSep2ToolStripMenuItem");
         // 
         // _thumbnailsToolStripMenuItem
         // 
         this._thumbnailsToolStripMenuItem.Image = global::PDFDocumentDemo.Properties.Resources.Thumbnails;
         this._thumbnailsToolStripMenuItem.Name = "_thumbnailsToolStripMenuItem";
         resources.ApplyResources(this._thumbnailsToolStripMenuItem, "_thumbnailsToolStripMenuItem");
         this._thumbnailsToolStripMenuItem.Click += new System.EventHandler(this._thumbnailsToolStripMenuItem_Click);
         // 
         // _bookmarksToolStripMenuItem
         // 
         this._bookmarksToolStripMenuItem.Image = global::PDFDocumentDemo.Properties.Resources.Bookmarks;
         this._bookmarksToolStripMenuItem.Name = "_bookmarksToolStripMenuItem";
         resources.ApplyResources(this._bookmarksToolStripMenuItem, "_bookmarksToolStripMenuItem");
         this._bookmarksToolStripMenuItem.Click += new System.EventHandler(this._bookmarksToolStripMenuItem_Click);
         // 
         // _viewSep3ToolStripMenuItem
         // 
         this._viewSep3ToolStripMenuItem.Name = "_viewSep3ToolStripMenuItem";
         resources.ApplyResources(this._viewSep3ToolStripMenuItem, "_viewSep3ToolStripMenuItem");
         // 
         // _highlightObjectsToolStripMenuItem
         // 
         this._highlightObjectsToolStripMenuItem.Image = global::PDFDocumentDemo.Properties.Resources.HighlightObjects;
         this._highlightObjectsToolStripMenuItem.Name = "_highlightObjectsToolStripMenuItem";
         resources.ApplyResources(this._highlightObjectsToolStripMenuItem, "_highlightObjectsToolStripMenuItem");
         this._highlightObjectsToolStripMenuItem.Click += new System.EventHandler(this._highlightObjectsToolStripMenuItem_Click);
         // 
         // _pageToolStripMenuItem
         // 
         this._pageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._previousPageToolStripMenuItem,
            this._nextPageToolStripMenuItem,
            this._gotoPageToolStripMenuItem});
         this._pageToolStripMenuItem.Name = "_pageToolStripMenuItem";
         resources.ApplyResources(this._pageToolStripMenuItem, "_pageToolStripMenuItem");
         this._pageToolStripMenuItem.DropDownOpening += new System.EventHandler(this._pageToolStripMenuItem_DropDownOpening);
         // 
         // _previousPageToolStripMenuItem
         // 
         this._previousPageToolStripMenuItem.Image = global::PDFDocumentDemo.Properties.Resources.PreviousPage;
         this._previousPageToolStripMenuItem.Name = "_previousPageToolStripMenuItem";
         resources.ApplyResources(this._previousPageToolStripMenuItem, "_previousPageToolStripMenuItem");
         this._previousPageToolStripMenuItem.Click += new System.EventHandler(this._previousPageToolStripMenuItem_Click);
         // 
         // _nextPageToolStripMenuItem
         // 
         this._nextPageToolStripMenuItem.Image = global::PDFDocumentDemo.Properties.Resources.NextPage;
         this._nextPageToolStripMenuItem.Name = "_nextPageToolStripMenuItem";
         resources.ApplyResources(this._nextPageToolStripMenuItem, "_nextPageToolStripMenuItem");
         this._nextPageToolStripMenuItem.Click += new System.EventHandler(this._nextPageToolStripMenuItem_Click);
         // 
         // _gotoPageToolStripMenuItem
         // 
         this._gotoPageToolStripMenuItem.Name = "_gotoPageToolStripMenuItem";
         resources.ApplyResources(this._gotoPageToolStripMenuItem, "_gotoPageToolStripMenuItem");
         this._gotoPageToolStripMenuItem.Click += new System.EventHandler(this._gotoPageToolStripMenuItem_Click);
         // 
         // _interactiveToolStripMenuItem
         // 
         this._interactiveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._selectModeToolStripMenuItem,
            this._highlightTextModeToolStripMenuItem,
            this._panModeToolStripMenuItem,
            this._zoomToModeToolStripMenuItem});
         this._interactiveToolStripMenuItem.Name = "_interactiveToolStripMenuItem";
         resources.ApplyResources(this._interactiveToolStripMenuItem, "_interactiveToolStripMenuItem");
         this._interactiveToolStripMenuItem.DropDownOpening += new System.EventHandler(this._interactiveToolStripMenuItem_DropDownOpening);
         // 
         // _selectModeToolStripMenuItem
         // 
         this._selectModeToolStripMenuItem.Image = global::PDFDocumentDemo.Properties.Resources.SelectMode;
         this._selectModeToolStripMenuItem.Name = "_selectModeToolStripMenuItem";
         resources.ApplyResources(this._selectModeToolStripMenuItem, "_selectModeToolStripMenuItem");
         this._selectModeToolStripMenuItem.Click += new System.EventHandler(this._selectModeToolStripMenuItem_Click);
         // 
         // _highlightTextModeToolStripMenuItem
         // 
         this._highlightTextModeToolStripMenuItem.Image = global::PDFDocumentDemo.Properties.Resources.HighlightText;
         this._highlightTextModeToolStripMenuItem.Name = "_highlightTextModeToolStripMenuItem";
         resources.ApplyResources(this._highlightTextModeToolStripMenuItem, "_highlightTextModeToolStripMenuItem");
         this._highlightTextModeToolStripMenuItem.Click += new System.EventHandler(this._highlightTextModeToolStripMenuItem_Click);
         // 
         // _panModeToolStripMenuItem
         // 
         this._panModeToolStripMenuItem.Image = global::PDFDocumentDemo.Properties.Resources.PanMode;
         this._panModeToolStripMenuItem.Name = "_panModeToolStripMenuItem";
         resources.ApplyResources(this._panModeToolStripMenuItem, "_panModeToolStripMenuItem");
         this._panModeToolStripMenuItem.Click += new System.EventHandler(this._panModeToolStripMenuItem_Click);
         // 
         // _zoomToModeToolStripMenuItem
         // 
         this._zoomToModeToolStripMenuItem.Image = global::PDFDocumentDemo.Properties.Resources.ZoomSelection;
         this._zoomToModeToolStripMenuItem.Name = "_zoomToModeToolStripMenuItem";
         resources.ApplyResources(this._zoomToModeToolStripMenuItem, "_zoomToModeToolStripMenuItem");
         this._zoomToModeToolStripMenuItem.Click += new System.EventHandler(this._zoomToModeToolStripMenuItem_Click);
         // 
         // _annotationsToolStripMenuItem
         // 
         this._annotationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._showAnnotationsToolStripMenuItem,
            this._annotationsObjectToolStripMenuItem,
            this._annotationsSep1ToolStripMenuItem,
            this._selectNextObjectToolStripMenuItem,
            this._selectPreviousObjectToolStripMenuItem,
            this._annotationsSep2ToolStripMenuItem,
            this._objectPropertiesToolStripMenuItem,
            this._objectContentToolStripMenuItem,
            this._deleteObjectToolStripMenuItem});
         this._annotationsToolStripMenuItem.Name = "_annotationsToolStripMenuItem";
         resources.ApplyResources(this._annotationsToolStripMenuItem, "_annotationsToolStripMenuItem");
         this._annotationsToolStripMenuItem.DropDownOpening += new System.EventHandler(this._annotationsToolStripMenuItem_DropDownOpening);
         // 
         // _showAnnotationsToolStripMenuItem
         // 
         this._showAnnotationsToolStripMenuItem.Image = global::PDFDocumentDemo.Properties.Resources.Annotations;
         this._showAnnotationsToolStripMenuItem.Name = "_showAnnotationsToolStripMenuItem";
         resources.ApplyResources(this._showAnnotationsToolStripMenuItem, "_showAnnotationsToolStripMenuItem");
         this._showAnnotationsToolStripMenuItem.Click += new System.EventHandler(this._showAnnotationsToolStripMenuItem_Click);
         // 
         // _annotationsObjectToolStripMenuItem
         // 
         this._annotationsObjectToolStripMenuItem.Name = "_annotationsObjectToolStripMenuItem";
         resources.ApplyResources(this._annotationsObjectToolStripMenuItem, "_annotationsObjectToolStripMenuItem");
         this._annotationsObjectToolStripMenuItem.DropDownOpening += new System.EventHandler(this._annotationsObjectToolStripMenuItem_DropDownOpening);
         // 
         // _annotationsSep1ToolStripMenuItem
         // 
         this._annotationsSep1ToolStripMenuItem.Name = "_annotationsSep1ToolStripMenuItem";
         resources.ApplyResources(this._annotationsSep1ToolStripMenuItem, "_annotationsSep1ToolStripMenuItem");
         // 
         // _selectNextObjectToolStripMenuItem
         // 
         this._selectNextObjectToolStripMenuItem.Name = "_selectNextObjectToolStripMenuItem";
         resources.ApplyResources(this._selectNextObjectToolStripMenuItem, "_selectNextObjectToolStripMenuItem");
         this._selectNextObjectToolStripMenuItem.Click += new System.EventHandler(this._selectNextObjectToolStripMenuItem_Click);
         // 
         // _selectPreviousObjectToolStripMenuItem
         // 
         this._selectPreviousObjectToolStripMenuItem.Name = "_selectPreviousObjectToolStripMenuItem";
         resources.ApplyResources(this._selectPreviousObjectToolStripMenuItem, "_selectPreviousObjectToolStripMenuItem");
         this._selectPreviousObjectToolStripMenuItem.Click += new System.EventHandler(this._selectPreviousObjectToolStripMenuItem_Click);
         // 
         // _annotationsSep2ToolStripMenuItem
         // 
         this._annotationsSep2ToolStripMenuItem.Name = "_annotationsSep2ToolStripMenuItem";
         resources.ApplyResources(this._annotationsSep2ToolStripMenuItem, "_annotationsSep2ToolStripMenuItem");
         // 
         // _objectPropertiesToolStripMenuItem
         // 
         this._objectPropertiesToolStripMenuItem.Name = "_objectPropertiesToolStripMenuItem";
         resources.ApplyResources(this._objectPropertiesToolStripMenuItem, "_objectPropertiesToolStripMenuItem");
         this._objectPropertiesToolStripMenuItem.Click += new System.EventHandler(this._objectPropertiesToolStripMenuItem_Click);
         // 
         // _objectContentToolStripMenuItem
         // 
         this._objectContentToolStripMenuItem.Name = "_objectContentToolStripMenuItem";
         resources.ApplyResources(this._objectContentToolStripMenuItem, "_objectContentToolStripMenuItem");
         this._objectContentToolStripMenuItem.Click += new System.EventHandler(this._objectContentToolStripMenuItem_Click);
         // 
         // _deleteObjectToolStripMenuItem
         // 
         this._deleteObjectToolStripMenuItem.Name = "_deleteObjectToolStripMenuItem";
         resources.ApplyResources(this._deleteObjectToolStripMenuItem, "_deleteObjectToolStripMenuItem");
         this._deleteObjectToolStripMenuItem.Click += new System.EventHandler(this._deleteObjectToolStripMenuItem_Click);
         // 
         // _helpToolStripMenuItem
         // 
         this._helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
         this._helpToolStripMenuItem.Name = "_helpToolStripMenuItem";
         resources.ApplyResources(this._helpToolStripMenuItem, "_helpToolStripMenuItem");
         // 
         // _aboutToolStripMenuItem
         // 
         this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
         resources.ApplyResources(this._aboutToolStripMenuItem, "_aboutToolStripMenuItem");
         this._aboutToolStripMenuItem.Click += new System.EventHandler(this._aboutToolStripMenuItem_Click);
         // 
         // _mainToolStrip
         // 
         this._mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openToolStripButton,
            this._toolStripSeparator1,
            this._findToolStripTextBox,
            this._findPreviousToolStripButton,
            this._findNextToolStripButton});
         resources.ApplyResources(this._mainToolStrip, "_mainToolStrip");
         this._mainToolStrip.Name = "_mainToolStrip";
         // 
         // _openToolStripButton
         // 
         this._openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._openToolStripButton.Image = global::PDFDocumentDemo.Properties.Resources.OpenDocument;
         resources.ApplyResources(this._openToolStripButton, "_openToolStripButton");
         this._openToolStripButton.Name = "_openToolStripButton";
         this._openToolStripButton.Click += new System.EventHandler(this._openToolStripButton_Click);
         // 
         // _toolStripSeparator1
         // 
         this._toolStripSeparator1.Name = "_toolStripSeparator1";
         resources.ApplyResources(this._toolStripSeparator1, "_toolStripSeparator1");
         // 
         // _findToolStripTextBox
         // 
         this._findToolStripTextBox.Name = "_findToolStripTextBox";
         resources.ApplyResources(this._findToolStripTextBox, "_findToolStripTextBox");
         this._findToolStripTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this._findToolStripTextBox_KeyDown);
         this._findToolStripTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._findToolStripTextBox_KeyPress);
         // 
         // _findPreviousToolStripButton
         // 
         this._findPreviousToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._findPreviousToolStripButton.Image = global::PDFDocumentDemo.Properties.Resources.FindPrevious;
         resources.ApplyResources(this._findPreviousToolStripButton, "_findPreviousToolStripButton");
         this._findPreviousToolStripButton.Name = "_findPreviousToolStripButton";
         this._findPreviousToolStripButton.Click += new System.EventHandler(this._findPreviousToolStripButton_Click);
         // 
         // _findNextToolStripButton
         // 
         this._findNextToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._findNextToolStripButton.Image = global::PDFDocumentDemo.Properties.Resources.FindNext;
         resources.ApplyResources(this._findNextToolStripButton, "_findNextToolStripButton");
         this._findNextToolStripButton.Name = "_findNextToolStripButton";
         this._findNextToolStripButton.Click += new System.EventHandler(this._findNextToolStripButton_Click);
         // 
         // _bottomPanel
         // 
         this._bottomPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         resources.ApplyResources(this._bottomPanel, "_bottomPanel");
         this._bottomPanel.Name = "_bottomPanel";
         // 
         // _splitter
         // 
         resources.ApplyResources(this._splitter, "_splitter");
         this._splitter.Name = "_splitter";
         this._splitter.TabStop = false;
         // 
         // _viewerControl
         // 
         resources.ApplyResources(this._viewerControl, "_viewerControl");
         this._viewerControl.Name = "_viewerControl";
         this._viewerControl.InteractiveModeChanged += new System.EventHandler(this._viewerControl_InteractiveModeChanged);
         this._viewerControl.Action += new System.EventHandler<PDFDocumentDemo.ActionEventArgs>(this._viewerControl_Action);
         // 
         // _pagesControl
         // 
         resources.ApplyResources(this._pagesControl, "_pagesControl");
         this._pagesControl.Name = "_pagesControl";
         this._pagesControl.Action += new System.EventHandler<PDFDocumentDemo.ActionEventArgs>(this._pagesControl_Action);
         this._pagesControl.Width = 200;
         // 
         // _annotationsControl
         // 
         resources.ApplyResources(this._annotationsControl, "_annotationsControl");
         this._annotationsControl.DocumentAnnotations = null;
         this._annotationsControl.Name = "_annotationsControl";
         // 
         // _signaturesToolStripMenuItem
         // 
         this._signaturesToolStripMenuItem.Image = global::PDFDocumentDemo.Properties.Resources.Signature;
         this._signaturesToolStripMenuItem.Name = "_signaturesToolStripMenuItem";
         resources.ApplyResources(this._signaturesToolStripMenuItem, "_signaturesToolStripMenuItem");
         this._signaturesToolStripMenuItem.Click += new System.EventHandler(this._signaturesToolStripMenuItem_Click);
         // 
         // MainForm
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._viewerControl);
         this.Controls.Add(this._annotationsControl);
         this.Controls.Add(this._splitter);
         this.Controls.Add(this._pagesControl);
         this.Controls.Add(this._bottomPanel);
         this.Controls.Add(this._mainToolStrip);
         this.Controls.Add(this._mainMenuStrip);
         this.Name = "MainForm";
         this._mainMenuStrip.ResumeLayout(false);
         this._mainMenuStrip.PerformLayout();
         this._mainToolStrip.ResumeLayout(false);
         this._mainToolStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip _mainMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _openToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _fileSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _exitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _zoomOutToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _zoomInToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _viewSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fitWidthToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fitPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _pageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _previousPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _nextPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _gotoPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _interactiveToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _selectModeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _panModeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _zoomToModeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _helpToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
      private System.Windows.Forms.ToolStrip _mainToolStrip;
      private System.Windows.Forms.ToolStripButton _openToolStripButton;
      private System.Windows.Forms.Panel _bottomPanel;
      private PagesControl.PagesControl _pagesControl;
      private ViewerControl.ViewerControl _viewerControl;
      private System.Windows.Forms.ToolStripMenuItem _closeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _editToolStripMenuItem2;
      private System.Windows.Forms.ToolStripMenuItem _findToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _findNextToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator1;
      private System.Windows.Forms.ToolStripTextBox _findToolStripTextBox;
      private System.Windows.Forms.ToolStripButton _findNextToolStripButton;
      private System.Windows.Forms.ToolStripButton _findPreviousToolStripButton;
      private System.Windows.Forms.ToolStripSeparator _editSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _findPreviousToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _copyToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _selectAllToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _editSep2ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _clearSelectionToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _exportTextToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _propertiesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fontsToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _fileSep2ToolStripMenuItem;
      private System.Windows.Forms.Splitter _splitter;
      private System.Windows.Forms.ToolStripSeparator _viewSep2ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _thumbnailsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _bookmarksToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _signaturesToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _viewSep3ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _highlightObjectsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _highlightTextModeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _annotationsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _showAnnotationsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _annotationsObjectToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _selectNextObjectToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _selectPreviousObjectToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _saveToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _saveAsToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _fileSep3ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _objectPropertiesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _objectContentToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _annotationsSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _annotationsSep2ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _deleteObjectToolStripMenuItem;
      private Annotations.AnnotationsControl _annotationsControl;
   }
}