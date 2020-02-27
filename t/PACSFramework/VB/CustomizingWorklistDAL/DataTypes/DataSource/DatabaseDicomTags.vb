' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace VBCustomizingWorklistDAL.DataTypes
   Public Class DatabaseDicomTags
      Public Sub New(ByVal tableName_Renamed As String, ByVal columnName_Renamed As String, ByVal dicomTag_Renamed As Long)
         TableName = tableName_Renamed
         ColumnName = columnName_Renamed
         DicomTag = dicomTag_Renamed
      End Sub

      Public TableName As String
      Public ColumnName As String
      Public DicomTag As Long
   End Class
End Namespace
