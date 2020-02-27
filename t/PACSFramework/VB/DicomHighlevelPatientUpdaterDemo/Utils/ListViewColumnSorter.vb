' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.Collections
Imports System.Runtime.InteropServices

Namespace DicomDemo.Utils
   ''' <summary>
   ''' This class is an implementation of the 'IComparer' interface.
   ''' </summary>
   Friend Class ListViewColumnSorter : Implements IComparer
      <StructLayout(LayoutKind.Sequential)> _
      Public Structure HDITEM
         Public mask As Int32
         Public cxy As Int32
         <MarshalAs(UnmanagedType.LPTStr)> _
         Public pszText As [String]
         Public hbm As IntPtr
         Public cchTextMax As Int32
         Public fmt As Int32
         Public lParam As Int32
         Public iImage As Int32
         Public iOrder As Int32
      End Structure

      <DllImport("user32")> _
      Shared Function SendMessage(ByVal Handle As IntPtr, ByVal msg As Int32, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
      End Function

      <DllImport("user32", EntryPoint:="SendMessage")> _
      Shared Function SendMessage2(ByVal Handle As IntPtr, ByVal msg As Int32, ByVal wParam As IntPtr, ByRef lParam As HDITEM) As IntPtr
      End Function

      Private Const HDI_WIDTH As Int32 = &H1
      Private Const HDI_HEIGHT As Int32 = HDI_WIDTH
      Private Const HDI_TEXT As Int32 = &H2
      Private Const HDI_FORMAT As Int32 = &H4
      Private Const HDI_LPARAM As Int32 = &H8
      Private Const HDI_BITMAP As Int32 = &H10
      Private Const HDI_IMAGE As Int32 = &H20
      Private Const HDI_DI_SETITEM As Int32 = &H40
      Private Const HDI_ORDER As Int32 = &H80
      Private Const HDI_FILTER As Int32 = &H100 ' 0x0500

      Private Const HDF_LEFT As Int32 = &H0
      Private Const HDF_RIGHT As Int32 = &H1
      Private Const HDF_CENTER As Int32 = &H2
      Private Const HDF_JUSTIFYMASK As Int32 = &H3
      Private Const HDF_RTLREADING As Int32 = &H4
      Private Const HDF_OWNERDRAW As Int32 = &H8000
      Private Const HDF_STRING As Int32 = &H4000
      Private Const HDF_BITMAP As Int32 = &H2000
      Private Const HDF_BITMAP_ON_RIGHT As Int32 = &H1000
      Private Const HDF_IMAGE As Int32 = &H800
      Private Const HDF_SORTUP As Int32 = &H400 ' 0x0501
      Private Const HDF_SORTDOWN As Int32 = &H200 ' 0x0501

      Private Const LVM_FIRST As Int32 = &H1000 ' List messages
      Private Const LVM_GETHEADER As Int32 = LVM_FIRST + 31

      Private Const HDM_FIRST As Int32 = &H1200 ' Header messages
      Private Const HDM_SETIMAGELIST As Int32 = HDM_FIRST + 8
      Private Const HDM_GETIMAGELIST As Int32 = HDM_FIRST + 9
      Private Const HDM_GETITEM As Int32 = HDM_FIRST + 11
      Private Const HDM_SETITEM As Int32 = HDM_FIRST + 12

      ''' <summary>
      ''' Specifies the column to be sorted
      ''' </summary>
      Private ColumnToSort As Integer
      ''' <summary>
      ''' Specifies the order in which to sort (i.e. 'Ascending').
      ''' </summary>
      Private OrderOfSort As SortOrder
      ''' <summary>
      ''' Case insensitive comparer object
      ''' </summary>
      Private ObjectCompare As CaseInsensitiveComparer

      ''' <summary>
      ''' Class constructor.  Initializes various elements
      ''' </summary>
      Public Sub New()
         ' Initialize the column to '0'
         ColumnToSort = 0

         ' Initialize the sort order to 'none'
         OrderOfSort = SortOrder.None

         ' Initialize the CaseInsensitiveComparer object
         ObjectCompare = New CaseInsensitiveComparer()
      End Sub

      ''' <summary>
      ''' This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
      ''' </summary>
      ''' <param name="x">First object to be compared</param>
      ''' <param name="y">Second object to be compared</param>
      ''' <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
      Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
         Dim compareResult As Integer
         Dim listviewX, listviewY As ListViewItem
         Dim xDate As DateTime

         ' Cast the objects to be compared to ListViewItem objects
         listviewX = CType(x, ListViewItem)
         listviewY = CType(y, ListViewItem)

         If DateTime.TryParse(listviewX.SubItems(ColumnToSort).Text, xDate) Then
            Dim yDate As DateTime

            DateTime.TryParse(listviewY.SubItems(ColumnToSort).Text, yDate)
            compareResult = ObjectCompare.Compare(xDate, yDate)
         Else
            ' Compare the two items
            compareResult = ObjectCompare.Compare(listviewX.SubItems(ColumnToSort).Text, listviewY.SubItems(ColumnToSort).Text)
         End If

         ' Calculate correct return value based on object comparison
         If OrderOfSort = SortOrder.Ascending Then
            ' Ascending sort is selected, return normal result of compare operation
            Return compareResult
         ElseIf OrderOfSort = SortOrder.Descending Then
            ' Descending sort is selected, return negative result of compare operation
            Return (-compareResult)
         Else
            ' Return '0' to indicate they are equal
            Return 0
         End If
      End Function

      ''' <summary>
      ''' Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
      ''' </summary>
      Public Property SortColumn() As Integer
         Set(ByVal value As Integer)
            ColumnToSort = value
         End Set
         Get
            Return ColumnToSort
         End Get
      End Property

      ''' <summary>
      ''' Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
      ''' </summary>
      Public Property Order() As SortOrder
         Set(ByVal value As SortOrder)
            OrderOfSort = value
         End Set
         Get
            Return OrderOfSort
         End Get
      End Property

      Public Sub ShowHeaderIcon(ByVal list As ListView, ByVal columnIndex As Integer, ByVal sortOrder As SortOrder)
         If columnIndex < 0 OrElse columnIndex >= list.Columns.Count Then
            Return
         End If

         Dim hHeader As IntPtr = SendMessage(list.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero)

         Dim colHdr As ColumnHeader = list.Columns(columnIndex)

         Dim hd As HDITEM = New HDITEM()
         hd.mask = HDI_FORMAT

         Dim align As HorizontalAlignment = colHdr.TextAlign

         If align = HorizontalAlignment.Left Then
            hd.fmt = HDF_LEFT Or HDF_STRING Or HDF_BITMAP_ON_RIGHT

         ElseIf align = HorizontalAlignment.Center Then
            hd.fmt = HDF_CENTER Or HDF_STRING Or HDF_BITMAP_ON_RIGHT

         Else ' HorizontalAlignment.Right
            hd.fmt = HDF_RIGHT Or HDF_STRING
         End If

         If sortOrder = sortOrder.Ascending Then
            hd.fmt = hd.fmt Or HDF_SORTUP

         ElseIf sortOrder = sortOrder.Descending Then
            hd.fmt = hd.fmt Or HDF_SORTDOWN
         End If

         SendMessage2(hHeader, HDM_SETITEM, New IntPtr(columnIndex), hd)
      End Sub
   End Class
End Namespace
