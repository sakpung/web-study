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

Namespace Leadtools.DicomDemos.Scu.CStore
   ''' <summary>
   ''' 
   ''' </summary>
   Public Class ProgressFilesEventArgs : Inherits EventArgs
      Friend _File As FileInfo

      ''' <summary>
      ''' The current file that is been worked on.
      ''' </summary>
      Public ReadOnly Property File() As FileInfo
         Get
            Return _File
         End Get
      End Property
   End Class

   Public Delegate Sub ProgressFilesEventHandler(ByVal sender As Object, ByVal e As ProgressFilesEventArgs)

   ''' <summary>
   ''' Summary description for Class1.
   ''' </summary>
   Public Class CStore : Inherits Scu
      Private _Files As StringCollection = New StringCollection()


      Private _Compression As DicomImageCompressionType
      Public [Continue] As Boolean = True
      Public PresentID As Short
      Private strCompression As String = ""

      ''' <summary>
      ''' DICOM Implementation Class UID.
      ''' </summary>
      Public Shared ImplementationClassUid As String

      ''' <summary>
      ''' 
      ''' </summary>
      Public Sub New()
      End Sub
      Public Sub New(clientPEM as string, tlsCipherSuiteType as DicomTlsCipherSuiteType, tlsCertificateType as DicomTlsCertificateType, privateKeyPassword as String)
         MyBase.New(clientPEM, tlsCipherSuiteType, tlsCertificateType, privateKeyPassword)
         '
         ' TODO: Add constructor logic here
         '
      End Sub

      Protected Overrides Sub Finalize()
         If Not workThread Is Nothing AndAlso workThread.IsAlive Then
            workThread.Abort()
         End If
      End Sub

#Region "Events          "

      Public Event ProgressFiles As ProgressFilesEventHandler

      Public Overridable Sub OnProgressFiles(ByVal e As ProgressFilesEventArgs)
         If Not ProgressFilesEvent Is Nothing Then
            ' Invokes teh delegates
            RaiseEvent ProgressFiles(Me, e)
         End If
      End Sub

#End Region

      ''' <summary>
      ''' Collections of files to send with C-STORE-REQ
      ''' </summary>
      Public ReadOnly Property Files() As StringCollection
         Get
            Return _Files
         End Get
      End Property

      ''' <summary>
      ''' Compression
      ''' </summary>
      <Category("Compression")> _
      Public Property Compression() As DicomImageCompressionType
         Get
            Return _Compression
         End Get
         Set(ByVal value As DicomImageCompressionType)
            _Compression = value
         End Set
      End Property

      Public Overrides Sub Init()
         MyBase.Init()
      End Sub

      Protected Overrides Sub OnReceiveCStoreResponse(ByVal presentationID As Byte, ByVal messageID As Integer, ByVal affectedClass As String, ByVal instance As String, ByVal status As DicomCommandStatusType)
         InvokeStatusEvent(StatusType.ReceiveCStoreResponse, status)
         [Continue] = True
         Me.Event.Set()
      End Sub

      Protected Overrides Sub OnReceiveReleaseResponse()
         InvokeStatusEvent(StatusType.ReceiveReleaseResponse, DicomExceptionCode.Success)
         Try
            Close()
         Catch ex As Exception
            ex = ex
         End Try
         Me.Event.Set()
      End Sub

      Protected Overrides Sub OnReceiveData(ByVal presentationID As Byte, ByVal cs As Dicom.DicomDataSet, ByVal ds As Dicom.DicomDataSet)
         MyBase.OnReceiveData(presentationID, cs, ds)
         If Nothing IsNot cs Then
            cs.Dispose()
         End If

      End Sub

      Public Overrides Function GetPresentationContext() As PresentationContextCollection
         Dim pc As PresentationContextCollection = New PresentationContextCollection()
         Dim p As PresentationContext
         Dim TransferSyntax As String = ""

         If Compression <> DicomImageCompressionType.None Then
            Select Case Compression
               Case DicomImageCompressionType.J2kLossy
                  strCompression = DicomUidType.JPEG2000
               Case DicomImageCompressionType.J2kLossless
                  strCompression = DicomUidType.JPEG2000LosslessOnly
               Case DicomImageCompressionType.JpegLossy
                  strCompression = DicomUidType.JPEGBaseline1
               Case DicomImageCompressionType.JpegLossless
                  strCompression = DicomUidType.JPEGLosslessNonhier14
            End Select
         End If

         For Each file As String In Files
            Dim StorageClass As String

         Using dcmDS As New DicomDataSet()

            TransferSyntax = strCompression
            Try
                  dcmDS.Load(file, DicomDataSetLoadFlags.None)
            Catch de As DicomException
               InvokeStatusEvent(StatusType.Error, de.Code)
               Terminate()
               Exit For
            End Try


            StorageClass = Utils.GetStringValue(dcmDS, DemoDicomTags.MediaStorageSOPClassUID)
            StorageClass = StorageClass.Trim()
            If StorageClass.Length = 0 Then
               StorageClass = Utils.GetStringValue(dcmDS, DemoDicomTags.SOPClassUID)
               StorageClass = StorageClass.Trim()
            End If
            If StorageClass.Length = 0 Then
               StorageClass = "1.1.1.1"
            End If

            p = FindPresentationContext(StorageClass, pc)
            If p Is Nothing Then
               p = New PresentationContext()

               p.AbstractSyntax = StorageClass
               pc.Add(p)
            End If

            If TransferSyntax.Length = 0 Then
               TransferSyntax = Utils.GetStringValue(dcmDS, DemoDicomTags.TransferSyntaxUID)
               TransferSyntax = TransferSyntax.Trim()
            End If

            If p.TransferSyntaxList.IndexOf(TransferSyntax) = -1 Then
               p.TransferSyntaxList.Add(TransferSyntax)
            End If
         End Using
         Next file

         Return pc
      End Function

      Private Function FindPresentationContext(ByVal StorageClass As String, ByVal pc As PresentationContextCollection) As PresentationContext
         For Each pCtxt As PresentationContext In pc
            If pCtxt.AbstractSyntax = StorageClass Then
               Return pCtxt
            End If
         Next pCtxt
         Return Nothing
      End Function


      ''' <summary>
      ''' Initiates the C-STORE-REQ
      ''' </summary>
      ''' <param name="ClientAE">Calling AE Title.</param>		
      ''' <returns></returns>
      Public Function Store(ByVal server As DicomServer, ByVal ClientAE As String) As DicomExceptionCode
         Dim ret As DicomExceptionCode

         ret = Associate(server, ClientAE, New SCUProcessFunc(AddressOf StoreProcess))
         If ret <> DicomExceptionCode.Success Then
            'MessageBox.Show("Error during association: ",ret.ToString());
            Return ret
         End If

         Return 0
      End Function

      ' Returns the presentation ID of the association that contains 
      ' 1. the storage class (sStorageClass)
      ' 2. the transfer syntax (sSearchTransferSyntax)
      '
      ' sSearchTransferSyntax: if String.Empty then match ANY valid transfer syntax
      ' Returns 0 if not found
      Public Function SearchAssociation(ByVal sStorageClass As String, ByVal sSearchTransferSyntax As String) As Byte
         ' Check if the sent abstract syntax is accepted
         Dim pid As Byte = Association.FindAbstract(sStorageClass)
         Do While pid <> 0
            If Association.GetResult(pid) = DicomAssociateAcceptResultType.Success Then
               ' Get the accepted transfer syntax
               Dim transferSyntax As String = Association.GetTransfer(pid, 0)
               If sSearchTransferSyntax = String.Empty Then
                  Return pid
               End If
               If transferSyntax = sSearchTransferSyntax Then
                  Return pid
               End If
            End If
            pid = Association.FindNextAbstract(pid, sStorageClass)
         Loop
         Return 0
      End Function

      Public Sub StoreProcess()
         For Each file As String In Files
            Dim StorageClass As String
            Dim StorageInstance As String
            Dim pid As Byte = 0
            Dim sOriginalTransferSyntax As String = DicomUidType.ImplicitVRLittleEndian
            Dim sNewTransferSyntax As String = DicomUidType.ImplicitVRLittleEndian
            Dim sSearchTransferSyntax As String = DicomUidType.ImplicitVRLittleEndian

            Dim pfe As ProgressFilesEventArgs = New ProgressFilesEventArgs()

            If Association Is Nothing Then
               Terminate()
               Return
            End If

            pfe._File = New FileInfo(file)
            OnProgressFiles(pfe)

            Dim bStoreFile As Boolean = True
            Try
               Using dcmDs As New DicomDataSet()

                  dcmDs.Load(file, DicomDataSetLoadFlags.None)


               StorageClass = Utils.GetStringValue(dcmDs, DemoDicomTags.MediaStorageSOPClassUID)
               StorageClass = StorageClass.Trim()

               sOriginalTransferSyntax = Utils.GetStringValue(dcmDs, DemoDicomTags.TransferSyntaxUID)
               If StorageClass.Length = 0 Then
                  StorageClass = Utils.GetStringValue(dcmDs, DemoDicomTags.SOPClassUID)
                  StorageClass = StorageClass.Trim()
               End If
               If StorageClass.Length = 0 Then
                  StorageClass = "1.1.1.1"
               End If

               StorageInstance = Utils.GetStringValue(dcmDs, DemoDicomTags.SOPInstanceUID)
               StorageInstance = StorageInstance.Trim()
               If StorageInstance.Length = 0 Then
                  StorageInstance = "998.998.1.1.19950214.94000.1.102"
               End If

               Select Case Compression
                  Case DicomImageCompressionType.None
                     ' For this demo, DicomImageCompressionType.None actually means "Do Not Recompress"
                     ' Search the association for the files current transfer syntax
                     ' If not found, change to Little Endian
                     sSearchTransferSyntax = sOriginalTransferSyntax
                  Case DicomImageCompressionType.J2kLossy
                     sSearchTransferSyntax = DicomUidType.JPEG2000
                  Case DicomImageCompressionType.J2kLossless
                     sSearchTransferSyntax = DicomUidType.JPEG2000LosslessOnly
                  Case DicomImageCompressionType.JpegLossy
                     sSearchTransferSyntax = DicomUidType.JPEGBaseline1
                  Case DicomImageCompressionType.JpegLossless
                     sSearchTransferSyntax = DicomUidType.JPEGLosslessNonhier14
               End Select

               Dim pidDefault As Byte
               pidDefault = SearchAssociation(StorageClass, String.Empty)
               pid = SearchAssociation(StorageClass, sSearchTransferSyntax)
               If pid <> 0 Then
                  sNewTransferSyntax = sOriginalTransferSyntax
               ElseIf pidDefault <> 0 Then
                  ' Search for default transfer syntax
                     sNewTransferSyntax = DicomUidType.ImplicitVRLittleEndian
                     pid = pidDefault
               Else
                  bStoreFile = False
               End If

               If bStoreFile Then
                  ' Change the transfer syntax to the accepted one
                  sNewTransferSyntax = sNewTransferSyntax.Trim()
                  If sNewTransferSyntax.Length > 0 Then
                     dcmDs.ChangeTransferSyntax(sNewTransferSyntax, 2, ChangeTransferSyntaxFlags.None)
                  End If

                  InvokeStatusEvent(StatusType.SendCStoreRequest, DicomExceptionCode.Success)
                  MessageId = Convert.ToInt16(MessageId + 1)
                  SendCStoreRequest(pid, MessageId, StorageClass, StorageInstance, DicomCommandPriorityType.Medium, "", 0, dcmDs)
               End If
               End Using
            Catch de As DicomException
               InvokeStatusEvent(StatusType.Error, de.Code)
               Terminate()
               Exit For
            End Try

            If bStoreFile Then
               If (Not Wait()) Then
                  InvokeStatusEvent(StatusType.Timeout, DicomExceptionCode.Success)
                  Terminate()
                  Return
               End If

               If [Continue] = False Then
                  Return
               End If
            End If
         Next file

         InvokeStatusEvent(StatusType.SendReleaseRequest, DicomExceptionCode.Success)
         SendReleaseRequest()

         If (Not Wait()) Then
            InvokeStatusEvent(StatusType.Timeout, DicomExceptionCode.Success)
            Terminate()
            Return
         End If
      End Sub
   End Class
End Namespace
