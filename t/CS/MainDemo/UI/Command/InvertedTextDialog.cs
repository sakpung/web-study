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
using Leadtools.ImageProcessing.Effects;
using Leadtools.ImageProcessing.Core;

namespace MainDemo
{
   public partial class InvertedTextDialog : Form
   {
      private static bool _firstTimer = true;
      private static InvertedTextCommandFlags _initialFlags;
      private static int _initialMinInvertWidth;
      private static int _initialMinInvertHeight;
      private static int _initialMinBlackPercent;
      private static int _initialMaxBlackPercent;

      public InvertedTextCommandFlags Flags;
      public int MinInvertWidth;
      public int MinInvertHeight;
      public int MinBlackPercent;
      public int MaxBlackPercent;

      public InvertedTextDialog( )
      {
         InitializeComponent();
      }

      private void InvertedTextDialog_Load(object sender, System.EventArgs e)
      {
         if(_firstTimer)
         {
            _firstTimer = false;
            InvertedTextCommand command = new InvertedTextCommand();
            _initialFlags = command.Flags;
            _initialMinInvertWidth = command.MinimumInvertWidth;
            _initialMinInvertHeight = command.MinimumInvertHeight;
            _initialMinBlackPercent = command.MinimumBlackPercent;
            _initialMaxBlackPercent = command.MaximumBlackPercent;
         }

         Flags = _initialFlags;
         MinInvertWidth = _initialMinInvertWidth;
         MinInvertHeight = _initialMinInvertHeight;
         MinBlackPercent = _initialMinBlackPercent;
         MaxBlackPercent = _initialMaxBlackPercent;

         _cbImageUnchanged.Checked = (Flags & InvertedTextCommandFlags.ImageUnchanged) == InvertedTextCommandFlags.ImageUnchanged;
         _cbUseDiagonals.Checked = (Flags & InvertedTextCommandFlags.UseDiagonals) == InvertedTextCommandFlags.UseDiagonals;
         _cbUseDpi.Checked = (Flags & InvertedTextCommandFlags.UseDpi) == InvertedTextCommandFlags.UseDpi;

         _numMinInvertWidth.Value = MinInvertWidth;
         _numMinInvertHeight.Value = MinInvertHeight;
         _numMinBlackPercent.Value = MinBlackPercent;
         _numMaxBlackPercent.Value = MaxBlackPercent;

         UpdateControls();
      }

      private void _num_Leave(object sender, System.EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         Flags = InvertedTextCommandFlags.None;

         if(_cbImageUnchanged.Checked)
            Flags |= InvertedTextCommandFlags.ImageUnchanged;
         if(_cbUseDiagonals.Checked)
            Flags |= InvertedTextCommandFlags.UseDiagonals;
         if(_cbUseDpi.Checked)
            Flags |= InvertedTextCommandFlags.UseDpi;

         MinInvertWidth = (int)_numMinInvertWidth.Value;
         MinInvertHeight = (int)_numMinInvertHeight.Value;
         MinBlackPercent = (int)_numMinBlackPercent.Value;
         MaxBlackPercent = (int)_numMaxBlackPercent.Value;

         _initialFlags = Flags;
         _initialMinInvertWidth = MinInvertWidth;
         _initialMinInvertHeight = MinInvertHeight;
         _initialMinBlackPercent = MinBlackPercent;
         _initialMaxBlackPercent = MaxBlackPercent;
      }

      private void _cbUseDpi_CheckedChanged(object sender, System.EventArgs e)
      {
         UpdateControls();
      }

      private void UpdateControls( )
      {
         // Units
         string units;

         if(_cbUseDpi.Checked)
            units = DemosGlobalization.GetResxString(GetType(), "Resx_1Over1000Inch");
         else
            units = DemosGlobalization.GetResxString(GetType(), "Resx_Pixels");
         _lblUnitsWidth.Text = units;
         _lblUnitsHeight.Text = units;
      }
   }
}
