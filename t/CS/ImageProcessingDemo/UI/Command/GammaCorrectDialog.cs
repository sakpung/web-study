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

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the GammaCorrectCommand

   public partial class GammaCorrectDialog : Form
   {
      private GammaCorrectCommand _GammaCorrectCommand;
      private int _Gamma;

      public GammaCorrectDialog()
      {
         InitializeComponent();
         _GammaCorrectCommand = new GammaCorrectCommand();

         //Set command default values
         _Gamma = 250;
         InitializeUI();

      }

      public GammaCorrectCommand GammaCorrectCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _GammaCorrectCommand;
         }
         set
         {
            _GammaCorrectCommand = value;
            InitializeUI();

         }
      }

      private void InitializeUI()
      {

         _Gamma = 250;
         _txbGamma.Text = _Gamma.ToString();
      }

      private void UpdateCommand()
      {
         if (_txbGamma.Text != "")
            _Gamma = Convert.ToInt32(_txbGamma.Text);

         _GammaCorrectCommand.Gamma = _Gamma;
      }

      private void _tbGamma_Scroll(object sender, EventArgs e)
      {
         _txbGamma.Text = _tbGamma.Value.ToString();
      }

      private void _txbGamma_TextChanged(object sender, EventArgs e)
      {
         try
         {
            _txbGamma.Text = MainForm.IsValidNumber(_txbGamma.Text, 1, 500);

            int Val = int.Parse(_txbGamma.Text);
            if (Val >= _tbGamma.Minimum && Val <= _tbGamma.Maximum)
               _tbGamma.Value = Val;
         }
         catch
         {
         }
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
