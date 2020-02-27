' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Leadtools.Dicom.Scu
Imports Leadtools.Dicom

Namespace DicomDemo
	Public Class MyPerformedProcedureStepScu : Inherits PerformedProcedureStepScu
		Private Const _sNewlineTab As String = Constants.vbCrLf & Constants.vbTab
		Public _mainForm As MainForm = Nothing

		Private _Status As DicomCommandStatusType = DicomCommandStatusType.Success

		Public Property Status() As DicomCommandStatusType
			Get
				Return _Status
			End Get
			Set
				_Status = Value
			End Set
		End Property

		Public Sub New(ByVal mainForm As MainForm)
			MyBase.New()
			_mainForm = mainForm
		End Sub

#If Not LEADTOOLS_V20_OR_LATER Then
      Public Sub New(ByVal mainForm As MainForm, ByVal TemporaryDirectory As String, ByVal SecurityMode As DicomNetSecurityeMode, ByVal openSslContextCreationSettings As DicomOpenSslContextCreationSettings)
         MyBase.New(TemporaryDirectory, SecurityMode, openSslContextCreationSettings)
         _mainForm = mainForm
      End Sub
#Else
      Public Sub New(ByVal mainForm As MainForm, ByVal TemporaryDirectory As String, ByVal SecurityMode As DicomNetSecurityMode, ByVal openSslContextCreationSettings As DicomOpenSslContextCreationSettings)
         MyBase.New(TemporaryDirectory, SecurityMode, openSslContextCreationSettings)
         _mainForm = mainForm
      End Sub
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then

      Protected Overrides Sub OnReceiveNCreateResponse(ByVal presentationID As Byte, ByVal messageID As Integer, ByVal affectedClass As String, ByVal instance As String, ByVal status_Renamed As DicomCommandStatusType, ByVal dataSet As DicomDataSet)
         MyBase.OnReceiveNCreateResponse(presentationID, messageID, affectedClass, instance, status_Renamed, dataSet)
         _Status = status_Renamed
      End Sub

      Protected Overrides Sub OnReceiveNSetResponse(ByVal presentationID As Byte, ByVal messageID As Integer, ByVal affectedClass As String, ByVal instance As String, ByVal status_Renamed As DicomCommandStatusType, ByVal dataSet As DicomDataSet)
         MyBase.OnReceiveNSetResponse(presentationID, messageID, affectedClass, instance, status_Renamed, dataSet)
         _Status = status_Renamed
      End Sub

		Protected Overrides Sub OnReceiveReleaseResponse()
			If (Not _mainForm Is Nothing) AndAlso (_mainForm._mySettings.LogLowLevel) Then
				_mainForm.LogText("OnReceiveReleaseResponse", String.Empty, System.Drawing.Color.Green)
			End If
			MyBase.OnReceiveReleaseResponse()
		End Sub

		Protected Overrides Sub OnReceiveAssociateAccept(ByVal association As DicomAssociate)
			If (Not _mainForm Is Nothing) AndAlso (_mainForm._mySettings.LogLowLevel) Then
				_mainForm.LogText("OnReceiveAssociateAccept", String.Empty, System.Drawing.Color.Green)
			End If
			MyBase.OnReceiveAssociateAccept(association)
		End Sub
	End Class
End Namespace
