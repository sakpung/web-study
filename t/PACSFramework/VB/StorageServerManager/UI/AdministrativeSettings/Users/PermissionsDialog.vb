' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Medical.UserManagementDataAccessLayer
Imports Leadtools.Medical.PermissionsManagement.DataAccessLayer

Namespace Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
   Partial Friend Class PermissionsDialog : Inherits Form
      Private _Username As String = String.Empty

      Public Property Username() As String
         Get
            Return _Username
         End Get
         Set(ByVal value As String)
            _Username = value
         End Set
      End Property

      Private _SelectedPermissions As List(Of String) = New List(Of String)()

      Public ReadOnly Property SelectedPermissions() As List(Of String)
         Get
            Return _SelectedPermissions
         End Get
      End Property

      Public Sub New()
         InitializeComponent()
      End Sub

      Public Sub SetPermissions(ByVal availablePermissions As Permission(), ByVal userPermission As List(Of String))
         listViewPermissions.Items.Clear()
         For Each permission As Permission In availablePermissions
            Dim item As ListViewItem = New ListViewItem(permission.Name)

            item.SubItems.Add(permission.Description)
            item.Tag = permission
            item.Checked = userPermission.Contains(permission.Name)
            listViewPermissions.Items.Add(item)
         Next permission
      End Sub

      Private Sub PermissionsDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         SizeColumns()
      End Sub

      Private Sub SizeColumns()
         Dim width As Integer = listViewPermissions.ClientRectangle.Width

         For Each column As ColumnHeader In listViewPermissions.Columns
            column.Width = CType(width / listViewPermissions.Columns.Count, Integer)
         Next column
      End Sub

      Private Function FindPermission(ByVal name As String) As ListViewItem
         For Each item As ListViewItem In listViewPermissions.Items
            Dim permission As Permission = TryCast(item.Tag, Permission)

            If permission.Name = name Then
               Return item
            End If
         Next item
         Return Nothing
      End Function

      Private Sub PermissionsDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         If DialogResult = DialogResult.OK Then
            For Each item As ListViewItem In listViewPermissions.CheckedItems
               Dim permission As Permission = TryCast(item.Tag, Permission)

               _SelectedPermissions.Add(permission.Name)
            Next item
         End If
      End Sub
   End Class
End Namespace
