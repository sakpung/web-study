' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Drawing
Imports System.Windows.Forms

Namespace MPPSWCFDemo.UI
	Public NotInheritable Class PaintUtils
		Private Sub New()
		End Sub
		Public Shared Sub HighlightRequiredFields(ByVal container As Control, ByVal graphics As Graphics, ByVal isVisible As Boolean, ByVal highlight As Color)
			Dim rect As Rectangle = Nothing
			For Each control As Control In container.Controls
				If TypeOf control.Tag Is String AndAlso control.Tag.ToString().ToLower() = "required" Then
					rect = control.Bounds
					rect.Inflate(1, 1)
					If isVisible Then
						ControlPaint.DrawBorder(graphics, rect, highlight, ButtonBorderStyle.Solid)
					Else
						ControlPaint.DrawBorder(graphics, rect, container.BackColor, ButtonBorderStyle.None)
					End If
				End If

				If control.HasChildren Then
					For Each ctrl As Control In control.Controls
						HighlightRequiredFields(ctrl, graphics, isVisible, highlight)
					Next ctrl
				End If
			Next control

		End Sub
	End Class
End Namespace
