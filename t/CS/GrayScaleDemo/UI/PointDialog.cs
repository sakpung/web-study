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

namespace GrayScaleDemo
{
    public partial class SetPixelColorDialog : Form
    {
        private int _ptX;
        private int _ptY;
        private int _level;
        private int _maxX;
        private int _maxY;
        private int _minValue;
        private int _maxValue;
        private int _maxLevel;
        ImageCategory _imgCat;
        private byte _r, _g, _b;

        public byte B
        {
            get { return _b; }
        }

        public byte G
        {
            get { return _g; }
        }

        public byte R
        {
            get { return _r; }
        }


        public int MaxLevel
        {
            get { return _maxLevel; }
            set { _maxLevel = value; }
        }

        public int MaxY
        {
            set { _maxY = value; }
        }

        public int MaxX
        {
            set { _maxX = value; }
        }

        public int Level
        {
            get { return _level; }
        } 
        
        public int PtX
        {
            get { return _ptX; }
        }

        public int PtY
        {
            get { return _ptY; }
        }

        public SetPixelColorDialog(ImageCategory cat, int bpp)
        {
            InitializeComponent();
            _imgCat = cat;
            _maxValue = (int)Math.Pow(2, bpp) -1; 
            _minValue = 0;
        }
 

        private void PointDialog_Load(object sender, EventArgs e)
        {
            if (_imgCat == ImageCategory.GrayScale_8_12_16_BPP)
            {
                _gbGray .Visible = true;
                _gbRGB .Visible = false;
                _numLevel.Maximum = _maxValue;
                _numLevel.Minimum = _minValue;
            }
            else if (_imgCat == ImageCategory.ColoredImage)
            {
                _gbGray.Visible = false;
                _gbRGB.Visible = true;
            }
            _numX.Maximum = _maxX;
            _numY.Maximum = _maxY;
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            if (_imgCat == ImageCategory.GrayScale_8_12_16_BPP)
            {
                _level = (int)_numLevel.Value;
            }
            else if (_imgCat == ImageCategory.ColoredImage)
            {
                _r = (byte)_numR.Value;
                _g = (byte)_numG.Value;
                _b = (byte)_numB.Value;
            }

            _ptX = (int)_numX.Value;
            _ptY = (int)_numY.Value;
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
