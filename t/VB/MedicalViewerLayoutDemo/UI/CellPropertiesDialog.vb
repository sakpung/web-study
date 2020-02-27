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
Imports Leadtools.MedicalViewer

Namespace MedicalViewerLayoutDemo
   Public Partial Class CellPropertiesDialog : Inherits Form
	  Private _cell As MedicalViewerMultiCell
	  Public Sub New(ByVal mainForm As MainForm, ByVal multiCell As MedicalViewerMultiCell)
		 InitializeComponent()

		 _cell = multiCell

		 If Not multiCell Is Nothing Then
			_rdoApplyToSelected.Checked = True
		 Else
			_cell = CType(mainForm.Viewer.Cells(0), MedicalViewerMultiCell)
			_rdoApplyToAll.Checked = True
			_rdoApplyToSelected.Enabled = False
		 End If

		 _chkShowTags.Checked = _cell.ShowTags
		 _cmbDisplayRuler.SelectedIndex = CInt(_cell.DisplayRulers)
		 _chkApplyOnMove.Checked = _cell.ApplyActionOnMove
		 _chkApplyWLToAll.Checked = Not _cell.ApplyOnIndividualSubCell
		 _chkFitImage.Checked = _cell.FitImageToCell
		 _txtRows.Text = _cell.Rows.ToString()
		 _txtColumns.Text = _cell.Columns.ToString()
	  End Sub

	  Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
		 Me.Close()
		 _btnApply_Click(sender, e)
	  End Sub

	  Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
		 For Each cell As MedicalViewerMultiCell In (CType(Me.Owner, MainForm)).Viewer.Cells
			If cell.Selected OrElse _rdoApplyToAll.Checked Then
			   If cell.ShowTags <> _chkShowTags.Checked Then
				  cell.ShowTags = _chkShowTags.Checked
			   End If

			   If cell.DisplayRulers <> CType(_cmbDisplayRuler.SelectedIndex, MedicalViewerRulers) Then
				  cell.DisplayRulers = CType(_cmbDisplayRuler.SelectedIndex, MedicalViewerRulers)
			   End If

			   If cell.ApplyActionOnMove <> _chkApplyOnMove.Checked Then
				  cell.ApplyActionOnMove = _chkApplyOnMove.Checked
			   End If

			   If cell.ApplyOnIndividualSubCell <> ((Not _chkApplyWLToAll.Checked)) Then
				  cell.ApplyOnIndividualSubCell = Not _chkApplyWLToAll.Checked
			   End If

			   If cell.FitImageToCell <> _chkFitImage.Checked Then
				  cell.FitImageToCell = _chkFitImage.Checked
			   End If

			   If cell.Rows <> _txtRows.Value Then
				  cell.Rows = _txtRows.Value
			   End If

			   If cell.Columns <> _txtColumns.Value Then
				  cell.Columns = _txtColumns.Value
			   End If
			End If
		 Next cell
	  End Sub

   End Class
End Namespace
