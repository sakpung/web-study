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
   Partial Public Class AntiAliasDialog : Inherits Form
      Private Shared _firstTimer As Boolean = True
      Private Shared _initialThreshold As Integer
      Private Shared _initialDimension As Integer
      Private Shared _initialFilter As AntiAliasingCommandType

      Public Threshold As Integer
      Public Dimension As Integer
      Public Filter As AntiAliasingCommandType

      Public Sub New(ByVal bitsPerPixel As Integer)
         InitializeComponent()

         _numDimension.Minimum = 2
         _numDimension.Maximum = 100

         _numThreshold.Minimum = 0
         Select Case bitsPerPixel
            Case 1, 2, 3, 4, 5, 6, 7, 8, 24, 32
               _numThreshold.Maximum = 255
            Case 12
               _numThreshold.Maximum = 4095
            Case 48, 64
               _numThreshold.Maximum = 65535
         End Select
      End Sub

      Private Sub AntiAliasDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         If _firstTimer Then
            _firstTimer = False
            Dim command As AntiAliasingCommand = New AntiAliasingCommand()
            _initialThreshold = command.Threshold
            _initialDimension = CInt(Math.Max(_numDimension.Minimum, Math.Min(_numDimension.Maximum, command.Dimension)))
            _initialFilter = command.Filter
         End If


         Threshold = _initialThreshold
         Dimension = _initialDimension
         Filter = _initialFilter

         Tools.FillComboBoxWithEnum(_cbFilter, GetType(AntiAliasingCommandType), Filter)

         _numThreshold.Value = Threshold
         _numDimension.Value = Dimension
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numDimension.Leave, _numThreshold.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Threshold = CInt(_numThreshold.Value)
         Dimension = CInt(_numDimension.Value)

         Filter = CType(Leadtools.Demos.Constants.GetValueFromName(GetType(AntiAliasingCommandType), CStr(_cbFilter.SelectedItem), _initialFilter), AntiAliasingCommandType)

         _initialThreshold = Threshold
         _initialDimension = Dimension
         _initialFilter = Filter
      End Sub
   End Class
End Namespace
