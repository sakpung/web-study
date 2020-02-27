' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Text
Imports Leadtools.Dicom.Scu
Imports System.IO
Imports System.Configuration
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Net
Imports System.Linq
Imports Leadtools.Dicom.AddIn.Common
Imports Leadtools.DicomDemos


Namespace Leadtools.Demos.Workstation.Configuration
   Public NotInheritable Class ConfigurationData
	  #Region "Public"

		 #Region "Methods"

			Private Sub New()
			End Sub
			Public Shared Function HasChanges() As Boolean
			   Return _isDirty
			End Function

			Public Shared Sub SaveChanges()
			   Save ()
			End Sub

		 #End Region

		 #Region "Properties"

			Public Shared Property ApplicationName() As String
			   Get
				  Return _appName
			   End Get

			   Set(ByVal value As String)
				  _appName = value
			   End Set
			End Property

         Private Shared privateHelpFile As String
			Public Shared Property HelpFile() As String
				Get
					Return privateHelpFile
				End Get
				Set(ByVal value As String)
					privateHelpFile = value
				End Set
			End Property

         Private Shared privateDatabaseConfigName As String
			Public Shared Property DatabaseConfigName() As String
				Get
					Return privateDatabaseConfigName
				End Get
				Set(ByVal value As String)
					privateDatabaseConfigName = value
				End Set
			End Property

         Private Shared privateDatabaseConfigEXEName As String
			Public Shared Property DatabaseConfigEXEName() As String
				Get
					Return privateDatabaseConfigEXEName
				End Get
				Set(ByVal value As String)
					privateDatabaseConfigEXEName = value
				End Set
			End Property

         Private Shared privateDatabaseConfigAltEXEName As String
			Public Shared Property DatabaseConfigAltEXEName() As String
				Get
					Return privateDatabaseConfigAltEXEName
				End Get
				Set(ByVal value As String)
					privateDatabaseConfigAltEXEName = value
				End Set
			End Property

			Public Shared Property MoveToWSClient() As Boolean
			   Get
				  Return _moveToClient
			   End Get

			   Set(ByVal value As Boolean)
				  If value <> _moveToClient Then
					 _moveToClient = value

					 OnValueChanged (Nothing, New EventArgs ())
				  End If
			   End Set
			End Property

			Public Shared Property SetClientToAllWorkstations() As Boolean
			   Get
				  Return _setClientToAllWS
			   End Get

			   Set(ByVal value As Boolean)
				  If value <> _setClientToAllWS Then
					 _setClientToAllWS = value

					 OnValueChanged (Nothing, EventArgs.Empty)
				  End If
			   End Set
			End Property

         Private Shared privateRunPacsConfig As Boolean
			Public Shared Property RunPacsConfig() As Boolean
				Get
					Return privateRunPacsConfig
				End Get
				Set(ByVal value As Boolean)
					privateRunPacsConfig = value
				End Set
			End Property

			Public Shared Property PACS() As IList(Of ScpInfo)
			   Get
				  Return _pacs
			   End Get

			   Private Set(ByVal value As IList(Of ScpInfo))
				  _pacs = value
			   End Set
			End Property

			Public Shared Property Debugging() As DebuggingConfig
			   Get
				  Return _debuggingConfig
			   End Get

			   Private Set(ByVal value As DebuggingConfig)
				  _debuggingConfig = value
			   End Set
			End Property

			Public Shared Property Compression() As StorageCompression
			   Get
				  Return _compression
			   End Get

			   Private Set(ByVal value As StorageCompression)
				  _compression = value
			   End Set
			End Property

			Public Shared Property WorkstationClient() As ScuInfo
			   Get
				  Return _workstationClient
			   End Get

			   Private Set(ByVal value As ScuInfo)
				  _workstationClient = value
			   End Set
			End Property

			Public Shared Property ActivePacs() As ScpInfo
			   Get
				  If __ActivePacsIndex < 0 OrElse __ActivePacsIndex >= PACS.Count Then
					 Return Nothing
				  End If

				  Return PACS (__ActivePacsIndex)
			   End Get

			   Set(ByVal value As ScpInfo)
				  If value IsNot Nothing AndAlso (Not PACS.Contains (value)) Then
                Throw New InvalidOperationException("Server " & value.ToString() & " doens't exist in configured PACS list")
				  End If

				  Dim newIndex As Integer


				  newIndex = PACS.IndexOf (value)

				  If newIndex <> __ActivePacsIndex Then
					 __ActivePacsIndex = newIndex

					 OnValueChanged (Nothing, New EventArgs ())
				  End If
			   End Set
			End Property

			Public Shared Property DefaultStorageServer() As ScpInfo
			   Get
				  Return _defaultStorageServer
			   End Get

			   Set(ByVal value As ScpInfo)
				  If _defaultStorageServer IsNot value Then
					 _defaultStorageServer = value

					 OnValueChanged (Nothing, New EventArgs ())
				  End If
			   End Set
			End Property

			Public Shared Property DefaultQueryRetrieveServer() As ScpInfo
			   Get
				  Return _defaultQueryRetrieveServer
			   End Get

			   Set(ByVal value As ScpInfo)
				  If _defaultQueryRetrieveServer IsNot value Then
					 _defaultQueryRetrieveServer = value

					 OnValueChanged (Nothing, New EventArgs ())
				  End If
			   End Set
			End Property

			Public Shared Property ClientBrowsingMode() As DicomClientMode
			   Get
				  Return _clientMode
			   End Get

			   Set(ByVal value As DicomClientMode)
				  If value <> _clientMode Then
					 _clientMode = value

					 OnValueChanged (Nothing, New EventArgs ())
				  End If
			   End Set
			End Property

			Public Shared Property ViewerLazyLoading() As LazyLoading
			   Get
				  Return _viewerLazyLoading
			   End Get

			   Private Set(ByVal value As LazyLoading)
				  _viewerLazyLoading = value
			   End Set
			End Property

			Public Shared Property RunFullScreen() As Boolean
			   Get
				  Return _runFullScreen
			   End Get

			   Set(ByVal value As Boolean)
				  If value <> _runFullScreen Then
					 _runFullScreen = value

					 OnValueChanged (Nothing, New EventArgs ())
				  End If
			   End Set
			End Property

			Public Shared Property QueueAutoLoad() As Boolean
			   Get
				  Return _queueAutoLoad
			   End Get

			   Set(ByVal value As Boolean)
				  If _queueAutoLoad <> value Then
					 _queueAutoLoad = value

					 OnValueChanged (Nothing, New EventArgs ())
				  End If
			   End Set
			End Property

			Public Shared Property QueueRemoveItem() As Boolean
			   Get
				  Return _queueRemoveItem
			   End Get

			   Set(ByVal value As Boolean)
				  If _queueRemoveItem <> value Then
					 _queueRemoveItem = value

					 OnValueChanged (Nothing, New EventArgs ())
				  End If
			   End Set
			End Property

			Public Shared Property ContinueRetrieveOnDuplicateInstance() As Boolean
			   Get
				  Return _storeRetrievedImages
			   End Get

			   Set(ByVal value As Boolean)
				  If value <> _storeRetrievedImages Then
					 _storeRetrievedImages = value

					 OnValueChanged (Nothing, New EventArgs ())
				  End If
			   End Set
			End Property

			'TODO: this should be not wirtten in config, the user should call this from the demo.
			Public Shared Property MedicalNetKey() As String
			   Get
				  Return _medicalNetKey
			   End Get

			   Set(ByVal value As String)
				  _medicalNetKey = value
			   End Set
			End Property

			'TODO: this should be not wirtten in config, the user should call this from the demo.
			Public Shared Property PacsFrmKey() As String
			   Get
				  Return _pacsFrmKey
			   End Get

			   Set(ByVal value As String)
				  _pacsFrmKey = value
			   End Set
			End Property

			Public Shared Property AutoCreateService() As Boolean
			   Get
				  Return _autoCreateService
			   End Get

			   Set(ByVal value As Boolean)
				  If value <> _autoCreateService Then
					 _autoCreateService = value

					 OnValueChanged (Nothing, New EventArgs ())
				  End If
			   End Set
			End Property

			Public Shared Property WorkstationServiceAE() As String
			   Get
				  Return _workstationServiceAE
			   End Get

			   Set(ByVal value As String)
				  If value <> _workstationServiceAE Then
					 _workstationServiceAE = value

					 OnValueChanged (Nothing, New EventArgs ())
				  End If
			   End Set
			End Property

			Public Shared Property ListenerServiceName() As String
			   Get
				  Return _listenerServiceName
			   End Get

			   Set(ByVal value As String)
				  If value <> _listenerServiceName Then
					 _listenerServiceName = value

					 OnValueChanged (Nothing, New EventArgs ())
				  End If
			   End Set
			End Property

			Public Shared Property ListenerServiceDefaultName() As String
			   Get
				  Return _listenerServiceDefaultName
			   End Get

			   Set(ByVal value As String)
				  If value <> _listenerServiceDefaultName Then
					 _listenerServiceDefaultName = value

					 OnValueChanged (Nothing, New EventArgs ())
				  End If
			   End Set
			End Property

			Public Shared Property ListenerServiceDefaultDisplayName() As String
			   Get
				  Return _listenerServiceDisplayName
			   End Get

			   Set(ByVal value As String)
				  If value <> _listenerServiceDisplayName Then
					 _listenerServiceDisplayName = value

					 OnValueChanged (Nothing, New EventArgs ())
				  End If
			   End Set
			End Property

			Public Shared Property ViewerOverlayTextSize() As Integer
			   Get
				  Return _viewerOverlayTextSize
			   End Get

			   Set(ByVal value As Integer)
				  If value <> _viewerOverlayTextSize Then
					 _viewerOverlayTextSize = value

					 OnValueChanged (Nothing, New EventArgs ())
				  End If
			   End Set
			End Property

			Public Shared Property ViewerAutoSizeOverlayText() As Boolean
			   Get
				  Return _viewerAutoSizeOverlayText
			   End Get

			   Set(ByVal value As Boolean)
				  If value <> _viewerAutoSizeOverlayText Then
					 _viewerAutoSizeOverlayText = value

					 OnValueChanged (Nothing, New EventArgs ())
				  End If
			   End Set
			End Property

			Public Shared Property SaveSessionBehavior() As SaveOptions
			   Get
				  Return _saveConfigBehavior
			   End Get

			   Set(ByVal value As SaveOptions)
				  If value <> _saveConfigBehavior Then
					 _saveConfigBehavior = value

					 OnValueChanged (Nothing, EventArgs.Empty)
				  End If
			   End Set
			End Property

         Private Shared privateSupportDicomCommunication As Boolean
			Public Shared Property SupportDicomCommunication() As Boolean
				Get
					Return privateSupportDicomCommunication
				End Get
				Set(ByVal value As Boolean)
					privateSupportDicomCommunication = value
				End Set
			End Property

         Private Shared privateSupportLocalQueriesStore As Boolean
			Public Shared Property SupportLocalQueriesStore() As Boolean
				Get
					Return privateSupportLocalQueriesStore
				End Get
				Set(ByVal value As Boolean)
					privateSupportLocalQueriesStore = value
				End Set
			End Property

         Private Shared privateCurrentDicomDir As String
			Public Shared Property CurrentDicomDir() As String
				Get
					Return privateCurrentDicomDir
				End Get
				Set(ByVal value As String)
					privateCurrentDicomDir = value
				End Set
         End Property

            Private Shared privateCheckDataAccessServices As Boolean
            Public Shared Property CheckDataAccessServices() As Boolean
               Get
                  Return privateCheckDataAccessServices
               End Get

               Set(ByVal value As Boolean)
                  privateCheckDataAccessServices = value
               End Set
            End Property

            Private Shared privateShowSplash As Boolean

         Public Shared Property ShowSplashScreen() As Boolean
               Get
                  Return privateShowSplash
               End Get
               Set(ByVal value As Boolean)
                  privateShowSplash = value
               End Set
            End Property

            Private Shared privateAutoQuery As Boolean
            Public Shared Property AutoQuery() As Boolean
            Get
               Return privateAutoQuery
            End Get
               Set(ByVal value As Boolean)
                  privateAutoQuery = value
               End Set
            End Property


