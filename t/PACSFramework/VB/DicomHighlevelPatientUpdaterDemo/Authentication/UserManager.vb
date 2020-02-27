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
Imports Leadtools.Medical.PermissionsManagement.DataAccessLayer
Imports Leadtools.Medical.PermissionsManagement.DataAccessLayer.Configuration
Imports Leadtools.Medical.OptionsDataAccessLayer
Imports Leadtools.Medical.Winforms
Imports Leadtools.Medical.OptionsDataAccessLayer.Configuration
Imports Leadtools.DicomDemos

Namespace DicomDemo.Authentication
    Public Class UserManager
        Private Shared _User As ManagerUser

        Private Sub New()
        End Sub
        Public Shared Property User() As ManagerUser
            Get
                Return _User
            End Get
            Set(ByVal value As ManagerUser)
                _User = value
            End Set
        End Property

        Private Shared _globalPacsConfiguration As System.Configuration.Configuration = DicomDemoSettingsManager.GetGlobalPacsConfiguration()

        Public Shared ReadOnly Property GlobalPacsConfiguration() As System.Configuration.Configuration
            Get
                Return UserManager._globalPacsConfiguration
            End Get
        End Property

        Private Shared userAgent As IUserManagementDataAccessAgent2
        Private Shared permissionsAgent2 As IPermissionManagementDataAccessAgent2
        Private Shared optionsAgent As IOptionsDataAccessAgent

        Shared Sub New()
            userAgent = Program.GetUserAgent(GlobalPacsConfiguration)
            permissionsAgent2 = Program.GetPermissionsAgent(GlobalPacsConfiguration)
            optionsAgent = Program.GetOptionsAgent(GlobalPacsConfiguration)
        End Sub

        Public Enum AuthenticateResult
            Success = 0
            InvalidUser = 1
            ErrorInvalidDatabase = 2
            ErrorUnknown = 3
        End Enum

        Public Shared Function Authenticate(ByVal username As String, ByVal password As SecureString, <System.Runtime.InteropServices.Out()> ByRef errorString As String) As AuthenticateResult
            errorString = String.Empty
            Dim userValid As Boolean = False
            Dim result As AuthenticateResult = AuthenticateResult.InvalidUser

            Try
                userValid = userAgent.IsUserValid(username, password)
                result = If(userValid, AuthenticateResult.Success, AuthenticateResult.InvalidUser)
            Catch ex As Exception
                errorString = ex.Message
                If ex.Message.Contains("Invalid object name 'Users'") Then
                    result = AuthenticateResult.ErrorInvalidDatabase
                Else
                    result = AuthenticateResult.ErrorUnknown
                End If
            End Try
            Return result
        End Function

        Public Shared Function IsPasswordExpired(ByVal userName As String) As Boolean
            Return userAgent.IsUserPasswordExpired(userName)
        End Function

        Public Shared Function GetUserPermissions(ByVal userName As String) As List(Of String)
            Dim permissions As New List(Of String)()
            Dim roles() As String = permissionsAgent2.GetUserRoles(userName)

            permissions.AddRange(permissionsAgent2.GetUserPermissions(userName))
            For Each role As String In roles
                Dim rolePermissions As New List(Of String)(permissionsAgent2.GetRolePermissions(role))

                permissions = permissions.Union(rolePermissions).ToList()
            Next role
            Return permissions
        End Function

        Public Shared Sub ResetPassword(ByVal userName As String, ByVal password As SecureString)
            Dim options As PasswordOptions
            Dim expires? As DateTime = Nothing

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
        Public Const PatientUpdaterAdmin As String = "PatientUpdaterAdmin"
        Public Const PatientUpdaterEdit As String = "PatientUpdaterEdit"
        Public Const PatientUpdaterDelete As String = "PatientUpdaterDelete"
    End Class

    Public Class ManagerUser
        Private privateName As String
        Public Property Name() As String
            Get
                Return privateName
            End Get
            Set(ByVal value As String)
                privateName = value
            End Set
        End Property

        Private privatePermissions As List(Of String)
        Public Property Permissions() As List(Of String)
            Get
                Return privatePermissions
            End Get
            Set(ByVal value As List(Of String))
                privatePermissions = value
            End Set
        End Property

        Public Sub New(ByVal userName As String, ByVal permissions As List(Of String))
            Name = userName
            privatePermissions = New List(Of String)()
            privatePermissions.AddRange(permissions)
        End Sub

        Public Function IsAdmin() As Boolean
            Return Permissions.Contains(UserPermissions.PatientUpdaterAdmin)
        End Function

        Public Function CanEdit() As Boolean
            Return IsAdmin() OrElse Permissions.Contains(UserPermissions.PatientUpdaterEdit)
        End Function

        Public Function CanDelete() As Boolean
            Return IsAdmin() OrElse Permissions.Contains(UserPermissions.PatientUpdaterDelete)
        End Function
    End Class
End Namespace