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

Imports Leadtools
Imports Leadtools.MedicalViewer

Namespace MedicalViewerDemo
   Partial Public Class AngleAnnotationDialog : Inherits Form
      Private _angleAnnotation As MedicalViewerAnnotationAngle
      Private cell As MedicalViewerMultiCell = Nothing
      Private viewer As MedicalViewer

      Public Sub New(ByVal owner As MainForm)
         InitializeComponent()

         cell = MainForm.DefaultCell
         viewer = owner.Viewer

         _angleAnnotation = CType(cell.GetActionProperties(MedicalViewerActionType.AnnotationAngle), MedicalViewerAnnotationAngle)
         _lblColor.BackColor = Color.FromArgb(&HFF, _angleAnnotation.AnnotationColor)
         _cmbApplyTo.SelectedIndex = CInt(_angleAnnotation.Flags)
      End Sub

      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         _angleAnnotation.Flags = (CType(_cmbApplyTo.SelectedIndex, MedicalViewerAnnotationFlags))
         _angleAnnotation.AnnotationColor = _lblColor.BackColor

         cell.SetActionProperties(MedicalViewerActionType.AnnotationAngle, _angleAnnotation)

         For Each viewerCell As MedicalViewerMultiCell In viewer.Cells
            viewerCell.SetActionProperties(MedicalViewerActionType.AnnotationAngle, _angleAnnotation)
         Next viewerCell
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         Me.Close()
         _btnApply_Click(sender, e)
      End Sub

      Private Sub _btnColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnColor.Click
         MainForm.ShowColorDialog(_lblColor)
      End Sub
   End Class
End Namespace
