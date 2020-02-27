Imports Microsoft.VisualBasic
Imports System
Namespace MedicalViewerLayoutDemo
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
            Me._mainMenu = New System.Windows.Forms.MenuStrip
            Me._fileMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.insertImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.toolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator
            Me._printCellMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator
            Me.saveLayoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.loadLayoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.sToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator
            Me._fileMenuItem_exit = New System.Windows.Forms.ToolStripMenuItem
            Me._editMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me._miEditFreezeCell = New System.Windows.Forms.ToolStripMenuItem
            Me._miEditToggleFreeze = New System.Windows.Forms.ToolStripMenuItem
            Me.sToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
            Me._miEditSelectAll = New System.Windows.Forms.ToolStripMenuItem
            Me._miEditInvertSelection = New System.Windows.Forms.ToolStripMenuItem
            Me._miEditDeselectAll = New System.Windows.Forms.ToolStripMenuItem
            Me.sToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
            Me._miEditRemoveCell = New System.Windows.Forms.ToolStripMenuItem
            Me._miEditRemoveSelectedCells = New System.Windows.Forms.ToolStripMenuItem
            Me.sToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator
            Me._miEditAnimation = New System.Windows.Forms.ToolStripMenuItem
            Me.layoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.designToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.toolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.selectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.drawToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
            Me.allowCellsToOverlappToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.showLocationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.gridToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.showToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.snapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.showLinesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.sizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.x6ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.x8ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.x10ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
            Me.bW2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.bW4ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.fMX18ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.fMX20ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator
            Me.overlapPriorityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me._propertiesMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me._miPropertiesViewerProperties = New System.Windows.Forms.ToolStripMenuItem
            Me._miPropertiesCellProperties = New System.Windows.Forms.ToolStripMenuItem
            Me._actionsMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me._miActionWindowLevel = New System.Windows.Forms.ToolStripMenuItem
            Me._miActionWindowLevelSet = New System.Windows.Forms.ToolStripMenuItem
            Me._miActionWindowLevelCustomize = New System.Windows.Forms.ToolStripMenuItem
            Me._miActionAlpha = New System.Windows.Forms.ToolStripMenuItem
            Me._miActionAlphaSet = New System.Windows.Forms.ToolStripMenuItem
            Me._miActionAlphaCustomizeAlpha = New System.Windows.Forms.ToolStripMenuItem
            Me._miActionScale = New System.Windows.Forms.ToolStripMenuItem
            Me._miActionScaleSet = New System.Windows.Forms.ToolStripMenuItem
            Me._miActionScaleCustomizeScale = New System.Windows.Forms.ToolStripMenuItem
            Me._miActionMagnify = New System.Windows.Forms.ToolStripMenuItem
            Me._miMagnifySet = New System.Windows.Forms.ToolStripMenuItem
            Me._miActionMagnifyCustomizeMagnify = New System.Windows.Forms.ToolStripMenuItem
            Me._miActionStack = New System.Windows.Forms.ToolStripMenuItem
            Me._miActionStackSet = New System.Windows.Forms.ToolStripMenuItem
            Me._miActionStackCustomizeStack = New System.Windows.Forms.ToolStripMenuItem
            Me._miActionOffset = New System.Windows.Forms.ToolStripMenuItem
            Me._miActionOffsetSet = New System.Windows.Forms.ToolStripMenuItem
            Me._miActionOffsetCustomizeOffset = New System.Windows.Forms.ToolStripMenuItem
            Me._helpMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me._miHelpAbout = New System.Windows.Forms.ToolStripMenuItem
            Me._mainPanel = New System.Windows.Forms.Panel
            Me.toolStrip1 = New System.Windows.Forms.ToolStrip
            Me.toolStripButtonUserMode = New System.Windows.Forms.ToolStripButton
            Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
            Me.toolStripButtonSelect = New System.Windows.Forms.ToolStripButton
            Me.toolStripButtonDraw = New System.Windows.Forms.ToolStripButton
            Me.toolStripButtonOverlap = New System.Windows.Forms.ToolStripButton
            Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
            Me.toolStripButtonShowPosition = New System.Windows.Forms.ToolStripButton
            Me.toolStripButton1 = New System.Windows.Forms.ToolStripButton
            Me._mainMenu.SuspendLayout()
            Me.toolStrip1.SuspendLayout()
            Me.SuspendLayout()
            '
            '_mainMenu
            '
            Me._mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._fileMenuItem, Me._editMenuItem, Me.layoutToolStripMenuItem, Me._propertiesMenuItem, Me._actionsMenuItem, Me._helpMenuItem})
            Me._mainMenu.Location = New System.Drawing.Point(0, 0)
            Me._mainMenu.Name = "_mainMenu"
            Me._mainMenu.Size = New System.Drawing.Size(640, 24)
            Me._mainMenu.TabIndex = 1
            Me._mainMenu.Text = "_mainMenu"
            '
            '_fileMenuItem
            '
            Me._fileMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.insertImageToolStripMenuItem, Me.toolStripMenuItem5, Me._printCellMenuItem, Me.toolStripMenuItem3, Me.saveLayoutToolStripMenuItem, Me.loadLayoutToolStripMenuItem, Me.sToolStripMenuItem, Me._fileMenuItem_exit})
            Me._fileMenuItem.Name = "_fileMenuItem"
            Me._fileMenuItem.Size = New System.Drawing.Size(37, 20)
            Me._fileMenuItem.Text = "&File"
            '
            'insertImageToolStripMenuItem
            '
            Me.insertImageToolStripMenuItem.Name = "insertImageToolStripMenuItem"
            Me.insertImageToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
            Me.insertImageToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
            Me.insertImageToolStripMenuItem.Text = "Insert Image..."
            '
            'toolStripMenuItem5
            '
            Me.toolStripMenuItem5.Name = "toolStripMenuItem5"
            Me.toolStripMenuItem5.Size = New System.Drawing.Size(185, 6)
            '
            '_printCellMenuItem
            '
            Me._printCellMenuItem.Name = "_printCellMenuItem"
            Me._printCellMenuItem.Size = New System.Drawing.Size(188, 22)
            Me._printCellMenuItem.Text = "&Print Cell..."
            '
            'toolStripMenuItem3
            '
            Me.toolStripMenuItem3.Name = "toolStripMenuItem3"
            Me.toolStripMenuItem3.Size = New System.Drawing.Size(185, 6)
            '
            'saveLayoutToolStripMenuItem
            '
            Me.saveLayoutToolStripMenuItem.Name = "saveLayoutToolStripMenuItem"
            Me.saveLayoutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
            Me.saveLayoutToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
            Me.saveLayoutToolStripMenuItem.Text = "&Save Layout..."
            '
            'loadLayoutToolStripMenuItem
            '
            Me.loadLayoutToolStripMenuItem.Name = "loadLayoutToolStripMenuItem"
            Me.loadLayoutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
            Me.loadLayoutToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
            Me.loadLayoutToolStripMenuItem.Text = "Load Layout..."
            '
            'sToolStripMenuItem
            '
            Me.sToolStripMenuItem.Name = "sToolStripMenuItem"
            Me.sToolStripMenuItem.Size = New System.Drawing.Size(185, 6)
            '
            '_fileMenuItem_exit
            '
            Me._fileMenuItem_exit.Name = "_fileMenuItem_exit"
            Me._fileMenuItem_exit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
            Me._fileMenuItem_exit.Size = New System.Drawing.Size(188, 22)
            Me._fileMenuItem_exit.Text = "&Exit"
            '
            '_editMenuItem
            '
            Me._editMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miEditFreezeCell, Me._miEditToggleFreeze, Me.sToolStripMenuItem1, Me._miEditSelectAll, Me._miEditInvertSelection, Me._miEditDeselectAll, Me.sToolStripMenuItem2, Me._miEditRemoveCell, Me._miEditRemoveSelectedCells, Me.sToolStripMenuItem3, Me._miEditAnimation})
            Me._editMenuItem.Name = "_editMenuItem"
            Me._editMenuItem.Size = New System.Drawing.Size(39, 20)
            Me._editMenuItem.Text = "&Edit"
            '
            '_miEditFreezeCell
            '
            Me._miEditFreezeCell.Name = "_miEditFreezeCell"
            Me._miEditFreezeCell.Size = New System.Drawing.Size(200, 22)
            Me._miEditFreezeCell.Text = "&Freeze Cell(s)..."
            '
            '_miEditToggleFreeze
            '
            Me._miEditToggleFreeze.Name = "_miEditToggleFreeze"
            Me._miEditToggleFreeze.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
            Me._miEditToggleFreeze.Size = New System.Drawing.Size(200, 22)
            Me._miEditToggleFreeze.Text = "To&ggle Freeze"
            '
            'sToolStripMenuItem1
            '
            Me.sToolStripMenuItem1.Name = "sToolStripMenuItem1"
            Me.sToolStripMenuItem1.Size = New System.Drawing.Size(197, 6)
            '
            '_miEditSelectAll
            '
            Me._miEditSelectAll.Name = "_miEditSelectAll"
            Me._miEditSelectAll.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
            Me._miEditSelectAll.Size = New System.Drawing.Size(200, 22)
            Me._miEditSelectAll.Text = "&Select All"
            '
            '_miEditInvertSelection
            '
            Me._miEditInvertSelection.Name = "_miEditInvertSelection"
            Me._miEditInvertSelection.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
            Me._miEditInvertSelection.Size = New System.Drawing.Size(200, 22)
            Me._miEditInvertSelection.Text = "&Invert Selection"
            '
            '_miEditDeselectAll
            '
            Me._miEditDeselectAll.Name = "_miEditDeselectAll"
            Me._miEditDeselectAll.Size = New System.Drawing.Size(200, 22)
            Me._miEditDeselectAll.Text = "&Deselect All"
            '
            'sToolStripMenuItem2
            '
            Me.sToolStripMenuItem2.Name = "sToolStripMenuItem2"
            Me.sToolStripMenuItem2.Size = New System.Drawing.Size(197, 6)
            '
            '_miEditRemoveCell
            '
            Me._miEditRemoveCell.Name = "_miEditRemoveCell"
            Me._miEditRemoveCell.Size = New System.Drawing.Size(200, 22)
            Me._miEditRemoveCell.Text = "Remo&ve Cell(s)..."
            '
            '_miEditRemoveSelectedCells
            '
            Me._miEditRemoveSelectedCells.Name = "_miEditRemoveSelectedCells"
            Me._miEditRemoveSelectedCells.Size = New System.Drawing.Size(200, 22)
            Me._miEditRemoveSelectedCells.Text = "&Remove Selected Cell(s)"
            '
            'sToolStripMenuItem3
            '
            Me.sToolStripMenuItem3.Name = "sToolStripMenuItem3"
            Me.sToolStripMenuItem3.Size = New System.Drawing.Size(197, 6)
            '
            '_miEditAnimation
            '
            Me._miEditAnimation.Name = "_miEditAnimation"
            Me._miEditAnimation.Size = New System.Drawing.Size(200, 22)
            Me._miEditAnimation.Text = "&Animation..."
            '
            'layoutToolStripMenuItem
            '
            Me.layoutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.designToolStripMenuItem, Me.toolToolStripMenuItem, Me.toolStripMenuItem2, Me.allowCellsToOverlappToolStripMenuItem, Me.showLocationToolStripMenuItem, Me.gridToolStripMenuItem, Me.toolStripMenuItem1, Me.bW2ToolStripMenuItem, Me.bW4ToolStripMenuItem, Me.fMX18ToolStripMenuItem, Me.fMX20ToolStripMenuItem, Me.toolStripMenuItem4, Me.overlapPriorityToolStripMenuItem})
            Me.layoutToolStripMenuItem.Name = "layoutToolStripMenuItem"
            Me.layoutToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
            Me.layoutToolStripMenuItem.Text = "&Layout"
            '
            'designToolStripMenuItem
            '
            Me.designToolStripMenuItem.Name = "designToolStripMenuItem"
            Me.designToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
                        Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
            Me.designToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
            Me.designToolStripMenuItem.Text = "&Design"
            '
            'toolToolStripMenuItem
            '
            Me.toolToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.selectionToolStripMenuItem, Me.drawToolStripMenuItem})
            Me.toolToolStripMenuItem.Name = "toolToolStripMenuItem"
            Me.toolToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
            Me.toolToolStripMenuItem.Text = "&Tool"
            '
            'selectionToolStripMenuItem
            '
            Me.selectionToolStripMenuItem.Name = "selectionToolStripMenuItem"
            Me.selectionToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
            Me.selectionToolStripMenuItem.Text = "&Selection"
            '
            'drawToolStripMenuItem
            '
            Me.drawToolStripMenuItem.Name = "drawToolStripMenuItem"
            Me.drawToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
            Me.drawToolStripMenuItem.Text = "&Draw"
            '
            'toolStripMenuItem2
            '
            Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
            Me.toolStripMenuItem2.Size = New System.Drawing.Size(190, 6)
            '
            'allowCellsToOverlappToolStripMenuItem
            '
            Me.allowCellsToOverlappToolStripMenuItem.Name = "allowCellsToOverlappToolStripMenuItem"
            Me.allowCellsToOverlappToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
            Me.allowCellsToOverlappToolStripMenuItem.Text = "Allow Cells To Overlap"
            '
            'showLocationToolStripMenuItem
            '
            Me.showLocationToolStripMenuItem.Name = "showLocationToolStripMenuItem"
            Me.showLocationToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
            Me.showLocationToolStripMenuItem.Text = "Show Position"
            '
            'gridToolStripMenuItem
            '
            Me.gridToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.showToolStripMenuItem, Me.snapToolStripMenuItem, Me.showLinesToolStripMenuItem, Me.sizeToolStripMenuItem})
            Me.gridToolStripMenuItem.Name = "gridToolStripMenuItem"
            Me.gridToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
            Me.gridToolStripMenuItem.Text = "Grid"
            '
            'showToolStripMenuItem
            '
            Me.showToolStripMenuItem.Name = "showToolStripMenuItem"
            Me.showToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
            Me.showToolStripMenuItem.Text = "Show"
            '
            'snapToolStripMenuItem
            '
            Me.snapToolStripMenuItem.Name = "snapToolStripMenuItem"
            Me.snapToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
            Me.snapToolStripMenuItem.Text = "Snap"
            '
            'showLinesToolStripMenuItem
            '
            Me.showLinesToolStripMenuItem.Name = "showLinesToolStripMenuItem"
            Me.showLinesToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
            Me.showLinesToolStripMenuItem.Text = "Show Lines"
            '
            'sizeToolStripMenuItem
            '
            Me.sizeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.x6ToolStripMenuItem, Me.x8ToolStripMenuItem, Me.x10ToolStripMenuItem})
            Me.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem"
            Me.sizeToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
            Me.sizeToolStripMenuItem.Text = "Size"
            '
            'x6ToolStripMenuItem
            '
            Me.x6ToolStripMenuItem.Name = "x6ToolStripMenuItem"
            Me.x6ToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
            Me.x6ToolStripMenuItem.Tag = "6"
            Me.x6ToolStripMenuItem.Text = "6x6"
            '
            'x8ToolStripMenuItem
            '
            Me.x8ToolStripMenuItem.Name = "x8ToolStripMenuItem"
            Me.x8ToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
            Me.x8ToolStripMenuItem.Tag = "8"
            Me.x8ToolStripMenuItem.Text = "8x8"
            '
            'x10ToolStripMenuItem
            '
            Me.x10ToolStripMenuItem.Name = "x10ToolStripMenuItem"
            Me.x10ToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
            Me.x10ToolStripMenuItem.Tag = "10"
            Me.x10ToolStripMenuItem.Text = "10x10"
            '
            'toolStripMenuItem1
            '
            Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
            Me.toolStripMenuItem1.Size = New System.Drawing.Size(190, 6)
            '
            'bW2ToolStripMenuItem
            '
            Me.bW2ToolStripMenuItem.Name = "bW2ToolStripMenuItem"
            Me.bW2ToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
            Me.bW2ToolStripMenuItem.Text = "BW2"
            '
            'bW4ToolStripMenuItem
            '
            Me.bW4ToolStripMenuItem.Name = "bW4ToolStripMenuItem"
            Me.bW4ToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
            Me.bW4ToolStripMenuItem.Text = "&BW4"
            '
            'fMX18ToolStripMenuItem
            '
            Me.fMX18ToolStripMenuItem.Name = "fMX18ToolStripMenuItem"
            Me.fMX18ToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
            Me.fMX18ToolStripMenuItem.Text = "&FMX18"
            '
            'fMX20ToolStripMenuItem
            '
            Me.fMX20ToolStripMenuItem.Name = "fMX20ToolStripMenuItem"
            Me.fMX20ToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
            Me.fMX20ToolStripMenuItem.Text = "FMX20"
            '
            'toolStripMenuItem4
            '
            Me.toolStripMenuItem4.Name = "toolStripMenuItem4"
            Me.toolStripMenuItem4.Size = New System.Drawing.Size(190, 6)
            '
            'overlapPriorityToolStripMenuItem
            '
            Me.overlapPriorityToolStripMenuItem.Name = "overlapPriorityToolStripMenuItem"
            Me.overlapPriorityToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
            Me.overlapPriorityToolStripMenuItem.Text = "Overlap Priority"
            '
            '_propertiesMenuItem
            '
            Me._propertiesMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miPropertiesViewerProperties, Me._miPropertiesCellProperties})
            Me._propertiesMenuItem.Name = "_propertiesMenuItem"
            Me._propertiesMenuItem.Size = New System.Drawing.Size(72, 20)
            Me._propertiesMenuItem.Text = "&Properties"
            '
            '_miPropertiesViewerProperties
            '
            Me._miPropertiesViewerProperties.Name = "_miPropertiesViewerProperties"
            Me._miPropertiesViewerProperties.Size = New System.Drawing.Size(174, 22)
            Me._miPropertiesViewerProperties.Text = "&Viewer Properties..."
            '
            '_miPropertiesCellProperties
            '
            Me._miPropertiesCellProperties.Name = "_miPropertiesCellProperties"
            Me._miPropertiesCellProperties.Size = New System.Drawing.Size(174, 22)
            Me._miPropertiesCellProperties.Text = "&Cell Properties..."
            '
            '_actionsMenuItem
            '
            Me._actionsMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miActionWindowLevel, Me._miActionAlpha, Me._miActionScale, Me._miActionMagnify, Me._miActionStack, Me._miActionOffset})
            Me._actionsMenuItem.Name = "_actionsMenuItem"
            Me._actionsMenuItem.Size = New System.Drawing.Size(59, 20)
            Me._actionsMenuItem.Text = "&Actions"
            '
            '_miActionWindowLevel
            '
            Me._miActionWindowLevel.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miActionWindowLevelSet, Me._miActionWindowLevelCustomize})
            Me._miActionWindowLevel.Name = "_miActionWindowLevel"
            Me._miActionWindowLevel.Size = New System.Drawing.Size(148, 22)
            Me._miActionWindowLevel.Text = "&Window Level"
            '
            '_miActionWindowLevelSet
            '
            Me._miActionWindowLevelSet.Name = "_miActionWindowLevelSet"
            Me._miActionWindowLevelSet.Size = New System.Drawing.Size(216, 22)
            Me._miActionWindowLevelSet.Text = "&Set..."
            '
            '_miActionWindowLevelCustomize
            '
            Me._miActionWindowLevelCustomize.Name = "_miActionWindowLevelCustomize"
            Me._miActionWindowLevelCustomize.Size = New System.Drawing.Size(216, 22)
            Me._miActionWindowLevelCustomize.Text = "Customize Window Level..."
            '
            '_miActionAlpha
            '
            Me._miActionAlpha.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miActionAlphaSet, Me._miActionAlphaCustomizeAlpha})
            Me._miActionAlpha.Name = "_miActionAlpha"
            Me._miActionAlpha.Size = New System.Drawing.Size(148, 22)
            Me._miActionAlpha.Text = "&Alpha"
            '
            '_miActionAlphaSet
            '
            Me._miActionAlphaSet.Name = "_miActionAlphaSet"
            Me._miActionAlphaSet.Size = New System.Drawing.Size(173, 22)
            Me._miActionAlphaSet.Text = "&Set..."
            '
            '_miActionAlphaCustomizeAlpha
            '
            Me._miActionAlphaCustomizeAlpha.Name = "_miActionAlphaCustomizeAlpha"
            Me._miActionAlphaCustomizeAlpha.Size = New System.Drawing.Size(173, 22)
            Me._miActionAlphaCustomizeAlpha.Text = "Customize Alpha..."
            '
            '_miActionScale
            '
            Me._miActionScale.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miActionScaleSet, Me._miActionScaleCustomizeScale})
            Me._miActionScale.Name = "_miActionScale"
            Me._miActionScale.Size = New System.Drawing.Size(148, 22)
            Me._miActionScale.Text = "&Scale"
            '
            '_miActionScaleSet
            '
            Me._miActionScaleSet.Name = "_miActionScaleSet"
            Me._miActionScaleSet.Size = New System.Drawing.Size(169, 22)
            Me._miActionScaleSet.Text = "&Set..."
            '
            '_miActionScaleCustomizeScale
            '
            Me._miActionScaleCustomizeScale.Name = "_miActionScaleCustomizeScale"
            Me._miActionScaleCustomizeScale.Size = New System.Drawing.Size(169, 22)
            Me._miActionScaleCustomizeScale.Text = "Customize Scale..."
            '
            '_miActionMagnify
            '
            Me._miActionMagnify.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miMagnifySet, Me._miActionMagnifyCustomizeMagnify})
            Me._miActionMagnify.Name = "_miActionMagnify"
            Me._miActionMagnify.Size = New System.Drawing.Size(148, 22)
            Me._miActionMagnify.Text = "&Magnify"
            '
            '_miMagnifySet
            '
            Me._miMagnifySet.Name = "_miMagnifySet"
            Me._miMagnifySet.Size = New System.Drawing.Size(186, 22)
            Me._miMagnifySet.Text = "&Set..."
            '
            '_miActionMagnifyCustomizeMagnify
            '
            Me._miActionMagnifyCustomizeMagnify.Name = "_miActionMagnifyCustomizeMagnify"
            Me._miActionMagnifyCustomizeMagnify.Size = New System.Drawing.Size(186, 22)
            Me._miActionMagnifyCustomizeMagnify.Text = "Customize Magnify..."
            '
            '_miActionStack
            '
            Me._miActionStack.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miActionStackSet, Me._miActionStackCustomizeStack})
            Me._miActionStack.Name = "_miActionStack"
            Me._miActionStack.Size = New System.Drawing.Size(148, 22)
            Me._miActionStack.Text = "&Stack"
            '
            '_miActionStackSet
            '
            Me._miActionStackSet.Name = "_miActionStackSet"
            Me._miActionStackSet.Size = New System.Drawing.Size(170, 22)
            Me._miActionStackSet.Text = "&Set..."
            '
            '_miActionStackCustomizeStack
            '
            Me._miActionStackCustomizeStack.Name = "_miActionStackCustomizeStack"
            Me._miActionStackCustomizeStack.Size = New System.Drawing.Size(170, 22)
            Me._miActionStackCustomizeStack.Text = "Customize Stack..."
            '
            '_miActionOffset
            '
            Me._miActionOffset.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miActionOffsetSet, Me._miActionOffsetCustomizeOffset})
            Me._miActionOffset.Name = "_miActionOffset"
            Me._miActionOffset.Size = New System.Drawing.Size(148, 22)
            Me._miActionOffset.Text = "&Offset"
            '
            '_miActionOffsetSet
            '
            Me._miActionOffsetSet.Name = "_miActionOffsetSet"
            Me._miActionOffsetSet.Size = New System.Drawing.Size(174, 22)
            Me._miActionOffsetSet.Text = "&Set..."
            '
            '_miActionOffsetCustomizeOffset
            '
            Me._miActionOffsetCustomizeOffset.Name = "_miActionOffsetCustomizeOffset"
            Me._miActionOffsetCustomizeOffset.Size = New System.Drawing.Size(174, 22)
            Me._miActionOffsetCustomizeOffset.Text = "Customize Offset..."
            '
            '_helpMenuItem
            '
            Me._helpMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miHelpAbout})
            Me._helpMenuItem.Name = "_helpMenuItem"
            Me._helpMenuItem.Size = New System.Drawing.Size(44, 20)
            Me._helpMenuItem.Text = "&Help"
            '
            '_miHelpAbout
            '
            Me._miHelpAbout.Name = "_miHelpAbout"
            Me._miHelpAbout.Size = New System.Drawing.Size(116, 22)
            Me._miHelpAbout.Text = "&About..."
            '
            '_mainPanel
            '
            Me._mainPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me._mainPanel.Location = New System.Drawing.Point(0, 49)
            Me._mainPanel.Name = "_mainPanel"
            Me._mainPanel.Size = New System.Drawing.Size(640, 391)
            Me._mainPanel.TabIndex = 2
            '
            'toolStrip1
            '
            Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripButtonUserMode, Me.toolStripSeparator3, Me.toolStripButtonSelect, Me.toolStripButtonDraw, Me.toolStripButtonOverlap, Me.toolStripSeparator4, Me.toolStripButtonShowPosition, Me.toolStripButton1})
            Me.toolStrip1.Location = New System.Drawing.Point(0, 24)
            Me.toolStrip1.Name = "toolStrip1"
            Me.toolStrip1.Size = New System.Drawing.Size(640, 25)
            Me.toolStrip1.TabIndex = 3
            Me.toolStrip1.Text = "toolStrip1"
            '
            'toolStripButtonUserMode
            '
            Me.toolStripButtonUserMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripButtonUserMode.Image = CType(resources.GetObject("toolStripButtonUserMode.Image"), System.Drawing.Image)
            Me.toolStripButtonUserMode.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripButtonUserMode.Name = "toolStripButtonUserMode"
            Me.toolStripButtonUserMode.Size = New System.Drawing.Size(23, 22)
            Me.toolStripButtonUserMode.Text = "toolStripButton1"
            Me.toolStripButtonUserMode.ToolTipText = "User Mode"
            '
            'toolStripSeparator3
            '
            Me.toolStripSeparator3.Name = "toolStripSeparator3"
            Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
            '
            'toolStripButtonSelect
            '
            Me.toolStripButtonSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripButtonSelect.Image = CType(resources.GetObject("toolStripButtonSelect.Image"), System.Drawing.Image)
            Me.toolStripButtonSelect.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripButtonSelect.Name = "toolStripButtonSelect"
            Me.toolStripButtonSelect.Size = New System.Drawing.Size(23, 22)
            Me.toolStripButtonSelect.Text = "toolStripButton2"
            Me.toolStripButtonSelect.ToolTipText = "Select Tool"
            '
            'toolStripButtonDraw
            '
            Me.toolStripButtonDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripButtonDraw.Image = CType(resources.GetObject("toolStripButtonDraw.Image"), System.Drawing.Image)
            Me.toolStripButtonDraw.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripButtonDraw.Name = "toolStripButtonDraw"
            Me.toolStripButtonDraw.Size = New System.Drawing.Size(23, 22)
            Me.toolStripButtonDraw.Text = "toolStripButton3"
            Me.toolStripButtonDraw.ToolTipText = "Draw Tool"
            '
            'toolStripButtonOverlap
            '
            Me.toolStripButtonOverlap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripButtonOverlap.Image = CType(resources.GetObject("toolStripButtonOverlap.Image"), System.Drawing.Image)
            Me.toolStripButtonOverlap.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripButtonOverlap.Name = "toolStripButtonOverlap"
            Me.toolStripButtonOverlap.Size = New System.Drawing.Size(23, 22)
            Me.toolStripButtonOverlap.ToolTipText = "Allow Cells To Overlap"
            '
            'toolStripSeparator4
            '
            Me.toolStripSeparator4.Name = "toolStripSeparator4"
            Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 25)
            '
            'toolStripButtonShowPosition
            '
            Me.toolStripButtonShowPosition.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripButtonShowPosition.Image = Global.Resources.map_go
            Me.toolStripButtonShowPosition.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripButtonShowPosition.Name = "toolStripButtonShowPosition"
            Me.toolStripButtonShowPosition.Size = New System.Drawing.Size(23, 22)
            Me.toolStripButtonShowPosition.Text = "toolStripButton1"
            Me.toolStripButtonShowPosition.ToolTipText = "Show Layout Position"
            '
            'toolStripButton1
            '
            Me.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripButton1.Name = "toolStripButton1"
            Me.toolStripButton1.Size = New System.Drawing.Size(23, 22)
            Me.toolStripButton1.Text = "toolStripButtonOverlap"
            Me.toolStripButton1.ToolTipText = "Change Overlap Priority"
            '
            'MainForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(640, 440)
            Me.Controls.Add(Me._mainPanel)
            Me.Controls.Add(Me.toolStrip1)
            Me.Controls.Add(Me._mainMenu)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MainMenuStrip = Me._mainMenu
            Me.Name = "MainForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
            Me.Text = "Medical Viewer Layout Demo"
            Me._mainMenu.ResumeLayout(False)
            Me._mainMenu.PerformLayout()
            Me.toolStrip1.ResumeLayout(False)
            Me.toolStrip1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub


	  #End Region

	  Private _mainMenu As System.Windows.Forms.MenuStrip
	  Private WithEvents _fileMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _editMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _propertiesMenuItem As System.Windows.Forms.ToolStripMenuItem
	   Private _actionsMenuItem As System.Windows.Forms.ToolStripMenuItem
	  Private _helpMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private sToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
	  Private WithEvents _fileMenuItem_exit As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _miEditFreezeCell As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _miEditToggleFreeze As System.Windows.Forms.ToolStripMenuItem
	  Private sToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
	  Private WithEvents _miEditSelectAll As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _miEditInvertSelection As System.Windows.Forms.ToolStripMenuItem
	   Private WithEvents _miEditDeselectAll As System.Windows.Forms.ToolStripMenuItem
	  Private sToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
	  Private WithEvents _miEditRemoveCell As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _miEditRemoveSelectedCells As System.Windows.Forms.ToolStripMenuItem
	  Private sToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
	   Private WithEvents _miEditAnimation As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _miPropertiesViewerProperties As System.Windows.Forms.ToolStripMenuItem
	   Private WithEvents _miPropertiesCellProperties As System.Windows.Forms.ToolStripMenuItem
	   Private WithEvents _miHelpAbout As System.Windows.Forms.ToolStripMenuItem
	  Private _miActionWindowLevel As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _miActionWindowLevelSet As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _miActionWindowLevelCustomize As System.Windows.Forms.ToolStripMenuItem
	  Private _miActionAlpha As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _miActionAlphaSet As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _miActionAlphaCustomizeAlpha As System.Windows.Forms.ToolStripMenuItem
	  Private _miActionScale As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _miActionScaleSet As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _miActionScaleCustomizeScale As System.Windows.Forms.ToolStripMenuItem
	  Private _miActionMagnify As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _miMagnifySet As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _miActionMagnifyCustomizeMagnify As System.Windows.Forms.ToolStripMenuItem
	  Private _miActionStack As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _miActionStackSet As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _miActionStackCustomizeStack As System.Windows.Forms.ToolStripMenuItem
	  Private _miActionOffset As System.Windows.Forms.ToolStripMenuItem
	  Private WithEvents _miActionOffsetSet As System.Windows.Forms.ToolStripMenuItem
	   Private WithEvents _miActionOffsetCustomizeOffset As System.Windows.Forms.ToolStripMenuItem
	   Private _mainPanel As System.Windows.Forms.Panel
	   Private WithEvents _printCellMenuItem As System.Windows.Forms.ToolStripMenuItem
	   Private WithEvents layoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	   Private WithEvents bW4ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	   Private WithEvents fMX18ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	   Private WithEvents bW2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	   Private WithEvents fMX20ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	   Private WithEvents designToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	   Private toolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
	   Private toolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
	   Private WithEvents gridToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	   Private WithEvents showToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	   Private WithEvents snapToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	   Private WithEvents sizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents x6ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	   Private WithEvents x8ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	   Private WithEvents x10ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	   Private WithEvents saveLayoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	   Private toolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
	   Private WithEvents loadLayoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	   Private WithEvents toolToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	   Private WithEvents selectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	   Private WithEvents drawToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	   Private WithEvents allowCellsToOverlappToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	   Private toolStrip1 As System.Windows.Forms.ToolStrip
	   Private WithEvents toolStripButtonUserMode As System.Windows.Forms.ToolStripButton
	   Private WithEvents toolStripButtonSelect As System.Windows.Forms.ToolStripButton
	   Private WithEvents toolStripButtonDraw As System.Windows.Forms.ToolStripButton
	   Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
	   Private toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
	   Private WithEvents toolStripButtonShowPosition As System.Windows.Forms.ToolStripButton
	   Private WithEvents showLocationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	   Private WithEvents toolStripButtonOverlap As System.Windows.Forms.ToolStripButton
	   Private toolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
	   Private WithEvents overlapPriorityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	   Private WithEvents toolStripButton1 As System.Windows.Forms.ToolStripButton
	   Private WithEvents insertImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	   Private toolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
	   Private WithEvents showLinesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   End Class
End Namespace

