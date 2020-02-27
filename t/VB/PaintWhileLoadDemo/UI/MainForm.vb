' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Threading

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.Internal
Imports System.IO
Imports Leadtools.Drawing
Imports System.Drawing.Drawing2D
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
   Friend WithEvents _miMode As System.Windows.Forms.MenuItem
   Friend WithEvents _miModePartialImage As System.Windows.Forms.MenuItem
   Friend WithEvents _miModeBuffer As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileExit As System.Windows.Forms.MenuItem
   Friend WithEvents _miHelp As System.Windows.Forms.MenuItem
   Friend WithEvents _miHelpAbout As System.Windows.Forms.MenuItem
   Friend WithEvents _mmMain As System.Windows.Forms.MainMenu
   Friend WithEvents _miFile As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileOpen As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileSep1 As System.Windows.Forms.MenuItem
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MainForm))
      Me._miMode = New System.Windows.Forms.MenuItem
      Me._miModePartialImage = New System.Windows.Forms.MenuItem
      Me._miModeBuffer = New System.Windows.Forms.MenuItem
      Me._miFileExit = New System.Windows.Forms.MenuItem
      Me._miHelp = New System.Windows.Forms.MenuItem
      Me._miHelpAbout = New System.Windows.Forms.MenuItem
      Me._mmMain = New System.Windows.Forms.MainMenu
      Me._miFile = New System.Windows.Forms.MenuItem
      Me._miFileOpen = New System.Windows.Forms.MenuItem
      Me._miFileSep1 = New System.Windows.Forms.MenuItem
      '
      '_miMode
      '
      Me._miMode.Index = 1
      Me._miMode.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miModePartialImage, Me._miModeBuffer})
      Me._miMode.Text = "&Mode"
      '
      '_miModePartialImage
      '
      Me._miModePartialImage.Index = 0
      Me._miModePartialImage.Text = "&Partial Image"
      '
      '_miModeBuffer
      '
      Me._miModeBuffer.Index = 1
      Me._miModeBuffer.Text = "&Buffer"
      '
      '_miFileExit
      '
      Me._miFileExit.Index = 2
      Me._miFileExit.Text = "E&xit"
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
      '_mmMain
      '
      Me._mmMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFile, Me._miMode, Me._miHelp})
      '
      '_miFile
      '
      Me._miFile.Index = 0
      Me._miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFileOpen, Me._miFileSep1, Me._miFileExit})
      Me._miFile.Text = "&File"
      '
      '_miFileOpen
      '
      Me._miFileOpen.Index = 0
      Me._miFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
      Me._miFileOpen.Text = "&Open..."
      '
      '_miFileSep1
      '
      Me._miFileSep1.Index = 1
      Me._miFileSep1.Text = "-"
      '
      'MainForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(624, 385)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Menu = Me._mmMain
      Me.Name = "MainForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "MainForm"

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


   Private Enum PaintWhileLoadOption
      PartialImage
      Buffer
   End Enum

   ' the raster image viewer
   Private _viewer As ImageViewer

   ' raster codecs used in load\save
   Private _codecs As RasterCodecs

   Private _paintWhileLoadOption As PaintWhileLoadOption
   Private _isLoading As Boolean
   Private _cancelLoad As Boolean
   Private _openInitialPath As String = ""
   ' <summary>
   ' Initialize the Application.
   ' </summary>
   Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Messager.Caption = "LEADTOOLS for .NET VB Paint While Load Demo"
      Text = Messager.Caption
      KeyPreview = True

      ' initialize the _viewer object
      _viewer = New ImageViewer
      _viewer.Dock = DockStyle.Fill
      _viewer.BackColor = Color.DarkGray
      Controls.Add(_viewer)
      _viewer.BringToFront()

      ' initialize the codecs object.
      _codecs = New RasterCodecs
      _codecs.Options.Load.Passes = -2 ' load all passes

      ' initialize other variables
      _paintWhileLoadOption = PaintWhileLoadOption.Buffer
      _isLoading = False
      _cancelLoad = False

      UpdateMyControls()
   End Sub

   ' <summary>
   ' Update the UI depending on the program state
   ' </summary>
   Private Sub UpdateMyControls()
      _miModePartialImage.Checked = (_paintWhileLoadOption = PaintWhileLoadOption.PartialImage)
      _miModeBuffer.Checked = (_paintWhileLoadOption = PaintWhileLoadOption.Buffer)
      EnableMenu(_miFile, Not _isLoading)
      EnableMenu(_miMode, Not _isLoading)
   End Sub

   ' <summary>
   ' Load a new image
   ' </summary>
   Private Sub _miFileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileOpen.Click
      Try
         ' load the image
         Dim loader As ImageFileLoader = New ImageFileLoader
         loader.LoadOnlyOnePage = True
         loader.OpenDialogInitialPath = _openInitialPath
         _isLoading = True
         _cancelLoad = False
         UpdateMyControls()
         If (loader.Load(Me, _codecs, False) > 0) Then
            _viewer.Image = Nothing
            Text = Messager.Caption

            AddHandler _codecs.LoadImage, AddressOf _codecs_LoadImage

            Try
               _viewer.Image = _codecs.Load(loader.FileName, 0, CodecsLoadByteOrder.BgrOrGray, loader.FirstPage, loader.LastPage)
               _openInitialPath = Path.GetDirectoryName(loader.FileName)
               ' update the caption
               Text = String.Format("{0} - {1}", loader.FileName, Messager.Caption)
            Catch ex As Exception
               Messager.ShowError(Me, ex)
            Finally
               RemoveHandler _codecs.LoadImage, AddressOf _codecs_LoadImage
            End Try
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         _isLoading = False
         _cancelLoad = False
         UpdateMyControls()
      End Try
   End Sub

   ' <summary>
   ' Shutdown
   ' </summary>
   Private Sub _miFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileExit.Click
      Close()
   End Sub

   Private Sub _miModePartialImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miModePartialImage.Click, _miModeBuffer.Click
      If (sender Is _miModePartialImage) Then '_miModePartialImage
         _paintWhileLoadOption = PaintWhileLoadOption.PartialImage
      Else '_miModeBuffer
         _paintWhileLoadOption = PaintWhileLoadOption.Buffer
      End If
      UpdateMyControls()
   End Sub

   Private Sub EnableMenu(ByVal menu As MenuItem, ByVal value As Boolean)
      menu.Enabled = value
   End Sub

   Private Sub _codecs_LoadImage(ByVal sender As Object, ByVal e As CodecsLoadImageEventArgs)
      If (_paintWhileLoadOption = PaintWhileLoadOption.PartialImage) Then
         ' One method is to use the Partial Image that is provided during this event to update
         ' the RasterImageViewer control
         If ((e.Flags And CodecsLoadImageFlags.FirstRow) = CodecsLoadImageFlags.FirstRow) Then
            If (e.ImagePage = 1) Then
               _viewer.Image = e.Image
               _viewer.Image.DisableEvents()
            End If
         End If

         If (e.ImagePage = 1) Then
            Application.DoEvents()
            Dim rc As Rectangle = New Rectangle(0, e.Row, _viewer.Image.Width, e.Lines)
            rc = Leadtools.Demos.Converters.ConvertRect(_viewer.Image.RectangleFromImage(RasterViewPerspective.TopLeft, Leadtools.Demos.Converters.ConvertRect(rc)))
            Dim mm As LeadMatrix = _viewer.ViewTransform
            Dim m As Matrix = New Matrix(CSng(mm.M11), CSng(mm.M12), CSng(mm.M21), CSng(mm.M22), CSng(mm.OffsetX), CSng(mm.OffsetY))
            Dim transformer As Transformer = New Transformer(m)
            rc = Rectangle.Round(transformer.RectangleToPhysical(RectangleF.FromLTRB(rc.Left, rc.Top, rc.Right, rc.Bottom)))
            _viewer.Invalidate(rc)
         End If

         If ((e.Flags And CodecsLoadImageFlags.LastRow) = CodecsLoadImageFlags.LastRow AndAlso e.Page = e.LastPage) Then

            _viewer.Image.EnableEvents()
         End If
         ' A second method, is to use PaintBuffer, and paint the data buffer that this event provides
      Else
         Application.DoEvents()
         Dim g As Graphics = _viewer.CreateGraphics()
         Dim rcDest As LeadRect = New LeadRect(0, 0, e.Image.Width, e.Image.Height)
         Dim paintProps As RasterPaintProperties = _viewer.PaintProperties

         If ((e.Flags And CodecsLoadImageFlags.Compressed) = CodecsLoadImageFlags.Compressed) Then
            RasterImagePainter.PaintBuffer(e.Image, g, LeadRect.Empty, LeadRect.Empty, rcDest, LeadRect.Empty, e.Buffer.Data, e.Row, -e.Lines, paintProps)
         Else
            RasterImagePainter.PaintBuffer(e.Image, g, LeadRect.Empty, LeadRect.Empty, rcDest, LeadRect.Empty, e.Buffer.Data, e.Row, e.Lines, paintProps)
         End If
         g.Dispose()
      End If

      If (_cancelLoad) Then
         If (Not IsNothing(_viewer.Image)) Then
            _viewer.Image = Nothing
            e.Cancel = True
         End If
      End If
      ' simulate a slow load
      Thread.Sleep(10)
   End Sub

   Private Sub MainForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
      e.Cancel = _isLoading
   End Sub

   Private Sub MainForm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
      If (_isLoading) Then
         _cancelLoad = True
      End If
   End Sub

   ' <summary>
   ' show the about dialog
   ' </summary>
   Private Sub _miHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miHelpAbout.Click
      Using aboutDialog As New AboutDialog("Paint While Load", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub
End Class
