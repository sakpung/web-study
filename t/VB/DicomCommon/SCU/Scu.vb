' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Net
Imports System.Threading
Imports System.Reflection

Imports Leadtools
Imports Leadtools.Dicom
Imports Leadtools.DicomDemos

Namespace Leadtools.DicomDemos.Scu
   Public Delegate Sub SCUProcessFunc()

   Friend Class AssociateInfo
      Public scu As Scu
      Public dcmServer As DicomServer
      Public ClientAE As String
      Public process As SCUProcessFunc

      Public Sub DoAssociate()
         Dim associate As DicomAssociate

         Dim ret As DicomExceptionCode = DicomExceptionCode.Success

         ret = scu.Connect(dcmServer)
         If ret <> DicomExceptionCode.Success Then
            Return
         End If

         associate = scu.BuildAssociation(dcmServer.AETitle, ClientAE)
         If associate Is Nothing Then
            scu.InvokeStatusEvent(StatusType.Error, DicomExceptionCode.Parameter)
            scu.Terminate()
            Return
         End If

         scu.InvokeStatusEvent(StatusType.SendAssociateRequest, DicomExceptionCode.Success)
         Try
            If scu.IsConnected() Then
               scu.SendAssociateRequest(associate)
            Else
               scu.InvokeStatusEvent(StatusType.Error, DicomExceptionCode.NetConnectionAborted)
               scu.Terminate()
               Return
            End If
         Catch de As DicomException
            scu.InvokeStatusEvent(StatusType.Error, de.Code)
            scu.Terminate()
            Return
         End Try

         If (Not scu.Wait()) Then
            '
            ' Connection timed out
            '
            scu.InvokeStatusEvent(StatusType.Timeout, DicomExceptionCode.Success)
            scu.Terminate()
         End If

         If Not scu.Rejected AndAlso scu.IsAssociated() Then
            process()
         End If
      End Sub
   End Class

   ''' <summary>
   ''' Summary description for Scu.
   ''' </summary>
   Public Class Scu : Inherits Base
      Private dcmServer As DicomServer
      Private workInfo As AssociateInfo
      Public workThread As Thread
      Private _MessageId As Short = 1

      Private _ProtocolVersion As String

      Private _presentationContextType As Integer

      Public Property PresentationContextType() As Integer
         Get
            Return _presentationContextType
         End Get
         Set(ByVal value As Integer)
            _presentationContextType = Value
         End Set
      End Property


      Public Property ProtocolVersion() As String
         Get
            Return _ProtocolVersion
         End Get
         Set(ByVal value As String)
            _ProtocolVersion = value
         End Set
      End Property

      ''' <summary>
      ''' Dicom message id.
      ''' </summary>
      Public Property MessageId() As Short
         Get
            Return _MessageId
         End Get
         Set(ByVal value As Short)
            _MessageId = value
         End Set
      End Property

      Private _Rejected As Boolean

      Public ReadOnly Property Rejected() As Boolean
         Get
            Return _Rejected
         End Get
      End Property

      Public Sub New()
      End Sub
      Public Sub New(ByVal clientPEM As String, ByVal tlsCipherSuiteType As DicomTlsCipherSuiteType, ByVal tlsCertificateType As DicomTlsCertificateType, ByVal privateKeyPassword As String)
         MyBase.New(clientPEM, tlsCipherSuiteType, tlsCertificateType, privateKeyPassword)

      End Sub

      Protected Overrides Sub Finalize()
         If Not workThread Is Nothing AndAlso workThread.IsAlive Then
            workThread.Abort()
         End If
      End Sub

      Public Overrides Sub Init()
         MyBase.Init()
      End Sub

      Protected Overrides Sub OnConnect(ByVal [error] As DicomExceptionCode)
         If [error] <> DicomExceptionCode.Success Then
            InvokeStatusEvent(StatusType.ConnectFailed, [error])

            ' Calling terminate here causes a problem, because it disposes of the Net
            ' The DicomNet object is disposed of in the OnClose event
            ' 
            ' This occurs in two places:
            ' 1. InvokeStatusEvent->store_Status->ClosedForced which generates an OnClose
            ' 2. Terminate->CloseForced which genrates an OnClose
            '
            ' So do not call Terminate

            ' Terminate()
            Return
         End If
         Dim e As StatusEventArgs = New StatusEventArgs()

         e._Type = StatusType.ConnectSucceeded
         e._PeerIP = IPAddress.Parse(PeerAddress)
         e._PeerPort = PeerPort
         InvokeStatusEvent(e)
         If IsSecureTLS = False Then
            Me.Event.Set()
         End If
      End Sub
      Protected Overrides Sub OnSecureLinkReady(ByVal [error] As DicomExceptionCode)

         If [error] <> DicomExceptionCode.Success Then
            InvokeStatusEvent(StatusType.ConnectFailed, [error])
            Terminate()
            Return
         End If

         Dim e As StatusEventArgs = New StatusEventArgs()

         e._Type = StatusType.SecureLinkReady
         e._PeerIP = IPAddress.Parse(PeerAddress)
         e._PeerPort = PeerPort
         InvokeStatusEvent(e)
         If IsSecureTLS = True Then
            Me.Event.Set()
         End If

      End Sub


      Protected Overrides Sub OnReceiveAssociateAccept(ByVal association As DicomAssociate)
         InvokeStatusEvent(StatusType.ReceiveAssociateAccept, 0, association.Calling, association.Called)
         Me.Event.Set()
      End Sub

      Protected Overrides Sub OnReceiveAssociateReject(ByVal result As DicomAssociateRejectResultType, ByVal source As DicomAssociateRejectSourceType, ByVal reason As DicomAssociateRejectReasonType)
         _Rejected = True
         InvokeStatusEvent(StatusType.ReceiveAssociateReject, result, source, reason)
         Me.Event.Set()
      End Sub

      ''' <summary>
      ''' Waits for a dicom communication to complete.
      ''' </summary>
      ''' <returns></returns>
      Public Function Wait() As Boolean
         Dim ret As WaitReturn

         ret = Utils.WaitForComplete(dcmServer.Timeout * 1000, Me.Event, Me.ResetTimeoutEvent)
         Return (ret = WaitReturn.Complete)

      End Function

      ''' <summary>
      ''' Connects to a dicom server.
      ''' </summary>
      ''' <param name="server">Dicom server to connect to.</param>
      ''' <returns></returns>
      Public Overloads Function Connect(ByVal server As DicomServer) As DicomExceptionCode
         dcmServer = server

         _Rejected = False
         Try
#If LEADTOOLS_V17_OR_LATER Then
         MyBase.Connect(Nothing, 0, server.Address.ToString(), server.Port, server.IpType)
#Else
            MyBase.Connect(Nothing, 0, server.Address.ToString(), server.Port)
#End If


            If (Not Wait()) Then
               '
               ' Connection timed out
               '
               Return DicomExceptionCode.NetTimeout
            End If
         Catch e As DicomException
            Return e.Code
         End Try

         Return DicomExceptionCode.Success
      End Function

      Public Overridable Function GetPresentationContext() As PresentationContextCollection
         Return New PresentationContextCollection()
      End Function

      Public Function BuildAssociation(ByVal CalledTitle As String, ByVal CallingTitle As String) As DicomAssociate
         Dim contexts As PresentationContextCollection = GetPresentationContext()
         Dim association As DicomAssociate = New DicomAssociate(True)

         association.Called = CalledTitle
         association.Calling = CallingTitle
            association.MaxLength = 46726
         association.ImplementClass = ImplementationClass

         Dim pid As Byte = 1
         Dim addedImplicitVRLittleEndian As Boolean = False
         If PresentationContextType = 0 Then
            ' One presentation context contains all transfer syntaxes
            For Each pc As PresentationContext In contexts
               association.AddPresentationContext(pid, 0, pc.AbstractSyntax)
               addedImplicitVRLittleEndian = False
               For Each transfersyntax As String In pc.TransferSyntaxList
                  association.AddTransfer(pid, transfersyntax)
                  If transfersyntax = DicomUidType.ImplicitVRLittleEndian Then
                     addedImplicitVRLittleEndian = True
                  End If
               Next transfersyntax
               If (Not addedImplicitVRLittleEndian) Then
                  association.AddTransfer(pid, DicomUidType.ImplicitVRLittleEndian)
               End If
               pid += Convert.ToByte(2)
            Next pc
         Else
            ' Separate presentation context for each transfer syntax
            For Each pc As PresentationContext In contexts
               addedImplicitVRLittleEndian = False
               For Each transfersyntax As String In pc.TransferSyntaxList
                  association.AddPresentationContext(pid, 0, pc.AbstractSyntax)
                  association.AddTransfer(pid, transfersyntax)
                  If transfersyntax = DicomUidType.ImplicitVRLittleEndian Then
                     addedImplicitVRLittleEndian = True
                  End If
                  pid += Convert.ToByte(2)
               Next transfersyntax
               If (Not addedImplicitVRLittleEndian) Then
                  association.AddPresentationContext(pid, 0, pc.AbstractSyntax)
                  association.AddTransfer(pid, DicomUidType.ImplicitVRLittleEndian)
                  pid += Convert.ToByte(2)
               End If
            Next pc
         End If
         Return association
      End Function

      ''' <summary>
      ''' Send an associate request to a dicom scp.
      ''' </summary>
      ''' <param name="server">Dicom server.</param>
      ''' <param name="CallingTitle">Calling ae title.</param>
      ''' <returns>DICOM_SUCCESS if successful, error otherwise.</returns>
      Public Function Associate(ByVal server As DicomServer, ByVal CallingTitle As String, ByVal process As SCUProcessFunc) As DicomExceptionCode
         '
         ' Terminate any existing communication
         '
         Terminate()

         workInfo = New AssociateInfo()
         workInfo.scu = Me
         workInfo.dcmServer = server
         workInfo.ClientAE = CallingTitle
         workInfo.process = process

         workThread = New Thread(AddressOf workInfo.DoAssociate)
         workThread.Start()


         Return DicomExceptionCode.Success
      End Function

      ''' <summary>
      ''' Terminates the dicom request.
      ''' </summary>
      Public Sub Terminate()
            Try
         If IsConnected() Then
                    Dim se As New StatusEventArgs()

            If IsAssociated() Then
               SendAbort(DicomAbortSourceType.User, 0)
            End If
                    CloseForced(True)
            se._Type = StatusType.ProcessTerminated
            OnStatus(se)
         End If

         '
         ' Terminate the store thread
         '
                If workThread IsNot Nothing AndAlso workThread.IsAlive Then
            workThread.Abort()
         End If
            Catch e1 As Exception
            Finally
            End Try

      End Sub
   End Class
End Namespace
