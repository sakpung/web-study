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
   Partial Public Class DotRemoveDialog : Inherits Form
      Private Shared _firstTimer As Boolean = True
      Private Shared _initialFlags As DotRemoveCommandFlags
      Private Shared _initialMinWidth As Integer
      Private Shared _initialMinHeight As Integer
      Private Shared _initialMaxWidth As Integer
      Private Shared _initialMaxHeight As Integer

      Public Flags As DotRemoveCommandFlags
      Public MinWidth As Integer
      Public MinHeight As Integer
      Public MaxWidth As Integer
      Public MaxHeight As Integer

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub DotRemoveDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         If _firstTimer Then
            _firstTimer = False
            Dim command As DotRemoveCommand = New DotRemoveCommand()
            _initialFlags = command.Flags
            _initialMinWidth = command.MinimumDotWidth
            _initialMinHeight = command.MinimumDotHeight
            _initialMaxWidth = command.MaximumDotWidth
            _initialMaxHeight = command.MaximumDotHeight
         End If

         Flags = _initialFlags
         MinWidth = _initialMinWidth
         MinHeight = _initialMinHeight
         MaxWidth = _initialMaxWidth
         MaxHeight = _initialMaxHeight

         _cbImageUnchanged.Checked = (Flags And DotRemoveCommandFlags.ImageUnchanged) = DotRemoveCommandFlags.ImageUnchanged
         _cbUseDiagonals.Checked = (Flags And DotRemoveCommandFlags.UseDiagonals) = DotRemoveCommandFlags.UseDiagonals
         _cbUseDpi.Checked = (Flags And DotRemoveCommandFlags.UseDpi) = DotRemoveCommandFlags.UseDpi
         _cbUseSize.Checked = (Flags And DotRemoveCommandFlags.UseSize) = DotRemoveCommandFlags.UseSize

         _numMinWidth.Value = MinWidth
         _numMinHeight.Value = MinHeight
         _numMaxWidth.Value = MaxWidth
         _numMaxHeight.Value = MaxHeight

         UpdateControls()
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numMaxHeight.Leave, _numMaxWidth.Leave, _numMinHeight.Leave, _numMinWidth.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         If _numMinWidth.Value >= _numMaxWidth.Value Then
            Messager.ShowWarning(Me, "Minimum width must be less than maximum width")
            DialogResult = System.Windows.Forms.DialogResult.None
            Return
         End If

         If _numMinHeight.Value >= _numMaxHeight.Value Then
            Messager.ShowWarning(Me, "Minimum height must be less than maximum height")
            DialogResult = System.Windows.Forms.DialogResult.None
            Return
         End If

         Flags = DotRemoveCommandFlags.None

         If _cbImageUnchanged.Checked Then
            Flags = Flags Or DotRemoveCommandFlags.ImageUnchanged
         End If
         If _cbUseDiagonals.Checked Then
            Flags = Flags Or DotRemoveCommandFlags.UseDiagonals
         End If
         If _cbUseDpi.Checked Then
            Flags = Flags Or DotRemoveCommandFlags.UseDpi
         End If
         If _cbUseSize.Checked Then
            Flags = Flags Or DotRemoveCommandFlags.UseSize
         End If

         MinWidth = CInt(_numMinWidth.Value)
         MinHeight = CInt(_numMinHeight.Value)
         MaxWidth = CInt(_numMaxWidth.Value)
         MaxHeight = CInt(_numMaxHeight.Value)

         _initialFlags = Flags
         _initialMinWidth = MinWidth
         _initialMinHeight = MinHeight
         _initialMaxWidth = MaxWidth
         _initialMaxHeight = MaxHeight
      End Sub

      Private Sub _cbUseDpi_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbUseDpi.CheckedChanged
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
