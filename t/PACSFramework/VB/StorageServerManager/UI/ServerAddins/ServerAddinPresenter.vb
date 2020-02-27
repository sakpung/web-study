' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Dicom.Server.Admin
Imports Leadtools.Dicom.AddIn.Interfaces
Imports Leadtools.Demos.StorageServer.DataTypes

Namespace Leadtools.Demos.StorageServer.UI
   Friend Class ServerAddinPresenter
#Region "Public"

#Region "Methods"

      Public Sub New()
      End Sub

      Public Sub RunView(ByVal _view As ServerAddinsView)
         View = _view

         SetViewAddins()

         AddHandler ServerState.Instance.ServerServiceChanged, AddressOf Instance_ServerServiceChanged
         AddHandler _view.AddInClicked, AddressOf view_AddInClicked
      End Sub

#End Region

#Region "Properties"

      Private _view As ServerAddinsView
      Public Property View() As ServerAddinsView
         Get
            Return _view
         End Get
         Set(ByVal value As ServerAddinsView)
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

      Shared Sub New()
         _ignoreAddins = New List(Of String)()

         _ignoreAddins.Add("Auto Copy")
         _ignoreAddins.Add("Forwarder")
         _ignoreAddins.Add("Patient Updater")
         _ignoreAddins.Add("Query/Retrieve, Store Configuration")
      End Sub

      Private Sub SetViewAddins()
         If Not ServerState.Instance.ServerService Is Nothing Then
            Dim found As Boolean = False

            For Each addin As IAddInOptions In ServerState.Instance.ServerService.AddInOptions
               If _ignoreAddins.Contains(addin.Text) Then
                  Continue For
               End If

               View.SetAddin(addin)

               found = True
            Next addin

            If (Not found) Then
               View.DisplayStaticNote("No Add-ons found.")
            Else
               View.HideStaticNote()
            End If
         Else
            View.ClearAddins()

            View.HideStaticNote()
         End If
      End Sub

#End Region

#Region "Properties"

#End Region

#Region "Events"

      Sub Instance_ServerServiceChanged(ByVal sender As Object, ByVal e As EventArgs)
         SetViewAddins()
      End Sub

      Sub view_AddInClicked(ByVal sender As Object, ByVal e As DataEventArgs(Of IAddInOptions))
         e.Data.Configure(View, ServerState.Instance.ServerService.Settings, ServerState.Instance.ServerService.ServiceDirectory)
      End Sub

#End Region

#Region "Data Members"

      Private Shared _ignoreAddins As List(Of String)

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
