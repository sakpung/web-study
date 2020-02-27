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
using Leadtools.ImageProcessing;
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
   //will be used for the CropCommand
   public partial class CropDialog : Form
   {
      private RasterImage _CropImage;
      private CropCommand _CropCommand;
      private int _X;
      private int _Y;
      private int _Width;
      private int _Height;

      public CropDialog()
      {
         InitializeComponent();
         _CropCommand = new CropCommand();
         
         //Set command default values
         InitializeUI();

      }
      public CropDialog(CropCommand Cropcommand, RasterImage CropImage)
      {
         InitializeComponent();
         _CropCommand = Cropcommand;
         _CropImage = CropImage;
         InitializeUI();
      }

      public RasterImage CropImage
      {
         get
         {
            return _CropImage;
         }
         set
         {
            _CropImage = value;
         }
      }

      public CropCommand Cropcommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _CropCommand;
         }
         set
         {
            _CropCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {
         _X = _CropImage.Width / 8;
         _Y = _CropImage.Height / 8;
         _Width = _CropImage.Width - _X * 2;
         _Height = _CropImage.Height - _Y * 2;

         _numX.Maximum = _CropImage.Width;
         _numX.Value = _X;

         _numY.Maximum = _CropImage.Height;
         _numY.Value = _Y;

         _numWidth.Maximum = _CropImage.Width;
         _numWidth.Value = _Width;

         _numHeight.Maximum = _CropImage.Height;
         _numHeight.Value = _Height;
      }
      private void UpdateCommand()
      {
         _X = Convert.ToInt32(_numX.Value);
         _Y = Convert.ToInt32(_numY.Value);
         _Width = Convert.ToInt32(_numWidth.Value);
         _Height = Convert.ToInt32(_numHeight.Value);

         _CropCommand.Rectangle = new LeadRect(_X, _Y, _Width, _Height);
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         UpdateCommand();
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         InitializeUI();
         this.DialogResult = DialogResult.Cancel;
      }

      private void _numX_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numY_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numWidth_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numHeight_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }
   }
}
