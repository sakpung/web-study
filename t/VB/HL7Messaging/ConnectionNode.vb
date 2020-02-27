' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.Serialization
Imports Leadtools.Medical.HL7.V2x.MLP
Imports System.Xml.Serialization
Imports System.IO
Imports System.Windows.Forms
Imports System

Namespace HL7Messaging
   <Serializable()> _
   Public Class ConnectionNode
      Public Property Name() As String
         Get
            Return m_Name
         End Get
         Set(value As String)
            m_Name = value
         End Set
      End Property
      Private m_Name As String

      Public Property RemoteIP() As String
         Get
            Return m_RemoteIP
         End Get
         Set(value As String)
            m_RemoteIP = value
         End Set
      End Property
      Private m_RemoteIP As String
      Public Property RemotePort() As Integer
         Get
            Return m_RemotePort
         End Get
         Set(value As Integer)
            m_RemotePort = value
         End Set
      End Property
      Private m_RemotePort As Integer
      Public Property RemoteAppName() As String
         Get
            Return m_RemoteAppName
         End Get
         Set(value As String)
            m_RemoteAppName = value
         End Set
      End Property
      Private m_RemoteAppName As String
      Public Property RemoteFacility() As String
         Get
            Return m_RemoteFacility
         End Get
         Set(value As String)
            m_RemoteFacility = value
         End Set
      End Property
      Private m_RemoteFacility As String

      Public Property ClientAppName() As String
         Get
            Return m_ClientAppName
         End Get
         Set(value As String)
            m_ClientAppName = value
         End Set
      End Property
      Private m_ClientAppName As String
      Public Property ClientFacility() As String
         Get
            Return m_ClientFacility
         End Get
         Set(value As String)
            m_ClientFacility = value
         End Set
      End Property
      Private m_ClientFacility As String

      Public Property Timeout() As Integer
         Get
            Return m_Timeout
         End Get
         Set(value As Integer)
            m_Timeout = value
         End Set
      End Property
      Private m_Timeout As Integer
      Public Property MessagingVersion() As String
         Get
            Return m_MessagingVersion
         End Get
         Set(value As String)
            m_MessagingVersion = value
         End Set
      End Property
      Private m_MessagingVersion As String
      Public Property MLPPrefix() As String
         Get
            Return m_MLPPrefix
         End Get
         Set(value As String)
            m_MLPPrefix = value
         End Set
      End Property
      Private m_MLPPrefix As String
      Public Property MLPSuffix() As String
         Get
            Return m_MLPSuffix
         End Get
         Set(value As String)
            m_MLPSuffix = value
         End Set
      End Property
      Private m_MLPSuffix As String
      Public Property WaitForACK() As Boolean
         Get
            Return m_WaitForACK
         End Get
         Set(value As Boolean)
            m_WaitForACK = value
         End Set
      End Property
      Private m_WaitForACK As Boolean

      Public Function Clone() As ConnectionNode
         Return New ConnectionNode() With { _
           .Name = Name, _
           .RemoteIP = RemoteIP, _
           .RemotePort = RemotePort, _
           .RemoteAppName = RemoteAppName, _
           .RemoteFacility = RemoteFacility, _
           .ClientAppName = ClientAppName, _
           .ClientFacility = ClientFacility, _
           .Timeout = Timeout, _
           .MessagingVersion = MessagingVersion, _
           .MLPPrefix = MLPPrefix, _
           .MLPSuffix = MLPSuffix, _
           .WaitForACK = WaitForACK _
         }
      End Function
   End Class

   Class InternalFormatter
      Public Shared Function StringToByteArray(hex As String) As Byte()
         If hex.Length Mod 2 = 1 Then
            hex = Convert.ToString("0"c) & hex
         End If
         hex = hex.ToUpper()
         Dim arr As Byte() = New Byte((hex.Length >> 1) - 1) {}

         For i As Integer = 0 To (hex.Length >> 1) - 1
            arr(i) = CByte((GetHexVal(hex(i << 1)) << 4) + (GetHexVal(hex((i << 1) + 1))))
         Next

         Return arr
      End Function

      Public Shared Function GetHexVal(hex As Char) As Integer
         Dim val As Integer = CInt(Microsoft.VisualBasic.AscW(hex))
         'For uppercase A-F letters:
         Return val - (If(val < 58, 48, 55))
         'For lowercase a-f letters:
         'return val - (val < 58 ? 48 : 87);
      End Function

      Public Shared Function ToHexString(bb As Byte()) As String
         Dim hex As String = ""
         For Each b As Byte In bb
            hex += b.ToString("X2")
         Next
         Return hex
      End Function
   End Class

   Public Class ConnectionNodeBuilder
      Public Shared Function Defaults(node As ConnectionNode) As ConnectionNode
         node.Name = ""
         node.RemoteIP = "127.0.0.1"
         node.RemotePort = 6790
         node.MLPPrefix = InternalFormatter.ToHexString(MLPEnvelope.Envelop_Header)
         node.MLPSuffix = InternalFormatter.ToHexString(MLPEnvelope.Envelop_Trailer)
         node.Timeout = 0
         node.WaitForACK = True
         node.ClientFacility = "LEAD Tech"
         node.ClientAppName = "LEADTOOLS HL7 Sender"
         Return node
      End Function

      Public Shared Function MWL(node As ConnectionNode) As ConnectionNode
         node.Name = "[Demo] Storage Server's MWL Plug-in"
         node.RemoteIP = "127.0.0.1"
         node.RemotePort = 6788
         node.MLPPrefix = InternalFormatter.ToHexString(MLPEnvelope.Envelop_Header)
         node.MLPSuffix = InternalFormatter.ToHexString(MLPEnvelope.Envelop_Trailer)
         node.Timeout = 0
         node.WaitForACK = True
         Return node
      End Function

      Public Shared Function PatientUpdate(node As ConnectionNode) As ConnectionNode
         node.Name = "[Demo] Storage Server's Patient Update Plug-in"
         node.RemoteIP = "127.0.0.1"
         node.RemotePort = 6787
         node.MLPPrefix = InternalFormatter.ToHexString(MLPEnvelope.Envelop_Header)
         node.MLPSuffix = InternalFormatter.ToHexString(MLPEnvelope.Envelop_Trailer)
         node.Timeout = 0
         node.WaitForACK = True
         Return node
      End Function
   End Class

   <Serializable()> _
   Public Class ConnectionNodes
      Shared _instance As ConnectionNodes = Nothing
      Public Shared Function Instance() As ConnectionNodes
         If _instance Is Nothing Then
            _instance = New ConnectionNodes()
         End If
         Return _instance
      End Function

      Public Property Nodes() As List(Of ConnectionNode)
         Get
            Return m_Nodes
         End Get
         Set(value As List(Of ConnectionNode))
            m_Nodes = value
         End Set
      End Property
      Private m_Nodes As List(Of ConnectionNode)

      Public Sub New()
         Nodes = New List(Of ConnectionNode)()
         Reset()
      End Sub

      Public Sub AddDefaults()
         Add(ConnectionNodeBuilder.PatientUpdate(New ConnectionNode()))
         Add(ConnectionNodeBuilder.MWL(New ConnectionNode()))
      End Sub

      Public Function Find(name As String) As Integer
         If String.IsNullOrEmpty(name) Then
            Return -1
         End If

         For index As Integer = 0 To Nodes.Count - 1
            If 0 = String.Compare(Nodes(index).Name, name) Then
               Return index
            End If
         Next

         Return -1
      End Function

      Public Sub Add(node As ConnectionNode)
         Dim index As Integer = Find(node.Name)
         If index >= 0 Then
            Nodes.Insert(index, node.Clone())
            Nodes.RemoveAt(index + 1)
         Else
            Nodes.Add(node.Clone())
         End If
      End Sub

      Public Sub Remove(index As Integer)
         If index >= 0 AndAlso index < Nodes.Count Then
            Nodes.RemoveAt(index)
         End If
      End Sub

      Public Sub Reset()
         Nodes.Clear()
         AddDefaults()
      End Sub

      Public Sub Load(fileName As String)
         If Not File.Exists(fileName) Then
            Return
         End If
         Using file__1 As StreamReader = New StreamReader(fileName)
            Dim ser As New XmlSerializer(GetType(ConnectionNodes))
            Dim cns As ConnectionNodes = CType(ser.Deserialize(file__1), ConnectionNodes)
            Reset()
            For Each cn As ConnectionNode In cns.Nodes
               Add(cn)
            Next
         End Using
      End Sub

      Public Sub Save(fileName As String)
         Using file As StreamWriter = New StreamWriter(fileName)
            Dim ser As New XmlSerializer(GetType(ConnectionNodes))
            ser.Serialize(file, Me)
         End Using
      End Sub
   End Class
End Namespace
