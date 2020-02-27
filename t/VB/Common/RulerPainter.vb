' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

''' <summary>
''' Ruler unit
''' </summary>
Public Enum RulerPainterUnit
   ''' <summary>
   ''' Inches
   ''' </summary>
   Inch

   ''' <summary>
   ''' Millimeters
   ''' </summary>
   Millimeter
End Enum

''' <summary>
''' Ruler orientation
''' </summary>
Public Enum RulerPainterOrientation
   Horizontal
   Vertical
End Enum

''' <summary>
''' Ruler alignment
''' </summary>
Public Enum RulerPainterAlignment
   Bottom
   Top
End Enum

''' <summary>
''' Ruler style
''' </summary>
Public Enum RulerPainterStyle
   Middle
   Edge
End Enum

''' <summary>
''' Paints a ruler to a destination rectangle
''' </summary>
Public Class RulerPainter
#Region "Properties"

   Private _backColor As Color = Color.White

   ''' <summary>
   ''' Back color, used for the background of in range ruler and edge of pad area
   ''' </summary>
   Public Property BackColor() As Color
      Get
         Return _backColor
      End Get
      Set(ByVal value As Color)
         _backColor = value
      End Set
   End Property

   Private _padColor As Color = Color.LightGray

   ''' <summary>
   ''' Pad color, used for the background of out of range ruler and edge of in range area
   ''' </summary>
   Public Property PadColor() As Color
      Get
         Return _padColor
      End Get
      Set(ByVal value As Color)
         _padColor = value
      End Set
   End Property

   Private _foreColor As Color = Color.Black

   ''' <summary>
   ''' Fore color, used for ticks and text
   ''' </summary>
   Public Property ForeColor() As Color
      Get
         Return _foreColor
      End Get
      Set(ByVal value As Color)
         _foreColor = value
      End Set
   End Property

   Private _fontFamilyName As String = "Times New Roman"

   ''' <summary>
   ''' Font family name
   ''' </summary>
   Public Property FontFamilyName() As String
      Get
         Return _fontFamilyName
      End Get
      Set(ByVal value As String)
         _fontFamilyName = value
      End Set
   End Property

   Private _fontPointSize As Single = 8.5F

   ''' <summary>
   ''' Font point size
   ''' </summary>
   Public Property FontPointSize() As Single
      Get
         Return _fontPointSize
      End Get
      Set(ByVal value As Single)
         _fontPointSize = value
      End Set
   End Property

   Private _fontStyle As FontStyle = FontStyle.Regular

   ''' <summary>
   ''' Font style
   ''' </summary>
   Public Property FontStyle() As FontStyle
      Get
         Return _fontStyle
      End Get
      Set(ByVal value As FontStyle)
         _fontStyle = value
      End Set
   End Property

   Private _orientation As RulerPainterOrientation = RulerPainterOrientation.Horizontal

   ''' <summary>
   ''' Ruler orientation (horizontal or vertical)
   ''' </summary>
   Public Property Orientation() As RulerPainterOrientation
      Get
         Return _orientation
      End Get
      Set(ByVal value As RulerPainterOrientation)
         _orientation = value
      End Set
   End Property

   Private _alignment As RulerPainterAlignment = RulerPainterAlignment.Bottom

   ''' <summary>
   ''' Ruler alignment (top or bottom)
   ''' </summary>
   Public Property Alignment() As RulerPainterAlignment
      Get
         Return _alignment
      End Get
      Set(ByVal value As RulerPainterAlignment)
         _alignment = value
      End Set
   End Property

   Private _style As RulerPainterStyle = RulerPainterStyle.Middle

   ''' <summary>
   ''' Ruler style (middle or edge)
   ''' </summary>
   Public Property Style() As RulerPainterStyle
      Get
         Return _style
      End Get
      Set(ByVal value As RulerPainterStyle)
         _style = value
      End Set
   End Property

   Private _unit As RulerPainterUnit = RulerPainterUnit.Inch

   ''' <summary>
   ''' Ruler units (inches, centimeters)
   ''' </summary>
   Public Property Unit() As RulerPainterUnit
      Get
         Return _unit
      End Get
      Set(ByVal value As RulerPainterUnit)
         If value <> _unit Then
            _unit = value

            ' Change the length to be in the new units
            Dim newLength As Double

            If _unit = RulerPainterUnit.Inch Then
               ' Old units were in millimeters, convert them to inches
               newLength = _length / _mmRatio
            Else
               ' Old units were in inches, convert them to millimeters
               newLength = _length * _mmRatio
            End If

            Length = newLength
         End If
      End Set
   End Property

   Private _length As Double = 8.5

   ''' <summary>
   ''' Ruler length in current units
   ''' </summary>
   Public Property Length() As Double
      Get
         Return _length
      End Get
      Set(ByVal value As Double)
         If value < 0 Then Throw New ArgumentException("Must be a value greater to or equal to 0", "Length")

         _length = value
      End Set
   End Property

   Private _originPixelOffset As Integer = 0

   ''' <summary>
   ''' Ruler pixel origin (The number of pixels where the 0 in the ruler is)
   ''' </summary>
   Public Property OriginPixelOffset() As Integer
      Get
         Return _originPixelOffset
      End Get
      Set(ByVal value As Integer)
         _originPixelOffset = value
      End Set
   End Property

   Private _resolution As Single = 0

   ''' <summary>
   ''' Ruler resolution. 0 for current screen resolution
   ''' </summary>
   Public Property Resolution() As Single
      Get
         Return _resolution
      End Get
      Set(ByVal value As Single)
         If value < 0 Then Throw New ArgumentException("Must be a value greater than or equal to 0", "Resolution")

         _resolution = value
      End Set
   End Property

   Private _scaleFactor As Double = 1

   ''' <summary>
   ''' Ruler scale factor (zooming)
   ''' </summary>
   Public Property ScaleFactor() As Double
      Get
         Return _scaleFactor
      End Get
      Set(ByVal value As Double)
         If value < 0 Then Throw New ArgumentException("Must be a value greater than or equal to 0", "ScaleFactor")

         _scaleFactor = value
      End Set
   End Property
#End Region

#Region "Painting"
   Private Const _mmRatio As Double = 25.400000025908

   ' Current dpi
   Private _dpi As Double

   ' Current convert to/from pixels factor
   Private _toPixelsFactor As Double = 1.0

   ' Convert from pixels to units
   Private Function ConvertFromPixels(ByVal value As Double) As Double
      Return value / _toPixelsFactor
   End Function

   ' Convert from units to pixels
   Private Function ConvertToPixels(ByVal value As Double) As Double
      Return value * _toPixelsFactor
   End Function

   Public Sub Paint(ByVal g As Graphics, ByVal bounds As Rectangle)
      Dim gstate As GraphicsState = g.Save()
      Try
         ' Smooth text painting
         g.SmoothingMode = SmoothingMode.AntiAlias

         ' Get the current DPIs
         _dpi = If(_orientation = RulerPainterOrientation.Horizontal, g.DpiX, g.DpiY)
         Dim actualResolution As Single = If(_resolution <> 0, _resolution, _dpi)

         ' Calculate the conversion factor
         _toPixelsFactor = _scaleFactor * actualResolution
         If _unit = RulerPainterUnit.Millimeter Then
            _toPixelsFactor /= _mmRatio
         End If

         ' Calculate the padding, how many units we need to pad the length from left and right (or top and bottom in vertical rulers)
         ' 1 inch or 10 mm (1 cm)
         Dim extraPad As Integer = If(_unit = RulerPainterUnit.Inch, 1, 10)

         Dim padBefore As Integer = CType(ConvertFromPixels(_originPixelOffset) + extraPad, Integer)
         Dim boundsLength As Integer = If(_orientation = RulerPainterOrientation.Horizontal, bounds.Width, bounds.Height)
         Dim padAfter As Integer = CType(ConvertFromPixels(boundsLength - _originPixelOffset - ConvertToPixels(_length)) + extraPad, Integer)

         ' If this is mm, the pads needs to be a multiple of 10
         If _unit = RulerPainterUnit.Millimeter Then
            If (CType(padBefore, Double) / 10.0) <> (CType(padBefore, Integer) / 10) Then
               padBefore = (CType(padBefore / 10, Integer) + 1) * 10
            End If

            If (CType(padAfter, Double) / 10.0) <> (CType(padAfter, Integer) / 10) Then
               padAfter = (CType(padAfter / 10, Integer) + 1) * 10
            End If
         End If

         ' Set the clip region
         g.SetClip(bounds)

         ' Fill the pads background
         FillPads(g, bounds, padAfter)

         ' Draw the ruler
         DrawRuler(g, bounds, padBefore, padAfter)
      Finally
         g.Restore(gstate)
      End Try
   End Sub

   <Flags()> _
   Private Enum FillAndStrokeSides
      None = 0
      Left = 1 << 0
      Top = 1 << 1
      Right = 1 << 2
      Bottom = 1 << 3
   End Enum

   Private Shared Sub FillAndStrokeRectangle(ByVal g As Graphics, ByVal pen As Pen, ByVal brush As Brush, ByVal rc As RectangleF, ByVal sides As FillAndStrokeSides)
      g.FillRectangle(brush, rc)

      If (sides And FillAndStrokeSides.Left) = FillAndStrokeSides.Left Then
         g.DrawLine(pen, rc.X, rc.Y, rc.X, rc.Bottom - 1)
      End If

      If (sides And FillAndStrokeSides.Top) = FillAndStrokeSides.Top Then
         g.DrawLine(pen, rc.X, rc.Y, rc.Right - 1, rc.Y)
      End If

      If (sides And FillAndStrokeSides.Right) = FillAndStrokeSides.Right Then
         g.DrawLine(pen, rc.Right, rc.Y, rc.Right, rc.Bottom - 1)
      End If

      If (sides And FillAndStrokeSides.Bottom) = FillAndStrokeSides.Bottom Then
         g.DrawLine(pen, rc.X, rc.Bottom, rc.Right - 1, rc.Bottom)
      End If
   End Sub

   Private Sub FillPads(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal padAfter As Integer)
      Dim boundsStart As Double = If(_orientation = RulerPainterOrientation.Horizontal, bounds.X, bounds.Y)
      Dim rulerStart As Double = boundsStart + _originPixelOffset
      Dim rulerStop As Double = rulerStart + ConvertToPixels(_length)

      Dim rc As RectangleF
      Dim sides As FillAndStrokeSides

      ' Everything before padBefore and after padAfter needs to be filled with pad color
      Using brush As New SolidBrush(PadColor)
         Using pen As New Pen(BackColor)
            If _orientation = RulerPainterOrientation.Horizontal Then
               rc = RectangleF.FromLTRB( _
               CType(boundsStart, Single), _
               CType(bounds.Y, Single), _
               CType(rulerStart, Single), _
               CType(bounds.Bottom - 1, Single))

               sides = FillAndStrokeSides.Left Or FillAndStrokeSides.Top Or FillAndStrokeSides.Bottom
            Else
               rc = RectangleF.FromLTRB( _
                  CType(bounds.X, Single), _
                  CType(boundsStart, Single), _
                  CType(bounds.Right, Single) - 1, _
                  CType(rulerStart, Single))

               sides = FillAndStrokeSides.Left Or FillAndStrokeSides.Top Or FillAndStrokeSides.Right
            End If

            FillAndStrokeRectangle(g, pen, brush, rc, sides)

            If _orientation = RulerPainterOrientation.Horizontal Then
               rc = RectangleF.FromLTRB( _
                  CType(rulerStop, Single), _
                  rc.Y, _
                  Math.Min(CType(ConvertToPixels(padAfter) + rulerStop, Single), bounds.Right - 1), _
                  rc.Bottom)

               sides = FillAndStrokeSides.Right Or FillAndStrokeSides.Top Or FillAndStrokeSides.Bottom
            Else
               rc = RectangleF.FromLTRB( _
                  rc.X, _
                  CType(rulerStop, Single), _
                  rc.Right, _
                  Math.Min(CType(ConvertToPixels(padAfter) + rulerStop, Single), bounds.Bottom - 1))

               sides = FillAndStrokeSides.Left Or FillAndStrokeSides.Bottom Or FillAndStrokeSides.Right
            End If

            FillAndStrokeRectangle(g, pen, brush, rc, sides)
         End Using
      End Using

      ' Everything in between needs to be filled with back color
      Using brush As New SolidBrush(BackColor)
         Using pen As New Pen(PadColor)
            If _orientation = RulerPainterOrientation.Horizontal Then
               rc = RectangleF.FromLTRB( _
               CType(rulerStart, Single) - 1, _
               CType(bounds.Y, Single), _
               CType(rulerStop, Single) + 1, _
               CType(bounds.Bottom, Single) - 1)
               sides = FillAndStrokeSides.Top Or FillAndStrokeSides.Bottom
            Else
               rc = RectangleF.FromLTRB( _
               CType(bounds.X, Single), _
               CType(rulerStart, Single) - 1, _
               CType(bounds.Right, Single) - 1, _
               CType(rulerStop, Single) + 1)
               sides = FillAndStrokeSides.Left Or FillAndStrokeSides.Right
            End If

            FillAndStrokeRectangle(g, pen, brush, rc, sides)
         End Using
      End Using
   End Sub

   Private Sub DrawRuler(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal padBefore As Integer, ByVal padAfter As Integer)
      ' The minimum distance between tick marks, otherwise, hide close ticks
      Dim minimumTickDistance As Double = ConvertFromPixels(2.0)

      'Find the full, large and small tick increments
      Dim fullIncrement As Double
      Dim largeIncrement As Double
      Dim smallIncrement As Double

      If _unit = RulerPainterUnit.Inch Then
         ' Ticks at 1, 1/2 and 1/4 of an inch
         fullIncrement = 1
         largeIncrement = 0.5
         smallIncrement = 0.25
      Else
         ' Ticks at 1cm, 5mm and 1mm
         fullIncrement = 10
         largeIncrement = 5
         smallIncrement = 1
      End If

      ' Find the tick increment to use based on the unit and current scale

      ' Use smallest increment
      Dim tickIncrement As Double = smallIncrement
      If tickIncrement < minimumTickDistance Then
         ' Too small, use next
         tickIncrement = largeIncrement
         If tickIncrement < minimumTickDistance Then
            ' Too small, use next
            tickIncrement = fullIncrement
            If tickIncrement < minimumTickDistance Then
               ' Too small, we need to keep going till we run at ouf length
               While tickIncrement < minimumTickDistance AndAlso tickIncrement < _length
                  tickIncrement *= 2
               End While
            End If
         End If
      End If

      Using font As New Font(_fontFamilyName, _fontPointSize, _fontStyle, GraphicsUnit.Point)
         Using sf As New StringFormat()
            Using pen As New Pen(ForeColor)
               Using textBrush As New SolidBrush(ForeColor)
                  sf.Alignment = StringAlignment.Center
                  sf.LineAlignment = StringAlignment.Center

                  If _orientation = RulerPainterOrientation.Vertical Then
                     sf.FormatFlags = sf.FormatFlags Or StringFormatFlags.DirectionVertical
                  End If

                  ' Draw the ruler ticks
                  DrawRulerTicks(g, bounds, font, pen, textBrush, sf, padBefore, padAfter, tickIncrement, largeIncrement, fullIncrement)
               End Using
            End Using
         End Using
      End Using
   End Sub

   Private Sub DrawRulerTicks(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal font As Font, ByVal pen As Pen, ByVal textBrush As Brush, ByVal sf As StringFormat, ByVal padBefore As Double, ByVal padAfter As Double, ByVal tickIncrement As Double, ByVal largeIncrement As Double, ByVal fullIncrement As Double)
      ' The 0,0 origin of the ruler
      Dim xOrigin As Double = bounds.X
      Dim yOrigin As Double = bounds.Y
      Dim tickOrigin As Double
      Dim tickPosition As Double

      If _orientation = RulerPainterOrientation.Horizontal Then
         xOrigin = xOrigin + _originPixelOffset
         tickOrigin = xOrigin
         tickPosition = yOrigin
      Else
         yOrigin = yOrigin + _originPixelOffset
         tickOrigin = yOrigin
         tickPosition = xOrigin
      End If

      Dim textSize As SizeF = g.MeasureString("WW", font, PointF.Empty, sf)
      Dim textHeight As Double = If(_orientation = RulerPainterOrientation.Horizontal, textSize.Height, textSize.Width)

      ' Calculate the lengths of the tick marks
      Dim fullTickLength As Double = If(_orientation = RulerPainterOrientation.Horizontal, bounds.Height, bounds.Width)
      Dim largeTickLength As Double = fullTickLength * 0.25
      Dim smallTickLength As Double = fullTickLength * 0.15

      Dim fullTickStart As Double
      Dim fullTickStop As Double
      Dim largeTickStart As Double
      Dim largeTickStop As Double
      Dim smallTickStart As Double
      Dim smallTickStop As Double
      Dim legendStart As Double
      Dim centerLegend As Boolean

      If _style = RulerPainterStyle.Middle Then
         If _alignment = RulerPainterAlignment.Bottom Then
            fullTickStart = tickPosition + (fullTickLength - smallTickLength)
            fullTickStop = tickPosition + fullTickLength
         Else
            fullTickStart = tickPosition
            fullTickStop = tickPosition + smallTickLength
         End If

         largeTickStart = tickPosition + (fullTickLength - largeTickLength) / 2.0
         largeTickStop = largeTickStart + largeTickLength
         smallTickStart = tickPosition + (fullTickLength - smallTickLength) / 2.0
         smallTickStop = smallTickStart + smallTickLength

         ' Calculate the location of the tick lenegds
         legendStart = tickPosition + (fullTickLength - textHeight) / 2.0
         centerLegend = True
      Else
         fullTickStart = tickPosition
         fullTickStop = tickPosition + fullTickLength

         If _alignment = RulerPainterAlignment.Bottom Then
            largeTickStart = tickPosition + fullTickLength
            largeTickStop = largeTickStart - largeTickLength
            smallTickStart = tickPosition + fullTickLength
            smallTickStop = smallTickStart - smallTickLength

            legendStart = tickPosition
         Else
            largeTickStart = tickPosition
            largeTickStop = largeTickStart + largeTickLength
            smallTickStart = tickPosition
            smallTickStop = smallTickStart + smallTickLength

            legendStart = tickPosition + (fullTickLength - textHeight)
         End If

         centerLegend = False
      End If

      ' Calculate the minimum distance between subsequent tick legends
      Dim lastLegendStop As Double = Double.MinValue

      ' For double calculations round-up errors
      Const delta As Double = 0.0001

      ' Size of the full increment in pixels
      Dim fullIncrementPixels As Double = ConvertToPixels(fullIncrement)

      ' Calculate the tick scale
      ' For mm, we need to scale everything by 10, since we will base our painting on centimeters and not mm
      Dim tickScale As Double = If(_unit = RulerPainterUnit.Inch, 1, 10)

      fullIncrement = fullIncrement / tickScale
      largeIncrement = largeIncrement / tickScale

      ' Draw the full length plus the pads
      Dim tick As Double = -padBefore
      Do While tickIncrement < _length AndAlso tick <= (_length + padAfter)
         ' This is where the tick should go
         Dim tickPixels As Double = tickOrigin + ConvertToPixels(tick)

         ' Compensate for double rounding errors
         Dim tickToCheck As Double

         If tick < 0 Then
            tickToCheck = CType((tick / tickScale - delta) * 1000, Integer) / 1000.0
         Else
            tickToCheck = CType((tick / tickScale + delta) * 1000, Integer) / 1000.0
         End If

         ' Find out the tick length (full, large or small)
         Dim tickStart As Double = 0
         Dim tickStop As Double = 0

         If (tickToCheck * fullIncrement) = CType(tickToCheck * fullIncrement, Integer) Then
            tickStart = fullTickStart
            tickStop = fullTickStop

            ' Only draw the legengds if we are inside the ruler length
            If (tick >= 0) AndAlso (tick <= _length) Then
               ' Here we need to draw the tick lengend
               Dim legendText As String = CType(tickToCheck, Integer).ToString()
               Dim legendTextSize As SizeF = g.MeasureString(legendText, font, PointF.Empty, sf)

               Dim legendShift As Double = 0

               If centerLegend Then
                  If _orientation = RulerPainterOrientation.Horizontal Then
                     legendShift = legendTextSize.Width / 2.0F
                  Else
                     legendShift = legendTextSize.Height / 2.0F
                  End If
               End If

               Dim legendRect As RectangleF
               Dim currentLegendStart As Double
               Dim currentLegendStop As Double

               If _orientation = RulerPainterOrientation.Horizontal Then
                  legendRect = New RectangleF( _
                     CType(tickPixels - legendShift, Single), _
                     CType(legendStart, Single), _
                     legendTextSize.Width, _
                     legendTextSize.Height)

                  currentLegendStart = legendRect.X
                  currentLegendStop = legendRect.Right
               Else
                  legendRect = New RectangleF( _
                     CType(legendStart - legendShift / 2, Single), _
                     CType(tickPixels - legendShift, Single), _
                     legendTextSize.Width, _
                     legendTextSize.Height)

                  currentLegendStart = legendRect.Y
                  currentLegendStop = legendRect.Bottom
               End If

               ' First, check if we dont overlap the previous legend
               If currentLegendStart > lastLegendStop Then
                  g.DrawString(legendText, font, textBrush, legendRect, sf)
                  lastLegendStop = currentLegendStop
               End If
            End If
         ElseIf (tickToCheck / largeIncrement) = CType(tickToCheck / largeIncrement, Integer) Then
            tickStart = largeTickStart
            tickStop = largeTickStop
         Else
            tickStart = smallTickStart
            tickStop = smallTickStop
         End If

         ' Draw the tick
         If _orientation = RulerPainterOrientation.Horizontal Then
            g.DrawLine( _
               pen, _
               CType(tickPixels, Single), _
               CType(tickStart, Single), _
               CType(tickPixels, Single), _
               CType(tickStop, Single))
         Else
            g.DrawLine( _
               pen, _
               CType(tickStart, Single), _
               CType(tickPixels, Single), _
               CType(tickStop, Single), _
               CType(tickPixels, Single))
         End If

         tick = tick + tickIncrement
      Loop
   End Sub
#End Region
End Class
