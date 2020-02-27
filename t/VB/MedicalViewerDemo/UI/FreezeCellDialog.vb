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
   Partial Public Class FreezeCellDialog : Inherits Form
      Public Sub New(ByVal owner As MainForm)
         InitializeComponent()

         Me.CancelButton = _cancelButton
         Me.AcceptButton = okButton

         ' set the allowed range for the cell index text box.
         freezeCombo.SelectedIndex = 0
         cellIndexText.MinimumAllowed = -1
         cellIndexText.MaximumAllowed = owner.Viewer.Cells.Count - 1
         cellIndexText.Text = (0).ToString()
      End Sub

      Private Sub okButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles okButton.Click
         applyButton_Click(sender, e)
         Me.Close()
      End Sub

      Private Sub applyToSingleRadio_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles applyToSingleRadio.CheckedChanged
         cellIndexText.Enabled = applyToSingleRadio.Checked
         cellIndexLabel.Enabled = applyToSingleRadio.Checked
         If applyToSingleRadio.Checked Then
            cellIndexText.Focus()
         End If
      End Sub

      Private Sub applyButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles applyButton.Click
         Try
            If applyToSingleRadio.Checked Then
               CType((CType(Me.Owner, MainForm)).Viewer.Cells(Convert.ToInt32(cellIndexText.Text)), MedicalViewerMultiCell).Frozen = (freezeCombo.SelectedIndex = 0)
            ElseIf applyToSelectedRadio.Checked Then
               'if (freezeCombo.SelectedIndex == 0)
               CType(Me.Owner, MainForm).Viewer.Cells.FreezeSelected(freezeCombo.SelectedIndex = 0)
               'else
               '((MainForm)this.Owner).Viewer.Cells.UnfreezeSelected();
            ElseIf applyToAllRadio.Checked Then
               'if (freezeCombo.SelectedIndex == 0)
               CType(Me.Owner, MainForm).Viewer.Cells.FreezeAll(freezeCombo.SelectedIndex = 0)
               ' else
               '((MainForm)this.Owner).Viewer.Cells.UnfreezeAll();
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub
   End Class
End Namespace
