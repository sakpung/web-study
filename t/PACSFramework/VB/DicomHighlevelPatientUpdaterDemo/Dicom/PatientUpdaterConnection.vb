' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Dicom
Imports Leadtools.Dicom.Scu.Common

Namespace DicomDemo.Dicom
   Public Class PatientUpdaterConnection : Inherits DicomConnection
        Private Shadows _Rejected As Boolean = False

        Public Overloads ReadOnly Property Rejected() As Boolean
            Get
                Return _Rejected
            End Get
        End Property

        Private _Reason As String

      Public ReadOnly Property Reason() As String
         Get
            Return _Reason
         End Get
      End Property

      Protected Overrides Sub OnReceiveAssociateReject(ByVal result As DicomAssociateRejectResultType, ByVal source As DicomAssociateRejectSourceType, ByVal reason As DicomAssociateRejectReasonType)
         MyBase.OnReceiveAssociateReject(result, source, reason)
         _Rejected = True
         Select Case reason
            Case DicomAssociateRejectReasonType.Called
               _Reason = "Called AE Title not recognized."
            Case DicomAssociateRejectReasonType.Calling
               _Reason = "Calling AE Title not recognized."
            Case DicomAssociateRejectReasonType.Congestion
               _Reason = "Temporary congestion"
            Case Else
               _Reason = "Uknown association rejection."
         End Select
      End Sub
   End Class
End Namespace
