' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Windows.Forms
Imports Leadtools.Demos.StorageServer.UI
Imports System.Drawing.Drawing2D
Imports Leadtools.Dicom.Server.Admin
Imports Leadtools.Medical.Winforms
Imports Leadtools.Medical.DataAccessLayer
Imports Leadtools.Medical.Storage.DataAccessLayer
Imports Leadtools.Medical.Storage.DataAccessLayer.Configuration
Imports Leadtools.Medical.Logging.DataAccessLayer
Imports Leadtools.Medical.Logging.DataAccessLayer.Configuration
Imports Leadtools.Demos.StorageServer.DataTypes
Imports System.IO
Imports Leadtools.Medical.OptionsDataAccessLayer
Imports Leadtools.DicomDemos
Imports Leadtools.Medical.AeManagement.DataAccessLayer
Imports Leadtools.Medical.AeManagement.DataAccessLayer.Configuration
Imports Leadtools.Medical.PermissionsManagement.DataAccessLayer
Imports Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
Imports Leadtools.Medical.Winforms.DataAccessLayer.Configuration
Imports Leadtools.Medical.Forward.DataAccessLayer
Imports Leadtools.Medical.Forward.DataAccessLayer.Configuration
Imports Leadtools.Dicom.AddIn
Imports Leadtools.Medical.Logging.Addins
Imports Leadtools.Logging
Imports Leadtools.Logging.Medical
Imports Leadtools.Medical.Storage.AddIns
Imports Leadtools.Dicom

#If (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) OrElse (LEADTOOLS_V19_OR_LATER) Then
Imports Leadtools.Medical.ExternalStore.DataAccessLayer
Imports Leadtools.Medical.ExternalStore.DataAccessLayer.Configuration
#End If


Namespace Leadtools.Demos.StorageServer
   Partial Public Class Shell

#If (LEADTOOLS_V20_OR_LATER) Then
        Public Const storageServerName As String = "LEADTOOLS Storage Server 20 (VB.Net)"
#ElseIf (LEADTOOLS_V19_OR_LATER) Then
	  Public Const storageServerName As String ="LEADTOOLS Storage Server 19 (VB.Net)"
#Else
	  Public Const storageServerName As String ="LEADTOOLS Storage Server (VB.Net)"
#End If

        Private _Form As MainForm

      Public Sub New()

      End Sub

#If LEADTOOLS_V18_OR_LATER Then
      Private Sub CheckLicenseFile()
         ' Try to set the default license file if expired
         If RasterSupport.KernelExpired Then
            Try
               ' If the license is not valid (i.e. not a LEAD license), then SetLicense throws an exception
               Dim licenseFilePath As String = System.IO.Path.Combine(Application.StartupPath, "LEADTOOLS.LIC")
               Dim developerKey As String = System.IO.File.ReadAllText(System.IO.Path.Combine(Application.StartupPath, "LEADTOOLS.LIC.KEY"))
               RasterSupport.SetLicense(licenseFilePath, developerKey)
            Catch
            End Try
         End If
#If LEADTOOLS_V19_OR_LATER Then
         If RasterSupport.KernelExpired Then
            Support.SetLicense(True)
         End If
#End If ' #if LEADTOOLS_V19_OR_LATER


         Dim applicationName As String = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name
         Dim errorMsg As String = String.Empty
         Dim leadLogType As LogType = LogType.Information
         Dim eventLogEntryType As EventLogEntryType = EventLogEntryType.Information
         Dim messageBoxIcon As MessageBoxIcon = MessageBoxIcon.None
         Dim messageBoxTitle As String = String.Empty

#If LEADTOOLS_V19_OR_LATER Then
         Dim isKernelEvaluation As Boolean = RasterSupport.KernelType = RasterKernelType.Evaluation
#Else
		 Dim isKernelEvaluation As Boolean = (RasterSupport.KernelType = RasterKernelType.Evaluation) OrElse (RasterSupport.KernelType = RasterKernelType.Nag)
