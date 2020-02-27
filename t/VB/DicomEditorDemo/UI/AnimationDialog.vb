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

Namespace DicomEditorDemo
   Partial Public Class AnimationDialog
	   Inherits Form
	  Private _viewer As MedicalViewer

	  Public Sub New(ByVal viewer As MedicalViewer)
		 InitializeComponent()
		 _viewer = viewer
		 Dim cell As MedicalViewerCell = CType(_viewer.Cells(0), MedicalViewerCell)

		 Me.Size = New Size(Me.Size.Width, 213)
		 _grpExtendedParameters.Visible = False
		 _txtFrom.Value = (cell.Animation.StartFrame + 1)
		 Dim toEnd As Boolean = cell.Animation.FrameCount = -1
		 _txtTo.Value = If((cell.Animation.FrameCount = -1), cell.Image.PageCount, cell.Animation.FrameCount + 1)
		 _chkToEnd.Checked = toEnd
		 _tbSpeed.Value = (301 - cell.Animation.Interval)
		 _chkShowAnnotation.Checked = (cell.Animation.Flags And MedicalViewerAnimationFlags.ShowAnnotations) = MedicalViewerAnimationFlags.ShowAnnotations
		 _chkShowRegion.Checked = (cell.Animation.Flags And MedicalViewerAnimationFlags.ShowRegions) = MedicalViewerAnimationFlags.ShowRegions
		 _cmbInterpolation.SelectedIndex = CInt(Fix(cell.Animation.Flags And (MedicalViewerAnimationFlags.PaintNormal Or MedicalViewerAnimationFlags.PaintResample Or MedicalViewerAnimationFlags.PaintBicubic)))
		 _radLoop.Checked = (cell.Animation.Flags And (MedicalViewerAnimationFlags.Sequence Or MedicalViewerAnimationFlags.Loop)) = MedicalViewerAnimationFlags.Sequence
		 _radShuffle.Checked = Not _radLoop.Checked
		 _chkAnimateAllSubCells.Checked = cell.Animation.AnimateAllSubCells
		 If (cell.Animation.Flags And MedicalViewerAnimationFlags.PlayOnSelection) = MedicalViewerAnimationFlags.PlayOnSelection Then
			cell.Animation.Flags = cell.Animation.Flags Xor MedicalViewerAnimationFlags.PlayOnSelection
		 End If



		 If cell.Animation.Animated Then
			If CInt(Fix(cell.Animation.Flags And MedicalViewerAnimationFlags.PlayBackward)) <> 0 Then
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
		 Dim cell As MedicalViewerCell = CType(_viewer.Cells(0), MedicalViewerCell)
		 If (Not _chkBackward.Checked) Then
			_chkStop.Checked = False
			_chkForward.Checked = False
			_chkBackward.Checked = True

			cell.Animation.Flags = cell.Animation.Flags And Not(MedicalViewerAnimationFlags.PlayForward Or MedicalViewerAnimationFlags.PlayBackward)
			cell.Animation.Flags = cell.Animation.Flags Or MedicalViewerAnimationFlags.PlayBackward
			cell.Animation.Animated = _chkBackward.Checked
		 End If
	  End Sub

	  Private Sub _chkForward_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _chkForward.Click
		 Dim cell As MedicalViewerCell = CType(_viewer.Cells(0), MedicalViewerCell)
		 If (Not _chkForward.Checked) Then
			_chkStop.Checked = False
			_chkBackward.Checked = False
			_chkForward.Checked = True

			cell.Animation.Flags = cell.Animation.Flags And Not(MedicalViewerAnimationFlags.PlayForward Or MedicalViewerAnimationFlags.PlayBackward)
			cell.Animation.Flags = cell.Animation.Flags Or MedicalViewerAnimationFlags.PlayForward
			cell.Animation.Animated = _chkForward.Checked
		 End If
	  End Sub

	  Private Sub _chkStop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _chkStop.Click
		 Dim cell As MedicalViewerCell = CType(_viewer.Cells(0), MedicalViewerCell)
		 If _chkForward.Checked Or _chkBackward.Checked Then
			_chkForward.Checked = False
			_chkBackward.Checked = False

			cell.Animation.Animated = False
		 End If
	  End Sub

	  Private Sub _radShuffle_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _radShuffle.CheckedChanged
		 Dim cell As MedicalViewerCell = CType(_viewer.Cells(0), MedicalViewerCell)
		 cell.Animation.Flags = cell.Animation.Flags And Not(MedicalViewerAnimationFlags.Loop Or MedicalViewerAnimationFlags.Sequence)
		 cell.Animation.Flags = cell.Animation.Flags Or (If(_radShuffle.Checked, MedicalViewerAnimationFlags.Loop, MedicalViewerAnimationFlags.Sequence))
	  End Sub

	  Private Sub _cmbInterpolation_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbInterpolation.SelectedIndexChanged
		 Dim cell As MedicalViewerCell = CType(_viewer.Cells(0), MedicalViewerCell)
		 cell.Animation.Flags = cell.Animation.Flags And Not(MedicalViewerAnimationFlags.PaintBicubic Or MedicalViewerAnimationFlags.PaintNormal Or MedicalViewerAnimationFlags.PaintResample)

		 Select Case _cmbInterpolation.SelectedIndex
			Case 0
			   cell.Animation.Flags = cell.Animation.Flags Or MedicalViewerAnimationFlags.PaintNormal
			Case 1
			   cell.Animation.Flags = cell.Animation.Flags Or MedicalViewerAnimationFlags.PaintResample
			Case 2
			   cell.Animation.Flags = cell.Animation.Flags Or MedicalViewerAnimationFlags.PaintBicubic
		 End Select
	  End Sub

	  Private Sub _chkAnimateAllSubCells_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkAnimateAllSubCells.CheckedChanged
		 Dim cell As MedicalViewerCell = CType(_viewer.Cells(0), MedicalViewerCell)
		 cell.Animation.AnimateAllSubCells = _chkAnimateAllSubCells.Checked
	  End Sub

	  Private Sub _chkShowRegion_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkShowRegion.CheckedChanged
		 Dim cell As MedicalViewerCell = CType(_viewer.Cells(0), MedicalViewerCell)
		 cell.Animation.Flags = cell.Animation.Flags And Not(MedicalViewerAnimationFlags.ShowRegions)
		 If _chkShowRegion.Checked Then
			cell.Animation.Flags = cell.Animation.Flags Or MedicalViewerAnimationFlags.ShowRegions
		 End If
	  End Sub

	  Private Sub _chkShowAnnotation_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkShowAnnotation.CheckedChanged
		 Dim cell As MedicalViewerCell = CType(_viewer.Cells(0), MedicalViewerCell)
		 cell.Animation.Flags = cell.Animation.Flags And Not(MedicalViewerAnimationFlags.ShowAnnotations)
		 If _chkShowAnnotation.Checked Then
			cell.Animation.Flags = cell.Animation.Flags Or MedicalViewerAnimationFlags.ShowAnnotations
		 End If
	  End Sub

	  Private Sub _cmbFrames_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbFrames.SelectedIndexChanged
		 Dim cell As MedicalViewerCell = CType(_viewer.Cells(0), MedicalViewerCell)
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
	  End Sub

	  Private Sub _txtFrames_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txtFrames.TextChanged
		 Dim cell As MedicalViewerCell = CType(_viewer.Cells(0), MedicalViewerCell)
		 If _txtFrames.Value = 1 Then
			cell.Animation.Frames = -1
		 Else
			cell.Animation.Frames = _txtFrames.Value
		 End If
	  End Sub

	  Private Sub _txtFrom_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txtFrom.TextChanged
		 Dim cell As MedicalViewerCell = CType(_viewer.Cells(0), MedicalViewerCell)
		 cell.Animation.StartFrame = _txtFrom.Value - 1
	  End Sub

	  Private Sub _txtTo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txtTo.TextChanged
		 Dim cell As MedicalViewerCell = CType(_viewer.Cells(0), MedicalViewerCell)
		 cell.Animation.FrameCount = _txtTo.Value - 1
	  End Sub

	  Private Sub _chkToEnd_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkToEnd.CheckedChanged
		 Dim cell As MedicalViewerCell = CType(_viewer.Cells(0), MedicalViewerCell)
		 _txtTo.Enabled = Not _chkToEnd.Checked
		 cell.Animation.FrameCount = If(_chkToEnd.Checked, -1, _txtTo.Value)
	  End Sub

	  Private Sub _tbSpeed_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles _tbSpeed.Scroll
		 Dim cell As MedicalViewerCell = CType(_viewer.Cells(0), MedicalViewerCell)
		 cell.Animation.Interval = (301 - _tbSpeed.Value)
	  End Sub

	  Private Sub _btnHidden_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnHidden.Click
		 Me.Close()
	  End Sub
   End Class

   Partial Public Class NumericTextBox
	   Inherits System.Windows.Forms.TextBox
	   Private _maximumAllowed As Integer
	   Private _minimumAllowed As Integer
	   Private _oldText As String

	   Public Sub New()
		   _maximumAllowed = 1000
		   _minimumAllowed = -1000
		   _oldText = ""
	   End Sub

	   <Description("The minimum allowed value to be entered"), Category("Allowed Values")> _
	   Public Property MinimumAllowed() As Integer
		   Set(ByVal value As Integer)
			   _minimumAllowed = value
		   End Set
		   Get
			   Return _minimumAllowed
		   End Get
	   End Property

	   <Description("The maximum allowed value to be entered"), Category("Allowed Values")> _
	   Public Property MaximumAllowed() As Integer
		   Set(ByVal value As Integer)
			   _maximumAllowed = value
		   End Set
		   Get
			   Return _maximumAllowed
		   End Get
	   End Property

	   <Description("The maximum allowed value to be entered"), Category("Current Value")> _
	   Public Property Value() As Integer
		   Set(ByVal value As Integer)
			   Me.Text = value.ToString()
		   End Set
		   Get
			   If Me.Text.Trim() = "" Then
				   Return _minimumAllowed
			   Else
				   Return Convert.ToInt32(Me.Text)
			   End If
		   End Get
	   End Property

	   ' Is the entered number within the specified valid range
	   Private Function IsAllowed(ByVal text As String) As Boolean
         Dim isAllowed_Renamed As Boolean = True

		   Try
			   Dim newNumber As Integer = Convert.ToInt32(text)
			   If (newNumber > _maximumAllowed) OrElse (newNumber < _minimumAllowed) Then
				   isAllowed_Renamed = False
			   End If
		   Catch
			   ' This happen if the entered value is not a numeric.
			   isAllowed_Renamed = False
		   End Try

		   Return isAllowed_Renamed
	   End Function

	   Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
		   If (Not IsAllowed(Me.Text)) Then
			   If _minimumAllowed <= 1 Then
				   Me.Text = _oldText
			   End If
		   Else
			   _oldText = Me.Text
		   End If

		   MyBase.OnTextChanged(e)
	   End Sub

	   Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
		   ' Increase or decrease the current value by 1 if the user presses the UP or DOWN
		   ' and test if the new value is allowed
		   If (e.KeyCode = Keys.Up) OrElse (e.KeyCode = Keys.Down) Then
			   Dim value As Integer = Convert.ToInt32(Me.Text)

			   value = If((e.KeyCode = Keys.Up), value + 1, value - 1)

			   If IsAllowed(value.ToString()) Then
				   Me.Text = value.ToString()
			   End If
		   End If

		   MyBase.OnKeyDown(e)
	   End Sub

	   Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)
		   Dim value As Integer = Convert.ToInt32(Me.Text)
		   If value < _minimumAllowed Then
			   Me.Text = _minimumAllowed.ToString()
		   End If

		   MyBase.OnLostFocus(e)
	   End Sub

	   Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
		   ' if Enter, Escape, Ctrl or Alt key is pressed, then there is no need to check
		   ' since the user is not entering a new character...
		   If ((Control.ModifierKeys And Keys.Control) = 0) AndAlso ((Control.ModifierKeys And Keys.Alt) = 0) AndAlso (e.KeyChar <> Convert.ToChar(Keys.Enter)) AndAlso (e.KeyChar <> Convert.ToChar(Keys.Escape)) Then
