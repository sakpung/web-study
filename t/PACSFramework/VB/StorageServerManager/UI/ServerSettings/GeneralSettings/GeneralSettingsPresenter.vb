' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Dicom.Server.Admin
Imports System.Net
Imports System.IO
Imports System.Configuration
Imports System.Xml
Imports Leadtools.Dicom.AddIn.Common
Imports Leadtools.Demos.StorageServer.DataTypes
Imports Leadtools.Medical.DataAccessLayer.Configuration
Imports Leadtools.DicomDemos
Imports Leadtools.Medical.Winforms
Imports Leadtools.Medical.Storage.AddIns
Imports Leadtools.Dicom.AddIn
Imports Leadtools.Medical.Logging.Addins
Imports Leadtools.Dicom
Imports Leadtools.Dicom.AddIn.Configuration

Namespace Leadtools.Demos.StorageServer.UI
   Partial Friend Class GeneralSettingsPresenter
#Region "Public"

#Region "Methods"

      Public Sub RunView(ByVal _view As GeneralSettingsView)
         AddHandler ServerState.Instance.ServerServiceChanged, AddressOf Instance_ServerServiceChanged
         AddHandler ServerState.Instance.ServiceAdminChanged, AddressOf OnConfigureView
         AddHandler ServerState.Instance.IsRemoteServerChanged, AddressOf OnConfigureView

         EventBroker.Instance.Subscribe(Of ApplyServerSettingsEventArgs)(AddressOf OnUpdateServerSettings)
         EventBroker.Instance.Subscribe(Of CancelServerSettingsEventArgs)(AddressOf OnCancelServerSettings)

         View = _view
         ConfigureView()

         AddHandler View.AddServer, AddressOf View_AddServer
         AddHandler View.DeleteServer, AddressOf View_DeleteServer
         AddHandler View.AETitleChanged, AddressOf View_AETitlechanged
         AddHandler View.IpAddressChanged, AddressOf View_IpAddressChanged
         AddHandler View.PortChanged, AddressOf View_PortChanged

         AddHandler View.ImplementationClassUIDChanged, AddressOf View_ImplementationClassUIDChanged
         AddHandler View.ImplementationVersionNameChanged, AddressOf View_ImplementationVersionNameChanged
         AddHandler View.ServiceStartModeChanged, AddressOf View_ServiceStartModeChanged

         AddHandler View.IpTypeChanged, AddressOf View_IpTypeChanged

         AddHandler View.VisibleChanged, AddressOf View_VisibleChanged

         AddHandler View.SettingsChanged, AddressOf View_SettingsChanged

      End Sub

      Public Event SettingsChanged As EventHandler

      Private Sub View_SettingsChanged(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If Not SettingsChangedEvent Is Nothing Then
               RaiseEvent SettingsChanged(sender, e)
            End If
         Catch e1 As Exception
            System.Diagnostics.Debug.Assert(False)
         End Try
      End Sub


      Public ReadOnly Property IsDirty() As Boolean
         Get
            Return View.IsDirty
         End Get
      End Property


      Private Sub View_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs)
         UpdateIpControls()
      End Sub

      Private Sub View_IpTypeChanged(ByVal sender As Object, ByVal e As EventArgs)
         __IsDirty = True

         Dim _view As GeneralSettingsView = TryCast(sender, GeneralSettingsView)
         If Not _view Is Nothing Then
            Dim addressesStringList As List(Of String) = ConfigureIpList(View.IpType)
            If (addressesStringList.Count > 0) Then
               If View.IpType = DicomNetIpTypeFlags.Ipv4OrIpv6 Then
                  View.IpAddress = addressesStringList(0)
               Else
                  View.IpAddress = addressesStringList(1)
               End If
            Else
               View.IpAddress = ServerDefaultValues.IpAddress
            End If

         End If

      End Sub

      Public Sub UpdateSettings()
         If Not ServerState.Instance.ServerService Is Nothing Then
            UpdateServerSettings(ServerState.Instance.ServerService.Settings)

            ServerState.Instance.ServerService.Settings = ServerState.Instance.ServerService.Settings
         End If
      End Sub

