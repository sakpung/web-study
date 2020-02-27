' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.Collections
Imports System.IO
Imports System.Xml
Imports System

Namespace HL7Messaging
   <Serializable()> _
   Public Class NodeItemView
      Implements IEnumerable
      Public Sub New()
         Nodes = New List(Of NodeItemView)()
         Expand = False
         Tag = Nothing
         Model = Nothing
      End Sub

      Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
         Return Nodes.GetEnumerator()
      End Function

      Public Property Nodes() As List(Of NodeItemView)
         Get
            Return m_Nodes
         End Get
         Set(value As List(Of NodeItemView))
            m_Nodes = value
         End Set
      End Property
      Private m_Nodes As List(Of NodeItemView)

      Public Property Name() As String
         Get
            Return m_Name
         End Get
         Set(value As String)
            m_Name = value
         End Set
      End Property
      Private m_Name As String
      Public Property DataType() As String
         Get
            Return m_DataType
         End Get
         Set(value As String)
            m_DataType = value
         End Set
      End Property
      Private m_DataType As String
      Public Property NodeType() As String
         Get
            Return m_NodeType
         End Get
         Set(value As String)
            m_NodeType = value
         End Set
      End Property
      Private m_NodeType As String
      Public Property IsPopulated() As Boolean
         Get
            Return m_IsPopulated
         End Get
         Set(value As Boolean)
            m_IsPopulated = value
         End Set
      End Property
      Private m_IsPopulated As Boolean
      Public Property Value() As String
         Get
            Return m_Value
         End Get
         Set(value As String)
            m_Value = value
         End Set
      End Property
      Private m_Value As String
      Public Property Rep() As Integer
         Get
            Return m_Rep
         End Get
         Set(value As Integer)
            m_Rep = value
         End Set
      End Property
      Private m_Rep As Integer

      Public Property Text() As String
         Get
            Return m_Text
         End Get
         Set(value As String)
            m_Text = value
         End Set
      End Property
      Private m_Text As String
      Public Property Tag() As Object
         Get
            Return m_Tag
         End Get
         Set(value As Object)
            m_Tag = value
         End Set
      End Property
      Private m_Tag As Object
      Public Property Model() As Object
         Get
            Return m_Model
         End Get
         Set(value As Object)
            m_Model = value
         End Set
      End Property
      Private m_Model As Object
      Public Property Expand() As Boolean
         Get
            Return m_Expand
         End Get
         Set(value As Boolean)
            m_Expand = value
         End Set
      End Property
      Private m_Expand As Boolean

      Private Function ThisToXML(doc As XmlDocument) As XmlElement
         If String.IsNullOrEmpty(Name) Then
            Return Nothing
         End If

         Dim XMLNode As XmlElement = doc.CreateElement(Name)

         If Not String.IsNullOrEmpty(Value) Then
            XMLNode.InnerText = Value
         End If

         For index As Integer = 0 To Nodes.Count - 1
            XMLNode.AppendChild(Nodes(index).ThisToXML(doc))
         Next

         Return XMLNode
      End Function

      Public Function ToXML() As XmlDocument
         Dim doc As New XmlDocument()

         Dim XMLNode As XmlElement = ThisToXML(doc)

         If XMLNode IsNot Nothing Then
            doc.AppendChild(XMLNode)
         End If

         Return doc
      End Function
   End Class
End Namespace
