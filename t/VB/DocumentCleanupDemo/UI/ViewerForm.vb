' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.Demos
Imports Leadtools.Drawing
Imports Leadtools.ImageProcessing.Core

Namespace DocumentCleanupDemo
   Partial Public Class ViewerForm : Inherits Form

      Public Enum MouseButton
         None = 0
         Rigth = 1
         Left = 2
      End Enum

      Public Sub New()
         InitializeComponent()

         InitClass()
      End Sub

      ' Create an instance of the RasterImageViewer
      Private _viewer As ImageViewer
      Private _name As String

      Private _xLastPos, _yLastPos, _windowLevelWidth, _windowLevelCenter As Integer
      Private _buttonPressed As MouseButton
      Private _currentPalette As RasterColor() = Nothing
      Private _toolTip As ToolTip
      Private _flags As RasterPaletteWindowLevelFlags
      Private _isWLImage, _isMagGlass As Boolean
      Private _LUTSize, _maxWidth, _minWidth, _maxLevel, _minLevel, _minValue, _maxValue, _highBit As Integer
      Private _scale As Integer = 1
      Private _regionInteractiveMode As ImageViewerAddRegionInteractiveMode = Nothing
      Private _magnifyGlassInteractiveMode As ImageViewerMagnifyGlassInteractiveMode = Nothing
      Private _noneInteractiveMode As ImageViewerNoneInteractiveMode = Nothing

      Public Property magnifyGlassInteractiveMode As ImageViewerMagnifyGlassInteractiveMode
         Get
            Return _magnifyGlassInteractiveMode
         End Get
         Set(value As ImageViewerMagnifyGlassInteractiveMode)
            _magnifyGlassInteractiveMode = value
         End Set
      End Property

      Public Property noneInteractiveMode As ImageViewerNoneInteractiveMode
         Get
            Return _noneInteractiveMode
         End Get
         Set(value As ImageViewerNoneInteractiveMode)
            _noneInteractiveMode = value
         End Set
      End Property

      Public Property regionInteractiveMode As ImageViewerAddRegionInteractiveMode
         Get
            Return _regionInteractiveMode
         End Get
         Set(value As ImageViewerAddRegionInteractiveMode)
            _regionInteractiveMode = value
         End Set
      End Property

      Public Property WindowLevelCenter As Integer
         Get
            Return _windowLevelCenter
         End Get
         Set(value As Integer)
            _windowLevelCenter = value
         End Set
      End Property

      Public Property WindowLevelWidth As Integer
         Get
            Return _windowLevelWidth
         End Get
         Set(value As Integer)
            _windowLevelWidth = value
         End Set
      End Property

      Public Property WindowLevelScale As Integer
         Get
            Return _scale
         End Get
         Set(value As Integer)
            _scale = value
         End Set
      End Property

      Public Property IsMagGlass As Boolean
         Get
            Return _isMagGlass
         End Get
         Set(value As Boolean)
            _isMagGlass = value
         End Set
      End Property
      Private Sub InitClass()
         ' Initialize the _viewer and add handlers to the DragEnter/DragDrop and KeyDown events
         _viewer = New ImageViewer()
         _viewer.Dock = DockStyle.Fill
         _viewer.BorderStyle = BorderStyle.None
         AddHandler _viewer.DragEnter, AddressOf _viewer_DragEnter
         AddHandler _viewer.DragDrop, AddressOf _viewer_DragDrop
         AddHandler _viewer.KeyDown, AddressOf _viewer_KeyDown
         AddHandler _viewer.MouseDown, AddressOf _viewer_MouseDown
         AddHandler _viewer.MouseMove, AddressOf _viewer_MouseMove
         AddHandler _viewer.MouseUp, AddressOf _viewer_MouseUp

         _toolTip = New ToolTip()

         _flags = RasterPaletteWindowLevelFlags.Logarithmic Or RasterPaletteWindowLevelFlags.DicomStyle Or RasterPaletteWindowLevelFlags.Outside

         Controls.Add(_viewer)
         _viewer.BringToFront()
         _viewer.AllowDrop = True
         _viewer.AutoScroll = True
         _viewer.ScrollMode = ControlScrollMode.Auto

         ' Set a default RasterPaintProperties and Paint engine to use when displaying images on the viewer
         Dim Prop As RasterPaintProperties = New RasterPaintProperties()
         Prop = RasterPaintProperties.Default
         Prop.PaintDisplayMode = RasterPaintDisplayModeFlags.FavorBlack
         Prop.PaintEngine = RasterPaintEngine.GdiPlus
         _viewer.PaintProperties = Prop

         noneInteractiveMode = New ImageViewerNoneInteractiveMode()
         magnifyGlassInteractiveMode = New ImageViewerMagnifyGlassInteractiveMode()
         regionInteractiveMode = New ImageViewerAddRegionInteractiveMode()
         regionInteractiveMode.AutoItemMode = ImageViewerAutoItemMode.AutoSet
         regionInteractiveMode.AutoRegionToFloater = False
         regionInteractiveMode.IsEnabled = True

         _viewer.InteractiveModes.BeginUpdate()
         _viewer.InteractiveModes.Add(noneInteractiveMode)
         _viewer.InteractiveModes.Add(magnifyGlassInteractiveMode)

         _viewer.InteractiveModes.Add(regionInteractiveMode)
         _viewer.InteractiveModes.EndUpdate()
      End Sub

      Private Sub _viewer_MouseDown(sender As Object, e As MouseEventArgs)
         Dim x, y As Integer
         Dim pt As LeadPointD = _viewer.ConvertPoint(Nothing, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, New LeadPointD(e.X, e.Y))
         x = Convert.ToInt32(pt.X)
         y = Convert.ToInt32(pt.Y)

         Select Case e.Button
            Case MouseButtons.Right
               _buttonPressed = MouseButton.Rigth
               _xLastPos = x
               _yLastPos = y
            Case MouseButtons.Left
               _buttonPressed = MouseButton.Left
               GetCursorData(x, y, e.X, e.Y)
               _xLastPos = x
               _yLastPos = y
            Case Else
               _buttonPressed = MouseButton.None
         End Select
      End Sub

      Private Sub _viewer_MouseMove(sender As Object, e As MouseEventArgs)
         Dim x, y As Integer
         Dim pt As LeadPointD = _viewer.ConvertPoint(Nothing, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, New LeadPointD(e.X, e.Y))
         x = Convert.ToInt32(pt.X)
         y = Convert.ToInt32(pt.Y)

         If ((_buttonPressed = MouseButton.Rigth) AndAlso _isWLImage) Then
            If (_xLastPos < x) Then
               _windowLevelWidth = _windowLevelWidth + (x - _xLastPos) * _scale
            ElseIf (_xLastPos > x) Then
               _windowLevelWidth = _windowLevelWidth - (_xLastPos - x) * _scale
            End If

            _xLastPos = x

            CheckValue(_windowLevelWidth, _maxWidth, _minWidth)

            If (_yLastPos < y) Then
               _windowLevelCenter = _windowLevelCenter + (y - _yLastPos) * _scale
            ElseIf (_yLastPos > y) Then
               _windowLevelCenter = _windowLevelCenter - (_yLastPos - y) * _scale
            End If

            _yLastPos = y

            CheckValue(_windowLevelCenter, _maxLevel, _minLevel)

            ChangeThePalette()

         ElseIf (_buttonPressed = MouseButton.Left AndAlso Not _isMagGlass) Then
            If (Not (_xLastPos = x AndAlso _yLastPos = y)) Then
               GetCursorData(x, y, e.X, e.Y)
               _xLastPos = x
               _yLastPos = y
            End If
         End If
      End Sub

      Private Sub _viewer_MouseUp(sender As Object, e As MouseEventArgs)
         _buttonPressed = MouseButton.None
         _toolTip.Hide(_viewer)
      End Sub

      Private Sub GetCursorData(x As Integer, y As Integer, CurX As Integer, CurY As Integer)
         Try
            Dim paletteValue, RGB As String
            If (x < _viewer.Image.Width AndAlso y < _viewer.Image.Height AndAlso x >= 0 AndAlso y >= 0 AndAlso _isWLImage AndAlso _viewer.Image.BitsPerPixel <> 12) Then
               Dim Data As Byte()
               Dim originalValue, originalValueT As Integer
               originalValue = 0
               originalValueT = 0
               _viewer.Image.Access()
               Data = _viewer.Image.GetPixelData(y, x)
               _viewer.Image.Release()
               Select Case (_viewer.Image.BitsPerPixel)
                  Case 16
                  Case 12
                     Dim high As Integer
                     If (_viewer.Image.HighBit <> -1) Then
                        _viewer.Image.HighBit = _viewer.Image.HighBit
                     Else
                        _viewer.Image.HighBit = _viewer.Image.BitsPerPixel
                     End If

                     Dim signedBit As Integer = _viewer.Image.HighBit
                     Dim checkValue As Integer = CInt(Math.Pow(2, signedBit))
                     originalValue = Data(1) * 256 + Data(0)
                     If (originalValue >= checkValue AndAlso _viewer.Image.Signed) Then
                        originalValue = Data(1) * 256 + Data(0)
                        originalValueT = -1 * (((Convert.ToInt32(Math.Pow(2, signedBit - 7) - 1) - Data(1)) * 256 + 255 - Data(0)) + 1)
                     Else
                        originalValueT = Data(1) * 256 + Data(0)
                        originalValue = Data(1) * 256 + Data(0)
                     End If
                  Case 8
                     originalValueT = Data(0)
                     originalValue = Data(0)
               End Select

               paletteValue = "Palette map value = " + _currentPalette(originalValue).B.ToString()
               RGB = "RGB in the original image = " + originalValueT.ToString()
            Else
               Dim tmpColor As RasterColor = _viewer.Image.GetPixelColor(y, x)
               RGB = String.Format("RGB = ({0},{1},{2})", tmpColor.R, tmpColor.G, tmpColor.B)
               paletteValue = "Palette map value =" + " 0 "
            End If

            If (_buttonPressed = MouseButton.Left) Then
               Dim tipMessage As String = String.Format("X = {1} , Y = {2} {0}{3} {0}{4}", Environment.NewLine, x, y, paletteValue, RGB)
               _toolTip.RemoveAll()

               If (Not _isMagGlass AndAlso Not _viewer.InteractiveModes.Contains(regionInteractiveMode)) Then
                  _toolTip.Show(tipMessage, _viewer, CurX + 20, CurY + 20)
               End If
            End If
         Catch ex As Exception

         End Try
      End Sub

      Public Sub Initialize(ByVal info As ImageInformation, ByVal paintProperties As RasterPaintProperties, ByVal animateRegions As Boolean, ByVal snap1 As Boolean, ByVal useDpi As Boolean)
         _viewer.BeginUpdate()
         UpdateAnimateRegions(animateRegions)
         UpdatePaintProperties(paintProperties)
         _viewer.Image = info.Image
         _viewer.UseDpi = useDpi
         If Not _viewer.Image Is Nothing Then
            AddHandler _viewer.Image.Changed, AddressOf Image_Changed
         End If
         _name = info.Name
         If snap1 Then
            Snap()
         End If
         UpdateCaption()
         _viewer.EndUpdate()

         _isWLImage = False
         _isMagGlass = False

         If (Viewer.Image.GrayscaleMode <> RasterGrayscaleMode.None) Then
            Select Case _viewer.Image.BitsPerPixel
               Case 8
                  If (_viewer.Image.GrayscaleMode = RasterGrayscaleMode.NotOrdered) Then
                     Dim cmd As Leadtools.ImageProcessing.GrayscaleCommand = New Leadtools.ImageProcessing.GrayscaleCommand(8)
                     cmd.Run(_viewer.Image)
                  End If
                  _currentPalette = _viewer.Image.GetPalette()
                  _LUTSize = 256
                  _minValue = 0
                  _maxValue = 255
                  _isWLImage = True
               Case 12
               Case 16
                  _viewer.Image.UseLookupTable = True
                  _currentPalette = _viewer.Image.GetLookupTable()
                  _highBit = _viewer.Image.HighBit
                  If (_highBit = -1) Then
                     _highBit = _viewer.Image.BitsPerPixel - 1
                  End If

                  If (_currentPalette Is Nothing) Then
                     _LUTSize = CInt(Math.Pow(2, _highBit + 1))
                     If (_viewer.Image.Signed) Then
                        _maxValue = CInt(_LUTSize / 2 - 1)
                        _minValue = CInt(-_LUTSize / 2)
                     Else
                        _maxValue = _LUTSize - 1
                        _minValue = 0
                     End If

                     createPalette()
                  Else
                     _LUTSize = _currentPalette.Length
                     Dim minMaxValueCmd As MinMaxValuesCommand = New MinMaxValuesCommand()
                     minMaxValueCmd.Run(_viewer.Image)
                     _maxValue = minMaxValueCmd.MaximumValue
                     _minValue = minMaxValueCmd.MinimumValue
                  End If

                  _isWLImage = True
            End Select

            If (((_maxValue - _minValue) / 1000 > 0)) Then
               _scale = CInt((_maxValue - _minValue) / 1000)
            Else
               _scale = 1
            End If

            _maxWidth = CInt(Math.Pow(2, _viewer.Image.BitsPerPixel) - 1)
            _minWidth = 1
            _maxLevel = CInt(Math.Pow(2, _viewer.Image.BitsPerPixel) - 1)
            _minLevel = CInt(Math.Pow(2, _viewer.Image.BitsPerPixel) * -1 + 1)

            If (_viewer.Image.Signed) Then
               _flags = _flags Or RasterPaletteWindowLevelFlags.Signed
               getWindowLevelForSigned(_currentPalette)

            Else
               getWindowLevelForUnSigned(_currentPalette)
            End If
         End If
      End Sub
      Private Sub getWindowLevelForSigned(palette() As RasterColor)
         Dim i As Integer = 0
         Dim lowValue As Integer = 0
         Dim highValue As Integer = 0

         Try
            Select Case palette(0).R
               Case 0
                  While (palette(i).R = 0 Or palette(i).R = 255)
                     If (i < palette.Length - 1) Then
                        If (i = _maxValue) Then
                           i = _minValue + palette.Length
                        Else
                           i = ++i
                        End If
                     Else
                        Exit While
                     End If
                  End While

                  If (i = palette.Length - 1) Then
                     lowValue = _maxValue + 2
                     highValue = lowValue + 2
                  Else
                     If (i > _maxValue) Then
                        lowValue = i - palette.Length
                     Else
                        lowValue = i
                     End If

                     If (lowValue > 0) Then
                        While (palette(i).R <> 255)
                           If (i < _maxValue) Then
                              i = i + 1
                           Else
                              Dim max As Integer = _maxValue
                              Dim low As Integer = lowValue
                              highValue = CInt(_maxValue + ((max - low) * (255.0 - palette(max).R)) / palette(max).R)

                              Exit While
                           End If
                           If (i < _maxValue) Then
                              highValue = i
                           End If
                        End While
                     Else
                        While (palette(i).R <> 0)
                           If (i < palette.Length - 1) Then
                              i = i + 1
                           End If
                           highValue = i - palette.Length
                           lowValue = lowValue - CInt(((highValue - lowValue) * (255.0 - palette(lowValue + palette.Length).R)) / (palette(lowValue + palette.Length).R))
                        End While
                     End If
                  End If
               Case 255
                  i = 0
                  While (palette(i).R = 255 Or palette(i).R = 0)
                     If (i < palette.Length - 1) Then
                        If (i = _maxValue) Then
                           i = _minValue + palette.Length
                        Else
                           i = ++i
                        End If
                     Else
                        Exit While
                     End If
                  End While

                  If (i = palette.Length - 1) Then
                     lowValue = _minValue - 2
                     highValue = lowValue + 2
                  Else
                     If (i > _maxValue) Then
                        lowValue = i - palette.Length
                     Else
                        lowValue = i
                     End If

                     If (lowValue > 0) Then
                        While (palette(i).R <> 0)
                           If (i < _maxValue) Then
                              i = i + 1
                           Else

                              Dim max As Integer = _maxValue
                              Dim low As Integer = lowValue
                              highValue = CInt(_maxValue + ((max - low) * palette(max).R) / (255.0 - palette(max).R))
                              Exit While
                           End If
                        End While

                        If (i < _maxValue) Then
                           highValue = i
                        End If
                     Else
                        While (palette(i).R <> 255)
                           If (i < palette.Length - 1) Then
                              i = i + 1
                           End If
                        End While

                        highValue = i - palette.Length
                        lowValue = lowValue - CInt(((highValue - lowValue) * palette(lowValue + palette.Length).R) / (255.0 - palette(lowValue + palette.Length).R))
                     End If
                  End If

               Case Else
                  i = 0

                  While (palette(i).R <> 0 AndAlso palette(i).R <> 255)
                     If (i < _maxValue) Then
                        i = i + 1
                     Else
                        Exit While
                     End If
                  End While

                  If (i = _maxValue) Then
                     i = palette.Length - Math.Abs(_minValue)
                     While (palette(i).R = 0 Or palette(i).R = 255)
                        If (i < palette.Length - 1) Then
                           i = i + 1
                        Else
                           Exit While
                        End If
                     End While

                     If (i = palette.Length - Math.Abs(_minValue)) Then

                        Dim max As Integer = _maxValue
                        Dim min As Integer = _minValue

                        If (palette(min + palette.Length).R > palette(max).R) Then
                           lowValue = CInt((max - min) * (255.0 - palette(max).R) / (palette(max).R - palette(min + palette.Length).R) + max)
                           highValue = CInt(min - (max - min) * palette(min + palette.Length).R / (palette(max).R - palette(min + palette.Length).R))
                        Else
                           highValue = CInt((max - min) * (255.0 - palette(max).R) / (palette(max).R - palette(min + palette.Length).R) + max)
                           lowValue = CInt(min - (max - min) * palette(min + palette.Length).R / (palette(max).R - palette(min + palette.Length).R))
                        End If

                     Else
                        Dim max As Integer = _maxValue
                        Dim min As Integer = _minValue

                        lowValue = i - palette.Length

                        If (palette(i).R > palette(_maxValue).R) Then
                           highValue = CInt(max + ((max - lowValue) * palette(max).R) / (255.0 - palette(max).R))
                        Else
                           highValue = CInt(max + ((max - lowValue) * (255.0 - palette(max).R)) / palette(max).R)
                        End If

                     End If

                  Else

                     highValue = i

                     While (palette(i).R = 0 Or palette(i).R = 255)
                        If (i < palette.Length - 1) Then
                           i = i + 1
                        Else
                           Exit While
                        End If
                     End While


                     If (i < palette.Length - 1) Then
                        lowValue = i - palette.Length
                     End If

                     If (lowValue < _minValue) Then
                        lowValue = _minValue
                        lowValue = lowValue - CInt(((highValue - lowValue) * palette(i).R) / (255.0 - palette(i).R))
                     End If
                  End If
            End Select

            _windowLevelWidth = highValue - lowValue
            _windowLevelCenter = CInt((highValue + lowValue) / 2)
            CheckValue(_windowLevelWidth, CInt(Math.Pow(2, _viewer.Image.BitsPerPixel)) - 1, 1)
            CheckValue(_windowLevelCenter, CInt(Math.Pow(2, _viewer.Image.BitsPerPixel)), CInt(Math.Pow(2, _viewer.Image.BitsPerPixel)) * -1 + 1)
            ChangeThePalette()
         Catch ex As Exception

         End Try
      End Sub
      Private Sub getWindowLevelForUnSigned(palette() As RasterColor)

         If (_viewer.Image.BitsPerPixel = 1) Then
            Return
         End If

         Try
            Dim lowValue As Integer = 0
            Dim highValue As Integer = 0
            Dim max As Integer = _maxValue
            Dim min As Integer = _minValue
            Dim i As Integer = min

            Select Case palette(0).R
               Case 0
                  While (palette(i).R = 0)
                     If (i < _maxValue) Then
                        i = i + 1
                     Else
                        Exit While
                     End If
                  End While

                  If (i = _maxValue) Then
                     lowValue = _maxValue
                     highValue = lowValue + 2
                  Else
                     lowValue = i
                     While (palette(i).R <> 255)
                        If (i < _maxValue) Then
                           i = i + 1
                        Else
                           Exit While
                        End If
                     End While

                     If (i = _maxValue) Then
                        max = _maxValue
                        highValue = CInt(max + (max - lowValue) * (255.0 - palette(max).R) / palette(max).R)
                     End If

                     If (i < _maxValue) Then
                        highValue = i
                     End If
                  End If

               Case 255

                  i = 0
                  While (palette(i).R = 255)
                     If (i < _maxValue) Then
                        i = i + 1
                     Else
                        Exit While
                     End If
                  End While

                  If (i = _maxValue) Then
                     lowValue = -2
                     highValue = 0
                  Else
                     lowValue = i
                     While (palette(i).R <> 0)
                        If (i < _maxValue) Then
                           i = i + 1
                        Else
                           highValue = CInt((max + (max - lowValue) * palette(max).R / (255.0 - palette(max).R)))
                           Exit While
                        End If

                        If (i < _maxValue) Then
                           highValue = i
                        End If
                     End While
                  End If

               Case Else
                  i = 0

                  While (palette(i).R <> 0 AndAlso palette(i).R <> 255)
                     If (i < _maxValue) Then
                        i = i + 1
                     Else
                        Exit While
                     End If
                  End While

                  If (i = _maxValue) Then
                     lowValue = CInt(min - max * (255.0 - palette(min).R) / (palette(min).R - palette(max).R))
                     highValue = CInt(max + ((max - min) * palette(max).R / (palette(min).R - palette(max).R)))
                  Else
                     lowValue = CInt(min - ((((highValue - min) * palette(min).R) / (255.0 - palette(min).R))))
                  End If

            End Select

            _windowLevelWidth = highValue - lowValue
            _windowLevelCenter = CInt((highValue + lowValue) / 2)
            CheckValue(_windowLevelWidth, CInt(Math.Pow(2, _viewer.Image.BitsPerPixel)) - 1, 1)
            CheckValue(_windowLevelCenter, CInt(Math.Pow(2, _viewer.Image.BitsPerPixel)), CInt(Math.Pow(2, _viewer.Image.BitsPerPixel)) * -1 + 1)
            ChangeThePalette()

         Catch ex As Exception

         End Try
      End Sub

      Private Sub CheckValue(ByRef value As Integer, max As Integer, min As Integer)
         If (value > max) Then
            value = max
         End If

         If (value < min) Then
            value = min
         End If
      End Sub

      Public Sub UpdatePaintProperties(ByVal paintProperties As RasterPaintProperties)
         _viewer.PaintProperties = paintProperties
      End Sub

      Public Sub UpdateAnimateRegions(ByVal animateRegions As Boolean)
         If (animateRegions) Then
            _viewer.ImageRegionRenderMode = ControlRegionRenderMode.Animated
            _viewer.FloaterRegionRenderMode = ControlRegionRenderMode.Animated
         Else
            _viewer.ImageRegionRenderMode = ControlRegionRenderMode.Fixed
            _viewer.FloaterRegionRenderMode = ControlRegionRenderMode.Fixed
         End If
      End Sub

      Private Sub UpdateCaption()
         Text = String.Format("{0} - Page {1}:{2}", _name, _viewer.Image.Page, _viewer.Image.PageCount)
      End Sub

      Public ReadOnly Property Image() As RasterImage
         Get
            Return _viewer.Image
         End Get
      End Property

      Public ReadOnly Property Viewer() As ImageViewer
         Get
            Return _viewer
         End Get
      End Property

      Private Sub Image_Changed(ByVal sender As Object, ByVal e As RasterImageChangedEventArgs)
         UpdateCaption()
      End Sub
      Public Sub Snap()
         _viewer.ClientSize = _viewer.ClientRectangle.Size
         ClientSize = _viewer.ClientSize
      End Sub

      Private Sub _viewer_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs)
         If Tools.CanDrop(e.Data) Then
            e.Effect = DragDropEffects.Copy
         End If
      End Sub

      Private Sub _viewer_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs)
         If Tools.CanDrop(e.Data) Then
            Dim files As String() = Tools.GetDropFiles(e.Data)
            If Not files Is Nothing Then
               CType(MdiParent, MainForm).LoadDropFiles(Me, files)
            End If
         End If
      End Sub

      Private Sub _viewer_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
         If (Not e.Handled) Then
            If e.KeyCode = Keys.Add OrElse e.KeyCode = Keys.Oemplus OrElse e.KeyCode = Keys.Subtract OrElse e.KeyCode = Keys.OemMinus Then
               e.Handled = True
            End If
         End If
      End Sub

      Private Sub ChangeThePalette()
         If (_viewer.Image.BitsPerPixel = 1) Then
            Return
         End If

         Try
            Dim low As Integer = CInt(_windowLevelCenter - _windowLevelWidth / 2.0)
            Dim high As Integer = CInt(_windowLevelCenter + _windowLevelWidth / 2.0)

            ReDim _currentPalette(_LUTSize)

            RasterPalette.WindowLevelFillLookupTable(
              _currentPalette,
              New RasterColor(0, 0, 0),
              New RasterColor(255, 255, 255),
              low,
              high,
              _viewer.Image.LowBit,
              _highBit,
              _minValue,
              _maxValue,
              0,
              _flags)

            If (_viewer.Image.BitsPerPixel = 8) Then
               _viewer.Image.SetPalette(_currentPalette, 0, _currentPalette.Length)
            Else
               _viewer.Image.WindowLevel(
                  _viewer.Image.LowBit,
                  _highBit,
                  _currentPalette,
                 RasterWindowLevelMode.PaintAndProcessing)
            End If
         Catch ex As Exception

         End Try
      End Sub

      Private Sub createPalette()
         If (_viewer.Image.BitsPerPixel = 1) Then
            Return
         End If
         _currentPalette(_LUTSize) = New RasterColor
         _windowLevelWidth = _maxValue - _minValue
         _windowLevelCenter = CInt((_maxValue + _minValue) / 2)

         If (_viewer.Image.BitsPerPixel = 8) Then
            _viewer.Image.SetPalette(_currentPalette, 0, _currentPalette.Length)
         Else
            _viewer.Image.SetLookupTable(_currentPalette)
         End If
         ChangeThePalette()
      End Sub

      Public Sub DisableInteractiveModes()
         For Each mode As ImageViewerInteractiveMode In _viewer.InteractiveModes
            mode.IsEnabled = False
         Next mode
      End Sub

      Public Sub StartMagGlass()
         DisableInteractiveModes()
         _viewer.InteractiveModes.EnableById(magnifyGlassInteractiveMode.Id)
         _isMagGlass = True
      End Sub
      

      Public Sub StopMagGlass()
         DisableInteractiveModes()
         _viewer.InteractiveModes.EnableById(noneInteractiveMode.Id)
         _isMagGlass = False
      End Sub

      Public Sub Histogram()
         Dim dlg As HistogramDlg = New HistogramDlg(_viewer.Image, _isWLImage)
         dlg.ShowDialog()
      End Sub

   End Class
End Namespace