#End If ' #if LEADTOOLS_V19_OR_LATER

         If RasterSupport.KernelExpired Then
            errorMsg = String.Format("License file is missing, invalid or expired." & Constants.vbCrLf & "'{0}' will function only in a limited mode." & Constants.vbCrLf & Constants.vbCrLf & "Please contact LEAD Sales for information on obtaining a valid license.", applicationName)
            leadLogType = LogType.Error
            eventLogEntryType = EventLogEntryType.Error
            messageBoxIcon = MessageBoxIcon.Error
            messageBoxTitle = "Error"
         ElseIf isKernelEvaluation Then
            errorMsg = String.Format("{0} is running in evaluation mode and will stop running in the future." & Constants.vbCrLf & Constants.vbCrLf & "Please contact LEAD Sales for information on obtaining a valid license.", applicationName)
            leadLogType = LogType.Warning
            eventLogEntryType = EventLogEntryType.Warning
            messageBoxIcon = MessageBoxIcon.Warning
            messageBoxTitle = "Warning"
         End If

         If (Not String.IsNullOrEmpty(errorMsg)) Then
            MessageBox.Show(errorMsg, messageBoxTitle, MessageBoxButtons.OK, messageBoxIcon)

            ' StorageServerManager log
            Logger.Global.Log(String.Empty, String.Empty, String.Empty, 0, String.Empty, String.Empty, 0, DicomCommandType.Undefined, DateTime.Now, leadLogType, MessageDirection.None, errorMsg, Nothing, Nothing)

            ' Applications and Services Logs -- Leadtools
            Dim appLog As New System.Diagnostics.EventLog()
            appLog.Source = applicationName
            appLog.WriteEntry(errorMsg, eventLogEntryType)

            ' Windows Logs -- Application Event Log
            Using eventLog As New EventLog("Application")
               eventLog.Source = "Application"

               eventLog.WriteEntry(errorMsg, eventLogEntryType, 0, 0)
            End Using
         End If
      End Sub
#End If ' #if LEADTOOLS_V18_OR_LATER

      Public Sub Run()
         Try
            Dim containerPanel As StorageServerContainerView = New StorageServerContainerView()
            Dim containerPresenter As StorageServerContainerPresenter = New StorageServerContainerPresenter()

            RegisterDataAccessLayers()

            _Form = New MainForm()
            _Form.Text = Shell.storageServerName
            containerPanel.Dock = DockStyle.Fill
            containerPanel.GradientMode = LinearGradientMode.Vertical

            _Form.Controls.Add(containerPanel)

            Using serverAdmin As ServiceAdministrator = New ServiceAdministrator(Application.StartupPath)
               Dim service As DicomService = Nothing


               Dim serviceName As String = InitializeServiceAdmin(serverAdmin)

               If serverAdmin.Services.Count > 0 Then
                  service = serverAdmin.Services(serviceName)
               End If

               CreateConfigurationServics(service)

               ServerState.Instance.ServerService = service
               ServerState.Instance.ServiceAdmin = serverAdmin
               ServerState.Instance.BaseDirectory = Application.StartupPath
               ServerState.Instance.ServiceName = serviceName

               ConfigureDataAccessLayers()

               LoadLoggingState(service)
               InitializeLogger()

#If LEADTOOLS_V18_OR_LATER Then
               CheckLicenseFile()
