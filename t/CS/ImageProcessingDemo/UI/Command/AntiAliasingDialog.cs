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
   //will be used for the AntiAliasingCommand

   public partial class AntiAliasingDialog : Form
   {
      private AntiAliasingCommand _AntiAliasingCommand;
      private int _Threshold, _MaskSize;

      public AntiAliasingDialog()
      {
         InitializeComponent();
         _AntiAliasingCommand = new AntiAliasingCommand();
         _Threshold = 0;
         _MaskSize = 2;
         //Set command default values
         InitializeUI();
      }

      public AntiAliasingCommand AntiAliasingCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _AntiAliasingCommand;
         }
         set
         {
            _AntiAliasingCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {
         _cmbFilter.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_VerticallyandHorizontally"));
         _cmbFilter.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_AllDirections1"));
         _cmbFilter.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_AllDirections2"));
         _cmbFilter.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_Diagonally"));
         _cmbFilter.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_Horizontally"));
         _cmbFilter.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_Vertically"));

         _cmbFilter.SelectedIndex = 0;

         _txbThreshold.Text = _Threshold.ToString();
         _txbMaskSize.Text = _MaskSize.ToString();
      }

      private void UpdateCommand()
      {
         if (_txbThreshold.Text != "")
            _AntiAliasingCommand.Threshold = Convert.ToInt32(_txbThreshold.Text);
         if (_txbMaskSize.Text != "")
            _AntiAliasingCommand.Dimension = Convert.ToInt32(_txbMaskSize.Text);


         _AntiAliasingCommand.Filter = TranslateFilter();
      }

      public AntiAliasingCommandType TranslateFilter()
      {
         switch (_cmbFilter.SelectedIndex)
         {
            case 0:
               return AntiAliasingCommandType.Type1;
            case 1:
               return AntiAliasingCommandType.Type2;
            case 2:
               return AntiAliasingCommandType.Type3;
            case 3:
               return AntiAliasingCommandType.Diagonal;
            case 4:
               return AntiAliasingCommandType.Horizontal;
            case 5:
               return AntiAliasingCommandType.Vertical;
            default:
               return AntiAliasingCommandType.Type1;
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

      private void _tbMaskSize_Scroll(object sender, EventArgs e)
      {
         _txbMaskSize.Text = _tbMaskSize.Value.ToString();
      }

      private void _txbMaskSize_TextChanged(object sender, EventArgs e)
      {
         try
         {
            _txbMaskSize.Text = MainForm.IsValidNumber(_txbMaskSize.Text, 2, 100);

            int Val = int.Parse(_txbMaskSize.Text);
            if (Val >= _tbMaskSize.Minimum && Val <= _tbMaskSize.Maximum)
               _tbMaskSize.Value = Val;
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
