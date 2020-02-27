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

Imports Leadtools.Ocr

Namespace OcrDemo
   Partial Public Class EngineSettingsDialog
      Inherits Form
      Public Sub New(ocrEngine As IOcrEngine)
         InitializeComponent()

         _ocrEngineSettingsControl.SetEngine(ocrEngine)
      End Sub
   End Class
End Namespace
