' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ComponentModel
Imports Leadtools.Dicom.Common.DataTypes

Namespace DicomDemo.Queries
    Public Class BroadBasedQuery

#If (LEADTOOLS_V18_OR_LATER) Then
        Private _ScheduledProcedureStepStartDate As DateRange = New DateRange()

        <DisplayName("Scheduled Procedure Step Start Date")> _
        Public Property ScheduledProcedureStepStartDate As DateRange
            Get
                Return _ScheduledProcedureStepStartDate
            End Get
            Set(value As DateRange)
                _ScheduledProcedureStepStartDate = value
            End Set
        End Property
#Else
       Private _ScheduledProcedureStepStartDate As DateTime

        <DisplayName("Scheduled Procedure Step Start Date")> _
        Public Property ScheduledProcedureStepStartDate() As DateTime
            Get
                Return _ScheduledProcedureStepStartDate
            End Get
            Set(value As DateTime)
                _ScheduledProcedureStepStartDate = Value
            End Set
        End Property
#End If

        Private _Modality As String

        Public Property Modality() As String
            Get
                Return _Modality
            End Get
            Set(value As String)
                _Modality = value
            End Set
        End Property

        Private _ScheduledStationAeTitle As String

        <DisplayName("Scheduled Station AE")> _
        Public Property ScheduledStationAeTitle() As String
            Get
                Return _ScheduledStationAeTitle
            End Get
            Set(value As String)
                _ScheduledStationAeTitle = value
            End Set
        End Property
    End Class
End Namespace
