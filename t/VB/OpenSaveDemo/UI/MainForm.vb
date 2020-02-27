' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports System.IO
Imports Leadtools.Demos.Dialogs

Public Class MainForm
   Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call

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

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   Friend WithEvents _mmMain As System.Windows.Forms.MainMenu
   Friend WithEvents _miHelp As System.Windows.Forms.MenuItem
   Friend WithEvents _miHelpAbout As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileExit As System.Windows.Forms.MenuItem
   Friend WithEvents _miFile As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileOpen As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileSave As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileSep1 As System.Windows.Forms.MenuItem
   Friend WithEvents _menuItemPage As System.Windows.Forms.MenuItem
   Friend WithEvents _menuItemPageFirst As System.Windows.Forms.MenuItem
   Friend WithEvents _menuItemPagePrevious As System.Windows.Forms.MenuItem
   Friend WithEvents _menuItemPageNext As System.Windows.Forms.MenuItem
   Friend WithEvents _menuItemPageLast As System.Windows.Forms.MenuItem
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MainForm))
      Me._miHelp = New System.Windows.Forms.MenuItem
      Me._miHelpAbout = New System.Windows.Forms.MenuItem
      Me._miFileExit = New System.Windows.Forms.MenuItem
      Me._mmMain = New System.Windows.Forms.MainMenu
      Me._miFile = New System.Windows.Forms.MenuItem
      Me._miFileOpen = New System.Windows.Forms.MenuItem
      Me._miFileSave = New System.Windows.Forms.MenuItem
      Me._miFileSep1 = New System.Windows.Forms.MenuItem
      Me._menuItemPage = New System.Windows.Forms.MenuItem
      Me._menuItemPageFirst = New System.Windows.Forms.MenuItem
      Me._menuItemPagePrevious = New System.Windows.Forms.MenuItem
      Me._menuItemPageNext = New System.Windows.Forms.MenuItem
      Me._menuItemPageLast = New System.Windows.Forms.MenuItem
      '
      '_miHelp
      '
      Me._miHelp.Index = 2
      Me._miHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miHelpAbout})
      Me._miHelp.Text = "&Help"
      '
      '_miHelpAbout
      '
      Me._miHelpAbout.Index = 0
      Me._miHelpAbout.Text = "&About..."
      '
      '_miFileExit
      '
      Me._miFileExit.Index = 3
      Me._miFileExit.Text = "E&xit"
      '
      '_mmMain
      '
      Me._mmMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFile, Me._menuItemPage, Me._miHelp})
      '
      '_miFile
      '
      Me._miFile.Index = 0
      Me._miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFileOpen, Me._miFileSave, Me._miFileSep1, Me._miFileExit})
      Me._miFile.Text = "&File"
      '
      '_miFileOpen
      '
      Me._miFileOpen.Index = 0
      Me._miFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
      Me._miFileOpen.Text = "&Open..."
      '
      '_miFileSave
      '
      Me._miFileSave.Index = 1
      Me._miFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
      Me._miFileSave.Text = "&Save..."
      '
      '_miFileSep1
      '
      Me._miFileSep1.Index = 2
      Me._miFileSep1.Text = "-"
      '
      '_menuItemPage
      '
      Me._menuItemPage.Index = 1
      Me._menuItemPage.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemPageFirst, Me._menuItemPagePrevious, Me._menuItemPageNext, Me._menuItemPageLast})
      Me._menuItemPage.Text = "&Page"
      '
      '_menuItemPageFirst
      '
      Me._menuItemPageFirst.Index = 0
      Me._menuItemPageFirst.RadioCheck = True
      Me._menuItemPageFirst.Text = "&First"
      '
      '_menuItemPagePrevious
      '
      Me._menuItemPagePrevious.Index = 1
      Me._menuItemPagePrevious.RadioCheck = True
      Me._menuItemPagePrevious.Text = "&Previous"
      '
      '_menuItemPageNext
      '
      Me._menuItemPageNext.Index = 2
      Me._menuItemPageNext.RadioCheck = True
      Me._menuItemPageNext.Text = "&Next"
      '
      '_menuItemPageLast
      '
      Me._menuItemPageLast.Index = 3
      Me._menuItemPageLast.RadioCheck = True
      Me._menuItemPageLast.Text = "&Last"
      '
      'MainForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(624, 385)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Menu = Me._mmMain
      Me.Name = "MainForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Open and Save Demo"

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

   ' the raster image viewer
   Private _viewer As ImageViewer

   ' raster codecs used in load\save
   Private _codecs As RasterCodecs
   Private _openInitialPath As String = ""
   ' <summary>
   ' Initialize the Application.
   ' </summary>
   Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Messager.Caption = "LEADTOOLS for .NET VB Open and Save Demo"
      Text = Messager.Caption

      ' initialize the _viewer object
      _viewer = New ImageViewer
      _viewer.Dock = DockStyle.Fill
      _viewer.BackColor = Color.DarkGray
      Controls.Add(_viewer)
      _viewer.BringToFront()

      ' initialize the codecs object.
      _codecs = New RasterCodecs

      UpdateMyControls()
   End Sub
   Private Sub EnableAndVisibleMenu(ByVal menu As MenuItem, ByVal value As Boolean)
      menu.Enabled = value
      menu.Visible = value
   End Sub

   ' <summary>
   ' Update the UI depending on the program state
   ' </summary>
   Private Sub UpdateMyControls()
      EnableAndVisibleMenu(_menuItemPage, (Not _viewer.Image Is Nothing))
      If (Not IsNothing(_viewer.Image)) Then
         _miFileSave.Enabled = True
         _miFileSave.Visible = True
         EnableAndVisibleMenu(_menuItemPage, (_viewer.Image.PageCount > 1))
         EnableAndVisibleMenu(_menuItemPageFirst, (_viewer.Image.PageCount > 1))
         EnableAndVisibleMenu(_menuItemPagePrevious, (_viewer.Image.PageCount > 1))
         EnableAndVisibleMenu(_menuItemPageNext, (_viewer.Image.PageCount > 1))
         EnableAndVisibleMenu(_menuItemPageLast, (_viewer.Image.PageCount > 1))
         If (_viewer.Image.PageCount > 1) Then
            _menuItemPageFirst.Enabled = (_viewer.Image.Page > 1)
            _menuItemPagePrevious.Enabled = (_viewer.Image.Page > 1)
            _menuItemPageNext.Enabled = (_viewer.Image.Page <> _viewer.Image.PageCount)
            _menuItemPageLast.Enabled = (_viewer.Image.Page <> _viewer.Image.PageCount)
         End If
      Else
         _miFileSave.Enabled = False
         _miFileSave.Visible = False
      End If
   End Sub

   ' <summary>
   ' Load a new image
   ' </summary>
   Private Sub _miFileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileOpen.Click
      Try
         ' load the image
         Dim loader As ImageFileLoader = New ImageFileLoader

         loader.OpenDialogInitialPath = _openInitialPath
         loader.ShowLoadPagesDialog = True
         If (loader.Load(Me, _codecs, True) > 0) Then
            _openInitialPath = Path.GetDirectoryName(loader.FileName)
            ' update the caption
            Text = String.Format("{0} - {1}", loader.FileName, Messager.Caption)
            ' set the new image in the viewer.
            _viewer.Image = loader.Image
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateMyControls()
      End Try
   End Sub

   ' <summary>
   ' save the original image
   ' </summary>
   Private Sub _miFileSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileSave.Click
      Try
         Dim saver As ImageFileSaver = New ImageFileSaver
         If (saver.Save(Me, _codecs, _viewer.Image)) Then
            ' we need to load me new image
            Dim temp As RasterImage = _codecs.Load(saver.FileName)
            ' update the caption
            Text = String.Format("{0} - {1}", saver.FileName, Messager.Caption)
            _viewer.Image = temp
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateMyControls()
      End Try
   End Sub
   Private Sub _menuItemPage_Click(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles _menuItemPageFirst.Click, _
                                           _menuItemPagePrevious.Click, _
                                           _menuItemPageNext.Click, _
                                           _menuItemPageLast.Click
      Try
         If (sender.Equals(_menuItemPageFirst)) Then
            _viewer.Image.Page = 1
         ElseIf (sender.Equals(_menuItemPagePrevious)) Then
            _viewer.Image.Page -= 1
         ElseIf (sender.Equals(_menuItemPageNext)) Then
            _viewer.Image.Page += 1
         ElseIf (sender.Equals(_menuItemPageLast)) Then
            _viewer.Image.Page = _viewer.Image.PageCount
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateMyControls()
      End Try
   End Sub

   ' <summary>
   ' Shutdown
   ' </summary>
   Private Sub _miFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileExit.Click
      Close()
   End Sub

   ' <summary>
   ' show the about dialog
   ' </summary>
   Private Sub _miHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miHelpAbout.Click
      Using aboutDialog As New AboutDialog("Open and Save", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub
End Class
