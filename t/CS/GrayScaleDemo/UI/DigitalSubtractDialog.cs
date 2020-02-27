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
using System.IO;

using Leadtools.ImageProcessing.Core;
using Leadtools;

namespace GrayScaleDemo
{
    public partial class DigitalSubtractDialog : Form
    {
        private static DigitalSubtractCommandFlags _flags;
        private static int _imageID;
        List<ViewerImages> _paths;

        public int ImageID
        {
            get { return DigitalSubtractDialog._imageID; }
        }

        public DigitalSubtractCommandFlags Flags
        {
            get { return DigitalSubtractDialog._flags; }
        }

        public DigitalSubtractDialog(List<ViewerImages> paths, RasterImage image)
        {
            InitializeComponent();
            _paths = new List<ViewerImages>();

            foreach (ViewerImages tmp in paths)
            {
                try
                {
                    if (tmp.Image.BitsPerPixel == image.BitsPerPixel && tmp.Image.Width == image.Width && tmp.Image.Height == image.Height
                        && tmp.Image.GrayscaleMode == image.GrayscaleMode)
                        _paths.Add(tmp);
                }
                catch (Exception /*ex*/)
                {
                }
            }
        }

        private void DigitalSubtractDialog_Load(object sender, EventArgs e)
        {
                DigitalSubtractCommand cmd = new DigitalSubtractCommand();
                _flags = cmd.Flags;


            foreach(ViewerImages path in _paths)
                _cmbMaskImage.Items.Add(path.ImageName);

            _cmbMaskImage.SelectedIndex = 0;

            _cbContrastEnhancement.Checked = (_flags & DigitalSubtractCommandFlags.ContrastEnhancement) !=0;
            _cbOptimizeRange.Checked = (_flags & DigitalSubtractCommandFlags.OptimizeRange)!=0;
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            _imageID =_paths[ _cmbMaskImage.SelectedIndex].ChildFormId;

            _flags = DigitalSubtractCommandFlags.None;

            if (_cbOptimizeRange.Checked)
                _flags |= DigitalSubtractCommandFlags.OptimizeRange;

            if (_cbContrastEnhancement.Checked)
                _flags |= DigitalSubtractCommandFlags.ContrastEnhancement;
        }

    }
}
