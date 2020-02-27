' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Security.Principal
Imports System.Threading
Imports Microsoft.SqlServer.MessageBox
Imports System.Windows.Forms

Namespace DicomDemo.Utils
   Public Enum LogonTypes As UInteger
      Interactive = 2
      Network
      Batch
      Service
      NetworkCleartext = 8
      NewCredentials
   End Enum

   Public Enum LogonProviders As UInteger
      [Default] = 0 ' default for platform (use this!)
      WinNT35 ' sends smoke signals to authority
      WinNT40 ' uses NTLM
      WinNT50 ' negotiates Kerb or NTLM
   End Enum

   Public Class ApplicationUtils
      <DllImport("kernel32.dll", SetLastError:=True)> _
      Public Shared Function CloseHandle(ByVal handle As IntPtr) As Boolean
      End Function

      <DllImport("advapi32.dll", SetLastError:=True)> _
      Public Shared Function LogonUser(ByVal principal As String, ByVal authority As String, ByVal password As String, ByVal logonType As LogonTypes, ByVal logonProvider As LogonProviders, <System.Runtime.InteropServices.Out()> ByRef token As IntPtr) As Boolean
      End Function

      Private Sub New()
      End Sub
      Public Shared Function Login(ByVal domain As String, ByVal user As String, ByVal password As String) As Boolean
         Dim token As IntPtr
         Dim id As WindowsIdentity

         Dim result As Boolean = LogonUser(user, domain, password, LogonTypes.Interactive, LogonProviders.Default, token)

         If (Not result) Then
            Return False
         End If

         id = New WindowsIdentity(token)
         CloseHandle(token)
         Dim p As WindowsPrincipal = New WindowsPrincipal(id)
         Thread.CurrentPrincipal = p

         Return True
      End Function

      Public Shared Sub SynchronizedInvoke(ByVal owner As Control, ByVal del As MethodInvoker)
         If Not owner Is Nothing AndAlso owner.InvokeRequired Then
            owner.BeginInvoke(del, Nothing)
         Else
            del()
         End If
      End Sub

      Public Shared Sub ShowException(ByVal owner As Control, ByVal e As Exception)
         Dim msgBox As New ExceptionMessageBox(e)

         SynchronizedInvoke(owner, Function() msgBox.Show(owner))
      End Sub
   End Class
End Namespace
