' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports System.Net
Imports System.IO
Imports System.Threading
Imports System.Management
Imports Leadtools
Imports Leadtools.Dicom
Imports Leadtools.Dicom.Scu.Common
Imports Leadtools.DicomDemos
Imports Leadtools.Dicom.Scu
Imports System.Diagnostics
Imports Leadtools.Dicom.Common.Extensions
#If LEADTOOLS_V19_OR_LATER Then
Imports Leadtools.Dicom.Common.DataTypes
#End If

Namespace DicomDemo
    Partial Public Class MainForm : Inherits Form

        Private Class MyStoreScu
            Inherits StoreScu
            Private _form As MainForm

#If Not LEADTOOLS_V20_OR_LATER Then
         Public Sub New(ByVal form As MainForm, ByVal TemporaryDirectory As String, ByVal SecurityMode As DicomNetSecurityeMode, ByVal openSslContextCreationSettings As DicomOpenSslContextCreationSettings)
            MyBase.New(TemporaryDirectory, SecurityMode, openSslContextCreationSettings)
            _form = form
         End Sub
#Else
            Public Sub New(ByVal form As MainForm, ByVal TemporaryDirectory As String, ByVal SecurityMode As DicomNetSecurityMode, ByVal openSslContextCreationSettings As DicomOpenSslContextCreationSettings)
                MyBase.New(TemporaryDirectory, SecurityMode, openSslContextCreationSettings)
                _form = form
            End Sub
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then

            Public Sub New(ByVal form As MainForm)
                MyBase.New()
                _form = form
            End Sub

            Protected Overrides Sub OnClose(ByVal [error] As DicomExceptionCode, ByVal net As DicomNet)

                _form.LogText("Server Closed Connection", String.Empty)

                If _form IsNot Nothing Then
                    _form.EnableCancel(False)
                End If
            End Sub

            Protected Overrides Sub OnReceiveCStoreResponse(ByVal presentationID As Byte, ByVal messageID As Integer, ByVal affectedClass As String, ByVal instance As String, ByVal status As DicomCommandStatusType)
                If (_form IsNot Nothing) AndAlso (_form._mySettings.LogLowLevel) Then
                    Dim sMsg As String = _sNewlineTab & "presentationID:" & Constants.vbTab + presentationID.ToString() & _sNewlineTab & "messageID:" & Constants.vbTab + messageID.ToString() & _sNewlineTab & "affectedClass:" & Constants.vbTab & affectedClass & _sNewlineTab & "instance:" & Constants.vbTab & instance & _sNewlineTab & "status:" & Constants.vbTab + status.ToString()

                    _form.LogText("OnReceiveCStoreResponse", sMsg, Color.Green)
                End If
                MyBase.OnReceiveCStoreResponse(presentationID, messageID, affectedClass, instance, status)
            End Sub

            Protected Overrides Sub OnReceiveReleaseResponse()
                If (_form IsNot Nothing) AndAlso (_form._mySettings.LogLowLevel) Then
                    _form.LogText("OnReceiveReleaseResponse", String.Empty, System.Drawing.Color.Green)
                End If
                MyBase.OnReceiveReleaseResponse()
            End Sub

            Protected Overrides Sub OnReceiveAssociateAccept(ByVal association As DicomAssociate)
                If (_form IsNot Nothing) AndAlso (_form._mySettings.LogLowLevel) Then
                    _form.LogText("OnReceiveAssociateAccept", String.Empty, System.Drawing.Color.Green)
                End If
                MyBase.OnReceiveAssociateAccept(association)
            End Sub

            Protected Overrides Sub OnReceiveNActionResponse(ByVal presentationID As Byte, ByVal messageID As Integer, ByVal affectedClass As String, ByVal instance As String, ByVal status As DicomCommandStatusType, ByVal action As Integer, ByVal dataSet As DicomDataSet)
                If (_form IsNot Nothing) AndAlso (_form._mySettings.LogLowLevel) Then
                    Dim sMsg As String = _sNewlineTab & "presentationID:" & Constants.vbTab + presentationID.ToString() & _sNewlineTab & "messageID:" & Constants.vbTab + messageID.ToString() & _sNewlineTab & "affectedClass:" & Constants.vbTab & affectedClass & _sNewlineTab & "instance:" & Constants.vbTab & instance & _sNewlineTab & "status:" & Constants.vbTab + status.ToString() & _sNewlineTab & "action:" & Constants.vbTab + action.ToString()

                    _form.LogText("OnReceiveNActionResponse", sMsg, Color.Green)
                End If
                MyBase.OnReceiveNActionResponse(presentationID, messageID, affectedClass, instance, status, action, dataSet)
            End Sub

            Protected Overrides Sub OnReceiveNReportRequest(ByVal presentationID As Byte, ByVal messageID As Integer, ByVal affectedClass As String, ByVal instance As String, ByVal dicomEvent As Integer, ByVal dataSet As DicomDataSet)
                If (_form IsNot Nothing) AndAlso (_form._mySettings.LogLowLevel) Then
                    Dim sMsg As String = _sNewlineTab & "presentationID:" & Constants.vbTab + presentationID.ToString() & _sNewlineTab & "messageID:" & Constants.vbTab + messageID.ToString() & _sNewlineTab & "affectedClass:" & Constants.vbTab & affectedClass & _sNewlineTab & "instance:" & Constants.vbTab & instance & _sNewlineTab & "dicomEvent:" & Constants.vbTab + dicomEvent.ToString()

                    _form.LogText("OnReceiveNReportRequest", sMsg, Color.Green)
                End If
                MyBase.OnReceiveNReportRequest(presentationID, messageID, affectedClass, instance, dicomEvent, dataSet)
            End Sub
        End Class

        Public Class PatientInformation
            Private _patientName As String
            Private _patientId As String
            Private _fileName As String

            Public Sub New(ByVal patientName As String, ByVal patientId As String, ByVal fileName As String)
                _patientName = patientName
                _patientId = patientId
                _fileName = fileName
            End Sub

            Public Property PatientName() As String
                Get
                    Return _patientName
                End Get
                Set(ByVal value As String)
                    _patientName = value
                End Set
            End Property

            Public Property PatientId() As String
                Get
                    Return _patientId
                End Get
                Set(ByVal value As String)
                    _patientId = value
                End Set
            End Property

            Public Property FileName() As String
                Get
                    Return _fileName
                End Get
                Set(ByVal value As String)
                    _fileName = value
                End Set
            End Property
        End Class

        ' CStore highlevel object
        Private _cstore As MyStoreScu
        Private _server As New DicomScp()
        Private Const _sConfigurationImplementationClass As String = "1.2.840.114257.1123456"
        Private Const _sConfigurationImplementationVersionName As String = "1"
        Private Const _sConfigurationProtocolVersion As String = "1"

        ' Settings
        Public _mySettings As New DicomDemoSettings()
        Public _demoName As String = Path.GetFileName(Application.ExecutablePath)

        ' Logging
        Private Const _sNewline As String = Constants.vbCrLf
        Private Const _sTab As String = Constants.vbTab
        Private Const _sNewlineTab As String = Constants.vbCrLf & Constants.vbTab
        Private Const _sNewlineTabTab As String = Constants.vbCrLf & Constants.vbTab + Constants.vbTab
        Public Delegate Sub AddLog(ByVal action As String, ByVal logText As String, ByVal sActionColor As Color)
        Private _cancel As Boolean = False
        Private _listViewItem As ListViewItem
        Private _tracer As TextBoxTraceListener = Nothing
        Private _closing As Boolean = False

        Private Const sHelpInstructions As String = "Command Line Options:" & _sNewlineTab & "/? or /help" & Constants.vbTab + Constants.vbTab & "Displays this help" & _sNewlineTab & "/configure" & Constants.vbTab + Constants.vbTab & "Configures the client (use one or more options below)" & _sNewlineTab & "/server_aetitle={aetitle}" & Constants.vbTab & "Server AE title" & _sNewlineTab & "/server_ip={ip address}" & Constants.vbTab & "Server IP" & _sNewlineTab & "/server_port={port}" & Constants.vbTab & "Server Port" & _sNewlineTab & "/client_aetitle={aetitle}" & Constants.vbTab & "Client AE title" & _sNewlineTab & "/client_port={port}" & Constants.vbTab + Constants.vbTab & "Client Port" & _sNewlineTab & "/defaults" & Constants.vbTab + Constants.vbTab + Constants.vbTab & "Sets defaults for other options"

        ' Help
        Private _firstTime As Boolean = True
        Private _bShowImportantMessage As Boolean = False
        Private _storageCommitList As List(Of String)


      <STAThread()> _
        Shared Sub Main(ByVal args() As String)
            Dim bConfigure As Boolean = ReadCommandLine(args)
            If bConfigure Then
                Return
            End If

