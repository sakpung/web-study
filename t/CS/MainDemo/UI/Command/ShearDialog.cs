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

namespace MainDemo
{
   public partial class ShearDialog : Form
   {
      private static bool _firstTimer = true;
      private static int _initialAngle;
      private static bool _initialHorizontal;
      private static RasterColor _initialFillColor;

      public int Angle;
      public bool Horizontal;
      public RasterColor FillColor;

      public ShearDialog( )
      {
         InitializeComponent();
      }

      private void ShearDialog_Load(object sender, System.EventArgs e)
      {
         if(_firstTimer)
         {
            _firstTimer = false;
            ShearCommand command = new ShearCommand();
            _initialAngle = command.Angle;
            _initialHorizontal = command.Horizontal;
            _initialFillColor = command.FillColor;
         }

         Angle = _initialAngle / 100;
         Horizontal = _initialHorizontal;
         FillColor = _initialFillColor;

         _numAngle.Value = Angle;

         _rbHorizontal.Checked = Horizontal;
         _rbVertical.Checked = !Horizontal;
      }

      private void _num_Leave(object sender, System.EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _pnlFillColor_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
      {
         e.Graphics.FillRectangle(new SolidBrush(Converters.ToGdiPlusColor(FillColor)), _pnlFillColor.ClientRectangle);
      }

      private void _btnFillColor_Click(object sender, System.EventArgs e)
      {
         if(Tools.ShowColorDialog(this, ref FillColor))
            _pnlFillColor.Refresh();
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         Angle = (int)_numAngle.Value * 100;
         Horizontal = _rbHorizontal.Checked;

         _initialAngle = Angle;
         _initialHorizontal = Horizontal;
         _initialFillColor = FillColor;
      }
   }
}
