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
using Leadtools.ImageProcessing;

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the GrayscaleCommand

   public partial class GrayScaleDialog : Form
   {
      private GrayscaleCommand _GrayscaleCommand = null;

      public GrayScaleDialog()
      {
         InitializeComponent();
         _GrayscaleCommand = new GrayscaleCommand();

         //Set command default values
         InitializeUI();
      }

      private void InitializeUI()
      {
         _cmbBitsPerPixel.Items.Add(8);
         _cmbBitsPerPixel.Items.Add(12);
         _cmbBitsPerPixel.Items.Add(16);
         _cmbBitsPerPixel.Items.Add(32);

         _cmbBitsPerPixel.SelectedIndex = 0;
         _GrayscaleCommand.BitsPerPixel = 8;
      }

      //Update command values
      private void UpdateCommand()
      {
         if (_cmbBitsPerPixel.Text != "")
            _GrayscaleCommand.BitsPerPixel = Convert.ToInt32(_cmbBitsPerPixel.Text);
         else
            _GrayscaleCommand.BitsPerPixel = 8;
      }

      public GrayscaleCommand Grayscalecommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _GrayscaleCommand;
         }
         set
         {
            _GrayscaleCommand = value;
            InitializeUI();
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
         InitializeUI();
         this.DialogResult = DialogResult.Cancel;
      }
   }
}
