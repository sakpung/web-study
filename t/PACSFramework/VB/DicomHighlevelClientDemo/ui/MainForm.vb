' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Net
Imports System.Threading
Imports System.Management
Imports System.IO
Imports System.Diagnostics
Imports System.Collections
Imports System.Text.RegularExpressions

Imports Leadtools
Imports Leadtools.Dicom
Imports Leadtools.MedicalViewer
Imports Leadtools.Dicom.Scu
Imports Leadtools.Dicom.Scu.Common
Imports Leadtools.DicomDemos
Imports Leadtools.Dicom.Common.Extensions


Namespace DicomDemo
    Partial Public Class MainForm : Inherits Form
        Private _server As DicomScp = New DicomScp()
        Private _medicalViewer As Leadtools.MedicalViewer.MedicalViewer

        Private Const _sNewline As String = Constants.vbCrLf
        Private Const _sNewlineTab As String = Constants.vbCrLf & Constants.vbTab
        Private Const _sNewlineTabTab As String = Constants.vbCrLf & Constants.vbTab + Constants.vbTab
        Private Const _sConfigurationImplementationClass As String = "1.2.840.114257.1123456"
        Private Const _sConfigurationImplementationVersionName As String = "1"
        Private Const _sConfigurationProtocolversion As String = "1"

        Private _canCancel As Boolean = False
        Private _retrieveCount As Integer = 0
        Private _totalRetrieveCount As Integer = 0

        Private WithEvents _find As MyQueryRetrieveScu
        Private _findQuery As FindQuery = New FindQuery()
        Private _tracer As TextBoxTraceListener = Nothing
        Private _closing As Boolean = False

        ' Settings
        Public _mySettings As DicomDemoSettings = New DicomDemoSettings()
        Public _demoName As String = Path.GetFileName(Application.ExecutablePath)

        ' Logging
        Public Delegate Sub AddLog(ByVal action As String, ByVal logText As String, ByVal sActionColor As Color)

        Private Const sHelpInstructions As String = "Command Line Options:" & _sNewlineTab & "/? or /help" & Constants.vbTab + Constants.vbTab & "Displays this help" & _sNewlineTab & "/configure" & Constants.vbTab + Constants.vbTab & "Configures the client (use one or more options below)" & _sNewlineTab & "/server_aetitle={aetitle}" & Constants.vbTab & "Server AE title" & _sNewlineTab & "/server_ip={ip address}" & Constants.vbTab & "Server IP" & _sNewlineTab & "/server_port={port}" & Constants.vbTab & "Server Port" & _sNewlineTab & "/client_aetitle={aetitle}" & Constants.vbTab & "Client AE title" & _sNewlineTab & "/client_port={port}" & Constants.vbTab + Constants.vbTab & "Client Port" & _sNewlineTab & "/defaults" & Constants.vbTab + Constants.vbTab + Constants.vbTab & "Sets defaults for other options"

        ' Help
        Private _firstTime As Boolean = True

      <STAThread()> _
        Shared Sub Main(ByVal args() As String)
            Dim bConfigure As Boolean = ReadCommandLine(args)
            If bConfigure Then
                Return
            End If

            If Not Support.SetLicense() Then
                Return
            End If

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
#End If

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

        Private Shared Function ParseOneServer(ByVal serverString As String) As MyServer
            '   /servers=ae1,ip1,port1,timeout1,secure1

            Dim server As MyServer = Nothing
            Dim fields() As String = serverString.Split(","c)
            If fields.Length = 5 Then
                server = New MyServer()
                server._sAE = fields(0).Trim()
                server._sIP = fields(1).Trim()
                server._port = Convert.ToInt32(fields(2).Trim())
                server._timeout = Convert.ToInt32(fields(3).Trim())
                server._useTls = Convert.ToBoolean(fields(4).Trim())
            End If
            Return server
        End Function

        Private Shared Function ParseServerList(ByVal serversString As String) As MyServer()
            '   /servers=ae1,ip1,port1,timeout1,secure1;ae1,ip1,port1,timeout1,secure1
            serversString.Trim()
            If serversString.EndsWith(";") Then
                serversString = serversString.Substring(0, serversString.Length - 1)
            End If
            Dim servers() As String = serversString.Split(";"c)

            Dim list As New ArrayList()
            For Each s As String In servers
                Dim server As MyServer = ParseOneServer(s)
                list.Add(server)
            Next s

            Dim items(servers.Length - 1) As MyServer
            list.CopyTo(items)
            Return items
        End Function

        ' Here are two sample command lines:
        '       /configure /server_aetitle=STORAGE_SCU /server_ip=10.1.1.167 /server_port=104 /defaults
        '       /configure /server_aetitle=test_server_ae /server_ip=10.1.1.123 /server_port=123 /client_aetitle=test_client_ae /client_ip=test_client_ip /client_port=456 /defaults
        '
        ' Here is how to configure more than one server
        '       /configure /defaults /servers=AE_1,1.1.1.1,101,31,false;AE_2,2.2.2.2,102,32,true

        Private Shared Function ReadCommandLine(ByVal args() As String) As Boolean
            Return False
        End Function

        Public Sub New()
            InitializeComponent()

            Me._medicalViewer = New Leadtools.MedicalViewer.MedicalViewer()
            '
            '_medicalViewer
            '
            Me._medicalViewer.AllowMultipleSelection = False
            Me._medicalViewer.AutoScroll = True
            Me._medicalViewer.CellMaintenance = False
            Me._medicalViewer.Columns = 1
            Me._medicalViewer.CustomSplitterColor = False
            Me._medicalViewer.Dock = System.Windows.Forms.DockStyle.Fill
            Me._medicalViewer.Location = New System.Drawing.Point(0, 23)
            Me._medicalViewer.Name = "_medicalViewer"
            Me._medicalViewer.ResizeBoth = System.Windows.Forms.Cursors.SizeAll
            Me._medicalViewer.ResizeHorizontalCursor = System.Windows.Forms.Cursors.SizeWE
            Me._medicalViewer.ResizeVerticalCursor = System.Windows.Forms.Cursors.SizeNS
            Me._medicalViewer.Rows = 1
            Me._medicalViewer.Size = New System.Drawing.Size(636, 243)
            Me._medicalViewer.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(200, Byte), Integer))
            Me._medicalViewer.SplitterStyle = Leadtools.MedicalViewer.MedicalViewerSplitterStyle.Thick
            Me._medicalViewer.TabIndex = 3
            Me._medicalViewer.Text = "_medicalViewer"
            Me._medicalViewer.UseExtraSplitters = False
            Me._medicalViewer.VisibleRow = 0

            Me._splitContainer5.Panel1.Controls.Add(Me._medicalViewer)

            If (Not DicomDemoSettingsManager.Is64Process()) Then
                Text = Text & " (32 bit)"
            Else
                Text = Text & "(64 bit)"
            End If
        End Sub

        Private Sub SizeColumns(ByVal lv As ListView)
            For Each header As ColumnHeader In lv.Columns
                header.Width = CType(lv.Width / lv.Columns.Count, Integer)
            Next header
        End Sub

        Private Sub _splitContainer2_Panel2_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles _splitContainer2.Panel2.Resize
        End Sub

        Private Sub _listViewStudies_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles _listViewStudies.Resize
            SizeColumns(_listViewStudies)
        End Sub

        Private Sub _listViewSeries_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles _listViewSeries.Resize
            SizeColumns(_listViewSeries)
        End Sub

        Private Function DoOptions() As DialogResult
            Dim options As New OptionsDialog()
            options.ServerList = _mySettings.ServerList

            Dim storageListCopy As New List(Of String)(_mySettings.StorageClassList)
            options.StorageClassList = storageListCopy
            options.ImageRetrieveMethod = _mySettings.DicomImageRetrieveMethod

            ' Certificate Authority
            options.CertificateAuthority = _mySettings.CertificateAuthority

            ' Client Settings
            options.ClientAE = _mySettings.ClientAe.AE
            options.ClientPort = _mySettings.ClientAe.Port
            options.ClientCertificate = _mySettings.ClientCertificate
            options.PrivateKey = _mySettings.ClientPrivateKey
            options.PrivateKeyPassword = _mySettings.ClientPrivateKeyPassword
            options.ClientPortSecurityUsage = _mySettings.ClientPortSecurityUsage

            ' Miscellaneous Settings
            options.LogLowLevel = _mySettings.LogLowLevel
            options.GroupLengthDataElements = _mySettings.GroupLengthDataElements
            options.CipherSuites = _mySettings.CipherSuites

            Dim dr As DialogResult = options.ShowDialog(Me)
            If dr = DialogResult.OK Then
                _mySettings.ServerList = options.ServerList

                ' Certificate Authority
                _mySettings.CertificateAuthority = options.CertificateAuthority

                ' Client Settings
                _mySettings.ClientAe.AE = options.ClientAE
                _mySettings.ClientAe.Port = Convert.ToInt32(options.ClientPort)
                _mySettings.ClientCertificate = options.ClientCertificate
                _mySettings.ClientPrivateKey = options.PrivateKey
                _mySettings.ClientPrivateKeyPassword = options.PrivateKeyPassword
                _mySettings.ClientPortSecurityUsage = options.ClientPortSecurityUsage

                ' Miscellaneous Settings
                _mySettings.LogLowLevel = options.LogLowLevel
                _mySettings.GroupLengthDataElements = options.GroupLengthDataElements
                _mySettings.StorageClassList = options.StorageClassList
                _mySettings.DicomImageRetrieveMethod = options.ImageRetrieveMethod
                _mySettings.CipherSuites = options.CipherSuites

                DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)

                UpdateComboBoxService()

                EnableItems(True)
            End If
            Return dr
        End Function

        Private Const defaultServerAE As String = "LEAD_SERVER"
        Private Const defaultServerIP As String = "127.0.0.1"
        Private Const defaultServerPort As Integer = 104
        Private Const defaultServerTimeout As Integer = 30
        Private Const defaultServerUseTls As Boolean = False

        Private Const defaultClientAE As String = "LEAD_CLIENT"
        Private Const defaultClientPort As Integer = 1000
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
            SetStorageClassListDefaults(settings)
            Return settings
        End Function

        Private Sub SetStorageClassListDefaults(ByVal settings As DicomDemoSettings)
            settings.StorageClassList.Clear()
            Dim uid As DicomUid = DicomUidTable.Instance.GetFirst()
            Do While uid IsNot Nothing
                If uid.Type = DicomUIDCategory.Class AndAlso uid.Code.StartsWith("1.2.840.10008.5.1.4.1.1") Then
                    settings.StorageClassList.Add(uid.Code)
                End If
                uid = DicomUidTable.Instance.GetNext(uid)
            Loop
        End Sub

        Private Sub SetOtherDefaults(ByVal settings As DicomDemoSettings)
            settings.CertificateAuthority = DicomDemoSettingsManager.GetCertificateAuthorityFullPath()
            settings.ClientCertificate = DicomDemoSettingsManager.GetClientCertificateFullPath()
            settings.ClientPrivateKey = DicomDemoSettingsManager.GetClientCertificateFullPath()
            settings.ClientPrivateKeyPassword = DicomDemoSettingsManager.GetClientCertificatePassword()

            settings.LogLowLevel = True
            settings.GroupLengthDataElements = False
            settings.ShowHelpOnStart = True

            Dim sDefaultIP As String = String.Empty
            Try
                sDefaultIP = GetDefaultIp()
            Catch e1 As Exception
            End Try
        End Sub

        Private Sub LoadSettings()
            Try
                ' Settings are stored at:
                ' %USERPROFILE%\Local Settings\Application Data\<Company Name>\<appdomainname>_<eid>_<hash>\<verison>\user.config

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
                        SetStorageClassListDefaults(_mySettings)
                    End If
                End If

                SetDefaultQueryServer()
                _mySettings.FirstRun = False
                DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)
            Catch ex As Exception
                System.Diagnostics.Debug.Assert(False, ex.Message)
            End Try
        End Sub

        Private Sub SetDefaultQueryServer()
            Dim defaultAE As DicomAE = _mySettings.GetServer(_mySettings.DefaultImageQuery)
            If _comboBoxService.SelectedIndex >= 0 Then
                defaultAE = _mySettings.ServerList(_comboBoxService.SelectedIndex)
            End If

            If Nothing IsNot defaultAE Then
                _server.AETitle = defaultAE.AE
                _server.Port = CInt(Fix(defaultAE.Port))
                _server.PeerAddress = IPAddress.Parse(defaultAE.IPAddress)
                _server.Timeout = defaultAE.Timeout

                _textBoxServerIp.Text = _server.PeerAddress.ToString()
                _textBoxServerPort.Text = _server.Port.ToString()
            End If
        End Sub

        Private Sub UpdateDefaultServerAE()
            If _comboBoxService.Items.Count > 0 Then
                _mySettings.DefaultImageQuery = _comboBoxService.GetSelectedAETitle()

                DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)

                SetDefaultQueryServer()
            End If
        End Sub

        Private Sub SelectDefaultServerAE()
            If _comboBoxService.Items.Count > 0 Then
                _comboBoxService.SetSelectedItem(_mySettings.DefaultImageQuery)

                If -1 = _comboBoxService.SelectedIndex AndAlso _comboBoxService.Items.Count > 0 Then
                    _comboBoxService.SelectedIndex = 0
                End If

                If _comboBoxService.Items.Count > 0 Then
                    _mySettings.DefaultImageQuery = _comboBoxService.GetSelectedAETitle()
                Else
                    _mySettings.DefaultImageQuery = String.Empty
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
            Dim defaultAE As DicomAE = _mySettings.GetServer(_mySettings.DefaultImageQuery)
            If _comboBoxService.SelectedIndex >= 0 Then
                defaultAE = _mySettings.ServerList(_comboBoxService.SelectedIndex)
            End If

            If defaultAE IsNot Nothing Then
                useTls = defaultAE.UseTls
            End If
            Return useTls
        End Function

        Private Sub SetCipherSuites(ByVal scu As DicomNet)
            ' Zero out the CipherSuite list
            scu.SetTlsCipherSuiteByIndex(0, DicomTlsCipherSuiteType.None)

            ' Add the new CipherSuites in order of priority
            Dim cipherCount As Integer = 0
            For Each cipherSuiteItem As CipherSuiteItem In _mySettings.CipherSuites.ItemList
                If cipherSuiteItem.IsChecked Then
                    scu.SetTlsCipherSuiteByIndex(cipherCount, cipherSuiteItem.Cipher)
                    cipherCount += 1
                End If
            Next cipherSuiteItem
        End Sub

        Private Sub CreateCFindObject()

            If _find IsNot Nothing Then
                _find.Dispose()
            End If


            Dim useTls As Boolean = GetDefaultUseTls()
            If useTls Then
