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
   public partial class InvertedTextDialog : Form
   {
      // The InvertedTextCommand Class is part of our LEAD Document Imaging functions. This class will find and modify areas of inverted text in a 1-bit black and white image
      // This dialog will update the following members of this class:
      // Members that controls the Opacity
      // InvertedTextCommand.MaximumBlackPercent, this member will be used to set the maximum percent of total pixels in an inverted text area that must be black.   
      // InvertedTextCommand.MinimumBlackPercent, this member will be used to set the minimum percent of total pixels in an inverted text area that must be black.
      // Members that controls the inverted text dimensions   
      // InvertedTextCommand.MinimumInvertHeight, this member will be used to set the minimum height of an area that is considered to be inverted text.   
      // InvertedTextCommand.MinimumInvertWidth, this member will be used to set the minimum width of an area that is considered to be inverted text.   

      private InvertedTextCommand _InvertedTextCommand = null;
      public int XResolution = 150;
      public int YResolution = 150;
      private double _MinimumInvertWidth = 0.0;
      private double _MinimumInvertHeight = 0.0;

      public InvertedTextDialog()
      {
         InitializeComponent();
         _InvertedTextCommand = new InvertedTextCommand();
         InitializeUI();
      }
      public InvertedTextDialog(InvertedTextCommand InvertedTextCommand, int XResolution, int YResolution)
      {
         InitializeComponent();
         _InvertedTextCommand = InvertedTextCommand;
         this.XResolution = XResolution;
         this.YResolution = YResolution;
         InitializeUI();
      }
      public InvertedTextCommand InvertedTextCommand
      {
         get
         {
            UpdateCommand();
            return _InvertedTextCommand;
         }
         set
         {
            _InvertedTextCommand = value;
            InitializeUI();
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
         // Initialize the InvertedTextCommand Dialog with default values
         if ((_InvertedTextCommand.Flags & InvertedTextCommandFlags.UseDpi) == InvertedTextCommandFlags.UseDpi)
         {
            _MinimumInvertWidth = (double)_InvertedTextCommand.MinimumInvertWidth / 1000;
            _MinimumInvertHeight = (double)_InvertedTextCommand.MinimumInvertHeight / 1000;

            _tbMinimumInvertWidth.Text = _MinimumInvertWidth.ToString();
            _tbMinimumInvertHeight.Text = _MinimumInvertHeight.ToString();

            _cbUseDPI.Checked = true;
            _lbl3.Text = _lbl4.Text = "inches";
         }
         else
         {
            _tbMinimumInvertWidth.Text = _InvertedTextCommand.MinimumInvertWidth.ToString();
            _tbMinimumInvertHeight.Text = _InvertedTextCommand.MinimumInvertHeight.ToString();
            // Converts the used unit to inches
            ConvertToInches();
            _cbUseDPI_CheckedChanged(this, null);
         }
         this._cbUseDPI.CheckedChanged += new System.EventHandler(this._cbUseDPI_CheckedChanged);
         _tbDPI.Text = "dpi: " + this.XResolution.ToString() + ", " + this.YResolution.ToString();

         _tbMinimumBlackPercent.Text = _InvertedTextCommand.MinimumBlackPercent.ToString();
         _tbMaximumBlackPercent.Text = _InvertedTextCommand.MaximumBlackPercent.ToString();
      }
      private void UpdateCommand()
      {
         // Determine how the InvertedTextCommand will work by setting the values to its members and flags
         _InvertedTextCommand.Flags = InvertedTextCommandFlags.None;
         _InvertedTextCommand.Flags =
            (_cbUseDPI.Checked ? InvertedTextCommandFlags.UseDpi : InvertedTextCommandFlags.None);

         if (_cbUseDPI.Checked)
         {
            _InvertedTextCommand.MinimumInvertWidth = Convert.ToInt32(_MinimumInvertWidth * 1000);
            _InvertedTextCommand.MinimumInvertHeight = Convert.ToInt32(_MinimumInvertHeight * 1000);
         }
         else
         {
            if (_tbMinimumInvertWidth.Text != "")
               _InvertedTextCommand.MinimumInvertWidth = Convert.ToInt32(_tbMinimumInvertWidth.Text);
            if (_tbMinimumInvertHeight.Text != "")
               _InvertedTextCommand.MinimumInvertHeight = Convert.ToInt32(_tbMinimumInvertHeight.Text);
         }
         if (_tbMaximumBlackPercent.Text != "")
         {
            int nPercent = Convert.ToInt32(_tbMaximumBlackPercent.Text);
            if (nPercent > 100) nPercent = 100;
            if (nPercent < 0) nPercent = 0;
            _InvertedTextCommand.MaximumBlackPercent = nPercent;
         }
         if (_tbMinimumBlackPercent.Text != "")
         {
            int nPercent = Convert.ToInt32(_tbMinimumBlackPercent.Text);
            if (nPercent > 100) nPercent = 100;
            if (nPercent < 0) nPercent = 0;
            _InvertedTextCommand.MinimumBlackPercent = nPercent;
         }
      }
      private void _cbUseDPI_CheckedChanged(object sender, EventArgs e)
      {
         if (_cbUseDPI.Checked)
         {
            // Converts the used unit to inches
            ConvertToInches();
            _lbl3.Text = _lbl4.Text = "inches";
         }
         else
         {
            //Converts the used unit to pixels
            ConvertToPixels();
            _lbl3.Text = _lbl4.Text = "pixels";
         }
      }
      private void ConvertToInches()
      {
         if (_tbMinimumInvertWidth.Text != "")
            _MinimumInvertWidth = Convert.ToDouble(_tbMinimumInvertWidth.Text) / this.XResolution;
         if (_tbMinimumInvertHeight.Text != "")
            _MinimumInvertHeight = Convert.ToDouble(_tbMinimumInvertHeight.Text) / this.XResolution;

         _tbMinimumInvertWidth.Text = _MinimumInvertWidth.ToString();
         _tbMinimumInvertHeight.Text = _MinimumInvertHeight.ToString();
      }
      private void ConvertToPixels()
      {
         _tbMinimumInvertWidth.Text = Convert.ToInt32((this.XResolution * _MinimumInvertWidth)).ToString();
         _tbMinimumInvertHeight.Text = Convert.ToInt32((this.XResolution * _MinimumInvertHeight)).ToString();
      }

      private void _tbMinimumInvertWidth_TextChanged(object sender, EventArgs e)
      {
         _tbMinimumInvertWidth.Text = MainForm.IsValidNumber(_tbMinimumInvertWidth.Text, 0, 10000);
      }

      private void _tbMinimumInvertHeight_TextChanged(object sender, EventArgs e)
      {
         _tbMinimumInvertHeight.Text = MainForm.IsValidNumber(_tbMinimumInvertHeight.Text, 0, 10000);

      }

      private void _tbMinimumBlackPercent_TextChanged(object sender, EventArgs e)
      {
         _tbMinimumBlackPercent.Text = MainForm.IsValidNumber(_tbMinimumBlackPercent.Text, 0, 100);

      }

      private void _tbMaximumBlackPercent_TextChanged(object sender, EventArgs e)
      {
         _tbMaximumBlackPercent.Text = MainForm.IsValidNumber(_tbMaximumBlackPercent.Text, 0, 100);
      }

   }
}
