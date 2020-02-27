' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Medical.Workstation.UI.Factory
Imports Leadtools.Medical.Workstation.UI
Imports Leadtools.Medical.Winforms
Imports Leadtools.Medical.Workstation.Commands
Imports System.Windows.Forms
Imports Leadtools.Medical.DataAccessLayer
Imports Leadtools.Medical.Workstation.DataAccessLayer
Imports Leadtools.Medical.Storage.DataAccessLayer
Imports Leadtools.Medical.Workstation
Imports Leadtools.Demos.Workstation.Configuration
Imports System.IO
Imports Leadtools.Dicom.Scu
Imports Leadtools.Medical.Workstation.Client.Pacs
Imports Leadtools.Medical.Workstation.UI.Commands
Imports Leadtools.DicomDemos
Imports Leadtools.Dicom.Scu.Common
Imports Leadtools.Medical.Workstation.Client
Imports Leadtools.Dicom
Imports Leadtools.Medical.Workstation.Loader
Imports Leadtools.MedicalViewer
Imports System.Drawing
Imports Leadtools.ImageProcessing
Imports Leadtools.Drawing

Namespace Leadtools.Demos.Workstation
    Friend Class WorkstationContainerPresenter
#Region "Public"

#Region "Methods"

        Public Sub New(ByVal viewparam As IWorkstationContainer, ByVal loadingDataSetState As ClientQueryDataSet)
            View = viewparam

            AddHandler View.ViewLoad, AddressOf View_Load

            __FeaturesCommand = New Dictionary(Of String, ICommand)()
            __LoadingDataSetState = loadingDataSetState
        End Sub

#End Region

