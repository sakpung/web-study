// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DicomDemo
{
    public partial class Page7 : UserControl
    {
        public Page7()
        {
            InitializeComponent();
        }

        private void linkLabels_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = ((LinkLabel)sender).Text;
            proc.Start();
        }
    }
}
