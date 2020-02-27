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

Namespace DocumentCleanupDemo
   Partial Public Class ZoomDialog : Inherits Form
      '' This dialog will determine the zoom level for the loaded image
      Public Value As Integer
      Public MinimumValue As Integer
      Public MaximumValue As Integer

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub ZoomDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         _tbZoom.Minimum = MinimumValue
         _tbZoom.Maximum = MaximumValue
         _tbPercentage.Text = Value.ToString()
      End Sub

      Private Sub _tbPercentage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _tbPercentage.TextChanged
         Try
            Dim val As Integer = Integer.Parse(_tbPercentage.Text)
            If val >= _tbZoom.Minimum AndAlso val <= _tbZoom.Maximum Then
               _tbZoom.Value = val
            End If
         Catch
         End Try
      End Sub

      Private Sub _tbPercentage_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _tbPercentage.KeyPress
         If (Not e.Handled) Then
            If (Not Char.IsControl(e.KeyChar)) AndAlso (Not Char.IsDigit(e.KeyChar)) Then
               e.Handled = True
            End If
         End If
      End Sub

      Private Sub _tbZoom_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles _tbZoom.Scroll
         _tbPercentage.Text = _tbZoom.Value.ToString()
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Value = _tbZoom.Value
      End Sub
   End Class
End Namespace
