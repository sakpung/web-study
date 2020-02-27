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
Imports Leadtools.Controls
Imports Leadtools.ImageProcessing.Color
Imports System

Namespace OcrDemo
   Partial Public Class ContrastBrightnessIntensityDialog
      Inherits Form
      Private _viewer As ImageViewer
      Private _originalImage As RasterImage
      Private _saveAutoDisposeImages As Boolean

      Private _command As New ContrastBrightnessIntensityCommand()
      Public ReadOnly Property Command() As ContrastBrightnessIntensityCommand
         Get
            Return _command
         End Get
      End Property

      Public Sub New(viewer As ImageViewer)
         InitializeComponent()

         _contrastValueLabel.Text = _contrastTrackBar.Value.ToString()
         _brightnessValueLabel.Text = _brightnessTrackBar.Value.ToString()
         _intensityValueLabel.Text = _intensityTrackBar.Value.ToString()

         _viewer = viewer

         ' Make a copy of the image in viewer and save it
         _originalImage = _viewer.Image

         ' Set a copy in the viewer, this is the image we will change here
         _saveAutoDisposeImages = _viewer.AutoDisposeImages
         _viewer.AutoDisposeImages = False
         _viewer.Image = _originalImage.Clone()
         _viewer.AutoDisposeImages = True

         RunCommand()
      End Sub

      Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
         Dim workImage As RasterImage = _viewer.Image

         ' Set the original image back
         If workImage IsNot _originalImage Then
            _viewer.AutoDisposeImages = False
            _viewer.Image = _originalImage
            workImage.Dispose()
         End If

         _viewer.AutoDisposeImages = _saveAutoDisposeImages

         MyBase.OnFormClosed(e)
      End Sub

      Private Sub _contrastTrackBar_ValueChanged(sender As Object, e As EventArgs) Handles _contrastTrackBar.ValueChanged
         RunCommand()
      End Sub

      Private Sub _brightnessTrackBar_ValueChanged(sender As Object, e As EventArgs) Handles _brightnessTrackBar.ValueChanged
         RunCommand()
      End Sub

      Private Sub _intensityTrackBar_ValueChanged(sender As Object, e As EventArgs) Handles _intensityTrackBar.ValueChanged
         RunCommand()
      End Sub

      Private Sub RunCommand()
         _command.Contrast = _contrastTrackBar.Value * 10
         _command.Brightness = _brightnessTrackBar.Value * 10
         _command.Intensity = _intensityTrackBar.Value * 10

         _contrastValueLabel.Text = _command.Contrast.ToString()
         _brightnessValueLabel.Text = _command.Brightness.ToString()
         _intensityValueLabel.Text = _command.Intensity.ToString()

         _viewer.Image = _originalImage.Clone()
         _command.Run(_viewer.Image)
      End Sub
   End Class
End Namespace
