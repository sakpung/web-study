' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools.Svg

Namespace SvgDemo
   Public Class SvgDocumentInformation
      Private _document As SvgDocument
      Private _documentText As DocumentText
      Private _showText As Boolean

      Public Sub New(document As SvgDocument)
         _document = document
         _documentText = Nothing
         _showText = False
      End Sub

      Public Property Document() As SvgDocument
         Get
            Return _document
         End Get
         Set(value As SvgDocument)
            If _document IsNot value Then
               If _document IsNot Nothing Then
                  _document.Dispose()
               End If

               _document = value
            End If
         End Set
      End Property

      Public Property ShowText() As Boolean
         Get
            Return _showText
         End Get
         Set(value As Boolean)
            _showText = value
         End Set
      End Property

      Public Property DocumentText() As DocumentText
         Get
            Return _documentText
         End Get
         Set(value As DocumentText)
            _documentText = value
         End Set
      End Property
   End Class
End Namespace
