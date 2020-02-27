' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Leadtools.Dicom.Common.DataTypes
Imports Leadtools.Dicom.Common.Extensions
Imports Leadtools.Dicom
Imports System.ComponentModel
Imports Leadtools.Dicom.Common.Editing.Converters

Namespace DicomDemo.Queries
	Friend Class PatientBasedQuery
		Private _PatientName As PersonName = New PersonName()

		<TypeConverter(GetType(PersonNameConverter)), DisplayName("Person Name")> _
		Public Property PatientName() As PersonName
			Get
				Return _PatientName
			End Get
			Set
				_PatientName = Value
			End Set
		End Property

		Private _PatientId As String = String.Empty

		<DisplayName("Patient ID")> _
		Public Property PatientId() As String
			Get
				Return _PatientId
			End Get
			Set
				_PatientId = Value
			End Set
		End Property

		Private _AccessionNumber As String = String.Empty

		<DisplayName("Accession #")> _
		Public Property AccessionNumber() As String
			Get
				Return _AccessionNumber
			End Get
			Set
				_AccessionNumber = Value
			End Set
		End Property

		Private _RequestedProcedureId As String = String.Empty

		<DisplayName("Requested Procedure ID")> _
		Public Property RequestedProcedureId() As String
			Get
				Return _RequestedProcedureId
			End Get
			Set
				_RequestedProcedureId = Value
			End Set
		End Property
	End Class
End Namespace
