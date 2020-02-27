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

Imports Leadtools.Demos
Imports Leadtools
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.ImageProcessing.Core

Namespace MainDemo
   Partial Public Class BorderRemoveDialog : Inherits Form
      Private Shared _firstTimer As Boolean = True
      Private Shared _initialFlags As BorderRemoveCommandFlags
      Private Shared _initialBorder As BorderRemoveBorderFlags
      Private Shared _initialPercent As Integer
      Private Shared _initialVariance As Integer
      Private Shared _initialWhiteNoiseLength As Integer

      Public Flags As BorderRemoveCommandFlags
      Public Border As BorderRemoveBorderFlags
      Public Percent As Integer
      Public Variance As Integer
      Public WhiteNoiseLength As Integer

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub BorderRemoveDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
         If _firstTimer Then
            _firstTimer = False
            Dim command As BorderRemoveCommand = New BorderRemoveCommand()
            _initialFlags = command.Flags
            _initialBorder = command.Border
            _initialPercent = command.Percent
            _initialVariance = command.Variance
            _initialWhiteNoiseLength = command.WhiteNoiseLength
         End If

         Flags = _initialFlags
         Border = _initialBorder
         Percent = _initialPercent
         Variance = _initialVariance
         WhiteNoiseLength = _initialWhiteNoiseLength

         _cbAutoRemove.Checked = (Flags And BorderRemoveCommandFlags.AutoRemove) = BorderRemoveCommandFlags.AutoRemove
         _cbImageUnchanged.Checked = (Flags And BorderRemoveCommandFlags.ImageUnchanged) = BorderRemoveCommandFlags.ImageUnchanged
         _cbUseVariance.Checked = (Flags And BorderRemoveCommandFlags.UseVariance) = BorderRemoveCommandFlags.UseVariance

         _cbLeft.Checked = (Border And BorderRemoveBorderFlags.Left) = BorderRemoveBorderFlags.Left
         _cbTop.Checked = (Border And BorderRemoveBorderFlags.Top) = BorderRemoveBorderFlags.Top
         _cbRight.Checked = (Border And BorderRemoveBorderFlags.Right) = BorderRemoveBorderFlags.Right
         _cbBottom.Checked = (Border And BorderRemoveBorderFlags.Bottom) = BorderRemoveBorderFlags.Bottom

         _numPercent.Value = Percent
         _numVariance.Value = Variance
         _numWhiteNoiseLength.Value = WhiteNoiseLength

         UpdateControls()
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numPercent.Leave, _numVariance.Leave, _numWhiteNoiseLength.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Flags = BorderRemoveCommandFlags.None

         If _cbAutoRemove.Checked Then
            Flags = BorderRemoveCommandFlags.AutoRemove
         Else
            If _cbImageUnchanged.Checked Then
               Flags = Flags Or BorderRemoveCommandFlags.ImageUnchanged
            End If
            If _cbUseVariance.Checked Then
               Flags = Flags Or BorderRemoveCommandFlags.UseVariance
            End If
         End If

         Border = BorderRemoveBorderFlags.None

         If _cbLeft.Checked Then
            Border = Border Or BorderRemoveBorderFlags.Left
         End If
         If _cbTop.Checked Then
            Border = Border Or BorderRemoveBorderFlags.Top
         End If
         If _cbRight.Checked Then
            Border = Border Or BorderRemoveBorderFlags.Right
         End If
         If _cbBottom.Checked Then
            Border = Border Or BorderRemoveBorderFlags.Bottom
         End If

         Percent = CInt(_numPercent.Value)
         Variance = CInt(_numVariance.Value)
         WhiteNoiseLength = CInt(_numWhiteNoiseLength.Value)

         _initialFlags = Flags
         _initialBorder = Border
         _initialPercent = Percent
         _initialVariance = Variance
         _initialWhiteNoiseLength = WhiteNoiseLength
      End Sub

      Private Sub _cbUseVariance_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbUseVariance.CheckedChanged
         UpdateControls()
      End Sub

      Private Sub UpdateControls()
         _lblVariance.Enabled = _cbUseVariance.Checked
         _numVariance.Enabled = _cbUseVariance.Checked
      End Sub

      Private Sub _cbAutoRemove_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbAutoRemove.CheckedChanged
         If _cbAutoRemove.Checked Then
            _cbUseVariance.Enabled = False
            _cbImageUnchanged.Enabled = False
            _cbBottom.Enabled = False
            _cbRight.Enabled = False
            _cbTop.Enabled = False
            _cbLeft.Enabled = False
            _numWhiteNoiseLength.Enabled = False
            _numVariance.Enabled = False
            _numPercent.Enabled = False
            _lblWhiteNoiseLength.Enabled = False
            _lblVariance.Enabled = False
            _lblPercent.Enabled = False
         Else
            _cbUseVariance.Enabled = True
            _cbImageUnchanged.Enabled = True
            _cbBottom.Enabled = True
            _cbRight.Enabled = True
            _cbTop.Enabled = True
            _cbLeft.Enabled = True
            _numWhiteNoiseLength.Enabled = True
            _numVariance.Enabled = True
            _numPercent.Enabled = True
            _lblWhiteNoiseLength.Enabled = True
            _lblVariance.Enabled = True
            _lblPercent.Enabled = True
         End If
      End Sub
   End Class
End Namespace
