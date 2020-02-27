' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Ocr

Namespace OcrDemo.DocumentInfoControl
   Partial Public Class DocumentInfoControl
      Inherits UserControl
      Public Sub New()
         InitializeComponent()
      End Sub

      Public Sub RepopulateDocumentInformationControl(ocrDocument As IOcrDocument)
         _lvOcrDocumentInfo.Items(0).SubItems(1).Text = If((ocrDocument IsNot Nothing), (If((ocrDocument.IsInMemory), "Memory", "File")), "None")
         _lvOcrDocumentInfo.Items(1).SubItems(1).Text = String.Format("{0}", If((ocrDocument IsNot Nothing), ocrDocument.Pages.Count, 0))
      End Sub
   End Class
End Namespace
