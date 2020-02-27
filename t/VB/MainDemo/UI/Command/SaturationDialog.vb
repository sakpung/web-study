' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.Drawing

Namespace MainDemo
   Partial Public Class SaturationDialog : Inherits Form
      Private WithEvents _beforeViewer As ImagePreviewCtrl
      Private WithEvents _afterViewer As ImagePreviewCtrl
      Private _originalImage As RasterImage
      Private _afterImage As RasterImage
      Private _internalSaturationValue As Integer
      Private _saturation As Integer

      Public Property Saturation() As Integer
         Set(ByVal value As Integer)
            _saturation = value
         End Set
         Get
            Return _saturation
         End Get
      End Property

      Public Sub New(ByVal image As RasterImage, ByVal paintProperties As RasterPaintProperties)
         Try
            InitializeComponent()

            If Not image Is Nothing Then
               Dim clone As CloneCommand = New CloneCommand()

               clone.Run(image)

               _originalImage = image
               _afterImage = clone.DestinationImage

               _beforeViewer = New ImagePreviewCtrl(_originalImage, paintProperties, _lblBefore.Location, _lblBefore.Size)
               _afterViewer = New ImagePreviewCtrl(_afterImage, paintProperties, _lblAfter.Location, _lblAfter.Size)

               Controls.Add(_beforeViewer)
               Controls.Add(_afterViewer)
               _beforeViewer.BringToFront()
               _afterViewer.BringToFront()
            Else
               _tsZoomLevel.Visible = False
            End If

            _internalSaturationValue = 0
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Protected Sub UpdateValues()
         Try
            If Not (_originalImage Is Nothing) Then
               Dim tempImage As RasterImage
               Dim clone As CloneCommand = New CloneCommand()

               clone.Run(_originalImage)

               tempImage = clone.DestinationImage

               If DoEffect(tempImage) Then
                  If Not _afterImage Is Nothing Then
                     _afterImage.Dispose()

                     _afterImage = Nothing
                  End If

                  _afterImage = tempImage

                  _afterViewer.Image = _afterImage

                  _afterViewer.OffsetImage(_beforeViewer.Offset)

                  _afterViewer.Invalidate()
               End If
            End If
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Protected Overridable Function DoEffect(ByRef effectedImage As RasterImage) As Boolean
         Try
            Dim command As ChangeSaturationCommand = New ChangeSaturationCommand(_internalSaturationValue)

            AddHandler command.Progress, AddressOf command_Progress

            If RasterImageChangedFlags.None = command.Run(effectedImage) Then
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
            If Not _beforeViewer.Image Is Nothing Then
               _tsbtnFit.Checked = False
               _tsbtnNormal.Checked = True

               _beforeViewer.FitView = False
               _afterViewer.FitView = False
            End If
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Private Sub _tsbtnFit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _tsbtnFit.Click
         Try
            If Not _beforeViewer.Image Is Nothing Then
               _tsbtnFit.Checked = True
               _tsbtnNormal.Checked = False

               _beforeViewer.FitView = True
               _afterViewer.FitView = True
            End If
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Private Sub SaturationDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         Try
            If Not _beforeViewer.Image Is Nothing Then
               _tsbtnFit.Checked = False
               _tsbtnNormal.Checked = True
            End If

            _internalSaturationValue = Saturation

            If (_internalSaturationValue / 10) < _numValue.Minimum Then
               _internalSaturationValue = CInt(_numValue.Minimum)
               Saturation = CInt(_numValue.Minimum)
            End If

            If (_internalSaturationValue / 10) > _numValue.Maximum Then
               _internalSaturationValue = CInt(_numValue.Maximum)
               Saturation = CInt(_numValue.Maximum)
            End If

            _numValue.Value = CInt(_internalSaturationValue / 10)
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numValue.Leave
         Try
            If _numValue.Value < _numValue.Minimum Then
               _numValue.Value = _numValue.Minimum
            ElseIf _numValue.Value > _numValue.Maximum Then
               _numValue.Value = _numValue.Maximum
            End If

            _internalSaturationValue = CInt(_numValue.Value) * 10

            UpdateValues()
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Private Sub _numValue_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numValue.ValueChanged
         Try
            _internalSaturationValue = CInt(_numValue.Value) * 10

            UpdateValues()
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Try
            Saturation = _internalSaturationValue
         Catch ex As Exception
            Throw ex
         End Try
      End Sub
      Private Sub _beforeViewer_PanImage(ByVal sender As Object, ByVal e As PanImageEvent) Handles _beforeViewer.PanImage
         _afterViewer.OffsetImage(e.Offset)
      End Sub
      Private Sub _afterViewer_PanImage(ByVal sender As Object, ByVal e As PanImageEvent) Handles _afterViewer.PanImage
         _beforeViewer.OffsetImage(e.Offset)
      End Sub

   End Class
End Namespace

