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
Imports Leadtools.Demos
Imports Leadtools.Drawing

Namespace MainDemo
   Partial Public Class DeskewDialog : Inherits Form
      Private Shared _firstTimer As Boolean = True
      Private Shared _initialFillColor As RasterColor
      Private Shared _initialFlags As DeskewCommandFlags

      Public FillColor As RasterColor
      Public Flags As DeskewCommandFlags

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub DeskewDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         If _firstTimer Then
            _firstTimer = False
            Dim command As DeskewCommand = New DeskewCommand()
            _initialFillColor = command.FillColor
            _initialFlags = command.Flags
         End If

         FillColor = _initialFillColor
         Flags = _initialFlags

         _rbFill.Checked = (Flags And DeskewCommandFlags.FillExposedArea) = DeskewCommandFlags.FillExposedArea
         _rbNoFill.Checked = (Flags And DeskewCommandFlags.DoNotFillExposedArea) = DeskewCommandFlags.DoNotFillExposedArea

         UpdateControls()
      End Sub

      Private Sub UpdateControls()
         _lblFillColor.Enabled = _rbFill.Checked
         _btnFillColor.Enabled = _rbFill.Checked
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
         Flags = DeskewCommandFlags.DeskewImage

         If _rbFill.Checked Then
            Flags = Flags Or DeskewCommandFlags.FillExposedArea
         Else
            Flags = Flags Or DeskewCommandFlags.DoNotFillExposedArea
         End If

         _initialFillColor = FillColor
         _initialFlags = Flags
      End Sub

      Private Sub _rb_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _rbNoFill.CheckedChanged, _rbFill.CheckedChanged
         UpdateControls()
      End Sub
   End Class
End Namespace
