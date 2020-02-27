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
Imports Leadtools.Medical.Gateway.CFindAddin.DataTypes
Imports Leadtools.Dicom.Server.Admin
Imports System.ServiceProcess
Imports System.Threading

Namespace Leadtools.Demos.StorageServer.UI
   Friend Class GatewayServerControlPresenter
      Public Sub New()
         _syncContext = WindowsFormsSynchronizationContext.Current
      End Sub
      Public Sub RunView(ByVal view As ItemsGridView, ByVal gatewaySource As BindingSource)
         _serverControlStrip = New ServerControlToolStrip()
         _gatewaySource = gatewaySource
         _view = view
         view.MainToolStrip.Items.Add(New ToolStripSeparator())

         ToolStripManager.Merge(_serverControlStrip, view.MainToolStrip)

         UpdateUI()

         AddHandler _view.SelectedItemChanged, AddressOf _view_SelectedItemChanged

         AddHandler _serverControlStrip.StartServer, AddressOf _serverControlStrip_StartServer
         AddHandler _serverControlStrip.StopServer, AddressOf _serverControlStrip_StopServer
         AddHandler _serverControlStrip.StartAllServers, AddressOf _serverControlStrip_StartAllServers
         AddHandler _serverControlStrip.StopAllServers, AddressOf _serverControlStrip_StopAllServers
      End Sub

      Public Sub Reconfigure(ByVal gatewaySource As BindingSource)
         _gatewaySource = gatewaySource

         UpdateUI()
      End Sub

      Private Sub _view_SelectedItemChanged(ByVal sender As Object, ByVal e As EventArgs)
         UpdateUI()
      End Sub

      Private Sub MySendOrPostCallback(ByVal state As Object)
         _serverControlStrip.CanStart = _serverControlStrip.CanStop = (Not _view.SelectedRow Is Nothing) AndAlso Not ServerState.Instance.ServiceAdmin Is Nothing
         _serverControlStrip.CanStartAll = _serverControlStrip.CanStopAll = (_gatewaySource.Count > 0) AndAlso Not ServerState.Instance.ServiceAdmin Is Nothing

         If Not Nothing Is _view.SelectedRow AndAlso Not _gatewaySource.Current Is Nothing Then
            Dim server As GatewayServer = CType((CType((CType(_gatewaySource.Current, DataRowView)).Row, Gateways.GatewayServerRow)).GatewayServer, GatewayServer)

            If Not Nothing Is ServerState.Instance.ServiceAdmin AndAlso ServerState.Instance.ServiceAdmin.Services.ContainsKey(server.ServiceName) Then
               Dim service As DicomService = ServerState.Instance.ServiceAdmin.Services(server.ServiceName)


               _serverControlStrip.CanStart = service.Status <> ServiceControllerStatus.Running
               _serverControlStrip.CanStop = service.Status <> ServiceControllerStatus.Stopped
            End If
         End If
      End Sub

      Public Sub UpdateUI()
         _syncContext.Send(AddressOf MySendOrPostCallback, Nothing)
      End Sub

      Private Function GetCurrentDicomService() As DicomService
         Dim gatewayService As DicomService = Nothing

         If Not _gatewaySource.Current Is Nothing Then
            Dim gatewayRow As Gateways.GatewayServerRow = CType((CType(_gatewaySource.Current, DataRowView)).Row, Gateways.GatewayServerRow)

            gatewayService = GetGatewayService(gatewayRow)
         End If

         Return gatewayService
      End Function

      Private Shared Function GetGatewayService(ByVal gatewayRow As Gateways.GatewayServerRow) As DicomService
         Dim gatewayService As DicomService = Nothing
         Dim gatewayServer As GatewayServer = CType(gatewayRow.GatewayServer, GatewayServer)

         If ServerState.Instance.ServiceAdmin.Services.ContainsKey(gatewayServer.ServiceName) Then
            gatewayService = ServerState.Instance.ServiceAdmin.Services(gatewayServer.ServiceName)
         End If

         Return gatewayService
      End Function

      Private Sub _serverControlStrip_StartServer(ByVal sender As Object, ByVal e As EventArgs)
         Dim gatewayService As DicomService = Nothing

         gatewayService = GetCurrentDicomService()

         If Not gatewayService Is Nothing Then
            If gatewayService.Status <> ServiceControllerStatus.Running Then
               gatewayService.Start()
            End If
         End If
      End Sub

      Private Sub _serverControlStrip_StopServer(ByVal sender As Object, ByVal e As EventArgs)
         Dim gatewayService As DicomService = Nothing

         gatewayService = GetCurrentDicomService()

         If Not gatewayService Is Nothing Then
            If gatewayService.Status <> ServiceControllerStatus.Stopped Then
               gatewayService.Stop()
            End If
         End If
      End Sub

      Private Sub _serverControlStrip_StartAllServers(ByVal sender As Object, ByVal e As EventArgs)
         Dim gateways As Gateways = CType(_gatewaySource.DataSource, Gateways)

         For Each gateway As Gateways.GatewayServerRow In gateways.GatewayServer
            Dim service As DicomService = GetGatewayService(gateway)

            If Not Nothing Is service AndAlso service.Status <> ServiceControllerStatus.Running Then
               service.Start()
            End If
         Next gateway
      End Sub

      Private Sub _serverControlStrip_StopAllServers(ByVal sender As Object, ByVal e As EventArgs)
         Dim gateways As Gateways = CType(_gatewaySource.DataSource, Gateways)

         For Each gateway As Gateways.GatewayServerRow In gateways.GatewayServer
            Dim service As DicomService = GetGatewayService(gateway)

            If Not Nothing Is service AndAlso service.Status <> ServiceControllerStatus.Stopped Then
               service.Stop()
            End If
         Next gateway
      End Sub

      Private _serverControlStrip As ServerControlToolStrip
      Private _gatewaySource As BindingSource
      Private _view As ItemsGridView
      Private _syncContext As SynchronizationContext
   End Class
End Namespace
