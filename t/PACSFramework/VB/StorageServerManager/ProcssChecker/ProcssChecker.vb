' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.IO

Namespace Leadtools.Demos.StorageServer
   Friend Class ProcessChecker
      Private Shared _requiredString As String

      Friend Class NativeMethods
         <DllImport("user32.dll")> _
         Public Shared Function ShowWindowAsync(ByVal hWnd As IntPtr, ByVal nCmdShow As Integer) As Boolean
         End Function

         <DllImport("user32.dll")> _
         Public Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As Boolean
         End Function

         <DllImport("user32.dll")> _
         Public Shared Function EnumWindows(ByVal lpEnumFunc As EnumWindowsProcDel, ByVal lParam As Int32) As Boolean
         End Function

         <DllImport("user32.dll")> _
         Public Shared Function GetWindowThreadProcessId(ByVal hWnd As IntPtr, ByRef lpdwProcessId As Int32) As Integer
         End Function

         <DllImport("user32.dll")> _
         Public Shared Function GetWindowText(ByVal hWnd As IntPtr, ByVal lpString As StringBuilder, ByVal nMaxCount As Int32) As Integer
         End Function

         <DllImport("user32.dll")> _
         Public Shared Function FindWindow(ByVal lpClassName As StringBuilder, ByVal lpWindowName As StringBuilder) As IntPtr
         End Function

         Public Const SW_SHOWNORMAL As Integer = 1
      End Class

      Public Delegate Function EnumWindowsProcDel(ByVal hWnd As IntPtr, ByVal lParam As Int32) As Boolean

      Private Sub New()
      End Sub
      Private Shared Function EnumWindowsProc(ByVal hWnd As IntPtr, ByVal lParam As Int32) As Boolean
         Dim processId As Integer = 0
         NativeMethods.GetWindowThreadProcessId(hWnd, processId)

         Dim caption As StringBuilder = New StringBuilder(1024)
         NativeMethods.GetWindowText(hWnd, caption, 1024)

         ' Use IndexOf to make sure our required string is in the title.
         If processId = lParam AndAlso (caption.ToString().IndexOf(_requiredString, StringComparison.OrdinalIgnoreCase) <> -1) Then
            ' Restore the window.
            NativeMethods.ShowWindowAsync(hWnd, NativeMethods.SW_SHOWNORMAL)
            NativeMethods.SetForegroundWindow(hWnd)
         End If
         Return True ' Keep this.
      End Function


      Public Shared Function IsOnlyProcess(ByVal forceTitle As String) As Boolean
         Dim exeName As String = Path.GetFileNameWithoutExtension(Application.ExecutablePath)
         Dim current As Process = Process.GetCurrentProcess()

         _requiredString = forceTitle

         For Each proc As Process In Process.GetProcessesByName(exeName)
            If proc.Id <> current.Id Then
               NativeMethods.EnumWindows(New EnumWindowsProcDel(AddressOf EnumWindowsProc), proc.Id)

               Dim windowHandle As IntPtr = NativeMethods.FindWindow(Nothing, New StringBuilder(proc.MainWindowTitle))

               Return False
            End If
         Next proc

         Return True
      End Function
   End Class
End Namespace
