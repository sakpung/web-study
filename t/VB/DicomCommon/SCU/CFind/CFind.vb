' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Threading
Imports System.Text
Imports System.ComponentModel

Imports Leadtools
Imports Leadtools.Dicom
Imports Leadtools.DicomDemos
Imports Leadtools.DicomDemos.Scu
Imports Leadtools.DicomDemos.Scp

Namespace Leadtools.DicomDemos.Scu.CFind
   Public Class FindCompleteEventArgs : Inherits EventArgs
      Friend _Datasets As DicomDataSetCollection
      Friend _Type As FindType

      ''' <summary>
      ''' 
      ''' </summary>
      Public Sub New()
      End Sub

      Public ReadOnly Property Datasets() As DicomDataSetCollection
         Get
            Return _Datasets
         End Get
      End Property

      Public ReadOnly Property Type() As FindType
         Get
            Return _Type
         End Get
      End Property
   End Class

   Public Class MoveCompleteEventArgs : Inherits EventArgs
      Friend _Datasets As DicomDataSetCollection
      'internal FindType _Type;

      ''' <summary>
      ''' 
      ''' </summary>
      Public Sub New()
      End Sub

      Public ReadOnly Property Datasets() As DicomDataSetCollection
         Get
            Return _Datasets
         End Get
      End Property

      'public FindType Type
      '{
      'get
      '{
      'return _Type;
      '}
      '}
   End Class

   Public Delegate Sub FindCompleteEventHandler(ByVal sender As Object, ByVal e As FindCompleteEventArgs)
   Public Delegate Sub MoveCompleteEventHandler(ByVal sender As Object, ByVal e As MoveCompleteEventArgs)

   ''' <summary>
   ''' 
   ''' </summary>
   Public Class CFindQuery
      Private _PatientName As String
      Private _PatientID As String
      Private _StudyID As String
      Private _StudyInstanceUid As String
      Private _AccessionNo As String
      Private _ReferringPhysiciansName As String
      Private _StudyStart As DateTime
      Private _StudyEnd As DateTime
      Public Sub New()
         _PatientName = ""
         _PatientID = ""
         _StudyID = ""
         _StudyInstanceUid = ""
         _AccessionNo = ""
         _ReferringPhysiciansName = ""
         _StudyStart = DateTime.MinValue
         _StudyEnd = DateTime.MinValue
      End Sub

      <Category("Patient"), Description("Patient name")> _
      Public Property PatientName() As String
         Get
            Return _PatientName
         End Get
         Set(ByVal value As String)
            _PatientName = Value
         End Set
      End Property

      <Category("Patient"), Description("Patient id")> _
      Public Property PatientID() As String
         Get
            Return _PatientID
         End Get
         Set(ByVal value As String)
            _PatientID = Value
         End Set
      End Property

      <Category("Study"), Description("Study id")> _
      Public Property StudyID() As String
         Get
            Return _StudyID
         End Get
         Set(ByVal value As String)
            _StudyID = Value
         End Set
      End Property

      	  <Category("Study"), Description("Study instance uid"), Browsable(False)> _
      Public Property StudyInstanceUid() As String
         Get
            Return _StudyInstanceUid
         End Get
         Set(ByVal value As String)
            _StudyInstanceUid = Value
         End Set
      End Property

      <Category("Study"), Description("Accession number")> _
      Public Property AccessionNo() As String
         Get
            Return _AccessionNo
         End Get
         Set(ByVal value As String)
            _AccessionNo = Value
         End Set
      End Property

      <Category("Study"), Description("Referring doctor's name")> _
      Public Property ReferringPhysiciansName() As String
         Get
            Return _ReferringPhysiciansName
         End Get
         Set(ByVal value As String)
            _ReferringPhysiciansName = Value
         End Set
      End Property

      <Category("Study"), Description("Study start date")> _
      Public Property StudyStartDate() As DateTime
         Get
            Return _StudyStart
         End Get
         Set(ByVal value As DateTime)
            _StudyStart = Value
         End Set
      End Property

      <Category("Study"), Description("Study end date")> _
      Public Property StudyEndDate() As DateTime
         Get
            Return _StudyEnd
         End Get
         Set(ByVal value As DateTime)
            _StudyEnd = Value
         End Set
      End Property
   End Class

   ''' <summary>
   ''' Type of query retrieve level.
   ''' </summary>
   Public Enum FindType
      Patient '/ Patient
      PatientSeries '/ Patient Series
      Study '/ Study
      StudySeries '/ Study Series
   End Enum

   ''' <summary>
   ''' This class communicate with the SCP.  The SCP will communicate with
   ''' use when we send a C-MOVE-REQUEST.  This class is used to respond
   ''' to the C-FIND-REQUEST.
   ''' </summary>
   Public Class CFindClient : Inherits DicomNet
      Private server As CFindSCP

#If Not LEADTOOLS_V20_OR_LATER Then
      Public Sub New(ByVal server As CFindSCP)
         MyBase.New(Nothing, DicomNetSecurityeMode.None)
         Me.server = server
      End Sub
#Else
      Public Sub New(ByVal server As CFindSCP)
         MyBase.New(Nothing, DicomNetSecurityMode.None)
         Me.server = server
      End Sub
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then

      Protected Overrides Sub OnReceiveAssociateRequest(ByVal association As DicomAssociate)
         server.cfind.InvokeStatusEvent(StatusType.ReceiveAssociateRequest, DicomExceptionCode.Success, association.Calling, association.Called)
         server.DoAssociateRequest(Me, association)
      End Sub

      Protected Overrides Sub OnReceiveCStoreRequest(ByVal presentationID As Byte, ByVal messageID As Integer, ByVal affectedClass As String, ByVal instance As String, ByVal priority As DicomCommandPriorityType, ByVal moveAE As String, ByVal moveMessageID As Integer, ByVal dataSet As DicomDataSet)
         Dim ds As DicomDataSet = New DicomDataSet()

         server.cfind.ResetTimeoutEvent.Set()

         server.cfind.InvokeStatusEvent(StatusType.ReceiveCStoreRequest, DicomExceptionCode.Success)
         If dataSet Is Nothing Then
            SendCStoreResponse(presentationID, messageID, affectedClass, instance, DicomCommandStatusType.ProcessingFailure)
            Return
         End If

         ds.Copy(dataSet, Nothing, Nothing)
         server.dsCollection.Add(ds)

         server.cfind.InvokeStatusEvent(StatusType.SendCStoreResponse, DicomExceptionCode.Success)
         SendCStoreResponse(presentationID, messageID, affectedClass, instance, DicomCommandStatusType.Success)
         dataSet.Dispose()
      End Sub

      Protected Overrides Sub OnReceiveData(ByVal presentationID As Byte, ByVal cs As Dicom.DicomDataSet, ByVal ds As Dicom.DicomDataSet)
         MyBase.OnReceiveData(presentationID, cs, ds)

         If (cs IsNot Nothing) Then
            cs.Dispose()
         End If
      End Sub
      Protected Overrides Sub OnReceiveReleaseRequest()
         SendReleaseResponse()
      End Sub

   End Class

   Public Class CFindSCP : Inherits Leadtools.DicomDemos.Scp.Scp
      Friend dsCollection As DicomDataSetCollection
      Friend cfind As CFind

      Public Overrides Sub Init()
         MyBase.Init()

         BuildExclusionList()
      End Sub

      Protected Overrides Sub OnAccept(ByVal [error] As DicomExceptionCode)
         If [error] = DicomExceptionCode.Success Then
            Dim client As CFindClient = New CFindClient(Me)

            Accept(client)
         End If
      End Sub

      Public Sub DoAssociateRequest(ByVal client As CFindClient, ByVal association As DicomAssociate)

         Dim retAssociate As DicomAssociate = New DicomAssociate(False)
         Try
            If retAssociate Is Nothing Then
               client.SendAssociateReject(DicomAssociateRejectResultType.Permanent, DicomAssociateRejectSourceType.Provider1, DicomAssociateRejectReasonType.Application)
               Return
            End If

            retAssociate.MaxLength = 46726
            retAssociate.Version = 1
            If (CalledAE Is Nothing) Then
               retAssociate.Called = association.Called
            Else
               retAssociate.Called = CalledAE
            End If
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
         Finally
            CType(retAssociate, IDisposable).Dispose()
         End Try

      End Sub

      Protected Overrides Sub OnClose(ByVal [error] As DicomExceptionCode, ByVal net As DicomNet)
         MyBase.OnClose([error], net)
         net.Dispose()
      End Sub

      Private Sub BuildExclusionList()
         UidExclusionList.Add(DicomUidType.BasicStudyNotificationClass)
         UidExclusionList.Add(DicomUidType.ApplicationContextName)
         UidExclusionList.Add(DicomUidType.ModalityPerformedClass)
         UidExclusionList.Add(DicomUidType.ModalityPerformedRetrieveClass)
         UidExclusionList.Add(DicomUidType.ModalityPerformedNotificationClass)
         UidExclusionList.Add(DicomUidType.BasicFilmSessionClass)
         UidExclusionList.Add(DicomUidType.BasicFilmBoxClass)
         UidExclusionList.Add(DicomUidType.BasicGrayscaleImageBoxClass)
         UidExclusionList.Add(DicomUidType.BasicColorImageBoxClass)
         UidExclusionList.Add(DicomUidType.BasicGrayscalePrintMetaClass)
         UidExclusionList.Add(DicomUidType.PrintJobClass)
         UidExclusionList.Add(DicomUidType.BasicAnnotationBoxClass)
         UidExclusionList.Add(DicomUidType.PrinterClass)
         UidExclusionList.Add(DicomUidType.PrinterConfigurationRetrievalClass)
         UidExclusionList.Add(DicomUidType.PrinterInstance)
         UidExclusionList.Add(DicomUidType.PrinterConfigurationRetrievalInstance)
         UidExclusionList.Add(DicomUidType.BasicColorPrintMetaClass)
         UidExclusionList.Add(DicomUidType.PresentationLutClass)
         UidExclusionList.Add(DicomUidType.BasicPrintImageOverlayBoxClass)
         UidExclusionList.Add(DicomUidType.PrintQueueInstance)
         UidExclusionList.Add(DicomUidType.PrintQueueClass)
         UidExclusionList.Add(DicomUidType.PullPrintRequestClass)
         UidExclusionList.Add(DicomUidType.PullStoredPrintMetaClass)
         UidExclusionList.Add(DicomUidType.PatientRootQueryFind)
         UidExclusionList.Add(DicomUidType.PatientRootQueryMove)
         UidExclusionList.Add(DicomUidType.PatientRootQueryGet)
         UidExclusionList.Add(DicomUidType.StudyRootQueryFind)
         UidExclusionList.Add(DicomUidType.StudyRootQueryMove)
         UidExclusionList.Add(DicomUidType.StudyRootQueryGet)
         UidExclusionList.Add(DicomUidType.PatientStudyQueryFind)
         UidExclusionList.Add(DicomUidType.PatientStudyQueryMove)
         UidExclusionList.Add(DicomUidType.PatientStudyQueryGet)
         UidExclusionList.Add(DicomUidType.ModalityWorklistFind)
         UidExclusionList.Add(DicomUidType.Papyrus3ImplicitVRLittleEndian)
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

      Protected Overrides Sub OnReceiveData(ByVal presentationID As Byte, ByVal cs As Dicom.DicomDataSet, ByVal ds As Dicom.DicomDataSet)
         MyBase.OnReceiveData(presentationID, cs, ds)
         If (cs IsNot Nothing) Then
            cs.Dispose()
         End If
      End Sub
   End Class

   ''' <summary>
   ''' Implements a Dicom C-FIND operation. 
   ''' </summary>
   Public Class CFind : Inherits Scu
      Private dsCollection As DicomDataSetCollection = New DicomDataSetCollection()
      Private type As FindType
      Private query As CFindQuery

      ' Move series values
      Private patientID As String
      Private studyInstance As String
      Private seriesInstance As String
      Private clientPort As Integer

