' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports GrayScaleDemo.Leadtools.Demos
Imports Leadtools
Imports Leadtools.ImageProcessing
Imports System

Partial Public Class RotateDialog
   Inherits Form
   Private Shared _initialAngle As Integer = 0
   Private Shared _initialFlags As RotateCommandFlags = RotateCommandFlags.None
   Private Shared _initialFillColorLevel As Integer
   Private _isGray As Boolean

   Public FillColor As Color
   Public Angle As Integer
   Public Flags As RotateCommandFlags
   Public FillColorLevel As Integer

   Public Sub New(isGray As Boolean)
      InitializeComponent()
      _isGray = isGray
   End Sub

   Private Sub RotateDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim cmd As New RotateCommand()
      _initialAngle = cmd.Angle
      _initialFlags = cmd.Flags
      _initialFillColorLevel = 0

      Angle = CInt(_initialAngle / 100)
      Flags = _initialFlags
      FillColorLevel = _initialFillColorLevel
      _pnlRevColor.BackColor = Converters.ToGdiPlusColor(cmd.FillColor)
      FillColor = Converters.ToGdiPlusColor(cmd.FillColor)

      _numAngle.Value = Angle
      _cbResize.Checked = (Flags And RotateCommandFlags.Resize) = RotateCommandFlags.Resize
      _numFillColorLevel.Value = FillColorLevel

      If (Flags And RotateCommandFlags.Resample) = RotateCommandFlags.Resample Then
         _rbButtonResample.Checked = True
      ElseIf (Flags And RotateCommandFlags.Bicubic) = RotateCommandFlags.Bicubic Then
         _rbButtonBicubic.Checked = True
      Else
         _rbButtonNormal.Checked = True
      End If

      If _isGray Then
         _pnlLevel.Visible = True
         _pnlColor.Visible = False
      Else
         _pnlLevel.Visible = False
         _pnlColor.Visible = True
      End If
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      Angle = CInt(_numAngle.Value) * 100

      Flags = RotateCommandFlags.None

      FillColorLevel = CInt(_numFillColorLevel.Value)

      If _cbResize.Checked Then
         Flags = Flags Or RotateCommandFlags.Resize
      End If

      If _rbButtonResample.Checked Then
         Flags = Flags Or RotateCommandFlags.Resample
      End If

      If _rbButtonBicubic.Checked Then
         Flags = Flags Or RotateCommandFlags.Bicubic
      End If

      _initialAngle = Angle
      _initialFlags = Flags
      _initialFillColorLevel = FillColorLevel

   End Sub

   Private Sub _btnCancel_Click(sender As Object, e As EventArgs) Handles _btnCancel.Click
      Close()
   End Sub

   Private Sub _btnDlgColor_Click(sender As Object, e As EventArgs) Handles _btnDlgColor.Click
      Dim colorDlg As New ColorDialog()
      If colorDlg.ShowDialog() = DialogResult.OK Then
         _pnlRevColor.BackColor = colorDlg.Color
         FillColor = colorDlg.Color
      End If
   End Sub
End Class
