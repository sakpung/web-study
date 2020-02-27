' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools
Imports Leadtools.Controls
Imports Leadtools.Drawing
Imports Leadtools.ImageProcessing.Core
Public Class ViewerForm
   Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call
      InitClass()
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
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ViewerForm))
      '
      'ViewerForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(292, 273)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ViewerForm"
      Me.ShowInTaskbar = False
      Me.Text = "ViewerForm"

   End Sub

#End Region

   Public Enum MouseButton
      None = 0
      Rigth = 1
      Left = 2
   End Enum

   Private _viewer As ImageViewer
   Private _name As String
   Private _undoList As UndoRedo
   Private _xLastPos, _yLastPos, _windowLevelWidth, _windowLevelCenter As Integer
   Private _buttonPressed As MouseButton
   Private _currentPalette As RasterColor() = Nothing
   Private _toolTip As ToolTip
   Private _flags As RasterPaletteWindowLevelFlags
   Private _isWLImage, _isMagGlass As Boolean
   Private _LUTSize, _maxWidth, _minWidth, _maxLevel, _minLevel, _minValue, _maxValue, _highBit As Integer
   Private _scale As Integer = 1

   Public Property IsMagGlass() As Boolean
      Get
         Return _isMagGlass
      End Get
      Set(ByVal value As Boolean)
         _isMagGlass = value
      End Set
   End Property

   Private Sub InitClass()
      _viewer = New ImageViewer()
      _viewer.Dock = DockStyle.Fill
      _viewer.BorderStyle = BorderStyle.None
      AddHandler _viewer.DragEnter, AddressOf _viewer_DragEnter
      AddHandler _viewer.DragDrop, AddressOf _viewer_DragDrop
      AddHandler _viewer.MouseDown, AddressOf _viewer_MouseDown
      AddHandler _viewer.MouseMove, AddressOf _viewer_MouseMove
      AddHandler _viewer.MouseUp, AddressOf _viewer_MouseUp

      _toolTip = New ToolTip()

      _flags = RasterPaletteWindowLevelFlags.Logarithmic Or
                     RasterPaletteWindowLevelFlags.DicomStyle Or RasterPaletteWindowLevelFlags.Outside

      Controls.Add(_viewer)
      _viewer.BringToFront()
      _viewer.AllowDrop = True
      _undoList = New UndoRedo()
   End Sub

   Public Sub Initialize(ByVal info As ImageInformation, ByVal paintProperties As RasterPaintProperties, ByVal doSnap As Boolean)
      _viewer.BeginUpdate()
      UpdatePaintProperties(paintProperties)
      _viewer.Image = info.Image
      If (Not IsNothing(_viewer.Image)) Then
         AddHandler _viewer.Image.Changed, AddressOf Image_Changed
      End If
      _name = info.Name
      If (doSnap) Then
         Snap()
      End If
      UpdateCaption()
      _viewer.EndUpdate()

      _isWLImage = False
      _isMagGlass = False

      If _viewer.Image.GrayscaleMode <> RasterGrayscaleMode.None Then
         Select Case _viewer.Image.BitsPerPixel
            Case 8
               _currentPalette = _viewer.Image.GetPalette()
               _LUTSize = 256
               _minValue = 0
               _maxValue = 255
               _isWLImage = True
               Exit Select
            Case 12, 16
               _viewer.Image.UseLookupTable = True
               _currentPalette = _viewer.Image.GetLookupTable()
               _highBit = _viewer.Image.HighBit
               If _highBit = -1 Then
                  _highBit = _viewer.Image.BitsPerPixel - 1
               End If
               If _currentPalette Is Nothing Then
                  _LUTSize = CInt(Math.Pow(2, _highBit + 1))
                  _maxValue = CInt(If((_viewer.Image.Signed), _LUTSize / 2 - 1, _LUTSize - 1))
                  _minValue = CInt(If((_viewer.Image.Signed), -_LUTSize / 2, 0))
               Else
                  _LUTSize = _currentPalette.Length
                  Dim minMaxValueCmd As New MinMaxValuesCommand()
                  minMaxValueCmd.Run(_viewer.Image)
                  _maxValue = minMaxValueCmd.MaximumValue
                  _minValue = minMaxValueCmd.MinimumValue
               End If
               _isWLImage = True
               Exit Select
         End Select
         _scale = CInt(If(((_maxValue - _minValue) / 1000 > 0), (_maxValue - _minValue) / 1000, 1))
         _maxWidth = CInt(Math.Pow(2, _viewer.Image.BitsPerPixel)) - 1
         _minWidth = 1
         _maxLevel = CInt(Math.Pow(2, _viewer.Image.BitsPerPixel)) - 1
         _minLevel = CInt(Math.Pow(2, _viewer.Image.BitsPerPixel)) * -1 + 1
         _windowLevelCenter = CInt((_maxValue + _minValue) / 2)
         _windowLevelWidth = _maxValue - _minValue
         If _viewer.Image.Signed Then
            _flags = _flags Or RasterPaletteWindowLevelFlags.Signed
         End If
         ChangeThePalette()
      End If

   End Sub

   Public Sub UpdatePaintProperties(ByVal paintProperties As RasterPaintProperties)
      _viewer.PaintProperties = paintProperties
   End Sub

   Private Sub UpdateCaption()
      Text = _name
   End Sub


   Public ReadOnly Property UndoList() As UndoRedo
      Get
         Return _undoList
      End Get
   End Property

   Public Property Image() As RasterImage
      Get
         Return _viewer.Image
      End Get

      Set(ByVal value As RasterImage)
         _viewer.Image = Value
      End Set
   End Property

   Public ReadOnly Property Viewer() As ImageViewer
      Get
         Return _viewer
      End Get
   End Property

   Private Sub Image_Changed(ByVal sender As Object, ByVal e As RasterImageChangedEventArgs)
      UpdateCaption()
      If (Not IsNothing(MdiParent)) Then
         CType(MdiParent, MainForm).UpdateControls()
      End If
   End Sub

   Private Sub _viewer_SizeModeChanged(ByVal sender As Object, ByVal e As EventArgs)
      CType(MdiParent, MainForm).UpdateControls()
   End Sub

   Public Sub Snap()
      _viewer.ClientSize = _viewer.DisplayRectangle.Size
      ClientSize = _viewer.ClientSize
   End Sub
   Private Sub _viewer_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs)
      If (Tools.CanDrop(e.Data)) Then
         e.Effect = DragDropEffects.Copy
      End If
   End Sub

   Private Sub _viewer_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs)
      If (Tools.CanDrop(e.Data)) Then
         Dim files() As String = Tools.GetDropFiles(e.Data)
         If (Not IsNothing(files)) Then
            CType(MdiParent, MainForm).LoadDropFiles(Me, files)
         End If
      End If
   End Sub

   Private Sub _viewer_MouseDown(sender As Object, e As MouseEventArgs)
      Dim x As Integer, y As Integer
      Dim pt As LeadPointD = _viewer.ConvertPoint(Nothing, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, New LeadPointD(e.X, e.Y))
      x = Convert.ToInt32(pt.X)
      y = Convert.ToInt32(pt.Y)

      Select Case e.Button
         Case MouseButtons.Right
            _buttonPressed = MouseButton.Rigth
            _xLastPos = x
            _yLastPos = y
            Exit Select

         Case MouseButtons.Left
            _buttonPressed = MouseButton.Left
            GetCursorData(x, y, e.X, e.Y)
            _xLastPos = x
            _yLastPos = y
            Exit Select
         Case Else

            _buttonPressed = MouseButton.None
            Exit Select
      End Select
   End Sub

   Private Sub GetCursorData(x As Integer, y As Integer, CurX As Integer, CurY As Integer)
      Try
         Dim paletteValue As String, RGB As String
         If x < _viewer.Image.Width AndAlso y < _viewer.Image.Height AndAlso x >= 0 AndAlso y >= 0 AndAlso _isWLImage AndAlso _viewer.Image.BitsPerPixel <> 12 Then
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

            paletteValue = "Palette map value = " & _currentPalette(originalValue).B
            RGB = "RGB in the original image = " & originalValueT
         Else
            Dim tmpColor As RasterColor = _viewer.Image.GetPixelColor(y, x)
            RGB = String.Format("RGB = ({0},{1},{2})", tmpColor.R, tmpColor.G, tmpColor.B)
            paletteValue = "Palette map value =" & " 0 "
         End If

         If _buttonPressed = MouseButton.Left Then
            Dim tipMessage As String = String.Format("X = {1} , Y = {2} {0}{3} {0}{4}", Environment.NewLine, x, y, paletteValue, RGB)

            _toolTip.RemoveAll()
            Dim regionInteractiveMode As New ImageViewerAddRegionInteractiveMode()
            If Not _isMagGlass AndAlso Not _viewer.InteractiveModes.Contains(regionInteractiveMode) Then
               _toolTip.Show(tipMessage, _viewer, CurX + 25, CurY + 25)
            End If
         End If
      Catch generatedExceptionName As Exception
         'ex
      End Try
   End Sub

   Private Sub _viewer_MouseMove(sender As Object, e As MouseEventArgs)
      Dim x As Integer, y As Integer
      Dim pt As LeadPointD = _viewer.ConvertPoint(Nothing, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, New LeadPointD(e.X, e.Y))
      x = Convert.ToInt32(pt.X)
      y = Convert.ToInt32(pt.Y)

      If _buttonPressed = MouseButton.Rigth AndAlso _isWLImage Then
         If _xLastPos < x Then
            _windowLevelWidth = _windowLevelWidth + (x - _xLastPos) * _scale
         ElseIf _xLastPos > x Then
            _windowLevelWidth = _windowLevelWidth - (_xLastPos - x) * _scale
         End If

         _xLastPos = x

         CheckValue(_windowLevelWidth, _maxWidth, _minWidth)

         If _yLastPos < y Then
            _windowLevelCenter = _windowLevelCenter + (y - _yLastPos) * _scale
         ElseIf _yLastPos > y Then
            _windowLevelCenter = _windowLevelCenter - (_yLastPos - y) * _scale
         End If

         _yLastPos = y

         CheckValue(_windowLevelCenter, _maxLevel, _minLevel)

         ChangeThePalette()
      ElseIf _buttonPressed = MouseButton.Left Then
         If Not (_xLastPos = x AndAlso _yLastPos = y) Then
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

   Private Sub CheckValue(ByRef value As Integer, max As Integer, min As Integer)
      If value > max Then
         value = max
      End If
      If value < min Then
         value = min
      End If
   End Sub

   Private Sub ChangeThePalette()
      If _viewer.Image.BitsPerPixel = 1 Then
         Return
      End If
      Try
         Dim low As Integer = CInt(Math.Truncate(_windowLevelCenter - _windowLevelWidth / 2.0))
         Dim high As Integer = CInt(Math.Truncate(_windowLevelCenter + _windowLevelWidth / 2.0))
         Dim minValue As Integer, maxVale As Integer

         _currentPalette = New RasterColor(_LUTSize - 1) {}

         Dim cmd As New MinMaxValuesCommand()
         cmd.Run(_viewer.Image)
         minValue = cmd.MinimumValue
         maxVale = cmd.MaximumValue

         RasterPalette.WindowLevelFillLookupTable(_currentPalette, New RasterColor(0, 0, 0), New RasterColor(255, 255, 255), low, high, _viewer.Image.LowBit, _
          _highBit, minValue, maxVale, 0, _flags)

         If _viewer.Image.BitsPerPixel = 8 Then
            _viewer.Image.SetPalette(_currentPalette, 0, _currentPalette.Length)
         Else
            _viewer.Image.WindowLevel(_viewer.Image.LowBit, _highBit, _currentPalette, RasterWindowLevelMode.PaintAndProcessing)
         End If
      Catch generatedExceptionName As Exception
         'ex
      End Try
   End Sub

   Public Sub StartMagGlass()
      Dim magnifyGlassInteractiveMode As New ImageViewerMagnifyGlassInteractiveMode()

      _viewer.InteractiveModes.BeginUpdate()
      _viewer.InteractiveModes.Clear()
      _viewer.InteractiveModes.Add(magnifyGlassInteractiveMode)
      _viewer.InteractiveModes.EndUpdate()

      _isMagGlass = True
   End Sub

   Public Sub StopMagGlass()
      Dim noneInteractiveMode As New ImageViewerNoneInteractiveMode()

      _viewer.InteractiveModes.BeginUpdate()
      _viewer.InteractiveModes.Clear()
      _viewer.InteractiveModes.Add(noneInteractiveMode)
      _viewer.InteractiveModes.EndUpdate()

      _isMagGlass = False
   End Sub


End Class