#If LEADTOOLS_V20_OR_LATER Then
                Const securityMode As DicomNetSecurityMode = DicomNetSecurityMode.Tls
#Else
			Const securityMode As DicomNetSecurityeMode = DicomNetSecurityeMode.Tls
#End If

                Dim s As New DicomOpenSslContextCreationSettings(DicomSslMethodType.SslV2, _mySettings.CertificateAuthority, DicomOpenSslVerificationFlags.All, 9, DicomOpenSslOptionsFlags.AllBugWorkarounds)
                _find = New MyQueryRetrieveScu(Me, String.Empty, securityMode, s)
                ' _find = new MyQueryRetrieveScu(this, string.Empty, securityMode, null);
            Else
                _find = New MyQueryRetrieveScu(Me)
            End If

            Select Case _mySettings.ClientPortSecurityUsage
                Case ClientPortUsageType.Unsecure
                    _find.UseSecureHost = False
                Case ClientPortUsageType.SameAsServer
                    _find.UseSecureHost = useTls
                Case ClientPortUsageType.Secure
                    _find.UseSecureHost = True
            End Select

            AddHandler _find.HostReady, AddressOf _find_HostReady

            _find.MaxLength = 46726
            _find.ImplementationClass = _sConfigurationImplementationClass
            _find.ProtocolVersion = _sConfigurationProtocolversion
            _find.ImplementationVersionName = _sConfigurationImplementationVersionName
            _find.AETitle = _mySettings.ClientAe.AE
            _find.HostPort = _mySettings.ClientAe.Port

#If LEADTOOLS_V19_OR_LATER Then
            _find.Flags = DicomNetFlags.None
            If _mySettings.GroupLengthDataElements Then
                _find.Flags = _find.Flags Or DicomNetFlags.SendDataWithGroupLengthStandardDataElements
            End If
#End If

            AddHandler _find.BeforeConnect, AddressOf _find_BeforeConnect
            AddHandler _find.AfterConnect, AddressOf _find_AfterConnect
            AddHandler _find.AfterSecureLinkReady, AddressOf _find_AfterSecureLinkReady
            AddHandler _find.BeforeAssociateRequest, AddressOf _find_BeforeAssociateRequest
            AddHandler _find.AfterAssociateRequest, AddressOf _find_AfterAssociateRequest
            AddHandler _find.BeforeReleaseRequest, AddressOf _find_BeforeAssociateRelease
            AddHandler _find.AfterReleaseRequest, AddressOf _find_AfterAssociateRelease
            AddHandler _find.BeforeClose, AddressOf _find_BeforeClose
            AddHandler _find.AfterClose, AddressOf _find_AfterClose

            AddHandler _find.MatchStudy, AddressOf _find_MatchStudy
            AddHandler _find.MatchSeries, AddressOf _find_MatchSeries
            AddHandler _find.BeforeCFind, AddressOf _find_BeforeCFind
            AddHandler _find.AfterCFind, AddressOf _find_AfterCFind

            AddHandler _find.BeforeCMove, AddressOf _find_BeforeCMove
            AddHandler _find.Moved, AddressOf _find_Moved
            AddHandler _find.AfterCMove, AddressOf _find_AfterCMove

#If LEADTOOLS_V18_OR_LATER Then
            AddHandler _find.BeforeCGet, AddressOf _find_BeforeCGet
            AddHandler _find.ReceivedStoreRequest, AddressOf _find_ReceivedStoreRequest
            AddHandler _find.AfterCGet, AddressOf _find_AfterCGet
