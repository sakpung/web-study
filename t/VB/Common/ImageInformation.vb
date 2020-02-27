' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System

Imports Leadtools

Public Class ImageInformation
   Public Image As RasterImage
   Public Name As String

   Public Sub New()
      Image = Nothing
      Name = String.Empty
   End Sub

   Public Sub New(ByVal i As RasterImage, ByVal n As String)
      Image = i
      Name = n
   End Sub

   Public Sub New(ByVal i As RasterImage)
      Image = i
      Name = "Untitled"
   End Sub
End Class
