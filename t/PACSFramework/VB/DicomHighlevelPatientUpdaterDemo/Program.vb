' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms
Imports System.Resources
Imports System.Reflection
Imports System.Threading
Imports System.Globalization
Imports System.Diagnostics
Imports Leadtools
Imports Leadtools.Dicom
Imports Leadtools.Demos
Imports DicomDemo.DicomDemo.Authentication
Imports Leadtools.Medical.DataAccessLayer.Configuration
Imports System.Configuration
Imports Leadtools.DicomDemos
Imports Leadtools.Medical.UserManagementDataAccessLayer.Configuration
Imports Leadtools.Medical.PermissionsManagement.DataAccessLayer.Configuration
Imports Leadtools.Medical.OptionsDataAccessLayer.Configuration
Imports System.IO
Imports Microsoft.VisualBasic
Imports Leadtools.Medical.UserManagementDataAccessLayer
Imports Leadtools.Medical.PermissionsManagement.DataAccessLayer
Imports Leadtools.Medical.OptionsDataAccessLayer
Imports Leadtools.Medical.DataAccessLayer

Namespace DicomDemo
    Friend Class Program
        Private Shared _Culture As CultureInfo = System.Globalization.CultureInfo.CurrentCulture

        Private Sub New()
        End Sub
        Public Shared ReadOnly Property Culture() As CultureInfo
            Get
                Return _Culture
            End Get
        End Property

        Public Shared OtherPID As New Dictionary(Of String, String)()

        Public Const PatientUpdater As String = "PatientUpdater"

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Shared Sub Main(ByVal args() As String)

#If (LEADTOOLS_V20_OR_LATER) Then
            If DemosGlobal.IsDotNet45OrLaterInstalled() = False Then
                MessageBox.Show("To run this application, you must first install Microsoft .NET Framework 4.5 or later.", "Microsoft .NET Framework 4.5 or later Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
#End If

            If (Not InitializeLicense()) Then
                Return
            End If

#If LEADTOOLS_V175_OR_LATER Then
            If RasterSupport.IsLocked(RasterSupportType.DicomCommunication) Then
                MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.DicomCommunication.ToString()), "Warning")
                Return
            End If
#Else
		   If RasterSupport.IsLocked(RasterSupportType.MedicalNet) Then
			  MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.MedicalNet.ToString()), "Warning")
			  Return
		   End If
#End If
            Leadtools.DicomDemos.Utils.EngineStartup()
            Leadtools.DicomDemos.Utils.DicomNetStartup()

            Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)

            Try
                If Login() Then
                    Application.Run(New MainForm())
                End If
            Catch e1 As Exception
            Finally
                DicomShutdown()
            End Try
        End Sub

        Public Shared Function InitializeLicense() As Boolean
            Dim ret As Boolean = True
#If LEADTOOLS_V19_OR_LATER Then
            ret = Support.SetLicense()
#Else
			Support.SetLicense()
			If RasterSupport.KernelExpired Then
			   ret = False
			End If
