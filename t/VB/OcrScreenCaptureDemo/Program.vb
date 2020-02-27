' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System
Imports System.Runtime.InteropServices
Imports System.Diagnostics

Namespace OcrScreenCaptureDemo
    NotInheritable Class Program
        <DllImport("user32.dll")> _
        Private Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As Boolean
        End Function
        <DllImport("user32.dll")> _
        Private Shared Function ShowWindowAsync(ByVal hWnd As IntPtr, ByVal nCmdShow As Integer) As Boolean
        End Function
        <DllImport("user32.dll")> _
        Private Shared Function IsIconic(ByVal hWnd As IntPtr) As Boolean
        End Function
        Private Sub New()
        End Sub
        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread()> _
        Shared Sub Main()
            Dim proc As String = Process.GetCurrentProcess().ProcessName
            Dim processes As Process() = Process.GetProcessesByName(proc)
            If processes.Length > 1 Then
                Dim p As Process = Process.GetCurrentProcess()
                Dim n As Integer = 0
                If processes(0).Id = p.Id Then
                    n = 1
                End If

                Dim hWnd As IntPtr = processes(n).MainWindowHandle
                If IsIconic(hWnd) Then
                    ShowWindowAsync(hWnd, 9)
                End If
                SetForegroundWindow(hWnd)
                Return
            End If

            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)

            

            If Not Support.SetLicense() Then
                Return
            End If

            Application.Run(New MainForm())
        End Sub
    End Class
End Namespace
