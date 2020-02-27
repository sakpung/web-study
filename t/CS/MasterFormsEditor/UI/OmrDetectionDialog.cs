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

namespace CSMasterFormsEditor.UI
{
    public partial class OmrDetectionDialog : Form
    {
        private MainForm _mainForm;
        private DiskMasterForm _masterForm;
        private OcrOmrSensitivity _sensitivity = OcrOmrSensitivity.High;
        private int _selectedPageNumber;

        public OmrDetectionDialog(MainForm mainForm, DiskMasterForm masterForm, int selectedPageNumber)
        {
            if (selectedPageNumber == 0)
            {
                Messager.ShowWarning(this, new ArgumentOutOfRangeException("selectedPageNumber"));
                Close();
            }

            InitializeComponent();
                        
            _mainForm = mainForm;
            _masterForm = masterForm;
            _selectedPageNumber = selectedPageNumber;
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            List<OmrFormField> fields = _masterForm.AutoDetectOmrFields(_sensitivity, _selectedPageNumber);
            if (fields != null)
                _mainForm.FillDetectedOmrFields(fields);

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
