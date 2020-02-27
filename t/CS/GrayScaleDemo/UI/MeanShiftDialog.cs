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
    public partial class MeanShiftDialog : Form
    {
        private static int _radius;
        private static int _colorDistance;

        public int Radius;
        public int ColorDistance;

        public MeanShiftDialog()
        {
            InitializeComponent();
        }

        private void MeanShiftDialog_Load(object sender, EventArgs e)
        {
          MeanShiftCommand cmd = new MeanShiftCommand();
          _radius = cmd.Radius;
          _colorDistance = cmd.ColorDistance;

            Radius = _radius;
            ColorDistance = _colorDistance;

            _numRadius.Value = Radius;
            _numColorDistance.Value = ColorDistance;
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            Radius = (int)_numRadius.Value;
            ColorDistance = (int)_numColorDistance.Value;

            _radius = Radius;
            _colorDistance = ColorDistance;
        }




    }
}
