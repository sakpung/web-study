' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System
Imports Leadtools

Namespace OcrDemo
   NotInheritable Class Program
      Private Sub New()
      End Sub
      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      <STAThread()> _
      Shared Sub Main()
         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)

         

         If Not Support.SetLicense() Then
            Return
         End If

         Dim bOCRLocked As Boolean = RasterSupport.IsLocked(RasterSupportType.OcrLEAD)
         If bOCRLocked Then
            MessageBox.Show("OCR support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         End If

         Dim bDocLocked As Boolean = RasterSupport.IsLocked(RasterSupportType.Document)
         If bDocLocked Then
            MessageBox.Show("Document support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         End If

         If bDocLocked Or bOCRLocked Then
            Return
         End If

         Application.Run(New MainForm())
      End Sub
   End Class
End Namespace
