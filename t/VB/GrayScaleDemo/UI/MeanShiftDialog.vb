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
Imports System

Partial Public Class MeanShiftDialog
   Inherits Form
   Private Shared _radius As Integer
   Private Shared _colorDistance As Integer

   Public Radius As Integer
   Public ColorDistance As Integer

   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub MeanShiftDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim cmd As New MeanShiftCommand()
      _radius = cmd.Radius
      _colorDistance = cmd.ColorDistance

      Radius = _radius
      ColorDistance = _colorDistance

      _numRadius.Value = Radius
      _numColorDistance.Value = ColorDistance
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      Radius = CInt(_numRadius.Value)
      ColorDistance = CInt(_numColorDistance.Value)

      _radius = Radius
      _colorDistance = ColorDistance
   End Sub




End Class
