' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Text


Public Class SymbologyListBoxItemDoubleClickedEventArgs : Inherits EventArgs
   Private Sub New()
   End Sub

   Public Sub New(ByVal index_Renamed As Integer)
      _index = index_Renamed
   End Sub

   Private _index As Integer
   Public ReadOnly Property Index() As Integer
      Get
         Return _index
      End Get
   End Property
End Class
