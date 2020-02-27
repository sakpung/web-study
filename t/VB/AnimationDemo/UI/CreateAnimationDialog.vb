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
Imports System
Imports Leadtools

Namespace AnimationDemo
   Partial Public Class CreateAnimationDialog
      Inherits Form
      Private _image As RasterImage = Nothing

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub CreateAnimationDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
         _btnRemove.Enabled = False
         _lstSourceImages.Items.Clear()
         _lstAnimationImages.Items.Clear()

         For Each i As ViewerForm In TryCast(Owner, Form).MdiChildren
            _lstSourceImages.Items.Add(New Item(i.Image, i.Title))
         Next
      End Sub

      Private Sub _btnAdd_Click(sender As Object, e As EventArgs) Handles _btnAdd.Click
         Dim item As Item = TryCast(_lstSourceImages.SelectedItem, Item)

         If item IsNot Nothing Then
            _lstAnimationImages.Items.Add(item)
         End If

         If _lstAnimationImages.Items.Count > 0 Then
            _btnOk.Enabled = True
         Else
            _btnOk.Enabled = False
         End If
      End Sub

      Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
         _image = TryCast(_lstAnimationImages.Items(0), Item).Image.Clone()

         If _image IsNot Nothing Then
            For i As Integer = 1 To _lstAnimationImages.Items.Count - 1
               _image.InsertPage(i + 1, TryCast(_lstAnimationImages.Items(i), Item).Image.Clone())
            Next
         End If
      End Sub

      Public ReadOnly Property Image() As RasterImage
         Get
            Return _image
         End Get
      End Property

      Private Sub _btnRemove_Click(sender As Object, e As EventArgs) Handles _btnRemove.Click
         Dim item As Item = TryCast(_lstAnimationImages.SelectedItem, Item)

         If item IsNot Nothing Then
            _lstAnimationImages.Items.Remove(item)
         End If

         If _lstAnimationImages.Items.Count > 0 Then
            _btnOk.Enabled = True
         Else
            _btnOk.Enabled = False
         End If
      End Sub

      Private Sub _lstAnimationImages_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _lstAnimationImages.SelectedIndexChanged
         Dim item As Item = TryCast(_lstAnimationImages.SelectedItem, Item)
         If item IsNot Nothing Then
            _btnRemove.Enabled = True
         End If
      End Sub
   End Class

   Class Item
      Private _image As RasterImage = Nothing
      Private _title As String = Nothing

      Public Sub New(image As RasterImage, title As String)
         _title = title
         _image = image
      End Sub

      Public Overrides Function ToString() As String
         Return Title
      End Function

      Public ReadOnly Property Title() As String
         Get
            Return _title
         End Get
      End Property

      Public ReadOnly Property Image() As RasterImage
         Get
            Return _image
         End Get
      End Property
   End Class

End Namespace
