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

namespace DocumentCleanupDemo
{
   public partial class HolePunchRemoveDialog : Form
   {
      // The HolePunchRemoveCommand Class is part of our LEAD Document Imaging functions. This class will find and removes hole punches from your image.
      // This dialog will update the following members of this class:
      // HolePunchRemoveCommand.Location, this member will be used to set a value that indicates the location within the document of the hole punches to remove.
      // HolePunchRemoveCommand.MaximumHoleCount, this member will be used to set the maximum number of holes to detect.
      // HolePunchRemoveCommand.MaximumHoleHeight, this member will be used to set the maximum height of one of the holes of the hole punch configuration to be removed.   
      // HolePunchRemoveCommand.MaximumHoleWidth, this member will be used to set the maximum width of one of the holes of the hole punch configuration to be removed.   
      // HolePunchRemoveCommand.MinimumHoleCount, this member will be used to set the minimum number of holes to detect.   
      // HolePunchRemoveCommand.MinimumHoleHeight, this member will be used to set the minimum height of one of the holes of the hole punch configuration to be removed.   
      // HolePunchRemoveCommand.MinimumHoleWidth, this member will be used to set the minimum width of one of the holes of the hole punch configuration to be removed.   
      // This dialog will check the following flags to determine how to process this command:
      // HolePunchRemoveCommandFlags.UseDpi
      // HolePunchRemoveCommandFlags.UseSize
      // HolePunchRemoveCommandFlags.UseLocation
      // HolePunchRemoveCommandFlags.UseCount
      // HolePunchRemoveCommandFlags.ImageUnchanged

      private static bool _firstTimer = true;
      private static HolePunchRemoveCommandFlags _initialFlags;
      private static HolePunchRemoveCommandLocation _initialHoleLocation;

      private static int _initialMinCount;
      private static int _initialMaxCount;
      private static int _initialMinWidth;
      private static int _initialMinHeight;
      private static int _initialMaxWidth;
      private static int _initialMaxHeight;

      public HolePunchRemoveCommandFlags Flags;
      public HolePunchRemoveCommandLocation HoleLocation;
      public int MinCount;
      public int MaxCount;
      public int MinWidth;
      public int MinHeight;
      public int MaxWidth;
      public int MaxHeight;

      public HolePunchRemoveDialog()
      {
         InitializeComponent();
      }