#End If

            AddHandler _find.PrivateKeyPassword, AddressOf _find_PrivateKeyPassword

            If useTls Then
                Try
                    SetCipherSuites(_find)
                    _find.SetTlsClientCertificate(_mySettings.ClientCertificate, DicomTlsCertificateType.Pem, If(_mySettings.ClientPrivateKey.Length > 0, _mySettings.ClientPrivateKey, Nothing))
                Catch ex As Exception
                    LogError(ex.Message)
                End Try
            End If

            If _mySettings.LogLowLevel Then
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
            _find.DebugLogFilename = String.Empty
            _find.EnableDebugLog = True

            SetDefaultQueryServer()
        End Sub

        Private Sub _find_HostReady(ByVal sender As Object, ByVal e As HostReadyEventArgs)
            Dim host As DicomConnection = e.ScpHost
            If host.SecurityMode = DicomNetSecurityMode.Tls Then
                AddHandler host.PrivateKeyPassword, AddressOf Host_PrivateKeyPassword
                host.SetTlsClientCertificate(_mySettings.ClientCertificate, DicomTlsCertificateType.Pem, _mySettings.ClientCertificate)
                RemoveHandler host.PrivateKeyPassword, AddressOf Host_PrivateKeyPassword

                host.SetTlsCipherSuiteByIndex(0, 0)

                host.SetTlsCipherSuiteByIndex(0, DicomTlsCipherSuiteType.DheRsaWithDesCbcSha)
                host.SetTlsCipherSuiteByIndex(1, DicomTlsCipherSuiteType.DheRsaWith3DesEdeCbcSha)
                host.SetTlsCipherSuiteByIndex(2, DicomTlsCipherSuiteType.DheRsaAes256Sha)
                host.SetTlsCipherSuiteByIndex(3, DicomTlsCipherSuiteType.RsaWithAes128CbcSha)
                host.SetTlsCipherSuiteByIndex(4, DicomTlsCipherSuiteType.RsaWith3DesEdeCbcSha)
                host.SetTlsCipherSuiteByIndex(5, DicomTlsCipherSuiteType.DheRsaWithAes128GcmSha256)
                host.SetTlsCipherSuiteByIndex(6, DicomTlsCipherSuiteType.EcdheRsaWithAes128GcmSha256)
                host.SetTlsCipherSuiteByIndex(7, DicomTlsCipherSuiteType.DheRsaWithAes256GcmSha384)
                host.SetTlsCipherSuiteByIndex(8, DicomTlsCipherSuiteType.EcdheRsaWithAes256GcmSha384)
            End If
        End Sub

        Private Sub Host_PrivateKeyPassword(ByVal sender As Object, ByVal e As PrivateKeyPasswordEventArgs)
            e.PrivateKeyPassword = _mySettings.ClientPrivateKeyPassword
        End Sub

#If LEADTOOLS_V18_OR_LATER Then
        Private Sub _find_BeforeCGet(ByVal sender As Object, ByVal e As BeforeCGetEventArgs)
            Dim message As String = _sNewlineTab & "Priority:" & Constants.vbTab.ToString & e.Priority & e.Scp.ToString()
            LogText("Before CGet", message)
            EnableCancel(True)
            _retrieveCount = 0
        End Sub

        Private Sub _find_ReceivedStoreRequest(ByVal sender As Object, ByVal e As ReceivedStoreRequestEventArgs)
            ReceiveCStore(e)

            Dim sMsg As String = String.Format("Retrieved {0} of {1} instances", _retrieveCount, _totalRetrieveCount)
            StatusText(sMsg)
        End Sub

        Private Sub _find_AfterCGet(ByVal sender As Object, ByVal e As AfterCGetEventArgs)
            Dim message As String
            If e.Status = DicomCommandStatusType.Success OrElse e.Status = DicomCommandStatusType.Pending OrElse e.Status = DicomCommandStatusType.Warning Then
                message = _sNewlineTab & "Status:" & Constants.vbTab + e.Status.ToString() & _sNewlineTab & "Completed:" & Constants.vbTab + e.Completed.ToString() & _sNewlineTab & "Warning:" & Constants.vbTab + e.Warning.ToString() & _sNewlineTab & "Failed:" & Constants.vbTab + e.Failed.ToString()
            Else
                message = _sNewlineTab & " CGet failed" & Constants.vbCrLf & Constants.vbTab & "Status: " & e.Status.ToString()
            End If
            LogText("After CGet", message)
            If e.Status <> DicomCommandStatusType.Pending Then
                EnableCancel(False)
            End If
        End Sub
