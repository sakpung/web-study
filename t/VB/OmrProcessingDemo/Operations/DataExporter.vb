Imports System.Windows.Forms
Imports System.IO
Imports System.Text
Imports System
Imports Microsoft.VisualBasic

Friend Class DataExporter
   Inherits BusyOperation

   Private _dgv As DataGridView
   Private _fileName As String

   Public Sub New(ByVal fileNameParam As String, ByVal dgvResults As DataGridView)
      MyBase.New()
      _fileName = fileNameParam
      _dgv = dgvResults
   End Sub

   Protected Overrides Sub Run()
      Dim ticker As Integer = 0
      Dim fName As String = Path.GetFileName(_fileName)
      Progress(0, "Saving to " & fName)
      Dim builder As StringBuilder = New StringBuilder()
      Dim steps As Single = 100.0F / (_dgv.Rows.Count * 1.0F)
      builder.Append(", ")

      For i As Integer = 0 To _dgv.Columns.Count - 1
         Dim text As String = _dgv.Columns(i).HeaderText
         text = text.Replace(Constants.vbLf, " "c)

         If text.Contains(",") Then
            text = """" & text & """"
         End If

         builder.Append(text & ", ")
      Next

      builder.AppendLine()

      For i As Integer = 0 To _dgv.Rows.Count - 1
         If (_dgv.Rows(i).HeaderCell.Value IsNot Nothing) Then
            builder.Append(_dgv.Rows(i).HeaderCell.Value.ToString() + ", ")
         End If

         For j As Integer = 0 To _dgv.Rows(i).Cells.Count - 1
            Dim cell As DataGridViewCell = _dgv.Rows(i).Cells(j)
            Dim val As String = If(cell.Value IsNot Nothing, cell.Value.ToString(), " ")
            builder.Append(val & ", ")
         Next

         ticker = ticker + Convert.ToInt32(steps)
         Progress(ticker, "")
         builder.AppendLine()
      Next

      File.WriteAllText(_fileName, builder.ToString())
      MyBase.Run()
   End Sub
End Class
