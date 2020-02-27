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
Imports System

Partial Public Class RenameOmrFieldsDlg
   Inherits Form
   Private _sampleName As String
   Private _mainForm As MainForm
   Private _omrFieldsCount As Integer
   Private _generatedNewNames As List(Of String)
   Private _alphabets As List(Of String)

   Public Sub New(mainForm As MainForm, omrFieldsCount As Integer)
      InitializeComponent()

      _omrFieldsCount = omrFieldsCount
      _mainForm = mainForm
      _generatedNewNames = New List(Of String)()
      _alphabets = GetAlphabets(omrFieldsCount)

      UpdateNames()

      Me.ActiveControl = _txtPrefix
   End Sub

   Public Shared Function GetAlphabets(fieldsCount As Integer) As List(Of String)
      Dim list As New List(Of String)()
      For i As Int16 = Convert.ToInt16("A"c) To Convert.ToInt16("Z"c)
         Dim c As Char = Convert.ToChar(i)
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

   Private Sub UpdateNames()
      If _generatedNewNames IsNot Nothing Then
         _generatedNewNames.Clear()
      End If

      _sampleName = _txtPrefix.Text

      If _rbNum1.Checked Then
         _numStartsWith.Enabled = False
         _sampleName += "1"

         For i As Integer = 1 To _omrFieldsCount
            Dim fieldName As String = _txtPrefix.Text + i.ToString()
            _generatedNewNames.Add(fieldName)
         Next
      ElseIf _rbAlpha.Checked Then
         _numStartsWith.Enabled = False
         _sampleName += "A"

         For i As Integer = 0 To _omrFieldsCount - 1
            Dim fieldName As String = _txtPrefix.Text + _alphabets(i)

            _generatedNewNames.Add(fieldName)
         Next
      Else
         _numStartsWith.Enabled = True
         _sampleName += _numStartsWith.Value.ToString()
         For i As Integer = Decimal.ToInt32(_numStartsWith.Value) To Decimal.ToInt32(_numStartsWith.Value) + _omrFieldsCount
            Dim fieldName As String = _txtPrefix.Text + i.ToString()
            _generatedNewNames.Add(fieldName)
         Next
      End If

      _lblName.Text = _sampleName
   End Sub

   Private Sub _txtPrefix_TextChanged(sender As Object, e As EventArgs) Handles _txtPrefix.TextChanged
      UpdateNames()
   End Sub

   Private Sub _rb_CheckedChanged(sender As Object, e As EventArgs) Handles _rbStartsWith.CheckedChanged, _rbNum1.CheckedChanged, _rbAlpha.CheckedChanged
      UpdateNames()
   End Sub

   Private Sub _btnOK_Click(sender As Object, e As EventArgs) Handles _btnOK.Click
      _mainForm.ApplyRenameMultipleFields(_generatedNewNames)
      Me.Close()
   End Sub

   Private Sub _btnCancel_Click(sender As Object, e As EventArgs) Handles _btnCancel.Click
      Me.Close()
   End Sub

   Private Sub _numStartsWith_ValueChanged(sender As Object, e As EventArgs) Handles _numStartsWith.ValueChanged
      UpdateNames()
   End Sub
End Class
