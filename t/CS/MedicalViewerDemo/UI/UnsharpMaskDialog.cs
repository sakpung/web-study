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

using Leadtools.Demos;
using Leadtools.ImageProcessing.Effects;
using Leadtools.MedicalViewer;
using Leadtools;

namespace MedicalViewerDemo
{
    public partial class UnsharpMaskDialog : Form
    {
        private RasterImage _originalBitmap;
        private bool _firstTime;
        private MainForm _mainForm;

        public UnsharpMaskDialog(MainForm mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
            _cbColorSpace.SelectedIndex = 0;
            _firstTime = true;
        }


        private void _num_Leave(object sender, System.EventArgs e)
        {
            DialogUtilities.NumericOnLeave(sender);
        }

        private void _btnOk_Click(object sender, System.EventArgs e)
        {
           _mainForm.FilterOk_Click(_originalBitmap, _firstTime, ApplyFilter);
        }

        private void _btnApply_Click(object sender, EventArgs e)
        {
           _mainForm.FilterApply_Click(ref _firstTime, ref _originalBitmap, ApplyFilter); 
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
           _mainForm.FilterCancel_Click(_firstTime, _originalBitmap, true);
        }

        private void ApplyFilter()
        {
            UnsharpMaskCommandColorType type = UnsharpMaskCommandColorType.None;

            switch (_cbColorSpace.SelectedIndex)
            {
                case 0:
                    type = UnsharpMaskCommandColorType.Rgb;
                    break;
                case 1:
                    type = UnsharpMaskCommandColorType.Yuv;
                    break;
            }

            UnsharpMaskCommand command = new UnsharpMaskCommand(Convert.ToInt32(_numAmount.Value), Convert.ToInt32(_numRadius.Value), Convert.ToInt32(_numThreshold.Value), type);
            _mainForm.FilterRunCommand(command, true, false);
        }

        private void UnsharpMaskDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
           if (_originalBitmap != null)
              _originalBitmap.Dispose();
        }

    }
}