#Region "Properties"

        Private privateView As IWorkstationContainer
        Public Property View() As IWorkstationContainer
            Get
                Return privateView
            End Get
            Private Set(ByVal value As IWorkstationContainer)
                privateView = value
            End Set
        End Property

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

        Private Sub UpdateViewUI()

        End Sub

        Private Sub RegisterViewEvents()
            ConfigureSearch()

            ConfigureViewer()

            ConfigureWSConfig()

            ConfigureMediaCreation()

            ConfigureListenerService()

            ConfigureUserAccounts()

            ConfigureQueueManager()

            ConfigureToggleFullScreenFeature()

            ConfigureShowHelpFeature()

            ExecuteFeature(UIElementKeys.SearchStudies)
        End Sub

        Private Sub ConfigureShowHelpFeature()
            If (Not String.IsNullOrEmpty(ConfigurationData.HelpFile)) AndAlso File.Exists(ConfigurationData.HelpFile) Then
                View.SetHelpNamescpace(ConfigurationData.HelpFile)

                View.CanDisplayHelp = True

                AddHandler View.DoDisplayHelp, AddressOf View_DoDisplayHelp
            Else
                View.CanDisplayHelp = False
            End If
        End Sub

        Private Sub ConfigureToggleFullScreenFeature()
            Dim fullScreenCmd As ToggleFullScreenCommand


            fullScreenCmd = New ToggleFullScreenCommand(View.DisplayContainer)

            __FeaturesCommand.Add(FullScreenFeature, fullScreenCmd)

            AddHandler fullScreenCmd.CommandExecuted, AddressOf fullScreenCmd_CommandExecuted

            View.CanToggleFullScreen = True

            AddHandler View.DoToggleFullScreen, AddressOf View_DoToggleFullScreen
            AddHandler View.ExitFullScreen, AddressOf View_ExitFullScreen
        End Sub

        Private Sub ConfigureSearch()
            If WorkstationUIFactory.Instance.IsControlRegistered(UIElementKeys.SearchStudies) Then
                __SearchStudies = WorkstationUIFactory.Instance.GetWorkstsationControl(Of SearchStudies)(UIElementKeys.SearchStudies)

                View.CanSearch = True

                AddHandler View.DoSearch, AddressOf View_DoSearch

                __FeaturesCommand.Add(UIElementKeys.SearchStudies, CreateDisplayControlCommand(__SearchStudies))
            Else
                View.CanSearch = False
            End If
        End Sub

        Private Sub ConfigureViewer()
            If WorkstationUIFactory.Instance.IsControlRegistered(UIElementKeys.WorkstationViewer) Then
                __WorkstationViewer = WorkstationUIFactory.Instance.GetWorkstsationControl(Of WorkstationViewer)(UIElementKeys.WorkstationViewer)
                __WorkstationViewer.Options3D.SupportPanoramic = True

                View.CanViewImages = True

                AddHandler View.DoDisplayViewer, AddressOf View_DoDisplayImages

                If Nothing IsNot __SearchStudies Then
                    AddHandler __SearchStudies.LoadSeries, AddressOf __SearchStudies_LoadSeries
                    AddHandler __SearchStudies.DisplayViewer, AddressOf __SearchStudies_DisplayViewer
                End If

                __FeaturesCommand.Add(UIElementKeys.WorkstationViewer, CreateDisplayControlCommand(__WorkstationViewer))

                AddHandler __WorkstationViewer.SeriesDropLoaderRequested, AddressOf __WorkstationViewer_SeriesDropLoaderRequested
                AddHandler __WorkstationViewer.SeriesLoadingCompleted, AddressOf __WorkstationViewer_SeriesLoadingCompleted
                AddHandler __WorkstationViewer.SeriesLoadingError, AddressOf __WorkstationViewer_SeriesLoadingError
            Else
                View.CanViewImages = False
            End If
        End Sub

        Private Sub ConfigureWSConfig()
            If WorkstationUIFactory.Instance.IsControlRegistered(UIElementKeys.WorkstationConfiguration) Then
                __WorkstationConfiguration = WorkstationUIFactory.Instance.GetWorkstsationControl(Of WorkstationConfiguration)(UIElementKeys.WorkstationConfiguration)

                View.CanConfigure = True

                AddHandler View.DoConfigure, AddressOf View_DoConfigure

                __FeaturesCommand.Add(UIElementKeys.WorkstationConfiguration, CreateDisplayControlCommand(__WorkstationConfiguration))
            Else
                View.CanConfigure = False
            End If
        End Sub

        Private Sub ConfigureMediaCreation()
            If WorkstationUIFactory.Instance.IsControlRegistered(UIElementKeys.MediaBurningManagerView) Then
                __MediaBurningManager = WorkstationUIFactory.Instance.GetWorkstsationControl(Of MediaBurningManagerView)(UIElementKeys.MediaBurningManagerView)

                If Nothing IsNot __SearchStudies AndAlso ConfigurationData.SupportDicomCommunication Then
                    AddHandler __SearchStudies.AddSeriesToMediaBurning, AddressOf __SearchStudies_AddSeriesToMediaBurning
                End If

                View.CanCreateMedia = True

                AddHandler View.DoCreateMedia, AddressOf View_DoCreateMedia

                Dim displayMediaBurningView As ICommand


                displayMediaBurningView = New ShowModelessDialogCommand(View.DisplayContainer, __MediaBurningManager)

                __FeaturesCommand.Add(UIElementKeys.MediaBurningManagerView, displayMediaBurningView)

                __MediaCreationController = New MediaBurningManagerController(__MediaBurningManager, __LoadingDataSetState, displayMediaBurningView)
            Else
                View.CanCreateMedia = False
            End If
        End Sub

        Private Sub ConfigureListenerService()
            If WorkstationUIFactory.Instance.IsControlRegistered(UIElementKeys.StorageListenerService) Then
                __StorageListenerService = WorkstationUIFactory.Instance.GetWorkstsationControl(Of StorageListenerService)(UIElementKeys.StorageListenerService)

                View.CanManageService = True

                AddHandler View.DoManageService, AddressOf View_DoManageService

                __FeaturesCommand.Add(UIElementKeys.StorageListenerService, CreateDisplayControlCommand(__StorageListenerService))
            Else
                View.CanManageService = False
            End If
        End Sub

        Private Sub ConfigureUserAccounts()
            If WorkstationUIFactory.Instance.IsControlRegistered(UIElementKeys.UsersAccounts) Then
                __WorkstationUsersManagement = WorkstationUIFactory.Instance.GetWorkstsationControl(Of UsersAccounts)(UIElementKeys.UsersAccounts)

                View.CanManageUsers = True

                AddHandler View.DoManageUsers, AddressOf View_DoManageUsers

                __FeaturesCommand.Add(UIElementKeys.UsersAccounts, CreateDisplayControlCommand(__WorkstationUsersManagement))
            Else
                View.CanManageUsers = False
            End If
        End Sub

        Private Sub ConfigureQueueManager()
            If WorkstationUIFactory.Instance.IsControlRegistered(UIElementKeys.QueueManager) Then
                __QueueManager = WorkstationUIFactory.Instance.GetWorkstsationControl(Of QueueManager)(UIElementKeys.QueueManager)

                View.CanViewQueueManager = True

                AddHandler View.DoViewQueueManager, AddressOf View_DoViewQueueManager

                If Nothing IsNot __SearchStudies AndAlso ConfigurationData.SupportDicomCommunication Then
                    AddHandler __SearchStudies.StoreSeries, AddressOf __SearchStudies_StoreSeries
                    AddHandler __SearchStudies.RetrieveSeries, AddressOf __SearchStudies_RetrieveSeries
                End If

                AddHandler __QueueManager.SeriesReady, AddressOf Instance_SeriesReady

                __FeaturesCommand.Add(UIElementKeys.QueueManager, New ShowModelessDialogCommand(View.DisplayContainer, __QueueManager))
            Else
                View.CanViewQueueManager = False
            End If
        End Sub

        Private Sub LoadSeriesInViewer(ByVal patientID As String, ByVal studyInstanceUID As String, ByVal seriesInstanceUID As String, ByVal clientMode As DicomClientMode)
            If Nothing Is __WorkstationViewer Then
                Return
            End If

            Dim loader As MedicalViewerLoader


            loader = New MedicalViewerLoader(DicomClientFactory.CreateRetrieveClient(clientMode))

            InitMedicalViewerLoader(loader)

            If __WorkstationViewer.InvokeRequired Then

                __WorkstationViewer.Invoke(New StartSeriesLoadingDelegate(AddressOf __WorkstationViewer.LoadSeries), patientID, studyInstanceUID, seriesInstanceUID, loader)
            Else
                __WorkstationViewer.LoadSeries(patientID, studyInstanceUID, seriesInstanceUID, loader)
            End If
        End Sub

        Private Delegate Sub StartSeriesLoadingDelegate(ByVal patientId As String, ByVal studyInstanceUid As String, ByVal seriesInstanceUid As String, ByVal loader As MedicalViewerLoader)

        Private Sub InitMedicalViewerLoader(ByVal loader As MedicalViewerLoader)
            loader.LazyLoading = ConfigurationData.ViewerLazyLoading.Enable
            loader.ViewerPreLoadedImages = ConfigurationData.ViewerLazyLoading.HiddenImages
            loader.DisplayOrientation = WorkstationShellController.Instance.DisplayOrientation
        End Sub

        Private Function CreateDisplayControlCommand(ByVal displayedControl As Control) As DisplayControlCommand
            Dim command As DisplayControlCommand


            command = New DisplayControlCommand(View.DisplayContainer, displayedControl)

            AddHandler command.DisplayControlExecuted, AddressOf command_DisplayControlExecuted

            Return command
        End Function

        Private Sub command_DisplayControlExecuted(ByVal sender As Object, ByVal e As DisplayControlEventArgs)
            Dim keyValuePait As KeyValuePair(Of String, ICommand) = __FeaturesCommand.Where(Function(n) n.Value Is sender).FirstOrDefault()

            View.OnDisplayedControlChanged(keyValuePait.Key)
        End Sub

        Private Sub ExecuteFeature(ByVal feature As String)
            If __FeaturesCommand.ContainsKey(feature) Then
                __FeaturesCommand(feature).Execute()
            End If
        End Sub

        Private Sub PopulateState(ByVal study As ClientQueryDataSet.StudiesRow, ByVal series As ClientQueryDataSet.SeriesRow)
            If __LoadingDataSetState.Studies.FindByStudyInstanceUID(study.StudyInstanceUID) Is Nothing Then
                __LoadingDataSetState.Studies.ImportRow(study)
            End If

            If __LoadingDataSetState.Series.FindBySeriesInstanceUID(series.SeriesInstanceUID) Is Nothing Then
                __LoadingDataSetState.Series.ImportRow(series)
            End If
        End Sub

        Private Function GetStudyInformation(ByVal study As ClientQueryDataSet.StudiesRow) As StudyInformation
            Dim studyInfo As New StudyInformation(If(study.IsPatientIDNull(), String.Empty, study.PatientID), study.StudyInstanceUID)

            studyInfo.AccessionNumber = If(study.IsAccessionNumberNull(), String.Empty, study.AccessionNumber)
            studyInfo.PatientBirthDate = If(study.IsPatientBirthDateNull(), String.Empty, study.PatientBirthDate)
            studyInfo.PatientName = If(study.IsPatientNameNull(), String.Empty, study.PatientName)
            studyInfo.PatientSex = If(study.IsPatientSexNull(), String.Empty, study.PatientSex)
            studyInfo.ReferringPhysicianName = If(study.IsReferDrNameNull(), String.Empty, study.ReferDrName)
            studyInfo.StudyDate = If(study.IsStudyDateNull(), String.Empty, study.StudyDate)
            studyInfo.StudyDescription = If(study.IsStudyDescriptionNull(), String.Empty, study.StudyDescription)

            Return studyInfo
        End Function

        Private Function GetSeriesInformation(ByVal studyInfo As StudyInformation, ByVal series As ClientQueryDataSet.SeriesRow) As SeriesInformation
            Dim patientID As String = studyInfo.PatientID
            Dim studyInstanceUID As String = studyInfo.StudyInstanceUID
            Dim seriesInstanceUID As String = series.SeriesInstanceUID
            Dim seriesDescription As String = If(series.IsSeriesDescriptionNull(), String.Empty, series.SeriesDescription)

            Dim seriesInfo As New SeriesInformation(patientID, studyInstanceUID, seriesInstanceUID, seriesDescription)

            seriesInfo.Modality = If(series.IsModalityNull(), String.Empty, series.Modality)
            seriesInfo.NumberOfSeriesRelatedInstances = If(series.IsFrameCountNull(), String.Empty, series.FrameCount)
            seriesInfo.SeriesDate = If(series.IsSeriesDateNull(), String.Empty, series.SeriesDate)
            seriesInfo.SeriesNumber = If(series.IsSeriesNumberNull(), String.Empty, series.SeriesNumber)
            seriesInfo.SeriesTime = If(series.IsSeriesTimeNull(), String.Empty, series.SeriesTime)

            Return seriesInfo
        End Function

        Private Shared Sub FillSeriesThumbnail(ByVal e As LoadSeriesEventArgs, ByVal seriesInfo As SeriesInformation)
            If e.LoadedSeries.Streamer.SeriesCells.Length > 0 Then
                Dim cell As MedicalViewerMultiCell = e.LoadedSeries.Streamer.SeriesCells(0)

                If cell.VirtualImage IsNot Nothing Then
                    If cell.VirtualImage(cell.ActiveSubCell).ImageExist Then
                        Using image As RasterImage = cell.VirtualImage(cell.ActiveSubCell).Image.Clone()
                            Dim thumbImage As Image

                            If image.Width <> 64 OrElse image.Height <> 64 Then
                                Dim sizeCommand As SizeCommand


                                sizeCommand = New SizeCommand(64, 64, RasterSizeFlags.None)

                                sizeCommand.Run(image)
                            End If

                            If image.BitsPerPixel <> 24 Then
                                Dim colorRes As New ColorResolutionCommand(ColorResolutionCommandMode.InPlace, 24, RasterByteOrder.Bgr, RasterDitheringMethod.None, ColorResolutionCommandPaletteFlags.FastMatch, Nothing)


                                colorRes.Run(image)
                            End If

                            thumbImage = RasterImageConverter.ConvertToImage(image, ConvertToImageOptions.InitAlpha)

                            seriesInfo.Thumbnail = thumbImage
                        End Using
                    End If
                End If
            End If
        End Sub

