' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Data
Imports Leadtools.Dicom.Server.Admin
Imports Leadtools.Medical.Gateway.CFindAddin.DataTypes
Imports Leadtools.Dicom.AddIn.Common
Imports System.Net
Imports Leadtools.Dicom.AddIn.Configuration
Imports Leadtools.Medical.Gateway
Imports Leadtools.Medical.Storage.AddIns
Imports Leadtools.Medical.Storage.AddIns.Configuration
Imports Leadtools.Demos.StorageServer.DataTypes
Imports Leadtools.Medical.Winforms.Forwarder
Imports System.ServiceProcess
Imports System.Drawing
Imports System.IO
Imports Leadtools.Medical.Winforms
Imports Leadtools.Medical.Logging.Addins
Imports Leadtools.Dicom.AddIn
Imports Microsoft.VisualBasic
Imports Leadtools.Medical.Winforms.SecurityOptions
Imports Leadtools.DicomDemos

Namespace Leadtools.Demos.StorageServer.UI
    Partial Friend Class GatewaySettingsPresenter
#Region "Public"

#Region "Methods"

        Public Sub RunView(ByVal _view As GatewaySettingsView)
            __View = _view

            __GatewayServers = New List(Of GatewayServer)()

            If Not ServerState.Instance.ServerService Is Nothing Then
                Init(_view)
            Else
                _view.Enabled = False
            End If

            AddHandler ServerState.Instance.ServerServiceChanged, AddressOf Instance_ServerServiceChanged
        End Sub

#End Region

#Region "Properties"

        Public ReadOnly Property View() As GatewaySettingsView
            Get
                Return __View
            End Get
        End Property

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

#Region "Data Types Definition"

#End Region

#End Region

#Region "Private"