#If LEADTOOLS_V19_OR_LATER Then
            If (Not Support.SetLicense()) Then
                Return
            End If
#Else
			Support.SetLicense()
			If RasterSupport.KernelExpired Then
            Return
         End If
#End If

#If LEADTOOLS_V175_OR_LATER Then
            If RasterSupport.IsLocked(RasterSupportType.DicomCommunication) Then
                MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.DicomCommunication.ToString()), "Warning")
                Return
            End If
#Else
            If RasterSupport.IsLocked(RasterSupportType.MedicalNet) Then
                MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.MedicalNet.ToString()), "Warning")
                Return
            End If
#End If ' #if LEADTOOLS_V175_OR_LATER
            Utils.EngineStartup()
            Utils.DicomNetStartup()
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)

            Try
                Application.Run(New MainForm())
            Catch e1 As Exception
            Finally
                DicomEngine.Shutdown()
                DicomNet.Shutdown()
            End Try
        End Sub

        Private Shared Function GetDefaultIp() As String
            Dim query As New ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'")
            Dim queryCollection As ManagementObjectCollection = query.Get()

            For Each mo As ManagementObject In queryCollection
                If queryCollection.Count > 0 Then
                    Dim addresses() As String = CType(mo("IPAddress"), String())

                    For Each ip As String In addresses
                        If (Not ip.Contains(":")) AndAlso (ip <> "0.0.0.0") Then
                            Return ip
                        End If
                    Next ip
                End If
            Next mo
            Return String.Empty
        End Function

        ' Here are two sample command lines:
        '       /configure /server_aetitle=STORAGE_SCU /server_ip=10.1.1.167 /server_port=104 /defaults
        '       /configure /server_aetitle=test_server_ae /server_ip=10.1.1.123 /server_port=123 /client_aetitle=test_client_ae /client_ip=test_client_ip /client_port=456 /defaults
        Private Shared Function ReadCommandLine(ByVal args() As String) As Boolean
            Return False
        End Function


        Public Sub New()
            InitializeComponent()
            If (Not DicomDemoSettingsManager.Is64Process()) Then
                Text = Text & " (32 bit)"
            Else
                Text = Text & "(64 bit)"
            End If
        End Sub

        Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
#If (Not LEADTOOLS_V19_OR_LATER) Then
         _buttonStorageCommit.Visible = False
#End If
            SizeColumns()
            EnableCancel(False)
            StatusText(String.Empty)
        End Sub

        Private Const defaultServerAE As String = "LEAD_SERVER"
        Private Const defaultServerIP As String = "127.0.0.1"
        Private Const defaultServerPort As Integer = 104
        Private Const defaultServerTimeout As Integer = 30
        Private Const defaultServerUseTls As Boolean = False
        Private Const defaultCompression As Integer = 2

        Private Const defaultClientAE As String = "LEAD_CLIENT"
        Private Const defaultClientPort As Integer = 1000

        Private Shared Sub SetOtherDefaults(ByVal settings As DicomDemoSettings)
            settings.ClientCertificate = DicomDemoSettingsManager.GetClientCertificateFullPath()
            settings.ClientPrivateKey = DicomDemoSettingsManager.GetClientCertificateFullPath()
            settings.ClientPrivateKeyPassword = DicomDemoSettingsManager.GetClientCertificatePassword()

            settings.LogLowLevel = True
            settings.ShowHelpOnStart = True

            Dim sDefaultIP As String = String.Empty
            Try
                sDefaultIP = GetDefaultIp()
            Catch e1 As Exception
            End Try
        End Sub

        Private Function DefaultSettings() As DicomDemoSettings
            Dim settings As New DicomDemoSettings()
            settings.ClientAe.AE = defaultClientAE
            settings.ClientAe.Port = defaultServerPort
            Dim serverAE As New DicomAE()
            serverAE.AE = defaultServerAE
            serverAE.IPAddress = defaultServerIP
            serverAE.Port = defaultServerPort
            serverAE.Timeout = defaultServerTimeout
            serverAE.UseTls = defaultServerUseTls
            settings.ServerList.Add(serverAE)
            SetOtherDefaults(settings)
            Return settings
        End Function

        Private Sub LoadSettings()
            _mySettings = Nothing
            Try
                _mySettings = DicomDemoSettingsManager.LoadSettings(_demoName)
                If _mySettings Is Nothing Then
                    DicomDemoSettingsManager.RunPacsConfigDemo()
                    _mySettings = DicomDemoSettingsManager.LoadSettings(_demoName)
                End If
            Catch e1 As Exception
            End Try
            If _mySettings Is Nothing Then
                _mySettings = DefaultSettings()
            Else
                ' found settings -- set any necessary defaults 
                If (_mySettings.FirstRun AndAlso _mySettings.IsPreconfigured) Then
                    SetOtherDefaults(_mySettings)
                End If
            End If

            SetDefaultStoreServer()

            If _mySettings.FileList Is Nothing Then
                _mySettings.FileList = New List(Of String)()
            End If

            If _mySettings.FileList.Count = 0 AndAlso _mySettings.FirstRun Then
                Dim sDir As String = DemosGlobal.ImagesFolder
                Dim sFileList() As String = {"image1.dcm", "image2.dcm", "image3.dcm"}
                For Each sName As String In sFileList
                    Dim sFile As String = sDir & "\" & sName
                    If File.Exists(sFile) Then
                        _mySettings.FileList.Add(sFile)
                    End If
                    DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)
                Next sName
            End If

            If _mySettings.FileList.Count > 0 Then
                Dim result As DialogResult = DialogResult.Yes

                'If _mySettings.FirstRun = False Then
                '    result = MessageBox.Show("Do you want to add the DICOM files that were used previously?", "Load DICOM files", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                'End If
                If result = DialogResult.Yes Then
                    EnableCancel(True)

                    ' Get the count
                    Dim sMsg As String = String.Empty
                    Dim totalCount As Integer = _mySettings.FileList.Count
                    Dim count As Integer = 0
                    Dim nMod As Integer = 1

                    LogText("Loading...", String.Empty)
                    For Each sFile As String In _mySettings.FileList
                        If LoadDicomFile(sFile) Then
                            count += 1
                        End If

                        If totalCount > 20 Then
                            nMod = 10
                        End If

                        If count Mod nMod = 0 Then
                            sMsg = String.Format("Loaded {0} of {1} files...", count.ToString(), totalCount.ToString())
                            LogText(String.Empty, _sTab & sMsg)
                            StatusText(sMsg)
                        End If
                        Application.DoEvents()
                    Next sFile
                    sMsg = String.Format("Loaded {0} of {1} total files", count.ToString(), totalCount.ToString())
                    LogText(String.Empty, _sTab & sMsg)
                    StatusText(sMsg)
                    EnableCancel(False)
                End If
            End If
            SizeColumns()
        End Sub

        Private Sub SaveSettings()
            _mySettings.FileList.Clear()
            For Each item As ListViewItem In _listViewImages.Items
                Try
                    _mySettings.FileList.Add(item.SubItems(5).Text)
                Catch ex As Exception
                    Messager.ShowWarning(Me, ex.Message)
                End Try
            Next item

            DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)
        End Sub

        Private Sub SetDefaultStoreServer()
            Dim defaultAE As DicomAE = _mySettings.GetServer(_mySettings.DefaultStore)

            If _comboBoxService.SelectedIndex >= 0 Then
                defaultAE = _mySettings.ServerList(_comboBoxService.SelectedIndex)
            End If

            If Nothing IsNot defaultAE Then
                _server.AETitle = defaultAE.AE
                _server.Port = CInt(Fix(defaultAE.Port))
                _server.PeerAddress = IPAddress.Parse(defaultAE.IPAddress.Trim())
                _server.Timeout = defaultAE.Timeout

                _textBoxServerIp.Text = _server.PeerAddress.ToString()
                _textBoxServerPort.Text = _server.Port.ToString()
            End If
        End Sub

        Private Sub UpdateDefaultServerAE()
            If _comboBoxService.Items.Count > 0 Then
                _mySettings.DefaultStore = _comboBoxService.GetSelectedAETitle()

                DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)

                SetDefaultStoreServer()
            End If
        End Sub

        Private Sub SelectDefaultServerAE()
            If _comboBoxService.Items.Count > 0 Then
                _comboBoxService.SetSelectedItem(_mySettings.DefaultStore)

                If -1 = _comboBoxService.SelectedIndex AndAlso _comboBoxService.Items.Count > 0 Then
                    _comboBoxService.SelectedIndex = 0
                End If

                If _comboBoxService.Items.Count > 0 Then
                    _mySettings.DefaultStore = _comboBoxService.GetSelectedAETitle()
                Else
                    _mySettings.DefaultStore = String.Empty
                End If
            End If

            _comboBoxService.Enabled = (_comboBoxService.Items.Count > 0)
        End Sub

        Private Sub UpdateComboBoxService()
            _comboBoxService.Items.Clear()

            For Each myServer As DicomAE In _mySettings.ServerList
                _comboBoxService.Items.Add(myServer)
            Next myServer

            SelectDefaultServerAE()
        End Sub

        Private Function GetDefaultUseTls() As Boolean
            Dim useTls As Boolean = False
            Dim defaultAE As DicomAE = _mySettings.GetServer(_mySettings.DefaultStore)
            If _comboBoxService.SelectedIndex >= 0 Then
                defaultAE = _mySettings.ServerList(_comboBoxService.SelectedIndex)
            End If

            If defaultAE IsNot Nothing Then
                useTls = defaultAE.UseTls
            End If
            Return useTls
        End Function

        Private Sub CreateCStoreObject()
            If _cstore IsNot Nothing Then
                _cstore.Dispose()
            End If
            Dim useTls As Boolean = GetDefaultUseTls()
            If useTls Then
