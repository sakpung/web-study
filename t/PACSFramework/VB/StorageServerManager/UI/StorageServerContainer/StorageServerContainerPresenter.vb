' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports Leadtools.Demos.StorageServer.UI
Imports System.Windows.Forms
Imports Leadtools.Medical.Winforms
Imports System.Drawing
Imports Leadtools.Medical.Storage.DataAccessLayer
Imports Leadtools.Medical.DataAccessLayer
Imports Leadtools.Medical.Storage.DataAccessLayer.Configuration
Imports Leadtools.Medical.Logging.DataAccessLayer.Configuration
Imports System.Configuration
Imports Leadtools.Medical.DataAccessLayer.Configuration
Imports Leadtools.Medical.OptionsDataAccessLayer.Configuration
Imports Leadtools.Dicom.AddIn.Common
Imports Leadtools.Medical.UserManagementDataAccessLayer.Configuration
Imports Leadtools.Medical.AeManagement.DataAccessLayer.Configuration
Imports Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
Imports Leadtools.DicomDemos
Imports Leadtools.Dicom.AddIn.Interfaces
Imports Leadtools.Dicom
Imports Leadtools.Demos.StorageServer.DataTypes
Imports Leadtools.Medical.Storage.AddIns.Configuration
Imports Leadtools.Medical.Storage.AddIns
Imports Leadtools.Dicom.AddIn
Imports Leadtools.Demos.StorageServer.UI.RealtimeView
Imports Leadtools.Medical.Winforms.ClientManager

#If (LEADTOOLS_V19_OR_LATER_EXPORT) OrElse (LEADTOOLS_V19_OR_LATER) Then
Imports Leadtools.Dicom.Scp.Command
#End If ' #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

Namespace Leadtools.Demos.StorageServer
    Partial Public Class StorageServerContainerPresenter
        Private _License As ILicense
        Private _FeatureStudyCount As IFeature
        Private _FeatureSeriesCount As IFeature
        Private _AccessAgent As IStorageDataAccessAgent
        Private __DbManager As StorageDatabaseManager
        Private __ServerInfoView As ServerInformationView

        Public Sub New()
            ProductName = DicomDemoSettingsManager.ProductNameStorageServer
        End Sub

        Private _productName As String
        Public Property ProductName() As String
            Get
                Return _productName
            End Get
            Set(ByVal value As String)
                _productName = value
            End Set
        End Property

        Public Sub RunView(ByVal _view As StorageServerContainerView)
            View = _view

            CreateContainerPages()

            EventBroker.Instance.Subscribe(Of CurrentUserPemissionsChangedEventArgs)(AddressOf OnCurrentUserPermissionChanged)
            EventBroker.Instance.Subscribe(Of ServerSettingsAppliedEventArgs)(AddressOf OnServerSettingsApplied)
        End Sub

        Private Sub CreateContainerPages()
            Dim controlPanelView As ControlPanelView = New ControlPanelView()
            Dim serverInfoView As ServerInformationView = New ServerInformationView()
            Dim serverAddInView As ServerAddinsView = New ServerAddinsView()
            Dim serverSettingsDlg As ServerSettingsDialog = New ServerSettingsDialog()
            Dim serverInfoControl As ServerInformationControl = New ServerInformationControl()

            Dim controlPanelPresenter As ControlPanelPresenter = New ControlPanelPresenter()
            Dim serverInfoPresenter As ServerInformationPresenter = New ServerInformationPresenter()
            Dim serverAddInPresenter As ServerAddinPresenter = New ServerAddinPresenter()
            Dim serverSettingsPresenter As ServerSettingsPresenter = New ServerSettingsPresenter()
            Dim realTimePresenter As RealTimeViewPresenter = New RealTimeViewPresenter()

            Dim dbManager As StorageDatabaseManager = New StorageDatabaseManager()
            Dim logViewer As EventLogViewer = New EventLogViewer()
            Dim realTimeView As RealTimeViewerControl = New RealTimeViewerControl()

            dbManager.BackColor = Color.FromArgb(75, 75, 75)
            logViewer.BackColor = Color.White
            serverInfoControl.BackColor = Color.White

            ThemesManager.ApplyTheme(controlPanelView)
            ThemesManager.ApplyTheme(logViewer)
            ThemesManager.ApplyTheme(dbManager)
            ThemesManager.ApplyTheme(serverInfoControl)
            ThemesManager.ApplyTheme(realTimeView)

            ConfigureServerInfoConrol(serverInfoControl)

            View.SetHeader(serverInfoView)

            AddPage(New PageData(controlPanelView, "Control Panel", Nothing))

            'AddPage ( new PageData ( new Control ( ), "Security", null ) ) ;
            AddPage(New PageData(logViewer, "Event Log", Nothing))
            AddPage(New PageData(serverInfoControl, "System Information", Nothing))

            dbManager.MergeImportDicom = True