#End Region

#Region "Events"

         Public Shared Event ValueChanged As EventHandler
         Public Shared Event ChangesSaved As EmptyHandler

#End Region

#Region "Data Types Definition"

         Public Delegate Sub EmptyHandler()

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

         Shared Sub New()
            Try
              Dim configReader As AppSettingsReader


              SupportDicomCommunication = True
              SupportLocalQueriesStore = True
              CheckDataAccessServices = True
              ShowSplashScreen = True
              AutoQuery = False
              WorkstationClient = New ScuInfo()
              PACS = New ScpInfoBindingList()
              Debugging = New DebuggingConfig()
              Compression = New StorageCompression()
              ViewerLazyLoading = New LazyLoading()
              configReader = New AppSettingsReader()

              DefaultQueryRetrieveServer = Nothing
              DefaultStorageServer = Nothing

              ReadKeys(configReader)
              ReadConfiguredPacs(configReader)
              ReadDebugConfig(configReader)
              ReadCompressionConfig(configReader)
              ReadWorkstationClientConfig(configReader)
              ReadGeneralConfigData(configReader)
              ReadLazyLoadingConfigData(configReader)
              ReadAutoCreateServiceConfigData(configReader)
              ReadOverlayTextSizeConfigData(configReader)

              If ActivePacs Is Nothing AndAlso PACS.Count > 0 Then
                ActivePacs = PACS(0)
              End If

              _isDirty = False

              RegisterEvents()
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              Throw
            End Try
         End Sub

         Private Shared Sub RegisterEvents()
            AddHandler TryCast(PACS, BindingList(Of ScpInfo)).ListChanged, AddressOf PacsConfiguration_ListChanged

            AddHandler TryCast(PACS, ScpInfoBindingList).ScpValueChanged, AddressOf OnValueChanged
            AddHandler Debugging.ValueChanged, AddressOf OnValueChanged
            AddHandler Compression.ValueChanged, AddressOf OnValueChanged
            AddHandler ViewerLazyLoading.ValueChanged, AddressOf OnValueChanged
            AddHandler WorkstationClient.ValueChanged, AddressOf OnValueChanged
         End Sub

         Private Shared Sub ReadKeys(ByVal configReader As AppSettingsReader)
            Try
              MedicalNetKey = CStr(configReader.GetValue(Constants.MedicalNetKey, GetType(String)))
            Catch
              MedicalNetKey = String.Empty
            End Try

            Try
              PacsFrmKey = CStr(configReader.GetValue(Constants.PacsFrmKey, GetType(String)))
            Catch
              PacsFrmKey = String.Empty
            End Try
         End Sub

         Private Shared Sub ReadWorkstationClientConfig(ByVal configReader As AppSettingsReader)
            Try
              Try
                WorkstationClient.AETitle = CStr(configReader.GetValue(Constants.WorkstationAETitle, GetType(String)))
              Catch
                WorkstationClient.AETitle = "LTSTATION_CLIENT"
              End Try

              Try
                WorkstationClient.Address = ValidateAndGetValidHostAddress(CStr(configReader.GetValue(Constants.WorkstationAddress, GetType(String))))
              Catch
                WorkstationClient.Address = Dns.GetHostName()
              End Try

              Try
                WorkstationClient.Port = CInt(Fix(configReader.GetValue(Constants.WorkstationPort, GetType(Integer))))
              Catch
                WorkstationClient.Port = 1000
              End Try
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
         End Sub

         Private Shared Sub ReadConfiguredPacs(ByVal configReader As AppSettingsReader)
            Try
              Dim scpServers As String

              Try
                scpServers = CStr(configReader.GetValue(Constants.PacsServers, GetType(String)))
              Catch
                scpServers = ""
              End Try

              If (Not String.IsNullOrEmpty(scpServers)) Then
                Dim serversArray() As String


                serversArray = scpServers.Split(";"c)

                For Each server As String In serversArray
                  Dim serverInfoArray() As String


                  serverInfoArray = server.Split(","c)

                  If serverInfoArray.Length <> 6 Then
                     Continue For
                  End If

                  PACS.Add(New ScpInfo(serverInfoArray(0), serverInfoArray(1), Integer.Parse(serverInfoArray(2)), Integer.Parse(serverInfoArray(3))))

                  If Integer.Parse(serverInfoArray(4)) = 1 Then
                     DefaultQueryRetrieveServer = PACS(PACS.Count - 1)
                  End If

                  If Integer.Parse(serverInfoArray(5)) = 1 Then
                     DefaultStorageServer = PACS(PACS.Count - 1)
                  End If
                Next server
              End If

              Try
                If ConfigurationManager.AppSettings.AllKeys.Contains(Constants.ActivePacs) Then
                  __ActivePacsIndex = CInt(Fix(configReader.GetValue(Constants.ActivePacs, GetType(Integer))))
                End If
              Catch
                __ActivePacsIndex = -1
              End Try
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              Throw
            End Try
         End Sub

         Private Shared Sub ReadDebugConfig(ByVal configReader As AppSettingsReader)
            Try
              Dim debugInfo As String

              Try
                debugInfo = CStr(configReader.GetValue(Constants.DebugInfo, GetType(String)))

                debugInfo = debugInfo.Trim()
              Catch
                debugInfo = ""
              End Try

              If (Not String.IsNullOrEmpty(debugInfo)) Then
                Dim debugInfoArray() As String


                debugInfoArray = debugInfo.Split(";"c)

                If debugInfoArray.Length = 4 Then
                  Debugging.Enable = Boolean.Parse(debugInfoArray(0))
                  Debugging.DisplayDetailedErrors = Boolean.Parse(debugInfoArray(1))
                  Debugging.GenerateLogFile = Boolean.Parse(debugInfoArray(2))
                  Debugging.LogFileName = debugInfoArray(3)
                End If
              End If
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              Debugging.Enable = False
            End Try
         End Sub

         Private Shared Sub ReadCompressionConfig(ByVal configReader As AppSettingsReader)
            Try
              Dim compressionInfo As String

              Try
                compressionInfo = CStr(configReader.GetValue(Constants.CompressionInfo, GetType(String)))

                compressionInfo = compressionInfo.Trim(";"c)
                compressionInfo = compressionInfo.Trim()
              Catch
                compressionInfo = ""
              End Try

              If (Not String.IsNullOrEmpty(compressionInfo)) Then
                Dim compressionInfoArray() As String


                compressionInfoArray = compressionInfo.Split(";"c)

                If compressionInfoArray.Length = 2 Then
                  Compression.Enable = Boolean.Parse(compressionInfoArray(0))
                  Compression.Lossy = Boolean.Parse(compressionInfoArray(1))
                End If
              End If
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              Compression.Enable = False
            End Try
         End Sub

         Private Shared Sub ReadGeneralConfigData(ByVal configReader As AppSettingsReader)
            Try
              Try
                ApplicationName = TryCast(configReader.GetValue(Constants.ApplicationName, GetType(String)), String)

                If String.IsNullOrEmpty(ApplicationName) Then
                  ApplicationName = DefaultValues.ApplicationName
                End If
              Catch
                ApplicationName = DefaultValues.ApplicationName
              End Try

              Try
                HelpFile = TryCast(configReader.GetValue(Constants.HelpFile, GetType(String)), String)
              Catch
                HelpFile = Nothing
              End Try

              Try
                DatabaseConfigName = TryCast(configReader.GetValue(Constants.DatabaseConfigName, GetType(String)), String)

                If String.IsNullOrEmpty(DatabaseConfigName) Then
                  DatabaseConfigName = DefaultValues.DatabaseConfigName
                End If
              Catch
                DatabaseConfigName = DefaultValues.DatabaseConfigName
              End Try

              Try
                DatabaseConfigEXEName = TryCast(configReader.GetValue(Constants.DatabaseConfigEXEName, GetType(String)), String)

                If String.IsNullOrEmpty(DatabaseConfigEXEName) Then
                  DatabaseConfigEXEName = DefaultValues.DatabaseConfigEXEName
                End If
              Catch
                DatabaseConfigEXEName = DefaultValues.DatabaseConfigEXEName
              End Try

              Try
                DatabaseConfigAltEXEName = TryCast(configReader.GetValue(Constants.DatabaseConfigAltEXEName, GetType(String)), String)

                If String.IsNullOrEmpty(DatabaseConfigAltEXEName) Then
                  DatabaseConfigAltEXEName = DefaultValues.DatabaseConfigAltEXEName
                End If
              Catch
                DatabaseConfigEXEName = DefaultValues.DatabaseConfigEXEName
              End Try

              Try
                RunPacsConfig = Boolean.Parse(CStr(configReader.GetValue(Constants.RunPacsConfig, GetType(String))))

              Catch
                RunPacsConfig = False
              End Try

              Try
                MoveToWSClient = Boolean.Parse(CStr(configReader.GetValue(Constants.MoveToWSClient, GetType(String))))
              Catch
                MoveToWSClient = False
              End Try

              Try
                SetClientToAllWorkstations = Boolean.Parse(CStr(configReader.GetValue(Constants.SetClientToAllWS, GetType(String))))
              Catch
                SetClientToAllWorkstations = False
              End Try

              Try
                ClientBrowsingMode = CType(System.Enum.Parse(GetType(DicomClientMode), CStr(configReader.GetValue(Constants.ClientBrowsingMode, GetType(String)))), DicomClientMode)
              Catch
                ClientBrowsingMode = DicomClientMode.LocalDb
              End Try

              Try
                RunFullScreen = Boolean.Parse(CStr(configReader.GetValue(Constants.RunFullScreen, GetType(String))))
              Catch
                RunFullScreen = False
              End Try

              Try
                QueueAutoLoad = Boolean.Parse(CStr(configReader.GetValue(Constants.QueueAutoLoad, GetType(String))))
              Catch
                QueueAutoLoad = False
              End Try

              Try
                QueueRemoveItem = Boolean.Parse(CStr(configReader.GetValue(Constants.QueueRemoveItem, GetType(String))))
              Catch
                QueueRemoveItem = False
              End Try

              Try
                ContinueRetrieveOnDuplicateInstance = Boolean.Parse(CStr(configReader.GetValue(Constants.ContinueRetrieveOnDuplicateInstance, GetType(String))))
              Catch
                ContinueRetrieveOnDuplicateInstance = False
              End Try

              Try
                If ConfigurationManager.AppSettings.AllKeys.Contains(Constants.SaveSessionBehavior) Then
                  SaveSessionBehavior = CType(System.Enum.Parse(GetType(SaveOptions), TryCast(configReader.GetValue(Constants.SaveSessionBehavior, GetType(String)), String)), SaveOptions)
                Else
                  SaveSessionBehavior = SaveOptions.PromptUser
                End If
              Catch
                SaveSessionBehavior = SaveOptions.PromptUser
              End Try
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              Throw
            End Try
         End Sub

         Private Shared Sub ReadLazyLoadingConfigData(ByVal configReader As AppSettingsReader)
            Try
              ViewerLazyLoading.Enable = CBool(Boolean.Parse(CStr(configReader.GetValue(Constants.EnableLazyLoading, GetType(String)))))
            Catch
              ViewerLazyLoading.Enable = True
            End Try

            Try
              ViewerLazyLoading.HiddenImages = Integer.Parse(CStr(configReader.GetValue(Constants.LazyLoadingHiddenImages, GetType(String))))
            Catch
              ViewerLazyLoading.HiddenImages = 2
            End Try

         End Sub

         Private Shared Sub ReadAutoCreateServiceConfigData(ByVal configReader As AppSettingsReader)
            Try
              AutoCreateService = CBool(Boolean.Parse(CStr(configReader.GetValue(Constants.AutoCreateService, GetType(String)))))
            Catch
              AutoCreateService = True
            End Try

            Try
              ListenerServiceName = CStr(configReader.GetValue(Constants.WorkstationServiceName, GetType(String)))
            Catch
              ListenerServiceName = ""
            End Try

            Try
              WorkstationServiceAE = CStr(configReader.GetValue(Constants.WorkstationServiceAE, GetType(String)))
            Catch
              WorkstationServiceAE = ""
            End Try

            Try
              ListenerServiceDefaultName = CStr(configReader.GetValue(Constants.DefualtServiceName, GetType(String)))
            Catch
              ListenerServiceDefaultName = "LTSTATION_SERVER"
            End Try

            Try
              ListenerServiceDefaultDisplayName = CStr(configReader.GetValue(Constants.DefualtServiceDisplay, GetType(String)))
            Catch
              ListenerServiceDefaultDisplayName = "LEADTOOLS Workstation Listener Service"
            End Try
         End Sub


         Private Shared Sub ReadOverlayTextSizeConfigData(ByVal configReader As AppSettingsReader)
            Try
              ViewerOverlayTextSize = Integer.Parse(CStr(configReader.GetValue(Constants.ViewerOverlayTextSize, GetType(String))))
            Catch
              ViewerOverlayTextSize = 14
            End Try

            Try
              ViewerAutoSizeOverlayText = Boolean.Parse(CStr(configReader.GetValue(Constants.ViewerAutoSizeOverlayText, GetType(String))))
            Catch
              ViewerAutoSizeOverlayText = True
            End Try
         End Sub

         Private Shared Sub AddConfigValue(ByVal config As System.Configuration.Configuration, ByVal keys As List(Of String), ByVal key As String, ByVal value As String)
            Try
              If keys.Contains(key) Then
                config.AppSettings.Settings(key).Value = value
              Else
                config.AppSettings.Settings.Add(key, value)

              End If
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              Throw
            End Try
         End Sub

         Private Shared Sub OnValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            _isDirty = True

            If Nothing IsNot ValueChangedEvent Then
              RaiseEvent ValueChanged(Nothing, New EventArgs())
            End If
         End Sub

         Private Shared Function ValidateAndGetValidHostAddress(ByVal testAddress As String) As String
            Dim validAddress As String


            validAddress = Dns.GetHostName()

            If validAddress.ToLower() = testAddress.ToLower() Then
              Return testAddress
            Else
              Dim localIpAddress() As IPAddress = Dns.GetHostAddresses(validAddress)

              For Each address As IPAddress In localIpAddress
                If address.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                  If testAddress = address.ToString() Then
                     Return testAddress
                  End If
                End If
              Next address
            End If

            Return validAddress
         End Function

