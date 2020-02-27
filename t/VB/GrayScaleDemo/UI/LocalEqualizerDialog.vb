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

Imports Leadtools.ImageProcessing.Color
Imports GrayScaleDemo.Leadtools.Demos
Imports Leadtools.ImageProcessing.Effects
Imports System

Partial Public Class LocalEqualizerDialog
   Inherits Form
   Private Shared _initialWidth As Integer
   Private Shared _initialHeight As Integer
   Private Shared _initialWidthExt As Integer
   Private Shared _initialHeightExt As Integer
   Private Shared _initialSmooth As Integer
   Private Shared _initialEqualizeType As HistogramEqualizeType

   Public nWidth As Integer
   Public nHeight As Integer
   Public nWidthExt As Integer
   Public nHeightExt As Integer
   Public nSmooth As Integer
   Public EqualizeType As HistogramEqualizeType

   Private _width As Integer
   Private _height As Integer

   Public Sub New(width As Integer, height As Integer)
      InitializeComponent()
      _width = width - 1
      _height = height - 1
   End Sub

   Private Sub LocalEqualizerDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim command As New LocalHistogramEqualizeCommand()
      _initialWidth = command.Width
      _initialHeight = command.Height
      _initialWidthExt = command.WidthExtension
      _initialHeightExt = command.HeightExtension
      _initialSmooth = command.Smooth
      _initialEqualizeType = command.Type


      nWidth = _initialWidth
      nHeight = _initialHeight
      nWidthExt = _initialWidthExt
      nHeightExt = _initialHeightExt
      nSmooth = _initialSmooth
      EqualizeType = _initialEqualizeType

      _numWidth.Value = nWidth
      _numHeight.Value = nHeight
      _numWidthExt.Value = nWidthExt
      _numHeightExt.Value = nHeightExt
      _numSmooth.Value = nSmooth

      _numWidth.Maximum = _width
      _numWidth.Minimum = 1
      _numWidthExt.Maximum = _width
      _numWidthExt.Minimum = 0

      _numHeight.Maximum = _height
      _numHeight.Minimum = 1
      _numHeightExt.Maximum = _height
      _numHeightExt.Minimum = 0

      _numWidth.Value = _width
      _numHeight.Value = _height

      Tools.FillComboBoxWithEnum(_cbEqualizeType, GetType(HistogramEqualizeType), EqualizeType, New Object() {UnsharpMaskCommandColorType.None})
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      nWidth = CInt(_numWidth.Value)
      nHeight = CInt(_numHeight.Value)
      nWidthExt = CInt(_numWidthExt.Value)
      nHeightExt = CInt(_numHeightExt.Value)
      nSmooth = CInt(_numSmooth.Value)
      EqualizeType = CType(Constants.GetValueFromName(GetType(HistogramEqualizeType), CType(_cbEqualizeType.SelectedItem, String), _initialEqualizeType), HistogramEqualizeType)

      _numWidth.Value = nWidth
      _numHeight.Value = nHeight
      _numWidthExt.Value = nWidthExt
      _numHeightExt.Value = nHeightExt
      _numSmooth.Value = nSmooth
      _initialEqualizeType = EqualizeType
   End Sub
End Class
