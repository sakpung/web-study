' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Forms.Auto
Imports Leadtools.Forms.Processing
Imports Leadtools.Ocr
Imports Leadtools.Demos
Imports Leadtools.Annotations.Engine
Imports System

Partial Public Class OmrSensitivityDialog
   Inherits Form
   Private _mainForm As MainForm
   Private _sensitivity As OcrOmrSensitivity = OcrOmrSensitivity.High
   Private _omrFields As AnnObjectCollection

   Public Sub New(mainForm As MainForm, omrFields As AnnObjectCollection)
      InitializeComponent()

      _mainForm = mainForm
      _omrFields = omrFields
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      _mainForm.ApplySetOmrSensitivity(_sensitivity)
      Me.Close()
   End Sub

   Private Sub _btnCancel_Click(sender As Object, e As EventArgs) Handles _btnCancel.Click
      Me.Close()
   End Sub

   Private Sub _omrSensitivtyChecked(sender As Object, e As EventArgs) Handles _rbHighest.CheckedChanged, _rbHigh.CheckedChanged, _rbLow.CheckedChanged, _rbLowest.CheckedChanged
      Dim rb As RadioButton = TryCast(sender, RadioButton)
      If (sender Is _rbHighest) Then
         _sensitivity = OcrOmrSensitivity.Highest
      ElseIf (sender Is _rbHigh) Then
         _sensitivity = OcrOmrSensitivity.High
      ElseIf (sender Is _rbLow) Then
         _sensitivity = OcrOmrSensitivity.Low
      ElseIf (sender Is _rbLowest) Then
         _sensitivity = OcrOmrSensitivity.Lowest
      End If
   End Sub
End Class
