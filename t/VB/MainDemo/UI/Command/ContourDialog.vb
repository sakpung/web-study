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
   Partial Public Class ContourDialog : Inherits Form
      Private Shared _firstTimer As Boolean = True
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

      Private Sub ContourDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         If _firstTimer Then
            _firstTimer = False
            Dim command As ContourFilterCommand = New ContourFilterCommand()
            _initialThreshold = command.Threshold
            _initialDeltaDirection = command.DeltaDirection
            _initialMaximumError = command.MaximumError
            _initialType = command.Type
         End If

         Threshold = _initialThreshold
         DeltaDirection = _initialDeltaDirection
         MaximumError = _initialMaximumError
         Type = _initialType

         _numThreshold.Value = Threshold
         _numDeltaDirection.Value = DeltaDirection
         _numMaximumError.Value = MaximumError
         Tools.FillComboBoxWithEnum(_cbType, GetType(ContourFilterCommandType), Type)

         UpdateControls()
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numMaximumError.Leave, _numDeltaDirection.Leave, _numThreshold.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _cbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbType.SelectedIndexChanged
         UpdateControls()
      End Sub

      Private Sub UpdateControls()
         Type = CType(Leadtools.Demos.Constants.GetValueFromName(GetType(ContourFilterCommandType), CStr(_cbType.SelectedItem), _initialType), ContourFilterCommandType)
         _lblMaximumError.Enabled = (Type = ContourFilterCommandType.ApproxColor)
         _numMaximumError.Enabled = (Type = ContourFilterCommandType.ApproxColor)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Threshold = CInt(_numThreshold.Value)
         DeltaDirection = CInt(_numDeltaDirection.Value)
         MaximumError = CInt(_numMaximumError.Value)
         Type = CType(Leadtools.Demos.Constants.GetValueFromName(GetType(ContourFilterCommandType), CStr(_cbType.SelectedItem), _initialType), ContourFilterCommandType)

         _initialThreshold = Threshold
         _initialDeltaDirection = DeltaDirection
         _initialMaximumError = MaximumError
         _initialType = Type
      End Sub
   End Class
End Namespace
