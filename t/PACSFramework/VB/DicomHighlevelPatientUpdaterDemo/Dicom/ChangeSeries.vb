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

Namespace DicomDemo.Dicom
   <Instance(DicomClassType.Undefined, NActionScu.PatientUpdateClass)> _
   Public Class ChangeSeries : Inherits PatientUpdate
      Private _SeriesDate As Nullable(Of DateTime)

      <Element(DicomTag.SeriesDate)> _
      Public Property SeriesDate() As Nullable(Of DateTime)
         Get
            Return _SeriesDate
         End Get
         Set(ByVal value As Nullable(Of DateTime))
            _SeriesDate = Value
         End Set
      End Property

      Private _SeriesDescription As String

      <Element(DicomTag.SeriesDescription)> _
      Public Property SeriesDescription() As String
         Get
            Return _SeriesDescription
         End Get
         Set(ByVal value As String)
            _SeriesDescription = Value
         End Set
      End Property

      Private _Modality As String

      <Element(DicomTag.Modality)> _
      Public Property Modality() As String
         Get
            Return _Modality
         End Get
         Set(ByVal value As String)
            _Modality = Value
         End Set
      End Property

      Private _SeriesInstanceUID As String

      <Element(DicomTag.SeriesInstanceUID)> _
      Public Property SeriesInstanceUID() As String
         Get
            Return _SeriesInstanceUID
         End Get
         Set(ByVal value As String)
            _SeriesInstanceUID = Value
         End Set
      End Property
   End Class
End Namespace
