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
   Public Class RowNumberDataGridViewDecorator
      '  The decorated DataGridView.
      Private _DatagridView As DataGridView

      ' Backing field for ShowRowNumber property.
      Private _ShowRowNumbers As Boolean = True

      Public Property ShowRowNumbers() As Boolean
         Get
            Return _ShowRowNumbers
         End Get
         Set(ByVal value As Boolean)
            If _ShowRowNumbers <> Value Then
               _ShowRowNumbers = Value
               _DatagridView.Refresh()
            End If
         End Set
      End Property ' end of property ShowRowNumbers

      ' Constructor
      ' dataGridView - the DataGridView to be decorated
      Public Sub New(ByVal dataGridView As DataGridView)
         If dataGridView Is Nothing Then
            Throw New ArgumentNullException("dataGridView")
         End If
         _DatagridView = dataGridView

         ' decorate dataGridView with row number behaviour
         AddHandler _DatagridView.RowPostPaint, AddressOf dataGridView_RowPostPaint
      End Sub

      ' Paints the row numbers in the row header column.
      Private Sub dataGridView_RowPostPaint(ByVal sender As Object, ByVal e As DataGridViewRowPostPaintEventArgs)
         If _ShowRowNumbers AndAlso sender Is _DatagridView Then
            ' Store a string representation of the row number
            ' in 'strRowNumber'
            Dim strRowNumber As String = (e.RowIndex + 1).ToString()

            ' Prepend leading zeros to the string if necessary to improve
            ' appearance. For example, if there are ten rows in the grid,
            ' row seven will be numbered as "07" instead of "7". Similarly,
            ' if there are 100 rows in the grid, row seven will be numbered
            ' as "007".
            Do While strRowNumber.Length < _DatagridView.RowCount.ToString().Length
               strRowNumber = "0" & strRowNumber
            Loop

            ' Determine the display size of the row number string using
            ' the DataGridView's current font.
            Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, _DatagridView.Font)

            ' Adjust the width of the column that contains the row header
            ' cells if necessary.
            If _DatagridView.RowHeadersWidth < CInt(size.Width + 20) Then
               _DatagridView.RowHeadersWidth = CInt(size.Width + 20)
            End If

            ' This brush will be used to draw the row number string on the
            ' row header cell using the system's current ControlText color.
            Dim b As Brush = SystemBrushes.ControlText

            ' Draw the row number string on the current row header cell using
            ' the brush defined above and the DataGridView's default font.
            e.Graphics.DrawString(strRowNumber, _DatagridView.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
         End If
      End Sub
   End Class
End Namespace
