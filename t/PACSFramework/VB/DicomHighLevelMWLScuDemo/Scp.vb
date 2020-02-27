' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Leadtools.Dicom.Scu
Imports System.Net
Imports System.Xml.Serialization

Namespace DicomDemo
	Public Class Scp : Inherits DicomScp
		Private _IPString As String

		Public Property IPString() As String
			Get
				Return _IPString
			End Get
			Set
                Dim ip As IPAddress = IPAddress.None

				If IPAddress.TryParse(Value, ip) Then
					_IPString = Value
					PeerAddress = ip
				End If
			End Set
		End Property

		<XmlIgnore> _
		Public Overrides Property PeerAddress() As IPAddress
			Get
				Return MyBase.PeerAddress
			End Get
			Set
				MyBase.PeerAddress = Value
				If Not Value Is Nothing Then
					_IPString = Value.ToString()
				End If
			End Set
		End Property
	End Class
End Namespace
