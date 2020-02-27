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
using Leadtools.ImageProcessing.Core;
using Leadtools.Demos;

namespace DocumentCleanupDemo
{
   public partial class DeskewDialog : Form
   {
      // The DeskewCommand Class is part our LEAD Document Imaging funcions, this class will rotate the specified image to straighten it. This command is typically used to automatically straighten scanned images
      // This dialog will use the DeskewCommandFlags, these flags will indicate whether to deskew the image, which background color to use, whether to deskew the image if the skew angle is very small, which type of interpolation to use, whether the image contains mostly text, and whether to use normal or fast rotation. 
      // The Flags used are:
      // DeskewCommandFlags.FillExposedArea, this flag is ued to fill areas exposed by rotation using the FillColor property
      // DeskewCommandFlags.Threshold, this flag determines if you can deskew the image if the deskew angle is very small (less than 0.5 degrees).  
      // DeskewCommandFlags.RotateLinear, this flag will not allow performing any interpolation methods when rotating 
      // DeskewCommandFlags.DocumentImage, this flag will rotate the image. 

      private DeskewCommand _DeskewCommand = null;
      public DeskewDialog()
      {
         InitializeComponent();
         _DeskewCommand = new DeskewCommand();
         InitializeUI();
      }
      public DeskewDialog(DeskewCommand DeskewCommand)
      {
         InitializeComponent();
         _DeskewCommand = DeskewCommand;
         InitializeUI();
      }
      public DeskewCommand DeskewCommand
      {
         get
         {
            UpdateCommand();
            return _DeskewCommand;
         }
         set
         {
            _DeskewCommand = value;
            InitializeUI();
         }
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

      private void InitializeUI()
      {
         // Initialize the DeskewCommand Dialog with default values
         // Fill
         if ((_DeskewCommand.Flags & DeskewCommandFlags.FillExposedArea) == DeskewCommandFlags.FillExposedArea)
         {
            _cbFillExposedArea.Checked = true;
            _lblColor.BackColor = Converters.ToGdiPlusColor(_DeskewCommand.FillColor);
            _lblColor.Enabled = true;
         }

         // Threshold
         if ((_DeskewCommand.Flags & DeskewCommandFlags.Threshold) == DeskewCommandFlags.Threshold)
         {
            _cbThreshold.Checked = true;
         }

         // Quality
         if ((_DeskewCommand.Flags & DeskewCommandFlags.RotateLinear) == DeskewCommandFlags.RotateLinear)
         {
            _rbLow.Checked = true;
         }
         if ((_DeskewCommand.Flags & DeskewCommandFlags.RotateResample) == DeskewCommandFlags.RotateResample)
         {
            _rbMedium.Checked = true;
         }
         if ((_DeskewCommand.Flags & DeskewCommandFlags.RotateBicubic) == DeskewCommandFlags.RotateBicubic)
         {
            _rbHigh.Checked = true;
         }

         // Type
         if ((_DeskewCommand.Flags & DeskewCommandFlags.DocumentImage) == DeskewCommandFlags.DocumentImage)
         {
            _rbTextOnly.Checked = true;
         }
         if ((_DeskewCommand.Flags & DeskewCommandFlags.DocumentAndPictures) == DeskewCommandFlags.DocumentAndPictures)
         {
            _rbTextImages.Checked = true;
         }

         // Speed
         if ((_DeskewCommand.Flags & DeskewCommandFlags.UseNormalRotate) == DeskewCommandFlags.UseNormalRotate)
         {
            _rbNormal.Checked = true;
         }
         if ((_DeskewCommand.Flags & DeskewCommandFlags.UseHighSpeedRotate) == DeskewCommandFlags.UseHighSpeedRotate)
         {
            _rbFast.Checked = true;
         }
      }

      private void UpdateCommand()
      {
         // Determine how the DeskewCommand will work by setting the values to its members and flags
         _DeskewCommand.Flags = (DeskewCommandFlags)0;

         // Fill
         if (_cbFillExposedArea.Checked)
         {
            _DeskewCommand.Flags |= DeskewCommandFlags.FillExposedArea;
            _DeskewCommand.FillColor = Converters.FromGdiPlusColor(_lblColor.BackColor);
         }
         else
            _DeskewCommand.Flags |= DeskewCommandFlags.DoNotFillExposedArea;

         // Threshold
         if (_cbThreshold.Checked)
            _DeskewCommand.Flags |= DeskewCommandFlags.Threshold;
         else
            _DeskewCommand.Flags |= DeskewCommandFlags.NoThreshold;

         // Quality
         if (_rbLow.Checked)
         {
            _DeskewCommand.Flags |= DeskewCommandFlags.RotateLinear;
         }
         else if (_rbMedium.Checked)
         {
            _DeskewCommand.Flags |= DeskewCommandFlags.RotateResample;
         }
         else
         {
            _DeskewCommand.Flags |= DeskewCommandFlags.RotateBicubic;
         }

         // Type
         if (_rbTextOnly.Checked)
         {
            _DeskewCommand.Flags |= DeskewCommandFlags.DocumentImage;
         }
         else
         {
            _DeskewCommand.Flags |= DeskewCommandFlags.DocumentAndPictures;
         }

         // Speed
         if (_rbNormal.Checked)
         {
            _DeskewCommand.Flags |= DeskewCommandFlags.UseNormalRotate;
         }
         else
         {
            _DeskewCommand.Flags |= DeskewCommandFlags.UseHighSpeedRotate;
         }
      }

      private void _cbFillExposedArea_CheckedChanged(object sender, EventArgs e)
      {
         _lblColor.Enabled = _cbFillExposedArea.Checked;
      }

      private void lblColor_Click(object sender, EventArgs e)
      {
         ColorDialog dlg = new ColorDialog();
         dlg.Color = _lblColor.BackColor;
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            _lblColor.BackColor = dlg.Color;
         }
      }
   }
}
