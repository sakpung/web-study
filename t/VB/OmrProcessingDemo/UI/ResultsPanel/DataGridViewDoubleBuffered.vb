Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Public Class DataGridViewDoubleBuffered
   Inherits DataGridView

   Public Sub New()
      MyBase.New()
      DoubleBuffered = True
   End Sub

   Protected Overrides Sub OnScroll(ByVal e As ScrollEventArgs)
      Me.Invalidate()
      MyBase.OnScroll(e)
   End Sub
End Class
