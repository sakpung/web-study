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
   Partial Public Class CellPropertiesDialog : Inherits Form
      Public Sub New(ByVal mainForm As MainForm, ByVal i As Integer)
         InitializeComponent()

         If i <> mainForm.Viewer.Cells.Count Then
            _rdoApplyToSelected.Checked = True
         Else
            i = 0
            _rdoApplyToAll.Checked = True
         End If

         Dim cell As MedicalViewerMultiCell = CType(mainForm.Viewer.Cells(i), MedicalViewerMultiCell)
         _chkShowTags.Checked = cell.ShowTags
         _cmbDisplayRuler.SelectedIndex = CInt(cell.DisplayRulers)
         _chkApplyOnMove.Checked = cell.ApplyActionOnMove
         _chkApplyWLToAll.Checked = Not cell.ApplyOnIndividualSubCell
         _chkFitImage.Checked = cell.FitImageToCell
         _txtRows.Text = cell.Rows.ToString()
         _txtColumns.Text = cell.Columns.ToString()

         _chkSnapRulers.Checked = cell.SnapRulers
         _chkDisableControlPoints.Checked = Not cell.ShowControlPoints

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

               If _chkSnapRulers.Checked <> cell.SnapRulers Then
                  cell.SnapRulers = _chkSnapRulers.Checked
               End If

               If _chkDisableControlPoints.Checked = cell.ShowControlPoints Then
                  cell.ShowControlPoints = Not _chkDisableControlPoints.Checked
               End If

            End If
         Next cell
      End Sub

   End Class
End Namespace
