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
using Leadtools.ImageProcessing.Core;
using Leadtools.Demos;

namespace MainDemo
{
   public partial class DeskewDialog : Form
   {
      private static bool _firstTimer = true;
      private static RasterColor _initialFillColor;
      private static DeskewCommandFlags _initialFlags;

      public RasterColor FillColor;
      public DeskewCommandFlags Flags;

      public DeskewDialog( )
      {
         InitializeComponent();
      }

      private void DeskewDialog_Load(object sender, System.EventArgs e)
      {
         if(_firstTimer)
         {
            _firstTimer = false;
            DeskewCommand command = new DeskewCommand();
            _initialFillColor = command.FillColor;
            _initialFlags = command.Flags;
         }

         FillColor = _initialFillColor;
         Flags = _initialFlags;

         _rbFill.Checked = (Flags & DeskewCommandFlags.FillExposedArea) == DeskewCommandFlags.FillExposedArea;
         _rbNoFill.Checked = (Flags & DeskewCommandFlags.DoNotFillExposedArea) == DeskewCommandFlags.DoNotFillExposedArea;

         UpdateControls();
      }

      private void UpdateControls( )
      {
         _lblFillColor.Enabled = _rbFill.Checked;
         _btnFillColor.Enabled = _rbFill.Checked;
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
         Flags = DeskewCommandFlags.DeskewImage;

         if(_rbFill.Checked)
            Flags |= DeskewCommandFlags.FillExposedArea;
         else
            Flags |= DeskewCommandFlags.DoNotFillExposedArea;

         _initialFillColor = FillColor;
         _initialFlags = Flags;
      }

      private void _rb_CheckedChanged(object sender, System.EventArgs e)
      {
         UpdateControls();
      }
   }
}
