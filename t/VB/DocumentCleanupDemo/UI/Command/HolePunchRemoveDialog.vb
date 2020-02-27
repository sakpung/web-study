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

Imports Leadtools.Demos
Imports Leadtools
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.ImageProcessing.Core

Namespace DocumentCleanupDemo
   Partial Public Class HolePunchRemoveDialog : Inherits Form

      '' The HolePunchRemoveCommand Class is part of our LEAD Document Imaging functions. This class will find and removes hole punches from your image.
      '' This dialog will update the following members of this class:
      '' HolePunchRemoveCommand.Location, this member will be used to set a value that indicates the location within the document of the hole punches to remove.
      '' HolePunchRemoveCommand.MaximumHoleCount, this member will be used to set the maximum number of holes to detect.
      '' HolePunchRemoveCommand.MaximumHoleHeight, this member will be used to set the maximum height of one of the holes of the hole punch configuration to be removed.   
      '' HolePunchRemoveCommand.MaximumHoleWidth, this member will be used to set the maximum width of one of the holes of the hole punch configuration to be removed.   
      '' HolePunchRemoveCommand.MinimumHoleCount, this member will be used to set the minimum number of holes to detect.   
      '' HolePunchRemoveCommand.MinimumHoleHeight, this member will be used to set the minimum height of one of the holes of the hole punch configuration to be removed.   
      '' HolePunchRemoveCommand.MinimumHoleWidth, this member will be used to set the minimum width of one of the holes of the hole punch configuration to be removed.   
      '' This dialog will check the following flags to determine how to process this command:
      '' HolePunchRemoveCommandFlags.UseDpi
      '' HolePunchRemoveCommandFlags.UseSize
      '' HolePunchRemoveCommandFlags.UseLocation
      '' HolePunchRemoveCommandFlags.UseCount
      '' HolePunchRemoveCommandFlags.ImageUnchanged

      Private Shared _firstTimer As Boolean = True
      Private Shared _initialFlags As HolePunchRemoveCommandFlags
      Private Shared _initialHoleLocation As HolePunchRemoveCommandLocation

      Private Shared _initialMinCount As Integer
      Private Shared _initialMaxCount As Integer
      Private Shared _initialMinWidth As Integer
      Private Shared _initialMinHeight As Integer
      Private Shared _initialMaxWidth As Integer
      Private Shared _initialMaxHeight As Integer

      Public Flags As HolePunchRemoveCommandFlags
      Public HoleLocation As HolePunchRemoveCommandLocation
      Public MinCount As Integer
      Public MaxCount As Integer
      Public MinWidth As Integer
      Public MinHeight As Integer
      Public MaxWidth As Integer
      Public MaxHeight As Integer

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub HolePunchRemoveDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         If _firstTimer Then
            _firstTimer = False
            Dim command As HolePunchRemoveCommand = New HolePunchRemoveCommand()
            _initialFlags = command.Flags
            _initialHoleLocation = command.Location
            _initialMinCount = command.MinimumHoleCount
            _initialMaxCount = command.MaximumHoleCount
            _initialMinWidth = command.MinimumHoleWidth
            _initialMinHeight = command.MinimumHoleHeight
            _initialMaxWidth = command.MaximumHoleWidth
            _initialMaxHeight = command.MaximumHoleHeight
         End If

         Flags = _initialFlags
         HoleLocation = _initialHoleLocation
         MinCount = _initialMinCount
         MaxCount = _initialMaxCount
         MinWidth = _initialMinWidth
         MinHeight = _initialMinHeight
         MaxWidth = _initialMaxWidth
         MaxHeight = _initialMaxHeight

         _cbImageUnchanged.Checked = (Flags And HolePunchRemoveCommandFlags.ImageUnchanged) = HolePunchRemoveCommandFlags.ImageUnchanged
         _cbUseCount.Checked = (Flags And HolePunchRemoveCommandFlags.UseCount) = HolePunchRemoveCommandFlags.UseCount
         _cbUseLocation.Checked = (Flags And HolePunchRemoveCommandFlags.UseLocation) = HolePunchRemoveCommandFlags.UseLocation
         _cbUseDpi.Checked = (Flags And HolePunchRemoveCommandFlags.UseDpi) = HolePunchRemoveCommandFlags.UseDpi
         _cbUseSize.Checked = (Flags And HolePunchRemoveCommandFlags.UseSize) = HolePunchRemoveCommandFlags.UseSize

         _rbButtonLeft.Checked = HoleLocation = HolePunchRemoveCommandLocation.Left
         _rbButtonTop.Checked = HoleLocation = HolePunchRemoveCommandLocation.Top
         _rbButtonRight.Checked = HoleLocation = HolePunchRemoveCommandLocation.Right
         _rbButtonBottom.Checked = HoleLocation = HolePunchRemoveCommandLocation.Bottom

         _numMinCount.Value = MinCount
         _numMaxCount.Value = MaxCount
         _numMinWidth.Value = MinWidth
         _numMinHeight.Value = MinHeight
         _numMaxWidth.Value = MaxWidth
         _numMaxHeight.Value = MaxHeight

         UpdateControls()
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numMaxHeight.Leave, _numMaxWidth.Leave, _numMaxCount.Leave, _numMinHeight.Leave, _numMinCount.Leave, _numMinWidth.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         '' Run the command depending on the checked flags in the dialog
         Flags = HolePunchRemoveCommandFlags.None

         If _cbImageUnchanged.Checked Then
            Flags = Flags Or HolePunchRemoveCommandFlags.ImageUnchanged
         End If
         If _cbUseCount.Checked Then
            Flags = Flags Or HolePunchRemoveCommandFlags.UseCount
         End If
         If _cbUseLocation.Checked Then
            Flags = Flags Or HolePunchRemoveCommandFlags.UseLocation
         End If
         If _cbUseDpi.Checked Then
            Flags = Flags Or HolePunchRemoveCommandFlags.UseDpi
         End If
         If _cbUseSize.Checked Then
            Flags = Flags Or HolePunchRemoveCommandFlags.UseSize
         End If

         If _rbButtonLeft.Checked Then
            HoleLocation = HolePunchRemoveCommandLocation.Left
         End If
         If _rbButtonTop.Checked Then
            HoleLocation = HolePunchRemoveCommandLocation.Top
         End If
         If _rbButtonRight.Checked Then
            HoleLocation = HolePunchRemoveCommandLocation.Right
         End If
         If _rbButtonBottom.Checked Then
            HoleLocation = HolePunchRemoveCommandLocation.Bottom
         End If

         MinCount = CInt(_numMinCount.Value)
         MaxCount = CInt(_numMaxCount.Value)
         MinWidth = CInt(_numMinWidth.Value)
         MinHeight = CInt(_numMinHeight.Value)
         MaxWidth = CInt(_numMaxWidth.Value)
         MaxHeight = CInt(_numMaxHeight.Value)

         _initialFlags = Flags
         _initialHoleLocation = HoleLocation
         _initialMinCount = MinCount
         _initialMaxCount = MaxCount
         _initialMinWidth = MinWidth
         _initialMinHeight = MinHeight
         _initialMaxWidth = MaxWidth
         _initialMaxHeight = MaxHeight
      End Sub

      Private Sub _cbUseDpi_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbUseDpi.CheckedChanged
         UpdateControls()
      End Sub

      Private Sub _cbUseCount_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbUseCount.CheckedChanged
         UpdateControls()
      End Sub

      Private Sub _cbUseLocation_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbUseLocation.CheckedChanged
         UpdateControls()
      End Sub

      Private Sub _cbUseSize_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbUseSize.CheckedChanged
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
         _lblUnitsMinWidth.Text = units
         _lblUnitsMinHeight.Text = units
         _lblUnitsMaxWidth.Text = units
         _lblUnitsMaxHeight.Text = units

         ' Count
         _lblMinCount.Enabled = _cbUseCount.Checked
         _numMinCount.Enabled = _cbUseCount.Checked
         _lblMaxCount.Enabled = _cbUseCount.Checked
         _numMaxCount.Enabled = _cbUseCount.Checked

         ' Location
         _gbLocation.Enabled = _cbUseLocation.Checked
         _rbButtonLeft.Enabled = _cbUseLocation.Checked
         _rbButtonTop.Enabled = _cbUseLocation.Checked
         _rbButtonRight.Enabled = _cbUseLocation.Checked
         _rbButtonBottom.Enabled = _cbUseLocation.Checked

         ' Size
         _lblMinWidth.Enabled = _cbUseSize.Checked
         _numMinWidth.Enabled = _cbUseSize.Checked
         _lblUnitsMinWidth.Enabled = _cbUseSize.Checked
         _lblMinHeight.Enabled = _cbUseSize.Checked
         _numMinHeight.Enabled = _cbUseSize.Checked
         _lblUnitsMinHeight.Enabled = _cbUseSize.Checked
         _lblMaxWidth.Enabled = _cbUseSize.Checked
         _numMaxWidth.Enabled = _cbUseSize.Checked
         _lblUnitsMaxWidth.Enabled = _cbUseSize.Checked
         _lblMaxHeight.Enabled = _cbUseSize.Checked
         _numMaxHeight.Enabled = _cbUseSize.Checked
         _lblUnitsMaxHeight.Enabled = _cbUseSize.Checked
      End Sub
   End Class
End Namespace
