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

Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Drawing
Imports Leadtools.Controls
Imports Leadtools.Demos.Dialogs
''' <summary>
''' Summary description for MainForm.
''' </summary>
Public Class MainForm : Inherits System.Windows.Forms.Form
   Private _miFile As System.Windows.Forms.MenuItem
   Private WithEvents _miFileOpen As System.Windows.Forms.MenuItem
   Private WithEvents _miFileSave As System.Windows.Forms.MenuItem
   Private WithEvents _miFileSaveAs As System.Windows.Forms.MenuItem
   Private _miFileSep1 As System.Windows.Forms.MenuItem
   Private WithEvents _miFileExit As System.Windows.Forms.MenuItem
   Private _miHelp As System.Windows.Forms.MenuItem
   Private WithEvents _miHelpAbout As System.Windows.Forms.MenuItem
   Private WithEvents _tbMain As System.Windows.Forms.ToolBar
   Private _tbbFileSave As System.Windows.Forms.ToolBarButton
   Private _tbbSep1 As System.Windows.Forms.ToolBarButton
   Private _tbbFileOpen As System.Windows.Forms.ToolBarButton
   Private _sbMain As System.Windows.Forms.StatusBar
   Private _miView As System.Windows.Forms.MenuItem
   Private _miViewZoom As System.Windows.Forms.MenuItem
   Private WithEvents _miViewZoomIn As System.Windows.Forms.MenuItem
   Private WithEvents _miViewZoomOut As System.Windows.Forms.MenuItem
   Private _miViewSizeMode As System.Windows.Forms.MenuItem
   Private WithEvents _miViewSizeModeNormal As System.Windows.Forms.MenuItem
   Private WithEvents _miViewSizeModeFit As System.Windows.Forms.MenuItem
   Private WithEvents _miViewSizeModeFitWidth As System.Windows.Forms.MenuItem
   Private _miAction As System.Windows.Forms.MenuItem
   Private WithEvents _miActionNone As System.Windows.Forms.MenuItem
   Private WithEvents _miActionLine As System.Windows.Forms.MenuItem
   Private WithEvents _miActionRectangle As System.Windows.Forms.MenuItem
   Private WithEvents _miActionEllipse As System.Windows.Forms.MenuItem
   Private WithEvents _miActionPan As System.Windows.Forms.MenuItem
   Private WithEvents _miActionZoomToRectangle As System.Windows.Forms.MenuItem
   Private _tbbZoomNone As System.Windows.Forms.ToolBarButton
   Private _tbbZoomIn As System.Windows.Forms.ToolBarButton
   Private _tbbZoomOut As System.Windows.Forms.ToolBarButton
   Private _tbbSep2 As System.Windows.Forms.ToolBarButton
   Private _tbbActionNone As System.Windows.Forms.ToolBarButton
   Private _tbbActionPan As System.Windows.Forms.ToolBarButton
   Private _tbbActionZoomToRectangle As System.Windows.Forms.ToolBarButton
   Private _tbbActionLine As System.Windows.Forms.ToolBarButton
   Private _tbbActionRectangle As System.Windows.Forms.ToolBarButton
   Private _tbbActionEllipse As System.Windows.Forms.ToolBarButton
   Private WithEvents _miViewZoomNone As System.Windows.Forms.MenuItem
   Private _miOptions As System.Windows.Forms.MenuItem
   Private WithEvents _miOptionsPen As System.Windows.Forms.MenuItem
   Private WithEvents _miOptionsBrush As System.Windows.Forms.MenuItem
   Private _mmMain As System.Windows.Forms.MainMenu
   Private components As System.ComponentModel.IContainer = Nothing

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
      Me._miFileSaveAs = New System.Windows.Forms.MenuItem()
      Me._miFileSep1 = New System.Windows.Forms.MenuItem()
      Me._miFileExit = New System.Windows.Forms.MenuItem()
      Me._miView = New System.Windows.Forms.MenuItem()
      Me._miViewZoom = New System.Windows.Forms.MenuItem()
      Me._miViewZoomNone = New System.Windows.Forms.MenuItem()
      Me._miViewZoomIn = New System.Windows.Forms.MenuItem()
      Me._miViewZoomOut = New System.Windows.Forms.MenuItem()
      Me._miViewSizeMode = New System.Windows.Forms.MenuItem()
      Me._miViewSizeModeNormal = New System.Windows.Forms.MenuItem()
      Me._miViewSizeModeFit = New System.Windows.Forms.MenuItem()
      Me._miViewSizeModeFitWidth = New System.Windows.Forms.MenuItem()
      Me._miOptions = New System.Windows.Forms.MenuItem()
      Me._miOptionsPen = New System.Windows.Forms.MenuItem()
      Me._miOptionsBrush = New System.Windows.Forms.MenuItem()
      Me._miAction = New System.Windows.Forms.MenuItem()
      Me._miActionNone = New System.Windows.Forms.MenuItem()
      Me._miActionPan = New System.Windows.Forms.MenuItem()
      Me._miActionZoomToRectangle = New System.Windows.Forms.MenuItem()
      Me._miActionLine = New System.Windows.Forms.MenuItem()
      Me._miActionRectangle = New System.Windows.Forms.MenuItem()
      Me._miActionEllipse = New System.Windows.Forms.MenuItem()
      Me._miHelp = New System.Windows.Forms.MenuItem()
      Me._miHelpAbout = New System.Windows.Forms.MenuItem()
      Me._tbMain = New System.Windows.Forms.ToolBar()
      Me._tbbFileOpen = New System.Windows.Forms.ToolBarButton()
      Me._tbbFileSave = New System.Windows.Forms.ToolBarButton()
      Me._tbbSep1 = New System.Windows.Forms.ToolBarButton()
      Me._tbbZoomNone = New System.Windows.Forms.ToolBarButton()
      Me._tbbZoomIn = New System.Windows.Forms.ToolBarButton()
      Me._tbbZoomOut = New System.Windows.Forms.ToolBarButton()
      Me._tbbSep2 = New System.Windows.Forms.ToolBarButton()
      Me._tbbActionNone = New System.Windows.Forms.ToolBarButton()
      Me._tbbActionPan = New System.Windows.Forms.ToolBarButton()
      Me._tbbActionZoomToRectangle = New System.Windows.Forms.ToolBarButton()
      Me._tbbActionLine = New System.Windows.Forms.ToolBarButton()
      Me._tbbActionRectangle = New System.Windows.Forms.ToolBarButton()
      Me._tbbActionEllipse = New System.Windows.Forms.ToolBarButton()
      Me._sbMain = New System.Windows.Forms.StatusBar()
      Me.SuspendLayout()
      ' 
      ' _mmMain
      ' 
      Me._mmMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFile, Me._miView, Me._miOptions, Me._miAction, Me._miHelp})
      ' 
      ' _miFile
      ' 
      Me._miFile.Index = 0
      Me._miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFileOpen, Me._miFileSave, Me._miFileSaveAs, Me._miFileSep1, Me._miFileExit})
      Me._miFile.Text = "&File"
      ' 
      ' _miFileOpen
      ' 
      Me._miFileOpen.Index = 0
      Me._miFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
      Me._miFileOpen.Text = "&Open..."
      ' 
      ' _miFileSave
      ' 
      Me._miFileSave.Index = 1
      Me._miFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
      Me._miFileSave.Text = "&Save"
      ' 
      ' _miFileSaveAs
      ' 
      Me._miFileSaveAs.Index = 2
      Me._miFileSaveAs.Text = "Save &As..."
      ' 
      ' _miFileSep1
      ' 
      Me._miFileSep1.Index = 3
      Me._miFileSep1.Text = "-"
      ' 
      ' _miFileExit
      ' 
      Me._miFileExit.Index = 4
      Me._miFileExit.Text = "E&xit"
      ' 
      ' _miView
      ' 
      Me._miView.Index = 1
      Me._miView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miViewZoom, Me._miViewSizeMode})
      Me._miView.Text = "&View"
      ' 
      ' _miViewZoom
      ' 
      Me._miViewZoom.Index = 0
      Me._miViewZoom.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miViewZoomNone, Me._miViewZoomIn, Me._miViewZoomOut})
      Me._miViewZoom.Text = "&Zoom"
      ' 
      ' _miViewZoomNone
      ' 
      Me._miViewZoomNone.Index = 0
      Me._miViewZoomNone.Text = "&None (100%)"
      ' 
      ' _miViewZoomIn
      ' 
      Me._miViewZoomIn.Index = 1
      Me._miViewZoomIn.Text = "&In"
      ' 
      ' _miViewZoomOut
      ' 
      Me._miViewZoomOut.Index = 2
      Me._miViewZoomOut.Text = "&Out"
      ' 
      ' _miViewSizeMode
      ' 
      Me._miViewSizeMode.Index = 1
      Me._miViewSizeMode.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miViewSizeModeNormal, Me._miViewSizeModeFit, Me._miViewSizeModeFitWidth})
      Me._miViewSizeMode.Text = "&Size Mode"
      ' 
      ' _miViewSizeModeNormal
      ' 
      Me._miViewSizeModeNormal.Index = 0
      Me._miViewSizeModeNormal.Text = "&Normal"
      ' 
      ' _miViewSizeModeFit
      ' 
      Me._miViewSizeModeFit.Index = 1
      Me._miViewSizeModeFit.Text = "&Fit"
      ' 
      ' _miViewSizeModeFitWidth
      ' 
      Me._miViewSizeModeFitWidth.Index = 2
      Me._miViewSizeModeFitWidth.Text = "Fit &Width"
      ' 
      ' _miOptions
      ' 
      Me._miOptions.Index = 2
      Me._miOptions.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miOptionsPen, Me._miOptionsBrush})
      Me._miOptions.Text = "&Options"
      ' 
      ' _miOptionsPen
      ' 
      Me._miOptionsPen.Index = 0
      Me._miOptionsPen.Text = "&Pen..."
      ' 
      ' _miOptionsBrush
      ' 
      Me._miOptionsBrush.Index = 1
      Me._miOptionsBrush.Text = "&Brush..."
      ' 
      ' _miAction
      ' 
      Me._miAction.Index = 3
      Me._miAction.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miActionNone, Me._miActionPan, Me._miActionZoomToRectangle, Me._miActionLine, Me._miActionRectangle, Me._miActionEllipse})
      Me._miAction.Text = "&Action"
      ' 
      ' _miActionNone
      ' 
      Me._miActionNone.Index = 0
      Me._miActionNone.Text = "&None"
      ' 
      ' _miActionPan
      ' 
      Me._miActionPan.Index = 1
      Me._miActionPan.Text = "&Pan"
      ' 
      ' _miActionZoomToRectangle
      ' 
      Me._miActionZoomToRectangle.Index = 2
      Me._miActionZoomToRectangle.Text = "&Zoom to Rectangle"
      ' 
      ' _miActionLine
      ' 
      Me._miActionLine.Index = 3
      Me._miActionLine.Text = "&Line"
      ' 
      ' _miActionRectangle
      ' 
      Me._miActionRectangle.Index = 4
      Me._miActionRectangle.Text = "&Rectangle"
      ' 
      ' _miActionEllipse
      ' 
      Me._miActionEllipse.Index = 5
      Me._miActionEllipse.Text = "&Ellipse"
      ' 
      ' _miHelp
      ' 
      Me._miHelp.Index = 4
      Me._miHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miHelpAbout})
      Me._miHelp.Text = "&Help"
      ' 
      ' _miHelpAbout
      ' 
      Me._miHelpAbout.Index = 0
      Me._miHelpAbout.Text = "&About..."
      ' 
      ' _tbMain
      ' 
      Me._tbMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me._tbMain.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me._tbbFileOpen, Me._tbbFileSave, Me._tbbSep1, Me._tbbZoomNone, Me._tbbZoomIn, Me._tbbZoomOut, Me._tbbSep2, Me._tbbActionNone, Me._tbbActionPan, Me._tbbActionZoomToRectangle, Me._tbbActionLine, Me._tbbActionRectangle, Me._tbbActionEllipse})
      Me._tbMain.DropDownArrows = True
      Me._tbMain.Location = New System.Drawing.Point(0, 0)
      Me._tbMain.Name = "_tbMain"
      Me._tbMain.ShowToolTips = True
      Me._tbMain.Size = New System.Drawing.Size(713, 28)
      Me._tbMain.TabIndex = 0
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
      Me._tbbFileSave.ToolTipText = "Save"
      ' 
      ' _tbbSep1
      ' 
      Me._tbbSep1.Name = "_tbbSep1"
      Me._tbbSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      ' 
      ' _tbbZoomNone
      ' 
      Me._tbbZoomNone.ImageIndex = 2
      Me._tbbZoomNone.Name = "_tbbZoomNone"
      Me._tbbZoomNone.ToolTipText = "No Zoom (100%)"
      ' 
      ' _tbbZoomIn
      ' 
      Me._tbbZoomIn.ImageIndex = 3
      Me._tbbZoomIn.Name = "_tbbZoomIn"
      Me._tbbZoomIn.ToolTipText = "Zoom In"
      ' 
      ' _tbbZoomOut
      ' 
      Me._tbbZoomOut.ImageIndex = 4
      Me._tbbZoomOut.Name = "_tbbZoomOut"
      Me._tbbZoomOut.ToolTipText = "Zoom Out"
      ' 
      ' _tbbSep2
      ' 
      Me._tbbSep2.Name = "_tbbSep2"
      Me._tbbSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      ' 
      ' _tbbActionNone
      ' 
      Me._tbbActionNone.ImageIndex = 5
      Me._tbbActionNone.Name = "_tbbActionNone"
      Me._tbbActionNone.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me._tbbActionNone.ToolTipText = "None"
      ' 
      ' _tbbActionPan
      ' 
      Me._tbbActionPan.ImageIndex = 6
      Me._tbbActionPan.Name = "_tbbActionPan"
      Me._tbbActionPan.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me._tbbActionPan.ToolTipText = "Pan"
      ' 
      ' _tbbActionZoomToRectangle
      ' 
      Me._tbbActionZoomToRectangle.ImageIndex = 7
      Me._tbbActionZoomToRectangle.Name = "_tbbActionZoomToRectangle"
      Me._tbbActionZoomToRectangle.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me._tbbActionZoomToRectangle.ToolTipText = "Zoom To Rectangle"
      ' 
      ' _tbbActionLine
      ' 
      Me._tbbActionLine.ImageIndex = 8
      Me._tbbActionLine.Name = "_tbbActionLine"
      Me._tbbActionLine.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me._tbbActionLine.ToolTipText = "Line"
      ' 
      ' _tbbActionRectangle
      ' 
      Me._tbbActionRectangle.ImageIndex = 9
      Me._tbbActionRectangle.Name = "_tbbActionRectangle"
      Me._tbbActionRectangle.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me._tbbActionRectangle.ToolTipText = "Rectangle"
      ' 
      ' _tbbActionEllipse
      ' 
      Me._tbbActionEllipse.ImageIndex = 10
      Me._tbbActionEllipse.Name = "_tbbActionEllipse"
      Me._tbbActionEllipse.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me._tbbActionEllipse.ToolTipText = "Ellipse"
      ' 
      ' _sbMain
      ' 
      Me._sbMain.Location = New System.Drawing.Point(0, 403)
      Me._sbMain.Name = "_sbMain"
      Me._sbMain.Size = New System.Drawing.Size(713, 22)
      Me._sbMain.TabIndex = 1
      ' 
      ' MainForm
      ' 
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(713, 425)
      Me.Controls.Add(Me._sbMain)
      Me.Controls.Add(Me._tbMain)
      Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
      Me.Menu = Me._mmMain
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
      
      If Not Support.SetLicense() Then
         Return
      End If

      Application.Run(New MainForm())
   End Sub

   ''' <summary>
   ''' Actions to do in this app
   ''' </summary>
   Private Enum ActionType
      None
      Pan
      ZoomToRectangle
      Line
      Rectangle
      Ellipse
   End Enum

   ' current action
   Private _action As ActionType

   ' if image needs saving or not
   Private _isDirty As Boolean

   ' the raster codecs used in load/save
   Private _codecs As RasterCodecs

   ' save the last image file name
   Private _fileName As String

   ' origianl bits per pixel of the loaded image
   Private _originalBitsPerPixel As Integer

   ' current pen properties
   Private _penWidth As Integer
   Private _penColor As Color

   ' current brush properties
   Private _brushUse As Boolean
   Private _brushColor As Color

   ' true if we are currently tracking a line, rectangle or ellipse
   Private _tracking As Boolean

   ' holds the coordinates of the tracking line
   Private _trackingStartPoint As Point
   Private _trackingEndPoint As Point

   ' holds the coordinates of the tracking rectangle or ellipse
   Private _trackingRectangle As Rectangle

   ' The raster image viewer object.
   Private _viewer As ImageViewer

   Private _openInitialPath As String = String.Empty

   Private _noneInteractiveMode As ImageViewerNoneInteractiveMode = Nothing
   Private _panInteractiveMode As ImageViewerPanZoomInteractiveMode = Nothing
   Private _zoomToInteractiveMode As ImageViewerZoomToInteractiveMode = Nothing

   Public Property NoneInteractiveMode() As ImageViewerNoneInteractiveMode
      Get
         Return _noneInteractiveMode
      End Get
      Set(value As ImageViewerNoneInteractiveMode)
         _noneInteractiveMode = value
      End Set
   End Property

   Public Property PanInteractiveMode() As ImageViewerPanZoomInteractiveMode
      Get
         Return _panInteractiveMode
      End Get
      Set(value As ImageViewerPanZoomInteractiveMode)
         _panInteractiveMode = value
      End Set
   End Property

   Public Property ZoomToInteractiveMode() As ImageViewerZoomToInteractiveMode
      Get
         Return _zoomToInteractiveMode
      End Get
      Set(value As ImageViewerZoomToInteractiveMode)
         _zoomToInteractiveMode = value
      End Set
   End Property

   ''' <summary>
   ''' Initializes the application
   ''' </summary>
   Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs)Handles Me.Load
      ' Initialize the raster viewer object
      _viewer = New ImageViewer()
      _viewer.Dock = DockStyle.Fill
      _viewer.BackColor = Color.DarkGray
      Controls.Add(_viewer)
      _viewer.BringToFront()
      AddHandler _viewer.MouseUp, AddressOf _viewer_MouseUp
      AddHandler _viewer.MouseDown, AddressOf _viewer_MouseDown
      AddHandler _viewer.MouseMove, AddressOf _viewer_MouseMove

      _noneInteractiveMode = New ImageViewerNoneInteractiveMode()
      _panInteractiveMode = New ImageViewerPanZoomInteractiveMode()
      _zoomToInteractiveMode = New ImageViewerZoomToInteractiveMode()

      _viewer.InteractiveModes.BeginUpdate()
      _viewer.InteractiveModes.Add(_noneInteractiveMode)
      _viewer.InteractiveModes.Add(_panInteractiveMode)
      _viewer.InteractiveModes.Add(_zoomToInteractiveMode)
      _viewer.InteractiveModes.EndUpdate()

      Dim props As RasterPaintProperties = RasterPaintProperties.Default
      props.PaintDisplayMode = RasterPaintDisplayModeFlags.Bicubic
      _viewer.PaintProperties = props

      ' A bug in Visual Studio 2003 prevents the LostFocus event from showing on the
      ' control Events property page.  We need to hook into this event manually
      AddHandler _viewer.LostFocus, AddressOf _viewer_LostFocus

      ' setup the toolbar images
      Dim btmp As Bitmap = New Bitmap(Me.GetType(), "ToolBar.bmp")
      btmp.MakeTransparent(btmp.GetPixel(0, 0))
      _tbMain.ImageList = New ImageList()
      _tbMain.ImageList.ColorDepth = ColorDepth.Depth24Bit
      _tbMain.ImageList.ImageSize = New Size(btmp.Height, btmp.Height)
      _tbMain.ImageList.Images.AddStrip(btmp)

      ' setup our caption
      Messager.Caption = "LEADTOOLS for .NET VB Draw Demo"
      Text = Messager.Caption

      For Each mode As ImageViewerInteractiveMode In _viewer.InteractiveModes
         mode.IsEnabled = False
      Next mode

      ' make sure the viewer interactive mode is set to none
      _viewer.InteractiveModes.EnableById(_noneInteractiveMode.Id)

      ' start with no action
      _action = ActionType.None
      _isDirty = False

      ' setup the initial pen and brush
      _penWidth = 1
      _penColor = Color.Red
      _brushUse = False
      _brushColor = Color.White

      ' we are not tracking anything yet
      _tracking = False
      _trackingStartPoint = Point.Empty
      _trackingEndPoint = Point.Empty
      _trackingRectangle = Rectangle.Empty

      ' intitialize the codecs object
      _codecs = New RasterCodecs()

      UpdateMyControls()
      UpdateStatusBarText()
   End Sub

   ''' <summary>
   ''' Updates the UI depending on the program state
   ''' </summary>
   Private Sub UpdateMyControls()
      ' update the menus and the toolbar buttons
      If Not _viewer.Image Is Nothing Then
         _miFileSave.Visible = True
         _miFileSave.Enabled = _isDirty
         _miFileSaveAs.Visible = True
         _miFileSaveAs.Enabled = True
         _miView.Enabled = True
         _miView.Visible = True
         _miViewZoomIn.Enabled = (_viewer.SizeMode = ControlSizeMode.ActualSize)
         _miViewZoomOut.Enabled = (_viewer.SizeMode = ControlSizeMode.ActualSize)
         _miViewSizeModeNormal.Checked = (_viewer.SizeMode = ControlSizeMode.ActualSize)
         _miViewSizeModeFit.Checked = (_viewer.SizeMode = ControlSizeMode.Fit)
         _miViewSizeModeFitWidth.Checked = (_viewer.SizeMode = ControlSizeMode.FitWidth)
         _miOptions.Enabled = True
         _miOptions.Visible = True
         _miAction.Enabled = True
         _miAction.Visible = True
         _miActionNone.Checked = (_action = ActionType.None)
         _miActionPan.Checked = (_action = ActionType.Pan)
         _miActionZoomToRectangle.Checked = (_action = ActionType.ZoomToRectangle)
         _miActionLine.Checked = (_action = ActionType.Line)
         _miActionRectangle.Checked = (_action = ActionType.Rectangle)
         _miActionEllipse.Checked = (_action = ActionType.Ellipse)

         _tbbFileSave.Visible = _miFileSave.Visible
         _tbbFileSave.Enabled = _miFileSave.Enabled
         _tbbSep1.Visible = True
         _tbbZoomNone.Visible = True
         _tbbZoomNone.Enabled = (_viewer.SizeMode = ControlSizeMode.ActualSize)
         _tbbZoomIn.Visible = True
         _tbbZoomIn.Enabled = _miViewZoomIn.Enabled
         _tbbZoomOut.Visible = True
         _tbbZoomOut.Enabled = _miViewZoomOut.Enabled
         _tbbSep2.Visible = True
         _tbbActionNone.Visible = True
         _tbbActionNone.Pushed = _miActionNone.Checked
         _tbbActionPan.Visible = True
         _tbbActionPan.Pushed = _miActionPan.Checked
         _tbbActionZoomToRectangle.Visible = True
         _tbbActionZoomToRectangle.Pushed = _miActionZoomToRectangle.Checked
         _tbbActionLine.Visible = True
         _tbbActionLine.Pushed = _miActionLine.Checked
         _tbbActionRectangle.Visible = True
         _tbbActionRectangle.Pushed = _miActionRectangle.Checked
         _tbbActionEllipse.Visible = True
         _tbbActionEllipse.Pushed = _miActionEllipse.Checked
      Else
         _miFileSave.Enabled = False
         _miFileSave.Visible = False
         _miFileSaveAs.Enabled = False
         _miFileSaveAs.Visible = False
         _miView.Enabled = False
         _miView.Visible = False
         _miOptions.Enabled = False
         _miOptions.Visible = False
         _miAction.Enabled = False
         _miAction.Visible = False

         _tbbFileSave.Visible = False
         _tbbSep1.Visible = False
         _tbbZoomNone.Visible = False
         _tbbZoomIn.Visible = False
         _tbbZoomOut.Visible = False
         _tbbSep2.Visible = False
         _tbbActionNone.Visible = False
         _tbbActionPan.Visible = False
         _tbbActionZoomToRectangle.Visible = False
         _tbbActionLine.Visible = False
         _tbbActionRectangle.Visible = False
         _tbbActionEllipse.Visible = False
      End If
      _miViewZoom.Enabled = (_viewer.SizeMode = ControlSizeMode.ActualSize)

   End Sub

   ''' <summary>
   ''' Updates the status bar text depending on current action
   ''' </summary>
   Private Sub UpdateStatusBarText()
      ' update the status bar text
      Select Case _action
         Case ActionType.Pan
            _sbMain.Text = "Click and drag to pan the image inside the viewer"

         Case ActionType.ZoomToRectangle
            _sbMain.Text = "Draw the rectangle area to zoom to"

         Case ActionType.Line
            _sbMain.Text = "Draw a line on the image"

         Case ActionType.Rectangle
            _sbMain.Text = "Draw a rectangle on the image"

         Case ActionType.Ellipse
            _sbMain.Text = "Draw an ellipse on the image"

         Case Else
            _sbMain.Text = "Ready"
      End Select
   End Sub

   ''' <summary>
   ''' Check if the image is dirty, if so, offer to save it before you exit the app
   ''' </summary>
   Private Sub MainForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)Handles Me.Closing
      e.Cancel = Not CheckDirty()
   End Sub

   ''' <summary>
   ''' Checks if the image is dirty, if so, offers to save the image or cancel
   ''' </summary>
   Private Function CheckDirty() As Boolean
      Dim ret As Boolean = True

      If Not _viewer.Image Is Nothing AndAlso _isDirty Then
         Dim message As String = String.Format("The image in the {0} file has changed.{1}{1}Do you want to save the changes?", _fileName, Environment.NewLine)
         Select Case Messager.ShowQuestion(Me, message, MessageBoxIcon.Question, MessageBoxButtons.YesNoCancel)
            Case DialogResult.Yes
               ret = Save()

            Case DialogResult.Cancel
               ret = False

            Case Else
         End Select
      End If

      Return ret
   End Function

   ''' <summary>
   ''' Save to original file, return true if saved correctly
   ''' </summary>
   Private Function Save() As Boolean
      Try
         Dim fmt As RasterImageFormat = RasterImageFormat.Bmp
         If _viewer.Image.OriginalFormat <> RasterImageFormat.Unknown Then
            fmt = _viewer.Image.OriginalFormat
         End If
         Try
            _codecs.Save(_viewer.Image, _fileName, fmt, _originalBitsPerPixel)
         Catch ex As RasterException
            If ex.Code = RasterExceptionCode.BitsPerPixel Then
               _codecs.Save(_viewer.Image, _fileName, fmt, 0)
            Else
               Throw ex
            End If
         End Try

         _isDirty = False
         Return True
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         Return False
      Finally
         UpdateMyControls()
      End Try
   End Function

   ''' <summary>
   ''' Load a new image
   ''' </summary>
   Private Sub _miFileOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _miFileOpen.Click
      Try
         If CheckDirty() Then
            ' load the image
            Dim loader As ImageFileLoader = New ImageFileLoader()
            loader.OpenDialogInitialPath = _openInitialPath
            If loader.Load(Me, _codecs, True) > 0 Then
               _openInitialPath = Path.GetDirectoryName(loader.FileName)
               Dim bitsPerPixel As Integer = loader.Image.BitsPerPixel
               ' we are going to draw on the image surface, so make sure its GDI+ compatible
               RasterImageConverter.MakeCompatible(loader.Image, PixelFormat.DontCare, True)

               ' update the caption
               Text = String.Format("{0} - {1}", loader.FileName, Messager.Caption)

               ' set the new image in the viewer and save the file name
               _viewer.Image = loader.Image
               _viewer.Zoom(ControlSizeMode.ActualSize, 1, _viewer.DefaultZoomOrigin)
               _fileName = loader.FileName
               _originalBitsPerPixel = bitsPerPixel
            End If
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateMyControls()
      End Try
   End Sub

   ''' <summary>
   ''' Save to original file
   ''' </summary>
   Private Sub _miFileSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _miFileSave.Click
      Save()
   End Sub

   ''' <summary>
   ''' Save to a new file
   ''' </summary>
   Private Sub _miFileSaveAs_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _miFileSaveAs.Click
      Try
         Dim saver As ImageFileSaver = New ImageFileSaver()
         If saver.Save(Me, _codecs, _viewer.Image) Then
            ' we need to load this new image
            Dim temp As RasterImage = _codecs.Load(saver.FileName)

            ' update the caption
            Text = String.Format("{0} - {1}", saver.FileName, Messager.Caption)
            Dim scaleFactor As Double = _viewer.ScaleFactor
            Dim position As Point = _viewer.AutoScrollPosition
            _viewer.Image = temp
            _viewer.Zoom(_viewer.SizeMode, scaleFactor, _viewer.DefaultZoomOrigin)
            position.X = -position.X
            position.Y = -position.Y
            _viewer.AutoScrollPosition = position
            _fileName = saver.FileName
            _isDirty = False
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
   Private Sub _miFileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _miFileExit.Click
      Close()
   End Sub

   ''' <summary>
   ''' Handles View/Zoom menu
   ''' </summary>
   Private Sub _miViewZoom_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _miViewZoomNone.Click,_miViewZoomIn.Click,_miViewZoomOut.Click
      Dim scaleFactor As Double = _viewer.ScaleFactor

      If sender Is _miViewZoomNone Then
         scaleFactor = 1
      ElseIf sender Is _miViewZoomIn Then
         scaleFactor *= 1.2F
      ElseIf sender Is _miViewZoomOut Then
         scaleFactor /= 1.2F
      End If

      If scaleFactor > 11 Then
         scaleFactor = 11
      End If
      If scaleFactor < 0.009 Then
         scaleFactor = 0.009F
      End If

      If scaleFactor <> _viewer.ScaleFactor Then
         _viewer.Zoom(ControlSizeMode.None, scaleFactor, _viewer.DefaultZoomOrigin)
      End If
   End Sub

   ''' <summary>
   ''' Handles View/Size Mode menu
   ''' </summary>
   Private Sub _miViewSizeMode_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _miViewSizeModeNormal.Click,_miViewSizeModeFit.Click,_miViewSizeModeFitWidth.Click
      Dim sizeMode As ControlSizeMode = _viewer.SizeMode

      If sender Is _miViewSizeModeNormal Then
         sizeMode = ControlSizeMode.ActualSize
      ElseIf sender Is _miViewSizeModeFit Then
         sizeMode = ControlSizeMode.Fit
      ElseIf sender Is _miViewSizeModeFitWidth Then
         sizeMode = ControlSizeMode.FitWidth
      End If

      If Not sizeMode = _viewer.SizeMode Then
         _viewer.Zoom(sizeMode, _viewer.ScaleFactor, _viewer.DefaultZoomOrigin)
         ' in this demo, we do not want to enable zooming when scale mode is not Normal
         If _viewer.SizeMode <> ControlSizeMode.ActualSize Then
            _viewer.Zoom(_viewer.SizeMode, 1, _viewer.DefaultZoomOrigin)
         End If
         UpdateMyControls()
      End If
   End Sub

   ''' <summary>
   ''' Show the pen dialog and update current pen properties
   ''' </summary>
   Private Sub _miOptionsPen_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _miOptionsPen.Click
      Dim dlg As PenDialog = New PenDialog()
      dlg.PenWidth = _penWidth
      dlg.PenColor = _penColor
      If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
         _penWidth = dlg.PenWidth
         _penColor = dlg.PenColor
      End If
   End Sub

   ''' <summary>
   ''' Show the brush dialog and update current brush properties
   ''' </summary>
   Private Sub _miOptionsBrush_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _miOptionsBrush.Click
      Dim dlg As BrushDialog = New BrushDialog()
      dlg.BrushUse = _brushUse
      dlg.BrushColor = _brushColor
      If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
         _brushUse = dlg.BrushUse
         _brushColor = dlg.BrushColor
      End If
   End Sub

   ''' <summary>
   ''' User either clicked the action menu or the action toobar.  Setup the new action
   ''' </summary>
   Private Sub _miAction_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _miActionNone.Click,_miActionPan.Click,_miActionZoomToRectangle.Click,_miActionLine.Click,_miActionRectangle.Click,_miActionEllipse.Click
      ' get the new action
      Dim action As ActionType = _action

      If sender Is _miActionNone Then
         action = ActionType.None
      ElseIf sender Is _miActionPan Then
         action = ActionType.Pan
      ElseIf sender Is _miActionZoomToRectangle Then
         action = ActionType.ZoomToRectangle
      ElseIf sender Is _miActionLine Then
         action = ActionType.Line
      ElseIf sender Is _miActionRectangle Then
         action = ActionType.Rectangle
      ElseIf sender Is _miActionEllipse Then
         action = ActionType.Ellipse
      End If

      If action <> _action Then
         ' action has changed
         _action = action


         For Each mode As ImageViewerInteractiveMode In _viewer.InteractiveModes
            mode.IsEnabled = False
         Next mode

         ' setup the action and update the mouse cursor

         Select Case _action
            Case ActionType.Pan
               _viewer.InteractiveModes.EnableById(_panInteractiveMode.Id)
               _viewer.Cursor = Cursors.Hand

            Case ActionType.ZoomToRectangle
               _viewer.InteractiveModes.EnableById(_zoomToInteractiveMode.Id)
               _viewer.Cursor = Cursors.Cross

            Case ActionType.Line, ActionType.Rectangle, ActionType.Ellipse
               _viewer.InteractiveModes.EnableById(_noneInteractiveMode.Id)
               _viewer.Cursor = Cursors.Cross

            Case Else
               _viewer.InteractiveModes.EnableById(_noneInteractiveMode.Id)
               _viewer.Cursor = Cursors.Default
         End Select

         UpdateMyControls()
         UpdateStatusBarText()
      End If
   End Sub

   ''' <summary>
   ''' Show the about dialog
   ''' </summary>
   Private Sub _miHelpAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs)Handles _miHelpAbout.Click
      Using aboutDialog As New AboutDialog("Draw", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using

   End Sub

   ''' <summary>
   ''' Toolbar button is clicked, call the corresponding menu PerformClick method
   ''' </summary>
   Private Sub _tbMain_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs)Handles _tbMain.ButtonClick
      If e.Button Is _tbbFileOpen Then
         _miFileOpen.PerformClick()
      ElseIf e.Button Is _tbbFileSave Then
         _miFileSave.PerformClick()
      ElseIf e.Button Is _tbbZoomNone Then
         _miViewZoomNone.PerformClick()
      ElseIf e.Button Is _tbbZoomIn Then
         _miViewZoomIn.PerformClick()
      ElseIf e.Button Is _tbbZoomOut Then
         _miViewZoomOut.PerformClick()
      ElseIf e.Button Is _tbbActionNone Then
         _miActionNone.PerformClick()
      ElseIf e.Button Is _tbbActionPan Then
         _miActionPan.PerformClick()
      ElseIf e.Button Is _tbbActionZoomToRectangle Then
         _miActionZoomToRectangle.PerformClick()
      ElseIf e.Button Is _tbbActionLine Then
         _miActionLine.PerformClick()
      ElseIf e.Button Is _tbbActionRectangle Then
         _miActionRectangle.PerformClick()
      ElseIf e.Button Is _tbbActionEllipse Then
         _miActionEllipse.PerformClick()
      End If
   End Sub

   ''' <summary>
   ''' User clicks on the viewer.  Depending on the current action, we might need to start tracking a line, rectangle or an ellipse.
   ''' </summary>
   Private Sub _viewer_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
      If _tracking Then
         ' probably a right button down while we are tracking, cancel.
         EndTracking()
      Else
         ' only start tracking if the viewer has an image and the click was a left button click
         If Not _viewer.Image Is Nothing AndAlso e.Button = MouseButtons.Left Then
            Select Case _action
               Case ActionType.Line
                  ' start tracking a line
                  _trackingStartPoint = New Point(e.X, e.Y)
                  _trackingEndPoint = _trackingStartPoint
                  BeginTracking()

               Case ActionType.Rectangle, ActionType.Ellipse
                  ' start tracking a rectangle or an ellipse
                  _trackingRectangle = New Rectangle(e.X, e.Y, 0, 0)
                  BeginTracking()

               Case Else
            End Select
         End If
      End If
   End Sub

   ''' <summary>
   ''' User moves the mouse over the viewer.  Depending on the current action, we might need to update the tracking process
   ''' </summary>
   Private Sub _viewer_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
      If _tracking Then
         Select Case _action
            Case ActionType.Line
               ' update the end point of the tracking line

               ' first erase the line already on screen
               Track()

               ' update the point and draw the new tracking line
               _trackingEndPoint = New Point(e.X, e.Y)
               Track()

            Case ActionType.Rectangle, ActionType.Ellipse
               ' update the bottom-right coordinate of the tracking rectangle

               ' first erase the rectangle already on screen
               Track()

               ' update and draw the new tracking rectangle
               _trackingRectangle = Rectangle.FromLTRB(_trackingRectangle.Left, _trackingRectangle.Top, e.X, e.Y)
               Track()

            Case Else
         End Select
      End If
   End Sub

   Private Function ToMatrix(ByVal LMatrix As LeadMatrix) As Matrix
      Return New Matrix(CSng(LMatrix.M11), CSng(LMatrix.M12), CSng(LMatrix.M21), CSng(LMatrix.M22), CSng(LMatrix.OffsetX), CSng(LMatrix.OffsetY))
   End Function

   ''' <summary>
   ''' Users has released the mouse button on the viewer.  If we are tracking, we need to end it and draw a line, rectangle or an ellipse on the image
   ''' </summary>
   Private Sub _viewer_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
      If _tracking Then
         ' end the tracking
         EndTracking()

         Select Case _action
            Case ActionType.Line
               ' only draw the line if it has some length
               If _trackingStartPoint.X <> _trackingEndPoint.X OrElse _trackingStartPoint.Y <> _trackingEndPoint.Y Then
                  ' convert the tracking points to image coordinates
                  Dim t As Transformer = New Transformer(ToMatrix(_viewer.ImageTransform))
                  _trackingStartPoint = Point.Round(t.PointToLogical(_trackingStartPoint))
                  _trackingEndPoint = Point.Round(t.PointToLogical(_trackingEndPoint))
                  _trackingStartPoint = Leadtools.Demos.Converters.ConvertPoint(_viewer.Image.PointToImage(RasterViewPerspective.TopLeft, Leadtools.Demos.Converters.ConvertPoint(_trackingStartPoint)))
                  _trackingEndPoint = Leadtools.Demos.Converters.ConvertPoint(_viewer.Image.PointToImage(RasterViewPerspective.TopLeft, Leadtools.Demos.Converters.ConvertPoint(_trackingEndPoint)))

                  ' create the graphics container for the image and draw the line
                  Using container As RasterImageGdiPlusGraphicsContainer = New RasterImageGdiPlusGraphicsContainer(_viewer.Image)

                     Using pen As Pen = New Pen(_penColor, _penWidth)
                        ' use anti-alias lines
                        container.Graphics.SmoothingMode = SmoothingMode.AntiAlias
                        container.Graphics.DrawLine(pen, _trackingStartPoint, _trackingEndPoint)
                     End Using
                  End Using

                  _viewer.Invalidate()

                  _isDirty = True
                  UpdateMyControls()
               End If

            Case ActionType.Rectangle, ActionType.Ellipse
               ' only draw the rectangle/ellipse if it has some width and height
               _trackingRectangle = DemosGlobal.FixRectangle(_trackingRectangle)
               If _trackingRectangle.Width > 0 AndAlso _trackingRectangle.Height > 0 Then
                  ' convert the tracking rectangle to image coordinates
                  Dim t As Transformer = New Transformer(ToMatrix(_viewer.ImageTransform))
                  _trackingRectangle = Rectangle.Round(t.RectangleToLogical(_trackingRectangle))
                  _trackingRectangle = Leadtools.Demos.Converters.ConvertRect(_viewer.Image.RectangleToImage(RasterViewPerspective.TopLeft, Leadtools.Demos.Converters.ConvertRect(_trackingRectangle)))

                  ' create the graphics container for the image and draw the rectangle/ellipse
                  Using container As RasterImageGdiPlusGraphicsContainer = New RasterImageGdiPlusGraphicsContainer(_viewer.Image)
                     ' we are going to use a graphics path to correctly align the rectangle/ellipse edge with the interior
                     Using path As GraphicsPath = New GraphicsPath()
                        If _action = ActionType.Rectangle Then
                           path.AddRectangle(_trackingRectangle)
                        Else
                           path.AddEllipse(_trackingRectangle)
                        End If

                        ' fill this path
                        If _brushUse Then
                           Using brush As Brush = New SolidBrush(_brushColor)
                              container.Graphics.FillPath(brush, path)
                           End Using
                        End If

                        ' stroke the path
                        Using pen As Pen = New Pen(_penColor, _penWidth)
                           ' use anti-alias lines
                           container.Graphics.SmoothingMode = SmoothingMode.AntiAlias
                           container.Graphics.DrawPath(pen, path)
                        End Using
                     End Using
                  End Using

                  _viewer.Invalidate()

                  _isDirty = True
                  UpdateMyControls()
               End If
         End Select
      End If
   End Sub

   ''' <summary>
   ''' The viewer has lost the focus.  If we are tracking, end it
   ''' </summary>
   Private Sub _viewer_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
      If _tracking Then
         EndTracking()
      End If
   End Sub

   ''' <summary>
   ''' Begins the tracking process
   ''' </summary>
   Private Sub BeginTracking()
      ' first thing we need to do is set the mouse capture to the viewer
      _viewer.Capture = True

      ' limit the cursor movement inside the current image rectangle of the viewer.
      ' we first obtain the rectangle for the image, transform it to physical coordinates
      ' depending on the current transformation of in the viewer, finally we intersect this
      ' rectangle with the viewer's client rectangle for the cases where the image rectangle
      ' is bigger than the viewer's client rectangle (i.e. when the viewer has scrollbars)

      Dim imageRectangle As RectangleF = New RectangleF(PointF.Empty, New SizeF(_viewer.ImageSize.Width, _viewer.ImageSize.Height))

      ' Leadtools.Helper.Transformer class can transform a rectangle from logical to physical
      Dim t As Transformer = New Transformer(ToMatrix(_viewer.ImageTransform))
      imageRectangle = t.RectangleToPhysical(imageRectangle)

      ' intersect this rectangle with the viewer client rectangle
      Dim clip As Rectangle = Rectangle.Intersect(Rectangle.Round(imageRectangle), _viewer.ClientRectangle)

      ' setup this rectangle as our cursor clip
      Cursor.Clip = _viewer.RectangleToScreen(clip)

      ' draw the tracking object on screen
      Track()

      _tracking = True
   End Sub

   ''' <summary>
   ''' Ends the tracking process
   ''' </summary>
   Private Sub EndTracking()
      If _tracking Then
         ' we have drawn the tracking object on screen, erase it
         Track()

         ' release the capture and reset the cursor clipping rectangle
         _viewer.Capture = False
         Cursor.Clip = Rectangle.Empty

         _tracking = False
      End If
   End Sub

   ''' <summary>
   ''' Draws the current tracking shape on the screen
   ''' </summary>
   Private Sub Track()
      ' use the ControlPaint.DrawReversibleXXX, do not forget, these methods take screen coordinates

      Select Case _action
         Case ActionType.Line
            ControlPaint.DrawReversibleLine(_viewer.PointToScreen(_trackingStartPoint), _viewer.PointToScreen(_trackingEndPoint), Color.Transparent)

         Case ActionType.Ellipse, ActionType.Rectangle
            ' notice that ControlPaint does not have a method to draw a reversible ellipse.  We could
            ' draw our own ellipse by generating a series of lines and call DrawReversibleLine on them.
            ' In this demo, we simply chose to track an ellipse by its bounding rectangle
            ControlPaint.DrawReversibleFrame(_viewer.RectangleToScreen(_trackingRectangle), Color.Transparent, FrameStyle.Thick)

         Case Else
      End Select
   End Sub
End Class