#If LEADTOOLS_V17_OR_LATER Then
      Private ipType As DicomNetIpTypeFlags = DicomNetIpTypeFlags.Ipv4
#End If

      ''' <summary>
      ''' C-FIND operation has completed.
      ''' </summary>
      Public Event FindComplete As FindCompleteEventHandler

      ''' <summary>
      ''' C-MOVE operation has completed.
      ''' </summary>
      Public Event MoveComplete As MoveCompleteEventHandler

      Protected Overridable Sub OnFindComplete(ByVal e As FindCompleteEventArgs)
         'LastError = e.Error;
         If Not FindCompleteEvent Is Nothing Then
            ' Invokes the delegates. 
            RaiseEvent FindComplete(Me, e)
         End If
      End Sub

      Protected Overridable Sub OnMoveComplete(ByVal e As MoveCompleteEventArgs)
         If Not MoveCompleteEvent Is Nothing Then
            RaiseEvent MoveComplete(Me, e)
         End If
      End Sub

      Public Sub New()
      End Sub

      Public Overrides Sub Init()
         MyBase.Init()
      End Sub

      Protected Overrides Sub OnReceiveCEchoResponse(ByVal presentationID As Byte, ByVal messageID As Integer, ByVal affectedClass As String, ByVal status As DicomCommandStatusType)
         MyBase.OnReceiveCEchoResponse(presentationID, messageID, affectedClass, status)
      End Sub

      Protected Overrides Sub OnReceiveCFindResponse(ByVal presentationID As Byte, ByVal messageID As Integer, ByVal affectedClass As String, ByVal status As DicomCommandStatusType, ByVal dataSet As DicomDataSet)
         InvokeStatusEvent(StatusType.ReceiveCFindResponse, status)

         Select Case status
            Case DicomCommandStatusType.Success, DicomCommandStatusType.Warning
               Me.Event.Set()
            Case DicomCommandStatusType.Pending, DicomCommandStatusType.PendingWarning
               AddDS(dataSet)
            Case Else
               Me.Event.Set()
         End Select

         If (Nothing IsNot dataSet) Then
            dataSet.Dispose()
         End If
      End Sub

      Protected Overrides Sub OnReceiveCMoveResponse(ByVal presentationID As Byte, ByVal messageID As Integer, ByVal affectedClass As String, ByVal status As DicomCommandStatusType, ByVal remaining As Integer, ByVal completed As Integer, ByVal failed As Integer, ByVal warning As Integer, ByVal dataSet As DicomDataSet)
         InvokeStatusEvent(StatusType.ReceiveCMoveResponse, DicomExceptionCode.Success, completed, remaining, status)
         Select Case status
            Case DicomCommandStatusType.Success, DicomCommandStatusType.Warning
               Me.Event.Set()
            Case DicomCommandStatusType.Pending
               AddDS(dataSet)
            Case Else
               Me.Event.Set()
         End Select
         If (Nothing IsNot dataSet) Then
            dataSet.Dispose()
         End If
      End Sub

      Protected Overrides Sub OnReceiveReleaseResponse()
         InvokeStatusEvent(StatusType.ReceiveReleaseResponse, DicomExceptionCode.Success)
         Close()
         Me.Event.Set()
      End Sub

      Protected Overrides Sub OnReceiveData(ByVal presentationID As Byte, ByVal cs As Dicom.DicomDataSet, ByVal ds As Dicom.DicomDataSet)
         MyBase.OnReceiveData(presentationID, cs, ds)
         If (Nothing IsNot cs) Then
            cs.Dispose()
         End If
      End Sub

      ''' <summary>
      ''' Sends a find request to the specified server.
      ''' </summary>
      ''' <param name="server">Server to send the find request to.</param>
      ''' <param name="type">Type of query.</param>
      ''' <param name="query">Query information.</param>
      ''' <param name="AETitle">Calling aetitle.</param>
      Public Sub Find(ByVal server As DicomServer, ByVal type As FindType, ByVal query As CFindQuery, ByVal AETitle As String)
         Dim ret As DicomExceptionCode

         Me.type = type
         Me.query = query

         dsCollection.Clear()
         ret = Associate(server, AETitle, New SCUProcessFunc(AddressOf FindProcess))
         If ret <> DicomExceptionCode.Success Then
            'MessageBox.Show("Error during association: ",ret.ToString());
            Return
         End If
      End Sub

      ''' <summary>
      ''' Performs a C-MOVE to move a series.
      ''' </summary>
      ''' <param name="patientID">Patient ID.</param>
      ''' <param name="studyInstance">Study Instance UID.</param>
      ''' <param name="seriesInstance">Series Instance UID.</param>
      ''' <param name="clientPort">Client port for SCP to connect to.</param>
      Public Sub MoveSeries(ByVal server As DicomServer, ByVal AETitle As String, ByVal patientID As String, ByVal studyInstance As String, ByVal seriesInstance As String, ByVal clientPort As Integer)
         Dim ret As DicomExceptionCode

         Me.patientID = patientID
         Me.studyInstance = studyInstance
         Me.seriesInstance = seriesInstance
         Me.clientPort = clientPort

