' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel
Imports System.Security
Imports Leadtools.Medical.UserManagementDataAccessLayer

Namespace Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
   Public Class PasswordRequestEventArgs : Inherits CancelEventArgs
      Private _password As SecureString
      Public Property Password() As SecureString
         Get
            Return _password
         End Get
         Set(ByVal value As SecureString)
            _password = value
         End Set
      End Property

      Private _expires As Nullable(Of DateTime)
      Public Property Expires() As Nullable(Of DateTime)
         Get
            Return _expires
         End Get
         Set(ByVal value As Nullable(Of DateTime))
            _expires = value
         End Set
      End Property

      Public Sub PasswordRequestEventArgs()
         Expires = Nothing
      End Sub
   End Class

   Public Class ValidatePasswordEventArgs : Inherits EventArgs
      Private _valid As Boolean
      Public Property Valid() As Boolean
         Get
            Return _valid
         End Get
         Set(ByVal value As Boolean)
            _valid = value
         End Set
      End Property
      Private _password As String
      Public Property Password() As String
         Get
            Return _password
         End Get
         Set(ByVal value As String)
            _password = value
         End Set
      End Property

      Private _confirmPassword As String
      Public Property ConfirmPassword() As String
         Get
            Return _confirmPassword
         End Get
         Set(ByVal value As String)
            _confirmPassword = value
         End Set
      End Property
   End Class

   Public Class EditUserPermissionsEventArgs : Inherits EventArgs
      Private _Username As String

      Public ReadOnly Property Username() As String
         Get
            Return _Username
         End Get
      End Property

      Private _Permissions As List(Of String) = New List(Of String)()

      Public ReadOnly Property Permissions() As List(Of String)
         Get
            Return _Permissions
         End Get
      End Property

      Public Sub New(ByVal username As String)
         _Username = username
      End Sub
   End Class
End Namespace
