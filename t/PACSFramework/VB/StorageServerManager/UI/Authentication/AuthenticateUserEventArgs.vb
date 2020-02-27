' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Security
Imports System.ComponentModel

Namespace Leadtools.Demos.StorageServer.UI.Authentication
   Public Class AuthenticateUserEventArgs : Inherits CancelEventArgs
      Private _Username As String

      Public ReadOnly Property Username() As String
         Get
            Return _Username
         End Get
      End Property

      Private _Password As SecureString

      Public ReadOnly Property Password() As SecureString
         Get
            Return _Password
         End Get
      End Property

      Private _InvalidCredentials As Boolean

      Public Property InvalidCredentials() As Boolean
         Get
            Return _InvalidCredentials
         End Get
         Set(ByVal value As Boolean)
            _InvalidCredentials = Value
         End Set
      End Property

      Public Sub New(ByVal myUsername As String, ByVal myPassword As SecureString)
         _Username = myUsername
         _Password = myPassword
      End Sub
   End Class
End Namespace