#End If

        Private Sub _find_AfterSecureLinkReady(ByVal sender As Object, ByVal e As AfterSecureLinkReadyEventArgs)
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

        Private Sub _find_PrivateKeyPassword(ByVal sender As Object, ByVal e As PrivateKeyPasswordEventArgs)
            e.PrivateKeyPassword = _mySettings.ClientPrivateKeyPassword
        End Sub

        Private Sub UpdateUI()
            _radioButtonCMove.Checked = (_mySettings.DicomImageRetrieveMethod = DicomRetrieveMode.CMove)
            _radioButtonCGet.Checked = (_mySettings.DicomImageRetrieveMethod = DicomRetrieveMode.CGet)
            buttonCGetStorageClasses.Visible = _radioButtonCGet.Checked
        End Sub

        Private Sub InitializeMedicalViewerCell(ByVal cell As MedicalViewerMultiCell)
            cell.AddAction(MedicalViewerActionType.WindowLevel)
            cell.AddAction(MedicalViewerActionType.Stack)
            cell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.Active)
            cell.SetAction(MedicalViewerActionType.Stack, MedicalViewerMouseButtons.Wheel, MedicalViewerActionFlags.Active)

            ' Set the relative sensitivity to true to raise the sensitivity on the images with large lookup table
            Using windowLevelActionProperties As MedicalViewerWindowLevel = CType(cell.GetActionProperties(MedicalViewerActionType.WindowLevel, 0), MedicalViewerWindowLevel)
                windowLevelActionProperties.RelativeSensitivity = True
                cell.SetActionProperties(MedicalViewerActionType.WindowLevel, windowLevelActionProperties, 0)
            End Using

            cell.OverlayTextSize = 12
        End Sub


        Private Sub AppendTextColor(ByVal text As String, ByVal color As Color)
            Dim oldColor As Color = _richTextBoxLog.SelectionColor

            _richTextBoxLog.SelectionLength = text.Length
            _richTextBoxLog.SelectionStart = _richTextBoxLog.Text.Length
            _richTextBoxLog.SelectionColor = color
            _richTextBoxLog.SelectionFont = New Font(_richTextBoxLog.SelectionFont, FontStyle.Bold)
            _richTextBoxLog.AppendText(text)
            _richTextBoxLog.SelectionColor = oldColor
        End Sub

        Private Sub AddAction(ByVal sAction As String, ByVal color As Color)
            Dim oldColor As System.Drawing.Color = _richTextBoxLog.SelectionColor

            _richTextBoxLog.SelectionLength = sAction.Length
            _richTextBoxLog.SelectionStart = _richTextBoxLog.Text.Length
            _richTextBoxLog.SelectionColor = color
            _richTextBoxLog.SelectionFont = New Font(_richTextBoxLog.SelectionFont, FontStyle.Bold)
            _richTextBoxLog.AppendText(sAction & ": ")
            _richTextBoxLog.SelectionColor = oldColor
        End Sub

        Public Sub LogText(ByVal sAction As String, ByVal sLogText As String, ByVal sActionColor As Color)
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
                        _richTextBoxLog.AppendText(sLogText)
                    End If
                    _richTextBoxLog.AppendText(_sNewline)
                    TextBoxTraceListener.SendMessage(_richTextBoxLog.Handle, TextBoxTraceListener.WM_VSCROLL, TextBoxTraceListener.SB_BOTTOM, 0)
                End If
            Catch e1 As Exception
            Finally
            End Try
        End Sub

        Public Sub LogText(ByVal sAction As String, ByVal sLogText As String)
            LogText(sAction, sLogText, Color.Blue)
        End Sub

        Public Sub LogWarning(ByVal sAction As String, ByVal sLogText As String)
            LogText(sAction, sLogText, Color.Red)
        End Sub

        Public Sub LogError(ByVal sLogText As String)
            LogText("*** ERROR *** ", _sNewlineTab & sLogText, Color.Red)
        End Sub


        Private Sub _find_BeforeConnect(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.BeforeConnectEventArgs)
            LogText("Before Connect", e.Scp.ToString())

        End Sub
        Private Sub _find_AfterConnect(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.AfterConnectEventArgs)
            Dim message As String
            If e.Error = DicomExceptionCode.Success Then
                message = _sNewlineTab & "Connection Successful"
            Else
                message = _sNewlineTab & "Connection failed" & _sNewlineTab & "Error:" & Constants.vbTab + e.Error.ToString()
            End If

            LogText("After Connect", message)
        End Sub

        Private Sub _find_BeforeAssociateRequest(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.BeforeAssociateRequestEventArgs)
            LogText("Before Associate Request", e.Associate.ToString())
        End Sub

        Private Sub _find_AfterAssociateRequest(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.AfterAssociateRequestEventArgs)
            Dim message As String
            If e.Rejected Then
                message = _sNewlineTab & "Association Rejected" & _sNewlineTab & "Result: " & e.Result.ToString() & _sNewlineTab & "Reason: " & e.Reason.ToString() & _sNewlineTab & "Source: " & e.Source.ToString()
            Else
                message = _sNewlineTab & "Association Accepted"
                If e.Associate IsNot Nothing Then
                    message = message & e.Associate.ToString()
                End If
            End If
            LogText("After Associate Request", message)
        End Sub

        Private Sub _find_BeforeAssociateRelease(ByVal sender As Object, ByVal e As EventArgs)
            LogText("Before Associate Release", String.Empty)
        End Sub

        Private Sub _find_AfterAssociateRelease(ByVal sender As Object, ByVal e As EventArgs)
            LogText("After Associate Release", String.Empty)
        End Sub

        Private Sub _find_BeforeClose(ByVal sender As Object, ByVal e As EventArgs)
            LogText("Before Close", String.Empty)
        End Sub

        Private Sub _find_AfterClose(ByVal sender As Object, ByVal e As EventArgs)
            LogText("After Close", String.Empty)
        End Sub

        Private Sub _find_BeforeCFind(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.BeforeCFindEventArgs)
            Dim message As String = _sNewlineTab & "QueryLevel:" & Constants.vbTab + e.QueryLevel.ToString() & _sNewlineTab & "Priority:" & Constants.vbTab + e.Priority.ToString()

            LogText("Before CFind", message)

            EnableCancel(True)
        End Sub

        Private Sub _find_AfterCFind(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.AfterCFindEventArgs)
            Dim message As String
            If e.Status = DicomCommandStatusType.Success Then
                message = _sNewlineTab & "MatchCount:" & Constants.vbTab + e.MatchCount.ToString() & _sNewlineTab & "Status:" & Constants.vbTab + e.Status.ToString()
            Else
                message = _sNewlineTab & " CFind failed" & _sNewlineTab & "Status: " & e.Status.ToString()
            End If
            LogText("After CFind", message)
            EnableCancel(False)
        End Sub

        Private Sub _find_MatchStudy(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.MatchEventArgs(Of Study))
            Dim message As String = _sNewlineTab & "QueryLevel: " & e.QueryLevel.ToString() & _sNewlineTab & "Availability:" & Constants.vbTab + e.Availability.ToString() & _sNewlineTab & "Info:" & Constants.vbTab + e.Info.ToString() & _sNewlineTab & "RetrieveAETitle:" & Constants.vbTab + e.RetrieveAETitle.ToString()
            LogText("Study Match Found", message)
            AddStudyItem(e)
        End Sub

        Private Sub _find_MatchSeries(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.MatchEventArgs(Of Series))
            Dim message As String = _sNewlineTab & "QueryLevel: " & e.QueryLevel.ToString() & _sNewlineTab & "Availability:" & Constants.vbTab + e.Availability.ToString() & _sNewlineTab & "Info:" & Constants.vbTab + e.Info.ToString() & _sNewlineTab & "RetrieveAETitle:" & Constants.vbTab + e.RetrieveAETitle.ToString()
            LogText("Series Match Found", message)
            AddSeriesItem(e)
        End Sub

        Private Sub _find_BeforeCMove(ByVal sender As Object, ByVal e As BeforeCMoveEventArgs)
            Dim message As String = _sNewlineTab & "Priority:" & Constants.vbTab + e.Priority.ToString() + e.Scp.ToString() & _sNewlineTab & "Destination AE:" & Constants.vbTab + e.DestinationAETitle
            LogText("Before CMove", message)
            EnableCancel(True)
            _retrieveCount = 0
        End Sub

        Private Sub _find_AfterCMove(ByVal sender As Object, ByVal e As AfterCMoveEventArgs)
            Dim message As String
            If e.Status = DicomCommandStatusType.Success OrElse e.Status = DicomCommandStatusType.Pending OrElse e.Status = DicomCommandStatusType.Warning Then
                message = _sNewlineTab & "Status:" & Constants.vbTab + e.Status.ToString() & _sNewlineTab & "Completed:" & Constants.vbTab + e.Completed.ToString() & _sNewlineTab & "Warning:" & Constants.vbTab + e.Warning.ToString() & _sNewlineTab & "Failed:" & Constants.vbTab + e.Failed.ToString()
            Else
                message = _sNewlineTab & " CMove failed" & Constants.vbCrLf & Constants.vbTab & "Status: " & e.Status.ToString()
            End If
            LogText("After CMove", message)
            If e.Status <> DicomCommandStatusType.Pending Then
                EnableCancel(False)
            End If
        End Sub

        Private Class CStoreReceivedArgs
            Public Patient As Patient
            Public Study As Study
            Public Series As Series
            Public Instance As CompositeObjectInstance

            Public Sub New(ByVal e As MovedEventArgs)
                Patient = e.Patient
                Study = e.Study
                Series = e.Series
                Instance = e.Instance
            End Sub

            Public Sub New(ByVal e As ReceivedStoreRequestEventArgs)
                Patient = e.Patient
                Study = e.Study
                Series = e.Series
                Instance = e.Instance
            End Sub
        End Class

        Public Delegate Sub ReceiveFindMovedDelegate(ByVal e As Leadtools.Dicom.Scu.Common.MovedEventArgs)

        Private Sub ReceiveFindMoved(ByVal e As Leadtools.Dicom.Scu.Common.MovedEventArgs)
            If InvokeRequired Then
                Invoke(New ReceiveFindMovedDelegate(AddressOf ReceiveFindMoved), e)
            Else
                Dim args As New CStoreReceivedArgs(e)
                ReceiveDataFromCStore(args)
            End If
        End Sub

        Public Delegate Sub ReceiveGetStoredDelegate(ByVal e As Leadtools.Dicom.Scu.Common.ReceivedStoreRequestEventArgs)
        Private Sub ReceiveCStore(ByVal e As Leadtools.Dicom.Scu.Common.ReceivedStoreRequestEventArgs)
            If InvokeRequired Then
                Invoke(New ReceiveGetStoredDelegate(AddressOf ReceiveCStore), e)
            Else
                Dim args As New CStoreReceivedArgs(e)
                ReceiveDataFromCStore(args)
            End If
        End Sub

        Private Sub ReceiveDataFromCStore(ByVal e As CStoreReceivedArgs)
            Dim message As String = _sNewlineTab & "PatientId:" & Constants.vbTab + e.Patient.Id + _sNewlineTab & "StudyInstanceUID:" & Constants.vbTab + e.Study.InstanceUID + _sNewlineTab & "SeriesInstanceUID:" & Constants.vbTab + e.Series.InstanceUID + _sNewlineTab & "SOPInstanceUID:" & Constants.vbTab + e.Instance.SOPInstanceUID

            If _mySettings.DicomImageRetrieveMethod = DicomRetrieveMode.CMove Then
                LogText("Moved", message)
            Else
                LogText("Stored", message)
            End If
            _retrieveCount += 1

            If e.Instance.InstanceType = InstanceLevel.Image Then
                Dim instance As ImageInstance = TryCast(e.Instance, ImageInstance)
                Dim cols As Integer = 1
                Dim rows As Integer = 1
                If instance.Images IsNot Nothing Then
                    Dim pageCount As Integer = instance.Images.PageCount
                    If pageCount > 1 Then
                        ' Display at most 6 x 6 (36) frames
                        If pageCount >= 36 Then
                            cols = 6
                            rows = 6
                        Else
                            cols = CInt(Fix(Math.Floor(Math.Sqrt(pageCount))))
                            rows = CInt(Fix(Math.Ceiling(CDbl(pageCount) / cols)))
                        End If
                    End If

                    Dim m As MedicalViewerMultiCell = GetCell()

                    m.Rows = rows
                    m.Columns = cols

                    If m.Image IsNot Nothing Then
                        For pageIndex As Integer = 0 To instance.Images.PageCount - 1
                            instance.Images.Page = pageIndex + 1

                            m.Image.AddPage(instance.Images)
                        Next pageIndex
                    Else
                        m.Image = instance.Images
                    End If

                    If pageCount > 1 Then
                        m.SetTag(0, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.Frame)
                        m.ShowTags = True
                    End If
                    m.SetTag(1, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.WindowLevelData)

                    ' Give the medical viewer cell the focus
                    If _medicalViewer.Cells.Count > 0 AndAlso TypeOf _medicalViewer.Cells(0) Is MedicalViewerBaseCell Then
                        TryCast(_medicalViewer.Cells(0), MedicalViewerBaseCell).Selected = True
                    End If

                    m.SetScaleMode(MedicalViewerScaleMode.Fit)
                End If
            End If
        End Sub


        Private Function GetCell() As MedicalViewerMultiCell
            If _medicalViewer.Cells.Count > 0 Then
                Return TryCast(_medicalViewer.Cells(0), MedicalViewerMultiCell)
            Else
                Dim m As New MedicalViewerMultiCell()

                InitializeMedicalViewerCell(m)
                m.FitImageToCell = True
                m.DisplayRulers = MedicalViewerRulers.None

                ' m.SetScaleMode(MedicalViewerScaleMode.Fit)

                _medicalViewer.Cells.Add(m)

                Return m
            End If
        End Function

        Private Sub _find_Moved(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.MovedEventArgs)
            ReceiveFindMoved(e)

            Dim sMsg As String = String.Format("Retrieved {0} of {1} instances", _retrieveCount, _totalRetrieveCount)
            StatusText(sMsg)
        End Sub

        Public Delegate Sub StartUpdateDelegate(ByVal lv As ListView)
        Private Sub StartUpdate(ByVal lv As ListView)
            If InvokeRequired Then
                Invoke(New StartUpdateDelegate(AddressOf StartUpdate), lv)
            Else
                lv.Items.Clear()
                lv.BeginUpdate()
            End If
        End Sub

        Public Delegate Sub EndUpdateDelegate(ByVal lv As ListView)
        Private Sub EndUpdate(ByVal lv As ListView)
            If InvokeRequired Then
                Invoke(New EndUpdateDelegate(AddressOf EndUpdate), lv)
            Else
                lv.EndUpdate()
            End If
        End Sub


        Public Delegate Sub AddStudyItemDelegate(ByVal ds As MatchEventArgs(Of Study))
        Private Sub AddStudyItem(ByVal e As MatchEventArgs(Of Study))
            Dim item As ListViewItem

            If InvokeRequired Then
                Invoke(New AddStudyItemDelegate(AddressOf AddStudyItem), e)
            Else
                item = _listViewStudies.Items.Add(e.Info.Patient.Name.Full)
                item.SubItems.Add(e.Info.Patient.Id)
                item.SubItems.Add(e.Info.AccessionNumber)
                item.SubItems.Add(If(e.Info.Date.HasValue, e.Info.Date.Value.ToString("d"), String.Empty))
                item.SubItems.Add(If(e.Info.Time.HasValue, e.Info.Time.ToString(), String.Empty))
                item.SubItems.Add(e.Info.ReferringPhysiciansName.Full)
                item.SubItems.Add(e.Info.Description)

                item.Tag = e.Info
            End If
        End Sub

        Public Delegate Sub AddSeriesItemDelegate(ByVal e As MatchEventArgs(Of Series))
        Private Sub AddSeriesItem(ByVal e As MatchEventArgs(Of Series))
            Dim item As ListViewItem

            If InvokeRequired Then
                Invoke(New AddSeriesItemDelegate(AddressOf AddSeriesItem), e)
            Else

                item = _listViewSeries.Items.Add(If(e.Info.Date.HasValue, e.Info.Date.Value.ToString("d"), String.Empty))
                item.SubItems.Add(e.Info.Number.ToString())
                item.SubItems.Add(e.Info.Description)
                item.SubItems.Add(e.Info.Modality)
                item.SubItems.Add(e.Info.NumberOfRelatedInstances.ToString())

                Dim mySeries As New MySeries(e.Info)
                item.Tag = mySeries
            End If
        End Sub

        Public Delegate Sub EnableCancelDelegate(ByVal enable As Boolean)
        Public Sub EnableCancel(ByVal enable As Boolean)
            If InvokeRequired Then
                Invoke(New EnableCancelDelegate(AddressOf EnableCancel), enable)
            Else
                _canCancel = enable
                _buttonCancel.Enabled = _canCancel
            End If
        End Sub


        Public Delegate Sub EnableItemsDelegate(ByVal enable As Boolean)
        Public Sub EnableItems(ByVal enable As Boolean)
            If InvokeRequired Then
                Invoke(New EnableItemsDelegate(AddressOf EnableItems), enable)
            Else
                _comboBoxService.Enabled = enable
                _textBoxServerIp.Enabled = enable
                _textBoxServerPort.Enabled = enable
                _menuStrip.Enabled = enable
                _listViewStudies.Enabled = enable
                _listViewSeries.Enabled = enable
                _buttonSearch.Enabled = enable AndAlso (_mySettings.ServerList.Count > 0)
                _buttonOptions.Enabled = enable
                _buttonCancel.Enabled = (Not enable) AndAlso _canCancel

                _radioButtonCMove.Enabled = enable AndAlso (_listViewSeries.Items.Count > 0)
                _radioButtonCGet.Enabled = enable AndAlso (_listViewSeries.Items.Count > 0)
                buttonCGetStorageClasses.Enabled = _radioButtonCGet.Enabled AndAlso (_listViewSeries.SelectedItems.Count > 0)
            End If
        End Sub

        Private Sub DoSearch()
            'Cursor = Cursors.WaitCursor;
            ClearCells()

            _listViewSeries.Items.Clear()

            EnableItems(False)
            StartUpdate(_listViewStudies)
            _find.AETitle = _mySettings.ClientAe.AE
            _find.HostPort = _mySettings.ClientAe.Port

            'string 
            Dim t As New Thread(AddressOf AnonymousMethod1)
            t.Start()
            Do While t.IsAlive
                Application.DoEvents()
                If _closing Then
                    t.Abort()
                    Exit Do
                End If
            Loop

            EnableItems(True)
            EndUpdate(_listViewStudies)
            StatusText(String.Empty)
            'Cursor = Cursors.Default;
        End Sub
        Private Sub AnonymousMethod1()
            Try
                _find.Find(_server, _findQuery)
            Catch ex As Exception
                LogError(ex.Message)
                If String.Compare(ex.Message, "The attempt to connect was forcefully rejected", True) = 0 Then
                    If _mySettings.IsPreconfigured Then
                        Dim serverManagerDemo As String = "CSLeadtools.Dicom.Server.Manager.exe"
                        Dim sImportant As String = String.Format(Constants.vbLf + Constants.vbTab & "This demo is preconfigured to communicate with {0} DICOM Service." & Constants.vbLf + Constants.vbTab & "To start the service:" & Constants.vbLf + Constants.vbTab & "* Run {1}" & Constants.vbLf + Constants.vbTab & "* Select the {0} service" & Constants.vbLf + Constants.vbTab & "* Click the 'Start Server' button (blue triangle) to start the DICOM service.", _server.AETitle, serverManagerDemo)

                        If _server.AETitle.Equals(_mySettings.HighLevelStorageServer) Then
                            serverManagerDemo = "CSStorageServerManagerDemo_Original.exe"
                            sImportant = String.Format(Constants.vbLf + Constants.vbTab & "This demo is preconfigured to communicate with {0} DICOM Service." & Constants.vbLf + Constants.vbTab & "To start the service:" & Constants.vbLf + Constants.vbTab & "* Run {1}" & Constants.vbLf + Constants.vbTab & "* Click the 'Start Storage Service' button (blue triangle) to start the DICOM service.", _server.AETitle, serverManagerDemo)
                        ElseIf _server.AETitle.Equals(_mySettings.WorkstationServer) Then
                            serverManagerDemo = "CSMedicalWorkstationMainDemo_Original.exe"
                            sImportant = String.Format(Constants.vbLf + Constants.vbTab & "This demo is preconfigured to communicate with {0} DICOM Service." & Constants.vbLf + Constants.vbTab & "To start the service:" & Constants.vbLf + Constants.vbTab & "* Run {1}" & Constants.vbLf + Constants.vbTab & "* Click the 'Service Manager' button (in toolbar at bottom) " & Constants.vbLf + Constants.vbTab & "* Click the 'Start Server' button (blue triangle) to start the DICOM service.", _server.AETitle, serverManagerDemo)
                        End If

                        LogText("*** IMPORTANT ***", sImportant, Color.Red)
                    End If
                End If
            End Try
        End Sub

        'private void ClearCells()
        '{
        '   this._medicalViewer.Cells.Clear();
        '   if (_medicalViewer.Cells != 0 && _medicalViewer.Cells.Count > 0)
        '   {
        '      MedicalViewerMultiCell mc = _medicalViewer.Cells[0] as MedicalViewerMultiCell;
        '      if (mc != null)
        '      {
        '         mc.Image.Del
        '      }
        '   }
        '}

        Private Sub ClearCells()
            If _medicalViewer IsNot Nothing Then
                Me._medicalViewer.Cells.Clear()
            End If
            Return

            'Dim cells As List(Of Control)

            'cells = New List(Of Control)()

            'cells.AddRange(Me._medicalViewer.Cells)

            'For Each cell As Control In cells
            '    Dim mc As MedicalViewerMultiCell = TryCast(cell, MedicalViewerMultiCell)

            '    If mc IsNot Nothing Then
            '        If mc.Image IsNot Nothing Then
            '            Dim image As RasterImage

            '            image = mc.Image

            '            mc.Image = Nothing 'this causes problem

            '            image = Nothing
            '        End If
            '    End If
            '    cell.Dispose()

            '    Me._medicalViewer.Cells.Remove(cell)
            'Next cell

            'cells.Clear()
        End Sub

        Private Sub DoCancel()
            If _find.IsAssociated() Then
                _find.AETitle = _mySettings.ClientAe.AE
                _find.HostPort = _mySettings.ClientAe.Port
                _find.CancelRequest()
                LogText("Cancelled", _sNewlineTab & "Sent C-Cancel")
                StatusText("Cancelled")
            End If
        End Sub

        Private Sub AnonymousMethod2()
            Dim study As Study = TryCast(_listViewStudies.SelectedItems(0).Tag, Study)
            ClearCells()

            If study.InstanceUID.Length > 0 Then
                Dim query As New FindQuery()

                Cursor = Cursors.WaitCursor
                StartUpdate(_listViewSeries)
                EnableItems(False)

                query.QueryLevel = QueryLevel.Series
                query.PatientId = study.Patient.Id
                query.StudyInstanceUID = study.InstanceUID
                Try
                    _find.Find(_server, query)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End Sub

        Private Sub _listViewStudies_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _listViewStudies.SelectedIndexChanged
            If _listViewStudies.SelectedItems.Count = 0 Then
                Return
            End If

            Dim t As New Thread(AddressOf AnonymousMethod2)
                t.Start()
                Do While t.IsAlive
                    Application.DoEvents()
                    If _closing Then
                        t.Abort()
                        Exit Do
                    End If
                Loop

            EnableItems(True)
                EndUpdate(_listViewSeries)
            Cursor = Cursors.Default
        End Sub

        Private Sub MoveThread()
            Dim mySeries As MySeries = TryCast(_listViewSeries.SelectedItems(0).Tag, MySeries)
            Dim study As Study = TryCast(_listViewStudies.SelectedItems(0).Tag, Study)
            _totalRetrieveCount = mySeries.Series.NumberOfRelatedInstances
            Try
                If Me._radioButtonCMove.Checked Then
                    _find.Move(_server, _mySettings.ClientAe.AE, study.InstanceUID, mySeries.Series.InstanceUID)
