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

using Leadtools.Controls;
using Leadtools;

namespace GrayScaleDemo
{
   public partial class MagnifyGlassDialog : Form
   {
      ImageViewerMagnifyGlassInteractiveMode _magnifyGlass;

      public MagnifyGlassDialog(ImageViewerMagnifyGlassInteractiveMode MagnifyGlass)
      {
         InitializeComponent();
         _magnifyGlass = MagnifyGlass;
      }

      private void MagnifyGlassDialog_Load(object sender, EventArgs e)
      {
         try
         {
            _numBorderSize.Value = (decimal)_magnifyGlass.BorderPen.Width;
            _numHeight.Value = _magnifyGlass.Size.Height;
            _numWidth.Value = _magnifyGlass.Size.Width;
            _numScaleFactor.Value = (decimal)_magnifyGlass.ScaleFactor;
            _cmbShape.SelectedIndex = (int)_magnifyGlass.Shape;
            _txtInterSectionColor.BackColor = (_magnifyGlass.CrosshairPen.Brush as SolidBrush).Color;
            _txtBorderColor.BackColor = (_magnifyGlass.BorderPen.Brush as SolidBrush).Color;
         }
         catch (Exception)
         {
         }
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         _magnifyGlass.BorderPen = new Pen(_txtBorderColor.BackColor, Convert.ToInt32(_numBorderSize.Value));
         _magnifyGlass.Size = new LeadSize(Convert.ToInt32(_numWidth.Value), Convert.ToInt32(_numHeight.Value));
         _magnifyGlass.ScaleFactor = Convert.ToInt32(_numScaleFactor.Value);
         _magnifyGlass.Shape = (ImageViewerSpyGlassShape)_cmbShape.SelectedIndex;
         _magnifyGlass.CrosshairPen = new Pen(_txtInterSectionColor.BackColor);
      }

      private void Color_Click(object sender, EventArgs e)
      {
         ColorDialog colorDlg = new ColorDialog();
         if (colorDlg.ShowDialog() == DialogResult.OK)
         {
            if (sender == _btnBorderColor)
            {
               _txtBorderColor.BackColor = colorDlg.Color;
            }
            else if (sender == _btnIntersectionColor)
               _txtInterSectionColor.BackColor = colorDlg.Color;
         }
      }
   }
}
