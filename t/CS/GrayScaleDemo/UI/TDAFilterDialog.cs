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

   public partial class TDAFilterDialog : Form
   {
      private static TADAnisotropicDiffusionFlags _flux;

      private static int _lambda;
      private static int _kappa;
      private static int _iterations;
      public int Lambda;
      public int Kappa;
      public int Iterations;
      public TADAnisotropicDiffusionFlags Flux;

      public TDAFilterDialog()
      {
         InitializeComponent();
      }

      private void TDAFilter_Load(object sender, EventArgs e)
      {

         TADAnisotropicDiffusionCommand cmd = new TADAnisotropicDiffusionCommand();
         _flux = TADAnisotropicDiffusionFlags.ExponentialFlux;

         _lambda = cmd.Lambda;
         _kappa = cmd.Kappa;
         _iterations = cmd.Iterations;

         Flux = _flux;

         Lambda = _lambda;
         Kappa = _kappa;
         Iterations = _iterations;

         _numLambda.Value = Lambda;
         _numKappa.Value = Kappa;
         _numIterations.Value = Iterations;
         switch (Flux)
         {
            case TADAnisotropicDiffusionFlags.ExponentialFlux:
               _cbFlux.SelectedIndex = 0;
               break;
            case TADAnisotropicDiffusionFlags.QuadraticFlux:
               _cbFlux.SelectedIndex = 1;
               break;
         }
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         _iterations = (int)_numIterations.Value;
         _kappa = (int)_numKappa.Value;
         _lambda = (int)_numLambda.Value;

         switch (_cbFlux.SelectedIndex)
         {
            case 0:
               _flux = TADAnisotropicDiffusionFlags.ExponentialFlux;
               break;
            case 1:
               _flux = TADAnisotropicDiffusionFlags.QuadraticFlux;
               break;
         }

         Iterations = _iterations;
         Lambda = _lambda;
         Kappa = _kappa;
         Flux = _flux;
      }
   }
}
