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

namespace GrayScaleDemo
{
    public partial class EdgeDetectorDialog : Form
    {
        private static int _initialThreshold = 255;
        private static EdgeDetectorCommandType _initialFilter = EdgeDetectorCommandType.SobelVertical;
        private int _max,_min;

        public int Threshold;
        public EdgeDetectorCommandType Filter;

        public EdgeDetectorDialog(int min,int max,bool isGray)
        {
            InitializeComponent();

            if (isGray)
            {
               _max = max;
               _min = min;
            }
            else
            {
               _max = 255;
               _min = 0;
            }
        }

        private void EdgeDetectorDialog_Load(object sender, EventArgs e)
        {
             EdgeDetectorCommand command = new EdgeDetectorCommand();
             _initialThreshold = command.Threshold;
             _initialFilter = command.Filter;


            Threshold = _initialThreshold;
            Filter = _initialFilter;

            Tools.FillComboBoxWithEnum(_cbFilter, typeof(EdgeDetectorCommandType), Filter);

            _numThreshold.Maximum = _max;
            _numThreshold.Minimum = _min;
            DialogUtilities.SetNumericValue(_numThreshold, Threshold);
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            Threshold = (int)_numThreshold.Value;

            Filter = (EdgeDetectorCommandType)Constants.GetValueFromName(
               typeof(EdgeDetectorCommandType),
               (string)_cbFilter.SelectedItem,
               _initialFilter);

            _initialThreshold = Threshold;
            _initialFilter = Filter;
        }
    }
}
