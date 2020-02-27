using System.Windows.Forms;
namespace Main3DDemo
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this._mainMenu = new System.Windows.Forms.MenuStrip();
         this._menuFile = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemFileLoadDICOM = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemFileLoadDICOMDIR = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemHardwareCheck = new System.Windows.Forms.ToolStripMenuItem();
         this._menuUnload = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this._loadMeshMenu = new System.Windows.Forms.ToolStripMenuItem();
         this._saveMeshMenu = new System.Windows.Forms.ToolStripMenuItem();
         this._saveMPR = new System.Windows.Forms.ToolStripMenuItem();
         this._save3DImage = new System.Windows.Forms.ToolStripMenuItem();
         this._loadObjectStatusMenu = new System.Windows.Forms.ToolStripMenuItem();
         this._saveObjectStatusMenu = new System.Windows.Forms.ToolStripMenuItem();
         this._menuLoadObject = new System.Windows.Forms.ToolStripMenuItem();
         this._menuSaveRawData = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this._menuFile_exit = new System.Windows.Forms.ToolStripMenuItem();
         this._menuEdit = new System.Windows.Forms.ToolStripMenuItem();
         this._editColorMap = new System.Windows.Forms.ToolStripMenuItem();
         this._menuRemoveDensity = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemEditSSD = new System.Windows.Forms.ToolStripMenuItem();
         this._menuSSDMeshColor = new System.Windows.Forms.ToolStripMenuItem();
         this._menuSSDIsoThreshold = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this._menuItemEditReset = new System.Windows.Forms.ToolStripMenuItem();
         this._menuDeleteAll = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
         this.renderingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.hardwareIfAvailbleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.softwareOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.renderingTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._texturing3D = new System.Windows.Forms.ToolStripMenuItem();
         this._texturing2D = new System.Windows.Forms.ToolStripMenuItem();
         this._texturingAuto = new System.Windows.Forms.ToolStripMenuItem();
         this._menuView = new System.Windows.Forms.ToolStripMenuItem();
         this._showMPRWindows = new System.Windows.Forms.ToolStripMenuItem();
         this._menuProperties = new System.Windows.Forms.ToolStripMenuItem();
         this._menuLayoutOptions = new System.Windows.Forms.ToolStripMenuItem();
         this._menuInvert = new System.Windows.Forms.ToolStripMenuItem();
         this._menuShowScrollBar = new System.Windows.Forms.ToolStripMenuItem();
         this._menuCellType = new System.Windows.Forms.ToolStripMenuItem();
         this._menuVolumeVRT = new System.Windows.Forms.ToolStripMenuItem();
         this._menuVolumeMIP = new System.Windows.Forms.ToolStripMenuItem();
         this._menuVolumeMPR = new System.Windows.Forms.ToolStripMenuItem();
         this._menuVolumeMinIP = new System.Windows.Forms.ToolStripMenuItem();
         this._menuVolumeSSD = new System.Windows.Forms.ToolStripMenuItem();
         this._menu2DCell = new System.Windows.Forms.ToolStripMenuItem();
         this._menuCutPlane2DCell = new System.Windows.Forms.ToolStripMenuItem();
         this._menuDoubleCutPlane2DCell = new System.Windows.Forms.ToolStripMenuItem();
         this._actionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._menuActionWindowLevel = new System.Windows.Forms.ToolStripMenuItem();
         this._menuActionAlpha = new System.Windows.Forms.ToolStripMenuItem();
         this._menuActionScale = new System.Windows.Forms.ToolStripMenuItem();
         this._menuActionMagnify = new System.Windows.Forms.ToolStripMenuItem();
         this._menuActionPan = new System.Windows.Forms.ToolStripMenuItem();
         this._menuActionRotate = new System.Windows.Forms.ToolStripMenuItem();
         this._menuActionPanoramicPolygon = new System.Windows.Forms.ToolStripMenuItem();
         this._menuActionProbeTool = new System.Windows.Forms.ToolStripMenuItem();
         this._menuReferenceLine = new System.Windows.Forms.ToolStripMenuItem();
         this._menuShowReferenceLine = new System.Windows.Forms.ToolStripMenuItem();
         this._menuShowReferenceBoundaries = new System.Windows.Forms.ToolStripMenuItem();
         this._menuShowAllReferenceLines = new System.Windows.Forms.ToolStripMenuItem();
         this._menuShowFirstAndLastReferenceLines = new System.Windows.Forms.ToolStripMenuItem();
         this._menuMPRLayout = new System.Windows.Forms.ToolStripMenuItem();
         this._menuShowCrossHair = new System.Windows.Forms.ToolStripMenuItem();
         this._menuColoredCrossHair = new System.Windows.Forms.ToolStripMenuItem();
         this._menuShowSlab = new System.Windows.Forms.ToolStripMenuItem();
         this._helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._menuAbout = new System.Windows.Forms.ToolStripMenuItem();
         this._printCellMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.nudgeToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.setToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.shrinkToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.setToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
         this.customizeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
         this._miEffectInvert = new System.Windows.Forms.ToolStripMenuItem();
         this._mainPanel = new System.Windows.Forms.Panel();
         this._displayPanel = new System.Windows.Forms.Panel();
         this._rightClickToolStrip = new System.Windows.Forms.ToolStrip();
         this._deleteGeneratorDropMenu = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemShowOptionsDeleteGenerator = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemShowOptionsSetGeneratorColor = new System.Windows.Forms.ToolStripMenuItem();
         this._cellRightClickMenu = new System.Windows.Forms.ToolStripMenuItem();
         this._rightClickWindowLevel = new System.Windows.Forms.ToolStripMenuItem();
         this._rightClickAlpha = new System.Windows.Forms.ToolStripMenuItem();
         this._rightClickScale = new System.Windows.Forms.ToolStripMenuItem();
         this._rightClickMagnify = new System.Windows.Forms.ToolStripMenuItem();
         this._rightClickPan = new System.Windows.Forms.ToolStripMenuItem();
         this._rightClickRotate = new System.Windows.Forms.ToolStripMenuItem();
         this._rightClickCellReferenceColor = new System.Windows.Forms.ToolStripMenuItem();
         this._rightClickProbeTool = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
         this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
         this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
         this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
         this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
         this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
         this._panoramicRightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
         this._panoramicRightClickCreateParaxialCell = new System.Windows.Forms.ToolStripMenuItem();
         this._panoramicRightClickSeperator1 = new System.Windows.Forms.ToolStripSeparator();
         this._panoramicRightClickInsertPoint = new System.Windows.Forms.ToolStripMenuItem();
         this._panoramicRightClickDeletePoint = new System.Windows.Forms.ToolStripMenuItem();
         this._panoramicRightClickSeperator3 = new System.Windows.Forms.ToolStripSeparator();
         this._panoramicRightClickPolygonColor = new System.Windows.Forms.ToolStripMenuItem();
         this._panoramicRightClickDeletePolygon = new System.Windows.Forms.ToolStripMenuItem();
         this._panoramicRightClickSeperator2 = new System.Windows.Forms.ToolStripSeparator();
         this._panoramicRightClickParaxialLineColor = new System.Windows.Forms.ToolStripMenuItem();
         this._panoramicRightClickActiveParaxialColor = new System.Windows.Forms.ToolStripMenuItem();
         this._panoramicRightClickParaxialProperties = new System.Windows.Forms.ToolStripMenuItem();
         this._panoramicRightClickDeleteParaxialCell = new System.Windows.Forms.ToolStripMenuItem();
         this._mainMenu.SuspendLayout();
         this._mainPanel.SuspendLayout();
         this._displayPanel.SuspendLayout();
         this._rightClickToolStrip.SuspendLayout();
         this._panoramicRightClickMenu.SuspendLayout();
         this.SuspendLayout();
         // 
         // _mainMenu
         // 
         this._mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuFile,
            this._menuEdit,
            this._menuView,
            this._menuCellType,
            this._actionsMenuItem,
            this._menuReferenceLine,
            this._menuMPRLayout,
            this._helpMenuItem});
         resources.ApplyResources(this._mainMenu, "_mainMenu");
         this._mainMenu.Name = "_mainMenu";
         // 
         // _menuFile
         // 
         this._menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemFileLoadDICOM,
            this._menuItemFileLoadDICOMDIR,
            this._menuItemHardwareCheck,
            this._menuUnload,
            this.toolStripSeparator1,
            this._loadMeshMenu,
            this._saveMeshMenu,
            this._saveMPR,
            this._save3DImage,
            this._loadObjectStatusMenu,
            this._saveObjectStatusMenu,
            this._menuLoadObject,
            this._menuSaveRawData,
            this.toolStripSeparator3,
            this._menuFile_exit});
         this._menuFile.Name = "_menuFile";
         resources.ApplyResources(this._menuFile, "_menuFile");
         this._menuFile.DropDownOpening += new System.EventHandler(this._menuFile_DropDownOpening);
         // 
         // _menuItemFileLoadDICOM
         // 
         this._menuItemFileLoadDICOM.Name = "_menuItemFileLoadDICOM";
         resources.ApplyResources(this._menuItemFileLoadDICOM, "_menuItemFileLoadDICOM");
         this._menuItemFileLoadDICOM.Click += new System.EventHandler(this._menuItemFileLoadDICOM_Click);
         // 
         // _menuItemFileLoadDICOMDIR
         // 
         this._menuItemFileLoadDICOMDIR.Name = "_menuItemFileLoadDICOMDIR";
         resources.ApplyResources(this._menuItemFileLoadDICOMDIR, "_menuItemFileLoadDICOMDIR");
         this._menuItemFileLoadDICOMDIR.Click += new System.EventHandler(this._menuItemFileLoadDICOMDIR_Click);
         // 
         // _menuItemHardwareCheck
         // 
         this._menuItemHardwareCheck.Name = "_menuItemHardwareCheck";
         resources.ApplyResources(this._menuItemHardwareCheck, "_menuItemHardwareCheck");
         this._menuItemHardwareCheck.Click += new System.EventHandler(this._menuItemHardwareCheck_Click);
         // 
         // _menuUnload
         // 
         this._menuUnload.Name = "_menuUnload";
         resources.ApplyResources(this._menuUnload, "_menuUnload");
         this._menuUnload.Click += new System.EventHandler(this._menuUnload_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
         // 
         // _loadMeshMenu
         // 
         this._loadMeshMenu.Name = "_loadMeshMenu";
         resources.ApplyResources(this._loadMeshMenu, "_loadMeshMenu");
         this._loadMeshMenu.Click += new System.EventHandler(this._loadMeshMenu_Click);
         // 
         // _saveMeshMenu
         // 
         this._saveMeshMenu.Name = "_saveMeshMenu";
         resources.ApplyResources(this._saveMeshMenu, "_saveMeshMenu");
         this._saveMeshMenu.Click += new System.EventHandler(this._saveMeshMenu_Click);
         // 
         // _saveMPR
         // 
         this._saveMPR.Name = "_saveMPR";
         resources.ApplyResources(this._saveMPR, "_saveMPR");
         this._saveMPR.Click += new System.EventHandler(this._saveMPR_Click);
         // 
         // _save3DImage
         // 
         this._save3DImage.Name = "_save3DImage";
         resources.ApplyResources(this._save3DImage, "_save3DImage");
         this._save3DImage.Click += new System.EventHandler(this._save3DImage_Click);
         // 
         // _loadObjectStatusMenu
         // 
         this._loadObjectStatusMenu.Name = "_loadObjectStatusMenu";
         resources.ApplyResources(this._loadObjectStatusMenu, "_loadObjectStatusMenu");
         this._loadObjectStatusMenu.Click += new System.EventHandler(this._loadObjectStatusMenu_Click);
         // 
         // _saveObjectStatusMenu
         // 
         this._saveObjectStatusMenu.Name = "_saveObjectStatusMenu";
         resources.ApplyResources(this._saveObjectStatusMenu, "_saveObjectStatusMenu");
         this._saveObjectStatusMenu.Click += new System.EventHandler(this._saveObjectStatusMenu_Click);
         // 
         // _menuLoadObject
         // 
         this._menuLoadObject.Name = "_menuLoadObject";
         resources.ApplyResources(this._menuLoadObject, "_menuLoadObject");
         this._menuLoadObject.Click += new System.EventHandler(this._menuLoadObject_Click);
         // 
         // _menuSaveRawData
         // 
         this._menuSaveRawData.Name = "_menuSaveRawData";
         resources.ApplyResources(this._menuSaveRawData, "_menuSaveRawData");
         this._menuSaveRawData.Click += new System.EventHandler(this._menuSaveRawData_Click);
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
         // 
         // _menuFile_exit
         // 
         this._menuFile_exit.Name = "_menuFile_exit";
         resources.ApplyResources(this._menuFile_exit, "_menuFile_exit");
         this._menuFile_exit.Click += new System.EventHandler(this._menuFile_exit_Click);
         // 
         // _menuEdit
         // 
         this._menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._editColorMap,
            this._menuRemoveDensity,
            this._menuItemEditSSD,
            this.toolStripSeparator2,
            this._menuItemEditReset,
            this._menuDeleteAll,
            this.toolStripSeparator4,
            this.renderingToolStripMenuItem,
            this.renderingTypeToolStripMenuItem});
         this._menuEdit.Name = "_menuEdit";
         resources.ApplyResources(this._menuEdit, "_menuEdit");
         this._menuEdit.DropDownOpening += new System.EventHandler(this._menuEdit_DropDownOpening);
         // 
         // _editColorMap
         // 
         this._editColorMap.Name = "_editColorMap";
         resources.ApplyResources(this._editColorMap, "_editColorMap");
         this._editColorMap.Click += new System.EventHandler(this.dHistogramToolStripMenuItem_Click);
         // 
         // _menuRemoveDensity
         // 
         this._menuRemoveDensity.Name = "_menuRemoveDensity";
         resources.ApplyResources(this._menuRemoveDensity, "_menuRemoveDensity");
         this._menuRemoveDensity.Click += new System.EventHandler(this._menuRemoveDensity_Click);
         // 
         // _menuItemEditSSD
         // 
         this._menuItemEditSSD.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuSSDMeshColor,
            this._menuSSDIsoThreshold});
         this._menuItemEditSSD.Name = "_menuItemEditSSD";
         resources.ApplyResources(this._menuItemEditSSD, "_menuItemEditSSD");
         this._menuItemEditSSD.DropDownOpening += new System.EventHandler(this._menuItemEditSSD_DropDownOpening);
         // 
         // _menuSSDMeshColor
         // 
         this._menuSSDMeshColor.Name = "_menuSSDMeshColor";
         resources.ApplyResources(this._menuSSDMeshColor, "_menuSSDMeshColor");
         this._menuSSDMeshColor.Click += new System.EventHandler(this._menuSSDMeshColor_Click);
         // 
         // _menuSSDIsoThreshold
         // 
         this._menuSSDIsoThreshold.Name = "_menuSSDIsoThreshold";
         resources.ApplyResources(this._menuSSDIsoThreshold, "_menuSSDIsoThreshold");
         this._menuSSDIsoThreshold.Click += new System.EventHandler(this._menuSSDIsoThreshold_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
         // 
         // _menuItemEditReset
         // 
         this._menuItemEditReset.Name = "_menuItemEditReset";
         resources.ApplyResources(this._menuItemEditReset, "_menuItemEditReset");
         this._menuItemEditReset.Click += new System.EventHandler(this._menuItemEditReset_Click);
         // 
         // _menuDeleteAll
         // 
         this._menuDeleteAll.Name = "_menuDeleteAll";
         resources.ApplyResources(this._menuDeleteAll, "_menuDeleteAll");
         this._menuDeleteAll.Click += new System.EventHandler(this._menuDeleteAll_Click);
         // 
         // toolStripSeparator4
         // 
         this.toolStripSeparator4.Name = "toolStripSeparator4";
         resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
         // 
         // renderingToolStripMenuItem
         // 
         this.renderingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hardwareIfAvailbleToolStripMenuItem,
            this.softwareOnlyToolStripMenuItem});
         this.renderingToolStripMenuItem.Name = "renderingToolStripMenuItem";
         resources.ApplyResources(this.renderingToolStripMenuItem, "renderingToolStripMenuItem");
         // 
         // hardwareIfAvailbleToolStripMenuItem
         // 
         this.hardwareIfAvailbleToolStripMenuItem.Name = "hardwareIfAvailbleToolStripMenuItem";
         resources.ApplyResources(this.hardwareIfAvailbleToolStripMenuItem, "hardwareIfAvailbleToolStripMenuItem");
         this.hardwareIfAvailbleToolStripMenuItem.Click += new System.EventHandler(this.hardwareIfAvailbleToolStripMenuItem_Click);
         // 
         // softwareOnlyToolStripMenuItem
         // 
         this.softwareOnlyToolStripMenuItem.Name = "softwareOnlyToolStripMenuItem";
         resources.ApplyResources(this.softwareOnlyToolStripMenuItem, "softwareOnlyToolStripMenuItem");
         this.softwareOnlyToolStripMenuItem.Click += new System.EventHandler(this.softwareOnlyToolStripMenuItem_Click);
         // 
         // renderingTypeToolStripMenuItem
         // 
         this.renderingTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._texturing3D,
            this._texturing2D,
            this._texturingAuto});
         this.renderingTypeToolStripMenuItem.Name = "renderingTypeToolStripMenuItem";
         resources.ApplyResources(this.renderingTypeToolStripMenuItem, "renderingTypeToolStripMenuItem");
         this.renderingTypeToolStripMenuItem.DropDownOpening += new System.EventHandler(this.renderingTypeToolStripMenuItem_DropDownOpening);
         // 
         // _texturing3D
         // 
         this._texturing3D.Name = "_texturing3D";
         resources.ApplyResources(this._texturing3D, "_texturing3D");
         this._texturing3D.Click += new System.EventHandler(this._texturing3D_Click);
         // 
         // _texturing2D
         // 
         this._texturing2D.Name = "_texturing2D";
         resources.ApplyResources(this._texturing2D, "_texturing2D");
         this._texturing2D.Click += new System.EventHandler(this._texturing2D_Click);
         // 
         // _texturingAuto
         // 
         this._texturingAuto.Name = "_texturingAuto";
         resources.ApplyResources(this._texturingAuto, "_texturingAuto");
         this._texturingAuto.Click += new System.EventHandler(this._texturingAuto_Click);
         // 
         // _menuView
         // 
         this._menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._showMPRWindows,
            this._menuProperties,
            this._menuLayoutOptions,
            this._menuInvert,
            this._menuShowScrollBar});
         this._menuView.Name = "_menuView";
         resources.ApplyResources(this._menuView, "_menuView");
         this._menuView.DropDownOpening += new System.EventHandler(this._menuView_DropDownOpening);
         // 
         // _showMPRWindows
         // 
         this._showMPRWindows.Name = "_showMPRWindows";
         resources.ApplyResources(this._showMPRWindows, "_showMPRWindows");
         this._showMPRWindows.Click += new System.EventHandler(this._showMPRWindows_Click);
         // 
         // _menuProperties
         // 
         this._menuProperties.Name = "_menuProperties";
         resources.ApplyResources(this._menuProperties, "_menuProperties");
         this._menuProperties.Click += new System.EventHandler(this._menuProperties_Click);
         // 
         // _menuLayoutOptions
         // 
         this._menuLayoutOptions.Name = "_menuLayoutOptions";
         resources.ApplyResources(this._menuLayoutOptions, "_menuLayoutOptions");
         this._menuLayoutOptions.Click += new System.EventHandler(this._menuLayoutOptions_Click);
         // 
         // _menuInvert
         // 
         this._menuInvert.Name = "_menuInvert";
         resources.ApplyResources(this._menuInvert, "_menuInvert");
         this._menuInvert.Click += new System.EventHandler(this._menuInvert_Click);
         // 
         // _menuShowScrollBar
         // 
         this._menuShowScrollBar.Name = "_menuShowScrollBar";
         resources.ApplyResources(this._menuShowScrollBar, "_menuShowScrollBar");
         this._menuShowScrollBar.Click += new System.EventHandler(this._menuShowScrollBar_Click);
         // 
         // _menuCellType
         // 
         this._menuCellType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuVolumeVRT,
            this._menuVolumeMIP,
            this._menuVolumeMPR,
            this._menuVolumeMinIP,
            this._menuVolumeSSD,
            this._menu2DCell,
            this._menuCutPlane2DCell,
            this._menuDoubleCutPlane2DCell});
         this._menuCellType.Name = "_menuCellType";
         resources.ApplyResources(this._menuCellType, "_menuCellType");
         this._menuCellType.DropDownOpening += new System.EventHandler(this._menuCellType_DropDownOpening);
         // 
         // _menuVolumeVRT
         // 
         this._menuVolumeVRT.Name = "_menuVolumeVRT";
         resources.ApplyResources(this._menuVolumeVRT, "_menuVolumeVRT");
         this._menuVolumeVRT.Click += new System.EventHandler(this._menuVolumeVRT_Click);
         // 
         // _menuVolumeMIP
         // 
         this._menuVolumeMIP.Name = "_menuVolumeMIP";
         resources.ApplyResources(this._menuVolumeMIP, "_menuVolumeMIP");
         this._menuVolumeMIP.Click += new System.EventHandler(this._menuVolumeMIP_Click);
         // 
         // _menuVolumeMPR
         // 
         this._menuVolumeMPR.Name = "_menuVolumeMPR";
         resources.ApplyResources(this._menuVolumeMPR, "_menuVolumeMPR");
         this._menuVolumeMPR.Click += new System.EventHandler(this._menuVolumeMPR_Click);
         // 
         // _menuVolumeMinIP
         // 
         this._menuVolumeMinIP.Name = "_menuVolumeMinIP";
         resources.ApplyResources(this._menuVolumeMinIP, "_menuVolumeMinIP");
         this._menuVolumeMinIP.Click += new System.EventHandler(this._menuVolumeMinIP_Click);
         // 
         // _menuVolumeSSD
         // 
         this._menuVolumeSSD.Name = "_menuVolumeSSD";
         resources.ApplyResources(this._menuVolumeSSD, "_menuVolumeSSD");
         this._menuVolumeSSD.Click += new System.EventHandler(this._menuVolumeSSD_Click);
         // 
         // _menu2DCell
         // 
         this._menu2DCell.Name = "_menu2DCell";
         resources.ApplyResources(this._menu2DCell, "_menu2DCell");
         this._menu2DCell.Click += new System.EventHandler(this._menu2DCell_Click);
         // 
         // _menuCutPlane2DCell
         // 
         this._menuCutPlane2DCell.Name = "_menuCutPlane2DCell";
         resources.ApplyResources(this._menuCutPlane2DCell, "_menuCutPlane2DCell");
         this._menuCutPlane2DCell.Click += new System.EventHandler(this._menuCutPlane2DCell_Click);
         // 
         // _menuDoubleCutPlane2DCell
         // 
         this._menuDoubleCutPlane2DCell.Name = "_menuDoubleCutPlane2DCell";
         resources.ApplyResources(this._menuDoubleCutPlane2DCell, "_menuDoubleCutPlane2DCell");
         this._menuDoubleCutPlane2DCell.Click += new System.EventHandler(this._menuDoubleCutPlane2DCell_Click);
         // 
         // _actionsMenuItem
         // 
         this._actionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuActionWindowLevel,
            this._menuActionAlpha,
            this._menuActionScale,
            this._menuActionMagnify,
            this._menuActionPan,
            this._menuActionRotate,
            this._menuActionPanoramicPolygon,
            this._menuActionProbeTool});
         this._actionsMenuItem.Name = "_actionsMenuItem";
         resources.ApplyResources(this._actionsMenuItem, "_actionsMenuItem");
         this._actionsMenuItem.DropDownOpening += new System.EventHandler(this._actionsMenuItem_DropDownOpening);
         // 
         // _menuActionWindowLevel
         // 
         this._menuActionWindowLevel.Name = "_menuActionWindowLevel";
         resources.ApplyResources(this._menuActionWindowLevel, "_menuActionWindowLevel");
         this._menuActionWindowLevel.Click += new System.EventHandler(this._menuActionWindowLevel_Click);
         // 
         // _menuActionAlpha
         // 
         this._menuActionAlpha.Name = "_menuActionAlpha";
         resources.ApplyResources(this._menuActionAlpha, "_menuActionAlpha");
         this._menuActionAlpha.Click += new System.EventHandler(this._menuActionAlpha_Click);
         // 
         // _menuActionScale
         // 
         this._menuActionScale.Name = "_menuActionScale";
         resources.ApplyResources(this._menuActionScale, "_menuActionScale");
         this._menuActionScale.Click += new System.EventHandler(this._menuActionScale_Click);
         // 
         // _menuActionMagnify
         // 
         this._menuActionMagnify.Name = "_menuActionMagnify";
         resources.ApplyResources(this._menuActionMagnify, "_menuActionMagnify");
         this._menuActionMagnify.Click += new System.EventHandler(this._menuActionMagnify_Click);
         // 
         // _menuActionPan
         // 
         this._menuActionPan.Name = "_menuActionPan";
         resources.ApplyResources(this._menuActionPan, "_menuActionPan");
         this._menuActionPan.Click += new System.EventHandler(this._menuActionPan_Click);
         // 
         // _menuActionRotate
         // 
         this._menuActionRotate.Name = "_menuActionRotate";
         resources.ApplyResources(this._menuActionRotate, "_menuActionRotate");
         this._menuActionRotate.Click += new System.EventHandler(this._menuActionRotate_Click);
         // 
         // _menuActionPanoramicPolygon
         // 
         this._menuActionPanoramicPolygon.Name = "_menuActionPanoramicPolygon";
         resources.ApplyResources(this._menuActionPanoramicPolygon, "_menuActionPanoramicPolygon");
         this._menuActionPanoramicPolygon.Click += new System.EventHandler(this._menuActionPanoramicPolygon_Click);
         // 
         // _menuActionProbeTool
         // 
         this._menuActionProbeTool.Name = "_menuActionProbeTool";
         resources.ApplyResources(this._menuActionProbeTool, "_menuActionProbeTool");
         this._menuActionProbeTool.Click += new System.EventHandler(this._menuActionProbeTool_Click);
         // 
         // _menuReferenceLine
         // 
         this._menuReferenceLine.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuShowReferenceLine,
            this._menuShowReferenceBoundaries,
            this._menuShowAllReferenceLines,
            this._menuShowFirstAndLastReferenceLines});
         this._menuReferenceLine.Name = "_menuReferenceLine";
         resources.ApplyResources(this._menuReferenceLine, "_menuReferenceLine");
         this._menuReferenceLine.DropDownOpening += new System.EventHandler(this._menuReferenceLine_DropDownOpening);
         // 
         // _menuShowReferenceLine
         // 
         this._menuShowReferenceLine.Name = "_menuShowReferenceLine";
         resources.ApplyResources(this._menuShowReferenceLine, "_menuShowReferenceLine");
         this._menuShowReferenceLine.Click += new System.EventHandler(this._menuShowReferenceLine_Click);
         // 
         // _menuShowReferenceBoundaries
         // 
         this._menuShowReferenceBoundaries.Name = "_menuShowReferenceBoundaries";
         resources.ApplyResources(this._menuShowReferenceBoundaries, "_menuShowReferenceBoundaries");
         this._menuShowReferenceBoundaries.Click += new System.EventHandler(this._menuShowReferenceBoundaries_Click);
         // 
         // _menuShowAllReferenceLines
         // 
         this._menuShowAllReferenceLines.Name = "_menuShowAllReferenceLines";
         resources.ApplyResources(this._menuShowAllReferenceLines, "_menuShowAllReferenceLines");
         this._menuShowAllReferenceLines.Click += new System.EventHandler(this._menuShowAllReferenceLines_Click);
         // 
         // _menuShowFirstAndLastReferenceLines
         // 
         this._menuShowFirstAndLastReferenceLines.Name = "_menuShowFirstAndLastReferenceLines";
         resources.ApplyResources(this._menuShowFirstAndLastReferenceLines, "_menuShowFirstAndLastReferenceLines");
         this._menuShowFirstAndLastReferenceLines.Click += new System.EventHandler(this._menuShowFirstAndLastReferenceLines_Click);
         // 
         // _menuMPRLayout
         // 
         this._menuMPRLayout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuShowCrossHair,
            this._menuColoredCrossHair,
            this._menuShowSlab});
         resources.ApplyResources(this._menuMPRLayout, "_menuMPRLayout");
         this._menuMPRLayout.Name = "_menuMPRLayout";
         // 
         // _menuShowCrossHair
         // 
         this._menuShowCrossHair.Name = "_menuShowCrossHair";
         resources.ApplyResources(this._menuShowCrossHair, "_menuShowCrossHair");
         this._menuShowCrossHair.Click += new System.EventHandler(this._menuShowCrossHair_Click);
         // 
         // _menuColoredCrossHair
         // 
         this._menuColoredCrossHair.Name = "_menuColoredCrossHair";
         resources.ApplyResources(this._menuColoredCrossHair, "_menuColoredCrossHair");
         this._menuColoredCrossHair.Click += new System.EventHandler(this._menuColoredCrossHair_Click);
         // 
         // _menuShowSlab
         // 
         this._menuShowSlab.Name = "_menuShowSlab";
         resources.ApplyResources(this._menuShowSlab, "_menuShowSlab");
         this._menuShowSlab.Click += new System.EventHandler(this._menuShowSlab_Click);
         // 
         // _helpMenuItem
         // 
         this._helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuAbout});
         this._helpMenuItem.Name = "_helpMenuItem";
         resources.ApplyResources(this._helpMenuItem, "_helpMenuItem");
         // 
         // _menuAbout
         // 
         this._menuAbout.Name = "_menuAbout";
         resources.ApplyResources(this._menuAbout, "_menuAbout");
         this._menuAbout.Click += new System.EventHandler(this._menuAbout_Click);
         // 
         // _printCellMenuItem
         // 
         this._printCellMenuItem.Name = "_printCellMenuItem";
         resources.ApplyResources(this._printCellMenuItem, "_printCellMenuItem");
         // 
         // nudgeToolToolStripMenuItem
         // 
         this.nudgeToolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setToolStripMenuItem,
            this.customizeToolStripMenuItem});
         this.nudgeToolToolStripMenuItem.Name = "nudgeToolToolStripMenuItem";
         resources.ApplyResources(this.nudgeToolToolStripMenuItem, "nudgeToolToolStripMenuItem");
         // 
         // setToolStripMenuItem
         // 
         this.setToolStripMenuItem.Name = "setToolStripMenuItem";
         resources.ApplyResources(this.setToolStripMenuItem, "setToolStripMenuItem");
         // 
         // customizeToolStripMenuItem
         // 
         this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
         resources.ApplyResources(this.customizeToolStripMenuItem, "customizeToolStripMenuItem");
         // 
         // shrinkToolToolStripMenuItem
         // 
         this.shrinkToolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setToolStripMenuItem1,
            this.customizeToolStripMenuItem1});
         this.shrinkToolToolStripMenuItem.Name = "shrinkToolToolStripMenuItem";
         resources.ApplyResources(this.shrinkToolToolStripMenuItem, "shrinkToolToolStripMenuItem");
         // 
         // setToolStripMenuItem1
         // 
         this.setToolStripMenuItem1.Name = "setToolStripMenuItem1";
         resources.ApplyResources(this.setToolStripMenuItem1, "setToolStripMenuItem1");
         // 
         // customizeToolStripMenuItem1
         // 
         this.customizeToolStripMenuItem1.Name = "customizeToolStripMenuItem1";
         resources.ApplyResources(this.customizeToolStripMenuItem1, "customizeToolStripMenuItem1");
         // 
         // _miEffectInvert
         // 
         this._miEffectInvert.Name = "_miEffectInvert";
         resources.ApplyResources(this._miEffectInvert, "_miEffectInvert");
         // 
         // _mainPanel
         // 
         this._mainPanel.Controls.Add(this._displayPanel);
         resources.ApplyResources(this._mainPanel, "_mainPanel");
         this._mainPanel.Name = "_mainPanel";
         this._mainPanel.SizeChanged += new System.EventHandler(this._mainPanel_SizeChanged);
         // 
         // _displayPanel
         // 
         this._displayPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
         this._displayPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._displayPanel.Controls.Add(this._rightClickToolStrip);
         resources.ApplyResources(this._displayPanel, "_displayPanel");
         this._displayPanel.Name = "_displayPanel";
         // 
         // _rightClickToolStrip
         // 
         this._rightClickToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._deleteGeneratorDropMenu,
            this._cellRightClickMenu,
            this.toolStripButton1});
         resources.ApplyResources(this._rightClickToolStrip, "_rightClickToolStrip");
         this._rightClickToolStrip.Name = "_rightClickToolStrip";
         // 
         // _deleteGeneratorDropMenu
         // 
         this._deleteGeneratorDropMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemShowOptionsDeleteGenerator,
            this._menuItemShowOptionsSetGeneratorColor});
         this._deleteGeneratorDropMenu.Name = "_deleteGeneratorDropMenu";
         resources.ApplyResources(this._deleteGeneratorDropMenu, "_deleteGeneratorDropMenu");
         // 
         // _menuItemShowOptionsDeleteGenerator
         // 
         this._menuItemShowOptionsDeleteGenerator.Name = "_menuItemShowOptionsDeleteGenerator";
         resources.ApplyResources(this._menuItemShowOptionsDeleteGenerator, "_menuItemShowOptionsDeleteGenerator");
         this._menuItemShowOptionsDeleteGenerator.Click += new System.EventHandler(this._menuItemShowOptionsDeleteGenerator_Click);
         // 
         // _menuItemShowOptionsSetGeneratorColor
         // 
         this._menuItemShowOptionsSetGeneratorColor.Name = "_menuItemShowOptionsSetGeneratorColor";
         resources.ApplyResources(this._menuItemShowOptionsSetGeneratorColor, "_menuItemShowOptionsSetGeneratorColor");
         this._menuItemShowOptionsSetGeneratorColor.Click += new System.EventHandler(this._menuItemShowOptionsSetGeneratorColor_Click);
         // 
         // _cellRightClickMenu
         // 
         this._cellRightClickMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._rightClickWindowLevel,
            this._rightClickAlpha,
            this._rightClickScale,
            this._rightClickMagnify,
            this._rightClickPan,
            this._rightClickRotate,
            this._rightClickCellReferenceColor,
            this._rightClickProbeTool});
         this._cellRightClickMenu.Name = "_cellRightClickMenu";
         resources.ApplyResources(this._cellRightClickMenu, "_cellRightClickMenu");
         // 
         // _rightClickWindowLevel
         // 
         this._rightClickWindowLevel.Name = "_rightClickWindowLevel";
         resources.ApplyResources(this._rightClickWindowLevel, "_rightClickWindowLevel");
         this._rightClickWindowLevel.Click += new System.EventHandler(this._menuActionWindowLevel_Click);
         // 
         // _rightClickAlpha
         // 
         this._rightClickAlpha.Name = "_rightClickAlpha";
         resources.ApplyResources(this._rightClickAlpha, "_rightClickAlpha");
         this._rightClickAlpha.Click += new System.EventHandler(this._menuActionAlpha_Click);
         // 
         // _rightClickScale
         // 
         this._rightClickScale.Name = "_rightClickScale";
         resources.ApplyResources(this._rightClickScale, "_rightClickScale");
         this._rightClickScale.Click += new System.EventHandler(this._menuActionScale_Click);
         // 
         // _rightClickMagnify
         // 
         this._rightClickMagnify.Name = "_rightClickMagnify";
         resources.ApplyResources(this._rightClickMagnify, "_rightClickMagnify");
         this._rightClickMagnify.Click += new System.EventHandler(this._menuActionMagnify_Click);
         // 
         // _rightClickPan
         // 
         this._rightClickPan.Name = "_rightClickPan";
         resources.ApplyResources(this._rightClickPan, "_rightClickPan");
         this._rightClickPan.Click += new System.EventHandler(this._menuActionPan_Click);
         // 
         // _rightClickRotate
         // 
         this._rightClickRotate.Name = "_rightClickRotate";
         resources.ApplyResources(this._rightClickRotate, "_rightClickRotate");
         this._rightClickRotate.Click += new System.EventHandler(this._menuActionRotate_Click);
         // 
         // _rightClickCellReferenceColor
         // 
         this._rightClickCellReferenceColor.Name = "_rightClickCellReferenceColor";
         resources.ApplyResources(this._rightClickCellReferenceColor, "_rightClickCellReferenceColor");
         this._rightClickCellReferenceColor.Click += new System.EventHandler(this._rightClickCellReferenceColor_Click);
         // 
         // _rightClickProbeTool
         // 
         this._rightClickProbeTool.Name = "_rightClickProbeTool";
         resources.ApplyResources(this._rightClickProbeTool, "_rightClickProbeTool");
         this._rightClickProbeTool.Click += new System.EventHandler(this._menuActionProbeTool_Click);
         // 
         // toolStripButton1
         // 
         this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
         this.toolStripButton1.Name = "toolStripButton1";
         // 
         // BottomToolStripPanel
         // 
         resources.ApplyResources(this.BottomToolStripPanel, "BottomToolStripPanel");
         this.BottomToolStripPanel.Name = "BottomToolStripPanel";
         this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
         this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
         // 
         // TopToolStripPanel
         // 
         resources.ApplyResources(this.TopToolStripPanel, "TopToolStripPanel");
         this.TopToolStripPanel.Name = "TopToolStripPanel";
         this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
         this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
         // 
         // RightToolStripPanel
         // 
         resources.ApplyResources(this.RightToolStripPanel, "RightToolStripPanel");
         this.RightToolStripPanel.Name = "RightToolStripPanel";
         this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
         this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
         // 
         // LeftToolStripPanel
         // 
         resources.ApplyResources(this.LeftToolStripPanel, "LeftToolStripPanel");
         this.LeftToolStripPanel.Name = "LeftToolStripPanel";
         this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
         this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
         // 
         // ContentPanel
         // 
         resources.ApplyResources(this.ContentPanel, "ContentPanel");
         // 
         // _panoramicRightClickMenu
         // 
         this._panoramicRightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._panoramicRightClickCreateParaxialCell,
            this._panoramicRightClickSeperator1,
            this._panoramicRightClickInsertPoint,
            this._panoramicRightClickDeletePoint,
            this._panoramicRightClickSeperator3,
            this._panoramicRightClickPolygonColor,
            this._panoramicRightClickDeletePolygon,
            this._panoramicRightClickSeperator2,
            this._panoramicRightClickParaxialLineColor,
            this._panoramicRightClickActiveParaxialColor,
            this._panoramicRightClickParaxialProperties,
            this._panoramicRightClickDeleteParaxialCell});
         this._panoramicRightClickMenu.Name = "_panoramicRightClickMenu";
         resources.ApplyResources(this._panoramicRightClickMenu, "_panoramicRightClickMenu");
         // 
         // _panoramicRightClickCreateParaxialCell
         // 
         this._panoramicRightClickCreateParaxialCell.Name = "_panoramicRightClickCreateParaxialCell";
         resources.ApplyResources(this._panoramicRightClickCreateParaxialCell, "_panoramicRightClickCreateParaxialCell");
         this._panoramicRightClickCreateParaxialCell.Click += new System.EventHandler(this._panoramicRightClickCreateParaxialCell_Click);
         // 
         // _panoramicRightClickSeperator1
         // 
         this._panoramicRightClickSeperator1.Name = "_panoramicRightClickSeperator1";
         resources.ApplyResources(this._panoramicRightClickSeperator1, "_panoramicRightClickSeperator1");
         // 
         // _panoramicRightClickInsertPoint
         // 
         this._panoramicRightClickInsertPoint.Name = "_panoramicRightClickInsertPoint";
         resources.ApplyResources(this._panoramicRightClickInsertPoint, "_panoramicRightClickInsertPoint");
         this._panoramicRightClickInsertPoint.Click += new System.EventHandler(this._panoramicRightClickInsertPoint_Click);
         // 
         // _panoramicRightClickDeletePoint
         // 
         this._panoramicRightClickDeletePoint.Name = "_panoramicRightClickDeletePoint";
         resources.ApplyResources(this._panoramicRightClickDeletePoint, "_panoramicRightClickDeletePoint");
         this._panoramicRightClickDeletePoint.Click += new System.EventHandler(this._panoramicRightClickDeletePoint_Click);
         // 
         // _panoramicRightClickSeperator3
         // 
         this._panoramicRightClickSeperator3.Name = "_panoramicRightClickSeperator3";
         resources.ApplyResources(this._panoramicRightClickSeperator3, "_panoramicRightClickSeperator3");
         // 
         // _panoramicRightClickPolygonColor
         // 
         this._panoramicRightClickPolygonColor.Name = "_panoramicRightClickPolygonColor";
         resources.ApplyResources(this._panoramicRightClickPolygonColor, "_panoramicRightClickPolygonColor");
         this._panoramicRightClickPolygonColor.Click += new System.EventHandler(this._panoramicRightClickPolygonColor_Click);
         // 
         // _panoramicRightClickDeletePolygon
         // 
         this._panoramicRightClickDeletePolygon.Name = "_panoramicRightClickDeletePolygon";
         resources.ApplyResources(this._panoramicRightClickDeletePolygon, "_panoramicRightClickDeletePolygon");
         this._panoramicRightClickDeletePolygon.Click += new System.EventHandler(this._panoramicRightClickDeletePolygon_Click);
         // 
         // _panoramicRightClickSeperator2
         // 
         this._panoramicRightClickSeperator2.Name = "_panoramicRightClickSeperator2";
         resources.ApplyResources(this._panoramicRightClickSeperator2, "_panoramicRightClickSeperator2");
         // 
         // _panoramicRightClickParaxialLineColor
         // 
         this._panoramicRightClickParaxialLineColor.Name = "_panoramicRightClickParaxialLineColor";
         resources.ApplyResources(this._panoramicRightClickParaxialLineColor, "_panoramicRightClickParaxialLineColor");
         this._panoramicRightClickParaxialLineColor.Click += new System.EventHandler(this._panoramicRightClickParaxialLineColor_Click);
         // 
         // _panoramicRightClickActiveParaxialColor
         // 
         this._panoramicRightClickActiveParaxialColor.Name = "_panoramicRightClickActiveParaxialColor";
         resources.ApplyResources(this._panoramicRightClickActiveParaxialColor, "_panoramicRightClickActiveParaxialColor");
         this._panoramicRightClickActiveParaxialColor.Click += new System.EventHandler(this._panoramicRightClickActiveParaxialColor_Click);
         // 
         // _panoramicRightClickParaxialProperties
         // 
         this._panoramicRightClickParaxialProperties.Name = "_panoramicRightClickParaxialProperties";
         resources.ApplyResources(this._panoramicRightClickParaxialProperties, "_panoramicRightClickParaxialProperties");
         this._panoramicRightClickParaxialProperties.Click += new System.EventHandler(this._panoramicRightClickParaxialProperties_Click);
         // 
         // _panoramicRightClickDeleteParaxialCell
         // 
         this._panoramicRightClickDeleteParaxialCell.Name = "_panoramicRightClickDeleteParaxialCell";
         resources.ApplyResources(this._panoramicRightClickDeleteParaxialCell, "_panoramicRightClickDeleteParaxialCell");
         this._panoramicRightClickDeleteParaxialCell.Click += new System.EventHandler(this._panoramicRightClickDeleteParaxialCell_Click);
         // 
         // MainForm
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._mainPanel);
         this.Controls.Add(this._mainMenu);
         this.MainMenuStrip = this._mainMenu;
         this.Name = "MainForm";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.Load += new System.EventHandler(this.MainForm_Load);
         this._mainMenu.ResumeLayout(false);
         this._mainMenu.PerformLayout();
         this._mainPanel.ResumeLayout(false);
         this._displayPanel.ResumeLayout(false);
         this._displayPanel.PerformLayout();
         this._rightClickToolStrip.ResumeLayout(false);
         this._rightClickToolStrip.PerformLayout();
         this._panoramicRightClickMenu.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }


      #endregion

      private System.Windows.Forms.MenuStrip _mainMenu;
       private System.Windows.Forms.ToolStripMenuItem _menuFile;
      private System.Windows.Forms.ToolStripMenuItem _menuEdit;
       private System.Windows.Forms.ToolStripMenuItem _helpMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _menuFile_exit;
       private System.Windows.Forms.Panel _mainPanel;
       private System.Windows.Forms.ToolStripMenuItem _miEffectInvert;
      private System.Windows.Forms.ToolStripMenuItem _printCellMenuItem;
      private System.Windows.Forms.ToolStripMenuItem nudgeToolToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem shrinkToolToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem1;
       private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem1;
       private System.Windows.Forms.ToolStripMenuItem _menuItemFileLoadDICOM;
      private System.Windows.Forms.ToolStripMenuItem _menuItemFileLoadDICOMDIR;
       private System.Windows.Forms.ToolStripMenuItem _menuCellType;
       private System.Windows.Forms.ToolStripMenuItem _menuVolumeMPR;
       private System.Windows.Forms.ToolStripMenuItem _menuVolumeVRT;
       private System.Windows.Forms.ToolStripMenuItem _menuVolumeMIP;
       private System.Windows.Forms.ToolStripMenuItem _menuAbout;
       private System.Windows.Forms.Panel _displayPanel;
       private System.Windows.Forms.ToolStrip _rightClickToolStrip;
       private System.Windows.Forms.ToolStripMenuItem _cellRightClickMenu;
       private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
       private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
       private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
       private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
       private System.Windows.Forms.ToolStripContentPanel ContentPanel;
      private System.Windows.Forms.ToolStripMenuItem _actionsMenuItem;
       private System.Windows.Forms.ToolStripMenuItem _menuActionWindowLevel;
       private System.Windows.Forms.ToolStripMenuItem _menuActionAlpha;
       private System.Windows.Forms.ToolStripMenuItem _menuActionRotate;
       private System.Windows.Forms.ToolStripMenuItem _deleteGeneratorDropMenu;
      private System.Windows.Forms.ToolStripButton toolStripButton1;
      private System.Windows.Forms.ToolStripMenuItem _menuItemShowOptionsDeleteGenerator;
      private System.Windows.Forms.ToolStripMenuItem _menuItemEditSSD;
      private System.Windows.Forms.ToolStripMenuItem _menuSSDMeshColor;
       private System.Windows.Forms.ToolStripMenuItem _menuVolumeSSD;
      private System.Windows.Forms.ToolStripMenuItem _menuSSDIsoThreshold;
       private System.Windows.Forms.ToolStripMenuItem _menuActionScale;
       private System.Windows.Forms.ToolStripMenuItem _menuActionMagnify;
       private System.Windows.Forms.ToolStripMenuItem _menuActionPan;
       private System.Windows.Forms.ToolStripMenuItem _menuItemEditReset;
       private System.Windows.Forms.ToolStripMenuItem _menuItemShowOptionsSetGeneratorColor;
       private System.Windows.Forms.ToolStripMenuItem _rightClickWindowLevel;
       private System.Windows.Forms.ToolStripMenuItem _rightClickAlpha;
       private System.Windows.Forms.ToolStripMenuItem _rightClickScale;
       private System.Windows.Forms.ToolStripMenuItem _rightClickMagnify;
       private System.Windows.Forms.ToolStripMenuItem _rightClickPan;
       private System.Windows.Forms.ToolStripMenuItem _rightClickRotate;
       private System.Windows.Forms.ToolStripMenuItem _rightClickCellReferenceColor;
       private System.Windows.Forms.ToolStripMenuItem _menuRemoveDensity;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
       private System.Windows.Forms.ToolStripMenuItem _menuItemHardwareCheck;
       private ToolStripSeparator toolStripSeparator1;
       private ToolStripMenuItem _saveMeshMenu;
       private ToolStripMenuItem _loadObjectStatusMenu;
       private ToolStripMenuItem _saveObjectStatusMenu;
       private ToolStripMenuItem _menuLoadObject;
       private ToolStripMenuItem _menuSaveRawData;
       private ToolStripMenuItem _loadMeshMenu;
       private ToolStripMenuItem _menu2DCell;
       private ToolStripMenuItem _menuCutPlane2DCell;
       private ToolStripMenuItem _menuDoubleCutPlane2DCell;
       private ToolStripMenuItem _menuReferenceLine;
       private ToolStripMenuItem _menuShowReferenceLine;
       private ToolStripMenuItem _menuShowReferenceBoundaries;
       private ToolStripMenuItem _menuMPRLayout;
       private ToolStripMenuItem _menuShowCrossHair;
       private ToolStripMenuItem _menuColoredCrossHair;
       private ToolStripMenuItem _menuShowSlab;
       private ToolStripMenuItem _menuView;
       private ToolStripMenuItem _showMPRWindows;
       private ToolStripMenuItem _menuProperties;
       private ToolStripMenuItem _menuLayoutOptions;
       private ToolStripMenuItem _menuInvert;
       private ToolStripMenuItem _menuShowScrollBar;
       private ToolStripMenuItem _menuUnload;
       private ToolStripMenuItem _menuDeleteAll;
       private ToolStripMenuItem _menuVolumeMinIP;
       private ToolStripMenuItem _menuActionPanoramicPolygon;
       private ContextMenuStrip _panoramicRightClickMenu;
       private ToolStripMenuItem _panoramicRightClickCreateParaxialCell;
       private ToolStripSeparator _panoramicRightClickSeperator1;
       private ToolStripMenuItem _panoramicRightClickInsertPoint;
       private ToolStripMenuItem _panoramicRightClickDeletePoint;
       private ToolStripSeparator _panoramicRightClickSeperator2;
       private ToolStripMenuItem _panoramicRightClickParaxialLineColor;
       private ToolStripMenuItem _panoramicRightClickActiveParaxialColor;
       private ToolStripMenuItem _panoramicRightClickPolygonColor;
       private ToolStripSeparator _panoramicRightClickSeperator3;
       private ToolStripMenuItem _panoramicRightClickParaxialProperties;
       private ToolStripMenuItem _panoramicRightClickDeletePolygon;
       private ToolStripMenuItem _panoramicRightClickDeleteParaxialCell;
       private ToolStripMenuItem _menuShowAllReferenceLines;
       private ToolStripMenuItem _menuShowFirstAndLastReferenceLines;
       private ToolStripMenuItem _menuActionProbeTool;
       private ToolStripMenuItem _rightClickProbeTool;
       private ToolStripMenuItem _editColorMap;
       private ToolStripMenuItem _saveMPR;
       private ToolStripMenuItem _save3DImage;
      private ToolStripSeparator toolStripSeparator4;
      private ToolStripMenuItem renderingToolStripMenuItem;
      private ToolStripMenuItem hardwareIfAvailbleToolStripMenuItem;
      private ToolStripMenuItem softwareOnlyToolStripMenuItem;
      private ToolStripMenuItem renderingTypeToolStripMenuItem;
      private ToolStripMenuItem _texturing3D;
      private ToolStripMenuItem _texturing2D;
      private ToolStripMenuItem _texturingAuto;
   }
}

