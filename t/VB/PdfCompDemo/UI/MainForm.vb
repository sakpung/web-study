' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports System.Data

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.Drawing
Imports Leadtools.ImageProcessing
Imports Leadtools.Mrc
Imports Leadtools.PdfCompressor
Imports Leadtools.WinForms.CommonDialogs.File
Imports Leadtools.Demos.Dialogs

''' <summary>
''' Summary description for Form1.
''' </summary>
Public Class MainForm : Inherits System.Windows.Forms.Form
   Private _miFile As System.Windows.Forms.MenuItem
   Private _mmMain As System.Windows.Forms.MainMenu
   Private WithEvents _miFileOpen As System.Windows.Forms.MenuItem
   Private WithEvents _miFileSave As System.Windows.Forms.MenuItem
   Private _miPdfOptions As System.Windows.Forms.MenuItem
   Private WithEvents _miWindow As System.Windows.Forms.MenuItem
   Private _miHelp As System.Windows.Forms.MenuItem
   Private WithEvents _miHelpAbout As System.Windows.Forms.MenuItem
   Private WithEvents _miWindowCascade As System.Windows.Forms.MenuItem
   Private WithEvents _miWindowTileHorizontally As System.Windows.Forms.MenuItem
   Private WithEvents _miWindowTileVertically As System.Windows.Forms.MenuItem
   Private WithEvents _miWindowArrangeIcons As System.Windows.Forms.MenuItem
   Private WithEvents _miWindowCloseAll As System.Windows.Forms.MenuItem
   Private WithEvents _miPdfOptionsAdd As System.Windows.Forms.MenuItem
   Private WithEvents _miPdfOptionsModify As System.Windows.Forms.MenuItem
   Private WithEvents _miPdfOptionsDelete As System.Windows.Forms.MenuItem
   Private menuItem4 As System.Windows.Forms.MenuItem
   Private WithEvents _miPdfOptionsAdvanced As System.Windows.Forms.MenuItem
   Private WithEvents _tbMain As System.Windows.Forms.ToolBar
   Private _tbbFileOpen As System.Windows.Forms.ToolBarButton
   Private _tbbFileSave As System.Windows.Forms.ToolBarButton
   Private _tbbPdfOptionsAdd As System.Windows.Forms.ToolBarButton
   Private _tbbPdfOptionsDelete As System.Windows.Forms.ToolBarButton
   Private _tbbHelpAbout As System.Windows.Forms.ToolBarButton
   Private _tbbPdfOptionsModify As System.Windows.Forms.ToolBarButton
   Private WithEvents _miFilePrint As System.Windows.Forms.MenuItem
   Private WithEvents _miFilePrintPreview As System.Windows.Forms.MenuItem
   Private _miSparator1 As System.Windows.Forms.MenuItem
   Private _miSparator2 As System.Windows.Forms.MenuItem
   Private WithEvents menuItem2 As System.Windows.Forms.MenuItem
   Private components As IContainer

   Public Sub New()
      '
      ' Required for Windows Form Designer support
      '
      InitializeComponent()

      '
      ' TODO: Add any constructor code after InitializeComponent call
      '
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
      Me._miFileSave = New System.Windows.Forms.MenuItem()
      Me._miSparator1 = New System.Windows.Forms.MenuItem()
      Me._miFilePrint = New System.Windows.Forms.MenuItem()
      Me._miFilePrintPreview = New System.Windows.Forms.MenuItem()
      Me._miSparator2 = New System.Windows.Forms.MenuItem()
      Me.menuItem2 = New System.Windows.Forms.MenuItem()
      Me._miPdfOptions = New System.Windows.Forms.MenuItem()
      Me._miPdfOptionsAdd = New System.Windows.Forms.MenuItem()
      Me._miPdfOptionsModify = New System.Windows.Forms.MenuItem()
      Me._miPdfOptionsDelete = New System.Windows.Forms.MenuItem()
      Me.menuItem4 = New System.Windows.Forms.MenuItem()
      Me._miPdfOptionsAdvanced = New System.Windows.Forms.MenuItem()
      Me._miWindow = New System.Windows.Forms.MenuItem()
      Me._miWindowCascade = New System.Windows.Forms.MenuItem()
      Me._miWindowTileHorizontally = New System.Windows.Forms.MenuItem()
      Me._miWindowTileVertically = New System.Windows.Forms.MenuItem()
      Me._miWindowArrangeIcons = New System.Windows.Forms.MenuItem()
      Me._miWindowCloseAll = New System.Windows.Forms.MenuItem()
      Me._miHelp = New System.Windows.Forms.MenuItem()
      Me._miHelpAbout = New System.Windows.Forms.MenuItem()
      Me._tbMain = New System.Windows.Forms.ToolBar()
      Me._tbbFileOpen = New System.Windows.Forms.ToolBarButton()
      Me._tbbFileSave = New System.Windows.Forms.ToolBarButton()
      Me._tbbPdfOptionsAdd = New System.Windows.Forms.ToolBarButton()
      Me._tbbPdfOptionsModify = New System.Windows.Forms.ToolBarButton()
      Me._tbbPdfOptionsDelete = New System.Windows.Forms.ToolBarButton()
      Me._tbbHelpAbout = New System.Windows.Forms.ToolBarButton()
      Me.SuspendLayout()
      ' 
      ' _mmMain
      ' 
      Me._mmMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFile, Me._miPdfOptions, Me._miWindow, Me._miHelp})
      ' 
      ' _miFile
      ' 
      Me._miFile.Index = 0
      Me._miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFileOpen, Me._miFileSave, Me._miSparator1, Me._miFilePrint, Me._miFilePrintPreview, Me._miSparator2, Me.menuItem2})
      Me._miFile.Text = "&File"
      ' 
      ' _miFileOpen
      ' 
      Me._miFileOpen.Index = 0
      Me._miFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
      Me._miFileOpen.Text = "&Open"
      '		 Me._miFileOpen.Click += New System.EventHandler(Me._miFileOpen_Click);
      ' 
      ' _miFileSave
      ' 
      Me._miFileSave.Index = 1
      Me._miFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
      Me._miFileSave.Text = "&Save all"
      '		 Me._miFileSave.Click += New System.EventHandler(Me._miFileSave_Click);
      ' 
      ' _miSparator1
      ' 
      Me._miSparator1.Index = 2
      Me._miSparator1.Text = "-"
      ' 
      ' _miFilePrint
      ' 
      Me._miFilePrint.Index = 3
      Me._miFilePrint.Text = "&Print"
      '		 Me._miFilePrint.Click += New System.EventHandler(Me._miFilePrint_Click);
      ' 
      ' _miFilePrintPreview
      ' 
      Me._miFilePrintPreview.Index = 4
      Me._miFilePrintPreview.Text = "Print Pre&view..."
      '		 Me._miFilePrintPreview.Click += New System.EventHandler(Me._miFilePrintPreview_Click);
      ' 
      ' _miSparator2
      ' 
      Me._miSparator2.Index = 5
      Me._miSparator2.Text = "-"
      ' 
      ' menuItem2
      ' 
      Me.menuItem2.Index = 6
      Me.menuItem2.Text = "E&xit"
      '		 Me.menuItem2.Click += New System.EventHandler(Me.menuItem2_Click);
      ' 
      ' _miPdfOptions
      ' 
      Me._miPdfOptions.Index = 1
      Me._miPdfOptions.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miPdfOptionsAdd, Me._miPdfOptionsModify, Me._miPdfOptionsDelete, Me.menuItem4, Me._miPdfOptionsAdvanced})
      Me._miPdfOptions.Text = "&Pdf Options"
      ' 
      ' _miPdfOptionsAdd
      ' 
      Me._miPdfOptionsAdd.Index = 0
      Me._miPdfOptionsAdd.Shortcut = System.Windows.Forms.Shortcut.CtrlA
      Me._miPdfOptionsAdd.Text = "&Add Image->Pdf"
      '		 Me._miPdfOptionsAdd.Click += New System.EventHandler(Me._miPdfOptionsAdd_Click);
      ' 
      ' _miPdfOptionsModify
      ' 
      Me._miPdfOptionsModify.Index = 1
      Me._miPdfOptionsModify.Shortcut = System.Windows.Forms.Shortcut.CtrlM
      Me._miPdfOptionsModify.Text = "&Modify Pdf Settings"
      '		 Me._miPdfOptionsModify.Click += New System.EventHandler(Me._miPdfOptionsAdd_Click);
      ' 
      ' _miPdfOptionsDelete
      ' 
      Me._miPdfOptionsDelete.Index = 2
      Me._miPdfOptionsDelete.Shortcut = System.Windows.Forms.Shortcut.CtrlD
      Me._miPdfOptionsDelete.Text = "&Delete Image->Pdf"
      '		 Me._miPdfOptionsDelete.Click += New System.EventHandler(Me._miPdfOptionsDelete_Click);
      ' 
      ' menuItem4
      ' 
      Me.menuItem4.Index = 3
      Me.menuItem4.Text = "-"
      ' 
      ' _miPdfOptionsAdvanced
      ' 
      Me._miPdfOptionsAdvanced.Index = 4
      Me._miPdfOptionsAdvanced.Shortcut = System.Windows.Forms.Shortcut.CtrlV
      Me._miPdfOptionsAdvanced.Text = "Ad&vanced"
      '		 Me._miPdfOptionsAdvanced.Click += New System.EventHandler(Me._miPdfOptionsAdvanced_Click);
      ' 
      ' _miWindow
      ' 
      Me._miWindow.Index = 2
      Me._miWindow.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miWindowCascade, Me._miWindowTileHorizontally, Me._miWindowTileVertically, Me._miWindowArrangeIcons, Me._miWindowCloseAll})
      Me._miWindow.Text = "&Window"
      '		 Me._miWindow.Click += New System.EventHandler(Me._miWindow_Click);
      ' 
      ' _miWindowCascade
      ' 
      Me._miWindowCascade.Index = 0
      Me._miWindowCascade.Text = "&Cascade"
      '		 Me._miWindowCascade.Click += New System.EventHandler(Me._miWindow_Click);
      ' 
      ' _miWindowTileHorizontally
      ' 
      Me._miWindowTileHorizontally.Index = 1
      Me._miWindowTileHorizontally.Text = "Tile &Horizontally"
      '		 Me._miWindowTileHorizontally.Click += New System.EventHandler(Me._miWindow_Click);
      ' 
      ' _miWindowTileVertically
      ' 
      Me._miWindowTileVertically.Index = 2
      Me._miWindowTileVertically.Text = "Tile &Vertically"
      '		 Me._miWindowTileVertically.Click += New System.EventHandler(Me._miWindow_Click);
      ' 
      ' _miWindowArrangeIcons
      ' 
      Me._miWindowArrangeIcons.Index = 3
      Me._miWindowArrangeIcons.Text = "Arrange &Icons"
      '		 Me._miWindowArrangeIcons.Click += New System.EventHandler(Me._miWindow_Click);
      ' 
      ' _miWindowCloseAll
      ' 
      Me._miWindowCloseAll.Index = 4
      Me._miWindowCloseAll.Text = "Close &All"
      '		 Me._miWindowCloseAll.Click += New System.EventHandler(Me._miWindow_Click);
      ' 
      ' _miHelp
      ' 
      Me._miHelp.Index = 3
      Me._miHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miHelpAbout})
      Me._miHelp.Text = "&Help"
      ' 
      ' _miHelpAbout
      ' 
      Me._miHelpAbout.Index = 0
      Me._miHelpAbout.Text = "&About"
      '		 Me._miHelpAbout.Click += New System.EventHandler(Me._miHelpAbout_Click);
      ' 
      ' _tbMain
      ' 
      Me._tbMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me._tbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me._tbbFileOpen, Me._tbbFileSave, Me._tbbPdfOptionsAdd, Me._tbbPdfOptionsModify, Me._tbbPdfOptionsDelete, Me._tbbHelpAbout})
      Me._tbMain.ButtonSize = New System.Drawing.Size(24, 22)
      Me._tbMain.DropDownArrows = True
      Me._tbMain.Location = New System.Drawing.Point(0, 0)
      Me._tbMain.Name = "_tbMain"
      Me._tbMain.ShowToolTips = True
      Me._tbMain.Size = New System.Drawing.Size(711, 28)
      Me._tbMain.TabIndex = 0
      '		 Me._tbMain.ButtonClick += New System.Windows.Forms.ToolBarButtonClickEventHandler(Me._tbMain_ButtonClick);
      ' 
      ' _tbbFileOpen
      ' 
      Me._tbbFileOpen.ImageIndex = 0
      Me._tbbFileOpen.Name = "_tbbFileOpen"
      Me._tbbFileOpen.ToolTipText = "Open"
      ' 
      ' _tbbFileSave
      ' 
      Me._tbbFileSave.ImageIndex = 1
      Me._tbbFileSave.Name = "_tbbFileSave"
      Me._tbbFileSave.ToolTipText = "Save all added images"
      ' 
      ' _tbbPdfOptionsAdd
      ' 
      Me._tbbPdfOptionsAdd.ImageIndex = 2
      Me._tbbPdfOptionsAdd.Name = "_tbbPdfOptionsAdd"
      Me._tbbPdfOptionsAdd.ToolTipText = "Add image to Pdf file"
      ' 
      ' _tbbPdfOptionsModify
      ' 
      Me._tbbPdfOptionsModify.ImageIndex = 3
      Me._tbbPdfOptionsModify.Name = "_tbbPdfOptionsModify"
      Me._tbbPdfOptionsModify.ToolTipText = "Modify Image settings"
      ' 
      ' _tbbPdfOptionsDelete
      ' 
      Me._tbbPdfOptionsDelete.ImageIndex = 4
      Me._tbbPdfOptionsDelete.Name = "_tbbPdfOptionsDelete"
      Me._tbbPdfOptionsDelete.ToolTipText = "Delete Image from queue"
      ' 
      ' _tbbHelpAbout
      ' 
      Me._tbbHelpAbout.ImageIndex = 5
      Me._tbbHelpAbout.Name = "_tbbHelpAbout"
      Me._tbbHelpAbout.ToolTipText = "About Pdf Compressor"
      ' 
      ' MainForm
      ' 
      Me.AllowDrop = True
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(711, 470)
      Me.Controls.Add(Me._tbMain)
      Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
      Me.IsMdiContainer = True
      Me.Menu = Me._mmMain
      Me.Name = "MainForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "MainForm"
      '		 Me.DragDrop += New System.Windows.Forms.DragEventHandler(Me.MainForm_DragDrop);
      '		 Me.MdiChildActivate += New System.EventHandler(Me.MainForm_MdiChildActivate);
      '		 Me.DragEnter += New System.Windows.Forms.DragEventHandler(Me.MainForm_DragEnter);
      '		 Me.Load += New System.EventHandler(Me.MainForm_Load);
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
#End Region

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

   Public ReadOnly Property ActiveViewerForm() As ViewerForm
      Get
         Return TryCast(ActiveMdiChild, ViewerForm)
      End Get
   End Property

   ' the raster codecs used in load/save
   Private _codecs As RasterCodecs
   Private _paintProperties As RasterPaintProperties
   Private _printDocument As PrintDocument


   Private Sub NewImage(ByVal info As ImageInformation)
      Dim child As ViewerForm = New ViewerForm()
      child.StandardOptions = New PdfStandardOptions()
      child.AdvancedOptions = New PdfAdvancedOptions()
      child.MdiParent = Me
      _paintProperties = RasterPaintProperties.Default
      child.Initialize(info, _paintProperties, True)
      child.Show()
   End Sub

   Private Sub _miFileOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileOpen.Click
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

   Private Function LoadImage() As ImageInformation
      Dim loader As PdfImageFileLoader = New PdfImageFileLoader()

      Try
         If loader.Load(Me, _codecs, True) Then

            If loader.Image.HasRegion Then
               loader.Image.MakeRegionEmpty()
            End If
            Return New ImageInformation(loader.Image, loader.FileName)
         End If
      Catch ex As Exception
         Messager.ShowFileOpenError(Me, loader.FileName, ex)
      End Try

      Return Nothing
   End Function

   Private Sub _miWindow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miWindow.Click, _miWindowCascade.Click, _miWindowTileHorizontally.Click, _miWindowTileVertically.Click, _miWindowArrangeIcons.Click, _miWindowCloseAll.Click
      If sender Is _miWindowCascade Then
         LayoutMdi(MdiLayout.Cascade)
      ElseIf sender Is _miWindowTileHorizontally Then
         LayoutMdi(MdiLayout.TileHorizontal)
      ElseIf sender Is _miWindowTileVertically Then
         LayoutMdi(MdiLayout.TileVertical)
      ElseIf sender Is _miWindowArrangeIcons Then
         LayoutMdi(MdiLayout.ArrangeIcons)
      ElseIf sender Is _miWindowCloseAll Then
         Do While MdiChildren.Length > 0
            MdiChildren(0).Close()
         Loop
         UpdateControls()
      End If
   End Sub

   Private Sub _miHelpAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miHelpAbout.Click
      Using aboutDialog As New AboutDialog("Pdf Compressor", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub

   Private Sub _miPdfOptionsAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miPdfOptionsAdd.Click, _miPdfOptionsModify.Click
      Dim activeForm As ViewerForm = ActiveViewerForm
      PdfOptionsAddDialog()
      MainForm.ActiveForm.Refresh()

   End Sub
   Public Sub PdfOptionsAddDialog()
      Try
         Dim activeForm As ViewerForm = ActiveViewerForm
         Dim OptionsDlg As PdfOptionsDialog = New PdfOptionsDialog()
         OptionsDlg.StandardOptions = New PdfStandardOptions()

         If activeForm.StandardOptions.Added Then
            OptionsDlg.StandardOptions = activeForm.StandardOptions
         End If
         OptionsDlg.ShowDialog(Me)
         If OptionsDlg.StandardOptions.Added Then
            activeForm.StandardOptions = OptionsDlg.StandardOptions
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateControls()
      End Try
   End Sub

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
            Dim i As Integer = 0
            Do While i < files.Length
               Try
                  Dim image As RasterImage = _codecs.Load(files(i))
                  Dim info As ImageInformation = New ImageInformation(image, files(i))
                  If i = 0 AndAlso Not viewer Is Nothing Then
                     viewer.Initialize(info, _paintProperties, False)
                  Else
                     NewImage(info)
                  End If
               Catch ex As Exception
                  Messager.ShowFileOpenError(Me, files(i), ex)
               End Try
               i += 1
            Loop
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateControls()
      End Try
   End Sub


   Private Sub _miPdfOptionsAdvanced_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miPdfOptionsAdvanced.Click
      Try
         Dim activeForm As ViewerForm = ActiveViewerForm
         Dim AdvancedOptionsDlg As PdfAdvancedOptionsDialog = New PdfAdvancedOptionsDialog()
         AdvancedOptionsDlg.AdvancedOptions = New PdfAdvancedOptions()

         AdvancedOptionsDlg.AdvancedOptions = activeForm.AdvancedOptions

         If AdvancedOptionsDlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            activeForm.AdvancedOptions = AdvancedOptionsDlg.AdvancedOptions
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try

   End Sub

   Public Sub UpdateControls()
      Dim activeForm As ViewerForm = ActiveViewerForm
      Try
         EnableAndVisibleMenu(_miFileSave, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miPdfOptions, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miWindow, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miFilePrint, Not _printDocument Is Nothing AndAlso Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miFilePrintPreview, Not _printDocument Is Nothing AndAlso Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miSparator1, Not activeForm Is Nothing)
         EnableAndVisibleMenu(_miSparator2, Not activeForm Is Nothing)

         _tbbFileSave.Enabled = _miFileSave.Enabled

         If Not activeForm Is Nothing Then
            _miPdfOptionsModify.Enabled = _tbbPdfOptionsModify.Enabled = activeForm.StandardOptions.Added
            _miPdfOptionsDelete.Enabled = _tbbPdfOptionsDelete.Enabled = activeForm.StandardOptions.Added
            _miPdfOptionsAdd.Enabled = _tbbPdfOptionsAdd.Enabled = Not activeForm.StandardOptions.Added
         Else
            _tbbPdfOptionsAdd.Enabled = False
            _tbbPdfOptionsModify.Enabled = False
            _tbbPdfOptionsDelete.Enabled = False

         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try
   End Sub

   Private Sub EnableAndVisibleMenu(ByVal menu As MenuItem, ByVal value As Boolean)
      menu.Enabled = value
      menu.Visible = value
   End Sub

   Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Dim btmp As Bitmap = New Bitmap(Me.GetType(), "ToolBar.bmp")
      btmp.MakeTransparent(btmp.GetPixel(0, 0))
      _tbMain.ImageList = New ImageList()
      _tbMain.ImageList.ColorDepth = ColorDepth.Depth24Bit
      _tbMain.ImageList.ImageSize = New Size(btmp.Height, btmp.Height)
      _tbMain.ImageList.Images.AddStrip(btmp)

      ' intitialize the codecs object
      _codecs = New RasterCodecs()

      ' setup our caption
      Messager.Caption = "LEADTOOLS for .NET VB Pdf Compressor Demo"

      Try

         If Not PrinterSettings.InstalledPrinters Is Nothing AndAlso PrinterSettings.InstalledPrinters.Count > 0 Then
            _printDocument = New PrintDocument()
            AddHandler _printDocument.BeginPrint, AddressOf _printDocument_BeginPrint
            AddHandler _printDocument.PrintPage, AddressOf _printDocument_PrintPage
            AddHandler _printDocument.EndPrint, AddressOf _printDocument_EndPrint
         Else
            _printDocument = Nothing
         End If
      Catch e1 As Exception
         _printDocument = Nothing
      End Try

      Text = Messager.Caption
      UpdateControls()
   End Sub



   Private Sub _miPdfOptionsDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miPdfOptionsDelete.Click
      Dim activeForm As ViewerForm = ActiveViewerForm
      activeForm.StandardOptions.Added = False


      DeletePage()
      UpdateControls()
      MainForm.ActiveForm.Refresh()
   End Sub

   Public Sub DeletePage()
      Dim activeForm As ViewerForm = ActiveViewerForm
      Try
         Dim i As Integer = 0
         Do While i < Me.MdiChildren.Length
            If (CType(Me.MdiChildren(i), ViewerForm)).StandardOptions.PageNumber > activeForm.StandardOptions.PageNumber Then
               CType(Me.MdiChildren(i), ViewerForm).StandardOptions.PageNumber -= 1
            End If
            i += 1
         Loop

      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateControls()
      End Try

   End Sub


   Private Sub ApplyPdfSave(ByVal FileName As String)
      Dim n As Integer = GetLeastNumber()
      Dim pdfCompressor As PdfCompressorEngine = New PdfCompressorEngine()
      Dim compressionTypes As PdfCompressorCompressionTypes = New PdfCompressorCompressionTypes()
      Dim pdfCompressorOptions As PdfCompressorOptions = New PdfCompressorOptions()
      Dim i As Integer = 0
      Do While i < Me.MdiChildren.Length
         Dim j As Integer = 0
         Do While j < Me.MdiChildren.Length
            If True = (CType(Me.MdiChildren(j), ViewerForm)).StandardOptions.Added AndAlso n = (CType(Me.MdiChildren(j), ViewerForm)).StandardOptions.PageNumber Then

               'Sets compression types needed for each segment
               compressionTypes.Comp1Bit = CType((CType(Me.MdiChildren(j), ViewerForm)).AdvancedOptions.OneBitComboSel, PdfCompressor1BitCompression)
               compressionTypes.Comp2Bit = CType((CType(Me.MdiChildren(j), ViewerForm)).AdvancedOptions.TwoBitComboSel, PdfCompressor2BitCompression)
               compressionTypes.CompPicture = CType((CType(Me.MdiChildren(j), ViewerForm)).AdvancedOptions.PictComboSel, PdfCompressorPictureCompression)
               compressionTypes.QFactor = (CType(Me.MdiChildren(j), ViewerForm)).AdvancedOptions.QFactor


               'Flags for used compression types should be set
               compressionTypes.Flags = EnabledCompressionsFlags.EnableOneBit Or EnabledCompressionsFlags.EnableTwoBit Or EnabledCompressionsFlags.EnablePicture

               pdfCompressorOptions.ImageQuality = PdfCompressorImageQuality.User
               pdfCompressorOptions.OutputQuality = PdfCompressorOutputQuality.User

               pdfCompressorOptions.BackGroundThreshold = (CType(Me.MdiChildren(j), ViewerForm)).StandardOptions.BKThreshold
               pdfCompressorOptions.CleanSize = (CType(Me.MdiChildren(j), ViewerForm)).StandardOptions.CleanSize
               pdfCompressorOptions.ColorThreshold = (CType(Me.MdiChildren(j), ViewerForm)).StandardOptions.CLRThreshold
               pdfCompressorOptions.CombineThreshold = (CType(Me.MdiChildren(j), ViewerForm)).StandardOptions.CombThreshold
               pdfCompressorOptions.SegmentQuality = (CType(Me.MdiChildren(j), ViewerForm)).StandardOptions.SegQuality

               If (CType(Me.MdiChildren(j), ViewerForm)).AdvancedOptions.CheckBackground Then
                  pdfCompressorOptions.Flags = SegmentationOptionsFlags.WithBackground
               Else
                  pdfCompressorOptions.Flags = SegmentationOptionsFlags.WithoutBackground
               End If

               pdfCompressorOptions.Flags = pdfCompressorOptions.Flags Or (CType((CType(Me.MdiChildren(j), ViewerForm)).AdvancedOptions.SegmentationComboSel, SegmentationOptionsFlags))
               pdfCompressor.SetCompression(compressionTypes)


               If (CType(Me.MdiChildren(j), ViewerForm)).StandardOptions.NOMRC Then
                  pdfCompressor.Insert((CType(Me.MdiChildren(j), ViewerForm)).Image)
               Else
                  pdfCompressor.Insert((CType(Me.MdiChildren(j), ViewerForm)).Image, pdfCompressorOptions)
               End If
               n += 1
               Exit Do
            End If
            j += 1
         Loop

         i += 1
      Loop
      pdfCompressor.Write(FileName)
      pdfCompressor.Dispose()

   End Sub

   Private Function GetLeastNumber() As Integer
      Dim bFirstTime As Boolean = True
      Dim j As Integer = 0
      Dim i As Integer = 0
      Do While i < Me.MdiChildren.Length

         If True = (CType(Me.MdiChildren(i), ViewerForm)).StandardOptions.Added Then
            If bFirstTime Then
               j = (CType(Me.MdiChildren(i), ViewerForm)).StandardOptions.PageNumber
               bFirstTime = False
            End If
            If (CType(Me.MdiChildren(i), ViewerForm)).StandardOptions.PageNumber < j Then
               j = (CType(Me.MdiChildren(i), ViewerForm)).StandardOptions.PageNumber
            End If
         End If

         i += 1
      Loop
      Return j
   End Function

   Private Sub _miFileSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileSave.Click
      Dim saver As ImageFileSaver = New ImageFileSaver()

      Try
         Dim saveDlg As SaveFileDialog = New SaveFileDialog()
         Dim sfd As SaveFileDialog = New SaveFileDialog()
         Dim added As Boolean = False
         Dim i As Integer = 0
         Do While i < Me.MdiChildren.Length
            If (CType(Me.MdiChildren(i), ViewerForm)).StandardOptions.Added = True Then
               added = True
            End If
            i += 1
         Loop

         If (Not added) Then
            Messager.ShowWarning(Me, "No image is added, at least one image should be added")
         Else
            sfd.Filter = "Acrobat Pdf (*.pdf)|*.pdf"
            sfd.FilterIndex = 1
            If sfd.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
               ApplyPdfSave(sfd.FileName)
            End If
         End If
      Catch ex As Exception
         Messager.ShowFileSaveError(Me, saver.FileName, ex)
      End Try

   End Sub

   Private Sub _tbMain_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles _tbMain.ButtonClick
      If e.Button Is _tbbFileOpen Then
         _miFileOpen.PerformClick()
      End If
      If e.Button Is _tbbFileSave Then
         _miFileSave.PerformClick()
      End If
      If e.Button Is _tbbPdfOptionsAdd Then
         _miPdfOptionsAdd.PerformClick()
      End If
      If e.Button Is _tbbPdfOptionsModify Then
         _miPdfOptionsModify.PerformClick()
      End If
      If e.Button Is _tbbPdfOptionsDelete Then
         _miPdfOptionsDelete.PerformClick()
      End If
      If e.Button Is _tbbHelpAbout Then
         _miHelpAbout.PerformClick()
      End If
      UpdateControls()
   End Sub

   Private Sub _miFilePrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFilePrint.Click
      If Not _printDocument Is Nothing Then
         Try
            Dim image As RasterImage = ActiveViewerForm.Viewer.Image
            _printDocument.PrinterSettings.MinimumPage = 1
            _printDocument.PrinterSettings.MaximumPage = image.PageCount
            _printDocument.PrinterSettings.FromPage = 1
            _printDocument.PrinterSettings.ToPage = image.PageCount

            _printDocument.Print()
         Catch
         End Try
      End If
   End Sub

   Private Sub CombineFloater()
      Dim activeForm As ViewerForm = ActiveViewerForm

      If activeForm.Viewer.Image.HasRegion Then
         activeForm.Viewer.Image.MakeRegionEmpty()
      End If

      UpdateControls()
   End Sub

   Private Sub _printDocument_BeginPrint(ByVal sender As Object, ByVal e As PrintEventArgs)
      ' This demo only loads one page at a time, so no need to re-set the print page number
   End Sub

   Private Sub _printDocument_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
      CombineFloater()
      Dim image As RasterImage = ActiveViewerForm.Image

      ' Get the print document object
      Dim document As PrintDocument = TryCast(sender, PrintDocument)

      ' Create an new LEADTOOLS image printer class
      Dim printer As RasterImagePrinter = New RasterImagePrinter()

      ' Set the document object so page calculations can be performed
      printer.PrintDocument = document

      ' We want to fit and center the image into the maximum print area
      printer.SizeMode = RasterPaintSizeMode.FitAlways
      printer.HorizontalAlignMode = RasterPaintAlignMode.Center
      printer.VerticalAlignMode = RasterPaintAlignMode.Center

      ' Account for FAX images that may have different horizontal and vertical resolution
      printer.UseDpi = True

      ' Print the whole image
      printer.ImageRectangle = Rectangle.Empty

      ' Use maximum page dimension ignoring the margins, this will be equivalant of printing
      ' using Windows Photo Gallery
      printer.PageRectangle = RectangleF.Empty
      printer.UseMargins = False

      ' Print the current page
      printer.Print(image, 1, e)

      ' Inform the printer that we have no more pages to print
      e.HasMorePages = False
   End Sub

   Private Sub _printDocument_EndPrint(ByVal sender As Object, ByVal e As PrintEventArgs)
      ' Nothing to do here
   End Sub

   Private Sub _miFilePrintPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFilePrintPreview.Click
      If Not _printDocument Is Nothing Then
         Try
            Using dlg As PrintPreviewDialog = New PrintPreviewDialog()
               Dim image As RasterImage = ActiveViewerForm.Viewer.Image
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

   Private Sub MainForm_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.MdiChildActivate
      UpdateControls()
   End Sub

   Private Sub menuItem2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItem2.Click
      Close()
   End Sub
End Class
