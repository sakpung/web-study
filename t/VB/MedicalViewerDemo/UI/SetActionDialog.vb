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
   Partial Public Class SetActionDialog : Inherits Form
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

      Private _actionType As MedicalViewerActionType
      Private _annotationAction As Boolean = False

      Public Sub New(ByVal owner As MainForm, ByVal actionType As MedicalViewerActionType, ByVal annotationAction As Boolean)
         Initialize(owner, actionType)
         _annotationAction = annotationAction
      End Sub

      Public Sub New(ByVal owner As MainForm, ByVal actionType As MedicalViewerActionType)
         Initialize(owner, actionType)
      End Sub

      Public Sub Initialize(ByVal owner As MainForm, ByVal actionType As MedicalViewerActionType)
         InitializeComponent()

         cell = MainForm.DefaultCell
         viewer = owner.Viewer
         _owner = owner

         _actionType = actionType
         Me.Text = "Set " & GetSeparatedText(actionType.ToString()) & " Action"

         If cell.IsValidForAction(actionType, MedicalViewerMouseButtons.Wheel) Then
            _cmbMouseButton.Items.Insert(4, "Wheel")
         End If

         If cell.IsValidForAction(actionType, MedicalViewerActionFlags.Selected) Then
            _cmbApplyTo.Items.Add("Selected Cells")
            _cmbApplyTo.Items.Add("All Cells")
         End If

         If cell.IsValidForAction(actionType, MedicalViewerActionFlags.Selected) Then
            _cmbApplyingMethod.Items.Add("On Release")
         End If

         Dim actionFlags As MedicalViewerActionFlags = cell.GetActionFlags(actionType)


         If (actionFlags Or MedicalViewerActionFlags.OnRelease) = actionFlags Then
            _cmbApplyingMethod.SelectedIndex = 1
         Else
            _cmbApplyingMethod.SelectedIndex = 0
         End If

         If (actionFlags And MedicalViewerActionFlags.Selected) = MedicalViewerActionFlags.Selected Then
            _cmbApplyTo.SelectedIndex = 1
         ElseIf (actionFlags And MedicalViewerActionFlags.AllCells) = MedicalViewerActionFlags.AllCells Then
            _cmbApplyTo.SelectedIndex = 2
         Else
            _cmbApplyTo.SelectedIndex = 0
         End If

         _cmbMouseButton.SelectedIndex = CInt(cell.GetActionButton(actionType))
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         Me.Close()
         _btnApply_Click(sender, e)
      End Sub

      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         Dim applyingOperation As MedicalViewerActionFlags = CType(0, MedicalViewerActionFlags)

         Select Case _cmbApplyTo.SelectedIndex
            Case 0
               applyingOperation = MedicalViewerActionFlags.Active
            Case 1
               applyingOperation = MedicalViewerActionFlags.Selected
            Case 2
               applyingOperation = MedicalViewerActionFlags.AllCells
         End Select

         If _cmbApplyTo.SelectedIndex > 0 Then
            If _cmbApplyingMethod.SelectedIndex = 1 Then
               applyingOperation = applyingOperation Xor MedicalViewerActionFlags.OnRelease
            Else
               applyingOperation = applyingOperation Xor MedicalViewerActionFlags.RealTime
            End If

         End If

         If CType(_cmbMouseButton.SelectedIndex, MedicalViewerMouseButtons) = MedicalViewerMouseButtons.Left Then
            _owner.CurrentAction = _actionType
            _owner.LeftButtonAction = _actionType
            _owner.CheckMoveMarkersAction(False)
            _owner.CheckSelectPoints(False)
         End If
         If CType(_cmbMouseButton.SelectedIndex, MedicalViewerMouseButtons) = MedicalViewerMouseButtons.Right Then
            _owner.RightButtonAction = _actionType
         End If

         cell.SetAction(_actionType, CType(_cmbMouseButton.SelectedIndex, MedicalViewerMouseButtons), applyingOperation)

         For Each viewerCell As MedicalViewerBaseCell In viewer.Cells
            viewerCell.SetAction(_actionType, CType(_cmbMouseButton.SelectedIndex, MedicalViewerMouseButtons), applyingOperation)
         Next viewerCell


         If CType(_cmbMouseButton.SelectedIndex, MedicalViewerMouseButtons) = MedicalViewerMouseButtons.Left Then
            If _annotationAction Then
               PushAnnotationIcon(_actionType)
            Else
               UnpushAllAnnotationIcons()
            End If
         End If
      End Sub


      Private Sub PushAnnotationIcon(ByVal actionType As MedicalViewerActionType)
         UnpushAllAnnotationIcons()

         Dim buttonAction As MedicalViewerActionType

         For Each button As ToolBarButton In _owner.ManagerHelper.ToolBar.Buttons
            buttonAction = _owner.GetAnnotationActionId(CInt(button.Tag))
            If buttonAction = actionType Then
               button.Pushed = True
               _owner.CurrentToolBarButton = button
               Return
            End If
         Next button
      End Sub


      Private Sub UnpushAllAnnotationIcons()
         For Each button As ToolBarButton In _owner.ManagerHelper.ToolBar.Buttons
            button.Pushed = False
         Next button
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
