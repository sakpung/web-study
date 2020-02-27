// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SharePointDemo
{
   // This is the comparer we are going to use in this demo
   // Will compare file names
   internal class FileListViewColumnSorter : IComparer
   {
      // The column to be sorted
      private int _sortColumnIndex;
      // Order in which to sort
      private SortOrder _sortOrder;
      // Comparer object

      public FileListViewColumnSorter()
      {
         _sortColumnIndex = 0;
         _sortOrder = SortOrder.None;
      }

      [DllImport(
          "SHLWAPI.DLL",
          EntryPoint = "StrCmpLogicalW",
          SetLastError = true,
          CharSet = CharSet.Unicode,
          ExactSpelling = true,
          CallingConvention = CallingConvention.StdCall)]
      private static extern int StrCmpLogicalW(string psz1, string psz2);

      // Compare the objects
      public int Compare(object x, object y)
      {
         // Get the ListViewItem's
         ListViewItem itemX = x as ListViewItem;
         ListViewItem itemY = y as ListViewItem;

         // Compare the two items
         int compareResult = StrCmpLogicalW(itemX.SubItems[_sortColumnIndex].Text, itemY.SubItems[_sortColumnIndex].Text);

         switch(_sortOrder)
         {
            case SortOrder.Ascending:
               // Ascending sort is selected, return normal result of compare operation
               return compareResult;

            case SortOrder.Descending:
               // Descending sort is selected, return negative result of compare operation
               return -compareResult;

            default:
               // Return '0' to indicate they are equal
               return 0;
         }
      }

      // The column index to use
      public int SortColumnIndex
      {
         get { return _sortColumnIndex; }
         set { _sortColumnIndex = value; }
      }

      public SortOrder SortOrder
      {
         get { return _sortOrder; }
         set { _sortOrder = value; }
      }

      public void Sort(ListView lv, int column)
      {
         // Check if the we clicked a column already sorted
         if(column == SortColumnIndex)
         {
            // Rever the current sort direction
            if(SortOrder == SortOrder.Ascending)
               SortOrder = SortOrder.Descending;
            else
               SortOrder = SortOrder.Ascending;
         }
         else
         {
            // Change the column that is to be sorted, default to ascending
            SortColumnIndex = column;
            SortOrder = SortOrder.Ascending;
         }

         // Perform the sort with these new options
         lv.Sort();
      }
   }
}
