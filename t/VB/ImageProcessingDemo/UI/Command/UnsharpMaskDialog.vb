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
   'will be used for the UnsharpMaskCommand

   Partial Public Class UnsharpMaskDialog : Inherits Form
      Private _UnsharpMaskCommand As UnsharpMaskCommand
      Private _Amount As Integer
      Private _Radius As Integer
      Private _Threshold As Integer

      Public Sub New()
         InitializeComponent()
         _UnsharpMaskCommand = New UnsharpMaskCommand()

         'Set command default values
         _Amount = 0
         _Radius = 1
         _Threshold = 0
         InitializeUI()
      End Sub

      Public Property UnsharpMaskCommand() As UnsharpMaskCommand
         Get
            'Update command values
            UpdateCommand()
            Return _UnsharpMaskCommand
         End Get
         Set(ByVal value As UnsharpMaskCommand)
            _UnsharpMaskCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()


         _cmbColorType.Items.Add("RGB Color space")
         _cmbColorType.Items.Add("YUV Color space")

         _cmbColorType.SelectedIndex = 0

         _Amount = 0
         _Radius = 1
         _Threshold = 0

         _txbAmount.Text = _Amount.ToString()
         _txbRadius.Text = _Radius.ToString()
         _txbThreshold.Text = _Threshold.ToString()
      End Sub

      Private Sub UpdateCommand()
         _Amount = Convert.ToInt32(_txbAmount.Text)
         _Radius = Convert.ToInt32(_txbRadius.Text)
         _Threshold = Convert.ToInt32(_txbThreshold.Text)

         _UnsharpMaskCommand.ColorType = TranslateColorType()
         _UnsharpMaskCommand.Amount = _Amount
         _UnsharpMaskCommand.Radius = _Radius
         _UnsharpMaskCommand.Threshold = _Threshold
      End Sub

      Private Function TranslateColorType() As UnsharpMaskCommandColorType
         Select Case _cmbColorType.SelectedIndex
            Case 0
               Return UnsharpMaskCommandColorType.Rgb
            Case 1
               Return UnsharpMaskCommandColorType.Yuv
            Case Else
               Return UnsharpMaskCommandColorType.Rgb
         End Select
      End Function
      Private Sub _tbAmount_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbAmount.Scroll
         _txbAmount.Text = _tbAmount.Value.ToString()
      End Sub

      Private Sub _txbAmount_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txbAmount.TextChanged
         Try
            _txbAmount.Text = MainForm.IsValidNumber(_txbAmount.Text, 0, 500)

            Dim Val As Integer = Integer.Parse(_txbAmount.Text)
            If Val >= _tbAmount.Minimum AndAlso Val <= _tbAmount.Maximum Then
               _tbAmount.Value = Val
            End If
         Catch
         End Try
      End Sub

      Private Sub _tbRadius_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbRadius.Scroll
         _txbRadius.Text = _tbRadius.Value.ToString()
      End Sub

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

      Private Sub _tbThreshold_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbThreshold.Scroll
         _txbThreshold.Text = _tbThreshold.Value.ToString()
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
