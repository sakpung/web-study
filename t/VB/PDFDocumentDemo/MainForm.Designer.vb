Namespace PDFDocumentDemo
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
         Me._openToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._saveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._saveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._closeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._fileSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._exportTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._fileSep2ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._propertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._fontsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._fileSep3ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._editToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
         Me._copyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._editSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._selectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._clearSelectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._editSep2ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._findToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._findNextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._findPreviousToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._viewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._zoomOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._zoomInToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._viewSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._fitWidthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._fitPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._viewSep2ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._thumbnailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._bookmarksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._signaturesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._viewSep3ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._highlightObjectsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._pageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._previousPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._nextPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._gotoPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._interactiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._selectModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._highlightTextModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._panModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._zoomToModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._annotationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._showAnnotationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._annotationsObjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._annotationsSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._selectNextObjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._selectPreviousObjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._annotationsSep2ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._objectPropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._objectContentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._deleteObjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._mainToolStrip = New System.Windows.Forms.ToolStrip()
         Me._openToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
         Me._findToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
         Me._findPreviousToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._findNextToolStripButton = New System.Windows.Forms.ToolStripButton()
         Me._bottomPanel = New System.Windows.Forms.Panel()
         Me._splitter = New System.Windows.Forms.Splitter()
         Me._viewerControl = New PDFDocumentDemo.ViewerControl.ViewerControl()
         Me._pagesControl = New PDFDocumentDemo.PagesControl.PagesControl()
         Me._annotationsControl = New PDFDocumentDemo.Annotations.AnnotationsControl()
         Me._mainMenuStrip.SuspendLayout()
         Me._mainToolStrip.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _mainMenuStrip
         ' 
         Me._mainMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._fileToolStripMenuItem, Me._editToolStripMenuItem2, Me._viewToolStripMenuItem, Me._pageToolStripMenuItem, Me._interactiveToolStripMenuItem, Me._annotationsToolStripMenuItem, Me._helpToolStripMenuItem})
         resources.ApplyResources(Me._mainMenuStrip, "_mainMenuStrip")
         Me._mainMenuStrip.Name = "_mainMenuStrip"
         ' 
         ' _fileToolStripMenuItem
         ' 
         Me._fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._openToolStripMenuItem, Me._saveToolStripMenuItem, Me._saveAsToolStripMenuItem, Me._closeToolStripMenuItem, Me._fileSep1ToolStripMenuItem, Me._exportTextToolStripMenuItem, Me._fileSep2ToolStripMenuItem, Me._propertiesToolStripMenuItem, Me._fontsToolStripMenuItem, Me._fileSep3ToolStripMenuItem, Me._exitToolStripMenuItem})
         Me._fileToolStripMenuItem.Name = "_fileToolStripMenuItem"
         resources.ApplyResources(Me._fileToolStripMenuItem, "_fileToolStripMenuItem")
         ' 
         ' _openToolStripMenuItem
         ' 
         Me._openToolStripMenuItem.Image = Global.PDFDocumentDemo.Resources.OpenDocument
         Me._openToolStripMenuItem.Name = "_openToolStripMenuItem"
         resources.ApplyResources(Me._openToolStripMenuItem, "_openToolStripMenuItem")
         ' 
         ' _saveToolStripMenuItem
         ' 
         Me._saveToolStripMenuItem.Image = Global.PDFDocumentDemo.Resources.SaveDocument
         Me._saveToolStripMenuItem.Name = "_saveToolStripMenuItem"
         resources.ApplyResources(Me._saveToolStripMenuItem, "_saveToolStripMenuItem")
         ' 
         ' _saveAsToolStripMenuItem
         ' 
         Me._saveAsToolStripMenuItem.Name = "_saveAsToolStripMenuItem"
         resources.ApplyResources(Me._saveAsToolStripMenuItem, "_saveAsToolStripMenuItem")
         ' 
         ' _closeToolStripMenuItem
         ' 
         Me._closeToolStripMenuItem.Name = "_closeToolStripMenuItem"
         resources.ApplyResources(Me._closeToolStripMenuItem, "_closeToolStripMenuItem")
         ' 
         ' _fileSep1ToolStripMenuItem
         ' 
         Me._fileSep1ToolStripMenuItem.Name = "_fileSep1ToolStripMenuItem"
         resources.ApplyResources(Me._fileSep1ToolStripMenuItem, "_fileSep1ToolStripMenuItem")
         ' 
         ' _exportTextToolStripMenuItem
         ' 
         Me._exportTextToolStripMenuItem.Name = "_exportTextToolStripMenuItem"
         resources.ApplyResources(Me._exportTextToolStripMenuItem, "_exportTextToolStripMenuItem")
         ' 
         ' _fileSep2ToolStripMenuItem
         ' 
         Me._fileSep2ToolStripMenuItem.Name = "_fileSep2ToolStripMenuItem"
         resources.ApplyResources(Me._fileSep2ToolStripMenuItem, "_fileSep2ToolStripMenuItem")
         ' 
         ' _propertiesToolStripMenuItem
         ' 
         Me._propertiesToolStripMenuItem.Name = "_propertiesToolStripMenuItem"
         resources.ApplyResources(Me._propertiesToolStripMenuItem, "_propertiesToolStripMenuItem")
         ' 
         ' _fontsToolStripMenuItem
         ' 
         Me._fontsToolStripMenuItem.Name = "_fontsToolStripMenuItem"
         resources.ApplyResources(Me._fontsToolStripMenuItem, "_fontsToolStripMenuItem")
         ' 
         ' _fileSep3ToolStripMenuItem
         ' 
         Me._fileSep3ToolStripMenuItem.Name = "_fileSep3ToolStripMenuItem"
         resources.ApplyResources(Me._fileSep3ToolStripMenuItem, "_fileSep3ToolStripMenuItem")
         ' 
         ' _exitToolStripMenuItem
         ' 
         Me._exitToolStripMenuItem.Name = "_exitToolStripMenuItem"
         resources.ApplyResources(Me._exitToolStripMenuItem, "_exitToolStripMenuItem")
         ' 
         ' _editToolStripMenuItem2
         ' 
         Me._editToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._copyToolStripMenuItem, Me._editSep1ToolStripMenuItem, Me._selectAllToolStripMenuItem, Me._clearSelectionToolStripMenuItem, Me._editSep2ToolStripMenuItem, Me._findToolStripMenuItem, Me._findNextToolStripMenuItem, Me._findPreviousToolStripMenuItem})
         Me._editToolStripMenuItem2.Name = "_editToolStripMenuItem2"
         resources.ApplyResources(Me._editToolStripMenuItem2, "_editToolStripMenuItem2")
         ' 
         ' _copyToolStripMenuItem
         ' 
         Me._copyToolStripMenuItem.Image = Global.PDFDocumentDemo.Resources.Copy
         Me._copyToolStripMenuItem.Name = "_copyToolStripMenuItem"
         resources.ApplyResources(Me._copyToolStripMenuItem, "_copyToolStripMenuItem")
         ' 
         ' _editSep1ToolStripMenuItem
         ' 
         Me._editSep1ToolStripMenuItem.Name = "_editSep1ToolStripMenuItem"
         resources.ApplyResources(Me._editSep1ToolStripMenuItem, "_editSep1ToolStripMenuItem")
         ' 
         ' _selectAllToolStripMenuItem
         ' 
         Me._selectAllToolStripMenuItem.Name = "_selectAllToolStripMenuItem"
         resources.ApplyResources(Me._selectAllToolStripMenuItem, "_selectAllToolStripMenuItem")
         ' 
         ' _clearSelectionToolStripMenuItem
         ' 
         Me._clearSelectionToolStripMenuItem.Name = "_clearSelectionToolStripMenuItem"
         resources.ApplyResources(Me._clearSelectionToolStripMenuItem, "_clearSelectionToolStripMenuItem")
         ' 
         ' _editSep2ToolStripMenuItem
         ' 
         Me._editSep2ToolStripMenuItem.Name = "_editSep2ToolStripMenuItem"
         resources.ApplyResources(Me._editSep2ToolStripMenuItem, "_editSep2ToolStripMenuItem")
         ' 
         ' _findToolStripMenuItem
         ' 
         Me._findToolStripMenuItem.Image = Global.PDFDocumentDemo.Resources.Find
         Me._findToolStripMenuItem.Name = "_findToolStripMenuItem"
         resources.ApplyResources(Me._findToolStripMenuItem, "_findToolStripMenuItem")
         ' 
         ' _findNextToolStripMenuItem
         ' 
         Me._findNextToolStripMenuItem.Image = Global.PDFDocumentDemo.Resources.FindNext
         Me._findNextToolStripMenuItem.Name = "_findNextToolStripMenuItem"
         resources.ApplyResources(Me._findNextToolStripMenuItem, "_findNextToolStripMenuItem")
         ' 
         ' _findPreviousToolStripMenuItem
         ' 
         Me._findPreviousToolStripMenuItem.Image = Global.PDFDocumentDemo.Resources.FindPrevious
         Me._findPreviousToolStripMenuItem.Name = "_findPreviousToolStripMenuItem"
         resources.ApplyResources(Me._findPreviousToolStripMenuItem, "_findPreviousToolStripMenuItem")
         ' 
         ' _viewToolStripMenuItem
         ' 
         Me._viewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._zoomOutToolStripMenuItem, Me._zoomInToolStripMenuItem, Me._viewSep1ToolStripMenuItem, Me._fitWidthToolStripMenuItem, Me._fitPageToolStripMenuItem, Me._viewSep2ToolStripMenuItem, Me._thumbnailsToolStripMenuItem, Me._bookmarksToolStripMenuItem, Me._signaturesToolStripMenuItem, Me._viewSep3ToolStripMenuItem, Me._highlightObjectsToolStripMenuItem})
         Me._viewToolStripMenuItem.Name = "_viewToolStripMenuItem"
         resources.ApplyResources(Me._viewToolStripMenuItem, "_viewToolStripMenuItem")
         ' 
         ' _zoomOutToolStripMenuItem
         ' 
         Me._zoomOutToolStripMenuItem.Image = Global.PDFDocumentDemo.Resources.ZoomOut
         Me._zoomOutToolStripMenuItem.Name = "_zoomOutToolStripMenuItem"
         resources.ApplyResources(Me._zoomOutToolStripMenuItem, "_zoomOutToolStripMenuItem")
         ' 
         ' _zoomInToolStripMenuItem
         ' 
         Me._zoomInToolStripMenuItem.Image = Global.PDFDocumentDemo.Resources.ZoomIn
         Me._zoomInToolStripMenuItem.Name = "_zoomInToolStripMenuItem"
         resources.ApplyResources(Me._zoomInToolStripMenuItem, "_zoomInToolStripMenuItem")
         ' 
         ' _viewSep1ToolStripMenuItem
         ' 
         Me._viewSep1ToolStripMenuItem.Name = "_viewSep1ToolStripMenuItem"
         resources.ApplyResources(Me._viewSep1ToolStripMenuItem, "_viewSep1ToolStripMenuItem")
         ' 
         ' _fitWidthToolStripMenuItem
         ' 
         Me._fitWidthToolStripMenuItem.Image = Global.PDFDocumentDemo.Resources.FitPageWidth
         Me._fitWidthToolStripMenuItem.Name = "_fitWidthToolStripMenuItem"
         resources.ApplyResources(Me._fitWidthToolStripMenuItem, "_fitWidthToolStripMenuItem")
         ' 
         ' _fitPageToolStripMenuItem
         ' 
         Me._fitPageToolStripMenuItem.Image = Global.PDFDocumentDemo.Resources.FitPage
         Me._fitPageToolStripMenuItem.Name = "_fitPageToolStripMenuItem"
         resources.ApplyResources(Me._fitPageToolStripMenuItem, "_fitPageToolStripMenuItem")
         ' 
         ' _viewSep2ToolStripMenuItem
         ' 
         Me._viewSep2ToolStripMenuItem.Name = "_viewSep2ToolStripMenuItem"
         resources.ApplyResources(Me._viewSep2ToolStripMenuItem, "_viewSep2ToolStripMenuItem")
         ' 
         ' _thumbnailsToolStripMenuItem
         ' 
         Me._thumbnailsToolStripMenuItem.Image = Global.PDFDocumentDemo.Resources.Thumbnails
         Me._thumbnailsToolStripMenuItem.Name = "_thumbnailsToolStripMenuItem"
         resources.ApplyResources(Me._thumbnailsToolStripMenuItem, "_thumbnailsToolStripMenuItem")
         ' 
         ' _bookmarksToolStripMenuItem
         ' 
         Me._bookmarksToolStripMenuItem.Image = Global.PDFDocumentDemo.Resources.Bookmarks
         Me._bookmarksToolStripMenuItem.Name = "_bookmarksToolStripMenuItem"
         resources.ApplyResources(Me._bookmarksToolStripMenuItem, "_bookmarksToolStripMenuItem")
         ' 
         ' _viewSep3ToolStripMenuItem
         ' 
         Me._viewSep3ToolStripMenuItem.Name = "_viewSep3ToolStripMenuItem"
         resources.ApplyResources(Me._viewSep3ToolStripMenuItem, "_viewSep3ToolStripMenuItem")
         ' 
         ' _highlightObjectsToolStripMenuItem
         ' 
         Me._highlightObjectsToolStripMenuItem.Image = Global.PDFDocumentDemo.Resources.HighlightObjects
         Me._highlightObjectsToolStripMenuItem.Name = "_highlightObjectsToolStripMenuItem"
         resources.ApplyResources(Me._highlightObjectsToolStripMenuItem, "_highlightObjectsToolStripMenuItem")
         ' 
         ' _pageToolStripMenuItem
         ' 
         Me._pageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._previousPageToolStripMenuItem, Me._nextPageToolStripMenuItem, Me._gotoPageToolStripMenuItem})
         Me._pageToolStripMenuItem.Name = "_pageToolStripMenuItem"
         resources.ApplyResources(Me._pageToolStripMenuItem, "_pageToolStripMenuItem")
         ' 
         ' _previousPageToolStripMenuItem
         ' 
         Me._previousPageToolStripMenuItem.Image = Global.PDFDocumentDemo.Resources.PreviousPage
         Me._previousPageToolStripMenuItem.Name = "_previousPageToolStripMenuItem"
         resources.ApplyResources(Me._previousPageToolStripMenuItem, "_previousPageToolStripMenuItem")
         ' 
         ' _nextPageToolStripMenuItem
         ' 
         Me._nextPageToolStripMenuItem.Image = Global.PDFDocumentDemo.Resources.NextPage
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
         Me._interactiveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._selectModeToolStripMenuItem, Me._highlightTextModeToolStripMenuItem, Me._panModeToolStripMenuItem, Me._zoomToModeToolStripMenuItem})
         Me._interactiveToolStripMenuItem.Name = "_interactiveToolStripMenuItem"
         resources.ApplyResources(Me._interactiveToolStripMenuItem, "_interactiveToolStripMenuItem")
         ' 
         ' _selectModeToolStripMenuItem
         ' 
         Me._selectModeToolStripMenuItem.Image = Global.PDFDocumentDemo.Resources.SelectMode
         Me._selectModeToolStripMenuItem.Name = "_selectModeToolStripMenuItem"
         resources.ApplyResources(Me._selectModeToolStripMenuItem, "_selectModeToolStripMenuItem")
         ' 
         ' _highlightTextModeToolStripMenuItem
         ' 
         Me._highlightTextModeToolStripMenuItem.Image = Global.PDFDocumentDemo.Resources.HighlightText
         Me._highlightTextModeToolStripMenuItem.Name = "_highlightTextModeToolStripMenuItem"
         resources.ApplyResources(Me._highlightTextModeToolStripMenuItem, "_highlightTextModeToolStripMenuItem")
         '		 Me._highlightTextModeToolStripMenuItem.Click ,AddressOf Me._highlightTextModeToolStripMenuItem_Click);
         ' 
         ' _panModeToolStripMenuItem
         ' 
         Me._panModeToolStripMenuItem.Image = Global.PDFDocumentDemo.Resources.PanMode
         Me._panModeToolStripMenuItem.Name = "_panModeToolStripMenuItem"
         resources.ApplyResources(Me._panModeToolStripMenuItem, "_panModeToolStripMenuItem")
         ' 
         ' _zoomToModeToolStripMenuItem
         ' 
         Me._zoomToModeToolStripMenuItem.Image = Global.PDFDocumentDemo.Resources.ZoomSelection
         Me._zoomToModeToolStripMenuItem.Name = "_zoomToModeToolStripMenuItem"
         resources.ApplyResources(Me._zoomToModeToolStripMenuItem, "_zoomToModeToolStripMenuItem")
         ' 
         ' _annotationsToolStripMenuItem
         ' 
         Me._annotationsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._showAnnotationsToolStripMenuItem, Me._annotationsObjectToolStripMenuItem, Me._annotationsSep1ToolStripMenuItem, Me._selectNextObjectToolStripMenuItem, Me._selectPreviousObjectToolStripMenuItem, Me._annotationsSep2ToolStripMenuItem, Me._objectPropertiesToolStripMenuItem, Me._objectContentToolStripMenuItem, Me._deleteObjectToolStripMenuItem})
         Me._annotationsToolStripMenuItem.Name = "_annotationsToolStripMenuItem"
         resources.ApplyResources(Me._annotationsToolStripMenuItem, "_annotationsToolStripMenuItem")
         ' 
         ' _showAnnotationsToolStripMenuItem
         ' 
         Me._showAnnotationsToolStripMenuItem.Image = Global.PDFDocumentDemo.Resources.Annotations
         Me._showAnnotationsToolStripMenuItem.Name = "_showAnnotationsToolStripMenuItem"
         resources.ApplyResources(Me._showAnnotationsToolStripMenuItem, "_showAnnotationsToolStripMenuItem")
         ' 
         ' _annotationsObjectToolStripMenuItem
         ' 
         Me._annotationsObjectToolStripMenuItem.Name = "_annotationsObjectToolStripMenuItem"
         resources.ApplyResources(Me._annotationsObjectToolStripMenuItem, "_annotationsObjectToolStripMenuItem")
         ' 
         ' _annotationsSep1ToolStripMenuItem
         ' 
         Me._annotationsSep1ToolStripMenuItem.Name = "_annotationsSep1ToolStripMenuItem"
         resources.ApplyResources(Me._annotationsSep1ToolStripMenuItem, "_annotationsSep1ToolStripMenuItem")
         ' 
         ' _selectNextObjectToolStripMenuItem
         ' 
         Me._selectNextObjectToolStripMenuItem.Name = "_selectNextObjectToolStripMenuItem"
         resources.ApplyResources(Me._selectNextObjectToolStripMenuItem, "_selectNextObjectToolStripMenuItem")
         ' 
         ' _selectPreviousObjectToolStripMenuItem
         ' 
         Me._selectPreviousObjectToolStripMenuItem.Name = "_selectPreviousObjectToolStripMenuItem"
         resources.ApplyResources(Me._selectPreviousObjectToolStripMenuItem, "_selectPreviousObjectToolStripMenuItem")
         ' 
         ' _annotationsSep2ToolStripMenuItem
         ' 
         Me._annotationsSep2ToolStripMenuItem.Name = "_annotationsSep2ToolStripMenuItem"
         resources.ApplyResources(Me._annotationsSep2ToolStripMenuItem, "_annotationsSep2ToolStripMenuItem")
         ' 
         ' _objectPropertiesToolStripMenuItem
         ' 
         Me._objectPropertiesToolStripMenuItem.Name = "_objectPropertiesToolStripMenuItem"
         resources.ApplyResources(Me._objectPropertiesToolStripMenuItem, "_objectPropertiesToolStripMenuItem")
         ' 
         ' _objectContentToolStripMenuItem
         ' 
         Me._objectContentToolStripMenuItem.Name = "_objectContentToolStripMenuItem"
         resources.ApplyResources(Me._objectContentToolStripMenuItem, "_objectContentToolStripMenuItem")
         ' 
         ' _deleteObjectToolStripMenuItem
         ' 
         Me._deleteObjectToolStripMenuItem.Name = "_deleteObjectToolStripMenuItem"
         resources.ApplyResources(Me._deleteObjectToolStripMenuItem, "_deleteObjectToolStripMenuItem")
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
         Me._mainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._openToolStripButton, Me._toolStripSeparator1, Me._findToolStripTextBox, Me._findPreviousToolStripButton, Me._findNextToolStripButton})
         resources.ApplyResources(Me._mainToolStrip, "_mainToolStrip")
         Me._mainToolStrip.Name = "_mainToolStrip"
         ' 
         ' _openToolStripButton
         ' 
         Me._openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._openToolStripButton.Image = Global.PDFDocumentDemo.Resources.OpenDocument
         resources.ApplyResources(Me._openToolStripButton, "_openToolStripButton")
         Me._openToolStripButton.Name = "_openToolStripButton"
         ' 
         ' _toolStripSeparator1
         ' 
         Me._toolStripSeparator1.Name = "_toolStripSeparator1"
         resources.ApplyResources(Me._toolStripSeparator1, "_toolStripSeparator1")
         ' 
         ' _findToolStripTextBox
         ' 
         Me._findToolStripTextBox.Name = "_findToolStripTextBox"
         resources.ApplyResources(Me._findToolStripTextBox, "_findToolStripTextBox")
         ' 
         ' _findPreviousToolStripButton
         ' 
         Me._findPreviousToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._findPreviousToolStripButton.Image = Global.PDFDocumentDemo.Resources.FindPrevious
         resources.ApplyResources(Me._findPreviousToolStripButton, "_findPreviousToolStripButton")
         Me._findPreviousToolStripButton.Name = "_findPreviousToolStripButton"
         ' 
         ' _findNextToolStripButton
         ' 
         Me._findNextToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._findNextToolStripButton.Image = Global.PDFDocumentDemo.Resources.FindNext
         resources.ApplyResources(Me._findNextToolStripButton, "_findNextToolStripButton")
         Me._findNextToolStripButton.Name = "_findNextToolStripButton"
         ' 
         ' _bottomPanel
         ' 
         Me._bottomPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         resources.ApplyResources(Me._bottomPanel, "_bottomPanel")
         Me._bottomPanel.Name = "_bottomPanel"
         ' 
         ' _splitter
         ' 
         resources.ApplyResources(Me._splitter, "_splitter")
         Me._splitter.Name = "_splitter"
         Me._splitter.TabStop = False
         ' 
         ' _viewerControl
         ' 
         resources.ApplyResources(Me._viewerControl, "_viewerControl")
         Me._viewerControl.Name = "_viewerControl"
         ' 
         ' _pagesControl
         ' 
         resources.ApplyResources(Me._pagesControl, "_pagesControl")
         Me._pagesControl.Name = "_pagesControl"
         Me._pagesControl.Width = 200
         ' 
         ' _annotationsControl
         ' 
         resources.ApplyResources(Me._annotationsControl, "_annotationsControl")
         Me._annotationsControl.DocumentAnnotations = Nothing
         Me._annotationsControl.Name = "_annotationsControl"
         ' 
         ' _signaturesToolStripMenuItem
         ' 
         Me._signaturesToolStripMenuItem.Image = Global.PDFDocumentDemo.Resources.Signature
         Me._signaturesToolStripMenuItem.Name = "_signaturesToolStripMenuItem"
         resources.ApplyResources(Me._signaturesToolStripMenuItem, "_signaturesToolStripMenuItem")
         ' 
         ' MainForm
         ' 
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me._viewerControl)
         Me.Controls.Add(Me._annotationsControl)
         Me.Controls.Add(Me._splitter)
         Me.Controls.Add(Me._pagesControl)
         Me.Controls.Add(Me._bottomPanel)
         Me.Controls.Add(Me._mainToolStrip)
         Me.Controls.Add(Me._mainMenuStrip)
         Me.Name = "MainForm"
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
      Private WithEvents _openToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _fileSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _viewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _zoomOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _zoomInToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _viewSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _fitWidthToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _fitPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _pageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _previousPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _nextPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _gotoPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _interactiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _selectModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _panModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _zoomToModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _mainToolStrip As System.Windows.Forms.ToolStrip
      Private WithEvents _openToolStripButton As System.Windows.Forms.ToolStripButton
      Private _bottomPanel As System.Windows.Forms.Panel
      Private WithEvents _pagesControl As PagesControl.PagesControl
      Private WithEvents _viewerControl As ViewerControl.ViewerControl
      Private WithEvents _closeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _editToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _findToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _findNextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _findToolStripTextBox As System.Windows.Forms.ToolStripTextBox
      Private WithEvents _findNextToolStripButton As System.Windows.Forms.ToolStripButton
      Private WithEvents _findPreviousToolStripButton As System.Windows.Forms.ToolStripButton
      Private _editSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _findPreviousToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _copyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _selectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _editSep2ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _clearSelectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _exportTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _propertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _fontsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _fileSep2ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private _splitter As System.Windows.Forms.Splitter
      Private _viewSep2ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _thumbnailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _bookmarksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _signaturesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _viewSep3ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _highlightObjectsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _highlightTextModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _annotationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _showAnnotationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _annotationsObjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _selectNextObjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _selectPreviousObjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _saveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _saveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _fileSep3ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _objectPropertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _objectContentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _annotationsSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private _annotationsSep2ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _deleteObjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _annotationsControl As Annotations.AnnotationsControl
   End Class
End Namespace
