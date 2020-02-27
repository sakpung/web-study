' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Dicom.AddIn.Common
Imports Leadtools.Demos.StorageServer.DataTypes
Imports Leadtools.Dicom.AddIn.Interfaces
Imports Leadtools.Dicom.AddIn.Configuration
Imports Leadtools.Medical.Gateway.CFindAddin.DataTypes
Imports Leadtools.Dicom.Server.Admin
Imports System.IO
Imports Leadtools.Dicom.AddIn
Imports Leadtools.Medical.Winforms

Namespace Leadtools.Demos.StorageServer.UI
   Public Class ServerOptionsPresenter
#Region "Public"

#Region "Methods"

      Public Sub RunView(ByVal _view As ServerOptionsView)
         AddHandler ServerState.Instance.ServerServiceChanged, AddressOf OnConfigureView
         AddHandler ServerState.Instance.ServiceAdminChanged, AddressOf OnConfigureView
         AddHandler ServerState.Instance.IsRemoteServerChanged, AddressOf OnConfigureView
         AddHandler ServerState.Instance.LicenseChanged, AddressOf OnLicenseChanged

         EventBroker.Instance.Subscribe(Of ApplyServerSettingsEventArgs)(AddressOf OnUpdateServerSettings)
         EventBroker.Instance.Subscribe(Of CancelServerSettingsEventArgs)(AddressOf OnCancelServerSettings)

         View = _view

         ConfigureView()

         AddHandler View.SettingsChanged, AddressOf View_SettingsChanged
      End Sub

      Private Sub OnLicenseChanged(ByVal sender As Object, ByVal e As EventArgs)
         ConfigureMax()
         SetGateWayLicense()
      End Sub

      Private Sub SetGateWayLicense()
         If Nothing Is ServerState.Instance.ServerService Then
            Return
         End If

         Dim serverSettings As AdvancedSettings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory)
         Dim gatewaysList As List(Of String) = serverSettings.GetAddInCustomData(Of List(Of String))(GetType(GatewaySettingsPresenter).Name, GetType(GatewayServer).Name)

         If Nothing Is gatewaysList Then
            gatewaysList = New List(Of String)()
         End If

         ServerState.Instance.ServiceAdmin.LoadServices(gatewaysList)

         For Each gatewayService As String In gatewaysList
            If ServerState.Instance.ServiceAdmin.Services.ContainsKey(gatewayService) Then
               Dim gateway As DicomService = ServerState.Instance.ServiceAdmin.Services(gatewayService)
               Dim configFile As String = Path.Combine(gateway.ServiceDirectory, "settings.xml")

               gateway.Settings.LicenseFile = ServerState.Instance.ServerService.Settings.LicenseFile
               AddInUtils.Serialize(Of ServerSettings)(gateway.Settings, configFile)
            End If
         Next gatewayService
      End Sub

#End Region

#Region "Properties"

      Private _view As ServerOptionsView
      Public Property View() As ServerOptionsView
         Get
            Return _view
         End Get
         Private Set(ByVal value As ServerOptionsView)
            _view = value
         End Set
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

      Private Sub ConfigureView()
         If ServerState.Instance.IsRemoteServer Then
            View.Enabled = False

            Return
         End If

         ConfigureMax()
         If Not ServerState.Instance.ServerService Is Nothing Then
            View.AllowAnonymousConnections = ServerState.Instance.ServerService.Settings.AllowAnonymous
#If (LEADTOOLS_V19_OR_LATER) Then
            View.AllowAnonymousCMove = ServerState.Instance.ServerService.Settings.AllowAnonymousCMove
            View.AnonymousClientPort = ServerState.Instance.ServerService.Settings.AnonymousClientPort
