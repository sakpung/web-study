' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Drawing
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.Text
Imports System.IO
Imports System.Reflection
Imports System

Imports Leadtools
Imports Leadtools.Codecs

Imports Leadtools.Drawing
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.Automation
Imports Leadtools.Annotations.Designers
Imports Leadtools.Annotations.Rendering
Imports System.Diagnostics
Imports Leadtools.Annotations.WinForms
Imports Leadtools.Controls
Imports Leadtools.Annotations.BatesStamp

#If LEADTOOLS_V19_OR_LATER Then
Imports Leadtools.Demos.Dialogs
#End If

''' <summary>
''' Summary description for MainForm.
''' </summary>
'''
Enum AudioState
   Playing
   Stopped
   Failed
   Finished
End Enum
Public Class MainForm
   Inherits Form
   Private ReadOnly _randomNumber As New Random()
   Private _managerHelper As AutomationManagerHelper = Nothing
   Private ReadOnly _loadedPackages As New List(Of String)()
   Private _showLoadPackageInfoDialog As Boolean = True
   Private _showLoadBatesStampInfoDialog As Boolean = True

   Public ReadOnly Property ManagerHelper() As AutomationManagerHelper
      Get
         Return _managerHelper
      End Get
   End Property

   Private _mainMenu As MainMenu
   Private _menuItemFile As MenuItem
   Private WithEvents _menuItemFileOpen As MenuItem
   Private _menuItemFileSep1 As MenuItem
   Private WithEvents _menuItemFileExit As MenuItem
   Private WithEvents _menuItemFilePrint As MenuItem
   Private WithEvents _menuItemFilePrintPreview As MenuItem
   Private _menuItemFileSep2 As MenuItem
   Private _menuItemFileSep3 As MenuItem
   Private _menuItemHelp As MenuItem
   Private WithEvents _menuItemHelpAbout As MenuItem
   Private WithEvents _menuItemEdit As MenuItem
   Private WithEvents _menuItemEditCut As MenuItem
   Private WithEvents _menuItemEditCopy As MenuItem
   Private WithEvents _menuItemEditPaste As MenuItem
   Private WithEvents _menuItemEditDelete As MenuItem
   Private WithEvents _menuItemEditSelectAll As MenuItem
   Private WithEvents _menuItemEditSelectNone As MenuItem
   Private _menuItemWindow As MenuItem
   Private WithEvents _menuItemWindowCascade As MenuItem
   Private WithEvents _menuItemWindowTileHorizontally As MenuItem
   Private WithEvents _menuItemWindowTileVertically As MenuItem
   Private WithEvents _menuItemWindowArrangeIcons As MenuItem
   Private WithEvents _menuItemWindowCloseAll As MenuItem
   Private _menuItemView As MenuItem
   Private _menuItemViewSizeMode As MenuItem
   Private WithEvents _menuItemViewSizeModeNormal As MenuItem
   Private WithEvents _menuItemViewSizeModeStretch As MenuItem
   Private WithEvents _menuItemViewSizeModeFitAlways As MenuItem
   Private WithEvents _menuItemViewSizeModeFitWidth As MenuItem
   Private _menuItemViewZoom As MenuItem
   Private WithEvents _menuItemViewZoomIn As MenuItem
   Private WithEvents _menuItemViewZoomOut As MenuItem
   Private _menuItemViewZoomSep1 As MenuItem
   Private WithEvents _menuItemViewZoomNormal As MenuItem
   Private WithEvents _menuItemViewPaintProperties As MenuItem
   Private _menuItemViewSep1 As MenuItem
   Private _menuItemAnnotations As MenuItem
   Private _menuItemAnnotationsUserMode As MenuItem
   Private _menuItemAnnotationsSep1 As MenuItem
   Private WithEvents _menuItemAnnotationsCurrentObject As MenuItem
   Private _menuItemAnnotationsSep2 As MenuItem
   Private _menuItemAnnotationsAlign As MenuItem
   Private WithEvents _menuItemAnnotationsAlignBringToFront As MenuItem
   Private WithEvents _menuItemAnnotationsAlignSendToBack As MenuItem
   Private WithEvents _menuItemAnnotationsAlignBringToFirst As MenuItem
   Private WithEvents _menuItemAnnotationsAlignSendToLast As MenuItem
   Private _menuItemAnnotationsAlignSep1 As MenuItem
   Private WithEvents _menuItemAnnotationsAlignObjectsAlignmentLefts As MenuItem
   Private WithEvents _menuItemAnnotationsAlignObjectsAlignmentCenters As MenuItem
   Private WithEvents _menuItemAnnotationsAlignObjectsAlignmentRights As MenuItem
   Private _menuItemAnnotationsAlignSep2 As MenuItem
   Private WithEvents _menuItemAnnotationsAlignObjectsAlignmentTops As MenuItem
   Private WithEvents _menuItemAnnotationsAlignObjectsAlignmentMiddles As MenuItem
   Private WithEvents _menuItemAnnotationsAlignObjectsAlignmentBottoms As MenuItem
   Private _menuItemAnnotationsAlignSep3 As MenuItem
   Private WithEvents _menuItemAnnotationsAlignObjectsMakeSameWidth As MenuItem
   Private WithEvents _menuItemAnnotationsAlignObjectsMakeSameHeight As MenuItem
   Private WithEvents _menuItemAnnotationsAlignObjectsMakeSameSize As MenuItem
   Private _menuItemAnnotationsGroup As MenuItem
   Private WithEvents _menuItemAnnotationsGroupGroupSelectedObjects As MenuItem
   Private WithEvents _menuItemAnnotationsGroupUngroup As MenuItem
   Private _menuItemAnnotationsSep3 As MenuItem
   Private WithEvents _menuItemAnnotationsProperties As MenuItem
   Private WithEvents _toolBarMain As ToolBar
   Private _tbbSave As ToolBarButton
   Private _tbbCopy As ToolBarButton
   Private _tbbPaste As ToolBarButton
   Private _tbbDelete As ToolBarButton
   Private _tbbSep1 As ToolBarButton
   Private _tbbRotate As ToolBarButton
   Private _tbbGroup As ToolBarButton
   Private _tbbProperties As ToolBarButton
   Private _tbbBringToFront As ToolBarButton
   Private _tbbSendToBack As ToolBarButton
   Private _tbbBringToFirst As ToolBarButton
   Private _tbbSendToLast As ToolBarButton
   Private _tbbAlignLefts As ToolBarButton
   Private _tbbAlignCenters As ToolBarButton
   Private _tbbAlignRights As ToolBarButton
   Private _tbbAlignTops As ToolBarButton
   Private _tbbAlignMiddles As ToolBarButton
   Private _tbbAlignBottoms As ToolBarButton
   Private _tbbMakeSameWidth As ToolBarButton
   Private _tbbMakeSameHeight As ToolBarButton
   Private _tbbMakeSameSize As ToolBarButton
   Private _tbbSep7 As ToolBarButton
   Private _tbbUngroup As ToolBarButton
   Private _tbbOpen As ToolBarButton
   Private WithEvents _menuItemAnnotationsUserModeRun As MenuItem
   Private WithEvents _menuItemAnnotationsUserModeDesign As MenuItem
   Private _tbbRunDesign As ToolBarButton
   Private WithEvents _menuItemFileSaveAsTiff As MenuItem
   Private WithEvents _menuItemFileSaveAs As MenuItem
   Private WithEvents _menuItemFileSaveAnnotations As MenuItem
   Private _tbbSep2 As ToolBarButton
   Private _tbbZoomIn As ToolBarButton
   Private _tbbZoomOut As ToolBarButton
   Private _tbbNoZoom As ToolBarButton
   Private _menuItemEditSep2 As MenuItem
   Private WithEvents _menuItemEditUndo As MenuItem
   Private WithEvents _menuItemEditRedo As MenuItem
   Private _menuItemEditSep1 As MenuItem
   Private _sbMain As StatusBar
   Private _tbbSep4 As ToolBarButton
   Private _tbbSep5 As ToolBarButton
   Private _tbbSep6 As ToolBarButton
   Private _tbbSep3 As ToolBarButton
   Private _tbbUndo As ToolBarButton
   Private _tbbRedo As ToolBarButton
   Private _menuItemAnnotationsPassword As MenuItem
   Private WithEvents _menuItemAnnotationsPasswordLock As MenuItem
   Private WithEvents _menuItemAnnotationsPasswordUnlock As MenuItem
   Private _menuItemAnnotationsFlip As MenuItem
   Private WithEvents _menuItemAnnotationsFlipHorizontal As MenuItem
   Private WithEvents _menuItemAnnotationsFlipVertical As MenuItem
   Private WithEvents _menuItemAnnotationsAntiAlias As MenuItem
   Private _menuItemAnnotationsEncryptObjects As MenuItem
   Private WithEvents _menuItemAnnotationsEncryptObjectsApplyAllEncryptors As MenuItem
   Private WithEvents _menuItemAnnotationsEncryptObjectsApplyAllDecryptors As MenuItem
   Private WithEvents _menuItemAnnotationsEncryptObjectsApplyEncryptor As MenuItem
   Private WithEvents _menuItemAnnotationsEncryptObjectsApplyDecryptor As MenuItem
   Private _menuItemAnnotationsEncryptObjectsSep1 As MenuItem
   Private WithEvents _menuItemViewZoomValue As MenuItem
   Private _menuItemAnnotationsRedactionObjects As MenuItem
   Private WithEvents _menuItemAnnotationsRedactionObjectsRealize As MenuItem
   Private WithEvents _menuItemAnnotationsRedactionObjectsRestore As MenuItem
   Private _menuItemAnnotationsRedactionObjectsSep1 As MenuItem
   Private WithEvents _menuItemAnnotationsRedactionObjectsRealizeAll As MenuItem
   Private WithEvents _menuItemAnnotationsRedactionObjectsRestoreAll As MenuItem
   Private WithEvents _menuItemAnnotationsRealize As MenuItem
   Private WithEvents _menuItemViewSizeModeFit As MenuItem
   Private _menuItemViewSep2 As MenuItem
   Private _menuItemViewFlip As MenuItem
   Private WithEvents _menuItemViewFlipHorizontal As MenuItem
   Private WithEvents _menuItemViewFlipVertical As MenuItem
   Private _menuItemViewRotate As MenuItem
   Private WithEvents _menuItemViewRotate90 As MenuItem
   Private WithEvents _menuItemViewRotate180 As MenuItem
   Private WithEvents _menuItemViewRotate270 As MenuItem
   Private _menuItemAnnotationsSep4 As MenuItem
   Private _menuItemAnnotationsBehavior As MenuItem
   Private WithEvents _menuItemAnnotationsBehaviorUseRotateThumbs As MenuItem
   Private WithEvents _menuItemAnnotationsBehaviorMaintainAspectRatio As MenuItem
   Private WithEvents _menuItemAnnotationsResetRotatePoints As MenuItem
   Private WithEvents _menuItemAnnotationsBehaviorEnableToolTip As MenuItem
   Private _menuItemViewInteractiveMode As MenuItem
   Private WithEvents _menuItemViewInteractiveModeNone As MenuItem
   Private WithEvents _menuItemViewInteractiveModeMagnifyGlass As MenuItem
   Private WithEvents _menuItemViewInteractiveModePan As MenuItem
   Private WithEvents _menuItemViewUseDpi As MenuItem
   Private WithEvents _menuItemLoadAnnPackage As MenuItem
   Private WithEvents _menuItemFileLoadBateStamp As MenuItem
   Private WithEvents _menuItemAnnotationsBehaviorEnableAutoIncrement As MenuItem
   Private WithEvents _menuItemAnnotationsBehaviorRestrictDesigners As MenuItem
   Private WithEvents _menuItemAnnotationsBehaviorEnableObjectsAlignment As MenuItem
   Private WithEvents _menuItemCalibrate As MenuItem
   Private WithEvents _menuItemEditDuplicate As MenuItem
   Private WithEvents _menuItemViewRotateNone As MenuItem
   Private WithEvents _menuItemAnnotationsSnapToGridProperties As MenuItem
   Private WithEvents _menuItemFileSaveAsWang As MenuItem
   Private components As IContainer

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
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing Then
         CleanUp()

         If components IsNot Nothing Then
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
      Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
      Me._mainMenu = New System.Windows.Forms.MainMenu(Me.components)
      Me._menuItemFile = New System.Windows.Forms.MenuItem()
      Me._menuItemFileOpen = New System.Windows.Forms.MenuItem()
      Me._menuItemFileSaveAnnotations = New System.Windows.Forms.MenuItem()
      Me._menuItemFileSaveAs = New System.Windows.Forms.MenuItem()
      Me._menuItemFileSaveAsTiff = New System.Windows.Forms.MenuItem()
      Me._menuItemFileSaveAsWang = New System.Windows.Forms.MenuItem()
      Me._menuItemFileSep1 = New System.Windows.Forms.MenuItem()
      Me._menuItemFilePrint = New System.Windows.Forms.MenuItem()
      Me._menuItemFilePrintPreview = New System.Windows.Forms.MenuItem()
      Me._menuItemFileSep2 = New System.Windows.Forms.MenuItem()
      Me._menuItemLoadAnnPackage = New System.Windows.Forms.MenuItem()
      Me._menuItemFileLoadBateStamp = New System.Windows.Forms.MenuItem()
      Me._menuItemFileSep3 = New System.Windows.Forms.MenuItem()
      Me._menuItemFileExit = New System.Windows.Forms.MenuItem()
      Me._menuItemEdit = New System.Windows.Forms.MenuItem()
      Me._menuItemEditUndo = New System.Windows.Forms.MenuItem()
      Me._menuItemEditRedo = New System.Windows.Forms.MenuItem()
      Me._menuItemEditSep1 = New System.Windows.Forms.MenuItem()
      Me._menuItemEditCut = New System.Windows.Forms.MenuItem()
      Me._menuItemEditCopy = New System.Windows.Forms.MenuItem()
      Me._menuItemEditPaste = New System.Windows.Forms.MenuItem()
      Me._menuItemEditDelete = New System.Windows.Forms.MenuItem()
      Me._menuItemEditSep2 = New System.Windows.Forms.MenuItem()
      Me._menuItemEditSelectAll = New System.Windows.Forms.MenuItem()
      Me._menuItemEditSelectNone = New System.Windows.Forms.MenuItem()
      Me._menuItemEditDuplicate = New System.Windows.Forms.MenuItem()
      Me._menuItemView = New System.Windows.Forms.MenuItem()
      Me._menuItemViewSizeMode = New System.Windows.Forms.MenuItem()
      Me._menuItemViewSizeModeNormal = New System.Windows.Forms.MenuItem()
      Me._menuItemViewSizeModeStretch = New System.Windows.Forms.MenuItem()
      Me._menuItemViewSizeModeFitAlways = New System.Windows.Forms.MenuItem()
      Me._menuItemViewSizeModeFitWidth = New System.Windows.Forms.MenuItem()
      Me._menuItemViewSizeModeFit = New System.Windows.Forms.MenuItem()
      Me._menuItemViewZoom = New System.Windows.Forms.MenuItem()
      Me._menuItemViewZoomIn = New System.Windows.Forms.MenuItem()
      Me._menuItemViewZoomOut = New System.Windows.Forms.MenuItem()
      Me._menuItemViewZoomValue = New System.Windows.Forms.MenuItem()
      Me._menuItemViewZoomSep1 = New System.Windows.Forms.MenuItem()
      Me._menuItemViewZoomNormal = New System.Windows.Forms.MenuItem()
      Me._menuItemViewInteractiveMode = New System.Windows.Forms.MenuItem()
      Me._menuItemViewInteractiveModeNone = New System.Windows.Forms.MenuItem()
      Me._menuItemViewInteractiveModeMagnifyGlass = New System.Windows.Forms.MenuItem()
      Me._menuItemViewInteractiveModePan = New System.Windows.Forms.MenuItem()
      Me._menuItemViewSep1 = New System.Windows.Forms.MenuItem()
      Me._menuItemViewPaintProperties = New System.Windows.Forms.MenuItem()
      Me._menuItemViewUseDpi = New System.Windows.Forms.MenuItem()
      Me._menuItemViewSep2 = New System.Windows.Forms.MenuItem()
      Me._menuItemViewFlip = New System.Windows.Forms.MenuItem()
      Me._menuItemViewFlipHorizontal = New System.Windows.Forms.MenuItem()
      Me._menuItemViewFlipVertical = New System.Windows.Forms.MenuItem()
      Me._menuItemViewRotate = New System.Windows.Forms.MenuItem()
      Me._menuItemViewRotate90 = New System.Windows.Forms.MenuItem()
      Me._menuItemViewRotate180 = New System.Windows.Forms.MenuItem()
      Me._menuItemViewRotate270 = New System.Windows.Forms.MenuItem()
      Me._menuItemViewRotateNone = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotations = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsUserMode = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsUserModeRun = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsUserModeDesign = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsSep1 = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsCurrentObject = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsSep2 = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsRedactionObjects = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsRedactionObjectsRealize = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsRedactionObjectsRestore = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsRedactionObjectsSep1 = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsRedactionObjectsRealizeAll = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsRedactionObjectsRestoreAll = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsEncryptObjects = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsEncryptObjectsApplyEncryptor = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsEncryptObjectsApplyDecryptor = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsEncryptObjectsSep1 = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsEncryptObjectsApplyAllEncryptors = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsEncryptObjectsApplyAllDecryptors = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsRealize = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsSep3 = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsAlign = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsAlignBringToFront = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsAlignSendToBack = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsAlignBringToFirst = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsAlignSendToLast = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsAlignSep1 = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsAlignObjectsAlignmentLefts = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsAlignObjectsAlignmentCenters = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsAlignObjectsAlignmentRights = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsAlignSep2 = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsAlignObjectsAlignmentTops = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsAlignObjectsAlignmentMiddles = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsAlignObjectsAlignmentBottoms = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsAlignSep3 = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsAlignObjectsMakeSameWidth = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsAlignObjectsMakeSameHeight = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsAlignObjectsMakeSameSize = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsFlip = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsFlipHorizontal = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsFlipVertical = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsGroup = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsGroupGroupSelectedObjects = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsGroupUngroup = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsPassword = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsPasswordLock = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsPasswordUnlock = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsResetRotatePoints = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsAntiAlias = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsSnapToGridProperties = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsProperties = New System.Windows.Forms.MenuItem()
      Me._menuItemCalibrate = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsSep4 = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsBehavior = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsBehaviorUseRotateThumbs = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsBehaviorMaintainAspectRatio = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsBehaviorEnableToolTip = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsBehaviorEnableAutoIncrement = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsBehaviorRestrictDesigners = New System.Windows.Forms.MenuItem()
      Me._menuItemAnnotationsBehaviorEnableObjectsAlignment = New System.Windows.Forms.MenuItem()
      Me._menuItemWindow = New System.Windows.Forms.MenuItem()
      Me._menuItemWindowCascade = New System.Windows.Forms.MenuItem()
      Me._menuItemWindowTileHorizontally = New System.Windows.Forms.MenuItem()
      Me._menuItemWindowTileVertically = New System.Windows.Forms.MenuItem()
      Me._menuItemWindowArrangeIcons = New System.Windows.Forms.MenuItem()
      Me._menuItemWindowCloseAll = New System.Windows.Forms.MenuItem()
      Me._menuItemHelp = New System.Windows.Forms.MenuItem()
      Me._menuItemHelpAbout = New System.Windows.Forms.MenuItem()
      Me._toolBarMain = New System.Windows.Forms.ToolBar()
      Me._tbbOpen = New System.Windows.Forms.ToolBarButton()
      Me._tbbSave = New System.Windows.Forms.ToolBarButton()
      Me._tbbSep1 = New System.Windows.Forms.ToolBarButton()
      Me._tbbCopy = New System.Windows.Forms.ToolBarButton()
      Me._tbbPaste = New System.Windows.Forms.ToolBarButton()
      Me._tbbDelete = New System.Windows.Forms.ToolBarButton()
      Me._tbbSep2 = New System.Windows.Forms.ToolBarButton()
      Me._tbbUndo = New System.Windows.Forms.ToolBarButton()
      Me._tbbRedo = New System.Windows.Forms.ToolBarButton()
      Me._tbbSep3 = New System.Windows.Forms.ToolBarButton()
      Me._tbbZoomIn = New System.Windows.Forms.ToolBarButton()
      Me._tbbZoomOut = New System.Windows.Forms.ToolBarButton()
      Me._tbbNoZoom = New System.Windows.Forms.ToolBarButton()
      Me._tbbSep4 = New System.Windows.Forms.ToolBarButton()
      Me._tbbGroup = New System.Windows.Forms.ToolBarButton()
      Me._tbbUngroup = New System.Windows.Forms.ToolBarButton()
      Me._tbbProperties = New System.Windows.Forms.ToolBarButton()
      Me._tbbSep5 = New System.Windows.Forms.ToolBarButton()
      Me._tbbBringToFront = New System.Windows.Forms.ToolBarButton()
      Me._tbbSendToBack = New System.Windows.Forms.ToolBarButton()
      Me._tbbBringToFirst = New System.Windows.Forms.ToolBarButton()
      Me._tbbSendToLast = New System.Windows.Forms.ToolBarButton()
      Me._tbbSep6 = New System.Windows.Forms.ToolBarButton()
      Me._tbbAlignLefts = New System.Windows.Forms.ToolBarButton()
      Me._tbbAlignCenters = New System.Windows.Forms.ToolBarButton()
      Me._tbbAlignRights = New System.Windows.Forms.ToolBarButton()
      Me._tbbAlignTops = New System.Windows.Forms.ToolBarButton()
      Me._tbbAlignMiddles = New System.Windows.Forms.ToolBarButton()
      Me._tbbAlignBottoms = New System.Windows.Forms.ToolBarButton()
      Me._tbbMakeSameWidth = New System.Windows.Forms.ToolBarButton()
      Me._tbbMakeSameHeight = New System.Windows.Forms.ToolBarButton()
      Me._tbbMakeSameSize = New System.Windows.Forms.ToolBarButton()
      Me._tbbSep7 = New System.Windows.Forms.ToolBarButton()
      Me._tbbRunDesign = New System.Windows.Forms.ToolBarButton()
      Me._tbbRotate = New System.Windows.Forms.ToolBarButton()
      Me._sbMain = New System.Windows.Forms.StatusBar()
      Me.SuspendLayout()
      ' 
      ' _mainMenu
      ' 
      Me._mainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemFile, Me._menuItemEdit, Me._menuItemView, Me._menuItemAnnotations, Me._menuItemWindow, Me._menuItemHelp})
      ' 
      ' _menuItemFile
      ' 
      Me._menuItemFile.Index = 0
      Me._menuItemFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemFileOpen, Me._menuItemFileSaveAnnotations, Me._menuItemFileSaveAs, Me._menuItemFileSaveAsTiff, Me._menuItemFileSaveAsWang, Me._menuItemFileSep1, Me._menuItemFilePrint, _
       Me._menuItemFilePrintPreview, Me._menuItemFileSep2, Me._menuItemLoadAnnPackage, Me._menuItemFileLoadBateStamp, Me._menuItemFileSep3, Me._menuItemFileExit})
      Me._menuItemFile.Text = "&File"
      ' 
      ' _menuItemFileOpen
      ' 
      Me._menuItemFileOpen.Index = 0
      Me._menuItemFileOpen.RadioCheck = True
      Me._menuItemFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
      Me._menuItemFileOpen.Text = "&Open..."
      ' 
      ' _menuItemFileSaveAnnotations
      ' 
      Me._menuItemFileSaveAnnotations.Index = 1
      Me._menuItemFileSaveAnnotations.Shortcut = System.Windows.Forms.Shortcut.CtrlS
      Me._menuItemFileSaveAnnotations.Text = "&Save Annotations"
      ' 
      ' _menuItemFileSaveAs
      ' 
      Me._menuItemFileSaveAs.Index = 2
      Me._menuItemFileSaveAs.RadioCheck = True
      Me._menuItemFileSaveAs.Text = "Save &As..."
      ' 
      ' _menuItemFileSaveAsTiff
      ' 
      Me._menuItemFileSaveAsTiff.Index = 3
      Me._menuItemFileSaveAsTiff.RadioCheck = True
      Me._menuItemFileSaveAsTiff.Text = "Save As &Tiff Tag..."
      ' 
      ' _menuItemFileSaveAsWang
      ' 
      Me._menuItemFileSaveAsWang.Index = 4
      Me._menuItemFileSaveAsWang.Text = "Save As &Wang Tag..."
      '
      ' _menuItemFileSep1
      ' 
      Me._menuItemFileSep1.Index = 5
      Me._menuItemFileSep1.RadioCheck = True
      Me._menuItemFileSep1.Text = "-"
      ' 
      ' _menuItemFilePrint
      ' 
      Me._menuItemFilePrint.Index = 6
      Me._menuItemFilePrint.RadioCheck = True
      Me._menuItemFilePrint.Shortcut = System.Windows.Forms.Shortcut.CtrlP
      Me._menuItemFilePrint.Text = "&Print..."
      ' 
      ' _menuItemFilePrintPreview
      ' 
      Me._menuItemFilePrintPreview.Index = 7
      Me._menuItemFilePrintPreview.RadioCheck = True
      Me._menuItemFilePrintPreview.Text = "Print Pre&view..."
      ' 
      ' _menuItemFileSep2
      ' 
      Me._menuItemFileSep2.Index = 8
      Me._menuItemFileSep2.RadioCheck = True
      Me._menuItemFileSep2.Text = "-"
      ' 
      ' _menuItemLoadAnnPackage
      ' 
      Me._menuItemLoadAnnPackage.Index = 9
      Me._menuItemLoadAnnPackage.Text = "Loa&d Package..."
      ' 
      ' _menuItemFileLoadBateStamp
      ' 
      Me._menuItemFileLoadBateStamp.Index = 10
      Me._menuItemFileLoadBateStamp.Text = "Load &Bates Stamp..."
      ' 
      ' _menuItemFileSep3
      ' 
      Me._menuItemFileSep3.Index = 11
      Me._menuItemFileSep3.RadioCheck = True
      Me._menuItemFileSep3.Text = "-"
      ' 
      ' _menuItemFileExit
      ' 
      Me._menuItemFileExit.Index = 12
      Me._menuItemFileExit.RadioCheck = True
      Me._menuItemFileExit.Text = "E&xit"
      ' 
      ' _menuItemEdit
      ' 
      Me._menuItemEdit.Index = 1
      Me._menuItemEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemEditUndo, Me._menuItemEditRedo, Me._menuItemEditSep1, Me._menuItemEditCut, Me._menuItemEditCopy, Me._menuItemEditPaste, _
       Me._menuItemEditDelete, Me._menuItemEditSep2, Me._menuItemEditSelectAll, Me._menuItemEditSelectNone, Me._menuItemEditDuplicate})
      Me._menuItemEdit.Text = "&Edit"
      ' 
      ' _menuItemEditUndo
      ' 
      Me._menuItemEditUndo.Index = 0
      Me._menuItemEditUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ
      Me._menuItemEditUndo.Text = "&Undo"
      ' 
      ' _menuItemEditRedo
      ' 
      Me._menuItemEditRedo.Index = 1
      Me._menuItemEditRedo.Shortcut = System.Windows.Forms.Shortcut.CtrlY
      Me._menuItemEditRedo.Text = "&Redo"
      ' 
      ' _menuItemEditSep1
      ' 
      Me._menuItemEditSep1.Index = 2
      Me._menuItemEditSep1.Text = "-"
      ' 
      ' _menuItemEditCut
      ' 
      Me._menuItemEditCut.Index = 3
      Me._menuItemEditCut.RadioCheck = True
      Me._menuItemEditCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX
      Me._menuItemEditCut.Text = "Cu&t"
      ' 
      ' _menuItemEditCopy
      ' 
      Me._menuItemEditCopy.Index = 4
      Me._menuItemEditCopy.RadioCheck = True
      Me._menuItemEditCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC
      Me._menuItemEditCopy.Text = "&Copy"
      ' 
      ' _menuItemEditPaste
      ' 
      Me._menuItemEditPaste.Index = 5
      Me._menuItemEditPaste.RadioCheck = True
      Me._menuItemEditPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV
      Me._menuItemEditPaste.Text = "&Paste"
      ' 
      ' _menuItemEditDelete
      ' 
      Me._menuItemEditDelete.Index = 6
      Me._menuItemEditDelete.RadioCheck = True
      Me._menuItemEditDelete.Shortcut = System.Windows.Forms.Shortcut.Del
      Me._menuItemEditDelete.Text = "&Delete"
      ' 
      ' _menuItemEditSep2
      ' 
      Me._menuItemEditSep2.Index = 7
      Me._menuItemEditSep2.RadioCheck = True
      Me._menuItemEditSep2.Text = "-"
      ' 
      ' _menuItemEditSelectAll
      ' 
      Me._menuItemEditSelectAll.Index = 8
      Me._menuItemEditSelectAll.RadioCheck = True
      Me._menuItemEditSelectAll.Shortcut = System.Windows.Forms.Shortcut.CtrlA
      Me._menuItemEditSelectAll.Text = "Select &All"
      ' 
      ' _menuItemEditSelectNone
      ' 
      Me._menuItemEditSelectNone.Index = 9
      Me._menuItemEditSelectNone.RadioCheck = True
      Me._menuItemEditSelectNone.Text = "Select &None"
      ' 
      ' _menuItemEditDuplicate
      ' 
      Me._menuItemEditDuplicate.Index = 10
      Me._menuItemEditDuplicate.Text = "Dup&licate"
      ' 
      ' _menuItemView
      ' 
      Me._menuItemView.Index = 2
      Me._menuItemView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemViewSizeMode, Me._menuItemViewZoom, Me._menuItemViewInteractiveMode, Me._menuItemViewSep1, Me._menuItemViewPaintProperties, Me._menuItemViewUseDpi, _
       Me._menuItemViewSep2, Me._menuItemViewFlip, Me._menuItemViewRotate})
      Me._menuItemView.Text = "&View"
      ' 
      ' _menuItemViewSizeMode
      ' 
      Me._menuItemViewSizeMode.Index = 0
      Me._menuItemViewSizeMode.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemViewSizeModeNormal, Me._menuItemViewSizeModeStretch, Me._menuItemViewSizeModeFitAlways, Me._menuItemViewSizeModeFitWidth, Me._menuItemViewSizeModeFit})
      Me._menuItemViewSizeMode.RadioCheck = True
      Me._menuItemViewSizeMode.Text = "&Size Mode"
      ' 
      ' _menuItemViewSizeModeNormal
      ' 
      Me._menuItemViewSizeModeNormal.Index = 0
      Me._menuItemViewSizeModeNormal.RadioCheck = True
      Me._menuItemViewSizeModeNormal.Text = "&Normal"
      ' 
      ' _menuItemViewSizeModeStretch
      ' 
      Me._menuItemViewSizeModeStretch.Index = 1
      Me._menuItemViewSizeModeStretch.RadioCheck = True
      Me._menuItemViewSizeModeStretch.Text = "&Stretch"
      ' 
      ' _menuItemViewSizeModeFitAlways
      ' 
      Me._menuItemViewSizeModeFitAlways.Index = 2
      Me._menuItemViewSizeModeFitAlways.RadioCheck = True
      Me._menuItemViewSizeModeFitAlways.Text = "Fit &Always"
      ' 
      ' _menuItemViewSizeModeFitWidth
      ' 
      Me._menuItemViewSizeModeFitWidth.Index = 3
      Me._menuItemViewSizeModeFitWidth.RadioCheck = True
      Me._menuItemViewSizeModeFitWidth.Text = "Fit &Width"
      ' 
      ' _menuItemViewSizeModeFit
      ' 
      Me._menuItemViewSizeModeFit.Index = 4
      Me._menuItemViewSizeModeFit.RadioCheck = True
      Me._menuItemViewSizeModeFit.Text = "&Fit"
      ' 
      ' _menuItemViewZoom
      ' 
      Me._menuItemViewZoom.Index = 1
      Me._menuItemViewZoom.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemViewZoomIn, Me._menuItemViewZoomOut, Me._menuItemViewZoomValue, Me._menuItemViewZoomSep1, Me._menuItemViewZoomNormal})
      Me._menuItemViewZoom.RadioCheck = True
      Me._menuItemViewZoom.Text = "&Zoom"
      ' 
      ' _menuItemViewZoomIn
      ' 
      Me._menuItemViewZoomIn.Index = 0
      Me._menuItemViewZoomIn.RadioCheck = True
      Me._menuItemViewZoomIn.Text = "&In"
      ' 
      ' _menuItemViewZoomOut
      ' 
      Me._menuItemViewZoomOut.Index = 1
      Me._menuItemViewZoomOut.RadioCheck = True
      Me._menuItemViewZoomOut.Text = "&Out"
      ' 
      ' _menuItemViewZoomValue
      ' 
      Me._menuItemViewZoomValue.Index = 2
      Me._menuItemViewZoomValue.Text = "&Value..."
      ' 
      ' _menuItemViewZoomSep1
      ' 
      Me._menuItemViewZoomSep1.Index = 3
      Me._menuItemViewZoomSep1.RadioCheck = True
      Me._menuItemViewZoomSep1.Text = "-"
      ' 
      ' _menuItemViewZoomNormal
      ' 
      Me._menuItemViewZoomNormal.Index = 4
      Me._menuItemViewZoomNormal.RadioCheck = True
      Me._menuItemViewZoomNormal.Text = "&Normal (100%)"
      ' 
      ' _menuItemViewInteractiveMode
      ' 
      Me._menuItemViewInteractiveMode.Index = 2
      Me._menuItemViewInteractiveMode.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemViewInteractiveModeNone, Me._menuItemViewInteractiveModeMagnifyGlass, Me._menuItemViewInteractiveModePan})
      Me._menuItemViewInteractiveMode.Text = "&Interactive Mode"
      ' 
      ' _menuItemViewInteractiveModeNone
      ' 
      Me._menuItemViewInteractiveModeNone.Index = 0
      Me._menuItemViewInteractiveModeNone.Text = "&Annotations"
      ' 
      ' _menuItemViewInteractiveModeMagnifyGlass
      ' 
      Me._menuItemViewInteractiveModeMagnifyGlass.Index = 1
      Me._menuItemViewInteractiveModeMagnifyGlass.Text = "&Magnify Glass"
      ' 
      ' _menuItemViewInteractiveModePan
      ' 
      Me._menuItemViewInteractiveModePan.Index = 2
      Me._menuItemViewInteractiveModePan.Text = "&Pan"
      ' 
      ' _menuItemViewSep1
      ' 
      Me._menuItemViewSep1.Index = 3
      Me._menuItemViewSep1.RadioCheck = True
      Me._menuItemViewSep1.Text = "-"
      ' 
      ' _menuItemViewPaintProperties
      ' 
      Me._menuItemViewPaintProperties.Index = 4
      Me._menuItemViewPaintProperties.RadioCheck = True
      Me._menuItemViewPaintProperties.Text = "&Paint Properties..."
      ' 
      ' _menuItemViewUseDpi
      ' 
      Me._menuItemViewUseDpi.Index = 5
      Me._menuItemViewUseDpi.Text = "&Use Dpi"
      ' 
      ' _menuItemViewSep2
      ' 
      Me._menuItemViewSep2.Index = 6
      Me._menuItemViewSep2.Text = "-"
      ' 
      ' _menuItemViewFlip
      ' 
      Me._menuItemViewFlip.Index = 7
      Me._menuItemViewFlip.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemViewFlipHorizontal, Me._menuItemViewFlipVertical})
      Me._menuItemViewFlip.RadioCheck = True
      Me._menuItemViewFlip.Text = "&Flip"
      ' 
      ' _menuItemViewFlipHorizontal
      ' 
      Me._menuItemViewFlipHorizontal.Index = 0
      Me._menuItemViewFlipHorizontal.RadioCheck = True
      Me._menuItemViewFlipHorizontal.Text = "&Horizontal"
      ' 
      ' _menuItemViewFlipVertical
      ' 
      Me._menuItemViewFlipVertical.Index = 1
      Me._menuItemViewFlipVertical.RadioCheck = True
      Me._menuItemViewFlipVertical.Text = "&Vertical"
      ' 
      ' _menuItemViewRotate
      ' 
      Me._menuItemViewRotate.Index = 8
      Me._menuItemViewRotate.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemViewRotate90, Me._menuItemViewRotate180, Me._menuItemViewRotate270, Me._menuItemViewRotateNone})
      Me._menuItemViewRotate.RadioCheck = True
      Me._menuItemViewRotate.Text = "&Rotate"
      ' 
      ' _menuItemViewRotate90
      ' 
      Me._menuItemViewRotate90.Index = 0
      Me._menuItemViewRotate90.RadioCheck = True
      Me._menuItemViewRotate90.Text = "9&0° clockwise"
      ' 
      ' _menuItemViewRotate180
      ' 
      Me._menuItemViewRotate180.Index = 1
      Me._menuItemViewRotate180.RadioCheck = True
      Me._menuItemViewRotate180.Text = "1&80° clockwise"
      ' 
      ' _menuItemViewRotate270
      ' 
      Me._menuItemViewRotate270.Index = 2
      Me._menuItemViewRotate270.RadioCheck = True
      Me._menuItemViewRotate270.Text = "2&70° clockwise"
      ' 
      ' _menuItemViewRotateNone
      ' 
      Me._menuItemViewRotateNone.Index = 3
      Me._menuItemViewRotateNone.Text = "N&one"
      ' 
      ' _menuItemAnnotations
      ' 
      Me._menuItemAnnotations.Index = 3
      Me._menuItemAnnotations.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemAnnotationsUserMode, Me._menuItemAnnotationsSep1, Me._menuItemAnnotationsCurrentObject, Me._menuItemAnnotationsSep2, Me._menuItemAnnotationsRedactionObjects, Me._menuItemAnnotationsEncryptObjects, _
       Me._menuItemAnnotationsRealize, Me._menuItemAnnotationsSep3, Me._menuItemAnnotationsAlign, Me._menuItemAnnotationsFlip, Me._menuItemAnnotationsGroup, Me._menuItemAnnotationsPassword, _
       Me._menuItemAnnotationsResetRotatePoints, Me._menuItemAnnotationsAntiAlias, Me._menuItemAnnotationsSnapToGridProperties, Me._menuItemAnnotationsProperties, Me._menuItemCalibrate, Me._menuItemAnnotationsSep4, Me._menuItemAnnotationsBehavior})
      Me._menuItemAnnotations.Text = "&Annotations"
      ' 
      ' _menuItemAnnotationsUserMode
      ' 
      Me._menuItemAnnotationsUserMode.Index = 0
      Me._menuItemAnnotationsUserMode.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemAnnotationsUserModeRun, Me._menuItemAnnotationsUserModeDesign})
      Me._menuItemAnnotationsUserMode.RadioCheck = True
      Me._menuItemAnnotationsUserMode.Text = "&User Mode"
      ' 
      ' _menuItemAnnotationsUserModeRun
      ' 
      Me._menuItemAnnotationsUserModeRun.Index = 0
      Me._menuItemAnnotationsUserModeRun.RadioCheck = True
      Me._menuItemAnnotationsUserModeRun.Text = "&Run"
      ' 
      ' _menuItemAnnotationsUserModeDesign
      ' 
      Me._menuItemAnnotationsUserModeDesign.Index = 1
      Me._menuItemAnnotationsUserModeDesign.RadioCheck = True
      Me._menuItemAnnotationsUserModeDesign.Text = "&Design"
      ' 
      ' _menuItemAnnotationsSep1
      ' 
      Me._menuItemAnnotationsSep1.Index = 1
      Me._menuItemAnnotationsSep1.RadioCheck = True
      Me._menuItemAnnotationsSep1.Text = "-"
      ' 
      ' _menuItemAnnotationsCurrentObject
      ' 
      Me._menuItemAnnotationsCurrentObject.Index = 2
      Me._menuItemAnnotationsCurrentObject.RadioCheck = True
      Me._menuItemAnnotationsCurrentObject.Text = "&Current Object..."
      ' 
      ' _menuItemAnnotationsSep2
      ' 
      Me._menuItemAnnotationsSep2.Index = 3
      Me._menuItemAnnotationsSep2.RadioCheck = True
      Me._menuItemAnnotationsSep2.Text = "-"
      ' 
      ' _menuItemAnnotationsRedactionObjects
      ' 
      Me._menuItemAnnotationsRedactionObjects.Index = 4
      Me._menuItemAnnotationsRedactionObjects.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemAnnotationsRedactionObjectsRealize, Me._menuItemAnnotationsRedactionObjectsRestore, Me._menuItemAnnotationsRedactionObjectsSep1, Me._menuItemAnnotationsRedactionObjectsRealizeAll, Me._menuItemAnnotationsRedactionObjectsRestoreAll})
      Me._menuItemAnnotationsRedactionObjects.RadioCheck = True
      Me._menuItemAnnotationsRedactionObjects.Text = "&Redaction Objects"
      ' 
      ' _menuItemAnnotationsRedactionObjectsRealize
      ' 
      Me._menuItemAnnotationsRedactionObjectsRealize.Index = 0
      Me._menuItemAnnotationsRedactionObjectsRealize.RadioCheck = True
      Me._menuItemAnnotationsRedactionObjectsRealize.Text = "&Realize"
      ' 
      ' _menuItemAnnotationsRedactionObjectsRestore
      ' 
      Me._menuItemAnnotationsRedactionObjectsRestore.Index = 1
      Me._menuItemAnnotationsRedactionObjectsRestore.RadioCheck = True
      Me._menuItemAnnotationsRedactionObjectsRestore.Text = "R&estore"
      ' 
      ' _menuItemAnnotationsRedactionObjectsSep1
      ' 
      Me._menuItemAnnotationsRedactionObjectsSep1.Index = 2
      Me._menuItemAnnotationsRedactionObjectsSep1.RadioCheck = True
      Me._menuItemAnnotationsRedactionObjectsSep1.Text = "-"
      ' 
      ' _menuItemAnnotationsRedactionObjectsRealizeAll
      ' 
      Me._menuItemAnnotationsRedactionObjectsRealizeAll.Index = 3
      Me._menuItemAnnotationsRedactionObjectsRealizeAll.RadioCheck = True
      Me._menuItemAnnotationsRedactionObjectsRealizeAll.Text = "Realize &All"
      ' 
      ' _menuItemAnnotationsRedactionObjectsRestoreAll
      ' 
      Me._menuItemAnnotationsRedactionObjectsRestoreAll.Index = 4
      Me._menuItemAnnotationsRedactionObjectsRestoreAll.RadioCheck = True
      Me._menuItemAnnotationsRedactionObjectsRestoreAll.Text = "Re&store All"
      ' 
      ' _menuItemAnnotationsEncryptObjects
      ' 
      Me._menuItemAnnotationsEncryptObjects.Index = 5
      Me._menuItemAnnotationsEncryptObjects.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemAnnotationsEncryptObjectsApplyEncryptor, Me._menuItemAnnotationsEncryptObjectsApplyDecryptor, Me._menuItemAnnotationsEncryptObjectsSep1, Me._menuItemAnnotationsEncryptObjectsApplyAllEncryptors, Me._menuItemAnnotationsEncryptObjectsApplyAllDecryptors})
      Me._menuItemAnnotationsEncryptObjects.RadioCheck = True
      Me._menuItemAnnotationsEncryptObjects.Text = "&Encrypt Objects"
      ' 
      ' _menuItemAnnotationsEncryptObjectsApplyEncryptor
      ' 
      Me._menuItemAnnotationsEncryptObjectsApplyEncryptor.Index = 0
      Me._menuItemAnnotationsEncryptObjectsApplyEncryptor.Text = "Apply &Encryptor"
      ' 
      ' _menuItemAnnotationsEncryptObjectsApplyDecryptor
      ' 
      Me._menuItemAnnotationsEncryptObjectsApplyDecryptor.Index = 1
      Me._menuItemAnnotationsEncryptObjectsApplyDecryptor.Text = "Apply &Decryptor"
      ' 
      ' _menuItemAnnotationsEncryptObjectsSep1
      ' 
      Me._menuItemAnnotationsEncryptObjectsSep1.Index = 2
      Me._menuItemAnnotationsEncryptObjectsSep1.Text = "-"
      ' 
      ' _menuItemAnnotationsEncryptObjectsApplyAllEncryptors
      ' 
      Me._menuItemAnnotationsEncryptObjectsApplyAllEncryptors.Index = 3
      Me._menuItemAnnotationsEncryptObjectsApplyAllEncryptors.RadioCheck = True
      Me._menuItemAnnotationsEncryptObjectsApplyAllEncryptors.Text = "&Apply All Encryptors"
      ' 
      ' _menuItemAnnotationsEncryptObjectsApplyAllDecryptors
      ' 
      Me._menuItemAnnotationsEncryptObjectsApplyAllDecryptors.Index = 4
      Me._menuItemAnnotationsEncryptObjectsApplyAllDecryptors.RadioCheck = True
      Me._menuItemAnnotationsEncryptObjectsApplyAllDecryptors.Text = "A&pply All Decryptors"
      ' 
      ' _menuItemAnnotationsRealize
      ' 
      Me._menuItemAnnotationsRealize.Index = 6
      Me._menuItemAnnotationsRealize.Text = "Reali&ze"
      ' 
      ' _menuItemAnnotationsSep3
      ' 
      Me._menuItemAnnotationsSep3.Index = 7
      Me._menuItemAnnotationsSep3.RadioCheck = True
      Me._menuItemAnnotationsSep3.Text = "-"
      ' 
      ' _menuItemAnnotationsAlign
      ' 
      Me._menuItemAnnotationsAlign.Index = 8
      Me._menuItemAnnotationsAlign.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemAnnotationsAlignBringToFront, Me._menuItemAnnotationsAlignSendToBack, Me._menuItemAnnotationsAlignBringToFirst, Me._menuItemAnnotationsAlignSendToLast, Me._menuItemAnnotationsAlignSendToLast, Me._menuItemAnnotationsAlignSep1, Me._menuItemAnnotationsAlignObjectsAlignmentLefts, _
          Me._menuItemAnnotationsAlignObjectsAlignmentCenters, Me._menuItemAnnotationsAlignObjectsAlignmentRights, Me._menuItemAnnotationsAlignSep2, Me._menuItemAnnotationsAlignObjectsAlignmentTops, Me._menuItemAnnotationsAlignObjectsAlignmentMiddles, Me._menuItemAnnotationsAlignObjectsAlignmentBottoms, _
          Me._menuItemAnnotationsAlignSep3, Me._menuItemAnnotationsAlignObjectsMakeSameWidth, Me._menuItemAnnotationsAlignObjectsMakeSameHeight, Me._menuItemAnnotationsAlignObjectsMakeSameSize})
      Me._menuItemAnnotationsAlign.RadioCheck = True
      Me._menuItemAnnotationsAlign.Text = "A&lign"
      ' 
      ' _menuItemAnnotationsAlignBringToFront
      ' 
      Me._menuItemAnnotationsAlignBringToFront.Index = 0
      Me._menuItemAnnotationsAlignBringToFront.RadioCheck = True
      Me._menuItemAnnotationsAlignBringToFront.Text = "&Bring To Front"
      ' 
      ' _menuItemAnnotationsAlignSendToBack
      ' 
      Me._menuItemAnnotationsAlignSendToBack.Index = 1
      Me._menuItemAnnotationsAlignSendToBack.RadioCheck = True
      Me._menuItemAnnotationsAlignSendToBack.Text = "&Send To Back"
      ' 
      ' _menuItemAnnotationsAlignBringToFirst
      ' 
      Me._menuItemAnnotationsAlignBringToFirst.Index = 2
      Me._menuItemAnnotationsAlignBringToFirst.RadioCheck = True
      Me._menuItemAnnotationsAlignBringToFirst.Text = "Bring To &First"
      ' 
      ' _menuItemAnnotationsAlignSendToLast
      ' 
      Me._menuItemAnnotationsAlignSendToLast.Index = 3
      Me._menuItemAnnotationsAlignSendToLast.RadioCheck = True
      Me._menuItemAnnotationsAlignSendToLast.Text = "Send To &Last"
      ' 
      ' _menuItemAnnotationsAlignSep1
      ' 
      Me._menuItemAnnotationsAlignSep1.Index = 4
      Me._menuItemAnnotationsAlignSep1.RadioCheck = True
      Me._menuItemAnnotationsAlignSep1.Text = "-"
      ' 
      ' _menuItemAnnotationsAlignObjectsAlignmentLefts
      ' 
      Me._menuItemAnnotationsAlignObjectsAlignmentLefts.Index = 5
      Me._menuItemAnnotationsAlignObjectsAlignmentLefts.RadioCheck = True
      Me._menuItemAnnotationsAlignObjectsAlignmentLefts.Text = "Align To Left"
      ' 
      ' _menuItemAnnotationsAlignObjectsAlignmentCenters
      ' 
      Me._menuItemAnnotationsAlignObjectsAlignmentCenters.Index = 6
      Me._menuItemAnnotationsAlignObjectsAlignmentCenters.RadioCheck = True
      Me._menuItemAnnotationsAlignObjectsAlignmentCenters.Text = "Align To Center"
      ' 
      ' _menuItemAnnotationsAlignObjectsAlignmentRights
      ' 
      Me._menuItemAnnotationsAlignObjectsAlignmentRights.Index = 7
      Me._menuItemAnnotationsAlignObjectsAlignmentRights.RadioCheck = True
      Me._menuItemAnnotationsAlignObjectsAlignmentRights.Text = "Align To Right"
      ' 
      ' _menuItemAnnotationsAlignSep2
      ' 
      Me._menuItemAnnotationsAlignSep2.Index = 8
      Me._menuItemAnnotationsAlignSep2.RadioCheck = True
      Me._menuItemAnnotationsAlignSep2.Text = "-"
      ' 
      ' _menuItemAnnotationsAlignObjectsAlignmentTops
      ' 
      Me._menuItemAnnotationsAlignObjectsAlignmentTops.Index = 9
      Me._menuItemAnnotationsAlignObjectsAlignmentTops.RadioCheck = True
      Me._menuItemAnnotationsAlignObjectsAlignmentTops.Text = "Align To Top"
      ' 
      ' _menuItemAnnotationsAlignObjectsAlignmentMiddles
      ' 
      Me._menuItemAnnotationsAlignObjectsAlignmentMiddles.Index = 10
      Me._menuItemAnnotationsAlignObjectsAlignmentMiddles.RadioCheck = True
      Me._menuItemAnnotationsAlignObjectsAlignmentMiddles.Text = "Align To Middle"
      ' 
      ' _menuItemAnnotationsAlignObjectsAlignmentBottoms
      ' 
      Me._menuItemAnnotationsAlignObjectsAlignmentBottoms.Index = 11
      Me._menuItemAnnotationsAlignObjectsAlignmentBottoms.RadioCheck = True
      Me._menuItemAnnotationsAlignObjectsAlignmentBottoms.Text = "Align To Bottom"
      ' 
      ' _menuItemAnnotationsAlignSep3
      ' 
      Me._menuItemAnnotationsAlignSep3.Index = 12
      Me._menuItemAnnotationsAlignSep3.RadioCheck = True
      Me._menuItemAnnotationsAlignSep3.Text = "-"
      ' 
      ' _menuItemAnnotationsAlignObjectsMakeSameWidth
      ' 
      Me._menuItemAnnotationsAlignObjectsMakeSameWidth.Index = 13
      Me._menuItemAnnotationsAlignObjectsMakeSameWidth.RadioCheck = True
      Me._menuItemAnnotationsAlignObjectsMakeSameWidth.Text = "Make Same Width"
      ' 
      ' _menuItemAnnotationsAlignObjectsMakeSameHeight
      ' 
      Me._menuItemAnnotationsAlignObjectsMakeSameHeight.Index = 14
      Me._menuItemAnnotationsAlignObjectsMakeSameHeight.RadioCheck = True
      Me._menuItemAnnotationsAlignObjectsMakeSameHeight.Text = "Make Same Height"
      ' 
      ' _menuItemAnnotationsAlignObjectsMakeSameSize
      ' 
      Me._menuItemAnnotationsAlignObjectsMakeSameSize.Index = 15
      Me._menuItemAnnotationsAlignObjectsMakeSameSize.RadioCheck = True
      Me._menuItemAnnotationsAlignObjectsMakeSameSize.Text = "Make Same Size"
      ' 
      ' _menuItemAnnotationsFlip
      ' 
      Me._menuItemAnnotationsFlip.Index = 9
      Me._menuItemAnnotationsFlip.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemAnnotationsFlipHorizontal, Me._menuItemAnnotationsFlipVertical})
      Me._menuItemAnnotationsFlip.RadioCheck = True
      Me._menuItemAnnotationsFlip.Text = "&Flip"
      ' 
      ' _menuItemAnnotationsFlipHorizontal
      ' 
      Me._menuItemAnnotationsFlipHorizontal.Index = 0
      Me._menuItemAnnotationsFlipHorizontal.RadioCheck = True
      Me._menuItemAnnotationsFlipHorizontal.Text = "&Horizontal"
      ' 
      ' _menuItemAnnotationsFlipVertical
      ' 
      Me._menuItemAnnotationsFlipVertical.Index = 1
      Me._menuItemAnnotationsFlipVertical.RadioCheck = True
      Me._menuItemAnnotationsFlipVertical.Text = "&Vertical"
      ' 
      ' _menuItemAnnotationsGroup
      ' 
      Me._menuItemAnnotationsGroup.Index = 10
      Me._menuItemAnnotationsGroup.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemAnnotationsGroupGroupSelectedObjects, Me._menuItemAnnotationsGroupUngroup})
      Me._menuItemAnnotationsGroup.RadioCheck = True
      Me._menuItemAnnotationsGroup.Text = "&Group"
      ' 
      ' _menuItemAnnotationsGroupGroupSelectedObjects
      ' 
      Me._menuItemAnnotationsGroupGroupSelectedObjects.Index = 0
      Me._menuItemAnnotationsGroupGroupSelectedObjects.RadioCheck = True
      Me._menuItemAnnotationsGroupGroupSelectedObjects.Text = "&Group Selected Objects"
      ' 
      ' _menuItemAnnotationsGroupUngroup
      ' 
      Me._menuItemAnnotationsGroupUngroup.Index = 1
      Me._menuItemAnnotationsGroupUngroup.RadioCheck = True
      Me._menuItemAnnotationsGroupUngroup.Text = "&Ungroup"
      ' 
      ' _menuItemAnnotationsPassword
      ' 
      Me._menuItemAnnotationsPassword.Index = 11
      Me._menuItemAnnotationsPassword.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemAnnotationsPasswordLock, Me._menuItemAnnotationsPasswordUnlock})
      Me._menuItemAnnotationsPassword.RadioCheck = True
      Me._menuItemAnnotationsPassword.Text = "Pass&word"
      ' 
      ' _menuItemAnnotationsPasswordLock
      ' 
      Me._menuItemAnnotationsPasswordLock.Index = 0
      Me._menuItemAnnotationsPasswordLock.RadioCheck = True
      Me._menuItemAnnotationsPasswordLock.Text = "&Lock..."
      ' 
      ' _menuItemAnnotationsPasswordUnlock
      ' 
      Me._menuItemAnnotationsPasswordUnlock.Index = 1
      Me._menuItemAnnotationsPasswordUnlock.RadioCheck = True
      Me._menuItemAnnotationsPasswordUnlock.Text = "&Unlock..."
      ' 
      ' _menuItemAnnotationsResetRotatePoints
      ' 
      Me._menuItemAnnotationsResetRotatePoints.Index = 12
      Me._menuItemAnnotationsResetRotatePoints.RadioCheck = True
      Me._menuItemAnnotationsResetRotatePoints.Text = "Re&set Rotate Points"
      ' 
      ' _menuItemAnnotationsAntiAlias
      ' 
      Me._menuItemAnnotationsAntiAlias.Index = 13
      Me._menuItemAnnotationsAntiAlias.RadioCheck = True
      Me._menuItemAnnotationsAntiAlias.Text = "&Anti Alias"
      ' 
      ' _menuItemAnnotationsSnapToGridProperties
      ' 
      Me._menuItemAnnotationsSnapToGridProperties.Index = 14
      Me._menuItemAnnotationsSnapToGridProperties.Text = "S&nap To Grid Properties"
      '
      ' _menuItemAnnotationsProperties
      ' 
      Me._menuItemAnnotationsProperties.Index = 15
      Me._menuItemAnnotationsProperties.RadioCheck = True
      Me._menuItemAnnotationsProperties.Text = "&Properties..."
      ' 
      ' _menuItemCalibrate
      ' 
      Me._menuItemCalibrate.Index = 16
      Me._menuItemCalibrate.Text = "Cal&ibrate..."
      ' 
      ' _menuItemAnnotationsSep4
      ' 
      Me._menuItemAnnotationsSep4.Index = 17
      Me._menuItemAnnotationsSep4.Text = "-"
      ' 
      ' _menuItemAnnotationsBehavior
      ' 
      Me._menuItemAnnotationsBehavior.Index = 18
      Me._menuItemAnnotationsBehavior.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemAnnotationsBehaviorUseRotateThumbs, Me._menuItemAnnotationsBehaviorMaintainAspectRatio, Me._menuItemAnnotationsBehaviorEnableToolTip, Me._menuItemAnnotationsBehaviorEnableAutoIncrement, Me._menuItemAnnotationsBehaviorRestrictDesigners, Me._menuItemAnnotationsBehaviorEnableObjectsAlignment})
      Me._menuItemAnnotationsBehavior.Text = "&Behavior"
      ' 
      ' _menuItemAnnotationsBehaviorUseRotateThumbs
      ' 
      Me._menuItemAnnotationsBehaviorUseRotateThumbs.Index = 0
      Me._menuItemAnnotationsBehaviorUseRotateThumbs.RadioCheck = True
      Me._menuItemAnnotationsBehaviorUseRotateThumbs.Text = "Use &Rotate Control Points"
      ' 
      ' _menuItemAnnotationsBehaviorMaintainAspectRatio
      ' 
      Me._menuItemAnnotationsBehaviorMaintainAspectRatio.Index = 1
      Me._menuItemAnnotationsBehaviorMaintainAspectRatio.RadioCheck = True
      Me._menuItemAnnotationsBehaviorMaintainAspectRatio.Text = "&Maintain Aspect Ratio"
      Me._menuItemAnnotationsBehaviorMaintainAspectRatio.Visible = False
      ' 
      ' _menuItemAnnotationsBehaviorEnableToolTip
      ' 
      Me._menuItemAnnotationsBehaviorEnableToolTip.Index = 2
      Me._menuItemAnnotationsBehaviorEnableToolTip.RadioCheck = True
      Me._menuItemAnnotationsBehaviorEnableToolTip.Text = "Enable &ToolTip"
      ' 

      ' _menuItemAnnotationsBehaviorEnableAutoIncrement
      ' 
      Me._menuItemAnnotationsBehaviorEnableAutoIncrement.Index = 3
      Me._menuItemAnnotationsBehaviorEnableAutoIncrement.Text = "Enable A&uto Increment Label"
      ' 
      ' _menuItemAnnotationsBehaviorRestrictDesigners
      ' 
      Me._menuItemAnnotationsBehaviorRestrictDesigners.Index = 4
      Me._menuItemAnnotationsBehaviorRestrictDesigners.Text = "&Restrict Designers"
      ' 
      ' _menuItemAnnotationsBehaviorEnableObjectsAlignment
      ' 
      Me._menuItemAnnotationsBehaviorEnableObjectsAlignment.Index = 5
      Me._menuItemAnnotationsBehaviorEnableObjectsAlignment.Text = "Enable Objects &Alignment"
      ' 
      ' _menuItemWindow
      ' 
      Me._menuItemWindow.Index = 4
      Me._menuItemWindow.MdiList = True
      Me._menuItemWindow.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemWindowCascade, Me._menuItemWindowTileHorizontally, Me._menuItemWindowTileVertically, Me._menuItemWindowArrangeIcons, Me._menuItemWindowCloseAll})
      Me._menuItemWindow.Text = "&Window"
      ' 
      ' _menuItemWindowCascade
      ' 
      Me._menuItemWindowCascade.Index = 0
      Me._menuItemWindowCascade.RadioCheck = True
      Me._menuItemWindowCascade.Shortcut = System.Windows.Forms.Shortcut.ShiftF5
      Me._menuItemWindowCascade.Text = "&Cascade"
      ' 
      ' _menuItemWindowTileHorizontally
      ' 
      Me._menuItemWindowTileHorizontally.Index = 1
      Me._menuItemWindowTileHorizontally.RadioCheck = True
      Me._menuItemWindowTileHorizontally.Shortcut = System.Windows.Forms.Shortcut.ShiftF4
      Me._menuItemWindowTileHorizontally.Text = "Tile &Horizontally"
      ' 
      ' _menuItemWindowTileVertically
      ' 
      Me._menuItemWindowTileVertically.Index = 2
      Me._menuItemWindowTileVertically.RadioCheck = True
      Me._menuItemWindowTileVertically.Text = "Tile &Vertically"
      ' 
      ' _menuItemWindowArrangeIcons
      ' 
      Me._menuItemWindowArrangeIcons.Index = 3
      Me._menuItemWindowArrangeIcons.RadioCheck = True
      Me._menuItemWindowArrangeIcons.Text = "Arrange &Icons"
      ' 
      ' _menuItemWindowCloseAll
      ' 
      Me._menuItemWindowCloseAll.Index = 4
      Me._menuItemWindowCloseAll.RadioCheck = True
      Me._menuItemWindowCloseAll.Text = "Close &All"
      ' 
      ' _menuItemHelp
      ' 
      Me._menuItemHelp.Index = 5
      Me._menuItemHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemHelpAbout})
      Me._menuItemHelp.Text = "&Help"
      ' 
      ' _menuItemHelpAbout
      ' 
      Me._menuItemHelpAbout.Index = 0
      Me._menuItemHelpAbout.RadioCheck = True
      Me._menuItemHelpAbout.Shortcut = System.Windows.Forms.Shortcut.F1
      Me._menuItemHelpAbout.Text = "&About..."
      ' 
      ' _toolBarMain
      ' 
      Me._toolBarMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me._toolBarMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me._tbbOpen, Me._tbbSave, Me._tbbSep1, Me._tbbCopy, Me._tbbPaste, Me._tbbDelete, _
       Me._tbbSep2, Me._tbbUndo, Me._tbbRedo, Me._tbbSep3, Me._tbbZoomIn, Me._tbbZoomOut, _
       Me._tbbNoZoom, Me._tbbSep4, Me._tbbGroup, Me._tbbUngroup, Me._tbbProperties, Me._tbbSep5, _
       Me._tbbBringToFront, Me._tbbSendToBack, Me._tbbBringToFirst, Me._tbbSendToLast, Me._tbbSep6, Me._tbbAlignLefts, _
          Me._tbbAlignCenters, Me._tbbAlignRights, Me._tbbAlignTops, Me._tbbAlignMiddles, Me._tbbAlignBottoms, Me._tbbMakeSameWidth, _
          Me._tbbMakeSameHeight, Me._tbbMakeSameSize, Me._tbbSep7, Me._tbbRunDesign})
      Me._toolBarMain.DropDownArrows = True
      Me._toolBarMain.Location = New System.Drawing.Point(0, 0)
      Me._toolBarMain.Name = "_toolBarMain"
      Me._toolBarMain.ShowToolTips = True
      Me._toolBarMain.Size = New System.Drawing.Size(768, 28)
      Me._toolBarMain.TabIndex = 0
      ' 
      ' _tbbOpen
      ' 
      Me._tbbOpen.ImageIndex = 0
      Me._tbbOpen.Name = "_tbbOpen"
      Me._tbbOpen.ToolTipText = "Open File"
      ' 
      ' _tbbSave
      ' 
      Me._tbbSave.ImageIndex = 1
      Me._tbbSave.Name = "_tbbSave"
      Me._tbbSave.ToolTipText = "Save File"
      ' 
      ' _tbbSep1
      ' 
      Me._tbbSep1.Name = "_tbbSep1"
      Me._tbbSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      ' 
      ' _tbbCopy
      ' 
      Me._tbbCopy.ImageIndex = 2
      Me._tbbCopy.Name = "_tbbCopy"
      Me._tbbCopy.ToolTipText = "Save Selected Annotations to Clipboard"
      ' 
      ' _tbbPaste
      ' 
      Me._tbbPaste.ImageIndex = 3
      Me._tbbPaste.Name = "_tbbPaste"
      Me._tbbPaste.ToolTipText = "Paste Annotations from Clipboard"
      ' 
      ' _tbbDelete
      ' 
      Me._tbbDelete.ImageIndex = 4
      Me._tbbDelete.Name = "_tbbDelete"
      Me._tbbDelete.ToolTipText = "Delete Selected Annotations"
      ' 
      ' _tbbSep2
      ' 
      Me._tbbSep2.Name = "_tbbSep2"
      Me._tbbSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      ' 
      ' _tbbUndo
      ' 
      Me._tbbUndo.ImageIndex = 5
      Me._tbbUndo.Name = "_tbbUndo"
      Me._tbbUndo.ToolTipText = "Undo"
      ' 
      ' _tbbRedo
      ' 
      Me._tbbRedo.ImageIndex = 6
      Me._tbbRedo.Name = "_tbbRedo"
      Me._tbbRedo.ToolTipText = "Redo"
      ' 
      ' _tbbSep3
      ' 
      Me._tbbSep3.Name = "_tbbSep3"
      Me._tbbSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      ' 
      ' _tbbZoomIn
      ' 
      Me._tbbZoomIn.ImageIndex = 7
      Me._tbbZoomIn.Name = "_tbbZoomIn"
      Me._tbbZoomIn.ToolTipText = "Zoom In"
      ' 
      ' _tbbZoomOut
      ' 
      Me._tbbZoomOut.ImageIndex = 8
      Me._tbbZoomOut.Name = "_tbbZoomOut"
      Me._tbbZoomOut.ToolTipText = "Zoom Out"
      ' 
      ' _tbbNoZoom
      ' 
      Me._tbbNoZoom.ImageIndex = 9
      Me._tbbNoZoom.Name = "_tbbNoZoom"
      Me._tbbNoZoom.ToolTipText = "No Zoom (100%)"
      ' 
      ' _tbbSep4
      ' 
      Me._tbbSep4.Name = "_tbbSep4"
      Me._tbbSep4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      ' 
      ' _tbbGroup
      ' 
      Me._tbbGroup.ImageIndex = 11
      Me._tbbGroup.Name = "_tbbGroup"
      Me._tbbGroup.ToolTipText = "Group Selected Objects"
      ' 
      ' _tbbUngroup
      ' 
      Me._tbbUngroup.ImageIndex = 12
      Me._tbbUngroup.Name = "_tbbUngroup"
      Me._tbbUngroup.ToolTipText = "Ungroup Selected Group"
      ' 
      ' _tbbProperties
      ' 
      Me._tbbProperties.ImageIndex = 13
      Me._tbbProperties.Name = "_tbbProperties"
      Me._tbbProperties.ToolTipText = "Properties"
      ' 
      ' _tbbSep5
      ' 
      Me._tbbSep5.Name = "_tbbSep5"
      Me._tbbSep5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      ' 
      ' _tbbBringToFront
      ' 
      Me._tbbBringToFront.ImageIndex = 14
      Me._tbbBringToFront.Name = "_tbbBringToFront"
      Me._tbbBringToFront.ToolTipText = "Bring Selected Object(s) to Front"
      ' 
      ' _tbbSendToBack
      ' 
      Me._tbbSendToBack.ImageIndex = 15
      Me._tbbSendToBack.Name = "_tbbSendToBack"
      Me._tbbSendToBack.ToolTipText = "Send Selected Object(s) to Back"
      ' 
      ' _tbbBringToFirst
      ' 
      Me._tbbBringToFirst.ImageIndex = 16
      Me._tbbBringToFirst.Name = "_tbbBringToFirst"
      Me._tbbBringToFirst.ToolTipText = "Bring Selected Object(s) to First"
      ' 
      ' _tbbSendToLast
      ' 
      Me._tbbSendToLast.ImageIndex = 17
      Me._tbbSendToLast.Name = "_tbbSendToLast"
      Me._tbbSendToLast.ToolTipText = "Send Selected Object(s) to Last"
      ' 
      ' _tbbSep6
      ' 
      Me._tbbSep6.Name = "_tbbSep6"
      Me._tbbSep6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      ' 
      ' _tbbAlignLefts
      ' 
      Me._tbbAlignLefts.ImageIndex = 18
      Me._tbbAlignLefts.Name = "_tbbAlignLefts"
      Me._tbbAlignLefts.ToolTipText = "Align Selected Objects to Left"
      ' 
      ' _tbbAlignCenters
      ' 
      Me._tbbAlignCenters.ImageIndex = 19
      Me._tbbAlignCenters.Name = "_tbbAlignCenters"
      Me._tbbAlignCenters.ToolTipText = "Align Selected Objects to Center"
      ' 
      ' _tbbAlignRights
      ' 
      Me._tbbAlignRights.ImageIndex = 20
      Me._tbbAlignRights.Name = "_tbbAlignRights"
      Me._tbbAlignRights.ToolTipText = "Align Selected Objects to Right"
      ' 
      ' _tbbAlignTops
      ' 
      Me._tbbAlignTops.ImageIndex = 21
      Me._tbbAlignTops.Name = "_tbbAlignTops"
      Me._tbbAlignTops.ToolTipText = "Align Selected Objects to Top"
      ' 
      ' _tbbAlignMiddles
      ' 
      Me._tbbAlignMiddles.ImageIndex = 22
      Me._tbbAlignMiddles.Name = "_tbbAlignMiddles"
      Me._tbbAlignMiddles.ToolTipText = "Align Selected Objects to Middle"
      ' 
      ' _tbbAlignBottoms
      ' 
      Me._tbbAlignBottoms.ImageIndex = 23
      Me._tbbAlignBottoms.Name = "_tbbAlignBottoms"
      Me._tbbAlignBottoms.ToolTipText = "Align Selected Objects to Bottom"
      ' 
      ' _tbbMakeSameWidth
      ' 
      Me._tbbMakeSameWidth.ImageIndex = 24
      Me._tbbMakeSameWidth.Name = "_tbbMakeSameWidth"
      Me._tbbMakeSameWidth.ToolTipText = "Make Selected Objects Same Width"
      ' 
      ' _tbbMakeSameHeight
      ' 
      Me._tbbMakeSameHeight.ImageIndex = 25
      Me._tbbMakeSameHeight.Name = "_tbbMakeSameHeight"
      Me._tbbMakeSameHeight.ToolTipText = "Make Selected Objects Same Height"
      ' 
      ' _tbbMakeSameSize
      ' 
      Me._tbbMakeSameSize.ImageIndex = 26
      Me._tbbMakeSameSize.Name = "_tbbMakeSameSize"
      Me._tbbMakeSameSize.ToolTipText = "Make Selected Objects Same Size"
      ' 
      ' _tbbSep7
      ' 
      Me._tbbSep7.Name = "_tbbSep7"
      Me._tbbSep7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      ' 
      ' _tbbRunDesign
      ' 
      Me._tbbRunDesign.ImageIndex = 27
      Me._tbbRunDesign.Name = "_tbbRunDesign"
      ' 
      ' _tbbRotate
      ' 
      Me._tbbRotate.ImageIndex = 10
      Me._tbbRotate.Name = "_tbbRotate"
      Me._tbbRotate.ToolTipText = "Rotate"
      ' 
      ' _sbMain
      ' 
      Me._sbMain.Location = New System.Drawing.Point(0, 593)
      Me._sbMain.Name = "_sbMain"
      Me._sbMain.Size = New System.Drawing.Size(768, 22)
      Me._sbMain.TabIndex = 2
      ' 
      ' MainForm
      ' 
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(768, 615)
      Me.Controls.Add(Me._sbMain)
      Me.Controls.Add(Me._toolBarMain)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.IsMdiContainer = True
      Me.Menu = Me._mainMenu
      Me.Name = "MainForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "MainForm"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
