' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Leadtools.Dicom.Common.Extensions
Imports Leadtools.Dicom
Imports Leadtools.Dicom.Common.DataTypes

Namespace DicomDemo
   Public Class MppsIodInfo
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

      Private _ReferencedStudySequence As List(Of SopInstanceReference)

      <Element(DicomTag.ReferencedStudySequence)> _
      Public Property ReferencedStudySequence() As List(Of SopInstanceReference)
         Get
            Return _ReferencedStudySequence
         End Get
         Set(ByVal value As List(Of SopInstanceReference))
            _ReferencedStudySequence = Value
         End Set
      End Property

      Private _AccessionNumber As String

      <Element(DicomTag.AccessionNumber)> _
      Public Property AccessionNumber() As String
         Get
            Return _AccessionNumber
         End Get
         Set(ByVal value As String)
            _AccessionNumber = Value
         End Set
      End Property

      Private _RequestAttributesSequence As List(Of RequestAttributes)

      <Element(DicomTag.RequestAttributesSequence)> _
      Public Property RequestAttributesSequence() As List(Of RequestAttributes)
         Get
            Return _RequestAttributesSequence
         End Get
         Set(ByVal value As List(Of RequestAttributes))
            _RequestAttributesSequence = Value
         End Set
      End Property

      Private _StudyID As String

      <Element(DicomTag.StudyID)> _
      Public Property StudyID() As String
         Get
            Return _StudyID
         End Get
         Set(ByVal value As String)
            _StudyID = Value
         End Set
      End Property

      Private _PerformedProcedureStepID As String

      <Element(DicomTag.PerformedProcedureStepID)> _
      Public Property PerformedProcedureStepID() As String
         Get
            Return _PerformedProcedureStepID
         End Get
         Set(ByVal value As String)
            _PerformedProcedureStepID = Value
         End Set
      End Property

      Private _PerformedProcedureStepStartDate As Nullable(Of DateTime)

      <Element(DicomTag.PerformedProcedureStepStartDate)> _
      Public Property PerformedProcedureStepStartDate() As Nullable(Of DateTime)
         Get
            Return _PerformedProcedureStepStartDate
         End Get
         Set(ByVal value As Nullable(Of DateTime))
            _PerformedProcedureStepStartDate = Value
         End Set
      End Property

      Private _PerformedProcedureStepStartTime As Nullable(Of DateTime)

      <Element(DicomTag.PerformedProcedureStepStartTime)> _
      Public Property PerformedProcedureStepStartTime() As Nullable(Of DateTime)
         Get
            Return _PerformedProcedureStepStartTime
         End Get
         Set(ByVal value As Nullable(Of DateTime))
            _PerformedProcedureStepStartTime = Value
         End Set
      End Property

      Private _PerformedProcedureStepDescription As String

      <Element(DicomTag.PerformedProcedureStepDescription)> _
      Public Property PerformedProcedureStepDescription() As String
         Get
            Return _PerformedProcedureStepDescription
         End Get
         Set(ByVal value As String)
            _PerformedProcedureStepDescription = Value
         End Set
      End Property

      Private _ProcedureCodeSequence As List(Of CodeSequence) = New List(Of CodeSequence)()

      <Element(DicomTag.ProcedureCodeSequence)> _
      Public Property ProcedureCodeSequence() As List(Of CodeSequence)
         Get
            Return _ProcedureCodeSequence
         End Get
         Set(ByVal value As List(Of CodeSequence))
            _ProcedureCodeSequence = Value
         End Set
      End Property

      Private _ReferencedPerformedProcedureStepSequence As List(Of SopInstanceReference)

      <Element(DicomTag.ReferencedPerformedProcedureStepSequence)> _
      Public Property ReferencedPerformedProcedureStepSequence() As List(Of SopInstanceReference)
         Get
            Return _ReferencedPerformedProcedureStepSequence
         End Get
         Set(ByVal value As List(Of SopInstanceReference))
            _ReferencedPerformedProcedureStepSequence = Value
         End Set
      End Property

      Private _ProtocolName As String

      <Element(DicomTag.ProtocolName)> _
      Public Property ProtocolName() As String
         Get
            Return _ProtocolName
         End Get
         Set(ByVal value As String)
            _ProtocolName = Value
         End Set
      End Property
   End Class
End Namespace
