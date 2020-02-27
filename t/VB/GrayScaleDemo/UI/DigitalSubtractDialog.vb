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
Imports System.IO

Imports Leadtools.ImageProcessing.Core
Imports Leadtools
Imports System

Partial Public Class DigitalSubtractDialog
   Inherits Form
   Private Shared _flags As DigitalSubtractCommandFlags
   Private Shared _imageID As Integer
   Private _paths As List(Of ViewerImages)

   Public ReadOnly Property ImageID() As Integer
      Get
         Return DigitalSubtractDialog._imageID
      End Get
   End Property

   Public ReadOnly Property Flags() As DigitalSubtractCommandFlags
      Get
         Return DigitalSubtractDialog._flags
      End Get
   End Property

   Public Sub New(paths As List(Of ViewerImages), image As RasterImage)
      InitializeComponent()
      _paths = New List(Of ViewerImages)()

      For Each tmp As ViewerImages In paths
         Try
            If tmp.Image.BitsPerPixel = image.BitsPerPixel AndAlso tmp.Image.Width = image.Width AndAlso tmp.Image.Height = image.Height AndAlso tmp.Image.GrayscaleMode = image.GrayscaleMode Then
               _paths.Add(tmp)
            End If
         Catch generatedExceptionName As Exception
            'ex
         End Try
      Next
   End Sub

   Private Sub DigitalSubtractDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim cmd As New DigitalSubtractCommand()
      _flags = cmd.Flags


      For Each path As ViewerImages In _paths
         _cmbMaskImage.Items.Add(path.ImageName)
      Next

      _cmbMaskImage.SelectedIndex = 0

      _cbContrastEnhancement.Checked = (_flags And DigitalSubtractCommandFlags.ContrastEnhancement) <> 0
      _cbOptimizeRange.Checked = (_flags And DigitalSubtractCommandFlags.OptimizeRange) <> 0
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      _imageID = _paths(_cmbMaskImage.SelectedIndex).ChildFormId

      _flags = DigitalSubtractCommandFlags.None

      If _cbOptimizeRange.Checked Then
         _flags = _flags Or DigitalSubtractCommandFlags.OptimizeRange
      End If

      If _cbContrastEnhancement.Checked Then
         _flags = _flags Or DigitalSubtractCommandFlags.ContrastEnhancement
      End If
   End Sub

End Class
