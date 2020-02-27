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
    public partial class ShearDialog : Form
    {
        private static int _initialAngle;
        private static bool _initialHorizontal;
        private static int _initialFillColorLevel;
        private bool _isGray;

        public int Angle;
        public Color FillColor;
        public bool Horizontal;
        public int FillColorLevel;

        public ShearDialog(bool isGray)
        {
            InitializeComponent();
            _isGray = isGray;
        }

        private void ShearDialog_Load(object sender, EventArgs e)
        {
             ShearCommand command = new ShearCommand();
             _initialAngle = command.Angle;
             _initialHorizontal = command.Horizontal;
             _initialFillColorLevel = 0;

            Angle = _initialAngle / 100;
            Horizontal = _initialHorizontal;
            FillColorLevel = _initialFillColorLevel;
            FillColor = _pnlRevColor.BackColor = Color.Black;

            _numAngle.Value = Angle;
            _numFillColorLevel.Value = FillColorLevel;
           
            _rbHorizontal.Checked = Horizontal;
            _rbVertical.Checked = !Horizontal;

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
     

        private void _btnOk_Click(object sender, System.EventArgs e)
        {
            Angle = (int)_numAngle.Value * 100;
            Horizontal = _rbHorizontal.Checked;
            FillColorLevel = (int)_numFillColorLevel.Value;

            _initialAngle = Angle;
            _initialHorizontal = Horizontal;
            _initialFillColorLevel = FillColorLevel;
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