#If LEADTOOLS_V17_OR_LATER Then
         Me.ipType = server.IpType
#End If

         ret = Associate(server, AETitle, New SCUProcessFunc(AddressOf MoveSeriesProcess))
         If ret <> DicomExceptionCode.Success Then
            'MessageBox.Show("Error during association: ",ret.ToString());
            Return
         End If
      End Sub

      Public Overrides Function GetPresentationContext() As PresentationContextCollection
         Dim pc As PresentationContextCollection = New PresentationContextCollection()
         Dim p As PresentationContext

         p = New PresentationContext()
         p.AbstractSyntax = DicomUidType.PatientRootQueryFind
         p.TransferSyntaxList.Add(DicomUidType.ImplicitVRLittleEndian)
         pc.Add(p)

         p = New PresentationContext()
         p.AbstractSyntax = DicomUidType.StudyRootQueryFind
         p.TransferSyntaxList.Add(DicomUidType.ImplicitVRLittleEndian)
         pc.Add(p)

         p = New PresentationContext()
         p.AbstractSyntax = DicomUidType.StudyRootQueryMove
         p.TransferSyntaxList.Add(DicomUidType.ImplicitVRLittleEndian)
         pc.Add(p)

         p = New PresentationContext()
         p.AbstractSyntax = DicomUidType.VerificationClass
         p.TransferSyntaxList.Add(DicomUidType.ImplicitVRLittleEndian)
         pc.Add(p)

         p = New PresentationContext()
         p.AbstractSyntax = DicomUidType.PatientRootQueryMove
         p.TransferSyntaxList.Add(DicomUidType.ImplicitVRLittleEndian)
         pc.Add(p)

         Return pc
      End Function

      Public Sub FindProcess()
         Using ds As DicomDataSet = GetDS()

            Dim pid As Byte = GetPresentationID(type)

            If pid = 0 OrElse (Association.GetResult(pid) <> DicomAssociateAcceptResultType.Success) Then
               InvokeStatusEvent(StatusType.Error, DicomExceptionCode.Success)
               Return
            End If

            If ds Is Nothing Then
               Return
            End If

            Dim uid As String = ""

            If type = FindType.Patient OrElse type = FindType.PatientSeries Then
               uid = DicomUidType.PatientRootQueryFind
            ElseIf type = FindType.Study OrElse type = FindType.StudySeries Then
               uid = DicomUidType.StudyRootQueryFind
            End If

            InvokeStatusEvent(StatusType.SendCFindRequest, DicomExceptionCode.Success)
            MessageId = CShort(MessageId + 1)
            SendCFindRequest(pid, MessageId, uid, DicomCommandPriorityType.Medium, ds)

            If (Not Wait()) Then
               '
               ' Connection timed out
               '
               InvokeStatusEvent(StatusType.Timeout, DicomExceptionCode.Success)
               Terminate()
            End If

            InvokeStatusEvent(StatusType.SendReleaseRequest, DicomExceptionCode.Success)
            SendReleaseRequest()

            If (Not Wait()) Then
               InvokeStatusEvent(StatusType.Timeout, DicomExceptionCode.Success)
               Terminate()
            End If

            Dim e As FindCompleteEventArgs = New FindCompleteEventArgs()

            e._Datasets = dsCollection
            e._Type = type
            OnFindComplete(e)
            For Each resultDs As DicomDataSet In dsCollection
               resultDs.Dispose()
            Next resultDs

            dsCollection.Clear()
         End Using
      End Sub

      Public Sub MoveSeriesProcess()
         Dim ret As DicomExceptionCode = DicomExceptionCode.Success
         Using scp As New CFindSCP()

            dsCollection.Clear()
            scp.cfind = Me
            scp.dsCollection = dsCollection
            scp.ImplementationClass = ImplementationClass
            scp.ImplementationVersionName = ImplementationVersionName
