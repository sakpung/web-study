' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports System.Linq
Imports Leadtools.Medical.Workstation
Imports Leadtools.Medical.Workstation.UI
Imports Leadtools.Demos.Workstation.Configuration
Imports Leadtools.Medical.Workstation.Commands
Imports Leadtools.Medical.Workstation.UI.Commands
Imports Leadtools.Medical.Winforms
Imports Leadtools.Medical.Storage.DataAccessLayer
Imports Leadtools.Medical.Workstation.Client
Imports Leadtools.DicomDemos
Imports Leadtools.Medical.DataAccessLayer
Imports Leadtools.Medical.Storage.DataAccessLayer.Configuration
Imports Leadtools.Dicom.Scu
Imports Leadtools.Dicom.Scu.Common
Imports Leadtools.Medical.Workstation.Client.Pacs
Imports Leadtools.Medical.Workstation.Loader
Imports Leadtools.Dicom
Imports Leadtools.MedicalViewer
Imports Leadtools.ImageProcessing
Imports Leadtools.Drawing
Imports Leadtools.Codecs
Imports Leadtools.Medical.Workstation.DataAccessLayer.Configuration
Imports Leadtools.Medical.Workstation.DataAccessLayer
Imports System.IO
Imports Leadtools.Medical.Workstation.UI.Factory



Namespace Leadtools.Demos.Workstation
   Partial Public Class WorkStationContainer
      Inherits UserControl
      Implements IWorkstationContainer
#Region "Public"

#Region "Methods"

         Public Sub New()
            Try
              InitializeComponent()

              If _DesignMode Then
                Return
              End If

              Init()

              RegisterEvents()

              'SearchButton.PerformClick ( ) ;
            Catch exception As Exception
              System.Diagnostics.Debug.Assert(False, exception.Message)
              Throw
            End Try
         End Sub

         Public Sub SetHelpNamescpace(ByVal helpNamespace As String) Implements IWorkstationContainer.SetHelpNamescpace
            Try
              _helpProvider.HelpNamespace = ConfigurationData.HelpFile

              _helpProvider.SetShowHelp(Me, True)
            Catch exception As Exception
              ThreadSafeMessager.ShowError(exception.Message)
            End Try
         End Sub

         Public Sub OnFullScreenChanged(ByVal isFullScreen As Boolean) Implements IWorkstationContainer.OnFullScreenChanged
            Try
              If isFullScreen Then
                ItemsToolTip.SetToolTip(FullScreenButton, "Go Normal Window")
              Else
                ItemsToolTip.SetToolTip(FullScreenButton, "Go Full Screen")
              End If
            Catch exception As Exception
              ThreadSafeMessager.ShowError(exception.Message)
            End Try
         End Sub

         Public Sub OnDisplayedControlChanged(ByVal uiElement As String) Implements IWorkstationContainer.OnDisplayedControlChanged
            Try
              Me.BackColor = ControlsDisplayPanel.BackColor

              For Each control As Control In ContainerItemsAutoHidePanel.Controls
                If TypeOf control Is Button Then
                  If control.BackColor = Color.LightGray Then
                     control.BackColor = Color.DimGray
                  End If
                End If
              Next control

              If _buttonsFeatures.ContainsKey(uiElement) Then
                _buttonsFeatures(uiElement).BackColor = Color.LightGray
              End If
            Catch exception As Exception
              ThreadSafeMessager.ShowError(exception.Message)
            End Try
         End Sub
#End Region

