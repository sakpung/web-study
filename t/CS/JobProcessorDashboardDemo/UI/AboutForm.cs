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
   public partial class AboutForm : Form
   {
      public AboutForm()
      {
         InitializeComponent();

         _chkDoNotShowAgain.Checked = !Properties.Settings.Default.ShowAbout;
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         //Do not show message again
         Properties.Settings.Default.ShowAbout = !_chkDoNotShowAgain.Checked;
         Properties.Settings.Default.Save();
         this.Close();
      }
   }
}
