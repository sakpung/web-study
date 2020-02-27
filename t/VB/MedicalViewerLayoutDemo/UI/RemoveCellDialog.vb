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

Namespace MedicalViewerLayoutDemo
   Public Partial Class RemoveCellDialog : Inherits Form
	  Public Sub New(ByVal owner As MainForm)
		 InitializeComponent()

		 ' set the allowed range for the cell index text box.
		 cellIndexText.MinimumAllowed = -1
		 cellIndexText.MaximumAllowed = owner.Viewer.Cells.Count - 1
            cellIndexText.Text = (0).ToString()
            removeSelectedRadio.Enabled = owner.GetSelectedCell() IsNot Nothing
            If removeSelectedRadio.Enabled Then
                removeSelectedRadio.Checked = True
            End If

	  End Sub

	  Private Sub removeSpecificRadio_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles removeSpecificRadio.CheckedChanged
		 cellIndexLabel.Enabled = removeSpecificRadio.Checked
		 cellIndexText.Enabled = removeSpecificRadio.Checked
		 If removeSpecificRadio.Checked Then
			cellIndexText.Focus()
		 End If
	  End Sub

	  Private Sub okButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
		 Try
			If removeSpecificRadio.Checked Then
			   CType(Me.Owner, MainForm).Viewer.Cells.RemoveAt(Convert.ToInt32(cellIndexText.Text))
			ElseIf removeSelectedRadio.Checked Then
			   CType(Me.Owner, MainForm).RemoveSelectedCells()
			ElseIf removeAllRadio.Checked Then
			   CType(Me.Owner, MainForm).Viewer.Cells.Clear()
			End If
		 Catch ex As Exception
			Messager.ShowError(Me, ex)
		 End Try
		 Me.Close()
	  End Sub
   End Class
End Namespace
