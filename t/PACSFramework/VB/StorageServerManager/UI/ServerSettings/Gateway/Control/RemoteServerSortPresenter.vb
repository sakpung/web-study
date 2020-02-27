' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Dicom.AddIn.Common
Imports System.Data
Imports Leadtools.Medical.Gateway.CFindAddin.DataTypes

Namespace Leadtools.Demos.StorageServer.UI
   Friend Class RemoteServerSortPresenter
      Public Sub RunView(ByVal mainToolStrip As ToolStrip, ByVal gatewaySource As BindingSource, ByVal remoteServerSource As BindingSource)
         _gatewaySource = gatewaySource
         _remoteServerSource = remoteServerSource

         _remoteServerUpDownMenu = New RemoteServerSortToolStrip()

         mainToolStrip.Items.Add(New ToolStripSeparator())

         ToolStripManager.Merge(_remoteServerUpDownMenu, mainToolStrip)

         AddHandler _remoteServerUpDownMenu.MoveUp, AddressOf _remoteServerUpDownMenu_MoveUp
         AddHandler _remoteServerUpDownMenu.MoveDown, AddressOf _remoteServerUpDownMenu_MoveDown

         AddHandler _remoteServerSource.PositionChanged, AddressOf _remoteServerSource_PositionChanged
      End Sub

      Public Sub Reconfigure(ByVal gatewaySource As BindingSource, ByVal remoteServersSource As BindingSource)
         If Not _remoteServerSource Is Nothing Then
            RemoveHandler _remoteServerSource.PositionChanged, AddressOf _remoteServerSource_PositionChanged
         End If

         _gatewaySource = gatewaySource
         _remoteServerSource = remoteServersSource

         If Not Nothing Is _remoteServerSource Then
            AddHandler _remoteServerSource.PositionChanged, AddressOf _remoteServerSource_PositionChanged
         End If
      End Sub

      Private Sub _remoteServerSource_PositionChanged(ByVal sender As Object, ByVal e As EventArgs)
         _remoteServerUpDownMenu.CanMoveDown = (_remoteServerSource.Position < _remoteServerSource.Count - 1)
         _remoteServerUpDownMenu.CanMoveUp = (_remoteServerSource.Position > 0)
      End Sub

      Private Sub _remoteServerUpDownMenu_MoveDown(ByVal sender As Object, ByVal e As EventArgs)
         If _remoteServerSource.Position < _remoteServerSource.Count - 1 Then
            MoveRow(1)
         End If
      End Sub

      Private Sub _remoteServerUpDownMenu_MoveUp(ByVal sender As Object, ByVal e As EventArgs)
         If _remoteServerSource.Position > 0 Then
            MoveRow(-1)
         End If
      End Sub

      Private Sub MoveRow(ByVal direction As Integer)
         Dim gateways As Gateways = CType(_gatewaySource.DataSource, Gateways)

         Dim currentRow As Gateways.RemoteServerRow = (CType((CType(_remoteServerSource.Current, DataRowView)).Row, Gateways.RemoteServerRow))
         _remoteServerSource.Position += direction
         Dim newRow As Gateways.RemoteServerRow = (CType((CType(_remoteServerSource.Current, DataRowView)).Row, Gateways.RemoteServerRow))
         Dim remoteServer As AeInfo = CType(currentRow.RemoteServerSettings, AeInfo)
         Dim currentIndex As Integer = gateways.RemoteServer.Rows.IndexOf(currentRow)
         Dim newIndex As Integer = gateways.RemoteServer.Rows.IndexOf(newRow)

         Dim items As Object() = currentRow.ItemArray

         gateways.RemoteServer.Rows.Remove(currentRow)
         Dim updateRow As DataRow = gateways.RemoteServer.NewRow()
         updateRow.ItemArray = items
         gateways.RemoteServer.Rows.InsertAt(updateRow, newIndex)
         _remoteServerSource.Position = newIndex

         Dim server As GatewayServer = CType((CType((CType(_gatewaySource.Current, DataRowView)).Row, Gateways.GatewayServerRow)).GatewayServer, GatewayServer)

         Dim aeInfoIndex As Integer = server.RemoteServers.IndexOf(remoteServer)
         aeInfoIndex += direction
         server.RemoteServers.Remove(remoteServer)
         server.RemoteServers.Insert(aeInfoIndex, remoteServer)

         GatewaySettingsPresenter.SetGatwayServerAddInSettings(server)
      End Sub

      Private _remoteServerUpDownMenu As RemoteServerSortToolStrip
      Private _gatewaySource As BindingSource
      Private _remoteServerSource As BindingSource
   End Class
End Namespace
