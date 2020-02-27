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

using Leadtools.Codecs;

namespace OcrEditDemo
{
   public partial class LoadResolutionDialog : Form
   {
      private RasterCodecs _rasterCodecs;

      public LoadResolutionDialog(RasterCodecs codecs)
      {
         InitializeComponent();

         _rasterCodecs = codecs;

#if !LEADTOOLS_V175_OR_LATER
         _resolutionTextBox.Text = _rasterCodecs.Options.Pdf.Load.XResolution.ToString();
#else
         _resolutionTextBox.Text = _rasterCodecs.Options.RasterizeDocument.Load.XResolution.ToString();
#endif
      }

      private void _resolutionTextBox_KeyPress(object sender, KeyPressEventArgs e)
      {
         if(!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            e.Handled = true;
       }

      private void _resolutionTextBox_TextChanged(object sender, EventArgs e)
      {
         if(_resolutionTextBox.Text.Trim().Length > 0)
            _okButton.Enabled = true;
         else
            _okButton.Enabled = false;
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         // Check the values
         int resolution;

         if(!GetResolutionValue(_resolutionTextBox, out resolution))
         {
            DialogResult = DialogResult.None;
            return;
         }

         // Use the same value for X and Y resolution
#if !LEADTOOLS_V175_OR_LATER
         _rasterCodecs.Options.Pdf.Load.XResolution = resolution;
         _rasterCodecs.Options.Pdf.Load.YResolution = resolution;
#else
         _rasterCodecs.Options.RasterizeDocument.Load.XResolution = resolution;
         _rasterCodecs.Options.RasterizeDocument.Load.YResolution = resolution;
#endif
      }

      private bool GetResolutionValue(TextBox tb, out int resolution)
      {
         bool ok = false;

         // First try to parse it
         if(int.TryParse(tb.Text, out resolution))
         {
            // Success, make sure it is between 10 and 10000
            if(resolution >= 10 && resolution <= 10000)
               ok = true;
         }

         if(!ok)
         {
            MessageBox.Show(this, "Resolution must be a value between 10 and 10000", "PDF Resolution", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            tb.SelectAll();
            tb.Focus();
         }

         return ok;
      }
   }
}
