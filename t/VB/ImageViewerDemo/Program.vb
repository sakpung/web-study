' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Demos
Imports System

NotInheritable Class Program
   Private Sub New()
   End Sub
   ''' <summary>
   ''' The main entry point for the application.
   ''' </summary>
   <STAThread()> _
   Public Shared Sub Main()
      Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(False)

      If Not Support.SetLicense() Then
         Return
      End If

      If RasterSupport.IsLocked(RasterSupportType.Document) Then
         MessageBox.Show("Document support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Return
      End If

      Application.Run(New MainForm())
   End Sub
End Class
