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

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the ChangeIntensityCommand

   public partial class ChangeIntensityDialog : Form
   {
      public int Value;

      public ChangeIntensityDialog()
      {
         InitializeComponent();
      }

      private void ChangeIntensityDialog_Load(object sender, EventArgs e)
      {
         //Set command default values
         _txbBrightness.Text = Value.ToString();
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         Value = _tbBrightness.Value;
         this.DialogResult = DialogResult.OK;
      }

      private void _txbBrightness_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (!e.Handled)
         {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar) && !(e.KeyChar == '-'))
               e.Handled = true;
         }
      }

      private void _txbBrightness_TextChanged(object sender, EventArgs e)
      {
         try
         {
            //Update command values
            int Val = int.Parse(_txbBrightness.Text);
            if (Val >= _tbBrightness.Minimum && Val <= _tbBrightness.Maximum)
               _tbBrightness.Value = Val;
         }
         catch
         {
         }
      }

      private void _tbBrightness_Scroll(object sender, EventArgs e)
      {
         _txbBrightness.Text = _tbBrightness.Value.ToString();
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
      }
   }
}
