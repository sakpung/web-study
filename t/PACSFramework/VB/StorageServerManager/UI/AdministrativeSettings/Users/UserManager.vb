' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Medical.UserManagementDataAccessLayer
Imports Leadtools.Medical.DataAccessLayer
Imports Leadtools.Medical.UserManagementDataAccessLayer.Configuration
Imports System.Data
Imports System.Security
Imports Leadtools.Medical.OptionsDataAccessLayer
Imports Leadtools.Medical.OptionsDataAccessLayer.Configuration
Imports Leadtools.Medical.PermissionsManagement.DataAccessLayer
Imports Leadtools.Medical.PermissionsManagement.DataAccessLayer.Configuration
Imports Leadtools.Medical.Winforms
Imports Leadtools.DicomDemos
Imports Leadtools.Demos.StorageServer.DataTypes
Imports Leadtools.Medical.DataAccessLayer.Configuration

Namespace Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
   Public Class UserManager
      Private Shared _User As ManagerUser

      Private Shared _globalPacsConfiguration As System.Configuration.Configuration = DicomDemoSettingsManager.GetGlobalPacsConfiguration()

      Private Sub New()
      End Sub
      Public Shared ReadOnly Property GlobalPacsConfiguration() As System.Configuration.Configuration
         Get
            Return UserManager._globalPacsConfiguration
         End Get
      End Property

      Public Shared Property User() As ManagerUser
         Get
            Return _User
         End Get
         Set(ByVal value As ManagerUser)
            _User = value
         End Set
      End Property

      Private Shared userAgent As IUserManagementDataAccessAgent2
      Private Shared permissionsAgent As IPermissionManagementDataAccessAgent
      Private Shared optionsAgent As IOptionsDataAccessAgent

      Shared Sub New()
         userAgent = GetDataAccess(Of IUserManagementDataAccessAgent2)(New UserManagementDataAccessConfigurationView2(GlobalPacsConfiguration, DicomDemoSettingsManager.ProductNameStorageServer, Nothing))
         permissionsAgent = GetDataAccess(Of IPermissionManagementDataAccessAgent)(New PermissionManagementDataAccessConfigurationView(GlobalPacsConfiguration, DicomDemoSettingsManager.ProductNameStorageServer, Nothing))
         optionsAgent = GetDataAccess(Of IOptionsDataAccessAgent)(New OptionsDataAccessConfigurationView(GlobalPacsConfiguration, DicomDemoSettingsManager.ProductNameStorageServer, Nothing))
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

      Public Shared Function Authenticate(ByVal username As String, ByVal password As SecureString) As Boolean
         Return userAgent.IsUserValid(username, password)
      End Function

      Public Shared Function IsPasswordExpired(ByVal userName As String) As Boolean
         Return userAgent.IsUserPasswordExpired(userName)
      End Function

      Public Shared Function LoadUsers() As UsersSource
         Dim users As IEnumerable(Of User)
         Dim usersDataSet As UsersSource

         users = userAgent.GetUsers()
         usersDataSet = New UsersSource()


         For Each userData As User In users
            Dim _user As UsersSource.UsersRow
            Dim permissions As String() = permissionsAgent.GetUserPermissions(userData.UserName)

            _user = usersDataSet.Users.NewUsersRow()
            _user.UserName = userData.UserName
            _user.IsAdmin = userData.IsAdmin
            If userData.Expires.HasValue Then
               _user.Expires = userData.Expires.Value
            End If
            usersDataSet.Users.AddUsersRow(_user)

            For Each permission As String In permissions
               Dim p As UsersSource.UserPermissionsRow

               p = usersDataSet.UserPermissions.NewUserPermissionsRow()
               p.UserName = userData.UserName
               p.Permission = permission
               usersDataSet.UserPermissions.AddUserPermissionsRow(p)
            Next permission
         Next userData

         usersDataSet.AcceptChanges()

         Return usersDataSet
      End Function

      Public Shared Sub UpdateUsers(ByVal users As UsersSource)
         Dim usersDataSet As UsersSource
         Dim options As PasswordOptions = optionsAgent.Get(Of PasswordOptions)(PasswordOptionsPresenter.PasswordOptions, New PasswordOptions())

         usersDataSet = CType(users.GetChanges(), UsersSource)

         If Nothing Is usersDataSet Then
            Return
         End If

         Dim i As Integer = 0

         For Each user As UsersSource.UsersRow In usersDataSet.Users
            If user.RowState = DataRowState.Added Then
               Dim expires As Nullable(Of DateTime) = Nothing

               If user.IsNewPasswordNull() Then
                  Throw New InvalidOperationException("New user has no password.")
               End If
               If (Not user.IsExpiresNull()) Then
                  expires = user.Expires
               End If

               userAgent.AddUser(user.UserName, user.NewPassword, expires)

               Shell.LogAudit(String.Format(AuditMessages.NewUserAdded.Message, user.UserName))
            ElseIf user.RowState = DataRowState.Deleted Then
               Dim username As String = Convert.ToString(usersDataSet.Users.Rows(i)(0, DataRowVersion.Original))

               userAgent.RemoveUser(username)

               Shell.LogAudit(String.Format(AuditMessages.UserRemoved.Message, username))
            ElseIf user.RowState = DataRowState.Modified Then
               If (Not user.IsNewPasswordNull()) Then
                  Dim expires As Nullable(Of DateTime) = Nothing

                  If (Not user.IsExpiresNull()) Then
                     expires = user.Expires
                  End If

                  userAgent.SetUserPassword(user.UserName, user.NewPassword, expires, options.MaxPasswordHistory)

                  Shell.LogAudit(String.Format(AuditMessages.UserPasswordChanged.Message, user.UserName))
               End If
            End If
            i += 1
         Next user

         i = 0
         Dim currentUserPermissionChanged As Boolean = False

         For Each permission As UsersSource.UserPermissionsRow In usersDataSet.UserPermissions
            If permission.RowState = DataRowState.Added Then
               permissionsAgent.AddUserPermission(permission.Permission, permission.UserName)

               Shell.LogAudit(String.Format(AuditMessages.PermissionAdded.Message, permission.UserName, permission.Permission))

               If permission.UserName = User.Name Then
                  currentUserPermissionChanged = True

                  User.Permissions.Add(permission.Permission)
               End If
            ElseIf permission.RowState = DataRowState.Deleted Then
               Dim username As String = Convert.ToString(usersDataSet.UserPermissions.Rows(i)(0, DataRowVersion.Original))
               Dim p As String = Convert.ToString(usersDataSet.UserPermissions.Rows(i)(1, DataRowVersion.Original))

               permissionsAgent.DeleteUserPermission(p, username)

               Shell.LogAudit(String.Format(AuditMessages.PermissionRemoved.Message, username, p))

               If username = User.Name Then
                  currentUserPermissionChanged = True

                  User.Permissions.Remove(p)
               End If

               i += 1
            End If
         Next permission

         users.AcceptChanges()

         If currentUserPermissionChanged Then
            EventBroker.Instance.PublishEvent(Of CurrentUserPemissionsChangedEventArgs)(Nothing, New CurrentUserPemissionsChangedEventArgs())
         End If
      End Sub

      Public Shared Function GetUserPermissions(ByVal userName As String) As List(Of String)
         Dim permissions As List(Of String) = New List(Of String)()

         permissions.AddRange(permissionsAgent.GetUserPermissions(userName))
         Return permissions
      End Function

      Public Shared Sub ResetPassword(ByVal userName As String, ByVal password As SecureString)
         Dim options As PasswordOptions
         Dim expires As Nullable(Of DateTime) = Nothing

         options = optionsAgent.Get(Of PasswordOptions)(PasswordOptionsPresenter.PasswordOptions, New PasswordOptions())
         If options.DaysToExpire > 0 Then
            expires = DateTime.Now.AddDays(options.DaysToExpire)
         End If
         userAgent.SetUserPassword(userName, password, expires, options.MaxPasswordHistory)
      End Sub

      Public Shared Function ValidatePassword(ByVal password As String, ByVal confirmPassword As String, <System.Runtime.InteropServices.Out()> ByRef message As String) As Boolean
         Dim options As PasswordOptions

         options = optionsAgent.Get(Of PasswordOptions)(PasswordOptionsPresenter.PasswordOptions, New PasswordOptions())
         If (Not PasswordValidator.Validate(password, confirmPassword, options, message)) Then
            Return False
         Else
            Return True
         End If
      End Function

      Public Shared Function IsPreviousPassword(ByVal userName As String, ByVal password As SecureString) As Boolean
         Return userAgent.IsPreviousPassword(userName, password)
      End Function
   End Class

   Public Class UserPermissions
      Public Const Admin As String = "Admin"
      Public Const CanDeleteFromDatabase As String = "CanDeleteFromDatabase"
      Public Const CanEmptyDatabase As String = "CanEmptyDatabase"
      Public Const CanChangeServerSettings As String = "CanChangeServerSettings"
   End Class

   Public Class ManagerUser
      Private _name As String
      Private _permissions As List(Of String)
      Public Property Name() As String
         Get
            Return _name
         End Get
         Set(ByVal value As String)
            _name = value
         End Set
      End Property

      Public Property Permissions() As List(Of String)
         Get
            Return _permissions
         End Get
         Set(ByVal value As List(Of String))
            _permissions = value
         End Set
      End Property

      Public Sub New(ByVal myUserName As String, ByVal myPermissions As List(Of String))
         Name = myUserName
         Permissions = New List(Of String)()
         Permissions.AddRange(myPermissions)
      End Sub

      Public Function IsAuthorized(ByVal mypermission As String) As Boolean
         Return Permissions.Contains(mypermission)
      End Function

      Public Function IsAdmin() As Boolean
         Return Permissions.Contains(UserPermissions.Admin)
      End Function
   End Class
End Namespace
