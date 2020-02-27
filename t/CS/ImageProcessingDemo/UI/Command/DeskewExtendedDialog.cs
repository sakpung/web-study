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

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the DeskewExtendedCommand

   public partial class DeskewExtendedDialog : Form
   {
      private DeskewExtendedCommand _DeskewExtendedCommand = null;
      private RasterColor _Color;
      private int _AngleRange;
      private RasterImage _image;

      public DeskewExtendedDialog(RasterImage image)
      {
         InitializeComponent();
         _DeskewExtendedCommand = new DeskewExtendedCommand();
         _Color = Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black);
         _AngleRange = 2000;
         _image = image;
         _rbFast.Enabled = (_image.BitsPerPixel == 1);

         //Set command default values
         InitializeUI();
      }
      public DeskewExtendedDialog(DeskewExtendedCommand DeskewExtendedCommand)
      {
         InitializeComponent();
         _DeskewExtendedCommand = DeskewExtendedCommand;
         InitializeUI();
      }
      public DeskewExtendedCommand DeskewExtendedCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _DeskewExtendedCommand;
         }
         set
         {
            _DeskewExtendedCommand = value;
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
         if ((_DeskewExtendedCommand.Flags & DeskewExtendedCommandFlags.FillExposedArea) == DeskewExtendedCommandFlags.FillExposedArea)
         {
            _cbFillExposedArea.Checked = true;
            _lblColor.BackColor = Leadtools.Demos.Converters.ToGdiPlusColor(_DeskewExtendedCommand.FillColor);
            _Color = Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black);
            _lblColor.Enabled = true;
         }

         // Threshold
         if ((_DeskewExtendedCommand.Flags & DeskewExtendedCommandFlags.Threshold) == DeskewExtendedCommandFlags.Threshold)
         {
            _cbThreshold.Checked = true;
         }

         // Quality
         if ((_DeskewExtendedCommand.Flags & DeskewExtendedCommandFlags.RotateLinear) == DeskewExtendedCommandFlags.RotateLinear)
         {
            _rbLow.Checked = true;
         }
         if ((_DeskewExtendedCommand.Flags & DeskewExtendedCommandFlags.RotateResample) == DeskewExtendedCommandFlags.RotateResample)
         {
            _rbMedium.Checked = true;
         }
         if ((_DeskewExtendedCommand.Flags & DeskewExtendedCommandFlags.RotateBicubic) == DeskewExtendedCommandFlags.RotateBicubic)
         {
            _rbHigh.Checked = true;
         }

         // Type
         if ((_DeskewExtendedCommand.Flags & DeskewExtendedCommandFlags.DocumentImage) == DeskewExtendedCommandFlags.DocumentImage)
         {
            _rbTextOnly.Checked = true;
         }
         if ((_DeskewExtendedCommand.Flags & DeskewExtendedCommandFlags.DocumentAndTextImage) == DeskewExtendedCommandFlags.DocumentAndTextImage)
         {
            _rbTextImages.Checked = true;
         }

         // Speed
         if ((_DeskewExtendedCommand.Flags & DeskewExtendedCommandFlags.UseNormalRotate) == DeskewExtendedCommandFlags.UseNormalRotate)
         {
            _rbNormal.Checked = true;
         }
         if ((_DeskewExtendedCommand.Flags & DeskewExtendedCommandFlags.UseHighSpeedRotate) == DeskewExtendedCommandFlags.UseHighSpeedRotate)
         {
            _rbFast.Checked = true;
         }

         _txbAngleRange.Text = _AngleRange.ToString();
         _numAngleResolution.Value = 20;         
      }

      private void UpdateCommand()
      {
         _DeskewExtendedCommand.Flags = (DeskewExtendedCommandFlags)0;

         // Fill
         if (_cbFillExposedArea.Checked)
         {
            _DeskewExtendedCommand.Flags |= DeskewExtendedCommandFlags.FillExposedArea;
         }
         else
            _DeskewExtendedCommand.Flags |= DeskewExtendedCommandFlags.DoNotFillExposedArea;

         // Threshold
         if (_cbThreshold.Checked)
            _DeskewExtendedCommand.Flags |= DeskewExtendedCommandFlags.Threshold;
         else
            _DeskewExtendedCommand.Flags |= DeskewExtendedCommandFlags.NoThreshold;

         // Quality
         if (_rbLow.Checked)
         {
            _DeskewExtendedCommand.Flags |= DeskewExtendedCommandFlags.RotateLinear;
         }
         else if (_rbMedium.Checked)
         {
            _DeskewExtendedCommand.Flags |= DeskewExtendedCommandFlags.RotateResample;
         }
         else
         {
            _DeskewExtendedCommand.Flags |= DeskewExtendedCommandFlags.RotateBicubic;
         }

         // Type
         if (_rbTextOnly.Checked)
         {
            _DeskewExtendedCommand.Flags |= DeskewExtendedCommandFlags.DocumentImage;
         }
         else
         {
            _DeskewExtendedCommand.Flags |= DeskewExtendedCommandFlags.DocumentAndTextImage;
         }

         // Speed
         if (_rbNormal.Checked)
         {
            _DeskewExtendedCommand.Flags |= DeskewExtendedCommandFlags.UseNormalRotate;
         }
         else
         {
            _DeskewExtendedCommand.Flags |= DeskewExtendedCommandFlags.UseHighSpeedRotate;
         }

         _DeskewExtendedCommand.AngleRange = Convert.ToInt32(_txbAngleRange.Text);
         _DeskewExtendedCommand.AngleResolution = Convert.ToInt32(_numAngleResolution.Value);
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

      private void _tbAngleRange_Scroll(object sender, EventArgs e)
      {
         _txbAngleRange.Text = _tbAngleRange.Value.ToString();         
      }

      private void _txbAngleRange_TextChanged(object sender, EventArgs e)
      {
         try
         {
            _txbAngleRange.Text = MainForm.IsValidNumber(_txbAngleRange.Text, 1, 4500);

            int Val = int.Parse(_txbAngleRange.Text);
            if (Val >= _tbAngleRange.Minimum && Val <= _tbAngleRange.Maximum)
               _tbAngleRange.Value = Val;

            if (_numAngleResolution.Value > Convert.ToInt32(_txbAngleRange.Text))
            {
               _numAngleResolution.Value = Convert.ToInt32(_txbAngleRange.Text);
            }
         }
         catch
         {
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

      private void _numAngleResolution_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
         if (_numAngleResolution.Value > Convert.ToInt32(_txbAngleRange.Text))
         {
            _numAngleResolution.Value = Convert.ToInt32(_txbAngleRange.Text);
         }
      }

      private void _numAngleResolution_ValueChanged(object sender, EventArgs e)
      {
         if (_numAngleResolution.Value > Convert.ToInt32(_txbAngleRange.Text))
         {
            _numAngleResolution.Value = Convert.ToInt32(_txbAngleRange.Text);
         }
      }
   }
}
