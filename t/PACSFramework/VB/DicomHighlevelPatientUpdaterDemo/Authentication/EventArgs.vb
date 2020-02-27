' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace DicomDemo.Authentication
   Public Class ValidatePasswordEventArgs
      Inherits EventArgs
      Public Property Valid() As Boolean
         Get
            Return m_Valid
         End Get
         Set(ByVal value As Boolean)
            m_Valid = value
         End Set
      End Property
      Private m_Valid As Boolean
      Public Property Password() As String
         Get
            Return m_Password
         End Get
         Set(ByVal value As String)
            m_Password = value
         End Set
      End Property
      Private m_Password As String
      Public Property ConfirmPassword() As String
         Get
            Return m_ConfirmPassword
         End Get
         Set(ByVal value As String)
            m_ConfirmPassword = value
         End Set
      End Property
      Private m_ConfirmPassword As String
   End Class
End Namespace
