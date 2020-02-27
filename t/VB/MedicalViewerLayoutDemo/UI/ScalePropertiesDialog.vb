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
   Public Partial Class ScalePropertiesDialog : Inherits Form
	  Private _scale As MedicalViewerScale
	  Private _SelectedCell As MedicalViewerCell = Nothing
	  Private _Viewer As MedicalViewer = Nothing
	  Private _keys As MedicalViewerKeys = Nothing

	  Public Sub New(ByVal owner As MainForm, ByVal selectedCell As MedicalViewerCell)
		 InitializeComponent()
		 _Viewer = owner.Viewer
		 If selectedCell Is Nothing Then
			If _Viewer.Cells.Count <> 0 Then
			   selectedCell = CType(_Viewer.Cells(0), MedicalViewerCell)
			End If
		 End If
		 _SelectedCell = selectedCell

		 If Not selectedCell Is Nothing Then
			 _txtCellIndex.Value = _Viewer.Cells.IndexOf(selectedCell)
		 End If

		 If Not _SelectedCell Is Nothing Then
			 _scale = CType(_SelectedCell.GetActionProperties(MedicalViewerActionType.Scale), MedicalViewerScale)
			 _keys = _SelectedCell.GetActionKeys(MedicalViewerActionType.Scale)
		 Else
			 _scale = CType(MainForm.GlobalCell.GetActionProperties(MedicalViewerActionType.Scale), MedicalViewerScale)
			 _keys = MainForm.GlobalCell.GetActionKeys(MedicalViewerActionType.Scale)
		 End If

		 _btnCursor.ButtonCursor = _scale.ActionCursor
		 _cmbApplyToCells.SelectedIndex = 0
		 _txtSensitivity.Value = _scale.Sensitivity
		 _chkCircular.Checked = _scale.CircularMouseMove
		 _txtScale.Value = _scale.Scale
		 owner.AddKeysToCombo(_cmbTopKey, _keys.MouseUp)
		 owner.AddKeysToCombo(_cmbBottomKey, _keys.MouseDown)
		 owner.AddModifiersToCombo(_cmbModifiers, _keys.Modifiers)

		 _cmbApplyToCells.Enabled = (owner.Viewer.Cells.Count <> 0)
	  End Sub

	  Private Sub _cmbApplyToCells_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbApplyToCells.SelectedIndexChanged
		 _txtScale.Enabled = (_cmbApplyToCells.Text <> "None")
		 _txtCellIndex.Enabled = (_cmbApplyToCells.Text = "Custom")
	  End Sub

	  Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
		  _keys.MouseUp = CType(_cmbTopKey.Items(_cmbTopKey.SelectedIndex), Keys)
		  _keys.MouseDown = CType(_cmbBottomKey.Items(_cmbBottomKey.SelectedIndex), Keys)
		  _keys.Modifiers = CType(_cmbModifiers.Items(_cmbModifiers.SelectedIndex), MedicalViewerModifiers)

		  _scale.Sensitivity = _txtSensitivity.Value
		  _scale.CircularMouseMove = _chkCircular.Checked
		  _scale.ActionCursor = _btnCursor.ButtonCursor

		  MainForm.GlobalCell.SetActionKeys(MedicalViewerActionType.Scale, _keys)
		  MainForm.GlobalCell.SetActionProperties(MedicalViewerActionType.Scale, _scale)

		  For Each cell As MedicalViewerMultiCell In _Viewer.Cells
			 MainForm.CopyKeysFromGlobalCell(MainForm.GlobalCell, cell, MedicalViewerActionType.Scale)
			 MainForm.CopyActionPropertiesFromGlobalCell(MainForm.GlobalCell, cell, MedicalViewerActionType.Scale)
		  Next cell

		  If _cmbApplyToCells.Text <> "None" Then
			  _scale.Scale = _txtScale.Value
			  MainForm.ApplyToCells(_Viewer, _cmbApplyToCells, _txtCellIndex, Nothing, Nothing, MedicalViewerActionType.Scale, _scale)
		  End If
	  End Sub

	  Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
		 Me.Close()
		 _btnApply_Click(sender, e)
	  End Sub
   End Class
End Namespace