#If Not LEADTOOLS_V20_OR_LATER Then
            _cstore = New MyStoreScu(Me, String.Empty, DicomNetSecurityeMode.Tls, Nothing)
#Else
                _cstore = New MyStoreScu(Me, String.Empty, DicomNetSecurityMode.Tls, Nothing)
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then
            Else
                _cstore = New MyStoreScu(Me)
            End If

            _cstore.MaxLength = 46726
            _cstore.Compression = CType(_mySettings.Compression, Leadtools.Dicom.Scu.Common.Compression)
            _cstore.ImplementationClass = _sConfigurationImplementationClass
            _cstore.ImplementationVersionName = _sConfigurationImplementationVersionName
            _cstore.ProtocolVersion = _sConfigurationProtocolVersion
            '_cstore.EnableDebugLog = false;
#If LEADTOOLS_V19_OR_LATER Then
            _cstore.Flags = DicomNetFlags.None
            If _mySettings.GroupLengthDataElements Then
                _cstore.Flags = _cstore.Flags Or DicomNetFlags.SendDataWithGroupLengthStandardDataElements
            End If
#End If

            ' Subscribe to events for logging
            AddHandler _cstore.BeforeConnect, AddressOf _cstore_BeforeConnect
            AddHandler _cstore.AfterConnect, AddressOf _cstore_AfterConnect
            AddHandler _cstore.AfterSecureLinkReady, AddressOf _cstore_AfterSecureLinkReady
            AddHandler _cstore.BeforeAssociateRequest, AddressOf _cstore_BeforeAssociateRequest
            AddHandler _cstore.AfterAssociateRequest, AddressOf _cstore_AfterAssociateRequest
            AddHandler _cstore.BeforeReleaseRequest, AddressOf _cstore_BeforeAssociateRelease
            AddHandler _cstore.AfterReleaseRequest, AddressOf _cstore_AfterAssociateRelease
            AddHandler _cstore.BeforeClose, AddressOf _cstore_BeforeClose
            AddHandler _cstore.AfterClose, AddressOf _cstore_AfterClose
            AddHandler _cstore.BeforeCStore, AddressOf _cstore_BeforeCStore
            AddHandler _cstore.AfterCStore, AddressOf _cstore_AfterCStore
            AddHandler _cstore.PrivateKeyPassword, AddressOf _cstore_PrivateKeyPassword
#If LEADTOOLS_V19_OR_LATER Then
            AddHandler _cstore.BeforeNAction, AddressOf _cstore_BeforeNAction
            AddHandler _cstore.AfterNAction, AddressOf _cstore_AfterNAction
            AddHandler _cstore.StorageCommitmentResult, AddressOf _cstore_StorageCommitmentResult
            AddHandler _cstore.StorageCommitmentWait, AddressOf _cstore_StorageCommitmentWait
#End If

            If useTls Then
                Try
                    _cstore.SetTlsCipherSuiteByIndex(0, DicomTlsCipherSuiteType.DheRsaWith3DesEdeCbcSha)

                    Dim strPathToKeyFile As String
                    If _mySettings.ClientPrivateKey.Length > 0 Then
                        strPathToKeyFile = _mySettings.ClientPrivateKey
                    Else
                        strPathToKeyFile = Nothing
                    End If
                    _cstore.SetTlsClientCertificate(_mySettings.ClientCertificate, DicomTlsCertificateType.Pem, strPathToKeyFile)
                Catch ex As Exception
                    LogError(ex.Message)
                End Try
            End If

            If _mySettings.LogLowLevel And Not _mySettings.DisableLogging Then
                If _tracer Is Nothing Then
                    _tracer = New TextBoxTraceListener(_richTextBoxLog)
                    Trace.Listeners.Add(_tracer)
                End If
            Else
                If _tracer IsNot Nothing Then
                    Trace.Listeners.Remove(_tracer)
                    _tracer = Nothing
                End If
            End If

            _cstore.DebugLogFilename = String.Empty
            If _mySettings.DisableLogging Then
                _cstore.EnableDebugLog = True
            Else
                _cstore.EnableDebugLog = False
            End If

            SetDefaultStoreServer()
        End Sub

        Private Sub _cstore_PrivateKeyPassword(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.PrivateKeyPasswordEventArgs)
            e.PrivateKeyPassword = _mySettings.ClientPrivateKeyPassword
        End Sub

        Private Sub MainForm_Closing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
