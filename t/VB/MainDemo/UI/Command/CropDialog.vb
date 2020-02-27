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


Namespace MainDemo
   Partial Public Class CropDialog : Inherits Form
      Public CropLeft As Integer
      Public CropTop As Integer
      Public CropWidth As Integer
      Public CropHeight As Integer

      Public Sub New(ByVal imageWidth As Integer, ByVal imageHeight As Integer)
         InitializeComponent()

         CropWidth = imageWidth
         CropHeight = imageHeight
      End Sub

      Private Sub CropDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         CropLeft = 0
         CropTop = 0

         _numLeft.Value = CropLeft
         _numTop.Value = CropTop
         _numWidth.Value = CropWidth
         _numHeight.Value = CropHeight
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numHeight.Leave, _numWidth.Leave, _numTop.Leave, _numLeft.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         CropLeft = CInt(_numLeft.Value)
         CropTop = CInt(_numTop.Value)
         CropWidth = CInt(_numWidth.Value)
         CropHeight = CInt(_numHeight.Value)
      End Sub
   End Class
End Namespace