#End If ' #if LEADTOOLS_V18_OR_LATER

               containerPresenter.RunView(containerPanel)

               SubscribeToEvents()

               Dim oTemp As AuditLogSubscriber = New AuditLogSubscriber()
               oTemp.Start()

               LogAudit(String.Format(AuditMessages.UserLogIn.Message, UserManager.User.Name))

               Start(_Form)

               If Not UserManager.User Is Nothing Then
                  LogAudit(String.Format(AuditMessages.UserLogOff.Message, UserManager.User.Name))
               Else
                  LogAudit("Canceled idle timer re-login")
               End If
            End Using
         Catch ex As Exception
            ' MessageBox.Show ( ex.Message ) ;
            Throw
         End Try
      End Sub

      Private Sub ConfigureDataAccessLayers()
         Dim storageDataAccess As IStorageDataAccessAgent = DataAccessServices.GetDataAccessService(Of IStorageDataAccessAgent)()


         If Not storageDataAccess Is Nothing AndAlso TypeOf storageDataAccess Is StorageDbDataAccessAgent Then
            Dim storageConfig As StorageModuleConfigurationManager = ServiceLocator.Retrieve(Of StorageModuleConfigurationManager)()

            If storageConfig.IsLoaded Then
               CType(storageDataAccess, StorageDbDataAccessAgent).AutoTruncateData = storageConfig.GetStorageAddInsSettings().StoreAddIn.AutoTruncateData
            End If
         End If
      End Sub

      Private Sub CreateConfigurationServics(ByVal service As DicomService)
         Dim storageConfigMnager As StorageModuleConfigurationManager = New StorageModuleConfigurationManager(False)
         Dim loggingConfigManager As LoggingModuleConfigurationManager = New LoggingModuleConfigurationManager(False)

         If Not Nothing Is service Then
            storageConfigMnager.Load(service.ServiceDirectory)
            loggingConfigManager.Load(service.ServiceDirectory)
         End If

         ServiceLocator.Register(Of StorageModuleConfigurationManager)(storageConfigMnager)
         ServiceLocator.Register(Of LoggingModuleConfigurationManager)(loggingConfigManager)
      End Sub

      Private Sub InitializeLogger()
         LoggingConfigurationSession.ConfigureLogger(Logger.Global, ServerState.Instance.LoggingState, DataAccessServices.GetDataAccessService(Of ILoggingDataAccessAgent2)())
      End Sub

      Private Shared Sub LoadLoggingState(ByVal service As DicomService)
         Dim loggingConfigManager As LoggingModuleConfigurationManager = ServiceLocator.Retrieve(Of LoggingModuleConfigurationManager)()

         If Not service Is Nothing AndAlso loggingConfigManager.IsLoaded Then
            ServerState.Instance.LoggingState = loggingConfigManager.GetLoggingState()
         Else
            ServerState.Instance.LoggingState = GetDefaultLoggingState()
         End If
      End Sub

      Private Sub SubscribeToEvents()
         EventBroker.Instance.Subscribe(Of ServerSettingsAppliedEventArgs)(AddressOf Instance_ServerSettingsApplied)
         EventBroker.Instance.Subscribe(Of LoginEventArgs)(AddressOf Relogin)

         AddHandler ServerState.Instance.LoggingStateChanged, AddressOf Instance_LoggingStateChanged

      End Sub

      Private Sub Instance_ServerSettingsApplied(ByVal sender As Object, ByVal e As EventArgs)
         ConfigureDataAccessLayers()

         InitializeLogger()

         SaveSettings()
      End Sub

      Private Sub SaveSettings()
         SetStorageServerInformationOptions(DataAccessServices.GetDataAccessService(Of IOptionsDataAccessAgent)())

         SaveLoggingState()
      End Sub

      Private Sub Relogin(ByVal sender As Object, ByVal e As EventArgs)
         If _Form.InvokeRequired Then
            _Form.Invoke(New EventHandler(AddressOf Relogin))
         Else
            LogAudit(String.Format(AuditMessages.UserLogOff.Message, UserManager.User.Name))

            UserManager.User = Nothing

            Try
               EventBroker.Instance.PublishEvent(Of ActivateIdleMonitorEventArgs)(Me, New ActivateIdleMonitorEventArgs(False))
               If (Not Program.Login("Idle timeout.  Please re-login to continue.", True)) Then
                  Application.Exit()
               Else
                  LogAudit(String.Format(AuditMessages.UserLogIn.Message, UserManager.User.Name))
               End If
            Finally
               EventBroker.Instance.PublishEvent(Of ActivateIdleMonitorEventArgs)(Me, New ActivateIdleMonitorEventArgs(True))
            End Try
         End If
      End Sub

      Private Sub Instance_LoggingStateChanged(ByVal sender As Object, ByVal e As EventArgs)
         InitializeLogger()
      End Sub

      Private Function InitializeServiceAdmin(ByVal serverAdmin As ServiceAdministrator) As String
         Dim optionsAgent As IOptionsDataAccessAgent
         Dim serverInfo As StorageServerInformation
         Dim services As List(Of String)
         Dim serviceName As String

         optionsAgent = DataAccessServices.GetDataAccessService(Of IOptionsDataAccessAgent)()
         serverInfo = optionsAgent.Get(Of StorageServerInformation)(GetType(StorageServerInformation).Name, Nothing, New Type() {})
         services = New List(Of String)()

         ServerState.Instance.IsRemoteServer = False

         If Nothing Is serverInfo Then
            serviceName = "LTSTORAGESERVER"

            services.Add(serviceName)
         Else
            If serverInfo.MachineName = Environment.MachineName Then
               If (Not String.IsNullOrEmpty(serverInfo.ServiceName)) Then
                  serviceName = serverInfo.ServiceName
               Else
                  serviceName = "LTSTORAGESERVER"
               End If

               services.Add(serverInfo.ServiceName)
            Else
               ServerState.Instance.IsRemoteServer = True
               ServerState.Instance.RemoteServerInformation = serverInfo

               serviceName = serverInfo.ServiceName
            End If
         End If

         AddHandler ServerState.Instance.ServiceAdminChanged, AddressOf Instance_ServiceAdminChanged
         AddHandler ServerState.Instance.ServerServiceChanged, AddressOf Instance_ServerServiceChanged

         If services.Count > 0 Then
            serverAdmin.Initialize(services)
         End If

         Return serviceName
      End Function

      Private Sub RegisterDataAccessLayers()
         Dim storageAgent As IStorageDataAccessAgent
         Dim loggingAgent As ILoggingDataAccessAgent2
         'IOptionsDataAccessAgent              optionsAgent ;
         Dim aeManagementAgent As IAeManagementDataAccessAgent
         Dim permissionManagementAgent As IPermissionManagementDataAccessAgent
         Dim forwardManagementAgent As IForwardDataAccessAgent

