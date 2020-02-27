' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.DicomDemos
Imports System.Xml.Serialization
Imports System.IO
Imports System.Xml
Imports Leadtools.Dicom.Common.DataTypes

Namespace Leadtools.Demos.Workstation
   <Serializable> _
   Public Class WorkstationSettings
	   Implements IWorkstationSettings
	  Public Sub New()
	  End Sub

	  Public Shared Function Load(ByVal settings As String) As WorkstationSettings
		 Dim serializer As XmlSerializer
		 Dim reader As StringReader

		 serializer = New XmlSerializer (GetType(WorkstationSettings))

		 reader = New StringReader (settings)
		 Using reader
			Return TryCast(serializer.Deserialize (XmlTextReader.Create (reader)), WorkstationSettings)
		 End Using
	  End Function

	  Public Shared Function Save(ByVal settings As WorkstationSettings) As String
		 Dim serializer As XmlSerializer
		 Dim writer As StringWriter

		 serializer = New XmlSerializer (GetType(WorkstationSettings))

		 writer = New StringWriter ()
		 Using writer
			serializer.Serialize (writer, settings)

			Return writer.ToString ()
		 End Using
	  End Function

	  Public Property ServerList() As List(Of DicomAE) Implements IWorkstationSettings.ServerList
		 Get
			If Nothing Is _serverList Then
			   _serverList = New List(Of DicomAE) ()
			End If

			Return _serverList
		 End Get

		 Set(ByVal value As List(Of DicomAE))
			_serverList = value
		 End Set
	  End Property

	  Private privateWorkstationDicomServer As DicomAE
	  Public Property WorkstationDicomServer() As DicomAE
		  Get
			  Return privateWorkstationDicomServer
		  End Get
		  Set(ByVal value As DicomAE)
			  privateWorkstationDicomServer = value
		  End Set
	  End Property

	  Private privateClientAe As DicomAE
	  Public Property ClientAe() As DicomAE Implements IWorkstationSettings.ClientAe
		  Get
			  Return privateClientAe
		  End Get
		  Set(ByVal value As DicomAE)
			  privateClientAe = value
		  End Set
	  End Property

	  Private privateWorkstationServer As String
	  Public Property WorkstationServer() As String Implements IWorkstationSettings.WorkstationServer
		  Get
			  Return privateWorkstationServer
		  End Get
		  Set(ByVal value As String)
			  privateWorkstationServer = value
		  End Set
	  End Property

	  Private privateDefaultImageQuery As String
	  Public Property DefaultImageQuery() As String Implements IWorkstationSettings.DefaultImageQuery
		  Get
			  Return privateDefaultImageQuery
		  End Get
		  Set(ByVal value As String)
			  privateDefaultImageQuery = value
		  End Set
	  End Property

	  Private privateDefaultStore As String
	  Public Property DefaultStore() As String Implements IWorkstationSettings.DefaultStore
		  Get
			  Return privateDefaultStore
		  End Get
		  Set(ByVal value As String)
			  privateDefaultStore = value
		  End Set
	  End Property

	  Private privateSetClientToAllWorkstations As Boolean
	  Public Property SetClientToAllWorkstations() As Boolean
		  Get
			  Return privateSetClientToAllWorkstations
		  End Get
		  Set(ByVal value As Boolean)
			  privateSetClientToAllWorkstations = value
		  End Set
	  End Property

	  Public Function GetServer(ByVal serverName As String) As DicomAE Implements IWorkstationSettings.GetServer
		 Dim ret As DicomAE = Nothing


		 If serverName = WorkstationServer Then
			Return WorkstationDicomServer
		 End If

		 For Each ae As DicomAE In ServerList
			If String.Compare (ae.AE, serverName, True) =0 Then
			   ret = ae

			   Exit For
			End If
		 Next ae
		 Return ret
	  End Function

	  Private _serverList As List(Of DicomAE)
   End Class
End Namespace
