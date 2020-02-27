' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools
Imports Leadtools.Codecs

Imports Leadtools.WinForms.CommonDialogs.File
Imports Leadtools.MedicalViewer

Namespace MedicalViewerDemo
   Partial Public Class InsertCellDialog : Inherits Form
      Private _codecs As RasterCodecs
      Public Sub New(ByVal owner As MainForm)
         _codecs = New RasterCodecs()
         InitializeComponent()

         Me.CancelButton = _btnCancel
         Me.AcceptButton = _btnOK

         ' set the allowed range for the cell index text box.
         _txtCellIndex.MinimumAllowed = -1
         _txtCellIndex.MaximumAllowed = owner.Viewer.Cells.Count
         _txtCellIndex.Text = (0).ToString()
      End Sub

      Private Sub insertNewCellRadio_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkInsert.CheckedChanged
         ' Enable or disable the controls based on this radio button state.
         _lblCellIndex.Enabled = _chkInsert.Checked
         _txtCellIndex.Enabled = _chkInsert.Checked
         If _txtCellIndex.Enabled Then
            _txtCellIndex.Focus()
         End If
      End Sub

      Private Sub okButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         DialogResult = System.Windows.Forms.DialogResult.OK
         If _chkInsert.Checked Then
            CType(Me.Owner, MainForm).CellIndex = _txtCellIndex.Value
         Else
            CType(Me.Owner, MainForm).CellIndex = -1
         End If
      End Sub

   End Class
End Namespace