#If (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) OrElse (LEADTOOLS_V19_OR_LATER) Then
         Dim externalStoreAgent As IExternalStoreDataAccessAgent
#End If


         Dim configuration As System.Configuration.Configuration = DicomDemoSettingsManager.GetGlobalPacsConfiguration()
         storageAgent = DataAccessFactory.GetInstance(New StorageDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, Nothing)).CreateDataAccessAgent(Of IStorageDataAccessAgent)()
         loggingAgent = DataAccessFactory.GetInstance(New LoggingDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, Nothing)).CreateDataAccessAgent(Of ILoggingDataAccessAgent2)()
         'optionsAgent = DataAccessFactory.GetInstance(new OptionsDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, null)).CreateDataAccessAgent<IOptionsDataAccessAgent>();
         aeManagementAgent = DataAccessFactory.GetInstance(New AeManagementDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, Nothing)).CreateDataAccessAgent(Of IAeManagementDataAccessAgent)()
         permissionManagementAgent = DataAccessFactory.GetInstance(New AePermissionManagementDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, Nothing)).CreateDataAccessAgent(Of IPermissionManagementDataAccessAgent)()
         forwardManagementAgent = DataAccessFactory.GetInstance(New ForwardDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, Nothing)).CreateDataAccessAgent(Of IForwardDataAccessAgent)()
#If (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) OrElse (LEADTOOLS_V19_OR_LATER) Then
         externalStoreAgent = DataAccessFactory.GetInstance(New ExternalStoreDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, Nothing)).CreateDataAccessAgent(Of IExternalStoreDataAccessAgent)()
#End If

         DataAccessServices.RegisterDataAccessService(Of IStorageDataAccessAgent)(storageAgent)
         DataAccessServices.RegisterDataAccessService(Of ILoggingDataAccessAgent2)(loggingAgent)
         'DataAccessServices.RegisterDataAccessService<IOptionsDataAccessAgent>(optionsAgent);
         DataAccessServices.RegisterDataAccessService(Of IAeManagementDataAccessAgent)(aeManagementAgent)
         DataAccessServices.RegisterDataAccessService(Of IPermissionManagementDataAccessAgent)(permissionManagementAgent)
         DataAccessServices.RegisterDataAccessService(Of IForwardDataAccessAgent)(forwardManagementAgent)

#If (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) OrElse (LEADTOOLS_V19_OR_LATER) Then
         DataAccessServices.RegisterDataAccessService(Of IExternalStoreDataAccessAgent)(externalStoreAgent)
