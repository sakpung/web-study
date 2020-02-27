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
using Leadtools.ImageProcessing.Effects;
using Leadtools.Demos;

#if ! LEADTOOLS_V17_OR_LATER
using LeadPoint = System.Drawing.Point;
using LeadSize = System.Drawing.Size;
using LeadRect = System.Drawing.Rectangle;
#endif // #if !LEADTOOLS_V17_OR_LATER

#if LEADTOOLS_V17_OR_LATER
using Leadtools.Drawing;
#endif // #if LEADTOOLS_V17_OR_LATER

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the AlphaBlendCommand
   public partial class AlphaBlendDialog : Form
   {
      private AlphaBlendCommand _AlphaBlendCommand;
      private int _X1, _Y1, _Width, _Height, _X2, _Y2;

      public AlphaBlendDialog(RasterImage TempImage)
      {
         InitializeComponent();
         _AlphaBlendCommand = new AlphaBlendCommand();
         _X1 = TempImage.Width / 8;
         _Y1 = TempImage.Height / 8;
         _Width = TempImage.Width;
         _Height = TempImage.Height;
         _X2 = 0;
         _Y2 = 0;

         _numOpacity.Minimum = 0;
         _tbOpacity.Minimum = 0;
         if ((TempImage.BitsPerPixel == 64) || (TempImage.BitsPerPixel == 48) || (TempImage.BitsPerPixel == 16))
         {
            _numOpacity.Maximum = 65535;
            _tbOpacity.Maximum = 65535;
         }
         else if (TempImage.BitsPerPixel == 12)
         {
            _numOpacity.Maximum = 4095;
            _tbOpacity.Maximum = 4095;
         }
         else
         {
            _numOpacity.Maximum = 255;
            _tbOpacity.Maximum = 255;
         }

         _numOpacity.Value = 128;
         _tbOpacity.Value = 128;
         //Set command default values
         InitializeUI();
      }

      public AlphaBlendCommand AlphaBlendCommand
      {
         get
         {
            //Update command values
            UpdateCommand(); 
            return _AlphaBlendCommand; 
         }
         set
         {
            _AlphaBlendCommand = value;
            InitializeUI();
         }
      }
      private void InitializeUI()
      {
         _numX1.Maximum = _Width;
         _numX1.Value = _X1;

         _numY1.Maximum = _Height;
         _numY1.Value = _Y1;

         _numWidth.Maximum = _Width;
         _numWidth.Value = (int)(_Width / 2);

         _numHeight.Maximum = _Height;
         _numHeight.Value = (int)(_Height / 2);

         _numX2.Maximum = _Width;
         _numX2.Value = _X2; 

         _numY2.Maximum = _Height;
         _numY2.Value = _Y2;

         _numOpacity.Value = 128;
         _tbOpacity.Value = 128;
      }

      private void UpdateCommand()
      {
         _X1 = Convert.ToInt32(_numX1.Value);
         _Y1 = Convert.ToInt32(_numY1.Value);
         _Width = Convert.ToInt32(_numWidth.Value);
         _Height = Convert.ToInt32(_numHeight.Value);
         _X2 = Convert.ToInt32(_numX2.Value);
         _Y2 = Convert.ToInt32(_numY2.Value);

         _AlphaBlendCommand.DestinationRectangle = new LeadRect(_X1, _Y1, _Width, _Height);
         _AlphaBlendCommand.SourcePoint = new LeadPoint(_X2, _Y2);
         _AlphaBlendCommand.Opacity = Convert.ToInt32(_numOpacity.Value);
    }

      private void _numX1_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numWidth_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numY1_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numHeight_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numX2_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numY2_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numOpacity_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _tbOpacity_Scroll(object sender, EventArgs e)
      {
         _numOpacity.Value = _tbOpacity.Value;
      }

      private void _numOpacity_ValueChanged(object sender, EventArgs e)
      {
         _tbOpacity.Value = Convert.ToInt32(_numOpacity.Value);
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         UpdateCommand();
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
      }
   }
}
