' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Net
Imports System.Security.Principal
Imports System.Windows.Forms
Imports Microsoft.Win32
Imports System

Namespace Leadtools.Demos
   Public NotInheritable Class DemoUtils
      Private Sub New()
      End Sub
      Public Shared Function IsAlreadyRunning() As Boolean
         Dim alreadyRunning As Boolean = False
         Dim currentProcess As Process = Process.GetCurrentProcess()
         Dim processes As Process() = Process.GetProcessesByName(currentProcess.ProcessName)
         For Each process__1 As Process In processes
            If process__1.MainModule.ModuleName = currentProcess.MainModule.ModuleName Then
               If alreadyRunning Then
                  Return True
               End If

               alreadyRunning = True
            End If
         Next
         Return False
      End Function


      Public Shared Function CheckAdminRights() As Boolean
         Dim elevate As Boolean = False

         Dim needUAC As Boolean = False

         ' Check if we need UAC to elevate the rights
         Dim os As OperatingSystem = Environment.OSVersion
         If os.Platform = PlatformID.Win32NT AndAlso os.Version.Major >= 6 Then
            needUAC = True
         Else
            needUAC = False
         End If

         If needUAC Then
            ' Check if we are not running in admin mode
            Dim wi As WindowsIdentity = WindowsIdentity.GetCurrent()
            Dim wp As New WindowsPrincipal(wi)

            If Not wp.IsInRole(WindowsBuiltInRole.Administrator) Then
               elevate = True
            End If
         End If

         Return Not elevate
      End Function

      Public Shared Function OpenSoftwareKey(keyName As String) As RegistryKey
         Dim key As RegistryKey = Registry.LocalMachine.OpenSubKey(Convert.ToString("SOFTWARE\Wow6432Node\") & keyName)
         If key Is Nothing Then
            key = Registry.LocalMachine.OpenSubKey(Convert.ToString("SOFTWARE\") & keyName)
            If key Is Nothing Then
               key = Registry.CurrentUser.OpenSubKey(Convert.ToString("SOFTWARE\") & keyName)
            End If
         End If

         Return key
      End Function

      Public Shared Function IsDotNet35Installed() As Boolean
         Dim ret As Boolean = False
         Dim rk As RegistryKey = OpenSoftwareKey("\Microsoft\NET Framework Setup\NDP\v3.5")
         If rk IsNot Nothing Then
            ret = True
            rk.Close()
         Else

            ret = False
         End If
         Return ret
      End Function

      Public Shared Function GetMachineIP() As String
         Dim address As String = ""
         Dim hostEntry As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())

         Dim Addresses As IPAddress() = hostEntry.AddressList

         For i As Integer = 0 To Addresses.Length - 1
            If Addresses(i).AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
               address = Addresses(i).ToString()
            End If
         Next

         Return address
      End Function
   End Class
End Namespace
