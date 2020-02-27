' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Demos.StorageServer.DataTypes
Imports System.Windows.Forms
Imports Leadtools.Medical.Winforms
Imports Leadtools.Medical.Storage.AddIns
Imports Leadtools.Medical.Winforms.Forwarder
Imports Leadtools.Dicom.AddIn.Configuration
Imports System.ServiceProcess
Imports Leadtools.Dicom.AddIn
Imports Leadtools.Dicom.Common.DataTypes
Imports Leadtools.Dicom.AddIn.Interfaces
Imports Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
Imports Leadtools.Logging
Imports Leadtools.Medical.Logging.Addins
Imports Leadtools.Medical.Winforms.DatabaseManager

#If (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) OrElse (LEADTOOLS_V19_OR_LATER) Then
Imports Leadtools.Medical.Winforms.ExternalStore
Imports Leadtools.Dicom.Common.Extensions
#End If

#If (LEADTOOLS_V19_OR_LATER_EXPORT) OrElse (LEADTOOLS_V19_OR_LATER) Then
Imports Leadtools.Medical.Winforms.Anonymize
Imports Leadtools.Medical.Storage.AddIns.Controls.StorageCommit
#End If ' #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

Imports Leadtools.Medical.Winforms.SecurityOptions
Imports Leadtools.Medical.Winforms.ClientManager

Namespace Leadtools.Demos.StorageServer.UI
    Public Class ServerSettingsPresenter
        Public Sub RunView(ByVal _view As ServerSettingsDialog)
            View = _view

            EventBroker.Instance.Subscribe(Of DisplayFeatureEventArgs)(AddressOf OnDisplayFeature)

            AddHandler ServerState.Instance.ServerServiceChanged, AddressOf Instance_ServerServiceChanged
            AddHandler ServerState.Instance.LoggingStateChanged, AddressOf Instance_LoggingStateChanged

            CreateViews()

            View.CanApply = False
            View.CanCancel = True

            AddHandler View.ConfirmChanges, AddressOf View_ConfirmChanges
            AddHandler View.CancelChanges, AddressOf View_CancelChanges
            AddHandler View.ApplyChanges, AddressOf View_ConfirmChanges
        End Sub

        Private Sub Instance_ServerServiceChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim serviceDirectory As String


            serviceDirectory = String.Empty

            If Not Nothing Is __StorageSettingsPresenter Then
                If Not Nothing Is ServerState.Instance.ServerService Then
                    serviceDirectory = ServerState.Instance.ServerService.ServiceDirectory
                End If

                ConfigureForwarder()
                ConfigureAutoCopy()

                __PatientUpdaterPresenter.ServiceDirectory = serviceDirectory

                __StorageSettingsPresenter.ReConfigureViews()
            End If

            If Not Nothing Is __LoggingConfigPresenter Then
                __LoggingConfigPresenter.EnableView = Not ServerState.Instance.ServerService Is Nothing
            End If
        End Sub

        Private Sub Instance_LoggingStateChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Not Nothing Is __LoggingConfigPresenter Then
                __LoggingConfigPresenter.ResetState(ServerState.Instance.LoggingState)
            End If
        End Sub

        Private Sub CreateViews()
            Dim configManager As StorageModuleConfigurationManager


            configManager = ServiceLocator.Retrieve(Of StorageModuleConfigurationManager)()

            Dim generalPresenter As GeneralSettingsPresenter = New GeneralSettingsPresenter()
            Dim optionsPresenter As ServerOptionsPresenter = New ServerOptionsPresenter()
            Dim generalView As GeneralSettingsView = New GeneralSettingsView()
            Dim optionsView As ServerOptionsView = New ServerOptionsView()
            Dim networkPresenter As ServerNetworkingPresenter = New ServerNetworkingPresenter()
            Dim networkView As ServerNetworkingView = New ServerNetworkingView()

            Dim storeOptionsView As StorageOptionsView = New StorageOptionsView()
            Dim queryOptionsView As QueryOptionsView = New QueryOptionsView()
            Dim storagePresenter As StorageSettingsPresenter = New StorageSettingsPresenter(configManager)

#If LEADTOOLS_V19_OR_LATER Then
            Dim storageCommitView As New StorageCommitView()
            Dim storageCommitPresenter As New StorageCommitPresenter()
#End If
            Dim securityOptionsPresenter As New SecurityOptionsPresenter()

            Dim loggingConfigView As New EventLogConfigurationView()

            Dim clientConfigPresenter As ClientViewerPresenter = New ClientViewerPresenter()
            Dim clientConfigView As ClientViewerControl = New ClientViewerControl()

            Dim loggingConfigPresenter As EventLogConfigurationPresenter = New EventLogConfigurationPresenter()

            Dim patientUpdaterView As PatientUpdaterConfigurationView = New PatientUpdaterConfigurationView()
            Dim patientUpdaterPresenter As PatientUpdaterPresenter = New PatientUpdaterPresenter()

            Dim autoCopyView As AutoCopyView = New AutoCopyView()
            Dim autoCopyPresenter As AutoCopyPresenter = New AutoCopyPresenter()

            Dim storageClassesView As StorageClassesTabControl = New StorageClassesTabControl()
            Dim storageClassesPresenter As StorageClassesPresenter = New StorageClassesPresenter()
            Dim forwardView As ForwardManagerConfigurationView = New ForwardManagerConfigurationView()
            forwardView.Visible = False
            Dim forwardPresenter As ForwardManagerPresenter = New ForwardManagerPresenter()

            Dim gatewayPresenter As GatewaySettingsPresenter = New GatewaySettingsPresenter()
            Dim gatewayView As GatewaySettingsView = New GatewaySettingsView()

            Dim securityOptionsView As SecurityOptionsView = New SecurityOptionsView()

#If (LEADTOOLS_V19_OR_LATER_EXPORT) OrElse (LEADTOOLS_V19_OR_LATER) Then
            Dim anonymizeOptionsPresenter As New AnonymizeOptionsPresenter()
            Dim anonymizeOptionsView As AnonymizeOptionsView = New AnonymizeOptionsView With {.SaveButtonVisible = False}
#End If ' #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

#If (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) OrElse (LEADTOOLS_V19_OR_LATER) Then
            Dim externalStoreView As New ExternalStoreConfigurationView()
            Dim externalStorePresenter As New ExternalStorePresenter()

            InitializeExternalStore(externalStoreView, externalStorePresenter)
