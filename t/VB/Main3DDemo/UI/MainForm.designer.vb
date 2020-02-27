Imports System.Windows.Forms
Namespace Main3DDemo
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
         Me.components = New System.ComponentModel.Container()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me._mainMenu = New System.Windows.Forms.MenuStrip()
         Me._menuFile = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemFileLoadDICOM = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemFileLoadDICOMDIR = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemHardwareCheck = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuUnload = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
         Me._loadMeshMenu = New System.Windows.Forms.ToolStripMenuItem()
         Me._saveMeshMenu = New System.Windows.Forms.ToolStripMenuItem()
         Me._saveMPR = New System.Windows.Forms.ToolStripMenuItem()
         Me._save3DImage = New System.Windows.Forms.ToolStripMenuItem()
         Me._loadObjectStatusMenu = New System.Windows.Forms.ToolStripMenuItem()
         Me._saveObjectStatusMenu = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuLoadObject = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuSaveRawData = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuFile_exit = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuEdit = New System.Windows.Forms.ToolStripMenuItem()
         Me._editColorMap = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuRemoveDensity = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemEditSSD = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuSSDMeshColor = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuSSDIsoThreshold = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
         Me._menuItemEditReset = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuDeleteAll = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuView = New System.Windows.Forms.ToolStripMenuItem()
         Me._showMPRWindows = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuProperties = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuLayoutOptions = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuInvert = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuShowScrollBar = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuCellType = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuVolumeVRT = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuVolumeMIP = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuVolumeMPR = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuVolumeMinIP = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuVolumeSSD = New System.Windows.Forms.ToolStripMenuItem()
         Me._menu2DCell = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuCutPlane2DCell = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuDoubleCutPlane2DCell = New System.Windows.Forms.ToolStripMenuItem()
         Me._actionsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuActionWindowLevel = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuActionAlpha = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuActionScale = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuActionMagnify = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuActionPan = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuActionRotate = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuActionPanoramicPolygon = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuActionProbeTool = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuReferenceLine = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuShowReferenceLine = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuShowReferenceBoundaries = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuShowAllReferenceLines = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuShowFirstAndLastReferenceLines = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuMPRLayout = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuShowCrossHair = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuColoredCrossHair = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuShowSlab = New System.Windows.Forms.ToolStripMenuItem()
         Me._helpMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuAbout = New System.Windows.Forms.ToolStripMenuItem()
         Me._printCellMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.nudgeToolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.setToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.customizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.shrinkToolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me.setToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
         Me.customizeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
         Me._miEffectInvert = New System.Windows.Forms.ToolStripMenuItem()
         Me._mainPanel = New System.Windows.Forms.Panel()
         Me._displayPanel = New System.Windows.Forms.Panel()
         Me._rightClickToolStrip = New System.Windows.Forms.ToolStrip()
         Me._deleteGeneratorDropMenu = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemShowOptionsDeleteGenerator = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemShowOptionsSetGeneratorColor = New System.Windows.Forms.ToolStripMenuItem()
         Me._cellRightClickMenu = New System.Windows.Forms.ToolStripMenuItem()
         Me._rightClickWindowLevel = New System.Windows.Forms.ToolStripMenuItem()
         Me._rightClickAlpha = New System.Windows.Forms.ToolStripMenuItem()
         Me._rightClickScale = New System.Windows.Forms.ToolStripMenuItem()
         Me._rightClickMagnify = New System.Windows.Forms.ToolStripMenuItem()
         Me._rightClickPan = New System.Windows.Forms.ToolStripMenuItem()
         Me._rightClickRotate = New System.Windows.Forms.ToolStripMenuItem()
         Me._rightClickCellReferenceColor = New System.Windows.Forms.ToolStripMenuItem()
         Me._rightClickProbeTool = New System.Windows.Forms.ToolStripMenuItem()
         Me.toolStripButton1 = New System.Windows.Forms.ToolStripButton()
         Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel()
         Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel()
         Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel()
         Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel()
         Me.ContentPanel = New System.Windows.Forms.ToolStripContentPanel()
         Me._panoramicRightClickMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
         Me._panoramicRightClickCreateParaxialCell = New System.Windows.Forms.ToolStripMenuItem()
         Me._panoramicRightClickSeperator1 = New System.Windows.Forms.ToolStripSeparator()
         Me._panoramicRightClickInsertPoint = New System.Windows.Forms.ToolStripMenuItem()
         Me._panoramicRightClickDeletePoint = New System.Windows.Forms.ToolStripMenuItem()
         Me._panoramicRightClickSeperator3 = New System.Windows.Forms.ToolStripSeparator()
         Me._panoramicRightClickPolygonColor = New System.Windows.Forms.ToolStripMenuItem()
         Me._panoramicRightClickDeletePolygon = New System.Windows.Forms.ToolStripMenuItem()
         Me._panoramicRightClickSeperator2 = New System.Windows.Forms.ToolStripSeparator()
         Me._panoramicRightClickParaxialLineColor = New System.Windows.Forms.ToolStripMenuItem()
         Me._panoramicRightClickActiveParaxialColor = New System.Windows.Forms.ToolStripMenuItem()
         Me._panoramicRightClickParaxialProperties = New System.Windows.Forms.ToolStripMenuItem()
         Me._panoramicRightClickDeleteParaxialCell = New System.Windows.Forms.ToolStripMenuItem()
         Me._mainMenu.SuspendLayout()
         Me._mainPanel.SuspendLayout()
         Me._displayPanel.SuspendLayout()
         Me._rightClickToolStrip.SuspendLayout()
         Me._panoramicRightClickMenu.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _mainMenu
         ' 
         Me._mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuFile, Me._menuEdit, Me._menuView, Me._menuCellType, Me._actionsMenuItem, Me._menuReferenceLine, Me._menuMPRLayout, Me._helpMenuItem})
         resources.ApplyResources(Me._mainMenu, "_mainMenu")
         Me._mainMenu.Name = "_mainMenu"
         ' 
         ' _menuFile
         ' 
         Me._menuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemFileLoadDICOM, Me._menuItemFileLoadDICOMDIR, Me._menuItemHardwareCheck, Me._menuUnload, Me.toolStripSeparator1, Me._loadMeshMenu, Me._saveMeshMenu, Me._saveMPR, Me._save3DImage, Me._loadObjectStatusMenu, Me._saveObjectStatusMenu, Me._menuLoadObject, Me._menuSaveRawData, Me.toolStripSeparator3, Me._menuFile_exit})
         Me._menuFile.Name = "_menuFile"
         resources.ApplyResources(Me._menuFile, "_menuFile")
         ' 
         ' _menuItemFileLoadDICOM
         ' 
         Me._menuItemFileLoadDICOM.Name = "_menuItemFileLoadDICOM"
         resources.ApplyResources(Me._menuItemFileLoadDICOM, "_menuItemFileLoadDICOM")
         ' 
         ' _menuItemFileLoadDICOMDIR
         ' 
         Me._menuItemFileLoadDICOMDIR.Name = "_menuItemFileLoadDICOMDIR"
         resources.ApplyResources(Me._menuItemFileLoadDICOMDIR, "_menuItemFileLoadDICOMDIR")
         ' 
         ' _menuItemHardwareCheck
         ' 
         Me._menuItemHardwareCheck.Name = "_menuItemHardwareCheck"
         resources.ApplyResources(Me._menuItemHardwareCheck, "_menuItemHardwareCheck")
         ' 
         ' _menuUnload
         ' 
         Me._menuUnload.Name = "_menuUnload"
         resources.ApplyResources(Me._menuUnload, "_menuUnload")
         ' 
         ' toolStripSeparator1
         ' 
         Me.toolStripSeparator1.Name = "toolStripSeparator1"
         resources.ApplyResources(Me.toolStripSeparator1, "toolStripSeparator1")
         ' 
         ' _loadMeshMenu
         ' 
         Me._loadMeshMenu.Name = "_loadMeshMenu"
         resources.ApplyResources(Me._loadMeshMenu, "_loadMeshMenu")
         ' 
         ' _saveMeshMenu
         ' 
         Me._saveMeshMenu.Name = "_saveMeshMenu"
         resources.ApplyResources(Me._saveMeshMenu, "_saveMeshMenu")
         ' 
         ' _saveMPR
         ' 
         Me._saveMPR.Name = "_saveMPR"
         resources.ApplyResources(Me._saveMPR, "_saveMPR")
         ' 
         ' _save3DImage
         ' 
         Me._save3DImage.Name = "_save3DImage"
         resources.ApplyResources(Me._save3DImage, "_save3DImage")
         ' 
         ' _loadObjectStatusMenu
         ' 
         Me._loadObjectStatusMenu.Name = "_loadObjectStatusMenu"
         resources.ApplyResources(Me._loadObjectStatusMenu, "_loadObjectStatusMenu")
         ' 
         ' _saveObjectStatusMenu
         ' 
         Me._saveObjectStatusMenu.Name = "_saveObjectStatusMenu"
         resources.ApplyResources(Me._saveObjectStatusMenu, "_saveObjectStatusMenu")
         ' 
         ' _menuLoadObject
         ' 
         Me._menuLoadObject.Name = "_menuLoadObject"
         resources.ApplyResources(Me._menuLoadObject, "_menuLoadObject")
         ' 
         ' _menuSaveRawData
         ' 
         Me._menuSaveRawData.Name = "_menuSaveRawData"
         resources.ApplyResources(Me._menuSaveRawData, "_menuSaveRawData")
         ' 
         ' toolStripSeparator3
         ' 
         Me.toolStripSeparator3.Name = "toolStripSeparator3"
         resources.ApplyResources(Me.toolStripSeparator3, "toolStripSeparator3")
         ' 
         ' _menuFile_exit
         ' 
         Me._menuFile_exit.Name = "_menuFile_exit"
         resources.ApplyResources(Me._menuFile_exit, "_menuFile_exit")
         ' 
         ' _menuEdit
         ' 
         Me._menuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._editColorMap, Me._menuRemoveDensity, Me._menuItemEditSSD, Me.toolStripSeparator2, Me._menuItemEditReset, Me._menuDeleteAll})
         Me._menuEdit.Name = "_menuEdit"
         resources.ApplyResources(Me._menuEdit, "_menuEdit")
         ' 
         ' _editColorMap
         ' 
         Me._editColorMap.Name = "_editColorMap"
         resources.ApplyResources(Me._editColorMap, "_editColorMap")
         ' 
         ' _menuRemoveDensity
         ' 
         Me._menuRemoveDensity.Name = "_menuRemoveDensity"
         resources.ApplyResources(Me._menuRemoveDensity, "_menuRemoveDensity")
         ' 
         ' _menuItemEditSSD
         ' 
         Me._menuItemEditSSD.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuSSDMeshColor, Me._menuSSDIsoThreshold})
         Me._menuItemEditSSD.Name = "_menuItemEditSSD"
         resources.ApplyResources(Me._menuItemEditSSD, "_menuItemEditSSD")
         ' 
         ' _menuSSDMeshColor
         ' 
         Me._menuSSDMeshColor.Name = "_menuSSDMeshColor"
         resources.ApplyResources(Me._menuSSDMeshColor, "_menuSSDMeshColor")
         ' 
         ' _menuSSDIsoThreshold
         ' 
         Me._menuSSDIsoThreshold.Name = "_menuSSDIsoThreshold"
         resources.ApplyResources(Me._menuSSDIsoThreshold, "_menuSSDIsoThreshold")
         ' 
         ' toolStripSeparator2
         ' 
         Me.toolStripSeparator2.Name = "toolStripSeparator2"
         resources.ApplyResources(Me.toolStripSeparator2, "toolStripSeparator2")
         ' 
         ' _menuItemEditReset
         ' 
         Me._menuItemEditReset.Name = "_menuItemEditReset"
         resources.ApplyResources(Me._menuItemEditReset, "_menuItemEditReset")
         ' 
         ' _menuDeleteAll
         ' 
         Me._menuDeleteAll.Name = "_menuDeleteAll"
         resources.ApplyResources(Me._menuDeleteAll, "_menuDeleteAll")
         ' 
         ' _menuView
         ' 
         Me._menuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._showMPRWindows, Me._menuProperties, Me._menuLayoutOptions, Me._menuInvert, Me._menuShowScrollBar})
         Me._menuView.Name = "_menuView"
         resources.ApplyResources(Me._menuView, "_menuView")
         ' 
         ' _showMPRWindows
         ' 
         Me._showMPRWindows.Name = "_showMPRWindows"
         resources.ApplyResources(Me._showMPRWindows, "_showMPRWindows")
         ' 
         ' _menuProperties
         ' 
         Me._menuProperties.Name = "_menuProperties"
         resources.ApplyResources(Me._menuProperties, "_menuProperties")
         ' 
         ' _menuLayoutOptions
         ' 
         Me._menuLayoutOptions.Name = "_menuLayoutOptions"
         resources.ApplyResources(Me._menuLayoutOptions, "_menuLayoutOptions")
         ' 
         ' _menuInvert
         ' 
         Me._menuInvert.Name = "_menuInvert"
         resources.ApplyResources(Me._menuInvert, "_menuInvert")
         ' 
         ' _menuShowScrollBar
         ' 
         Me._menuShowScrollBar.Name = "_menuShowScrollBar"
         resources.ApplyResources(Me._menuShowScrollBar, "_menuShowScrollBar")
         ' 
         ' _menuCellType
         ' 
         Me._menuCellType.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuVolumeVRT, Me._menuVolumeMIP, Me._menuVolumeMPR, Me._menuVolumeMinIP, Me._menuVolumeSSD, Me._menu2DCell, Me._menuCutPlane2DCell, Me._menuDoubleCutPlane2DCell})
         Me._menuCellType.Name = "_menuCellType"
         resources.ApplyResources(Me._menuCellType, "_menuCellType")
         ' 
         ' _menuVolumeVRT
         ' 
         Me._menuVolumeVRT.Name = "_menuVolumeVRT"
         resources.ApplyResources(Me._menuVolumeVRT, "_menuVolumeVRT")
         ' 
         ' _menuVolumeMIP
         ' 
         Me._menuVolumeMIP.Name = "_menuVolumeMIP"
         resources.ApplyResources(Me._menuVolumeMIP, "_menuVolumeMIP")
         ' 
         ' _menuVolumeMPR
         ' 
         Me._menuVolumeMPR.Name = "_menuVolumeMPR"
         resources.ApplyResources(Me._menuVolumeMPR, "_menuVolumeMPR")
         ' 
         ' _menuVolumeMinIP
         ' 
         Me._menuVolumeMinIP.Name = "_menuVolumeMinIP"
         resources.ApplyResources(Me._menuVolumeMinIP, "_menuVolumeMinIP")
         ' 
         ' _menuVolumeSSD
         ' 
         Me._menuVolumeSSD.Name = "_menuVolumeSSD"
         resources.ApplyResources(Me._menuVolumeSSD, "_menuVolumeSSD")
         ' 
         ' _menu2DCell
         ' 
         Me._menu2DCell.Name = "_menu2DCell"
         resources.ApplyResources(Me._menu2DCell, "_menu2DCell")
         ' 
         ' _menuCutPlane2DCell
         ' 
         Me._menuCutPlane2DCell.Name = "_menuCutPlane2DCell"
         resources.ApplyResources(Me._menuCutPlane2DCell, "_menuCutPlane2DCell")
         ' 
         ' _menuDoubleCutPlane2DCell
         ' 
         Me._menuDoubleCutPlane2DCell.Name = "_menuDoubleCutPlane2DCell"
         resources.ApplyResources(Me._menuDoubleCutPlane2DCell, "_menuDoubleCutPlane2DCell")
         ' 
         ' _actionsMenuItem
         ' 
         Me._actionsMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuActionWindowLevel, Me._menuActionAlpha, Me._menuActionScale, Me._menuActionMagnify, Me._menuActionPan, Me._menuActionRotate, Me._menuActionPanoramicPolygon, Me._menuActionProbeTool})
         Me._actionsMenuItem.Name = "_actionsMenuItem"
         resources.ApplyResources(Me._actionsMenuItem, "_actionsMenuItem")
         ' 
         ' _menuActionWindowLevel
         ' 
         Me._menuActionWindowLevel.Name = "_menuActionWindowLevel"
         resources.ApplyResources(Me._menuActionWindowLevel, "_menuActionWindowLevel")
         ' 
         ' _menuActionAlpha
         ' 
         Me._menuActionAlpha.Name = "_menuActionAlpha"
         resources.ApplyResources(Me._menuActionAlpha, "_menuActionAlpha")
         ' 
         ' _menuActionScale
         ' 
         Me._menuActionScale.Name = "_menuActionScale"
         resources.ApplyResources(Me._menuActionScale, "_menuActionScale")
         ' 
         ' _menuActionMagnify
         ' 
         Me._menuActionMagnify.Name = "_menuActionMagnify"
         resources.ApplyResources(Me._menuActionMagnify, "_menuActionMagnify")
         ' 
         ' _menuActionPan
         ' 
         Me._menuActionPan.Name = "_menuActionPan"
         resources.ApplyResources(Me._menuActionPan, "_menuActionPan")
         ' 
         ' _menuActionRotate
         ' 
         Me._menuActionRotate.Name = "_menuActionRotate"
         resources.ApplyResources(Me._menuActionRotate, "_menuActionRotate")
         ' 
         ' _menuActionPanoramicPolygon
         ' 
         Me._menuActionPanoramicPolygon.Name = "_menuActionPanoramicPolygon"
         resources.ApplyResources(Me._menuActionPanoramicPolygon, "_menuActionPanoramicPolygon")
         ' 
         ' _menuActionProbeTool
         ' 
         Me._menuActionProbeTool.Name = "_menuActionProbeTool"
         resources.ApplyResources(Me._menuActionProbeTool, "_menuActionProbeTool")
         ' 
         ' _menuReferenceLine
         ' 
         Me._menuReferenceLine.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuShowReferenceLine, Me._menuShowReferenceBoundaries, Me._menuShowAllReferenceLines, Me._menuShowFirstAndLastReferenceLines})
         Me._menuReferenceLine.Name = "_menuReferenceLine"
         resources.ApplyResources(Me._menuReferenceLine, "_menuReferenceLine")
         ' 
         ' _menuShowReferenceLine
         ' 
         Me._menuShowReferenceLine.Name = "_menuShowReferenceLine"
         resources.ApplyResources(Me._menuShowReferenceLine, "_menuShowReferenceLine")
         ' 
         ' _menuShowReferenceBoundaries
         ' 
         Me._menuShowReferenceBoundaries.Name = "_menuShowReferenceBoundaries"
         resources.ApplyResources(Me._menuShowReferenceBoundaries, "_menuShowReferenceBoundaries")
         ' 
         ' _menuShowAllReferenceLines
         ' 
         Me._menuShowAllReferenceLines.Name = "_menuShowAllReferenceLines"
         resources.ApplyResources(Me._menuShowAllReferenceLines, "_menuShowAllReferenceLines")
         ' 
         ' _menuShowFirstAndLastReferenceLines
         ' 
         Me._menuShowFirstAndLastReferenceLines.Name = "_menuShowFirstAndLastReferenceLines"
         resources.ApplyResources(Me._menuShowFirstAndLastReferenceLines, "_menuShowFirstAndLastReferenceLines")
         ' 
         ' _menuMPRLayout
         ' 
         Me._menuMPRLayout.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuShowCrossHair, Me._menuColoredCrossHair, Me._menuShowSlab})
         resources.ApplyResources(Me._menuMPRLayout, "_menuMPRLayout")
         Me._menuMPRLayout.Name = "_menuMPRLayout"
         ' 
         ' _menuShowCrossHair
         ' 
         Me._menuShowCrossHair.Name = "_menuShowCrossHair"
         resources.ApplyResources(Me._menuShowCrossHair, "_menuShowCrossHair")
         ' 
         ' _menuColoredCrossHair
         ' 
         Me._menuColoredCrossHair.Name = "_menuColoredCrossHair"
         resources.ApplyResources(Me._menuColoredCrossHair, "_menuColoredCrossHair")
         ' 
         ' _menuShowSlab
         ' 
         Me._menuShowSlab.Name = "_menuShowSlab"
         resources.ApplyResources(Me._menuShowSlab, "_menuShowSlab")
         ' 
         ' _helpMenuItem
         ' 
         Me._helpMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuAbout})
         Me._helpMenuItem.Name = "_helpMenuItem"
         resources.ApplyResources(Me._helpMenuItem, "_helpMenuItem")
         ' 
         ' _menuAbout
         ' 
         Me._menuAbout.Name = "_menuAbout"
         resources.ApplyResources(Me._menuAbout, "_menuAbout")
         ' 
         ' _printCellMenuItem
         ' 
         Me._printCellMenuItem.Name = "_printCellMenuItem"
         resources.ApplyResources(Me._printCellMenuItem, "_printCellMenuItem")
         ' 
         ' nudgeToolToolStripMenuItem
         ' 
         Me.nudgeToolToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.setToolStripMenuItem, Me.customizeToolStripMenuItem})
         Me.nudgeToolToolStripMenuItem.Name = "nudgeToolToolStripMenuItem"
         resources.ApplyResources(Me.nudgeToolToolStripMenuItem, "nudgeToolToolStripMenuItem")
         ' 
         ' setToolStripMenuItem
         ' 
         Me.setToolStripMenuItem.Name = "setToolStripMenuItem"
         resources.ApplyResources(Me.setToolStripMenuItem, "setToolStripMenuItem")
         ' 
         ' customizeToolStripMenuItem
         ' 
         Me.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem"
         resources.ApplyResources(Me.customizeToolStripMenuItem, "customizeToolStripMenuItem")
         ' 
         ' shrinkToolToolStripMenuItem
         ' 
         Me.shrinkToolToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.setToolStripMenuItem1, Me.customizeToolStripMenuItem1})
         Me.shrinkToolToolStripMenuItem.Name = "shrinkToolToolStripMenuItem"
         resources.ApplyResources(Me.shrinkToolToolStripMenuItem, "shrinkToolToolStripMenuItem")
         ' 
         ' setToolStripMenuItem1
         ' 
         Me.setToolStripMenuItem1.Name = "setToolStripMenuItem1"
         resources.ApplyResources(Me.setToolStripMenuItem1, "setToolStripMenuItem1")
         ' 
         ' customizeToolStripMenuItem1
         ' 
         Me.customizeToolStripMenuItem1.Name = "customizeToolStripMenuItem1"
         resources.ApplyResources(Me.customizeToolStripMenuItem1, "customizeToolStripMenuItem1")
         ' 
         ' _miEffectInvert
         ' 
         Me._miEffectInvert.Name = "_miEffectInvert"
         resources.ApplyResources(Me._miEffectInvert, "_miEffectInvert")
         ' 
         ' _mainPanel
         ' 
         Me._mainPanel.Controls.Add(Me._displayPanel)
         resources.ApplyResources(Me._mainPanel, "_mainPanel")
         Me._mainPanel.Name = "_mainPanel"
         ' 
         ' _displayPanel
         ' 
         Me._displayPanel.BackColor = System.Drawing.SystemColors.ActiveBorder
         Me._displayPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._displayPanel.Controls.Add(Me._rightClickToolStrip)
         resources.ApplyResources(Me._displayPanel, "_displayPanel")
         Me._displayPanel.Name = "_displayPanel"
         ' 
         ' _rightClickToolStrip
         ' 
         Me._rightClickToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._deleteGeneratorDropMenu, Me._cellRightClickMenu, Me.toolStripButton1})
         resources.ApplyResources(Me._rightClickToolStrip, "_rightClickToolStrip")
         Me._rightClickToolStrip.Name = "_rightClickToolStrip"
         ' 
         ' _deleteGeneratorDropMenu
         ' 
         Me._deleteGeneratorDropMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemShowOptionsDeleteGenerator, Me._menuItemShowOptionsSetGeneratorColor})
         Me._deleteGeneratorDropMenu.Name = "_deleteGeneratorDropMenu"
         resources.ApplyResources(Me._deleteGeneratorDropMenu, "_deleteGeneratorDropMenu")
         ' 
         ' _menuItemShowOptionsDeleteGenerator
         ' 
         Me._menuItemShowOptionsDeleteGenerator.Name = "_menuItemShowOptionsDeleteGenerator"
         resources.ApplyResources(Me._menuItemShowOptionsDeleteGenerator, "_menuItemShowOptionsDeleteGenerator")
         ' 
         ' _menuItemShowOptionsSetGeneratorColor
         ' 
         Me._menuItemShowOptionsSetGeneratorColor.Name = "_menuItemShowOptionsSetGeneratorColor"
         resources.ApplyResources(Me._menuItemShowOptionsSetGeneratorColor, "_menuItemShowOptionsSetGeneratorColor")
         ' 
         ' _cellRightClickMenu
         ' 
         Me._cellRightClickMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._rightClickWindowLevel, Me._rightClickAlpha, Me._rightClickScale, Me._rightClickMagnify, Me._rightClickPan, Me._rightClickRotate, Me._rightClickCellReferenceColor, Me._rightClickProbeTool})
         Me._cellRightClickMenu.Name = "_cellRightClickMenu"
         resources.ApplyResources(Me._cellRightClickMenu, "_cellRightClickMenu")
         ' 
         ' _rightClickWindowLevel
         ' 
         Me._rightClickWindowLevel.Name = "_rightClickWindowLevel"
         resources.ApplyResources(Me._rightClickWindowLevel, "_rightClickWindowLevel")
         ' 
         ' _rightClickAlpha
         ' 
         Me._rightClickAlpha.Name = "_rightClickAlpha"
         resources.ApplyResources(Me._rightClickAlpha, "_rightClickAlpha")
         ' 
         ' _rightClickScale
         ' 
         Me._rightClickScale.Name = "_rightClickScale"
         resources.ApplyResources(Me._rightClickScale, "_rightClickScale")
         ' 
         ' _rightClickMagnify
         ' 
         Me._rightClickMagnify.Name = "_rightClickMagnify"
         resources.ApplyResources(Me._rightClickMagnify, "_rightClickMagnify")
         ' 
         ' _rightClickPan
         ' 
         Me._rightClickPan.Name = "_rightClickPan"
         resources.ApplyResources(Me._rightClickPan, "_rightClickPan")
         ' 
         ' _rightClickRotate
         ' 
         Me._rightClickRotate.Name = "_rightClickRotate"
         resources.ApplyResources(Me._rightClickRotate, "_rightClickRotate")
         ' 
         ' _rightClickCellReferenceColor
         ' 
         Me._rightClickCellReferenceColor.Name = "_rightClickCellReferenceColor"
         resources.ApplyResources(Me._rightClickCellReferenceColor, "_rightClickCellReferenceColor")
         ' 
         ' _rightClickProbeTool
         ' 
         Me._rightClickProbeTool.Name = "_rightClickProbeTool"
         resources.ApplyResources(Me._rightClickProbeTool, "_rightClickProbeTool")
         ' 
         ' toolStripButton1
         ' 
         Me.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         resources.ApplyResources(Me.toolStripButton1, "toolStripButton1")
         Me.toolStripButton1.Name = "toolStripButton1"
         ' 
         ' BottomToolStripPanel
         ' 
         resources.ApplyResources(Me.BottomToolStripPanel, "BottomToolStripPanel")
         Me.BottomToolStripPanel.Name = "BottomToolStripPanel"
         Me.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
         Me.BottomToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
         ' 
         ' TopToolStripPanel
         ' 
         resources.ApplyResources(Me.TopToolStripPanel, "TopToolStripPanel")
         Me.TopToolStripPanel.Name = "TopToolStripPanel"
         Me.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
         Me.TopToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
         ' 
         ' RightToolStripPanel
         ' 
         resources.ApplyResources(Me.RightToolStripPanel, "RightToolStripPanel")
         Me.RightToolStripPanel.Name = "RightToolStripPanel"
         Me.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
         Me.RightToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
         ' 
         ' LeftToolStripPanel
         ' 
         resources.ApplyResources(Me.LeftToolStripPanel, "LeftToolStripPanel")
         Me.LeftToolStripPanel.Name = "LeftToolStripPanel"
         Me.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
         Me.LeftToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
         ' 
         ' ContentPanel
         ' 
         resources.ApplyResources(Me.ContentPanel, "ContentPanel")
         ' 
         ' _panoramicRightClickMenu
         ' 
         Me._panoramicRightClickMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._panoramicRightClickCreateParaxialCell, Me._panoramicRightClickSeperator1, Me._panoramicRightClickInsertPoint, Me._panoramicRightClickDeletePoint, Me._panoramicRightClickSeperator3, Me._panoramicRightClickPolygonColor, Me._panoramicRightClickDeletePolygon, Me._panoramicRightClickSeperator2, Me._panoramicRightClickParaxialLineColor, Me._panoramicRightClickActiveParaxialColor, Me._panoramicRightClickParaxialProperties, Me._panoramicRightClickDeleteParaxialCell})
         Me._panoramicRightClickMenu.Name = "_panoramicRightClickMenu"
         resources.ApplyResources(Me._panoramicRightClickMenu, "_panoramicRightClickMenu")
         ' 
         ' _panoramicRightClickCreateParaxialCell
         ' 
         Me._panoramicRightClickCreateParaxialCell.Name = "_panoramicRightClickCreateParaxialCell"
         resources.ApplyResources(Me._panoramicRightClickCreateParaxialCell, "_panoramicRightClickCreateParaxialCell")
         ' 
         ' _panoramicRightClickSeperator1
         ' 
         Me._panoramicRightClickSeperator1.Name = "_panoramicRightClickSeperator1"
         resources.ApplyResources(Me._panoramicRightClickSeperator1, "_panoramicRightClickSeperator1")
         ' 
         ' _panoramicRightClickInsertPoint
         ' 
         Me._panoramicRightClickInsertPoint.Name = "_panoramicRightClickInsertPoint"
         resources.ApplyResources(Me._panoramicRightClickInsertPoint, "_panoramicRightClickInsertPoint")
         ' 
         ' _panoramicRightClickDeletePoint
         ' 
         Me._panoramicRightClickDeletePoint.Name = "_panoramicRightClickDeletePoint"
         resources.ApplyResources(Me._panoramicRightClickDeletePoint, "_panoramicRightClickDeletePoint")
         ' 
         ' _panoramicRightClickSeperator3
         ' 
         Me._panoramicRightClickSeperator3.Name = "_panoramicRightClickSeperator3"
         resources.ApplyResources(Me._panoramicRightClickSeperator3, "_panoramicRightClickSeperator3")
         ' 
         ' _panoramicRightClickPolygonColor
         ' 
         Me._panoramicRightClickPolygonColor.Name = "_panoramicRightClickPolygonColor"
         resources.ApplyResources(Me._panoramicRightClickPolygonColor, "_panoramicRightClickPolygonColor")
         ' 
         ' _panoramicRightClickDeletePolygon
         ' 
         Me._panoramicRightClickDeletePolygon.Name = "_panoramicRightClickDeletePolygon"
         resources.ApplyResources(Me._panoramicRightClickDeletePolygon, "_panoramicRightClickDeletePolygon")
         ' 
         ' _panoramicRightClickSeperator2
         ' 
         Me._panoramicRightClickSeperator2.Name = "_panoramicRightClickSeperator2"
         resources.ApplyResources(Me._panoramicRightClickSeperator2, "_panoramicRightClickSeperator2")
         ' 
         ' _panoramicRightClickParaxialLineColor
         ' 
         Me._panoramicRightClickParaxialLineColor.Name = "_panoramicRightClickParaxialLineColor"
         resources.ApplyResources(Me._panoramicRightClickParaxialLineColor, "_panoramicRightClickParaxialLineColor")
         ' 
         ' _panoramicRightClickActiveParaxialColor
         ' 
         Me._panoramicRightClickActiveParaxialColor.Name = "_panoramicRightClickActiveParaxialColor"
         resources.ApplyResources(Me._panoramicRightClickActiveParaxialColor, "_panoramicRightClickActiveParaxialColor")
         ' 
         ' _panoramicRightClickParaxialProperties
         ' 
         Me._panoramicRightClickParaxialProperties.Name = "_panoramicRightClickParaxialProperties"
         resources.ApplyResources(Me._panoramicRightClickParaxialProperties, "_panoramicRightClickParaxialProperties")
         ' 
         ' _panoramicRightClickDeleteParaxialCell
         ' 
         Me._panoramicRightClickDeleteParaxialCell.Name = "_panoramicRightClickDeleteParaxialCell"
         resources.ApplyResources(Me._panoramicRightClickDeleteParaxialCell, "_panoramicRightClickDeleteParaxialCell")
         ' 
         ' MainForm
         ' 
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me._mainPanel)
         Me.Controls.Add(Me._mainMenu)
         Me.MainMenuStrip = Me._mainMenu
         Me.Name = "MainForm"
         Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
         Me._mainMenu.ResumeLayout(False)
         Me._mainMenu.PerformLayout()
         Me._mainPanel.ResumeLayout(False)
         Me._displayPanel.ResumeLayout(False)
         Me._displayPanel.PerformLayout()
         Me._rightClickToolStrip.ResumeLayout(False)
         Me._rightClickToolStrip.PerformLayout()
         Me._panoramicRightClickMenu.ResumeLayout(False)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub


