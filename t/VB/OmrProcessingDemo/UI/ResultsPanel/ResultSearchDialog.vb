Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Partial Public Class ResultSearchDialog
   Inherits Form

   Private dgv As DataGridView

   Public Sub New(ByVal dgv As DataGridView)
      InitializeComponent()
      Me.dgv = dgv
      txtSearch.Focus()
   End Sub

   Private Sub btnFindNext_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim currentRow As Integer = Math.Max(0, dgv.CurrentCell.RowIndex)
      Dim currentcol As Integer = Math.Max(0, dgv.CurrentCell.ColumnIndex)
      Dim direction As Integer = If(rdbtnForward.Checked, 1, -1)

      If rdbtnSearchbyRows.Checked Then

         While DoRowSearch(currentRow, currentcol, dgv.ColumnCount) = False

            If (currentRow = 0 AndAlso direction = -1) OrElse (direction = 1 AndAlso currentRow = dgv.RowCount - 1) Then
               MessageBox.Show("No other matches found.")
               Return
            End If

            currentRow += direction
            currentcol = If(direction = 1, -1, dgv.ColumnCount)
         End While
      End If

      If rdbtnSearchbyCols.Checked Then

         While DoColumnSearch(currentRow, currentcol, dgv.RowCount) = False

            If (currentcol = 0 AndAlso direction = -1) OrElse (direction = 1 AndAlso currentcol = dgv.ColumnCount - 1) Then
               MessageBox.Show("No results found")
               Return
            End If

            Dim prompt As String = String.Format("No results found.  Continue searching in {0} {1}?", If(rdbtnForward.Checked, "next", "previous"), If(rdbtnSearchbyRows.Checked, "row", "column"))

            If MessageBox.Show(prompt, "Continue?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
               currentcol += direction
               currentRow = If(direction = 1, -1, dgv.RowCount)
            Else
               Exit While
            End If
         End While
      End If
   End Sub

   Private Function DoRowSearch(ByVal x As Integer, ByVal y As Integer, ByVal [stop] As Integer) As Boolean
      Dim direction As Integer = If(rdbtnForward.Checked, 1, -1)
      y += direction

      While y >= 0 AndAlso y < [stop]
         Dim cell As DataGridViewCell = dgv(y, x)

         If IsMatch(cell.Value) Then
            dgv.CurrentCell = cell
            Return True
         End If

         y += direction
      End While

      Return False
   End Function

   Private Function IsMatch(ByVal value As Object) As Boolean
      If value IsNot Nothing AndAlso TypeOf value Is String Then
         Dim toMatch As String = If(chkMatchCase.Checked, txtSearch.Text, txtSearch.Text.ToLowerInvariant())
         Dim matchValue As String = If(chkMatchCase.Checked, value.ToString(), value.ToString().ToLowerInvariant())
         Return toMatch = matchValue
      End If

      Return False
   End Function

   Private Function DoColumnSearch(ByVal x As Integer, ByVal y As Integer, ByVal [stop] As Integer) As Boolean
      Dim direction As Integer = If(rdbtnForward.Checked, 1, -1)
      x += direction

      While x >= 0 AndAlso x < [stop]
         Dim cell As DataGridViewCell = dgv(y, x)

         If IsMatch(cell.Value) Then
            dgv.CurrentCell = cell
            Return True
         End If

         x += direction
      End While

      Return False
   End Function

   Private Sub rdbtnSearchby_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      rdbtnForward.Text = If(rdbtnSearchbyRows.Checked, "&Forward", "&Down")
      rdbtnBackward.Text = If(rdbtnSearchbyRows.Checked, "&Backward", "&Up")
   End Sub
End Class
