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
Imports Leadtools.MedicalViewer


Namespace MedicalViewerLayoutDemo
   Public Partial Class WindowLevelPropertiesDialog : Inherits Form
	   Private _SelectedCell As MedicalViewerCell= Nothing
	   Private _windowLevel As MedicalViewerWindowLevel = Nothing
	   Private _keys As MedicalViewerKeys = Nothing
	   Private _Viewer As MedicalViewer = Nothing

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

		 If selectedCell Is Nothing Then
			 _windowLevel = TryCast(MainForm.GlobalCell.GetActionProperties(MedicalViewerActionType.WindowLevel, 0), MedicalViewerWindowLevel)
			 _keys = MainForm.GlobalCell.GetActionKeys(MedicalViewerActionType.WindowLevel)
		 Else
			 _windowLevel = TryCast(selectedCell.GetActionProperties(MedicalViewerActionType.WindowLevel, 0), MedicalViewerWindowLevel)
			 _keys = selectedCell.GetActionKeys(MedicalViewerActionType.WindowLevel)
		 End If

		 _cmbFillType.Items.Add(MedicalViewerLookupTableType.Linear)
		 _cmbFillType.Items.Add(MedicalViewerLookupTableType.Logarithmic)
		 _cmbFillType.Items.Add(MedicalViewerLookupTableType.Exponential)
		 _cmbFillType.Items.Add(MedicalViewerLookupTableType.Sigmoid)
		 _btnCursor.ButtonCursor = _windowLevel.ActionCursor

		 _lblStart.BoxColor = _windowLevel.StartColor
		 _lblEnd.BoxColor = _windowLevel.EndColor
		 If (_windowLevel.Width = 0) Then
			 _txtWidth.Value = 1
		 Else
			 _txtWidth.Value = _windowLevel.Width
		 End If
		 _txtCenter.Value = _windowLevel.Center
		 Dim index As Integer = _cmbFillType.Items.IndexOf(_windowLevel.LookupTableType)
		 If index = -1 Then
			 _cmbFillType.SelectedIndex = 0
		 Else
			 _cmbFillType.SelectedIndex = index
		 End If
		 _txtSensitivity.Text = _windowLevel.Sensitivity.ToString()
		 _chkCircular.Checked = _windowLevel.CircularMouseMove
		 _cmbApplyToCell.SelectedIndex = 0
		 _cmbApplyToSubCell.SelectedIndex = 0

		 owner.AddKeysToCombo(_cmbLeftKey, _keys.MouseLeft)
		 owner.AddKeysToCombo(_cmbRightKey, _keys.MouseRight)
		 owner.AddKeysToCombo(_cmbBottomKey, _keys.MouseDown)
		 owner.AddKeysToCombo(_cmbTopKey, _keys.MouseUp)
		 owner.AddModifiersToCombo(_cmbModifiers, _keys.Modifiers)

		 _cmbApplyToCell.Enabled = (owner.Viewer.Cells.Count <> 0)
	  End Sub

	  Private Sub _cmbApplyToCell_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbApplyToCell.SelectedIndexChanged
		 Dim enableControls As Boolean = (_cmbApplyToCell.SelectedIndex <> 0)
		 Dim enableSubCellControls As Boolean = (_cmbApplyToSubCell.Text = "Custom")

		 _txtCellIndex.Enabled = enableControls AndAlso (_cmbApplyToCell.Text = "Custom")
		 _cmbApplyToSubCell.Enabled = enableControls
		 _txtSubcellIndex.Enabled = (enableControls AndAlso enableSubCellControls)
		 _txtWidth.Enabled = enableControls
		 _txtCenter.Enabled = enableControls
		 _cmbFillType.Enabled = enableControls
		 _lblStart.Enabled = enableControls
		 _lblEnd.Enabled = enableControls
		 _btnStart.Enabled = enableControls
		 _btnEnd.Enabled = enableControls
	  End Sub

	  Private Sub _cmbApplyToSubCell_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbApplyToSubCell.SelectedIndexChanged
		 _txtSubcellIndex.Enabled = ((_cmbApplyToSubCell.Text = "Custom") AndAlso (_cmbApplyToCell.SelectedIndex <> 0))
	  End Sub



	  Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
		  _keys.MouseDown = CType(_cmbBottomKey.Items(_cmbBottomKey.SelectedIndex), Keys)
		  _keys.MouseLeft = CType(_cmbLeftKey.Items(_cmbLeftKey.SelectedIndex), Keys)
		  _keys.MouseRight = CType(_cmbRightKey.Items(_cmbRightKey.SelectedIndex), Keys)
		  _keys.MouseUp = CType(_cmbTopKey.Items(_cmbTopKey.SelectedIndex), Keys)
		  _keys.Modifiers = CType(_cmbModifiers.Items(_cmbModifiers.SelectedIndex), MedicalViewerModifiers)

		  _windowLevel.Sensitivity = _txtSensitivity.Value
		  _windowLevel.CircularMouseMove = _chkCircular.Checked
		  _windowLevel.ActionCursor = _btnCursor.ButtonCursor

		  MainForm.GlobalCell.SetActionKeys(MedicalViewerActionType.WindowLevel, _keys)
		  MainForm.GlobalCell.SetActionProperties(MedicalViewerActionType.WindowLevel, _windowLevel)

		  For Each cell As MedicalViewerMultiCell In _Viewer.Cells
			 MainForm.CopyKeysFromGlobalCell(MainForm.GlobalCell, cell, MedicalViewerActionType.WindowLevel)
			 MainForm.CopyActionPropertiesFromGlobalCell(MainForm.GlobalCell, cell, MedicalViewerActionType.WindowLevel)
		  Next cell

		 If _cmbApplyToCell.Text <> "None" Then
			_windowLevel.Width = _txtWidth.Value
			_windowLevel.Center = _txtCenter.Value
			_windowLevel.LookupTableType = CType(_cmbFillType.Items(_cmbFillType.SelectedIndex), MedicalViewerLookupTableType)
			_windowLevel.StartColor = _lblStart.BoxColor
			_windowLevel.EndColor = _lblEnd.BoxColor

			MainForm.ApplyToCells(_Viewer, _cmbApplyToCell, _txtCellIndex, _cmbApplyToSubCell, _txtSubcellIndex, MedicalViewerActionType.WindowLevel, _windowLevel)
		 End If
	  End Sub

	  Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
		 Me.Close()
		 _btnApply_Click(sender, e)
	  End Sub

	  Private Sub _btnStart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnStart.Click
		 MainForm.ShowColorDialog(_lblStart)
	  End Sub

	  Private Sub _btnEnd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnEnd.Click
		 MainForm.ShowColorDialog(_lblEnd)
	  End Sub
   End Class
End Namespace
