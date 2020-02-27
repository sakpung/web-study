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

Imports Leadtools
Imports Leadtools.ImageProcessing.core
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.Demos


Namespace MainDemo
   Partial Public Class HalftoneDialog : Inherits Form
      Private Shared _firstTimer As Boolean = True
      Private Shared _initialType As HalfToneCommandType
      Private Shared _initialAngle As Integer
      Private Shared _initialDimension As Integer

      Public Type As HalfToneCommandType
      Public Angle As Integer
      Public Dimension As Integer

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub HalftoneDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         If _firstTimer Then
            _firstTimer = False
            Dim command As HalfToneCommand = New HalfToneCommand()
            _initialType = command.Type
            _initialAngle = command.Angle
            _initialDimension = command.Dimension
         End If

         Type = _initialType
         Angle = CInt(_initialAngle / 100)
         Dimension = _initialDimension

         Tools.FillComboBoxWithEnum(_cbType, GetType(HalfToneCommandType), Type, New Object() {HalfToneCommandType.UserDefined})
         UpdateMyControls()
      End Sub

      Private Sub UpdateMyControls()
         Dim t As HalfToneCommandType = CType(Leadtools.Demos.Constants.GetValueFromName(GetType(HalfToneCommandType), CStr(_cbType.SelectedItem), _initialType), HalfToneCommandType)

         Dim noAngle As Boolean = (t = HalfToneCommandType.Rectangular) OrElse (t = HalfToneCommandType.Circular) OrElse (t = HalfToneCommandType.Random)
         _numAngle.Enabled = Not noAngle

         Dim noDimension As Boolean = (t = HalfToneCommandType.View) OrElse (t = HalfToneCommandType.Print)
         _numDimension.Enabled = Not noDimension
      End Sub

      Private Sub _cbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cbType.SelectedIndexChanged
         UpdateMyControls()
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numDimension.Leave, _numAngle.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Type = CType(Leadtools.Demos.Constants.GetValueFromName(GetType(HalfToneCommandType), CStr(_cbType.SelectedItem), _initialType), HalfToneCommandType)
         Angle = CInt(_numAngle.Value) * 100
         Dimension = CInt(_numDimension.Value)

         _initialType = Type
         _initialAngle = Angle
         _initialDimension = Dimension
      End Sub
   End Class
End Namespace
