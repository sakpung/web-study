' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Reflection
Imports System.Windows.Forms

Namespace VBLEADUniversalViewer
   Friend Class Program
      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      Private Sub New()
      End Sub
      <STAThread()> _
      Shared Sub Main()
         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)
         'Check if the Multimedia DLL is available in the current directory
         Try
            Dim [assembly] As System.Reflection.Assembly = System.Reflection.Assembly.LoadFrom("Leadtools.Multimedia.dll")
            Application.Run(New MainForm())
         Catch e1 As System.IO.FileNotFoundException
            Dim MsgBoxRes As DialogResult = MessageBox.Show("LEADTOOLS Multimedia SDK is not installed. Please download and install it to continue using this demo." & Microsoft.VisualBasic.Constants.vbLf & "Do you want to download LEADTOOLS Multimedia SDK?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)

            If MsgBoxRes = System.Windows.Forms.DialogResult.Yes Then
               System.Diagnostics.Process.Start("https://www.leadtools.com/downloads?category=mm")
            Else
               Return
            End If
         End Try
      End Sub
   End Class
End Namespace
