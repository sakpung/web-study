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

Namespace DicomDemo
   Partial Public Class UnsharpMaskDialog : Inherits Form
      Private Shared _firstTimer As Boolean = True
      Private Shared _initialAmount As Integer
      Private Shared _initialRadius As Integer
      Private Shared _initialThreshold As Integer
      Private Shared _initialColorSpace As UnsharpMaskCommandColorType

      Public Amount As Integer
      Public Radius As Integer
      Public Threshold As Integer
      Public ColorSpace As UnsharpMaskCommandColorType

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub UnsharpMaskDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         If _firstTimer Then
            _firstTimer = False
            Dim command As UnsharpMaskCommand = New UnsharpMaskCommand()
            _initialAmount = command.Amount
            _initialRadius = command.Radius
            _initialThreshold = command.Threshold
            _initialColorSpace = command.ColorType
         End If

         Amount = _initialAmount
         Radius = _initialRadius
         Threshold = _initialThreshold
         ColorSpace = _initialColorSpace

         _numAmount.Value = Amount
         _numRadius.Value = Radius
         _numThreshold.Value = Threshold

         _cbColorSpace.Items.AddRange(System.Enum.GetNames(GetType(UnsharpMaskCommandColorType)))
         _cbColorSpace.Items.RemoveAt(0)
         _cbColorSpace.SelectedIndex = 0
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numThreshold.Leave, _numRadius.Leave, _numAmount.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Amount = CInt(_numAmount.Value)
         Radius = CInt(_numRadius.Value)
         Threshold = CInt(_numThreshold.Value)

         'ColorSpace = CType(Constants.GetValueFromName(GetType(UnsharpMaskCommandColorType), CStr(_cbColorSpace.SelectedItem), _initialColorSpace), UnsharpMaskCommandColorType)
         ColorSpace = CType(System.Enum.Parse(GetType(UnsharpMaskCommandColorType), CStr(_cbColorSpace.SelectedItem)), UnsharpMaskCommandColorType)

         _initialAmount = Amount
         _initialRadius = Radius
         _initialThreshold = Threshold
         _initialColorSpace = ColorSpace
      End Sub
   End Class
End Namespace
