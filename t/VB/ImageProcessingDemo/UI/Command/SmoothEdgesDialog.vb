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
   'will be used for the SmoothEdgesCommand

   Partial Public Class SmoothEdgesDialog : Inherits Form
      Private _SmoothEdgesCommand As SmoothEdgesCommand
      Private _Amount, _Threshold As Integer

      Public Sub New()
         InitializeComponent()
         _SmoothEdgesCommand = New SmoothEdgesCommand()

         'Set command default values
         InitializeUI()
      End Sub

      Public Property SmoothEdgesCommand() As SmoothEdgesCommand
         Get
            'Update command values
            UpdateCommand()
            Return _SmoothEdgesCommand
         End Get
         Set(ByVal value As SmoothEdgesCommand)
            _SmoothEdgesCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()
         _Amount = 50
         _Threshold = 0

         _numAmount.Value = _Amount
         _numThreshold.Value = _Threshold
      End Sub
      Private Sub UpdateCommand()
         _Amount = Convert.ToInt32(_numAmount.Value)
         _Threshold = Convert.ToInt32(_numThreshold.Value)

         _SmoothEdgesCommand.Amount = _Amount
         _SmoothEdgesCommand.Threshold = _Threshold
      End Sub
      Private Sub _tbThreshold_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbThreshold.Scroll
         _numThreshold.Value = _tbThreshold.Value
      End Sub

      Private Sub _tbAmount_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbAmount.Scroll
         _numAmount.Value = _tbAmount.Value
      End Sub

      Private Sub _numAmount_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numAmount.ValueChanged
         _tbAmount.Value = Convert.ToInt32(_numAmount.Value)
      End Sub

      Private Sub _numAmount_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numAmount.Leave
         DialogUtilities.NumericOnLeave(sender)

      End Sub

      Private Sub _numThreshold_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numThreshold.Leave
         DialogUtilities.NumericOnLeave(sender)

      End Sub

      Private Sub _numThreshold_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numThreshold.ValueChanged
         _tbThreshold.Value = Convert.ToInt32(_numThreshold.Value)

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
