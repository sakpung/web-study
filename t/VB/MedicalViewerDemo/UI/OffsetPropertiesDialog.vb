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
   Partial Public Class OffsetPropertiesDialog : Inherits Form
      Private _offset As MedicalViewerOffset
      Private _keys As MedicalViewerKeys = Nothing
      Private _Viewer As MedicalViewer = Nothing
      Private _SelectedCell As MedicalViewerCell = Nothing

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
            _offset = CType(_SelectedCell.GetActionProperties(MedicalViewerActionType.Offset, _txtCellIndex.Value), MedicalViewerOffset)
            _keys = _SelectedCell.GetActionKeys(MedicalViewerActionType.Offset)
         Else
            _offset = CType(MainForm.DefaultCell.GetActionProperties(MedicalViewerActionType.Offset, _txtCellIndex.Value), MedicalViewerOffset)
            _keys = MainForm.DefaultCell.GetActionKeys(MedicalViewerActionType.Offset)
         End If

         _btnActionCursor.ButtonCursor = _offset.ActionCursor

         _cmbApplyToCell.SelectedIndex = 0
         _txtX.Value = _offset.X
         _txtY.Value = _offset.Y

         _txtSensitivity.Value = _offset.Sensitivity
         _chkCircular.Checked = _offset.CircularMouseMove

         owner.AddKeysToCombo(_cmbLeftKey, _keys.MouseLeft)
         owner.AddKeysToCombo(_cmbRightKey, _keys.MouseRight)
         owner.AddKeysToCombo(_cmbBottomKey, _keys.MouseDown)
         owner.AddKeysToCombo(_cmbTopKey, _keys.MouseUp)
         owner.AddModifiersToCombo(_cmbModifiers, _keys.Modifiers)

         _cmbApplyToCell.Enabled = (owner.Viewer.Cells.Count <> 0)
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         Me.Close()
         _btnApply_Click(sender, e)
      End Sub

      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         _keys.MouseDown = CType(_cmbBottomKey.Items(_cmbBottomKey.SelectedIndex), Keys)
         _keys.MouseLeft = CType(_cmbLeftKey.Items(_cmbLeftKey.SelectedIndex), Keys)
         _keys.MouseRight = CType(_cmbRightKey.Items(_cmbRightKey.SelectedIndex), Keys)
         _keys.MouseUp = CType(_cmbTopKey.Items(_cmbTopKey.SelectedIndex), Keys)
         _keys.Modifiers = CType(_cmbModifiers.Items(_cmbModifiers.SelectedIndex), MedicalViewerModifiers)

         _offset.Sensitivity = _txtSensitivity.Value
         _offset.CircularMouseMove = _chkCircular.Checked
         _offset.ActionCursor = _btnActionCursor.ButtonCursor

         MainForm.DefaultCell.SetActionKeys(MedicalViewerActionType.Offset, _keys)
         MainForm.DefaultCell.SetActionProperties(MedicalViewerActionType.Offset, _offset)

         For Each cell As MedicalViewerMultiCell In _Viewer.Cells
            MainForm.CopyKeysFromGlobalCell(MainForm.DefaultCell, cell, MedicalViewerActionType.Offset)
            MainForm.CopyActionPropertiesFromGlobalCell(MainForm.DefaultCell, cell, MedicalViewerActionType.Offset)
         Next cell

         If _cmbApplyToCell.Text <> "None" Then
            _offset.X = _txtY.Value
            _offset.Y = _txtX.Value
            MainForm.ApplyToCells(_Viewer, _cmbApplyToCell, _txtCellIndex, Nothing, Nothing, MedicalViewerActionType.Offset, _offset)
         End If

      End Sub

      Private Sub _cmbApplyToCell_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbApplyToCell.SelectedIndexChanged
         _txtY.Enabled = (_cmbApplyToCell.Text <> "None")
         _txtX.Enabled = (_cmbApplyToCell.Text <> "None")
         _txtCellIndex.Enabled = (_cmbApplyToCell.Text = "Custom")
      End Sub
   End Class
End Namespace
