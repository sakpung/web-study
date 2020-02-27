// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DicomAnonymizer.Common
{
   public static class Extensions
   {
      public static int MeasureDisplayStringWidth(this Graphics graphics, string text, Font font)
      {
         System.Drawing.StringFormat format = new System.Drawing.StringFormat();
         System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0, 0, 1000, 1000);
         System.Drawing.CharacterRange[] ranges = { new System.Drawing.CharacterRange(0, text.Length) };
         System.Drawing.Region[] regions = new System.Drawing.Region[1];

         format.SetMeasurableCharacterRanges(ranges);
         regions = graphics.MeasureCharacterRanges(text, font, rect, format);
         rect = regions[0].GetBounds(graphics);

         return (int)(rect.Right + 1.0f);
      }

      public static void SetValues(this DicomTagNode node, params object[] values)
      {
         for (int i = 0; i < values.Length; i++)
         {
            node.Cells[i].Value = values[i];
         }
      }     
   }
}
