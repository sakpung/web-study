' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System
Imports Leadtools.Demos

Namespace PDFFormsDemo
   NotInheritable Class Program
      Private Sub New()
      End Sub
      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      <STAThread()> _
      Public Shared Sub Main()

         If (Not Support.SetLicense()) Then
            Return
         End If

         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)
         Application.Run(New MainForm())
      End Sub
   End Class
End Namespace
