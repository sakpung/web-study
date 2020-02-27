' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Leadtools.Dicom

Namespace DicomAnonymizer
   Friend Class Program
      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      Private Sub New()
      End Sub
      <STAThread()> _
      Shared Sub Main()

         

         If Not Support.SetLicense() Then
            Return
         End If

         DicomEngine.Startup()
         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)
         Application.Run(New MainForm())

         DicomEngine.Shutdown()
      End Sub
   End Class
End Namespace
