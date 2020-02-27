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

namespace DocumentCleanupDemo
{
   public partial class BorderRemoveDialog : Form
   {
      // The BorderRemoveCommand Class is part of LEAD Document Clean-up functions. This class will remove the black borders in a 1-bit black and white image.
      // This dialog will update the following members of this class:
      // BorderRemoveCommand.Border Flag, this flag will indicate which border to remove 
      // BorderRemoveCommand.Flags, this member will determine the behavior of the border removal process. 
      // BorderRemoveCommand.Percent, this member will set the percent of the image dimension in which the border will be found.  
      // BorderRemoveCommand.Variance, this member will set the amount of variance tolerated in the border.  
      // BorderRemoveCommand.WhiteNoiseLength, this member will set the amount of white noise tolerated when determining the border.  

      private BorderRemoveCommand _BorderRemoveCommand;
      private BorderRemoveCommandFlags Flags;

      public BorderRemoveDialog()
      {
         InitializeComponent();
         _BorderRemoveCommand = new BorderRemoveCommand();
         InitializeUI();
      }

      public BorderRemoveDialog(BorderRemoveCommand borderRemoveCommand)
      {
         InitializeComponent();
         _BorderRemoveCommand = borderRemoveCommand;
         InitializeUI();
      }
      public BorderRemoveCommand BorderRemoveCommand
      {
         get
         {
            UpdateCommand();
            return _BorderRemoveCommand;
         }
         set
         {
            _BorderRemoveCommand = value;
            InitializeUI();
         }
      }
      private void _btnOK_Click(object sender, EventArgs e)
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
         // Initialize the BorderRemove Dialog with default values
         if ((_BorderRemoveCommand.Border & BorderRemoveBorderFlags.All) == BorderRemoveBorderFlags.All)
         {
            _cbLeftBorder.Checked = _cbRightBorder.Checked = _cbTopBorder.Checked = _cbBottomBorder.Checked = true;
         }
         else
         {
            // Use the BorderRemoveCommand.Border flag to determine which border will be removed.
            if ((_BorderRemoveCommand.Border & BorderRemoveBorderFlags.Bottom) == BorderRemoveBorderFlags.Bottom)
            {
               _cbBottomBorder.Checked = true;
            }
            if ((_BorderRemoveCommand.Border & BorderRemoveBorderFlags.Top) == BorderRemoveBorderFlags.Top)
            {
               _cbTopBorder.Checked = true;
            }
            if ((_BorderRemoveCommand.Border & BorderRemoveBorderFlags.Left) == BorderRemoveBorderFlags.Left)
            {
               _cbLeftBorder.Checked = true;
            }
            if ((_BorderRemoveCommand.Border & BorderRemoveBorderFlags.Right) == BorderRemoveBorderFlags.Right)
            {
               _cbRightBorder.Checked = true;
            }
         }
         _bBorderPercent.Text = _BorderRemoveCommand.Percent.ToString();
         _tnVariance.Text = _BorderRemoveCommand.Variance.ToString();
         _tbWhiteNoiseLength.Text = _BorderRemoveCommand.WhiteNoiseLength.ToString();
      }
      private void UpdateCommand()
      {
         // Determine how the BorderRemoveCommand will work by setting the values to its members and flags
         _BorderRemoveCommand.Border = BorderRemoveBorderFlags.None;

         _BorderRemoveCommand.Border =
        (_cbBottomBorder.Checked ? BorderRemoveBorderFlags.Bottom : BorderRemoveBorderFlags.None) |
        (_cbLeftBorder.Checked ? BorderRemoveBorderFlags.Left : BorderRemoveBorderFlags.None) |
        (_cbRightBorder.Checked ? BorderRemoveBorderFlags.Right : BorderRemoveBorderFlags.None) |
        (_cbTopBorder.Checked ? BorderRemoveBorderFlags.Top : BorderRemoveBorderFlags.None);

         if (_BorderRemoveCommand.Border == BorderRemoveBorderFlags.None)
            _BorderRemoveCommand.Border = (new BorderRemoveCommand()).Border;

         Flags = BorderRemoveCommandFlags.None;
         // Check the flag that will determine how the BorderRemoveCommand will process.
         if (_cbImageUnchanged.Checked)
            Flags |= BorderRemoveCommandFlags.ImageUnchanged;
         if (_cbUseVariance.Checked)
            Flags |= BorderRemoveCommandFlags.UseVariance;

         _BorderRemoveCommand.Flags = Flags;
         // Set the value of the Percent property
         if (_bBorderPercent.Text != "")
            _BorderRemoveCommand.Percent = Convert.ToInt32(_bBorderPercent.Text);
         // Set the value of the Variance property
         if (_tnVariance.Text != "")
            _BorderRemoveCommand.Variance = Convert.ToInt32(_tnVariance.Text);
         // Set the value of the WhiteNoiseLength property
         if (_tbWhiteNoiseLength.Text != "")
            _BorderRemoveCommand.WhiteNoiseLength = Convert.ToInt32(_tbWhiteNoiseLength.Text);
      }

      private void _cbUseVariance_CheckedChanged(object sender, EventArgs e)
      {
         _lblVariance.Enabled = _cbUseVariance.Checked;
         _tnVariance.Enabled = _cbUseVariance.Checked;
      }

      private void _bBorderPercent_TextChanged(object sender, EventArgs e)
      {
         _bBorderPercent.Text = MainForm.IsValidNumber(_bBorderPercent.Text, 1, 100);
      }

      private void _tbWhiteNoiseLength_TextChanged(object sender, EventArgs e)
      {
         _tbWhiteNoiseLength.Text = MainForm.IsValidNumber(_tbWhiteNoiseLength.Text, 0, 10);
      }

      private void _tnVariance_TextChanged(object sender, EventArgs e)
      {
         _tnVariance.Text = MainForm.IsValidNumber(_tnVariance.Text, 0, 10);
      }
   }
}
