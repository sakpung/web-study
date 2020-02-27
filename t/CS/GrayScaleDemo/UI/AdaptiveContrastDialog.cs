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
using Leadtools.ImageProcessing.Color;

namespace GrayScaleDemo
{
    public partial class AdaptiveContrastDialog : Form
    {
        private static int _amount ;
        private static int _dimension ;
        private static AdaptiveContrastCommandType _initialAdaptiveContrastType;

        public int Amount;
        public int Dimentions;
        public AdaptiveContrastCommandType AdaptiveContrastType;
        
        public AdaptiveContrastDialog()
        {
            InitializeComponent();
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            Amount = (int)_numAmount.Value;
            Dimentions = (int)_numDimension.Value;

            switch (_cmbAdaptiveType.SelectedIndex)
            {
                case 0:
                    AdaptiveContrastType = AdaptiveContrastCommandType.Exponential;
                    break;
                case 1:
                    AdaptiveContrastType = AdaptiveContrastCommandType.Linear;
                    break;
            }
            _amount = Amount;
            _dimension = Dimentions;
            _initialAdaptiveContrastType = AdaptiveContrastType;
        }

        private void AdaptiveContrastDialog_Load(object sender, EventArgs e)
        {
             AdaptiveContrastCommand command = new AdaptiveContrastCommand();
             _amount = command.Amount;
             _dimension = command.Dimension;
             _initialAdaptiveContrastType = command.Type;


            Amount = _amount;
            Dimentions = _dimension;
            AdaptiveContrastType = _initialAdaptiveContrastType;

            try
            {
                _numAmount.Value = Amount;
                _numDimension.Value = Dimentions;
                
                switch((int)AdaptiveContrastType)
                {
                    case 0x00000001:
                        _cmbAdaptiveType.SelectedIndex =0;
                        break;
                    case 0x00000002:
                        _cmbAdaptiveType.SelectedIndex =1;
                        break;
                }
                
            }
            catch (Exception /*ex*/)
            {

            }
        }
    }
}
