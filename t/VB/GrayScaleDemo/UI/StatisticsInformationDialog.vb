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

Imports Leadtools.ImageProcessing.Effects
Imports Leadtools
Imports GrayScaleDemo.Leadtools.Demos
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Core
Imports System

Partial Public Class ImageInformationDialog
   Inherits Form
   Private _image As RasterImage

   Public Sub New(image As RasterImage)
      InitializeComponent()
      _image = image
   End Sub

   Private Sub StatisticsInformationDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      For i As Integer = 0 To _lvInfo.Items.Count - 1
         _lvInfo.Items(i).SubItems.Add(String.Empty)
      Next

      UpdateControls()
   End Sub

   Private Sub _btnPageLast_Click(sender As Object, e As EventArgs) Handles _btnPageLast.Click
      _image.Page = _image.PageCount
      UpdateControls()
   End Sub

   Private Sub _btnPageFirst_Click(sender As Object, e As EventArgs) Handles _btnPageFirst.Click
      _image.Page = 1
      UpdateControls()
   End Sub

   Private Sub _btnPageNext_Click(sender As Object, e As EventArgs) Handles _btnPageNext.Click
      _image.Page += 1
      UpdateControls()
   End Sub

   Private Sub _btnPagePrevious_Click(sender As Object, e As EventArgs) Handles _btnPagePrevious.Click
      _image.Page -= 1
      UpdateControls()
   End Sub

   Private Sub UpdateControls()
      Try
         _lblPage.Text = String.Format("Page {0}:{1}", _image.Page, _image.PageCount)
         _btnPageFirst.Enabled = _image.Page > 1
         _btnPagePrevious.Enabled = _image.Page > 1
         _btnPageNext.Enabled = _image.Page < _image.PageCount
         _btnPageLast.Enabled = _image.Page < _image.PageCount

         Dim index As Integer = 0
         _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = _image.OriginalFormat.ToString()
         _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = String.Format("{0} x {1} pixels", _image.Width, _image.Height)
         _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = String.Format("{0} x {1} dpi", _image.XResolution, _image.YResolution)
         _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = _image.BitsPerPixel.ToString()
         _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = _image.BytesPerLine.ToString()
         _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = _image.DataSize.ToString()
         _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = Constants.GetNameFromValue(GetType(RasterViewPerspective), _image.ViewPerspective)
         _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = Constants.GetNameFromValue(GetType(RasterByteOrder), _image.Order)
         _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = If(_image.HasRegion, "Yes", "No")
         If _image.IsCompressed Then
            _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = "Run Length Limited (RLE)"
         Else
            _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = "Not compressed"
         End If

         If _image.IsDiskMemory Then
            _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = "Disk"
         ElseIf _image.IsTiled Then
            _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = "Tiled"
         ElseIf _image.IsConventionalMemory Then
            _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = "Managed memory"
         Else
            _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = "Unmanaged memory"
         End If

         _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = If(_image.Signed, "Yes", "No")
         _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = Constants.GetNameFromValue(GetType(RasterGrayscaleMode), _image.GrayscaleMode)

         _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = _image.LowBit.ToString()
         _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = _image.HighBit.ToString()


         Dim useLookup As Boolean = _image.UseLookupTable
         _image.UseLookupTable = False

         Dim MinValue As Integer = 0
         Dim MaxClrVal As Integer

         If _image.UseLookupTable = True Then
            MinValue = 0
            MaxClrVal = 255
         Else
            Dim HighBit As Integer = If((_image.HighBit > 0), _image.HighBit, (_image.BitsPerPixel - 1))
            Dim LowBit As Integer = If((_image.LowBit < 0), 0, _image.LowBit)
            If _image.Order = RasterByteOrder.Gray OrElse _image.BitsPerPixel >= 48 Then
               If _image.BitsPerPixel = 16 OrElse _image.BitsPerPixel = 12 Then
                  MaxClrVal = (1 << ((HighBit - LowBit) + 1)) - 1
               Else
                  MaxClrVal = &HFFFF

               End If
            Else
               MaxClrVal = &HFF
            End If
         End If

         Dim command As New StatisticsInformationCommand()

         command.Channel = RasterColorChannel.Master
         command.Start = MinValue
         command.[End] = MaxClrVal
         command.Run(_image)
         _image.UseLookupTable = useLookup

         _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = Math.Round(command.Mean, 2).ToString()
         _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = Math.Round(command.StandardDeviation, 2).ToString()
         _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = command.Median.ToString()

         If (_image.BitsPerPixel = 8 OrElse _image.BitsPerPixel = 12 OrElse _image.BitsPerPixel = 16) AndAlso _image.GrayscaleMode <> RasterGrayscaleMode.None Then
            Dim cmd As New MinMaxValuesCommand()
            cmd.Run(_image)
            _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = cmd.MinimumValue.ToString()
            _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = cmd.MaximumValue.ToString()
         Else
            _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = _image.MinValue.ToString()
            _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = _image.MaxValue.ToString()
         End If

         _lvInfo.Items(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)).SubItems(1).Text = command.PixelCount.ToString()
      Catch generatedExceptionName As Exception
      End Try
   End Sub

   Private Sub _btnOK_Click(sender As Object, e As EventArgs) Handles _btnOK.Click
      Close()
   End Sub

End Class
