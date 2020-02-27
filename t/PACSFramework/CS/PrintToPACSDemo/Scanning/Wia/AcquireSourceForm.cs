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

namespace PrintToPACSDemo
{
   public partial class AcquireSourceForm : Form
   {
      public AcquireSourceForm()
      {
         InitializeComponent();
      }

      private void AcquireSourceForm_Load(object sender, EventArgs e)
      {
         _lbAcquireSources.Items.Add("Feeder");
         _lbAcquireSources.Items.Add("Flatbed");
         _lbAcquireSources.SelectedIndex = 0;
      }

      private void _lbAcquireSources_DoubleClick(object sender, EventArgs e)
      {
         if(_lbAcquireSources.SelectedIndex == 0)  // Feeder selected
         {
            FrmMain._acquireFromFeeder = true;
         }
         else
         {
            FrmMain._acquireFromFeeder = false;
         }

         DialogResult = DialogResult.OK;
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         if (_lbAcquireSources.SelectedIndex == 0)  // Feeder selected
         {
            FrmMain._acquireFromFeeder = true;
         }
         else
         {
            FrmMain._acquireFromFeeder = false;
         }

         DialogResult = DialogResult.OK;
      }
   }
}
