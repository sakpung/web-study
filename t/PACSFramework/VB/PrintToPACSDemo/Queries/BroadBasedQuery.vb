' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.Text
Imports System.ComponentModel
Imports Leadtools.Dicom.Common.DataTypes
Imports Leadtools.Dicom.Common.Extensions
Imports Leadtools.Dicom

Namespace PrintToPACSDemo.Queries
   Public Class BroadBasedQuery

      Private _ScheduledProcedureStepStartDate As New DateRange()

      <DisplayName("Scheduled Procedure Step Start Date"), TypeConverter(GetType(ExpandableObjectConverter))> _
      Public Property ScheduledProcedureStepStartDate() As DateRange
         Get
            Return _ScheduledProcedureStepStartDate
         End Get
         Set(ByVal value As DateRange)
            _ScheduledProcedureStepStartDate = value
         End Set
      End Property

      Private _Modality As String

      <Browsable(True), Category("Study"), Description("Modalities in Study"), DisplayName("Modalities in Study"), TypeConverter(GetType(DicomModalityConvertor))> _
      Public Property Modality() As String
         Get
            Return _Modality
         End Get
         Set(ByVal value As String)
            _Modality = value
         End Set
      End Property

      Private _ScheduledStationAeTitle As String

      <DisplayName("Scheduled Station AE")> _
      Public Property ScheduledStationAeTitle() As String
         Get
            Return _ScheduledStationAeTitle
         End Get
         Set(ByVal value As String)
            _ScheduledStationAeTitle = value
         End Set
      End Property
   End Class
End Namespace
