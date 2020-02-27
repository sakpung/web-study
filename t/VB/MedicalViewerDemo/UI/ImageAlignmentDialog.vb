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
Imports Leadtools.ImageProcessing.Core

Namespace MedicalViewerDemo
   Partial Public Class ImageAlignmentDialog : Inherits Form
      Private _form As MainForm
      Public Options As RegistrationOptions
      Public OldOptions As RegistrationOptions

      Public Sub New(ByVal form As MainForm)
         _form = form
         InitializeComponent()
      End Sub

      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         _form.ApplyAlignment()
      End Sub

      Private Sub _btnReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnReset.Click
         _form.ResetAlignment()
         EnableApplyButton(False)
      End Sub

      Private Sub _bntCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _bntCancel.Click
         Me.Close()
      End Sub

      Private Sub ImageAlignmentDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         _form.FinishAlignment()
      End Sub

      Private Sub ImageAlignmentDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         _cbTransformation.SelectedIndex = 0
      End Sub

      Private Sub _cbTransformation_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cbTransformation.SelectedIndexChanged
         Dim type As Integer = _cbTransformation.SelectedIndex

         Select Case type
            Case 0
               Options = RegistrationOptions.Unknown
            Case 1
               Options = RegistrationOptions.XY
            Case 2
               Options = RegistrationOptions.RSXY
            Case 3
               Options = RegistrationOptions.Affine6
            Case 4
               Options = RegistrationOptions.Perspective
         End Select

         'if (_form.TemplateList.Count >= 1 && OldOptions != Options)
         '    EnableApplyButton(true);
         'else
         '    EnableApplyButton(false);
      End Sub

      Public Sub EnableApplyButton(ByVal Enable As Boolean)
         Me._btnApply.Enabled = Enable
      End Sub

   End Class
End Namespace
