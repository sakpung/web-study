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

using Leadtools.Demos;

namespace OcrZonesRubberBandDemo
{
   public partial class SetResolution : Form
   {
      public int _xRes;
      public int _yRes;

      public SetResolution()
      {
         InitializeComponent();
      }

      private void SetResolution_Load(object sender, EventArgs e)
      {
         _txtXRes.Text = _xRes.ToString();
         _txtYRes.Text = _yRes.ToString();
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         try
         {
            _xRes = Convert.ToInt32(_txtXRes.Text);
            _yRes = Convert.ToInt32(_txtYRes.Text);
            if ((_xRes >= 10 && _xRes <= 1000) && (_yRes >= 10 && _yRes <= 1000))
               DialogResult = DialogResult.OK;
            else
               Messager.ShowError(this, "Please enter an integer between 10 and 1000");
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex.Message);
         }
      }

      private void _txtXRes_TextChanged(object sender, EventArgs e)
      {
         CheckOkButton();
      }

      private void _txtYRes_TextChanged(object sender, EventArgs e)
      {
         CheckOkButton();
      }

      private void CheckOkButton()
      {
         try
         {
            if (_txtXRes.Text != "" && _txtYRes.Text != "")
               _btnOk.Enabled = true;
            else
               _btnOk.Enabled = false;
         }
         catch
         {
         }
      }

      private void _txtXRes_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            e.Handled = true;
      }

      private void _txtYRes_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            e.Handled = true;
      }
   }
}
