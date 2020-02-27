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

Imports GrayScaleDemo.Leadtools.Demos
Imports Leadtools.ImageProcessing.Effects
Imports System

Partial Public Class EdgeDetectorDialog
   Inherits Form
   Private Shared _initialThreshold As Integer = 255
   Private Shared _initialFilter As EdgeDetectorCommandType = EdgeDetectorCommandType.SobelVertical
   Private _max As Integer, _min As Integer

   Public Threshold As Integer
   Public Filter As EdgeDetectorCommandType

   Public Sub New(min As Integer, max As Integer, isGray As Boolean)
      InitializeComponent()

      If isGray Then
         _max = max
         _min = min
      Else
         _max = 255
         _min = 0
      End If
   End Sub

   Private Sub EdgeDetectorDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim command As New EdgeDetectorCommand()
      _initialThreshold = command.Threshold
      _initialFilter = command.Filter


      Threshold = _initialThreshold
      Filter = _initialFilter

      Tools.FillComboBoxWithEnum(_cbFilter, GetType(EdgeDetectorCommandType), Filter)

      _numThreshold.Maximum = _max
      _numThreshold.Minimum = _min
      DialogUtilities.SetNumericValue(_numThreshold, Threshold)
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      Threshold = CInt(_numThreshold.Value)

      Filter = CType(Leadtools.Demos.Constants.GetValueFromName(GetType(EdgeDetectorCommandType), CType(_cbFilter.SelectedItem, String), _initialFilter), EdgeDetectorCommandType)

      _initialThreshold = Threshold
      _initialFilter = Filter
   End Sub
End Class
