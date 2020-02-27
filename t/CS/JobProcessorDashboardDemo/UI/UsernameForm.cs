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

namespace JobProcessorDashboardDemo
{
   public partial class UsernameForm : Form
   {
      public UsernameForm()
      {
         InitializeComponent();
      }

      public string UserName
      {
         get { return _txtUsername.Text; }
         set { _txtUsername.Text = value; }
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.OK;
         this.Close();
      }
   }
}
