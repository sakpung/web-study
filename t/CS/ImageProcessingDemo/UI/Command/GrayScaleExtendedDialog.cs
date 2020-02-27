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
   //will be used for the GrayScaleExtendedCommand

   public partial class GrayScaleExtendedDialog : Form
   {
      private GrayScaleExtendedCommand _GrayScaleExtendedCommand;
      private int _Red, _Green,_Blue;

      public GrayScaleExtendedDialog()
      {
         InitializeComponent();
         _GrayScaleExtendedCommand = new GrayScaleExtendedCommand();
         
         //Set command default values
         InitializeUI();
      }

      public GrayScaleExtendedCommand GrayScaleExtendedCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _GrayScaleExtendedCommand;
         }
         set
         {
            _GrayScaleExtendedCommand = value;
            InitializeUI(); 
         }
      }

      private void InitializeUI()
      {
         _Red = 300;
         _Green = 590;
         _Blue = 110;

         _numRed.Value = _Red;
         _numGreen.Value = _Green;
         _numBlue.Value = _Blue;  
      }

      private void UpdateCommand()
      {
         _Red = Convert.ToInt32(_numRed.Value);
         _Green = Convert.ToInt32(_numGreen.Value);
         _Blue = Convert.ToInt32(_numBlue.Value);

         _GrayScaleExtendedCommand.RedFactor = _Red;
         _GrayScaleExtendedCommand.GreenFactor = _Green;
         _GrayScaleExtendedCommand.BlueFactor = _Blue;
      }

      private void _tbRed_Scroll(object sender, EventArgs e)
      {
         /*if ((_numRed.Value + _numGreen.Value + _numBlue.Value) >= 1000)
         {
            _numRed.Value = 1000 - (_numGreen.Value + _numBlue.Value);
            _tbRed.Value = Convert.ToInt32(_numRed.Value);
         }
         else*/
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

      private void _numRed_ValueChanged(object sender, EventArgs e)
      {
         _tbRed.Value = Convert.ToInt32(_numRed.Value);    
      }

      private void _numGreen_ValueChanged(object sender, EventArgs e)
      { 
         _tbGreen.Value = Convert.ToInt32(_numGreen.Value);
      }

      private void _numBlue_ValueChanged(object sender, EventArgs e)
      {
         _tbBlue.Value = Convert.ToInt32(_numBlue.Value);
      }

      private void _numRed_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
         if (_numRed.Value != _numRed.Maximum)
         {
            _numRed.Value = _numRed.Value + 1;
            _numRed.Value = _numRed.Value - 1;
         }
      }

      private void _numGreen_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
         if (_numGreen.Value != _numGreen.Maximum)
         {
            _numGreen.Value = _numGreen.Value + 1;
            _numGreen.Value = _numGreen.Value - 1;
         }
      }

      private void _numBlue_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
         if (_numBlue.Value != _numBlue.Maximum)
         {
            _numBlue.Value = _numBlue.Value + 1;
            _numBlue.Value = _numBlue.Value - 1;
         }
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         if ((_numRed.Value + _numGreen.Value + _numBlue.Value) > 1000)
         {
            MessageBox.Show(DemosGlobalization.GetResxString(GetType(), "resx_sumErrorMsg"), DemosGlobalization.GetResxString(GetType(), "resx_sumErrorMsgTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            _numRed.Value = _Red+1;
            _numGreen.Value = _Green +1;
            _numBlue.Value = _Blue+1;

            _numRed.Value = _numRed.Value -1;
            _numGreen.Value = _numGreen.Value - 1;
            _numBlue.Value = _numBlue.Value  -1 ;   
 
         }
         else
         {
            UpdateCommand();
            this.DialogResult = DialogResult.OK;
            this.Close();
         }
      }
      
      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
      }
   }
}
