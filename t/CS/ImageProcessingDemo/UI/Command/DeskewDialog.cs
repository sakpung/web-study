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

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the DeskewCommand
   public partial class DeskewDialog : Form
   {
      private DeskewCommand _DeskewCommand = null;
      public DeskewDialog()
      {
         InitializeComponent();
         _DeskewCommand = new DeskewCommand();
         
         //Set command default values
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
            //Update command values
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
         // Fill
         if ((_DeskewCommand.Flags & DeskewCommandFlags.FillExposedArea) == DeskewCommandFlags.FillExposedArea)
         {
            _cbFillExposedArea.Checked = true;
            _lblColor.BackColor = Leadtools.Demos.Converters.ToGdiPlusColor(_DeskewCommand.FillColor);
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
         _DeskewCommand.Flags = (DeskewCommandFlags)0;

         // Fill
         if (_cbFillExposedArea.Checked)
         {
            _DeskewCommand.Flags |= DeskewCommandFlags.FillExposedArea;
            _DeskewCommand.FillColor = Leadtools.Demos.Converters.FromGdiPlusColor(_lblColor.BackColor);
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
