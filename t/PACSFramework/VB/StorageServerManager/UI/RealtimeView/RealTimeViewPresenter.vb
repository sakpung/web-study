' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Medical.Winforms.ClientManager
Imports Leadtools.Dicom.Server.Admin
Imports Leadtools.Dicom.AddIn.Common
Imports Leadtools.Dicom.AddIn
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.ServiceProcess

Namespace Leadtools.Demos.StorageServer.UI.RealtimeView
    Public Class RealTimeViewPresenter
        Private _View As RealTimeViewerControl

        Public Sub RunView(ByVal view As RealTimeViewerControl)
            _View = view
            AddHandler _View.VisibleChanged, AddressOf _View_VisibleChanged
            AddHandler _View.DisconnectClient, AddressOf _View_DisconnectClient
            AddHandler ServerState.Instance.ServerServiceChanged, AddressOf Instance_ServerServiceChanged
            HookEvents()
        End Sub

        Private Sub _View_DisconnectClient(ByVal sender As Object, ByVal e As DisconnectClientEventArgs)
            If Not ServerState.Instance.ServerService Is Nothing Then
                ServerState.Instance.ServerService.SendMessage(MessageNames.DisconnectClient, e.ClientInfo)
            End If
        End Sub

        Private Sub _View_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs)
            If (Not _View.Visible) Then
                _View.PauseScheduler()
            Else
                _View.ResumeScheduler()
            End If
        End Sub

        Private Sub Instance_ServerServiceChanged(ByVal sender As Object, ByVal e As EventArgs)
            HookEvents()
        End Sub

        Private Sub HookEvents()
            If Not ServerState.Instance.ServerService Is Nothing Then
                AddHandler ServerState.Instance.ServerService.StatusChange, AddressOf ServerService_StatusChange
                AddHandler ServerState.Instance.ServerService.Message, AddressOf ServerService_Message
                If ServerState.Instance.ServerService.Status = ServiceControllerStatus.Running Then
                    ServerState.Instance.ServerService.SendMessage(MessageNames.GetConnectedClients)
                End If
                _View.Refresh()
            End If
        End Sub

        Private Sub Proc_StatusChange()
            _View.Clear()
        End Sub
        Private Sub ServerService_StatusChange(ByVal sender As Object, ByVal e As EventArgs)
            If Not ServerState.Instance.ServerService Is Nothing Then
                If ServerState.Instance.ServerService.Status <> ServiceControllerStatus.Running Then
                    AsyncHelper.SynchronizedInvoke(Application.OpenForms(0), AddressOf Proc_StatusChange)
                End If
            End If
        End Sub

        Private Function Proc_ClientConnected(ByVal e As MessageEventArgs) As Integer
            _View.ClientConnected(TryCast(e.Message.Data(1), ClientInfo))
            If (Not _View.Visible) Then
                _View.PauseScheduler()
            End If
            Return 0
        End Function

        Private Function Proc_ClientAssociated(ByVal e As MessageEventArgs) As Integer
            _View.ClientAssociated(TryCast(e.Message.Data(1), ClientInfo))
            _View.SetClientAction(TryCast(e.Message.Data(0), String), "ASSOCIATED", String.Empty)
            Return 0
        End Function

        Private Function Proc_SetClientAction(ByVal e As MessageEventArgs) As Integer
            _View.SetClientAction(TryCast(e.Message.Data(0), String), TryCast(e.Message.Data(1), String), TryCast(e.Message.Data(3), String))
            Return 0
        End Function

        Private Function Proc_ClientDisconnected(ByVal e As MessageEventArgs) As Integer
            _View.ClientDisconnected(TryCast(e.Message.Data(1), ClientInfo))
            Return 0
        End Function

        Private Function Proc_GetConnectedClients(ByVal e As MessageEventArgs) As Integer
            _View.ClientDisconnected(TryCast(e.Message.Data(0), ClientInfo))
            Return 0
        End Function

        Private Sub ServerService_Message(ByVal sender As Object, ByVal e As MessageEventArgs)
            Select Case e.Message.Message
                Case MessageNames.ClientConnected
                    AsyncHelper.SynchronizedInvoke(Application.OpenForms(0), Function() Proc_ClientConnected(e))
                Case MessageNames.ClientAssociated
                    AsyncHelper.SynchronizedInvoke(Application.OpenForms(0), Function() Proc_ClientAssociated(e))
                Case MessageNames.ClientAction
                    AsyncHelper.SynchronizedInvoke(Application.OpenForms(0), Function() Proc_SetClientAction(e))
                Case MessageNames.ClientDisconnected
                    AsyncHelper.SynchronizedInvoke(Application.OpenForms(0), Function() Proc_ClientDisconnected(e))
                Case MessageNames.GetConnectedClients
                    AsyncHelper.SynchronizedInvoke(Application.OpenForms(0), Function() Proc_GetConnectedClients(e))
            End Select
        End Sub
    End Class
End Namespace
