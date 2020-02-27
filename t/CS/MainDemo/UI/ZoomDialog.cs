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
   public partial class ZoomDialog : Form
   {
      public int Value;
      public int MinimumValue;
      public int MaximumValue;

      public ZoomDialog( )
      {
         InitializeComponent();
      }

      private void ZoomDialog_Load(object sender, System.EventArgs e)
      {
         _tbZoom.Minimum = MinimumValue;
         _tbZoom.Maximum = MaximumValue;
         _tbPercentage.Text = Value.ToString();
      }

      private void _tbPercentage_TextChanged(object sender, System.EventArgs e)
      {
         try
         {
            int val = int.Parse(_tbPercentage.Text);
            if(val >= _tbZoom.Minimum && val <= _tbZoom.Maximum)
               _tbZoom.Value = val;
         }
         catch
         {
         }
      }

      private void _tbPercentage_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
      {
         if(!e.Handled)
         {
            if(!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
               e.Handled = true;
         }
      }

      private void _tbZoom_Scroll(object sender, System.EventArgs e)
      {
         _tbPercentage.Text = _tbZoom.Value.ToString();
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         Value = _tbZoom.Value;
      }
   }
}
