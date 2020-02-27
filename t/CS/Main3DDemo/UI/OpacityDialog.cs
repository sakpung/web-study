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
    public partial class OpacityDialog : Form
    {
        private MedicalViewer _viewer;
        private Medical3DContainer _container;
        private float _oldOpacityValue;

        public OpacityDialog()
        {
            InitializeComponent();
        }

        public OpacityDialog(MedicalViewer control, Medical3DContainer container)
        {
            InitializeComponent();
            _viewer = control;

            MedicalViewer3DCell cell3D = (MedicalViewer3DCell)_viewer.Cells[0];

            _container = container;
            _oldOpacityValue = container.Objects[cell3D.Container.CurrentObjectIndex].Opacity;
            _trackBarOpacity.Maximum = 100;
            _textBoxOpacity.MaximumAllowed = 100;
            _textBoxOpacity.Value = (int)container.Objects[cell3D.Container.CurrentObjectIndex].Opacity;
            _trackBarOpacity.Value = _textBoxOpacity.Value;
        }

        private void _btnReset_Click(object sender, EventArgs e)
        {
           MedicalViewer3DCell cell3D = (MedicalViewer3DCell)_viewer.Cells[0];
           _container.Objects[cell3D.Container.CurrentObjectIndex].Opacity = _oldOpacityValue;
            _textBoxOpacity.Value = (int)100;
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
           MedicalViewer3DCell cell3D = (MedicalViewer3DCell)_viewer.Cells[0];
           _container.Objects[cell3D.Container.CurrentObjectIndex].Opacity = _oldOpacityValue;
        }

        private void _trackBarOpacity_Scroll(object sender, EventArgs e)
        {
            if (_trackBarOpacity.Value != _textBoxOpacity.Value)
                _textBoxOpacity.Value = _trackBarOpacity.Value;

             MedicalViewer3DCell cell3D = (MedicalViewer3DCell)_viewer.Cells[0];
             _container.Objects[cell3D.Container.CurrentObjectIndex].Opacity = _textBoxOpacity.Value;
        }

        private void _textBoxOpacity_TextChanged(object sender, EventArgs e)
        {
            if (_trackBarOpacity.Value != _textBoxOpacity.Value)
                _trackBarOpacity.Value = _textBoxOpacity.Value;
        }
    }
}
