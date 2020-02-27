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
   Partial Public Class AdaptiveContrastDialog : Inherits Form
      Private _firstTime As Boolean
      Private _originalBitmap As RasterImage
      Private _mainForm As MainForm

      Public Sub New(ByVal mainForm As MainForm)
         _mainForm = mainForm
         InitializeComponent()
         _cbType.SelectedIndex = 0
         _firstTime = True
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
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
         Dim type As AdaptiveContrastCommandType = AdaptiveContrastCommandType.Exponential
         Select Case _cbType.SelectedIndex
            Case 0
               type = AdaptiveContrastCommandType.Exponential
            Case 1
               type = AdaptiveContrastCommandType.Linear
         End Select
         Dim command As AdaptiveContrastCommand = New AdaptiveContrastCommand(Convert.ToInt32(_numSize.Value), Convert.ToInt32(_numAmount.Value), type)
         _mainForm.FilterRunCommand(command, True)
      End Sub

      Private Sub AdaptiveContrastDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         If Not _originalBitmap Is Nothing Then
            _originalBitmap.Dispose()
         End If
      End Sub
   End Class
End Namespace
