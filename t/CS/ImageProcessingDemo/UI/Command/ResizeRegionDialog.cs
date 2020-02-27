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
   //will be used for the ResizeRegionCommand

   public partial class ResizeRegionDialog : Form
   {
      private ResizeRegionCommand _ResizeRegionCommand;
      private int _Dimension;
      private bool _AsFrame;

      public ResizeRegionDialog()
      {
         InitializeComponent();
         _ResizeRegionCommand = new ResizeRegionCommand();
         _Dimension = 1;
         _AsFrame = true;
         
         //Set command default values
         InitializeUI();
      }

      public ResizeRegionCommand ResizeRegionCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _ResizeRegionCommand;
         }
         set
         {
            _ResizeRegionCommand = value;
            InitializeUI();
         }
      }
      private void InitializeUI()
      {
         string[] names;
         names = Enum.GetNames(typeof(ResizeRegionCommandType));
         foreach (string name in names)
         {
            _cmbType.Items.Add(name);
         }
         _cmbType.SelectedIndex = _cmbType.Items.IndexOf(_ResizeRegionCommand.Type.ToString());

         _Dimension = 20;
         _AsFrame = true;

         _txbDimension.Text = _Dimension.ToString();
         _chkFrame.Checked = _AsFrame;
      }

      private void UpdateCommand()
      {
         _Dimension = Convert.ToInt32(_txbDimension.Text);
         _AsFrame = _chkFrame.Checked;

         _ResizeRegionCommand.Dimension = _Dimension;
         _ResizeRegionCommand.AsFrame = _AsFrame;
         _ResizeRegionCommand.Type = TranslateType();
      }
      private ResizeRegionCommandType TranslateType()
      {
         switch (_cmbType.SelectedIndex)
         {
            case 0:
               return ResizeRegionCommandType.ExpandRegion;
            case 1:
               return ResizeRegionCommandType.ContractRegion;
            default:
               return ResizeRegionCommandType.ExpandRegion;
         }
      }
      private void _tbDimension_Scroll(object sender, EventArgs e)
      {
         _txbDimension.Text = _tbDimension.Value.ToString();
      }

      private void _txbDimension_TextChanged(object sender, EventArgs e)
      {
         try
         {
            _txbDimension.Text = MainForm.IsValidNumber(_txbDimension.Text, 1, 500);

            int Val = int.Parse(_txbDimension.Text);
            if (Val >= _tbDimension.Minimum && Val <= _tbDimension.Maximum)
               _tbDimension.Value = Val;
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
