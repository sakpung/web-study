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
Imports Leadtools.ImageProcessing.Color
Imports System


Partial Public Class EqualizerDialog
   Inherits Form
   Private Shared _initialColorSpace As HistogramEqualizeType
   Public ColorSpace As HistogramEqualizeType

   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      ColorSpace = CType(Constants.GetValueFromName(GetType(HistogramEqualizeType), CType(_cbColorSpace.SelectedItem, String), _initialColorSpace), HistogramEqualizeType)

      _initialColorSpace = ColorSpace
   End Sub

   Private Sub EqualizerDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim command As New HistogramEqualizeCommand()
      _initialColorSpace = command.Type

      ColorSpace = _initialColorSpace
      Tools.FillComboBoxWithEnum(_cbColorSpace, GetType(HistogramEqualizeType), ColorSpace, New Object() {HistogramEqualizeType.None})
   End Sub
End Class
