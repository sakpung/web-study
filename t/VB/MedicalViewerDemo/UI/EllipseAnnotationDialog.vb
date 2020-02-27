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
   Partial Public Class EllipseAnnotationDialog : Inherits Form
      Private _ellipseAnnotation As MedicalViewerAnnotationEllipse

      Private cell As MedicalViewerMultiCell = Nothing
      Private viewer As MedicalViewer

      Public Sub New(ByVal owner As MainForm)
         InitializeComponent()
         Dim cellIndex As Integer = owner.SearchForFirstSelected()
         cell = MainForm.DefaultCell '(MedicalViewerMultiCell)owner.Viewer.Cells[cellIndex];
         viewer = owner.Viewer

         _cmbApplyTo.SelectedIndex = 0
         _ellipseAnnotation = CType(cell.GetActionProperties(MedicalViewerActionType.AnnotationEllipse), MedicalViewerAnnotationEllipse)
         _lblColor.BackColor = Color.FromArgb(&HFF, _ellipseAnnotation.AnnotationColor)
         _radCenter.Checked = _ellipseAnnotation.CreateFromCenter
      End Sub

      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         _ellipseAnnotation.Flags = (CType(_cmbApplyTo.SelectedIndex, MedicalViewerAnnotationFlags))
         _ellipseAnnotation.CreateFromCenter = _radCenter.Checked
         _ellipseAnnotation.AnnotationColor = _lblColor.BackColor

         cell.SetActionProperties(MedicalViewerActionType.AnnotationEllipse, _ellipseAnnotation)

         For Each viewerCell As MedicalViewerMultiCell In viewer.Cells
            viewerCell.SetActionProperties(MedicalViewerActionType.AnnotationEllipse, _ellipseAnnotation)
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