#Region "Properties"

         Public ReadOnly Property WorkstationViewerButton() As Button
            Get
              Return ViewerButton
            End Get
         End Property

         Public ReadOnly Property SearchStudiesButton() As Button
            Get
              Return SearchButton
            End Get
         End Property

         Public ReadOnly Property WorkstationConfigurationButton() As Button
            Get
              Return ConfigurationButton
            End Get
         End Property

         Public ReadOnly Property WorkstationLogOutButton() As Button
            Get
              Return LogOutButton
            End Get
         End Property

         Public ReadOnly Property WorkstationQueueManagerButton() As Button
            Get
              Return QueueManagerButton
            End Get
         End Property

         Public ReadOnly Property WorkstationMediaBurningButton() As Button
            Get
              Return MediaBurningButton
            End Get
         End Property

         Public ReadOnly Property WorkstationFullScreenButton() As Button
            Get
              Return FullScreenButton
            End Get
         End Property

         Public ReadOnly Property WorkstationListenerServiceButton() As Button
            Get
              Return StorageServiceButton
            End Get
         End Property

         Public ReadOnly Property WorkstationUsersManagementButton() As Button
            Get
              Return UserAccessButton
            End Get
         End Property


         Public ReadOnly Property DisplayContainer() As Control Implements IWorkstationContainer.DisplayContainer
            Get
               Return ControlsDisplayPanel
            End Get
         End Property

         Public WriteOnly Property CanSearch() As Boolean Implements IWorkstationContainer.CanSearch
            Set(ByVal value As Boolean)
               SearchStudiesButton.Visible = value
            End Set
         End Property

         Public WriteOnly Property CanViewImages() As Boolean Implements IWorkstationContainer.CanViewImages
            Set(ByVal value As Boolean)
               WorkstationViewerButton.Visible = value
            End Set
         End Property

         Public WriteOnly Property CanConfigure() As Boolean Implements IWorkstationContainer.CanConfigure
            Set(ByVal value As Boolean)
               WorkstationConfigurationButton.Visible = value
            End Set
         End Property

         Public WriteOnly Property CanManageUsers() As Boolean Implements IWorkstationContainer.CanManageUsers
            Set(ByVal value As Boolean)
               WorkstationUsersManagementButton.Visible = value
            End Set
         End Property

         Public WriteOnly Property CanManageService() As Boolean Implements IWorkstationContainer.CanManageService
            Set(ByVal value As Boolean)
               WorkstationListenerServiceButton.Visible = value
            End Set
         End Property

         Public WriteOnly Property CanCreateMedia() As Boolean Implements IWorkstationContainer.CanCreateMedia
            Set(ByVal value As Boolean)
               WorkstationMediaBurningButton.Visible = value
            End Set
         End Property

         Public WriteOnly Property CanViewQueueManager() As Boolean Implements IWorkstationContainer.CanViewQueueManager
            Set(ByVal value As Boolean)
               WorkstationQueueManagerButton.Visible = value
            End Set
         End Property

         Public WriteOnly Property CanDisplayHelp() As Boolean Implements IWorkstationContainer.CanDisplayHelp
            Set(ByVal value As Boolean)
               WSHelpButton.Visible = value
            End Set
         End Property

         Public WriteOnly Property CanToggleFullScreen() As Boolean Implements IWorkstationContainer.CanToggleFullScreen
            Set(ByVal value As Boolean)
               WorkstationFullScreenButton.Visible = value
            End Set
         End Property


#End Region

#Region "Events"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

         Public Event LogOutRequested As EventHandler

         Public Event DoSearch As EventHandler Implements IWorkstationContainer.DoSearch

         Public Event DoDisplayViewer As EventHandler Implements IWorkstationContainer.DoDisplayViewer

         Public Event DoConfigure As EventHandler Implements IWorkstationContainer.DoConfigure

         Public Event DoManageUsers As EventHandler Implements IWorkstationContainer.DoManageUsers

         Public Event DoManageService As EventHandler Implements IWorkstationContainer.DoManageService

         Public Event DoCreateMedia As EventHandler Implements IWorkstationContainer.DoCreateMedia

         Public Event DoViewQueueManager As EventHandler Implements IWorkstationContainer.DoViewQueueManager

         Public Event DoDisplayHelp As EventHandler Implements IWorkstationContainer.DoDisplayHelp

         Public Event DoToggleFullScreen As EventHandler Implements IWorkstationContainer.DoToggleFullScreen

         Public Event ExitFullScreen As EventHandler Implements IWorkstationContainer.ExitFullScreen

         Public Event ViewLoad As EventHandler Implements IWorkstationContainer.ViewLoad


#End Region

#End Region

#Region "Protected"

#Region "Methods"

         Protected Overrides Function ProcessKeyPreview(ByRef m As Message) As Boolean
            Try
              If m.Msg = WM_KEYDOWN AndAlso (m.WParam.ToInt32() = CInt(Fix(Keys.Escape))) Then
                OnExitFullScreen()
              End If

              Return False
            Catch exception As Exception
              ThreadSafeMessager.ShowError(exception.Message)

              Return False
            End Try
         End Function

#End Region

