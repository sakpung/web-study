' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.WinForms.CommonDialogs.File
Imports System.Drawing.Drawing2D
Imports System.IO
Imports Leadtools.Demos.Dialogs

Public Class MainForm
   Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'me call is required by the Windows Form Designer.
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
   Friend WithEvents _miFile As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileOpen As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileSave As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileSep1 As System.Windows.Forms.MenuItem
   Friend WithEvents _miFileExit As System.Windows.Forms.MenuItem
   Friend WithEvents _miZoomIn As System.Windows.Forms.MenuItem
   Friend WithEvents _miZoom As System.Windows.Forms.MenuItem
   Friend WithEvents _miZoomOut As System.Windows.Forms.MenuItem
   Friend WithEvents _miZoomSep1 As System.Windows.Forms.MenuItem
   Friend WithEvents _miZoomNormal As System.Windows.Forms.MenuItem
   Friend WithEvents _miHelp As System.Windows.Forms.MenuItem
   Friend WithEvents _miPreferences As System.Windows.Forms.MenuItem
   Friend WithEvents _miUseROI As System.Windows.Forms.MenuItem
   Friend WithEvents _miHelpAbout As System.Windows.Forms.MenuItem
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
      Me._miZoomIn = New System.Windows.Forms.MenuItem
      Me._miZoom = New System.Windows.Forms.MenuItem
      Me._miZoomOut = New System.Windows.Forms.MenuItem
      Me._miZoomSep1 = New System.Windows.Forms.MenuItem
      Me._miZoomNormal = New System.Windows.Forms.MenuItem
      Me._miFile = New System.Windows.Forms.MenuItem
      Me._miFileOpen = New System.Windows.Forms.MenuItem
      Me._miFileSave = New System.Windows.Forms.MenuItem
      Me._miFileSep1 = New System.Windows.Forms.MenuItem
      Me._miFileExit = New System.Windows.Forms.MenuItem
      Me._mmMain = New System.Windows.Forms.MainMenu(Me.components)
      Me._miHelp = New System.Windows.Forms.MenuItem
      Me._miHelpAbout = New System.Windows.Forms.MenuItem
      Me._miPreferences = New System.Windows.Forms.MenuItem
      Me._miUseROI = New System.Windows.Forms.MenuItem
      Me.SuspendLayout()
      '
      '_miZoomIn
      '
      Me._miZoomIn.Index = 0
      Me._miZoomIn.RadioCheck = True
      Me._miZoomIn.Text = "&In     (Num +)"
      '
      '_miZoom
      '
      Me._miZoom.Index = 1
      Me._miZoom.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miZoomIn, Me._miZoomOut, Me._miZoomSep1, Me._miZoomNormal})
      Me._miZoom.RadioCheck = True
      Me._miZoom.Text = "&Zoom"
      '
      '_miZoomOut
      '
      Me._miZoomOut.Index = 1
      Me._miZoomOut.RadioCheck = True
      Me._miZoomOut.Text = "&Out   (Num -)"
      '
      '_miZoomSep1
      '
      Me._miZoomSep1.Index = 2
      Me._miZoomSep1.RadioCheck = True
      Me._miZoomSep1.Text = "-"
      '
      '_miZoomNormal
      '
      Me._miZoomNormal.Index = 3
      Me._miZoomNormal.RadioCheck = True
      Me._miZoomNormal.Text = "&Normal (100%)"
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
      Me._miFileSave.Text = "&Save As..."
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
      '_mmMain
      '
      Me._mmMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miFile, Me._miZoom, Me._miPreferences, Me._miHelp})
      '
      '_miHelp
      '
      Me._miHelp.Index = 3
      Me._miHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miHelpAbout})
      Me._miHelp.Text = "&Help"
      '
      '_miHelpAbout
      '
      Me._miHelpAbout.Index = 0
      Me._miHelpAbout.Text = "&About..."
      '
      '_miPreferences
      '
      Me._miPreferences.Index = 2
      Me._miPreferences.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._miUseROI})
      Me._miPreferences.Text = "&Preferences"
      '
      '_miUseROI
      '
      Me._miUseROI.Index = 0
      Me._miUseROI.Text = "&Use ROI"
      '
      'MainForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(624, 401)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Menu = Me._mmMain
      Me.Name = "MainForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "MainForm"
      Me.ResumeLayout(False)

   End Sub

