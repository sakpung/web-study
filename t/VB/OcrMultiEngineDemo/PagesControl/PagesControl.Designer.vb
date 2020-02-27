Imports Leadtools.Controls

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PagesControl
   Inherits System.Windows.Forms.UserControl

   'UserControl overrides dispose to clean up the component list.
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
      Dim _imageViewerVerticalViewLayout As ImageViewerVerticalViewLayout = New ImageViewerVerticalViewLayout()
      _imageViewerVerticalViewLayout.Columns = 1
      Me._titleLabel = New System.Windows.Forms.Label
      Me._toolStrip = New System.Windows.Forms.ToolStrip
      Me._insertPageToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._deleteCurrentPageToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._movePageUpToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._movePageDownToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._rasterImageList = New ImageViewer(_imageViewerVerticalViewLayout)
      Me._toolStrip.SuspendLayout()
      Me.SuspendLayout()
      '
      '_titleLabel
      '
      Me._titleLabel.Dock = System.Windows.Forms.DockStyle.Top
      Me._titleLabel.Location = New System.Drawing.Point(0, 0)
      Me._titleLabel.Name = "_titleLabel"
      Me._titleLabel.Size = New System.Drawing.Size(197, 13)
      Me._titleLabel.TabIndex = 0
      Me._titleLabel.Text = "Pages"
      Me._titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_toolStrip
      '
      Me._toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._insertPageToolStripButton, Me._deleteCurrentPageToolStripButton, Me._movePageUpToolStripButton, Me._movePageDownToolStripButton})
      Me._toolStrip.Location = New System.Drawing.Point(0, 13)
      Me._toolStrip.Name = "_toolStrip"
      Me._toolStrip.Size = New System.Drawing.Size(197, 25)
      Me._toolStrip.TabIndex = 1
      '
      '_insertPageToolStripButton
      '
      Me._insertPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._insertPageToolStripButton.Image = Global.OcrMultiEngineDemo.My.Resources.Resources.OpenDocument
      Me._insertPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._insertPageToolStripButton.Name = "_insertPageToolStripButton"
      Me._insertPageToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._insertPageToolStripButton.ToolTipText = "Insert page or pages to the document from a disk file"
      '
      '_deleteCurrentPageToolStripButton
      '
      Me._deleteCurrentPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._deleteCurrentPageToolStripButton.Image = Global.OcrMultiEngineDemo.My.Resources.Resources.DeletePage
      Me._deleteCurrentPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._deleteCurrentPageToolStripButton.Name = "_deleteCurrentPageToolStripButton"
      Me._deleteCurrentPageToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._deleteCurrentPageToolStripButton.ToolTipText = "Delete current page"
      '
      '_movePageUpToolStripButton
      '
      Me._movePageUpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._movePageUpToolStripButton.Image = Global.OcrMultiEngineDemo.My.Resources.Resources.MovePageUp
      Me._movePageUpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._movePageUpToolStripButton.Name = "_movePageUpToolStripButton"
      Me._movePageUpToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._movePageUpToolStripButton.ToolTipText = "Move current page up in the document"
      '
      '_movePageDownToolStripButton
      '
      Me._movePageDownToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._movePageDownToolStripButton.Image = Global.OcrMultiEngineDemo.My.Resources.Resources.MovePageDown
      Me._movePageDownToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._movePageDownToolStripButton.Name = "_movePageDownToolStripButton"
      Me._movePageDownToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._movePageDownToolStripButton.ToolTipText = "Move current page down in the document"
      '
      '_rasterImageList
      '
      Me._rasterImageList.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me._rasterImageList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._rasterImageList.ItemSizeMode = ControlSizeMode.Fit
      Me._rasterImageList.SelectedItemBorderColor = System.Drawing.Color.Blue
      Me._rasterImageList.Dock = System.Windows.Forms.DockStyle.Left
      Me._rasterImageList.Location = New System.Drawing.Point(0, 93)
      Me._rasterImageList.Size = New System.Drawing.Size(197, 475)
      Me._rasterImageList.ViewHorizontalAlignment = ControlAlignment.Center
      Me._rasterImageList.Name = "_ImageList"
      Me._rasterImageList.UseDpi = True
      Me._rasterImageList.ItemBorderThickness = 2
      Me._rasterImageList.SelectedItemBorderColor = System.Drawing.Color.Blue
      Dim _imageViewerSelectItemsInteractiveMode As ImageViewerSelectItemsInteractiveMode = New ImageViewerSelectItemsInteractiveMode()
      _imageViewerSelectItemsInteractiveMode.SelectionMode = ImageViewerSelectionMode.Single
      Me._rasterImageList.InteractiveModes.Add(_imageViewerSelectItemsInteractiveMode)
      '
      'PagesControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._rasterImageList)
      Me.Controls.Add(Me._toolStrip)
      Me.Controls.Add(Me._titleLabel)
      Me.Name = "PagesControl"
      Me.Size = New System.Drawing.Size(197, 364)
      Me._toolStrip.ResumeLayout(False)
      Me._toolStrip.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents _titleLabel As System.Windows.Forms.Label
   Private WithEvents _toolStrip As System.Windows.Forms.ToolStrip
   Private WithEvents _insertPageToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _deleteCurrentPageToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _movePageUpToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _movePageDownToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _rasterImageList As ImageViewer

End Class
