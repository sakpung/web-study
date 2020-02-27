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
using Leadtools.Demos;
namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the AddNoiseCommand
   public partial class AddNoiseDialog : Form
   {
      private AddNoiseCommand _AddNoiseCommand = null;

      public AddNoiseDialog()
      {
         InitializeComponent();
         _AddNoiseCommand = new AddNoiseCommand();
         //Set command default values
         InitializeUI();
      }

      public AddNoiseCommand AddNoisecommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _AddNoiseCommand;
         }
         set
         {
            _AddNoiseCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {
         _AddNoiseCommand.Channel = Leadtools.ImageProcessing.RasterColorChannel.Red;
         _AddNoiseCommand.Range = 250;
         _numRange.Value = _AddNoiseCommand.Range;
         _rbRed.Checked = true;

      }

      private void UpdateCommand()
      {
         if (_rbRed.Checked)
            _AddNoiseCommand.Channel = Leadtools.ImageProcessing.RasterColorChannel.Red;
         if (_rbGreen.Checked)
            _AddNoiseCommand.Channel = Leadtools.ImageProcessing.RasterColorChannel.Green;
         if (_rbBlue.Checked)
            _AddNoiseCommand.Channel = Leadtools.ImageProcessing.RasterColorChannel.Blue;
         if (_rbMaster.Checked)
            _AddNoiseCommand.Channel = Leadtools.ImageProcessing.RasterColorChannel.Master;

         _AddNoiseCommand.Range = Convert.ToInt32(_numRange.Value);

      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         UpdateCommand();
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         InitializeUI();
         this.DialogResult = DialogResult.Cancel;
      }

      private void _numRange_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

   }
}