#End If

            InitializeForwarding(forwardView, forwardPresenter)
            InitializeAutoCopy(autoCopyView, autoCopyPresenter)

#If LEADTOOLS_V19_OR_LATER Then
            InitializeStorageCommit(storageCommitView, storageCommitPresenter)
#End If

            InitializeSecurityOptionsView(securityOptionsView, securityOptionsPresenter)

            generalPresenter.RunView(generalView)
            optionsPresenter.RunView(optionsView)
            networkPresenter.RunView(networkView)
            patientUpdaterPresenter.RunView(patientUpdaterView, If(ServerState.Instance.ServerService IsNot Nothing, ServerState.Instance.ServerService.ServiceDirectory, String.Empty))
            clientConfigPresenter.RunView(clientConfigView)
            storageClassesPresenter.RunView(storageClassesView)

#If (LEADTOOLS_V19_OR_LATER_EXPORT) OrElse (LEADTOOLS_V19_OR_LATER) Then
            anonymizeOptionsPresenter.RunView(anonymizeOptionsView)
#End If ' #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)   

            gatewayPresenter.RunView(gatewayView)

            loggingConfigPresenter.RunView(loggingConfigView, ServerState.Instance.LoggingState)

            loggingConfigPresenter.EnableView = Not ServerState.Instance.ServerService Is Nothing

            storeOptionsView.ShowDeleteAnnotationOption = False

            storagePresenter.RunViews(storeOptionsView, queryOptionsView)

            View.AddFeatureControl(FeatureNames.ServerParentFeature, generalView, Nothing)
            View.AddFeatureControl(FeatureNames.ServerSettings, generalView, FeatureNames.ServerParentFeature)
            View.AddFeatureControl(FeatureNames.ClientConfig, clientConfigView, FeatureNames.ServerParentFeature)
            View.AddFeatureControl(FeatureNames.ServerOptions, optionsView, FeatureNames.ServerParentFeature)
            View.AddFeatureControl(FeatureNames.ServerNetworking, networkView, FeatureNames.ServerParentFeature)

            '
            ' Storage Settings
            '
            View.AddFeatureControl(FeatureNames.StoreSettingsParentFeature, storeOptionsView, Nothing)
            View.AddFeatureControl(FeatureNames.StoreSettings, storeOptionsView, FeatureNames.StoreSettingsParentFeature)
            View.AddFeatureControl(FeatureNames.QuerySettings, queryOptionsView, FeatureNames.StoreSettingsParentFeature)
#If LEADTOOLS_V19_OR_LATER Then
            View.AddFeatureControl(FeatureNames.StorageCommit, storageCommitView, FeatureNames.StoreSettingsParentFeature)
#End If
            View.AddFeatureControl(FeatureNames.IodClasses, storageClassesView, FeatureNames.StoreSettingsParentFeature)

            If UserManager.User.IsAdmin() Then
                Dim passwordOptionsPresenter As New PasswordOptionsPresenter()
                Dim passwordOptions As New PasswordOptionsView()

                Dim userViewPresenter As New UserViewPresenter()
                Dim rolesViewPresenter As New RolesViewPresenter()
                Dim userView As New UserView()
                Dim rolesView As New RolesView()
                Dim databaseManagerOptionsView As New DatabaseManagerOptionsView()
                Dim databaseManagerOptionsPresenter As New DatabaseManagerOptionsPresenter()

                Dim clientConfigurationOptionsView As New ClientConfigurationOptionsView()
                Dim clientConfigurationOptionsPresenter As New ClientConfigurationOptionsPresenter()
                __ClientConfigurationOptionsPresenter = clientConfigurationOptionsPresenter


                __UserViewPresenter = userViewPresenter
                __RolesViewPresenter = rolesViewPresenter
                __DatabaseManagerOptionsPresenter = databaseManagerOptionsPresenter

                passwordOptionsPresenter.RunView(passwordOptions)
                userViewPresenter.RunView(userView)
                rolesViewPresenter.RunView(rolesView)
                databaseManagerOptionsPresenter.RunView(databaseManagerOptionsView)
                clientConfigurationOptionsPresenter.RunView(clientConfigurationOptionsView)

                '
                ' Administrative Settings
                '
                View.AddFeatureControl(FeatureNames.AdministrationParentFeature, passwordOptions, Nothing)
                View.AddFeatureControl(FeatureNames.PasswordOptions, passwordOptions, FeatureNames.AdministrationParentFeature)
                View.AddFeatureControl(FeatureNames.Users, userView, FeatureNames.AdministrationParentFeature)
                View.AddFeatureControl(FeatureNames.Roles, rolesView, FeatureNames.AdministrationParentFeature)
                View.AddFeatureControl(FeatureNames.DatabaseManagerOptions, databaseManagerOptionsView, FeatureNames.AdministrationParentFeature)
                View.AddFeatureControl(FeatureNames.ClientConfigurationOptions, clientConfigurationOptionsView, FeatureNames.AdministrationParentFeature)


#If (LEADTOOLS_V19_OR_LATER_EXPORT) OrElse (LEADTOOLS_V19_OR_LATER) Then
                View.AddFeatureControl(FeatureNames.AnonymizeOptions, anonymizeOptionsView, FeatureNames.AdministrationParentFeature)
#End If ' #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)         

                __PasswordOptionsPresenter = passwordOptionsPresenter

                AddHandler __PasswordOptionsPresenter.IdleTimeout, AddressOf passwordOptionsPresenter_IdleTimeout
            End If

            View.AddFeatureControl(FeatureNames.PatientUpdater, patientUpdaterView, Nothing)
            View.AddFeatureControl(FeatureNames.AutoCopy, autoCopyView, Nothing)
            View.AddFeatureControl(FeatureNames.LoggingConfig, loggingConfigView, Nothing)
            View.AddFeatureControl(FeatureNames.Forwarder, forwardView, Nothing)

            View.AddFeatureControl(FeatureNames.Gateway, gatewayView, Nothing)

#If (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) OrElse (LEADTOOLS_V19_OR_LATER) Then
            View.AddFeatureControl(FeatureNames.ExternalStore, externalStoreView, Nothing)
