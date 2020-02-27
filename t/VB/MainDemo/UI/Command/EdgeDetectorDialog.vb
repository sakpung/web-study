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

Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.Demos

Namespace MainDemo
   Partial Public Class EdgeDetectorDialog : Inherits Form
      Private Shared _firstTimer As Boolean = True
      Private Shared _initialThreshold As Integer = 255
      Private Shared _initialFilter As EdgeDetectorCommandType = EdgeDetectorCommandType.SobelVertical
      Private _bitsPerPixel As Integer

      Public Threshold As Integer
      Public Filter As EdgeDetectorCommandType

      Public Sub New(ByVal bitsPerPixel As Integer)
         InitializeComponent()

         _bitsPerPixel = bitsPerPixel
      End Sub

      Private Sub EdgeDetectorDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         If _firstTimer Then
            _firstTimer = False
            Dim command As EdgeDetectorCommand = New EdgeDetectorCommand()
            _initialThreshold = command.Threshold
            _initialFilter = command.Filter
         End If

         Threshold = _initialThreshold
         Filter = _initialFilter

         Tools.FillComboBoxWithEnum(_cbFilter, GetType(EdgeDetectorCommandType), Filter)

         Select Case _bitsPerPixel
            Case 12
               _numThreshold.Maximum = 4095

            Case 16, 48, 64
               _numThreshold.Maximum = 65535

            Case Else
               _numThreshold.Maximum = 255
         End Select

         DialogUtilities.SetNumericValue(_numThreshold, Threshold)
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numThreshold.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Threshold = CInt(_numThreshold.Value)

         Filter = CType(Leadtools.Demos.Constants.GetValueFromName(GetType(EdgeDetectorCommandType), CStr(_cbFilter.SelectedItem), _initialFilter), EdgeDetectorCommandType)

         _initialThreshold = Threshold
         _initialFilter = Filter
      End Sub
   End Class
End Namespace
