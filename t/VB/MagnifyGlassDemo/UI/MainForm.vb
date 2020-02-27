' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.IO

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.WinForms
Imports Leadtools.Demos.Dialogs

#If LEADTOOLS_V17_OR_LATER Then
Imports Leadtools.Drawing
#End If ' #if LEADTOOLS_V17_OR_LATER

Namespace MagnifyGlassDemo
   ''' <summary>
   ''' Summary description for MainForm.
   ''' </summary>
   Public Class MainForm : Inherits System.Windows.Forms.Form
      Private _mmMain As System.Windows.Forms.MainMenu
      Private _miFile As System.Windows.Forms.MenuItem
      Private WithEvents _miFileOpen As System.Windows.Forms.MenuItem
      Private _miFileSep1 As System.Windows.Forms.MenuItem
      Private WithEvents _miFileExit As System.Windows.Forms.MenuItem
      Private _miMagnifyGlass As System.Windows.Forms.MenuItem
      Private WithEvents _miMagnifyGlassStart As System.Windows.Forms.MenuItem
      Private WithEvents _miMagnifyGlassStop As System.Windows.Forms.MenuItem
      Private _miMagnifyGlassSep1 As System.Windows.Forms.MenuItem
      Private WithEvents _miMagnifyGlassResizeWidth As System.Windows.Forms.MenuItem
      Private WithEvents _miMagnifyGlassResizeHeight As System.Windows.Forms.MenuItem
      Private WithEvents _miMagnifyGlassResizeBorder As System.Windows.Forms.MenuItem
      Private _miColors As System.Windows.Forms.MenuItem
      Private WithEvents _miColorsBorderColor As System.Windows.Forms.MenuItem
      Private WithEvents _miColorsCrosshairColor As System.Windows.Forms.MenuItem
      Private _miOptions As System.Windows.Forms.MenuItem
      Private _miOptionsCrosshair As System.Windows.Forms.MenuItem
      Private WithEvents _miOptionsCrosshairNone As System.Windows.Forms.MenuItem
      Private WithEvents _miOptionsCrosshairFine As System.Windows.Forms.MenuItem
      Private _miShape As System.Windows.Forms.MenuItem
      Private WithEvents _miShapeRectangle As System.Windows.Forms.MenuItem
      Private WithEvents _miShapeEllipse As System.Windows.Forms.MenuItem
      Private WithEvents _miShapeRoundRectangle As System.Windows.Forms.MenuItem
      Private WithEvents _miShapeNone As System.Windows.Forms.MenuItem
      Private _miHelp As System.Windows.Forms.MenuItem
      Private WithEvents _miAbout As System.Windows.Forms.MenuItem
      Private _miOptions3DBorderAdjust As System.Windows.Forms.MenuItem
      Private _miOptions3DBorderBump As System.Windows.Forms.MenuItem
      Private _miOptions3DBorderEtched As System.Windows.Forms.MenuItem
      Private _miOptions3DBorderFlat As System.Windows.Forms.MenuItem
      Private _miOptions3DBorderRaised As System.Windows.Forms.MenuItem
      Private _miOptions3DBorderRaisedInner As System.Windows.Forms.MenuItem
      Private _miOptions3DBorderRaisedOuter As System.Windows.Forms.MenuItem
      Private _miOptions3DBorderRaisedBoth As System.Windows.Forms.MenuItem
      Private _miOptions3DBorderSunken As System.Windows.Forms.MenuItem
      Private _miOptions3DBorderSunkenInner As System.Windows.Forms.MenuItem
      Private _miOptions3DBorderSunkenOuter As System.Windows.Forms.MenuItem
      Private _miOptions3DBorderSunkenBoth As System.Windows.Forms.MenuItem
      Private WithEvents _miMagnifyGlassScaleFactor As System.Windows.Forms.MenuItem
      Private WithEvents _miMagnifyGlassRoundRectangleEllipseSize As System.Windows.Forms.MenuItem

      Private magGlass As ImageViewerMagnifyGlassInteractiveMode = New ImageViewerMagnifyGlassInteractiveMode()
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
         Me._miMagnifyGlass = New System.Windows.Forms.MenuItem()
         Me._miMagnifyGlassStart = New System.Windows.Forms.MenuItem()
         Me._miMagnifyGlassStop = New System.Windows.Forms.MenuItem()
         Me._miMagnifyGlassSep1 = New System.Windows.Forms.MenuItem()
         Me._miMagnifyGlassResizeWidth = New System.Windows.Forms.MenuItem()
         Me._miMagnifyGlassResizeHeight = New System.Windows.Forms.MenuItem()
         Me._miMagnifyGlassResizeBorder = New System.Windows.Forms.MenuItem()
         Me._miMagnifyGlassScaleFactor = New System.Windows.Forms.MenuItem()
         Me._miMagnifyGlassRoundRectangleEllipseSize = New System.Windows.Forms.MenuItem()
         Me._miColors = New System.Windows.Forms.MenuItem()
         Me._miColorsBorderColor = New System.Windows.Forms.MenuItem()
         Me._miColorsCrosshairColor = New System.Windows.Forms.MenuItem()
         Me._miOptions = New System.Windows.Forms.MenuItem()
         Me._miOptionsCrosshair = New System.Windows.Forms.MenuItem()
         Me._miOptionsCrosshairNone = New System.Windows.Forms.MenuItem()
         Me._miOptionsCrosshairFine = New System.Windows.Forms.MenuItem()
         Me._miShape = New System.Windows.Forms.MenuItem()
         Me._miShapeRectangle = New System.Windows.Forms.MenuItem()
         Me._miShapeEllipse = New System.Windows.Forms.MenuItem()
         Me._miShapeRoundRectangle = New System.Windows.Forms.MenuItem()
         Me._miShapeNone = New System.Windows.Forms.MenuItem()
         Me._miHelp = New System.Windows.Forms.MenuItem()
         Me._miAbout = New System.Windows.Forms.MenuItem()
         Me._miOptions3DBorderAdjust = New System.Windows.Forms.MenuItem()
         Me._miOptions3DBorderBump = New System.Windows.Forms.MenuItem()
         Me._miOptions3DBorderEtched = New System.Windows.Forms.MenuItem()
         Me._miOptions3DBorderFlat = New System.Windows.Forms.MenuItem()
         Me._miOptions3DBorderRaised = New System.Windows.Forms.MenuItem()
         Me._miOptions3DBorderRaisedInner = New System.Windows.Forms.MenuItem()
         Me._miOptions3DBorderRaisedOuter = New System.Windows.Forms.MenuItem()
         Me._miOptions3DBorderRaisedBoth = New System.Windows.Forms.MenuItem()
         Me._miOptions3DBorderSunken = New System.Windows.Forms.MenuItem()
         Me._miOptions3DBorderSunkenInner = New System.Windows.Forms.MenuItem()
         Me._miOptions3DBorderSunkenOuter = New System.Windows.Forms.MenuItem()
         Me._miOptions3DBorderSunkenBoth = New System.Windows.Forms.MenuItem()
         Me.SuspendLayout()
         ' 
         ' _mmMain
         ' 
         Me._mmMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFile, Me._miMagnifyGlass, Me._miColors, Me._miOptions, Me._miShape, Me._miHelp})
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
         ' _miMagnifyGlass
         ' 
         Me._miMagnifyGlass.Index = 1
         Me._miMagnifyGlass.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miMagnifyGlassStart, Me._miMagnifyGlassStop, Me._miMagnifyGlassSep1, Me._miMagnifyGlassResizeWidth, Me._miMagnifyGlassResizeHeight, Me._miMagnifyGlassResizeBorder, Me._miMagnifyGlassScaleFactor, Me._miMagnifyGlassRoundRectangleEllipseSize})
         Me._miMagnifyGlass.Text = "&MagnifyGlass"
         ' 
         ' _miMagnifyGlassStart
         ' 
         Me._miMagnifyGlassStart.Index = 0
         Me._miMagnifyGlassStart.Text = "&Start"
         ' 
         ' _miMagnifyGlassStop
         ' 
         Me._miMagnifyGlassStop.Index = 1
         Me._miMagnifyGlassStop.Text = "Sto&p"
         ' 
         ' _miMagnifyGlassSep1
         ' 
         Me._miMagnifyGlassSep1.Index = 2
         Me._miMagnifyGlassSep1.Text = "-"
         ' 
         ' _miMagnifyGlassResizeWidth
         ' 
         Me._miMagnifyGlassResizeWidth.Index = 3
         Me._miMagnifyGlassResizeWidth.Text = "Resize &Width..."
         ' 
         ' _miMagnifyGlassResizeHeight
         ' 
         Me._miMagnifyGlassResizeHeight.Index = 4
         Me._miMagnifyGlassResizeHeight.Text = "Resize &Height..."
         ' 
         ' _miMagnifyGlassResizeBorder
         ' 
         Me._miMagnifyGlassResizeBorder.Index = 5
         Me._miMagnifyGlassResizeBorder.Text = "Resize &Border..."
         ' 
         ' _miMagnifyGlassScaleFactor
         ' 
         Me._miMagnifyGlassScaleFactor.Index = 6
         Me._miMagnifyGlassScaleFactor.Text = "&Scale Factor..."
         ' 
         ' _miMagnifyGlassRoundRectangleEllipseSize
         ' 
         Me._miMagnifyGlassRoundRectangleEllipseSize.Index = 7
         Me._miMagnifyGlassRoundRectangleEllipseSize.Text = "Round Rectangle Ellipse Size..."
         ' 
         ' _miColors
         ' 
         Me._miColors.Index = 2
         Me._miColors.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miColorsBorderColor, Me._miColorsCrosshairColor})
         Me._miColors.Text = "&Colors"
         ' 
         ' _miColorsBorderColor
         ' 
         Me._miColorsBorderColor.Index = 0
         Me._miColorsBorderColor.Text = "&Border Color..."
         ' 
         ' _miColorsCrosshairColor
         ' 
         Me._miColorsCrosshairColor.Index = 1
         Me._miColorsCrosshairColor.Text = "&Crosshair Color..."
         ' 
         ' _miOptions
         ' 
         Me._miOptions.Index = 3
         Me._miOptions.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miOptionsCrosshair})
         Me._miOptions.Text = "&Options"
         ' 
         ' _miOptionsCrosshair
         ' 
         Me._miOptionsCrosshair.Index = 0
         Me._miOptionsCrosshair.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miOptionsCrosshairNone, Me._miOptionsCrosshairFine})
         Me._miOptionsCrosshair.Text = "&Crosshair"
         ' 
         ' _miOptionsCrosshairNone
         ' 
         Me._miOptionsCrosshairNone.Index = 0
         Me._miOptionsCrosshairNone.Text = "&None"
         ' 
         ' _miOptionsCrosshairFine
         ' 
         Me._miOptionsCrosshairFine.Index = 1
         Me._miOptionsCrosshairFine.Text = "&Fine"
         ' 
         ' _miShape
         ' 
         Me._miShape.Index = 4
         Me._miShape.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miShapeRectangle, Me._miShapeEllipse, Me._miShapeRoundRectangle, Me._miShapeNone})
         Me._miShape.Text = "&Shape"
         ' 
         ' _miShapeRectangle
         ' 
         Me._miShapeRectangle.Index = 0
         Me._miShapeRectangle.Text = "&Rectangle"
         ' 
         ' _miShapeEllipse
         ' 
         Me._miShapeEllipse.Index = 1
         Me._miShapeEllipse.Text = "&Ellipse"
         ' 
         ' _miShapeRoundRectangle
         ' 
         Me._miShapeRoundRectangle.Index = 2
         Me._miShapeRoundRectangle.Text = "&Round Rectangle"
         ' 
         ' _miShapeNone
         ' 
         Me._miShapeNone.Index = 3
         Me._miShapeNone.Text = "&None"
         ' 
         ' _miHelp
         ' 
         Me._miHelp.Index = 5
         Me._miHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miAbout})
         Me._miHelp.Text = "&Help"
         ' 
         ' _miAbout
         ' 
         Me._miAbout.Index = 0
         Me._miAbout.Text = "&About..."
         ' 
         ' _miOptions3DBorderAdjust
         ' 
         Me._miOptions3DBorderAdjust.Index = -1
         Me._miOptions3DBorderAdjust.Text = ""
         ' 
         ' _miOptions3DBorderBump
         ' 
         Me._miOptions3DBorderBump.Index = -1
         Me._miOptions3DBorderBump.Text = ""
         ' 
         ' _miOptions3DBorderEtched
         ' 
         Me._miOptions3DBorderEtched.Index = -1
         Me._miOptions3DBorderEtched.Text = ""
         ' 
         ' _miOptions3DBorderFlat
         ' 
         Me._miOptions3DBorderFlat.Index = -1
         Me._miOptions3DBorderFlat.Text = ""
         ' 
         ' _miOptions3DBorderRaised
         ' 
         Me._miOptions3DBorderRaised.Index = -1
         Me._miOptions3DBorderRaised.Text = ""
         ' 
         ' _miOptions3DBorderRaisedInner
         ' 
         Me._miOptions3DBorderRaisedInner.Index = -1
         Me._miOptions3DBorderRaisedInner.Text = ""
         ' 
         ' _miOptions3DBorderRaisedOuter
         ' 
         Me._miOptions3DBorderRaisedOuter.Index = -1
         Me._miOptions3DBorderRaisedOuter.Text = ""
         ' 
         ' _miOptions3DBorderRaisedBoth
         ' 
         Me._miOptions3DBorderRaisedBoth.Index = -1
         Me._miOptions3DBorderRaisedBoth.Text = ""
         ' 
         ' _miOptions3DBorderSunken
         ' 
         Me._miOptions3DBorderSunken.Index = -1
         Me._miOptions3DBorderSunken.Text = ""
         ' 
         ' _miOptions3DBorderSunkenInner
         ' 
         Me._miOptions3DBorderSunkenInner.Index = -1
         Me._miOptions3DBorderSunkenInner.Text = ""
         ' 
         ' _miOptions3DBorderSunkenOuter
         ' 
         Me._miOptions3DBorderSunkenOuter.Index = -1
         Me._miOptions3DBorderSunkenOuter.Text = ""
         ' 
         ' _miOptions3DBorderSunkenBoth
         ' 
         Me._miOptions3DBorderSunkenBoth.Index = -1
         Me._miOptions3DBorderSunkenBoth.Text = ""
         ' 
         ' MainForm
         ' 
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.BackColor = System.Drawing.Color.DarkGray
         Me.ClientSize = New System.Drawing.Size(608, 393)
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

      ' the raster codecs used in load
      Private _codecs As RasterCodecs

      ' MagnifyGlass border color
      Private _borderColor As Color

      ' MagnifyGlass border width
      Private _borderWidth As Integer

      ' MagnifyGlass crosshair type
      Private _crosshair As ImageViewerSpyGlassCrosshair

      ' MagnifyGlass crosshair color
      Private _crosshairColor As Color

      ' MagnifyGlass crosshair width
      Private _crosshairWidth As Integer

      ' MagnifyGlass round rectangle ellipse size
      Private _roundRectangleEllipseSize As LeadSize

      ' MagnifyGlass scale factor (zoom factor)
      Private _scaleFactor As Single

      ' MagnifyGlass shape type
      Private _shape As ImageViewerSpyGlassShape

      ' MagnifyGlass size
      Private _size As LeadSize

      Private _openInitialPath As String = String.Empty

      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         ' setup our caption
         Messager.Caption = "LEADTOOLS for .NET VB MagnifyGlass Demo"
         Text = Messager.Caption

         ' initialize the _viewer object    
         _viewer = New ImageViewer()

         ' Add the MagnifyGlass InteractiveMode
         _viewer.InteractiveModes.Add(magGlass)

         Dim paintProperties As RasterPaintProperties = RasterPaintProperties.Default
         paintProperties.PaintDisplayMode = paintProperties.PaintDisplayMode Or RasterPaintDisplayModeFlags.Bicubic Or RasterPaintDisplayModeFlags.ScaleToGray
         paintProperties.PaintEngine = RasterPaintEngine.GdiPlus
         _viewer.PaintProperties = paintProperties
         _viewer.Dock = DockStyle.Fill
         _viewer.BackColor = Color.DarkGray
         Controls.Add(_viewer)
         _viewer.BringToFront()

         ' initialize the codecs object
         _codecs = New RasterCodecs()

         ' initialize the other variables
         _borderColor = Color.Red
         _borderWidth = 2
         _crosshair = ImageViewerSpyGlassCrosshair.Fine
         _crosshairColor = Color.Green
         _crosshairWidth = 1
         _roundRectangleEllipseSize = New LeadSize(20, 20)
         _scaleFactor = 2
         _shape = ImageViewerSpyGlassShape.Rectangle
         _size = New LeadSize(150, 150)

         UpdateMyControls()
      End Sub

      ''' <summary>
      ''' Updates the UI depending on the program state.
      ''' </summary>
      Private Sub UpdateMyControls()
         If Not _viewer.Image Is Nothing Then
            ' update the menu items
            _miMagnifyGlass.Enabled = True
            _miMagnifyGlass.Visible = True

            _miColors.Enabled = True
            _miColors.Visible = True

            _miOptions.Enabled = True
            _miOptions.Visible = True

            _miShape.Enabled = True
            _miShape.Visible = True

            For Each _interactivemode As ImageViewerInteractiveMode In _viewer.InteractiveModes
               If _interactivemode.Name = "MagnifyGlass" Then
                  magGlass = TryCast(_interactivemode, ImageViewerMagnifyGlassInteractiveMode)
               End If
            Next _interactivemode

            _miMagnifyGlassStart.Enabled = Not (magGlass.IsStarted)
            _miMagnifyGlassStop.Enabled = (magGlass.IsStarted)

            _miOptionsCrosshairNone.Checked = (_crosshair = ImageViewerSpyGlassCrosshair.None)
            _miOptionsCrosshairFine.Checked = (_crosshair = ImageViewerSpyGlassCrosshair.Fine)
            _miShapeRectangle.Checked = (_shape = ImageViewerSpyGlassShape.Rectangle)
            _miShapeEllipse.Checked = (_shape = ImageViewerSpyGlassShape.Ellipse)
            _miShapeRoundRectangle.Checked = (_shape = ImageViewerSpyGlassShape.RoundRectangle)
            _miShapeNone.Checked = (_shape = ImageViewerSpyGlassShape.None)

            ' update the MagnifyGlass members                
            magGlass.Crosshair = _crosshair
            magGlass.BorderPen = New Pen(_borderColor, _borderWidth)
            magGlass.CrosshairPen = New Pen(_crosshairColor, _crosshairWidth)
            magGlass.RoundRectangleRadius = _roundRectangleEllipseSize
            magGlass.ScaleFactor = _scaleFactor
            magGlass.Shape = _shape
            magGlass.Size = _size

         Else
            _miMagnifyGlass.Enabled = False
            _miMagnifyGlass.Visible = False

            _miColors.Enabled = False
            _miColors.Visible = False

            _miOptions.Enabled = False
            _miOptions.Visible = False

            _miShape.Enabled = False
            _miShape.Visible = False
         End If
      End Sub

      ''' <summary>
      ''' load new image
      ''' </summary>

      Private Sub _miFileOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileOpen.Click
         Try
            ' load the image
            Dim loader As ImageFileLoader = New ImageFileLoader()

            loader.OpenDialogInitialPath = _openInitialPath

            If loader.Load(Me, _codecs, True) > 0 Then
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

      ''' <summary>
      ''' Shutdown
      ''' </summary>
      Private Sub _miFileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miFileExit.Click
         Close()
      End Sub

      ''' <summary>
      ''' Start MagnifyGlass
      ''' </summary>
      Private Sub _miMagnifyGlassStart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miMagnifyGlassStart.Click

         For Each _interactivemode As ImageViewerInteractiveMode In _viewer.InteractiveModes

            If _interactivemode.Name = "MagnifyGlass" Then
               magGlass = TryCast(_interactivemode, ImageViewerMagnifyGlassInteractiveMode)
            End If
         Next _interactivemode

         magGlass.Start(_viewer)

         UpdateMyControls()
      End Sub

      ''' <summary>
      ''' Stop MagnifyGlass
      ''' </summary>
      Private Sub _miMagnifyGlassStop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miMagnifyGlassStop.Click
         For Each _interactivemode As ImageViewerInteractiveMode In _viewer.InteractiveModes

            If _interactivemode.Name = "MagnifyGlass" Then
               magGlass = TryCast(_interactivemode, ImageViewerMagnifyGlassInteractiveMode)
            End If
         Next _interactivemode

         magGlass.Stop(_viewer)

         UpdateMyControls()
      End Sub

      ''' <summary>
      ''' Resize the MagnifyGlass width
      ''' </summary>
      Private Sub _miMagnifyGlassResizeWidth_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miMagnifyGlassResizeWidth.Click
         Dim dlg As ValueDialog = New ValueDialog(ValueDialog.TypeConstants.Width)
         dlg.Value = _size.Width
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _size = New LeadSize(dlg.Value, _size.Height)

            UpdateMyControls()
         End If

      End Sub

      ''' <summary>
      ''' Resize the MagnifyGlass height
      ''' </summary>
      Private Sub _miMagnifyGlassResizeHeight_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miMagnifyGlassResizeHeight.Click
         Dim dlg As ValueDialog = New ValueDialog(ValueDialog.TypeConstants.Height)
         dlg.Value = _size.Height
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _size = New LeadSize(_size.Width, dlg.Value)
            UpdateMyControls()
         End If
      End Sub

      ''' <summary>
      ''' Resize the MagnifyGlass border width
      ''' </summary>
      Private Sub _miMagnifyGlassResizeBorder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miMagnifyGlassResizeBorder.Click
         Dim dlg As ValueDialog = New ValueDialog(ValueDialog.TypeConstants.Border)
         dlg.Value = _borderWidth
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _borderWidth = dlg.Value
            UpdateMyControls()
         End If
      End Sub

      ''' <summary>
      ''' Resize the MagnifyGlass Scale factor
      ''' </summary>
      Private Sub _miMagnifyGlassScaleFactor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miMagnifyGlassScaleFactor.Click
         Dim dlg As ValueDialog = New ValueDialog(ValueDialog.TypeConstants.ScaleFactor)
         dlg.Value = CInt(_scaleFactor)
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _scaleFactor = dlg.Value
            UpdateMyControls()
         End If
      End Sub

      ''' <summary>
      ''' Change the Round Rectangle Ellipse Size
      ''' </summary>
      Private Sub _miMagnifyGlassRoundRectangleEllipseSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miMagnifyGlassRoundRectangleEllipseSize.Click
         Dim dlg As RoundRectSizeDialog = New RoundRectSizeDialog(_roundRectangleEllipseSize.Width, _roundRectangleEllipseSize.Height, _size.Width, _size.Height)
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _roundRectangleEllipseSize = New LeadSize(dlg.RoundRectEllipseSize.Width, dlg.RoundRectEllipseSize.Height)
            UpdateMyControls()
         End If
      End Sub

      ''' <summary>
      ''' Resize the MagnifyGlass border color
      ''' </summary>
      Private Sub _miColorsBorderColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miColorsBorderColor.Click
         Dim dlg As ColorDialog = New ColorDialog()
         dlg.AllowFullOpen = True
         dlg.AnyColor = True
         dlg.Color = _borderColor
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _borderColor = dlg.Color
            UpdateMyControls()
         End If
      End Sub

      ''' <summary>
      ''' Resize the MagnifyGlass crosshair color
      ''' </summary>
      Private Sub _miColorsCrosshairColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miColorsCrosshairColor.Click
         Dim dlg As ColorDialog = New ColorDialog()
         dlg.AllowFullOpen = True
         dlg.AnyColor = True
         dlg.Color = _crosshairColor
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _crosshairColor = dlg.Color
            UpdateMyControls()
         End If
      End Sub

      ''' <summary>
      ''' Display or not the MagnifyGlass border as 3D
      ''' </summary>


      ''' <summary>
      ''' Change the MagnifyGlass crosshair style
      ''' </summary>
      Private Sub _miOptionsCrosshair_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miOptionsCrosshairNone.Click, _miOptionsCrosshairFine.Click
         If sender Is _miOptionsCrosshairNone Then
            _crosshair = ImageViewerSpyGlassCrosshair.None
         Else
            _crosshair = ImageViewerSpyGlassCrosshair.Fine
         End If

         UpdateMyControls()
      End Sub

      ''' <summary>
      ''' Choose the MagnifyGlass Shape
      ''' </summary>
      Private Sub _miShape_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miShapeRectangle.Click, _miShapeEllipse.Click, _miShapeRoundRectangle.Click, _miShapeNone.Click
         If sender Is _miShapeRectangle Then
            _shape = ImageViewerSpyGlassShape.Rectangle
         ElseIf sender Is _miShapeEllipse Then
            _shape = ImageViewerSpyGlassShape.Ellipse
         ElseIf sender Is _miShapeRoundRectangle Then
            _shape = ImageViewerSpyGlassShape.RoundRectangle
         ElseIf sender Is _miShapeNone Then
            _shape = ImageViewerSpyGlassShape.None
         End If

         UpdateMyControls()
      End Sub

      ''' <summary>
      ''' Show the about dialog
      ''' </summary>
      Private Sub _miAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miAbout.Click
         Using aboutDialog As New AboutDialog("MagnifyGlass", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub
   End Class
End Namespace
