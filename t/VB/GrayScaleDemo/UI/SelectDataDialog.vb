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

Imports Leadtools.ImageProcessing.Core
Imports Leadtools
Imports GrayScaleDemo.Leadtools.Demos
Imports System

Partial Public Class SelectDataDialog
   Inherits Form
   Private Shared _color As Color
   Private Shared _combine As Boolean
   Private Shared _sourceLowBit As Integer
   Private Shared _sourceHighBit As Integer
   Private Shared _threshold As Integer

   Public dlgColor As Color
   Public Combine As Boolean
   Public SourceLowBit As Integer
   Public SourceHighBit As Integer
   Public Threshold As Integer

   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub SelectDataDialog_Load(sender As Object, e As EventArgs) Handles Me.Load

      Dim cmd As New SelectDataCommand()
      _pnlColor.BackColor = Converters.ToGdiPlusColor(cmd.Color)
      _color = Converters.ToGdiPlusColor(cmd.Color)
      _combine = cmd.Combine
      _sourceLowBit = cmd.SourceLowBit
      _sourceHighBit = cmd.SourceHighBit
      _threshold = cmd.Threshold


      dlgColor = _color
      Combine = _combine
      SourceHighBit = _sourceHighBit
      SourceLowBit = _sourceLowBit
      Threshold = _threshold

      _numSourceHighBit.Value = SourceHighBit
      _numSourceLowBit.Value = SourceLowBit
      _numThreshold.Value = Threshold
      _cbCombine.Checked = Combine
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      Combine = _cbCombine.Checked
      SourceHighBit = CInt(_numSourceHighBit.Value)
      SourceLowBit = CInt(_numSourceHighBit.Value)
      Threshold = CInt(_numThreshold.Value)
      dlgColor = _color

      _combine = Combine
      _sourceHighBit = SourceHighBit
      _sourceLowBit = SourceLowBit
      _threshold = Threshold
   End Sub

   Private Sub _btnColor_Click(sender As Object, e As EventArgs) Handles _btnColor.Click
      Dim colorDlg As New ColorDialog()
      If colorDlg.ShowDialog() = DialogResult.OK Then
         _color = colorDlg.Color
         _pnlColor.BackColor = colorDlg.Color
      End If
   End Sub
End Class