#If LEADTOOLS_V19_OR_LATER Then
            _cstore.StopListener()
#End If
            _closing = True
            If _cstore IsNot Nothing AndAlso _cstore.IsConnected() Then
                _cstore.CloseForced(True)
            End If
            SaveSettings()
        End Sub

        Private Sub _cstore_BeforeConnect(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.BeforeConnectEventArgs)
            LogText("Before Connect", e.Scp.ToString())
            e.PrivateKeyPassword = _mySettings.ClientPrivateKeyPassword
        End Sub

        Private Sub _cstore_AfterConnect(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.AfterConnectEventArgs)
            Dim message As String
            If e.Error = DicomExceptionCode.Success Then
                message = _sNewlineTab & "Connection Successful"
            Else
                message = _sNewlineTab & "Connection Failed" & _sNewlineTab & "Error:" & Constants.vbTab + e.Error.ToString()
            End If

            LogText("After Connect", message)
        End Sub

        Private Sub _cstore_AfterSecureLinkReady(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.AfterSecureLinkReadyEventArgs)
            Dim net As DicomNet = CType(sender, DicomNet)
            If net IsNot Nothing Then
                Dim cipher As DicomTlsCipherSuiteType = net.GetTlsCipherSuite()
                Dim message As String
                If e.Error = DicomExceptionCode.Success Then
                    message = _sNewlineTab & "Secure Link Ready" & _sNewlineTab & "Cipher Suite: " & cipher.GetCipherFriendlyName()
                Else
                    message = _sNewlineTab & "Secure Link Failed" & _sNewlineTab & "Error:" & Constants.vbTab + e.Error.ToString()
                End If

                LogText("After Secure Link Ready", message)
            End If
        End Sub

        Private Sub _cstore_BeforeAssociateRequest(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.BeforeAssociateRequestEventArgs)
            LogText("Before Associate Request", e.Associate.ToString())
        End Sub

        Private Sub _cstore_AfterAssociateRequest(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.AfterAssociateRequestEventArgs)
            Dim message As String
            If e.Rejected Then
                message = _sNewlineTab & "Association Rejected" & _sNewlineTab & "Result: " & e.Result.ToString() & _sNewlineTab & "Reason: " & e.Reason.ToString() & _sNewlineTab & "Source: " & e.Source.ToString()
            Else
                message = _sNewlineTab & "Association Accepted" & e.Associate.ToString()
            End If
            LogText("After Associate Request", message)
        End Sub

        Private Sub _cstore_BeforeAssociateRelease(ByVal sender As Object, ByVal e As EventArgs)
            LogText("Before Associate Release", String.Empty)
        End Sub

        Private Sub _cstore_AfterAssociateRelease(ByVal sender As Object, ByVal e As EventArgs)
            LogText("After Associate Release", String.Empty)
        End Sub

        Private Sub _cstore_BeforeClose(ByVal sender As Object, ByVal e As EventArgs)
            LogText("Before Close", String.Empty)
        End Sub

        Private Sub _cstore_AfterClose(ByVal sender As Object, ByVal e As EventArgs)
            LogText("After Close", String.Empty)
        End Sub

        Private Sub _cstore_BeforeCStore(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.BeforeCStoreEventArgs)
            Dim message As String = _sNewlineTab & "Filename: " & e.FileInfo.FullName & _sNewlineTab & "Message ID: " & e.MessageId.ToString + _sNewlineTab & "Presentation ID: " & e.PresentationID.ToString + _sNewlineTab & "Affected Class: " & e.AffectedClass + _sNewlineTab & "Priority:" & e.Priority.ToString()

            LogText("Before CStore", message)
        End Sub

        Private Sub _cstore_AfterCStore(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.AfterCStoreEventArgs)
            Dim message As String
            If e.Status = DicomCommandStatusType.Success Then
                message = _sNewlineTab & "Success" & _sNewlineTab & "Filename: " & e.FileInfo.FullName
            Else
                message = _sNewlineTab & "CStore Failed" & _sNewlineTab & "Status: " & e.Status.ToString()
            End If
            LogText("After CStore", message)
        End Sub

