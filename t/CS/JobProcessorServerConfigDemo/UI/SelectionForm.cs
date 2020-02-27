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

namespace JobProcessorServerConfigDemo
{
   public partial class Selection : Form
   {
      string _selectedToolkit = string.Empty;

      public string SelectedToolkit
      {
         get { return _selectedToolkit; }
      }

      public Selection(string [] _toolkits)
      {
         InitializeComponent();
         _cmbToolkits.Items.AddRange(_toolkits);
         _cmbToolkits.SelectedIndex = 0;
      }

      private void button1_Click(object sender, EventArgs e)
      {
         _selectedToolkit = (string)_cmbToolkits.SelectedItem;
      }
   }
}
