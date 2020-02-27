' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Dicom.Server.Admin
Imports Leadtools.Medical.Winforms
Imports Leadtools.Medical.AeManagement.DataAccessLayer
Imports Leadtools.Medical.Storage.AddIns.Configuration
Imports Leadtools.Medical.Gateway.CFindAddin.DataTypes
Imports Leadtools.Dicom.AddIn.Interfaces
Imports Leadtools.DicomDemos

Namespace Leadtools.Demos.StorageServer
   Public Class ServerState
      Private Sub New()
      End Sub

      Shared Sub New()
         _instance = New ServerState()
      End Sub

      Public Shared ReadOnly Property Instance() As ServerState
         Get
            Return _instance
         End Get
      End Property

      Public Property ServerService() As DicomService
         Get
            Return _serverService
         End Get

         Set(ByVal value As DicomService)
            If Not Value Is _serverService Then
               _serverService = Value

               OnServerServiceChanged()
            End If
         End Set
      End Property

      Public Property ServiceAdmin() As ServiceAdministrator
         Get
            Return _serviceAdmin
         End Get

         Set(ByVal value As ServiceAdministrator)
            If Not Value Is _serviceAdmin Then
               _serviceAdmin = Value

               OnServiceAdminChanged()
            End If
         End Set
      End Property

      Public Property BaseDirectory() As String
         Get
            Return _baseDirectory
         End Get

         Set(ByVal value As String)
            If Value <> _baseDirectory Then
               _baseDirectory = Value

               OnBaseDirectoryChanged()
            End If
         End Set
      End Property

      Public Property ServiceName() As String
         Get
            Return _serviceName
         End Get

         Set(ByVal value As String)
            If Value <> _serviceName Then
               _serviceName = Value

               OnServiceNameChanged()
            End If
         End Set
      End Property

      Public Property LoggingState() As LoggingState
         Get
            Return _loggingState
         End Get

         Set(ByVal value As LoggingState)
            If Not _loggingState Is Value Then
               _loggingState = Value

               OnLoggingStateChanged()
            End If
         End Set
      End Property

      Public Property IsRemoteServer() As Boolean
         Get
            Return _isRemoteServer
         End Get

         Set(ByVal value As Boolean)
            If Value <> _isRemoteServer Then
               _isRemoteServer = Value

               OnIsRemoteServerChanged()
            End If
         End Set
      End Property

      Private _clientList As ClientInformationList
      Public Property ClientList() As ClientInformationList
         Get
            Return _clientList
         End Get
         Set(ByVal value As ClientInformationList)
            _clientList = value
         End Set
      End Property

      Public Property RemoteServerInformation() As StorageServerInformation
         Get
            Return _remoteServerInformation
         End Get

         Set(ByVal value As StorageServerInformation)
            If Not Value Is _remoteServerInformation Then
               _remoteServerInformation = Value

               OnRemoteServerInformationChanged()
            End If
         End Set
      End Property

      Private _License As ILicense

      Public Property License() As ILicense
         Get
            Return _License
         End Get

         Set(ByVal value As ILicense)
            If Not _License Is value Then
               _License = value
               OnLicenseChanged()
            End If
         End Set
      End Property

      Private _gatewayServers As List(Of String)
      Public Property GatewayServers() As List(Of String)
         Get
            Return _gatewayServers
         End Get
         Set(ByVal value As List(Of String))
            _gatewayServers = value
         End Set
      End Property

      Private Sub OnServiceNameChanged()
         If Not Nothing Is ServiceNameChangedEvent Then
            RaiseEvent ServiceNameChanged(Me, EventArgs.Empty)
         End If
      End Sub

      Private Sub OnLoggingStateChanged()
         If Not LoggingStateChangedEvent Is Nothing Then
            RaiseEvent LoggingStateChanged(Me, EventArgs.Empty)
         End If
      End Sub

      Private Sub OnServiceAdminChanged()
         If Not Nothing Is ServiceAdminChangedEvent Then
            RaiseEvent ServiceAdminChanged(Me, EventArgs.Empty)
         End If
      End Sub

      Private Sub OnBaseDirectoryChanged()
         If Not Nothing Is BaseDirectoryChangedEvent Then
            RaiseEvent BaseDirectoryChanged(Me, EventArgs.Empty)
         End If
      End Sub

      Private Sub OnIsRemoteServerChanged()
         If Not Nothing Is IsRemoteServerChangedEvent Then
            RaiseEvent IsRemoteServerChanged(Me, EventArgs.Empty)
         End If
      End Sub

      Private Sub OnRemoteServerInformationChanged()
         If Not Nothing Is RemoteServerInformationChangedEvent Then
            RaiseEvent RemoteServerInformationChanged(Me, EventArgs.Empty)
         End If
      End Sub

      Public Sub OnLicenseChanged()
         If Not LicenseChangedEvent Is Nothing Then
            RaiseEvent LicenseChanged(Me, EventArgs.Empty)
         End If
      End Sub

      Public Event ServerServiceChanged As EventHandler
      Public Event ServiceAdminChanged As EventHandler
      Public Event BaseDirectoryChanged As EventHandler
      Public Event ServiceNameChanged As EventHandler
      Public Event IsRemoteServerChanged As EventHandler
      Public Event RemoteServerInformationChanged As EventHandler
      Public Event LicenseChanged As EventHandler
      Public Event LoggingStateChanged As EventHandler

      Private Sub OnServerServiceChanged()
         If Not Nothing Is ServerServiceChangedEvent Then
            RaiseEvent ServerServiceChanged(Me, EventArgs.Empty)
         End If
      End Sub

      Private Shared _instance As ServerState
      Private _serverService As DicomService
      Private _serviceAdmin As ServiceAdministrator
      Private _baseDirectory As String
      Private _serviceName As String
      Private _isRemoteServer As Boolean
      Private _remoteServerInformation As StorageServerInformation
      Private _loggingState As LoggingState
   End Class
End Namespace
