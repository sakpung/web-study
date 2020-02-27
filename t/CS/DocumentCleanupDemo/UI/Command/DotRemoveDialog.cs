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
   public partial class DotRemoveDialog : Form
   {
      private DotRemoveCommand _DotRemoveCommand = null;
      public int XResolution = 150;
      public int YResolution = 150;
      private double _MaximumDotHeight = 0.0;
      private double _MaximumDotWidth = 0.0;
      private double _MinimumDotHeight = 0.0;
      private double _MinimumDotWidth = 0.0;

      public DotRemoveDialog()
      {
         InitializeComponent();
         _DotRemoveCommand = new DotRemoveCommand();
         InitializeUI();
      }

      public DotRemoveDialog(DotRemoveCommand DotRemoveCommand, int XResolution, int YResolution)
      {
         // The DotRemoveCommand Class is part of our LEAD Document Imaging functions. This class will find and removes dots and specks of various sizes.
         // This dialog will update the following members of this class:
         // DotRemoveCommand.MaximumDotHeight to set the maximum height of a dot to be removed.   
         // DotRemoveCommand.MaximumDotWidth to set the maximum width of a dot to be removed.   
         // DotRemoveCommand.MinimumDotHeight to set the minimum height of a dot to be removed.   
         // DotRemoveCommand.MinimumDotWidth to set the minimum width of a dot to be removed.  
         InitializeComponent();
         _DotRemoveCommand = DotRemoveCommand;
         this.XResolution = XResolution;
         this.YResolution = YResolution;
         InitializeUI();
      }
      public DotRemoveCommand DotRemoveCommand
      {
         get
         {
            UpdateCommand();
            return _DotRemoveCommand;
         }
         set
         {
            _DotRemoveCommand = value;
            InitializeUI();
         }
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         bool OK = true;
         UpdateCommand();

         if ((_tbMinimumDotWidth.Text != "") && (_tbMaximumDotWidth.Text != ""))

            if ((Convert.ToInt32(_tbMinimumDotWidth.Text)) >
                (Convert.ToInt32(_tbMaximumDotWidth.Text)))
            {
               MessageBox.Show("Minimum width must be less than maximum width");
               OK = false;
            }
         if ((_tbMinimumDotHeight.Text != "") && (_tbMaximumDotHeight.Text != ""))
            if ((Convert.ToInt32(_tbMinimumDotHeight.Text)) >
                (Convert.ToInt32(_tbMaximumDotHeight.Text)))
            {
               MessageBox.Show("Minimum Height must be less than maximum Height");
               OK = false;
            }

         if (OK)
         {
            this.DialogResult = DialogResult.OK;
            this.Close();
         }
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
      }
      private void InitializeUI()
      {
         // Initialize the DotRemove Dialog with default values
         if ((_DotRemoveCommand.Flags & DotRemoveCommandFlags.UseDpi) == DotRemoveCommandFlags.UseDpi)
         {
            _MaximumDotHeight = (double)_DotRemoveCommand.MaximumDotHeight / 1000;
            _MaximumDotWidth = (double)_DotRemoveCommand.MaximumDotWidth / 1000;
            _MinimumDotHeight = (double)_DotRemoveCommand.MinimumDotHeight / 1000;
            _MinimumDotWidth = (double)_DotRemoveCommand.MinimumDotWidth / 1000;

            _tbMinimumDotHeight.Text = _MinimumDotHeight.ToString();
            _tbMinimumDotWidth.Text = _MinimumDotWidth.ToString();
            _tbMaximumDotHeight.Text = _MaximumDotHeight.ToString();
            _tbMaximumDotWidth.Text = _MaximumDotWidth.ToString();

            _cbUseDPI.Checked = true;
            _lbl5.Text = _lbl6.Text = _lbl7.Text = _lbl8.Text = "inches";
         }
         else
         {
            _tbMinimumDotHeight.Text = _DotRemoveCommand.MinimumDotHeight.ToString();
            _tbMinimumDotWidth.Text = _DotRemoveCommand.MinimumDotWidth.ToString();
            _tbMaximumDotHeight.Text = _DotRemoveCommand.MaximumDotHeight.ToString();
            _tbMaximumDotWidth.Text = _DotRemoveCommand.MaximumDotWidth.ToString();
            // Converts the used unit to inches
            ConvertToInches();
            _cbUseDPI_CheckedChanged(this, null);
         }

         if ((_DotRemoveCommand.Flags & DotRemoveCommandFlags.UseDiagonals) == DotRemoveCommandFlags.UseDiagonals)
         {
            _cbUseDiagonals.Checked = true;
         }
         if ((_DotRemoveCommand.Flags & DotRemoveCommandFlags.UseSize) == DotRemoveCommandFlags.UseSize)
         {
            _cbUseDotDimensions.Checked = true;
         }
         this._cbUseDPI.CheckedChanged += new System.EventHandler(this._cbUseDPI_CheckedChanged);

         _tbDPI.Text = "dpi: " + this.XResolution.ToString() + ", " + this.YResolution.ToString();
         _cbUseDotDimensions_CheckedChanged(this, null);
      }
      private void UpdateCommand()
      {
         _DotRemoveCommand.Flags = DotRemoveCommandFlags.None;
         _DotRemoveCommand.Flags =
            (_cbUseDPI.Checked ? DotRemoveCommandFlags.UseDpi : DotRemoveCommandFlags.None) |
            (_cbUseDiagonals.Checked ? DotRemoveCommandFlags.UseDiagonals : DotRemoveCommandFlags.None) |
            (_cbUseDotDimensions.Checked ? DotRemoveCommandFlags.UseSize : DotRemoveCommandFlags.None);
         if (_DotRemoveCommand.Flags == DotRemoveCommandFlags.None)
            _DotRemoveCommand.Flags = (new DotRemoveCommand()).Flags;
         // Updates the dimensions of the Dot
         if (_cbUseDotDimensions.Checked)
         {
            if (_cbUseDPI.Checked)
            {
               _DotRemoveCommand.MaximumDotHeight = Convert.ToInt32(_MaximumDotHeight * 1000);
               _DotRemoveCommand.MaximumDotWidth = Convert.ToInt32(_MaximumDotWidth * 1000);
               _DotRemoveCommand.MinimumDotHeight = Convert.ToInt32(_MinimumDotHeight * 1000);
               _DotRemoveCommand.MinimumDotWidth = Convert.ToInt32(_MinimumDotWidth * 1000);
            }
            else
            {
               if (_tbMaximumDotHeight.Text != "")
                  _DotRemoveCommand.MaximumDotHeight = Convert.ToInt32(_tbMaximumDotHeight.Text);
               if (_tbMaximumDotWidth.Text != "")
                  _DotRemoveCommand.MaximumDotWidth = Convert.ToInt32(_tbMaximumDotWidth.Text);
               if (_tbMinimumDotHeight.Text != "")
                  _DotRemoveCommand.MinimumDotHeight = Convert.ToInt32(_tbMinimumDotHeight.Text);
               if (_tbMinimumDotWidth.Text != "")
                  _DotRemoveCommand.MinimumDotWidth = Convert.ToInt32(_tbMinimumDotWidth.Text);
            }
         }
      }
      private void _cbUseDPI_CheckedChanged(object sender, EventArgs e)
      {
         if (_cbUseDPI.Checked)
         {
            // Converts the used unit to inches
            ConvertToInches();
            _lbl5.Text = _lbl6.Text = _lbl7.Text = _lbl8.Text = "inches";
         }
         else
         {
            //Converts the used unit to pixels
            ConvertToPixels();
            _lbl5.Text = _lbl6.Text = _lbl7.Text = _lbl8.Text = "pixels";
         }
      }
      private void ConvertToInches()
      {
         if (_tbMaximumDotHeight.Text != "")
            _MaximumDotHeight = Convert.ToDouble(_tbMaximumDotHeight.Text) / this.XResolution;
         if (_tbMaximumDotWidth.Text != "")
            _MaximumDotWidth = Convert.ToDouble(_tbMaximumDotWidth.Text) / this.XResolution;
         if (_tbMinimumDotHeight.Text != "")
            _MinimumDotHeight = Convert.ToDouble(_tbMinimumDotHeight.Text) / this.XResolution;
         if (_tbMinimumDotWidth.Text != "")
            _MinimumDotWidth = Convert.ToDouble(_tbMinimumDotWidth.Text) / this.XResolution;

         _tbMinimumDotHeight.Text = _MinimumDotHeight.ToString();
         _tbMinimumDotWidth.Text = _MinimumDotWidth.ToString();
         _tbMaximumDotHeight.Text = _MaximumDotHeight.ToString();
         _tbMaximumDotWidth.Text = _MaximumDotWidth.ToString();
      }
      private void ConvertToPixels()
      {
         _tbMinimumDotHeight.Text = Convert.ToInt32((this.XResolution * _MinimumDotHeight)).ToString();
         _tbMinimumDotWidth.Text = Convert.ToInt32((this.XResolution * _MinimumDotWidth)).ToString();
         _tbMaximumDotHeight.Text = Convert.ToInt32((this.XResolution * _MaximumDotHeight)).ToString();
         _tbMaximumDotWidth.Text = Convert.ToInt32((this.XResolution * _MaximumDotWidth)).ToString();
      }

      private void _cbUseDotDimensions_CheckedChanged(object sender, EventArgs e)
      {
         _gbDotDimensions.Enabled = _cbUseDotDimensions.Checked;
      }

      private void _tbMinimumDotWidth_TextChanged(object sender, EventArgs e)
      {
         _tbMinimumDotWidth.Text = MainForm.IsValidNumber(_tbMinimumDotWidth.Text, 1, 10000);
      }

      private void _tbMinimumDotHeight_TextChanged(object sender, EventArgs e)
      {
         _tbMinimumDotHeight.Text = MainForm.IsValidNumber(_tbMinimumDotHeight.Text, 1, 10000);
      }

      private void _tbMaximumDotWidth_TextChanged(object sender, EventArgs e)
      {
         _tbMaximumDotWidth.Text = MainForm.IsValidNumber(_tbMaximumDotWidth.Text, 1, 10000);
      }

      private void _tbMaximumDotHeight_TextChanged(object sender, EventArgs e)
      {
         _tbMaximumDotHeight.Text = MainForm.IsValidNumber(_tbMaximumDotHeight.Text, 1, 10000);
      }
   }
}
