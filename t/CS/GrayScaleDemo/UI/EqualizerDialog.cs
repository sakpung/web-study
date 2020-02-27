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
using Leadtools.ImageProcessing.Color;

namespace GrayScaleDemo
{
    public partial class EqualizerDialog : Form
    {
        private static HistogramEqualizeType _initialColorSpace;
        public HistogramEqualizeType ColorSpace;

        public EqualizerDialog()
        {
            InitializeComponent();
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            ColorSpace = (HistogramEqualizeType)Constants.GetValueFromName(
                        typeof(HistogramEqualizeType),
                        (string)_cbColorSpace.SelectedItem,
                        _initialColorSpace);

            _initialColorSpace = ColorSpace;
        }

        private void EqualizerDialog_Load(object sender, EventArgs e)
        {
             HistogramEqualizeCommand command = new HistogramEqualizeCommand();
             _initialColorSpace = command.Type;

            ColorSpace = _initialColorSpace;
            Tools.FillComboBoxWithEnum(_cbColorSpace, typeof(HistogramEqualizeType), ColorSpace, new object[] { HistogramEqualizeType.None });
        }
    }
}
