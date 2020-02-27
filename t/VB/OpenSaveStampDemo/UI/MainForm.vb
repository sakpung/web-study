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
   Friend WithEvents _miFileSaveWithStamp As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileOpen As System.Windows.Forms.MenuItem
   Friend WithEvents _miFile As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileSep1 As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileExit As System.Windows.Forms.MenuItem
   Friend WithEvents _miHelp As System.Windows.Forms.MenuItem
   Friend WithEvents _miHelpAbout As System.Windows.Forms.MenuItem
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
      Me._miFileSaveWithStamp = New System.Windows.Forms.MenuItem
      Me._miFileOpen = New System.Windows.Forms.MenuItem
      Me._mmMain = New System.Windows.Forms.MainMenu(Me.components)
      Me._miFile = New System.Windows.Forms.MenuItem
      Me._miFileSep1 = New System.Windows.Forms.MenuItem
      Me._miFileExit = New System.Windows.Forms.MenuItem
      Me._miHelp = New System.Windows.Forms.MenuItem
      Me._miHelpAbout = New System.Windows.Forms.MenuItem
      Me.SuspendLayout()
      '
      '_miFileSaveWithStamp
      '
      Me._miFileSaveWithStamp.Index = 1
      Me._miFileSaveWithStamp.Text = "&Save with Stamp..."
      '
      '_miFileOpen
      '
      Me._miFileOpen.Index = 0
      Me._miFileOpen.Text = "&Open..."
      '
      '_mmMain
      '
      Me._mmMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFile, Me._miHelp})
      '
      '_miFile
      '
      Me._miFile.Index = 0
      Me._miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFileOpen, Me._miFileSaveWithStamp, Me._miFileSep1, Me._miFileExit})
      Me._miFile.Text = "&File"
      '
      '_miFileSep1
      '
      Me._miFileSep1.Index = 2
      Me._miFileSep1.Text = "-"
      '
      '_miFileExit
      '
      Me._miFileExit.Index = 3
      Me._miFileExit.Text = "E&xit"
      '
      '_miHelp
      '
      Me._miHelp.Index = 1
      Me._miHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miHelpAbout})
      Me._miHelp.Text = "&Help"
      '
      '_miHelpAbout
      '
      Me._miHelpAbout.Index = 0
      Me._miHelpAbout.Text = "&About..."
      '
      'MainForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(680, 401)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Menu = Me._mmMain
      Me.Name = "MainForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "MainForm"
      Me.ResumeLayout(False)

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

   ' the raster codecs used in load\save
   Private _codecs As RasterCodecs

   ' Image/Stamp viewer, label, and stamp objects.
   Private _viewerStamp As ImageViewer
   Private _pnlStamp As Panel
   Private _lblStamp As Label
   Private _viewerImage As ImageViewer
   Private _pnlImage As Panel
   Private _lblImage As Label
   Private _openInitialPath As String = ""
   ' <summary>
   ' initialize the application
   ' </summary>

   Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

      ' Initialize image/stamp viewer, label, and stamp objects.
      _viewerStamp = New ImageViewer()
      _pnlStamp = New Panel()
      _lblStamp = New Label()
      _viewerImage = New ImageViewer()
      _pnlImage = New Panel()
      _lblImage = New Label()

      ' Image viewer object.
      _viewerImage.Dock = DockStyle.Fill
      _viewerImage.ViewHorizontalAlignment = ControlAlignment.Center
      _viewerImage.ViewVerticalAlignment = ControlAlignment.Near

      ' Image Panel object.
      _pnlImage.BorderStyle = BorderStyle.Fixed3D
      _pnlImage.Controls.Add(_lblImage)
      _pnlImage.Dock = System.Windows.Forms.DockStyle.Top
      _pnlImage.Size = New Size(680, 24)

      ' Image Label object.
      _lblImage.BorderStyle = BorderStyle.Fixed3D
      _lblImage.Dock = DockStyle.Fill
      _lblImage.FlatStyle = FlatStyle.System
      _lblImage.TextAlign = ContentAlignment.MiddleCenter

      ' Stamp viewer object.
      _viewerStamp.Dock = DockStyle.Bottom
      _viewerStamp.ViewHorizontalAlignment = ControlAlignment.Center
      _viewerStamp.ViewVerticalAlignment = ControlAlignment.Center

      ' Stamp Panel object.
      _pnlStamp.BorderStyle = BorderStyle.Fixed3D
      _pnlStamp.Controls.Add(_lblStamp)
      _pnlStamp.Dock = DockStyle.Bottom
      _pnlStamp.Size = New Size(680, 24)

      ' Stamp Label object.
      _lblStamp.BorderStyle = BorderStyle.Fixed3D
      _lblStamp.Dock = DockStyle.Fill
      _lblStamp.FlatStyle = FlatStyle.System
      _lblStamp.TextAlign = ContentAlignment.MiddleCenter

      Controls.Add(_viewerImage)
      Controls.Add(_pnlImage)
      Controls.Add(_pnlStamp)
      Controls.Add(_viewerStamp)

      ' setup our caption
      Messager.Caption = "LEADTOOLS for .NET VB Open and Save Stamp Demo"
      Text = Messager.Caption

      ' initialize the codecs object
      _codecs = New RasterCodecs

      UpdateMyControls()
   End Sub

   ' <summary>
   ' updates the UI depending on the program state
   ' </summary>
   Private Sub UpdateMyControls()
      If (Not IsNothing(_viewerImage.Image)) Then
         _miFileSaveWithStamp.Enabled = True
         _miFileSaveWithStamp.Visible = True
      Else
         _miFileSaveWithStamp.Enabled = False
         _miFileSaveWithStamp.Visible = False
      End If
   End Sub

   ' <summary>
   ' load a new image with its stamp, if it has one
   ' </summary>
   Private Sub _miFileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileOpen.Click
      Try
         ' load an image with its stamp, if it has stamp
         Dim ofd As OpenFileDialog = New OpenFileDialog
         ofd.Filter = "All Files|*.*"
         ofd.InitialDirectory = _openInitialPath
         If (ofd.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            ' clear the previous image and stamp (if applicable)
            _viewerImage.Image = Nothing
            _viewerStamp.Image = Nothing

            _openInitialPath = Path.GetDirectoryName(ofd.FileName)

            ' load the image
            _viewerImage.Image = _codecs.Load(ofd.FileName, 0, CodecsLoadByteOrder.BgrOrGray, 1, 1)

            ' update the labels
            _lblImage.Text = ofd.FileName

            ' load the stamp
            _viewerStamp.Image = _codecs.ReadStamp(ofd.FileName, 1)

            ' update the labels
            _lblStamp.Text = String.Format("Stamp - {0}", ofd.FileName)
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateMyControls()
      End Try

   End Sub

   ' <summary>
   ' Save the current image with stamp
   ' </summary>
   Private Sub _miFileSaveWithStamp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileSaveWithStamp.Click
      Try
         ' take the destination JPEG file name
         Dim sfd As SaveFileDialog = New SaveFileDialog
         ' the destination image format should be JPEG.
         sfd.Filter = "JPEG(*.jpg,*.jpeg)|*.jpg;*.jpeg"
         If (sfd.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            ' Enable saving with stamp
            _codecs.Options.Jpeg.Save.SaveWithStamp = True
            _codecs.Options.Jpeg.Save.StampBitsPerPixel = 24

            ' Calculate the stamp size (fit it in a 128 by 128 pixels)
            Dim rc As LeadRect = RasterImage.CalculatePaintModeRectangle( _
               _viewerImage.Image.ImageWidth, _
               _viewerImage.Image.ImageHeight, _
               New LeadRect(0, 0, 128, 128), _
               RasterPaintSizeMode.Fit, _
               RasterPaintAlignMode.Near, _
               RasterPaintAlignMode.Near)

            _codecs.Options.Jpeg.Save.StampWidth = rc.Width
            _codecs.Options.Jpeg.Save.StampHeight = rc.Height

            ' save the image as JPEG with stamp with the closest bits per pixel
            _codecs.Save(_viewerImage.Image, sfd.FileName, RasterImageFormat.Jpeg, 0)
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
      Using aboutDialog As New AboutDialog("Open and Save Stamp", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub
End Class
