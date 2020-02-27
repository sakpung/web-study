' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Core
Imports System.IO
Imports Leadtools.Controls
Imports Leadtools.Demos.Dialogs
Imports Leadtools.Drawing

Public Class MainForm
   Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'Me call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call

      InitClass()

      _saver = New ImageFileSaver()
   End Sub

   'Form overrides dispose to clean up the component list.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer
   Private WithEvents _mainMenu As System.Windows.Forms.MenuStrip
   Private WithEvents _miFile As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miFileOpen As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miFileSave As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miFileClose As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miFileSeperator1 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _miFileExit As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miEdit As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miEditUndo As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miEditRedo As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miEditSeperator1 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _miEditCopy As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miEditPaste As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miAnalysis As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miAnalysisInteractiveHistogram As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miWindow As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miWindowCascade As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miWindowTileHorizontally As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miWindowTileVertically As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miWindowArrangeIcons As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miWindowCloseAll As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miHelp As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miHelpAbout As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents _menuFileHowTo As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents _menuHelpHowTo As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents MagnifyGlassToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents _menuItemMagGlassStart As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents _menuItemMagGlassStop As System.Windows.Forms.ToolStripMenuItem

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   Friend WithEvents _sbMainStatus As System.Windows.Forms.StatusBar
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
      Me._sbMainStatus = New System.Windows.Forms.StatusBar()
      Me._mainMenu = New System.Windows.Forms.MenuStrip()
      Me._miFile = New System.Windows.Forms.ToolStripMenuItem()
      Me._miFileOpen = New System.Windows.Forms.ToolStripMenuItem()
      Me._miFileSave = New System.Windows.Forms.ToolStripMenuItem()
      Me._miFileClose = New System.Windows.Forms.ToolStripMenuItem()
      Me._miFileSeperator1 = New System.Windows.Forms.ToolStripSeparator()
      Me._menuFileHowTo = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me._miFileExit = New System.Windows.Forms.ToolStripMenuItem()
      Me._miEdit = New System.Windows.Forms.ToolStripMenuItem()
      Me._miEditUndo = New System.Windows.Forms.ToolStripMenuItem()
      Me._miEditRedo = New System.Windows.Forms.ToolStripMenuItem()
      Me._miEditSeperator1 = New System.Windows.Forms.ToolStripSeparator()
      Me._miEditCopy = New System.Windows.Forms.ToolStripMenuItem()
      Me._miEditPaste = New System.Windows.Forms.ToolStripMenuItem()
      Me._miAnalysis = New System.Windows.Forms.ToolStripMenuItem()
      Me._miAnalysisInteractiveHistogram = New System.Windows.Forms.ToolStripMenuItem()
      Me._miWindow = New System.Windows.Forms.ToolStripMenuItem()
      Me._miWindowCascade = New System.Windows.Forms.ToolStripMenuItem()
      Me._miWindowTileHorizontally = New System.Windows.Forms.ToolStripMenuItem()
      Me._miWindowTileVertically = New System.Windows.Forms.ToolStripMenuItem()
      Me._miWindowArrangeIcons = New System.Windows.Forms.ToolStripMenuItem()
      Me._miWindowCloseAll = New System.Windows.Forms.ToolStripMenuItem()
      Me._miHelp = New System.Windows.Forms.ToolStripMenuItem()
      Me._miHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me._menuHelpHowTo = New System.Windows.Forms.ToolStripMenuItem()
      Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.MagnifyGlassToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemMagGlassStart = New System.Windows.Forms.ToolStripMenuItem()
      Me._menuItemMagGlassStop = New System.Windows.Forms.ToolStripMenuItem()
      Me._mainMenu.SuspendLayout()
      Me.SuspendLayout()
      '
      '_sbMainStatus
      '
      Me._sbMainStatus.Location = New System.Drawing.Point(0, 449)
      Me._sbMainStatus.Name = "_sbMainStatus"
      Me._sbMainStatus.Size = New System.Drawing.Size(712, 22)
      Me._sbMainStatus.TabIndex = 1
      '
      '_mainMenu
      '
      Me._mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miFile, Me._miEdit, Me.ViewToolStripMenuItem, Me._miAnalysis, Me._miWindow, Me._miHelp})
      Me._mainMenu.Location = New System.Drawing.Point(0, 0)
      Me._mainMenu.Name = "_mainMenu"
      Me._mainMenu.Size = New System.Drawing.Size(712, 24)
      Me._mainMenu.TabIndex = 3
      Me._mainMenu.Text = "menuStrip1"
      '
      '_miFile
      '
      Me._miFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miFileOpen, Me._miFileSave, Me._miFileClose, Me._miFileSeperator1, Me._menuFileHowTo, Me.ToolStripSeparator1, Me._miFileExit})
      Me._miFile.Name = "_miFile"
      Me._miFile.Size = New System.Drawing.Size(37, 20)
      Me._miFile.Text = "&File"
      '
      '_miFileOpen
      '
      Me._miFileOpen.Name = "_miFileOpen"
      Me._miFileOpen.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
      Me._miFileOpen.Size = New System.Drawing.Size(152, 22)
      Me._miFileOpen.Text = "&Open"
      '
      '_miFileSave
      '
      Me._miFileSave.Name = "_miFileSave"
      Me._miFileSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
      Me._miFileSave.Size = New System.Drawing.Size(152, 22)
      Me._miFileSave.Text = "&Save"
      '
      '_miFileClose
      '
      Me._miFileClose.Name = "_miFileClose"
      Me._miFileClose.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
      Me._miFileClose.Size = New System.Drawing.Size(152, 22)
      Me._miFileClose.Text = "&Close"
      '
      '_miFileSeperator1
      '
      Me._miFileSeperator1.Name = "_miFileSeperator1"
      Me._miFileSeperator1.Size = New System.Drawing.Size(149, 6)
      '
      '_menuFileHowTo
      '
      Me._menuFileHowTo.Name = "_menuFileHowTo"
      Me._menuFileHowTo.Size = New System.Drawing.Size(152, 22)
      Me._menuFileHowTo.Text = "&How To..."
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
      '
      '_miFileExit
      '
      Me._miFileExit.Name = "_miFileExit"
      Me._miFileExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
      Me._miFileExit.Size = New System.Drawing.Size(152, 22)
      Me._miFileExit.Text = "&Exit"
      '
      '_miEdit
      '
      Me._miEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miEditUndo, Me._miEditRedo, Me._miEditSeperator1, Me._miEditCopy, Me._miEditPaste})
      Me._miEdit.Name = "_miEdit"
      Me._miEdit.Size = New System.Drawing.Size(39, 20)
      Me._miEdit.Text = "&Edit"
      '
      '_miEditUndo
      '
      Me._miEditUndo.Name = "_miEditUndo"
      Me._miEditUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
      Me._miEditUndo.Size = New System.Drawing.Size(152, 22)
      Me._miEditUndo.Text = "&Undo"
      '
      '_miEditRedo
      '
      Me._miEditRedo.Name = "_miEditRedo"
      Me._miEditRedo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
      Me._miEditRedo.Size = New System.Drawing.Size(152, 22)
      Me._miEditRedo.Text = "&Redo"
      '
      '_miEditSeperator1
      '
      Me._miEditSeperator1.Name = "_miEditSeperator1"
      Me._miEditSeperator1.Size = New System.Drawing.Size(149, 6)
      '
      '_miEditCopy
      '
      Me._miEditCopy.Name = "_miEditCopy"
      Me._miEditCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
      Me._miEditCopy.Size = New System.Drawing.Size(152, 22)
      Me._miEditCopy.Text = "&Copy"
      '
      '_miEditPaste
      '
      Me._miEditPaste.Name = "_miEditPaste"
      Me._miEditPaste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
      Me._miEditPaste.Size = New System.Drawing.Size(152, 22)
      Me._miEditPaste.Text = "&Paste"
      '
      '_miAnalysis
      '
      Me._miAnalysis.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miAnalysisInteractiveHistogram})
      Me._miAnalysis.Name = "_miAnalysis"
      Me._miAnalysis.Size = New System.Drawing.Size(62, 20)
      Me._miAnalysis.Text = "&Analysis"
      '
      '_miAnalysisInteractiveHistogram
      '
      Me._miAnalysisInteractiveHistogram.Name = "_miAnalysisInteractiveHistogram"
      Me._miAnalysisInteractiveHistogram.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
      Me._miAnalysisInteractiveHistogram.Size = New System.Drawing.Size(225, 22)
      Me._miAnalysisInteractiveHistogram.Text = "&Interactive Histogram"
      '
      '_miWindow
      '
      Me._miWindow.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miWindowCascade, Me._miWindowTileHorizontally, Me._miWindowTileVertically, Me._miWindowArrangeIcons, Me._miWindowCloseAll})
      Me._miWindow.Name = "_miWindow"
      Me._miWindow.Size = New System.Drawing.Size(63, 20)
      Me._miWindow.Text = "&Window"
      '
      '_miWindowCascade
      '
      Me._miWindowCascade.Name = "_miWindowCascade"
      Me._miWindowCascade.Size = New System.Drawing.Size(160, 22)
      Me._miWindowCascade.Text = "&Cascade"
      '
      '_miWindowTileHorizontally
      '
      Me._miWindowTileHorizontally.Name = "_miWindowTileHorizontally"
      Me._miWindowTileHorizontally.Size = New System.Drawing.Size(160, 22)
      Me._miWindowTileHorizontally.Text = "Tile &Horizontally"
      '
      '_miWindowTileVertically
      '
      Me._miWindowTileVertically.Name = "_miWindowTileVertically"
      Me._miWindowTileVertically.Size = New System.Drawing.Size(160, 22)
      Me._miWindowTileVertically.Text = "Tile &Vertically"
      '
      '_miWindowArrangeIcons
      '
      Me._miWindowArrangeIcons.Name = "_miWindowArrangeIcons"
      Me._miWindowArrangeIcons.Size = New System.Drawing.Size(160, 22)
      Me._miWindowArrangeIcons.Text = "Arrange &Icons"
      '
      '_miWindowCloseAll
      '
      Me._miWindowCloseAll.Name = "_miWindowCloseAll"
      Me._miWindowCloseAll.Size = New System.Drawing.Size(160, 22)
      Me._miWindowCloseAll.Text = "Close &All"
      '
      '_miHelp
      '
      Me._miHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miHelpAbout, Me.ToolStripSeparator2, Me._menuHelpHowTo})
      Me._miHelp.Name = "_miHelp"
      Me._miHelp.Size = New System.Drawing.Size(44, 20)
      Me._miHelp.Text = "&Help"
      '
      '_miHelpAbout
      '
      Me._miHelpAbout.Name = "_miHelpAbout"
      Me._miHelpAbout.Size = New System.Drawing.Size(152, 22)
      Me._miHelpAbout.Text = "&About"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(149, 6)
      '
      '_menuHelpHowTo
      '
      Me._menuHelpHowTo.Name = "_menuHelpHowTo"
      Me._menuHelpHowTo.Size = New System.Drawing.Size(152, 22)
      Me._menuHelpHowTo.Text = "&How To..."
      '
      'ViewToolStripMenuItem
      '
      Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MagnifyGlassToolStripMenuItem})
      Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
      Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
      Me.ViewToolStripMenuItem.Text = "&View"
      '
      'MagnifyGlassToolStripMenuItem
      '
      Me.MagnifyGlassToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemMagGlassStart, Me._menuItemMagGlassStop})
      Me.MagnifyGlassToolStripMenuItem.Name = "MagnifyGlassToolStripMenuItem"
      Me.MagnifyGlassToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me.MagnifyGlassToolStripMenuItem.Text = "&Magnify Glass"
      '
      '_menuItemMagGlassStart
      '
      Me._menuItemMagGlassStart.Name = "_menuItemMagGlassStart"
      Me._menuItemMagGlassStart.Size = New System.Drawing.Size(152, 22)
      Me._menuItemMagGlassStart.Text = "&Start"
      '
      '_menuItemMagGlassStop
      '
      Me._menuItemMagGlassStop.Name = "_menuItemMagGlassStop"
      Me._menuItemMagGlassStop.Size = New System.Drawing.Size(152, 22)
      Me._menuItemMagGlassStop.Text = "S&top"
      '
      'MainForm
      '
      Me.AllowDrop = True
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(712, 471)
      Me.Controls.Add(Me._mainMenu)
      Me.Controls.Add(Me._sbMainStatus)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.IsMdiContainer = True
      Me.MainMenuStrip = Me._mainMenu
      Me.Name = "MainForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "MainForm"
      Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
      Me._mainMenu.ResumeLayout(False)
      Me._mainMenu.PerformLayout()
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

      Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(False)
      Application.Run(New MainForm())
   End Sub

   Private _codecs As RasterCodecs
   Private _paintProperties As RasterPaintProperties
   Private _saver As ImageFileSaver
   Private _openInitialPath As String = ""

   Private Sub ShowHelpFile()
      Dim helpPath As String = String.Empty

      Try
         helpPath = Application.ExecutablePath
         Dim index As Integer = helpPath.ToLower().IndexOf("bin")
         helpPath = helpPath.Remove(index)
