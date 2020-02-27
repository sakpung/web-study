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
   Partial Public Class LineRemoveDialog : Inherits Form
      Private Shared _firstTimer As Boolean = True
      Private Shared _initialFlags As LineRemoveCommandFlags
      Private Shared _initialRemove As LineRemoveCommandType
      Private Shared _initialGapLength As Integer
      Private Shared _initialLineVariance As Integer
      Private Shared _initialMaxLineWidth As Integer
      Private Shared _initialMaxWallPercent As Integer
      Private Shared _initialMinLineLength As Integer
      Private Shared _initialWall As Integer

      Public Flags As LineRemoveCommandFlags
      Public Remove As LineRemoveCommandType
      Public GapLength As Integer = 1
      Public LineVariance As Integer = 2
      Public MaxLineWidth As Integer = 10
      Public MaxWallPercent As Integer = 50
      Public MinLineLength As Integer = 100
      Public Wall As Integer = 10

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub LineRemoveDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         If _firstTimer Then
            _firstTimer = False
            Dim command As LineRemoveCommand = New LineRemoveCommand()
            _initialFlags = command.Flags
            _initialRemove = command.Type
            _initialGapLength = command.GapLength
            _initialLineVariance = command.Variance
            _initialMaxLineWidth = command.MaximumLineWidth
            _initialMaxWallPercent = command.MaximumWallPercent
            _initialMinLineLength = command.MinimumLineLength
            _initialWall = command.Wall
         End If

         Flags = _initialFlags
         Remove = _initialRemove
         GapLength = _initialGapLength
         LineVariance = _initialLineVariance
         MaxLineWidth = _initialMaxLineWidth
         MaxWallPercent = _initialMaxWallPercent
         MinLineLength = _initialMinLineLength
         Wall = _initialWall

         _cbImageUnchanged.Checked = (Flags And LineRemoveCommandFlags.ImageUnchanged) = LineRemoveCommandFlags.ImageUnchanged
         _cbRemoveEntire.Checked = (Flags And LineRemoveCommandFlags.RemoveEntire) = LineRemoveCommandFlags.RemoveEntire
         _cbUseVariance.Checked = (Flags And LineRemoveCommandFlags.UseVariance) = LineRemoveCommandFlags.UseVariance
         _cbUseGap.Checked = (Flags And LineRemoveCommandFlags.UseGap) = LineRemoveCommandFlags.UseGap
         _cbUseDpi.Checked = (Flags And LineRemoveCommandFlags.UseDpi) = LineRemoveCommandFlags.UseDpi

         _rbHorizontal.Checked = (Remove = LineRemoveCommandType.Horizontal)
         _rbVertical.Checked = (Remove = LineRemoveCommandType.Vertical)

         _numGapLength.Value = GapLength
         _numLineVariance.Value = LineVariance
         _numMaxLineWidth.Value = MaxLineWidth
         _numMaxWallPercent.Value = MaxWallPercent
         _numMinLineLength.Value = MinLineLength
         _numWall.Value = Wall

         UpdateControls()
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numWall.Leave, _numMinLineLength.Leave, _numMaxWallPercent.Leave, _numMaxLineWidth.Leave, _numLineVariance.Leave, _numGapLength.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Flags = LineRemoveCommandFlags.None

         If _cbImageUnchanged.Checked Then
            Flags = Flags Or LineRemoveCommandFlags.ImageUnchanged
         End If
         If _cbRemoveEntire.Checked Then
            Flags = Flags Or LineRemoveCommandFlags.RemoveEntire
         End If
         If _cbUseVariance.Checked Then
            Flags = Flags Or LineRemoveCommandFlags.UseVariance
         End If
         If _cbUseGap.Checked Then
            Flags = Flags Or LineRemoveCommandFlags.UseGap
         End If
         If _cbUseDpi.Checked Then
            Flags = Flags Or LineRemoveCommandFlags.UseDpi
         End If

         If _rbHorizontal.Checked Then
            Remove = LineRemoveCommandType.Horizontal
         End If
         If _rbVertical.Checked Then
            Remove = LineRemoveCommandType.Vertical
         End If

         GapLength = CInt(_numGapLength.Value)
         LineVariance = CInt(_numLineVariance.Value)
         MaxLineWidth = CInt(_numMaxLineWidth.Value)
         MaxWallPercent = CInt(_numMaxWallPercent.Value)
         MinLineLength = CInt(_numMinLineLength.Value)
         Wall = CInt(_numWall.Value)

         _initialFlags = Flags
         _initialRemove = Remove
         _initialGapLength = GapLength
         _initialLineVariance = LineVariance
         _initialMaxLineWidth = MaxLineWidth
         _initialMaxWallPercent = MaxWallPercent
         _initialMinLineLength = MinLineLength
         _initialWall = Wall
      End Sub

      Private Sub _cbUseDpi_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbUseDpi.CheckedChanged
         UpdateControls()
      End Sub

      Private Sub _cbUseGap_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbUseGap.CheckedChanged
         UpdateControls()
      End Sub

      Private Sub _cbUseVariance_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbUseVariance.CheckedChanged
         UpdateControls()
      End Sub

      Private Sub UpdateControls()
         Dim units As String

         ' units
         If _cbUseDpi.Checked Then
            units = "1/1000 inch"
         Else
            units = "Pixels"
         End If
         _lblUnitsWidth.Text = units
         _lblUnitsHeight.Text = units

         ' Use Gap
         _lblGapLength.Enabled = _cbUseGap.Checked
         _numGapLength.Enabled = _cbUseGap.Checked

         'Use Variance
         _lblLineVariance.Enabled = _cbUseVariance.Checked
         _numLineVariance.Enabled = _cbUseVariance.Checked
      End Sub
   End Class
End Namespace
