' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools.Forms.Processing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System

Public Class DetailedTableResults
   Private _table As TableFormField

   Public Sub New(table As TableFormField)
      _table = table
      InitializeComponent()
      _tableResults.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
      For Each column As TableColumn In _table.Columns
         Dim index As Integer = _tableResults.Columns.Add(column.OcrField.Name, column.OcrField.Name)
         If column.Alignment = FieldAlignment.Left Then
            _tableResults.Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
         ElseIf column.Alignment = FieldAlignment.Right Then
            _tableResults.Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         ElseIf column.Alignment = FieldAlignment.Center Then
            _tableResults.Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
         End If
      Next

      Dim results As TableFormFieldResult = TryCast(table.Result, TableFormFieldResult)
      If results IsNot Nothing Then
         For i As Integer = 0 To results.Rows.Count - 1
            Dim row As TableFormRow = results.Rows(i)
            _tableResults.Rows.Add()

            Dim lineCounter As Integer = 1
            For j As Integer = 0 To row.Fields.Count - 1
               Dim ocrField As OcrFormField = row.Fields(j)
               If TypeOf ocrField Is TextFormField Then
                  Dim txtResults As TextFormFieldResult = TryCast(ocrField.Result, TextFormFieldResult)
                  _tableResults.Rows(i).Cells(j).Value = txtResults.Text
                  Dim counter As Integer = 1

                  If txtResults.Text IsNot Nothing Then
                     counter += CountCharacterInString(txtResults.Text, ControlChars.Lf)
                  End If

                  If counter > lineCounter Then
                     lineCounter = counter
                  End If

                  _tableResults.Rows(i).Cells(j).Tag = ocrField
               ElseIf TypeOf ocrField Is OmrFormField Then
                  Dim omrResults As OmrFormFieldResult = TryCast(ocrField.Result, OmrFormFieldResult)
                  _tableResults.Rows(i).Cells(j).Value = omrResults.Text
                  _tableResults.Rows(i).Cells(j).Tag = ocrField
               End If
            Next

            _tableResults.Rows(i).Height *= lineCounter
         Next
      End If
   End Sub

   Private Function CountCharacterInString(str As String, c As Char) As Integer
      Dim counter As Integer = 0
      For i As Integer = 0 To counter - 1
         If str(i) = c Then
            counter += 1
         End If
      Next
      Return counter
   End Function

   Private Sub _tableResults_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles _tableResults.MouseDoubleClick
      Try
         If _tableResults.Rows.Count > 0 AndAlso _tableResults.SelectedCells.Count = 1 Then
            Dim field As OcrFormField = TryCast(_tableResults.SelectedCells(0).Tag, OcrFormField)

            If TypeOf field Is TextFormField OrElse TypeOf field Is OmrFormField Then
               Dim detailedResultsdialog As New DetailedCharacterResults(field)
               detailedResultsdialog.ShowDialog(Me)
            End If
         End If
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try
   End Sub
End Class
