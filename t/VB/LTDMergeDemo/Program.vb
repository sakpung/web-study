' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Leadtools.Demos
Imports System

NotInheritable Class Program
   Private Sub New()
   End Sub
   ''' <summary>
   ''' The main entry point for the application.
   ''' </summary>
   <STAThread()> _
   Shared Sub Main()

      If Not Support.SetLicense() Then
         Return
      End If

      Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(False)
      Application.Run(New LTDMergeDialog())
   End Sub
End Class
