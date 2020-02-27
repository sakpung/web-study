' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Xml
Imports System.Collections.Generic
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Drawing.Design
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports Leadtools
Imports Leadtools.Annotations.Engine

Public Class AnnRichTextObject
   Inherits AnnRectangleObject
   Public Overrides ReadOnly Property FriendlyName() As String
      Get
         Return "RichText"
      End Get
   End Property

   Public Overrides ReadOnly Property SupportsFont() As Boolean
      Get
         Return True
      End Get
   End Property

   Public Overrides ReadOnly Property SupportsFill() As Boolean
      Get
         Return True
      End Get
   End Property

   Public Overrides ReadOnly Property CanRotate() As Boolean
      Get
         Return False
      End Get
   End Property

   Public Sub New()
      SetId(AnnObject.RichTextObjectId)
      Fill = Nothing
   End Sub

   Private _rtfText As String = "{\rtf1\fbidis\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Arial;}}{\colortbl ;\red255\green0\blue0;\red255\green255\blue255;\red0\green128\blue0;\red0\green0\blue255;\red0\green0\blue0;}\viewkind4\uc1\pard\ltrpar\cf1\highlight2\fs20 Aa\cf3 Bb\cf4 Yy\cf5 Zz\par}"
   Public Property Rtf() As String
      Get
         Return _rtfText
      End Get
      Set(value As String)
         If _rtfText <> value Then
            Dim args As New AnnPropertyChangedEventArgs("RtfText", PropertyChangedStatus.Before, _rtfText, value)
            OnPropertyChanged(args)
            If Not args.Cancel Then
               args.Status = PropertyChangedStatus.After
               _rtfText = value
               OnPropertyChanged(args)
            End If
         End If
      End Set
   End Property

   Public Overrides Function Clone() As AnnObject
      Dim annTextObject As AnnRichTextObject = TryCast(MyBase.Clone(), AnnRichTextObject)

      If annTextObject IsNot Nothing Then
         annTextObject.Rtf = _rtfText
      End If

      Return annTextObject
   End Function

   Public Overrides Sub Serialize(options As AnnSerializeOptions, parentNode As XmlNode, document As XmlDocument)
      MyBase.Serialize(options, parentNode, document)

      Dim element As XmlNode = document.CreateElement("Rtf")


      If element IsNot Nothing Then
         element.InnerText = _rtfText
         parentNode.AppendChild(element)
      End If
   End Sub

   Public Overrides Sub Deserialize(options As AnnDeserializeOptions, element As XmlNode, document As XmlDocument)
      MyBase.Deserialize(options, element, document)

      Dim xmlElement As XmlElement = TryCast(element, XmlElement)

      _rtfText = ReadStringElement(document, "Rtf", element)
   End Sub

   Public Shared Function ReadStringElement(document As XmlDocument, elementName As String, node As XmlNode) As String
      Dim xmlElement As XmlElement = TryCast(node, XmlElement)
      Dim data As String = String.Empty

      If xmlElement IsNot Nothing Then
         For Each childNode As XmlNode In xmlElement.GetElementsByTagName(elementName)
            If childNode.ParentNode Is node Then
               If childNode IsNot Nothing AndAlso childNode.HasChildNodes Then
                  data = childNode.FirstChild.Value.Trim()
               End If

               Exit For
            End If
         Next
      End If

      Return data
   End Function

   Protected Overrides Function Create() As AnnObject
      Return New AnnRichTextObject()
   End Function

   Public Overrides Function ToString() As String
      Dim text As String = _rtfText
      Using rtf As New RichTextBox()
         rtf.Rtf = _rtfText
         text = rtf.Text
      End Using

      Return text
   End Function
End Class
