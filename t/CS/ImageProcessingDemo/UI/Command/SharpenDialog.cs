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
   //will be used for the SharpenCommand

   public partial class SharpenDialog : Form
   {
      private SharpenCommand _SharpenCommand = null;
      private int _Sharpness;

      public SharpenDialog()
      {
         InitializeComponent();
         _SharpenCommand = new SharpenCommand();

         //Set command default values
         InitializeUI();

      }

      public SharpenCommand Sharpencommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _SharpenCommand;
         }
         set
         {
            _SharpenCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {
         _Sharpness = 100;
         _numSharpness.Value = _Sharpness;
      }

      private void UpdateCommand()
      {
         _SharpenCommand.Sharpness = Convert.ToInt32(_numSharpness.Value);
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

      private void _tbSharpness_Scroll(object sender, EventArgs e)
      {
         _numSharpness.Value = _tbSharpness.Value;
      }

      private void _numSharpness_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }
   }
}
