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

namespace FormsDemo
{
   public partial class BusyDialog : Form
   {
      public BusyDialog()
      {
         InitializeComponent();
      }

      public Label Label1
      {
         get { return _lblLabel1; }
      }

      public Label Label2
      {
         get { return _lblLabel2; }
      }

      public Label FormName
      {
         get { return _lblFormName; }
      }

      public ProgressBar Progress
      {
         get { return _progressBar; }
      }

      public Button Ok
      {
         get { return _btnOk; }
      }

      public Button Cancel
      {
         get { return _btnCancel; }
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         Visible = false;
         DialogResult = DialogResult.OK;
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         Visible = false;
         DialogResult = DialogResult.Cancel;
      }
   }
}
