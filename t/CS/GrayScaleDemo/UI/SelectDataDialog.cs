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
using Leadtools;
using Leadtools.Demos;

namespace GrayScaleDemo
{
    public partial class SelectDataDialog : Form
    {
        private static Color _color ; 
        private static bool _combine ;
        private static int _sourceLowBit ;
        private static int _sourceHighBit ;
        private static int _threshold ;

        public Color dlgColor;
        public bool Combine;
        public int SourceLowBit;
        public int SourceHighBit;
        public int Threshold;

        public SelectDataDialog()
        {
            InitializeComponent();
        }

        private void SelectDataDialog_Load(object sender, EventArgs e)
        {

          SelectDataCommand cmd = new SelectDataCommand();
          _pnlColor.BackColor =_color = Converters.ToGdiPlusColor(cmd.Color);
          _combine = cmd.Combine;
          _sourceLowBit = cmd.SourceLowBit;
          _sourceHighBit = cmd.SourceHighBit;
          _threshold = cmd.Threshold;


            dlgColor = _color;
            Combine = _combine;
            SourceHighBit = _sourceHighBit;
            SourceLowBit = _sourceLowBit;
            Threshold = _threshold;

            _numSourceHighBit.Value = SourceHighBit;
            _numSourceLowBit.Value = SourceLowBit;
            _numThreshold.Value = Threshold;
            _cbCombine.Checked = Combine;
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            Combine = _cbCombine.Checked;
            SourceHighBit = (int)_numSourceHighBit.Value;
            SourceLowBit = (int)_numSourceHighBit.Value;
            Threshold = (int)_numThreshold.Value;
            dlgColor = _color; 

            _combine = Combine;
            _sourceHighBit = SourceHighBit;
            _sourceLowBit = SourceLowBit;
            _threshold = Threshold;
        }

        private void _btnColor_Click(object sender, EventArgs e)
        {
           ColorDialog colorDlg = new ColorDialog();
           if (colorDlg.ShowDialog() == DialogResult.OK)
           {
              _color = _pnlColor.BackColor = colorDlg.Color;
             
           }
        }
    }
}
