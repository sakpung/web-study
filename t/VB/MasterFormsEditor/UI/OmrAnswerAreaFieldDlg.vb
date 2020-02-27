
' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Forms.Processing
Imports System

Partial Public Class OmrAnswerAreaFieldDlg
   Inherits Form
   Private _mainForm As MainForm
   Private _omrAnswerAreaField As OmrAnswerAreaField
   Private _oldName As String
   Private _removedObjects As List(Of SingleSelectionField)

   Public Sub New(mainForm As MainForm, omrAnswerAreaField As OmrAnswerAreaField)
      InitializeComponent()

      _mainForm = mainForm
      _omrAnswerAreaField = omrAnswerAreaField
      _oldName = omrAnswerAreaField.Name
      PopulateData()

      _lbSelection.SelectedIndex = 0
      _removedObjects = New List(Of SingleSelectionField)()
   End Sub

   Private Sub _btnOK_Click(sender As Object, e As EventArgs) Handles _btnOK.Click
      _omrAnswerAreaField.Name = _tbName.Text

      For i As Integer = 0 To _omrAnswerAreaField.Answers.Count - 1
         _omrAnswerAreaField.Answers(i).Parent = _omrAnswerAreaField.Name
      Next

      For i As Integer = 0 To _removedObjects.Count - 1
         _omrAnswerAreaField.Answers.Remove(_removedObjects(i))
      Next

      If Not _oldName.Equals(_omrAnswerAreaField.Name) Then
         _mainForm.UpdateOmrAnswerArea(_oldName, _omrAnswerAreaField)
      End If
   End Sub

   Private Sub PopulateData()
      If _omrAnswerAreaField IsNot Nothing Then
         _tbName.Text = _omrAnswerAreaField.Name

         For Each field As SingleSelectionField In _omrAnswerAreaField.Answers
            _lbSelection.Items.Add(field.Name)
         Next
      End If
   End Sub

   Private Sub _btnEdit_Click(sender As Object, e As EventArgs) Handles _btnEdit.Click
      Dim index As Integer = _lbSelection.SelectedIndex
      If index <> -1 Then
         Dim dlg As New SingleSelectionFieldDlg(_mainForm, _omrAnswerAreaField.Answers(index))
         dlg.ShowDialog()
      End If
   End Sub

   Private Sub _btnRemove_Click(sender As Object, e As EventArgs) Handles _btnRemove.Click
      Dim index As Integer = _lbSelection.SelectedIndex
      If index <> -1 Then
         _removedObjects.Add(_omrAnswerAreaField.Answers(index))
         _lbSelection.Items.RemoveAt(index)
      End If
   End Sub
End Class