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

Imports Leadtools.ImageProcessing.Core


Imports Leadtools.MedicalViewer
Imports Leadtools

Namespace MedicalViewerDemo
   Partial Public Class MultiscaleEnhancementDialog : Inherits Form
      Private _originalBitmap As RasterImage
      Private _firstTime As Boolean
      Private _mainForm As MainForm


      Public Sub New(ByVal mainForm As MainForm, ByVal cell As MedicalViewerCell)
         _mainForm = mainForm
         InitializeComponent()

         Dim orignalPage As Integer = cell.Image.Page
         cell.Image.Page = cell.ActiveSubCell + 1

         Dim uMaxLevels As Integer = Math.Max(cell.Image.Width, cell.Image.Height)

         Dim nRangeMax As Integer = CInt(Math.Ceiling(Math.Log(uMaxLevels) / Math.Log(2.0)))

         _numEdgeLevel.Maximum = New Decimal(nRangeMax)
         _numLatLevel.Maximum = New Decimal(nRangeMax)

         _cbFilter.SelectedIndex = 3
         _firstTime = True
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numEdgeLevel.Leave, _numContrast.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         _mainForm.FilterOk_Click(_originalBitmap, _firstTime, AddressOf ApplyFilter)
      End Sub

      Private Sub _cbEdge_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cbEdge.CheckedChanged
         _cbEdgeLevel.Enabled = _cbEdge.Checked
         _cbEdgeCoef.Enabled = _cbEdge.Checked

         _numEdgeLevel.Enabled = _cbEdge.Checked
         _numEdgeCoef.Enabled = _cbEdge.Checked
      End Sub

      Private Sub cbLatitude_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cbLatitude.CheckedChanged
         _cbLatLevel.Enabled = _cbLatitude.Checked
         _cbLatCoef.Enabled = _cbLatitude.Checked

         _numLatLevel.Enabled = _cbLatitude.Checked
         _numLatCoef.Enabled = _cbLatitude.Checked
      End Sub

      Private Sub _cbEdgeLevel_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cbEdgeLevel.CheckedChanged
         _numEdgeLevel.Enabled = _cbEdgeLevel.Checked
      End Sub

      Private Sub _cbEdgeCoef_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cbEdgeCoef.CheckedChanged
         _numEdgeCoef.Enabled = _cbEdgeCoef.Checked
      End Sub

      Private Sub _cbLatLevel_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cbLatLevel.CheckedChanged
         _numLatLevel.Enabled = _cbLatLevel.Checked
      End Sub

      Private Sub _cbLatCoef_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cbLatCoef.CheckedChanged
         _numLatCoef.Enabled = _cbLatCoef.Checked
      End Sub

      Private Sub ApplyFilter()
         Dim type As MultiscaleEnhancementCommandType = MultiscaleEnhancementCommandType.Gaussian
         Select Case _cbFilter.SelectedIndex
            Case 0
               type = MultiscaleEnhancementCommandType.Normal
            Case 1
               type = MultiscaleEnhancementCommandType.Resample
            Case 2
               type = MultiscaleEnhancementCommandType.Bicubic
            Case 3
               type = MultiscaleEnhancementCommandType.Gaussian
         End Select
         Dim flags As MultiscaleEnhancementCommandFlags = MultiscaleEnhancementCommandFlags.None
         If _cbEdge.Checked Then
            flags = flags Or MultiscaleEnhancementCommandFlags.EdgeEnhancement
         End If
         If _cbLatitude.Checked Then
            flags = flags Or MultiscaleEnhancementCommandFlags.LatitudeReduction
         End If

         Dim command As MultiscaleEnhancementCommand
         If (_cbEdgeLevel.Checked) Then
            If (_cbEdgeCoef.Checked) Then
               If (_cbLatLevel.Checked) Then
                  If (_cbLatCoef.Checked) Then
                     command = New MultiscaleEnhancementCommand(Convert.ToInt32(_numContrast.Value * 100), Convert.ToInt32(_numEdgeLevel.Value), Convert.ToInt32(_numEdgeCoef.Value * 100), Convert.ToInt32(_numLatLevel.Value), Convert.ToInt32(_numLatCoef.Value * 100), type, flags)
                  Else
                     command = New MultiscaleEnhancementCommand(Convert.ToInt32(_numContrast.Value * 100), Convert.ToInt32(_numEdgeLevel.Value), Convert.ToInt32(_numEdgeCoef.Value * 100), Convert.ToInt32(_numLatLevel.Value), -1, type, flags)
                  End If
               Else
                  If (_cbLatCoef.Checked) Then
                     command = New MultiscaleEnhancementCommand(Convert.ToInt32(_numContrast.Value * 100), Convert.ToInt32(_numEdgeLevel.Value), Convert.ToInt32(_numEdgeCoef.Value * 100), -1, Convert.ToInt32(_numLatCoef.Value * 100), type, flags)
                  Else
                     command = New MultiscaleEnhancementCommand(Convert.ToInt32(_numContrast.Value * 100), Convert.ToInt32(_numEdgeLevel.Value), Convert.ToInt32(_numEdgeCoef.Value * 100), -1, -1, type, flags)
                  End If
               End If
            Else
               If (_cbLatLevel.Checked) Then
                  If (_cbLatCoef.Checked) Then
                     command = New MultiscaleEnhancementCommand(Convert.ToInt32(_numContrast.Value * 100), Convert.ToInt32(_numEdgeLevel.Value), -1, Convert.ToInt32(_numLatLevel.Value), Convert.ToInt32(_numLatCoef.Value * 100), type, flags)
                  Else
                     command = New MultiscaleEnhancementCommand(Convert.ToInt32(_numContrast.Value * 100), Convert.ToInt32(_numEdgeLevel.Value), -1, Convert.ToInt32(_numLatLevel.Value), -1, type, flags)
                  End If
               Else
                  If (_cbLatCoef.Checked) Then
                     command = New MultiscaleEnhancementCommand(Convert.ToInt32(_numContrast.Value * 100), Convert.ToInt32(_numEdgeLevel.Value), -1, -1, Convert.ToInt32(_numLatCoef.Value * 100), type, flags)
                  Else
                     command = New MultiscaleEnhancementCommand(Convert.ToInt32(_numContrast.Value * 100), Convert.ToInt32(_numEdgeLevel.Value), -1, -1, -1, type, flags)
                  End If
               End If
            End If
         Else
            If (_cbEdgeCoef.Checked) Then
               If (_cbLatLevel.Checked) Then
                  If (_cbLatCoef.Checked) Then
                     command = New MultiscaleEnhancementCommand(Convert.ToInt32(_numContrast.Value * 100), -1, Convert.ToInt32(_numEdgeCoef.Value * 100), Convert.ToInt32(_numLatLevel.Value), Convert.ToInt32(_numLatCoef.Value * 100), type, flags)
                  Else
                     command = New MultiscaleEnhancementCommand(Convert.ToInt32(_numContrast.Value * 100), -1, Convert.ToInt32(_numEdgeCoef.Value * 100), Convert.ToInt32(_numLatLevel.Value), -1, type, flags)
                  End If
               Else
                  If (_cbLatCoef.Checked) Then
                     command = New MultiscaleEnhancementCommand(Convert.ToInt32(_numContrast.Value * 100), -1, Convert.ToInt32(_numEdgeCoef.Value * 100), -1, Convert.ToInt32(_numLatCoef.Value * 100), type, flags)
                  Else
                     command = New MultiscaleEnhancementCommand(Convert.ToInt32(_numContrast.Value * 100), -1, Convert.ToInt32(_numEdgeCoef.Value * 100), -1, -1, type, flags)
                  End If
               End If
            Else
               If (_cbLatLevel.Checked) Then
                  If (_cbLatCoef.Checked) Then
                     command = New MultiscaleEnhancementCommand(Convert.ToInt32(_numContrast.Value * 100), -1, -1, Convert.ToInt32(_numLatLevel.Value), Convert.ToInt32(_numLatCoef.Value * 100), type, flags)
                  Else
                     command = New MultiscaleEnhancementCommand(Convert.ToInt32(_numContrast.Value * 100), -1, -1, Convert.ToInt32(_numLatLevel.Value), -1, type, flags)
                  End If
               Else
                  If (_cbLatCoef.Checked) Then
                     command = New MultiscaleEnhancementCommand(Convert.ToInt32(_numContrast.Value * 100), -1, -1, -1, Convert.ToInt32(_numLatCoef.Value * 100), type, flags)
                  Else
                     command = New MultiscaleEnhancementCommand(Convert.ToInt32(_numContrast.Value * 100), -1, -1, -1, -1, type, flags)
                  End If
               End If
            End If
         End If

         _mainForm.FilterRunCommand(command, True)
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         _mainForm.FilterCancel_Click(_firstTime, _originalBitmap, True)
      End Sub

      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         _mainForm.FilterApply_Click(_firstTime, _originalBitmap, AddressOf ApplyFilter)
      End Sub

      Private Sub MultiscaleEnhancementDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         If Not _originalBitmap Is Nothing Then
            _originalBitmap.Dispose()
         End If
      End Sub
   End Class
End Namespace
