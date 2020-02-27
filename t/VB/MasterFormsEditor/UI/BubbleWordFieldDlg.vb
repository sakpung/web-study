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

Partial Public Class BubbleWordFieldDlg
   Inherits Form
   Private _mainForm As MainForm
   Private _bubbleWordField As BubbleWordField
   Private _oldName As String
   Private _removedObjects As List(Of SingleSelectionField)

   Public Sub New(mainForm As MainForm, bubbleWordField As BubbleWordField)
      InitializeComponent()

      _mainForm = mainForm
      _bubbleWordField = bubbleWordField
      _oldName = bubbleWordField.Name
      PopulateData()

      _lbSelection.SelectedIndex = 0
      _removedObjects = New List(Of SingleSelectionField)()
   End Sub

   Private Sub _btnOK_Click(sender As Object, e As EventArgs) Handles _btnOK.Click
      _bubbleWordField.Name = _tbName.Text

      If _rbCharacters.Checked Then
         _bubbleWordField.ValueType = BubbleWordValueType.Character
      Else
         _bubbleWordField.ValueType = BubbleWordValueType.Numerical
      End If

      For i As Integer = 0 To _bubbleWordField.Fields.Count - 1
         _bubbleWordField.Fields(i).Parent = _bubbleWordField.Name
      Next

      For i As Integer = 0 To _removedObjects.Count - 1
         _bubbleWordField.Fields.Remove(_removedObjects(i))
      Next

      _mainForm.UpdateBubbleWord(_oldName, _bubbleWordField)
   End Sub

   Private Sub PopulateData()
      If _bubbleWordField IsNot Nothing Then
         _tbName.Text = _bubbleWordField.Name

         For Each field As SingleSelectionField In _bubbleWordField.Fields
            _lbSelection.Items.Add(field.Name)
         Next

         If _bubbleWordField.ValueType = BubbleWordValueType.Character Then
            _rbCharacters.Checked = True
         Else
            _rbNumerical.Checked = True
         End If
      End If
   End Sub

   Private Sub _btnEdit_Click(sender As Object, e As EventArgs) Handles _btnEdit.Click
      Dim index As Integer = _lbSelection.SelectedIndex
      If index <> -1 Then
         Dim dlg As New SingleSelectionFieldDlg(_mainForm, _bubbleWordField.Fields(index))
         dlg.ShowDialog()
      End If
   End Sub

   Private Sub _btnRemove_Click(sender As Object, e As EventArgs) Handles _btnRemove.Click
      Dim index As Integer = _lbSelection.SelectedIndex
      If index <> -1 Then
         _removedObjects.Add(_bubbleWordField.Fields(index))
         _lbSelection.Items.RemoveAt(index)
      End If
   End Sub

   Private Shared Function GetAlphabets(fieldsCount As Integer) As List(Of String)
      Dim list As New List(Of String)()

      For i1 As Int16 = Convert.ToInt16("A"c) To Convert.ToInt16("Z"c)
         Dim c As Char = Convert.ToChar(i1)
         list.Add(c.ToString())
         If list.Count = fieldsCount Then
            Return list
         End If
      Next

      For i1 As Int16 = Convert.ToInt16("A"c) To Convert.ToInt16("Z"c)
         Dim c1 As Char = Convert.ToChar(i1)
         For i2 As Int16 = Convert.ToInt16("A"c) To Convert.ToInt16("Z"c)
            Dim c2 As Char = Convert.ToChar(i2)
            list.Add(c1.ToString() + c2.ToString())
            If list.Count = fieldsCount Then
               Return list
            End If
         Next
      Next

      For i1 As Int16 = Convert.ToInt16("A"c) To Convert.ToInt16("Z"c)
         Dim c1 As Char = Convert.ToChar(i1)
         For i2 As Int16 = Convert.ToInt16("A"c) To Convert.ToInt16("Z"c)
            Dim c2 As Char = Convert.ToChar(i2)
            For i3 As Int16 = Convert.ToInt16("A"c) To Convert.ToInt16("Z"c)
               Dim c3 As Char = Convert.ToChar(i3)
               list.Add(c1.ToString() + c2.ToString() + c3.ToString())
               If list.Count = fieldsCount Then
                  Return list
               End If
            Next
         Next
      Next

      Return list
   End Function

   Private Sub FillFieldsValues(field As SingleSelectionField, valueType As BubbleWordValueType)
      If valueType = BubbleWordValueType.Character Then
         Dim alphabets As List(Of String) = GetAlphabets(field.Fields.Count)

         For i As Integer = 0 To field.Fields.Count - 1
            Dim singleField As SingleField = field.Fields(i)
            singleField.FieldValue = alphabets(i)
            field.Fields(i) = singleField
         Next
      Else
         For i As Integer = 0 To field.Fields.Count - 1
            Dim singleField As SingleField = field.Fields(i)
            singleField.FieldValue = i.ToString()
            field.Fields(i) = singleField
         Next
      End If
   End Sub

   Private Sub _rbCharacters_CheckedChanged(sender As Object, e As EventArgs) Handles _rbCharacters.CheckedChanged
      If _rbCharacters.Checked Then
         For i As Integer = 0 To _bubbleWordField.Fields.Count - 1
            FillFieldsValues(_bubbleWordField.Fields(i), BubbleWordValueType.Character)
         Next
      End If
   End Sub

   Private Sub _rbNumerical_CheckedChanged(sender As Object, e As EventArgs) Handles _rbNumerical.CheckedChanged
      If _rbNumerical.Checked Then
         For i As Integer = 0 To _bubbleWordField.Fields.Count - 1
            FillFieldsValues(_bubbleWordField.Fields(i), BubbleWordValueType.Numerical)
         Next
      End If
   End Sub
End Class
