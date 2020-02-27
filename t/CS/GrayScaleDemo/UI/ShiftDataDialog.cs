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

namespace GrayScaleDemo
{
    public partial class ShiftDataDialog : Form
    {
        private static int _destinationBitsPerPixel ;
        private static int _destinationLowBit ;
        private static int _sourceLowBit ;
        private static int _sourceHighBit ;

        public int DestinationBitsPerPixel;
        public int DestinationLowBit;
        public int SourceLowBit;
        public int SourceHighBit;

        public ShiftDataDialog(int imageBpp,bool isSegned)
        {
            InitializeComponent();
            _numSourceHighBit.Maximum = imageBpp-1;
            _numSourceLowBit.Maximum = imageBpp - 1;

            if (!isSegned)
                _cmbDestBPP.Items.Add("8");
            _cmbDestBPP.Items.Add("12");
            _cmbDestBPP.Items.Add("16");
        }

        private void ShiftDataDialog_Load(object sender, EventArgs e)
        {
             ShiftDataCommand cmd = new ShiftDataCommand();
             _destinationBitsPerPixel = 8;
             _destinationLowBit = cmd.DestinationLowBit;
             _sourceLowBit = cmd.SourceLowBit;
             _sourceHighBit = cmd.SourceHighBit;

            DestinationBitsPerPixel = _destinationBitsPerPixel;
            DestinationLowBit = _destinationLowBit;
            SourceLowBit = _sourceLowBit;
            SourceHighBit = _sourceHighBit;

            try
            {
                _numDestLowBit.Value = DestinationLowBit;
                _numSourceHighBit.Value = SourceHighBit;
                _numSourceLowBit.Value = SourceLowBit;

                switch (DestinationBitsPerPixel)
                {
                    case 8:
                        _cmbDestBPP.SelectedIndex = 0;
                        break;
                    case 12:
                        _cmbDestBPP.SelectedIndex = 1;
                        break;
                    case 16:
                        _cmbDestBPP.SelectedIndex = 2;
                        break;
                }
            }
            catch(Exception /*ex*/)
            {
                _cmbDestBPP.SelectedIndex = 0;
                _numDestLowBit.Value = 0;
                _numSourceHighBit.Value = 7;
                _numSourceLowBit.Value = 0;
            }
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {

            if (_numSourceHighBit.Value <= _numSourceLowBit.Value)
            {
                Messager.ShowWarning(this, _lblMsg.Text);
                DialogResult = DialogResult.None;
                return;
            }

            DestinationBitsPerPixel = int.Parse(_cmbDestBPP.Text);
            DestinationLowBit = (int)_numDestLowBit.Value;
            SourceLowBit = (int)_numSourceLowBit.Value;
            SourceHighBit = (int)_numSourceHighBit.Value;

            _destinationBitsPerPixel = DestinationBitsPerPixel;
            _destinationLowBit = DestinationLowBit;
            _sourceLowBit = SourceLowBit;
            _sourceHighBit = SourceHighBit;
        }

        private void _cmbDestBPP_SelectedIndexChanged(object sender, EventArgs e)
        {
            _numDestLowBit.Maximum = int.Parse(_cmbDestBPP.Text) - 2;
        }

    }
}
