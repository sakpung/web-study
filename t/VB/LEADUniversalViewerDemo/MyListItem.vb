' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace VBLEADUniversalViewer
   'MyListItem: This is a use-defined class to control the items in the list-box
   Public Class MyListItem
      Private _fileFullName As String
      Private _fileShortName As String
      Private _fileType As Integer

      Public Sub New(ByVal strFileName As String, ByVal strfileShortName As String, ByVal strFileType As Integer)
         Me._fileFullName = strFileName
         Me._fileShortName = strfileShortName
         Me._fileType = strFileType
      End Sub

      Public ReadOnly Property FileFullName() As String
         Get
            Return _fileFullName
         End Get
      End Property

      Public ReadOnly Property FileType() As Integer
         Get
            Return _fileType
         End Get
      End Property

      Public ReadOnly Property FileShortName() As String
         Get
            Return _fileShortName
         End Get
      End Property
   End Class
End Namespace
