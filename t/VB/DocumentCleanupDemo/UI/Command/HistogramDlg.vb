' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System

Imports Leadtools.ImageProcessing.Effects
Imports Leadtools
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.ImageProcessing.Core

Namespace DocumentCleanupDemo
   Partial Public Class HistogramDlg : Inherits Form
      Private _histValues As Long() = Nothing
      Private _rangesCount As Integer, _imageMinValue As Integer, _imageMaxValue As Integer, _median As Integer, _level As Integer, _clipping As Integer, _
       _oldClip As Integer
      Private _pixels As Long
      Private _value As Long()
      Private _graph As Graphics
      Private _mean As Double
      Private _isFirstLoad As Boolean
      Private _image As RasterImage
      Private _isGrayScale As Boolean
      Private _penColor As Color

      Public Sub New(image As RasterImage, isGray As Boolean)
         InitializeComponent()


         _value = New Long(499) {}
         _graph = _pnlHistogram.CreateGraphics()
         _isGrayScale = isGray

         If _isGrayScale Then
            Dim cmd As New MinMaxValuesCommand()
            cmd.Run(image)
            _imageMinValue = cmd.MinimumValue
            _imageMaxValue = cmd.MaximumValue
         End If

         _image = image
      End Sub

      Protected Overrides Sub OnPaint(e As PaintEventArgs)
         MyBase.OnPaint(e)
         _pnlHistogram.Refresh()
         DrawHistogram()
         _isFirstLoad = False
      End Sub

      Private Sub panel1_MouseMove(sender As Object, e As MouseEventArgs)
         Try
            Dim shift As Integer = CInt(_numRangeMin.Value)
            _level = _rangesCount * e.X + shift
            _lblLevel.Text = " Level = " & _level
            _lblCount.Text = " Count = " & _value(e.X)
            _lblPercentil.Text = " Percentil = " & Math.Round(getPercent() * 100, 2) & "%"
         Catch generatedExceptionName As Exception

         End Try
      End Sub

      Private Sub DrawHistogram()
         Try
            Dim max As Integer = Integer.Parse(_numRangeMax.Text)
            Dim min As Integer = Integer.Parse(_numRangeMin.Text) - _imageMinValue

            checkValues()
            _rangesCount = CInt(Math.Truncate(Math.Ceiling((max - Integer.Parse(_numRangeMin.Text)) / 500.0)))

            If _rangesCount = 0 Then
               _rangesCount += 1
            End If

            Using tempBmp As New Bitmap(_pnlHistogram.Width, _pnlHistogram.Height)
               Using tempG As Graphics = Graphics.FromImage(tempBmp)
                  Dim scale As Double = Math.Ceiling(arrayMax(_value) / 150.0)
                  If scale = 0 Then
                     scale += 1
                  End If

                  For i As Integer = 0 To 499
                     tempG.DrawLine(New Pen(_pnlHistogram.BackColor), i, _pnlHistogram.Height, i, _pnlHistogram.Height - CInt(Math.Truncate(_value(i) / scale * (_oldClip + 1))))
                  Next
                  _oldClip = _clipping

                  For i As Integer = 0 To 499
                     _value(i) = 0
                  Next

                  For i As Integer = 0 To 499
                     For j As Integer = 0 To _rangesCount - 1
                        _value(i) += If((((_rangesCount * i + j) + min) < _histValues.Length), _histValues((_rangesCount * i + j) + min), 0)
                     Next
                  Next

                  scale = Math.Ceiling(arrayMax(_value) / 150.0)
                  If scale = 0 Then
                     scale += 1
                  End If

                  For i As Integer = 0 To 499
                     tempG.DrawLine(New Pen(_penColor), i, _pnlHistogram.Height, i, _pnlHistogram.Height - CInt(Math.Truncate(_value(i) / scale * (_clipping + 1))))
                  Next

                  Dim srcRect As New Rectangle(0, 0, tempBmp.Width, tempBmp.Height)
                  _graph.DrawImage(tempBmp, 0, 0, srcRect, GraphicsUnit.Pixel)
               End Using
            End Using
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      End Sub

      Private Function arrayMax(arr As Long()) As Long
         Dim max As Long = arr(0)
         For i As Integer = 1 To arr.Length - 1
            If arr(i) > max Then
               max = arr(i)
            End If
         Next

         Return max
      End Function

      Private Sub _btnCancel_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
         Me.Close()
      End Sub

      Private Sub _btnDraw_Click(sender As Object, e As EventArgs) Handles _btnDraw.Click
         DrawHistogram()
      End Sub

      Private Sub checkValues()
         If Not _isFirstLoad Then
            If Integer.Parse(_numRangeMax.Text) < Integer.Parse(_numRangeMin.Text) Then
               Throw New Exception(" Error range : max value must be greater than min value ")
            End If

            If Integer.Parse(_numRangeMax.Text) > _imageMaxValue OrElse Integer.Parse(_numRangeMax.Text) < _imageMinValue Then
               Throw New Exception(" Error : max value must be less than or equal Max ")
            End If

            If Integer.Parse(_numRangeMin.Text) > _imageMaxValue OrElse Integer.Parse(_numRangeMin.Text) < _imageMinValue Then
               Throw New Exception(" Error : min value must be greater than or equal Min")
            End If
         End If
      End Sub

      Private Sub _txtRange_KeyPress(sender As Object, e As KeyPressEventArgs)
         If Not (Char.IsDigit(e.KeyChar) OrElse e.KeyChar = "-"c) Then
            e.Handled = True
         End If


      End Sub

      Private Function getPercent() As Double
         Dim sum As Single = 0
         Dim i As Integer
         Dim level As Integer = _level - _imageMinValue
         Try
            For i = 0 To level - 1
               If i >= _histValues.Length Then
                  Exit For
               End If
               sum += _histValues(i)
            Next
            Return sum / _pixels
         Catch generatedExceptionName As Exception

            Return 0
         End Try
      End Function

      Private Sub _numClipping_ValueChanged(sender As Object, e As EventArgs) Handles _numClipping.ValueChanged
         _clipping = CInt(_numClipping.Value)
         DrawHistogram()
      End Sub

      Private Sub HistogramDlg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
         Dim command As New StatisticsInformationCommand()
         Try
            command.Channel = RasterColorChannel.Master
            command.Start = 0
            command.[End] = 255
            command.Run(_image)

            If _isGrayScale Then
               _numRangeMin.Maximum = InlineAssignHelper(_numRangeMax.Maximum, _imageMaxValue)
               _numRangeMin.Minimum = InlineAssignHelper(_numRangeMax.Minimum, _imageMinValue)
            End If

            _penColor = Color.Black
            _pixels = _image.Width * _image.Height
            _mean = command.Mean
            _numRangeMin.Text = _imageMinValue.ToString()
            _numRangeMax.Text = _imageMaxValue.ToString()
            _median = command.Median

            _cmbChanel.SelectedIndex = 0

            Dim commandHist As New HistogramCommand()
            commandHist.Channel = HistogramCommandFlags.Master
            commandHist.Run(_image)
            Dim histogramValues As Long() = commandHist.Histogram

            If _isGrayScale Then
               Select Case _image.BitsPerPixel
                  Case 1, 8
                     _histValues = histogramValues
                     Exit Select
                  Case 16, 12
                     Dim size As Integer = CInt(Math.Truncate(Math.Ceiling(Math.Log(_imageMaxValue - _imageMinValue, 2))))
                     size = CInt(Math.Truncate(Math.Pow(2, size)))
                     If size = 0 Then
                        size += 1
                     End If
                     _histValues = New Long(size - 1) {}

                     Dim i As Integer = _imageMinValue, j As Integer = 0
                     While i <= _imageMaxValue
                        Dim x As Integer = If((i < 0), histogramValues.Length + i, i)
                        _histValues(j) = histogramValues(x)
                        i += 1
                        j += 1
                     End While
                     Exit Select
               End Select
               _cmbChanel.Enabled = False
            Else
               _gbGrayScaleRange.Enabled = False
               _histValues = histogramValues
               _lblMax.Enabled = InlineAssignHelper(_lblMin.Enabled, False)
            End If

            _lblLevel.Text = " Level = " & _level
            _lblCount.Text = " Count = " & 0
            _lblMax.Text = " Max = " & _imageMaxValue
            _lblMin.Text = " Min = " & _imageMinValue
            _lblToltalPixels.Text = " Total Pixels = " & _pixels
            _lblMean.Text = " Mean = " & Math.Round(_mean, 2)
            _lblMedian.Text = " Median = " & _median
            _lblPercentil.Text = " Percentil = " & 0 & "%"
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      End Sub

      Private Sub _cmbChanel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _cmbChanel.SelectedIndexChanged
         Dim commandHist As New HistogramCommand()
         Select Case _cmbChanel.SelectedIndex
            Case 0
               commandHist.Channel = HistogramCommandFlags.Master
               _penColor = Color.Black
               Exit Select
            Case 1
               commandHist.Channel = HistogramCommandFlags.Red
               _penColor = Color.Red
               Exit Select
            Case 2
               commandHist.Channel = HistogramCommandFlags.Green
               _penColor = Color.Green
               Exit Select
            Case 3
               commandHist.Channel = HistogramCommandFlags.Blue
               _penColor = Color.Blue
               Exit Select
         End Select
         commandHist.Run(_image)
         _histValues = commandHist.Histogram
         DrawHistogram()
      End Sub
      Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
         target = value
         Return value
      End Function
   End Class
End Namespace
