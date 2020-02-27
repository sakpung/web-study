' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms


Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.MedicalViewer
Imports Leadtools

Namespace MedicalViewerDemo
   Partial Public Class UnsharpMaskDialog : Inherits Form
      Private _originalBitmap As RasterImage
      Private _firstTime As Boolean
      Private _mainForm As MainForm

      Public Sub New(ByVal mainForm As MainForm)
         _mainForm = mainForm
         InitializeComponent()
         _cbColorSpace.SelectedIndex = 0
         _firstTime = True
      End Sub


      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numThreshold.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         _mainForm.FilterOk_Click(_originalBitmap, _firstTime, AddressOf ApplyFilter)
      End Sub

      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         _mainForm.FilterApply_Click(_firstTime, _originalBitmap, AddressOf ApplyFilter)
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         _mainForm.FilterCancel_Click(_firstTime, _originalBitmap, True)
      End Sub

      Private Sub ApplyFilter()
         Dim type As UnsharpMaskCommandColorType = UnsharpMaskCommandColorType.None

         Select Case _cbColorSpace.SelectedIndex
            Case 0
               type = UnsharpMaskCommandColorType.Rgb
            Case 1
               type = UnsharpMaskCommandColorType.Yuv
         End Select

         Dim command As UnsharpMaskCommand = New UnsharpMaskCommand(Convert.ToInt32(_numAmount.Value), Convert.ToInt32(_numRadius.Value), Convert.ToInt32(_numThreshold.Value), type)
         _mainForm.FilterRunCommand(command, True)
      End Sub

      Private Sub UnsharpMaskDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         If Not _originalBitmap Is Nothing Then
            _originalBitmap.Dispose()
         End If
      End Sub

   End Class
End Namespace
