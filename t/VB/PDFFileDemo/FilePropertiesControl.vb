' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.Pdf

Namespace PDFFileDemo
   Partial Public Class FilePropertiesControl : Inherits UserControl
      Public Sub New()
         InitializeComponent()
      End Sub

      Public Sub SetFileProperties(ByVal document As PDFFile)
         Try
            If PDFFile.IsEncrypted(document.FileName) Then
               _isEncryptedTextBox.Text = "Yes"
            Else
               _isEncryptedTextBox.Text = "No"
            End If
         Catch
            _isEncryptedTextBox.Text = "No"
         End Try

         Try
            _versionTextBox.Text = GetPDFFileTypeName(PDFFile.GetPDFFileType(document.FileName, True))
         Catch
            _versionTextBox.Text = GetPDFFileTypeName(PDFFileType.PDF14)
         End Try

         _numberOfPagesTextBox.Text = String.Format("{0} pages", document.Pages.Count)

         Dim inchesWidth As Double = document.Pages(0).Width / 72.0
         Dim inchesHeight As Double = document.Pages(0).Height / 72.0

         _pageSizeTextBox.Text = String.Format("{0} by {1} inches", inchesWidth, inchesHeight)

         Try
            If PDFFile.IsLinearized(document.FileName, Nothing) Then
               _isLinearizedTextBox.Text = "Yes"
            Else
               _isLinearizedTextBox.Text = "No"
            End If
         Catch
            _isLinearizedTextBox.Text = "No"
         End Try
      End Sub

      Private Shared Function GetPDFFileTypeName(ByVal fileType As PDFFileType) As String
         Select Case fileType
            Case PDFFileType.PDF10
               Return "PDF 1.0"
            Case PDFFileType.PDF11
               Return "PDF 1.1"
            Case PDFFileType.PDF12
               Return "PDF 1.2"
            Case PDFFileType.PDF13
               Return "PDF 1.3"
            Case PDFFileType.PDF14
               Return "PDF 1.4"
            Case PDFFileType.PDF15
               Return "PDF 1.5"
            Case PDFFileType.PDF16
               Return "PDF 1.6"
            Case PDFFileType.PDF17
               Return "PDF 1.7"
            Case Else
               Return "Unknown"
         End Select
      End Function
   End Class
End Namespace
