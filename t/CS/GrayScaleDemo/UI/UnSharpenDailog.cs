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

using Leadtools.Demos;
using Leadtools.ImageProcessing.Effects;

namespace GrayScaleDemo
{
    public partial class UnSharpenDailog : Form
    {
        private static int _initialAmount;
        private static int _initialRadius;
        private static int _initialThreshold;
        private static UnsharpMaskCommandColorType _initialColorSpace;

        public int Amount;
        public int Radius;
        public int Threshold;
        public UnsharpMaskCommandColorType ColorSpace;
        
        public UnSharpenDailog(int bpp)
        {
            InitializeComponent();
            _numThreshold.Maximum = 255;
        }

        private void UnSharpenDailog_Load(object sender, EventArgs e)
        {
          UnsharpMaskCommand command = new UnsharpMaskCommand();
          _initialAmount = command.Amount;
          _initialRadius = command.Radius;
          _initialThreshold = command.Threshold;
          _initialColorSpace = command.ColorType;

            Amount = _initialAmount;
            Radius = _initialRadius;
            Threshold = _initialThreshold;
            ColorSpace = _initialColorSpace;

            _numAmount.Value = Amount;
            _numRadius.Value = Radius;
            _numThreshold.Value = Threshold;

            Tools.FillComboBoxWithEnum(_cbColorSpace, typeof(UnsharpMaskCommandColorType), ColorSpace, new object[] { UnsharpMaskCommandColorType.None });
        }
        private void _btnOk_Click(object sender, EventArgs e)
        {
            Amount = (int)_numAmount.Value;
            Radius = (int)_numRadius.Value;
            Threshold = (int)_numThreshold.Value;

            ColorSpace = (UnsharpMaskCommandColorType)Constants.GetValueFromName(
               typeof(UnsharpMaskCommandColorType),
               (string)_cbColorSpace.SelectedItem,
               _initialColorSpace);

            _initialAmount = Amount;
            _initialRadius = Radius;
            _initialThreshold = Threshold;
            _initialColorSpace = ColorSpace;
        }
    }
}
