Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Text
Imports System.Threading.Tasks

Class LoadWorkspaceOperation
   Inherits BusyOperation

   Private filename As String
   Private myworkspace As Workspace

   Public ReadOnly Property LoadedWorkspace As Workspace
      Get
         Return myworkspace
      End Get
   End Property

   Public Sub New(ByVal filename As String)
      Me.filename = filename
   End Sub

   Protected Overrides Sub Run()
      Progress(101, "Loading workspace file...")
      Dim bf As BinaryFormatter = New BinaryFormatter()

      Using fs As FileStream = File.OpenRead(filename)
         myworkspace = CType(bf.Deserialize(fs), Workspace)
      End Using

      Progress(101, "Unpacking...")
      myworkspace.Unpack()
      MyBase.Run()
   End Sub
End Class
