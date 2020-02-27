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

Namespace ImageProcessingDemo
   'This dialog is used to allow the user to specify values which
   'will be used for the RotateCommand

   Partial Public Class RotateDialog : Inherits Form
      Private Shared _initialAngle As Integer = 0
      Private Shared _initialFlags As RotateCommandFlags = RotateCommandFlags.None
      Private Shared _initialFillColor As RasterColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.White)

      Public Angle As Integer
      Public Flags As RotateCommandFlags
      Public FillColor As RasterColor

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub RotateDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         'Set command default values
         Angle = CType(_initialAngle / 100, Integer)
         Flags = _initialFlags
         FillColor = _initialFillColor

         _numAngle.Value = Angle
         _cbResize.Checked = (Flags And RotateCommandFlags.Resize) = RotateCommandFlags.Resize

         If (Flags And RotateCommandFlags.Resample) = RotateCommandFlags.Resample Then
            _rbButtonResample.Checked = True
         ElseIf (Flags And RotateCommandFlags.Bicubic) = RotateCommandFlags.Bicubic Then
            _rbButtonBicubic.Checked = True
         Else
            _rbButtonNormal.Checked = True
         End If
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numAngle.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _pnlFillColor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles _pnlFillColor.Paint
         e.Graphics.FillRectangle(New SolidBrush(Leadtools.Demos.Converters.ToGdiPlusColor(FillColor)), _pnlFillColor.ClientRectangle)
      End Sub

      Private Sub _btnFillColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnFillColor.Click
         Dim ColorDlg As ColorDialog = New ColorDialog()
         ColorDlg.AllowFullOpen = True
         ColorDlg.AnyColor = True
         Dim res As DialogResult = ColorDlg.ShowDialog(Me)
         If res = DialogResult.OK Then
            FillColor = Leadtools.Demos.Converters.FromGdiPlusColor(ColorDlg.Color)
         End If

         _pnlFillColor.Refresh()
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         'Update command values
         Angle = CInt(_numAngle.Value) * 100

         Flags = RotateCommandFlags.None

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
         _initialFillColor = FillColor
      End Sub
   End Class
End Namespace
