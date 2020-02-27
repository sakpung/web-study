' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports Leadtools.Codecs

'This project is provided as an example of how to implement the following three interfaces: IMasterFormsRepository, IMasterFormsCategory, and IMasterForm.
'This demo is not intended to be a running one. These three interfaces are used with Leadtools.Forms.Auto.AutoFormsEngine class to store master forms and categorize them.
'The code provided in this project is the default implementation for the three mentioned interfaces that is shipped with LEADTOOLS SDK for Forms
'This project may help a user to build his own implementation of these interfaces that fits his application, for example, database repository.

Namespace Leadtools.Forms.Auto
    Public Class DiskMasterFormsRepositoryExample : Implements IMasterFormsRepository
        Private _rasterCodecsInstance As RasterCodecs
        Private _rootCategory As DiskMasterFormsCategoryExample
        Private _path As String

        ' Get or set the RasterCodecs objcte to use when loading forms
        Public ReadOnly Property RasterCodecsInstance() As RasterCodecs Implements IMasterFormsRepository.RasterCodecsInstance
            Get
                Return _rasterCodecsInstance
            End Get
        End Property

        ' Get all the root categories in this repository
        Public ReadOnly Property RootCategory() As IMasterFormsCategory Implements IMasterFormsRepository.RootCategory
            Get
                Return _rootCategory
            End Get
        End Property

        ' Get all the path
        Public ReadOnly Property Path() As String
            Get
                Return _path
            End Get
        End Property

        Public Sub Refresh() Implements IMasterFormsRepository.Refresh
            CType(_rootCategory, DiskMasterFormsCategoryExample).Refresh()
        End Sub
        Public Sub New(ByVal rasterCodecsInstanceParam As RasterCodecs, ByVal pathParam As String)
            DiskMasterFormRepositoryInternal(rasterCodecsInstanceParam, pathParam) ', true);
        End Sub

        Private Sub DiskMasterFormRepositoryInternal(ByVal rasterCodecsInstanceParam As RasterCodecs, ByVal rootPath As String)
            Dim pathParam As String = System.IO.Path.GetFullPath(rootPath)
            ' Check if we need to create the root directory
            If (Not Directory.Exists(pathParam)) Then
                Directory.CreateDirectory(pathParam)
            End If
            _rasterCodecsInstance = rasterCodecsInstanceParam
            _path = pathParam
            ' Create the root category
            _rootCategory = New DiskMasterFormsCategoryExample(Me, "root", _path, Nothing)
            Refresh()
        End Sub
    End Class
End Namespace
