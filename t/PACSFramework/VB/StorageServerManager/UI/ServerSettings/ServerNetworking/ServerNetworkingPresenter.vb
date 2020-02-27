' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Demos.StorageServer.DataTypes
Imports Leadtools.Dicom.AddIn.Common
Imports Leadtools.Medical.Winforms
Imports Leadtools.Demos.StorageServer

Namespace Leadtools.Demos.StorageServer.UI
   Public Class ServerNetworkingPresenter
#Region "Public"

#Region "Methods"

      Public Sub RunView(ByVal viewParam As ServerNetworkingView)
         AddHandler ServerState.Instance.ServerServiceChanged, AddressOf OnConfigureView
         AddHandler ServerState.Instance.ServiceAdminChanged, AddressOf OnConfigureView
         AddHandler ServerState.Instance.IsRemoteServerChanged, AddressOf OnConfigureView

         EventBroker.Instance.Subscribe(Of ApplyServerSettingsEventArgs)(AddressOf OnUpdateServerSettings)
         EventBroker.Instance.Subscribe(Of CancelServerSettingsEventArgs)(AddressOf OnCancelServerSettings)

         View = viewParam

         ConfigureView()

         AddHandler View.SettingsChanged, AddressOf View_SettingsChanged
      End Sub

      Public Sub UpdateSettings()
         If Not ServerState.Instance.ServerService Is Nothing Then
            UpdateServerSettings(ServerState.Instance.ServerService.Settings)

            ServerState.Instance.ServerService.Settings = ServerState.Instance.ServerService.Settings
         End If
      End Sub

#End Region

#Region "Properties"

      Private _view As ServerNetworkingView
      Public Property View() As ServerNetworkingView
         Get
            Return _view
         End Get
         Private Set(ByVal value As ServerNetworkingView)
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

         If Not ServerState.Instance.ServerService Is Nothing Then
            View.IsMaxPduLengthChecked = ServerState.Instance.ServerService.Settings.MaxPduLength <> -1
            If ServerState.Instance.ServerService.Settings.MaxPduLength = -1 Then
               View.MaxPduLength = 0
            Else
               View.MaxPduLength = ServerState.Instance.ServerService.Settings.MaxPduLength
            End If
            View.ReceiveBufferSize = ServerState.Instance.ServerService.Settings.ReceiveBufferSize
            View.SendBufferSize = ServerState.Instance.ServerService.Settings.SendBufferSize
            View.NoDelay = ServerState.Instance.ServerService.Settings.NoDelay
         Else
            View.IsMaxPduLengthChecked = False
            View.MaxPduLength = 0
            View.ReceiveBufferSize = 29696
            View.SendBufferSize = 29696
            View.NoDelay = False
         End If

         __IsDirty = False
      End Sub

      Private Sub UpdateServerSettings(ByVal serverSettings As ServerSettings)
         If View.IsMaxPduLengthChecked Then
            serverSettings.MaxPduLength = View.MaxPduLength
         Else
            serverSettings.MaxPduLength = -1
         End If
         serverSettings.ReceiveBufferSize = View.ReceiveBufferSize
         serverSettings.SendBufferSize = View.SendBufferSize
         serverSettings.NoDelay = View.NoDelay
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

      Sub OnConfigureView(ByVal sender As Object, ByVal e As EventArgs)
         ConfigureView()
      End Sub

      Public Event SettingsChanged As EventHandler

      Sub View_SettingsChanged(ByVal sender As Object, ByVal e As EventArgs)
         Try
            __IsDirty = True
            RaiseEvent SettingsChanged(sender, e)
         Catch e1 As Exception
            System.Diagnostics.Debug.Assert(False)
         End Try
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
