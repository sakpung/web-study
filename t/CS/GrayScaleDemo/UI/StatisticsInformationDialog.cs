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

using Leadtools.ImageProcessing.Effects;
using Leadtools;
using Leadtools.Demos;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Core;

namespace GrayScaleDemo
{
    public partial class ImageInformationDialog : Form
    {
        private RasterImage _image;

        public ImageInformationDialog(RasterImage image)
        {
            InitializeComponent();
            _image = image;
        }

        private void StatisticsInformationDialog_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < _lvInfo.Items.Count; i++)
                _lvInfo.Items[i].SubItems.Add(string.Empty);

            UpdateControls();
        }

        private void _btnPageLast_Click(object sender, EventArgs e)
        {
            _image.Page = _image.PageCount;
            UpdateControls();
        }

        private void _btnPageFirst_Click(object sender, EventArgs e)
        {
            _image.Page = 1;
            UpdateControls();
        }

        private void _btnPageNext_Click(object sender, EventArgs e)
        {
            _image.Page++;
            UpdateControls();
        }

        private void _btnPagePrevious_Click(object sender, EventArgs e)
        {
            _image.Page--;
            UpdateControls();
        }

        void UpdateControls()
        {
            try
            {
                _lblPage.Text = string.Format("Page {0}:{1}", _image.Page, _image.PageCount);
                _btnPageFirst.Enabled = _image.Page > 1;
                _btnPagePrevious.Enabled = _image.Page > 1;
                _btnPageNext.Enabled = _image.Page < _image.PageCount;
                _btnPageLast.Enabled = _image.Page < _image.PageCount;

                int index = 0;
                _lvInfo.Items[index++].SubItems[1].Text = _image.OriginalFormat.ToString();
                _lvInfo.Items[index++].SubItems[1].Text = string.Format("{0} x {1} pixels", _image.Width, _image.Height);
                _lvInfo.Items[index++].SubItems[1].Text = string.Format("{0} x {1} dpi", _image.XResolution, _image.YResolution);
                _lvInfo.Items[index++].SubItems[1].Text = _image.BitsPerPixel.ToString();
                _lvInfo.Items[index++].SubItems[1].Text = _image.BytesPerLine.ToString();
                _lvInfo.Items[index++].SubItems[1].Text = _image.DataSize.ToString();
                _lvInfo.Items[index++].SubItems[1].Text = Constants.GetNameFromValue(typeof(RasterViewPerspective), _image.ViewPerspective);
                _lvInfo.Items[index++].SubItems[1].Text = Constants.GetNameFromValue(typeof(RasterByteOrder), _image.Order);
                _lvInfo.Items[index++].SubItems[1].Text = _image.HasRegion ? "Yes" : "No";
                if (_image.IsCompressed)
                    _lvInfo.Items[index++].SubItems[1].Text = "Run Length Limited (RLE)";
                else
                    _lvInfo.Items[index++].SubItems[1].Text = "Not compressed";

                if (_image.IsDiskMemory)
                    _lvInfo.Items[index++].SubItems[1].Text = "Disk";
                else if (_image.IsTiled)
                    _lvInfo.Items[index++].SubItems[1].Text = "Tiled";
                else if (_image.IsConventionalMemory)
                    _lvInfo.Items[index++].SubItems[1].Text = "Managed memory";
                else
                    _lvInfo.Items[index++].SubItems[1].Text = "Unmanaged memory";

                _lvInfo.Items[index++].SubItems[1].Text = _image.Signed ? "Yes" : "No";
                _lvInfo.Items[index++].SubItems[1].Text = Constants.GetNameFromValue(typeof(RasterGrayscaleMode), _image.GrayscaleMode);

                _lvInfo.Items[index++].SubItems[1].Text = _image.LowBit.ToString();
                _lvInfo.Items[index++].SubItems[1].Text = _image.HighBit.ToString();


                bool useLookup = _image.UseLookupTable;
                _image.UseLookupTable = false;

                int MinValue = 0 ;
                int MaxClrVal ;

                if (_image.UseLookupTable == true)
                {
                    MinValue = 0;
                    MaxClrVal = 255 ;
                }
                else
                {
                    int HighBit = (_image.HighBit > 0) ? _image.HighBit : (_image.BitsPerPixel-1) ;
                    int LowBit = (_image.LowBit < 0) ? 0 : _image.LowBit ;
                    if (_image.Order == RasterByteOrder.Gray || _image.BitsPerPixel >= 48)
                    {
                        if (_image.BitsPerPixel == 16 || _image.BitsPerPixel == 12)
                        {
                            MaxClrVal = (1 << ((HighBit - LowBit) + 1)) - 1;
                        }
                        else
                        {
                            MaxClrVal = 0xffff;
                        }

                    }
                    else
                    {
                        MaxClrVal = 0xff ;
                    }
                }
                
                StatisticsInformationCommand command = new StatisticsInformationCommand();

                command.Channel = RasterColorChannel.Master;
                command.Start = MinValue;
                command.End = MaxClrVal;
                command.Run(_image) ;
                _image.UseLookupTable = useLookup;

                _lvInfo.Items[index++].SubItems[1].Text = Math.Round(command.Mean, 2).ToString();
                _lvInfo.Items[index++].SubItems[1].Text = Math.Round(command.StandardDeviation, 2).ToString();
                _lvInfo.Items[index++].SubItems[1].Text = command.Median.ToString();

                if ((_image.BitsPerPixel == 8 || _image.BitsPerPixel == 12 || _image.BitsPerPixel == 16) && _image.GrayscaleMode != RasterGrayscaleMode.None)
                {
                    MinMaxValuesCommand cmd = new MinMaxValuesCommand();
                    cmd.Run(_image);
                    _lvInfo.Items[index++].SubItems[1].Text = cmd.MinimumValue.ToString();
                    _lvInfo.Items[index++].SubItems[1].Text = cmd.MaximumValue.ToString();
                }
                else
                {
                    _lvInfo.Items[index++].SubItems[1].Text = _image.MinValue.ToString();
                    _lvInfo.Items[index++].SubItems[1].Text = _image.MaxValue.ToString();
                }

                _lvInfo.Items[index++].SubItems[1].Text = command.PixelCount.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void _btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
