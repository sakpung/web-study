Imports Leadtools.Annotations.WinForms
Imports Leadtools.Controls

Namespace DocumentWritersDemo
   Partial Class ViewerControl
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

#Region "Component Designer generated code"

      ''' <summary> 
      ''' Required method for Designer support - do not modify 
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Me._titleLabel = New System.Windows.Forms.Label()
         Me._toolStrip = New System.Windows.Forms.ToolStrip()
         Me._previousPageToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._nextPageToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._pageToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
         Me._pageToolStripLabel = New System.Windows.Forms.ToolStripLabel()
         Me._toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
         Me._zoomOutToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._zoomInToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._zoomToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
         Me._fitPageWidthToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._fitPageToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
         Me._selectModeToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._panModeToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._zoomToSelectionModeToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
         Me._bringToFrontToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._sendToBackToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._bringToFirstToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._sendToLastToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
         Me._propertiesToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._mousePositionLabel = New System.Windows.Forms.Label()
         Me._rasterImageViewer = New AutomationImageViewer()
         Me._toolStrip.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _titleLabel
         ' 
         Me._titleLabel.Dock = System.Windows.Forms.DockStyle.Top
         Me._titleLabel.Location = New System.Drawing.Point(0, 0)
         Me._titleLabel.Name = "_titleLabel"
         Me._titleLabel.Size = New System.Drawing.Size(619, 13)
         Me._titleLabel.TabIndex = 1
         Me._titleLabel.Text = "_titleLabel"
         Me._titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' _toolStrip
         ' 
         Me._toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._previousPageToolStripButton, Me._nextPageToolStripButton, Me._pageToolStripTextBox, Me._pageToolStripLabel, Me._toolStripSeparator1, Me._zoomOutToolStripButton, _
          Me._zoomInToolStripButton, Me._zoomToolStripComboBox, Me._fitPageWidthToolStripButton, Me._fitPageToolStripButton, Me._toolStripSeparator2, Me._selectModeToolStripButton, _
          Me._panModeToolStripButton, Me._zoomToSelectionModeToolStripButton, Me._toolStripSeparator3, Me._bringToFrontToolStripButton, Me._sendToBackToolStripButton, Me._bringToFirstToolStripButton, _
          Me._sendToLastToolStripButton, Me._toolStripSeparator4, Me._propertiesToolStripButton})
         Me._toolStrip.Location = New System.Drawing.Point(0, 13)
         Me._toolStrip.Name = "_toolStrip"
         Me._toolStrip.Size = New System.Drawing.Size(619, 25)
         Me._toolStrip.TabIndex = 2
         ' 
         ' _previousPageToolStripButton
         ' 
         Me._previousPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._previousPageToolStripButton.Image = Global.DocumentWritersDemo.Resources.PreviousPage
         Me._previousPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._previousPageToolStripButton.Name = "_previousPageToolStripButton"
         Me._previousPageToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._previousPageToolStripButton.ToolTipText = "Go to previous page in the document"
         ' 
         ' _nextPageToolStripButton
         ' 
         Me._nextPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._nextPageToolStripButton.Image = Global.DocumentWritersDemo.Resources.NextPage
         Me._nextPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._nextPageToolStripButton.Name = "_nextPageToolStripButton"
         Me._nextPageToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._nextPageToolStripButton.ToolTipText = "Go to next page in the document"
         ' 
         ' _pageToolStripTextBox
         ' 
         Me._pageToolStripTextBox.Name = "_pageToolStripTextBox"
         Me._pageToolStripTextBox.Size = New System.Drawing.Size(40, 25)
         Me._pageToolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
         Me._pageToolStripTextBox.ToolTipText = "Current page number in the document"
         ' 
         ' _pageToolStripLabel
         ' 
         Me._pageToolStripLabel.Name = "_pageToolStripLabel"
         Me._pageToolStripLabel.Size = New System.Drawing.Size(48, 22)
         Me._pageToolStripLabel.Text = "/ WWW"
         ' 
         ' _toolStripSeparator1
         ' 
         Me._toolStripSeparator1.Name = "_toolStripSeparator1"
         Me._toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
         ' 
         ' _zoomOutToolStripButton
         ' 
         Me._zoomOutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._zoomOutToolStripButton.Image = Global.DocumentWritersDemo.Resources.ZoomOut
         Me._zoomOutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._zoomOutToolStripButton.Name = "_zoomOutToolStripButton"
         Me._zoomOutToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._zoomOutToolStripButton.ToolTipText = "Zoom out"
         ' 
         ' _zoomInToolStripButton
         ' 
         Me._zoomInToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._zoomInToolStripButton.Image = Global.DocumentWritersDemo.Resources.ZoomIn
         Me._zoomInToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._zoomInToolStripButton.Name = "_zoomInToolStripButton"
         Me._zoomInToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._zoomInToolStripButton.ToolTipText = "Zoom In"
         ' 
         ' _zoomToolStripComboBox
         ' 
         Me._zoomToolStripComboBox.DropDownWidth = 80
         Me._zoomToolStripComboBox.Items.AddRange(New Object() {"10%", "25%", "50%", "75%", "100%", "125%", _
          "200%", "400%", "800%", "1600%", "2400%", "3200%", _
          "6400%", "Actual Size", "Fit Page", "Fit Width"})
         Me._zoomToolStripComboBox.Name = "_zoomToolStripComboBox"
         Me._zoomToolStripComboBox.Size = New System.Drawing.Size(80, 25)
         ' 
         ' _fitPageWidthToolStripButton
         ' 
         Me._fitPageWidthToolStripButton.CheckOnClick = True
         Me._fitPageWidthToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._fitPageWidthToolStripButton.Image = Global.DocumentWritersDemo.Resources.FitPageWidth
         Me._fitPageWidthToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._fitPageWidthToolStripButton.Name = "_fitPageWidthToolStripButton"
         Me._fitPageWidthToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._fitPageWidthToolStripButton.ToolTipText = "Fit page width in window"
         ' 
         ' _fitPageToolStripButton
         ' 
         Me._fitPageToolStripButton.CheckOnClick = True
         Me._fitPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._fitPageToolStripButton.Image = Global.DocumentWritersDemo.Resources.FitPage
         Me._fitPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._fitPageToolStripButton.Name = "_fitPageToolStripButton"
         Me._fitPageToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._fitPageToolStripButton.ToolTipText = "Fit entire page in window"
         ' 
         ' _toolStripSeparator2
         ' 
         Me._toolStripSeparator2.Name = "_toolStripSeparator2"
         Me._toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
         ' 
         ' _selectModeToolStripButton
         ' 
         Me._selectModeToolStripButton.CheckOnClick = True
         Me._selectModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._selectModeToolStripButton.Image = Global.DocumentWritersDemo.Resources.SelectMode
         Me._selectModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._selectModeToolStripButton.Name = "_selectModeToolStripButton"
         Me._selectModeToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._selectModeToolStripButton.ToolTipText = "Select mode"
         ' 
         ' _panModeToolStripButton
         ' 
         Me._panModeToolStripButton.CheckOnClick = True
         Me._panModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._panModeToolStripButton.Image = Global.DocumentWritersDemo.Resources.PanMode
         Me._panModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._panModeToolStripButton.Name = "_panModeToolStripButton"
         Me._panModeToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._panModeToolStripButton.ToolTipText = "Pan mode"
         ' 
         ' _zoomToSelectionModeToolStripButton
         ' 
         Me._zoomToSelectionModeToolStripButton.CheckOnClick = True
         Me._zoomToSelectionModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._zoomToSelectionModeToolStripButton.Image = Global.DocumentWritersDemo.Resources.ZoomSelection
         Me._zoomToSelectionModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._zoomToSelectionModeToolStripButton.Name = "_zoomToSelectionModeToolStripButton"
         Me._zoomToSelectionModeToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._zoomToSelectionModeToolStripButton.ToolTipText = "Zoom to selection mode"
         ' 
         ' _toolStripSeparator3
         ' 
         Me._toolStripSeparator3.Name = "_toolStripSeparator3"
         Me._toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
         ' 
         ' _bringToFrontToolStripButton
         ' 
         Me._bringToFrontToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._bringToFrontToolStripButton.Image = Global.DocumentWritersDemo.Resources.BringToFront
         Me._bringToFrontToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._bringToFrontToolStripButton.Name = "_bringToFrontToolStripButton"
         Me._bringToFrontToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._bringToFrontToolStripButton.ToolTipText = "Bring selected object(s) to front"
         ' 
         ' _sendToBackToolStripButton
         ' 
         Me._sendToBackToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._sendToBackToolStripButton.Image = Global.DocumentWritersDemo.Resources.SendToBack
         Me._sendToBackToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._sendToBackToolStripButton.Name = "_sendToBackToolStripButton"
         Me._sendToBackToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._sendToBackToolStripButton.ToolTipText = "Send selected object(s) to back"
         ' 
         ' _bringToFirstToolStripButton
         ' 
         Me._bringToFirstToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._bringToFirstToolStripButton.Image = Global.DocumentWritersDemo.Resources.BringToFirst
         Me._bringToFirstToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._bringToFirstToolStripButton.Name = "_bringToFirstToolStripButton"
         Me._bringToFirstToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._bringToFirstToolStripButton.ToolTipText = "Bring selected object(s) to first"
         ' 
         ' _sendToLastToolStripButton
         ' 
         Me._sendToLastToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._sendToLastToolStripButton.Image = Global.DocumentWritersDemo.Resources.SendToLast
         Me._sendToLastToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._sendToLastToolStripButton.Name = "_sendToLastToolStripButton"
         Me._sendToLastToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._sendToLastToolStripButton.ToolTipText = "Send selected object(s) to last"
         ' 
         ' _toolStripSeparator4
         ' 
         Me._toolStripSeparator4.Name = "_toolStripSeparator4"
         Me._toolStripSeparator4.Size = New System.Drawing.Size(6, 25)
         ' 
         ' _propertiesToolStripButton
         ' 
         Me._propertiesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._propertiesToolStripButton.Image = Global.DocumentWritersDemo.Resources.ObjectProperties
         Me._propertiesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._propertiesToolStripButton.Name = "_propertiesToolStripButton"
         Me._propertiesToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._propertiesToolStripButton.ToolTipText = "Show selected object(s) properties"
         ' 
         ' _mousePositionLabel
         ' 
         Me._mousePositionLabel.Dock = System.Windows.Forms.DockStyle.Bottom
         Me._mousePositionLabel.Location = New System.Drawing.Point(0, 408)
         Me._mousePositionLabel.Name = "_mousePositionLabel"
         Me._mousePositionLabel.Size = New System.Drawing.Size(619, 13)
         Me._mousePositionLabel.TabIndex = 3
         Me._mousePositionLabel.Text = "_mousePositionLabel"
         Me._mousePositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' _rasterImageViewer
         '
         Me._rasterImageViewer.BackColor = System.Drawing.SystemColors.AppWorkspace
         Me._rasterImageViewer.BorderStyle = System.Windows.Forms.BorderStyle.None
         Me._rasterImageViewer.Dock = System.Windows.Forms.DockStyle.Fill
         Me._rasterImageViewer.RestrictScroll = False
         Me._rasterImageViewer.ScrollMode = ControlScrollMode.Auto
         Me._rasterImageViewer.HorizontalScroll.Enabled = True
         Me._rasterImageViewer.VerticalScroll.Enabled = True
         Me._rasterImageViewer.VerticalScroll.Visible = True
         Me._rasterImageViewer.AutoScroll = True
         Me._rasterImageViewer.ViewHorizontalAlignment = ControlAlignment.Center
         Me._rasterImageViewer.Location = New System.Drawing.Point(0, 38)
         Me._rasterImageViewer.Name = "_rasterImageViewer"
         Me._rasterImageViewer.Size = New System.Drawing.Size(619, 370)
         Me._rasterImageViewer.TabIndex = 4
         Me._rasterImageViewer.ViewVerticalAlignment = ControlAlignment.Center
         ' 
         ' ViewerControl
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me._rasterImageViewer)
         Me.Controls.Add(Me._mousePositionLabel)
         Me.Controls.Add(Me._toolStrip)
         Me.Controls.Add(Me._titleLabel)
         Me.Name = "ViewerControl"
         Me.Size = New System.Drawing.Size(619, 421)
         Me._toolStrip.ResumeLayout(False)
         Me._toolStrip.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _titleLabel As System.Windows.Forms.Label
      Private _toolStrip As System.Windows.Forms.ToolStrip
      Private WithEvents _previousPageToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _nextPageToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _pageToolStripTextBox As System.Windows.Forms.ToolStripTextBox
      Private _pageToolStripLabel As System.Windows.Forms.ToolStripLabel
      Private _toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _zoomOutToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _zoomInToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _zoomToolStripComboBox As System.Windows.Forms.ToolStripComboBox
      Private WithEvents _fitPageWidthToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _fitPageToolStripButton As System.Windows.Forms.ToolStripButton
      Private _toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _selectModeToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _panModeToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _zoomToSelectionModeToolStripButton As System.Windows.Forms.ToolStripButton
      Private _mousePositionLabel As System.Windows.Forms.Label
      Private WithEvents _rasterImageViewer As AutomationImageViewer
      Private _toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _propertiesToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _bringToFrontToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _sendToBackToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _bringToFirstToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _sendToLastToolStripButton As System.Windows.Forms.ToolStripButton
      Private _toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   End Class
End Namespace
