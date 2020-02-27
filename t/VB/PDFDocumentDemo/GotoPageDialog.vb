' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Namespace PDFDocumentDemo
   Partial Public Class GotoPageDialog : Inherits Form
      Public Sub New()
         InitializeComponent()
      End Sub

      Public DocumentPage As Integer
      Public DocumentPageCount As Integer

      Protected Overrides Sub OnLoad(ByVal e As EventArgs)
         If (Not DesignMode) Then
            _pageCountLabel.Text = _pageCountLabel.Text.Replace("##", DocumentPageCount.ToString())
            _pageNumericUpDown.Maximum = DocumentPageCount
            _pageNumericUpDown.Value = DocumentPage
         End If

         MyBase.OnLoad(e)
      End Sub

      Private Sub _okButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _okButton.Click
         DocumentPage = CInt(_pageNumericUpDown.Value)
      End Sub
   End Class
End Namespace
