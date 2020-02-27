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
    public partial class SigmaDialog : Form
    {
        private static int _dimension;
        private static bool _outline;
        private static float _threshold;
        private static int _sigma;

        public int Dimension
        {
            get { return _dimension; }
        }

        public int Sigma
        {
            get { return SigmaDialog._sigma; }
        }

        public float Threshold
        {
            get { return SigmaDialog._threshold; }
        }

        public bool Outline
        {
            get { return SigmaDialog._outline; }
        }
       
        public SigmaDialog()
        {
            InitializeComponent();
        }

        private void Sigma_Load(object sender, EventArgs e)
        {
             SigmaCommand cmd = new SigmaCommand();
             _dimension = cmd.Dimension;
             _outline = cmd.Outline;
             _threshold = cmd.Threshold;
             _sigma = cmd.Sigma;

            _numDimension.Value      = _dimension;
            _numThreshold.Value      = (decimal)_threshold;
            _numSigma.Value          = _sigma;
            _cbOutline.Checked       = _outline;
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            _dimension = (int)_numDimension.Value;
            _threshold=(float)_numThreshold.Value  ;
            _sigma = (int)_numSigma.Value;
            _outline = _cbOutline.Checked;
        }
    }
}
