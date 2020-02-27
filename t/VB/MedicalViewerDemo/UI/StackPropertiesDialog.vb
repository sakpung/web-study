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
   Partial Public Class StackPropertiesDialog : Inherits Form
      Private _stack As MedicalViewerStack
      Private _SelectedCell As MedicalViewerCell = Nothing
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

         If Not selectedCell Is Nothing Then
            _stack = CType(_SelectedCell.GetActionProperties(MedicalViewerActionType.Stack), MedicalViewerStack)
            _keys = _SelectedCell.GetActionKeys(MedicalViewerActionType.Stack)
         Else
            _stack = CType(MainForm.DefaultCell.GetActionProperties(MedicalViewerActionType.Stack, _txtCellIndex.Value), MedicalViewerStack)
            _keys = MainForm.DefaultCell.GetActionKeys(MedicalViewerActionType.Stack)
         End If

         _btnActionCursor.ButtonCursor = _stack.ActionCursor

         _txtSensitivity.Value = _stack.Sensitivity
         _chkCircular.Checked = _stack.CircularMouseMove
         _txtStack.Value = _stack.ScrollValue
         _txtActiveSubCell.Value = _stack.ActiveSubCell

         _cmbApplyToCells.SelectedIndex = 0

         owner.AddKeysToCombo(_cmbTopKey, _keys.MouseUp)
         owner.AddKeysToCombo(_cmbBottomKey, _keys.MouseDown)
         owner.AddModifiersToCombo(_cmbModifiers, _keys.Modifiers)

         _cmbApplyToCells.Enabled = (owner.Viewer.Cells.Count <> 0)
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         Me.Close()
         _btnApply_Click(sender, e)
      End Sub

      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         _keys.MouseUp = CType(_cmbTopKey.Items(_cmbTopKey.SelectedIndex), Keys)
         _keys.MouseDown = CType(_cmbBottomKey.Items(_cmbBottomKey.SelectedIndex), Keys)
         _keys.Modifiers = CType(_cmbModifiers.Items(_cmbModifiers.SelectedIndex), MedicalViewerModifiers)

         _stack.Sensitivity = _txtSensitivity.Value
         _stack.CircularMouseMove = _chkCircular.Checked
         _stack.ActionCursor = _btnActionCursor.ButtonCursor

         MainForm.DefaultCell.SetActionKeys(MedicalViewerActionType.Stack, _keys)
         MainForm.DefaultCell.SetActionProperties(MedicalViewerActionType.Stack, _stack)

         For Each cell As MedicalViewerMultiCell In _Viewer.Cells
            MainForm.CopyKeysFromGlobalCell(MainForm.DefaultCell, cell, MedicalViewerActionType.Stack)
            MainForm.CopyActionPropertiesFromGlobalCell(MainForm.DefaultCell, cell, MedicalViewerActionType.Stack)
         Next cell

         If _cmbApplyToCells.Text <> "None" Then
            _stack.ScrollValue = _txtStack.Value
            _stack.ActiveSubCell = _txtActiveSubCell.Value
            MainForm.ApplyToCells(_Viewer, _cmbApplyToCells, _txtCellIndex, Nothing, Nothing, MedicalViewerActionType.Stack, _stack)
         End If
      End Sub

      Private Sub _cmbApplyToCells_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbApplyToCells.SelectedIndexChanged
         _txtActiveSubCell.Enabled = (_cmbApplyToCells.Text <> "None")
         _txtStack.Enabled = (_cmbApplyToCells.Text <> "None")
         _txtCellIndex.Enabled = (_cmbApplyToCells.Text = "Custom")
      End Sub

   End Class
End Namespace
