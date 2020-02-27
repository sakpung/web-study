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

using Leadtools.ImageProcessing.Core;

namespace GrayScaleDemo
{
   public partial class LambdaConnectednessDialog : Form
   {
      private int _lambda;

      public int Lambda;
      public LambdaConnectednessDialog()
      {
         InitializeComponent();
      }

      private void LambdaConnectednessDialog_Load(object sender, EventArgs e)
      {
         _lambda = 950;

         Lambda = _lambda;
         _numLambda.Value = Lambda;
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         Lambda = (int)_numLambda.Value;
         _lambda = Lambda;
      }
   }
}
