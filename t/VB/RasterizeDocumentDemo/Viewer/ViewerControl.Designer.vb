Imports Leadtools
Imports Leadtools.Controls

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewerControl
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
      Me._imageInfoPanel = New System.Windows.Forms.Panel
      Me._imageInfoTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel
      Me._imageInfoFileSizeLabel = New System.Windows.Forms.Label
      Me._imageInfoFileSizeValueLabel = New System.Windows.Forms.Label
      Me.Panel1 = New System.Windows.Forms.Panel
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
      Me.Label1 = New System.Windows.Forms.Label
      Me.Label2 = New System.Windows.Forms.Label
      Me._imageInfoMemorySizeValueLabel = New System.Windows.Forms.Label
      Me._imageInfoBitsPerPixelValueLabel = New System.Windows.Forms.Label
      Me._imageInfoPageSizeLabel = New System.Windows.Forms.Label
      Me._imageInfoPageSizeLogicalLabel = New System.Windows.Forms.Label
      Me._imageInfoPageSizePixelsLabel = New System.Windows.Forms.Label
      Me._imageInfoPageSizeResolutionLabel = New System.Windows.Forms.Label
      Me._imageInfoMemorySizeLabel = New System.Windows.Forms.Label
      Me._imageInfoBitsPerPixelLabel = New System.Windows.Forms.Label
      Me._toolStrip = New System.Windows.Forms.ToolStrip
      Me._previousPageToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._nextPageToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._pageToolStripTextBox = New System.Windows.Forms.ToolStripTextBox
      Me._pageToolStripLabel = New System.Windows.Forms.ToolStripLabel
      Me._toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
      Me._zoomOutToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._zoomInToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._zoomToolStripComboBox = New System.Windows.Forms.ToolStripComboBox
      Me._fitPageWidthToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._fitPageToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._useDpiToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
      Me._panModeToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._zoomToSelectionModeToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._imageList = New ImageViewer(New ImageViewerVerticalViewLayout() With { _
 .Columns = 1 _
})
      Me._imageViewer = New ImageViewer()
      Me._mousePositionLabel = New System.Windows.Forms.Label
      Me._imageInfoTableLayoutPanel.SuspendLayout()
      Me.Panel1.SuspendLayout()
      Me.TableLayoutPanel1.SuspendLayout()
      Me._toolStrip.SuspendLayout()
      Me.SuspendLayout()
      '
      '_imageInfoPanel
      '
      Me._imageInfoPanel.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me._imageInfoPanel.Location = New System.Drawing.Point(0, 0)
      Me._imageInfoPanel.Name = "_imageInfoPanel"
      Me._imageInfoPanel.Size = New System.Drawing.Size(200, 100)
      Me._imageInfoPanel.TabIndex = 0
      '
      '_imageInfoTableLayoutPanel
      '
      Me._imageInfoTableLayoutPanel.ColumnCount = 4
      Me._imageInfoTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
      Me._imageInfoTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
      Me._imageInfoTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
      Me._imageInfoTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186.0!))
      Me._imageInfoTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me._imageInfoTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me._imageInfoTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me._imageInfoTableLayoutPanel.Controls.Add(Me._imageInfoFileSizeLabel, 0, 0)
      Me._imageInfoTableLayoutPanel.Location = New System.Drawing.Point(0, 0)
      Me._imageInfoTableLayoutPanel.Name = "_imageInfoTableLayoutPanel"
      Me._imageInfoTableLayoutPanel.RowCount = 1
      Me._imageInfoTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me._imageInfoTableLayoutPanel.Size = New System.Drawing.Size(200, 100)
      Me._imageInfoTableLayoutPanel.TabIndex = 0
      '
      '_imageInfoFileSizeLabel
      '
      Me._imageInfoFileSizeLabel.Dock = System.Windows.Forms.DockStyle.Fill
      Me._imageInfoFileSizeLabel.Location = New System.Drawing.Point(3, 0)
      Me._imageInfoFileSizeLabel.Name = "_imageInfoFileSizeLabel"
      Me._imageInfoFileSizeLabel.Size = New System.Drawing.Size(74, 100)
      Me._imageInfoFileSizeLabel.TabIndex = 0
      Me._imageInfoFileSizeLabel.Text = "File size:"
      Me._imageInfoFileSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_imageInfoFileSizeValueLabel
      '
      Me._imageInfoFileSizeValueLabel.Dock = System.Windows.Forms.DockStyle.Fill
      Me._imageInfoFileSizeValueLabel.Location = New System.Drawing.Point(83, 0)
      Me._imageInfoFileSizeValueLabel.Name = "_imageInfoFileSizeValueLabel"
      Me._imageInfoFileSizeValueLabel.Size = New System.Drawing.Size(194, 20)
      Me._imageInfoFileSizeValueLabel.TabIndex = 1
      Me._imageInfoFileSizeValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(850, 68)
      Me.Panel1.TabIndex = 8
      '
      'TableLayoutPanel1
      '
      Me.TableLayoutPanel1.ColumnCount = 4
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186.0!))
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 0)
      Me.TableLayoutPanel1.Controls.Add(Me._imageInfoMemorySizeValueLabel, 1, 1)
      Me.TableLayoutPanel1.Controls.Add(Me._imageInfoBitsPerPixelValueLabel, 1, 2)
      Me.TableLayoutPanel1.Controls.Add(Me._imageInfoPageSizeLabel, 2, 0)
      Me.TableLayoutPanel1.Controls.Add(Me._imageInfoPageSizeLogicalLabel, 3, 0)
      Me.TableLayoutPanel1.Controls.Add(Me._imageInfoPageSizePixelsLabel, 3, 1)
      Me.TableLayoutPanel1.Controls.Add(Me._imageInfoPageSizeResolutionLabel, 3, 2)
      Me.TableLayoutPanel1.Controls.Add(Me._imageInfoMemorySizeLabel, 0, 1)
      Me.TableLayoutPanel1.Controls.Add(Me._imageInfoBitsPerPixelLabel, 0, 2)
      Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
      Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
      Me.TableLayoutPanel1.RowCount = 4
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.TableLayoutPanel1.Size = New System.Drawing.Size(546, 60)
      Me.TableLayoutPanel1.TabIndex = 7
      '
      'Label1
      '
      Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Label1.Location = New System.Drawing.Point(3, 0)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(74, 20)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "File size:"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label2
      '
      Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Label2.Location = New System.Drawing.Point(83, 0)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(194, 20)
      Me.Label2.TabIndex = 1
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_imageInfoMemorySizeValueLabel
      '
      Me._imageInfoMemorySizeValueLabel.Dock = System.Windows.Forms.DockStyle.Fill
      Me._imageInfoMemorySizeValueLabel.Location = New System.Drawing.Point(83, 20)
      Me._imageInfoMemorySizeValueLabel.Name = "_imageInfoMemorySizeValueLabel"
      Me._imageInfoMemorySizeValueLabel.Size = New System.Drawing.Size(194, 20)
      Me._imageInfoMemorySizeValueLabel.TabIndex = 3
      Me._imageInfoMemorySizeValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_imageInfoBitsPerPixelValueLabel
      '
      Me._imageInfoBitsPerPixelValueLabel.Dock = System.Windows.Forms.DockStyle.Fill
      Me._imageInfoBitsPerPixelValueLabel.Location = New System.Drawing.Point(83, 40)
      Me._imageInfoBitsPerPixelValueLabel.Name = "_imageInfoBitsPerPixelValueLabel"
      Me._imageInfoBitsPerPixelValueLabel.Size = New System.Drawing.Size(194, 20)
      Me._imageInfoBitsPerPixelValueLabel.TabIndex = 5
      Me._imageInfoBitsPerPixelValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_imageInfoPageSizeLabel
      '
      Me._imageInfoPageSizeLabel.Dock = System.Windows.Forms.DockStyle.Fill
      Me._imageInfoPageSizeLabel.Location = New System.Drawing.Point(283, 0)
      Me._imageInfoPageSizeLabel.Name = "_imageInfoPageSizeLabel"
      Me._imageInfoPageSizeLabel.Size = New System.Drawing.Size(74, 20)
      Me._imageInfoPageSizeLabel.TabIndex = 6
      Me._imageInfoPageSizeLabel.Text = "Page size:"
      Me._imageInfoPageSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_imageInfoPageSizeLogicalLabel
      '
      Me._imageInfoPageSizeLogicalLabel.Dock = System.Windows.Forms.DockStyle.Fill
      Me._imageInfoPageSizeLogicalLabel.Location = New System.Drawing.Point(363, 0)
      Me._imageInfoPageSizeLogicalLabel.Name = "_imageInfoPageSizeLogicalLabel"
      Me._imageInfoPageSizeLogicalLabel.Size = New System.Drawing.Size(180, 20)
      Me._imageInfoPageSizeLogicalLabel.TabIndex = 7
      Me._imageInfoPageSizeLogicalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_imageInfoPageSizePixelsLabel
      '
      Me._imageInfoPageSizePixelsLabel.Dock = System.Windows.Forms.DockStyle.Fill
      Me._imageInfoPageSizePixelsLabel.Location = New System.Drawing.Point(363, 20)
      Me._imageInfoPageSizePixelsLabel.Name = "_imageInfoPageSizePixelsLabel"
      Me._imageInfoPageSizePixelsLabel.Size = New System.Drawing.Size(180, 20)
      Me._imageInfoPageSizePixelsLabel.TabIndex = 8
      Me._imageInfoPageSizePixelsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_imageInfoPageSizeResolutionLabel
      '
      Me._imageInfoPageSizeResolutionLabel.Dock = System.Windows.Forms.DockStyle.Fill
      Me._imageInfoPageSizeResolutionLabel.Location = New System.Drawing.Point(363, 40)
      Me._imageInfoPageSizeResolutionLabel.Name = "_imageInfoPageSizeResolutionLabel"
      Me._imageInfoPageSizeResolutionLabel.Size = New System.Drawing.Size(180, 20)
      Me._imageInfoPageSizeResolutionLabel.TabIndex = 9
      Me._imageInfoPageSizeResolutionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_imageInfoMemorySizeLabel
      '
      Me._imageInfoMemorySizeLabel.AutoSize = True
      Me._imageInfoMemorySizeLabel.Dock = System.Windows.Forms.DockStyle.Fill
      Me._imageInfoMemorySizeLabel.Location = New System.Drawing.Point(3, 20)
      Me._imageInfoMemorySizeLabel.Name = "_imageInfoMemorySizeLabel"
      Me._imageInfoMemorySizeLabel.Size = New System.Drawing.Size(74, 20)
      Me._imageInfoMemorySizeLabel.TabIndex = 10
      Me._imageInfoMemorySizeLabel.Text = "Memory size:"
      Me._imageInfoMemorySizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_imageInfoBitsPerPixelLabel
      '
      Me._imageInfoBitsPerPixelLabel.AutoSize = True
      Me._imageInfoBitsPerPixelLabel.Dock = System.Windows.Forms.DockStyle.Fill
      Me._imageInfoBitsPerPixelLabel.Location = New System.Drawing.Point(3, 40)
      Me._imageInfoBitsPerPixelLabel.Name = "_imageInfoBitsPerPixelLabel"
      Me._imageInfoBitsPerPixelLabel.Size = New System.Drawing.Size(74, 20)
      Me._imageInfoBitsPerPixelLabel.TabIndex = 11
      Me._imageInfoBitsPerPixelLabel.Text = "Bits per pixel:"
      Me._imageInfoBitsPerPixelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      '_toolStrip
      '
      Me._toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._previousPageToolStripButton, Me._nextPageToolStripButton, Me._pageToolStripTextBox, Me._pageToolStripLabel, Me._toolStripSeparator1, Me._zoomOutToolStripButton, Me._zoomInToolStripButton, Me._zoomToolStripComboBox, Me._fitPageWidthToolStripButton, Me._fitPageToolStripButton, Me._useDpiToolStripButton, Me._toolStripSeparator2, Me._panModeToolStripButton, Me._zoomToSelectionModeToolStripButton})
      Me._toolStrip.Location = New System.Drawing.Point(0, 68)
      Me._toolStrip.Name = "_toolStrip"
      Me._toolStrip.Size = New System.Drawing.Size(850, 25)
      Me._toolStrip.TabIndex = 9
      '
      '_previousPageToolStripButton
      '
      Me._previousPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._previousPageToolStripButton.Image = Global.RasterizeDocumentDemo.My.Resources.Resources.PreviousPage
      Me._previousPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._previousPageToolStripButton.Name = "_previousPageToolStripButton"
      Me._previousPageToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._previousPageToolStripButton.ToolTipText = "Go to previous page in the document"
      '
      '_nextPageToolStripButton
      '
      Me._nextPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._nextPageToolStripButton.Image = Global.RasterizeDocumentDemo.My.Resources.Resources.NextPage
      Me._nextPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._nextPageToolStripButton.Name = "_nextPageToolStripButton"
      Me._nextPageToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._nextPageToolStripButton.ToolTipText = "Go to next page in the document"
      '
      '_pageToolStripTextBox
      '
      Me._pageToolStripTextBox.Name = "_pageToolStripTextBox"
      Me._pageToolStripTextBox.Size = New System.Drawing.Size(40, 25)
      Me._pageToolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me._pageToolStripTextBox.ToolTipText = "Current page number in the document"
      '
      '_pageToolStripLabel
      '
      Me._pageToolStripLabel.Name = "_pageToolStripLabel"
      Me._pageToolStripLabel.Size = New System.Drawing.Size(48, 22)
      Me._pageToolStripLabel.Text = "/ WWW"
      '
      '_toolStripSeparator1
      '
      Me._toolStripSeparator1.Name = "_toolStripSeparator1"
      Me._toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
      '
      '_zoomOutToolStripButton
      '
      Me._zoomOutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._zoomOutToolStripButton.Image = Global.RasterizeDocumentDemo.My.Resources.Resources.ZoomOut
      Me._zoomOutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._zoomOutToolStripButton.Name = "_zoomOutToolStripButton"
      Me._zoomOutToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._zoomOutToolStripButton.ToolTipText = "Zoom out"
      '
      '_zoomInToolStripButton
      '
      Me._zoomInToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._zoomInToolStripButton.Image = Global.RasterizeDocumentDemo.My.Resources.Resources.ZoomIn
      Me._zoomInToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._zoomInToolStripButton.Name = "_zoomInToolStripButton"
      Me._zoomInToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._zoomInToolStripButton.ToolTipText = "Zoom In"
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
      Me._fitPageWidthToolStripButton.Image = Global.RasterizeDocumentDemo.My.Resources.Resources.FitPageWidth
      Me._fitPageWidthToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._fitPageWidthToolStripButton.Name = "_fitPageWidthToolStripButton"
      Me._fitPageWidthToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._fitPageWidthToolStripButton.ToolTipText = "Fit page width in window"
      '
      '_fitPageToolStripButton
      '
      Me._fitPageToolStripButton.CheckOnClick = True
      Me._fitPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._fitPageToolStripButton.Image = Global.RasterizeDocumentDemo.My.Resources.Resources.FitPage
      Me._fitPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._fitPageToolStripButton.Name = "_fitPageToolStripButton"
      Me._fitPageToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._fitPageToolStripButton.ToolTipText = "Fit entire page in window"
      '
      '_useDpiToolStripButton
      '
      Me._useDpiToolStripButton.CheckOnClick = True
      Me._useDpiToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._useDpiToolStripButton.Image = Global.RasterizeDocumentDemo.My.Resources.Resources.UseDpi
      Me._useDpiToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._useDpiToolStripButton.Name = "_useDpiToolStripButton"
      Me._useDpiToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._useDpiToolStripButton.ToolTipText = "Use the image actual resolution instead of the screen when viewing"
      '
      '_toolStripSeparator2
      '
      Me._toolStripSeparator2.Name = "_toolStripSeparator2"
      Me._toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
      '
      '_panModeToolStripButton
      '
      Me._panModeToolStripButton.CheckOnClick = True
      Me._panModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._panModeToolStripButton.Image = Global.RasterizeDocumentDemo.My.Resources.Resources.PanMode
      Me._panModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._panModeToolStripButton.Name = "_panModeToolStripButton"
      Me._panModeToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._panModeToolStripButton.ToolTipText = "Pan mode"
      '
      '_zoomToSelectionModeToolStripButton
      '
      Me._zoomToSelectionModeToolStripButton.CheckOnClick = True
      Me._zoomToSelectionModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._zoomToSelectionModeToolStripButton.Image = Global.RasterizeDocumentDemo.My.Resources.Resources.ZoomSelection
      Me._zoomToSelectionModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._zoomToSelectionModeToolStripButton.Name = "_zoomToSelectionModeToolStripButton"
      Me._zoomToSelectionModeToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._zoomToSelectionModeToolStripButton.ToolTipText = "Zoom to selection mode"
      '
      '_imageList
      '
      Me._imageList.BackColor = System.Drawing.SystemColors.Control
      Me._imageList.ViewHorizontalAlignment = ControlAlignment.Center
      Me._imageList.ViewHorizontalAlignment = ControlAlignment.Center
      Me._imageList.ItemSpacing = New LeadSize(20, 20)
      Me._imageList.ItemBorderThickness = 2
      Me._imageList.SelectedItemBorderColor = System.Drawing.Color.Blue
      Me._imageList.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me._imageList.Dock = System.Windows.Forms.DockStyle.Left
      Me._imageList.ItemSize = New LeadSize(160, 160)
      Me._imageList.ItemSizeMode = ControlSizeMode.Fit
      Me._imageList.Location = New System.Drawing.Point(0, 93)
      Me._imageList.Name = "_imageList"
      Me._imageList.Size = New System.Drawing.Size(197, 475)
      Me._imageList.TabIndex = 11
      Dim SelectItemsInteractiveMode As ImageViewerSelectItemsInteractiveMode = New ImageViewerSelectItemsInteractiveMode()
      SelectItemsInteractiveMode.SelectionMode = ImageViewerSelectionMode.Single
      Me._imageList.InteractiveModes.Add(SelectItemsInteractiveMode)
      '
      '_imageViewer
      '
      Me._imageViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._imageViewer.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me._imageViewer.ViewPadding = New System.Windows.Forms.Padding(10)
      Me._imageViewer.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me._imageViewer.ViewHorizontalAlignment = ControlAlignment.Center
      Me._imageViewer.Location = New System.Drawing.Point(229, 122)
      Me._imageViewer.Name = "_imageViewer"
      Me._imageViewer.Size = New System.Drawing.Size(496, 220)
      Me._imageViewer.TabIndex = 10
      Me._imageViewer.UseDpi = True
      Me._imageViewer.ViewVerticalAlignment = ControlAlignment.Center
      '
      '_mousePositionLabel
      '
      Me._mousePositionLabel.Dock = System.Windows.Forms.DockStyle.Bottom
      Me._mousePositionLabel.Location = New System.Drawing.Point(0, 568)
      Me._mousePositionLabel.Name = "_mousePositionLabel"
      Me._mousePositionLabel.Size = New System.Drawing.Size(850, 13)
      Me._mousePositionLabel.TabIndex = 14
      Me._mousePositionLabel.Text = "_mousePositionLabel"
      Me._mousePositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'ViewerControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._imageViewer)
      Me.Controls.Add(Me._imageList)
      Me.Controls.Add(Me._toolStrip)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me._mousePositionLabel)
      Me.Name = "ViewerControl"
      Me.Size = New System.Drawing.Size(850, 581)
      Me._imageInfoTableLayoutPanel.ResumeLayout(False)
      Me.Panel1.ResumeLayout(False)
      Me.TableLayoutPanel1.ResumeLayout(False)
      Me.TableLayoutPanel1.PerformLayout()
      Me._toolStrip.ResumeLayout(False)
      Me._toolStrip.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents _imageInfoPanel As System.Windows.Forms.Panel
   Friend WithEvents _imageInfoTableLayoutPanel As System.Windows.Forms.TableLayoutPanel
   Private WithEvents _imageInfoFileSizeLabel As System.Windows.Forms.Label
   Private WithEvents _imageInfoFileSizeValueLabel As System.Windows.Forms.Label
   Private WithEvents Panel1 As System.Windows.Forms.Panel
   Private WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
   Private WithEvents Label1 As System.Windows.Forms.Label
   Private WithEvents Label2 As System.Windows.Forms.Label
   Private WithEvents _imageInfoMemorySizeValueLabel As System.Windows.Forms.Label
   Private WithEvents _imageInfoBitsPerPixelValueLabel As System.Windows.Forms.Label
   Private WithEvents _imageInfoPageSizeLabel As System.Windows.Forms.Label
   Private WithEvents _imageInfoPageSizeLogicalLabel As System.Windows.Forms.Label
   Private WithEvents _imageInfoPageSizePixelsLabel As System.Windows.Forms.Label
   Private WithEvents _imageInfoPageSizeResolutionLabel As System.Windows.Forms.Label
   Private WithEvents _imageInfoMemorySizeLabel As System.Windows.Forms.Label
   Private WithEvents _imageInfoBitsPerPixelLabel As System.Windows.Forms.Label
   Private WithEvents _toolStrip As System.Windows.Forms.ToolStrip
   Private WithEvents _previousPageToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _nextPageToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _pageToolStripTextBox As System.Windows.Forms.ToolStripTextBox
   Private WithEvents _pageToolStripLabel As System.Windows.Forms.ToolStripLabel
   Private WithEvents _toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _zoomOutToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _zoomInToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _zoomToolStripComboBox As System.Windows.Forms.ToolStripComboBox
   Private WithEvents _fitPageWidthToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _fitPageToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _useDpiToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _panModeToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _zoomToSelectionModeToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _imageList As ImageViewer
   Private WithEvents _imageViewer As ImageViewer
   Private WithEvents _mousePositionLabel As System.Windows.Forms.Label

End Class