#End If
            View.AddFeatureControl(FeatureNames.SecurityOptions, securityOptionsView, Nothing)

            __SecurityOptionsPresenter = securityOptionsPresenter
#If (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) OrElse (LEADTOOLS_V19_OR_LATER) Then
            __ExternalStorePresenter = externalStorePresenter
#End If

            __LoggingConfigPresenter = loggingConfigPresenter
            __PatientUpdaterPresenter = patientUpdaterPresenter
            __AutoCopyPresenter = autoCopyPresenter
            __StorageClassesPresenter = storageClassesPresenter
            __StorageSettingsPresenter = storagePresenter
            __ClientConfigPresenter = clientConfigPresenter
            __GatewaySettingsPresenter = gatewayPresenter
            __GeneralSettingsPresenter = generalPresenter
            __ServerOptionsPresenter = optionsPresenter
            __ServerNetworkingPresenter = networkPresenter

#If (LEADTOOLS_V19_OR_LATER_EXPORT) OrElse (LEADTOOLS_V19_OR_LATER) Then
            __AnonymizeOptionsPresenter = anonymizeOptionsPresenter
#End If ' #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)


            SetClientConfigLicense()
            SetGatewayLicense()

            ' Subscribe to SettingsChanged events
            AddHandler __LoggingConfigPresenter.SettingsChanged, AddressOf OnSettingsChanged
            AddHandler __PatientUpdaterPresenter.SettingsChanged, AddressOf OnSettingsChanged
            AddHandler __AutoCopyPresenter.SettingsChanged, AddressOf OnSettingsChanged
            AddHandler __StorageClassesPresenter.SettingsChanged, AddressOf OnSettingsChanged
            AddHandler __StorageSettingsPresenter.SettingsChanged, AddressOf OnSettingsChanged
            AddHandler __ClientConfigPresenter.SettingsChanged, AddressOf OnSettingsChanged

            AddHandler __GeneralSettingsPresenter.SettingsChanged, AddressOf OnSettingsChanged
            AddHandler __ServerOptionsPresenter.SettingsChanged, AddressOf OnSettingsChanged
            AddHandler __ServerNetworkingPresenter.SettingsChanged, AddressOf OnSettingsChanged
            AddHandler __ForwardPresenter.SettingsChanged, AddressOf OnSettingsChanged

#If (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) OrElse (LEADTOOLS_V19_OR_LATER) Then
            AddHandler __ExternalStorePresenter.SettingsChanged, AddressOf OnSettingsChanged
#End If

#If (LEADTOOLS_V19_OR_LATER_EXPORT) OrElse (LEADTOOLS_V19_OR_LATER) Then
            AddHandler __AnonymizeOptionsPresenter.SettingsChanged, AddressOf OnSettingsChanged
#End If ' #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

#If LEADTOOLS_V19_OR_LATER Then
            If __StorageCommitPresenter IsNot Nothing Then
                AddHandler __StorageCommitPresenter.SettingsChanged, AddressOf OnSettingsChanged
            End If
#End If

            If __SecurityOptionsPresenter IsNot Nothing Then
                AddHandler __SecurityOptionsPresenter.SettingsChanged, AddressOf OnSettingsChanged
            End If

            If __PasswordOptionsPresenter IsNot Nothing Then
                AddHandler __PasswordOptionsPresenter.SettingsChanged, AddressOf OnSettingsChanged
            End If

            If __UserViewPresenter IsNot Nothing Then
                AddHandler __UserViewPresenter.SettingsChanged, AddressOf OnSettingsChanged
            End If

            If __RolesViewPresenter IsNot Nothing Then
                AddHandler __RolesViewPresenter.SettingsChanged, AddressOf OnSettingsChanged
            End If

            If __DatabaseManagerOptionsPresenter IsNot Nothing Then
                AddHandler __DatabaseManagerOptionsPresenter.SettingsChanged, AddressOf OnSettingsChanged
            End If

            If __ClientConfigurationOptionsPresenter IsNot Nothing Then
                AddHandler __ClientConfigurationOptionsPresenter.SettingsChanged, AddressOf OnSettingsChanged
            End If

            EventBroker.Instance.Subscribe(Of ActivateIdleMonitorEventArgs)(New EventHandler(Of ActivateIdleMonitorEventArgs)(AddressOf OnActivateIdle))

            EventBroker.Instance.Subscribe(Of ExitMinimizedStateEventArgs)(New EventHandler(Of ExitMinimizedStateEventArgs)(AddressOf OnExitMinimizedState))

        End Sub

        Private Sub OnExitMinimizedState(ByVal sender As Object, ByVal e As ExitMinimizedStateEventArgs)
            If e.MinimizedSeconds <> 0 Then
                If (e.MinimizedSeconds > __PasswordOptionsPresenter.View.Options.IdleTimeOut) AndAlso __PasswordOptionsPresenter.View.Options.EnableIdleTimeout Then
                    EventBroker.Instance.PublishEvent(Of LoginEventArgs)(Me, New LoginEventArgs())
                End If
            End If
        End Sub

        Private Sub InitializeAutoCopy(ByVal autoCopyView As AutoCopyView, ByVal autoCopyPresenter As AutoCopyPresenter)
            If Not ServerState.Instance.ServerService Is Nothing Then
                Dim settings As AdvancedSettings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory)

                autoCopyPresenter.RunView(autoCopyView, settings)
            Else
                autoCopyPresenter.RunView(autoCopyView, Nothing)
            End If
            __AutoCopyPresenter = autoCopyPresenter
        End Sub

#If LEADTOOLS_V19_OR_LATER Then
        Private Sub InitializeStorageCommit(ByVal storageCommitView As StorageCommitView, ByVal storageCommitPresenter As StorageCommitPresenter)
            If ServerState.Instance.ServerService IsNot Nothing Then
                Dim settings As AdvancedSettings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory)

                storageCommitPresenter.RunView(storageCommitView, settings)
            Else
                storageCommitPresenter.RunView(storageCommitView, Nothing)
            End If
            __StorageCommitPresenter = storageCommitPresenter
        End Sub
