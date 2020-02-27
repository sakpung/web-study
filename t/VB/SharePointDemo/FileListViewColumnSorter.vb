' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Collections
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Namespace SharePointDemo
   ' This is the comparer we are going to use in this demo
   ' Will compare file names
   Friend Class FileListViewColumnSorter : Implements IComparer
      ' The column to be sorted
      Private _sortColumnIndex As Integer
      ' Order in which to sort
      Private _sortOrder As SortOrder
      ' Comparer object

      Public Sub New()
         _sortColumnIndex = 0
         _sortOrder = SortOrder.None
      End Sub

      <DllImport("SHLWAPI.DLL", EntryPoint:="StrCmpLogicalW", SetLastError:=True, CharSet:=CharSet.Unicode, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
      Private Shared Function StrCmpLogicalW(ByVal psz1 As String, ByVal psz2 As String) As Integer
      End Function

      ' Compare the objects
      Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
         ' Get the ListViewItem's
         Dim itemX As ListViewItem = TryCast(x, ListViewItem)
         Dim itemY As ListViewItem = TryCast(y, ListViewItem)

         ' Compare the two items
         Dim compareResult As Integer = StrCmpLogicalW(itemX.SubItems(_sortColumnIndex).Text, itemY.SubItems(_sortColumnIndex).Text)

         Select Case _sortOrder
            Case SortOrder.Ascending
               ' Ascending sort is selected, return normal result of compare operation
               Return compareResult

            Case SortOrder.Descending
               ' Descending sort is selected, return negative result of compare operation
               Return -compareResult

            Case Else
               ' Return '0' to indicate they are equal
               Return 0
         End Select
      End Function

      ' The column index to use
      Public Property SortColumnIndex() As Integer
         Get
            Return _sortColumnIndex
         End Get
         Set(ByVal value As Integer)
            _sortColumnIndex = Value
         End Set
      End Property

      Public Property SortOrder() As SortOrder
         Get
            Return _sortOrder
         End Get
         Set(ByVal value As SortOrder)
            _sortOrder = Value
         End Set
      End Property

      Public Sub Sort(ByVal lv As ListView, ByVal column As Integer)
         ' Check if the we clicked a column already sorted
         If column = SortColumnIndex Then
            ' Rever the current sort direction
            If SortOrder = SortOrder.Ascending Then
               SortOrder = SortOrder.Descending
            Else
               SortOrder = SortOrder.Ascending
            End If
         Else
            ' Change the column that is to be sorted, default to ascending
            SortColumnIndex = column
            SortOrder = SortOrder.Ascending
         End If

         ' Perform the sort with these new options
         lv.Sort()
      End Sub
   End Class
End Namespace