#If LEADTOOLS_V19_OR_LATER Then
        Private Sub _cstore_BeforeNAction(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.BeforeNActionEventArgs)
            Dim message As String = _sNewlineTab & "Message ID: " & e.MessageID & _sNewlineTab & "Presentation ID: " & e.PresentationID & _sNewlineTab & "Affected Class: " & e.AffectedClass + _sNewlineTab & "Instance: " & e.Instance + _sNewlineTab & "Action Type:" & e.ActionType.ToString()

            LogText("Before NAction", message)
        End Sub

        Private Sub _cstore_AfterNAction(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.AfterNActionEventArgs)
            Dim message As String
            If e.Status = DicomCommandStatusType.Success Then
                message = _sNewlineTab & "Success" & ""
                '"_sNewlineTab + @"Filename: " + e.FileInfo.FullName;
            Else
                message = _sNewlineTab & "NAction Failed" & _sNewlineTab & "Status: " & e.Status.ToString()
            End If
            LogText("After NAction", message)
        End Sub

        Shared Function AppendNewlineString(ByVal original As String, ByVal name As String, ByVal result As String, ByVal tabcount As Integer) As String
            If String.IsNullOrEmpty(result) Then
                Return original
            End If

            Dim ret As String = original & Environment.NewLine
            For i As Integer = 0 To tabcount - 1
                ret &= _sTab
            Next i
            ret &= (name & result)
            Return ret
        End Function

        Shared Function GetPatientInfo(ByVal sopPatientList As Dictionary(Of String, PatientInformation), ByVal sopInstanceUid As String) As String
            Dim result As String = String.Empty
            Dim p As PatientInformation
            If sopPatientList.TryGetValue(sopInstanceUid, p) Then
                result = String.Format("{0} ({1}) {2}", p.PatientName, p.PatientId, Path.GetFileName(p.FileName))
            End If
            Return result
        End Function

        Private Sub _cstore_StorageCommitmentWait(ByVal sender As Object, ByVal e As StorageCommitmentWaitEventArgs)
            Dim scu As MyStoreScu = TryCast(sender, MyStoreScu)
            If scu IsNot Nothing AndAlso scu.ActiveScp IsNot Nothing AndAlso scu.ActiveScp.Association IsNot Nothing Then
                Dim implementationVersionName As String = scu.ActiveScp.Association.ImplementationVersionName
                If String.Compare(implementationVersionName, "LT_PACS_DEMO", True) = 0 Then
                    e.Options = StoreScu.StorageCommitOptions.WaitForResultsThenClose
                End If
            End If
        End Sub

        Public Delegate Sub _cstore_StorageCommitmentResultDelegate(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.StorageCommitmentResultEventArgs)

        Private Sub _cstore_StorageCommitmentResult(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.StorageCommitmentResultEventArgs)
            If Me.InvokeRequired Then
                Invoke(New _cstore_StorageCommitmentResultDelegate(AddressOf _cstore_StorageCommitmentResult), sender, e)
                Return
            End If

            Dim sopPatientList As New Dictionary(Of String, PatientInformation)()
            For Each item As ListViewItem In _listViewImages.CheckedItems
                Dim patientName As String = item.SubItems(0).Text
                Dim patientId As String = item.SubItems(1).Text
                Dim imagePath As String = item.SubItems(5).Text
                Dim sopInstanceUid As String = item.SubItems(6).Text
                sopPatientList.Add(sopInstanceUid, New PatientInformation(patientName, patientId, imagePath))
            Next item


            Dim message As String = _sNewlineTab & "TransactionUID: " & e.Result.TransactionUID
            message = AppendNewlineString(message, "RetrieveAETitle: ", e.Result.RetrieveAETitle, 1)
            message = AppendNewlineString(message, "StorageMediaFileSetID: ", e.Result.StorageMediaFileSetID, 1)
            message = AppendNewlineString(message, "StorageMediaFileSetUID: ", e.Result.StorageMediaFileSetUID, 1)

            Dim successes As Integer = If((e.Result.ReferencedSOPSequence IsNot Nothing), e.Result.ReferencedSOPSequence.Count, 0)
            Dim failures As Integer = If((e.Result.FailedSOPSequence IsNot Nothing), e.Result.FailedSOPSequence.Count, 0)
            Dim total As Integer = successes + failures

            If successes > 0 AndAlso e.Result.ReferencedSOPSequence IsNot Nothing Then
                message &= String.Format("{0}Successes ({1} of {2}):{{Green}}", _sNewlineTab, successes, total)
                Dim count As Integer = 0
                For Each sop As SCSOPInstanceReference In e.Result.ReferencedSOPSequence
                    count += 1
                    message &= _sNewlineTabTab & count
                    message = AppendNewlineString(message, String.Empty, GetPatientInfo(sopPatientList, sop.ReferencedSopInstanceUid), 3)
                    message = AppendNewlineString(message, "RetrieveAETitle: ", sop.RetrieveAETitle, 3)
                    'message = AppendNewlineString(message, @"StorageMediaFileSetID: ", sop.StorageMediaFileSetID, 3);
                    'message = AppendNewlineString(message, @"StorageMediaFileSetUID: ", sop.StorageMediaFileSetUID, 3);
                    'message = AppendNewlineString(message, @"ReferencedSopClassUid: ", sop.ReferencedSopClassUid, 3);
                    message = AppendNewlineString(message, "ReferencedSopInstanceUid: ", sop.ReferencedSopInstanceUid, 3)
                Next sop
            End If

            If failures > 0 AndAlso e.Result.FailedSOPSequence IsNot Nothing Then
                message &= String.Format("{0}Failures ({1} of {2}):{{Red}}", _sNewlineTab, failures, total)
                Dim count As Integer = 0
                For Each sop As SCFailedSOPInstanceReference In e.Result.FailedSOPSequence
                    count += 1
                    message &= _sNewlineTabTab & count
                    message = AppendNewlineString(message, String.Empty, GetPatientInfo(sopPatientList, sop.ReferencedSopInstanceUid), 3)
                    'message = AppendNewlineString(message, @"ReferencedSopClassUid: ", sop.ReferencedSopClassUid, 3);
                    message = AppendNewlineString(message, "ReferencedSopInstanceUid: ", sop.ReferencedSopInstanceUid, 3)
                Next sop
            End If

            LogText("Storage Commitment Result", message)

            EnableCancel(False)
        End Sub
