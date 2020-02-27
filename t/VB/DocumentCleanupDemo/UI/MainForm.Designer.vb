Imports Microsoft.VisualBasic
Imports System
Namespace DocumentCleanupDemo
	Public Partial Class MainForm
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
         Me._mainMenu = New System.Windows.Forms.MenuStrip()
         Me._menuItemFile = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemFileOpen = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemFileSave = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemFileOpenRaw = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemFileSaveRaw = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemFileTwainSelectSource = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemFileTwainAcquire = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemFileWiaSelectSource = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemFileWiaAcquire = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemFileExit = New System.Windows.Forms.ToolStripMenuItem()
         Me.editToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEditCopy = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEditPaste = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemEditRegion = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEditRegionRectangle = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEditRegionEllipse = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEditRegionFreehand = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemEditCancelRegion = New System.Windows.Forms.ToolStripMenuItem()
         Me.vToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewSizeMode = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewSizeModeNormal = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewSizeModeStretch = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewSizeModeFitAlways = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewSizeModeFitWidth = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewSizeModeFit = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemViewSizeModeSnap = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewAlignMode = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewAlignModeHorizontal = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewAlignModeHorizontalNear = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewAlignModeHorizontalCenter = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewAlignModeHorizontalFar = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewAlignModeVertical = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewAlignModeVerticalNear = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewAlignModeVerticalCenter = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewAlignModeVerticalFar = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewZoom = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewZoomIn = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewZoomOut = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemViewZoomNormal = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemViewZoomValue = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemMagGlass = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemMagGlassStart = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemMagGlassStop = New System.Windows.Forms.ToolStripMenuItem()
         Me.imageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemHistogram = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemImageRotateRight90 = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemImageRotateLeft90 = New System.Windows.Forms.ToolStripMenuItem()
         Me.rotate180DegreesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemImageRotateAnyAngle = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemImageflipHorizontal = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemImagflipVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemImageColorResolution = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemImagefillImage = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemResize = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemDocument = New System.Windows.Forms.ToolStripMenuItem()
         Me.characterSmoothToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemCleanupLineRemove = New System.Windows.Forms.ToolStripMenuItem()
         Me.borderRemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.dotRemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemCleanupHolePunchRemove = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemCleanupInvertedText = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemCleanupDeskew = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemCleanupDespeckle = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemCleanupInverte = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemCleanupfillWhite = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemCleanupfillBlack = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemCleanupDilate = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemCleanupErode = New System.Windows.Forms.ToolStripMenuItem()
         Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
         Me.ProgressBar = New System.Windows.Forms.ToolStripProgressBar()
         Me._mainMenu.SuspendLayout()
         Me.statusStrip1.SuspendLayout()
         Me.SuspendLayout()
         '
         '_mainMenu
         '
         Me._mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemFile, Me.editToolStripMenuItem, Me.vToolStripMenuItem, Me.imageToolStripMenuItem, Me._menuItemDocument, Me.helpToolStripMenuItem})
         Me._mainMenu.Location = New System.Drawing.Point(0, 0)
         Me._mainMenu.Name = "_mainMenu"
         Me._mainMenu.Size = New System.Drawing.Size(578, 24)
         Me._mainMenu.TabIndex = 1
         Me._mainMenu.Text = "menuStrip1"
         '
         '_menuItemFile
         '
         Me._menuItemFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemFileOpen, Me._menuItemFileSave, Me.toolStripSeparator1, Me._menuItemFileOpenRaw, Me._menuItemFileSaveRaw, Me.toolStripSeparator13, Me._menuItemFileTwainSelectSource, Me._menuItemFileTwainAcquire, Me.toolStripSeparator2, Me._menuItemFileWiaSelectSource, Me._menuItemFileWiaAcquire, Me.toolStripSeparator3, Me._menuItemFileExit})
         Me._menuItemFile.Name = "_menuItemFile"
         Me._menuItemFile.Size = New System.Drawing.Size(37, 20)
         Me._menuItemFile.Text = "&File"
         '
         '_menuItemFileOpen
         '
         Me._menuItemFileOpen.Name = "_menuItemFileOpen"
         Me._menuItemFileOpen.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
         Me._menuItemFileOpen.Size = New System.Drawing.Size(194, 22)
         Me._menuItemFileOpen.Text = "&Open..."
         '
         '_menuItemFileSave
         '
         Me._menuItemFileSave.Enabled = False
         Me._menuItemFileSave.Name = "_menuItemFileSave"
         Me._menuItemFileSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
         Me._menuItemFileSave.Size = New System.Drawing.Size(194, 22)
         Me._menuItemFileSave.Text = "&Save As..."
         '
         'toolStripSeparator1
         '
         Me.toolStripSeparator1.Name = "toolStripSeparator1"
         Me.toolStripSeparator1.Size = New System.Drawing.Size(191, 6)
         '
         '_menuItemFileOpenRaw
         '
         Me._menuItemFileOpenRaw.Name = "_menuItemFileOpenRaw"
         Me._menuItemFileOpenRaw.Size = New System.Drawing.Size(194, 22)
         Me._menuItemFileOpenRaw.Text = "Open &Raw..."
         '
         '_menuItemFileSaveRaw
         '
         Me._menuItemFileSaveRaw.Enabled = False
         Me._menuItemFileSaveRaw.Name = "_menuItemFileSaveRaw"
         Me._menuItemFileSaveRaw.Size = New System.Drawing.Size(194, 22)
         Me._menuItemFileSaveRaw.Text = "Save Ra&w..."
         '
         'toolStripSeparator13
         '
         Me.toolStripSeparator13.Name = "toolStripSeparator13"
         Me.toolStripSeparator13.Size = New System.Drawing.Size(191, 6)
         '
         '_menuItemFileTwainSelectSource
         '
         Me._menuItemFileTwainSelectSource.Name = "_menuItemFileTwainSelectSource"
         Me._menuItemFileTwainSelectSource.Size = New System.Drawing.Size(194, 22)
         Me._menuItemFileTwainSelectSource.Text = "TWAIN Se&lect Source..."
         '
         '_menuItemFileTwainAcquire
         '
         Me._menuItemFileTwainAcquire.Name = "_menuItemFileTwainAcquire"
         Me._menuItemFileTwainAcquire.Size = New System.Drawing.Size(194, 22)
         Me._menuItemFileTwainAcquire.Text = "TWAIN Ac&quire..."
         '
         'toolStripSeparator2
         '
         Me.toolStripSeparator2.Name = "toolStripSeparator2"
         Me.toolStripSeparator2.Size = New System.Drawing.Size(191, 6)
         '
         '_menuItemFileWiaSelectSource
         '
         Me._menuItemFileWiaSelectSource.Name = "_menuItemFileWiaSelectSource"
         Me._menuItemFileWiaSelectSource.Size = New System.Drawing.Size(194, 22)
         Me._menuItemFileWiaSelectSource.Text = "WIA Select &Source..."
         '
         '_menuItemFileWiaAcquire
         '
         Me._menuItemFileWiaAcquire.Name = "_menuItemFileWiaAcquire"
         Me._menuItemFileWiaAcquire.Size = New System.Drawing.Size(194, 22)
         Me._menuItemFileWiaAcquire.Text = "WIA Acq&uire..."
         '
         'toolStripSeparator3
         '
         Me.toolStripSeparator3.Name = "toolStripSeparator3"
         Me.toolStripSeparator3.Size = New System.Drawing.Size(191, 6)
         '
         '_menuItemFileExit
         '
         Me._menuItemFileExit.Name = "_menuItemFileExit"
         Me._menuItemFileExit.Size = New System.Drawing.Size(194, 22)
         Me._menuItemFileExit.Text = "E&xit"
         '
         'editToolStripMenuItem
         '
         Me.editToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemEditCopy, Me._menuItemEditPaste, Me.toolStripSeparator8, Me._menuItemEditRegion, Me.toolStripSeparator9, Me._menuItemEditCancelRegion})
         Me.editToolStripMenuItem.Name = "editToolStripMenuItem"
         Me.editToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
         Me.editToolStripMenuItem.Text = "&Edit"
         '
         '_menuItemEditCopy
         '
         Me._menuItemEditCopy.Enabled = False
         Me._menuItemEditCopy.Name = "_menuItemEditCopy"
         Me._menuItemEditCopy.Size = New System.Drawing.Size(150, 22)
         Me._menuItemEditCopy.Text = "&Copy"
         '
         '_menuItemEditPaste
         '
         Me._menuItemEditPaste.Enabled = False
         Me._menuItemEditPaste.Name = "_menuItemEditPaste"
         Me._menuItemEditPaste.Size = New System.Drawing.Size(150, 22)
         Me._menuItemEditPaste.Text = "&Paste"
         '
         'toolStripSeparator8
         '
         Me.toolStripSeparator8.Name = "toolStripSeparator8"
         Me.toolStripSeparator8.Size = New System.Drawing.Size(147, 6)
         '
         '_menuItemEditRegion
         '
         Me._menuItemEditRegion.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemEditRegionRectangle, Me._menuItemEditRegionEllipse, Me._menuItemEditRegionFreehand})
         Me._menuItemEditRegion.Enabled = False
         Me._menuItemEditRegion.Name = "_menuItemEditRegion"
         Me._menuItemEditRegion.Size = New System.Drawing.Size(150, 22)
         Me._menuItemEditRegion.Text = "&Region"
         '
         '_menuItemEditRegionRectangle
         '
         Me._menuItemEditRegionRectangle.Name = "_menuItemEditRegionRectangle"
         Me._menuItemEditRegionRectangle.Size = New System.Drawing.Size(126, 22)
         Me._menuItemEditRegionRectangle.Text = "&Rectangle"
         '
         '_menuItemEditRegionEllipse
         '
         Me._menuItemEditRegionEllipse.Name = "_menuItemEditRegionEllipse"
         Me._menuItemEditRegionEllipse.Size = New System.Drawing.Size(126, 22)
         Me._menuItemEditRegionEllipse.Text = "&Ellipse"
         '
         '_menuItemEditRegionFreehand
         '
         Me._menuItemEditRegionFreehand.Name = "_menuItemEditRegionFreehand"
         Me._menuItemEditRegionFreehand.Size = New System.Drawing.Size(126, 22)
         Me._menuItemEditRegionFreehand.Text = "&Freehand"
         '
         'toolStripSeparator9
         '
         Me.toolStripSeparator9.Name = "toolStripSeparator9"
         Me.toolStripSeparator9.Size = New System.Drawing.Size(147, 6)
         '
         '_menuItemEditCancelRegion
         '
         Me._menuItemEditCancelRegion.Enabled = False
         Me._menuItemEditCancelRegion.Name = "_menuItemEditCancelRegion"
         Me._menuItemEditCancelRegion.Size = New System.Drawing.Size(150, 22)
         Me._menuItemEditCancelRegion.Text = "Cance&l Region"
         '
         'vToolStripMenuItem
         '
         Me.vToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemViewSizeMode, Me._menuItemViewAlignMode, Me._menuItemViewZoom, Me._menuItemMagGlass})
         Me.vToolStripMenuItem.Enabled = False
         Me.vToolStripMenuItem.Name = "vToolStripMenuItem"
         Me.vToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
         Me.vToolStripMenuItem.Text = "&View"
         '
         '_menuItemViewSizeMode
         '
         Me._menuItemViewSizeMode.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemViewSizeModeNormal, Me._menuItemViewSizeModeStretch, Me._menuItemViewSizeModeFitAlways, Me._menuItemViewSizeModeFitWidth, Me._menuItemViewSizeModeFit, Me.toolStripSeparator10, Me._menuItemViewSizeModeSnap})
         Me._menuItemViewSizeMode.Name = "_menuItemViewSizeMode"
         Me._menuItemViewSizeMode.Size = New System.Drawing.Size(148, 22)
         Me._menuItemViewSizeMode.Text = "&Size Mode"
         '
         '_menuItemViewSizeModeNormal
         '
         Me._menuItemViewSizeModeNormal.Name = "_menuItemViewSizeModeNormal"
         Me._menuItemViewSizeModeNormal.Size = New System.Drawing.Size(127, 22)
         Me._menuItemViewSizeModeNormal.Text = "&Normal"
         '
         '_menuItemViewSizeModeStretch
         '
         Me._menuItemViewSizeModeStretch.Name = "_menuItemViewSizeModeStretch"
         Me._menuItemViewSizeModeStretch.Size = New System.Drawing.Size(127, 22)
         Me._menuItemViewSizeModeStretch.Text = "&Stretch"
         '
         '_menuItemViewSizeModeFitAlways
         '
         Me._menuItemViewSizeModeFitAlways.Name = "_menuItemViewSizeModeFitAlways"
         Me._menuItemViewSizeModeFitAlways.Size = New System.Drawing.Size(127, 22)
         Me._menuItemViewSizeModeFitAlways.Text = "Fit &Always"
         '
         '_menuItemViewSizeModeFitWidth
         '
         Me._menuItemViewSizeModeFitWidth.Name = "_menuItemViewSizeModeFitWidth"
         Me._menuItemViewSizeModeFitWidth.Size = New System.Drawing.Size(127, 22)
         Me._menuItemViewSizeModeFitWidth.Text = "Fit &Width"
         '
         '_menuItemViewSizeModeFit
         '
         Me._menuItemViewSizeModeFit.Name = "_menuItemViewSizeModeFit"
         Me._menuItemViewSizeModeFit.Size = New System.Drawing.Size(127, 22)
         Me._menuItemViewSizeModeFit.Text = "&Fit"
         '
         'toolStripSeparator10
         '
         Me.toolStripSeparator10.Name = "toolStripSeparator10"
         Me.toolStripSeparator10.Size = New System.Drawing.Size(124, 6)
         '
         '_menuItemViewSizeModeSnap
         '
         Me._menuItemViewSizeModeSnap.Name = "_menuItemViewSizeModeSnap"
         Me._menuItemViewSizeModeSnap.Size = New System.Drawing.Size(127, 22)
         Me._menuItemViewSizeModeSnap.Text = "&Snap"
         '
         '_menuItemViewAlignMode
         '
         Me._menuItemViewAlignMode.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemViewAlignModeHorizontal, Me._menuItemViewAlignModeVertical})
         Me._menuItemViewAlignMode.Name = "_menuItemViewAlignMode"
         Me._menuItemViewAlignMode.Size = New System.Drawing.Size(148, 22)
         Me._menuItemViewAlignMode.Text = "&Align Mode"
         '
         '_menuItemViewAlignModeHorizontal
         '
         Me._menuItemViewAlignModeHorizontal.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemViewAlignModeHorizontalNear, Me._menuItemViewAlignModeHorizontalCenter, Me._menuItemViewAlignModeHorizontalFar})
         Me._menuItemViewAlignModeHorizontal.Name = "_menuItemViewAlignModeHorizontal"
         Me._menuItemViewAlignModeHorizontal.Size = New System.Drawing.Size(129, 22)
         Me._menuItemViewAlignModeHorizontal.Text = "&Horizontal"
         '
         '_menuItemViewAlignModeHorizontalNear
         '
         Me._menuItemViewAlignModeHorizontalNear.Name = "_menuItemViewAlignModeHorizontalNear"
         Me._menuItemViewAlignModeHorizontalNear.Size = New System.Drawing.Size(109, 22)
         Me._menuItemViewAlignModeHorizontalNear.Text = "&Near"
         '
         '_menuItemViewAlignModeHorizontalCenter
         '
         Me._menuItemViewAlignModeHorizontalCenter.Name = "_menuItemViewAlignModeHorizontalCenter"
         Me._menuItemViewAlignModeHorizontalCenter.Size = New System.Drawing.Size(109, 22)
         Me._menuItemViewAlignModeHorizontalCenter.Text = "&Center"
         '
         '_menuItemViewAlignModeHorizontalFar
         '
         Me._menuItemViewAlignModeHorizontalFar.Name = "_menuItemViewAlignModeHorizontalFar"
         Me._menuItemViewAlignModeHorizontalFar.Size = New System.Drawing.Size(109, 22)
         Me._menuItemViewAlignModeHorizontalFar.Text = "&Far"
         '
         '_menuItemViewAlignModeVertical
         '
         Me._menuItemViewAlignModeVertical.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemViewAlignModeVerticalNear, Me._menuItemViewAlignModeVerticalCenter, Me._menuItemViewAlignModeVerticalFar})
         Me._menuItemViewAlignModeVertical.Name = "_menuItemViewAlignModeVertical"
         Me._menuItemViewAlignModeVertical.Size = New System.Drawing.Size(129, 22)
         Me._menuItemViewAlignModeVertical.Text = "&Vertical"
         '
         '_menuItemViewAlignModeVerticalNear
         '
         Me._menuItemViewAlignModeVerticalNear.Name = "_menuItemViewAlignModeVerticalNear"
         Me._menuItemViewAlignModeVerticalNear.Size = New System.Drawing.Size(109, 22)
         Me._menuItemViewAlignModeVerticalNear.Text = "&Near"
         '
         '_menuItemViewAlignModeVerticalCenter
         '
         Me._menuItemViewAlignModeVerticalCenter.Name = "_menuItemViewAlignModeVerticalCenter"
         Me._menuItemViewAlignModeVerticalCenter.Size = New System.Drawing.Size(109, 22)
         Me._menuItemViewAlignModeVerticalCenter.Text = "&Center"
         '
         '_menuItemViewAlignModeVerticalFar
         '
         Me._menuItemViewAlignModeVerticalFar.Name = "_menuItemViewAlignModeVerticalFar"
         Me._menuItemViewAlignModeVerticalFar.Size = New System.Drawing.Size(109, 22)
         Me._menuItemViewAlignModeVerticalFar.Text = "&Far"
         '
         '_menuItemViewZoom
         '
         Me._menuItemViewZoom.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemViewZoomIn, Me._menuItemViewZoomOut, Me.toolStripSeparator11, Me._menuItemViewZoomNormal, Me._menuItemViewZoomValue})
         Me._menuItemViewZoom.Name = "_menuItemViewZoom"
         Me._menuItemViewZoom.Size = New System.Drawing.Size(148, 22)
         Me._menuItemViewZoom.Text = "&Zoom"
         '
         '_menuItemViewZoomIn
         '
         Me._menuItemViewZoomIn.Name = "_menuItemViewZoomIn"
         Me._menuItemViewZoomIn.Size = New System.Drawing.Size(153, 22)
         Me._menuItemViewZoomIn.Text = "&In"
         '
         '_menuItemViewZoomOut
         '
         Me._menuItemViewZoomOut.Name = "_menuItemViewZoomOut"
         Me._menuItemViewZoomOut.Size = New System.Drawing.Size(153, 22)
         Me._menuItemViewZoomOut.Text = "&Out"
         '
         'toolStripSeparator11
         '
         Me.toolStripSeparator11.Name = "toolStripSeparator11"
         Me.toolStripSeparator11.Size = New System.Drawing.Size(150, 6)
         '
         '_menuItemViewZoomNormal
         '
         Me._menuItemViewZoomNormal.Name = "_menuItemViewZoomNormal"
         Me._menuItemViewZoomNormal.Size = New System.Drawing.Size(153, 22)
         Me._menuItemViewZoomNormal.Text = "&Normal (100%)"
         '
         '_menuItemViewZoomValue
         '
         Me._menuItemViewZoomValue.Name = "_menuItemViewZoomValue"
         Me._menuItemViewZoomValue.Size = New System.Drawing.Size(153, 22)
         Me._menuItemViewZoomValue.Text = "&Value..."
         '
         '_menuItemMagGlass
         '
         Me._menuItemMagGlass.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemMagGlassStart, Me._menuItemMagGlassStop})
         Me._menuItemMagGlass.Name = "_menuItemMagGlass"
         Me._menuItemMagGlass.Size = New System.Drawing.Size(148, 22)
         Me._menuItemMagGlass.Text = "Magnify Glass"
         '
         '_menuItemMagGlassStart
         '
         Me._menuItemMagGlassStart.Name = "_menuItemMagGlassStart"
         Me._menuItemMagGlassStart.Size = New System.Drawing.Size(98, 22)
         Me._menuItemMagGlassStart.Text = "Start"
         '
         '_menuItemMagGlassStop
         '
         Me._menuItemMagGlassStop.Name = "_menuItemMagGlassStop"
         Me._menuItemMagGlassStop.Size = New System.Drawing.Size(98, 22)
         Me._menuItemMagGlassStop.Text = "Stop"
         '
         'imageToolStripMenuItem
         '
         Me.imageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemHistogram, Me._menuItemImageRotateRight90, Me._menuItemImageRotateLeft90, Me.rotate180DegreesToolStripMenuItem, Me._menuItemImageRotateAnyAngle, Me.toolStripSeparator6, Me._menuItemImageflipHorizontal, Me._menuItemImagflipVerticalToolStripMenuItem, Me.toolStripSeparator7, Me._menuItemImageColorResolution, Me._menuItemImagefillImage, Me.toolStripSeparator12, Me._menuItemResize})
         Me.imageToolStripMenuItem.Enabled = False
         Me.imageToolStripMenuItem.Name = "imageToolStripMenuItem"
         Me.imageToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
         Me.imageToolStripMenuItem.Text = "&Image"
         '
         '_menuItemHistogram
         '
         Me._menuItemHistogram.Name = "_menuItemHistogram"
         Me._menuItemHistogram.Size = New System.Drawing.Size(199, 22)
         Me._menuItemHistogram.Text = "Histogram"
         '
         '_menuItemImageRotateRight90
         '
         Me._menuItemImageRotateRight90.Name = "_menuItemImageRotateRight90"
         Me._menuItemImageRotateRight90.Size = New System.Drawing.Size(199, 22)
         Me._menuItemImageRotateRight90.Text = "Rotate Right 90 Degrees"
         '
         '_menuItemImageRotateLeft90
         '
         Me._menuItemImageRotateLeft90.Name = "_menuItemImageRotateLeft90"
         Me._menuItemImageRotateLeft90.Size = New System.Drawing.Size(199, 22)
         Me._menuItemImageRotateLeft90.Text = "Rotate left 90 Degrees"
         '
         'rotate180DegreesToolStripMenuItem
         '
         Me.rotate180DegreesToolStripMenuItem.Name = "rotate180DegreesToolStripMenuItem"
         Me.rotate180DegreesToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
         Me.rotate180DegreesToolStripMenuItem.Text = "Rotate 180 Degrees"
         '
         '_menuItemImageRotateAnyAngle
         '
         Me._menuItemImageRotateAnyAngle.Name = "_menuItemImageRotateAnyAngle"
         Me._menuItemImageRotateAnyAngle.Size = New System.Drawing.Size(199, 22)
         Me._menuItemImageRotateAnyAngle.Text = "Rotate Any Angle…"
         '
         'toolStripSeparator6
         '
         Me.toolStripSeparator6.Name = "toolStripSeparator6"
         Me.toolStripSeparator6.Size = New System.Drawing.Size(196, 6)
         '
         '_menuItemImageflipHorizontal
         '
         Me._menuItemImageflipHorizontal.Name = "_menuItemImageflipHorizontal"
         Me._menuItemImageflipHorizontal.Size = New System.Drawing.Size(199, 22)
         Me._menuItemImageflipHorizontal.Text = "Flip Horizontal"
         '
         '_menuItemImagflipVerticalToolStripMenuItem
         '
         Me._menuItemImagflipVerticalToolStripMenuItem.Name = "_menuItemImagflipVerticalToolStripMenuItem"
         Me._menuItemImagflipVerticalToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
         Me._menuItemImagflipVerticalToolStripMenuItem.Text = "Flip Vertical"
         '
         'toolStripSeparator7
         '
         Me.toolStripSeparator7.Name = "toolStripSeparator7"
         Me.toolStripSeparator7.Size = New System.Drawing.Size(196, 6)
         '
         '_menuItemImageColorResolution
         '
         Me._menuItemImageColorResolution.Name = "_menuItemImageColorResolution"
         Me._menuItemImageColorResolution.Size = New System.Drawing.Size(199, 22)
         Me._menuItemImageColorResolution.Text = "Color Resolution..."
         '
         '_menuItemImagefillImage
         '
         Me._menuItemImagefillImage.Name = "_menuItemImagefillImage"
         Me._menuItemImagefillImage.Size = New System.Drawing.Size(199, 22)
         Me._menuItemImagefillImage.Text = "Fill..."
         '
         'toolStripSeparator12
         '
         Me.toolStripSeparator12.Name = "toolStripSeparator12"
         Me.toolStripSeparator12.Size = New System.Drawing.Size(196, 6)
         '
         '_menuItemResize
         '
         Me._menuItemResize.Name = "_menuItemResize"
         Me._menuItemResize.Size = New System.Drawing.Size(199, 22)
         Me._menuItemResize.Text = "Resize..."
         '
         '_menuItemDocument
         '
         Me._menuItemDocument.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.characterSmoothToolStripMenuItem, Me._menuItemCleanupLineRemove, Me.borderRemoveToolStripMenuItem, Me.dotRemoveToolStripMenuItem, Me._menuItemCleanupHolePunchRemove, Me._menuItemCleanupInvertedText, Me._menuItemCleanupDeskew, Me._menuItemCleanupDespeckle, Me.toolStripSeparator4, Me._menuItemCleanupInverte, Me._menuItemCleanupfillWhite, Me._menuItemCleanupfillBlack, Me.toolStripSeparator5, Me._menuItemCleanupDilate, Me._menuItemCleanupErode})
         Me._menuItemDocument.Enabled = False
         Me._menuItemDocument.Name = "_menuItemDocument"
         Me._menuItemDocument.Size = New System.Drawing.Size(63, 20)
         Me._menuItemDocument.Text = "&Cleanup"
         '
         'characterSmoothToolStripMenuItem
         '
         Me.characterSmoothToolStripMenuItem.Name = "characterSmoothToolStripMenuItem"
         Me.characterSmoothToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
         Me.characterSmoothToolStripMenuItem.Text = "Character Smooth..."
         '
         '_menuItemCleanupLineRemove
         '
         Me._menuItemCleanupLineRemove.Name = "_menuItemCleanupLineRemove"
         Me._menuItemCleanupLineRemove.Size = New System.Drawing.Size(191, 22)
         Me._menuItemCleanupLineRemove.Text = "Line Remove ..."
         '
         'borderRemoveToolStripMenuItem
         '
         Me.borderRemoveToolStripMenuItem.Name = "borderRemoveToolStripMenuItem"
         Me.borderRemoveToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
         Me.borderRemoveToolStripMenuItem.Text = "Border Remove..."
         '
         'dotRemoveToolStripMenuItem
         '
         Me.dotRemoveToolStripMenuItem.Name = "dotRemoveToolStripMenuItem"
         Me.dotRemoveToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
         Me.dotRemoveToolStripMenuItem.Text = "Dot Remove..."
         '
         '_menuItemCleanupHolePunchRemove
         '
         Me._menuItemCleanupHolePunchRemove.Name = "_menuItemCleanupHolePunchRemove"
         Me._menuItemCleanupHolePunchRemove.Size = New System.Drawing.Size(191, 22)
         Me._menuItemCleanupHolePunchRemove.Text = "Hole Punch Remove..."
         '
         '_menuItemCleanupInvertedText
         '
         Me._menuItemCleanupInvertedText.Name = "_menuItemCleanupInvertedText"
         Me._menuItemCleanupInvertedText.Size = New System.Drawing.Size(191, 22)
         Me._menuItemCleanupInvertedText.Text = "Inverted Text..."
         '
         '_menuItemCleanupDeskew
         '
         Me._menuItemCleanupDeskew.Name = "_menuItemCleanupDeskew"
         Me._menuItemCleanupDeskew.Size = New System.Drawing.Size(191, 22)
         Me._menuItemCleanupDeskew.Text = "Deskew..."
         '
         '_menuItemCleanupDespeckle
         '
         Me._menuItemCleanupDespeckle.Name = "_menuItemCleanupDespeckle"
         Me._menuItemCleanupDespeckle.Size = New System.Drawing.Size(191, 22)
         Me._menuItemCleanupDespeckle.Text = "Despeckle"
         '
         'toolStripSeparator4
         '
         Me.toolStripSeparator4.Name = "toolStripSeparator4"
         Me.toolStripSeparator4.Size = New System.Drawing.Size(188, 6)
         '
         '_menuItemCleanupInverte
         '
         Me._menuItemCleanupInverte.Name = "_menuItemCleanupInverte"
         Me._menuItemCleanupInverte.Size = New System.Drawing.Size(191, 22)
         Me._menuItemCleanupInverte.Text = "Invert"
         '
         '_menuItemCleanupfillWhite
         '
         Me._menuItemCleanupfillWhite.Name = "_menuItemCleanupfillWhite"
         Me._menuItemCleanupfillWhite.Size = New System.Drawing.Size(191, 22)
         Me._menuItemCleanupfillWhite.Text = "Fill White"
         '
         '_menuItemCleanupfillBlack
         '
         Me._menuItemCleanupfillBlack.Name = "_menuItemCleanupfillBlack"
         Me._menuItemCleanupfillBlack.Size = New System.Drawing.Size(191, 22)
         Me._menuItemCleanupfillBlack.Text = "Fill Black"
         '
         'toolStripSeparator5
         '
         Me.toolStripSeparator5.Name = "toolStripSeparator5"
         Me.toolStripSeparator5.Size = New System.Drawing.Size(188, 6)
         '
         '_menuItemCleanupDilate
         '
         Me._menuItemCleanupDilate.Name = "_menuItemCleanupDilate"
         Me._menuItemCleanupDilate.Size = New System.Drawing.Size(191, 22)
         Me._menuItemCleanupDilate.Text = "Dilate"
         '
         '_menuItemCleanupErode
         '
         Me._menuItemCleanupErode.Name = "_menuItemCleanupErode"
         Me._menuItemCleanupErode.Size = New System.Drawing.Size(191, 22)
         Me._menuItemCleanupErode.Text = "Erode"
         '
         'helpToolStripMenuItem
         '
         Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.aboutToolStripMenuItem})
         Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
         Me.helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
         Me.helpToolStripMenuItem.Text = "&Help"
         '
         'aboutToolStripMenuItem
         '
         Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
         Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
         Me.aboutToolStripMenuItem.Text = "&About"
         '
         'statusStrip1
         '
         Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgressBar})
         Me.statusStrip1.Location = New System.Drawing.Point(0, 490)
         Me.statusStrip1.Name = "statusStrip1"
         Me.statusStrip1.Size = New System.Drawing.Size(578, 22)
         Me.statusStrip1.TabIndex = 3
         Me.statusStrip1.Text = "statusStrip1"
         '
         'ProgressBar
         '
         Me.ProgressBar.Name = "ProgressBar"
         Me.ProgressBar.Size = New System.Drawing.Size(300, 16)
         Me.ProgressBar.Visible = False
         '
         'MainForm
         '
         Me.AllowDrop = True
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(578, 512)
         Me.Controls.Add(Me.statusStrip1)
         Me.Controls.Add(Me._mainMenu)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.IsMdiContainer = True
         Me.MainMenuStrip = Me._mainMenu
         Me.Name = "MainForm"
         Me.Text = "MainForm"
         Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
         Me._mainMenu.ResumeLayout(False)
         Me._mainMenu.PerformLayout()
         Me.statusStrip1.ResumeLayout(False)
         Me.statusStrip1.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _mainMenu As System.Windows.Forms.MenuStrip
      Private _menuItemFile As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemFileOpen As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemFileSave As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
      Private _menuItemDocument As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemCleanupLineRemove As System.Windows.Forms.ToolStripMenuItem
      Private statusStrip1 As System.Windows.Forms.StatusStrip
      Private ProgressBar As System.Windows.Forms.ToolStripProgressBar
      Private WithEvents dotRemoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents borderRemoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents characterSmoothToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemFileTwainSelectSource As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemFileTwainAcquire As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemFileWiaSelectSource As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemFileWiaAcquire As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemFileExit As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemCleanupInvertedText As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemCleanupDeskew As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemCleanupDespeckle As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemCleanupInverte As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemCleanupfillWhite As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemCleanupfillBlack As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemCleanupDilate As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemCleanupErode As System.Windows.Forms.ToolStripMenuItem
      Private imageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemImageRotateRight90 As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemImageRotateLeft90 As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents rotate180DegreesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemImageRotateAnyAngle As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemImageflipHorizontal As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemImagflipVerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemResize As System.Windows.Forms.ToolStripMenuItem
      Private editToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEditCopy As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEditPaste As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
      Private _menuItemEditRegion As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEditRegionRectangle As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEditRegionEllipse As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEditRegionFreehand As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEditCancelRegion As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
      Private vToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _menuItemViewSizeMode As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewSizeModeNormal As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewSizeModeStretch As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewSizeModeFitAlways As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewSizeModeFitWidth As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewSizeModeFit As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemViewSizeModeSnap As System.Windows.Forms.ToolStripMenuItem
      Private _menuItemViewAlignMode As System.Windows.Forms.ToolStripMenuItem
      Private _menuItemViewAlignModeHorizontal As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewAlignModeHorizontalNear As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewAlignModeHorizontalCenter As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewAlignModeHorizontalFar As System.Windows.Forms.ToolStripMenuItem
      Private _menuItemViewAlignModeVertical As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewAlignModeVerticalNear As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewAlignModeVerticalCenter As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewAlignModeVerticalFar As System.Windows.Forms.ToolStripMenuItem
      Private _menuItemViewZoom As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewZoomIn As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewZoomOut As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemViewZoomNormal As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemViewZoomValue As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemImageColorResolution As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
      Private helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemFileOpenRaw As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemFileSaveRaw As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemCleanupHolePunchRemove As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemImagefillImage As System.Windows.Forms.ToolStripMenuItem
      Friend WithEvents _menuItemMagGlass As System.Windows.Forms.ToolStripMenuItem
      Friend WithEvents _menuItemMagGlassStart As System.Windows.Forms.ToolStripMenuItem
      Friend WithEvents _menuItemMagGlassStop As System.Windows.Forms.ToolStripMenuItem
      Friend WithEvents _menuItemHistogram As System.Windows.Forms.ToolStripMenuItem
	End Class
End Namespace

