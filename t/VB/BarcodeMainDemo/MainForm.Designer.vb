
Imports System.Windows.Forms

Partial Class MainForm
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

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me._mainMenuStrip = New System.Windows.Forms.MenuStrip()
        Me._fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._newToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._openToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._saveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._closeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._fileSep1toolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
        Me._scanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._selectSourceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._acquireToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._fileSep2ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
        Me._exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._editToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._copyImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._pasteImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._viewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._zoomOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._zoomInToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._editSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
        Me._fitWidthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._fitPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._pageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._previousPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._nextPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._gotoPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._interactiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._selectModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._panModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._zoomToModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._drawRegionModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._readBarcodeModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._writeBarcodeModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._interactiveSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
        Me._deleteRegionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._preprocessingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._preprocessAllPagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._preprocessingSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
        Me._flipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._reverseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._rotate90ClockwiseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._rotate90CounterclockwiseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._noiseFiltersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._noiseMinFilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._noiseMedianFilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._noiseMaxFilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._lineRemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._imageDeskewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._segmentationPerspectiveMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._perspectiveDeskewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._barcodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._readBarcodesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._readBarcodeOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._barcodeImageTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._scannedDocumentImageTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._pictureImageTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._unknownImageTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._barcodeBoundaryTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._rectangleBoundaryTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._fourPointsBoundaryTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._writeBarcodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._barcodeSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
        Me._showBarcodesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._barcodeSep2ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
        Me._saveCurrentReadOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._loadReadOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._saveCurrentWriteOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._loadWriteOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._barcodeSep3ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
        Me._deleteSelectedBarcodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._zoomToSelectedBarcodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._exportBarcodesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._clearAllBarcodesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._mainToolStrip = New System.Windows.Forms.ToolStrip()
        Me._newToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me._openToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me._saveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me._toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me._readBarcodesToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me._readBarcodeOptionsToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me._writeBarcodeToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me._mainStatusStrip = New System.Windows.Forms.StatusStrip()
        Me._viewerSplitter = New System.Windows.Forms.Splitter()
        Me._viewerControl = New ViewerControl()
        Me._barcodeControl = New BarcodeControl()
        Me._pagesControl = New PagesControl()
        Me._mainMenuStrip.SuspendLayout()
        Me._mainToolStrip.SuspendLayout()
        Me.SuspendLayout()
        ' 
        ' _mainMenuStrip
        ' 
        Me._mainMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._fileToolStripMenuItem, Me._editToolStripMenuItem, Me._viewToolStripMenuItem, Me._pageToolStripMenuItem, Me._interactiveToolStripMenuItem, Me._preprocessingToolStripMenuItem, Me._barcodeToolStripMenuItem, Me._helpToolStripMenuItem})
        resources.ApplyResources(Me._mainMenuStrip, "_mainMenuStrip")
        Me._mainMenuStrip.Name = "_mainMenuStrip"
        ' 
        ' _fileToolStripMenuItem
        ' 
        Me._fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._newToolStripMenuItem, Me._openToolStripMenuItem, Me._saveToolStripMenuItem, Me._closeToolStripMenuItem, Me._fileSep1toolStripMenuItem, Me._scanToolStripMenuItem, Me._fileSep2ToolStripMenuItem, Me._exitToolStripMenuItem})
        Me._fileToolStripMenuItem.Name = "_fileToolStripMenuItem"
        resources.ApplyResources(Me._fileToolStripMenuItem, "_fileToolStripMenuItem")
        ' 
        ' _newToolStripMenuItem
        ' 
        Me._newToolStripMenuItem.Image = Global.BarcodeMainDemo.Resources.NewDocument
        Me._newToolStripMenuItem.Name = "_newToolStripMenuItem"
        resources.ApplyResources(Me._newToolStripMenuItem, "_newToolStripMenuItem")
        ' 
        ' _openToolStripMenuItem
        ' 
        Me._openToolStripMenuItem.Image = Global.BarcodeMainDemo.Resources.OpenDocument
        Me._openToolStripMenuItem.Name = "_openToolStripMenuItem"
        resources.ApplyResources(Me._openToolStripMenuItem, "_openToolStripMenuItem")
        ' 
        ' _saveToolStripMenuItem
        ' 
        Me._saveToolStripMenuItem.Image = Global.BarcodeMainDemo.Resources.SaveDocument
        Me._saveToolStripMenuItem.Name = "_saveToolStripMenuItem"
        resources.ApplyResources(Me._saveToolStripMenuItem, "_saveToolStripMenuItem")
        ' 
        ' _closeToolStripMenuItem
        ' 
        Me._closeToolStripMenuItem.Name = "_closeToolStripMenuItem"
        resources.ApplyResources(Me._closeToolStripMenuItem, "_closeToolStripMenuItem")
        ' 
        ' _fileSep1toolStripMenuItem
        ' 
        Me._fileSep1toolStripMenuItem.Name = "_fileSep1toolStripMenuItem"
        resources.ApplyResources(Me._fileSep1toolStripMenuItem, "_fileSep1toolStripMenuItem")
        ' 
        ' _scanToolStripMenuItem
        ' 
        Me._scanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._selectSourceToolStripMenuItem, Me._acquireToolStripMenuItem})
        Me._scanToolStripMenuItem.Name = "_scanToolStripMenuItem"
        resources.ApplyResources(Me._scanToolStripMenuItem, "_scanToolStripMenuItem")
        ' 
        ' _selectSourceToolStripMenuItem
        ' 
        Me._selectSourceToolStripMenuItem.Name = "_selectSourceToolStripMenuItem"
        resources.ApplyResources(Me._selectSourceToolStripMenuItem, "_selectSourceToolStripMenuItem")
        ' 
        ' _acquireToolStripMenuItem
        ' 
        Me._acquireToolStripMenuItem.Name = "_acquireToolStripMenuItem"
        resources.ApplyResources(Me._acquireToolStripMenuItem, "_acquireToolStripMenuItem")
        ' 
        ' _fileSep2ToolStripMenuItem
        ' 
        Me._fileSep2ToolStripMenuItem.Name = "_fileSep2ToolStripMenuItem"
        resources.ApplyResources(Me._fileSep2ToolStripMenuItem, "_fileSep2ToolStripMenuItem")
        ' 
        ' _exitToolStripMenuItem
        ' 
        Me._exitToolStripMenuItem.Name = "_exitToolStripMenuItem"
        resources.ApplyResources(Me._exitToolStripMenuItem, "_exitToolStripMenuItem")
        ' 
        ' _editToolStripMenuItem
        ' 
        Me._editToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._copyImageToolStripMenuItem, Me._pasteImageToolStripMenuItem})
        Me._editToolStripMenuItem.Name = "_editToolStripMenuItem"
        resources.ApplyResources(Me._editToolStripMenuItem, "_editToolStripMenuItem")
        ' 
        ' _copyImageToolStripMenuItem
        ' 
        Me._copyImageToolStripMenuItem.Name = "_copyImageToolStripMenuItem"
        resources.ApplyResources(Me._copyImageToolStripMenuItem, "_copyImageToolStripMenuItem")
        ' 
        ' _pasteImageToolStripMenuItem
        ' 
        Me._pasteImageToolStripMenuItem.Name = "_pasteImageToolStripMenuItem"
        resources.ApplyResources(Me._pasteImageToolStripMenuItem, "_pasteImageToolStripMenuItem")
        ' 
        ' _viewToolStripMenuItem
        ' 
        Me._viewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._zoomOutToolStripMenuItem, Me._zoomInToolStripMenuItem, Me._editSep1ToolStripMenuItem, Me._fitWidthToolStripMenuItem, Me._fitPageToolStripMenuItem})
        Me._viewToolStripMenuItem.Name = "_viewToolStripMenuItem"
        resources.ApplyResources(Me._viewToolStripMenuItem, "_viewToolStripMenuItem")
        ' 
        ' _zoomOutToolStripMenuItem
        ' 
        Me._zoomOutToolStripMenuItem.Image = Global.BarcodeMainDemo.Resources.ZoomOut
        Me._zoomOutToolStripMenuItem.Name = "_zoomOutToolStripMenuItem"
        resources.ApplyResources(Me._zoomOutToolStripMenuItem, "_zoomOutToolStripMenuItem")
        ' 
        ' _zoomInToolStripMenuItem
        ' 
        Me._zoomInToolStripMenuItem.Image = Global.BarcodeMainDemo.Resources.ZoomIn
        Me._zoomInToolStripMenuItem.Name = "_zoomInToolStripMenuItem"
        resources.ApplyResources(Me._zoomInToolStripMenuItem, "_zoomInToolStripMenuItem")
        ' 
        ' _editSep1ToolStripMenuItem
        ' 
        Me._editSep1ToolStripMenuItem.Name = "_editSep1ToolStripMenuItem"
        resources.ApplyResources(Me._editSep1ToolStripMenuItem, "_editSep1ToolStripMenuItem")
        ' 
        ' _fitWidthToolStripMenuItem
        ' 
        Me._fitWidthToolStripMenuItem.Image = Global.BarcodeMainDemo.Resources.FitPageWidth
        Me._fitWidthToolStripMenuItem.Name = "_fitWidthToolStripMenuItem"
        resources.ApplyResources(Me._fitWidthToolStripMenuItem, "_fitWidthToolStripMenuItem")
        ' 
        ' _fitPageToolStripMenuItem
        ' 
        Me._fitPageToolStripMenuItem.Image = Global.BarcodeMainDemo.Resources.FitPage
        Me._fitPageToolStripMenuItem.Name = "_fitPageToolStripMenuItem"
        resources.ApplyResources(Me._fitPageToolStripMenuItem, "_fitPageToolStripMenuItem")
        ' 
        ' _pageToolStripMenuItem
        ' 
        Me._pageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._previousPageToolStripMenuItem, Me._nextPageToolStripMenuItem, Me._gotoPageToolStripMenuItem})
        Me._pageToolStripMenuItem.Name = "_pageToolStripMenuItem"
        resources.ApplyResources(Me._pageToolStripMenuItem, "_pageToolStripMenuItem")
        ' 
        ' _previousPageToolStripMenuItem
        ' 
        Me._previousPageToolStripMenuItem.Image = Global.BarcodeMainDemo.Resources.PreviousPage
        Me._previousPageToolStripMenuItem.Name = "_previousPageToolStripMenuItem"
        resources.ApplyResources(Me._previousPageToolStripMenuItem, "_previousPageToolStripMenuItem")
        ' 
        ' _nextPageToolStripMenuItem
        ' 
        Me._nextPageToolStripMenuItem.Image = Global.BarcodeMainDemo.Resources.NextPage
        Me._nextPageToolStripMenuItem.Name = "_nextPageToolStripMenuItem"
        resources.ApplyResources(Me._nextPageToolStripMenuItem, "_nextPageToolStripMenuItem")
        ' 
        ' _gotoPageToolStripMenuItem
        ' 
        Me._gotoPageToolStripMenuItem.Name = "_gotoPageToolStripMenuItem"
        resources.ApplyResources(Me._gotoPageToolStripMenuItem, "_gotoPageToolStripMenuItem")
        ' 
        ' _interactiveToolStripMenuItem
        ' 
        Me._interactiveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._selectModeToolStripMenuItem, Me._panModeToolStripMenuItem, Me._zoomToModeToolStripMenuItem, Me._drawRegionModeToolStripMenuItem, Me._readBarcodeModeToolStripMenuItem, Me._writeBarcodeModeToolStripMenuItem, Me._interactiveSep1ToolStripMenuItem, Me._deleteRegionToolStripMenuItem})
        Me._interactiveToolStripMenuItem.Name = "_interactiveToolStripMenuItem"
        resources.ApplyResources(Me._interactiveToolStripMenuItem, "_interactiveToolStripMenuItem")
        ' 
        ' _selectModeToolStripMenuItem
        ' 
        Me._selectModeToolStripMenuItem.Image = Global.BarcodeMainDemo.Resources.SelectMode
        Me._selectModeToolStripMenuItem.Name = "_selectModeToolStripMenuItem"
        resources.ApplyResources(Me._selectModeToolStripMenuItem, "_selectModeToolStripMenuItem")
        ' 
        ' _panModeToolStripMenuItem
        ' 
        Me._panModeToolStripMenuItem.Image = Global.BarcodeMainDemo.Resources.PanMode
        Me._panModeToolStripMenuItem.Name = "_panModeToolStripMenuItem"
        resources.ApplyResources(Me._panModeToolStripMenuItem, "_panModeToolStripMenuItem")
        ' 
        ' _zoomToModeToolStripMenuItem
        ' 
        Me._zoomToModeToolStripMenuItem.Image = Global.BarcodeMainDemo.Resources.ZoomSelection
        Me._zoomToModeToolStripMenuItem.Name = "_zoomToModeToolStripMenuItem"
        resources.ApplyResources(Me._zoomToModeToolStripMenuItem, "_zoomToModeToolStripMenuItem")
        ' 
        ' _drawRegionModeToolStripMenuItem
        ' 
        Me._drawRegionModeToolStripMenuItem.Image = Global.BarcodeMainDemo.Resources.RegionMode
        Me._drawRegionModeToolStripMenuItem.Name = "_drawRegionModeToolStripMenuItem"
        resources.ApplyResources(Me._drawRegionModeToolStripMenuItem, "_drawRegionModeToolStripMenuItem")
        ' 
        ' _readBarcodeModeToolStripMenuItem
        ' 
        Me._readBarcodeModeToolStripMenuItem.Image = Global.BarcodeMainDemo.Resources.ReadBarcodes
        Me._readBarcodeModeToolStripMenuItem.Name = "_readBarcodeModeToolStripMenuItem"
        resources.ApplyResources(Me._readBarcodeModeToolStripMenuItem, "_readBarcodeModeToolStripMenuItem")
        ' 
        ' _writeBarcodeModeToolStripMenuItem
        ' 
        Me._writeBarcodeModeToolStripMenuItem.Image = Global.BarcodeMainDemo.Resources.WriteBarcodeMode
        Me._writeBarcodeModeToolStripMenuItem.Name = "_writeBarcodeModeToolStripMenuItem"
        resources.ApplyResources(Me._writeBarcodeModeToolStripMenuItem, "_writeBarcodeModeToolStripMenuItem")
        ' 
        ' _interactiveSep1ToolStripMenuItem
        ' 
        Me._interactiveSep1ToolStripMenuItem.Name = "_interactiveSep1ToolStripMenuItem"
        resources.ApplyResources(Me._interactiveSep1ToolStripMenuItem, "_interactiveSep1ToolStripMenuItem")
        ' 
        ' _deleteRegionToolStripMenuItem
        ' 
        Me._deleteRegionToolStripMenuItem.Image = Global.BarcodeMainDemo.Resources.DeleteRegion
        Me._deleteRegionToolStripMenuItem.Name = "_deleteRegionToolStripMenuItem"
        resources.ApplyResources(Me._deleteRegionToolStripMenuItem, "_deleteRegionToolStripMenuItem")
        ' 
        ' _preprocessingToolStripMenuItem
        ' 
        Me._preprocessingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._preprocessAllPagesToolStripMenuItem, Me._preprocessingSep1ToolStripMenuItem, Me._flipToolStripMenuItem, Me._reverseToolStripMenuItem, Me._rotate90ClockwiseToolStripMenuItem, Me._rotate90CounterclockwiseToolStripMenuItem, Me._noiseFiltersToolStripMenuItem, Me._lineRemoveToolStripMenuItem, Me._imageDeskewToolStripMenuItem, Me._segmentationPerspectiveMenuItem, Me._perspectiveDeskewToolStripMenuItem})
        Me._preprocessingToolStripMenuItem.Name = "_preprocessingToolStripMenuItem"
        resources.ApplyResources(Me._preprocessingToolStripMenuItem, "_preprocessingToolStripMenuItem")
        ' 
        ' _preprocessAllPagesToolStripMenuItem
        ' 
        Me._preprocessAllPagesToolStripMenuItem.Checked = True
        Me._preprocessAllPagesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me._preprocessAllPagesToolStripMenuItem.Name = "_preprocessAllPagesToolStripMenuItem"
        resources.ApplyResources(Me._preprocessAllPagesToolStripMenuItem, "_preprocessAllPagesToolStripMenuItem")
        ' 
        ' _preprocessingSep1ToolStripMenuItem
        ' 
        Me._preprocessingSep1ToolStripMenuItem.Name = "_preprocessingSep1ToolStripMenuItem"
        resources.ApplyResources(Me._preprocessingSep1ToolStripMenuItem, "_preprocessingSep1ToolStripMenuItem")
        ' 
        ' _flipToolStripMenuItem
        ' 
        Me._flipToolStripMenuItem.Name = "_flipToolStripMenuItem"
        resources.ApplyResources(Me._flipToolStripMenuItem, "_flipToolStripMenuItem")
        ' 
        ' _reverseToolStripMenuItem
        ' 
        Me._reverseToolStripMenuItem.Name = "_reverseToolStripMenuItem"
        resources.ApplyResources(Me._reverseToolStripMenuItem, "_reverseToolStripMenuItem")
        ' 
        ' _rotate90ClockwiseToolStripMenuItem
        ' 
        Me._rotate90ClockwiseToolStripMenuItem.Name = "_rotate90ClockwiseToolStripMenuItem"
        resources.ApplyResources(Me._rotate90ClockwiseToolStripMenuItem, "_rotate90ClockwiseToolStripMenuItem")
        ' 
        ' _rotate90CounterclockwiseToolStripMenuItem
        ' 
        Me._rotate90CounterclockwiseToolStripMenuItem.Name = "_rotate90CounterclockwiseToolStripMenuItem"
        resources.ApplyResources(Me._rotate90CounterclockwiseToolStripMenuItem, "_rotate90CounterclockwiseToolStripMenuItem")
        ' 
        ' _noiseFiltersToolStripMenuItem
        ' 
        Me._noiseFiltersToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._noiseMinFilterToolStripMenuItem, Me._noiseMedianFilterToolStripMenuItem, Me._noiseMaxFilterToolStripMenuItem})
        Me._noiseFiltersToolStripMenuItem.Name = "_noiseFiltersToolStripMenuItem"
        resources.ApplyResources(Me._noiseFiltersToolStripMenuItem, "_noiseFiltersToolStripMenuItem")
        ' 
        ' _noiseMinFilterToolStripMenuItem
        ' 
        Me._noiseMinFilterToolStripMenuItem.Name = "_noiseMinFilterToolStripMenuItem"
        resources.ApplyResources(Me._noiseMinFilterToolStripMenuItem, "_noiseMinFilterToolStripMenuItem")
        ' 
        ' _noiseMedianFilterToolStripMenuItem
        ' 
        Me._noiseMedianFilterToolStripMenuItem.Name = "_noiseMedianFilterToolStripMenuItem"
        resources.ApplyResources(Me._noiseMedianFilterToolStripMenuItem, "_noiseMedianFilterToolStripMenuItem")
        ' 
        ' _noiseMaxFilterToolStripMenuItem
        ' 
        Me._noiseMaxFilterToolStripMenuItem.Name = "_noiseMaxFilterToolStripMenuItem"
        resources.ApplyResources(Me._noiseMaxFilterToolStripMenuItem, "_noiseMaxFilterToolStripMenuItem")
        ' 
        ' _lineRemoveToolStripMenuItem
        ' 
        Me._lineRemoveToolStripMenuItem.Name = "_lineRemoveToolStripMenuItem"
        resources.ApplyResources(Me._lineRemoveToolStripMenuItem, "_lineRemoveToolStripMenuItem")
        ' 
        ' _imageDeskewToolStripMenuItem
        ' 
        Me._imageDeskewToolStripMenuItem.Name = "_imageDeskewToolStripMenuItem"
        resources.ApplyResources(Me._imageDeskewToolStripMenuItem, "_imageDeskewToolStripMenuItem")
        ' 
        ' _segmentationPerspectiveMenuItem
        ' 
        Me._segmentationPerspectiveMenuItem.Name = "_segmentationPerspectiveMenuItem"
        resources.ApplyResources(Me._segmentationPerspectiveMenuItem, "_segmentationPerspectiveMenuItem")
        ' 
        ' _perspectiveDeskewToolStripMenuItem
        ' 
        Me._perspectiveDeskewToolStripMenuItem.Name = "_perspectiveDeskewToolStripMenuItem"
        resources.ApplyResources(Me._perspectiveDeskewToolStripMenuItem, "_perspectiveDeskewToolStripMenuItem")
        ' 
        ' _barcodeToolStripMenuItem
        ' 
        Me._barcodeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._readBarcodesToolStripMenuItem, Me._readBarcodeOptionsToolStripMenuItem, Me._barcodeImageTypeToolStripMenuItem, Me._barcodeBoundaryTypeToolStripMenuItem, Me._writeBarcodeToolStripMenuItem, Me._barcodeSep1ToolStripMenuItem, Me._showBarcodesToolStripMenuItem, Me._barcodeSep2ToolStripMenuItem, Me._saveCurrentReadOptionsToolStripMenuItem, Me._loadReadOptionsToolStripMenuItem, Me._saveCurrentWriteOptionsToolStripMenuItem, Me._loadWriteOptionsToolStripMenuItem, Me._barcodeSep3ToolStripMenuItem, Me._deleteSelectedBarcodeToolStripMenuItem, Me._zoomToSelectedBarcodeToolStripMenuItem, Me._exportBarcodesToolStripMenuItem, Me._clearAllBarcodesToolStripMenuItem})
        Me._barcodeToolStripMenuItem.Name = "_barcodeToolStripMenuItem"
        resources.ApplyResources(Me._barcodeToolStripMenuItem, "_barcodeToolStripMenuItem")
        ' 
        ' _readBarcodesToolStripMenuItem
        ' 
        Me._readBarcodesToolStripMenuItem.Image = Global.BarcodeMainDemo.Resources.ReadBarcodes
        Me._readBarcodesToolStripMenuItem.Name = "_readBarcodesToolStripMenuItem"
        resources.ApplyResources(Me._readBarcodesToolStripMenuItem, "_readBarcodesToolStripMenuItem")
        ' 
        ' _readBarcodeOptionsToolStripMenuItem
        ' 
        Me._readBarcodeOptionsToolStripMenuItem.Image = Global.BarcodeMainDemo.Resources.ReadBarcodeOptions
        Me._readBarcodeOptionsToolStripMenuItem.Name = "_readBarcodeOptionsToolStripMenuItem"
        resources.ApplyResources(Me._readBarcodeOptionsToolStripMenuItem, "_readBarcodeOptionsToolStripMenuItem")
        ' 
        ' _barcodeImageTypeToolStripMenuItem
        ' 
        Me._barcodeImageTypeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._scannedDocumentImageTypeToolStripMenuItem, Me._pictureImageTypeToolStripMenuItem, Me._unknownImageTypeToolStripMenuItem})
        Me._barcodeImageTypeToolStripMenuItem.Name = "_barcodeImageTypeToolStripMenuItem"
        resources.ApplyResources(Me._barcodeImageTypeToolStripMenuItem, "_barcodeImageTypeToolStripMenuItem")
        ' 
        ' _scannedDocumentImageTypeToolStripMenuItem
        ' 
        Me._scannedDocumentImageTypeToolStripMenuItem.Name = "_scannedDocumentImageTypeToolStripMenuItem"
        resources.ApplyResources(Me._scannedDocumentImageTypeToolStripMenuItem, "_scannedDocumentImageTypeToolStripMenuItem")
        ' 
        ' _pictureImageTypeToolStripMenuItem
        ' 
        Me._pictureImageTypeToolStripMenuItem.Name = "_pictureImageTypeToolStripMenuItem"
        resources.ApplyResources(Me._pictureImageTypeToolStripMenuItem, "_pictureImageTypeToolStripMenuItem")
        ' 
        ' _unknownImageTypeToolStripMenuItem
        ' 
        Me._unknownImageTypeToolStripMenuItem.Name = "_unknownImageTypeToolStripMenuItem"
        resources.ApplyResources(Me._unknownImageTypeToolStripMenuItem, "_unknownImageTypeToolStripMenuItem")
        ' 
        ' _barcodeBoundaryTypeToolStripMenuItem
        ' 
        Me._barcodeBoundaryTypeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._rectangleBoundaryTypeToolStripMenuItem, Me._fourPointsBoundaryTypeToolStripMenuItem})
        Me._barcodeBoundaryTypeToolStripMenuItem.Name = "_barcodeBoundaryTypeToolStripMenuItem"
        resources.ApplyResources(Me._barcodeBoundaryTypeToolStripMenuItem, "_barcodeBoundaryTypeToolStripMenuItem")
        ' 
        ' _rectangleBoundaryTypeToolStripMenuItem
        ' 
        Me._rectangleBoundaryTypeToolStripMenuItem.Name = "_rectangleBoundaryTypeToolStripMenuItem"
        resources.ApplyResources(Me._rectangleBoundaryTypeToolStripMenuItem, "_rectangleBoundaryTypeToolStripMenuItem")
        ' 
        ' _fourPointsBoundaryTypeToolStripMenuItem
        ' 
        Me._fourPointsBoundaryTypeToolStripMenuItem.Name = "_fourPointsBoundaryTypeToolStripMenuItem"
        resources.ApplyResources(Me._fourPointsBoundaryTypeToolStripMenuItem, "_fourPointsBoundaryTypeToolStripMenuItem")
        ' 
        ' _writeBarcodeToolStripMenuItem
        ' 
        Me._writeBarcodeToolStripMenuItem.Name = "_writeBarcodeToolStripMenuItem"
        resources.ApplyResources(Me._writeBarcodeToolStripMenuItem, "_writeBarcodeToolStripMenuItem")
        ' 
        ' _barcodeSep1ToolStripMenuItem
        ' 
        Me._barcodeSep1ToolStripMenuItem.Name = "_barcodeSep1ToolStripMenuItem"
        resources.ApplyResources(Me._barcodeSep1ToolStripMenuItem, "_barcodeSep1ToolStripMenuItem")
        ' 
        ' _showBarcodesToolStripMenuItem
        ' 
        Me._showBarcodesToolStripMenuItem.Image = Global.BarcodeMainDemo.Resources.ShowBarcodes
        Me._showBarcodesToolStripMenuItem.Name = "_showBarcodesToolStripMenuItem"
        resources.ApplyResources(Me._showBarcodesToolStripMenuItem, "_showBarcodesToolStripMenuItem")
        ' 
        ' _barcodeSep2ToolStripMenuItem
        ' 
        Me._barcodeSep2ToolStripMenuItem.Name = "_barcodeSep2ToolStripMenuItem"
        resources.ApplyResources(Me._barcodeSep2ToolStripMenuItem, "_barcodeSep2ToolStripMenuItem")
        ' 
        ' _saveCurrentReadOptionsToolStripMenuItem
        ' 
        Me._saveCurrentReadOptionsToolStripMenuItem.Name = "_saveCurrentReadOptionsToolStripMenuItem"
        resources.ApplyResources(Me._saveCurrentReadOptionsToolStripMenuItem, "_saveCurrentReadOptionsToolStripMenuItem")
        ' 
        ' _loadReadOptionsToolStripMenuItem
        ' 
        Me._loadReadOptionsToolStripMenuItem.Name = "_loadReadOptionsToolStripMenuItem"
        resources.ApplyResources(Me._loadReadOptionsToolStripMenuItem, "_loadReadOptionsToolStripMenuItem")
        ' 
        ' _saveCurrentWriteOptionsToolStripMenuItem
        ' 
        Me._saveCurrentWriteOptionsToolStripMenuItem.Name = "_saveCurrentWriteOptionsToolStripMenuItem"
        resources.ApplyResources(Me._saveCurrentWriteOptionsToolStripMenuItem, "_saveCurrentWriteOptionsToolStripMenuItem")
        ' 
        ' _loadWriteOptionsToolStripMenuItem
        ' 
        Me._loadWriteOptionsToolStripMenuItem.Name = "_loadWriteOptionsToolStripMenuItem"
        resources.ApplyResources(Me._loadWriteOptionsToolStripMenuItem, "_loadWriteOptionsToolStripMenuItem")
        ' 
        ' _barcodeSep3ToolStripMenuItem
        ' 
        Me._barcodeSep3ToolStripMenuItem.Name = "_barcodeSep3ToolStripMenuItem"
        resources.ApplyResources(Me._barcodeSep3ToolStripMenuItem, "_barcodeSep3ToolStripMenuItem")
        ' 
        ' _deleteSelectedBarcodeToolStripMenuItem
        ' 
        Me._deleteSelectedBarcodeToolStripMenuItem.Name = "_deleteSelectedBarcodeToolStripMenuItem"
        resources.ApplyResources(Me._deleteSelectedBarcodeToolStripMenuItem, "_deleteSelectedBarcodeToolStripMenuItem")
        ' 
        ' _zoomToSelectedBarcodeToolStripMenuItem
        ' 
        Me._zoomToSelectedBarcodeToolStripMenuItem.Name = "_zoomToSelectedBarcodeToolStripMenuItem"
        resources.ApplyResources(Me._zoomToSelectedBarcodeToolStripMenuItem, "_zoomToSelectedBarcodeToolStripMenuItem")
        ' 
        ' _exportBarcodesToolStripMenuItem
        ' 
        Me._exportBarcodesToolStripMenuItem.Name = "_exportBarcodesToolStripMenuItem"
        resources.ApplyResources(Me._exportBarcodesToolStripMenuItem, "_exportBarcodesToolStripMenuItem")
        ' 
        ' _clearAllBarcodesToolStripMenuItem
        ' 
        Me._clearAllBarcodesToolStripMenuItem.Name = "_clearAllBarcodesToolStripMenuItem"
        resources.ApplyResources(Me._clearAllBarcodesToolStripMenuItem, "_clearAllBarcodesToolStripMenuItem")
        ' 
        ' _helpToolStripMenuItem
        ' 
        Me._helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._aboutToolStripMenuItem})
        Me._helpToolStripMenuItem.Name = "_helpToolStripMenuItem"
        resources.ApplyResources(Me._helpToolStripMenuItem, "_helpToolStripMenuItem")
        ' 
        ' _aboutToolStripMenuItem
        ' 
        Me._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem"
        resources.ApplyResources(Me._aboutToolStripMenuItem, "_aboutToolStripMenuItem")
        ' 
        ' _mainToolStrip
        ' 
        Me._mainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._newToolStripButton, Me._openToolStripButton, Me._saveToolStripButton, Me._toolStripSeparator1, Me._readBarcodesToolStripButton, Me._readBarcodeOptionsToolStripButton, Me._writeBarcodeToolStripButton})
        resources.ApplyResources(Me._mainToolStrip, "_mainToolStrip")
        Me._mainToolStrip.Name = "_mainToolStrip"
        ' 
        ' _newToolStripButton
        ' 
        Me._newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me._newToolStripButton.Image = Global.BarcodeMainDemo.Resources.NewDocument
        resources.ApplyResources(Me._newToolStripButton, "_newToolStripButton")
        Me._newToolStripButton.Name = "_newToolStripButton"
        ' 
        ' _openToolStripButton
        ' 
        Me._openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me._openToolStripButton.Image = Global.BarcodeMainDemo.Resources.OpenDocument
        resources.ApplyResources(Me._openToolStripButton, "_openToolStripButton")
        Me._openToolStripButton.Name = "_openToolStripButton"
        ' 
        ' _saveToolStripButton
        ' 
        Me._saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me._saveToolStripButton.Image = Global.BarcodeMainDemo.Resources.SaveDocument
        resources.ApplyResources(Me._saveToolStripButton, "_saveToolStripButton")
        Me._saveToolStripButton.Name = "_saveToolStripButton"
        ' 
        ' _toolStripSeparator1
        ' 
        Me._toolStripSeparator1.Name = "_toolStripSeparator1"
        resources.ApplyResources(Me._toolStripSeparator1, "_toolStripSeparator1")
        ' 
        ' _readBarcodesToolStripButton
        ' 
        Me._readBarcodesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me._readBarcodesToolStripButton.Image = Global.BarcodeMainDemo.Resources.ReadBarcodes
        resources.ApplyResources(Me._readBarcodesToolStripButton, "_readBarcodesToolStripButton")
        Me._readBarcodesToolStripButton.Name = "_readBarcodesToolStripButton"
        ' 
        ' _readBarcodeOptionsToolStripButton
        ' 
        Me._readBarcodeOptionsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me._readBarcodeOptionsToolStripButton.Image = Global.BarcodeMainDemo.Resources.ReadBarcodeOptions
        resources.ApplyResources(Me._readBarcodeOptionsToolStripButton, "_readBarcodeOptionsToolStripButton")
        Me._readBarcodeOptionsToolStripButton.Name = "_readBarcodeOptionsToolStripButton"
        ' 
        ' _writeBarcodeToolStripButton
        ' 
        Me._writeBarcodeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me._writeBarcodeToolStripButton.Image = Global.BarcodeMainDemo.Resources.WriteBarcode
        resources.ApplyResources(Me._writeBarcodeToolStripButton, "_writeBarcodeToolStripButton")
        Me._writeBarcodeToolStripButton.Name = "_writeBarcodeToolStripButton"
        ' 
        ' _mainStatusStrip
        ' 
        resources.ApplyResources(Me._mainStatusStrip, "_mainStatusStrip")
        Me._mainStatusStrip.Name = "_mainStatusStrip"
        ' 
        ' _viewerSplitter
        ' 
        resources.ApplyResources(Me._viewerSplitter, "_viewerSplitter")
        Me._viewerSplitter.Name = "_viewerSplitter"
        Me._viewerSplitter.TabStop = False
        ' 
        ' _viewerControl
        ' 
        resources.ApplyResources(Me._viewerControl, "_viewerControl")
        Me._viewerControl.Name = "_viewerControl"
        ' 
        ' _barcodeControl
        ' 
        resources.ApplyResources(Me._barcodeControl, "_barcodeControl")
        Me._barcodeControl.Name = "_barcodeControl"
        ' 
        ' _pagesControl
        ' 
        resources.ApplyResources(Me._pagesControl, "_pagesControl")
        Me._pagesControl.Name = "_pagesControl"
        ' 
        ' MainForm
        ' 
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me._viewerControl)
        Me.Controls.Add(Me._viewerSplitter)
        Me.Controls.Add(Me._barcodeControl)
        Me.Controls.Add(Me._pagesControl)
        Me.Controls.Add(Me._mainStatusStrip)
        Me.Controls.Add(Me._mainToolStrip)
        Me.Controls.Add(Me._mainMenuStrip)
        Me.MainMenuStrip = Me._mainMenuStrip
        Me.Name = "MainForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me._mainMenuStrip.ResumeLayout(False)
        Me._mainMenuStrip.PerformLayout()
        Me._mainToolStrip.ResumeLayout(False)
        Me._mainToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private _mainMenuStrip As System.Windows.Forms.MenuStrip
    Private WithEvents _fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _newToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _openToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _saveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _closeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private _fileSep1toolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Private _scanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _selectSourceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _acquireToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private _fileSep2ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Private WithEvents _exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _editToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _copyImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _pasteImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _viewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _zoomOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _zoomInToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private _editSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Private WithEvents _fitWidthToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _fitPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _pageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _previousPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _nextPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private _helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _gotoPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _interactiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _selectModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _panModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _zoomToModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _drawRegionModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private _interactiveSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Private WithEvents _deleteRegionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _writeBarcodeModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _barcodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _showBarcodesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private _mainToolStrip As System.Windows.Forms.ToolStrip
    Private WithEvents _newToolStripButton As System.Windows.Forms.ToolStripButton
    Private WithEvents _openToolStripButton As System.Windows.Forms.ToolStripButton
    Private WithEvents _saveToolStripButton As System.Windows.Forms.ToolStripButton
    Private _toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private _mainStatusStrip As System.Windows.Forms.StatusStrip
    Private WithEvents _pagesControl As PagesControl
    Private WithEvents _barcodeControl As BarcodeControl
    Private WithEvents _viewerControl As ViewerControl
    Private WithEvents _readBarcodesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _readBarcodesToolStripButton As System.Windows.Forms.ToolStripButton
    Private WithEvents _readBarcodeModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _readBarcodeOptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _readBarcodeOptionsToolStripButton As System.Windows.Forms.ToolStripButton
    Private _barcodeSep2ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Private WithEvents _saveCurrentReadOptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _loadReadOptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _saveCurrentWriteOptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _loadWriteOptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private _viewerSplitter As System.Windows.Forms.Splitter
    Private WithEvents _writeBarcodeToolStripButton As System.Windows.Forms.ToolStripButton
    Private WithEvents _writeBarcodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private _barcodeSep3ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Private WithEvents _deleteSelectedBarcodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _zoomToSelectedBarcodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _exportBarcodesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _clearAllBarcodesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private _barcodeSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Private WithEvents _preprocessingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _preprocessAllPagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private _preprocessingSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Private WithEvents _flipToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _reverseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _rotate90ClockwiseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _rotate90CounterclockwiseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private _noiseFiltersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _noiseMinFilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _noiseMedianFilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _noiseMaxFilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _lineRemoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _imageDeskewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _segmentationPerspectiveMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _perspectiveDeskewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _barcodeImageTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _scannedDocumentImageTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _pictureImageTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _unknownImageTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _barcodeBoundaryTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _rectangleBoundaryTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _fourPointsBoundaryTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
