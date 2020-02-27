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
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.Demos

Namespace MainDemo
   Partial Public Class AddNoiseDialog : Inherits Form
      Private Shared _firstTimer As Boolean = True
      Private Shared _initialRange As Integer
      Private Shared _initialChannel As RasterColorChannel

      Public Range As Integer
      Public Channel As RasterColorChannel

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub AddNoiseDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         If _firstTimer Then
            _firstTimer = False
            Dim command As AddNoiseCommand = New AddNoiseCommand()
            _initialRange = command.Range
            _initialChannel = command.Channel
         End If

         Range = CInt(_initialRange / 10)
         Channel = _initialChannel

         _numRange.Value = Range
         Tools.FillComboBoxWithEnum(_cbChannel, GetType(RasterColorChannel), Channel)
      End Sub

      Private Sub _numRange_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numRange.Leave
         DialogUtilities.NumericOnLeave(_numRange)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Range = CInt(_numRange.Value) * 10

         Channel = CType(Leadtools.Demos.Constants.GetValueFromName(GetType(RasterColorChannel), CStr(_cbChannel.SelectedItem), _initialChannel), RasterColorChannel)

         _initialRange = Range
         _initialChannel = Channel
      End Sub
   End Class
End Namespace
