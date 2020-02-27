' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace VBCustomizingWorklistDAL.DataTypes
   Public Class WorklistDataSource
      Public Sub New()
         DatabaseTags = New List(Of DatabaseDicomTags)()
      End Sub
      Public DatabaseTags As List(Of DatabaseDicomTags)
   End Class
End Namespace
