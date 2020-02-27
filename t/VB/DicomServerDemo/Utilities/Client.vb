' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.Threading
Imports System.Collections.Generic

Imports Leadtools.Dicom

Namespace DicomDemo
   Public Class Client : Inherits DicomNet
      Private _Timer As DicomTimer
      Private server As Server
      Private procThread As Thread = Nothing
        Dim action As DicomAction = Nothing

      Public ReadOnly Property Timer() As DicomTimer
         Get
            Return _Timer
         End Get
      End Property

#If Not LEADTOOLS_V20_OR_LATER Then
      Public Sub New(ByVal server As Server)
         MyBase.New(Nothing, DicomNetSecurityeMode.None)
         Me.server = server
         _Timer = New DicomTimer(Me, 30)
      End Sub
#Else
      Public Sub New(ByVal server As Server)
         MyBase.New(Nothing, DicomNetSecurityMode.None)
         Me.server = server
         _Timer = New DicomTimer(Me, 30)
      End Sub
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then

      'Use this constructor for TLS secure communication
      Public Sub New(ByVal server As Server, ByVal reserved As Boolean)
#If Not LEADTOOLS_V20_OR_LATER Then
         MyBase.New(Nothing, DicomNetSecurityeMode.Tls, reserved)
#Else
         MyBase.New(Nothing, DicomNetSecurityMode.Tls, reserved)
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then
         Me.server = server
         _Timer = New DicomTimer(Me, 30)
      End Sub
      Protected Overrides Function OnPrivateKeyPassword(ByVal encryption As Boolean) As String
         Return "test"
      End Function

      Protected Overrides Sub OnReceiveAssociateRequest(ByVal association As DicomAssociate)
         server.mf.UpdateClient(Me, association.Calling, "Associate")
         server.mf.Log("ASSOCIATE-REQUEST", "Received from " & association.Calling)

         If (Not server.usersDB.FindUser(PeerAddress, association.Calling)) Then
            SendAssociateReject(DicomAssociateRejectResultType.Permanent, DicomAssociateRejectSourceType.User, DicomAssociateRejectReasonType.Calling)
            server.mf.Log("ASSOCIATE-REJECT", "Invalid calling AE Title: " & association.Calling)
         Else
            server.DoAssociateRequest(Me, association)
            server.mf.EnableTimer(Me, association.Calling, True)
            server.mf.Log("ASSOCIATE-REQUEST", "Association accepted from " & association.Calling & " (" & PeerAddress & ")")
         End If
      End Sub

      Protected Overrides Sub OnReceiveReleaseRequest()
         server.Clients.Remove(PeerAddress)
         server.mf.RemoveClient(Me)
         SendReleaseResponse()
      End Sub

      Protected Overrides Sub OnReceiveData(ByVal presentationID As Byte, ByVal cs As DicomDataSet, ByVal ds As DicomDataSet)
         If Logger.DisableLogging = False Then
                    If server.SaveCSReceived AndAlso Not cs Is Nothing Then
            server.LogCS(Me, cs)
         End If
         If (cs IsNot Nothing) Then
            cs.Dispose()
         End If
         End If
      End Sub

      Protected Sub StartAction(ByVal action As DicomAction)
         If Not procThread Is Nothing AndAlso procThread.IsAlive Then
            procThread.Abort()
            procThread = Nothing
         End If
         procThread = New Thread(AddressOf action.DoAction)
         procThread.Start()
      End Sub

      Protected Overrides Sub OnReceiveCEchoRequest(ByVal presentationID As Byte, ByVal messageID As Integer, ByVal affectedClass As String)
         Dim action As DicomAction = server.InitAction("C-ECHO-REQUEST", ProcessType.EchoRequest, Me, Nothing)

         action.PresentationID = presentationID
         action.MessageID = messageID
         action.Class = affectedClass
         StartAction(action)
      End Sub

      Protected Overrides Sub OnReceiveCStoreRequest(ByVal presentationID As Byte, ByVal messageID As Integer, ByVal affectedClass As String, ByVal instance As String, ByVal priority As DicomCommandPriorityType, ByVal moveAE As String, ByVal moveMessageID As Integer, ByVal dataSet As DicomDataSet)
         action = server.InitAction("C-STORE-REQUEST", ProcessType.StoreRequest, Me, dataSet)

         action.PresentationID = presentationID
         action.MessageID = messageID
         action.Class = affectedClass
         action.Instance = instance
         action.Priority = priority
         action.MoveAETitle = moveAE
         action.MoveMessageID = moveMessageID
         StartAction(action)
         dataSet.Dispose()
      End Sub

      Protected Overrides Sub OnReceiveCFindRequest(ByVal presentationID As Byte, ByVal messageID As Integer, ByVal affectedClass As String, ByVal priority As DicomCommandPriorityType, ByVal dataSet As DicomDataSet)
         action = server.InitAction("C-FIND-REQUEST", ProcessType.FindRequest, Me, dataSet)

         action.PresentationID = presentationID
         action.MessageID = messageID
         action.Class = affectedClass
         action.Priority = priority
         StartAction(action)
         dataSet.Dispose()
      End Sub

      Protected Overrides Sub OnReceiveCMoveRequest(ByVal presentationID As Byte, ByVal messageID As Integer, ByVal affectedClass As String, ByVal priority As DicomCommandPriorityType, ByVal moveAE As String, ByVal dataSet As DicomDataSet)
         action = server.InitAction("C-MOVE-REQUEST", ProcessType.MoveRequest, Me, dataSet)

         action.PresentationID = presentationID
         action.MessageID = messageID
         action.Class = affectedClass
         action.Priority = priority
         action.MoveAETitle = moveAE
         StartAction(action)
         dataSet.Dispose()
      End Sub

      Protected Overrides Sub OnReceiveCCancelRequest(ByVal presentationID As Byte, ByVal messageID As Integer)
         If Not procThread Is Nothing AndAlso procThread.IsAlive Then
            procThread.Abort()
            procThread = Nothing
         End If
      End Sub

      Public Sub Terminate()
         If action IsNot Nothing Then
            action.Close()
         End If
         If procThread IsNot Nothing AndAlso procThread.IsAlive Then
            procThread.Abort()
            procThread = Nothing
         End If
      End Sub
   End Class
End Namespace
