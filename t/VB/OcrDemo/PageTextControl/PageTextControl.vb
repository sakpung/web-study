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

Namespace OcrDemo.PageTextControl
   Partial Public Class PageTextControl
      Inherits UserControl
      Public Sub New()
         InitializeComponent()
      End Sub

      Public Sub SetPageText(pageText As String)
         _tbPageText.Text = pageText
      End Sub
   End Class
End Namespace