#If LEADTOOLS_V18_OR_LATER Then
                Else
                    mySeries.SetDefaultAdditionalPresentationContexts()

                    Try
                        _find.Get(_server, study.InstanceUID, mySeries.Series.InstanceUID, mySeries.AdditionalPresentationContexts)
                    Catch ex As Exception
                        Dim [error] As String = ex.Message.ToLower()
                        Const errorUnsupported As String = "Abstract Syntax Not Supported"
                        If [error].Contains(errorUnsupported.ToLower()) AndAlso [error].Contains(DicomUidType.StudyRootQueryGet) Then
                            Dim message As String = String.Format("{1}{0} does not support C-GET{1}Do one of the following{1}* Click the 'Options' button and change the 'Image Retrieve Method' to C-MOVE or{1}* Select a server that supports C-GET", _server.AETitle, _sNewlineTab)

                            For Each dicomAE As DicomAE In _mySettings.ServerList
                                Dim mc As MatchCollection = Regex.Matches(dicomAE.AE, "L[0-9][0-9]_SERVER")
                                If mc.Count > 0 Then
                                    message = message & String.Format("(i.e. {0})", mc(0).Value)
                                End If
                                Exit For
                            Next dicomAE

                            LogWarning("Could not Retrieve Image", message)
                        Else
                            Throw ex
                        End If
                    End Try
