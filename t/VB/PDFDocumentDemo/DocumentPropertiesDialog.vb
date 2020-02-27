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
Imports Leadtools.Pdf
Imports PDFDocumentDemo.Leadtools.Demos

Namespace PDFDocumentDemo
   Partial Public Class DocumentPropertiesDialog
      Inherits Form

      Private _document As PDFDocument
      Private _file As PDFFile

      Public Sub New(ByVal document As PDFDocument, ByVal file As PDFFile)
         InitializeComponent()
         _document = document
         _file = file
      End Sub

      Protected Overrides Sub OnLoad(ByVal e As EventArgs)
         If Not DesignMode Then

            Try
               Dim pdfProperties As PDFDocumentProperties

               If _document IsNot Nothing Then
                  _fileNameTextBox.Text = _document.FileName
                  _isEncryptedTextBox.Text = If(_document.IsEncrypted, DemosGlobalization.GetResxString([GetType](), "resx_Yes"), DemosGlobalization.GetResxString([GetType](), "resx_No"))
                  _isLinearizedTextBox.Text = If(_document.IsLinearized, DemosGlobalization.GetResxString([GetType](), "resx_Yes"), DemosGlobalization.GetResxString([GetType](), "resx_No"))
                  _isPdfATextBox.Text = If(_document.IsPdfA, DemosGlobalization.GetResxString([GetType](), "resx_Yes"), DemosGlobalization.GetResxString([GetType](), "resx_No"))
                  _versionTextBox.Text = GetPDFFileTypeName(_document.FileType)
                  _numberOfPagesTextBox.Text = String.Format("{0} {1}", _document.Pages.Count, DemosGlobalization.GetResxString([GetType](), "resx_Pages"))
                  Dim inchesWidth As Double = _document.Pages(0).WidthInches
                  Dim inchesHeight As Double = _document.Pages(0).HeightInches
                  _pageSizeTextBox.Text = String.Format("{0} {1} {2} {3}", inchesWidth, DemosGlobalization.GetResxString([GetType](), "resx_By"), inchesHeight, DemosGlobalization.GetResxString([GetType](), "resx_Inches"))
                  pdfProperties = _document.DocumentProperties
               Else
                  _fileNameTextBox.Text = _file.FileName
                  _isEncryptedTextBox.Text = If(PDFFile.IsEncrypted(_file.FileName), DemosGlobalization.GetResxString([GetType](), "resx_Yes"), DemosGlobalization.GetResxString([GetType](), "resx_No"))

                  Try
                     _isLinearizedTextBox.Text = If(PDFFile.IsLinearized(_file.FileName, Nothing), DemosGlobalization.GetResxString([GetType](), "resx_Yes"), DemosGlobalization.GetResxString([GetType](), "resx_No"))
                  Catch
                     _isLinearizedTextBox.Text = DemosGlobalization.GetResxString([GetType](), "resx_No")
                  End Try

                  _isPdfATextBox.Text = If(PDFFile.IsPdfA(_file.FileName), DemosGlobalization.GetResxString([GetType](), "resx_Yes"), DemosGlobalization.GetResxString([GetType](), "resx_No"))
                  _versionTextBox.Text = GetPDFFileTypeName(PDFFile.GetPDFFileType(_file.FileName, True))
                  _numberOfPagesTextBox.Text = String.Format("{0} pages", _file.Pages.Count)
                  Dim inchesWidth As Double = _file.Pages(0).Width
                  Dim inchesHeight As Double = _file.Pages(0).Height
                  _pageSizeTextBox.Text = String.Format("{0} {1} {2} {3}", inchesWidth, DemosGlobalization.GetResxString([GetType](), "resx_By"), inchesHeight, DemosGlobalization.GetResxString([GetType](), "resx_Inches"))
                  pdfProperties = _file.DocumentProperties
               End If

               _documentPropertiesControl.SetDocumentProperties(pdfProperties, True)
            Catch ex As Exception
               Messager.ShowError(Me, ex)
            End Try
         End If

         MyBase.OnLoad(e)
      End Sub

      Private Function GetPDFFileTypeName(ByVal fileType As PDFFileType) As String
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
