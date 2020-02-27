' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.MedicalViewer

Namespace MedicalViewerLayoutDemo
   Public Partial Class NudgeToolDialog : Inherits Form
	  Private _type As MedicalViewerActionType

	  Private _shapeType As MedicalViewerNudgeToolShape
	  Public Property Type() As MedicalViewerNudgeToolShape
		 Get
			If _rdoRectangle.Checked Then
			   Return MedicalViewerNudgeToolShape.Rectangle
			End If
			If _rdoEllipse.Checked Then
			   Return MedicalViewerNudgeToolShape.Ellipse
			End If
			If _rdoSlash.Checked Then
			   Return MedicalViewerNudgeToolShape.Slash
			End If

			Return MedicalViewerNudgeToolShape.BackSlash
		 End Get

		 Set
			_shapeType = Value
			If Value = MedicalViewerNudgeToolShape.Rectangle Then
			   _rdoRectangle.Checked = True
			End If
			If Value = MedicalViewerNudgeToolShape.Ellipse Then
			   _rdoEllipse.Checked = True
			End If
			If Value = MedicalViewerNudgeToolShape.Slash Then
			   _rdoSlash.Checked = True
			End If
			If Value = MedicalViewerNudgeToolShape.BackSlash Then
			   _rdoBackSlash.Checked = True
			End If
		 End Set
	  End Property

	  Public Sub New(ByVal owner As MainForm, ByVal actionType As MedicalViewerActionType)
		 InitializeComponent()
		 _type = actionType
            If _type = MedicalViewerActionType.ShrinkTool Then
                Text = "Shrink Tool Dialog"
            Else
                Text = "Nudge Tool Dialog"
            End If

		 Dim nudgeToolProperties As MedicalViewerNudgeTool = CType(owner.Viewer.GetActionProperties(_type), MedicalViewerNudgeTool)

		 _txtHeight.Text = nudgeToolProperties.Height.ToString()
		 _txtWidth.Text = nudgeToolProperties.Width.ToString()
		 Type = nudgeToolProperties.Shape
	  End Sub

	  Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
		 Dim nudgeToolProperties As MedicalViewerNudgeTool = CType((CType(Me.Owner, MainForm)).Viewer.GetActionProperties(_type), MedicalViewerNudgeTool)

		 nudgeToolProperties.Width = Convert.ToInt32(_txtWidth.Text)
		 nudgeToolProperties.Height = Convert.ToInt32(_txtHeight.Text)
		 nudgeToolProperties.Shape = Type

		 CType(Me.Owner, MainForm).Viewer.SetActionProperties(_type, nudgeToolProperties)

		 Me.Close()
	  End Sub

   End Class
End Namespace