#End Region

#Region "Properties"

      Private _view As GeneralSettingsView
      Public Property View() As GeneralSettingsView
         Get
            Return _view
         End Get
         Private Set(ByVal value As GeneralSettingsView)
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

      Private Function ConfigureIpList(ByVal ipType As DicomNetIpTypeFlags) As List(Of String)
         Dim addresses As IPAddress() = Dns.GetHostAddresses(Dns.GetHostName())
         Dim addressesStringList As List(Of String) = New List(Of String)()
         Dim addressesIpv4StringList As List(Of String) = New List(Of String)()
         Dim addressesIpv6StringList As List(Of String) = New List(Of String)()

         For Each address As IPAddress In addresses
            If address.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
               addressesIpv4StringList.Add(address.ToString())
            ElseIf address.AddressFamily = System.Net.Sockets.AddressFamily.InterNetworkV6 Then
               addressesIpv6StringList.Add(address.ToString())
            End If
         Next address

         View.CanIpV6CheckBox = addressesIpv6StringList.Count > 0
         View.CanIpBothCheckBox = DemosGlobal.IsOnVistaOrLater AndAlso View.CanIpV6CheckBox

         Select Case ipType
            Case DicomNetIpTypeFlags.Ipv4
               ' nothing
            Case DicomNetIpTypeFlags.Ipv6
               If (Not View.CanIpV6CheckBox) Then
                  ipType = DicomNetIpTypeFlags.Ipv4
               End If
            Case DicomNetIpTypeFlags.Ipv4OrIpv6
               If (Not View.CanIpBothCheckBox) Then
                  ipType = DicomNetIpTypeFlags.Ipv4
               End If
         End Select

         addressesStringList.Clear()
         addressesStringList.Add("All")

         If (ipType And DicomNetIpTypeFlags.Ipv4) = DicomNetIpTypeFlags.Ipv4 Then
            For Each s As String In addressesIpv4StringList
               If s <> "0.0.0.0" Then
                  addressesStringList.Add(s)
               End If
            Next s
         End If

         If (ipType And DicomNetIpTypeFlags.Ipv6) = DicomNetIpTypeFlags.Ipv6 Then
            For Each s As String In addressesIpv6StringList
               addressesStringList.Add(s)
            Next s
         End If
         View.SetIpAddressList(addressesStringList.ToArray())
         View.IpType = ipType
         Return addressesStringList
      End Function

      Private Sub UpdateIpControls()
         Dim serviceRunning As Boolean = False
         If Not ServerState.Instance.ServerService Is Nothing Then
            serviceRunning = ServerState.Instance.ServerService.Status = System.ServiceProcess.ServiceControllerStatus.Running
         End If
         View.CanSelectIpAddress = Not serviceRunning
         View.CanSelectIpType = Not serviceRunning
         View.CanSelectPort = Not serviceRunning
      End Sub

      Private Sub ConfigureView()

         If ServerState.Instance.IsRemoteServer Then
            View.Enabled = False

            Return
         End If

         Dim addressesStringList As List(Of String) = Nothing

         View.SetStartupModeList(New String() {"Automatic", "Manual", "Disabled"})

         If ServerState.Instance.ServerService Is Nothing Then
            View.AeTitle = ServerDefaultValues.AeTitle
            View.Port = ServerDefaultValues.Port
            View.IpType = Leadtools.Dicom.DicomNetIpTypeFlags.Ipv4
            addressesStringList = ConfigureIpList(View.IpType)
            If (addressesStringList.Count > 0) Then
               If View.IpType = DicomNetIpTypeFlags.Ipv4OrIpv6 Then
                  View.IpAddress = addressesStringList(0)
               Else
                  View.IpAddress = addressesStringList(1)
               End If
            Else
               View.IpAddress = ServerDefaultValues.IpAddress
            End If
            View.ImplementationClassUID = ServerDefaultValues.ImplementationClassUID
            View.ImplementationVersion = ServerDefaultValues.ImplementationVersion
            View.ServiceDisplayName = ServerDefaultValues.AeTitle
            View.ServiceDecription = ServerDefaultValues.ServiceDecription
            View.ServiceStartupMode = ServerDefaultValues.ServiceStartupMode

            View.CanChangeServiceDescription = True
            View.CanDeleteServer = False
            View.CanAddServer = True AndAlso Not ServerState.Instance.ServiceAdmin Is Nothing
         Else
            View.AeTitle = ServerState.Instance.ServerService.Settings.AETitle
            View.Port = ServerState.Instance.ServerService.Settings.Port
            View.IpType = ServerState.Instance.ServerService.Settings.IpType
            addressesStringList = ConfigureIpList(ServerState.Instance.ServerService.Settings.IpType)
            View.IpAddress = ServerState.Instance.ServerService.Settings.IpAddress
            View.ImplementationClassUID = ServerState.Instance.ServerService.Settings.ImplementationClass
            View.ImplementationVersion = ServerState.Instance.ServerService.Settings.ImplementationVersionName
            View.ServiceDisplayName = ServerState.Instance.ServerService.ServiceName
            View.ServiceDecription = ServerState.Instance.ServerService.Settings.Description
            View.ServiceStartupMode = ServerState.Instance.ServerService.Settings.StartMode

            View.CanChangeServiceDescription = False
            View.CanDeleteServer = True AndAlso Not ServerState.Instance.ServiceAdmin Is Nothing
            View.CanAddServer = False
         End If

         View.CanChangeServiceDisplayName = False

         UpdateIpControls()

         __IsDirty = False
      End Sub

      Private Sub UpdateServerSettings(ByVal settings As ServerSettings)
         settings.AETitle = View.AeTitle
         If View.IpAddress = MyConstants.BothIp Then
            settings.IpAddress = "*"
         Else
            settings.IpAddress = View.IpAddress
         End If
         settings.Port = View.Port
         settings.StartMode = View.ServiceStartupMode

         settings.ImplementationClass = View.ImplementationClassUID
         settings.ImplementationVersionName = View.ImplementationVersion
         settings.Description = View.ServiceDecription

         settings.IpType = View.IpType
      End Sub

      Private Sub CreateServiceAdmin(ByVal serviceName As String)
         Dim serviceAdmin As ServiceAdministrator
         Dim services As List(Of String)

         serviceAdmin = New ServiceAdministrator(ServerState.Instance.BaseDirectory)
         services = New List(Of String)()

         services.Add(serviceName)

         serviceAdmin.Initialize(services)

         If serviceAdmin.IsLocked Then
            Throw New InvalidOperationException("PACS Framework locked.")
         End If

         ServerState.Instance.ServiceAdmin = serviceAdmin
      End Sub

      Private Sub InstallAddIns(ByVal addIns As String(), ByVal configurationAddIns As String(), ByVal serviceName As String)
         Dim addInsDirectory As String = Path.Combine(Path.Combine(ServerState.Instance.ServiceAdmin.BaseDirectory, serviceName), "AddIns")
         Dim configurationDirectory As String = Path.Combine(Path.Combine(ServerState.Instance.ServiceAdmin.BaseDirectory, serviceName), "Configuration")

         Shell.InstallAddIns(addIns, addInsDirectory)
         Shell.InstallAddIns(configurationAddIns, configurationDirectory)

         CreateAddInConfigurationFile(Path.Combine(ServerState.Instance.ServiceAdmin.BaseDirectory, serviceName))
      End Sub

      Private Sub CreateAddInConfigurationFile(ByVal serviceDirectory As String)
         Dim addInConfigurationFile As String
         Dim config As System.Configuration.Configuration
         Dim xml As System.Configuration.ConfigXmlDocument = New ConfigXmlDocument()
         Dim nodes As XmlNodeList

         addInConfigurationFile = Path.Combine(serviceDirectory, "service.config")
         config = ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None)

         config.SaveAs(addInConfigurationFile)

         xml.Load(addInConfigurationFile)

         nodes = xml.GetElementsByTagName("appSettings")

         If nodes.Count > 0 Then
            nodes(0).ParentNode.RemoveChild(nodes(0))

            xml.Save(addInConfigurationFile)
         End If
      End Sub

      Private Function ValidateAETitle() As Boolean
         If View.AeTitle.Length = 0 OrElse View.AeTitle.Length > 16 Then
            View.AETitelValidationMessage("AE Title can't be empty and must be less than 16 characters.")

            Return False
         ElseIf View.AeTitle.ToUpper() <> View.AeTitle Then
            View.AETitelValidationMessage("AE Title must be in upper case letters.")

            Return False
         Else
            View.AETitelValidationMessage("")

            Return True
         End If
      End Function

