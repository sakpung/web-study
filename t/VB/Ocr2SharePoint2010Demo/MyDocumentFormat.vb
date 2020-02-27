' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Imports Leadtools.Document.Writer

Namespace Ocr2SharePointDemo
   Public Enum MyDocumentFormat
	  PDF
	  PDFImageOverText
	  DOCX
	  DOC
	  TEXT
   End Enum

   Public Class MyDocumentFormatItem
	  Public Title As String
	  Public FormatType As MyDocumentFormat

	  Public Sub New(ByVal t As String, ByVal f As MyDocumentFormat)
		 Title = t
		 FormatType = f
	  End Sub

	  Public Overrides Function ToString() As String
		 Return Title
	  End Function

	  Public Shared Function GetExtension(ByVal format As MyDocumentFormat) As String
		 Select Case format
			Case MyDocumentFormat.DOC
			   Return "doc"

			Case MyDocumentFormat.DOCX
			   Return "docx"

			Case MyDocumentFormat.TEXT
			   Return "txt"

			Case Else
			   Return "pdf"
		 End Select
	  End Function

	  Public Shared ReadOnly DefaultItems As MyDocumentFormatItem() = { New MyDocumentFormatItem("Adobe Portable Format (PDF)", MyDocumentFormat.PDF), New MyDocumentFormatItem("Adobe Portable Format (PDF) with Image over Text", MyDocumentFormat.PDFImageOverText), New MyDocumentFormatItem("Microsoft Word 2007 (DOCX)", MyDocumentFormat.DOCX), New MyDocumentFormatItem("Microsoft Word 2003 (DOC)", MyDocumentFormat.DOC), New MyDocumentFormatItem("Text (TXT)", MyDocumentFormat.TEXT) }
   End Class
End Namespace
