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
using Leadtools.ImageProcessing.Core;

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the MedianCommand

   public partial class MedianDialog : Form
   {
      private MedianCommand _MedianCommand = null;
      private int _Dimension;

      public MedianDialog()
      {
         InitializeComponent();
         _MedianCommand = new MedianCommand();

         //Set command default values
         InitializeUI();

      }

      public MedianCommand Mediancommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _MedianCommand;
         }
         set
         {
            _MedianCommand = value;
            InitializeUI();
         }
      }

      private void _txbDimension_TextChanged(object sender, EventArgs e)
      {
         try
         {
            _txbDimension.Text = MainForm.IsValidNumber(_txbDimension.Text, 1, 100);

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
         _MedianCommand.Dimension = Convert.ToInt32(_txbDimension.Text);
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
