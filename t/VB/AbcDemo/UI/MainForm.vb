' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.IO

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.Drawing
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.Demos.Dialogs

Namespace AbcDemo
   ''' <summary>
   ''' Summary description for Form1.
   ''' </summary>
   Public Class MainForm : Inherits System.Windows.Forms.Form
      Private _mmMain As System.Windows.Forms.MainMenu
      Private WithEvents _miFile As System.Windows.Forms.MenuItem
      Private WithEvents _miFileOpen As System.Windows.Forms.MenuItem
      Private WithEvents _miFileClose As System.Windows.Forms.MenuItem
      Private WithEvents _miFileExit As System.Windows.Forms.MenuItem
      Private _FileSeperator1 As System.Windows.Forms.MenuItem
      Private _miEdit As System.Windows.Forms.MenuItem
      Private WithEvents _miEditCopy As System.Windows.Forms.MenuItem
      Private WithEvents _miView As System.Windows.Forms.MenuItem
      Private WithEvents _miViewNormal As System.Windows.Forms.MenuItem
      Private WithEvents _miViewSnapToImage As System.Windows.Forms.MenuItem
      Private WithEvents _miViewZoomIn As System.Windows.Forms.MenuItem
      Private WithEvents _miViewZoomOut As System.Windows.Forms.MenuItem
      Private _miQuality As System.Windows.Forms.MenuItem
      Private WithEvents _miQualityCombineTwoImages As System.Windows.Forms.MenuItem
      Private _QualitySeperator1 As System.Windows.Forms.MenuItem
      Private WithEvents _miQualityLossless As System.Windows.Forms.MenuItem
      Private WithEvents _miQualityVirtualLossless As System.Windows.Forms.MenuItem
      Private WithEvents _miQualityRemoveBorder As System.Windows.Forms.MenuItem
      Private WithEvents _miQualityEnhanced As System.Windows.Forms.MenuItem
      Private WithEvents _miQualityModified1 As System.Windows.Forms.MenuItem
      Private WithEvents _miQualityFastModified1 As System.Windows.Forms.MenuItem
      Private WithEvents _miQualityModified2 As System.Windows.Forms.MenuItem
      Private WithEvents _miQualityFastModified2 As System.Windows.Forms.MenuItem
      Private WithEvents _miQualityModified3 As System.Windows.Forms.MenuItem
      Private _miWindow As System.Windows.Forms.MenuItem
      Private WithEvents _miWindowCascade As System.Windows.Forms.MenuItem
      Private WithEvents _miWindowTileHorizontal As System.Windows.Forms.MenuItem
      Private WithEvents _miWindowTileVertical As System.Windows.Forms.MenuItem
      Private WithEvents _miWindowArrangeIcons As System.Windows.Forms.MenuItem
      Private _miHelp As System.Windows.Forms.MenuItem
      Private WithEvents _miHelpAbout As System.Windows.Forms.MenuItem
      Private WithEvents _miViewFitToWindow As System.Windows.Forms.MenuItem
      Private WithEvents _miFileSaveCurrentAsAbc As System.Windows.Forms.MenuItem
      Private WithEvents _miFileSaveAllPagesAsTIFF As System.Windows.Forms.MenuItem
      Private WithEvents _miFileSaveCurrentAsTIFF As System.Windows.Forms.MenuItem
      Private _ViewSeparator1 As System.Windows.Forms.MenuItem
      Private _ViewSeparator2 As System.Windows.Forms.MenuItem
      Private WithEvents _miQualityFastModified3 As System.Windows.Forms.MenuItem
      Private WithEvents _miQualityFastLossless As System.Windows.Forms.MenuItem
      Private WithEvents _miQualityFastLossy As System.Windows.Forms.MenuItem
      Private _sbMainStatus As System.Windows.Forms.StatusBar
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
            Me._mmMain = New System.Windows.Forms.MainMenu(Me.components)
            Me._miFile = New System.Windows.Forms.MenuItem()
            Me._miFileOpen = New System.Windows.Forms.MenuItem()
            Me._miFileClose = New System.Windows.Forms.MenuItem()
            Me._miFileSaveCurrentAsAbc = New System.Windows.Forms.MenuItem()
            Me._miFileSaveCurrentAsTIFF = New System.Windows.Forms.MenuItem()
            Me._miFileSaveAllPagesAsTIFF = New System.Windows.Forms.MenuItem()
            Me._FileSeperator1 = New System.Windows.Forms.MenuItem()
            Me._miFileExit = New System.Windows.Forms.MenuItem()
            Me._miEdit = New System.Windows.Forms.MenuItem()
            Me._miEditCopy = New System.Windows.Forms.MenuItem()
            Me._miView = New System.Windows.Forms.MenuItem()
            Me._miViewNormal = New System.Windows.Forms.MenuItem()
            Me._miViewFitToWindow = New System.Windows.Forms.MenuItem()
            Me._ViewSeparator1 = New System.Windows.Forms.MenuItem()
            Me._miViewSnapToImage = New System.Windows.Forms.MenuItem()
            Me._ViewSeparator2 = New System.Windows.Forms.MenuItem()
            Me._miViewZoomIn = New System.Windows.Forms.MenuItem()
            Me._miViewZoomOut = New System.Windows.Forms.MenuItem()
            Me._miQuality = New System.Windows.Forms.MenuItem()
            Me._miQualityCombineTwoImages = New System.Windows.Forms.MenuItem()
            Me._QualitySeperator1 = New System.Windows.Forms.MenuItem()
            Me._miQualityLossless = New System.Windows.Forms.MenuItem()
            Me._miQualityFastLossless = New System.Windows.Forms.MenuItem()
            Me._miQualityVirtualLossless = New System.Windows.Forms.MenuItem()
            Me._miQualityFastLossy = New System.Windows.Forms.MenuItem()
            Me._miQualityRemoveBorder = New System.Windows.Forms.MenuItem()
            Me._miQualityEnhanced = New System.Windows.Forms.MenuItem()
            Me._miQualityModified1 = New System.Windows.Forms.MenuItem()
            Me._miQualityFastModified1 = New System.Windows.Forms.MenuItem()
            Me._miQualityModified2 = New System.Windows.Forms.MenuItem()
            Me._miQualityFastModified2 = New System.Windows.Forms.MenuItem()
            Me._miQualityModified3 = New System.Windows.Forms.MenuItem()
            Me._miQualityFastModified3 = New System.Windows.Forms.MenuItem()
            Me._miWindow = New System.Windows.Forms.MenuItem()
            Me._miWindowCascade = New System.Windows.Forms.MenuItem()
            Me._miWindowTileHorizontal = New System.Windows.Forms.MenuItem()
            Me._miWindowTileVertical = New System.Windows.Forms.MenuItem()
            Me._miWindowArrangeIcons = New System.Windows.Forms.MenuItem()
            Me._miHelp = New System.Windows.Forms.MenuItem()
            Me._miHelpAbout = New System.Windows.Forms.MenuItem()
            Me._sbMainStatus = New System.Windows.Forms.StatusBar()
            Me.SuspendLayout()
            '
            '_mmMain
            '
            Me._mmMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFile, Me._miEdit, Me._miView, Me._miQuality, Me._miWindow, Me._miHelp})
            '
            '_miFile
            '
            Me._miFile.Index = 0
            Me._miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFileOpen, Me._miFileClose, Me._miFileSaveCurrentAsAbc, Me._miFileSaveCurrentAsTIFF, Me._miFileSaveAllPagesAsTIFF, Me._FileSeperator1, Me._miFileExit})
            Me._miFile.Text = "&File"
            '
            '_miFileOpen
            '
            Me._miFileOpen.Index = 0
            Me._miFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
            Me._miFileOpen.Text = "&Open..."
            '
            '_miFileClose
            '
            Me._miFileClose.Index = 1
            Me._miFileClose.Text = "&Close"
            '
            '_miFileSaveCurrentAsAbc
            '
            Me._miFileSaveCurrentAsAbc.Index = 2
            Me._miFileSaveCurrentAsAbc.Shortcut = System.Windows.Forms.Shortcut.CtrlS
            Me._miFileSaveCurrentAsAbc.Text = "Save Current As ABC..."
            '
            '_miFileSaveCurrentAsTIFF
            '
            Me._miFileSaveCurrentAsTIFF.Index = 3
            Me._miFileSaveCurrentAsTIFF.Text = "Save Current As TIFF..."
            '
            '_miFileSaveAllPagesAsTIFF
            '
            Me._miFileSaveAllPagesAsTIFF.Index = 4
            Me._miFileSaveAllPagesAsTIFF.Text = "Save All Pages As TIFF..."
            '
            '_FileSeperator1
            '
            Me._FileSeperator1.Index = 5
            Me._FileSeperator1.Text = "-"
            '
            '_miFileExit
            '
            Me._miFileExit.Index = 6
            Me._miFileExit.Shortcut = System.Windows.Forms.Shortcut.CtrlX
            Me._miFileExit.Text = "E&xit"
            '
            '_miEdit
            '
            Me._miEdit.Index = 1
            Me._miEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miEditCopy})
            Me._miEdit.Text = "&Edit"
            '
            '_miEditCopy
            '
            Me._miEditCopy.Index = 0
            Me._miEditCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC
            Me._miEditCopy.Text = "&Copy"
            '
            '_miView
            '
            Me._miView.Index = 2
            Me._miView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miViewNormal, Me._miViewFitToWindow, Me._ViewSeparator1, Me._miViewSnapToImage, Me._ViewSeparator2, Me._miViewZoomIn, Me._miViewZoomOut})
            Me._miView.Text = "&View"
            '
            '_miViewNormal
            '
            Me._miViewNormal.Checked = True
            Me._miViewNormal.Index = 0
            Me._miViewNormal.Shortcut = System.Windows.Forms.Shortcut.CtrlN
            Me._miViewNormal.Text = "&Normal"
            '
            '_miViewFitToWindow
            '
            Me._miViewFitToWindow.Index = 1
            Me._miViewFitToWindow.Text = "&Fit Image To Window"
            '
            '_ViewSeparator1
            '
            Me._ViewSeparator1.Index = 2
            Me._ViewSeparator1.Text = "-"
            '
            '_miViewSnapToImage
            '
            Me._miViewSnapToImage.Index = 3
            Me._miViewSnapToImage.Text = "Sna&p Window To Image"
            '
            '_ViewSeparator2
            '
            Me._ViewSeparator2.Index = 4
            Me._ViewSeparator2.Text = "-"
            '
            '_miViewZoomIn
            '
            Me._miViewZoomIn.Index = 5
            Me._miViewZoomIn.Text = "Zoom &In"
            '
            '_miViewZoomOut
            '
            Me._miViewZoomOut.Index = 6
            Me._miViewZoomOut.Text = "Zoom &Out"
            '
            '_miQuality
            '
            Me._miQuality.Index = 3
            Me._miQuality.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miQualityCombineTwoImages, Me._QualitySeperator1, Me._miQualityLossless, Me._miQualityFastLossless, Me._miQualityVirtualLossless, Me._miQualityFastLossy, Me._miQualityRemoveBorder, Me._miQualityEnhanced, Me._miQualityModified1, Me._miQualityFastModified1, Me._miQualityModified2, Me._miQualityFastModified2, Me._miQualityModified3, Me._miQualityFastModified3})
            Me._miQuality.Text = "&Quality"
            '
            '_miQualityCombineTwoImages
            '
            Me._miQualityCombineTwoImages.Index = 0
            Me._miQualityCombineTwoImages.Text = "Combine Two Images"
            '
            '_QualitySeperator1
            '
            Me._QualitySeperator1.Index = 1
            Me._QualitySeperator1.Text = "-"
            '
            '_miQualityLossless
            '
            Me._miQualityLossless.Index = 2
            Me._miQualityLossless.Text = "Lossless"
            '
            '_miQualityFastLossless
            '
            Me._miQualityFastLossless.Index = 3
            Me._miQualityFastLossless.Text = "Fast Lossless"
            '
            '_miQualityVirtualLossless
            '
            Me._miQualityVirtualLossless.Index = 4
            Me._miQualityVirtualLossless.Text = "Virtual Lossless"
            '
            '_miQualityFastLossy
            '
            Me._miQualityFastLossy.Index = 5
            Me._miQualityFastLossy.Text = "Fast Lossy"
            '
            '_miQualityRemoveBorder
            '
            Me._miQualityRemoveBorder.Index = 6
            Me._miQualityRemoveBorder.Text = "Remove Border "
            '
            '_miQualityEnhanced
            '
            Me._miQualityEnhanced.Index = 7
            Me._miQualityEnhanced.Text = "Enhanced"
            '
            '_miQualityModified1
            '
            Me._miQualityModified1.Index = 8
            Me._miQualityModified1.Text = "Modified 1"
            '
            '_miQualityFastModified1
            '
            Me._miQualityFastModified1.Index = 9
            Me._miQualityFastModified1.Text = "Fast Modified 1"
            '
            '_miQualityModified2
            '
            Me._miQualityModified2.Index = 10
            Me._miQualityModified2.Text = "Modified 2"
            '
            '_miQualityFastModified2
            '
            Me._miQualityFastModified2.Index = 11
            Me._miQualityFastModified2.Text = "Fast Modified 2"
            '
            '_miQualityModified3
            '
            Me._miQualityModified3.Index = 12
            Me._miQualityModified3.Text = "Modified 3"
            '
            '_miQualityFastModified3
            '
            Me._miQualityFastModified3.Index = 13
            Me._miQualityFastModified3.Text = "Fast Modified 3"
            '
            '_miWindow
            '
            Me._miWindow.Index = 4
            Me._miWindow.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miWindowCascade, Me._miWindowTileHorizontal, Me._miWindowTileVertical, Me._miWindowArrangeIcons})
            Me._miWindow.Text = "&Window"
            '
            '_miWindowCascade
            '
            Me._miWindowCascade.Index = 0
            Me._miWindowCascade.Text = "&Cascade"
            '
            '_miWindowTileHorizontal
            '
            Me._miWindowTileHorizontal.Index = 1
            Me._miWindowTileHorizontal.Text = "Tile &Horizontal"
            '
            '_miWindowTileVertical
            '
            Me._miWindowTileVertical.Index = 2
            Me._miWindowTileVertical.Text = "Tile &Vertical"
            '
            '_miWindowArrangeIcons
            '
            Me._miWindowArrangeIcons.Index = 3
            Me._miWindowArrangeIcons.Text = "&Arrange Icons"
            '
            '_miHelp
            '
            Me._miHelp.Index = 5
            Me._miHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miHelpAbout})
            Me._miHelp.Text = "&Help"
            '
            '_miHelpAbout
            '
            Me._miHelpAbout.Index = 0
            Me._miHelpAbout.Text = "&About..."
            '
            '_sbMainStatus
            '
            Me._sbMainStatus.Location = New System.Drawing.Point(0, 449)
            Me._sbMainStatus.Name = "_sbMainStatus"
            Me._sbMainStatus.Size = New System.Drawing.Size(712, 22)
            Me._sbMainStatus.TabIndex = 1
            '
            'MainForm
            '
            Me.AllowDrop = True
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(712, 471)
            Me.Controls.Add(Me._sbMainStatus)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.IsMdiContainer = True
            Me.Menu = Me._mmMain
            Me.Name = "MainForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "MainForm"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.ResumeLayout(False)

        End Sub
#End Region

      Private _codecs As RasterCodecs
      Private _paintProperties As RasterPaintProperties
      Private _viewerOpened As Boolean
      Private _fileName As String
      Private _quality As String
      Private _showSave As Boolean
      Private _previousCheckQuality As MenuItem
      Private _stopSaving As Boolean

      Private Shared ReadOnly _minimumScaleFactor As Single = 0.05F
      Private Shared ReadOnly _maximumScaleFactor As Single = 11.0F

      Private Const _saveDirectory As String = "c:\Temp"
      Private Const _saveFileName As String = _saveDirectory & "\preview"
      Private Const _saveFileNameG4 As String = _saveDirectory & "\preview.g4"

      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      <STAThread()> _
      Shared Sub Main()

         If Not Support.SetLicense() Then
            Return
         End If

         Application.Run(New MainForm())
      End Sub

      Private Sub InitClass()
         Messager.Caption = "LEADTOOLS for .NET VB ABC Demo"
         Text = Messager.Caption

         _codecs = New RasterCodecs()

         _paintProperties = RasterPaintProperties.Default
         _paintProperties.PaintDisplayMode = _paintProperties.PaintDisplayMode Or RasterPaintDisplayModeFlags.ScaleToGray
         _paintProperties.PaintEngine = RasterPaintEngine.GdiPlus

         _showSave = False
         _viewerOpened = False

         _quality = "(Lossless)"

         setCheckWindow(_miWindowCascade)

         LoadImage(True)
         UpdateControls()
      End Sub

      Public Property StopSaving() As Boolean
         Get
            Return _stopSaving
         End Get
         Set(value As Boolean)
            _stopSaving = Value
         End Set
      End Property

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

      Public ReadOnly Property ActiveViewerForm() As ViewerForm
         Get
            Return TryCast(ActiveMdiChild, ViewerForm)
         End Get
      End Property

      Public WriteOnly Property ViewerOpened() As Boolean
         Set(value As Boolean)
            _viewerOpened = Value
         End Set
      End Property

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
      Public WriteOnly Property ShowSave() As Boolean
         Set(value As Boolean)
            _showSave = Value
         End Set
      End Property
      Public ReadOnly Property PreviousCheckQuality() As MenuItem
         Get
            Return _previousCheckQuality
         End Get
      End Property

      Public Sub UpdateControls()
         Dim activeForm As ViewerForm = ActiveViewerForm

         EnableAndVisibleMenu(_miFileSaveCurrentAsAbc, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miFileSaveCurrentAsTIFF, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miFileSaveAllPagesAsTIFF, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miFileClose, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miEdit, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miView, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miQuality, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miWindow, Not activeForm Is Nothing)

         _miFileSaveCurrentAsAbc.Enabled = _showSave
         _miFileSaveAllPagesAsTIFF.Enabled = _showSave
         _miFileSaveCurrentAsTIFF.Enabled = _showSave

         If Not activeForm Is Nothing Then
            _miViewNormal.Checked = activeForm.Viewer.SizeMode <> ControlSizeMode.Fit
            _miViewFitToWindow.Checked = activeForm.Viewer.SizeMode = ControlSizeMode.Fit
         End If
      End Sub

      Private Sub EnableAndVisibleMenu(ByVal menu As MenuItem, ByVal value As Boolean)
         menu.Enabled = value
         menu.Visible = value
      End Sub

      Private Sub NewImage(ByVal info As ImageInformation, ByVal originalViewer As Boolean)
         Dim child As ViewerForm = New ViewerForm()
         child.MdiParent = Me
         child.Initialize(info, _paintProperties, True)
         child.OriginalViewer = originalViewer
         child.Show()
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
                        Dim activeViewer As ViewerForm = ActiveViewerForm

                        _fileName = info.Name
                        info.Name &= " (Original)"

                        If (Not _viewerOpened) Then
                           NewImage(info, True)
                           _viewerOpened = True
                        Else
                           activeViewer.Image = info.Image
                           activeViewer.Text = info.Name
                           If Not (CType(MdiChildren(0), ViewerForm)).OriginalViewer Then
                              MdiChildren(0).Close()
                           End If

                           If MdiChildren.Length > 1 Then
                              If Not (CType(MdiChildren(1), ViewerForm)).OriginalViewer Then
                                 MdiChildren(1).Close()
                              End If
                           End If

                           ShowSave = False
                           If Not PreviousCheckQuality Is Nothing Then
                              PreviousCheckQuality.Checked = False
                           End If
                        End If
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

      Private Sub MainForm_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.MdiChildActivate
         UpdateControls()
      End Sub

      Private Sub _miFile_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFile.Popup
         If MdiChildren.Length <> 0 Then
            If (CType(MdiChildren(0), ViewerForm)).OriginalViewer Then
               CType(MdiChildren(0), ViewerForm).Activate()
            Else
               CType(MdiChildren(1), ViewerForm).Activate()
            End If
         End If
      End Sub

      Private Sub LoadImage(ByVal loadDefaultImage As Boolean)
         Dim loader As ImageFileLoader = New ImageFileLoader()
         Dim activeViewer As ViewerForm = ActiveViewerForm

         Try
            Dim info As ImageInformation = Nothing

            If loadDefaultImage Then

               If loader.Load(Me, DemosGlobal.ImagesFolder & "\clean.tif", _codecs, 1, 1) Then
                  info = New ImageInformation(loader.Image, loader.FileName)
               End If
            Else
               Dim filesCount As Integer = loader.Load(Me, _codecs, True)
               If filesCount > 0 AndAlso Not loader.Images(0) Is Nothing Then
                  info = loader.Images(0)
               End If
            End If

            If Not info Is Nothing Then
               If info.Image.HasRegion Then
                  info.Image.MakeRegionEmpty()
               End If

               _fileName = info.Name
               info.Name &= " (Original)"

               If (Not _viewerOpened) Then
                  NewImage(info, True)
                  _viewerOpened = True
               Else
                  activeViewer.Image = info.Image
                  activeViewer.Text = info.Name
                  If Not (CType(MdiChildren(0), ViewerForm)).OriginalViewer Then
                     MdiChildren(0).Close()
                  End If

                  If MdiChildren.Length > 1 Then
                     If Not (CType(MdiChildren(1), ViewerForm)).OriginalViewer Then
                        MdiChildren(1).Close()
                     End If
                  End If

                  ShowSave = False
                  If Not PreviousCheckQuality Is Nothing Then
                     PreviousCheckQuality.Checked = False
                  End If
               End If
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateControls()
         End Try
      End Sub

      Private Sub _miFileOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileOpen.Click
         LoadImage(False)
      End Sub

      Private Sub _miFileClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileClose.Click
         Dim activeViewer As ViewerForm = ActiveViewerForm

         activeViewer.Close()
      End Sub

      Private Sub _miFileSaveCurrentAsAbc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileSaveCurrentAsAbc.Click
         Dim saveDlg As SaveFileDialog = New SaveFileDialog()
         saveDlg.FileName = _fileName.Remove(_fileName.Length - 4, 4)
         saveDlg.OverwritePrompt = True

         Dim formatString As String = _quality
         formatString = (formatString.Trim()).Substring(1, formatString.Length - 3)

         saveDlg.FileName &= "_Abc_" & formatString & ".abc"
         saveDlg.Title = "Save As ABC (LEAD ABC Format)"
         saveDlg.Filter = "LEAD ABC Format (*.abc)|*.abc"

         Try
            If saveDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
               Dim activeViewer As ViewerForm = ActiveViewerForm
               _codecs.Save(activeViewer.Image, saveDlg.FileName, RasterImageFormat.Abc, 1)
            End If
         Catch ex As Exception
            Messager.ShowFileSaveError(Me, saveDlg.FileName, ex)
         End Try
      End Sub

      Private Sub _miFileSaveCurrentAsTIFF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileSaveCurrentAsTIFF.Click
         Dim saveDlg As SaveFileDialog = New SaveFileDialog()
         saveDlg.FileName = _fileName.Remove(_fileName.Length - 4, 4)
         saveDlg.OverwritePrompt = True

         Dim formatString As String = _quality
         formatString = (formatString.Trim()).Substring(1, formatString.Length - 3)

         saveDlg.FileName &= "_Tiff_" & formatString & ".tif"
         saveDlg.Title = "Save As TIFF (TIFF LEAD ABC Format)"
         saveDlg.Filter = "TIFF LEAD ABC Format (*.tif)|*.tif"

         Try
            If saveDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
               Dim activeViewer As ViewerForm = ActiveViewerForm
               _codecs.Save(activeViewer.Image, saveDlg.FileName, RasterImageFormat.TifAbc, 1, 1, 1, 1, CodecsSavePageMode.Append)
            End If
         Catch ex As Exception
            Messager.ShowFileSaveError(Me, saveDlg.FileName, ex)
         End Try
      End Sub

      Private Sub _miFileSaveAllPagesAsTIFF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileSaveAllPagesAsTIFF.Click
         Dim saveDlg As SaveFileDialog = New SaveFileDialog()
         saveDlg.FileName = _fileName.Remove(_fileName.Length - 4, 4)
         saveDlg.OverwritePrompt = True

         Dim formatString As String = _quality
         formatString = (formatString.Trim()).Substring(1, formatString.Length - 3)

         saveDlg.FileName &= "_M_" & formatString & ".tif"
         saveDlg.Title = "Save All Pages (TIFF LEAD ABC Format)"
         saveDlg.Filter = "TIFF LEAD ABC Format (*.tif)|*.tif"

         Using wait As WaitCursor = New WaitCursor()
            Try
               If saveDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                  If File.Exists(saveDlg.FileName) Then
                     File.Delete(saveDlg.FileName)
                  End If

                  Dim index As Integer
                  Dim cmd As CombineCommand = New CombineCommand()
                  Dim newWidth As Integer
                  Dim newHeight As Integer
                  Dim loopStep As Integer
                  If (_miQualityCombineTwoImages.Checked) Then
                     loopStep = 2
                  Else
                     loopStep = 1
                  End If

                  Dim fullImage As RasterImage = _codecs.Load(_fileName, 0, CodecsLoadByteOrder.BgrOrGray, 1, -1)
                  If fullImage.HasRegion Then
                     fullImage.MakeRegionEmpty()
                  End If

                  StopSaving = False

                  index = 1
                  Do While index <= fullImage.PageCount AndAlso Not StopSaving
                     _sbMainStatus.Text = String.Format("Saving page {0}/{1}. Press Esc to cancel.", index, fullImage.PageCount)

                     newWidth = 0
                     newHeight = 0

                     fullImage.Page = index
                     newWidth = fullImage.Width
                     newHeight = fullImage.Height

                     If index + 1 > fullImage.PageCount OrElse (Not _miQualityCombineTwoImages.Checked) Then
                        Dim newImage_Renamed As RasterImage = fullImage.Clone()
                        _codecs.Save(newImage_Renamed, saveDlg.FileName, RasterImageFormat.TifAbc, 1, 1, 1, 1, CodecsSavePageMode.Append)
                     Else
                        fullImage.Page = index + 1
                        newWidth = Math.Max(newWidth, fullImage.Width)
                        newHeight += fullImage.Height
                        Dim newImage_Renamed As RasterImage = New RasterImage(RasterMemoryFlags.Conventional, newWidth, newHeight, 24, RasterByteOrder.Bgr, RasterViewPerspective.TopLeft, Nothing, IntPtr.Zero, 0)

                        fullImage.Page = index

                        cmd.SourceImage = fullImage
                        cmd.DestinationRectangle = New LeadRect(0, 0, fullImage.Width, fullImage.Height)
                        cmd.Run(newImage_Renamed)

                        fullImage.Page = index + 1

                        cmd.SourceImage = fullImage
                        cmd.DestinationRectangle = New LeadRect(0, newHeight - fullImage.Height, fullImage.Width, fullImage.Height)
                        cmd.Run(newImage_Renamed)

                        _codecs.Save(newImage_Renamed, saveDlg.FileName, RasterImageFormat.TifAbc, 1, 1, 1, 1, CodecsSavePageMode.Append)
                     End If
                     Application.DoEvents()
                     index += loopStep
                  Loop
                  fullImage.Page = 1
               End If
            Catch ex As Exception
               Messager.ShowFileSaveError(Me, saveDlg.FileName, ex)
            End Try
            _sbMainStatus.Text = ""
         End Using
      End Sub

      Private Sub _miFileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileExit.Click
         Close()
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

      Private Sub _miView_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miView.Popup
         Dim activeForm As ViewerForm = ActiveViewerForm
         _miViewFitToWindow.Checked = False
         _miViewNormal.Checked = False
         If activeForm.Viewer.SizeMode = ControlSizeMode.Fit Then
            _miViewFitToWindow.Checked = True
         ElseIf activeForm.Viewer.SizeMode = ControlSizeMode.ActualSize Then
            _miViewNormal.Checked = True
         End If
      End Sub


      Public Sub _miView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miViewNormal.Click, _miViewFitToWindow.Click, _miViewSnapToImage.Click, _miViewZoomIn.Click, _miViewZoomOut.Click
         ' get the current center in logical units
         Dim viewer As ImageViewer = ActiveViewerForm.Viewer ' get the active viewer

         ' zoom     
         Dim scaleFactor As Double = viewer.ScaleFactor
         Dim sizeMode As ControlSizeMode = ControlSizeMode.None
         Const ratio As Single = 1.2F

         If sender Is _miViewZoomIn Then
            sizeMode = ControlSizeMode.None
            scaleFactor *= ratio
         ElseIf sender Is _miViewZoomOut Then
            sizeMode = ControlSizeMode.None
            scaleFactor /= ratio
         ElseIf sender Is _miViewNormal Then
            sizeMode = ControlSizeMode.ActualSize
            scaleFactor = 1.0
         ElseIf sender Is _miViewFitToWindow Then
            sizeMode = ControlSizeMode.Fit
            scaleFactor = 1.0
         ElseIf sender Is _miViewSnapToImage Then
            Dim activeViewer As ViewerForm = ActiveViewerForm
            activeViewer.Snap()
            If activeViewer.WindowState <> FormWindowState.Normal Then
               activeViewer.WindowState = FormWindowState.Normal
            End If
         End If

         scaleFactor = Math.Max(_minimumScaleFactor, Math.Min(_maximumScaleFactor, scaleFactor))

         If (viewer.ScaleFactor <> scaleFactor) OrElse (Not viewer.SizeMode = sizeMode) Then
            viewer.Zoom(sizeMode, scaleFactor, viewer.DefaultZoomOrigin)
         End If
      End Sub

      Private Sub _miQualityCombineTwoImages_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miQualityCombineTwoImages.Click
         _miQualityCombineTwoImages.Checked = Not _miQualityCombineTwoImages.Checked
      End Sub

      Private Sub _miQuality_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miQualityLossless.Click, _miQualityFastLossless.Click, _miQualityVirtualLossless.Click, _miQualityFastLossy.Click, _miQualityRemoveBorder.Click, _miQualityEnhanced.Click, _miQualityModified1.Click, _miQualityFastModified1.Click, _miQualityModified2.Click, _miQualityFastModified2.Click, _miQualityModified3.Click, _miQualityFastModified3.Click
         Dim wait As WaitCursor = New WaitCursor()

         If Not (CType(MdiChildren(0), ViewerForm)).OriginalViewer Then
            MdiChildren(0).Close()
         End If

         If MdiChildren.Length > 1 Then
            If Not (CType(MdiChildren(1), ViewerForm)).OriginalViewer Then
               MdiChildren(1).Close()
            End If
         End If

         CType(MdiChildren(0), ViewerForm).Activate()

         If (Not Directory.Exists(_saveDirectory)) Then
            Directory.CreateDirectory(_saveDirectory)
         End If

         If File.Exists(_saveFileName) Then
            File.Delete(_saveFileName)
         End If

         If File.Exists(_saveFileNameG4) Then
            File.Delete(_saveFileNameG4)
         End If

         If sender Is _miQualityLossless Then
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.Lossless
            _quality = " (Lossless)"
         ElseIf sender Is _miQualityFastLossless Then
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.LosslessFast
            _quality = " (Fast Lossless)"
         ElseIf sender Is _miQualityFastLossy Then
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.LossyFast
            _quality = " (Fast Lossy)"
         ElseIf sender Is _miQualityVirtualLossless Then
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.VirtualLossless
            _quality = " (Virtual Lossless)"
         ElseIf sender Is _miQualityRemoveBorder Then
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.RemoveBorder
            _quality = " (Remove Border)"
         ElseIf sender Is _miQualityEnhanced Then
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.Enhance
            _quality = " (Enhance)"
         ElseIf sender Is _miQualityModified1 Then
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.Modified1
            _quality = " (Modified1)"
         ElseIf sender Is _miQualityFastModified1 Then
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.Modified1Fast
            _quality = " (Fast Modified1)"
         ElseIf sender Is _miQualityModified2 Then
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.Modified2
            _quality = " (Modified2)"
         ElseIf sender Is _miQualityFastModified2 Then
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.Modified2Fast
            _quality = " (Fast Modified2)"
         ElseIf sender Is _miQualityModified3 Then
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.Modified3
            _quality = " (Modified3)"
         ElseIf sender Is _miQualityFastModified3 Then
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.Modified3Fast
            _quality = " (Fast Modified3)"
         End If

         Dim tempFileName As String = _saveFileName

         If Not _previousCheckQuality Is Nothing Then
            _previousCheckQuality.Checked = False
         End If

         _previousCheckQuality = CType(sender, MenuItem)
         _previousCheckQuality.Checked = True

         Try
            Dim activeViewer As ViewerForm = ActiveViewerForm

            _codecs.Save(activeViewer.Image, _saveFileName, RasterImageFormat.Abc, 1)

            tempFileName = _saveFileNameG4

            _codecs.Save(activeViewer.Image, _saveFileNameG4, RasterImageFormat.CcittGroup4, 1)

            Dim savedImageInformation As ImageInformation = New ImageInformation(_codecs.Load(_saveFileName), _saveFileName)

            savedImageInformation.Name += _quality

            NewImage(savedImageInformation, False)

            LayoutMdi(MdiLayout.TileVertical)
            setCheckWindow(_miWindowTileVertical)

            Dim fileInformation As FileInfo = New FileInfo(_saveFileName)

            Dim previewSize As Long = fileInformation.Length

            fileInformation = New FileInfo(_saveFileNameG4)

            Dim previewG4Size As Long = fileInformation.Length

            Dim improvement As Integer = CInt((CDbl(previewG4Size) / previewSize) * 10000.0 - 10000)

            Messager.ShowInformation(Me, String.Format("CCITT G4: {1:#,##0} bytes{0}LEAD ABC: {2:#,##0} bytes{0}{0}{3:0.00}% Reduction", Environment.NewLine, previewG4Size, previewSize, improvement / 100.0))
            _showSave = True
         Catch ex As Exception
            Messager.ShowFileSaveError(Me, tempFileName, ex)
         End Try
         wait.Dispose()
         UpdateControls()
      End Sub

      Private Sub setCheckWindow(ByVal menuItem As MenuItem)
         _miWindowCascade.Checked = False
         _miWindowTileHorizontal.Checked = False
         _miWindowTileVertical.Checked = False
         _miWindowArrangeIcons.Checked = False

         menuItem.Checked = True
      End Sub

      Private Sub _miWindow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miWindowCascade.Click, _miWindowTileHorizontal.Click, _miWindowTileVertical.Click, _miWindowArrangeIcons.Click
         If sender Is _miWindowCascade Then
            LayoutMdi(MdiLayout.Cascade)
         ElseIf sender Is _miWindowTileHorizontal Then
            LayoutMdi(MdiLayout.TileHorizontal)
         ElseIf sender Is _miWindowTileVertical Then
            LayoutMdi(MdiLayout.TileVertical)
         ElseIf sender Is _miWindowArrangeIcons Then
            LayoutMdi(MdiLayout.ArrangeIcons)
         End If

         setCheckWindow(CType(sender, MenuItem))
      End Sub

      Private Sub _miHelpAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miHelpAbout.Click
         Using aboutDialog As New AboutDialog("Abc", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using

      End Sub
   End Class
End Namespace
