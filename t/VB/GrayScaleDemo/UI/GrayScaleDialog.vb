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

Imports Leadtools.ImageProcessing

Partial Public Class GrayScaleDialog
   Inherits Form
   Private Shared _firstTimer As Boolean = True
   Private Shared _initialBitsPerPixel As Integer
   Public BitsPerPixel As Integer

   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub GrayScaleDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load
      If _firstTimer Then
         _firstTimer = False
         Dim command As New GrayscaleCommand()
         _initialBitsPerPixel = command.BitsPerPixel
      End If

      BitsPerPixel = _initialBitsPerPixel

      If BitsPerPixel = 8 Then
         _rb8.Checked = True
      ElseIf BitsPerPixel = 12 Then
         _rb12.Checked = True
      ElseIf BitsPerPixel = 16 Then
         _rb16.Checked = True
      End If
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As System.EventArgs) Handles _btnOk.Click
      If _rb8.Checked Then
         BitsPerPixel = 8
      ElseIf _rb12.Checked Then
         BitsPerPixel = 12
      ElseIf _rb16.Checked Then
         BitsPerPixel = 16
      End If

      _initialBitsPerPixel = BitsPerPixel
   End Sub

End Class
