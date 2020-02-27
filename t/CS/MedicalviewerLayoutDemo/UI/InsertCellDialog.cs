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
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools.WinForms.CommonDialogs.File;
using Leadtools.MedicalViewer;

namespace MedicalViewerLayoutDemo
{
    public partial class InsertCellDialog : Form
    {
        //private RasterCodecs _codecs;

        private MedicalViewerLayoutPosition _Position;

        public MedicalViewerLayoutPosition Position
        {
            get
            {
                return _Position;
            }
        }

        public InsertCellDialog(MainForm owner)
        {            
            InitializeComponent();                       
        }        

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void InsertCellDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
               _Position = new MedicalViewerLayoutPosition(Convert.ToSingle(ltx.Value),
                               Convert.ToSingle(lty.Value),Convert.ToSingle(rbx.Value),
                               Convert.ToSingle(rby.Value));
            }
        }

        private void InsertCellDialog_Load(object sender, EventArgs e)
        {
            
        }

        private void InsertCellDialog_Shown(object sender, EventArgs e)
        {
            ltx.Focus();
        }
    }
}
