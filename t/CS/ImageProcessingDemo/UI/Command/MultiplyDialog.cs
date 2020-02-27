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
   //will be used for the MultiplyCommand

   public partial class MultiplyDialog : Form
   {
      private MultiplyCommand _MultiplyCommand;
      private int _Factor; 

      public MultiplyDialog()
      {
         InitializeComponent();
         _MultiplyCommand = new MultiplyCommand();

         //Set command default values
         InitializeUI();
 
      }

      public MultiplyCommand MultiplyCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _MultiplyCommand;
         }
         set
         {
            _MultiplyCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {
         _Factor = 1;
         _numFactor.Value = _Factor;         
      }
      private void UpdateCommand()
      {
         _Factor = Convert.ToInt32(_numFactor.Value);

         _MultiplyCommand.Factor= _Factor;         
      }

      private void _numFactor_ValueChanged(object sender, EventArgs e)
      {
         _tbFactor.Value = Convert.ToInt32(_numFactor.Value);
      }

      private void _numFactor_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _tbFactor_Scroll(object sender, EventArgs e)
      {
         _numFactor.Value = _tbFactor.Value;
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
