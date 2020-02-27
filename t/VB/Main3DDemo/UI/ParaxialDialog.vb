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

Imports Leadtools.Medical3D
Imports Leadtools.MedicalViewer

Namespace Main3DDemo
   Partial Public Class ParaxialDialog : Inherits Form
      Private oldLengthValue As Integer = 0
      Private oldDistanceValue As Integer = 0
      Private _cell As MedicalViewerParaxialCutCell


      Public Sub New(ByVal cell As MedicalViewerParaxialCutCell)
         InitializeComponent()

         _cell = cell

         oldLengthValue = CInt(_cell.ParaxialLength)
         oldDistanceValue = CInt(_cell.ParaxialDistance)
         _textBoxLength.Value = oldLengthValue
         _textBoxDistance.Value = oldDistanceValue
      End Sub

      Private Sub _btnReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnReset.Click
         _textBoxLength.Value = oldLengthValue
         _textBoxDistance.Value = oldDistanceValue
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         _cell.BeginUpdate()
         _cell.ParaxialLength = CSng(_textBoxLength.Value)
         _cell.ParaxialDistance = CSng(_textBoxDistance.Value)
         _cell.EndUpdate()
      End Sub
   End Class
End Namespace
