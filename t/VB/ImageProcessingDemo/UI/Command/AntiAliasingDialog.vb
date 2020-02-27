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
   'will be used for the AntiAliasingCommand

   Partial Public Class AntiAliasingDialog : Inherits Form
      Private _AntiAliasingCommand As AntiAliasingCommand
      Private _Threshold, _MaskSize As Integer

      Public Sub New()
         InitializeComponent()
         _AntiAliasingCommand = New AntiAliasingCommand()
         _Threshold = 0
         _MaskSize = 2
         'Set command default values
         InitializeUI()
      End Sub

      Public Property AntiAliasingCommand() As AntiAliasingCommand
         Get
            'Update command values
            UpdateCommand()
            Return _AntiAliasingCommand
         End Get
         Set(ByVal value As AntiAliasingCommand)
            _AntiAliasingCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()
         _cmbFilter.Items.Add("Vertically and Horizontally")
         _cmbFilter.Items.Add("All directions 1")
         _cmbFilter.Items.Add("All directions 2")
         _cmbFilter.Items.Add("Diagonally")
         _cmbFilter.Items.Add("Horizontally")
         _cmbFilter.Items.Add("Vertically")

         _cmbFilter.SelectedIndex = 0

         _txbThreshold.Text = _Threshold.ToString()
         _txbMaskSize.Text = _MaskSize.ToString()
      End Sub

      Private Sub UpdateCommand()
         If _txbThreshold.Text <> "" Then
            _AntiAliasingCommand.Threshold = Convert.ToInt32(_txbThreshold.Text)
         End If
         If _txbMaskSize.Text <> "" Then
            _AntiAliasingCommand.Dimension = Convert.ToInt32(_txbMaskSize.Text)
         End If


         _AntiAliasingCommand.Filter = TranslateFilter()
      End Sub

      Public Function TranslateFilter() As AntiAliasingCommandType
         Select Case _cmbFilter.SelectedIndex
            Case 0
               Return AntiAliasingCommandType.Type1
            Case 1
               Return AntiAliasingCommandType.Type2
            Case 2
               Return AntiAliasingCommandType.Type3
            Case 3
               Return AntiAliasingCommandType.Diagonal
            Case 4
               Return AntiAliasingCommandType.Horizontal
            Case 5
               Return AntiAliasingCommandType.Vertical
            Case Else
               Return AntiAliasingCommandType.Type1
         End Select
      End Function

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

      Private Sub _tbMaskSize_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbMaskSize.Scroll
         _txbMaskSize.Text = _tbMaskSize.Value.ToString()
      End Sub

      Private Sub _txbMaskSize_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txbMaskSize.TextChanged
         Try
            _txbMaskSize.Text = MainForm.IsValidNumber(_txbMaskSize.Text, 2, 100)

            Dim Val As Integer = Integer.Parse(_txbMaskSize.Text)
            If Val >= _tbMaskSize.Minimum AndAlso Val <= _tbMaskSize.Maximum Then
               _tbMaskSize.Value = Val
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
