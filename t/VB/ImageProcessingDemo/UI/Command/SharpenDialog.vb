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
   'will be used for the SharpenCommand

   Partial Public Class SharpenDialog : Inherits Form
      Private _SharpenCommand As SharpenCommand = Nothing
      Private _Sharpness As Integer

      Public Sub New()
         InitializeComponent()
         _SharpenCommand = New SharpenCommand()

         'Set command default values
         InitializeUI()

      End Sub

      Public Property Sharpencommand() As SharpenCommand
         Get
            'Update command values
            UpdateCommand()
            Return _SharpenCommand
         End Get
         Set(ByVal value As SharpenCommand)
            _SharpenCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub InitializeUI()
         _Sharpness = 100
         _numSharpness.Value = _Sharpness
      End Sub

      Private Sub UpdateCommand()
         _SharpenCommand.Sharpness = Convert.ToInt32(_numSharpness.Value)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         UpdateCommand()
         Me.DialogResult = DialogResult.OK
         Me.Close()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         InitializeUI()
         Me.DialogResult = DialogResult.Cancel
      End Sub

      Private Sub _tbSharpness_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbSharpness.Scroll
         _numSharpness.Value = _tbSharpness.Value
      End Sub

      Private Sub _numSharpness_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numSharpness.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub
   End Class
End Namespace
