// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DicomAnonymizer.UI
{
   public class RowNumberDataGridViewDecorator
   {
      //  The decorated DataGridView.
      private DataGridView _DatagridView;

      // Backing field for ShowRowNumber property.
      private bool _ShowRowNumbers = true;

      public bool ShowRowNumbers
      {
         get
         {
            return _ShowRowNumbers;
         }
         set
         {
            if (_ShowRowNumbers != value)
            {
               _ShowRowNumbers = value;
               _DatagridView.Refresh();
            }
         }
      } // end of property ShowRowNumbers

      // Constructor
      // dataGridView - the DataGridView to be decorated
      public RowNumberDataGridViewDecorator(DataGridView dataGridView)
      {
         if (dataGridView == null)
         {
            throw new ArgumentNullException("dataGridView");
         }
         _DatagridView = dataGridView;

         // decorate dataGridView with row number behaviour
         _DatagridView.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridView_RowPostPaint);
      }           

      // Paints the row numbers in the row header column.
      private void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
      {
         if (_ShowRowNumbers && sender == _DatagridView)
         {
            // Store a string representation of the row number
            // in 'strRowNumber'
            string strRowNumber = (e.RowIndex + 1).ToString();

            // Prepend leading zeros to the string if necessary to improve
            // appearance. For example, if there are ten rows in the grid,
            // row seven will be numbered as "07" instead of "7". Similarly,
            // if there are 100 rows in the grid, row seven will be numbered
            // as "007".
            while (strRowNumber.Length < _DatagridView.RowCount.ToString().Length)
            {
               strRowNumber = "0" + strRowNumber;
            }

            // Determine the display size of the row number string using
            // the DataGridView's current font.
            SizeF size = e.Graphics.MeasureString(strRowNumber, _DatagridView.Font);

            // Adjust the width of the column that contains the row header
            // cells if necessary.
            if (_DatagridView.RowHeadersWidth < (int)(size.Width + 20))
            {
               _DatagridView.RowHeadersWidth = (int)(size.Width + 20);
            }

            // This brush will be used to draw the row number string on the
            // row header cell using the system's current ControlText color.
            Brush b = SystemBrushes.ControlText;

            // Draw the row number string on the current row header cell using
            // the brush defined above and the DataGridView's default font.
            e.Graphics.DrawString(strRowNumber, _DatagridView.Font, b, e.RowBounds.Location.X + 15,
                                  e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
         }
      }
   }
}
