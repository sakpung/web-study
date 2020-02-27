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
   public partial class DotRemoveDialog : Form
   {
      private static bool _firstTimer = true;
      private static DotRemoveCommandFlags _initialFlags;
      private static int _initialMinWidth;
      private static int _initialMinHeight;
      private static int _initialMaxWidth;
      private static int _initialMaxHeight;

      public DotRemoveCommandFlags Flags;
      public int MinWidth;
      public int MinHeight;
      public int MaxWidth;
      public int MaxHeight;

      public DotRemoveDialog( )
      {
         InitializeComponent();
      }

      private void DotRemoveDialog_Load(object sender, System.EventArgs e)
      {
         if(_firstTimer)
         {
            _firstTimer = false;
            DotRemoveCommand command = new DotRemoveCommand();
            _initialFlags = command.Flags;
            _initialMinWidth = command.MinimumDotWidth;
            _initialMinHeight = command.MinimumDotHeight;
            _initialMaxWidth = command.MaximumDotWidth;
            _initialMaxHeight = command.MaximumDotHeight;
         }

         Flags = _initialFlags;
         MinWidth = _initialMinWidth;
         MinHeight = _initialMinHeight;
         MaxWidth = _initialMaxWidth;
         MaxHeight = _initialMaxHeight;

         _cbImageUnchanged.Checked = (Flags & DotRemoveCommandFlags.ImageUnchanged) == DotRemoveCommandFlags.ImageUnchanged;
         _cbUseDiagonals.Checked = (Flags & DotRemoveCommandFlags.UseDiagonals) == DotRemoveCommandFlags.UseDiagonals;
         _cbUseDpi.Checked = (Flags & DotRemoveCommandFlags.UseDpi) == DotRemoveCommandFlags.UseDpi;
         _cbUseSize.Checked = (Flags & DotRemoveCommandFlags.UseSize) == DotRemoveCommandFlags.UseSize;

         _numMinWidth.Value = MinWidth;
         _numMinHeight.Value = MinHeight;
         _numMaxWidth.Value = MaxWidth;
         _numMaxHeight.Value = MaxHeight;

         UpdateControls();
      }

      private void _num_Leave(object sender, System.EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         if(_numMinWidth.Value >= _numMaxWidth.Value)
         {
            Messager.ShowWarning(this, DemosGlobalization.GetResxString(GetType(), "Resx_MinWidthWarning"));
            DialogResult = DialogResult.None;
            return;
         }

         if(_numMinHeight.Value >= _numMaxHeight.Value)
         {
            Messager.ShowWarning(this, "Resx_MinHeightWarning");
            DialogResult = DialogResult.None;
            return;
         }

         Flags = DotRemoveCommandFlags.None;

         if(_cbImageUnchanged.Checked)
            Flags |= DotRemoveCommandFlags.ImageUnchanged;
         if(_cbUseDiagonals.Checked)
            Flags |= DotRemoveCommandFlags.UseDiagonals;
         if(_cbUseDpi.Checked)
            Flags |= DotRemoveCommandFlags.UseDpi;
         if(_cbUseSize.Checked)
            Flags |= DotRemoveCommandFlags.UseSize;

         MinWidth = (int)_numMinWidth.Value;
         MinHeight = (int)_numMinHeight.Value;
         MaxWidth = (int)_numMaxWidth.Value;
         MaxHeight = (int)_numMaxHeight.Value;

         _initialFlags = Flags;
         _initialMinWidth = MinWidth;
         _initialMinHeight = MinHeight;
         _initialMaxWidth = MaxWidth;
         _initialMaxHeight = MaxHeight;
      }

      private void _cbUseDpi_CheckedChanged(object sender, System.EventArgs e)
      {
         UpdateControls();
      }

      private void _cbUseSize_CheckedChanged(object sender, System.EventArgs e)
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
         _lblUnitsMinWidth.Text = units;
         _lblUnitsMinHeight.Text = units;
         _lblUnitsMaxWidth.Text = units;
         _lblUnitsMaxHeight.Text = units;

         // Size
         _lblMinWidth.Enabled = _cbUseSize.Checked;
         _numMinWidth.Enabled = _cbUseSize.Checked;
         _lblUnitsMinWidth.Enabled = _cbUseSize.Checked;

         _lblMinHeight.Enabled = _cbUseSize.Checked;
         _numMinHeight.Enabled = _cbUseSize.Checked;
         _lblUnitsMinHeight.Enabled = _cbUseSize.Checked;


         _lblMaxWidth.Enabled = _cbUseSize.Checked;
         _numMaxWidth.Enabled = _cbUseSize.Checked;
         _lblUnitsMaxWidth.Enabled = _cbUseSize.Checked;

         _lblMaxHeight.Enabled = _cbUseSize.Checked;
         _numMaxHeight.Enabled = _cbUseSize.Checked;
         _lblUnitsMaxHeight.Enabled = _cbUseSize.Checked;

      }
   }
}
