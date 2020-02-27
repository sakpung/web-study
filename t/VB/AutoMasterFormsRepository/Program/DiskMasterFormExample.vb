' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Forms.Recognition
Imports Leadtools.Forms.Processing

'This project is provided as an example of how to implement the following three interfaces: IMasterFormsRepository, IMasterFormsCategory, and IMasterForm.
'This demo is not intended to be a running one. These three interfaces are used with Leadtools.Forms.Auto.AutoFormsEngine class to store master forms and categorize them.
'The code provided in this project is the default implementation for the three mentioned interfaces that is shipped with LEADTOOLS SDK for Forms
'This project may help a user to build his own implementation of these interfaces that fits his application, for example, database repository.

Namespace Leadtools.Forms.Auto
   Public Class DiskMasterFormExample : Implements IMasterForm
      Private _name As String
      Private _path As String
      Private _parent As IMasterFormsCategory
      Private _attributes As FormRecognitionAttributes
      Private _processingEngine As FormProcessingEngine
      Private _repository As IMasterFormsRepository
      Private _candidatePageNumber As Integer

      ' Name of this master form
      Public ReadOnly Property Name() As String Implements IMasterForm.Name
         Get
            Return _name
         End Get
      End Property

      'The Repository that this Master belongs to
      Public ReadOnly Property Repository() As IMasterFormsRepository Implements IMasterForm.Repository
         Get
            Return _repository
         End Get
      End Property

      'Parent category that contains this Master Form
      Public ReadOnly Property Parent() As IMasterFormsCategory Implements IMasterForm.Parent
         Get
            Return _parent
         End Get
      End Property

      ' Get all the path
      Public ReadOnly Property Path() As String
         Get
            Return _path
         End Get
      End Property

      ' Get all the CandidatePageNumber
      Public Property CandidatePageNumber() As Integer Implements IMasterForm.CandidatePageNumber
         Get
            Return _candidatePageNumber
         End Get
         Set(value As Integer)
            _candidatePageNumber = value
         End Set
      End Property

      ' Get the attributes of this master form (from attributes you can get last access date/time/etc)
      Public Function ReadAttributes() As FormRecognitionAttributes Implements IMasterForm.ReadAttributes
         If _attributes Is Nothing Then
            If (Not File.Exists(_path & ".bin")) Then
               Return Nothing
            End If
            Dim data As Byte() = File.ReadAllBytes(_path & ".bin")
            _attributes = New FormRecognitionAttributes()
            _attributes.SetData(data)
         End If
         Return _attributes
      End Function

      ' Update the attributes of this master form
      Public Sub WriteAttributes(ByVal attributes As FormRecognitionAttributes) Implements IMasterForm.WriteAttributes
         If attributes Is Nothing Then
            Throw New ArgumentNullException("attributes")
         End If
         _attributes = Nothing
         Dim data As Byte() = attributes.GetData()
         File.WriteAllBytes(_path & ".bin", data)
      End Sub

      ' Read the fields of this master form
      Public Function ReadFields() As FormPages Implements IMasterForm.ReadFields
         If (Not File.Exists(_path & ".xml")) Then
            Return Nothing
         End If
         _processingEngine.LoadFields(_path & ".xml")
         'to create new forms pages
         Dim tempProcessingEngine As FormProcessingEngine = New FormProcessingEngine()
         Dim formFields As FormPages = tempProcessingEngine.Pages
         formFields.AddRange(_processingEngine.Pages)
         Return formFields
      End Function

      ' Update the fields of this master form
      Public Sub WriteFields(ByVal fields As FormPages) Implements IMasterForm.WriteFields
         If fields Is Nothing Then
            Throw New ArgumentNullException("fields")
         End If
         _processingEngine.Pages.Clear()
         _processingEngine.Pages.AddRange(fields)
         _processingEngine.SaveFields(_path & ".xml")
      End Sub

      ' Read the form (RasterImage) attached to this master form (optional, might return null)
      Public Function ReadForm() As RasterImage Implements IMasterForm.ReadForm
         If (Not File.Exists(_path & ".tif")) Then
            Return Nothing
         End If
         Return _repository.RasterCodecsInstance.Load(_path & ".tif", 1, CodecsLoadByteOrder.Bgr, 1, -1)
      End Function

      ' Update the form (RasterImage) attached to this master form
      Public Sub WriteForm(ByVal form As RasterImage) Implements IMasterForm.WriteForm
         If form Is Nothing Then
            Throw New ArgumentNullException("form")
         End If
         form.DitheringMethod = RasterDitheringMethod.None
         _repository.RasterCodecsInstance.Save(form, _path & ".tif", RasterImageFormat.Tif, 1, 1, -1, 1, CodecsSavePageMode.Overwrite)
      End Sub
      Friend Sub New(ByVal repositoryParam As IMasterFormsRepository, ByVal nameParam As String, ByVal pathParam As String, ByVal parentParam As IMasterFormsCategory)
         _repository = repositoryParam
         _processingEngine = New FormProcessingEngine()
         _attributes = Nothing
         _name = nameParam
         _parent = parentParam
         _path = pathParam
      End Sub
#If LEADTOOLS_V19_OR_LATER Then
      Private _isExtendable As Boolean

      Public ReadOnly Property IsExtendable() As Boolean Implements IMasterForm.IsExtendable
         Get
            If _isExtendable = True Then
               Return _isExtendable
            End If

            Dim pages As FormPages = Me.ReadFields()
            If pages Is Nothing Then
               Return False
            End If
            For Each page As FormPage In pages
               For Each field As FormField In page
                  If TypeOf field Is TableFormField Then
                     _isExtendable = True
                     Return True
                  End If
               Next
            Next
            Return False
         End Get
      End Property
#End If
   End Class
End Namespace
