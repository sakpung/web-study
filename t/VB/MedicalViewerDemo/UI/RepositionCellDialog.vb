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
   Partial Public Class RepositionCellDialog : Inherits Form
      Public Sub New(ByVal owner As MainForm)
         InitializeComponent()

         _txtCellIndex.MaximumAllowed = owner.Viewer.Cells.Count - 1
         _txtTargetIndex.MaximumAllowed = owner.Viewer.Cells.Count - 1
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         CType(Me.Owner, MainForm).Viewer.Cells.Reposition(_txtCellIndex.Value, _txtTargetIndex.Value, _chkSwap.Checked)
      End Sub
   End Class
End Namespace
