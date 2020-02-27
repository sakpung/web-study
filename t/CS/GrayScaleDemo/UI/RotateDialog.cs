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
using Leadtools;
using Leadtools.ImageProcessing;

namespace GrayScaleDemo
{
    public partial class RotateDialog : Form
    {
        private static int _initialAngle = 0;
        private static RotateCommandFlags _initialFlags = RotateCommandFlags.None;
        private static int _initialFillColorLevel ;
        private bool _isGray;

        public Color FillColor;
        public int Angle;
        public RotateCommandFlags Flags;
        public int FillColorLevel;

        public RotateDialog(bool isGray)
        {
            InitializeComponent();
            _isGray = isGray;
        }

        private void RotateDialog_Load(object sender, EventArgs e)
        {
          RotateCommand cmd = new RotateCommand();
          _initialAngle = cmd.Angle;
          _initialFlags = cmd.Flags;
          _initialFillColorLevel = 0;

            Angle = _initialAngle / 100;
            Flags = _initialFlags;
            FillColorLevel = _initialFillColorLevel;
            _pnlRevColor.BackColor = FillColor = Converters.ToGdiPlusColor(cmd.FillColor);

            _numAngle.Value = Angle;
            _cbResize.Checked = (Flags & RotateCommandFlags.Resize) == RotateCommandFlags.Resize;
            _numFillColorLevel.Value = FillColorLevel;

            if ((Flags & RotateCommandFlags.Resample) == RotateCommandFlags.Resample)
                _rbButtonResample.Checked = true;
            else if ((Flags & RotateCommandFlags.Bicubic) == RotateCommandFlags.Bicubic)
                _rbButtonBicubic.Checked = true;
            else
                _rbButtonNormal.Checked = true;

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
            Angle = (int)_numAngle.Value * 100;

            Flags = RotateCommandFlags.None;

            FillColorLevel = (int)_numFillColorLevel.Value;

            if (_cbResize.Checked)
                Flags |= RotateCommandFlags.Resize;

            if (_rbButtonResample.Checked)
                Flags |= RotateCommandFlags.Resample;

            if (_rbButtonBicubic.Checked)
                Flags |= RotateCommandFlags.Bicubic;

            _initialAngle = Angle;
            _initialFlags = Flags;
            _initialFillColorLevel = FillColorLevel;

        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _btnDlgColor_Click(object sender, EventArgs e)
        {
           ColorDialog colorDlg = new ColorDialog();
           if (colorDlg.ShowDialog() == DialogResult.OK)
           {
              _pnlRevColor.BackColor = FillColor = colorDlg.Color;
           }
        }
    }
}