#End Region

      Private _mainMenu As System.Windows.Forms.MenuStrip
      Private WithEvents _menuFile As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuEdit As System.Windows.Forms.ToolStripMenuItem
      Private _helpMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuFile_exit As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mainPanel As System.Windows.Forms.Panel
      Private _miEffectInvert As System.Windows.Forms.ToolStripMenuItem
      Private _printCellMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private nudgeToolToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private setToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private customizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private shrinkToolToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private setToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
      Private customizeToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemFileLoadDICOM As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemFileLoadDICOMDIR As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuCellType As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuVolumeMPR As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuVolumeVRT As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuVolumeMIP As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuAbout As System.Windows.Forms.ToolStripMenuItem
      Private _displayPanel As System.Windows.Forms.Panel
      Private _rightClickToolStrip As System.Windows.Forms.ToolStrip
      Private _cellRightClickMenu As System.Windows.Forms.ToolStripMenuItem
      Private BottomToolStripPanel As System.Windows.Forms.ToolStripPanel
      Private TopToolStripPanel As System.Windows.Forms.ToolStripPanel
      Private RightToolStripPanel As System.Windows.Forms.ToolStripPanel
      Private LeftToolStripPanel As System.Windows.Forms.ToolStripPanel
      Private ContentPanel As System.Windows.Forms.ToolStripContentPanel
      Private WithEvents _actionsMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuActionWindowLevel As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuActionAlpha As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuActionRotate As System.Windows.Forms.ToolStripMenuItem
      Private _deleteGeneratorDropMenu As System.Windows.Forms.ToolStripMenuItem
      Private toolStripButton1 As System.Windows.Forms.ToolStripButton
      Private WithEvents _menuItemShowOptionsDeleteGenerator As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEditSSD As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuSSDMeshColor As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuVolumeSSD As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuSSDIsoThreshold As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuActionScale As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuActionMagnify As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuActionPan As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemEditReset As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemShowOptionsSetGeneratorColor As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _rightClickWindowLevel As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _rightClickAlpha As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _rightClickScale As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _rightClickMagnify As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _rightClickPan As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _rightClickRotate As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _rightClickCellReferenceColor As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuRemoveDensity As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
      Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _menuItemHardwareCheck As System.Windows.Forms.ToolStripMenuItem
      Private toolStripSeparator1 As ToolStripSeparator
      Private WithEvents _saveMeshMenu As ToolStripMenuItem
      Private WithEvents _loadObjectStatusMenu As ToolStripMenuItem
      Private WithEvents _saveObjectStatusMenu As ToolStripMenuItem
      Private WithEvents _menuLoadObject As ToolStripMenuItem
      Private WithEvents _menuSaveRawData As ToolStripMenuItem
      Private WithEvents _loadMeshMenu As ToolStripMenuItem
      Private WithEvents _menu2DCell As ToolStripMenuItem
      Private WithEvents _menuCutPlane2DCell As ToolStripMenuItem
      Private WithEvents _menuDoubleCutPlane2DCell As ToolStripMenuItem
      Private WithEvents _menuReferenceLine As ToolStripMenuItem
      Private WithEvents _menuShowReferenceLine As ToolStripMenuItem
      Private WithEvents _menuShowReferenceBoundaries As ToolStripMenuItem
      Private _menuMPRLayout As ToolStripMenuItem
      Private WithEvents _menuShowCrossHair As ToolStripMenuItem
      Private WithEvents _menuColoredCrossHair As ToolStripMenuItem
      Private WithEvents _menuShowSlab As ToolStripMenuItem
      Private WithEvents _menuView As ToolStripMenuItem
      Private WithEvents _showMPRWindows As ToolStripMenuItem
      Private WithEvents _menuProperties As ToolStripMenuItem
      Private WithEvents _menuLayoutOptions As ToolStripMenuItem
      Private WithEvents _menuInvert As ToolStripMenuItem
      Private WithEvents _menuShowScrollBar As ToolStripMenuItem
      Private WithEvents _menuUnload As ToolStripMenuItem
      Private WithEvents _menuDeleteAll As ToolStripMenuItem
      Private WithEvents _menuVolumeMinIP As ToolStripMenuItem
      Private WithEvents _menuActionPanoramicPolygon As ToolStripMenuItem
      Private _panoramicRightClickMenu As ContextMenuStrip
      Private WithEvents _panoramicRightClickCreateParaxialCell As ToolStripMenuItem
      Private _panoramicRightClickSeperator1 As ToolStripSeparator
      Private WithEvents _panoramicRightClickInsertPoint As ToolStripMenuItem
      Private WithEvents _panoramicRightClickDeletePoint As ToolStripMenuItem
      Private _panoramicRightClickSeperator2 As ToolStripSeparator
      Private WithEvents _panoramicRightClickParaxialLineColor As ToolStripMenuItem
      Private WithEvents _panoramicRightClickActiveParaxialColor As ToolStripMenuItem
      Private WithEvents _panoramicRightClickPolygonColor As ToolStripMenuItem
      Private _panoramicRightClickSeperator3 As ToolStripSeparator
      Private WithEvents _panoramicRightClickParaxialProperties As ToolStripMenuItem
      Private WithEvents _panoramicRightClickDeletePolygon As ToolStripMenuItem
      Private WithEvents _panoramicRightClickDeleteParaxialCell As ToolStripMenuItem
      Private WithEvents _menuShowAllReferenceLines As ToolStripMenuItem
      Private WithEvents _menuShowFirstAndLastReferenceLines As ToolStripMenuItem
      Private WithEvents _menuActionProbeTool As ToolStripMenuItem
      Private WithEvents _rightClickProbeTool As ToolStripMenuItem
      Private WithEvents _editColorMap As ToolStripMenuItem
      Private WithEvents _saveMPR As ToolStripMenuItem
      Private WithEvents _save3DImage As ToolStripMenuItem
   End Class
End Namespace

