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

using Leadtools.Demos;

namespace MainDemo
{
   public partial class CropDialog : Form
   {
      public int CropLeft;
      public int CropTop;
      public int CropWidth;
      public int CropHeight;

      public CropDialog(int imageWidth, int imageHeight)
      {
         InitializeComponent();

         CropWidth = imageWidth;
         CropHeight = imageHeight;
      }

      private void CropDialog_Load(object sender, System.EventArgs e)
      {
         CropLeft = 0;
         CropTop = 0;

         _numLeft.Value = CropLeft;
         _numTop.Value = CropTop;
         _numWidth.Value = CropWidth;
         _numHeight.Value = CropHeight;
      }

      private void _num_Leave(object sender, System.EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         CropLeft = (int)_numLeft.Value;
         CropTop = (int)_numTop.Value;
         CropWidth = (int)_numWidth.Value;
         CropHeight = (int)_numHeight.Value;
      }
   }
}
