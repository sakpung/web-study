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
    public partial class SRADAnisotropicDialog : Form
    {
        public int Lambda;
        public int Iterations;

        public SRADAnisotropicDialog()
        {
            InitializeComponent();
        }

        private void SRADAnisotropicDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Lambda = (int)_numLambda.Value;
            Iterations = (int)_numIterations.Value;
        }

    }
}
