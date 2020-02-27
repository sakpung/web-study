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
   public partial class LineRemoveDialog : Form
   {
      private static bool _firstTimer = true;
      private static LineRemoveCommandFlags _initialFlags;
      private static LineRemoveCommandType _initialRemove;
      private static int _initialGapLength;
      private static int _initialLineVariance;
      private static int _initialMaxLineWidth;
      private static int _initialMaxWallPercent;
      private static int _initialMinLineLength;
      private static int _initialWall;

      public LineRemoveCommandFlags Flags;
      public LineRemoveCommandType Remove;
      public int GapLength = 1;
      public int LineVariance = 2;
      public int MaxLineWidth = 10;
      public int MaxWallPercent = 50;
      public int MinLineLength = 100;
      public int Wall = 10;

      public LineRemoveDialog( )
      {
         InitializeComponent();
      }

      private void LineRemoveDialog_Load(object sender, System.EventArgs e)
      {
         if(_firstTimer)
         {
            _firstTimer = false;
            LineRemoveCommand command = new LineRemoveCommand();
            _initialFlags = command.Flags;
            _initialRemove = command.Type;
            _initialGapLength = command.GapLength;
            _initialLineVariance = command.Variance;
            _initialMaxLineWidth = command.MaximumLineWidth;
            _initialMaxWallPercent = command.MaximumWallPercent;
            _initialMinLineLength = command.MinimumLineLength;
            _initialWall = command.Wall;
         }

         Flags = _initialFlags;
         Remove = _initialRemove;
         GapLength = _initialGapLength;
         LineVariance = _initialLineVariance;
         MaxLineWidth = _initialMaxLineWidth;
         MaxWallPercent = _initialMaxWallPercent;
         MinLineLength = _initialMinLineLength;
         Wall = _initialWall;

         _cbImageUnchanged.Checked = (Flags & LineRemoveCommandFlags.ImageUnchanged) == LineRemoveCommandFlags.ImageUnchanged;
         _cbRemoveEntire.Checked = (Flags & LineRemoveCommandFlags.RemoveEntire) == LineRemoveCommandFlags.RemoveEntire;
         _cbUseVariance.Checked = (Flags & LineRemoveCommandFlags.UseVariance) == LineRemoveCommandFlags.UseVariance;
         _cbUseGap.Checked = (Flags & LineRemoveCommandFlags.UseGap) == LineRemoveCommandFlags.UseGap;
         _cbUseDpi.Checked = (Flags & LineRemoveCommandFlags.UseDpi) == LineRemoveCommandFlags.UseDpi;

         _rbHorizontal.Checked = Remove == LineRemoveCommandType.Horizontal;
         _rbVertical.Checked = Remove == LineRemoveCommandType.Vertical;

         _numGapLength.Value = GapLength;
         _numLineVariance.Value = LineVariance;
         _numMaxLineWidth.Value = MaxLineWidth;
         _numMaxWallPercent.Value = MaxWallPercent;
         _numMinLineLength.Value = MinLineLength;
         _numWall.Value = Wall;

         UpdateControls();
      }

      private void _num_Leave(object sender, System.EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         Flags = LineRemoveCommandFlags.None;

         if(_cbImageUnchanged.Checked)
            Flags |= LineRemoveCommandFlags.ImageUnchanged;
         if(_cbRemoveEntire.Checked)
            Flags |= LineRemoveCommandFlags.RemoveEntire;
         if(_cbUseVariance.Checked)
            Flags |= LineRemoveCommandFlags.UseVariance;
         if(_cbUseGap.Checked)
            Flags |= LineRemoveCommandFlags.UseGap;
         if(_cbUseDpi.Checked)
            Flags |= LineRemoveCommandFlags.UseDpi;

         if(_rbHorizontal.Checked)
            Remove = LineRemoveCommandType.Horizontal;
         if(_rbVertical.Checked)
            Remove = LineRemoveCommandType.Vertical;

         GapLength = (int)_numGapLength.Value;
         LineVariance = (int)_numLineVariance.Value;
         MaxLineWidth = (int)_numMaxLineWidth.Value;
         MaxWallPercent = (int)_numMaxWallPercent.Value;
         MinLineLength = (int)_numMinLineLength.Value;
         Wall = (int)_numWall.Value;

         _initialFlags = Flags;
         _initialRemove = Remove;
         _initialGapLength = GapLength;
         _initialLineVariance = LineVariance;
         _initialMaxLineWidth = MaxLineWidth;
         _initialMaxWallPercent = MaxWallPercent;
         _initialMinLineLength = MinLineLength;
         _initialWall = Wall;
      }

      private void _cbUseDpi_CheckedChanged(object sender, System.EventArgs e)
      {
         UpdateControls();
      }

      private void _cbUseGap_CheckedChanged(object sender, System.EventArgs e)
      {
         UpdateControls();
      }

      private void _cbUseVariance_CheckedChanged(object sender, System.EventArgs e)
      {
         UpdateControls();
      }

      private void UpdateControls( )
      {
         string units;

         // units
         if (_cbUseDpi.Checked)
            units = DemosGlobalization.GetResxString(GetType(), "Resx_1Over1000Inch");
         else
            units = DemosGlobalization.GetResxString(GetType(), "Resx_Pixels");
         _lblUnitsWidth.Text = units;
         _lblUnitsHeight.Text = units;

         // Use Gap
         _lblGapLength.Enabled = _cbUseGap.Checked;
         _numGapLength.Enabled = _cbUseGap.Checked;

         //Use Variance
         _lblLineVariance.Enabled = _cbUseVariance.Checked;
         _numLineVariance.Enabled = _cbUseVariance.Checked;
      }
   }
}
