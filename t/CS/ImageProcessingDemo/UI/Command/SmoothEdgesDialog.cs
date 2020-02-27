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
   //will be used for the SmoothEdgesCommand

   public partial class SmoothEdgesDialog : Form
   {
      private SmoothEdgesCommand _SmoothEdgesCommand;
      private int _Amount, _Threshold;

      public SmoothEdgesDialog()
      {
         InitializeComponent();
         _SmoothEdgesCommand = new SmoothEdgesCommand();
         
         //Set command default values
         InitializeUI();
      }

      public SmoothEdgesCommand SmoothEdgesCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _SmoothEdgesCommand; 
         }
         set
         {
            _SmoothEdgesCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {
         _Amount = 50;
         _Threshold = 0;

         _numAmount.Value = _Amount;
         _numThreshold.Value = _Threshold;   
      }
      private void UpdateCommand()
      {
         _Amount = Convert.ToInt32(_numAmount.Value);
         _Threshold = Convert.ToInt32(_numThreshold.Value);
   
         _SmoothEdgesCommand.Amount = _Amount;
         _SmoothEdgesCommand.Threshold = _Threshold;  
      }
      private void _tbThreshold_Scroll(object sender, EventArgs e)
      {
         _numThreshold.Value = _tbThreshold.Value; 
      }

      private void _tbAmount_Scroll(object sender, EventArgs e)
      {
         _numAmount.Value = _tbAmount.Value;
      }

      private void _numAmount_ValueChanged(object sender, EventArgs e)
      {
         _tbAmount.Value = Convert.ToInt32(_numAmount.Value);
      }

      private void _numAmount_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);

      }

      private void _numThreshold_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);

      }

      private void _numThreshold_ValueChanged(object sender, EventArgs e)
      {
         _tbThreshold.Value = Convert.ToInt32(_numThreshold.Value);

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
   }
}
