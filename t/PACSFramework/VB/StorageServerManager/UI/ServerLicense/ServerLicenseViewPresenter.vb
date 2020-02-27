' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Medical.Winforms.LicenseManager
Imports Leadtools.Dicom.AddIn
Imports System.Windows.Forms
Imports System.IO
Imports Leadtools.DicomDemos
Imports Leadtools.Demos.StorageServer.DataTypes

Namespace Leadtools.Demos.StorageServer.UI.ServerLicense
   Public Class ServerLicenseViewPresenter
      Private _View As LicenseView

      Public Sub RunView(ByVal view As LicenseView)
         AddHandler ServerState.Instance.ServerServiceChanged, AddressOf OnConfigureView
         AddHandler ServerState.Instance.ServiceAdminChanged, AddressOf OnConfigureView
         AddHandler ServerState.Instance.IsRemoteServerChanged, AddressOf OnConfigureView

         _View = view
         If Not ServerState.Instance.License Is Nothing Then
            _View.SetLicense(ServerState.Instance.ServerService.Settings.LicenseFile, ServerState.Instance.License)
         End If
         SetHardwareCodes()
         ConfigureView()
         AddHandler _View.OpenLicense, AddressOf Of OpenLicenseEventArgs
      End Sub

      Public Sub SetHardwareCodes()
         Dim codes As List(Of String) = New List(Of String)()

         codes.Add(MachineIDs.Instance.CPUId)
         codes.Add(String.Join(String.Empty, MachineIDs.Instance.HDSerial.ToArray()))
         codes.Add(String.Join(String.Empty, MachineIDs.Instance.MACAddress.ToArray()))
         _View.SetHardwareCodes(codes.ToArray())
      End Sub

      Private Sub OnOpenLicense(ByVal sender As Object, ByVal e As OpenLicenseEventArgs)
         Try
            If Not ServerState.Instance.License Is Nothing Then
               ServerState.Instance.License.Load(e.FileName)
               ServerState.Instance.ServerService.Settings.LicenseFile = e.FileName
               ServerState.Instance.ServerService.Settings = ServerState.Instance.ServerService.Settings
               _View.SetLicense(e.FileName, ServerState.Instance.License)
               ServerState.Instance.OnLicenseChanged()
            End If
         Catch exception As Exception
            Messager.ShowError(Application.OpenForms(0), exception)
         End Try
      End Sub

      Private Sub ConfigureView()
         _View.Enabled = Not ServerState.Instance.ServerService Is Nothing
         If _View.Enabled AndAlso Not ServerState.Instance.License Is Nothing Then
            _View.SetLicense(ServerState.Instance.ServerService.Settings.LicenseFile, ServerState.Instance.License)
         Else
            _View.Clear()
         End If
      End Sub

      Private Sub OnConfigureView(ByVal sender As Object, ByVal e As EventArgs)
         ConfigureView()
      End Sub
   End Class
End Namespace
