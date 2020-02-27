' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports Leadtools.Dicom.Server.Admin
Imports Leadtools.Dicom.AddIn.Common
Imports Leadtools.Medical.Workstation.DataAccessLayer
Imports Leadtools.Medical.DataAccessLayer.Configuration
Imports Leadtools.Medical.Storage.DataAccessLayer.Configuration
Imports System.Configuration
Imports System.Xml
Imports Leadtools.Demos.Workstation.Configuration


Namespace Leadtools.Demos.Workstation
   Public Class WorkstatoinServiceManager
	   Implements IDisposable
	  #Region "Public"

		 #Region "Methods"

         Public Sub New(ByVal baseDirectoryParam As String)
            baseDirectory = baseDirectoryParam
         End Sub

			Public Function LoadWorkstationListenerService(ByVal serviceName As String) As DicomService
			   If WorkstationService IsNot Nothing Then
				  Throw New InvalidOperationException ("Another service is already loaded")
			   End If

			   CreateServiceAdmin (serviceName)

			   For Each service As DicomService In ServiceAdmin.Services.Values
				  WorkstationService = service

				  Return service
			   Next service

			   Return Nothing
			End Function

			Public Sub UnloadWorkstationListenerService()
			   If WorkstationService Is Nothing Then
				  Return
			   End If

			   WorkstationService.Dispose ()

			   WorkstationService = Nothing

			   If Nothing IsNot ServiceAdmin Then
				  RemoveHandler ServiceAdmin.Error, AddressOf ServiceAdmin_Error
				  ServiceAdmin.Dispose ()
				  ServiceAdmin = Nothing
			   End If
			End Sub

			Public Function InstallWorkstationService(ByVal settings As ServerSettings, ByVal addInsDlls() As String) As DicomService
			   If WorkstationService IsNot Nothing Then
				  Throw New InvalidOperationException ("Workstation Service already installed.")
			   End If

			   CreateServiceAdmin (settings.AETitle)

			   Dim service As DicomService


			   InstallAddIns (addInsDlls, settings.AETitle)

			   service = ServiceAdmin.InstallService (settings)

			   WorkstationService = service

			   Return service
			End Function

			Public Sub UninstallWorkstationService()
			   If Nothing IsNot WorkstationService Then
				  ServiceAdmin.UnInstallService (WorkstationService)

				  WorkstationService.Dispose ()

				  WorkstationService = Nothing
			   End If
			End Sub

		 #End Region

		 #Region "Properties"

			Private Property ServiceAdmin() As ServiceAdministrator
			   Get
				  Return _serviceAdmin
			   End Get

			   Set(ByVal value As ServiceAdministrator)
				  _serviceAdmin = value
			   End Set
			End Property

			Private privateBaseDirectory As String
			Public Property BaseDirectory() As String
				Get
					Return privateBaseDirectory
				End Get
				Private Set(ByVal value As String)
					privateBaseDirectory = value
				End Set
			End Property

			Private privateWorkstationService As DicomService
			Public Property WorkstationService() As DicomService
				Get
					Return privateWorkstationService
				End Get
				Private Set(ByVal value As DicomService)
					privateWorkstationService = value
				End Set
			End Property

			Public ReadOnly Property ServiceName() As String
			   Get
				  If WorkstationService Is Nothing Then
					 Return Nothing
				  Else
					 Return WorkstationService.ServiceName
				  End If
			   End Get
			End Property


		 #End Region

		 #Region "Events"

		 #End Region

		 #Region "Data Types Definition"

		 #End Region

		 #Region "Callbacks"

			Public Event ServerError As EventHandler(Of Leadtools.Dicom.Server.Admin.ErrorEventArgs)

		 #End Region

	  #End Region

	  #Region "Protected"

		 #Region "Methods"

		 #End Region

		 #Region "Properties"

		 #End Region

		 #Region "Events"

		 #End Region

		 #Region "Data Members"

		 #End Region

		 #Region "Data Types Definition"

		 #End Region

	  #End Region

	  #Region "Private"

		 #Region "Methods"

			Private Sub InstallAddIns(ByVal addIns() As String, ByVal serviceName As String)
			   Dim addInsDirectory As String


			   addInsDirectory = Path.Combine (Path.Combine (ServiceAdmin.BaseDirectory, serviceName), "AddIns")

			   If (Not Directory.Exists (addInsDirectory)) Then
				  Directory.CreateDirectory (addInsDirectory)
			   End If

			   For Each addInDll As String In addIns
				  If File.Exists (Path.Combine (ServiceAdmin.BaseDirectory, addInDll)) Then
					 File.Copy (Path.Combine (ServiceAdmin.BaseDirectory, addInDll), Path.Combine (addInsDirectory, addInDll), True)
				  End If
			   Next addInDll

			   CreateAddInConfigurationFile (Path.Combine (ServiceAdmin.BaseDirectory, serviceName))
			End Sub

			Private Sub CreateAddInConfigurationFile(ByVal serviceDirectory As String)
			   Dim addInConfigurationFile As String
			   Dim config As System.Configuration.Configuration
			   Dim xml As System.Configuration.ConfigXmlDocument = New ConfigXmlDocument ()
			   Dim nodes As XmlNodeList



			   addInConfigurationFile = Path.Combine (serviceDirectory, "service.config")
			   config = ConfigurationManager.OpenExeConfiguration (System.Configuration.ConfigurationUserLevel.None)

			   config.SaveAs (addInConfigurationFile)

			   xml.Load (addInConfigurationFile)

			   nodes = xml.GetElementsByTagName ("appSettings")

			   If nodes.Count > 0 Then
				  nodes (0).ParentNode.RemoveChild (nodes (0))

				  xml.Save (addInConfigurationFile)
			   End If
			End Sub

			Private Sub CreateServiceAdmin(ByVal serviceName As String)
			   Dim services As List(Of String)


			   ServiceAdmin = New ServiceAdministrator (BaseDirectory)
			   services = New List (Of String) ()

			   AddHandler ServiceAdmin.Error, AddressOf ServiceAdmin_Error

			   services.Add (serviceName)

#If LEADTOOLS_V175_OR_LATER Then
            ServiceAdmin.Initialize(services)
#Else
		    ServiceAdmin.Unlock(ConfigurationData.PacsFrmKey, services)
#End If

			   If ServiceAdmin.IsLocked Then
				  Throw New InvalidOperationException ("PACS Framework locked.")
			   End If
			End Sub

		 #End Region

		 #Region "Properties"

		 #End Region

		 #Region "Events"

			Private Sub ServiceAdmin_Error(ByVal sender As Object, ByVal e As Leadtools.Dicom.Server.Admin.ErrorEventArgs)
			   If Nothing IsNot ServerErrorEvent Then
				  RaiseEvent ServerError(sender, e)
			   End If
			End Sub

		 #End Region

		 #Region "Data Members"

			Private _serviceAdmin As ServiceAdministrator

		 #End Region

		 #Region "Data Types Definition"

		 #End Region

	  #End Region

	  #Region "internal"

		 #Region "Methods"

		 #End Region

		 #Region "Properties"

		 #End Region

		 #Region "Events"

		 #End Region

		 #Region "Data Types Definition"

		 #End Region

		 #Region "Callbacks"

		 #End Region

	  #End Region

	  #Region "IDisposable Members"

	  Public Sub Dispose() Implements IDisposable.Dispose
		 Try
			UnloadWorkstationListenerService ()
		 Catch
		 End Try
	  End Sub

	  #End Region
   End Class
End Namespace
