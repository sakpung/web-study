' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Demos.StorageServer.DataTypes
Imports Leadtools.Medical.Winforms
Imports Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
Imports Leadtools.Dicom.AddIn.Interfaces

Namespace Leadtools.Demos.StorageServer.UI
   Friend Class ControlPanelPresenter

      Dim serverSettingsItem As PanelItem = New PanelItem()
      Dim storeSettings As PanelItem = New PanelItem()
      Dim administration As PanelItem = New PanelItem()
      Dim patientUpdater As PanelItem = New PanelItem()
      Dim autoCopy As PanelItem = New PanelItem()
      Dim LoggingConfig As PanelItem = New PanelItem()
      Dim forwarding As PanelItem = New PanelItem()
      Dim gateway As PanelItem = New PanelItem()

#If (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) OrElse (LEADTOOLS_V19_OR_LATER) Then
      Dim externalStore As New PanelItem()
#End If
        Dim securityOptions As New PanelItem()

        Public Sub RunView(ByVal view As ControlPanelView)
         __View = view

         ConfigureView()

         AddHandler ServerState.Instance.ServerServiceChanged, AddressOf Instance_ServerServiceChanged
         AddHandler ServerState.Instance.LicenseChanged, AddressOf Instance_LicenseChanged
         AddHandler __View.ItemClicked, AddressOf __View_ItemClicked
      End Sub

      Private Sub Instance_LicenseChanged(ByVal sender As Object, ByVal e As EventArgs)
         '__View.EnableItem(HasFeature(ServerFeatures.Forwarding),forwarding);
         '__View.EnableItem(HasFeature(ServerFeatures.Gateway),gateway);

         'bool isExpired = IsLicenseExpired();
         '__View.EnableItem(isExpired, serverSettingsItem);
         '__View.EnableItem(isExpired, storeSettings);
         '__View.EnableItem(isExpired, administration);
         '__View.EnableItem(isExpired, patientUpdater);
         '__View.EnableItem(isExpired, autoCopy);
         '__View.EnableItem(isExpired, LoggingConfig);

         UpdateUI()
      End Sub

      Private Function IsLicenseValid() As Boolean
         Dim license As ILicense = ServerState.Instance.License
         If license Is Nothing OrElse license.Features.Count = 0 Then
            Return False
         End If

         If license.IsFeatureExpired(ServerFeatures.GeneralFunctionality) Then
            Return False
         End If

         Return True
      End Function

      Private Function HasFeature(ByVal featureId As String) As Boolean
         Dim license As ILicense = ServerState.Instance.License

         If (Not IsLicenseValid()) Then
            Return False
         End If

         If (Not license.IsFeatureValid(featureId)) Then
            Return False
         End If

         Dim feature As IFeature = license.GetFeature(featureId)
         If feature IsNot Nothing Then
            If feature.Type = LicenseFeatureType.Off Then
               Return False
            End If
         End If

         If license.IsFeatureEvaluation(featureId) AndAlso license.IsFeatureExpired(featureId) Then
            Return False
         End If

         Return True
      End Function

      Private Sub UpdateUI()
         Dim exists As Boolean = ServerState.Instance.ServerService IsNot Nothing
         Dim isAdmin As Boolean = UserManager.User.IsAdmin()
         Dim license As ILicense = ServerState.Instance.License
         Dim isLicenseValid As Boolean = Me.IsLicenseValid()

         Dim canChangeServerSettings As Boolean = UserManager.User.IsAuthorized(UserPermissions.CanChangeServerSettings)

         serverSettingsItem.Enabled = (isAdmin OrElse canChangeServerSettings) ' always show this one
         storeSettings.Enabled = isLicenseValid AndAlso (exists AndAlso (isAdmin OrElse canChangeServerSettings))
         administration.Enabled = isLicenseValid AndAlso (isAdmin)
         patientUpdater.Enabled = isLicenseValid AndAlso (exists AndAlso (isAdmin OrElse canChangeServerSettings))
         autoCopy.Enabled = isLicenseValid AndAlso (exists AndAlso (isAdmin OrElse canChangeServerSettings))
         LoggingConfig.Enabled = isLicenseValid AndAlso (exists AndAlso (isAdmin OrElse canChangeServerSettings))
         forwarding.Enabled = isLicenseValid AndAlso (exists AndAlso (isAdmin OrElse canChangeServerSettings) AndAlso HasFeature(ServerFeatures.Forwarding))
         gateway.Enabled = isLicenseValid AndAlso (exists AndAlso (isAdmin OrElse canChangeServerSettings) AndAlso HasFeature(ServerFeatures.Gateway))
