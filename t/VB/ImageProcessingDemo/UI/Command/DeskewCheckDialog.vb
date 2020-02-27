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
   'will be used for the DeskewCheckCommand

   Partial Public Class DeskewCheckDialog : Inherits Form
      Private _DeskewCheckCommand As DeskewCheckCommand = Nothing
      Private _Color As RasterColor
      Public ReturnAngleOnly As Boolean = False
      Private _Image As RasterImage

      Public Sub New(ByVal Image As RasterImage)
         InitializeComponent()
         _Image = Image

         If Not (_Image.BitsPerPixel = 1) Then
            _rbFast.Enabled = False
         End If

         _DeskewCheckCommand = New DeskewCheckCommand()
         _Color = Leadtools.Demos.Converters.FromGdiPlusColor(System.Drawing.Color.Black)

         'Set command default values
         InitializeUI()
      End Sub
      Public Sub New(ByVal DeskewCheckCommand As DeskewCheckCommand)
         InitializeComponent()
         _DeskewCheckCommand = DeskewCheckCommand
         InitializeUI()
      End Sub
      Public Property DeskewCheckCommand() As DeskewCheckCommand
         Get
            'Update command values
            UpdateCommand()
            Return _DeskewCheckCommand
         End Get
         Set(ByVal value As DeskewCheckCommand)
            _DeskewCheckCommand = value
            InitializeUI()
         End Set
      End Property

      Public Property color() As RasterColor
         Get
            Return _Color
         End Get
         Set(ByVal value As RasterColor)
            _Color = value
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
         If (_DeskewCheckCommand.Flags And DeskewCheckCommandFlags.FillExposedArea) = DeskewCheckCommandFlags.FillExposedArea Then
            _cbFillExposedArea.Checked = True
            _lblColor.BackColor = Leadtools.Demos.Converters.ToGdiPlusColor(_DeskewCheckCommand.FillColor)
            _Color = Leadtools.Demos.Converters.FromGdiPlusColor(System.Drawing.Color.Black)
            _lblColor.Enabled = True
         End If
         'Deskew Image
         If (_DeskewCheckCommand.Flags And DeskewCheckCommandFlags.DeskewImage) = DeskewCheckCommandFlags.DeskewImage Then
            _rbDeskewImage.Checked = True
         End If

         If (_DeskewCheckCommand.Flags And DeskewCheckCommandFlags.ReturnAngleOnly) = DeskewCheckCommandFlags.ReturnAngleOnly Then
            _rbReturnAngleOnly.Checked = True
         End If
         ' Threshold
         If (_DeskewCheckCommand.Flags And DeskewCheckCommandFlags.Threshold) = DeskewCheckCommandFlags.Threshold Then
            _cbThreshold.Checked = True
         End If

         ' Quality
         If (_DeskewCheckCommand.Flags And DeskewCheckCommandFlags.RotateLinear) = DeskewCheckCommandFlags.RotateLinear Then
            _rbLow.Checked = True
         End If
         If (_DeskewCheckCommand.Flags And DeskewCheckCommandFlags.RotateResample) = DeskewCheckCommandFlags.RotateResample Then
            _rbMedium.Checked = True
         End If
         If (_DeskewCheckCommand.Flags And DeskewCheckCommandFlags.RotateBicubic) = DeskewCheckCommandFlags.RotateBicubic Then
            _rbHigh.Checked = True
         End If

         ' Type
         If (_DeskewCheckCommand.Flags And DeskewCheckCommandFlags.DocumentImage) = DeskewCheckCommandFlags.DocumentImage Then
            _rbTextOnly.Checked = True
         End If
         If (_DeskewCheckCommand.Flags And DeskewCheckCommandFlags.DocumentAndPictures) = DeskewCheckCommandFlags.DocumentAndPictures Then
            _rbTextImages.Checked = True
         End If

         ' Speed
         If (_DeskewCheckCommand.Flags And DeskewCheckCommandFlags.UseNormalRotate) = DeskewCheckCommandFlags.UseNormalRotate Then
            _rbNormal.Checked = True
         End If
         If (_DeskewCheckCommand.Flags And DeskewCheckCommandFlags.UseHighSpeedRotate) = DeskewCheckCommandFlags.UseHighSpeedRotate Then
            _rbFast.Checked = True
         End If

         'Algorithm
         If (_DeskewCheckCommand.Flags And DeskewCheckCommandFlags.DoNotUseCheckDeskew) = DeskewCheckCommandFlags.DoNotUseCheckDeskew Then
            _rbOrdinaryDeskew.Checked = True
         End If
         If (_DeskewCheckCommand.Flags And DeskewCheckCommandFlags.UseNormalCheckDeskew) = DeskewCheckCommandFlags.UseNormalCheckDeskew Then
            _rbBankCheckDeskew.Checked = True
         End If

         If (_DeskewCheckCommand.Flags And DeskewCheckCommandFlags.UseLineDetectionToDeskewCheck) = DeskewCheckCommandFlags.UseLineDetectionToDeskewCheck Then
            _rbLineDetectionDeskew.Checked = True
         End If
      End Sub

      Private Sub UpdateCommand()
         'DeskewCheckCommand.FillColor = new RasterColor(Color.Red);// _Color;
         _DeskewCheckCommand.Flags = CType(0, DeskewCheckCommandFlags)

         ' Fill
         If _cbFillExposedArea.Checked Then
            _DeskewCheckCommand.Flags = _DeskewCheckCommand.Flags Or DeskewCheckCommandFlags.FillExposedArea
         Else
            _DeskewCheckCommand.Flags = _DeskewCheckCommand.Flags Or DeskewCheckCommandFlags.DoNotFillExposedArea
         End If

         'Deskew Image
         If _rbDeskewImage.Checked Then
            _DeskewCheckCommand.Flags = _DeskewCheckCommand.Flags Or DeskewCheckCommandFlags.DeskewImage
         Else
            _DeskewCheckCommand.Flags = _DeskewCheckCommand.Flags Or DeskewCheckCommandFlags.ReturnAngleOnly
            ReturnAngleOnly = True
         End If

         ' Threshold
         If _cbThreshold.Checked Then
            _DeskewCheckCommand.Flags = _DeskewCheckCommand.Flags Or DeskewCheckCommandFlags.Threshold
         Else
            _DeskewCheckCommand.Flags = _DeskewCheckCommand.Flags Or DeskewCheckCommandFlags.NoThreshold
         End If

         ' Quality
         If _rbLow.Checked Then
            _DeskewCheckCommand.Flags = _DeskewCheckCommand.Flags Or DeskewCheckCommandFlags.RotateLinear
         ElseIf _rbMedium.Checked Then
            _DeskewCheckCommand.Flags = _DeskewCheckCommand.Flags Or DeskewCheckCommandFlags.RotateResample
         Else
            _DeskewCheckCommand.Flags = _DeskewCheckCommand.Flags Or DeskewCheckCommandFlags.RotateBicubic
         End If

         ' Type
         If _rbTextOnly.Checked Then
            _DeskewCheckCommand.Flags = _DeskewCheckCommand.Flags Or DeskewCheckCommandFlags.DocumentImage
         Else
            _DeskewCheckCommand.Flags = _DeskewCheckCommand.Flags Or DeskewCheckCommandFlags.DocumentAndPictures
         End If

         ' Speed
         If _rbNormal.Checked Then
            _DeskewCheckCommand.Flags = _DeskewCheckCommand.Flags Or DeskewCheckCommandFlags.UseNormalRotate
         Else
            _DeskewCheckCommand.Flags = _DeskewCheckCommand.Flags Or DeskewCheckCommandFlags.UseHighSpeedRotate
         End If

         'Algorithm
         If _rbOrdinaryDeskew.Checked Then
            _DeskewCheckCommand.Flags = _DeskewCheckCommand.Flags Or DeskewCheckCommandFlags.DoNotUseCheckDeskew
         End If
         If _rbBankCheckDeskew.Checked Then
            _DeskewCheckCommand.Flags = _DeskewCheckCommand.Flags Or DeskewCheckCommandFlags.UseNormalCheckDeskew
         End If
         If _rbLineDetectionDeskew.Checked Then
            _DeskewCheckCommand.Flags = _DeskewCheckCommand.Flags Or DeskewCheckCommandFlags.UseLineDetectionToDeskewCheck
         End If


      End Sub

      Private Sub _cbFillExposedArea_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cbFillExposedArea.CheckedChanged
         _lblColor.Enabled = _cbFillExposedArea.Checked
      End Sub

      Private Sub lblColor_Click(ByVal sender As Object, ByVal e As EventArgs)
         Dim dlg As ColorDialog = New ColorDialog()
         dlg.Color = _lblColor.BackColor
         If dlg.ShowDialog() = DialogResult.OK Then
            _lblColor.BackColor = dlg.Color
            _Color = Leadtools.Demos.Converters.FromGdiPlusColor(dlg.Color)
         End If
      End Sub

      Private Sub _btnColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnColor.Click
         Dim dlg As ColorDialog = New ColorDialog()
         dlg.AllowFullOpen = True
         dlg.AnyColor = True
         Dim res As DialogResult = dlg.ShowDialog(Me)
         If res = DialogResult.OK Then
            _Color = Leadtools.Demos.Converters.FromGdiPlusColor(dlg.Color)
         End If
         _lblColor.Refresh()
      End Sub

      Private Sub _lblColor_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles _lblColor.Paint
         e.Graphics.FillRectangle(New SolidBrush(Leadtools.Demos.Converters.ToGdiPlusColor(_Color)), _lblColor.ClientRectangle)
      End Sub
   End Class
End Namespace
