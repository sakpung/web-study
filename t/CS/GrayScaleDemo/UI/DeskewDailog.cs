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

using Leadtools.ImageProcessing.Core;
using Leadtools.Demos;
using Leadtools;
using Leadtools.ImageProcessing.Effects;

namespace GrayScaleDemo
{
    public partial class DeskewDailog : Form
    {

        private static int _initialFillColorLevel;
        private static DeskewCommandFlags _initialFlags;
        private bool _isGray;

        public int FillColorLevel;
        public DeskewCommandFlags Flags;
        public RasterColor FillColor;

        public DeskewDailog(bool isGray)
        {
            InitializeComponent();
            _isGray = isGray;
        }

        private void DeskewDailog_Load(object sender, EventArgs e)
        {
             DeskewCommand command = new DeskewCommand();
             _initialFillColorLevel = 0;
             _initialFlags = command.Flags;

            FillColorLevel = _initialFillColorLevel;
            Flags = _initialFlags;

            _rbFill.Checked = (Flags & DeskewCommandFlags.FillExposedArea) == DeskewCommandFlags.FillExposedArea;
            _rbNoFill.Checked = (Flags & DeskewCommandFlags.DoNotFillExposedArea) == DeskewCommandFlags.DoNotFillExposedArea;
            _numFillColorLevel.Value = FillColorLevel;
            FillColor = RasterColor.Black;
            _pnlRevColor.BackColor = Color.Black;


            if (_isGray)
            {
               _pnlLevel.Visible = true;
               _pnlColor.Visible = false;
            }
            else
            {
               _pnlLevel.Visible = false;
               _pnlColor.Visible = true;
            }
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            Flags = DeskewCommandFlags.DeskewImage;
            FillColorLevel = (int)_numFillColorLevel.Value;

            if (_rbFill.Checked)
                Flags |= DeskewCommandFlags.FillExposedArea;
            else
                Flags |= DeskewCommandFlags.DoNotFillExposedArea;

            _initialFillColorLevel = FillColorLevel;
            _initialFlags = Flags;

            if (_isGray)
            {
               FillColor = new RasterColor(FillColorLevel, FillColorLevel, FillColorLevel);
            }
        }

        private void _btnRevColor_Click(object sender, EventArgs e)
        {
           ColorDialog colorDlg = new ColorDialog();
           if (colorDlg.ShowDialog() == DialogResult.OK)
           {
              _pnlRevColor.BackColor =  colorDlg.Color;
              FillColor = Converters.FromGdiPlusColor(colorDlg.Color); 
           }
        }

    }
}
