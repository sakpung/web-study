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

using Leadtools.ImageProcessing;

namespace GrayScaleDemo
{
   public partial class GrayScaleDialog : Form
   {
      private static bool _firstTimer = true;
      private static int _initialBitsPerPixel;
      public int BitsPerPixel;

      public GrayScaleDialog( )
      {
         InitializeComponent();
      }

      private void GrayScaleDialog_Load(object sender, System.EventArgs e)
      {
         if(_firstTimer)
         {
            _firstTimer = false;
            GrayscaleCommand command = new GrayscaleCommand();
            _initialBitsPerPixel = command.BitsPerPixel;
         }

         BitsPerPixel = _initialBitsPerPixel;

         if(BitsPerPixel == 8)
            _rb8.Checked = true;
         else if(BitsPerPixel == 12)
            _rb12.Checked = true;
         else if(BitsPerPixel == 16)
            _rb16.Checked = true;
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         if(_rb8.Checked)
            BitsPerPixel = 8;
         else if(_rb12.Checked)
            BitsPerPixel = 12;
         else if(_rb16.Checked)
            BitsPerPixel = 16;

         _initialBitsPerPixel = BitsPerPixel;
      }

   }
}
