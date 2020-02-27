' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Net
Imports System.Net.Sockets
Imports System.Windows.Forms
Imports System.Xml
Imports System.ComponentModel.Design
Imports Leadtools.Dicom.Server.Admin
Imports Leadtools.Dicom.AddIn
Imports Leadtools.Dicom.AddIn.Common
Imports Leadtools.Dicom.AddIn.Interfaces
Imports Leadtools.Medical.Workstation.DataAccessLayer
Imports Leadtools.Medical.Workstation
Imports Leadtools.Demos.Workstation.Configuration
Imports System.ServiceProcess
Imports Leadtools.DicomDemos
Imports Leadtools.Medical.Logging.DataAccessLayer.Configuration
Imports Leadtools.Medical.Workstation.UI.Factory
Imports Leadtools.Medical.Storage.DataAccessLayer
Imports Leadtools.Medical.DataAccessLayer
Imports Leadtools.Medical.Workstation.DataAccessLayer.Configuration
Imports Leadtools.Medical.Storage.DataAccessLayer.Configuration
Imports Leadtools.Medical.UserManagementDataAccessLayer.Configuration
Imports Leadtools.Medical.UserManagementDataAccessLayer
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration
Imports Leadtools.Medical.Workstation.UI
Imports Leadtools.Medical.Winforms
Imports System.Diagnostics
Imports Leadtools.Dicom.Scu.Common
Imports Leadtools.Dicom
Imports System.Configuration
Imports Leadtools.Medical.DataAccessLayer.Configuration
Imports Leadtools.Dicom.Common.DataTypes
Imports System.Xml.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports Leadtools.Demos.StorageServer.DataTypes



Namespace Leadtools.Demos.Workstation
    Partial Public Class StorageListenerService
        Inherits UserControl
#Region "Public"

#Region "Methods"

        Public Sub New()
            Try
                InitializeComponent()

                WorkstationAddInsDll = New List(Of String)()
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)

                Throw
            End Try
        End Sub

#End Region

#Region "Properties"

        Public Property WorkstationAddInsDll() As List(Of String)
            Get
                Return _workstationAddInsDll
            End Get

            Private Set(ByVal value As List(Of String))
                _workstationAddInsDll = New List(Of String)()
            End Set
        End Property

        Private ReadOnly Property EventLogViewer() As EventLogViewerDialog
            Get
                Try
                    Return WorkstationUIFactory.Instance.GetWorkstsationControl(Of EventLogViewerDialog)(UIElementKeys.EventLogViewer)
                Catch
                    Return Nothing
                End Try
            End Get

        End Property

#End Region

#Region "Events"

        Public Event WorkstationServiceCreated As EventHandler(Of WorkstationServiceEventArgs)
        Public Event WorkstationServiceDeleted As EventHandler(Of WorkstationServiceEventArgs)
        Public Event WorkstationServiceChanged As EventHandler(Of WorkstationServiceEventArgs)

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

#End Region

#End Region

#Region "Protected"

