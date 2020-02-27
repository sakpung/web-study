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

namespace CSMasterFormsEditor
{
   public partial class RegionForm : Form
   {
      public RegionForm()
      {
         InitializeComponent();
      }

      public bool UseIncludeRegions
      {
         get { return _chkIncludeRegions.Checked; }
         set { _chkIncludeRegions.Checked = value; }
      }

      public bool UseExcludeRegions
      {
         get { return _chkExcludeRegions.Checked; }
         set { _chkExcludeRegions.Checked = value; }
      }

      public bool UseInterestRegions
      {
         get { return _chkRegionsOfInterest.Checked; }
         set { _chkRegionsOfInterest.Checked = value; }
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         if (!_chkExcludeRegions.Checked && !_chkIncludeRegions.Checked && !_chkRegionsOfInterest.Checked)
         {
            MessageBox.Show("You must select at least one option", "Error");
            return;
         }

         this.DialogResult = DialogResult.OK;
         this.Close();
      }
   }
}
