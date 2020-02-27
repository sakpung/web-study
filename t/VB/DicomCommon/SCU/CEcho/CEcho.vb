' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Net
Imports System.Threading
Imports System.ComponentModel
Imports System.Collections.Specialized

Imports Leadtools
Imports Leadtools.Dicom
Imports Leadtools.DicomDemos
Imports Leadtools.DicomDemos.Scu

Namespace Leadtools.DicomDemos.Scu.CEcho

   ''' <summary>
   ''' Summary description for Class1.
   ''' </summary>
   Public Class CEcho : Inherits Scu
      'private StringCollection _Files = new StringCollection();

      Public [Continue] As Boolean = True
      Public PresentID As Short

      ''' <summary>
      ''' DICOM Implementation Class UID.
      ''' </summary>
      Public Shared ImplementationClassUid As String

      ''' <summary>
      ''' 
      ''' </summary>
      Public Sub New()
      End Sub
#Region "Secure TLS Communication"
      Public Sub New(ByVal clientPEM As String, ByVal tlsCipherSuiteType As DicomTlsCipherSuiteType, ByVal tlsCertificateType As DicomTlsCertificateType, ByVal privateKeyPassword As String)
         MyBase.New(clientPEM, tlsCipherSuiteType, tlsCertificateType, privateKeyPassword)

      End Sub
#End Region

      Protected Overrides Sub Finalize()
         If Not workThread Is Nothing AndAlso workThread.IsAlive Then
            workThread.Abort()
         End If
      End Sub

      Public Overrides Sub Init()
         MyBase.Init()
      End Sub


      Protected Overrides Sub OnReceiveCEchoResponse(ByVal presentationID As Byte, ByVal messageID As Integer, ByVal affectedClass As String, ByVal status As DicomCommandStatusType)
         Try
            Dim se As StatusEventArgs = New StatusEventArgs()
            InvokeStatusEvent(StatusType.ReceiveCEchoResponse, status, presentationID, messageID, affectedClass)
            [Continue] = True
            [Event].Set()
         Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString())
         End Try

      End Sub

      Protected Overrides Sub OnReceiveReleaseResponse()
         Try
            InvokeStatusEvent(StatusType.ReceiveReleaseResponse, DicomExceptionCode.Success)
            Close()
            [Event].Set()

         Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString())
         End Try
      End Sub

      Public Overrides Function GetPresentationContext() As PresentationContextCollection
         Dim pc As PresentationContextCollection = New PresentationContextCollection()
         Dim p As PresentationContext

         Try
            Dim VerificationClass As String

            VerificationClass = DicomUidType.VerificationClass

            ' Check to make sure the Presentation Context isn't already in the collection
            p = FindPresentationContext(VerificationClass, pc)
            If p Is Nothing Then
               p = New PresentationContext()

               p.AbstractSyntax = VerificationClass
               pc.Add(p)
            End If

         Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString())
         End Try
         Return pc

      End Function

      Private Function FindPresentationContext(ByVal StorageClass As String, ByVal pc As PresentationContextCollection) As PresentationContext
         For Each pCtxt As PresentationContext In pc
            Try
               If pCtxt.AbstractSyntax = StorageClass Then
                  Return pCtxt
               End If

            Catch ex As Exception
               System.Windows.Forms.MessageBox.Show(ex.ToString())
            End Try
         Next pCtxt
         Return Nothing
      End Function

      ''' <summary>
      ''' Initiates the C-EECHO-REQ
      ''' </summary>
      ''' <param name="ClientAE">Calling AE Title.</param>		
      ''' <returns></returns>
      Public Function Echo(ByVal server As DicomServer, ByVal ClientAE As String) As DicomExceptionCode
         Dim ret As DicomExceptionCode

         ret = Associate(server, ClientAE, New SCUProcessFunc(AddressOf EchoProcess))
         If ret <> DicomExceptionCode.Success Then
            Return ret
         End If

         Return 0
      End Function

      Public Sub EchoProcess()

         Dim pid As Byte

         If Association Is Nothing Then
            Terminate()
            Return
         End If

         Try
            pid = Association.FindAbstract(DicomUidType.VerificationClass)
            InvokeStatusEvent(StatusType.SendCEchoRequest, DicomExceptionCode.Success)
            MessageId += CShort(1)
            SendCEchoRequest(pid, MessageId, DicomUidType.VerificationClass)
         Catch de As DicomException
            InvokeStatusEvent(StatusType.Error, de.Code)
            Terminate()
         End Try

         If (Not Wait()) Then
            InvokeStatusEvent(StatusType.Timeout, DicomExceptionCode.Success)
            Terminate()
            Return
         End If

         If Not [Continue] Then
            Return
         End If

         InvokeStatusEvent(StatusType.SendReleaseRequest, DicomExceptionCode.Success)

         SendReleaseRequest()

         If (Not Wait()) Then
            InvokeStatusEvent(StatusType.Timeout, DicomExceptionCode.Success)
            Terminate()
            Return
         End If
      End Sub
      Protected Overrides Sub OnReceiveData(ByVal presentationID As Byte, ByVal cs As Dicom.DicomDataSet, ByVal ds As Dicom.DicomDataSet)
         MyBase.OnReceiveData(presentationID, cs, ds)

         If (cs IsNot Nothing) Then
            cs.Dispose()
         End If
      End Sub
   End Class
End Namespace
