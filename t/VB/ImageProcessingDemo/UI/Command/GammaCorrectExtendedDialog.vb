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
Imports Leadtools.ImageProcessing.Color

Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the GammaCorrectExtendedCommand

   Partial Public Class GammaCorrectExtendedDialog : Inherits Form
      Private _GammaCorrectExtendedCommand As GammaCorrectExtendedCommand
      Private _Gamma As Integer

      Public Sub New()
         InitializeComponent()
         _GammaCorrectExtendedCommand = New GammaCorrectExtendedCommand()

         'Set command default values
         _Gamma = 250
         InitializeUI()
      End Sub

      Public Property GammaCorrectExtendedCommand() As GammaCorrectExtendedCommand
         Get
            'Update command values
            UpdateCommand()
            Return _GammaCorrectExtendedCommand
         End Get
         Set(ByVal value As GammaCorrectExtendedCommand)
            _GammaCorrectExtendedCommand = value
            InitializeUI()

         End Set
      End Property

      Private Sub InitializeUI()
         If (_GammaCorrectExtendedCommand.Type And GammaCorrectExtendedCommandType.RgbSpace) = GammaCorrectExtendedCommandType.RgbSpace Then
            _rbRgb.Checked = True
         End If
         If (_GammaCorrectExtendedCommand.Type And GammaCorrectExtendedCommandType.YuvSpace) = GammaCorrectExtendedCommandType.YuvSpace Then
            _rbYuv.Checked = True
         End If

         _Gamma = 250
         _txbGamma.Text = _Gamma.ToString()


      End Sub

      Private Sub UpdateCommand()
         _GammaCorrectExtendedCommand.Type = CType(0, GammaCorrectExtendedCommandType)
         If _rbRgb.Checked Then
            _GammaCorrectExtendedCommand.Type = GammaCorrectExtendedCommandType.RgbSpace
         End If
         If _rbYuv.Checked Then
            _GammaCorrectExtendedCommand.Type = GammaCorrectExtendedCommandType.YuvSpace
         End If

         If _txbGamma.Text <> "" Then
            _Gamma = Convert.ToInt32(_txbGamma.Text)
         End If

         _GammaCorrectExtendedCommand.Gamma = _Gamma
      End Sub

      Private Sub _tbGamma_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbGamma.Scroll
         _txbGamma.Text = _tbGamma.Value.ToString()
      End Sub

      Private Sub _txbGamma_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txbGamma.TextChanged
         Try
            _txbGamma.Text = MainForm.IsValidNumber(_txbGamma.Text, 1, 500)

            Dim Val As Integer = Integer.Parse(_txbGamma.Text)
            If Val >= _tbGamma.Minimum AndAlso Val <= _tbGamma.Maximum Then
               _tbGamma.Value = Val
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