#End If ' #if LEADTOOLS_V19_OR_LATER

        Private Sub InitializeSecurityOptionsView(ByVal securityOptionsView As SecurityOptionsView, ByVal securityOptionsPresenter As SecurityOptionsPresenter)
            If ServerState.Instance.ServerService IsNot Nothing Then
                Dim settings As AdvancedSettings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory)

                securityOptionsPresenter.RunView(securityOptionsView, settings)
            Else
                securityOptionsPresenter.RunView(securityOptionsView, Nothing)
            End If
            __SecurityOptionsPresenter = securityOptionsPresenter
        End Sub

        Private Sub InitializeForwarding(ByVal forwardView As ForwardManagerConfigurationView, ByVal forwardPresenter As ForwardManagerPresenter)
            If Not ServerState.Instance.ServerService Is Nothing Then
                Dim settings As AdvancedSettings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory)

                forwardPresenter.RunView(forwardView, settings)
            Else
                forwardPresenter.RunView(forwardView, Nothing)
            End If

            __ForwardPresenter = forwardPresenter
            AddHandler __ForwardPresenter.Forward, AddressOf Forwarder_Forward
            AddHandler __ForwardPresenter.Clean, AddressOf Forwarder_Clean
            AddHandler __ForwardPresenter.Reset, AddressOf Forwarder_Reset
            ConfigureForwarder()

            AddHandler ServerState.Instance.IsRemoteServerChanged, AddressOf OnConfigurerFowarder
            AddHandler ServerState.Instance.RemoteServerInformationChanged, AddressOf OnConfigurerFowarder
        End Sub

#If (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) OrElse (LEADTOOLS_V19_OR_LATER) Then
        Private Sub InitializeExternalStore(ByVal externalStoreView As ExternalStoreConfigurationView, ByVal externalStorePresenter As ExternalStorePresenter)
            If ServerState.Instance.ServerService IsNot Nothing Then
                Dim settings As AdvancedSettings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory)

                externalStorePresenter.ServiceDirectory = ServerState.Instance.ServerService.ServiceDirectory

                externalStorePresenter.RunView(externalStoreView, settings)
            Else
                externalStorePresenter.RunView(externalStoreView, Nothing)
            End If

            __ExternalStorePresenter = externalStorePresenter
            AddHandler __ExternalStorePresenter.ExternalStore, AddressOf ExternalStorePresenter_ExternalStore
            AddHandler __ExternalStorePresenter.CancelExternalStore, AddressOf ExternalStorePresenter_CancelExternalStore
            AddHandler __ExternalStorePresenter.Clean, AddressOf ExternalStorePresenter_Clean
            AddHandler __ExternalStorePresenter.Restore, AddressOf ExternalStorePresenter_Restore
            AddHandler __ExternalStorePresenter.CancelRestore, AddressOf ExternalStorePresenter_CancelRestore
            AddHandler __ExternalStorePresenter.Reset, AddressOf ExternalStorePresenter_Reset
            ConfigureExternalStore()

            'ServerState.Instance.IsRemoteServerChanged += new EventHandler(OnConfigurerFowarder);
            'ServerState.Instance.RemoteServerInformationChanged += new EventHandler(OnConfigurerFowarder);   
        End Sub

        Private Sub ConfigureExternalStore()
            If ServerState.Instance.ServerService IsNot Nothing Then
                Dim settings As AdvancedSettings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory)

                __ExternalStorePresenter.UpdateSettings(settings)
                __ExternalStorePresenter.EnableTools(ServerState.Instance.ServerService.Status = ServiceControllerStatus.Running)
                AddHandler ServerState.Instance.ServerService.StatusChange, AddressOf ExternalStore_ServerService_StatusChange
                AddHandler ServerState.Instance.LicenseChanged, AddressOf Instance_LicenseChanged
            Else
                __ExternalStorePresenter.EnableTools(False)
                __ExternalStorePresenter.View.Enabled = False
            End If
            Instance_LicenseChanged(Me, EventArgs.Empty)
        End Sub
#End If ' #if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)

        Private Sub ConfigureForwarder()
            If Not ServerState.Instance.ServerService Is Nothing Then
                Dim settings As AdvancedSettings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory)

                __ForwardPresenter.UpdateSettings(settings)
                __ForwardPresenter.EnableTools(ServerState.Instance.ServerService.Status = ServiceControllerStatus.Running)
                AddHandler ServerState.Instance.ServerService.StatusChange, AddressOf ServerService_StatusChange
                AddHandler ServerState.Instance.LicenseChanged, AddressOf Instance_LicenseChanged
            Else
                __ForwardPresenter.EnableTools(False)
                __ForwardPresenter.View.Enabled = False
            End If
            Instance_LicenseChanged(Me, EventArgs.Empty)
        End Sub

        Private Sub ConfigureAutoCopy()
            If Not ServerState.Instance.ServerService Is Nothing Then
                Dim settings As AdvancedSettings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory)

                __ForwardPresenter.UpdateSettings(settings)
            End If
        End Sub

        Private Sub Instance_LicenseChanged(ByVal sender As Object, ByVal e As EventArgs)
            SetDefaultPresentersLicense()
            SetForwardLicense()
            SetGatewayLicense()
            SetClientConfigLicense()
#If (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) OrElse (LEADTOOLS_V19_OR_LATER) Then
            SetExternalStoreLicense()
#End If
        End Sub

        Private Sub SetDefaultPresentersLicense()
            ' Always enabled

            ' DICOM Server
            If __GeneralSettingsPresenter IsNot Nothing Then
                __GeneralSettingsPresenter.View.Enabled = True
            End If
            If __ClientConfigPresenter IsNot Nothing Then
                __ClientConfigPresenter.View.Enabled = True
            End If
            If __ServerOptionsPresenter IsNot Nothing Then
                __ServerOptionsPresenter.View.Enabled = True
            End If
            If __ServerNetworkingPresenter IsNot Nothing Then
                __ServerNetworkingPresenter.View.Enabled = True
            End If

            ' Storage Settings
            If __StorageSettingsPresenter IsNot Nothing Then
                __StorageSettingsPresenter.StorageView.Enabled = True
            End If
            If __StorageSettingsPresenter IsNot Nothing Then
                __StorageSettingsPresenter.QueryView.Enabled = True
            End If
            If __StorageClassesPresenter IsNot Nothing Then
                __StorageClassesPresenter.View.Enabled = True
            End If

            ' Adminstration
            If __PasswordOptionsPresenter IsNot Nothing Then
                __PasswordOptionsPresenter.View.Enabled = True
            End If
            If __UserViewPresenter IsNot Nothing Then
                __UserViewPresenter.View.Enabled = True
            End If
            If __RolesViewPresenter IsNot Nothing Then
                __RolesViewPresenter.View.Enabled = True
            End If
            If __DatabaseManagerOptionsPresenter IsNot Nothing Then
                __DatabaseManagerOptionsPresenter.View.Enabled = True
            End If
            If __ClientConfigurationOptionsPresenter IsNot Nothing Then
                __ClientConfigurationOptionsPresenter.View.Enabled = True
            End If

            ' Patient Updater
            If __PatientUpdaterPresenter IsNot Nothing Then
                __PatientUpdaterPresenter.View.Enabled = True
            End If

            ' Auto Copy
            If __AutoCopyPresenter IsNot Nothing Then
                __AutoCopyPresenter.View.Enabled = True
            End If

            ' Logging Configuration
            If __LoggingConfigPresenter IsNot Nothing Then
                __LoggingConfigPresenter.View.Enabled = True
            End If

            ' Forwarding
            ' Controled by licensing

            ' Gateway
            ' Controlled by licensing

            ' Anonymize
