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

Partial Public Class WiaPropertiesErrorsForm : Inherits Form
   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub WiaPropertiesErrorsForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
      _lvErrors.Columns.Add("Device Name", 150, HorizontalAlignment.Left)
      _lvErrors.Columns.Add("Item Name", 100, HorizontalAlignment.Left)
      _lvErrors.Columns.Add("Property Name", 120, HorizontalAlignment.Left)
      _lvErrors.Columns.Add("Property Value", 100, HorizontalAlignment.Left)
      _lvErrors.Columns.Add("Error", 70, HorizontalAlignment.Left)

      For Each i As MyPropertiesErrors In MainForm._errorList
         Dim item As ListViewItem

         item = _lvErrors.Items.Add(i.DeviceName)

         item.SubItems.Add(i.ItemName)
         item.SubItems.Add(i.PropertyName)
         item.SubItems.Add(i.PropertyValue)
         item.SubItems.Add(i.ErrorCodeString)
      Next i
   End Sub

   Private Sub _btnClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnClear.Click
      MainForm._errorList.Clear()
      _lvErrors.Items.Clear()
   End Sub
End Class
