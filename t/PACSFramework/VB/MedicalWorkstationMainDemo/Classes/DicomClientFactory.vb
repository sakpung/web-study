' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Medical.Workstation.Client
Imports Leadtools.Medical.Workstation.Client.Local
Imports Leadtools.Medical.Workstation.Client.Pacs
Imports Leadtools.Medical.Workstation.Loader
Imports Leadtools.Medical.Workstation
Imports Leadtools.Medical.Storage.DataAccessLayer
Imports Leadtools.Medical.DataAccessLayer
Imports Leadtools.Medical.Storage.DataAccessLayer.Configuration
Imports Leadtools.DicomDemos
Imports Leadtools.Demos.Workstation.Configuration

Namespace Leadtools.Demos.Workstation
   Public Class DicomClientFactory
#Region "Public"

#Region "Methods"
        Private Shared Sub SetQueryClientTlsSettings(ByVal client As BaseClient)
            '// Set TLS settings
            client.ClientCertificate = ConfigurationData.SecurityOptions.CertificateFileName
            client.ClientCertificateType = ConfigurationData.SecurityOptions.CertificateType
            client.ClientCertificateKey = ConfigurationData.SecurityOptions.KeyFileName
            client.ClientCertificateKeyPassword = ConfigurationData.SecurityOptions.Password

            client.CipherSuiteList.Clear()
            For Each cipherSuiteItem As CipherSuiteItem In ConfigurationData.SecurityOptions.CipherSuites.ItemList
                If cipherSuiteItem.IsChecked Then
                    client.CipherSuiteList.Add(cipherSuiteItem.Cipher)
                End If
            Next cipherSuiteItem

            client.OpenSslContextCreationSettings = New Dicom.DicomOpenSslContextCreationSettings(ConfigurationData.SecurityOptions.SslMethodType, ConfigurationData.SecurityOptions.CertificationAuthoritiesFileName, ConfigurationData.SecurityOptions.VerificationFlags, ConfigurationData.SecurityOptions.MaximumVerificationDepth, ConfigurationData.SecurityOptions.Options)
        End Sub

        Public Shared Function CreateQueryClient() As QueryClient
			   Try
				  Return CreateQueryClient (ConfigurationData.ClientBrowsingMode)
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw
			   End Try
			End Function

			Public Shared Function CreateQueryClient(ByVal clientMode As DicomClientMode) As QueryClient
			   Try
				  Select Case clientMode
					 Case DicomClientMode.LocalDb
						Dim client As QueryClient
						Dim dataAccess As IStorageDataAccessAgent


						If (Not ConfigurationData.SupportLocalQueriesStore) Then
						   Throw New InvalidOperationException ("Feature is not supported.")
						End If

						dataAccess = DataAccessServices.GetDataAccessService (Of IStorageDataAccessAgent) ()

						If Nothing Is dataAccess Then
						   Throw New InvalidOperationException ("Storage Service is not registered.")
						End If

						client = New DbQueryClient (ConfigurationData.WorkstationClient.ToAeInfo (), dataAccess)

						client.EnableLog = ConfigurationData.Debugging.GenerateLogFile
						client.LogFileName = ConfigurationData.Debugging.LogFileName

						Return client


					 Case DicomClientMode.Pacs
						Dim client As QueryClient
						Dim scp As Leadtools.Dicom.Scu.DicomScp


						If (Not ConfigurationData.SupportDicomCommunication) Then
						   Throw New InvalidOperationException ("Feature is not supported.")
						End If

						scp = New Leadtools.Dicom.Scu.DicomScp ()

						scp.AETitle = ConfigurationData.ActivePacs.AETitle
						scp.PeerAddress = Utils.ResolveIPAddress (ConfigurationData.ActivePacs.Address)
						scp.Port = ConfigurationData.ActivePacs.Port
                        scp.Timeout = ConfigurationData.ActivePacs.Timeout
                        scp.Secure = ConfigurationData.ActivePacs.Secure

                        client = New PacsQueryClient (ConfigurationData.WorkstationClient.ToAeInfo (), scp)

						client.EnableLog = ConfigurationData.Debugging.GenerateLogFile
						client.LogFileName = ConfigurationData.Debugging.LogFileName
                        SetQueryClientTlsSettings(client)
                        Return client

					 Case DicomClientMode.DicomDir
						Dim client As New DicomDirQueryClient(ConfigurationData.CurrentDicomDir)

						Return client

					 Case Else
						Throw New NotImplementedException ("Dicom Client not implemented.")
				  End Select
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw
			   End Try
			End Function

			Public Shared Function CreateRetrieveClient() As RetrieveClient
			   Try
				  Return CreateRetrieveClient (ConfigurationData.ClientBrowsingMode)
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw
			   End Try
			End Function

			Public Shared Function CreateRetrieveClient(ByVal clientMode As DicomClientMode) As RetrieveClient
			   Try
				  Select Case clientMode
					 Case DicomClientMode.LocalDb
						Return CreateLocalRetrieveClient ()


					 Case DicomClientMode.Pacs
						Dim scp As Leadtools.Dicom.Scu.DicomScp


						If ConfigurationData.ActivePacs Is Nothing Then
						   Throw New InvalidOperationException ("No active PACS Server defined")
						End If

						scp = New Leadtools.Dicom.Scu.DicomScp ()

						scp.AETitle = ConfigurationData.ActivePacs.AETitle
						scp.PeerAddress = Utils.ResolveIPAddress (ConfigurationData.ActivePacs.Address)
						scp.Port = ConfigurationData.ActivePacs.Port
						scp.Timeout = ConfigurationData.ActivePacs.Timeout


						Return CreatePacsRetrieveClient (scp)

					 Case DicomClientMode.DicomDir
						Dim client As DicomDirRetrieveClient


						client = New DicomDirRetrieveClient (ConfigurationData.WorkstationClient.ToAeInfo (), ConfigurationData.CurrentDicomDir)

						Return client

					 Case Else
						Throw New NotImplementedException ("Dicom Client not implemented.")
				  End Select
			   Catch exception As Exception
				  System.Diagnostics.Debug.Assert (False, exception.Message)

				  Throw
			   End Try
			End Function

			Public Shared Function CreateLocalRetrieveClient() As DbRetrieveClient
			   Dim dataAccess As IStorageDataAccessAgent
			   Dim client As DbRetrieveClient


			   If (Not ConfigurationData.SupportLocalQueriesStore) Then
				  Throw New InvalidOperationException ("Feature is not supported.")
			   End If

			   dataAccess = DataAccessServices.GetDataAccessService (Of IStorageDataAccessAgent) ()

			   If Nothing Is dataAccess Then
				  Throw New InvalidOperationException ("Storage Service is not registered.")
			   End If

			   client = New DbRetrieveClient (ConfigurationData.WorkstationClient.ToAeInfo (), dataAccess)

			   client.EnableLog = ConfigurationData.Debugging.GenerateLogFile
			   client.LogFileName = ConfigurationData.Debugging.LogFileName

			   Return client
			End Function

			Public Shared Function CreatePacsRetrieveClient(ByVal scp As Leadtools.Dicom.Scu.DicomScp) As PacsRetrieveClient
			   Dim client As PacsRetrieveClient


			   If (Not ConfigurationData.SupportDicomCommunication) Then
				  Throw New InvalidOperationException ("Feature is not supported.")
			   End If

			   client = New PacsRetrieveClient (ConfigurationData.WorkstationClient.ToAeInfo (), scp)

			   client.EnableLog = ConfigurationData.Debugging.GenerateLogFile
            client.LogFileName = ConfigurationData.Debugging.LogFileName

            SetQueryClientTlsSettings(client)

            client.ValidateForDuplicateImages = Not ConfigurationData.ContinueRetrieveOnDuplicateInstance
            client.StoreRetrievedImages = ConfigurationData.MoveToWSClient
			   client.MoveLocally = ConfigurationData.MoveToWSClient
			   client.MoveServerAeTitle = ConfigurationData.WorkstationServiceAE


			   Return client
			End Function


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
   End Class

   Public Enum DicomClientMode
	  Pacs
	  LocalDb
	  DicomDir
   End Enum
End Namespace
