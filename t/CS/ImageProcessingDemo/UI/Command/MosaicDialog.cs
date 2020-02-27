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
   //will be used for the MosaicCommand

   public partial class MosaicDialog : Form
   {
      private MosaicCommand _MosaicCommand = null;
      private int _Dimension;

      public MosaicDialog()
      {
         InitializeComponent();
         _MosaicCommand = new MosaicCommand();

         //Set command default values
         InitializeUI();

      }

      public MosaicCommand Mosaiccommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _MosaicCommand;
         }
         set
         {
            _MosaicCommand = value;
            InitializeUI();
         }
      }

      private void _txbDimension_TextChanged(object sender, EventArgs e)
      {
         try
         {
            _txbDimension.Text = MainForm.IsValidNumber(_txbDimension.Text, 1, 64);

            int Val = int.Parse(_txbDimension.Text);
            if (Val >= _tbDimension.Minimum && Val <= _tbDimension.Maximum)
               _tbDimension.Value = Val;
         }
         catch
         {
         }
      }

      private void _tbDimension_Scroll(object sender, EventArgs e)
      {
         _txbDimension.Text = _tbDimension.Value.ToString();
      }

      private void InitializeUI()
      {
         _Dimension = 2;
         _txbDimension.Text = _Dimension.ToString();
      }

      private void UpdateCommand()
      {
         _MosaicCommand.Dimension = Convert.ToInt32(_txbDimension.Text);
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         UpdateCommand();
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         InitializeUI();
         this.DialogResult = DialogResult.Cancel;
      }
   }
}
