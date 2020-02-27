' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Text

Namespace DicomAnonymizer.UI.Controls
   Public Class CancelDropHilightEventArgs : Inherits CancelEventArgs
      Private _RowIndex As Integer = -1

      Public ReadOnly Property RowIndex() As Integer
         Get
            Return _RowIndex
         End Get
      End Property

      Public Sub New(ByVal rowIndex_Renamed As Integer)
         _RowIndex = rowIndex_Renamed
      End Sub
   End Class
End Namespace
