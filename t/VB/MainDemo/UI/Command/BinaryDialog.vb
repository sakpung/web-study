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
   Partial Public Class BinaryDialog : Inherits Form
      Public Enum FilterConstants
         Dilation
         Erosion
      End Enum

      Private Shared _initialFilter As BinaryFilterCommandPredefined = BinaryFilterCommandPredefined.ErosionOmniDirectional

      Public Filter As BinaryFilterCommandPredefined

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub BinaryDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         Filter = _initialFilter

         Tools.FillComboBoxWithEnum(_cbFilter, GetType(BinaryFilterCommandPredefined), Filter)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Filter = CType(Leadtools.Demos.Constants.GetValueFromName(GetType(BinaryFilterCommandPredefined), CStr(_cbFilter.SelectedItem), _initialFilter), BinaryFilterCommandPredefined)

         _initialFilter = Filter
      End Sub
   End Class
End Namespace
