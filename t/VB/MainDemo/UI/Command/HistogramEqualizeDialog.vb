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
Imports Leadtools.Demos

Namespace MainDemo
   Partial Public Class HistogramEqualizeDialog : Inherits Form
      Private Shared _firstTimer As Boolean = True
      Private Shared _initialColorSpace As HistogramEqualizeType

      Public ColorSpace As HistogramEqualizeType

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub HistogramEqualizeDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         If _firstTimer Then
            _firstTimer = False
            Dim command As HistogramEqualizeCommand = New HistogramEqualizeCommand()
            _initialColorSpace = command.Type
         End If

         ColorSpace = _initialColorSpace

         Tools.FillComboBoxWithEnum(_cbColorSpace, GetType(HistogramEqualizeType), ColorSpace, New Object() {HistogramEqualizeType.None})
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         ColorSpace = CType(Leadtools.Demos.Constants.GetValueFromName(GetType(HistogramEqualizeType), CStr(_cbColorSpace.SelectedItem), _initialColorSpace), HistogramEqualizeType)

         _initialColorSpace = ColorSpace
      End Sub
   End Class
End Namespace