#If (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) OrElse (LEADTOOLS_V19_OR_LATER) Then
         ExternalStore.Enabled = isLicenseValid AndAlso (exists AndAlso (isAdmin OrElse canChangeServerSettings) AndAlso HasFeature(ServerFeatures.ExternalStore))
#End If
            securityOptions.Enabled = isLicenseValid AndAlso (exists AndAlso (isAdmin OrElse canChangeServerSettings))

            __View.EnableItem(serverSettingsItem.Enabled, serverSettingsItem)
         __View.EnableItem(storeSettings.Enabled, storeSettings)
         __View.EnableItem(administration.Enabled, administration)
         __View.EnableItem(serverSettingsItem.Enabled, serverSettingsItem)
         __View.EnableItem(patientUpdater.Enabled, patientUpdater)
         __View.EnableItem(autoCopy.Enabled, autoCopy)
         __View.EnableItem(LoggingConfig.Enabled, LoggingConfig)
         __View.EnableItem(forwarding.Enabled, forwarding)
         __View.EnableItem(gateway.Enabled, gateway)

#If (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) OrElse (LEADTOOLS_V19_OR_LATER) Then
         __View.EnableItem(ExternalStore.Enabled, ExternalStore)
#End If
            __View.EnableItem(securityOptions.Enabled, securityOptions)
        End Sub

	  Private Sub ConfigureView()
         Dim exists As Boolean = ServerState.Instance.ServerService IsNot Nothing
         Dim isAdmin As Boolean = UserManager.User.IsAdmin()
         Dim license As ILicense = ServerState.Instance.License

         Dim canChangeServerSettings As Boolean = UserManager.User.IsAuthorized(UserPermissions.CanChangeServerSettings)

         serverSettingsItem.Feature = FeatureNames.ServerParentFeature
         serverSettingsItem.Text = FeatureNames.ServerParentFeature.DisplayName
         serverSettingsItem.Image = My.Resources.server
         serverSettingsItem.ToolTip = ItemsToolTips.DICOMServer

         storeSettings.Feature = FeatureNames.StoreSettingsParentFeature
         storeSettings.Text = FeatureNames.StoreSettingsParentFeature.DisplayName
         storeSettings.Image = If((exists), My.Resources.storage_setting, My.Resources.Warning_32)
         storeSettings.ToolTip = ItemsToolTips.StorageSettings

         administration.Feature = FeatureNames.AdministrationParentFeature
         administration.Text = FeatureNames.AdministrationParentFeature.DisplayName
         administration.Image = My.Resources.administration
         administration.ToolTip = ItemsToolTips.Administration

         patientUpdater.Feature = FeatureNames.PatientUpdater
         patientUpdater.Text = FeatureNames.PatientUpdater.DisplayName
         patientUpdater.Image = If((exists), My.Resources.patient_updater, My.Resources.Warning_32)
         patientUpdater.ToolTip = ItemsToolTips.PatientUpdater

         autoCopy.Feature = FeatureNames.AutoCopy
         autoCopy.Text = FeatureNames.AutoCopy.DisplayName
         autoCopy.Image = My.Resources.autocopy
         autoCopy.ToolTip = ItemsToolTips.AutoCopy

         LoggingConfig.Feature = FeatureNames.LoggingConfig
         LoggingConfig.Text = FeatureNames.LoggingConfig.DisplayName
         LoggingConfig.Image = My.Resources.login_config
         LoggingConfig.ToolTip = ItemsToolTips.LoggingConfig


         forwarding.Feature = FeatureNames.Forwarder
         forwarding.Text = FeatureNames.Forwarder.DisplayName
         forwarding.Image = My.Resources.patient_forwarding
         forwarding.ToolTip = ItemsToolTips.Forwarding

         gateway.Feature = FeatureNames.Gateway
         gateway.Text = FeatureNames.Gateway.DisplayName
         gateway.Image = My.Resources.gateway
         gateway.ToolTip = ItemsToolTips.Gateway

