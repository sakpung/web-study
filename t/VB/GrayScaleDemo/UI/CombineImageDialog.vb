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

Imports Leadtools.ImageProcessing

Imports Leadtools
Imports System

Partial Public Class CombineImageDialog
   Inherits Form

   Private Shared _imageID As Integer
   Private Shared _flag As CombineFastCommandFlags
   Private _destImg As RasterImage
   Private _maskImg As RasterImage

   Public ReadOnly Property SourcePoint() As LeadPoint
      Get
         Return New LeadPoint(CInt(_numMaskX.Value), CInt(_numMaskY.Value))
      End Get
   End Property

   Public ReadOnly Property DestRect() As LeadRect
      Get
         Return New LeadRect(CInt(_numDestX.Value), CInt(_numDestY.Value), CInt(_numWidth.Value), CInt(_numHeight.Value))
      End Get
   End Property

   Public Property Flag() As CombineFastCommandFlags
      Get
         Return CombineImageDialog._flag
      End Get
      Set(value As CombineFastCommandFlags)
         CombineImageDialog._flag = value
      End Set
   End Property

   Public ReadOnly Property ImageID() As Integer
      Get
         Return CombineImageDialog._imageID
      End Get
   End Property
   Private _paths As List(Of ViewerImages)

   Public Sub New(paths As List(Of ViewerImages), image As RasterImage)
      InitializeComponent()
      _paths = New List(Of ViewerImages)()
      _destImg = image

      For Each tmp As ViewerImages In paths
         Try
            If tmp.Image.BitsPerPixel = _destImg.BitsPerPixel Then
               _paths.Add(tmp)
            End If
         Catch generatedExceptionName As Exception
            'ex
         End Try
      Next

      _numDestX.Maximum = _destImg.Width
      _numDestY.Maximum = _destImg.Height
   End Sub

   Private Sub CombineImageDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      For Each path As ViewerImages In _paths
         _cmbMaskImage.Items.Add(path.ImageName)
      Next
      _cmbMaskImage.SelectedIndex = 0
      _cmbCombiningOperation.SelectedIndex = 0
      _numMaskX.Value = 0
      _numWidth.Value = _destImg.Width
      _numHeight.Value = _destImg.Height
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      _imageID = _paths(_cmbMaskImage.SelectedIndex).ChildFormId
      Select Case _cmbCombiningOperation.SelectedIndex
         Case 0
            _flag = CombineFastCommandFlags.OperationOr
            Exit Select
         Case 1
            _flag = CombineFastCommandFlags.OperationXor
            Exit Select
         Case 2
            _flag = CombineFastCommandFlags.OperationAdd
            Exit Select
         Case 3
            _flag = CombineFastCommandFlags.OperationSubtractSource
            Exit Select
         Case 4
            _flag = CombineFastCommandFlags.OperationSubtractDestination
            Exit Select
         Case 5
            _flag = CombineFastCommandFlags.OperationMultiply
            Exit Select
         Case 6
            _flag = CombineFastCommandFlags.OperationDivideSource
            Exit Select
         Case 7
            _flag = CombineFastCommandFlags.OperationDivideDestination
            Exit Select
         Case 8
            _flag = CombineFastCommandFlags.OperationAverage
            Exit Select
         Case 9
            _flag = CombineFastCommandFlags.OperationMinimum
            Exit Select
         Case 10
            _flag = CombineFastCommandFlags.OperationMaximum
            Exit Select
      End Select
   End Sub

   Private Sub _num_ValueChanged(sender As Object, e As EventArgs) Handles _numDestY.ValueChanged, _numDestX.ValueChanged, _numMaskY.ValueChanged, _numMaskX.ValueChanged
      If (_maskImg IsNot Nothing) And (_destImg IsNot Nothing) Then
         Dim xMask As Integer = CInt(_maskImg.Width - _numMaskX.Value)
         Dim xDest As Integer = CInt(_destImg.Width - _numDestX.Value)
         Dim yMask As Integer = CInt(_maskImg.Height - _numMaskY.Value)
         Dim yDest As Integer = CInt(_destImg.Height - _numDestY.Value)

         _numHeight.Maximum = Math.Max(yMask, yDest)
         _numWidth.Maximum = Math.Max(xMask, xDest)
      End If
   End Sub

   Private Sub _cmbMaskImage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _cmbMaskImage.SelectedIndexChanged
      _maskImg = _paths(_cmbMaskImage.SelectedIndex).Image
      _numMaskX.Maximum = _maskImg.Width
      _numMaskY.Maximum = _maskImg.Height
   End Sub
End Class
