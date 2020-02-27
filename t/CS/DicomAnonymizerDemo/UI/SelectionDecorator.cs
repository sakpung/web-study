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
   public class SelectionDecorator
   {
      private DataGridView _DatagridView;

      public SelectionDecorator(DataGridView dataGridView)
      {
         if (dataGridView == null)
         {
            throw new ArgumentNullException("dataGridView");
         }
         _DatagridView = dataGridView;

         // decorate dataGridView with row number behaviour
         _DatagridView.RowPostPaint += _DatagridView_RowPostPaint;
         _DatagridView.CellFormatting += _DatagridView_CellFormatting;
      }

      void _DatagridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
      {
         // for the first cell paint the background as highlight and text as white in case of selection
         if (e.ColumnIndex == 0)
         {            
            e.CellStyle.SelectionBackColor = SystemColors.Highlight;
            e.CellStyle.SelectionForeColor = Color.White;
         }
         else
         {
            e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
         }
      }

      void _DatagridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
      {
         var dgv = (DataGridView)sender;

         if (dgv.Rows[e.RowIndex].Selected)
         {
            int width = dgv.Width;
            Rectangle r = dgv.GetRowDisplayRectangle(e.RowIndex, false);
            var rect = new Rectangle(r.X, r.Y, width - 1, r.Height - 1);

            // draw the border around the selected row using the highlight color and using a border width of 2
            ControlPaint.DrawBorder(e.Graphics, rect, SystemColors.Highlight, 2, ButtonBorderStyle.Solid, SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid, SystemColors.Highlight, 2, ButtonBorderStyle.Solid);
         }
      }    
   }
}
