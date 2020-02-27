' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Windows.Forms

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
      Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(False)
      Application.Run(New MainForm())
   End Sub
End Class
