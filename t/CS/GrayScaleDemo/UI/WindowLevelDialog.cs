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
    public partial class WindowLevelDialog : Form
    {
        private int _level;
        private int _width;

        public int WL_Width
        {
            get { return _width; }
            set { _width = value; }
        }
        
        public int WL_Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public WindowLevelDialog(int level, int width , int minWidth
            ,int maxWidth,int minLevel,int maxLevel)
        {
            InitializeComponent();
            _level = level;
            _width = width;
            _numLevel.Maximum = maxLevel;
            _numLevel.Minimum = minLevel;
            _numWidth.Maximum = maxWidth;
            _numWidth.Minimum = minWidth;
        }

        private void WindowLevelDialog_Load(object sender, EventArgs e)
        {
            _numWidth.Value = _width;
            _numLevel.Value = _level;
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            _width = (int)_numWidth.Value;
            _level = (int)_numLevel.Value;
        }
    }
}
