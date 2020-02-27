' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace DicomAnonymizer.UI
   Public Class SelectionDecorator
      Private _DatagridView As DataGridView

      Public Sub New(ByVal dataGridView As DataGridView)
         If dataGridView Is Nothing Then
            Throw New ArgumentNullException("dataGridView")
         End If
         _DatagridView = dataGridView

         ' decorate dataGridView with row number behaviour
         AddHandler _DatagridView.RowPostPaint, AddressOf _DatagridView_RowPostPaint
         AddHandler _DatagridView.CellFormatting, AddressOf _DatagridView_CellFormatting
      End Sub

      Private Sub _DatagridView_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs)
         ' for the first cell paint the background as highlight and text as white in case of selection
         If e.ColumnIndex = 0 Then
            e.CellStyle.SelectionBackColor = SystemColors.Highlight
            e.CellStyle.SelectionForeColor = Color.White
         Else
            e.CellStyle.SelectionBackColor = e.CellStyle.BackColor
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor
         End If
      End Sub

      Private Sub _DatagridView_RowPostPaint(ByVal sender As Object, ByVal e As DataGridViewRowPostPaintEventArgs)
         Dim dgv As DataGridView = CType(sender, DataGridView)

         If dgv.Rows(e.RowIndex).Selected Then
            Dim width As Integer = dgv.Width
            Dim r As Rectangle = dgv.GetRowDisplayRectangle(e.RowIndex, False)
            Dim rect As Rectangle = New Rectangle(r.X, r.Y, width - 1, r.Height - 1)

            ' draw the border around the selected row using the highlight color and using a border width of 2
            ControlPaint.DrawBorder(e.Graphics, rect, SystemColors.Highlight, 2, ButtonBorderStyle.Solid, SystemColors.Highlight, 2, ButtonBorderStyle.Solid, SystemColors.Highlight, 2, ButtonBorderStyle.Solid, SystemColors.Highlight, 2, ButtonBorderStyle.Solid)
         End If
      End Sub
   End Class
End Namespace
