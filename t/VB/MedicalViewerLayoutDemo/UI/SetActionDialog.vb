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
   Public Partial Class SetActionDialog : Inherits Form
	  Private Function GetSeparatedText(ByVal sourceString As String) As String
		 Dim result As String = sourceString.ToString()
		 Dim index As Integer = 1

		 Do While index < result.Length
			If Char.IsUpper(result.Chars(index)) Then
			   result = result.Insert(index, " ")
			   index += 1
			End If

			index += 1
		 Loop
		 Return result
	  End Function

	  Private _actionType As MedicalViewerActionType
	  Private _SelectedCell As MedicalViewerCell
	  Private _viewer As MedicalViewer

	  Public Sub New(ByVal owner As MainForm, ByVal viewer As MedicalViewer, ByVal selectedCell As MedicalViewerCell, ByVal actionType As MedicalViewerActionType)
		 InitializeComponent()
		 _viewer = viewer
		 _actionType = actionType
		 _SelectedCell = selectedCell
		 Me.Text = "Set " & GetSeparatedText(actionType.ToString()) & " Action"

		 If selectedCell.IsValidForAction(actionType, MedicalViewerMouseButtons.Wheel) Then
			 _cmbMouseButton.Items.Insert(4, "Wheel")
		 End If

		 If selectedCell.IsValidForAction(actionType, MedicalViewerActionFlags.Selected) Then
			 _cmbApplyTo.Items.Add("Selected Cells")
			 _cmbApplyTo.Items.Add("All Cells")
		 End If

		 If selectedCell.IsValidForAction(actionType, MedicalViewerActionFlags.Selected) Then
			 _cmbApplyingMethod.Items.Add("On Release")
		 End If

		 Dim actionFlags As MedicalViewerActionFlags = selectedCell.GetActionFlags(actionType)

            If (actionFlags Or MedicalViewerActionFlags.OnRelease) = actionFlags Then
                _cmbApplyingMethod.SelectedIndex = 1
            Else
                _cmbApplyingMethod.SelectedIndex = 0
            End If

            If (actionFlags Or MedicalViewerActionFlags.Selected) = actionFlags Then
                _cmbApplyTo.SelectedIndex = 1
            ElseIf (actionFlags Or MedicalViewerActionFlags.AllCells) = actionFlags Then
                _cmbApplyTo.SelectedIndex = 2
            Else
                _cmbApplyTo.SelectedIndex = 0
            End If

		 _cmbMouseButton.SelectedIndex = CInt(selectedCell.GetActionButton(actionType))
	  End Sub

	  Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
		 Me.Close()
		 _btnApply_Click(sender, e)
	  End Sub

	  Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
		  Dim applyingOperation As MedicalViewerActionFlags = CType(_cmbApplyTo.SelectedIndex, MedicalViewerActionFlags)
		  If _cmbApplyingMethod.SelectedIndex = 1 Then
			  applyingOperation = applyingOperation Xor MedicalViewerActionFlags.OnRelease
		  End If

		  _SelectedCell.SetAction(_actionType, CType(_cmbMouseButton.SelectedIndex, MedicalViewerMouseButtons), applyingOperation)

		 For Each cell As MedicalViewerBaseCell In _viewer.Cells
			cell.SetAction(_actionType, CType(_cmbMouseButton.SelectedIndex, MedicalViewerMouseButtons), applyingOperation)
		 Next cell
	  End Sub

	  Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
		 Me.Close()
	  End Sub

	  Private Sub _cmbApplyTo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbApplyTo.SelectedIndexChanged
		 If ((_cmbMouseButton.Text = "Wheel") OrElse (_cmbApplyTo.SelectedIndex = 0)) Then
			 _cmbApplyingMethod.Enabled = False
		 Else
			 _cmbApplyingMethod.Enabled = True
		 End If
	  End Sub

	  Private Sub _cmbMouseButton_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbMouseButton.SelectedIndexChanged
		 If ((_cmbMouseButton.Text = "Wheel") OrElse (_cmbMouseButton.SelectedIndex = 0) OrElse (_cmbApplyTo.SelectedIndex = 0)) Then
			 _cmbApplyingMethod.Enabled = False
		 Else
			 _cmbApplyingMethod.Enabled = True
		 End If
		 If (_cmbMouseButton.SelectedIndex = 0) Then
			 _cmbApplyTo.Enabled = False
		 Else
			 _cmbApplyTo.Enabled = True
		 End If
	  End Sub
   End Class
End Namespace
