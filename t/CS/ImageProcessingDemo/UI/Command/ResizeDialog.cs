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
using Leadtools;
using Leadtools.ImageProcessing;

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the sizeCommand

   public partial class ResizeDialog : Form
   {
      private static RasterSizeFlags _initialFlags = RasterSizeFlags.FavorBlack | RasterSizeFlags.Resample;

      public int ImageWidth;
      public int ImageHeight;
      public RasterSizeFlags Flags;

      public ResizeDialog(int imageWidth, int imageHeight)
      {
         InitializeComponent();

         //Set command default values
         ImageWidth = imageWidth;
         ImageHeight = imageHeight;
      }

      private void ResizeDialog_Load(object sender, System.EventArgs e)
      {
         //Set command default values
         Flags = _initialFlags;

         _numWidth.Value = ImageWidth;
         _numHeight.Value = ImageHeight;

         switch (Flags)
         {
            case RasterSizeFlags.FavorBlack:
               _rbButtonFavorBlack.Checked = true;
               break;

            case RasterSizeFlags.Resample:
               _rbButtonResample.Checked = true;
               break;

            case RasterSizeFlags.FavorBlack | RasterSizeFlags.Resample:
               _rbButtonFavorBlackOrResample.Checked = true;
               break;

            case RasterSizeFlags.Bicubic:
               _rbButtonBicubic.Checked = true;
               break;

            case RasterSizeFlags.Bicubic | RasterSizeFlags.FavorBlack:
               _rbButtonFavorBlackOrBicubic.Checked = true;
               break;

            default:
               _rbButtonNormal.Checked = true;
               break;
         }
      }

      private void _num_Leave(object sender, System.EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         //Update command values
         ImageWidth = (int)_numWidth.Value;
         ImageHeight = (int)_numHeight.Value;

         if (_rbButtonNormal.Checked)
            Flags = RasterSizeFlags.None;
         else if (_rbButtonFavorBlack.Checked)
            Flags = RasterSizeFlags.FavorBlack;
         else if (_rbButtonResample.Checked)
            Flags = RasterSizeFlags.Resample;
         else if (_rbButtonFavorBlackOrResample.Checked)
            Flags = RasterSizeFlags.FavorBlack | RasterSizeFlags.Resample;
         else if (_rbButtonBicubic.Checked)
            Flags = RasterSizeFlags.Bicubic;
         else if (_rbButtonFavorBlackOrBicubic.Checked)
            Flags = RasterSizeFlags.FavorBlack | RasterSizeFlags.Bicubic;

         _initialFlags = Flags;
      }

   }
}
