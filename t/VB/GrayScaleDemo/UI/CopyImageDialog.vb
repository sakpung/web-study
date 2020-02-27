' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports System

Partial Public Class CopyImageDialog
   Inherits Form
   Private Shared _imageID As Integer
   Private _viewer As ViewerImages

   Public Property ImageID() As Integer
      Get
         Return CopyImageDialog._imageID
      End Get
      Set(value As Integer)
         CopyImageDialog._imageID = value
      End Set
   End Property
   Private _paths As List(Of ViewerImages)

   Public Sub New(viewer As ViewerImages, paths As List(Of ViewerImages), image As RasterImage)
      InitializeComponent()
      _paths = New List(Of ViewerImages)()
      _viewer = viewer

      For Each tmp As ViewerImages In paths
         Try
            If tmp.ImageName <> viewer.ImageName Then
               _paths.Add(tmp)
            End If
         Catch generatedExceptionName As Exception
            'ex
         End Try
      Next
   End Sub

   Private Sub CopyImageDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      For Each path As ViewerImages In _paths
         _cmbDestImage.Items.Add(path.ImageName)
      Next
      _cmbDestImage.SelectedIndex = 0
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      _imageID = _paths(_cmbDestImage.SelectedIndex).ChildFormId
   End Sub


End Class
