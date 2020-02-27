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
using Leadtools.Dicom.Common.Anonymization;
using DicomAnonymizer.UI.Controls;
using Leadtools.Dicom.Common.Compare;

namespace DicomAnonymizer.UI
{
   public class DifferenceDecorator
   {
      private DataGridView _DatagridView;

      public DifferenceDecorator(DataGridView dataGridView)
      {
         if (dataGridView == null)
         {
            throw new ArgumentNullException("dataGridView");
         }
         _DatagridView = dataGridView;

         //
         // decorate dataGridView with row number behaviour   
         //
         _DatagridView.CellFormatting += _DatagridView_CellFormatting;
         _DatagridView.RowPostPaint += new DataGridViewRowPostPaintEventHandler(_DatagridView_RowPostPaint);
      }

      void _DatagridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
      {
         TreeGridView tgv = sender as TreeGridView;

         if (e.RowIndex < tgv.Nodes.Count)
         {
            Difference diff = tgv.Nodes[e.RowIndex].Tag as Difference;

            if (diff != null)
            {
               if (diff.Location != TagLocation.Both)
               {
                  int width = tgv.Width;
                  Rectangle r = tgv.GetRowDisplayRectangle(e.RowIndex, false);
                  var rect = new Rectangle(r.X, r.Y, width - 1, r.Height - 1);
                  Color color = diff.Location == TagLocation.First ? Color.Red : Color.Pink;

                  ControlPaint.DrawBorder(e.Graphics, rect, color, 2, ButtonBorderStyle.Solid, color, 2, ButtonBorderStyle.Solid,
                                          color, 2, ButtonBorderStyle.Solid, color, 2, ButtonBorderStyle.Solid);
               }
            }
         }
      }   

      void _DatagridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
      {                 
      }    
   }
}
