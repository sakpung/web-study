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
   'will be used for the AutoCropCommand
   Partial Public Class AutoCropDialog : Inherits Form
      Private _Threshold As Integer

      Public Sub New()
         InitializeComponent()
         _Threshold = 128
         'Set command default values
         InitializeUI()
      End Sub

      Public Property Threshold() As Integer
         Get
            'Update command values
            UpdateCommand()
            Return _Threshold
         End Get
         Set(ByVal value As Integer)
            _Threshold = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()
         _Threshold = 128
         _txbThreshold.Text = _Threshold.ToString()
      End Sub

      Private Sub UpdateCommand()
         _Threshold = Convert.ToInt32(_txbThreshold.Text)
      End Sub

      Private Sub _btnok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnok.Click
         UpdateCommand()
         Me.DialogResult = DialogResult.OK
         Me.Close()
      End Sub

      Private Sub _btncancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btncancel.Click
         InitializeUI()
         Me.DialogResult = DialogResult.Cancel
      End Sub

      Private Sub _txbThreshold_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txbThreshold.TextChanged
         Try
            _txbThreshold.Text = MainForm.IsValidNumber(_txbThreshold.Text, 0, 255)

            Dim Val As Integer = Integer.Parse(_txbThreshold.Text)
            If Val >= _tbThreshold.Minimum AndAlso Val <= _tbThreshold.Maximum Then
               _tbThreshold.Value = Val
            End If
         Catch
         End Try
      End Sub

      Private Sub _tbThreshold_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbThreshold.Scroll
         _txbThreshold.Text = _tbThreshold.Value.ToString()
      End Sub
   End Class
End Namespace