#If (LEADTOOLS_V19_OR_LATER_EXPORT) OrElse (LEADTOOLS_V19_OR_LATER) Then
            dbManager.EnableExport = True
#End If ' #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

            dbManager.Enabled = Not ServerState.Instance.ServerService Is Nothing

            AddPage(New PageData(dbManager, "Database Manager", Nothing))

            AddPage(New PageData(realTimeView, "Live View", Nothing))

            InitializeLicenseView()

            serverAddInView.Enabled = UserManager.User.IsAdmin()
            AddPage(New PageData(serverAddInView, "Add-ons", Nothing))

            controlPanelPresenter.RunView(controlPanelView)
            serverInfoPresenter.RunView(serverInfoView)
            serverAddInPresenter.RunView(serverAddInView)
            serverSettingsPresenter.RunView(serverSettingsDlg)
            realTimePresenter.RunView(realTimeView)

            If DataAccessServices.IsDataAccessServiceRegistered(Of IStorageDataAccessAgent)() Then
                _AccessAgent = DataAccessServices.GetDataAccessService(Of IStorageDataAccessAgent)()
            End If

            AddHandler dbManager.CancelStore, AddressOf dbManager_CancelStore
            AddHandler dbManager.ConfigureStoreCommand, AddressOf dbManager_ConfigureStoreCommand

#If (LEADTOOLS_V19_OR_LATER_EXPORT) OrElse (LEADTOOLS_V19_OR_LATER) Then
            AddHandler dbManager.ConfigureStoreExportCommand, AddressOf dbManager_ConfigureStoreCommandExport
#End If ' #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

            Instance_LicenseChanged(Me, EventArgs.Empty)
            AddHandler ServerState.Instance.LicenseChanged, AddressOf Instance_LicenseChanged


            __DbManager = dbManager
            __ServerInfoView = serverInfoView

            ApplyPermissions()

            ApplyStorageSettingsPermissions()
        End Sub

        Private Sub ApplyStorageSettingsPermissions()
            If Not Nothing Is __DbManager Then
                Dim configManager As StorageModuleConfigurationManager = ServiceLocator.Retrieve(Of StorageModuleConfigurationManager)()
                If configManager.IsLoaded Then
                    Dim storageSettings As StorageAddInsConfiguration = configManager.GetStorageAddInsSettings()

                    If Not storageSettings Is Nothing Then
                        __DbManager.DeleteFilesOnDatabaseDelete = storageSettings.StoreAddIn.DeleteFiles
                        __DbManager.BackupFilesOnDatabaseDelete = storageSettings.StoreAddIn.BackupFilesOnDelete
                        __DbManager.BackupFilesOnDeleteFolder = storageSettings.StoreAddIn.DeleteBackupLocation
                    End If
                End If
            End If
        End Sub

        Private Sub ApplyPermissions()
            If Nothing IsNot __DbManager Then
                __DbManager.CanDelete = UserManager.User.IsAuthorized(UserPermissions.CanDeleteFromDatabase)
                __DbManager.CanEmptyDatabase = UserManager.User.IsAuthorized(UserPermissions.CanEmptyDatabase)
                __ServerInfoView.CanChangeSettings = UserManager.User.IsAuthorized(UserPermissions.Admin) OrElse UserManager.User.IsAuthorized(UserPermissions.CanChangeServerSettings)

