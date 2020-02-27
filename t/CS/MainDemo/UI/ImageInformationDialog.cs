// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Demos;

namespace MainDemo
{
   public partial class ImageInformationDialog : Form
   {
      public RasterImage Image;

      public ImageInformationDialog( )
      {
         InitializeComponent();
      }

      private void ImageInformationDialog_Load(object sender, System.EventArgs e)
      {
         for(int i = 0; i < _lvInfo.Items.Count; i++)
            _lvInfo.Items[i].SubItems.Add(string.Empty);

         UpdateControls();
      }

      private void UpdateControls( )
      {
         _lblPage.Text = string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_Page") + " {0}:{1}", Image.Page, Image.PageCount);
         _btnPageFirst.Enabled = Image.Page > 1;
         _btnPagePrevious.Enabled = Image.Page > 1;
         _btnPageNext.Enabled = Image.Page < Image.PageCount;
         _btnPageLast.Enabled = Image.Page < Image.PageCount;

         int index = 0;
         _lvInfo.Items[index++].SubItems[1].Text = Image.OriginalFormat.ToString();
         _lvInfo.Items[index++].SubItems[1].Text = string.Format("{0} x {1} " + DemosGlobalization.GetResxString(GetType(), "Resx_Pixels"), Image.Width, Image.Height);
         _lvInfo.Items[index++].SubItems[1].Text = string.Format("{0} x {1} " + DemosGlobalization.GetResxString(GetType(), "Resx_Pixels"), Image.ImageWidth, Image.ImageHeight);
         _lvInfo.Items[index++].SubItems[1].Text = string.Format("{0} x {1} " + DemosGlobalization.GetResxString(GetType(), "Resx_dpi"), Image.XResolution, Image.YResolution);
         _lvInfo.Items[index++].SubItems[1].Text = Image.BitsPerPixel.ToString();
         _lvInfo.Items[index++].SubItems[1].Text = Image.BytesPerLine.ToString();
         _lvInfo.Items[index++].SubItems[1].Text = Image.DataSize.ToString();
         _lvInfo.Items[index++].SubItems[1].Text = Constants.GetNameFromValue(typeof(RasterViewPerspective), Image.ViewPerspective);
         _lvInfo.Items[index++].SubItems[1].Text = Constants.GetNameFromValue(typeof(RasterByteOrder), Image.Order);
         _lvInfo.Items[index++].SubItems[1].Text = Image.HasRegion ? DemosGlobalization.GetResxString(GetType(), "Resx_Yes") : DemosGlobalization.GetResxString(GetType(), "Resx_No");
         if(Image.IsCompressed)
            _lvInfo.Items[index++].SubItems[1].Text = DemosGlobalization.GetResxString(GetType(), "Resx_RunLengthLimited");
         else
            _lvInfo.Items[index++].SubItems[1].Text = DemosGlobalization.GetResxString(GetType(), "Resx_NotCompressed");

         if(Image.IsDiskMemory)
            _lvInfo.Items[index++].SubItems[1].Text = DemosGlobalization.GetResxString(GetType(), "Resx_Disk");
         else if(Image.IsTiled)
            _lvInfo.Items[index++].SubItems[1].Text = DemosGlobalization.GetResxString(GetType(), "Resx_Tiled");
         else if(Image.IsConventionalMemory)
            _lvInfo.Items[index++].SubItems[1].Text = DemosGlobalization.GetResxString(GetType(), "Resx_ManagedMemory");
         else
            _lvInfo.Items[index++].SubItems[1].Text = DemosGlobalization.GetResxString(GetType(), "Resx_UnmanagedMemory");

         _lvInfo.Items[index++].SubItems[1].Text = Image.Signed ? DemosGlobalization.GetResxString(GetType(), "Resx_Yes") : DemosGlobalization.GetResxString(GetType(), "Resx_No");
         _lvInfo.Items[index++].SubItems[1].Text = Constants.GetNameFromValue(typeof(RasterGrayscaleMode), Image.GrayscaleMode);

         _lvInfo.Items[index++].SubItems[1].Text = Image.LowBit.ToString();
         _lvInfo.Items[index++].SubItems[1].Text = Image.HighBit.ToString();

         foreach (var data in Image.CustomData)
         {
            if (index == _lvInfo.Items.Count)
            {
               var item = new ListViewItem(string.Format("{0}:", data.Key));
               item.SubItems.Add(new ListViewItem.ListViewSubItem(item, data.Value.ToString()));
               _lvInfo.Items.Add(item);
            }
            else
            {
               var item = new ListViewItem(string.Format("{0}:", data.Key));
               item.SubItems.Add(new ListViewItem.ListViewSubItem(item, data.Value.ToString()));

               _lvInfo.Items[index].SubItems[0].Text = item.Text;
               _lvInfo.Items[index++].SubItems[1].Text = item.SubItems[1].Text;
            }
         }

         RasterColor[] palette = Image.GetPalette();
         _btnPalette.Enabled = palette != null && palette.Length > 0;
      }

      private void _btnPalette_Click(object sender, System.EventArgs e)
      {
         PaletteDialog dlg = new PaletteDialog();
         dlg.Palette = Image.GetPalette();
         dlg.ShowDialog(this);
      }

      private void _btnPageFirst_Click(object sender, System.EventArgs e)
      {
         Image.Page = 1;
         UpdateControls();
      }

      private void _btnPagePrevious_Click(object sender, System.EventArgs e)
      {
         Image.Page--;
         UpdateControls();
      }

      private void _btnPageNext_Click(object sender, System.EventArgs e)
      {
         Image.Page++;
         UpdateControls();
      }

      private void _btnPageLast_Click(object sender, System.EventArgs e)
      {
         Image.Page = Image.PageCount;
         UpdateControls();
      }
   }
}
