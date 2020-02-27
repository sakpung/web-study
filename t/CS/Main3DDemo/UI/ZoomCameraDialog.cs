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

using Leadtools.Medical3D;
using Leadtools.MedicalViewer;

namespace Main3DDemo
{
    public partial class ZoomCameraDialog : Form
    {
        private MedicalViewer _control;
        private Medical3DContainer _container;
        private float _oldZoomValue;

        public ZoomCameraDialog()
        {
            InitializeComponent();
        }

        public ZoomCameraDialog(MedicalViewer control, Medical3DContainer container)
        {
            InitializeComponent();
            _control = control;
            _container = container;
            _oldZoomValue = container.Camera.Zoom;
            _trackBarZoom.Maximum = 180;
            _textBoxZoom.MaximumAllowed = 180;
            _textBoxZoom.Value = (180 - (int)container.Camera.Zoom);
            _trackBarZoom.Value = _textBoxZoom.Value;
        }

        private void _btnReset_Click(object sender, EventArgs e)
        {
           _container.Camera.Zoom = (int)(180 - 128);
           _textBoxZoom.Value = (int)128;
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            _container.Camera.Zoom = _oldZoomValue;
        }

        private void _trackBarZoom_Scroll(object sender, EventArgs e)
        {
            if (_trackBarZoom.Value != _textBoxZoom.Value)
                _textBoxZoom.Value = _trackBarZoom.Value;

            _container.Camera.Zoom = (180 - _textBoxZoom.Value);
        }

        private void _textBoxZoom_TextChanged(object sender, EventArgs e)
        {
            if (_trackBarZoom.Value != _textBoxZoom.Value)
                _trackBarZoom.Value = _textBoxZoom.Value;
        }
    }
}
