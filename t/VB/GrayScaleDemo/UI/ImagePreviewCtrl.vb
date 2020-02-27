' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports GrayScaleDemo.Leadtools.Demos
Imports Leadtools.Drawing
Imports System


Public Class PanImageEvent
   Inherits EventArgs
   Private _offset As Point

   Public Sub New(offset As Point)
      _offset = offset
   End Sub

   Public ReadOnly Property Offset() As Point
      Get
         Return _offset
      End Get
   End Property
End Class

Partial Public Class ImagePreviewCtrl
   Inherits UserControl
   Private _image As RasterImage
   Private _paintProperties As RasterPaintProperties
   Private _fitView As Boolean
   Private _sourceRectangle As Rectangle
   Private _destinationRectangle As Rectangle
   Private _borderStyle As BorderStyle
   Private _isPanAllowed As Boolean
   Private _isPanModeBusy As Boolean
   Private _isCursorClipped As Boolean
   Private _rcClip As Rectangle
   Private _panPoint As Point
   Private _offset As Point

   Private Const WS_BORDER As Integer = &H800000
   Private Const WS_EX_CLIENTEDGE As Integer = &H200

   Public Sub New(image As RasterImage, paintProperties As RasterPaintProperties, previewPosition As Point, previewSize As Size)
      Me.Location = previewPosition
      Me.Size = previewSize

      InitializeComponent()
      SetStyle(ControlStyles.ResizeRedraw, True)
      SetStyle(ControlStyles.AllPaintingInWmPaint, True)
      SetStyle(ControlStyles.ContainerControl, True)
      SetStyle(ControlStyles.SupportsTransparentBackColor, True)
      SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
      SetStyle(ControlStyles.UserPaint, True)

      _image = image
      _paintProperties = paintProperties
      _fitView = False
      _sourceRectangle = Rectangle.Empty
      _destinationRectangle = Rectangle.Empty
      _borderStyle = BorderStyle.Fixed3D
      _isPanAllowed = False
      _isPanModeBusy = False
      _isCursorClipped = False
      _panPoint = Point.Empty
      _offset = Point.Empty

      CalculateAll()
   End Sub

   Public Property Image() As RasterImage
      Get
         Return _image
      End Get
      Set(value As RasterImage)
         If _image IsNot value Then
            _image = value
            OnImageChanged(EventArgs.Empty)
         End If
      End Set
   End Property

   Public Event ImageChanged As EventHandler

   Protected Overridable Sub OnImageChanged(e As EventArgs)
      CalculateAll()
      Invalidate()

      RaiseEvent ImageChanged(Me, e)
   End Sub

   Protected Overrides ReadOnly Property CreateParams() As CreateParams
      Get
         Dim cp As CreateParams = MyBase.CreateParams

         Select Case BorderStyle
            Case BorderStyle.None
               cp.Style = cp.Style And Not WS_BORDER
               cp.ExStyle = cp.ExStyle And Not WS_EX_CLIENTEDGE
               Exit Select

            Case BorderStyle.FixedSingle
               cp.Style = cp.Style Or WS_BORDER
               cp.ExStyle = cp.ExStyle And Not WS_EX_CLIENTEDGE
               Exit Select

            Case BorderStyle.Fixed3D
               cp.Style = cp.Style And Not WS_BORDER
               cp.ExStyle = cp.ExStyle Or WS_EX_CLIENTEDGE
               Exit Select
         End Select

         Return cp
      End Get
   End Property

   Protected Overrides Sub OnPaint(e As PaintEventArgs)
      Try
         Dim dstRect As Rectangle = DestinationRectangle


         RasterImagePainter.Paint(_image, e.Graphics, Converters.ConvertRect(SourceRectangle), LeadRect.Empty, Converters.ConvertRect(dstRect), Converters.ConvertRect(e.ClipRectangle), _
          _paintProperties)
      Catch
      End Try
   End Sub

   Public Event FitViewChanged As EventHandler

   Protected Overridable Sub OnFitViewChanged(e As EventArgs)
      CalculateAll()
      Invalidate()

      RaiseEvent FitViewChanged(Me, e)
   End Sub

   Public Event BorderStyleChanged As EventHandler

   Protected Overridable Sub OnBorderStyleChanged(e As EventArgs)
      UpdateStyles()
      Invalidate()

      RaiseEvent BorderStyleChanged(Me, e)
   End Sub

   Private Sub CalculateAll()
      Dim currentXScaleFactor As Double = 1
      Dim currentYScaleFactor As Double = 1

      Dim fitView__1 As Boolean = FitView
      _sourceRectangle = Rectangle.Empty
      If _image IsNot Nothing Then
         _sourceRectangle = New Rectangle(0, 0, _image.Width, _image.Height)
      End If

      _destinationRectangle = ClientRectangle

      If fitView__1 Then
         If _sourceRectangle.Width > 0 AndAlso _sourceRectangle.Height > 0 Then
            If _destinationRectangle.Width > 0 AndAlso _destinationRectangle.Height > 0 Then
               Dim factor As Double

               If _destinationRectangle.Width > _destinationRectangle.Height Then
                  factor = _destinationRectangle.Width / CDbl(_sourceRectangle.Width)
                  If (factor * CDbl(_sourceRectangle.Height)) > _destinationRectangle.Height Then
                     factor = _destinationRectangle.Height / CDbl(_sourceRectangle.Height)
                  End If
               Else
                  factor = _destinationRectangle.Height / CDbl(_sourceRectangle.Height)
                  If (factor * CDbl(_sourceRectangle.Width)) > _destinationRectangle.Width Then
                     factor = _destinationRectangle.Width / CDbl(_sourceRectangle.Width)
                  End If
               End If

               currentXScaleFactor = factor
               currentYScaleFactor = factor
            End If
         End If
      End If

      If currentXScaleFactor <= 0.0 Then
         currentXScaleFactor = 1
      End If
      If currentYScaleFactor <= 0.0 Then
         currentYScaleFactor = 1
      End If

      _destinationRectangle = New Rectangle(0, 0, CInt(SourceRectangle.Width * currentXScaleFactor), CInt(SourceRectangle.Height * currentYScaleFactor))
      Dim left As Integer = 0
      Dim top As Integer = 0

      ' Center the Image.
      left = CInt((ClientRectangle.Width - _destinationRectangle.Width) / 2)
      top = CInt((ClientRectangle.Height - _destinationRectangle.Height) / 2)

      _isPanAllowed = Not FitView AndAlso (SourceRectangle.Width > ClientRectangle.Width OrElse SourceRectangle.Height > ClientRectangle.Height)

      _offset = Point.Empty
      _destinationRectangle.Offset(left, top)
   End Sub

   Public Property FitView() As Boolean
      Get
         Return _fitView
      End Get
      Set(value As Boolean)
         If _fitView <> value Then
            _fitView = value
            OnFitViewChanged(EventArgs.Empty)
         End If
      End Set
   End Property

   Public Shadows Property BorderStyle() As BorderStyle
      Get
         Return _borderStyle
      End Get

      Set(value As BorderStyle)
         If value <> BorderStyle Then
            _borderStyle = value
            OnBorderStyleChanged(EventArgs.Empty)
         End If
      End Set
   End Property

   Public ReadOnly Property Offset() As Point
      Get
         Return _offset
      End Get
   End Property

   Private ReadOnly Property IsPanModeBusy() As Boolean
      Get
         Return _isPanModeBusy
      End Get
   End Property

   Private ReadOnly Property SourceRectangle() As Rectangle
      Get
         Return _sourceRectangle
      End Get
   End Property

   Private ReadOnly Property DestinationRectangle() As Rectangle
      Get
         Return _destinationRectangle
      End Get
   End Property

   Private ReadOnly Property IsPanAllowed() As Boolean
      Get
         Return _isPanAllowed
      End Get
   End Property

   Private Sub CancelPanMode()
      If IsPanModeBusy Then
         EndPanMode()
      End If
   End Sub

   Private Sub EndPanMode()
      If IsPanModeBusy Then
         Capture = False
         _isPanModeBusy = False

         EndClipCursor()
      End If
   End Sub

   Private Sub BeginPanMode(clipCursor As Boolean)
      _isPanModeBusy = True
      Capture = True

      If clipCursor Then
         BeginClipCursor()
      End If
   End Sub

   Private Sub BeginClipCursor()
      Dim rc As Rectangle = Rectangle.Intersect(DemosGlobal.FixRectangle(SourceRectangle), ClientRectangle)
      rc = RectangleToScreen(rc)
      Dim parent__1 As Control = Parent
      While parent__1 IsNot Nothing
         rc = Rectangle.Intersect(rc, Parent.RectangleToScreen(Parent.ClientRectangle))
         If TypeOf parent__1 Is Form Then
            Dim form As Form = TryCast(parent__1, Form)
            If form.IsMdiChild AndAlso form.Owner IsNot Nothing Then
               rc = Rectangle.Intersect(rc, form.Owner.RectangleToScreen(form.Owner.ClientRectangle))
            End If
         End If

         parent__1 = parent__1.Parent
      End While

      _rcClip = Cursor.Clip
      Cursor.Clip = rc
      _isCursorClipped = True
   End Sub

   Private Sub EndClipCursor()
      If _isCursorClipped Then
         Cursor.Clip = _rcClip
         _isCursorClipped = False
         _rcClip = Rectangle.Empty
      End If
   End Sub

   Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
      Focus()

      If Image IsNot Nothing Then
         If e.Button = MouseButtons.Left Then
            If IsPanAllowed Then
               If IsPanModeBusy Then
                  CancelPanMode()
               Else
                  Dim pt As New Point(e.X, e.Y)
                  Dim rc As Rectangle = SourceRectangle
                  If rc.Contains(pt) Then
                     BeginPanMode(False)
                     _panPoint = pt
                  End If
               End If
            End If
         ElseIf IsPanModeBusy Then
            CancelPanMode()
         End If
      End If

      MyBase.OnMouseDown(e)
   End Sub

   Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
      If IsPanModeBusy Then
         If (_panPoint.X - e.X) <> 0 OrElse (_panPoint.Y - e.Y) <> 0 Then
            Dim offset As New Point(-(_panPoint.X - e.X), -(_panPoint.Y - e.Y))

            UpdateDestinationRect(offset)
            _panPoint = New Point(e.X, e.Y)
         End If
      End If
      MyBase.OnMouseMove(e)
   End Sub

   Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
      If IsPanAllowed Then
         EndPanMode()
      End If
      MyBase.OnMouseUp(e)
   End Sub

   Private Sub UpdateDestinationRect(offset As Point)
      Dim updatePan As Boolean = False
      Dim panPoint As Point = Point.Empty

      If (_destinationRectangle.Left + offset.X <= 0) AndAlso (Math.Abs(_destinationRectangle.Left) + ClientRectangle.Width - offset.X <= SourceRectangle.Width) Then
         updatePan = True
         panPoint.X = offset.X
      End If

      If (_destinationRectangle.Top + offset.Y <= 0) AndAlso (Math.Abs(_destinationRectangle.Top) + ClientRectangle.Height - offset.Y <= SourceRectangle.Height) Then
         updatePan = True
         panPoint.Y = offset.Y
      End If

      If updatePan Then
         Dim e As New PanImageEvent(panPoint)
         OnPanImage(e)
      End If
   End Sub

   Public Event PanImage As EventHandler(Of PanImageEvent)

   Protected Overridable Sub OnPanImage(e As PanImageEvent)
      OffsetImage(e.Offset)
      RaiseEvent PanImage(Me, e)
   End Sub

   Public Sub OffsetImage(offset As Point)
      _destinationRectangle.Offset(offset)
      _offset.Offset(offset)

      Invalidate()
   End Sub
End Class