#End If ' #If LEADTOOLS_V19_OR_LATER Then

        ' Logging
        Private Sub AppendTextColor(ByVal text As String, ByVal color As Color)
            Dim oldColor As Color = _richTextBoxLog.SelectionColor

            _richTextBoxLog.SelectionLength = text.Length
            _richTextBoxLog.SelectionStart = _richTextBoxLog.Text.Length
            _richTextBoxLog.SelectionColor = color
            _richTextBoxLog.SelectionFont = New Font(_richTextBoxLog.SelectionFont, FontStyle.Bold)
            _richTextBoxLog.AppendText(text)
            _richTextBoxLog.SelectionColor = oldColor
            _richTextBoxLog.ScrollToCaret()
        End Sub

        Private Sub AddAction(ByVal sAction As String, ByVal color As Color)
            If sAction.Length > 0 Then
                sAction = Environment.NewLine & sAction
                Dim oldColor As Color = _richTextBoxLog.SelectionColor
                _richTextBoxLog.SelectionLength = sAction.Length
                _richTextBoxLog.SelectionStart = _richTextBoxLog.Text.Length
                _richTextBoxLog.SelectionColor = color
                _richTextBoxLog.SelectionFont = New Font(_richTextBoxLog.SelectionFont, FontStyle.Bold)
                _richTextBoxLog.AppendText(sAction & ": ")
                _richTextBoxLog.SelectionColor = oldColor
                _richTextBoxLog.ScrollToCaret()
            End If
        End Sub

        Public Function RemoveColorToken(ByVal s As String, <System.Runtime.InteropServices.Out()> ByRef color As Color) As String
            color = Color.Empty
            Dim line As String = s
            Dim colors() As Color = New Color() {Color.Red, Color.Green}

            For Each colorToCheck As Color In colors
                Dim colorFormat As String = String.Format("{{{0}}}", colorToCheck.Name)
                If line.EndsWith(colorFormat) Then
                    line = line.Remove(line.Length - colorFormat.Length)
                    color = colorToCheck
                End If
            Next colorToCheck
            Return Environment.NewLine & line
        End Function

        Public Sub LogText(ByVal sAction As String, ByVal sLogText As String, ByVal sActionColor As Color)
            If _mySettings.DisableLogging Then
                Return
            End If

            If _closing Then
                Return
            End If

            Try
                If Me.InvokeRequired Then
                    Me.Invoke(New AddLog(AddressOf LogText), New Object() {sAction, sLogText, sActionColor})
                Else
                    AddAction(sAction, sActionColor)
                    If sActionColor = Color.Green Then
                        AppendTextColor(sLogText, sActionColor)
                    Else
                        Dim splitChars() As Char = New Char() {ControlChars.Lf, ControlChars.Cr}
                        Dim lines() As String = sLogText.Split(splitChars, StringSplitOptions.RemoveEmptyEntries)
                        For Each line As String In lines
                            Dim color As Color
                            Dim lineNew As String = RemoveColorToken(line, color)
                            AppendTextColor(lineNew, color)
                        Next line
                    End If
                    TextBoxTraceListener.SendMessage(_richTextBoxLog.Handle, TextBoxTraceListener.WM_VSCROLL, TextBoxTraceListener.SB_BOTTOM, 0)
                End If
            Catch e1 As Exception
            Finally
            End Try
        End Sub

        Public Sub LogText(ByVal sAction As String, ByVal sLogText As String)
            If (_mySettings.DisableLogging) Then
                Return
            End If

            LogText(sAction, sLogText, Color.Blue)
            Application.DoEvents()
        End Sub

        Public Sub LogError(ByVal sLogText As String)
            If _mySettings.DisableLogging Then
                Return
            End If

            ' If cancelling, do not log any errors that might result from the cancel
            If _cancel Then
                Return
            End If
            LogText("*** ERROR *** ", _sNewlineTab & sLogText, Color.Red)
        End Sub

        Private Sub _listViewImages_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles _listViewImages.DragDrop
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                Dim myFiles() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
                Cursor = Cursors.WaitCursor
                EnableCancel(True)
                For Each sFile As String In myFiles
                    LoadDicomFile(sFile)
                    Application.DoEvents()
                Next sFile
                EnableCancel(False)
                Cursor = Cursors.Default
            End If
            SizeColumns()
        End Sub

        Private Sub _listViewImages_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles _listViewImages.DragEnter

            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If
        End Sub


        Private Function LoadDicomFile(ByVal filename As String) As Boolean
            If _cancel Then
                Return False
            End If

            Dim succeeded As Boolean = True

            Using ds As New DicomDataSet()
                Dim item As ListViewItem = Nothing
                Dim strTransferSyntax As String = String.Empty

                Try
                    Me.Cursor = Cursors.WaitCursor
                    ds.Load(filename, DicomDataSetLoadFlags.None)
                    item = _listViewImages.Items.Add(ds.GetValue(Of String)(DicomTag.PatientName, String.Empty))
                    item.SubItems.Add(ds.GetValue(Of String)(DicomTag.PatientID, String.Empty))
                    item.SubItems.Add(ds.GetValue(Of String)(DicomTag.StudyID, String.Empty))
                    item.SubItems.Add(ds.GetValue(Of String)(DicomTag.Modality, String.Empty))

                    strTransferSyntax = "Implicit VR - Little Endian"

                    Dim element As DicomElement = ds.FindFirstElement(Nothing, DicomTag.TransferSyntaxUID, False)
                    If element IsNot Nothing AndAlso ds.GetElementValueCount(element) > 0 Then
                        Dim uidString As String = ds.GetValue(Of String)(element, String.Empty)
                        Dim uid As DicomUid = DicomUidTable.Instance.Find(uidString)
                        If uid IsNot Nothing Then
                            strTransferSyntax = uid.Name
                        End If
                    End If
                Catch de As DicomException
                    LogText("Dicom error: " & de.Code.ToString(), filename)
                    succeeded = False
                End Try

                If succeeded Then
                    ' Mark item read if we have a basic directory
                    If ds.InformationClass = DicomClassType.BasicDirectory Then
                        item.Font = New Font(_listViewImages.Font, FontStyle.Bold)
                    End If

                    item.SubItems.Add(strTransferSyntax)
                    item.SubItems.Add(filename)
                    item.SubItems.Add(ds.GetValue(Of String)(DicomTag.SOPInstanceUID, String.Empty))

                    item.Checked = True
                End If
            End Using
            Me.Cursor = Cursors.Default
            Return succeeded
        End Function

        Private Sub LoadDicomDir(ByVal filename As String)
            If _cancel Then
                Return
            End If

            Dim ds As New DicomDataSet()
            Dim refFilename As String = String.Empty
            Dim element As DicomElement = Nothing
            Dim count As Integer = 0
            Dim totalCount As Integer = 0
            Dim nMod As Integer = 10
            Dim sMsg As String = String.Empty


            If (Not filename.ToUpper().Contains("DICOMDIR")) Then
                Return
            End If

            Dim pathname As String = Path.GetDirectoryName(filename) & "\"
            Try
                Me.Cursor = Cursors.WaitCursor
                ds.Load(filename, DicomDataSetLoadFlags.None)

                ' Get the total count
                element = ds.FindFirstElement(Nothing, DicomTag.ReferencedFileID, False)
                Do While element IsNot Nothing
                    totalCount += 1
                    element = ds.FindNextElement(element, False)
                Loop

                If totalCount > 20 Then
                    nMod = 10
                End If

                ' now get the datasets
                element = ds.FindFirstElement(Nothing, DicomTag.ReferencedFileID, False)
                If element IsNot Nothing AndAlso ds.GetElementValueCount(element) > 0 Then
                    If (Not _cancel) Then
                        LogText("Loading DICOMDIR", String.Empty)
                        refFilename = ds.GetConvertValue(element)
                        If LoadDicomFile(pathname & refFilename) Then
                            count += 1
                        End If
                        Application.DoEvents()
                    End If
                End If

                Do While (refFilename.Length > 0) AndAlso ((Not _cancel))
                    element = ds.FindNextElement(element, False)
                    If element IsNot Nothing AndAlso ds.GetElementValueCount(element) > 0 Then
                        refFilename = ds.GetConvertValue(element)
                        If LoadDicomFile(pathname & refFilename) Then
                            count += 1
                        End If
                        Application.DoEvents()
                    Else
                        refFilename = String.Empty
                    End If
                    If count Mod nMod = 0 Then
                        sMsg = String.Format("Loaded {0} of {1} files...", count.ToString(), totalCount.ToString())
                        LogText(String.Empty, _sTab & sMsg)
                        StatusText(sMsg)
                    End If
                Loop
            Catch de As DicomException
                LogText("Dicom error: " & de.Code.ToString(), filename)
            End Try
            sMsg = String.Format("Loaded {0} of {1} total files", count.ToString(), totalCount.ToString())
            LogText(String.Empty, _sTab & sMsg)
            StatusText(sMsg)
            Me.Cursor = Cursors.Default
        End Sub


        Private Sub addDICOMDIRToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles addDICOMDIRToolStripMenuItem.Click
            _openFileDialog.Multiselect = True
            _openFileDialog.Title = "Add DICOM Dir"
            _openFileDialog.Filter = "All Files|*.*"
            _openFileDialog.FileName = "DICOMDIR"
            If _openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                EnableCancel(True)
                For Each file As String In _openFileDialog.FileNames
                    LoadDicomDir(file)
                Next file
                EnableCancel(False)
            End If
            SizeColumns()
        End Sub

        Private Sub SizeColumns()
            If _listViewImages.Items.Count > 0 Then
                ' Size to content
                For Each header As ColumnHeader In _listViewImages.Columns
                    If header.Text.Contains("Modality") Then
                        header.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                    ElseIf header.Text.Contains("Transfer Syntax") Then
                        header.AutoResize(ColumnHeaderAutoResizeStyle.None)
                    Else
                        header.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                    End If
                Next header
            Else
                ' size to header
                For Each header As ColumnHeader In _listViewImages.Columns
                    header.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                Next header
            End If
        End Sub

        Private Sub splitContainer1_Panel2_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles _splitContainer1.Panel2.Resize
        End Sub

        Private Sub _listViewImages_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles _listViewImages.Resize
        End Sub

        Private Function DoOptions() As DialogResult
            Dim options As New OptionsDialog()
            options.ServerList = _mySettings.ServerList


            options.ClientAE = _mySettings.ClientAe.AE
            options.ClientPort = _mySettings.ClientAe.Port
            options.Compression = CType(_mySettings.Compression, Leadtools.Dicom.Scu.Common.Compression)
            options.ClientCertificate = _mySettings.ClientCertificate
            options.PrivateKey = _mySettings.ClientPrivateKey
            options.PrivateKeyPassword = _mySettings.ClientPrivateKeyPassword
            options.LogLowLevel = _mySettings.LogLowLevel
            options.GroupLengthDataElements = _mySettings.GroupLengthDataElements
            options.DisableLogging = _mySettings.DisableLogging
            options.StorageCommitResultsOnSameAssociation = _mySettings.StorageCommitResultsOnSameAssociation
            options.CipherSuites = _mySettings.CipherSuites

            Dim dr As DialogResult = options.ShowDialog(Me)
            If dr = DialogResult.OK Then
                _mySettings.ServerList = options.ServerList
                _mySettings.ClientAe.AE = options.ClientAE
                _mySettings.ClientAe.Port = Convert.ToInt32(options.ClientPort)
                _mySettings.Compression = CInt(Fix(options.Compression))
                _mySettings.ClientCertificate = options.ClientCertificate
                _mySettings.ClientPrivateKey = options.PrivateKey
                _mySettings.ClientPrivateKeyPassword = options.PrivateKeyPassword
                _mySettings.LogLowLevel = options.LogLowLevel
                _mySettings.GroupLengthDataElements = options.GroupLengthDataElements
                _mySettings.DisableLogging = options.DisableLogging
                _mySettings.StorageCommitResultsOnSameAssociation = options.StorageCommitResultsOnSameAssociation
                _mySettings.CipherSuites = options.CipherSuites

                DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)
                UpdateComboBoxService()
                EnableCancel(False)
            End If
            Return dr
        End Function

        Private Sub StatusText(ByVal s As String)
            _labelStatus.Text = s
            Application.DoEvents()
        End Sub

        Private Sub StoreThread()
            Try
                _cstore.Store(_server, _listViewItem.SubItems(5).Text)
            Catch ex As Exception
                LogError(ex.Message)
                If String.Compare(ex.Message, "The attempt to connect was forcefully rejected", True) = 0 Then
                    If _mySettings.IsPreconfigured() Then
                        _bShowImportantMessage = True
                    End If
                End If
            End Try
        End Sub

        Private Sub DoStore()
            Dim defaultServer As DicomAE = Me.DefaultServer()
            If String.IsNullOrEmpty(defaultServer.AE) Then
                Return
            End If

            EnableCancel(True)

            _server.AETitle = defaultServer.AE
            _server.PeerAddress = IPAddress.Parse(defaultServer.IPAddress)
            _server.Port = defaultServer.Port
            _server.Timeout = defaultServer.Timeout

            ' Get total count
            Dim totalCount As Integer = 0
            Dim count As Integer = 0
            Dim sMsg As String = String.Empty

            StatusText("Getting Total Count of images to store...")
            totalCount = _listViewImages.CheckedItems.Count
            sMsg = String.Format("Total images to store: {0}", totalCount)
            StatusText(sMsg)

            For Each item As ListViewItem In _listViewImages.CheckedItems
                If (Not _cancel) Then
                    _cstore.AETitle = _mySettings.ClientAe.AE
                    _cstore.HostPort = _mySettings.ClientAe.Port
                    count += 1

                    sMsg = String.Format("Storing {0} of {1} files", count, totalCount)
                    StatusText(sMsg)

                    _listViewItem = item
                    Dim t As New System.Threading.Thread(AddressOf StoreThread)
                    t.Start()
                    Do While t.IsAlive
                        Application.DoEvents()
                        If _closing Then
                            t.Abort()
                            Exit Do
                        End If
                    Loop

                    StatusText(sMsg)
                End If
            Next item
            If _bShowImportantMessage Then
                ShowImportantMessage()
            End If
            EnableCancel(False)
        End Sub

        Public Sub EnableCancel(ByVal bEnable As Boolean)
            addDICOMToolStripMenuItem.Enabled = Not bEnable
            addDICOMDIRToolStripMenuItem.Enabled = Not bEnable
            removeSelectedToolStripMenuItem.Enabled = Not bEnable
            removeAllToolStripMenuItem.Enabled = Not bEnable
            optionsToolStripMenuItem.Enabled = Not bEnable
            clearLogToolStripMenuItem.Enabled = Not bEnable
            storeToolStripMenuItem.Enabled = Not bEnable
            exitToolStripMenuItem.Enabled = Not bEnable
            aboutToolStripMenuItem.Enabled = Not bEnable
            _buttonOptions.Enabled = Not bEnable
            _buttonStore.Enabled = (Not bEnable) AndAlso (_mySettings.ServerList IsNot Nothing) AndAlso (_mySettings.ServerList.Count > 0)
            _buttonStorageCommit.Enabled = (Not bEnable) AndAlso (_mySettings.ServerList IsNot Nothing) AndAlso (_mySettings.ServerList.Count > 0)
            '_buttonExit.Enabled = Not bEnable
            _listViewImages.Enabled = Not bEnable

            cancelToolStripMenuItem.Enabled = bEnable
            _buttonCancel.Enabled = bEnable

            If bEnable = False Then
                If _cancel Then
                    LogText("Cancelled", "")
                    _cancel = False
                End If
            End If
        End Sub

        Private Sub DoCancel()
            _cancel = True
            Thread.Sleep(1000)
            If _cstore IsNot Nothing Then
                _cstore.Dispose()
                _cstore = Nothing
            End If
            CreateCStoreObject()
            EnableCancel(True)

        End Sub


        Private Sub MainForm_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
            LoadSettings()
            CreateCStoreObject()
            UpdateComboBoxService()

            If _firstTime AndAlso _mySettings.ShowHelpOnStart Then
                _firstTime = False
                Dim dlg As New HelpDialog(DefaultServer().AE, _mySettings.ShowHelpOnStart)
                dlg.ShowDialog(Me)
                If dlg.CheckBoxNoShowAgainResult Then
                    _mySettings.ShowHelpOnStart = False
                    DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)
                End If
            End If

            _mySettings.FirstRun = False
            DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)
        End Sub

        Private Sub RemoveAll()
            For Each item As ListViewItem In _listViewImages.Items
                item.Remove()
            Next item
        End Sub

        Private Sub RemoveSelected()
            For Each item As ListViewItem In _listViewImages.Items
                If item.Selected Then
                    item.Remove()
                End If
            Next item
        End Sub

        Private Sub addDICOMToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles addDICOMToolStripMenuItem.Click
            _openFileDialog.Multiselect = True
            _openFileDialog.Title = "Add DICOM File"
            _openFileDialog.Filter = "DICOM Files (*.dcm;*.dic)|*.dcm;*.dic|All files (*.*)|*.*"
            _openFileDialog.FileName = ""
            Dim count As Integer = 0
            Dim totalCount As Integer = 0
            Dim nMod As Integer = 1
            Dim sMsg As String = String.Empty
            If _openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                EnableCancel(True)
                totalCount = _openFileDialog.FileNames.Length
                If totalCount > 20 Then
                    nMod = 10
                End If
                LogText("Loading...", String.Empty)
                For Each file As String In _openFileDialog.FileNames
                    If LoadDicomFile(file) Then
                        count += 1
                        If count Mod nMod = 0 Then
                            sMsg = String.Format("Loaded {0} of {1} files...", count.ToString(), totalCount.ToString())
                            LogText(String.Empty, _sTab & sMsg)
                            StatusText(sMsg)
                        End If
                    End If
                    Application.DoEvents()
                Next file
                EnableCancel(False)
                sMsg = String.Format("Loaded {0} of {1} files", count.ToString(), totalCount.ToString())
                LogText(String.Empty, _sTab & sMsg)
                StatusText(sMsg)
            End If
            SizeColumns()
        End Sub

        Private Sub clearLogToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles clearLogToolStripMenuItem.Click, clearLogToolStripMenuItem1.Click
            _richTextBoxLog.Clear()
        End Sub

        Private Sub aboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aboutToolStripMenuItem.Click
            Dim dlg As New AboutDialog("DICOM High Level Store")
            dlg.ShowDialog(Me)
        End Sub

        Private Sub removeSelectedToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles removeSelectedToolStripMenuItem.Click
            RemoveSelected()
        End Sub

        Private Sub _toolStripMenuItemRemoveSelected_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _toolStripMenuItemRemoveSelected.Click
            RemoveSelected()
        End Sub

        Private Sub removeAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles removeAllToolStripMenuItem.Click
            RemoveAll()
        End Sub
        Private Sub _toolStripMenuItemRemoveAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _toolStripMenuItemRemoveAll.Click
            RemoveAll()
        End Sub

        Private Sub optionsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optionsToolStripMenuItem.Click
            ' Check if the options have changed
            If System.Windows.Forms.DialogResult.OK = DoOptions() Then
                CreateCStoreObject()
            End If
        End Sub

        Private Sub _buttonOptions_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _buttonOptions.Click
            ' Check if the options have changed
            If System.Windows.Forms.DialogResult.OK = DoOptions() Then
                CreateCStoreObject()
            End If
        End Sub

        Private Sub storeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles storeToolStripMenuItem.Click
            DoStore()
        End Sub

        Private Sub _buttonStore_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _buttonStore.Click
            DoStore()
        End Sub

        Private Sub cancelToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cancelToolStripMenuItem.Click
            DoCancel()
        End Sub

        Private Sub _buttonCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _buttonCancel.Click
            DoCancel()
        End Sub

        Private Sub _buttonExit_Click(ByVal sender As Object, ByVal e As EventArgs)
            Application.Exit()
        End Sub

        Private Function DefaultServer() As DicomAE
            Dim ret As DicomAE = _mySettings.GetServer(_mySettings.DefaultStore)
            If Nothing Is ret Then
                ret = New DicomAE()
            End If
            Return ret
        End Function

        Private Sub showHelpToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles showHelpToolStripMenuItem.Click
            Dim dlg As New HelpDialog(DefaultServer().AE, False)
            dlg.ShowDialog(Me)
        End Sub

        Private Sub _comboBoxService_SelectionChangeCommitted(ByVal sender As Object, ByVal e As EventArgs) Handles _comboBoxService.SelectionChangeCommitted
            UpdateDefaultServerAE()
            CreateCStoreObject()
        End Sub

        Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Application.Exit()
        End Sub

