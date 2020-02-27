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

using Leadtools.ImageProcessing.Effects;
using Leadtools;

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the EdgeDetectEffectCommand

   public partial class EdgeDetectEffectDialog : Form
   {
      private EdgeDetectEffectCommand _EdgeDetectEffectCommand;
      private int _Level;
      private int _Threshold;

      public EdgeDetectEffectDialog()
      {
         InitializeComponent();
         _EdgeDetectEffectCommand = new EdgeDetectEffectCommand();

         //Set command default values
         _Level = 50;
         _Threshold = 0;
         InitializeUI();
      }

      public EdgeDetectEffectCommand EdgeDetectEffectCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _EdgeDetectEffectCommand;
         }
         set
         {
            _EdgeDetectEffectCommand = value;
            InitializeUI();
         }
      }

      private void _tbLevel_Scroll(object sender, EventArgs e)
      {
         _txbLevel.Text = _tbLevel.Value.ToString();
      }

      private void _txbLevel_TextChanged(object sender, EventArgs e)
      {
         try
         {
            _txbLevel.Text = MainForm.IsValidNumber(_txbLevel.Text, 1, 100);

            int Val = int.Parse(_txbLevel.Text);
            if (Val >= _tbLevel.Minimum && Val <= _tbLevel.Maximum)
               _tbLevel.Value = Val;
         }
         catch
         {
         }
      }

      private void InitializeUI()
      {
         string[] names;

         names = Enum.GetNames(typeof(EdgeDetectEffectCommandType));

         foreach (string name in names)
            _cmbType.Items.Add(name);
         _cmbType.SelectedIndex = 0;

         _txbLevel.Text = _Level.ToString();
         _txbThreshold.Text = _Threshold.ToString();
         _EdgeDetectEffectCommand.Type = EdgeDetectEffectCommandType.Smooth;
      }

      private void UpdateCommand()
      {
         _Level = Convert.ToInt32(_txbLevel.Text);
         _Threshold = Convert.ToInt32(_txbThreshold.Text);

         _EdgeDetectEffectCommand.Type = TranslateType();
         _EdgeDetectEffectCommand.Level = _Level;
         _EdgeDetectEffectCommand.Threshold = _Threshold;
      }

      public EdgeDetectEffectCommandType TranslateType()
      {
         switch (_cmbType.SelectedIndex)
         {
            case 0:
               return EdgeDetectEffectCommandType.Smooth;
            case 1:
               return EdgeDetectEffectCommandType.Solid;
            default:
               return EdgeDetectEffectCommandType.Smooth;
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