#If (LEADTOOLS_V19_OR_LATER_EXPORT) OrElse (LEADTOOLS_V19_OR_LATER) Then
            If __AnonymizeOptionsPresenter IsNot Nothing Then
                __AnonymizeOptionsPresenter.View.Enabled = True
            End If
#End If ' #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
        End Sub

        Private Function IsFeatureValid(ByVal featureId As String) As Boolean
            Dim ret As Boolean = True

            Dim license As ILicense = ServerState.Instance.License
            If license Is Nothing Then
                Return False
            End If

            Dim feature As IFeature = license.GetFeature(featureId)
            If feature Is Nothing Then
                ret = False
            ElseIf feature.Type = LicenseFeatureType.Off Then
                ret = False
            ElseIf feature.Type = LicenseFeatureType.Eval AndAlso feature.IsExpired Then
                ret = False
            Else
                ret = True
            End If
            Return ret
        End Function

        Private Sub SetForwardLicense()
            If Not __ForwardPresenter Is Nothing Then
                If Not ServerState.Instance.License Is Nothing Then
                    Dim license As ILicense = ServerState.Instance.License
                    Dim feature As IFeature = license.GetFeature(ServerFeatures.Forwarding)

                    If Not feature Is Nothing AndAlso feature.Type <> LicenseFeatureType.Eval Then
                        __ForwardPresenter.View.Enabled = True
                    ElseIf Not feature Is Nothing AndAlso feature.Type = LicenseFeatureType.Eval AndAlso (Not feature.IsExpired) Then
                        __ForwardPresenter.View.Enabled = True
                    Else
                        __ForwardPresenter.View.Enabled = False
                    End If
                Else
                    __ForwardPresenter.View.Enabled = False
                End If
            End If
        End Sub

        Private Sub SetGatewayLicense()
            If Not __GatewaySettingsPresenter Is Nothing Then
                If Not ServerState.Instance.License Is Nothing Then
                    Dim license As ILicense = ServerState.Instance.License
                    Dim feature As IFeature = license.GetFeature(ServerFeatures.Gateway)

                    If Not feature Is Nothing AndAlso feature.Type <> LicenseFeatureType.Eval Then
                        __GatewaySettingsPresenter.View.Enabled = True
                    ElseIf Not feature Is Nothing AndAlso feature.Type = LicenseFeatureType.Eval AndAlso (Not feature.IsExpired) Then
                        __GatewaySettingsPresenter.View.Enabled = True
                    Else
                        __GatewaySettingsPresenter.View.Enabled = False
                    End If
                Else
                    __GatewaySettingsPresenter.View.Enabled = False
                End If
            End If
        End Sub

        Private Sub SetClientConfigLicense()
            If Not __ClientConfigPresenter Is Nothing Then
                If Not ServerState.Instance.License Is Nothing Then
                    Dim license As ILicense = ServerState.Instance.License
                    Dim feature As IFeature = license.GetFeature(ServerFeatures.MaxConfigurableClients)

                    If Not feature Is Nothing AndAlso feature.Type = LicenseFeatureType.LimitedNumber Then
                        If (feature.Counter <= 0) Then
                            __ClientConfigPresenter.MaxClients = Integer.MaxValue
                        Else
                            __ClientConfigPresenter.MaxClients = feature.Counter
                        End If
                    ElseIf Not feature Is Nothing AndAlso feature.Type = LicenseFeatureType.Eval AndAlso (Not feature.IsExpired) Then
                        __ClientConfigPresenter.MaxClients = 10
                    ElseIf feature Is Nothing Then
                        __ClientConfigPresenter.MaxClients = Nothing
                    Else
                        __ClientConfigPresenter.MaxClients = 0
                    End If

                Else
                    '
                    ' If there is not setting for max clients then there is no limitation
                    '
                    __ClientConfigPresenter.MaxClients = Nothing
                End If
            End If
        End Sub

        Private Sub OnConfigurerFowarder(ByVal sender As Object, ByVal e As EventArgs)
            ConfigureForwarder()
        End Sub

        Private Sub passwordOptionsPresenter_IdleTimeout(ByVal sender As Object, ByVal e As EventArgs)
            EventBroker.Instance.PublishEvent(Of LoginEventArgs)(Me, New LoginEventArgs())
        End Sub

        Private Sub OnActivateIdle(ByVal sender As Object, ByVal e As ActivateIdleMonitorEventArgs)
            If Not Nothing Is __PasswordOptionsPresenter Then
                __PasswordOptionsPresenter.UpdateIdleMonitor(e)
            End If
        End Sub

