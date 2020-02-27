' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Namespace ScreenCaptureDemo
   Friend Class Program
      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      Private Sub New()
      End Sub
      <STAThread()> _
      Shared Sub Main()
         ' unlock support
#If LEADTOOLS_V175_OR_LATER Then
        If Not Support.SetLicense() Then
            Return
         End If 
#Else
		 Support.Unlock(False)
#End If ' #if LEADTOOLS_V175_OR_LATER

         

         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)
         Application.Run(New MainForm())
      End Sub
   End Class
End Namespace
