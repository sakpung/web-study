' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.Controls

Public Class ContrastBrightnessIntensityDialog
   Private _viewer As ImageViewer
   Private _originalImage As RasterImage
   Private _saveAutoDisposeImages As Boolean

   Private _command As New ContrastBrightnessIntensityCommand()
   Public ReadOnly Property Command() As ContrastBrightnessIntensityCommand
      Get
         Return _command
      End Get
   End Property

   Public Sub New(ByVal viewer As ImageViewer)
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
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

   Protected Overrides Sub OnFormClosed(ByVal e As System.Windows.Forms.FormClosedEventArgs)
      Dim workImage As RasterImage = _viewer.Image

      ' Set the original image back
      If Not workImage Is _originalImage Then
         _viewer.AutoDisposeImages = False
         _viewer.Image = _originalImage
         workImage.Dispose()
      End If

      _viewer.AutoDisposeImages = _saveAutoDisposeImages

      MyBase.OnFormClosed(e)
   End Sub

   Private Sub _contrastTrackBar_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _contrastTrackBar.ValueChanged
      RunCommand()
   End Sub

   Private Sub _brightnessTrackBar_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _brightnessTrackBar.ValueChanged
      RunCommand()
   End Sub

   Private Sub _intensityTrackBar_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _intensityTrackBar.ValueChanged
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
