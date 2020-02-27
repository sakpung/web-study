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
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.ImageProcessing.Effects

Namespace MainDemo
   Partial Public Class InvertedTextDialog : Inherits Form
      Private Shared _firstTimer As Boolean = True
      Private Shared _initialFlags As InvertedTextCommandFlags
      Private Shared _initialMinInvertWidth As Integer
      Private Shared _initialMinInvertHeight As Integer
      Private Shared _initialMinBlackPercent As Integer
      Private Shared _initialMaxBlackPercent As Integer

      Public Flags As InvertedTextCommandFlags
      Public MinInvertWidth As Integer
      Public MinInvertHeight As Integer
      Public MinBlackPercent As Integer
      Public MaxBlackPercent As Integer

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub InvertedTextDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         If _firstTimer Then
            _firstTimer = False
            Dim command As InvertedTextCommand = New InvertedTextCommand()
            _initialFlags = command.Flags
            _initialMinInvertWidth = command.MinimumInvertWidth
            _initialMinInvertHeight = command.MinimumInvertHeight
            _initialMinBlackPercent = command.MinimumBlackPercent
            _initialMaxBlackPercent = command.MaximumBlackPercent
         End If

         Flags = _initialFlags
         MinInvertWidth = _initialMinInvertWidth
         MinInvertHeight = _initialMinInvertHeight
         MinBlackPercent = _initialMinBlackPercent
         MaxBlackPercent = _initialMaxBlackPercent

         _cbImageUnchanged.Checked = (Flags And InvertedTextCommandFlags.ImageUnchanged) = InvertedTextCommandFlags.ImageUnchanged
         _cbUseDiagonals.Checked = (Flags And InvertedTextCommandFlags.UseDiagonals) = InvertedTextCommandFlags.UseDiagonals
         _cbUseDpi.Checked = (Flags And InvertedTextCommandFlags.UseDpi) = InvertedTextCommandFlags.UseDpi

         _numMinInvertWidth.Value = MinInvertWidth
         _numMinInvertHeight.Value = MinInvertHeight
         _numMinBlackPercent.Value = MinBlackPercent
         _numMaxBlackPercent.Value = MaxBlackPercent

         UpdateControls()
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numMaxBlackPercent.Leave, _numMinBlackPercent.Leave, _numMinInvertHeight.Leave, _numMinInvertWidth.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Flags = InvertedTextCommandFlags.None

         If _cbImageUnchanged.Checked Then
            Flags = Flags Or InvertedTextCommandFlags.ImageUnchanged
         End If
         If _cbUseDiagonals.Checked Then
            Flags = Flags Or InvertedTextCommandFlags.UseDiagonals
         End If
         If _cbUseDpi.Checked Then
            Flags = Flags Or InvertedTextCommandFlags.UseDpi
         End If

         MinInvertWidth = CInt(_numMinInvertWidth.Value)
         MinInvertHeight = CInt(_numMinInvertHeight.Value)
         MinBlackPercent = CInt(_numMinBlackPercent.Value)
         MaxBlackPercent = CInt(_numMaxBlackPercent.Value)

         _initialFlags = Flags
         _initialMinInvertWidth = MinInvertWidth
         _initialMinInvertHeight = MinInvertHeight
         _initialMinBlackPercent = MinBlackPercent
         _initialMaxBlackPercent = MaxBlackPercent
      End Sub

      Private Sub _cbUseDpi_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbUseDpi.CheckedChanged
         UpdateControls()
      End Sub

      Private Sub UpdateControls()
         ' Units
         Dim units As String

         If _cbUseDpi.Checked Then
            units = "1/1000 inch"
         Else
            units = "Pixels"
         End If
         _lblUnitsWidth.Text = units
         _lblUnitsHeight.Text = units
      End Sub
   End Class
End Namespace
