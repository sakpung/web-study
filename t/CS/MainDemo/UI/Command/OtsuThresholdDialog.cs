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
    public partial class OtsuThresholdDialog : Form
    {
        public int Clusters;

        public OtsuThresholdDialog()
        {
            InitializeComponent();
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            Clusters = (int) _numClusters.Value;
        }
    }
}
