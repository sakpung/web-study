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

namespace Main3DDemo
{
   public partial class LoadAs3D : Form
   {
      private MainForm _mainForm;

      public LoadAs3D(MainForm mainForm)
      {
         InitializeComponent();
         _mainForm = mainForm;
         _mainForm.LoadAsMultiFrame = false;
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         _mainForm.LoadAsMultiFrame = _radioMultiFrames.Checked;
      }
   }
}
