' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Text

Imports Leadtools

Public Class UndoRedo

   Private Const _maxImages As Integer = 10

   Private _imageList() As RasterImage
   Private _index As Integer = -1
   Private _Counter As Integer = 0

   Public Sub New()
      ReDim _imageList(_maxImages - 1)
   End Sub

   Public ReadOnly Property MaxImages() As Integer
      Get

         Return _maxImages
      End Get
   End Property

   Public ReadOnly Property CurrentImage() As RasterImage
      Get
         Return _imageList(_index)
      End Get
   End Property

   Public Function GetImage(ByVal index As Integer) As RasterImage
      Return _imageList(index)
   End Function

   Public Property Counter() As Integer
      Get
         Return _Counter
      End Get
      Set(ByVal value As Integer)
         _Counter = value
      End Set
   End Property

   Public Property Index() As Integer
      Get
         Return _index
      End Get
      Set(ByVal value As Integer)
         _index = value
      End Set
   End Property

   Public Property ImageList() As RasterImage()
      Get
         Return _imageList
      End Get
      Set(ByVal value As RasterImage())
         _imageList = value
      End Set
   End Property

   Public Sub AddToUndoList(ByVal image As RasterImage)

      If (_index < _maxImages - 1) Then
         _imageList(_index + 1) = image.CloneAll()
         _index = _index + 1
         _Counter = _index + 1

      Else
         If (Not _imageList(0) Is Nothing) Then
            _imageList(0).Dispose()
         End If

         Dim Index As Integer
         For Index = 1 To MaxImages - 1
            _imageList(Index - 1) = _imageList(Index)
         Next Index

         _imageList(_index) = image.CloneAll()
         _Counter = _index + 1
      End If
   End Sub
End Class
