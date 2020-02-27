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
   Public Class PatientUpdate
      Private _Description As String = String.Empty

      <Element(DicomTag.RequestedProcedureDescription)> _
      Public Property Description() As String
         Get
            Return _Description
         End Get
         Set(ByVal value As String)
            _Description = Value
         End Set
      End Property

      Private _Reason As String

      <Element(DicomTag.ReasonForTheRequestedProcedure)> _
      Public Property Reason() As String
         Get
            Return _Reason
         End Get
         Set(ByVal value As String)
            _Reason = Value
         End Set
      End Property

      Private _Operator As String = String.Empty

      <Element(DicomTag.OperatorName)> _
      Public Property [Operator]() As String
         Get
            Return _Operator
         End Get
         Set(ByVal value As String)
            _Operator = Value
         End Set
      End Property

      Private _Station As String = Environment.MachineName

      <Element(DicomTag.StationName)> _
      Public Property Station() As String
         Get
            Return _Station
         End Get
         Set(ByVal value As String)
            _Station = Value
         End Set
      End Property

      Private _Date As DateTime = DateTime.Now

      <Element(DicomTag.InstanceCreationDate)> _
      Public Property [Date]() As DateTime
         Get
            Return _Date
         End Get
         Set(ByVal value As DateTime)
            _Date = Value
         End Set
      End Property

      Private _Time As DateTime = DateTime.Now

      <Element(DicomTag.InstanceCreationTime)> _
      Public Property Time() As DateTime
         Get
            Return _Time
         End Get
         Set(ByVal value As DateTime)
            _Time = Value
         End Set
      End Property

      Private _TransactionID As String = Guid.NewGuid().ToString()

      <Element(DicomTag.TransactionUID)> _
      Public Property TransactionID() As String
         Get
            Return _TransactionID
         End Get
         Set(ByVal value As String)
            _TransactionID = Value
         End Set
      End Property
   End Class
End Namespace
