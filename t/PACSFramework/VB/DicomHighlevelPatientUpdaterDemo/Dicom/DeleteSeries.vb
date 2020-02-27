' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Dicom
Imports Leadtools.Dicom.Common.Attributes
Imports Leadtools.Dicom.Common.Extensions

Namespace DicomDemo.Dicom
   <Instance(DicomClassType.Undefined, NActionScu.PatientUpdateClass)> _
   Public Class DeleteSeries : Inherits PatientUpdate
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
