Imports Leadtools.Forms.Processing.Omr
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Class StatisticsExporter
   Inherits BusyOperation

   Private _filename As String
   Private _statsArray As String(,)

   Public Sub New(ByVal filename As String, ByVal statsArray As String(,))
      _filename = filename
      _statsArray = statsArray
   End Sub

   Protected Overrides Sub Run()
      Dim fName As String = Path.GetFileName(_filename)
      Progress(0, "Saving to " & fName)
      Dim length As Integer = _statsArray.GetLength(0)
      Dim width As Integer = _statsArray.GetLength(1)
      Dim builder As StringBuilder = New StringBuilder()

      For i As Integer = 0 To length - 1

         For j As Integer = 0 To width - 1
            builder.Append(_statsArray(i, j) & ", ")
         Next

         builder.AppendLine()
      Next

      File.WriteAllText(_filename, builder.ToString())
      MyBase.Run()
   End Sub
End Class
