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
using System.IO;
using System.Diagnostics;

using Leadtools.Ocr;
using Leadtools.Codecs;

namespace OcrDemo
{
   public partial class LoadResolutionDialog : Form
   {
      private RasterCodecs _rasterCodecs;

      public LoadResolutionDialog(RasterCodecs codecs)
      {
         InitializeComponent();

         _rasterCodecs = codecs;
      }

      protected override void OnLoad(EventArgs e)
      {
         if(!DesignMode)
         {
            _xResolutionTextBox.Text = _rasterCodecs.Options.RasterizeDocument.Load.XResolution.ToString();
            _yResolutionTextBox.Text = _rasterCodecs.Options.RasterizeDocument.Load.YResolution.ToString();
         }

         base.OnLoad(e);
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         int value = 0;
         if(int.TryParse(_xResolutionTextBox.Text, out value))
            _rasterCodecs.Options.RasterizeDocument.Load.XResolution = value;

         if (int.TryParse(_yResolutionTextBox.Text, out value))
            _rasterCodecs.Options.RasterizeDocument.Load.YResolution = value;
      }
   }
}
