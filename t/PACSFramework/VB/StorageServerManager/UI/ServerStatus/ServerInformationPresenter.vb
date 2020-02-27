' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Dicom.Server.Admin
Imports System.ServiceProcess
Imports System.Threading
Imports System.Windows.Forms
Imports Leadtools.Demos.StorageServer.DataTypes
Imports Leadtools.Medical.Winforms
Imports System.Text.RegularExpressions
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.ComponentModel

Namespace Leadtools.Demos.StorageServer.UI
   Friend Class ServerInformationPresenter
      Public Sub RunView(ByVal viewParam As ServerInformationView)
         View = viewParam

         __SyncContext = WindowsFormsSynchronizationContext.Current

         ConfigureView()

         AddHandler ServerState.Instance.ServerServiceChanged, AddressOf OnConfigureView
         AddHandler ServerState.Instance.IsRemoteServerChanged, AddressOf OnConfigureView
         AddHandler ServerState.Instance.RemoteServerInformationChanged, AddressOf OnConfigureView

         EventBroker.Instance.Subscribe(Of ServerSettingsAppliedEventArgs)(AddressOf OnConfigureView)
      End Sub

      Private Sub OnConfigureView(ByVal sender As Object, ByVal e As EventArgs)
         ConfigureView()
      End Sub

      Private Sub ConfigureViewDelegate(ByVal state As Object)
         If ServerState.Instance.IsRemoteServer Then
            View.CanStartStopServer = False

            If Not Nothing Is ServerState.Instance.RemoteServerInformation Then
               View.ServerDisplayName = ServerState.Instance.RemoteServerInformation.ServiceName
               View.ServerAE = ServerState.Instance.RemoteServerInformation.DicomServer.AE
               View.IpAddress = ServerState.Instance.RemoteServerInformation.DicomServer.IPAddress
                    View.Port = ServerState.Instance.RemoteServerInformation.DicomServer.Port.ToString()
                    View.IsSecure = ServerState.Instance.RemoteServerInformation.DicomServer.UseTls
                End If

            Return
         End If

         If Not Nothing Is Service Then
            If Service.Settings.Description.Length > 0 Then
               View.ServerDisplayName = Service.Settings.Description
            Else
               View.ServerDisplayName = "Storage Server"
            End If
            View.ServerAE = Service.Settings.AETitle
            View.IpAddress = Service.Settings.IpAddress.ToString()
                View.Port = Service.Settings.Port.ToString()
                View.IsSecure = Service.Settings.Secure

                AddHandler View.StartService, AddressOf view_StartService
            AddHandler View.StopService, AddressOf view_StopService

            SetServiceStatus()

            AddHandler Service.StatusChange, AddressOf Service_StatusChange
         Else
            View.ServerDisplayName = String.Empty
            View.ServerAE = String.Empty
            View.IpAddress = String.Empty
                View.Port = String.Empty
                View.IsSecure = False

                View.IsServerRunning = True
            View.CanStartStopServer = False
            View.Status = "Not Applicable"
         End If
      End Sub

      Private Sub ConfigureView()
         Dim service As DicomService = ServerState.Instance.ServerService

         '__SyncContext.Send(New SendOrPostCallback(AddressOf ConfigureViewDelegate), )
         Dim state As Object = New Object()
         __SyncContext.Send(AddressOf ConfigureViewDelegate, state)
      End Sub

      Sub view_StartService(ByVal sender As Object, ByVal e As EventArgs)
         Service.Start()
      End Sub

      Sub view_StopService(ByVal sender As Object, ByVal e As EventArgs)
         Service.Stop()
      End Sub

      Sub Service_StatusChange(ByVal sender As Object, ByVal e As EventArgs)
         SetServiceStatus()
      End Sub

      Private Sub MySendOrPostCallback(ByVal state As Object)
         If (Service.Status = ServiceControllerStatus.Running) Then
            View.IsServerRunning = True
         ElseIf Service.Status = ServiceControllerStatus.Stopped OrElse Service.Status = ServiceControllerStatus.StopPending OrElse Service.Status = ServiceControllerStatus.StartPending Then
            View.IsServerRunning = False
         Else
            View.CanStartStopServer = False
         End If

         '
         ' Convert CamelCase Status to a space delimeted status.  StartPending becomes Start Pending
         '
         View.Status = Regex.Replace(Service.Status.ToString(), "(\B[A-Z])", " $1")
      End Sub

      Private Sub SetServiceStatus()
         __SyncContext.Send(AddressOf MySendOrPostCallback, Nothing)
      End Sub

      Private _view As ServerInformationView
      Public Property View() As ServerInformationView
         Get
            Return _view
         End Get
         Private Set(ByVal value As ServerInformationView)
            _view = value
         End Set
      End Property

      Public ReadOnly Property Service() As DicomService
         Get
            Return ServerState.Instance.ServerService
         End Get
      End Property

      Private _mySyncContext As SynchronizationContext
      Private Property __SyncContext() As SynchronizationContext
         Get
            Return _mySyncContext
         End Get
         Set(ByVal value As SynchronizationContext)
            _mySyncContext = value
         End Set
      End Property
   End Class
end namespace 
