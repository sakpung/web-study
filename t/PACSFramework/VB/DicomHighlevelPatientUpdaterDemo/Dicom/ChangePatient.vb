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

#If (LEADTOOLS_V19_OR_LATER) Then
Imports Leadtools.Dicom.Common.DataTypes.PatientUpdater
#End If

Namespace DicomDemo.Dicom
    <Instance(DicomClassType.Undefined, NActionScu.PatientUpdateClass)>
    Public Class ChangePatient : Inherits PatientUpdate
        Private _OriginalPatientId As String = String.Empty

        <Element(DicomTag.OtherPatientIDs)>
        Public Property OriginalPatientId() As String
            Get
                Return _OriginalPatientId
            End Get
            Set(ByVal value As String)
                _OriginalPatientId = value
            End Set
        End Property

        Private _PatientId As String = String.Empty

        <Element(DicomTag.PatientID)>
        Public Property PatientId() As String
            Get
                Return _PatientId
            End Get
            Set(ByVal value As String)
                _PatientId = value
            End Set
        End Property

        Private _Name As New PersonName()

        <Element(DicomTag.PatientName), TypeConverter(GetType(PersonNameConverter))>
        Public Property Name() As PersonName
            Get
                Return _Name
            End Get
            Set(ByVal value As PersonName)
                _Name = value
            End Set
        End Property

        Private _Sex As String

        <Element(DicomTag.PatientSex)>
        Public Property Sex() As String
            Get
                Return _Sex
            End Get
            Set(ByVal value As String)
                _Sex = value
            End Set
        End Property

        Private _Birthdate As Nullable(Of DateTime)

        <Element(DicomTag.PatientBirthDate)>
        Public Property Birthdate() As Nullable(Of DateTime)
            Get
                Return _Birthdate
            End Get
            Set(ByVal value? As DateTime)
                _Birthdate = value
            End Set
        End Property

#If (LEADTOOLS_V19_OR_LATER) Then
        Private privateOtherPatientIdsSequence As List(Of PatientUpdater.OtherPatientID)
        <Element(DicomTag.OtherPatientIDsSequence)>
        Public Property OtherPatientIdsSequence() As List(Of PatientUpdater.OtherPatientID)
            Get
                Return privateOtherPatientIdsSequence
            End Get
            Set(ByVal value As List(Of PatientUpdater.OtherPatientID))
                privateOtherPatientIdsSequence = value
            End Set
        End Property
#End If
    End Class
End Namespace