#End Region

#Region "Properties"

         Private Shared private__ActivePacsIndex As Integer
         Private Shared Property __ActivePacsIndex() As Integer
            Get
               Return private__ActivePacsIndex
            End Get
            Set(ByVal value As Integer)
               private__ActivePacsIndex = value
            End Set
         End Property

#End Region

#Region "Events"

         Private Shared Sub PacsConfiguration_ListChanged(ByVal sender As Object, ByVal e As ListChangedEventArgs)
            Try
              If Nothing IsNot DefaultStorageServer AndAlso (Not PACS.Contains(DefaultStorageServer)) Then
                DefaultStorageServer = Nothing
              End If

              If Nothing IsNot DefaultQueryRetrieveServer AndAlso (Not PACS.Contains(DefaultQueryRetrieveServer)) Then
                DefaultQueryRetrieveServer = Nothing
              End If

              OnValueChanged(Nothing, New EventArgs())
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              Throw
            End Try
         End Sub

#End Region

#Region "Data Members"

         Private Shared _pacs As IList(Of ScpInfo)
         Private Shared _workstationClient As ScuInfo
         Private Shared _defaultStorageServer As ScpInfo
         Private Shared _defaultQueryRetrieveServer As ScpInfo
         Private Shared _clientMode As DicomClientMode
         Private Shared _debuggingConfig As DebuggingConfig
         Private Shared _compression As StorageCompression
         Private Shared _viewerLazyLoading As LazyLoading
         Private Shared _runFullScreen As Boolean
         Private Shared _queueAutoLoad As Boolean
         Private Shared _queueRemoveItem As Boolean
         Private Shared _storeRetrievedImages As Boolean
         Private Shared _autoCreateService As Boolean
         Private Shared _moveToClient As Boolean
         Private Shared _setClientToAllWS As Boolean
         Private Shared _isDirty As Boolean = False
         Private Shared _medicalNetKey As String
         Private Shared _pacsFrmKey As String
         Private Shared _workstationServiceAE As String
         Private Shared _listenerServiceName As String
         Private Shared _listenerServiceDefaultName As String
         Private Shared _listenerServiceDisplayName As String
         Private Shared _appName As String
         Private Shared _viewerAutoSizeOverlayText As Boolean
         Private Shared _viewerOverlayTextSize As Integer
         Private Shared _saveConfigBehavior As SaveOptions

