Imports Leadtools.Annotations.WinForms
Imports Leadtools.Controls
Namespace PDFDocumentDemo.ViewerControl
   Partial Class ViewerControl
      ''' <summary> 
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary> 
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing AndAlso (Not components Is Nothing) Then
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewerControl))
         Me._pageInfoLabel = New System.Windows.Forms.Label()
         Me._zoomToSelectionModeToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._panModeToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._selectModeToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._mousePositionLabel = New System.Windows.Forms.Label()
         Me._toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
         Me._fitPageToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._pageToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
         Me._nextPageToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._previousPageToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._toolStrip = New System.Windows.Forms.ToolStrip()
         Me._pageToolStripLabel = New System.Windows.Forms.ToolStripLabel()
         Me._toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
         Me._zoomOutToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._zoomInToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._zoomToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
         Me._fitPageWidthToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
         Me._highlightObjectsToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._rasterImageViewer = New AutomationImageViewer()
         Me._highlightTextModeToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._toolStrip.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _pageInfoLabel
         ' 
         Me._pageInfoLabel.Dock = System.Windows.Forms.DockStyle.Top
         Me._pageInfoLabel.Location = New System.Drawing.Point(0, 25)
         Me._pageInfoLabel.Name = "_pageInfoLabel"
         Me._pageInfoLabel.Size = New System.Drawing.Size(619, 13)
         Me._pageInfoLabel.TabIndex = 10
         Me._pageInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' _zoomToSelectionModeToolStripButton
         ' 
         Me._zoomToSelectionModeToolStripButton.CheckOnClick = True
         Me._zoomToSelectionModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._zoomToSelectionModeToolStripButton.Image = Global.PDFDocumentDemo.Resources.ZoomSelection
         Me._zoomToSelectionModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._zoomToSelectionModeToolStripButton.Name = "_zoomToSelectionModeToolStripButton"

         Me._zoomToSelectionModeToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._zoomToSelectionModeToolStripButton.ToolTipText = resources.GetString("resx_ZoomToSelectionMode")
         ' 
         ' _panModeToolStripButton
         ' 
         Me._panModeToolStripButton.CheckOnClick = True
         Me._panModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._panModeToolStripButton.Image = Global.PDFDocumentDemo.Resources.PanMode
         Me._panModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._panModeToolStripButton.Name = "_panModeToolStripButton"
         Me._panModeToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._panModeToolStripButton.ToolTipText = resources.GetString("resx_PanMode")
         ' 
         ' _selectModeToolStripButton
         ' 
         Me._selectModeToolStripButton.CheckOnClick = True
         Me._selectModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._selectModeToolStripButton.Image = Global.PDFDocumentDemo.Resources.SelectMode
         Me._selectModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._selectModeToolStripButton.Name = "_selectModeToolStripButton"
         Me._selectModeToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._selectModeToolStripButton.ToolTipText = resources.GetString("resx_Select")
         ' 
         ' _mousePositionLabel
         ' 
         Me._mousePositionLabel.Dock = System.Windows.Forms.DockStyle.Bottom
         Me._mousePositionLabel.Location = New System.Drawing.Point(0, 408)
         Me._mousePositionLabel.Name = "_mousePositionLabel"
         Me._mousePositionLabel.Size = New System.Drawing.Size(619, 13)
         Me._mousePositionLabel.TabIndex = 12
         Me._mousePositionLabel.Text = "_mousePositionLabel"
         ' 
         ' _toolStripSeparator2
         ' 
         Me._toolStripSeparator2.Name = "_toolStripSeparator2"
         Me._toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
         ' 
         ' _fitPageToolStripButton
         ' 
         Me._fitPageToolStripButton.CheckOnClick = True
         Me._fitPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._fitPageToolStripButton.Image = Global.PDFDocumentDemo.Resources.FitPage
         Me._fitPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._fitPageToolStripButton.Name = "_fitPageToolStripButton"
         Me._fitPageToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._fitPageToolStripButton.ToolTipText = resources.GetString("resx_FitEntirePageInWindow")
         ' 
         ' _pageToolStripTextBox
         ' 
         Me._pageToolStripTextBox.Name = "_pageToolStripTextBox"
         Me._pageToolStripTextBox.Size = New System.Drawing.Size(40, 25)
         Me._pageToolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
         Me._pageToolStripTextBox.ToolTipText = resources.GetString("resx_CurrentPageNumber")
         ' 
         ' _nextPageToolStripButton
         ' 
         Me._nextPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._nextPageToolStripButton.Image = Global.PDFDocumentDemo.Resources.NextPage
         Me._nextPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._nextPageToolStripButton.Name = "_nextPageToolStripButton"
         Me._nextPageToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._nextPageToolStripButton.ToolTipText = resources.GetString("resx_GoToNextPage")
         ' 
         ' _previousPageToolStripButton
         ' 
         Me._previousPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._previousPageToolStripButton.Image = Global.PDFDocumentDemo.Resources.PreviousPage
         Me._previousPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._previousPageToolStripButton.Name = "_previousPageToolStripButton"
         Me._previousPageToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._previousPageToolStripButton.ToolTipText = resources.GetString("resx_GoToPreviousPage")
         ' 
         ' _toolStrip
         ' 
         Me._toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._previousPageToolStripButton, Me._nextPageToolStripButton, Me._pageToolStripTextBox, Me._pageToolStripLabel, Me._toolStripSeparator1, Me._zoomOutToolStripButton, Me._zoomInToolStripButton, Me._zoomToolStripComboBox, Me._fitPageWidthToolStripButton, Me._fitPageToolStripButton, Me._toolStripSeparator2, Me._selectModeToolStripButton, Me._highlightTextModeToolStripButton, Me._panModeToolStripButton, Me._zoomToSelectionModeToolStripButton, Me._toolStripSeparator3, Me._highlightObjectsToolStripButton})
         Me._toolStrip.Location = New System.Drawing.Point(0, 0)
         Me._toolStrip.Name = "_toolStrip"
         Me._toolStrip.Size = New System.Drawing.Size(619, 25)
         Me._toolStrip.TabIndex = 11
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
         Me._zoomOutToolStripButton.Image = Global.PDFDocumentDemo.Resources.ZoomOut
         Me._zoomOutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._zoomOutToolStripButton.Name = "_zoomOutToolStripButton"
         Me._zoomOutToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._zoomOutToolStripButton.ToolTipText = resources.GetString("resx_ZoomOut")
         ' 
         ' _zoomInToolStripButton
         ' 
         Me._zoomInToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._zoomInToolStripButton.Image = Global.PDFDocumentDemo.Resources.ZoomIn
         Me._zoomInToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._zoomInToolStripButton.Name = "_zoomInToolStripButton"
         Me._zoomInToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._zoomInToolStripButton.ToolTipText = resources.GetString("resx_ZoomIn")
         ' 
         ' _zoomToolStripComboBox
         ' 
         Me._zoomToolStripComboBox.DropDownWidth = 80
         Me._zoomToolStripComboBox.Items.AddRange(New Object() {"10%", "25%", "50%", "75%", "100%", "125%", "200%", "400%", "800%", "1600%", "2400%", "3200%", "6400%", resources.GetString("resx_ActualSize"), resources.GetString("resx_FitPage"), resources.GetString("resx_FitWidth")})
         Me._zoomToolStripComboBox.Name = "_zoomToolStripComboBox"
         Me._zoomToolStripComboBox.Size = New System.Drawing.Size(80, 25)
         ' 
         ' _fitPageWidthToolStripButton
         ' 
         Me._fitPageWidthToolStripButton.CheckOnClick = True
         Me._fitPageWidthToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._fitPageWidthToolStripButton.Image = Global.PDFDocumentDemo.Resources.FitPageWidth
         Me._fitPageWidthToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._fitPageWidthToolStripButton.Name = "_fitPageWidthToolStripButton"
         Me._fitPageWidthToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._fitPageWidthToolStripButton.ToolTipText = resources.GetString("resx_FitPageWidthInWindow")
         ' 
         ' _toolStripSeparator3
         ' 
         Me._toolStripSeparator3.Name = "_toolStripSeparator3"
         Me._toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
         ' 
         ' _highlightObjectsToolStripButton
         ' 
         Me._highlightObjectsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._highlightObjectsToolStripButton.Image = Global.PDFDocumentDemo.Resources.HighlightObjects
         Me._highlightObjectsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._highlightObjectsToolStripButton.Name = "_highlightObjectsToolStripButton"
         Me._highlightObjectsToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._highlightObjectsToolStripButton.ToolTipText = resources.GetString("resx_HighlightTheObjects")
         ' 
         ' _rasterImageViewer
         ' 
         Me._rasterImageViewer.ImageRegionRenderMode = ControlRegionRenderMode.None
         Me._rasterImageViewer.AutomationAntiAlias = False
         Me._rasterImageViewer.BackColor = System.Drawing.SystemColors.AppWorkspace
         Me._rasterImageViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._rasterImageViewer.Dock = System.Windows.Forms.DockStyle.Fill
         Me._rasterImageViewer.ScrollMode = ControlScrollMode.Auto
         Me._rasterImageViewer.ViewMargin = New System.Windows.Forms.Padding(1)
         Me._rasterImageViewer.ImageBorderThickness = 2
         Me._rasterImageViewer.ViewHorizontalAlignment = ControlAlignment.Center
         Me._rasterImageViewer.Location = New System.Drawing.Point(0, 38)
         Me._rasterImageViewer.Name = "_rasterImageViewer"
         Me._rasterImageViewer.Size = New System.Drawing.Size(619, 370)
         Me._rasterImageViewer.Zoom(ControlSizeMode.FitAlways, 1, _rasterImageViewer.DefaultZoomOrigin)
         Me._rasterImageViewer.TabIndex = 13
         Me._rasterImageViewer.UseDpi = True
         Me._rasterImageViewer.ViewVerticalAlignment = ControlAlignment.Center
         ' 
         ' _highlightTextModeToolStripButton
         ' 
         Me._highlightTextModeToolStripButton.CheckOnClick = True
         Me._highlightTextModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._highlightTextModeToolStripButton.Image = Global.PDFDocumentDemo.Resources.HighlightText
         Me._highlightTextModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
         Me._highlightTextModeToolStripButton.Name = "_highlightTextModeToolStripButton"
         Me._highlightTextModeToolStripButton.Size = New System.Drawing.Size(23, 22)
         Me._highlightTextModeToolStripButton.ToolTipText = resources.GetString("resx_SelectTheTextToHighlight")
         ' 
         ' ViewerControl
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me._rasterImageViewer)
         Me.Controls.Add(Me._pageInfoLabel)
         Me.Controls.Add(Me._mousePositionLabel)
         Me.Controls.Add(Me._toolStrip)
         Me.Name = "ViewerControl"
         Me.Size = New System.Drawing.Size(619, 421)
         Me._toolStrip.ResumeLayout(False)
         Me._toolStrip.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _pageInfoLabel As System.Windows.Forms.Label
      Private WithEvents _zoomToSelectionModeToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _panModeToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _selectModeToolStripButton As System.Windows.Forms.ToolStripButton
      Private _mousePositionLabel As System.Windows.Forms.Label
      Private _toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _fitPageToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _pageToolStripTextBox As System.Windows.Forms.ToolStripTextBox
      Private WithEvents _nextPageToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _previousPageToolStripButton As System.Windows.Forms.ToolStripButton
      Private _toolStrip As System.Windows.Forms.ToolStrip
      Private _pageToolStripLabel As System.Windows.Forms.ToolStripLabel
      Private _toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _zoomOutToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _zoomInToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _zoomToolStripComboBox As System.Windows.Forms.ToolStripComboBox
      Private WithEvents _fitPageWidthToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _rasterImageViewer As AutomationImageViewer
      Private _toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _highlightObjectsToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _highlightTextModeToolStripButton As System.Windows.Forms.ToolStripButton
   End Class
End Namespace
