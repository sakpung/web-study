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

using Leadtools.ImageProcessing;

namespace MainDemo
{
   public partial class FlipDialog : Form
   {
      private static bool _firstTimer = true;
      private static bool _initialHorizontal;
      public bool Horizontal;

      public FlipDialog( )
      {
         InitializeComponent();
      }

      private void FlipDialog_Load(object sender, System.EventArgs e)
      {
         if(_firstTimer)
         {
            _firstTimer = false;
            FlipCommand command = new FlipCommand();
            _initialHorizontal = command.Horizontal;
         }

         Horizontal = _initialHorizontal;
         _rbHorizontal.Checked = Horizontal;
         _rbVertical.Checked = !Horizontal;
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         Horizontal = _rbHorizontal.Checked;
         _initialHorizontal = Horizontal;
      }
   }
}
