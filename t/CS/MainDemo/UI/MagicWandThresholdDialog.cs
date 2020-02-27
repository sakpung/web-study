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

namespace MainDemo
{
   public partial class MagicWandThresholdDialog : Form
   {

      public int Value;
      public MagicWandThresholdDialog()
      {
         InitializeComponent();
      }

      private void _txtThreshold_TextChanged(object sender, EventArgs e)
      {
         try
         {
            int val = int.Parse(_txtThreshold.Text);
            if (val > _tbThreshold.Maximum)
            {
               val = _tbThreshold.Maximum;
               _txtThreshold.Text = _tbThreshold.Maximum.ToString();
            }

            if (val < _tbThreshold.Minimum)
            {
               val = _tbThreshold.Minimum;
               _txtThreshold.Text = _tbThreshold.Minimum.ToString();
            }

            _tbThreshold.Value = val;
         }
         catch
         {
         }
      }

      private void _txtThreshold_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (!e.Handled)
         {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
               e.Handled = true;
         }
      }

      private void MagicWandThresholdDialog_Load(object sender, EventArgs e)
      {
         _txtThreshold.Text = Value.ToString();
      }

      private void _tbThreshold_Scroll(object sender, EventArgs e)
      {
         _txtThreshold.Text = _tbThreshold.Value.ToString();
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         Value = _tbThreshold.Value;
      }
   }
}
