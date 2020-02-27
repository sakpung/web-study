' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Forms.Recognition
Imports Leadtools.Forms.Processing
Imports Leadtools.Forms.Common

Namespace FormsDemo
   Public Class FilledForm
      Private _fileName As String
      Private _name As String
      Private _image As RasterImage
      Private _attributes As FormRecognitionAttributes
      Private _master As MasterForm
      Private _result As FormRecognitionResult
      Private _alignment As IList(Of PageAlignment)
      Private _processingPages As FormPages

      Public Sub New()
         _fileName = Nothing
         _name = Nothing
         _image = Nothing
         _attributes = Nothing
         _master = Nothing
         _result = Nothing
         _alignment = Nothing
      End Sub

      Public Property FileName() As String
         Get
            Return _fileName
         End Get
         Set(value As String)
            _fileName = value
         End Set
      End Property

      Public Property Name() As String
         Get
            Return _name
         End Get
         Set(value As String)
            _name = value
         End Set
      End Property

      Public Property Alignment() As IList(Of PageAlignment)
         Get
            Return _alignment
         End Get
         Set(value As IList(Of PageAlignment))
            _alignment = value
         End Set
      End Property

      Public Property Result() As FormRecognitionResult
         Get
            Return _result
         End Get
         Set(value As FormRecognitionResult)
            _result = value
         End Set
      End Property

      Public Property Image() As RasterImage
         Get
            Return _image
         End Get
         Set(value As RasterImage)
            _image = value
         End Set
      End Property

      Public Property Attributes() As FormRecognitionAttributes
         Get
            Return _attributes
         End Get
         Set(value As FormRecognitionAttributes)
            _attributes = value
         End Set
      End Property

      Public Property Master() As MasterForm
         Get
            Return _master
         End Get
         Set(value As MasterForm)
            _master = value
         End Set
      End Property

      Public Property ProcessingPages() As FormPages
         Get
            Return _processingPages
         End Get
         Set(value As FormPages)
            _processingPages = value
         End Set
      End Property
   End Class
End Namespace
