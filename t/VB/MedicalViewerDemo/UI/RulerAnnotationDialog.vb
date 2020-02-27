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
   Partial Public Class RulerAnnotationDialog : Inherits Form
      Private _rulerAnnotation As MedicalViewerAnnotationRuler
      Private cell As MedicalViewerMultiCell = Nothing
      Private viewer As MedicalViewer

      Public Sub New(ByVal owner As MainForm)
         InitializeComponent()

         cell = MainForm.DefaultCell
         viewer = owner.Viewer

         _rulerAnnotation = CType(cell.GetActionProperties(MedicalViewerActionType.AnnotationRuler), MedicalViewerAnnotationRuler)
         _lblColor.BackColor = Color.FromArgb(&HFF, _rulerAnnotation.AnnotationColor)
         _cmbApplyTo.SelectedIndex = CInt(_rulerAnnotation.Flags)
         _chkSimpleRuler.Checked = _rulerAnnotation.SimpleRuler
      End Sub

      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         _rulerAnnotation.Flags = (CType(_cmbApplyTo.SelectedIndex, MedicalViewerAnnotationFlags))
         _rulerAnnotation.SimpleRuler = _chkSimpleRuler.Checked
         _rulerAnnotation.AnnotationColor = _lblColor.BackColor

         cell.SetActionProperties(MedicalViewerActionType.AnnotationRuler, _rulerAnnotation)

         For Each viewerCell As MedicalViewerMultiCell In viewer.Cells
            viewerCell.SetActionProperties(MedicalViewerActionType.AnnotationRuler, _rulerAnnotation)
         Next viewerCell
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         _btnApply_Click(sender, e)
         Me.Close()
      End Sub

      Private Sub _btnColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnColor.Click
         MainForm.ShowColorDialog(_lblColor)
      End Sub
   End Class
End Namespace
