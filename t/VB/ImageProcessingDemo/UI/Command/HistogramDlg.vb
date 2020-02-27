' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.ImageProcessing.Effects
Imports Leadtools
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.ImageProcessing.Core

Namespace ImageProcessingDemo
      Partial Public Class HistogramDlg : Inherits Form
         Private _histValues As Long() = Nothing
         Private _rangesCount, _imageMinValue, _imageMaxValue, _median, _level, _clipping, _oldClip As Integer
         Private _pixels As Long
         Private _value As Long()
         Private _graph As Graphics
         Private _mean As Double
         Private _isFirstLoad As Boolean
         Private _image As RasterImage
         Private _isGrayScale As Boolean
         Private _penColor As Color

         Public Sub New(ByVal image As RasterImage, ByVal isGray As Boolean)
            InitializeComponent()

            _value = New Long(499) {}
            _graph = _pnlHistogram.CreateGraphics()
            _isGrayScale = isGray

            If _isGrayScale Then
               Dim cmd As MinMaxValuesCommand = New MinMaxValuesCommand()
               cmd.Run(image)
               _imageMinValue = cmd.MinimumValue
               _imageMaxValue = cmd.MaximumValue
            End If
            _image = image

         End Sub

         Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)
            _pnlHistogram.Refresh()
            DrawHistogram()
            _isFirstLoad = False
         End Sub

         Private Sub panel1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _pnlHistogram.MouseMove
            Try
               Dim shift As Integer = CInt(_numRangeMin.Value)
               _level = _rangesCount * e.X + shift
               _lblLevel.Text = " Level = " & _level
               _lblCount.Text = " Count = " & _value(e.X)
               _lblPercentil.Text = " Percentil = " & Math.Round(getPercent() * 100, 2) & "%"
         Catch e1 As Exception
         End Try
         End Sub

         Private Sub numericUpDown1_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            DrawHistogram()
         End Sub

         Private Sub DrawHistogram()
            Try
               Dim max As Integer = Integer.Parse(_numRangeMax.Text)
               Dim min As Integer = Integer.Parse(_numRangeMin.Text) - _imageMinValue

            checkValues()
               _rangesCount = CInt(Math.Ceiling((max - Integer.Parse(_numRangeMin.Text)) / 500.0))

               If _rangesCount = 0 Then
                  _rangesCount += 1
               End If

               Using tempBmp As Bitmap = New Bitmap(_pnlHistogram.Width, _pnlHistogram.Height)
                  Using tempG As Graphics = Graphics.FromImage(tempBmp)
                     Dim scale As Double = Math.Ceiling(arrayMax(_value) / 150.0)
                     If scale = 0 Then
                        scale += 1
                     End If

                     For i As Integer = 0 To 499
                        tempG.DrawLine(New Pen(_pnlHistogram.BackColor), i, _pnlHistogram.Height, i, _pnlHistogram.Height - CInt(_value(i) / scale * (_oldClip + 1)))
                     Next i
                     _oldClip = _clipping

                     For i As Integer = 0 To 499
                        _value(i) = 0
                     Next i

                     For i As Integer = 0 To 499
                        Dim j As Integer = 0
                        Do While j < _rangesCount
                           If (((_rangesCount * i + j) + min) < _histValues.Length) Then
                              _value(i) += _histValues((_rangesCount * i + j) + min)
                           Else
                              _value(i) += 0
                           End If
                           j += 1
                        Loop
                     Next i

                     scale = Math.Ceiling(arrayMax(_value) / 150.0)
                     If scale = 0 Then
                        scale += 1
                     End If

                     For i As Integer = 0 To 499
                        tempG.DrawLine(New Pen(_penColor), i, _pnlHistogram.Height, i, _pnlHistogram.Height - CInt(_value(i) / scale * (_clipping + 1)))
                     Next i

                     Dim srcRect As Rectangle = New Rectangle(0, 0, tempBmp.Width, tempBmp.Height)
                     _graph.DrawImage(tempBmp, 0, 0, srcRect, GraphicsUnit.Pixel)
                  End Using
               End Using
            Catch ex As Exception
               MessageBox.Show(ex.Message)
            End Try
         End Sub

         Private Function arrayMax(ByVal arr As Long()) As Long
            Dim max As Long = arr(0)
            For i As Integer = 1 To arr.Length - 1
               If arr(i) > max Then
                  max = arr(i)
               End If
            Next i

            Return max
         End Function

         Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
            Me.Close()
         End Sub

         Private Sub _btnDraw_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnDraw.Click
            DrawHistogram()
         End Sub

         Private Sub checkValues()
            If (Not _isFirstLoad) Then
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

         Private Sub _txtRange_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
            If Not (Char.IsDigit(e.KeyChar) OrElse e.KeyChar = "-"c) Then
               e.Handled = True
            End If

         End Sub

         Private Function getPercent() As Double
            Dim sum As Single = 0
            Dim i As Integer
            Dim level As Integer = _level - _imageMinValue
            Try
               i = 0
               Do While i < level
                  If i >= _histValues.Length Then
                     Exit Do
                  End If
                  sum += _histValues(i)
                  i += 1
               Loop
               Return sum / _pixels
         Catch e1 As Exception
            Return 0
            End Try
         End Function

         Private Sub _numClipping_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numClipping.ValueChanged
            _clipping = CInt(_numClipping.Value)
            DrawHistogram()
         End Sub

         Private Sub HistogramDlg_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim command As StatisticsInformationCommand = New StatisticsInformationCommand()
            Try
               command.Channel = RasterColorChannel.Master
               command.Start = 0
               command.End = 255
               command.Run(_image)

               If _isGrayScale Then
                  _numRangeMin.Maximum = _imageMaxValue
                  _numRangeMax.Maximum = _imageMaxValue
                  _numRangeMin.Minimum = _imageMinValue
                  _numRangeMax.Minimum = _imageMinValue
               End If

               _penColor = Color.Black
               _pixels = _image.Width * _image.Height
               _mean = command.Mean
               _numRangeMin.Text = _imageMinValue.ToString()
               _numRangeMax.Text = _imageMaxValue.ToString()
               _median = command.Median

               _cmbChanel.SelectedIndex = 0

               Dim commandHist As HistogramCommand = New HistogramCommand()
               commandHist.Channel = HistogramCommandFlags.Master
               commandHist.Run(_image)
               Dim histogramValues As Long() = commandHist.Histogram

               If _isGrayScale Then
                  Select Case _image.BitsPerPixel
                     Case 1, 8
                        _histValues = histogramValues
                     Case 16, 12
                        Dim size As Integer = CInt(Math.Ceiling(Math.Log(_imageMaxValue - _imageMinValue, 2)))
                        size = CInt(Math.Pow(2, size))
                        If size = 0 Then
                           size += 1
                        End If
                        _histValues = New Long(size - 1) {}

                        Dim i As Integer = _imageMinValue
                        Dim j As Integer = 0
                        Do While i <= _imageMaxValue
                           Dim x As Integer
                           If (i < 0) Then
                              x = histogramValues.Length + i
                           Else
                              x = i
                           End If
                           _histValues(j) = histogramValues(x)
                           i += 1
                           j += 1
                        Loop
                  End Select
                  _cmbChanel.Enabled = False
               Else
                  _gbGrayScaleRange.Enabled = False
                  _histValues = histogramValues
               _lblMax.Enabled = _lblMin.Enabled = False
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

         Private Sub _cmbChanel_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbChanel.SelectedIndexChanged
            Dim commandHist As HistogramCommand = New HistogramCommand()
            Select Case _cmbChanel.SelectedIndex
               Case 0
                  commandHist.Channel = HistogramCommandFlags.Master
                  _penColor = Color.Black
               Case 1
                  commandHist.Channel = HistogramCommandFlags.Red
                  _penColor = Color.Red
               Case 2
                  commandHist.Channel = HistogramCommandFlags.Green
                  _penColor = Color.Green
               Case 3
                  commandHist.Channel = HistogramCommandFlags.Blue
                  _penColor = Color.Blue
            End Select
            commandHist.Run(_image)
            _histValues = commandHist.Histogram
            DrawHistogram()
         End Sub
      End Class
End Namespace
