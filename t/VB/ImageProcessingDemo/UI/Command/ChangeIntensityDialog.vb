' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the ChangeIntensityCommand

   Partial Public Class ChangeIntensityDialog : Inherits Form
      Public Value As Integer

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub ChangeIntensityDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         'Set command default values
         _txbBrightness.Text = Value.ToString()
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         Value = _tbBrightness.Value
         Me.DialogResult = DialogResult.OK
      End Sub

      Private Sub _txbBrightness_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles _txbBrightness.KeyPress
         If (Not e.Handled) Then
            If (Not Char.IsControl(e.KeyChar)) AndAlso (Not Char.IsDigit(e.KeyChar)) AndAlso Not (e.KeyChar = "-"c) Then
               e.Handled = True
            End If
         End If
      End Sub

      Private Sub _txbBrightness_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txbBrightness.TextChanged
         Try
            'Update command values
            Dim Val As Integer = Integer.Parse(_txbBrightness.Text)
            If Val >= _tbBrightness.Minimum AndAlso Val <= _tbBrightness.Maximum Then
               _tbBrightness.Value = Val
            End If
         Catch
         End Try
      End Sub

      Private Sub _tbBrightness_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbBrightness.Scroll
         _txbBrightness.Text = _tbBrightness.Value.ToString()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         Me.DialogResult = DialogResult.Cancel
      End Sub
   End Class
End Namespace
