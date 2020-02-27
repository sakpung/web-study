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
   Partial Public Class RectangleAnnotationDialog : Inherits Form
      Private _rectangleAnnotation As MedicalViewerAnnotationRectangle
      Private cell As MedicalViewerCell = Nothing
      Private viewer As MedicalViewer

      Public Sub New(ByVal owner As MainForm)
         InitializeComponent()

         cell = MainForm.DefaultCell
         viewer = owner.Viewer

         _cmbApplyTo.SelectedIndex = 0
         _rectangleAnnotation = CType(cell.GetActionProperties(MedicalViewerActionType.AnnotationRectangle), MedicalViewerAnnotationRectangle)
         _lblColor.BackColor = Color.FromArgb(&HFF, _rectangleAnnotation.AnnotationColor)
         _radCenter.Checked = _rectangleAnnotation.CreateFromCenter
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         _btnApply_Click(sender, e)
         Me.Close()
      End Sub

      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         _rectangleAnnotation.Flags = (CType(_cmbApplyTo.SelectedIndex, MedicalViewerAnnotationFlags))
         _rectangleAnnotation.CreateFromCenter = _radCenter.Checked
         _rectangleAnnotation.AnnotationColor = _lblColor.BackColor

         cell.SetActionProperties(MedicalViewerActionType.AnnotationRectangle, _rectangleAnnotation)

         For Each viewerCell As MedicalViewerMultiCell In viewer.Cells
            viewerCell.SetActionProperties(MedicalViewerActionType.AnnotationRectangle, _rectangleAnnotation)
         Next viewerCell
      End Sub

      Private Sub _btnColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnColor.Click
         MainForm.ShowColorDialog(_lblColor)
      End Sub
   End Class
End Namespace