#Region "Properties"

         Protected Overridable Sub OnLogOutRequested(ByVal sender As Object, ByVal e As EventArgs)
            If Nothing IsNot LogOutRequestedEvent Then
              RaiseEvent LogOutRequested(sender, e)
            End If
         End Sub

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

         Private Sub Init()
            Try
              _helpProvider = New HelpProvider()
              __LoadingDataSetState = New ClientQueryDataSet()

              _buttonsFeatures.Add(UIElementKeys.MediaBurningManagerView, MediaBurningButton)
              _buttonsFeatures.Add(UIElementKeys.QueueManager, QueueManagerButton)
              _buttonsFeatures.Add(UIElementKeys.SearchStudies, SearchButton)
              _buttonsFeatures.Add(UIElementKeys.StorageListenerService, StorageServiceButton)
              _buttonsFeatures.Add(UIElementKeys.UsersAccounts, UserAccessButton)
              _buttonsFeatures.Add(UIElementKeys.WorkstationConfiguration, WorkstationConfigurationButton)
              _buttonsFeatures.Add(UIElementKeys.WorkstationViewer, WorkstationViewerButton)
            Catch e1 As Exception
              Throw
            End Try
         End Sub

         Private Sub RegisterEvents()
            Try
              AddHandler LogOutButton.Click, AddressOf btnLogOut_Click

              ViewerButton.Tag = New Action(AddressOf AnonymousMethod1)
              SearchButton.Tag = New Action(AddressOf AnonymousMethod2)
              ConfigurationButton.Tag = New Action(AddressOf AnonymousMethod3)
              UserAccessButton.Tag = New Action(AddressOf AnonymousMethod4)
              FullScreenButton.Tag = New Action(AddressOf AnonymousMethod5)
              QueueManagerButton.Tag = New Action(AddressOf AnonymousMethod6)
              MediaBurningButton.Tag = New Action(AddressOf AnonymousMethod7)
              StorageServiceButton.Tag = New Action(AddressOf AnonymousMethod8)
              WSHelpButton.Tag = New Action(AddressOf AnonymousMethod9)


              AddHandler ViewerButton.Click, AddressOf FeatureButton_Click
              AddHandler SearchButton.Click, AddressOf FeatureButton_Click
              AddHandler ConfigurationButton.Click, AddressOf FeatureButton_Click
              AddHandler UserAccessButton.Click, AddressOf FeatureButton_Click
              AddHandler FullScreenButton.Click, AddressOf FeatureButton_Click
              AddHandler QueueManagerButton.Click, AddressOf FeatureButton_Click
              AddHandler MediaBurningButton.Click, AddressOf FeatureButton_Click
              AddHandler StorageServiceButton.Click, AddressOf FeatureButton_Click
              AddHandler WSHelpButton.Click, AddressOf FeatureButton_Click
              AddHandler Me.Load, AddressOf Me_Load
            Catch e1 As Exception
              Throw
            End Try
         End Sub
         Private Sub AnonymousMethod1()
            OnDoDisplayViewer()
         End Sub
         Private Sub AnonymousMethod2()
            OnDoSearch()
         End Sub
         Private Sub AnonymousMethod3()
            OnDoConfigure()
         End Sub
         Private Sub AnonymousMethod4()
            OnDoManageUsers()
         End Sub
         Private Sub AnonymousMethod5()
            OnDoToggleFullScreen()
         End Sub
         Private Sub AnonymousMethod6()
            OnDoViewQueueManager()
         End Sub
         Private Sub AnonymousMethod7()
            OnDoCreateMedia()
         End Sub
         Private Sub AnonymousMethod8()
            OnDoManageService()
         End Sub
         Private Sub AnonymousMethod9()
            OnDoDisplayHelp()
         End Sub

         Private Sub OnDoSearch()
            If Nothing IsNot DoSearchEvent Then
              RaiseEvent DoSearch(Me, EventArgs.Empty)
            End If
         End Sub

         Private Sub OnDoDisplayViewer()
            If Nothing IsNot DoDisplayViewerEvent Then
              RaiseEvent DoDisplayViewer(Me, EventArgs.Empty)
            End If
         End Sub

         Private Sub OnDoConfigure()
            If Nothing IsNot DoConfigureEvent Then
              RaiseEvent DoConfigure(Me, EventArgs.Empty)
            End If
         End Sub

         Private Sub OnDoManageUsers()
            If Nothing IsNot DoManageUsersEvent Then
              RaiseEvent DoManageUsers(Me, EventArgs.Empty)
            End If
         End Sub

         Private Sub OnDoManageService()
            If Nothing IsNot DoManageServiceEvent Then
              RaiseEvent DoManageService(Me, EventArgs.Empty)
            End If
         End Sub

         Private Sub OnDoCreateMedia()
            If Nothing IsNot DoCreateMediaEvent Then
              RaiseEvent DoCreateMedia(Me, EventArgs.Empty)
            End If
         End Sub

         Private Sub OnDoViewQueueManager()
            If Nothing IsNot DoViewQueueManagerEvent Then
              RaiseEvent DoViewQueueManager(Me, EventArgs.Empty)
            End If
         End Sub

         Private Sub OnDoDisplayHelp()
            If Nothing IsNot DoDisplayHelpEvent Then
              RaiseEvent DoDisplayHelp(Me, EventArgs.Empty)
            End If
         End Sub

         Private Sub OnDoToggleFullScreen()
            If Nothing IsNot DoToggleFullScreenEvent Then
              RaiseEvent DoToggleFullScreen(Me, EventArgs.Empty)
            End If
         End Sub

         Private Sub OnExitFullScreen()
            If Nothing IsNot ExitFullScreenEvent Then
              RaiseEvent ExitFullScreen(Me, EventArgs.Empty)
            End If
         End Sub

