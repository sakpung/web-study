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

Namespace DicomDemo


   ''' <summary>
   ''' Summary description for Server.
   ''' </summary>
   Public Class Server : Inherits Scp
	  Private _Port As Integer = 104
	  Private _Peers As Integer = 5
	  Private _IPAddress As String = ""
	  Private _Timeout As Integer = 1
	  Private _Clients As Dictionary(Of String, Client) = New Dictionary(Of String, Client)()

	  Public mf As MainForm

	  Private _ExitEvent As AutoResetEvent = New AutoResetEvent(False)

	  #Region "Properties"

	  Public Property Port() As Integer
		 Get
			Return _Port
		 End Get
		 Set
			_Port = Value
		 End Set
	  End Property

	  Public Property Peers() As Integer
		 Get
			Return _Peers
		 End Get
		 Set
			_Peers = Value
		 End Set
	  End Property

	  Public ReadOnly Property ExitEvent() As AutoResetEvent
		 Get
			Return _ExitEvent
		 End Get
	  End Property

	  Public Property IPAddress() As String
		 Get
			Return _IPAddress
		 End Get
		 Set
			_IPAddress = Value
		 End Set
	  End Property

	  Public Property Timeout() As Integer
		 Get
			Return _Timeout
		 End Get
		 Set
			_Timeout = Value
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
		 BuildExclusionList()
	  End Sub

	  '
	   '* Builds a UID exclusion list for the server.
	   '
	  Private Sub BuildExclusionList()
		  'This list has ALL of the UIDs and the ones the server SUPPORTS are commented out
			'UidExclusionList.Add(DicomUidType.VerificationClass);
			UidExclusionList.Add(DicomUidType.MediaStorageDirectory)
			UidExclusionList.Add(DicomUidType.BasicStudyNotificationClass)
			UidExclusionList.Add(DicomUidType.StorageCommitmentPushModelClass)
			UidExclusionList.Add(DicomUidType.StorageCommitmentPullModelClass)
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
			UidExclusionList.Add(DicomUidType.ReferencedImageBoxClassRetired)
			UidExclusionList.Add(DicomUidType.BasicGrayscalePrintMetaClass)
			UidExclusionList.Add(DicomUidType.ReferencedGrayscalePrintMetaClassRetired)
			UidExclusionList.Add(DicomUidType.PrintJobClass)
			UidExclusionList.Add(DicomUidType.BasicAnnotationBoxClass)
			UidExclusionList.Add(DicomUidType.PrinterClass)
			UidExclusionList.Add(DicomUidType.PrinterConfigurationRetrievalClass)
			UidExclusionList.Add(DicomUidType.BasicColorPrintMetaClass)
			UidExclusionList.Add(DicomUidType.ReferencedColorPrintMetaClassRetired)
			UidExclusionList.Add(DicomUidType.VoiLutBoxClassRetired)
			UidExclusionList.Add(DicomUidType.PresentationLutClass)
			UidExclusionList.Add(DicomUidType.ImageOverlayBoxClassRetired)
			UidExclusionList.Add(DicomUidType.BasicPrintImageOverlayBoxClass)
			UidExclusionList.Add(DicomUidType.PrintQueueClass)
			UidExclusionList.Add(DicomUidType.StoredPrintStorageClass)
			UidExclusionList.Add(DicomUidType.HardcopyGrayscaleImageStorageClass)
			UidExclusionList.Add(DicomUidType.HardcopyColorImageStorageClass)
			UidExclusionList.Add(DicomUidType.PullPrintRequestClass)
			UidExclusionList.Add(DicomUidType.PullStoredPrintMetaClass)
			UidExclusionList.Add(DicomUidType.CRImageStorage)
			UidExclusionList.Add(DicomUidType.DXImageStoragePresentation)
			UidExclusionList.Add(DicomUidType.DXImageStorageProcessing)
			UidExclusionList.Add(DicomUidType.DXMammographyImageStoragePresentation)
			UidExclusionList.Add(DicomUidType.DXMammographyImageStorageProcessing)
			UidExclusionList.Add(DicomUidType.DXIntraoralImageStoragePresentation)
			UidExclusionList.Add(DicomUidType.DXIntraoralImageStorageProcessing)
			UidExclusionList.Add(DicomUidType.CTImageStorage)
			UidExclusionList.Add(DicomUidType.USMultiframeImageStorageRetired)
			UidExclusionList.Add(DicomUidType.USMultiframeImageStorage)
			UidExclusionList.Add(DicomUidType.MRImageStorage)
			UidExclusionList.Add(DicomUidType.EnhancedMRImageStorage)
			UidExclusionList.Add(DicomUidType.MRSpectroscopyStorage)
			UidExclusionList.Add(DicomUidType.NMImageStorageRetired)
			UidExclusionList.Add(DicomUidType.USImageStorageRetired)
			UidExclusionList.Add(DicomUidType.USImageStorage)
			UidExclusionList.Add(DicomUidType.SCImageStorage)
			UidExclusionList.Add(DicomUidType.SCMultiFrameSingleBitImageStorage)
			UidExclusionList.Add(DicomUidType.SCMultiFrameGrayscaleByteImageStorage)
			UidExclusionList.Add(DicomUidType.SCMultiFrameGrayscaleWordImageStorage)
			UidExclusionList.Add(DicomUidType.SCMultiFrameTrueColorImageStorage)
			UidExclusionList.Add(DicomUidType.StandaloneOverlayStorage)
			UidExclusionList.Add(DicomUidType.StandaloneCurveStorage)
			UidExclusionList.Add(DicomUidType.TwleveLeadECGWaveformStorage)
			UidExclusionList.Add(DicomUidType.GeneralECGWaveformStorage)
			UidExclusionList.Add(DicomUidType.AmbulatoryECGWaveformStorage)
			UidExclusionList.Add(DicomUidType.HemodynamicWaveformStorage)
			UidExclusionList.Add(DicomUidType.CardiacElectrophysiologyWaveformStorage)
			UidExclusionList.Add(DicomUidType.BasicVoiceAudioWaveformStorage)
			UidExclusionList.Add(DicomUidType.StandaloneModalityLutStorage)
			UidExclusionList.Add(DicomUidType.StandaloneVoiLutStorage)
			UidExclusionList.Add(DicomUidType.GrayscaleSoftcopyPresentationStateStorage)
			UidExclusionList.Add(DicomUidType.XAImageStorage)
			UidExclusionList.Add(DicomUidType.XRayRadiofluoroscopicImageStorage)
			UidExclusionList.Add(DicomUidType.XABiplaneImageStorageRetired)
			UidExclusionList.Add(DicomUidType.NMImageStorage)
			UidExclusionList.Add(DicomUidType.RawDataStorage)
			UidExclusionList.Add(DicomUidType.VLImageStorageRetired)
			UidExclusionList.Add(DicomUidType.VLMultiframeImageStorageRetired)
			UidExclusionList.Add(DicomUidType.VLEndoscopicImageStorageClass)
			UidExclusionList.Add(DicomUidType.VideoEndoscopicImageStorage)
			UidExclusionList.Add(DicomUidType.VLMicroscopicImageStorageClass)
			UidExclusionList.Add(DicomUidType.VideoMicroscopicImageStorage)
			UidExclusionList.Add(DicomUidType.VLSlideCoordinatesMicroscopicImageStorageClass)
			UidExclusionList.Add(DicomUidType.VLPhotographicImageStorageClass)
			UidExclusionList.Add(DicomUidType.VideoPhotographicImageStorage)
			UidExclusionList.Add(DicomUidType.Ophthalmic8BitPhotographyImageStorage)
			UidExclusionList.Add(DicomUidType.Ophthalmic16BitPhotographyImageStorage)
			UidExclusionList.Add(DicomUidType.StereometricRelationshipStorage)
			UidExclusionList.Add(DicomUidType.BasicTextSR)
			UidExclusionList.Add(DicomUidType.EnhancedSR)
			UidExclusionList.Add(DicomUidType.ComprehensiveSR)
			UidExclusionList.Add(DicomUidType.MammographyCadSR)
			UidExclusionList.Add(DicomUidType.KeyObjectSelectionDocument)
			UidExclusionList.Add(DicomUidType.ChestCadSR)
			UidExclusionList.Add(DicomUidType.PETImageStorage)
			UidExclusionList.Add(DicomUidType.StandalonePETCurveStorage)
			UidExclusionList.Add(DicomUidType.RTImageStorage)
			UidExclusionList.Add(DicomUidType.RTDoseStorage)
			UidExclusionList.Add(DicomUidType.RTStructureStorage)
			UidExclusionList.Add(DicomUidType.RTBeamsTreatmentRecordStorageClass)
			UidExclusionList.Add(DicomUidType.RTPlanStorage)
			UidExclusionList.Add(DicomUidType.RTBrachyTreatmentRecordStorageClass)
			UidExclusionList.Add(DicomUidType.RTTreatmentSummaryRecordStorageClass)
			UidExclusionList.Add(DicomUidType.PatientRootQueryFind)
			UidExclusionList.Add(DicomUidType.PatientRootQueryMove)
			UidExclusionList.Add(DicomUidType.PatientRootQueryGet)
			UidExclusionList.Add(DicomUidType.StudyRootQueryFind)
			UidExclusionList.Add(DicomUidType.StudyRootQueryMove)
			UidExclusionList.Add(DicomUidType.StudyRootQueryGet)
			UidExclusionList.Add(DicomUidType.PatientStudyQueryFind)
			UidExclusionList.Add(DicomUidType.PatientStudyQueryMove)
			UidExclusionList.Add(DicomUidType.PatientStudyQueryGet)
			'UidExclusionList.Add(DicomUidType.ModalityWorklistFind);
			UidExclusionList.Add(DicomUidType.GeneralPurposeWorklistFind)
			UidExclusionList.Add(DicomUidType.GeneralPurposeScheduledProcedureStepSopClass)
			UidExclusionList.Add(DicomUidType.GeneralPurposePerformedProcedureStepSopClass)
			UidExclusionList.Add(DicomUidType.GeneralPurposeWorklistManagementMetaSopClass)
	  End Sub

	  '
	   '* Establishes a connection to listen for incoming connection requests.
	   '
      Public Overloads Function Listen() As DicomExceptionCode
         Dim ret As DicomExceptionCode = DicomExceptionCode.Success

         Try
            Listen(_IPAddress, _Port, _Peers)
            If _IPAddress.Length = 0 Then
               _IPAddress = HostAddress
            End If
         Catch de As DicomException
            ret = de.Code
         End Try

         Return ret
      End Function

	  '
	   '* Notifies a listening connection (SCP) that it can accept pending connection requests.
	   '
	  Protected Overrides Sub OnAccept(ByVal [error] As DicomExceptionCode)
		 Dim client As Client = Nothing
         If [error] = DicomExceptionCode.Success Then
            client = New Client(Me)

            Accept(client)

            If (Not Clients.ContainsKey(client.PeerAddress)) Then
               Clients.Add(client.PeerAddress, client)
            Else
               mf.Log("Connection attempted by " & client.PeerAddress & " was rejected because that IP is already connected" & Constants.vbCrLf)
               Clients.Remove(client.PeerAddress)
               client.Close()
               client.Dispose()
               Return
            End If

            If Clients.Count > _Peers Then
               mf.Log("Connection attempted by " & client.PeerAddress & " was rejected because the Maximum connections has already been reached" & Constants.vbCrLf)
               Clients.Remove(client.PeerAddress)
               client.Close()
               client.Dispose()
               Return
            End If

            If (Not VerifyUserIP(client.PeerAddress)) Then
               mf.Log("Connection attempted by " & client.PeerAddress & " was rejected because the client's IP address is not valid." & Constants.vbCrLf)
               Clients.Remove(client.PeerAddress)
               client.Close()
               client.Dispose()
               Return
            End If

            mf.Log("***  Last client connected: ClientAddress[" & client.PeerAddress & "], ClientPort[" & client.PeerPort & "]" & Constants.vbCrLf)
         End If
	  End Sub

	  '
	   '* Notifies a member of a connection that the connection was closed.
	   '
	  Protected Overrides Sub OnClose(ByVal [error] As DicomExceptionCode, ByVal net As DicomNet)
		 If Clients.ContainsKey(net.PeerAddress) Then
			Dim client As Client = Clients(net.PeerAddress)

         Clients.Remove(net.PeerAddress)
         client.Dispose()
      Else
         net.Dispose()
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
			 mf.Log("CLIENT NAME: " & client.Association.Calling & " -- Timeout")
		 Else
			 mf.Log("CLIENT NAME: " & client.PeerAddress & " -- Timeout")
       End If

      client.Dispose()
	  End Sub

	  '
	   '* Initializes an incoming action.
	   '
	  Public Function InitAction(ByVal actionOp As String, ByVal process As ProcessType, ByVal client As Client, ByVal ds As DicomDataSet) As DicomAction
		 Dim action As DicomAction = New DicomAction(process, Me, client, ds)

		 action.AETitle = client.Association.Calling
		 action.ipAddress = client.PeerAddress
		 AddHandler action.ActionComplete, AddressOf action_ActionComplete

		 Return action
	  End Function

	  Private Sub action_ActionComplete(ByVal sender As Object, ByVal e As EventArgs)
		 Dim action As DicomAction = CType(sender, DicomAction)
	  End Sub

	  '
	   '* Performs an Association request
	   '
	  Public Sub DoAssociateRequest(ByVal client As Client, ByVal association As DicomAssociate)
		  mf.Log("Client Name: " & association.Calling & " -- Receiving Associate Request." & Constants.vbCrLf)

		  ' Check association
		  If association Is Nothing Then
            client.SendAssociateReject(DicomAssociateRejectResultType.Permanent, DicomAssociateRejectSourceType.Provider1, DicomAssociateRejectReasonType.Application)
			  mf.Log("Client Name: " & association.Calling & " -- Failed in accepting the connection (Associate was null)!" & Constants.vbCrLf & "Sending associate reject!" & Constants.vbCrLf)
			  Return
		  End If

		  ' Check version
		  If association.Version <> 1 Then
            client.SendAssociateReject(DicomAssociateRejectResultType.Permanent, DicomAssociateRejectSourceType.Provider1, DicomAssociateRejectReasonType.Version)
			  mf.Log("Client Name: " & association.Calling & " -- Failed in accepting the connection (Version Not supported)!" & Constants.vbCrLf & "Sending associate reject!" & Constants.vbCrLf)
			  Return
		  End If

		  ' Make sure that the client is supported
		  If (Not VerifyUserName(association.Calling)) Then
            client.SendAssociateReject(DicomAssociateRejectResultType.Permanent, DicomAssociateRejectSourceType.User, DicomAssociateRejectReasonType.Calling)
			  mf.Log("Client Name: " & association.Calling & " -- Failed in accepting the connection (Not a valid client name)!" & Constants.vbCrLf & "Sending associate reject!" & Constants.vbCrLf)
			  Return
		  End If

		  ' Check the Called AE title (SCP)
		  If association.Called <> CalledAE Then
            client.SendAssociateReject(DicomAssociateRejectResultType.Permanent, DicomAssociateRejectSourceType.User, DicomAssociateRejectReasonType.Called)
			  mf.Log("Client Name: " & association.Calling & " -- Failed in accepting the connection (Server names are not the same)!" & Constants.vbCrLf & " Sending associate reject!" & Constants.vbCrLf)
			  Return
		  End If

		  ' Send association back
'		 using(DicomAssociate retAssociate = New DicomAssociate(False))
		 Dim retAssociate As DicomAssociate = New DicomAssociate(False)
            Try
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
                            ' Presentation id doesn't have any abstract syntaxes therefore we will reject it.
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
                mf.Log("Client Name: " & association.Calling & " -- Sending Associate Accept." & Constants.vbCrLf)
            Finally
                CType(retAssociate, IDisposable).Dispose()
            End Try
	  End Sub

	  '
	   '* Makes sure that the user's name attempting to associate is valid
	   '
	  Private Function VerifyUserName(ByVal CallingName As String) As Boolean
		  Dim bRet As Boolean

		  If mf.lstClients.Items.Count > 0 Then
			  bRet = False
			  Dim i As Integer = 0
			  Do While i < mf.lstClients.Items.Count
				  If mf.lstClients.Items(i).SubItems(0).Text = CallingName Then
					  Return True
				  End If
				  i += 1
			  Loop
		  Else
			  bRet = True
		  End If

		  Return bRet
	  End Function

	  '
	   '* Makes sure that the user's IP attempting to connect is valid
	   '
	  Private Function VerifyUserIP(ByVal CallingIP As String) As Boolean
		  Dim bRet As Boolean

		  If mf.lstClients.Items.Count > 0 Then
			  bRet = False
			  Dim i As Integer = 0
			  Do While i < mf.lstClients.Items.Count
				  If mf.lstClients.Items(i).SubItems(1).Text = CallingIP Then
					  Return True
				  End If
				  i += 1
			  Loop
		  Else
			  bRet = True
		  End If

		  Return bRet
	  End Function
   End Class
End Namespace