#End Region

#Region "Properties"

        Private private__SearchStudies As SearchStudies
        Private Property __SearchStudies() As SearchStudies
            Get
                Return private__SearchStudies
            End Get
            Set(ByVal value As SearchStudies)
                private__SearchStudies = value
            End Set
        End Property

        Private private__WorkstationViewer As WorkstationViewer
        Private Property __WorkstationViewer() As WorkstationViewer
            Get
                Return private__WorkstationViewer
            End Get
            Set(ByVal value As WorkstationViewer)
                private__WorkstationViewer = value
            End Set
        End Property

        Private private__WorkstationConfiguration As WorkstationConfiguration
        Private Property __WorkstationConfiguration() As WorkstationConfiguration
            Get
                Return private__WorkstationConfiguration
            End Get
            Set(ByVal value As WorkstationConfiguration)
                private__WorkstationConfiguration = value
            End Set
        End Property

        Private private__StorageListenerService As StorageListenerService
        Private Property __StorageListenerService() As StorageListenerService
            Get
                Return private__StorageListenerService
            End Get
            Set(ByVal value As StorageListenerService)
                private__StorageListenerService = value
            End Set
        End Property

        Private private__WorkstationUsersManagement As UsersAccounts
        Private Property __WorkstationUsersManagement() As UsersAccounts
            Get
                Return private__WorkstationUsersManagement
            End Get
            Set(ByVal value As UsersAccounts)
                private__WorkstationUsersManagement = value
            End Set
        End Property

        Private private__MediaBurningManager As MediaBurningManagerView
        Private Property __MediaBurningManager() As MediaBurningManagerView
            Get
                Return private__MediaBurningManager
            End Get
            Set(ByVal value As MediaBurningManagerView)
                private__MediaBurningManager = value
            End Set
        End Property

        Private private__QueueManager As QueueManager
        Private Property __QueueManager() As QueueManager
            Get
                Return private__QueueManager
            End Get
            Set(ByVal value As QueueManager)
                private__QueueManager = value
            End Set
        End Property

        Private private__FeaturesCommand As Dictionary(Of String, ICommand)
        Private Property __FeaturesCommand() As Dictionary(Of String, ICommand)
            Get
                Return private__FeaturesCommand
            End Get
            Set(ByVal value As Dictionary(Of String, ICommand))
                private__FeaturesCommand = value
            End Set
        End Property

        Private private__LoadingDataSetState As ClientQueryDataSet
        Private Property __LoadingDataSetState() As ClientQueryDataSet
            Get
                Return private__LoadingDataSetState
            End Get
            Set(ByVal value As ClientQueryDataSet)
                private__LoadingDataSetState = value
            End Set
        End Property

        Private private__MediaCreationController As MediaBurningManagerController
        Private Property __MediaCreationController() As MediaBurningManagerController
            Get
                Return private__MediaCreationController
            End Get
            Set(ByVal value As MediaBurningManagerController)
                private__MediaCreationController = value
            End Set
        End Property

