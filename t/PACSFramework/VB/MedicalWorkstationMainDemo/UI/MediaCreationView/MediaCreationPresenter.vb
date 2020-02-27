' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Dicom.Common.DataTypes
Imports Leadtools.Demos.Workstation.Configuration
Imports Leadtools.DicomDemos
Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel
Imports Leadtools.Dicom.Scu
Imports System.Net
Imports Leadtools.Dicom.Common.DataTypes.MediaCreation
Imports Leadtools.Dicom
Imports Leadtools.Dicom.Common.Validation

Namespace Leadtools.Demos.Workstation
   Friend Class MediaCreationPresenter
#Region "Public"

#Region "Methods"

         Public Sub New(ByVal view As IMediaInformationView, ByVal burningImagesStateParam As BindingList(Of ClientQueryDataSet.ImagesRow))
            __View = view

            AddHandler __View.ViewLoad, AddressOf __View_Load

            BurningImagesState = burningImagesStateParam

            AddHandler BurningImagesState.ListChanged, AddressOf burningImagesState_ListChanged
         End Sub

         Public Sub SetCurrentPatient(ByVal patientName As String)
            If String.IsNullOrEmpty(__View.MediaTitle) Then
              For Each invalidChar As Char In Path.GetInvalidFileNameChars()
                patientName = patientName.Replace(invalidChar, ControlChars.NullChar)
              Next invalidChar

              patientName = patientName.Replace("^"c, " "c)

              If patientName.Length > 16 Then
                patientName = patientName.Substring(0, 16)
              End If

              __View.MediaTitle = patientName
            End If
         End Sub

#End Region

#Region "Properties"

         Private privateBurningImagesState As BindingList(Of ClientQueryDataSet.ImagesRow)
         Public Property BurningImagesState() As BindingList(Of ClientQueryDataSet.ImagesRow)
            Get
               Return privateBurningImagesState
            End Get
            Private Set(ByVal value As BindingList(Of ClientQueryDataSet.ImagesRow))
               privateBurningImagesState = value
            End Set
         End Property

#End Region

#Region "Events"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

         Public Event ClearInstances As EventHandler

#End Region

#End Region

#Region "Protected"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Events"

#End Region

#Region "Data Members"

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "Private"

#Region "Methods"

         Private Function CreateWorkstationScp() As ScpInfo
            Dim wsAE As DicomAE = WorkstationShellController.Instance.WorkstationSettings.WorkstationDicomServer


            If Nothing IsNot wsAE Then
                Return New ScpInfo(wsAE.AE, wsAE.IPAddress, wsAE.Port, wsAE.Timeout, wsAE.UseTls)
            Else
              Return Nothing
            End If
         End Function

         Private Function GetPacs() As ScpInfo()
            Dim pacs As New List(Of ScpInfo)()


            If Nothing IsNot __WorkstationScp Then
              pacs.Add(__WorkstationScp)
            End If

            pacs.AddRange(ConfigurationData.PACS)

            Return pacs.ToArray()
         End Function

         Private Sub SetViewPacs()
            __View.SetPacsServers(GetPacs())

            If Nothing IsNot __WorkstationScp Then
              __View.SelectedServer = __WorkstationScp
            End If
         End Sub

         Private Sub UpdateViewUI()
            If __Busy OrElse BurningImagesState.Count = 0 OrElse __View.MediaTitle.Length = 0 OrElse (Not String.IsNullOrEmpty(ValidateMediaTitle(__View.MediaTitle))) OrElse __View.SelectedServer Is Nothing Then
              __View.CanSendCreateRequest = False
            Else
              __View.CanSendCreateRequest = True
            End If

            If __Busy OrElse __View.SelectedServer Is Nothing Then
              __View.CanVerify = False
            Else
              __View.CanVerify = True
            End If
         End Sub

         Private Function ValidateMediaTitle(ByVal mediaTitle As String) As String
            If mediaTitle.Length <= 16 Then
              Return Nothing
            Else
              Return "Value can't be more than 16 characters."
            End If
         End Function

         Private Sub OnClearInstances()
            If Nothing IsNot ClearInstancesEvent Then
              RaiseEvent ClearInstances(Me, EventArgs.Empty)
            End If
         End Sub

