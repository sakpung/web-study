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
   Partial Public Class NudgeShrinkToolDialog : Inherits Form
      Private viewer As MedicalViewer
      Private _shapeNudgeType As MedicalViewerNudgeToolShape
      Private _shapeShrinkType As MedicalViewerNudgeToolShape
      Private cell As MedicalViewerCell = Nothing

      Public Property NudgeType() As MedicalViewerNudgeToolShape
         Get
            If _rdoNudgeRectangle.Checked Then
               Return MedicalViewerNudgeToolShape.Rectangle
            End If
            If _rdoNudgeEllipse.Checked Then
               Return MedicalViewerNudgeToolShape.Ellipse
            End If
            If _rdoNudgeSlash.Checked Then
               Return MedicalViewerNudgeToolShape.Slash
            End If

            Return MedicalViewerNudgeToolShape.BackSlash
         End Get

         Set(value As MedicalViewerNudgeToolShape)
            _shapeNudgeType = Value
            If Value = MedicalViewerNudgeToolShape.Rectangle Then
               _rdoNudgeRectangle.Checked = True
            End If
            If Value = MedicalViewerNudgeToolShape.Ellipse Then
               _rdoNudgeEllipse.Checked = True
            End If
            If Value = MedicalViewerNudgeToolShape.Slash Then
               _rdoNudgeSlash.Checked = True
            End If
            If Value = MedicalViewerNudgeToolShape.BackSlash Then
               _rdoNudgeBackSlash.Checked = True
            End If
         End Set
      End Property

      Public Property ShrinkType() As MedicalViewerNudgeToolShape
         Get
            If _rdoShrinkRectangle.Checked Then
               Return MedicalViewerNudgeToolShape.Rectangle
            End If
            If _rdoShrinkEllipse.Checked Then
               Return MedicalViewerNudgeToolShape.Ellipse
            End If
            If _rdoShrinkSlash.Checked Then
               Return MedicalViewerNudgeToolShape.Slash
            End If

            Return MedicalViewerNudgeToolShape.BackSlash
         End Get

         Set(value As MedicalViewerNudgeToolShape)
            _shapeShrinkType = Value
            If Value = MedicalViewerNudgeToolShape.Rectangle Then
               _rdoShrinkRectangle.Checked = True
            End If
            If Value = MedicalViewerNudgeToolShape.Ellipse Then
               _rdoShrinkEllipse.Checked = True
            End If
            If Value = MedicalViewerNudgeToolShape.Slash Then
               _rdoShrinkSlash.Checked = True
            End If
            If Value = MedicalViewerNudgeToolShape.BackSlash Then
               _rdoShrinkBackSlash.Checked = True
            End If
         End Set
      End Property

      Public Sub New(ByVal owner As MainForm)
         InitializeComponent()

         cell = MainForm.DefaultCell
         viewer = owner.Viewer

         Dim nudgeToolProperties As MedicalViewerNudgeTool = CType(cell.GetActionProperties(MedicalViewerActionType.NudgeTool), MedicalViewerNudgeTool)

         _txtNudgeHeight.Text = nudgeToolProperties.Height.ToString()
         _txtNudgeWidth.Text = nudgeToolProperties.Width.ToString()
         NudgeType = nudgeToolProperties.Shape

         nudgeToolProperties = CType(cell.GetActionProperties(MedicalViewerActionType.ShrinkTool), MedicalViewerNudgeTool)

         _txtShrinkHeight.Text = nudgeToolProperties.Height.ToString()
         _txtShrinkWidth.Text = nudgeToolProperties.Width.ToString()
         ShrinkType = nudgeToolProperties.Shape
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         Dim nudgeToolProperties As MedicalViewerNudgeTool = CType(cell.GetActionProperties(MedicalViewerActionType.NudgeTool), MedicalViewerNudgeTool)

         nudgeToolProperties.Width = Convert.ToInt32(_txtNudgeWidth.Text)
         nudgeToolProperties.Height = Convert.ToInt32(_txtNudgeHeight.Text)
         nudgeToolProperties.Shape = NudgeType

         cell.SetActionProperties(MedicalViewerActionType.NudgeTool, nudgeToolProperties)

         For Each viewerCell As MedicalViewerMultiCell In viewer.Cells
            viewerCell.SetActionProperties(MedicalViewerActionType.NudgeTool, nudgeToolProperties)
         Next viewerCell



         nudgeToolProperties = CType(cell.GetActionProperties(MedicalViewerActionType.ShrinkTool), MedicalViewerNudgeTool)

         nudgeToolProperties.Width = Convert.ToInt32(_txtShrinkWidth.Text)
         nudgeToolProperties.Height = Convert.ToInt32(_txtShrinkHeight.Text)
         nudgeToolProperties.Shape = ShrinkType

         cell.SetActionProperties(MedicalViewerActionType.ShrinkTool, nudgeToolProperties)

         For Each viewerCell As MedicalViewerMultiCell In viewer.Cells
            viewerCell.SetActionProperties(MedicalViewerActionType.ShrinkTool, nudgeToolProperties)
         Next viewerCell

         Me.Close()
      End Sub

   End Class
End Namespace
