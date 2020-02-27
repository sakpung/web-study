' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Windows.Forms
Imports System.Threading
Imports System.Collections.Generic


Imports Leadtools
Imports Leadtools.Dicom
Imports Leadtools.DicomDemos
Imports Leadtools.DicomDemos.Scp
Imports Leadtools.Demos.Database

Namespace DicomDemo

   ''' <summary>
   ''' Summary description for Server.
   ''' </summary>
   Public Class Server : Inherits Scp
      Private _Port As Integer = 104
      Private _Peers As Integer = 5
      Private _Verify As Boolean = True
      Private _IPAddress As String = ""

#If (LEADTOOLS_V17_OR_LATER) Then
        Private _ipType As DicomNetIpTypeFlags

      Public Shadows Property IpType() As DicomNetIpTypeFlags
         Get
            Return _ipType
         End Get
         Set(ByVal value As DicomNetIpTypeFlags)
            _ipType = value
         End Set
      End Property
#End If

      Private _Timeout As Integer = 1
      Private _ImageDir As String = Application.StartupPath & "\ImagesVB\"
      Private _LogDir As String = Application.StartupPath & "\LogVB\"
      Private _SaveCSReceived As Boolean = False
      Private _SaveDSReceived As Boolean = False
      Private _SaveDSSent As Boolean = False
      Private _Clients As Dictionary(Of String, Client) = New Dictionary(Of String, Client)()

      Private _isSecure As Boolean = False
      Private _certificationAuthoritiesFileName As String = Application.StartupPath & "\CA.pem"
      Private _serverPEM As String = Application.StartupPath & "\server.pem"

      Public mf As MainForm
      Public usersDB As UsersDB
      Public dicomDB As DicomDB

      Private _ExitEvent As AutoResetEvent = New AutoResetEvent(False)

#Region "Properties"

      Public Property Port() As Integer
         Get
            Return _Port
         End Get
         Set(ByVal value As Integer)
            _Port = value
         End Set
      End Property
      Public Property IsSecure() As Boolean
         Get
            Return _isSecure
         End Get
         Set(ByVal value As Boolean)
            _isSecure = value
         End Set
      End Property

      Public Property Peers() As Integer
         Get
            Return _Peers
         End Get
         Set(ByVal value As Integer)
            _Peers = value
         End Set
      End Property

      Public ReadOnly Property ExitEvent() As AutoResetEvent
         Get
            Return _ExitEvent
         End Get
      End Property

      Public Property Verify() As Boolean
         Get
            Return _Verify
         End Get
         Set(ByVal value As Boolean)
            _Verify = value
         End Set
      End Property

      Public Property IPAddress() As String
         Get
            Return _IPAddress
         End Get
         Set(ByVal value As String)
            _IPAddress = value
         End Set
      End Property

      Public Property Timeout() As Integer
         Get
            Return _Timeout
         End Get
         Set(ByVal value As Integer)
            _Timeout = value
         End Set
      End Property

      Public Property ImageDir() As String
         Get
            Return _ImageDir
         End Get
         Set(ByVal value As String)
            _ImageDir = value
         End Set
      End Property

      Public Property SaveCSReceived() As Boolean
         Get
            Return _SaveCSReceived
         End Get
         Set(ByVal value As Boolean)
            _SaveCSReceived = value
         End Set
      End Property

      Public Property SaveDSReceived() As Boolean
         Get
            Return _SaveDSReceived
         End Get
         Set(ByVal value As Boolean)
            _SaveDSReceived = value
         End Set
      End Property

      Public Property SaveDSSent() As Boolean
         Get
            Return _SaveDSSent
         End Get
         Set(ByVal value As Boolean)
            _SaveDSSent = value
         End Set
      End Property

      Public Property LogDir() As String
         Get
            Return _LogDir
         End Get
         Set(ByVal value As String)
            _LogDir = value
         End Set
      End Property

      Public ReadOnly Property Clients() As Dictionary(Of String, Client)
         Get
            Return _Clients
         End Get
      End Property


#End Region

        Public Sub New()
            CalledAE = "LEAD_SERVER"
#If (LEADTOOLS_V17_OR_LATER) Then
            IpType = DicomNetIpTypeFlags.Ipv4
#End If
        End Sub

      Public Overrides Sub Init()
         MyBase.Init()

         BuildExclusionList()
      End Sub

      Private Sub BuildExclusionList()
         UidExclusionList.Add(DicomUidType.PatientRootQueryGet)
         UidExclusionList.Add(DicomUidType.StudyRootQueryGet)
         UidExclusionList.Add(DicomUidType.PatientStudyQueryFind)
         UidExclusionList.Add(DicomUidType.PatientStudyQueryMove)
         UidExclusionList.Add(DicomUidType.PatientStudyQueryGet)
         UidExclusionList.Add(DicomUidType.ModalityWorklistFind)
         UidExclusionList.Add(DicomUidType.MediaStorageDirectory)
         UidExclusionList.Add(DicomUidType.BasicStudyNotificationClass)
         UidExclusionList.Add(DicomUidType.StorageCommitmentPushModelClass)
         UidExclusionList.Add(DicomUidType.StorageCommitmentPushModelInstance)
         UidExclusionList.Add(DicomUidType.StorageCommitmentPullModelClass)
         UidExclusionList.Add(DicomUidType.StorageCommitmentPullModelInstance)
         UidExclusionList.Add(DicomUidType.DetachedPatientClass)
         UidExclusionList.Add(DicomUidType.DetachedPatientMetaClass)
         UidExclusionList.Add(DicomUidType.DetachedVisitClass)
         UidExclusionList.Add(DicomUidType.DetachedStudyClass)
         UidExclusionList.Add(DicomUidType.StudyComponentClass)
         UidExclusionList.Add(DicomUidType.ModalityPerformedClass)
         UidExclusionList.Add(DicomUidType.ModalityPerformedRetrieveClass)
         UidExclusionList.Add(DicomUidType.ModalityPerformedNotificationClass)
         UidExclusionList.Add(DicomUidType.DetachedResultsClass)
         UidExclusionList.Add(DicomUidType.DetachedResultsMetaClass)
         UidExclusionList.Add(DicomUidType.DetachedStudyMetaClass)
         UidExclusionList.Add(DicomUidType.DetachedInterpretationClass)
         UidExclusionList.Add(DicomUidType.BasicFilmSessionClass)
         UidExclusionList.Add(DicomUidType.BasicFilmBoxClass)
         UidExclusionList.Add(DicomUidType.BasicGrayscaleImageBoxClass)
         UidExclusionList.Add(DicomUidType.BasicColorImageBoxClass)
         UidExclusionList.Add(DicomUidType.BasicGrayscalePrintMetaClass)
         UidExclusionList.Add(DicomUidType.PrintJobClass)
         UidExclusionList.Add(DicomUidType.BasicAnnotationBoxClass)
         UidExclusionList.Add(DicomUidType.PrinterClass)
         UidExclusionList.Add(DicomUidType.PrinterInstance)
         UidExclusionList.Add(DicomUidType.BasicColorPrintMetaClass)
         UidExclusionList.Add(DicomUidType.PresentationLutClass)
         UidExclusionList.Add(DicomUidType.PrintQueueInstance)
         UidExclusionList.Add(DicomUidType.PrintQueueClass)
         UidExclusionList.Add(DicomUidType.StoredPrintStorageClass)
         UidExclusionList.Add(DicomUidType.HardcopyGrayscaleImageStorageClass)
         UidExclusionList.Add(DicomUidType.HardcopyColorImageStorageClass)
         UidExclusionList.Add(DicomUidType.PullPrintRequestClass)
         UidExclusionList.Add(DicomUidType.PullStoredPrintMetaClass)
         'UidExclusionList.Add(DicomUidType.UID_GE_MAGNETIC_RESONANCE_IMAGE_INFORMATION_OBJECT);
         'UidExclusionList.Add(DicomUidType.UID_GE_COMPUTED_TOMOGRAPHY_IMAGE_INFORMATION_OBJECT);
         UidExclusionList.Add(DicomUidType.GeDisplayImagermation)
         UidExclusionList.Add(DicomUidType.GeArmMigration)
         UidExclusionList.Add(DicomUidType.GeArmMigrationInstance)

         UidExclusionList.Add(DicomUidType.JPEGExtended3_5)
         UidExclusionList.Add(DicomUidType.JPEGSpectralNonhier6_8)
         UidExclusionList.Add(DicomUidType.JPEGSpectralNonhier7_9)
         UidExclusionList.Add(DicomUidType.JPEGFullNonhier10_12)
         UidExclusionList.Add(DicomUidType.JPEGFullNonhier11_13)
         UidExclusionList.Add(DicomUidType.JPEGLosslessNonhier15)
         UidExclusionList.Add(DicomUidType.JPEGExtendedHier16_18)
         UidExclusionList.Add(DicomUidType.JPEGExtendedHier17_19)
         UidExclusionList.Add(DicomUidType.JPEGSpectralHier20_22)
         UidExclusionList.Add(DicomUidType.JPEGSpectralHier21_23)
         UidExclusionList.Add(DicomUidType.JPEGFullHier24_26)
         UidExclusionList.Add(DicomUidType.JPEGFullHier25_27)
         UidExclusionList.Add(DicomUidType.JPEGLosslessHierProcess28)
         UidExclusionList.Add(DicomUidType.JPEGLosslessHierProcess29)
         UidExclusionList.Add(DicomUidType.JPEGLSLossless)
         UidExclusionList.Add(DicomUidType.JPEGLSLossy)
      End Sub

      Public Overloads Function Listen() As DicomExceptionCode
         Dim ret As DicomExceptionCode = DicomExceptionCode.Success

            Try
#If (LEADTOOLS_V17_OR_LATER) Then
                Listen(_IPAddress, _Port, _Peers, _ipType)
#Else
			Listen(_IPAddress, _Port, _Peers)
#End If
                If _IPAddress.Length = 0 Then
                    _IPAddress = HostAddress
            End If
            mf.Log("Startup", "Server started")
         Catch de As DicomException
            mf.Log("Startup", "Error starting server: " & de.Code.ToString())
            ret = de.Code
         End Try

         Return ret
      End Function

      Protected Overrides Sub OnAccept(ByVal [error] As DicomExceptionCode)
         Dim client As Client = Nothing
         If [error] = DicomExceptionCode.Success Then
            If IsSecure = True Then
               client = New Client(Me, False)
               If Not client Is Nothing Then
                  'Require and verify a client certificate.
                  'Support SSL version 3 or TLS Version 1 for the handshake.
                  'Use trusted certificate authority file to verify the client certificate
                  'Verify the client certificate chain to a maximum depth of 2.
                  Dim settings As DicomOpenSslContextCreationSettings = New DicomOpenSslContextCreationSettings(DicomSslMethodType.SslV23,
                   _certificationAuthoritiesFileName,
                   DicomOpenSslVerificationFlags.Peer Or DicomOpenSslVerificationFlags.FailIfNoPeerCertificate,
                   2,
                   DicomOpenSslOptionsFlags.NoSslV2 Or DicomOpenSslOptionsFlags.AllBugWorkarounds)
#If Not LEADTOOLS_V20_OR_LATER Then
                  client.Initialize(Nothing, DicomNetSecurityeMode.Tls, settings)
#Else
                  client.Initialize(Nothing, DicomNetSecurityMode.Tls, settings)
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then

                  client.SetTlsCipherSuiteByIndex(0, DicomTlsCipherSuiteType.DheRsaWithDesCbcSha)
                  client.SetTlsCipherSuiteByIndex(1, DicomTlsCipherSuiteType.DheRsaWith3DesEdeCbcSha)
                  client.SetTlsCipherSuiteByIndex(2, DicomTlsCipherSuiteType.DheRsaAes256Sha)

#If LEADTOOLS_V20_OR_LATER Then
                  ' TLS 1.0
                  client.SetTlsCipherSuiteByIndex(3, DicomTlsCipherSuiteType.RsaWithAes128CbcSha)
                  client.SetTlsCipherSuiteByIndex(4, DicomTlsCipherSuiteType.RsaWith3DesEdeCbcSha)

                  ' TLS 1.2
                  client.SetTlsCipherSuiteByIndex(5, DicomTlsCipherSuiteType.DheRsaWithAes128GcmSha256)
                  client.SetTlsCipherSuiteByIndex(6, DicomTlsCipherSuiteType.EcdheRsaWithAes128GcmSha256)
                  client.SetTlsCipherSuiteByIndex(7, DicomTlsCipherSuiteType.DheRsaWithAes256GcmSha384)
                  client.SetTlsCipherSuiteByIndex(8, DicomTlsCipherSuiteType.EcdheRsaWithAes256GcmSha384)
#End If ' #if LEADTOOLS_V20_OR_LATER

                  client.SetTlsClientCertificate(_serverPEM, DicomTlsCertificateType.Pem, Nothing)
               End If
            Else
               client = New Client(Me)
            End If

            Try
               Accept(client)
            Catch ex As Exception
               mf.Log("Connect", String.Format("Connection rejected : {0}", ex.Message))
               client.Close()
               Return
            End Try

            If Clients.ContainsKey(client.PeerAddress) = False Then
               Clients.Add(client.PeerAddress, client)
            Else
               mf.Log("Connect", "Connection rejected.  IP already connected: " + client.PeerAddress)
               client.Close()
               client.Dispose()
               Return
            End If

            If Clients.Count > _Peers Then
               mf.Log("Connect", "Connection rejected. Max connections reached")
               client.Close()
            End If

            If _Verify Then
               If (Not usersDB.FindUser(client.PeerAddress)) Then
                  Clients.Remove(client.PeerAddress)
                  client.Close()
                  mf.Log("Connect", "Connection rejected.  Unknown User: " & client.PeerAddress)
                  client.Dispose()
                  Return
               End If
            End If

            mf.AddClient(client, DateTime.Now)
            mf.Log("Connect", "Accepted")
         End If
      End Sub

      Protected Overrides Sub OnClose(ByVal [error] As DicomExceptionCode, ByVal net As DicomNet)
         If Clients.ContainsKey(net.PeerAddress) Then
            Dim client As Client = Clients(net.PeerAddress)

            mf.RemoveClient(client)
                Clients.Remove(net.PeerAddress)
                client.Terminate()
                client.Dispose()
          Else
            Try
               net.Dispose()
            Catch ex As Exception
               mf.Log("Exception while disposing object", ex.Message)
            End Try
         End If
      End Sub

      ''' <summary>
      ''' Forcefully close a client connection.
      ''' </summary>
      ''' <param name="hClient">Client network handle.</param>
      Public Sub CloseClient(ByVal client As Client)
         '
         ' Remove client from list
         '
         Clients.Remove(client.PeerAddress)
         client.SendAbort(DicomAbortSourceType.Provider, DicomAbortReasonType.Unknown)
         client.CloseForced(True)

         If Not client.Association Is Nothing Then
            mf.Log("Timeout", "Connection closed: " & client.Association.Calling)
         Else
            mf.Log("Timeout", "Connection closed: " & client.PeerAddress)
         End If

         client.Dispose()
      End Sub

      Public Function InitAction(ByVal actionOp As String, ByVal process As ProcessType, ByVal client As Client, ByVal ds As DicomDataSet) As DicomAction
         Dim action As DicomAction = New DicomAction(process, Me, client, ds)

         action.AETitle = client.Association.Calling
         action.ipAddress = client.PeerAddress
         mf.EnableTimer(client, action.AETitle, False)
         mf.UpdateClient(client, "", actionOp)
         AddHandler action.ActionComplete, AddressOf action_ActionComplete

         If ds IsNot Nothing AndAlso SaveDSReceived AndAlso (Not Logger.DisableLogging) Then
            Dim file As String

            file = LogDS(process.ToString(), client, ds)
            mf.Log(actionOp, "Received from " & action.AETitle, file)
         Else
            mf.Log(actionOp, "Received from " & action.AETitle)
         End If

         Return action
      End Function

      Private Sub action_ActionComplete(ByVal sender As Object, ByVal e As EventArgs)
         Dim action As DicomAction = CType(sender, DicomAction)

         mf.EnableTimer(action.Client, action.AETitle, True)
      End Sub

      Private Function GetLogDir(ByVal AETitle As String) As String
         Dim dir As String = LogDir & AETitle & "\"

         If (Not Directory.Exists(dir)) Then
            Directory.CreateDirectory(dir)
         End If
         Return dir
      End Function

      Public Sub LogCS(ByVal client As Client, ByVal ds As DicomDataSet)
         Dim ui As UserInfo

         ui = mf.UsersData.LoadUser(client.PeerAddress, client.Association.Calling)
         If Not ui Is Nothing Then
            Dim dir As String = GetLogDir(client.Association.Calling)
            Dim file As String
            Dim command As String

            '
            ' File name is of the following form for command sets.
            '  cs.hNet-Command-UniqueId.dcm
            '

            command = ds.InformationCommand.ToString()
            command = command.Remove(0, command.IndexOf("_") + 1)
            command = command.Replace("_", "-")
            file = dir & "cs." & client.Association.Calling & "-" & command & "-REQ"
            file &= "-" & Environment.TickCount.ToString() & ".dcm"
            ds.Save(file, DicomDataSetSaveFlags.None)
         End If
      End Sub

      Public Sub DoAssociateRequest(ByVal client As Client, ByVal association As DicomAssociate)
         Using retAssociate As DicomAssociate = New DicomAssociate(False)
            If retAssociate Is Nothing Then
               client.SendAssociateReject(DicomAssociateRejectResultType.Permanent, DicomAssociateRejectSourceType.Provider1, DicomAssociateRejectReasonType.Application)
               Return
            End If

                retAssociate.MaxLength = 46726
            retAssociate.Version = 1
            retAssociate.Called = CalledAE
            If (CallingAE Is Nothing) Then
               retAssociate.Calling = association.Calling
            Else
               retAssociate.Calling = CallingAE
            End If
            retAssociate.ApplicationContextName = CStr(DicomUidType.ApplicationContextName)

            Dim i As Integer = 0
            Do While i < association.PresentationContextCount
               Dim id As Byte = association.GetPresentationContextID(i)
               Dim abstractSyntax As String = association.GetAbstract(id)

               retAssociate.AddPresentationContext(id, DicomAssociateAcceptResultType.Success, abstractSyntax)
               If IsSupported(abstractSyntax) Then
                  Dim j As Integer = 0
                  Do While j < association.GetTransferCount(id)
                     Dim transferSyntax As String = association.GetTransfer(id, j)

                     If IsSupported(transferSyntax) Then
                        retAssociate.AddTransfer(id, transferSyntax)
                        Exit Do
                     End If
                     j += 1
                  Loop

                  If retAssociate.GetTransferCount(id) = 0 Then
                     '
                     ' Presentation id doesn't have any abstract
                     '  syntaxes therefore we will reject it.
                     '
                     retAssociate.SetResult(id, DicomAssociateAcceptResultType.AbstractSyntax)
                  End If
               Else
                  retAssociate.SetResult(id, DicomAssociateAcceptResultType.AbstractSyntax)
               End If
               i += 1
            Loop

            If association.MaxLength <> 0 Then
               retAssociate.MaxLength = association.MaxLength
            End If

            retAssociate.ImplementClass = ImplementationClass
            retAssociate.ImplementationVersionName = ImplementationVersionName

            client.SendAssociateAccept(retAssociate)
         End Using
      End Sub

      Public Function LogDS(ByVal command As String, ByVal client As Client, ByVal ds As DicomDataSet) As String
         Dim ui As UserInfo
         Dim file As String = ""

         ui = mf.UsersData.LoadUser(client.PeerAddress, client.Association.Calling)
         If Not ui Is Nothing Then
            Dim dir As String = GetLogDir(client.Association.Calling)

            '
            ' File name is of the following form for command sets.
            '  ds.CallingAE-Command-UniqueId.dcm
            '				
            file = dir & "ds." & client.Association.Calling & "-" & command
            file &= "-" & Environment.TickCount.ToString() & ".dcm"
            ds.Save(file, DicomDataSetSaveFlags.None)

         End If
         Return file
      End Function
   End Class
End Namespace