#End Region

#Region "Data Types Definition"

         Private MustInherit Class Constants
            Public Const MedicalNetKey As String = "MedicalNetKey"
            Public Const PacsFrmKey As String = "PacsFrmKey"
            Public Const ScpServerFormat As String = "{0},{1},{2},{3},{4},{5};"
            Public Const PacsServers As String = "PacsServers"
            Public Const WorkstationAETitle As String = "WsAETitle"
            Public Const WorkstationPort As String = "WsPort"
            Public Const WorkstationAddress As String = "WsAddress"
            Public Const DebugInfo As String = "DebugInfo"
            Public Const CompressionInfo As String = "CompressionInfo"
            Public Const ApplicationName As String = "ApplicationName"

            Public Const DatabaseConfigName As String = "DatabaseConfigName"
            Public Const DatabaseConfigEXEName As String = "DatabaseConfigEXENam"
            Public Const DatabaseConfigAltEXEName As String = "DatabaseConfigAltEXENam"
            Public Const RunPacsConfig As String = "RunPacsConfig"
            Public Const MoveToWSClient As String = "MoveToWSClient"
            Public Const SetClientToAllWS As String = "SetClientToAllWS"
            Public Const ClientBrowsingMode As String = "ClientBrowsingMode"
            Public Const RunFullScreen As String = "RunFullScreen"
            Public Const QueueAutoLoad As String = "QueueAutoLoad"
            Public Const QueueRemoveItem As String = "QueueRemoveItem"
            Public Const EnableLazyLoading As String = "EnableLazyLoading"
            Public Const AutoCreateService As String = "AutoCreateListenerService"
            Public Const WorkstationServiceAE As String = "WorkstationServiceAE"
            Public Const DefualtServiceName As String = "DefaultListenerServiceName"
            Public Const WorkstationServiceName As String = "WorkstationServiceName"
            Public Const DefualtServiceDisplay As String = "DefaultListenerServiceDisplayName"
            Public Const ActivePacs As String = "ActivePacs"
            Public Const LazyLoadingHiddenImages As String = "LazyLoadingHiddenImages"
            Public Const ContinueRetrieveOnDuplicateInstance As String = "ContinueRetrieveOnDuplicateInstance"

            Public Const ViewerOverlayTextSize As String = "ViewerOverlayTextSize"
            Public Const ViewerAutoSizeOverlayText As String = "ViewerAutoSizeOverlayText"
            Public Const HelpFile As String = "HelpFile"
            Public Const SaveSessionBehavior As String = "SaveSessionBehavior"
         End Class

         Private MustInherit Class DefaultValues
            Public Const ApplicationName As String = "Medical Workstation Viewer Main Demo"
            Public Const DatabaseConfigName As String = "CSPacsDatabaseConfigurationDemo"
            Public Const DatabaseConfigEXEName As String = "CSPacsDatabaseConfigurationDemo_Original.exe"
            Public Const DatabaseConfigAltEXEName As String = "CSPacsDatabaseConfigurationDemo.exe"
         End Class

