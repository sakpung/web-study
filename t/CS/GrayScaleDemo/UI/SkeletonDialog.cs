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

using Leadtools.ImageProcessing.Effects;

namespace GrayScaleDemo
{
    public partial class SkeletonDialog : Form
    {
        private static int _threshold;

        public int Threshold
        {
            get { return SkeletonDialog._threshold; }
        } 

        public SkeletonDialog(int max)
        {
            InitializeComponent();
            _numThreshold.Maximum = max;
        }

        private void SkeletonDialog_Load(object sender, EventArgs e)
        {
             SkeletonCommand cmd = new SkeletonCommand();
             _threshold = cmd.Threshold;

            _numThreshold.Value = _threshold;
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            _threshold = (int)_numThreshold.Value ;
        }
    }
}
