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
Imports System

Partial Public Class OmrDetectionDialog
   Inherits Form
   Private _mainForm As MainForm
   Private _masterForm As DiskMasterForm
   Private _sensitivity As OcrOmrSensitivity = OcrOmrSensitivity.High
   Private _selectedPageNumber As Integer

   Public Sub New(mainForm As MainForm, masterForm As DiskMasterForm, selectedPageNumber As Integer)
      If selectedPageNumber = 0 Then
         Messager.ShowWarning(Me, New ArgumentOutOfRangeException("selectedPageNumber"))
         Close()
      End If

      InitializeComponent()

      _mainForm = mainForm
      _masterForm = masterForm
      _selectedPageNumber = selectedPageNumber

      _rbHigh.Checked = True
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      Dim fields As List(Of OmrFormField) = _masterForm.AutoDetectOmrFields(_sensitivity, _selectedPageNumber)
      If fields IsNot Nothing Then
         _mainForm.FillDetectedOmrFields(fields)
      End If

      Me.Close()
   End Sub

   Private Sub _btnCancel_Click(sender As Object, e As EventArgs) Handles _btnCancel.Click
      Me.Close()
   End Sub

   Private Sub _omrSensitivtyChecked(sender As Object, e As EventArgs) Handles _rbLowest.CheckedChanged, _rbLow.CheckedChanged, _rbHigh.CheckedChanged, _rbHighest.CheckedChanged
      Dim rb As RadioButton = TryCast(sender, RadioButton)
      _sensitivity = CType([Enum].Parse(GetType(OcrOmrSensitivity), rb.Text, False), OcrOmrSensitivity)
   End Sub
End Class