#If (LEADTOOLS_V19_OR_LATER_EXPORT) OrElse (LEADTOOLS_V19_OR_LATER) Then
                __DbManager.CanChangeSettings = UserManager.User.IsAuthorized(UserPermissions.Admin) OrElse UserManager.User.IsAuthorized(UserPermissions.CanChangeServerSettings)
#End If ' #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
            End If
        End Sub

        Private Sub OnCurrentUserPermissionChanged(ByVal sender As Object, ByVal e As CurrentUserPemissionsChangedEventArgs)
            ApplyPermissions()
        End Sub

        Private Sub OnServerSettingsApplied(ByVal sender As Object, ByVal e As ServerSettingsAppliedEventArgs)
            ApplyStorageSettingsPermissions()
        End Sub

        Private Sub Instance_LicenseChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try
                _License = ServerState.Instance.License
                If Not _License Is Nothing Then
                    _FeatureStudyCount = _License.GetFeature(ServerFeatures.MaxStudiesStored)
                    _FeatureSeriesCount = _License.GetFeature(ServerFeatures.MaxSeriesStored)
                End If
            Catch
            End Try
        End Sub

        Private Sub dbManager_CancelStore(ByVal sender As Object, ByVal e As CancelStoreEventArgs)
            Try
                ValidateLicense(e)
            Catch
            End Try
        End Sub

        Private Sub dbManager_ConfigureStoreCommand(ByVal sender As Object, ByVal e As StoreCommandEventArgs)
            Try
                If Not ServerState.Instance.ServerService Is Nothing Then
                    Dim configManager As StorageModuleConfigurationManager = ServiceLocator.Retrieve(Of StorageModuleConfigurationManager)()

                    If configManager.IsLoaded Then
                        Dim storageSettings As StorageAddInsConfiguration = configManager.GetStorageAddInsSettings()

                        StoreCommandInitializationService.ConfigureCStoreCommand(e.Command, storageSettings.StoreAddIn)
                        StoreCommandInitializationService.ConfigureInstanceCStoreCommand(e.Command, storageSettings.StoreAddIn)
                    End If
                End If
            Catch
            End Try
        End Sub

#If (LEADTOOLS_V19_OR_LATER_EXPORT) OrElse (LEADTOOLS_V19_OR_LATER) Then
        Shared Sub dbManager_ConfigureStoreCommandExport(ByVal sender As Object, ByVal e As StoreCommandEventArgs)
            Try
                If ServerState.Instance.ServerService IsNot Nothing Then
                    Dim configManager As StorageModuleConfigurationManager = ServiceLocator.Retrieve(Of StorageModuleConfigurationManager)()

                    If configManager.IsLoaded Then
                        Dim storageSettings As StorageAddInsConfiguration = configManager.GetStorageAddInsSettings()

                        StoreCommandInitializationService.ConfigureCStoreCommand(e.Command, storageSettings.StoreAddIn)


                        ' StoreCommandInitializationService.ConfigureInstanceCStoreCommand ( e.Command, storageSettings.StoreAddIn ) ;

                        Dim instanceStoreCommand As InstanceCStoreCommand = TryCast(e.Command, InstanceCStoreCommand)
                        If instanceStoreCommand IsNot Nothing Then
                            instanceStoreCommand.InstanceConfiguration.CreateBackupForDuplicateSop = False
                            instanceStoreCommand.InstanceConfiguration.UpdateInstanceData = False
                            instanceStoreCommand.InstanceConfiguration.UpdatePatientData = False
                            instanceStoreCommand.InstanceConfiguration.UpdateSeriesData = False
                            instanceStoreCommand.InstanceConfiguration.UpdateStudyData = False
                            instanceStoreCommand.InstanceConfiguration.ValidateDuplicateSopInstanceUID = False
                        End If
                    End If

                End If
            Catch
            End Try
        End Sub
