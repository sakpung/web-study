// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JobProcessorAdministratorDemo
{
   public partial class TroubleshootingDlg : Form
   {
      public TroubleshootingDlg()
      {
         InitializeComponent();

         _chkDoNotShowAgain.Checked = !Properties.Settings.Default.ShowTroubleShooting;
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         //Do not show message again
         Properties.Settings.Default.ShowTroubleShooting = !_chkDoNotShowAgain.Checked;
         Properties.Settings.Default.Save();
         this.Close();
      }
   }
}
