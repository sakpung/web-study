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
using Leadtools.MedicalViewer;
using Leadtools.ImageProcessing.Core;

namespace MedicalViewerDemo
{
    public partial class ImageAlignmentDialog : Form
    {
        private MainForm _form;
        public RegistrationOptions Options;
        public RegistrationOptions OldOptions;

        public ImageAlignmentDialog(MainForm form)
        {
            _form = form;
            InitializeComponent();
        }

        private void _btnApply_Click(object sender, EventArgs e)
        {
            _form.ApplyAlignment();
        }

        private void _btnReset_Click(object sender, EventArgs e)
        {
            _form.ResetAlignment();
            EnableApplyButton(false);
        }

        private void _bntCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ImageAlignmentDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            _form.FinishAlignment();
        }

        private void ImageAlignmentDialog_Load(object sender, EventArgs e)
        {
            _cbTransformation.SelectedIndex = 0;
        }

        private void _cbTransformation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int type = _cbTransformation.SelectedIndex;

            switch (type)
            {
                case 0:
                    Options = RegistrationOptions.Unknown;
                    break;
                case 1:
                    Options = RegistrationOptions.XY;
                    break;
                case 2:
                    Options = RegistrationOptions.RSXY;
                    break;
                case 3:
                    Options = RegistrationOptions.Affine6;
                    break;
                case 4:
                    Options = RegistrationOptions.Perspective;
                    break;
            }

            //if (_form.TemplateList.Count >= 1 && OldOptions != Options)
            //    EnableApplyButton(true);
            //else
            //    EnableApplyButton(false);
        }

        public void EnableApplyButton(bool Enable)
        {
            this._btnApply.Enabled = Enable;
        }

    }
}
