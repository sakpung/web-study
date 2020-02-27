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
   'will be used for the RemoveRedEyeCommand

   Partial Public Class RemoveRedEyeDialog : Inherits Form
      Private _RemoveRedEyeCommand As RemoveRedEyeCommand
      Private _Red, _Green, _Blue, _Threshold, _Lightness As Integer

      Public Sub New()
         InitializeComponent()
         _RemoveRedEyeCommand = New RemoveRedEyeCommand()

         'Set command default values
         InitializeUI()
      End Sub

      Public Property RemoveRedEyeCommand() As RemoveRedEyeCommand
         Get
            'Update command values
            UpdateCommand()
            Return _RemoveRedEyeCommand
         End Get
         Set(ByVal value As RemoveRedEyeCommand)
            _RemoveRedEyeCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()
         _Red = 0
         _Green = 0
         _Blue = 0
         _Threshold = 150
         _Lightness = 100

         _numRed.Value = _Red
         _numGreen.Value = _Green
         _numBlue.Value = _Blue
         _numThreshold.Value = _Threshold
         _numLightness.Value = _Lightness
      End Sub

      Private Sub UpdateCommand()

         _Red = Convert.ToInt32(_numRed.Value)
         _Green = Convert.ToInt32(_numGreen.Value)
         _Blue = Convert.ToInt32(_numBlue.Value)
         _Threshold = Convert.ToInt32(_numThreshold.Value)
         _Lightness = Convert.ToInt32(_numLightness.Value)

         _RemoveRedEyeCommand.NewColor = New RasterColor(_Red, _Green, _Blue)
         _RemoveRedEyeCommand.Threshold = _Threshold
         _RemoveRedEyeCommand.Lightness = _Lightness
      End Sub

      Private Sub _numBlue_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numBlue.ValueChanged
         _tbBlue.Value = Convert.ToInt32(_numBlue.Value)
      End Sub

      Private Sub _numRed_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numRed.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numGreen_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numGreen.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numBlue_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numBlue.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numThreshold_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numThreshold.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numLightness_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numLightness.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _tbRed_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbRed.Scroll
         _numRed.Value = _tbRed.Value
      End Sub

      Private Sub _tbGreen_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbGreen.Scroll
         _numGreen.Value = _tbGreen.Value
      End Sub

      Private Sub _tbBlue_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbBlue.Scroll
         _numBlue.Value = _tbBlue.Value
      End Sub

      Private Sub _tbThreshold_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbThreshold.Scroll
         _numThreshold.Value = _tbThreshold.Value
      End Sub

      Private Sub _tbLightness_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbLightness.Scroll
         _numLightness.Value = _tbLightness.Value
      End Sub

      Private Sub _numRed_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numRed.ValueChanged
         _tbRed.Value = Convert.ToInt32(_numRed.Value)
      End Sub

      Private Sub _numGreen_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numGreen.ValueChanged
         _tbGreen.Value = Convert.ToInt32(_numGreen.Value)
      End Sub

      Private Sub _numThreshold_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numThreshold.ValueChanged
         _tbThreshold.Value = Convert.ToInt32(_numThreshold.Value)
      End Sub

      Private Sub _numLightness_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numLightness.ValueChanged
         _tbLightness.Value = Convert.ToInt32(_numLightness.Value)
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
