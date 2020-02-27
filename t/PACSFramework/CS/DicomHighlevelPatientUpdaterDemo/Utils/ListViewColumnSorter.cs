// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;

namespace DicomDemo.Utils
{
    /// <summary>
/// This class is an implementation of the 'IComparer' interface.
/// </summary>
    internal class ListViewColumnSorter : IComparer
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct HDITEM
        {
            public Int32 mask;
            public Int32 cxy;
            [MarshalAs(UnmanagedType.LPTStr)]
            public String pszText;
            public IntPtr hbm;
            public Int32 cchTextMax;
            public Int32 fmt;
            public Int32 lParam;
            public Int32 iImage;
            public Int32 iOrder;
        };

        [DllImport("user32")]
        static extern IntPtr SendMessage(IntPtr Handle, Int32 msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32", EntryPoint = "SendMessage")]
        static extern IntPtr SendMessage2(IntPtr Handle, Int32 msg, IntPtr wParam, ref HDITEM lParam);

        const Int32 HDI_WIDTH = 0x0001;
        const Int32 HDI_HEIGHT = HDI_WIDTH;
        const Int32 HDI_TEXT = 0x0002;
        const Int32 HDI_FORMAT = 0x0004;
        const Int32 HDI_LPARAM = 0x0008;
        const Int32 HDI_BITMAP = 0x0010;
        const Int32 HDI_IMAGE = 0x0020;
        const Int32 HDI_DI_SETITEM = 0x0040;
        const Int32 HDI_ORDER = 0x0080;
        const Int32 HDI_FILTER = 0x0100;		// 0x0500

        const Int32 HDF_LEFT = 0x0000;
        const Int32 HDF_RIGHT = 0x0001;
        const Int32 HDF_CENTER = 0x0002;
        const Int32 HDF_JUSTIFYMASK = 0x0003;
        const Int32 HDF_RTLREADING = 0x0004;
        const Int32 HDF_OWNERDRAW = 0x8000;
        const Int32 HDF_STRING = 0x4000;
        const Int32 HDF_BITMAP = 0x2000;
        const Int32 HDF_BITMAP_ON_RIGHT = 0x1000;
        const Int32 HDF_IMAGE = 0x0800;
        const Int32 HDF_SORTUP = 0x0400;		// 0x0501
        const Int32 HDF_SORTDOWN = 0x0200;		// 0x0501

        const Int32 LVM_FIRST = 0x1000;		// List messages
        const Int32 LVM_GETHEADER = LVM_FIRST + 31;

        const Int32 HDM_FIRST = 0x1200;		// Header messages
        const Int32 HDM_SETIMAGELIST = HDM_FIRST + 8;
        const Int32 HDM_GETIMAGELIST = HDM_FIRST + 9;
        const Int32 HDM_GETITEM = HDM_FIRST + 11;
        const Int32 HDM_SETITEM = HDM_FIRST + 12;

        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private int ColumnToSort;
        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private SortOrder OrderOfSort;
        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;
            DateTime xDate;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            if (DateTime.TryParse(listviewX.SubItems[ColumnToSort].Text, out xDate))
            {
                DateTime yDate;

                DateTime.TryParse(listviewY.SubItems[ColumnToSort].Text, out yDate);
                compareResult = ObjectCompare.Compare(xDate, yDate);
            }
            else
            {
                // Compare the two items
                compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
            }

            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }

        public void ShowHeaderIcon(ListView list, int columnIndex, SortOrder sortOrder)
        {
            if (columnIndex < 0 || columnIndex >= list.Columns.Count)
                return;

            IntPtr hHeader = SendMessage(list.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);

            ColumnHeader colHdr = list.Columns[columnIndex];

            HDITEM hd = new HDITEM();
            hd.mask = HDI_FORMAT;

            HorizontalAlignment align = colHdr.TextAlign;

            if (align == HorizontalAlignment.Left)
                hd.fmt = HDF_LEFT | HDF_STRING | HDF_BITMAP_ON_RIGHT;

            else if (align == HorizontalAlignment.Center)
                hd.fmt = HDF_CENTER | HDF_STRING | HDF_BITMAP_ON_RIGHT;

            else	// HorizontalAlignment.Right
                hd.fmt = HDF_RIGHT | HDF_STRING;

            if (sortOrder == SortOrder.Ascending)
                    hd.fmt |= HDF_SORTUP;

            else if (sortOrder == SortOrder.Descending)
                    hd.fmt |= HDF_SORTDOWN;           

            SendMessage2(hHeader, HDM_SETITEM, new IntPtr(columnIndex), ref hd);
        }        
    }
}
