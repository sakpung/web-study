Imports Leadtools.Annotations.WinForms
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
      Me._titleLabel = New System.Windows.Forms.Label
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
      Me._toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
      Me._selectModeToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._panModeToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._zoomToSelectionModeToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._drawZoneModeToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
      Me._zonePropertiesToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._showZonesToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._showZoneNameToolStripButton = New System.Windows.Forms.ToolStripButton
      Me._rasterImageViewer = New AutomationImageViewer()
      Me._splitContainer = New System.Windows.Forms.SplitContainer
      Me._mousePositionLabel = New System.Windows.Forms.Label
      Me._cellIndexLabel = New System.Windows.Forms.Label
      Me._toolStrip.SuspendLayout()
      Me._splitContainer.Panel1.SuspendLayout()
      Me._splitContainer.Panel2.SuspendLayout()
      Me._splitContainer.SuspendLayout()
      Me.SuspendLayout()
      '
      '_titleLabel
      '
      Me._titleLabel.Dock = System.Windows.Forms.DockStyle.Top
      Me._titleLabel.Location = New System.Drawing.Point(0, 0)
      Me._titleLabel.Name = "_titleLabel"
      Me._titleLabel.Size = New System.Drawing.Size(619, 13)
      Me._titleLabel.TabIndex = 0
      Me._titleLabel.Text = ""
      Me._titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_toolStrip
      '
      Me._toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._previousPageToolStripButton, Me._nextPageToolStripButton, Me._pageToolStripTextBox, Me._pageToolStripLabel, Me._toolStripSeparator1, Me._zoomOutToolStripButton, Me._zoomInToolStripButton, Me._zoomToolStripComboBox, Me._fitPageWidthToolStripButton, Me._fitPageToolStripButton, Me._toolStripSeparator2, Me._selectModeToolStripButton, Me._panModeToolStripButton, Me._zoomToSelectionModeToolStripButton, Me._drawZoneModeToolStripButton, Me._toolStripSeparator3, Me._zonePropertiesToolStripButton, Me._showZonesToolStripButton, Me._showZoneNameToolStripButton})
      Me._toolStrip.Location = New System.Drawing.Point(0, 13)
      Me._toolStrip.Name = "_toolStrip"
      Me._toolStrip.Size = New System.Drawing.Size(619, 25)
      Me._toolStrip.TabIndex = 1
      '
      '_previousPageToolStripButton
      '
      Me._previousPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._previousPageToolStripButton.Image = Global.OcrMultiEngineDemo.My.Resources.Resources.PreviousPage
      Me._previousPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._previousPageToolStripButton.Name = "_previousPageToolStripButton"
      Me._previousPageToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._previousPageToolStripButton.ToolTipText = "Go to previous page in the document"
      '
      '_nextPageToolStripButton
      '
      Me._nextPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._nextPageToolStripButton.Image = Global.OcrMultiEngineDemo.My.Resources.Resources.NextPage
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
      Me._zoomOutToolStripButton.Image = Global.OcrMultiEngineDemo.My.Resources.Resources.ZoomOut
      Me._zoomOutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._zoomOutToolStripButton.Name = "_zoomOutToolStripButton"
      Me._zoomOutToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._zoomOutToolStripButton.ToolTipText = "Zoom out"
      '
      '_zoomInToolStripButton
      '
      Me._zoomInToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._zoomInToolStripButton.Image = Global.OcrMultiEngineDemo.My.Resources.Resources.ZoomIn
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
      Me._fitPageWidthToolStripButton.Image = Global.OcrMultiEngineDemo.My.Resources.Resources.FitPageWidth
      Me._fitPageWidthToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._fitPageWidthToolStripButton.Name = "_fitPageWidthToolStripButton"
      Me._fitPageWidthToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._fitPageWidthToolStripButton.ToolTipText = "Fit page width in window"
      '
      '_fitPageToolStripButton
      '
      Me._fitPageToolStripButton.CheckOnClick = True
      Me._fitPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._fitPageToolStripButton.Image = Global.OcrMultiEngineDemo.My.Resources.Resources.FitPage
      Me._fitPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._fitPageToolStripButton.Name = "_fitPageToolStripButton"
      Me._fitPageToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._fitPageToolStripButton.ToolTipText = "Fit entire page in window"
      '
      '_toolStripSeparator2
      '
      Me._toolStripSeparator2.Name = "_toolStripSeparator2"
      Me._toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
      '
      '_selectModeToolStripButton
      '
      Me._selectModeToolStripButton.CheckOnClick = True
      Me._selectModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._selectModeToolStripButton.Image = Global.OcrMultiEngineDemo.My.Resources.Resources.SelectMode
      Me._selectModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._selectModeToolStripButton.Name = "_selectModeToolStripButton"
      Me._selectModeToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._selectModeToolStripButton.ToolTipText = "Select mode"
      '
      '_panModeToolStripButton
      '
      Me._panModeToolStripButton.CheckOnClick = True
      Me._panModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._panModeToolStripButton.Image = Global.OcrMultiEngineDemo.My.Resources.Resources.PanMode
      Me._panModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._panModeToolStripButton.Name = "_panModeToolStripButton"
      Me._panModeToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._panModeToolStripButton.ToolTipText = "Pan mode"
      '
      '_zoomToSelectionModeToolStripButton
      '
      Me._zoomToSelectionModeToolStripButton.CheckOnClick = True
      Me._zoomToSelectionModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._zoomToSelectionModeToolStripButton.Image = Global.OcrMultiEngineDemo.My.Resources.Resources.ZoomSelection
      Me._zoomToSelectionModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._zoomToSelectionModeToolStripButton.Name = "_zoomToSelectionModeToolStripButton"
      Me._zoomToSelectionModeToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._zoomToSelectionModeToolStripButton.ToolTipText = "Zoom to selection mode"
      '
      '_drawZoneModeToolStripButton
      '
      Me._drawZoneModeToolStripButton.CheckOnClick = True
      Me._drawZoneModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._drawZoneModeToolStripButton.Image = Global.OcrMultiEngineDemo.My.Resources.Resources.DrawZoneMode
      Me._drawZoneModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._drawZoneModeToolStripButton.Name = "_drawZoneModeToolStripButton"
      Me._drawZoneModeToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._drawZoneModeToolStripButton.ToolTipText = "Draw new zone mode"
      '
      '_toolStripSeparator3
      '
      Me._toolStripSeparator3.Name = "_toolStripSeparator3"
      Me._toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
      '
      '_zonePropertiesToolStripButton
      '
      Me._zonePropertiesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._zonePropertiesToolStripButton.Image = Global.OcrMultiEngineDemo.My.Resources.Resources.ZoneProperties
      Me._zonePropertiesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._zonePropertiesToolStripButton.Name = "_zonePropertiesToolStripButton"
      Me._zonePropertiesToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._zonePropertiesToolStripButton.ToolTipText = "Show the update zones dialog"
      '
      '_showZonesToolStripButton
      '
      Me._showZonesToolStripButton.Checked = True
      Me._showZonesToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked
      Me._showZonesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._showZonesToolStripButton.Image = Global.OcrMultiEngineDemo.My.Resources.Resources.ShowZones
      Me._showZonesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._showZonesToolStripButton.Name = "_showZonesToolStripButton"
      Me._showZonesToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._showZonesToolStripButton.ToolTipText = "Show/hide zones"
      '
      '_showZoneNameToolStripButton
      '
      Me._showZoneNameToolStripButton.Checked = True
      Me._showZoneNameToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked
      Me._showZoneNameToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._showZoneNameToolStripButton.Image = Global.OcrMultiEngineDemo.My.Resources.Resources.ShowZoneName
      Me._showZoneNameToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._showZoneNameToolStripButton.Name = "_showZoneNameToolStripButton"
      Me._showZoneNameToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me._showZoneNameToolStripButton.ToolTipText = "Show/hide zone names"
      '
      '_rasterImageViewer
      '
      Me._rasterImageViewer.Dock = DockStyle.Fill
      Me._rasterImageViewer.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me._rasterImageViewer.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me._rasterImageViewer.AutoScroll = True
      Me._rasterImageViewer.ViewHorizontalAlignment = ControlAlignment.Center
      Me._rasterImageViewer.Name = "_rasterImageViewer"
      Me._rasterImageViewer.Zoom(ControlSizeMode.Fit, _rasterImageViewer.ScaleFactor, _rasterImageViewer.DefaultZoomOrigin)
      Me._rasterImageViewer.UseDpi = True
      Me._rasterImageViewer.ViewVerticalAlignment = ControlAlignment.Center
      '
      '_splitContainer
      '
      Me._splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._splitContainer.Dock = System.Windows.Forms.DockStyle.Bottom
      Me._splitContainer.IsSplitterFixed = True
      Me._splitContainer.Location = New System.Drawing.Point(0, 405)
      Me._splitContainer.Name = "_splitContainer"
      '
      '_splitContainer.Panel1
      '
      Me._splitContainer.Panel1.Controls.Add(Me._mousePositionLabel)
      '
      '_splitContainer.Panel2
      '
      Me._splitContainer.Panel2.Controls.Add(Me._cellIndexLabel)
      Me._splitContainer.Size = New System.Drawing.Size(619, 16)
      Me._splitContainer.SplitterDistance = 205
      Me._splitContainer.SplitterWidth = 1
      Me._splitContainer.TabIndex = 5
      '
      '_mousePositionLabel
      '
      Me._mousePositionLabel.Dock = System.Windows.Forms.DockStyle.Bottom
      Me._mousePositionLabel.Location = New System.Drawing.Point(0, 1)
      Me._mousePositionLabel.Name = "_mousePositionLabel"
      Me._mousePositionLabel.Size = New System.Drawing.Size(203, 13)
      Me._mousePositionLabel.TabIndex = 6
      Me._mousePositionLabel.Text = "_mousePositionLabel"
      Me._mousePositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_cellIndexLabel
      '
      Me._cellIndexLabel.Dock = System.Windows.Forms.DockStyle.Bottom
      Me._cellIndexLabel.Location = New System.Drawing.Point(0, 1)
      Me._cellIndexLabel.Name = "_cellIndexLabel"
      Me._cellIndexLabel.Size = New System.Drawing.Size(411, 13)
      Me._cellIndexLabel.TabIndex = 7
      Me._cellIndexLabel.Text = ""
      Me._cellIndexLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'ViewerControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._rasterImageViewer)
      Me.Controls.Add(Me._splitContainer)
      Me.Controls.Add(Me._toolStrip)
      Me.Controls.Add(Me._titleLabel)
      Me.Name = "ViewerControl"
      Me.Size = New System.Drawing.Size(619, 421)
      Me._toolStrip.ResumeLayout(False)
      Me._toolStrip.PerformLayout()
      Me._splitContainer.Panel1.ResumeLayout(False)
      Me._splitContainer.Panel2.ResumeLayout(False)
      Me._splitContainer.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents _titleLabel As System.Windows.Forms.Label
   Public WithEvents _toolStrip As System.Windows.Forms.ToolStrip
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
   Private WithEvents _toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _selectModeToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _panModeToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _zoomToSelectionModeToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _drawZoneModeToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _zonePropertiesToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _showZonesToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _rasterImageViewer As AutomationImageViewer
   Friend WithEvents _showZoneNameToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _splitContainer As System.Windows.Forms.SplitContainer
   Private WithEvents _mousePositionLabel As System.Windows.Forms.Label
   Private WithEvents _cellIndexLabel As System.Windows.Forms.Label

End Class
