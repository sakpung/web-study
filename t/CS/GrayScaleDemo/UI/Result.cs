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
    public partial class Result : Form
    {
        private string _result;
        public Result(string result)
        {
            InitializeComponent();
            _result = result;
        }

        private void Result_Load(object sender, EventArgs e)
        {
            _lblResult.Text = _result;
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
