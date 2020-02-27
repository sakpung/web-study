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
using Leadtools.Forms.Auto;
using Leadtools.Forms.Processing;
using Leadtools.Ocr;
using Leadtools.Demos;
using Leadtools.Annotations.Engine;

namespace CSMasterFormsEditor.UI
{
    public partial class OmrSensitivityDialog : Form
    {
        private MainForm _mainForm;
        private OcrOmrSensitivity _sensitivity = OcrOmrSensitivity.High;
        private AnnObjectCollection _omrFields;

        public OmrSensitivityDialog(MainForm mainForm, AnnObjectCollection omrFields)
        {
            InitializeComponent();
                        
            _mainForm = mainForm;
            _omrFields = omrFields;
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            _mainForm.ApplySetOmrSensitivity(_sensitivity);            
            this.Close();
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _omrSensitivtyChecked(object sender, EventArgs e)
        {
            RadioButton rb = (sender as RadioButton);
            _sensitivity = (OcrOmrSensitivity) Enum.Parse(typeof(OcrOmrSensitivity), rb.Text, false);
        }
    }
}