#If LEADTOOLS_V19_OR_LATER Then

        Private Sub StoreCommitThread()
            Try
                Dim options As StoreScu.StorageCommitOptions = StoreScu.StorageCommitOptions.None
                If _mySettings.StorageCommitResultsOnSameAssociation Then
                    options = StoreScu.StorageCommitOptions.WaitForResultsThenClose
                Else
                    options = StoreScu.StorageCommitOptions.NoWaitForResults
                End If
                _cstore.StorageCommit(_server, _storageCommitList, String.Empty, options)
                Console.WriteLine("Finished")
            Catch ex As Exception
                LogError(ex.Message)
                If String.Compare(ex.Message, "The attempt to connect was forcefully rejected", True) = 0 Then
                    If _mySettings.IsPreconfigured Then
                        _bShowImportantMessage = True
                    End If
                End If
            End Try
        End Sub


        Private Sub StorageCommit()
            Dim defaultServer As DicomAE = Me.DefaultServer()
            If String.IsNullOrEmpty(defaultServer.AE) Then
                Return
            End If

            _server.AETitle = defaultServer.AE
            _server.PeerAddress = IPAddress.Parse(defaultServer.IPAddress)
            _server.Port = defaultServer.Port
            _server.Timeout = defaultServer.Timeout

            ' Get total count
            StatusText("Getting Total Count of Storage Commit instances...")
            _storageCommitList = (From item As ListViewItem In _listViewImages.CheckedItems Select item.SubItems(5).Text).ToList()
            Dim totalCount As Integer = _storageCommitList.Count
            Dim sMsg As String = String.Format("Total Storage Commit Instances: {0}", totalCount)
            StatusText(sMsg)

            If totalCount <= 0 Then
                Return
            End If

            Dim bShowImportantMessage As Boolean = False

            If (Not _cancel) Then
                _cstore.AETitle = _mySettings.ClientAe.AE
                _cstore.HostPort = _mySettings.ClientAe.Port

                Dim t As New System.Threading.Thread(AddressOf StoreCommitThread)


                t.Start()
                Do While t.IsAlive
                    Application.DoEvents()
                    If _closing Then
                        t.Abort()
                        Exit Do
                    End If
                Loop

                StatusText(sMsg)
            End If


            If bShowImportantMessage Then
                ShowImportantMessage()
            End If
        End Sub

        Private Sub DoStorageCommit()
            EnableCancel(True)
            Try
                StorageCommit()
            Finally
                EnableCancel(False)
            End Try
        End Sub
