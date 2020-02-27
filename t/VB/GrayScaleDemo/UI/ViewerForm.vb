' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports GrayScaleDemo.Leadtools.Demos
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.ImageProcessing
Imports Leadtools.Dicom
Imports Leadtools.Drawing
Imports System.Threading
Imports System


Partial Public Class ViewerForm
   Inherits Form
   Private _parent As MainForm
   Public Sub New(pointer As MainForm)
      InitializeComponent()
      _parent = pointer
   End Sub

   Private _viewer As ImageViewer
   Private _codecs As RasterCodecs
   Private m_id As Integer
   Private _toolTip As ToolTip
   Public ReadOnly Property ViewerScale() As Double
      Get
         Return _viewer.ScaleFactor
      End Get
   End Property
   Public Property Id() As Integer
      Get
         Return m_id
      End Get
      Set(value As Integer)
         m_id = value
      End Set
   End Property
   Private _pressed As PressedButton
   Private _xLast As Integer
   Private _yLast As Integer
   Private _width As Integer
   Private _level As Integer
   Private _scale As Integer = 1
   Private _currentPalette As RasterColor() = Nothing
   Private _currentPalette16 As RasterColor16() = Nothing
   Private _isRegion As Boolean, _isFloater As Boolean, _isPerspective As Boolean
   Private _histogramValues As Long() = Nothing
   Private _flags As RasterPaletteWindowLevelFlags
   Private _startColor As RasterColor
   Private _startColor16 As RasterColor16
   Private _endColor As RasterColor
   Private _endColor16 As RasterColor16
   Private _maxWidth As Integer, _minWidth As Integer, _maxLevel As Integer, _minLevel As Integer
   Private _LUTSize As Integer, _LUTSize16 As Integer, _highBit As Integer, _lowBit As Integer, _maxValue As Integer, _minValue As Integer, _
    _freeHandIndex As Integer
   Private _regionType As RegionType
   Private _regionRect As LeadRect
   Private _regionStart As Point
   Private _lowerTolerance As Integer
   Private _trackingRectangle As Rectangle
   Private _actualPoints As LeadPoint()
   Private _freeHandPoints As Point()
   Private _sepType As SeparationType
   Private _imageCategory As ImageCategory
   Private _isGray As Boolean
   Public imageslist As List(Of RasterImage)
   Private _imageIndex As Integer
   Public floaterImageslist As List(Of RasterImage)
   Private _floaterImageIndex As Integer
   Private _currentPageIndex As Integer
   Private _noneInteractiveMode As ImageViewerNoneInteractiveMode
   Private _floaterInteractiveMode As ImageViewerFloaterInteractiveMode
   Private _magnifyGlassInteractiveMode As ImageViewerMagnifyGlassInteractiveMode
   Private _panInteractiveMode As ImageViewerPanZoomInteractiveMode
   Private _regionInteractiveMode As ImageViewerAddRegionInteractiveMode

   Public Property MagnifyGlassInteractiveMode() As ImageViewerMagnifyGlassInteractiveMode
      Get
         Return _magnifyGlassInteractiveMode
      End Get
      Set(value As ImageViewerMagnifyGlassInteractiveMode)
         _magnifyGlassInteractiveMode = value
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

   Public Property NoneInteractiveMode() As ImageViewerNoneInteractiveMode
      Get
         Return _noneInteractiveMode
      End Get
      Set(value As ImageViewerNoneInteractiveMode)
         _noneInteractiveMode = value
      End Set
   End Property

   Public Property FloaterInteractiveMode() As ImageViewerFloaterInteractiveMode
      Get
         Return _floaterInteractiveMode
      End Get
      Set(value As ImageViewerFloaterInteractiveMode)
         _floaterInteractiveMode = value
      End Set
   End Property

   Public Property RegionInteractiveMode() As ImageViewerAddRegionInteractiveMode
      Get
         Return _regionInteractiveMode
      End Get
      Set(value As ImageViewerAddRegionInteractiveMode)
         _regionInteractiveMode = value
      End Set
   End Property

   Public Property FloaterImageIndex() As Integer
      Get
         Return _floaterImageIndex
      End Get
      Set(value As Integer)
         _floaterImageIndex = value
      End Set
   End Property

   Private lineHistgramDlg As LineHistogramDialog
   Private _lowerToleranceLevel As Integer, _upperToleranceLevel As Integer
   Private _invertByCommand As Boolean

   Public Property InvertByCommand() As Boolean
      Get
         Return _invertByCommand
      End Get
      Set(value As Boolean)
         _invertByCommand = value
      End Set
   End Property

   Public ReadOnly Property ImageIndex() As Integer
      Get
         Return _imageIndex
      End Get
   End Property

   Public Property ImageCategory() As ImageCategory
      Get
         Return _imageCategory
      End Get
      Set(value As ImageCategory)
         _imageCategory = value
      End Set
   End Property

   Public Property SepType() As SeparationType
      Get
         Return _sepType
      End Get
      Set(value As SeparationType)
         _sepType = value
      End Set
   End Property

   Public Property RegionType() As RegionType
      Get
         Return _regionType
      End Get
      Set(value As RegionType)
         _regionType = value
      End Set
   End Property

   Public Property IsPerspective() As Boolean
      Get
         Return _isPerspective
      End Get
      Set(value As Boolean)
         _isPerspective = value
      End Set
   End Property

   Public ReadOnly Property HistogramValues() As Long()
      Get
         Return _histogramValues
      End Get
   End Property

   Public Property IsFloater() As Boolean
      Get
         Return _isFloater
      End Get
      Set(value As Boolean)
         _isFloater = value
      End Set
   End Property

   Public Property IsRegion() As Boolean
      Get
         Return _isRegion
      End Get
      Set(value As Boolean)
         _isRegion = value
      End Set
   End Property

   Public ReadOnly Property Viewer() As ImageViewer
      Get
         Return _viewer
      End Get
   End Property

   Public ReadOnly Property Image() As RasterImage
      Get
         Return _viewer.Image
      End Get
   End Property

   Public Property WindowLevelCenter() As Integer
      Get
         Return _level
      End Get
      Set(value As Integer)
         _level = value
      End Set
   End Property

   Public Property WindowLevelWidth() As Integer
      Get
         Return _width
      End Get
      Set(value As Integer)
         _width = value
      End Set
   End Property

   Private Sub RegionInteractiveMode_WorkCompleted(sender As Object, e As EventArgs)
      If _viewer.Image.GetRegionBounds(Nothing).Width > 0 Then
         _viewer.ActiveItem.ImageRegionToFloater()
         _viewer.WorkingInteractiveMode.IsEnabled = False
         _viewer.Image.MakeRegionEmpty()
         _regionType = RegionType.NONE

         FloaterInteractiveMode.IsEnabled = False
         FloaterInteractiveMode.AutoItemMode = ImageViewerAutoItemMode.AutoSetActive
         FloaterInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left
         FloaterInteractiveMode.FloaterOpacity = 0.5
         FloaterInteractiveMode.FloaterRegionRenderMode = ControlRegionRenderMode.Animated
         FloaterInteractiveMode.Item = _viewer.ActiveItem

         _viewer.InteractiveModes.EnableById(FloaterInteractiveMode.Id)
      End If

      '((MainForm)MdiParent).UpdateControls();
   End Sub


   Public Sub Initialize()
      _viewer = New ImageViewer()
      _viewer.Dock = DockStyle.Fill
      _viewer.BackColor = Color.DarkGray
      Controls.Add(_viewer)
      _viewer.BringToFront()
      _viewer.FloaterOpacity = 1
      _codecs = New RasterCodecs()

      _viewer.InteractiveModes.BeginUpdate()

      RegionInteractiveMode = New ImageViewerAddRegionInteractiveMode()
      RegionInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle
      RegionInteractiveMode.AutoRegionToFloater = True
      RegionInteractiveMode.WorkOnBounds = True
      AddHandler RegionInteractiveMode.WorkCompleted, AddressOf RegionInteractiveMode_WorkCompleted
      RegionInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left
      _viewer.InteractiveModes.Add(RegionInteractiveMode)

      'None
      NoneInteractiveMode = New ImageViewerNoneInteractiveMode()
      NoneInteractiveMode.IsEnabled = True
      _viewer.InteractiveModes.EnableById(NoneInteractiveMode.Id)
      _viewer.InteractiveModes.Add(NoneInteractiveMode)
      'Floater
      FloaterInteractiveMode = New ImageViewerFloaterInteractiveMode()
      FloaterInteractiveMode.EnablePan = True
      FloaterInteractiveMode.EnableZoom = False
      FloaterInteractiveMode.EnablePinchZoom = False
      FloaterInteractiveMode.WorkOnBounds = True
      FloaterInteractiveMode.FloaterRegionRenderMode = ControlRegionRenderMode.Animated
      _viewer.InteractiveModes.Add(FloaterInteractiveMode)

      MagnifyGlassInteractiveMode = New ImageViewerMagnifyGlassInteractiveMode()
      _viewer.InteractiveModes.Add(MagnifyGlassInteractiveMode)

      PanInteractiveMode = New ImageViewerPanZoomInteractiveMode()
      PanInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left
      _viewer.InteractiveModes.Add(PanInteractiveMode)

      _viewer.InteractiveModes.EndUpdate()

      DisableInteractiveModes(_viewer)

      _viewer.InteractiveModes.EnableById(NoneInteractiveMode.Id)

      AddHandler Me._viewer.MouseUp, AddressOf Me.Viewer_MouseUp
      AddHandler Me._viewer.MouseDown, AddressOf Me.Viewer_MouseDown
      AddHandler Me._viewer.MouseMove, AddressOf Me.Viewer_MouseMove
      AddHandler Me._viewer.MouseWheel, AddressOf Me.Viewer_MouseWheel
      AddHandler _viewer.Paint, AddressOf _viewer_Paint
      _isFloater = _isRegion = False
      _flags = RasterPaletteWindowLevelFlags.Linear Or RasterPaletteWindowLevelFlags.DicomStyle Or RasterPaletteWindowLevelFlags.Outside
      _startColor = New RasterColor(0, 0, 0)
      _startColor16 = New RasterColor16(0, 0, 0)

      _endColor = New RasterColor(RasterColor.MaximumComponent, RasterColor.MaximumComponent, RasterColor.MaximumComponent)
      _endColor16 = New RasterColor16(RasterColor16.MaximumComponent, RasterColor16.MaximumComponent, RasterColor16.MaximumComponent)

      _regionRect = New LeadRect()
      _regionStart = New Point()
      _trackingRectangle = New Rectangle()
      _toolTip = New ToolTip()
      _pressed = PressedButton.None
      imageslist = New List(Of RasterImage)()
      floaterImageslist = New List(Of RasterImage)()
   End Sub

   Public Sub DisableInteractiveModes(Viewer As ImageViewer)
      Viewer.InteractiveModes.BeginUpdate()
      For Each mode As ImageViewerInteractiveMode In Viewer.InteractiveModes
         mode.IsEnabled = False
      Next
      Viewer.InteractiveModes.EndUpdate()
   End Sub

   Public Sub Viewer_MouseDown(sender As Object, e As MouseEventArgs)
      Try
         Dim x As Integer, y As Integer
         Dim pt As LeadPoint = _viewer.ConvertPoint(Nothing, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, LeadPoint.Create(e.X, e.Y))
         x = pt.X
         y = pt.Y
         _lowerToleranceLevel = 127
         _upperToleranceLevel = 128
         Select Case e.Button
            Case MouseButtons.Right
               _pressed = PressedButton.RigthBotton
               _xLast = x
               _yLast = y
               Exit Select

            Case MouseButtons.Left
               _regionStart.X = x
               _regionStart.Y = y

               Dim rect As New Rectangle(0, 0, 0, 0)
               If _viewer.Floater IsNot Nothing AndAlso FloaterInteractiveMode.IsEnabled Then
                  Dim fPt As New Point(CInt(_viewer.FloaterTransform.OffsetX), CInt(_viewer.FloaterTransform.OffsetY))
                  Dim rt As LeadRect = _viewer.Floater.GetRegionBounds(Nothing)
                  rect = New Rectangle(rt.X + fPt.X, rt.Y + fPt.Y, rt.Width, rt.Height)

                  Dim inRegion As Boolean = False
                  Dim maxClipSegments As Integer = _viewer.Floater.CalculateRegionMaximumClipSegments()
                  Dim rgnBounds As LeadRect = _viewer.Floater.GetRegionBounds(Nothing)
                  Dim segmentBuffer As Integer() = New Integer(maxClipSegments - 1) {}

                  Dim yInFloater As Integer = y - CInt(_viewer.FloaterTransform.OffsetY)

                  _viewer.Floater.GetRegionClipSegments(yInFloater, segmentBuffer, 0)

                  Dim xInFloater As Integer = x - CInt(_viewer.FloaterTransform.OffsetX)

                  Dim i As Integer = 0
                  While i < maxClipSegments
                     If xInFloater > segmentBuffer(i) AndAlso xInFloater < segmentBuffer(i + 1) Then
                        inRegion = True
                        Exit While
                     End If
                     i = i + 2
                  End While

                  If Not inRegion Then
                     CombineFloater()
                     freeHand()
                  End If

                  _freeHandIndex = 0
               Else
                  _regionStart.X = x
                  _regionStart.Y = y
               End If
               _trackingRectangle = Rectangle.FromLTRB(0, 0, 0, 0)
               If _regionType = RegionType.FREE_HAND AndAlso _viewer.Floater Is Nothing Then
                  _freeHandPoints(System.Math.Max(System.Threading.Interlocked.Increment(_freeHandIndex), _freeHandIndex - 1)) = New Point(x, y)
               End If

               _pressed = PressedButton.LeftBotton
               cursorData(e.X, e.Y, e.X, e.Y)

               Exit Select
         End Select
      Catch generatedExceptionName As Exception
         'ex
      End Try
   End Sub

   Public Sub Viewer_MouseWheel(sender As Object, e As MouseEventArgs)
      Dim scale As Double = _viewer.ScaleFactor + -1 * e.Delta / 1200.0

      'if (scale >= .0001 && scale <= 20)
      '   _viewer.Zoom(_viewer.SizeMode, scale, _viewer.DefaultZoomOrigin);

      '_viewer.Zoom(ControlSizeMode.None, _viewer.ScaleFactor, _viewer.DefaultZoomOrigin);
      '_parent.UpdateMyControls();
   End Sub

   Private Function isInRect(pt As Point, rect As Rectangle) As Boolean
      Return (pt.X >= rect.Left AndAlso pt.X <= rect.Right AndAlso pt.Y >= rect.Top AndAlso pt.Y <= rect.Bottom)
   End Function

   Public Sub Viewer_MouseUp(sender As Object, e As MouseEventArgs)
      Try
         Select Case e.Button
            Case MouseButtons.Left
               _pressed = PressedButton.None
               Dim xform As New RasterRegionXForm()
               xform.ViewPerspective = RasterViewPerspective.TopLeft
               xform.XOffset = 0
               xform.YOffset = 0
               xform.XScalarDenominator = 1
               xform.XScalarNumerator = 1
               xform.YScalarDenominator = 1
               xform.YScalarNumerator = 1

               Dim x As Integer, y As Integer
               Dim pt As LeadPoint = _viewer.ConvertPoint(Nothing, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, LeadPoint.Create(e.X, e.Y))
               x = pt.X
               y = pt.Y

               _trackingRectangle = Rectangle.FromLTRB(0, 0, 0, 0)
               _viewer.Invalidate()
               If _viewer.Floater Is Nothing Then
                  '_viewer.Image.MakeRegionEmpty();
                  Select Case _regionType
                     Case RegionType.NONE
                        _toolTip.Hide(_viewer)
                        Return
                        'case RegionType.RECTANGLE:
                        '   if (!updateRegionRectLocation(new Point(_regionStart.X, _regionStart.Y), new Point(x, y)))
                        '      return;
                        '   _viewer.Image.AddRectangleToRegion(xform, _regionRect, RasterRegionCombineMode.Set);
                        '   break;
                        'case RegionType.ELLIPSE:
                        '   if (!updateRegionRectLocation(new Point(_regionStart.X, _regionStart.Y), new Point(x, y)))
                        '      return;
                        '   _viewer.Image.AddEllipseToRegion(xform, _regionRect, RasterRegionCombineMode.Set);
                        '   break;
                        'case RegionType.ROUND_RECTANGLE:
                        '   if (!updateRegionRectLocation(new Point(_regionStart.X, _regionStart.Y), new Point(x, y)))
                        '      return;
                        '   LeadSize sz = new LeadSize(_regionRect.Width / 4, _regionRect.Height / 4);
                        '   _viewer.Image.AddRoundRectangleToRegion(xform, _regionRect, sz, RasterRegionCombineMode.Set);
                        '   break;
                        'case RegionType.FREE_HAND:
                        '   _freeHandPoints = new Point[5000];
                        '   _freeHandIndex = 0;
                        '   _viewer.Image.AddPolygonToRegion(xform, _actualPoints, LeadFillMode.Alternate, RasterRegionCombineMode.Set);
                        '   break;
                     Case RegionType.AUTO_SEGMENT
                        If Not updateRegionRectLocation(New Point(_regionStart.X, _regionStart.Y), New Point(x, y)) Then
                           Return
                        End If
                        Dim cmd As New AutoSegmentCommand(_regionRect)
                        cmd.Run(_viewer.Image)
                        Exit Select
                     Case RegionType.FAST_MAGIC_WAND
                        Dim cmdFast As New FastMagicWandCommand()
                        If x > _viewer.Image.Width OrElse y > _viewer.Image.Height OrElse x < 0 OrElse y < 0 Then
                           Return
                        End If
                        cmdFast.X = x
                        cmdFast.Y = y

                        cmdFast.Tolerance = _lowerTolerance
                        cmdFast.SourceImage = _viewer.Image

                        cmdFast.StartEngine()
                        cmdFast.Run(_viewer.Image)
                        cmdFast.EndEngine()
                        Dim regionCombineMode As RasterRegionCombineMode = RasterRegionCombineMode.[Set]
                        For row As Integer = cmdFast.ObjectRectangle.Top To cmdFast.ObjectRectangle.Bottom - 1
                           For col As Integer = cmdFast.ObjectRectangle.Left To cmdFast.ObjectRectangle.Right - 1
                              If cmdFast.ObjectData(col - cmdFast.ObjectRectangle.Left)(row - cmdFast.ObjectRectangle.Top) = 1 Then
                                 Dim start As Integer = col
                                 While (cmdFast.ObjectData(System.Math.Max(System.Threading.Interlocked.Increment(col), col - 1) - cmdFast.ObjectRectangle.Left)(row - cmdFast.ObjectRectangle.Top) = 1) AndAlso col < cmdFast.ObjectRectangle.Right


                                 End While

                                 updateRegionRectLocation(New Point(start, row), New Point(col, row + 1))
                                 _viewer.Image.AddRectangleToRegion(xform, _regionRect, regionCombineMode)
                                 regionCombineMode = RasterRegionCombineMode.[Or]
                              End If
                           Next
                        Next
                        Exit Select
                  End Select
                  convertRegionToFloater()
                  _parent.UpdateMyControls()
               End If
               _toolTip.Hide(_viewer)
               Exit Select
            Case MouseButtons.Right
               _pressed = PressedButton.None
               Exit Select
         End Select
      Catch generatedExceptionName As Exception
         'ex
      End Try
   End Sub

   Private Function updateRegionRectLocation(startPoint As Point, endPoint As Point) As Boolean
      _regionRect.X = Math.Min(startPoint.X, endPoint.X)
      _regionRect.Y = Math.Min(startPoint.Y, endPoint.Y)
      _regionRect.Width = Math.Abs(endPoint.X - startPoint.X)
      _regionRect.Height = Math.Abs(endPoint.Y - startPoint.Y)

      If _regionRect.X + _regionRect.Width >= _viewer.Image.Width Then
         _regionRect.Width = _viewer.Image.Width - 1 - _regionRect.X
      End If
      If _regionRect.Y + _regionRect.Height >= _viewer.Image.Height Then
         _regionRect.Height = _viewer.Image.Height - 1 - _regionRect.Y
      End If
      If _regionRect.X < 0 Then
         _regionRect.Width += _regionRect.X
         _regionRect.X = 0
      End If
      If _regionRect.Y < 0 Then
         _regionRect.Height += _regionRect.Y
         _regionRect.Y = 0
      End If

      If _regionRect.Width = 0 OrElse _regionRect.Height = 0 Then
         Return False
      End If
      Return True
   End Function

   Public Sub Viewer_MouseMove(sender As Object, e As MouseEventArgs)
      Dim x As Integer, y As Integer
      Dim pt As LeadPoint = _viewer.ConvertPoint(Nothing, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, LeadPoint.Create(e.X, e.Y))
      x = pt.X
      y = pt.Y

      If _pressed = PressedButton.RigthBotton AndAlso _viewer.Floater Is Nothing Then
         If _xLast < x Then
            _width = _width + (x - _xLast) * _scale
         ElseIf _xLast > x Then
            _width = _width - (_xLast - x) * _scale
         End If

         _xLast = x

         CheckValue(_width, _maxWidth, _minWidth)

         If _yLast < y Then
            _level = _level + (y - _yLast) * _scale
         ElseIf _yLast > y Then
            _level = _level - (_yLast - y) * _scale
         End If

         _yLast = y

         CheckValue(_level, _maxLevel, _minLevel)

         If _isGray Then
            ChangeThePalette()
         End If
      End If

      If _pressed = PressedButton.LeftBotton AndAlso (_viewer.Floater Is Nothing) AndAlso _regionType <> RegionType.NONE Then
         _trackingRectangle = Rectangle.FromLTRB(_trackingRectangle.Left, _trackingRectangle.Top, e.X, e.Y)

         Select Case _regionType
            Case RegionType.ROUND_RECTANGLE, RegionType.RECTANGLE, RegionType.ELLIPSE, RegionType.AUTO_SEGMENT
               _trackingRectangle.X = Math.Min(_regionStart.X, x)
               _trackingRectangle.Y = Math.Min(_regionStart.Y, y)
               _trackingRectangle.Width = Math.Abs(x - _regionStart.X)
               _trackingRectangle.Height = Math.Abs(y - _regionStart.Y)
               Exit Select
            Case RegionType.FREE_HAND
               _freeHandPoints(System.Math.Max(System.Threading.Interlocked.Increment(_freeHandIndex), _freeHandIndex - 1)) = New Point(x, y)
               Exit Select
            Case RegionType.MAGIC_WAND, RegionType.ADD_BORDER_TO_REGION

               Dim cr As RasterColor = _viewer.Image.GetPixelColor(_regionStart.Y, _regionStart.X)
               Dim delta As Integer = CInt((y - _regionStart.Y) / 20)

               _lowerToleranceLevel = CheckColorValue(_lowerTolerance - delta)
               _upperToleranceLevel = CheckColorValue(_upperToleranceLevel + delta)

               If x < 0 OrElse x > _viewer.Image.Width - 1 OrElse y < 0 OrElse y > _viewer.Image.Height - 1 Then
                  Return
               End If
               _viewer.Image.MakeRegionEmpty()

               If _regionType = RegionType.MAGIC_WAND Then
                  _viewer.Image.AddMagicWandToRegion(x, y, New RasterColor(_lowerToleranceLevel, _lowerToleranceLevel, _lowerToleranceLevel), New RasterColor(_upperToleranceLevel, _upperToleranceLevel, _upperToleranceLevel), RasterRegionCombineMode.[Set])
               ElseIf _regionType = RegionType.ADD_BORDER_TO_REGION Then
                  _viewer.Image.AddBorderToRegion(x, y, cr, New RasterColor(_lowerToleranceLevel, _lowerToleranceLevel, _lowerToleranceLevel), New RasterColor(_upperToleranceLevel, _upperToleranceLevel, _upperToleranceLevel), RasterRegionCombineMode.[Set])
               End If

               Exit Select
         End Select
         _viewer.Invalidate()
      End If
      cursorData(x, y, e.X, e.Y)
   End Sub

   Private Function CheckColorValue(level As Integer) As Integer
      If level < 0 Then
         Return 0
      End If

      If level > 255 Then
         Return 255
      End If

      Return level
   End Function

   Private Sub ChangeThePalette()
      If _isGray = False Then
         Return
      End If

      Try
         Dim inverted As Boolean = False
         If _viewer.Image.GrayscaleMode = RasterGrayscaleMode.OrderedInverse Then
            inverted = True
         End If

         Dim low As Integer = CInt(_level - _width / 2.0)
         Dim high As Integer = CInt(_level + _width / 2.0)

         If _viewer.Image.BitsPerPixel = 8 Then
            _currentPalette = New RasterColor(_LUTSize - 1) {}

            RasterPalette.WindowLevelFillLookupTable(_currentPalette, If(inverted, _endColor, _startColor), If(inverted, _startColor, _endColor), low, high, _viewer.Image.LowBit, _
             _highBit, _minValue, _maxValue, 0, _flags)

            _viewer.Image.SetPalette(_currentPalette, 0, _currentPalette.Length)
         Else
            _currentPalette16 = New RasterColor16(_LUTSize16 - 1) {}

            RasterPalette.WindowLevelFillLookupTableExt(_currentPalette16, If(inverted, _endColor16, _startColor16), If(inverted, _startColor16, _endColor16), low, high, _viewer.Image.LowBit, _
             _highBit, _minValue, _maxValue, 0, _flags)

            _viewer.Image.WindowLevelExt(_viewer.Image.LowBit, _highBit, _currentPalette16, RasterWindowLevelMode.PaintAndProcessing)
         End If

         _lblWidth.Text = " W = " + _width.ToString()
         _lblLevel.Text = " L = " + _level.ToString()
      Catch
      End Try
   End Sub

   Public Sub UpdateAfterCommandExecution()
      Try
         Dim tmpImg As RasterImage = If((_viewer.Floater IsNot Nothing), _viewer.Floater, _viewer.Image)
         If tmpImg.GrayscaleMode <> RasterGrayscaleMode.None Then
            Select Case tmpImg.BitsPerPixel
               Case 1
                  _imageCategory = ImageCategory.OneBitImage
                  _isGray = False
                  Exit Select
               Case 8
                  _currentPalette = _viewer.Image.GetPalette()
                  _LUTSize = 256
                  _minValue = 0
                  _maxValue = 255
                  _imageCategory = ImageCategory.GrayScale_8_12_16_BPP
                  _isGray = True
                  _highBit = _viewer.Image.HighBit

                  _flags = RasterPaletteWindowLevelFlags.None
                  _flags = RasterPaletteWindowLevelFlags.Linear Or RasterPaletteWindowLevelFlags.DicomStyle Or RasterPaletteWindowLevelFlags.Outside
                  If _viewer.Image.Signed Then
                     _flags = _flags Or RasterPaletteWindowLevelFlags.Signed
                  End If
                  Exit Select
               Case 12, 16
                  _highBit = _viewer.Image.HighBit
                  If _highBit = -1 Then
                     _highBit = _viewer.Image.BitsPerPixel - 1
                  End If
                  _LUTSize = 1 << (_highBit - _viewer.Image.LowBit + 1)
                  _LUTSize16 = 1 << (_highBit - _viewer.Image.LowBit + 1)

                  _maxValue = CInt(If((_viewer.Image.Signed), ((_LUTSize + 1) / 2 - 1), (_LUTSize - 1)))
                  _minValue = CInt(If((_viewer.Image.Signed), (-(_LUTSize + 1) / 2), 0))

                  _flags = RasterPaletteWindowLevelFlags.None
                  _flags = RasterPaletteWindowLevelFlags.Linear Or RasterPaletteWindowLevelFlags.DicomStyle Or RasterPaletteWindowLevelFlags.Outside
                  If _viewer.Image.Signed Then
                     _flags = _flags Or RasterPaletteWindowLevelFlags.Signed
                  End If

                  _imageCategory = ImageCategory.GrayScale_8_12_16_BPP
                  _isGray = True
                  Exit Select
               Case Else
                  _imageCategory = ImageCategory.GrayScale_32_48_BPP
                  Exit Select
            End Select

            _scale = CInt(If(((_maxValue - _minValue) / 10000 > 0), (_maxValue - _minValue) / 10000, 1))
            _minWidth = 1
            _maxWidth = CInt(Math.Pow(2, _viewer.Image.BitsPerPixel))
            _minLevel = CInt(Math.Pow(2, _viewer.Image.BitsPerPixel)) * -1 + 1
            _maxLevel = CInt(Math.Pow(2, _viewer.Image.BitsPerPixel)) - 1

            getWindowLevel()

            _lblWidth.Text = " W = " + _width.ToString()
            _lblLevel.Text = " L = " + _level.ToString()
         Else
            _imageCategory = ImageCategory.ColoredImage
            _isGray = False
         End If

         _lblBPP.Text = " BPP = " & _viewer.Image.BitsPerPixel
         _lblImageSize.Text = _viewer.Image.Width & "X" & _viewer.Image.Height
         _lblSigned.Text = If((_viewer.Image.Signed), "Signed Image", "UnSigned Image")
      Catch generatedExceptionName As Exception
      End Try
   End Sub

   Private Sub CheckValue(ByRef value As Integer, max As Integer, min As Integer)
      If value > max Then
         value = max
      End If
      If value < min Then
         value = min
      End If
   End Sub

   Public Sub invert(useLUT As Boolean)
      Try
         Dim inv As New InvertCommand()
         If _viewer.Floater IsNot Nothing Then
            inv.Run(_viewer.Floater)
         Else
            _viewer.Image.UseLookupTable = useLUT
            inv.Run(_viewer.Image)
            _viewer.Image.UseLookupTable = True
         End If

         If _invertByCommand Then
            addToImageList()
         End If

         _invertByCommand = False
      Catch ex As Exception
         MessageBox.Show(ex.Message)
      End Try
   End Sub

   Public Sub rotate(angle As Integer)
      Dim command As New RotateCommand()
      If angle = -1 Then
         Dim dlg As New RotateDialog(_isGray)
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            If _isGray Then
               command.FillColor = New RasterColor(dlg.FillColorLevel, dlg.FillColorLevel, dlg.FillColorLevel)
            Else
               command.FillColor = Converters.FromGdiPlusColor(dlg.FillColor)
            End If
            command.Flags = dlg.Flags
            command.Angle = dlg.Angle
            If _viewer.Floater Is Nothing Then
               command.Run(_viewer.Image)
            Else
               command.Run(_viewer.Floater)
            End If


            addToImageList()
         End If
      Else
         command.Angle = angle * 100
         If _viewer.Floater Is Nothing Then
            command.Run(_viewer.Image)
         Else
            command.Run(_viewer.Floater)
         End If

         addToImageList()
      End If
   End Sub

   Public Sub flip(isHorizontal As Boolean)
      Dim cmd As New FlipCommand()
      cmd.Horizontal = isHorizontal
      If _viewer.Floater Is Nothing Then
         cmd.Run(_viewer.Image)
      Else
         cmd.Run(_viewer.Floater)
      End If

      addToImageList()
   End Sub

   Public Function GetWindowTitle(title As String) As String
      If _parent.MdiChildren.Length = 0 Then
         Return title
      End If

      For x As Integer = 0 To _parent.MdiChildren.Length - 1
         If title = _parent.MdiChildren(x).Text Then
            Return title & Convert.ToString("*")
         End If
      Next

      Return title
   End Function

   Public Sub myLoad(image As RasterImage, title As String)
      _viewer.Image = image

      _imageIndex = 0
      imageslist.Add(New RasterImage(_viewer.Image))

      Me.Width = 600
      Me.Height = 600

      If image.GrayscaleMode <> RasterGrayscaleMode.None Then
         Select Case _viewer.Image.BitsPerPixel
            Case 8
               _currentPalette = _viewer.Image.GetPalette()
               _LUTSize = 256
               _minValue = 0
               _maxValue = 255
               _isGray = True
               _LUTSize16 = 0

               _highBit = _viewer.Image.HighBit
               If _highBit = -1 Then
                  _highBit = _viewer.Image.BitsPerPixel - 1
               End If

               _lowBit = _viewer.Image.LowBit
               If _lowBit = -1 Then
                  _lowBit = _viewer.Image.BitsPerPixel - 1
               End If

               _imageCategory = ImageCategory.GrayScale_8_12_16_BPP

               _lblPaletteValue.Visible = False
               _lblWidth.Visible = False
               _lblLevel.Visible = False

               Exit Select
            Case 12, 16
               _viewer.Image.UseLookupTable = True
               _currentPalette = _viewer.Image.GetLookupTable()
               _currentPalette16 = _viewer.Image.GetLookupTable16()
               _highBit = _viewer.Image.HighBit
               If _highBit = -1 Then
                  _highBit = _viewer.Image.BitsPerPixel - 1
               End If

               _lowBit = _viewer.Image.LowBit
               If _lowBit = -1 Then
                  _lowBit = _viewer.Image.BitsPerPixel - 1
               End If

               If _currentPalette IsNot Nothing Then
                  _LUTSize = _currentPalette.Length
               Else
                  _LUTSize = CInt(Math.Pow(2, _highBit + 1))
               End If

               If _currentPalette16 IsNot Nothing Then
                  _LUTSize16 = _currentPalette16.Length
               Else
                  _LUTSize16 = CInt(Math.Pow(2, _highBit + 1))
               End If

               If _currentPalette IsNot Nothing OrElse _currentPalette16 IsNot Nothing Then
                  Dim minMaxValueCmd As New MinMaxValuesCommand()
                  minMaxValueCmd.Run(_viewer.Image)
                  _maxValue = minMaxValueCmd.MaximumValue
                  _minValue = minMaxValueCmd.MinimumValue
               Else
                  _maxValue = CInt(If((_viewer.Image.Signed), _LUTSize / 2 - 1, _LUTSize - 1))
                  _minValue = CInt(If((_viewer.Image.Signed), -_LUTSize / 2, 0))
               End If

               _imageCategory = ImageCategory.GrayScale_8_12_16_BPP
               _isGray = True
               Exit Select
            Case 1
               _imageCategory = ImageCategory.OneBitImage
               _isGray = False
               _lblPaletteValue.Visible = False
               _lblWidth.Visible = False
               _lblLevel.Visible = False
               Exit Select
         End Select
      Else
         _imageCategory = ImageCategory.ColoredImage
         _isGray = False
         _lblPaletteValue.Visible = False
         _lblWidth.Visible = False
         _lblLevel.Visible = False
      End If
      If _viewer.Image.Signed Then
         _flags = _flags Or RasterPaletteWindowLevelFlags.Signed
      End If

      _maxWidth = CInt(Math.Pow(2, _viewer.Image.BitsPerPixel)) - 1
      _minWidth = 1
      _maxLevel = CInt(Math.Pow(2, _viewer.Image.BitsPerPixel)) - 1
      _minLevel = CInt(Math.Pow(2, _viewer.Image.BitsPerPixel)) * -1 + 1
      _scale = CInt(If(((_maxValue - _minValue) / 10000 > 0), (_maxValue - _minValue) / 10000, 1))

      getWindowLevel()

      _lblBPP.Text = " BPP = " & _viewer.Image.BitsPerPixel
      _lblImageSize.Text = _viewer.Image.Width & "X" & _viewer.Image.Height
      _lblSigned.Text = If((_viewer.Image.Signed), "Signed Image", "UnSigned Image")
      Me.Text = GetWindowTitle(title)
   End Sub

   Public Sub save()
      Dim saver As New ImageFileSaver()
      Try
         saver.Save(Me, _codecs, _viewer.Image)
      Catch ex As Exception
         MessageBox.Show(ex.Message)
      End Try
   End Sub

   Public Sub CombineFloater()
      If (_viewer.FloaterOpacity = 1) AndAlso _viewer.Floater IsNot Nothing Then
         DisableInteractiveModes(_viewer)
         _viewer.InteractiveModes.EnableById(NoneInteractiveMode.Id)
         _viewer.CombineFloater(True)
         _viewer.Floater = Nothing
         addToImageList()
      End If
      floaterImageslist.Clear()
      _floaterImageIndex = 0
      UpdateAfterCommandExecution()
      _parent.UpdateMyControls()
   End Sub

   Private Sub cursorData(x As Integer, y As Integer, CurX As Integer, CurY As Integer)
      Try
         If x < _viewer.Image.Width AndAlso y < _viewer.Image.Height AndAlso _isGray AndAlso _viewer.Image.BitsPerPixel <> 12 Then
            x = If((x >= 0), x, 0)
            y = If((y >= 0), y, 0)
            Dim Data As Byte()
            Dim originalValue As Integer = 0, originalValueT As Integer = 0

            _viewer.Image.Access()
            Data = _viewer.Image.GetPixelData(y, x)
            _viewer.Image.Release()

            Select Case _viewer.Image.BitsPerPixel
               Case 16
                  Dim high As Integer = If((_viewer.Image.HighBit <> -1), _viewer.Image.HighBit, _viewer.Image.BitsPerPixel)
                  Dim signedBit As Integer = _viewer.Image.HighBit
                  Dim checkValue As Integer = CInt(Math.Pow(2, signedBit))
                  originalValue = Data(1) * 256 + Data(0)

                  If originalValue >= checkValue AndAlso _viewer.Image.Signed Then
                     originalValue = Data(1) * 256 + Data(0)
                     originalValueT = -1 * (((Convert.ToInt32(Math.Pow(2, signedBit - 7) - 1) - Data(1)) * 256 + 255 - Data(0)) + 1)
                  Else
                     originalValueT = Data(1) * 256 + Data(0)
                     originalValue = Data(1) * 256 + Data(0)
                  End If
                  Exit Select
               Case 8
                  originalValueT = Data(0)
                  originalValue = Data(0)
                  Exit Select
            End Select

            _lblRGB.Text = "RGB in the original image = " & originalValueT
            If _currentPalette IsNot Nothing Then
               _lblPaletteValue.Text = "Palette map value = " & _currentPalette(originalValue).B

            End If
         Else
            Dim tmpColor As RasterColor = _viewer.Image.GetPixelColor(y, x)
            _lblRGB.Text = String.Format("RGB = ({0},{1},{2})", tmpColor.R, tmpColor.G, tmpColor.B)
            _lblPaletteValue.Text = "Palette map value = " + " 0"
         End If

         If _pressed = PressedButton.LeftBotton AndAlso NoneInteractiveMode.IsEnabled AndAlso _regionType = RegionType.NONE AndAlso _viewer.Floater Is Nothing AndAlso Not _parent.IsSegmentation Then
            Dim tipMessage As String = String.Format("X = {1} , Y = {2} {0}{3} {0}{4}", Environment.NewLine, x, y, _lblPaletteValue.Text, _lblRGB.Text)
            _toolTip.Show(tipMessage, _viewer, CurX + 25, CurY + 25)
         End If

         _lblX.Text = " X = " & x
         _lblY.Text = " Y = " & y
      Catch
      End Try
   End Sub

   Private Sub getWindowLevel()
      If _isGray = False OrElse _viewer.Image.BitsPerPixel = 0 Then
         Return
      End If

      Try
         Dim lowValue As Integer = 0, highValue As Integer = 0
         Dim max As Integer = _maxValue
         Dim min As Integer = _minValue

         If _viewer.Image.BitsPerPixel <> 8 Then
            Dim palette As RasterColor() = _viewer.Image.GetLookupTable()
            If palette IsNot Nothing AndAlso palette.Length <> 0 Then
               Dim cmd As New GetLinearVoiLookupTableCommand()
               cmd.Run(_viewer.Image)
               highValue = CInt(cmd.Center + cmd.Width / 2)
               lowValue = CInt(cmd.Center - cmd.Width / 2)
            Else
               Dim cmd As New MinMaxValuesCommand()
               cmd.Run(_viewer.Image)
               highValue = cmd.MaximumValue
               lowValue = cmd.MinimumValue
            End If
         Else
            Dim palette As RasterColor() = _viewer.Image.GetPalette()

            If palette IsNot Nothing AndAlso palette.Length = 256 Then
               Dim value1 As Integer = palette(0).R
               Dim value2 As Integer = palette(&HFF).R
               Dim i As Integer
               Dim nFrom As Integer = 0
               Dim nTo As Integer = 255

               For i = 1 To 255
                  If palette(i).R <> value1 Then
                     nFrom = i - 1
                     Exit For
                  End If
               Next

               For i = 254 To 1 Step -1
                  If palette(i).R <> value2 Then
                     nTo = i + 1
                     Exit For
                  End If
               Next

               highValue = nTo
               lowValue = nFrom
            End If
         End If

         _width = highValue - lowValue + 1
         _level = CInt((highValue + lowValue) / 2)
         CheckValue(_width, CInt(Math.Pow(2, _viewer.Image.BitsPerPixel)), 1)
         CheckValue(_level, CInt(Math.Pow(2, _viewer.Image.BitsPerPixel)) - 1, CInt(Math.Pow(2, _viewer.Image.BitsPerPixel)) * -1 + 1)

         ChangeThePalette()
      Catch generatedExceptionName As Exception
         'ex
      End Try
   End Sub

   Public Sub histogram()
      Dim tmpImage As RasterImage = If((_viewer.Floater Is Nothing), _viewer.Image, _viewer.Floater)
      Dim dlg As New HistogramDlg(tmpImage, _isGray)
      dlg.ShowDialog()
   End Sub

   Public Sub fillCommand()
      Dim command As FillCommand
      Dim dlg As New FillDialog(_isGray, FillDialog.TypeConstants.Fill)
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         command = New FillCommand()
         If _isGray Then
            command.Color = New RasterColor(dlg.Level, dlg.Level, dlg.Level)
         Else
            command.Color = Converters.FromGdiPlusColor(dlg.FillColor)
         End If
         If _viewer.Floater Is Nothing Then
            command.Run(_viewer.Image)
         Else
            command.Run(_viewer.Floater)
         End If

         addToImageList()
      End If
   End Sub

   Public Sub fastMagicWandCommand()
      Dim dlg As New ValueDialog(ValueDialog.TypeConstants.FastMagicWand)
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         _lowerTolerance = dlg.Value
      End If
   End Sub

   Public Sub setPixelColor()
      Dim dlg As New SetPixelColorDialog(_imageCategory, _viewer.Image.BitsPerPixel)
      dlg.MaxX = _viewer.Image.Width - 1
      dlg.MaxY = _viewer.Image.Height - 1
      If _isGray Then
         dlg.MaxLevel = Convert.ToInt32(Math.Pow(2.0, _viewer.Image.BitsPerPixel) - 1)
      End If

      If dlg.ShowDialog(Me) = DialogResult.OK Then
         Dim Data As Byte() = Nothing

         _viewer.Image.GetPixelData(dlg.PtY, dlg.PtX)
         Dim binary As String = Convert.ToString(dlg.Level, 2)
         Dim green As String, blue As String, red As String
         Select Case _viewer.Image.BitsPerPixel
            Case 1
               _viewer.Image.SetPixelColor(dlg.PtY, dlg.PtX, New RasterColor(dlg.Level, dlg.Level, dlg.Level))
               Exit Select

            Case 12, 16
               Data = _viewer.Image.GetPixelData(dlg.PtY, dlg.PtX)
               binary = binary.PadLeft(16, "0"c)
               Data(1) = Byte.Parse(Convert.ToInt32(binary.Substring(0, 8), 2).ToString())
               Data(0) = Byte.Parse(Convert.ToInt32(binary.Substring(8, 8), 2).ToString())
               _viewer.Image.SetPixelData(dlg.PtY, dlg.PtX, Data)
               Exit Select
            Case 8
               Data = _viewer.Image.GetPixelData(dlg.PtY, dlg.PtX)
               binary = binary.PadLeft(8, "0"c)
               Data(0) = Byte.Parse(Convert.ToInt32(binary.Substring(0, 8), 2).ToString())
               _viewer.Image.SetPixelData(dlg.PtY, dlg.PtX, Data)
               Exit Select
            Case 24
               Data = _viewer.Image.GetPixelData(dlg.PtY, dlg.PtX)
               binary = binary.PadLeft(24, "0"c)
               Data(2) = dlg.R
               Data(1) = dlg.G
               Data(0) = dlg.B
               _viewer.Image.SetPixelData(dlg.PtY, dlg.PtX, Data)
               Exit Select
            Case 32
               Data = _viewer.Image.GetPixelData(dlg.PtY, dlg.PtX)
               binary = binary.PadLeft(32, "0"c)
               Data(3) = 0
               Data(2) = dlg.R
               Data(1) = dlg.G
               Data(0) = dlg.B
               _viewer.Image.SetPixelData(dlg.PtY, dlg.PtX, Data)
               Exit Select
            Case 46
               Data = _viewer.Image.GetPixelData(dlg.PtY, dlg.PtX)
               red = Convert.ToString(dlg.R * 255, 2)
               green = Convert.ToString(dlg.G * 255, 2)
               blue = Convert.ToString(dlg.B * 255, 2)
               red = red.PadLeft(16, "0"c)
               green = green.PadLeft(16, "0"c)
               blue = blue.PadLeft(16, "0"c)
               Data(5) = Byte.Parse(Convert.ToInt32(red.Substring(0, 8), 2).ToString())
               Data(4) = Byte.Parse(Convert.ToInt32(red.Substring(8, 8), 2).ToString())
               Data(3) = Byte.Parse(Convert.ToInt32(green.Substring(0, 8), 2).ToString())
               Data(2) = Byte.Parse(Convert.ToInt32(green.Substring(8, 8), 2).ToString())
               Data(1) = Byte.Parse(Convert.ToInt32(blue.Substring(0, 8), 2).ToString())
               Data(0) = Byte.Parse(Convert.ToInt32(blue.Substring(8, 8), 2).ToString())
               _viewer.Image.SetPixelData(dlg.PtY, dlg.PtX, Data)
               Exit Select
            Case 64
               Data = _viewer.Image.GetPixelData(dlg.PtY, dlg.PtX)
               Data(7) = 0
               Data(6) = 0
               red = Convert.ToString(dlg.R * 255, 2)
               green = Convert.ToString(dlg.G * 255, 2)
               blue = Convert.ToString(dlg.B * 255, 2)
               red = red.PadLeft(16, "0"c)
               green = green.PadLeft(16, "0"c)
               blue = blue.PadLeft(16, "0"c)
               Data(5) = Byte.Parse(Convert.ToInt32(red.Substring(0, 8), 2).ToString())
               Data(4) = Byte.Parse(Convert.ToInt32(red.Substring(8, 8), 2).ToString())
               Data(3) = Byte.Parse(Convert.ToInt32(green.Substring(0, 8), 2).ToString())
               Data(2) = Byte.Parse(Convert.ToInt32(green.Substring(8, 8), 2).ToString())
               Data(1) = Byte.Parse(Convert.ToInt32(blue.Substring(0, 8), 2).ToString())
               Data(0) = Byte.Parse(Convert.ToInt32(blue.Substring(8, 8), 2).ToString())
               _viewer.Image.SetPixelData(dlg.PtY, dlg.PtX, Data)
               Exit Select
         End Select
         If _isGray Then
            Dim cmd As New MinMaxValuesCommand()
            cmd.Run(_viewer.Image)
            _maxValue = cmd.MaximumValue
            _minValue = cmd.MinimumValue
         End If
      End If
   End Sub

   Public Sub page()
      UpdateAfterCommandExecution()
   End Sub

   Public Sub average()
      Dim dlg As New ValueDialog(ValueDialog.TypeConstants.Average)
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         Dim command As New AverageCommand(dlg.Value)
         If _viewer.Floater Is Nothing Then
            command.Run(_viewer.Image)
         Else
            command.Run(_viewer.Floater)
         End If

         addToImageList()
      End If
   End Sub

   Public Sub noiseMax()
      Dim dlg As New ValueDialog(ValueDialog.TypeConstants.Maximum)
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         Dim command As New MaximumCommand(dlg.Value)
         If _viewer.Floater Is Nothing Then
            command.Run(_viewer.Image)
         Else
            command.Run(_viewer.Floater)
         End If

         addToImageList()
      End If
   End Sub

   Public Sub noiseMin()
      Dim dlg As New ValueDialog(ValueDialog.TypeConstants.Minimum)
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         Dim command As New MinimumCommand(dlg.Value)
         If _viewer.Floater Is Nothing Then
            command.Run(_viewer.Image)
         Else
            command.Run(_viewer.Floater)
         End If

         addToImageList()
      End If
   End Sub

   Public Sub noiseMedian()
      Dim dlg As New ValueDialog(ValueDialog.TypeConstants.Median)
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         Dim command As New MedianCommand(dlg.Value)
         If _viewer.Floater Is Nothing Then
            command.Run(_viewer.Image)
         Else
            command.Run(_viewer.Floater)
         End If

         addToImageList()
      End If
   End Sub

   Public Sub sharpen()
      Dim dlg As New ValueDialog(ValueDialog.TypeConstants.Sharpen)
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         Dim command As New SharpenCommand(dlg.Value * 10)
         If _viewer.Floater Is Nothing Then
            command.Run(_viewer.Image)
         Else
            command.Run(_viewer.Floater)
         End If

         addToImageList()
      End If
   End Sub

   Public Sub unSharpen()
      Dim dlg As New UnSharpenDailog(_viewer.Image.BitsPerPixel)
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         Dim command As New UnsharpMaskCommand(dlg.Amount, dlg.Radius, dlg.Threshold, dlg.ColorSpace)
         If _viewer.Floater Is Nothing Then
            command.Run(_viewer.Image)
         Else
            command.Run(_viewer.Floater)
         End If

         addToImageList()
      End If
   End Sub

   Public Sub edgeDetection()
      Dim dlg As New EdgeDetectorDialog(_minValue, _maxValue, _isGray)
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         Dim command As New EdgeDetectorCommand(dlg.Threshold, dlg.Filter)
         If _viewer.Floater Is Nothing Then
            command.Run(_viewer.Image)
         Else
            command.Run(_viewer.Floater)
         End If

         addToImageList()
      End If
   End Sub

   Public Sub edgeContour()
      Dim dlg As New ContourDialog()
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         Dim command As New ContourFilterCommand(dlg.Threshold, dlg.DeltaDirection, dlg.MaximumError, dlg.Type)
         If _viewer.Floater Is Nothing Then
            command.Run(_viewer.Image)
         Else
            command.Run(_viewer.Floater)
         End If

         addToImageList()
      End If
   End Sub

   Public Sub gauissian()
      Dim dlg As New ValueDialog(ValueDialog.TypeConstants.Gaussian)
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         Dim command As New GaussianCommand(dlg.Value)
         If _viewer.Floater Is Nothing Then
            command.Run(_viewer.Image)
         Else
            command.Run(_viewer.Floater)
         End If


         addToImageList()
      End If
   End Sub

   Public Sub contrast()
      Dim dlg As New ValueDialog(ValueDialog.TypeConstants.Contrast)
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         Dim command As New ChangeContrastCommand(dlg.Value)
         If _viewer.Floater Is Nothing Then
            command.Run(_viewer.Image)
         Else
            command.Run(_viewer.Floater)
         End If

         addToImageList()
      End If
   End Sub

   Public Sub brightness()
      Dim dlg As New ValueDialog(ValueDialog.TypeConstants.Brightness)
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         Dim command As New ChangeIntensityCommand(dlg.Value)
         If _viewer.Floater Is Nothing Then
            command.Run(_viewer.Image)
         Else
            command.Run(_viewer.Floater)
         End If

         addToImageList()
      End If
   End Sub

   Public Sub saturation()
      Dim dlg As New ValueDialog(ValueDialog.TypeConstants.Saturation)
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         Dim command As New ChangeSaturationCommand(dlg.Value)
         If _viewer.Floater Is Nothing Then
            command.Run(_viewer.Image)
         Else
            command.Run(_viewer.Floater)
         End If

         addToImageList()
      End If
   End Sub

   Public Sub histogramEqualizer()
      Dim dlg As New EqualizerDialog()
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         Dim command As New HistogramEqualizeCommand(dlg.ColorSpace)
         If _viewer.Floater Is Nothing Then
            command.Run(_viewer.Image)
         Else
            command.Run(_viewer.Floater)
         End If

         addToImageList()
      End If
   End Sub

   Public Sub histogramAdaptiveContrast()
      Dim dlg As New AdaptiveContrastDialog()
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         Dim command As New AdaptiveContrastCommand()
         command.Amount = dlg.Amount
         command.Dimension = dlg.Dimentions
         command.Type = dlg.AdaptiveContrastType
         If _viewer.Floater Is Nothing Then
            command.Run(_viewer.Image)
         Else
            command.Run(_viewer.Floater)
         End If

         addToImageList()
      End If
   End Sub

   Public Sub histogramLocalEqualizer()
      Dim dlg As New LocalEqualizerDialog(_viewer.Image.Width, _viewer.Image.Height)
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         Dim command As New LocalHistogramEqualizeCommand()
         command.Width = dlg.nWidth
         command.Height = dlg.nHeight
         command.WidthExtension = dlg.nWidthExt
         command.HeightExtension = dlg.nHeightExt
         command.Smooth = dlg.nSmooth
         command.Type = dlg.EqualizeType
         If _viewer.Floater Is Nothing Then
            command.Run(_viewer.Image)
         Else
            command.Run(_viewer.Floater)
         End If

         addToImageList()
      End If
   End Sub

   Public Sub autoLevel()
      Dim command As New AutoColorLevelCommand()
      command.Type = AutoColorLevelCommandType.Level
      If _viewer.Floater Is Nothing Then
         command.Run(_viewer.Image)
      Else
         command.Run(_viewer.Floater)
      End If

      addToImageList()
   End Sub

   Public Sub autoContrast()
      Dim command As New AutoColorLevelCommand()
      command.Type = AutoColorLevelCommandType.Contrast
      If _viewer.Floater Is Nothing Then
         command.Run(_viewer.Image)
      Else
         command.Run(_viewer.Floater)
      End If

      addToImageList()
   End Sub

   Public Sub autoIntensity()
      Dim command As New AutoColorLevelCommand()
      command.Type = AutoColorLevelCommandType.Intensity
      If _viewer.Floater Is Nothing Then
         command.Run(_viewer.Image)
      Else
         command.Run(_viewer.Floater)
      End If

      addToImageList()
   End Sub

   Public Sub Sensitivity()
      Dim dlg As New SensitivityDialog(_scale)
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         _scale = dlg.SenValue
      End If
   End Sub

   Public Sub deskew()
      Dim dlg As New DeskewDailog(_isGray)
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         Dim command As New DeskewCommand(dlg.FillColor, dlg.Flags)
         command.Flags = DeskewCommandFlags.ReturnAngleOnly Or DeskewCommandFlags.UseNormalDetection

         If _viewer.Floater Is Nothing Then
            command.Run(_viewer.Image)
         Else
            command.Run(_viewer.Floater)
         End If

         addToImageList()
      End If
   End Sub

   Public Sub blankPageDetection()
      Dim command As New BlankPageDetectorCommand(BlankPageDetectorCommandFlags.UseAdvanced Or BlankPageDetectorCommandFlags.DetectNoisyPage Or BlankPageDetectorCommandFlags.UseBleedThrough, 0, 0, 0, 0)
      If _viewer.Floater Is Nothing Then
         command.Run(_viewer.Image)
      Else
         command.Run(_viewer.Floater)
      End If
      MessageBox.Show(" Is Blank   : " & command.IsBlank & vbLf & " Accuracy : " & (command.Accuracy * 1.0 / 100) & "%", "Blank Page Detection Results")
   End Sub

   Public Sub shear()
      Dim dlg As New ShearDialog(_isGray)
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         Dim cmd As New ShearCommand()
         cmd.Angle = dlg.Angle
         cmd.Horizontal = dlg.Horizontal
         If _isGray Then
            cmd.FillColor = New RasterColor(dlg.FillColorLevel, dlg.FillColorLevel, dlg.FillColorLevel)
         Else
            cmd.FillColor = Converters.FromGdiPlusColor(dlg.FillColor)
         End If
         If _viewer.Floater Is Nothing Then
            cmd.Run(_viewer.Image)
         Else
            cmd.Run(_viewer.Floater)
         End If

         addToImageList()
      End If
   End Sub

   Public Sub autoBinarize()
      Dim command As New AutoBinarizeCommand()
      If _viewer.Floater Is Nothing Then
         command.Run(_viewer.Image)
      Else
         command.Run(_viewer.Floater)
      End If

      addToImageList()
   End Sub

   Public Sub intensityDetect()
      Dim dlg As New IntensityDetectDailog(_isGray)
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         Dim command As New IntensityDetectCommand(dlg.Low, dlg.High, dlg.InColor, dlg.OutColor, dlg.Channel)
         _currentPalette = _viewer.Image.GetPalette()
         If _viewer.Floater Is Nothing Then
            command.Run(_viewer.Image)
         Else
            command.Run(_viewer.Floater)
         End If

         addToImageList()
         _currentPalette = _viewer.Image.GetPalette()
      End If
   End Sub

   Public Sub KMeans()
      Dim dlg As New KMeansDialog()
      If dlg.ShowDialog() = DialogResult.OK Then
         Dim command As New KMeansCommand(dlg.Clusters, dlg.Type, Nothing)
         command.Run(_viewer.Image)
         addToImageList()
      End If
   End Sub

   Public Sub Otsu(mainPt As MainForm)
      Dim dlg As New OtsuThresholdDialog(mainPt)
      If dlg.ShowDialog() = DialogResult.OK Then
         Dim command As New OtsuThresholdCommand(dlg.Clusters)
         command.Run(_viewer.Image)
      End If
   End Sub

   Public Sub Lambda()
      Dim dlg As New LambdaConnectednessDialog()
      If dlg.ShowDialog() = DialogResult.OK Then
         Dim command As New LambdaConnectednessCommand(dlg.Lambda)
         command.Run(_viewer.Image)
         addToImageList()
      End If
   End Sub

   Public Sub LevelSet()
      Dim command As New LevelsetCommand()
      command.Run(_viewer.Image)

      _viewer.ActiveItem.ImageRegionToFloater()
      _viewer.Image.SetRegion(Nothing, Nothing, RasterRegionCombineMode.[Set])
      DisableInteractiveModes(_viewer)
      _viewer.InteractiveModes.EnableById(FloaterInteractiveMode.Id)

      _viewer.FloaterOpacity = 1
   End Sub

   Public Sub ShrinkTool()

   End Sub

   Public Sub TDAFilter()
      Dim dlg As New TDAFilterDialog()
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         Dim command As New TADAnisotropicDiffusionCommand(dlg.Iterations, dlg.Lambda, dlg.Kappa, dlg.Flux)
         command.Run(_viewer.Image)
         addToImageList()
      End If
   End Sub

   Public Sub SRADFilter()
      Dim dlg As New SRADFilterDialog()
      If dlg.ShowDialog() = DialogResult.OK Then
         Dim command As New SRADAnisotropicDiffusionCommand(dlg.Iterations, dlg.Lambda, New LeadRect(10, 10, _viewer.Image.Width - 20, _viewer.Image.Height - 20))
         command.Run(_viewer.Image)
         addToImageList()
      End If
   End Sub

   Public Sub AutoCrop()
      Dim dlg As New ValueDialog(ValueDialog.TypeConstants.AutoCrop)
      If dlg.ShowDialog() = DialogResult.OK Then
         Dim cmd As New AutoCropCommand(dlg.Value)
         If _viewer.Floater Is Nothing Then
            cmd.Run(_viewer.Image)
         Else
            cmd.Run(_viewer.Floater)
         End If

         addToImageList()
      End If
   End Sub

   Public Sub Despeckle()
      Dim command As New DespeckleCommand()
      If _viewer.Floater Is Nothing Then
         command.Run(_viewer.Image)
      Else
         command.Run(_viewer.Floater)
      End If

      addToImageList()
   End Sub

   Public Sub Dilate()
      Dim command As New BinaryFilterCommand(BinaryFilterCommandPredefined.DilationOmniDirectional)
      If _viewer.Floater Is Nothing Then
         command.Run(_viewer.Image)
      Else
         command.Run(_viewer.Floater)
      End If

      addToImageList()
   End Sub

   Public Sub Erode()
      Dim command As New BinaryFilterCommand(BinaryFilterCommandPredefined.ErosionOmniDirectional)
      If _viewer.Floater Is Nothing Then
         command.Run(_viewer.Image)
      Else
         command.Run(_viewer.Floater)
      End If

      addToImageList()
   End Sub

   Public Sub UnditherText()
      Dim cmdMedian As New MedianCommand(3)
      Dim cmdMin As New MinimumCommand(2)
      If _viewer.Floater Is Nothing Then
         cmdMedian.Run(_viewer.Image)
         cmdMin.Run(_viewer.Image)
      Else
         cmdMedian.Run(_viewer.Floater)
         cmdMin.Run(_viewer.Floater)
      End If

      addToImageList()
   End Sub

   Public Sub FixBrokenLetters()
      Dim cmdMin As New MinimumCommand(2)
      If _viewer.Floater Is Nothing Then
         cmdMin.Run(_viewer.Image)
      Else
         cmdMin.Run(_viewer.Floater)
      End If

      addToImageList()
   End Sub

   Public Sub LineRemove()
      Dim horizontalRemoveCommand As New LineRemoveCommand()
      horizontalRemoveCommand.Type = LineRemoveCommandType.Horizontal

      Dim verticalRemoveCommand As New LineRemoveCommand()
      verticalRemoveCommand.Type = LineRemoveCommandType.Vertical

      If _viewer.Floater Is Nothing Then
         horizontalRemoveCommand.Run(_viewer.Image)
         verticalRemoveCommand.Run(_viewer.Image)
      Else
         horizontalRemoveCommand.Run(_viewer.Floater)
         verticalRemoveCommand.Run(_viewer.Floater)
      End If

      addToImageList()
   End Sub

   Public Sub invPerspective(mainPt As MainForm)
      Dim dlg As New PerspectiveDialog(mainPt, Me)
      dlg.TopMost = True
      dlg.Show()
      AddHandler dlg.FormClosed, AddressOf dlg_FormClosed
   End Sub

   Public Sub BackgroundRemoval(mainPt As MainForm)
      Dim dlg As New BackgroundRemovalDialog(mainPt, Me, False)
      If dlg.ShowDialog() = DialogResult.OK Then
         addToImageList()
      End If
   End Sub

   Public Sub shrinkTool(mainPt As MainForm)
      Dim dlg As New ShrinkWrapDialog(mainPt, Me)
      dlg.TopMost = True
      dlg.Show()
   End Sub

   Private Sub dlg_FormClosed(sender As Object, e As FormClosedEventArgs)
      addToImageList()
   End Sub

   Public Sub gWireTool(mainPt As MainForm)
      Dim dlg As New GWireDialog(Me, mainPt)
      dlg.TopMost = True
      dlg.Show()

   End Sub

   Public Sub AnisotropicDiffusion()
      Dim dlg As New AnisotropicDiffusionDialog()
      If dlg.ShowDialog() = DialogResult.OK Then
         Using wait As New WaitCursor()
            Dim cmd As New AnisotropicDiffusionCommand()
            cmd.Iterations = dlg.Iterations
            ' 20
            cmd.Smoothing = dlg.Smoothing
            ' 1
            cmd.TimeStep = dlg.TimeStep
            ' 40.0
            cmd.MaxVariation = dlg.MaxVariation
            ' 90.0
            cmd.MinVariation = dlg.MinVariation
            '50.0
            cmd.Update = dlg.nUpdate
            ' 10
            cmd.EdgeHeight = dlg.EdgeHeight
            ' 5.0
            If _viewer.Floater Is Nothing Then
               cmd.Run(_viewer.Image)
            Else
               cmd.Run(_viewer.Floater)
            End If

            addToImageList()
         End Using
      End If
   End Sub

   Public Sub DigitalSubtract()
      Dim images As New List(Of ViewerImages)()

      For i As Integer = 0 To Me.MdiParent.MdiChildren.Length - 1
         'images.Add(new ViewerImages(Path.GetFileNameWithoutExtension(this.MdiParent.MdiChildren[i].Text),
         images.Add(New ViewerImages(Me.MdiParent.MdiChildren(i).Text, CType(Me.MdiParent.MdiChildren(i), ViewerForm).Id, CType(Me.MdiParent.MdiChildren(i), ViewerForm).Image))
      Next

      Dim dlg As New DigitalSubtractDialog(images, _viewer.Image)
      If dlg.ShowDialog() = DialogResult.OK Then
         If CType(Me.MdiParent.MdiChildren(dlg.ImageID), ViewerForm).Viewer.Floater IsNot Nothing Then
            CType(Me.MdiParent.MdiChildren(dlg.ImageID), ViewerForm).Viewer.CombineFloater(True)
            CType(Me.MdiParent.MdiChildren(dlg.ImageID), ViewerForm).Viewer.Floater = Nothing
            DisableInteractiveModes(_viewer)
            CType(Me.MdiParent.MdiChildren(dlg.ImageID), ViewerForm).Viewer.InteractiveModes.EnableById(NoneInteractiveMode.Id)
         End If

         Dim cmd As New DigitalSubtractCommand()
         cmd.MaskImage = CType(Me.MdiParent.MdiChildren(dlg.ImageID), ViewerForm).Viewer.Image
         cmd.Flags = dlg.Flags

         If _viewer.Floater IsNot Nothing Then
            CombineFloater()
         End If

         cmd.Run(_viewer.Image)

         addToImageList()
      End If
   End Sub

   Public Sub MeanShift()
      Dim dlg As New MeanShiftDialog()
      If dlg.ShowDialog() = DialogResult.OK Then
         Using wait As New WaitCursor()
            Dim cmd As New MeanShiftCommand()
            cmd.Radius = dlg.Radius
            cmd.ColorDistance = dlg.ColorDistance

            If _viewer.Floater Is Nothing Then
               cmd.Run(_viewer.Image)
            Else
               cmd.Run(_viewer.Floater)
            End If

            addToImageList()
         End Using
      End If
   End Sub

   Public Sub MultiscaleEnhancement(mainPt As MainForm)
      Dim dlg As New MultiscaleEnhancementDialog(mainPt, Me)
      If dlg.ShowDialog() = DialogResult.OK Then
         addToImageList()
      End If
   End Sub

   Public Sub SelectData()
      Dim dlg As New SelectDataDialog()
      If dlg.ShowDialog() = DialogResult.OK Then
         Dim cmd As New SelectDataCommand()
         cmd.Threshold = dlg.Threshold
         cmd.Color = Converters.FromGdiPlusColor(dlg.dlgColor)
         cmd.Combine = dlg.Combine
         cmd.SourceHighBit = dlg.SourceHighBit
         cmd.SourceLowBit = dlg.SourceLowBit

         cmd.Run(_viewer.Image)
         _viewer.Image.ReplacePage(_viewer.Image.Page, cmd.DestinationImage)

         addToImageList()
      End If
   End Sub

   Public Sub ShiftData()
      Dim dlg As New ShiftDataDialog(_viewer.Image.BitsPerPixel, _viewer.Image.Signed)
      If dlg.ShowDialog() = DialogResult.OK Then
         Dim cmd As New ShiftDataCommand()
         cmd.SourceHighBit = dlg.SourceHighBit
         cmd.SourceLowBit = dlg.SourceLowBit
         cmd.DestinationBitsPerPixel = dlg.DestinationBitsPerPixel
         cmd.DestinationLowBit = dlg.DestinationLowBit

         cmd.Run(_viewer.Image)
         _viewer.Image.ReplacePage(_viewer.Image.Page, cmd.DestinationImage)

         addToImageList()
      End If
   End Sub

   Public Sub Sigma()
      Dim dlg As New SigmaDialog()
      If dlg.ShowDialog() = DialogResult.OK Then
         Dim cmd As New SigmaCommand()
         cmd.Dimension = dlg.Dimension
         cmd.Outline = dlg.Outline
         cmd.Sigma = dlg.Sigma
         cmd.Threshold = dlg.Threshold

         _viewer.Image.MakeRegionEmpty()
         If _viewer.Floater Is Nothing Then
            cmd.Run(_viewer.Image)
         Else
            cmd.Run(_viewer.Floater)
         End If
         addToImageList()
      End If
   End Sub

   Public Sub TissueEqualize()
      Dim dlg As New TissueEqualizeDialog()
      If dlg.ShowDialog() = DialogResult.OK Then
         Dim cmd As New TissueEqualizeCommand(dlg.Flags)
         If _viewer.Floater Is Nothing Then
            cmd.Run(_viewer.Image)
         Else
            cmd.Run(_viewer.Floater)
         End If

         addToImageList()
      End If
   End Sub

   Public Sub Skeleton()
      Dim cmd As New SkeletonCommand()
      Dim maxThreshold As Integer
      Dim cmdMinMax As New MinMaxValuesCommand()



      If _isGray Then
         cmdMinMax.Run(_viewer.Image)
         maxThreshold = cmdMinMax.MaximumValue
      Else
         maxThreshold = 255
      End If

      Dim dlg As New SkeletonDialog(maxThreshold)
      If dlg.ShowDialog() = DialogResult.OK Then
         cmd.Threshold = dlg.Threshold
         If _viewer.Floater Is Nothing Then
            cmd.Run(_viewer.Image)
         Else
            cmd.Run(_viewer.Floater)
         End If

         UpdateAfterCommandExecution()
         ChangeThePalette()
         addToImageList()
      End If
   End Sub

   Private Sub convertRegionToFloater()
      _viewer.ActiveItem.ImageRegionToFloater()
      _viewer.FloaterOpacity = 1
      DisableInteractiveModes(_viewer)
      _viewer.InteractiveModes.EnableById(FloaterInteractiveMode.Id)
      _viewer.Image.MakeRegionEmpty()
      floaterImageslist.Add(New RasterImage(_viewer.Floater))
      _floaterImageIndex = 0
   End Sub

   Public Sub WLManually()
      Dim dlg As New WindowLevelDialog(_level, _width, _minWidth, _maxWidth, _minLevel, _maxLevel)
      If dlg.ShowDialog() = DialogResult.OK Then
         _width = dlg.WL_Width
         _level = dlg.WL_Level
         ChangeThePalette()
         _lblWidth.Text = " W = " + _width.ToString()
         _lblLevel.Text = " L = " + _level.ToString()
      End If
   End Sub

   Public Sub _viewer_Paint(sender As Object, e As PaintEventArgs)
      Dim trackingRectangle As LeadRect = _viewer.ConvertRect(Nothing, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, LeadRect.Create(_trackingRectangle.X, _trackingRectangle.Y, _trackingRectangle.Width, _trackingRectangle.Height))
      _trackingRectangle = New Rectangle(trackingRectangle.X, trackingRectangle.Y, trackingRectangle.Width, trackingRectangle.Height)
      Dim dashValuesWhite As Single() = {4, 4, 4, 4}
      Dim penBlack As New Pen(Color.Black, 1)
      Dim penWhite As New Pen(Color.White, 1)
      penWhite.DashPattern = dashValuesWhite
      Select Case _regionType
         Case RegionType.RECTANGLE, RegionType.AUTO_SEGMENT
            e.Graphics.DrawRectangle(penBlack, _trackingRectangle)
            e.Graphics.DrawRectangle(penWhite, _trackingRectangle)
            Exit Select
         Case RegionType.ELLIPSE
            e.Graphics.DrawEllipse(penBlack, _trackingRectangle)
            e.Graphics.DrawEllipse(penWhite, _trackingRectangle)
            Exit Select
         Case RegionType.ROUND_RECTANGLE
            drawRoundRect(e, penBlack, penWhite)
            Exit Select
         Case RegionType.FREE_HAND
            If _freeHandIndex <= 1 OrElse _viewer.Floater IsNot Nothing Then
               Return
            End If
            Dim drawPoints As Point() = New Point(_freeHandIndex - 1) {}
            _actualPoints = New LeadPoint(_freeHandIndex - 1) {}
            For i As Integer = 0 To _actualPoints.Length - 1
               Dim leadPoint As LeadPoint = _viewer.ConvertPoint(Nothing, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, New LeadPoint(_freeHandPoints(i).X, _freeHandPoints(i).Y))
               drawPoints(i) = New Point(leadPoint.X, leadPoint.Y)
               _actualPoints(i).X = _freeHandPoints(i).X
               _actualPoints(i).Y = _freeHandPoints(i).Y
            Next
            e.Graphics.DrawLines(penBlack, drawPoints)
            e.Graphics.DrawLines(penWhite, drawPoints)
            Exit Select
      End Select
   End Sub

   Private Sub drawRoundRect(e As PaintEventArgs, penBlack As Pen, penWhite As Pen)
      Dim left As Integer = _trackingRectangle.Left
      Dim right As Integer = _trackingRectangle.Right
      Dim top As Integer = _trackingRectangle.Top
      Dim bottom As Integer = _trackingRectangle.Bottom
      Dim width As Integer = _trackingRectangle.Width
      Dim height As Integer = _trackingRectangle.Height
      e.Graphics.DrawLine(penBlack, New Point(left + Convert.ToInt32(0.125 * width), top), New Point(right - Convert.ToInt32(0.125 * width), top))
      e.Graphics.DrawLine(penBlack, New Point(left + Convert.ToInt32(0.125 * width), bottom), New Point(right - Convert.ToInt32(0.125 * width), bottom))
      e.Graphics.DrawLine(penBlack, New Point(left, top + Convert.ToInt32(0.125 * height)), New Point(left, bottom - Convert.ToInt32(0.125 * height)))
      e.Graphics.DrawLine(penBlack, New Point(right, top + Convert.ToInt32(0.125 * height)), New Point(right, bottom - Convert.ToInt32(0.125 * height)))
      e.Graphics.DrawLine(penWhite, New Point(left + Convert.ToInt32(0.125 * width), top), New Point(right - Convert.ToInt32(0.125 * width), top))
      e.Graphics.DrawLine(penWhite, New Point(left + Convert.ToInt32(0.125 * width), bottom), New Point(right - Convert.ToInt32(0.125 * width), bottom))
      e.Graphics.DrawLine(penWhite, New Point(left, top + Convert.ToInt32(0.125 * height)), New Point(left, bottom - Convert.ToInt32(0.125 * height)))
      e.Graphics.DrawLine(penWhite, New Point(right, top + Convert.ToInt32(0.125 * height)), New Point(right, bottom - Convert.ToInt32(0.125 * height)))
      Dim rect As New Rectangle(left, top, If(Convert.ToInt32(width * 0.25) = 0, 1, Convert.ToInt32(width * 0.25)), If(Convert.ToInt32(height * 0.25) = 0, 1, Convert.ToInt32(height * 0.25)))
      e.Graphics.DrawArc(penBlack, rect, 180.0F, 90.0F)
      e.Graphics.DrawArc(penWhite, rect, 180.0F, 90.0F)
      rect = New Rectangle(right - Convert.ToInt32(width * 0.25), top, If(Convert.ToInt32(width * 0.25) = 0, 1, Convert.ToInt32(width * 0.25)), If(Convert.ToInt32(height * 0.25) = 0, 1, Convert.ToInt32(height * 0.25)))
      e.Graphics.DrawArc(penBlack, rect, 270.0F, 90.0F)
      e.Graphics.DrawArc(penWhite, rect, 270.0F, 90.0F)
      rect = New Rectangle(left, bottom - Convert.ToInt32(height * 0.25), If(Convert.ToInt32(width * 0.25) = 0, 1, Convert.ToInt32(width * 0.25)), If(Convert.ToInt32(height * 0.25) = 0, 1, Convert.ToInt32(height * 0.25)))
      e.Graphics.DrawArc(penBlack, rect, 90.0F, 90.0F)
      e.Graphics.DrawArc(penWhite, rect, 90.0F, 90.0F)
      rect = New Rectangle(right - Convert.ToInt32(width * 0.25), bottom - Convert.ToInt32(height * 0.25), If(Convert.ToInt32(width * 0.25) = 0, 1, Convert.ToInt32(width * 0.25)), If(Convert.ToInt32(height * 0.25) = 0, 1, Convert.ToInt32(height * 0.25)))
      e.Graphics.DrawArc(penBlack, rect, 0, 90.0F)
      e.Graphics.DrawArc(penWhite, rect, 0, 90.0F)
   End Sub

   Public Sub freeHand()
      _freeHandIndex = 0
      _freeHandPoints = New Point(4999) {}
      _actualPoints = New LeadPoint(999) {}
   End Sub

   Public Sub MagnifyGlass()
      Dim dlg As New MagnifyGlassDialog(MagnifyGlassInteractiveMode)
      dlg.ShowDialog()
   End Sub

   Public Sub CombineImage()
      Dim images As New List(Of ViewerImages)()

      For i As Integer = 0 To Me.MdiParent.MdiChildren.Length - 1
         'images.Add(new ViewerImages(Path.GetFileNameWithoutExtension(this.MdiParent.MdiChildren[i].Text),
         images.Add(New ViewerImages(Me.MdiParent.MdiChildren(i).Text, CType(Me.MdiParent.MdiChildren(i), ViewerForm).Id, CType(Me.MdiParent.MdiChildren(i), ViewerForm).Image))
      Next

      Dim dlg As New CombineImageDialog(images, _viewer.Image)
      If dlg.ShowDialog() = DialogResult.OK Then
         Dim cmd As New CombineFastCommand()
         cmd.DestinationImage = _viewer.Image
         cmd.Flags = dlg.Flag
         cmd.DestinationRectangle = dlg.DestRect
         cmd.SourcePoint = dlg.SourcePoint

         cmd.Run(CType(Me.MdiParent.MdiChildren(dlg.ImageID), ViewerForm).Viewer.Image)

         addToImageList()
      End If
   End Sub

   Public Sub CopyImage()
      Dim images As New List(Of ViewerImages)()

      'ViewerImages viewer = new ViewerImages(Path.GetFileNameWithoutExtension(Text), Id, Image);
      Dim viewer As New ViewerImages(Text, Id, Image)

      For i As Integer = 0 To Me.MdiParent.MdiChildren.Length - 1
         'images.Add(new ViewerImages(Path.GetFileNameWithoutExtension(this.MdiParent.MdiChildren[i].Text), ((ViewerForm)this.MdiParent.MdiChildren[i]).Id, ((ViewerForm)this.MdiParent.MdiChildren[i]).Image));
         images.Add(New ViewerImages(Me.MdiParent.MdiChildren(i).Text, CType(Me.MdiParent.MdiChildren(i), ViewerForm).Id, CType(Me.MdiParent.MdiChildren(i), ViewerForm).Image))
      Next

      Dim dlg As New CopyImageDialog(viewer, images, _viewer.Image)
      If dlg.ShowDialog() = DialogResult.OK Then
         Dim sourceImage As RasterImage = _viewer.Image.Clone()
         Dim destImage As RasterImage = CType(Me.MdiParent.MdiChildren(dlg.ImageID), ViewerForm).Viewer.Image

         If destImage.BitsPerPixel <> sourceImage.BitsPerPixel Then
            Dim colorRes As New ColorResolutionCommand(ColorResolutionCommandMode.InPlace, sourceImage.BitsPerPixel, sourceImage.Order, sourceImage.DitheringMethod, ColorResolutionCommandPaletteFlags.Optimized, Nothing)
            colorRes.Run(sourceImage)
         End If

         If sourceImage.Width = destImage.Width AndAlso sourceImage.Height = destImage.Height AndAlso sourceImage.BitsPerPixel = destImage.BitsPerPixel Then
            Dim cmd As New CopyDataCommand()
            cmd.DestinationImage = destImage
            cmd.Run(sourceImage)
         Else
            sourceImage.Access()
            destImage.Access()

            Dim bytes As Integer = Math.Min(sourceImage.BytesPerLine, destImage.BytesPerLine)
            Dim rows As Integer = Math.Min(sourceImage.Height, destImage.Height)
            Dim data As Byte() = New Byte(bytes - 1) {}
            For row As Integer = 0 To rows - 1
               sourceImage.GetRow(row, data, 0, bytes)
               destImage.SetRow(row, data, 0, bytes)
            Next

            sourceImage.Release()
            destImage.Release()
         End If

         sourceImage.Dispose()
         addToImageList()
      End If
   End Sub

   Public Sub StatisticsInformation()
      Dim tmpImage As RasterImage = If((_viewer.Floater Is Nothing), _viewer.Image, _viewer.Floater)
      Dim dlg As New ImageInformationDialog(tmpImage)
      dlg.ShowDialog()
   End Sub

   Public Sub LineHistogram()
      RemoveHandler Me._viewer.MouseUp, AddressOf Me.Viewer_MouseUp
      RemoveHandler Me._viewer.MouseDown, AddressOf Me.Viewer_MouseDown
      RemoveHandler Me._viewer.MouseMove, AddressOf Me.Viewer_MouseMove
      RemoveHandler Me._viewer.MouseWheel, AddressOf Me.Viewer_MouseWheel
      RemoveHandler _viewer.Paint, AddressOf _viewer_Paint

      lineHistgramDlg = New LineHistogramDialog(Me, _viewer, _isGray)
      lineHistgramDlg.Show()
      lineHistgramDlg.TopMost = True
   End Sub

   Public Sub Separation()
      Try
         Dim command As New ColorSeparateCommand()
         CombineFloater()

         Select Case _sepType
            Case SeparationType.RGB
               command.Type = ColorSeparateCommandType.Rgb
               command.Run(_viewer.Image)

               command.DestinationImage.Page = 1
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Blue Plane")

               command.DestinationImage.Page = 2
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Green Plane")

               command.DestinationImage.Page = 3
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Red Plane")
               Exit Select
            Case SeparationType.HSV
               command.Type = ColorSeparateCommandType.Hsv
               command.Run(_viewer.Image)

               command.DestinationImage.Page = 1
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Hue Plane")

               command.DestinationImage.Page = 2
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Saturation Plane")

               command.DestinationImage.Page = 3
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Value Plane")
               Exit Select
            Case SeparationType.HLS
               command.Type = ColorSeparateCommandType.Hls
               command.Run(_viewer.Image)

               command.DestinationImage.Page = 1
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Hue Plane")

               command.DestinationImage.Page = 2
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Lightness Plane")

               command.DestinationImage.Page = 3
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Saturation Plane")
               Exit Select
            Case SeparationType.CMYK
               command.Type = ColorSeparateCommandType.Cmyk
               command.Run(_viewer.Image)

               command.DestinationImage.Page = 1
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Cyan Plane")

               command.DestinationImage.Page = 2
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Magenta Plane")

               command.DestinationImage.Page = 3
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Yellow Plane")

               command.DestinationImage.Page = 4
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Black Plane")
               Exit Select
            Case SeparationType.CMY
               command.Type = ColorSeparateCommandType.Cmy
               command.Run(_viewer.Image)

               command.DestinationImage.Page = 1
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Cyan Plane")

               command.DestinationImage.Page = 2
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Magenta Plane")

               command.DestinationImage.Page = 3
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Yellow Plane")
               Exit Select
            Case SeparationType.ALPHA
               CreateColorPlaneWindow(_viewer.Image.CreateAlphaImage(), "Alpha Plane")
               Exit Select
            Case SeparationType.YUV
               command.Type = ColorSeparateCommandType.Yuv
               command.Run(_viewer.Image)


               command.DestinationImage.Page = 1
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Y Plane")

               command.DestinationImage.Page = 2
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "U Plane")

               command.DestinationImage.Page = 3
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "V Plane")
               Exit Select
            Case SeparationType.XYZ
               command.Type = ColorSeparateCommandType.Xyz
               command.Run(_viewer.Image)


               command.DestinationImage.Page = 1
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "X Plane")

               command.DestinationImage.Page = 2
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Y Plane")

               command.DestinationImage.Page = 3
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Z Plane")
               Exit Select
            Case SeparationType.LAB
               command.Type = ColorSeparateCommandType.Lab
               command.Run(_viewer.Image)


               command.DestinationImage.Page = 1
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "L Plane")

               command.DestinationImage.Page = 2
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "A Plane")

               command.DestinationImage.Page = 3
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "B Plane")
               Exit Select
            Case SeparationType.YCRCB
               command.Type = ColorSeparateCommandType.Ycrcb
               command.Run(_viewer.Image)

               command.DestinationImage.Page = 1
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Y Plane")

               command.DestinationImage.Page = 2
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Cr Plane")

               command.DestinationImage.Page = 3
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "Cb Plane")
               Exit Select
            Case SeparationType.SCT
               command.Type = ColorSeparateCommandType.Sct
               command.Run(_viewer.Image)


               command.DestinationImage.Page = 1
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "S Plane")

               command.DestinationImage.Page = 2
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "C Plane")

               command.DestinationImage.Page = 3
               CreateColorPlaneWindow(command.DestinationImage.Clone(), "T Plane")
               Exit Select
         End Select
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try
   End Sub

   Public Sub CreateColorPlaneWindow(image As RasterImage, title As String)
      Dim child As New ViewerForm(_parent)
      child.MdiParent = _parent
      child.WindowState = FormWindowState.Normal
      child.Initialize()
      child.myLoad(image, title)
      child.Show()
   End Sub

   Public Sub Merge()
      Dim images As New List(Of ViewerImages)()

      For i As Integer = 0 To Me.MdiParent.MdiChildren.Length - 1
         'images.Add(new ViewerImages(Path.GetFileNameWithoutExtension(this.MdiParent.MdiChildren[i].Text),
         images.Add(New ViewerImages(Me.MdiParent.MdiChildren(i).Text, CType(Me.MdiParent.MdiChildren(i), ViewerForm).Id, CType(Me.MdiParent.MdiChildren(i), ViewerForm).Image))
      Next

      Dim dlg As New MergeDialog(images)
      If dlg.ShowDialog() = DialogResult.OK Then
         Dim command As New ColorMergeCommand()
         command.Type = dlg.MergeType
         command.Run(dlg.MergeImage)
         CreateColorPlaneWindow(command.DestinationImage, "Merge Image")

         addToImageList()
      End If
   End Sub

   Public Sub Undo()
      If _viewer.Floater IsNot Nothing Then
         _floaterImageIndex -= 1
         _viewer.Floater.Dispose()
         _viewer.Floater = New RasterImage(floaterImageslist(_floaterImageIndex))
         Return
      End If

      _imageIndex -= 1
      _viewer.Image.Dispose()
      _viewer.Image = New RasterImage(imageslist(_imageIndex))

      _viewer.Image.Page = _currentPageIndex
   End Sub

   Public Sub Redo()
      If _viewer.Floater IsNot Nothing Then
         _floaterImageIndex += 1
         _viewer.Floater.Dispose()
         _viewer.Floater = New RasterImage(floaterImageslist(_floaterImageIndex))
         Return
      End If

      _imageIndex += 1
      _viewer.Image.Dispose()
      _viewer.Image = New RasterImage(imageslist(_imageIndex))

      _viewer.Image.Page = _currentPageIndex
   End Sub

   Public Sub addToImageList()
      Dim i As Integer = 0
      If _viewer.Floater IsNot Nothing Then
         i = _floaterImageIndex + 1
         While floaterImageslist.Count > _floaterImageIndex + 1
            floaterImageslist.RemoveAt(i)
         End While

         floaterImageslist.Add(New RasterImage(_viewer.Floater))
         _floaterImageIndex += 1
         Return
      End If

      i = _imageIndex + 1
      While imageslist.Count > _imageIndex + 1
         imageslist.RemoveAt(i)
      End While

      imageslist.Add(New RasterImage(_viewer.Image))
      _imageIndex += 1

      _currentPageIndex = _viewer.Image.Page
   End Sub

   Public Sub CLAHE()
      Dim dlg As New CLAHEDialog()
      If dlg.ShowDialog() = DialogResult.OK Then
         Dim cmd As New CLAHECommand()
         cmd.Flags = dlg.Flags
         cmd.AlphaFactor = dlg.AlphaFactor
         cmd.BinNumber = dlg.BinNumber
         cmd.TilesNumber = dlg.TilesNumber
         cmd.TileHistClipLimit = dlg.TileHistClipLimit

         If _viewer.Floater Is Nothing Then
            cmd.Run(_viewer.Image)
         Else
            cmd.Run(_viewer.Floater)
         End If

         addToImageList()
      End If
   End Sub

   Private Sub ViewerForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      If lineHistgramDlg IsNot Nothing Then
         lineHistgramDlg.Close()
      End If
   End Sub

   Private Function getPixelColor(x As Integer, y As Integer) As RasterColor
      Dim Data As Byte()
      Dim originalValue As Integer = 0, originalValueT As Integer = 0
      Data = _viewer.Image.GetPixelData(y, x)

      Select Case _viewer.Image.BitsPerPixel
         Case 16, 12
            Dim high As Integer = If((_viewer.Image.HighBit <> -1), _viewer.Image.HighBit, _viewer.Image.BitsPerPixel)
            Dim signedBit As Integer = _viewer.Image.HighBit
            Dim checkValue As Integer = CInt(Math.Pow(2, signedBit))
            originalValue = Data(1) * 256 + Data(0)
            If originalValue >= checkValue AndAlso _viewer.Image.Signed Then
               originalValue = Data(1) * 256 + Data(0)
            Else
               originalValueT = Data(1) * 256 + Data(0)
               originalValue = Data(1) * 256 + Data(0)
            End If
            Exit Select
         Case 8
            originalValueT = Data(0)
            originalValue = Data(0)
            Exit Select
      End Select

      Return _currentPalette(originalValue)
   End Function

   Public Sub Watershed(mainPt As MainForm)
      Dim dlg As New WatershedDialog(mainPt, Me)
      dlg.TopMost = True
      dlg.Show()
   End Sub

   Public Sub Auto3DDeskew()
      Dim command As New PerspectiveDeskewCommand()
      command.Run(_viewer.Image)
      addToImageList()
   End Sub

   Private Sub ViewerForm_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
      If _viewer IsNot Nothing Then
         _viewer.Invalidate()
      End If
   End Sub

   Public Sub Grayscale(BitsPerPixel As Integer)
      Dim command As New GrayscaleCommand(BitsPerPixel)
      command.Run(_viewer.Image)
      addToImageList()
   End Sub

   Public Sub ColorResolution(BitsPerPixel As Integer, Order As RasterByteOrder, DitheringMethod As RasterDitheringMethod, PaletteFlags As ColorResolutionCommandPaletteFlags)
      Dim command As New ColorResolutionCommand(ColorResolutionCommandMode.InPlace, BitsPerPixel, Order, DitheringMethod, PaletteFlags, Nothing)
      command.Run(_viewer.Image)
      addToImageList()
   End Sub

End Class
