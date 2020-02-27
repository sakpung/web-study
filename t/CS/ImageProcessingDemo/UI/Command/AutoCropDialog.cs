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
   //will be used for the AutoCropCommand
   public partial class AutoCropDialog : Form
   {
      private int _Threshold;

      public AutoCropDialog()
      {
         InitializeComponent();
         _Threshold = 128;
         //Set command default values
         InitializeUI();
      }

      public int Threshold
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _Threshold;
         }
         set
         {
            _Threshold = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {
         _Threshold = 128;
         _txbThreshold.Text = _Threshold.ToString();
      }

      private void UpdateCommand()
      {
         _Threshold = Convert.ToInt32(_txbThreshold.Text);
      }

      private void _btnok_Click(object sender, EventArgs e)
      {
         UpdateCommand();
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void _btncancel_Click(object sender, EventArgs e)
      {
         InitializeUI();
         this.DialogResult = DialogResult.Cancel;
      }

      private void _txbThreshold_TextChanged(object sender, EventArgs e)
      {
         try
         {
            _txbThreshold.Text = MainForm.IsValidNumber(_txbThreshold.Text, 0, 255);

            int Val = int.Parse(_txbThreshold.Text);
            if (Val >= _tbThreshold.Minimum && Val <= _tbThreshold.Maximum)
               _tbThreshold.Value = Val;
         }
         catch
         {
         }
      }

      private void _tbThreshold_Scroll(object sender, EventArgs e)
      {
         _txbThreshold.Text = _tbThreshold.Value.ToString();
      }
   }
}
