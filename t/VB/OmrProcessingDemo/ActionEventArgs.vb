Imports System
Imports System.Collections.Generic
Imports System.Text

Public Class ActionEventArgs
   Inherits EventArgs

   Private _action As String
   Private _data As Object

   Private Sub New()
   End Sub

   Public Sub New(ByVal action As String, ByVal data As Object)
      _action = action
      _data = data
   End Sub

   Public ReadOnly Property Action As String
      Get
         Return _action
      End Get
   End Property

   Public ReadOnly Property Data As Object
      Get
         Return _data
      End Get
   End Property
End Class