#End If
      End Sub

      Private Sub Instance_ServerServiceChanged(ByVal sender As Object, ByVal e As EventArgs)
         Dim optionsAgent As IOptionsDataAccessAgent


         optionsAgent = DataAccessServices.GetDataAccessService(Of IOptionsDataAccessAgent)()

         If Not Nothing Is ServerState.Instance.ServerService Then
            SetStorageServerInformationOptions(optionsAgent)

            LoadLicense(ServerState.Instance.ServerService.Settings.LicenseFile)
         Else
            optionsAgent.DeleteOption(GetType(StorageServerInformation).Name)

            ServerState.Instance.License = Nothing
         End If

         LoadLoggingState(ServerState.Instance.ServerService)
      End Sub

      Private Shared Sub SetStorageServerInformationOptions(ByVal optionsAgent As IOptionsDataAccessAgent)
         If Not Nothing Is ServerState.Instance.ServerService Then
            Dim information As StorageServerInformation = Nothing

            Dim ae As DicomAE = New DicomAE(ServerState.Instance.ServerService.Settings.AETitle, ServerState.Instance.ServerService.Settings.IpAddress, ServerState.Instance.ServerService.Settings.Port, 0, ServerState.Instance.ServerService.Settings.Secure)

            information = New StorageServerInformation(ae, ServerState.Instance.ServerService.ServiceName, Environment.MachineName)

            optionsAgent.Set(Of StorageServerInformation)(GetType(StorageServerInformation).Name, information, New Type() {})
         End If
      End Sub

      Private Sub Instance_ServiceAdminChanged(ByVal sender As Object, ByVal e As EventArgs)
         If Not Nothing Is ServerState.Instance.ServiceAdmin Then
            AddHandler ServerState.Instance.ServiceAdmin.Error, AddressOf ServiceAdmin_Error
         End If
      End Sub

      Private Sub ServiceAdmin_Error(ByVal sender As Object, ByVal e As Leadtools.Dicom.Server.Admin.ErrorEventArgs)
         'TODO
         MessageBox.Show(e.Error.Message)
      End Sub

      Friend Shared Function GetDefaultLoggingState() As LoggingState
         Dim state As LoggingState


         state = New LoggingState()

         state.EnableAutoSaveLog = False

         Return state
      End Function

      Friend Shared Sub SaveLoggingState()
         Dim loggingConfigManager As LoggingModuleConfigurationManager = ServiceLocator.Retrieve(Of LoggingModuleConfigurationManager)()

         If loggingConfigManager.IsLoaded Then
            loggingConfigManager.SetLoggingState(ServerState.Instance.LoggingState)

            loggingConfigManager.Save()
         End If
      End Sub

      Public Shared Sub InstallAddIns(ByVal addIns As String(), ByVal directoryName As String)
         If (Not Directory.Exists(directoryName)) Then
            Directory.CreateDirectory(directoryName)
         End If

         For Each addInDll As String In addIns
            Dim sourceFileLocation As String = Path.Combine(ServerState.Instance.ServiceAdmin.BaseDirectory, addInDll)

            If (Not File.Exists(sourceFileLocation)) Then
               Dim baseDir As String = Path.Combine(ServerState.Instance.ServiceAdmin.BaseDirectory, "PACSAddIns")

               sourceFileLocation = Path.Combine(baseDir, addInDll)
            End If

            If File.Exists(sourceFileLocation) Then
               File.Copy(sourceFileLocation, Path.Combine(directoryName, addInDll), True)
            End If
         Next addInDll
      End Sub

      Public Shared Sub LogAudit(ByVal description As String)
         Dim logEntry As DicomLogEntry = New DicomLogEntry()

         logEntry.LogType = LogType.Audit
         If Not UserManager.User Is Nothing Then
            logEntry.ClientAETitle = UserManager.User.Name
         Else
            Dim optionsAgent As IOptionsDataAccessAgent = DataAccessServices.GetDataAccessService(Of IOptionsDataAccessAgent)()
            Dim lastUser As String = optionsAgent.Get(Of String)("LastUser", String.Empty)

            logEntry.ClientAETitle = lastUser
         End If
         logEntry.Description = description

         Logger.Global.Log(logEntry)
      End Sub

      Public Const storageServerNotes As String = "" & ControlChars.CrLf & "This is a Fully Functional OEM-ready DICOM Storage server application with source code that includes the following features:" & ControlChars.CrLf & ControlChars.CrLf & "• Storage Add-in that supports query/retrieve and Store with extensive options." & ControlChars.CrLf & ControlChars.CrLf & "• Logging Add-in that supports many filtering options including Automatic export of logs" & ControlChars.CrLf & ControlChars.CrLf & "• Patient Updater Add-in that includes a patient/study management client that allows users to move, merge, and update patient information using DICOM communications." & ControlChars.CrLf & ControlChars.CrLf & "• Auto-Copy Add-in that automatically routes retrieved DICOM image data to multiple storage locations." & ControlChars.CrLf & ControlChars.CrLf & "• Gateway Add-in that acts as a query/retrieve proxy, automatically relaying a single query/retrieve message to any number of specified external DICOM servers." & ControlChars.CrLf & ControlChars.CrLf & "• Forwarding Add-in that allows DICOM image data to be automatically forwarded to another PACS server immediately upon storage, or on any schedule." & ControlChars.CrLf & ControlChars.CrLf & "• Administrative options including setting permissions for both users and AE titles." & ControlChars.CrLf & ControlChars.CrLf & "• Full Source code provided for customization or branding with your own company logo." & ControlChars.CrLf & ControlChars.CrLf & ""
   End Class
End Namespace
