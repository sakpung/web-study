' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Configuration
Imports System.Runtime.InteropServices
Imports System.IO

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Dicom
Imports Leadtools.Dicom.Common.Extensions
Imports Leadtools.Controls
Imports Leadtools.DicomDemos
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.Demos.Dialogs
Imports ImageProcessingDemo

Namespace DicomDemo
   ''' <summary>
   ''' Summary description for Form1.
   ''' </summary>
   Public Class MainForm : Inherits System.Windows.Forms.Form
      Private mainMenu1 As System.Windows.Forms.MainMenu
      Private menuItemTables As System.Windows.Forms.MenuItem
      Private menuItem5 As System.Windows.Forms.MenuItem
      Private WithEvents menuItemAbout As System.Windows.Forms.MenuItem
      Private WithEvents menuItemNew As System.Windows.Forms.MenuItem
      Private WithEvents menuItemOpen As System.Windows.Forms.MenuItem
      Private WithEvents menuItemClose As System.Windows.Forms.MenuItem
      Private menuItem6 As System.Windows.Forms.MenuItem
      Private WithEvents menuItemSave As System.Windows.Forms.MenuItem
      Private menuItem7 As System.Windows.Forms.MenuItem
      Private WithEvents menuItemInfo As System.Windows.Forms.MenuItem
      Private menuItem8 As System.Windows.Forms.MenuItem
      Private WithEvents menuItemExit As System.Windows.Forms.MenuItem
      Private WithEvents menuItemVR As System.Windows.Forms.MenuItem
      Private WithEvents menuItemUID As System.Windows.Forms.MenuItem
      Private WithEvents menuItemTag As System.Windows.Forms.MenuItem
      Private WithEvents menuItemIOD As System.Windows.Forms.MenuItem
      Private WithEvents menuItemGroups As System.Windows.Forms.MenuItem
      Private WithEvents menuItemElementInsert As System.Windows.Forms.MenuItem
      Private WithEvents menuItemElementDelete As System.Windows.Forms.MenuItem
      Private components As System.ComponentModel.IContainer
      Private panel1 As System.Windows.Forms.Panel
      Private panel2 As System.Windows.Forms.Panel
      Private splitter1 As System.Windows.Forms.Splitter
      Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
      Private WithEvents menuItemView As System.Windows.Forms.MenuItem
      Private WithEvents menuItemNormal As System.Windows.Forms.MenuItem
      Private WithEvents menuItemFit As System.Windows.Forms.MenuItem
      Private menuItem15 As System.Windows.Forms.MenuItem
      Private WithEvents menuItemZoom2 As System.Windows.Forms.MenuItem
      Private WithEvents menuItemZoom4 As System.Windows.Forms.MenuItem
      Private WithEvents menuItemZoomHalf As System.Windows.Forms.MenuItem
      Private WithEvents menuItemZoomFourth As System.Windows.Forms.MenuItem
      Private WithEvents menuItemAnimation As System.Windows.Forms.MenuItem
      Private menuItemZoomIn As System.Windows.Forms.MenuItem
      Private menuItemZoomOut As System.Windows.Forms.MenuItem
      Private WithEvents menuItemDataset As System.Windows.Forms.MenuItem
      Private imageList1 As System.Windows.Forms.ImageList
      Private WithEvents menuItemFile As System.Windows.Forms.MenuItem
      Private WithEvents menuItemProcessing As System.Windows.Forms.MenuItem
      Private menuItem3 As System.Windows.Forms.MenuItem
      Private WithEvents menuItemInvert As System.Windows.Forms.MenuItem
      Private WithEvents menuItemBrightness As System.Windows.Forms.MenuItem
      Private WithEvents menuItemContrast As System.Windows.Forms.MenuItem
      Private menuItemGrayscale As System.Windows.Forms.MenuItem
      Private WithEvents menuItemGrayscale8 As System.Windows.Forms.MenuItem
      Private WithEvents menuItemGrayscale12 As System.Windows.Forms.MenuItem
      Private WithEvents menuItemGrayscale16 As System.Windows.Forms.MenuItem

      Private ds As DicomDataSet
      Private WithEvents menuItemFlip As System.Windows.Forms.MenuItem
      Private WithEvents menuItemReverse As System.Windows.Forms.MenuItem
      Private WithEvents menuItemRotate As System.Windows.Forms.MenuItem
      Private menuItem1 As System.Windows.Forms.MenuItem
      Private WithEvents menuItemUpdate As System.Windows.Forms.MenuItem
      Private WithEvents menuItemPlay As System.Windows.Forms.MenuItem
      Private menuItem13 As System.Windows.Forms.MenuItem
      Private WithEvents menuItemFirst As System.Windows.Forms.MenuItem
      Private WithEvents menuItemNext As System.Windows.Forms.MenuItem
      Private WithEvents menuItemPrevious As System.Windows.Forms.MenuItem
      Private WithEvents menuItemLast As System.Windows.Forms.MenuItem
      Private propertyGridElement As System.Windows.Forms.PropertyGrid
      Private saveFileDialog1 As System.Windows.Forms.SaveFileDialog
      Private WithEvents menuItemEdit As System.Windows.Forms.MenuItem
      Private imgIndex As Integer = 0
      Private imageInfo As DicomImageInformation = Nothing

      Private _fileMenuEnabled As Boolean = False
      Private _viewMenuEnabled As Boolean = False
      Private _tablesMenuEnabled As Boolean = False
      Private _datasetMenuEnabled As Boolean = False
      Private _animationMenuEnabled As Boolean = False
      Private _processingMenuEnabled As Boolean = False

      Private wl As WindowLevel = New WindowLevel()
      Private tabControl1 As TabControl
      Private tabPage1 As TabPage
      Private WithEvents treeViewElements As TreeView
      Private panel3 As Panel
      Private textBoxValues As TextBox
      Private splitter3 As Splitter
      Private splitter2 As Splitter
      Private menuItem10 As MenuItem
      Private WithEvents menuItemListView As MenuItem
      Private WithEvents menuItemModuleView As MenuItem
      Private menuItem9 As MenuItem
      Private menuItem11 As MenuItem
      Friend WithEvents menuItemUnsharpMask As System.Windows.Forms.MenuItem
      Friend WithEvents menuItemViewHistogram As MenuItem

        Public isMonochrome1 As Boolean = True
        Public _toolTip As ToolTip

        Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
      Friend WithEvents menuItemModifyTables As System.Windows.Forms.MenuItem
      Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
      Friend WithEvents menuItemLoadXml As System.Windows.Forms.MenuItem
      Friend WithEvents menuItemSaveXml As System.Windows.Forms.MenuItem
      Friend WithEvents MenuItem17 As System.Windows.Forms.MenuItem
      Private listView As Boolean = True
      Friend WithEvents MenuItem21 As System.Windows.Forms.MenuItem
      Friend WithEvents menuItemSaveNativeDicomModel As System.Windows.Forms.MenuItem
      Friend WithEvents menuItemSaveNativeDicomOptions As System.Windows.Forms.MenuItem
      Friend WithEvents menuItemSaveNativeDicom As System.Windows.Forms.MenuItem
      Friend WithEvents menuItemSaveDicomJsonModel As System.Windows.Forms.MenuItem
      Friend WithEvents menuItemSaveJsonOptions As System.Windows.Forms.MenuItem
      Friend WithEvents menuItemSaveJson As System.Windows.Forms.MenuItem
      Friend WithEvents MenuItemLoadJson As System.Windows.Forms.MenuItem
      Friend WithEvents MenuItemOptions As MenuItem
      Friend WithEvents MenuItemOptionsLoad As MenuItem
      Private _openInitialPath As String = ""
      <DllImport("user32.dll")> _
      Shared Function GetKeyState(ByVal nVirtKey As Integer) As Short
      End Function

      Private Const VK_CONTROL As Integer = &H11

      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         Utils.EngineStartup()
            isMonochrome1 = False
            _toolTip = New ToolTip()
        End Sub

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            If Not components Is Nothing Then
               components.Dispose()
            End If
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
         Me.mainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
         Me.menuItemFile = New System.Windows.Forms.MenuItem()
         Me.menuItemNew = New System.Windows.Forms.MenuItem()
         Me.menuItemOpen = New System.Windows.Forms.MenuItem()
         Me.MenuItem12 = New System.Windows.Forms.MenuItem()
         Me.menuItemLoadXml = New System.Windows.Forms.MenuItem()
         Me.MenuItemLoadJson = New System.Windows.Forms.MenuItem()
         Me.MenuItem21 = New System.Windows.Forms.MenuItem()
         Me.menuItemSaveXml = New System.Windows.Forms.MenuItem()
         Me.menuItemSaveNativeDicomModel = New System.Windows.Forms.MenuItem()
         Me.menuItemSaveNativeDicomOptions = New System.Windows.Forms.MenuItem()
         Me.menuItemSaveNativeDicom = New System.Windows.Forms.MenuItem()
         Me.menuItemSaveDicomJsonModel = New System.Windows.Forms.MenuItem()
         Me.menuItemSaveJsonOptions = New System.Windows.Forms.MenuItem()
         Me.menuItemSaveJson = New System.Windows.Forms.MenuItem()
         Me.MenuItem17 = New System.Windows.Forms.MenuItem()
         Me.menuItemSave = New System.Windows.Forms.MenuItem()
         Me.menuItem6 = New System.Windows.Forms.MenuItem()
         Me.menuItemClose = New System.Windows.Forms.MenuItem()
         Me.menuItem7 = New System.Windows.Forms.MenuItem()
         Me.menuItemInfo = New System.Windows.Forms.MenuItem()
         Me.menuItem8 = New System.Windows.Forms.MenuItem()
         Me.menuItemExit = New System.Windows.Forms.MenuItem()
         Me.menuItemView = New System.Windows.Forms.MenuItem()
         Me.menuItemNormal = New System.Windows.Forms.MenuItem()
         Me.menuItemFit = New System.Windows.Forms.MenuItem()
         Me.menuItem15 = New System.Windows.Forms.MenuItem()
         Me.menuItemZoomIn = New System.Windows.Forms.MenuItem()
         Me.menuItemZoom2 = New System.Windows.Forms.MenuItem()
         Me.menuItemZoom4 = New System.Windows.Forms.MenuItem()
         Me.menuItemZoomOut = New System.Windows.Forms.MenuItem()
         Me.menuItemZoomHalf = New System.Windows.Forms.MenuItem()
         Me.menuItemZoomFourth = New System.Windows.Forms.MenuItem()
         Me.menuItemTables = New System.Windows.Forms.MenuItem()
         Me.menuItemVR = New System.Windows.Forms.MenuItem()
         Me.menuItemUID = New System.Windows.Forms.MenuItem()
         Me.menuItemTag = New System.Windows.Forms.MenuItem()
         Me.menuItemIOD = New System.Windows.Forms.MenuItem()
         Me.menuItemGroups = New System.Windows.Forms.MenuItem()
         Me.MenuItem2 = New System.Windows.Forms.MenuItem()
         Me.menuItemModifyTables = New System.Windows.Forms.MenuItem()
         Me.menuItemDataset = New System.Windows.Forms.MenuItem()
         Me.menuItemEdit = New System.Windows.Forms.MenuItem()
         Me.menuItem9 = New System.Windows.Forms.MenuItem()
         Me.menuItemElementInsert = New System.Windows.Forms.MenuItem()
         Me.menuItemElementDelete = New System.Windows.Forms.MenuItem()
         Me.menuItem11 = New System.Windows.Forms.MenuItem()
         Me.menuItemUpdate = New System.Windows.Forms.MenuItem()
         Me.menuItem10 = New System.Windows.Forms.MenuItem()
         Me.menuItemListView = New System.Windows.Forms.MenuItem()
         Me.menuItemModuleView = New System.Windows.Forms.MenuItem()
         Me.menuItemAnimation = New System.Windows.Forms.MenuItem()
         Me.menuItemPlay = New System.Windows.Forms.MenuItem()
         Me.menuItem13 = New System.Windows.Forms.MenuItem()
         Me.menuItemFirst = New System.Windows.Forms.MenuItem()
         Me.menuItemNext = New System.Windows.Forms.MenuItem()
         Me.menuItemPrevious = New System.Windows.Forms.MenuItem()
         Me.menuItemLast = New System.Windows.Forms.MenuItem()
         Me.menuItemProcessing = New System.Windows.Forms.MenuItem()
         Me.menuItemFlip = New System.Windows.Forms.MenuItem()
         Me.menuItemReverse = New System.Windows.Forms.MenuItem()
         Me.menuItemRotate = New System.Windows.Forms.MenuItem()
         Me.menuItem1 = New System.Windows.Forms.MenuItem()
         Me.menuItemGrayscale = New System.Windows.Forms.MenuItem()
         Me.menuItemGrayscale8 = New System.Windows.Forms.MenuItem()
         Me.menuItemGrayscale12 = New System.Windows.Forms.MenuItem()
         Me.menuItemGrayscale16 = New System.Windows.Forms.MenuItem()
         Me.menuItem3 = New System.Windows.Forms.MenuItem()
         Me.menuItemInvert = New System.Windows.Forms.MenuItem()
         Me.menuItemBrightness = New System.Windows.Forms.MenuItem()
         Me.menuItemContrast = New System.Windows.Forms.MenuItem()
         Me.menuItemUnsharpMask = New System.Windows.Forms.MenuItem()
         Me.menuItemViewHistogram = New System.Windows.Forms.MenuItem()
         Me.MenuItemOptions = New System.Windows.Forms.MenuItem()
         Me.MenuItemOptionsLoad = New System.Windows.Forms.MenuItem()
         Me.menuItem5 = New System.Windows.Forms.MenuItem()
         Me.menuItemAbout = New System.Windows.Forms.MenuItem()
         Me.panel1 = New System.Windows.Forms.Panel()
         Me.panel2 = New System.Windows.Forms.Panel()
         Me.panel3 = New System.Windows.Forms.Panel()
         Me.textBoxValues = New System.Windows.Forms.TextBox()
         Me.splitter3 = New System.Windows.Forms.Splitter()
         Me.propertyGridElement = New System.Windows.Forms.PropertyGrid()
         Me.splitter2 = New System.Windows.Forms.Splitter()
         Me.tabControl1 = New System.Windows.Forms.TabControl()
         Me.tabPage1 = New System.Windows.Forms.TabPage()
         Me.treeViewElements = New System.Windows.Forms.TreeView()
         Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
         Me.splitter1 = New System.Windows.Forms.Splitter()
         Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
         Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
         Me.panel2.SuspendLayout()
         Me.panel3.SuspendLayout()
         Me.tabControl1.SuspendLayout()
         Me.tabPage1.SuspendLayout()
         Me.SuspendLayout()
         '
         'mainMenu1
         '
         Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemFile, Me.menuItemView, Me.menuItemTables, Me.menuItemDataset, Me.menuItemAnimation, Me.menuItemProcessing, Me.MenuItemOptions, Me.menuItem5})
         '
         'menuItemFile
         '
         Me.menuItemFile.Index = 0
         Me.menuItemFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemNew, Me.menuItemOpen, Me.MenuItem12, Me.menuItemLoadXml, Me.MenuItemLoadJson, Me.MenuItem21, Me.menuItemSaveXml, Me.menuItemSaveNativeDicomModel, Me.menuItemSaveDicomJsonModel, Me.MenuItem17, Me.menuItemSave, Me.menuItem6, Me.menuItemClose, Me.menuItem7, Me.menuItemInfo, Me.menuItem8, Me.menuItemExit})
         Me.menuItemFile.Text = "&File"
         '
         'menuItemNew
         '
         Me.menuItemNew.Index = 0
         Me.menuItemNew.Text = "&New..."
         '
         'menuItemOpen
         '
         Me.menuItemOpen.Index = 1
         Me.menuItemOpen.Text = "&Open..."
         '
         'MenuItem12
         '
         Me.MenuItem12.Index = 2
         Me.MenuItem12.Text = "-"
         '
         'menuItemLoadXml
         '
         Me.menuItemLoadXml.Index = 3
         Me.menuItemLoadXml.Text = "Open DICOM XML..."
         '
         'MenuItemLoadJson
         '
         Me.MenuItemLoadJson.Index = 4
         Me.MenuItemLoadJson.Text = "Open DICOM JSON..."
         '
         'MenuItem21
         '
         Me.MenuItem21.Index = 5
         Me.MenuItem21.Text = "-"
         '
         'menuItemSaveXml
         '
         Me.menuItemSaveXml.Index = 6
         Me.menuItemSaveXml.Text = "Save DICOM XML..."
         '
         'menuItemSaveNativeDicomModel
         '
         Me.menuItemSaveNativeDicomModel.Index = 7
         Me.menuItemSaveNativeDicomModel.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemSaveNativeDicomOptions, Me.menuItemSaveNativeDicom})
         Me.menuItemSaveNativeDicomModel.Text = "Save Native DICOM Model (xml)"
         '
         'menuItemSaveNativeDicomOptions
         '
         Me.menuItemSaveNativeDicomOptions.Index = 0
         Me.menuItemSaveNativeDicomOptions.Text = "Options..."
         '
         'menuItemSaveNativeDicom
         '
         Me.menuItemSaveNativeDicom.Index = 1
         Me.menuItemSaveNativeDicom.Text = "Save..."
         '
         'menuItemSaveDicomJsonModel
         '
         Me.menuItemSaveDicomJsonModel.Index = 8
         Me.menuItemSaveDicomJsonModel.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemSaveJsonOptions, Me.menuItemSaveJson})
         Me.menuItemSaveDicomJsonModel.Text = "Save DICOM JSON Model (json)"
         '
         'menuItemSaveJsonOptions
         '
         Me.menuItemSaveJsonOptions.Index = 0
         Me.menuItemSaveJsonOptions.Text = "Options..."
         '
         'menuItemSaveJson
         '
         Me.menuItemSaveJson.Index = 1
         Me.menuItemSaveJson.Text = "Save..."
         '
         'MenuItem17
         '
         Me.MenuItem17.Index = 9
         Me.MenuItem17.Text = "-"
         '
         'menuItemSave
         '
         Me.menuItemSave.Enabled = False
         Me.menuItemSave.Index = 10
         Me.menuItemSave.Text = "&Save DICOM (dcm)..."
         '
         'menuItem6
         '
         Me.menuItem6.Index = 11
         Me.menuItem6.Text = "-"
         '
         'menuItemClose
         '
         Me.menuItemClose.Enabled = False
         Me.menuItemClose.Index = 12
         Me.menuItemClose.Text = "&Close"
         '
         'menuItem7
         '
         Me.menuItem7.Index = 13
         Me.menuItem7.Text = "-"
         '
         'menuItemInfo
         '
         Me.menuItemInfo.Index = 14
         Me.menuItemInfo.Text = "&Info..."
         '
         'menuItem8
         '
         Me.menuItem8.Index = 15
         Me.menuItem8.Text = "-"
         '
         'menuItemExit
         '
         Me.menuItemExit.Index = 16
         Me.menuItemExit.Text = "&Exit"
         '
         'menuItemView
         '
         Me.menuItemView.Index = 1
         Me.menuItemView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemNormal, Me.menuItemFit, Me.menuItem15, Me.menuItemZoomIn, Me.menuItemZoomOut})
         Me.menuItemView.Text = "&View"
         '
         'menuItemNormal
         '
         Me.menuItemNormal.Index = 0
         Me.menuItemNormal.Text = "&Normal"
         '
         'menuItemFit
         '
         Me.menuItemFit.Index = 1
         Me.menuItemFit.Text = "&Fit"
         '
         'menuItem15
         '
         Me.menuItem15.Index = 2
         Me.menuItem15.Text = "-"
         '
         'menuItemZoomIn
         '
         Me.menuItemZoomIn.Index = 3
         Me.menuItemZoomIn.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemZoom2, Me.menuItemZoom4})
         Me.menuItemZoomIn.Text = "Zoom &In"
         '
         'menuItemZoom2
         '
         Me.menuItemZoom2.Index = 0
         Me.menuItemZoom2.Text = "&2x"
         '
         'menuItemZoom4
         '
         Me.menuItemZoom4.Index = 1
         Me.menuItemZoom4.Text = "&4x"
         '
         'menuItemZoomOut
         '
         Me.menuItemZoomOut.Index = 4
         Me.menuItemZoomOut.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemZoomHalf, Me.menuItemZoomFourth})
         Me.menuItemZoomOut.Text = "Zoom &Out"
         '
         'menuItemZoomHalf
         '
         Me.menuItemZoomHalf.Index = 0
         Me.menuItemZoomHalf.Text = "1/2x"
         '
         'menuItemZoomFourth
         '
         Me.menuItemZoomFourth.Index = 1
         Me.menuItemZoomFourth.Text = "1/4x"
         '
         'menuItemTables
         '
         Me.menuItemTables.Index = 2
         Me.menuItemTables.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemVR, Me.menuItemUID, Me.menuItemTag, Me.menuItemIOD, Me.menuItemGroups, Me.MenuItem2, Me.menuItemModifyTables})
         Me.menuItemTables.Text = "&Tables"
         '
         'menuItemVR
         '
         Me.menuItemVR.Index = 0
         Me.menuItemVR.Text = "&Value Representation (VR)..."
         '
         'menuItemUID
         '
         Me.menuItemUID.Index = 1
         Me.menuItemUID.Text = "&Unique Identifier (UID)..."
         '
         'menuItemTag
         '
         Me.menuItemTag.Index = 2
         Me.menuItemTag.Text = "&Element Tag..."
         '
         'menuItemIOD
         '
         Me.menuItemIOD.Index = 3
         Me.menuItemIOD.Text = "Information Object Definition (IOD)..."
         '
         'menuItemGroups
         '
         Me.menuItemGroups.Index = 4
         Me.menuItemGroups.Text = "Context Groups..."
         '
         'MenuItem2
         '
         Me.MenuItem2.Index = 5
         Me.MenuItem2.Text = "-"
         '
         'menuItemModifyTables
         '
         Me.menuItemModifyTables.Index = 6
         Me.menuItemModifyTables.Text = "Modify Tables..."
         '
         'menuItemDataset
         '
         Me.menuItemDataset.Enabled = False
         Me.menuItemDataset.Index = 3
         Me.menuItemDataset.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemEdit, Me.menuItem9, Me.menuItemElementInsert, Me.menuItemElementDelete, Me.menuItem11, Me.menuItemUpdate, Me.menuItem10, Me.menuItemListView, Me.menuItemModuleView})
         Me.menuItemDataset.Text = "&Dataset"
         '
         'menuItemEdit
         '
         Me.menuItemEdit.Index = 0
         Me.menuItemEdit.Text = "&Edit Values..."
         '
         'menuItem9
         '
         Me.menuItem9.Index = 1
         Me.menuItem9.Text = "-"
         '
         'menuItemElementInsert
         '
         Me.menuItemElementInsert.Index = 2
         Me.menuItemElementInsert.Text = "&Insert..."
         '
         'menuItemElementDelete
         '
         Me.menuItemElementDelete.Index = 3
         Me.menuItemElementDelete.Text = "&Delete"
         '
         'menuItem11
         '
         Me.menuItem11.Index = 4
         Me.menuItem11.Text = "-"
         '
         'menuItemUpdate
         '
         Me.menuItemUpdate.Index = 5
         Me.menuItemUpdate.Text = "Update Pixel Data Element..."
         '
         'menuItem10
         '
         Me.menuItem10.Index = 6
         Me.menuItem10.Text = "-"
         '
         'menuItemListView
         '
         Me.menuItemListView.Index = 7
         Me.menuItemListView.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftL
         Me.menuItemListView.Text = "&List View"
         '
         'menuItemModuleView
         '
         Me.menuItemModuleView.Index = 8
         Me.menuItemModuleView.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftM
         Me.menuItemModuleView.Text = "&Module View"
         '
         'menuItemAnimation
         '
         Me.menuItemAnimation.Enabled = False
         Me.menuItemAnimation.Index = 4
         Me.menuItemAnimation.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemPlay, Me.menuItem13, Me.menuItemFirst, Me.menuItemNext, Me.menuItemPrevious, Me.menuItemLast})
         Me.menuItemAnimation.Text = "&Animation"
         '
         'menuItemPlay
         '
         Me.menuItemPlay.Index = 0
         Me.menuItemPlay.Text = "&Play"
         '
         'menuItem13
         '
         Me.menuItem13.Index = 1
         Me.menuItem13.Text = "-"
         '
         'menuItemFirst
         '
         Me.menuItemFirst.Index = 2
         Me.menuItemFirst.Text = "&First"
         '
         'menuItemNext
         '
         Me.menuItemNext.Index = 3
         Me.menuItemNext.Text = "&Next"
         '
         'menuItemPrevious
         '
         Me.menuItemPrevious.Index = 4
         Me.menuItemPrevious.Text = "Pre&vious"
         '
         'menuItemLast
         '
         Me.menuItemLast.Index = 5
         Me.menuItemLast.Text = "L&ast"
         '
         'menuItemProcessing
         '
         Me.menuItemProcessing.Enabled = False
         Me.menuItemProcessing.Index = 5
         Me.menuItemProcessing.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemFlip, Me.menuItemReverse, Me.menuItemRotate, Me.menuItem1, Me.menuItemGrayscale, Me.menuItem3, Me.menuItemInvert, Me.menuItemBrightness, Me.menuItemContrast, Me.menuItemUnsharpMask, Me.menuItemViewHistogram})
         Me.menuItemProcessing.Text = "&Processing"
         '
         'menuItemFlip
         '
         Me.menuItemFlip.Index = 0
         Me.menuItemFlip.Text = "&Flip"
         '
         'menuItemReverse
         '
         Me.menuItemReverse.Index = 1
         Me.menuItemReverse.Text = "&Reverse"
         '
         'menuItemRotate
         '
         Me.menuItemRotate.Index = 2
         Me.menuItemRotate.Text = "Ro&tate..."
         '
         'menuItem1
         '
         Me.menuItem1.Index = 3
         Me.menuItem1.Text = "-"
         '
         'menuItemGrayscale
         '
         Me.menuItemGrayscale.Index = 4
         Me.menuItemGrayscale.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemGrayscale8, Me.menuItemGrayscale12, Me.menuItemGrayscale16})
         Me.menuItemGrayscale.Text = "GrayScale"
         '
         'menuItemGrayscale8
         '
         Me.menuItemGrayscale8.Index = 0
         Me.menuItemGrayscale8.Text = "&8"
         '
         'menuItemGrayscale12
         '
         Me.menuItemGrayscale12.Index = 1
         Me.menuItemGrayscale12.Text = "1&2"
         '
         'menuItemGrayscale16
         '
         Me.menuItemGrayscale16.Index = 2
         Me.menuItemGrayscale16.Text = "1&6"
         '
         'menuItem3
         '
         Me.menuItem3.Index = 5
         Me.menuItem3.Text = "-"
         '
         'menuItemInvert
         '
         Me.menuItemInvert.Index = 6
         Me.menuItemInvert.Text = "&Invert"
         '
         'menuItemBrightness
         '
         Me.menuItemBrightness.Index = 7
         Me.menuItemBrightness.Text = "&Brightness..."
         '
         'menuItemContrast
         '
         Me.menuItemContrast.Index = 8
         Me.menuItemContrast.Text = "&Contrast..."
         '
         'menuItemUnsharpMask
         '
         Me.menuItemUnsharpMask.Index = 9
         Me.menuItemUnsharpMask.Text = "&Unsharp Mask..."
         '
         'menuItemViewHistogram
         '
         Me.menuItemViewHistogram.Index = 10
         Me.menuItemViewHistogram.Text = "&View Histogram..."
         '
         'MenuItemOptions
         '
         Me.MenuItemOptions.Index = 6
         Me.MenuItemOptions.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemOptionsLoad})
         Me.MenuItemOptions.Text = "&Options"
         '
         'MenuItemOptionsLoad
         '
         Me.MenuItemOptionsLoad.Index = 0
         Me.MenuItemOptionsLoad.Text = "Load..."
         '
         'menuItem5
         '
         Me.menuItem5.Index = 7
         Me.menuItem5.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemAbout})
         Me.menuItem5.Text = "&Help"
         '
         'menuItemAbout
         '
         Me.menuItemAbout.Index = 0
         Me.menuItemAbout.Text = "&About"
         '
         'panel1
         '
         Me.panel1.Dock = System.Windows.Forms.DockStyle.Fill
         Me.panel1.Location = New System.Drawing.Point(0, 0)
         Me.panel1.Name = "panel1"
         Me.panel1.Size = New System.Drawing.Size(568, 277)
         Me.panel1.TabIndex = 0
         '
         'panel2
         '
         Me.panel2.Controls.Add(Me.panel3)
         Me.panel2.Controls.Add(Me.splitter2)
         Me.panel2.Controls.Add(Me.tabControl1)
         Me.panel2.Dock = System.Windows.Forms.DockStyle.Bottom
         Me.panel2.Location = New System.Drawing.Point(0, 277)
         Me.panel2.Name = "panel2"
         Me.panel2.Size = New System.Drawing.Size(568, 160)
         Me.panel2.TabIndex = 1
         '
         'panel3
         '
         Me.panel3.Controls.Add(Me.textBoxValues)
         Me.panel3.Controls.Add(Me.splitter3)
         Me.panel3.Controls.Add(Me.propertyGridElement)
         Me.panel3.Dock = System.Windows.Forms.DockStyle.Fill
         Me.panel3.Location = New System.Drawing.Point(422, 0)
         Me.panel3.Name = "panel3"
         Me.panel3.Size = New System.Drawing.Size(146, 160)
         Me.panel3.TabIndex = 7
         '
         'textBoxValues
         '
         Me.textBoxValues.Dock = System.Windows.Forms.DockStyle.Fill
         Me.textBoxValues.Location = New System.Drawing.Point(0, 92)
         Me.textBoxValues.Multiline = True
         Me.textBoxValues.Name = "textBoxValues"
         Me.textBoxValues.ReadOnly = True
         Me.textBoxValues.Size = New System.Drawing.Size(146, 68)
         Me.textBoxValues.TabIndex = 4
         '
         'splitter3
         '
         Me.splitter3.Dock = System.Windows.Forms.DockStyle.Top
         Me.splitter3.Location = New System.Drawing.Point(0, 89)
         Me.splitter3.Name = "splitter3"
         Me.splitter3.Size = New System.Drawing.Size(146, 3)
         Me.splitter3.TabIndex = 3
         Me.splitter3.TabStop = False
         '
         'propertyGridElement
         '
         Me.propertyGridElement.Dock = System.Windows.Forms.DockStyle.Top
         Me.propertyGridElement.HelpVisible = False
         Me.propertyGridElement.LineColor = System.Drawing.SystemColors.ScrollBar
         Me.propertyGridElement.Location = New System.Drawing.Point(0, 0)
         Me.propertyGridElement.Name = "propertyGridElement"
         Me.propertyGridElement.PropertySort = System.Windows.Forms.PropertySort.NoSort
         Me.propertyGridElement.Size = New System.Drawing.Size(146, 89)
         Me.propertyGridElement.TabIndex = 2
         Me.propertyGridElement.ToolbarVisible = False
         '
         'splitter2
         '
         Me.splitter2.Location = New System.Drawing.Point(419, 0)
         Me.splitter2.Name = "splitter2"
         Me.splitter2.Size = New System.Drawing.Size(3, 160)
         Me.splitter2.TabIndex = 6
         Me.splitter2.TabStop = False
         '
         'tabControl1
         '
         Me.tabControl1.Controls.Add(Me.tabPage1)
         Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Left
         Me.tabControl1.Location = New System.Drawing.Point(0, 0)
         Me.tabControl1.Name = "tabControl1"
         Me.tabControl1.SelectedIndex = 0
         Me.tabControl1.Size = New System.Drawing.Size(419, 160)
         Me.tabControl1.TabIndex = 5
         '
         'tabPage1
         '
         Me.tabPage1.Controls.Add(Me.treeViewElements)
         Me.tabPage1.Location = New System.Drawing.Point(4, 22)
         Me.tabPage1.Name = "tabPage1"
         Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
         Me.tabPage1.Size = New System.Drawing.Size(411, 134)
         Me.tabPage1.TabIndex = 0
         Me.tabPage1.Text = "List View"
         Me.tabPage1.UseVisualStyleBackColor = True
         '
         'treeViewElements
         '
         Me.treeViewElements.Dock = System.Windows.Forms.DockStyle.Fill
         Me.treeViewElements.FullRowSelect = True
         Me.treeViewElements.HideSelection = False
         Me.treeViewElements.ImageIndex = 0
         Me.treeViewElements.ImageList = Me.imageList1
         Me.treeViewElements.Location = New System.Drawing.Point(3, 3)
         Me.treeViewElements.Name = "treeViewElements"
         Me.treeViewElements.SelectedImageIndex = 0
         Me.treeViewElements.Size = New System.Drawing.Size(405, 128)
         Me.treeViewElements.TabIndex = 0
         '
         'imageList1
         '
         Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
         Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
         Me.imageList1.Images.SetKeyName(0, "")
         Me.imageList1.Images.SetKeyName(1, "")
         Me.imageList1.Images.SetKeyName(2, "")
         Me.imageList1.Images.SetKeyName(3, "")
         '
         'splitter1
         '
         Me.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
         Me.splitter1.Location = New System.Drawing.Point(0, 274)
         Me.splitter1.Name = "splitter1"
         Me.splitter1.Size = New System.Drawing.Size(568, 3)
         Me.splitter1.TabIndex = 2
         Me.splitter1.TabStop = False
         '
         'openFileDialog1
         '
         Me.openFileDialog1.Filter = "DICOM Files (*.dcm;*.dic)|*.dcm;*.dic|All files (*.*)|*.*"
         Me.openFileDialog1.Multiselect = True
         Me.openFileDialog1.Title = "Open Dicom File"
         '
         'MainForm
         '
         Me.AllowDrop = True
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(568, 437)
         Me.Controls.Add(Me.splitter1)
         Me.Controls.Add(Me.panel1)
         Me.Controls.Add(Me.panel2)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.Menu = Me.mainMenu1
         Me.Name = "MainForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "DICOM Demo - VB.NET"
         Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
         Me.panel2.ResumeLayout(False)
         Me.panel3.ResumeLayout(False)
         Me.panel3.PerformLayout()
         Me.tabControl1.ResumeLayout(False)
         Me.tabPage1.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub
#End Region

      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      <STAThread()>
      Shared Sub Main()


         If Not Support.SetLicense() Then
            Return
         End If

         If (RasterSupport.IsLocked(RasterSupportType.Medical)) Then
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.Medical.ToString()), "Warning")
            Return
         End If

         Application.Run(New MainForm())
      End Sub

      ' Raster viewer object.
      Private _viewer As ImageViewer
      Private TempOutPdf As String

      Private _getImageFlags As DicomGetImageFlags =
               DicomGetImageFlags.AutoApplyModalityLut Or
               DicomGetImageFlags.AutoApplyVoiLut Or
               DicomGetImageFlags.AutoScaleModalityLut Or
               DicomGetImageFlags.AutoScaleVoiLut Or
               DicomGetImageFlags.AutoDetectInvalidRleCompression Or
               DicomGetImageFlags.LoadCorrupted

      Private Sub menuItemAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemAbout.Click
         Using aboutDialog As New AboutDialog("DICOM", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub menuItemExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemExit.Click
         Application.Exit()
      End Sub

      Private Sub menuItemGroups_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemGroups.Click
         Cursor = Cursors.WaitCursor

         Try
            Dim dlgContext As ContextGroupDlg = New ContextGroupDlg()
            dlgContext.ShowDialog()
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False)

            Throw exception
         Finally
            Cursor = Cursors.Arrow
         End Try
      End Sub

      Private Function IsIodTableLoaded() As Boolean
         Dim bRet As Boolean = True

         Dim iod As DicomIod = DicomIodTable.Instance.GetFirst(Nothing, False)
         bRet = (iod IsNot Nothing)

         Return bRet
      End Function

      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

         ' Initialize the viewer object.
         TempOutPdf = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TempPdf"
         _viewer = New ImageViewer()
         _viewer.Dock = DockStyle.Fill
         _viewer.BackColor = SystemColors.ControlText
         panel1.Controls.Add(_viewer)

         _viewer.BringToFront()

         AddHandler _viewer.MouseDown, AddressOf _viewer_MouseDown
         AddHandler _viewer.MouseUp, AddressOf _viewer_MouseUp
         AddHandler _viewer.MouseMove, AddressOf _viewer_MouseMove


         ds = New DicomDataSet()

         If ds Is Nothing Then
            MessageBox.Show("Can't create dicom object. Quitting app.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
            Return
         End If

         panel2.Height = Convert.ToInt32(ClientSize.Height * 0.3)
         tabControl1.Width = Convert.ToInt32(ClientSize.Width * 0.75)
         textBoxValues.Height = Convert.ToInt32(panel3.Height / 2)
         BringToFront()

         AddHandler Application.ApplicationExit, AddressOf Application_ApplicationExit

         LoadImage(True)

         MenuItem12.Visible = False
         menuItemLoadXml.Visible = False
         menuItemSaveXml.Visible = False

         MenuItem12.Visible = True
         menuItemLoadXml.Visible = True
         menuItemSaveXml.Visible = True

         If False = IsIodTableLoaded() Then
            MessageBox.Show("The IOD Table is empty because Leadtools.Dicom.Tables.dll is missing." & Constants.vbLf + Constants.vbLf & "The 'Module View' is consqeuently disabled.  To re-enable the 'Module View', load the IOD Table as follows:" & Constants.vbLf + Constants.vbLf + Constants.vbTab & "Tables->Modify Tables->Load from file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            listView = True
         End If

#If LEADTOOLS_V19_OR_LATER Then
         Me.menuItemSaveNativeDicomModel.Visible = True
         Me.menuItemSaveNativeDicomModel.Visible = True
#Else
         menuItemSaveNativeDicomModel.Visible = False
         menuItemSaveDicomJsonModel.Visible = False
#End If ' #if LEADTOOLS_V19_OR_LATER

      End Sub

      Private Sub Application_ApplicationExit(ByVal sender As Object, ByVal e As EventArgs)
         Utils.EngineShutdown()
      End Sub

      Private Sub FreeImage()
         If Not _viewer.Image Is Nothing Then
            If _viewer.Image.PageCount > 1 Then
               _viewer.Image.RemoveAllPages()
            End If

            _viewer.Image.Dispose()
            _viewer.Image = Nothing
         End If
      End Sub

      Private Function GetWindowValuesFromDataset(ByVal wl As WindowLevel) As DicomGetValueResult
         Dim vr As DicomGetValueResult = DicomGetValueResult.Success
         Dim width As Double = ds.GetValue(DicomTag.WindowWidth, 0.0)
         If ds.GetValueResult <> DicomGetValueResult.Success Then
            Return ds.GetValueResult
         End If

         Dim center As Double = ds.GetValue(DicomTag.WindowCenter, 0.0)
         If ds.GetValueResult <> DicomGetValueResult.Success Then
            Return ds.GetValueResult
         End If

         wl.WindowWidth = width
         wl.WindowCenter = center

         Return DicomGetValueResult.Success
      End Function

      Private Sub GetWindowLevelValues()
         Dim bSuccess As Boolean = False
         Dim sPhoto As String = ds.GetValue(DicomTag.PhotometricInterpretation, String.Empty)
         isMonochrome1 = (String.Compare(sPhoto, "MONOCHROME1", True) = 0)

         Try
            Dim vr As DicomGetValueResult = GetWindowValuesFromDataset(wl)
            If vr = DicomGetValueResult.Success Then
               bSuccess = True
            End If
         Catch e1 As Exception
         End Try

         If bSuccess Then
            Return
         End If

         Try
            ' First see if there is a linear VOI LUT
            Dim command As New GetLinearVoiLookupTableCommand()
            command.Flags = GetLinearVoiLookupTableCommandFlags.None
            command.Run(_viewer.Image)
            wl.WindowCenter = command.Center
            wl.WindowWidth = command.Width
            bSuccess = True
         Catch e2 As Exception
         End Try

         If bSuccess Then
            Return
         End If

         Try
            ' Next try for a non-linear VOI LUT
            Dim voiLut As DicomVoiLutAttributes = ds.GetVoiLut(0)
            Dim data() As Integer = ds.GetVoiLutData(0)

            Dim nMin As Integer = Math.Min(data(0), data(data.Length - 1))
            Dim nMax As Integer = Math.Max(data(0), data(data.Length - 1))
            wl.WindowCenter = (nMax + nMin) / 2
            wl.WindowWidth = (nMax - nMin) / 2
            bSuccess = True
         Catch e3 As Exception
         End Try

         If bSuccess Then
            Return
         End If

         Try
            ' Finally, just use max and min value
            Dim nMax As Integer = _viewer.Image.MaxValue
            Dim nMin As Integer = _viewer.Image.MinValue
            wl.WindowCenter = (nMax + nMin) / 2
            wl.WindowWidth = (nMax - nMin) / 2

         Catch e4 As Exception
         End Try

      End Sub

      Private Sub menuItemVR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemVR.Click
         Dim dlgVR As ValueRepresentationDlg = New ValueRepresentationDlg(ds)

         dlgVR.ShowDialog()
      End Sub

      Private Sub menuItemUID_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemUID.Click
         Dim dlgUID As UniqueIdentifierDlg = New UniqueIdentifierDlg()

         dlgUID.ShowDialog()
      End Sub

      Private Sub menuItemTag_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemTag.Click
         Cursor = Cursors.WaitCursor

         Try
            Dim dlgTag As ElementTagDlg = New ElementTagDlg()

            dlgTag.ShowDialog()
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False)

            Throw exception
         Finally
            Cursor = Cursors.Arrow
         End Try
      End Sub

      Private Sub menuItemIOD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemIOD.Click
         Cursor = Cursors.WaitCursor
         Try
            Dim dlgIOD As InformationObjectDefinitionDlg = New InformationObjectDefinitionDlg()
            dlgIOD.ShowDialog()
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False)

            Throw exception
         Finally
            Cursor = Cursors.Arrow
         End Try
      End Sub

      Private Sub menuItemOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemOpen.Click
         LoadImage(False)
      End Sub

      Private Sub LoadImage(ByVal loadDefaultImage As Boolean)
         Try
            If loadDefaultImage Then
               menuItemClose_Click(Nothing, New EventArgs())
               OpenDataset(DemosGlobal.ImagesFolder & "\image2.dcm")
            Else
               openFileDialog1.Filter = "DICOM Files (*.dcm;*.dic)|*.dcm;*.dic|All files (*.*)|*.*"
               openFileDialog1.Multiselect = True
               openFileDialog1.Title = "Open Dicom File"
               openFileDialog1.InitialDirectory = _openInitialPath

               If openFileDialog1.ShowDialog() = DialogResult.OK Then
                  _openInitialPath = Path.GetDirectoryName(openFileDialog1.FileName)
                  menuItemClose_Click(Nothing, New EventArgs())
                  OpenDataset(openFileDialog1.FileName)
               End If
            End If
         Catch
            MessageBox.Show("Error loading image")
         End Try
      End Sub

      Private Sub DisplayInvalidImageMessage(ByVal errorMsg As String)
         If String.Compare("Improper Image.", errorMsg, True) = 0 Then
            errorMsg = "Note that this dataset contains an invalid image."
         End If
         MessageBox.Show(errorMsg & Constants.vbLf + Constants.vbLf & "Unable to display the image data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      End Sub

      Private Sub ShowImage()

         If ds.InformationClass = DicomClassType.EncapsulatedPdfStorage Then
            Try

               Dim encapsulatedDocument As DicomEncapsulatedDocument = New DicomEncapsulatedDocument()
               Dim conceptNameCodeSequence As DicomCodeSequenceItem = New DicomCodeSequenceItem()

               'Get the Encapsulated Pdf file and store it in the Temp File
               ds.GetEncapsulatedDocument(Nothing, False, TempOutPdf, encapsulatedDocument, conceptNameCodeSequence)

               'Get extra info about DicomEncapsulatedDocument and DicomCodeSequenceItem here...

               encapsulatedDocument.Dispose()
               conceptNameCodeSequence.Dispose()

               'View the stored Pdf file
               Using codecs As RasterCodecs = New RasterCodecs()

                  Try
                     _viewer.Image = codecs.Load(TempOutPdf, 0, CodecsLoadByteOrder.Bgr, 1, -1)
                  Catch
                     MessageBox.Show("Unable to load the Encapsulated Pdf file.")
                  End Try

               End Using

            Catch exception As Exception
               System.Diagnostics.Debug.Assert(False)
               Throw exception

            Finally
               'delete the Temp Pdf file if exists
               If (System.IO.File.Exists(TempOutPdf) = True) Then
                  System.IO.File.Delete(TempOutPdf)
               End If

            End Try

         Else
            Try
               Dim element As DicomElement = Nothing
               element = ds.FindFirstElement(Nothing, DemoDicomTags.PixelData, True)
               Dim bitmapCount As Integer = ds.GetImageCount(element)
               If bitmapCount > 0 Then
                  If bitmapCount = 1 Then
                     If Not element Is Nothing Then
                        Try
                           Dim image As RasterImage = ds.GetImage(element, 0, 0, RasterByteOrder.Gray, _getImageFlags)

                           _viewer.Image = image
                        Catch ex As Exception
                           DisplayInvalidImageMessage(ex.Message)
                        End Try
                     End If
                  Else
                     If Not element Is Nothing Then
                        LoadBitmapList(element)
                     End If
                  End If

                  GetWindowLevelValues()
                  imageInfo = ds.GetImageInformation(element, 0)
               Else
                  MessageBox.Show("Note that this dataset does not include any images.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
               End If
            Catch exception As Exception
               System.Diagnostics.Debug.Assert(False)
               Throw exception
            End Try
         End If

      End Sub

      Public Enum DicomDemoFormat
         Standard
         Xml
         Json
      End Enum

      Private Sub OpenDataset(ByVal file As String)
         OpenDataset(file, DicomDemoFormat.Standard)
      End Sub

      Private Sub OpenDataset(ByVal file As String, ByVal format As DicomDemoFormat)
         FreeImage()

         Cursor = Cursors.WaitCursor

         Try
            Dim element As DicomElement = Nothing

            If format = DicomDemoFormat.Standard Then
               Try
                  ds.Load(file, DicomDataSetLoadFlags.None)
               Catch e1 As Exception
                  Dim msg As String = String.Format("Failed to load '{0}'.  Make sure that this is a valid DICOM file.", file)
                  MessageBox.Show(msg)
                  Return
               End Try
            ElseIf format = DicomDemoFormat.Xml Then
               Try
                  ds.LoadXml(file, DicomDataSetLoadXmlFlags.None)
               Catch e2 As Exception
                  Dim msg As String = String.Format("Failed to load '{0}'.  Make sure that this is a valid DICOM XML file.", file)
                  MessageBox.Show(msg)
                  Return
               End Try
            Else
               Try
                  ds.LoadJson(file, DicomDataSetLoadJsonFlags.None)
               Catch e3 As Exception
                  Dim msg As String = String.Format("Failed to load '{0}'.  Make sure that this is a valid DICOM Json Model file.", file)
                  MessageBox.Show(msg)
                  Return
               End Try
            End If
            If ds.InformationClass = DicomClassType.BasicDirectory Then
               MessageBox.Show("This demo does not support opening Dicom Directory datasets.  " & "Please see the Dicom Directory demo.")
               Return
            End If

            Dim bImage As Boolean = False
            Try
               ShowImage()
               bImage = (_viewer.Image IsNot Nothing)
            Catch ex As Exception
               MessageBox.Show(ex.Message)
            End Try

            menuItemDataset.Enabled = True
            menuItemProcessing.Enabled = bImage

            If _viewer.Image IsNot Nothing Then
               If ds.InformationClass = DicomClassType.EncapsulatedPdfStorage Then
                  menuItemAnimation.Enabled = (_viewer.Image.PageCount > 1)
               Else
                  menuItemAnimation.Enabled = ds.GetImageCount(element) > 1
               End If
            End If

            UpdateTree()
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False)

            Throw exception
         Finally
            Cursor = Cursors.Arrow
         End Try

         If treeViewElements.Nodes.Count > 0 Then
            treeViewElements.SelectedNode = treeViewElements.Nodes(0)
         End If
      End Sub

      Private Sub LoadBitmapList(ByVal element As DicomElement)
         Dim count As Integer
         Dim getImagesSuccess As Boolean = True
         Dim errorMsg As String = String.Empty

         count = ds.GetImageCount(element)
         Dim x As Integer = 0
         Do While (x < count) AndAlso (getImagesSuccess = True)
            Dim image As RasterImage = Nothing

            Try
               image = ds.GetImage(element, x, 0, RasterByteOrder.Rgb Or RasterByteOrder.Gray, _getImageFlags)

            Catch ex As Exception
               getImagesSuccess = False
               errorMsg = ex.Message
            End Try


            If image IsNot Nothing Then
               If x = 0 Then
                  _viewer.Image = image
               Else
                  _viewer.Image.AddPage(image)
               End If
            End If
            x += 1
         Loop

         If getImagesSuccess = False Then
            DisplayInvalidImageMessage(errorMsg)
         End If

         If _viewer.Image IsNot Nothing AndAlso _viewer.Image.PageCount > 0 Then
            _viewer.Image.Page = 1
         End If
      End Sub

      Private Sub FillTree()
         Dim element As DicomElement

         element = ds.GetFirstElement(Nothing, False, True)
         If element Is Nothing Then
            Dim err As String = String.Format("Error reading dicom dataset!")

            MessageBox.Show(err, "Error")
            Return
         End If

         FillSubTree(element, Nothing)
      End Sub

      Private Sub FillSubTree(ByVal element As DicomElement, ByVal ParentNode As TreeNode)
         Dim node As TreeNode
         Dim name As String
         Dim temp As String = ""
         Dim tag As DicomTag
         Dim tempElement As DicomElement

         tag = DicomTagTable.Instance.Find(element.Tag)

         If Not tag Is Nothing Then
            name = tag.Name
         Else
            name = "Item"
         End If

         Dim tagValue As Long = 0

         tagValue = CLng(element.Tag)

         temp = String.Format("{0:x4}:{1:x4} - ", Utils.GetGroup(tagValue), Utils.GetElement(tagValue))
         temp = temp & name

         If Not ParentNode Is Nothing Then
            node = ParentNode.Nodes.Add(temp)
         Else
            node = treeViewElements.Nodes.Add(temp)
         End If

         node.Tag = element

         If ds.IsVolatileElement(element) Then
            node.ForeColor = Color.Red
         End If

         node.ImageIndex = 1
         node.SelectedImageIndex = 1

         tempElement = ds.GetChildElement(element, True)
         If Not tempElement Is Nothing Then
            node.ImageIndex = 0
            node.SelectedImageIndex = 0
            FillSubTree(tempElement, node)
         End If


         tempElement = ds.GetNextElement(element, True, True)
         If Not tempElement Is Nothing Then
            FillSubTree(tempElement, ParentNode)
         Else
            element = ds.GetParentElement(element)
         End If
      End Sub

      Private Sub FillTreeModules()
         Dim x As Integer = 0
         Do While x < ds.ModuleCount
            Dim node As TreeNode
            Dim [module] As DicomModule
            Dim iod As DicomIod

            [module] = ds.FindModuleByIndex(x)
            iod = DicomIodTable.Instance.FindModule(ds.InformationClass, [module].Type)

            node = treeViewElements.Nodes.Add(iod.Name)
            node.Tag = [module]
            For Each element As DicomElement In [module].Elements
               FillModuleSubTree(element, node, False)
            Next element
            x += 1
         Loop
      End Sub

      Private Sub FillModuleSubTree(ByVal element As DicomElement, ByVal ParentNode As TreeNode, ByVal recurse As Boolean)
         Dim node As TreeNode
         Dim name As String
         Dim temp As String = ""
         Dim tempElement As DicomElement

         Dim tag As DicomTag

         tag = DicomTagTable.Instance.Find(element.Tag)
         temp = String.Format("{0:x4}:{1:x4} - ", Utils.GetGroup(CLng(element.Tag)), Utils.GetElement(CLng(element.Tag)))


         If tag Is Nothing Then
            name = "Item"
         Else
            name = tag.Name
         End If

         temp = temp & name

         If Not ParentNode Is Nothing Then
            node = ParentNode.Nodes.Add(temp)
         Else
            node = treeViewElements.Nodes.Add(temp)
         End If

         node.Tag = element

         If ds.IsVolatileElement(element) Then
            node.ForeColor = Color.Red
         End If

         node.ImageIndex = 1
         node.SelectedImageIndex = 1

         tempElement = ds.GetChildElement(element, True)
         If Not tempElement Is Nothing Then
            node.ImageIndex = 0
            node.SelectedImageIndex = 0
            FillModuleSubTree(tempElement, node, True)
         End If

         If recurse Then
            tempElement = ds.GetNextElement(element, True, True)
            If Not tempElement Is Nothing Then
               FillModuleSubTree(tempElement, ParentNode, True)
            End If
         End If
      End Sub

      Private Sub menuItemView_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemView.Popup
         Dim enable As Boolean = False
         If _viewer.Image Is Nothing OrElse (_viewer.Image.PageCount < 1) Then
            enable = False
         Else
            enable = True
         End If

         menuItemNormal.Enabled = enable
         menuItemNormal.Checked = ((_viewer.SizeMode = ControlSizeMode.ActualSize) AndAlso (_viewer.ScaleFactor = 1))

         menuItemFit.Enabled = enable
         menuItemFit.Checked = _viewer.SizeMode = ControlSizeMode.Fit

         menuItemZoomIn.Enabled = enable
         menuItemZoomOut.Enabled = enable
         menuItemAnimation.Enabled = enable

         menuItemZoom2.Checked = _viewer.ScaleFactor = (2 * 100)
         menuItemZoom4.Checked = _viewer.ScaleFactor = (4 * 100)
         menuItemZoomHalf.Checked = _viewer.ScaleFactor = (100 / 2)
         menuItemZoomFourth.Checked = _viewer.ScaleFactor = (100 / 4)
      End Sub

      Private Sub menuItemNormal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemNormal.Click
         _viewer.Zoom(ControlSizeMode.ActualSize, 1, _viewer.DefaultZoomOrigin)
      End Sub

      Private Sub menuItemFit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemFit.Click
         _viewer.Zoom(ControlSizeMode.Fit, 1, _viewer.DefaultZoomOrigin)
      End Sub

      Private Sub menuItemZoom2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemZoom2.Click
         _viewer.Zoom(ControlSizeMode.None, _viewer.ScaleFactor * 2, _viewer.DefaultZoomOrigin)
      End Sub

      Private Sub menuItemZoom4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemZoom4.Click
         _viewer.Zoom(ControlSizeMode.None, _viewer.ScaleFactor * 4, _viewer.DefaultZoomOrigin)
      End Sub

      Private Sub menuItemZoomHalf_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemZoomHalf.Click
         _viewer.Zoom(ControlSizeMode.None, _viewer.ScaleFactor * 0.5F, _viewer.DefaultZoomOrigin)
      End Sub

      Private Sub menuItemZoomFourth_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemZoomFourth.Click
         _viewer.Zoom(ControlSizeMode.None, _viewer.ScaleFactor * 0.25F, _viewer.DefaultZoomOrigin)
      End Sub

      Private Sub menuItemClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemClose.Click
         propertyGridElement.SelectedObject = Nothing
         treeViewElements.BeginUpdate()
         treeViewElements.Nodes.Clear()
         treeViewElements.EndUpdate()

         menuItemDataset.Enabled = False
         menuItemProcessing.Enabled = False
         menuItemAnimation.Enabled = False
         ds.Reset()

         FreeImage()
      End Sub

      Private Sub menuItemFile_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemFile.Popup
         Dim valid As Boolean = IsDatasetValid()

         menuItemClose.Enabled = valid
         menuItemSave.Enabled = valid
         menuItemInfo.Enabled = valid
      End Sub

      Private Function IsDatasetValid() As Boolean
         Dim element As DicomElement

         element = ds.FindFirstElement(Nothing, DemoDicomTags.SOPClassUID, True)
         If element Is Nothing Then
            Return False
         End If
         Return True
      End Function

      Private Sub menuItemInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemInfo.Click
         Dim dlgInfo As InfoDlg = New InfoDlg(ds)

         dlgInfo.ShowDialog()
      End Sub

      Private Sub menuItemNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemNew.Click
         Dim dlgNew As NewDatasetDlg = New NewDatasetDlg(ds)

         If dlgNew.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Cursor = Cursors.WaitCursor

            menuItemClose_Click(Nothing, Nothing)

            Try
               ds.Initialize(dlgNew.Class, dlgNew.InitializeFlags)

               menuItemDataset.Enabled = True
               menuItemProcessing.Enabled = True

               UpdateTree()
               If treeViewElements.Nodes.Count > 0 Then
                  treeViewElements.SelectedNode = treeViewElements.Nodes(0)
               End If
            Catch de As DicomException
               System.Diagnostics.Debug.Assert(False)

               Throw de
            Finally
               Cursor = Cursors.Arrow
            End Try
         End If
      End Sub

      Private Sub menuItemProcessing_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemProcessing.Popup
         Dim valid As Boolean = False
         Try
            If _viewer.Image IsNot Nothing Then
               valid = (_viewer.Image.PageCount > 0)
            End If
         Catch
            valid = False
         End Try
         menuItemGrayscale8.Enabled = valid
         menuItemGrayscale12.Enabled = valid
         menuItemGrayscale16.Enabled = valid
         menuItemInvert.Enabled = valid
         menuItemBrightness.Enabled = valid
         menuItemContrast.Enabled = valid
         menuItemFlip.Enabled = valid
         menuItemReverse.Enabled = valid
         menuItemRotate.Enabled = valid
         menuItemUpdate.Enabled = valid
         menuItemUnsharpMask.Enabled = valid
      End Sub

      Private Sub menuItemGrayscale8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemGrayscale8.Click
         Dim command As GrayscaleCommand = New GrayscaleCommand()

         command.BitsPerPixel = 8
         command.Run(_viewer.Image)
      End Sub

      Private Sub menuItemGrayscale12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemGrayscale12.Click
         Dim command As GrayscaleCommand = New GrayscaleCommand()

         command.BitsPerPixel = 12
         command.Run(_viewer.Image)
      End Sub

      Private Sub menuItemGrayscale16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemGrayscale16.Click
         Dim command As GrayscaleCommand = New GrayscaleCommand()

         command.BitsPerPixel = 16
         command.Run(_viewer.Image)
      End Sub

      Private Sub menuItemInvert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemInvert.Click
         Dim command As InvertCommand = New InvertCommand()

         command.Run(_viewer.Image)
      End Sub

      Private Sub menuItemBrightness_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemBrightness.Click
         Dim dlg As ValueDialog = New ValueDialog(ValueDialog.TypeConstants.Intensity)

         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then

            Dim command As ChangeIntensityCommand = New ChangeIntensityCommand(dlg.Value)

            command.Run(_viewer.Image)
         End If
      End Sub

      Private Sub menuItemContrast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemContrast.Click
         Dim dlg As ValueDialog = New ValueDialog(ValueDialog.TypeConstants.Contrast)

         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Dim command As ChangeContrastCommand = New ChangeContrastCommand(dlg.Value)

            command.Run(_viewer.Image)
         End If
      End Sub

      Private Sub menuItemFlip_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemFlip.Click
         Dim command As FlipCommand = New FlipCommand()

         command.Horizontal = False
         command.Run(_viewer.Image)

      End Sub

      Private Sub menuItemReverse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemReverse.Click
         Dim command As FlipCommand = New FlipCommand()

         command.Horizontal = True
         command.Run(_viewer.Image)
      End Sub

      Private Sub menuItemRotate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemRotate.Click
         Dim command As RotateCommand
         Dim dlg As RotateDialog = New RotateDialog()

         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            command = New RotateCommand(dlg.Angle, dlg.Flags, dlg.FillColor)
            command.Run(_viewer.Image)
         End If
      End Sub

      Private Sub UpdateTree()
         Try
            treeViewElements.BeginUpdate()
            treeViewElements.Nodes.Clear()
            If listView Then
               FillTree()
            Else
               FillTreeModules()
            End If
            treeViewElements.EndUpdate()
         Catch
         End Try
      End Sub
      Private Sub menuItemUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemUpdate.Click
         Dim imgElement As DicomElement = ds.FindFirstElement(Nothing, DemoDicomTags.PixelData, True)
         Dim dlgOptions As ImageOptionsDlg = New ImageOptionsDlg(ds, imgElement)

         If dlgOptions.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
               Dim image As RasterImage = _viewer.Image

               Cursor = Cursors.WaitCursor
               Try
                  treeViewElements.BeginUpdate()
                  treeViewElements.Nodes.Clear()
                  treeViewElements.EndUpdate()

                  If dlgOptions.Compression <> DicomImageCompressionType.None Then
                     Try
                        ds.ChangeTransferSyntax(DicomUidType.ExplicitVRLittleEndian, dlgOptions.QFactor, ChangeTransferSyntaxFlags.None)
                        imgElement = ds.FindFirstElement(Nothing, DemoDicomTags.PixelData, True)
                     Catch de As DicomException
                        Dim err As String = String.Format("Error changing transfer syntax!" & Constants.vbCrLf & Constants.vbCrLf & "{0}", de.Code.ToString())

                        MessageBox.Show(err, "Error")

                        Cursor = Cursors.Arrow
                        UpdateTree()
                        Return
                     End Try
                  End If

                  If dlgOptions.UseNewImageFile AndAlso Not dlgOptions.NewImage Is Nothing Then
                     image = dlgOptions.NewImage.Clone()
                     GetWindowLevelValues()
                  End If

                  If Not dlgOptions.NewImage Is Nothing Then
                     dlgOptions.NewImage.Dispose()
                  End If

                  If Not _viewer.Image Is Nothing AndAlso _viewer.Image.PageCount = 1 AndAlso Not image Is Nothing Then
                     ds.SetImage(imgElement, image, dlgOptions.Compression, dlgOptions.PhotoMetric, dlgOptions.BitsPerPixel, dlgOptions.QFactor, DicomSetImageFlags.AutoSetVoiLut)
                  ElseIf Not image Is Nothing Then
                     ds.SetImages(imgElement, image, dlgOptions.Compression, dlgOptions.PhotoMetric, dlgOptions.BitsPerPixel, dlgOptions.QFactor, DicomSetImageFlags.AutoSetVoiLut)
                  End If
                  ShowImage()
                  UpdateTree()
                  imageInfo = ds.GetImageInformation(imgElement, 0)
               Catch exception As Exception
                  System.Diagnostics.Debug.Assert(False)

                  Throw exception
               Finally
                  Cursor = Cursors.Arrow
               End Try

            Catch Ex As Exception
               MessageBox.Show(Ex.Message, "Error")
            End Try
         End If
      End Sub
      Private Sub PushMenuItemsState()

         Try
            _fileMenuEnabled = menuItemFile.Enabled
            _viewMenuEnabled = menuItemView.Enabled
            _tablesMenuEnabled = menuItemTables.Enabled
            _datasetMenuEnabled = menuItemDataset.Enabled
            _animationMenuEnabled = menuItemAnimation.Enabled
            _processingMenuEnabled = menuItemProcessing.Enabled
         Catch

         End Try

      End Sub

      Private Sub PopMenuItemsState()

         Try
            menuItemFile.Enabled = _fileMenuEnabled
            menuItemView.Enabled = _viewMenuEnabled
            menuItemTables.Enabled = _tablesMenuEnabled
            menuItemDataset.Enabled = _datasetMenuEnabled
            menuItemAnimation.Enabled = _animationMenuEnabled
            menuItemProcessing.Enabled = _processingMenuEnabled
         Catch

         End Try
      End Sub

      Private Sub DisableMenuItems()
         Try
            menuItemFile.Enabled = False
            menuItemView.Enabled = False
            menuItemTables.Enabled = False
            menuItemDataset.Enabled = False
            menuItemAnimation.Enabled = False
            menuItemProcessing.Enabled = False
         Catch

         End Try
      End Sub


      Private Sub menuItemPlay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemPlay.Click
         Dim count As Integer

         Cursor = Cursors.WaitCursor
         PushMenuItemsState()

         Try
            DisableMenuItems()
            _viewer.Zoom(ControlSizeMode.ActualSize, _viewer.ScaleFactor * 0.5F, _viewer.DefaultZoomOrigin)
            count = _viewer.Image.PageCount
            Dim x As Integer = 1
            Do While x <= count
               If Not _viewer Is Nothing Then
                  If Not _viewer.Image Is Nothing Then
                     _viewer.Image.Page = x
                  End If
                  _viewer.Refresh()
               End If
               System.Threading.Thread.Sleep(20)
               Application.DoEvents()
               x += 1
            Loop
         Finally
            PopMenuItemsState()
            If Not _viewer Is Nothing Then
               If Not _viewer.Image Is Nothing Then
                  _viewer.Image.Page = 1
               End If
            End If
            Cursor = Cursors.Arrow
         End Try

      End Sub

      Private Sub menuItemAnimation_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemAnimation.Popup
         If menuItemAnimation.Enabled Then
            menuItemFirst.Enabled = _viewer.Image.Page <> 1
            menuItemNext.Enabled = _viewer.Image.Page <> (_viewer.Image.PageCount)
            menuItemPrevious.Enabled = _viewer.Image.Page <> 1
            menuItemLast.Enabled = _viewer.Image.Page <> (_viewer.Image.PageCount)
         End If
      End Sub

      Private Sub menuItemFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemFirst.Click
         _viewer.Image.Page = 1
      End Sub

      Private Sub menuItemNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemNext.Click
         _viewer.Image.Page = (_viewer.Image.Page + 1)
      End Sub

      Private Sub menuItemPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemPrevious.Click
         _viewer.Image.Page = (_viewer.Image.Page - 1)
      End Sub

      Private Sub menuItemLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemLast.Click
         _viewer.Image.Page = _viewer.Image.PageCount
      End Sub

      Private Sub treeViewElements_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles treeViewElements.AfterSelect
         Try
            textBoxValues.Text = ""

            If Not treeViewElements.SelectedNode Is Nothing AndAlso Not treeViewElements.SelectedNode.Tag Is Nothing Then
               Dim node As TreeNode = treeViewElements.SelectedNode

               If node.Tag.GetType() Is GetType(DicomElement) Then
                  SelectElement(TryCast(node.Tag, DicomElement))
               Else
                  propertyGridElement.SelectedObject = Nothing
               End If
            End If
         Catch
         End Try
      End Sub

      Private Sub SelectElement(ByVal element As DicomElement)
         If (Not IsImageElement(element)) Then
            GetElementValues(element)
         Else
            If treeViewElements.SelectedNode.Parent Is Nothing Then
               If _viewer.Image.PageCount <> 1 Then
                  _viewer.Image.Page = 1
               End If
            Else
               Dim parent As TreeNode

               parent = treeViewElements.SelectedNode.Parent
               imgIndex = parent.Nodes.IndexOf(treeViewElements.SelectedNode) + 1
               If imgIndex > _viewer.Image.PageCount Then
                  imgIndex = _viewer.Image.PageCount
               End If
               _viewer.Image.Page = CShort(imgIndex)
            End If
         End If
         propertyGridElement.SelectedObject = element
      End Sub

      Private Function IsImageElement(ByVal element As DicomElement) As Boolean
         If Not element Is Nothing Then
            Dim tag As DicomTag

            tag = DicomTagTable.Instance.Find(element.Tag)


            '
            ' Pixel Data tags will not be display in our list box instead we will load
            '  them in the image viewer
            '
            If Not tag Is Nothing AndAlso tag.Name.IndexOf("Pixel Data") = -1 Then
               element = ds.GetParentElement(element)
               If Not element Is Nothing Then

                  tag = DicomTagTable.Instance.Find(element.Tag)


                  If Not tag Is Nothing AndAlso tag.Name.IndexOf("Pixel Data") <> -1 Then
                     Return True
                  End If
               End If
            Else
               Return False
            End If
         End If
         Return False
      End Function

      Private Sub GetElementValues(ByVal element As DicomElement)
         Dim value As String = ""
         If element.Length > &HFFF Then
            Dim b() As Byte = ds.GetBinaryValue(element, &HFFF)
            If b IsNot Nothing Then
               value = BitConverter.ToString(b)
               value = value.Replace("-", " ")
            End If
         Else
            value = ds.GetConvertValue(element)
            If value IsNot Nothing AndAlso value.Length > 0 Then
               value = value.Replace("\", Constants.vbCrLf)
            End If
         End If
         textBoxValues.Text = value
      End Sub

      Private Function FindTag(ByVal Tag As Long) As DicomTag
         Dim tag_Renamed As DicomTag = Nothing

         tag_Renamed = DicomTagTable.Instance.Find(Tag)
         Return tag_Renamed
      End Function

      Private Sub menuItemSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemSave.Click
         saveFileDialog1.Filter = "DCM File(*.dcm)|*.dcm|All files (*.*)|*.*"
         saveFileDialog1.AddExtension = True
         saveFileDialog1.Title = "Save Dicom File"
         If saveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
               ds.Save(saveFileDialog1.FileName, DicomDataSetSaveFlags.None)
            Catch de As DicomException
               Dim err As String = String.Format("Error saving dicom dataset!" & Constants.vbCrLf & Constants.vbCrLf & "{0}", de.Code.ToString())

               MessageBox.Show(err, "Error")
               Return
            End Try
         End If
      End Sub

      Private Function ReadCharacterSet() As DicomCharacterSetType
         ' If we do not find one of the character sets below, use the default
         Dim characterSet As DicomCharacterSetType = DicomCharacterSetType.Default
         Dim element As DicomElement = ds.FindFirstElement(Nothing, DemoDicomTags.SpecificCharacterSet, False)
         If Not element Is Nothing Then
            Dim sValue As String = ds.GetStringValue(element, 0)
            If Not sValue Is Nothing Then
               If sValue.Trim().Contains("ISO_IR 6") Then
                  characterSet = DicomCharacterSetType.Default
               ElseIf sValue.Trim().Contains("ISO_IR 100") Then
                  characterSet = DicomCharacterSetType.LatinAlphabetNo1
               ElseIf sValue.Trim().Contains("ISO_IR 101") Then
                  characterSet = DicomCharacterSetType.LatinAlphabetNo2
               ElseIf sValue.Trim().Contains("ISO_IR 109") Then
                  characterSet = DicomCharacterSetType.LatinAlphabetNo3
               ElseIf sValue.Trim().Contains("ISO_IR 110") Then
                  characterSet = DicomCharacterSetType.LatinAlphabetNo4
               ElseIf sValue.Trim().Contains("ISO_IR 144") Then
                  characterSet = DicomCharacterSetType.Cyrillic
               ElseIf sValue.Trim().Contains("ISO_IR 127") Then
                  characterSet = DicomCharacterSetType.Arabic
               ElseIf sValue.Trim().Contains("ISO_IR 126") Then
                  characterSet = DicomCharacterSetType.Greek
               ElseIf sValue.Trim().Contains("ISO_IR 138") Then
                  characterSet = DicomCharacterSetType.Hebrew
               ElseIf sValue.Trim().Contains("ISO_IR 148") Then
                  characterSet = DicomCharacterSetType.LatinAlphabetNo5
               ElseIf sValue.Trim().Contains("ISO_IR 13") Then
                  characterSet = DicomCharacterSetType.JapaneseJisX0201
               ElseIf sValue.Trim().Contains("ISO_IR 166") Then
                  characterSet = DicomCharacterSetType.Thai
               ElseIf sValue.Trim().Contains("ISO_IR 149") Then
                  characterSet = DicomCharacterSetType.Korean
               ElseIf sValue.Trim().Contains("ISO_IR 192") Then
                  characterSet = DicomCharacterSetType.UnicodeInUtf8
               ElseIf sValue.Trim().Contains("GB18030") Then
                  characterSet = DicomCharacterSetType.Gb18030
               End If
            End If
         End If
         Return characterSet
      End Function

      Private Sub menuItemEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemEdit.Click
         Dim element As DicomElement = TryCast(treeViewElements.SelectedNode.Tag, DicomElement)
         Dim dlgEdit As EditValueDlg = New EditValueDlg(ds, element)

         If (Not IsImageElement(element)) Then
            If dlgEdit.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
               Dim count As Integer

               count = dlgEdit.listBoxValues.Items.Count
               If count > 0 Then
                  Dim values As String = ""

                  For Each item As String In dlgEdit.listBoxValues.Items
                     If values.Length > 0 Then
                        values &= "\"
                     End If

                     values &= item
                  Next item
                  ds.FreeElementValue(element)
                  Dim ret As Boolean = False
                  Select Case element.VR
                     Case DicomVRType.SH, DicomVRType.LO, DicomVRType.ST, DicomVRType.PN, DicomVRType.LT, DicomVRType.UT
                        ' could be another code page (i.e. arabic)
                        ' Call SetStringValue instead and set the 'Specific Character Set (0008,0005)'
                        Dim characterSet As DicomCharacterSetType = ReadCharacterSet()
                        ret = ds.SetStringValue(element, values, characterSet)

                        ' If default fails, try adding as UTF-8
                        If ret = False Then
                           ret = ds.SetStringValue(element, values, DicomCharacterSetType.UnicodeInUtf8)
                        End If
                     Case Else
                        ret = ds.SetConvertValue(element, values, count)
                  End Select
               Else
                  'Dim b() As Byte = Nothing
                  'ds.SetBinaryValue(element, b, 0)
                  ds.FreeElementValue(element)
               End If

               treeViewElements_AfterSelect(Nothing, Nothing)
            End If
         Else
            menuItemUpdate_Click(Nothing, Nothing)
         End If
      End Sub

      Private Function IsControlPressed() As Boolean
         Dim pressed As Boolean

         pressed = ((CUShort(GetKeyState(VK_CONTROL))) And &H8000) <> 0
         Return pressed
      End Function


      Private Sub menuItemDataset_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemDataset.Popup
         If treeViewElements.SelectedNode Is Nothing OrElse Not treeViewElements.SelectedNode.Tag.GetType() Is GetType(DicomElement) Then
            menuItemEdit.Enabled = False
            menuItemElementDelete.Enabled = False
         Else
            Dim element As DicomElement = TryCast(treeViewElements.SelectedNode.Tag, DicomElement)

            Dim enable As Boolean = (Not ds.IsVolatileElement(element)) OrElse (ds.IsVolatileElement(element) AndAlso IsControlPressed())

            menuItemEdit.Enabled = enable
            menuItemElementDelete.Enabled = enable
         End If
         menuItemListView.Checked = listView
         menuItemModuleView.Checked = Not listView
         menuItemModuleView.Enabled = IsIodTableLoaded()
      End Sub

      Private Sub menuItemElementDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemElementDelete.Click
         Dim element As DicomElement = TryCast(treeViewElements.SelectedNode.Tag, DicomElement)

         Try
            ds.DeleteElement(element)
            treeViewElements.SelectedNode.Remove()
            If element.Tag = DemoDicomTags.PixelData Then
               FreeImage()
               menuItemAnimation.Enabled = False
            End If
         Catch de As DicomException
            Dim err As String = String.Format("Error deleting element!" & Constants.vbCrLf & Constants.vbCrLf & "{0}", de.Code.ToString())

            MessageBox.Show(err, "Error")
         End Try
      End Sub

      Private Sub menuItemElementInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemElementInsert.Click
         Cursor = Cursors.WaitCursor

         Try

            If treeViewElements.SelectedNode Is Nothing Then
               MessageBox.Show("No element selected, please start by selecting an element from the tree and try again.")
               Return
            End If
            Dim element As DicomElement = TryCast(treeViewElements.SelectedNode.Tag, DicomElement)
            Dim dlgInsert As InsertElementDlg = New InsertElementDlg(ds, element)

            If element Is Nothing Then
               MessageBox.Show("No element selected, please start by selecting an element from the tree and try again.")
               Return
            End If

            If dlgInsert.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
               Try
                  Dim temp As String
                  Dim newElement As DicomElement
                  Dim node As TreeNode = New TreeNode()

                  newElement = ds.InsertElement(element, dlgInsert.Child, dlgInsert.Tag.Code, DicomVRType.UN, dlgInsert.Sequence, -1)

                  temp = String.Format("{0:x4}:{1:x4} - ", Utils.GetGroup(CLng(dlgInsert.Tag.Code)), Utils.GetElement(CLng(dlgInsert.Tag.Code)))
                  temp = temp & dlgInsert.Tag.Name

                  node.Text = temp
                  node.Tag = newElement
                  If dlgInsert.Sequence Then
                     node.ImageIndex = 0
                  Else
                     node.ImageIndex = 1
                  End If
                  If dlgInsert.Sequence Then
                     node.SelectedImageIndex = 0
                  Else
                     node.SelectedImageIndex = 1
                  End If
                  If ds.IsVolatileElement(newElement) Then
                     node.ForeColor = Color.Red
                  End If

                  If dlgInsert.Child Then
                     treeViewElements.SelectedNode.Nodes.Add(node)
                     treeViewElements.SelectedNode.ImageIndex = 0
                     treeViewElements.SelectedNode.SelectedImageIndex = 0
                  Else
                     treeViewElements.Nodes.Insert(treeViewElements.SelectedNode.Index + 1, node)
                  End If
                  treeViewElements.SelectedNode = node
               Catch de As DicomException
                  Dim err As String = String.Format("Error inserting element. Element might already exist in the dataset!" & Constants.vbCrLf & Constants.vbCrLf & "Return Code: {0}", de.Code.ToString())


                  MessageBox.Show(err, "Error")
                  Return
               End Try
            End If
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False)

            Throw exception
         Finally
            Cursor = Cursors.Arrow
         End Try
      End Sub

      Private Sub _viewer_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            If _viewer.Image IsNot Nothing Then
                If e.Button.IsFlagged(MouseButtons.Left) Then
                    Dim tipMessage As String = GetPixelInformation(e.X, e.Y)
                    _toolTip.Show(tipMessage, _viewer, e.X + 25, e.Y + 25)
                End If

                If e.Button.IsFlagged(MouseButtons.Right) Then
                    wl.ReverseOrder = (_viewer.Image.GrayscaleMode = RasterGrayscaleMode.OrderedInverse) OrElse (isMonochrome1)
                    wl.Start(_viewer.Image, e.Location)
                End If
            End If
        End Sub

      Private Sub _viewer_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            If wl.WindowLeveling Then
                wl.Stop(e.Location)
            End If
            _toolTip.Hide(_viewer)
        End Sub

        Private Sub _viewer_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            If e.Button.IsFlagged(MouseButtons.Left) Then
                Dim tipMessage As String = GetPixelInformation(e.X, e.Y)
                _toolTip.Show(tipMessage, _viewer, e.X + 25, e.Y + 25)
            End If
            If e.Button.IsFlagged(MouseButtons.Right) Then
                If wl.WindowLeveling Then
                    wl.Process(New System.Drawing.Point(e.X, e.Y))
                    _viewer.Update()
                End If
            End If
        End Sub

        Private Function IsBitSet(ByVal b As Byte, ByVal pos As Integer) As Boolean
            Return (b And (1 << pos)) <> 0
        End Function

        Private Function IsBitSet(ByVal ba() As Byte, ByVal highBit As Integer) As Boolean
            Dim byteArrayIndex As Integer = highBit \ 8
            If ba.Length >= (byteArrayIndex + 1) Then
                Dim newBitToCheck As Integer = highBit Mod 8
                Return IsBitSet(ba(byteArrayIndex), newBitToCheck)
            End If
            Return False
        End Function

        Private Function GetHexPixelValue(ByVal bytes() As Byte) As String
            Dim hexPixelValue As String = String.Empty
            Select Case bytes.Length
                Case 1
                    hexPixelValue = String.Format("0x{0:X2}", bytes(0))

                Case 2
                    hexPixelValue = String.Format("0x{0:X4}", bytes(0) Or (CInt(Fix(bytes(1))) << 8))

                Case 3
                    hexPixelValue = String.Format("0x{0:X6}", bytes(0) Or (CInt(Fix(bytes(1))) << 8) Or (CInt(Fix(bytes(2))) << 16))

                Case 4
                    hexPixelValue = String.Format("0x{0:X8}", bytes(0) Or (CInt(Fix(bytes(1))) << 8) Or (CInt(Fix(bytes(2))) << 16) Or (CInt(Fix(bytes(3))) << 24))
            End Select
            Return hexPixelValue
        End Function

        Private Function GetPixelValue(ByVal bytes() As Byte, ByVal highBit As Integer, ByVal signed As Boolean) As String
            Dim pixelValue As String = String.Empty


            If signed AndAlso IsBitSet(bytes, highBit) Then
                Dim mask As UInteger = &HFFFFFFFFL
                mask = (mask << (highBit))

                If bytes.Length >= 1 Then
                    bytes(0) = bytes(0) Or CByte(mask And &HFF)
                End If

                If bytes.Length >= 2 Then
                    bytes(1) = bytes(1) Or CByte((mask And &HFF00) >> 8)
                End If

                If bytes.Length >= 3 Then
                    bytes(2) = bytes(2) Or CByte((mask And &HFF0000) >> 16)
                End If

                If bytes.Length >= 4 Then
                    bytes(3) = bytes(3) Or CByte((mask And &HFF000000L) >> 24)
                End If
            End If

            Select Case bytes.Length
                Case 1
                    Dim bytesCopy2() As Byte = {bytes(0), 0}
                    pixelValue = If((_viewer.Image.Signed), BitConverter.ToInt16(bytes, 0).ToString(), BitConverter.ToUInt16(bytesCopy2, 0).ToString())

                Case 2
                    pixelValue = If((_viewer.Image.Signed), BitConverter.ToInt16(bytes, 0).ToString(), BitConverter.ToUInt16(bytes, 0).ToString())

                Case 3
                    Dim bytesCopy4() As Byte = {bytes(0), bytes(1), bytes(2), 0}
                    pixelValue = If((_viewer.Image.Signed), BitConverter.ToInt32(bytesCopy4, 0).ToString(), BitConverter.ToUInt32(bytesCopy4, 0).ToString())

                Case 4
                    pixelValue = If((_viewer.Image.Signed), BitConverter.ToInt32(bytes, 0).ToString(), BitConverter.ToUInt32(bytes, 0).ToString())
            End Select
            Return pixelValue
        End Function


        Private Function GetPixelInformation(ByVal xOld As Integer, ByVal yOld As Integer) As String
            Dim leadPoint As New LeadPoint(xOld, yOld)

            ' from mouse to where it is in the image, taking care of scroll/zoom/DPI
            Dim convertedLeadTemp As LeadPoint = _viewer.ConvertPoint(Nothing, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, leadPoint)

            Dim leadPointFinal As LeadPoint = _viewer.Image.PointToImage(RasterViewPerspective.TopLeft, convertedLeadTemp)

            Dim xNew As Integer = leadPointFinal.X
            Dim yNew As Integer = leadPointFinal.Y

            Dim hexPixelValue As String = String.Empty
            Dim pixelValue As String = String.Empty
            Dim rgbColor As String = String.Empty
            Dim paletteOrLookupTable As String = String.Empty

            If xNew < _viewer.Image.Width AndAlso yNew < _viewer.Image.Height AndAlso xNew >= 0 AndAlso yNew >= 0 AndAlso _viewer.Image.BitsPerPixel <> 1 Then
                _viewer.Image.Access()
                Dim bytes() As Byte = _viewer.Image.GetPixelData(yNew, xNew)

                hexPixelValue = GetHexPixelValue(bytes)
                pixelValue = GetPixelValue(bytes, _viewer.Image.HighBit, _viewer.Image.Signed)

                Dim pixelColor As RasterColor = _viewer.Image.GetPixelColor(yNew, xNew)

                If pixelColor.Reserved = &H4 Then
                    paletteOrLookupTable = "Lookup Table (Palette)"
                ElseIf pixelColor.Reserved = &H1 Then
                    ' 8 bit index
                    paletteOrLookupTable = "Palette"
                End If
                pixelColor = _viewer.Image.GetTrueColorValue(pixelColor)

                rgbColor = String.Format("({0},{1},{2})", pixelColor.R, pixelColor.G, pixelColor.B)

                _viewer.Image.Release()
            End If

            Dim highBit As Integer = _viewer.Image.HighBit
            Dim imageInfo As String = String.Format("Bits Per Pixel = {0},  Bits Used = {1}, High Bit = {2}", _viewer.Image.BitsPerPixel, highBit + 1, highBit)
            Dim msg As String = String.Format("X = {1} , Y = {2}{0}Pixel Value (hex) = {3}{0}Pixel Value (dec) = {4}{0}RGB = {5}{0}{6}{0}{7}", Environment.NewLine, xNew, yNew, hexPixelValue, pixelValue, rgbColor, If(_viewer.Image.Signed, "Signed", "Unsigned"), imageInfo)

            If (Not String.IsNullOrEmpty(paletteOrLookupTable)) Then
                msg = msg & Environment.NewLine & paletteOrLookupTable
            End If

            Return msg
        End Function

        Private Sub ShowListView()
         If listView Then
            Return
         End If

         Dim wc As New WaitCursor()

         treeViewElements.BeginUpdate()
         treeViewElements.Nodes.Clear()
         tabPage1.Text = "List View"
         FillTree()
         listView = True
         If treeViewElements.Nodes.Count > 0 Then
            treeViewElements.SelectedNode = treeViewElements.Nodes(0)
         End If

         treeViewElements.EndUpdate()
      End Sub

      Private Sub menuItemListView_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuItemListView.Click
         ShowListView()
      End Sub

      Private Sub menuItemModuleView_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuItemModuleView.Click
         If (Not listView) Then
            Return
         End If

         Dim wc As WaitCursor = New WaitCursor()

         treeViewElements.BeginUpdate()
         treeViewElements.Nodes.Clear()
         tabPage1.Text = "Module View"
         FillTreeModules()
         listView = False
         If treeViewElements.Nodes.Count > 0 Then
            treeViewElements.SelectedNode = treeViewElements.Nodes(0)
         End If
         treeViewElements.EndUpdate()
      End Sub

      Private Sub menuItemUnsharpMask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItemUnsharpMask.Click
         Dim dlg As UnsharpMaskDialog = New UnsharpMaskDialog()
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            Dim command As UnsharpMaskCommand = New UnsharpMaskCommand(dlg.Amount, dlg.Radius, dlg.Threshold, dlg.ColorSpace)
            command.Run(_viewer.Image)
         End If
      End Sub

      Private Sub LoadXml()
         Me.openFileDialog1.Filter = "DICOM XML Files (*.xml)|*.xml|All files (*.*)|*.*"
         Me.openFileDialog1.Multiselect = True
         Me.openFileDialog1.Title = "Open DICOM XML File"

         If openFileDialog1.ShowDialog() = DialogResult.OK Then
            menuItemClose_Click(Nothing, New EventArgs())
            OpenDataset(openFileDialog1.FileName, DicomDemoFormat.Xml)
         End If
      End Sub

      Private Sub LoadJson()
         Me.openFileDialog1.Filter = "DICOM Json Model Files (*.json)|*.json|All files (*.*)|*.*"
         Me.openFileDialog1.Multiselect = True
         Me.openFileDialog1.Title = "Open DICOM Json Model File"

         If openFileDialog1.ShowDialog() = DialogResult.OK Then
            menuItemClose_Click(Nothing, New EventArgs())
            OpenDataset(openFileDialog1.FileName, DicomDemoFormat.Json)
         End If
      End Sub

      Private Sub menuItemSaveXml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItemSaveXml.Click
         saveFileDialog1.Filter = "XML File(*.xml)|*.xml|All files (*.*)|*.*"
         saveFileDialog1.AddExtension = True
         saveFileDialog1.Title = "Save Dicom XML File"
         If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            Try
               ds.SaveXml(saveFileDialog1.FileName, DicomDataSetSaveXmlFlags.None)
            Catch de As DicomException
               Dim err As String = String.Format("Error saving dicom dataset!" & Constants.vbCrLf & Constants.vbCrLf & "{0}", de.Code.ToString())

               MessageBox.Show(err, "Error")
               Return
            End Try
         End If
      End Sub


      Private Sub menuItemLoadXml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItemLoadXml.Click
         LoadXml()
      End Sub


      Private Sub menuItemModifyTables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItemModifyTables.Click
         Dim dlg As New ModifyTablesDlg()
         dlg.ShowDialog()

         If False = IsIodTableLoaded() Then
            ShowListView()
         End If
      End Sub

      Private Sub MainForm_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop
         Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
         If files.Length > 0 Then
            Try
               Dim format As DicomDemoFormat = DicomDemoFormat.Standard
               If files(0).EndsWith(".xml", StringComparison.OrdinalIgnoreCase) Then
                  format = DicomDemoFormat.Xml
               End If
               OpenDataset(files(0), format)
            Catch
               MessageBox.Show("Error loading image")
            End Try

         End If
      End Sub

      Private Sub MainForm_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
         If e.Data.GetDataPresent(DataFormats.FileDrop, False) = True Then
            e.Effect = DragDropEffects.All
         End If
      End Sub

#If LEADTOOLS_V19_OR_LATER Then
      Private _saveXmlFlags As DicomDataSetSaveXmlFlags = DicomDataSetSaveXmlFlags.NativeDicomModel Or DicomDataSetSaveXmlFlags.BulkDataUuid Or DicomDataSetSaveXmlFlags.TrimWhiteSpace

      Private _saveJsonFlags As DicomDataSetSaveJsonFlags = DicomDataSetSaveJsonFlags.BulkDataUri Or DicomDataSetSaveJsonFlags.TrimWhiteSpace

      Private Sub menuItemSaveNativeDicomOptions_Click(sender As System.Object, e As System.EventArgs) Handles menuItemSaveNativeDicomOptions.Click
         Dim saveDlg As New SaveDlg(SaveOptionsEnum.NativeDicomModel)
         saveDlg.SetXmlFlags(_saveXmlFlags)
         saveDlg.DicomDS = ds
         If saveDlg.ShowDialog() = DialogResult.OK Then
            _saveXmlFlags = saveDlg.GetXmlFlags()
         End If
      End Sub

      Private Sub menuItemSaveNativeDicom_Click(sender As System.Object, e As System.EventArgs) Handles menuItemSaveNativeDicom.Click
         SaveDlg.SaveXmlFile(ds, _saveXmlFlags)
      End Sub

      Private Sub menuItemSaveJsonOptions_Click(sender As System.Object, e As System.EventArgs) Handles menuItemSaveJsonOptions.Click
         Dim saveDlg As New SaveDlg(SaveOptionsEnum.JsonModel)
         saveDlg.SetJsonFlags(_saveJsonFlags)
         saveDlg.DicomDS = ds
         If saveDlg.ShowDialog() = DialogResult.OK Then
            _saveJsonFlags = saveDlg.GetJsonFlags()
         End If
      End Sub

      Private Sub menuItemSaveJson_Click(sender As System.Object, e As System.EventArgs) Handles menuItemSaveJson.Click
         SaveDlg.SaveJsonFile(ds, _saveJsonFlags)
      End Sub
#End If ' #If LEADTOOLS_V19_OR_LATER Then

      Private Sub MenuItemLoadJson_Click(sender As System.Object, e As System.EventArgs) Handles MenuItemLoadJson.Click
         LoadJson()
      End Sub

      Private Sub menuItemViewHistogram_Click(sender As Object, e As EventArgs) Handles menuItemViewHistogram.Click
         Dim isGrayscale As Boolean = False
         If _viewer.Image.GrayscaleMode <> RasterGrayscaleMode.None Then
            isGrayscale = True
         End If

         Dim dlg As HistogramDlg = New HistogramDlg(_viewer.Image, isGrayscale)
         dlg.ShowDialog()
      End Sub

      Private Sub MenuItemOptionsLoad_Click(sender As Object, e As EventArgs) Handles MenuItemOptionsLoad.Click
         Dim dlg As New LoadOptionsDlg()
         dlg.GetImageFlags = _getImageFlags

         dlg.Viewer = _viewer
         dlg.ds = ds

         dlg.ShowDialog()

         _getImageFlags = dlg.GetImageFlags
         ShowImage()
      End Sub
   End Class
End Namespace
