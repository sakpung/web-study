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


namespace MainDemo
{
    public partial class TADAnisotropicDialog : Form
    {
        public TADAnisotropicDiffusionFlags Flux;
        public int Lambda;
        public int Kappa;
        public int Iterations;

        public TADAnisotropicDialog()
        {
            InitializeComponent();
            _cbFlux.SelectedIndex = 0;
        }

        private void TADAnisotropicDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Lambda = (int)_numLambda.Value;
            Kappa = (int)_numKappa.Value;
            Iterations = (int)_numIterations.Value;

            Flux = (_cbFlux.SelectedIndex == 0) ? TADAnisotropicDiffusionFlags.ExponentialFlux : TADAnisotropicDiffusionFlags.QuadraticFlux;
        }

    }
}
