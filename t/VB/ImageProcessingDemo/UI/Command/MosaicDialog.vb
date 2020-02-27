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
   'will be used for the MosaicCommand

   Partial Public Class MosaicDialog : Inherits Form
      Private _MosaicCommand As MosaicCommand = Nothing
      Private _Dimension As Integer

      Public Sub New()
         InitializeComponent()
         _MosaicCommand = New MosaicCommand()

         'Set command default values
         InitializeUI()

      End Sub

      Public Property Mosaiccommand() As MosaicCommand
         Get
            'Update command values
            UpdateCommand()
            Return _MosaicCommand
         End Get
         Set(ByVal value As MosaicCommand)
            _MosaicCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub _txbDimension_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txbDimension.TextChanged
         Try
            _txbDimension.Text = MainForm.IsValidNumber(_txbDimension.Text, 1, 64)

            Dim Val As Integer = Integer.Parse(_txbDimension.Text)
            If Val >= _tbDimension.Minimum AndAlso Val <= _tbDimension.Maximum Then
               _tbDimension.Value = Val
            End If
         Catch
         End Try
      End Sub

      Private Sub _tbDimension_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbDimension.Scroll
         _txbDimension.Text = _tbDimension.Value.ToString()
      End Sub

      Private Sub InitializeUI()
         _Dimension = 2
         _txbDimension.Text = _Dimension.ToString()
      End Sub

      Private Sub UpdateCommand()
         _MosaicCommand.Dimension = Convert.ToInt32(_txbDimension.Text)
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
   End Class
End Namespace
