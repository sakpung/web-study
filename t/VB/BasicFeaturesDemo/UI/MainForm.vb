' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Threading
Imports System.IO
Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.Demos.Dialogs

Namespace BasicFeaturesDemo
   ''' <summary>
   ''' Summary description for MainForm.
   ''' </summary>
   Public Class MainForm : Inherits Form
      Private _mmMain As MainMenu
      Private WithEvents _miFileOpen As MenuItem
      Private _miFile As MenuItem
      Private _miFileSep1 As MenuItem
      Private WithEvents _miFileExit As MenuItem
      Private _miBasicFeatures As MenuItem
      Private WithEvents _miBasicFeaturesBatch1 As MenuItem
      Private WithEvents _miBasicFeaturesBatch2 As MenuItem
      Private WithEvents _miBasicFeaturesUnderlay As MenuItem
      Private WithEvents _miBasicFeaturesGetSetRow As MenuItem
      Private _miHelp As MenuItem
      Private WithEvents _miHelpAbout As MenuItem
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
         Me._miFileSep1 = New System.Windows.Forms.MenuItem()
         Me._miFileExit = New System.Windows.Forms.MenuItem()
         Me._miBasicFeatures = New System.Windows.Forms.MenuItem()
         Me._miBasicFeaturesBatch1 = New System.Windows.Forms.MenuItem()
         Me._miBasicFeaturesBatch2 = New System.Windows.Forms.MenuItem()
         Me._miBasicFeaturesUnderlay = New System.Windows.Forms.MenuItem()
         Me._miBasicFeaturesGetSetRow = New System.Windows.Forms.MenuItem()
         Me._miHelp = New System.Windows.Forms.MenuItem()
         Me._miHelpAbout = New System.Windows.Forms.MenuItem()
         Me.SuspendLayout()
         ' 
         ' _mmMain
         ' 
         Me._mmMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFile, Me._miBasicFeatures, Me._miHelp})
         ' 
         ' _miFile
         ' 
         Me._miFile.Index = 0
         Me._miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFileOpen, Me._miFileSep1, Me._miFileExit})
         Me._miFile.Text = "&File"
         ' 
         ' _miFileOpen
         ' 
         Me._miFileOpen.Index = 0
         Me._miFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
         Me._miFileOpen.Text = "&Open..."
         ' 
         ' _miFileSep1
         ' 
         Me._miFileSep1.Index = 1
         Me._miFileSep1.Text = "-"
         ' 
         ' _miFileExit
         ' 
         Me._miFileExit.Index = 2
         Me._miFileExit.Text = "E&xit"
         ' 
         ' _miBasicFeatures
         ' 
         Me._miBasicFeatures.Index = 1
         Me._miBasicFeatures.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miBasicFeaturesBatch1, Me._miBasicFeaturesBatch2, Me._miBasicFeaturesUnderlay, Me._miBasicFeaturesGetSetRow})
         Me._miBasicFeatures.Text = "&Basic Features"
         ' 
         ' _miBasicFeaturesBatch1
         ' 
         Me._miBasicFeaturesBatch1.Index = 0
         Me._miBasicFeaturesBatch1.Text = "Batch &1"
         ' 
         ' _miBasicFeaturesBatch2
         ' 
         Me._miBasicFeaturesBatch2.Index = 1
         Me._miBasicFeaturesBatch2.Text = "Batch &2"
         ' 
         ' _miBasicFeaturesUnderlay
         ' 
         Me._miBasicFeaturesUnderlay.Index = 2
         Me._miBasicFeaturesUnderlay.Text = "&Underlay"
         ' 
         ' _miBasicFeaturesGetSetRow
         ' 
         Me._miBasicFeaturesGetSetRow.Index = 3
         Me._miBasicFeaturesGetSetRow.Text = "Get/Set Row"
         ' 
         ' _miHelp
         ' 
         Me._miHelp.Index = 2
         Me._miHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miHelpAbout})
         Me._miHelp.Text = "&Help"
         ' 
         ' _miHelpAbout
         ' 
         Me._miHelpAbout.Index = 0
         Me._miHelpAbout.Text = "&About..."
         ' 
         ' MainForm
         ' 
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(552, 401)
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
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

         Application.Run(New MainForm())
      End Sub

      ' the raster image viewer
      Private _viewer As ImageViewer

      ' the raster codecs used in load/save
      Private _codecs As RasterCodecs
      Private _openInitialPath As String = String.Empty
      ''' <summary>
      ''' Initialize the application
      ''' </summary>
      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         ' setup our caption
         Messager.Caption = "LEADTOOLS for .NET VB Basic Features Demo"
         Text = Messager.Caption

         ' initialize the _viewer object
         _viewer = New ImageViewer()
         _viewer.Dock = DockStyle.Fill
         _viewer.BackColor = Color.DarkGray
         Controls.Add(_viewer)
         _viewer.BringToFront()

         ' initialize the codecs object
         _codecs = New RasterCodecs()

         UpdateMyControls()
      End Sub

      ''' <summary>
      ''' Update the UI depending on the program state
      ''' </summary>
      Private Sub UpdateMyControls()
         ' update the menu items
         If Not _viewer.Image Is Nothing Then
            _miBasicFeatures.Enabled = True
            _miBasicFeatures.Visible = True
         Else
            _miBasicFeatures.Enabled = False
            _miBasicFeatures.Visible = False
         End If
      End Sub

      ''' <summary>
      ''' load a new image
      ''' </summary>
      Private Sub _miFileOpen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miFileOpen.Click
         Try
            ' load the image
            Dim loader As ImageFileLoader = New ImageFileLoader()
            loader.OpenDialogInitialPath = _openInitialPath
            If loader.Load(Me, _codecs, True) > 0 Then
               _openInitialPath = Path.GetDirectoryName(loader.FileName)
               ' update the caption
               Text = String.Format("{0} - {1}", loader.FileName, Messager.Caption)

               'set the new image in the viewer
               _viewer.Image = loader.Image
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateMyControls()
         End Try
      End Sub

      ''' <summary>
      ''' Shutdown
      ''' </summary>
      Private Sub _miFileExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miFileExit.Click
         Close()
      End Sub

      ''' <summary>
      ''' Select the Batch 1 functions
      ''' </summary>
      Private Sub _miBasicFeaturesBatch1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miBasicFeaturesBatch1.Click
         Const message As String = "Batch1 does the following:" & ControlChars.CrLf _
                                   & "   1. Color Resolution" & ControlChars.CrLf _
                                   & "   2. Flip" & ControlChars.CrLf _
                                   & "   3. Intensity" & ControlChars.CrLf _
                                   & "   4. Resize" & ControlChars.CrLf _
                                   & "   5. Rotate"

         Messager.ShowInformation(Me, message)
         DoBatch1()
      End Sub

      ''' <summary>
      ''' Batch 1 Functions
      ''' </summary>
      Private Sub DoBatch1()
         ' save the current caption
         Dim tmpCaption As String = Text
         ' change cursor
         Cursor = Cursors.SizeNS
         ' disable the form
         Me.Enabled = False
         ' Do Color Resolution
         Text = "Optimizing Image To 8 Bits Per Pixel With Burkes Dithering..."
         Dim colorResCommand As ColorResolutionCommand = New ColorResolutionCommand()
         colorResCommand.BitsPerPixel = 8
         colorResCommand.DitheringMethod = RasterDitheringMethod.Burkes
         colorResCommand.PaletteFlags = ColorResolutionCommandPaletteFlags.Optimized
         colorResCommand.Mode = ColorResolutionCommandMode.InPlace
         colorResCommand.Order = RasterByteOrder.Bgr
         colorResCommand.SetPalette(Nothing)
         colorResCommand.Run(_viewer.Image)
         Text = "Image Is Optimized"
         _viewer.Refresh()
         Thread.Sleep(2000)

         ' change cursor
         Cursor = Cursors.SizeWE
         ' Do Flip
         Text = "Flipping Image..."
         Dim flipCommand As FlipCommand = New FlipCommand()
         flipCommand.Horizontal = False
         flipCommand.Run(_viewer.Image)
         Text = "Image Is Flipped"
         _viewer.Refresh()
         Thread.Sleep(2000)

         ' change cursor
         Cursor = Cursors.SizeNS
         ' Do Lightening
         Text = "Lightening Image..."
         Dim changeIntensityCommand As ChangeIntensityCommand = New ChangeIntensityCommand()
         changeIntensityCommand.Brightness = 200
         changeIntensityCommand.Run(_viewer.Image)
         Text = "Image Is Lightened"
         _viewer.Refresh()
         Thread.Sleep(2000)

         ' change cursor
         Cursor = Cursors.SizeWE
         ' Do Resize
         Text = "Resizing Image..."
         Dim resizeCommand As ResizeCommand = New ResizeCommand()
         resizeCommand.Flags = RasterSizeFlags.None
         resizeCommand.DestinationImage = New RasterImage(RasterMemoryFlags.Conventional, CInt((_viewer.Image.Width + 1) / 2), CInt((_viewer.Image.Height + 1) / 2), _viewer.Image.BitsPerPixel, _viewer.Image.Order, _viewer.Image.ViewPerspective, _viewer.Image.GetPalette(), IntPtr.Zero, 0)
         resizeCommand.Run(_viewer.Image)
         _viewer.Image = resizeCommand.DestinationImage
         Text = "Image Is Resized"
         _viewer.Refresh()
         Thread.Sleep(2000)

         Cursor = Cursors.SizeNS
         ' Do Rotate
         Text = "Rotating Image..."
         Dim rotateCommand As RotateCommand = New RotateCommand()
         rotateCommand.Angle = -4500
         rotateCommand.FillColor = New RasterColor(255, 0, 0)
         rotateCommand.Flags = RotateCommandFlags.None

         rotateCommand.Run(_viewer.Image)
         Text = "Image Is Rotated, Batch Is Complete"
         _viewer.Refresh()
         Thread.Sleep(2000)

         ' change the cursor to arrow
         Cursor = Cursors.Arrow

         ' return the old caption
         Text = tmpCaption

         ' enable the form
         Me.Enabled = True
      End Sub

      ''' <summary>
      ''' Select the Batch 2 functions
      ''' </summary>
      Private Sub _miBasicFeaturesBatch2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miBasicFeaturesBatch2.Click
         Const message As String = "Batch2 does the following:" & ControlChars.CrLf _
                                   & "   1. AntiAliasing" & ControlChars.CrLf _
                                   & "   2. Reverse" & ControlChars.CrLf _
                                   & "   3. Grayscale" & ControlChars.CrLf _
                                   & "   4. Invert"

         Messager.ShowInformation(Me, message)
         DoBatch2()
      End Sub

      ''' <summary>
      ''' Batch 2 Functions
      ''' </summary>
      Private Sub DoBatch2()
         ' save the current caption
         Dim tmpCaption As String = Text

         ' disable the form
         Me.Enabled = False

         ' change cursor
         Cursor = Cursors.SizeNS

         ' Do AntiAlias
         Text = "AntiAliasing Image..."
         Dim antiAliasingCommand As AntiAliasingCommand = New AntiAliasingCommand()
         antiAliasingCommand.Threshold = 25
         antiAliasingCommand.Dimension = 7
         antiAliasingCommand.Filter = AntiAliasingCommandType.Type1
         antiAliasingCommand.Run(_viewer.Image)
         Text = "Image Is AntiAliased"
         _viewer.Refresh()
         Thread.Sleep(2000)

         ' change cursor
         Cursor = Cursors.SizeWE
         ' Do Reverse
         Text = "Reversing Image..."
         Dim flipCommand As FlipCommand = New FlipCommand()
         flipCommand.Horizontal = True
         flipCommand.Run(_viewer.Image)
         Text = "Image Is Reversed"
         _viewer.Refresh()
         Thread.Sleep(2000)

         ' change cursor
         Cursor = Cursors.SizeNS
         ' Do Grayscale
         Text = "Grayscaling Image..."
         Dim grayScaleCommand As GrayscaleCommand = New GrayscaleCommand()
         Thread.Sleep(1000)
         grayScaleCommand.BitsPerPixel = 8
         grayScaleCommand.Run(_viewer.Image)
         Text = "Image Is Grayscaled"
         _viewer.Refresh()
         Thread.Sleep(2000)

         ' change cursor
         Cursor = Cursors.SizeWE
         ' Do Invert
         Text = "Inverting Image..."
         Dim invertCommand As InvertCommand = New InvertCommand()
         invertCommand.Run(_viewer.Image)
         Text = "Image Is Inverted, Batch Is Complete"
         _viewer.Refresh()
         Thread.Sleep(2000)

         ' change the cursor to arrow
         Cursor = Cursors.Arrow

         ' enable the form
         Me.Enabled = True

         ' return the old caption
         Text = tmpCaption
      End Sub

      ''' <summary>
      ''' Underlay an Image
      ''' </summary>
      Private Sub _miBasicFeaturesUnderlay_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miBasicFeaturesUnderlay.Click
         Try
            Dim loader As ImageFileLoader = New ImageFileLoader()
            If loader.Load(Me, _codecs, True) > 0 Then
               Using dlg As UnderlayDialog = New UnderlayDialog()
                  If dlg.ShowDialog(Me) = DialogResult.OK Then
                     Using wait As WaitCursor = New WaitCursor()
                        _viewer.Image.Underlay(loader.Image, dlg.Flags)
                     End Using
                  End If
               End Using
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      ''' <summary>
      ''' Optimizing the Image to 8 bpp, and Rotating the Image using GetRow and SetRowColumn methods
      ''' </summary>
      Private Sub _miBasicFeaturesGetSetRow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miBasicFeaturesGetSetRow.Click
         Try
            ' convert the image to 8 bpp
            Dim colorResCommand As ColorResolutionCommand = New ColorResolutionCommand()
            colorResCommand.BitsPerPixel = 8
            colorResCommand.DitheringMethod = RasterDitheringMethod.FloydStein
            colorResCommand.PaletteFlags = ColorResolutionCommandPaletteFlags.Optimized
            colorResCommand.Mode = ColorResolutionCommandMode.InPlace
            colorResCommand.Order = RasterByteOrder.Bgr
            colorResCommand.SetPalette(Nothing)
            colorResCommand.Run(_viewer.Image)
            _viewer.Refresh()

            ' the row number
            Dim outRow As Integer = _viewer.Image.Width - 1
            ' the column number
            Dim outCol As Integer = 0
            ' Allocate the buffer.
            Dim buffer As Byte() = New Byte(_viewer.Image.BytesPerLine - 1) {}
            ' the temp image to save the rotated image (8 bpp, and Height*Width).
            Dim tmpImg As RasterImage = New RasterImage(RasterMemoryFlags.Conventional, _viewer.Image.Height, _viewer.Image.Width, 8, _viewer.Image.Order, _viewer.Image.ViewPerspective, _viewer.Image.GetPalette(), IntPtr.Zero, 0)

            Dim i As Integer = 0
            Do While i < _viewer.Image.Height
               _viewer.Image.Access()

               _viewer.Image.GetRow(i, buffer, 0, _viewer.Image.BytesPerLine)

               ' loop into the image
               Dim j As Integer = 0
               Do While j < tmpImg.Height
                  ' set the row as column
                  tmpImg.SetRowColumn(outRow, outCol, buffer, j, 1)
                  ' move to the next row
                  outRow -= 1
                  j += 1
               Loop
               ' move to the next column
               outCol += 1
               ' reset the row number
               outRow = _viewer.Image.Width - 1
               i += 1
            Loop
            ' set the rotated image into the viewer
            _viewer.Image = tmpImg

            _viewer.Image.Release()
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      ''' <summary>
      ''' display the about dialog
      ''' </summary>
      Private Sub _miHelpAbout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miHelpAbout.Click
         Using aboutDialog As New AboutDialog("Basic Features", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub
   End Class
End Namespace
