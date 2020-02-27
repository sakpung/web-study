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

Public Class MasterForm
   Private _image As RasterImage
   Private _attributes As FormRecognitionAttributes
   Private _properties As FormRecognitionProperties
   Private _processingPages As FormPages
   Private _isDirty As Boolean

   Public Sub New()
      _image = Nothing
      _attributes = New FormRecognitionAttributes()
      _properties = FormRecognitionProperties.Empty
      _processingPages = Nothing
      _isDirty = False
   End Sub

   Public Sub New(name As String)
      _image = Nothing
      _attributes = New FormRecognitionAttributes()
      _properties = New FormRecognitionProperties()
      _properties.Name = name
      _processingPages = Nothing
      _isDirty = False
   End Sub

   Public Property IsDirty() As Boolean
      Get
         Return _isDirty
      End Get
      Set(value As Boolean)
         _isDirty = value
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

   Public Property Properties() As FormRecognitionProperties
      Get
         Return _properties
      End Get
      Set(value As FormRecognitionProperties)
         _properties = value
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

   Public ReadOnly Property IsExtendable() As [Boolean]
      Get
         If Me.ProcessingPages Is Nothing Then
            Return False
         End If

         For Each page As FormPage In Me.ProcessingPages
            For Each field As FormField In page
               If TypeOf field Is TableFormField Then
                  Return True
               End If
            Next
         Next
         Return False
      End Get
   End Property
End Class
