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

namespace GrayScaleDemo
{
    public partial class CopyImageDialog : Form
    {
        private static int _imageID;
        private ViewerImages _viewer;

        public int ImageID
        {
            get { return CopyImageDialog._imageID; }
            set { CopyImageDialog._imageID = value; }
        }
        List<ViewerImages> _paths;

        public CopyImageDialog(ViewerImages viewer, List<ViewerImages> paths, RasterImage image)
        {
            InitializeComponent();
            _paths = new List<ViewerImages>();
            _viewer = viewer;

            foreach (ViewerImages tmp in paths)
            {
                try
                {
                   if (tmp.ImageName != viewer.ImageName)
                        _paths.Add(tmp);
                }
                catch (Exception /*ex*/)
                {
                }
            }
        }

        private void CopyImageDialog_Load(object sender, EventArgs e)
        {
            foreach (ViewerImages path in _paths)
                _cmbDestImage.Items.Add(path.ImageName);
            _cmbDestImage.SelectedIndex = 0;
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            _imageID = _paths[_cmbDestImage.SelectedIndex].ChildFormId;
        }


    }
}
