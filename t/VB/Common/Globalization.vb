' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.IO
Imports Microsoft.Win32
Imports System.Drawing
Imports System.Windows.Forms

Imports Leadtools
Imports System.Diagnostics
Imports System.Security.Principal
Imports System.Reflection
Imports System.Threading
Imports System.Globalization
Imports System

Namespace Leadtools.Demos
   Friend Enum GlobalizationLanguage
      English
      Japanese
   End Enum

   Friend NotInheritable Class DemosGlobalization
      Private Sub New()
      End Sub
      Private Shared _strAdminPrivilege As String
      Private Shared _strDebuggerWarning As String
      Private Shared _strWarning As String
      Private Shared _strSelectOpFolder As String

      Shared Sub New()
         If GetCurrentThreadLanguage() = GlobalizationLanguage.Japanese Then
            _strAdminPrivilege = "This application needs to be run with administrator privileges"
            _strDebuggerWarning = "This will end your debugging session"
            _strWarning = "Warning"
            _strSelectOpFolder = "Select Output Folder"
         Else
            _strAdminPrivilege = "This application needs to be run with administrator privileges"
            _strDebuggerWarning = "This will end your debugging session"
            _strWarning = "Warning"
            _strSelectOpFolder = "Select Output Folder"
         End If
      End Sub

      Public Shared Function GetResxString(type As Type, stringName As String) As String
         Dim resources As New System.ComponentModel.ComponentResourceManager(type)
         Return resources.GetString(stringName)
      End Function

      Public Shared Function GetCurrentThreadLanguage() As GlobalizationLanguage
         If Thread.CurrentThread.CurrentCulture.Name = "ja-JP" Then
            Return GlobalizationLanguage.Japanese
         Else
            Return GlobalizationLanguage.English
         End If
      End Function

      Public Shared ReadOnly Property AdminPrivilege() As String
         Get
            Return _strAdminPrivilege
         End Get
      End Property

      Public Shared ReadOnly Property DebuggerWarning() As String
         Get
            Return _strDebuggerWarning
         End Get
      End Property

      Public Shared ReadOnly Property Warning() As String
         Get
            Return _strWarning
         End Get
      End Property

      Public Shared ReadOnly Property SelectOutputFolder() As String
         Get
            Return _strSelectOpFolder
         End Get
      End Property
   End Class
End Namespace
