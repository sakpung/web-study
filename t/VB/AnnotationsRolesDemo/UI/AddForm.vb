' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System

Namespace AnnotationsRolesDemo
   Partial Public Class AddForm : Inherits Form
      Public ReadOnly Property Value() As String
         Get
            Return _txtValue.Text
         End Get
      End Property
      Public Sub New(type As AddType)
         InitializeComponent()
         If type = AddType.Group Then
            label1.Text = "Group Name"
            Text = "Add Group"
         Else
            label1.Text = "User Name"
            Text = "Add User"
         End If
      End Sub
      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
         If Not String.IsNullOrEmpty(_txtValue.Text) Then
            DialogResult = DialogResult.OK
         End If
      End Sub
   End Class

   Public Enum AddType
      Group
      User
   End Enum
End Namespace
