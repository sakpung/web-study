Namespace MedicalViewerDemo
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
         Me._mainMenu = New System.Windows.Forms.MenuStrip()
         Me._fileMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._fileMenuItem_insertCell = New System.Windows.Forms.ToolStripMenuItem()
         Me._printCellMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.saveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.sToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._fileMenuItem_exit = New System.Windows.Forms.ToolStripMenuItem()
         Me._editMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._miEditFreezeCell = New System.Windows.Forms.ToolStripMenuItem()
         Me._miEditToggleFreeze = New System.Windows.Forms.ToolStripMenuItem()
         Me.sToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
         Me._miEditSelectAll = New System.Windows.Forms.ToolStripMenuItem()
         Me._miEditInvertSelection = New System.Windows.Forms.ToolStripMenuItem()
         Me._miEditDeselectAll = New System.Windows.Forms.ToolStripMenuItem()
         Me._miEditRepositionCell = New System.Windows.Forms.ToolStripMenuItem()
         Me.sToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
         Me._miEditRemoveCell = New System.Windows.Forms.ToolStripMenuItem()
         Me._miEditRemoveSelectedCells = New System.Windows.Forms.ToolStripMenuItem()
         Me.sToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
         Me._miEditAnimation = New System.Windows.Forms.ToolStripMenuItem()
         Me._miEditCalibrateRuler = New System.Windows.Forms.ToolStripMenuItem()
         Me._miEditConvertAnnotationToRegion = New System.Windows.Forms.ToolStripMenuItem()
         Me._propertiesMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._miPropertiesViewerProperties = New System.Windows.Forms.ToolStripMenuItem()
         Me._miPropertiesCellProperties = New System.Windows.Forms.ToolStripMenuItem()
         Me._actionsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionWindowLevel = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionWindowLevelSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionWindowLevelCustomize = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionAlpha = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionAlphaSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionAlphaCustomizeAlpha = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionScale = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionScaleSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionScaleCustomizeScale = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionMagnify = New System.Windows.Forms.ToolStripMenuItem()
         Me._miMagnifySet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionMagnifyCustomizeMagnify = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionStack = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionStackSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionStackCustomizeStack = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionOffset = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionOffsetSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionOffsetCustomizeOffset = New System.Windows.Forms.ToolStripMenuItem()
         Me._miSpyGlass = New System.Windows.Forms.ToolStripMenuItem()
         Me._miSpyGlassSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionsProbeTool = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionsProbeToolSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionZoomToRectangle = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionZoomToRectangleSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionClickZoomIn = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionClickZoomInSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionClickZoomOut = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionClickZoomOutSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionCobbAngle = New System.Windows.Forms.ToolStripMenuItem()
         Me._miActionCobbAngleSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._regionMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.loadRegionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.selectedCellsToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
         Me.allCellsToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
         Me.saveRegionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.selectedCellsToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
         Me.allCellsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
         Me._miStatisticsStatistics = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
         Me._miRegionRectangle = New System.Windows.Forms.ToolStripMenuItem()
         Me._miRegionRectangleSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miRegionEllipse = New System.Windows.Forms.ToolStripMenuItem()
         Me._miRegionEllipseSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miRegionSquare = New System.Windows.Forms.ToolStripMenuItem()
         Me._miRegionSquareSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miRegionCircle = New System.Windows.Forms.ToolStripMenuItem()
         Me._miRegionCircleSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miRegionPolygon = New System.Windows.Forms.ToolStripMenuItem()
         Me._miRegionPolygonSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miRegionFreeHand = New System.Windows.Forms.ToolStripMenuItem()
         Me._miRegionFreeHandSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miRegionMagicWand = New System.Windows.Forms.ToolStripMenuItem()
         Me._miRegionMagicWandSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miRegionColorRange = New System.Windows.Forms.ToolStripMenuItem()
         Me._miRegionColorRangeSet = New System.Windows.Forms.ToolStripMenuItem()
         Me.nudgeToolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.setToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.customizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._annotationMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.loadAnnotationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.selectedCellsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
         Me.allCellToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.saveAnnotationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.selectedCellsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.allCellsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._miEditAnnotation = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
         Me._miAnnotationRectangle = New System.Windows.Forms.ToolStripMenuItem()
         Me._miAnnotationRectangleSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miAnnotationRectangleCustomizeRectangle = New System.Windows.Forms.ToolStripMenuItem()
         Me._miAnnotationEllipse = New System.Windows.Forms.ToolStripMenuItem()
         Me._miAnnotationEllipseSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miAnnotationEllipseCustomizeEllipse = New System.Windows.Forms.ToolStripMenuItem()
         Me._miAnnotationArrow = New System.Windows.Forms.ToolStripMenuItem()
         Me._miAnnotationArrowSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miAnnotationArrowCustomizeArrow = New System.Windows.Forms.ToolStripMenuItem()
         Me._miAnnotationText = New System.Windows.Forms.ToolStripMenuItem()
         Me._miAnnotationTextSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miAnnotationTextCustomizeText = New System.Windows.Forms.ToolStripMenuItem()
         Me._miAnnotationAngle = New System.Windows.Forms.ToolStripMenuItem()
         Me._miAnnotationAngleSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miAnnotationAngleCustomizeAngle = New System.Windows.Forms.ToolStripMenuItem()
         Me._miAnnotationHilite = New System.Windows.Forms.ToolStripMenuItem()
         Me._miAnnotationHiliteSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miAnnotationHiliteCustomizeHilite = New System.Windows.Forms.ToolStripMenuItem()
         Me._miAnnotationRuler = New System.Windows.Forms.ToolStripMenuItem()
         Me._miAnnotationRulerSet = New System.Windows.Forms.ToolStripMenuItem()
         Me._miAnnotationRulerCustomizeRuler = New System.Windows.Forms.ToolStripMenuItem()
         Me._transformMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._miEffectReverse = New System.Windows.Forms.ToolStripMenuItem()
         Me._miEffectFlip = New System.Windows.Forms.ToolStripMenuItem()
         Me._miRotate = New System.Windows.Forms.ToolStripMenuItem()
         Me._miRotate90 = New System.Windows.Forms.ToolStripMenuItem()
         Me._miRotate180 = New System.Windows.Forms.ToolStripMenuItem()
         Me._miRotateMinus90 = New System.Windows.Forms.ToolStripMenuItem()
         Me._miRotateMinus180 = New System.Windows.Forms.ToolStripMenuItem()
         Me.sToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
         Me._miEffectOptions = New System.Windows.Forms.ToolStripMenuItem()
         Me._miEffectOptionsApplyToAllSubCells = New System.Windows.Forms.ToolStripMenuItem()
         Me._stentMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._stentEnhancementMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._unselectFramesMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._moveMarkersAction = New System.Windows.Forms.ToolStripMenuItem()
         Me._filtersMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.multiscaleEnhancementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.adaptiveContrastToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.unsharpMaskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.histogramEqualizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._miEffectCLAHE = New System.Windows.Forms.ToolStripMenuItem()
         Me._miEffectInvert = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
         Me.resetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._alignmentMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.imageAlignmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._selectPointsActionMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._helpMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._miHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
         Me._mainPanel = New System.Windows.Forms.Panel()
         Me._mainMenu.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _mainMenu
         ' 
         Me._mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._fileMenuItem, Me._editMenuItem, Me._propertiesMenuItem, Me._actionsMenuItem, Me._regionMenuItem, Me._annotationMenuItem, Me._transformMenuItem, Me._stentMenuItem, Me._filtersMenuItem, Me._alignmentMenuItem, Me._helpMenuItem})
         Me._mainMenu.Location = New System.Drawing.Point(0, 0)
         Me._mainMenu.Name = "_mainMenu"
         Me._mainMenu.Size = New System.Drawing.Size(772, 24)
         Me._mainMenu.TabIndex = 1
         Me._mainMenu.Text = "_mainMenu"
         ' 
         ' _fileMenuItem
         ' 
         Me._fileMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._fileMenuItem_insertCell, Me._printCellMenuItem, Me.saveToolStripMenuItem, Me.sToolStripMenuItem, Me._fileMenuItem_exit})
         Me._fileMenuItem.Name = "_fileMenuItem"
         Me._fileMenuItem.Size = New System.Drawing.Size(37, 20)
         Me._fileMenuItem.Text = "&File"
         ' 
         ' _fileMenuItem_insertCell
         ' 
         Me._fileMenuItem_insertCell.Name = "_fileMenuItem_insertCell"
         Me._fileMenuItem_insertCell.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys))
         Me._fileMenuItem_insertCell.Size = New System.Drawing.Size(178, 22)
         Me._fileMenuItem_insertCell.Text = "&Insert Cell..."
         ' 
         ' _printCellMenuItem
         ' 
         Me._printCellMenuItem.Name = "_printCellMenuItem"
         Me._printCellMenuItem.Size = New System.Drawing.Size(178, 22)
         Me._printCellMenuItem.Text = "&Print Cell..."
         ' 
         ' saveToolStripMenuItem
         ' 
         Me.saveToolStripMenuItem.Name = "saveToolStripMenuItem"
         Me.saveToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
         Me.saveToolStripMenuItem.Text = "Save..."
         ' 
         ' sToolStripMenuItem
         ' 
         Me.sToolStripMenuItem.Name = "sToolStripMenuItem"
         Me.sToolStripMenuItem.Size = New System.Drawing.Size(175, 6)
         ' 
         ' _fileMenuItem_exit
         ' 
         Me._fileMenuItem_exit.Name = "_fileMenuItem_exit"
         Me._fileMenuItem_exit.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys))
         Me._fileMenuItem_exit.Size = New System.Drawing.Size(178, 22)
         Me._fileMenuItem_exit.Text = "&Exit"
         ' 
         ' _editMenuItem
         ' 
         Me._editMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miEditFreezeCell, Me._miEditToggleFreeze, Me.sToolStripMenuItem1, Me._miEditSelectAll, Me._miEditInvertSelection, Me._miEditDeselectAll, Me._miEditRepositionCell, Me.sToolStripMenuItem2, Me._miEditRemoveCell, Me._miEditRemoveSelectedCells, Me.sToolStripMenuItem3, Me._miEditAnimation, Me._miEditCalibrateRuler, Me._miEditConvertAnnotationToRegion})
         Me._editMenuItem.Name = "_editMenuItem"
         Me._editMenuItem.Size = New System.Drawing.Size(39, 20)
         Me._editMenuItem.Text = "&Edit"
         ' 
         ' _miEditFreezeCell
         ' 
         Me._miEditFreezeCell.Name = "_miEditFreezeCell"
         Me._miEditFreezeCell.Size = New System.Drawing.Size(203, 22)
         Me._miEditFreezeCell.Text = "&Freeze Cell(s)..."
         ' 
         ' _miEditToggleFreeze
         ' 
         Me._miEditToggleFreeze.Name = "_miEditToggleFreeze"
         Me._miEditToggleFreeze.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys))
         Me._miEditToggleFreeze.Size = New System.Drawing.Size(203, 22)
         Me._miEditToggleFreeze.Text = "To&ggle Freeze"
         ' 
         ' sToolStripMenuItem1
         ' 
         Me.sToolStripMenuItem1.Name = "sToolStripMenuItem1"
         Me.sToolStripMenuItem1.Size = New System.Drawing.Size(200, 6)
         ' 
         ' _miEditSelectAll
         ' 
         Me._miEditSelectAll.Name = "_miEditSelectAll"
         Me._miEditSelectAll.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys))
         Me._miEditSelectAll.Size = New System.Drawing.Size(203, 22)
         Me._miEditSelectAll.Text = "&Select All"
         ' 
         ' _miEditInvertSelection
         ' 
         Me._miEditInvertSelection.Name = "_miEditInvertSelection"
         Me._miEditInvertSelection.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys))
         Me._miEditInvertSelection.Size = New System.Drawing.Size(203, 22)
         Me._miEditInvertSelection.Text = "&Invert Selection"
         ' 
         ' _miEditDeselectAll
         ' 
         Me._miEditDeselectAll.Name = "_miEditDeselectAll"
         Me._miEditDeselectAll.Size = New System.Drawing.Size(203, 22)
         Me._miEditDeselectAll.Text = "&Deselect All"
         ' 
         ' _miEditRepositionCell
         ' 
         Me._miEditRepositionCell.Name = "_miEditRepositionCell"
         Me._miEditRepositionCell.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys))
         Me._miEditRepositionCell.Size = New System.Drawing.Size(203, 22)
         Me._miEditRepositionCell.Text = "Re&position Cell..."
         ' 
         ' sToolStripMenuItem2
         ' 
         Me.sToolStripMenuItem2.Name = "sToolStripMenuItem2"
         Me.sToolStripMenuItem2.Size = New System.Drawing.Size(200, 6)
         ' 
         ' _miEditRemoveCell
         ' 
         Me._miEditRemoveCell.Name = "_miEditRemoveCell"
         Me._miEditRemoveCell.Size = New System.Drawing.Size(203, 22)
         Me._miEditRemoveCell.Text = "Remo&ve Cell(s)..."
         ' 
         ' _miEditRemoveSelectedCells
         ' 
         Me._miEditRemoveSelectedCells.Name = "_miEditRemoveSelectedCells"
         Me._miEditRemoveSelectedCells.Size = New System.Drawing.Size(203, 22)
         Me._miEditRemoveSelectedCells.Text = "&Remove Selected Cell(s)"
         ' 
         ' sToolStripMenuItem3
         ' 
         Me.sToolStripMenuItem3.Name = "sToolStripMenuItem3"
         Me.sToolStripMenuItem3.Size = New System.Drawing.Size(200, 6)
         ' 
         ' _miEditAnimation
         ' 
         Me._miEditAnimation.Name = "_miEditAnimation"
         Me._miEditAnimation.Size = New System.Drawing.Size(203, 22)
         Me._miEditAnimation.Text = "&Animation..."
         ' 
         ' _miEditCalibrateRuler
         ' 
         Me._miEditCalibrateRuler.Name = "_miEditCalibrateRuler"
         Me._miEditCalibrateRuler.Size = New System.Drawing.Size(203, 22)
         Me._miEditCalibrateRuler.Text = "Calibrate R&uler..."
         ' 
         ' _miEditConvertAnnotationToRegion
         ' 
         Me._miEditConvertAnnotationToRegion.Name = "_miEditConvertAnnotationToRegion"
         Me._miEditConvertAnnotationToRegion.Size = New System.Drawing.Size(203, 22)
         Me._miEditConvertAnnotationToRegion.Text = "Annotation &To Region"
         ' 
         ' _propertiesMenuItem
         ' 
         Me._propertiesMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miPropertiesViewerProperties, Me._miPropertiesCellProperties})
         Me._propertiesMenuItem.Name = "_propertiesMenuItem"
         Me._propertiesMenuItem.Size = New System.Drawing.Size(72, 20)
         Me._propertiesMenuItem.Text = "&Properties"
         ' 
         ' _miPropertiesViewerProperties
         ' 
         Me._miPropertiesViewerProperties.Name = "_miPropertiesViewerProperties"
         Me._miPropertiesViewerProperties.Size = New System.Drawing.Size(174, 22)
         Me._miPropertiesViewerProperties.Text = "&Viewer Properties..."
         ' 
         ' _miPropertiesCellProperties
         ' 
         Me._miPropertiesCellProperties.Name = "_miPropertiesCellProperties"
         Me._miPropertiesCellProperties.Size = New System.Drawing.Size(174, 22)
         Me._miPropertiesCellProperties.Text = "&Cell Properties..."
         ' 
         ' _actionsMenuItem
         ' 
         Me._actionsMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miActionWindowLevel, Me._miActionAlpha, Me._miActionScale, Me._miActionMagnify, Me._miActionStack, Me._miActionOffset, Me._miSpyGlass, Me._miActionsProbeTool, Me._miActionZoomToRectangle, Me._miActionClickZoomIn, Me._miActionClickZoomOut, Me._miActionCobbAngle})
         Me._actionsMenuItem.Name = "_actionsMenuItem"
         Me._actionsMenuItem.Size = New System.Drawing.Size(59, 20)
         Me._actionsMenuItem.Text = "&Actions"
         ' 
         ' _miActionWindowLevel
         ' 
         Me._miActionWindowLevel.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miActionWindowLevelSet, Me._miActionWindowLevelCustomize})
         Me._miActionWindowLevel.Name = "_miActionWindowLevel"
         Me._miActionWindowLevel.Size = New System.Drawing.Size(178, 22)
         Me._miActionWindowLevel.Text = "&Window Level"
         ' 
         ' _miActionWindowLevelSet
         ' 
         Me._miActionWindowLevelSet.Name = "_miActionWindowLevelSet"
         Me._miActionWindowLevelSet.Size = New System.Drawing.Size(216, 22)
         Me._miActionWindowLevelSet.Text = "&Set..."
         ' 
         ' _miActionWindowLevelCustomize
         ' 
         Me._miActionWindowLevelCustomize.Name = "_miActionWindowLevelCustomize"
         Me._miActionWindowLevelCustomize.Size = New System.Drawing.Size(216, 22)
         Me._miActionWindowLevelCustomize.Text = "Customize Window Level..."
         ' 
         ' _miActionAlpha
         ' 
         Me._miActionAlpha.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miActionAlphaSet, Me._miActionAlphaCustomizeAlpha})
         Me._miActionAlpha.Name = "_miActionAlpha"
         Me._miActionAlpha.Size = New System.Drawing.Size(178, 22)
         Me._miActionAlpha.Text = "&Alpha"
         ' 
         ' _miActionAlphaSet
         ' 
         Me._miActionAlphaSet.Name = "_miActionAlphaSet"
         Me._miActionAlphaSet.Size = New System.Drawing.Size(173, 22)
         Me._miActionAlphaSet.Text = "&Set..."
         ' 
         ' _miActionAlphaCustomizeAlpha
         ' 
         Me._miActionAlphaCustomizeAlpha.Name = "_miActionAlphaCustomizeAlpha"
         Me._miActionAlphaCustomizeAlpha.Size = New System.Drawing.Size(173, 22)
         Me._miActionAlphaCustomizeAlpha.Text = "Customize Alpha..."
         ' 
         ' _miActionScale
         ' 
         Me._miActionScale.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miActionScaleSet, Me._miActionScaleCustomizeScale})
         Me._miActionScale.Name = "_miActionScale"
         Me._miActionScale.Size = New System.Drawing.Size(178, 22)
         Me._miActionScale.Text = "&Scale"
         ' 
         ' _miActionScaleSet
         ' 
         Me._miActionScaleSet.Name = "_miActionScaleSet"
         Me._miActionScaleSet.Size = New System.Drawing.Size(169, 22)
         Me._miActionScaleSet.Text = "&Set..."
         ' 
         ' _miActionScaleCustomizeScale
         ' 
         Me._miActionScaleCustomizeScale.Name = "_miActionScaleCustomizeScale"
         Me._miActionScaleCustomizeScale.Size = New System.Drawing.Size(169, 22)
         Me._miActionScaleCustomizeScale.Text = "Customize Scale..."
         ' 
         ' _miActionMagnify
         ' 
         Me._miActionMagnify.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miMagnifySet, Me._miActionMagnifyCustomizeMagnify})
         Me._miActionMagnify.Name = "_miActionMagnify"
         Me._miActionMagnify.Size = New System.Drawing.Size(178, 22)
         Me._miActionMagnify.Text = "&Magnify"
         ' 
         ' _miMagnifySet
         ' 
         Me._miMagnifySet.Name = "_miMagnifySet"
         Me._miMagnifySet.Size = New System.Drawing.Size(186, 22)
         Me._miMagnifySet.Text = "&Set..."
         ' 
         ' _miActionMagnifyCustomizeMagnify
         ' 
         Me._miActionMagnifyCustomizeMagnify.Name = "_miActionMagnifyCustomizeMagnify"
         Me._miActionMagnifyCustomizeMagnify.Size = New System.Drawing.Size(186, 22)
         Me._miActionMagnifyCustomizeMagnify.Text = "Customize Magnify..."
         ' 
         ' _miActionStack
         ' 
         Me._miActionStack.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miActionStackSet, Me._miActionStackCustomizeStack})
         Me._miActionStack.Name = "_miActionStack"
         Me._miActionStack.Size = New System.Drawing.Size(178, 22)
         Me._miActionStack.Text = "&Stack"
         ' 
         ' _miActionStackSet
         ' 
         Me._miActionStackSet.Name = "_miActionStackSet"
         Me._miActionStackSet.Size = New System.Drawing.Size(170, 22)
         Me._miActionStackSet.Text = "&Set..."
         ' 
         ' _miActionStackCustomizeStack
         ' 
         Me._miActionStackCustomizeStack.Name = "_miActionStackCustomizeStack"
         Me._miActionStackCustomizeStack.Size = New System.Drawing.Size(170, 22)
         Me._miActionStackCustomizeStack.Text = "Customize Stack..."
         ' 
         ' _miActionOffset
         ' 
         Me._miActionOffset.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miActionOffsetSet, Me._miActionOffsetCustomizeOffset})
         Me._miActionOffset.Name = "_miActionOffset"
         Me._miActionOffset.Size = New System.Drawing.Size(178, 22)
         Me._miActionOffset.Text = "&Pan"
         ' 
         ' _miActionOffsetSet
         ' 
         Me._miActionOffsetSet.Name = "_miActionOffsetSet"
         Me._miActionOffsetSet.Size = New System.Drawing.Size(162, 22)
         Me._miActionOffsetSet.Text = "&Set..."
         ' 
         ' _miActionOffsetCustomizeOffset
         ' 
         Me._miActionOffsetCustomizeOffset.Name = "_miActionOffsetCustomizeOffset"
         Me._miActionOffsetCustomizeOffset.Size = New System.Drawing.Size(162, 22)
         Me._miActionOffsetCustomizeOffset.Text = "Customize Pan..."
         ' 
         ' _miSpyGlass
         ' 
         Me._miSpyGlass.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miSpyGlassSet})
         Me._miSpyGlass.Name = "_miSpyGlass"
         Me._miSpyGlass.Size = New System.Drawing.Size(178, 22)
         Me._miSpyGlass.Text = "Sp&y Glass"
         ' 
         ' _miSpyGlassSet
         ' 
         Me._miSpyGlassSet.Name = "_miSpyGlassSet"
         Me._miSpyGlassSet.Size = New System.Drawing.Size(99, 22)
         Me._miSpyGlassSet.Text = "&Set..."
         ' 
         ' _miActionsProbeTool
         ' 
         Me._miActionsProbeTool.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miActionsProbeToolSet})
         Me._miActionsProbeTool.Name = "_miActionsProbeTool"
         Me._miActionsProbeTool.Size = New System.Drawing.Size(178, 22)
         Me._miActionsProbeTool.Text = "&Probe Tool"
         ' 
         ' _miActionsProbeToolSet
         ' 
         Me._miActionsProbeToolSet.Name = "_miActionsProbeToolSet"
         Me._miActionsProbeToolSet.Size = New System.Drawing.Size(99, 22)
         Me._miActionsProbeToolSet.Text = "&Set..."
         ' 
         ' _miActionZoomToRectangle
         ' 
         Me._miActionZoomToRectangle.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miActionZoomToRectangleSet})
         Me._miActionZoomToRectangle.Name = "_miActionZoomToRectangle"
         Me._miActionZoomToRectangle.Size = New System.Drawing.Size(178, 22)
         Me._miActionZoomToRectangle.Text = "&Zoom To Rectangle"
         ' 
         ' _miActionZoomToRectangleSet
         ' 
         Me._miActionZoomToRectangleSet.Name = "_miActionZoomToRectangleSet"
         Me._miActionZoomToRectangleSet.Size = New System.Drawing.Size(99, 22)
         Me._miActionZoomToRectangleSet.Text = "&Set..."
         ' 
         ' _miActionClickZoomIn
         ' 
         Me._miActionClickZoomIn.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miActionClickZoomInSet})
         Me._miActionClickZoomIn.Name = "_miActionClickZoomIn"
         Me._miActionClickZoomIn.Size = New System.Drawing.Size(178, 22)
         Me._miActionClickZoomIn.Text = "Click Zoom In"
         ' 
         ' _miActionClickZoomInSet
         ' 
         Me._miActionClickZoomInSet.Name = "_miActionClickZoomInSet"
         Me._miActionClickZoomInSet.Size = New System.Drawing.Size(99, 22)
         Me._miActionClickZoomInSet.Text = "&Set..."
         ' 
         ' _miActionClickZoomOut
         ' 
         Me._miActionClickZoomOut.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miActionClickZoomOutSet})
         Me._miActionClickZoomOut.Name = "_miActionClickZoomOut"
         Me._miActionClickZoomOut.Size = New System.Drawing.Size(178, 22)
         Me._miActionClickZoomOut.Text = "Click Zoom Out"
         ' 
         ' _miActionClickZoomOutSet
         ' 
         Me._miActionClickZoomOutSet.Name = "_miActionClickZoomOutSet"
         Me._miActionClickZoomOutSet.Size = New System.Drawing.Size(99, 22)
         Me._miActionClickZoomOutSet.Text = "&Set..."
         ' 
         ' _miActionCobbAngle
         ' 
         Me._miActionCobbAngle.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miActionCobbAngleSet})
         Me._miActionCobbAngle.Name = "_miActionCobbAngle"
         Me._miActionCobbAngle.Size = New System.Drawing.Size(178, 22)
         Me._miActionCobbAngle.Text = "&Cobb Angle"
         ' 
         ' _miActionCobbAngleSet
         ' 
         Me._miActionCobbAngleSet.Name = "_miActionCobbAngleSet"
         Me._miActionCobbAngleSet.Size = New System.Drawing.Size(99, 22)
         Me._miActionCobbAngleSet.Text = "&Set..."
         ' 
         ' _regionMenuItem
         ' 
         Me._regionMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.loadRegionsToolStripMenuItem, Me.saveRegionsToolStripMenuItem, Me._miStatisticsStatistics, Me.toolStripSeparator1, Me._miRegionRectangle, Me._miRegionEllipse, Me._miRegionSquare, Me._miRegionCircle, Me._miRegionPolygon, Me._miRegionFreeHand, Me._miRegionMagicWand, Me._miRegionColorRange, Me.nudgeToolToolStripMenuItem})
         Me._regionMenuItem.Name = "_regionMenuItem"
         Me._regionMenuItem.Size = New System.Drawing.Size(56, 20)
         Me._regionMenuItem.Text = "&Region"
         ' 
         ' loadRegionsToolStripMenuItem
         ' 
         Me.loadRegionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.selectedCellsToolStripMenuItem3, Me.allCellsToolStripMenuItem2})
         Me.loadRegionsToolStripMenuItem.Name = "loadRegionsToolStripMenuItem"
         Me.loadRegionsToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
         Me.loadRegionsToolStripMenuItem.Text = "&Load Regions"
         ' 
         ' selectedCellsToolStripMenuItem3
         ' 
         Me.selectedCellsToolStripMenuItem3.Name = "selectedCellsToolStripMenuItem3"
         Me.selectedCellsToolStripMenuItem3.Size = New System.Drawing.Size(155, 22)
         Me.selectedCellsToolStripMenuItem3.Text = "&Selected Cells..."
         ' 
         ' allCellsToolStripMenuItem2
         ' 
         Me.allCellsToolStripMenuItem2.Name = "allCellsToolStripMenuItem2"
         Me.allCellsToolStripMenuItem2.Size = New System.Drawing.Size(155, 22)
         Me.allCellsToolStripMenuItem2.Text = "&All Cells..."
         ' 
         ' saveRegionsToolStripMenuItem
         ' 
         Me.saveRegionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.selectedCellsToolStripMenuItem2, Me.allCellsToolStripMenuItem1})
         Me.saveRegionsToolStripMenuItem.Name = "saveRegionsToolStripMenuItem"
         Me.saveRegionsToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
         Me.saveRegionsToolStripMenuItem.Text = "&Save Regions"
         ' 
         ' selectedCellsToolStripMenuItem2
         ' 
         Me.selectedCellsToolStripMenuItem2.Name = "selectedCellsToolStripMenuItem2"
         Me.selectedCellsToolStripMenuItem2.Size = New System.Drawing.Size(155, 22)
         Me.selectedCellsToolStripMenuItem2.Text = "&Selected Cells..."
         ' 
         ' allCellsToolStripMenuItem1
         ' 
         Me.allCellsToolStripMenuItem1.Name = "allCellsToolStripMenuItem1"
         Me.allCellsToolStripMenuItem1.Size = New System.Drawing.Size(155, 22)
         Me.allCellsToolStripMenuItem1.Text = "&All Cells..."
         ' 
         ' _miStatisticsStatistics
         ' 
         Me._miStatisticsStatistics.Name = "_miStatisticsStatistics"
         Me._miStatisticsStatistics.Size = New System.Drawing.Size(169, 22)
         Me._miStatisticsStatistics.Text = "Region &Statistics..."
         ' 
         ' toolStripSeparator1
         ' 
         Me.toolStripSeparator1.Name = "toolStripSeparator1"
         Me.toolStripSeparator1.Size = New System.Drawing.Size(166, 6)
         ' 
         ' _miRegionRectangle
         ' 
         Me._miRegionRectangle.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miRegionRectangleSet})
         Me._miRegionRectangle.Name = "_miRegionRectangle"
         Me._miRegionRectangle.Size = New System.Drawing.Size(169, 22)
         Me._miRegionRectangle.Text = "&Rectangle"
         ' 
         ' _miRegionRectangleSet
         ' 
         Me._miRegionRectangleSet.Name = "_miRegionRectangleSet"
         Me._miRegionRectangleSet.Size = New System.Drawing.Size(99, 22)
         Me._miRegionRectangleSet.Text = "&Set..."
         ' 
         ' _miRegionEllipse
         ' 
         Me._miRegionEllipse.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miRegionEllipseSet})
         Me._miRegionEllipse.Name = "_miRegionEllipse"
         Me._miRegionEllipse.Size = New System.Drawing.Size(169, 22)
         Me._miRegionEllipse.Text = "&Ellipse"
         ' 
         ' _miRegionEllipseSet
         ' 
         Me._miRegionEllipseSet.Name = "_miRegionEllipseSet"
         Me._miRegionEllipseSet.Size = New System.Drawing.Size(99, 22)
         Me._miRegionEllipseSet.Text = "&Set..."
         ' 
         ' _miRegionSquare
         ' 
         Me._miRegionSquare.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miRegionSquareSet})
         Me._miRegionSquare.Name = "_miRegionSquare"
         Me._miRegionSquare.Size = New System.Drawing.Size(169, 22)
         Me._miRegionSquare.Text = "&Square"
         ' 
         ' _miRegionSquareSet
         ' 
         Me._miRegionSquareSet.Name = "_miRegionSquareSet"
         Me._miRegionSquareSet.Size = New System.Drawing.Size(99, 22)
         Me._miRegionSquareSet.Text = "&Set..."
         ' 
         ' _miRegionCircle
         ' 
         Me._miRegionCircle.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miRegionCircleSet})
         Me._miRegionCircle.Name = "_miRegionCircle"
         Me._miRegionCircle.Size = New System.Drawing.Size(169, 22)
         Me._miRegionCircle.Text = "&Circle"
         ' 
         ' _miRegionCircleSet
         ' 
         Me._miRegionCircleSet.Name = "_miRegionCircleSet"
         Me._miRegionCircleSet.Size = New System.Drawing.Size(99, 22)
         Me._miRegionCircleSet.Text = "&Set..."
         ' 
         ' _miRegionPolygon
         ' 
         Me._miRegionPolygon.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miRegionPolygonSet})
         Me._miRegionPolygon.Name = "_miRegionPolygon"
         Me._miRegionPolygon.Size = New System.Drawing.Size(169, 22)
         Me._miRegionPolygon.Text = "&Polygon"
         ' 
         ' _miRegionPolygonSet
         ' 
         Me._miRegionPolygonSet.Name = "_miRegionPolygonSet"
         Me._miRegionPolygonSet.Size = New System.Drawing.Size(99, 22)
         Me._miRegionPolygonSet.Text = "&Set..."
         ' 
         ' _miRegionFreeHand
         ' 
         Me._miRegionFreeHand.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miRegionFreeHandSet})
         Me._miRegionFreeHand.Name = "_miRegionFreeHand"
         Me._miRegionFreeHand.Size = New System.Drawing.Size(169, 22)
         Me._miRegionFreeHand.Text = "&Free Hand"
         ' 
         ' _miRegionFreeHandSet
         ' 
         Me._miRegionFreeHandSet.Name = "_miRegionFreeHandSet"
         Me._miRegionFreeHandSet.Size = New System.Drawing.Size(99, 22)
         Me._miRegionFreeHandSet.Text = "&Set..."
         ' 
         ' _miRegionMagicWand
         ' 
         Me._miRegionMagicWand.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miRegionMagicWandSet})
         Me._miRegionMagicWand.Name = "_miRegionMagicWand"
         Me._miRegionMagicWand.Size = New System.Drawing.Size(169, 22)
         Me._miRegionMagicWand.Text = "&Magic Wand"
         ' 
         ' _miRegionMagicWandSet
         ' 
         Me._miRegionMagicWandSet.Name = "_miRegionMagicWandSet"
         Me._miRegionMagicWandSet.Size = New System.Drawing.Size(99, 22)
         Me._miRegionMagicWandSet.Text = "&Set..."
         ' 
         ' _miRegionColorRange
         ' 
         Me._miRegionColorRange.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miRegionColorRangeSet})
         Me._miRegionColorRange.Name = "_miRegionColorRange"
         Me._miRegionColorRange.Size = New System.Drawing.Size(169, 22)
         Me._miRegionColorRange.Text = "&Color Range"
         ' 
         ' _miRegionColorRangeSet
         ' 
         Me._miRegionColorRangeSet.Name = "_miRegionColorRangeSet"
         Me._miRegionColorRangeSet.Size = New System.Drawing.Size(99, 22)
         Me._miRegionColorRangeSet.Text = "&Set..."
         ' 
         ' nudgeToolToolStripMenuItem
         ' 
         Me.nudgeToolToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.setToolStripMenuItem, Me.customizeToolStripMenuItem})
         Me.nudgeToolToolStripMenuItem.Name = "nudgeToolToolStripMenuItem"
         Me.nudgeToolToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
         Me.nudgeToolToolStripMenuItem.Text = "&Nudge tool"
         ' 
         ' setToolStripMenuItem
         ' 
         Me.setToolStripMenuItem.Name = "setToolStripMenuItem"
         Me.setToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
         Me.setToolStripMenuItem.Text = "&Set.."
         ' 
         ' customizeToolStripMenuItem
         ' 
         Me.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem"
         Me.customizeToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
         Me.customizeToolStripMenuItem.Text = "&Customize..."
         ' 
         ' _annotationMenuItem
         ' 
         Me._annotationMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.loadAnnotationsToolStripMenuItem, Me.saveAnnotationsToolStripMenuItem, Me._miEditAnnotation, Me.toolStripSeparator2, Me._miAnnotationRectangle, Me._miAnnotationEllipse, Me._miAnnotationArrow, Me._miAnnotationText, Me._miAnnotationAngle, Me._miAnnotationHilite, Me._miAnnotationRuler})
         Me._annotationMenuItem.Name = "_annotationMenuItem"
         Me._annotationMenuItem.Size = New System.Drawing.Size(79, 20)
         Me._annotationMenuItem.Text = "A&nnotation"
         ' 
         ' loadAnnotationsToolStripMenuItem
         ' 
         Me.loadAnnotationsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.selectedCellsToolStripMenuItem1, Me.allCellToolStripMenuItem})
         Me.loadAnnotationsToolStripMenuItem.Name = "loadAnnotationsToolStripMenuItem"
         Me.loadAnnotationsToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
         Me.loadAnnotationsToolStripMenuItem.Text = "&Load annotations "
         ' 
         ' selectedCellsToolStripMenuItem1
         ' 
         Me.selectedCellsToolStripMenuItem1.Name = "selectedCellsToolStripMenuItem1"
         Me.selectedCellsToolStripMenuItem1.Size = New System.Drawing.Size(155, 22)
         Me.selectedCellsToolStripMenuItem1.Text = "&Selected Cells..."
         ' 
         ' allCellToolStripMenuItem
         ' 
         Me.allCellToolStripMenuItem.Name = "allCellToolStripMenuItem"
         Me.allCellToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
         Me.allCellToolStripMenuItem.Text = "&All Cells..."
         ' 
         ' saveAnnotationsToolStripMenuItem
         ' 
         Me.saveAnnotationsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.selectedCellsToolStripMenuItem, Me.allCellsToolStripMenuItem})
         Me.saveAnnotationsToolStripMenuItem.Name = "saveAnnotationsToolStripMenuItem"
         Me.saveAnnotationsToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
         Me.saveAnnotationsToolStripMenuItem.Text = "&Save Annotations"
         ' 
         ' selectedCellsToolStripMenuItem
         ' 
         Me.selectedCellsToolStripMenuItem.Name = "selectedCellsToolStripMenuItem"
         Me.selectedCellsToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
         Me.selectedCellsToolStripMenuItem.Text = "&Selected Cells..."
         ' 
         ' allCellsToolStripMenuItem
         ' 
         Me.allCellsToolStripMenuItem.Name = "allCellsToolStripMenuItem"
         Me.allCellsToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
         Me.allCellsToolStripMenuItem.Text = "&All Cells..."
         ' 
         ' _miEditAnnotation
         ' 
         Me._miEditAnnotation.Name = "_miEditAnnotation"
         Me._miEditAnnotation.Size = New System.Drawing.Size(213, 22)
         Me._miEditAnnotation.Text = "E&dit Selected Annotation..."
         ' 
         ' toolStripSeparator2
         ' 
         Me.toolStripSeparator2.Name = "toolStripSeparator2"
         Me.toolStripSeparator2.Size = New System.Drawing.Size(210, 6)
         ' 
         ' _miAnnotationRectangle
         ' 
         Me._miAnnotationRectangle.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miAnnotationRectangleSet, Me._miAnnotationRectangleCustomizeRectangle})
         Me._miAnnotationRectangle.Name = "_miAnnotationRectangle"
         Me._miAnnotationRectangle.Size = New System.Drawing.Size(213, 22)
         Me._miAnnotationRectangle.Text = "&Rectangle"
         ' 
         ' _miAnnotationRectangleSet
         ' 
         Me._miAnnotationRectangleSet.Name = "_miAnnotationRectangleSet"
         Me._miAnnotationRectangleSet.Size = New System.Drawing.Size(194, 22)
         Me._miAnnotationRectangleSet.Text = "&Set..."
         ' 
         ' _miAnnotationRectangleCustomizeRectangle
         ' 
         Me._miAnnotationRectangleCustomizeRectangle.Name = "_miAnnotationRectangleCustomizeRectangle"
         Me._miAnnotationRectangleCustomizeRectangle.Size = New System.Drawing.Size(194, 22)
         Me._miAnnotationRectangleCustomizeRectangle.Text = "&Customize Rectangle..."
         ' 
         ' _miAnnotationEllipse
         ' 
         Me._miAnnotationEllipse.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miAnnotationEllipseSet, Me._miAnnotationEllipseCustomizeEllipse})
         Me._miAnnotationEllipse.Name = "_miAnnotationEllipse"
         Me._miAnnotationEllipse.Size = New System.Drawing.Size(213, 22)
         Me._miAnnotationEllipse.Text = "&Ellipse"
         ' 
         ' _miAnnotationEllipseSet
         ' 
         Me._miAnnotationEllipseSet.Name = "_miAnnotationEllipseSet"
         Me._miAnnotationEllipseSet.Size = New System.Drawing.Size(175, 22)
         Me._miAnnotationEllipseSet.Text = "&Set..."
         ' 
         ' _miAnnotationEllipseCustomizeEllipse
         ' 
         Me._miAnnotationEllipseCustomizeEllipse.Name = "_miAnnotationEllipseCustomizeEllipse"
         Me._miAnnotationEllipseCustomizeEllipse.Size = New System.Drawing.Size(175, 22)
         Me._miAnnotationEllipseCustomizeEllipse.Text = "&Customize Ellipse..."
         ' 
         ' _miAnnotationArrow
         ' 
         Me._miAnnotationArrow.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miAnnotationArrowSet, Me._miAnnotationArrowCustomizeArrow})
         Me._miAnnotationArrow.Name = "_miAnnotationArrow"
         Me._miAnnotationArrow.Size = New System.Drawing.Size(213, 22)
         Me._miAnnotationArrow.Text = "&Arrow"
         ' 
         ' _miAnnotationArrowSet
         ' 
         Me._miAnnotationArrowSet.Name = "_miAnnotationArrowSet"
         Me._miAnnotationArrowSet.Size = New System.Drawing.Size(174, 22)
         Me._miAnnotationArrowSet.Text = "&Set..."
         ' 
         ' _miAnnotationArrowCustomizeArrow
         ' 
         Me._miAnnotationArrowCustomizeArrow.Name = "_miAnnotationArrowCustomizeArrow"
         Me._miAnnotationArrowCustomizeArrow.Size = New System.Drawing.Size(174, 22)
         Me._miAnnotationArrowCustomizeArrow.Text = "&Customize Arrow..."
         ' 
         ' _miAnnotationText
         ' 
         Me._miAnnotationText.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miAnnotationTextSet, Me._miAnnotationTextCustomizeText})
         Me._miAnnotationText.Name = "_miAnnotationText"
         Me._miAnnotationText.Size = New System.Drawing.Size(213, 22)
         Me._miAnnotationText.Text = "&Text"
         ' 
         ' _miAnnotationTextSet
         ' 
         Me._miAnnotationTextSet.Name = "_miAnnotationTextSet"
         Me._miAnnotationTextSet.Size = New System.Drawing.Size(164, 22)
         Me._miAnnotationTextSet.Text = "&Set..."
         ' 
         ' _miAnnotationTextCustomizeText
         ' 
         Me._miAnnotationTextCustomizeText.Name = "_miAnnotationTextCustomizeText"
         Me._miAnnotationTextCustomizeText.Size = New System.Drawing.Size(164, 22)
         Me._miAnnotationTextCustomizeText.Text = "&Customize Text..."
         ' 
         ' _miAnnotationAngle
         ' 
         Me._miAnnotationAngle.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miAnnotationAngleSet, Me._miAnnotationAngleCustomizeAngle})
         Me._miAnnotationAngle.Name = "_miAnnotationAngle"
         Me._miAnnotationAngle.Size = New System.Drawing.Size(213, 22)
         Me._miAnnotationAngle.Text = "&Angle"
         ' 
         ' _miAnnotationAngleSet
         ' 
         Me._miAnnotationAngleSet.Name = "_miAnnotationAngleSet"
         Me._miAnnotationAngleSet.Size = New System.Drawing.Size(173, 22)
         Me._miAnnotationAngleSet.Text = "&Set..."
         ' 
         ' _miAnnotationAngleCustomizeAngle
         ' 
         Me._miAnnotationAngleCustomizeAngle.Name = "_miAnnotationAngleCustomizeAngle"
         Me._miAnnotationAngleCustomizeAngle.Size = New System.Drawing.Size(173, 22)
         Me._miAnnotationAngleCustomizeAngle.Text = "&Customize Angle..."
         ' 
         ' _miAnnotationHilite
         ' 
         Me._miAnnotationHilite.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miAnnotationHiliteSet, Me._miAnnotationHiliteCustomizeHilite})
         Me._miAnnotationHilite.Name = "_miAnnotationHilite"
         Me._miAnnotationHilite.Size = New System.Drawing.Size(213, 22)
         Me._miAnnotationHilite.Text = "&Hilite"
         ' 
         ' _miAnnotationHiliteSet
         ' 
         Me._miAnnotationHiliteSet.Name = "_miAnnotationHiliteSet"
         Me._miAnnotationHiliteSet.Size = New System.Drawing.Size(170, 22)
         Me._miAnnotationHiliteSet.Text = "&Set..."
         ' 
         ' _miAnnotationHiliteCustomizeHilite
         ' 
         Me._miAnnotationHiliteCustomizeHilite.Name = "_miAnnotationHiliteCustomizeHilite"
         Me._miAnnotationHiliteCustomizeHilite.Size = New System.Drawing.Size(170, 22)
         Me._miAnnotationHiliteCustomizeHilite.Text = "Customize Hilite..."
         ' 
         ' _miAnnotationRuler
         ' 
         Me._miAnnotationRuler.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miAnnotationRulerSet, Me._miAnnotationRulerCustomizeRuler})
         Me._miAnnotationRuler.Name = "_miAnnotationRuler"
         Me._miAnnotationRuler.Size = New System.Drawing.Size(213, 22)
         Me._miAnnotationRuler.Text = "R&uler"
         ' 
         ' _miAnnotationRulerSet
         ' 
         Me._miAnnotationRulerSet.Name = "_miAnnotationRulerSet"
         Me._miAnnotationRulerSet.Size = New System.Drawing.Size(169, 22)
         Me._miAnnotationRulerSet.Text = "&Set..."
         ' 
         ' _miAnnotationRulerCustomizeRuler
         ' 
         Me._miAnnotationRulerCustomizeRuler.Name = "_miAnnotationRulerCustomizeRuler"
         Me._miAnnotationRulerCustomizeRuler.Size = New System.Drawing.Size(169, 22)
         Me._miAnnotationRulerCustomizeRuler.Text = "&Customize Ruler..."
         ' 
         ' _transformMenuItem
         ' 
         Me._transformMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miEffectReverse, Me._miEffectFlip, Me._miRotate, Me.sToolStripMenuItem4, Me._miEffectOptions})
         Me._transformMenuItem.Name = "_transformMenuItem"
         Me._transformMenuItem.Size = New System.Drawing.Size(74, 20)
         Me._transformMenuItem.Text = "&Transform"
         ' 
         ' _miEffectReverse
         ' 
         Me._miEffectReverse.Name = "_miEffectReverse"
         Me._miEffectReverse.Size = New System.Drawing.Size(116, 22)
         Me._miEffectReverse.Text = "&Reverse"
         ' 
         ' _miEffectFlip
         ' 
         Me._miEffectFlip.Name = "_miEffectFlip"
         Me._miEffectFlip.Size = New System.Drawing.Size(116, 22)
         Me._miEffectFlip.Text = "&Flip"
         ' 
         ' _miRotate
         ' 
         Me._miRotate.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miRotate90, Me._miRotate180, Me._miRotateMinus90, Me._miRotateMinus180})
         Me._miRotate.Name = "_miRotate"
         Me._miRotate.Size = New System.Drawing.Size(116, 22)
         Me._miRotate.Text = "Rotate"
         ' 
         ' _miRotate90
         ' 
         Me._miRotate90.Name = "_miRotate90"
         Me._miRotate90.Size = New System.Drawing.Size(105, 22)
         Me._miRotate90.Text = "+90°"
         ' 
         ' _miRotate180
         ' 
         Me._miRotate180.Name = "_miRotate180"
         Me._miRotate180.Size = New System.Drawing.Size(105, 22)
         Me._miRotate180.Text = "+180°"
         ' 
         ' _miRotateMinus90
         ' 
         Me._miRotateMinus90.Name = "_miRotateMinus90"
         Me._miRotateMinus90.Size = New System.Drawing.Size(105, 22)
         Me._miRotateMinus90.Text = "-90°"
         ' 
         ' _miRotateMinus180
         ' 
         Me._miRotateMinus180.Name = "_miRotateMinus180"
         Me._miRotateMinus180.Size = New System.Drawing.Size(105, 22)
         Me._miRotateMinus180.Text = "-180°"
         ' 
         ' sToolStripMenuItem4
         ' 
         Me.sToolStripMenuItem4.Name = "sToolStripMenuItem4"
         Me.sToolStripMenuItem4.Size = New System.Drawing.Size(113, 6)
         ' 
         ' _miEffectOptions
         ' 
         Me._miEffectOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miEffectOptionsApplyToAllSubCells})
         Me._miEffectOptions.Name = "_miEffectOptions"
         Me._miEffectOptions.Size = New System.Drawing.Size(116, 22)
         Me._miEffectOptions.Text = "&Options"
         ' 
         ' _miEffectOptionsApplyToAllSubCells
         ' 
         Me._miEffectOptionsApplyToAllSubCells.Checked = True
         Me._miEffectOptionsApplyToAllSubCells.CheckState = System.Windows.Forms.CheckState.Checked
         Me._miEffectOptionsApplyToAllSubCells.Name = "_miEffectOptionsApplyToAllSubCells"
         Me._miEffectOptionsApplyToAllSubCells.Size = New System.Drawing.Size(185, 22)
         Me._miEffectOptionsApplyToAllSubCells.Text = "&Apply to all Sub-cells"
         ' 
         ' _stentMenuItem
         ' 
         Me._stentMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._stentEnhancementMenuItem, Me._unselectFramesMenuItem, Me._moveMarkersAction})
         Me._stentMenuItem.Name = "_stentMenuItem"
         Me._stentMenuItem.Size = New System.Drawing.Size(46, 20)
         Me._stentMenuItem.Text = "&Stent"
         ' 
         ' _stentEnhancementMenuItem
         ' 
         Me._stentEnhancementMenuItem.Name = "_stentEnhancementMenuItem"
         Me._stentEnhancementMenuItem.Size = New System.Drawing.Size(187, 22)
         Me._stentEnhancementMenuItem.Text = "&Stent Enhancement..."
         ' 
         ' _unselectFramesMenuItem
         ' 
         Me._unselectFramesMenuItem.Name = "_unselectFramesMenuItem"
         Me._unselectFramesMenuItem.Size = New System.Drawing.Size(187, 22)
         Me._unselectFramesMenuItem.Text = "&Unselect Frames..."
         ' 
         ' _moveMarkersAction
         ' 
         Me._moveMarkersAction.Name = "_moveMarkersAction"
         Me._moveMarkersAction.Size = New System.Drawing.Size(187, 22)
         Me._moveMarkersAction.Text = "&Move Markers Action"
         ' 
         ' _filtersMenuItem
         ' 
         Me._filtersMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.multiscaleEnhancementToolStripMenuItem, Me.adaptiveContrastToolStripMenuItem, Me.unsharpMaskToolStripMenuItem, Me.histogramEqualizeToolStripMenuItem, Me._miEffectCLAHE, Me._miEffectInvert, Me.toolStripSeparator3, Me.resetToolStripMenuItem})
         Me._filtersMenuItem.Name = "_filtersMenuItem"
         Me._filtersMenuItem.Size = New System.Drawing.Size(50, 20)
         Me._filtersMenuItem.Text = "&Filters"
         ' 
         ' multiscaleEnhancementToolStripMenuItem
         ' 
         Me.multiscaleEnhancementToolStripMenuItem.Name = "multiscaleEnhancementToolStripMenuItem"
         Me.multiscaleEnhancementToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
         Me.multiscaleEnhancementToolStripMenuItem.Text = "&Multiscale Enhancement..."
         ' 
         ' adaptiveContrastToolStripMenuItem
         ' 
         Me.adaptiveContrastToolStripMenuItem.Name = "adaptiveContrastToolStripMenuItem"
         Me.adaptiveContrastToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
         Me.adaptiveContrastToolStripMenuItem.Text = "&Adaptive Contrast..."
         ' 
         ' unsharpMaskToolStripMenuItem
         ' 
         Me.unsharpMaskToolStripMenuItem.Name = "unsharpMaskToolStripMenuItem"
         Me.unsharpMaskToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
         Me.unsharpMaskToolStripMenuItem.Text = "&Unsharp Mask..."
         ' 
         ' histogramEqualizeToolStripMenuItem
         ' 
         Me.histogramEqualizeToolStripMenuItem.Name = "histogramEqualizeToolStripMenuItem"
         Me.histogramEqualizeToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
         Me.histogramEqualizeToolStripMenuItem.Text = "&Histogram Equalize..."
         ' 
         ' _miEffectCLAHE
         ' 
         Me._miEffectCLAHE.Name = "_miEffectCLAHE"
         Me._miEffectCLAHE.Size = New System.Drawing.Size(207, 22)
         Me._miEffectCLAHE.Text = "&CLAHE..."
         ' 
         ' _miEffectInvert
         ' 
         Me._miEffectInvert.Name = "_miEffectInvert"
         Me._miEffectInvert.Size = New System.Drawing.Size(207, 22)
         Me._miEffectInvert.Text = "&Invert"
         ' 
         ' toolStripSeparator3
         ' 
         Me.toolStripSeparator3.Name = "toolStripSeparator3"
         Me.toolStripSeparator3.Size = New System.Drawing.Size(204, 6)
         ' 
         ' resetToolStripMenuItem
         ' 
         Me.resetToolStripMenuItem.Name = "resetToolStripMenuItem"
         Me.resetToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
         Me.resetToolStripMenuItem.Text = "&Reset"
         ' 
         ' _alignmentMenuItem
         ' 
         Me._alignmentMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.imageAlignmentToolStripMenuItem, Me._selectPointsActionMenuItem})
         Me._alignmentMenuItem.Name = "_alignmentMenuItem"
         Me._alignmentMenuItem.Size = New System.Drawing.Size(75, 20)
         Me._alignmentMenuItem.Text = "Alignment"
         ' 
         ' imageAlignmentToolStripMenuItem
         ' 
         Me.imageAlignmentToolStripMenuItem.Name = "imageAlignmentToolStripMenuItem"
         Me.imageAlignmentToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
         Me.imageAlignmentToolStripMenuItem.Text = "Image Alignment..."
         ' 
         ' _selectPointsActionMenuItem
         ' 
         Me._selectPointsActionMenuItem.Name = "_selectPointsActionMenuItem"
         Me._selectPointsActionMenuItem.Size = New System.Drawing.Size(179, 22)
         Me._selectPointsActionMenuItem.Text = "Select Points Action"
         ' 
         ' _helpMenuItem
         ' 
         Me._helpMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miHelpAbout})
         Me._helpMenuItem.Name = "_helpMenuItem"
         Me._helpMenuItem.Size = New System.Drawing.Size(44, 20)
         Me._helpMenuItem.Text = "&Help"
         ' 
         ' _miHelpAbout
         ' 
         Me._miHelpAbout.Name = "_miHelpAbout"
         Me._miHelpAbout.Size = New System.Drawing.Size(116, 22)
         Me._miHelpAbout.Text = "&About..."
         ' 
         ' _mainPanel
         ' 
         Me._mainPanel.Dock = System.Windows.Forms.DockStyle.Fill
         Me._mainPanel.Location = New System.Drawing.Point(0, 24)
         Me._mainPanel.Name = "_mainPanel"
         Me._mainPanel.Size = New System.Drawing.Size(772, 416)
         Me._mainPanel.TabIndex = 2
         ' 
         ' MainForm
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(772, 440)
         Me.Controls.Add(Me._mainPanel)
         Me.Controls.Add(Me._mainMenu)
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.MainMenuStrip = Me._mainMenu
         Me.Name = "MainForm"
         Me.Text = "Medical Viewer Demo"
         Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
         Me._mainMenu.ResumeLayout(False)
         Me._mainMenu.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub


#End Region

      Private _mainMenu As System.Windows.Forms.MenuStrip
      Private WithEvents _fileMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _propertiesMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _actionsMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _regionMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _annotationMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _helpMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _fileMenuItem_insertCell As System.Windows.Forms.ToolStripMenuItem
      Private sToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _fileMenuItem_exit As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miPropertiesViewerProperties As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miPropertiesCellProperties As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miHelpAbout As System.Windows.Forms.ToolStripMenuItem
      Private _miRegionRectangle As System.Windows.Forms.ToolStripMenuItem
      Private _miRegionEllipse As System.Windows.Forms.ToolStripMenuItem
      Private _miRegionSquare As System.Windows.Forms.ToolStripMenuItem
      Private _miRegionCircle As System.Windows.Forms.ToolStripMenuItem
      Private _miRegionPolygon As System.Windows.Forms.ToolStripMenuItem
      Private _miRegionFreeHand As System.Windows.Forms.ToolStripMenuItem
      Private _miRegionMagicWand As System.Windows.Forms.ToolStripMenuItem
      Private _miRegionColorRange As System.Windows.Forms.ToolStripMenuItem
      Private _miAnnotationRectangle As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miAnnotationRectangleSet As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miAnnotationRectangleCustomizeRectangle As System.Windows.Forms.ToolStripMenuItem
      Private _miAnnotationEllipse As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miAnnotationEllipseSet As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miAnnotationEllipseCustomizeEllipse As System.Windows.Forms.ToolStripMenuItem
      Private _miAnnotationArrow As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miAnnotationArrowSet As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miAnnotationArrowCustomizeArrow As System.Windows.Forms.ToolStripMenuItem
      Private _miAnnotationText As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miAnnotationTextSet As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miAnnotationTextCustomizeText As System.Windows.Forms.ToolStripMenuItem
      Private _miAnnotationAngle As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miAnnotationAngleSet As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miAnnotationAngleCustomizeAngle As System.Windows.Forms.ToolStripMenuItem
      Private _miAnnotationHilite As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miAnnotationHiliteSet As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miAnnotationHiliteCustomizeHilite As System.Windows.Forms.ToolStripMenuItem
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
      Private WithEvents _miRegionRectangleSet As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miRegionEllipseSet As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miRegionSquareSet As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miRegionCircleSet As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miRegionPolygonSet As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miRegionFreeHandSet As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miRegionMagicWandSet As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miRegionColorRangeSet As System.Windows.Forms.ToolStripMenuItem
      Private _mainPanel As System.Windows.Forms.Panel
      Private _miAnnotationRuler As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miAnnotationRulerSet As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miAnnotationRulerCustomizeRuler As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _transformMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miEffectReverse As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miEffectFlip As System.Windows.Forms.ToolStripMenuItem
      Private sToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
      Private _miEffectOptions As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miEffectOptionsApplyToAllSubCells As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _printCellMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private nudgeToolToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents setToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents customizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents saveRegionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents selectedCellsToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents allCellsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents loadRegionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents selectedCellsToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents allCellsToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents saveAnnotationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents selectedCellsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents allCellsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents loadAnnotationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents selectedCellsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents allCellToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
      Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
      Private _miSpyGlass As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miSpyGlassSet As System.Windows.Forms.ToolStripMenuItem
      Private _miActionsProbeTool As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miActionsProbeToolSet As System.Windows.Forms.ToolStripMenuItem
      Private _miActionZoomToRectangle As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miActionZoomToRectangleSet As System.Windows.Forms.ToolStripMenuItem
      Private _miActionClickZoomIn As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miActionClickZoomInSet As System.Windows.Forms.ToolStripMenuItem
      Private _miActionClickZoomOut As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miActionClickZoomOutSet As System.Windows.Forms.ToolStripMenuItem
      Private _miActionCobbAngle As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miActionCobbAngleSet As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _editMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miEditFreezeCell As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miEditToggleFreeze As System.Windows.Forms.ToolStripMenuItem
      Private sToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _miEditSelectAll As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miEditInvertSelection As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miEditDeselectAll As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miEditRepositionCell As System.Windows.Forms.ToolStripMenuItem
      Private sToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _miEditRemoveCell As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miEditRemoveSelectedCells As System.Windows.Forms.ToolStripMenuItem
      Private sToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _miEditAnimation As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miEditCalibrateRuler As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miEditConvertAnnotationToRegion As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _stentMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _stentEnhancementMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _unselectFramesMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _filtersMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents multiscaleEnhancementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents adaptiveContrastToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents unsharpMaskToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents histogramEqualizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _moveMarkersAction As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _alignmentMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents imageAlignmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _selectPointsActionMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents resetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents saveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _miEffectCLAHE As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miStatisticsStatistics As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miEffectInvert As System.Windows.Forms.ToolStripMenuItem
      Private _miRotate As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miRotate90 As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miRotate180 As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miRotateMinus90 As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miRotateMinus180 As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _miEditAnnotation As System.Windows.Forms.ToolStripMenuItem
   End Class
End Namespace