#Region "Methods"

        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            Try
                MyBase.OnLoad(e)

                If _DesignMode Then
                    Return
                End If

                Init()

                RegisterEvents()
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)

                ThreadSafeMessager.ShowError(exception.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Obtains a lifetime service object to control the lifetime policy for this instance. Returning null makes this a singleton object that doesn't
        ''' expire.
        ''' </summary>
        ''' <returns>
        ''' An object of type <see cref="T:System.Runtime.Remoting.Lifetime.ILease"/> used to control the lifetime policy for this instance.
        ''' This is the current lifetime service object for this instance if one exists; otherwise, a new lifetime service object initialized to 
        ''' the value of the <see cref="P:System.Runtime.Remoting.Lifetime.LifetimeServices.LeaseManagerPollTime"/> property.
        ''' </returns>
        ''' <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission. </exception>
        ''' <PermissionSet>
        ''' 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="RemotingConfiguration, Infrastructure"/>
        ''' </PermissionSet>
        Public Overrides Function InitializeLifetimeService() As Object
            Return Nothing
        End Function

        Protected Overrides Sub OnVisibleChanged(ByVal e As EventArgs)
            Try
                MyBase.OnVisibleChanged(e)
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)

                Throw
            End Try

        End Sub

        Protected Overridable Sub OnWorkstationServiceCreated(ByVal sender As Object, ByVal e As WorkstationServiceEventArgs)
            If Nothing IsNot WorkstationServiceCreatedEvent Then
                RaiseEvent WorkstationServiceCreated(sender, e)
            End If
        End Sub

        Protected Overridable Sub OnWorkstationServiceDeleted(ByVal sender As Object, ByVal e As WorkstationServiceEventArgs)
            If Nothing IsNot WorkstationServiceDeletedEvent Then
                RaiseEvent WorkstationServiceDeleted(sender, e)
            End If
        End Sub

        Protected Overridable Sub OnWorkstationServiceChanged(ByVal sender As Object, ByVal e As WorkstationServiceEventArgs)
            If Nothing IsNot WorkstationServiceChangedEvent Then
                RaiseEvent WorkstationServiceChanged(sender, e)
            End If
        End Sub

#End Region

#Region "Properties"

        Protected Property WorkstationService() As DicomService
            Get
                Return _LEADWorkstationService
            End Get

            Set(ByVal value As DicomService)
                If value IsNot _LEADWorkstationService Then
                    If Nothing IsNot _LEADWorkstationService Then
                        UnloadService()
                    End If

                    _LEADWorkstationService = value

                    If Nothing IsNot value Then
                        LoadService()
                    End If
                End If
            End Set
        End Property

        Protected Property ServiceManager() As WorkstatoinServiceManager
            Get
                Return _serviceManager
            End Get

            Set(ByVal value As WorkstatoinServiceManager)
                _serviceManager = value
            End Set
        End Property

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
                Dim serviceName As String = Nothing

                EventLogViewerToolStripButton.Enabled = EventLogViewer IsNot Nothing
                serviceName = ConfigurationData.ListenerServiceName

                If String.IsNullOrEmpty(serviceName) Then
                    serviceName = ConfigurationData.ListenerServiceDefaultName
                End If

                CreateServiceManager()

                WorkstationService = ServiceManager.LoadWorkstationListenerService(serviceName)

                If Nothing Is WorkstationService Then
                    Try
                        WorkstationService = CreateDefaultWorkStationService()
                    Catch ex As Exception
                        ThreadSafeMessager.ShowError(ex.Message)

                        WorkstationService = Nothing
                    End Try
                End If

                HandleStatusChange()

                If Nothing Is WorkstationService Then
                    ThreadSafeMessager.ShowWarning("No Listener service installed.")
                End If
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)

                HandleStatusChange()

                Throw
            End Try
        End Sub

        Private Sub RegisterEvents()
            Try
                If EventLogViewer IsNot Nothing Then
                    AddHandler EventLogViewerToolStripButton.Click, AddressOf eventLogViewer_Click
                End If
                AddHandler EditServerToolStripButton.Click, AddressOf toolStripButtonEditServer_Click
                AddHandler ToolStripButtonStart.Click, AddressOf toolStripButtonStart_Click
                AddHandler PauseToolStripButton.Click, AddressOf toolStripButtonPause_Click
                AddHandler StopToolStripButton.Click, AddressOf toolStripButtonStop_Click
                AddHandler AddServerToolStripButton.Click, AddressOf AddServerToolStripButton_Click
                AddHandler DeleteServerToolStripButton.Click, AddressOf DeleteServerToolStripButton_Click

                AddHandler AddAeTitleToolStripButton.Click, AddressOf toolStripButtonAddAeTitle_Click
                AddHandler EditAeTitleToolStripButton.Click, AddressOf toolStripButtonEditAeTitle_Click
                AddHandler DeleteAeTitleToolStripButton.Click, AddressOf toolStripButtonDeleteAeTitle_Click

                AddHandler AeTitlesListView.SelectedIndexChanged, AddressOf listViewAeTitles_SelectedIndexChanged
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)

                Throw
            End Try
        End Sub

        Private Sub CreateServiceManager()
            ServiceManager = New WorkstatoinServiceManager(Application.StartupPath)

            AddHandler ServiceManager.ServerError, AddressOf ServiceManager_ServerError
        End Sub

        Private Sub LoadService()
            LoadAddIns()

            HandleStatusChange()

            AddHandler WorkstationService.Message, AddressOf __LEADWorkstationService_Message
            AddHandler WorkstationService.StatusChange, AddressOf __LEADWorkstationService_StatusChange

            InitializeService()
        End Sub

        Private Sub UnloadService()
            UnloadAddIns()

            RemoveHandler WorkstationService.Message, AddressOf __LEADWorkstationService_Message
            RemoveHandler WorkstationService.StatusChange, AddressOf __LEADWorkstationService_StatusChange
        End Sub

        Private Sub InitServiceInformation()
            If Nothing IsNot WorkstationService Then
                WorkstationDisplayNameLabel.Text = WorkstationService.Settings.DisplayName
                IpAddressLabel.Text = WorkstationService.Settings.IpAddress
                ServerPortLabel.Text = WorkstationService.Settings.Port.ToString()
                LEADStorageServiceAELabel.Text = WorkstationService.Settings.AETitle
                ' Enable security icon
                ServerSecurePictureBox.Visible = WorkstationService.Settings.Secure
            Else
                WorkstationDisplayNameLabel.Text = String.Empty
                IpAddressLabel.Text = String.Empty
                ServerPortLabel.Text = String.Empty
                LEADStorageServiceAELabel.Text = String.Empty
                ServerSecurePictureBox.Visible = False
            End If
        End Sub

        Private Sub LoadAddIns()
            For Each [option] As IAddInOptions In WorkstationService.AddInOptions

                Dim addInButton As ToolStripButton


                Try
                    addInButton = New ToolStripButton()

                    If Nothing IsNot [option].Image Then
                        addInButton.Image = [option].Image.ToImage()
                    End If

                    addInButton.Text = [option].Text
                    addInButton.Tag = [option]
                    addInButton.ToolTipText = [option].Text
                    addInButton.DisplayStyle = ToolStripItemDisplayStyle.Image

                    AddHandler addInButton.Click, AddressOf toolStripButtonConfigureDatabase_Click

                    MainToolStrip.Items.Add(addInButton)
                Catch
                End Try
            Next [option]
        End Sub

        Private Sub UnloadAddIns()
            Dim unLoadedItems As List(Of ToolStripItem)


            unLoadedItems = New List(Of ToolStripItem)()

            For Each stripItem As ToolStripItem In MainToolStrip.Items
                If TypeOf stripItem.Tag Is IAddInOptions Then
                    unLoadedItems.Add(stripItem)
                End If
            Next stripItem

            For Each addInItem As ToolStripItem In unLoadedItems
                MainToolStrip.Items.Remove(addInItem)
            Next addInItem
        End Sub

        Private Function CreateDefaultWorkStationService() As DicomService
            Try
                Dim service As DicomService


                If ConfigurationData.AutoCreateService Then
                    Dim settings As ServerSettings


                    If ServiceManager.WorkstationService IsNot Nothing Then
                        ServiceManager.UnloadWorkstationListenerService()
                    End If

                    settings = GetSettings()
                    service = ServiceManager.InstallWorkstationService(settings, WorkstationAddInsDll.ToArray())

                    OnWorkstationServiceCreated(Me, New WorkstationServiceEventArgs(ServiceManager.ServiceName, service))
                Else
                    service = Nothing
                End If

                Return service
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)

                Throw
            End Try
        End Function

        Private Function GetSettings() As ServerSettings
            Dim settings As ServerSettings


            settings = New ServerSettings()

            Dim addresses() As IPAddress
            Dim iPv4Address As IPAddress = Nothing


            Dim hostName As String = Dns.GetHostName()


            addresses = Dns.GetHostAddresses(Dns.GetHostName())

            If 0 = addresses.Length Then
                Return Nothing
            End If

            For Each address As IPAddress In addresses
                If address.AddressFamily = AddressFamily.InterNetwork Then
                    iPv4Address = address

                    Exit For
                End If
            Next address

            If iPv4Address Is Nothing Then
                Return Nothing
            End If

            settings.AETitle = ConfigurationData.ListenerServiceDefaultName
            settings.AllowAnonymous = True
            settings.DisplayName = ConfigurationData.ListenerServiceDefaultDisplayName
            settings.IpAddress = iPv4Address.ToString()
            settings.Port = GetNearestAvailablePort(iPv4Address, Constants.DefaultPort)

            settings.AllowMultipleConnections = True
            settings.ImplementationClass = "1.2.840.114257.1123456"
            settings.ImplementationVersionName = "LTPACSF V17"


            Return settings
        End Function

        Private Sub UnInstallService()
            ServiceManager.UninstallWorkstationService()

            UnloadAddIns()
        End Sub

        Private Sub ColorCell(ByVal item As ListViewItem, ByVal portColumnNumber As Integer, ByVal securePort As Boolean, ByVal portUsage As ClientPortUsageType)
            Dim secure As Boolean = (portUsage = ClientPortUsageType.Secure) OrElse ((portUsage = ClientPortUsageType.SameAsServer) AndAlso WorkstationService.Settings.Secure)
            If secure = securePort Then
                'cell.Style.ForeColor = dataGridView1.DefaultCellStyle.ForeColor;
                'cell.Style.SelectionForeColor = dataGridView1.DefaultCellStyle.SelectionForeColor;
                item.SubItems(portColumnNumber).ForeColor = ListView.DefaultForeColor
                item.UseItemStyleForSubItems = False
            Else
                'cell.Style.ForeColor = Color.LightGray;
                'cell.Style.SelectionForeColor = Color.DarkGray;
                item.SubItems(portColumnNumber).ForeColor = Color.LightGray
                item.UseItemStyleForSubItems = False
            End If
        End Sub

        Private Sub ColorListViewPorts(ByVal item As ListViewItem, ByVal portUsage As ClientPortUsageType)
            ColorCell(item, 2, False, portUsage)

            ' Secure Port
            ColorCell(item, 3, True, portUsage)
        End Sub

        Private Sub AddAe(ByVal info As AeInfo)
            Try
                If InvokeRequired Then
                    Invoke(New Action(Of AeInfo)(AddressOf AddAe), info)

                    Return
                End If

                Dim item As ListViewItem


                item = AeTitlesListView.Items.Add(info.AETitle)

                item.SubItems.Add(info.Address)
                item.SubItems.Add(info.Port.ToString())
                item.SubItems.Add(info.SecurePort.ToString())
                item.SubItems.Add(info.ClientPortUsage.ToString())

                item.Tag = info

                ColorListViewPorts(item, info.ClientPortUsage)
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)

                Throw
            End Try
        End Sub

        Private Sub LoadAes(ByVal aes As List(Of AeInfo))
            Try
                If InvokeRequired Then
                    Invoke(New Action(Of List(Of AeInfo))(AddressOf LoadAes), aes)
                    Return
                End If

                For Each ae As AeInfo In aes
                    AddAe(ae)
                Next ae

                HandleStatusChange()
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)

                Throw
            End Try
        End Sub

        Private Sub UpdateAe(ByVal oldAe As String, ByVal info As AeInfo, ByVal failed As Boolean)
            Try
                If InvokeRequired Then
                    Invoke(New Action(Of String, AeInfo, Boolean)(AddressOf UpdateAe), (New Object() {oldAe, info, failed}))

                    Return
                End If

                For Each item As ListViewItem In AeTitlesListView.Items
                    Dim old As AeInfo


                    old = TryCast(item.Tag, AeInfo)

                    If old.AETitle = oldAe Then
                        '
                        ' If the update didn't fail we will update the display
                        '
                        If (Not failed) Then
                            item.Text = info.AETitle
                            item.SubItems(1).Text = info.Address
                            item.SubItems(2).Text = info.Port.ToString()
                            item.SubItems(3).Text = info.SecurePort.ToString()
                            item.SubItems(4).Text = info.ClientPortUsage.ToString()

                            item.Tag = info
                        End If

                        Exit For
                    End If
                Next item

                HandleStatusChange()
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)

                Throw
            End Try
        End Sub

        Private Sub RemoveAe(ByVal deleteAE As String)
            Try
                If InvokeRequired Then
                    Invoke(New Action(Of String)(AddressOf RemoveAe), deleteAE)

                    Return
                End If

                For Each item As ListViewItem In AeTitlesListView.Items
                    Dim ae As AeInfo


                    ae = TryCast(item.Tag, AeInfo)

                    If ae.AETitle = deleteAE Then
                        AeTitlesListView.Items.Remove(item)

                        Exit For
                    End If
                Next item

                HandleStatusChange()
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)

                Throw
            End Try
        End Sub

        Private Sub InitializeService()
            Try
                If InvokeRequired Then
                    Invoke(New MethodInvoker(AddressOf AnonymousMethod1))

                    Return
                End If

                InitServiceInformation()

                If (Nothing IsNot WorkstationService) AndAlso (WorkstationService.Status = ServiceControllerStatus.Running) Then
                    AeTitlesListView.Items.Clear()

                    '
                    ' Request server ae titles
                    '    
                    WorkstationService.SendMessage(MessageNames.GetAeTitles)
                End If
            Catch ex As Exception
                ThreadSafeMessager.ShowError("Error sending message." & Microsoft.VisualBasic.Constants.vbLf + ex.Message)
            End Try
        End Sub
        Private Sub AnonymousMethod1()
            InitializeService()
        End Sub

        Private Function GetNearestAvailablePort(ByVal address As IPAddress, ByVal port As Integer) As Integer
            Try
                Dim tcpTestSocket As Socket


                tcpTestSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

                Do
                    Try
                        Dim endPoint As IPEndPoint


                        endPoint = New IPEndPoint(address, port)

                        tcpTestSocket.Bind(endPoint)

                        If tcpTestSocket.IsBound Then
                            tcpTestSocket.Close()

                            Return port
                        Else
                            port += 1
                        End If
                    Catch e1 As Exception
                        port += 1
                    End Try
                Loop
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)

                Throw
            End Try
        End Function

        Private Sub HandleStatusChange()
            Try
                If InvokeRequired Then
                    Invoke(New MethodInvoker(AddressOf HandleStatusChange))

                    Return
                End If

                If Nothing IsNot WorkstationService Then
                    Dim running As Boolean = WorkstationService.Status = ServiceControllerStatus.Running
                    Dim paused As Boolean = WorkstationService.Status = ServiceControllerStatus.Paused

                    ToolStripButtonStart.Enabled = (Not running) OrElse paused
                    StopToolStripButton.Enabled = running OrElse paused
                    PauseToolStripButton.Enabled = running
                    EditServerToolStripButton.Enabled = True

                    AddAeTitleToolStripButton.Enabled = WorkstationService.IsAdminAvailable
                    EditAeTitleToolStripButton.Enabled = WorkstationService.IsAdminAvailable AndAlso AeTitlesListView.SelectedItems.Count > 0
                    DeleteAeTitleToolStripButton.Enabled = WorkstationService.IsAdminAvailable AndAlso AeTitlesListView.SelectedItems.Count > 0

                    AddServerToolStripButton.Enabled = False
                    DeleteServerToolStripButton.Enabled = True
                Else
                    For Each button As ToolStripItem In MainToolStrip.Items
                        If button IsNot AddServerToolStripButton Then
                            button.Enabled = False
                        End If
                    Next button

                    AddServerToolStripButton.Enabled = True
                End If

                Dim globalPacsConfig As System.Configuration.Configuration
                globalPacsConfig = Leadtools.DicomDemos.DicomDemoSettingsManager.GetGlobalPacsConfiguration()
                Dim loggingConfig As New LoggingDataAccessConfigurationView(globalPacsConfig, DicomDemoSettingsManager.ProductNameStorageServer, Nothing)
                EventLogViewerToolStripButton.Enabled = Leadtools.Demos.StorageServer.DataTypes.GlobalPacsUpdater.IsDataAccessSettingsValid(globalPacsConfig, loggingConfig.DataAccessSettingsSectionName, DicomDemoSettingsManager.ProductNameWorkstation)
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)

                Throw
            End Try
        End Sub

#End Region

#Region "Properties"


        Private ReadOnly Property _DesignMode() As Boolean
            Get
                Return (Me.GetService(GetType(IDesignerHost)) IsNot Nothing) OrElse (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime)
            End Get
        End Property

#End Region

#Region "Events"

        Private Sub __LEADWorkstationService_Message(ByVal sender As Object, ByVal e As MessageEventArgs)
            Try
                Dim message As ServiceMessage


                If WorkstationService IsNot (TryCast(sender, DicomService)) Then
                    Return
                End If

                message = AddInUtils.Clone(Of ServiceMessage)(e.Message)

                Select Case message.Message
                    Case MessageNames.AddAeTitle

                        If message.Success Then
                            AddAe(TryCast(message.Data(0), AeInfo))
                        Else
                            ThreadSafeMessager.ShowError("Error Adding AE Title." & Microsoft.VisualBasic.Constants.vbLf + message.Error)
                        End If

                    Case MessageNames.GetAeTitles
                        If message.Success Then
                            LoadAes(TryCast(message.Data(0), List(Of AeInfo)))
                        Else
                            ThreadSafeMessager.ShowError("Error Getting AE Titles." & Microsoft.VisualBasic.Constants.vbLf + message.Error)
                        End If

                    Case MessageNames.UpdateAeTitle
                        If (Not message.Success) Then
                            ThreadSafeMessager.ShowError("Error Updating AE Title." & Microsoft.VisualBasic.Constants.vbLf + message.Error)

                            UpdateAe(TryCast(message.Data(0), String), TryCast(message.Data(1), AeInfo), True)
                        Else
                            UpdateAe(TryCast(message.Data(0), String), TryCast(message.Data(1), AeInfo), False)
                        End If

                    Case MessageNames.RemoveAeTitle
                        If (Not message.Success) Then
                            ThreadSafeMessager.ShowError("Error Removing AE Title" & Microsoft.VisualBasic.Constants.vbLf + message.Error)
                        Else
                            RemoveAe(TryCast(message.Data(0), String))
                        End If
                End Select
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)

                Throw
            End Try
        End Sub

        Private Sub __LEADWorkstationService_StatusChange(ByVal sender As Object, ByVal e As EventArgs)
            Try
                HandleStatusChange()

                If WorkstationService Is (TryCast(sender, DicomService)) AndAlso WorkstationService.Status = ServiceControllerStatus.Running Then
                    InitializeService()
                End If
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)

                Throw
            End Try
        End Sub

        Private Sub toolStripButtonConfigureDatabase_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try
                If TypeOf sender Is ToolStripButton AndAlso TypeOf (CType(sender, ToolStripButton)).Tag Is IAddInOptions Then
                    CType((CType(sender, ToolStripButton)).Tag, IAddInOptions).Configure(Me, WorkstationService.Settings, WorkstationService.ServiceDirectory)
                End If
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)

                ThreadSafeMessager.ShowError(exception.Message)
            End Try
        End Sub

        Private Sub toolStripButtonEditServer_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim dialog As EditServiceDialog


                dialog = New EditServiceDialog()

                dialog.Settings = AddInUtils.Clone(Of ServerSettings)(WorkstationService.Settings)
                dialog.ServiceName = ServiceManager.ServiceName
                dialog.Mode = EditServiceDialog.EditMode.EditServer

                If dialog.ShowDialog(Me) = DialogResult.OK Then
                    WorkstationService.Settings = dialog.Settings

                    LEADStorageServiceAELabel.Text = WorkstationService.Settings.AETitle
                    IpAddressLabel.Text = WorkstationService.Settings.IpAddress
                    ServerPortLabel.Text = WorkstationService.Settings.Port.ToString()
                    ServerSecurePictureBox.Visible = WorkstationService.Settings.Secure

                    OnWorkstationServiceChanged(Me, New WorkstationServiceEventArgs(WorkstationService.ServiceName, WorkstationService))
                End If
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)

                ThreadSafeMessager.ShowError(exception.Message)
            End Try
        End Sub

        Private Sub toolStripButtonStart_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try
                WorkstationService.Start()
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)

                ThreadSafeMessager.ShowError(exception.Message)
            End Try
        End Sub

        Private Sub toolStripButtonPause_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try
                WorkstationService.Pause()
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)

                ThreadSafeMessager.ShowError(exception.Message)
            End Try
        End Sub

        Private Sub toolStripButtonStop_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try
                WorkstationService.Stop()
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)

                ThreadSafeMessager.ShowError(exception.Message)
            End Try
        End Sub

        Private Sub AddServerToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim dialog As EditServiceDialog


                dialog = New EditServiceDialog()

                dialog.Settings = GetSettings()
                dialog.ServiceName = ServiceManager.ServiceName
                dialog.Mode = EditServiceDialog.EditMode.AddServer

                If dialog.ShowDialog(Me) = DialogResult.OK Then
                    Try
                        WorkstationService = ServiceManager.InstallWorkstationService(dialog.Settings, WorkstationAddInsDll.ToArray())

                        If Nothing IsNot WorkstationService Then
                            OnWorkstationServiceCreated(Me, New WorkstationServiceEventArgs(ServiceManager.ServiceName, WorkstationService))
                        End If
                    Catch ex As Exception
                        ThreadSafeMessager.ShowError(ex.Message)
                    End Try
                End If
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)

                ThreadSafeMessager.ShowError(exception.Message)
            End Try
        End Sub


        Private Sub DeleteServerToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim result As DialogResult = DialogResult.Yes


            If Nothing Is WorkstationService Then
                Return
            End If

            If WorkstationService.Status = ServiceControllerStatus.Running Then
                result = ThreadSafeMessager.ShowQuestion("Service is currently running" & Microsoft.VisualBasic.Constants.vbCrLf & "Do you want to stop and delete?", MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then
                    WorkstationService.Stop()

                    Do While WorkstationService.Status <> ServiceControllerStatus.Stopped
                        Application.DoEvents()
                    Loop
                End If
            End If

            If result = DialogResult.Yes Then
                Try
                    Dim serviceName As String


                    serviceName = ServiceManager.ServiceName

                    UnInstallService()

                    LEADStorageServiceAELabel.Text = String.Empty
                    IpAddressLabel.Text = String.Empty
                    ServerPortLabel.Text = String.Empty

                    AeTitlesListView.Items.Clear()

                    ThreadSafeMessager.ShowInformation("Service successfully uninstalled")

                    WorkstationService = Nothing

                    OnWorkstationServiceDeleted(Me, New WorkstationServiceEventArgs(serviceName, Nothing))
                Catch ex As Exception
                    ThreadSafeMessager.ShowError(ex.Message)
                End Try
            End If

            HandleStatusChange()
        End Sub

        Private Sub toolStripButtonAddAeTitle_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim dialog As EditAeTitleDialog


                dialog = New EditAeTitleDialog()
                dialog.ServerSecure = WorkstationService.Settings.Secure

                If dialog.ShowDialog(Me) = DialogResult.OK Then
                    Dim newAeInfo As AeInfo = AddInUtils.Clone(Of AeInfo)(dialog.AeInfo)


                    newAeInfo.Address = newAeInfo.Address

                    Try
                        WorkstationService.SendMessage(MessageNames.AddAeTitle, newAeInfo)
                    Catch ex As Exception
                        ThreadSafeMessager.ShowError("Error sending message." & Microsoft.VisualBasic.Constants.vbLf + ex.Message)
                    End Try
                End If
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)

                ThreadSafeMessager.ShowError(exception.Message)
            End Try
        End Sub

        Private Sub toolStripButtonEditAeTitle_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim dialog As EditAeTitleDialog
                Dim oldAe As String


                If AeTitlesListView.SelectedItems.Count = 0 Then
                    Return
                End If

                dialog = New EditAeTitleDialog()
                dialog.ServerSecure = WorkstationService.Settings.Secure

                dialog.AeInfo = AddInUtils.Clone(Of AeInfo)(TryCast(AeTitlesListView.SelectedItems(0).Tag, AeInfo))

                oldAe = dialog.AeInfo.AETitle

                If dialog.ShowDialog(Me) = DialogResult.OK Then
                    Try
                        Dim newAeInfo As AeInfo = AddInUtils.Clone(Of AeInfo)(dialog.AeInfo)


                        newAeInfo.Address = newAeInfo.Address

                        ColorListViewPorts(AeTitlesListView.SelectedItems(0), newAeInfo.ClientPortUsage)

                        WorkstationService.SendMessage(MessageNames.UpdateAeTitle, oldAe, newAeInfo)
                    Catch ex As Exception
                        ThreadSafeMessager.ShowError("Error sending message." & Microsoft.VisualBasic.Constants.vbLf + ex.Message)
                    End Try
                End If
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)

                ThreadSafeMessager.ShowError(exception.Message)
            End Try
        End Sub

        Private Sub toolStripButtonDeleteAeTitle_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim info As AeInfo


                If AeTitlesListView.SelectedItems.Count = 0 Then
                    Return
                End If

                info = TryCast(AeTitlesListView.SelectedItems(0).Tag, AeInfo)

                WorkstationService.SendMessage(MessageNames.RemoveAeTitle, info.AETitle)
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)

                ThreadSafeMessager.ShowError("Error sending message." & Microsoft.VisualBasic.Constants.vbLf + exception.Message)
            End Try
        End Sub

        Private Sub ServiceManager_ServerError(ByVal sender As Object, ByVal e As Leadtools.Dicom.Server.Admin.ErrorEventArgs)
            If (Nothing IsNot e.Error) AndAlso (TypeOf e.Error Is BadImageFormatException) Then
                Dim demoVersoin As String = "32"
                Dim addInsVersion As String = "64"

                Dim msg As String = "Error loading [{0}]." & Microsoft.VisualBasic.Constants.vbLf & Microsoft.VisualBasic.Constants.vbLf & "This {1}-bit {3} process cannot load {2}-bit AddIn dlls, so the AddIn options can not be displayed.  " & "Please use the {2}-bit version of the {3} to view the AddIn options." & Microsoft.VisualBasic.Constants.vbLf & Microsoft.VisualBasic.Constants.vbLf & "Note:" & Microsoft.VisualBasic.Constants.vbLf & "If you prefer to use the {1}-bit version of the AddIn dlls you can delete the current service and reinstall it from this {3}:" & Microsoft.VisualBasic.Constants.vbLf & "* To delete the service, click on 'Delete Server' button from the Workstation Listener Service Manager." & Microsoft.VisualBasic.Constants.vbLf & "* To install a new service, click on 'Add Server' and enter the service information -or leave the defaults- in the dialog then click ok." & Microsoft.VisualBasic.Constants.vbLf

                Dim message As String = String.Empty

                If DemosGlobal.Is64Process() Then
                    demoVersoin = "64"
                    addInsVersion = "32"
                Else
                    demoVersoin = "32"
                    addInsVersion = "64"
                End If

                message = String.Format(msg, (TryCast(e.Error, BadImageFormatException)).FileName, demoVersoin, addInsVersion, Messager.Caption)

                ThreadSafeMessager.ShowWarning(message)
            Else
                ThreadSafeMessager.ShowError(e.Error.Message)
            End If
        End Sub

        Private Sub listViewAeTitles_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try
                HandleStatusChange()
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False, exception.Message)
            End Try
        End Sub

        Private Sub eventLogViewer_Click(ByVal sender As Object, ByVal e As EventArgs)
            If EventLogViewer.Visible Then
                EventLogViewer.Focus()
            Else
                EventLogViewer.Show(Me)
            End If
        End Sub

#End Region

#Region "Data Members"

        Private _LEADWorkstationService As DicomService
        Private _serviceManager As WorkstatoinServiceManager
        Private _workstationAddInsDll As List(Of String)

#End Region

#Region "Data Types Definition"

        Private Class Constants
            Public Const DicomServerConfigFile As String = "Leadtools.Dicom.Server.exe.config"
            Public Const ConfigurationComponent As String = "StorageListenerService"
            Public Const DefaultPort As Integer = 105
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

    Public Class WorkstationServiceEventArgs
        Inherits EventArgs
        Public Sub New(ByVal serviceName As String, ByVal serviceParam As DicomService)
            Me.ServiceName = serviceName
            Service = serviceParam
        End Sub

        Public Property ServiceName() As String
            Get
                Return _serviceName
            End Get

            Set(ByVal value As String)
                _serviceName = value
            End Set
        End Property

        Private privateService As DicomService
        Public Property Service() As DicomService
            Get
                Return privateService
            End Get
            Private Set(ByVal value As DicomService)
                privateService = value
            End Set
        End Property

        Private _serviceName As String
    End Class
End Namespace
