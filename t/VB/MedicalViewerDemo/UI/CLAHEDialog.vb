' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Imports Leadtools.ImageProcessing.Core
Imports Leadtools
Imports Leadtools.MedicalViewer


Namespace MedicalViewerDemo
   Partial Public Class CLAHEDialog : Inherits Form
      Private _firstTime As Boolean
      Private _originalBitmap As RasterImage
      Private _mainForm As MainForm
      Private _cell As MedicalViewerMultiCell
      Private _oldWindowWidth As Integer
      Private _oldWindowCenter As Integer
      Private _command As CLAHECommand

      Public Sub New(ByVal mainForm As MainForm, ByVal cell As MedicalViewerCell)
         _mainForm = mainForm
         _cell = CType(cell, MedicalViewerMultiCell)
         _command = New CLAHECommand()

         InitializeComponent()

         _firstTime = True

         _cbFlags.SelectedIndex = 0
         _cbBinsNumber.SelectedIndex = 6

         _numAlpha.Value = CDec(_command.AlphaFactor)
         _numTilesNumber.Value = CDec(_command.TilesNumber)
         _numClipLimit.Value = CDec(_command.TileHistClipLimit)

         _oldWindowWidth = _cell.GetWindowLevelWidth()
         _oldWindowCenter = _cell.GetWindowLevelCenter()

         Select Case _command.Flags
            Case CLAHECommandFlags.ApplyNormalDistribution
               _cbFlags.SelectedIndex = 0
            Case CLAHECommandFlags.ApplyExponentialDistribution
               _cbFlags.SelectedIndex = 1
            Case CLAHECommandFlags.ApplyRayliehDistribution
               _cbFlags.SelectedIndex = 2
            Case CLAHECommandFlags.ApplySigmoidDistribution
               _cbFlags.SelectedIndex = 3
         End Select
      End Sub

      Private Sub _cbFlags_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cbFlags.SelectedIndexChanged
         Select Case _cbFlags.SelectedIndex
            Case 0
               _numAlpha.Enabled = False
               _command.Flags = CLAHECommandFlags.ApplyNormalDistribution
            Case 1
               _command.Flags = CLAHECommandFlags.ApplyExponentialDistribution
               _numAlpha.Enabled = True
               _numAlpha.Maximum = 1D
            Case 2
               _command.Flags = CLAHECommandFlags.ApplyRayliehDistribution
               _numAlpha.Enabled = True
               _numAlpha.Maximum = 1D
            Case 3
               _command.Flags = CLAHECommandFlags.ApplySigmoidDistribution
               _numAlpha.Enabled = True
               _numAlpha.Maximum = 5D
         End Select
      End Sub

      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         _mainForm.FilterApply_Click(_firstTime, _originalBitmap, AddressOf ApplyFilter)
      End Sub

      Private Sub _numAlpha_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numAlpha.ValueChanged
         _command.AlphaFactor = CSng(_numAlpha.Value)
      End Sub

      Private Sub CLAHEDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         If Not _originalBitmap Is Nothing Then
            _originalBitmap.Dispose()
         End If
      End Sub

      Private Sub _numTilesNumber_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numTilesNumber.ValueChanged
         _command.TilesNumber = CInt(_numTilesNumber.Value)
      End Sub

      Private Sub _numClipLimit_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _numClipLimit.ValueChanged
         _command.TileHistClipLimit = CSng(_numClipLimit.Value)
      End Sub

      Private Sub _cbBinsNumber_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cbBinsNumber.SelectedIndexChanged
         _command.BinNumber = Integer.Parse(_cbBinsNumber.Text)
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         _mainForm.FilterOk_Click(_originalBitmap, _firstTime, AddressOf ApplyFilter)
      End Sub

      Private Sub ApplyFilter()
         _mainForm.FilterRunCommand(_command, False)

         If _cell.Image.BitsPerPixel = 16 Then
            Dim orignalPage As Integer = _cell.Image.Page
            _cell.Image.Page = _cell.ActiveSubCell + 1

            Dim voiLut As GetLinearVoiLookupTableCommand = New GetLinearVoiLookupTableCommand()
            voiLut.Run(_cell.Image)

            _cell.Image.Page = orignalPage

            _cell.SetWindowLevel(_cell.ActiveSubCell, CInt(voiLut.Width), CInt(voiLut.Center))
         End If

         _cell.Invalidate()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         _mainForm.FilterCancel_Click(_firstTime, _originalBitmap, False)

         _cell.SetWindowLevel(_oldWindowWidth, _oldWindowCenter)
         _cell.Invalidate()
      End Sub
   End Class
End Namespace
