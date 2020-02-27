' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools

Public Class ViewerImages
   Private _imageName As String
   Private _childFormId As Integer
   Private _image As RasterImage

   Public Property Image() As RasterImage
      Get
         Return _image
      End Get
      Set(value As RasterImage)
         _image = value
      End Set
   End Property

   Public Property ImageName() As String
      Get
         Return _imageName
      End Get
      Set(value As String)
         _imageName = value
      End Set
   End Property

   Public Property ChildFormId() As Integer
      Get
         Return _childFormId
      End Get
      Set(value As Integer)
         _childFormId = value
      End Set
   End Property

   Public Sub New(name As String, id As Integer, image As RasterImage)
      _imageName = name
      _childFormId = id
      _image = image
   End Sub

End Class
