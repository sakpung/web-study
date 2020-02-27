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
   Partial Public Class TextAnnotationDialog : Inherits Form
      Private _textAnnotation As MedicalViewerAnnotationText
      Private _cell As MedicalViewerCell
      Private _viewer As MedicalViewer

      Public Sub New(ByVal owner As MainForm)
         InitializeComponent()

         _cell = MainForm.DefaultCell
         _viewer = owner.Viewer

         If _viewer.Cells.Count = 0 Then
            _textAnnotation = CType(_cell.GetActionProperties(MedicalViewerActionType.AnnotationText), MedicalViewerAnnotationText)
         Else
            _textAnnotation = CType(_viewer.Cells(0).GetActionProperties(MedicalViewerActionType.AnnotationText), MedicalViewerAnnotationText)
         End If

         _lblColor.BackColor = Color.FromArgb(&HFF, _textAnnotation.AnnotationColor)
         _textAnnotation.TextColor = Color.FromArgb(&HFF, _textAnnotation.TextColor)
         _cmbApplyTo.SelectedIndex = CInt(_textAnnotation.Flags)
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         Me.Close()
         _btnApply_Click(sender, e)
      End Sub

      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         _textAnnotation.Flags = (CType(_cmbApplyTo.SelectedIndex, MedicalViewerAnnotationFlags))
         _textAnnotation.AnnotationColor = _lblColor.BackColor
         _textAnnotation.TextColor = _lblColor.BackColor

         _cell.SetActionProperties(MedicalViewerActionType.AnnotationText, _textAnnotation)

         For Each viewerCell As MedicalViewerMultiCell In _viewer.Cells
            viewerCell.SetActionProperties(MedicalViewerActionType.AnnotationText, _textAnnotation)
         Next viewerCell
      End Sub

      Private Sub _btnColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnColor.Click
         MainForm.ShowColorDialog(_lblColor)
      End Sub
   End Class
End Namespace
