' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text

Imports Leadtools
Imports Leadtools.Dicom
Imports Leadtools.MedicalViewer
Imports Leadtools.Dicom.Scu
Imports Leadtools.Dicom.Scu.Common
Imports Leadtools.DicomDemos

Namespace DicomDemo
    Friend Class MyQueryRetrieveScu
        Inherits QueryRetrieveScu
        Private Const _sNewlineTab As String = Constants.vbCrLf & Constants.vbTab
        Public _mainForm As MainForm = Nothing


        ' Summary:
        '     Initializes a new instance of the Leadtools.Dicom.Scu.QueryRetrieveScu class.
        Public Sub New()
            MyBase.New()
        End Sub

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

      Protected Overrides Sub OnClose(ByVal [error] As DicomExceptionCode, ByVal net As DicomNet)
         _mainForm.LogText("Server Closed Connection", String.Empty)
         'base.OnClose(error, net);
      End Sub

        Protected Overrides Sub OnReceive(ByVal [error] As DicomExceptionCode, ByVal pduType As DicomPduType, ByVal buffer As IntPtr, ByVal bytes As Integer)
            ' Uncomment the lines below to log the OnReceive events
            'if ((_mainForm != null) && (_mainForm._mySettings._settings.logLowLevel))
            '{
            '   string sMsg =
            '      _sNewlineTab + "error:\t" + error.ToString() +
            '      _sNewlineTab + "pduType:\t" + pduType.ToString() +
            '      _sNewlineTab + "bytes:\t" + bytes.ToString();

            '   _mainForm.LogText("OnReceive", sMsg, System.Drawing.Color.Green);
            '}
            MyBase.OnReceive([error], pduType, buffer, bytes)
        End Sub

        Protected Overrides Sub OnReceiveCStoreRequest(ByVal scu As QueryRetrieveScu, ByVal presentationID As Byte, ByVal messageID As Integer, ByVal affectedClass As String, ByVal instance As String, ByVal priority As DicomCommandPriorityType, ByVal moveAE As String, ByVal moveMessageID As Integer, ByVal dataSet As DicomDataSet)
            If (_mainForm IsNot Nothing) AndAlso (_mainForm._mySettings.LogLowLevel) Then
                Dim sMsg As String = _sNewlineTab & "scu:" & Constants.vbTab + scu.ToString() & _sNewlineTab & "presentationID:" & Constants.vbTab + presentationID.ToString() & _sNewlineTab & "messageID:" & Constants.vbTab + messageID.ToString() & _sNewlineTab & "affectedClass:" & Constants.vbTab & affectedClass & _sNewlineTab & "instance:" & Constants.vbTab & instance & _sNewlineTab & "priority:" & Constants.vbTab + priority.ToString() & _sNewlineTab & "moveAE:" & Constants.vbTab & moveAE & _sNewlineTab & "moveMessageID:" & Constants.vbTab + moveMessageID.ToString()

                _mainForm.LogText("OnReceiveCStoreRequest", sMsg, System.Drawing.Color.Green)
            End If
            MyBase.OnReceiveCStoreRequest(scu, presentationID, messageID, affectedClass, instance, priority, moveAE, moveMessageID, dataSet)
        End Sub

        Protected Overrides Sub OnReceiveCFindResponse(ByVal presentationID As Byte, ByVal messageID As Integer, ByVal affectedClass As String, ByVal status As DicomCommandStatusType, ByVal dataSet As DicomDataSet)
            If (_mainForm IsNot Nothing) AndAlso (_mainForm._mySettings.LogLowLevel) Then
                Dim sMsg As String = _sNewlineTab & "presentationID:" & Constants.vbTab + presentationID.ToString() & _sNewlineTab & "messageID:" & Constants.vbTab + messageID.ToString() & _sNewlineTab & "affectedClass:" & Constants.vbTab & affectedClass & _sNewlineTab & "status:" & Constants.vbTab + status.ToString()

                _mainForm.LogText("OnReceiveCFindResponse", sMsg, System.Drawing.Color.Green)
            End If
            MyBase.OnReceiveCFindResponse(presentationID, messageID, affectedClass, status, dataSet)
        End Sub

        Protected Overrides Sub OnReceiveReleaseResponse()
            If (_mainForm IsNot Nothing) AndAlso (_mainForm._mySettings.LogLowLevel) Then
                _mainForm.LogText("OnReceiveReleaseResponse", String.Empty, System.Drawing.Color.Green)
            End If
            MyBase.OnReceiveReleaseResponse()
        End Sub

        Protected Overrides Sub OnReceiveAssociateAccept(ByVal association As DicomAssociate)
            If (_mainForm IsNot Nothing) AndAlso (_mainForm._mySettings.LogLowLevel) Then
                _mainForm.LogText("OnReceiveAssociateAccept", String.Empty, System.Drawing.Color.Green)
            End If
            MyBase.OnReceiveAssociateAccept(association)
        End Sub
    End Class
End Namespace
