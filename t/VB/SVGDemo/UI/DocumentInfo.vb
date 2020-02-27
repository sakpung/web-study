' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Windows.Forms

Imports Leadtools.Svg
Imports System

Namespace SvgDemo
   Partial Public Class DocumentInfo
      Inherits Form
      Private _document As SvgDocument
      Private _fileName As String
      Private _pageNumber As Integer
      Private _totalPages As Integer

      Public Sub New(document As SvgDocument, fileName As String, pageIndex As Integer, totalPages As Integer)
         InitializeComponent()
         _document = document
         _fileName = fileName
         _pageNumber = pageIndex + 1
         _totalPages = totalPages
      End Sub

      Private Sub DocumentInfo_Load(sender As Object, e As EventArgs) Handles Me.Load
         For i As Integer = 0 To _documentInfo.Items.Count - 1
            _documentInfo.Items(i).SubItems.Add(String.Empty)
         Next

         _documentInfo.Items(0).SubItems(1).Text = _fileName
         _documentInfo.Items(1).SubItems(1).Text = _pageNumber.ToString()
         _documentInfo.Items(2).SubItems(1).Text = _totalPages.ToString()
         _documentInfo.Items(3).SubItems(1).Text = _document.IsFlat.ToString()
         _documentInfo.Items(4).SubItems(1).Text = _document.IsRenderOptimized.ToString()
         Dim bounds As SvgBounds = _document.Bounds
         _documentInfo.Items(7).SubItems(1).Text = bounds.IsValid.ToString()
         _documentInfo.Items(8).SubItems(1).Text = bounds.IsTrimmed.ToString()
         _documentInfo.Items(9).SubItems(1).Text = bounds.Resolution.ToString()
         _documentInfo.Items(10).SubItems(1).Text = bounds.Bounds.ToString()
      End Sub

      Private Sub _closeButton_Click(sender As Object, e As EventArgs) Handles _closeButton.Click
         Close()
      End Sub
   End Class
End Namespace
