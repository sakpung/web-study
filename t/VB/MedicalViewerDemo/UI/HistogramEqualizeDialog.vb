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

Imports Leadtools.ImageProcessing.Color

Imports Leadtools.MedicalViewer
Imports Leadtools

Namespace MedicalViewerDemo
   Partial Public Class HistogramEqualizeDialog : Inherits Form
      Private _cell As MedicalViewerMultiCell
      Private _originalBitmap As RasterImage
      Private _firstTime As Boolean
      Private _region As RasterRegion
      Private _oldWindowWidth As Integer
      Private _oldWindowCenter As Integer
      Private _mainForm As MainForm


      Public Sub New(ByVal cell As MedicalViewerMultiCell, ByVal mainForm As MainForm)
         _cell = cell
         _mainForm = mainForm
         InitializeComponent()
         _cbColorSpace.SelectedIndex = 0
         _firstTime = True
         _oldWindowWidth = _cell.GetWindowLevelWidth()
         _oldWindowCenter = _cell.GetWindowLevelCenter()
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         _mainForm.FilterOk_Click(_originalBitmap, _firstTime, AddressOf ApplyFilter)
      End Sub

      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         _mainForm.FilterApply_Click(_firstTime, _originalBitmap, AddressOf ApplyFilter)
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         _mainForm.FilterCancel_Click(_firstTime, _originalBitmap, False)

         _cell.SetWindowLevel(_oldWindowWidth, _oldWindowCenter)
         _cell.Invalidate()
      End Sub

      Private Sub ApplyFilter()
         Dim orignalPage As Integer = _cell.Image.Page
         _cell.Image.Page = _cell.ActiveSubCell + 1
         _region = _cell.Image.GetRegion(Nothing)
         _cell.RemoveRegion()
         Dim type As HistogramEqualizeType = HistogramEqualizeType.None
         Select Case _cbColorSpace.SelectedIndex
            Case 0
               type = HistogramEqualizeType.Rgb
            Case 1
               type = HistogramEqualizeType.Yuv
            Case 2
               type = HistogramEqualizeType.Gray
         End Select

         Dim command As HistogramEqualizeCommand = New HistogramEqualizeCommand(type)

         _mainForm.FilterRunCommand(command, False)


         _cell.Image.SetRegion(Nothing, _region, RasterRegionCombineMode.Set)
         If _cell.Image.BitsPerPixel = 8 Then
            _cell.SetWindowLevel(_cell.ActiveSubCell, 255, 128)
         ElseIf _cell.Image.BitsPerPixel = 16 Then
            _cell.SetWindowLevel(_cell.ActiveSubCell, 65000, 32000)
         End If

         _cell.Image.Page = orignalPage
         _cell.Invalidate()

      End Sub

      Private Sub HistogramEqualizeDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         If Not _originalBitmap Is Nothing Then
            _originalBitmap.Dispose()
         End If
      End Sub

   End Class
End Namespace
