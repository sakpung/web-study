' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Option Infer On

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Management
Imports System.Xml.Serialization
Imports System.IO
Imports System.Security.Permissions
Imports System.Net
Imports System.Linq

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Dicom
Imports Leadtools.Dicom.Scu
Imports Leadtools.Dicom.Scu.Common
Imports Leadtools.DicomDemos
Imports System.Diagnostics
Imports Leadtools.Dicom.Scu.Queries
Imports DicomDemo.Queries
Imports Leadtools.Dicom.Common.DataTypes
Imports Leadtools.Dicom.Common.DataTypes.Modality
Imports Leadtools.Dicom.Common.Extensions
Imports Leadtools.Dicom.Common.Editing
Imports Leadtools.WinForms.CommonDialogs.File
Imports Leadtools.ImageProcessing
Imports System.Reflection
Imports System.Data

Namespace DicomDemo
   Partial Public Class MainForm : Inherits Form
      Private Const _sNewline As String = Constants.vbCrLf
      Private Const _sNewlineTab As String = Constants.vbCrLf & Constants.vbTab
      Private Const _sNewlineTabTab As String = Constants.vbCrLf & Constants.vbTab + Constants.vbTab
      Private Const _sConfigurationImplementationClass As String = "1.2.840.114257.1123456"
      Private Const _sConfigurationImplementationVersionName As String = "1"
      Private Const _sConfigurationProtocolversion As String = "1"

      Private _find As QueryRetrieveScu
      Private _MwlFind As DicomDataSet = Nothing
      Private _store As StoreScu
      Private _canCancel As Boolean = False
      Private _findQuery As FindQuery = New FindQuery()
      Private _studyRoot As StudyRootQueryStudy = New StudyRootQueryStudy()
      Private _tracer As TextBoxTraceListener = Nothing
      Private patientQuery As ToolStripButton
      Private _query As ModalityWorklistQuery = New ModalityWorklistQuery()
      Private _pbQuery As PatientBasedQuery = New PatientBasedQuery()
      Private _bbQuery As BroadBasedQuery = New BroadBasedQuery()
      Private _modalityPPS As MyPerformedProcedureStepScu = Nothing
      Private _AllowedSet As List(Of Long) = New List(Of Long)()
      Private _CancelStore As Boolean = False
      Private _saveFiledlg As SaveFileDialog
      ' 
      Public _mwlServer As Scp = New Scp()
      Public _mppsServer As Scp = New Scp()
      Public _storageServer As Scp = New Scp()

      ' Settings
      Public _mySettings As DicomDemoSettings = New DicomDemoSettings()
      Public _demoName As String = Path.GetFileName(Application.ExecutablePath)

      ' Logging
      Public Delegate Sub AddLog(ByVal action As String, ByVal logText As String, ByVal sActionColor As Color)

      Private Const sHelpInstructions As String = "Command Line Options:" & _sNewlineTab & "/? or /help" & Constants.vbTab + Constants.vbTab & "Displays this help" & _sNewlineTab & "/configure" & Constants.vbTab + Constants.vbTab & "Configures the client (use one or more options below)" & _sNewlineTab & "/server_aetitle={aetitle}" & Constants.vbTab & "Server AE title" & _sNewlineTab & "/server_ip={ip address}" & Constants.vbTab & "Server IP" & _sNewlineTab & "/server_port={port}" & Constants.vbTab & "Server Port" & _sNewlineTab & "/client_aetitle={aetitle}" & Constants.vbTab & "Client AE title" & _sNewlineTab & "/client_port={port}" & Constants.vbTab + Constants.vbTab & "Client Port" & _sNewlineTab & "/defaults" & Constants.vbTab + Constants.vbTab + Constants.vbTab & "Sets defaults for other options"

      ' Help
      Private _firstTime As Boolean = True

      <Serializable()>
      Public Class ProcedureStep
         Private _Mpps As MPPSNCreate

         Public Property Mpps() As MPPSNCreate
            Get
               Return _Mpps
            End Get
            Set(ByVal value As MPPSNCreate)
               _Mpps = value
            End Set
         End Property

         Private _Result As ModalityWorklistResult

         Public Property Result() As ModalityWorklistResult
            Get
               Return _Result
            End Get
            Set(ByVal value As ModalityWorklistResult)
               _Result = value
            End Set
         End Property

         Public Sub New()
         End Sub

         Public Sub New(ByVal mpps_Renamed As MPPSNCreate, ByVal result_Renamed As ModalityWorklistResult)
            _Mpps = mpps_Renamed
            _Result = result_Renamed
         End Sub
      End Class


      Public Class Program
         ''' <summary>
         ''' The main entry point for the application.
         ''' </summary>
         Private Sub New()
         End Sub
         <STAThread()>
         Shared Sub Main(ByVal args As String())
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
#End If ' #if LEADTOOLS_V175_OR_LATER

#If (LEADTOOLS_V20_OR_LATER) Then
                If DemosGlobal.IsDotNet45OrLaterInstalled() = False Then
                    MessageBox.Show("To run this application, you must first install Microsoft .NET Framework 4.5 or later.", "Microsoft .NET Framework 4.5 or later Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
#End If

                Utils.EngineStartup()
                Utils.DicomNetStartup()

                Application.EnableVisualStyles()
                Application.SetCompatibleTextRenderingDefault(False)
                Application.Run(New MainForm())
            End Sub
        End Class

        Private Shared Function GetDefaultIp() As String
            Dim query As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'")
            Dim queryCollection As ManagementObjectCollection = query.Get()

            For Each mo As ManagementObject In queryCollection
                If queryCollection.Count > 0 Then
                    Dim addresses As String() = CType(mo("IPAddress"), String())

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

        Private Shared Function ReadCommandLine(ByVal args As String()) As Boolean
            Return False
        End Function
        Private Function LoadImage() As List(Of RasterImage)
            Dim images As List(Of RasterImage) = New List(Of RasterImage)
            Dim codecs As RasterCodecs = Nothing
            Dim loader As ImageFileLoader = Nothing

            Try
                loader = New ImageFileLoader()
                codecs = New RasterCodecs()
                loader.MultiSelect = True
                loader.ShowLoadPagesDialog = True
                loader.Images.Clear()
                Dim filesCount As Integer = loader.Load(Me, codecs, True)
                If filesCount > 0 Then
                    Dim fileNum As Integer
                    For fileNum = 0 To filesCount - 1 Step fileNum + 1
                        Dim img As RasterImage = loader.Images(fileNum).Image
                        Dim pageNum As Integer
                        For pageNum = 1 To img.PageCount Step pageNum + 1
                            img.Page = pageNum
                            images.Add(img.Clone())
                        Next
                        img.Dispose()
                    Next
                End If
            Catch ex As Exception
                Messager.ShowFileOpenError(Me, loader.FileName, ex)
            End Try

            If Not codecs Is Nothing Then
                codecs.Dispose()
            End If

            Return images
        End Function


        Public Sub New()
            InitializeComponent()
            If (Not DicomDemoSettingsManager.Is64Process()) Then
                Text = Text & " (32 bit)"
            Else
                Text = Text & "(64 bit)"
            End If
            InitializeAllowList()

            _saveFiledlg = New SaveFileDialog()
            _saveFiledlg.Filter = "Dicom Files (*.dcm)|*.dcm"
            _saveFiledlg.DefaultExt = "dcm"

        End Sub

        Private Sub InitializeAllowList()
            _AllowedSet.Add(DicomTag.ServiceEpisodeID)
            _AllowedSet.Add(DicomTag.IssuerOfServiceEpisodeID)
            _AllowedSet.Add(DicomTag.ServiceEpisodeDescription)
            _AllowedSet.Add(DicomTag.PerformedProcedureStepDescription)
            _AllowedSet.Add(DicomTag.PerformedProcedureTypeDescription)
            _AllowedSet.Add(DicomTag.PerformedProcedureCodeSequence)
            _AllowedSet.Add(DicomTag.PerformedProcedureStepEndDate)
            _AllowedSet.Add(DicomTag.PerformedProcedureStepEndTime)
            _AllowedSet.Add(DicomTag.CommentsOnThePerformedProcedureStep)
            _AllowedSet.Add(DicomTag.PerformedProcedureStepDiscontinuationReasonCodeSequence)
            _AllowedSet.Add(DicomTag.PerformedProtocolCodeSequence)
            _AllowedSet.Add(DicomTag.PerformedSeriesSequence)
            _AllowedSet.Add(DicomTag.PerformingPhysicianName)
            _AllowedSet.Add(DicomTag.ProtocolName)
            _AllowedSet.Add(DicomTag.OperatorName)
            _AllowedSet.Add(DicomTag.SeriesInstanceUID)
            _AllowedSet.Add(DicomTag.SeriesDescription)
            _AllowedSet.Add(DicomTag.RetrieveAETitle)
            _AllowedSet.Add(DicomTag.ArchiveRequested)
        End Sub

        Private Sub SizeColumns(ByVal lv As ListView)
            For Each header As ColumnHeader In lv.Columns
                header.Width = Convert.ToInt32(lv.Width / lv.Columns.Count)
            Next header
        End Sub

        Private Sub _listViewWorkItems_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles _listViewWorkItems.Resize
            SizeColumns(_listViewWorkItems)
        End Sub

        Private Function DoOptions() As DialogResult
            Dim options As OptionsDialog = New OptionsDialog()
            options.ServerList = _mySettings.ServerList

            options.ClientAE = _mySettings.ClientAe.AE
            options.ClientCertificate = _mySettings.ClientCertificate
            options.PrivateKey = _mySettings.ClientPrivateKey
            options.PrivateKeyPassword = _mySettings.ClientPrivateKeyPassword
            options.LogLowLevel = _mySettings.LogLowLevel
            options.GroupLengthDataElements = _mySettings.GroupLengthDataElements
            options.Mwl = _mySettings.DefaultMwlQuery
            options.Mpps = _mySettings.DefaultMpps
            options.Storage = _mySettings.DefaultStore
            options.CipherSuites = _mySettings.CipherSuites
            Dim dr As DialogResult = options.ShowDialog(Me)
            If dr = System.Windows.Forms.DialogResult.OK Then
                _mySettings.ServerList = options.ServerList
                _mySettings.ClientAe.AE = options.ClientAE
                _mySettings.ClientCertificate = options.ClientCertificate
                _mySettings.ClientPrivateKey = options.PrivateKey
                _mySettings.ClientPrivateKeyPassword = options.PrivateKeyPassword
                _mySettings.LogLowLevel = options.LogLowLevel
                _mySettings.GroupLengthDataElements = options.GroupLengthDataElements
                _mySettings.DefaultMwlQuery = options.Mwl
                _mySettings.DefaultMpps = options.Mpps
                _mySettings.DefaultStore = options.Storage
                _mySettings.CipherSuites = options.CipherSuites

                UpdateComboBoxServices()
                DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)
            End If
            Return dr
        End Function

        Private Const defaultServerAE As String = "LEAD_SERVER"
        Private Const defaultServerIP As String = "127.0.0.1"
        Private Const defaultServerPort As Integer = 104
        Private Const defaultServerTimeout As Integer = 30
        Private Const defaultServerUseTls As Boolean = False
        Private Const defaultCompression As Integer = 2

        Private Const defaultClientAE As String = "LEAD_CLIENT"
        Private Const defaultClientPort As Integer = 1000

        Private Sub SetOtherDefaults(ByVal settings As DicomDemoSettings)
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

        Private Function DefaultSettings() As DicomDemoSettings
            Dim settings As DicomDemoSettings = New DicomDemoSettings()
            settings.ClientAe.AE = defaultClientAE
            settings.ClientAe.Port = defaultServerPort
            Dim serverAE As DicomAE = New DicomAE()
            serverAE.AE = defaultServerAE
            serverAE.IPAddress = defaultServerIP
            serverAE.Port = defaultServerPort
            serverAE.Timeout = defaultServerTimeout
            serverAE.UseTls = defaultServerUseTls
            settings.ServerList.Add(serverAE)

            settings.DefaultMwlQuery = serverAE.AE
            settings.DefaultMpps = serverAE.AE
            settings.DefaultStore = serverAE.AE
            SetOtherDefaults(settings)
            Return settings
        End Function

        Private Sub SetDefaultServer(ByVal scp As Scp, ByVal serverAe As String)
            Dim defaultAE As DicomAE = _mySettings.GetServer(serverAe)

            If Not Nothing Is defaultAE Then
                scp.AETitle = defaultAE.AE
                scp.Port = CInt(defaultAE.Port)
                scp.PeerAddress = IPAddress.Parse(defaultAE.IPAddress)
                scp.Timeout = defaultAE.Timeout
            End If
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
                    End If
                End If

                SetDefaultServer(_storageServer, _mySettings.DefaultStore)
                SetDefaultServer(_mwlServer, _mySettings.DefaultMwlQuery)
                SetDefaultServer(_mppsServer, _mySettings.DefaultMpps)
                patientQuery.Checked = Not _mySettings.BroadQuery
                _mySettings.FirstRun = False
                DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)
            Catch ex As Exception
                System.Diagnostics.Debug.Assert(False, ex.Message)
            End Try
        End Sub

        Private Function GetDefaultUseTls(ByVal ae As String) As Boolean
            Dim useTls As Boolean = False
            Dim defaultAE As DicomAE = _mySettings.GetServer(ae)
            If Not defaultAE Is Nothing Then
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
            If Not _find Is Nothing Then
                _find.Dispose()
            End If

            Dim useTls As Boolean = GetDefaultUseTls(_mySettings.DefaultMwlQuery)
            If useTls Then
#If Not LEADTOOLS_V20_OR_LATER Then
            _find = New QueryRetrieveScu(String.Empty, DicomNetSecurityeMode.Tls, Nothing)
#Else
                _find = New QueryRetrieveScu(String.Empty, DicomNetSecurityMode.Tls, Nothing)
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then
            Else
                _find = New QueryRetrieveScu()
            End If

            _find.MaxLength = 46726
            _find.ImplementationClass = _sConfigurationImplementationClass
            _find.ProtocolVersion = _sConfigurationProtocolversion
            _find.ImplementationVersionName = _sConfigurationImplementationVersionName
            _find.AETitle = _mySettings.ClientAe.AE

#If LEADTOOLS_V19_OR_LATER Then
            _find.Flags = DicomNetFlags.None
            If _mySettings.GroupLengthDataElements Then
                _find.Flags = _find.Flags Or DicomNetFlags.SendDataWithGroupLengthStandardDataElements
            End If
#End If

            AddHandler _find.BeforeConnect, New Leadtools.Dicom.Scu.Common.BeforeConnectDelegate(AddressOf BeforeConnect)
            AddHandler _find.AfterConnect, New Leadtools.Dicom.Scu.Common.AfterConnectDelegate(AddressOf AfterConnect)
            AddHandler _find.BeforeAssociateRequest, New Leadtools.Dicom.Scu.Common.BeforeAssociationRequestDelegate(AddressOf BeforeAssociateRequest)
            AddHandler _find.AfterAssociateRequest, New Leadtools.Dicom.Scu.Common.AfterAssociateRequestDelegate(AddressOf AfterAssociateRequest)
            AddHandler _find.BeforeCFind, New Leadtools.Dicom.Scu.Common.BeforeCFindDelegate(AddressOf _find_BeforeCFind)
            AddHandler _find.AfterCFind, New Leadtools.Dicom.Scu.Common.AfterCFindDelegate(AddressOf _find_AfterCFind)

            AddHandler _find.AfterSecureLinkReady, New AfterSecureLinkReadyDelegate(AddressOf AfterSecureLinkReady)
            AddHandler _find.PrivateKeyPassword, New PrivateKeyPasswordDelegate(AddressOf PrivateKeyPassword)

            If useTls Then
                Try
                    SetCipherSuites(_find)
                    If _mySettings.ClientPrivateKey.Length > 0 Then
                        _find.SetTlsClientCertificate(_mySettings.ClientCertificate, DicomTlsCertificateType.Pem, _mySettings.ClientPrivateKey)
                    Else
                        _find.SetTlsClientCertificate(_mySettings.ClientCertificate, DicomTlsCertificateType.Pem, Nothing)
                    End If
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
                If Not _tracer Is Nothing Then
                    Trace.Listeners.Remove(_tracer)
                    _tracer = Nothing
                End If
            End If
            _find.DebugLogFilename = String.Empty
            _find.EnableDebugLog = True
            SetDefaultServer(Me._mwlServer, _mySettings.DefaultMwlQuery)
            SetLabelInfo(toolStripStatusLabelMWL, toolStripComboBoxMWLScp.ComboBox)
        End Sub

        Private Sub CreateModalityPPSObject()
            If Not _modalityPPS Is Nothing Then
                _modalityPPS.Dispose()
            End If

            Dim useTls As Boolean = GetDefaultUseTls(_mySettings.DefaultMpps)
            If useTls Then
#If Not LEADTOOLS_V20_OR_LATER Then
            _modalityPPS = New MyPerformedProcedureStepScu(Me, String.Empty, DicomNetSecurityeMode.Tls, Nothing)
#Else
                _modalityPPS = New MyPerformedProcedureStepScu(Me, String.Empty, DicomNetSecurityMode.Tls, Nothing)
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then
            Else
                _modalityPPS = New MyPerformedProcedureStepScu(Me)
            End If

            _modalityPPS.ImplementationClass = _sConfigurationImplementationClass
            _modalityPPS.ProtocolVersion = _sConfigurationProtocolversion
            _modalityPPS.ImplementationVersionName = _sConfigurationImplementationVersionName
            _modalityPPS.AETitle = _mySettings.ClientAe.AE

            AddHandler _modalityPPS.BeforeConnect, New BeforeConnectDelegate(AddressOf BeforeConnect)
            AddHandler _modalityPPS.AfterConnect, New AfterConnectDelegate(AddressOf AfterConnect)
            AddHandler _modalityPPS.BeforeAssociateRequest, New BeforeAssociationRequestDelegate(AddressOf BeforeAssociateRequest)
            AddHandler _modalityPPS.AfterAssociateRequest, New AfterAssociateRequestDelegate(AddressOf AfterAssociateRequest)
            AddHandler _modalityPPS.AfterSecureLinkReady, New AfterSecureLinkReadyDelegate(AddressOf AfterSecureLinkReady)
            AddHandler _modalityPPS.PrivateKeyPassword, New PrivateKeyPasswordDelegate(AddressOf PrivateKeyPassword)

            AddHandler _modalityPPS.AfterNCreate, AddressOf _modalityPPS_AfterNCreate
            AddHandler _modalityPPS.AfterNSet, AddressOf _modalityPPS_AfterNSet

            If useTls Then
                Try
                    SetCipherSuites(_modalityPPS)
                    If _mySettings.ClientPrivateKey.Length > 0 Then
                        _modalityPPS.SetTlsClientCertificate(_mySettings.ClientCertificate, DicomTlsCertificateType.Pem, _mySettings.ClientPrivateKey)
                    Else
                        _modalityPPS.SetTlsClientCertificate(_mySettings.ClientCertificate, DicomTlsCertificateType.Pem, Nothing)
                    End If
                Catch ex As Exception
                    LogError(ex.Message)
                End Try
            End If

            _modalityPPS.DebugLogFilename = String.Empty
            _modalityPPS.EnableDebugLog = True
            SetDefaultServer(Me._mppsServer, _mySettings.DefaultMpps)
            SetLabelInfo(toolStripStatusLabelMPPS, toolStripComboBoxMPPSScp.ComboBox)
        End Sub

        Private Sub _modalityPPS_AfterNSet(ByVal sender As Object, ByVal e As StatusCommonEventArgs)
            If _mySettings.LogLowLevel Then
                Dim sMsg As String = _sNewlineTab & "presentationID:" & Constants.vbTab + e.PresentationID.ToString() & _sNewlineTab & "messageID:" & Constants.vbTab + e.MessageID.ToString() & _sNewlineTab & "affectedClass:" & Constants.vbTab + e.AffectedClass & _sNewlineTab & "instance:" & Constants.vbTab + e.Instance & _sNewlineTab & "status:" & Constants.vbTab + e.Status.ToString()

                LogText("AfterNSet", sMsg, System.Drawing.Color.Green)
            End If
        End Sub

        Private Sub _modalityPPS_AfterNCreate(ByVal sender As Object, ByVal e As StatusCommonEventArgs)
            If _mySettings.LogLowLevel Then
                Dim sMsg As String = _sNewlineTab & "presentationID:" & Constants.vbTab + e.PresentationID.ToString() & _sNewlineTab & "messageID:" & Constants.vbTab + e.MessageID.ToString() & _sNewlineTab & "affectedClass:" & Constants.vbTab + e.AffectedClass & _sNewlineTab & "instance:" & Constants.vbTab + e.Instance & _sNewlineTab & "status:" & Constants.vbTab + e.Status.ToString()

                LogText("AfterNCreate", sMsg, System.Drawing.Color.Green)
            End If
        End Sub


        Private Sub CreateCStoreObject()
            If Not _store Is Nothing Then
                _store.Dispose()
            End If
            Dim useTls As Boolean = GetDefaultUseTls(_mySettings.DefaultStore)
            If useTls Then
#If Not LEADTOOLS_V20_OR_LATER Then
            _store = New StoreScu(String.Empty, DicomNetSecurityeMode.Tls, Nothing)
#Else
                _store = New StoreScu(String.Empty, DicomNetSecurityMode.Tls, Nothing)
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then
            Else
                _store = New StoreScu()
            End If

            _store.MaxLength = 46726
            _store.ImplementationClass = _sConfigurationImplementationClass
            _store.ImplementationVersionName = _sConfigurationImplementationVersionName
            _store.ProtocolVersion = _sConfigurationProtocolversion
            _store.AETitle = _mySettings.ClientAe.AE

            AddHandler _store.BeforeConnect, New BeforeConnectDelegate(AddressOf BeforeConnect)
            AddHandler _store.AfterConnect, New AfterConnectDelegate(AddressOf AfterConnect)
            AddHandler _store.BeforeAssociateRequest, New BeforeAssociationRequestDelegate(AddressOf BeforeAssociateRequest)
            AddHandler _store.AfterAssociateRequest, New AfterAssociateRequestDelegate(AddressOf AfterAssociateRequest)
            AddHandler _store.AfterSecureLinkReady, New AfterSecureLinkReadyDelegate(AddressOf AfterSecureLinkReady)
            AddHandler _store.PrivateKeyPassword, New PrivateKeyPasswordDelegate(AddressOf PrivateKeyPassword)

            AddHandler _store.BeforeCStore, New BeforeCStoreDelegate(AddressOf _store_BeforeCStore)
            AddHandler _store.AfterCStore, New AfterCStoreDelegate(AddressOf _store_AfterCStore)

            If useTls Then
                Try
                    SetCipherSuites(_store)
                    If _mySettings.ClientPrivateKey.Length > 0 Then
                        _store.SetTlsClientCertificate(_mySettings.ClientCertificate, DicomTlsCertificateType.Pem, _mySettings.ClientPrivateKey)
                    Else
                        _store.SetTlsClientCertificate(_mySettings.ClientCertificate, DicomTlsCertificateType.Pem, Nothing)
                    End If
                Catch ex As Exception
                    LogError(ex.Message)
                End Try
            End If

            _store.DebugLogFilename = String.Empty
            _store.EnableDebugLog = True
            SetDefaultServer(Me._storageServer, _mySettings.DefaultStore)
            SetLabelInfo(toolStripStatusLabelStore, toolStripComboBoxStoreScp.ComboBox)
        End Sub

        Private Sub _store_AfterCStore(ByVal sender As Object, ByVal e As AfterCStoreEventArgs)
            Dim message As String

            If e.Status = DicomCommandStatusType.Success Then
                message = _sNewlineTab & "Success"
                If Not e.FileInfo Is Nothing Then
                    message &= _sNewlineTab & "Filename: " & e.FileInfo.FullName
                End If
            Else
                message = _sNewlineTab & "CStore Failed" & _sNewlineTab & "Status: " & e.Status.ToString()
            End If
            LogText("After CStore", message)
        End Sub

        Private Sub _store_BeforeCStore(ByVal sender As Object, ByVal e As BeforeCStoreEventArgs)
            Dim fileinfo As String = String.Empty

            If Not e.FileInfo Is Nothing Then
                fileinfo = _sNewlineTab & "Filename: " & e.FileInfo.FullName
            End If
            LogText("Before CStore", fileinfo)
        End Sub

        Private Sub AfterSecureLinkReady(ByVal sender As Object, ByVal e As AfterSecureLinkReadyEventArgs)
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

        Private Sub PrivateKeyPassword(ByVal sender As Object, ByVal e As PrivateKeyPasswordEventArgs)
            e.PrivateKeyPassword = _mySettings.ClientPrivateKeyPassword
        End Sub

        Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            AddHandler Application.ApplicationExit, AddressOf Application_ApplicationExit

            StatusText(String.Empty)
            SizeColumns(_listViewWorkItems)
            AddPropertyGridButtons()
            LoadSettings()
            UpdateComboBoxServices()
            EnableItems(True)
            CreateCFindObject()
            CreateModalityPPSObject()
            CreateCStoreObject()

            patientQuery_CheckedChanged(Nothing, EventArgs.Empty)
            LoadProcedureStep()
        End Sub

        Private Sub AddPropertyGridButtons()
            Dim toolStrip As ToolStrip = Nothing

            For Each control As Control In _propertyGrid.Controls
                If TypeOf control Is ToolStrip Then
                    toolStrip = TryCast(control, ToolStrip)
                    Exit For
                End If
            Next control

            If Not toolStrip Is Nothing Then
                toolStrip.Items.Add(New ToolStripSeparator())
                patientQuery = New ToolStripButton("Patient", Resources.Patient)
                patientQuery.DisplayStyle = ToolStripItemDisplayStyle.Image
                patientQuery.CheckOnClick = True
                AddHandler patientQuery.CheckedChanged, AddressOf patientQuery_CheckedChanged
                toolStrip.Items.Add(patientQuery)
            End If
        End Sub

        Private Sub patientQuery_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If patientQuery.Checked Then
                _propertyGrid.SelectedObject = _pbQuery
            Else
                _propertyGrid.SelectedObject = _bbQuery
            End If

            '
            ' Save Query Option
            '
            _mySettings.BroadQuery = Not patientQuery.Checked
            DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)
        End Sub

        Private Sub Application_ApplicationExit(ByVal sender As Object, ByVal e As EventArgs)
            Utils.EngineShutdown()
            Utils.DicomNetShutdown()
        End Sub

        Private Sub AddAction(ByVal sAction As String)
            AddAction(sAction, Color.Blue)
        End Sub

        Private Sub AddAction(ByVal sAction As String, ByVal color As Color)
            Dim oldColor As System.Drawing.Color = _richTextBoxLog.SelectionColor

            _richTextBoxLog.SelectionLength = 0
            _richTextBoxLog.SelectionStart = _richTextBoxLog.Text.Length
            _richTextBoxLog.SelectionColor = color
            _richTextBoxLog.SelectionFont = New Font(_richTextBoxLog.SelectionFont, FontStyle.Bold)
            _richTextBoxLog.AppendText(sAction & ": ")
            _richTextBoxLog.SelectionColor = oldColor
        End Sub

        Public Sub LogText(ByVal sAction As String, ByVal sLogText As String, ByVal sActionColor As Color)
            If Me.InvokeRequired Then
                Me.Invoke(New AddLog(AddressOf LogText), New Object() {sAction, sLogText, sActionColor})
            Else
                AddAction(sAction, sActionColor)
                _richTextBoxLog.AppendText(sLogText)
                _richTextBoxLog.AppendText(_sNewline)
                TextBoxTraceListener.SendMessage(_richTextBoxLog.Handle, TextBoxTraceListener.WM_VSCROLL, TextBoxTraceListener.SB_BOTTOM, 0)
            End If
        End Sub

        Public Sub LogText(ByVal sAction As String, ByVal sLogText As String)
            LogText(sAction, sLogText, Color.Blue)
        End Sub

        Public Sub LogError(ByVal sLogText As String)
            LogText("*** ERROR *** ", _sNewlineTab & sLogText, Color.Red)
        End Sub


        Private Sub BeforeConnect(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.BeforeConnectEventArgs)
            LogText("Before Connect", e.Scp.ToString())

        End Sub
        Private Sub AfterConnect(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.AfterConnectEventArgs)
            Dim message As String
            If e.Error = DicomExceptionCode.Success Then
                message = _sNewlineTab & "Connection Successful"
            Else
                message = _sNewlineTab & "Connection failed" & _sNewlineTab & "Error:" & Constants.vbTab + e.Error.ToString()
            End If

            LogText("After Connect", message)
        End Sub

        Private Sub BeforeAssociateRequest(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.BeforeAssociateRequestEventArgs)
            LogText("Before Associate Request", e.Associate.ToString())
        End Sub

        Private Sub AfterAssociateRequest(ByVal sender As Object, ByVal e As Leadtools.Dicom.Scu.Common.AfterAssociateRequestEventArgs)
            Dim message As String = String.Empty

            If e.Rejected Then
                message = _sNewlineTab & "Association Rejected" & _sNewlineTab & "Result: " & e.Result.ToString() & _sNewlineTab & "Reason: " & e.Reason.ToString() & _sNewlineTab & "Source: " & e.Source.ToString()
            Else
                If Not e.Associate Is Nothing Then
                    message = _sNewlineTab & "Association Accepted" & e.Associate.ToString()
                End If
            End If
            LogText("After Associate Request", message)
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

        Public Delegate Sub StartUpdateDelegate(ByVal lv As ListView)
        Private Sub StartUpdate(ByVal lv As ListView)
            If InvokeRequired Then
                Invoke(New StartUpdateDelegate(AddressOf StartUpdate), lv)
            Else
                For Each item As ListViewItem In lv.Items
                    Dim result As ModalityWorklistResult = TryCast(item.Tag, ModalityWorklistResult)

                    If result IsNot Nothing Then
                        TryCast(result.Tag, DicomDataSet).Dispose()
                    End If
                Next
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


        Public Delegate Sub AddResultItemDelegate(ByVal result As ModalityWorklistResult)
        Private Sub AddResultItem(ByVal result As ModalityWorklistResult)
            Dim item As ListViewItem

            If InvokeRequired Then
                Invoke(New AddResultItemDelegate(AddressOf AddResultItem), result)
            Else
                item = _listViewWorkItems.Items.Add(result.AccessionNumber)
                item.SubItems.Add(result.PatientId)
                item.SubItems.Add(result.PatientName.Full)
                If result.PatientBirthDate.HasValue Then
                    item.SubItems.Add(result.PatientBirthDate.Value.ToShortDateString())
                Else
                    item.SubItems.Add(String.Empty)
                End If
                item.SubItems.Add(result.PatientSex)
                If Not result.ScheduledProcedureStepSequence Is Nothing AndAlso result.ScheduledProcedureStepSequence.Count > 0 Then
                    If result.ScheduledProcedureStepSequence(0).ScheduledProcedureStepStartDate.HasValue Then
                        item.SubItems.Add(result.ScheduledProcedureStepSequence(0).ScheduledProcedureStepStartDate.Value.ToShortDateString())
                    Else
                        item.SubItems.Add(String.Empty)
                    End If
                    item.SubItems.Add(result.ScheduledProcedureStepSequence(0).Modality)
                    item.SubItems.Add(result.ScheduledProcedureStepSequence(0).ScheduledStationAeTitle)
                    item.SubItems.Add(result.ScheduledProcedureStepSequence(0).ScheduledProcedureStepDescription)
                End If

                item.Tag = result
            End If
        End Sub

        Public Delegate Sub EnableCancelDelegate(ByVal enable As Boolean)
        Public Sub EnableCancel(ByVal enable As Boolean)
            If InvokeRequired Then
                Invoke(New EnableCancelDelegate(AddressOf EnableCancel), enable)
            Else
                _canCancel = enable
                buttonCancel.Enabled = _canCancel
            End If
        End Sub


        Public Delegate Sub EnableItemsDelegate(ByVal enable As Boolean)
        Public Sub EnableItems(ByVal enable As Boolean)
            If InvokeRequired Then
                Invoke(New EnableItemsDelegate(AddressOf EnableItems), enable)
            Else
                _menuStrip.Enabled = enable

                _listViewWorkItems.Enabled = enable
                buttonSearch.Enabled = enable
                buttonCancel.Enabled = (Not enable) AndAlso _canCancel
                listViewInProgress.Enabled = enable
                buttonCreateMPPS.Enabled = enable AndAlso _listViewWorkItems.SelectedItems.Count = 1
                saveAsDicomFileToolStripMenuItem.Enabled = _listViewWorkItems.SelectedItems.Count > 0
            End If
      End Sub

      Private Function OnBeforeAdd(ByVal parent As LinkedList(Of Long), ByVal data As Object, ByVal tag As Long) As Boolean
         Return _mySettings.ExcludeList.Contains(tag)
      End Function

      Private Function GetQueryParams() As ModalityWorklistQuery
         Dim query As ModalityWorklistQuery = New ModalityWorklistQuery()

         If patientQuery.Checked Then
            query.PatientName = _pbQuery.PatientName
            query.PatientId = _pbQuery.PatientId
            query.RequestedProcedureId = _pbQuery.RequestedProcedureId
            query.AccessionNumber = _pbQuery.AccessionNumber
         Else
            Dim bq As BroadQuery = New BroadQuery()

#If (LEADTOOLS_V18_OR_LATER) Then
            bq.ScheduledProcedureStepStartDate = _bbQuery.ScheduledProcedureStepStartDate
#Else
                If _bbQuery.ScheduledProcedureStepStartDate <> DateTime.MinValue Then
                    bq.ScheduledProcedureStepStartDate = _bbQuery.ScheduledProcedureStepStartDate
                Else
                    bq.ScheduledProcedureStepStartDate = Nothing
                End If
#End If
            bq.Modality = _bbQuery.Modality
            bq.ScheduledStationAeTitle = _bbQuery.ScheduledStationAeTitle
            query.Broad.Add(bq)
         End If
         Return query
      End Function

      Private Sub ShowProgress(ByVal show As Boolean)
         If show Then
            toolStripProgressBar.MarqueeAnimationSpeed = 30
            toolStripProgressBar.Visible = True
         Else
            toolStripProgressBar.Visible = False
            toolStripProgressBar.MarqueeAnimationSpeed = 0
         End If
      End Sub

      Private Sub FoundMatch(ByVal result As ModalityWorklistResult, ByVal ds As DicomDataSet)
         Dim message As String = _sNewlineTab & "Accession #:" & Constants.vbTab + Constants.vbTab & " " & result.AccessionNumber + _sNewlineTab & "Patient Name:" & Constants.vbTab + Constants.vbTab + result.PatientName.Full

         If (result.ScheduledProcedureStepSequence.Count > 0) AndAlso result.ScheduledProcedureStepSequence(0).ScheduledProcedureStepStartDate.HasValue Then
            message &= _sNewlineTab & "Scheduled Start Date:" & Constants.vbTab + result.ScheduledProcedureStepSequence(0).ScheduledProcedureStepStartDate.Value.ToShortDateString()
         End If
         LogText("Worklist Item Found", message)

         If ds IsNot Nothing Then
            Dim data As New DicomDataSet()

            data.Copy(ds, Nothing, Nothing)
            result.Tag = data
         End If
         AddResultItem(result)
      End Sub

      Private Sub SearchThread(ByVal q As Object)
         Dim query As ModalityWorklistQuery = TryCast(q, ModalityWorklistQuery)

         Try
            _find.Find(Of ModalityWorklistQuery, ModalityWorklistResult)(_mwlServer, query, New DicomMatchDelegate(Of ModalityWorklistResult)(AddressOf FoundMatch), _MwlFind)
         Catch ex As Exception
            LogError(ex.Message)

            If String.Compare(ex.Message, "The attempt to connect was forcefully rejected", True) = 0 Then
               If _mySettings.IsPreconfigured Then
                  'string 
                  Dim sImportant As String = String.Format(Constants.vbLf + Constants.vbTab & "This demo is preconfigured to communicate with {0} DICOM Service." & Constants.vbLf + Constants.vbTab & "To start the service:" & Constants.vbLf + Constants.vbTab & "* Run CSLeadtools.Dicom.Server.Manager.exe" & Constants.vbLf + Constants.vbTab & "* Select the {0} service" & Constants.vbLf + Constants.vbTab & "* Click the 'Start Server' button (blue triangle) to start the DICOM service.", _mySettings.GetServerAe(_mySettings.DefaultMwlQuery))
                  LogText("*** IMPORTANT ***", sImportant, Color.Red)
               End If
            End If
         End Try
      End Sub

      Private Sub DoSearch()
         Dim query As ModalityWorklistQuery = GetQueryParams()

         If _find Is Nothing Then
            CreateCFindObject()
         End If
         If _modalityPPS Is Nothing Then
            CreateModalityPPSObject()
         End If

         EnableItems(False)
         StartUpdate(_listViewWorkItems)
         _find.AETitle = _mySettings.ClientAe.AE

         ShowProgress(True)
         Dim t As Thread = New Thread(New ParameterizedThreadStart(AddressOf SearchThread))
         t.Start(query)
         Do While t.IsAlive
            Application.DoEvents()
         Loop
         ShowProgress(False)
         EnableItems(True)
         If _listViewWorkItems.Items.Count > 0 Then
            _listViewWorkItems.Items(0).Selected = True
            _listViewWorkItems.Focus()
         End If
         EndUpdate(_listViewWorkItems)
         StatusText(String.Empty)
      End Sub

      Private Sub MPPSCreate(ByVal data As Object)
         Try
            Dim mpps As MPPSNCreate

            mpps = CType(data, MPPSNCreate)
            _modalityPPS.AETitle = _mySettings.ClientAe.AE
            _modalityPPS.Status = DicomCommandStatusType.Failure
            _modalityPPS.Create(Of MPPSNCreate)(_mppsServer, mpps, True, New BeforeAddTagDelegate(AddressOf OnBeforeAdd))
         Catch ex As Exception
            LogError(ex.Message)

            If String.Compare(ex.Message, "The attempt to connect was forcefully rejected", True) = 0 Then
               If _mySettings.IsPreconfigured Then
                  'string 
                  Dim sImportant As String = String.Format(Constants.vbLf + Constants.vbTab & "This demo is preconfigured to communicate with {0} DICOM Service." & Constants.vbLf + Constants.vbTab & "To start the service:" & Constants.vbLf + Constants.vbTab & "* Run CSLeadtools.Dicom.Server.Manager.exe" & Constants.vbLf + Constants.vbTab & "* Select the {0} service" & Constants.vbLf + Constants.vbTab & "* Click the 'Start Server' button (blue triangle) to start the DICOM service.", _mySettings.GetServerAe(_mySettings.DefaultMpps))
                  LogText("*** IMPORTANT ***", sImportant, Color.Red)
               End If
            End If
         End Try
      End Sub

      Private Sub DoMPPSCreate(ByVal mpps As MPPSNCreate)
         EnableItems(False)
         ShowProgress(True)

         Dim t As Thread = New Thread(AddressOf MPPSCreate)

         t.Start(mpps)
         Do While t.IsAlive
            Application.DoEvents()
            Thread.Sleep(0)
         Loop
         ShowProgress(False)
         If _modalityPPS.Status = DicomCommandStatusType.Success Then
            Dim item As ListViewItem = AddProcedureStep(mpps)

            item.Selected = True
            listViewInProgress.EnsureVisible(item.Index)
         End If
         EnableItems(True)
         StatusText(String.Empty)
      End Sub

      Private Sub DoCancel()
         Dim cancelled As Boolean = False

         If _find.IsAssociated() Then
            _find.CancelRequest()
            cancelled = True
         End If

         If _modalityPPS.IsAssociated() Then
            _modalityPPS.CancelRequest()
            cancelled = True
         End If

         If _store.IsAssociated() Then
            _store.CancelRequest()
            _CancelStore = True
         End If

         If cancelled Then
            LogText("Cancelled", _sNewlineTab & "Sent C-Cancel")
            StatusText("Cancelled")
         End If
      End Sub

      Private Sub _listViewWorkItems_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _listViewWorkItems.SelectedIndexChanged
         buttonCreateMPPS.Enabled = _listViewWorkItems.SelectedItems.Count > 0
         saveAsDicomFileToolStripMenuItem.Enabled = _listViewWorkItems.SelectedItems.Count > 0
      End Sub

      Private Sub clearLogToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles clearLogToolStripMenuItem.Click
         _richTextBoxLog.Clear()
      End Sub

      Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem.Click
         Application.Exit()
      End Sub

      Private Sub aboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aboutToolStripMenuItem.Click
         Dim dlg As AboutDialog = New AboutDialog("DICOM High Level Modality Worklist Client")

         dlg.ShowDialog(Me)
      End Sub

        Private Sub _toolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _ToolStripMenuItem1.Click
            _richTextBoxLog.Clear()
        End Sub

        Private Sub Options_Click(ByVal sender As Object, ByVal e As EventArgs) Handles dICOMSettingsToolStripMenuItem.Click
         ' Check if the options have changed
         If System.Windows.Forms.DialogResult.OK = DoOptions() Then
            'CreateCFindObject()
            'CreateModalityPPSObject()
            'CreateCStoreObject()
         End If
      End Sub

      Private Sub optionsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
         Options_Click(sender, e)
      End Sub

      Private Sub StatusText(ByVal s As String)
         Application.DoEvents()
      End Sub

      Private Sub _buttonSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonSearch.Click
         If _MwlFind Is Nothing Then
            Using stream As New MemoryStream(ASCIIEncoding.ASCII.GetBytes(Templates.MWLFind))
               stream.Position = 0
               _MwlFind = New DicomDataSet()
               _MwlFind.LoadXml(stream, DicomDataSetLoadXmlFlags.None)
            End Using
         End If

         DoSearch()
      End Sub

      Private Sub searchToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles searchToolStripMenuItem.Click
         DoSearch()
      End Sub

      Private Sub _buttonCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonCancel.Click
         DoCancel()
      End Sub

      Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
         SaveProcedureStep()
         Utils.EngineShutdown()
         Utils.DicomNetShutdown()
      End Sub

      Private Sub showHelpToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles showHelpToolStripMenuItem.Click
         Dim dlg As HelpDialog = New HelpDialog(_mySettings.GetServerAe(_mySettings.DefaultMwlQuery), False)
         dlg.ShowDialog(Me)
      End Sub

      Private Sub MainForm_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
         MyBase.Activate()
         If _firstTime AndAlso _mySettings.ShowHelpOnStart Then
            _firstTime = False
            Dim dlg As HelpDialog = New HelpDialog(_mySettings.GetServerAe(_mySettings.DefaultMwlQuery), _mySettings.ShowHelpOnStart)
            dlg.ShowDialog(Me)
            If dlg.CheckBoxNoShowAgainResult Then
               _mySettings.ShowHelpOnStart = False
               DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)
            End If
         End If
      End Sub

      Private Sub _listViewWorkItems_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles _listViewWorkItems.DoubleClick
         If _listViewWorkItems.SelectedItems.Count = 1 Then
            Dim result As ModalityWorklistResult = TryCast(_listViewWorkItems.SelectedItems(0).Tag, ModalityWorklistResult)
            Dim viewer As DicomViewer = New DicomViewer(TryCast(result.Tag, DicomDataSet))

            viewer.ShowDialog(Me)
         End If
      End Sub

      Private Sub buttonCreateMPPS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonCreateMPPS.Click
            Dim result As ModalityWorklistResult = TryCast(_listViewWorkItems.SelectedItems(0).Tag, ModalityWorklistResult)
            Dim mpps As MPPSNCreate = MPPSNCreate.FromWorklistItem(result)
            Dim editor As DicomEditor = Nothing

            mpps.PerformedStationAeTitle = Environment.MachineName
            mpps.PerformedStationName = Environment.MachineName
            mpps.PerformedProcedureStepStartDate = DateTime.Now
            mpps.PerformedProcedureStepStartTime = DateTime.Now
            mpps.PerformedSeriesSequence = New List(Of PerformedSeries)()
            mpps.PerformedSeriesSequence.Add(New PerformedSeries())
            mpps.PerformedSeriesSequence(0).ProtocolName = MPPSNCreate.RandomId(16)
            mpps.PerformedSeriesSequence(0).SeriesInstanceUID = Utils.GenerateDicomUniqueIdentifier()
            mpps.SOPInstance.SOPInstanceUid = Utils.GenerateDicomUniqueIdentifier()

            editor = New DicomEditor(_mySettings.ExcludeList)

            If editor.Edit(Of MPPSNCreate)(Me, mpps, New Action(Of BeforeAddElementEventArgs)(AddressOf OnCheckProperty)) = DialogResult.OK Then
                DoMPPSCreate(mpps)
            End If
        End Sub

      Private Sub buttonEditMPPSDataset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mPPSTemplateToolStripMenuItem.Click
         Dim editor As MPPSDatasetEditor = New MPPSDatasetEditor()

         editor.ExcludeList.AddRange(_mySettings.ExcludeList)
         If editor.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _mySettings.ExcludeList.Clear()
            _mySettings.ExcludeList.AddRange(editor.ExcludeList)
            DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)
         End If
      End Sub

      Private Function AddProcedureStep(ByVal mpps As MPPSNCreate) As ListViewItem
         Dim item As ListViewItem = listViewInProgress.Items.Add(mpps.ScheduledStepAttributeSequence(0).AccessionNumber)
         Dim result As ModalityWorklistResult = TryCast(_listViewWorkItems.SelectedItems(0).Tag, ModalityWorklistResult)

         item.SubItems.Add(mpps.PatientId)
         item.SubItems.Add(mpps.Modality)
         item.SubItems.Add(mpps.PerformedProcedureStepStartDate.Value.ToShortDateString())
         item.SubItems.Add(mpps.PerformedProcedureStepStartTime.Value.ToShortTimeString())
         item.SubItems.Add(mpps.PerformedProcedureStepId)
         item.SubItems.Add(mpps.PerformedStationAeTitle)
         item.SubItems.Add(mpps.PerformedStationName)
         item.Tag = New ProcedureStep(mpps, result)
         Return item
      End Function

      Private Function AddProcedureStep(ByVal ps As ProcedureStep) As ListViewItem
         Dim item As ListViewItem = listViewInProgress.Items.Add(ps.Mpps.ScheduledStepAttributeSequence(0).AccessionNumber)

         item.SubItems.Add(ps.Mpps.PatientId)
         item.SubItems.Add(ps.Mpps.Modality)
         item.SubItems.Add(ps.Mpps.PerformedProcedureStepStartDate.Value.ToShortDateString())
         item.SubItems.Add(ps.Mpps.PerformedProcedureStepStartTime.Value.ToShortTimeString())
         item.SubItems.Add(ps.Mpps.PerformedProcedureStepId)
         item.SubItems.Add(ps.Mpps.PerformedStationAeTitle)
         item.SubItems.Add(ps.Mpps.PerformedStationName)
         item.Tag = ps
         Return item
      End Function

      Private Sub listViewInProgress_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listViewInProgress.SelectedIndexChanged
         buttonSetMPPS.Enabled = listViewInProgress.SelectedItems.Count > 0
         buttonAddImage.Enabled = buttonSetMPPS.Enabled
         buttonCancelMPPS.Enabled = buttonSetMPPS.Enabled
         buttonCompleteMPPS.Enabled = buttonSetMPPS.Enabled
      End Sub

      Private Sub OnCheckProperty(ByVal e As BeforeAddElementEventArgs)
         If (Not _AllowedSet.Contains(e.Element.DicomElement.Tag)) Then
            e.Element.Attributes.Add(New ReadOnlyAttribute(True))
         End If
      End Sub

      Private Sub toolStripButtonAddImage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonAddImage.Click
         If openFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Dim ps As ProcedureStep = TryCast(listViewInProgress.SelectedItems(0).Tag, ProcedureStep)

            _CancelStore = False
            Try
               EnableItems(False)
               ShowProgress(True)
               DoStore(openFileDialog.FileNames, ps)
            Finally
               EnableItems(True)
               ShowProgress(False)
            End Try
         End If
      End Sub

      Private Sub DoStore(ByVal filenames As String(), ByVal ps As ProcedureStep)
         Dim bShowImportantMessage As Boolean = False

         For Each file As String In filenames
            If _CancelStore Then
               Exit For
            End If

            Application.DoEvents()
            Try
               Using ds As DicomDataSet = New DicomDataSet()
                  Dim instance As SopInstanceReference

                  ds.Load(file, DicomDataSetLoadFlags.None)
                  UpdateDataset(ds, ps)

                  If _mySettings.ViewerBeforeSend Then
                     Dim dcmViewer As DicomViewer = New DicomViewer(ds)

                     dcmViewer.Text = "DICOM Dataset Viewer (Dataset to store for MPPS)"
                     dcmViewer.ModuleView = True
                     dcmViewer.ShowDialog(Me)
                  End If
                  _store.Store(_storageServer, ds)
                  instance = SopInstanceReference.Import(ds)

                  If (Not String.IsNullOrEmpty(instance.ReferencedSopInstanceUid)) AndAlso (Not String.IsNullOrEmpty(instance.ReferencedSopClassUid)) Then
                     Dim series As PerformedSeries = ps.Mpps.PerformedSeriesSequence(0)

                     If series.ReferencedImageSequence Is Nothing Then
                        series.ReferencedImageSequence = New List(Of SopInstanceReference)()
                     End If

                     series.ReferencedImageSequence.Add(instance)
                  End If
               End Using
            Catch e As Exception
               LogError(e.Message)
               If String.Compare(e.Message, "The attempt to connect was forcefully rejected", True) = 0 Then
                  If _mySettings.IsPreconfigured Then
                     bShowImportantMessage = True
                  End If
               End If
            End Try
         Next file

         If bShowImportantMessage Then
            Dim sImportant As String = String.Format(Constants.vbLf + Constants.vbTab & "This demo is preconfigured to communicate with {0} DICOM Service." & Constants.vbLf + Constants.vbTab & "To start the service:" & Constants.vbLf + Constants.vbTab & "* Run CSLeadtools.Dicom.Server.Manager.exe" & Constants.vbLf + Constants.vbTab & "* For each of the following services" & Constants.vbLf + Constants.vbTab & "* Click the 'Start Server' button (blue triangle) to start the DICOM service" & Constants.vbLf + Constants.vbTab & "{0}" & Constants.vbLf + Constants.vbTab & "{1}" & Constants.vbLf + Constants.vbTab & "{2}.", _mySettings.DefaultMwlQuery, _mySettings.DefaultMpps, _mySettings.DefaultStore)
            LogText("*** IMPORTANT ***", sImportant, Color.Red)
         End If
      End Sub

      '
      ' Updates the dataset with MPPS info.  This normally happens on an image that has been captured from a modality.  We
      ' are simulating it here by loading an image and forwarding it.
      '
      Public Sub UpdateDataset(ByVal ds As DicomDataSet, ByVal ps As ProcedureStep)
         Dim info As MppsIodInfo = New MppsIodInfo()

         info.StudyInstanceUID = ps.Mpps.ScheduledStepAttributeSequence(0).StudyInstanceUid
         info.ReferencedStudySequence = ps.Mpps.ScheduledStepAttributeSequence(0).ReferencedStudySequence
         info.AccessionNumber = ps.Mpps.ScheduledStepAttributeSequence(0).AccessionNumber

         info.RequestAttributesSequence = New List(Of RequestAttributes)()
         info.RequestAttributesSequence.Add(New RequestAttributes())
         info.RequestAttributesSequence(0).RequestedProcedureID = ps.Mpps.ScheduledStepAttributeSequence(0).RequestedProcedureId
         info.RequestAttributesSequence(0).RequestedProcedureDescription = ps.Mpps.ScheduledStepAttributeSequence(0).RequestedProcedureDescription
         info.RequestAttributesSequence(0).ScheduledProcedureStepID = ps.Mpps.ScheduledStepAttributeSequence(0).ScheduledProcedureStepId
         'info.RequestAttributesSequence(0).ScheduledProcedureStepDescription = ps.Mpps.ScheduledStepAttributeSequence(0).ScheduledProcedureStepDescription
         info.RequestAttributesSequence(0).ScheduledProtocolCodeSequence = ps.Mpps.ScheduledStepAttributeSequence(0).ScheduledProtocolCodeSequence

         info.StudyID = ps.Mpps.ScheduledStepAttributeSequence(0).RequestedProcedureId
         info.PerformedProcedureStepID = ps.Mpps.PerformedProcedureStepId
         info.PerformedProcedureStepStartDate = ps.Mpps.PerformedProcedureStepStartDate
         info.PerformedProcedureStepStartTime = ps.Mpps.PerformedProcedureStepStartTime
         info.ProcedureCodeSequence = ps.Mpps.ScheduledStepAttributeSequence(0).RequestedProcedureCodeSequence
         info.ProtocolName = ps.Mpps.PerformedSeriesSequence(0).ProtocolName

         info.ReferencedPerformedProcedureStepSequence = New List(Of SopInstanceReference)()
         info.ReferencedPerformedProcedureStepSequence.Add(New SopInstanceReference())
         info.ReferencedPerformedProcedureStepSequence(0).ReferencedSopClassUid = DicomUidType.ModalityPerformedClass
         info.ReferencedPerformedProcedureStepSequence(0).ReferencedSopInstanceUid = ps.Mpps.SOPInstance.SOPInstanceUid

         ds.InsertElementAndSetValue(DicomTag.PatientName, ps.Result.PatientName)
         ds.InsertElementAndSetValue(DicomTag.PatientID, ps.Result.PatientId)
         ds.InsertElementAndSetValue(DicomTag.PatientSex, ps.Result.PatientSex)
         ds.InsertElementAndSetValue(DicomTag.PatientComments, ps.Result.PatientComments)
         ds.InsertElementAndSetValue(DicomTag.SeriesInstanceUID, Utils.GenerateDicomUniqueIdentifier())
         ds.InsertElementAndSetValue(DicomTag.SOPInstanceUID, Utils.GenerateDicomUniqueIdentifier())
         ds.InsertElementAndSetValue(DicomTag.Modality, ps.Mpps.Modality)
         ds.InsertElementAndSetValue(DicomTag.ScheduledProcedureStepDescription, ps.Mpps.ScheduledStepAttributeSequence(0).ScheduledProcedureStepDescription)
         ds.Set(info)
      End Sub

      Public Function GetProcedureStepFilename() As String
         Dim commonFolder As String = DicomDemoSettingsManager.GetFolderPath()
         Dim settingsFilename As String = commonFolder & "\procedurestep.xml"

         Return settingsFilename
      End Function

      Public Sub SaveProcedureStep()
         Dim filename As String = GetProcedureStepFilename()
         Dim xs As XmlSerializer = New XmlSerializer(GetType(List(Of ProcedureStep)))
         Dim xmlTextWriter As TextWriter = New StreamWriter(filename)
         Dim list As List(Of ProcedureStep) = New List(Of ProcedureStep)()

         For Each item As ListViewItem In listViewInProgress.Items
            Dim ps As ProcedureStep = TryCast(item.Tag, ProcedureStep)

            list.Add(ps)
         Next item

         xs.Serialize(xmlTextWriter, list)
         xmlTextWriter.Close()
      End Sub

      Public Sub LoadProcedureStep()
         Dim SerializerObj As New XmlSerializer(GetType(List(Of ProcedureStep)))
         Dim filename As String = GetProcedureStepFilename()

         If File.Exists(filename) Then
            Try
               Dim list As List(Of ProcedureStep)
               Dim ReadFileStream As New FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read)

               list = CType(SerializerObj.Deserialize(ReadFileStream), List(Of ProcedureStep))
               For Each ps As ProcedureStep In list
                  AddProcedureStep(ps)
               Next
               ReadFileStream.Close()
            Catch generatedExceptionName As Exception
            End Try
         End If
      End Sub


      Private Sub SetDefaultServer(ByVal comboBox As ComboBox, ByVal scp As Scp, ByVal mySettingsDefaultAeTitle As String)
         Dim defaultAE As DicomAE = _mySettings.GetServer(mySettingsDefaultAeTitle)
         If Not Nothing Is defaultAE Then
            scp.AETitle = defaultAE.AE
            scp.Port = CInt(defaultAE.Port)
            scp.PeerAddress = IPAddress.Parse(defaultAE.IPAddress)
            scp.Timeout = defaultAE.Timeout
         End If
      End Sub


      Private Sub UpdateDefaultServerAE(ByVal comboBox As ComboBox, ByVal scp As Scp)
         If comboBox.Items.Count > 0 Then
            If comboBox Is toolStripComboBoxMWLScp.ComboBox Then
               _mySettings.DefaultMwlQuery = comboBox.Text
            ElseIf comboBox Is toolStripComboBoxMPPSScp.ComboBox Then
               _mySettings.DefaultMpps = comboBox.Text
            ElseIf comboBox Is toolStripComboBoxStoreScp.ComboBox Then
               _mySettings.DefaultStore = comboBox.Text
            End If

            DicomDemoSettingsManager.SaveSettings(_demoName, _mySettings)

            SetDefaultServer(comboBox, scp, comboBox.Text)
         End If
      End Sub

      Private Sub _comboBoxMwl_SelectionChangeCommitted(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripComboBoxMWLScp.SelectedIndexChanged
         UpdateDefaultServerAE(toolStripComboBoxMWLScp.ComboBox, _mwlServer)
         CreateCFindObject()
      End Sub

      Private Sub _comboBoxMpps_SelectionChangeCommitted(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripComboBoxMPPSScp.SelectedIndexChanged
         UpdateDefaultServerAE(toolStripComboBoxMPPSScp.ComboBox, _mppsServer)
         CreateModalityPPSObject()
      End Sub

      Private Sub _comboBoxStore_SelectionChangeCommitted(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripComboBoxStoreScp.SelectedIndexChanged
         UpdateDefaultServerAE(toolStripComboBoxStoreScp.ComboBox, _storageServer)
         CreateCStoreObject()
      End Sub

      Private Function SelectDefaultServerAE(ByVal comboBox As ComboBox, ByVal defaultAeTitle As String) As String
         Dim ret As String = String.Empty
         If comboBox.Items.Count > 0 Then
            comboBox.SelectedItem = defaultAeTitle

            If -1 = comboBox.SelectedIndex AndAlso comboBox.Items.Count > 0 Then
               comboBox.SelectedIndex = 0
            End If

            If comboBox.Items.Count > 0 Then
               ret = comboBox.SelectedItem.ToString()
            End If
         End If

         comboBox.Enabled = (comboBox.Items.Count > 0)
         Return ret
      End Function

      Private Function UpdateComboBoxService(ByVal comboBox As ComboBox, ByVal defaultAeTitle As String) As String
         comboBox.Items.Clear()

         For Each myServer As DicomAE In _mySettings.ServerList
            comboBox.Items.Add(myServer.AE)
         Next myServer

         Return SelectDefaultServerAE(comboBox, defaultAeTitle)
      End Function

      Private Sub UpdateComboBoxServices()
         _mySettings.DefaultMwlQuery = UpdateComboBoxService(toolStripComboBoxMWLScp.ComboBox, _mySettings.DefaultMwlQuery)
         _mySettings.DefaultMpps = UpdateComboBoxService(toolStripComboBoxMPPSScp.ComboBox, _mySettings.DefaultMpps)
         _mySettings.DefaultStore = UpdateComboBoxService(toolStripComboBoxStoreScp.ComboBox, _mySettings.DefaultStore)
      End Sub

      Private Sub SetLabelInfo(ByVal label As ToolStripStatusLabel, ByVal combo As ComboBox)
         label.Text = combo.Text
      End Sub

      Private Sub toolStripButtonSet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonSetMPPS.Click
         Dim ps As ProcedureStep = TryCast(listViewInProgress.SelectedItems(0).Tag, ProcedureStep)
         Dim editor As DicomEditor = Nothing
         Dim mpps As MPPSNCreate = ps.Mpps
         Dim mppsNSet = New MPPSNSet()

         mpps.CopyTo(mppsNSet)
         editor = New DicomEditor(_mySettings.ExcludeList)
         editor.Text = "Edit Modality Peformed Procedure Step"
         editor.DefaultTag = DicomTag.PerformedProcedureStepStatus
         If editor.Edit(Of MPPSNSet)(Me, mppsNSet, New Action(Of BeforeAddElementEventArgs)(AddressOf OnCheckProperty)) = System.Windows.Forms.DialogResult.OK Then
            Try
               _modalityPPS.Status = DicomCommandStatusType.Failure
               ShowProgress(True)
               _modalityPPS.Set(Of MPPSNSet)(_mppsServer, True, mppsNSet)
               If _modalityPPS.Status = DicomCommandStatusType.Success Then
                  mppsNSet.CopyTo(mpps)
                  ps.Mpps = mpps
                  listViewInProgress.SelectedItems(0).Tag = ps
               ElseIf _modalityPPS.Status = DicomCommandStatusType.NoSuchObjectInstance Then
                  listViewInProgress.Items.Remove(listViewInProgress.SelectedItems(0))
               End If
            Catch
            Finally
               ShowProgress(False)
            End Try
         End If
      End Sub

      Private Sub buttonCancelMPPS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonCancelMPPS.Click
         Dim ps As ProcedureStep = TryCast(listViewInProgress.SelectedItems(0).Tag, ProcedureStep)
         Dim editor As DicomEditor = Nothing
         Dim mpps As MPPSNCreate = ps.Mpps
         Dim mppsNSet = New MPPSNSet()

         mpps.CopyTo(mppsNSet)
         mppsNSet.PerformedProcedureStepStatus = "DISCONTINUED"
         If mppsNSet.PerformedProcedureStepEndDate Is Nothing Then
            mppsNSet.PerformedProcedureStepEndDate = DateTime.Now
            mppsNSet.PerformedProcedureStepEndTime = mppsNSet.PerformedProcedureStepEndDate
         End If
         editor = New DicomEditor(_mySettings.ExcludeList)
         editor.Text = "Discontinue Modality Peformed Procedure Step"
         editor.DefaultTag = DicomTag.PerformedProcedureStepStatus
         If editor.Edit(Of MPPSNSet)(Me, mppsNSet, New Action(Of BeforeAddElementEventArgs)(AddressOf OnCheckProperty)) = System.Windows.Forms.DialogResult.OK Then
            Try
               _modalityPPS.Status = DicomCommandStatusType.Failure
               ShowProgress(True)
               _modalityPPS.Set(Of MPPSNSet)(_mppsServer, True, mppsNSet)
               If _modalityPPS.Status = DicomCommandStatusType.Success Then
                  mppsNSet.CopyTo(mpps)
                  ps.Mpps = mpps
                  listViewInProgress.Items.Remove(listViewInProgress.SelectedItems(0))
               ElseIf _modalityPPS.Status = DicomCommandStatusType.NoSuchObjectInstance Then
                  listViewInProgress.Items.Remove(listViewInProgress.SelectedItems(0))
               End If
            Catch
            Finally
               ShowProgress(False)
            End Try
         End If
      End Sub

      Private Sub buttonCompleteMPPS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonCompleteMPPS.Click
         Dim ps As ProcedureStep = TryCast(listViewInProgress.SelectedItems(0).Tag, ProcedureStep)
         Dim editor As DicomEditor = Nothing
         Dim mpps As MPPSNCreate = ps.Mpps
         Dim mppsNSet = New MPPSNSet()

         mpps.CopyTo(mppsNSet)
         mppsNSet.PerformedProcedureStepStatus = "COMPLETED"
         If mppsNSet.PerformedProcedureStepEndDate Is Nothing Then
            mppsNSet.PerformedProcedureStepEndDate = DateTime.Now
            mppsNSet.PerformedProcedureStepEndTime = mppsNSet.PerformedProcedureStepEndDate
         End If
         editor = New DicomEditor(_mySettings.ExcludeList)
         editor.Text = "Complete Modality Peformed Procedure Step"
         editor.DefaultTag = DicomTag.PerformedProcedureStepStatus
         If editor.Edit(Of MPPSNSet)(Me, mppsNSet, New Action(Of BeforeAddElementEventArgs)(AddressOf OnCheckProperty)) = System.Windows.Forms.DialogResult.OK Then
            Try
               mppsNSet.CopyTo(mpps)
               ps.Mpps = mpps
               _modalityPPS.Status = DicomCommandStatusType.Failure
               ShowProgress(True)
               _modalityPPS.Set(Of MPPSNSet)(_mppsServer, True, mppsNSet)
               If _modalityPPS.Status = DicomCommandStatusType.Success Then
                  listViewInProgress.Items.Remove(listViewInProgress.SelectedItems(0))
               ElseIf _modalityPPS.Status = DicomCommandStatusType.NoSuchObjectInstance Then
                  listViewInProgress.Items.Remove(listViewInProgress.SelectedItems(0))
               End If
            Catch
            Finally
               ShowProgress(False)
            End Try
         End If
      End Sub

      Private Sub contextMenuStripMPPS_Opening(ByVal sender As Object, ByVal e As CancelEventArgs) Handles contextMenuStripMPPS.Opening
         InitializeContextMenu(contextMenuStripMPPS, toolStripComboBoxMPPSScp.ComboBox)
      End Sub

      Private Sub contextMenuStripMWL_Opening(ByVal sender As Object, ByVal e As CancelEventArgs) Handles contextMenuStripMWL.Opening
         InitializeContextMenu(contextMenuStripMWL, toolStripComboBoxMWLScp.ComboBox)
      End Sub

      Private Sub contextMenuStripStore_Opening(ByVal sender As Object, ByVal e As CancelEventArgs) Handles contextMenuStripStore.Opening
         Dim item As ToolStripMenuItem = New ToolStripMenuItem("View Store DataSet")

         InitializeContextMenu(contextMenuStripStore, toolStripComboBoxStoreScp.ComboBox)
         contextMenuStripStore.Items.Insert(0, New ToolStripSeparator())
         item.Checked = _mySettings.ViewerBeforeSend
         item.CheckOnClick = True
         AddHandler item.CheckedChanged, AddressOf ViewOnStore_Checked
         contextMenuStripStore.Items.Insert(0, item)
      End Sub

      Private Sub ViewOnStore_Checked(ByVal sender As Object, ByVal e As EventArgs)
         Dim item As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)

         _mySettings.ViewerBeforeSend = item.Checked
      End Sub

      Private Sub InitializeContextMenu(ByVal menu As ContextMenuStrip, ByVal combo As ComboBox)
         menu.Items.Clear()
         For Each ae As String In combo.Items
            Dim item As ToolStripMenuItem = New ToolStripMenuItem(ae)

            item.Tag = combo
            item.CheckOnClick = False
            If combo.Text = ae Then
               item.Checked = True
            End If
            menu.Items.Add(item)
            AddHandler item.Click, AddressOf item_Click
         Next ae
      End Sub

      Private Sub item_Click(ByVal sender As Object, ByVal e As EventArgs)
         Dim item As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)

         If (Not item.Checked) Then
            Dim combo As ComboBox = TryCast(item.Tag, ComboBox)

            combo.SelectedIndex = combo.Items.IndexOf(item.Text)
         End If
      End Sub

      Private Sub listViewInProgress_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles listViewInProgress.KeyDown
         If e.KeyCode = Keys.Delete AndAlso listViewInProgress.SelectedItems.Count > 0 Then
            listViewInProgress.Items.RemoveAt(listViewInProgress.SelectedIndices(0))
         End If
      End Sub

      Private Sub AddImagesToDataSet(ByVal ds As DicomDataSet, ByVal images As List(Of RasterImage))
         If images.Count = 0 Then
            Return
         End If

         Dim image1 As RasterImage = Nothing

         Dim width As Integer = images(0).Width
         Dim height As Integer = images(0).Height

         For Each img As RasterImage In images
            Dim sizeCmd As New SizeCommand(width, height, RasterSizeFlags.None)
            sizeCmd.Run(img)
         Next

         For i As Integer = 0 To images.Count - 1
            If i = 0 Then
               image1 = images(i).Clone()
            Else
               image1.AddPage(images(i))
            End If
         Next

         Dim resolCmd As New ColorResolutionCommand(ColorResolutionCommandMode.AllPages, image1.BitsPerPixel, image1.Order, RasterDitheringMethod.None, ColorResolutionCommandPaletteFlags.None, image1.GetPalette())
         resolCmd.Run(image1)

         Dim dPixel As DicomElement = ds.FindFirstElement(Nothing, DicomTag.PixelData, True)
         If dPixel Is Nothing Then
            dPixel = ds.InsertElement(Nothing, False, DicomTag.PixelData, DicomVRType.OW, False, 0)
         Else
            ds.DeleteElement(dPixel)
            dPixel = ds.InsertElement(Nothing, False, DicomTag.PixelData, DicomVRType.OW, False, 0)
         End If


         ds.SetImages(dPixel, image1, DicomImageCompressionType.None, DicomImagePhotometricInterpretationType.Rgb, 0, 2,
          DicomSetImageFlags.None)
         image1.Dispose()

      End Sub

      Private Sub saveAsDicomFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveAsDicomFileToolStripMenuItem.Click
         Try
            Dim result As ModalityWorklistResult = TryCast(_listViewWorkItems.SelectedItems(0).Tag, ModalityWorklistResult)
            Dim ds As DicomDataSet = TryCast(result.Tag, DicomDataSet)
            Dim images As List(Of RasterImage) = Nothing

            'If MessageBox.Show("Do you want Add Image to Dicom File", "Info", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            '   images = LoadImage()
            'End If

            If _saveFiledlg.ShowDialog() = DialogResult.OK Then
               Dim modifiedDataSet As DicomDataSet = Nothing
               modifiedDataSet = New DicomDataSet()
               modifiedDataSet.Copy(ds, Nothing, Nothing)
               If images IsNot Nothing Then
                  AddImagesToDataSet(modifiedDataSet, images)
                  For Each img As RasterImage In images
                     img.Dispose()
                  Next
               End If
               modifiedDataSet.Save(_saveFiledlg.FileName, DicomDataSetSaveFlags.None)
               modifiedDataSet.Dispose()
            End If

         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub
   End Class
End Namespace

Module DemoExtensions
   <System.Runtime.CompilerServices.Extension()>
   Public Sub CopyTo(Of T)(source As Object, dest As T)
      If source Is Nothing Then
         Throw New ArgumentNullException("source", "The object you are copying from cannot be null")
      End If

      If dest Is Nothing Then
         Throw New ArgumentNullException("dest", "The object you are copying to cannot be null")
      End If

      ' Don't copy if they are the same object
      If Not ReferenceEquals(source, dest) Then
         Dim matches As List(Of PropertyInfo) = GetMatchingProperties(source, dest)

         For Each fromProperty As PropertyInfo In matches
            Dim toProperty As PropertyInfo = dest.[GetType]().GetProperty(fromProperty.Name)

            If toProperty.CanWrite Then
               Dim value As Object = Nothing

               If TypeOf source Is DataRow Then
                  Dim row As DataRow = TryCast(source, DataRow)

                  If row(fromProperty.Name) IsNot Nothing Then
                     value = row(fromProperty.Name)
                  End If
               Else
                  value = fromProperty.GetValue(source, Nothing)
               End If

               If Convert.IsDBNull(value) Then
                  value = Nothing
               End If
               toProperty.SetValue(dest, value, Nothing)
            End If
         Next
      End If
   End Sub

   Private Function GetMatchingProperties(source As Object, target As Object) As List(Of PropertyInfo)
      If source Is Nothing Then
         Throw New ArgumentNullException("source")
      End If

      If target Is Nothing Then
         Throw New ArgumentNullException("target")
      End If

      Dim sourceType = source.[GetType]()
      Dim sourceProperties = sourceType.GetProperties()
      Dim targetType = target.[GetType]()
      Dim targetProperties = targetType.GetProperties()
      Dim properties = (From s In sourceProperties From t In targetProperties Where s.Name = t.Name AndAlso s.PropertyType Is t.PropertyType Select s).ToList()

      Return CType(properties, List(Of PropertyInfo))
   End Function
End Module

