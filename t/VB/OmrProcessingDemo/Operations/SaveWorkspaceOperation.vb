Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Text
Imports System.Threading.Tasks

Class SaveWorkspaceOperation
   Inherits BusyOperation

   Private _filename As String
   Private _workspace As Workspace

   Public Sub New(ByVal filename As String, ByVal workspaceVar As Workspace)
      _filename = filename
      _workspace = workspaceVar
   End Sub

   Protected Overrides Sub Run()
      Progress(101, "Packaging workspace...")
      _workspace.Pack(_filename)
      Progress(101, "Saving...")
      Dim bf As BinaryFormatter = New BinaryFormatter()

      Using fs As FileStream = File.OpenWrite(_filename)
         bf.Serialize(fs, _workspace)
      End Using

      MyBase.Run()
   End Sub
End Class
