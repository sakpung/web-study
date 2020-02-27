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

Imports Leadtools.MedicalViewer

Namespace MedicalViewerDemo
   Partial Public Class AlphaPropertiesDialog : Inherits Form
      Private _alpha As MedicalViewerAlpha
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
         _txtCellIndex.Value = _Viewer.Cells.IndexOf(_SelectedCell)
         _txtSubCellIndex.Value = 0

         If Not _SelectedCell Is Nothing Then
            _alpha = CType(_SelectedCell.GetActionProperties(MedicalViewerActionType.Alpha), MedicalViewerAlpha)
            _keys = _SelectedCell.GetActionKeys(MedicalViewerActionType.Alpha)
         Else
            _alpha = CType(MainForm.DefaultCell.GetActionProperties(MedicalViewerActionType.Alpha), MedicalViewerAlpha)
            _keys = MainForm.DefaultCell.GetActionKeys(MedicalViewerActionType.Alpha)
         End If

         _btnCursor.ButtonCursor = _alpha.ActionCursor

         _txtFactor.Value = _alpha.Alpha

         _txtSensitivity.Value = _alpha.Sensitivity
         _chkCircular.Checked = _alpha.CircularMouseMove

         _cmbApplyToCell.SelectedIndex = 0
         _cmbApplyToSubCell.SelectedIndex = 0

         owner.AddKeysToCombo(_cmbLeftKey, _keys.MouseLeft)
         owner.AddKeysToCombo(_cmbRightKey, _keys.MouseRight)
         owner.AddModifiersToCombo(_cmbModifiers, _keys.Modifiers)

         _cmbApplyToCell.Enabled = (owner.Viewer.Cells.Count <> 0)
      End Sub

      Private Sub _cmbApplyToSubCell_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbApplyToSubCell.SelectedIndexChanged
         _txtSubCellIndex.Enabled = ((_cmbApplyToSubCell.Text = "Custom") AndAlso (_cmbApplyToCell.SelectedIndex <> 0))
      End Sub

      Private Sub _cmbApplyToCell_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbApplyToCell.SelectedIndexChanged
         Dim enableControls As Boolean = (_cmbApplyToCell.SelectedIndex <> 0)
         Dim enableSubCellControls As Boolean = (_cmbApplyToSubCell.Text = "Custom")

         _txtCellIndex.Enabled = enableControls AndAlso (_cmbApplyToCell.Text = "Custom")
         _cmbApplyToSubCell.Enabled = enableControls
         _txtSubCellIndex.Enabled = (enableControls AndAlso enableSubCellControls)
         _txtFactor.Enabled = enableControls
      End Sub

      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         _keys.MouseLeft = CType(_cmbLeftKey.Items(_cmbLeftKey.SelectedIndex), Keys)
         _keys.MouseRight = CType(_cmbRightKey.Items(_cmbRightKey.SelectedIndex), Keys)
         _keys.Modifiers = CType(_cmbModifiers.Items(_cmbModifiers.SelectedIndex), MedicalViewerModifiers)

         _alpha.Sensitivity = _txtSensitivity.Value
         _alpha.CircularMouseMove = _chkCircular.Checked
         _alpha.ActionCursor = _btnCursor.ButtonCursor

         MainForm.DefaultCell.SetActionKeys(MedicalViewerActionType.Alpha, _keys)
         MainForm.DefaultCell.SetActionProperties(MedicalViewerActionType.Alpha, _alpha)

         For Each cell As MedicalViewerMultiCell In _Viewer.Cells
            MainForm.CopyKeysFromGlobalCell(MainForm.DefaultCell, cell, MedicalViewerActionType.Alpha)
            MainForm.CopyActionPropertiesFromGlobalCell(MainForm.DefaultCell, cell, MedicalViewerActionType.Alpha)
         Next cell

         If _cmbApplyToCell.Text <> "None" Then
            _alpha.Alpha = _txtFactor.Value
            MainForm.ApplyToCells(_Viewer, _cmbApplyToCell, _txtCellIndex, _cmbApplyToSubCell, _txtSubCellIndex, MedicalViewerActionType.Alpha, _alpha)
         End If
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         Me.Close()
         _btnApply_Click(sender, e)
      End Sub
   End Class
End Namespace
