' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
Imports Leadtools.Medical.PermissionsManagement.DataAccessLayer
Imports Leadtools.Medical.DataAccessLayer
Imports Leadtools.Medical.PermissionsManagement.DataAccessLayer.Configuration
Imports Leadtools.DicomDemos
Imports Leadtools.Medical.Winforms
Imports Leadtools.Demos.StorageServer.DataTypes

Namespace Leadtools.Demos.StorageServer.UI
   Friend Class RolesViewPresenter
	  Private _RolesView As RolesView

	  Public Property View() As RolesView
		 Get
			 Return _RolesView
		 End Get
		 Set(ByVal value As RolesView)
			 _RolesView = value
		 End Set
	  End Property
	  Private _Initialized As Boolean = False

	  Public Sub RunView(ByVal view As RolesView)
		 EventBroker.Instance.Subscribe(Of ApplyServerSettingsEventArgs)(AddressOf OnUpdateServerSettings)

		 _RolesView = view
		 AddHandler _RolesView.Load, AddressOf _RolesView_Load
		 AddHandler _RolesView.SettingsChanged, AddressOf _RolesView_SettingsChanged
	  End Sub

	  Private Sub _RolesView_SettingsChanged(ByVal sender As Object, ByVal e As EventArgs)
		 View_SettingsChanged(Me, EventArgs.Empty)
	  End Sub

	  Private Sub _RolesView_Load(ByVal sender As Object, ByVal e As EventArgs)
		 Try
			If (Not _Initialized) Then
			   SetPermissions()
			   SetRoles()
			   _Initialized = True
			End If
		 Catch exception As Exception
			Messager.ShowError(_RolesView, exception)
		 End Try
	  End Sub

	  Private Sub SetPermissions()
		 Dim agent As IPermissionManagementDataAccessAgent = DataAccessFactory.GetInstance(New PermissionManagementDataAccessConfigurationView(DicomDemoSettingsManager.GetGlobalPacsConfiguration(), DicomDemoSettingsManager.ProductNameStorageServer, Nothing)).CreateDataAccessAgent(Of IPermissionManagementDataAccessAgent)()

		 _RolesView.SetPermissions(agent.GetPermissions())
	  End Sub

	  Private Sub SetRoles()
		 _RolesView.SetRoles(RoleManager.GetAllRoles())
	  End Sub

	  Public Event SettingsChanged As EventHandler

	  Private Sub View_SettingsChanged(ByVal sender As Object, ByVal e As EventArgs)
		 Try
		   RaiseEvent SettingsChanged(sender, e)
		 Catch e1 As Exception
			System.Diagnostics.Debug.Assert(False)
		 End Try
	  End Sub

	  Private Sub OnUpdateServerSettings(ByVal sender As Object, ByVal e As EventArgs)
		 Dim roles As New List(Of Role)(RoleManager.GetAllRoles())
		 Dim rolesAdded As New List(Of String)()

		 For Each delete As String In _RolesView.RolesToDelete
			RoleManager.DeleteRole(delete)
		 Next delete

		 For Each role As KeyValuePair(Of String, Role) In _RolesView.RolesToAdd
			Dim permissions As List(Of String) = ( _
					From rp In _RolesView.RolePermissions _
					Where rp.Key.ToLower() = role.Key.ToLower() _
					Select rp.Value).FirstOrDefault()

			role.Value.AssignedPermissions = If(permissions IsNot Nothing, permissions.ToArray(), New List(Of String)().ToArray())
			RoleManager.AddRole(role.Value)
			rolesAdded.Add(role.Key)
		 Next role

		 For Each role As String In rolesAdded
			_RolesView.RolesToAdd.Remove(role)
		 Next role

		 For Each roleEdit As KeyValuePair(Of String,List(Of String)) In _RolesView.RolePermissions
			Dim role As Role = ( _
					From r In roles _
					Where r.Name = roleEdit.Key _
					Select r).FirstOrDefault()

			If role IsNot Nothing Then
			   Dim permissions As List(Of String) = role.AssignedPermissions.ToList()
			   Dim deletes As List(Of String) = permissions.Except(roleEdit.Value).ToList()
			   Dim adds As List(Of String) = roleEdit.Value.Except(permissions).ToList()

			   If deletes.Count > 0 OrElse adds.Count > 0 Then
				  For Each delete As String In deletes
					 permissions.Remove(delete)
				  Next delete

				  For Each add As String In adds
					 permissions.Add(add)
				  Next add

				  role.AssignedPermissions = permissions.ToArray()
				  RoleManager.UpdateRole(role)
			   End If
			End If
		 Next roleEdit
	  End Sub
   End Class
End Namespace
