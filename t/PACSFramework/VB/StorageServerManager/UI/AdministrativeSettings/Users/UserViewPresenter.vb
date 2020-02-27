' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Demos.StorageServer.DataTypes
Imports Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
Imports Leadtools.Medical.UserManagementDataAccessLayer
Imports Leadtools.Medical.UserManagementDataAccessLayer.Configuration
Imports Leadtools.Medical.DataAccessLayer
Imports System.Windows.Forms
Imports Leadtools.Medical.OptionsDataAccessLayer
Imports Leadtools.Medical.OptionsDataAccessLayer.Configuration
Imports System.Data
Imports Leadtools.Medical.PermissionsManagement.DataAccessLayer
Imports Leadtools.Medical.PermissionsManagement.DataAccessLayer.Configuration
Imports Leadtools.Medical.Winforms
Imports Leadtools.DicomDemos

Namespace Leadtools.Demos.StorageServer.UI
   Public Class UserViewPresenter
      Private _view As UserView
      Public Property View() As UserView
         Get
            Return _view
         End Get
         Private Set(ByVal value As UserView)
            _view = value
         End Set
      End Property

      Public Sub RunView(ByVal usrview As UserView)
         EventBroker.Instance.Subscribe(Of ApplyServerSettingsEventArgs)(AddressOf OnUpdateServerSettings)
         EventBroker.Instance.Subscribe(Of CancelServerSettingsEventArgs)(AddressOf OnCancelServerSettings)

         View = usrview
         ThemesManager.ApplyTheme(View)
         AddHandler View.UsersAccounts.VisibleChanged, AddressOf UsersAccounts_VisibleChanged
         AddHandler View.UsersAccounts.PasswordRequest, AddressOf UsersAccounts_PasswordRequest
         AddHandler View.UsersAccounts.EditUserPermissions, AddressOf UsersAccounts_EditUserPermissions
         AddHandler View.SettingsChanged, AddressOf View_SettingsChanged
      End Sub

      Public Event SettingsChanged As EventHandler

      Private Sub View_SettingsChanged(ByVal sender As Object, ByVal e As EventArgs)
         Try
            RaiseEvent SettingsChanged(sender, e)
         Catch e1 As Exception
            System.Diagnostics.Debug.Assert(False)
         End Try
      End Sub

      Sub UsersAccounts_EditUserPermissions(ByVal sender As Object, ByVal e As EditUserPermissionsEventArgs)
         Dim permissionDialog As PermissionsDialog = New PermissionsDialog()
         Dim agent As IPermissionManagementDataAccessAgent = DataAccessFactory.GetInstance(New PermissionManagementDataAccessConfigurationView(DicomDemoSettingsManager.GetGlobalPacsConfiguration(), DicomDemoSettingsManager.ProductNameStorageServer, Nothing)).CreateDataAccessAgent(Of IPermissionManagementDataAccessAgent)()
         Dim permissions As Permission() = agent.GetPermissions()

         permissionDialog.Username = e.Username
         permissionDialog.SetPermissions(permissions, e.Permissions)
         If permissionDialog.ShowDialog() = DialogResult.OK Then
            View.UsersAccounts.SetUserPermissions(permissionDialog.SelectedPermissions)
         End If
      End Sub

      Sub UsersAccounts_PasswordRequest(ByVal sender As Object, ByVal e As PasswordRequestEventArgs)
         Dim dlgPassword As PasswordDialog = New PasswordDialog()

         AddHandler dlgPassword.ValidatePassword, AddressOf dlgPassword_ValidatePassword
         e.Cancel = dlgPassword.ShowDialog() = DialogResult.Cancel
         If (Not e.Cancel) Then
            Dim agent As IOptionsDataAccessAgent
            Dim options As PasswordOptions

            agent = DataAccessFactory.GetInstance(New OptionsDataAccessConfigurationView(DicomDemoSettingsManager.GetGlobalPacsConfiguration(), DicomDemoSettingsManager.ProductNameStorageServer, Nothing)).CreateDataAccessAgent(Of IOptionsDataAccessAgent)()
            options = agent.Get(Of PasswordOptions)(PasswordOptionsPresenter.PasswordOptions, New PasswordOptions())
            e.Password = dlgPassword.Password
            If options.DaysToExpire > 0 Then
               e.Expires = DateTime.Now.AddDays(options.DaysToExpire)
            End If
         End If
      End Sub

      Sub dlgPassword_ValidatePassword(ByVal sender As Object, ByVal e As ValidatePasswordEventArgs)
         Dim agent As IOptionsDataAccessAgent
         Dim options As PasswordOptions
         Dim message As String = ""

         agent = DataAccessFactory.GetInstance(New OptionsDataAccessConfigurationView(DicomDemoSettingsManager.GetGlobalPacsConfiguration(), DicomDemoSettingsManager.ProductNameStorageServer, Nothing)).CreateDataAccessAgent(Of IOptionsDataAccessAgent)()
         options = agent.Get(Of PasswordOptions)(PasswordOptionsPresenter.PasswordOptions, New PasswordOptions())
         If (Not PasswordValidator.Validate(e.Password, e.ConfirmPassword, options, message)) Then
            e.Valid = False
            Messager.ShowError(Nothing, message)
         Else
            e.Valid = True
            If UserManager.IsPreviousPassword(View.UsersAccounts.SelectedUser, Extensions.ToSecureString(e.Password)) Then
               e.Valid = False
               Messager.ShowError(TryCast(sender, Form), "The password chosen has already been used.  Please choose a new password.")
            End If
         End If
      End Sub

      Sub UsersAccounts_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs)
         If View.UsersAccounts.Visible Then
            Dim users As Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users.UsersSource = UserManager.LoadUsers()

            View.UsersAccounts.LoadUsers(users)
         End If
      End Sub

      Private Sub OnUpdateServerSettings(ByVal sender As Object, ByVal e As EventArgs)
         If View.UsersAccounts.HasChanges() Then
            UserManager.UpdateUsers(View.UsersAccounts.Source)
         End If
      End Sub

      Private Sub OnCancelServerSettings(ByVal sender As Object, ByVal e As EventArgs)

      End Sub
   End Class
End Namespace
