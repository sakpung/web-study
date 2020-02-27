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
   //will be used for the ContourFilterCommand

   public partial class ContourFilterDialog : Form
   {
      private ContourFilterCommand _ContourFilterCommand;
      private int _DeltaDirection;
      private int _MaximumError;
      private int _Threshold;

      public ContourFilterDialog()
      {
         InitializeComponent();
         _ContourFilterCommand = new ContourFilterCommand();

         //Set command default values
         InitializeUI();
      }

      public ContourFilterCommand ContourFilterCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _ContourFilterCommand;
         }
         set
         {
            _ContourFilterCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {
         string[] names;
         names = Enum.GetNames(typeof(ContourFilterCommandType));
         foreach (string name in names)
         {
            _cmbType.Items.Add(name);
         }
         _cmbType.SelectedIndex = _cmbType.Items.IndexOf(_ContourFilterCommand.Type.ToString());

         _DeltaDirection = 35;
         _MaximumError = 5;
         _Threshold = 15;

         _txbDeltaDirection.Text = _DeltaDirection.ToString();
         _txbMaximumError.Text = _MaximumError.ToString();
         _txbThreshold.Text = _Threshold.ToString();
      }

      private void UpdateCommand()
      {
         _DeltaDirection = Convert.ToInt32(_txbDeltaDirection.Text);
         _MaximumError = Convert.ToInt32(_txbMaximumError.Text);
         _Threshold = Convert.ToInt32(_txbThreshold.Text);

         _ContourFilterCommand.Type = TranslateType();
         _ContourFilterCommand.DeltaDirection = _DeltaDirection;
         _ContourFilterCommand.MaximumError = _MaximumError;
         _ContourFilterCommand.Threshold = _Threshold;
      }

      private ContourFilterCommandType TranslateType()
      {
         switch (_cmbType.SelectedIndex)
         {
            case 0:
               return ContourFilterCommandType.Thin;
            case 1:
               return ContourFilterCommandType.LinkBlackWhite;
            case 2:
               return ContourFilterCommandType.LinkGray;
            case 3:
               return ContourFilterCommandType.LinkColor;
            case 4:
               return ContourFilterCommandType.ApproxColor;
            default:
               return ContourFilterCommandType.Thin;

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

      private void _tbDeltaDirection_Scroll(object sender, EventArgs e)
      {
         _txbDeltaDirection.Text = _tbDeltaDirection.Value.ToString();
      }

      private void _txbDeltaDirection_TextChanged(object sender, EventArgs e)
      {
         try
         {
            _txbDeltaDirection.Text = MainForm.IsValidNumber(_txbDeltaDirection.Text, 1, 64);

            int Val = int.Parse(_txbDeltaDirection.Text);
            if (Val >= _tbDeltaDirection.Minimum && Val <= _tbDeltaDirection.Maximum)
               _tbDeltaDirection.Value = Val;
         }
         catch
         {
         }
      }

      private void _tbMaximumError_Scroll(object sender, EventArgs e)
      {
         _txbMaximumError.Text = _tbMaximumError.Value.ToString();

      }

      private void _txbMaximumError_TextChanged(object sender, EventArgs e)
      {
         try
         {
            _txbMaximumError.Text = MainForm.IsValidNumber(_txbMaximumError.Text, 0, 255);

            int Val = int.Parse(_txbMaximumError.Text);
            if (Val >= _tbMaximumError.Minimum && Val <= _tbMaximumError.Maximum)
               _tbMaximumError.Value = Val;
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
            _txbThreshold.Text = MainForm.IsValidNumber(_txbThreshold.Text, 1, 254);

            int Val = int.Parse(_txbThreshold.Text);
            if (Val >= _tbThreshold.Minimum && Val <= _tbThreshold.Maximum)
               _tbThreshold.Value = Val;
         }
         catch
         {
         }
      }

      private void _cmbType_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (_cmbType.SelectedItem.ToString() == "ApproxColor")
            _gbMaximumError.Enabled = true;
         else
            _gbMaximumError.Enabled = false;
      }
   }
}
