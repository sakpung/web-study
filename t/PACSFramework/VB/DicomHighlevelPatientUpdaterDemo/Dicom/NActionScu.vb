' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Dicom.Scu.Common
Imports Leadtools.Dicom
Imports Leadtools.Dicom.Scu
Imports Leadtools.Dicom.Common.Attributes
Imports Leadtools.Dicom.Common.Extensions

Namespace DicomDemo.Dicom
    Public Class NActionScu
        Inherits DicomConnection
        Public Shared MessageId As Integer = 0
        Private Shadows _Status As DicomCommandStatusType = DicomCommandStatusType.Success

        Public Const PatientUpdateClass As String = "1.2.840.114257.15.1.3"
        Public Const PatientUpdateInstance As String = "1.2.840.114257.15.1.3.100.1"

        Public Const ChangePatient As Integer = 100
        Public Const DeletePatient As Integer = 101
        Public Const MergePatient As Integer = 102
        Public Const ChangeSeries As Integer = 103
        Public Const DeleteSeries As Integer = 104
        Public Const MergeStudy As Integer = 105
        Public Const MoveStudyToNewPatient As Integer = 106
        Public Const CopyPatient As Integer = 107
        Public Const CopyStudy As Integer = 108
        Public Const MoveSeries As Integer = 109
        Public Const ChangeStudy As Integer = 110
        Public Const DeleteStudy As Integer = 111

        Private _ErrorMessage As String

        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _ErrorMessage
            End Get
        End Property

        Public Sub New()
            MyBase.New()
        End Sub

#If (Not LEADTOOLS_V20_OR_LATER) Then
		Public Sub New(ByVal TemporaryDirectory As String, ByVal SecurityMode As DicomNetSecurityeMode, ByVal openSslContextCreationSettings As DicomOpenSslContextCreationSettings)
			MyBase.New(TemporaryDirectory, SecurityMode, openSslContextCreationSettings)
		End Sub
#Else
        Public Sub New(ByVal TemporaryDirectory As String, ByVal SecurityMode As DicomNetSecurityMode, ByVal openSslContextCreationSettings As DicomOpenSslContextCreationSettings)
            MyBase.New(TemporaryDirectory, SecurityMode, openSslContextCreationSettings)
        End Sub
#End If ' #if !LEADTOOLS_V20_OR_LATER

        Private Function GetDataset(ByVal findObject As Object, ByVal OnBeforeAdd As BeforeAddTagDelegate) As DicomDataSet
            Dim ds As DicomDataSet = Nothing

            ds = New DicomDataSet(TemporaryDirectory)
            ds.Initialize(_CurrentInstance.ClassType, DicomDataSetInitializeType.ExplicitVRLittleEndian)
            ds.Set(OnBeforeAdd, findObject)
            Return ds
        End Function

        Private Function GetFindAttribute(ByVal findObject As Object) As InstanceAttribute
            Dim cfa As InstanceAttribute() = CType(findObject.GetType().GetCustomAttributes(GetType(InstanceAttribute), False), InstanceAttribute())

            If cfa Is Nothing OrElse cfa.Length = 0 Then
                Return Nothing
            End If
            Return cfa(0)
        End Function

        Protected Overrides Function GetPresentationContexts() As List(Of PresentationContext)
            Dim contexts As List(Of PresentationContext) = MyBase.GetPresentationContexts()
            Dim pc As PresentationContext = New PresentationContext(NActionScu.PatientUpdateClass)

            pc.TransferSyntaxes.Add(DicomUidType.ImplicitVRLittleEndian)
            contexts.Add(pc)
            Return contexts
        End Function

        Public Shadows Function SendNActionRequest(Of TQuery)(ByVal Scp As DicomScp, ByVal Query As TQuery, ByVal action As Integer, ByVal instance As String) As DicomCommandStatusType
            Dim ds As DicomDataSet = Nothing

            If Scp Is Nothing Then
                Throw New ArgumentNullException("Scp")
            End If

            If Query Is Nothing Then
                Throw New ArgumentNullException("Query")
            End If

            _ErrorMessage = String.Empty
            Try
                _CurrentInstance = GetFindAttribute(Query)
                If _CurrentInstance Is Nothing Then
                    Throw New InvalidOperationException()
                End If

                ds = GetDataset(Query, Nothing)
                Connect(Scp)
                If parameters.Result Is Nothing Then
                    SendNAction(ds, action, instance)
                Else
                    Throw New ClientAssociationException(parameters.Reason)
                End If
            Catch e As Exception
                _ErrorMessage = e.Message
                _Status = DicomCommandStatusType.Failure
            Finally
                If IsConnected() Then
                    Close()
                End If
                If Not ds Is Nothing Then
                    ds.Dispose()
                    ds = Nothing
                End If
            End Try

            Return _Status
        End Function

        Private Sub SendNAction(ByVal ds As DicomDataSet, ByVal action As Integer, ByVal instance As String)
            Dim pid As Byte = 0
            Dim abstractSyntax As String = String.Empty

            pid = Association.FindAbstract(_CurrentInstance.AbstractSyntax)
            If pid = 0 OrElse Association.GetResult(pid) <> DicomAssociateAcceptResultType.Success Then
                Throw New DicomException("Invalid Abstract Syntax")
            End If
            abstractSyntax = _CurrentInstance.AbstractSyntax
            MyBase.SendNActionRequest(pid, MessageId, _CurrentInstance.AbstractSyntax, instance, action, ds)
            MessageId += 1
            Wait()
            Release()
        End Sub

        Protected Overrides Sub OnReceiveNActionResponse(ByVal presentationID As Byte, ByVal messageID As Integer, ByVal affectedClass As String, ByVal instance As String, ByVal status As DicomCommandStatusType, ByVal action As Integer, ByVal dataSet As DicomDataSet)
            _Status = status
            dicomEventResponse.Set()
        End Sub

        Public Function GetErrorMessage() As String
            If _ErrorMessage = "Invalid Abstract Syntax" Then
                Return "Server doesn't support update action.  Either update client doesn't have permission or the Patient " & "Updater addin is not available.  Please contact your server administrator."
            End If
            Return _ErrorMessage
        End Function
    End Class
End Namespace