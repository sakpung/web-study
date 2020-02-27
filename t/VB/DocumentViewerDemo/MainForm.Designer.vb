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
         CleanUp()
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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
      Me._mainMenuStrip = New System.Windows.Forms.MenuStrip()
      Me._fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._openDocumentFromFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._openDocumentFromUrltoolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._saveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._closeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._fileSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
      Me._openFromCacheToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._saveToCacheToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._fileSep2ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
      Me._exportTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._propertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._fileSep3ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
      Me._printSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._printToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._fileSep4ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
      Me._exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._editToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._undoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._redoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._editSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
      Me._cutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._copyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._pasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._deleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._editSep2ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
      Me._selectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._selectAllAnnotationsToolStripMenuItemtoolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._clearSelectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._editSep3ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
      Me._findToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._findNextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._findPreviousToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._viewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._rotateVieweToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._clockwiseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._counterClockwiseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._viewSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
      Me._zoomOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._zoomInToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._viewSep2ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
      Me._actualSizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._fitPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._fitWidthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._viewSep3ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
      Me._asSvgToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._asImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._viewSep4ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
      Me._thumbnailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._bookmarksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._pageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._firstPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._previousPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._nextPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._lastPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._gotoPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._pageSep1ToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
      Me._getCurrentPageTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._getAllPagesTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._pageSep2ToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
      Me._rotatePageClockwiseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._rotatePageCounterClockwiseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._rotatePagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._pageSep3ToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
      Me._enableDisablePageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._pageSep4ToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
      Me._displayPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._singlePageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._verticalPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._doublePageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._horizontalPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._interactiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._selectTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._panZoomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._panToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._zoomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._zoomToToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._magnifyGlassToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._interactiveSep1ToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
      Me._autoPanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._inertiaScrollToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._annotationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._userModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._userModeDesignToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._userModeRunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._userModeRenderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._userModeSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
      Me._customizeRenderModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._annotationsSep1ToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
      Me._currentObjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._annotationsSep2ToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
      Me._alignToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._alignBringToFrontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._alignSendToBackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._alignBringToFirstToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._alignSendToLastToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._flipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._flipVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._flipHorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._groupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._groupSelectedObjectsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._groupUngroupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._securityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._securityLockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._securityUnlockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._resetRotatePointsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._antiAliasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._annotationsPropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._annotationsSep3ToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
      Me._behaviorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._behaviorUseRotateThumbsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._annotationsSep4ToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
      Me._redactionOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._behaviorEnableToolTipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._behaviorRenderOnThumbnailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._behaviorDeselectOnDownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._behaviorRestrictDesignersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._behaviorRubberbandSelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._preferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._userNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._cacheDirectoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._autoGetTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._documentTextOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._showTextIndicatorsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._showOperationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._diagnosticsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._documentViewerOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._mainToolStrip = New System.Windows.Forms.ToolStrip()
      Me._openDocumentFromFileToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._openDocumentFromUrlToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._mainToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me._previousPageToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._nextPageToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._pageNumberToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
      Me._pageNumberToolStripLabel = New System.Windows.Forms.ToolStripLabel()
      Me._mainToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me._zoomInToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._zoomOutToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._zoomToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
      Me._actualSizeToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._fitPageToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._fitWidthToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._mainToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me._singlePageToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._verticalPageToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._doublePageToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._horizontalPageToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._mainToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me._selectTextToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._panZoomToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._panToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._zoomToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._zoomToToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._magnifyGlassToolStripButton = New System.Windows.Forms.ToolStripButton()
      Me._leftPanel = New System.Windows.Forms.Panel()
      Me._leftTabControl = New System.Windows.Forms.TabControl()
      Me._thumbnailsTabPage = New System.Windows.Forms.TabPage()
      Me._thumbnailsContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me._thumbnailsGetThisPageTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._thumbnailsGetAllPagesTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._thumbnailsSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
      Me._thumbnailsRotateClockwiseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._thumbnailsRotateCounterClockwiseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._thumbnailsSep2ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
      Me._thumbnailsEnableDisablePageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._loadingThumbnailsProgressBar = New System.Windows.Forms.ProgressBar()
      Me._bookmarksTabPage = New System.Windows.Forms.TabPage()
      Me._loadingBookmarksProgressBar = New System.Windows.Forms.ProgressBar()
      Me._rightPanel = New System.Windows.Forms.Panel()
      Me._loadingAnnotationsProgressBar = New System.Windows.Forms.ProgressBar()
      Me._annotationsControlPanel = New System.Windows.Forms.Panel()
      Me._annotationsObjectsPanel = New System.Windows.Forms.Panel()
      Me._annotationsObjectsLabel = New System.Windows.Forms.Label()
      Me._annotationsControlSplitter = New System.Windows.Forms.Splitter()
      Me._annotationsToolBarPanel = New System.Windows.Forms.Panel()
      Me._annotationsShapeLabel = New System.Windows.Forms.Label()
      Me._leftSplitter = New System.Windows.Forms.Splitter()
      Me._rightSplitter = New System.Windows.Forms.Splitter()
      Me._centerPanel = New System.Windows.Forms.Panel()
      Me._bottomPanel = New System.Windows.Forms.Panel()
      Me._outputWindow = New DocumentViewerDemo.OutputWindow()

      Me._mainMenuStrip.SuspendLayout()
      Me._mainToolStrip.SuspendLayout()
      Me._leftPanel.SuspendLayout()
      Me._leftTabControl.SuspendLayout()
      Me._thumbnailsTabPage.SuspendLayout()
      Me._thumbnailsContextMenuStrip.SuspendLayout()
      Me._bookmarksTabPage.SuspendLayout()
      Me._rightPanel.SuspendLayout()
      Me._annotationsControlPanel.SuspendLayout()
      Me._annotationsObjectsPanel.SuspendLayout()
      Me._annotationsToolBarPanel.SuspendLayout()
      Me._bottomPanel.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _mainMenuStrip
      ' 
      Me._mainMenuStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
      Me._mainMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._fileToolStripMenuItem, Me._editToolStripMenuItem, Me._viewToolStripMenuItem, Me._pageToolStripMenuItem, Me._interactiveToolStripMenuItem, Me._annotationsToolStripMenuItem, Me._preferencesToolStripMenuItem, Me._helpToolStripMenuItem})
      Me._mainMenuStrip.Location = New System.Drawing.Point(0, 0)
      Me._mainMenuStrip.Name = "_mainMenuStrip"
      Me._mainMenuStrip.Padding = New System.Windows.Forms.Padding(9, 3, 0, 3)
      Me._mainMenuStrip.Size = New System.Drawing.Size(1731, 35)
      Me._mainMenuStrip.TabIndex = 0
      ' 
      ' _fileToolStripMenuItem
      ' 
      Me._fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._openDocumentFromFileToolStripMenuItem, Me._openDocumentFromUrltoolStripMenuItem, Me._saveToolStripMenuItem, Me._closeToolStripMenuItem, Me._fileSep1ToolStripMenuItem, Me._openFromCacheToolStripMenuItem, Me._saveToCacheToolStripMenuItem, Me._fileSep2ToolStripMenuItem, Me._exportTextToolStripMenuItem, Me._propertiesToolStripMenuItem, Me._fileSep3ToolStripMenuItem, Me._printSetupToolStripMenuItem, Me._printToolStripMenuItem, Me._fileSep4ToolStripMenuItem, Me._exitToolStripMenuItem})
      Me._fileToolStripMenuItem.Name = "_fileToolStripMenuItem"
      Me._fileToolStripMenuItem.Size = New System.Drawing.Size(50, 29)
      Me._fileToolStripMenuItem.Text = "&File"
      ' 
      ' _openDocumentFromFileToolStripMenuItem
      ' 
      Me._openDocumentFromFileToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.Open
      Me._openDocumentFromFileToolStripMenuItem.Name = "_openDocumentFromFileToolStripMenuItem"
      Me._openDocumentFromFileToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys))
      Me._openDocumentFromFileToolStripMenuItem.Size = New System.Drawing.Size(245, 30)
      Me._openDocumentFromFileToolStripMenuItem.Text = "&Open..."
      AddHandler Me._openDocumentFromFileToolStripMenuItem.Click, AddressOf Me._openDocumentFromFileToolStripMenuItem_Click
      ' 
      ' _openDocumentFromUrltoolStripMenuItem
      ' 
      Me._openDocumentFromUrltoolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.OpenUrl
      Me._openDocumentFromUrltoolStripMenuItem.Name = "_openDocumentFromUrltoolStripMenuItem"
      Me._openDocumentFromUrltoolStripMenuItem.Size = New System.Drawing.Size(245, 30)
      Me._openDocumentFromUrltoolStripMenuItem.Text = "Open &URL..."
      AddHandler Me._openDocumentFromUrltoolStripMenuItem.Click, AddressOf Me._openDocumentFromUrltoolStripMenuItem_Click
      ' 
      ' _saveToolStripMenuItem
      ' 
      Me._saveToolStripMenuItem.Name = "_saveToolStripMenuItem"
      Me._saveToolStripMenuItem.Size = New System.Drawing.Size(245, 30)
      Me._saveToolStripMenuItem.Text = "&Save..."
      Me._saveToolStripMenuItem.ToolTipText = "Export this document"
      AddHandler Me._saveToolStripMenuItem.Click, AddressOf Me._saveToolStripMenuItem_Click
      ' 
      ' _closeToolStripMenuItem
      ' 
      Me._closeToolStripMenuItem.Name = "_closeToolStripMenuItem"
      Me._closeToolStripMenuItem.Size = New System.Drawing.Size(245, 30)
      Me._closeToolStripMenuItem.Text = "C&lose"
      AddHandler Me._closeToolStripMenuItem.Click, AddressOf Me._closeToolStripMenuItem_Click
      ' 
      ' _fileSep1ToolStripMenuItem
      ' 
      Me._fileSep1ToolStripMenuItem.Name = "_fileSep1ToolStripMenuItem"
      Me._fileSep1ToolStripMenuItem.Size = New System.Drawing.Size(242, 6)
      ' 
      ' _openFromCacheToolStripMenuItem
      ' 
      Me._openFromCacheToolStripMenuItem.Name = "_openFromCacheToolStripMenuItem"
      Me._openFromCacheToolStripMenuItem.Size = New System.Drawing.Size(245, 30)
      Me._openFromCacheToolStripMenuItem.Text = "Open from &cache..."
      Me._openFromCacheToolStripMenuItem.ToolTipText = "Open a document from the cache"
      AddHandler Me._openFromCacheToolStripMenuItem.Click, AddressOf Me._openFromCacheToolStripMenuItem_Click
      ' 
      ' _saveToCacheToolStripMenuItem
      ' 
      Me._saveToCacheToolStripMenuItem.Name = "_saveToCacheToolStripMenuItem"
      Me._saveToCacheToolStripMenuItem.Size = New System.Drawing.Size(245, 30)
      Me._saveToCacheToolStripMenuItem.Text = "Save to cac&he"
      Me._saveToCacheToolStripMenuItem.ToolTipText = "Save this document to the cache"
      AddHandler Me._saveToCacheToolStripMenuItem.Click, AddressOf Me._saveToCacheToolStripMenuItem_Click
      ' 
      ' _fileSep2ToolStripMenuItem
      ' 
      Me._fileSep2ToolStripMenuItem.Name = "_fileSep2ToolStripMenuItem"
      Me._fileSep2ToolStripMenuItem.Size = New System.Drawing.Size(242, 6)
      ' 
      ' _exportTextToolStripMenuItem
      ' 
      Me._exportTextToolStripMenuItem.Name = "_exportTextToolStripMenuItem"
      Me._exportTextToolStripMenuItem.Size = New System.Drawing.Size(245, 30)
      Me._exportTextToolStripMenuItem.Text = "Export &text..."
      AddHandler Me._exportTextToolStripMenuItem.Click, AddressOf Me._exportTextToolStripMenuItem_Click
      ' 
      ' _propertiesToolStripMenuItem
      ' 
      Me._propertiesToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.Properties
      Me._propertiesToolStripMenuItem.Name = "_propertiesToolStripMenuItem"
      Me._propertiesToolStripMenuItem.Size = New System.Drawing.Size(245, 30)
      Me._propertiesToolStripMenuItem.Text = "P&roperties..."
      AddHandler Me._propertiesToolStripMenuItem.Click, AddressOf Me._propertiesToolStripMenuItem_Click
      ' 
      ' _fileSep3ToolStripMenuItem
      ' 
      Me._fileSep3ToolStripMenuItem.Name = "_fileSep3ToolStripMenuItem"
      Me._fileSep3ToolStripMenuItem.Size = New System.Drawing.Size(242, 6)
      ' 
      ' _printSetupToolStripMenuItem
      ' 
      Me._printSetupToolStripMenuItem.Name = "_printSetupToolStripMenuItem"
      Me._printSetupToolStripMenuItem.Size = New System.Drawing.Size(245, 30)
      Me._printSetupToolStripMenuItem.Text = "Print set&up..."
      AddHandler Me._printSetupToolStripMenuItem.Click, AddressOf Me._printSetupToolStripMenuItem_Click
      ' 
      ' _printToolStripMenuItem
      ' 
      Me._printToolStripMenuItem.Name = "_printToolStripMenuItem"
      Me._printToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys))
      Me._printToolStripMenuItem.Size = New System.Drawing.Size(245, 30)
      Me._printToolStripMenuItem.Text = "&Print..."
      AddHandler Me._printToolStripMenuItem.Click, AddressOf Me._printToolStripMenuItem_Click
      ' 
      ' _fileSep4ToolStripMenuItem
      ' 
      Me._fileSep4ToolStripMenuItem.Name = "_fileSep4ToolStripMenuItem"
      Me._fileSep4ToolStripMenuItem.Size = New System.Drawing.Size(242, 6)
      ' 
      ' _exitToolStripMenuItem
      ' 
      Me._exitToolStripMenuItem.Name = "_exitToolStripMenuItem"
      Me._exitToolStripMenuItem.Size = New System.Drawing.Size(245, 30)
      Me._exitToolStripMenuItem.Text = "E&xit"
      AddHandler Me._exitToolStripMenuItem.Click, AddressOf Me._exitToolStripMenuItem_Click
      ' 
      ' _editToolStripMenuItem
      ' 
      Me._editToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._undoToolStripMenuItem, Me._redoToolStripMenuItem, Me._editSep1ToolStripMenuItem, Me._cutToolStripMenuItem, Me._copyToolStripMenuItem, Me._pasteToolStripMenuItem, Me._deleteToolStripMenuItem, Me._editSep2ToolStripMenuItem, Me._selectAllToolStripMenuItem, Me._selectAllAnnotationsToolStripMenuItemtoolStripMenuItem, Me._clearSelectionToolStripMenuItem, Me._editSep3ToolStripMenuItem, Me._findToolStripMenuItem, Me._findNextToolStripMenuItem, Me._findPreviousToolStripMenuItem})
      Me._editToolStripMenuItem.Name = "_editToolStripMenuItem"
      Me._editToolStripMenuItem.Size = New System.Drawing.Size(54, 29)
      Me._editToolStripMenuItem.Text = "E&dit"
      ' 
      ' _undoToolStripMenuItem
      ' 
      Me._undoToolStripMenuItem.Name = "_undoToolStripMenuItem"
      Me._undoToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys))
      Me._undoToolStripMenuItem.Size = New System.Drawing.Size(374, 30)
      Me._undoToolStripMenuItem.Text = "&Undo"
      ' 
      ' _redoToolStripMenuItem
      ' 
      Me._redoToolStripMenuItem.Name = "_redoToolStripMenuItem"
      Me._redoToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys))
      Me._redoToolStripMenuItem.Size = New System.Drawing.Size(374, 30)
      Me._redoToolStripMenuItem.Text = "&Redo"
      ' 
      ' _editSep1ToolStripMenuItem
      ' 
      Me._editSep1ToolStripMenuItem.Name = "_editSep1ToolStripMenuItem"
      Me._editSep1ToolStripMenuItem.Size = New System.Drawing.Size(371, 6)
      ' 
      ' _cutToolStripMenuItem
      ' 
      Me._cutToolStripMenuItem.Name = "_cutToolStripMenuItem"
      Me._cutToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys))
      Me._cutToolStripMenuItem.Size = New System.Drawing.Size(374, 30)
      Me._cutToolStripMenuItem.Text = "Cu&t"
      ' 
      ' _copyToolStripMenuItem
      ' 
      Me._copyToolStripMenuItem.Name = "_copyToolStripMenuItem"
      Me._copyToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys))
      Me._copyToolStripMenuItem.Size = New System.Drawing.Size(374, 30)
      Me._copyToolStripMenuItem.Text = "&Copy"
      Me._copyToolStripMenuItem.ToolTipText = "Copy selected text to the clipboard"
      ' 
      ' _pasteToolStripMenuItem
      ' 
      Me._pasteToolStripMenuItem.Name = "_pasteToolStripMenuItem"
      Me._pasteToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys))
      Me._pasteToolStripMenuItem.Size = New System.Drawing.Size(374, 30)
      Me._pasteToolStripMenuItem.Text = "&Paste"
      ' 
      ' _deleteToolStripMenuItem
      ' 
      Me._deleteToolStripMenuItem.Name = "_deleteToolStripMenuItem"
      Me._deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
      Me._deleteToolStripMenuItem.Size = New System.Drawing.Size(374, 30)
      Me._deleteToolStripMenuItem.Text = "&Delete"
      ' 
      ' _editSep2ToolStripMenuItem
      ' 
      Me._editSep2ToolStripMenuItem.Name = "_editSep2ToolStripMenuItem"
      Me._editSep2ToolStripMenuItem.Size = New System.Drawing.Size(371, 6)
      ' 
      ' _selectAllToolStripMenuItem
      ' 
      Me._selectAllToolStripMenuItem.Name = "_selectAllToolStripMenuItem"
      Me._selectAllToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys))
      Me._selectAllToolStripMenuItem.Size = New System.Drawing.Size(374, 30)
      Me._selectAllToolStripMenuItem.Text = "Select &all"
      Me._selectAllToolStripMenuItem.ToolTipText = "Select all text in this page"
      AddHandler Me._selectAllToolStripMenuItem.Click, AddressOf Me._selectAllToolStripMenuItem_Click
      ' 
      ' _selectAllAnnotationsToolStripMenuItemtoolStripMenuItem
      ' 
      Me._selectAllAnnotationsToolStripMenuItemtoolStripMenuItem.Name = "_selectAllAnnotationsToolStripMenuItemtoolStripMenuItem"
      Me._selectAllAnnotationsToolStripMenuItemtoolStripMenuItem.ShortcutKeys = (CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys))
      Me._selectAllAnnotationsToolStripMenuItemtoolStripMenuItem.Size = New System.Drawing.Size(374, 30)
      Me._selectAllAnnotationsToolStripMenuItemtoolStripMenuItem.Text = "Select all annotation&s"
      ' 
      ' _clearSelectionToolStripMenuItem
      ' 
      Me._clearSelectionToolStripMenuItem.Name = "_clearSelectionToolStripMenuItem"
      Me._clearSelectionToolStripMenuItem.Size = New System.Drawing.Size(374, 30)
      Me._clearSelectionToolStripMenuItem.Text = "C&lear selection"
      ' 
      ' _editSep3ToolStripMenuItem
      ' 
      Me._editSep3ToolStripMenuItem.Name = "_editSep3ToolStripMenuItem"
      Me._editSep3ToolStripMenuItem.Size = New System.Drawing.Size(371, 6)
      ' 
      ' _findToolStripMenuItem
      ' 
      Me._findToolStripMenuItem.Name = "_findToolStripMenuItem"
      Me._findToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys))
      Me._findToolStripMenuItem.Size = New System.Drawing.Size(374, 30)
      Me._findToolStripMenuItem.Text = "&Find..."
      Me._findToolStripMenuItem.ToolTipText = "Find text in the document"
      AddHandler Me._findToolStripMenuItem.Click, AddressOf Me._findToolStripMenuItem_Click
      ' 
      ' _findNextToolStripMenuItem
      ' 
      Me._findNextToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.FindNext
      Me._findNextToolStripMenuItem.Name = "_findNextToolStripMenuItem"
      Me._findNextToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
      Me._findNextToolStripMenuItem.Size = New System.Drawing.Size(374, 30)
      Me._findNextToolStripMenuItem.Text = "Find &next"
      Me._findNextToolStripMenuItem.ToolTipText = "Find next accurace of text in the document"
      AddHandler Me._findNextToolStripMenuItem.Click, AddressOf Me._findNextToolStripMenuItem_Click
      ' 
      ' _findPreviousToolStripMenuItem
      ' 
      Me._findPreviousToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.FindPrevious
      Me._findPreviousToolStripMenuItem.Name = "_findPreviousToolStripMenuItem"
      Me._findPreviousToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F3), System.Windows.Forms.Keys))
      Me._findPreviousToolStripMenuItem.Size = New System.Drawing.Size(374, 30)
      Me._findPreviousToolStripMenuItem.Text = "Find &previous"
      Me._findPreviousToolStripMenuItem.ToolTipText = "Find previous text"
      AddHandler Me._findPreviousToolStripMenuItem.Click, AddressOf Me._findPreviousToolStripMenuItem_Click
      ' 
      ' _viewToolStripMenuItem
      ' 
      Me._viewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._rotateVieweToolStripMenuItem, Me._viewSep1ToolStripMenuItem, Me._zoomOutToolStripMenuItem, Me._zoomInToolStripMenuItem, Me._viewSep2ToolStripMenuItem, Me._actualSizeToolStripMenuItem, Me._fitPageToolStripMenuItem, Me._fitWidthToolStripMenuItem, Me._viewSep3ToolStripMenuItem, Me._asSvgToolStripMenuItem, Me._asImageToolStripMenuItem, Me._viewSep4ToolStripMenuItem, Me._thumbnailsToolStripMenuItem, Me._bookmarksToolStripMenuItem})
      Me._viewToolStripMenuItem.Name = "_viewToolStripMenuItem"
      Me._viewToolStripMenuItem.Size = New System.Drawing.Size(61, 29)
      Me._viewToolStripMenuItem.Text = "&View"
      AddHandler Me._viewToolStripMenuItem.DropDownOpening, AddressOf Me._viewToolStripMenuItem_DropDownOpening
      ' 
      ' _rotateVieweToolStripMenuItem
      ' 
      Me._rotateVieweToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._clockwiseToolStripMenuItem, Me._counterClockwiseToolStripMenuItem})
      Me._rotateVieweToolStripMenuItem.Name = "_rotateVieweToolStripMenuItem"
      Me._rotateVieweToolStripMenuItem.Size = New System.Drawing.Size(187, 30)
      Me._rotateVieweToolStripMenuItem.Text = "&Rotate view"
      ' 
      ' _clockwiseToolStripMenuItem
      ' 
      Me._clockwiseToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.Clockwise
      Me._clockwiseToolStripMenuItem.Name = "_clockwiseToolStripMenuItem"
      Me._clockwiseToolStripMenuItem.Size = New System.Drawing.Size(238, 30)
      Me._clockwiseToolStripMenuItem.Text = "&Clockwise"
      ' 
      ' _counterClockwiseToolStripMenuItem
      ' 
      Me._counterClockwiseToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.CounterClockwise
      Me._counterClockwiseToolStripMenuItem.Name = "_counterClockwiseToolStripMenuItem"
      Me._counterClockwiseToolStripMenuItem.Size = New System.Drawing.Size(238, 30)
      Me._counterClockwiseToolStripMenuItem.Text = "Counter clock&wise"
      ' 
      ' _viewSep1ToolStripMenuItem
      ' 
      Me._viewSep1ToolStripMenuItem.Name = "_viewSep1ToolStripMenuItem"
      Me._viewSep1ToolStripMenuItem.Size = New System.Drawing.Size(184, 6)
      ' 
      ' _zoomOutToolStripMenuItem
      ' 
      Me._zoomOutToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.ZoomOut
      Me._zoomOutToolStripMenuItem.Name = "_zoomOutToolStripMenuItem"
      Me._zoomOutToolStripMenuItem.Size = New System.Drawing.Size(187, 30)
      Me._zoomOutToolStripMenuItem.Text = "Zoom &out"
      Me._zoomOutToolStripMenuItem.ToolTipText = "Zoom out"
      ' 
      ' _zoomInToolStripMenuItem
      ' 
      Me._zoomInToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.ZoomIn
      Me._zoomInToolStripMenuItem.Name = "_zoomInToolStripMenuItem"
      Me._zoomInToolStripMenuItem.Size = New System.Drawing.Size(187, 30)
      Me._zoomInToolStripMenuItem.Text = "Zoom &in"
      Me._zoomInToolStripMenuItem.ToolTipText = "Zoom in"
      ' 
      ' _viewSep2ToolStripMenuItem
      ' 
      Me._viewSep2ToolStripMenuItem.Name = "_viewSep2ToolStripMenuItem"
      Me._viewSep2ToolStripMenuItem.Size = New System.Drawing.Size(184, 6)
      ' 
      ' _actualSizeToolStripMenuItem
      ' 
      Me._actualSizeToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.ActualSize
      Me._actualSizeToolStripMenuItem.Name = "_actualSizeToolStripMenuItem"
      Me._actualSizeToolStripMenuItem.Size = New System.Drawing.Size(187, 30)
      Me._actualSizeToolStripMenuItem.Text = "&Actual size"
      Me._actualSizeToolStripMenuItem.ToolTipText = "Fit the image into the window"
      ' 
      ' _fitPageToolStripMenuItem
      ' 
      Me._fitPageToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.FitPage
      Me._fitPageToolStripMenuItem.Name = "_fitPageToolStripMenuItem"
      Me._fitPageToolStripMenuItem.Size = New System.Drawing.Size(187, 30)
      Me._fitPageToolStripMenuItem.Text = "Fit &page"
      Me._fitPageToolStripMenuItem.ToolTipText = "Fit the image into the window"
      ' 
      ' _fitWidthToolStripMenuItem
      ' 
      Me._fitWidthToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.FitWidth
      Me._fitWidthToolStripMenuItem.Name = "_fitWidthToolStripMenuItem"
      Me._fitWidthToolStripMenuItem.Size = New System.Drawing.Size(187, 30)
      Me._fitWidthToolStripMenuItem.Text = "&Fit width"
      Me._fitWidthToolStripMenuItem.ToolTipText = "Fit the image width into the window"
      ' 
      ' _viewSep3ToolStripMenuItem
      ' 
      Me._viewSep3ToolStripMenuItem.Name = "_viewSep3ToolStripMenuItem"
      Me._viewSep3ToolStripMenuItem.Size = New System.Drawing.Size(184, 6)
      ' 
      ' _asSvgToolStripMenuItem
      ' 
      Me._asSvgToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.ViewAsSvg
      Me._asSvgToolStripMenuItem.Name = "_asSvgToolStripMenuItem"
      Me._asSvgToolStripMenuItem.Size = New System.Drawing.Size(187, 30)
      Me._asSvgToolStripMenuItem.Text = "As &SVG"
      AddHandler Me._asSvgToolStripMenuItem.Click, AddressOf Me._asSvgToolStripMenuItem_Click
      ' 
      ' _asImageToolStripMenuItem
      ' 
      Me._asImageToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.ViewAsImage
      Me._asImageToolStripMenuItem.Name = "_asImageToolStripMenuItem"
      Me._asImageToolStripMenuItem.Size = New System.Drawing.Size(187, 30)
      Me._asImageToolStripMenuItem.Text = "As image"
      AddHandler Me._asImageToolStripMenuItem.Click, AddressOf Me._asImageToolStripMenuItem_Click
      ' 
      ' _viewSep4ToolStripMenuItem
      ' 
      Me._viewSep4ToolStripMenuItem.Name = "_viewSep4ToolStripMenuItem"
      Me._viewSep4ToolStripMenuItem.Size = New System.Drawing.Size(184, 6)
      ' 
      ' _thumbnailsToolStripMenuItem
      ' 
      Me._thumbnailsToolStripMenuItem.Name = "_thumbnailsToolStripMenuItem"
      Me._thumbnailsToolStripMenuItem.Size = New System.Drawing.Size(187, 30)
      Me._thumbnailsToolStripMenuItem.Text = "&Thumbnails"
      Me._thumbnailsToolStripMenuItem.ToolTipText = "Show pages thumbnails"
      AddHandler Me._thumbnailsToolStripMenuItem.Click, AddressOf Me._thumbnailsToolStripMenuItem_Click
      ' 
      ' _bookmarksToolStripMenuItem
      ' 
      Me._bookmarksToolStripMenuItem.Name = "_bookmarksToolStripMenuItem"
      Me._bookmarksToolStripMenuItem.Size = New System.Drawing.Size(187, 30)
      Me._bookmarksToolStripMenuItem.Text = "&Bookmarks"
      Me._bookmarksToolStripMenuItem.ToolTipText = "Show document bookmarks"
      AddHandler Me._bookmarksToolStripMenuItem.Click, AddressOf Me._bookmarksToolStripMenuItem_Click
      ' 
      ' _pageToolStripMenuItem
      ' 
      Me._pageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._firstPageToolStripMenuItem, Me._previousPageToolStripMenuItem, Me._nextPageToolStripMenuItem, Me._lastPageToolStripMenuItem, Me._gotoPageToolStripMenuItem, Me._pageSep1ToolStripSeparator, Me._getCurrentPageTextToolStripMenuItem, Me._getAllPagesTextToolStripMenuItem, Me._pageSep2ToolStripSeparator, Me._rotatePageClockwiseToolStripMenuItem, Me._rotatePageCounterClockwiseToolStripMenuItem, Me._rotatePagesToolStripMenuItem, Me._pageSep3ToolStripSeparator, Me._enableDisablePageToolStripMenuItem, Me._pageSep4ToolStripSeparator, Me._displayPageToolStripMenuItem})
      Me._pageToolStripMenuItem.Name = "_pageToolStripMenuItem"
      Me._pageToolStripMenuItem.Size = New System.Drawing.Size(62, 29)
      Me._pageToolStripMenuItem.Text = "&Page"
      AddHandler Me._pageToolStripMenuItem.DropDownOpening, AddressOf Me._pageToolStripMenuItem_DropDownOpening
      ' 
      ' _firstPageToolStripMenuItem
      ' 
      Me._firstPageToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.FirstPage
      Me._firstPageToolStripMenuItem.Name = "_firstPageToolStripMenuItem"
      Me._firstPageToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
      Me._firstPageToolStripMenuItem.Text = "&First"
      ' 
      ' _previousPageToolStripMenuItem
      ' 
      Me._previousPageToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.PreviousPage
      Me._previousPageToolStripMenuItem.Name = "_previousPageToolStripMenuItem"
      Me._previousPageToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
      Me._previousPageToolStripMenuItem.Text = "&Previous"
      Me._previousPageToolStripMenuItem.ToolTipText = "Go to previous page in the document"
      ' 
      ' _nextPageToolStripMenuItem
      ' 
      Me._nextPageToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.NextPage
      Me._nextPageToolStripMenuItem.Name = "_nextPageToolStripMenuItem"
      Me._nextPageToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
      Me._nextPageToolStripMenuItem.Text = "&Next"
      Me._nextPageToolStripMenuItem.ToolTipText = "Go to next page in the document"
      ' 
      ' _lastPageToolStripMenuItem
      ' 
      Me._lastPageToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.LastPage
      Me._lastPageToolStripMenuItem.Name = "_lastPageToolStripMenuItem"
      Me._lastPageToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
      Me._lastPageToolStripMenuItem.Text = "&Last "
      ' 
      ' _gotoPageToolStripMenuItem
      ' 
      Me._gotoPageToolStripMenuItem.Name = "_gotoPageToolStripMenuItem"
      Me._gotoPageToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
      Me._gotoPageToolStripMenuItem.Text = "&Goto page..."
      Me._gotoPageToolStripMenuItem.ToolTipText = "Go to a specific page in the document"
      AddHandler Me._gotoPageToolStripMenuItem.Click, AddressOf Me._gotoPageToolStripMenuItem_Click
      ' 
      ' _pageSep1ToolStripSeparator
      ' 
      Me._pageSep1ToolStripSeparator.Name = "_pageSep1ToolStripSeparator"
      Me._pageSep1ToolStripSeparator.Size = New System.Drawing.Size(288, 6)
      ' 
      ' _getCurrentPageTextToolStripMenuItem
      ' 
      Me._getCurrentPageTextToolStripMenuItem.Name = "_getCurrentPageTextToolStripMenuItem"
      Me._getCurrentPageTextToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
      Me._getCurrentPageTextToolStripMenuItem.Text = "Get &text for current page"
      AddHandler Me._getCurrentPageTextToolStripMenuItem.Click, AddressOf Me._getCurrentPageTextToolStripMenuItem_Click
      ' 
      ' _getAllPagesTextToolStripMenuItem
      ' 
      Me._getAllPagesTextToolStripMenuItem.Name = "_getAllPagesTextToolStripMenuItem"
      Me._getAllPagesTextToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
      Me._getAllPagesTextToolStripMenuItem.Text = "Get text for &all pages"
      AddHandler Me._getAllPagesTextToolStripMenuItem.Click, AddressOf Me._getAllPagesTextToolStripMenuItem_Click
      ' 
      ' _pageSep2ToolStripSeparator
      ' 
      Me._pageSep2ToolStripSeparator.Name = "_pageSep2ToolStripSeparator"
      Me._pageSep2ToolStripSeparator.Size = New System.Drawing.Size(288, 6)
      ' 
      ' _rotatePageClockwiseToolStripMenuItem
      ' 
      Me._rotatePageClockwiseToolStripMenuItem.Name = "_rotatePageClockwiseToolStripMenuItem"
      Me._rotatePageClockwiseToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
      Me._rotatePageClockwiseToolStripMenuItem.Text = "&Rotate clockwise"
      Me._rotatePageClockwiseToolStripMenuItem.ToolTipText = "Rotate the current page by 90 degrees clockwise"
      ' 
      ' _rotatePageCounterClockwiseToolStripMenuItem
      ' 
      Me._rotatePageCounterClockwiseToolStripMenuItem.Name = "_rotatePageCounterClockwiseToolStripMenuItem"
      Me._rotatePageCounterClockwiseToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
      Me._rotatePageCounterClockwiseToolStripMenuItem.Text = "Rotate &counter clockwise"
      Me._rotatePageCounterClockwiseToolStripMenuItem.ToolTipText = "Rotate the current page by 90 degrees counter-clockwise"
      ' 
      ' _rotatePagesToolStripMenuItem
      ' 
      Me._rotatePagesToolStripMenuItem.Name = "_rotatePagesToolStripMenuItem"
      Me._rotatePagesToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
      Me._rotatePagesToolStripMenuItem.Text = "R&otate pages..."
      Me._rotatePagesToolStripMenuItem.ToolTipText = "Rotate document pages"
      AddHandler Me._rotatePagesToolStripMenuItem.Click, AddressOf Me._rotatePagesToolStripMenuItem_Click
      ' 
      ' _pageSep3ToolStripSeparator
      ' 
      Me._pageSep3ToolStripSeparator.Name = "_pageSep3ToolStripSeparator"
      Me._pageSep3ToolStripSeparator.Size = New System.Drawing.Size(288, 6)
      ' 
      ' _enableDisablePageToolStripMenuItem
      ' 
      Me._enableDisablePageToolStripMenuItem.Name = "_enableDisablePageToolStripMenuItem"
      Me._enableDisablePageToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
      Me._enableDisablePageToolStripMenuItem.Text = "Mark page as disabl&ed"
      Me._enableDisablePageToolStripMenuItem.ToolTipText = "Mark the current page as disabled in the document"
      AddHandler Me._enableDisablePageToolStripMenuItem.Click, AddressOf Me._enableDisablePageToolStripMenuItem_Click
      ' 
      ' _pageSep4ToolStripSeparator
      ' 
      Me._pageSep4ToolStripSeparator.Name = "_pageSep4ToolStripSeparator"
      Me._pageSep4ToolStripSeparator.Size = New System.Drawing.Size(288, 6)
      ' 
      ' _displayPageToolStripMenuItem
      ' 
      Me._displayPageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._singlePageToolStripMenuItem, Me._verticalPageToolStripMenuItem, Me._doublePageToolStripMenuItem, Me._horizontalPageToolStripMenuItem})
      Me._displayPageToolStripMenuItem.Name = "_displayPageToolStripMenuItem"
      Me._displayPageToolStripMenuItem.Size = New System.Drawing.Size(291, 30)
      Me._displayPageToolStripMenuItem.Text = "&Display"
      ' 
      ' _singlePageToolStripMenuItem
      ' 
      Me._singlePageToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.SingleLayout
      Me._singlePageToolStripMenuItem.Name = "_singlePageToolStripMenuItem"
      Me._singlePageToolStripMenuItem.Size = New System.Drawing.Size(178, 30)
      Me._singlePageToolStripMenuItem.Text = "&Single"
      Me._singlePageToolStripMenuItem.ToolTipText = "Single page display"
      ' 
      ' _verticalPageToolStripMenuItem
      ' 
      Me._verticalPageToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.VerticalLayout
      Me._verticalPageToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me._verticalPageToolStripMenuItem.Name = "_verticalPageToolStripMenuItem"
      Me._verticalPageToolStripMenuItem.Size = New System.Drawing.Size(178, 30)
      Me._verticalPageToolStripMenuItem.Text = "Vertical"
      Me._verticalPageToolStripMenuItem.ToolTipText = "Vertical page display"
      ' 
      ' _doublePageToolStripMenuItem
      ' 
      Me._doublePageToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.DoubleLayout
      Me._doublePageToolStripMenuItem.Name = "_doublePageToolStripMenuItem"
      Me._doublePageToolStripMenuItem.Size = New System.Drawing.Size(178, 30)
      Me._doublePageToolStripMenuItem.Text = "&Double"
      Me._doublePageToolStripMenuItem.ToolTipText = "Double page display"
      ' 
      ' _horizontalPageToolStripMenuItem
      ' 
      Me._horizontalPageToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.HorizontalLayout
      Me._horizontalPageToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
      Me._horizontalPageToolStripMenuItem.Name = "_horizontalPageToolStripMenuItem"
      Me._horizontalPageToolStripMenuItem.Size = New System.Drawing.Size(178, 30)
      Me._horizontalPageToolStripMenuItem.Text = "Horizontal"
      Me._horizontalPageToolStripMenuItem.ToolTipText = "Horizontal page display"
      ' 
      ' _interactiveToolStripMenuItem
      ' 
      Me._interactiveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._selectTextToolStripMenuItem, Me._panZoomToolStripMenuItem, Me._panToolStripMenuItem, Me._zoomToolStripMenuItem, Me._zoomToToolStripMenuItem, Me._magnifyGlassToolStripMenuItem, Me._interactiveSep1ToolStripSeparator, Me._autoPanToolStripMenuItem, Me._inertiaScrollToolStripMenuItem})
      Me._interactiveToolStripMenuItem.Name = "_interactiveToolStripMenuItem"
      Me._interactiveToolStripMenuItem.Size = New System.Drawing.Size(105, 29)
      Me._interactiveToolStripMenuItem.Text = "&Interactive"
      AddHandler Me._interactiveToolStripMenuItem.DropDownOpening, AddressOf Me._interactiveToolStripMenuItem_DropDownOpening
      ' 
      ' _selectTextToolStripMenuItem
      ' 
      Me._selectTextToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.SelectTextMode
      Me._selectTextToolStripMenuItem.Name = "_selectTextToolStripMenuItem"
      Me._selectTextToolStripMenuItem.Size = New System.Drawing.Size(206, 30)
      Me._selectTextToolStripMenuItem.Text = "&Select text"
      ' 
      ' _panZoomToolStripMenuItem
      ' 
      Me._panZoomToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.PanZoomMode
      Me._panZoomToolStripMenuItem.Name = "_panZoomToolStripMenuItem"
      Me._panZoomToolStripMenuItem.Size = New System.Drawing.Size(206, 30)
      Me._panZoomToolStripMenuItem.Text = "P&an zoom"
      ' 
      ' _panToolStripMenuItem
      ' 
      Me._panToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.PanMode
      Me._panToolStripMenuItem.Name = "_panToolStripMenuItem"
      Me._panToolStripMenuItem.Size = New System.Drawing.Size(206, 30)
      Me._panToolStripMenuItem.Text = "&Pan"
      ' 
      ' _zoomToolStripMenuItem
      ' 
      Me._zoomToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.ZoomMode
      Me._zoomToolStripMenuItem.Name = "_zoomToolStripMenuItem"
      Me._zoomToolStripMenuItem.Size = New System.Drawing.Size(206, 30)
      Me._zoomToolStripMenuItem.Text = "&Zoom"
      ' 
      ' _zoomToToolStripMenuItem
      ' 
      Me._zoomToToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.ZoomToMode
      Me._zoomToToolStripMenuItem.Name = "_zoomToToolStripMenuItem"
      Me._zoomToToolStripMenuItem.Size = New System.Drawing.Size(206, 30)
      Me._zoomToToolStripMenuItem.Text = "Zoom &to"
      ' 
      ' _magnifyGlassToolStripMenuItem
      ' 
      Me._magnifyGlassToolStripMenuItem.Image = Global.DocumentViewerDemo.Resources.MagnifyGlassMode
      Me._magnifyGlassToolStripMenuItem.Name = "_magnifyGlassToolStripMenuItem"
      Me._magnifyGlassToolStripMenuItem.Size = New System.Drawing.Size(206, 30)
      Me._magnifyGlassToolStripMenuItem.Text = "&Magnify glass"
      ' 
      ' _interactiveSep1ToolStripSeparator
      ' 
      Me._interactiveSep1ToolStripSeparator.Name = "_interactiveSep1ToolStripSeparator"
      Me._interactiveSep1ToolStripSeparator.Size = New System.Drawing.Size(203, 6)
      ' 
      ' _autoPanToolStripMenuItem
      ' 
      Me._autoPanToolStripMenuItem.Name = "_autoPanToolStripMenuItem"
      Me._autoPanToolStripMenuItem.Size = New System.Drawing.Size(206, 30)
      Me._autoPanToolStripMenuItem.Text = "A&uto pan"
      ' 
      ' _inertiaScrollToolStripMenuItem
      ' 
      Me._inertiaScrollToolStripMenuItem.Name = "_inertiaScrollToolStripMenuItem"
      Me._inertiaScrollToolStripMenuItem.Size = New System.Drawing.Size(206, 30)
      Me._inertiaScrollToolStripMenuItem.Text = "&Inertia scroll"
      AddHandler Me._inertiaScrollToolStripMenuItem.Click, AddressOf Me._inertiaScrollToolStripMenuItem_Click
      ' 
      ' _annotationsToolStripMenuItem
      ' 
      Me._annotationsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._userModeToolStripMenuItem, Me._annotationsSep1ToolStripSeparator, Me._currentObjectToolStripMenuItem, Me._annotationsSep2ToolStripSeparator, Me._alignToolStripMenuItem, Me._flipToolStripMenuItem, Me._groupToolStripMenuItem, Me._securityToolStripMenuItem, Me._resetRotatePointsToolStripMenuItem, Me._antiAliasToolStripMenuItem, Me._annotationsPropertiesToolStripMenuItem, Me._annotationsSep3ToolStripSeparator, Me._behaviorToolStripMenuItem, Me._annotationsSep4ToolStripSeparator, Me._redactionOptionsToolStripMenuItem})
      Me._annotationsToolStripMenuItem.Name = "_annotationsToolStripMenuItem"
      Me._annotationsToolStripMenuItem.Size = New System.Drawing.Size(121, 29)
      Me._annotationsToolStripMenuItem.Text = "&Annotations"
      AddHandler Me._annotationsToolStripMenuItem.DropDownOpening, AddressOf Me._annotationsToolStripMenuItem_DropDownOpening
      ' 
      ' _userModeToolStripMenuItem
      ' 
      Me._userModeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._userModeDesignToolStripMenuItem, Me._userModeRunToolStripMenuItem, Me._userModeRenderToolStripMenuItem, Me._userModeSep1ToolStripMenuItem, Me._customizeRenderModeToolStripMenuItem})
      Me._userModeToolStripMenuItem.Name = "_userModeToolStripMenuItem"
      Me._userModeToolStripMenuItem.Size = New System.Drawing.Size(245, 30)
      Me._userModeToolStripMenuItem.Text = "&User mode"
      ' 
      ' _userModeDesignToolStripMenuItem
      ' 
      Me._userModeDesignToolStripMenuItem.Name = "_userModeDesignToolStripMenuItem"
      Me._userModeDesignToolStripMenuItem.Size = New System.Drawing.Size(299, 30)
      Me._userModeDesignToolStripMenuItem.Text = "&Design"
      Me._userModeDesignToolStripMenuItem.ToolTipText = "Allows editing of the annotations objects"
      ' 
      ' _userModeRunToolStripMenuItem
      ' 
      Me._userModeRunToolStripMenuItem.Name = "_userModeRunToolStripMenuItem"
      Me._userModeRunToolStripMenuItem.Size = New System.Drawing.Size(299, 30)
      Me._userModeRunToolStripMenuItem.Text = "&Run"
      Me._userModeRunToolStripMenuItem.ToolTipText = "Allows running the annotations objects and clicking the hyperlinks"
      ' 
      ' _userModeRenderToolStripMenuItem
      ' 
      Me._userModeRenderToolStripMenuItem.Name = "_userModeRenderToolStripMenuItem"
      Me._userModeRenderToolStripMenuItem.Size = New System.Drawing.Size(299, 30)
      Me._userModeRenderToolStripMenuItem.Text = "R&ender"
      Me._userModeRenderToolStripMenuItem.ToolTipText = "Render the annotations only. No editing and no running"
      ' 
      ' _userModeSep1ToolStripMenuItem
      ' 
      Me._userModeSep1ToolStripMenuItem.Name = "_userModeSep1ToolStripMenuItem"
      Me._userModeSep1ToolStripMenuItem.Size = New System.Drawing.Size(296, 6)
      ' 
      ' _customizeRenderModeToolStripMenuItem
      ' 
      Me._customizeRenderModeToolStripMenuItem.Name = "_customizeRenderModeToolStripMenuItem"
      Me._customizeRenderModeToolStripMenuItem.Size = New System.Drawing.Size(299, 30)
      Me._customizeRenderModeToolStripMenuItem.Text = "&Customize render mode..."
      AddHandler Me._customizeRenderModeToolStripMenuItem.Click, AddressOf Me._customizeRenderModeToolStripMenuItem_Click
      ' 
      ' _annotationsSep1ToolStripSeparator
      ' 
      Me._annotationsSep1ToolStripSeparator.Name = "_annotationsSep1ToolStripSeparator"
      Me._annotationsSep1ToolStripSeparator.Size = New System.Drawing.Size(242, 6)
      ' 
      ' _currentObjectToolStripMenuItem
      ' 
      Me._currentObjectToolStripMenuItem.Name = "_currentObjectToolStripMenuItem"
      Me._currentObjectToolStripMenuItem.Size = New System.Drawing.Size(245, 30)
      Me._currentObjectToolStripMenuItem.Text = "&Current object..."
      AddHandler Me._currentObjectToolStripMenuItem.Click, AddressOf Me._currentObjectToolStripMenuItem_Click
      ' 
      ' _annotationsSep2ToolStripSeparator
      ' 
      Me._annotationsSep2ToolStripSeparator.Name = "_annotationsSep2ToolStripSeparator"
      Me._annotationsSep2ToolStripSeparator.Size = New System.Drawing.Size(242, 6)
      ' 
      ' _alignToolStripMenuItem
      ' 
      Me._alignToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._alignBringToFrontToolStripMenuItem, Me._alignSendToBackToolStripMenuItem, Me._alignBringToFirstToolStripMenuItem, Me._alignSendToLastToolStripMenuItem})
      Me._alignToolStripMenuItem.Name = "_alignToolStripMenuItem"
      Me._alignToolStripMenuItem.Size = New System.Drawing.Size(245, 30)
      Me._alignToolStripMenuItem.Text = "&Align"
      ' 
      ' _alignBringToFrontToolStripMenuItem
      ' 
      Me._alignBringToFrontToolStripMenuItem.Name = "_alignBringToFrontToolStripMenuItem"
      Me._alignBringToFrontToolStripMenuItem.Size = New System.Drawing.Size(203, 30)
      Me._alignBringToFrontToolStripMenuItem.Text = "&Bring to front"
      ' 
      ' _alignSendToBackToolStripMenuItem
      ' 
      Me._alignSendToBackToolStripMenuItem.Name = "_alignSendToBackToolStripMenuItem"
      Me._alignSendToBackToolStripMenuItem.Size = New System.Drawing.Size(203, 30)
      Me._alignSendToBackToolStripMenuItem.Text = "Send to &back"
      ' 
      ' _alignBringToFirstToolStripMenuItem
      ' 
      Me._alignBringToFirstToolStripMenuItem.Name = "_alignBringToFirstToolStripMenuItem"
      Me._alignBringToFirstToolStripMenuItem.Size = New System.Drawing.Size(203, 30)
      Me._alignBringToFirstToolStripMenuItem.Text = "Bring to &first"
      ' 
      ' _alignSendToLastToolStripMenuItem
      ' 
      Me._alignSendToLastToolStripMenuItem.Name = "_alignSendToLastToolStripMenuItem"
      Me._alignSendToLastToolStripMenuItem.Size = New System.Drawing.Size(203, 30)
      Me._alignSendToLastToolStripMenuItem.Text = "Send to &last"
      ' 
      ' _flipToolStripMenuItem
      ' 
      Me._flipToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._flipVerticalToolStripMenuItem, Me._flipHorizontalToolStripMenuItem})
      Me._flipToolStripMenuItem.Name = "_flipToolStripMenuItem"
      Me._flipToolStripMenuItem.Size = New System.Drawing.Size(245, 30)
      Me._flipToolStripMenuItem.Text = "&Flip"
      ' 
      ' _flipVerticalToolStripMenuItem
      ' 
      Me._flipVerticalToolStripMenuItem.Name = "_flipVerticalToolStripMenuItem"
      Me._flipVerticalToolStripMenuItem.Size = New System.Drawing.Size(178, 30)
      Me._flipVerticalToolStripMenuItem.Text = "&Vertical"
      ' 
      ' _flipHorizontalToolStripMenuItem
      ' 
      Me._flipHorizontalToolStripMenuItem.Name = "_flipHorizontalToolStripMenuItem"
      Me._flipHorizontalToolStripMenuItem.Size = New System.Drawing.Size(178, 30)
      Me._flipHorizontalToolStripMenuItem.Text = "&Horizontal"
      ' 
      ' _groupToolStripMenuItem
      ' 
      Me._groupToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._groupSelectedObjectsToolStripMenuItem, Me._groupUngroupToolStripMenuItem})
      Me._groupToolStripMenuItem.Name = "_groupToolStripMenuItem"
      Me._groupToolStripMenuItem.Size = New System.Drawing.Size(245, 30)
      Me._groupToolStripMenuItem.Text = "&Group"
      ' 
      ' _groupSelectedObjectsToolStripMenuItem
      ' 
      Me._groupSelectedObjectsToolStripMenuItem.Name = "_groupSelectedObjectsToolStripMenuItem"
      Me._groupSelectedObjectsToolStripMenuItem.Size = New System.Drawing.Size(277, 30)
      Me._groupSelectedObjectsToolStripMenuItem.Text = "&Group selected objects"
      ' 
      ' _groupUngroupToolStripMenuItem
      ' 
      Me._groupUngroupToolStripMenuItem.Name = "_groupUngroupToolStripMenuItem"
      Me._groupUngroupToolStripMenuItem.Size = New System.Drawing.Size(277, 30)
      Me._groupUngroupToolStripMenuItem.Text = "&Ungroup"
      ' 
      ' _securityToolStripMenuItem
      ' 
      Me._securityToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._securityLockToolStripMenuItem, Me._securityUnlockToolStripMenuItem})
      Me._securityToolStripMenuItem.Name = "_securityToolStripMenuItem"
      Me._securityToolStripMenuItem.Size = New System.Drawing.Size(245, 30)
      Me._securityToolStripMenuItem.Text = "&Security"
      ' 
      ' _securityLockToolStripMenuItem
      ' 
      Me._securityLockToolStripMenuItem.Name = "_securityLockToolStripMenuItem"
      Me._securityLockToolStripMenuItem.Size = New System.Drawing.Size(162, 30)
      Me._securityLockToolStripMenuItem.Text = "&Lock..."
      ' 
      ' _securityUnlockToolStripMenuItem
      ' 
      Me._securityUnlockToolStripMenuItem.Name = "_securityUnlockToolStripMenuItem"
      Me._securityUnlockToolStripMenuItem.Size = New System.Drawing.Size(162, 30)
      Me._securityUnlockToolStripMenuItem.Text = "&Unlock..."
      ' 
      ' _resetRotatePointsToolStripMenuItem
      ' 
      Me._resetRotatePointsToolStripMenuItem.Name = "_resetRotatePointsToolStripMenuItem"
      Me._resetRotatePointsToolStripMenuItem.Size = New System.Drawing.Size(245, 30)
      Me._resetRotatePointsToolStripMenuItem.Text = "Reset rotate p&oints"
      ' 
      ' _antiAliasToolStripMenuItem
      ' 
      Me._antiAliasToolStripMenuItem.Name = "_antiAliasToolStripMenuItem"
      Me._antiAliasToolStripMenuItem.Size = New System.Drawing.Size(245, 30)
      Me._antiAliasToolStripMenuItem.Text = "A&nti alias"
      ' 
      ' _annotationsPropertiesToolStripMenuItem
      ' 
      Me._annotationsPropertiesToolStripMenuItem.Name = "_annotationsPropertiesToolStripMenuItem"
      Me._annotationsPropertiesToolStripMenuItem.Size = New System.Drawing.Size(245, 30)
      Me._annotationsPropertiesToolStripMenuItem.Text = "&Properties..."
      ' 
      ' _annotationsSep3ToolStripSeparator
      ' 
      Me._annotationsSep3ToolStripSeparator.Name = "_annotationsSep3ToolStripSeparator"
      Me._annotationsSep3ToolStripSeparator.Size = New System.Drawing.Size(242, 6)
      ' 
      ' _behaviorToolStripMenuItem
      ' 
      Me._behaviorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._behaviorUseRotateThumbsToolStripMenuItem, Me._behaviorEnableToolTipToolStripMenuItem, Me._behaviorRenderOnThumbnailsToolStripMenuItem, Me._behaviorDeselectOnDownToolStripMenuItem, Me._behaviorRestrictDesignersToolStripMenuItem, Me._behaviorRubberbandSelectToolStripMenuItem})
      Me._behaviorToolStripMenuItem.Name = "_behaviorToolStripMenuItem"
      Me._behaviorToolStripMenuItem.Size = New System.Drawing.Size(245, 30)
      Me._behaviorToolStripMenuItem.Text = "&Behavior"
      AddHandler Me._behaviorToolStripMenuItem.DropDownOpening, AddressOf Me._behaviorToolStripMenuItem_DropDownOpening
      ' 
      ' _annotationsSep3ToolStripSeparator
      ' 
      Me._annotationsSep4ToolStripSeparator.Name = "_annotationsSep3ToolStripSeparator"
      Me._annotationsSep4ToolStripSeparator.Size = New System.Drawing.Size(242, 6)
      ' 
      ' _redactionOptionsToolStripMenuItem
      ' 
      Me._redactionOptionsToolStripMenuItem.Name = "_redactionOptionsToolStripMenuItem"
      Me._redactionOptionsToolStripMenuItem.Size = New System.Drawing.Size(245, 30)
      Me._redactionOptionsToolStripMenuItem.Text = "&Redaction Options..."
      AddHandler Me._redactionOptionsToolStripMenuItem.Click, AddressOf Me._redactionOptionsToolStripMenuItem_Click

      ' 
      ' _behaviorUseRotateThumbsToolStripMenuItem
      ' 
      Me._behaviorUseRotateThumbsToolStripMenuItem.Name = "_behaviorUseRotateThumbsToolStripMenuItem"
      Me._behaviorUseRotateThumbsToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys))
      Me._behaviorUseRotateThumbsToolStripMenuItem.Size = New System.Drawing.Size(306, 30)
      Me._behaviorUseRotateThumbsToolStripMenuItem.Text = "&Use rotate thumbs"
      ' 
      ' _behaviorEnableToolTipToolStripMenuItem
      ' 
      Me._behaviorEnableToolTipToolStripMenuItem.Name = "_behaviorEnableToolTipToolStripMenuItem"
      Me._behaviorEnableToolTipToolStripMenuItem.Size = New System.Drawing.Size(306, 30)
      Me._behaviorEnableToolTipToolStripMenuItem.Text = "&Enable tool tip"
      ' 
      ' _behaviorRenderOnThumbnailsToolStripMenuItem
      ' 
      Me._behaviorRenderOnThumbnailsToolStripMenuItem.Name = "_behaviorRenderOnThumbnailsToolStripMenuItem"
      Me._behaviorRenderOnThumbnailsToolStripMenuItem.Size = New System.Drawing.Size(306, 30)
      Me._behaviorRenderOnThumbnailsToolStripMenuItem.Text = "&Render on thumbnails"
      ' 
      ' _behaviorDeselectOnDownToolStripMenuItem
      ' 
      Me._behaviorDeselectOnDownToolStripMenuItem.Name = "_behaviorDeselectOnDownToolStripMenuItem"
      Me._behaviorDeselectOnDownToolStripMenuItem.Size = New System.Drawing.Size(306, 30)
      Me._behaviorDeselectOnDownToolStripMenuItem.Text = "&Deselect on down"
      AddHandler Me._behaviorDeselectOnDownToolStripMenuItem.Click, AddressOf Me._behaviorDeselectOnDownToolStripMenuItem_Click
      ' 
      ' _behaviorRestrictDesignersToolStripMenuItem
      ' 
      Me._behaviorRestrictDesignersToolStripMenuItem.Name = "_behaviorRestrictDesignersToolStripMenuItem"
      Me._behaviorRestrictDesignersToolStripMenuItem.Size = New System.Drawing.Size(306, 30)
      Me._behaviorRestrictDesignersToolStripMenuItem.Text = "Res&trict Designers"
      AddHandler Me._behaviorRestrictDesignersToolStripMenuItem.Click, AddressOf Me._behaviorRestrictDesignersToolStripMenuItem_Click
      ' 
      ' _behaviorRubberbandSelectToolStripMenuItem
      ' 
      Me._behaviorRubberbandSelectToolStripMenuItem.Name = "_behaviorRubberbandSelectToolStripMenuItem"
      Me._behaviorRubberbandSelectToolStripMenuItem.Size = New System.Drawing.Size(306, 30)
      Me._behaviorRubberbandSelectToolStripMenuItem.Text = "Ru&bberband Select"
      AddHandler Me._behaviorRubberbandSelectToolStripMenuItem.Click, AddressOf Me._behaviorRubberbandSelectToolStripMenuItem_Click
      ' 
      ' _preferencesToolStripMenuItem
      ' 
      Me._preferencesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._userNameToolStripMenuItem, Me._cacheDirectoryToolStripMenuItem, Me._autoGetTextToolStripMenuItem, Me._documentTextOptionsToolStripMenuItem, Me._showTextIndicatorsToolStripMenuItem, Me._showOperationsToolStripMenuItem, Me._diagnosticsToolStripMenuItem, Me._documentViewerOptionsToolStripMenuItem})
      Me._preferencesToolStripMenuItem.Name = "_preferencesToolStripMenuItem"
      Me._preferencesToolStripMenuItem.Size = New System.Drawing.Size(114, 29)
      Me._preferencesToolStripMenuItem.Text = "P&references"
      AddHandler Me._preferencesToolStripMenuItem.DropDownOpening, AddressOf Me._preferencesToolStripMenuItem_DropDownOpening
      ' 
      ' _userNameToolStripMenuItem
      ' 
      Me._userNameToolStripMenuItem.Name = "_userNameToolStripMenuItem"
      Me._userNameToolStripMenuItem.Size = New System.Drawing.Size(314, 30)
      Me._userNameToolStripMenuItem.Text = "&User name..."
      Me._userNameToolStripMenuItem.ToolTipText = "Change the current user name used with the document"
      AddHandler Me._userNameToolStripMenuItem.Click, AddressOf Me._userNameToolStripMenuItem_Click
      ' 
      ' _cacheDirectoryToolStripMenuItem
      ' 
      Me._cacheDirectoryToolStripMenuItem.Name = "_cacheDirectoryToolStripMenuItem"
      Me._cacheDirectoryToolStripMenuItem.Size = New System.Drawing.Size(314, 30)
      Me._cacheDirectoryToolStripMenuItem.Text = "&Cache directory..."
      Me._cacheDirectoryToolStripMenuItem.ToolTipText = "Change the cache directory used by this application"
      AddHandler Me._cacheDirectoryToolStripMenuItem.Click, AddressOf Me._cacheDirectoryToolStripMenuItem_Click
      ' 
      ' _autoGetTextToolStripMenuItem
      ' 
      Me._autoGetTextToolStripMenuItem.Name = "_autoGetTextToolStripMenuItem"
      Me._autoGetTextToolStripMenuItem.Size = New System.Drawing.Size(314, 30)
      Me._autoGetTextToolStripMenuItem.Text = "&Auto get text"
      Me._autoGetTextToolStripMenuItem.ToolTipText = "Automatically get the text when needed"
      AddHandler Me._autoGetTextToolStripMenuItem.Click, AddressOf Me._autoGetTextToolStripMenuItem_Click
      ' 
      ' _documentTextOptionsToolStripMenuItem
      ' 
      Me._documentTextOptionsToolStripMenuItem.Name = "_documentTextOptionsToolStripMenuItem"
      Me._documentTextOptionsToolStripMenuItem.Size = New System.Drawing.Size(314, 30)
      Me._documentTextOptionsToolStripMenuItem.Text = "Document text &options..."
      Me._documentTextOptionsToolStripMenuItem.ToolTipText = "Show the document text options"
      AddHandler Me._documentTextOptionsToolStripMenuItem.Click, AddressOf Me._documentTextOptionsToolStripMenuItem_Click
      ' 
      ' _showTextIndicatorsToolStripMenuItem
      ' 
      Me._showTextIndicatorsToolStripMenuItem.Name = "_showTextIndicatorsToolStripMenuItem"
      Me._showTextIndicatorsToolStripMenuItem.Size = New System.Drawing.Size(314, 30)
      Me._showTextIndicatorsToolStripMenuItem.Text = "Show &text indicators"
      Me._showTextIndicatorsToolStripMenuItem.ToolTipText = "Show the text indicators on the pages"
      AddHandler Me._showTextIndicatorsToolStripMenuItem.Click, AddressOf Me._showTextIndicatorsToolStripMenuItem_Click
      ' 
      ' _showOperationsToolStripMenuItem
      ' 
      Me._showOperationsToolStripMenuItem.Name = "_showOperationsToolStripMenuItem"
      Me._showOperationsToolStripMenuItem.Size = New System.Drawing.Size(314, 30)
      Me._showOperationsToolStripMenuItem.Text = "&Show operations"
      Me._showOperationsToolStripMenuItem.ToolTipText = "Show the operation pane"
      AddHandler Me._showOperationsToolStripMenuItem.Click, AddressOf Me._showOperationsToolStripMenuItem_Click
      ' 
      ' _diagnosticsToolStripMenuItem
      ' 
      Me._diagnosticsToolStripMenuItem.Name = "_diagnosticsToolStripMenuItem"
      Me._diagnosticsToolStripMenuItem.Size = New System.Drawing.Size(314, 30)
      Me._diagnosticsToolStripMenuItem.Text = "&Diagnostics..."
      Me._diagnosticsToolStripMenuItem.ToolTipText = "Show the diagnostics dialog"
      AddHandler Me._diagnosticsToolStripMenuItem.Click, AddressOf Me._diagnosticsToolStripMenuItem_Click
      ' 
      ' _documentViewerOptionsToolStripMenuItem
      ' 
      Me._documentViewerOptionsToolStripMenuItem.Name = "_documentViewerOptionsToolStripMenuItem"
      Me._documentViewerOptionsToolStripMenuItem.Size = New System.Drawing.Size(314, 30)
      Me._documentViewerOptionsToolStripMenuItem.Text = "Document &Viewer options..."
      AddHandler Me._documentViewerOptionsToolStripMenuItem.Click, AddressOf Me._documentViewerOptionsToolStripMenuItem_Click
      ' 
      ' _helpToolStripMenuItem
      ' 
      Me._helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._aboutToolStripMenuItem})
      Me._helpToolStripMenuItem.Name = "_helpToolStripMenuItem"
      Me._helpToolStripMenuItem.Size = New System.Drawing.Size(61, 29)
      Me._helpToolStripMenuItem.Text = "&Help"
      ' 
      ' _aboutToolStripMenuItem
      ' 
      Me._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem"
      Me._aboutToolStripMenuItem.Size = New System.Drawing.Size(158, 30)
      Me._aboutToolStripMenuItem.Text = "&About..."
      AddHandler Me._aboutToolStripMenuItem.Click, AddressOf Me._aboutToolStripMenuItem_Click
      ' 
      ' _mainToolStrip
      ' 
      Me._mainToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
      Me._mainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._openDocumentFromFileToolStripButton, Me._openDocumentFromUrlToolStripButton, Me._mainToolStripSeparator1, Me._previousPageToolStripButton, Me._nextPageToolStripButton, Me._pageNumberToolStripTextBox, Me._pageNumberToolStripLabel, Me._mainToolStripSeparator2, Me._zoomInToolStripButton, Me._zoomOutToolStripButton, Me._zoomToolStripComboBox, Me._actualSizeToolStripButton, Me._fitPageToolStripButton, Me._fitWidthToolStripButton, Me._mainToolStripSeparator3, Me._singlePageToolStripButton, Me._verticalPageToolStripButton, Me._doublePageToolStripButton, Me._horizontalPageToolStripButton, Me._mainToolStripSeparator4, Me._selectTextToolStripButton, Me._panZoomToolStripButton, Me._panToolStripButton, Me._zoomToolStripButton, Me._zoomToToolStripButton, Me._magnifyGlassToolStripButton})
      Me._mainToolStrip.Location = New System.Drawing.Point(0, 35)
      Me._mainToolStrip.Name = "_mainToolStrip"
      Me._mainToolStrip.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
      Me._mainToolStrip.Size = New System.Drawing.Size(1731, 33)
      Me._mainToolStrip.TabIndex = 1
      ' 
      ' _openDocumentFromFileToolStripButton
      ' 
      Me._openDocumentFromFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._openDocumentFromFileToolStripButton.Image = Global.DocumentViewerDemo.Resources.Open
      Me._openDocumentFromFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._openDocumentFromFileToolStripButton.Name = "_openDocumentFromFileToolStripButton"
      Me._openDocumentFromFileToolStripButton.Size = New System.Drawing.Size(28, 30)
      Me._openDocumentFromFileToolStripButton.ToolTipText = "Open document from a disk file"
      AddHandler Me._openDocumentFromFileToolStripButton.Click, AddressOf Me._openDocumentFromFileToolStripButton_Click
      ' 
      ' _openDocumentFromUrlToolStripButton
      ' 
      Me._openDocumentFromUrlToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._openDocumentFromUrlToolStripButton.Image = Global.DocumentViewerDemo.Resources.OpenUrl
      Me._openDocumentFromUrlToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._openDocumentFromUrlToolStripButton.Name = "_openDocumentFromUrlToolStripButton"
      Me._openDocumentFromUrlToolStripButton.Size = New System.Drawing.Size(28, 30)
      Me._openDocumentFromUrlToolStripButton.ToolTipText = "Open document from a web address"
      AddHandler Me._openDocumentFromUrlToolStripButton.Click, AddressOf Me._openDocumentFromUrlToolStripButton_Click
      ' 
      ' _mainToolStripSeparator1
      ' 
      Me._mainToolStripSeparator1.Name = "_mainToolStripSeparator1"
      Me._mainToolStripSeparator1.Size = New System.Drawing.Size(6, 33)
      ' 
      ' _previousPageToolStripButton
      ' 
      Me._previousPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._previousPageToolStripButton.Image = Global.DocumentViewerDemo.Resources.PreviousPage
      Me._previousPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._previousPageToolStripButton.Name = "_previousPageToolStripButton"
      Me._previousPageToolStripButton.Size = New System.Drawing.Size(28, 30)
      Me._previousPageToolStripButton.ToolTipText = "Go to previous page in the document"
      ' 
      ' _nextPageToolStripButton
      ' 
      Me._nextPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._nextPageToolStripButton.Image = Global.DocumentViewerDemo.Resources.NextPage
      Me._nextPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._nextPageToolStripButton.Name = "_nextPageToolStripButton"
      Me._nextPageToolStripButton.Size = New System.Drawing.Size(28, 30)
      Me._nextPageToolStripButton.ToolTipText = "Go to next page in the document"
      ' 
      ' _pageNumberToolStripTextBox
      ' 
      Me._pageNumberToolStripTextBox.Name = "_pageNumberToolStripTextBox"
      Me._pageNumberToolStripTextBox.Size = New System.Drawing.Size(88, 33)
      Me._pageNumberToolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me._pageNumberToolStripTextBox.ToolTipText = "Current page number"
      ' 
      ' _pageNumberToolStripLabel
      ' 
      Me._pageNumberToolStripLabel.AutoSize = False
      Me._pageNumberToolStripLabel.Name = "_pageNumberToolStripLabel"
      Me._pageNumberToolStripLabel.Size = New System.Drawing.Size(60, 22)
      Me._pageNumberToolStripLabel.Text = "/##"
      Me._pageNumberToolStripLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _mainToolStripSeparator2
      ' 
      Me._mainToolStripSeparator2.Name = "_mainToolStripSeparator2"
      Me._mainToolStripSeparator2.Size = New System.Drawing.Size(6, 33)
      ' 
      ' _zoomInToolStripButton
      ' 
      Me._zoomInToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._zoomInToolStripButton.Image = Global.DocumentViewerDemo.Resources.ZoomIn
      Me._zoomInToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._zoomInToolStripButton.Name = "_zoomInToolStripButton"
      Me._zoomInToolStripButton.Size = New System.Drawing.Size(28, 30)
      Me._zoomInToolStripButton.ToolTipText = "Zoom in"
      ' 
      ' _zoomOutToolStripButton
      ' 
      Me._zoomOutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._zoomOutToolStripButton.Image = Global.DocumentViewerDemo.Resources.ZoomOut
      Me._zoomOutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._zoomOutToolStripButton.Name = "_zoomOutToolStripButton"
      Me._zoomOutToolStripButton.Size = New System.Drawing.Size(28, 30)
      Me._zoomOutToolStripButton.ToolTipText = "Zoom out"
      ' 
      ' _zoomToolStripComboBox
      ' 
      Me._zoomToolStripComboBox.Name = "_zoomToolStripComboBox"
      Me._zoomToolStripComboBox.Size = New System.Drawing.Size(148, 33)
      ' 
      ' _actualSizeToolStripButton
      ' 
      Me._actualSizeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._actualSizeToolStripButton.Image = Global.DocumentViewerDemo.Resources.ActualSize
      Me._actualSizeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._actualSizeToolStripButton.Name = "_actualSizeToolStripButton"
      Me._actualSizeToolStripButton.Size = New System.Drawing.Size(28, 30)
      Me._actualSizeToolStripButton.ToolTipText = "Show the actual size of the page"
      ' 
      ' _fitPageToolStripButton
      ' 
      Me._fitPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._fitPageToolStripButton.Image = Global.DocumentViewerDemo.Resources.FitPage
      Me._fitPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._fitPageToolStripButton.Name = "_fitPageToolStripButton"
      Me._fitPageToolStripButton.Size = New System.Drawing.Size(28, 30)
      Me._fitPageToolStripButton.ToolTipText = "Fit the image into the window"
      ' 
      ' _fitWidthToolStripButton
      ' 
      Me._fitWidthToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._fitWidthToolStripButton.Image = Global.DocumentViewerDemo.Resources.FitWidth
      Me._fitWidthToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._fitWidthToolStripButton.Name = "_fitWidthToolStripButton"
      Me._fitWidthToolStripButton.Size = New System.Drawing.Size(28, 30)
      Me._fitWidthToolStripButton.ToolTipText = "Fit the image width into the window"
      ' 
      ' _mainToolStripSeparator3
      ' 
      Me._mainToolStripSeparator3.Name = "_mainToolStripSeparator3"
      Me._mainToolStripSeparator3.Size = New System.Drawing.Size(6, 33)
      ' 
      ' _singlePageToolStripButton
      ' 
      Me._singlePageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._singlePageToolStripButton.Image = Global.DocumentViewerDemo.Resources.SingleLayout
      Me._singlePageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._singlePageToolStripButton.Name = "_singlePageToolStripButton"
      Me._singlePageToolStripButton.Size = New System.Drawing.Size(28, 30)
      Me._singlePageToolStripButton.ToolTipText = "Single page display"
      ' 
      ' _verticalPageToolStripButton
      ' 
      Me._verticalPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._verticalPageToolStripButton.Image = Global.DocumentViewerDemo.Resources.VerticalLayout
      Me._verticalPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._verticalPageToolStripButton.Name = "_verticalPageToolStripButton"
      Me._verticalPageToolStripButton.Size = New System.Drawing.Size(28, 30)
      Me._verticalPageToolStripButton.ToolTipText = "Vertical page display"
      ' 
      ' _doublePageToolStripButton
      ' 
      Me._doublePageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._doublePageToolStripButton.Image = Global.DocumentViewerDemo.Resources.DoubleLayout
      Me._doublePageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._doublePageToolStripButton.Name = "_doublePageToolStripButton"
      Me._doublePageToolStripButton.Size = New System.Drawing.Size(28, 30)
      Me._doublePageToolStripButton.ToolTipText = "Double page display"
      ' 
      ' _horizontalPageToolStripButton
      ' 
      Me._horizontalPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._horizontalPageToolStripButton.Image = Global.DocumentViewerDemo.Resources.HorizontalLayout
      Me._horizontalPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._horizontalPageToolStripButton.Name = "_horizontalPageToolStripButton"
      Me._horizontalPageToolStripButton.Size = New System.Drawing.Size(28, 30)
      Me._horizontalPageToolStripButton.ToolTipText = "Horizontal page display"
      ' 
      ' _mainToolStripSeparator4
      ' 
      Me._mainToolStripSeparator4.Name = "_mainToolStripSeparator4"
      Me._mainToolStripSeparator4.Size = New System.Drawing.Size(6, 33)
      ' 
      ' _selectTextToolStripButton
      ' 
      Me._selectTextToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._selectTextToolStripButton.Image = Global.DocumentViewerDemo.Resources.SelectTextMode
      Me._selectTextToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._selectTextToolStripButton.Name = "_selectTextToolStripButton"
      Me._selectTextToolStripButton.Size = New System.Drawing.Size(28, 30)
      Me._selectTextToolStripButton.ToolTipText = "Select text"
      ' 
      ' _panZoomToolStripButton
      ' 
      Me._panZoomToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._panZoomToolStripButton.Image = Global.DocumentViewerDemo.Resources.PanZoomMode
      Me._panZoomToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._panZoomToolStripButton.Name = "_panZoomToolStripButton"
      Me._panZoomToolStripButton.Size = New System.Drawing.Size(28, 30)
      Me._panZoomToolStripButton.ToolTipText = "Pan and zoom"
      ' 
      ' _panToolStripButton
      ' 
      Me._panToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._panToolStripButton.Image = Global.DocumentViewerDemo.Resources.PanMode
      Me._panToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._panToolStripButton.Name = "_panToolStripButton"
      Me._panToolStripButton.Size = New System.Drawing.Size(28, 30)
      Me._panToolStripButton.ToolTipText = "Pan"
      ' 
      ' _zoomToolStripButton
      ' 
      Me._zoomToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._zoomToolStripButton.Image = Global.DocumentViewerDemo.Resources.ZoomMode
      Me._zoomToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._zoomToolStripButton.Name = "_zoomToolStripButton"
      Me._zoomToolStripButton.Size = New System.Drawing.Size(28, 30)
      Me._zoomToolStripButton.ToolTipText = "Zoom"
      ' 
      ' _zoomToToolStripButton
      ' 
      Me._zoomToToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._zoomToToolStripButton.Image = Global.DocumentViewerDemo.Resources.ZoomToMode
      Me._zoomToToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._zoomToToolStripButton.Name = "_zoomToToolStripButton"
      Me._zoomToToolStripButton.Size = New System.Drawing.Size(28, 30)
      Me._zoomToToolStripButton.ToolTipText = "Zoom to"
      ' 
      ' _magnifyGlassToolStripButton
      ' 
      Me._magnifyGlassToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._magnifyGlassToolStripButton.Image = Global.DocumentViewerDemo.Resources.MagnifyGlassMode
      Me._magnifyGlassToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._magnifyGlassToolStripButton.Name = "_magnifyGlassToolStripButton"
      Me._magnifyGlassToolStripButton.Size = New System.Drawing.Size(28, 30)
      Me._magnifyGlassToolStripButton.ToolTipText = "Magnify Glass"
      ' 
      ' _leftPanel
      ' 
      Me._leftPanel.Controls.Add(Me._leftTabControl)
      Me._leftPanel.Dock = System.Windows.Forms.DockStyle.Left
      Me._leftPanel.Location = New System.Drawing.Point(0, 68)
      Me._leftPanel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._leftPanel.Name = "_leftPanel"
      Me._leftPanel.Size = New System.Drawing.Size(300, 724)
      Me._leftPanel.TabIndex = 2
      ' 
      ' _leftTabControl
      ' 
      Me._leftTabControl.Controls.Add(Me._thumbnailsTabPage)
      Me._leftTabControl.Controls.Add(Me._bookmarksTabPage)
      Me._leftTabControl.Dock = System.Windows.Forms.DockStyle.Fill
      Me._leftTabControl.Location = New System.Drawing.Point(0, 0)
      Me._leftTabControl.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._leftTabControl.Name = "_leftTabControl"
      Me._leftTabControl.SelectedIndex = 0
      Me._leftTabControl.Size = New System.Drawing.Size(300, 724)
      Me._leftTabControl.TabIndex = 1
      ' 
      ' _thumbnailsTabPage
      ' 
      Me._thumbnailsTabPage.ContextMenuStrip = Me._thumbnailsContextMenuStrip
      Me._thumbnailsTabPage.Controls.Add(Me._loadingThumbnailsProgressBar)
      Me._thumbnailsTabPage.Location = New System.Drawing.Point(4, 29)
      Me._thumbnailsTabPage.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._thumbnailsTabPage.Name = "_thumbnailsTabPage"
      Me._thumbnailsTabPage.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._thumbnailsTabPage.Size = New System.Drawing.Size(292, 691)
      Me._thumbnailsTabPage.TabIndex = 0
      Me._thumbnailsTabPage.Text = "Pages"
      ' 
      ' _thumbnailsContextMenuStrip
      ' 
      Me._thumbnailsContextMenuStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
      Me._thumbnailsContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._thumbnailsGetThisPageTextToolStripMenuItem, Me._thumbnailsGetAllPagesTextToolStripMenuItem, Me._thumbnailsSep1ToolStripMenuItem, Me._thumbnailsRotateClockwiseToolStripMenuItem, Me._thumbnailsRotateCounterClockwiseToolStripMenuItem, Me._thumbnailsSep2ToolStripMenuItem, Me._thumbnailsEnableDisablePageToolStripMenuItem})
      Me._thumbnailsContextMenuStrip.Name = "_thumbnailsCcontextMenuStrip"
      Me._thumbnailsContextMenuStrip.Size = New System.Drawing.Size(280, 166)
      AddHandler Me._thumbnailsContextMenuStrip.Opening, AddressOf Me._thumbnailsContextMenuStrip_Opening
      ' 
      ' _thumbnailsGetThisPageTextToolStripMenuItem
      ' 
      Me._thumbnailsGetThisPageTextToolStripMenuItem.Name = "_thumbnailsGetThisPageTextToolStripMenuItem"
      Me._thumbnailsGetThisPageTextToolStripMenuItem.Size = New System.Drawing.Size(279, 30)
      Me._thumbnailsGetThisPageTextToolStripMenuItem.Text = "Get &text for this page"
      AddHandler Me._thumbnailsGetThisPageTextToolStripMenuItem.Click, AddressOf Me._thumbnailsGetThisPageTextToolStripMenuItem_Click
      ' 
      ' _thumbnailsGetAllPagesTextToolStripMenuItem
      ' 
      Me._thumbnailsGetAllPagesTextToolStripMenuItem.Name = "_thumbnailsGetAllPagesTextToolStripMenuItem"
      Me._thumbnailsGetAllPagesTextToolStripMenuItem.Size = New System.Drawing.Size(279, 30)
      Me._thumbnailsGetAllPagesTextToolStripMenuItem.Text = "Get text for &all pages"
      AddHandler Me._thumbnailsGetAllPagesTextToolStripMenuItem.Click, AddressOf Me._thumbnailsGetAllPagesTextToolStripMenuItem_Click
      ' 
      ' _thumbnailsSep1ToolStripMenuItem
      ' 
      Me._thumbnailsSep1ToolStripMenuItem.Name = "_thumbnailsSep1ToolStripMenuItem"
      Me._thumbnailsSep1ToolStripMenuItem.Size = New System.Drawing.Size(276, 6)
      ' 
      ' _thumbnailsRotateClockwiseToolStripMenuItem
      ' 
      Me._thumbnailsRotateClockwiseToolStripMenuItem.Name = "_thumbnailsRotateClockwiseToolStripMenuItem"
      Me._thumbnailsRotateClockwiseToolStripMenuItem.Size = New System.Drawing.Size(279, 30)
      Me._thumbnailsRotateClockwiseToolStripMenuItem.Text = "&Rotate clockwise"
      Me._thumbnailsRotateClockwiseToolStripMenuItem.ToolTipText = "Rotate this page by 90 degrees clockwise"
      AddHandler Me._thumbnailsRotateClockwiseToolStripMenuItem.Click, AddressOf Me._thumbnailsRotateClockwiseToolStripMenuItem_Click
      ' 
      ' _thumbnailsRotateCounterClockwiseToolStripMenuItem
      ' 
      Me._thumbnailsRotateCounterClockwiseToolStripMenuItem.Name = "_thumbnailsRotateCounterClockwiseToolStripMenuItem"
      Me._thumbnailsRotateCounterClockwiseToolStripMenuItem.Size = New System.Drawing.Size(279, 30)
      Me._thumbnailsRotateCounterClockwiseToolStripMenuItem.Text = "Rotate &counter clockwise"
      Me._thumbnailsRotateCounterClockwiseToolStripMenuItem.ToolTipText = "Rotate this page by 90 degrees counter-clockwise"
      AddHandler Me._thumbnailsRotateCounterClockwiseToolStripMenuItem.Click, AddressOf Me._thumbnailsRotateCounterClockwiseToolStripMenuItem_Click
      ' 
      ' _thumbnailsSep2ToolStripMenuItem
      ' 
      Me._thumbnailsSep2ToolStripMenuItem.Name = "_thumbnailsSep2ToolStripMenuItem"
      Me._thumbnailsSep2ToolStripMenuItem.Size = New System.Drawing.Size(276, 6)
      ' 
      ' _thumbnailsEnableDisablePageToolStripMenuItem
      ' 
      Me._thumbnailsEnableDisablePageToolStripMenuItem.Name = "_thumbnailsEnableDisablePageToolStripMenuItem"
      Me._thumbnailsEnableDisablePageToolStripMenuItem.Size = New System.Drawing.Size(279, 30)
      Me._thumbnailsEnableDisablePageToolStripMenuItem.Text = "Mark page as &disabled"
      Me._thumbnailsEnableDisablePageToolStripMenuItem.ToolTipText = "Mark this page as disabled in the document"
      AddHandler Me._thumbnailsEnableDisablePageToolStripMenuItem.Click, AddressOf Me._thumbnailsEnableDisablePageToolStripMenuItem_Click
      ' 
      ' _loadingThumbnailsProgressBar
      ' 
      Me._loadingThumbnailsProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom
      Me._loadingThumbnailsProgressBar.Location = New System.Drawing.Point(4, 671)
      Me._loadingThumbnailsProgressBar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._loadingThumbnailsProgressBar.MarqueeAnimationSpeed = 50
      Me._loadingThumbnailsProgressBar.Name = "_loadingThumbnailsProgressBar"
      Me._loadingThumbnailsProgressBar.Size = New System.Drawing.Size(284, 15)
      Me._loadingThumbnailsProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
      Me._loadingThumbnailsProgressBar.TabIndex = 1
      Me._loadingThumbnailsProgressBar.Visible = False
      ' 
      ' _bookmarksTabPage
      ' 
      Me._bookmarksTabPage.Controls.Add(Me._loadingBookmarksProgressBar)
      Me._bookmarksTabPage.Location = New System.Drawing.Point(4, 29)
      Me._bookmarksTabPage.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._bookmarksTabPage.Name = "_bookmarksTabPage"
      Me._bookmarksTabPage.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._bookmarksTabPage.Size = New System.Drawing.Size(292, 691)
      Me._bookmarksTabPage.TabIndex = 1
      Me._bookmarksTabPage.Text = "Bookmarks"
      Me._bookmarksTabPage.UseVisualStyleBackColor = True
      ' 
      ' _loadingBookmarksProgressBar
      ' 
      Me._loadingBookmarksProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom
      Me._loadingBookmarksProgressBar.Location = New System.Drawing.Point(4, 671)
      Me._loadingBookmarksProgressBar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._loadingBookmarksProgressBar.MarqueeAnimationSpeed = 50
      Me._loadingBookmarksProgressBar.Name = "_loadingBookmarksProgressBar"
      Me._loadingBookmarksProgressBar.Size = New System.Drawing.Size(284, 15)
      Me._loadingBookmarksProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
      Me._loadingBookmarksProgressBar.TabIndex = 2
      Me._loadingBookmarksProgressBar.Visible = False
      ' 
      ' _rightPanel
      ' 
      Me._rightPanel.Controls.Add(Me._loadingAnnotationsProgressBar)
      Me._rightPanel.Controls.Add(Me._annotationsControlPanel)
      Me._rightPanel.Dock = System.Windows.Forms.DockStyle.Right
      Me._rightPanel.Location = New System.Drawing.Point(1431, 68)
      Me._rightPanel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._rightPanel.Name = "_rightPanel"
      Me._rightPanel.Size = New System.Drawing.Size(300, 724)
      Me._rightPanel.TabIndex = 3
      ' 
      ' _loadingAnnotationsProgressBar
      ' 
      Me._loadingAnnotationsProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom
      Me._loadingAnnotationsProgressBar.Location = New System.Drawing.Point(0, 709)
      Me._loadingAnnotationsProgressBar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._loadingAnnotationsProgressBar.MarqueeAnimationSpeed = 50
      Me._loadingAnnotationsProgressBar.Name = "_loadingAnnotationsProgressBar"
      Me._loadingAnnotationsProgressBar.Size = New System.Drawing.Size(300, 15)
      Me._loadingAnnotationsProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
      Me._loadingAnnotationsProgressBar.TabIndex = 4
      Me._loadingAnnotationsProgressBar.Visible = False
      ' 
      ' _annotationsControlPanel
      ' 
      Me._annotationsControlPanel.Controls.Add(Me._annotationsObjectsPanel)
      Me._annotationsControlPanel.Controls.Add(Me._annotationsControlSplitter)
      Me._annotationsControlPanel.Controls.Add(Me._annotationsToolBarPanel)
      Me._annotationsControlPanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me._annotationsControlPanel.Location = New System.Drawing.Point(0, 0)
      Me._annotationsControlPanel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._annotationsControlPanel.Name = "_annotationsControlPanel"
      Me._annotationsControlPanel.Size = New System.Drawing.Size(300, 724)
      Me._annotationsControlPanel.TabIndex = 3
      ' 
      ' _annotationsObjectsPanel
      ' 
      Me._annotationsObjectsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._annotationsObjectsPanel.Controls.Add(Me._annotationsObjectsLabel)
      Me._annotationsObjectsPanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me._annotationsObjectsPanel.Location = New System.Drawing.Point(0, 356)
      Me._annotationsObjectsPanel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._annotationsObjectsPanel.Name = "_annotationsObjectsPanel"
      Me._annotationsObjectsPanel.Size = New System.Drawing.Size(300, 368)
      Me._annotationsObjectsPanel.TabIndex = 2
      ' 
      ' _annotationsObjectsLabel
      ' 
      Me._annotationsObjectsLabel.Dock = System.Windows.Forms.DockStyle.Top
      Me._annotationsObjectsLabel.Location = New System.Drawing.Point(0, 0)
      Me._annotationsObjectsLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._annotationsObjectsLabel.Name = "_annotationsObjectsLabel"
      Me._annotationsObjectsLabel.Size = New System.Drawing.Size(298, 20)
      Me._annotationsObjectsLabel.TabIndex = 0
      Me._annotationsObjectsLabel.Text = "Objects"
      Me._annotationsObjectsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
      ' 
      ' _annotationsControlSplitter
      ' 
      Me._annotationsControlSplitter.Dock = System.Windows.Forms.DockStyle.Top
      Me._annotationsControlSplitter.Location = New System.Drawing.Point(0, 350)
      Me._annotationsControlSplitter.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._annotationsControlSplitter.Name = "_annotationsControlSplitter"
      Me._annotationsControlSplitter.Size = New System.Drawing.Size(300, 6)
      Me._annotationsControlSplitter.TabIndex = 3
      Me._annotationsControlSplitter.TabStop = False
      ' 
      ' _annotationsToolBarPanel
      ' 
      Me._annotationsToolBarPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._annotationsToolBarPanel.Controls.Add(Me._annotationsShapeLabel)
      Me._annotationsToolBarPanel.Dock = System.Windows.Forms.DockStyle.Top
      Me._annotationsToolBarPanel.Location = New System.Drawing.Point(0, 0)
      Me._annotationsToolBarPanel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._annotationsToolBarPanel.Name = "_annotationsToolBarPanel"
      Me._annotationsToolBarPanel.Size = New System.Drawing.Size(300, 350)
      Me._annotationsToolBarPanel.TabIndex = 0
      ' 
      ' _annotationsShapeLabel
      ' 
      Me._annotationsShapeLabel.Dock = System.Windows.Forms.DockStyle.Top
      Me._annotationsShapeLabel.Location = New System.Drawing.Point(0, 0)
      Me._annotationsShapeLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._annotationsShapeLabel.Name = "_annotationsShapeLabel"
      Me._annotationsShapeLabel.Size = New System.Drawing.Size(298, 20)
      Me._annotationsShapeLabel.TabIndex = 1
      Me._annotationsShapeLabel.Text = "Shapes"
      Me._annotationsShapeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
      ' 
      ' _leftSplitter
      ' 
      Me._leftSplitter.Location = New System.Drawing.Point(300, 68)
      Me._leftSplitter.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._leftSplitter.Name = "_leftSplitter"
      Me._leftSplitter.Size = New System.Drawing.Size(6, 724)
      Me._leftSplitter.TabIndex = 4
      Me._leftSplitter.TabStop = False
      ' 
      ' _rightSplitter
      ' 
      Me._rightSplitter.Dock = System.Windows.Forms.DockStyle.Right
      Me._rightSplitter.Location = New System.Drawing.Point(1425, 68)
      Me._rightSplitter.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._rightSplitter.Name = "_rightSplitter"
      Me._rightSplitter.Size = New System.Drawing.Size(6, 724)
      Me._rightSplitter.TabIndex = 5
      Me._rightSplitter.TabStop = False
      ' 
      ' _centerPanel
      ' 
      Me._centerPanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me._centerPanel.Location = New System.Drawing.Point(306, 68)
      Me._centerPanel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._centerPanel.Name = "_centerPanel"
      Me._centerPanel.Size = New System.Drawing.Size(1119, 724)
      Me._centerPanel.TabIndex = 6
      ' 
      ' _bottomPanel
      ' 
      Me._bottomPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._bottomPanel.Controls.Add(Me._outputWindow)
      Me._bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom
      Me._bottomPanel.Location = New System.Drawing.Point(0, 792)
      Me._bottomPanel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._bottomPanel.Name = "_bottomPanel"
      Me._bottomPanel.Size = New System.Drawing.Size(1731, 139)
      Me._bottomPanel.TabIndex = 7
      ' 
      ' _outputWindow
      ' 
      Me._outputWindow.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me._outputWindow.Dock = System.Windows.Forms.DockStyle.Fill
      Me._outputWindow.Font = New System.Drawing.Font("Consolas", 8.0F)
      Me._outputWindow.Location = New System.Drawing.Point(0, 0)
      Me._outputWindow.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._outputWindow.Name = "_outputWindow"
      Me._outputWindow.ReadOnly = True
      Me._outputWindow.Size = New System.Drawing.Size(1729, 137)
      Me._outputWindow.TabIndex = 0
      Me._outputWindow.Text = ""
      ' 








      ' MainForm
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0F, 20.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1731, 931)
      Me.Controls.Add(Me._centerPanel)
      Me.Controls.Add(Me._rightSplitter)
      Me.Controls.Add(Me._leftSplitter)
      Me.Controls.Add(Me._rightPanel)
      Me.Controls.Add(Me._leftPanel)
      Me.Controls.Add(Me._mainToolStrip)
      Me.Controls.Add(Me._mainMenuStrip)
      Me.Controls.Add(Me._bottomPanel)
      Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
      Me.MainMenuStrip = Me._mainMenuStrip
      Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me.Name = "MainForm"
      Me.Text = "MainForm"
      Me._mainMenuStrip.ResumeLayout(False)
      Me._mainMenuStrip.PerformLayout()
      Me._mainToolStrip.ResumeLayout(False)
      Me._mainToolStrip.PerformLayout()
      Me._leftPanel.ResumeLayout(False)
      Me._leftTabControl.ResumeLayout(False)
      Me._thumbnailsTabPage.ResumeLayout(False)
      Me._thumbnailsContextMenuStrip.ResumeLayout(False)
      Me._bookmarksTabPage.ResumeLayout(False)
      Me._rightPanel.ResumeLayout(False)
      Me._annotationsControlPanel.ResumeLayout(False)
      Me._annotationsObjectsPanel.ResumeLayout(False)
      Me._annotationsToolBarPanel.ResumeLayout(False)
      Me._bottomPanel.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _mainMenuStrip As System.Windows.Forms.MenuStrip
   Private _fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _mainToolStrip As System.Windows.Forms.ToolStrip
   Private _leftPanel As System.Windows.Forms.Panel
   Private _rightPanel As System.Windows.Forms.Panel
   Private _leftSplitter As System.Windows.Forms.Splitter
   Private _rightSplitter As System.Windows.Forms.Splitter
   Private _centerPanel As System.Windows.Forms.Panel
   Private WithEvents _openDocumentFromFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _fileSep2ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _openDocumentFromFileToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _closeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _openDocumentFromUrltoolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _openDocumentFromUrlToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _exportTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _propertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _editToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _copyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _editSep2ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _selectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _clearSelectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _editSep3ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _findToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _findNextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _findPreviousToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _viewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _rotateVieweToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _clockwiseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _counterClockwiseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _viewSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
   Private _zoomOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _zoomInToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _viewSep2ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
   Private _fitWidthToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _fitPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _viewSep3ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _thumbnailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _bookmarksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _viewSep4ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _pageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _firstPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _previousPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _nextPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _lastPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _gotoPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _pageSep1ToolStripSeparator As System.Windows.Forms.ToolStripSeparator
   Private _displayPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _singlePageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _doublePageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _horizontalPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _verticalPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _bottomPanel As System.Windows.Forms.Panel
   Private _outputWindow As OutputWindow
   Private WithEvents _preferencesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _showOperationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _actualSizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _interactiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _panZoomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _panToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _zoomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _zoomToToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _magnifyGlassToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _selectTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _asSvgToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _asImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _mainToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Private _previousPageToolStripButton As System.Windows.Forms.ToolStripButton
   Private _nextPageToolStripButton As System.Windows.Forms.ToolStripButton
   Private _pageNumberToolStripTextBox As System.Windows.Forms.ToolStripTextBox
   Private _pageNumberToolStripLabel As System.Windows.Forms.ToolStripLabel
   Private _mainToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Private _zoomInToolStripButton As System.Windows.Forms.ToolStripButton
   Private _zoomOutToolStripButton As System.Windows.Forms.ToolStripButton
   Private _zoomToolStripComboBox As System.Windows.Forms.ToolStripComboBox
   Private _fitPageToolStripButton As System.Windows.Forms.ToolStripButton
   Private _fitWidthToolStripButton As System.Windows.Forms.ToolStripButton
   Private _actualSizeToolStripButton As System.Windows.Forms.ToolStripButton
   Private _leftTabControl As System.Windows.Forms.TabControl
   Private _thumbnailsTabPage As System.Windows.Forms.TabPage
   Private _bookmarksTabPage As System.Windows.Forms.TabPage
   Private _loadingThumbnailsProgressBar As System.Windows.Forms.ProgressBar
   Private WithEvents _diagnosticsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _annotationsToolBarPanel As System.Windows.Forms.Panel
   Private _annotationsObjectsPanel As System.Windows.Forms.Panel
   Private WithEvents _annotationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _userModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _userModeRunToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _userModeDesignToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _annotationsSep1ToolStripSeparator As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _currentObjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _annotationsSep2ToolStripSeparator As System.Windows.Forms.ToolStripSeparator
   Private _alignToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _alignBringToFrontToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _alignSendToBackToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _alignBringToFirstToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _alignSendToLastToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _flipToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _flipHorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _flipVerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _groupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _groupSelectedObjectsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _groupUngroupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _securityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _securityLockToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _securityUnlockToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _resetRotatePointsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _antiAliasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _annotationsPropertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _annotationsSep3ToolStripSeparator As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _behaviorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _behaviorUseRotateThumbsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _annotationsSep4ToolStripSeparator As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _redactionOptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _behaviorEnableToolTipToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _undoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _redoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _editSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
   Private _cutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _pasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _deleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _selectAllAnnotationsToolStripMenuItemtoolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _userNameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _behaviorRenderOnThumbnailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _interactiveSep1ToolStripSeparator As System.Windows.Forms.ToolStripSeparator
   Private _autoPanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _userModeRenderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _annotationsControlPanel As System.Windows.Forms.Panel
   Private _annotationsControlSplitter As System.Windows.Forms.Splitter
   Private _loadingAnnotationsProgressBar As System.Windows.Forms.ProgressBar
   Private WithEvents _getCurrentPageTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _getAllPagesTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _pageSep4ToolStripSeparator As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _thumbnailsContextMenuStrip As System.Windows.Forms.ContextMenuStrip
   Private WithEvents _thumbnailsGetThisPageTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _thumbnailsGetAllPagesTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _showTextIndicatorsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _userModeSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _customizeRenderModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _annotationsObjectsLabel As System.Windows.Forms.Label
   Private _annotationsShapeLabel As System.Windows.Forms.Label
   Private _mainToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Private _singlePageToolStripButton As System.Windows.Forms.ToolStripButton
   Private _verticalPageToolStripButton As System.Windows.Forms.ToolStripButton
   Private _doublePageToolStripButton As System.Windows.Forms.ToolStripButton
   Private _horizontalPageToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _saveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _fileSep3ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _cacheDirectoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _printToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _fileSep4ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _printSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _autoGetTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _documentTextOptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _mainToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Private _selectTextToolStripButton As System.Windows.Forms.ToolStripButton
   Private _panZoomToolStripButton As System.Windows.Forms.ToolStripButton
   Private _panToolStripButton As System.Windows.Forms.ToolStripButton
   Private _zoomToolStripButton As System.Windows.Forms.ToolStripButton
   Private _zoomToToolStripButton As System.Windows.Forms.ToolStripButton
   Private _magnifyGlassToolStripButton As System.Windows.Forms.ToolStripButton
   Private WithEvents _inertiaScrollToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _loadingBookmarksProgressBar As System.Windows.Forms.ProgressBar
   Private WithEvents _documentViewerOptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _behaviorDeselectOnDownToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _behaviorRestrictDesignersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _behaviorRubberbandSelectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _openFromCacheToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _saveToCacheToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _fileSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
   Private _thumbnailsSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _thumbnailsRotateClockwiseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _pageSep2ToolStripSeparator As System.Windows.Forms.ToolStripSeparator
   Private _rotatePageClockwiseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _rotatePageCounterClockwiseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _thumbnailsRotateCounterClockwiseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _rotatePagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _pageSep3ToolStripSeparator As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _enableDisablePageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _thumbnailsSep2ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _thumbnailsEnableDisablePageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
