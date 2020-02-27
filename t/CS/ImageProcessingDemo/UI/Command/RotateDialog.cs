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
   //will be used for the RotateCommand

   public partial class RotateDialog : Form
   {
      private static int _initialAngle = 0;
      private static RotateCommandFlags _initialFlags = RotateCommandFlags.None;
      private static RasterColor _initialFillColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.White);

      public int Angle;
      public RotateCommandFlags Flags;
      public RasterColor FillColor;

      public RotateDialog()
      {
         InitializeComponent();
      }

      private void RotateDialog_Load(object sender, System.EventArgs e)
      {
         //Set command default values
         Angle = _initialAngle / 100;
         Flags = _initialFlags;
         FillColor = _initialFillColor;

         _numAngle.Value = Angle;
         _cbResize.Checked = (Flags & RotateCommandFlags.Resize) == RotateCommandFlags.Resize;

         if ((Flags & RotateCommandFlags.Resample) == RotateCommandFlags.Resample)
            _rbButtonResample.Checked = true;
         else if ((Flags & RotateCommandFlags.Bicubic) == RotateCommandFlags.Bicubic)
            _rbButtonBicubic.Checked = true;
         else
            _rbButtonNormal.Checked = true;
      }

      private void _num_Leave(object sender, System.EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _pnlFillColor_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
      {
         e.Graphics.FillRectangle(new SolidBrush(Leadtools.Demos.Converters.ToGdiPlusColor(FillColor)), _pnlFillColor.ClientRectangle);
      }

      private void _btnFillColor_Click(object sender, System.EventArgs e)
      {
         ColorDialog ColorDlg = new ColorDialog();
         ColorDlg.AllowFullOpen = true;
         ColorDlg.AnyColor = true;
         DialogResult res = ColorDlg.ShowDialog(this);
         if (res == DialogResult.OK)
            FillColor = Leadtools.Demos.Converters.FromGdiPlusColor(ColorDlg.Color);

         _pnlFillColor.Refresh();
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         //Update command values
         Angle = (int)_numAngle.Value * 100;

         Flags = RotateCommandFlags.None;

         if (_cbResize.Checked)
            Flags |= RotateCommandFlags.Resize;

         if (_rbButtonResample.Checked)
            Flags |= RotateCommandFlags.Resample;

         if (_rbButtonBicubic.Checked)
            Flags |= RotateCommandFlags.Bicubic;

         _initialAngle = Angle;
         _initialFlags = Flags;
         _initialFillColor = FillColor;
      }
   }
}
