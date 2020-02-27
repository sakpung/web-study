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
   Partial Public Class SetNudgeShrinkActionDialog : Inherits Form
      Private cell As MedicalViewerMultiCell = Nothing
      Private viewer As MedicalViewer
      Private _owner As MainForm
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

      Public Sub New(ByVal owner As MainForm)
         InitializeComponent()

         cell = MainForm.DefaultCell
         viewer = owner.Viewer
         _owner = owner

         If cell.IsValidForAction(MedicalViewerActionType.NudgeTool, MedicalViewerMouseButtons.Wheel) Then
            _cmbNudgeMouseButton.Items.Insert(4, "Wheel")
         End If
         If cell.IsValidForAction(MedicalViewerActionType.ShrinkTool, MedicalViewerMouseButtons.Wheel) Then
            _cmbShrinkMouseButton.Items.Insert(4, "Wheel")
         End If

         If cell.IsValidForAction(MedicalViewerActionType.NudgeTool, MedicalViewerActionFlags.Selected) Then
            _cmbNudgeApplyTo.Items.Add("Selected Cells")
            _cmbNudgeApplyTo.Items.Add("All Cells")
         End If
         If cell.IsValidForAction(MedicalViewerActionType.ShrinkTool, MedicalViewerActionFlags.Selected) Then
            _cmbShrinkApplyTo.Items.Add("Selected Cells")
            _cmbShrinkApplyTo.Items.Add("All Cells")
         End If

         If cell.IsValidForAction(MedicalViewerActionType.NudgeTool, MedicalViewerActionFlags.Selected) Then
            _cmbNudgeApplyingMethod.Items.Add("On Release")
         End If
         If cell.IsValidForAction(MedicalViewerActionType.ShrinkTool, MedicalViewerActionFlags.Selected) Then
            _cmbNudgeMouseButton.Items.Add("On Release")
         End If

         Dim actionFlags As MedicalViewerActionFlags = cell.GetActionFlags(MedicalViewerActionType.NudgeTool)
         If (actionFlags Or MedicalViewerActionFlags.OnRelease) = actionFlags Then
            _cmbNudgeApplyingMethod.SelectedIndex = 1
         Else
            _cmbNudgeApplyingMethod.SelectedIndex = 0
         End If

         If (actionFlags And MedicalViewerActionFlags.Selected) = MedicalViewerActionFlags.Selected Then
            _cmbNudgeApplyTo.SelectedIndex = 1
         ElseIf (actionFlags And MedicalViewerActionFlags.AllCells) = MedicalViewerActionFlags.AllCells Then
            _cmbNudgeApplyTo.SelectedIndex = 2
         Else
            _cmbNudgeApplyTo.SelectedIndex = 0
         End If

         _cmbNudgeMouseButton.SelectedIndex = CInt(cell.GetActionButton(MedicalViewerActionType.NudgeTool))


         actionFlags = cell.GetActionFlags(MedicalViewerActionType.ShrinkTool)
         If (actionFlags Or MedicalViewerActionFlags.OnRelease) = actionFlags Then
            _cmbShrinkApplyingMethod.SelectedIndex = 1
         Else
            _cmbShrinkApplyingMethod.SelectedIndex = 0
         End If

         If (actionFlags And MedicalViewerActionFlags.Selected) = MedicalViewerActionFlags.Selected Then
            _cmbShrinkApplyTo.SelectedIndex = 1
         ElseIf (actionFlags And MedicalViewerActionFlags.AllCells) = MedicalViewerActionFlags.AllCells Then
            _cmbShrinkApplyTo.SelectedIndex = 2
         Else
            _cmbShrinkApplyTo.SelectedIndex = 0
         End If

         _cmbShrinkMouseButton.SelectedIndex = CInt(cell.GetActionButton(MedicalViewerActionType.ShrinkTool))
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         Me.Close()
         _btnApply_Click(sender, e)
      End Sub

      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         Dim applyingOperation As MedicalViewerActionFlags = CType(0, MedicalViewerActionFlags)

         Select Case _cmbNudgeApplyTo.SelectedIndex
            Case 0
               applyingOperation = MedicalViewerActionFlags.Active
            Case 1
               applyingOperation = MedicalViewerActionFlags.Selected
            Case 2
               applyingOperation = MedicalViewerActionFlags.AllCells
         End Select

         If _cmbNudgeApplyTo.SelectedIndex > 0 Then
            If _cmbNudgeApplyingMethod.SelectedIndex = 1 Then
               applyingOperation = applyingOperation Xor MedicalViewerActionFlags.OnRelease
            Else
               applyingOperation = applyingOperation Xor MedicalViewerActionFlags.RealTime
            End If

         End If

         If CType(_cmbNudgeMouseButton.SelectedIndex, MedicalViewerMouseButtons) = MedicalViewerMouseButtons.Left Then
            _owner.CurrentAction = MedicalViewerActionType.NudgeTool
            _owner.LeftButtonAction = MedicalViewerActionType.NudgeTool
            _owner.CheckMoveMarkersAction(False)
            _owner.CheckSelectPoints(False)
         End If
         If CType(_cmbNudgeMouseButton.SelectedIndex, MedicalViewerMouseButtons) = MedicalViewerMouseButtons.Right Then
            _owner.RightButtonAction = MedicalViewerActionType.NudgeTool
         End If

         cell.SetAction(MedicalViewerActionType.NudgeTool, CType(_cmbNudgeMouseButton.SelectedIndex, MedicalViewerMouseButtons), applyingOperation)

         For Each viewerCell As MedicalViewerBaseCell In viewer.Cells
            viewerCell.SetAction(MedicalViewerActionType.NudgeTool, CType(_cmbNudgeMouseButton.SelectedIndex, MedicalViewerMouseButtons), applyingOperation)
         Next viewerCell




         applyingOperation = CType(0, MedicalViewerActionFlags)

         Select Case _cmbShrinkApplyTo.SelectedIndex
            Case 0
               applyingOperation = MedicalViewerActionFlags.Active
            Case 1
               applyingOperation = MedicalViewerActionFlags.Selected
            Case 2
               applyingOperation = MedicalViewerActionFlags.AllCells
         End Select

         If _cmbShrinkApplyTo.SelectedIndex > 0 Then
            If _cmbShrinkApplyingMethod.SelectedIndex = 1 Then
               applyingOperation = applyingOperation Xor MedicalViewerActionFlags.OnRelease
            Else
               applyingOperation = applyingOperation Xor MedicalViewerActionFlags.RealTime
            End If

         End If
         If CType(_cmbShrinkMouseButton.SelectedIndex, MedicalViewerMouseButtons) = MedicalViewerMouseButtons.Left Then
            _owner.CurrentAction = MedicalViewerActionType.ShrinkTool
            _owner.LeftButtonAction = MedicalViewerActionType.ShrinkTool
            _owner.CheckMoveMarkersAction(False)
            _owner.CheckSelectPoints(False)
         End If
         If CType(_cmbShrinkMouseButton.SelectedIndex, MedicalViewerMouseButtons) = MedicalViewerMouseButtons.Right Then
            _owner.RightButtonAction = MedicalViewerActionType.ShrinkTool
         End If

         cell.SetAction(MedicalViewerActionType.ShrinkTool, CType(_cmbShrinkMouseButton.SelectedIndex, MedicalViewerMouseButtons), applyingOperation)

         For Each viewerCell As MedicalViewerBaseCell In viewer.Cells
            viewerCell.SetAction(MedicalViewerActionType.ShrinkTool, CType(_cmbShrinkMouseButton.SelectedIndex, MedicalViewerMouseButtons), applyingOperation)
         Next viewerCell
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         Me.Close()
      End Sub

      Private Sub _cmbApplyTo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbNudgeApplyTo.SelectedIndexChanged, _cmbShrinkApplyTo.SelectedIndexChanged
         Dim cmBox As ComboBox = CType(sender, ComboBox)

         If cmBox.Name = "_cmbNudgeMouseButton" Then
            If ((_cmbNudgeMouseButton.Text = "Wheel") OrElse (_cmbNudgeApplyTo.SelectedIndex = 0)) Then
               _cmbNudgeApplyingMethod.Enabled = False
            Else
               _cmbNudgeApplyingMethod.Enabled = True
            End If
         ElseIf cmBox.Name = "_cmbShrinkMouseButton" Then
            If ((_cmbShrinkMouseButton.Text = "Wheel") OrElse (_cmbShrinkApplyTo.SelectedIndex = 0)) Then
               _cmbShrinkApplyingMethod.Enabled = False
            Else
               _cmbShrinkApplyingMethod.Enabled = True
            End If
         End If
      End Sub

      Private Sub _cmbMouseButton_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbNudgeMouseButton.SelectedIndexChanged, _cmbShrinkMouseButton.SelectedIndexChanged
         Dim cmBox As ComboBox = CType(sender, ComboBox)

         If cmBox.Name = "_cmbNudgeMouseButton" Then
            If ((_cmbNudgeMouseButton.Text = "Wheel") OrElse (_cmbNudgeMouseButton.SelectedIndex = 0) OrElse (_cmbNudgeApplyTo.SelectedIndex = 0)) Then
               _cmbNudgeApplyingMethod.Enabled = False
            Else
               _cmbNudgeApplyingMethod.Enabled = True
            End If
            If (_cmbNudgeMouseButton.SelectedIndex = 0) Then
               _cmbNudgeApplyTo.Enabled = False
            Else
               _cmbNudgeApplyTo.Enabled = True
            End If

            If _cmbNudgeMouseButton.Text = _cmbShrinkMouseButton.Text Then
               _cmbShrinkMouseButton.SelectedIndex = 0
            End If
         ElseIf cmBox.Name = "_cmbShrinkMouseButton" Then
            If ((_cmbShrinkMouseButton.Text = "Wheel") OrElse (_cmbShrinkMouseButton.SelectedIndex = 0) OrElse (_cmbShrinkApplyTo.SelectedIndex = 0)) Then
               _cmbShrinkApplyingMethod.Enabled = False
            Else
               _cmbShrinkApplyingMethod.Enabled = True
            End If
            If (_cmbShrinkMouseButton.SelectedIndex = 0) Then
               _cmbShrinkApplyTo.Enabled = False
            Else
               _cmbShrinkApplyTo.Enabled = True
            End If

            If _cmbNudgeMouseButton.Text = _cmbShrinkMouseButton.Text Then
               _cmbNudgeMouseButton.SelectedIndex = 0
            End If
         End If
      End Sub
   End Class
End Namespace