#Region "Methods"

        Private Sub CreateGatewayServersList()
            Dim serverSettings As AdvancedSettings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory)
            Dim gatewaysList As List(Of String) = serverSettings.GetAddInCustomData(Of List(Of String))(Me.[GetType]().Name, GetType(GatewayServer).Name)

            If Nothing Is gatewaysList Then
                gatewaysList = New List(Of String)()
            End If

            ServerState.Instance.GatewayServers = gatewaysList

            ServerState.Instance.ServiceAdmin.LoadServices(gatewaysList)

            For Each gatewayService As String In gatewaysList
                If ServerState.Instance.ServiceAdmin.Services.ContainsKey(gatewayService) Then
                    Dim gateway As DicomService = ServerState.Instance.ServiceAdmin.Services(gatewayService)

                    Dim gatewaySettings As AdvancedSettings = AdvancedSettings.Open(gateway.ServiceDirectory)

                    Dim server As GatewayServer = gatewaySettings.GetAddInCustomData(Of GatewayServer)(GetType(GatewaySession).Name, GetType(GatewayServer).Name)

                    If Not Nothing Is server Then
                        __GatewayServers.Add(server)
                    End If

                    AddHandler gateway.StatusChange, AddressOf gateway_StatusChange
                End If
            Next gatewayService
        End Sub

        Private Sub Init(ByVal _view As GatewaySettingsView)
            CreateGatewayServersList()
            ConfigureView(_view)
            RegisterEvents(_view)
        End Sub

        Private Sub RegisterEvents(ByVal _view As GatewaySettingsView)
            AddHandler _view.GatewaysItemsGridView.AddItem, AddressOf GatewaysItemsGridView_AddItem
            AddHandler _view.GatewaysItemsGridView.DeleteItem, AddressOf GatewaysItemsGridView_DeleteItem
            AddHandler _view.GatewaysItemsGridView.ModifyItem, AddressOf GatewaysItemsGridView_ModifyItem

            AddHandler _view.GatewaysItemsGridView.SelectedItemChanged, AddressOf GatewaysItemsGridView_SelectedItemChanged

            AddHandler _view.RemoteServersItemsGridView.AddItem, AddressOf RemoteServersItemsGridView_AddItem
            AddHandler _view.RemoteServersItemsGridView.DeleteItem, AddressOf RemoteServersItemsGridView_DeleteItem
            AddHandler _view.RemoteServersItemsGridView.ModifyItem, AddressOf RemoteServersItemsGridView_ModifyItem

            AddHandler _view.NumberOfTimesToUseSecondaryServerChanged, AddressOf view_NumberOfTimesToUseSecondaryServerChanged

            EventBroker.Instance.Subscribe(Of ServerSettingsAppliedEventArgs)(AddressOf ServerSettingsAppliedHandler)
        End Sub

        Private Sub UnregisterEvents(ByVal _view As GatewaySettingsView)
            RemoveHandler _view.GatewaysItemsGridView.AddItem, AddressOf GatewaysItemsGridView_AddItem
            RemoveHandler _view.GatewaysItemsGridView.DeleteItem, AddressOf GatewaysItemsGridView_DeleteItem
            RemoveHandler _view.GatewaysItemsGridView.ModifyItem, AddressOf GatewaysItemsGridView_ModifyItem

            RemoveHandler _view.RemoteServersItemsGridView.AddItem, AddressOf RemoteServersItemsGridView_AddItem
            RemoveHandler _view.RemoteServersItemsGridView.DeleteItem, AddressOf RemoteServersItemsGridView_DeleteItem
            RemoveHandler _view.RemoteServersItemsGridView.ModifyItem, AddressOf RemoteServersItemsGridView_ModifyItem

            AddHandler _view.NumberOfTimesToUseSecondaryServerChanged, AddressOf view_NumberOfTimesToUseSecondaryServerChanged

            EventBroker.Instance.Unsubscribe(Of ServerSettingsAppliedEventArgs)(AddressOf ServerSettingsAppliedHandler)
        End Sub

        Private Sub ConfigureView(ByVal _view As GatewaySettingsView)
            Dim gateways As Gateways = New Gateways()

            For Each gateway As GatewayServer In __GatewayServers
                CreateGatewayRow(gateways, gateway)
            Next gateway


            __GatewaySource = New BindingSource()
            __GatewaySource.DataSource = gateways
            __GatewaySource.DataMember = gateways.GatewayServer.TableName

            _view.GatewaysItemsGridView.DataSource = __GatewaySource

            FormatGatewayGridViewStyles(_view.GatewaysItemsGridView, gateways)
            AddServiceStateImageColumn(_view.GatewaysItemsGridView, gateways)

            __RemoteServersSource = New BindingSource()

            __RemoteServersSource.DataSource = __GatewaySource
            __RemoteServersSource.DataMember = gateways.Relations(0).RelationName

            _view.RemoteServersItemsGridView.DataSource = __RemoteServersSource

            FormatRemoteServersGridViewStyles(_view.RemoteServersItemsGridView, gateways)

            If (__GatewayServers.Count > 0) Then
                _view.NumberOfTimesToUseSecondaryServer = Math.Min(Math.Max(__GatewayServers(0).NumberOfTimesToUseSecondaryServer, 1), 100)
            Else
                _view.NumberOfTimesToUseSecondaryServer = 1
            End If

            If __ServerController Is Nothing Then
                __ServerController = New GatewayServerControlPresenter()

                __ServerController.RunView(__View.GatewaysItemsGridView, __GatewaySource)
            Else
                __ServerController.Reconfigure(__GatewaySource)
            End If

            If __RemoteController Is Nothing Then
                __RemoteController = New RemoteServerSortPresenter()

                __RemoteController.RunView(__View.RemoteServersItemsGridView.MainToolStrip, __GatewaySource, __RemoteServersSource)
            Else
                __RemoteController.Reconfigure(__GatewaySource, __RemoteServersSource)
            End If
        End Sub

        Private Sub AddServiceStateImageColumn(ByVal itemsGridView As ItemsGridView, ByVal source As Gateways)
            If (Not itemsGridView.ItemsDataGridView.Columns.Contains(MyConstants.ServiceStateColumn)) Then
                Dim imageColumn As DataGridViewImageColumn = New DataGridViewImageColumn()

                imageColumn.Name = MyConstants.ServiceStateColumn

                imageColumn.Width = 16
                imageColumn.HeaderText = "State"
                itemsGridView.ItemsDataGridView.Columns.Add(imageColumn)
                imageColumn.DefaultCellStyle.NullValue = My.Resources.Stopped
                imageColumn.DisplayIndex = 0
            End If

            AddHandler itemsGridView.ItemsDataGridView.CellFormatting, AddressOf ItemsDataGridView_CellFormatting
        End Sub

        Private Sub ItemsDataGridView_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs)
            Try
                Dim _view As DataGridView = TryCast(sender, DataGridView)

                If Not _view Is Nothing AndAlso _view.Columns(e.ColumnIndex).Name = MyConstants.ServiceStateColumn Then
                    Dim row As DataGridViewRow = _view.Rows(e.RowIndex)
                    Dim source As Gateways = TryCast(__GatewaySource.DataSource, Gateways)
                    Dim server As GatewayServer = CType(row.Cells(source.GatewayServer.GatewayServerColumn.ColumnName).Value, GatewayServer)

                    If Not server Is Nothing Then
                        If ServerState.Instance.ServiceAdmin.Services.ContainsKey(server.ServiceName) Then
                            Dim service As DicomService = ServerState.Instance.ServiceAdmin.Services(server.ServiceName)

                            UpdateGatewayServiceStatus(service, e)
                        End If
                    End If
                End If
            Catch e1 As Exception
            End Try
        End Sub

        Private Sub UpdateGatewayServiceStatus(ByVal service As DicomService, ByVal gatewayRow As DataGridViewRow)
            If service.Status = ServiceControllerStatus.Stopped Then
                gatewayRow.Cells(MyConstants.ServiceStateColumn).Value = My.Resources.Stopped
            Else
                gatewayRow.Cells(MyConstants.ServiceStateColumn).Value = My.Resources.Running
            End If
        End Sub

        Private Sub UpdateGatewayServiceStatus(ByVal service As DicomService, ByVal e As DataGridViewCellFormattingEventArgs)
            If service.Status = ServiceControllerStatus.Stopped Then
                e.Value = My.Resources.Stopped
            Else
                e.Value = My.Resources.Running
            End If
        End Sub

        Private Sub FormatGatewayGridViewStyles(ByVal itemsGridView As ItemsGridView, ByVal source As Gateways)
            itemsGridView.ItemsDataGridView.Columns(source.GatewayServer.AETitleColumn.ColumnName).HeaderText = "AE Title"
            itemsGridView.ItemsDataGridView.Columns(source.GatewayServer.IpAddressColumn.ColumnName).HeaderText = "IP Address"
            itemsGridView.ItemsDataGridView.Columns(source.GatewayServer.PortColumn.ColumnName).HeaderText = "Port"
            itemsGridView.ItemsDataGridView.Columns(source.GatewayServer.SecureColumn.ColumnName).HeaderText = "Secure (TLS)"
            itemsGridView.ItemsDataGridView.Columns(source.GatewayServer.GatewayServerColumn.ColumnName).Visible = False
        End Sub

        Private Sub FormatRemoteServersGridViewStyles(ByVal itemsGridView As ItemsGridView, ByVal source As Gateways)
            itemsGridView.ItemsDataGridView.Columns(source.RemoteServer.AETitleColumn.ColumnName).HeaderText = "AE Title"
            itemsGridView.ItemsDataGridView.Columns(source.RemoteServer.IpAddressColumn.ColumnName).HeaderText = "IP Address"
            itemsGridView.ItemsDataGridView.Columns(source.RemoteServer.PortColumn.ColumnName).HeaderText = "Port"
            itemsGridView.ItemsDataGridView.Columns(source.RemoteServer.SecurePortColumn.ColumnName).HeaderText = "Secure Port"
            itemsGridView.ItemsDataGridView.Columns(source.RemoteServer.UseSecurePortColumn.ColumnName).HeaderText = "Secure (TLS)"

            itemsGridView.ItemsDataGridView.Columns(source.RemoteServer.GatewayServerAEColumn.ColumnName).Visible = False
            itemsGridView.ItemsDataGridView.Columns(source.RemoteServer.RemoteServerSettingsColumn.ColumnName).Visible = False
            itemsGridView.ItemsDataGridView.Columns(source.RemoteServer.SecurePortColumn.ColumnName).Visible = False
        End Sub

        Private Function CreateGatewayRow(ByVal gateways As Gateways, ByVal gateway As GatewayServer) As Gateways.GatewayServerRow
            Dim r1 As Gateways.GatewayServerRow = gateways.GatewayServer.AddGatewayServerRow(gateway.Server.AETitle, gateway.Server.Address, If(gateway.Server.Port = 0, gateway.Server.SecurePort, gateway.Server.Port), gateway.Server.SecurePort > 0, gateway)

            For Each remoteServer As AeInfo In gateway.RemoteServers
                AddGatewayRemoteServerRow(gateways, r1, remoteServer)
            Next remoteServer

            Return r1
        End Function

        Private Shared Sub AddGatewayRemoteServerRow(ByVal gateways As Gateways, ByVal r1 As Gateways.GatewayServerRow, ByVal remoteServer As AeInfo)
            gateways.RemoteServer.AddRemoteServerRow(remoteServer.AETitle, remoteServer.Address, If(remoteServer.Port = 0, remoteServer.SecurePort, remoteServer.Port), remoteServer.SecurePort, r1, remoteServer, remoteServer.SecurePort > 0)
        End Sub

        Private Function GetIpAddresses() As String()
            If Nothing Is __IpAddresses Then
                Dim addresses As IPAddress() = Dns.GetHostAddresses(Dns.GetHostName())
                Dim addressesStringList As List(Of String) = New List(Of String)()


                For Each address As IPAddress In addresses
                    addressesStringList.Add(address.ToString())
                Next address

                __IpAddresses = addressesStringList.ToArray()
            End If

            Return __IpAddresses
        End Function

        Private Shared Sub UpdateGatewaySettings(ByVal settings As ServerSettings)
            settings.ImplementationClass = ServerState.Instance.ServerService.Settings.ImplementationClass
            settings.ImplementationVersionName = ServerState.Instance.ServerService.Settings.ImplementationVersionName

            settings.AddInTimeout = ServerState.Instance.ServerService.Settings.AddInTimeout
            settings.AdministrativePipes = ServerState.Instance.ServerService.Settings.AdministrativePipes
            settings.AllowAnonymous = ServerState.Instance.ServerService.Settings.AllowAnonymous

            settings.ClientTimeout = ServerState.Instance.ServerService.Settings.ClientTimeout

            settings.MaxClients = ServerState.Instance.ServerService.Settings.MaxClients
            settings.MaxPduLength = ServerState.Instance.ServerService.Settings.MaxPduLength
            settings.NoDelay = ServerState.Instance.ServerService.Settings.NoDelay
            settings.ReceiveBufferSize = ServerState.Instance.ServerService.Settings.ReceiveBufferSize
            settings.ReconnectTimeout = ServerState.Instance.ServerService.Settings.ReconnectTimeout
            settings.SendBufferSize = ServerState.Instance.ServerService.Settings.SendBufferSize
            settings.StartMode = ServerState.Instance.ServerService.Settings.StartMode
            settings.TemporaryDirectory = ServerState.Instance.ServerService.Settings.TemporaryDirectory
            settings.RelationalQueries = ServerState.Instance.ServerService.Settings.RelationalQueries
        End Sub

        Private Sub InstallGateway(ByVal settings As ServerSettings)
            Dim gatewayService As DicomService
            Dim gatewayServer As GatewayServer = Nothing
            Dim gatewayRow As Gateways.GatewayServerRow = Nothing
            Dim gatewayAe As AeInfo
            Dim gateways As Gateways = Nothing


            '
            ' Set License File to the server license file
            '
            settings.LicenseFile = ServerState.Instance.ServerService.Settings.LicenseFile
            gatewayService = ServerState.Instance.ServiceAdmin.InstallService(settings)

            Try
                gatewayServer = New GatewayServer()
                gatewayAe = New AeInfo()
                gateways = CType(__GatewaySource.DataSource, Gateways)


                gatewayAe.AETitle = settings.AETitle
                gatewayAe.Address = settings.IpAddress
                If settings.Secure Then
                    gatewayAe.Port = 0
                Else
                    gatewayAe.Port = settings.Port
                End If
                If settings.Secure Then
                    gatewayAe.SecurePort = settings.Port
                Else
                    gatewayAe.SecurePort = 0
                End If

                gatewayServer.Server = gatewayAe
                gatewayServer.ServiceName = gatewayService.ServiceName
                gatewayServer.NumberOfTimesToUseSecondaryServer = View.NumberOfTimesToUseSecondaryServer

                gatewayRow = CreateGatewayRow(gateways, gatewayServer)

                __GatewayServers.Add(gatewayServer)

                ServerState.Instance.GatewayServers.Add(gatewayServer.ServiceName)

                UpdateGatewayServersInMainServerSettings()

                Dim gatewaySettings As AdvancedSettings = AdvancedSettings.Open(gatewayService.ServiceDirectory)

                gatewaySettings.SetAddInCustomData(Of GatewayServer)(GetType(GatewaySession).Name, GetType(GatewayServer).Name, gatewayServer)
                gatewaySettings.SetConfigAssemblies("Leadtools.Medical.Logging.AddIn.dll")

                InstallAddins(gatewayService)

                IgnoreStroageFindMoveAddins(gatewaySettings)

                SetStorageAddInConfig(gatewayService.ServiceDirectory)
                SetLoggingAddInConfig(gatewayService.ServiceDirectory)
                SetForwardAddinConfig(gatewaySettings)
                SetSecurityAddinConfig(gatewaySettings)

                gatewaySettings.Save()

                GlobalPacsUpdater.ModifyGlobalPacsConfiguration(gatewayService.ServiceName, gatewayService.ServiceName, GlobalPacsUpdater.ModifyConfigurationType.Add)

                For Each serverRow As DataGridViewRow In __View.GatewaysItemsGridView.ItemsDataGridView.Rows
                    If serverRow.Cells(gateways.GatewayServer.GatewayServerColumn.ColumnName).Value Is gatewayServer Then
                        UpdateGatewayServiceStatus(gatewayService, serverRow)

                        Exit For
                    End If
                Next serverRow

                AddHandler gatewayService.StatusChange, AddressOf gateway_StatusChange
            Catch e1 As Exception
                If Not Nothing Is gateways AndAlso Not Nothing Is gatewayRow AndAlso gatewayRow.Table Is gateways.GatewayServer Then
                    gateways.GatewayServer.Rows.Remove(gatewayRow)
                End If

                If Not Nothing Is gatewayServer AndAlso __GatewayServers.Contains(gatewayServer) Then
                    __GatewayServers.Remove(gatewayServer)
                End If

                If ServerState.Instance.GatewayServers.Contains(gatewayServer.ServiceName) Then
                    ServerState.Instance.GatewayServers.Add(gatewayServer.ServiceName)
                End If

                GlobalPacsUpdater.ModifyGlobalPacsConfiguration(gatewayService.ServiceName, gatewayService.ServiceName, GlobalPacsUpdater.ModifyConfigurationType.Remove)

                If Not Nothing Is gatewayService Then
                    ServerState.Instance.ServiceAdmin.UnInstallService(gatewayService)
                End If

                UpdateGatewayServersInMainServerSettings()

                Throw
            End Try
        End Sub

        Private Sub UpdateGatewayServersInMainServerSettings()
            If Not Nothing Is ServerState.Instance.ServerService Then
                Dim serverSettings As AdvancedSettings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory)
                serverSettings.SetAddInCustomData(Of List(Of String))(Me.[GetType]().Name, GetType(GatewayServer).Name, ServerState.Instance.GatewayServers)
                serverSettings.Save()
            End If
        End Sub

        Private Sub SetStorageAddInConfig(ByVal gatewayServiceDirectory As String)
            Dim serverStoreConfigManger As StorageModuleConfigurationManager = ServiceLocator.Retrieve(Of StorageModuleConfigurationManager)()
            Using gatewayStoreConfigManger As StorageModuleConfigurationManager = New StorageModuleConfigurationManager(False)
                gatewayStoreConfigManger.Load(gatewayServiceDirectory)

                If gatewayStoreConfigManger.IsLoaded AndAlso serverStoreConfigManger.IsLoaded Then
                    Dim storageaddinSettings As StorageAddInsConfiguration = serverStoreConfigManger.GetStorageAddInsSettings()

                    gatewayStoreConfigManger.SetStorageAddinsSettings(storageaddinSettings)
                End If
            End Using
        End Sub

        Private Sub SetLoggingAddInConfig(ByVal gatewayServiceDirectory As String)
            Dim serverLoggingConfigManger As LoggingModuleConfigurationManager = ServiceLocator.Retrieve(Of LoggingModuleConfigurationManager)()

            Using gatewayLoggingConfigManger As LoggingModuleConfigurationManager = New LoggingModuleConfigurationManager(False)
                gatewayLoggingConfigManger.Load(gatewayServiceDirectory)

                If gatewayLoggingConfigManger.IsLoaded AndAlso serverLoggingConfigManger.IsLoaded Then
                    Dim loggingState As LoggingState = serverLoggingConfigManger.GetLoggingState()

                    gatewayLoggingConfigManger.SetLoggingState(loggingState)
                End If
            End Using
        End Sub

        Private Sub SetForwardAddinConfig(ByVal gatewaySetting As AdvancedSettings)
            Dim serviceSettings As AdvancedSettings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory)

            Dim options As ForwardOptions = serviceSettings.GetAddInCustomData(Of ForwardOptions)(ForwardManagerPresenter._addinName, "ForwardOptions")

            gatewaySetting.SetAddInCustomData(Of ForwardOptions)(ForwardManagerPresenter._addinName, "ForwardOptions", options)
        End Sub

        Private Sub SetSecurityAddinConfig(ByVal gatewaySetting As AdvancedSettings)
            Dim serviceSettings As AdvancedSettings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory)

            Dim options As DicomSecurityOptions = serviceSettings.GetAddInCustomData(Of DicomSecurityOptions)(SecurityOptionsPresenter.AddinName, SecurityOptionsPresenter.CustomDataName)

            gatewaySetting.SetAddInCustomData(Of DicomSecurityOptions)(SecurityOptionsPresenter.AddinName, SecurityOptionsPresenter.CustomDataName, options)
        End Sub

        Private Sub InstallAddins(ByVal gatewayService As DicomService)
            Dim addInsDirectory As String
            Dim configDirectory As String

            addInsDirectory = Path.Combine(gatewayService.ServiceDirectory, "AddIns")
            configDirectory = Path.Combine(gatewayService.ServiceDirectory, "Configuration")

            Shell.InstallAddIns(GetAddIns(), addInsDirectory)
            Shell.InstallAddIns(GetConfigurationAddIns(), configDirectory)
        End Sub

        Private Sub IgnoreStroageFindMoveAddins(ByVal serviceSettings As AdvancedSettings)
            serviceSettings.SetIgnoreType("CFind", GetType(Leadtools.Medical.Storage.AddIns.FindAddIn))
            serviceSettings.SetIgnoreType("CMove", GetType(Leadtools.Medical.Storage.AddIns.MoveAddIn))
        End Sub

        Friend Shared Sub SetGatwayServerAddInSettings(ByVal server As GatewayServer)
            If ServerState.Instance.ServiceAdmin.Services.ContainsKey(server.ServiceName) Then
                Dim gatewayService As DicomService = ServerState.Instance.ServiceAdmin.Services(server.ServiceName)

                Dim gatewaySettings As AdvancedSettings = AdvancedSettings.Open(gatewayService.ServiceDirectory)

                gatewaySettings.SetAddInCustomData(Of GatewayServer)(GetType(GatewaySession).Name, GetType(GatewayServer).Name, server)

                gatewaySettings.Save()
            End If
        End Sub

