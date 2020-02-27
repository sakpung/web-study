' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.MedicalViewer

Namespace MedicalViewerLayoutDemo
   Public Partial Class CalibrateRulerDialog : Inherits Form
	  Public Sub New(ByVal owner As MainForm)
		 InitializeComponent()
		 _cmbUnit.SelectedIndex = CInt(owner.Viewer.MeasurementUnit)
		 _txtDistance.MinimumAllowed = 1
		 _txtDistance.MaximumAllowed = 100
		 _txtDistance.Text = (1).ToString()
		 _chkApplyToAll.Checked = owner.ApplyToAll
	  End Sub

	  Private Sub applyButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
		 Dim subCellIndex As Integer
		 If (_chkApplyToAll.Checked) Then
			 subCellIndex = -1
		 Else
			 subCellIndex = -2
		 End If
		 CType(Me.Owner, MainForm).ApplyToAll = _chkApplyToAll.Checked
		 For Each cell As MedicalViewerCell In (CType(Me.Owner, MainForm)).Viewer.Cells
			If cell.Selected Then
			   cell.CalibrateRuler(_txtDistance.Value, CType(_cmbUnit.SelectedIndex, MedicalViewerMeasurementUnit), subCellIndex)
			End If
		 Next cell
	  End Sub

	  Private Sub okButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
		 applyButton_Click(sender, e)
		 Me.Close()
	  End Sub
   End Class
End Namespace
