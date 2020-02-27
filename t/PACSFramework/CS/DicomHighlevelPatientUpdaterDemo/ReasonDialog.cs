// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DicomDemo
{
    public partial class ReasonDialog : Form
    {
        private string _Reason = string.Empty;

        public string Reason
        {
            get { return _Reason; }
            set { _Reason = value; }
        }

        public ReasonDialog(string title)
        {
            InitializeComponent();
            Text = title;
        }

        private void textBoxReason_TextChanged(object sender, EventArgs e)
        {
            OkButton.Enabled = textBoxReason.Text.Length > 0;
        }

        private void ReasonDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
                _Reason = textBoxReason.Text;
        }
    }
}