#End If
                End If
            Catch ex As Exception
                LogError(ex.Message)
            End Try
        End Sub

        Private Sub _listViewSeries_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles _listViewSeries.DoubleClick
            If _listViewStudies.SelectedItems.Count = 0 Then
                Return
            End If

            Dim study As Study = TryCast(_listViewStudies.SelectedItems(0).Tag, Study)
            If study Is Nothing Then
                Return
            End If

            Dim mySeries As MySeries = TryCast(_listViewSeries.SelectedItems(0).Tag, MySeries)
            If mySeries Is Nothing Then
                Return
            End If

            ClearCells()

            EnableItems(False)

            Try
                Dim t As New Thread(AddressOf MoveThread)

                t.Start()
                Do While t.IsAlive
                    Application.DoEvents()
                    If _closing Then
                        t.Abort()
                        Exit Do
                    End If
                Loop
            Catch ex As Exception
                LogError(ex.Message)
            End Try

            EnableItems(True)
            'Cursor = Cursors.Default;
        End Sub

        Private Sub clearLogToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles clearLogToolStripMenuItem.Click
            _richTextBoxLog.Clear()
        End Sub

        Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem.Click
            Application.Exit()
        End Sub

        Private Sub aboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aboutToolStripMenuItem.Click
            Dim dlg As New AboutDialog("DICOM High Level Client")

            dlg.ShowDialog(Me)
        End Sub

        Private Sub _toolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _toolStripMenuItem1.Click
            _richTextBoxLog.Clear()
        End Sub

        Private Sub Options_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _buttonOptions.Click
            ' Check if the options have changed
            If System.Windows.Forms.DialogResult.OK = DoOptions() Then
                CreateCFindObject()
            End If
        End Sub

        Private Sub optionsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optionsToolStripMenuItem.Click
            ' Check if the options have changed
            If System.Windows.Forms.DialogResult.OK = DoOptions() Then
                CreateCFindObject()
            End If
        End Sub

        Private Sub StatusText(ByVal s As String)
            _labelStatus.Text = s
            Application.DoEvents()
        End Sub

        Private Sub _buttonSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _buttonSearch.Click
            DoSearch()
        End Sub

        Private Sub searchToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles searchToolStripMenuItem.Click
            DoSearch()
        End Sub

        Private Sub _buttonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _buttonCancel.Click
            DoCancel()
        End Sub

        Private Sub ShowHelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showHelpToolStripMenuItem.Click
            Dim dlg As New HelpDialog(_mySettings.DefaultImageQuery, False)
            dlg.ShowDialog(Me)
        End Sub


        Private Sub _comboBoxService_SelectionChangeCommitted(ByVal sender As Object, ByVal e As EventArgs) Handles _comboBoxService.SelectionChangeCommitted
            UpdateDefaultServerAE()
            CreateCFindObject()
        End Sub

        Private Sub buttonCGetStorageClasses_Click(sender As System.Object, e As System.EventArgs) Handles buttonCGetStorageClasses.Click
            If _listViewSeries.SelectedItems.Count > 0 Then
                Dim mySeries As MySeries = TryCast(_listViewSeries.SelectedItems(0).Tag, MySeries)

                If mySeries IsNot Nothing Then
                    Dim dlg As New StorageClassesDialog()

                    If (Not mySeries.IsDirtyPresentationContextList) Then
                        mySeries.SetDefaultAdditionalPresentationContexts()
                    End If
                    dlg.PresentationContextList = mySeries.AdditionalPresentationContexts
                    If DialogResult.OK = dlg.ShowDialog() Then
                        mySeries.AdditionalPresentationContexts = dlg.PresentationContextList
                    End If
                End If
            End If
        End Sub

        Private Sub _radioButtonCMove_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles _radioButtonCMove.CheckedChanged
            If Me._radioButtonCMove.Checked Then
                _mySettings.DicomImageRetrieveMethod = DicomRetrieveMode.CMove
                DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)
                UpdateUI()
            End If
        End Sub
        Private Sub _radioButtonCGet_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles _radioButtonCGet.CheckedChanged
            If Me._radioButtonCGet.Checked Then
                _mySettings.DicomImageRetrieveMethod = DicomRetrieveMode.CGet
                DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)
                UpdateUI()
            End If
        End Sub

        Private Sub MainForm_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
            MyBase.Activate()
            If _firstTime AndAlso _mySettings.ShowHelpOnStart Then
                _firstTime = False
                Dim dlg As New HelpDialog(_mySettings.DefaultImageQuery, _mySettings.ShowHelpOnStart)
                dlg.ShowDialog(Me)
                If dlg.CheckBoxNoShowAgainResult Then
                    _mySettings.ShowHelpOnStart = False
                    DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)
                End If
            End If
        End Sub

        Private Sub MainForm_FormClosing_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
            _closing = True
            If _find IsNot Nothing AndAlso _find.IsConnected() Then
                _find.CloseForced(True)
            End If
        End Sub

        Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            StatusText(String.Empty)
            SizeColumns(_listViewStudies)
            SizeColumns(_listViewSeries)
            LoadSettings()

            DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)

            UpdateUI()
            Me._radioButtonCMove.Checked = (_mySettings.DicomImageRetrieveMethod = DicomRetrieveMode.CMove)
            Me._radioButtonCGet.Checked = (_mySettings.DicomImageRetrieveMethod = DicomRetrieveMode.CGet)

            UpdateComboBoxService()
            EnableItems(True)
            CreateCFindObject()

            _propertyGrid.SelectedObject = _findQuery

            Me._find._mainForm = Me
        End Sub

        Private Sub _listViewSeries_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles _listViewSeries.SelectedIndexChanged
            EnableItems(True)
        End Sub
    End Class

    <Serializable()>
    Public Class MyServer
        Public _sAE As String
        Public _sIP As String
        Public _port As Integer
        Public _timeout As Integer
        Public _useTls As Boolean

        Public Sub New()
            _sAE = String.Empty
            _sIP = String.Empty
            _port = 0
            _timeout = 0
            _useTls = False
        End Sub

        Public Sub New(ByVal sAE As String, ByVal sIP As String, ByVal port As Integer, ByVal timeout As Integer, ByVal useTls As Boolean)
            _sAE = sAE
            _sIP = sIP
            _port = port
            _timeout = timeout
            _useTls = useTls
        End Sub
    End Class

    Public Class MySeries
        Public Sub New(ByVal series As Series)
            _series = series
            _additionalPresentationContexts = New List(Of PresentationContext)()
            _isDirtyPresentationContextList = False
        End Sub

        Public ReadOnly Property Series() As Series
            Get
                Return _series
            End Get
        End Property

        Public Shared Function CreatePresentationContext(ByVal uidType As String) As PresentationContext
            Dim pc As New PresentationContext(uidType)
            pc.TransferSyntaxes.Add(DicomUidType.ImplicitVRLittleEndian)
            pc.TransferSyntaxes.Add(DicomUidType.ExplicitVRLittleEndian)
            pc.TransferSyntaxes.Add(DicomUidType.JPEGBaseline1)
            pc.TransferSyntaxes.Add(DicomUidType.JPEGExtended2_4)
            pc.TransferSyntaxes.Add(DicomUidType.JPEGExtended3_5)
            Return pc
        End Function

        Private Sub AddPresentationContext(ByVal uidType As String)
            Dim pc As PresentationContext = CreatePresentationContext(uidType)
            _additionalPresentationContexts.Add(pc)
        End Sub

        Public Property AdditionalPresentationContexts() As List(Of PresentationContext)
            Get
                Return _additionalPresentationContexts
            End Get

            Set(ByVal value As List(Of PresentationContext))
                _additionalPresentationContexts = value
                _isDirtyPresentationContextList = True
            End Set
        End Property

        Public ReadOnly Property IsDirtyPresentationContextList() As Boolean
            Get
                Return _isDirtyPresentationContextList
            End Get
        End Property

        Public Sub SetDefaultAdditionalPresentationContexts()
            If IsDirtyPresentationContextList Then
                Return
            End If

            Select Case Series.Modality
                Case "AR" ' Autorefraction
                    AddPresentationContext(DicomUidType.AutorefractionMeasurementsStorage)

                Case "ASMT" ' Content Assessment Results
                    AddPresentationContext(DicomUidType.DicomContentMappingResource)

                Case "AU" ' Audio
                    AddPresentationContext(DicomUidType.BasicVoiceAudioWaveformStorage)
                    AddPresentationContext(DicomUidType.GeneralAudioWaveformStorage)
                    AddPresentationContext(DicomUidType.AudioSRStorageTrialRetired)

                Case "BDUS" ' Bone Densitometry (ultrasound)
                    AddPresentationContext(DicomUidType.USImageStorage)
                    AddPresentationContext(DicomUidType.USImageStorageRetired)
                    AddPresentationContext(DicomUidType.USMultiframeImageStorage)
                    AddPresentationContext(DicomUidType.USMultiframeImageStorageRetired)
                    AddPresentationContext(DicomUidType.EnhancedUSVolumeStorage)

                Case "BI" ' Biomagnetic imaging

                Case "BMD" ' Bone Densitometry (X-Ray)

                Case "CR" ' Computed Radiography
                    AddPresentationContext(DicomUidType.CRImageStorage)

                Case "CT" ' Computed Tomography
                    AddPresentationContext(DicomUidType.CTImageStorage)
                    AddPresentationContext(DicomUidType.EnhancedCTImageStorage)

                Case "CTPROTOCOL" ' CT Protocol (Performed)
                    AddPresentationContext(DicomUidType.CTImageStorage)
                    AddPresentationContext(DicomUidType.EnhancedCTImageStorage)

                Case "DG" ' Diaphanography

                Case "DOC" ' Document

                Case "DX" ' Digital Radiography
                    AddPresentationContext(DicomUidType.DXImageStoragePresentation)
                    AddPresentationContext(DicomUidType.DXImageStorageProcessing)
                    AddPresentationContext(DicomUidType.DXIntraoralImageStoragePresentation)
                    AddPresentationContext(DicomUidType.DXIntraoralImageStorageProcessing)
                    AddPresentationContext(DicomUidType.DXMammographyImageStoragePresentation)
                    AddPresentationContext(DicomUidType.DXMammographyImageStorageProcessing)

                Case "ECG" ' Electrocardiography
                    AddPresentationContext(DicomUidType.TwelveLeadECGWaveformStorage)
                    AddPresentationContext(DicomUidType.GeneralECGWaveformStorage)
                    AddPresentationContext(DicomUidType.AmbulatoryECGWaveformStorage)

                Case "EPS" ' Cardiac Electrophysiology
                    AddPresentationContext(DicomUidType.CardiacElectrophysiologyWaveformStorage)

                Case "ES" ' Endoscopy
                    AddPresentationContext(DicomUidType.VideoEndoscopicImageStorage)
                    AddPresentationContext(DicomUidType.VLEndoscopicImageStorageClass)

                Case "FID" ' Fiducials
                    AddPresentationContext(DicomUidType.SpatialFiducialsStorage)

                Case "GM" ' General Microscopy
                    AddPresentationContext(DicomUidType.VideoMicroscopicImageStorage)
                    AddPresentationContext(DicomUidType.VLMicroscopicImageStorageClass)
                    AddPresentationContext(DicomUidType.VLSlideCoordinatesMicroscopicImageStorageClass)
                    AddPresentationContext(DicomUidType.VLWholeSlideMicroscopyImageStorage)

                Case "HC" ' Hard Copy
                    AddPresentationContext(DicomUidType.HardcopyColorImageStorageClass)
                    AddPresentationContext(DicomUidType.HardcopyGrayscaleImageStorageClass)

                Case "HD" ' Hemodynamic Waveform
                    AddPresentationContext(DicomUidType.HemodynamicWaveformStorage)

                Case "IO" ' Intra-Oral Radiography
                    AddPresentationContext(DicomUidType.DXIntraoralImageStoragePresentation)
                    AddPresentationContext(DicomUidType.DXIntraoralImageStorageProcessing)

                Case "IOL" ' Intraocular Lens Data
                    AddPresentationContext(DicomUidType.IntraocularLensCalculationsStorage)
                    AddPresentationContext(DicomUidType.LensometryMeasurementsStorage)

                Case "IVOCT" ' Intravascular Optical Coherence Tomography
                    AddPresentationContext(DicomUidType.IntravascularOctImageStoragePresentation)
                    AddPresentationContext(DicomUidType.IntravascularOctImageStorageProcessing)

                Case "IVUS" ' Intravascular Ultrasound
                    AddPresentationContext(DicomUidType.USImageStorage)
                    AddPresentationContext(DicomUidType.USImageStorageRetired)
                    AddPresentationContext(DicomUidType.USMultiframeImageStorage)
                    AddPresentationContext(DicomUidType.USMultiframeImageStorageRetired)
                    AddPresentationContext(DicomUidType.EnhancedUSVolumeStorage)

                Case "KER" ' Keratometry
                    AddPresentationContext(DicomUidType.KeratometryMeasurementsStorage)

                Case "KO" ' Key Object Selection
                    AddPresentationContext(DicomUidType.KeyObjectSelectionDocument)

                Case "LEN" ' Lensometry
                    AddPresentationContext(DicomUidType.LensometryMeasurementsStorage)
                    AddPresentationContext(DicomUidType.IntraocularLensCalculationsStorage)

                Case "LS" ' Laser surface scan
                    AddPresentationContext(DicomUidType.SurfaceScanMeshStorage)
                    AddPresentationContext(DicomUidType.SurfaceScanPointCloudStorage)
                    AddPresentationContext(DicomUidType.SurfaceSegmentationStorage)

                Case "MG" ' Mammography
                    AddPresentationContext(DicomUidType.MammographyCadSR)
                    AddPresentationContext(DicomUidType.DXMammographyImageStoragePresentation)
                    AddPresentationContext(DicomUidType.DXMammographyImageStorageProcessing)

                Case "MR" ' Magnetic Resonance
                    AddPresentationContext(DicomUidType.MRImageStorage)
                    AddPresentationContext(DicomUidType.MRSpectroscopyStorage)
                    AddPresentationContext(DicomUidType.EnhancedMRColorImageStorage)
                    AddPresentationContext(DicomUidType.EnhancedMRImageStorage)
                    AddPresentationContext(DicomUidType.LegacyConvertedEnhancedMRImageStorage)

                Case "NM" ' Nuclear Medicine
                    AddPresentationContext(DicomUidType.NMImageStorageRetired)
                    AddPresentationContext(DicomUidType.NMImageStorage)

                Case "OAM" ' Ophthalmic Axial Measurements
                    AddPresentationContext(DicomUidType.OphthalmicAxialMeasurementsStorage)

                Case "OCT" ' Optical Coherence Tomography (non-Ophthalmic)
                    AddPresentationContext(DicomUidType.OphthalmicTomographyImageStorage)

                Case "OP" ' Ophthalmic Photography
                    AddPresentationContext(DicomUidType.Ophthalmic16BitPhotographyImageStorage)
                    AddPresentationContext(DicomUidType.Ophthalmic8BitPhotographyImageStorage)
                    AddPresentationContext(DicomUidType.WideFieldOphthalmicPhotography3dCoordinatesImageStorage)
                    AddPresentationContext(DicomUidType.WideFieldOphthalmicPhotographyStereographicProjectionImageStorage)

                Case "OPM" ' Ophthalmic Mapping
                    AddPresentationContext(DicomUidType.OphthalmicThicknessMapStorage)

                Case "OPT" ' Ophthalmic Tomography
                    AddPresentationContext(DicomUidType.OphthalmicTomographyImageStorage)

                Case "OPV" ' Ophthalmic Visual Field
                    AddPresentationContext(DicomUidType.OphthalmicVisualFieldStaticPerimetryMeasurementsStorage)

                Case "OSS" ' Optical Surface Scan
                    AddPresentationContext(DicomUidType.SurfaceScanMeshStorage)
                    AddPresentationContext(DicomUidType.SurfaceScanPointCloudStorage)

                Case "OT" ' Other
                    AddPresentationContext(DicomUidType.SCImageStorage)
                    AddPresentationContext(DicomUidType.SCMultiFrameGrayscaleByteImageStorage)
                    AddPresentationContext(DicomUidType.SCMultiFrameGrayscaleWordImageStorage)
                    AddPresentationContext(DicomUidType.SCMultiFrameSingleBitImageStorage)
                    AddPresentationContext(DicomUidType.SCMultiFrameTrueColorImageStorage)
                    AddPresentationContext(DicomUidType.CRImageStorage)

                Case "PLAN" ' Plan
                    AddPresentationContext(DicomUidType.ImplantationPlanSRDocumentStorage)
                    AddPresentationContext(DicomUidType.RTIonPlanStorage)
                    AddPresentationContext(DicomUidType.RTPlanStorage)

                Case "PR" ' Presentation State
                    AddPresentationContext(DicomUidType.BasicStructuredDisplayStorage)
                    AddPresentationContext(DicomUidType.BlendingSoftcopyPresentationStateStorage)
                    AddPresentationContext(DicomUidType.ColorSoftcopyPresentationStateStorage)
                    AddPresentationContext(DicomUidType.GrayscaleSoftcopyPresentationStateStorage)
                    AddPresentationContext(DicomUidType.PseudoColorSoftcopyPresentationStateStorage)
                    AddPresentationContext(DicomUidType.XAXrfGrayscaleSoftcopyPresentationStateStorage)

                Case "PT" ' Positron emission tomography (PET)
                    AddPresentationContext(DicomUidType.PETImageStorage)
                    AddPresentationContext(DicomUidType.EnhancedPETImageStorage)
                    AddPresentationContext(DicomUidType.LegacyConvertedEnhancedPETImageStorage)

                Case "PX" ' Panoramic X-Ray
                    AddPresentationContext(DicomUidType.DXIntraoralImageStoragePresentation)
                    AddPresentationContext(DicomUidType.DXIntraoralImageStorageProcessing)
                    AddPresentationContext(DicomUidType.DXImageStoragePresentation)
                    AddPresentationContext(DicomUidType.DXImageStorageProcessing)

                Case "REG" ' Registration
                    AddPresentationContext(DicomUidType.DeformableSpatialRegistrationStorage)
                    AddPresentationContext(DicomUidType.SpatialRegistrationStorage)

                Case "RESP" ' Respiratory Waveform
                    AddPresentationContext(DicomUidType.RespiratoryWaveformStorage)

                Case "RF" ' Radio Fluoroscopy
                    AddPresentationContext(DicomUidType.XRayRadiofluoroscopicImageStorage)

                Case "RG" ' Radiographic imaging (conventional film/screen)

                Case "RTDOSE" ' Radiotherapy Dose
                    AddPresentationContext(DicomUidType.RTDoseStorage)

                Case "RTIMAGE" ' Radiotherapy Image
                    AddPresentationContext(DicomUidType.RTImageStorage)

                Case "RTPLAN" ' Radiotherapy Plan
                    AddPresentationContext(DicomUidType.RTPlanStorage)

                Case "RTRECORD" ' RT Treatment Record
                    AddPresentationContext(DicomUidType.RTTreatmentSummaryRecordStorageClass)

                Case "RTSTRUCT" ' Radiotherapy Structure Set
                    AddPresentationContext(DicomUidType.RTStructureStorage)

                Case "RWV" ' Real World Value Map
                    AddPresentationContext(DicomUidType.RealWorldValueMappingStorage)

                Case "SEG" ' Segmentation
                    AddPresentationContext(DicomUidType.SegmentationStorage)
                    AddPresentationContext(DicomUidType.SurfaceSegmentationStorage)

                Case "SM" ' Slide Microscopy
                    AddPresentationContext(DicomUidType.VLWholeSlideMicroscopyImageStorage)
                    AddPresentationContext(DicomUidType.VLSlideCoordinatesMicroscopicImageStorageClass)

                Case "SMR" ' Stereometric Relationship
                    AddPresentationContext(DicomUidType.StereometricRelationshipStorage)

                Case "SR" ' SR Document
                    AddPresentationContext(DicomUidType.ImplantationPlanSRDocumentStorage)
                    AddPresentationContext(DicomUidType.BasicTextSR)
                    AddPresentationContext(DicomUidType.ChestCadSR)
                    AddPresentationContext(DicomUidType.ColonCadSRStorage)
                    AddPresentationContext(DicomUidType.Comprehensive3dSRStorage)

                Case "SRF" ' Subjective Refraction
                    AddPresentationContext(DicomUidType.SubjectiveRefractionMeasurementsStorage)

                Case "STAIN" ' Automated Slide Stainer
                    AddPresentationContext(DicomUidType.VLWholeSlideMicroscopyImageStorage)
                    AddPresentationContext(DicomUidType.VLSlideCoordinatesMicroscopicImageStorageClass)

                Case "TG" ' Thermography

                Case "US" ' Ultrasound
                    AddPresentationContext(DicomUidType.USImageStorage)
                    AddPresentationContext(DicomUidType.USImageStorageRetired)
                    AddPresentationContext(DicomUidType.USMultiframeImageStorage)
                    AddPresentationContext(DicomUidType.USMultiframeImageStorageRetired)
                    AddPresentationContext(DicomUidType.EnhancedUSVolumeStorage)

                Case "VA" ' Visual Acuity
                    AddPresentationContext(DicomUidType.VisualAcuityMeasurementsStorage)

                Case "XA" ' X-Ray Angiography
                    AddPresentationContext(DicomUidType.XRay3dAngiographicImageStorage)
                    AddPresentationContext(DicomUidType.XRay3dCraniofacialImageStorage)
                    AddPresentationContext(DicomUidType.XRayRadiationDoseSRStorage)
                    AddPresentationContext(DicomUidType.XRayRadiofluoroscopicImageStorage)
                    AddPresentationContext(DicomUidType.XAImageStorage)

                Case "XC" ' External-camera Photography
                    AddPresentationContext(DicomUidType.VideoPhotographicImageStorage)
                    AddPresentationContext(DicomUidType.VLPhotographicImageStorageClass)

               ' Retired Defined Terms:
                Case "AS" ' Angioscopy
                    AddPresentationContext(DicomUidType.XRay3dAngiographicImageStorage)

                Case "CD" ' Color flow Doppler

                Case "CF" ' Cinefluorography

                Case "CP" ' Culposcopy

                Case "CS" ' Cystoscopy

                Case "DD" ' Duplex Doppler

                Case "DF" ' Digital fluoroscopy

                Case "DM" ' Digital microscopy
                    AddPresentationContext(DicomUidType.VideoMicroscopicImageStorage)
                    AddPresentationContext(DicomUidType.VLMicroscopicImageStorageClass)
                    AddPresentationContext(DicomUidType.VLSlideCoordinatesMicroscopicImageStorageClass)
                    AddPresentationContext(DicomUidType.VLWholeSlideMicroscopyImageStorage)

                Case "DS" ' Digital Subtraction Angiography
                    AddPresentationContext(DicomUidType.XRay3dAngiographicImageStorage)
                    AddPresentationContext(DicomUidType.XAImageStorage)

                Case "EC" ' Echocardiography
                    AddPresentationContext(DicomUidType.CardiacElectrophysiologyWaveformStorage)

                Case "FA" ' Fluorescein angiography
                    AddPresentationContext(DicomUidType.XRay3dAngiographicImageStorage)
                    AddPresentationContext(DicomUidType.XAImageStorage)

                Case "FS" ' Fundoscopy

                Case "LP" ' Laparoscopy

                Case "MA" ' Magnetic resonance angiography
                    AddPresentationContext(DicomUidType.MRImageStorage)
                    AddPresentationContext(DicomUidType.MRSpectroscopyStorage)
                    AddPresentationContext(DicomUidType.EnhancedMRColorImageStorage)
                    AddPresentationContext(DicomUidType.EnhancedMRImageStorage)

                Case "MS" ' Magnetic resonance spectroscopy
                    AddPresentationContext(DicomUidType.MRImageStorage)
                    AddPresentationContext(DicomUidType.MRSpectroscopyStorage)
                    AddPresentationContext(DicomUidType.EnhancedMRColorImageStorage)
                    AddPresentationContext(DicomUidType.EnhancedMRImageStorage)

                Case "OPR" ' Ophthalmic Refraction
                    AddPresentationContext(DicomUidType.OphthalmicTomographyImageStorage)
                    AddPresentationContext(DicomUidType.SubjectiveRefractionMeasurementsStorage)

                Case "ST" ' Single-photon emission computed tomography (SPECT)
                    AddPresentationContext(DicomUidType.CTImageStorage)

                Case "VF" ' Videofluorography
                    AddPresentationContext(DicomUidType.VideoEndoscopicImageStorage)
                    AddPresentationContext(DicomUidType.VideoMicroscopicImageStorage)
                    AddPresentationContext(DicomUidType.VideoPhotographicImageStorage)
            End Select
            _isDirtyPresentationContextList = True
        End Sub

        Private _isDirtyPresentationContextList As Boolean
        Private ReadOnly _series As Series
        Private _additionalPresentationContexts As List(Of PresentationContext)
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
