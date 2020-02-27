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

	  Protected Overrides Function OnPrivateKeyPassword(ByVal encryption As Boolean) As String
		 Return "test"
	  End Function

	  Protected Overrides Sub OnReceiveAssociateRequest(ByVal association As DicomAssociate)
		 server.DoAssociateRequest(Me, association)
	  End Sub

	   Protected Overrides Sub OnReceiveReleaseRequest()
		   server.Clients.Remove(PeerAddress)
		   SendReleaseResponse()
	   End Sub

	  Protected Sub StartAction(ByVal action As DicomAction)
		 If Not procThread Is Nothing AndAlso procThread.IsAlive Then
			procThread.Abort()
			procThread = Nothing
		 End If
		 procThread = New Thread(AddressOf action.DoAction)
		 procThread.Start()
	  End Sub

	  '
	   '* Handles a CEcho request
	   '
	  Protected Overrides Sub OnReceiveCEchoRequest(ByVal presentationID As Byte, ByVal messageID As Integer, ByVal affectedClass As String)
		 Dim action As DicomAction = server.InitAction("C-ECHO-REQUEST", ProcessType.EchoRequest, Me, Nothing)

		 action.PresentationID = presentationID
		 action.MessageID = messageID
		 action.Class = affectedClass
		 StartAction(action)
	  End Sub

	  '
	   '* Handles a CFind request
	   '
	  Protected Overrides Sub OnReceiveCFindRequest(ByVal presentationID As Byte, ByVal messageID As Integer, ByVal affectedClass As String, ByVal priority As DicomCommandPriorityType, ByVal dataSet As DicomDataSet)
		 Dim action As DicomAction = server.InitAction("C-FIND-REQUEST", ProcessType.FindRequest, Me, dataSet)

		 action.PresentationID = presentationID
		 action.MessageID = messageID
		 action.Class = affectedClass
		 action.Priority = priority
       StartAction(action)
       dataSet.Dispose()
     End Sub

      Protected Overrides Sub OnReceiveData(ByVal presentationID As Byte, ByVal cs As Leadtools.Dicom.DicomDataSet, ByVal ds As Leadtools.Dicom.DicomDataSet)
         MyBase.OnReceiveData(presentationID, cs, ds)

         If (Nothing IsNot cs) Then
            cs.Dispose()
         End If
      End Sub
   End Class
End Namespace
