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

Namespace MainDemo

   Partial Public Class MagicWandThresholdDialog : Inherits Form
      Public Value As Integer
      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub _txtThreshold_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txtThreshold.TextChanged
         Try
            Dim val As Integer = Integer.Parse(_txtThreshold.Text)
            If val > _tbThreshold.Maximum Then
               val = _tbThreshold.Maximum
               _txtThreshold.Text = _tbThreshold.Maximum.ToString()
            End If

            If val < _tbThreshold.Minimum Then
               val = _tbThreshold.Minimum
               _txtThreshold.Text = _tbThreshold.Minimum.ToString()
            End If

            _tbThreshold.Value = val
         Catch
         End Try
      End Sub

      Private Sub _txtThreshold_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles _txtThreshold.KeyPress
         If (Not e.Handled) Then
            If (Not Char.IsControl(e.KeyChar)) AndAlso (Not Char.IsDigit(e.KeyChar)) Then
               e.Handled = True
            End If
         End If
      End Sub

      Private Sub MagicWandThresholdDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         _txtThreshold.Text = Value.ToString()
      End Sub

      Private Sub _tbThreshold_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbThreshold.Scroll
         _txtThreshold.Text = _tbThreshold.Value.ToString()
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         Value = _tbThreshold.Value
      End Sub
   End Class

End Namespace
