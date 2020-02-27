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

Imports Leadtools.ImageProcessing.Effects
Imports System

Partial Public Class SkeletonDialog
   Inherits Form
   Private Shared _threshold As Integer

   Public ReadOnly Property Threshold() As Integer
      Get
         Return SkeletonDialog._threshold
      End Get
   End Property

   Public Sub New(max As Integer)
      InitializeComponent()
      _numThreshold.Maximum = max
   End Sub

   Private Sub SkeletonDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim cmd As New SkeletonCommand()
      _threshold = cmd.Threshold

      _numThreshold.Value = _threshold
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      _threshold = CInt(_numThreshold.Value)
   End Sub
End Class
