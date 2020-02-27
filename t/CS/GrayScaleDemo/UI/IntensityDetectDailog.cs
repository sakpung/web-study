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
using Leadtools.ImageProcessing.Color;


namespace GrayScaleDemo
{
    public partial class IntensityDetectDailog : Form
    {
        private static int _initialLow;
        private static int _initialHigh;
        private int _OutColorLevel, _InColorLevel;
        private static IntensityDetectCommandFlags _initialChannel;
        private bool _isGray;

        public int Low;
        public int High;
        public IntensityDetectCommandFlags Channel;
        public RasterColor OutColor, InColor;

        public IntensityDetectDailog(bool isGray)
        {
            InitializeComponent();
            _isGray = isGray;
        }

        private struct ChannelType
        {
            public string Name;
            public IntensityDetectCommandFlags Flags;

            public ChannelType(string n, IntensityDetectCommandFlags f)
            {
                Name = n;
                Flags = f;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        private static readonly ChannelType[] _channels =
        {
         new ChannelType("Master", IntensityDetectCommandFlags.Master),
         new ChannelType("Red", IntensityDetectCommandFlags.Red),
         new ChannelType("Green", IntensityDetectCommandFlags.Green),
         new ChannelType("Blue", IntensityDetectCommandFlags.Blue),
         new ChannelType("Red and Green", IntensityDetectCommandFlags.Red | IntensityDetectCommandFlags.Green),
         new ChannelType("Red and Blue", IntensityDetectCommandFlags.Red | IntensityDetectCommandFlags.Blue),
         new ChannelType("Green and Blue", IntensityDetectCommandFlags.Green | IntensityDetectCommandFlags.Blue),
         new ChannelType("Red, Green and Blue", IntensityDetectCommandFlags.Red | IntensityDetectCommandFlags.Green | IntensityDetectCommandFlags.Blue)
         };

        private void IntensityDetectDailog_Load(object sender, EventArgs e)
        {
             IntensityDetectCommand command = new IntensityDetectCommand();
             _initialLow = command.LowThreshold;
             _initialHigh = command.HighThreshold;

             if (_initialLow >= _initialHigh)
                 _initialHigh = _initialLow + 1;

             _InColorLevel =0;
             _OutColorLevel = 0;
             _initialChannel = command.Channel;

            Low = _initialLow;
            High = _initialHigh;
            Channel = _initialChannel;

            _numLow.Value = Low;
            _numHigh.Value = High;
            _numOutColorLevel.Value = 0;
            _numInColorLevel.Value = 0;
            _pnlInRevColor.BackColor = _pnlOutRevColor.BackColor = Color.Black;

            if (_isGray)
            {
               _pnlColor.Visible = false;
               _pnlLevel.Visible = true;
            }
            else
            {
               _pnlColor.Visible = true;
               _pnlLevel.Visible = false;
            }


            foreach (ChannelType i in _channels)
            {
                _cbChannel.Items.Add(i);
                if (i.Flags == Channel)
                    _cbChannel.SelectedItem = i;
            }

            if (_cbChannel.SelectedItem == null)
                _cbChannel.SelectedIndex = 0;
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            if (_numLow.Value >= _numHigh.Value)
            {
                Messager.ShowWarning(this, _lblMsg.Text);
                DialogResult = DialogResult.None;
                return;
            }

            Low = (int)_numLow.Value;
            High = (int)_numHigh.Value;
            _InColorLevel = (int)_numInColorLevel.Value;
            _OutColorLevel = (int)_numOutColorLevel.Value;

            ChannelType ct = (ChannelType)_cbChannel.SelectedItem;
            Channel = ct.Flags;

            _initialLow = Low;
            _initialHigh = High;
            _initialChannel = 0;

            if (_isGray)
            {
               OutColor = new RasterColor(_OutColorLevel, _OutColorLevel, _OutColorLevel);
               InColor = new RasterColor(_InColorLevel, _InColorLevel, _InColorLevel);
            }
        }

        private void _btnColor_Click(object sender, EventArgs e)
        {
           ColorDialog colorDlg = new ColorDialog();
           if (colorDlg.ShowDialog() == DialogResult.OK)
           {
              if (sender == _btnInColor)
              {
                 _pnlInRevColor.BackColor = colorDlg.Color;
                 InColor = Converters.FromGdiPlusColor(colorDlg.Color);
              }
              else if (sender == _btnOutColor)
              {
                 _pnlOutRevColor.BackColor = colorDlg.Color;
                 OutColor = Converters.FromGdiPlusColor(colorDlg.Color);
              }
           }
        }
    }
}
