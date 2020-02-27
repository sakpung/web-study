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
using Leadtools.ImageProcessing.SpecialEffects;

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the ImpressionistCommand 

   public partial class ImpressionistDialog : Form
   {
      private int _HorizontalSize;
      private int _VerticalSize;
      private RasterImage _RasImage;


      public ImpressionistDialog()
      {
         InitializeComponent();
         _HorizontalSize = 1;
         _VerticalSize = 1;

         //Set command default values
         InitializeUI();
      }

      public ImpressionistDialog(RasterImage TempImage)
      {
         InitializeComponent();
         _HorizontalSize = 1;
         _VerticalSize = 1;
         _RasImage = TempImage;
         InitializeUI();

      }
      public int HorizontalSize
      {
         get
         {
            UpdateCommand();
            return _HorizontalSize;
         }
         set
         {
            _HorizontalSize = value;
            InitializeUI();

         }
      }

      public int VerticalSize
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _VerticalSize;
         }
         set
         {
            _VerticalSize = value;
            InitializeUI();

         }
      }

      private void InitializeUI()
      {
         _HorizontalSize = 1;
         _VerticalSize = 1;

         _txbHorizontal.Text = _HorizontalSize.ToString();
         _txbVertical.Text = _VerticalSize.ToString();

         _tbHorizontal.Maximum = _RasImage.Width;
         _tbHorizontal.Minimum = 1;
         _tbVertical.Maximum = _RasImage.Height;
         _tbVertical.Minimum = 1;

      }

      private void UpdateCommand()
      {
         _HorizontalSize = Convert.ToInt32(_txbHorizontal.Text);
         _VerticalSize = Convert.ToInt32(_txbVertical.Text);
      }

      private void _btnok_Click(object sender, EventArgs e)
      {
         UpdateCommand();
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void _btncancel_Click(object sender, EventArgs e)
      {
         InitializeUI();
         this.DialogResult = DialogResult.Cancel;
      }

      private void _txbHorizontal_TextChanged(object sender, EventArgs e)
      {
         try
         {
            _txbHorizontal.Text = MainForm.IsValidNumber(_txbHorizontal.Text, 1, _RasImage.Width);

            int Val = int.Parse(_txbHorizontal.Text);
            if (Val >= _tbHorizontal.Minimum && Val <= _tbHorizontal.Maximum)
               _tbHorizontal.Value = Val;
         }
         catch
         {
         }
      }

      private void _txbVertical_TextChanged(object sender, EventArgs e)
      {
         try
         {
            _txbVertical.Text = MainForm.IsValidNumber(_txbVertical.Text, 1, _RasImage.Height);

            int Val = int.Parse(_txbVertical.Text);
            if (Val >= _tbVertical.Minimum && Val <= _tbVertical.Maximum)
               _tbVertical.Value = Val;
         }
         catch
         {
         }
      }

      private void _tbHorizontal_Scroll(object sender, EventArgs e)
      {
         _txbHorizontal.Text = _tbHorizontal.Value.ToString();
      }

      private void _tbVertical_Scroll(object sender, EventArgs e)
      {
         _txbVertical.Text = _tbVertical.Value.ToString();
      }


   }
}
