' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Dicom
Imports Leadtools.Dicom.Scp

Namespace VBCustomizingWorklistDAL.MyClientSession
   Public Class DemoClientSession
      Implements ICFindClientSessionProxy

      Public Sub New()
         ResponseDS = New List(Of DicomDataSet)()
      End Sub

      Public Status As DicomCommandStatusType
      Public StatusMessage As String
      Public ResponseDS As List(Of DicomDataSet)

#Region "IDicomCommandClientSessionProxy Members"
      Public ReadOnly Property AbstractClass() As String Implements ICFindClientSessionProxy.AbstractClass
         Get
            Return String.Empty
         End Get
      End Property

      Public ReadOnly Property MessageID() As Integer Implements ICFindClientSessionProxy.MessageID
         Get
            Return 1
         End Get
      End Property

      Public ReadOnly Property PresentationID() As Byte Implements ICFindClientSessionProxy.PresentationID
         Get
            Return 1
         End Get
      End Property
#End Region

#Region "IClientSessionProxy Members"
      Public ReadOnly Property ClientName() As String Implements ICFindClientSessionProxy.ClientName
         Get
            Return "DEMO"
         End Get
      End Property

      Public ReadOnly Property IsAssociated() As Boolean Implements ICFindClientSessionProxy.IsAssociated
         Get
            Return True
         End Get
      End Property

      Public ReadOnly Property IsConnected() As Boolean Implements ICFindClientSessionProxy.IsConnected
         Get
            Return True
         End Get
      End Property

      Public Sub LogEvent(ByVal eventType As Global.Leadtools.Logging.LogType, ByVal messageDirection As Global.Leadtools.Logging.Medical.MessageDirection, ByVal description As String, ByVal command As DicomCommandType, ByVal dataset As DicomDataSet, ByVal customInformation As Global.Leadtools.Logging.SerializableDictionary(Of String, Object)) Implements ICFindClientSessionProxy.LogEvent

      End Sub

      Public ReadOnly Property ServerName() As String Implements ICFindClientSessionProxy.ServerName
         Get
            Return "DEMOSERVER"
         End Get
      End Property
#End Region

#Region "ICFindClientSessionProxy Members"
      Public Sub SendCFindResponse(ByVal status As DicomCommandStatusType, ByVal responseDataset As DicomDataSet, ByVal descriptionMessage As String) Implements ICFindClientSessionProxy.SendCFindResponse
         status = status
         StatusMessage = descriptionMessage

         If Not Nothing Is responseDataset Then
            ResponseDS.Add(responseDataset)
         End If
      End Sub
#End Region

   End Class
End Namespace
