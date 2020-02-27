' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
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
    Public Class DiskMasterFormsCategoryExample : Implements IMasterFormsCategory
        Private _name As String
        Private _path As String
        Private _parent As IMasterFormsCategory
        Private _childCategories As MasterFormsCategoryCollection
        Private _masterForms As MasterFormCollection
        Private _recognitionEngine As FormRecognitionEngine
        Private _repository As IMasterFormsRepository

        ' This category name
        Public ReadOnly Property Name() As String Implements IMasterFormsCategory.Name
            Get
                Return _name
            End Get
        End Property

        'The Repository that this Master belongs to
        Public ReadOnly Property Repository() As IMasterFormsRepository Implements IMasterFormsCategory.Repository
            Get
                Return _repository
            End Get
        End Property

        ' Get all the path
        Public ReadOnly Property Path() As String
            Get
                Return _path
            End Get
        End Property

        'Parent category that contains this Category
        Public ReadOnly Property Parent() As IMasterFormsCategory Implements IMasterFormsCategory.Parent
            Get
                Return _parent
            End Get
        End Property

        ' Children categories of this category
        Public ReadOnly Property ChildCategories() As MasterFormsCategoryCollection Implements IMasterFormsCategory.ChildCategories
            Get
                Return _childCategories
            End Get
        End Property

        Public ReadOnly Property ChildCategoriesCount() As Integer Implements IMasterFormsCategory.ChildCategoriesCount
            Get
                Return _childCategories.Count
            End Get
        End Property

        Public Function AddChildCategory(ByVal nameParam As String) As IMasterFormsCategory Implements IMasterFormsCategory.AddChildCategory
            Dim dir As String = System.IO.Path.Combine(_path, nameParam)

            ' Check if already exists
            If Directory.Exists(dir) Then
                Throw New ArgumentException(String.Format("A category with the name '{0}' already exists", nameParam), "name")
            End If

            ' Create the directory
            Directory.CreateDirectory(dir)

            ' Add it to the child categories
            Dim cat As DiskMasterFormsCategoryExample = New DiskMasterFormsCategoryExample(_repository, nameParam, dir, Me)
            _childCategories.AddCategory(cat)
            Return cat
        End Function

        Public Sub DeleteChildCategory(ByVal category As IMasterFormsCategory) Implements IMasterFormsCategory.DeleteChildCategory
            ' Check
            If category Is Nothing Then
                Throw New ArgumentNullException("category")
            End If

            If (Not _childCategories.Contains(category)) Then
                Throw New ArgumentException("Category not child of this category", "category")
            End If

            Dim diskCategory As DiskMasterFormsCategoryExample = TryCast(category, DiskMasterFormsCategoryExample)
            If diskCategory Is Nothing Then ' cast above failed
                Throw New Exception("Invalid category type")
            End If

            ' Call clear to delete all children of this category
            category.Clear()

            ' Remove it from the list
            _childCategories.Remove(category)
        End Sub


        Public ReadOnly Property MasterFormsCount() As Integer Implements IMasterFormsCategory.MasterFormsCount
            Get
                Return _masterForms.Count
            End Get
        End Property

        Public ReadOnly Property MasterForms() As MasterFormCollection Implements IMasterFormsCategory.MasterForms
            Get
                Return _masterForms
            End Get
        End Property

        ' Adds a new master form in the given category, parentCategory must not be null
        Public Function AddMasterForm(ByVal attributes As FormRecognitionAttributes, ByVal fields As FormPages, ByVal form As RasterImage) As IMasterForm Implements IMasterFormsCategory.AddMasterForm
            If attributes Is Nothing Then
                Throw New ArgumentException(String.Format("Master Form attributes should be available"), "attributes")
            End If
            ' Create the file(s)
            Dim properties As FormRecognitionProperties = _recognitionEngine.GetFormProperties(attributes)
            Dim masterForm As DiskMasterFormExample = New DiskMasterFormExample(_repository, properties.Name, System.IO.Path.Combine(_path, properties.Name), Me)
            ' Create the file
            masterForm.WriteAttributes(attributes)
            If Not fields Is Nothing Then
                masterForm.WriteFields(fields)
            End If
            If Not form Is Nothing Then
                masterForm.WriteForm(form)
            End If

            _masterForms.AddMasterForm(masterForm)
            Return masterForm
        End Function

        Public Function AddMasterForm(ByVal attributes As FormRecognitionAttributes, ByVal fields As FormPages, ByVal fileName As String) As IMasterForm Implements IMasterFormsCategory.AddMasterForm
            If attributes Is Nothing Then
                Throw New ArgumentException(String.Format("Master Form attributes should be available"), "attributes")
            End If
            ' Create the file(s)
            Dim properties As FormRecognitionProperties = _recognitionEngine.GetFormProperties(attributes)
            Dim masterForm As DiskMasterFormExample = New DiskMasterFormExample(_repository, properties.Name, System.IO.Path.Combine(_path, properties.Name), Me)
            ' Create the file
            masterForm.WriteAttributes(attributes)
            If Not fields Is Nothing Then
                masterForm.WriteFields(fields)
            End If
            If Not fileName Is Nothing Then
                masterForm.WriteForm(_repository.RasterCodecsInstance.Load(fileName, 1, CodecsLoadByteOrder.Bgr, 1, -1))
            End If

            _masterForms.AddMasterForm(masterForm)
            Return masterForm
        End Function

        Public Function AddMasterForm(ByVal attributes As FormRecognitionAttributes, ByVal fields As FormPages, ByVal stream As Stream) As IMasterForm Implements IMasterFormsCategory.AddMasterForm
            If attributes Is Nothing Then
                Throw New ArgumentException(String.Format("Master Form attributes should be available"), "attributes")
            End If
            ' Create the file(s)
            Dim properties As FormRecognitionProperties = _recognitionEngine.GetFormProperties(attributes)
            Dim masterForm As DiskMasterFormExample = New DiskMasterFormExample(_repository, properties.Name, System.IO.Path.Combine(_path, properties.Name), Me)
            ' Create the file
            masterForm.WriteAttributes(attributes)
            If Not fields Is Nothing Then
                masterForm.WriteFields(fields)
            End If
            If Not stream Is Nothing Then
                masterForm.WriteForm(_repository.RasterCodecsInstance.Load(stream, 1, CodecsLoadByteOrder.Bgr, 1, -1))
            End If

            _masterForms.AddMasterForm(masterForm)
            Return masterForm
        End Function

        Public Function AddMasterForm(ByVal attributes As FormRecognitionAttributes, ByVal fields As FormPages, ByVal url As Uri) As IMasterForm Implements IMasterFormsCategory.AddMasterForm
            If attributes Is Nothing Then
                Throw New ArgumentException(String.Format("Master Form attributes should be available"), "attributes")
            End If
            ' Create the file(s)
            Dim properties As FormRecognitionProperties = _recognitionEngine.GetFormProperties(attributes)
            Dim masterForm As DiskMasterFormExample = New DiskMasterFormExample(_repository, properties.Name, System.IO.Path.Combine(_path, properties.Name), Me)
            ' Create the file
            masterForm.WriteAttributes(attributes)
            If Not fields Is Nothing Then
                masterForm.WriteFields(fields)
            End If
            If Not url Is Nothing Then
                masterForm.WriteForm(_repository.RasterCodecsInstance.Load(url, 1, CodecsLoadByteOrder.Bgr, 1, -1))
            End If

            _masterForms.AddMasterForm(masterForm)
            Return masterForm
        End Function

        Public Sub DeleteMasterForm(ByVal masterForm As IMasterForm) Implements IMasterFormsCategory.DeleteMasterForm
            ' Check
            If masterForm Is Nothing Then
                Throw New ArgumentNullException("masterForm")
            End If

            Dim diskMasterForm As DiskMasterFormExample = TryCast(masterForm, DiskMasterFormExample)
            If diskMasterForm Is Nothing Then ' cast above failed
                Throw New Exception("Invalid master form type")
            End If

            ' Remove it from its parent list
            _masterForms.Remove(masterForm)

            ' Delete attributes file
            Dim file As String = diskMasterForm.Path & ".bin"
            If System.IO.File.Exists(file) Then
                System.IO.File.Delete(file)
            End If
            ' Delete fields file
            file = diskMasterForm.Path & ".xml"
            If System.IO.File.Exists(file) Then
                System.IO.File.Delete(file)
            End If
            ' Delete image file
            file = diskMasterForm.Path & ".tif"
            If System.IO.File.Exists(file) Then
                System.IO.File.Delete(file)
            End If
        End Sub

        Public Sub Clear() Implements IMasterFormsCategory.Clear
            ' Delete the child categories first
            Do While _childCategories.Count > 0
                Dim childCategory As IMasterFormsCategory = _childCategories(0)

                ' Delete it, this will remove itself from the list
                DeleteChildCategory(childCategory)
            Loop

            ' Delete all the master forms in this category
            Do While _masterForms.Count > 0
                Dim masterForm As IMasterForm = _masterForms(0)

                ' Delete it, this will remove itself from the list
                DeleteMasterForm(masterForm)
            Loop

            ' At this point, we can safely remove the directory
            Directory.Delete(Path)
        End Sub

        Friend Sub Refresh()
            ' Clear the collections
            _childCategories.Clear()
            _masterForms.Clear()

            ' Read all the master forms in here
            Dim files As String() = Directory.GetFiles(_path, "*.bin")
            For Each file As String In files

                Dim nameParam As String = System.IO.Path.GetFileNameWithoutExtension(file)
                Dim masterForm As DiskMasterFormExample = New DiskMasterFormExample(_repository, nameParam, System.IO.Path.Combine(_path, nameParam), Me)
                _masterForms.AddMasterForm(masterForm)
            Next file

            ' Read all the directories
            Dim dirs As String() = Directory.GetDirectories(_path)
            For Each dir As String In dirs
                Dim category As DiskMasterFormsCategoryExample = New DiskMasterFormsCategoryExample(_repository, System.IO.Path.GetFileNameWithoutExtension(dir), dir, Me)
                _childCategories.AddCategory(category)
                category.Refresh()
            Next dir
        End Sub

        Friend Sub New(ByVal repositoryParam As IMasterFormsRepository, ByVal nameParam As String, ByVal pathParam As String, ByVal parentParam As IMasterFormsCategory)
            _repository = repositoryParam
            _name = nameParam
            _parent = parentParam
            _path = pathParam
            _recognitionEngine = New FormRecognitionEngine()
            _childCategories = New MasterFormsCategoryCollection()
            _masterForms = New MasterFormCollection()
        End Sub
    End Class
End Namespace