      private void HolePunchRemoveDialog_Load(object sender, System.EventArgs e)
      {
         if (_firstTimer)
         {
            _firstTimer = false;
            HolePunchRemoveCommand command = new HolePunchRemoveCommand();
            _initialFlags = command.Flags;
            _initialHoleLocation = command.Location;
            _initialMinCount = command.MinimumHoleCount;
            _initialMaxCount = command.MaximumHoleCount;
            _initialMinWidth = command.MinimumHoleWidth;
            _initialMinHeight = command.MinimumHoleHeight;
            _initialMaxWidth = command.MaximumHoleWidth;
            _initialMaxHeight = command.MaximumHoleHeight;
         }

         Flags = _initialFlags;
         HoleLocation = _initialHoleLocation;
         MinCount = _initialMinCount;
         MaxCount = _initialMaxCount;
         MinWidth = _initialMinWidth;
         MinHeight = _initialMinHeight;
         MaxWidth = _initialMaxWidth;
         MaxHeight = _initialMaxHeight;

         _cbImageUnchanged.Checked = (Flags & HolePunchRemoveCommandFlags.ImageUnchanged) == HolePunchRemoveCommandFlags.ImageUnchanged;
         _cbUseCount.Checked = (Flags & HolePunchRemoveCommandFlags.UseCount) == HolePunchRemoveCommandFlags.UseCount;
         _cbUseLocation.Checked = (Flags & HolePunchRemoveCommandFlags.UseLocation) == HolePunchRemoveCommandFlags.UseLocation;
         _cbUseDpi.Checked = (Flags & HolePunchRemoveCommandFlags.UseDpi) == HolePunchRemoveCommandFlags.UseDpi;
         _cbUseSize.Checked = (Flags & HolePunchRemoveCommandFlags.UseSize) == HolePunchRemoveCommandFlags.UseSize;

         _rbButtonLeft.Checked = HoleLocation == HolePunchRemoveCommandLocation.Left;
         _rbButtonTop.Checked = HoleLocation == HolePunchRemoveCommandLocation.Top;
         _rbButtonRight.Checked = HoleLocation == HolePunchRemoveCommandLocation.Right;
         _rbButtonBottom.Checked = HoleLocation == HolePunchRemoveCommandLocation.Bottom;

         _numMinCount.Value = MinCount;
         _numMaxCount.Value = MaxCount;
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
         // Run the command depending on the checked flags in the dialog
         Flags = HolePunchRemoveCommandFlags.None;

         if (_cbImageUnchanged.Checked)
            Flags |= HolePunchRemoveCommandFlags.ImageUnchanged;
         if (_cbUseCount.Checked)
            Flags |= HolePunchRemoveCommandFlags.UseCount;
         if (_cbUseLocation.Checked)
            Flags |= HolePunchRemoveCommandFlags.UseLocation;
         if (_cbUseDpi.Checked)
            Flags |= HolePunchRemoveCommandFlags.UseDpi;
         if (_cbUseSize.Checked)
            Flags |= HolePunchRemoveCommandFlags.UseSize;

         if (_rbButtonLeft.Checked)
            HoleLocation = HolePunchRemoveCommandLocation.Left;
         if (_rbButtonTop.Checked)
            HoleLocation = HolePunchRemoveCommandLocation.Top;
         if (_rbButtonRight.Checked)
            HoleLocation = HolePunchRemoveCommandLocation.Right;
         if (_rbButtonBottom.Checked)
            HoleLocation = HolePunchRemoveCommandLocation.Bottom;

         MinCount = (int)_numMinCount.Value;
         MaxCount = (int)_numMaxCount.Value;
         MinWidth = (int)_numMinWidth.Value;
         MinHeight = (int)_numMinHeight.Value;
         MaxWidth = (int)_numMaxWidth.Value;
         MaxHeight = (int)_numMaxHeight.Value;

         _initialFlags = Flags;
         _initialHoleLocation = HoleLocation;
         _initialMinCount = MinCount;
         _initialMaxCount = MaxCount;
         _initialMinWidth = MinWidth;
         _initialMinHeight = MinHeight;
         _initialMaxWidth = MaxWidth;
         _initialMaxHeight = MaxHeight;
      }

      private void _cbUseDpi_CheckedChanged(object sender, System.EventArgs e)
      {
         UpdateControls();
      }

      private void _cbUseCount_CheckedChanged(object sender, System.EventArgs e)
      {
         UpdateControls();
      }

      private void _cbUseLocation_CheckedChanged(object sender, System.EventArgs e)
      {
         UpdateControls();
      }

      private void _cbUseSize_CheckedChanged(object sender, System.EventArgs e)
      {
         UpdateControls();
      }

      private void UpdateControls()
      {
         // Units
         string units;

         if (_cbUseDpi.Checked)
            units = "1/1000 inch";
         else
            units = "Pixels";
         _lblUnitsMinWidth.Text = units;
         _lblUnitsMinHeight.Text = units;
         _lblUnitsMaxWidth.Text = units;
         _lblUnitsMaxHeight.Text = units;

         // Count
         _lblMinCount.Enabled = _cbUseCount.Checked;
         _numMinCount.Enabled = _cbUseCount.Checked;
         _lblMaxCount.Enabled = _cbUseCount.Checked;
         _numMaxCount.Enabled = _cbUseCount.Checked;

         // Location
         _gbLocation.Enabled = _cbUseLocation.Checked;
         _rbButtonLeft.Enabled = _cbUseLocation.Checked;
         _rbButtonTop.Enabled = _cbUseLocation.Checked;
         _rbButtonRight.Enabled = _cbUseLocation.Checked;
         _rbButtonBottom.Enabled = _cbUseLocation.Checked;

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
