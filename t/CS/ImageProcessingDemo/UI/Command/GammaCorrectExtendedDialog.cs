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
   //will be used for the GammaCorrectExtendedCommand

   public partial class GammaCorrectExtendedDialog : Form
   {
      private GammaCorrectExtendedCommand _GammaCorrectExtendedCommand;
      private int _Gamma;

      public GammaCorrectExtendedDialog()
      {
         InitializeComponent();
         _GammaCorrectExtendedCommand = new GammaCorrectExtendedCommand();

         //Set command default values
         _Gamma = 250;
         InitializeUI();
      }

      public GammaCorrectExtendedCommand GammaCorrectExtendedCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _GammaCorrectExtendedCommand;
         }
         set
         {
            _GammaCorrectExtendedCommand = value;
            InitializeUI();

         }
      }

      private void InitializeUI()
      {
         if ((_GammaCorrectExtendedCommand.Type & GammaCorrectExtendedCommandType.RgbSpace) == GammaCorrectExtendedCommandType.RgbSpace)
            _rbRgb.Checked = true;
         if ((_GammaCorrectExtendedCommand.Type & GammaCorrectExtendedCommandType.YuvSpace) == GammaCorrectExtendedCommandType.YuvSpace)
            _rbYuv.Checked = true;

         _Gamma = 250;
         _txbGamma.Text = _Gamma.ToString();


      }

      private void UpdateCommand()
      {
         _GammaCorrectExtendedCommand.Type = (GammaCorrectExtendedCommandType)0;
         if (_rbRgb.Checked)
            _GammaCorrectExtendedCommand.Type = GammaCorrectExtendedCommandType.RgbSpace;
         if (_rbYuv.Checked)
            _GammaCorrectExtendedCommand.Type = GammaCorrectExtendedCommandType.YuvSpace;

         if (_txbGamma.Text != "")
            _Gamma = Convert.ToInt32(_txbGamma.Text);

         _GammaCorrectExtendedCommand.Gamma = _Gamma;
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