#If (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) OrElse (LEADTOOLS_V19_OR_LATER) Then
        Private Sub SetExternalStoreLicense()
            If __ExternalStorePresenter IsNot Nothing Then
                __ExternalStorePresenter.View.Enabled = IsFeatureValid(ServerFeatures.ExternalStore)
            End If
        End Sub

        Private Sub ExternalStorePresenter_ExternalStore(ByVal sender As Object, ByVal e As ExternalStoreMessageEventArgs)
            If ServerState.Instance.ServerService IsNot Nothing Then
                ServerState.Instance.ServerService.SendMessage(ExternalStoreMessage.ExternalStore, e.ExternalStoreTo)
            End If
        End Sub

        Private Sub ExternalStorePresenter_CancelExternalStore(ByVal sender As Object, ByVal e As EventArgs)
            If ServerState.Instance.ServerService IsNot Nothing Then
                ServerState.Instance.ServerService.SendMessage(ExternalStoreMessage.CancelExternalStore)
            End If
        End Sub

        Private Sub ExternalStorePresenter_Clean(ByVal sender As Object, ByVal e As Leadtools.Medical.Winforms.ExternalStore.CleanMessageEventArgs)
            If ServerState.Instance.ServerService IsNot Nothing Then
                ServerState.Instance.ServerService.SendMessage(ExternalStoreMessage.Clean, e.ExternalStoreTo, e.ExpirationDays)
            End If
        End Sub

        Private Sub ExternalStorePresenter_Restore(ByVal sender As Object, ByVal e As RestoreMessageEventArgs)
            If ServerState.Instance.ServerService IsNot Nothing Then
                Dim range As New DateRange()

                range.StartDate = e.Start
                range.EndDate = e.End
                ServerState.Instance.ServerService.SendMessage(ExternalStoreMessage.Restore, e.RestoreFrom, range)
            End If
        End Sub

        Private Sub ExternalStorePresenter_CancelRestore(ByVal sender As Object, ByVal e As EventArgs)
            If ServerState.Instance.ServerService IsNot Nothing Then
                ServerState.Instance.ServerService.SendMessage(ExternalStoreMessage.CancelRestore)
            End If
        End Sub

        Private Sub ExternalStorePresenter_Reset(ByVal sender As Object, ByVal e As Leadtools.Medical.Winforms.ExternalStore.ResetEventArgs)
            If ServerState.Instance.ServerService IsNot Nothing Then
                Dim range As New DateRange()

                range.StartDate = e.Start
                range.EndDate = e.End
                ServerState.Instance.ServerService.SendMessage(ExternalStoreMessage.Reset, range)
            End If
        End Sub

        Private Sub ExternalStoreStatusChangeProc()
            __ExternalStorePresenter.EnableTools(ServerState.Instance.ServerService.Status = ServiceControllerStatus.Running)
        End Sub

        Private Sub ExternalStore_ServerService_StatusChange(ByVal sender As Object, ByVal e As EventArgs)
            AsyncHelper.SynchronizedInvoke(Application.OpenForms(0), AddressOf ExternalStoreStatusChangeProc)
        End Sub
#End If ' #if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)

        Private Sub Forwarder_Forward(ByVal sender As Object, ByVal e As ForwardMessageEventArgs)
            If Not ServerState.Instance.ServerService Is Nothing Then
                ServerState.Instance.ServerService.SendMessage(ForwarderMessage.Forward, e.ForwardTo)
            End If
        End Sub

        Private Sub Forwarder_Clean(ByVal sender As Object, ByVal e As Leadtools.Medical.Winforms.Forwarder.SendMessageEventArgs)
            If Not ServerState.Instance.ServerService Is Nothing Then
                ServerState.Instance.ServerService.SendMessage(ForwarderMessage.Clean)
            End If
        End Sub

        Private Sub Forwarder_Reset(ByVal sender As Object, ByVal e As Leadtools.Medical.Winforms.Forwarder.ResetEventArgs)
            If Not ServerState.Instance.ServerService Is Nothing Then
                Dim range As DateRange = New DateRange()

                range.StartDate = e.Start
                range.EndDate = e.End
                ServerState.Instance.ServerService.SendMessage(ForwarderMessage.Reset, range)
            End If
        End Sub

        Private Sub StatusChangeProc()
            __ForwardPresenter.EnableTools(ServerState.Instance.ServerService.Status = ServiceControllerStatus.Running)
        End Sub
        Private Sub ServerService_StatusChange(ByVal sender As Object, ByVal e As EventArgs)
            AsyncHelper.SynchronizedInvoke(Application.OpenForms(0), AddressOf StatusChangeProc)
        End Sub

        Private _view As ServerSettingsDialog
        Public Property View() As ServerSettingsDialog
            Get
                Return _view
            End Get
            Private Set(ByVal value As ServerSettingsDialog)
                _view = value
            End Set
        End Property

        Private Sub OnDisplayFeature(ByVal sender As Object, ByVal featureArgs As DisplayFeatureEventArgs)
            If FeatureNames.DisplaySettingsFeature Is featureArgs.Feature Then
                View.EnsureActive()
            ElseIf View.IsFeatureAdded(featureArgs.Feature) Then
                View.SelectFeature(featureArgs.Feature)

                View.EnsureActive()
            End If
        End Sub

        Private _myLoggingConfigPresenter As EventLogConfigurationPresenter
        Private Property __LoggingConfigPresenter() As EventLogConfigurationPresenter
            Get
                Return _myLoggingConfigPresenter
            End Get
            Set(ByVal value As EventLogConfigurationPresenter)
                _myLoggingConfigPresenter = value
            End Set
        End Property

        Private _myPatientUpdaterPresenter As PatientUpdaterPresenter
        Private Property __PatientUpdaterPresenter() As PatientUpdaterPresenter
            Get
                Return _myPatientUpdaterPresenter
            End Get
            Set(ByVal value As PatientUpdaterPresenter)
                _myPatientUpdaterPresenter = value
            End Set
        End Property

        Private _myAutoCopyPresenter As AutoCopyPresenter
        Private Property __AutoCopyPresenter() As AutoCopyPresenter
            Get
                Return _myAutoCopyPresenter
            End Get
            Set(ByVal value As AutoCopyPresenter)
                _myAutoCopyPresenter = value
            End Set
        End Property

        Private _myForwardPresenter As ForwardManagerPresenter
        Private Property __ForwardPresenter() As ForwardManagerPresenter
            Get
                Return _myForwardPresenter
            End Get
            Set(ByVal value As ForwardManagerPresenter)
                _myForwardPresenter = value
            End Set
        End Property

        Private _myPasswordOptionsPresenter As PasswordOptionsPresenter
        Private Property __PasswordOptionsPresenter() As PasswordOptionsPresenter
            Get
                Return _myPasswordOptionsPresenter
            End Get
            Set(ByVal value As PasswordOptionsPresenter)
                _myPasswordOptionsPresenter = value
            End Set
        End Property

        Private _myStorageClassesPresenter As StorageClassesPresenter
        Private Property __StorageClassesPresenter() As StorageClassesPresenter
            Get
                Return _myStorageClassesPresenter
            End Get
            Set(ByVal value As StorageClassesPresenter)
                _myStorageClassesPresenter = value
            End Set
        End Property

        Private _myStorageSettingsPresenter As StorageSettingsPresenter
        Private Property __StorageSettingsPresenter() As StorageSettingsPresenter
            Get
                Return _myStorageSettingsPresenter
            End Get
            Set(ByVal value As StorageSettingsPresenter)
                _myStorageSettingsPresenter = value
            End Set
        End Property

        Private _myClientConfigPresenter As ClientViewerPresenter
        Private Property __ClientConfigPresenter() As ClientViewerPresenter
            Get
                Return _myClientConfigPresenter
            End Get
            Set(ByVal value As ClientViewerPresenter)
                _myClientConfigPresenter = value
            End Set
        End Property

        Private _myGatewaySettingsPresenter As GatewaySettingsPresenter
        Private Property __GatewaySettingsPresenter() As GatewaySettingsPresenter
            Get
                Return _myGatewaySettingsPresenter
            End Get
            Set(ByVal value As GatewaySettingsPresenter)
                _myGatewaySettingsPresenter = value
            End Set
        End Property

        Private _myGeneralSettingsPresenter As GeneralSettingsPresenter
        Private Property __GeneralSettingsPresenter() As GeneralSettingsPresenter
            Get
                Return _myGeneralSettingsPresenter
            End Get
            Set(ByVal value As GeneralSettingsPresenter)
                _myGeneralSettingsPresenter = value
            End Set
        End Property

        Private _myServerOptionsPresenter As ServerOptionsPresenter
        Private Property __ServerOptionsPresenter() As ServerOptionsPresenter
            Get
                Return _myServerOptionsPresenter
            End Get
            Set(ByVal value As ServerOptionsPresenter)
                _myServerOptionsPresenter = value
            End Set
        End Property

        Private _myServerNetworkingPresenter As ServerNetworkingPresenter
        Private Property __ServerNetworkingPresenter() As ServerNetworkingPresenter
            Get
                Return _myServerNetworkingPresenter
            End Get
            Set(ByVal value As ServerNetworkingPresenter)
                _myServerNetworkingPresenter = value
            End Set
        End Property

        Private _myUserViewPresenter As UserViewPresenter
        Private Property __UserViewPresenter() As UserViewPresenter
            Get
                Return _myUserViewPresenter
            End Get
            Set(ByVal value As UserViewPresenter)
                _myUserViewPresenter = value
            End Set
        End Property


        Private _myRolesViewPresenter As RolesViewPresenter
        Private Property __RolesViewPresenter() As RolesViewPresenter
            Get
                Return _myRolesViewPresenter
            End Get
            Set(ByVal value As RolesViewPresenter)
                _myRolesViewPresenter = value
            End Set
        End Property

        Private _myDatabaseManagerOptionsPresenter As DatabaseManagerOptionsPresenter
        Private Property __DatabaseManagerOptionsPresenter() As DatabaseManagerOptionsPresenter
            Get
                Return _myDatabaseManagerOptionsPresenter
            End Get
            Set(ByVal value As DatabaseManagerOptionsPresenter)
                _myDatabaseManagerOptionsPresenter = value
            End Set
        End Property

        Private private__ClientConfigurationOptionsPresenter As ClientConfigurationOptionsPresenter
        Private Property __ClientConfigurationOptionsPresenter() As ClientConfigurationOptionsPresenter
            Get
                Return private__ClientConfigurationOptionsPresenter
            End Get
            Set(ByVal value As ClientConfigurationOptionsPresenter)
                private__ClientConfigurationOptionsPresenter = value
            End Set
        End Property

