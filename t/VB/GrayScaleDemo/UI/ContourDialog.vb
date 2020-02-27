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


Partial Public Class ContourDialog
   Inherits Form
   Private Shared _initialThreshold As Integer
   Private Shared _initialDeltaDirection As Integer
   Private Shared _initialMaximumError As Integer
   Private Shared _initialType As ContourFilterCommandType = ContourFilterCommandType.Thin

   Public Threshold As Integer
   Public DeltaDirection As Integer
   Public MaximumError As Integer
   Public Type As ContourFilterCommandType

   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub ContourDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
      Dim command As New ContourFilterCommand()
      _initialThreshold = command.Threshold
      _initialDeltaDirection = command.DeltaDirection
      _initialMaximumError = command.MaximumError
      _initialType = command.Type

      Threshold = _initialThreshold
      DeltaDirection = _initialDeltaDirection
      MaximumError = _initialMaximumError
      Type = _initialType

      _numThreshold.Value = Threshold
      _numDeltaDirection.Value = DeltaDirection
      _numMaximumError.Value = MaximumError
      Tools.FillComboBoxWithEnum(_cmbType, GetType(ContourFilterCommandType), Type)

      UpdateControls()
   End Sub

   Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
      Threshold = CInt(_numThreshold.Value)
      DeltaDirection = CInt(_numDeltaDirection.Value)
      MaximumError = CInt(_numMaximumError.Value)
      Type = CType(Constants.GetValueFromName(GetType(ContourFilterCommandType), CType(_cmbType.SelectedItem, String), _initialType), ContourFilterCommandType)

      _initialThreshold = Threshold
      _initialDeltaDirection = DeltaDirection
      _initialMaximumError = MaximumError
      _initialType = Type
   End Sub

   Private Sub UpdateControls()
      Type = CType(Constants.GetValueFromName(GetType(ContourFilterCommandType), CType(_cmbType.SelectedItem, String), _initialType), ContourFilterCommandType)
      _lblMaximumError.Enabled = Type = ContourFilterCommandType.ApproxColor
      _numMaximumError.Enabled = Type = ContourFilterCommandType.ApproxColor
   End Sub

   Private Sub _cbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _cmbType.SelectedIndexChanged
      If _cmbType.Text = "Approx Color" Then
         _lblMaximumError.Enabled = True
         _numMaximumError.Enabled = True
      Else
         _lblMaximumError.Enabled = False
         _numMaximumError.Enabled = False
      End If
   End Sub
End Class
