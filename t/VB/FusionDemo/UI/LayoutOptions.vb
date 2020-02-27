' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Imports Leadtools.MedicalViewer

Namespace FusionDemo
   Partial Public Class LayoutOptions : Inherits Form
      Private _viewer As MedicalViewer
      Private _form As MainForm

      Public Sub New()
         InitializeComponent()
      End Sub

      Public Sub New(ByVal viewer As MedicalViewer, ByVal form As MainForm)
         _viewer = viewer
         _form = form

         InitializeComponent()

         _txtRows.Value = _viewer.Rows
         _txtColumns.Value = _viewer.Columns
         _interpolateAlwaysImage.Checked = _form.AlwaysInterpolate
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         If _viewer.Rows <> _txtRows.Value Then
            _viewer.Rows = _txtRows.Value
         End If

         If _viewer.Columns <> _txtColumns.Value Then
            _viewer.Columns = _txtColumns.Value
         End If

         _form.AlwaysInterpolate = _interpolateAlwaysImage.Checked

         Dim counter As Integer
         Dim cell As MedicalViewerCell
         counter = 0
         Do While counter < _viewer.Cells.Count
            If TypeOf _viewer.Cells(counter) Is MedicalViewerCell Then
               cell = (CType(_viewer.Cells(counter), MedicalViewerCell))
               cell.AlwaysInterpolate = _interpolateAlwaysImage.Checked
            End If
            counter += 1
         Loop
      End Sub

      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         _btnOK_Click(sender, e)
      End Sub
   End Class
End Namespace
