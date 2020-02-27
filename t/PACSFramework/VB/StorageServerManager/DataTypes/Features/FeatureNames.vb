' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Leadtools.Demos.StorageServer.DataTypes
   Public Class FeatureNames
      Public Sub New(ByVal _name As String, ByVal _displayName As String)
         Name = _name
         DisplayName = _displayName
      End Sub

      Shared Sub New()
         DisplaySettingsFeature = New FeatureNames("DisplaySettingsDlg", "Settings")
         ServerParentFeature = New FeatureNames("DICOMServer", "DICOM Server")
         ServerSettings = New FeatureNames("ServerGeneralSettings", "Settings")
         ServerOptions = New FeatureNames("ServerOptions", "Options")
         ServerNetworking = New FeatureNames("ServerNetworking", "Networking")
         LoggingConfig = New FeatureNames("LoggingConfiguration", "Logging Configuration")
         ClientConfig = New FeatureNames("ClientConfiguration", "Client Configuration")
         ServerFiles = New FeatureNames("Files", "Files")
         AdministrationParentFeature = New FeatureNames("Administration", "Administration")
         PasswordOptions = New FeatureNames("PasswordOptions", "Password Options")
         Users = New FeatureNames("Users", "Users")
         PatientUpdater = New FeatureNames("PatientUpdater", "Patient Updater")
         AutoCopy = New FeatureNames("AutoCopy", "Auto Copy")
         StoreSettingsParentFeature = New FeatureNames("StoreSettings", "Storage Settings")
         IodClasses = New FeatureNames("IodClasses", "IOD Classes")
         StoreSettings = New FeatureNames("StoreSettings", "Store Settings")
         QuerySettings = New FeatureNames("QuerySettings", "Query Settings")
         Forwarder = New FeatureNames("Forwarder", "Forwarding")
         Gateway = New FeatureNames("Gateway", "Gateway")
         Roles = New FeatureNames("Roles", "Roles")
         DatabaseManagerOptions = New FeatureNames("DatabaseManagerOptions", "Database Manager Options")
         ClientConfigurationOptions = New FeatureNames("ClientConfigurationOptions", "Client Configuration Options")
#If (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) OrElse (LEADTOOLS_V19_OR_LATER) Then
            ExternalStore = New FeatureNames("ExternalStore", "External Store")
#End If
#If (LEADTOOLS_V19_OR_LATER_EXPORT) OrElse (LEADTOOLS_V19_OR_LATER) Then
         AnonymizeOptions = New FeatureNames("AnonymizeOptions", "Anonymize Options")
#End If ' #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

#If (LEADTOOLS_V19_OR_LATER) Then
         StorageCommit = New FeatureNames("StorageCommit", "Storage Commit Settings")
