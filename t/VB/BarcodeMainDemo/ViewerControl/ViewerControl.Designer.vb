Imports Leadtools.Controls
Imports Leadtools

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
      Me._regionModeToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._deleteRegionToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._readBarcodeModeToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._writeBarcodeModeToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me._showBarcodesToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._mousePositionLabel = New System.Windows.Forms.Label()
      Me._rasterImageViewer = New ImageViewer()
      Me._toolStrip.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _pageInfoLabel
      ' 
      resources.ApplyResources(Me._pageInfoLabel, "_pageInfoLabel")
      Me._pageInfoLabel.Name = "_pageInfoLabel"
      ' 
      ' _toolStrip
      ' 
      Me._toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._previousPageToolStripButton, Me._nextPageToolStripButton, Me._pageToolStripTextBox, Me._pageToolStripLabel, Me._toolStripSeparator1, Me._zoomOutToolStripButton, Me._zoomInToolStripButton, Me._zoomToolStripComboBox, Me._fitPageWidthToolStripButton, Me._fitPageToolStripButton, Me._toolStripSeparator2, Me._selectModeToolStripButton, Me._panModeToolStripButton, Me._zoomToSelectionModeToolStripButton, Me._regionModeToolStripButton, Me._deleteRegionToolStripButton, Me._readBarcodeModeToolStripButton, Me._writeBarcodeModeToolStripButton, Me._toolStripSeparator3, Me._showBarcodesToolStripButton})
      resources.ApplyResources(Me._toolStrip, "_toolStrip")
      Me._toolStrip.Name = "_toolStrip"
      ' 
      ' _previousPageToolStripButton
      ' 
      Me._previousPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._previousPageToolStripButton.Image = Global.BarcodeMainDemo.Resources.PreviousPage
      resources.ApplyResources(Me._previousPageToolStripButton, "_previousPageToolStripButton")
      Me._previousPageToolStripButton.Name = "_previousPageToolStripButton"
      ' 
      ' _nextPageToolStripButton
      ' 
      Me._nextPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._nextPageToolStripButton.Image = Global.BarcodeMainDemo.Resources.NextPage
      resources.ApplyResources(Me._nextPageToolStripButton, "_nextPageToolStripButton")
      Me._nextPageToolStripButton.Name = "_nextPageToolStripButton"
      ' 
      ' _pageToolStripTextBox
      ' 
      Me._pageToolStripTextBox.Name = "_pageToolStripTextBox"
      resources.ApplyResources(Me._pageToolStripTextBox, "_pageToolStripTextBox")
      ' 
      ' _pageToolStripLabel
      ' 
      Me._pageToolStripLabel.Name = "_pageToolStripLabel"
      resources.ApplyResources(Me._pageToolStripLabel, "_pageToolStripLabel")
      ' 
      ' _toolStripSeparator1
      ' 
      Me._toolStripSeparator1.Name = "_toolStripSeparator1"
      resources.ApplyResources(Me._toolStripSeparator1, "_toolStripSeparator1")
      ' 
      ' _zoomOutToolStripButton
      ' 
      Me._zoomOutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._zoomOutToolStripButton.Image = Global.BarcodeMainDemo.Resources.ZoomOut
      resources.ApplyResources(Me._zoomOutToolStripButton, "_zoomOutToolStripButton")
      Me._zoomOutToolStripButton.Name = "_zoomOutToolStripButton"
      ' 
      ' _zoomInToolStripButton
      ' 
      Me._zoomInToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._zoomInToolStripButton.Image = Global.BarcodeMainDemo.Resources.ZoomIn
      resources.ApplyResources(Me._zoomInToolStripButton, "_zoomInToolStripButton")
      Me._zoomInToolStripButton.Name = "_zoomInToolStripButton"
      ' 
      ' _zoomToolStripComboBox
      ' 
      Me._zoomToolStripComboBox.DropDownWidth = 80
      Me._zoomToolStripComboBox.Items.AddRange(New Object() {resources.GetString("_zoomToolStripComboBox.Items"), resources.GetString("_zoomToolStripComboBox.Items1"), resources.GetString("_zoomToolStripComboBox.Items2"), resources.GetString("_zoomToolStripComboBox.Items3"), resources.GetString("_zoomToolStripComboBox.Items4"), resources.GetString("_zoomToolStripComboBox.Items5"), resources.GetString("_zoomToolStripComboBox.Items6"), resources.GetString("_zoomToolStripComboBox.Items7"), resources.GetString("_zoomToolStripComboBox.Items8"), resources.GetString("_zoomToolStripComboBox.Items9"), resources.GetString("_zoomToolStripComboBox.Items10"), resources.GetString("_zoomToolStripComboBox.Items11"), resources.GetString("_zoomToolStripComboBox.Items12"), resources.GetString("_zoomToolStripComboBox.Items13"), resources.GetString("_zoomToolStripComboBox.Items14"), resources.GetString("_zoomToolStripComboBox.Items15")})
      Me._zoomToolStripComboBox.Name = "_zoomToolStripComboBox"
      resources.ApplyResources(Me._zoomToolStripComboBox, "_zoomToolStripComboBox")
      ' 
      ' _fitPageWidthToolStripButton
      ' 
      Me._fitPageWidthToolStripButton.CheckOnClick = True
      Me._fitPageWidthToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._fitPageWidthToolStripButton.Image = Global.BarcodeMainDemo.Resources.FitPageWidth
      resources.ApplyResources(Me._fitPageWidthToolStripButton, "_fitPageWidthToolStripButton")
      Me._fitPageWidthToolStripButton.Name = "_fitPageWidthToolStripButton"
      ' 
      ' _fitPageToolStripButton
      ' 
      Me._fitPageToolStripButton.CheckOnClick = True
      Me._fitPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._fitPageToolStripButton.Image = Global.BarcodeMainDemo.Resources.FitPage
      resources.ApplyResources(Me._fitPageToolStripButton, "_fitPageToolStripButton")
      Me._fitPageToolStripButton.Name = "_fitPageToolStripButton"
      ' 
      ' _toolStripSeparator2
      ' 
      Me._toolStripSeparator2.Name = "_toolStripSeparator2"
      resources.ApplyResources(Me._toolStripSeparator2, "_toolStripSeparator2")
      ' 
      ' _selectModeToolStripButton
      ' 
      Me._selectModeToolStripButton.CheckOnClick = True
      Me._selectModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._selectModeToolStripButton.Image = Global.BarcodeMainDemo.Resources.SelectMode
      resources.ApplyResources(Me._selectModeToolStripButton, "_selectModeToolStripButton")
      Me._selectModeToolStripButton.Name = "_selectModeToolStripButton"
      ' 
      ' _panModeToolStripButton
      ' 
      Me._panModeToolStripButton.CheckOnClick = True
      Me._panModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._panModeToolStripButton.Image = Global.BarcodeMainDemo.Resources.PanMode
      resources.ApplyResources(Me._panModeToolStripButton, "_panModeToolStripButton")
      Me._panModeToolStripButton.Name = "_panModeToolStripButton"
      ' 
      ' _zoomToSelectionModeToolStripButton
      ' 
      Me._zoomToSelectionModeToolStripButton.CheckOnClick = True
      Me._zoomToSelectionModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._zoomToSelectionModeToolStripButton.Image = Global.BarcodeMainDemo.Resources.ZoomSelection
      resources.ApplyResources(Me._zoomToSelectionModeToolStripButton, "_zoomToSelectionModeToolStripButton")
      Me._zoomToSelectionModeToolStripButton.Name = "_zoomToSelectionModeToolStripButton"
      ' 
      ' _regionModeToolStripButton
      ' 
      Me._regionModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._regionModeToolStripButton.Image = Global.BarcodeMainDemo.Resources.RegionMode
      resources.ApplyResources(Me._regionModeToolStripButton, "_regionModeToolStripButton")
      Me._regionModeToolStripButton.Name = "_regionModeToolStripButton"
      ' 
      ' _deleteRegionToolStripButton
      ' 
      Me._deleteRegionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._deleteRegionToolStripButton.Image = Global.BarcodeMainDemo.Resources.DeleteRegion
      resources.ApplyResources(Me._deleteRegionToolStripButton, "_deleteRegionToolStripButton")
      Me._deleteRegionToolStripButton.Name = "_deleteRegionToolStripButton"
      ' 
      ' _readBarcodeModeToolStripButton
      ' 
      Me._readBarcodeModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._readBarcodeModeToolStripButton.Image = Global.BarcodeMainDemo.Resources.ReadBarcodes
      resources.ApplyResources(Me._readBarcodeModeToolStripButton, "_readBarcodeModeToolStripButton")
      Me._readBarcodeModeToolStripButton.Name = "_readBarcodeModeToolStripButton"
      ' 
      ' _writeBarcodeModeToolStripButton
      ' 
      Me._writeBarcodeModeToolStripButton.CheckOnClick = True
      Me._writeBarcodeModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._writeBarcodeModeToolStripButton.Image = Global.BarcodeMainDemo.Resources.WriteBarcodeMode
      resources.ApplyResources(Me._writeBarcodeModeToolStripButton, "_writeBarcodeModeToolStripButton")
      Me._writeBarcodeModeToolStripButton.Name = "_writeBarcodeModeToolStripButton"
      ' 
      ' _toolStripSeparator3
      ' 
      Me._toolStripSeparator3.Name = "_toolStripSeparator3"
      resources.ApplyResources(Me._toolStripSeparator3, "_toolStripSeparator3")
      ' 
      ' _showBarcodesToolStripButton
      ' 
      Me._showBarcodesToolStripButton.Checked = True
      Me._showBarcodesToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked
      Me._showBarcodesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._showBarcodesToolStripButton.Image = Global.BarcodeMainDemo.Resources.ShowBarcodes
      resources.ApplyResources(Me._showBarcodesToolStripButton, "_showBarcodesToolStripButton")
      Me._showBarcodesToolStripButton.Name = "_showBarcodesToolStripButton"
      ' 
      ' _mousePositionLabel
      ' 
      resources.ApplyResources(Me._mousePositionLabel, "_mousePositionLabel")
      Me._mousePositionLabel.Name = "_mousePositionLabel"
      ' 
      ' _rasterImageViewer
      ' 
      Me._rasterImageViewer.ImageRegionRenderMode = ControlRegionRenderMode.None
      Me._rasterImageViewer.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me._rasterImageViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      resources.ApplyResources(Me._rasterImageViewer, "_rasterImageViewer")
      Me._rasterImageViewer.AutoScroll = True
      Me._rasterImageViewer.ViewHorizontalAlignment = ControlAlignment.Center
      Me._rasterImageViewer.Name = "_rasterImageViewer"
      Me._rasterImageViewer.Zoom(ControlSizeMode.FitAlways, _rasterImageViewer.ScaleFactor, _rasterImageViewer.DefaultZoomOrigin)
      Me._rasterImageViewer.UseDpi = True
      Me._rasterImageViewer.ViewVerticalAlignment = ControlAlignment.Center
      ' 
      ' ViewerControl
      ' 
      resources.ApplyResources(Me, "$this")
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._rasterImageViewer)
      Me.Controls.Add(Me._mousePositionLabel)
      Me.Controls.Add(Me._toolStrip)
      Me.Controls.Add(Me._pageInfoLabel)
      Me.Name = "ViewerControl"
      Me._toolStrip.ResumeLayout(False)
      Me._toolStrip.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _pageInfoLabel As System.Windows.Forms.Label
   Public _toolStrip As System.Windows.Forms.ToolStrip
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
   Private WithEvents _regionModeToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _deleteRegionToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _writeBarcodeModeToolStripButton As System.Windows.Forms.ToolStripButton
   Private _toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _showBarcodesToolStripButton As System.Windows.Forms.ToolStripButton
   Private _mousePositionLabel As System.Windows.Forms.Label
   Private WithEvents _rasterImageViewer As ImageViewer
   Private WithEvents _readBarcodeModeToolStripButton As System.Windows.Forms.ToolStripButton
End Class
