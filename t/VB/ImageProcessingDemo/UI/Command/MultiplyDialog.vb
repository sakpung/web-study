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
   'will be used for the MultiplyCommand

   Partial Public Class MultiplyDialog : Inherits Form
      Private _MultiplyCommand As MultiplyCommand
      Private _Factor As Integer

      Public Sub New()
         InitializeComponent()
         _MultiplyCommand = New MultiplyCommand()

         'Set command default values
         InitializeUI()

      End Sub

      Public Property MultiplyCommand() As MultiplyCommand
         Get
            'Update command values
            UpdateCommand()
            Return _MultiplyCommand
         End Get
         Set(ByVal value As MultiplyCommand)
            _MultiplyCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()
         _Factor = 1
         _numFactor.Value = _Factor
      End Sub
      Private Sub UpdateCommand()
         _Factor = Convert.ToInt32(_numFactor.Value)

         _MultiplyCommand.Factor = _Factor
      End Sub

      Private Sub _numFactor_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numFactor.ValueChanged
         _tbFactor.Value = Convert.ToInt32(_numFactor.Value)
      End Sub

      Private Sub _numFactor_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numFactor.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _tbFactor_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbFactor.Scroll
         _numFactor.Value = _tbFactor.Value
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
