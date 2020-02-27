' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace Leadtools.Demos.StorageServer.UI
   Friend Class ServerControlToolStrip : Inherits ToolStrip
      Public Sub New()
         MyBase.New()
         _startServer.Text = "Start"
         _stopServer.Text = "Stop"
         _startAllServers.Text = "Start All"
         _stopAllServers.Text = "Stop All"

         _startServer.Image = Global.My.Resources.Start
         _stopServer.Image = Global.My.Resources._Stop
         _startAllServers.Image = Global.My.Resources.StartAll
         _stopAllServers.Image = Global.My.Resources.StopAll

         _startServer.DisplayStyle = ToolStripItemDisplayStyle.Image
         _stopServer.DisplayStyle = ToolStripItemDisplayStyle.Image
         _startAllServers.DisplayStyle = ToolStripItemDisplayStyle.Image
         _stopAllServers.DisplayStyle = ToolStripItemDisplayStyle.Image

         Me.Items.AddRange(New ToolStripItem() {_startServer, _stopServer, _startAllServers, _stopAllServers})

         AddHandler _startServer.Click, AddressOf _startServer_Click
         AddHandler _stopServer.Click, AddressOf _stopServer_Click
         AddHandler _startAllServers.Click, AddressOf _startAllServers_Click
         AddHandler _stopAllServers.Click, AddressOf _stopAllServers_Click

      End Sub

      Public Property CanStart() As Boolean
         Get
            Return _startServer.Enabled
         End Get

         Set(ByVal value As Boolean)
            _startServer.Enabled = value
         End Set
      End Property

      Public Property CanStop() As Boolean
         Get
            Return _stopServer.Enabled
         End Get

         Set(ByVal value As Boolean)
            _stopServer.Enabled = value
         End Set
      End Property

      Public Property CanStartAll() As Boolean
         Get
            Return _startAllServers.Enabled
         End Get

         Set(ByVal value As Boolean)
            _startAllServers.Enabled = value
         End Set
      End Property

      Public Property CanStopAll() As Boolean
         Get
            Return _stopAllServers.Enabled
         End Get

         Set(ByVal value As Boolean)
            _stopAllServers.Enabled = value
         End Set
      End Property

      Public Event StartServer As EventHandler
      Public Event StopServer As EventHandler
      Public Event StartAllServers As EventHandler
      Public Event StopAllServers As EventHandler

      Private Sub _startServer_Click(ByVal sender As Object, ByVal e As EventArgs)
         If Not Nothing Is StartServerEvent Then
            RaiseEvent StartServer(Me, e)
         End If
      End Sub

      Private Sub _stopServer_Click(ByVal sender As Object, ByVal e As EventArgs)
         If Not Nothing Is StopServerEvent Then
            RaiseEvent StopServer(Me, e)
         End If
      End Sub

      Private Sub _startAllServers_Click(ByVal sender As Object, ByVal e As EventArgs)
         If Not Nothing Is StartAllServersEvent Then
            RaiseEvent StartAllServers(Me, e)
         End If
      End Sub

      Private Sub _stopAllServers_Click(ByVal sender As Object, ByVal e As EventArgs)
         RaiseEvent StopAllServers(Me, e)
      End Sub



      Private _startServer As ToolStripButton = New ToolStripButton()
      Private _stopServer As ToolStripButton = New ToolStripButton()
      Private _startAllServers As ToolStripButton = New ToolStripButton()
      Private _stopAllServers As ToolStripButton = New ToolStripButton()
   End Class
End Namespace