'			   #Region "Check if the entered character is valid for Numeric format"
			   ' Validate the entered character
			   If (Not Char.IsNumber(e.KeyChar)) Then

'				   #Region "Check If the user has entered Minus character"
				   ' Here we check if the user wants to enter the "-" character.
				   If Not((Me.Text.IndexOf("-"c) = -1) AndAlso (Me.SelectionStart = 0) AndAlso (_minimumAllowed < 0) AndAlso (e.KeyChar = "-"c)) Then ' the character entered was a Minus character
					   e.KeyChar = Char.MinValue
				   End If
'				   #End Region
			   End If
'			   #End Region

			   If _minimumAllowed <= 1 Then
'				   #Region "Checkinng if the value falles within the given range"
				   If e.KeyChar <> Char.MinValue Then
					   ' Create the string that will be displayed, and check whether it's valid or not.

					   ' Remove the selected character(s).
					   Dim newString As String = Me.Text.Remove(Me.SelectionStart, Me.SelectionLength)
					   ' Insert the new character.
					   newString = newString.Insert(Me.SelectionStart, e.KeyChar.ToString())
					   If (Not IsAllowed(newString)) Then
						   ' the new string is not valid, cancel the whole operation.
						   e.KeyChar = Char.MinValue
					   End If
				   End If
			   End If
'				   #End Region
		   End If
		   MyBase.OnKeyPress(e)
	   End Sub
   End Class
End Namespace
