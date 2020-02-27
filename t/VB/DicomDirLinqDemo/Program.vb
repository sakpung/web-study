' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports VBDicomDirLinqDemo.UI
Imports Leadtools.Dicom
Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports Leadtools

Namespace VBDicomDirLinqDemo
   Public NotInheritable Class Program
      Private Sub New()
      End Sub
      Shared Sub New()
         DicomEngine.Startup()
      End Sub

      <DllImport("user32.dll")> _
      Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
      End Function

      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      <STAThread()> _
      Public Shared Sub Main()
         
         If Not Support.SetLicense() Then
            Return
         End If

         If RasterSupport.IsLocked(RasterSupportType.Medical) Then
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.Medical.ToString()), "Warning")
            Return
         End If

         Dim created As Boolean = False
         Dim m As New Mutex(True, "DicomDirLinqDemo", created)

         If created Then
            AddHandler Application.ApplicationExit, AddressOf Application_ApplicationExit
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New MainForm())

            GC.KeepAlive(m)
         Else
            Dim current As Process = Process.GetCurrentProcess()

            For Each process As Process In process.GetProcessesByName(current.ProcessName)
               If process.Id <> current.Id Then
                  SetForegroundWindow(process.MainWindowHandle)
                  Exit For
               End If
            Next process
         End If
      End Sub

      Private Shared Sub Application_ApplicationExit(ByVal sender As Object, ByVal e As EventArgs)
         DicomEngine.Shutdown()
      End Sub
   End Class
End Namespace
