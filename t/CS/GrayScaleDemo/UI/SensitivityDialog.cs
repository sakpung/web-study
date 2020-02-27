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

namespace GrayScaleDemo
{
    public partial class SensitivityDialog : Form
    {
        private int _senValue;

        public int SenValue
        {
            get { return _senValue; }
            set { _senValue = value; }
        }

        public SensitivityDialog(int senValue)
        {
            InitializeComponent();

            _senValue = senValue;
        }

        private void SensitivityDialog_Load(object sender, EventArgs e)
        {
            _numValue.Value = _senValue;
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
             _senValue = (int) _numValue.Value;
        }



    }
}
