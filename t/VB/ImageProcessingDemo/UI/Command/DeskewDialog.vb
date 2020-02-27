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
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Core

Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the DeskewCommand
   Partial Public Class DeskewDialog : Inherits Form
      Private _DeskewCommand As DeskewCommand = Nothing
      Public Sub New()
         InitializeComponent()
         _DeskewCommand = New DeskewCommand()

         'Set command default values
         InitializeUI()
      End Sub
      Public Sub New(ByVal DeskewCommand As DeskewCommand)
         InitializeComponent()
         _DeskewCommand = DeskewCommand
         InitializeUI()
      End Sub
      Public Property DeskewCommand() As DeskewCommand
         Get
            'Update command values
            UpdateCommand()
            Return _DeskewCommand
         End Get
         Set(ByVal value As DeskewCommand)
            _DeskewCommand = value
            InitializeUI()
         End Set
      End Property

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         UpdateCommand()
         Me.DialogResult = DialogResult.OK
         Me.Close()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         Me.DialogResult = DialogResult.Cancel
      End Sub

      Private Sub InitializeUI()
         ' Fill
         If (_DeskewCommand.Flags And DeskewCommandFlags.FillExposedArea) = DeskewCommandFlags.FillExposedArea Then
            _cbFillExposedArea.Checked = True
            _lblColor.BackColor = Leadtools.Demos.Converters.ToGdiPlusColor(_DeskewCommand.FillColor)
            _lblColor.Enabled = True
         End If

         ' Threshold
         If (_DeskewCommand.Flags And DeskewCommandFlags.Threshold) = DeskewCommandFlags.Threshold Then
            _cbThreshold.Checked = True
         End If

         ' Quality
         If (_DeskewCommand.Flags And DeskewCommandFlags.RotateLinear) = DeskewCommandFlags.RotateLinear Then
            _rbLow.Checked = True
         End If
         If (_DeskewCommand.Flags And DeskewCommandFlags.RotateResample) = DeskewCommandFlags.RotateResample Then
            _rbMedium.Checked = True
         End If
         If (_DeskewCommand.Flags And DeskewCommandFlags.RotateBicubic) = DeskewCommandFlags.RotateBicubic Then
            _rbHigh.Checked = True
         End If

         ' Type
         If (_DeskewCommand.Flags And DeskewCommandFlags.DocumentImage) = DeskewCommandFlags.DocumentImage Then
            _rbTextOnly.Checked = True
         End If
         If (_DeskewCommand.Flags And DeskewCommandFlags.DocumentAndPictures) = DeskewCommandFlags.DocumentAndPictures Then
            _rbTextImages.Checked = True
         End If

         ' Speed
         If (_DeskewCommand.Flags And DeskewCommandFlags.UseNormalRotate) = DeskewCommandFlags.UseNormalRotate Then
            _rbNormal.Checked = True
         End If
         If (_DeskewCommand.Flags And DeskewCommandFlags.UseHighSpeedRotate) = DeskewCommandFlags.UseHighSpeedRotate Then
            _rbFast.Checked = True
         End If
      End Sub

      Private Sub UpdateCommand()
         _DeskewCommand.Flags = CType(0, DeskewCommandFlags)

         ' Fill
         If _cbFillExposedArea.Checked Then
            _DeskewCommand.Flags = _DeskewCommand.Flags Or DeskewCommandFlags.FillExposedArea
            _DeskewCommand.FillColor = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor.BackColor)
         Else
            _DeskewCommand.Flags = _DeskewCommand.Flags Or DeskewCommandFlags.DoNotFillExposedArea
         End If

         ' Threshold
         If _cbThreshold.Checked Then
            _DeskewCommand.Flags = _DeskewCommand.Flags Or DeskewCommandFlags.Threshold
         Else
            _DeskewCommand.Flags = _DeskewCommand.Flags Or DeskewCommandFlags.NoThreshold
         End If

         ' Quality
         If _rbLow.Checked Then
            _DeskewCommand.Flags = _DeskewCommand.Flags Or DeskewCommandFlags.RotateLinear
         ElseIf _rbMedium.Checked Then
            _DeskewCommand.Flags = _DeskewCommand.Flags Or DeskewCommandFlags.RotateResample
         Else
            _DeskewCommand.Flags = _DeskewCommand.Flags Or DeskewCommandFlags.RotateBicubic
         End If

         ' Type
         If _rbTextOnly.Checked Then
            _DeskewCommand.Flags = _DeskewCommand.Flags Or DeskewCommandFlags.DocumentImage
         Else
            _DeskewCommand.Flags = _DeskewCommand.Flags Or DeskewCommandFlags.DocumentAndPictures
         End If

         ' Speed
         If _rbNormal.Checked Then
            _DeskewCommand.Flags = _DeskewCommand.Flags Or DeskewCommandFlags.UseNormalRotate
         Else
            _DeskewCommand.Flags = _DeskewCommand.Flags Or DeskewCommandFlags.UseHighSpeedRotate
         End If
      End Sub

      Private Sub _cbFillExposedArea_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cbFillExposedArea.CheckedChanged
         _lblColor.Enabled = _cbFillExposedArea.Checked
      End Sub

      Private Sub lblColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _lblColor.Click
         Dim dlg As ColorDialog = New ColorDialog()
         dlg.Color = _lblColor.BackColor
         If dlg.ShowDialog() = DialogResult.OK Then
            _lblColor.BackColor = dlg.Color
         End If
      End Sub
   End Class
End Namespace