#End If
            Return ret
        End Function

        Private Shared PacsDatabaseConfigurationDemoNames() As String = {"CSPacsDatabaseConfigurationDemo_Original.exe", "CSPacsDatabaseConfigurationDemo.exe"}

        Public Shared Function Login() As Boolean
            If IsUserDBConfigured() Then
                Dim dlgLogin As LoginDialog = New LoginDialog()
                Dim process As Process = Process.GetCurrentProcess()

                dlgLogin.Text = "Patient Updater Login"
                AddHandler dlgLogin.AuthenticateUser, AddressOf dlgLogin_AuthenticateUser
                If dlgLogin.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    UserManager.User = New ManagerUser(dlgLogin.Username, UserManager.GetUserPermissions(dlgLogin.Username))
                    Return True
                End If
            Else
                MessageBox.Show("Patient Updater DB Configuration Incomplete. Please run CSPacsDatabaseConfigurationDemo_Original.exe to configure the database.", "Application will exit.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Environment.Exit(0)
            End If
            Return False
        End Function

        Private Shared _UserName As String

        Private Shared Function IsUserDBConfigured() As Boolean
            Dim configuration As System.Configuration.Configuration = DicomDemoSettingsManager.GetGlobalPacsConfiguration()

            If configuration IsNot Nothing Then
                Dim settings As ConnectionStringSettings = GetConnectionString(configuration, New UserManagementDataAccessConfigurationView().DataAccessSettingsSectionName)

                If settings Is Nothing Then
                    Return False
                End If

                settings = GetConnectionString(configuration, New PermissionManagementDataAccessConfigurationView().DataAccessSettingsSectionName)
                If settings Is Nothing Then
                    Return False
                End If

                settings = GetConnectionString(configuration, New OptionsDataAccessConfigurationView().DataAccessSettingsSectionName)
                If settings Is Nothing Then
                    Return False
                End If
            End If

            Return True
        End Function

        Private Shared Sub DicomShutdown()
            Try
                DicomNet.Shutdown()
                DicomEngine.Shutdown()
            Catch e1 As Exception
            End Try
        End Sub

        Private Shared Function GetConnectionString(config As System.Configuration.Configuration, dataAccessSectionName As String) As ConnectionStringSettings
            Dim settings As DataAccessSettings

            Try
                settings = TryCast(config.GetSection(dataAccessSectionName), DataAccessSettings)

                If settings Is Nothing Then
                    Return Nothing
                Else
                    Dim puElement As ConnectionElement = Nothing
                    Dim connection As ConnectionStringSettings = Nothing

                    For i As Integer = 0 To settings.Connections.Count - 1
                        If settings.Connections(i).ProductName = DicomDemoSettingsManager.ProductNameStorageServer Then
                            puElement = settings.Connections(i)
                            Exit For
                        End If
                    Next

                    If puElement IsNot Nothing Then
                        connection = config.ConnectionStrings.ConnectionStrings(puElement.ConnectionName)
                    End If

                    Return connection
                End If
            Catch generatedExceptionName As Exception
                Return Nothing
            End Try
        End Function

        Private Shared Sub dlgLogin_AuthenticateUser(ByVal sender As Object, ByVal e As AuthenticateUserEventArgs)
            '
            ' Once user is logged in we need to check to see if the user password
            ' has expired.
            '
            Dim errorString As String = String.Empty
            _UserName = e.Username
            Dim result As UserManager.AuthenticateResult = UserManager.Authenticate(e.Username, e.Password, errorString)
            If result = UserManager.AuthenticateResult.Success Then
                If UserManager.IsPasswordExpired(e.Username) Then
                    Dim dlgPassword As New PasswordDialog()

                    dlgPassword.Text = "Reset Expired Password"
                    AddHandler dlgPassword.ValidatePassword, AddressOf dlgPassword_ValidatePassword
                    If dlgPassword.ShowDialog(TryCast(sender, Form)) = DialogResult.OK Then
                        UserManager.ResetPassword(e.Username, dlgPassword.Password)
                    Else
                        e.Cancel = True
                    End If
                End If
            ElseIf result = UserManager.AuthenticateResult.InvalidUser Then
                Messager.ShowError(TryCast(sender, Form), "Invalid user name or password.")
                e.InvalidCredentials = True
            ElseIf result = UserManager.AuthenticateResult.ErrorInvalidDatabase Then
                Messager.ShowError(TryCast(sender, Form), "Invalid Database." & Constants.vbLf + Constants.vbLf & "The configured database does not contain a 'Users' table.  Please run " & Program.PacsDatabaseConfigurationDemoNames(0) & " to connect to the correct database.")
                e.InvalidCredentials = False
                e.Cancel = True
            Else
                Messager.ShowError(TryCast(sender, Form), errorString)
                e.InvalidCredentials = False
                e.Cancel = True
            End If
        End Sub

        Private Shared Sub dlgPassword_ValidatePassword(ByVal sender As Object, ByVal e As ValidatePasswordEventArgs)
            Dim message As String = String.Empty
            e.Valid = True
            If (Not UserManager.ValidatePassword(e.Password, e.ConfirmPassword, message)) Then
                e.Valid = False
                Messager.ShowError(TryCast(sender, Form), message)
            ElseIf UserManager.IsPreviousPassword(_UserName, DicomDemo.Authentication.Extensions.ToSecureString(e.Password)) Then
                e.Valid = False
                Messager.ShowError(TryCast(sender, Form), "The password chosen has already been used.  Please choose a new password.")
            End If
        End Sub

        Public Shared Function DateString(ByVal [date] As Nullable(Of DateTime)) As String
            If [date].HasValue Then
                Return [date].Value.ToString(Culture.DateTimeFormat.ShortDatePattern)
            Else
                Return String.Empty
            End If
        End Function

        Public Shared Function GetUserAgent(ByVal configuration As System.Configuration.Configuration) As IUserManagementDataAccessAgent2
            Return DataAccessFactory.GetInstance(New UserManagementDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, Nothing)).CreateDataAccessAgent(Of IUserManagementDataAccessAgent2)()
        End Function

        Public Shared Function GetPermissionsAgent(ByVal configuration As System.Configuration.Configuration) As IPermissionManagementDataAccessAgent2
            Return DataAccessFactory.GetInstance(New PermissionManagementDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, Nothing)).CreateDataAccessAgent(Of IPermissionManagementDataAccessAgent2)()
        End Function

        Public Shared Function GetOptionsAgent(ByVal configuration As System.Configuration.Configuration) As IOptionsDataAccessAgent
            Return DataAccessFactory.GetInstance(New OptionsDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, Nothing)).CreateDataAccessAgent(Of IOptionsDataAccessAgent)()
        End Function

    End Class
End Namespace