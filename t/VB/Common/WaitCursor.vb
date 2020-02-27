' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Windows.Forms

Public NotInheritable Class WaitCursor
   Implements IDisposable

   Private _cursor As Cursor

   Public Sub New()
      _cursor = Cursor.Current
      Cursor.Current = Cursors.WaitCursor
   End Sub

   Public Sub Dispose() Implements IDisposable.Dispose
      Dispose(True)
      System.GC.SuppressFinalize(Me)
   End Sub

   Protected Overrides Sub Finalize()

      Dispose(False)
   End Sub

   Private Sub Dispose(ByVal disposing As Boolean)
      If (disposing) Then
         If Not (_cursor Is Nothing) Then
            Cursor.Current = _cursor
            _cursor = Nothing
         End If
      End If
   End Sub
End Class
