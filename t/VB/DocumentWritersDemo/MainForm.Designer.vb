Namespace DocumentWritersDemo
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
         Me._fileNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._fileOpenRtfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._fileOpenEmfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._fileSaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._fileSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._fileExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._editToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._editUndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._editRedoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._editSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._editCutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._editCopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._editPasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._editDeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._editSep2ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._editSelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._editSelectNoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._viewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._viewZoomOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._viewZoomInToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._viewSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._viewFitWidthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._viewFitPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._annotationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._annotationsCurrentObjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._annotationsSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._annotationsAlignToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._alignBringToFrontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._alignSendToBackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._alignBringToFirstToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._alignSendToLastToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._annotationsSep2ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._annotationsPropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._helpAboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._mainToolStrip = New System.Windows.Forms.ToolStrip()
         Me._newToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._saveToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
         Me._copyToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._pasteToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._deleteToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
         Me._undoToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._redoToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._mainSplitter = New System.Windows.Forms.Splitter()
         Me._viewerControl = New DocumentWritersDemo.ViewerControl()
         Me._pagesControl = New DocumentWritersDemo.PagesControl()
         Me._mainMenuStrip.SuspendLayout()
         Me._mainToolStrip.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _mainMenuStrip
         ' 
         Me._mainMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._fileToolStripMenuItem, Me._editToolStripMenuItem, Me._viewToolStripMenuItem, Me._annotationsToolStripMenuItem, Me._helpToolStripMenuItem})
         Me._mainMenuStrip.Location = New System.Drawing.Point(0, 0)
         Me._mainMenuStrip.Name = "_mainMenuStrip"
         Me._mainMenuStrip.Size = New System.Drawing.Size(904, 24)
         Me._mainMenuStrip.TabIndex = 0
         Me._mainMenuStrip.Text = "_mainMenuStrip"
         ' 
         ' _fileToolStripMenuItem
         ' 
         Me._fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._fileNewToolStripMenuItem, Me._fileOpenRtfToolStripMenuItem, Me._fileOpenEmfToolStripMenuItem, Me._fileSaveToolStripMenuItem, Me._fileSep1ToolStripMenuItem, Me._fileExitToolStripMenuItem})
         Me._fileToolStripMenuItem.Name = "_fileToolStripMenuItem"
         Me._fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
         Me._fileToolStripMenuItem.Text = "&File"
         ' 
         ' _fileNewToolStripMenuItem
         ' 
         Me._fileNewToolStripMenuItem.Image = Global.DocumentWritersDemo.Resources.NewDocument
         Me._fileNewToolStripMenuItem.Name = "_fileNewToolStripMenuItem"
         Me._fileNewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
         Me._fileNewToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
         Me._fileNewToolStripMenuItem.Text = "&New..."
         ' 
         ' _fileOpenRtfToolStripMenuItem
         ' 
         Me._fileOpenRtfToolStripMenuItem.Image = Global.DocumentWritersDemo.Resources.OpenDocument
         Me._fileOpenRtfToolStripMenuItem.Name = "_fileOpenRtfToolStripMenuItem"
         Me._fileOpenRtfToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
         Me._fileOpenRtfToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
         Me._fileOpenRtfToolStripMenuItem.Text = "&Open Rtf Document"
         ' 
         ' _fileOpenEmfToolStripMenuItem
         ' 
         Me._fileOpenEmfToolStripMenuItem.Image = Global.DocumentWritersDemo.Resources.OpenDocument
         Me._fileOpenEmfToolStripMenuItem.Name = "_fileOpenEmfToolStripMenuItem"
         Me._fileOpenEmfToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
         Me._fileOpenEmfToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
         Me._fileOpenEmfToolStripMenuItem.Text = "&Open Emf File(s)"
         ' 
         ' _fileSaveToolStripMenuItem
         ' 
         Me._fileSaveToolStripMenuItem.Image = Global.DocumentWritersDemo.Resources.SaveDocument
         Me._fileSaveToolStripMenuItem.Name = "_fileSaveToolStripMenuItem"
         Me._fileSaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
         Me._fileSaveToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
         Me._fileSaveToolStripMenuItem.Text = "&Save..."
         ' 
         ' _fileSep1ToolStripMenuItem
         ' 
         Me._fileSep1ToolStripMenuItem.Name = "_fileSep1ToolStripMenuItem"
         Me._fileSep1ToolStripMenuItem.Size = New System.Drawing.Size(218, 6)
         ' 
         ' _fileExitToolStripMenuItem
         ' 
         Me._fileExitToolStripMenuItem.Name = "_fileExitToolStripMenuItem"
         Me._fileExitToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
         Me._fileExitToolStripMenuItem.Text = "E&xit"
         ' 
         ' _editToolStripMenuItem
         ' 
         Me._editToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._editUndoToolStripMenuItem, Me._editRedoToolStripMenuItem, Me._editSep1ToolStripMenuItem, Me._editCutToolStripMenuItem, Me._editCopyToolStripMenuItem, Me._editPasteToolStripMenuItem, _
          Me._editDeleteToolStripMenuItem, Me._editSep2ToolStripMenuItem, Me._editSelectAllToolStripMenuItem, Me._editSelectNoneToolStripMenuItem})
         Me._editToolStripMenuItem.Name = "_editToolStripMenuItem"
         Me._editToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
         Me._editToolStripMenuItem.Text = "&Edit"
         ' 
         ' _editUndoToolStripMenuItem
         ' 
         Me._editUndoToolStripMenuItem.Image = Global.DocumentWritersDemo.Resources.Undo
         Me._editUndoToolStripMenuItem.Name = "_editUndoToolStripMenuItem"
         Me._editUndoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
         Me._editUndoToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
         Me._editUndoToolStripMenuItem.Text = "&Undo"
         ' 
         ' _editRedoToolStripMenuItem
         ' 
         Me._editRedoToolStripMenuItem.Image = Global.DocumentWritersDemo.Resources.Redo
         Me._editRedoToolStripMenuItem.Name = "_editRedoToolStripMenuItem"
         Me._editRedoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
         Me._editRedoToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
         Me._editRedoToolStripMenuItem.Text = "&Redo"
         ' 
         ' _editSep1ToolStripMenuItem
         ' 
         Me._editSep1ToolStripMenuItem.Name = "_editSep1ToolStripMenuItem"
         Me._editSep1ToolStripMenuItem.Size = New System.Drawing.Size(159, 6)
         ' 
         ' _editCutToolStripMenuItem
         ' 
         Me._editCutToolStripMenuItem.Name = "_editCutToolStripMenuItem"
         Me._editCutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
         Me._editCutToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
         Me._editCutToolStripMenuItem.Text = "Cu&t"
         ' 
         ' _editCopyToolStripMenuItem
         ' 
         Me._editCopyToolStripMenuItem.Image = Global.DocumentWritersDemo.Resources.Copy
         Me._editCopyToolStripMenuItem.Name = "_editCopyToolStripMenuItem"
         Me._editCopyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
         Me._editCopyToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
         Me._editCopyToolStripMenuItem.Text = "&Copy"
         ' 
         ' _editPasteToolStripMenuItem
         ' 
         Me._editPasteToolStripMenuItem.Image = Global.DocumentWritersDemo.Resources.Paste
         Me._editPasteToolStripMenuItem.Name = "_editPasteToolStripMenuItem"
         Me._editPasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
         Me._editPasteToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
         Me._editPasteToolStripMenuItem.Text = "&Paste"
         ' 
         ' _editDeleteToolStripMenuItem
         ' 
         Me._editDeleteToolStripMenuItem.Image = Global.DocumentWritersDemo.Resources.Delete
         Me._editDeleteToolStripMenuItem.Name = "_editDeleteToolStripMenuItem"
         Me._editDeleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
         Me._editDeleteToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
         Me._editDeleteToolStripMenuItem.Text = "&Delete"
         ' 
         ' _editSep2ToolStripMenuItem
         ' 
         Me._editSep2ToolStripMenuItem.Name = "_editSep2ToolStripMenuItem"
         Me._editSep2ToolStripMenuItem.Size = New System.Drawing.Size(159, 6)
         ' 
         ' _editSelectAllToolStripMenuItem
         ' 
         Me._editSelectAllToolStripMenuItem.Name = "_editSelectAllToolStripMenuItem"
         Me._editSelectAllToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
         Me._editSelectAllToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
         Me._editSelectAllToolStripMenuItem.Text = "Select &all"
         ' 
         ' _editSelectNoneToolStripMenuItem
         ' 
         Me._editSelectNoneToolStripMenuItem.Name = "_editSelectNoneToolStripMenuItem"
         Me._editSelectNoneToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
         Me._editSelectNoneToolStripMenuItem.Text = "Select &none"
         ' 
         ' _viewToolStripMenuItem
         ' 
         Me._viewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._viewZoomOutToolStripMenuItem, Me._viewZoomInToolStripMenuItem, Me._viewSep1ToolStripMenuItem, Me._viewFitWidthToolStripMenuItem, Me._viewFitPageToolStripMenuItem})
         Me._viewToolStripMenuItem.Name = "_viewToolStripMenuItem"
         Me._viewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
         Me._viewToolStripMenuItem.Text = "&View"
         ' 
         ' _viewZoomOutToolStripMenuItem
         ' 
         Me._viewZoomOutToolStripMenuItem.Image = Global.DocumentWritersDemo.Resources.ZoomOut
         Me._viewZoomOutToolStripMenuItem.Name = "_viewZoomOutToolStripMenuItem"
         Me._viewZoomOutToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
         Me._viewZoomOutToolStripMenuItem.Text = "Zoom &out"
         ' 
         ' _viewZoomInToolStripMenuItem
         ' 
         Me._viewZoomInToolStripMenuItem.Image = Global.DocumentWritersDemo.Resources.ZoomIn
         Me._viewZoomInToolStripMenuItem.Name = "_viewZoomInToolStripMenuItem"
         Me._viewZoomInToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
         Me._viewZoomInToolStripMenuItem.Text = "Zoom &in"
         ' 
         ' _viewSep1ToolStripMenuItem
         ' 
         Me._viewSep1ToolStripMenuItem.Name = "_viewSep1ToolStripMenuItem"
         Me._viewSep1ToolStripMenuItem.Size = New System.Drawing.Size(124, 6)
         ' 
         ' _viewFitWidthToolStripMenuItem
         ' 
         Me._viewFitWidthToolStripMenuItem.Image = Global.DocumentWritersDemo.Resources.FitPageWidth
         Me._viewFitWidthToolStripMenuItem.Name = "_viewFitWidthToolStripMenuItem"
         Me._viewFitWidthToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
         Me._viewFitWidthToolStripMenuItem.Text = "Fit &width"
         ' 
         ' _viewFitPageToolStripMenuItem
         ' 
         Me._viewFitPageToolStripMenuItem.Image = Global.DocumentWritersDemo.Resources.FitPage
         Me._viewFitPageToolStripMenuItem.Name = "_viewFitPageToolStripMenuItem"
         Me._viewFitPageToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
         Me._viewFitPageToolStripMenuItem.Text = "&Fit page"
         ' 
         ' _annotationsToolStripMenuItem
         ' 
         Me._annotationsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._annotationsCurrentObjectToolStripMenuItem, Me._annotationsSep1ToolStripMenuItem, Me._annotationsAlignToolStripMenuItem, Me._annotationsSep2ToolStripMenuItem, Me._annotationsPropertiesToolStripMenuItem})
         Me._annotationsToolStripMenuItem.Name = "_annotationsToolStripMenuItem"
         Me._annotationsToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
         Me._annotationsToolStripMenuItem.Text = "&Annotations"
         ' 
         ' _annotationsCurrentObjectToolStripMenuItem
         ' 
         Me._annotationsCurrentObjectToolStripMenuItem.Name = "_annotationsCurrentObjectToolStripMenuItem"
         Me._annotationsCurrentObjectToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
         Me._annotationsCurrentObjectToolStripMenuItem.Text = "&Current object"
         ' 
         ' _annotationsSep1ToolStripMenuItem
         ' 
         Me._annotationsSep1ToolStripMenuItem.Name = "_annotationsSep1ToolStripMenuItem"
         Me._annotationsSep1ToolStripMenuItem.Size = New System.Drawing.Size(147, 6)
         ' 
         ' _annotationsAlignToolStripMenuItem
         ' 
         Me._annotationsAlignToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._alignBringToFrontToolStripMenuItem, Me._alignSendToBackToolStripMenuItem, Me._alignBringToFirstToolStripMenuItem, Me._alignSendToLastToolStripMenuItem})
         Me._annotationsAlignToolStripMenuItem.Name = "_annotationsAlignToolStripMenuItem"
         Me._annotationsAlignToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
         Me._annotationsAlignToolStripMenuItem.Text = "&Align"
         ' 
         ' _alignBringToFrontToolStripMenuItem
         ' 
         Me._alignBringToFrontToolStripMenuItem.Image = Global.DocumentWritersDemo.Resources.BringToFront
         Me._alignBringToFrontToolStripMenuItem.Name = "_alignBringToFrontToolStripMenuItem"
         Me._alignBringToFrontToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
         Me._alignBringToFrontToolStripMenuItem.Text = "&Bring to front"
         ' 
         ' _alignSendToBackToolStripMenuItem
         ' 
         Me._alignSendToBackToolStripMenuItem.Image = Global.DocumentWritersDemo.Resources.SendToBack
         Me._alignSendToBackToolStripMenuItem.Name = "_alignSendToBackToolStripMenuItem"
         Me._alignSendToBackToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
         Me._alignSendToBackToolStripMenuItem.Text = "&Send to back"
         ' 
         ' _alignBringToFirstToolStripMenuItem
         ' 
         Me._alignBringToFirstToolStripMenuItem.Image = Global.DocumentWritersDemo.Resources.BringToFirst
         Me._alignBringToFirstToolStripMenuItem.Name = "_alignBringToFirstToolStripMenuItem"
         Me._alignBringToFirstToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
         Me._alignBringToFirstToolStripMenuItem.Text = "Bring to &first"
         ' 
         ' _alignSendToLastToolStripMenuItem
         ' 
         Me._alignSendToLastToolStripMenuItem.Image = Global.DocumentWritersDemo.Resources.SendToLast
         Me._alignSendToLastToolStripMenuItem.Name = "_alignSendToLastToolStripMenuItem"
         Me._alignSendToLastToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
         Me._alignSendToLastToolStripMenuItem.Text = "Send to &last"
         ' 
         ' _annotationsSep2ToolStripMenuItem
         ' 
         Me._annotationsSep2ToolStripMenuItem.Name = "_annotationsSep2ToolStripMenuItem"
         Me._annotationsSep2ToolStripMenuItem.Size = New System.Drawing.Size(147, 6)
         ' 
         ' _annotationsPropertiesToolStripMenuItem
         ' 
         Me._annotationsPropertiesToolStripMenuItem.Image = Global.DocumentWritersDemo.Resources.ObjectProperties
         Me._annotationsPropertiesToolStripMenuItem.Name = "_annotationsPropertiesToolStripMenuItem"
         Me._annotationsPropertiesToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
         Me._annotationsPropertiesToolStripMenuItem.Text = "&Properties..."
         ' 
         ' _helpToolStripMenuItem
         ' 
         Me._helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._helpAboutToolStripMenuItem})
         Me._helpToolStripMenuItem.Name = "_helpToolStripMenuItem"
         Me._helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
         Me._helpToolStripMenuItem.Text = "&Help"
         ' 
         ' _helpAboutToolStripMenuItem
         ' 
         Me._helpAboutToolStripMenuItem.Name = "_helpAboutToolStripMenuItem"
         Me._helpAboutToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
         Me._helpAboutToolStripMenuItem.Text = "&About..."
         ' 
         ' _mainToolStrip
         ' 
         Me._mainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._newToolStripButton, Me._saveToolStripButton, Me._toolStripSeparator1, Me._copyToolStripButton, Me._pasteToolStripButton, Me._deleteToolStripButton, _
          Me._toolStripSeparator2, Me._undoToolStripButton, Me._redoToolStripButton})
         Me._mainToolStrip.Location = New System.Drawing.Point(0, 24)
         Me._mainToolStrip.Name = "_mainToolStrip"
         Me._mainToolStrip.Size = New System.Drawing.Size(904, 25)
         Me._mainToolStrip.TabIndex = 1
         Me._mainToolStrip.Text = "toolStrip1"
         ' 
         ' _newToolStripButton
         ' 
         Me._newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._newToolStripButton.Image = Global.DocumentWritersDemo.Resources.NewDocument
         Me._newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._newToolStripButton.Name = "_newToolStripButton"
         Me._newToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._newToolStripButton.ToolTipText = "Create a new empty document"
         ' 
         ' _saveToolStripButton
         ' 
         Me._saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._saveToolStripButton.Image = Global.DocumentWritersDemo.Resources.SaveDocument
         Me._saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._saveToolStripButton.Name = "_saveToolStripButton"
         Me._saveToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._saveToolStripButton.ToolTipText = "Save the current document using the LEADTOOLS document writers"
         ' 
         ' _toolStripSeparator1
         ' 
         Me._toolStripSeparator1.Name = "_toolStripSeparator1"
         Me._toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
         ' 
         ' _copyToolStripButton
         ' 
         Me._copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._copyToolStripButton.Image = Global.DocumentWritersDemo.Resources.Copy
         Me._copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._copyToolStripButton.Name = "_copyToolStripButton"
         Me._copyToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._copyToolStripButton.ToolTipText = "Copy the select objects from the current page to the clipboard"
         ' 
         ' _pasteToolStripButton
         ' 
         Me._pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._pasteToolStripButton.Image = Global.DocumentWritersDemo.Resources.Paste
         Me._pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._pasteToolStripButton.Name = "_pasteToolStripButton"
         Me._pasteToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._pasteToolStripButton.ToolTipText = "Paste objects from the clipboard to the current page"
         ' 
         ' _deleteToolStripButton
         ' 
         Me._deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._deleteToolStripButton.Image = Global.DocumentWritersDemo.Resources.Delete
         Me._deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._deleteToolStripButton.Name = "_deleteToolStripButton"
         Me._deleteToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._deleteToolStripButton.ToolTipText = "Delete the selected objects from the current page"
         ' 
         ' _toolStripSeparator2
         ' 
         Me._toolStripSeparator2.Name = "_toolStripSeparator2"
         Me._toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
         ' 
         ' _undoToolStripButton
         ' 
         Me._undoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._undoToolStripButton.Image = Global.DocumentWritersDemo.Resources.Undo
         Me._undoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._undoToolStripButton.Name = "_undoToolStripButton"
         Me._undoToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._undoToolStripButton.ToolTipText = "Undo the last operation"
         ' 
         ' _redoToolStripButton
         ' 
         Me._redoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._redoToolStripButton.Image = Global.DocumentWritersDemo.Resources.Redo
         Me._redoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._redoToolStripButton.Name = "_redoToolStripButton"
         Me._redoToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._redoToolStripButton.ToolTipText = "Redo the last operation"
         ' 
         ' _mainSplitter
         ' 
         Me._mainSplitter.Location = New System.Drawing.Point(217, 49)
         Me._mainSplitter.Name = "_mainSplitter"
         Me._mainSplitter.Size = New System.Drawing.Size(3, 575)
         Me._mainSplitter.TabIndex = 5
         Me._mainSplitter.TabStop = False
         ' 
         ' _viewerControl
         ' 
         Me._viewerControl.Dock = System.Windows.Forms.DockStyle.Fill
         Me._viewerControl.Location = New System.Drawing.Point(220, 49)
         Me._viewerControl.Name = "_viewerControl"
         Me._viewerControl.Size = New System.Drawing.Size(684, 575)
         Me._viewerControl.TabIndex = 6
         ' 
         ' _pagesControl
         ' 
         Me._pagesControl.Dock = System.Windows.Forms.DockStyle.Left
         Me._pagesControl.Location = New System.Drawing.Point(0, 49)
         Me._pagesControl.Name = "_pagesControl"
         Me._pagesControl.Size = New System.Drawing.Size(217, 575)
         Me._pagesControl.TabIndex = 2
         ' 
         ' MainForm
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(904, 624)
         Me.Controls.Add(Me._viewerControl)
         Me.Controls.Add(Me._mainSplitter)
         Me.Controls.Add(Me._pagesControl)
         Me.Controls.Add(Me._mainToolStrip)
         Me.Controls.Add(Me._mainMenuStrip)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.MainMenuStrip = Me._mainMenuStrip
         Me.Name = "MainForm"
         Me.Text = "MainForm"
         Me._mainMenuStrip.ResumeLayout(False)
         Me._mainMenuStrip.PerformLayout()
         Me._mainToolStrip.ResumeLayout(False)
         Me._mainToolStrip.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _mainMenuStrip As System.Windows.Forms.MenuStrip
      Private _fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _fileNewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _fileSaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _fileSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _fileExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _helpAboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _editToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _editCopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _editPasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _viewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _viewZoomOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _viewZoomInToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _viewSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _viewFitWidthToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _viewFitPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _mainToolStrip As System.Windows.Forms.ToolStrip
      Private WithEvents _newToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _saveToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _pagesControl As PagesControl
      Private _mainSplitter As System.Windows.Forms.Splitter
      Private WithEvents _viewerControl As ViewerControl
      Private WithEvents _editUndoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _editRedoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _editSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _editCutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _editDeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _editSep2ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _editSelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _editSelectNoneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _annotationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _annotationsCurrentObjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _annotationsSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _annotationsAlignToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _alignBringToFrontToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _alignSendToBackToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _alignBringToFirstToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _alignSendToLastToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _copyToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _pasteToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _deleteToolStripButton As System.Windows.Forms.ToolStripButton
      Private _toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _undoToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _redoToolStripButton As System.Windows.Forms.ToolStripButton
      Private _annotationsSep2ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _annotationsPropertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _fileOpenRtfToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _fileOpenEmfToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   End Class
End Namespace
