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
   'will be used for the DeskewExtendedCommand

   Partial Public Class DeskewExtendedDialog : Inherits Form
      Private _DeskewExtendedCommand As DeskewExtendedCommand = Nothing
      Private _Color As RasterColor
      Private _AngleRange As Integer
      Private _AngleResolution As Integer
      Private _Image As RasterImage
      
      Public Sub New(ByVal Image As RasterImage)
         InitializeComponent()
         _DeskewExtendedCommand = New DeskewExtendedCommand()
         _Color = Leadtools.Demos.Converters.FromGdiPlusColor(System.Drawing.Color.Black)
         _Image = Image

         If Not (_Image.BitsPerPixel = 1) Then
            _rbFast.Enabled = False
         End If

         _AngleRange = 2000
         _AngleResolution = 20
         InitializeUI()
      End Sub
      Public Sub New(ByVal DeskewExtendedCommand As DeskewExtendedCommand)
         InitializeComponent()
         _DeskewExtendedCommand = DeskewExtendedCommand
         InitializeUI()
      End Sub
      Public Property DeskewExtendedCommand() As DeskewExtendedCommand
         Get
            'Update command values
            UpdateCommand()
            Return _DeskewExtendedCommand
         End Get
         Set(ByVal value As DeskewExtendedCommand)
            _DeskewExtendedCommand = value
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

         If (_DeskewExtendedCommand.Flags And DeskewExtendedCommandFlags.FillExposedArea) = DeskewExtendedCommandFlags.FillExposedArea Then
            _cbFillExposedArea.Checked = True
            _lblColor.BackColor = Leadtools.Demos.Converters.ToGdiPlusColor(_DeskewExtendedCommand.FillColor)
            _Color = Leadtools.Demos.Converters.FromGdiPlusColor(System.Drawing.Color.Black)
            _lblColor.Enabled = True
         End If

         ' Threshold
         If (_DeskewExtendedCommand.Flags And DeskewExtendedCommandFlags.Threshold) = DeskewExtendedCommandFlags.Threshold Then
            _cbThreshold.Checked = True
         End If

         ' Quality
         If (_DeskewExtendedCommand.Flags And DeskewExtendedCommandFlags.RotateLinear) = DeskewExtendedCommandFlags.RotateLinear Then
            _rbLow.Checked = True
         End If
         If (_DeskewExtendedCommand.Flags And DeskewExtendedCommandFlags.RotateResample) = DeskewExtendedCommandFlags.RotateResample Then
            _rbMedium.Checked = True
         End If
         If (_DeskewExtendedCommand.Flags And DeskewExtendedCommandFlags.RotateBicubic) = DeskewExtendedCommandFlags.RotateBicubic Then
            _rbHigh.Checked = True
         End If

         ' Type
         If (_DeskewExtendedCommand.Flags And DeskewExtendedCommandFlags.DocumentImage) = DeskewExtendedCommandFlags.DocumentImage Then
            _rbTextOnly.Checked = True
         End If
         If (_DeskewExtendedCommand.Flags And DeskewExtendedCommandFlags.DocumentAndTextImage) = DeskewExtendedCommandFlags.DocumentAndTextImage Then
            _rbTextImages.Checked = True
         End If

         ' Speed
         If (_DeskewExtendedCommand.Flags And DeskewExtendedCommandFlags.UseNormalRotate) = DeskewExtendedCommandFlags.UseNormalRotate Then
            _rbNormal.Checked = True
         End If
         If (_DeskewExtendedCommand.Flags And DeskewExtendedCommandFlags.UseHighSpeedRotate) = DeskewExtendedCommandFlags.UseHighSpeedRotate Then
            _rbFast.Checked = True
         End If

         _txbAngleRange.Text = _AngleRange.ToString()
         _txtAngleResolution.Text = _AngleResolution.ToString()
      End Sub

      Private Sub UpdateCommand()
         _DeskewExtendedCommand.Flags = CType(0, DeskewExtendedCommandFlags)

         ' Fill
         If _cbFillExposedArea.Checked Then
            _DeskewExtendedCommand.Flags = _DeskewExtendedCommand.Flags Or DeskewExtendedCommandFlags.FillExposedArea
         Else
            _DeskewExtendedCommand.Flags = _DeskewExtendedCommand.Flags Or DeskewExtendedCommandFlags.DoNotFillExposedArea
         End If

         ' Threshold
         If _cbThreshold.Checked Then
            _DeskewExtendedCommand.Flags = _DeskewExtendedCommand.Flags Or DeskewExtendedCommandFlags.Threshold
         Else
            _DeskewExtendedCommand.Flags = _DeskewExtendedCommand.Flags Or DeskewExtendedCommandFlags.NoThreshold
         End If

         ' Quality
         If _rbLow.Checked Then
            _DeskewExtendedCommand.Flags = _DeskewExtendedCommand.Flags Or DeskewExtendedCommandFlags.RotateLinear
         ElseIf _rbMedium.Checked Then
            _DeskewExtendedCommand.Flags = _DeskewExtendedCommand.Flags Or DeskewExtendedCommandFlags.RotateResample
         Else
            _DeskewExtendedCommand.Flags = _DeskewExtendedCommand.Flags Or DeskewExtendedCommandFlags.RotateBicubic
         End If

         ' Type
         If _rbTextOnly.Checked Then
            _DeskewExtendedCommand.Flags = _DeskewExtendedCommand.Flags Or DeskewExtendedCommandFlags.DocumentImage
         Else
            _DeskewExtendedCommand.Flags = _DeskewExtendedCommand.Flags Or DeskewExtendedCommandFlags.DocumentAndTextImage
         End If

         ' Speed
         If _rbNormal.Checked Then
            _DeskewExtendedCommand.Flags = _DeskewExtendedCommand.Flags Or DeskewExtendedCommandFlags.UseNormalRotate
         Else
            _DeskewExtendedCommand.Flags = _DeskewExtendedCommand.Flags Or DeskewExtendedCommandFlags.UseHighSpeedRotate
         End If

         _DeskewExtendedCommand.AngleRange = Convert.ToInt32(_txbAngleRange.Text)
         _DeskewExtendedCommand.AngleResolution = Convert.ToInt32(_txtAngleResolution.Text)
      End Sub

      Private Sub _cbFillExposedArea_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cbFillExposedArea.CheckedChanged
         _lblColor.Enabled = _cbFillExposedArea.Checked
      End Sub

      Private Sub lblColor_Click(ByVal sender As Object, ByVal e As EventArgs)
         Dim dlg As ColorDialog = New ColorDialog()
         dlg.Color = _lblColor.BackColor
         If dlg.ShowDialog() = DialogResult.OK Then
            _lblColor.BackColor = dlg.Color
         End If
      End Sub

      Private Sub _tbAngleRange_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbAngleRange.Scroll
         _txbAngleRange.Text = _tbAngleRange.Value.ToString()
      End Sub

      Private Sub _txbAngleRange_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txbAngleRange.TextChanged
         Try
            _txbAngleRange.Text = MainForm.IsValidNumber(_txbAngleRange.Text, 1, 4500)

            Dim Val As Integer = Integer.Parse(_txbAngleRange.Text)
            If Val >= _tbAngleRange.Minimum AndAlso Val <= _tbAngleRange.Maximum Then
               _tbAngleRange.Value = Val
            End If

            If Convert.ToInt32(_txtAngleResolution.Text) > Convert.ToInt32(_txbAngleRange.Text) Then
               _txtAngleResolution.Text = _txbAngleRange.Text
            End If
         Catch
         End Try
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

      Private Sub _txtAngleResolution_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _txtAngleResolution.TextChanged
         Try
            _txtAngleResolution.Text = MainForm.IsValidNumber(_txtAngleResolution.Text, 1, 4500)

            Dim Val As Integer = Integer.Parse(_txbAngleRange.Text)
            If Val >= _tbAngleRange.Minimum AndAlso Val <= _tbAngleRange.Maximum Then
               _tbAngleRange.Value = Val
            End If

            If Convert.ToInt32(_txtAngleResolution.Text) > Convert.ToInt32(_txbAngleRange.Text) Then
               _txtAngleResolution.Text = _txbAngleRange.Text
            End If
         Catch
         End Try
      End Sub

      Private Sub _txtAngleResolution_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _txtAngleResolution.Leave
         If Convert.ToInt32(_txtAngleResolution.Text) > Convert.ToInt32(_txbAngleRange.Text) Then
            _txtAngleResolution.Text = _txbAngleRange.Text
         End If
      End Sub
   End Class
End Namespace