#End Region

   ''' <summary>
   ''' The main entry point for the application.
   ''' </summary>
   <STAThread()> _
   Shared Sub Main()
      ' Set license


      If Not Support.SetLicense() Then
         Return
      End If

      If RasterSupport.IsLocked(RasterSupportType.Document) Then
         MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.Document.ToString()), "Warning")
         Return
      End If

      Application.EnableVisualStyles()
      Application.DoEvents()

      Application.Run(New MainForm())
   End Sub

   Private _codecs As RasterCodecs
   Private _annCodecs As AnnCodecs
   Private _printDocument As PrintDocument
   Private _paintProperties As RasterPaintProperties
   Private _automationManager As AnnAutomationManager
   Private _antiAlias As Boolean
   Private _redactionMessage As Boolean
   Private _openInitialPath As String = String.Empty

   Private Shared ReadOnly _minimumScaleFactor As Single = 0.05F
   Private Shared ReadOnly _maximumScaleFactor As Single = 11.0F

   Public ReadOnly Property AutomationManager() As AnnAutomationManager
      Get
         Return _automationManager
      End Get
   End Property

   Public Property RedactionMessage() As Boolean
      Get
         Return _redactionMessage
      End Get
      Set(value As Boolean)
         _redactionMessage = value
      End Set
   End Property

   Public ReadOnly Property AnnCodecs() As AnnCodecs
      Get
         Return _annCodecs
      End Get
   End Property

   Private Sub InitClass()
      Messager.Caption = "LEADTOOLS VB Annotations Demo"
      Text = Messager.Caption

      _codecs = New RasterCodecs()
      _annCodecs = New AnnCodecs()
      Dim options As New AnnDeserializeOptions()

      AddHandler options.DeserializeObject, AddressOf DeserializeOptions_DeserializeObject

      _annCodecs.DeserializeOptions = options

      _paintProperties = RasterPaintProperties.Default
      _paintProperties.PaintDisplayMode = _paintProperties.PaintDisplayMode Or RasterPaintDisplayModeFlags.ScaleToGray

      Try

         If PrinterSettings.InstalledPrinters IsNot Nothing AndAlso PrinterSettings.InstalledPrinters.Count > 0 Then
            _printDocument = New PrintDocument()
            AddHandler _printDocument.BeginPrint, New PrintEventHandler(AddressOf _printDocument_BeginPrint)
            AddHandler _printDocument.PrintPage, New PrintPageEventHandler(AddressOf _printDocument_PrintPage)
            AddHandler _printDocument.EndPrint, New PrintEventHandler(AddressOf _printDocument_EndPrint)
         Else
            _printDocument = Nothing
         End If
      Catch generatedExceptionName As Exception
         _printDocument = Nothing
      End Try

      _redactionMessage = True

      InitToolbar()
      InitAutomation()

      'DoResize();
      LoadImage(True)

      UpdateControls()
      UpdateCaption()
   End Sub

   Private Sub InitToolbar()
      Dim btmp As New Bitmap([GetType](), "MainToolbar.bmp")
      btmp.MakeTransparent(btmp.GetPixel(0, 0))

      _toolBarMain.ImageList = New ImageList()
      _toolBarMain.ImageList.ImageSize = New Size(btmp.Height, btmp.Height)
      _toolBarMain.ImageList.Images.AddStrip(btmp)
   End Sub

   Private Function CreateRichTextAutomationObject() As AnnAutomationObject
      Dim automationObj As New AnnAutomationObject()
      Dim annRichTextObject As New AnnRichTextObject()

      automationObj.Id = annRichTextObject.Id
      automationObj.Name = annRichTextObject.FriendlyName
      automationObj.DrawDesignerType = GetType(AnnRichDrawDesigner)
      automationObj.EditDesignerType = GetType(AnnRichTextEditDesigner)
      automationObj.ObjectTemplate = annRichTextObject
      automationObj.RunDesignerType = GetType(AnnRunDesigner)

      Return automationObj

   End Function

   Private Sub InitAutomation()
      _automationManager = New AnnAutomationManager()

      _automationManager.RedactionRealizePassword = String.Empty
      _automationManager.EditContentAfterDraw = True
      _automationManager.EditTextAfterDraw = True
      _automationManager.RestrictDesigners = True

      _automationManager.CreateDefaultObjects()

      Dim annRichTextObjectRenderer As New AnnRichTextObjectRenderer()
      _automationManager.Objects.Add(CreateRichTextAutomationObject())

      _managerHelper = New AutomationManagerHelper(_automationManager)

      Dim annNoteObjectRenderer As IAnnObjectRenderer = _automationManager.RenderingEngine.Renderers(AnnObject.NoteObjectId)
      annRichTextObjectRenderer.LocationsThumbStyle = annNoteObjectRenderer.LocationsThumbStyle
      annRichTextObjectRenderer.RotateCenterThumbStyle = annNoteObjectRenderer.RotateCenterThumbStyle
      annRichTextObjectRenderer.RotateGripperThumbStyle = annNoteObjectRenderer.RotateGripperThumbStyle

      _automationManager.RenderingEngine.Renderers(AnnObject.RichTextObjectId) = annRichTextObjectRenderer

      _managerHelper.CreateToolBar()
      Controls.Add(_managerHelper.ToolBar)

      _managerHelper.ToolBar.Dock = DockStyle.Right
      _managerHelper.ToolBar.BringToFront()
      _managerHelper.ToolBar.AutoSize = False
      _managerHelper.ToolBar.Appearance = ToolBarAppearance.Flat

      AddHandler _automationManager.UserModeChanged, AddressOf _automationManager_UserModeChanged
   End Sub

   Public ReadOnly Property IsEditingText() As Boolean
      Get
         Dim isEditingText__1 As Boolean = False
         If ActiveAnnotationsForm IsNot Nothing Then
            isEditingText__1 = ActiveAnnotationsForm.IsEditingText
         End If

         Return isEditingText__1
      End Get
   End Property

   Public Sub UpdateControls()
      Dim annForm As AnnotationsForm = ActiveAnnotationsForm

      If annForm Is Nothing Then
         _menuItemFileSaveAnnotations.Enabled = False
         _menuItemFileSaveAnnotations.Visible = False
         _menuItemFileSaveAs.Enabled = False
         _menuItemFileSaveAs.Visible = False
         _menuItemFileSaveAsTiff.Enabled = False
         _menuItemFileSaveAsTiff.Visible = False
         _menuItemFileSaveAsWang.Enabled = False
         _menuItemFileSaveAsWang.Visible = False
         _menuItemLoadAnnPackage.Enabled = False
         _menuItemLoadAnnPackage.Visible = False
         _menuItemFileLoadBateStamp.Enabled = False
         _menuItemFileLoadBateStamp.Visible = False
         _tbbSave.Enabled = False
         _tbbSave.Visible = False

         _menuItemFilePrint.Enabled = False
         _menuItemFilePrint.Visible = False
         _menuItemFilePrintPreview.Enabled = False
         _menuItemFilePrintPreview.Visible = False
         _menuItemFileSep2.Visible = False

         _menuItemEdit.Enabled = False
         _menuItemEdit.Visible = False

         _menuItemView.Enabled = False
         _menuItemView.Visible = False

         _menuItemAnnotations.Enabled = False
         _menuItemAnnotations.Visible = False

         _menuItemWindow.Enabled = False
         _menuItemWindow.Visible = False

         _tbbSep1.Visible = False
         _tbbCopy.Visible = False
         _tbbPaste.Visible = False
         _tbbDelete.Visible = False
         _tbbSep2.Visible = False
         _tbbUndo.Visible = False
         _tbbRedo.Visible = False
         _tbbSep3.Visible = False
         _tbbZoomIn.Visible = False
         _tbbZoomOut.Visible = False
         _tbbNoZoom.Visible = False
         _tbbSep4.Visible = False
         _tbbRotate.Visible = False
         _tbbGroup.Visible = False
         _tbbUngroup.Visible = False
         _tbbProperties.Visible = False
         _tbbSep5.Visible = False
         _tbbBringToFront.Visible = False
         _tbbSendToBack.Visible = False
         _tbbBringToFirst.Visible = False
         _tbbSendToLast.Visible = False
         _tbbSep6.Visible = False
         _tbbAlignLefts.Visible = False
         _tbbAlignCenters.Visible = False
         _tbbAlignRights.Visible = False
         _tbbAlignTops.Visible = False
         _tbbAlignMiddles.Visible = False
         _tbbAlignBottoms.Visible = False
         _tbbMakeSameWidth.Visible = False
         _tbbMakeSameHeight.Visible = False
         _tbbMakeSameSize.Visible = False
         _tbbSep7.Visible = False
         _tbbRunDesign.Visible = False
         _tbbRunDesign.Visible = False
         _managerHelper.ToolBar.Visible = False
      Else
         Dim automation As AnnAutomation = annForm.Automation
         Dim viewer As ImageViewer = annForm.Viewer

         Dim designMode As Boolean = _automationManager.UserMode = AnnUserMode.Design
         Dim isPolyRulerObject As Boolean = TypeOf automation.CurrentEditObject Is AnnPolyRulerObject

         _menuItemFileSaveAnnotations.Enabled = True
         _menuItemFileSaveAnnotations.Visible = True
         _menuItemFileSaveAs.Enabled = True
         _menuItemFileSaveAs.Visible = True
         _menuItemFileSaveAsTiff.Enabled = True
         _menuItemFileSaveAsTiff.Visible = True
         _menuItemFileSaveAsWang.Enabled = True
         _menuItemFileSaveAsWang.Visible = True
         _menuItemLoadAnnPackage.Enabled = True
         _menuItemLoadAnnPackage.Visible = True
         _menuItemFileLoadBateStamp.Enabled = True
         _menuItemFileLoadBateStamp.Visible = True
         _tbbSave.Enabled = True
         _tbbSave.Visible = True

         _menuItemFilePrint.Enabled = _printDocument IsNot Nothing
         _menuItemFilePrint.Visible = _printDocument IsNot Nothing
         _menuItemFilePrintPreview.Enabled = _printDocument IsNot Nothing AndAlso DialogUtilities.CanRunPrintPreview
         _menuItemFilePrintPreview.Visible = _printDocument IsNot Nothing AndAlso DialogUtilities.CanRunPrintPreview
         _menuItemFileSep2.Visible = _printDocument IsNot Nothing

         _menuItemEdit.Enabled = designMode AndAlso Not IsEditingText
         _menuItemEdit.Visible = designMode AndAlso Not IsEditingText
         _menuItemEditUndo.Enabled = automation.CanUndo AndAlso Not IsEditingText
         _menuItemEditRedo.Enabled = automation.CanRedo AndAlso Not IsEditingText

         _menuItemEditCut.Enabled = automation.CanCopy AndAlso Not IsEditingText
         _menuItemEditCopy.Enabled = automation.CanCopy AndAlso Not IsEditingText
         _menuItemEditPaste.Enabled = automation.CanPaste AndAlso Not IsEditingText
         _menuItemEditDelete.Enabled = automation.CanDeleteObjects AndAlso Not IsEditingText
         _menuItemEditSelectAll.Enabled = automation.CanSelectObjects AndAlso Not IsEditingText
         _menuItemEditSelectNone.Enabled = automation.Container.SelectionObject.SelectedObjects.Count > 0
         _menuItemEditDuplicate.Enabled = designMode AndAlso (automation.CurrentEditObject IsNot Nothing)

         _menuItemView.Enabled = True
         _menuItemView.Visible = True

         _menuItemViewSizeModeNormal.Checked = (viewer.SizeMode = ControlSizeMode.None)
         _menuItemViewSizeModeStretch.Checked = (viewer.SizeMode = ControlSizeMode.Stretch)
         _menuItemViewSizeModeFitAlways.Checked = (viewer.SizeMode = ControlSizeMode.FitAlways)
         _menuItemViewSizeModeFitWidth.Checked = (viewer.SizeMode = ControlSizeMode.FitWidth)
         _menuItemViewSizeModeFit.Checked = (viewer.SizeMode = ControlSizeMode.Fit)

         _menuItemViewZoom.Enabled = True
         _menuItemViewUseDpi.Checked = viewer.UseDpi

         _menuItemAnnotations.Enabled = True
         _menuItemAnnotations.Visible = True

         _menuItemAnnotationsRedactionObjectsRealize.Enabled = automation.CanRealizeRedaction
         _menuItemAnnotationsRedactionObjectsRestore.Enabled = automation.CanRestoreRedaction
         _menuItemAnnotationsRedactionObjectsRealizeAll.Enabled = automation.CanRealizeAllRedactions
         _menuItemAnnotationsRedactionObjectsRestoreAll.Enabled = automation.CanRestoreAllRedactions

         _menuItemAnnotationsEncryptObjectsApplyAllEncryptors.Enabled = automation.CanApplyAllEncryptors
         _menuItemAnnotationsEncryptObjectsApplyAllDecryptors.Enabled = automation.CanApplyAllDecryptors
         _menuItemAnnotationsEncryptObjectsApplyEncryptor.Enabled = automation.CanApplyEncryptor
         _menuItemAnnotationsEncryptObjectsApplyDecryptor.Enabled = automation.CanApplyDecryptor

         _menuItemAnnotationsUserModeRun.Checked = Not designMode
         _menuItemAnnotationsUserModeDesign.Checked = designMode
         _menuItemAnnotationsCurrentObject.Enabled = designMode

         _menuItemAnnotationsAlign.Enabled = designMode

         _menuItemAnnotationsAlignSendToBack.Enabled = (automation.CanSendToBack)
         _menuItemAnnotationsAlignSendToLast.Enabled = (automation.CanSendToLast)
         _menuItemAnnotationsAlignBringToFront.Enabled = (automation.CanBringToFront)
         _menuItemAnnotationsAlignBringToFirst.Enabled = (automation.CanBringToFirst)

         _menuItemAnnotationsAlignSep1.Visible = (automation.Manager.EnableObjectsAlignment)
         _menuItemAnnotationsAlignObjectsAlignmentLefts.Visible = (automation.Manager.EnableObjectsAlignment)
         _menuItemAnnotationsAlignObjectsAlignmentLefts.Enabled = (automation.CanAlign)
         _menuItemAnnotationsAlignObjectsAlignmentCenters.Visible = (automation.Manager.EnableObjectsAlignment)
         _menuItemAnnotationsAlignObjectsAlignmentCenters.Enabled = (automation.CanAlign)
         _menuItemAnnotationsAlignObjectsAlignmentRights.Visible = (automation.Manager.EnableObjectsAlignment)
         _menuItemAnnotationsAlignObjectsAlignmentRights.Enabled = (automation.CanAlign)
         _menuItemAnnotationsAlignSep2.Visible = (automation.Manager.EnableObjectsAlignment)
         _menuItemAnnotationsAlignObjectsAlignmentTops.Visible = (automation.Manager.EnableObjectsAlignment)
         _menuItemAnnotationsAlignObjectsAlignmentTops.Enabled = (automation.CanAlign)
         _menuItemAnnotationsAlignObjectsAlignmentMiddles.Visible = (automation.Manager.EnableObjectsAlignment)
         _menuItemAnnotationsAlignObjectsAlignmentMiddles.Enabled = (automation.CanAlign)
         _menuItemAnnotationsAlignObjectsAlignmentBottoms.Visible = (automation.Manager.EnableObjectsAlignment)
         _menuItemAnnotationsAlignObjectsAlignmentBottoms.Enabled = (automation.CanAlign)
         _menuItemAnnotationsAlignSep3.Visible = (automation.Manager.EnableObjectsAlignment)
         _menuItemAnnotationsAlignObjectsMakeSameWidth.Visible = (automation.Manager.EnableObjectsAlignment)
         _menuItemAnnotationsAlignObjectsMakeSameWidth.Enabled = (automation.CanAlign)
         _menuItemAnnotationsAlignObjectsMakeSameHeight.Visible = (automation.Manager.EnableObjectsAlignment)
         _menuItemAnnotationsAlignObjectsMakeSameHeight.Enabled = (automation.CanAlign)
         _menuItemAnnotationsAlignObjectsMakeSameSize.Visible = (automation.Manager.EnableObjectsAlignment)
         _menuItemAnnotationsAlignObjectsMakeSameSize.Enabled = (automation.CanAlign)

         _menuItemAnnotationsFlip.Enabled = designMode
         _menuItemAnnotationsFlipHorizontal.Enabled = (automation.CanFlip)
         _menuItemAnnotationsFlipVertical.Enabled = (automation.CanFlip)

         _menuItemAnnotationsGroup.Enabled = designMode
         _menuItemAnnotationsGroupGroupSelectedObjects.Enabled = automation.CanGroup
         _menuItemAnnotationsGroupUngroup.Enabled = automation.CanUngroup
         _menuItemAnnotationsPasswordLock.Enabled = automation.CanLock
         _menuItemAnnotationsPasswordUnlock.Enabled = automation.CanUnlock

         _menuItemAnnotationsResetRotatePoints.Enabled = designMode AndAlso automation.CanResetRotatePoints
         _menuItemAnnotationsAntiAlias.Checked = _antiAlias
         _menuItemAnnotationsBehaviorUseRotateThumbs.Checked = _automationManager.Objects.Count > 0 AndAlso _automationManager.Objects(0).UseRotateThumbs
         _menuItemAnnotationsBehaviorRestrictDesigners.Checked = _automationManager.RestrictDesigners
         _menuItemAnnotationsBehaviorEnableObjectsAlignment.Checked = _automationManager.EnableObjectsAlignment
         _menuItemAnnotationsBehaviorMaintainAspectRatio.Checked = _automationManager.MaintainAspectRatio
         _menuItemAnnotationsProperties.Enabled = designMode AndAlso automation.CanShowObjectProperties
         _menuItemCalibrate.Enabled = designMode AndAlso isPolyRulerObject
         _menuItemAnnotationsBehaviorEnableToolTip.Checked = _automationManager.EnableToolTip

         _menuItemWindow.Enabled = True
         _menuItemWindow.Visible = True

         _tbbSep1.Visible = True
         _tbbCopy.Visible = True
         _tbbCopy.Enabled = _menuItemEditCopy.Enabled AndAlso designMode
         _tbbPaste.Visible = True
         _tbbPaste.Enabled = _menuItemEditPaste.Enabled AndAlso designMode
         _tbbDelete.Visible = True
         _tbbDelete.Enabled = _menuItemEditDelete.Enabled AndAlso designMode
         _tbbSep2.Visible = True
         _tbbUndo.Visible = True
         _tbbUndo.Enabled = automation.CanUndo AndAlso designMode
         _tbbRedo.Visible = True
         _tbbRedo.Enabled = automation.CanRedo AndAlso designMode
         _tbbSep3.Visible = True

         _tbbZoomIn.Visible = True
         _tbbZoomOut.Visible = True
         _tbbNoZoom.Visible = True

         _tbbZoomIn.Enabled = _menuItemViewZoom.Enabled
         _tbbZoomOut.Enabled = _menuItemViewZoom.Enabled
         _tbbNoZoom.Enabled = _menuItemViewZoom.Enabled

         _tbbSep4.Visible = True
         _tbbRotate.Visible = True
         _tbbGroup.Visible = True
         _tbbGroup.Enabled = _menuItemAnnotationsGroupGroupSelectedObjects.Enabled AndAlso designMode
         _tbbUngroup.Visible = True
         _tbbUngroup.Enabled = _menuItemAnnotationsGroupUngroup.Enabled AndAlso designMode
         _tbbProperties.Visible = True
         _tbbProperties.Enabled = _menuItemAnnotationsProperties.Enabled AndAlso designMode
         _tbbSep5.Visible = True
         _tbbBringToFront.Visible = True
         _tbbBringToFront.Enabled = _menuItemAnnotationsAlignBringToFront.Enabled AndAlso designMode
         _tbbSendToBack.Visible = True
         _tbbSendToBack.Enabled = _menuItemAnnotationsAlignSendToBack.Enabled AndAlso designMode
         _tbbBringToFirst.Visible = True
         _tbbBringToFirst.Enabled = _menuItemAnnotationsAlignBringToFirst.Enabled AndAlso designMode
         _tbbSendToLast.Visible = True
         _tbbSendToLast.Enabled = _menuItemAnnotationsAlignSendToLast.Enabled AndAlso designMode
         _tbbSep6.Visible = True
         _tbbAlignLefts.Visible = automation.Manager.EnableObjectsAlignment
         _tbbAlignLefts.Enabled = _menuItemAnnotationsAlignObjectsAlignmentLefts.Enabled AndAlso designMode
         _tbbAlignCenters.Visible = automation.Manager.EnableObjectsAlignment
         _tbbAlignCenters.Enabled = _menuItemAnnotationsAlignObjectsAlignmentCenters.Enabled AndAlso designMode
         _tbbAlignRights.Visible = automation.Manager.EnableObjectsAlignment
         _tbbAlignRights.Enabled = _menuItemAnnotationsAlignObjectsAlignmentRights.Enabled AndAlso designMode
         _tbbAlignTops.Visible = automation.Manager.EnableObjectsAlignment
         _tbbAlignTops.Enabled = _menuItemAnnotationsAlignObjectsAlignmentTops.Enabled AndAlso designMode
         _tbbAlignMiddles.Visible = automation.Manager.EnableObjectsAlignment
         _tbbAlignMiddles.Enabled = _menuItemAnnotationsAlignObjectsAlignmentMiddles.Enabled AndAlso designMode
         _tbbAlignBottoms.Visible = automation.Manager.EnableObjectsAlignment
         _tbbAlignBottoms.Enabled = _menuItemAnnotationsAlignObjectsAlignmentBottoms.Enabled AndAlso designMode
         _tbbMakeSameWidth.Visible = automation.Manager.EnableObjectsAlignment
         _tbbMakeSameWidth.Enabled = _menuItemAnnotationsAlignObjectsMakeSameWidth.Enabled AndAlso designMode
         _tbbMakeSameHeight.Visible = automation.Manager.EnableObjectsAlignment
         _tbbMakeSameHeight.Enabled = _menuItemAnnotationsAlignObjectsMakeSameHeight.Enabled AndAlso designMode
         _tbbMakeSameSize.Visible = automation.Manager.EnableObjectsAlignment
         _tbbMakeSameSize.Enabled = _menuItemAnnotationsAlignObjectsMakeSameSize.Enabled AndAlso designMode
         _tbbSep7.Visible = automation.Manager.EnableObjectsAlignment
         _tbbRunDesign.Visible = True
         _tbbRunDesign.Enabled = True

         If _menuItemAnnotationsUserModeRun.Checked Then
            _tbbRunDesign.ToolTipText = "Switch to Design Mode"
            _tbbRunDesign.ImageIndex = _toolBarMain.ImageList.Images.Count - 1
         Else
            _tbbRunDesign.ToolTipText = "Switch to Run Mode"
            _tbbRunDesign.ImageIndex = _toolBarMain.ImageList.Images.Count - 2
         End If

         If designMode AndAlso Not _managerHelper.ToolBar.Visible Then
            _managerHelper.ToolBar.Visible = True
         End If

         _menuItemViewInteractiveModeNone.Checked = annForm.AutomationInteractiveMode.IsEnabled
         _menuItemViewInteractiveModeMagnifyGlass.Checked = annForm.MagnifyGlassInteractiveMode.IsEnabled
         _menuItemViewInteractiveModePan.Checked = annForm.PanZoomInteractiveMode.IsEnabled
      End If
   End Sub

   Private Sub CleanUp()
      _managerHelper.Dispose()
   End Sub

   Private ReadOnly Property ActiveAnnotationsForm() As AnnotationsForm
      Get
         Return TryCast(ActiveMdiChild, AnnotationsForm)
      End Get
   End Property

   Protected Overrides Sub OnSizeChanged(e As EventArgs)
      If AutomationManager IsNot Nothing AndAlso _managerHelper.ToolBar IsNot Nothing Then
         DoResize()
      End If

      MyBase.OnSizeChanged(e)
   End Sub

   Private Sub DoResize()
      SuspendLayout()
      _managerHelper.ToolBar.SuspendLayout()

      _managerHelper.ToolBar.Height = ClientSize.Height

      Dim width As Integer = 0
      Dim height As Integer = 0
      For i As Integer = 0 To _managerHelper.ToolBar.Buttons.Count - 1
         If i = 0 Then
            width = _managerHelper.ToolBar.Buttons(i).Rectangle.Width
            height = _managerHelper.ToolBar.Buttons(i).Rectangle.Height
         Else
            width = Math.Max(width, _managerHelper.ToolBar.Buttons(i).Rectangle.Width)
            height = Math.Max(height, _managerHelper.ToolBar.Buttons(i).Rectangle.Height)
         End If
      Next

      If width > 0 AndAlso height > 0 Then
         Dim rows As Integer = CInt(_managerHelper.ToolBar.Height / height)
         If rows > 0 Then
            Dim columns As Integer = CInt(_managerHelper.ToolBar.Buttons.Count / rows)
            If (_managerHelper.ToolBar.Buttons.Count Mod rows) = 0 Then
               columns += 1
            End If

            _managerHelper.ToolBar.Width = columns * width
         End If
      End If

      _managerHelper.ToolBar.ResumeLayout()
      ResumeLayout()
   End Sub

   Private Sub MainForm_MdiChildActivate(sender As Object, e As EventArgs) Handles Me.MdiChildActivate
      If ActiveMdiChild IsNot Nothing Then
         Dim annForm As AnnotationsForm = TryCast(ActiveMdiChild, AnnotationsForm)
         Dim automation As AnnAutomation = annForm.Automation
         If Not automation.Active Then
            automation.Active = True
         End If
      End If

      UpdateControls()
      DoResize()
   End Sub

   Private Sub _menuItemFileOpen_Click(sender As Object, e As EventArgs) Handles _menuItemFileOpen.Click
      LoadImage(False)
   End Sub

   Private Sub LoadImage(loadDefaultImage As Boolean)
      Dim loader As New ImageFileLoader()
      Dim bLoaded As Boolean = False
      If String.IsNullOrEmpty(_openInitialPath) Then
         loader.OpenDialogInitialPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
      Else
         loader.OpenDialogInitialPath = _openInitialPath
      End If


      Try
         loader.LoadOnlyOnePage = True

         Dim defaultImageFileName As String = Nothing

#If LT_CLICKONCE Then
				 defaultImageFileName = "clean.tif"
#Else
         defaultImageFileName = Path.Combine(DemosGlobal.ImagesFolder, "ocr1.tif")
#End If

         If loadDefaultImage Then
            If File.Exists(defaultImageFileName) Then
               bLoaded = loader.Load(Me, defaultImageFileName, _codecs, 1, 1)
            End If
         Else
            bLoaded = loader.Load(Me, _codecs, True) > 0
         End If

         If bLoaded Then
            _openInitialPath = Path.GetDirectoryName(loader.FileName)
            loader.Image.ChangeViewPerspective(RasterViewPerspective.TopLeft)
            NewAnnotationForm(loader.Image, loader.FileName, 1)
         End If
      Catch ex As Exception
         If TypeOf ex Is TargetInvocationException AndAlso ex.InnerException IsNot Nothing Then
            Messager.ShowFileOpenError(Me, loader.FileName, ex.InnerException)
         Else
            Messager.ShowFileOpenError(Me, loader.FileName, ex)
         End If
      End Try
   End Sub


   Private Sub NewAnnotationForm(image As RasterImage, fileName As String, pageNumber As Integer)
      Dim child As New AnnotationsForm()
      child.MdiParent = Me
      child.Initialize(_paintProperties, image, fileName, pageNumber)
      child.WindowState = FormWindowState.Maximized
      child.Show()
      child.Viewer.Dock = DockStyle.Fill
      child.UpdateAntiAlias(_antiAlias)
      LoadAnnotations(fileName, child.Automation.Container, pageNumber, child.AutomationControl)
      AddHandler child.AutomationTextAdded, AddressOf child_AutomationTextAdded
      AddHandler child.AutomationTextRemoved, AddressOf child_AutomationTextRemoved
      AddHandler child.FormClosed, AddressOf child_FormClosed
   End Sub

   Private Sub child_FormClosed(sender As Object, e As FormClosedEventArgs)
      Dim child As AnnotationsForm = TryCast(sender, AnnotationsForm)
      RemoveHandler child.FormClosed, AddressOf child_FormClosed
      RemoveHandler child.AutomationTextAdded, AddressOf child_AutomationTextAdded
      RemoveHandler child.AutomationTextRemoved, AddressOf child_AutomationTextRemoved
   End Sub

   Private Sub child_AutomationTextAdded(sender As Object, e As EventArgs)
      'when automation text box is active will leave theses shortcuts to the text box
      Me._menuItemEditUndo.Shortcut = Shortcut.None
      Me._menuItemEditRedo.Shortcut = Shortcut.None
      Me._menuItemEditCut.Shortcut = Shortcut.None
      Me._menuItemEditCopy.Shortcut = Shortcut.None
      Me._menuItemEditPaste.Shortcut = Shortcut.None
      Me._menuItemEditDelete.Shortcut = Shortcut.None
      Me._menuItemEditSelectAll.Shortcut = Shortcut.None
   End Sub

   Private Sub child_AutomationTextRemoved(sender As Object, e As EventArgs)
      'restore shortcuts
      Me._menuItemEditUndo.Shortcut = Shortcut.CtrlZ
      Me._menuItemEditRedo.Shortcut = Shortcut.CtrlY
      Me._menuItemEditCut.Shortcut = Shortcut.CtrlX
      Me._menuItemEditCopy.Shortcut = Shortcut.CtrlC
      Me._menuItemEditPaste.Shortcut = Shortcut.CtrlV
      Me._menuItemEditDelete.Shortcut = Shortcut.Del
      Me._menuItemEditSelectAll.Shortcut = Shortcut.CtrlA
      Me.ActiveAnnotationsForm.Automation.Invalidate(LeadRectD.Empty)
   End Sub

   Private Sub _menuItemFileSave_Click(sender As Object, e As EventArgs) Handles _menuItemFileSaveAnnotations.Click
      Try
         Dim activeForm As AnnotationsForm = ActiveAnnotationsForm
         Save(activeForm.Text, False, activeForm.Viewer.Image.OriginalFormat, False, False)
      Catch ex As Exception
         If TypeOf ex Is TargetInvocationException AndAlso ex.InnerException IsNot Nothing Then
            Messager.ShowFileSaveError(Me, ActiveAnnotationsForm.Text, ex.InnerException)
         Else
            Messager.ShowFileSaveError(Me, ActiveAnnotationsForm.Text, ex)
         End If
      End Try
   End Sub

   Private Sub _menuItemFileSaveAs_Click(sender As Object, e As EventArgs) Handles _menuItemFileSaveAs.Click
      Dim saver As New ImageFileSaver()

      Try
         Dim activeForm As AnnotationsForm = ActiveAnnotationsForm

         If saver.Save(Me, _codecs, activeForm.Viewer.Image) Then
            Save(saver.FileName, False, saver.Format, False, False)
         End If
      Catch ex As Exception
         If TypeOf ex Is TargetInvocationException AndAlso ex.InnerException IsNot Nothing Then
            Messager.ShowFileSaveError(Me, saver.FileName, ex.InnerException)
         Else
            Messager.ShowFileSaveError(Me, saver.FileName, ex)
         End If
      End Try
   End Sub

   Private Sub SaveAsTag_Click(sender As Object, e As EventArgs) Handles _menuItemFileSaveAsTiff.Click, _menuItemFileSaveAsWang.Click
      Dim saveAsWang As Boolean = (sender Is _menuItemFileSaveAsWang)
      Using saveDialog As New SaveFileDialog()
         saveDialog.Filter = "Tiff files (*.tif)|*.tif"
         saveDialog.FilterIndex = 1

         If saveDialog.ShowDialog(Me) = DialogResult.OK Then
            Dim fileName As String = saveDialog.FileName
            Try
               Dim activeForm As AnnotationsForm = ActiveAnnotationsForm

               If activeForm.Viewer.Image.BitsPerPixel = 1 Then
                  Save(fileName, True, RasterImageFormat.CcittGroup4, True, saveAsWang)
               Else
                  Save(fileName, True, RasterImageFormat.TifLzw, True, saveAsWang)
               End If
            Catch ex As Exception
               If TypeOf ex Is TargetInvocationException AndAlso ex.InnerException IsNot Nothing Then
                  Messager.ShowFileSaveError(Me, fileName, ex.InnerException)
               Else
                  Messager.ShowFileSaveError(Me, fileName, ex)
               End If
            End Try
         End If
      End Using
   End Sub

   Private Sub _menuItemFilePrint_Click(sender As Object, e As EventArgs) Handles _menuItemFilePrint.Click
      If _printDocument IsNot Nothing Then
         Try
            Dim image As RasterImage = ActiveAnnotationsForm.Viewer.Image
            _printDocument.PrinterSettings.MinimumPage = 1
            _printDocument.PrinterSettings.MaximumPage = image.PageCount
            _printDocument.PrinterSettings.FromPage = 1
            _printDocument.PrinterSettings.ToPage = image.PageCount

            _printDocument.Print()
         Catch
         End Try
      End If
   End Sub

   Private Sub _menuItemFilePrintPreview_Click(sender As Object, e As EventArgs) Handles _menuItemFilePrintPreview.Click
      If _printDocument IsNot Nothing Then
         Try
            Using dlg As New PrintPreviewDialog()
               Dim image As RasterImage = ActiveAnnotationsForm.Viewer.Image
               _printDocument.PrinterSettings.MinimumPage = 1
               _printDocument.PrinterSettings.MaximumPage = image.PageCount
               _printDocument.PrinterSettings.FromPage = 1
               _printDocument.PrinterSettings.ToPage = image.PageCount

               dlg.Document = _printDocument
               dlg.WindowState = FormWindowState.Maximized
               dlg.ShowDialog(Me)
            End Using
         Catch
         End Try
      End If
   End Sub

   Private Sub _printDocument_BeginPrint(sender As Object, e As PrintEventArgs)
      ' Our document has only 1 page so there is no need to reset the print page number
   End Sub

   Private Sub _printDocument_PrintPage(sender As Object, e As PrintPageEventArgs)
      Dim form As AnnotationsForm = ActiveAnnotationsForm
      Dim image As RasterImage = form.Viewer.Image
      Dim g As Graphics = e.Graphics

      Dim pageBounds As Rectangle = e.PageBounds
      Dim bounds As LeadRect = LeadRect.Create(pageBounds.X, pageBounds.Y, pageBounds.Width, pageBounds.Height)

      Dim destRect As LeadRect = RasterImage.CalculatePaintModeRectangle(image.ImageWidth, image.ImageHeight, bounds, RasterPaintSizeMode.Fit, RasterPaintAlignMode.Near, RasterPaintAlignMode.Near)

      RasterImagePainter.Paint(image, g, destRect, RasterPaintProperties.Default)

      For Each container As AnnContainer In ActiveAnnotationsForm.Automation.Containers
         BurnContainer(container, g, destRect.ToLeadRectD())
      Next

      ' Inform the printer whether we have no more pages to print
      e.HasMorePages = False
   End Sub

   Private Sub BurnContainer(container As AnnContainer, g As Graphics, destRect As LeadRectD)
      If container Is Nothing OrElse destRect.IsEmpty Then
         Return
      End If

      Dim engine As New AnnWinFormsRenderingEngine(container, g)
      engine.Resources = _automationManager.Resources
      engine.Renderers = _automationManager.RenderingEngine.Renderers

      Dim viewer As ImageViewer = ActiveAnnotationsForm.Viewer

      Dim mapper As AnnContainerMapper = container.Mapper
      container.Mapper = mapper.Clone()
      container.Mapper.MapResolutions(96, 96, 96, 96)
      engine.BurnToRectWithDpi(container.Mapper.RectToContainerCoordinates(destRect), 96, 96, 96, 96)
      container.Mapper = mapper

   End Sub

   Private Sub _printDocument_EndPrint(sender As Object, e As PrintEventArgs)
      ' Nothing to do here
   End Sub

   Private Sub _menuItemFileExit_Click(sender As Object, e As EventArgs) Handles _menuItemFileExit.Click
      Close()
   End Sub

   Private Sub _menuItemEdit_Popup(sender As Object, e As EventArgs) Handles _menuItemEdit.Popup
      _menuItemEditPaste.Enabled = ActiveAnnotationsForm.Automation.CanPaste
   End Sub

   Private Sub _menuItemEditUndoRedo_Click(sender As Object, e As EventArgs) Handles _menuItemEditUndo.Click, _menuItemEditRedo.Click
      Try
         Dim activeForm As AnnotationsForm = ActiveAnnotationsForm

         If sender Is _menuItemEditUndo Then
            activeForm.Automation.Undo()
         ElseIf sender Is _menuItemEditRedo Then
            activeForm.Automation.Redo()
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateControls()
      End Try
   End Sub

   Private Sub _menuItemEditClipboard_Click(sender As Object, e As EventArgs) Handles _menuItemEditCut.Click, _menuItemEditCopy.Click, _menuItemEditPaste.Click, _menuItemEditDelete.Click
      Try
         Dim activeForm As AnnotationsForm = ActiveAnnotationsForm

         If sender Is _menuItemEditCut Then
            activeForm.Automation.Copy()
            activeForm.Automation.DeleteSelectedObjects()
         ElseIf sender Is _menuItemEditCopy Then
            activeForm.Automation.Copy()
         ElseIf sender Is _menuItemEditPaste Then
            activeForm.Automation.Paste()
         ElseIf sender Is _menuItemEditDelete Then
            activeForm.Automation.DeleteSelectedObjects()
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateControls()
      End Try
   End Sub

   Private Sub _menuItemEditSelect_Click(sender As Object, e As EventArgs) Handles _menuItemEditSelectAll.Click, _menuItemEditSelectNone.Click
      Dim activeForm As AnnotationsForm = ActiveAnnotationsForm

      If sender Is _menuItemEditSelectAll Then
         activeForm.Automation.SelectObjects(activeForm.Automation.Container.Children)
      ElseIf sender Is _menuItemEditSelectNone Then
         activeForm.Automation.SelectObjects(Nothing)
      End If

      activeForm.Viewer.Invalidate()
      UpdateControls()
   End Sub

   Private Sub _toolBarMain_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles _toolBarMain.ButtonClick
      If e.Button Is _tbbOpen Then
         _menuItemFileOpen.PerformClick()
      ElseIf e.Button Is _tbbSave Then
         _menuItemFileSaveAnnotations.PerformClick()
      ElseIf e.Button Is _tbbCopy Then
         _menuItemEditCopy.PerformClick()
      ElseIf e.Button Is _tbbPaste Then
         _menuItemEditPaste.PerformClick()
      ElseIf e.Button Is _tbbDelete Then
         _menuItemEditDelete.PerformClick()
      ElseIf e.Button Is _tbbUndo Then
         _menuItemEditUndo.PerformClick()
      ElseIf e.Button Is _tbbRedo Then
         _menuItemEditRedo.PerformClick()
      ElseIf e.Button Is _tbbZoomIn Then
         _menuItemViewZoomIn.PerformClick()
      ElseIf e.Button Is _tbbZoomOut Then
         _menuItemViewZoomOut.PerformClick()
      ElseIf e.Button Is _tbbNoZoom Then
         _menuItemViewZoomNormal.PerformClick()
      ElseIf e.Button Is _tbbGroup Then
         _menuItemAnnotationsGroupGroupSelectedObjects.PerformClick()
      ElseIf e.Button Is _tbbUngroup Then
         _menuItemAnnotationsGroupUngroup.PerformClick()
      ElseIf e.Button Is _tbbProperties Then
         _menuItemAnnotationsProperties.PerformClick()
      ElseIf e.Button Is _tbbBringToFront Then
         _menuItemAnnotationsAlignBringToFront.PerformClick()
      ElseIf e.Button Is _tbbSendToBack Then
         _menuItemAnnotationsAlignSendToBack.PerformClick()
      ElseIf e.Button Is _tbbBringToFirst Then
         _menuItemAnnotationsAlignBringToFirst.PerformClick()
      ElseIf e.Button Is _tbbSendToLast Then
         _menuItemAnnotationsAlignSendToLast.PerformClick()
      ElseIf e.Button Is _tbbAlignLefts Then
         _menuItemAnnotationsAlignObjectsAlignmentLefts.PerformClick()
      ElseIf e.Button Is _tbbAlignCenters Then
         _menuItemAnnotationsAlignObjectsAlignmentCenters.PerformClick()
      ElseIf e.Button Is _tbbAlignRights Then
         _menuItemAnnotationsAlignObjectsAlignmentRights.PerformClick()
      ElseIf e.Button Is _tbbAlignTops Then
         _menuItemAnnotationsAlignObjectsAlignmentTops.PerformClick()
      ElseIf e.Button Is _tbbAlignMiddles Then
         _menuItemAnnotationsAlignObjectsAlignmentMiddles.PerformClick()
      ElseIf e.Button Is _tbbAlignBottoms Then
         _menuItemAnnotationsAlignObjectsAlignmentBottoms.PerformClick()
      ElseIf e.Button Is _tbbMakeSameWidth Then
         _menuItemAnnotationsAlignObjectsMakeSameWidth.PerformClick()
      ElseIf e.Button Is _tbbMakeSameHeight Then
         _menuItemAnnotationsAlignObjectsMakeSameHeight.PerformClick()
      ElseIf e.Button Is _tbbMakeSameSize Then
         _menuItemAnnotationsAlignObjectsMakeSameSize.PerformClick()
      ElseIf e.Button Is _tbbRunDesign Then
         If _automationManager.UserMode = AnnUserMode.Run Then
            _menuItemAnnotationsUserModeDesign.PerformClick()
         ElseIf _automationManager.UserMode = AnnUserMode.Design Then
            _menuItemAnnotationsUserModeRun.PerformClick()
         End If
      End If
   End Sub

   Private Sub _menuItemViewSizeMode_Click(sender As Object, e As EventArgs) Handles _menuItemViewSizeModeNormal.Click, _menuItemViewSizeModeStretch.Click, _menuItemViewSizeModeFitAlways.Click, _menuItemViewSizeModeFitWidth.Click, _menuItemViewSizeModeFit.Click
      Dim activeForm As AnnotationsForm = ActiveAnnotationsForm

      activeForm.Viewer.BeginUpdate()

      Dim viewer As ImageViewer = activeForm.Viewer
      Dim defaultZoomOrigin As LeadPoint = viewer.DefaultZoomOrigin
      If sender Is _menuItemViewSizeModeNormal Then
         viewer.Zoom(ControlSizeMode.ActualSize, 1, defaultZoomOrigin)
      ElseIf sender Is _menuItemViewSizeModeFitAlways Then
         viewer.Zoom(ControlSizeMode.FitAlways, 1, defaultZoomOrigin)
      ElseIf sender Is _menuItemViewSizeModeFitWidth Then
         viewer.Zoom(ControlSizeMode.FitWidth, 1, defaultZoomOrigin)
      ElseIf sender Is _menuItemViewSizeModeStretch Then
         viewer.Zoom(ControlSizeMode.Stretch, 1, defaultZoomOrigin)
      ElseIf sender Is _menuItemViewSizeModeFit Then
         viewer.Zoom(ControlSizeMode.Fit, 1, defaultZoomOrigin)
      End If

      activeForm.Viewer.EndUpdate()

      UpdateControls()
   End Sub

   Public Sub Zoom(zoomIn As Boolean)
      If zoomIn Then
         _menuItemViewZoomIn.PerformClick()
      Else
         _menuItemViewZoomOut.PerformClick()
      End If
   End Sub

   Private Sub _menuItemViewZoom_Click(sender As Object, e As EventArgs) Handles _menuItemViewZoomIn.Click, _menuItemViewZoomOut.Click, _menuItemViewZoomValue.Click, _menuItemViewZoomNormal.Click
      ' get the current center in logical units
      Dim viewer As ImageViewer = ActiveAnnotationsForm.Viewer
      ' get the active viewer
      Dim defaultZoomOrigin As LeadPoint = viewer.DefaultZoomOrigin

      ' zoom
      Dim scaleFactor As Double = viewer.ScaleFactor

      Const ratio As Single = 1.2F

      If sender Is _menuItemViewZoomIn Then
         scaleFactor *= ratio
      ElseIf sender Is _menuItemViewZoomOut Then
         scaleFactor /= ratio
      ElseIf sender Is _menuItemViewZoomNormal Then
         scaleFactor = 1
         viewer.Zoom(ControlSizeMode.None, 1, defaultZoomOrigin)
      Else
         Dim dlg As New ZoomDialog()
         dlg.Value = CInt(Math.Truncate(scaleFactor * 100))
         dlg.MinimumValue = CInt(Math.Truncate(_minimumScaleFactor * 100.0F))
         dlg.MaximumValue = CInt(Math.Truncate(_maximumScaleFactor * 100.0F))

         If dlg.ShowDialog(Me) = DialogResult.OK Then
            scaleFactor = CSng(dlg.Value) / 100.0F
         End If
      End If

      scaleFactor = Math.Max(_minimumScaleFactor, Math.Min(_maximumScaleFactor, scaleFactor))

      If Math.Abs(viewer.ScaleFactor - scaleFactor) > 0 Then
         viewer.Zoom(ControlSizeMode.None, scaleFactor, defaultZoomOrigin)
      End If
   End Sub

   Private Sub _menuItemViewPaintProperties_Click(sender As Object, e As EventArgs) Handles _menuItemViewPaintProperties.Click
      Dim dlg As New PaintPropertiesDialog()
      dlg.PaintProperties = _paintProperties
      AddHandler dlg.Apply, AddressOf PaintPropertiesDialog_Apply
      dlg.ShowDialog(Me)
   End Sub

   Private Sub _menuItemViewFlip_Click(sender As Object, e As EventArgs) Handles _menuItemViewFlipHorizontal.Click, _menuItemViewFlipVertical.Click
      Dim horizontal As Boolean

      If sender Is _menuItemViewFlipHorizontal Then
         horizontal = True
      Else
         horizontal = False
      End If

      Try
         Using wait As New WaitCursor()

            Dim activeForm As AnnotationsForm = ActiveAnnotationsForm
            Dim viewer As IAnnAutomationControl = activeForm.Automation.AutomationControl
            Dim useDpiPrev As Boolean = viewer.AutomationUseDpi
            activeForm.Viewer.UseDpi = False
            FlipImageAndAnnotations(horizontal, activeForm.Automation.Container, activeForm.Viewer)
            activeForm.Viewer.UseDpi = useDpiPrev
         End Using
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try
      UpdateControls()
   End Sub

   Private Sub _menuItemViewRotate_Click(sender As Object, e As EventArgs) Handles _menuItemViewRotate90.Click, _menuItemViewRotate180.Click, _menuItemViewRotate270.Click, _menuItemViewRotateNone.Click
      Dim activeForm As AnnotationsForm = ActiveAnnotationsForm

      If sender Is _menuItemViewRotate180 Then
         activeForm.Viewer.RotateAngle = 180
      ElseIf sender Is _menuItemViewRotate270 Then
         activeForm.Viewer.RotateAngle = 270
      ElseIf sender Is _menuItemViewRotate90 Then
         activeForm.Viewer.RotateAngle = 90
      Else
         activeForm.Viewer.RotateAngle = 0
      End If

      UpdateControls()
   End Sub

   Private Sub PaintPropertiesDialog_Apply(sender As Object, e As EventArgs)
      Dim dlg As PaintPropertiesDialog = TryCast(sender, PaintPropertiesDialog)
      _paintProperties = dlg.PaintProperties
      For Each i As AnnotationsForm In MdiChildren
         i.UpdatePaintProperties(_paintProperties)
      Next
   End Sub

   Private Sub _menuItemAnnotationsRedactionObjects_Click(sender As Object, e As EventArgs) Handles _menuItemAnnotationsRedactionObjectsRealize.Click, _menuItemAnnotationsRedactionObjectsRestore.Click
      Dim activeForm As AnnotationsForm = ActiveAnnotationsForm

      If sender Is _menuItemAnnotationsRedactionObjectsRealize Then
         activeForm.Automation.RealizeRedaction()
      ElseIf sender Is _menuItemAnnotationsRedactionObjectsRestore Then
         activeForm.Automation.RestoreRedaction()
      End If
      UpdateControls()
   End Sub

   Private Sub _menuItemAnnotationsRedactionObjectsAll_Click(sender As Object, e As EventArgs) Handles _menuItemAnnotationsRedactionObjectsRealizeAll.Click, _menuItemAnnotationsRedactionObjectsRestoreAll.Click
      Dim activeForm As AnnotationsForm = ActiveAnnotationsForm

      If sender Is _menuItemAnnotationsRedactionObjectsRealizeAll Then
         activeForm.Automation.RealizeAllRedactions()
      ElseIf sender Is _menuItemAnnotationsRedactionObjectsRestoreAll Then
         activeForm.Automation.RestoreAllRedactions()
      End If
      UpdateControls()
   End Sub

   Private Sub _menuItemAnnotationsEncryptObjects_Click(sender As Object, e As EventArgs) Handles _menuItemAnnotationsEncryptObjectsApplyEncryptor.Click, _menuItemAnnotationsEncryptObjectsApplyDecryptor.Click
      Dim activeForm As AnnotationsForm = ActiveAnnotationsForm

      If sender Is _menuItemAnnotationsEncryptObjectsApplyEncryptor Then
         activeForm.Automation.ApplyEncryptor()
      ElseIf sender Is _menuItemAnnotationsEncryptObjectsApplyDecryptor Then
         activeForm.Automation.ApplyDecryptor()
      End If
      UpdateControls()
   End Sub

   Private Sub _menuItemAnnotationsEncryptObjectsAll_Click(sender As Object, e As EventArgs) Handles _menuItemAnnotationsEncryptObjectsApplyAllEncryptors.Click, _menuItemAnnotationsEncryptObjectsApplyAllDecryptors.Click
      Dim activeForm As AnnotationsForm = ActiveAnnotationsForm

      If sender Is _menuItemAnnotationsEncryptObjectsApplyAllEncryptors Then
         activeForm.Automation.ApplyAllEncryptors()
      ElseIf sender Is _menuItemAnnotationsEncryptObjectsApplyAllDecryptors Then
         activeForm.Automation.ApplyAllDecryptors()
      End If
      UpdateControls()
   End Sub

   Private Sub _menuItemAnnotationsRealize_Click(sender As Object, e As EventArgs) Handles _menuItemAnnotationsRealize.Click
      Dim activeForm As AnnotationsForm = ActiveAnnotationsForm
      If activeForm Is Nothing Then
         Return
      End If

      Dim container As AnnContainer = activeForm.Automation.Container
      Dim rasterImage As RasterImage = activeForm.Viewer.Image

      Try
         Dim renderingEngine As New AnnWinFormsRenderingEngine()
         renderingEngine.Renderers = _managerHelper.AutomationManager.RenderingEngine.Renderers
         renderingEngine.Resources = _automationManager.Resources

         Dim autoResetOptions As ImageViewerAutoResetOptions = activeForm.Viewer.AutoResetOptions
         activeForm.Viewer.AutoResetOptions = ImageViewerAutoResetOptions.None
         activeForm.Viewer.Image = renderingEngine.RenderOnImage(container, rasterImage)
         activeForm.Viewer.AutoResetOptions = autoResetOptions
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateControls()
      End Try
   End Sub

   Private Sub _menuItemAnnotationsFlip_Click(sender As Object, e As EventArgs) Handles _menuItemAnnotationsFlipHorizontal.Click, _menuItemAnnotationsFlipVertical.Click
      Dim activeForm As AnnotationsForm = ActiveAnnotationsForm
      If sender Is _menuItemAnnotationsFlipHorizontal Then
         activeForm.Automation.Flip(True)
      ElseIf sender Is _menuItemAnnotationsFlipVertical Then
         activeForm.Automation.Flip(False)
      End If

      UpdateControls()
   End Sub

   Private Sub _menuItemAnnotationsGroupGroupSelectedObjects_Click(sender As Object, e As EventArgs) Handles _menuItemAnnotationsGroupGroupSelectedObjects.Click
      Dim annContainer As AnnContainer = ActiveAnnotationsForm.Automation.Container
      If annContainer.SelectionObject IsNot Nothing AndAlso annContainer.SelectionObject.SelectedObjects.Count > 1 Then
         Dim groupName As String = String.Format("Group{0}", _randomNumber.Next() Mod 100)
         For Each annObject As AnnObject In annContainer.SelectionObject.SelectedObjects
            annObject.GroupName = groupName
         Next
      End If

      UpdateControls()
   End Sub

   Private Sub _menuItemAnnotationsGroupUngroup_Click(sender As Object, e As EventArgs) Handles _menuItemAnnotationsGroupUngroup.Click
      Dim annContainer As AnnContainer = ActiveAnnotationsForm.Automation.Container
      If annContainer.SelectionObject IsNot Nothing AndAlso annContainer.SelectionObject.SelectedObjects.Count > 1 Then
         annContainer.SelectionObject.Ungroup(annContainer.SelectionObject.SelectedObjects(0).GroupName)
      End If

      UpdateControls()
   End Sub

   Private Sub _menuItemAnnotationsPassword_Click(sender As Object, e As EventArgs) Handles _menuItemAnnotationsPasswordLock.Click, _menuItemAnnotationsPasswordUnlock.Click
      Dim activeForm As AnnotationsForm = ActiveAnnotationsForm

      If sender Is _menuItemAnnotationsPasswordLock Then
         activeForm.Automation.Lock()
      ElseIf sender Is _menuItemAnnotationsPasswordUnlock Then
         activeForm.Automation.Unlock()
      End If
      UpdateControls()
   End Sub

   Private Sub _menuItemAnnotationsAlign_Click(sender As Object, e As EventArgs) Handles _menuItemAnnotationsAlignBringToFront.Click, _menuItemAnnotationsAlignSendToBack.Click,
       _menuItemAnnotationsAlignBringToFirst.Click, _menuItemAnnotationsAlignSendToLast.Click, _menuItemAnnotationsAlignObjectsAlignmentLefts.Click, _menuItemAnnotationsAlignObjectsAlignmentCenters.Click,
       _menuItemAnnotationsAlignObjectsAlignmentRights.Click, _menuItemAnnotationsAlignObjectsAlignmentTops.Click, _menuItemAnnotationsAlignObjectsAlignmentMiddles.Click,
       _menuItemAnnotationsAlignObjectsAlignmentBottoms.Click, _menuItemAnnotationsAlignObjectsMakeSameWidth.Click, _menuItemAnnotationsAlignObjectsMakeSameHeight.Click,
       _menuItemAnnotationsAlignObjectsMakeSameSize.Click

      Dim activeForm As AnnotationsForm = ActiveAnnotationsForm

      If sender Is _menuItemAnnotationsAlignBringToFront Then
         activeForm.Automation.BringToFront(False)
      ElseIf sender Is _menuItemAnnotationsAlignSendToBack Then
         activeForm.Automation.SendToBack(False)
      ElseIf sender Is _menuItemAnnotationsAlignBringToFirst Then
         activeForm.Automation.BringToFront(True)
      ElseIf sender Is _menuItemAnnotationsAlignSendToLast Then
         activeForm.Automation.SendToBack(True)
      ElseIf sender Is _menuItemAnnotationsAlignObjectsAlignmentLefts Then
         activeForm.Automation.AlignLefts()
      ElseIf sender Is _menuItemAnnotationsAlignObjectsAlignmentCenters Then
         activeForm.Automation.AlignCenters()
      ElseIf sender Is _menuItemAnnotationsAlignObjectsAlignmentRights Then
         activeForm.Automation.AlignRights()
      ElseIf sender Is _menuItemAnnotationsAlignObjectsAlignmentTops Then
         activeForm.Automation.AlignTops()
      ElseIf sender Is _menuItemAnnotationsAlignObjectsAlignmentMiddles Then
         activeForm.Automation.AlignMiddles()
      ElseIf sender Is _menuItemAnnotationsAlignObjectsAlignmentBottoms Then
         activeForm.Automation.AlignBottoms()
      ElseIf sender Is _menuItemAnnotationsAlignObjectsMakeSameWidth Then
         activeForm.Automation.MakeSameWidth()
      ElseIf sender Is _menuItemAnnotationsAlignObjectsMakeSameHeight Then
         activeForm.Automation.MakeSameHeight()
      ElseIf sender Is _menuItemAnnotationsAlignObjectsMakeSameSize Then
         activeForm.Automation.MakeSameSize()
      End If
      UpdateControls()
   End Sub

   Private Sub _menuItemAnnotationsResetRotatePoints_Click(sender As Object, e As EventArgs) Handles _menuItemAnnotationsResetRotatePoints.Click
      Dim activeForm As AnnotationsForm = ActiveAnnotationsForm

      activeForm.Automation.ResetRotatePoints()
      UpdateControls()
   End Sub

   Private Sub _menuItemAnnotationsCurrentObject_Click(sender As Object, e As EventArgs) Handles _menuItemAnnotationsCurrentObject.Click
      Using dlg As New CurrentObjectDialog(_automationManager)
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _automationManager.CurrentObjectId = dlg.ObjectId
            If _automationManager.CurrentObjectId = AnnObject.RubberStampObjectId Then
               _automationManager.CurrentRubberStampType = dlg.RubberStampType
            End If
         End If
      End Using
   End Sub

   Private Sub _menuItemAnnotationsAntiAlias_Click(sender As Object, e As EventArgs) Handles _menuItemAnnotationsAntiAlias.Click
      _antiAlias = Not _antiAlias

      For Each i As AnnotationsForm In MdiChildren
         i.UpdateAntiAlias(_antiAlias)
      Next

      UpdateControls()
   End Sub

   Private Sub _menuItemAnnotationsSnapToGridProperties_Click(sender As Object, e As EventArgs) Handles _menuItemAnnotationsSnapToGridProperties.Click
      Dim activeForm As AnnotationsForm = ActiveAnnotationsForm
      If activeForm IsNot Nothing Then
         Using dlg As New SnapToGridPropertiesDialog()
            dlg.Automation = activeForm.Automation
            dlg.ShowDialog()
         End Using
      End If

      UpdateControls()
   End Sub

   Private Sub _menuItemAnnotationsProperties_Click(sender As Object, e As EventArgs) Handles _menuItemAnnotationsProperties.Click
      Dim activeForm As AnnotationsForm = ActiveAnnotationsForm
      If activeForm IsNot Nothing AndAlso activeForm.Automation.CanShowObjectProperties Then
         activeForm.Automation.ShowObjectProperties()
      End If

      UpdateControls()
   End Sub

   Private Sub _menuItemAnnotationsBehaviorUseRotateThumbs_Click(sender As Object, e As EventArgs) Handles _menuItemAnnotationsBehaviorUseRotateThumbs.Click
      Dim useRotateControlPoints As Boolean = Not _menuItemAnnotationsBehaviorUseRotateThumbs.Checked

      For Each obj As AnnAutomationObject In _automationManager.Objects
         obj.UseRotateThumbs = useRotateControlPoints
      Next

      Dim form As AnnotationsForm = ActiveAnnotationsForm
      If form IsNot Nothing AndAlso form.Automation.CanSelectNone Then
         Dim activeForm As AnnotationsForm = ActiveAnnotationsForm

         activeForm.Automation.SelectObjects(Nothing)

         activeForm.Viewer.Invalidate()
      End If
      UpdateControls()
   End Sub

   Private Sub _menuItemAnnotationsBehaviorRestrictDesigners_Click(sender As Object, e As EventArgs) Handles _menuItemAnnotationsBehaviorRestrictDesigners.Click
      _automationManager.RestrictDesigners = Not _automationManager.RestrictDesigners
      UpdateControls()
   End Sub

   Private Sub _menuItemAnnotationsBehaviorEnableObjectsAlignment_Click(sender As Object, e As EventArgs) Handles _menuItemAnnotationsBehaviorEnableObjectsAlignment.Click
      _automationManager.EnableObjectsAlignment = Not _automationManager.EnableObjectsAlignment
      UpdateControls()
   End Sub

   Private Sub _menuItemAnnotationsBehaviorEnableAutoIncrement_Click(sender As Object, e As EventArgs) Handles _menuItemAnnotationsBehaviorEnableAutoIncrement.Click
      _menuItemAnnotationsBehaviorEnableAutoIncrement.Checked = Not _menuItemAnnotationsBehaviorEnableAutoIncrement.Checked
      SetAutoIncrement(_menuItemAnnotationsBehaviorEnableAutoIncrement.Checked)
   End Sub

   Private Sub SetAutoIncrement(autoIncrement As Boolean)

      For Each automationObject As AnnAutomationObject In _automationManager.Objects
         If autoIncrement Then
            automationObject.LabelTemplate = "##"
         Else
            automationObject.LabelTemplate = String.Empty
         End If
      Next

   End Sub

   Private Sub _menuItemAnnotationsBehaviorEnableToolTip_Click(sender As Object, e As EventArgs) Handles _menuItemAnnotationsBehaviorEnableToolTip.Click
      _menuItemAnnotationsBehaviorEnableToolTip.Checked = Not _menuItemAnnotationsBehaviorEnableToolTip.Checked
      _automationManager.EnableToolTip = Not _automationManager.EnableToolTip
   End Sub

   Private Sub _menuItemAnnotationsBehaviorMaintainAspectRatio_Click(sender As Object, e As EventArgs) Handles _menuItemAnnotationsBehaviorMaintainAspectRatio.Click
      _automationManager.MaintainAspectRatio = Not _automationManager.MaintainAspectRatio

      Dim activeForm As AnnotationsForm = ActiveAnnotationsForm
      If activeForm IsNot Nothing AndAlso activeForm.Automation.Container.SelectionObject.SelectedObjects.Count > 0 Then
         activeForm.Automation.SelectObjects(Nothing)
      End If
   End Sub

   Private Sub _menuItemAnnotationsUserMode_Click(sender As Object, e As EventArgs) Handles _menuItemAnnotationsUserModeRun.Click, _menuItemAnnotationsUserModeDesign.Click
      If _automationManager.UserMode = AnnUserMode.Design Then
         _automationManager.UserMode = AnnUserMode.Run
      Else
         _automationManager.UserMode = AnnUserMode.Design
      End If

      UpdateControls()
   End Sub

   Private Sub _menuItemWindow_Click(sender As Object, e As EventArgs) Handles _menuItemWindowCascade.Click, _menuItemWindowTileHorizontally.Click, _menuItemWindowTileVertically.Click, _menuItemWindowArrangeIcons.Click, _menuItemWindowCloseAll.Click
      If sender Is _menuItemWindowCascade Then
         LayoutMdi(MdiLayout.Cascade)
      ElseIf sender Is _menuItemWindowTileHorizontally Then
         LayoutMdi(MdiLayout.TileHorizontal)
      ElseIf sender Is _menuItemWindowTileVertically Then
         LayoutMdi(MdiLayout.TileVertical)
      ElseIf sender Is _menuItemWindowArrangeIcons Then
         LayoutMdi(MdiLayout.ArrangeIcons)
      ElseIf sender Is _menuItemWindowCloseAll Then
         Dim i As Integer
         For i = MdiChildren.Length - 1 To 0 Step -1
            MdiChildren(i).Close()
         Next

         UpdateControls()
      End If
   End Sub

   Private Sub _menuItemHelpAbout_Click(sender As Object, e As EventArgs) Handles _menuItemHelpAbout.Click
#If LEADTOOLS_V19_OR_LATER Then
      Using aboutDialog As New AboutDialog("Annotations", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
#Else
      Using aboutDialog As New AboutDialog("Annotations")
	      aboutDialog.ShowDialog(Me)
      End Using
#End If
   End Sub

   Public Sub SetStatusBarText(text As String)
      _sbMain.Text = text
   End Sub

   Private Sub _automationManager_UserModeChanged(sender As Object, e As EventArgs)
      UpdateCaption()
      UpdateControls()
   End Sub

   Private Sub UpdateCaption()
      Text = String.Format("{0} [{1}]", Messager.Caption, If(_automationManager.UserMode = AnnUserMode.Run, "Run", "Design"))
   End Sub

   Public Sub CurrentDesignerChanged()
      Dim activeForm As AnnotationsForm = ActiveAnnotationsForm

      If activeForm IsNot Nothing Then
         Dim automation As AnnAutomation = activeForm.Automation
         If automation.CurrentDesigner IsNot Nothing AndAlso TypeOf automation.CurrentDesigner Is AnnRunDesigner Then
            Dim runDesigner As AnnRunDesigner = TryCast(automation.CurrentDesigner, AnnRunDesigner)
            AddHandler runDesigner.Run, AddressOf MyRunDesignerHandler
         End If
      End If
   End Sub

   Private Sub MyRunDesignerHandler(sender As Object, e As AnnRunDesignerEventArgs)
      If e.OperationStatus = AnnDesignerOperationStatus.End Then

         Dim mediaObject As AnnMediaObject = TryCast(e.Object, AnnMediaObject)

         Try

            Dim mediaSource As String = Nothing

            If mediaObject IsNot Nothing AndAlso mediaObject.Media IsNot Nothing Then
               mediaSource = mediaObject.Media.Source1
            End If

            If mediaSource IsNot Nothing Then
               If mediaObject.Id = AnnObject.AudioObjectId Then
                  Using mediaForm As MediaForm = New MediaForm(mediaSource, MediaControl.Audio)
                     mediaForm.ShowDialog(Me)
                     Return
                  End Using
               Else
                  Using mediaForm As MediaForm = New MediaForm(mediaSource, MediaControl.Video)
                     mediaForm.ShowDialog(Me)
                     Return
                  End Using
               End If
            End If


            If Not e.Cancel AndAlso (e.Object.Hyperlink Is Nothing OrElse e.Object.Hyperlink = String.Empty) Then
               e.Cancel = True

               Dim sb As New StringBuilder()
               sb.Append("You clicked an object that has no hyperlink:")
               sb.Append(Environment.NewLine)
               sb.Append(Environment.NewLine)
               sb.Append(String.Format("Name: {0}", e.Object.FriendlyName))
               sb.Append(Environment.NewLine)
               sb.Append(String.Format("Type: {0}", e.Object.GetType().Name))
               sb.Append(Environment.NewLine)
               Messager.ShowInformation(Me, sb.ToString())
            Else
               Process.Start(e.Object.Hyperlink)
            End If

         Catch ex As Exception
            MessageBox.Show(Me, ex.Message, Nothing, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End Try
      End If
   End Sub

   Public Function GetAnnotationsFileName(fileName As String) As String
      ' the file name may be (.xml) new design , or (.ann) for old annotations
      Dim annFileName As String = Path.ChangeExtension(fileName, "xml")
      If Not File.Exists(annFileName) Then
         annFileName = Path.ChangeExtension(fileName, "ann")
         If Not File.Exists(annFileName) Then
            Return String.Empty
         End If
      End If

      Return annFileName
   End Function


   Public Sub Save(fileName As String, saveImage As Boolean, format As RasterImageFormat, saveToTiff As Boolean, saveToWang As Boolean)
      Dim form As AnnotationsForm = ActiveAnnotationsForm
      Dim automation As AnnAutomation = form.Automation
      Dim image As RasterImage = form.Viewer.Image
      If saveImage Then
         Try
            'if we want to attach the annotations as tags we should save the image as Tiff 
            If saveToTiff AndAlso image.OriginalFormat <> RasterImageFormat.CcittGroup4 AndAlso image.OriginalFormat <> RasterImageFormat.TifLzw Then
               _codecs.Save(image, fileName, RasterImageFormat.TifLzw, image.BitsPerPixel)
            Else
               _codecs.Save(image, fileName, image.OriginalFormat, image.BitsPerPixel)

            End If
         Catch ex As RasterException
            If ex.Code = RasterExceptionCode.BitsPerPixel Then
               _codecs.Save(image, form.Text, image.OriginalFormat, 0)
            End If
         End Try
      End If

      SaveAnnotations(fileName, image.Page, automation.Container, saveToTiff, saveToWang)
   End Sub

   Private _skippedLoadedObjects As List(Of String)

   Private Sub DeserializeOptions_DeserializeObject(sender As Object, e As AnnSerializeObjectEventArgs)
      ' Check if the object has an AutomationObject, if not, this means this object
      ' was created with a pack loaded, collect the info and warn the user. Skip loading this object
      For Each automationObject As AnnAutomationObject In _automationManager.Objects
         If automationObject.ObjectTemplate.[GetType]().FullName = e.TypeName Then
            e.AnnObject = automationObject.ObjectTemplate.Clone()
            Return
         End If
      Next

      ' Not found,
      e.SkipObject = True
      If _skippedLoadedObjects IsNot Nothing AndAlso Not _skippedLoadedObjects.Contains(e.TypeName) Then
         _skippedLoadedObjects.Add(e.TypeName)
      End If
   End Sub


   Private Sub LoadAnnotations(fileName As String, container As AnnContainer, pageNumber As Integer, automationControl As IAnnAutomationControl)
      'Set some properties for the AnnCodecs to update container mapper resolutions during build before updating it on automation
      _annCodecs.LoadUseDpi = automationControl.AutomationUseDpi
      _annCodecs.LoadSourceResolution = LeadSizeD.Create(automationControl.AutomationXResolution, automationControl.AutomationYResolution)
      _annCodecs.LoadTargetResolution = LeadSizeD.Create(automationControl.AutomationDpiX, automationControl.AutomationDpiY)

      Dim tmpContainer As AnnContainer = Nothing
      Dim info As CodecsImageInfo = _codecs.GetInformation(fileName, False)

      Try
         ' To hold any objects we skipped
         _skippedLoadedObjects = New List(Of String)()

         'try to load annotations from tif fil tags
         If IsTiffFormat(info.Format) Then
            tmpContainer = AnnCodecs.Load(fileName, 1)
         End If


         If tmpContainer Is Nothing Then
            Dim annFileName As String = GetAnnotationsFileName(fileName)
            If annFileName <> String.Empty Then
               tmpContainer = AnnCodecs.Load(annFileName, 1)
               If tmpContainer IsNot Nothing Then
                  'Set the Text for rich text object if it is loaded
                  For Each annObject__1 As AnnObject In tmpContainer.Children
                     If annObject__1.Id = AnnObject.TextObjectId Then
                        If annObject__1.Metadata.ContainsKey("RichTextData") Then
                           Dim annTextObject As AnnTextObject = TryCast(annObject__1, AnnTextObject)
                           'convert the rtf string to text , the rich text control will take care of this
                           Dim richTextBox As New RichTextBox()
                           richTextBox.Rtf = annObject__1.Metadata("RichTextData")


                           annTextObject.Text = richTextBox.Text
                        End If
                     End If

                     If annObject__1.Id = AnnObject.EncryptObjectId Then
                        Dim encrypt As AnnEncryptObject = TryCast(annObject__1, AnnEncryptObject)
                        If encrypt.IsEncrypted Then
                           encrypt.Encryptor = True
                           encrypt.Apply(_automationManager.Automations(0).AutomationControl.AutomationDataProvider, _automationManager.Automations(0).Container)
                           _automationManager.Automations(0).InvalidateObject(annObject__1)
                        End If
                     End If
                  Next

                  If _skippedLoadedObjects.Count > 0 Then
                     ' We skipped loading objects that we couldnt automate, show a warning to the user
                     Dim sb As New StringBuilder()
                     sb.AppendLine("The following object types were found in the file but skipped during load since the demo did not find an automation object for them.")
                     sb.AppendLine("You can fix this by loading the package that contains these objects from File/Load Package and try again")
                     sb.AppendLine()
                     sb.AppendLine("Object types:")
                     sb.AppendLine("-------------")
                     For Each typeName As String In _skippedLoadedObjects
                        sb.AppendLine(typeName)
                     Next
                     MessageBox.Show(Me, sb.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                  End If
               End If
            End If
         End If
      Catch ex As Exception
         If TypeOf ex Is TargetInvocationException AndAlso ex.InnerException IsNot Nothing Then
            Messager.ShowError(Me, ex.InnerException)
         Else
            Messager.ShowError(Me, ex)
         End If

      End Try

      If tmpContainer IsNot Nothing Then
         container.Children.Clear()

         Dim calibrationUnit As AnnUnit = tmpContainer.Mapper.CalibrationUnit

         'apply loaded calibration scale
         container.Mapper.Calibrate(LeadLengthD.Create(1), calibrationUnit, LeadLengthD.Create(tmpContainer.Mapper.CalibrationScale), calibrationUnit)

         For Each annObject__1 As AnnObject In tmpContainer.Children
            container.Children.Add(annObject__1)
         Next

      End If

      If ActiveAnnotationsForm IsNot Nothing Then
         ActiveAnnotationsForm.Automation.Invalidate(LeadRectD.Empty)
      End If
   End Sub


   Private Function IsTiffFormat(format As RasterImageFormat) As Boolean
      Select Case format
         Case RasterImageFormat.Tif, RasterImageFormat.TifLzw, RasterImageFormat.TifJpeg411, RasterImageFormat.TifJpeg422, RasterImageFormat.Ccitt, RasterImageFormat.CcittGroup31Dim, _
          RasterImageFormat.CcittGroup32Dim, RasterImageFormat.CcittGroup4, RasterImageFormat.TifCmyk, RasterImageFormat.TifLzwCmyk, RasterImageFormat.TifPackBits, RasterImageFormat.TifPackBitsCmyk, _
          RasterImageFormat.TifYcc, RasterImageFormat.TifLzwYcc, RasterImageFormat.TifPackbitsYcc, RasterImageFormat.Exif, RasterImageFormat.ExifYcc, RasterImageFormat.TifCmp, _
          RasterImageFormat.TifJbig, RasterImageFormat.TifUnknown, RasterImageFormat.GeoTiff, RasterImageFormat.TifLead1Bit, RasterImageFormat.TifCmw
            Return True
         Case Else
            Return False
      End Select
   End Function
   Private Shared Sub SaveContainerToTiff(codecs As RasterCodecs, annCodecs As AnnCodecs, fileName As String, pageNumber As Integer, container As AnnContainer, saveToWang As Boolean)
      Dim tag As RasterTagMetadata = annCodecs.SaveToTag(container, saveToWang)
      If tag IsNot Nothing Then
         codecs.WriteTag(fileName, pageNumber, tag)
      End If

   End Sub

   Private Sub SaveAnnotations(imageFileName As String, pageNumber As Integer, container As AnnContainer, saveToTiff As Boolean, saveToWang As Boolean)
      If saveToTiff Then
         SaveContainerToTiff(_codecs, _annCodecs, imageFileName, pageNumber, container, saveToWang)
      Else
         Dim annFileName As String = Path.ChangeExtension(imageFileName, "xml")

         Try
            AnnCodecs.Save(annFileName, container, AnnFormat.Annotations, 1)
         Catch ex As Exception
            If TypeOf ex Is TargetInvocationException AndAlso ex.InnerException IsNot Nothing Then
               Messager.ShowError(Me, ex.InnerException)
            Else
               Messager.ShowError(Me, ex)
            End If
         End Try
      End If
   End Sub

   Private Function IsDecryptor(obj As AnnObject) As Boolean
      Dim bRet As Boolean = False

      If TypeOf obj Is AnnEncryptObject Then
         Dim annEncryptObject As AnnEncryptObject = CType(obj, AnnEncryptObject)
         If annEncryptObject IsNot Nothing Then
            If annEncryptObject.Encryptor = False Then
               bRet = True
            End If
         End If
      End If

      Return bRet
   End Function

   Private Function IsDecryptorPresent(container As AnnContainer) As Boolean
      For Each obj As AnnObject In container.Children
         If TypeOf obj Is AnnSelectionObject Then
            Dim annGroupObject As AnnSelectionObject = CType(obj, AnnSelectionObject)
            For Each obj2 As AnnObject In annGroupObject.SelectedObjects
               If IsDecryptor(obj2) Then
                  Return True
               End If
            Next
         ElseIf IsDecryptor(obj) Then
            Return True
         End If
      Next
      Return False
   End Function

   Private Sub FlipImageAndAnnotations(horizontal As Boolean, container As AnnContainer, viewer As ImageViewer)
      Dim bDecryptor As Boolean = IsDecryptorPresent(container)
      If bDecryptor Then
         MessageBox.Show("You must 'Apply Decryptor' before doing a flip.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Return
      End If

      Dim image As RasterImage = viewer.Image
      ' calculate the origin
      Dim origin As New LeadPointD(image.ImageWidth / 2, image.ImageHeight / 2)

      ' flip the image
      image.FlipViewPerspective(horizontal)

      ' now flip each object around the origin.
      Dim sx As Single = If(horizontal, -1, 1)
      Dim sy As Single = If(horizontal, 1, -1)

      Dim annOrigin As LeadPointD = LeadPointD.Create(origin.X, origin.Y)
      Dim mapper As AnnContainerMapper = container.Mapper.Clone()
      mapper.UpdateTransform(LeadMatrix.Identity)
      annOrigin = mapper.PointToContainerCoordinates(annOrigin)

      For Each obj As AnnObject In container.Children
         obj.Scale(sx, sy, annOrigin)
      Next

      If container.SelectionObject IsNot Nothing Then
         container.SelectionObject.AdjustBounds()
      End If

      Dim editDesigner As AnnEditDesigner = TryCast(ActiveAnnotationsForm.Automation.CurrentDesigner, AnnEditDesigner)
      If editDesigner IsNot Nothing Then
         ActiveAnnotationsForm.Automation.CurrentDesigner.Invalidate(LeadRectD.Empty)
      End If
   End Sub

   Private Sub _menuItemViewInteractiveMode_Click(sender As Object, e As EventArgs) Handles _menuItemViewInteractiveModeNone.Click, _menuItemViewInteractiveModeMagnifyGlass.Click, _menuItemViewInteractiveModePan.Click

      For Each i As AnnotationsForm In MdiChildren

         Dim viewer As ImageViewer = i.Viewer

         viewer.InteractiveModes.BeginUpdate()

         For Each mode As ImageViewerInteractiveMode In viewer.InteractiveModes
            mode.IsEnabled = False
         Next

         If sender Is _menuItemViewInteractiveModeMagnifyGlass Then
            i.MagnifyGlassInteractiveMode.IsEnabled = True
         ElseIf sender Is _menuItemViewInteractiveModePan Then
            i.PanZoomInteractiveMode.IsEnabled = True
         Else
            i.AutomationInteractiveMode.IsEnabled = True
         End If

         viewer.InteractiveModes.EndUpdate()
      Next

      UpdateControls()
   End Sub

   Private Sub _menuItemViewUseDpi_Click(sender As Object, e As EventArgs) Handles _menuItemViewUseDpi.Click
      _menuItemViewUseDpi.Checked = Not _menuItemViewUseDpi.Checked
      ActiveAnnotationsForm.Viewer.UseDpi = _menuItemViewUseDpi.Checked
   End Sub

   Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      _managerHelper.Dispose()

   End Sub

   Private Sub _menuItemLoadAnnPackage_Click(sender As Object, e As EventArgs) Handles _menuItemLoadAnnPackage.Click

      If _showLoadPackageInfoDialog = True Then
         Dim info As StringBuilder = New StringBuilder()
         info.AppendLine("This allows you to load a .NET dll that contains custom Annotation Objects.\n")
         info.AppendLine("The dll must have a class that implements the IAnnPackage interface defined in the Leadtools.Annotations.Automation Assembly.\n")
         info.AppendLine("For testing, you can load the Custom Medical objects located in Leadtools.Annotations.UserMedicalPack.WinForms.dll.")

         Using dlg As New UserInfoDialog(info.ToString())
            dlg.Text = "Load Package Information"
            dlg.ShowDialog()
            _showLoadPackageInfoDialog = dlg.ShowNextTime
         End Using
      End If

      Using openFileDialog As New OpenFileDialog()
         openFileDialog.Title = "Load Annotations Package"
         openFileDialog.Filter = "Dll files (*.dll)|*.dll"
         If openFileDialog.ShowDialog() = DialogResult.OK Then
            LoadPackage(openFileDialog.FileName)
            SetAutoIncrement(_menuItemAnnotationsBehaviorEnableAutoIncrement.Checked)
         End If
      End Using
   End Sub

   Private Sub LoadPackage(fileName As String)
      Try
         Dim assembly__1 As Assembly = Assembly.LoadFrom(fileName)
         Dim types As Type() = assembly__1.GetTypes()
         Dim packageType As Type = GetType(IAnnPackage)
         Dim packageFound As Boolean = False
         Dim packageAlreadyLoaded As Boolean = False
         Dim package As IAnnPackage = Nothing
         Dim sb As New StringBuilder()
         sb.AppendLine("The following packages were loaded")
         sb.AppendLine()

         ' load packages those implement IAnnPackage.
         For Each type As Type In types
            If packageType.IsAssignableFrom(type) Then
               packageFound = True

               package = CType(Activator.CreateInstance(type), IAnnPackage)
               If Not _loadedPackages.Contains(package.FriendlyName) Then
                  _managerHelper.LoadPackage(package)
                  _loadedPackages.Add(package.FriendlyName)
               Else
                  packageAlreadyLoaded = True
               End If

               sb.AppendLine("Name:" + package.FriendlyName)
               sb.AppendLine("Author:" + package.Author)
               sb.AppendLine("Description:" + package.Description)
            End If
         Next

         If packageFound Then
            If packageAlreadyLoaded Then
               MessageBox.Show(Me, String.Format("The Package ({0}) Is Already Loaded", package.FriendlyName), "Annotations Package", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
               MessageBox.Show(Me, sb.ToString(), "Annotations Package", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
         Else
            MessageBox.Show(Me, "The specified dll doesn't contain annotations packages", "Annotations Package", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message)
      End Try
   End Sub

   Private Sub _menuItemFileLoadBateStamp_Click(sender As Object, e As EventArgs) Handles _menuItemFileLoadBateStamp.Click
      Try
         If _showLoadBatesStampInfoDialog = True Then
            Dim info As StringBuilder = New StringBuilder()
            info.AppendLine("Use this Menu to load Bates stamp xml file.\n")
            info.AppendLine("You can create bates stamp using our Bates Stamp Composer Demo.\n")

            Using dlg As New UserInfoDialog(info.ToString())
               dlg.Text = "Load Bates Stamp Information"
               dlg.ShowDialog()
               _showLoadBatesStampInfoDialog = dlg.ShowNextTime
            End Using
         End If

         Using openDilaog As New OpenFileDialog()
            openDilaog.Filter = "Xml Files | *.xml"
            openDilaog.Title = "Load Bate Stamp"
            If openDilaog.ShowDialog() = DialogResult.OK Then
               'Set Composer rendering engine
               AnnBatesStampComposer.RenderingEngine = New AnnWinFormsRenderingEngine()
               'Load composer instance
               Dim batesStampComposer As AnnBatesStampComposer = AnnBatesStampComposer.Load(openDilaog.FileName)

               If ActiveAnnotationsForm IsNot Nothing Then
                  Dim automation As AnnAutomation = ActiveAnnotationsForm.Automation
                  Dim mainContainer As AnnContainer = automation.Container

                  'If there is bates stamp container added then remove it 
                  If automation.Containers.Count = 2 Then
                     automation.Containers.RemoveAt(0)
                  End If

                  'Create Bates stamp container, set its size and mapper
                  Dim batesStampContainer As New AnnContainer()
                  batesStampContainer.Size = mainContainer.Size
                  batesStampContainer.Mapper = mainContainer.Mapper.Clone()

                  'Apply BatesStamp to our container
                  batesStampComposer.TargetContainers.Add(batesStampContainer)

                  automation.Containers.Insert(0, batesStampContainer)

                  automation.Invalidate(LeadRectD.Empty)
               End If
            End If
         End Using
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try
   End Sub

   Private Sub _menuItemCalibrate_Click(sender As Object, e As EventArgs) Handles _menuItemCalibrate.Click
      Using calibrationDialog As New CalibrationDialog(ActiveAnnotationsForm.Automation)
         calibrationDialog.ShowDialog()
      End Using
   End Sub

   Private Sub _menuItemEditDuplicate_Click(sender As Object, e As EventArgs) Handles _menuItemEditDuplicate.Click
      Dim automation As AnnAutomation = ActiveAnnotationsForm.Automation
      Dim newObjects As New AnnObjectCollection()

      Dim selectionObject As AnnSelectionObject = TryCast(automation.CurrentEditObject, AnnSelectionObject)
      If selectionObject IsNot Nothing Then
         ' clone the objects into a new list

         For Each obj As AnnObject In selectionObject.SelectedObjects
            newObjects.Add(obj.Clone())
         Next
      Else
         newObjects.Add(automation.CurrentEditObject.Clone())
      End If

      ' if needed, one undo operation for this
      automation.BeginUndo()

      ' Add them to the container through automation
      For Each obj As AnnObject In newObjects
         automation.ActiveContainer.Children.Add(obj)
      Next

      automation.EndUndo()

      ' and you can unselect the old objects
      automation.SelectObjects(Nothing)

      ' and select the new ones
      automation.SelectObjects(newObjects)
   End Sub
End Class
