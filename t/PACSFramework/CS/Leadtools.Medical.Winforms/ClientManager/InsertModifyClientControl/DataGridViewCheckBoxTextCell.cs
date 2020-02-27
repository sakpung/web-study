// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Leadtools.Medical.Winforms
{
   public class MyDataGridViewCheckBoxTextCell : DataGridViewCheckBoxCell
   {
      private string _text;
      public string Text
      {
         get { return _text; }
         set { _text = value; }
      }


      protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
      {
         base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

         Rectangle contentBounds = this.GetContentBounds(rowIndex);

         // Compute the location where we want to paint the string.
         Point stringLocation = new Point();

         // Compute the Y.
         // NOTE: the current logic does not take into account padding.
         stringLocation.Y = cellBounds.Y + 2;

         // Compute the X.
         // Content bounds are computed relative to the cell bounds
         // - not relative to the DataGridView control.
         stringLocation.X = cellBounds.X + contentBounds.Right + 2;

         // Paint the string.
         graphics.DrawString(Text, System.Windows.Forms.Control.DefaultFont, System.Drawing.Brushes.Black, stringLocation);
      }
   }

   public class MyDataGridViewCheckBoxTextColumn : DataGridViewCheckBoxColumn
   {
      public override DataGridViewCell CellTemplate
      {
         get
         {
            return new MyDataGridViewCheckBoxTextCell();
         }
      }
   }
}
