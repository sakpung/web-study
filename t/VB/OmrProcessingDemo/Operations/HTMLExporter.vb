Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Class HTMLExporter
   Inherits BusyOperation

   Private dgv As DataGridView
   Private fileName As String

   Public Sub New(ByVal filenameParam As String, ByVal dgv As DataGridView)
      fileName = filenameParam
      dgv = dgv
   End Sub

   Protected Overrides Sub Run()
      Dim ticker As Integer = 0
      Dim fName As String = Path.GetFileName(fileName)
      Progress(0, "Saving to " & fName)
      Dim builder As StringBuilder = New StringBuilder()
      Dim steps As Single = 100.0F / (dgv.Rows.Count * 1.0F)
      builder.AppendLine("<!DOCTYPE html>")
      builder.AppendLine("<html>")
      builder.AppendLine("<head>")
      builder.AppendLine("<style>")
      builder.AppendLine("table {")
      builder.AppendLine("border-collapse: collapse;")
      builder.AppendLine("width: 100 %;")
      builder.AppendLine("}")
      builder.AppendLine("th, td {")
      builder.AppendLine("text-align: left;")
      builder.AppendLine("padding: 8px;")
      builder.AppendLine("}")
      builder.AppendLine("tr:nth-child(even) {background-color: #f2f2f2;}")
      builder.AppendLine("</style>")
      builder.AppendLine("</head>")
      builder.AppendLine("<body>")
      builder.AppendLine("<table>")
      builder.AppendLine("<tr>")
      builder.AppendLine("<td></td>")

      For i As Integer = 0 To dgv.ColumnCount - 1
         Dim text As String = dgv.Columns(i).HeaderText
         builder.AppendFormat("<th>{0}</th>", text)
         builder.AppendLine()
      Next

      builder.AppendLine("</tr>")

      For i As Integer = 0 To dgv.Rows.Count - 1
         builder.AppendLine("<tr>")
         Dim header As String = If(dgv.Rows(i).HeaderCell.Value IsNot Nothing, dgv.Rows(i).HeaderCell.Value.ToString(), "")
         builder.AppendFormat("<td>{0}</td>", header)
         builder.AppendLine()

         For j As Integer = 0 To dgv.Rows(i).Cells.Count - 1
            Dim cell As DataGridViewCell = dgv.Rows(i).Cells(j)
            Dim val As String = If(cell.Value IsNot Nothing, cell.Value.ToString(), " ")
            builder.AppendFormat("<td>{0}</td>", val)
            builder.AppendLine()
         Next

         ticker = ticker + CInt(steps)
         Progress(ticker, "")
         builder.AppendLine("</tr>")
      Next

      builder.AppendLine("</table>")
      builder.AppendLine("</body></html>")
      File.WriteAllText(fileName, builder.ToString())
      MyBase.Run()
   End Sub
End Class
