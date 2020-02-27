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
   Partial Public Class AnimationDialog : Inherits Form
      Private _viewer As MedicalViewer
      Private _cellIndex As Integer

      Public Sub New(ByVal owner As MainForm, ByVal cellIndex As Integer)
         InitializeComponent()
         _viewer = owner.Viewer
         _cellIndex = cellIndex
         Dim cell As MedicalViewerCell = CType(_viewer.Cells(_cellIndex), MedicalViewerCell)

         Me.Size = New Size(Me.Size.Width, 213)
         _grpExtendedParameters.Visible = False
         _txtFrom.Value = (cell.Animation.StartFrame + 1)
         Dim toEnd As Boolean = cell.Animation.FrameCount = -1
         If (cell.Animation.FrameCount = -1) Then
            _txtTo.Value = cell.Image.PageCount
         Else
            _txtTo.Value = cell.Animation.FrameCount + 1
         End If
         _chkToEnd.Checked = toEnd
         _tbSpeed.Value = (301 - cell.Animation.Interval)
         _chkShowAnnotation.Checked = (cell.Animation.Flags And MedicalViewerAnimationFlags.ShowAnnotations) = MedicalViewerAnimationFlags.ShowAnnotations
         _chkShowRegion.Checked = (cell.Animation.Flags And MedicalViewerAnimationFlags.ShowRegions) = MedicalViewerAnimationFlags.ShowRegions
         _cmbInterpolation.SelectedIndex = CInt(cell.Animation.Flags And (MedicalViewerAnimationFlags.PaintNormal Or MedicalViewerAnimationFlags.PaintResample Or MedicalViewerAnimationFlags.PaintBicubic))
         _radLoop.Checked = (cell.Animation.Flags And (MedicalViewerAnimationFlags.Sequence Or MedicalViewerAnimationFlags.Loop)) = MedicalViewerAnimationFlags.Sequence
         _radShuffle.Checked = Not _radLoop.Checked
         _chkAnimateAllSubCells.Checked = cell.Animation.AnimateAllSubCells
         If (cell.Animation.Flags And MedicalViewerAnimationFlags.PlayOnSelection) = MedicalViewerAnimationFlags.PlayOnSelection Then
            cell.Animation.Flags = cell.Animation.Flags Xor MedicalViewerAnimationFlags.PlayOnSelection
         End If



         If cell.Animation.Animated Then
            If CInt(cell.Animation.Flags And MedicalViewerAnimationFlags.PlayBackward) <> 0 Then
               _chkBackward.Checked = True
            Else
               _chkForward.Checked = True
            End If
         Else
            _chkStop.Checked = True
         End If



         Select Case cell.Animation.Frames
            Case -1, 0, 1
               _cmbFrames.SelectedIndex = cell.Animation.Frames + 1
            Case Else
               _cmbFrames.SelectedIndex = 3
               _txtFrames.Value = cell.Animation.Frames
         End Select
      End Sub

      Private Sub _btnAdvance_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnAdvance.Click
         If _btnAdvance.Text = "Ad&vance >>" Then
            _btnAdvance.Text = "&Basic <<"
            Me.Size = New Size(Me.Size.Width, 438)
            _grpExtendedParameters.Visible = True
         ElseIf _btnAdvance.Text = "&Basic <<" Then
            _btnAdvance.Text = "Ad&vance >>"
            Me.Size = New Size(Me.Size.Width, 213)
            _grpExtendedParameters.Visible = False
         End If
      End Sub

		Private Sub _chkBackward_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _chkBackward.Click
			If _viewer IsNot Nothing Then
				Dim cell As MedicalViewerCell = CType(_viewer.Cells(_cellIndex), MedicalViewerCell)
				If (Not _chkBackward.Checked) Then
					_chkStop.Checked = False
					_chkForward.Checked = False
					_chkBackward.Checked = True

					cell.Animation.Flags = cell.Animation.Flags And Not (MedicalViewerAnimationFlags.PlayForward Or MedicalViewerAnimationFlags.PlayBackward)
					cell.Animation.Flags = cell.Animation.Flags Or MedicalViewerAnimationFlags.PlayBackward
					cell.Animation.Animated = _chkBackward.Checked
				End If
			End If
		End Sub

		Private Sub _chkForward_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _chkForward.Click
			If _viewer IsNot Nothing Then
				Dim cell As MedicalViewerCell = CType(_viewer.Cells(_cellIndex), MedicalViewerCell)
				If (Not _chkForward.Checked) Then
					_chkStop.Checked = False
					_chkBackward.Checked = False
					_chkForward.Checked = True

					cell.Animation.Flags = cell.Animation.Flags And Not (MedicalViewerAnimationFlags.PlayForward Or MedicalViewerAnimationFlags.PlayBackward)
					cell.Animation.Flags = cell.Animation.Flags Or MedicalViewerAnimationFlags.PlayForward
					cell.Animation.Animated = _chkForward.Checked
				End If
			End If
		End Sub

		Private Sub _chkStop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _chkStop.Click
			If _viewer IsNot Nothing Then
				Dim cell As MedicalViewerCell = CType(_viewer.Cells(_cellIndex), MedicalViewerCell)
				If _chkForward.Checked Or _chkBackward.Checked Then
					_chkForward.Checked = False
					_chkBackward.Checked = False

					cell.Animation.Animated = False
				End If
			End If
		End Sub

		Private Sub _radShuffle_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _radShuffle.CheckedChanged
			If _viewer IsNot Nothing Then
				Dim cell As MedicalViewerCell = CType(_viewer.Cells(_cellIndex), MedicalViewerCell)
				cell.Animation.Flags = cell.Animation.Flags And Not (MedicalViewerAnimationFlags.Loop Or MedicalViewerAnimationFlags.Sequence)
				If _radShuffle.Checked Then
					cell.Animation.Flags = cell.Animation.Flags Or (MedicalViewerAnimationFlags.Loop)
				Else
					cell.Animation.Flags = cell.Animation.Flags Or (MedicalViewerAnimationFlags.Sequence)
				End If
			End If
		End Sub

		Private Sub _cmbInterpolation_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbInterpolation.SelectedIndexChanged
			If _viewer IsNot Nothing Then
				Dim cell As MedicalViewerCell = CType(_viewer.Cells(_cellIndex), MedicalViewerCell)
				cell.Animation.Flags = cell.Animation.Flags And Not (MedicalViewerAnimationFlags.PaintBicubic Or MedicalViewerAnimationFlags.PaintNormal Or MedicalViewerAnimationFlags.PaintResample)

				Select Case _cmbInterpolation.SelectedIndex
					Case 0
						cell.Animation.Flags = cell.Animation.Flags Or MedicalViewerAnimationFlags.PaintNormal
					Case 1
						cell.Animation.Flags = cell.Animation.Flags Or MedicalViewerAnimationFlags.PaintResample
					Case 2
						cell.Animation.Flags = cell.Animation.Flags Or MedicalViewerAnimationFlags.PaintBicubic
				End Select
			End If
		End Sub

		Private Sub _chkAnimateAllSubCells_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkAnimateAllSubCells.CheckedChanged
			If _viewer IsNot Nothing Then
				Dim cell As MedicalViewerCell = CType(_viewer.Cells(_cellIndex), MedicalViewerCell)
				cell.Animation.AnimateAllSubCells = _chkAnimateAllSubCells.Checked
			End If
		End Sub

		Private Sub _chkShowRegion_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkShowRegion.CheckedChanged
			If _viewer IsNot Nothing Then
				Dim cell As MedicalViewerCell = CType(_viewer.Cells(_cellIndex), MedicalViewerCell)
				cell.Animation.Flags = cell.Animation.Flags And Not (MedicalViewerAnimationFlags.ShowRegions)
				If _chkShowRegion.Checked Then
					cell.Animation.Flags = cell.Animation.Flags Or MedicalViewerAnimationFlags.ShowRegions
				End If
			End If
		End Sub

		Private Sub _chkShowAnnotation_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkShowAnnotation.CheckedChanged
			If _viewer IsNot Nothing Then
				Dim cell As MedicalViewerCell = CType(_viewer.Cells(_cellIndex), MedicalViewerCell)
				cell.Animation.Flags = cell.Animation.Flags And Not (MedicalViewerAnimationFlags.ShowAnnotations)
				If _chkShowAnnotation.Checked Then
					cell.Animation.Flags = cell.Animation.Flags Or MedicalViewerAnimationFlags.ShowAnnotations
				End If
			End If
		End Sub

		Private Sub _cmbFrames_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbFrames.SelectedIndexChanged
			If _viewer IsNot Nothing Then
				Dim cell As MedicalViewerCell = CType(_viewer.Cells(_cellIndex), MedicalViewerCell)
				Select Case _cmbFrames.SelectedIndex
					Case 0
						cell.Animation.Frames = -1
						_txtFrames.Enabled = False
					Case 1
						cell.Animation.Frames = 0
						_txtFrames.Enabled = False
					Case 2
						cell.Animation.Frames = 1
						_txtFrames.Enabled = False
					Case 3
						cell.Animation.Frames = _txtFrames.Value
						_txtFrames.Enabled = True
				End Select
			End If
		End Sub

		Private Sub _txtFrames_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txtFrames.TextChanged
			If _viewer IsNot Nothing Then
				Dim cell As MedicalViewerCell = CType(_viewer.Cells(_cellIndex), MedicalViewerCell)
				If _txtFrames.Value = 1 Then
					cell.Animation.Frames = -1
				Else
					cell.Animation.Frames = _txtFrames.Value
				End If
			End If
		End Sub

		Private Sub _txtFrom_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txtFrom.TextChanged
			If _viewer IsNot Nothing Then
				Dim cell As MedicalViewerCell = CType(_viewer.Cells(_cellIndex), MedicalViewerCell)
				cell.Animation.StartFrame = _txtFrom.Value - 1
			End If
		End Sub

		Private Sub _txtTo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txtTo.TextChanged
			If _viewer IsNot Nothing Then
				Dim cell As MedicalViewerCell = CType(_viewer.Cells(_cellIndex), MedicalViewerCell)
				cell.Animation.FrameCount = _txtTo.Value - 1
			End If
		End Sub

		Private Sub _chkToEnd_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkToEnd.CheckedChanged
			If _viewer IsNot Nothing Then
				Dim cell As MedicalViewerCell = CType(_viewer.Cells(_cellIndex), MedicalViewerCell)
				_txtTo.Enabled = Not _chkToEnd.Checked
				If _chkToEnd.Checked Then
					cell.Animation.FrameCount = -1
				Else
					cell.Animation.FrameCount = _txtTo.Value
				End If
			End If

		End Sub

		Private Sub _tbSpeed_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbSpeed.Scroll
			If _viewer IsNot Nothing Then
				Dim cell As MedicalViewerCell = CType(_viewer.Cells(_cellIndex), MedicalViewerCell)
				cell.Animation.Interval = (301 - _tbSpeed.Value)
			End If
		End Sub

		Private Sub _btnHidden_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnHidden.Click
         Me.Close()
      End Sub
   End Class
End Namespace
