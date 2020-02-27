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
   'will be used for the GrayScaleExtendedCommand

   Partial Public Class GrayScaleExtendedDialog : Inherits Form
      Private _GrayScaleExtendedCommand As GrayScaleExtendedCommand
      Private _Red, _Green, _Blue As Integer

      Public Sub New()
         InitializeComponent()
         _GrayScaleExtendedCommand = New GrayScaleExtendedCommand()

         'Set command default values
         InitializeUI()
      End Sub

      Public Property GrayScaleExtendedCommand() As GrayScaleExtendedCommand
         Get
            'Update command values
            UpdateCommand()
            Return _GrayScaleExtendedCommand
         End Get
         Set(ByVal value As GrayScaleExtendedCommand)
            _GrayScaleExtendedCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()
         _Red = 300
         _Green = 590
         _Blue = 110

         _numRed.Value = _Red
         _numGreen.Value = _Green
         _numBlue.Value = _Blue
      End Sub

      Private Sub UpdateCommand()
         _Red = Convert.ToInt32(_numRed.Value)
         _Green = Convert.ToInt32(_numGreen.Value)
         _Blue = Convert.ToInt32(_numBlue.Value)

         _GrayScaleExtendedCommand.RedFactor = _Red
         _GrayScaleExtendedCommand.GreenFactor = _Green
         _GrayScaleExtendedCommand.BlueFactor = _Blue
      End Sub

      Private Sub _tbRed_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbRed.Scroll
         'if ((_numRed.Value + _numGreen.Value + _numBlue.Value) >= 1000)
         '{
         '_numRed.Value = 1000 - (_numGreen.Value + _numBlue.Value);
         '_tbRed.Value = Convert.ToInt32(_numRed.Value);
         '}
         'else
         _numRed.Value = _tbRed.Value
      End Sub

      Private Sub _tbGreen_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbGreen.Scroll
         _numGreen.Value = _tbGreen.Value

      End Sub

      Private Sub _tbBlue_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbBlue.Scroll
         _numBlue.Value = _tbBlue.Value
      End Sub

      Private Sub _numRed_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numRed.ValueChanged
         _tbRed.Value = Convert.ToInt32(_numRed.Value)
      End Sub

      Private Sub _numGreen_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numGreen.ValueChanged
         _tbGreen.Value = Convert.ToInt32(_numGreen.Value)
      End Sub

      Private Sub _numBlue_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numBlue.ValueChanged
         _tbBlue.Value = Convert.ToInt32(_numBlue.Value)
      End Sub

      Private Sub _numRed_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numRed.Leave
         DialogUtilities.NumericOnLeave(sender)
         If _numRed.Value <> _numRed.Maximum Then
            _numRed.Value = _numRed.Value + 1
            _numRed.Value = _numRed.Value - 1
         End If
      End Sub

      Private Sub _numGreen_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numGreen.Leave
         DialogUtilities.NumericOnLeave(sender)
         If _numGreen.Value <> _numGreen.Maximum Then
            _numGreen.Value = _numGreen.Value + 1
            _numGreen.Value = _numGreen.Value - 1
         End If
      End Sub

      Private Sub _numBlue_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numBlue.Leave
         DialogUtilities.NumericOnLeave(sender)
         If _numBlue.Value <> _numBlue.Maximum Then
            _numBlue.Value = _numBlue.Value + 1
            _numBlue.Value = _numBlue.Value - 1
         End If
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         If (_numRed.Value + _numGreen.Value + _numBlue.Value) > 1000 Then
            MessageBox.Show("The Sum of the Red, Green and Blue values must be <= 1000. Please modify the values.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _numRed.Value = _Red + 1
            _numGreen.Value = _Green + 1
            _numBlue.Value = _Blue + 1

            _numRed.Value = _numRed.Value - 1
            _numGreen.Value = _numGreen.Value - 1
            _numBlue.Value = _numBlue.Value - 1

         Else
            UpdateCommand()
            Me.DialogResult = DialogResult.OK
            Me.Close()
         End If
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         Me.DialogResult = DialogResult.Cancel
      End Sub
   End Class
End Namespace
