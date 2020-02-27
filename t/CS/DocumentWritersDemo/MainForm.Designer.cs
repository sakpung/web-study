namespace DocumentWritersDemo
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
         this._fileNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._fileOpenRtfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._fileOpenEmfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._fileSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._fileSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._fileExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._editUndoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._editRedoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._editSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._editCutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._editCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._editPasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._editDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._editSep2ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._editSelectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._editSelectNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewZoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewZoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._viewFitWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewFitPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._annotationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._annotationsCurrentObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._annotationsSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._annotationsAlignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._alignBringToFrontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._alignSendToBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._alignBringToFirstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._alignSendToLastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._annotationsSep2ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._annotationsPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._helpAboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._mainToolStrip = new System.Windows.Forms.ToolStrip();
         this._newToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._saveToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this._copyToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this._undoToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._redoToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._mainSplitter = new System.Windows.Forms.Splitter();
         this._viewerControl = new DocumentWritersDemo.ViewerControl();
         this._pagesControl = new DocumentWritersDemo.PagesControl();
         this._mainMenuStrip.SuspendLayout();
         this._mainToolStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // _mainMenuStrip
         // 
         this._mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem,
            this._editToolStripMenuItem,
            this._viewToolStripMenuItem,
            this._annotationsToolStripMenuItem,
            this._helpToolStripMenuItem});
         this._mainMenuStrip.Location = new System.Drawing.Point(0, 0);
         this._mainMenuStrip.Name = "_mainMenuStrip";
         this._mainMenuStrip.Size = new System.Drawing.Size(904, 24);
         this._mainMenuStrip.TabIndex = 0;
         this._mainMenuStrip.Text = "_mainMenuStrip";
         // 
         // _fileToolStripMenuItem
         // 
         this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileNewToolStripMenuItem,
            this._fileOpenRtfToolStripMenuItem,
            this._fileOpenEmfToolStripMenuItem,
            this._fileSaveToolStripMenuItem,
            this._fileSep1ToolStripMenuItem,
            this._fileExitToolStripMenuItem});
         this._fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
         this._fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this._fileToolStripMenuItem.Text = "&File";
         // 
         // _fileNewToolStripMenuItem
         // 
         this._fileNewToolStripMenuItem.Image = global::DocumentWritersDemo.Properties.Resources.NewDocument;
         this._fileNewToolStripMenuItem.Name = "_fileNewToolStripMenuItem";
         this._fileNewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
         this._fileNewToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
         this._fileNewToolStripMenuItem.Text = "&New...";
         this._fileNewToolStripMenuItem.Click += new System.EventHandler(this._fileNewToolStripMenuItem_Click);
         // 
         // _fileOpenRtfToolStripMenuItem
         // 
         this._fileOpenRtfToolStripMenuItem.Image = global::DocumentWritersDemo.Properties.Resources.OpenDocument;
         this._fileOpenRtfToolStripMenuItem.Name = "_fileOpenRtfToolStripMenuItem";
         this._fileOpenRtfToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
         this._fileOpenRtfToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
         this._fileOpenRtfToolStripMenuItem.Text = "&Open Rtf Document";
         this._fileOpenRtfToolStripMenuItem.Click += new System.EventHandler(this._fileOpenRtfToolStripMenuItem_Click);
         // 
         // _fileOpenEmfToolStripMenuItem
         // 
         this._fileOpenEmfToolStripMenuItem.Image = global::DocumentWritersDemo.Properties.Resources.OpenDocument;
         this._fileOpenEmfToolStripMenuItem.Name = "_fileOpenEmfToolStripMenuItem";
         this._fileOpenEmfToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
         this._fileOpenEmfToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
         this._fileOpenEmfToolStripMenuItem.Text = "&Open Emf File(s)";
         this._fileOpenEmfToolStripMenuItem.Click += new System.EventHandler(this._fileOpenEmfToolStripMenuItem_Click);
         // 
         // _fileSaveToolStripMenuItem
         // 
         this._fileSaveToolStripMenuItem.Image = global::DocumentWritersDemo.Properties.Resources.SaveDocument;
         this._fileSaveToolStripMenuItem.Name = "_fileSaveToolStripMenuItem";
         this._fileSaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
         this._fileSaveToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
         this._fileSaveToolStripMenuItem.Text = "&Save...";
         this._fileSaveToolStripMenuItem.Click += new System.EventHandler(this._fileSaveToolStripMenuItem_Click);
         // 
         // _fileSep1ToolStripMenuItem
         // 
         this._fileSep1ToolStripMenuItem.Name = "_fileSep1ToolStripMenuItem";
         this._fileSep1ToolStripMenuItem.Size = new System.Drawing.Size(218, 6);
         // 
         // _fileExitToolStripMenuItem
         // 
         this._fileExitToolStripMenuItem.Name = "_fileExitToolStripMenuItem";
         this._fileExitToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
         this._fileExitToolStripMenuItem.Text = "E&xit";
         this._fileExitToolStripMenuItem.Click += new System.EventHandler(this._fileExitToolStripMenuItem_Click);
         // 
         // _editToolStripMenuItem
         // 
         this._editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._editUndoToolStripMenuItem,
            this._editRedoToolStripMenuItem,
            this._editSep1ToolStripMenuItem,
            this._editCutToolStripMenuItem,
            this._editCopyToolStripMenuItem,
            this._editPasteToolStripMenuItem,
            this._editDeleteToolStripMenuItem,
            this._editSep2ToolStripMenuItem,
            this._editSelectAllToolStripMenuItem,
            this._editSelectNoneToolStripMenuItem});
         this._editToolStripMenuItem.Name = "_editToolStripMenuItem";
         this._editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
         this._editToolStripMenuItem.Text = "&Edit";
         this._editToolStripMenuItem.DropDownOpening += new System.EventHandler(this._editToolStripMenuItem_DropDownOpening);
         // 
         // _editUndoToolStripMenuItem
         // 
         this._editUndoToolStripMenuItem.Image = global::DocumentWritersDemo.Properties.Resources.Undo;
         this._editUndoToolStripMenuItem.Name = "_editUndoToolStripMenuItem";
         this._editUndoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
         this._editUndoToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
         this._editUndoToolStripMenuItem.Text = "&Undo";
         this._editUndoToolStripMenuItem.Click += new System.EventHandler(this._editUndoToolStripMenuItem_Click);
         // 
         // _editRedoToolStripMenuItem
         // 
         this._editRedoToolStripMenuItem.Image = global::DocumentWritersDemo.Properties.Resources.Redo;
         this._editRedoToolStripMenuItem.Name = "_editRedoToolStripMenuItem";
         this._editRedoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
         this._editRedoToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
         this._editRedoToolStripMenuItem.Text = "&Redo";
         this._editRedoToolStripMenuItem.Click += new System.EventHandler(this._editRedoToolStripMenuItem_Click);
         // 
         // _editSep1ToolStripMenuItem
         // 
         this._editSep1ToolStripMenuItem.Name = "_editSep1ToolStripMenuItem";
         this._editSep1ToolStripMenuItem.Size = new System.Drawing.Size(159, 6);
         // 
         // _editCutToolStripMenuItem
         // 
         this._editCutToolStripMenuItem.Name = "_editCutToolStripMenuItem";
         this._editCutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
         this._editCutToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
         this._editCutToolStripMenuItem.Text = "Cu&t";
         this._editCutToolStripMenuItem.Click += new System.EventHandler(this._editCutToolStripMenuItem_Click);
         // 
         // _editCopyToolStripMenuItem
         // 
         this._editCopyToolStripMenuItem.Image = global::DocumentWritersDemo.Properties.Resources.Copy;
         this._editCopyToolStripMenuItem.Name = "_editCopyToolStripMenuItem";
         this._editCopyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
         this._editCopyToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
         this._editCopyToolStripMenuItem.Text = "&Copy";
         this._editCopyToolStripMenuItem.Click += new System.EventHandler(this._editCopyToolStripMenuItem_Click);
         // 
         // _editPasteToolStripMenuItem
         // 
         this._editPasteToolStripMenuItem.Image = global::DocumentWritersDemo.Properties.Resources.Paste;
         this._editPasteToolStripMenuItem.Name = "_editPasteToolStripMenuItem";
         this._editPasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
         this._editPasteToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
         this._editPasteToolStripMenuItem.Text = "&Paste";
         this._editPasteToolStripMenuItem.Click += new System.EventHandler(this._editPasteToolStripMenuItem_Click);
         // 
         // _editDeleteToolStripMenuItem
         // 
         this._editDeleteToolStripMenuItem.Image = global::DocumentWritersDemo.Properties.Resources.Delete;
         this._editDeleteToolStripMenuItem.Name = "_editDeleteToolStripMenuItem";
         this._editDeleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
         this._editDeleteToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
         this._editDeleteToolStripMenuItem.Text = "&Delete";
         this._editDeleteToolStripMenuItem.Click += new System.EventHandler(this._editDeleteToolStripMenuItem_Click);
         // 
         // _editSep2ToolStripMenuItem
         // 
         this._editSep2ToolStripMenuItem.Name = "_editSep2ToolStripMenuItem";
         this._editSep2ToolStripMenuItem.Size = new System.Drawing.Size(159, 6);
         // 
         // _editSelectAllToolStripMenuItem
         // 
         this._editSelectAllToolStripMenuItem.Name = "_editSelectAllToolStripMenuItem";
         this._editSelectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
         this._editSelectAllToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
         this._editSelectAllToolStripMenuItem.Text = "Select &all";
         this._editSelectAllToolStripMenuItem.Click += new System.EventHandler(this._editSelectAllToolStripMenuItem_Click);
         // 
         // _editSelectNoneToolStripMenuItem
         // 
         this._editSelectNoneToolStripMenuItem.Name = "_editSelectNoneToolStripMenuItem";
         this._editSelectNoneToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
         this._editSelectNoneToolStripMenuItem.Text = "Select &none";
         this._editSelectNoneToolStripMenuItem.Click += new System.EventHandler(this._editSelectNoneToolStripMenuItem_Click);
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
         // 
         // _viewZoomOutToolStripMenuItem
         // 
         this._viewZoomOutToolStripMenuItem.Image = global::DocumentWritersDemo.Properties.Resources.ZoomOut;
         this._viewZoomOutToolStripMenuItem.Name = "_viewZoomOutToolStripMenuItem";
         this._viewZoomOutToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
         this._viewZoomOutToolStripMenuItem.Text = "Zoom &out";
         this._viewZoomOutToolStripMenuItem.Click += new System.EventHandler(this._viewZoomOutToolStripMenuItem_Click);
         // 
         // _viewZoomInToolStripMenuItem
         // 
         this._viewZoomInToolStripMenuItem.Image = global::DocumentWritersDemo.Properties.Resources.ZoomIn;
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
         this._viewFitWidthToolStripMenuItem.Image = global::DocumentWritersDemo.Properties.Resources.FitPageWidth;
         this._viewFitWidthToolStripMenuItem.Name = "_viewFitWidthToolStripMenuItem";
         this._viewFitWidthToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
         this._viewFitWidthToolStripMenuItem.Text = "Fit &width";
         this._viewFitWidthToolStripMenuItem.Click += new System.EventHandler(this._viewFitWidthToolStripMenuItem_Click);
         // 
         // _viewFitPageToolStripMenuItem
         // 
         this._viewFitPageToolStripMenuItem.Image = global::DocumentWritersDemo.Properties.Resources.FitPage;
         this._viewFitPageToolStripMenuItem.Name = "_viewFitPageToolStripMenuItem";
         this._viewFitPageToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
         this._viewFitPageToolStripMenuItem.Text = "&Fit page";
         this._viewFitPageToolStripMenuItem.Click += new System.EventHandler(this._viewFitPageToolStripMenuItem_Click);
         // 
         // _annotationsToolStripMenuItem
         // 
         this._annotationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._annotationsCurrentObjectToolStripMenuItem,
            this._annotationsSep1ToolStripMenuItem,
            this._annotationsAlignToolStripMenuItem,
            this._annotationsSep2ToolStripMenuItem,
            this._annotationsPropertiesToolStripMenuItem});
         this._annotationsToolStripMenuItem.Name = "_annotationsToolStripMenuItem";
         this._annotationsToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
         this._annotationsToolStripMenuItem.Text = "&Annotations";
         this._annotationsToolStripMenuItem.DropDownOpening += new System.EventHandler(this._annotationsToolStripMenuItem_DropDownOpening);
         // 
         // _annotationsCurrentObjectToolStripMenuItem
         // 
         this._annotationsCurrentObjectToolStripMenuItem.Name = "_annotationsCurrentObjectToolStripMenuItem";
         this._annotationsCurrentObjectToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
         this._annotationsCurrentObjectToolStripMenuItem.Text = "&Current object";
         this._annotationsCurrentObjectToolStripMenuItem.DropDownOpening += new System.EventHandler(this._annotationsCurrentObjectToolStripMenuItem_DropDownOpening);
         // 
         // _annotationsSep1ToolStripMenuItem
         // 
         this._annotationsSep1ToolStripMenuItem.Name = "_annotationsSep1ToolStripMenuItem";
         this._annotationsSep1ToolStripMenuItem.Size = new System.Drawing.Size(147, 6);
         // 
         // _annotationsAlignToolStripMenuItem
         // 
         this._annotationsAlignToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._alignBringToFrontToolStripMenuItem,
            this._alignSendToBackToolStripMenuItem,
            this._alignBringToFirstToolStripMenuItem,
            this._alignSendToLastToolStripMenuItem});
         this._annotationsAlignToolStripMenuItem.Name = "_annotationsAlignToolStripMenuItem";
         this._annotationsAlignToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
         this._annotationsAlignToolStripMenuItem.Text = "&Align";
         this._annotationsAlignToolStripMenuItem.DropDownOpening += new System.EventHandler(this._annotationsAlignToolStripMenuItem_DropDownOpening);
         // 
         // _alignBringToFrontToolStripMenuItem
         // 
         this._alignBringToFrontToolStripMenuItem.Image = global::DocumentWritersDemo.Properties.Resources.BringToFront;
         this._alignBringToFrontToolStripMenuItem.Name = "_alignBringToFrontToolStripMenuItem";
         this._alignBringToFrontToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
         this._alignBringToFrontToolStripMenuItem.Text = "&Bring to front";
         this._alignBringToFrontToolStripMenuItem.Click += new System.EventHandler(this._alignBringToFrontToolStripMenuItem_Click);
         // 
         // _alignSendToBackToolStripMenuItem
         // 
         this._alignSendToBackToolStripMenuItem.Image = global::DocumentWritersDemo.Properties.Resources.SendToBack;
         this._alignSendToBackToolStripMenuItem.Name = "_alignSendToBackToolStripMenuItem";
         this._alignSendToBackToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
         this._alignSendToBackToolStripMenuItem.Text = "&Send to back";
         this._alignSendToBackToolStripMenuItem.Click += new System.EventHandler(this._alignSendToBackToolStripMenuItem_Click);
         // 
         // _alignBringToFirstToolStripMenuItem
         // 
         this._alignBringToFirstToolStripMenuItem.Image = global::DocumentWritersDemo.Properties.Resources.BringToFirst;
         this._alignBringToFirstToolStripMenuItem.Name = "_alignBringToFirstToolStripMenuItem";
         this._alignBringToFirstToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
         this._alignBringToFirstToolStripMenuItem.Text = "Bring to &first";
         this._alignBringToFirstToolStripMenuItem.Click += new System.EventHandler(this._alignBringToFirstToolStripMenuItem_Click);
         // 
         // _alignSendToLastToolStripMenuItem
         // 
         this._alignSendToLastToolStripMenuItem.Image = global::DocumentWritersDemo.Properties.Resources.SendToLast;
         this._alignSendToLastToolStripMenuItem.Name = "_alignSendToLastToolStripMenuItem";
         this._alignSendToLastToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
         this._alignSendToLastToolStripMenuItem.Text = "Send to &last";
         this._alignSendToLastToolStripMenuItem.Click += new System.EventHandler(this._alignSendToLastToolStripMenuItem_Click);
         // 
         // _annotationsSep2ToolStripMenuItem
         // 
         this._annotationsSep2ToolStripMenuItem.Name = "_annotationsSep2ToolStripMenuItem";
         this._annotationsSep2ToolStripMenuItem.Size = new System.Drawing.Size(147, 6);
         // 
         // _annotationsPropertiesToolStripMenuItem
         // 
         this._annotationsPropertiesToolStripMenuItem.Image = global::DocumentWritersDemo.Properties.Resources.ObjectProperties;
         this._annotationsPropertiesToolStripMenuItem.Name = "_annotationsPropertiesToolStripMenuItem";
         this._annotationsPropertiesToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
         this._annotationsPropertiesToolStripMenuItem.Text = "&Properties...";
         this._annotationsPropertiesToolStripMenuItem.Click += new System.EventHandler(this._annotationsPropertiesToolStripMenuItem_Click);
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
            this._newToolStripButton,
            this._saveToolStripButton,
            this._toolStripSeparator1,
            this._copyToolStripButton,
            this._pasteToolStripButton,
            this._deleteToolStripButton,
            this._toolStripSeparator2,
            this._undoToolStripButton,
            this._redoToolStripButton});
         this._mainToolStrip.Location = new System.Drawing.Point(0, 24);
         this._mainToolStrip.Name = "_mainToolStrip";
         this._mainToolStrip.Size = new System.Drawing.Size(904, 25);
         this._mainToolStrip.TabIndex = 1;
         this._mainToolStrip.Text = "toolStrip1";
         // 
         // _newToolStripButton
         // 
         this._newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._newToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.NewDocument;
         this._newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._newToolStripButton.Name = "_newToolStripButton";
         this._newToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._newToolStripButton.ToolTipText = "Create a new empty document";
         this._newToolStripButton.Click += new System.EventHandler(this._newToolStripButton_Click);
         // 
         // _saveToolStripButton
         // 
         this._saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._saveToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.SaveDocument;
         this._saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._saveToolStripButton.Name = "_saveToolStripButton";
         this._saveToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._saveToolStripButton.ToolTipText = "Save the current document using the LEADTOOLS document writers";
         this._saveToolStripButton.Click += new System.EventHandler(this._saveToolStripButton_Click);
         // 
         // _toolStripSeparator1
         // 
         this._toolStripSeparator1.Name = "_toolStripSeparator1";
         this._toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // _copyToolStripButton
         // 
         this._copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._copyToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.Copy;
         this._copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._copyToolStripButton.Name = "_copyToolStripButton";
         this._copyToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._copyToolStripButton.ToolTipText = "Copy the select objects from the current page to the clipboard";
         this._copyToolStripButton.Click += new System.EventHandler(this._copyToolStripButton_Click);
         // 
         // _pasteToolStripButton
         // 
         this._pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._pasteToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.Paste;
         this._pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._pasteToolStripButton.Name = "_pasteToolStripButton";
         this._pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._pasteToolStripButton.ToolTipText = "Paste objects from the clipboard to the current page";
         this._pasteToolStripButton.Click += new System.EventHandler(this._pasteToolStripButton_Click);
         // 
         // _deleteToolStripButton
         // 
         this._deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._deleteToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.Delete;
         this._deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._deleteToolStripButton.Name = "_deleteToolStripButton";
         this._deleteToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._deleteToolStripButton.ToolTipText = "Delete the selected objects from the current page";
         this._deleteToolStripButton.Click += new System.EventHandler(this._deleteToolStripButton_Click);
         // 
         // _toolStripSeparator2
         // 
         this._toolStripSeparator2.Name = "_toolStripSeparator2";
         this._toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
         // 
         // _undoToolStripButton
         // 
         this._undoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._undoToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.Undo;
         this._undoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._undoToolStripButton.Name = "_undoToolStripButton";
         this._undoToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._undoToolStripButton.ToolTipText = "Undo the last operation";
         this._undoToolStripButton.Click += new System.EventHandler(this._undoToolStripButton_Click);
         // 
         // _redoToolStripButton
         // 
         this._redoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._redoToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.Redo;
         this._redoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._redoToolStripButton.Name = "_redoToolStripButton";
         this._redoToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._redoToolStripButton.ToolTipText = "Redo the last operation";
         this._redoToolStripButton.Click += new System.EventHandler(this._redoToolStripButton_Click);
         // 
         // _mainSplitter
         // 
         this._mainSplitter.Location = new System.Drawing.Point(217, 49);
         this._mainSplitter.Name = "_mainSplitter";
         this._mainSplitter.Size = new System.Drawing.Size(3, 575);
         this._mainSplitter.TabIndex = 5;
         this._mainSplitter.TabStop = false;
         // 
         // _viewerControl
         // 
         this._viewerControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this._viewerControl.Location = new System.Drawing.Point(220, 49);
         this._viewerControl.Name = "_viewerControl";
         this._viewerControl.Size = new System.Drawing.Size(684, 575);
         this._viewerControl.TabIndex = 6;
         this._viewerControl.Action += new System.EventHandler<DocumentWritersDemo.ActionEventArgs>(this._viewerControl_Action);
         // 
         // _pagesControl
         // 
         this._pagesControl.Dock = System.Windows.Forms.DockStyle.Left;
         this._pagesControl.Location = new System.Drawing.Point(0, 49);
         this._pagesControl.Name = "_pagesControl";
         this._pagesControl.Size = new System.Drawing.Size(217, 575);
         this._pagesControl.TabIndex = 2;
         this._pagesControl.Action += new System.EventHandler<DocumentWritersDemo.ActionEventArgs>(this._pagesControl_Action);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(904, 624);
         this.Controls.Add(this._viewerControl);
         this.Controls.Add(this._mainSplitter);
         this.Controls.Add(this._pagesControl);
         this.Controls.Add(this._mainToolStrip);
         this.Controls.Add(this._mainMenuStrip);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this._mainMenuStrip;
         this.Name = "MainForm";
         this.Text = "MainForm";
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
      private System.Windows.Forms.ToolStripMenuItem _fileNewToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fileSaveToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _fileSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fileExitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _helpToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _helpAboutToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _editToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _editCopyToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _editPasteToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewZoomOutToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewZoomInToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _viewSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewFitWidthToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewFitPageToolStripMenuItem;
      private System.Windows.Forms.ToolStrip _mainToolStrip;
      private System.Windows.Forms.ToolStripButton _newToolStripButton;
      private System.Windows.Forms.ToolStripButton _saveToolStripButton;
      private PagesControl _pagesControl;
      private System.Windows.Forms.Splitter _mainSplitter;
      private ViewerControl _viewerControl;
      private System.Windows.Forms.ToolStripMenuItem _editUndoToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _editRedoToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _editSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _editCutToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _editDeleteToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _editSep2ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _editSelectAllToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _editSelectNoneToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _annotationsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _annotationsCurrentObjectToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _annotationsSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _annotationsAlignToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _alignBringToFrontToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _alignSendToBackToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _alignBringToFirstToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _alignSendToLastToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton _copyToolStripButton;
      private System.Windows.Forms.ToolStripButton _pasteToolStripButton;
      private System.Windows.Forms.ToolStripButton _deleteToolStripButton;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator2;
      private System.Windows.Forms.ToolStripButton _undoToolStripButton;
      private System.Windows.Forms.ToolStripButton _redoToolStripButton;
      private System.Windows.Forms.ToolStripSeparator _annotationsSep2ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _annotationsPropertiesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fileOpenRtfToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fileOpenEmfToolStripMenuItem;
   }
}

