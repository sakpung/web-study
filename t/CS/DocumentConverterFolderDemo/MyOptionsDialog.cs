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

using Leadtools.Demos;

namespace DocumentConverterDemo
{
   public partial class MyOptionsDialog : Form
   {
      public MyOptions MyOptions;

      public MyOptionsDialog()
      {
         InitializeComponent();
      }

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
            _propertyGrid.SelectedObject = MyOptions;

         base.OnLoad(e);
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         if (string.IsNullOrEmpty(MyOptions.InputFolder))
         {
            Warn("Please select an input folder");
            return;
         }

         if (string.IsNullOrEmpty(MyOptions.OutputFolder))
         {
            Warn("Please select an output folder");
            return;
         }
      }

      private void Warn(string message)
      {
         MessageBox.Show(this, message, Messager.Caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         DialogResult = DialogResult.None;
      }
   }
}
