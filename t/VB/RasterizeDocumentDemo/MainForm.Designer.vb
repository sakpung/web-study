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
      Me._fileExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._helpAboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._optionsTabControl = New System.Windows.Forms.TabControl
      Me._rasterizeDocumentOptionsTabPage = New System.Windows.Forms.TabPage
      Me._rasterizeDocumentOptionsControl = New RasterizeDocumentDemo.RasterizeDocumentOptionsControl
      Me._pdfOptionsTabPage = New System.Windows.Forms.TabPage
      Me._pdfOptionsControl = New RasterizeDocumentDemo.PdfOptionsControl
      Me._xpsOptionsTabPage = New System.Windows.Forms.TabPage
      Me._xpsOptionsControl = New RasterizeDocumentDemo.XpsOptionsControl
      Me._xlsOptionsTabPage = New System.Windows.Forms.TabPage
      Me._xlsOptionsControl = New RasterizeDocumentDemo.XlsOptionsControl
      Me._rtfOptionsTabPage = New System.Windows.Forms.TabPage
      Me._rtfOptionsControl = New RasterizeDocumentDemo.RtfOptionsControl
      Me._txtOptionsTabPage = New System.Windows.Forms.TabPage
      Me._txtOptionsControl = New RasterizeDocumentDemo.TxtOptionsControl
      Me._documentPathControl = New RasterizeDocumentDemo.DocumentPathControl
      Me._documentInfoControl = New RasterizeDocumentDemo.DocumentInfoControl
      Me._loadDocumentInViewerButton = New System.Windows.Forms.Button
      Me._getDocumentInformationButton = New System.Windows.Forms.Button
      Me._docOptionsTabPage = New System.Windows.Forms.TabPage
      Me._docOptionsControl = New RasterizeDocumentDemo.DocOptionsControl
      Me._mainMenuStrip.SuspendLayout()
      Me._optionsTabControl.SuspendLayout()
      Me._rasterizeDocumentOptionsTabPage.SuspendLayout()
      Me._pdfOptionsTabPage.SuspendLayout()
      Me._xpsOptionsTabPage.SuspendLayout()
      Me._xlsOptionsTabPage.SuspendLayout()
      Me._rtfOptionsTabPage.SuspendLayout()
      Me._txtOptionsTabPage.SuspendLayout()
      Me.SuspendLayout()
      '
      '_mainMenuStrip
      '
      Me._mainMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._fileToolStripMenuItem, Me._helpToolStripMenuItem})
      Me._mainMenuStrip.Location = New System.Drawing.Point(0, 0)
      Me._mainMenuStrip.Name = "_mainMenuStrip"
      Me._mainMenuStrip.Size = New System.Drawing.Size(741, 24)
      Me._mainMenuStrip.TabIndex = 1
      '
      '_fileToolStripMenuItem
      '
      Me._fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._fileExitToolStripMenuItem})
      Me._fileToolStripMenuItem.Name = "_fileToolStripMenuItem"
      Me._fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
      Me._fileToolStripMenuItem.Text = "&File"
      '
      '_fileExitToolStripMenuItem
      '
      Me._fileExitToolStripMenuItem.Name = "_fileExitToolStripMenuItem"
      Me._fileExitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
      Me._fileExitToolStripMenuItem.Text = "E&xit"
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
      '_optionsTabControl
      '
      Me._optionsTabControl.Controls.Add(Me._rasterizeDocumentOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._pdfOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._xpsOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._xlsOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._rtfOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._txtOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._docOptionsTabPage)
      Me._optionsTabControl.Location = New System.Drawing.Point(13, 28)
      Me._optionsTabControl.Name = "_optionsTabControl"
      Me._optionsTabControl.SelectedIndex = 0
      Me._optionsTabControl.Size = New System.Drawing.Size(520, 270)
      Me._optionsTabControl.TabIndex = 2
      '
      '_rasterizeDocumentOptionsTabPage
      '
      Me._rasterizeDocumentOptionsTabPage.Controls.Add(Me._rasterizeDocumentOptionsControl)
      Me._rasterizeDocumentOptionsTabPage.Location = New System.Drawing.Point(4, 22)
      Me._rasterizeDocumentOptionsTabPage.Name = "_rasterizeDocumentOptionsTabPage"
      Me._rasterizeDocumentOptionsTabPage.Padding = New System.Windows.Forms.Padding(3)
      Me._rasterizeDocumentOptionsTabPage.Size = New System.Drawing.Size(512, 244)
      Me._rasterizeDocumentOptionsTabPage.TabIndex = 0
      Me._rasterizeDocumentOptionsTabPage.Text = "Rasterize Document"
      Me._rasterizeDocumentOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_rasterizeDocumentOptionsControl
      '
      Me._rasterizeDocumentOptionsControl.Location = New System.Drawing.Point(8, 8)
      Me._rasterizeDocumentOptionsControl.Name = "_rasterizeDocumentOptionsControl"
      Me._rasterizeDocumentOptionsControl.Size = New System.Drawing.Size(500, 230)
      Me._rasterizeDocumentOptionsControl.TabIndex = 0
      '
      '_pdfOptionsTabPage
      '
      Me._pdfOptionsTabPage.Controls.Add(Me._pdfOptionsControl)
      Me._pdfOptionsTabPage.Location = New System.Drawing.Point(4, 22)
      Me._pdfOptionsTabPage.Name = "_pdfOptionsTabPage"
      Me._pdfOptionsTabPage.Padding = New System.Windows.Forms.Padding(3)
      Me._pdfOptionsTabPage.Size = New System.Drawing.Size(512, 244)
      Me._pdfOptionsTabPage.TabIndex = 1
      Me._pdfOptionsTabPage.Text = "PDF"
      Me._pdfOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_pdfOptionsControl
      '
      Me._pdfOptionsControl.Location = New System.Drawing.Point(8, 8)
      Me._pdfOptionsControl.Name = "_pdfOptionsControl"
      Me._pdfOptionsControl.Size = New System.Drawing.Size(500, 230)
      Me._pdfOptionsControl.TabIndex = 0
      '
      '_xpsOptionsTabPage
      '
      Me._xpsOptionsTabPage.Controls.Add(Me._xpsOptionsControl)
      Me._xpsOptionsTabPage.Location = New System.Drawing.Point(4, 22)
      Me._xpsOptionsTabPage.Name = "_xpsOptionsTabPage"
      Me._xpsOptionsTabPage.Size = New System.Drawing.Size(512, 244)
      Me._xpsOptionsTabPage.TabIndex = 2
      Me._xpsOptionsTabPage.Text = "XPS"
      Me._xpsOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_xpsOptionsControl
      '
      Me._xpsOptionsControl.Location = New System.Drawing.Point(8, 8)
      Me._xpsOptionsControl.Name = "_xpsOptionsControl"
      Me._xpsOptionsControl.Size = New System.Drawing.Size(500, 230)
      Me._xpsOptionsControl.TabIndex = 0
      '
      '_xlsOptionsTabPage
      '
      Me._xlsOptionsTabPage.Controls.Add(Me._xlsOptionsControl)
      Me._xlsOptionsTabPage.Location = New System.Drawing.Point(4, 22)
      Me._xlsOptionsTabPage.Name = "_xlsOptionsTabPage"
      Me._xlsOptionsTabPage.Size = New System.Drawing.Size(512, 244)
      Me._xlsOptionsTabPage.TabIndex = 3
      Me._xlsOptionsTabPage.Text = "XLS"
      Me._xlsOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_xlsOptionsControl
      '
      Me._xlsOptionsControl.Location = New System.Drawing.Point(8, 8)
      Me._xlsOptionsControl.Name = "_xlsOptionsControl"
      Me._xlsOptionsControl.Size = New System.Drawing.Size(500, 230)
      Me._xlsOptionsControl.TabIndex = 0
      '
      '_rtfOptionsTabPage
      '
      Me._rtfOptionsTabPage.Controls.Add(Me._rtfOptionsControl)
      Me._rtfOptionsTabPage.Location = New System.Drawing.Point(4, 22)
      Me._rtfOptionsTabPage.Name = "_rtfOptionsTabPage"
      Me._rtfOptionsTabPage.Size = New System.Drawing.Size(512, 244)
      Me._rtfOptionsTabPage.TabIndex = 4
      Me._rtfOptionsTabPage.Text = "RTF"
      Me._rtfOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_rtfOptionsControl
      '
      Me._rtfOptionsControl.Location = New System.Drawing.Point(8, 8)
      Me._rtfOptionsControl.Name = "_rtfOptionsControl"
      Me._rtfOptionsControl.Size = New System.Drawing.Size(500, 230)
      Me._rtfOptionsControl.TabIndex = 0
      '
      '_txtOptionsTabPage
      '
      Me._txtOptionsTabPage.Controls.Add(Me._txtOptionsControl)
      Me._txtOptionsTabPage.Location = New System.Drawing.Point(4, 22)
      Me._txtOptionsTabPage.Name = "_txtOptionsTabPage"
      Me._txtOptionsTabPage.Size = New System.Drawing.Size(512, 244)
      Me._txtOptionsTabPage.TabIndex = 5
      Me._txtOptionsTabPage.Text = "TXT"
      Me._txtOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_txtOptionsControl
      '
      Me._txtOptionsControl.Location = New System.Drawing.Point(8, 8)
      Me._txtOptionsControl.Name = "_txtOptionsControl"
      Me._txtOptionsControl.Size = New System.Drawing.Size(500, 230)
      Me._txtOptionsControl.TabIndex = 0
      '
      '_documentPathControl
      '
      Me._documentPathControl.Location = New System.Drawing.Point(12, 304)
      Me._documentPathControl.Name = "_documentPathControl"
      Me._documentPathControl.Size = New System.Drawing.Size(520, 70)
      Me._documentPathControl.TabIndex = 3
      '
      '_documentInfoControl
      '
      Me._documentInfoControl.Location = New System.Drawing.Point(9, 380)
      Me._documentInfoControl.Name = "_documentInfoControl"
      Me._documentInfoControl.Size = New System.Drawing.Size(520, 200)
      Me._documentInfoControl.TabIndex = 4
      '
      '_loadDocumentInViewerButton
      '
      Me._loadDocumentInViewerButton.Location = New System.Drawing.Point(548, 409)
      Me._loadDocumentInViewerButton.Name = "_loadDocumentInViewerButton"
      Me._loadDocumentInViewerButton.Size = New System.Drawing.Size(181, 23)
      Me._loadDocumentInViewerButton.TabIndex = 7
      Me._loadDocumentInViewerButton.Text = "&Load document in the viewer"
      Me._loadDocumentInViewerButton.UseVisualStyleBackColor = True
      '
      '_getDocumentInformationButton
      '
      Me._getDocumentInformationButton.Location = New System.Drawing.Point(548, 380)
      Me._getDocumentInformationButton.Name = "_getDocumentInformationButton"
      Me._getDocumentInformationButton.Size = New System.Drawing.Size(181, 23)
      Me._getDocumentInformationButton.TabIndex = 6
      Me._getDocumentInformationButton.Text = "Get document &information"
      Me._getDocumentInformationButton.UseVisualStyleBackColor = True
      '
      '_docOptionsTabPage
      '
      Me._docOptionsTabPage.Controls.Add(Me._docOptionsControl)
      Me._docOptionsTabPage.Location = New System.Drawing.Point(4, 22)
      Me._docOptionsTabPage.Name = "_docOptionsTabPage"
      Me._docOptionsTabPage.Size = New System.Drawing.Size(512, 244)
      Me._docOptionsTabPage.TabIndex = 6
      Me._docOptionsTabPage.Text = "DOC / DOCX"
      Me._docOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_docOptionsControl
      '
      Me._docOptionsControl.Location = New System.Drawing.Point(8, 8)
      Me._docOptionsControl.Name = "_txtOptionsControl"
      Me._docOptionsControl.Size = New System.Drawing.Size(500, 230)
      Me._docOptionsControl.TabIndex = 0
      '
      'MainForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(741, 590)
      Me.Controls.Add(Me._loadDocumentInViewerButton)
      Me.Controls.Add(Me._getDocumentInformationButton)
      Me.Controls.Add(Me._documentInfoControl)
      Me.Controls.Add(Me._documentPathControl)
      Me.Controls.Add(Me._optionsTabControl)
      Me.Controls.Add(Me._mainMenuStrip)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "MainForm"
      Me.Text = "MainForm"
      Me._mainMenuStrip.ResumeLayout(False)
      Me._mainMenuStrip.PerformLayout()
      Me._optionsTabControl.ResumeLayout(False)
      Me._rasterizeDocumentOptionsTabPage.ResumeLayout(False)
      Me._pdfOptionsTabPage.ResumeLayout(False)
      Me._xpsOptionsTabPage.ResumeLayout(False)
      Me._xlsOptionsTabPage.ResumeLayout(False)
      Me._rtfOptionsTabPage.ResumeLayout(False)
      Me._txtOptionsTabPage.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents _mainMenuStrip As System.Windows.Forms.MenuStrip
   Private WithEvents _fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _fileExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _helpAboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents _optionsTabControl As System.Windows.Forms.TabControl
   Friend WithEvents _rasterizeDocumentOptionsTabPage As System.Windows.Forms.TabPage
   Friend WithEvents _pdfOptionsTabPage As System.Windows.Forms.TabPage
   Friend WithEvents _documentPathControl As RasterizeDocumentDemo.DocumentPathControl
   Friend WithEvents _documentInfoControl As RasterizeDocumentDemo.DocumentInfoControl
   Private WithEvents _loadDocumentInViewerButton As System.Windows.Forms.Button
   Private WithEvents _getDocumentInformationButton As System.Windows.Forms.Button
   Friend WithEvents _xpsOptionsTabPage As System.Windows.Forms.TabPage
   Friend WithEvents _xlsOptionsTabPage As System.Windows.Forms.TabPage
   Friend WithEvents _rtfOptionsTabPage As System.Windows.Forms.TabPage
   Friend WithEvents _txtOptionsTabPage As System.Windows.Forms.TabPage
   Friend WithEvents _rasterizeDocumentOptionsControl As RasterizeDocumentDemo.RasterizeDocumentOptionsControl
   Friend WithEvents _pdfOptionsControl As RasterizeDocumentDemo.PdfOptionsControl
   Friend WithEvents _xpsOptionsControl As RasterizeDocumentDemo.XpsOptionsControl
   Friend WithEvents _xlsOptionsControl As RasterizeDocumentDemo.XlsOptionsControl
   Friend WithEvents _rtfOptionsControl As RasterizeDocumentDemo.RtfOptionsControl
   Friend WithEvents _txtOptionsControl As RasterizeDocumentDemo.TxtOptionsControl
   Friend WithEvents _docOptionsControl As RasterizeDocumentDemo.DocOptionsControl
   Friend WithEvents _docOptionsTabPage As System.Windows.Forms.TabPage

End Class
