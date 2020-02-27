' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms
Imports Leadtools.Demos
Imports Leadtools
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

      If RasterSupport.IsLocked(RasterSupportType.Basic) Then
         MessageBox.Show("Raster support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Return
      End If

      Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(False)
      Application.Run(New Form1())
   End Sub
End Class
