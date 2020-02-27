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
Imports Leadtools.Demos

Namespace MainDemo
   Partial Public Class ShearDialog : Inherits Form
      Private Shared _firstTimer As Boolean = True
      Private Shared _initialAngle As Integer
      Private Shared _initialHorizontal As Boolean
      Private Shared _initialFillColor As RasterColor

      Public Angle As Integer
      Public Horizontal As Boolean
      Public FillColor As RasterColor

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub ShearDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         If _firstTimer Then
            _firstTimer = False
            Dim command As ShearCommand = New ShearCommand()
            _initialAngle = command.Angle
            _initialHorizontal = command.Horizontal
            _initialFillColor = command.FillColor
         End If

         Angle = CInt(_initialAngle / 100)
         Horizontal = _initialHorizontal
         FillColor = _initialFillColor

         _numAngle.Value = Angle

         _rbHorizontal.Checked = Horizontal
         _rbVertical.Checked = Not Horizontal
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numAngle.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _pnlFillColor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles _pnlFillColor.Paint
         e.Graphics.FillRectangle(New SolidBrush(Converters.ToGdiPlusColor(FillColor)), _pnlFillColor.ClientRectangle)
      End Sub

      Private Sub _btnFillColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnFillColor.Click
         If Tools.ShowColorDialog(Me, FillColor) Then
            _pnlFillColor.Refresh()
         End If
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Angle = CInt(_numAngle.Value) * 100
         Horizontal = _rbHorizontal.Checked

         _initialAngle = Angle
         _initialHorizontal = Horizontal
         _initialFillColor = FillColor
      End Sub
   End Class
End Namespace
