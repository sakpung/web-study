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
Imports Leadtools.Dicom.Common.Anonymization
Imports DicomAnonymizer.UI.Controls
Imports Leadtools.Dicom.Common.Compare

Namespace DicomAnonymizer.UI
   Public Class DifferenceDecorator
      Private _DatagridView As DataGridView

      Public Sub New(ByVal dataGridView As DataGridView)
         If dataGridView Is Nothing Then
            Throw New ArgumentNullException("dataGridView")
         End If
         _DatagridView = dataGridView

         '
         ' decorate dataGridView with row number behaviour   
         '
         AddHandler _DatagridView.CellFormatting, AddressOf _DatagridView_CellFormatting
         AddHandler _DatagridView.RowPostPaint, AddressOf _DatagridView_RowPostPaint
      End Sub

      Private Sub _DatagridView_RowPostPaint(ByVal sender As Object, ByVal e As DataGridViewRowPostPaintEventArgs)
         Dim tgv As TreeGridView = TryCast(sender, TreeGridView)

         If e.RowIndex < tgv.Nodes.Count Then
            Dim diff As Difference = TryCast(tgv.Nodes(e.RowIndex).Tag, Difference)
            If Not diff Is Nothing Then
               If diff.Location <> TagLocation.Both Then
                  Dim width As Integer = tgv.Width
                  Dim r As Rectangle = tgv.GetRowDisplayRectangle(e.RowIndex, False)
                  Dim rect As Rectangle = New Rectangle(r.X, r.Y, width - 1, r.Height - 1)
                  Dim color As Color
                  If diff.Location = TagLocation.First Then
                     color = color.Red
                  Else
                     color = color.Pink
                  End If

                  ControlPaint.DrawBorder(e.Graphics, rect, color, 2, ButtonBorderStyle.Solid, color, 2, ButtonBorderStyle.Solid, color, 2, ButtonBorderStyle.Solid, color, 2, ButtonBorderStyle.Solid)
               End If
            End If
         End If
      End Sub

      Private Sub _DatagridView_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs)
      End Sub
   End Class
End Namespace
