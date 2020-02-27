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
Imports System

Partial Public Class MultiscaleEnhancementDialog
   Inherits Form
   Private _originalBitmap As RasterImage
   Private _viewer As ImageViewer
   Private _form As ViewerForm
   Private _mainForm As MainForm

   Public Sub New(mainForm As MainForm, form As ViewerForm)
      InitializeComponent()

      _mainForm = mainForm
      _form = form
      _viewer = form.Viewer
      _originalBitmap = _viewer.Image.Clone()

      Dim uMaxLevels As Integer = Math.Max(form.Image.Width, form.Image.Height)

      Dim nRangeMax As Integer = CInt(Math.Ceiling(Math.Log(uMaxLevels) / Math.Log(2.0)))

      _numEdgeLevel.Maximum = New Decimal(nRangeMax)
      _numLatLevel.Maximum = New Decimal(nRangeMax)

      _cbFilter.SelectedIndex = 3
   End Sub

   Private Sub _num_Leave(sender As Object, e As System.EventArgs) Handles _numEdgeLevel.Leave, _numContrast.Leave
      DialogUtilities.NumericOnLeave(sender)
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As System.EventArgs) Handles _btnOk.Click
      ApplyFilter()
      Me.Close()
   End Sub

   Private Sub _cbEdge_CheckedChanged(sender As Object, e As EventArgs) Handles _cbEdge.CheckedChanged
      _cbEdgeLevel.Enabled = _cbEdge.Checked
      _cbEdgeCoef.Enabled = _cbEdge.Checked

      _numEdgeLevel.Enabled = _cbEdgeLevel.Enabled AndAlso _cbEdgeLevel.Checked
      _numEdgeCoef.Enabled = _cbEdgeCoef.Enabled AndAlso _cbEdgeCoef.Checked
   End Sub

   Private Sub cbLatitude_CheckedChanged(sender As Object, e As EventArgs) Handles _cbLatitude.CheckedChanged
      _cbLatLevel.Enabled = _cbLatitude.Checked
      _cbLatCoef.Enabled = _cbLatitude.Checked

      _numLatLevel.Enabled = _cbLatLevel.Enabled AndAlso _cbLatLevel.Checked
      _numLatCoef.Enabled = _cbLatCoef.Enabled AndAlso _cbLatCoef.Checked
   End Sub

   Private Sub _cbEdgeLevel_CheckedChanged(sender As Object, e As EventArgs) Handles _cbEdgeLevel.CheckedChanged
      _numEdgeLevel.Enabled = _cbEdgeLevel.Checked
   End Sub

   Private Sub _cbEdgeCoef_CheckedChanged(sender As Object, e As EventArgs) Handles _cbEdgeCoef.CheckedChanged
      _numEdgeCoef.Enabled = _cbEdgeCoef.Checked
   End Sub

   Private Sub _cbLatLevel_CheckedChanged(sender As Object, e As EventArgs) Handles _cbLatLevel.CheckedChanged
      _numLatLevel.Enabled = _cbLatLevel.Checked
   End Sub

   Private Sub _cbLatCoef_CheckedChanged(sender As Object, e As EventArgs) Handles _cbLatCoef.CheckedChanged
      _numLatCoef.Enabled = _cbLatCoef.Checked
   End Sub

   Private Sub ApplyFilter()
      Dim runImage As RasterImage = _originalBitmap.Clone()

      Try

         Dim type As MultiscaleEnhancementCommandType = MultiscaleEnhancementCommandType.Gaussian
         Select Case _cbFilter.SelectedIndex
            Case 0
               type = MultiscaleEnhancementCommandType.Normal
               Exit Select
            Case 1
               type = MultiscaleEnhancementCommandType.Resample
               Exit Select
            Case 2
               type = MultiscaleEnhancementCommandType.Bicubic
               Exit Select
            Case 3
               type = MultiscaleEnhancementCommandType.Gaussian
               Exit Select
         End Select
         Dim flags As MultiscaleEnhancementCommandFlags = MultiscaleEnhancementCommandFlags.None
         If _cbEdge.Checked Then
            flags = flags Or MultiscaleEnhancementCommandFlags.EdgeEnhancement
         End If
         If _cbLatitude.Checked Then
            flags = flags Or MultiscaleEnhancementCommandFlags.LatitudeReduction
         End If

         Dim command As New MultiscaleEnhancementCommand(Convert.ToInt32(_numContrast.Value * 100), If((_cbEdgeLevel.Checked), Convert.ToInt32(_numEdgeLevel.Value), -1), If((_cbEdgeCoef.Checked), Convert.ToInt32(_numEdgeCoef.Value * 100), -1), If((_cbLatLevel.Checked), Convert.ToInt32(_numLatLevel.Value), -1), If((_cbLatCoef.Checked), Convert.ToInt32(_numLatCoef.Value * 100), -1), type, _
          flags)

         command.Run(runImage)

         _viewer.Image = runImage
      Catch ex As System.Exception
         Messager.ShowError(Me, ex)
      End Try
   End Sub

   Private Sub _btnCancel_Click(sender As Object, e As EventArgs) Handles _btnCancel.Click
      _viewer.Image = _originalBitmap.Clone()
      Me.Close()
   End Sub

   Private Sub _btnApply_Click(sender As Object, e As EventArgs) Handles _btnApply.Click
      ApplyFilter()
   End Sub

   Private Sub MultiscaleEnhancementDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      If _originalBitmap IsNot Nothing Then
         _originalBitmap.Dispose()
      End If
   End Sub
End Class
