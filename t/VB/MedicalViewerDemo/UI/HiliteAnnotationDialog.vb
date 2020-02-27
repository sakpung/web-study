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
   Partial Public Class HiliteAnnotationDialog : Inherits Form
      Private _hiliteAnnotation As MedicalViewerAnnotationHilite
      Private cell As MedicalViewerCell = Nothing
      Private viewer As MedicalViewer

      Public Sub New(ByVal owner As MainForm)
         InitializeComponent()

         cell = MainForm.DefaultCell
         viewer = owner.Viewer

         _cmbApplyTo.SelectedIndex = 0
         _hiliteAnnotation = CType(cell.GetActionProperties(MedicalViewerActionType.AnnotationHilite), MedicalViewerAnnotationHilite)
         _lblColor.BackColor = Color.FromArgb(&HFF, _hiliteAnnotation.AnnotationColor)
         _radCenter.Checked = _hiliteAnnotation.CreateFromCenter
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         _btnApply_Click(sender, e)
         Me.Close()
      End Sub

      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         _hiliteAnnotation.Flags = (CType(_cmbApplyTo.SelectedIndex, MedicalViewerAnnotationFlags))
         _hiliteAnnotation.CreateFromCenter = _radCenter.Checked
         _hiliteAnnotation.AnnotationColor = _lblColor.BackColor

         cell.SetActionProperties(MedicalViewerActionType.AnnotationHilite, _hiliteAnnotation)

         For Each viewerCell As MedicalViewerMultiCell In viewer.Cells
            viewerCell.SetActionProperties(MedicalViewerActionType.AnnotationHilite, _hiliteAnnotation)
         Next viewerCell
      End Sub

      Private Sub _btnColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnColor.Click
         MainForm.ShowColorDialog(_lblColor)
      End Sub
   End Class
End Namespace
