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

using Leadtools.ImageProcessing.Color;
using Leadtools.Demos;
using Leadtools.ImageProcessing.Effects;

namespace GrayScaleDemo
{
    public partial class LocalEqualizerDialog : Form
    {
        private static int _initialWidth;
        private static int _initialHeight;
        private static int _initialWidthExt;
        private static int _initialHeightExt;
        private static int _initialSmooth;
        private static HistogramEqualizeType _initialEqualizeType;

        public int nWidth;
        public int nHeight;
        public int nWidthExt;
        public int nHeightExt;
        public int nSmooth;
        public HistogramEqualizeType EqualizeType;

        private int _width;
        private int _height;
        
        public LocalEqualizerDialog(int width ,int height)
        {
            InitializeComponent();
            _width = width - 1;
            _height = height-1;
        }

        private void LocalEqualizerDialog_Load(object sender, EventArgs e)
        {
             LocalHistogramEqualizeCommand command = new LocalHistogramEqualizeCommand();
             _initialWidth = command.Width;
            _initialHeight = command.Height;
            _initialWidthExt = command.WidthExtension;
            _initialHeightExt = command.HeightExtension;
            _initialSmooth = command.Smooth;
            _initialEqualizeType = command.Type;


            nWidth = _initialWidth;
            nHeight = _initialHeight;
            nWidthExt = _initialWidthExt;
            nHeightExt = _initialHeightExt;
            nSmooth = _initialSmooth;
            EqualizeType = _initialEqualizeType;

            _numWidth.Value = nWidth;
            _numHeight.Value = nHeight;
            _numWidthExt.Value = nWidthExt;
            _numHeightExt.Value = nHeightExt;
            _numSmooth.Value = nSmooth;

            _numWidth.Maximum = _width;
            _numWidth.Minimum = 1;
            _numWidthExt.Maximum = _width;
            _numWidthExt.Minimum = 0;

            _numHeight.Maximum = _height;
            _numHeight.Minimum = 1;
            _numHeightExt.Maximum = _height;
            _numHeightExt.Minimum = 0;

            _numWidth.Value = _width;
            _numHeight.Value = _height;

            Tools.FillComboBoxWithEnum(_cbEqualizeType, typeof(HistogramEqualizeType), EqualizeType, new object[] { UnsharpMaskCommandColorType.None });
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            nWidth = (int)_numWidth.Value;
            nHeight = (int)_numHeight.Value;
            nWidthExt = (int)_numWidthExt.Value;
            nHeightExt = (int)_numHeightExt.Value;
            nSmooth = (int)_numSmooth.Value;
            EqualizeType = (HistogramEqualizeType)Constants.GetValueFromName(
               typeof(HistogramEqualizeType),
               (string)_cbEqualizeType.SelectedItem,
               _initialEqualizeType);

            _numWidth.Value = nWidth;
            _numHeight.Value = nHeight;
            _numWidthExt.Value = nWidthExt;
            _numHeightExt.Value = nHeightExt;
            _numSmooth.Value = nSmooth;
            _initialEqualizeType = EqualizeType;
        }
    }
}
