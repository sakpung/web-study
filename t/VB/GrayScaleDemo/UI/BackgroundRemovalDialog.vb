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

Imports Leadtools.ImageProcessing.Core

Imports GrayScaleDemo.Leadtools.Demos
Imports Leadtools
Imports Leadtools.Controls
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.ImageProcessing.Color
Imports System

Partial Public Class BackgroundRemovalDialog
   Inherits Form
   Private _originalBitmap As RasterImage
   Private _windowCenter As Integer
   Private _windowWidth As Integer
   Private _viewer As ImageViewer
   Private _form As ViewerForm
   Private _mainForm As MainForm

   Public Sub New(mainForm As MainForm, form As ViewerForm, invert As Boolean)
      InitializeComponent()

      _mainForm = mainForm
      'cell.Image.Page = cell.ActiveSubCell + 1;
      _form = form
      _viewer = form.Viewer

      _cbInvert.Checked = invert

      _windowCenter = _form.WindowLevelCenter
      _windowWidth = _form.WindowLevelWidth

      _originalBitmap = _viewer.Image.Clone()

      Dim uMaxLevels As Integer = Math.Max(form.Image.Width, form.Image.Height)

      Dim nRangeMax As Integer = CInt(Math.Ceiling(Math.Log(uMaxLevels) / Math.Log(2.0)))

      _numEdgeLevel.Maximum = New Decimal(nRangeMax)
   End Sub

   Private Sub _num_Leave(sender As Object, e As System.EventArgs) Handles _numContrast.Leave, _numEdgeLevel.Leave
      DialogUtilities.NumericOnLeave(sender)
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As System.EventArgs) Handles _btnOk.Click
      ApplyFilter()
      Me.Close()
   End Sub

   Private Sub ApplyFilter()
      Try
         Dim runImage As RasterImage = _originalBitmap.Clone()

         If _cbInvert.Checked Then
            runImage.UseLookupTable = False
            Dim invComd As New InvertCommand()
            invComd.Run(runImage)
         End If

         Dim backgroundRemovalCommand As New BackGroundRemovalCommand(Convert.ToInt32(_numRemovalFactor.Value))
         backgroundRemovalCommand.Run(runImage)

         Dim minMaxCmd As New MinMaxValuesCommand()
         minMaxCmd.Run(runImage)
         Dim min As Integer = minMaxCmd.MinimumValue
         Dim max As Integer = minMaxCmd.MaximumValue

         If _cbEnableEnhancements.Checked Then
            Dim avrcmd As New AverageCommand()
            avrcmd.Dimension = 5
            avrcmd.Run(runImage)

            Dim MSECommand As New MultiscaleEnhancementCommand()
            MSECommand.Contrast = Convert.ToInt32(_numContrast.Value * 100)
            MSECommand.EdgeCoefficient = Convert.ToInt32(_numEdgeCoef.Value * 100)
            MSECommand.EdgeLevels = Convert.ToInt32(_numEdgeLevel.Value)
            MSECommand.LatitudeCoefficient = 140
            MSECommand.LatitudeLevels = 5
            MSECommand.Flags = MultiscaleEnhancementCommandFlags.EdgeEnhancement Or MultiscaleEnhancementCommandFlags.LatitudeReduction
            MSECommand.Type = MultiscaleEnhancementCommandType.Gaussian
            MSECommand.Run(runImage)
         Else
            Dim avrcmd As New AverageCommand()
            avrcmd.Dimension = 3
            avrcmd.Run(runImage)
         End If

         Dim voiCmd As New ApplyLinearVoiLookupTableCommand()
         voiCmd.Center = (min + max) / 2
         voiCmd.Width = max - min
         voiCmd.Flags = VoiLookupTableCommandFlags.UpdateMinMax
         voiCmd.Run(runImage)

         Dim voiLutCommand As New GetLinearVoiLookupTableCommand(GetLinearVoiLookupTableCommandFlags.None)
         voiLutCommand.Run(runImage)
         _form.WindowLevelWidth = CInt(voiLutCommand.Width)
         _form.WindowLevelCenter = CInt(voiLutCommand.Center)

         _viewer.Image = runImage
      Catch generatedExceptionName As System.Exception

         'ex
      End Try

   End Sub

   Private Sub _btnCancel_Click(sender As Object, e As EventArgs) Handles _btnCancel.Click
      _viewer.Image = _originalBitmap.Clone()
      '_viewer.Invalidate();
      Me.Close()
   End Sub

   Private Sub _btnApply_Click(sender As Object, e As EventArgs) Handles _btnApply.Click
      ApplyFilter()
   End Sub

   Private Sub BackgroundRemovalDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      If _originalBitmap IsNot Nothing Then
         _originalBitmap.Dispose()
      End If
   End Sub

   Private Sub _numRemovalFactor_Scroll(sender As Object, e As EventArgs) Handles _numRemovalFactor.Scroll
      _txtRemovalFactor.Text = _numRemovalFactor.Value.ToString()
   End Sub

   Private Sub _cbEnableEnhancements_CheckedChanged(sender As Object, e As EventArgs) Handles _cbEnableEnhancements.CheckedChanged
      Dim cb As CheckBox = TryCast(sender, CheckBox)
      _numContrast.Enabled = cb.Checked
      _numEdgeLevel.Enabled = cb.Checked
      _numEdgeCoef.Enabled = cb.Checked
   End Sub
End Class
