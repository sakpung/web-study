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

using Leadtools.ImageProcessing;

using Leadtools;

namespace GrayScaleDemo
{
    public partial class CombineImageDialog : Form
    {

        private static int _imageID;
        private static CombineFastCommandFlags _flag;
        private RasterImage _destImg;
        private RasterImage _maskImg;

        public LeadPoint SourcePoint
        {
            get { return new LeadPoint((int)_numMaskX.Value, (int)_numMaskY.Value); }
        }

        public LeadRect DestRect
        {
            get { return new LeadRect((int)_numDestX.Value, (int)_numDestY.Value, (int)_numWidth.Value, (int)_numHeight.Value); }
        }

        public CombineFastCommandFlags Flag
        {
            get { return CombineImageDialog._flag; }
            set { CombineImageDialog._flag = value; }
        }

        public  int ImageID
        {
            get { return CombineImageDialog._imageID; }
        }
        List<ViewerImages> _paths;

        public CombineImageDialog(List<ViewerImages> paths, RasterImage image)
        {
            InitializeComponent();
            _paths = new List<ViewerImages>();
            _destImg = image;

            foreach (ViewerImages tmp in paths)
            {
                try
                {
                    if (tmp.Image.BitsPerPixel == _destImg.BitsPerPixel)
                        _paths.Add(tmp);
                }
                catch (Exception /*ex*/)
                {
                }
            }

            _numDestX.Maximum = _destImg.Width;
            _numDestY.Maximum = _destImg.Height;
        }

        private void CombineImageDialog_Load(object sender, EventArgs e)
        {
            foreach (ViewerImages path in _paths)
                _cmbMaskImage.Items.Add(path.ImageName);
            _cmbMaskImage.SelectedIndex = 0;
            _cmbCombiningOperation.SelectedIndex = 0;
            _numMaskX.Value = 0;
           _numWidth.Value = _destImg.Width;
           _numHeight.Value = _destImg.Height;
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            _imageID = _paths[_cmbMaskImage.SelectedIndex].ChildFormId;
            switch (_cmbCombiningOperation.SelectedIndex)
            {
                case 0:
                    _flag = CombineFastCommandFlags.OperationOr;
                    break;
                case 1:
                    _flag = CombineFastCommandFlags.OperationXor;
                    break;
                case 2:
                    _flag = CombineFastCommandFlags.OperationAdd;
                    break;
                case 3:
                    _flag = CombineFastCommandFlags.OperationSubtractSource;
                    break;
                case 4:
                    _flag = CombineFastCommandFlags.OperationSubtractDestination;
                    break;
                case 5:
                    _flag = CombineFastCommandFlags.OperationMultiply;
                    break;
                case 6:
                    _flag = CombineFastCommandFlags.OperationDivideSource;
                    break;
                case 7:
                    _flag = CombineFastCommandFlags.OperationDivideDestination;
                    break;
                case 8:
                    _flag = CombineFastCommandFlags.OperationAverage;
                    break;
                case 9:
                    _flag = CombineFastCommandFlags.OperationMinimum;
                    break;
                case 10:
                    _flag = CombineFastCommandFlags.OperationMaximum;
                    break;
            }
        }

        private void _num_ValueChanged(object sender, EventArgs e)
        {
            int xMask = (int)(_maskImg.Width - _numMaskX.Value);
            int xDest = (int) (_destImg.Width - _numDestX.Value);
            int yMask = (int) (_maskImg.Height - _numMaskY.Value);
            int yDest = (int) (_destImg.Height - _numDestY.Value);

            _numHeight.Maximum = Math.Max(yMask,yDest);
            _numWidth.Maximum = Math.Max(xMask, xDest);

        }

        private void _cmbMaskImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            _maskImg = _paths[_cmbMaskImage.SelectedIndex].Image;
            _numMaskX.Maximum = _maskImg.Width;
            _numMaskY.Maximum = _maskImg.Height;
        }
    }
}
