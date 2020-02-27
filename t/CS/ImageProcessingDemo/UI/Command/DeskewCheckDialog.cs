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
   //will be used for the DeskewCheckCommand

   public partial class DeskewCheckDialog : Form
   {
      private DeskewCheckCommand _DeskewCheckCommand = null;
      private RasterColor _Color;
      private RasterImage _image;
      public bool ReturnAngleOnly = false;

      public DeskewCheckDialog(RasterImage image)
      {
         _image = image;
         InitializeComponent();
         _DeskewCheckCommand = new DeskewCheckCommand();
         _Color = Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black);
         _rbFast.Enabled = (_image.BitsPerPixel == 1);

         //Set command default values
         InitializeUI();
      }
      public DeskewCheckDialog(DeskewCheckCommand DeskewCheckCommand)
      {
         InitializeComponent();
         _DeskewCheckCommand = DeskewCheckCommand;
         InitializeUI();
      }
      public DeskewCheckCommand DeskewCheckCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _DeskewCheckCommand;
         }
         set
         {
            _DeskewCheckCommand = value;
            InitializeUI();
         }
      }

      public RasterColor color
      {
         get
         {
            return _Color;
         }
         set
         {
            _Color = value;
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
         if ((_DeskewCheckCommand.Flags & DeskewCheckCommandFlags.FillExposedArea) == DeskewCheckCommandFlags.FillExposedArea)
         {
            _cbFillExposedArea.Checked = true;
            _lblColor.BackColor = Leadtools.Demos.Converters.ToGdiPlusColor(_DeskewCheckCommand.FillColor);
            _Color = Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black);
            _lblColor.Enabled = true;
         }
         //Deskew Image
         if ((_DeskewCheckCommand.Flags & DeskewCheckCommandFlags.DeskewImage) == DeskewCheckCommandFlags.DeskewImage)
         {
            _rbDeskewImage.Checked = true;
         }

         if ((_DeskewCheckCommand.Flags & DeskewCheckCommandFlags.ReturnAngleOnly) == DeskewCheckCommandFlags.ReturnAngleOnly)
         {
            _rbReturnAngleOnly.Checked = true;
         }
         // Threshold
         if ((_DeskewCheckCommand.Flags & DeskewCheckCommandFlags.Threshold) == DeskewCheckCommandFlags.Threshold)
         {
            _cbThreshold.Checked = true;
         }

         // Quality
         if ((_DeskewCheckCommand.Flags & DeskewCheckCommandFlags.RotateLinear) == DeskewCheckCommandFlags.RotateLinear)
         {
            _rbLow.Checked = true;
         }
         if ((_DeskewCheckCommand.Flags & DeskewCheckCommandFlags.RotateResample) == DeskewCheckCommandFlags.RotateResample)
         {
            _rbMedium.Checked = true;
         }
         if ((_DeskewCheckCommand.Flags & DeskewCheckCommandFlags.RotateBicubic) == DeskewCheckCommandFlags.RotateBicubic)
         {
            _rbHigh.Checked = true;
         }

         // Type
         if ((_DeskewCheckCommand.Flags & DeskewCheckCommandFlags.DocumentImage) == DeskewCheckCommandFlags.DocumentImage)
         {
            _rbTextOnly.Checked = true;
         }
         if ((_DeskewCheckCommand.Flags & DeskewCheckCommandFlags.DocumentAndPictures) == DeskewCheckCommandFlags.DocumentAndPictures)
         {
            _rbTextImages.Checked = true;
         }

         // Speed
         if ((_DeskewCheckCommand.Flags & DeskewCheckCommandFlags.UseNormalRotate) == DeskewCheckCommandFlags.UseNormalRotate)
         {
            _rbNormal.Checked = true;
         }
         if ((_DeskewCheckCommand.Flags & DeskewCheckCommandFlags.UseHighSpeedRotate) == DeskewCheckCommandFlags.UseHighSpeedRotate)
         {
            _rbFast.Checked = true;
         }

         //Algorithm
         if ((_DeskewCheckCommand.Flags & DeskewCheckCommandFlags.DoNotUseCheckDeskew) == DeskewCheckCommandFlags.DoNotUseCheckDeskew)
         {
            _rbOrdinaryDeskew.Checked = true;
         }
         if ((_DeskewCheckCommand.Flags & DeskewCheckCommandFlags.UseNormalCheckDeskew) == DeskewCheckCommandFlags.UseNormalCheckDeskew)
         {
            _rbBankCheckDeskew.Checked = true;
         }

         if ((_DeskewCheckCommand.Flags & DeskewCheckCommandFlags.UseLineDetectionToDeskewCheck) == DeskewCheckCommandFlags.UseLineDetectionToDeskewCheck)
         {
            _rbLineDetectionDeskew.Checked = true;
         }
      }

      private void UpdateCommand()
      {
         //DeskewCheckCommand.FillColor = new RasterColor(Color.Red);// _Color;
         _DeskewCheckCommand.Flags = (DeskewCheckCommandFlags)0;

         // Fill
         if (_cbFillExposedArea.Checked)
         {
            _DeskewCheckCommand.Flags |= DeskewCheckCommandFlags.FillExposedArea;
         }
         else
            _DeskewCheckCommand.Flags |= DeskewCheckCommandFlags.DoNotFillExposedArea;

         //Deskew Image
         if (_rbDeskewImage.Checked)
            _DeskewCheckCommand.Flags |= DeskewCheckCommandFlags.DeskewImage;
         else
         {
            _DeskewCheckCommand.Flags |= DeskewCheckCommandFlags.ReturnAngleOnly;
            ReturnAngleOnly = true;
         }

         // Threshold
         if (_cbThreshold.Checked)
            _DeskewCheckCommand.Flags |= DeskewCheckCommandFlags.Threshold;
         else
            _DeskewCheckCommand.Flags |= DeskewCheckCommandFlags.NoThreshold;

         // Quality
         if (_rbLow.Checked)
         {
            _DeskewCheckCommand.Flags |= DeskewCheckCommandFlags.RotateLinear;
         }
         else if (_rbMedium.Checked)
         {
            _DeskewCheckCommand.Flags |= DeskewCheckCommandFlags.RotateResample;
         }
         else
         {
            _DeskewCheckCommand.Flags |= DeskewCheckCommandFlags.RotateBicubic;
         }

         // Type
         if (_rbTextOnly.Checked)
         {
            _DeskewCheckCommand.Flags |= DeskewCheckCommandFlags.DocumentImage;
         }
         else
         {
            _DeskewCheckCommand.Flags |= DeskewCheckCommandFlags.DocumentAndPictures;
         }

         // Speed
         if (_rbNormal.Checked)
         {
            _DeskewCheckCommand.Flags |= DeskewCheckCommandFlags.UseNormalRotate;
         }
         else
         {
            _DeskewCheckCommand.Flags |= DeskewCheckCommandFlags.UseHighSpeedRotate;
         }

         //Algorithm
         if (_rbOrdinaryDeskew.Checked)
            _DeskewCheckCommand.Flags |= DeskewCheckCommandFlags.DoNotUseCheckDeskew;
         if (_rbBankCheckDeskew.Checked)
            _DeskewCheckCommand.Flags |= DeskewCheckCommandFlags.UseNormalCheckDeskew;
         if (_rbLineDetectionDeskew.Checked)
            _DeskewCheckCommand.Flags |= DeskewCheckCommandFlags.UseLineDetectionToDeskewCheck;


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
            _Color = Leadtools.Demos.Converters.FromGdiPlusColor(dlg.Color);
         }
      }

      private void _btnColor_Click(object sender, EventArgs e)
      {
         ColorDialog dlg = new ColorDialog();
         dlg.AllowFullOpen = true;
         dlg.AnyColor = true;
         DialogResult res = dlg.ShowDialog(this);
         if (res == DialogResult.OK)
            _Color = Leadtools.Demos.Converters.FromGdiPlusColor(dlg.Color);
         _lblColor.Refresh();
      }

      private void _lblColor_Paint(object sender, PaintEventArgs e)
      {
         e.Graphics.FillRectangle(new SolidBrush(Leadtools.Demos.Converters.ToGdiPlusColor(_Color)), _lblColor.ClientRectangle);
      }
   }
}