#End If ' #if (LEADTOOLS_V19_OR_LATER
            View.AllowClientMultipleConnections = ServerState.Instance.ServerService.Settings.AllowMultipleConnections
            If ServerState.Instance.ServerService.Settings.MaxClients > View.MaxClientsMaxValue Then
               View.MaxClients = View.MaxClientsMaxValue
            Else
               View.MaxClients = ServerState.Instance.ServerService.Settings.MaxClients
            End If
            View.ClientIdleTimeout = ServerState.Instance.ServerService.Settings.ClientTimeout
            View.MessageProcessingTimeout = ServerState.Instance.ServerService.Settings.AddInTimeout
            View.StoreSubOperationsTimeout = ServerState.Instance.ServerService.Settings.ReconnectTimeout
            View.TempDirectory = ServerState.Instance.ServerService.Settings.TemporaryDirectory
            View.RelationalQueries = ServerState.Instance.ServerService.Settings.RelationalQueries
            View.RoleSelectionOptions = ServerState.Instance.ServerService.Settings.RoleSelectionOptions

            View.UseTlsSecurity = ServerState.Instance.ServerService.Settings.Secure
            Else
            View.AllowAnonymousConnections = True
            View.AllowAnonymousCMove = False
            View.AnonymousClientPort = 104
            View.AllowClientMultipleConnections = True
            View.MaxClientsMaxValue = 100
            View.MaxClients = 99
            View.ClientIdleTimeout = 30
            View.MessageProcessingTimeout = 30
            View.StoreSubOperationsTimeout = 30
            View.RelationalQueries = RelationalQuerySupportEnum.Negotiation
            View.RoleSelectionOptions = RoleSelectionFlags.AcceptAllProposed

            View.UseTlsSecurity = False
            End If
         __IsDirty = False
      End Sub

      Private Sub ConfigureMax()
         If Not ServerState.Instance.License Is Nothing Then
            Dim license As ILicense = ServerState.Instance.License
            Dim feature As IFeature = license.GetFeature(ServerFeatures.MaxConcurrentConnections)

            If Not feature Is Nothing AndAlso feature.Type = LicenseFeatureType.LimitedNumber Then
               If Not feature.Counter Is Nothing AndAlso feature.Counter.Value > 0 Then
                  View.MaxClientsMaxValue = feature.Counter.Value
               Else
                  View.MaxClientsMaxValue = Integer.MaxValue
               End If
            ElseIf Not feature Is Nothing AndAlso feature.Type = LicenseFeatureType.Eval AndAlso (Not feature.IsExpired) Then
               View.MaxClientsMaxValue = 10
            Else
               View.MaxClientsMaxValue = 5
            End If
         Else
            View.MaxClientsMaxValue = 100
         End If
      End Sub

      Private Sub UpdateServerSettings(ByVal settings As ServerSettings)
         settings.AllowAnonymous = View.AllowAnonymousConnections
#If (LEADTOOLS_V19_OR_LATER) Then
         settings.AllowAnonymousCMove = View.AllowAnonymousCMove
         settings.AnonymousClientPort = View.AnonymousClientPort
#End If ' #if (LEADTOOLS_V19_OR_LATER)
         settings.AllowMultipleConnections = View.AllowClientMultipleConnections
         settings.MaxClients = View.MaxClients
         settings.ClientTimeout = View.ClientIdleTimeout
         settings.AddInTimeout = View.MessageProcessingTimeout
         settings.ReconnectTimeout = View.StoreSubOperationsTimeout
         settings.TemporaryDirectory = View.TempDirectory
         settings.RelationalQueries = View.RelationalQueries
         settings.RoleSelectionOptions = View.RoleSelectionOptions
         settings.Secure = View.UseTlsSecurity
        End Sub

      Public Sub UpdateSettings()
         If Not ServerState.Instance.ServerService Is Nothing Then
            UpdateServerSettings(ServerState.Instance.ServerService.Settings)

            ServerState.Instance.ServerService.Settings = ServerState.Instance.ServerService.Settings
         End If
      End Sub

#End Region

#Region "Properties"

      Private _myIsDirty As Boolean
      Private Property __IsDirty() As Boolean
         Get
            Return _myIsDirty
         End Get
         Set(ByVal value As Boolean)
            _myIsDirty = value
         End Set
      End Property

#End Region

#Region "Events"

      Public Event SettingsChanged As EventHandler

      Sub View_SettingsChanged(ByVal sender As Object, ByVal e As EventArgs)
         Try
            __IsDirty = True
            RaiseEvent SettingsChanged(sender, e)
         Catch e1 As Exception
            System.Diagnostics.Debug.Assert(False)
         End Try
      End Sub

      Sub OnConfigureView(ByVal sender As Object, ByVal e As EventArgs)
         ConfigureView()
      End Sub

      Sub OnUpdateServerSettings(ByVal sender As Object, ByVal e As EventArgs)
         If __IsDirty Then
            UpdateSettings()
         End If
      End Sub

      Sub OnCancelServerSettings(ByVal sender As Object, ByVal e As EventArgs)
         If __IsDirty Then
            ConfigureView()
         End If
      End Sub

#End Region

#Region "Data Members"

#End Region

#Region "Data Types Definition"

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
