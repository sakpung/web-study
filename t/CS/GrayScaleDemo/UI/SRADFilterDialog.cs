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

using Leadtools;
using Leadtools.ImageProcessing.Core;

namespace GrayScaleDemo
{
   public partial class SRADFilterDialog : Form
   {
      public int _lambda;
      public int _iterations;

      public int Lambda;
      public int Iterations;

      public SRADFilterDialog()
      {
         InitializeComponent();
      }

      private void SRADFilterDialog_Load(object sender, EventArgs e)
      {
         SRADAnisotropicDiffusionCommand cmd = new SRADAnisotropicDiffusionCommand();
         _lambda = cmd.Lambda;
         _iterations = cmd.Iterations;


         Lambda = _lambda;
         Iterations = _iterations;

         _numIterations.Value = Iterations;
         _numLambda.Value = Lambda;
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         Lambda = (int)_numLambda.Value;
         Iterations = (int)_numIterations.Value;

         _lambda = Lambda;
         _iterations = Iterations;
      }
   }
}
