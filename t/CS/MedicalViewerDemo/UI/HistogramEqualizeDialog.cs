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
    public partial class HistogramEqualizeDialog : Form
    {
        private MedicalViewerMultiCell _cell;
        private RasterImage _originalBitmap;
        private bool _firstTime;
        private RasterRegion _region;
        private int _oldWindowWidth;
        private int _oldWindowCenter;
        private MainForm _mainForm;


        public HistogramEqualizeDialog(MedicalViewerMultiCell cell, MainForm mainForm)
        {
            _cell = cell;
            _mainForm = mainForm;
            InitializeComponent();
            _cbColorSpace.SelectedIndex = 0;
            _firstTime = true;
            _oldWindowWidth  = _cell.GetWindowLevelWidth();
            _oldWindowCenter = _cell.GetWindowLevelCenter();
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
           _mainForm.FilterCancel_Click(_firstTime, _originalBitmap, false);

           _cell.SetWindowLevel(_oldWindowWidth, _oldWindowCenter);
           _cell.Invalidate();
        }

        private void ApplyFilter()
        {
            int orignalPage = _cell.Image.Page;
            _cell.Image.Page = _cell.ActiveSubCell + 1;
            _region = _cell.Image.GetRegion(null);
            _cell.RemoveRegion();
            HistogramEqualizeType type = HistogramEqualizeType.None;
            switch (_cbColorSpace.SelectedIndex)
            {
                case 0:
                    type = HistogramEqualizeType.Rgb;
                    break;
                case 1:
                    type = HistogramEqualizeType.Yuv;
                    break;
                case 2:
                    type = HistogramEqualizeType.Gray;
                    break;
            }

            HistogramEqualizeCommand command = new HistogramEqualizeCommand(type);

            _mainForm.FilterRunCommand(command, false, true);


            _cell.Image.SetRegion(null, _region, RasterRegionCombineMode.Set);
            if(_cell.Image.BitsPerPixel == 8)
                _cell.SetWindowLevel(_cell.ActiveSubCell, 255, 128);
            else if(_cell.Image.BitsPerPixel == 16)
                _cell.SetWindowLevel(_cell.ActiveSubCell, 65000, 32000);

            _cell.Image.Page = orignalPage;
            _cell.Invalidate();

        }

        private void HistogramEqualizeDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
           if (_originalBitmap != null)
              _originalBitmap.Dispose();
        }

    }
}
