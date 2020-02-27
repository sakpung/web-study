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
Imports Leadtools.ImageProcessing

Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the GrayscaleCommand

   Partial Public Class GrayScaleDialog : Inherits Form
      Private _GrayscaleCommand As GrayscaleCommand = Nothing

      Public Sub New()
         InitializeComponent()
         _GrayscaleCommand = New GrayscaleCommand()

         'Set command default values
         InitializeUI()
      End Sub

      Private Sub InitializeUI()
         _cmbBitsPerPixel.Items.Add(8)
         _cmbBitsPerPixel.Items.Add(12)
         _cmbBitsPerPixel.Items.Add(16)
         _cmbBitsPerPixel.Items.Add(32)

         _cmbBitsPerPixel.SelectedIndex = 0
         _GrayscaleCommand.BitsPerPixel = 8
      End Sub

      'Update command values
      Private Sub UpdateCommand()
         If _cmbBitsPerPixel.Text <> "" Then
            _GrayscaleCommand.BitsPerPixel = Convert.ToInt32(_cmbBitsPerPixel.Text)
         Else
            _GrayscaleCommand.BitsPerPixel = 8
         End If
      End Sub

      Public Property Grayscalecommand() As GrayscaleCommand
         Get
            'Update command values
            UpdateCommand()
            Return _GrayscaleCommand
         End Get
         Set(ByVal value As GrayscaleCommand)
            _GrayscaleCommand = value
            InitializeUI()
         End Set
      End Property

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
