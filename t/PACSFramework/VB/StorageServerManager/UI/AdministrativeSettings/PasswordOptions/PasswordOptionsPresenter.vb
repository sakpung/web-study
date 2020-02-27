' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Demos.StorageServer.DataTypes
Imports Leadtools.Medical.DataAccessLayer
Imports Leadtools.Medical.OptionsDataAccessLayer
Imports Leadtools.Medical.OptionsDataAccessLayer.Configuration
Imports Leadtools.Demos.StorageServer.DataTypes.Options
Imports Leadtools.Medical.Winforms.Monitor
Imports Leadtools.Demos.StorageServer.UI.AdministrativeSettings

Namespace Leadtools.Demos.StorageServer.UI
   Public Class PasswordOptionsPresenter
      Private _IdleMonitor As IdleMonitor

      Public Const PasswordOptions As String = "PasswordOptions"

      Private _Options As IOptionsDataAccessAgent

      Public Property View() As PasswordOptionsView
         Get
         Private Set
         End Get
         End Get

      public void RunView(PasswordOptionsView view)
         ServerEventBroker.Instance.Subscribe(Of ApplyServerSettingsEventArgs)(OnUpdateServerSettings)
         ServerEventBroker.Instance.Subscribe(Of CancelServerSettingsEventArgs)(OnCancelServerSettings)
         ServerEventBroker.Instance.Subscribe(Of ActivateIdleMonitorEventArgs)(UpdateIdleMonitor)

         View = view
         _Options = DataAccessServices.GetDataAccessService(Of IOptionsDataAccessAgent)()
         View.Options = _Options.Get(Of PasswordOptions)(PasswordOptions, New PasswordOptions())
         If View.Options.EnableIdleTimeout Then
            StartIdleMonitor()
         End If

      private void OnUpdateServerSettings(Object sender, EventArgs e)
         Try
            _Options.Set(Of PasswordOptions)(PasswordOptions, View.Options)
            If View.Options.EnableIdleTimeout Then
               StartIdleMonitor()
            Else
               StopIdleMonitor()
            End If
         Catch exception As Exception
            Messager.ShowError(Nothing, exception)
         End Try

      private void OnCancelServerSettings(Object sender, EventArgs e)

      private void UpdateIdleMonitor(Object sender, ActivateIdleMonitorEventArgs e)
         If e.Activate AndAlso View.Options.EnableIdleTimeout Then
            StartIdleMonitor()
         Else
            StopIdleMonitor()
         End If

      private void StartIdleMonitor()
         StopIdleMonitor()
         _IdleMonitor = New IdleMonitor(View.Options.IdleTimeOut)
         AddHandler _IdleMonitor.IdleTimeout, AddressOf _IdleMonitor_IdleTimeout
         _IdleMonitor.Start()

      void _IdleMonitor_IdleTimeout(Object sender, EventArgs e)
         ServerEventBroker.Instance.PublishEvent(Of LoginEventArgs)(Me, New LoginEventArgs())

      private void StopIdleMonitor()
         If Not _IdleMonitor Is Nothing Then
            RemoveHandler _IdleMonitor.IdleTimeout, AddressOf _IdleMonitor_IdleTimeout
            _IdleMonitor.Stop()
            _IdleMonitor.Dispose()
            _IdleMonitor = Nothing
         End If
      End Property
   End Class
