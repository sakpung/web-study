' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Medical.DataAccessLayer.Configuration
Imports Leadtools.Medical.DataAccessLayer
Imports Leadtools.Demos.StorageServer
Imports Leadtools.Medical.AeManagement.DataAccessLayer
Imports Leadtools.Dicom.AddIn.Common
Imports Leadtools.Demos.StorageServer.DataTypes
Imports Leadtools.Medical.PermissionsManagement.DataAccessLayer

Namespace Leadtools.Medical.Winforms
   Public Class ClientViewerPresenter
      Public Property MaxClients() As Nullable(Of Integer)
         Get
            If Not _view Is Nothing Then
               Return _view.MaxClients
            End If
            Return Nothing
         End Get
         Set(ByVal value As Nullable(Of Integer))
            If Not _view Is Nothing Then
               _view.MaxClients = Value
            End If
         End Set
      End Property
      Public Sub New()
      End Sub

      Private _view As ClientViewerControl

      Public Property View() As ClientViewerControl
         Get
            Return _view
         End Get
         Set(ByVal value As ClientViewerControl)
            _view = value
         End Set
      End Property

        Public Sub RunView(ByVal view As ClientViewerControl)
            view.ServerSecure = ServerState.Instance.ServerService.Settings.Secure

            EventBroker.Instance.Subscribe(Of ApplyServerSettingsEventArgs)(AddressOf OnUpdateServerSettings)
            EventBroker.Instance.Subscribe(Of CancelServerSettingsEventArgs)(AddressOf OnCancelServerSettings)
            EventBroker.Instance.Subscribe(Of ServerSettingsSecureChangedEventArgs)(AddressOf OnServerSettingsSecureChanged)

            Dim agent As IAeManagementDataAccessAgent = DataAccessServices.GetDataAccessService(Of IAeManagementDataAccessAgent)()
            Dim aeInfoExtendedArray As AeInfoExtended() = agent.GetAeTitles()

            Dim permissionsAgent As IPermissionManagementDataAccessAgent = DataAccessServices.GetDataAccessService(Of IPermissionManagementDataAccessAgent)()

            ' Get the list of all possible permissions
            view.Permissions = permissionsAgent.GetPermissions()

            ' The LEADTOOLS skinned version defaults to all permissions on
            If Shell.storageServerName.Contains("LEAD") Then
                view.NewClientPermissions = view.Permissions ' All permissions on by default;
            Else
                view.NewClientPermissions = New Permission(-1) {} ' All permissions off by default;
            End If

            view.ClientInformationList = New ClientInformationList()

            ' view.ClientInformationList.AddItems(aeInfoExtendedArray);
            For Each info As AeInfoExtended In aeInfoExtendedArray
                Dim permissionsArray As String() = permissionsAgent.GetUserPermissions(info.AETitle)
                Dim ci As ClientInformation = New ClientInformation(info, permissionsArray)
                view.ClientInformationList.ClientDictionary.Add(info.AETitle, ci)
            Next info

            ' store the view
            _view = view

            ' Make a backup of the settings
            ServerState.Instance.ClientList = New ClientInformationList(view.ClientInformationList)
            AddHandler _view.SettingsChanged, AddressOf View_SettingsChanged

        End Sub

        Public Event SettingsChanged As EventHandler

      Private Sub View_SettingsChanged(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If Not SettingsChangedEvent Is Nothing Then
               RaiseEvent SettingsChanged(sender, e)
            End If
         Catch e1 As Exception
            System.Diagnostics.Debug.Assert(False)
         End Try
      End Sub


      Public ReadOnly Property IsDirty() As Boolean
         Get
            Return _view.IsDirty
         End Get
      End Property

      Private Sub OnUpdateServerSettings(ByVal sender As Object, ByVal e As EventArgs)
         If Not _view Is Nothing Then
            Dim agent As IAeManagementDataAccessAgent = DataAccessServices.GetDataAccessService(Of IAeManagementDataAccessAgent)()
            Dim permissionsAgent As IPermissionManagementDataAccessAgent = DataAccessServices.GetDataAccessService(Of IPermissionManagementDataAccessAgent)()

            Dim aeInfoExtendedArray As AeInfoExtended() = agent.GetAeTitles()
            Dim aeTitlesInDB As List(Of String) = New List(Of String)()
            For Each ae As AeInfoExtended In aeInfoExtendedArray
               aeTitlesInDB.Add(ae.AETitle.ToUpper())
            Next ae

            ' Updates and adds
            For Each ci As ClientInformation In _view.ClientInformationList.Items
               Dim aeTitle As String = ci.Client.AETitle
               If aeTitlesInDB.Contains(aeTitle, StringComparer.InvariantCultureIgnoreCase) Then
                  ' update
                  Dim ciPrevious As ClientInformation = Nothing
                  ServerState.Instance.ClientList.ClientDictionary.TryGetValue(aeTitle, ciPrevious)

                  If (Not ciPrevious.Equals(ci)) Then
                     agent.Update(aeTitle, ci.Client)
                  End If
                  aeTitlesInDB.Remove(aeTitle.ToUpper())
                  Try
                     EventBroker.Instance.PublishEvent(Of ClientUpdatedEventArgs)(Me, New ClientUpdatedEventArgs(aeTitle, ci.Client))
                  Catch
                  End Try
               Else
                  ' insert
                  agent.Add(ci.Client)
                  Try
                     EventBroker.Instance.PublishEvent(Of ClientAddedEventArgs)(Me, New ClientAddedEventArgs(ci.Client))
                  Catch
                  End Try
               End If
               permissionsAgent.DeleteUserPermission(Nothing, aeTitle)
               For Each permissionName As String In ci.Permissions
                  permissionsAgent.AddUserPermission(permissionName, aeTitle)
               Next permissionName
            Next ci

            ' Finally, remove the deleted AE titles from the database
            For Each aeTitle As String In aeTitlesInDB
               agent.Remove(aeTitle)
               Try
                  EventBroker.Instance.PublishEvent(Of ClientRemovedEventArgs)(Me, New ClientRemovedEventArgs(aeTitle))
               Catch
               End Try
            Next aeTitle

            ServerState.Instance.ClientList = New ClientInformationList(_view.ClientInformationList)

         End If
      End Sub

      Private Sub OnCancelServerSettings(ByVal sender As Object, ByVal e As EventArgs)
         If Not _view Is Nothing Then
            _view.ClientInformationList = ServerState.Instance.ClientList
         End If
      End Sub

      Private Sub OnServerSettingsSecureChanged(ByVal sender As Object, ByVal e As ServerSettingsSecureChangedEventArgs)
		 _view.ServerSecure = e.SecureServer
      End Sub
   End Class
End Namespace