#End Region

#Region "Properties"

      Private _myIsDirty As Boolean
      Public Property __IsDirty() As Boolean
         Get
            Return _myIsDirty
         End Get
         Set(ByVal value As Boolean)
            _myIsDirty = value
         End Set
      End Property

#End Region

#Region "Events"

      Sub Instance_ServerServiceChanged(ByVal sender As Object, ByVal e As EventArgs)
         ConfigureView()
      End Sub

      Sub View_AddServer(ByVal sender As Object, ByVal e As EventArgs)
         Dim settings As ServerSettings
         Dim service As DicomService

         If Nothing Is ServerState.Instance.ServiceAdmin Then
            CreateServiceAdmin(ServerState.Instance.ServiceName)
         End If

         settings = New ServerSettings()

         UpdateServerSettings(settings)

         Dim addIns As String() = GetAddIns()

         Dim configurationAddIns As String() = GetConfigurationAddIns()

         InstallAddIns(addIns, configurationAddIns, settings.AETitle)

         service = ServerState.Instance.ServiceAdmin.InstallService(settings)

         Dim sotrageConfigManager As StorageModuleConfigurationManager = ServiceLocator.Retrieve(Of StorageModuleConfigurationManager)()
         Dim loggingConfigManager As LoggingModuleConfigurationManager = ServiceLocator.Retrieve(Of LoggingModuleConfigurationManager)()

         sotrageConfigManager.Load(service.ServiceDirectory)
         loggingConfigManager.Load(service.ServiceDirectory)

         ServerState.Instance.ServerService = service

         Dim assemblies As String() = New String(1) {}
         assemblies(0) = "Leadtools.Medical.Logging.Addin.dll"

         AddConfigAssemblies(service.ServiceDirectory, assemblies)
         GlobalPacsUpdater.ModifyGlobalPacsConfiguration(DicomDemoSettingsManager.ProductNameStorageServer, settings.AETitle, GlobalPacsUpdater.ModifyConfigurationType.Add)

         LocalAuditLogQueue.AddAuditMessage(AuditMessages.ServerServiceCreated.Key, String.Format(AuditMessages.ServerServiceCreated.Message, service.ServiceName, service.Settings.AETitle, service.Settings.IpAddress, service.Settings.Port))
      End Sub

      Private Sub AddConfigAssemblies(ByVal serviceDirectory As String, ByVal assemblies As String())
         Dim settings As AdvancedSettings = AdvancedSettings.Open(serviceDirectory)

         If Not settings Is Nothing Then
            settings.SetConfigAssemblies(assemblies)
            settings.Save()
         End If
      End Sub

      Sub View_DeleteServer(ByVal sender As Object, ByVal e As EventArgs)
         If Not Nothing Is ServerState.Instance.ServerService Then
            Dim serviceName As String = ServerState.Instance.ServerService.ServiceName

            GlobalPacsUpdater.ModifyGlobalPacsConfiguration(DicomDemoSettingsManager.ProductNameStorageServer, serviceName, GlobalPacsUpdater.ModifyConfigurationType.Remove)

            ServerState.Instance.ServiceAdmin.UnInstallService(ServerState.Instance.ServerService)

            ServerState.Instance.ServerService.Dispose()

            Dim sotrageConfigManager As StorageModuleConfigurationManager = ServiceLocator.Retrieve(Of StorageModuleConfigurationManager)()
            Dim loggingConfigManager As LoggingModuleConfigurationManager = ServiceLocator.Retrieve(Of LoggingModuleConfigurationManager)()

            sotrageConfigManager.Unload()
            loggingConfigManager.Unload()

            ServerState.Instance.ServerService = Nothing

            LocalAuditLogQueue.AddAuditMessage(AuditMessages.ServerServiceDeleted.Key, String.Format(AuditMessages.ServerServiceDeleted.Message, serviceName))
         End If
      End Sub

      Sub View_AETitlechanged(ByVal sender As Object, ByVal e As EventArgs)
         If ValidateAETitle() Then
            __IsDirty = True

            If ServerState.Instance.ServerService Is Nothing Then
               View.ServiceDisplayName = View.AeTitle
            End If

            LocalAuditLogQueue.AddAuditMessage(AuditMessages.AeTitleChanged.Key, String.Format(AuditMessages.AeTitleChanged.Message, View.AeTitle))
         End If
      End Sub

      Sub OnConfigureView(ByVal sender As Object, ByVal e As EventArgs)
         ConfigureView()
      End Sub

      Sub View_IpAddressChanged(ByVal sender As Object, ByVal e As EventArgs)
         __IsDirty = True

         LocalAuditLogQueue.AddAuditMessage(AuditMessages.IpAddressChanged.Key, String.Format(AuditMessages.IpAddressChanged.Message, View.IpAddress))
      End Sub

      Sub View_PortChanged(ByVal sender As Object, ByVal e As EventArgs)
         __IsDirty = True

         LocalAuditLogQueue.AddAuditMessage(AuditMessages.PortChanged.Key, String.Format(AuditMessages.PortChanged.Message, View.Port))
      End Sub

      Sub View_ImplementationClassUIDChanged(ByVal sender As Object, ByVal e As EventArgs)
         __IsDirty = True

         LocalAuditLogQueue.AddAuditMessage(AuditMessages.ImplementationClassUIDChanged.Key, String.Format(AuditMessages.ImplementationClassUIDChanged.Message, View.ImplementationClassUID))
      End Sub

      Sub View_ImplementationVersionNameChanged(ByVal sender As Object, ByVal e As EventArgs)
         __IsDirty = True

         LocalAuditLogQueue.AddAuditMessage(AuditMessages.ImplementationVersionNameChanged.Key, String.Format(AuditMessages.ImplementationVersionNameChanged.Message, View.ImplementationVersion))
      End Sub

      Sub View_ServiceStartModeChanged(ByVal sender As Object, ByVal e As EventArgs)
         __IsDirty = True

         LocalAuditLogQueue.AddAuditMessage(AuditMessages.ServiceStartModeChanged.Key, String.Format(AuditMessages.ServiceStartModeChanged.Message, View.ServiceStartupMode))
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

      Class ServerDefaultValues
         Public Shared AeTitle As String = ServerState.Instance.ServiceName
         Public Shared Port As Integer = 504
         Public Shared IpAddress As String = String.Empty
         Public Shared ImplementationClassUID As String = "1.2.840.114257.1123456"
         Public Shared ImplementationVersion As String = "LTPACSF V175"
         Public Shared ServiceDisplayName As String = "LEAD Storage Server"
         Public Shared ServiceDecription As String = String.Empty
         Public Shared ServiceStartupMode As String = "Automatic"
      End Class

      Class MyConstants
         Public Const BothIp As String = "All"
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