#If (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) OrElse (LEADTOOLS_V19_OR_LATER) Then
         externalStore.Feature = FeatureNames.ExternalStore
         externalStore.Text = FeatureNames.ExternalStore.DisplayName
         externalStore.Image = My.Resources.externalStore
         externalStore.ToolTip = ItemsToolTips.ExternalStore
#End If

            securityOptions.Feature = FeatureNames.SecurityOptions
            securityOptions.Text = FeatureNames.SecurityOptions.Name
            securityOptions.Image = My.Resources.Lock_Icon_32
            securityOptions.ToolTip = ItemsToolTips.SecurityOptions

            UpdateUI()

         __View.SetItem(serverSettingsItem)
         __View.SetItem(storeSettings)
         __View.SetItem(administration)
         __View.SetItem(patientUpdater)
         __View.SetItem(autoCopy)
         __View.SetItem(LoggingConfig)
         __View.SetItem(forwarding)
         __View.SetItem(gateway)

#If (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) OrElse (LEADTOOLS_V19_OR_LATER) Then
         __View.SetItem(externalStore)
#End If

            __View.SetItem(securityOptions)

            __View.Notes = Shell.storageServerNotes
      End Sub

      Private Sub Instance_ServerServiceChanged(ByVal sender As Object, ByVal e As EventArgs)
         __View.ClearItems()

         ConfigureView()
      End Sub

      Private Sub __View_ItemClicked(ByVal sender As Object, ByVal e As DisplayFeatureEventArgs)
         EventBroker.Instance.PublishEvent(Of DisplayFeatureEventArgs)(Me, e)
      End Sub

      Private _myView As ControlPanelView
      Private Property __View() As ControlPanelView
         Get
            Return _myView
         End Get
         Set(ByVal value As ControlPanelView)
            _myView = value
         End Set
      End Property

      Public MustInherit Class ItemsToolTips
         Public Const Gateway As String = "The gateway feature allows DICOM servers to be created that act as a proxy to communicate with other DICOM servers on the client’s behalf. This allows clients to send query/retrieve requests only to the gateway server, and those requests are then automatically relayed to any number of additional PACS servers." & ControlChars.CrLf & ControlChars.CrLf & "The Gateway can forward C-FIND and C-MOVE DICOM messages. The requests will be forwarded to the specified remote DICOM servers and the responses will be forwarded back from the gateway to the requested clients. " & ControlChars.CrLf & ControlChars.CrLf & "Moved images from remote servers will be stored into the local main storage server database." & ControlChars.CrLf & ControlChars.CrLf & "Multiple remote servers can specified for each gateway. If one remote server fails to respond, then the next remote server in the list will be used. This continues until one server responds before sending a failure message to the requested client."

         Public Const LoggingConfig As String = "The logging configuration allows the server to be configured to control how logging is performed. " & ControlChars.CrLf & ControlChars.CrLf & "It provides extensive log filtering options including whether to log the DICOM datasets and where to save them." & ControlChars.CrLf & ControlChars.CrLf & "It also provides an Auto Save feature that dumps the log to text files along with the DICOM datasets at a configurable specific time. The server can optionally be configured to delete the logs from the database after they are saved. " & ControlChars.CrLf & "This feature reduces the amount of logs that accumulate in the database, which helps maintain server performance."

         Public Const DICOMServer As String = "The DICOM server settings allow you to create, delete and configure the DICOM Server information such as AE Title, listening IP Address and port number." & ControlChars.CrLf & ControlChars.CrLf & "Other settings include specifying the clients that are allowed to communicate with the DICOM Server, assigning client permissions, restricting the client count, allow anonymous connections, and a time-out period for idle clients."

         Public Const StorageSettings As String = "The storage settings expose a rich set of options that allow complete customization of the storage behavior. Available options include DICOM storage location and file extension, storage folder structure, automatic backup of overwritten stored files, automatic backup of deleted files, and ability to save C-Store and Import failures. " & ControlChars.CrLf & ControlChars.CrLf & "Other settings allow you to prevent/allow storing duplicate instances, options to allow automatic update of patient, study, series, and instance information, and the ability to automatically create one or more thumbnails per stored image. " & ControlChars.CrLf & ControlChars.CrLf & "Query settings allow you to validate client request datasets, and customize the storage server response datasets. The storage server can also be configured to accept specific and user-defined storage classes."

         Public Const Forwarding As String = "The forwarding feature allows the storage server to be configured so that stored DICOM images can be automatically archived/stored to another PACS server immediately, or on any schedule. " & ControlChars.CrLf & ControlChars.CrLf & "The schedule can be customized to forward all images in any date range, and can be setup to automatically repeat the forwarding every specified time period. " & ControlChars.CrLf & ControlChars.CrLf & "Once images have been forwarded, they can optionally be automatically removed from the database after a specified hold time so that the storage server keeps only the most recent data online. " & ControlChars.CrLf & ControlChars.CrLf & "Advanced features allow you to forward the same images to different servers, and connect to a PACS using a custom AE title."

         Public Const ExternalStore As String = "The external store feature allows the storage server to optionally store DICOM datasets to an external store (i.e. a cloud storage)."

         Public Const Administration As String = "The administration features are available only to administrators. Features include ability to manage users and permissions. Permissions for users include admin, patient updater admin, patient updater edit and delete. " & ControlChars.CrLf & ControlChars.CrLf & "Other permissions include modify, delete and remove all images from the server. Password complexity and password expiration can be specified, as well as an optional idle-timeout for logged-in users."

         Public Const AutoCopy As String = "The auto copy feature allows the storage server to be configured to automatically route moved DICOM image data to any number of PACS servers. " & ControlChars.CrLf & ControlChars.CrLf & "This feature can be set up so that when the server receives a C-MOVE request to a destination AE it will automatically store it to some other server as well." & ControlChars.CrLf & ControlChars.CrLf & "When the storage server to connects to the remote PACS servers, it can be configured to optionally use a custom AE title. " & ControlChars.CrLf & ControlChars.CrLf & "For performance, the auto copy processing can be performed in a user-specified number of different threads."

         Public Const PatientUpdater As String = "The patient updater feature allows DICOM clients to send a custom N-Action message to the storage server to seamlessly modify existing patient and study information. " & ControlChars.CrLf & "This feature includes a patient updater client SCU, and a storage server patient updater add-in. " & ControlChars.CrLf & ControlChars.CrLf & "This feature is useful for updating incorrectly entered information. " & ControlChars.CrLf & "Support includes the ability to copy patients and studies, delete patients and series, move a study to either an existing or a new patient, and merge studies with a new or existing patient. " & ControlChars.CrLf & ControlChars.CrLf & "Additionally, the storage server can be configured to automatically send the update command to a central PACS server to synchronize changes."

         Public Const SecurityOptions As String = "The security options feature allows the storage server to optionally configure DICOM Communications to use Transport Layer Security Protocol."
        End Class
   End Class
End Namespace