#If LEADTOOLS_V17_OR_LATER Then
            ret = scp.Listen(clientPort, 1, ipType)
#Else
         ret = scp.Listen(clientPort, 1)
#End If
            If ret <> DicomExceptionCode.Success Then
               InvokeStatusEvent(StatusType.Error, ret)
               Terminate()
               Return
            End If
            Using ds As New DicomDataSet()

               ds.Initialize(DicomClassType.Undefined, DicomDataSetInitializeType.ExplicitVRLittleEndian)

               Utils.SetTag(ds, DemoDicomTags.QueryRetrieveLevel, "SERIES")
               Utils.SetTag(ds, DemoDicomTags.StudyInstanceUID, studyInstance)
               Utils.SetTag(ds, DemoDicomTags.SeriesInstanceUID, seriesInstance)
               'Utils.SetTag(ds, DemoDicomTags.PatientID, patientID);

               Dim pid As Byte
               pid = Association.FindAbstract(DicomUidType.StudyRootQueryMove)
               If pid = 0 Then
                  pid = Association.FindAbstract(DicomUidType.PatientRootQueryMove)
                  Utils.SetTag(ds, DemoDicomTags.PatientID, patientID)
               End If

               InvokeStatusEvent(StatusType.SendCMoveRequest, DicomExceptionCode.Success)

               Try
                  Dim UidType As String = Association.GetAbstract(pid)
                  SendCMoveRequest(pid, MessageId, UidType, DicomCommandPriorityType.Medium, Association.Calling, ds)
                  MessageId += 1
               Catch de As DicomException
                  InvokeStatusEvent(StatusType.Error, de.Code)
                  SendReleaseRequest()
                  If (Not Wait()) Then ' Allows Messages to occur
                     InvokeStatusEvent(StatusType.Timeout, DicomExceptionCode.Success)
                     Terminate()
                  End If
                  scp.Close()
                  Return
               End Try
            End Using
            If (Not Wait()) Then
               '
               ' Connection timed out
               '
               scp.Close()
               InvokeStatusEvent(StatusType.Timeout, DicomExceptionCode.Success)
               Terminate()
            End If

            InvokeStatusEvent(StatusType.SendReleaseRequest, DicomExceptionCode.Success)
            SendReleaseRequest()

            If (Not Wait()) Then
               scp.Close()
               InvokeStatusEvent(StatusType.Timeout, DicomExceptionCode.Success)
               Terminate()
            End If

            scp.Close()
            Dim e As MoveCompleteEventArgs = New MoveCompleteEventArgs()

            e._Datasets = dsCollection
            OnMoveComplete(e)
            For Each resultDs As DicomDataSet In dsCollection
               resultDs.Dispose()
            Next resultDs

            dsCollection.Clear()
         End Using
      End Sub

      Public Sub AddDS(ByVal newDS As DicomDataSet)
         If Not newDS Is Nothing Then
            Dim ds As DicomDataSet = New DicomDataSet()

            ds.Copy(newDS, Nothing, Nothing)
            dsCollection.Add(ds)
         End If

      End Sub

      Public Function GetPresentationID(ByVal type As FindType) As Byte
         Dim id As Byte = 0

         If Not Association Is Nothing Then
            Select Case type
               Case FindType.Patient, FindType.PatientSeries
                  id = Association.FindAbstract(DicomUidType.PatientRootQueryFind)
               Case FindType.Study, FindType.StudySeries
                  id = Association.FindAbstract(DicomUidType.StudyRootQueryFind)
            End Select
         End If

         Return id
      End Function

      Public Function GetDS() As DicomDataSet
         Dim ds As DicomDataSet = New DicomDataSet()

         If ds Is Nothing Then
            Return Nothing
         End If

         Select Case type
            Case FindType.Patient
               ds.Initialize(DicomClassType.PatientRootQueryPatient, DicomDataSetInitializeType.ExplicitVRLittleEndian)

               Utils.SetTag(ds, DemoDicomTags.QueryRetrieveLevel, "PATIENT")
               Utils.SetTag(ds, DemoDicomTags.PatientName, query.PatientName)
               Utils.SetTag(ds, DemoDicomTags.PatientID, query.PatientID)

            Case FindType.PatientSeries
               ds.Initialize(DicomClassType.PatientRootQuerySeries, DicomDataSetInitializeType.ExplicitVRLittleEndian)

               Utils.SetTag(ds, DemoDicomTags.QueryRetrieveLevel, "SERIES")
               Utils.SetTag(ds, DemoDicomTags.PatientID, query.PatientID)
               Utils.SetTag(ds, DemoDicomTags.StudyInstanceUID, query.StudyInstanceUid)

            Case FindType.Study
               ds.Initialize(DicomClassType.StudyRootQueryStudy, DicomDataSetInitializeType.ExplicitVRLittleEndian)

               Utils.SetTag(ds, DemoDicomTags.QueryRetrieveLevel, "STUDY")
               Utils.SetTag(ds, DemoDicomTags.StudyInstanceUID, query.StudyInstanceUid)
               Utils.SetTag(ds, DemoDicomTags.StudyID, query.StudyID)
               Utils.SetTag(ds, DemoDicomTags.AccessionNumber, query.AccessionNo)
               Utils.SetTag(ds, DemoDicomTags.PatientName, query.PatientName)
               Utils.SetTag(ds, DemoDicomTags.PatientID, query.PatientID)
               Utils.SetTag(ds, DemoDicomTags.ReferringPhysicianName, query.ReferringPhysiciansName)

               If DateTime.Compare(query.StudyStartDate, DateTime.MinValue) <> 0 AndAlso DateTime.Compare(query.StudyEndDate, DateTime.MinValue) <> 0 Then
                  Dim range As StringBuilder = New StringBuilder()

                  range.Append(query.StudyStartDate.ToString("yyyyMMdd"))
                  range.Append("-")
                  range.Append(query.StudyEndDate.ToString("yyyyMMdd"))

                  Utils.SetTag(ds, DemoDicomTags.StudyDate, Encoding.UTF8.GetBytes(range.ToString()))
               ElseIf DateTime.Compare(query.StudyStartDate, DateTime.MinValue) = 0 AndAlso DateTime.Compare(query.StudyEndDate, DateTime.MinValue) <> 0 Then
                  Dim range As StringBuilder = New StringBuilder()

                  range.Append("-")
                  range.Append(query.StudyEndDate.ToString("yyyyMMdd"))
                  Utils.SetTag(ds, DemoDicomTags.StudyDate, Encoding.UTF8.GetBytes(range.ToString()))
               ElseIf DateTime.Compare(query.StudyStartDate, DateTime.MinValue) <> 0 AndAlso DateTime.Compare(query.StudyEndDate, DateTime.MinValue) = 0 Then
                  Dim range As StringBuilder = New StringBuilder()

                  range.Append(query.StudyStartDate.ToString("yyyyMMdd"))
                  range.Append("-")
                  Utils.SetTag(ds, DemoDicomTags.StudyDate, Encoding.UTF8.GetBytes(range.ToString()))
               End If

            Case FindType.StudySeries
               ds.Initialize(DicomClassType.StudyRootQuerySeries, DicomDataSetInitializeFlags.ExplicitVR Or DicomDataSetInitializeFlags.LittleEndian Or DicomDataSetInitializeFlags.AddMandatoryElementsOnly)

               Utils.SetTag(ds, DemoDicomTags.QueryRetrieveLevel, "SERIES")
               Utils.SetTag(ds, DemoDicomTags.StudyInstanceUID, query.StudyInstanceUid)
               Utils.CreateTag(ds, DicomTag.SeriesDate)
               Utils.CreateTag(ds, DicomTag.SeriesTime)
               Utils.CreateTag(ds, DicomTag.SeriesNumber)
               Utils.CreateTag(ds, DicomTag.SeriesDescription)
               Utils.CreateTag(ds, DicomTag.NumberOfSeriesRelatedInstances)
         End Select

         Return ds
      End Function
   End Class
End Namespace
