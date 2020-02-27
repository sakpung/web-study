' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Medical.PermissionsManagement.DataAccessLayer
Imports System.Collections.ObjectModel
Imports Leadtools.Medical.DataAccessLayer
Imports Leadtools.Medical.DataAccessLayer.Configuration
Imports Leadtools.Medical.PermissionsManagement.DataAccessLayer.Configuration
Imports Leadtools.DicomDemos

Namespace Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
   Public NotInheritable Class RoleManager
	  Private Shared _BuiltInRoles As New List(Of Role)()
	  Private Shared permissionsAgent As IPermissionManagementDataAccessAgent2

	  Private Sub New()
	  End Sub
	  Public Shared ReadOnly Property BuiltInRoles() As ReadOnlyCollection(Of Role)
		 Get
			Return _BuiltInRoles.AsReadOnly()
		 End Get
	  End Property

	  Public Shared ReadOnly Admin As New Role() With {.Name = "Administrators", .Description = "Web viewer administrator, full permissions.", .AssignedPermissions = PermissionsTable.Instance.PermissionsNames.ToArray()}

	  Shared Sub New()
		 _BuiltInRoles.Add(Admin)
		 permissionsAgent = GetDataAccess(Of IPermissionManagementDataAccessAgent2)(New PermissionManagementDataAccessConfigurationView(DicomDemoSettingsManager.GetGlobalPacsConfiguration(), DicomDemoSettingsManager.ProductNameStorageServer, Nothing))
	  End Sub

	  Public Shared Function GetAllRoles() As Role()
		 Dim roles As New List(Of Role)()

		 For Each role As Role In BuiltInRoles
			roles.Add(role)
		 Next role

		 For Each role As Role In permissionsAgent.GetRoles()
			roles.Add(role)
		 Next role

		 Return roles.ToArray()
	  End Function

	  Public Shared Function GetUserRoles(ByVal userName As String) As Role()
		 Dim roles As New List(Of Role)()
		 Dim temp_roles() As String = permissionsAgent.GetUserRoles(userName)

		 For Each roleName As String In temp_roles
			Dim role As Role = permissionsAgent.GetRole(roleName)
			Dim builtIn As Role = Find(roleName)

			If role IsNot Nothing Then
			   roles.Add(role)
			End If

			If builtIn IsNot Nothing Then
			   roles.Add(builtIn)
			End If
		 Next roleName

		 If permissionsAgent.UserHasPermission(UserPermissions.Admin, userName) Then
			If (Not roles.Contains(Admin, New RoleComparer())) Then
			   roles.Add(Admin)
			End If
		 End If

		 Return roles.ToArray()
	  End Function

	  Public Shared Function Find(ByVal name As String) As Role
		 Dim result As Role = _BuiltInRoles.Find(Function(ByVal Role As Role) Role.Name = name)

		 Return result
	  End Function

	  Public Shared Sub UpdateRole(ByVal role As Role)
		 permissionsAgent.UpdateRole(role)
	  End Sub

	  Public Shared Sub AddRole(ByVal role As Role)
		 permissionsAgent.AddRole(role)
	  End Sub

	  Public Shared Sub DeleteRole(ByVal roleName As String)
		 permissionsAgent.DeleteRole(roleName)
	  End Sub

	  Public Shared Sub SetUserRoles(ByVal userName As String, ByVal roles As List(Of Role))
		 Dim currentRoles As List(Of String) = GetUserRoles(userName).Select(Function(r) r.Name).ToList()
		 Dim deleteRoles As List(Of String) = currentRoles.Except(roles.Select(Function(r) r.Name)).ToList()

		 For Each role As Role In roles
			permissionsAgent.AddUserRole(role.Name, userName)
		 Next role

		 For Each role As String In deleteRoles
			permissionsAgent.DeleteUserRole(role, userName)
		 Next role
	  End Sub

	  Private Shared Function GetDataAccess(Of T)(ByVal configView As DataAccessConfigurationView) As T
		 Dim service As T

		 If (Not DataAccessServices.IsDataAccessServiceRegistered(Of T)()) Then
			service = DataAccessFactory.GetInstance(configView).CreateDataAccessAgent(Of T)()
			DataAccessServices.RegisterDataAccessService(Of T)(service)
		 Else
			service = DataAccessServices.GetDataAccessService(Of T)()
		 End If
		 Return service
	  End Function
   End Class

   Public Class RoleComparer
	   Implements IEqualityComparer(Of Role)
	  Public Overloads Function Equals(ByVal r1 As Role, ByVal r2 As Role) As Boolean Implements IEqualityComparer(Of Role).Equals
		 Return r1.Name = r2.Name
	  End Function

	  Public Overloads Function GetHashCode(ByVal r As Role) As Integer Implements IEqualityComparer(Of Role).GetHashCode
		 Return r.Name.GetHashCode()
	  End Function
   End Class

   Public Class PermissionsTable
	  Private Const _prefix As String = "MWV."

	  Private Shared _instance As New PermissionsTable()
	  Public Shared ReadOnly Property Instance() As PermissionsTable
		  Get
			  Return _instance
		  End Get
	  End Property

	  Public ReadOnly CanDownloadImages As New Permission() With {.Name = _prefix & "CanDownloadImages", .Description = "Allow users to Move images from remote PACS."}
	  Public ReadOnly CanDeleteImages As New Permission() With {.Name = "CanDeleteFromDatabase", .Description = "Allow users to delete from storage database."}
	  Public ReadOnly CanDeleteDownloadInfo As New Permission() With {.Name = _prefix & "CanDeleteDownloadInfo", .Description = "Allow users to delete jobs in download queue."}
	  Public ReadOnly CanRetrieve As New Permission() With {.Name = _prefix & "CanRetrieve", .Description = "Allow users to request DICOM DataSet through the web interface."}
	  Public ReadOnly CanQueryPACS As New Permission() With {.Name = _prefix & "CanQueryPACS", .Description = "Allow users to query remote PACS through the web interface."}
	  Public ReadOnly CanQuery As New Permission() With {.Name = _prefix & "CanQuery", .Description = "Allow users to query local images through the web interface."}
	  Public ReadOnly CanManageUsers As New Permission() With {.Name = _prefix & "CanManageUsers", .Description = "Allow users to manage other users through the web interface."}
	  Public ReadOnly CanManageRoles As New Permission() With {.Name = _prefix & "CanManageRoles", .Description = "Allow users to manage roles through the web interface."}
	  Public ReadOnly CanManageAccessRight As New Permission() With {.Name = _prefix & "CanManageAccessRight", .Description = "Allow users to grant or deny access to patient information through the web interface."}
	  Public ReadOnly CanStore As New Permission() With {.Name = _prefix & "CanStore", .Description = "Allow users to store to server."}
	  Public ReadOnly CanViewAnnotations As New Permission() With {.Name = _prefix & "CanViewAnnotations", .Description = "Allow users to load annotations."}
	  Public ReadOnly CanStoreAnnotations As New Permission() With {.Name = _prefix & "CanStoreAnnotations", .Description = "Allow users to save annotations."}
	  Public ReadOnly CanDeleteAnnotations As New Permission() With {.Name = _prefix & "CanDeleteAnnotations", .Description = "Allow users to save annotations."}
	  Private privatePermissions As List(Of Permission)
	  Public Property Permissions() As List(Of Permission)
		  Get
			  Return privatePermissions
		  End Get
		  Private Set(ByVal value As List(Of Permission))
			  privatePermissions = value
		  End Set
	  End Property

	  Public ReadOnly Property PermissionsNames() As List(Of String)
		 Get
            Dim permissionsNames_Renamed As New List(Of String)()
			For Each permission As Permission In Permissions
			   permissionsNames_Renamed.Add(permission.Name)
			Next permission
			Return permissionsNames_Renamed
		 End Get
	  End Property

	  Public Sub New()
		 Permissions = New List(Of Permission)()

		 Permissions.Add(CanDownloadImages)
		 Permissions.Add(CanDeleteImages)
		 Permissions.Add(CanDeleteDownloadInfo)
		 Permissions.Add(CanRetrieve)
		 Permissions.Add(CanQueryPACS)
		 Permissions.Add(CanQuery)
		 Permissions.Add(CanManageUsers)
		 Permissions.Add(CanManageRoles)
		 Permissions.Add(CanManageAccessRight)
		 Permissions.Add(CanStore)
		 Permissions.Add(CanViewAnnotations)
		 Permissions.Add(CanStoreAnnotations)
		 Permissions.Add(CanDeleteAnnotations)
	  End Sub

	  Public Function Find(ByVal name As String) As Permission
		 Dim result As Permission = Permissions.Find(Function(ByVal permission As Permission) permission.Name = name)
		 Return result
	  End Function

	  Public Function Find(ByVal names() As String) As Permission()
		 Dim result As New List(Of Permission)()
		 For Each p As String In names
			result.Add(Find(p))
		 Next p
		 Return result.ToArray()
	  End Function
   End Class
End Namespace
