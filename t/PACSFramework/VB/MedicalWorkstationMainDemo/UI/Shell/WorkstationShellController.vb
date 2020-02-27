' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Medical.Workstation.DataAccessLayer
Imports Leadtools.Medical.Storage.DataAccessLayer
Imports Leadtools.Medical.DataAccessLayer
Imports Leadtools.Medical.Workstation.DataAccessLayer.Configuration
Imports Leadtools.Medical.Storage.DataAccessLayer.Configuration
Imports Leadtools.Medical.UserManagementDataAccessLayer.Configuration
Imports Leadtools.Medical.UserManagementDataAccessLayer
Imports System.ComponentModel
Imports Leadtools.Medical.Workstation.UI.Factory
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration
Imports Leadtools.Medical.Workstation.UI
Imports Leadtools.Medical.Winforms
Imports System.Windows.Forms
Imports Leadtools.Demos.Workstation.Configuration
Imports Leadtools.DicomDemos
Imports System.IO
Imports Leadtools.Dicom.Server.Admin
Imports System.Diagnostics
Imports Leadtools.Medical.Workstation
Imports Leadtools.Dicom.Common.DataTypes
Imports System.Runtime.Serialization.Formatters.Binary
Imports Leadtools.Demos.StorageServer.DataTypes

#If (LEADTOOLS_V19_OR_LATER) Then
Imports Leadtools.Medical.OptionsDataAccessLayer
Imports Leadtools.Medical.OptionsDataAccessLayer.Configuration
#End If ' #if (LEADTOOLS_V19_OR_LATER)

Namespace Leadtools.Demos.Workstation
   Friend Class WorkstationShellController
#Region "Public"

#Region "Methods"

         Public Sub Run()
            Dim message As String = Nothing
            Dim dbConfigured As Boolean


            Dim productsToCheck() As String = {DicomDemoSettingsManager.ProductNameWorkstation}
            If IsUninstallMode() Then
               dbConfigured = GlobalPacsUpdater.IsDbComponentsConfigured(productsToCheck, message)
              If dbConfigured Then
                Try
                  RegisterServices()

                  DeleteServiceIfExists()
                Catch
                End Try
              End If

              Return
            End If

         CheckPacsConfig()

#If (LEADTOOLS_V19_OR_LATER) Then
         Dim globalPacsConfigPath As String = DicomDemoSettingsManager.GlobalPacsConfigFullFileName
         If File.Exists(globalPacsConfigPath) Then
            Try
               If False = UpgradeConfigFiles() Then
                  Return
               End If
            Catch ex As Exception
               Dim msg As String = String.Format("Upgrade Failed!" & Constants.vbLf + Constants.vbLf & "{0}", ex.Message)
               MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
               Return
            End Try
         End If
#End If ' #if (LEADTOOLS_V19_OR_LATER)

            dbConfigured = GlobalPacsUpdater.IsDbComponentsConfigured(productsToCheck, message)

            If (Not dbConfigured) Then
              If (Not RequestUserToConfigureDbSucess(message)) Then
                Return
              End If
         End If

         If ConfigurationData.CheckDataAccessServices Then
            If (Not GlobalPacsUpdater.IsProductDatabaseUpTodate(DicomDemoSettingsManager.ProductNameWorkstation)) AndAlso (Not RequestUserToUpgradeDbSucess()) Then
               Return
            End If
         End If

            Caption = ConfigurationData.ApplicationName

            Messager.Caption = Caption
            WorkstationMessager.Caption = Caption

            RegisterServices()

            If LogInUser() Then
               If (ConfigurationData.ShowSplashScreen) Then
                  ShowSplashScreen()
               End If


#If (Not LEADTOOLS_V175_OR_LATER) Then
				  Leadtools.Demos.Workstation.Configuration.ConfigurationData.PacsFrmKey = Leadtools.Demos.Support.MedicalServerKey
#End If

              SetWorkstationSettings()

              RegisterControls()

              ConfigureControls()

              If UserAccessManager.AuthenticatedUser.IsAdmin Then
                AddHandler ConfigurationData.ChangesSaved, AddressOf ConfigurationData_ChangesSaved
              End If

              Dim form As New MainForm()

              form.Text = Caption

              form.Icon = WorkstationUtils.GetApplicationIcon()

              AddHandler form.FormClosing, AddressOf MainForm_FormClosing

              AddHandler form.WorkStationContainerControl.LogOutRequested, AddressOf WorkStationContainerControl_LogOutRequested

              Dim TempWorkstationContainerPresenter As WorkstationContainerPresenter = New WorkstationContainerPresenter(form.WorkStationContainerControl, New ClientQueryDataSet())

              ThreadSafeMessager.Owner = form

              Application.Run(form)
            End If
         End Sub

         Public Sub UpdateDisplayOrientation(ByVal orientationConfiguration As OrientationConfiguration)
            DisplayOrientation = orientationConfiguration

            SaveDisplayOrientation()
         End Sub

#End Region

