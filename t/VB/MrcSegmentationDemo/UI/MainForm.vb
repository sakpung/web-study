' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.IO

Imports Leadtools
Imports Leadtools.Mrc

Imports Leadtools.Twain
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.WinForms.CommonDialogs.File

Imports Leadtools.Drawing
Imports System.Drawing.Drawing2D
Imports Leadtools.Demos.Dialogs

Namespace MrcSegmentationDemo
   ''' <summary>
   ''' Summary description for MainForm.
   ''' </summary>
   Public Class MainForm : Inherits System.Windows.Forms.Form
      Private _mainMenu As System.Windows.Forms.MainMenu
      Private _miFileSeperator1 As System.Windows.Forms.MenuItem
      Private WithEvents _miFileTwainSelectSource As System.Windows.Forms.MenuItem
      Private WithEvents _miFileTwainAcquire As System.Windows.Forms.MenuItem
      Private _miFileSeperator2 As System.Windows.Forms.MenuItem
      Private WithEvents _miFileExit As System.Windows.Forms.MenuItem
      Private WithEvents _miFileSave As System.Windows.Forms.MenuItem
      Private _miFileSeperator3 As System.Windows.Forms.MenuItem
      Private WithEvents _miFileOpenMrc As System.Windows.Forms.MenuItem
      Private WithEvents _miFileSaveLeadMrc As System.Windows.Forms.MenuItem
      Private WithEvents _miFileSaveMrc As System.Windows.Forms.MenuItem
      Private _miFileSeperator4 As System.Windows.Forms.MenuItem
      Private WithEvents _miFile As System.Windows.Forms.MenuItem
      Private WithEvents _miEdit As System.Windows.Forms.MenuItem
      Private WithEvents _miEditCopy As System.Windows.Forms.MenuItem
      Private WithEvents _miEditPaste As System.Windows.Forms.MenuItem
      Private _miWindow As System.Windows.Forms.MenuItem
      Private WithEvents _miWindowCascade As System.Windows.Forms.MenuItem
      Private WithEvents _miWindowTileHorizontally As System.Windows.Forms.MenuItem
      Private WithEvents _miWindowTileVertically As System.Windows.Forms.MenuItem
      Private WithEvents _miWindowArrangeIcons As System.Windows.Forms.MenuItem
      Private WithEvents _miWindowCloseAll As System.Windows.Forms.MenuItem
      Private _miHelp As System.Windows.Forms.MenuItem
      Private WithEvents _miHelpAbout As System.Windows.Forms.MenuItem
      Private WithEvents _miFileSavePDF As System.Windows.Forms.MenuItem
      Private WithEvents _miFileExportSegment As System.Windows.Forms.MenuItem
      Private WithEvents _miFileImportSegment As System.Windows.Forms.MenuItem
      Private WithEvents _miColor As System.Windows.Forms.MenuItem
      Private WithEvents _miColorUniqueColors As System.Windows.Forms.MenuItem
      Private WithEvents _miColorResolution As System.Windows.Forms.MenuItem
      Private WithEvents _miColorHistogram As System.Windows.Forms.MenuItem
      Private _EditSeperator2 As System.Windows.Forms.MenuItem
      Private _EditSeperator1 As System.Windows.Forms.MenuItem
      Private WithEvents _miView As System.Windows.Forms.MenuItem
      Private WithEvents _miViewSelectedSegment As System.Windows.Forms.MenuItem
      Private WithEvents _miViewFitToWindow As System.Windows.Forms.MenuItem
      Private WithEvents _miViewNormal As System.Windows.Forms.MenuItem
      Private WithEvents _miViewZoomIn As System.Windows.Forms.MenuItem
      Private WithEvents _miViewZoomOut As System.Windows.Forms.MenuItem
      Private WithEvents _miSegmentation As System.Windows.Forms.MenuItem
      Private _miSegDraw As System.Windows.Forms.MenuItem
      Private WithEvents _miSegDrawSegment As System.Windows.Forms.MenuItem
      Private WithEvents _miSegDrawCancelDrawing As System.Windows.Forms.MenuItem
      Private WithEvents _miSegStartClearManual As System.Windows.Forms.MenuItem
      Private WithEvents _miSegStartPreserveManual As System.Windows.Forms.MenuItem
      Private WithEvents _miEditUndo As System.Windows.Forms.MenuItem
      Private _miSegSeperator1 As System.Windows.Forms.MenuItem
      Private _miSegSeperator2 As System.Windows.Forms.MenuItem
      Private WithEvents _miSegClearSegments As System.Windows.Forms.MenuItem
      Private WithEvents _miEditSelectAllSegments As System.Windows.Forms.MenuItem
      Private WithEvents _miEditDeleteSelectedSegment As System.Windows.Forms.MenuItem
      Private WithEvents _miPreference As System.Windows.Forms.MenuItem
      Private WithEvents _miPrefSegAndComOptions As System.Windows.Forms.MenuItem
      Private WithEvents _miPrefShowSegType As System.Windows.Forms.MenuItem
      Private _miPrefSeperator1 As System.Windows.Forms.MenuItem
      Private WithEvents _miViewEnlargeSegment As System.Windows.Forms.MenuItem
      Private WithEvents _miViewShowInNewWindow As System.Windows.Forms.MenuItem
      Private WithEvents _miViewShowType As System.Windows.Forms.MenuItem
      Private WithEvents _miViewShowProperties As System.Windows.Forms.MenuItem
      Private WithEvents _miViewShowHistogram As System.Windows.Forms.MenuItem
      Private WithEvents _miViewUniqueColors As System.Windows.Forms.MenuItem
      Private WithEvents _miViewCombineSegments As System.Windows.Forms.MenuItem
      Private _viewSeperator2 As System.Windows.Forms.MenuItem
      Private _viewSeperator3 As System.Windows.Forms.MenuItem
      Private _viewSeperator1 As System.Windows.Forms.MenuItem
      Private WithEvents _miFileSaveMultiPage As System.Windows.Forms.MenuItem
      Private WithEvents _miFileOpenImage As System.Windows.Forms.MenuItem
      Private WithEvents _miEditDeselectAll As System.Windows.Forms.MenuItem
      Private menuItem1 As MenuItem
      Private WithEvents menuItem2 As MenuItem
      Private WithEvents menuItem3 As MenuItem
      Private components As System.ComponentModel.IContainer

      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         '
         ' TODO: Add any constructor code after InitializeComponent call
         '
         InitClass()
      End Sub

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            CleanUp()

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
         Me._mainMenu = New System.Windows.Forms.MainMenu(Me.components)
         Me._miFile = New System.Windows.Forms.MenuItem()
         Me._miFileOpenImage = New System.Windows.Forms.MenuItem()
         Me._miFileOpenMrc = New System.Windows.Forms.MenuItem()
         Me._miFileSeperator1 = New System.Windows.Forms.MenuItem()
         Me._miFileTwainSelectSource = New System.Windows.Forms.MenuItem()
         Me._miFileTwainAcquire = New System.Windows.Forms.MenuItem()
         Me._miFileSeperator2 = New System.Windows.Forms.MenuItem()
         Me._miFileSave = New System.Windows.Forms.MenuItem()
         Me._miFileSaveLeadMrc = New System.Windows.Forms.MenuItem()
         Me._miFileSaveMrc = New System.Windows.Forms.MenuItem()
         Me._miFileSavePDF = New System.Windows.Forms.MenuItem()
         Me._miFileSaveMultiPage = New System.Windows.Forms.MenuItem()
         Me._miFileSeperator3 = New System.Windows.Forms.MenuItem()
         Me._miFileExportSegment = New System.Windows.Forms.MenuItem()
         Me._miFileImportSegment = New System.Windows.Forms.MenuItem()
         Me._miFileSeperator4 = New System.Windows.Forms.MenuItem()
         Me._miFileExit = New System.Windows.Forms.MenuItem()
         Me._miEdit = New System.Windows.Forms.MenuItem()
         Me._miEditUndo = New System.Windows.Forms.MenuItem()
         Me._EditSeperator1 = New System.Windows.Forms.MenuItem()
         Me._miEditCopy = New System.Windows.Forms.MenuItem()
         Me._miEditPaste = New System.Windows.Forms.MenuItem()
         Me._EditSeperator2 = New System.Windows.Forms.MenuItem()
         Me._miEditSelectAllSegments = New System.Windows.Forms.MenuItem()
         Me._miEditDeselectAll = New System.Windows.Forms.MenuItem()
         Me._miEditDeleteSelectedSegment = New System.Windows.Forms.MenuItem()
         Me._miView = New System.Windows.Forms.MenuItem()
         Me._miViewSelectedSegment = New System.Windows.Forms.MenuItem()
         Me._miViewEnlargeSegment = New System.Windows.Forms.MenuItem()
         Me._miViewShowInNewWindow = New System.Windows.Forms.MenuItem()
         Me._viewSeperator2 = New System.Windows.Forms.MenuItem()
         Me._miViewShowType = New System.Windows.Forms.MenuItem()
         Me._miViewShowProperties = New System.Windows.Forms.MenuItem()
         Me._miViewShowHistogram = New System.Windows.Forms.MenuItem()
         Me._miViewUniqueColors = New System.Windows.Forms.MenuItem()
         Me._viewSeperator3 = New System.Windows.Forms.MenuItem()
         Me._miViewCombineSegments = New System.Windows.Forms.MenuItem()
         Me._viewSeperator1 = New System.Windows.Forms.MenuItem()
         Me._miViewFitToWindow = New System.Windows.Forms.MenuItem()
         Me._miViewNormal = New System.Windows.Forms.MenuItem()
         Me._miViewZoomIn = New System.Windows.Forms.MenuItem()
         Me._miViewZoomOut = New System.Windows.Forms.MenuItem()
         Me._miSegmentation = New System.Windows.Forms.MenuItem()
         Me._miSegDraw = New System.Windows.Forms.MenuItem()
         Me._miSegDrawSegment = New System.Windows.Forms.MenuItem()
         Me._miSegDrawCancelDrawing = New System.Windows.Forms.MenuItem()
         Me._miSegSeperator1 = New System.Windows.Forms.MenuItem()
         Me._miSegStartClearManual = New System.Windows.Forms.MenuItem()
         Me._miSegStartPreserveManual = New System.Windows.Forms.MenuItem()
         Me._miSegSeperator2 = New System.Windows.Forms.MenuItem()
         Me._miSegClearSegments = New System.Windows.Forms.MenuItem()
         Me._miColor = New System.Windows.Forms.MenuItem()
         Me._miColorResolution = New System.Windows.Forms.MenuItem()
         Me._miColorHistogram = New System.Windows.Forms.MenuItem()
         Me._miColorUniqueColors = New System.Windows.Forms.MenuItem()
         Me._miPreference = New System.Windows.Forms.MenuItem()
         Me._miPrefSegAndComOptions = New System.Windows.Forms.MenuItem()
         Me._miPrefSeperator1 = New System.Windows.Forms.MenuItem()
         Me._miPrefShowSegType = New System.Windows.Forms.MenuItem()
         Me._miWindow = New System.Windows.Forms.MenuItem()
         Me._miWindowCascade = New System.Windows.Forms.MenuItem()
         Me._miWindowTileHorizontally = New System.Windows.Forms.MenuItem()
         Me._miWindowTileVertically = New System.Windows.Forms.MenuItem()
         Me._miWindowArrangeIcons = New System.Windows.Forms.MenuItem()
         Me._miWindowCloseAll = New System.Windows.Forms.MenuItem()
         Me._miHelp = New System.Windows.Forms.MenuItem()
         Me._miHelpAbout = New System.Windows.Forms.MenuItem()
         Me.menuItem1 = New System.Windows.Forms.MenuItem()
         Me.menuItem2 = New System.Windows.Forms.MenuItem()
         Me.menuItem3 = New System.Windows.Forms.MenuItem()
         Me.SuspendLayout()
         ' 
         ' _mainMenu
         ' 
         Me._mainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFile, Me._miEdit, Me._miView, Me._miSegmentation, Me._miColor, Me._miPreference, Me._miWindow, Me._miHelp})
         ' 
         ' _miFile
         ' 
         Me._miFile.Index = 0
         Me._miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFileOpenImage, Me._miFileOpenMrc, Me._miFileSeperator1, Me._miFileTwainSelectSource, Me._miFileTwainAcquire, Me._miFileSeperator2, Me._miFileSave, Me._miFileSaveLeadMrc, Me._miFileSaveMrc, Me._miFileSavePDF, Me._miFileSaveMultiPage, Me._miFileSeperator3, Me._miFileExportSegment, Me._miFileImportSegment, Me._miFileSeperator4, Me._miFileExit})
         Me._miFile.Text = "&File"
         ' 
         ' _miFileOpenImage
         ' 
         Me._miFileOpenImage.Index = 0
         Me._miFileOpenImage.RadioCheck = True
         Me._miFileOpenImage.Shortcut = System.Windows.Forms.Shortcut.CtrlO
         Me._miFileOpenImage.Text = "Open &Image..."
         ' 
         ' _miFileOpenMrc
         ' 
         Me._miFileOpenMrc.Index = 1
         Me._miFileOpenMrc.Text = "Open &Mrc..."
         ' 
         ' _miFileSeperator1
         ' 
         Me._miFileSeperator1.Index = 2
         Me._miFileSeperator1.Text = "-"
         ' 
         ' _miFileTwainSelectSource
         ' 
         Me._miFileTwainSelectSource.Index = 3
         Me._miFileTwainSelectSource.RadioCheck = True
         Me._miFileTwainSelectSource.Text = "TWAIN Se&lect Source..."
         ' 
         ' _miFileTwainAcquire
         ' 
         Me._miFileTwainAcquire.Index = 4
         Me._miFileTwainAcquire.RadioCheck = True
         Me._miFileTwainAcquire.Text = "TWAIN Ac&quire..."
         ' 
         ' _miFileSeperator2
         ' 
         Me._miFileSeperator2.Index = 5
         Me._miFileSeperator2.Text = "-"
         ' 
         ' _miFileSave
         ' 
         Me._miFileSave.Index = 6
         Me._miFileSave.RadioCheck = True
         Me._miFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
         Me._miFileSave.Text = "Sa&ve As..."
         ' 
         ' _miFileSaveLeadMrc
         ' 
         Me._miFileSaveLeadMrc.Index = 7
         Me._miFileSaveLeadMrc.Text = "Save As &Lead Mrc..."
         ' 
         ' _miFileSaveMrc
         ' 
         Me._miFileSaveMrc.Index = 8
         Me._miFileSaveMrc.Text = "&Save As Mrc..."
         ' 
         ' _miFileSavePDF
         ' 
         Me._miFileSavePDF.Index = 9
         Me._miFileSavePDF.Text = "Save As &PDF..."
         ' 
         ' _miFileSaveMultiPage
         ' 
         Me._miFileSaveMultiPage.Index = 10
         Me._miFileSaveMultiPage.Text = "Save Multi-Pa&ge..."
         ' 
         ' _miFileSeperator3
         ' 
         Me._miFileSeperator3.Index = 11
         Me._miFileSeperator3.RadioCheck = True
         Me._miFileSeperator3.Text = "-"
         ' 
         ' _miFileExportSegment
         ' 
         Me._miFileExportSegment.Enabled = False
         Me._miFileExportSegment.Index = 12
         Me._miFileExportSegment.Text = "&Export Segments..."
         ' 
         ' _miFileImportSegment
         ' 
         Me._miFileImportSegment.Index = 13
         Me._miFileImportSegment.Text = "&Import Segments..."
         ' 
         ' _miFileSeperator4
         ' 
         Me._miFileSeperator4.Index = 14
         Me._miFileSeperator4.Text = "-"
         ' 
         ' _miFileExit
         ' 
         Me._miFileExit.Index = 15
         Me._miFileExit.RadioCheck = True
         Me._miFileExit.Text = "E&xit"
         ' 
         ' _miEdit
         ' 
         Me._miEdit.Index = 1
         Me._miEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miEditUndo, Me._EditSeperator1, Me._miEditCopy, Me._miEditPaste, Me._EditSeperator2, Me._miEditSelectAllSegments, Me._miEditDeselectAll, Me._miEditDeleteSelectedSegment})
         Me._miEdit.Text = "&Edit"
         ' 
         ' _miEditUndo
         ' 
         Me._miEditUndo.Index = 0
         Me._miEditUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ
         Me._miEditUndo.Text = "&Undo"
         ' 
         ' _EditSeperator1
         ' 
         Me._EditSeperator1.Index = 1
         Me._EditSeperator1.Text = "-"
         ' 
         ' _miEditCopy
         ' 
         Me._miEditCopy.Index = 2
         Me._miEditCopy.RadioCheck = True
         Me._miEditCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC
         Me._miEditCopy.Text = "&Copy"
         ' 
         ' _miEditPaste
         ' 
         Me._miEditPaste.Index = 3
         Me._miEditPaste.RadioCheck = True
         Me._miEditPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV
         Me._miEditPaste.Text = "&Paste"
         ' 
         ' _EditSeperator2
         ' 
         Me._EditSeperator2.Index = 4
         Me._EditSeperator2.Text = "-"
         ' 
         ' _miEditSelectAllSegments
         ' 
         Me._miEditSelectAllSegments.Index = 5
         Me._miEditSelectAllSegments.Shortcut = System.Windows.Forms.Shortcut.CtrlA
         Me._miEditSelectAllSegments.Text = "Select All Segments"
         ' 
         ' _miEditDeselectAll
         ' 
         Me._miEditDeselectAll.Index = 6
         Me._miEditDeselectAll.Shortcut = System.Windows.Forms.Shortcut.CtrlD
         Me._miEditDeselectAll.Text = "&Deselect All"
         ' 
         ' _miEditDeleteSelectedSegment
         ' 
         Me._miEditDeleteSelectedSegment.Index = 7
         Me._miEditDeleteSelectedSegment.Shortcut = System.Windows.Forms.Shortcut.Del
         Me._miEditDeleteSelectedSegment.Text = "Delete Selected Segment"
         ' 
         ' _miView
         ' 
         Me._miView.Index = 2
         Me._miView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miViewSelectedSegment, Me._viewSeperator1, Me._miViewFitToWindow, Me._miViewNormal, Me._miViewZoomIn, Me._miViewZoomOut})
         Me._miView.Text = "&View"
         ' 
         ' _miViewSelectedSegment
         ' 
         Me._miViewSelectedSegment.Index = 0
         Me._miViewSelectedSegment.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miViewEnlargeSegment, Me._miViewShowInNewWindow, Me._viewSeperator2, Me._miViewShowType, Me._miViewShowProperties, Me._miViewShowHistogram, Me._miViewUniqueColors, Me._viewSeperator3, Me._miViewCombineSegments})
         Me._miViewSelectedSegment.Text = "Selected Segment"
         ' 
         ' _miViewEnlargeSegment
         ' 
         Me._miViewEnlargeSegment.Index = 0
         Me._miViewEnlargeSegment.Text = "Enlarge Segment"
         ' 
         ' _miViewShowInNewWindow
         ' 
         Me._miViewShowInNewWindow.Index = 1
         Me._miViewShowInNewWindow.Text = "Show In New Window"
         ' 
         ' _viewSeperator2
         ' 
         Me._viewSeperator2.Index = 2
         Me._viewSeperator2.Text = "-"
         ' 
         ' _miViewShowType
         ' 
         Me._miViewShowType.Index = 3
         Me._miViewShowType.Text = "Show Type..."
         ' 
         ' _miViewShowProperties
         ' 
         Me._miViewShowProperties.Index = 4
         Me._miViewShowProperties.Text = "Show Properties..."
         ' 
         ' _miViewShowHistogram
         ' 
         Me._miViewShowHistogram.Index = 5
         Me._miViewShowHistogram.Text = "Show Histogram..."
         ' 
         ' _miViewUniqueColors
         ' 
         Me._miViewUniqueColors.Index = 6
         Me._miViewUniqueColors.Text = "Unique Colors..."
         ' 
         ' _viewSeperator3
         ' 
         Me._viewSeperator3.Index = 7
         Me._viewSeperator3.Text = "-"
         ' 
         ' _miViewCombineSegments
         ' 
         Me._miViewCombineSegments.Index = 8
         Me._miViewCombineSegments.Text = "Combine Segments"
         ' 
         ' _viewSeperator1
         ' 
         Me._viewSeperator1.Index = 1
         Me._viewSeperator1.Text = "-"
         ' 
         ' _miViewFitToWindow
         ' 
         Me._miViewFitToWindow.Index = 2
         Me._miViewFitToWindow.Text = "&Fit To Window"
         ' 
         ' _miViewNormal
         ' 
         Me._miViewNormal.Index = 3
         Me._miViewNormal.Text = "&Normal"
         ' 
         ' _miViewZoomIn
         ' 
         Me._miViewZoomIn.Index = 4
         Me._miViewZoomIn.Text = "Zoom &In +"
         ' 
         ' _miViewZoomOut
         ' 
         Me._miViewZoomOut.Index = 5
         Me._miViewZoomOut.Text = "Zoom &Out -"
         ' 
         ' _miSegmentation
         ' 
         Me._miSegmentation.Index = 3
         Me._miSegmentation.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miSegDraw, Me.menuItem1, Me._miSegSeperator1, Me._miSegStartClearManual, Me._miSegStartPreserveManual, Me._miSegSeperator2, Me._miSegClearSegments})
         Me._miSegmentation.Text = "&Segmentation"
         ' 
         ' _miSegDraw
         ' 
         Me._miSegDraw.Index = 0
         Me._miSegDraw.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miSegDrawSegment, Me._miSegDrawCancelDrawing})
         Me._miSegDraw.Text = "Draw"
         ' 
         ' _miSegDrawSegment
         ' 
         Me._miSegDrawSegment.Index = 0
         Me._miSegDrawSegment.Text = "Draw Se&gment"
         ' 
         ' _miSegDrawCancelDrawing
         ' 
         Me._miSegDrawCancelDrawing.Enabled = False
         Me._miSegDrawCancelDrawing.Index = 1
         Me._miSegDrawCancelDrawing.Text = "Cancel D&rawing"
         ' 
         ' _miSegSeperator1
         ' 
         Me._miSegSeperator1.Index = 2
         Me._miSegSeperator1.Text = "-"
         ' 
         ' _miSegStartClearManual
         ' 
         Me._miSegStartClearManual.Index = 3
         Me._miSegStartClearManual.Text = "Start Auto And C&lear Manual Segment"
         ' 
         ' _miSegStartPreserveManual
         ' 
         Me._miSegStartPreserveManual.Enabled = False
         Me._miSegStartPreserveManual.Index = 4
         Me._miSegStartPreserveManual.Text = "Start Auto And P&reserve Manual Segment"
         ' 
         ' _miSegSeperator2
         ' 
         Me._miSegSeperator2.Index = 5
         Me._miSegSeperator2.Text = "-"
         ' 
         ' _miSegClearSegments
         ' 
         Me._miSegClearSegments.Enabled = False
         Me._miSegClearSegments.Index = 6
         Me._miSegClearSegments.Text = "&Clear Segments"
         ' 
         ' _miColor
         ' 
         Me._miColor.Index = 4
         Me._miColor.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miColorResolution, Me._miColorHistogram, Me._miColorUniqueColors})
         Me._miColor.Text = "&Color"
         ' 
         ' _miColorResolution
         ' 
         Me._miColorResolution.Index = 0
         Me._miColorResolution.Text = "Color &Resolution..."
         ' 
         ' _miColorHistogram
         ' 
         Me._miColorHistogram.Index = 1
         Me._miColorHistogram.Text = "View &Histogram..."
         ' 
         ' _miColorUniqueColors
         ' 
         Me._miColorUniqueColors.Index = 2
         Me._miColorUniqueColors.Text = "&Unique Colors..."
         ' 
         ' _miPreference
         ' 
         Me._miPreference.Index = 5
         Me._miPreference.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miPrefSegAndComOptions, Me._miPrefSeperator1, Me._miPrefShowSegType})
         Me._miPreference.Text = "&Preference"
         ' 
         ' _miPrefSegAndComOptions
         ' 
         Me._miPrefSegAndComOptions.Index = 0
         Me._miPrefSegAndComOptions.Text = "Segmentation And Compression &Options..."
         ' 
         ' _miPrefSeperator1
         ' 
         Me._miPrefSeperator1.Index = 1
         Me._miPrefSeperator1.Text = "-"
         ' 
         ' _miPrefShowSegType
         ' 
         Me._miPrefShowSegType.Checked = True
         Me._miPrefShowSegType.Index = 2
         Me._miPrefShowSegType.Text = "Show Segments &Type"
         ' 
         ' _miWindow
         ' 
         Me._miWindow.Index = 6
         Me._miWindow.MdiList = True
         Me._miWindow.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miWindowCascade, Me._miWindowTileHorizontally, Me._miWindowTileVertically, Me._miWindowArrangeIcons, Me._miWindowCloseAll})
         Me._miWindow.Text = "&Window"
         ' 
         ' _miWindowCascade
         ' 
         Me._miWindowCascade.Index = 0
         Me._miWindowCascade.Shortcut = System.Windows.Forms.Shortcut.ShiftF5
         Me._miWindowCascade.Text = "&Cascade"
         ' 
         ' _miWindowTileHorizontally
         ' 
         Me._miWindowTileHorizontally.Index = 1
         Me._miWindowTileHorizontally.Shortcut = System.Windows.Forms.Shortcut.ShiftF4
         Me._miWindowTileHorizontally.Text = "Tile &Horizontally"
         ' 
         ' _miWindowTileVertically
         ' 
         Me._miWindowTileVertically.Index = 2
         Me._miWindowTileVertically.Text = "Tile &Vertically"
         ' 
         ' _miWindowArrangeIcons
         ' 
         Me._miWindowArrangeIcons.Index = 3
         Me._miWindowArrangeIcons.Text = "Arrange &Icons"
         ' 
         ' _miWindowCloseAll
         ' 
         Me._miWindowCloseAll.Index = 4
         Me._miWindowCloseAll.Text = "Close &All"
         ' 
         ' _miHelp
         ' 
         Me._miHelp.Index = 7
         Me._miHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miHelpAbout})
         Me._miHelp.Text = "&Help"
         ' 
         ' _miHelpAbout
         ' 
         Me._miHelpAbout.Index = 0
         Me._miHelpAbout.Text = "&About..."
         ' 
         ' menuItem1
         ' 
         Me.menuItem1.Index = 1
         Me.menuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItem2, Me.menuItem3})
         Me.menuItem1.Text = "Segmentation &Method"
         ' 
         ' menuItem2
         ' 
         Me.menuItem2.Checked = True
         Me.menuItem2.Index = 0
         Me.menuItem2.Text = "N&ormal Segmentation"
         ' 
         ' menuItem3
         ' 
         Me.menuItem3.Index = 1
         Me.menuItem3.Text = "Ad&vanced Feature-Based Segmentation"
         ' 
         ' MainForm
         ' 
         Me.AllowDrop = True
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(712, 471)
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.IsMdiContainer = True
         Me.Menu = Me._mainMenu
         Me.Name = "MainForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "MainForm"
         Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private _codecs As RasterCodecs
      Private _fillColor As RasterColor

      Private _twainSession As TwainSession
      Private _acquirePageCount As Integer
      Private _inTwainAcquire As Boolean
      Private _paintProperties As RasterPaintProperties

      Private Shared ReadOnly _minimumScaleFactor As Single = 0.05F
      Private Shared ReadOnly _maximumScaleFactor As Single = 11.0F

      '    Mrc:
      Public _pictureCoder As Integer
      Public _grayscaleCoder8Bit As Integer
      Public _textCoder2Bit As Integer
      Public _grayscaleCoder2Bit As Integer
      Public _maskCoder As Integer
      Public _qFactor As Integer
      Public _gSQFactor As Integer

      '    PDF:
      Public _pDFPictureCoder As Integer
      Public _pDFTextCoder2Bit As Integer
      Public _pDFMaskCoder As Integer
      Public _pDFQFactor As Integer

      '    Segmentation:
      Public _inputImageType As Integer
      Public _outputImageType As Integer

      Public _bGThreshold As Integer
      Public _cleanSize As Integer
      Public _combineThreshold As Integer
      Public _quality As Integer
      Public _clrThreshold As Integer
      Public _typeIndex As Integer
      Public _check As Boolean

      Public _userDefineBGThreshold As Integer
      Public _userDefineCleanSize As Integer
      Public _userDefineCombineThreshold As Integer
      Public _userDefineQuality As Integer
      Public _userDefineclrThreshold As Integer
      Public _userDefineTypeIndex As Integer
      Public _userDefineCheck As Boolean

      Public _segmentationMethod As Boolean

      '    Combine:
      Public _combineType As Integer
      Public _combineFactor As Integer

      Public _backColor As Color
      Public _foreColor As Color

      Private checkedWindowMenu As MenuItem
      Private checkedViewMenu As MenuItem

      Private _setPdfOptions As Boolean
      Private _xResolution As Integer
      Private _yResolution As Integer

      Private _openInitialPath As String = String.Empty

      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      <STAThread()> _
      Shared Sub Main()
         

         If Not Support.SetLicense() Then
            Return
         End If

         If RasterSupport.IsLocked(RasterSupportType.Document) Then
            MessageBox.Show("Document support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
         End If

         Application.EnableVisualStyles()
         Application.DoEvents()

         Application.Run(New MainForm())
      End Sub

      Private Sub InitClass()
         Messager.Caption = "LEADTOOLS for .NET VB Mrc Segmentation Demo"
         Text = Messager.Caption

         _codecs = New RasterCodecs()

         _fillColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.White)
         _paintProperties = RasterPaintProperties.Default
         _paintProperties.PaintDisplayMode = _paintProperties.PaintDisplayMode Or RasterPaintDisplayModeFlags.ScaleToGray

         checkedWindowMenu = _miWindowCascade
         checkedWindowMenu.Checked = True

         checkedViewMenu = _miViewNormal
         checkedViewMenu.Checked = True

         '    Mrc:
         _pictureCoder = 6
         _grayscaleCoder8Bit = 4
         _textCoder2Bit = 0
         _grayscaleCoder2Bit = 0
         _maskCoder = 0
         _qFactor = 20
         _gSQFactor = 20

         '    PDF:
         _pDFPictureCoder = 2
         _pDFTextCoder2Bit = 0
         _pDFMaskCoder = 0
         _pDFQFactor = 50

         '    Segmentation:
         _inputImageType = 0
         _outputImageType = 0

         _bGThreshold = 15
         _cleanSize = 7
         _combineThreshold = 100
         _quality = 50
         _clrThreshold = 25
         _typeIndex = 1
         _check = False

         _userDefineBGThreshold = 15
         _userDefineCleanSize = 7
         _userDefineCombineThreshold = 100
         _userDefineclrThreshold = 25
         _userDefineQuality = 50
         _userDefineTypeIndex = 1
         _userDefineCheck = False

         _segmentationMethod = False


         '    Combine:
         _combineType = 2
         _combineFactor = 30

         _backColor = Color.White
         _foreColor = Color.Black

         _setPdfOptions = False
         _xResolution = 150
         _yResolution = 150


         Try
            Using wait As WaitCursor = New WaitCursor()

               If TwainSession.IsAvailable(Me.Handle) Then
                  _twainSession = New TwainSession()

                  _twainSession.Startup(Me.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None)
                  AddHandler _twainSession.AcquirePage, AddressOf _twainSession_AcquirePage
               End If
            End Using
         Catch ex As TwainException
            If ex.Code = TwainExceptionCode.InvalidDll Then
               _twainSession = Nothing
               Messager.ShowError(Me, "You have an old version of TWAINDSM.DLL. Please download latest version of this DLL from www.twain.org")
            Else
               _twainSession = Nothing
               Messager.ShowError(Me, ex)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
            _twainSession = Nothing
         End Try

         LoadMRC(True)
         UpdateControls()

         menuItem1.Visible = False
      End Sub

      Private Sub CleanUp()

         If Not _twainSession Is Nothing Then
            Try
               _twainSession.Shutdown()
            Catch ex As Exception
               Messager.ShowError(Me, ex)
            End Try
         End If
      End Sub

      Public ReadOnly Property ZoomIn() As MenuItem
         Get
            Return _miViewZoomIn
         End Get
      End Property

      Public ReadOnly Property ZoomOut() As MenuItem
         Get
            Return _miViewZoomOut
         End Get
      End Property

      Public ReadOnly Property PreserveManualMenuItem() As MenuItem
         Get
            Return _miSegStartPreserveManual
         End Get
      End Property

      Public ReadOnly Property ActiveViewerForm() As ViewerForm
         Get
            Return TryCast(ActiveMdiChild, ViewerForm)
         End Get
      End Property

      Public ReadOnly Property ShowSegmentType() As Boolean
         Get
            Return _miPrefShowSegType.Checked
         End Get
      End Property

      Public Sub UpdateControls()
         Dim activeForm As ViewerForm = ActiveViewerForm

         EnableAndVisibleMenu(_miFileTwainSelectSource, Not _twainSession Is Nothing)
         EnableAndVisibleMenu(_miFileTwainAcquire, Not _twainSession Is Nothing)
         EnableAndVisibleMenu(_miFileSeperator2, Not _twainSession Is Nothing)
         EnableAndVisibleMenu(_miFileSave, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miFileSaveLeadMrc, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miFileSaveMrc, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miFileSavePDF, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miFileSaveMultiPage, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miFileSeperator3, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miFileExportSegment, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miFileImportSegment, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miFileSeperator4, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miEditUndo, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_EditSeperator1, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miEditCopy, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_EditSeperator2, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miEditSelectAllSegments, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miEditDeleteSelectedSegment, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miEditDeselectAll, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miView, Not activeForm Is Nothing)
         If Not activeForm Is Nothing Then
            EnableAndVisibleMenu(_miEditSelectAllSegments, activeForm.MrcStarted)
            EnableAndVisibleMenu(_miEditDeleteSelectedSegment, activeForm.MrcStarted)
            EnableAndVisibleMenu(_miEditDeselectAll, activeForm.MrcStarted)
            EnableAndVisibleMenu(_EditSeperator2, activeForm.MrcStarted)
            EnableAndVisibleMenu(_miViewSelectedSegment, activeForm.MrcStarted)
            EnableAndVisibleMenu(_viewSeperator1, activeForm.MrcStarted)
            EnableAndVisibleMenu(_miViewSelectedSegment, (activeForm.SelectedSegment >= 0))
            EnableAndVisibleMenu(_viewSeperator1, (activeForm.SelectedSegment >= 0))
            _miEditDeselectAll.Enabled = (activeForm.SelectedSegment >= 0)
         End If
         EnableAndVisibleMenu(_miSegmentation, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miColor, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miPreference, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miWindow, Not activeForm Is Nothing)
      End Sub

      Private Sub EnableAndVisibleMenu(ByVal menu As MenuItem, ByVal value As Boolean)
         menu.Enabled = value
         menu.Visible = value
      End Sub

      Private Sub _miFileOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileOpenImage.Click
         Try
            Dim info As ImageInformation = LoadImage()

            If Not info Is Nothing Then
               NewImage(info)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateControls()
         End Try
      End Sub

      Private Sub _miFileOpenMrc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileOpenMrc.Click
         LoadMRC(False)
         UpdateControls()
      End Sub

      Private Sub LoadMRC(ByVal loadDefaultImage As Boolean)
         Dim fileName As String = String.Empty

         Try
            If loadDefaultImage Then
               fileName = DemosGlobal.ImagesFolder & "\sample.mrc"
            Else
               Dim ofd As OpenFileDialog = New OpenFileDialog()

               ofd.Filter = "Mrc Files (*.mrc)|*.mrc"
               ofd.Title = "Open Mrc"

               If ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                  fileName = ofd.FileName
               End If
            End If
            If (Not String.IsNullOrEmpty(fileName)) Then
               Dim image As RasterImage = MrcSegmenter.LoadImage(fileName, 1)
               NewImage(New ImageInformation(image, fileName))
            End If

         Catch ex As Exception
            Messager.ShowFileOpenError(Me, fileName, ex)
         End Try
      End Sub

      Private Sub _miFileSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileSave.Click
         Dim saver As ImageFileSaver = New ImageFileSaver()

         Try
            saver.Save(Me, _codecs, ActiveViewerForm.Viewer.Image)
         Catch ex As Exception
            Messager.ShowFileSaveError(Me, saver.FileName, ex)
         End Try
      End Sub

      Private Sub _miFileTwainSelectSource_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileTwainSelectSource.Click
         _inTwainAcquire = True
         Try
            If Not _twainSession Is Nothing Then
               _twainSession.SelectSource(String.Empty)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
         _inTwainAcquire = False
      End Sub

      Private Sub _miFileTwainAcquire_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileTwainAcquire.Click
         _inTwainAcquire = True
         _acquirePageCount = 1

         Try
            If Not _twainSession Is Nothing Then
               If (Not DemosGlobal.CheckKnown3rdPartyTwainIssues(Me, _twainSession.SelectedSourceName())) Then
                  Return
               End If
               Dim res As DialogResult = _twainSession.Acquire(TwainUserInterfaceFlags.Modal Or TwainUserInterfaceFlags.Show)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            _acquirePageCount = -1
            _inTwainAcquire = False
         End Try
      End Sub

      Private Sub _twainSession_AcquirePage(ByVal sender As Object, ByVal e As TwainAcquirePageEventArgs)
         Application.DoEvents()

         If Not e.Image Is Nothing Then
            If _acquirePageCount = 1 Then
               NewImage(New ImageInformation(e.Image, "Twain Image"))
            Else
               ActiveViewerForm.Image.AddPage(e.Image)
            End If

            _acquirePageCount += 1
         End If
      End Sub

      Private Sub _miFileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileExit.Click
         Close()
      End Sub

      Private Sub MainForm_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.MdiChildActivate
         UpdateControls()
      End Sub

      Private Sub _miEdit_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miEdit.Popup
         Dim activeViewer As ViewerForm = ActiveViewerForm

         If activeViewer Is Nothing Then
            Return
         End If



         _miEditPaste.Enabled = RasterClipboard.IsReady

         _miEditSelectAllSegments.Enabled = activeViewer.MrcStarted

         If activeViewer.SelectedSegment = -1 Then
            _miEditSelectAllSegments.Enabled = False
         Else
           _miEditSelectAllSegments.Enabled = _miEditDeleteSelectedSegment.Enabled = True
         End If

         _miEditDeselectAll.Enabled = ((Not _miEditSelectAllSegments.Enabled)) OrElse (activeViewer.SelectedSegment >= 0)

         _miEditUndo.Enabled = activeViewer.EnableUndo
      End Sub

      Private Sub _miEditCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miEditCopy.Click
         Try
            Using wait As WaitCursor = New WaitCursor()
               RasterClipboard.Copy(Me.Handle, ImageToRun, RasterClipboardCopyFlags.Empty Or RasterClipboardCopyFlags.Dib Or RasterClipboardCopyFlags.Palette Or RasterClipboardCopyFlags.Region)
            End Using
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateControls()
         End Try
      End Sub

      Private Sub _miEditPaste_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miEditPaste.Click
         Try
            Using wait As WaitCursor = New WaitCursor()
               Dim image As RasterImage = RasterClipboard.Paste(Me.Handle)
               If Not image Is Nothing Then
                  Dim activeForm As ViewerForm = ActiveViewerForm

                  If image.HasRegion AndAlso activeForm Is Nothing Then
                     image.MakeRegionEmpty()
                  End If

                  If image.HasRegion Then
                     ' make sure the images have the same BitsPerPixel and Palette
                     If activeForm.Viewer.Image.BitsPerPixel > 8 Then
                        If image.BitsPerPixel <> activeForm.Viewer.Image.BitsPerPixel Then
                           Try
                              Dim colorRes As ColorResolutionCommand = New ColorResolutionCommand()
                              colorRes.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel
                              colorRes.Order = activeForm.Viewer.Image.Order
                              colorRes.Mode = ColorResolutionCommandMode.InPlace
                              colorRes.Run(image)
                           Catch ex As Exception
                              Messager.ShowError(Me, ex)
                           End Try
                        End If
                     Else
                        Try
                           Dim colorRes As ColorResolutionCommand = New ColorResolutionCommand()
                           colorRes.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel
                           colorRes.SetPalette(activeForm.Viewer.Image.GetPalette())
                           colorRes.PaletteFlags = ColorResolutionCommandPaletteFlags.UsePalette
                           colorRes.Mode = ColorResolutionCommandMode.InPlace
                           colorRes.Run(image)
                        Catch ex As Exception
                           Messager.ShowError(Me, ex)
                        End Try
                     End If
                  Else
                     NewImage(New ImageInformation(image))
                  End If
               End If
            End Using
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateControls()
         End Try
      End Sub

      Private Sub _miHelpAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miHelpAbout.Click
         Using aboutDialog As New AboutDialog("Mrc Segmentation", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _miWindow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miWindowCascade.Click, _miWindowTileHorizontally.Click, _miWindowTileVertically.Click, _miWindowArrangeIcons.Click, _miWindowCloseAll.Click
         checkedWindowMenu.Checked = False

         If sender Is _miWindowCascade Then
            LayoutMdi(MdiLayout.Cascade)
            checkedWindowMenu = _miWindowCascade
         ElseIf sender Is _miWindowTileHorizontally Then
            LayoutMdi(MdiLayout.TileHorizontal)
            checkedWindowMenu = _miWindowTileHorizontally
         ElseIf sender Is _miWindowTileVertically Then
            LayoutMdi(MdiLayout.TileVertical)
            checkedWindowMenu = _miWindowTileVertically
         ElseIf sender Is _miWindowArrangeIcons Then
            LayoutMdi(MdiLayout.ArrangeIcons)
            checkedWindowMenu = _miWindowArrangeIcons
         ElseIf sender Is _miWindowCloseAll Then
            Do While MdiChildren.Length > 0
               MdiChildren(0).Close()
            Loop
            UpdateControls()
            checkedWindowMenu = _miWindowCascade
         End If
         checkedWindowMenu.Checked = True
      End Sub


      Private Function LoadImage() As ImageInformation
         Dim loader As ImageFileLoader = New ImageFileLoader()

         loader.OpenDialogInitialPath = _openInitialPath

         Try
            If loader.Load(Me, _codecs, False) > 0 Then


               Using wait As WaitCursor = New WaitCursor()
                  Dim loadedImage As RasterImage = _codecs.Load(loader.FileName, 0, CodecsLoadByteOrder.BgrOrGray, loader.FirstPage, loader.LastPage)
                  _openInitialPath = Path.GetDirectoryName(loader.FileName)
                  If loadedImage.HasRegion Then
                     loadedImage.MakeRegionEmpty()
                  End If
                  Return New ImageInformation(loadedImage, loader.FileName)
               End Using
            End If
         Catch ex As Exception
            Messager.ShowFileOpenError(Me, loader.FileName, ex)
         End Try

         Return Nothing
      End Function

      Private Sub NewImage(ByVal info As ImageInformation)
         Dim child As ViewerForm = New ViewerForm()
         child.MdiParent = Me
         child.Initialize(info, _paintProperties, True)
         child.Show()
      End Sub

      Private Property ImageToRun() As RasterImage
         Get
            Dim activeForm As ViewerForm = ActiveViewerForm

            Return activeForm.Viewer.Image
         End Get
         Set(value As RasterImage)
            If Not Value Is Nothing Then
               Dim activeForm As ViewerForm = ActiveViewerForm

               activeForm.Viewer.Image = Value
            End If
         End Set
      End Property

      Private Sub MainForm_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
         If Tools.CanDrop(e.Data) Then
            e.Effect = DragDropEffects.Copy
         End If
      End Sub

      Private Sub MainForm_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop
         If Tools.CanDrop(e.Data) Then
            Dim files As String() = Tools.GetDropFiles(e.Data)
            If Not files Is Nothing Then
               LoadDropFiles(Nothing, files)
            End If
         End If
      End Sub

      Public Sub LoadDropFiles(ByVal viewer As ViewerForm, ByVal files As String())
         Try
            If Not files Is Nothing Then
               Dim nI As Integer = 0
               Do While nI < files.Length
                  Try
                     Dim image As RasterImage = _codecs.Load(files(nI))
                     Dim info As ImageInformation = New ImageInformation(image, files(nI))
                     If nI = 0 AndAlso Not viewer Is Nothing Then
                        viewer.Initialize(info, _paintProperties, False)
                     Else
                        NewImage(info)
                     End If
                  Catch ex As Exception
                     Messager.ShowFileOpenError(Me, files(nI), ex)
                  End Try
                  nI += 1
               Loop
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateControls()
         End Try
      End Sub

      Private Sub MainForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

         If _inTwainAcquire Then
            e.Cancel = True
         End If
      End Sub

      Private Sub _miColorResolution_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miColorResolution.Click
         Dim activeForm As ViewerForm = ActiveViewerForm
         Dim command As ColorResolutionCommand
         Dim colorResolutionDlg As ColorResolutionDialog = New ColorResolutionDialog()

         colorResolutionDlg.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel
         colorResolutionDlg.Order = activeForm.Viewer.Image.Order

         If colorResolutionDlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            command = New ColorResolutionCommand(ColorResolutionCommandMode.InPlace, colorResolutionDlg.BitsPerPixel, colorResolutionDlg.Order, colorResolutionDlg.DitheringMethod, colorResolutionDlg.PaletteFlags, Nothing)

            command.Run(activeForm.Image)
         End If
      End Sub

      Private Sub _miColorHistogram_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miColorHistogram.Click
         Dim activeViewer As ViewerForm = ActiveViewerForm

         activeViewer.ShowHistogram()
      End Sub

      Private Sub _miColorUniqueColors_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miColorUniqueColors.Click
         Dim activeViewer As ViewerForm = ActiveViewerForm

         activeViewer.GetUniqueColorsCount()
      End Sub

      Public Sub _miView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miViewFitToWindow.Click, _miViewNormal.Click, _miViewZoomIn.Click, _miViewZoomOut.Click
         ' get the current center in logical units
         Dim viewer As ImageViewer = ActiveViewerForm.Viewer ' get the active viewer
         Dim rc As Rectangle = Rectangle.Intersect(viewer.ClientRectangle, viewer.ClientRectangle) ' get what you see in physical coordinates
         Dim center As PointF = New PointF(CSng(rc.Left + rc.Width / 2), CSng(rc.Top + rc.Height / 2)) ' get the center of what you see in physical coordinates
         Dim t As Transformer = New Transformer(Tools.ToMatrix(viewer.ImageTransform))
         center = t.PointToLogical(center) ' get the center of what you see in logical coordinates

         ' zoom     
         Dim scaleFactor As Double = viewer.ScaleFactor

         Const ratio As Single = 1.2F

         checkedViewMenu.Checked = False

         If sender Is _miViewZoomIn Then
            scaleFactor *= ratio
            checkedViewMenu = _miViewZoomIn
         ElseIf sender Is _miViewZoomOut Then
            scaleFactor /= ratio
            checkedViewMenu = _miViewZoomOut
         ElseIf sender Is _miViewNormal Then
            scaleFactor = 1
            If viewer.SizeMode <> ControlSizeMode.ActualSize Then
               viewer.Zoom(ControlSizeMode.ActualSize, scaleFactor, viewer.DefaultZoomOrigin)
            End If
            checkedViewMenu = _miViewNormal
         ElseIf sender Is _miViewFitToWindow Then
            viewer.BeginUpdate()
            viewer.Zoom(ControlSizeMode.Fit, scaleFactor, viewer.DefaultZoomOrigin)
            checkedViewMenu = _miViewFitToWindow
            scaleFactor = 1
            viewer.EndUpdate()
         End If

         scaleFactor = Math.Max(_minimumScaleFactor, Math.Min(_maximumScaleFactor, scaleFactor))

         If viewer.ScaleFactor <> scaleFactor Then
            viewer.Zoom(ControlSizeMode.None, scaleFactor, viewer.DefaultZoomOrigin)
            ' bring the original center into the view center
            t = New Transformer(Tools.ToMatrix(viewer.ImageTransform))
            center = t.PointToPhysical(center) ' get the center of what you saw before the zoom in physical coordinates
            Dim lPoint As LeadPoint = New LeadPoint(Point.Round(center).X, Point.Round(center).Y)
            viewer.CenterAtPoint(lPoint) ' bring the old center into the center of the view
         End If
         checkedViewMenu.Checked = True
      End Sub

      Private Sub _miSegStartClearManual_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miSegStartClearManual.Click
         CancelDrawing()
         Dim activeViewer As ViewerForm = ActiveViewerForm
         activeViewer.AddSegment = False
         activeViewer.AddToUndoList()



         Using wait As WaitCursor = New WaitCursor()
            activeViewer.StartAutoMrcSegmentation(False)
         End Using

         _miSegClearSegments.Enabled = True
         _miSegStartPreserveManual.Enabled = True
         _miSegDrawSegment.Enabled = True
         _miSegDrawCancelDrawing.Enabled = False
      End Sub

      Private Sub _miDeleteSelectedSegment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miEditDeleteSelectedSegment.Click
         Dim activeViewer As ViewerForm = ActiveViewerForm
         activeViewer.AddToUndoList()
         If activeViewer.AddSegment Then
            activeViewer.Viewer.Cursor = Cursors.Cross
         Else
            activeViewer.Viewer.Cursor = Cursors.Default
         End If

         Using wait As WaitCursor = New WaitCursor()
            activeViewer.DeleteSelectedSegment()
         End Using
      End Sub

      Private Sub _miSegClearSegments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miSegClearSegments.Click
         CancelDrawing()
         Dim activeViewer As ViewerForm = ActiveViewerForm
         activeViewer.AddToUndoList()

         Using wait As WaitCursor = New WaitCursor()
            activeViewer.ClearSegments()
         End Using

         _miSegDrawSegment.Enabled = True
         _miSegStartPreserveManual.Enabled = False
         _miSegClearSegments.Enabled = False
         _miSegDrawCancelDrawing.Enabled = False
         _miEditSelectAllSegments.Enabled = False
         _miEditDeleteSelectedSegment.Enabled = False
      End Sub

      Private Sub _miSegDrawSegment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miSegDrawSegment.Click
         Dim activeViewer As ViewerForm = ActiveViewerForm

         activeViewer.AddSegment = True

         _miSegDrawSegment.Enabled = False
         _miSegDrawCancelDrawing.Enabled = True
         activeViewer.Cursor = Cursors.Cross
      End Sub

      Private Sub _miSegDrawCancelDrawing_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miSegDrawCancelDrawing.Click
         Dim activeViewer As ViewerForm = ActiveViewerForm

         activeViewer.AddSegment = False

         _miSegDrawSegment.Enabled = True
         _miSegDrawCancelDrawing.Enabled = False
      End Sub

      Private Sub _miSegStartPreserveManual_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miSegStartPreserveManual.Click
         CancelDrawing()
         Dim activeViewer As ViewerForm = ActiveViewerForm
         activeViewer.AddToUndoList()

         Using wait As WaitCursor = New WaitCursor()
            activeViewer.StartAutoMrcSegmentation(True)
         End Using
         _miSegClearSegments.Enabled = True
      End Sub

      Private Sub _miPrefShowSegType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miPrefShowSegType.Click
         Dim activeViewer As ViewerForm = ActiveViewerForm

         _miPrefShowSegType.Checked = Not _miPrefShowSegType.Checked

         activeViewer.Viewer.Invalidate(True)
      End Sub

      Private Sub _miEditSelectAllSegments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miEditSelectAllSegments.Click
         Dim activeViewer As ViewerForm = ActiveViewerForm
         activeViewer.SelectAllSegments()
         _miEditSelectAllSegments.Enabled = False
         activeViewer.SetSelectionArray(True)
         UpdateControls()
         activeViewer.Viewer.Invalidate(True)
      End Sub

      Private Sub _miFileSaveLeadMrc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileSaveLeadMrc.Click
         Dim activeViewer As ViewerForm = ActiveViewerForm

         Dim saveDlgFormatList As RasterSaveDialogFileFormatsList = New RasterSaveDialogFileFormatsList(RasterDialogFileFormatDataContent.User)

         ' Adding Mrc format
         saveDlgFormatList.Add(RasterDialogFileTypesIndex.Mrc, RasterDialogBitsPerPixelDataContent.User)
         saveDlgFormatList(0).BitsPerPixelList.Add(RasterDialogFileTypesIndex.Mrc, 24, RasterDialogFileSubTypeDataContent.User)
         saveDlgFormatList(0).BitsPerPixelList(0).SubFormatsList.Add(RasterDialogFileTypesIndex.Mrc, 24, CInt(RasterDialogMrcSubTypesIndex.LeadMrc))

         ' Adding Tiff format
         saveDlgFormatList.Add(RasterDialogFileTypesIndex.Tiff, RasterDialogBitsPerPixelDataContent.User)
         saveDlgFormatList(1).BitsPerPixelList.Add(RasterDialogFileTypesIndex.Tiff, 24, RasterDialogFileSubTypeDataContent.User)
         saveDlgFormatList(1).BitsPerPixelList(0).SubFormatsList.Add(RasterDialogFileTypesIndex.Tiff, 24, CInt(RasterDialogTiff24SubTypesIndex.LeadMrc))

         Dim saver As ImageFileSaver = New ImageFileSaver()

         saver.SaveFormats = saveDlgFormatList
         saver.AutoSave = False

         Try
            If saver.Save(Me, _codecs, activeViewer.Image) Then
               Using wait As WaitCursor = New WaitCursor()
                  activeViewer.SaveLeadMrc(saver.FileName, _codecs, saver.Format)
               End Using
            End If
         Catch ex As Exception
            Messager.ShowFileSaveError(Me, saver.FileName, ex)
         End Try
      End Sub

      Public Sub CancelDrawing()
         Dim activeViewer As ViewerForm = ActiveViewerForm

         activeViewer.AddSegment = False
         activeViewer.DrawNewSegment = False
         _miSegDrawSegment.Enabled = True
         _miSegDrawCancelDrawing.Enabled = False

         activeViewer.Cursor = Cursors.Default
         activeViewer.Invalidate(True)
      End Sub

      Private Sub _menusPopUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFile.Popup, _miView.Popup, _miColor.Popup, _miPreference.Popup
         Dim activeViewer As ViewerForm = ActiveViewerForm

         If Not activeViewer Is Nothing Then


            If sender Is _miFile Then
               _miFileExportSegment.Enabled = activeViewer.MrcStarted
            End If
         End If
      End Sub

      Private Sub _miPrefSegAndComOptions_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miPrefSegAndComOptions.Click
         Dim activeViewer As ViewerForm = ActiveViewerForm
         Dim optionsDialog As Options = New Options()

         activeViewer.SetValuesToDialog(optionsDialog)
         optionsDialog.SetSelections()

         If optionsDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Using wait As WaitCursor = New WaitCursor()
               activeViewer.SetValuesToVariables(optionsDialog)
               activeViewer.OptionsChanged = True
            End Using
         End If
      End Sub

      Private Sub _miFileSaveMrc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileSaveMrc.Click
         Dim activeViewer As ViewerForm = ActiveViewerForm

         Dim saveDlgFormatList As RasterSaveDialogFileFormatsList = New RasterSaveDialogFileFormatsList(RasterDialogFileFormatDataContent.User)

         ' Adding Mrc format
         saveDlgFormatList.Add(RasterDialogFileTypesIndex.Mrc, RasterDialogBitsPerPixelDataContent.User)
         saveDlgFormatList(0).BitsPerPixelList.Add(RasterDialogFileTypesIndex.Mrc, 24, RasterDialogFileSubTypeDataContent.User)
         saveDlgFormatList(0).BitsPerPixelList(0).SubFormatsList.Add(RasterDialogFileTypesIndex.Mrc, 24, CInt(RasterDialogMrcSubTypesIndex.Mrc))

         ' Adding Tiff format
         saveDlgFormatList.Add(RasterDialogFileTypesIndex.Tiff, RasterDialogBitsPerPixelDataContent.User)
         saveDlgFormatList(1).BitsPerPixelList.Add(RasterDialogFileTypesIndex.Tiff, 24, RasterDialogFileSubTypeDataContent.User)
         saveDlgFormatList(1).BitsPerPixelList(0).SubFormatsList.Add(RasterDialogFileTypesIndex.Tiff, 24, CInt(RasterDialogTiff24SubTypesIndex.Mrc))

         Dim saver As ImageFileSaver = New ImageFileSaver()

         saver.SaveFormats = saveDlgFormatList
         saver.AutoSave = False

         Try
            If saver.Save(Me, _codecs, activeViewer.Image) Then
               Using wait As WaitCursor = New WaitCursor()
                  activeViewer.SaveMrc(saver.FileName, _codecs, saver.Format)
               End Using
            End If
         Catch ex As Exception
            Messager.ShowFileSaveError(Me, saver.FileName, ex)
         End Try
      End Sub

      Private Sub _miFileSavePDF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileSavePDF.Click
         Dim activeViewer As ViewerForm = ActiveViewerForm

         Dim saveDlgFormatList As RasterSaveDialogFileFormatsList = New RasterSaveDialogFileFormatsList(RasterDialogFileFormatDataContent.User)

         ' Adding Pdf format
         saveDlgFormatList.Add(RasterDialogFileTypesIndex.Pdf, RasterDialogBitsPerPixelDataContent.User)
         saveDlgFormatList(0).BitsPerPixelList.Add(RasterDialogFileTypesIndex.Pdf, 24, RasterDialogFileSubTypeDataContent.User)
         saveDlgFormatList(0).BitsPerPixelList(0).SubFormatsList.Add(RasterDialogFileTypesIndex.Pdf, 24, CInt(RasterDialogPdf24SubTypesIndex.Uncompressed))

         Dim saver As ImageFileSaver = New ImageFileSaver()

         saver.SaveFormats = saveDlgFormatList

         Try
            If saver.Save(Me, _codecs, activeViewer.Image) Then
               Using wait As WaitCursor = New WaitCursor()
                  activeViewer.SavePDF(saver.FileName, _codecs)
               End Using
            End If
         Catch ex As Exception
            Messager.ShowFileSaveError(Me, saver.FileName, ex)
         End Try
      End Sub

      Private Sub _miFileExportSegment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileExportSegment.Click
         Dim activeViewer As ViewerForm = ActiveViewerForm
         Dim dlg As SaveFileDialog = New SaveFileDialog()

         dlg.Filter = "Segments files|*.sgm"
         dlg.Title = "Export Segments"

         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Using wait As WaitCursor = New WaitCursor()
               activeViewer.SaveSegments(dlg.FileName)
            End Using
         End If
      End Sub

      Private Sub _miFileImportSegment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileImportSegment.Click
         Dim activeViewer As ViewerForm = ActiveViewerForm
         Dim dlg As OpenFileDialog = New OpenFileDialog()

         dlg.Filter = "Segments files|*.sgm"
         dlg.Title = "Import Segments Files"

         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Using wait As WaitCursor = New WaitCursor()
               activeViewer.LoadSegments(dlg.FileName)
               UpdateControls()
            End Using
         End If
      End Sub

      Private Sub _miViewEnlargeSegment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miViewEnlargeSegment.Click
         Dim activeViewer As ViewerForm = ActiveViewerForm
         activeViewer.AddToUndoList()

         activeViewer.EnlargeSegment()
      End Sub

      Public Sub _miViewShowInNewWindow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miViewShowInNewWindow.Click
         Dim activeViewer As ViewerForm = ActiveViewerForm

         NewImage(New ImageInformation(activeViewer.GetRectangleAsImage()))
      End Sub

      Private Sub _miViewShowType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miViewShowType.Click
         Dim activeViewer As ViewerForm = ActiveViewerForm

         activeViewer.ShowSegmentType()
      End Sub

      Private Sub _miViewShowHistogram_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miViewShowHistogram.Click
         Dim activeViewer As ViewerForm = ActiveViewerForm

         activeViewer.ShowSegmentHistogram()
      End Sub

      Private Sub _miViewUniqueColors_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miViewUniqueColors.Click
         Dim activeViewer As ViewerForm = ActiveViewerForm

         activeViewer.GetSegmentUniqueColorsCount()
      End Sub

      Private Sub _miViewCombineSegments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miViewCombineSegments.Click
         Dim activeViewer As ViewerForm = ActiveViewerForm
         activeViewer.AddToUndoList()

         activeViewer.CombineSegments()
      End Sub

      Private Sub _miViewSelectedSegment_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miViewSelectedSegment.Popup
         Dim activeViewer As ViewerForm = ActiveViewerForm

         If activeViewer.SelectedSegment = -1 Then
            _miViewEnlargeSegment.Enabled = _miViewShowInNewWindow.Enabled = _miViewShowType.Enabled = _miViewShowProperties.Enabled = _miViewShowHistogram.Enabled = _miViewUniqueColors.Enabled = False
         Else
            _miViewEnlargeSegment.Enabled = _miViewShowInNewWindow.Enabled = _miViewShowType.Enabled = _miViewShowProperties.Enabled = _miViewShowHistogram.Enabled = _miViewUniqueColors.Enabled = True
         End If

         If activeViewer.SelectedCombineSegment = -1 Then
            _miViewCombineSegments.Enabled = False
         Else
            _miViewCombineSegments.Enabled = True
         End If
      End Sub

      Private Sub _miEditUndo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miEditUndo.Click
         Dim activeViewer As ViewerForm = ActiveViewerForm

         activeViewer.Undo()

         activeViewer.Viewer.Invalidate(True)
      End Sub

      Private Sub _miViewShowProperties_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miViewShowProperties.Click
         Dim activeViewer As ViewerForm = ActiveViewerForm

         activeViewer.ShowSegmentInformation()
      End Sub

      Public Function GetPictureCompression(ByVal index As Integer) As MrcPictureCompression
         Select Case index
            Case 0
               Return MrcPictureCompression.Cmw
            Case 1
               Return MrcPictureCompression.LosslessCmw
            Case 2
               Return MrcPictureCompression.Cmp
            Case 3
               Return MrcPictureCompression.Jpeg
            Case 4
               Return MrcPictureCompression.LosslessJpeg
            Case 5
               Return MrcPictureCompression.JpegYUV422
            Case 6
               Return MrcPictureCompression.JpegYUV411
            Case 7
               Return MrcPictureCompression.JpegProgressive
            Case 8
               Return MrcPictureCompression.JpegProgressiveYUV422
            Case Else
               Return MrcPictureCompression.JpegProgressiveYUV411
         End Select
      End Function

      Public Function GetGrayscaleCompression8BitCoder(ByVal index As Integer) As MrcGrayscaleCompression8BitCoder
         Select Case index
            Case 0
               Return MrcGrayscaleCompression8BitCoder.LosslessCmw
            Case 1
               Return MrcGrayscaleCompression8BitCoder.GrayscaleCmw
            Case 2
               Return MrcGrayscaleCompression8BitCoder.GrayscaleCmp
            Case 3
               Return MrcGrayscaleCompression8BitCoder.LosslessJpeg
            Case 4
               Return MrcGrayscaleCompression8BitCoder.GrayscaleJpeg
            Case Else
               Return MrcGrayscaleCompression8BitCoder.GrayscaleJpegProgressive
         End Select
      End Function

      Public Function GetTextCompressionCoder(ByVal index As Integer) As MrcTextCompression2BitCoder
         Select Case index
            Case 0
               Return MrcTextCompression2BitCoder.Jbig2Bit
            Case Else
               Return MrcTextCompression2BitCoder.Gif2Bit
         End Select
      End Function

      Public Function GetGrayscaleCompression2BitCoder(ByVal index As Integer) As MrcGrayscaleCompression2BitCoder
         Select Case index
            Case Else
               Return MrcGrayscaleCompression2BitCoder.Jbig2
         End Select
      End Function

      Public Function GetMaskCompression(ByVal index As Integer) As MrcMaskCompression
         Select Case index
            Case 0
               Return MrcMaskCompression.Jbig
            Case 1
               Return MrcMaskCompression.FaxG4
            Case 2
               Return MrcMaskCompression.FaxG31D
            Case Else
               Return MrcMaskCompression.FaxG32D
         End Select
      End Function

      Public Function GetPDF1Compression(ByVal index As Integer) As MrcMaskCompression
         Select Case index
            Case 0
               Return MrcMaskCompression.PdfZip
            Case 1
               Return MrcMaskCompression.PdfLzw
            Case 2
               Return MrcMaskCompression.PdfG31D
            Case 3
               Return MrcMaskCompression.PdfG32D
            Case 4
               Return MrcMaskCompression.PdfG4
            Case Else
               Return MrcMaskCompression.PdfJbig
         End Select
      End Function

      Public Function GetPDF2Compression(ByVal index As Integer) As MrcTextCompression2BitCoder
         Select Case index
            Case 0
               Return MrcTextCompression2BitCoder.PdfZip
            Case Else
               Return MrcTextCompression2BitCoder.PdfLzw
         End Select
      End Function

      Public Function GetPDFPictureCompression(ByVal index As Integer) As MrcPictureCompression
         Select Case index
            Case 0
               Return MrcPictureCompression.PdfJpeg
            Case 1
               Return MrcPictureCompression.PdfJpegYUV422
            Case 2
               Return MrcPictureCompression.PdfJpegYUV411
            Case 3
               Return MrcPictureCompression.PdfJpegProgressive
            Case 4
               Return MrcPictureCompression.PdfJpegProgressiveYUV422
            Case 5
               Return MrcPictureCompression.PdfJpegProgressiveYUV411
            Case 6
               Return MrcPictureCompression.PdfZip
            Case Else
               Return MrcPictureCompression.PdfLzw
         End Select
      End Function

      Private Sub _miFileSaveMultiPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileSaveMultiPage.Click
         Try
            Dim activeViewer As ViewerForm = ActiveViewerForm
            Dim dlgMultiPage As SaveMultiPageDialog = New SaveMultiPageDialog(Me)

            If dlgMultiPage.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
               Dim dlgSave As SaveFileDialog = New SaveFileDialog()

               Select Case dlgMultiPage.SaveType
                  Case 0, 1
                     dlgSave.Filter = "Tiff|*.tif;*.tiff"
                  Case 2
                     dlgSave.Filter = "PDF|*.pdf"
               End Select
               dlgSave.Title = "Save Multi-Page"

               If dlgSave.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                  Dim imageListFormat As MrcImageListFormat
                  Dim compressionOptions As MrcCompressionOptions = New MrcCompressionOptions()
                  Dim segmenterList As List(Of MrcSegmenter) = New List(Of MrcSegmenter)()

                  Select Case dlgMultiPage.SaveType
                     Case 0
                        compressionOptions.PictureCoder = MrcPictureCompression.Jpeg
                        compressionOptions.PictureQualityFactor = _qFactor

                        Select Case GetPictureCompression(_pictureCoder)
                           Case MrcPictureCompression.LosslessJpeg, MrcPictureCompression.LosslessCmw
                              compressionOptions.PictureQualityFactor = 0
                        End Select
                        compressionOptions.MaskCoder = GetMaskCompression(_maskCoder)
                        imageListFormat = MrcImageListFormat.MrcT44Tif
                     Case 1
                        compressionOptions.PictureCoder = GetPictureCompression(_pictureCoder)
                        compressionOptions.Text2BitCoder = GetTextCompressionCoder(_textCoder2Bit)
                        compressionOptions.MaskCoder = GetMaskCompression(_maskCoder)
                        compressionOptions.PictureQualityFactor = _qFactor

                        Select Case compressionOptions.PictureCoder
                           Case MrcPictureCompression.LosslessJpeg, MrcPictureCompression.LosslessCmw
                              compressionOptions.PictureQualityFactor = 0
                        End Select
                        compressionOptions.Grayscale2BitCoder = GetGrayscaleCompression2BitCoder(_grayscaleCoder2Bit)
                        compressionOptions.Grayscale8BitCoder = GetGrayscaleCompression8BitCoder(_grayscaleCoder8Bit)
                        compressionOptions.Grayscale8BitFactor = _gSQFactor
                        Select Case compressionOptions.Grayscale8BitCoder
                           Case MrcGrayscaleCompression8BitCoder.LosslessCmw, MrcGrayscaleCompression8BitCoder.LosslessJpeg
                              compressionOptions.Grayscale8BitFactor = 0
                        End Select
                        imageListFormat = MrcImageListFormat.MrcTif
                     Case Else
                        compressionOptions.PictureCoder = GetPDFPictureCompression(_pDFPictureCoder)
                        compressionOptions.Text2BitCoder = GetPDF2Compression(_pDFTextCoder2Bit)
                        compressionOptions.MaskCoder = GetPDF1Compression(_pDFMaskCoder)
                        compressionOptions.PictureQualityFactor = _pDFQFactor

                        Select Case compressionOptions.PictureCoder
                           Case MrcPictureCompression.LosslessJpeg, MrcPictureCompression.LosslessCmw
                              compressionOptions.PictureQualityFactor = 0
                        End Select
                        imageListFormat = MrcImageListFormat.MrcPdf
                  End Select

                  MrcSegmenter.SaveBitmapList(dlgMultiPage.SegmenterCollection, dlgMultiPage.ImageCollection, dlgSave.FileName, imageListFormat, compressionOptions)
               End If
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub _miSegmentation_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miSegmentation.Popup
         Dim activeViewer As ViewerForm = ActiveViewerForm
         _miSegClearSegments.Enabled = activeViewer.MrcStarted
         _miSegStartPreserveManual.Enabled = activeViewer.MrcStarted
      End Sub

      Private Sub _miEditDeselectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miEditDeselectAll.Click
         Dim activeViewer As ViewerForm = ActiveViewerForm
         activeViewer.SelectedSegment = -2
         activeViewer.Viewer.Cursor = Cursors.Default
         UpdateControls()
         activeViewer.Invalidate(True)
      End Sub

      Private Sub MainForm_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
         Dim activeViewer As ViewerForm = ActiveViewerForm
         If Not activeViewer Is Nothing Then
            If activeViewer.AddSegment AndAlso activeViewer.DrawNewSegment Then
               CancelDrawing()
            End If
         End If
      End Sub

      Private Sub menuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuItem2.Click
         If menuItem2.Checked = False Then
            menuItem2.Checked = True
            menuItem3.Checked = False
            _segmentationMethod = False
         End If

      End Sub

      Private Sub menuItem3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuItem3.Click
         If menuItem3.Checked = False Then
            menuItem3.Checked = True
            menuItem2.Checked = False
            _segmentationMethod = True
         End If
      End Sub
   End Class
End Namespace
