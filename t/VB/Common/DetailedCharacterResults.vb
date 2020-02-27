' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Forms.Recognition
Imports Leadtools.Forms.Processing

Partial Public Class DetailedCharacterResults : Inherits Form
   Public Sub New(ByVal field As FormField)
      InitializeComponent()

      If TypeOf field Is TextFormField Then
         Dim i As Integer = 0
         Do While i < (TryCast((TryCast(field, TextFormField)).Result, TextFormFieldResult)).Characters.Count
            Dim row As String() = New String(4) {}
            row(0) = (TryCast((TryCast(field, TextFormField)).Result, TextFormFieldResult)).Characters(i).Code.ToString()
            row(1) = (TryCast((TryCast(field, TextFormField)).Result, TextFormFieldResult)).Characters(i).GuessCode2.ToString()
            row(2) = (TryCast((TryCast(field, TextFormField)).Result, TextFormFieldResult)).Characters(i).FontStyle.ToString()
            row(3) = (TryCast((TryCast(field, TextFormField)).Result, TextFormFieldResult)).Characters(i).FontSize.ToString()
            row(4) = (TryCast((TryCast(field, TextFormField)).Result, TextFormFieldResult)).Characters(i).Bounds.ToString()
            _charResults.Rows.Add(row)
            i += 1
         Loop
      ElseIf TypeOf field Is UnStructuredTextFormField Then
         Dim i As Integer = 0
         Do While i < (TryCast((TryCast(field, UnStructuredTextFormField)).Result, TextFormFieldResult)).Characters.Count
            Dim row As String() = New String(4) {}
            row(0) = (TryCast((TryCast(field, UnStructuredTextFormField)).Result, TextFormFieldResult)).Characters(i).Code.ToString()
            row(1) = (TryCast((TryCast(field, UnStructuredTextFormField)).Result, TextFormFieldResult)).Characters(i).GuessCode2.ToString()
            row(2) = (TryCast((TryCast(field, UnStructuredTextFormField)).Result, TextFormFieldResult)).Characters(i).FontStyle.ToString()
            row(3) = (TryCast((TryCast(field, UnStructuredTextFormField)).Result, TextFormFieldResult)).Characters(i).FontSize.ToString()
            row(4) = (TryCast((TryCast(field, UnStructuredTextFormField)).Result, TextFormFieldResult)).Characters(i).Bounds.ToString()
            _charResults.Rows.Add(row)
            i += 1
         Loop
      ElseIf TypeOf field Is OmrFormField Then
         Dim i As Integer = 0
         Do While i < (TryCast((TryCast(field, OmrFormField)).Result, OmrFormFieldResult)).Characters.Count
            Dim row As String() = New String(4) {}
            row(0) = (TryCast((TryCast(field, OmrFormField)).Result, OmrFormFieldResult)).Characters(i).Code.ToString()
            row(1) = (TryCast((TryCast(field, OmrFormField)).Result, OmrFormFieldResult)).Characters(i).GuessCode2.ToString()
            row(2) = (TryCast((TryCast(field, OmrFormField)).Result, OmrFormFieldResult)).Characters(i).FontStyle.ToString()
            row(3) = (TryCast((TryCast(field, OmrFormField)).Result, OmrFormFieldResult)).Characters(i).FontSize.ToString()
            row(4) = (TryCast((TryCast(field, OmrFormField)).Result, OmrFormFieldResult)).Characters(i).Bounds.ToString()
            _charResults.Rows.Add(row)
            i += 1
         Loop
      End If
   End Sub

   Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
      DialogResult = System.Windows.Forms.DialogResult.OK
   End Sub
End Class