#End If ' #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

        Private Sub ValidateLicense(ByVal e As CancelStoreEventArgs)
            If _License Is Nothing Then
                e.Cancel = True
                e.CancelMessage = "No valid license provided."
            Else
                If Not _AccessAgent Is Nothing Then
                    Dim instance As String = String.Empty
                    Dim count As Integer
                    Dim mpc As New MatchingParameterCollection()
                    mpc(0) = New MatchingParameterList()

                    If Not _FeatureStudyCount Is Nothing Then
                        instance = e.DataSet.GetValue(Of String)(DicomTag.StudyInstanceUID, String.Empty)
                        If (Not _AccessAgent.IsStudyExists(instance)) Then
                            count = _AccessAgent.FindStudiesCount(mpc)
                            If _FeatureStudyCount.Counter > 0 AndAlso (count + 1) > _FeatureStudyCount.Counter Then
                                e.Cancel = True
                                If count = 1 Then
                                    e.CancelMessage = String.Format("Max study limit reached, Study ({0}) not stored.  The license is restricted to storing {1} {2}.", instance, count, "study")
                                Else
                                    e.CancelMessage = String.Format("Max study limit reached, Study ({0}) not stored.  The license is restricted to storing {1} {2}.", instance, count, "studies")
                                End If
                                Return
                            End If
                        End If
                    End If

                    If Not _FeatureSeriesCount Is Nothing Then
                        instance = e.DataSet.GetValue(Of String)(DicomTag.SeriesInstanceUID, String.Empty)
                        If (Not _AccessAgent.IsSeriesExists(instance)) Then
                            count = _AccessAgent.FindSeriesCount(mpc)
                            If _FeatureSeriesCount.Counter > 0 AndAlso (count + 1) > _FeatureSeriesCount.Counter Then
                                e.Cancel = True
                                e.CancelMessage = String.Format("Max series limit reached, Series ({0}) not stored.  The license is restricted to storing {1} series.", instance, count)
                                Return
                            End If
                        End If
                    End If
                End If
            End If
        End Sub

        Public Sub AddPage(ByVal pageData As PageData)
            ValidateView()

            View.Pages.Add(pageData)
        End Sub

        Private Sub ValidateView()
            If Nothing Is View Then
                Throw New InvalidOperationException("View is not initialized.")
            End If
        End Sub

        Private _view As StorageServerContainerView
        Public Property View() As StorageServerContainerView
            Get
                Return _view
            End Get
            Private Set(ByVal value As StorageServerContainerView)
                _view = value
            End Set
        End Property

        Private _serverInfoControl As ServerInformationControl

        Private Sub ConfigureServerInfoConrol(ByVal serverInfoControl As ServerInformationControl)
            Dim logging As ConnectionStringSettings
            Dim storage As ConnectionStringSettings
            Dim options As ConnectionStringSettings
            Dim userManagement As ConnectionStringSettings
            Dim aeManagement As ConnectionStringSettings

            Dim configPacs As System.Configuration.Configuration = DicomDemoSettingsManager.GetGlobalPacsConfiguration()

            ' Machine.config file
            Dim configMachine As System.Configuration.Configuration = ConfigurationManager.OpenMachineConfiguration()

            logging = GetConnectionString(configPacs, configMachine, New LoggingDataAccessConfigurationView(configPacs, PacsProduct.ProductName, Nothing).DataAccessSettingsSectionName)
            storage = GetConnectionString(configPacs, configMachine, New StorageDataAccessConfigurationView(configPacs, PacsProduct.ProductName, Nothing).DataAccessSettingsSectionName)
            options = GetConnectionString(configPacs, configMachine, New OptionsDataAccessConfigurationView(configPacs, PacsProduct.ProductName, Nothing).DataAccessSettingsSectionName)

            userManagement = GetConnectionString(configPacs, configMachine, New UserManagementDataAccessConfigurationView(configPacs, ProductName, Nothing).DataAccessSettingsSectionName)
            aeManagement = GetConnectionString(configPacs, configMachine, New AeManagementDataAccessConfigurationView(configPacs, PacsProduct.ProductName, Nothing).DataAccessSettingsSectionName)



            Dim connections As Dictionary(Of String, String) = New Dictionary(Of String, String)()
            Dim storageDatabaseName As String = "Storage Database"
            connections.Add(storageDatabaseName, storage.ConnectionString)
            connections.Add("Logging Database", logging.ConnectionString)
            connections.Add("Server Configuration Database", options.ConnectionString)
            connections.Add("User Management Database", userManagement.ConnectionString)
            connections.Add("Client Management Database", aeManagement.ConnectionString)

            serverInfoControl.SqlDatabaseList = connections
            serverInfoControl.StorageDatabaseName = storageDatabaseName
            If ServerState.Instance.ServerService Is Nothing Then
                serverInfoControl.MaximumClientConnectionCount = 5
            Else
                serverInfoControl.MaximumClientConnectionCount = ServerState.Instance.ServerService.Settings.MaxClients
            End If
            AddHandler serverInfoControl.RequestCurrentClientConnectionCount, AddressOf serverInfoControl_RequestCurrentClientConnectionCount
            If ServerState.Instance.ServerService Is Nothing Then
                serverInfoControl.ServiceName = String.Empty
            Else
                serverInfoControl.ServiceName = ServerState.Instance.ServiceName
            End If
            _serverInfoControl = serverInfoControl

            If Not ServerState.Instance.ServerService Is Nothing Then
                AddHandler ServerState.Instance.ServerService.Message, AddressOf ServerService_Message
                AddHandler ServerState.Instance.ServerService.StatusChange, AddressOf ServerService_StatusChange
                If ServerState.Instance.ServerService.Status = System.ServiceProcess.ServiceControllerStatus.Running Then
                    _serverInfoControl.SetStartTime()
                End If
            End If

            AddHandler ServerState.Instance.ServerServiceChanged, AddressOf Instance_ServerServiceChanged
            EventBroker.Instance.Subscribe(Of ServerSettingsAppliedEventArgs)(New EventHandler(Of ServerSettingsAppliedEventArgs)(AddressOf OnSettingsChanged))
        End Sub

        Private Sub ServerService_StatusChange(ByVal sender As Object, ByVal e As EventArgs)
            If ServerState.Instance.ServerService.Status = System.ServiceProcess.ServiceControllerStatus.Running Then
                _serverInfoControl.SetStartTime()
            ElseIf ServerState.Instance.ServerService.Status = System.ServiceProcess.ServiceControllerStatus.Stopped Then
                _serverInfoControl.ResetStartTime()
            End If
        End Sub

        Private Sub OnSettingsChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Not ServerState.Instance.ServerService Is Nothing Then
                _serverInfoControl.MaximumClientConnectionCount = ServerState.Instance.ServerService.Settings.MaxClients
            End If
        End Sub

        Private Sub Instance_ServerServiceChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try
                If Not ServerState.Instance.ServerService Is Nothing Then
                    AddHandler ServerState.Instance.ServerService.Message, AddressOf ServerService_Message

                    _serverInfoControl.ServiceName = ServerState.Instance.ServiceName
                    AddHandler ServerState.Instance.ServerServiceChanged, AddressOf Instance_ServerServiceChanged
                End If

                If Not Nothing Is __DbManager Then
                    __DbManager.Enabled = Not ServerState.Instance.ServerService Is Nothing
                End If
            Catch
            End Try
        End Sub


        Delegate Sub Invoker(ByVal parameter As Integer)

        Private Sub UpdateServerInfoControlConnectionCount(ByVal count As Integer)
            If _serverInfoControl.InvokeRequired Then
                _serverInfoControl.BeginInvoke(New Invoker(AddressOf UpdateServerInfoControlConnectionCount), count)
            Else
                _serverInfoControl.CurrentClientConnectionCount = count
            End If
        End Sub

        Private Sub ServerService_Message(ByVal sender As Object, ByVal e As Leadtools.Dicom.Server.Admin.MessageEventArgs)
            Try
                If e.Message.Message = MessageNames.GetTotalClients Then
                    Dim count As Integer = 0
                    If (e.Message.Success) AndAlso (Not e.Message.Data Is Nothing) AndAlso (e.Message.Data.Count = 1) Then
                        count = CInt(e.Message.Data(0))
                    End If
                    UpdateServerInfoControlConnectionCount(count)
                End If
            Catch
            End Try
        End Sub

        Private Sub GetConnectionCount(ByVal data As Object)
            If (Not ServerState.Instance.ServerService Is Nothing) AndAlso (ServerState.Instance.ServerService.Status = System.ServiceProcess.ServiceControllerStatus.Running) Then
                ServerState.Instance.ServerService.SendMessage(MessageNames.GetTotalClients)
            Else
                UpdateServerInfoControlConnectionCount(0)
            End If
        End Sub

        Private Sub serverInfoControl_RequestCurrentClientConnectionCount(ByVal sender As Object, ByVal e As CurrentClientConnectionCountEventArgs)
            Try
                GetConnectionCount(Nothing)
            Catch
            End Try
        End Sub

        Private Function GetConnectionString(ByVal pacsConfig As System.Configuration.Configuration, ByVal machineConfig As System.Configuration.Configuration, ByVal dataAccessSectionName As String) As ConnectionStringSettings
            Dim settings As DataAccessSettings = Nothing
            Dim connectionStringSettings As ConnectionStringSettings = Nothing
            Try
                settings = TryCast(pacsConfig.GetSection(dataAccessSectionName), DataAccessSettings)
                If Not settings Is Nothing Then
                    Dim found As Boolean = False
                    Dim name As String = String.Empty
                    For Each connectionElement As ConnectionElement In settings.Connections
                        If connectionElement.ProductName = ProductName Then
                            name = connectionElement.ConnectionName
                            found = True
                            Exit For
                        End If
                    Next connectionElement

                    If found AndAlso (Not String.IsNullOrEmpty(name)) Then
                        Dim connectionStringsSection As ConnectionStringsSection = pacsConfig.ConnectionStrings
                        connectionStringSettings = connectionStringsSection.ConnectionStrings(name)
                    End If
                End If

            Catch e1 As Exception
                ' return null;
            End Try

            If connectionStringSettings Is Nothing Then
                connectionStringSettings = GetConnectionString(machineConfig, dataAccessSectionName)
            End If
            Return connectionStringSettings
        End Function

        Private Function GetConnectionString(ByVal machineConfig As System.Configuration.Configuration, ByVal dataAccessSectionName As String) As ConnectionStringSettings
            Dim settings As DataAccessSettings


            Try
                settings = TryCast(machineConfig.GetSection(dataAccessSectionName), DataAccessSettings)

                If Nothing Is settings Then
                    Return New ConnectionStringSettings()
                Else
                    Dim connection As ConnectionStringSettings


                    connection = machineConfig.ConnectionStrings.ConnectionStrings(settings.ConnectionName)

                    If Nothing Is connection Then
                        Return New ConnectionStringSettings()
                    Else
                        Return connection
                    End If
                End If
            Catch e1 As Exception
                Return New ConnectionStringSettings()
            End Try
        End Function
    End Class
End Namespace
