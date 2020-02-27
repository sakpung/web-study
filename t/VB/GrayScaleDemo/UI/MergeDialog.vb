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

Imports Leadtools
Imports GrayScaleDemo.Leadtools.Demos
Imports Leadtools.ImageProcessing.Color
Imports System

Partial Public Class MergeDialog
   Inherits Form
   Private _images As List(Of ViewerImages)
   Private _mergeType As ColorMergeCommandType
   Private _mergeImage As RasterImage
   Private _maxImgNum As Integer
   Private _checkedImgsCount As Integer

   Public Property MergeImage() As RasterImage
      Get
         Return _mergeImage
      End Get
      Set(value As RasterImage)
         _mergeImage = value
      End Set
   End Property

   Public Property MergeType() As ColorMergeCommandType
      Get
         Return _mergeType
      End Get
      Set(value As ColorMergeCommandType)
         _mergeType = value
      End Set
   End Property

   Public Sub New(images As List(Of ViewerImages))
      InitializeComponent()
      _images = images
   End Sub

   Private Sub MergeDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      For Each tmpImg As ViewerImages In _images
         _cLbImages.Items.Add(tmpImg.ImageName)
      Next

      _rbRGB.Checked = True

   End Sub

   Private Sub _rb_CheckedChanged(sender As Object, e As EventArgs) Handles _rbSCT.CheckedChanged, _rbYCRCB.CheckedChanged, _rbLAB.CheckedChanged, _rbXYZ.CheckedChanged, _rbYUV.CheckedChanged, _rbCMY.CheckedChanged, _rbHLS.CheckedChanged, _rbHSV.CheckedChanged, _rbCMYK.CheckedChanged, _rbRGB.CheckedChanged
      If _rbCMY.Checked = True Then
         _mergeType = ColorMergeCommandType.Cmy
      ElseIf _rbCMYK.Checked = True Then
         _mergeType = ColorMergeCommandType.Cmyk
      ElseIf _rbHLS.Checked = True Then
         _mergeType = ColorMergeCommandType.Hls
      ElseIf _rbHSV.Checked = True Then
         _mergeType = ColorMergeCommandType.Hsv
      ElseIf _rbLAB.Checked = True Then
         _mergeType = ColorMergeCommandType.Lab
      ElseIf _rbRGB.Checked = True Then
         _mergeType = ColorMergeCommandType.Rgb
      ElseIf _rbSCT.Checked = True Then
         _mergeType = ColorMergeCommandType.Sct
      ElseIf _rbXYZ.Checked = True Then
         _mergeType = ColorMergeCommandType.Xyz
      ElseIf _rbYCRCB.Checked = True Then
         _mergeType = ColorMergeCommandType.YcrCb
      ElseIf _rbYUV.Checked = True Then
         _mergeType = ColorMergeCommandType.Yuv
      End If

      If _mergeType = ColorMergeCommandType.Cmyk Then
         _maxImgNum = 4
      Else
         _maxImgNum = 3
      End If
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      _checkedImgsCount = 0
      For i As Integer = 0 To _cLbImages.Items.Count - 1
         If _cLbImages.GetItemChecked(i) Then
            _checkedImgsCount += 1
         End If
      Next

      If _maxImgNum <> _checkedImgsCount Then
         Messager.ShowWarning(Me, String.Format("For this Merg type you must select {0} images exactly", _maxImgNum))
         DialogResult = DialogResult.None
         Return


      End If

      If _mergeImage IsNot Nothing Then
         _mergeImage.Dispose()
      End If
      For i As Integer = 0 To _cLbImages.Items.Count - 1
         If _cLbImages.GetItemChecked(i) Then
            If _mergeImage Is Nothing Then
               _mergeImage = _images(i).Image.Clone()
            Else
               _mergeImage.AddPages(New RasterImage(_images(i).Image), 1, 1)
            End If
         End If
      Next

      DialogResult = DialogResult.OK
   End Sub

   Private Sub _cLbImages_SelectedIndexChanged(sender As Object, e As EventArgs)

   End Sub

   Private Sub _btnCancel_Click(sender As Object, e As EventArgs) Handles _btnCancel.Click
      Close()
   End Sub
End Class
