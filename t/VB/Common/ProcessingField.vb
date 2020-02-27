' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Collections.Generic
Imports System.Text

Imports Leadtools
Imports Leadtools.Forms.Recognition
Imports Leadtools.Forms.Processing

#If LEADTOOLS_V17_OR_LATER Then
Imports Leadtools.Drawing
#End If

Namespace FormsDemo
   Public Enum ProcessingFieldType
      None
      Text
      Omr
      Barcode
      Image
   End Enum

   Public Enum HitTestPosition
      Inside
      Outside
      LeftTop
      RightTop
      LeftBottom
      RightBottom
      LeftEdge
      RightEdge
      UpperEdge
      LowerEdge
   End Enum

   Public Class ProcessingField
      Private _processingBox As FormField = Nothing
      Private _ProcessingBoxRect As Rectangle
      Private _brush As SolidBrush = Nothing
      Private _pen As Pen = Nothing
      Private _type As ProcessingFieldType
      Private _leftTopHandle As Rectangle
      Private _rightTopHandle As Rectangle
      Private _leftBottomHandle As Rectangle
      Private _rightBottomHandle As Rectangle
      Private _upperHandle As Rectangle
      Private _lowerHandle As Rectangle
      Private _leftHandle As Rectangle
      Private _rightHandle As Rectangle
      Private _selected As Boolean = True
      Private _dpiX As Integer = 0
      Private _dpiY As Integer = 0

      Public Sub New(ByVal processingBox_Renamed As FormField, ByVal type_Renamed As ProcessingFieldType, ByVal image As RasterImage, ByVal brush As SolidBrush, ByVal pen As Pen)
         _type = type_Renamed
         _brush = brush
         _pen = pen
         _processingBox = processingBox_Renamed
         _ProcessingBoxRect = Leadtools.Demos.Converters.ConvertRect(_processingBox.Bounds.ToRectangle(_dpiX, _dpiX))
         AdjustRectPoints()
      End Sub

      Public Property BarcodeBox() As BarcodeFormField
         Get
            Return TryCast(_processingBox, BarcodeFormField)
         End Get
         Set(ByVal value As BarcodeFormField)
            _processingBox = Value
         End Set
      End Property

      Public Property ImageBox() As ImageFormField
         Get
            Return TryCast(_processingBox, ImageFormField)
         End Get
         Set(ByVal value As ImageFormField)
            _processingBox = Value
         End Set
      End Property

      Public Property OcrBox() As TextFormField
         Get
            Return TryCast(_processingBox, TextFormField)
         End Get
         Set(ByVal value As TextFormField)
            _processingBox = Value
         End Set
      End Property

      Public Property OmrBox() As OmrFormField
         Get
            Return TryCast(_processingBox, OmrFormField)
         End Get
         Set(ByVal value As OmrFormField)
            _processingBox = Value
         End Set
      End Property

      Public ReadOnly Property Type() As ProcessingFieldType
         Get
            Return _type
         End Get
      End Property

      Public Property Selected() As Boolean
         Get
            Return _selected
         End Get
         Set(ByVal value As Boolean)
            _selected = Value
         End Set
      End Property

      Private Sub AdjustRectPoints()
         Dim x As Integer = 0
         Dim y As Integer = 0
         Dim width As Integer = Math.Abs(_processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Width)
         Dim height As Integer = Math.Abs(_processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Height)

         If _processingBox.Bounds.Width <= 0 AndAlso _processingBox.Bounds.Height <= 0 Then
            x = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left
            y = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top

            If width = 0 Then
               width = 1
            End If

            If height = 0 Then
               height = 1
            End If

            _processingBox.Bounds = New LogicalRectangle(x, y, width, height, LogicalUnit.Pixel)
         ElseIf _processingBox.Bounds.Width <= 0 AndAlso _processingBox.Bounds.Height > 0 Then
            x = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left
            y = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top

            If width = 0 Then
               width = 1
            End If

            _processingBox.Bounds = New LogicalRectangle(x, y, width, height, LogicalUnit.Pixel)
         ElseIf _processingBox.Bounds.Width > 0 AndAlso _processingBox.Bounds.Height <= 0 Then
            x = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left
            y = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top

            If height = 0 Then
               height = 1
            End If

            _processingBox.Bounds = New LogicalRectangle(x, y, width, height, LogicalUnit.Pixel)
         End If

         CreateHandles()
         _ProcessingBoxRect = Leadtools.Demos.Converters.ConvertRect(_processingBox.Bounds.ToRectangle(_dpiX, _dpiX))
      End Sub

      Public Property Name() As String
         Get
            Return _processingBox.Name
         End Get
         Set(ByVal value As String)
            _processingBox.Name = Value
         End Set
      End Property

      Public Property Rectangle() As RectangleF
         Get
            Return Leadtools.Demos.Converters.ConvertRect(_processingBox.Bounds.ToRectangle(_dpiX, _dpiY))
         End Get
         Set(ByVal value As RectangleF)
            _processingBox.Bounds = New LogicalRectangle(value.Left, value.Top, value.Width, value.Height, LogicalUnit.Pixel)
            _ProcessingBoxRect = System.Drawing.Rectangle.Round(Value)
            CreateHandles()
         End Set
      End Property

      Public ReadOnly Property ProcessingBox() As FormField
         Get
            Return _processingBox
         End Get
      End Property

      Private Function PointInRectangle(ByVal position As PointF, ByVal rect As Rectangle) As Boolean
         If (position.X > rect.Left AndAlso position.X < rect.Right) AndAlso (position.Y > rect.Top AndAlso position.Y < rect.Bottom) Then
            Return True
         Else
            Return False
         End If
      End Function

      Public Function HitTest(ByVal position As PointF) As HitTestPosition
         If PointInRectangle(position, _leftTopHandle) Then
            Return HitTestPosition.LeftTop
         ElseIf PointInRectangle(position, _rightTopHandle) Then
            Return HitTestPosition.RightTop
         ElseIf PointInRectangle(position, _leftBottomHandle) Then
            Return HitTestPosition.LeftBottom
         ElseIf PointInRectangle(position, _rightBottomHandle) Then
            Return HitTestPosition.RightBottom
         ElseIf PointInRectangle(position, _upperHandle) Then
            Return HitTestPosition.UpperEdge
         ElseIf PointInRectangle(position, _lowerHandle) Then
            Return HitTestPosition.LowerEdge
         ElseIf PointInRectangle(position, _rightHandle) Then
            Return HitTestPosition.RightEdge
         ElseIf PointInRectangle(position, _leftHandle) Then
            Return HitTestPosition.LeftEdge
         ElseIf PointInRectangle(position, Leadtools.Demos.Converters.ConvertRect(_processingBox.Bounds.ToRectangle(_dpiX, _dpiY))) Then
            Return HitTestPosition.Inside
         Else
            Return HitTestPosition.Outside
         End If
      End Function

      Public Sub Resize(ByVal newCorner As Point, ByVal resizeOrigin As HitTestPosition)
         Dim left As Integer = 0
         Dim top As Integer = 0
         Dim width As Integer = 0
         Dim height As Integer = 0

         Select Case resizeOrigin
            Case HitTestPosition.LeftTop
               left = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left
               top = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top
               width = newCorner.X - left
               height = newCorner.Y - top

            Case HitTestPosition.RightTop
               left = newCorner.X
               top = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top
               width = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Right - left
               height = newCorner.Y - top

            Case HitTestPosition.LeftBottom
               left = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left
               top = newCorner.Y
               width = newCorner.X - left
               height = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Bottom - top

            Case HitTestPosition.RightBottom
               left = newCorner.X
               top = newCorner.Y
               width = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Right - left
               height = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Bottom - top

            Case HitTestPosition.LowerEdge
               left = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left
               top = newCorner.Y
               width = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Width
               height = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Bottom - top

            Case HitTestPosition.UpperEdge
               left = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left
               top = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top
               width = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Width
               height = newCorner.Y - top

            Case HitTestPosition.LeftEdge
               left = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left
               top = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top
               width = newCorner.X - _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left
               height = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Height

            Case HitTestPosition.RightEdge
               left = newCorner.X
               top = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top
               width = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Right - left
               height = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Height
         End Select

         _processingBox.Bounds = New LogicalRectangle(left, top, width, height, LogicalUnit.Pixel)
         _ProcessingBoxRect = Leadtools.Demos.Converters.ConvertRect(_processingBox.Bounds.ToRectangle(_dpiX, _dpiX))
         AdjustRectPoints()
      End Sub

      Public Sub Move(ByVal dx As Integer, ByVal dy As Integer)
         _processingBox.Bounds = New LogicalRectangle(_processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left + dx, _
                                                      _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top + dy, _
                                                      _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Width, _
                                                      _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Height, _
                                                      LogicalUnit.Pixel)
         _ProcessingBoxRect = Leadtools.Demos.Converters.ConvertRect(_processingBox.Bounds.ToRectangle(_dpiX, _dpiX))
         CreateHandles()
      End Sub

      Public Sub ChangeAlpha(ByVal alpha As Integer)
         Dim newAlpha As Integer = _brush.Color.A + alpha
         Dim brushColor As Color = _brush.Color
         _brush = New SolidBrush(Color.FromArgb(newAlpha, brushColor.R, brushColor.G, brushColor.B))
         _pen = New Pen(Color.FromArgb(newAlpha, _pen.Color.R, _pen.Color.G, _pen.Color.B))
      End Sub

      Private Sub CreateHandles()
         Dim leftTop As Point = New Point()
         Dim handleEdgeLength As Integer = 6
         Dim handleEdgeHalf As Integer = CInt(handleEdgeLength / 2)

         leftTop.X = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left - handleEdgeHalf
         leftTop.Y = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top - handleEdgeHalf
         _leftTopHandle = New Rectangle(leftTop.X, leftTop.Y, handleEdgeLength, handleEdgeLength)

         leftTop.X = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Right - handleEdgeHalf
         leftTop.Y = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top - handleEdgeHalf
         _rightTopHandle = New Rectangle(leftTop.X, leftTop.Y, handleEdgeLength, handleEdgeLength)

         leftTop.X = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left - handleEdgeHalf
         leftTop.Y = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Bottom - handleEdgeHalf
         _leftBottomHandle = New Rectangle(leftTop.X, leftTop.Y, handleEdgeLength, handleEdgeLength)

         leftTop.X = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Right - handleEdgeHalf
         leftTop.Y = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Bottom - handleEdgeHalf
         _rightBottomHandle = New Rectangle(leftTop.X, leftTop.Y, handleEdgeLength, handleEdgeLength)

         leftTop.X = CInt(_processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left + _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Width / 2) - handleEdgeHalf
         leftTop.Y = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top - handleEdgeHalf
         _upperHandle = New Rectangle(leftTop.X, leftTop.Y, handleEdgeLength, handleEdgeLength)

         leftTop.X = CInt(_processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left + _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Width / 2) - handleEdgeHalf
         leftTop.Y = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Bottom - handleEdgeHalf
         _lowerHandle = New Rectangle(leftTop.X, leftTop.Y, handleEdgeLength, handleEdgeLength)

         leftTop.X = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left - handleEdgeHalf
         leftTop.Y = CInt(_processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top + _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Height / 2) - handleEdgeHalf
         _leftHandle = New Rectangle(leftTop.X, leftTop.Y, handleEdgeLength, handleEdgeLength)

         leftTop.X = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Right - handleEdgeHalf
         leftTop.Y = CInt(_processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top + _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Height / 2) - handleEdgeHalf
         _rightHandle = New Rectangle(leftTop.X, leftTop.Y, handleEdgeLength, handleEdgeLength)

      End Sub

      Private Sub DrawHandles(ByVal graphics As Graphics, ByVal transformer As Transformer)
         Dim transformedRect As Rectangle = System.Drawing.Rectangle.Round(transformer.RectangleToPhysical(_leftTopHandle))
         graphics.DrawRectangle(Pens.Black, transformedRect)
         graphics.FillRectangle(Brushes.Black, transformedRect)

         transformedRect = System.Drawing.Rectangle.Round(transformer.RectangleToPhysical(_rightTopHandle))
         graphics.DrawRectangle(Pens.Black, transformedRect)
         graphics.FillRectangle(Brushes.Black, transformedRect)

         transformedRect = System.Drawing.Rectangle.Round(transformer.RectangleToPhysical(_leftBottomHandle))
         graphics.DrawRectangle(Pens.Black, transformedRect)
         graphics.FillRectangle(Brushes.Black, transformedRect)

         transformedRect = System.Drawing.Rectangle.Round(transformer.RectangleToPhysical(_rightBottomHandle))
         graphics.DrawRectangle(Pens.Black, transformedRect)
         graphics.FillRectangle(Brushes.Black, transformedRect)

         transformedRect = System.Drawing.Rectangle.Round(transformer.RectangleToPhysical(_upperHandle))
         graphics.DrawRectangle(Pens.Black, transformedRect)
         graphics.FillRectangle(Brushes.Black, transformedRect)

         transformedRect = System.Drawing.Rectangle.Round(transformer.RectangleToPhysical(_lowerHandle))
         graphics.DrawRectangle(Pens.Black, transformedRect)
         graphics.FillRectangle(Brushes.Black, transformedRect)

         transformedRect = System.Drawing.Rectangle.Round(transformer.RectangleToPhysical(_leftHandle))
         graphics.DrawRectangle(Pens.Black, transformedRect)
         graphics.FillRectangle(Brushes.Black, transformedRect)

         transformedRect = System.Drawing.Rectangle.Round(transformer.RectangleToPhysical(_rightHandle))
         graphics.DrawRectangle(Pens.Black, transformedRect)
         graphics.FillRectangle(Brushes.Black, transformedRect)
      End Sub

      Public Sub Draw(ByVal graphics As Graphics, ByVal transform As Matrix)
         Dim tranformer As Transformer = New Transformer(transform)
         Dim transformedRect As Rectangle = System.Drawing.Rectangle.Round(tranformer.RectangleToPhysical(Leadtools.Demos.Converters.ConvertRect(_processingBox.Bounds.ToRectangle(_dpiX, _dpiY))))
         graphics.DrawRectangle(_pen, transformedRect)
         graphics.FillRectangle(_brush, transformedRect)

         If _selected Then
            DrawHandles(graphics, tranformer)
         End If
      End Sub
   End Class
End Namespace
