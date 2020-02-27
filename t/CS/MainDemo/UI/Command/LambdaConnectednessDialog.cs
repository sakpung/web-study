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

namespace MainDemo
{
    public partial class LambdaConnectednessDialog : Form
    {
        public int Lambda;

        public LambdaConnectednessDialog()
        {
            InitializeComponent();
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            Lambda = (int)_numLambda.Value;
        }

        private void LambdaConnectednessDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