#End Region

   ' the raster image viewer
   Private _viewer As ImageViewer

   ' the raster codecs used in load/save
   Private _codecs As RasterCodecs
   Private _originalWidth As Integer
   Private _originalHeight As Integer
   Private _fileName As String
   Private _mousePath As GraphicsPath
   Private _drawRect As LeadRect
   Private _startDrawing As Boolean
   Private _myDrawPen As Pen
   Private _graph As Graphics
   Private _originPoint As LeadPoint
   Private _useROI As Boolean
   Private _openInitialPath As String = ""

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

   ' <summary>
   ' Hook the KeyPress event of the viewer
   ' </summary>
   Private Sub _viewer_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
      If Not (_viewer.Image Is Nothing) Then
         If (e.KeyChar = "+") Then
            _miZoom_Click(_miZoomIn, Nothing)
         End If
         If (e.KeyChar = "-") Then
            _miZoom_Click(_miZoomOut, Nothing)
         End If
      End If
   End Sub

   ' <summary>
   ' Initialize the application
   ' </summary>
   Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' setup our caption
      Messager.Caption = "LEADTOOLS for .NET VB JPEG 2000 Demo"
      Text = Messager.Caption

      ' initialize the _viewer object
      _viewer = New ImageViewer
      _viewer.Dock = DockStyle.Fill
      AddHandler _viewer.KeyPress, AddressOf _viewer_KeyPress
      _viewer.BackColor = Color.DarkGray
      Controls.Add(_viewer)
      _viewer.BringToFront()
      AddHandler _viewer.MouseDown, AddressOf MyMouseDown
      AddHandler _viewer.MouseUp, AddressOf MyMouseUp
      AddHandler _viewer.MouseMove, AddressOf MyMouseMove

      ' initialize the codecs object
      _codecs = New RasterCodecs

      _originalWidth = 0
      _originalHeight = 0

      LoadImage(True)
      UpdateMyControls()

      _mousePath = New System.Drawing.Drawing2D.GraphicsPath()
      _startDrawing = False
      _myDrawPen = New Pen(Color.Black, 2)
      _useROI = False
   End Sub

   ' <summary>
   ' Updates the UI depending on the program state
   ' </summary>
   Private Sub UpdateMyControls()
      ' update the menu items
      If (Not IsNothing(_viewer.Image)) Then
         _miFileSave.Enabled = True
         _miFileSave.Visible = True

         _miZoom.Enabled = True
         _miZoom.Visible = True
      Else
         _miFileSave.Enabled = False
         _miFileSave.Visible = False

         _miZoom.Enabled = False
         _miZoom.Visible = False
      End If
   End Sub

   ' <summary>
   ' Load a new image
   ' </summary>
   Private Sub _miFileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileOpen.Click
      LoadImage(False)
   End Sub

   Private Sub LoadImage(ByVal loadDefaultImage As Boolean)
      Try
         Dim loader As ImageFileLoader = New ImageFileLoader()
         Dim bLoaded As Boolean

         loader.OpenDialogInitialPath = _openInitialPath

         If loadDefaultImage Then
            bLoaded = loader.Load(Me, DemosGlobal.ImagesFolder & "\image1.j2k", _codecs, 1, 1)
         Else
            ImageFileLoader.FilterIndex = 5
            bLoaded = loader.Load(Me, _codecs, True) > 0
         End If

         If bLoaded Then
            _openInitialPath = Path.GetDirectoryName(loader.FileName)
            ' Load and set the new image in the viewer
            _viewer.Image = loader.Image

            ' Get the information about the image
            Dim imageInformation As CodecsImageInfo = _codecs.GetInformation(loader.FileName, False)
            Select Case imageInformation.Format
               Case RasterImageFormat.J2k, RasterImageFormat.Jp2, RasterImageFormat.Cmw
                  Me.Text = String.Format("LEADTOOLS for .NET VB JPEG 2000 Demo {0} X {1}", _viewer.Image.Width, _viewer.Image.Height)
                  Exit Select
               Case Else
                  Me.Text = String.Format("{0} - {1}", loader.FileName, Messager.Caption)
                  Exit Select
            End Select

            _fileName = loader.FileName

            _originalWidth = imageInformation.Width
            _originalHeight = imageInformation.Height

            _viewer.Invalidate(True)
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      Finally
         UpdateMyControls()
      End Try
   End Sub

   ' <summary>
   ' Save the image
   ' </summary>
   Private Sub _miFileSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileSave.Click
      Dim saveFormats As New RasterSaveDialogFileFormatsList(RasterDialogFileFormatDataContent.User)
      Dim saver As New ImageFileSaver

      saveFormats.Add(RasterDialogFileTypesIndex.Jpeg2000, RasterDialogBitsPerPixelDataContent.Default)
      saveFormats.Add(RasterDialogFileTypesIndex.Cmw, RasterDialogBitsPerPixelDataContent.Default)
      saveFormats.Add(RasterDialogFileTypesIndex.Jpeg, RasterDialogBitsPerPixelDataContent.Default)
      saveFormats.Add(RasterDialogFileTypesIndex.Lead, RasterDialogBitsPerPixelDataContent.Default)

      saver.SaveFormats = saveFormats
      saver.FormatIndex = RasterDialogFileTypesIndex.Jpeg2000

      Try
         If _useROI Then
            _codecs.Options.Jpeg2000.Save.RegionOfInterest = CodecsJpeg2000RegionOfInterest.UseLeadRegion
         End If

         saver.Save(Me, _codecs, _viewer.Image)
      Catch ex As Exception
         Messager.ShowFileSaveError(Me, saver.FileName, ex)
      End Try
   End Sub

   ' <summary>
   ' Shutdown
   ' </summary>
   Private Sub _miFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miFileExit.Click
      Close()
   End Sub

   ' <summary>
   ' Zoom the image
   ' </summary>
   Private Sub _miZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miZoomIn.Click, _miZoomOut.Click, _miZoomNormal.Click
      Dim scaleFactor As Double = _viewer.ScaleFactor

      If (sender Is _miZoomIn) Then
         If (_originalWidth > _viewer.Image.Width AndAlso (scaleFactor = 1)) Then
            Using codecs As RasterCodecs = New RasterCodecs
               Dim _imageInformation As CodecsImageInfo = codecs.GetInformation(_fileName, False)
               Select Case (_imageInformation.Format)
                  Case RasterImageFormat.J2k
                     codecs.Options.Jpeg2000.Load.J2kResolution = New LeadSize(_viewer.Image.Width * 2, _viewer.Image.Height * 2)
                  Case RasterImageFormat.Jp2
                     codecs.Options.Jpeg2000.Load.Jp2Resolution = New LeadSize(_viewer.Image.Width * 2, _viewer.Image.Height * 2)
                  Case RasterImageFormat.Cmw
                     codecs.Options.Jpeg2000.Load.CmwResolution = New LeadSize(_viewer.Image.Width * 2, _viewer.Image.Height * 2)
               End Select
               _viewer.Cursor = Cursors.WaitCursor
               _viewer.Image.Dispose()
               _viewer.Image = codecs.Load(_fileName)
               Me.Text = String.Format("LEADTOOLS for .NET VB JPEG 2000 Demo {0} X {1}", _viewer.Image.Width, _viewer.Image.Height)
               _viewer.Cursor = Cursors.Arrow
            End Using
         Else
            scaleFactor *= 2
         End If
      ElseIf (sender Is _miZoomOut) Then
         scaleFactor /= 2
      ElseIf (sender Is _miZoomNormal) Then
         scaleFactor = 1
         _viewer.Zoom(ControlSizeMode.None, scaleFactor, _viewer.DefaultZoomOrigin)
      End If
      If ((scaleFactor > 0.009) AndAlso (scaleFactor < 11)) Then
         _viewer.Zoom(ControlSizeMode.None, scaleFactor, _viewer.DefaultZoomOrigin)
      End If
   End Sub

   ' <summary>
   ' Show the About dialog
   ' </summary>
   Private Sub _miHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miHelpAbout.Click
      Using aboutDialog As New AboutDialog("JPEG 2000", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub

   Private Function MakeRect(ByVal originPoint As LeadPoint, ByVal endPoint As LeadPoint) As LeadRect
      Dim tmpRect As LeadRect = New LeadRect(0, 0, 0, 0)
      If (originPoint.X > endPoint.X) Then
         tmpRect.X = endPoint.X
      Else
         tmpRect.X = originPoint.X
      End If

      If (originPoint.Y > endPoint.Y) Then
         tmpRect.Y = endPoint.Y
      Else
         tmpRect.Y = originPoint.Y
      End If

      If (originPoint.X > endPoint.X) Then
         tmpRect.Width = originPoint.X - endPoint.X
      Else
         tmpRect.Width = endPoint.X - originPoint.X
      End If

      If originPoint.Y > endPoint.Y Then
         tmpRect.Height = originPoint.Y - endPoint.Y
      Else
         tmpRect.Height = endPoint.Y - originPoint.Y
      End If

      Return tmpRect
   End Function

   Private Sub MyMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
      If (_useROI) Then
         _drawRect = New LeadRect(0, 0, 0, 0)
         _drawRect.X = e.X
         _drawRect.Y = e.Y

         _drawRect.Width = 0
         _drawRect.Height = 0
         _originPoint = New LeadPoint(e.X, e.Y)

         _mousePath.Reset()
         _mousePath.AddRectangle(Leadtools.Demos.Converters.ConvertRect(_drawRect))

         ' Draw the path to the screen.
         _graph = _viewer.CreateGraphics()
         _graph.DrawPath(_myDrawPen, _mousePath)
         _startDrawing = True
      End If
   End Sub

   Private Sub MyMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
      If _useROI And _startDrawing Then
         Dim endPt As LeadPoint = New LeadPoint(e.X, e.Y)
         If e.X > _viewer.Image.Width Then
            endPt.X = _viewer.Image.Width
         End If
         If e.Y > _viewer.Image.Height Then
            endPt.Y = _viewer.Image.Height
         End If
         If e.X < 0 Then
            endPt.X = 0
         End If
         If e.Y < 0 Then
            endPt.Y = 0
         End If

         _drawRect = MakeRect(_originPoint, endPt)

         _mousePath.Reset()
         _mousePath.AddRectangle(Leadtools.Demos.Converters.ConvertRect(_drawRect))

         ' Draw the path to the screen.
         _viewer.Refresh()
         _graph.DrawPath(_myDrawPen, _mousePath)
         _graph.Dispose()

         Dim power As Double
         power = Math.Log(_viewer.ScaleFactor) / Math.Log(2.0)
         Dim numerator As Integer
         Dim denominator As Integer

         If (power > 0.0) Then
            numerator = 1
            denominator = CType(Math.Pow(2.0, power), Integer)
         Else
            numerator = CType(Math.Pow(2.0, -1 * power), Integer)
            denominator = 1
         End If

         Dim xForm As RasterRegionXForm = New RasterRegionXForm()
         xForm.ViewPerspective = RasterViewPerspective.TopLeft
         xForm.XScalarNumerator = numerator
         xForm.XScalarDenominator = denominator
         xForm.YScalarNumerator = numerator
         xForm.YScalarDenominator = denominator
         xForm.XOffset = _viewer.ScrollOffset.X
         xForm.YOffset = _viewer.ScrollOffset.Y

         If Not _viewer.Image.HasRegion Then
            _viewer.Image.AddRectangleToRegion(xForm, _drawRect, RasterRegionCombineMode.Set)
         Else
            _viewer.Image.AddRectangleToRegion(xForm, _drawRect, RasterRegionCombineMode.Or)
         End If
      End If

      _startDrawing = False
   End Sub

   Private Sub MyMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
      If _useROI And _startDrawing Then

         Dim endPt As LeadPoint = New LeadPoint(e.X, e.Y)
         If e.X > _viewer.Image.Width Then
            endPt.X = _viewer.Image.Width
         End If
         If e.Y > _viewer.Image.Height Then
            endPt.Y = _viewer.Image.Height
         End If
         If e.X < 0 Then
            endPt.X = 0
         End If
         If e.Y < 0 Then
            endPt.Y = 0
         End If

         _drawRect = MakeRect(_originPoint, endPt)

         _mousePath.Reset()
         _mousePath.AddRectangle(Leadtools.Demos.Converters.ConvertRect(_drawRect))

         ' Draw the path to the screen.
         _viewer.Refresh()
         _graph.DrawPath(_myDrawPen, _mousePath)
      End If
   End Sub

   Private Sub _miUseROI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _miUseROI.Click
      _useROI = Not _useROI
      _miUseROI.Checked = _useROI
   End Sub
End Class
