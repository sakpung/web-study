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
using Leadtools.ImageProcessing.Color;

using Leadtools.Demos;
using Leadtools.MedicalViewer;
using Leadtools;

namespace MedicalViewerDemo
{
    public partial class AdaptiveContrastDialog : Form
    {
        private bool _firstTime;
        private RasterImage _originalBitmap;
        private MainForm _mainForm;

        public AdaptiveContrastDialog(MainForm mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
            _cbType.SelectedIndex = 0;
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
            AdaptiveContrastCommandType type = AdaptiveContrastCommandType.Exponential;
            switch (_cbType.SelectedIndex)
            {
                case 0:
                    type = AdaptiveContrastCommandType.Exponential;
                    break;
                case 1:
                    type = AdaptiveContrastCommandType.Linear;
                    break;
            }
            AdaptiveContrastCommand command = new AdaptiveContrastCommand(Convert.ToInt32(_numSize.Value), Convert.ToInt32(_numAmount.Value), type);
            _mainForm.FilterRunCommand(command, true, false);
        }

        private void AdaptiveContrastDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
           if (_originalBitmap != null)
              _originalBitmap.Dispose();
        }
    }
}
