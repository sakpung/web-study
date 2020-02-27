
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

Partial Public Class OmrDateFieldDlg
   Inherits Form
   Private _mainForm As MainForm
   Private _omrDateField As OmrDateField
   Private _oldName As String
   Private _removedObjects As List(Of SingleSelectionField)

   Public Sub New(mainForm As MainForm, omrDateField As OmrDateField)
      InitializeComponent()

      _mainForm = mainForm
      _omrDateField = omrDateField
      _oldName = omrDateField.Name
      PopulateData()

      _lbSelection.SelectedIndex = 0
      _removedObjects = New List(Of SingleSelectionField)()
   End Sub

   Private Sub _btnOK_Click(sender As Object, e As EventArgs) Handles _btnOK.Click
      _omrDateField.Name = _tbName.Text
      _mainForm.UpdateOmrDateField(_oldName, _omrDateField)
   End Sub

   Private Sub PopulateData()
      If _omrDateField IsNot Nothing Then
         _tbName.Text = _omrDateField.Name

         _lbSelection.Items.Add(IndexToField(0).Name)
         _lbSelection.Items.Add("Day Field: " + IndexToField(1).Name)
         _lbSelection.Items.Add("Day Field: " + IndexToField(2).Name)
         _lbSelection.Items.Add("Year Field: " + IndexToField(3).Name)

         _lbSelection.Items.Add("Year Field: " + IndexToField(4).Name)
      End If
   End Sub

   Private Function IndexToField(index As Integer) As SingleSelectionField
      Select Case index
         Case 0
            Return _omrDateField.MonthField
         Case 1
            Return _omrDateField.DayField.Fields(0)
         Case 2
            Return _omrDateField.DayField.Fields(1)
         Case 3
            Return _omrDateField.YearField.Fields(0)
         Case 4
            Return _omrDateField.YearField.Fields(1)
      End Select

      Return Nothing
   End Function

   Private Sub _btnEdit_Click(sender As Object, e As EventArgs) Handles _btnEdit.Click
      Dim index As Integer = _lbSelection.SelectedIndex

      If index <> -1 Then
         Dim dlg As New SingleSelectionFieldDlg(_mainForm, IndexToField(index))
         dlg.ShowDialog()
      End If
   End Sub
End Class