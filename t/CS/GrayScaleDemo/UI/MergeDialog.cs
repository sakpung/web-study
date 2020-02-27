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

using Leadtools;
using Leadtools.Demos;
using Leadtools.ImageProcessing.Color;

namespace GrayScaleDemo
{
    public partial class MergeDialog : Form
    {
        private List<ViewerImages> _images;
        private ColorMergeCommandType _mergeType;
        private RasterImage _mergeImage;
        private int _maxImgNum;
        private int _checkedImgsCount;

        public RasterImage MergeImage
        {
            get { return _mergeImage; }
            set { _mergeImage = value; }
        }

        public ColorMergeCommandType MergeType
        {
            get { return _mergeType; }
            set { _mergeType = value; }
        }

        public MergeDialog(List<ViewerImages> images)
        {
            InitializeComponent();
            _images = images;
        }

        private void MergeDialog_Load(object sender, EventArgs e)
        {
            foreach (ViewerImages tmpImg in _images)
                _cLbImages.Items.Add(tmpImg.ImageName);

            _rbRGB.Checked = true;
            
        }

        private void _rb_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbCMY.Checked == true)
                _mergeType = ColorMergeCommandType.Cmy;
            else if (_rbCMYK.Checked == true)
                _mergeType = ColorMergeCommandType.Cmyk;
            else if (_rbHLS.Checked == true)
                _mergeType = ColorMergeCommandType.Hls;
            else if (_rbHSV.Checked == true)
                _mergeType = ColorMergeCommandType.Hsv;
            else if (_rbLAB.Checked == true)
                _mergeType = ColorMergeCommandType.Lab;
            else if (_rbRGB.Checked == true)
                _mergeType = ColorMergeCommandType.Rgb;
            else if (_rbSCT.Checked == true)
                _mergeType = ColorMergeCommandType.Sct;
            else if (_rbXYZ.Checked == true)
                _mergeType = ColorMergeCommandType.Xyz;
            else if (_rbYCRCB.Checked == true)
                _mergeType = ColorMergeCommandType.YcrCb;
            else if (_rbYUV.Checked == true)
                _mergeType = ColorMergeCommandType.Yuv;

            if (_mergeType == ColorMergeCommandType.Cmyk)
                _maxImgNum = 4;
            else
                _maxImgNum = 3;
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            _checkedImgsCount = 0;
            for (int i = 0; i < _cLbImages.Items.Count; i++)
                if (_cLbImages.GetItemChecked(i))
                    _checkedImgsCount++;
            
            if (_maxImgNum != _checkedImgsCount)
            {
                Messager.ShowWarning(this, string.Format("For this Merg type you must select {0} images exactly",_maxImgNum));
                DialogResult = DialogResult.None;
                return; ;
            }

            if(_mergeImage != null)
                _mergeImage.Dispose();
            for (int i = 0; i < _cLbImages.Items.Count; i++)
                if (_cLbImages.GetItemChecked(i))
                {
                    if (_mergeImage == null)
                    {
                        _mergeImage = _images[i].Image.Clone();
                    }
                    else
                        _mergeImage.AddPages(new RasterImage(_images[i].Image), 1, 1);
                }

            DialogResult = DialogResult.OK;
        }

        private void _cLbImages_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