#If (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) OrElse (LEADTOOLS_V19_OR_LATER) Then
        Private _myExternalStorePresenter As ExternalStorePresenter
        Private Property __ExternalStorePresenter() As ExternalStorePresenter
            Get
                Return _myExternalStorePresenter
            End Get
            Set(ByVal value As ExternalStorePresenter)
                _myExternalStorePresenter = value
            End Set
        End Property
#End If

#If (LEADTOOLS_V19_OR_LATER_EXPORT) OrElse (LEADTOOLS_V19_OR_LATER) Then
        Private private__AnonymizeOptionsPresenter As AnonymizeOptionsPresenter
        Private Property __AnonymizeOptionsPresenter() As AnonymizeOptionsPresenter
            Get
                Return private__AnonymizeOptionsPresenter
            End Get
            Set(ByVal value As AnonymizeOptionsPresenter)
                private__AnonymizeOptionsPresenter = value
            End Set
        End Property
#End If ' #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

#If LEADTOOLS_V19_OR_LATER Then
        Private private__StorageCommitPresenter As StorageCommitPresenter
        Private Property __StorageCommitPresenter() As StorageCommitPresenter
            Get
                Return private__StorageCommitPresenter
            End Get
            Set(ByVal value As StorageCommitPresenter)
                private__StorageCommitPresenter = value
            End Set
        End Property
#End If

        Private _securityOptionsPresenter As SecurityOptionsPresenter
        Private Property __SecurityOptionsPresenter() As SecurityOptionsPresenter
            Get
                Return _securityOptionsPresenter
            End Get
            Set(ByVal value As SecurityOptionsPresenter)
                _securityOptionsPresenter = value
            End Set
        End Property

        Sub View_CancelChanges(ByVal sender As Object, ByVal e As EventArgs)
            ' These live in Leadtools.Medical.Winforms.dll
            __LoggingConfigPresenter.ResetView()
            __PatientUpdaterPresenter.CancelOptions()
            __AutoCopyPresenter.CancelOptions()
            __ForwardPresenter.CancelOptions()
#If (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) OrElse (LEADTOOLS_V19_OR_LATER) Then
            __ExternalStorePresenter.CancelOptions()
#End If
            __StorageClassesPresenter.ResetSettings()
            __StorageSettingsPresenter.ResetView()

#If (LEADTOOLS_V19_OR_LATER_EXPORT) OrElse (LEADTOOLS_V19_OR_LATER) Then
            __AnonymizeOptionsPresenter.ResetSettings()