#End Region

#End Region

#Region "internal"

#Region "Methods"

         Friend Shared Sub Save()

            Try
              Dim config As System.Configuration.Configuration
              Dim pacsServers As String = String.Empty
              Dim debugging As String = String.Empty
              Dim compression As String = String.Empty


              For Each scp As ScpInfo In PACS
                pacsServers &= String.Format(Constants.ScpServerFormat, scp.AETitle, scp.Address, scp.Port, scp.Timeout, If((scp Is DefaultQueryRetrieveServer), 1, 0), If((scp Is DefaultStorageServer), 1, 0))
              Next scp

              debugging = String.Format("{0};{1};{2};{3}", ConfigurationData.Debugging.Enable.ToString(), ConfigurationData.Debugging.DisplayDetailedErrors.ToString(), ConfigurationData.Debugging.GenerateLogFile.ToString(), ConfigurationData.Debugging.LogFileName)

              compression = String.Format("{0};{1}", ConfigurationData.Compression.Enable.ToString(), ConfigurationData.Compression.Lossy.ToString())

              config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

              Dim keys As New List(Of String)(config.AppSettings.Settings.AllKeys)


              AddConfigValue(config, keys, Constants.WorkstationAETitle, WorkstationClient.AETitle)
              AddConfigValue(config, keys, Constants.WorkstationAddress, WorkstationClient.Address)
              AddConfigValue(config, keys, Constants.WorkstationPort, WorkstationClient.Port.ToString())
              AddConfigValue(config, keys, Constants.PacsServers, pacsServers)
              AddConfigValue(config, keys, Constants.DebugInfo, debugging)
              AddConfigValue(config, keys, Constants.CompressionInfo, compression)
              AddConfigValue(config, keys, Constants.ApplicationName, ApplicationName)
              AddConfigValue(config, keys, Constants.HelpFile, HelpFile)
              AddConfigValue(config, keys, Constants.DatabaseConfigName, DatabaseConfigName)
              AddConfigValue(config, keys, Constants.DatabaseConfigEXEName, DatabaseConfigEXEName)
              AddConfigValue(config, keys, Constants.DatabaseConfigAltEXEName, DatabaseConfigAltEXEName)
              AddConfigValue(config, keys, Constants.RunPacsConfig, RunPacsConfig.ToString())
              AddConfigValue(config, keys, Constants.MoveToWSClient, MoveToWSClient.ToString())
              AddConfigValue(config, keys, Constants.SetClientToAllWS, SetClientToAllWorkstations.ToString())
              AddConfigValue(config, keys, Constants.ClientBrowsingMode, ClientBrowsingMode.ToString())
              AddConfigValue(config, keys, Constants.RunFullScreen, RunFullScreen.ToString())
              AddConfigValue(config, keys, Constants.QueueAutoLoad, QueueAutoLoad.ToString())
              AddConfigValue(config, keys, Constants.QueueRemoveItem, QueueRemoveItem.ToString())
              AddConfigValue(config, keys, Constants.ContinueRetrieveOnDuplicateInstance, ContinueRetrieveOnDuplicateInstance.ToString())
              AddConfigValue(config, keys, Constants.EnableLazyLoading, ViewerLazyLoading.Enable.ToString())
              AddConfigValue(config, keys, Constants.AutoCreateService, AutoCreateService.ToString())
              AddConfigValue(config, keys, Constants.LazyLoadingHiddenImages, ViewerLazyLoading.HiddenImages.ToString())
              AddConfigValue(config, keys, Constants.ViewerOverlayTextSize, ViewerOverlayTextSize.ToString())
              AddConfigValue(config, keys, Constants.ViewerAutoSizeOverlayText, ViewerAutoSizeOverlayText.ToString())
              AddConfigValue(config, keys, Constants.ActivePacs, __ActivePacsIndex.ToString())
              AddConfigValue(config, keys, Constants.SaveSessionBehavior, SaveSessionBehavior.ToString())
              AddConfigValue(config, keys, Constants.DefualtServiceDisplay, ListenerServiceDefaultDisplayName)
              AddConfigValue(config, keys, Constants.DefualtServiceName, ListenerServiceDefaultName)
              AddConfigValue(config, keys, Constants.WorkstationServiceName, ListenerServiceName)
              AddConfigValue(config, keys, Constants.WorkstationServiceAE, WorkstationServiceAE)

              config.Save(ConfigurationSaveMode.Modified)

              ConfigurationManager.RefreshSection("appSettings")

              _isDirty = False

              OnChangesSaved()
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)

              Throw
            End Try
         End Sub

         Private Shared Sub OnChangesSaved()
            If Nothing IsNot ChangesSavedEvent Then
              RaiseEvent ChangesSaved()
            End If
         End Sub

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

   <Serializable> _
   Public Class ScpInfo
	  Public Sub New()
		  Me.New("", Nothing, 1000, 30)

	  End Sub

	  Public Sub New(ByVal aeTitle As String, ByVal address As String, ByVal port As Integer, ByVal timeout As Integer)
		 Me.AETitle = aeTitle
		 Me.Address = address
		 Me.Port = port
		 Me.Timeout = timeout
	  End Sub

	  Public Property Address() As String
		  Get
			Return _address
		  End Get

		  Set(ByVal value As String)

			If _address Is Nothing OrElse (value.ToString () <> _address.ToString ()) Then
			   _address = value

			   OnValueChanged ()
			End If
		  End Set
	  End Property

	  Public Property AETitle() As String
		 Get
			Return _aeTitle
		 End Get

		 Set(ByVal value As String)
			If value <> _aeTitle Then
			   _aeTitle = value

			   OnValueChanged ()
			End If
		 End Set
	  End Property

	  Public Property Port() As Integer
		 Get
			Return _port
		 End Get

		 Set(ByVal value As Integer)
			If _port <> value Then
			   _port = value

			   OnValueChanged ()
			End If
		 End Set
	  End Property

	  Public Property Timeout() As Integer
		 Get
			Return _timeout
		 End Get

		 Set(ByVal value As Integer)
			If _timeout <> value Then
			   _timeout = value

			   OnValueChanged ()
			End If
		 End Set
	  End Property

	  Public Overrides Function ToString() As String
		 Return AETitle
	  End Function

	  Private Sub OnValueChanged()
		 If Nothing IsNot ValueChangedEvent Then
			RaiseEvent ValueChanged(Me, New EventArgs ())
		 End If
	  End Sub

	  Public Event ValueChanged As EventHandler

	  Private _address As String
	  Private _aeTitle As String
	  Private _port As Integer
	  Private _timeout As Integer


	  Public Overrides Overloads Function Equals(ByVal obj As Object) As Boolean
		 Try
			Dim scpObj As ScpInfo


			scpObj = TryCast(obj, ScpInfo)

			If Nothing Is scpObj Then
			   Return False
			End If

			Return (Me.AETitle = scpObj.AETitle AndAlso Me.Address = scpObj.Address AndAlso Me.Port = scpObj.Port AndAlso Me.Timeout = scpObj.Timeout)
		 Catch e1 As Exception
			Return False
		 End Try
	  End Function

	  Public Overrides Function GetHashCode() As Integer
		 Return AETitle.GetHashCode () Xor Address.GetHashCode () Xor Port.GetHashCode () Xor Timeout.GetHashCode ()
	  End Function
   End Class


   <Serializable> _
   Public Class ScuInfo
	  Public Sub New()

	  End Sub


	  Friend Function ToAeInfo() As AeInfo
		 Dim ae As New AeInfo()

		 ae.Address = Address
		 ae.AETitle = AETitle
		 ae.Port = Port
		 ae.SecurePort = 0

		 Return ae
	  End Function

	  Friend Function ToDicomAE() As DicomAE
		 Dim ae As New DicomAE()

		 ae.AE = AETitle
		 ae.IPAddress = Address
		 ae.Port = Port

		 Return ae
	  End Function

	  Public Property Address() As String
		 Get
			Return _address
		 End Get

		 Set(ByVal value As String)
			If value <> _address Then
			   _address = value

			   OnValueChanged ()
			End If
		 End Set
	  End Property

	  Public Property AETitle() As String
		 Get
			Return _aeTitle
		 End Get

		 Set(ByVal value As String)
			If _aeTitle <> value Then
			   _aeTitle = value

			   OnValueChanged ()
			End If
		 End Set
	  End Property

	  Public Property Port() As Integer
		 Get
			Return _port
		 End Get

		 Set(ByVal value As Integer)
			If _port <> value Then
			   _port = value

			   OnValueChanged ()
			End If
		 End Set
	  End Property

	  Private Sub OnValueChanged()
		 If Nothing IsNot ValueChangedEvent Then
			RaiseEvent ValueChanged(Me, New EventArgs ())
		 End If
	  End Sub

	  Public Event ValueChanged As EventHandler
	  Private _address As String = String.Empty
	  Private _aeTitle As String = String.Empty
	  Private _port As Integer = -1
   End Class

   Friend Class ScpInfoBindingList
	   Inherits BindingList(Of ScpInfo)
	  Protected Overrides Sub InsertItem(ByVal index As Integer, ByVal item As ScpInfo)
		 MyBase.InsertItem(index, item)

		 AddHandler item.ValueChanged, AddressOf item_ValueChanged
	  End Sub

	  Private Sub item_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
		 If Nothing IsNot ScpValueChangedEvent Then
			RaiseEvent ScpValueChanged(sender, New EventArgs ())
		 End If
	  End Sub

	  Protected Overrides Sub RemoveItem(ByVal index As Integer)
		 If index >= 0 AndAlso index < Count Then
			RemoveHandler Me(index).ValueChanged, AddressOf item_ValueChanged
		 End If

		 MyBase.RemoveItem(index)
	  End Sub

	  Public Event ScpValueChanged As EventHandler
   End Class

   Public Enum SaveOptions
	  AlwaysSave
	  NeverSave
	  PromptUser
   End Enum
End Namespace
