' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel
Imports Leadtools.Dicom.Common.Attributes
Imports Leadtools.Dicom
Imports Leadtools.Dicom.Common.Extensions
Imports Leadtools.Dicom.Common.DataTypes
Imports Leadtools.Dicom.Common.Editing.Converters

Namespace DicomDemo.Dicom
   <Instance(DicomClassType.Undefined, NActionScu.PatientUpdateClass)> _
   Public Class CopyStudy : Inherits PatientUpdate
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

      Private _Name As PersonName = New PersonName()

      <Element(DicomTag.PatientName), TypeConverter(GetType(PersonNameConverter))> _
      Public Property Name() As PersonName
         Get
            Return _Name
         End Get
         Set(ByVal value As PersonName)
            _Name = Value
         End Set
      End Property

      Private _Sex As String

      <Element(DicomTag.PatientSex)> _
      Public Property Sex() As String
         Get
            Return _Sex
         End Get
         Set(ByVal value As String)
            _Sex = Value
         End Set
      End Property

      Private _Birthdate As Nullable(Of DateTime)

      <Element(DicomTag.PatientBirthDate)> _
      Public Property Birthdate() As Nullable(Of DateTime)
         Get
            Return _Birthdate
         End Get
         Set(ByVal value As Nullable(Of DateTime))
            _Birthdate = Value
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
