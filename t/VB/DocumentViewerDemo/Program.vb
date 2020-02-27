' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Windows.Forms
Imports Leadtools

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

      If RasterSupport.IsLocked(RasterSupportType.Document) Then
         MessageBox.Show("Document support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Return
      End If

      Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(False)
      Application.Run(New MainForm())
   End Sub
End Class