#End Region

#Region "Properties"

         Private private__View As IMediaInformationView
         Private Property __View() As IMediaInformationView
            Get
               Return private__View
            End Get
            Set(ByVal value As IMediaInformationView)
               private__View = value
            End Set
         End Property

         Private private__WorkstationScp As ScpInfo
         Private Property __WorkstationScp() As ScpInfo
            Get
               Return private__WorkstationScp
            End Get
            Set(ByVal value As ScpInfo)
               private__WorkstationScp = value
            End Set
         End Property

         Private privateBusy As Boolean
         Private Property __Busy() As Boolean
            Get
               Return privateBusy
            End Get
            Set(ByVal value As Boolean)
               privateBusy = value
            End Set
         End Property

#End Region

#Region "Events"

         Private Sub __View_Load(ByVal sender As Object, ByVal e As EventArgs)
            __WorkstationScp = CreateWorkstationScp()

            __View.Initialize(System.Enum.GetValues(GetType(MediaType)).OfType(Of MediaType)().ToArray(), New RequestPriority() {RequestPriority.High, RequestPriority.Medium, RequestPriority.Low})

            __View.ClearInstancesAfterRequest = True
            __View.MediaType = MediaType.Default
            __View.NumberOfCopies = 1
            __View.Prioirty = RequestPriority.Medium

            AddHandler __View.SendMediaCreationRequest, AddressOf __View_SendMediaCreationRequest
            AddHandler __View.VerifySelectedServer, AddressOf __View_VirifySelectedServer
            AddHandler __View.MediaTitleChanged, AddressOf __View_MediaTitleChanged
            AddHandler __View.SelectedServerChanged, AddressOf __View_SelectedServerChanged

            SetViewPacs()

            AddHandler ConfigurationData.ValueChanged, AddressOf ConfigurationData_ValueChanged

            UpdateViewUI()
         End Sub

         Private Sub ConfigurationData_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            SetViewPacs()
         End Sub

         Private Sub __View_VirifySelectedServer(ByVal sender As Object, ByVal e As EventArgs)
            Dim scu As MediaCreationManagementScu


            __Busy = True

            Try
               UpdateViewUI()

               scu = CreateMediaScu()

               Try
                 scu.TestConnection()

                 __View.ReportServerVerificationSuccess()
               Catch exception As Exception
                 __View.ReportServerVerificationFailure(GetFormattedErrorMessage(exception, "Verification Failed."))
               End Try

            Finally
               __Busy = False
               UpdateViewUI()
            End Try

         End Sub

         Private Sub __View_SendMediaCreationRequest(ByVal sender As Object, ByVal e As EventArgs)
            Dim scu As MediaCreationManagementScu
            Dim referencedSops As List(Of MediaCreationReferencedSop)

            __Busy = True

            Try
               UpdateViewUI()
               scu = CreateMediaScu()

               scu.MediaSopInstanceUID = Utils.GenerateDicomUniqueIdentifier()
               scu.NumberOfCopies = __View.NumberOfCopies
               scu.Priority = __View.Prioirty
               scu.MediaFileSetID = __View.MediaTitle
               scu.LabelText = __View.LabelText
               scu.IncludeDisplayApplication = If((__View.IncludeDisplayApplication), YesNo.Yes, YesNo.No)

               referencedSops = New List(Of MediaCreationReferencedSop)()

               For Each image As ClientQueryDataSet.ImagesRow In BurningImagesState
                 Dim sop As New MediaCreationReferencedSop()


                 sop.SopInstance.ReferencedSopInstanceUid = image.SOPInstanceUID
                 sop.SopInstance.ReferencedSopClassUid = image.SOPClassUID
                 sop.RequestedMediaApplicationProfile = GetProfile()

                 referencedSops.Add(sop)
               Next image

               Try
                Dim mediaObject As MediaCreationManagement = scu.CreateMedia(referencedSops)


                If mediaObject.ExecutionStatus Is Nothing OrElse mediaObject.ExecutionStatus.ExecutionStatus Is Nothing Then
                  scu.UpdateMediaObjectStatus(mediaObject)
                End If

                If mediaObject.ExecutionStatus.ExecutionStatus.Value <> ExecutionStatus.Failure Then
                  __View.ReportMediaCreationSuccess()
                Else
                  __View.ReportMediaCreationFailure("Request sent but failed to execute on the server. Server status is:" & Constants.vbLf + mediaObject.ExecutionStatus.ExecutionStatusInfo.ToString())
                End If

                 __View.MediaTitle = String.Empty

                 If __View.ClearInstancesAfterRequest Then
                   Try
                     OnClearInstances()
                   Catch
                   End Try
                 End If
               Catch exception As Exception
                 __View.ReportMediaCreationFailure(GetFormattedErrorMessage(exception, "Media Creation Failed"))
               End Try
            Finally
               __Busy = False
               UpdateViewUI()
            End Try
         End Sub

         Private Function CreateMediaScu() As MediaCreationManagementScu
            Dim scp As DicomScp
            Dim scu As MediaCreationManagementScu


            scp = New DicomScp(Utils.ResolveIPAddress(__View.SelectedServer.Address), __View.SelectedServer.AETitle, __View.SelectedServer.Port)

            scu = New MediaCreationManagementScu(ConfigurationData.WorkstationClient.AETitle, scp)

            Return scu
         End Function


         Private Function GetFormattedErrorMessage(ByVal exception As Exception, ByVal baseMessage As String) As String
            If TypeOf exception Is Leadtools.Dicom.Scu.Common.ClientConnectionException Then
              baseMessage = String.Format("{0}" & Constants.vbLf & "{1}" & Constants.vbLf & "DICOM Code: {2}" & Constants.vbLf & "{3}", baseMessage, exception.Message, (CType(exception, Leadtools.Dicom.Scu.Common.ClientConnectionException)).Code, DicomException.GetCodeMessage((CType(exception, Leadtools.Dicom.Scu.Common.ClientConnectionException)).Code))
            ElseIf TypeOf exception Is Leadtools.Dicom.Scu.Common.ClientAssociationException Then
              baseMessage = String.Format("{0}" & Constants.vbLf & "{1}" & Constants.vbLf & "DICOM Reason: {2}" & Constants.vbLf & "{3}", baseMessage, exception.Message, (CType(exception, Leadtools.Dicom.Scu.Common.ClientAssociationException)).Reason, WorkstationUtils.GetAssociationReasonMessage((CType(exception, Leadtools.Dicom.Scu.Common.ClientAssociationException)).Reason))
            ElseIf TypeOf exception Is Leadtools.Dicom.Scu.Common.ClientCommunicationException Then
              baseMessage = baseMessage & Constants.vbLf + exception.Message + Constants.vbLf & "DICOM Status: " & (CType(exception, Leadtools.Dicom.Scu.Common.ClientCommunicationException)).Status
            Else
              baseMessage = baseMessage & Constants.vbLf + exception.Message
            End If

            Return baseMessage
         End Function



         Private Function GetProfile() As String
            Select Case __View.MediaType
              Case MediaType.CD
                Return "STD-GEN-CD"

              Case MediaType.DVD
                Return "STD-GEN-DVD-RAM"

              Case Else
                Return Nothing
            End Select
         End Function

         Private Sub __View_SelectedServerChanged(ByVal sender As Object, ByVal e As EventArgs)
            UpdateViewUI()
         End Sub

         Private Sub __View_MediaTitleChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim errorText As String


            errorText = ValidateMediaTitle(__View.MediaTitle)

            If Nothing IsNot errorText Then
              __View.MediaTitleValidationError(errorText)
            End If

            UpdateViewUI()
         End Sub

         Private Sub burningImagesState_ListChanged(ByVal sender As Object, ByVal e As ListChangedEventArgs)
            UpdateViewUI()
         End Sub

#End Region

#Region "Data Members"



#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "internal"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Events"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

#End Region

#End Region
   End Class

   Public Enum MediaType
     [Default]
     CD
     DVD
   End Enum
End Namespace
