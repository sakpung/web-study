namespace MedicalViewerDemo
{
   partial class MainForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this._mainMenu = new System.Windows.Forms.MenuStrip();
         this._fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._fileMenuItem_insertCell = new System.Windows.Forms.ToolStripMenuItem();
         this._printCellMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.sToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._fileMenuItem_exit = new System.Windows.Forms.ToolStripMenuItem();
         this._editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._miEditFreezeCell = new System.Windows.Forms.ToolStripMenuItem();
         this._miEditToggleFreeze = new System.Windows.Forms.ToolStripMenuItem();
         this.sToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
         this._miEditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
         this._miEditInvertSelection = new System.Windows.Forms.ToolStripMenuItem();
         this._miEditDeselectAll = new System.Windows.Forms.ToolStripMenuItem();
         this._miEditRepositionCell = new System.Windows.Forms.ToolStripMenuItem();
         this.sToolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
         this._miEditRemoveCell = new System.Windows.Forms.ToolStripMenuItem();
         this._miEditRemoveSelectedCells = new System.Windows.Forms.ToolStripMenuItem();
         this.sToolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
         this._miEditAnimation = new System.Windows.Forms.ToolStripMenuItem();
         this._miEditCalibrateRuler = new System.Windows.Forms.ToolStripMenuItem();
         this._miEditConvertAnnotationToRegion = new System.Windows.Forms.ToolStripMenuItem();
         this._propertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._miPropertiesViewerProperties = new System.Windows.Forms.ToolStripMenuItem();
         this._miPropertiesCellProperties = new System.Windows.Forms.ToolStripMenuItem();
         this._actionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionWindowLevel = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionWindowLevelSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionWindowLevelCustomize = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionAlpha = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionAlphaSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionAlphaCustomizeAlpha = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionScale = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionScaleSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionScaleCustomizeScale = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionMagnify = new System.Windows.Forms.ToolStripMenuItem();
         this._miMagnifySet = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionMagnifyCustomizeMagnify = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionStack = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionStackSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionStackCustomizeStack = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionOffset = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionOffsetSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionOffsetCustomizeOffset = new System.Windows.Forms.ToolStripMenuItem();
         this._miSpyGlass = new System.Windows.Forms.ToolStripMenuItem();
         this._miSpyGlassSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionsProbeTool = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionsProbeToolSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionZoomToRectangle = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionZoomToRectangleSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionClickZoomIn = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionClickZoomInSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionClickZoomOut = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionClickZoomOutSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionCobbAngle = new System.Windows.Forms.ToolStripMenuItem();
         this._miActionCobbAngleSet = new System.Windows.Forms.ToolStripMenuItem();
         this._regionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.loadRegionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.selectedCellsToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
         this.allCellsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
         this.saveRegionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.selectedCellsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
         this.allCellsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
         this._miStatisticsStatistics = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this._miRegionRectangle = new System.Windows.Forms.ToolStripMenuItem();
         this._miRegionRectangleSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miRegionEllipse = new System.Windows.Forms.ToolStripMenuItem();
         this._miRegionEllipseSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miRegionSquare = new System.Windows.Forms.ToolStripMenuItem();
         this._miRegionSquareSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miRegionCircle = new System.Windows.Forms.ToolStripMenuItem();
         this._miRegionCircleSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miRegionPolygon = new System.Windows.Forms.ToolStripMenuItem();
         this._miRegionPolygonSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miRegionFreeHand = new System.Windows.Forms.ToolStripMenuItem();
         this._miRegionFreeHandSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miRegionMagicWand = new System.Windows.Forms.ToolStripMenuItem();
         this._miRegionMagicWandSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miRegionColorRange = new System.Windows.Forms.ToolStripMenuItem();
         this._miRegionColorRangeSet = new System.Windows.Forms.ToolStripMenuItem();
         this.nudgeToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.setToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._annotationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.loadAnnotationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.selectedCellsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
         this.allCellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.saveAnnotationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.selectedCellsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.allCellsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._miEditAnnotation = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this._miAnnotationRectangle = new System.Windows.Forms.ToolStripMenuItem();
         this._miAnnotationRectangleSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miAnnotationRectangleCustomizeRectangle = new System.Windows.Forms.ToolStripMenuItem();
         this._miAnnotationEllipse = new System.Windows.Forms.ToolStripMenuItem();
         this._miAnnotationEllipseSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miAnnotationEllipseCustomizeEllipse = new System.Windows.Forms.ToolStripMenuItem();
         this._miAnnotationArrow = new System.Windows.Forms.ToolStripMenuItem();
         this._miAnnotationArrowSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miAnnotationArrowCustomizeArrow = new System.Windows.Forms.ToolStripMenuItem();
         this._miAnnotationText = new System.Windows.Forms.ToolStripMenuItem();
         this._miAnnotationTextSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miAnnotationTextCustomizeText = new System.Windows.Forms.ToolStripMenuItem();
         this._miAnnotationAngle = new System.Windows.Forms.ToolStripMenuItem();
         this._miAnnotationAngleSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miAnnotationAngleCustomizeAngle = new System.Windows.Forms.ToolStripMenuItem();
         this._miAnnotationHilite = new System.Windows.Forms.ToolStripMenuItem();
         this._miAnnotationHiliteSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miAnnotationHiliteCustomizeHilite = new System.Windows.Forms.ToolStripMenuItem();
         this._miAnnotationRuler = new System.Windows.Forms.ToolStripMenuItem();
         this._miAnnotationRulerSet = new System.Windows.Forms.ToolStripMenuItem();
         this._miAnnotationRulerCustomizeRuler = new System.Windows.Forms.ToolStripMenuItem();
         this._transformMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._miEffectReverse = new System.Windows.Forms.ToolStripMenuItem();
         this._miEffectFlip = new System.Windows.Forms.ToolStripMenuItem();
         this._miRotate = new System.Windows.Forms.ToolStripMenuItem();
         this._miRotate90 = new System.Windows.Forms.ToolStripMenuItem();
         this._miRotate180 = new System.Windows.Forms.ToolStripMenuItem();
         this._miRotateMinus90 = new System.Windows.Forms.ToolStripMenuItem();
         this._miRotateMinus180 = new System.Windows.Forms.ToolStripMenuItem();
         this.sToolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
         this._miEffectOptions = new System.Windows.Forms.ToolStripMenuItem();
         this._miEffectOptionsApplyToAllSubCells = new System.Windows.Forms.ToolStripMenuItem();
         this._stentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._stentEnhancementMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._unselectFramesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._moveMarkersAction = new System.Windows.Forms.ToolStripMenuItem();
         this._filtersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.multiscaleEnhancementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.adaptiveContrastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.unsharpMaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.histogramEqualizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._miEffectCLAHE = new System.Windows.Forms.ToolStripMenuItem();
         this._miEffectInvert = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._alignmentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.imageAlignmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._selectPointsActionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._miHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
         this._mainPanel = new System.Windows.Forms.Panel();
         this._mainMenu.SuspendLayout();
         this.SuspendLayout();
         // 
         // _mainMenu
         // 
         this._mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileMenuItem,
            this._editMenuItem,
            this._propertiesMenuItem,
            this._actionsMenuItem,
            this._regionMenuItem,
            this._annotationMenuItem,
            this._transformMenuItem,
            this._stentMenuItem,
            this._filtersMenuItem,
            this._alignmentMenuItem,
            this._helpMenuItem});
         this._mainMenu.Location = new System.Drawing.Point(0, 0);
         this._mainMenu.Name = "_mainMenu";
         this._mainMenu.Size = new System.Drawing.Size(772, 24);
         this._mainMenu.TabIndex = 1;
         this._mainMenu.Text = "_mainMenu";
         // 
         // _fileMenuItem
         // 
         this._fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileMenuItem_insertCell,
            this._printCellMenuItem,
            this.saveToolStripMenuItem,
            this.sToolStripMenuItem,
            this._fileMenuItem_exit});
         this._fileMenuItem.Name = "_fileMenuItem";
         this._fileMenuItem.Size = new System.Drawing.Size(37, 20);
         this._fileMenuItem.Text = "&File";
         this._fileMenuItem.DropDownOpening += new System.EventHandler(this._fileMenuItem_DropDownOpening);
         // 
         // _fileMenuItem_insertCell
         // 
         this._fileMenuItem_insertCell.Name = "_fileMenuItem_insertCell";
         this._fileMenuItem_insertCell.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
         this._fileMenuItem_insertCell.Size = new System.Drawing.Size(178, 22);
         this._fileMenuItem_insertCell.Text = "&Insert Cell...";
         this._fileMenuItem_insertCell.Click += new System.EventHandler(this._fileMenuItem_insertCell_Click);
         // 
         // _printCellMenuItem
         // 
         this._printCellMenuItem.Name = "_printCellMenuItem";
         this._printCellMenuItem.Size = new System.Drawing.Size(178, 22);
         this._printCellMenuItem.Text = "&Print Cell...";
         this._printCellMenuItem.Click += new System.EventHandler(this._printCellMenuItem_Click);
         // 
         // saveToolStripMenuItem
         // 
         this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
         this.saveToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
         this.saveToolStripMenuItem.Text = "Save...";
         this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
         // 
         // sToolStripMenuItem
         // 
         this.sToolStripMenuItem.Name = "sToolStripMenuItem";
         this.sToolStripMenuItem.Size = new System.Drawing.Size(175, 6);
         // 
         // _fileMenuItem_exit
         // 
         this._fileMenuItem_exit.Name = "_fileMenuItem_exit";
         this._fileMenuItem_exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
         this._fileMenuItem_exit.Size = new System.Drawing.Size(178, 22);
         this._fileMenuItem_exit.Text = "&Exit";
         this._fileMenuItem_exit.Click += new System.EventHandler(this._fileMenuItem_exit_Click);
         // 
         // _editMenuItem
         // 
         this._editMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miEditFreezeCell,
            this._miEditToggleFreeze,
            this.sToolStripMenuItem1,
            this._miEditSelectAll,
            this._miEditInvertSelection,
            this._miEditDeselectAll,
            this._miEditRepositionCell,
            this.sToolStripMenuItem2,
            this._miEditRemoveCell,
            this._miEditRemoveSelectedCells,
            this.sToolStripMenuItem3,
            this._miEditAnimation,
            this._miEditCalibrateRuler,
            this._miEditConvertAnnotationToRegion});
         this._editMenuItem.Name = "_editMenuItem";
         this._editMenuItem.Size = new System.Drawing.Size(39, 20);
         this._editMenuItem.Text = "&Edit";
         this._editMenuItem.DropDownOpening += new System.EventHandler(this._editMenuItem_DropDownOpening);
         // 
         // _miEditFreezeCell
         // 
         this._miEditFreezeCell.Name = "_miEditFreezeCell";
         this._miEditFreezeCell.Size = new System.Drawing.Size(203, 22);
         this._miEditFreezeCell.Text = "&Freeze Cell(s)...";
         this._miEditFreezeCell.Click += new System.EventHandler(this._miEditFreezeCell_Click);
         // 
         // _miEditToggleFreeze
         // 
         this._miEditToggleFreeze.Name = "_miEditToggleFreeze";
         this._miEditToggleFreeze.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
         this._miEditToggleFreeze.Size = new System.Drawing.Size(203, 22);
         this._miEditToggleFreeze.Text = "To&ggle Freeze";
         this._miEditToggleFreeze.Click += new System.EventHandler(this._miEditToggleFreeze_Click);
         // 
         // sToolStripMenuItem1
         // 
         this.sToolStripMenuItem1.Name = "sToolStripMenuItem1";
         this.sToolStripMenuItem1.Size = new System.Drawing.Size(200, 6);
         // 
         // _miEditSelectAll
         // 
         this._miEditSelectAll.Name = "_miEditSelectAll";
         this._miEditSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
         this._miEditSelectAll.Size = new System.Drawing.Size(203, 22);
         this._miEditSelectAll.Text = "&Select All";
         this._miEditSelectAll.Click += new System.EventHandler(this._miEditSelectAll_Click);
         // 
         // _miEditInvertSelection
         // 
         this._miEditInvertSelection.Name = "_miEditInvertSelection";
         this._miEditInvertSelection.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
         this._miEditInvertSelection.Size = new System.Drawing.Size(203, 22);
         this._miEditInvertSelection.Text = "&Invert Selection";
         this._miEditInvertSelection.Click += new System.EventHandler(this._miEditInvertSelection_Click);
         // 
         // _miEditDeselectAll
         // 
         this._miEditDeselectAll.Name = "_miEditDeselectAll";
         this._miEditDeselectAll.Size = new System.Drawing.Size(203, 22);
         this._miEditDeselectAll.Text = "&Deselect All";
         this._miEditDeselectAll.Click += new System.EventHandler(this._miEditDeselectAll_Click);
         // 
         // _miEditRepositionCell
         // 
         this._miEditRepositionCell.Name = "_miEditRepositionCell";
         this._miEditRepositionCell.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
         this._miEditRepositionCell.Size = new System.Drawing.Size(203, 22);
         this._miEditRepositionCell.Text = "Re&position Cell...";
         this._miEditRepositionCell.Click += new System.EventHandler(this._miEditRepositionCell_Click);
         // 
         // sToolStripMenuItem2
         // 
         this.sToolStripMenuItem2.Name = "sToolStripMenuItem2";
         this.sToolStripMenuItem2.Size = new System.Drawing.Size(200, 6);
         // 
         // _miEditRemoveCell
         // 
         this._miEditRemoveCell.Name = "_miEditRemoveCell";
         this._miEditRemoveCell.Size = new System.Drawing.Size(203, 22);
         this._miEditRemoveCell.Text = "Remo&ve Cell(s)...";
         this._miEditRemoveCell.Click += new System.EventHandler(this._miEditRemoveCell_Click);
         // 
         // _miEditRemoveSelectedCells
         // 
         this._miEditRemoveSelectedCells.Name = "_miEditRemoveSelectedCells";
         this._miEditRemoveSelectedCells.Size = new System.Drawing.Size(203, 22);
         this._miEditRemoveSelectedCells.Text = "&Remove Selected Cell(s)";
         this._miEditRemoveSelectedCells.Click += new System.EventHandler(this._miEditRemoveSelectedCells_Click);
         // 
         // sToolStripMenuItem3
         // 
         this.sToolStripMenuItem3.Name = "sToolStripMenuItem3";
         this.sToolStripMenuItem3.Size = new System.Drawing.Size(200, 6);
         // 
         // _miEditAnimation
         // 
         this._miEditAnimation.Name = "_miEditAnimation";
         this._miEditAnimation.Size = new System.Drawing.Size(203, 22);
         this._miEditAnimation.Text = "&Animation...";
         this._miEditAnimation.Click += new System.EventHandler(this._miEditAnimation_Click);
         // 
         // _miEditCalibrateRuler
         // 
         this._miEditCalibrateRuler.Name = "_miEditCalibrateRuler";
         this._miEditCalibrateRuler.Size = new System.Drawing.Size(203, 22);
         this._miEditCalibrateRuler.Text = "Calibrate R&uler...";
         this._miEditCalibrateRuler.Click += new System.EventHandler(this._miEditCalibrateRuler_Click);
         // 
         // _miEditConvertAnnotationToRegion
         // 
         this._miEditConvertAnnotationToRegion.Name = "_miEditConvertAnnotationToRegion";
         this._miEditConvertAnnotationToRegion.Size = new System.Drawing.Size(203, 22);
         this._miEditConvertAnnotationToRegion.Text = "Annotation &To Region";
         this._miEditConvertAnnotationToRegion.Click += new System.EventHandler(this._miEditConvertAnnotationToRegion_Click);
         // 
         // _propertiesMenuItem
         // 
         this._propertiesMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miPropertiesViewerProperties,
            this._miPropertiesCellProperties});
         this._propertiesMenuItem.Name = "_propertiesMenuItem";
         this._propertiesMenuItem.Size = new System.Drawing.Size(72, 20);
         this._propertiesMenuItem.Text = "&Properties";
         this._propertiesMenuItem.DropDownOpening += new System.EventHandler(this._propertiesMenuItem_DropDownOpening);
         // 
         // _miPropertiesViewerProperties
         // 
         this._miPropertiesViewerProperties.Name = "_miPropertiesViewerProperties";
         this._miPropertiesViewerProperties.Size = new System.Drawing.Size(174, 22);
         this._miPropertiesViewerProperties.Text = "&Viewer Properties...";
         this._miPropertiesViewerProperties.Click += new System.EventHandler(this._miPropertiesViewerProperties_Click);
         // 
         // _miPropertiesCellProperties
         // 
         this._miPropertiesCellProperties.Name = "_miPropertiesCellProperties";
         this._miPropertiesCellProperties.Size = new System.Drawing.Size(174, 22);
         this._miPropertiesCellProperties.Text = "&Cell Properties...";
         this._miPropertiesCellProperties.Click += new System.EventHandler(this._miPropertiesCellProperties_Click);
         // 
         // _actionsMenuItem
         // 
         this._actionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miActionWindowLevel,
            this._miActionAlpha,
            this._miActionScale,
            this._miActionMagnify,
            this._miActionStack,
            this._miActionOffset,
            this._miSpyGlass,
            this._miActionsProbeTool,
            this._miActionZoomToRectangle,
            this._miActionClickZoomIn,
            this._miActionClickZoomOut,
            this._miActionCobbAngle});
         this._actionsMenuItem.Name = "_actionsMenuItem";
         this._actionsMenuItem.Size = new System.Drawing.Size(59, 20);
         this._actionsMenuItem.Text = "&Actions";
         this._actionsMenuItem.DropDownOpening += new System.EventHandler(this._actionsMenuItem_DropDownOpening);
         // 
         // _miActionWindowLevel
         // 
         this._miActionWindowLevel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miActionWindowLevelSet,
            this._miActionWindowLevelCustomize});
         this._miActionWindowLevel.Name = "_miActionWindowLevel";
         this._miActionWindowLevel.Size = new System.Drawing.Size(178, 22);
         this._miActionWindowLevel.Text = "&Window Level";
         // 
         // _miActionWindowLevelSet
         // 
         this._miActionWindowLevelSet.Name = "_miActionWindowLevelSet";
         this._miActionWindowLevelSet.Size = new System.Drawing.Size(216, 22);
         this._miActionWindowLevelSet.Text = "&Set...";
         this._miActionWindowLevelSet.Click += new System.EventHandler(this._miActionWindowLevelSet_Click);
         // 
         // _miActionWindowLevelCustomize
         // 
         this._miActionWindowLevelCustomize.Name = "_miActionWindowLevelCustomize";
         this._miActionWindowLevelCustomize.Size = new System.Drawing.Size(216, 22);
         this._miActionWindowLevelCustomize.Text = "Customize Window Level...";
         this._miActionWindowLevelCustomize.Click += new System.EventHandler(this._miActionWindowLevelCustomize_Click);
         // 
         // _miActionAlpha
         // 
         this._miActionAlpha.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miActionAlphaSet,
            this._miActionAlphaCustomizeAlpha});
         this._miActionAlpha.Name = "_miActionAlpha";
         this._miActionAlpha.Size = new System.Drawing.Size(178, 22);
         this._miActionAlpha.Text = "&Alpha";
         // 
         // _miActionAlphaSet
         // 
         this._miActionAlphaSet.Name = "_miActionAlphaSet";
         this._miActionAlphaSet.Size = new System.Drawing.Size(173, 22);
         this._miActionAlphaSet.Text = "&Set...";
         this._miActionAlphaSet.Click += new System.EventHandler(this._miActionAlphaSet_Click);
         // 
         // _miActionAlphaCustomizeAlpha
         // 
         this._miActionAlphaCustomizeAlpha.Name = "_miActionAlphaCustomizeAlpha";
         this._miActionAlphaCustomizeAlpha.Size = new System.Drawing.Size(173, 22);
         this._miActionAlphaCustomizeAlpha.Text = "Customize Alpha...";
         this._miActionAlphaCustomizeAlpha.Click += new System.EventHandler(this._miActionAlphaCustomizeAlpha_Click);
         // 
         // _miActionScale
         // 
         this._miActionScale.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miActionScaleSet,
            this._miActionScaleCustomizeScale});
         this._miActionScale.Name = "_miActionScale";
         this._miActionScale.Size = new System.Drawing.Size(178, 22);
         this._miActionScale.Text = "&Scale";
         // 
         // _miActionScaleSet
         // 
         this._miActionScaleSet.Name = "_miActionScaleSet";
         this._miActionScaleSet.Size = new System.Drawing.Size(169, 22);
         this._miActionScaleSet.Text = "&Set...";
         this._miActionScaleSet.Click += new System.EventHandler(this._miActionScaleSet_Click);
         // 
         // _miActionScaleCustomizeScale
         // 
         this._miActionScaleCustomizeScale.Name = "_miActionScaleCustomizeScale";
         this._miActionScaleCustomizeScale.Size = new System.Drawing.Size(169, 22);
         this._miActionScaleCustomizeScale.Text = "Customize Scale...";
         this._miActionScaleCustomizeScale.Click += new System.EventHandler(this._miActionScaleCustomizeScale_Click);
         // 
         // _miActionMagnify
         // 
         this._miActionMagnify.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miMagnifySet,
            this._miActionMagnifyCustomizeMagnify});
         this._miActionMagnify.Name = "_miActionMagnify";
         this._miActionMagnify.Size = new System.Drawing.Size(178, 22);
         this._miActionMagnify.Text = "&Magnify";
         // 
         // _miMagnifySet
         // 
         this._miMagnifySet.Name = "_miMagnifySet";
         this._miMagnifySet.Size = new System.Drawing.Size(186, 22);
         this._miMagnifySet.Text = "&Set...";
         this._miMagnifySet.Click += new System.EventHandler(this._miMagnifySet_Click);
         // 
         // _miActionMagnifyCustomizeMagnify
         // 
         this._miActionMagnifyCustomizeMagnify.Name = "_miActionMagnifyCustomizeMagnify";
         this._miActionMagnifyCustomizeMagnify.Size = new System.Drawing.Size(186, 22);
         this._miActionMagnifyCustomizeMagnify.Text = "Customize Magnify...";
         this._miActionMagnifyCustomizeMagnify.Click += new System.EventHandler(this._miActionMagnifyCustomizeMagnify_Click);
         // 
         // _miActionStack
         // 
         this._miActionStack.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miActionStackSet,
            this._miActionStackCustomizeStack});
         this._miActionStack.Name = "_miActionStack";
         this._miActionStack.Size = new System.Drawing.Size(178, 22);
         this._miActionStack.Text = "&Stack";
         // 
         // _miActionStackSet
         // 
         this._miActionStackSet.Name = "_miActionStackSet";
         this._miActionStackSet.Size = new System.Drawing.Size(170, 22);
         this._miActionStackSet.Text = "&Set...";
         this._miActionStackSet.Click += new System.EventHandler(this._miActionStackSet_Click);
         // 
         // _miActionStackCustomizeStack
         // 
         this._miActionStackCustomizeStack.Name = "_miActionStackCustomizeStack";
         this._miActionStackCustomizeStack.Size = new System.Drawing.Size(170, 22);
         this._miActionStackCustomizeStack.Text = "Customize Stack...";
         this._miActionStackCustomizeStack.Click += new System.EventHandler(this._miActionStackCustomizeStack_Click);
         // 
         // _miActionOffset
         // 
         this._miActionOffset.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miActionOffsetSet,
            this._miActionOffsetCustomizeOffset});
         this._miActionOffset.Name = "_miActionOffset";
         this._miActionOffset.Size = new System.Drawing.Size(178, 22);
         this._miActionOffset.Text = "&Pan";
         // 
         // _miActionOffsetSet
         // 
         this._miActionOffsetSet.Name = "_miActionOffsetSet";
         this._miActionOffsetSet.Size = new System.Drawing.Size(162, 22);
         this._miActionOffsetSet.Text = "&Set...";
         this._miActionOffsetSet.Click += new System.EventHandler(this._miActionOffsetSet_Click);
         // 
         // _miActionOffsetCustomizeOffset
         // 
         this._miActionOffsetCustomizeOffset.Name = "_miActionOffsetCustomizeOffset";
         this._miActionOffsetCustomizeOffset.Size = new System.Drawing.Size(162, 22);
         this._miActionOffsetCustomizeOffset.Text = "Customize Pan...";
         this._miActionOffsetCustomizeOffset.Click += new System.EventHandler(this._miActionOffsetCustomizeOffset_Click);
         // 
         // _miSpyGlass
         // 
         this._miSpyGlass.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miSpyGlassSet});
         this._miSpyGlass.Name = "_miSpyGlass";
         this._miSpyGlass.Size = new System.Drawing.Size(178, 22);
         this._miSpyGlass.Text = "Sp&y Glass";
         // 
         // _miSpyGlassSet
         // 
         this._miSpyGlassSet.Name = "_miSpyGlassSet";
         this._miSpyGlassSet.Size = new System.Drawing.Size(99, 22);
         this._miSpyGlassSet.Text = "&Set...";
         this._miSpyGlassSet.Click += new System.EventHandler(this._miSpyGlassSet_Click);
         // 
         // _miActionsProbeTool
         // 
         this._miActionsProbeTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miActionsProbeToolSet});
         this._miActionsProbeTool.Name = "_miActionsProbeTool";
         this._miActionsProbeTool.Size = new System.Drawing.Size(178, 22);
         this._miActionsProbeTool.Text = "&Probe Tool";
         // 
         // _miActionsProbeToolSet
         // 
         this._miActionsProbeToolSet.Name = "_miActionsProbeToolSet";
         this._miActionsProbeToolSet.Size = new System.Drawing.Size(99, 22);
         this._miActionsProbeToolSet.Text = "&Set...";
         this._miActionsProbeToolSet.Click += new System.EventHandler(this._miActionsProbeToolSet_Click);
         // 
         // _miActionZoomToRectangle
         // 
         this._miActionZoomToRectangle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miActionZoomToRectangleSet});
         this._miActionZoomToRectangle.Name = "_miActionZoomToRectangle";
         this._miActionZoomToRectangle.Size = new System.Drawing.Size(178, 22);
         this._miActionZoomToRectangle.Text = "&Zoom To Rectangle";
         // 
         // _miActionZoomToRectangleSet
         // 
         this._miActionZoomToRectangleSet.Name = "_miActionZoomToRectangleSet";
         this._miActionZoomToRectangleSet.Size = new System.Drawing.Size(99, 22);
         this._miActionZoomToRectangleSet.Text = "&Set...";
         this._miActionZoomToRectangleSet.Click += new System.EventHandler(this._miActionZoomToRectangleSet_Click);
         // 
         // _miActionClickZoomIn
         // 
         this._miActionClickZoomIn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miActionClickZoomInSet});
         this._miActionClickZoomIn.Name = "_miActionClickZoomIn";
         this._miActionClickZoomIn.Size = new System.Drawing.Size(178, 22);
         this._miActionClickZoomIn.Text = "Click Zoom In";
         // 
         // _miActionClickZoomInSet
         // 
         this._miActionClickZoomInSet.Name = "_miActionClickZoomInSet";
         this._miActionClickZoomInSet.Size = new System.Drawing.Size(99, 22);
         this._miActionClickZoomInSet.Text = "&Set...";
         this._miActionClickZoomInSet.Click += new System.EventHandler(this._miActionClickZoomInSet_Click);
         // 
         // _miActionClickZoomOut
         // 
         this._miActionClickZoomOut.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miActionClickZoomOutSet});
         this._miActionClickZoomOut.Name = "_miActionClickZoomOut";
         this._miActionClickZoomOut.Size = new System.Drawing.Size(178, 22);
         this._miActionClickZoomOut.Text = "Click Zoom Out";
         // 
         // _miActionClickZoomOutSet
         // 
         this._miActionClickZoomOutSet.Name = "_miActionClickZoomOutSet";
         this._miActionClickZoomOutSet.Size = new System.Drawing.Size(99, 22);
         this._miActionClickZoomOutSet.Text = "&Set...";
         this._miActionClickZoomOutSet.Click += new System.EventHandler(this._miActionClickZoomOutSet_Click);
         // 
         // _miActionCobbAngle
         // 
         this._miActionCobbAngle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miActionCobbAngleSet});
         this._miActionCobbAngle.Name = "_miActionCobbAngle";
         this._miActionCobbAngle.Size = new System.Drawing.Size(178, 22);
         this._miActionCobbAngle.Text = "&Cobb Angle";
         // 
         // _miActionCobbAngleSet
         // 
         this._miActionCobbAngleSet.Name = "_miActionCobbAngleSet";
         this._miActionCobbAngleSet.Size = new System.Drawing.Size(99, 22);
         this._miActionCobbAngleSet.Text = "&Set...";
         this._miActionCobbAngleSet.Click += new System.EventHandler(this._miActionCobbAngleSet_Click);
         // 
         // _regionMenuItem
         // 
         this._regionMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadRegionsToolStripMenuItem,
            this.saveRegionsToolStripMenuItem,
            this._miStatisticsStatistics,
            this.toolStripSeparator1,
            this._miRegionRectangle,
            this._miRegionEllipse,
            this._miRegionSquare,
            this._miRegionCircle,
            this._miRegionPolygon,
            this._miRegionFreeHand,
            this._miRegionMagicWand,
            this._miRegionColorRange,
            this.nudgeToolToolStripMenuItem});
         this._regionMenuItem.Name = "_regionMenuItem";
         this._regionMenuItem.Size = new System.Drawing.Size(56, 20);
         this._regionMenuItem.Text = "&Region";
         // 
         // loadRegionsToolStripMenuItem
         // 
         this.loadRegionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectedCellsToolStripMenuItem3,
            this.allCellsToolStripMenuItem2});
         this.loadRegionsToolStripMenuItem.Name = "loadRegionsToolStripMenuItem";
         this.loadRegionsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
         this.loadRegionsToolStripMenuItem.Text = "&Load Regions";
         this.loadRegionsToolStripMenuItem.DropDownOpening += new System.EventHandler(this.loadRegionsToolStripMenuItem_DropDownOpening);
         // 
         // selectedCellsToolStripMenuItem3
         // 
         this.selectedCellsToolStripMenuItem3.Name = "selectedCellsToolStripMenuItem3";
         this.selectedCellsToolStripMenuItem3.Size = new System.Drawing.Size(155, 22);
         this.selectedCellsToolStripMenuItem3.Text = "&Selected Cells...";
         this.selectedCellsToolStripMenuItem3.Click += new System.EventHandler(this.selectedCellsToolStripMenuItem3_Click);
         // 
         // allCellsToolStripMenuItem2
         // 
         this.allCellsToolStripMenuItem2.Name = "allCellsToolStripMenuItem2";
         this.allCellsToolStripMenuItem2.Size = new System.Drawing.Size(155, 22);
         this.allCellsToolStripMenuItem2.Text = "&All Cells...";
         this.allCellsToolStripMenuItem2.Click += new System.EventHandler(this.allCellsToolStripMenuItem2_Click);
         // 
         // saveRegionsToolStripMenuItem
         // 
         this.saveRegionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectedCellsToolStripMenuItem2,
            this.allCellsToolStripMenuItem1});
         this.saveRegionsToolStripMenuItem.Name = "saveRegionsToolStripMenuItem";
         this.saveRegionsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
         this.saveRegionsToolStripMenuItem.Text = "&Save Regions";
         this.saveRegionsToolStripMenuItem.DropDownOpening += new System.EventHandler(this.saveRegionsToolStripMenuItem_DropDownOpening);
         // 
         // selectedCellsToolStripMenuItem2
         // 
         this.selectedCellsToolStripMenuItem2.Name = "selectedCellsToolStripMenuItem2";
         this.selectedCellsToolStripMenuItem2.Size = new System.Drawing.Size(155, 22);
         this.selectedCellsToolStripMenuItem2.Text = "&Selected Cells...";
         this.selectedCellsToolStripMenuItem2.Click += new System.EventHandler(this.selectedCellsToolStripMenuItem2_Click);
         // 
         // allCellsToolStripMenuItem1
         // 
         this.allCellsToolStripMenuItem1.Name = "allCellsToolStripMenuItem1";
         this.allCellsToolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
         this.allCellsToolStripMenuItem1.Text = "&All Cells...";
         this.allCellsToolStripMenuItem1.Click += new System.EventHandler(this.allCellsToolStripMenuItem1_Click);
         // 
         // _miStatisticsStatistics
         // 
         this._miStatisticsStatistics.Name = "_miStatisticsStatistics";
         this._miStatisticsStatistics.Size = new System.Drawing.Size(169, 22);
         this._miStatisticsStatistics.Text = "Region &Statistics...";
         this._miStatisticsStatistics.Click += new System.EventHandler(this._miStatisticsStatistics_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
         // 
         // _miRegionRectangle
         // 
         this._miRegionRectangle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miRegionRectangleSet});
         this._miRegionRectangle.Name = "_miRegionRectangle";
         this._miRegionRectangle.Size = new System.Drawing.Size(169, 22);
         this._miRegionRectangle.Text = "&Rectangle";
         // 
         // _miRegionRectangleSet
         // 
         this._miRegionRectangleSet.Name = "_miRegionRectangleSet";
         this._miRegionRectangleSet.Size = new System.Drawing.Size(99, 22);
         this._miRegionRectangleSet.Text = "&Set...";
         this._miRegionRectangleSet.Click += new System.EventHandler(this.setToolStripMenuItem6_Click);
         // 
         // _miRegionEllipse
         // 
         this._miRegionEllipse.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miRegionEllipseSet});
         this._miRegionEllipse.Name = "_miRegionEllipse";
         this._miRegionEllipse.Size = new System.Drawing.Size(169, 22);
         this._miRegionEllipse.Text = "&Ellipse";
         // 
         // _miRegionEllipseSet
         // 
         this._miRegionEllipseSet.Name = "_miRegionEllipseSet";
         this._miRegionEllipseSet.Size = new System.Drawing.Size(99, 22);
         this._miRegionEllipseSet.Text = "&Set...";
         this._miRegionEllipseSet.Click += new System.EventHandler(this._miRegionEllipseSet_Click);
         // 
         // _miRegionSquare
         // 
         this._miRegionSquare.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miRegionSquareSet});
         this._miRegionSquare.Name = "_miRegionSquare";
         this._miRegionSquare.Size = new System.Drawing.Size(169, 22);
         this._miRegionSquare.Text = "&Square";
         // 
         // _miRegionSquareSet
         // 
         this._miRegionSquareSet.Name = "_miRegionSquareSet";
         this._miRegionSquareSet.Size = new System.Drawing.Size(99, 22);
         this._miRegionSquareSet.Text = "&Set...";
         this._miRegionSquareSet.Click += new System.EventHandler(this._miRegionSquareSet_Click);
         // 
         // _miRegionCircle
         // 
         this._miRegionCircle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miRegionCircleSet});
         this._miRegionCircle.Name = "_miRegionCircle";
         this._miRegionCircle.Size = new System.Drawing.Size(169, 22);
         this._miRegionCircle.Text = "&Circle";
         // 
         // _miRegionCircleSet
         // 
         this._miRegionCircleSet.Name = "_miRegionCircleSet";
         this._miRegionCircleSet.Size = new System.Drawing.Size(99, 22);
         this._miRegionCircleSet.Text = "&Set...";
         this._miRegionCircleSet.Click += new System.EventHandler(this._miRegionCircleSet_Click);
         // 
         // _miRegionPolygon
         // 
         this._miRegionPolygon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miRegionPolygonSet});
         this._miRegionPolygon.Name = "_miRegionPolygon";
         this._miRegionPolygon.Size = new System.Drawing.Size(169, 22);
         this._miRegionPolygon.Text = "&Polygon";
         // 
         // _miRegionPolygonSet
         // 
         this._miRegionPolygonSet.Name = "_miRegionPolygonSet";
         this._miRegionPolygonSet.Size = new System.Drawing.Size(99, 22);
         this._miRegionPolygonSet.Text = "&Set...";
         this._miRegionPolygonSet.Click += new System.EventHandler(this._miRegionPolygonSet_Click);
         // 
         // _miRegionFreeHand
         // 
         this._miRegionFreeHand.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miRegionFreeHandSet});
         this._miRegionFreeHand.Name = "_miRegionFreeHand";
         this._miRegionFreeHand.Size = new System.Drawing.Size(169, 22);
         this._miRegionFreeHand.Text = "&Free Hand";
         // 
         // _miRegionFreeHandSet
         // 
         this._miRegionFreeHandSet.Name = "_miRegionFreeHandSet";
         this._miRegionFreeHandSet.Size = new System.Drawing.Size(99, 22);
         this._miRegionFreeHandSet.Text = "&Set...";
         this._miRegionFreeHandSet.Click += new System.EventHandler(this._miRegionFreeHandSet_Click);
         // 
         // _miRegionMagicWand
         // 
         this._miRegionMagicWand.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miRegionMagicWandSet});
         this._miRegionMagicWand.Name = "_miRegionMagicWand";
         this._miRegionMagicWand.Size = new System.Drawing.Size(169, 22);
         this._miRegionMagicWand.Text = "&Magic Wand";
         // 
         // _miRegionMagicWandSet
         // 
         this._miRegionMagicWandSet.Name = "_miRegionMagicWandSet";
         this._miRegionMagicWandSet.Size = new System.Drawing.Size(99, 22);
         this._miRegionMagicWandSet.Text = "&Set...";
         this._miRegionMagicWandSet.Click += new System.EventHandler(this._miRegionMagicWandSet_Click);
         // 
         // _miRegionColorRange
         // 
         this._miRegionColorRange.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miRegionColorRangeSet});
         this._miRegionColorRange.Name = "_miRegionColorRange";
         this._miRegionColorRange.Size = new System.Drawing.Size(169, 22);
         this._miRegionColorRange.Text = "&Color Range";
         // 
         // _miRegionColorRangeSet
         // 
         this._miRegionColorRangeSet.Name = "_miRegionColorRangeSet";
         this._miRegionColorRangeSet.Size = new System.Drawing.Size(99, 22);
         this._miRegionColorRangeSet.Text = "&Set...";
         this._miRegionColorRangeSet.Click += new System.EventHandler(this._miRegionColorRangeSet_Click);
         // 
         // nudgeToolToolStripMenuItem
         // 
         this.nudgeToolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setToolStripMenuItem,
            this.customizeToolStripMenuItem});
         this.nudgeToolToolStripMenuItem.Name = "nudgeToolToolStripMenuItem";
         this.nudgeToolToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
         this.nudgeToolToolStripMenuItem.Text = "&Nudge tool";
         // 
         // setToolStripMenuItem
         // 
         this.setToolStripMenuItem.Name = "setToolStripMenuItem";
         this.setToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
         this.setToolStripMenuItem.Text = "&Set..";
         this.setToolStripMenuItem.Click += new System.EventHandler(this.setToolStripMenuItem_Click);
         // 
         // customizeToolStripMenuItem
         // 
         this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
         this.customizeToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
         this.customizeToolStripMenuItem.Text = "&Customize...";
         this.customizeToolStripMenuItem.Click += new System.EventHandler(this.customizeToolStripMenuItem_Click);
         // 
         // _annotationMenuItem
         // 
         this._annotationMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadAnnotationsToolStripMenuItem,
            this.saveAnnotationsToolStripMenuItem,
            this._miEditAnnotation,
            this.toolStripSeparator2,
            this._miAnnotationRectangle,
            this._miAnnotationEllipse,
            this._miAnnotationArrow,
            this._miAnnotationText,
            this._miAnnotationAngle,
            this._miAnnotationHilite,
            this._miAnnotationRuler});
         this._annotationMenuItem.Name = "_annotationMenuItem";
         this._annotationMenuItem.Size = new System.Drawing.Size(79, 20);
         this._annotationMenuItem.Text = "A&nnotation";
         this._annotationMenuItem.DropDownOpening += new System.EventHandler(this._annotationMenuItem_DropDownOpening);
         // 
         // loadAnnotationsToolStripMenuItem
         // 
         this.loadAnnotationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectedCellsToolStripMenuItem1,
            this.allCellToolStripMenuItem});
         this.loadAnnotationsToolStripMenuItem.Name = "loadAnnotationsToolStripMenuItem";
         this.loadAnnotationsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
         this.loadAnnotationsToolStripMenuItem.Text = "&Load annotations ";
         this.loadAnnotationsToolStripMenuItem.DropDownOpening += new System.EventHandler(this.loadAnnotationsToolStripMenuItem_DropDownOpening);
         // 
         // selectedCellsToolStripMenuItem1
         // 
         this.selectedCellsToolStripMenuItem1.Name = "selectedCellsToolStripMenuItem1";
         this.selectedCellsToolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
         this.selectedCellsToolStripMenuItem1.Text = "&Selected Cells...";
         this.selectedCellsToolStripMenuItem1.Click += new System.EventHandler(this.selectedCellsToolStripMenuItem1_Click);
         // 
         // allCellToolStripMenuItem
         // 
         this.allCellToolStripMenuItem.Name = "allCellToolStripMenuItem";
         this.allCellToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
         this.allCellToolStripMenuItem.Text = "&All Cells...";
         this.allCellToolStripMenuItem.Click += new System.EventHandler(this.allCellToolStripMenuItem_Click);
         // 
         // saveAnnotationsToolStripMenuItem
         // 
         this.saveAnnotationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectedCellsToolStripMenuItem,
            this.allCellsToolStripMenuItem});
         this.saveAnnotationsToolStripMenuItem.Name = "saveAnnotationsToolStripMenuItem";
         this.saveAnnotationsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
         this.saveAnnotationsToolStripMenuItem.Text = "&Save Annotations";
         this.saveAnnotationsToolStripMenuItem.DropDownOpening += new System.EventHandler(this.saveAnnotationsToolStripMenuItem_DropDownOpening);
         // 
         // selectedCellsToolStripMenuItem
         // 
         this.selectedCellsToolStripMenuItem.Name = "selectedCellsToolStripMenuItem";
         this.selectedCellsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
         this.selectedCellsToolStripMenuItem.Text = "&Selected Cells...";
         this.selectedCellsToolStripMenuItem.Click += new System.EventHandler(this.selectedCellsToolStripMenuItem_Click);
         // 
         // allCellsToolStripMenuItem
         // 
         this.allCellsToolStripMenuItem.Name = "allCellsToolStripMenuItem";
         this.allCellsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
         this.allCellsToolStripMenuItem.Text = "&All Cells...";
         this.allCellsToolStripMenuItem.Click += new System.EventHandler(this.allCellsToolStripMenuItem_Click);
         // 
         // _miEditAnnotation
         // 
         this._miEditAnnotation.Name = "_miEditAnnotation";
         this._miEditAnnotation.Size = new System.Drawing.Size(213, 22);
         this._miEditAnnotation.Text = "E&dit Selected Annotation...";
         this._miEditAnnotation.Click += new System.EventHandler(this._miEditAnnotation_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(210, 6);
         // 
         // _miAnnotationRectangle
         // 
         this._miAnnotationRectangle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miAnnotationRectangleSet,
            this._miAnnotationRectangleCustomizeRectangle});
         this._miAnnotationRectangle.Name = "_miAnnotationRectangle";
         this._miAnnotationRectangle.Size = new System.Drawing.Size(213, 22);
         this._miAnnotationRectangle.Text = "&Rectangle";
         // 
         // _miAnnotationRectangleSet
         // 
         this._miAnnotationRectangleSet.Name = "_miAnnotationRectangleSet";
         this._miAnnotationRectangleSet.Size = new System.Drawing.Size(194, 22);
         this._miAnnotationRectangleSet.Text = "&Set...";
         this._miAnnotationRectangleSet.Click += new System.EventHandler(this._miAnnotationRectangleSet_Click);
         // 
         // _miAnnotationRectangleCustomizeRectangle
         // 
         this._miAnnotationRectangleCustomizeRectangle.Name = "_miAnnotationRectangleCustomizeRectangle";
         this._miAnnotationRectangleCustomizeRectangle.Size = new System.Drawing.Size(194, 22);
         this._miAnnotationRectangleCustomizeRectangle.Text = "&Customize Rectangle...";
         this._miAnnotationRectangleCustomizeRectangle.Click += new System.EventHandler(this._miAnnotationRectangleCustomizeRectangle_Click);
         // 
         // _miAnnotationEllipse
         // 
         this._miAnnotationEllipse.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miAnnotationEllipseSet,
            this._miAnnotationEllipseCustomizeEllipse});
         this._miAnnotationEllipse.Name = "_miAnnotationEllipse";
         this._miAnnotationEllipse.Size = new System.Drawing.Size(213, 22);
         this._miAnnotationEllipse.Text = "&Ellipse";
         // 
         // _miAnnotationEllipseSet
         // 
         this._miAnnotationEllipseSet.Name = "_miAnnotationEllipseSet";
         this._miAnnotationEllipseSet.Size = new System.Drawing.Size(175, 22);
         this._miAnnotationEllipseSet.Text = "&Set...";
         this._miAnnotationEllipseSet.Click += new System.EventHandler(this._miAnnotationEllipseSet_Click);
         // 
         // _miAnnotationEllipseCustomizeEllipse
         // 
         this._miAnnotationEllipseCustomizeEllipse.Name = "_miAnnotationEllipseCustomizeEllipse";
         this._miAnnotationEllipseCustomizeEllipse.Size = new System.Drawing.Size(175, 22);
         this._miAnnotationEllipseCustomizeEllipse.Text = "&Customize Ellipse...";
         this._miAnnotationEllipseCustomizeEllipse.Click += new System.EventHandler(this._miAnnotationEllipseCustomizeEllipse_Click);
         // 
         // _miAnnotationArrow
         // 
         this._miAnnotationArrow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miAnnotationArrowSet,
            this._miAnnotationArrowCustomizeArrow});
         this._miAnnotationArrow.Name = "_miAnnotationArrow";
         this._miAnnotationArrow.Size = new System.Drawing.Size(213, 22);
         this._miAnnotationArrow.Text = "&Arrow";
         // 
         // _miAnnotationArrowSet
         // 
         this._miAnnotationArrowSet.Name = "_miAnnotationArrowSet";
         this._miAnnotationArrowSet.Size = new System.Drawing.Size(174, 22);
         this._miAnnotationArrowSet.Text = "&Set...";
         this._miAnnotationArrowSet.Click += new System.EventHandler(this._miAnnotationArrowSet_Click);
         // 
         // _miAnnotationArrowCustomizeArrow
         // 
         this._miAnnotationArrowCustomizeArrow.Name = "_miAnnotationArrowCustomizeArrow";
         this._miAnnotationArrowCustomizeArrow.Size = new System.Drawing.Size(174, 22);
         this._miAnnotationArrowCustomizeArrow.Text = "&Customize Arrow...";
         this._miAnnotationArrowCustomizeArrow.Click += new System.EventHandler(this._miActionArrowCustomizeArrow_Click);
         // 
         // _miAnnotationText
         // 
         this._miAnnotationText.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miAnnotationTextSet,
            this._miAnnotationTextCustomizeText});
         this._miAnnotationText.Name = "_miAnnotationText";
         this._miAnnotationText.Size = new System.Drawing.Size(213, 22);
         this._miAnnotationText.Text = "&Text";
         // 
         // _miAnnotationTextSet
         // 
         this._miAnnotationTextSet.Name = "_miAnnotationTextSet";
         this._miAnnotationTextSet.Size = new System.Drawing.Size(164, 22);
         this._miAnnotationTextSet.Text = "&Set...";
         this._miAnnotationTextSet.Click += new System.EventHandler(this._miAnnotationTextSet_Click);
         // 
         // _miAnnotationTextCustomizeText
         // 
         this._miAnnotationTextCustomizeText.Name = "_miAnnotationTextCustomizeText";
         this._miAnnotationTextCustomizeText.Size = new System.Drawing.Size(164, 22);
         this._miAnnotationTextCustomizeText.Text = "&Customize Text...";
         this._miAnnotationTextCustomizeText.Click += new System.EventHandler(this._miAnnotationTextCustomizeText_Click);
         // 
         // _miAnnotationAngle
         // 
         this._miAnnotationAngle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miAnnotationAngleSet,
            this._miAnnotationAngleCustomizeAngle});
         this._miAnnotationAngle.Name = "_miAnnotationAngle";
         this._miAnnotationAngle.Size = new System.Drawing.Size(213, 22);
         this._miAnnotationAngle.Text = "&Angle";
         // 
         // _miAnnotationAngleSet
         // 
         this._miAnnotationAngleSet.Name = "_miAnnotationAngleSet";
         this._miAnnotationAngleSet.Size = new System.Drawing.Size(173, 22);
         this._miAnnotationAngleSet.Text = "&Set...";
         this._miAnnotationAngleSet.Click += new System.EventHandler(this._miAnnotationAngleSet_Click);
         // 
         // _miAnnotationAngleCustomizeAngle
         // 
         this._miAnnotationAngleCustomizeAngle.Name = "_miAnnotationAngleCustomizeAngle";
         this._miAnnotationAngleCustomizeAngle.Size = new System.Drawing.Size(173, 22);
         this._miAnnotationAngleCustomizeAngle.Text = "&Customize Angle...";
         this._miAnnotationAngleCustomizeAngle.Click += new System.EventHandler(this._miAnnotationAngleCustomizeAngle_Click);
         // 
         // _miAnnotationHilite
         // 
         this._miAnnotationHilite.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miAnnotationHiliteSet,
            this._miAnnotationHiliteCustomizeHilite});
         this._miAnnotationHilite.Name = "_miAnnotationHilite";
         this._miAnnotationHilite.Size = new System.Drawing.Size(213, 22);
         this._miAnnotationHilite.Text = "&Hilite";
         // 
         // _miAnnotationHiliteSet
         // 
         this._miAnnotationHiliteSet.Name = "_miAnnotationHiliteSet";
         this._miAnnotationHiliteSet.Size = new System.Drawing.Size(170, 22);
         this._miAnnotationHiliteSet.Text = "&Set...";
         this._miAnnotationHiliteSet.Click += new System.EventHandler(this._miAnnotationHiliteSet_Click);
         // 
         // _miAnnotationHiliteCustomizeHilite
         // 
         this._miAnnotationHiliteCustomizeHilite.Name = "_miAnnotationHiliteCustomizeHilite";
         this._miAnnotationHiliteCustomizeHilite.Size = new System.Drawing.Size(170, 22);
         this._miAnnotationHiliteCustomizeHilite.Text = "Customize Hilite...";
         this._miAnnotationHiliteCustomizeHilite.Click += new System.EventHandler(this._miAnnotationHiliteCustomizeHilite_Click);
         // 
         // _miAnnotationRuler
         // 
         this._miAnnotationRuler.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miAnnotationRulerSet,
            this._miAnnotationRulerCustomizeRuler});
         this._miAnnotationRuler.Name = "_miAnnotationRuler";
         this._miAnnotationRuler.Size = new System.Drawing.Size(213, 22);
         this._miAnnotationRuler.Text = "R&uler";
         // 
         // _miAnnotationRulerSet
         // 
         this._miAnnotationRulerSet.Name = "_miAnnotationRulerSet";
         this._miAnnotationRulerSet.Size = new System.Drawing.Size(169, 22);
         this._miAnnotationRulerSet.Text = "&Set...";
         this._miAnnotationRulerSet.Click += new System.EventHandler(this._miAnnotationRulerSet_Click);
         // 
         // _miAnnotationRulerCustomizeRuler
         // 
         this._miAnnotationRulerCustomizeRuler.Name = "_miAnnotationRulerCustomizeRuler";
         this._miAnnotationRulerCustomizeRuler.Size = new System.Drawing.Size(169, 22);
         this._miAnnotationRulerCustomizeRuler.Text = "&Customize Ruler...";
         this._miAnnotationRulerCustomizeRuler.Click += new System.EventHandler(this._miAnnotationRulerCustomize_Click);
         // 
         // _transformMenuItem
         // 
         this._transformMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miEffectReverse,
            this._miEffectFlip,
            this._miRotate,
            this.sToolStripMenuItem4,
            this._miEffectOptions});
         this._transformMenuItem.Name = "_transformMenuItem";
         this._transformMenuItem.Size = new System.Drawing.Size(74, 20);
         this._transformMenuItem.Text = "&Transform";
         this._transformMenuItem.DropDownOpening += new System.EventHandler(this.@__transformMenuItem_DropDownOpening);
         // 
         // _miEffectReverse
         // 
         this._miEffectReverse.Name = "_miEffectReverse";
         this._miEffectReverse.Size = new System.Drawing.Size(116, 22);
         this._miEffectReverse.Text = "&Reverse";
         this._miEffectReverse.Click += new System.EventHandler(this._miEffectReverse_Click);
         // 
         // _miEffectFlip
         // 
         this._miEffectFlip.Name = "_miEffectFlip";
         this._miEffectFlip.Size = new System.Drawing.Size(116, 22);
         this._miEffectFlip.Text = "&Flip";
         this._miEffectFlip.Click += new System.EventHandler(this._miEffectFlip_Click);
         // 
         // _miRotate
         // 
         this._miRotate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miRotate90,
            this._miRotate180,
            this._miRotateMinus90,
            this._miRotateMinus180});
         this._miRotate.Name = "_miRotate";
         this._miRotate.Size = new System.Drawing.Size(116, 22);
         this._miRotate.Text = "Rotate";
         // 
         // _miRotate90
         // 
         this._miRotate90.Name = "_miRotate90";
         this._miRotate90.Size = new System.Drawing.Size(105, 22);
         this._miRotate90.Text = "+90°";
         this._miRotate90.Click += new System.EventHandler(this._miRotate90_Click);
         // 
         // _miRotate180
         // 
         this._miRotate180.Name = "_miRotate180";
         this._miRotate180.Size = new System.Drawing.Size(105, 22);
         this._miRotate180.Text = "+180°";
         this._miRotate180.Click += new System.EventHandler(this._miRotate180_Click);
         // 
         // _miRotateMinus90
         // 
         this._miRotateMinus90.Name = "_miRotateMinus90";
         this._miRotateMinus90.Size = new System.Drawing.Size(105, 22);
         this._miRotateMinus90.Text = "-90°";
         this._miRotateMinus90.Click += new System.EventHandler(this._miRotateMinus90_Click);
         // 
         // _miRotateMinus180
         // 
         this._miRotateMinus180.Name = "_miRotateMinus180";
         this._miRotateMinus180.Size = new System.Drawing.Size(105, 22);
         this._miRotateMinus180.Text = "-180°";
         this._miRotateMinus180.Click += new System.EventHandler(this._miRotateMinus180_Click);
         // 
         // sToolStripMenuItem4
         // 
         this.sToolStripMenuItem4.Name = "sToolStripMenuItem4";
         this.sToolStripMenuItem4.Size = new System.Drawing.Size(113, 6);
         // 
         // _miEffectOptions
         // 
         this._miEffectOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miEffectOptionsApplyToAllSubCells});
         this._miEffectOptions.Name = "_miEffectOptions";
         this._miEffectOptions.Size = new System.Drawing.Size(116, 22);
         this._miEffectOptions.Text = "&Options";
         // 
         // _miEffectOptionsApplyToAllSubCells
         // 
         this._miEffectOptionsApplyToAllSubCells.Checked = true;
         this._miEffectOptionsApplyToAllSubCells.CheckState = System.Windows.Forms.CheckState.Checked;
         this._miEffectOptionsApplyToAllSubCells.Name = "_miEffectOptionsApplyToAllSubCells";
         this._miEffectOptionsApplyToAllSubCells.Size = new System.Drawing.Size(185, 22);
         this._miEffectOptionsApplyToAllSubCells.Text = "&Apply to all Sub-cells";
         this._miEffectOptionsApplyToAllSubCells.Click += new System.EventHandler(this._miEffectOptionsApplyToAllSubCells_Click);
         // 
         // _stentMenuItem
         // 
         this._stentMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._stentEnhancementMenuItem,
            this._unselectFramesMenuItem,
            this._moveMarkersAction});
         this._stentMenuItem.Name = "_stentMenuItem";
         this._stentMenuItem.Size = new System.Drawing.Size(46, 20);
         this._stentMenuItem.Text = "&Stent";
         this._stentMenuItem.DropDownOpening += new System.EventHandler(this.stentToolStripMenuItem_DropDownOpening);
         // 
         // _stentEnhancementMenuItem
         // 
         this._stentEnhancementMenuItem.Name = "_stentEnhancementMenuItem";
         this._stentEnhancementMenuItem.Size = new System.Drawing.Size(187, 22);
         this._stentEnhancementMenuItem.Text = "&Stent Enhancement...";
         this._stentEnhancementMenuItem.Click += new System.EventHandler(this.stentEnhancementToolStripMenuItem_Click);
         // 
         // _unselectFramesMenuItem
         // 
         this._unselectFramesMenuItem.Name = "_unselectFramesMenuItem";
         this._unselectFramesMenuItem.Size = new System.Drawing.Size(187, 22);
         this._unselectFramesMenuItem.Text = "&Unselect Frames...";
         this._unselectFramesMenuItem.Click += new System.EventHandler(this.unselectFramesToolStripMenuItem_Click);
         // 
         // _moveMarkersAction
         // 
         this._moveMarkersAction.Name = "_moveMarkersAction";
         this._moveMarkersAction.Size = new System.Drawing.Size(187, 22);
         this._moveMarkersAction.Text = "&Move Markers Action";
         this._moveMarkersAction.Click += new System.EventHandler(this._moveMarkersAction_Click);
         // 
         // _filtersMenuItem
         // 
         this._filtersMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.multiscaleEnhancementToolStripMenuItem,
            this.adaptiveContrastToolStripMenuItem,
            this.unsharpMaskToolStripMenuItem,
            this.histogramEqualizeToolStripMenuItem,
            this._miEffectCLAHE,
            this._miEffectInvert,
            this.toolStripSeparator3,
            this.resetToolStripMenuItem});
         this._filtersMenuItem.Name = "_filtersMenuItem";
         this._filtersMenuItem.Size = new System.Drawing.Size(50, 20);
         this._filtersMenuItem.Text = "&Filters";
         this._filtersMenuItem.DropDownOpening += new System.EventHandler(this.filtersToolStripMenuItem1_DropDownOpening);
         // 
         // multiscaleEnhancementToolStripMenuItem
         // 
         this.multiscaleEnhancementToolStripMenuItem.Name = "multiscaleEnhancementToolStripMenuItem";
         this.multiscaleEnhancementToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
         this.multiscaleEnhancementToolStripMenuItem.Text = "&Multiscale Enhancement...";
         this.multiscaleEnhancementToolStripMenuItem.Click += new System.EventHandler(this.multiscaleEnhancementToolStripMenuItem_Click);
         // 
         // adaptiveContrastToolStripMenuItem
         // 
         this.adaptiveContrastToolStripMenuItem.Name = "adaptiveContrastToolStripMenuItem";
         this.adaptiveContrastToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
         this.adaptiveContrastToolStripMenuItem.Text = "&Adaptive Contrast...";
         this.adaptiveContrastToolStripMenuItem.Click += new System.EventHandler(this.adaptiveContrastToolStripMenuItem_Click);
         // 
         // unsharpMaskToolStripMenuItem
         // 
         this.unsharpMaskToolStripMenuItem.Name = "unsharpMaskToolStripMenuItem";
         this.unsharpMaskToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
         this.unsharpMaskToolStripMenuItem.Text = "&Unsharp Mask...";
         this.unsharpMaskToolStripMenuItem.Click += new System.EventHandler(this.unsharpMaskToolStripMenuItem_Click);
         // 
         // histogramEqualizeToolStripMenuItem
         // 
         this.histogramEqualizeToolStripMenuItem.Name = "histogramEqualizeToolStripMenuItem";
         this.histogramEqualizeToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
         this.histogramEqualizeToolStripMenuItem.Text = "&Histogram Equalize...";
         this.histogramEqualizeToolStripMenuItem.Click += new System.EventHandler(this.histogramEqualizeToolStripMenuItem_Click);
         // 
         // _miEffectCLAHE
         // 
         this._miEffectCLAHE.Name = "_miEffectCLAHE";
         this._miEffectCLAHE.Size = new System.Drawing.Size(207, 22);
         this._miEffectCLAHE.Text = "&CLAHE...";
         this._miEffectCLAHE.Click += new System.EventHandler(this.cLAHEToolStripMenuItem_Click);
         // 
         // _miEffectInvert
         // 
         this._miEffectInvert.Name = "_miEffectInvert";
         this._miEffectInvert.Size = new System.Drawing.Size(207, 22);
         this._miEffectInvert.Text = "&Invert";
         this._miEffectInvert.Click += new System.EventHandler(this._miEffectInvert_Click);
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(204, 6);
         // 
         // resetToolStripMenuItem
         // 
         this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
         this.resetToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
         this.resetToolStripMenuItem.Text = "&Reset";
         this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
         // 
         // _alignmentMenuItem
         // 
         this._alignmentMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageAlignmentToolStripMenuItem,
            this._selectPointsActionMenuItem});
         this._alignmentMenuItem.Name = "_alignmentMenuItem";
         this._alignmentMenuItem.Size = new System.Drawing.Size(75, 20);
         this._alignmentMenuItem.Text = "Alignment";
         this._alignmentMenuItem.DropDownOpening += new System.EventHandler(this.dISToolStripMenuItem_DropDownOpening);
         // 
         // imageAlignmentToolStripMenuItem
         // 
         this.imageAlignmentToolStripMenuItem.Name = "imageAlignmentToolStripMenuItem";
         this.imageAlignmentToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
         this.imageAlignmentToolStripMenuItem.Text = "Image Alignment...";
         this.imageAlignmentToolStripMenuItem.Click += new System.EventHandler(this.imageAlignmentToolStripMenuItem_Click);
         // 
         // _selectPointsActionMenuItem
         // 
         this._selectPointsActionMenuItem.Name = "_selectPointsActionMenuItem";
         this._selectPointsActionMenuItem.Size = new System.Drawing.Size(179, 22);
         this._selectPointsActionMenuItem.Text = "Select Points Action";
         this._selectPointsActionMenuItem.Click += new System.EventHandler(this._selectPointsActionMenuItem_Click);
         // 
         // _helpMenuItem
         // 
         this._helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miHelpAbout});
         this._helpMenuItem.Name = "_helpMenuItem";
         this._helpMenuItem.Size = new System.Drawing.Size(44, 20);
         this._helpMenuItem.Text = "&Help";
         // 
         // _miHelpAbout
         // 
         this._miHelpAbout.Name = "_miHelpAbout";
         this._miHelpAbout.Size = new System.Drawing.Size(116, 22);
         this._miHelpAbout.Text = "&About...";
         this._miHelpAbout.Click += new System.EventHandler(this._miHelpAbout_Click);
         // 
         // _mainPanel
         // 
         this._mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this._mainPanel.Location = new System.Drawing.Point(0, 24);
         this._mainPanel.Name = "_mainPanel";
         this._mainPanel.Size = new System.Drawing.Size(772, 416);
         this._mainPanel.TabIndex = 2;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(772, 440);
         this.Controls.Add(this._mainPanel);
         this.Controls.Add(this._mainMenu);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this._mainMenu;
         this.Name = "MainForm";
         this.Text = "Medical Viewer Demo";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.Resize += new System.EventHandler(this.MainForm_Resize);
         this._mainMenu.ResumeLayout(false);
         this._mainMenu.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }


      #endregion

      private System.Windows.Forms.MenuStrip _mainMenu;
      private System.Windows.Forms.ToolStripMenuItem _fileMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _propertiesMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _actionsMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _regionMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _annotationMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _helpMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fileMenuItem_insertCell;
      private System.Windows.Forms.ToolStripSeparator sToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fileMenuItem_exit;
      private System.Windows.Forms.ToolStripMenuItem _miPropertiesViewerProperties;
      private System.Windows.Forms.ToolStripMenuItem _miPropertiesCellProperties;
      private System.Windows.Forms.ToolStripMenuItem _miHelpAbout;
      private System.Windows.Forms.ToolStripMenuItem _miRegionRectangle;
      private System.Windows.Forms.ToolStripMenuItem _miRegionEllipse;
      private System.Windows.Forms.ToolStripMenuItem _miRegionSquare;
      private System.Windows.Forms.ToolStripMenuItem _miRegionCircle;
      private System.Windows.Forms.ToolStripMenuItem _miRegionPolygon;
      private System.Windows.Forms.ToolStripMenuItem _miRegionFreeHand;
      private System.Windows.Forms.ToolStripMenuItem _miRegionMagicWand;
      private System.Windows.Forms.ToolStripMenuItem _miRegionColorRange;
      private System.Windows.Forms.ToolStripMenuItem _miAnnotationRectangle;
      private System.Windows.Forms.ToolStripMenuItem _miAnnotationRectangleSet;
      private System.Windows.Forms.ToolStripMenuItem _miAnnotationRectangleCustomizeRectangle;
      private System.Windows.Forms.ToolStripMenuItem _miAnnotationEllipse;
      private System.Windows.Forms.ToolStripMenuItem _miAnnotationEllipseSet;
      private System.Windows.Forms.ToolStripMenuItem _miAnnotationEllipseCustomizeEllipse;
      private System.Windows.Forms.ToolStripMenuItem _miAnnotationArrow;
      private System.Windows.Forms.ToolStripMenuItem _miAnnotationArrowSet;
      private System.Windows.Forms.ToolStripMenuItem _miAnnotationArrowCustomizeArrow;
      private System.Windows.Forms.ToolStripMenuItem _miAnnotationText;
      private System.Windows.Forms.ToolStripMenuItem _miAnnotationTextSet;
      private System.Windows.Forms.ToolStripMenuItem _miAnnotationTextCustomizeText;
      private System.Windows.Forms.ToolStripMenuItem _miAnnotationAngle;
      private System.Windows.Forms.ToolStripMenuItem _miAnnotationAngleSet;
      private System.Windows.Forms.ToolStripMenuItem _miAnnotationAngleCustomizeAngle;
      private System.Windows.Forms.ToolStripMenuItem _miAnnotationHilite;
      private System.Windows.Forms.ToolStripMenuItem _miAnnotationHiliteSet;
      private System.Windows.Forms.ToolStripMenuItem _miAnnotationHiliteCustomizeHilite;
      private System.Windows.Forms.ToolStripMenuItem _miActionWindowLevel;
      private System.Windows.Forms.ToolStripMenuItem _miActionWindowLevelSet;
      private System.Windows.Forms.ToolStripMenuItem _miActionWindowLevelCustomize;
      private System.Windows.Forms.ToolStripMenuItem _miActionAlpha;
      private System.Windows.Forms.ToolStripMenuItem _miActionAlphaSet;
      private System.Windows.Forms.ToolStripMenuItem _miActionAlphaCustomizeAlpha;
      private System.Windows.Forms.ToolStripMenuItem _miActionScale;
      private System.Windows.Forms.ToolStripMenuItem _miActionScaleSet;
      private System.Windows.Forms.ToolStripMenuItem _miActionScaleCustomizeScale;
      private System.Windows.Forms.ToolStripMenuItem _miActionMagnify;
      private System.Windows.Forms.ToolStripMenuItem _miMagnifySet;
      private System.Windows.Forms.ToolStripMenuItem _miActionMagnifyCustomizeMagnify;
      private System.Windows.Forms.ToolStripMenuItem _miActionStack;
      private System.Windows.Forms.ToolStripMenuItem _miActionStackSet;
      private System.Windows.Forms.ToolStripMenuItem _miActionStackCustomizeStack;
      private System.Windows.Forms.ToolStripMenuItem _miActionOffset;
      private System.Windows.Forms.ToolStripMenuItem _miActionOffsetSet;
      private System.Windows.Forms.ToolStripMenuItem _miActionOffsetCustomizeOffset;
      private System.Windows.Forms.ToolStripMenuItem _miRegionRectangleSet;
      private System.Windows.Forms.ToolStripMenuItem _miRegionEllipseSet;
      private System.Windows.Forms.ToolStripMenuItem _miRegionSquareSet;
      private System.Windows.Forms.ToolStripMenuItem _miRegionCircleSet;
      private System.Windows.Forms.ToolStripMenuItem _miRegionPolygonSet;
      private System.Windows.Forms.ToolStripMenuItem _miRegionFreeHandSet;
      private System.Windows.Forms.ToolStripMenuItem _miRegionMagicWandSet;
      private System.Windows.Forms.ToolStripMenuItem _miRegionColorRangeSet;
      private System.Windows.Forms.Panel _mainPanel;
      private System.Windows.Forms.ToolStripMenuItem _miAnnotationRuler;
      private System.Windows.Forms.ToolStripMenuItem _miAnnotationRulerSet;
      private System.Windows.Forms.ToolStripMenuItem _miAnnotationRulerCustomizeRuler;
      private System.Windows.Forms.ToolStripMenuItem _transformMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _miEffectReverse;
      private System.Windows.Forms.ToolStripMenuItem _miEffectFlip;
      private System.Windows.Forms.ToolStripSeparator sToolStripMenuItem4;
      private System.Windows.Forms.ToolStripMenuItem _miEffectOptions;
      private System.Windows.Forms.ToolStripMenuItem _miEffectOptionsApplyToAllSubCells;
      private System.Windows.Forms.ToolStripMenuItem _printCellMenuItem;
      private System.Windows.Forms.ToolStripMenuItem nudgeToolToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem saveRegionsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem selectedCellsToolStripMenuItem2;
      private System.Windows.Forms.ToolStripMenuItem allCellsToolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem loadRegionsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem selectedCellsToolStripMenuItem3;
      private System.Windows.Forms.ToolStripMenuItem allCellsToolStripMenuItem2;
      private System.Windows.Forms.ToolStripMenuItem saveAnnotationsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem selectedCellsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem allCellsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem loadAnnotationsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem selectedCellsToolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem allCellToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripMenuItem _miSpyGlass;
      private System.Windows.Forms.ToolStripMenuItem _miSpyGlassSet;
      private System.Windows.Forms.ToolStripMenuItem _miActionsProbeTool;
      private System.Windows.Forms.ToolStripMenuItem _miActionsProbeToolSet;
      private System.Windows.Forms.ToolStripMenuItem _miActionZoomToRectangle;
      private System.Windows.Forms.ToolStripMenuItem _miActionZoomToRectangleSet;
      private System.Windows.Forms.ToolStripMenuItem _miActionClickZoomIn;
      private System.Windows.Forms.ToolStripMenuItem _miActionClickZoomInSet;
      private System.Windows.Forms.ToolStripMenuItem _miActionClickZoomOut;
      private System.Windows.Forms.ToolStripMenuItem _miActionClickZoomOutSet;
      private System.Windows.Forms.ToolStripMenuItem _miActionCobbAngle;
      private System.Windows.Forms.ToolStripMenuItem _miActionCobbAngleSet;
      private System.Windows.Forms.ToolStripMenuItem _editMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _miEditFreezeCell;
      private System.Windows.Forms.ToolStripMenuItem _miEditToggleFreeze;
      private System.Windows.Forms.ToolStripSeparator sToolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem _miEditSelectAll;
      private System.Windows.Forms.ToolStripMenuItem _miEditInvertSelection;
      private System.Windows.Forms.ToolStripMenuItem _miEditDeselectAll;
      private System.Windows.Forms.ToolStripMenuItem _miEditRepositionCell;
      private System.Windows.Forms.ToolStripSeparator sToolStripMenuItem2;
      private System.Windows.Forms.ToolStripMenuItem _miEditRemoveCell;
      private System.Windows.Forms.ToolStripMenuItem _miEditRemoveSelectedCells;
      private System.Windows.Forms.ToolStripSeparator sToolStripMenuItem3;
      private System.Windows.Forms.ToolStripMenuItem _miEditAnimation;
      private System.Windows.Forms.ToolStripMenuItem _miEditCalibrateRuler;
      private System.Windows.Forms.ToolStripMenuItem _miEditConvertAnnotationToRegion;
      private System.Windows.Forms.ToolStripMenuItem _stentMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _stentEnhancementMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _unselectFramesMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _filtersMenuItem;
      private System.Windows.Forms.ToolStripMenuItem multiscaleEnhancementToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem adaptiveContrastToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem unsharpMaskToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem histogramEqualizeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _moveMarkersAction;
      private System.Windows.Forms.ToolStripMenuItem _alignmentMenuItem;
      private System.Windows.Forms.ToolStripMenuItem imageAlignmentToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _selectPointsActionMenuItem;
      private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripMenuItem _miEffectCLAHE;
      private System.Windows.Forms.ToolStripMenuItem _miStatisticsStatistics;
      private System.Windows.Forms.ToolStripMenuItem _miEffectInvert;
      private System.Windows.Forms.ToolStripMenuItem _miRotate;
      private System.Windows.Forms.ToolStripMenuItem _miRotate90;
      private System.Windows.Forms.ToolStripMenuItem _miRotate180;
      private System.Windows.Forms.ToolStripMenuItem _miRotateMinus90;
      private System.Windows.Forms.ToolStripMenuItem _miRotateMinus180;
      private System.Windows.Forms.ToolStripMenuItem _miEditAnnotation;
   }
}

