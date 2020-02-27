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
using Leadtools.ImageProcessing.Color;
using Leadtools.Demos;
   
namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the RemoveRedEyeCommand

   public partial class RemoveRedEyeDialog : Form
   {
      private RemoveRedEyeCommand _RemoveRedEyeCommand;
      private int _Red, _Green, _Blue, _Threshold, _Lightness;

      public RemoveRedEyeDialog()
      {
         InitializeComponent();
         _RemoveRedEyeCommand = new RemoveRedEyeCommand();

         //Set command default values
         InitializeUI();
      }

      public RemoveRedEyeCommand RemoveRedEyeCommand
      {
         get
         {
            //Update command values
            UpdateCommand(); 
            return _RemoveRedEyeCommand;
         }
         set
         {
            _RemoveRedEyeCommand = value;
            InitializeUI();
         }         
      }

      private void InitializeUI()
      {
         _Red = 0;
         _Green = 0;
         _Blue = 0;
         _Threshold = 150;
         _Lightness = 100;

         _numRed.Value = _Red;
         _numGreen.Value = _Green;
         _numBlue.Value = _Blue;
         _numThreshold.Value = _Threshold;
         _numLightness.Value = _Lightness;  
      }

      private void UpdateCommand()
      {

         _Red = Convert.ToInt32(_numRed.Value);
         _Green = Convert.ToInt32(_numGreen.Value);
         _Blue = Convert.ToInt32(_numBlue.Value);
         _Threshold = Convert.ToInt32(_numThreshold.Value);
         _Lightness = Convert.ToInt32(_numLightness.Value);

         _RemoveRedEyeCommand.NewColor = new RasterColor(_Red, _Green, _Blue);
         _RemoveRedEyeCommand.Threshold = _Threshold;
         _RemoveRedEyeCommand.Lightness = _Lightness;
      }    

      private void _numBlue_ValueChanged(object sender, EventArgs e)
      {
         _tbBlue.Value = Convert.ToInt32(_numBlue.Value);         
      }

      private void _numRed_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numGreen_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numBlue_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numThreshold_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numLightness_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _tbRed_Scroll(object sender, EventArgs e)
      {
         _numRed.Value = _tbRed.Value;
      }

      private void _tbGreen_Scroll(object sender, EventArgs e)
      {
         _numGreen.Value = _tbGreen.Value;
      }

      private void _tbBlue_Scroll(object sender, EventArgs e)
      {
         _numBlue.Value = _tbBlue.Value;
      }

      private void _tbThreshold_Scroll(object sender, EventArgs e)
      {
         _numThreshold.Value = _tbThreshold.Value; 
      }

      private void _tbLightness_Scroll(object sender, EventArgs e)
      {
         _numLightness.Value = _tbLightness.Value;
      }

      private void _numRed_ValueChanged(object sender, EventArgs e)
      {
         _tbRed.Value = Convert.ToInt32(_numRed.Value);
      }

      private void _numGreen_ValueChanged(object sender, EventArgs e)
      {
         _tbGreen.Value = Convert.ToInt32(_numGreen.Value);
      }

      private void _numThreshold_ValueChanged(object sender, EventArgs e)
      {
         _tbThreshold.Value = Convert.ToInt32(_numThreshold.Value);
      }

      private void _numLightness_ValueChanged(object sender, EventArgs e)
      {
         _tbLightness.Value = Convert.ToInt32(_numLightness.Value);
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
