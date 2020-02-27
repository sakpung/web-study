' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles
Imports System.Drawing
Imports System.ComponentModel

Namespace Dicom.UI
	Public Class SplitButton : Inherits Button
		Private _state As PushButtonState
		Private Const PushButtonWidth As Integer = 14
		Private Shared BorderSize As Integer = SystemInformation.Border3DSize.Width * 2
		Private skipNextOpen As Boolean = False
		Private dropDownRectangle As Rectangle = New Rectangle()
		Private showSplit_Renamed As Boolean = True

		Public Sub New()
			Me.AutoSize = True
		End Sub
		<DefaultValue(True)> _
		Public WriteOnly Property ShowSplit() As Boolean
			Set
				If Value <> showSplit_Renamed Then
					showSplit_Renamed = Value
					Invalidate()
					If Not Me.Parent Is Nothing Then
						Me.Parent.PerformLayout()
					End If
				End If
			End Set
		End Property

		Private Property State() As PushButtonState
			Get
				Return _state
			End Get
			Set
				If (Not _state.Equals(Value)) Then
					_state = Value
					Invalidate()
				End If
			End Set
		End Property

		Public Overrides Function GetPreferredSize(ByVal proposedSize As Size) As Size
			Dim preferredSize As Size = MyBase.GetPreferredSize(proposedSize)
			If showSplit_Renamed AndAlso (Not String.IsNullOrEmpty(Text)) AndAlso TextRenderer.MeasureText(Text, Font).Width + PushButtonWidth > preferredSize.Width Then
				Return preferredSize + New Size(PushButtonWidth + BorderSize * 2, 0)
			End If
			Return preferredSize
		End Function

		Protected Overrides Function IsInputKey(ByVal keyData As Keys) As Boolean
			If keyData.Equals(Keys.Down) AndAlso showSplit_Renamed Then
				Return True
			Else
				Return MyBase.IsInputKey(keyData)
			End If
		End Function

		Protected Overrides Sub OnEnabledChanged(ByVal e As EventArgs)
			If Enabled Then
				State = PushButtonState.Normal
			Else
				State = PushButtonState.Disabled
			End If

			MyBase.OnEnabledChanged(e)
		End Sub

		Protected Overrides Sub OnGotFocus(ByVal e As EventArgs)
			If (Not showSplit_Renamed) Then
				MyBase.OnGotFocus(e)
				Return
			End If

			If (Not State.Equals(PushButtonState.Pressed)) AndAlso (Not State.Equals(PushButtonState.Disabled)) Then
				State = PushButtonState.Default
			End If
		End Sub

		Protected Overrides Sub OnKeyDown(ByVal kevent As KeyEventArgs)
			If showSplit_Renamed Then
				If kevent.KeyCode.Equals(Keys.Down) Then
					ShowContextMenuStrip()
				ElseIf kevent.KeyCode.Equals(Keys.Space) AndAlso kevent.Modifiers = Keys.None Then
					State = PushButtonState.Pressed
				End If
			End If

			MyBase.OnKeyDown(kevent)
		End Sub

		Protected Overrides Sub OnKeyUp(ByVal kevent As KeyEventArgs)
			If kevent.KeyCode.Equals(Keys.Space) Then
				If Control.MouseButtons = MouseButtons.None Then
					State = PushButtonState.Normal
				End If
			End If
			MyBase.OnKeyUp(kevent)
		End Sub

		Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)
			If (Not showSplit_Renamed) Then
				MyBase.OnLostFocus(e)
				Return
			End If
			If (Not State.Equals(PushButtonState.Pressed)) AndAlso (Not State.Equals(PushButtonState.Disabled)) Then
				State = PushButtonState.Normal
			End If
		End Sub

		Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
			If (Not showSplit_Renamed) Then
				MyBase.OnMouseDown(e)
				Return
			End If

			If dropDownRectangle.Contains(e.Location) Then
				ShowContextMenuStrip()
			Else
				State = PushButtonState.Pressed
			End If
		End Sub

		Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
			If (Not showSplit_Renamed) Then
				MyBase.OnMouseEnter(e)
				Return
			End If

			If (Not State.Equals(PushButtonState.Pressed)) AndAlso (Not State.Equals(PushButtonState.Disabled)) Then
				State = PushButtonState.Hot
			End If
		End Sub

		Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
			If (Not showSplit_Renamed) Then
				MyBase.OnMouseLeave(e)
				Return
			End If

			If (Not State.Equals(PushButtonState.Pressed)) AndAlso (Not State.Equals(PushButtonState.Disabled)) Then
				If Focused Then
					State = PushButtonState.Default
				Else
					State = PushButtonState.Normal
				End If
			End If
		End Sub

		Protected Overrides Sub OnMouseUp(ByVal mevent As MouseEventArgs)
			If (Not showSplit_Renamed) Then
				MyBase.OnMouseUp(mevent)
				Return
			End If

			If ContextMenuStrip Is Nothing OrElse (Not ContextMenuStrip.Visible) Then
				SetButtonDrawState()
				If Bounds.Contains(Parent.PointToClient(Cursor.Position)) AndAlso (Not dropDownRectangle.Contains(mevent.Location)) Then
					OnClick(New EventArgs())
				End If
			End If
		End Sub

		Protected Overrides Sub OnPaint(ByVal pevent As PaintEventArgs)
			MyBase.OnPaint(pevent)

			If (Not showSplit_Renamed) Then
				Return
			End If

			Dim g As Graphics = pevent.Graphics
			Dim bounds As Rectangle = Me.ClientRectangle

			' draw the button background as according to the current state.
			If State <> PushButtonState.Pressed AndAlso IsDefault AndAlso (Not Application.RenderWithVisualStyles) Then
				Dim backgroundBounds As Rectangle = bounds
				backgroundBounds.Inflate(-1, -1)
				ButtonRenderer.DrawButton(g, backgroundBounds, State)

				' button renderer doesnt draw the black frame when themes are off =(
				g.DrawRectangle(SystemPens.WindowFrame, 0, 0, bounds.Width - 1, bounds.Height - 1)

			Else
				ButtonRenderer.DrawButton(g, bounds, State)
			End If
			' calculate the current dropdown rectangle.
			dropDownRectangle = New Rectangle(bounds.Right - PushButtonWidth - 1, BorderSize, PushButtonWidth, bounds.Height - BorderSize * 2)

			Dim internalBorder As Integer = BorderSize
			Dim focusRect As Rectangle = New Rectangle(internalBorder, internalBorder, bounds.Width - dropDownRectangle.Width - internalBorder, bounds.Height - (internalBorder * 2))

			Dim drawSplitLine As Boolean = (State = PushButtonState.Hot OrElse State = PushButtonState.Pressed OrElse (Not Application.RenderWithVisualStyles))

			If RightToLeft = RightToLeft.Yes Then
				dropDownRectangle.X = bounds.Left + 1
				focusRect.X = dropDownRectangle.Right
				If drawSplitLine Then
					' draw two lines at the edge of the dropdown button
					g.DrawLine(SystemPens.ButtonShadow, bounds.Left + PushButtonWidth, BorderSize, bounds.Left + PushButtonWidth, bounds.Bottom - BorderSize)
					g.DrawLine(SystemPens.ButtonFace, bounds.Left + PushButtonWidth + 1, BorderSize, bounds.Left + PushButtonWidth + 1, bounds.Bottom - BorderSize)
				End If
			Else
				If drawSplitLine Then
					' draw two lines at the edge of the dropdown button
					g.DrawLine(SystemPens.ButtonShadow, bounds.Right - PushButtonWidth, BorderSize, bounds.Right - PushButtonWidth, bounds.Bottom - BorderSize)
					g.DrawLine(SystemPens.ButtonFace, bounds.Right - PushButtonWidth - 1, BorderSize, bounds.Right - PushButtonWidth - 1, bounds.Bottom - BorderSize)
				End If

			End If

			' Draw an arrow in the correct location 
			PaintArrow(g, dropDownRectangle)

			' Figure out how to draw the text
			Dim formatFlags As TextFormatFlags = TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter

			' If we dont' use mnemonic, set formatFlag to NoPrefix as this will show ampersand.
			If (Not UseMnemonic) Then
				formatFlags = formatFlags Or TextFormatFlags.NoPrefix
			ElseIf (Not ShowKeyboardCues) Then
				formatFlags = formatFlags Or TextFormatFlags.HidePrefix
			End If

			If (Not String.IsNullOrEmpty(Me.Text)) Then
				If Enabled Then
					TextRenderer.DrawText(g, Text, Font, focusRect, SystemColors.ControlText, formatFlags)
				Else
					ControlPaint.DrawStringDisabled(g, Text, Font, BackColor, focusRect, formatFlags)
				End If
			End If

			' draw the focus rectangle.

			If State <> PushButtonState.Pressed AndAlso Focused Then
				ControlPaint.DrawFocusRectangle(g, focusRect)
			End If
		End Sub

		Private Sub PaintArrow(ByVal g As Graphics, ByVal dropDownRect As Rectangle)
			Dim middle As Point = New Point(Convert.ToInt32(dropDownRect.Left + dropDownRect.Width / 2), Convert.ToInt32(dropDownRect.Top + dropDownRect.Height / 2))

			'if the width is odd - favor pushing it over one pixel right.
			middle.X += (dropDownRect.Width Mod 2)

			Dim arrow As Point() = New Point() { New Point(middle.X - 2, middle.Y - 1), New Point(middle.X + 3, middle.Y - 1), New Point(middle.X, middle.Y + 2) }

			g.FillPolygon(SystemBrushes.ControlText, arrow)
		End Sub

		Private Sub ShowContextMenuStrip()
			If skipNextOpen Then
				' we were called because we're closing the context menu strip
				' when clicking the dropdown button.
				skipNextOpen = False
				Return
			End If
			State = PushButtonState.Pressed

			If Not ContextMenuStrip Is Nothing Then
				AddHandler ContextMenuStrip.Closing, AddressOf ContextMenuStrip_Closing
				ContextMenuStrip.Show(Me, New Point(0, Height), ToolStripDropDownDirection.BelowRight)
			End If
		End Sub

		Private Sub ContextMenuStrip_Closing(ByVal sender As Object, ByVal e As ToolStripDropDownClosingEventArgs)
			Dim cms As ContextMenuStrip = TryCast(sender, ContextMenuStrip)
			If Not cms Is Nothing Then
				RemoveHandler cms.Closing, AddressOf ContextMenuStrip_Closing
			End If

			SetButtonDrawState()

			If e.CloseReason = ToolStripDropDownCloseReason.AppClicked Then
				skipNextOpen = (dropDownRectangle.Contains(Me.PointToClient(Cursor.Position)))
			End If
		End Sub


		Private Sub SetButtonDrawState()
			If Bounds.Contains(Parent.PointToClient(Cursor.Position)) Then
				State = PushButtonState.Hot
			ElseIf Focused Then
				State = PushButtonState.Default
			Else
				State = PushButtonState.Normal
			End If
		End Sub
	End Class

End Namespace


