' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Namespace PDFFormsDemo
   Partial Public Class ColorPickerPanel
      Inherits UserControl
      Public Sub New()
         InitializeComponent()

         _colorPickerDialog.Color = _colorPanel.BackColor
      End Sub

      Private Sub _openButton_Click(sender As Object, e As EventArgs) Handles _openButton.Click
         _colorPickerDialog.Color = _colorPanel.BackColor
         If _colorPickerDialog.ShowDialog() = DialogResult.OK Then
            _colorPanel.BackColor = _colorPickerDialog.Color
         End If
      End Sub

      Public Property Color() As Color
         Get
            Return _colorPanel.BackColor
         End Get
         Set(value As Color)
            _colorPanel.BackColor = value
         End Set
      End Property
   End Class
End Namespace
