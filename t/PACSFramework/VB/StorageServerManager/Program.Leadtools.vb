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
Imports Leadtools.Demos.StorageServer.UI.Authentication
Imports System.Diagnostics
Imports System.Windows.Forms
Imports Leadtools.Medical.OptionsDataAccessLayer
Imports Leadtools.Medical.DataAccessLayer
Imports Leadtools.DicomDemos
Imports System.IO
Imports System.Reflection
Imports System.Drawing
Imports Leadtools.Demos.StorageServer.DataTypes
Imports Leadtools.Medical.OptionsDataAccessLayer.Configuration
Imports System.ServiceProcess
Imports Leadtools.Dicom.Server.Admin

Namespace Leadtools.Demos.StorageServer
   Partial Friend Class Program
      Private Shared PacsDatabaseConfigurationDemoNames() As String = {"CSPacsDatabaseConfigurationDemo_Original.exe", "CSPacsDatabaseConfigurationDemo.exe"}

      Public Shared Sub CheckPacsConfigDemo()
         Try
            Dim demoName As String = Path.GetFileName(Application.ExecutablePath)
            Dim mySettings As DicomDemoSettings = DicomDemoSettingsManager.LoadSettings(demoName)
            If mySettings Is Nothing Then
               DicomDemoSettingsManager.RunPacsConfigDemo()
               mySettings = DicomDemoSettingsManager.LoadSettings(demoName)
               If mySettings Is Nothing Then
                  Messager.ShowWarning(Nothing, "Since the PACSConfigDemo has not been run, the PACS High Level Demos are not pre-configured.")
               End If
            End If
         Catch e1 As Exception
         End Try
      End Sub

      Public Shared Function Login(ByVal info As String, ByVal relogin As Boolean) As Boolean
         Try
            Dim dlgLogin As LoginDialog = New LoginDialog()
            Dim process As Process = Process.GetCurrentProcess()
            Dim optionsAgent As IOptionsDataAccessAgent = DataAccessServices.GetDataAccessService(Of IOptionsDataAccessAgent)()
            Dim lastUser As String = optionsAgent.Get(Of String)("LastUser", String.Empty)

            dlgLogin.Text = "Storage Server Manager Login"
            dlgLogin.Info = info
            dlgLogin.Username = lastUser
            dlgLogin.CanSetUserName = Not relogin
            AddHandler dlgLogin.AuthenticateUser, AddressOf dlgLogin_AuthenticateUser
            If dlgLogin.ShowDialog(New WindowWrapper(process.MainWindowHandle)) = DialogResult.OK Then
               UserManager.User = New ManagerUser(dlgLogin.Username, UserManager.GetUserPermissions(dlgLogin.Username))
               Return True
            End If
            Return False
         Catch ex As Exception
            Messager.ShowError(Nothing, ex)
            Return False
         End Try
      End Function

      Private Shared Sub LoadSplash()
         Dim stream As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Resources.splash-screen.jpg")

         If stream IsNot Nothing Then
            SplashForm.SplashBitmap = New Bitmap(stream)
         End If
      End Sub

      Public Shared Function ShouldHideUserDetails() As Boolean
         Return False
      End Function

      Private Shared Sub StopDicomServices(ByVal baseDirectory As String)
         For Each scService As ServiceController In ServiceController.GetServices()
            Dim service As New DicomServiceController(scService)

            If service IsNot Nothing AndAlso service.PathName.ToLower().Contains(Path.Combine(baseDirectory.ToLower(), "leadtools.dicom.server.exe")) Then
               Try
                  If service.Status <> ServiceControllerStatus.Stopped Then
                     service.Stop()
                     service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(1))
                     If service.Status <> ServiceControllerStatus.Stopped Then
                        service.Stop()
                     End If
                  End If
               Catch ex As Exception
                  Debug.Assert(False, ex.Message)
               Finally
                  '                  si.UnInstallService(service.ServiceName);
               End Try
            End If
         Next scService
      End Sub

      Public Shared Sub StopDicomServices()
         StopDicomServices(Application.StartupPath)
      End Sub

      Private Shared Function UpgradeConfigFiles() As Boolean
#If (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) OrElse (LEADTOOLS_V19_OR_LATER) Then
         Dim exeName As String = Path.GetFileNameWithoutExtension(Application.ExecutablePath)
         Dim globalPacsConfigPath As String = DicomDemoSettingsManager.GlobalPacsConfigFullFileName
         Dim backupGlobalPacsConfigPath As String = String.Empty

         ' Upgrade GlobalPacs.Config if necessary
         Dim bNeedsUpdate As Boolean = GlobalPacsUpdater.AddExternalStoreToGlobalPacsConfig(globalPacsConfigPath, False)
         If bNeedsUpdate Then
            Dim msg As String = String.Format("The existing globalPacs.config must be upgraded" & Constants.vbLf + Constants.vbLf & "Do you want to continue?", exeName)
            Dim dr As DialogResult = MessageBox.Show(msg, "Upgrade Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If dr <> DialogResult.Yes Then
               Return False
            End If

            backupGlobalPacsConfigPath = GlobalPacsUpdater.BackupFile(globalPacsConfigPath)
            GlobalPacsUpdater.AddExternalStoreToGlobalPacsConfig(globalPacsConfigPath, True)
         End If

#End If ' #if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
         Return True
      End Function
   End Class
End Namespace
