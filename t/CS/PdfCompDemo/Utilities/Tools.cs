// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Demos;

#if ! LEADTOOLS_V17_OR_LATER
using LeadPoint = System.Drawing.Point;
using LeadSize = System.Drawing.Size;
using LeadRect = System.Drawing.Rectangle;
#endif // #if !LEADTOOLS_V17_OR_LATER

#if LEADTOOLS_V17_OR_LATER
using Leadtools.Drawing;
#endif // #if LEADTOOLS_V17_OR_LATER

namespace PdfCompDemo
{
   public sealed class Tools
   {
      private Tools( )
      {
      }

      public static bool ShowColorDialog(IWin32Window owner, ref RasterColor color)
      {
         ColorDialog dlg = new ColorDialog();
         dlg.AllowFullOpen = true;
         dlg.AnyColor = true;
         dlg.Color = Converters.ToGdiPlusColor(color);
         DialogResult res = dlg.ShowDialog(owner);
         if(res == DialogResult.OK)
            color = Converters.FromGdiPlusColor(dlg.Color);

         return res == DialogResult.OK;
      }

      public static bool CanDrop(IDataObject data)
      {
         return data.GetDataPresent(DataFormats.Text) || data.GetDataPresent(DataFormats.FileDrop);
      }

      public static string[] GetDropFiles(IDataObject data)
      {
         if(data.GetDataPresent(DataFormats.Text))
         {
            string[] files = new string[1];
            files[0] = data.GetData(DataFormats.Text) as string;
            return files;
         }
         else if(data.GetDataPresent(DataFormats.FileDrop))
         {
            string[] files = data.GetData(DataFormats.FileDrop) as string[];
            return files;
         }

         return null;
      }
   }
}
