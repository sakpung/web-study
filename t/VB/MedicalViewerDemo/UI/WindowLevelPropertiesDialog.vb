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


Namespace MedicalViewerDemo
   Partial Public Class WindowLevelPropertiesDialog : Inherits Form
      Private _SelectedCell As MedicalViewerCell = Nothing
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
            _windowLevel = CType(IIf(TypeOf MainForm.DefaultCell.GetActionProperties(MedicalViewerActionType.WindowLevel, 0) Is MedicalViewerWindowLevel, MainForm.DefaultCell.GetActionProperties(MedicalViewerActionType.WindowLevel, 0), Nothing), MedicalViewerWindowLevel)
            _keys = MainForm.DefaultCell.GetActionKeys(MedicalViewerActionType.WindowLevel)


            _chkUseWindowLevelBoundaries.Checked = MainForm.DefaultCell.UseWindowLevelBoundaries
            _cmbBoxPaletteType.SelectedIndex = CInt(MainForm.DefaultCell.SubCells(0).PaletteType)

         Else
            _windowLevel = CType(IIf(TypeOf selectedCell.GetActionProperties(MedicalViewerActionType.WindowLevel, 0) Is MedicalViewerWindowLevel, selectedCell.GetActionProperties(MedicalViewerActionType.WindowLevel, 0), Nothing), MedicalViewerWindowLevel)
            _keys = selectedCell.GetActionKeys(MedicalViewerActionType.WindowLevel)


            _chkUseWindowLevelBoundaries.Checked = selectedCell.UseWindowLevelBoundaries

            _cmbBoxPaletteType.SelectedIndex = CInt(selectedCell.SubCells(0).PaletteType)

         End If

         _cmbFillType.Items.Add(MedicalViewerLookupTableType.Linear)
         _cmbFillType.Items.Add(MedicalViewerLookupTableType.Logarithmic)
         _cmbFillType.Items.Add(MedicalViewerLookupTableType.Exponential)
         _cmbFillType.Items.Add(MedicalViewerLookupTableType.Sigmoid)
         _btnCursor.ButtonCursor = _windowLevel.ActionCursor

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

         If _Viewer.Cells.Count = 0 Then
            Return
         End If

         Dim myCell As MedicalViewerMultiCell = CType(_Viewer.Cells(_txtCellIndex.Value), MedicalViewerMultiCell)

         _chkUseWindowLevelBoundaries.Checked = myCell.UseWindowLevelBoundaries


         _txtCellIndex.Enabled = enableControls AndAlso (_cmbApplyToCell.Text = "Custom")
         _cmbApplyToSubCell.Enabled = enableControls
         _txtSubcellIndex.Enabled = (enableControls AndAlso enableSubCellControls)
         _txtWidth.Enabled = enableControls
         _txtCenter.Enabled = enableControls
         _cmbFillType.Enabled = enableControls

         _cmbBoxPaletteType.Enabled = enableControls
         _chkUseWindowLevelBoundaries.Enabled = enableControls

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

         MainForm.DefaultCell.SetActionKeys(MedicalViewerActionType.WindowLevel, _keys)
         MainForm.DefaultCell.SetActionProperties(MedicalViewerActionType.WindowLevel, _windowLevel)


         MainForm.DefaultCell.UseWindowLevelBoundaries = _chkUseWindowLevelBoundaries.Checked


         For Each cell As MedicalViewerMultiCell In _Viewer.Cells
            MainForm.CopyKeysFromGlobalCell(MainForm.DefaultCell, cell, MedicalViewerActionType.WindowLevel)
            MainForm.CopyActionPropertiesFromGlobalCell(MainForm.DefaultCell, cell, MedicalViewerActionType.WindowLevel)
         Next cell

         If _cmbApplyToCell.Text <> "None" Then
            _windowLevel.Width = _txtWidth.Value
            _windowLevel.Center = _txtCenter.Value
            _windowLevel.LookupTableType = CType(_cmbFillType.Items(_cmbFillType.SelectedIndex), MedicalViewerLookupTableType)

            MainForm.ApplyToCells(_Viewer, _cmbApplyToCell, _txtCellIndex, _cmbApplyToSubCell, _txtSubcellIndex, MedicalViewerActionType.WindowLevel, _windowLevel, AddressOf ApplyMoreFeatures)

         End If


      End Sub

      Public Sub ApplyMoreFeatures(ByVal cell As MedicalViewerMultiCell, ByVal subCellIndex As Integer)

         cell.UseWindowLevelBoundaries = _chkUseWindowLevelBoundaries.Checked


         Dim from As Integer = 0
         Dim [to] As Integer = 1

         Select Case subCellIndex
            Case -2
               from = cell.ActiveSubCell
               [to] = from + 1
            Case -1
               from = 0
               [to] = cell.SubCells.Count
            Case Else
               from = subCellIndex
               [to] = subCellIndex + 1
         End Select


         Dim counter As Integer
         counter = from
         Do While counter < [to]
            cell.SubCells(counter).PaletteType = CType(_cmbBoxPaletteType.SelectedIndex, MedicalViewerPaletteType)
            counter += 1
         Loop

      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         Me.Close()
         _btnApply_Click(sender, e)
      End Sub
   End Class
End Namespace
