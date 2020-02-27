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

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the GaussianCommand

   public partial class GaussianDialog : Form
   {
      private int _Radius;

      public GaussianDialog()
      {
         InitializeComponent();

         //Set command default values
         _Radius = 1;
         InitializeUI();
      }

      public int Radius
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _Radius;
         }
         set
         {
            _Radius = value;
            InitializeUI();
         }
      }

      private void _txbRadius_TextChanged(object sender, EventArgs e)
      {
         try
         {
            _txbRadius.Text = MainForm.IsValidNumber(_txbRadius.Text, 1, 1000);

            int Val = int.Parse(_txbRadius.Text);
            if (Val >= _tbRadius.Minimum && Val <= _tbRadius.Maximum)
               _tbRadius.Value = Val;
         }
         catch
         {
         }
      }

      private void _tbRadius_Scroll(object sender, EventArgs e)
      {
         _txbRadius.Text = _tbRadius.Value.ToString();
      }

      private void InitializeUI()
      {
         _txbRadius.Text = _Radius.ToString();
      }
      private void UpdateCommand()
      {
         _Radius = Convert.ToInt32(_txbRadius.Text);
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
