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
    public partial class ContourDialog : Form
    {
        private static int _initialThreshold;
        private static int _initialDeltaDirection;
        private static int _initialMaximumError;
        private static ContourFilterCommandType _initialType = ContourFilterCommandType.Thin;

        public int Threshold;
        public int DeltaDirection;
        public int MaximumError;
        public ContourFilterCommandType Type;

        public ContourDialog()
        {
            InitializeComponent();
        }

        private void ContourDialog_Load(object sender, EventArgs e)
        {
             ContourFilterCommand command = new ContourFilterCommand();
             _initialThreshold = command.Threshold;
             _initialDeltaDirection = command.DeltaDirection;
             _initialMaximumError = command.MaximumError;
             _initialType = command.Type;

            Threshold = _initialThreshold;
            DeltaDirection = _initialDeltaDirection;
            MaximumError = _initialMaximumError;
            Type = _initialType;

            _numThreshold.Value = Threshold;
            _numDeltaDirection.Value = DeltaDirection;
            _numMaximumError.Value = MaximumError;
            Tools.FillComboBoxWithEnum(_cmbType, typeof(ContourFilterCommandType), Type);

            UpdateControls();
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            Threshold = (int)_numThreshold.Value;
            DeltaDirection = (int)_numDeltaDirection.Value;
            MaximumError = (int)_numMaximumError.Value;
            Type = (ContourFilterCommandType)Constants.GetValueFromName(
               typeof(ContourFilterCommandType),
               (string)_cmbType.SelectedItem,
               _initialType);

            _initialThreshold = Threshold;
            _initialDeltaDirection = DeltaDirection;
            _initialMaximumError = MaximumError;
            _initialType = Type;
        }

        private void UpdateControls()
        {
            Type = (ContourFilterCommandType)Constants.GetValueFromName(
               typeof(ContourFilterCommandType),
               (string)_cmbType.SelectedItem,
               _initialType);
            _lblMaximumError.Enabled = Type == ContourFilterCommandType.ApproxColor;
            _numMaximumError.Enabled = Type == ContourFilterCommandType.ApproxColor;
        }

        private void _cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lblMaximumError.Enabled = _numMaximumError.Enabled = _cmbType.Text == "Approx Color";
        }

    }
}
