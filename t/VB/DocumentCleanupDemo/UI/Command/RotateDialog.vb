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
Imports Leadtools.ImageProcessing

Namespace DocumentCleanupDemo
   Partial Public Class RotateDialog : Inherits Form

      '' The RotateCommandFlags are flags which control the behaviour of image resize methods. 
      '' This dialog will check the flags used when rotating the image. Flags used are:
      '' RotateCommandFlags.None, this flag will not resize the image or crop it.  
      '' RotateCommandFlags.Resample, this flag will perform bilinear interpolation when rotating.
      '' RotateCommandFlags.Bicubic, this flag will perform bicubic interpolation when rotating. 
      '' RotateCommandFlags.Resize, this flag will size resulting image as needed. 
      '' This dialog will also update the image Width and Height if resized option is enable.

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
         Angle = Convert.ToInt32(_initialAngle / 100)
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
         If Tools.ShowColorDialog(Me, FillColor) Then
            _pnlFillColor.Refresh()
         End If
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         '' Set the new values for the selected RotateCommandFlags flags and apply to the loaded image.
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
