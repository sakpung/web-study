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

namespace MedicalViewerDemo
{
   public partial class DefaultImagesDialog : Form
   {
      public DefaultImagesDialog()
      {
         InitializeComponent();
      }

      private void okButton_Click(object sender, EventArgs e)
      {
         this.DialogResult = loadRadio.Checked ? DialogResult.Yes : DialogResult.No;
         this.Close();
      }
   }
}