#End Region

#Region "Properties"

         Private Property __WorkstationViewer() As WorkstationViewer
            Get
              Return _workstationViewer
            End Get

            Set(ByVal value As WorkstationViewer)
              _workstationViewer = value
            End Set
         End Property

         Private Property __SearchStudies() As SearchStudies
            Get
              Return _searchStudies
            End Get

            Set(ByVal value As SearchStudies)
              _searchStudies = value
            End Set
         End Property

         Private Property __WorkstationConfiguration() As WorkstationConfiguration
            Get
              Return _workstationConfiguration
            End Get

            Set(ByVal value As WorkstationConfiguration)
              _workstationConfiguration = value
            End Set
         End Property

         Private Property __StorageListenerService() As StorageListenerService
            Get
              Return _storageListenerService
            End Get

            Set(ByVal value As StorageListenerService)
              _storageListenerService = value
            End Set
         End Property

         Private Property __WorkstationUsersManagement() As UsersAccounts
            Get
              Return _usersManagement
            End Get

            Set(ByVal value As UsersAccounts)
              _usersManagement = value
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

         Private ReadOnly Property _DesignMode() As Boolean
            Get
              Return (Me.GetService(GetType(IDesignerHost)) IsNot Nothing) OrElse (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime)
            End Get
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

         Private Sub btnLogOut_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try
              OnLogOutRequested(Me, e)
            Catch exception As Exception
              ThreadSafeMessager.ShowError(exception.Message)
            End Try
         End Sub

         Private Sub FeatureButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try
               TryCast((CType(sender, Button)).Tag, Action).Invoke()
            Catch exception As Exception
              ThreadSafeMessager.ShowError(exception.Message)
            End Try
         End Sub

         Private Sub Me_Load(ByVal sender As Object, ByVal e As EventArgs)
            Try
              If Nothing IsNot ViewLoadEvent Then
              RaiseEvent ViewLoad(sender, e)
            End If
            Catch exception As Exception
              ThreadSafeMessager.ShowError(exception.Message)
            End Try
         End Sub

#End Region

#Region "Data Members"

         Private _workstationViewer As WorkstationViewer
         Private _searchStudies As SearchStudies
         Private _workstationConfiguration As WorkstationConfiguration
         Private _storageListenerService As StorageListenerService
         Private _usersManagement As UsersAccounts
         Private _helpProvider As HelpProvider

         Private _buttonsFeatures As New Dictionary(Of String, Button)()

         Private Const WM_KEYDOWN As Integer = &H100

#End Region

#Region "Data Types Definition"

         Private Delegate Sub StartSeriesLoadingDelegate(ByVal patientId As String, ByVal studyInstanceUid As String, ByVal seriesInstanceUid As String, ByVal loader As MedicalViewerLoader)

         Private Class Constants
            Public Const SeriesInfo As String = "{0} ({1}) Series ""{2}"" Modality ""{3}"""
         End Class

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
