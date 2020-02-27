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
Imports Leadtools.Dicom.Common.Attributes

Namespace DicomDemo.Dicom
   <Instance(DicomClassType.Undefined, NActionScu.PatientUpdateClass)> _
   Public Class MergeStudy : Inherits PatientUpdate
      Private _PatientId As String = String.Empty

      <Element(DicomTag.PatientID)> _
      Public Property PatientId() As String
         Get
            Return _PatientId
         End Get
         Set(ByVal value As String)
            _PatientId = Value
         End Set
      End Property

      Private _StudyInstanceUID As String

      <Element(DicomTag.StudyInstanceUID)> _
      Public Property StudyInstanceUID() As String
         Get
            Return _StudyInstanceUID
         End Get
         Set(ByVal value As String)
            _StudyInstanceUID = Value
         End Set
      End Property

      Private _PatientToMerge As List(Of MergePatientSequence) = New List(Of MergePatientSequence)()

      <Element(DicomTag.ReferencedPatientSequence)> _
      Public Property PatientToMerge() As List(Of MergePatientSequence)
         Get
            Return _PatientToMerge
         End Get
         Set(ByVal value As List(Of MergePatientSequence))
            _PatientToMerge = Value
         End Set
      End Property
   End Class
End Namespace
