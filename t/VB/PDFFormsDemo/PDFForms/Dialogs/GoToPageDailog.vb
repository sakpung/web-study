' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System

Namespace PDFFormsDemo
   Partial Public Class GoToPageDailog
      Inherits Form
      Private _pagesCount As Integer
      Public Sub New(currentPageIndex As Integer, pagesCount As Integer)
         InitializeComponent()

         _pagesCount = pagesCount
         _pageNumberTextBox.Text = (currentPageIndex + 1).ToString()

         _pagesCountLabel.Text = pagesCount.ToString()
      End Sub

      Private Sub _okButton_Click(sender As Object, e As EventArgs) Handles _okButton.Click
         Dim pageNumber__1 As Integer = 0
         Integer.TryParse(_pageNumberTextBox.Text, pageNumber__1)

         If pageNumber__1 > 0 AndAlso pageNumber__1 <= _pagesCount Then
            PageNumber = pageNumber__1
         Else
            MessageBox.Show("Please insert valid page number")
            Return
         End If

         Me.DialogResult = DialogResult.OK

         Me.Close()
      End Sub

      Private Sub _cancelButton_Click(sender As Object, e As EventArgs) Handles _cancelButton.Click
         Me.DialogResult = DialogResult.Cancel

         Me.Close()
      End Sub

      Public Property PageNumber() As Integer
         Get
            Return m_PageNumber
         End Get
         Set(value As Integer)
            m_PageNumber = value
         End Set
      End Property
      Private m_PageNumber As Integer
   End Class
End Namespace
