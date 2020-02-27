' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Dicom
Imports Leadtools.Dicom.Common.Extensions

Namespace DicomDemo.Dicom
   Public Class MergePatientSequence
      Private _PatientId As String = String.Empty

      <Element(DicomTag.PatientID)> _
      Public Property PatientId() As String
         Get
            Return _PatientId
         End Get
         Set(ByVal value As String)
            _PatientId = value
         End Set
      End Property

      Public Sub New(ByVal patientID As String)
         _PatientId = patientID
      End Sub
   End Class
End Namespace