#End If ' #If LEADTOOLS_V19_OR_LATER Then

        Public Sub ShowImportantMessage()
            Dim serverManagerDemo As String = "CSLeadtools.Dicom.Server.Manager.exe"
            Dim sImportant As String = String.Format(Constants.vbLf + Constants.vbTab & "This demo is preconfigured to communicate with {0} DICOM Service." & Constants.vbLf + Constants.vbTab & "To start the service:" & Constants.vbLf + Constants.vbTab & "* Run {1}" & Constants.vbLf + Constants.vbTab & "* Select the {0} service" & Constants.vbLf + Constants.vbTab & "* Click the 'Start Server' button (blue triangle) to start the DICOM service.", _server.AETitle, serverManagerDemo)

            If _server.AETitle.Equals(Me._mySettings.HighLevelStorageServer) Then
                serverManagerDemo = "CSStorageServerManagerDemo_Original.exe"
                sImportant = String.Format(Constants.vbLf + Constants.vbTab & "This demo is preconfigured to communicate with {0} DICOM Service." & Constants.vbLf + Constants.vbTab & "To start the service:" & Constants.vbLf + Constants.vbTab & "* Run {1}" & Constants.vbLf + Constants.vbTab & "* Click the 'Start Storage Service' button (blue triangle) to start the DICOM service.", _server.AETitle, serverManagerDemo)
            ElseIf _server.AETitle.Equals(Me._mySettings.WorkstationServer) Then
                serverManagerDemo = "CSMedicalWorkstationMainDemo_Original.exe"
                sImportant = String.Format(Constants.vbLf + Constants.vbTab & "This demo is preconfigured to communicate with {0} DICOM Service." & Constants.vbLf + Constants.vbTab & "To start the service:" & Constants.vbLf + Constants.vbTab & "* Run {1}" & Constants.vbLf + Constants.vbTab & "* Click the 'Service Manager' button (in toolbar at bottom) " & Constants.vbLf + Constants.vbTab & "* Click the 'Start Server' button (blue triangle) to start the DICOM service.", _server.AETitle, serverManagerDemo)
            End If

            LogText("*** IMPORTANT ***", sImportant, Color.Red)
        End Sub

        Private Sub _buttonStorageCommit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _buttonStorageCommit.Click
#If LEADTOOLS_V19_OR_LATER Then
            DoStorageCommit()
#End If
        End Sub

    End Class

    Public Module MyExtensions
        <System.Runtime.CompilerServices.Extension>
        Public Function GetSelectedAETitle(ByVal comboBoxService As ComboBox) As String
            Dim aeTitle As String = String.Empty

            Dim dicomAe As DicomAE = TryCast(comboBoxService.SelectedItem, DicomAE)
            If dicomAe IsNot Nothing Then
                aeTitle = dicomAe.AE
            End If
            Return aeTitle
        End Function

        <System.Runtime.CompilerServices.Extension>
        Public Sub SetSelectedItem(ByVal comboBoxService As ComboBox, ByVal aeTitle As String)
            For Each item As Object In comboBoxService.Items
                Dim dicomAe As DicomAE = TryCast(item, DicomAE)
                If dicomAe.AE = aeTitle Then
                    comboBoxService.SelectedItem = item
                    Exit For
                End If
            Next item
        End Sub

    End Module
End Namespace