#End Region

#Region "Properties"

        Private _myServerController As GatewayServerControlPresenter
        Private Property __ServerController() As GatewayServerControlPresenter
            Get
                Return _myServerController
            End Get
            Set(ByVal value As GatewayServerControlPresenter)
                _myServerController = value
            End Set
        End Property

        Private _myremoteController As RemoteServerSortPresenter
        Private Property __RemoteController() As RemoteServerSortPresenter
            Get
                Return _myremoteController
            End Get
            Set(ByVal value As RemoteServerSortPresenter)
                _myremoteController = value
            End Set
        End Property

#End Region

#Region "Events"

        Private Sub Instance_ServerServiceChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try
                If Nothing Is ServerState.Instance.ServerService Then
                    UnregisterEvents(__View)

                    __View.Enabled = False

                    If __GatewayServers.Count > 0 Then
                        DeleteAllGateways()
                    End If
                Else
                    __View.Enabled = True

                    If Nothing Is ServerState.Instance.GatewayServers OrElse ServerState.Instance.GatewayServers.Count > 0 Then
                        CreateGatewayServersList()

                        ConfigureView(__View)
                    End If

                    RegisterEvents(__View)
                End If
            Catch exception As Exception
                __View.ShowErrorMessage(exception.Message)
            End Try
        End Sub

        Private Sub ServerSettingsAppliedHandler(ByVal sender As Object, ByVal e As ServerSettingsAppliedEventArgs)
            Try
                If Not ServerState.Instance.ServiceAdmin Is Nothing AndAlso Not ServerState.Instance.ServerService Is Nothing Then
                    For Each server As GatewayServer In __GatewayServers
                        Dim gatewayService As DicomService


                        If ServerState.Instance.ServiceAdmin.Services.ContainsKey(server.ServiceName) Then
                            Dim gatewaySettings As AdvancedSettings


                            gatewayService = ServerState.Instance.ServiceAdmin.Services(server.ServiceName)

                            gatewaySettings = AdvancedSettings.Open(gatewayService.ServiceDirectory)

                            SetStorageAddInConfig(gatewayService.ServiceDirectory)
                            SetLoggingAddInConfig(gatewayService.ServiceDirectory)
                            SetForwardAddinConfig(gatewaySettings)
                            SetSecurityAddinConfig(gatewaySettings)

                            gatewaySettings.Save()

                            UpdateGatewaySettings(gatewayService.Settings)

                            gatewayService.Settings = gatewayService.Settings
                        End If
                    Next server
                End If
            Catch exception As Exception
                __View.ShowErrorMessage(exception.Message)
            End Try
        End Sub

        Private Sub GatewaysItemsGridView_AddItem(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Using aeInfoDlg As AeInfoDetails = New AeInfoDetails()
                    aeInfoDlg.DialogTitle = "Create Gateway Server"
                    aeInfoDlg.ConfirmText = "Create"
                    aeInfoDlg.Port = 104

                    aeInfoDlg.SetIpAddressList(GetIpAddresses())

                    If aeInfoDlg.ShowDialog(__View) = DialogResult.OK Then
                        Dim settings As ServerSettings = New ServerSettings()

                        Dim existServer As Object = __GatewayServers.Where(Function(n) n.Server.AETitle = aeInfoDlg.AETitle OrElse n.ServiceName = aeInfoDlg.AETitle).FirstOrDefault()

                        If Not Nothing Is existServer Then
                            __View.ShowErrorMessage("AE Title already exists or matches another server name.")
                        Else
                            settings.AETitle = aeInfoDlg.AETitle
                            settings.IpAddress = aeInfoDlg.Address
                            settings.Port = aeInfoDlg.Port
                            settings.Secure = aeInfoDlg.Secure

                            settings.AllowMultipleConnections = True
#If Not LEADTOOLS_V19_OR_LATER Then
                     settings.EnableLog = True 'login configuration Addin will handle the logging state
#End If

                            UpdateGatewaySettings(settings)

                            InstallGateway(settings)
                        End If
                    End If
                End Using
            Catch exception As Exception
                __View.ShowErrorMessage("Failed to create gateway." + Constants.vbLf + exception.Message)
            End Try
        End Sub

        Private Sub GatewaysItemsGridView_DeleteItem(ByVal sender As Object, ByVal e As EventArgs)
            Try
                If Nothing IsNot __GatewaySource.Current Then
                    Dim selectedRow As DataRowView = CType(__GatewaySource.Current, DataRowView)
                    Dim gatewayRow As Gateways.GatewayServerRow = CType(selectedRow.Row, Gateways.GatewayServerRow)
                    Dim gatewayServer As GatewayServer = CType(gatewayRow.GatewayServer, GatewayServer)

                    Dim confirm As Boolean = __View.ShowConfirmMessage(String.Format("Are you sure you want to remove {0}?", gatewayServer.ServiceName))
                    If confirm Then
                        ServerState.Instance.ServiceAdmin.UnInstallService(ServerState.Instance.ServiceAdmin.Services(gatewayServer.ServiceName))

                        GlobalPacsUpdater.ModifyGlobalPacsConfiguration(DicomDemoSettingsManager.ProductNameGateway, gatewayServer.ServiceName, GlobalPacsUpdater.ModifyConfigurationType.Remove)

                        selectedRow.Row.Delete()

                        __GatewayServers.Remove(gatewayServer)

                        ServerState.Instance.GatewayServers.Remove(gatewayServer.ServiceName)

                        UpdateGatewayServersInMainServerSettings()
                    Else
                        __View.ShowMessage(String.Format("{0} has not been removed.", gatewayServer.ServiceName))
                    End If
                End If
            Catch exception As Exception
                __View.ShowErrorMessage("Failed to delete gateway." & Constants.vbLf + exception.Message)
            End Try
        End Sub

        Private Sub DeleteAllGateways()
            For Each server As GatewayServer In __GatewayServers
                ServerState.Instance.ServiceAdmin.UnInstallService(ServerState.Instance.ServiceAdmin.Services(server.ServiceName))

                ServerState.Instance.GatewayServers.Remove(server.ServiceName)
            Next server

            __GatewayServers.Clear()

            CType(__GatewaySource.DataSource, Gateways).RemoteServer.Clear()
            CType(__GatewaySource.DataSource, Gateways).GatewayServer.Clear()
        End Sub

        Private Sub GatewaysItemsGridView_ModifyItem(ByVal sender As Object, ByVal e As EventArgs)
            Try
                If Not Nothing Is __GatewaySource.Current Then
                    Dim selectedRow As DataRowView = CType(__GatewaySource.Current, DataRowView)
                    Dim gatewayRow As Gateways.GatewayServerRow = CType(selectedRow.Row, Gateways.GatewayServerRow)
                    Dim gatewayServer As GatewayServer = CType(gatewayRow.GatewayServer, GatewayServer)

                    Dim gatewayService As DicomService

                    If (Not ServerState.Instance.ServiceAdmin.Services.ContainsKey(gatewayServer.ServiceName)) Then
                        Throw New InvalidOperationException("Gateway service not available.")
                    Else
                        gatewayService = ServerState.Instance.ServiceAdmin.Services(gatewayServer.ServiceName)
                    End If

                    Using aeInfoDlg As AeInfoDetails = New AeInfoDetails()
                        aeInfoDlg.DialogTitle = "Modify Gateway Server"
                        aeInfoDlg.ConfirmText = "Modify"

                        aeInfoDlg.SetIpAddressList(GetIpAddresses())

                        aeInfoDlg.AETitle = gatewayServer.Server.AETitle
                        aeInfoDlg.Address = gatewayServer.Server.Address
                        If gatewayServer.Server.SecurePort = 0 Then
                            aeInfoDlg.Port = gatewayServer.Server.Port
                        Else
                            aeInfoDlg.Port = gatewayServer.Server.SecurePort
                        End If
                        aeInfoDlg.Secure = gatewayServer.Server.SecurePort <> 0

                        If aeInfoDlg.ShowDialog(__View) = DialogResult.OK Then
                            gatewayServer.Server.AETitle = aeInfoDlg.AETitle
                            gatewayServer.Server.Address = aeInfoDlg.Address
                            gatewayServer.Server.Port = If(aeInfoDlg.Secure, 0, aeInfoDlg.Port)
                            gatewayServer.Server.SecurePort = If(aeInfoDlg.Secure, aeInfoDlg.Port, 0)
                            gatewayServer.Server.ClientPortUsage = If((aeInfoDlg.Secure), Dicom.ClientPortUsageType.Secure, Dicom.ClientPortUsageType.Unsecure)
                            gatewayServer.Server.LastAccessDate = DateTime.Now

                            SetGatwayServerAddInSettings(gatewayServer)

                            gatewayRow.AETitle = aeInfoDlg.AETitle
                            gatewayRow.IpAddress = aeInfoDlg.Address
                            gatewayRow.Port = aeInfoDlg.Port
                            gatewayRow.Secure = aeInfoDlg.Secure

                            gatewayService.Settings.AETitle = aeInfoDlg.AETitle
                            gatewayService.Settings.IpAddress = aeInfoDlg.Address
                            gatewayService.Settings.Port = aeInfoDlg.Port
                            gatewayService.Settings.Secure = aeInfoDlg.Secure

                            gatewayService.Settings = gatewayService.Settings
                        End If
                    End Using
                End If
            Catch exception As Exception
                __View.ShowErrorMessage("Failed to modify gateway settings." & Constants.vbLf + exception.Message)
            End Try
        End Sub

        Private Sub RemoteServersItemsGridView_ModifyItem(ByVal sender As Object, ByVal e As EventArgs)
            Try
                If Nothing IsNot __RemoteServersSource.Current Then
                    Using aeInfoDlg As New AeInfoDetails()
                        Dim currentRowView As DataRowView = CType(__RemoteServersSource.Current, DataRowView)
                        Dim remoteServerRow As Gateways.RemoteServerRow = CType(currentRowView.Row, Gateways.RemoteServerRow)
                        Dim remoteAeInfo As AeInfo = CType(remoteServerRow.RemoteServerSettings, AeInfo)

                        aeInfoDlg.DialogTitle = "Modify Remote Server"
                        aeInfoDlg.ConfirmText = "Modify"
                        aeInfoDlg.CanEnterIp = True

                        aeInfoDlg.AETitle = remoteAeInfo.AETitle
                        aeInfoDlg.Port = If(remoteAeInfo.Port > 0, remoteAeInfo.Port, remoteAeInfo.SecurePort)
                        aeInfoDlg.Secure = (remoteAeInfo.ClientPortUsage = Dicom.ClientPortUsageType.Secure)
                        aeInfoDlg.Address = remoteAeInfo.Address

                        If aeInfoDlg.ShowDialog(__View) = DialogResult.OK Then
                            remoteServerRow.AETitle = aeInfoDlg.AETitle
                            remoteServerRow.IpAddress = aeInfoDlg.Address

                            remoteServerRow.Port = aeInfoDlg.Port
                            remoteServerRow.SecurePort = 0 ' ( !aeInfoDlg.Secure ) ? 0 : aeInfoDlg.Port ;
                            remoteServerRow.UseSecurePort = aeInfoDlg.Secure

                            remoteAeInfo.AETitle = aeInfoDlg.AETitle
                            remoteAeInfo.Address = aeInfoDlg.Address
                            remoteAeInfo.Port = If(aeInfoDlg.Secure, 0, aeInfoDlg.Port)
                            remoteAeInfo.SecurePort = If(aeInfoDlg.Secure, aeInfoDlg.Port, 0)
                            remoteAeInfo.ClientPortUsage = If((aeInfoDlg.Secure), Dicom.ClientPortUsageType.Secure, Dicom.ClientPortUsageType.Unsecure)
                            remoteAeInfo.LastAccessDate = DateTime.Now

                            If Nothing IsNot __GatewaySource.Current Then
                                Dim server As GatewayServer = CType((CType((CType(__GatewaySource.Current, DataRowView)).Row, Gateways.GatewayServerRow)).GatewayServer, GatewayServer)


                                SetGatwayServerAddInSettings(server)
                            End If
                        End If
                    End Using
                End If
            Catch exception As Exception
                __View.ShowErrorMessage("Failed to modify remote server." & Constants.vbLf + exception.Message)
            End Try
        End Sub

        Private Sub RemoteServersItemsGridView_DeleteItem(ByVal sender As Object, ByVal e As EventArgs)
            Try
                If Nothing IsNot __RemoteServersSource.Current AndAlso Nothing IsNot __GatewaySource.Current Then
                    Dim selectedGatewayRow As DataRowView = CType(__GatewaySource.Current, DataRowView)
                    Dim gatewayRow As Gateways.GatewayServerRow = CType(selectedGatewayRow.Row, Gateways.GatewayServerRow)
                    Dim gatewayServer As GatewayServer = CType(gatewayRow.GatewayServer, GatewayServer)


                    Dim currentRowView As DataRowView = CType(__RemoteServersSource.Current, DataRowView)
                    Dim remoteServerRow As Gateways.RemoteServerRow = CType(currentRowView.Row, Gateways.RemoteServerRow)
                    Dim remoteAeInfo As AeInfo = CType(remoteServerRow.RemoteServerSettings, AeInfo)

                    Dim confirm As Boolean = __View.ShowConfirmMessage(String.Format("Are you sure you want to remove {0}?", remoteAeInfo.AETitle))
                    If confirm Then
                        gatewayServer.RemoteServers.Remove(remoteAeInfo)

                        remoteServerRow.Delete()

                        SetGatwayServerAddInSettings(gatewayServer)
                    Else
                        __View.ShowMessage(String.Format("{0} has not been removed.", remoteAeInfo.AETitle))
                    End If


                End If
            Catch exception As Exception
                __View.ShowErrorMessage("Failed to delete remote server." & Constants.vbLf + exception.Message)
            End Try
        End Sub

        Private Sub RemoteServersItemsGridView_AddItem(ByVal sender As Object, ByVal e As EventArgs)
            Try
                If Not Nothing Is __GatewaySource.Current Then
                    Using aeInfoDlg As AeInfoDetails = New AeInfoDetails()
                        aeInfoDlg.DialogTitle = "Add Remote Server"
                        aeInfoDlg.ConfirmText = "Add"
                        aeInfoDlg.Port = 105
                        aeInfoDlg.CanEnterIp = True

                        If aeInfoDlg.ShowDialog(__View) = DialogResult.OK Then
                            Dim remoteServer As AeInfo = New AeInfo()
                            Dim currentParent As DataRowView = CType(__GatewaySource.Current, DataRowView)
                            Dim parentGateway As Gateways.GatewayServerRow = CType(currentParent.Row, Gateways.GatewayServerRow)


                            remoteServer.AETitle = aeInfoDlg.AETitle
                            remoteServer.Address = aeInfoDlg.Address
                            If (aeInfoDlg.Secure) Then
                                remoteServer.Port = 0
                            Else
                                remoteServer.Port = aeInfoDlg.Port
                            End If
                            If ((Not aeInfoDlg.Secure)) Then
                                remoteServer.SecurePort = 0
                            Else
                                remoteServer.SecurePort = aeInfoDlg.Port
                            End If

                            AddGatewayRemoteServerRow(CType(__GatewaySource.DataSource, Gateways), parentGateway, remoteServer)

                            Dim server As GatewayServer = CType(parentGateway.GatewayServer, GatewayServer)

                            server.RemoteServers.Add(remoteServer)

                            SetGatwayServerAddInSettings(server)
                        End If
                    End Using
                End If
            Catch exception As Exception
                __View.ShowErrorMessage("Failed to add remote server." & Constants.vbLf + exception.Message)
            End Try
        End Sub

        Private Sub view_NumberOfTimesToUseSecondaryServerChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try
                For Each gateway As GatewayServer In __GatewayServers
                    gateway.NumberOfTimesToUseSecondaryServer = __View.NumberOfTimesToUseSecondaryServer

                    SetGatwayServerAddInSettings(gateway)
                Next gateway
            Catch exception As Exception
                __View.ShowErrorMessage(exception.Message)
            End Try
        End Sub

        Sub gateway_StatusChange(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim service As DicomService = CType(sender, DicomService)
                Dim gatewayServer As Object = __GatewayServers.Where(Function(n) n.ServiceName = service.ServiceName).FirstOrDefault()

                If Not Nothing Is gatewayServer Then
                    For Each serverRow As DataGridViewRow In __View.GatewaysItemsGridView.ItemsDataGridView.Rows
                        If serverRow.Cells("GatewayServer").Value Is gatewayServer Then
                            UpdateGatewayServiceStatus(service, serverRow)

                            Exit For
                        End If
                    Next serverRow
                End If

                If Not Nothing Is __ServerController Then
                    __ServerController.UpdateUI()
                End If
            Catch
            End Try
        End Sub

        Sub GatewaysItemsGridView_SelectedItemChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try
                __View.RemoteServersItemsGridView.CanAdd = Not __View.GatewaysItemsGridView.SelectedRow Is Nothing

                If __View.GatewaysItemsGridView.SelectedRow Is Nothing Then
                    __RemoteServersSource.Filter = "GatewayServerAE = ''"
                Else
                    __RemoteServersSource.Filter = String.Empty
                End If
            Catch
            End Try
        End Sub


#End Region

#Region "Data Members"

        Private _myGatewaySource As BindingSource
        Private Property __GatewaySource() As BindingSource
            Get
                Return _myGatewaySource
            End Get
            Set(ByVal value As BindingSource)
                _myGatewaySource = value
            End Set
        End Property

        Private _myRemoteServersSource As BindingSource
        Private Property __RemoteServersSource() As BindingSource
            Get
                Return _myRemoteServersSource
            End Get
            Set(ByVal value As BindingSource)
                _myRemoteServersSource = value
            End Set
        End Property

        Private _myview As GatewaySettingsView
        Private Property __View() As GatewaySettingsView
            Get
                Return _myview
            End Get
            Set(ByVal value As GatewaySettingsView)
                _myview = value
            End Set
        End Property

        Private _myIpAddresses As String()
        Private Property __IpAddresses() As String()
            Get
                Return _myIpAddresses
            End Get
            Set(ByVal value As String())
                _myIpAddresses = value
            End Set
        End Property

        Public _myGatewayServers As List(Of GatewayServer)
        Public Property __GatewayServers() As List(Of GatewayServer)
            Get
                Return _myGatewayServers
            End Get
            Set(ByVal value As List(Of GatewayServer))
                _myGatewayServers = value
            End Set
        End Property

#End Region

#Region "Data Types Definition"

        Private MustInherit Class MyConstants
            Public Const ServiceStateColumn As String = "ServiceState"
        End Class

#End Region

#End Region

#Region "internal"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

#End Region
#End Region

    End Class
End Namespace