#End Region

#Region "Events"

        Private Sub View_Load(ByVal sender As Object, ByVal e As EventArgs)
            Try
                UpdateViewUI()

                RegisterViewEvents()

                If ConfigurationData.RunFullScreen Then
                    ExecuteFeature(FullScreenFeature)
                End If
            Catch exception As Exception
                ThreadSafeMessager.ShowError(exception.Message)
            End Try
        End Sub

        Private Sub View_DoSearch(ByVal sender As Object, ByVal e As EventArgs)
            ExecuteFeature(UIElementKeys.SearchStudies)
        End Sub

        Private Sub View_DoConfigure(ByVal sender As Object, ByVal e As EventArgs)
            ExecuteFeature(UIElementKeys.WorkstationConfiguration)
        End Sub

        Private Sub View_DoDisplayImages(ByVal sender As Object, ByVal e As EventArgs)
            ExecuteFeature(UIElementKeys.WorkstationViewer)
        End Sub

        Private Sub View_DoCreateMedia(ByVal sender As Object, ByVal e As EventArgs)
            ExecuteFeature(UIElementKeys.MediaBurningManagerView)
        End Sub

        Private Sub View_DoManageService(ByVal sender As Object, ByVal e As EventArgs)
            ExecuteFeature(UIElementKeys.StorageListenerService)
        End Sub

        Private Sub View_DoManageUsers(ByVal sender As Object, ByVal e As EventArgs)
            ExecuteFeature(UIElementKeys.UsersAccounts)
        End Sub

        Private Sub View_DoViewQueueManager(ByVal sender As Object, ByVal e As EventArgs)
            ExecuteFeature(UIElementKeys.QueueManager)
        End Sub

        Private Sub View_DoToggleFullScreen(ByVal sender As Object, ByVal e As EventArgs)
            ExecuteFeature(FullScreenFeature)
        End Sub

        Private Sub View_DoDisplayHelp(ByVal sender As Object, ByVal e As EventArgs)
            Help.ShowHelp(View.DisplayContainer, ConfigurationData.HelpFile)
        End Sub

        Private Sub View_ExitFullScreen(ByVal sender As Object, ByVal e As EventArgs)
            If __FeaturesCommand.ContainsKey(FullScreenFeature) AndAlso TypeOf __FeaturesCommand(FullScreenFeature) Is ToggleFullScreenCommand Then
                Dim cmd As ToggleFullScreenCommand = CType(__FeaturesCommand(FullScreenFeature), ToggleFullScreenCommand)


                If cmd.FullScreen Then
                    ExecuteFeature(FullScreenFeature)
                End If
            End If
        End Sub

        Private Sub fullScreenCmd_CommandExecuted(ByVal sender As Object, ByVal e As EventArgs)
            Try
                View.OnFullScreenChanged((CType(sender, ToggleFullScreenCommand)).FullScreen)
            Catch exception As Exception
                ThreadSafeMessager.ShowError(exception.Message)
            End Try
        End Sub

        Private Sub __SearchStudies_LoadSeries(ByVal sender As Object, ByVal e As ProcessSeriesEventArgs)
            Try
                PopulateState(e.Study, e.Series)

                LoadSeriesInViewer(e.Study.PatientID, e.Study.StudyInstanceUID, e.Series.SeriesInstanceUID, ConfigurationData.ClientBrowsingMode)
            Catch exception As Exception
                ThreadSafeMessager.ShowError(exception.Message)
            End Try

        End Sub

        Private Sub __SearchStudies_StoreSeries(ByVal sender As Object, ByVal e As StoreSeriesEventArgs)
            Try
                PopulateState(e.Study, e.Series)

                If (Not __QueueManager.Visible) Then
                    __QueueManager.Show(View.DisplayContainer)
                End If

                Dim scp As DicomScp
                Dim patientID As String
                Dim description As String
                Dim dataAccess As IStorageDataAccessAgent
                Dim compression As Compression
                Dim storeCommand As StoreQueueItemCommand

                If (Not ConfigurationData.Compression.Enable) Then
                    compression = Leadtools.Dicom.Scu.Common.Compression.Native
                Else
                    compression = If((ConfigurationData.Compression.Lossy), Leadtools.Dicom.Scu.Common.Compression.Lossy, Leadtools.Dicom.Scu.Common.Compression.Lossless)
                End If

                scp = New Leadtools.Dicom.Scu.DicomScp()

                scp.AETitle = e.Server.AETitle
                scp.PeerAddress = Utils.ResolveIPAddress(e.Server.Address)
                scp.Port = e.Server.Port
                scp.Timeout = e.Server.Timeout
                scp.Secure = e.Server.Secure

                patientID = If(e.Study.IsPatientIDNull(), String.Empty, e.Study.PatientID)

                description = String.Format(SeriesInfo, If(e.Study.IsPatientNameNull(), String.Empty, e.Study.PatientName), patientID, If(e.Series.IsSeriesNumberNull(), String.Empty, e.Series.SeriesNumber), If(e.Series.IsModalityNull(), String.Empty, e.Series.Modality))

                dataAccess = DataAccessServices.GetDataAccessService(Of IStorageDataAccessAgent)()

                If Nothing Is dataAccess Then
                    Throw New InvalidOperationException("Storage Service is not registered.")
                End If

                Dim client As New StoreClient(ConfigurationData.WorkstationClient.ToAeInfo(), scp, compression, dataAccess)


                storeCommand = New StoreQueueItemCommand(New SeriesInformation(patientID, e.Study.StudyInstanceUID, e.Series.SeriesInstanceUID, description), client)

                QueueManager.Instance.AddCommand(storeCommand)
            Catch exception As Exception
                ThreadSafeMessager.ShowError(exception.Message)
            End Try
        End Sub

        Private Sub __SearchStudies_RetrieveSeries(ByVal sender As Object, ByVal e As StoreSeriesEventArgs)
            Try
                PopulateState(e.Study, e.Series)

                If (Not __QueueManager.Visible) Then
                    __QueueManager.Show(View.DisplayContainer)
                End If

                Dim scp As DicomScp
                Dim patientID As String
                Dim description As String
                Dim client As PacsRetrieveClient
                Dim retrieveCommand As RetrieveQueueItemCommand


                scp = New DicomScp()

                scp.AETitle = e.Server.AETitle
                scp.PeerAddress = Utils.ResolveIPAddress(e.Server.Address)
                scp.Port = e.Server.Port
                scp.Timeout = e.Server.Timeout

                patientID = If(e.Study.IsPatientIDNull(), String.Empty, e.Study.PatientID)

                description = String.Format(SeriesInfo, If(e.Study.IsPatientNameNull(), String.Empty, e.Study.PatientName), patientID, If(e.Series.IsSeriesNumberNull(), String.Empty, e.Series.SeriesNumber), If(e.Series.IsModalityNull(), String.Empty, e.Series.Modality))


                client = DicomClientFactory.CreatePacsRetrieveClient(scp)

                retrieveCommand = New RetrieveQueueItemCommand(New SeriesInformation(patientID, e.Study.StudyInstanceUID, e.Series.SeriesInstanceUID, description), client)


                __QueueManager.AddCommand(retrieveCommand)
            Catch exception As Exception
                ThreadSafeMessager.ShowError(exception.Message)
            End Try
        End Sub

        Private Sub __SearchStudies_DisplayViewer(ByVal sender As Object, ByVal e As EventArgs)
            Try
                ExecuteFeature(UIElementKeys.WorkstationViewer)
            Catch exception As Exception
                ThreadSafeMessager.ShowError(exception.Message)
            End Try
        End Sub

        Private Sub __SearchStudies_AddSeriesToMediaBurning(ByVal sender As Object, ByVal e As ProcessSeriesEventArgs)
            Try
                __MediaCreationController.AddSeriesToBurningManager(e.Study, e.Series)
            Catch exception As Exception
                ThreadSafeMessager.ShowError(exception.Message)
            End Try
        End Sub

        Private Sub Instance_SeriesReady(ByVal sender As Object, ByVal e As SeriesInformationEventArgs)
            Try
                LoadSeriesInViewer(e.PatientId, e.StudyInstanceUID, e.SeriesInstanceUID, DicomClientMode.LocalDb)
            Catch exception As Exception
                ThreadSafeMessager.ShowError(exception.Message)
            End Try
        End Sub

        Private Sub __WorkstationViewer_SeriesDropLoaderRequested(ByVal sender As Object, ByVal e As SeriesDropLoaderRequestedEventArgs)
            Try
                Dim loader As MedicalViewerLoader


                If (Not ConfigurationData.SupportLocalQueriesStore) Then
                    loader = New MedicalViewerLoader(DicomClientFactory.CreateRetrieveClient())
                Else
                    loader = New MedicalViewerLoader(DicomClientFactory.CreateLocalRetrieveClient())
                End If

                InitMedicalViewerLoader(loader)

                e.SeriesLoader = loader
            Catch exception As Exception
                ThreadSafeMessager.ShowError(exception.Message)
            End Try
        End Sub

        Private Sub __WorkstationViewer_SeriesLoadingError(ByVal sender As Object, ByVal e As LoadSeriesErrorEventArgs)
            If TypeOf e.Error Is Leadtools.Dicom.Scu.Common.ClientCommunicationException Then
                WorkstationMessager.ShowError(View.DisplayContainer, "Series Loading Error" & Constants.vbLf & "." & e.Error.Message + Constants.vbLf & "DICOM Status: " & (TryCast(e.Error, Leadtools.Dicom.Scu.Common.ClientCommunicationException)).Status)

                If WorkstationMessager.DetailedError Then
                    WorkstationMessager.ShowError(View.DisplayContainer, e.Error)
                End If
            ElseIf TypeOf e.Error Is DicomException Then
                WorkstationMessager.ShowError(View.DisplayContainer, "Series Loading Error" & Constants.vbLf & "." & e.Error.Message + Constants.vbLf & "DICOM Error: " & (TryCast(e.Error, DicomException)).Code)

                If WorkstationMessager.DetailedError Then
                    WorkstationMessager.ShowError(View.DisplayContainer, e.Error)
                End If
            Else
                System.Diagnostics.Debug.Assert(False, e.Error.Message)

                WorkstationMessager.ShowError(View.DisplayContainer, e.Error)
            End If

        End Sub

        Private Sub __WorkstationViewer_SeriesLoadingCompleted(ByVal sender As Object, ByVal e As LoadSeriesEventArgs)
            Try
                If SeriesBrowser.Instance.FindSeries(e.LoadedSeries.SeriesInstanceUID) IsNot Nothing Then
                    Return
                End If

                Dim study As ClientQueryDataSet.StudiesRow
                Dim series As ClientQueryDataSet.SeriesRow


                study = __LoadingDataSetState.Studies.FindByStudyInstanceUID(e.LoadedSeries.StudyInstanceUID)
                If study IsNot Nothing Then
                    series = __LoadingDataSetState.Series.FindBySeriesInstanceUID(e.LoadedSeries.SeriesInstanceUID)
                    If series IsNot Nothing Then
                        Dim studyInfo As StudyInformation
                        Dim seriesInfo As SeriesInformation


                        studyInfo = GetStudyInformation(study)
                        seriesInfo = GetSeriesInformation(studyInfo, series)

                        Try
                            FillSeriesThumbnail(e, seriesInfo)
                        Catch e1 As Exception
                        End Try

                        SeriesBrowser.Instance.AddSeries(studyInfo, seriesInfo)
                    End If
                End If
            Catch exception As Exception
                ThreadSafeMessager.ShowError(exception.Message)
            End Try
        End Sub

#End Region

#Region "Data Members"

        Private Const FullScreenFeature As String = "FullScreen"
        Private Const ShowHelpFeature As String = "ShowHelp"
        Private Const SeriesInfo As String = "{0} ({1}) Series ""{2}"" Modality ""{3}"""

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
End Namespace
