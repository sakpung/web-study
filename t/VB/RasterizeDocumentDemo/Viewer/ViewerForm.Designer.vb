<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewerForm
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewerForm))
      Me._mainMenuStrip = New System.Windows.Forms.MenuStrip
      Me._fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._filePrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._filePrintPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._filePrintSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._fileSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator
      Me._fileCloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewGotoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewGotoFirstPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewGotoPreviousPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewGotoNextPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewGotoLastPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewGotoPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator
      Me._viewZoomOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewZoomInToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewSep2ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator
      Me._viewFitWidthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewFitPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewUseDpiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewRulerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewRulerInchesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewRulerMillimetersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewSep3ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator
      Me._viewHighQualityPaintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._viewerControl = New RasterizeDocumentDemo.ViewerControl
      Me._mainMenuStrip.SuspendLayout()
      Me.SuspendLayout()
      '
      '_mainMenuStrip
      '
      Me._mainMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._fileToolStripMenuItem, Me._viewToolStripMenuItem})
      Me._mainMenuStrip.Location = New System.Drawing.Point(0, 0)
      Me._mainMenuStrip.Name = "_mainMenuStrip"
      Me._mainMenuStrip.Size = New System.Drawing.Size(585, 24)
      Me._mainMenuStrip.TabIndex = 1
      '
      '_fileToolStripMenuItem
      '
      Me._fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._filePrintToolStripMenuItem, Me._filePrintPreviewToolStripMenuItem, Me._filePrintSetupToolStripMenuItem, Me._fileSep1ToolStripMenuItem, Me._fileCloseToolStripMenuItem})
      Me._fileToolStripMenuItem.Name = "_fileToolStripMenuItem"
      Me._fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
      Me._fileToolStripMenuItem.Text = "&File"
      '
      '_filePrintToolStripMenuItem
      '
      Me._filePrintToolStripMenuItem.Name = "_filePrintToolStripMenuItem"
      Me._filePrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
      Me._filePrintToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me._filePrintToolStripMenuItem.Text = "&Print..."
      '
      '_filePrintPreviewToolStripMenuItem
      '
      Me._filePrintPreviewToolStripMenuItem.Name = "_filePrintPreviewToolStripMenuItem"
      Me._filePrintPreviewToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me._filePrintPreviewToolStripMenuItem.Text = "Print pre&view..."
      '
      '_filePrintSetupToolStripMenuItem
      '
      Me._filePrintSetupToolStripMenuItem.Name = "_filePrintSetupToolStripMenuItem"
      Me._filePrintSetupToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me._filePrintSetupToolStripMenuItem.Text = "Print set&up..."
      '
      '_fileSep1ToolStripMenuItem
      '
      Me._fileSep1ToolStripMenuItem.Name = "_fileSep1ToolStripMenuItem"
      Me._fileSep1ToolStripMenuItem.Size = New System.Drawing.Size(149, 6)
      '
      '_fileCloseToolStripMenuItem
      '
      Me._fileCloseToolStripMenuItem.Name = "_fileCloseToolStripMenuItem"
      Me._fileCloseToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me._fileCloseToolStripMenuItem.Text = "C&lose"
      '
      '_viewToolStripMenuItem
      '
      Me._viewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._viewGotoToolStripMenuItem, Me._viewSep1ToolStripMenuItem, Me._viewZoomOutToolStripMenuItem, Me._viewZoomInToolStripMenuItem, Me._viewSep2ToolStripMenuItem, Me._viewFitWidthToolStripMenuItem, Me._viewFitPageToolStripMenuItem, Me._viewUseDpiToolStripMenuItem, Me._viewRulerToolStripMenuItem, Me._viewSep3ToolStripMenuItem, Me._viewHighQualityPaintToolStripMenuItem})
      Me._viewToolStripMenuItem.Name = "_viewToolStripMenuItem"
      Me._viewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
      Me._viewToolStripMenuItem.Text = "&View"
      '
      '_viewGotoToolStripMenuItem
      '
      Me._viewGotoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._viewGotoFirstPageToolStripMenuItem, Me._viewGotoPreviousPageToolStripMenuItem, Me._viewGotoNextPageToolStripMenuItem, Me._viewGotoLastPageToolStripMenuItem, Me._viewGotoPageToolStripMenuItem})
      Me._viewGotoToolStripMenuItem.Name = "_viewGotoToolStripMenuItem"
      Me._viewGotoToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
      Me._viewGotoToolStripMenuItem.Text = "&Go to"
      '
      '_viewGotoFirstPageToolStripMenuItem
      '
      Me._viewGotoFirstPageToolStripMenuItem.Name = "_viewGotoFirstPageToolStripMenuItem"
      Me._viewGotoFirstPageToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
      Me._viewGotoFirstPageToolStripMenuItem.Text = "&First page"
      Me._viewGotoFirstPageToolStripMenuItem.ToolTipText = "Goto the first page in the document"
      '
      '_viewGotoPreviousPageToolStripMenuItem
      '
      Me._viewGotoPreviousPageToolStripMenuItem.Name = "_viewGotoPreviousPageToolStripMenuItem"
      Me._viewGotoPreviousPageToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
      Me._viewGotoPreviousPageToolStripMenuItem.Text = "P&revious page"
      Me._viewGotoPreviousPageToolStripMenuItem.ToolTipText = "Goto the previous page in the document"
      '
      '_viewGotoNextPageToolStripMenuItem
      '
      Me._viewGotoNextPageToolStripMenuItem.Name = "_viewGotoNextPageToolStripMenuItem"
      Me._viewGotoNextPageToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
      Me._viewGotoNextPageToolStripMenuItem.Text = "&Next page"
      Me._viewGotoNextPageToolStripMenuItem.ToolTipText = "Goto the next page in the document"
      '
      '_viewGotoLastPageToolStripMenuItem
      '
      Me._viewGotoLastPageToolStripMenuItem.Name = "_viewGotoLastPageToolStripMenuItem"
      Me._viewGotoLastPageToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
      Me._viewGotoLastPageToolStripMenuItem.Text = "&Last page"
      Me._viewGotoLastPageToolStripMenuItem.ToolTipText = "Goto the last page in the document"
      '
      '_viewGotoPageToolStripMenuItem
      '
      Me._viewGotoPageToolStripMenuItem.Name = "_viewGotoPageToolStripMenuItem"
      Me._viewGotoPageToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                  Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
      Me._viewGotoPageToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
      Me._viewGotoPageToolStripMenuItem.Text = "&Page..."
      Me._viewGotoPageToolStripMenuItem.ToolTipText = "Goto a specific page in the document"
      '
      '_viewSep1ToolStripMenuItem
      '
      Me._viewSep1ToolStripMenuItem.Name = "_viewSep1ToolStripMenuItem"
      Me._viewSep1ToolStripMenuItem.Size = New System.Drawing.Size(182, 6)
      '
      '_viewZoomOutToolStripMenuItem
      '
      Me._viewZoomOutToolStripMenuItem.Image = Global.RasterizeDocumentDemo.My.Resources.Resources.ZoomOut
      Me._viewZoomOutToolStripMenuItem.Name = "_viewZoomOutToolStripMenuItem"
      Me._viewZoomOutToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
      Me._viewZoomOutToolStripMenuItem.Text = "Zoom &out"
      Me._viewZoomOutToolStripMenuItem.ToolTipText = "Zoom out"
      '
      '_viewZoomInToolStripMenuItem
      '
      Me._viewZoomInToolStripMenuItem.Image = Global.RasterizeDocumentDemo.My.Resources.Resources.ZoomIn
      Me._viewZoomInToolStripMenuItem.Name = "_viewZoomInToolStripMenuItem"
      Me._viewZoomInToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
      Me._viewZoomInToolStripMenuItem.Text = "Zoom &in"
      Me._viewZoomInToolStripMenuItem.ToolTipText = "Zoom in"
      '
      '_viewSep2ToolStripMenuItem
      '
      Me._viewSep2ToolStripMenuItem.Name = "_viewSep2ToolStripMenuItem"
      Me._viewSep2ToolStripMenuItem.Size = New System.Drawing.Size(182, 6)
      '
      '_viewFitWidthToolStripMenuItem
      '
      Me._viewFitWidthToolStripMenuItem.Image = Global.RasterizeDocumentDemo.My.Resources.Resources.FitPageWidth
      Me._viewFitWidthToolStripMenuItem.Name = "_viewFitWidthToolStripMenuItem"
      Me._viewFitWidthToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
      Me._viewFitWidthToolStripMenuItem.Text = "Fit &width"
      Me._viewFitWidthToolStripMenuItem.ToolTipText = "Fit page width in window"
      '
      '_viewFitPageToolStripMenuItem
      '
      Me._viewFitPageToolStripMenuItem.Image = Global.RasterizeDocumentDemo.My.Resources.Resources.FitPage
      Me._viewFitPageToolStripMenuItem.Name = "_viewFitPageToolStripMenuItem"
      Me._viewFitPageToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
      Me._viewFitPageToolStripMenuItem.Text = "&Fit page"
      Me._viewFitPageToolStripMenuItem.ToolTipText = "Fit entire page in window"
      '
      '_viewUseDpiToolStripMenuItem
      '
      Me._viewUseDpiToolStripMenuItem.Image = Global.RasterizeDocumentDemo.My.Resources.Resources.UseDpi
      Me._viewUseDpiToolStripMenuItem.Name = "_viewUseDpiToolStripMenuItem"
      Me._viewUseDpiToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
      Me._viewUseDpiToolStripMenuItem.Text = "&Use image resolution"
      Me._viewUseDpiToolStripMenuItem.ToolTipText = "Use the image actual resolution instead of the screen when viewing"
      '
      '_viewRulerToolStripMenuItem
      '
      Me._viewRulerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._viewRulerInchesToolStripMenuItem, Me._viewRulerMillimetersToolStripMenuItem})
      Me._viewRulerToolStripMenuItem.Name = "_viewRulerToolStripMenuItem"
      Me._viewRulerToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
      Me._viewRulerToolStripMenuItem.Text = "&Ruler"
      '
      '_viewRulerInchesToolStripMenuItem
      '
      Me._viewRulerInchesToolStripMenuItem.Name = "_viewRulerInchesToolStripMenuItem"
      Me._viewRulerInchesToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me._viewRulerInchesToolStripMenuItem.Text = "&Inches"
      Me._viewRulerInchesToolStripMenuItem.ToolTipText = "Use inches unit on the ruler (English)"
      '
      '_viewRulerMillimetersToolStripMenuItem
      '
      Me._viewRulerMillimetersToolStripMenuItem.Name = "_viewRulerMillimetersToolStripMenuItem"
      Me._viewRulerMillimetersToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me._viewRulerMillimetersToolStripMenuItem.Text = "&Millimeters"
      Me._viewRulerMillimetersToolStripMenuItem.ToolTipText = "Use millimeters unit on the ruler (Metric)"
      '
      '_viewSep3ToolStripMenuItem
      '
      Me._viewSep3ToolStripMenuItem.Name = "_viewSep3ToolStripMenuItem"
      Me._viewSep3ToolStripMenuItem.Size = New System.Drawing.Size(182, 6)
      '
      '_viewHighQualityPaintToolStripMenuItem
      '
      Me._viewHighQualityPaintToolStripMenuItem.Name = "_viewHighQualityPaintToolStripMenuItem"
      Me._viewHighQualityPaintToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
      Me._viewHighQualityPaintToolStripMenuItem.Text = "&High quality paint"
      '
      '_viewerControl
      '
      Me._viewerControl.Dock = System.Windows.Forms.DockStyle.Fill
      Me._viewerControl.Location = New System.Drawing.Point(0, 24)
      Me._viewerControl.Name = "_viewerControl"
      Me._viewerControl.Size = New System.Drawing.Size(585, 536)
      Me._viewerControl.TabIndex = 2
      '
      'ViewerForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(585, 560)
      Me.Controls.Add(Me._viewerControl)
      Me.Controls.Add(Me._mainMenuStrip)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ViewerForm"
      Me.Text = "ViewerForm"
      Me._mainMenuStrip.ResumeLayout(False)
      Me._mainMenuStrip.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents _mainMenuStrip As System.Windows.Forms.MenuStrip
   Private WithEvents _fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _filePrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _filePrintPreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _filePrintSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _fileSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _fileCloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewGotoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewGotoFirstPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewGotoPreviousPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewGotoNextPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewGotoLastPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewGotoPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _viewZoomOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewZoomInToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewSep2ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _viewFitWidthToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewFitPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewUseDpiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewRulerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewRulerInchesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewRulerMillimetersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewSep3ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _viewHighQualityPaintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents _viewerControl As RasterizeDocumentDemo.ViewerControl
End Class
