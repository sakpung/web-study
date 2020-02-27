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
   Partial Public Class SpatialDialog : Inherits Form
      Private Shared _initialFilter As SpatialFilterCommandPredefined = SpatialFilterCommandPredefined.SobelVertical

      Public Filter As SpatialFilterCommandPredefined

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub SpatialDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         Filter = _initialFilter

         Tools.FillComboBoxWithEnum(_cbFilter, GetType(SpatialFilterCommandPredefined), Filter)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Filter = CType(Leadtools.Demos.Constants.GetValueFromName(GetType(SpatialFilterCommandPredefined), CStr(_cbFilter.SelectedItem), _initialFilter), SpatialFilterCommandPredefined)

         _initialFilter = Filter
      End Sub
   End Class
End Namespace
