' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.Drawing

Namespace MainDemo

   Public Class MatchHistogramDialog
      Inherits Form

      Private _DSTViewer As ImagePreviewCtrl

      Private _REFViewer As ImagePreviewCtrl

      Private _originalImage As RasterImage

      Private _DSTImage As RasterImage

      Private _REFImage As RasterImage

      Private _images As List(Of RasterImage) = New List(Of RasterImage)

        Private _imageIndex As Integer

        Private _indexList As List(Of Integer) = New List(Of Integer)

        Public ReadOnly Property ImageIndex As Integer
         Get
            Return Me._imageIndex
         End Get
      End Property

      Public Sub New(ByVal image As RasterImage, ByVal paintProperties As RasterPaintProperties, ByVal ViewerForms() As Form)
         MyBase.New()
         Try
            InitializeComponent()
            If (Not (image) Is Nothing) Then
               Dim i As Integer = 0
               Do While (i < ViewerForms.Length)
                  If ((((image.BitsPerPixel = 24) _
                              AndAlso (CType(ViewerForms(i), ViewerForm).Image.BitsPerPixel = 24)) _
                              OrElse (CType(ViewerForms(i), ViewerForm).Image.BitsPerPixel = 8)) _
                              OrElse ((image.BitsPerPixel = 8) _
                              AndAlso (CType(ViewerForms(i), ViewerForm).Image.BitsPerPixel = 8))) Then
                     Me._images.Add(CType(ViewerForms(i), ViewerForm).Image)
                        _cmbREFImage.Items.Add(System.IO.Path.GetFileName(ViewerForms(i).Text))
                        _indexList.Add(i)
                End If

                  i = (i + 1)
               Loop

               Me._imageIndex = 0
               Me._REFImage = Me._images(Me._imageIndex)
               Dim clone As CloneCommand = New CloneCommand
               clone.Run(image)
               Me._originalImage = image
               Me._DSTImage = clone.DestinationImage
               Me._DSTViewer = New ImagePreviewCtrl(Me._DSTImage, paintProperties, _lblDST.Location, _lblDST.Size)
               Me._REFViewer = New ImagePreviewCtrl(Me._REFImage, paintProperties, _lblREF.Location, _lblREF.Size)
               Controls.Add(Me._DSTViewer)
               Controls.Add(Me._REFViewer)
               Me._DSTViewer.BringToFront()
               Me._REFViewer.BringToFront()
               AddHandler Me._DSTViewer.PanImage, AddressOf Me._beforeViewer_PanImage
               AddHandler Me._REFViewer.PanImage, AddressOf Me._afterViewer_PanImage
               _cmbREFImage.SelectedIndex = 0
            Else
               _tsZoomLevel.Visible = False
            End If

         Catch ex As Exception
            Throw ex
         End Try

      End Sub

      Private Sub _beforeViewer_PanImage(ByVal sender As Object, ByVal e As PanImageEvent)
         Me._REFViewer.OffsetImage(e.Offset)
      End Sub

      Private Sub _afterViewer_PanImage(ByVal sender As Object, ByVal e As PanImageEvent)
         Me._DSTViewer.OffsetImage(e.Offset)
      End Sub

      Protected Sub UpdateValues()
         Try
            Dim tempImage As RasterImage
            Dim clone As CloneCommand = New CloneCommand
            clone.Run(Me._originalImage)
            tempImage = clone.DestinationImage
            If Me.DoEffect(tempImage) Then
               If (Not (Me._DSTImage) Is Nothing) Then
                  Me._DSTImage.Dispose()
                  Me._DSTImage = Nothing
               End If

               Me._DSTImage = tempImage
               Me._DSTViewer.Image = Me._DSTImage
               Me._DSTViewer.OffsetImage(Me._DSTViewer.Offset)
               Me._DSTViewer.Invalidate()
            End If

         Catch ex As Exception
            Throw ex
         End Try

      End Sub

      Protected Overridable Function DoEffect(ByRef effectedImage As RasterImage) As Boolean
         Try
            Dim command As MatchHistogramCommand = New MatchHistogramCommand(Me._REFImage)
            AddHandler command.Progress, AddressOf Me.command_Progress
            If (RasterImageChangedFlags.None = command.Run(effectedImage)) Then
               Return False
            End If

            'Reset progress bar
            _pbProgress.Value = 0
            Return True
         Catch ex As Exception
            Throw ex
         End Try

      End Function

      Private Sub command_Progress(ByVal sender As Object, ByVal e As RasterCommandProgressEventArgs)
         _pbProgress.Value = e.Percent
      End Sub

      Private Sub _tsbtnNormal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _tsbtnNormal.Click
         Try
            If (Not (Me._DSTViewer.Image) Is Nothing) Then
               _tsbtnFit.Checked = False
               _tsbtnNormal.Checked = True
               Me._DSTViewer.FitView = False
               Me._REFViewer.FitView = False
            End If

         Catch ex As Exception
            Throw ex
         End Try

      End Sub

      Private Sub _tsbtnFit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _tsbtnFit.Click
         Try
            If (Not (Me._DSTViewer.Image) Is Nothing) Then
               _tsbtnFit.Checked = True
               _tsbtnNormal.Checked = False
               Me._DSTViewer.FitView = True
               Me._REFViewer.FitView = True
            End If

         Catch ex As Exception
            Throw ex
         End Try

      End Sub

      Private Sub MatchHistogramDialog_Load(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If (Not (Me._DSTViewer.Image) Is Nothing) Then
               _tsbtnFit.Checked = False
               _tsbtnNormal.Checked = True
            End If

         Catch ex As Exception
            Throw ex
         End Try

      End Sub

      Private Sub _cmbREFImage_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbREFImage.SelectedIndexChanged
         Me._REFImage = Me._images(_cmbREFImage.SelectedIndex)
         Me._REFViewer.Image = Me._REFImage
         Me._REFViewer.OffsetImage(Me._DSTViewer.Offset)
         Me._REFViewer.Invalidate()
         Me.UpdateValues()
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Try
                Me._imageIndex = _indexList.Item(_cmbREFImage.SelectedIndex)
            Catch ex As Exception
            Throw ex
         End Try

      End Sub
   End Class
End Namespace
