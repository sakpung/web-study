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

Imports Leadtools
Imports Leadtools.ImageProcessing.Effects

Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the GaussianCommand

   Partial Public Class GaussianDialog : Inherits Form
      Private _Radius As Integer

      Public Sub New()
         InitializeComponent()

         'Set command default values
         _Radius = 1
         InitializeUI()
      End Sub

      Public Property Radius() As Integer
         Get
            'Update command values
            UpdateCommand()
            Return _Radius
         End Get
         Set(ByVal value As Integer)
            _Radius = value
            InitializeUI()
         End Set
      End Property

      Private Sub _txbRadius_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txbRadius.TextChanged
         Try
            _txbRadius.Text = MainForm.IsValidNumber(_txbRadius.Text, 1, 1000)

            Dim Val As Integer = Integer.Parse(_txbRadius.Text)
            If Val >= _tbRadius.Minimum AndAlso Val <= _tbRadius.Maximum Then
               _tbRadius.Value = Val
            End If
         Catch
         End Try
      End Sub

      Private Sub _tbRadius_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbRadius.Scroll
         _txbRadius.Text = _tbRadius.Value.ToString()
      End Sub

      Private Sub InitializeUI()
         _txbRadius.Text = _Radius.ToString()
      End Sub
      Private Sub UpdateCommand()
         _Radius = Convert.ToInt32(_txbRadius.Text)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         UpdateCommand()
         Me.DialogResult = DialogResult.OK
         Me.Close()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         Me.DialogResult = DialogResult.Cancel
      End Sub

   End Class
End Namespace
