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

Imports Leadtools.ImageProcessing.Core
Imports GrayScaleDemo.Leadtools.Demos
Imports Leadtools
Imports Leadtools.ImageProcessing.Effects
Imports System

Partial Public Class DeskewDailog
   Inherits Form

   Private Shared _initialFillColorLevel As Integer
   Private Shared _initialFlags As DeskewCommandFlags
   Private _isGray As Boolean

   Public FillColorLevel As Integer
   Public Flags As DeskewCommandFlags
   Public FillColor As RasterColor

   Public Sub New(isGray As Boolean)
      InitializeComponent()
      _isGray = isGray
   End Sub

   Private Sub DeskewDailog_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim command As New DeskewCommand()
      _initialFillColorLevel = 0
      _initialFlags = command.Flags

      FillColorLevel = _initialFillColorLevel
      Flags = _initialFlags

      _rbFill.Checked = (Flags And DeskewCommandFlags.FillExposedArea) = DeskewCommandFlags.FillExposedArea
      _rbNoFill.Checked = (Flags And DeskewCommandFlags.DoNotFillExposedArea) = DeskewCommandFlags.DoNotFillExposedArea
      _numFillColorLevel.Value = FillColorLevel
      FillColor = RasterColor.Black
      _pnlRevColor.BackColor = Color.Black


      If _isGray Then
         _pnlLevel.Visible = True
         _pnlColor.Visible = False
      Else
         _pnlLevel.Visible = False
         _pnlColor.Visible = True
      End If
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      Flags = DeskewCommandFlags.DeskewImage
      FillColorLevel = CInt(_numFillColorLevel.Value)

      If _rbFill.Checked Then
         Flags = Flags Or DeskewCommandFlags.FillExposedArea
      Else
         Flags = Flags Or DeskewCommandFlags.DoNotFillExposedArea
      End If

      _initialFillColorLevel = FillColorLevel
      _initialFlags = Flags

      If _isGray Then
         FillColor = New RasterColor(FillColorLevel, FillColorLevel, FillColorLevel)
      End If
   End Sub

   Private Sub _btnRevColor_Click(sender As Object, e As EventArgs) Handles _btnRevColor.Click
      Dim colorDlg As New ColorDialog()
      If colorDlg.ShowDialog() = DialogResult.OK Then
         _pnlRevColor.BackColor = colorDlg.Color
         FillColor = Converters.FromGdiPlusColor(colorDlg.Color)
      End If
   End Sub

End Class
