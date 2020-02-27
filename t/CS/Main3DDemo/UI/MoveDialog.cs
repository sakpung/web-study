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
    public partial class MoveDialog : Form
    {
        private Medical3DPoint _oldPoint;
        private ItemType _type;
        private MedicalViewer _viewer;
        private Medical3DContainer _container;
        private int _objectIndex;

        float SetCorrospondingTextValue(NumericTextBox textBox, TrackBar trackBar)
        {
            if (textBox.Value != trackBar.Value)
                textBox.Value = trackBar.Value;

            return trackBar.Value / 1000.0f;
        }

        public MoveDialog()
        {
            InitializeComponent();
        }

        public MoveDialog(MedicalViewer viewer, Medical3DContainer container, ItemType type, int objectIndex)
        {
            InitializeComponent();

            _oldPoint = new Medical3DPoint();
            _type = type;
            _viewer = viewer;
            _container = container;
            _objectIndex = objectIndex;

            switch(type)
            {
                case ItemType.Camera:
                    Text = "Move Camera Dialog";
                    _oldPoint.X = container.Camera.XOffset;
                    _oldPoint.Y = container.Camera.YOffset;
                    _oldPoint.Z = container.Camera.ZOffset;
                    _textBoxZ.MaximumAllowed = 4000;
                    _textBoxZ.MinimumAllowed = 0;
                    _trackBarZ.Maximum = 4000;
                    _trackBarZ.Minimum= 0;
                    break;

                case ItemType.Object:
                    Text = "Move Object Dialog";
                    _oldPoint.X = container.Objects[objectIndex].XOffset;
                    _oldPoint.Y = container.Objects[objectIndex].YOffset;
                    _oldPoint.Z = container.Objects[objectIndex].ZOffset;
                    break;
            }

            _textBoxX.Value = (int)(_oldPoint.X * 1000);
            _textBoxY.Value = (int)(_oldPoint.Y * 1000);
            _textBoxZ.Value = (int)(_oldPoint.Z * 1000);
        }


        private void _trackBarX_Scroll(object sender, EventArgs e)
        {
            if (_trackBarX.Value != _textBoxX.Value)
                _textBoxX.Value = _trackBarX.Value;
            
            switch (_type)
            {
                case ItemType.Camera:
                    _container.Camera.XOffset = _trackBarX.Value / 1000.0f;
                    break;
                case ItemType.Object:
                    _container.Objects[_objectIndex].XOffset = _trackBarX.Value / 1000.0f;
                    break;
            }
        }

        private void _trackBarY_Scroll(object sender, EventArgs e)
        {
            if (_trackBarY.Value != _textBoxY.Value)
                _textBoxY.Value = _trackBarY.Value;

            switch (_type)
            {
                case ItemType.Camera:
                    _container.Camera.YOffset = _trackBarY.Value / 1000.0f;
                    break;
                case ItemType.Object:
                    _container.Objects[_objectIndex].YOffset = _trackBarY.Value / 1000.0f;
                    break;
            }
        }

        private void _trackBarZ_Scroll(object sender, EventArgs e)
        {
            if (_trackBarZ.Value != _textBoxZ.Value)
                _textBoxZ.Value = _trackBarZ.Value;

            switch (_type)
            {
                case ItemType.Camera:
                    _container.Camera.ZOffset = _trackBarZ.Value / 1000.0f;
                    break;
                case ItemType.Object:
                    _container.Objects[_objectIndex].ZOffset = _trackBarZ.Value / 1000.0f;
                    break;
            }
        }

        private void _textBoxZ_TextChanged(object sender, EventArgs e)
        {
            _trackBarZ.Value = _textBoxZ.Value;
        }

        private void _textBoxY_TextChanged(object sender, EventArgs e)
        {
            _trackBarY.Value = _textBoxY.Value;
        }

        private void _textBoxX_TextChanged(object sender, EventArgs e)
        {
            _trackBarX.Value = _textBoxX.Value;
        }

        private void _btnReset_Click(object sender, EventArgs e)
        {
            switch (_type)
            {
                case ItemType.Camera:
                    _container.Camera.XOffset = 0;
                    _container.Camera.YOffset = 0;
                    _container.Camera.ZOffset = 3;
                    _textBoxZ.Value = 3000;
                    break;
                case ItemType.Object:
                   _container.Objects[_objectIndex].XOffset = 0;
                   _container.Objects[_objectIndex].YOffset = 0;
                   _container.Objects[_objectIndex].ZOffset = 0;
                   _textBoxZ.Value = 0;
                   break;
            }
            _textBoxX.Value = 0;
            _textBoxY.Value = 0;
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
           switch (_type)
           {
              case ItemType.Camera:
                 _container.Camera.XOffset = _oldPoint.X;
                 _container.Camera.YOffset = _oldPoint.Y;
                 _container.Camera.ZOffset = _oldPoint.Z;
                 break;
              case ItemType.Object:
                 _container.Objects[_objectIndex].XOffset = _oldPoint.X;
                 _container.Objects[_objectIndex].YOffset = _oldPoint.Y;
                 _container.Objects[_objectIndex].ZOffset = _oldPoint.Z;
                 _textBoxZ.Value = 0;
                 break;
           }
           _textBoxX.Value = (int)(_oldPoint.X * 1000);
           _textBoxY.Value = (int)(_oldPoint.Y * 1000);
           _textBoxZ.Value = (int)(_oldPoint.Z * 1000);
        }
    }
}
