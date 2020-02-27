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
   //will be used for the UnsharpMaskCommand

   public partial class UnsharpMaskDialog : Form
   {
      private UnsharpMaskCommand _UnsharpMaskCommand;
      private int _Amount;
      private int _Radius;
      private int _Threshold;

      public UnsharpMaskDialog()
      {
         InitializeComponent();
         _UnsharpMaskCommand = new UnsharpMaskCommand();

         //Set command default values
         _Amount = 0;
         _Radius = 1;
         _Threshold = 0;
         InitializeUI();
      }

      public UnsharpMaskCommand UnsharpMaskCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _UnsharpMaskCommand;
         }
         set
         {
            _UnsharpMaskCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {


         _cmbColorType.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_RGBColorSpace"));
         _cmbColorType.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_YUVColorSpace"));

         _cmbColorType.SelectedIndex = 0;

         _Amount = 0;
         _Radius = 1;
         _Threshold = 0;

         _txbAmount.Text = _Amount.ToString();
         _txbRadius.Text = _Radius.ToString();
         _txbThreshold.Text = _Threshold.ToString();
      }

      private void UpdateCommand()
      {
         _Amount = Convert.ToInt32(_txbAmount.Text);
         _Radius = Convert.ToInt32(_txbRadius.Text);
         _Threshold = Convert.ToInt32(_txbThreshold.Text);

         _UnsharpMaskCommand.ColorType = TranslateColorType();
         _UnsharpMaskCommand.Amount = _Amount;
         _UnsharpMaskCommand.Radius = _Radius;
         _UnsharpMaskCommand.Threshold = _Threshold;
      }

      private UnsharpMaskCommandColorType TranslateColorType()
      {
         switch (_cmbColorType.SelectedIndex)
         {
            case 0:
               return UnsharpMaskCommandColorType.Rgb;
            case 1:
               return UnsharpMaskCommandColorType.Yuv;
            default:
               return UnsharpMaskCommandColorType.Rgb;
         }
      }
      private void _tbAmount_Scroll(object sender, EventArgs e)
      {
         _txbAmount.Text = _tbAmount.Value.ToString();
      }

      private void _txbAmount_TextChanged(object sender, EventArgs e)
      {
         try
         {
            _txbAmount.Text = MainForm.IsValidNumber(_txbAmount.Text, 0, 500);

            int Val = int.Parse(_txbAmount.Text);
            if (Val >= _tbAmount.Minimum && Val <= _tbAmount.Maximum)
               _tbAmount.Value = Val;
         }
         catch
         {
         }
      }

      private void _tbRadius_Scroll(object sender, EventArgs e)
      {
         _txbRadius.Text = _tbRadius.Value.ToString();
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

      private void _tbThreshold_Scroll(object sender, EventArgs e)
      {
         _txbThreshold.Text = _tbThreshold.Value.ToString();
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
