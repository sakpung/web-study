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
   Partial Public Class ArrowAnnotationDialog : Inherits Form
      Private _arrowAnnotation As MedicalViewerAnnotationArrow
      Private cell As MedicalViewerCell = Nothing
      Private viewer As MedicalViewer

      Public Sub New(ByVal owner As MainForm)
         InitializeComponent()

         cell = MainForm.DefaultCell
         viewer = owner.Viewer

         _arrowAnnotation = CType(cell.GetActionProperties(MedicalViewerActionType.AnnotationArrow), MedicalViewerAnnotationArrow)
         _lblColor.BackColor = Color.FromArgb(&HFF, _arrowAnnotation.AnnotationColor)
         _cmbApplyTo.SelectedIndex = CInt(_arrowAnnotation.Flags)

      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         _btnApply_Click(sender, e)
         Me.Close()
      End Sub

      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         _arrowAnnotation.Flags = (CType(_cmbApplyTo.SelectedIndex, MedicalViewerAnnotationFlags))
         _arrowAnnotation.AnnotationColor = _lblColor.BackColor

         'int cellIndex = owner.SearchForFirstSelected();
         cell = MainForm.DefaultCell '(MedicalViewerMultiCell)owner.Viewer.Cells[cellIndex];

         cell.SetActionProperties(MedicalViewerActionType.AnnotationArrow, _arrowAnnotation)

         For Each viewerCell As MedicalViewerMultiCell In viewer.Cells
            viewerCell.SetActionProperties(MedicalViewerActionType.AnnotationArrow, _arrowAnnotation)
         Next viewerCell
      End Sub

      Private Sub _btnColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnColor.Click
         MainForm.ShowColorDialog(_lblColor)
      End Sub
   End Class
End Namespace
