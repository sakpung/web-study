' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text

Friend Structure MyItemData
   Private _zoneType As Integer
   Private _characterFilters As Integer
   Private _selectedDocFormatIndex As Integer
   Private _selectedOcrModuleIndex As Integer
   Private _name As String
   Private _originalName As String
   Private _imageFileName As String

   Public Sub New(ByVal name_Renamed As String, ByVal originalName_Renamed As String, ByVal zoneType As Integer, ByVal characterFilters As Integer, ByVal imageFileName_Renamed As String, ByVal selectedDocFormatIndex As Integer, ByVal selectedOcrModuleIndex_Renamed As Integer)
      _name = name_Renamed
      _originalName = originalName_Renamed
      _zoneType = zoneType
      _characterFilters = characterFilters
      _imageFileName = imageFileName_Renamed
      _selectedDocFormatIndex = selectedDocFormatIndex
      _selectedOcrModuleIndex = selectedOcrModuleIndex_Renamed
   End Sub

   Public Property ZoneType() As Integer
      Get
         Return _zoneType
      End Get
      Set(ByVal value As Integer)
         _zoneType = value
      End Set
   End Property

   Public Property CharacterFilters() As Integer
      Get
         Return _characterFilters
      End Get
      Set(ByVal value As Integer)
         _characterFilters = value
      End Set
   End Property

   Public Property Name() As String
      Get
         Return _name
      End Get
      Set(ByVal value As String)
         _name = value
      End Set
   End Property

   Public Property OriginalName() As String
      Get
         Return _originalName
      End Get
      Set(ByVal value As String)
         _originalName = value
      End Set
   End Property

   Public Property SelectedDocumentFormatIndex() As Integer
      Get
         Return _selectedDocFormatIndex
      End Get
      Set(ByVal value As Integer)
         _selectedDocFormatIndex = value
      End Set
   End Property

   Public Property SelectedOcrModuleIndex() As Integer
      Get
         Return _selectedOcrModuleIndex
      End Get
      Set(ByVal value As Integer)
         _selectedOcrModuleIndex = value
      End Set
   End Property

   Public Property ImageFileName() As String
      Get
         Return _imageFileName
      End Get
      Set(ByVal value As String)
         _imageFileName = value
      End Set
   End Property

   Public Overrides Function ToString() As String
      Return _name
   End Function
End Structure