#Region "Properties"

         Public Shared ReadOnly Property Instance() As WorkstationShellController
            Get
              Return _instance
            End Get
         End Property

         Private privateWorkstationSettings As WorkstationSettings
         Public Property WorkstationSettings() As WorkstationSettings
            Get
               Return privateWorkstationSettings
            End Get
            Private Set(ByVal value As WorkstationSettings)
               privateWorkstationSettings = value
            End Set
         End Property

         Private privateDisplayOrientation As OrientationConfiguration
         Public Property DisplayOrientation() As OrientationConfiguration
            Get
               Return privateDisplayOrientation
            End Get
            Private Set(ByVal value As OrientationConfiguration)
               privateDisplayOrientation = value
            End Set
         End Property


#End Region

#Region "Events"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

#End Region

#End Region

#Region "Protected"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Events"

#End Region

#Region "Data Members"

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "Private"

#Region "Methods"

         Private Sub New()
      End Sub

      Private Shared Function UpgradeConfigFiles() As Boolean
#If (LEADTOOLS_V19_OR_LATER) Then
         Dim exeName As String = Path.GetFileNameWithoutExtension(Application.ExecutablePath)
         Dim globalPacsConfigPath As String = DicomDemoSettingsManager.GlobalPacsConfigFullFileName
         Dim backupGlobalPacsConfigPath As String = String.Empty

         ' Upgrade GlobalPacs.Config if necessary
         Dim bNeedsUpdate As Boolean = GlobalPacsUpdater.AddOptionsToGlobalPacsConfig(globalPacsConfigPath, False)
         If bNeedsUpdate Then
            Dim msg As String = String.Format("The existing globalPacs.config must be upgraded" & Constants.vbLf + Constants.vbLf & "Do you want to continue?", exeName)
            Dim dr As DialogResult = MessageBox.Show(msg, "Upgrade Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If dr <> DialogResult.Yes Then
               Return False
            End If

            backupGlobalPacsConfigPath = GlobalPacsUpdater.BackupFile(globalPacsConfigPath)
            GlobalPacsUpdater.AddOptionsToGlobalPacsConfig(globalPacsConfigPath, True)
         End If

#End If ' (LEADTOOLS_V19_OR_LATER)
         Return True
      End Function

         Private Sub ConfigureControls()
            ConfigureListenerService()

            ConfigureWSConfig()

            ConfigureViewer()
         End Sub

         Private Sub ConfigureListenerService()
            If WorkstationUIFactory.Instance.IsControlRegistered(UIElementKeys.StorageListenerService) Then
              Dim storageListenerService As StorageListenerService = WorkstationUIFactory.Instance.GetWorkstsationControl(Of StorageListenerService)(UIElementKeys.StorageListenerService)


              storageListenerService.WorkstationAddInsDll.Add("Leadtools.Medical.Storage.AddIns.dll")
              storageListenerService.WorkstationAddInsDll.Add("Leadtools.Medical.Media.AddIns.dll")

              AddHandler storageListenerService.WorkstationServiceCreated, AddressOf WorkstationListenerServiceControl_WorkstationServiceChanged
              AddHandler storageListenerService.WorkstationServiceDeleted, AddressOf WorkstationListenerServiceControl_WorkstationServiceDeleted
              AddHandler storageListenerService.WorkstationServiceChanged, AddressOf WorkstationListenerServiceControl_WorkstationServiceChanged
            End If
         End Sub

         Private Sub ConfigureWSConfig()
            If WorkstationUIFactory.Instance.IsControlRegistered(UIElementKeys.WorkstationConfiguration) Then
              Dim configurationView As WorkstationConfiguration = WorkstationUIFactory.Instance.GetWorkstsationControl(Of WorkstationConfiguration)(UIElementKeys.WorkstationConfiguration)


              configurationView.CanViewPACSConfig = UserAccessManager.AuthenticatedUser.IsAdmin
              configurationView.CanEditWorkstationClientInfo = UserAccessManager.AuthenticatedUser.IsAdmin OrElse Not ConfigurationData.SetClientToAllWorkstations
              configurationView.CanChangeForceClientInfo = UserAccessManager.AuthenticatedUser.IsAdmin
            End If
         End Sub

         Private Sub ConfigureViewer()
            If WorkstationUIFactory.Instance.IsControlRegistered(UIElementKeys.WorkstationViewer) Then
              Dim workstationViewer As WorkstationViewer = WorkstationUIFactory.Instance.GetWorkstsationControl(Of WorkstationViewer)(UIElementKeys.WorkstationViewer)

              workstationViewer.WorkstationDataAccess = DataAccessServices.GetDataAccessService(Of IWorkstationDataAccessAgent)()
              workstationViewer.StorageDataAccess = DataAccessServices.GetDataAccessService(Of IStorageDataAccessAgent)()

              workstationViewer.CanModifyWindowLevelPreset = UserAccessManager.AuthenticatedUser.IsAdmin

              LoadModalitySettings(workstationViewer)
            End If
         End Sub

         Private Sub RegisterControls()
            Dim isServiceInstalledOnMachineOrEmpty As Boolean


            If Nothing Is WorkstationSettings OrElse String.IsNullOrEmpty(WorkstationSettings.WorkstationServer) Then
              isServiceInstalledOnMachineOrEmpty = True
            Else
              isServiceInstalledOnMachineOrEmpty = Utils.IsLocalIPAddress(WorkstationSettings.WorkstationDicomServer.IPAddress)
            End If

            If ConfigurationData.SupportDicomCommunication AndAlso (Not WorkstationUISettings.Instance.Controls.Contains(UIElementKeys.MediaBurningManagerView)) Then
              Dim burningManager As Type

              burningManager = GetType(MediaBurningManagerView)

              WorkstationUISettings.Instance.Controls.Add(New NameTypeConfigurationElement(UIElementKeys.MediaBurningManagerView, burningManager))
            End If

            If (Not WorkstationUISettings.Instance.Controls.Contains(UIElementKeys.WorkstationViewer)) Then
              Dim workstationViewer As Type

              workstationViewer = GetType(WorkstationViewer)

              WorkstationUISettings.Instance.Controls.Add(New NameTypeConfigurationElement(UIElementKeys.WorkstationViewer, workstationViewer))
            End If

            If (Not WorkstationUISettings.Instance.Controls.Contains(UIElementKeys.SearchStudies)) Then
              Dim searchStudies As Type

              searchStudies = GetType(SearchStudies)

              WorkstationUISettings.Instance.Controls.Add(New NameTypeConfigurationElement(UIElementKeys.SearchStudies, searchStudies))
            End If

            If UserAccessManager.AuthenticatedUser.IsAdmin AndAlso (Not WorkstationUISettings.Instance.Controls.Contains(UIElementKeys.WorkstationConfiguration)) Then
              Dim configuration As Type

              configuration = GetType(WorkstationConfiguration)

              WorkstationUISettings.Instance.Controls.Add(New NameTypeConfigurationElement(UIElementKeys.WorkstationConfiguration, configuration))
            End If

            If ConfigurationData.SupportDicomCommunication AndAlso UserAccessManager.AuthenticatedUser.IsAdmin AndAlso isServiceInstalledOnMachineOrEmpty AndAlso (Not WorkstationUISettings.Instance.Controls.Contains(UIElementKeys.StorageListenerService)) Then
              Dim serviceManager As Type
              Dim eventLogViewer As Type


              serviceManager = GetType(StorageListenerService)
              eventLogViewer = GetType(EventLogViewerDialog)

              WorkstationUISettings.Instance.Controls.Add(New NameTypeConfigurationElement(UIElementKeys.StorageListenerService, serviceManager))
              WorkstationUISettings.Instance.Controls.Add(New NameTypeConfigurationElement(UIElementKeys.EventLogViewer, eventLogViewer))
            End If

            If UserAccessManager.AuthenticatedUser.IsAdmin AndAlso (Not WorkstationUISettings.Instance.Controls.Contains(UIElementKeys.UsersAccounts)) Then
              Dim userAccounts As Type

              userAccounts = GetType(UsersAccounts)

              WorkstationUISettings.Instance.Controls.Add(New NameTypeConfigurationElement(UIElementKeys.UsersAccounts, userAccounts))
            End If

            If ConfigurationData.SupportDicomCommunication AndAlso (Not WorkstationUISettings.Instance.Controls.Contains(UIElementKeys.QueueManager)) Then
              Dim queueManagerType As Type

              queueManagerType = GetType(QueueManager)

              WorkstationUISettings.Instance.Controls.Add(New NameTypeConfigurationElement(UIElementKeys.QueueManager, queueManagerType))

              QueueManager.Instance.AutoLoadRetrievedImages = ConfigurationData.QueueAutoLoad
              QueueManager.Instance.RemoveCompletedItems = ConfigurationData.QueueRemoveItem

              AddHandler QueueManager.Instance.AutoLoadRetrievedImagesChanged, AddressOf Instance_AutoLoadRetrievedImagesChanged
              AddHandler QueueManager.Instance.RemoveCompletedItemsChanged, AddressOf Instance_RemoveCompletedItemsChanged
            End If
         End Sub

      Private Sub RegisterServices()
         Dim globalPacsConfig As System.Configuration.Configuration = DicomDemoSettingsManager.GetGlobalPacsConfiguration()

         If (Not ConfigurationData.SupportLocalQueriesStore) Then
            Return
         End If

         Try
            Dim wsDataAccess As IWorkstationDataAccessAgent = DataAccessFactory.GetInstance(New WorkstationDataAccessConfigurationView()).CreateDataAccessAgent(Of IWorkstationDataAccessAgent)()

            DataAccessServices.RegisterDataAccessService(Of IWorkstationDataAccessAgent)(wsDataAccess)
         Catch
         End Try

         Try
            Dim storageDataAccess As IStorageDataAccessAgent = DataAccessFactory.GetInstance(New StorageDataAccessConfigurationView(globalPacsConfig, DicomDemoSettingsManager.ProductNameWorkstation, Nothing)).CreateDataAccessAgent(Of IStorageDataAccessAgent)()

            DataAccessServices.RegisterDataAccessService(Of IStorageDataAccessAgent)(storageDataAccess)
         Catch
         End Try

         Try
            Dim userManagement As IUserManagementDataAccessAgent = DataAccessFactory.GetInstance(New UserManagementDataAccessConfigurationView(globalPacsConfig, DicomDemoSettingsManager.ProductNameWorkstation, Nothing)).CreateDataAccessAgent(Of IUserManagementDataAccessAgent)()

            DataAccessServices.RegisterDataAccessService(Of IUserManagementDataAccessAgent)(userManagement)
         Catch
         End Try

#If (LEADTOOLS_V19_OR_LATER) Then
         Try
            Dim optionsAgent As IOptionsDataAccessAgent = DataAccessFactory.GetInstance(New OptionsDataAccessConfigurationView(globalPacsConfig, DicomDemoSettingsManager.ProductNameWorkstation, Nothing)).CreateDataAccessAgent(Of IOptionsDataAccessAgent)()

            DataAccessServices.RegisterDataAccessService(Of IOptionsDataAccessAgent)(optionsAgent)
         Catch
         End Try
#End If ' #if (LEADTOOLS_V19_OR_LATER)

      End Sub

         Private Shared Function IsUninstallMode() As Boolean
            Dim args() As String = System.Environment.GetCommandLineArgs()


            For Each arg As String In args
              If arg.IndexOf("uninstall", StringComparison.OrdinalIgnoreCase) = 0 Then
                Return True
              End If
            Next arg

            Return False
         End Function

         Private Function RequestUserToConfigureDbSucess(ByVal missingDbComponents As String) As Boolean
              Dim message As String
              Dim result As DialogResult


              message = "The following databases are not configured:" & Constants.vbLf + Constants.vbLf & "{0}" & Constants.vbLf & "Run the " & ConfigurationData.DatabaseConfigName & " to configure the missing databases." & Constants.vbLf + Constants.vbLf & "Do you want to run the " & ConfigurationData.DatabaseConfigName & " wizard?"

              message = String.Format(message, missingDbComponents)

              result = MessageBox.Show(message, Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

              If DialogResult.Yes = result Then
                Dim dbManagerFileName As String


                dbManagerFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), ConfigurationData.DatabaseConfigEXEName)

                If (Not File.Exists(dbManagerFileName)) Then
                  dbManagerFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), ConfigurationData.DatabaseConfigAltEXEName)
                End If

                If File.Exists(dbManagerFileName) Then
                  Dim dbConfigProcess As Process


                  dbConfigProcess = New Process()
                  dbConfigProcess.StartInfo.FileName = dbManagerFileName

                  dbConfigProcess.Start()

                  dbConfigProcess.WaitForExit()

                  Dim productsToCheck() As String = {DicomDemoSettingsManager.ProductNameWorkstation}

                  Dim isDbConfigured As Boolean = GlobalPacsUpdater.IsDbComponentsConfigured(productsToCheck, missingDbComponents)

                  If (Not isDbConfigured) Then
                     MessageBox.Show("Databases is not configured.", Caption, MessageBoxButtons.OK, MessageBoxIcon.Error)


                     Return False

                  End If
                Else
                  MessageBox.Show("Couldn't find the " & ConfigurationData.DatabaseConfigName & " wizard", Caption, MessageBoxButtons.OK, MessageBoxIcon.Error)

                  Return False
                End If
              Else
                Return False
              End If

            Return True
         End Function

      Private Shared Function RequestUserToUpgradeDbSucess() As Boolean
         Dim message As String
         Dim result As DialogResult
         Dim Caption As String = "Warning"

         message = "The Workstation database needs to be upgraded." & Constants.vbLf + Constants.vbLf & "Do you want to upgrade the database now?"

         result = MessageBox.Show(message, Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

         If DialogResult.Yes = result Then
            GlobalPacsUpdater.UpgradeProductDatabase(DicomDemoSettingsManager.ProductNameWorkstation)

            If GlobalPacsUpdater.IsProductDatabaseUpTodate(DicomDemoSettingsManager.ProductNameWorkstation) Then
               MessageBox.Show("Database upgraded successfully", Caption, MessageBoxButtons.OK, MessageBoxIcon.Information)

               Return True
            End If
         End If

         Return False

      End Function

         Private Shared Sub CheckPacsConfig()
            If ConfigurationData.RunPacsConfig Then
              Dim settings As DicomDemoSettings = Nothing


              settings = DicomDemoSettingsManager.LoadSettings(Path.GetFileName(Application.ExecutablePath))

              If settings Is Nothing Then
                DicomDemoSettingsManager.RunPacsConfigDemo()

                settings = DicomDemoSettingsManager.LoadSettings(Path.GetFileName(Application.ExecutablePath))
              End If
            End If
         End Sub

         Private Shared Sub DeleteServiceIfExists()
            Try
              Dim settings As WorkstationSettings = LoadWorkstationSettings()


              If Nothing IsNot settings AndAlso (Not String.IsNullOrEmpty(settings.WorkstationServer)) Then
                If Utils.IsLocalIPAddress(settings.WorkstationDicomServer.IPAddress) Then
                  Dim services As New List(Of String)()

                        Using serviceAdmin As New ServiceAdministrator(Application.StartupPath & "\")
                            services.Add(settings.WorkstationServer)

#If LEADTOOLS_V175_OR_LATER Then
                            serviceAdmin.Initialize()
#Else
                            serviceAdmin.Unlock(Support.MedicalServerKey)
#End If

                            If serviceAdmin.Services.Count = 1 Then
                                Dim service As DicomService

                                service = serviceAdmin.Services(settings.WorkstationServer)

                                If service.Status <> System.ServiceProcess.ServiceControllerStatus.Stopped OrElse service.Status <> System.ServiceProcess.ServiceControllerStatus.StopPending Then
                                    service.Stop()
                                End If

                                serviceAdmin.UnInstallService(serviceAdmin.Services(settings.WorkstationServer))
                            End If
                        End Using
                End If
              End If
            Catch
            End Try
         End Sub

         Private Sub SetWorkstationSettings()
            Try
              Dim settings As DicomDemoSettings


              settings = DicomDemoSettingsManager.LoadSettings(Path.GetFileName(Application.ExecutablePath))

              If Nothing IsNot settings AndAlso settings.FirstRun Then
                Dim notification As ImagesDownloadDialog


                notification = New ImagesDownloadDialog()

                notification.ShowDialog()

                settings.FirstRun = False

                DicomDemoSettingsManager.SaveSettings(Path.GetFileName(Application.ExecutablePath), settings)

                ConfigurationData.ClientBrowsingMode = DicomClientMode.Pacs

                WorkstationSettings = CreateWorkstationSettings(settings)
              Else
                WorkstationSettings = LoadWorkstationSettings()

                If (Not WorkstationSettings.SetClientToAllWorkstations) Then
                  WorkstationSettings.ClientAe = Nothing
                End If

                ConfigurationData.SetClientToAllWorkstations = WorkstationSettings.SetClientToAllWorkstations
              End If

              ConfigureServersAndClients(WorkstationSettings)

              DisplayOrientation = LoadDisplayOrientation()
            Catch e1 As Exception

            End Try
         End Sub

         Private Sub ConfigureServersAndClients(ByVal settings As IWorkstationSettings)
            If Nothing Is settings Then
              Return
            End If

            If (Not String.IsNullOrEmpty(settings.WorkstationServer)) Then
              Dim server As DicomAE


              server = settings.GetServer(settings.WorkstationServer)

              ConfigurationData.ListenerServiceName = settings.WorkstationServer

              If Nothing IsNot server Then
                ConfigurationData.WorkstationServiceAE = server.AE
              End If
            End If

            ConfigurationData.PACS.Clear()

            If settings.ServerList.Count <> 0 Then
              For Each server As DicomAE In settings.ServerList
                If (Not ServerExists(server)) AndAlso (Not IsWorkstationServer(settings, server)) Then
                        ConfigurationData.PACS.Add(New ScpInfo(server.AE, server.IPAddress, server.Port, server.Timeout, server.UseTls))
                    End If
              Next server
            End If

            If Nothing IsNot settings.ClientAe AndAlso (Not String.IsNullOrEmpty(settings.ClientAe.AE)) Then
              ConfigurationData.WorkstationClient.AETitle = settings.ClientAe.AE
              ConfigurationData.WorkstationClient.Address = settings.ClientAe.IPAddress
              ConfigurationData.WorkstationClient.Port = settings.ClientAe.Port
            End If

            If (Not String.IsNullOrEmpty(settings.DefaultImageQuery)) Then
              Dim server As DicomAE


              server = settings.GetServer(settings.DefaultImageQuery)

              If Nothing IsNot server Then
                    ConfigurationData.DefaultQueryRetrieveServer = New ScpInfo(server.AE, server.IPAddress, server.Port, server.Timeout, server.UseTls)
                End If
            End If

            If (Not String.IsNullOrEmpty(settings.DefaultStore)) Then
              Dim server As DicomAE


              server = settings.GetServer(settings.DefaultStore)

              If Nothing IsNot server Then
                    ConfigurationData.DefaultStorageServer = New ScpInfo(server.AE, server.IPAddress, server.Port, server.Timeout, server.UseTls)
                End If
            End If

            If ConfigurationData.SaveSessionBehavior <> SaveOptions.NeverSave Then
                ConfigurationData.SaveChanges()
            End If
        End Sub

         Private Function CreateWorkstationSettings(ByVal settings As DicomDemoSettings) As WorkstationSettings
            Dim wsSettings As New WorkstationSettings()


            wsSettings.DefaultImageQuery = settings.DefaultImageQuery
            wsSettings.DefaultStore = settings.DefaultStore

            wsSettings.ServerList.AddRange(settings.ServerList)

            Dim server As DicomAE = settings.GetServer(settings.WorkstationServer)

            If Nothing IsNot server Then
              wsSettings.ServerList.Remove(server)
              wsSettings.WorkstationDicomServer = server
              wsSettings.WorkstationServer = server.AE
            End If

            wsSettings.ClientAe = settings.ClientAe

            SaveWorkstationSettings(wsSettings)

            Return wsSettings
         End Function

         Private Function ServerExists(ByVal server As DicomAE) As Boolean
            For Each scp As ScpInfo In ConfigurationData.PACS
              If scp.AETitle = server.AE AndAlso scp.Address = server.IPAddress AndAlso scp.Port = server.Port Then
                Return True
              End If
            Next scp

            Return False
         End Function

         Private Function IsWorkstationServer(ByVal settings As IWorkstationSettings, ByVal server As DicomAE) As Boolean
            If (Not String.IsNullOrEmpty(settings.WorkstationServer)) Then
              Dim wsServer As DicomAE


              wsServer = settings.GetServer(settings.WorkstationServer)

              If Nothing IsNot wsServer Then
                Return (wsServer.AE = server.AE AndAlso wsServer.IPAddress = server.IPAddress)
              End If
            End If

            Return False
         End Function

         Private Function LogInUser() As Boolean
            If UserAccessManager.AuthenticatedUser Is Nothing AndAlso (Not UserAuthenticatedFromArgs()) Then
              Dim logIn As LogInDialog


              logIn = New LogInDialog()

              If logIn.ShowDialog() = DialogResult.OK Then
                Return (Nothing IsNot UserAccessManager.AuthenticatedUser)
              Else
                Return False
              End If
            Else
              Return True
            End If
         End Function

         Private Function UserAuthenticatedFromArgs() As Boolean
            Dim args() As String = System.Environment.GetCommandLineArgs()
            Dim userName As String = ""
            Dim password As String = ""


            For Each arg As String In args
              If arg.IndexOf("UserName", StringComparison.OrdinalIgnoreCase) = 0 Then
                userName = GetValueFromArg(arg)
              End If

              If arg.IndexOf("Password", StringComparison.OrdinalIgnoreCase) = 0 Then
                password = GetValueFromArg(arg)
              End If
            Next arg

            If (Not String.IsNullOrEmpty(userName)) AndAlso (Not String.IsNullOrEmpty(password)) Then
              Return UserAccessManager.AuthenticateUser(userName, UserAccessManager.GetSecureString(password))
            End If

            Return False
         End Function

         Private Function GetValueFromArg(ByVal arg As String) As String
            Dim tokens() As String


            tokens = arg.Split("="c)

            If tokens.Length = 2 Then
              Return tokens(1).Trim()
            Else
              Return Nothing
            End If
         End Function

         Private Shared Sub ShowSplashScreen()
            Dim splash As WorkstationSplashScreen


            splash = New WorkstationSplashScreen()

            splash.Show()

            splash.Update()

            System.Threading.Thread.Sleep(3000)

            splash.Close()
         End Sub

         Private Sub SaveWorkstationSettings()
            If WorkstationSettings IsNot Nothing AndAlso UserAccessManager.AuthenticatedUser.IsAdmin Then
              If ConfigurationData.WorkstationClient IsNot Nothing AndAlso ConfigurationData.SetClientToAllWorkstations Then
                WorkstationSettings.ClientAe = ConfigurationData.WorkstationClient.ToDicomAE()
              End If

              If Nothing IsNot ConfigurationData.DefaultQueryRetrieveServer Then
                WorkstationSettings.DefaultImageQuery = ConfigurationData.DefaultQueryRetrieveServer.AETitle
              End If

              If Nothing IsNot ConfigurationData.DefaultStorageServer Then
                WorkstationSettings.DefaultStore = ConfigurationData.DefaultStorageServer.AETitle
              End If

              WorkstationSettings.ServerList.Clear()

              For Each scp As ScpInfo In ConfigurationData.PACS
                WorkstationSettings.ServerList.Add(New DicomAE(scp.AETitle, scp.Address, scp.Port, scp.Timeout, False))
              Next scp

              WorkstationSettings.SetClientToAllWorkstations = ConfigurationData.SetClientToAllWorkstations

              SaveWorkstationSettings(WorkstationSettings)
            End If
         End Sub

         Private Sub LoadModalitySettings(ByVal viewer As WorkstationViewer)
            Dim dataAccess As IWorkstationDataAccessAgent


            dataAccess = DataAccessServices.GetDataAccessService(Of IWorkstationDataAccessAgent)()

            If Nothing IsNot dataAccess Then
              If (Not dataAccess.IsConfigurationRegistered(ModalitySettingsConfigName)) Then
                viewer.ModalityManager.FillDefaultOptions()
              Else
                Dim configuration As String
                Dim modalitySettingsBuffer() As Byte

                configuration = dataAccess.ReadConfiguration(ModalitySettingsConfigName)

                If (Not String.IsNullOrEmpty(configuration)) Then
                  modalitySettingsBuffer = Encoding.GetEncoding(0).GetBytes(configuration)

                  Using ms As New MemoryStream(modalitySettingsBuffer)
                     viewer.ModalityManager.LoadOptions(ms)
                  End Using
                Else
                  viewer.ModalityManager.FillDefaultOptions()
                End If
              End If
            End If
         End Sub

         Private Sub SaveModalitySettings()
            Dim dataAccess As IWorkstationDataAccessAgent


            dataAccess = DataAccessServices.GetDataAccessService(Of IWorkstationDataAccessAgent)()

            If Nothing IsNot dataAccess Then
              Using ms As New MemoryStream()
                If WorkstationUIFactory.Instance.IsControlRegistered(UIElementKeys.WorkstationViewer) Then
                  WorkstationUIFactory.Instance.GetWorkstsationControl(Of WorkstationViewer)(UIElementKeys.WorkstationViewer).ModalityManager.SaveOptions(ms)
                End If

                If (Not dataAccess.IsConfigurationRegistered(ModalitySettingsConfigName)) Then
                  dataAccess.RegisterConfiguration(ModalitySettingsConfigName)
                End If

                dataAccess.UpdateConfiguration(ModalitySettingsConfigName, Encoding.GetEncoding(0).GetString(ms.ToArray()))
              End Using
            End If
         End Sub

         Private Shared Function LoadWorkstationSettings() As WorkstationSettings
            Dim dataAccess As IWorkstationDataAccessAgent


            dataAccess = DataAccessServices.GetDataAccessService(Of IWorkstationDataAccessAgent)()

            If Nothing IsNot dataAccess Then
              If dataAccess.IsConfigurationRegistered(WSComponentConfigName) Then
                Dim configuration As String = dataAccess.ReadConfiguration(WSComponentConfigName)

                If (Not String.IsNullOrEmpty(configuration)) Then
                  Return WorkstationSettings.Load(configuration)
                End If
              End If
            End If

            Return New WorkstationSettings()
         End Function

         Private Shared Sub SaveWorkstationSettings(ByVal settings As WorkstationSettings)
            Dim dataAccess As IWorkstationDataAccessAgent
            Dim configuration As String


            dataAccess = DataAccessServices.GetDataAccessService(Of IWorkstationDataAccessAgent)()

            If Nothing IsNot dataAccess Then
              If (Not dataAccess.IsConfigurationRegistered(WSComponentConfigName)) Then
                dataAccess.RegisterConfiguration(WSComponentConfigName)
              End If

              configuration = WorkstationSettings.Save(settings)

              dataAccess.UpdateConfiguration(WSComponentConfigName, configuration)
            End If
         End Sub

         Private Function LoadDisplayOrientation() As OrientationConfiguration
            Dim dataAccess As IWorkstationDataAccessAgent


            dataAccess = DataAccessServices.GetDataAccessService(Of IWorkstationDataAccessAgent)()

            If Nothing IsNot dataAccess Then
              If dataAccess.IsConfigurationRegistered(OrientationConfigurationConfigName) Then
                Dim configuration As String = dataAccess.ReadConfiguration(OrientationConfigurationConfigName)

                If (Not String.IsNullOrEmpty(configuration)) Then
                  Dim formatter As New BinaryFormatter()

                  Using ms As New MemoryStream(Convert.FromBase64String(configuration))
                     Return TryCast(formatter.Deserialize(ms), OrientationConfiguration)
                  End Using
                End If
              End If
            Else
              Dim settingsFile As String


              settingsFile = Path.ChangeExtension(GetType(OrientationConfiguration).Name, "dat")

              If File.Exists(settingsFile) Then
                Dim formatter As New BinaryFormatter()

                Using ms As New MemoryStream(File.ReadAllBytes(settingsFile))
                  Return TryCast(formatter.Deserialize(ms), OrientationConfiguration)
                End Using
              End If
            End If

            Return New OrientationConfiguration()
         End Function

         Private Sub SaveDisplayOrientation()
            Dim dataAccess As IWorkstationDataAccessAgent


            dataAccess = DataAccessServices.GetDataAccessService(Of IWorkstationDataAccessAgent)()

            If Nothing IsNot dataAccess Then
              If (Not dataAccess.IsConfigurationRegistered(OrientationConfigurationConfigName)) Then
                dataAccess.RegisterConfiguration(OrientationConfigurationConfigName)
              End If

              Dim formatter As New BinaryFormatter()

              Using stream As New MemoryStream()
                formatter.Serialize(stream, DisplayOrientation)

                dataAccess.UpdateConfiguration(OrientationConfigurationConfigName, Convert.ToBase64String(stream.ToArray(), Base64FormattingOptions.None))
              End Using
            End If
         End Sub

#End Region

#Region "Properties"

#End Region

#Region "Events"

         Private Sub Instance_RemoveCompletedItemsChanged(ByVal sender As Object, ByVal e As EventArgs)
            ConfigurationData.QueueRemoveItem = QueueManager.Instance.RemoveCompletedItems
         End Sub

         Private Sub Instance_AutoLoadRetrievedImagesChanged(ByVal sender As Object, ByVal e As EventArgs)
            ConfigurationData.QueueAutoLoad = QueueManager.Instance.AutoLoadRetrievedImages
         End Sub

         Private Sub WorkstationListenerServiceControl_WorkstationServiceChanged(ByVal sender As Object, ByVal e As WorkstationServiceEventArgs)
            Try
              If Nothing IsNot WorkstationSettings Then

                WorkstationSettings.WorkstationServer = e.ServiceName

                WorkstationSettings.WorkstationDicomServer = New DicomAE(e.Service.Settings.AETitle, e.Service.Settings.IpAddress, e.Service.Settings.Port, e.Service.Settings.ReconnectTimeout, e.Service.Settings.Secure)

                ConfigurationData.ListenerServiceName = e.ServiceName
                ConfigurationData.WorkstationServiceAE = e.Service.Settings.AETitle

                SaveWorkstationSettings(WorkstationSettings)
              End If
            Catch
            End Try
         End Sub

         Private Sub WorkstationListenerServiceControl_WorkstationServiceDeleted(ByVal sender As Object, ByVal e As WorkstationServiceEventArgs)
            Try
              If Nothing IsNot WorkstationSettings Then
                WorkstationSettings.WorkstationServer = Nothing
                WorkstationSettings.WorkstationDicomServer = Nothing

                ConfigurationData.ListenerServiceName = String.Empty
                ConfigurationData.WorkstationServiceAE = String.Empty

                SaveWorkstationSettings(WorkstationSettings)
              End If
            Catch
            End Try
         End Sub

         Private Sub ConfigurationData_ChangesSaved()
            Try
              SaveWorkstationSettings()
            Catch
              Throw New ApplicationException("Error saving configuration into database.")
            End Try
         End Sub

         Private Sub WorkStationContainerControl_LogOutRequested(ByVal sender As Object, ByVal e As EventArgs)
            Try
              If Nothing IsNot (CType(sender, Control)).FindForm() Then
                CType(sender, Control).FindForm().Close()
              End If
            Catch exception As Exception
              ThreadSafeMessager.ShowError(exception.Message)
            End Try
         End Sub

         Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
            Try
              CanCloseDemo(e)
            Catch exception As Exception
              ThreadSafeMessager.ShowError(exception.Message)

              e.Cancel = False
            End Try
         End Sub

         Private Sub CanCloseDemo(ByVal e As FormClosingEventArgs)
            If (ConfigurationData.SaveSessionBehavior <> SaveOptions.NeverSave) AndAlso ((ConfigurationData.HasChanges()) OrElse (WorkstationUIFactory.Instance.IsControlRegistered(UIElementKeys.UsersAccounts) AndAlso WorkstationUIFactory.Instance.GetWorkstsationControl(Of UsersAccounts)(UIElementKeys.UsersAccounts).HasChanges())) Then
              If ConfigurationData.SaveSessionBehavior = SaveOptions.PromptUser Then
                Dim result As DialogResult


                result = ThreadSafeMessager.ShowQuestion("Do you want to save current session's settings before exit?", MessageBoxButtons.YesNoCancel)

                If DialogResult.Yes = result Then
                  SaveAllChanges()
                ElseIf DialogResult.Cancel = result Then
                  e.Cancel = True
                End If
              ElseIf ConfigurationData.SaveSessionBehavior = SaveOptions.AlwaysSave Then
                If DialogResult.Yes = ThreadSafeMessager.ShowQuestion("Are you sure you want to exit?", MessageBoxButtons.YesNo) Then
                  SaveAllChanges()
                Else
                  e.Cancel = True
                End If
              End If
            Else
              If DialogResult.No = ThreadSafeMessager.ShowQuestion("Are you sure you want to exit?", MessageBoxButtons.YesNo) Then
                e.Cancel = True
              End If
            End If

            If ConfigurationData.SaveSessionBehavior <> SaveOptions.NeverSave AndAlso (Not e.Cancel) Then
              SaveModalitySettings()
            End If
         End Sub

         Private Sub SaveAllChanges()
            If ConfigurationData.HasChanges() Then
              ConfigurationData.SaveChanges()
            End If

            If (WorkstationUIFactory.Instance.IsControlRegistered(UIElementKeys.UsersAccounts) AndAlso WorkstationUIFactory.Instance.GetWorkstsationControl(Of UsersAccounts)(UIElementKeys.UsersAccounts).HasChanges()) Then
              WorkstationUIFactory.Instance.GetWorkstsationControl(Of UsersAccounts)(UIElementKeys.UsersAccounts).SaveChanges()
            End If
         End Sub

#End Region

#Region "Data Members"

         Private Shared _instance As New WorkstationShellController()
         Private Shared Caption As String = String.Empty
         Private Const ModalitySettingsConfigName As String = "WorkstationViewerControl.ModalitySettings"
         Private Const WSComponentConfigName As String = "WorkstationViewerControl.WorkstationSettings"
         Private Const OrientationConfigurationConfigName As String = "WorkstationViewerControl.OrientationConfiguration"

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "internal"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Events"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

#End Region

#End Region
   End Class

   Friend Class UIElementKeys
     Public Const WorkstationViewer As String = "WorkstationViewer"
     Public Const MediaBurningManagerView As String = "MediaBurningManagerView"
     Public Const SearchStudies As String = "SearchStudies"
     Public Const WorkstationConfiguration As String = "WorkstationConfiguration"
     Public Const StorageListenerService As String = "StorageListenerService"
     Public Const EventLogViewer As String = "EventLogViewer"
     Public Const UsersAccounts As String = "UsersAccounts"
     Public Const QueueManager As String = "QueueManager"
   End Class
End Namespace
