Imports Leadtools
Imports Leadtools.Controls

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
      Me._mainMenuStrip = New System.Windows.Forms.MenuStrip
      Me._fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._fileOpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._fileSaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._fileSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator
      Me._fileExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewZoomOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewZoomInToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator
      Me._viewFitWidthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewFitPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewSep2ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator
      Me._viewHighlightRecognizedWordsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._wordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._wordUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._wordDeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._preferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._preferencesPdfResolutionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._preferencesUseCallbacksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._preferencesViewSavedDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._helpAboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewerToolStrip = New System.Windows.Forms.ToolStrip
      Me._openToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._saveToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._viewerToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
      Me._zoomOutToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._zoomInToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._zoomToolStripComboBox = New System.Windows.Forms.ToolStripComboBox
      Me._fitPageWidthToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._fitPageToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._viewerToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
      Me._highlightWordsToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._updateWordToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._deleteWordToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._controlsPanel = New System.Windows.Forms.Panel
      Me._deleteButton = New System.Windows.Forms.Button
      Me._demoDescriptionLabel = New System.Windows.Forms.Label
      Me._updateButton = New System.Windows.Forms.Button
      Me._wordTextBox = New System.Windows.Forms.TextBox
      Me._mousePositionLabel = New System.Windows.Forms.Label
      Me._imageViewer = New ImageViewer()
      Me._mainMenuStrip.SuspendLayout()
      Me._viewerToolStrip.SuspendLayout()
      Me._controlsPanel.SuspendLayout()
      Me.SuspendLayout()
      '
      '_mainMenuStrip
      '
      Me._mainMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._fileToolStripMenuItem, Me._viewToolStripMenuItem, Me._wordToolStripMenuItem, Me._preferencesToolStripMenuItem, Me._helpToolStripMenuItem})
      Me._mainMenuStrip.Location = New System.Drawing.Point(0, 0)
      Me._mainMenuStrip.Name = "_mainMenuStrip"
      Me._mainMenuStrip.Size = New System.Drawing.Size(894, 24)
      Me._mainMenuStrip.TabIndex = 1
      '
      '_fileToolStripMenuItem
      '
      Me._fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._fileOpenToolStripMenuItem, Me._fileSaveToolStripMenuItem, Me._fileSep1ToolStripMenuItem, Me._fileExitToolStripMenuItem})
      Me._fileToolStripMenuItem.Name = "_fileToolStripMenuItem"
      Me._fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
      Me._fileToolStripMenuItem.Text = "&File"
      '
      '_fileOpenToolStripMenuItem
      '
      Me._fileOpenToolStripMenuItem.Image = Global.OcrEditDemo.My.Resources.Resources.OpenDocument
      Me._fileOpenToolStripMenuItem.Name = "_fileOpenToolStripMenuItem"
      Me._fileOpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
      Me._fileOpenToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
      Me._fileOpenToolStripMenuItem.Text = "&Open..."
      '
      '_fileSaveToolStripMenuItem
      '
      Me._fileSaveToolStripMenuItem.Image = Global.OcrEditDemo.My.Resources.Resources.SaveDocument
      Me._fileSaveToolStripMenuItem.Name = "_fileSaveToolStripMenuItem"
      Me._fileSaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
      Me._fileSaveToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
      Me._fileSaveToolStripMenuItem.Text = "&Save..."
      '
      '_fileSep1ToolStripMenuItem
      '
      Me._fileSep1ToolStripMenuItem.Name = "_fileSep1ToolStripMenuItem"
      Me._fileSep1ToolStripMenuItem.Size = New System.Drawing.Size(152, 6)
      '
      '_fileExitToolStripMenuItem
      '
      Me._fileExitToolStripMenuItem.Name = "_fileExitToolStripMenuItem"
      Me._fileExitToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
      Me._fileExitToolStripMenuItem.Text = "&Exit"
      '
      '_viewToolStripMenuItem
      '
      Me._viewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._viewZoomOutToolStripMenuItem, Me._viewZoomInToolStripMenuItem, Me._viewSep1ToolStripMenuItem, Me._viewFitWidthToolStripMenuItem, Me._viewFitPageToolStripMenuItem, Me._viewSep2ToolStripMenuItem, Me._viewHighlightRecognizedWordsToolStripMenuItem})
      Me._viewToolStripMenuItem.Name = "_viewToolStripMenuItem"
      Me._viewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
      Me._viewToolStripMenuItem.Text = "&View"
      '
      '_viewZoomOutToolStripMenuItem
      '
      Me._viewZoomOutToolStripMenuItem.Image = Global.OcrEditDemo.My.Resources.Resources.ZoomOut
      Me._viewZoomOutToolStripMenuItem.Name = "_viewZoomOutToolStripMenuItem"
      Me._viewZoomOutToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
      Me._viewZoomOutToolStripMenuItem.Text = "Zoom &out"
      '
      '_viewZoomInToolStripMenuItem
      '
      Me._viewZoomInToolStripMenuItem.Image = Global.OcrEditDemo.My.Resources.Resources.ZoomIn
      Me._viewZoomInToolStripMenuItem.Name = "_viewZoomInToolStripMenuItem"
      Me._viewZoomInToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
      Me._viewZoomInToolStripMenuItem.Text = "Zoom &in"
      '
      '_viewSep1ToolStripMenuItem
      '
      Me._viewSep1ToolStripMenuItem.Name = "_viewSep1ToolStripMenuItem"
      Me._viewSep1ToolStripMenuItem.Size = New System.Drawing.Size(217, 6)
      '
      '_viewFitWidthToolStripMenuItem
      '
      Me._viewFitWidthToolStripMenuItem.CheckOnClick = True
      Me._viewFitWidthToolStripMenuItem.Image = Global.OcrEditDemo.My.Resources.Resources.FitPageWidth
      Me._viewFitWidthToolStripMenuItem.Name = "_viewFitWidthToolStripMenuItem"
      Me._viewFitWidthToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
      Me._viewFitWidthToolStripMenuItem.Text = "Fit &width"
      '
      '_viewFitPageToolStripMenuItem
      '
      Me._viewFitPageToolStripMenuItem.CheckOnClick = True
      Me._viewFitPageToolStripMenuItem.Image = Global.OcrEditDemo.My.Resources.Resources.FitPage
      Me._viewFitPageToolStripMenuItem.Name = "_viewFitPageToolStripMenuItem"
      Me._viewFitPageToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
      Me._viewFitPageToolStripMenuItem.Text = "&Fit page"
      '
      '_viewSep2ToolStripMenuItem
      '
      Me._viewSep2ToolStripMenuItem.Name = "_viewSep2ToolStripMenuItem"
      Me._viewSep2ToolStripMenuItem.Size = New System.Drawing.Size(217, 6)
      '
      '_viewHighlightRecognizedWordsToolStripMenuItem
      '
      Me._viewHighlightRecognizedWordsToolStripMenuItem.Checked = True
      Me._viewHighlightRecognizedWordsToolStripMenuItem.CheckOnClick = True
      Me._viewHighlightRecognizedWordsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
      Me._viewHighlightRecognizedWordsToolStripMenuItem.Image = Global.OcrEditDemo.My.Resources.Resources.ShowZones
      Me._viewHighlightRecognizedWordsToolStripMenuItem.Name = "_viewHighlightRecognizedWordsToolStripMenuItem"
      Me._viewHighlightRecognizedWordsToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
      Me._viewHighlightRecognizedWordsToolStripMenuItem.Text = "&Highlight recognized words"
      '
      '_wordToolStripMenuItem
      '
      Me._wordToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._wordUpdateToolStripMenuItem, Me._wordDeleteToolStripMenuItem})
      Me._wordToolStripMenuItem.Name = "_wordToolStripMenuItem"
      Me._wordToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
      Me._wordToolStripMenuItem.Text = "&Words"
      '
      '_wordUpdateToolStripMenuItem
      '
      Me._wordUpdateToolStripMenuItem.Image = Global.OcrEditDemo.My.Resources.Resources.AutoZonePage
      Me._wordUpdateToolStripMenuItem.Name = "_wordUpdateToolStripMenuItem"
      Me._wordUpdateToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
      Me._wordUpdateToolStripMenuItem.Text = "&Update"
      '
      '_wordDeleteToolStripMenuItem
      '
      Me._wordDeleteToolStripMenuItem.Image = Global.OcrEditDemo.My.Resources.Resources.DeleteZone
      Me._wordDeleteToolStripMenuItem.Name = "_wordDeleteToolStripMenuItem"
      Me._wordDeleteToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
      Me._wordDeleteToolStripMenuItem.Text = "&Delete"
      '
      '_preferencesToolStripMenuItem
      '
      Me._preferencesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._preferencesPdfResolutionToolStripMenuItem, Me._preferencesUseCallbacksToolStripMenuItem, Me._preferencesViewSavedDocumentToolStripMenuItem})
      Me._preferencesToolStripMenuItem.Name = "_preferencesToolStripMenuItem"
      Me._preferencesToolStripMenuItem.Size = New System.Drawing.Size(80, 20)
      Me._preferencesToolStripMenuItem.Text = "&Preferences"
      '
      '_preferencesPdfResolutionToolStripMenuItem
      '
      Me._preferencesPdfResolutionToolStripMenuItem.Name = "_preferencesPdfResolutionToolStripMenuItem"
      Me._preferencesPdfResolutionToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
      Me._preferencesPdfResolutionToolStripMenuItem.Text = "&Set PDF files load resolution..."
      '
      '_preferencesUseCallbacksToolStripMenuItem
      '
      Me._preferencesUseCallbacksToolStripMenuItem.Checked = True
      Me._preferencesUseCallbacksToolStripMenuItem.CheckOnClick = True
      Me._preferencesUseCallbacksToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
      Me._preferencesUseCallbacksToolStripMenuItem.Name = "_preferencesUseCallbacksToolStripMenuItem"
      Me._preferencesUseCallbacksToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
      Me._preferencesUseCallbacksToolStripMenuItem.Text = "&Use callbacks"
      '
      '_preferencesViewSavedDocumentToolStripMenuItem
      '
      Me._preferencesViewSavedDocumentToolStripMenuItem.Checked = True
      Me._preferencesViewSavedDocumentToolStripMenuItem.CheckOnClick = True
      Me._preferencesViewSavedDocumentToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
      Me._preferencesViewSavedDocumentToolStripMenuItem.Name = "_preferencesViewSavedDocumentToolStripMenuItem"
      Me._preferencesViewSavedDocumentToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
      Me._preferencesViewSavedDocumentToolStripMenuItem.Text = "&View saved document"
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
      '_viewerToolStrip
      '
      Me._viewerToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._openToolStripButton, Me._saveToolStripButton, Me._viewerToolStripSeparator1, Me._zoomOutToolStripButton, Me._zoomInToolStripButton, Me._zoomToolStripComboBox, Me._fitPageWidthToolStripButton, Me._fitPageToolStripButton, Me._viewerToolStripSeparator2, Me._highlightWordsToolStripButton, Me._updateWordToolStripButton, Me._deleteWordToolStripButton})
      Me._viewerToolStrip.Location = New System.Drawing.Point(0, 24)
      Me._viewerToolStrip.Name = "_viewerToolStrip"
      Me._viewerToolStrip.Size = New System.Drawing.Size(894, 25)
      Me._viewerToolStrip.TabIndex = 2
      Me._viewerToolStrip.Text = "toolStrip1"
      '
      '_openToolStripButton
      '
      Me._openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._openToolStripButton.Image = Global.OcrEditDemo.My.Resources.Resources.OpenDocument
      Me._openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._openToolStripButton.Name = "_openToolStripButton"
      Me._openToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._openToolStripButton.ToolTipText = "Open a new document"
      '
      '_saveToolStripButton
      '
      Me._saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._saveToolStripButton.Image = Global.OcrEditDemo.My.Resources.Resources.SaveDocument
      Me._saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._saveToolStripButton.Name = "_saveToolStripButton"
      Me._saveToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._saveToolStripButton.ToolTipText = "Save this document as PDF"
      '
      '_viewerToolStripSeparator1
      '
      Me._viewerToolStripSeparator1.Name = "_viewerToolStripSeparator1"
      Me._viewerToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
      '
      '_zoomOutToolStripButton
      '
      Me._zoomOutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._zoomOutToolStripButton.Image = Global.OcrEditDemo.My.Resources.Resources.ZoomOut
      Me._zoomOutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._zoomOutToolStripButton.Name = "_zoomOutToolStripButton"
      Me._zoomOutToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._zoomOutToolStripButton.ToolTipText = "Zoom out"
      '
      '_zoomInToolStripButton
      '
      Me._zoomInToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._zoomInToolStripButton.Image = Global.OcrEditDemo.My.Resources.Resources.ZoomIn
      Me._zoomInToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._zoomInToolStripButton.Name = "_zoomInToolStripButton"
      Me._zoomInToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._zoomInToolStripButton.ToolTipText = "Zoom in"
      '
      '_zoomToolStripComboBox
      '
      Me._zoomToolStripComboBox.DropDownWidth = 80
      Me._zoomToolStripComboBox.Items.AddRange(New Object() {"10%", "25%", "50%", "75%", "100%", "125%", "200%", "400%", "800%", "1600%", "2400%", "3200%", "6400%", "Actual Size", "Fit Page", "Fit Width"})
      Me._zoomToolStripComboBox.Name = "_zoomToolStripComboBox"
      Me._zoomToolStripComboBox.Size = New System.Drawing.Size(80, 25)
      '
      '_fitPageWidthToolStripButton
      '
      Me._fitPageWidthToolStripButton.CheckOnClick = True
      Me._fitPageWidthToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._fitPageWidthToolStripButton.Image = Global.OcrEditDemo.My.Resources.Resources.FitPageWidth
      Me._fitPageWidthToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._fitPageWidthToolStripButton.Name = "_fitPageWidthToolStripButton"
      Me._fitPageWidthToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._fitPageWidthToolStripButton.ToolTipText = "Fit page width in window"
      '
      '_fitPageToolStripButton
      '
      Me._fitPageToolStripButton.CheckOnClick = True
      Me._fitPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._fitPageToolStripButton.Image = Global.OcrEditDemo.My.Resources.Resources.FitPage
      Me._fitPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._fitPageToolStripButton.Name = "_fitPageToolStripButton"
      Me._fitPageToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._fitPageToolStripButton.ToolTipText = "Fit entire page in window"
      '
      '_viewerToolStripSeparator2
      '
      Me._viewerToolStripSeparator2.Name = "_viewerToolStripSeparator2"
      Me._viewerToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
      '
      '_highlightWordsToolStripButton
      '
      Me._highlightWordsToolStripButton.Checked = True
      Me._highlightWordsToolStripButton.CheckOnClick = True
      Me._highlightWordsToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked
      Me._highlightWordsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._highlightWordsToolStripButton.Image = Global.OcrEditDemo.My.Resources.Resources.ShowZones
      Me._highlightWordsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._highlightWordsToolStripButton.Name = "_highlightWordsToolStripButton"
      Me._highlightWordsToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._highlightWordsToolStripButton.ToolTipText = "Highlight the recognized words"
      '
      '_updateWordToolStripButton
      '
      Me._updateWordToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._updateWordToolStripButton.Image = Global.OcrEditDemo.My.Resources.Resources.AutoZonePage
      Me._updateWordToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._updateWordToolStripButton.Name = "_updateWordToolStripButton"
      Me._updateWordToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._updateWordToolStripButton.ToolTipText = "Update the selected word"
      '
      '_deleteWordToolStripButton
      '
      Me._deleteWordToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._deleteWordToolStripButton.Image = Global.OcrEditDemo.My.Resources.Resources.DeleteZone
      Me._deleteWordToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._deleteWordToolStripButton.Name = "_deleteWordToolStripButton"
      Me._deleteWordToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._deleteWordToolStripButton.ToolTipText = "Delete selected word"
      '
      '_controlsPanel
      '
      Me._controlsPanel.Controls.Add(Me._deleteButton)
      Me._controlsPanel.Controls.Add(Me._demoDescriptionLabel)
      Me._controlsPanel.Controls.Add(Me._updateButton)
      Me._controlsPanel.Controls.Add(Me._wordTextBox)
      Me._controlsPanel.Dock = System.Windows.Forms.DockStyle.Top
      Me._controlsPanel.Location = New System.Drawing.Point(0, 49)
      Me._controlsPanel.Name = "_controlsPanel"
      Me._controlsPanel.Size = New System.Drawing.Size(894, 146)
      Me._controlsPanel.TabIndex = 3
      '
      '_deleteButton
      '
      Me._deleteButton.Location = New System.Drawing.Point(267, 116)
      Me._deleteButton.Name = "_deleteButton"
      Me._deleteButton.Size = New System.Drawing.Size(75, 23)
      Me._deleteButton.TabIndex = 3
      Me._deleteButton.Text = "&Delete"
      Me._deleteButton.UseVisualStyleBackColor = True
      '
      '_demoDescriptionLabel
      '
      Me._demoDescriptionLabel.AutoSize = True
      Me._demoDescriptionLabel.Location = New System.Drawing.Point(4, 11)
      Me._demoDescriptionLabel.Name = "_demoDescriptionLabel"
      Me._demoDescriptionLabel.Size = New System.Drawing.Size(609, 78)
      Me._demoDescriptionLabel.TabIndex = 0
      Me._demoDescriptionLabel.Text = resources.GetString("_demoDescriptionLabel.Text")
      '
      '_updateButton
      '
      Me._updateButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._updateButton.Location = New System.Drawing.Point(186, 116)
      Me._updateButton.Name = "_updateButton"
      Me._updateButton.Size = New System.Drawing.Size(75, 23)
      Me._updateButton.TabIndex = 1
      Me._updateButton.Text = "&Update"
      Me._updateButton.UseVisualStyleBackColor = True
      '
      '_wordTextBox
      '
      Me._wordTextBox.Location = New System.Drawing.Point(12, 118)
      Me._wordTextBox.Name = "_wordTextBox"
      Me._wordTextBox.Size = New System.Drawing.Size(168, 20)
      Me._wordTextBox.TabIndex = 2
      '
      '_mousePositionLabel
      '
      Me._mousePositionLabel.Dock = System.Windows.Forms.DockStyle.Bottom
      Me._mousePositionLabel.Location = New System.Drawing.Point(0, 528)
      Me._mousePositionLabel.Name = "_mousePositionLabel"
      Me._mousePositionLabel.Size = New System.Drawing.Size(894, 13)
      Me._mousePositionLabel.TabIndex = 5
      '
      '_imageViewer
      '
      Me._imageViewer.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me._imageViewer.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me._imageViewer.Cursor = System.Windows.Forms.Cursors.Cross
      Me._imageViewer.Dock = System.Windows.Forms.DockStyle.Fill
      Me._imageViewer.ViewHorizontalAlignment = ControlAlignment.Center
      Me._imageViewer.Location = New System.Drawing.Point(0, 195)
      Me._imageViewer.Name = "_rasterImageViewer"
      Me._imageViewer.Size = New System.Drawing.Size(894, 333)
      Me._imageViewer.TabIndex = 3
      Me._imageViewer.UseDpi = True
      Me._imageViewer.ViewVerticalAlignment = ControlAlignment.Center
      'MainForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(894, 541)
      Me.Controls.Add(Me._imageViewer)
      Me.Controls.Add(Me._mousePositionLabel)
      Me.Controls.Add(Me._controlsPanel)
      Me.Controls.Add(Me._viewerToolStrip)
      Me.Controls.Add(Me._mainMenuStrip)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "MainForm"
      Me.Text = "MainForm"
      Me._mainMenuStrip.ResumeLayout(False)
      Me._mainMenuStrip.PerformLayout()
      Me._viewerToolStrip.ResumeLayout(False)
      Me._viewerToolStrip.PerformLayout()
      Me._controlsPanel.ResumeLayout(False)
      Me._controlsPanel.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents _mainMenuStrip As System.Windows.Forms.MenuStrip
   Private WithEvents _fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _fileOpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _fileSaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _fileSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _fileExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewZoomOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewZoomInToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _viewFitWidthToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewFitPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewSep2ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _viewHighlightRecognizedWordsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _wordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _wordUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _wordDeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _preferencesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _preferencesPdfResolutionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _preferencesUseCallbacksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _preferencesViewSavedDocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _helpAboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewerToolStrip As System.Windows.Forms.ToolStrip
   Private WithEvents _openToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _saveToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _viewerToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _zoomOutToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _zoomInToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _zoomToolStripComboBox As System.Windows.Forms.ToolStripComboBox
   Private WithEvents _fitPageWidthToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _fitPageToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _viewerToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _highlightWordsToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _updateWordToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _deleteWordToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _controlsPanel As System.Windows.Forms.Panel
   Private WithEvents _deleteButton As System.Windows.Forms.Button
   Private WithEvents _demoDescriptionLabel As System.Windows.Forms.Label
   Private WithEvents _updateButton As System.Windows.Forms.Button
   Private WithEvents _wordTextBox As System.Windows.Forms.TextBox
   Private WithEvents _mousePositionLabel As System.Windows.Forms.Label
   Private WithEvents _imageViewer As ImageViewer
End Class
