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

Imports GrayScaleDemo.Leadtools.Demos
Imports Leadtools.ImageProcessing.Effects
Imports System

Partial Public Class UnSharpenDailog
   Inherits Form
   Private Shared _initialAmount As Integer
   Private Shared _initialRadius As Integer
   Private Shared _initialThreshold As Integer
   Private Shared _initialColorSpace As UnsharpMaskCommandColorType

   Public Amount As Integer
   Public Radius As Integer
   Public Threshold As Integer
   Public ColorSpace As UnsharpMaskCommandColorType

   Public Sub New(bpp As Integer)
      InitializeComponent()
      _numThreshold.Maximum = 255
   End Sub

   Private Sub UnSharpenDailog_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim command As New UnsharpMaskCommand()
      _initialAmount = command.Amount
      _initialRadius = command.Radius
      _initialThreshold = command.Threshold
      _initialColorSpace = command.ColorType

      Amount = _initialAmount
      Radius = _initialRadius
      Threshold = _initialThreshold
      ColorSpace = _initialColorSpace

      _numAmount.Value = Amount
      _numRadius.Value = Radius
      _numThreshold.Value = Threshold

      Tools.FillComboBoxWithEnum(_cbColorSpace, GetType(UnsharpMaskCommandColorType), ColorSpace, New Object() {UnsharpMaskCommandColorType.None})
   End Sub
   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      Amount = CInt(_numAmount.Value)
      Radius = CInt(_numRadius.Value)
      Threshold = CInt(_numThreshold.Value)

      ColorSpace = CType(Constants.GetValueFromName(GetType(UnsharpMaskCommandColorType), CType(_cbColorSpace.SelectedItem, String), _initialColorSpace), UnsharpMaskCommandColorType)

      _initialAmount = Amount
      _initialRadius = Radius
      _initialThreshold = Threshold
      _initialColorSpace = ColorSpace
   End Sub
End Class
