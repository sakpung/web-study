namespace OcrEditDemo
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
         if (disposing && (components != null))
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
         this._fileSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._fileSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._fileExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewZoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewZoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._viewFitWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewFitPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewSep2ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._viewHighlightRecognizedWordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._wordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._wordUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._wordDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._preferencesPdfResolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._preferencesUseCallbacksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._preferencesViewSavedDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._helpAboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewerToolStrip = new System.Windows.Forms.ToolStrip();
         this._openToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._saveToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._viewerToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this._zoomOutToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._zoomInToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._zoomToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
         this._fitPageWidthToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._fitPageToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._viewerToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this._highlightWordsToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._updateWordToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._deleteWordToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._controlsPanel = new System.Windows.Forms.Panel();
         this._deleteButton = new System.Windows.Forms.Button();
         this._demoDescriptionLabel = new System.Windows.Forms.Label();
         this._updateButton = new System.Windows.Forms.Button();
         this._wordTextBox = new System.Windows.Forms.TextBox();
         this._mousePositionLabel = new System.Windows.Forms.Label();
         this._imageViewer = new Leadtools.Controls.ImageViewer();
         this._mainMenuStrip.SuspendLayout();
         this._viewerToolStrip.SuspendLayout();
         this._controlsPanel.SuspendLayout();
         this.SuspendLayout();
         // 
         // _mainMenuStrip
         // 
         this._mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem,
            this._viewToolStripMenuItem,
            this._wordToolStripMenuItem,
            this._preferencesToolStripMenuItem,
            this._helpToolStripMenuItem});
         this._mainMenuStrip.Location = new System.Drawing.Point(0, 0);
         this._mainMenuStrip.Name = "_mainMenuStrip";
         this._mainMenuStrip.Size = new System.Drawing.Size(894, 24);
         this._mainMenuStrip.TabIndex = 0;
         // 
         // _fileToolStripMenuItem
         // 
         this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileOpenToolStripMenuItem,
            this._fileSaveToolStripMenuItem,
            this._fileSep1ToolStripMenuItem,
            this._fileExitToolStripMenuItem});
         this._fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
         this._fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this._fileToolStripMenuItem.Text = "&File";
         this._fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this._fileToolStripMenuItem_DropDownOpening);
         // 
         // _fileOpenToolStripMenuItem
         // 
         this._fileOpenToolStripMenuItem.Image = global::OcrEditDemo.Properties.Resources.OpenDocument;
         this._fileOpenToolStripMenuItem.Name = "_fileOpenToolStripMenuItem";
         this._fileOpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
         this._fileOpenToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
         this._fileOpenToolStripMenuItem.Text = "&Open...";
         this._fileOpenToolStripMenuItem.Click += new System.EventHandler(this._fileOpenToolStripMenuItem_Click);
         // 
         // _fileSaveToolStripMenuItem
         // 
         this._fileSaveToolStripMenuItem.Image = global::OcrEditDemo.Properties.Resources.SaveDocument;
         this._fileSaveToolStripMenuItem.Name = "_fileSaveToolStripMenuItem";
         this._fileSaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
         this._fileSaveToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
         this._fileSaveToolStripMenuItem.Text = "&Save...";
         this._fileSaveToolStripMenuItem.Click += new System.EventHandler(this._fileSaveToolStripMenuItem_Click);
         // 
         // _fileSep1ToolStripMenuItem
         // 
         this._fileSep1ToolStripMenuItem.Name = "_fileSep1ToolStripMenuItem";
         this._fileSep1ToolStripMenuItem.Size = new System.Drawing.Size(152, 6);
         // 
         // _fileExitToolStripMenuItem
         // 
         this._fileExitToolStripMenuItem.Name = "_fileExitToolStripMenuItem";
         this._fileExitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
         this._fileExitToolStripMenuItem.Text = "&Exit";
         this._fileExitToolStripMenuItem.Click += new System.EventHandler(this._fileExitToolStripMenuItem_Click);
         // 
         // _viewToolStripMenuItem
         // 
         this._viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._viewZoomOutToolStripMenuItem,
            this._viewZoomInToolStripMenuItem,
            this._viewSep1ToolStripMenuItem,
            this._viewFitWidthToolStripMenuItem,
            this._viewFitPageToolStripMenuItem,
            this._viewSep2ToolStripMenuItem,
            this._viewHighlightRecognizedWordsToolStripMenuItem});
         this._viewToolStripMenuItem.Name = "_viewToolStripMenuItem";
         this._viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
         this._viewToolStripMenuItem.Text = "&View";
         this._viewToolStripMenuItem.DropDownOpening += new System.EventHandler(this._viewToolStripMenuItem_DropDownOpening);
         // 
         // _viewZoomOutToolStripMenuItem
         // 
         this._viewZoomOutToolStripMenuItem.Image = global::OcrEditDemo.Properties.Resources.ZoomOut;
         this._viewZoomOutToolStripMenuItem.Name = "_viewZoomOutToolStripMenuItem";
         this._viewZoomOutToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
         this._viewZoomOutToolStripMenuItem.Text = "Zoom &out";
         this._viewZoomOutToolStripMenuItem.Click += new System.EventHandler(this._viewZoomOutToolStripMenuItem_Click);
         // 
         // _viewZoomInToolStripMenuItem
         // 
         this._viewZoomInToolStripMenuItem.Image = global::OcrEditDemo.Properties.Resources.ZoomIn;
         this._viewZoomInToolStripMenuItem.Name = "_viewZoomInToolStripMenuItem";
         this._viewZoomInToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
         this._viewZoomInToolStripMenuItem.Text = "Zoom &in";
         this._viewZoomInToolStripMenuItem.Click += new System.EventHandler(this._viewZoomInToolStripMenuItem_Click);
         // 
         // _viewSep1ToolStripMenuItem
         // 
         this._viewSep1ToolStripMenuItem.Name = "_viewSep1ToolStripMenuItem";
         this._viewSep1ToolStripMenuItem.Size = new System.Drawing.Size(217, 6);
         // 
         // _viewFitWidthToolStripMenuItem
         // 
         this._viewFitWidthToolStripMenuItem.CheckOnClick = true;
         this._viewFitWidthToolStripMenuItem.Image = global::OcrEditDemo.Properties.Resources.FitPageWidth;
         this._viewFitWidthToolStripMenuItem.Name = "_viewFitWidthToolStripMenuItem";
         this._viewFitWidthToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
         this._viewFitWidthToolStripMenuItem.Text = "Fit &width";
         this._viewFitWidthToolStripMenuItem.Click += new System.EventHandler(this._viewFitWidthToolStripMenuItem_Click);
         // 
         // _viewFitPageToolStripMenuItem
         // 
         this._viewFitPageToolStripMenuItem.CheckOnClick = true;
         this._viewFitPageToolStripMenuItem.Image = global::OcrEditDemo.Properties.Resources.FitPage;
         this._viewFitPageToolStripMenuItem.Name = "_viewFitPageToolStripMenuItem";
         this._viewFitPageToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
         this._viewFitPageToolStripMenuItem.Text = "&Fit page";
         this._viewFitPageToolStripMenuItem.Click += new System.EventHandler(this._viewFitPageToolStripMenuItem_Click);
         // 
         // _viewSep2ToolStripMenuItem
         // 
         this._viewSep2ToolStripMenuItem.Name = "_viewSep2ToolStripMenuItem";
         this._viewSep2ToolStripMenuItem.Size = new System.Drawing.Size(217, 6);
         // 
         // _viewHighlightRecognizedWordsToolStripMenuItem
         // 
         this._viewHighlightRecognizedWordsToolStripMenuItem.Checked = true;
         this._viewHighlightRecognizedWordsToolStripMenuItem.CheckOnClick = true;
         this._viewHighlightRecognizedWordsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
         this._viewHighlightRecognizedWordsToolStripMenuItem.Image = global::OcrEditDemo.Properties.Resources.ShowZones;
         this._viewHighlightRecognizedWordsToolStripMenuItem.Name = "_viewHighlightRecognizedWordsToolStripMenuItem";
         this._viewHighlightRecognizedWordsToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
         this._viewHighlightRecognizedWordsToolStripMenuItem.Text = "&Highlight recognized words";
         this._viewHighlightRecognizedWordsToolStripMenuItem.Click += new System.EventHandler(this._viewHighlightRecognizedWordsToolStripMenuItem_Click);
         // 
         // _wordToolStripMenuItem
         // 
         this._wordToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._wordUpdateToolStripMenuItem,
            this._wordDeleteToolStripMenuItem});
         this._wordToolStripMenuItem.Name = "_wordToolStripMenuItem";
         this._wordToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
         this._wordToolStripMenuItem.Text = "&Words";
         this._wordToolStripMenuItem.DropDownOpening += new System.EventHandler(this._wordToolStripMenuItem_DropDownOpening);
         // 
         // _wordUpdateToolStripMenuItem
         // 
         this._wordUpdateToolStripMenuItem.Image = global::OcrEditDemo.Properties.Resources.AutoZonePage;
         this._wordUpdateToolStripMenuItem.Name = "_wordUpdateToolStripMenuItem";
         this._wordUpdateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this._wordUpdateToolStripMenuItem.Text = "&Update";
         this._wordUpdateToolStripMenuItem.Click += new System.EventHandler(this._wordUpdateToolStripMenuItem_Click);
         // 
         // _wordDeleteToolStripMenuItem
         // 
         this._wordDeleteToolStripMenuItem.Image = global::OcrEditDemo.Properties.Resources.DeleteZone;
         this._wordDeleteToolStripMenuItem.Name = "_wordDeleteToolStripMenuItem";
         this._wordDeleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this._wordDeleteToolStripMenuItem.Text = "&Delete";
         this._wordDeleteToolStripMenuItem.Click += new System.EventHandler(this._wordDeleteToolStripMenuItem_Click);
         // 
         // _preferencesToolStripMenuItem
         // 
         this._preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._preferencesPdfResolutionToolStripMenuItem,
            this._preferencesUseCallbacksToolStripMenuItem,
            this._preferencesViewSavedDocumentToolStripMenuItem});
         this._preferencesToolStripMenuItem.Name = "_preferencesToolStripMenuItem";
         this._preferencesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
         this._preferencesToolStripMenuItem.Text = "&Preferences";
         // 
         // _preferencesPdfResolutionToolStripMenuItem
         // 
         this._preferencesPdfResolutionToolStripMenuItem.Name = "_preferencesPdfResolutionToolStripMenuItem";
         this._preferencesPdfResolutionToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
         this._preferencesPdfResolutionToolStripMenuItem.Text = "&Set PDF files load resolution...";
         this._preferencesPdfResolutionToolStripMenuItem.Click += new System.EventHandler(this._preferencesPdfResolutionToolStripMenuItem_Click);
         // 
         // _preferencesUseCallbacksToolStripMenuItem
         // 
         this._preferencesUseCallbacksToolStripMenuItem.Checked = true;
         this._preferencesUseCallbacksToolStripMenuItem.CheckOnClick = true;
         this._preferencesUseCallbacksToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
         this._preferencesUseCallbacksToolStripMenuItem.Name = "_preferencesUseCallbacksToolStripMenuItem";
         this._preferencesUseCallbacksToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
         this._preferencesUseCallbacksToolStripMenuItem.Text = "&Use callbacks";
         // 
         // _preferencesViewSavedDocumentToolStripMenuItem
         // 
         this._preferencesViewSavedDocumentToolStripMenuItem.Checked = true;
         this._preferencesViewSavedDocumentToolStripMenuItem.CheckOnClick = true;
         this._preferencesViewSavedDocumentToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
         this._preferencesViewSavedDocumentToolStripMenuItem.Name = "_preferencesViewSavedDocumentToolStripMenuItem";
         this._preferencesViewSavedDocumentToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
         this._preferencesViewSavedDocumentToolStripMenuItem.Text = "&View saved document";
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
         // _viewerToolStrip
         // 
         this._viewerToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openToolStripButton,
            this._saveToolStripButton,
            this._viewerToolStripSeparator1,
            this._zoomOutToolStripButton,
            this._zoomInToolStripButton,
            this._zoomToolStripComboBox,
            this._fitPageWidthToolStripButton,
            this._fitPageToolStripButton,
            this._viewerToolStripSeparator2,
            this._highlightWordsToolStripButton,
            this._updateWordToolStripButton,
            this._deleteWordToolStripButton});
         this._viewerToolStrip.Location = new System.Drawing.Point(0, 24);
         this._viewerToolStrip.Name = "_viewerToolStrip";
         this._viewerToolStrip.Size = new System.Drawing.Size(894, 25);
         this._viewerToolStrip.TabIndex = 1;
         this._viewerToolStrip.Text = "toolStrip1";
         // 
         // _openToolStripButton
         // 
         this._openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._openToolStripButton.Image = global::OcrEditDemo.Properties.Resources.OpenDocument;
         this._openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._openToolStripButton.Name = "_openToolStripButton";
         this._openToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._openToolStripButton.ToolTipText = "Open a new document";
         this._openToolStripButton.Click += new System.EventHandler(this._openToolStripButton_Click);
         // 
         // _saveToolStripButton
         // 
         this._saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._saveToolStripButton.Image = global::OcrEditDemo.Properties.Resources.SaveDocument;
         this._saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._saveToolStripButton.Name = "_saveToolStripButton";
         this._saveToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._saveToolStripButton.ToolTipText = "Save this document as PDF";
         this._saveToolStripButton.Click += new System.EventHandler(this._saveToolStripButton_Click);
         // 
         // _viewerToolStripSeparator1
         // 
         this._viewerToolStripSeparator1.Name = "_viewerToolStripSeparator1";
         this._viewerToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // _zoomOutToolStripButton
         // 
         this._zoomOutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._zoomOutToolStripButton.Image = global::OcrEditDemo.Properties.Resources.ZoomOut;
         this._zoomOutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._zoomOutToolStripButton.Name = "_zoomOutToolStripButton";
         this._zoomOutToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._zoomOutToolStripButton.ToolTipText = "Zoom out";
         this._zoomOutToolStripButton.Click += new System.EventHandler(this._zoomOutToolStripButton_Click);
         // 
         // _zoomInToolStripButton
         // 
         this._zoomInToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._zoomInToolStripButton.Image = global::OcrEditDemo.Properties.Resources.ZoomIn;
         this._zoomInToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._zoomInToolStripButton.Name = "_zoomInToolStripButton";
         this._zoomInToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._zoomInToolStripButton.ToolTipText = "Zoom in";
         this._zoomInToolStripButton.Click += new System.EventHandler(this._zoomInToolStripButton_Click);
         // 
         // _zoomToolStripComboBox
         // 
         this._zoomToolStripComboBox.DropDownWidth = 80;
         this._zoomToolStripComboBox.Items.AddRange(new object[] {
            "10%",
            "25%",
            "50%",
            "75%",
            "100%",
            "125%",
            "200%",
            "400%",
            "800%",
            "1600%",
            "2400%",
            "3200%",
            "6400%",
            "Actual Size",
            "Fit Page",
            "Fit Width"});
         this._zoomToolStripComboBox.Name = "_zoomToolStripComboBox";
         this._zoomToolStripComboBox.Size = new System.Drawing.Size(80, 25);
         this._zoomToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this._zoomToolStripComboBox_SelectedIndexChanged);
         this._zoomToolStripComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._zoomToolStripComboBox_KeyPress);
         // 
         // _fitPageWidthToolStripButton
         // 
         this._fitPageWidthToolStripButton.CheckOnClick = true;
         this._fitPageWidthToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._fitPageWidthToolStripButton.Image = global::OcrEditDemo.Properties.Resources.FitPageWidth;
         this._fitPageWidthToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._fitPageWidthToolStripButton.Name = "_fitPageWidthToolStripButton";
         this._fitPageWidthToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._fitPageWidthToolStripButton.ToolTipText = "Fit page width in window";
         this._fitPageWidthToolStripButton.Click += new System.EventHandler(this._fitPageWidthToolStripButton_Click);
         // 
         // _fitPageToolStripButton
         // 
         this._fitPageToolStripButton.CheckOnClick = true;
         this._fitPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._fitPageToolStripButton.Image = global::OcrEditDemo.Properties.Resources.FitPage;
         this._fitPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._fitPageToolStripButton.Name = "_fitPageToolStripButton";
         this._fitPageToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._fitPageToolStripButton.ToolTipText = "Fit entire page in window";
         this._fitPageToolStripButton.Click += new System.EventHandler(this._fitPageToolStripButton_Click);
         // 
         // _viewerToolStripSeparator2
         // 
         this._viewerToolStripSeparator2.Name = "_viewerToolStripSeparator2";
         this._viewerToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
         // 
         // _highlightWordsToolStripButton
         // 
         this._highlightWordsToolStripButton.Checked = true;
         this._highlightWordsToolStripButton.CheckOnClick = true;
         this._highlightWordsToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
         this._highlightWordsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._highlightWordsToolStripButton.Image = global::OcrEditDemo.Properties.Resources.ShowZones;
         this._highlightWordsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._highlightWordsToolStripButton.Name = "_highlightWordsToolStripButton";
         this._highlightWordsToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._highlightWordsToolStripButton.ToolTipText = "Highlight the recognized words";
         this._highlightWordsToolStripButton.Click += new System.EventHandler(this._highlightWordsToolStripButton_Click);
         // 
         // _updateWordToolStripButton
         // 
         this._updateWordToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._updateWordToolStripButton.Image = global::OcrEditDemo.Properties.Resources.AutoZonePage;
         this._updateWordToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._updateWordToolStripButton.Name = "_updateWordToolStripButton";
         this._updateWordToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._updateWordToolStripButton.ToolTipText = "Update the selected word";
         this._updateWordToolStripButton.Click += new System.EventHandler(this._updateWordToolStripButton_Click);
         // 
         // _deleteWordToolStripButton
         // 
         this._deleteWordToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._deleteWordToolStripButton.Image = global::OcrEditDemo.Properties.Resources.DeleteZone;
         this._deleteWordToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._deleteWordToolStripButton.Name = "_deleteWordToolStripButton";
         this._deleteWordToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._deleteWordToolStripButton.ToolTipText = "Delete selected word";
         this._deleteWordToolStripButton.Click += new System.EventHandler(this._deleteWordToolStripButton_Click);
         // 
         // _controlsPanel
         // 
         this._controlsPanel.Controls.Add(this._deleteButton);
         this._controlsPanel.Controls.Add(this._demoDescriptionLabel);
         this._controlsPanel.Controls.Add(this._updateButton);
         this._controlsPanel.Controls.Add(this._wordTextBox);
         this._controlsPanel.Dock = System.Windows.Forms.DockStyle.Top;
         this._controlsPanel.Location = new System.Drawing.Point(0, 49);
         this._controlsPanel.Name = "_controlsPanel";
         this._controlsPanel.Size = new System.Drawing.Size(894, 146);
         this._controlsPanel.TabIndex = 2;
         // 
         // _deleteButton
         // 
         this._deleteButton.Location = new System.Drawing.Point(267, 116);
         this._deleteButton.Name = "_deleteButton";
         this._deleteButton.Size = new System.Drawing.Size(75, 23);
         this._deleteButton.TabIndex = 3;
         this._deleteButton.Text = "&Delete";
         this._deleteButton.UseVisualStyleBackColor = true;
         this._deleteButton.Click += new System.EventHandler(this._deleteButton_Click);
         // 
         // _demoDescriptionLabel
         // 
         this._demoDescriptionLabel.AutoSize = true;
         this._demoDescriptionLabel.Location = new System.Drawing.Point(4, 11);
         this._demoDescriptionLabel.Name = "_demoDescriptionLabel";
         this._demoDescriptionLabel.Size = new System.Drawing.Size(609, 78);
         this._demoDescriptionLabel.TabIndex = 0;
         this._demoDescriptionLabel.Text = resources.GetString("_demoDescriptionLabel.Text");
         // 
         // _updateButton
         // 
         this._updateButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._updateButton.Location = new System.Drawing.Point(186, 116);
         this._updateButton.Name = "_updateButton";
         this._updateButton.Size = new System.Drawing.Size(75, 23);
         this._updateButton.TabIndex = 1;
         this._updateButton.Text = "&Update";
         this._updateButton.UseVisualStyleBackColor = true;
         this._updateButton.Click += new System.EventHandler(this._updateButton_Click);
         // 
         // _wordTextBox
         // 
         this._wordTextBox.Location = new System.Drawing.Point(12, 118);
         this._wordTextBox.Name = "_wordTextBox";
         this._wordTextBox.Size = new System.Drawing.Size(168, 20);
         this._wordTextBox.TabIndex = 2;
         this._wordTextBox.TextChanged += new System.EventHandler(this._wordTextBox_TextChanged);
         // 
         // _mousePositionLabel
         // 
         this._mousePositionLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
         this._mousePositionLabel.Location = new System.Drawing.Point(0, 528);
         this._mousePositionLabel.Name = "_mousePositionLabel";
         this._mousePositionLabel.Size = new System.Drawing.Size(894, 13);
         this._mousePositionLabel.TabIndex = 4;
         // 
         // _rasterImageViewer
         // 
         this._imageViewer.BackColor = System.Drawing.SystemColors.AppWorkspace;
         this._imageViewer.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this._imageViewer.Cursor = System.Windows.Forms.Cursors.Cross;
         this._imageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
         this._imageViewer.ViewHorizontalAlignment = Leadtools.Controls.ControlAlignment.Center;
         this._imageViewer.Location = new System.Drawing.Point(0, 195);
         this._imageViewer.Name = "_rasterImageViewer";
         this._imageViewer.Size = new System.Drawing.Size(894, 333);
         this._imageViewer.TabIndex = 3;
         this._imageViewer.UseDpi = true;
         this._imageViewer.ViewVerticalAlignment = Leadtools.Controls.ControlAlignment.Center;
         this._imageViewer.TransformChanged += new System.EventHandler(this._imageViewer_TransformChanged);
         this._imageViewer.MouseMove += new System.Windows.Forms.MouseEventHandler(this._imageViewer_MouseMove);
         this._imageViewer.MouseClick += new System.Windows.Forms.MouseEventHandler(this._imageViewer_MouseClick);
         this._imageViewer.PostRender += new System.EventHandler<Leadtools.Controls.ImageViewerRenderEventArgs>(this._imageViewer_PostRender);
         // 
         // MainForm
         // 
         this.AcceptButton = this._updateButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(894, 541);
         this.Controls.Add(this._imageViewer);
         this.Controls.Add(this._mousePositionLabel);
         this.Controls.Add(this._controlsPanel);
         this.Controls.Add(this._viewerToolStrip);
         this.Controls.Add(this._mainMenuStrip);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this._mainMenuStrip;
         this.Name = "MainForm";
         this.Text = "MainForm";
         this._mainMenuStrip.ResumeLayout(false);
         this._mainMenuStrip.PerformLayout();
         this._viewerToolStrip.ResumeLayout(false);
         this._viewerToolStrip.PerformLayout();
         this._controlsPanel.ResumeLayout(false);
         this._controlsPanel.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }      

      #endregion

      private System.Windows.Forms.MenuStrip _mainMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fileOpenToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fileSaveToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _fileSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fileExitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _preferencesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _preferencesPdfResolutionToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _helpToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _helpAboutToolStripMenuItem;
      private System.Windows.Forms.ToolStrip _viewerToolStrip;
      private System.Windows.Forms.ToolStripButton _zoomOutToolStripButton;
      private System.Windows.Forms.ToolStripButton _zoomInToolStripButton;
      private System.Windows.Forms.ToolStripComboBox _zoomToolStripComboBox;
      private System.Windows.Forms.ToolStripButton _fitPageWidthToolStripButton;
      private System.Windows.Forms.ToolStripButton _fitPageToolStripButton;
      private System.Windows.Forms.ToolStripMenuItem _viewToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewZoomOutToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewZoomInToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _viewSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewFitWidthToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewFitPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripButton _openToolStripButton;
      private System.Windows.Forms.ToolStripButton _saveToolStripButton;
      private System.Windows.Forms.ToolStripSeparator _viewerToolStripSeparator1;
      private System.Windows.Forms.Panel _controlsPanel;
      private System.Windows.Forms.Label _mousePositionLabel;
      private Leadtools.Controls.ImageViewer _imageViewer;
      private System.Windows.Forms.ToolStripMenuItem _preferencesUseCallbacksToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _preferencesViewSavedDocumentToolStripMenuItem;
      private System.Windows.Forms.Button _updateButton;
      private System.Windows.Forms.TextBox _wordTextBox;
      private System.Windows.Forms.Label _demoDescriptionLabel;
      private System.Windows.Forms.ToolStripSeparator _viewerToolStripSeparator2;
      private System.Windows.Forms.ToolStripButton _highlightWordsToolStripButton;
      private System.Windows.Forms.ToolStripButton _deleteWordToolStripButton;
      private System.Windows.Forms.ToolStripSeparator _viewSep2ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewHighlightRecognizedWordsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _wordToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _wordDeleteToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _wordUpdateToolStripMenuItem;
      private System.Windows.Forms.ToolStripButton _updateWordToolStripButton;
      private System.Windows.Forms.Button _deleteButton;

   }
}

