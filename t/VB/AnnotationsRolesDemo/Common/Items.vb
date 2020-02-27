' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.Text
Imports Leadtools.Annotations.Engine

Namespace AnnotationsRolesDemo
   Public NotInheritable Class CustomRoles
      Private Sub New()
      End Sub

      Public Const RulersOnly As String = "Rulers Only"
   End Class

   Public Class CheckRoleItem
      Public Sub New(role As String)
         _role = role
      End Sub

      Private _role As String

      Public ReadOnly Property Role() As String
         Get
            Return _role
         End Get
      End Property

      Public Overrides Function ToString() As String
         Dim role As String
         Select Case _role
            Case AnnRoles.View
               role = "View"
               Exit Select

            Case AnnRoles.ViewAll
               role = "View All"
               Exit Select

            Case AnnRoles.Edit
               role = "Edit"
               Exit Select

            Case AnnRoles.EditAll
               role = "Edit All"
               Exit Select

            Case CustomRoles.RulersOnly
               role = "Rulers Only"
               Exit Select
            Case Else

               role = "Full Control"
               Exit Select
         End Select
         Return role
         'return base.ToString();
      End Function
   End Class

   Public Class UserItem
      Public Sub New(name As String)
         _userName = name
      End Sub
      Private _userName As String

      Public ReadOnly Property Name() As String
         Get
            Return _userName
         End Get
      End Property

      Private _roles As New AnnRoles()
      Public ReadOnly Property Roles() As AnnRoles
         Get
            Return _roles
         End Get
      End Property

      Public Overrides Function ToString() As String
         Return _userName
      End Function
   End Class

   Public Class GroupItem
      Private _roles As AnnRoles = Nothing
      Public Sub New(name As String)
         _groupName = name
         _roles = New AnnRoles()
      End Sub

      Public Sub New(name As String, roles As AnnRoles)
         _groupName = name
         _roles = roles
      End Sub

      Private _groupName As String

      Public ReadOnly Property Name() As String
         Get
            Return _groupName
         End Get
      End Property


      Public ReadOnly Property Roles() As AnnRoles
         Get
            Return _roles
         End Get
      End Property

      Public Overrides Function ToString() As String
         Return _groupName
      End Function
   End Class
End Namespace
