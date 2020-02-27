' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Leadtools

Namespace HL7Messaging
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

         If RasterSupport.IsLocked(RasterSupportType.Hl7) Then
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.Hl7.ToString()), "Warning")
            Return
         End If

         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)
         Application.Run(New MainView())
      End Sub
   End Class
End Namespace