#End If ' #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

            If Nothing IsNot __PasswordOptionsPresenter Then
                __PasswordOptionsPresenter.ResetView()
            End If

            ' These live in the EXE
            EventBroker.Instance.PublishEvent(Of CancelServerSettingsEventArgs)(Me, New CancelServerSettingsEventArgs())

            LocalAuditLogQueue.Clear()
            View.CanApply = False
        End Sub

        Private Sub View_ConfirmChanges(ByVal sender As Object, ByVal e As EventArgs)
            ' Code below prevents the "configuration file has been changed by another program' exception
            ' This happens when an addin that the server manager does not know about (i.e. Leadtools.Medical.Rules.Addin) saves its settings into 'advanced.config', which occurs in a different process
            ' When the main process (server manager UI) saves the advanced.config without doing a RefreshSettings first, the exception occurs
            '
            ' To prevent this:
            '    Get a reference to the global copy of 'advanced.config' and refresh from disk (RefreshSettings)
            '    All the presenters (i.e. _PatientUpdaterPresenter) have a reference to this, but it is the same reference
            '    Now copy all settings into the reference to 'advanced.config' and save

            If ServerState.Instance.ServerService IsNot Nothing Then
                Dim settings As AdvancedSettings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory)
                settings.RefreshSettings()
            End If

            ' These live in Leadtools.Medical.Winforms.dll
            __LoggingConfigPresenter.UpdateState()
            __PatientUpdaterPresenter.SaveOptions()
            __AutoCopyPresenter.SaveOptions()
            __ForwardPresenter.SaveOptions()


            If __SecurityOptionsPresenter.IsDirty Then
                __SecurityOptionsPresenter.SaveOptions()
            End If

#If LEADTOOLS_V19_OR_LATER Then
            Dim isStorageCommitDirty As Boolean = __StorageCommitPresenter.IsDirty
            If isStorageCommitDirty Then
                __StorageCommitPresenter.SaveOptions()

                ' This fails if the service is not running
                ' This is not a problem, because once the service starts it will read the options
                Try
                    DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "SendMessage(ExternalStoreMessage.SettingsChanged)")
                    ' ServerState.Instance.ServerService.SendMessage(ExternalStoreMessage.SettingsChanged);
                Catch ex As Exception
                    DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "Exception: SendMessage(ExternalStoreMessage.SettingsChanged)" & ex.Message)
                End Try
            End If
#End If
            Dim isSecurityOptionsDirty As Boolean = __SecurityOptionsPresenter.IsDirty
            If isSecurityOptionsDirty Then
                __SecurityOptionsPresenter.SaveOptions()

                ' This fails if the service is not running
                ' This is not a problem, because once the service starts it will read the options
                Try
                    ' DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "SendMessage(SecurityOptionsMessage.SettingsChanged)");
                    ' ServerState.Instance.ServerService.SendMessage(SecurityOptionsMessage.SettingsChanged);
                Catch ex As Exception
                    '  DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "Exception: SendMessage(SecurityOptionsMessage.SettingsChanged)" + ex.Message);
                End Try
            End If

#If (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) OrElse (LEADTOOLS_V19_OR_LATER) Then
            Dim isExternalStoreDirty As Boolean = __ExternalStorePresenter.IsDirty
            DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "__ExternalStorePresenter.IsDirty : " & isExternalStoreDirty.ToString())
            If isExternalStoreDirty Then
                __ExternalStorePresenter.SaveOptions()

                ' This fails if the service is not running
                ' This is not a problem, because once the service starts it will read the options
                Try
                    DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "SendMessage(ExternalStoreMessage.SettingsChanged)")
                    ServerState.Instance.ServerService.SendMessage(ExternalStoreMessage.SettingsChanged)
                Catch ex As Exception
                    DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "Exception: SendMessage(ExternalStoreMessage.SettingsChanged)" & ex.Message)
                End Try
            End If
#End If ' #if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)

            If __StorageClassesPresenter.IsDirty Then
                Dim configManager As StorageModuleConfigurationManager


                configManager = ServiceLocator.Retrieve(Of StorageModuleConfigurationManager)()

                __StorageClassesPresenter.UpdateSettings()

                If configManager.IsLoaded Then
                    configManager.SetPresentationContextsTimestamp()
                End If
            End If

#If (LEADTOOLS_V19_OR_LATER_EXPORT) OrElse (LEADTOOLS_V19_OR_LATER) Then
            If __AnonymizeOptionsPresenter.IsDirty Then
                Dim configManager As StorageModuleConfigurationManager = ServiceLocator.Retrieve(Of StorageModuleConfigurationManager)()

                __AnonymizeOptionsPresenter.UpdateSettings()
            End If
#End If ' #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

            If Nothing IsNot __StorageSettingsPresenter Then
                If __StorageSettingsPresenter.IsDirty Then
                    __StorageSettingsPresenter.UpdateState()
                    __StorageSettingsPresenter.SaveSettings()
                End If
            End If

            If Nothing IsNot __PasswordOptionsPresenter Then
                __PasswordOptionsPresenter.SaveOptions()
            End If

            If __DatabaseManagerOptionsPresenter.IsDirty Then
                __DatabaseManagerOptionsPresenter.SaveOptions()

                Dim args As New DatabaseManagerOptionsAppliedEventArgs()
                EventBroker.Instance.PublishEvent(Of DatabaseManagerOptionsAppliedEventArgs)(Me, args)
            End If

            If __ClientConfigurationOptionsPresenter.IsDirty Then
                __ClientConfigurationOptionsPresenter.SaveOptions()

                Dim args As New ClientConfigurationOptionsAppliedEventArgs()
                EventBroker.Instance.PublishEvent(Of ClientConfigurationOptionsAppliedEventArgs)(Me, args)
            End If

            ' These live in the EXE
            EventBroker.Instance.PublishEvent(Of ApplyServerSettingsEventArgs)(Me, New ApplyServerSettingsEventArgs())
            EventBroker.Instance.PublishEvent(Of ServerSettingsAppliedEventArgs)(Me, New ServerSettingsAppliedEventArgs())

            LocalAuditLogQueue.FlushLogs(Logger.Global, UserManager.User.Name)

            View.CanApply = False
        End Sub

        Sub OnSettingsChanged(ByVal sender As Object, ByVal e As EventArgs)
            View.CanApply = True
        End Sub
    End Class
End Namespace

