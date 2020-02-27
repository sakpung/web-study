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
   'will be used for the ColorHalftoneCommand

   Partial Public Class ColorHalftoneDialog : Inherits Form
      Private _ColorHalftoneCommand As ColorHalftoneCommand
      Private _Cyan, _Magenta, _Yellow, _Black, _Radius As Integer

      Public Sub New()
         InitializeComponent()
         _ColorHalftoneCommand = New ColorHalftoneCommand()
         _Cyan = 108
         _Magenta = 163
         _Yellow = 90
         _Black = 45
         _Radius = 8

         'Set command default values
         InitializeUI()
      End Sub

      Public Property ColorHalftoneCommand() As ColorHalftoneCommand
         Get
            'Update command values
            UpdateCommand()
            Return _ColorHalftoneCommand
         End Get
         Set(ByVal value As ColorHalftoneCommand)
            _ColorHalftoneCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()
         _numBlackAngle.Value = _Black
         _numCyanAngle.Value = _Cyan
         _numMagentaAngle.Value = _Magenta
         _numYellowAngle.Value = _Yellow
         _numRadius.Value = _Radius
      End Sub

      Private Sub UpdateCommand()
         _Black = Convert.ToInt32(_numBlackAngle.Value)
         _Cyan = Convert.ToInt32(_numCyanAngle.Value)
         _Magenta = Convert.ToInt32(_numMagentaAngle.Value)
         _Yellow = Convert.ToInt32(_numYellowAngle.Value)
         _Radius = Convert.ToInt32(_numRadius.Value)

         _ColorHalftoneCommand.BlackAngle = _Black
         _ColorHalftoneCommand.CyanAngle = _Cyan
         _ColorHalftoneCommand.MagentaAngle = _Magenta
         _ColorHalftoneCommand.YellowAngle = _Yellow
         _ColorHalftoneCommand.MaximumRadius = _Radius

      End Sub
      Private Sub _numBlackAngle_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numBlackAngle.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numCyanAngle_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numCyanAngle.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numMagentaAngle_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numMagentaAngle.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numYellowAngle_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numYellowAngle.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _numRadius_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numRadius.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _tbBlackAngle_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbBlackAngle.Scroll
         _numBlackAngle.Value = _tbBlackAngle.Value
      End Sub

      Private Sub _tbCyanAngle_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbCyanAngle.Scroll
         _numCyanAngle.Value = _tbCyanAngle.Value
      End Sub

      Private Sub _tbMagentaAngle_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbMagentaAngle.Scroll
         _numMagentaAngle.Value = _tbMagentaAngle.Value
      End Sub

      Private Sub _tbYellowAngle_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbYellowAngle.Scroll
         _numYellowAngle.Value = _tbYellowAngle.Value
      End Sub

      Private Sub _tbRadius_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbRadius.Scroll
         _numRadius.Value = _tbRadius.Value
      End Sub

      Private Sub _numBlackAngle_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numBlackAngle.ValueChanged
         _tbBlackAngle.Value = Convert.ToInt32(_numBlackAngle.Value)
      End Sub

      Private Sub _numCyanAngle_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numCyanAngle.ValueChanged
         _tbCyanAngle.Value = Convert.ToInt32(_numCyanAngle.Value)

      End Sub

      Private Sub _numMagentaAngle_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numMagentaAngle.ValueChanged
         _tbMagentaAngle.Value = Convert.ToInt32(_numMagentaAngle.Value)

      End Sub

      Private Sub _numYellowAngle_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numYellowAngle.ValueChanged
         _tbYellowAngle.Value = Convert.ToInt32(_numYellowAngle.Value)

      End Sub

      Private Sub _numRadius_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numRadius.ValueChanged
         _tbRadius.Value = Convert.ToInt32(_numRadius.Value)
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
