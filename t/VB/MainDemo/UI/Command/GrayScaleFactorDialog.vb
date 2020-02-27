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

Imports Leadtools.ImageProcessing.Color

Namespace MainDemo
   Partial Public Class GrayScaleFactorDialog : Inherits Form
      Private Shared _firstTimer As Boolean = True
      Private Shared _initialRedFactor As Integer
      Private Shared _initialGreenFactor As Integer
      Private Shared _initialBlueFactor As Integer

      Public RedFactor As Integer
      Public GreenFactor As Integer
      Public BlueFactor As Integer


      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub GrayScaleFactorDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs)
         If _firstTimer Then
            _firstTimer = False
            Dim command As GrayScaleExtendedCommand = New GrayScaleExtendedCommand()
            _initialRedFactor = command.RedFactor
            _initialGreenFactor = command.GreenFactor
            _initialBlueFactor = command.BlueFactor
         End If

         RedFactor = _initialRedFactor
         GreenFactor = _initialGreenFactor
         BlueFactor = _initialBlueFactor

         DialogUtilities.SetNumericValue(_numRed, RedFactor)
         DialogUtilities.SetNumericValue(_numGreen, GreenFactor)
         DialogUtilities.SetNumericValue(_numBlue, BlueFactor)
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numBlue.Leave, _numGreen.Leave, _numRed.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         If (_numRed.Value + _numGreen.Value + _numBlue.Value) > 1000 Then
            Messager.ShowWarning(Me, _lblMsg.Text)
            DialogResult = System.Windows.Forms.DialogResult.None
            Return
         End If

         RedFactor = CInt(_numRed.Value)
         GreenFactor = CInt(_numGreen.Value)
         BlueFactor = CInt(_numBlue.Value)

         _initialRedFactor = RedFactor
         _initialGreenFactor = GreenFactor
         _initialBlueFactor = BlueFactor
      End Sub
   End Class
End Namespace