#If FOR_NUGET Then
            helpPath += "Help\\Interactive Histogram Demo.htm"

#Else
         helpPath += "Examples\\DotNet\\CS\\InteractiveHistDemo\\Help\\Interactive Histogram Demo.htm"
#End If ' #If FOR_NUGET

         System.Diagnostics.Process.Start(helpPath)
      Catch ex As Exception
         Messager.ShowError(Me, "Error opening file" & Microsoft.VisualBasic.Constants.vbCrLf & helpPath)
      End Try
   End Sub

   Private Sub InitClass()
      Messager.Caption = "LEADTOOLS for .NET VB Interactive Histogram Demo"
      Text = Messager.Caption

      _codecs = New RasterCodecs()
      _codecs.Options.Txt.Load.Enabled = False

      _paintProperties = RasterPaintProperties.Default
      _paintProperties.PaintDisplayMode = _paintProperties.PaintDisplayMode Or RasterPaintDisplayModeFlags.ScaleToGray
      ShowHelpFile()

      UpdateControls()
   End Sub

   Public ReadOnly Property ActiveViewerForm() As ViewerForm
      Get
         Return CType(ActiveMdiChild, ViewerForm)
      End Get
   End Property

   Public Sub UpdateControls()
      Dim activeForm As ViewerForm = ActiveViewerForm

      ' Update File menu items...
      EnableAndVisibleMenu(_miFileSave, Not IsNothing(activeForm))
      EnableAndVisibleMenu(_miFileClose, Not IsNothing(activeForm))

      ' Update Edit menu items...
      EnableAndVisibleMenu(_miEditUndo, Not IsNothing(activeForm))
      EnableAndVisibleMenu(_miEditRedo, Not IsNothing(activeForm))
      _miEditSeperator1.Visible = (Not IsNothing(activeForm))
      EnableAndVisibleMenu(_miEditCopy, Not IsNothing(activeForm))
      _miEditPaste.Enabled = RasterClipboard.IsReady

      ' Update Analysis menu items...
      EnableAndVisibleMenu(_miAnalysis, Not IsNothing(activeForm))
      EnableAndVisibleMenu(_miAnalysisInteractiveHistogram, Not IsNothing(activeForm))

      If (Not IsNothing(activeForm)) Then
         If (activeForm.UndoList.Index <= 0) Then
            _miEditUndo.Enabled = False
         Else
            _miEditUndo.Enabled = True
         End If

         If (activeForm.UndoList.Index >= activeForm.UndoList.Counter - 1) Then
            _miEditRedo.Enabled = False
         Else
            _miEditRedo.Enabled = True
         End If
         _menuItemMagGlassStart.Checked = activeForm.IsMagGlass
         _menuItemMagGlassStop.Checked = Not activeForm.IsMagGlass
      End If

      ' Update Window menu items...
      EnableAndVisibleMenu(_miWindow, Not IsNothing(activeForm))
   End Sub

   Private Sub EnableAndVisibleMenu(ByVal menu As ToolStripMenuItem, ByVal value As Boolean)
      menu.Enabled = value
      menu.Visible = value
   End Sub

   Private Property ImageToRun() As RasterImage
      Get
         Dim activeForm As ViewerForm = ActiveViewerForm
         Return activeForm.Viewer.Image
      End Get

      Set(ByVal value As RasterImage)
         If (Not IsNothing(value)) Then
            Dim activeForm As ViewerForm = ActiveViewerForm
            activeForm.Viewer.Image = value
         End If
      End Set
   End Property

   Private Sub MainForm_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
      If (Tools.CanDrop(e.Data)) Then
         e.Effect = DragDropEffects.Copy
      End If
   End Sub

   Private Sub MainForm_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop
      If (Tools.CanDrop(e.Data)) Then
         Dim files() As String = Tools.GetDropFiles(e.Data)
         If (Not files Is Nothing) Then
            LoadDropFiles(Nothing, files)
         End If
      End If
   End Sub

   Public Sub LoadDropFiles(ByVal viewer As ViewerForm, ByVal files() As String)
      Try
         If (Not files Is Nothing) Then
            Dim i As Integer
            For i = 0 To files.Length - 1
               Try
                  Dim image As RasterImage = _codecs.Load(files(i))
                  Dim info As New ImageInformation(image, files(i))
                  If (i = 0 AndAlso Not IsNothing(viewer)) Then
                     viewer.Initialize(info, _paintProperties, False)
                  Else
                     NewImage(info)
                  End If
               Catch ex As Exception
                  Messager.ShowFileOpenError(Me, files(i), ex)
               End Try
            Next
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateControls()
      End Try
   End Sub

   Private Sub NewImage(ByVal info As ImageInformation)
      Dim child As New ViewerForm

      child.MdiParent = Me

      child.Initialize(info, _paintProperties, True)

      child.Show()
   End Sub

   Private Function LoadImage() As ImageInformation
      Dim loader As ImageFileLoader = New ImageFileLoader

      loader.OpenDialogInitialPath = _openInitialPath

      Try
         loader.LoadOnlyOnePage = True
         loader.ShowLoadPagesDialog = False
         If (loader.Load(Me, _codecs, True) > 0) Then
            _openInitialPath = Path.GetDirectoryName(loader.FileName)

            If (loader.Image.HasRegion) Then
               loader.Image.MakeRegionEmpty()
            End If
            Return New ImageInformation(loader.Image, loader.FileName)
         End If
      Catch ex As Exception
         Messager.ShowFileOpenError(Me, loader.FileName, ex)
      End Try

      Return Nothing
   End Function

   Private Sub _miFileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileOpen.Click
      Dim activeViewer As ViewerForm = ActiveViewerForm

      Try
         Dim info As ImageInformation = LoadImage()
         If (Not IsNothing(info)) Then
            NewImage(info)
         End If

         If (Not IsNothing(ActiveViewerForm)) Then
            AddImageToUndoList(ActiveViewerForm.Viewer.Image)
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateControls()
      End Try

   End Sub

   Private Sub _miFileSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileSave.Click
      Try
         _saver.Save(Me, _codecs, ActiveViewerForm.Viewer.Image)
      Catch ex As Exception
         Messager.ShowFileSaveError(Me, _saver.FileName, ex)
      End Try
   End Sub

   Private Sub _miFileClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileClose.Click
      ActiveViewerForm.Close()
      UpdateControls()
   End Sub

   Private Sub _miFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileExit.Click
      Me.Close()
   End Sub

   Private Sub _miEditUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miEditUndo.Click
      ActiveViewerForm.UndoList.Index = ActiveViewerForm.UndoList.Index - 1
      ActiveViewerForm.Viewer.Image = ActiveViewerForm.UndoList.GetImage(ActiveViewerForm.UndoList.Index).CloneAll()
      UpdateControls()
   End Sub

   Private Sub _miEditRedo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miEditRedo.Click
      ActiveViewerForm.UndoList.Index = ActiveViewerForm.UndoList.Index + 1
      ActiveViewerForm.Viewer.Image = ActiveViewerForm.UndoList.GetImage(ActiveViewerForm.UndoList.Index).CloneAll()
      UpdateControls()
   End Sub

   Private Sub _miEditCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miEditCopy.Click
      Try
         Dim wait As New WaitCursor
         Try
            RasterClipboard.Copy( _
               Me.Handle, _
               ImageToRun, _
               RasterClipboardCopyFlags.Empty Or _
               RasterClipboardCopyFlags.Dib Or _
               RasterClipboardCopyFlags.Palette Or _
               RasterClipboardCopyFlags.Region)
         Finally
            wait.Dispose()
         End Try
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateControls()
      End Try
   End Sub

   Private Sub _miEditPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miEditPaste.Click
      Try
         Dim wait As New WaitCursor
         Try
            Dim image As RasterImage = RasterClipboard.Paste(Me.Handle)

            Dim activeForm As ViewerForm = ActiveViewerForm

            If (Not IsNothing(image)) Then
               If (image.HasRegion AndAlso IsNothing(activeForm)) Then
                  image.MakeRegionEmpty()
               End If

               If (image.HasRegion) Then
                  ' make sure the images have the same BitsPerPixel and Palette
                  If (activeForm.Viewer.Image.BitsPerPixel > 8) Then
                     If (image.BitsPerPixel <> activeForm.Viewer.Image.BitsPerPixel) Then
                        Try
                           Dim colorRes As ColorResolutionCommand = New ColorResolutionCommand
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
                        Dim colorRes As ColorResolutionCommand = New ColorResolutionCommand
                        colorRes.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel
                        colorRes.SetPalette(activeForm.Viewer.Image.GetPalette)
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
         Finally
            wait.Dispose()
         End Try
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateControls()
      End Try
   End Sub

   Private Sub AddImageToUndoList(ByVal image As RasterImage)
      ActiveViewerForm.UndoList.AddToUndoList(image)
      UpdateControls()
   End Sub

   Private Sub _miAnalysisInteractiveHistogram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miAnalysisInteractiveHistogram.Click
      Me.Cursor = Cursors.WaitCursor
      Dim interactiveHistoramDialog As New InteractiveHistDialog(Me)

      Try
         If (interactiveHistoramDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            ActiveViewerForm.UndoList.AddToUndoList(ActiveViewerForm.Viewer.Image)
            UpdateControls()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Interactive histogram Demo")
      Finally
         UpdateControls()
      End Try
   End Sub

   Private Sub setCheckWindow(ByVal menuItem As ToolStripMenuItem)
      _miWindowCascade.Checked = False
      _miWindowTileHorizontally.Checked = False
      _miWindowTileVertically.Checked = False
      _miWindowArrangeIcons.Checked = False
      _miWindowCloseAll.Checked = False

      menuItem.Checked = True
   End Sub

   Private Sub _miWindow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
Handles _miWindowCascade.Click, _miWindowTileHorizontally.Click, _miWindowTileVertically.Click, _miWindowArrangeIcons.Click, _miWindowCloseAll.Click

      If (sender Is _miWindowCascade) Then
         LayoutMdi(MdiLayout.Cascade)
      ElseIf (sender Is _miWindowTileHorizontally) Then
         LayoutMdi(MdiLayout.TileHorizontal)
      ElseIf (sender Is _miWindowTileVertically) Then
         LayoutMdi(MdiLayout.TileVertical)
      ElseIf (sender Is _miWindowArrangeIcons) Then
         LayoutMdi(MdiLayout.ArrangeIcons)
      ElseIf (sender Is _miWindowCloseAll) Then
         While (MdiChildren.Length > 0)
            MdiChildren(0).Close()
         End While
         UpdateControls()
      End If

      setCheckWindow(CType(sender, ToolStripMenuItem))
   End Sub

   Private Sub _miHelpAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miHelpAbout.Click
      Using aboutDialog As New AboutDialog("Interactive Histogram", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub

   Private Sub _mi_Popup(ByVal sender As Object, ByVal e As System.EventArgs) _
Handles _miFile.DropDownOpening, _miEdit.DropDownOpening, _miAnalysis.DropDownOpening, _miWindow.DropDownOpening
      UpdateControls()
   End Sub

   Private Sub MainForm_MdiChildActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.MdiChildActivate
      UpdateControls()
   End Sub

   Private Sub _menuHelpHowTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _menuHelpHowTo.Click
      ShowHelpFile()
   End Sub

   Private Sub _menuFileHowTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _menuFileHowTo.Click
      ShowHelpFile()
   End Sub

   Private Sub _menuItemMagGlassStart_Click(sender As System.Object, e As System.EventArgs) Handles _menuItemMagGlassStart.Click
      _menuItemMagGlassStart.Checked = True
      _menuItemMagGlassStop.Checked = False
      Dim activeForm As ViewerForm = CType(ActiveMdiChild, ViewerForm)
      If activeForm IsNot Nothing Then
         activeForm.StartMagGlass()
      End If
      UpdateControls()
   End Sub

   Private Sub _menuItemMagGlassStop_Click(sender As System.Object, e As System.EventArgs) Handles _menuItemMagGlassStop.Click
      _menuItemMagGlassStop.Checked = True
      _menuItemMagGlassStart.Checked = False
      Dim activeForm As ViewerForm = CType(ActiveMdiChild, ViewerForm)
      If activeForm IsNot Nothing Then
         activeForm.StopMagGlass()
      End If
      UpdateControls()
   End Sub
End Class
