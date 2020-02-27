' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System

Namespace SvgDemo
   Partial Public Class SelectPage
      Inherits Form
      Private _totalPages As Integer
      Private _selectedPage As Integer = 1
      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub SelectPage_Load(sender As Object, e As EventArgs) Handles Me.Load
         _pageNumberTextBox.Text = _selectedPage.ToString()
      End Sub

      Public Property TotalPage() As Integer
         Get
            Return _totalPages
         End Get
         Set(value As Integer)
            _totalPages = value
         End Set
      End Property

      Public Property SelectedPageNumber() As Integer
         Get
            Return _selectedPage
         End Get
         Set(value As Integer)
            _selectedPage = value
         End Set
      End Property

      Private Sub _pageNumberTextBox_TextChanged(sender As Object, e As EventArgs) Handles _pageNumberTextBox.TextChanged
         Try
            Dim val As Integer = Integer.Parse(_pageNumberTextBox.Text)
            If val >= 1 AndAlso val <= _totalPages Then
               SelectedPageNumber = val
            Else
               _pageNumberTextBox.Text = SelectedPageNumber.ToString()
               MessageBox.Show(String.Format("Please select page betwee 1 and {0}", _totalPages))
            End If
         Catch
         End Try
      End Sub

      Private Sub _pageNumberTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _pageNumberTextBox.KeyPress
         If Not e.Handled Then
            If Not [Char].IsControl(e.KeyChar) AndAlso Not [Char].IsDigit(e.KeyChar) Then
               e.Handled = True
            End If
         End If
      End Sub
   End Class
End Namespace
