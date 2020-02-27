' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Net
Imports System.Threading

Imports Leadtools
Imports Leadtools.Dicom

Namespace Leadtools.DicomDemos
   ''' <summary>
   ''' Status type codes.
   ''' </summary>
   Public Enum StatusType
      ''' <summary>
      ''' Dicom error has occurred.
      ''' </summary>
      [Error]

      ''' <summary>
      ''' Process has been terminated.
      ''' </summary>
      ProcessTerminated

      ''' <summary>
      ''' Connection has been successfully received.
      ''' </summary>
      ConnectReceived

      ''' <summary>
      ''' Connection attempt failed.
      ''' </summary>
      ConnectFailed

      ''' <summary>
      ''' Connection attemp succeeded.
      ''' </summary>
      ConnectSucceeded

      ''' <summary>
      ''' Connection has been closed.
      ''' </summary>
      ConnectionClosed

      ''' <summary>
      ''' Associate request sent.
      ''' </summary>
      SendAssociateRequest

      ''' <summary>
      ''' Received associate accept.
      ''' </summary>
      ReceiveAssociateAccept

      ''' <summary>
      ''' Received associate reject.
      ''' </summary>
      ReceiveAssociateReject

      ''' <summary>
      ''' The abstract syntax is not supported on the association.
      ''' </summary>
      AbstractSyntaxNotSupported

      ''' <summary>
      ''' C-STORE-REQ sent.
      ''' </summary>
      SendCStoreRequest

      ''' <summary>
      ''' Received a C-STORE-RESP
      ''' </summary>
      ReceiveCStoreResponse

      ''' <summary>
      ''' Release request sent.
      ''' </summary>
      SendReleaseRequest

      ''' <summary>
      ''' Received release response.
      ''' </summary>
      ReceiveReleaseResponse

      SendCEchoRequest

      ReceiveCEchoResponse

      SendCFindRequest

      ReceiveCFindResponse

      SendCMoveRequest

      ReceiveCMoveResponse

      SendCStoreResponse

      ReceiveCStoreRequest

      ''' <summary>
      ''' Connection timeout.
      ''' </summary>
      Timeout

      ReceiveAssociateRequest
      SenAssociateAccept
      ''' <summary>
      ''' Secure Link Ready.
      ''' </summary>
      SecureLinkReady
   End Enum

   ''' <summary>
   ''' 
   ''' </summary>
   Public Class StatusEventArgs : Inherits EventArgs
      Friend _Type As StatusType
      Friend _Error As DicomExceptionCode = DicomExceptionCode.Success
      Friend _CallingAE As String
      Friend _CalledAE As String
      Friend _PeerIP As IPAddress
      Friend _PeerPort As Integer
      Friend _NumberCompleted As Integer
      Friend _NumberRemaining As Integer
      Friend _Status As DicomCommandStatusType
      Friend _Result As DicomAssociateRejectResultType
      Friend _Source As DicomAssociateRejectSourceType
      Friend _Reason As DicomAssociateRejectReasonType
      Friend _PresentationID As Byte
      Friend _MessageID As Integer
      Friend _AffectedClass As String

      ''' <summary>
      ''' 
      ''' </summary>
      Public Sub New()
         _Type = Type
      End Sub

      ''' <summary>
      ''' Status type
      ''' </summary>
      Public ReadOnly Property Type() As StatusType
         Get
            Return _Type
         End Get
      End Property

      ''' <summary>
      ''' Status/Error code
      ''' </summary>
      Public ReadOnly Property [Error]() As DicomExceptionCode
         Get
            Return _Error
         End Get
      End Property

      Public ReadOnly Property CallingAE() As String
         Get
            Return _CallingAE
         End Get
      End Property

      Public ReadOnly Property CalledAE() As String
         Get
            Return _CalledAE
         End Get
      End Property

      Public ReadOnly Property PeerIP() As IPAddress
         Get
            Return _PeerIP
         End Get
      End Property

      Public ReadOnly Property PeerPort() As Integer
         Get
            Return _PeerPort
         End Get
      End Property

      Public ReadOnly Property NumberCompleted() As Integer
         Get
            Return _NumberCompleted
         End Get
      End Property

      Public ReadOnly Property NumberRemaining() As Integer
         Get
            Return _NumberRemaining
         End Get
      End Property

      Public ReadOnly Property Status() As DicomCommandStatusType
         Get
            Return _Status
         End Get
      End Property

      Public ReadOnly Property Result() As DicomAssociateRejectResultType
         Get
            Return _Result
         End Get
      End Property

      Public ReadOnly Property Source() As DicomAssociateRejectSourceType
         Get
            Return _Source
         End Get
      End Property

      Public ReadOnly Property Reason() As DicomAssociateRejectReasonType
         Get
            Return _Reason
         End Get
      End Property

      Public ReadOnly Property PresentationID() As Byte
         Get
            Return _PresentationID
         End Get
      End Property

      Public ReadOnly Property MessageID() As Integer
         Get
            Return _MessageID
         End Get
      End Property

      Public ReadOnly Property AffectedClass() As String
         Get
            Return _AffectedClass
         End Get
      End Property
   End Class

   Public Delegate Sub StatusEventHandler(ByVal sender As Object, ByVal e As StatusEventArgs)

   ''' <summary>
   ''' Base class for dicom communications.  Defines all the processes that
   ''' are common to SCP & SCU applications.
   ''' </summary>
   Public Class Base : Inherits DicomNet
      Private _Event As AutoResetEvent = New AutoResetEvent(False)
      Private _resetTimeoutEvent As New AutoResetEvent(False)
      Private _ImplementationClass As String = "1.2.840.114257.1123456"
      Private _privateKeyPassword As String = ""
      Private _isSecureTLS As Boolean = False

      Public Event Status As StatusEventHandler
      Public ReadOnly Property IsSecureTLS() As Boolean
         Get
            Return _isSecureTLS
         End Get
      End Property
      Public Property PrivateKeyPassword() As String
         Get
            Return _privateKeyPassword
         End Get
         Set(ByVal value As String)
            _privateKeyPassword = value
         End Set
      End Property
      Protected Overrides Function OnPrivateKeyPassword(ByVal encryption As Boolean) As String
         Return PrivateKeyPassword
      End Function

#If Not LEADTOOLS_V20_OR_LATER Then
      Public Sub New(ByVal clientPEM As String, ByVal tlsCipherSuiteType As DicomTlsCipherSuiteType, ByVal tlsCertificateType As DicomTlsCertificateType, ByVal privateKeyPassword As String)
         MyBase.New(Nothing, DicomNetSecurityeMode.Tls)
#Else
      Public Sub New(ByVal clientPEM As String, ByVal tlsCipherSuiteType As DicomTlsCipherSuiteType, ByVal tlsCertificateType As DicomTlsCertificateType, ByVal privateKeyPassword As String)
         MyBase.New(Nothing, DicomNetSecurityMode.Tls)
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then
         _privateKeyPassword = privateKeyPassword
         SetTlsCipherSuiteByIndex(0, tlsCipherSuiteType)
         SetTlsClientCertificate(clientPEM, tlsCertificateType, Nothing)
         _isSecureTLS = True
      End Sub

#If Not LEADTOOLS_V20_OR_LATER Then
      Public Sub New()
         MyBase.New(Nothing, DicomNetSecurityeMode.None)
         '
         ' TODO: Add constructor logic here
         '
      End Sub
#Else
      Public Sub New()
         MyBase.New(Nothing, DicomNetSecurityMode.None)
         '
         ' TODO: Add constructor logic here
         '
      End Sub
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then

      Protected Overridable Sub OnStatus(ByVal e As StatusEventArgs)
         'LastError = e.Error;
         If Not StatusEvent Is Nothing Then
            ' Invokes the delegates. 
            RaiseEvent Status(Me, e)
         End If
      End Sub

      Public Sub InvokeStatusEvent(ByVal sType As StatusType, ByVal [error] As DicomExceptionCode)
         Dim se As StatusEventArgs = New StatusEventArgs()

         se._Type = sType
         se._Error = [error]
         OnStatus(se)
      End Sub

      Public Sub InvokeStatusEvent(ByVal sType As StatusType, ByVal [error] As DicomExceptionCode, ByVal callingAE As String, ByVal calledAE As String)
         Dim se As StatusEventArgs = New StatusEventArgs()

         se._Type = sType
         se._Error = [error]
         se._CallingAE = callingAE
         se._CalledAE = calledAE
         OnStatus(se)
      End Sub

      Public Sub InvokeStatusEvent(ByVal sType As StatusType, ByVal [error] As DicomExceptionCode, ByVal completed As Integer, ByVal remaining As Integer, ByVal status As DicomCommandStatusType)
         Dim se As StatusEventArgs = New StatusEventArgs()

         se._Type = sType
         se._Error = [error]
         se._NumberCompleted = completed
         se._NumberRemaining = remaining
         se._Status = status
         OnStatus(se)

      End Sub

      Public Sub InvokeStatusEvent(ByVal sType As StatusType, ByVal status As DicomCommandStatusType)
         Dim se As StatusEventArgs = New StatusEventArgs()

         If (status = DicomCommandStatusType.Success) Then
            se._Error = DicomExceptionCode.Success
         Else
            se._Error = DicomExceptionCode.NetFailure
         End If
         se._Status = status
         se._Type = sType

         OnStatus(se)
      End Sub

      Public Sub InvokeStatusEvent(ByVal sType As StatusType, ByVal status As DicomCommandStatusType, ByVal presentationID As Byte, ByVal messageID As Integer, ByVal affectedClass As String)
         Dim se As StatusEventArgs = New StatusEventArgs()

         If (status = DicomCommandStatusType.Success) Then
            se._Error = DicomExceptionCode.Success
         Else
            se._Error = DicomExceptionCode.NetFailure
         End If
         se._Status = status

         se._Type = sType
         se._PresentationID = presentationID
         se._MessageID = messageID
         se._AffectedClass = affectedClass

         OnStatus(se)
      End Sub

      Public Sub InvokeStatusEvent(ByVal e As StatusEventArgs)
         OnStatus(e)
      End Sub

      Public Sub InvokeStatusEvent(ByVal sType As StatusType, ByVal result As DicomAssociateRejectResultType, ByVal source As DicomAssociateRejectSourceType, ByVal reason As DicomAssociateRejectReasonType)
         Dim se As StatusEventArgs = New StatusEventArgs()

         se._Result = result
         se._Reason = reason
         se._Source = source
         se._Error = DicomExceptionCode.Success
         se._Type = sType
         OnStatus(se)

      End Sub

      ''' <summary>
      ''' Derived classes should override this method to perform any 
      ''' per instance initialization.
      ''' </summary>
      Public Overridable Sub Init()

      End Sub

      ''' <summary>
      ''' Implementation Class.
      ''' </summary>
      Public Property ImplementationClass() As String
         Get
            Return _ImplementationClass
         End Get
         Set(ByVal value As String)
            _ImplementationClass = value
         End Set
      End Property

      Private _ImplementationVersionName As String = ""

      ''' <summary>
      ''' Implementation Version Name.
      ''' </summary>
      Public Property ImplementationVersionName() As String
         Get
            Return _ImplementationVersionName
         End Get
         Set(ByVal value As String)
            _ImplementationVersionName = value
         End Set
      End Property

      ''' <summary>
      ''' Event used to control communication flow in the dicom
      ''' communication thread.
      ''' </summary>
      Public ReadOnly Property [Event]() As AutoResetEvent
         Get
            Return _Event
         End Get
      End Property

      Public ReadOnly Property ResetTimeoutEvent() As AutoResetEvent
         Get
            Return _resetTimeoutEvent
         End Get
      End Property

   End Class
End Namespace
