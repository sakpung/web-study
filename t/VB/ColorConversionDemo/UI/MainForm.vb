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
Imports System.IO
Imports System.Text

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.ColorConversion
Imports Leadtools.ImageProcessing
Imports Leadtools.Controls
Imports Leadtools.WinForms.CommonDialogs.File
Imports Leadtools.Demos.Dialogs

Namespace ColorConversionDemo
   ''' <summary>
   ''' Summary description for MainForm.
   ''' </summary>
   Public Class MainForm : Inherits System.Windows.Forms.Form
      Private _miFile As System.Windows.Forms.MenuItem
      Private WithEvents _miFileOpen As System.Windows.Forms.MenuItem
      Private WithEvents _miFileClose As System.Windows.Forms.MenuItem
      Private _miFileSep1 As System.Windows.Forms.MenuItem
      Private WithEvents _miFileSaveAs As System.Windows.Forms.MenuItem
      Private _miFileSep2 As System.Windows.Forms.MenuItem
      Private WithEvents _miFileExit As System.Windows.Forms.MenuItem
      Private _mmMain As System.Windows.Forms.MainMenu
      Private _miHelp As System.Windows.Forms.MenuItem
      Private WithEvents _miHelpAbout As System.Windows.Forms.MenuItem
      Private _miConvert As System.Windows.Forms.MenuItem
      Private WithEvents _miConvertConvertTo As System.Windows.Forms.MenuItem
      Private _miView As System.Windows.Forms.MenuItem
      Private WithEvents _miViewFitImageToWindow As System.Windows.Forms.MenuItem
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing

      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

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
         Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MainForm))
         Me._mmMain = New System.Windows.Forms.MainMenu()
         Me._miFile = New System.Windows.Forms.MenuItem()
         Me._miFileOpen = New System.Windows.Forms.MenuItem()
         Me._miFileClose = New System.Windows.Forms.MenuItem()
         Me._miFileSep1 = New System.Windows.Forms.MenuItem()
         Me._miFileSaveAs = New System.Windows.Forms.MenuItem()
         Me._miFileSep2 = New System.Windows.Forms.MenuItem()
         Me._miFileExit = New System.Windows.Forms.MenuItem()
         Me._miConvert = New System.Windows.Forms.MenuItem()
         Me._miConvertConvertTo = New System.Windows.Forms.MenuItem()
         Me._miHelp = New System.Windows.Forms.MenuItem()
         Me._miHelpAbout = New System.Windows.Forms.MenuItem()
         Me._miView = New System.Windows.Forms.MenuItem()
         Me._miViewFitImageToWindow = New System.Windows.Forms.MenuItem()
         ' 
         ' _mmMain
         ' 
         Me._mmMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFile, Me._miView, Me._miConvert, Me._miHelp})
         ' 
         ' _miFile
         ' 
         Me._miFile.Index = 0
         Me._miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFileOpen, Me._miFileClose, Me._miFileSep1, Me._miFileSaveAs, Me._miFileSep2, Me._miFileExit})
         Me._miFile.Text = "&File"
         ' 
         ' _miFileOpen
         ' 
         Me._miFileOpen.Index = 0
         Me._miFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
         Me._miFileOpen.Text = "&Open..."
         ' 
         ' _miFileClose
         ' 
         Me._miFileClose.Index = 1
         Me._miFileClose.Text = "&Close"
         ' 
         ' _miFileSep1
         ' 
         Me._miFileSep1.Index = 2
         Me._miFileSep1.Text = "-"
         ' 
         ' _miFileSaveAs
         ' 
         Me._miFileSaveAs.Index = 3
         Me._miFileSaveAs.Shortcut = System.Windows.Forms.Shortcut.CtrlS
         Me._miFileSaveAs.Text = "&Save As..."
         ' 
         ' _miFileSep2
         ' 
         Me._miFileSep2.Index = 4
         Me._miFileSep2.Text = "-"
         ' 
         ' _miFileExit
         ' 
         Me._miFileExit.Index = 5
         Me._miFileExit.Text = "E&xit"
         ' 
         ' _miConvert
         ' 
         Me._miConvert.Index = 2
         Me._miConvert.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miConvertConvertTo})
         Me._miConvert.Text = "&Convert"
         ' 
         ' _miConvertConvertTo
         ' 
         Me._miConvertConvertTo.Index = 0
         Me._miConvertConvertTo.Text = "Convert &To..."
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
         Me._miHelpAbout.Text = "&About..."
         ' 
         ' _miView
         ' 
         Me._miView.Index = 1
         Me._miView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miViewFitImageToWindow})
         Me._miView.Text = "&View"
         ' 
         ' _miViewFitImageToWindow
         ' 
         Me._miViewFitImageToWindow.Index = 0
         Me._miViewFitImageToWindow.RadioCheck = True
         Me._miViewFitImageToWindow.Text = "&Fit Image to Window"
         ' 
         ' MainForm
         ' 
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(608, 393)
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
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
         Application.DoEvents()

         Application.Run(New MainForm())
      End Sub

      ' The raster image viewer
      Private _viewer As ImageViewer

      ' The raster codecs used in load/save.
      Private _codecs As RasterCodecs

      ' The type of conversion as a text
      Private Shared _conversionType As String
      Private _openInitialPath As String = String.Empty

      Public Shared WriteOnly Property ConversionType() As String
         Set(value As String)
            _conversionType = Value
         End Set
      End Property

      ''' <summary>
      ''' Initialize the application.
      ''' </summary>
      Private Sub InitClass()
         ' Setup our caption
         Messager.Caption = "LEADTOOLS for .NET VB Color Conversion Demo"
         Text = Messager.Caption

         ' Conversion type is nothing for now
         _conversionType = String.Empty

         ' Initialize the _viewer object
         _viewer = New ImageViewer()
         _viewer.Dock = DockStyle.Fill
         _viewer.BackColor = Color.DarkGray
         Controls.Add(_viewer)
         _viewer.BringToFront()

         _viewer.Zoom(ControlSizeMode.Fit, 1, _viewer.DefaultZoomOrigin)

         ' initialize the raster codecs object
         _codecs = New RasterCodecs()

         Try
            RasterColorConverterEngine.Startup()
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try

         LoadImage(True)
         UpdateMyControls()
      End Sub

      ''' <summary>
      ''' Shutting down
      ''' </summary>
      Private Sub CleanUp()
         RasterColorConverterEngine.Shutdown()
      End Sub

      ''' <summary>
      ''' Update the UI depending on the program state.
      ''' </summary>
      Private Sub UpdateMyControls()
         ' Update the menus and the Caption
         If Not _viewer.Image Is Nothing Then
            _miFileClose.Visible = True
            _miFileClose.Enabled = True
            _miFileSaveAs.Visible = True
            _miFileSaveAs.Enabled = True
            _miFileSep2.Visible = True
            _miFileSep2.Enabled = True
            _miConvert.Visible = True
            _miConvert.Enabled = True
            _miConvertConvertTo.Enabled = True
         Else
            _miFileClose.Visible = False
            _miFileClose.Enabled = False
            _miFileSaveAs.Visible = False
            _miFileSaveAs.Enabled = False
            _miFileSep2.Visible = False
            _miFileSep2.Enabled = False
            _miConvert.Visible = False
            _miConvert.Enabled = False
         End If

         _miViewFitImageToWindow.Checked = _viewer.SizeMode = ControlSizeMode.Fit
      End Sub

      ''' <summary>
      ''' Open a new image.
      ''' </summary>
      Private Sub _miFileOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _miFileOpen.Click
         LoadImage(False)
      End Sub

      Private Sub LoadImage(ByVal loadDefaultImage As Boolean)
         Dim loaderFilters As RasterOpenDialogLoadFormat() = New RasterOpenDialogLoadFormat(2) {}
         loaderFilters(0) = New RasterOpenDialogLoadFormat("Bitmap Files (*.dib;*.bmp)", "*.dib;*.bmp")
         loaderFilters(1) = New RasterOpenDialogLoadFormat("TIFF Files (*.tif)", "*.tif")
         loaderFilters(2) = New RasterOpenDialogLoadFormat("All Files (*.tif, *.bmp)", "*.tif;*.bmp")

         Dim loader As ImageFileLoader = New ImageFileLoader()
         loader.OpenDialogInitialPath = _openInitialPath
         loader.Filters = loaderFilters

         Dim bLoaded As Boolean = False

         Try
            If loadDefaultImage Then
               bLoaded = loader.Load(Me, DemosGlobal.ImagesFolder & "\ET\dst_rgb_image.tif", _codecs, 1, 1)
            Else
               bLoaded = loader.Load(Me, _codecs, True) > 0
            End If

            If bLoaded Then
               _openInitialPath = Path.GetDirectoryName(loader.FileName)
               ' Resize the image so each dimension becomes a multiple of 4. This is done because it's required by some color spaces 
               Dim width As Integer = loader.Image.Width
               Dim height As Integer = loader.Image.Height

               If (width Mod 4 = 0) Then
                  width += 0
               Else
                  width += (4 - (width Mod 4))
               End If
               If (height Mod 4 = 0) Then
                  height += 0
               Else
                  height += (4 - (height Mod 4))
               End If

               ' If the width and the height were the same, the SizeCommand will return immediately.
               Dim sizeCommand As SizeCommand = New SizeCommand(width, height, RasterSizeFlags.None)
               sizeCommand.Run(loader.Image)

               Dim info As CodecsImageInfo = _codecs.GetInformation(loader.FileName, False, 1)
               If info.BitsPerPixel = 24 Then
                  _viewer.Image = loader.Image
                  Text = "LEADTOOLS for .NET VB Color Conversion Demo"
               Else
                  Messager.ShowError(Me, "Format not supported" & Constants.vbLf & "this demo supports simple TIFF - (RGB24, CMYK, YCC and LAB) and BMP - (RGB24)")
               End If
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateMyControls()
         End Try
      End Sub

      ''' <summary>
      ''' Close the opened Image.
      ''' </summary>
      Private Sub _miFileClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _miFileClose.Click
         _viewer.Image = Nothing
         Text = Messager.Caption
         UpdateMyControls()
      End Sub

      ''' <summary>
      ''' Save the viewer Image.
      ''' </summary>
      Private Sub _miFileSaveAs_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _miFileSaveAs.Click
         Dim saver As ImageFileSaver = New ImageFileSaver()

         Try
            saver.Save(Me, _codecs, _viewer.Image)
         Catch ex As Exception
            Messager.ShowFileSaveError(Me, saver.FileName, ex)
         End Try
      End Sub

      ''' <summary>
      ''' Shutdown.
      ''' </summary>
      Private Sub _miFileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _miFileExit.Click
         Close()
      End Sub

      ''' <summary>
      ''' Converting between Color Spaces.
      ''' </summary>
      Private Sub _miConvertConvertTo_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _miConvertConvertTo.Click
         Dim dlg As ConvertToDialog = New ConvertToDialog(_viewer.Image, ConversionColorFormat.Bgr)

         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _viewer.Image = dlg.ResultImage
            Text = String.Format("Converted image ({1})- {0}", Messager.Caption, _conversionType)
         End If
      End Sub

      ''' <summary>
      ''' Show the About dialog.
      ''' </summary>
      Private Sub _miHelpAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _miHelpAbout.Click
         Using aboutDialog As New AboutDialog("Color Conversion", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _miViewFitImageToWindow_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _miViewFitImageToWindow.Click
         Dim sizeMode As ControlSizeMode = _viewer.SizeMode
         If sizeMode = ControlSizeMode.Fit Then
            sizeMode = ControlSizeMode.ActualSize
         Else
            sizeMode = ControlSizeMode.Fit
         End If

         _viewer.Zoom(sizeMode, 1, _viewer.DefaultZoomOrigin)
         UpdateMyControls()
      End Sub
   End Class
End Namespace