#End If
            SecurityOptions = New FeatureNames("DICOM Security", "DICOM Security Options")
        End Sub

      Private _name As String
      Public Property Name() As String
         Get
            Return _name
         End Get
         Private Set(ByVal value As String)
            _name = value
         End Set
      End Property

      Private _displayName As String
      Public Property DisplayName() As String
         Get
            Return _displayName
         End Get
         Private Set(ByVal value As String)
            _displayName = value
         End Set
      End Property

      Private Shared _displaySettingsFeature As FeatureNames
      Public Shared Property DisplaySettingsFeature() As FeatureNames
         Get
            Return _displaySettingsFeature
         End Get
         Private Set(ByVal value As FeatureNames)
            _displaySettingsFeature = value
         End Set
      End Property

      Private Shared _serverParentFeature As FeatureNames
      Public Shared Property ServerParentFeature() As FeatureNames
         Get
            Return _serverParentFeature
         End Get
         Private Set(ByVal value As FeatureNames)
            _serverParentFeature = value
         End Set
      End Property

      Private Shared _serverSettings As FeatureNames
      Public Shared Property ServerSettings() As FeatureNames
         Get
            Return _serverSettings
         End Get
         Private Set(ByVal value As FeatureNames)
            _serverSettings = value
         End Set
      End Property

      Private Shared _serverOptions As FeatureNames
      Public Shared Property ServerOptions() As FeatureNames
         Get
            Return _serverOptions
         End Get
         Private Set(ByVal value As FeatureNames)
            _serverOptions = value
         End Set
      End Property

      Private Shared _serverNetworking As FeatureNames
      Public Shared Property ServerNetworking() As FeatureNames
         Get
            Return _serverNetworking
         End Get
         Private Set(ByVal value As FeatureNames)
            _serverNetworking = value
         End Set
      End Property

      Private Shared _loggingConfig As FeatureNames
      Public Shared Property LoggingConfig() As FeatureNames
         Get
            Return _loggingConfig
         End Get
         Private Set(ByVal value As FeatureNames)
            _loggingConfig = value
         End Set
      End Property

      Private Shared _clientConfig As FeatureNames
      Public Shared Property ClientConfig() As FeatureNames
         Get
            Return _clientConfig
         End Get
         Private Set(ByVal value As FeatureNames)
            _clientConfig = value
         End Set
      End Property

      Private Shared _serverFiles As FeatureNames
      Public Shared Property ServerFiles() As FeatureNames
         Get
            Return _serverFiles
         End Get
         Private Set(ByVal value As FeatureNames)
            _serverFiles = value
         End Set
      End Property

      Private Shared _administrationParentFeature As FeatureNames
      Public Shared Property AdministrationParentFeature() As FeatureNames
         Get
            Return _administrationParentFeature
         End Get
         Private Set(ByVal value As FeatureNames)
            _administrationParentFeature = value
         End Set
      End Property

      Private Shared _passwordOptions As FeatureNames
      Public Shared Property PasswordOptions() As FeatureNames
         Get
            Return _passwordOptions
         End Get
         Private Set(ByVal value As FeatureNames)
            _passwordOptions = value
         End Set
      End Property

      Private Shared _users As FeatureNames
      Public Shared Property Users() As FeatureNames
         Get
            Return _users
         End Get
         Private Set(ByVal value As FeatureNames)
            _users = value
         End Set
      End Property

      Private Shared _patientUpdater As FeatureNames
      Public Shared Property PatientUpdater() As FeatureNames
         Get
            Return _patientUpdater
         End Get
         Private Set(ByVal value As FeatureNames)
            _patientUpdater = value
         End Set
      End Property

      Private Shared _autoCopy As FeatureNames
      Public Shared Property AutoCopy() As FeatureNames
         Get
            Return _autoCopy
         End Get
         Private Set(ByVal value As FeatureNames)
            _autoCopy = value
         End Set
      End Property

      Private Shared _storeSettingsParentFeature As FeatureNames
      Public Shared Property StoreSettingsParentFeature() As FeatureNames
         Get
            Return _storeSettingsParentFeature
         End Get
         Private Set(ByVal value As FeatureNames)
            _storeSettingsParentFeature = value
         End Set
      End Property

      Private Shared _iodClasses As FeatureNames
      Public Shared Property IodClasses() As FeatureNames
         Get
            Return _iodClasses
         End Get
         Private Set(ByVal value As FeatureNames)
            _iodClasses = value
         End Set
      End Property

      Private Shared _storeSettings As FeatureNames
      Public Shared Property StoreSettings() As FeatureNames
         Get
            Return _storeSettings
         End Get
         Private Set(ByVal value As FeatureNames)
            _storeSettings = value
         End Set
      End Property

      Private Shared _querySettings As FeatureNames
      Public Shared Property QuerySettings() As FeatureNames
         Get
            Return _querySettings
         End Get
         Private Set(ByVal value As FeatureNames)
            _querySettings = value
         End Set
      End Property

      Private Shared _forwarder As FeatureNames
      Public Shared Property Forwarder() As FeatureNames
         Get
            Return _forwarder
         End Get
         Private Set(ByVal value As FeatureNames)
            _forwarder = value
         End Set
      End Property

      Private Shared _gateway As FeatureNames
      Public Shared Property Gateway() As FeatureNames
         Get
            Return _gateway
         End Get
         Private Set(ByVal value As FeatureNames)
            _gateway = value
         End Set
      End Property

      Private Shared _roles As FeatureNames
      Public Shared Property Roles() As FeatureNames
         Get
            Return _roles
         End Get
         Private Set(ByVal value As FeatureNames)
            _roles = value
         End Set
      End Property

      Private Shared _databaseManagerOptions As FeatureNames
        Public Shared Property DatabaseManagerOptions() As FeatureNames
            Get
                Return _databaseManagerOptions
            End Get
            Private Set(ByVal value As FeatureNames)
                _databaseManagerOptions = value
            End Set
        End Property

        Private Shared _clientConfigurationOptions As FeatureNames
        Public Shared Property ClientConfigurationOptions() As FeatureNames
            Get
                Return _clientConfigurationOptions
            End Get
            Private Set(ByVal value As FeatureNames)
                _clientConfigurationOptions = value
            End Set
        End Property

#If (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) OrElse (LEADTOOLS_V19_OR_LATER) Then
        Private Shared _externalStore As FeatureNames
      Public Shared Property ExternalStore() As FeatureNames
         Get
            Return _externalStore
         End Get
         Private Set(ByVal value As FeatureNames)
            _externalStore = value
         End Set
      End Property
#End If

#If (LEADTOOLS_V19_OR_LATER_EXPORT) OrElse (LEADTOOLS_V19_OR_LATER) Then
      Private Shared _anonymizeOptions As FeatureNames
      Public Shared Property AnonymizeOptions() As FeatureNames
         Get
            Return _anonymizeOptions
         End Get
         Private Set(ByVal value As FeatureNames)
            _anonymizeOptions = value
         End Set
      End Property
#End If ' #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

#If (LEADTOOLS_V19_OR_LATER) Then
      Private Shared _storageCommit As FeatureNames
      Public Shared Property StorageCommit() As FeatureNames
         Get
            Return _storageCommit
         End Get
         Private Set(ByVal value As FeatureNames)
            _storageCommit = value
         End Set
      End Property
#End If

        Private Shared _securityOptions As FeatureNames
        Public Shared Property SecurityOptions() As FeatureNames
            Get
                Return _securityOptions
            End Get
            Private Set(ByVal value As FeatureNames)
                _securityOptions = value
            End Set
        End Property
    End Class
End Namespace

