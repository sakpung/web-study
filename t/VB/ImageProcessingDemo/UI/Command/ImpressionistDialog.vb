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
Imports Leadtools.ImageProcessing.SpecialEffects

Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the ImpressionistCommand 

   Partial Public Class ImpressionistDialog : Inherits Form
      Private _HorizontalSize As Integer
      Private _VerticalSize As Integer
      Private _RasImage As RasterImage


      Public Sub New()
         InitializeComponent()
         _HorizontalSize = 1
         _VerticalSize = 1

         'Set command default values
         InitializeUI()
      End Sub

      Public Sub New(ByVal TempImage As RasterImage)
         InitializeComponent()
         _HorizontalSize = 1
         _VerticalSize = 1
         _RasImage = TempImage
         InitializeUI()

      End Sub
      Public Property HorizontalSize() As Integer
         Get
            UpdateCommand()
            Return _HorizontalSize
         End Get
         Set(ByVal value As Integer)
            _HorizontalSize = value
            InitializeUI()

         End Set
      End Property

      Public Property VerticalSize() As Integer
         Get
            'Update command values
            UpdateCommand()
            Return _VerticalSize
         End Get
         Set(ByVal value As Integer)
            _VerticalSize = value
            InitializeUI()

         End Set
      End Property

      Private Sub InitializeUI()
         _HorizontalSize = 1
         _VerticalSize = 1

         _txbHorizontal.Text = _HorizontalSize.ToString()
         _txbVertical.Text = _VerticalSize.ToString()

         _tbHorizontal.Maximum = _RasImage.Width
         _tbHorizontal.Minimum = 1
         _tbVertical.Maximum = _RasImage.Height
         _tbVertical.Minimum = 1

      End Sub

      Private Sub UpdateCommand()
         _HorizontalSize = Convert.ToInt32(_txbHorizontal.Text)
         _VerticalSize = Convert.ToInt32(_txbVertical.Text)
      End Sub

      Private Sub _btnok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnok.Click
         UpdateCommand()
         Me.DialogResult = DialogResult.OK
         Me.Close()
      End Sub

      Private Sub _btncancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btncancel.Click
         InitializeUI()
         Me.DialogResult = DialogResult.Cancel
      End Sub

      Private Sub _txbHorizontal_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txbHorizontal.TextChanged
         Try
            _txbHorizontal.Text = MainForm.IsValidNumber(_txbHorizontal.Text, 1, _RasImage.Width)

            Dim Val As Integer = Integer.Parse(_txbHorizontal.Text)
            If Val >= _tbHorizontal.Minimum AndAlso Val <= _tbHorizontal.Maximum Then
               _tbHorizontal.Value = Val
            End If
         Catch
         End Try
      End Sub

      Private Sub _txbVertical_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txbVertical.TextChanged
         Try
            _txbVertical.Text = MainForm.IsValidNumber(_txbVertical.Text, 1, _RasImage.Height)

            Dim Val As Integer = Integer.Parse(_txbVertical.Text)
            If Val >= _tbVertical.Minimum AndAlso Val <= _tbVertical.Maximum Then
               _tbVertical.Value = Val
            End If
         Catch
         End Try
      End Sub

      Private Sub _tbHorizontal_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbHorizontal.Scroll
         _txbHorizontal.Text = _tbHorizontal.Value.ToString()
      End Sub

      Private Sub _tbVertical_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbVertical.Scroll
         _txbVertical.Text = _tbVertical.Value.ToString()
      End Sub


   End Class
End Namespace
