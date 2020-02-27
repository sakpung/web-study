' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Net
Imports System.ComponentModel
Imports Leadtools.Dicom

Namespace Leadtools.DicomDemos
   ''' <summary>
   ''' Summary description for DicomServer.
   ''' </summary>
   Public Class DicomServer
      Private _AETitle As String = ""
      Private _Port As Integer = 104
      Private _Address As IPAddress = IPAddress.Parse("127.0.0.1")
#If LEADTOOLS_V17_OR_LATER Then
      Private _ipType As DicomNetIpTypeFlags = DicomNetIpTypeFlags.Ipv4
#End If
      Private _Timeout As Integer = 30

#Region "Server Properties"

      ''' <summary>
      ''' Called AE Title.
      ''' </summary>
      <Category("Server"), Description("Server AE Title")> _
      Public Property AETitle() As String
         Get
            ' TODO:  Add Storage.AETitle getter implementation
            Return _AETitle
         End Get
         Set(ByVal value As String)
            _AETitle = Value
         End Set
      End Property

      ''' <summary>
      ''' Port of server.
      ''' </summary>
      <Category("Server"), Description("Server port number")> _
      Public Property Port() As Integer
         Get
            ' TODO:  Add Storage.Port getter implementation
            Return _Port
         End Get
         Set(ByVal value As Integer)
            _Port = Value
         End Set
      End Property

      ''' <summary>
      ''' IPAddress of server
      ''' </summary>
      <Category("Server"), Description("Server internet address")> _
      Public Property Address() As System.Net.IPAddress
         Get
            Return _Address
         End Get
         Set(ByVal value As System.Net.IPAddress)
            _Address = Value
         End Set
      End Property

#If LEADTOOLS_V17_OR_LATER Then
      Public Property IpType() As DicomNetIpTypeFlags
          Get
              Return _ipType
          End Get
          Set(ByVal value As DicomNetIpTypeFlags)
              _ipType = value
          End Set
      End Property
#End If

      ''' <summary>
      ''' About of time in milliseconds to wait for a response from
      ''' the server. Assign zero to wait indefinitely.
      ''' </summary>
      <Category("Server"), Description("Sever timeout in milliseconds")> _
      Public Property Timeout() As Integer
         Get
            Return _Timeout
         End Get
         Set(ByVal value As Integer)
            _Timeout = Value
         End Set
      End Property
#End Region

      Public Sub New()
         '
         ' TODO: Add constructor logic here
         '
      End Sub
   End Class
End Namespace
