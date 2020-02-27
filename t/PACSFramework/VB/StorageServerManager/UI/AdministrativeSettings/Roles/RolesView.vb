' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Medical.PermissionsManagement.DataAccessLayer
Imports Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
Imports Leadtools.Demos.StorageServer.Extensions
Imports Microsoft.VisualBasic

Namespace Leadtools.Demos.StorageServer.UI
   Partial Public Class RolesView
	   Inherits UserControl
	  Private _RolePermissions As New Dictionary(Of String, List(Of String))()

	  Public ReadOnly Property RolePermissions() As Dictionary(Of String, List(Of String))
		 Get
			Return _RolePermissions
		 End Get
	  End Property

	  Private _RolesToDelete As New List(Of String)()

	  Public ReadOnly Property RolesToDelete() As List(Of String)
		 Get
			Return _RolesToDelete
		 End Get
	  End Property

	  Private _RolesToAdd As New Dictionary(Of String, Role)()

	  Public ReadOnly Property RolesToAdd() As Dictionary(Of String, Role)
		 Get
			Return _RolesToAdd
		 End Get
	  End Property

	  Public Event SettingsChanged As EventHandler

	  Private Sub OnSettingsChanged()
		RaiseEvent SettingsChanged(Me, EventArgs.Empty)
	  End Sub

	  Public Sub New()
		 InitializeComponent()
		 listViewPermissions.Columns(0).Width = listViewPermissions.ClientRectangle.Width-2
	  End Sub

	  Public Sub SetRoles(ByVal roles() As Role)
		 For Each role As Role In roles
			AddRole(role)
		 Next role

		 If comboBoxRoles.Items.Count > 0 Then
			comboBoxRoles.SelectedIndex = 0
			comboBoxRoles_SelectionChangeCommitted(comboBoxRoles, EventArgs.Empty)
		 End If
	  End Sub

	  Private Sub AddRole(ByVal role As Role)
		 comboBoxRoles.Items.Add(role)
		 _RolePermissions(role.Name) = New List(Of String)()
		 _RolePermissions(role.Name).AddRange(role.AssignedPermissions)
	  End Sub

	  Public Sub SetPermissions(ByVal permissions() As Permission)
		 RemoveHandler listViewPermissions.ItemChecked, AddressOf listViewPermissions_ItemChecked
		 For Each permission As Permission In permissions
			Dim item As ListViewItem = listViewPermissions.Items.Add(permission.Name)

			item.Tag = permission
		 Next permission
		 AddHandler listViewPermissions.ItemChecked, AddressOf listViewPermissions_ItemChecked
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

	  Private Sub comboBoxRoles_SelectionChangeCommitted(ByVal sender As Object, ByVal e As EventArgs) Handles comboBoxRoles.SelectionChangeCommitted
		 Dim role As Role = TryCast(comboBoxRoles.SelectedItem, Role)

		 If role IsNot Nothing Then
			CheckRolePermissions(role)
			listViewPermissions.Enabled = Not RoleManager.BuiltInRoles.Contains(role)
			buttonDelete.Enabled = listViewPermissions.Enabled
		 End If
	  End Sub

	  Private Sub CheckRolePermissions(ByVal role As Role)
         RemoveHandler listViewPermissions.ItemChecked, AddressOf listViewPermissions_ItemChecked
         UncheckAll(listViewPermissions)

		 If role.Name = "Administrators" Then
            CheckAll(listViewPermissions)
		 Else
			For Each permission As String In _RolePermissions(role.Name).AsReadOnly()
			   Dim item As ListViewItem = FindPermission(permission)

			   If item IsNot Nothing Then
				  item.Checked = True
			   End If
			Next permission
		 End If
		 AddHandler listViewPermissions.ItemChecked, AddressOf listViewPermissions_ItemChecked
	  End Sub

	  Private Sub listViewPermissions_ItemChecked(ByVal sender As Object, ByVal e As ItemCheckedEventArgs) Handles listViewPermissions.ItemChecked
		 Dim role As Role = TryCast(comboBoxRoles.SelectedItem, Role)

		 If role IsNot Nothing Then
			Dim permission As Permission = TryCast(e.Item.Tag, Permission)

			If e.Item.Checked Then
			   _RolePermissions(role.Name).Add(permission.Name)
			Else
			   _RolePermissions(role.Name).Remove(permission.Name)
			End If
			OnSettingsChanged()
		 End If
	  End Sub

	  Private Sub buttonDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonDelete.Click
		 Dim role As Role = TryCast(comboBoxRoles.SelectedItem, Role)
		 Dim selectedIndex As Integer = comboBoxRoles.SelectedIndex

		 comboBoxRoles.Items.RemoveAt(selectedIndex)
		 If selectedIndex >= 1 Then
			comboBoxRoles.SelectedIndex = selectedIndex - 1
			comboBoxRoles_SelectionChangeCommitted(comboBoxRoles, EventArgs.Empty)
		 End If
		 If _RolesToAdd.ContainsKey(role.Name.ToLower()) Then
			_RolesToAdd.Remove(role.Name.ToLower())
		 Else
			_RolesToDelete.Add(role.Name)
		 End If

		 OnSettingsChanged()
	  End Sub

	  Private Sub buttonAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonAdd.Click
		 Dim role As String = String.Empty
		 Dim input As Boolean = True

		 Do While input
			If DialogUtilities.InputBox("Add Role", "Role Name: ", role) = DialogResult.OK Then
			   If (Not RoleExists(role)) Then
				  Dim r As New Role(role, String.Empty)

				  r.AssignedPermissions = New List(Of String)().ToArray()
				  AddRole(r)
				  _RolesToAdd.Add(r.Name.ToLower(), r)
				  comboBoxRoles.SelectedItem = r
				  comboBoxRoles_SelectionChangeCommitted(comboBoxRoles, EventArgs.Empty)
				  OnSettingsChanged()
				  input = False
			   Else
				  Messager.Show(Me, String.Format("Role {0} already exists. Please choose another name.", role), MessageBoxIcon.Error, MessageBoxButtons.OK)
			   End If
			Else
			   input = False
			End If
		 Loop
	  End Sub

	  Private Function RoleExists(ByVal roleName As String) As Boolean
		 Dim role As Role = ( _
		 		From r In comboBoxRoles.Items.Cast(Of Role)() _
		 		Where r.Name.ToLower() = roleName _
		 		Select r).FirstOrDefault()

		 Return role IsNot Nothing
	  End Function
   End Class
End Namespace
