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

Namespace MainDemo
   Partial Public Class MotionBlurDialog : Inherits Form
      Private Shared _firstTimer As Boolean = True
      Private Shared _initialDimension As Integer
      Private Shared _initialAngle As Integer
      Private Shared _initialUniDirectional As Boolean

      Public Dimension As Integer
      Public Angle As Integer
      Public UniDirectional As Boolean

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub MotionBlurDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         If _firstTimer Then
            _firstTimer = False
            Dim command As MotionBlurCommand = New MotionBlurCommand()
            _initialDimension = command.Dimension
            _initialAngle = command.Angle
            _initialUniDirectional = command.UniDirection
         End If

         Dimension = _initialDimension
         Angle = CInt(_initialAngle / 100)
         UniDirectional = _initialUniDirectional

         _numDimension.Value = Dimension
         DialogUtilities.SetNumericValue(_numAngle, Angle)
         _cbUniDirectional.Checked = UniDirectional
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numDimension.Leave, _numAngle.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Dimension = CInt(_numDimension.Value)
         Angle = CInt(_numAngle.Value) * 100
         UniDirectional = _cbUniDirectional.Checked
         If Dimension > 255 Then
            Dimension = 255
         End If
         _initialDimension = Dimension
         _initialAngle = Angle
         _initialUniDirectional = UniDirectional
      End Sub
   End Class
End Namespace
