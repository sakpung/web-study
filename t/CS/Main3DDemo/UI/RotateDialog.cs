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
    public partial class RotateDialog : Form
    {
        private Medical3DPoint _oldPoint;
        private ItemType _type;
        private MedicalViewer _control;
        private Medical3DContainer _container;
        private int _objectIndex;

        float SetCorrospondingTextValue(NumericTextBox textBox, TrackBar trackBar)
        {
            if (textBox.Value != trackBar.Value)
                textBox.Value = trackBar.Value;

            return trackBar.Value;
        }

        public RotateDialog()
        {
            InitializeComponent();
        }

        public RotateDialog(MedicalViewer control, Medical3DContainer container, ItemType type, int objectIndex)
        {
            InitializeComponent();

            _type = type;
            _control = control;
            _container = container;
            _objectIndex = objectIndex;
            _oldPoint = new Medical3DPoint();

            switch(type)
            {
                case ItemType.Camera:
                    Text = "Rotate Camera Dialog";
                    _textBoxX.MinimumAllowed = -180;
                    _textBoxY.MinimumAllowed = -90;
                    _textBoxZ.MinimumAllowed = 0;

                    _textBoxX.MaximumAllowed = 180;
                    _textBoxY.MaximumAllowed = 90;
                    _textBoxZ.MaximumAllowed = 360;

                    _trackBarX.Minimum = -180;
                    _trackBarY.Minimum = -90;
                    _trackBarZ.Minimum = 0;

                    _trackBarX.Maximum = 180;
                    _trackBarY.Maximum = 90;
                    _trackBarZ.Maximum = 360;

                    _oldPoint.X = container.Camera.XRotation;
                    _oldPoint.Y = container.Camera.YRotation;
                    _oldPoint.Z = container.Camera.AxialRotation;

                    break;

                case ItemType.Object:
                    Text = "Rotate Object Dialog";
                    _oldPoint.X = container.Objects[objectIndex].XRotation;
                    _oldPoint.Y = container.Objects[objectIndex].YRotation;
                    _oldPoint.Z = container.Objects[objectIndex].ZRotation;
                    break;
            }

            _textBoxX.Value = (int)_oldPoint.X;
            _textBoxY.Value = (int)_oldPoint.Y;
            _textBoxZ.Value = (int)_oldPoint.Z;
        }


        private void _trackBarX_Scroll(object sender, EventArgs e)
        {
        }

        private void _trackBarY_Scroll(object sender, EventArgs e)
        {
        }

        private void _trackBarZ_Scroll(object sender, EventArgs e)
        {
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
                    _container.Camera.AxialRotation = 90; //_oldPoint.X;
                    _container.Camera.YRotation = 0; //_oldPoint.Y;
                    _container.Camera.XRotation = -90; //_oldPoint.Z;
                    break;
                case ItemType.Object:
                    _container.Objects[_objectIndex].ZRotation = 0; //_oldPoint.Z;
                    _container.Objects[_objectIndex].YRotation = 0; //_oldPoint.Y;
                    _container.Objects[_objectIndex].XRotation = 0; //_oldPoint.X;
                    break;
            }
            _textBoxX.Value = -90; //(int)_oldPoint.X;
            _textBoxY.Value = 0; //(int)_oldPoint.Y;
            _textBoxZ.Value = 90; //(int)_oldPoint.Z;

            //_control.Container.Render(_control, new Rectangle(new Point(0, 0), new Size(_control.Bounds.Width, _control.Bounds.Height)));
        }

        private void _trackBarX_ValueChanged(object sender, EventArgs e)
        {
            if (_trackBarX.Value != _textBoxX.Value)
                _textBoxX.Value = _trackBarX.Value;

            switch (_type)
            {
                case ItemType.Camera:
                    _container.Camera.XRotation = _trackBarX.Value;
                    break;
                case ItemType.Object:
                    _container.Objects[_objectIndex].XRotation = _trackBarX.Value;
                    break;
            }

            //_control.Container.Render(_control, new Rectangle(new Point(0, 0), new Size(_control.Bounds.Width, _control.Bounds.Height)));
        }

        private void _trackBarY_ValueChanged(object sender, EventArgs e)
        {
            if (_trackBarY.Value != _textBoxY.Value)
                _textBoxY.Value = _trackBarY.Value;

            switch (_type)
            {
                case ItemType.Camera:
                    _container.Camera.YRotation = _trackBarY.Value;
                    break;
                case ItemType.Object:
                    _container.Objects[_objectIndex].YRotation = _trackBarY.Value;
                    break;
            }

            //_control.Container.Render(_control, new Rectangle(new Point(0, 0), new Size(_control.Bounds.Width, _control.Bounds.Height)));
        }

        private void _trackBarZ_ValueChanged(object sender, EventArgs e)
        {
            if (_trackBarZ.Value != _textBoxZ.Value)
                _textBoxZ.Value = _trackBarZ.Value;

            switch (_type)
            {
                case ItemType.Camera:
                    _container.Camera.AxialRotation = _trackBarZ.Value;
                    break;
                case ItemType.Object:
                    _container.Objects[_objectIndex].ZRotation = _trackBarZ.Value;
                    break;
            }

            //_control.Container.Render(_control, new Rectangle(new Point(0, 0), new Size(_control.Bounds.Width, _control.Bounds.Height)));
        }

        private void _btnOK_Click(object sender, EventArgs e)
        {

        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            switch (_type)
            {
                case ItemType.Camera:
                    _container.Camera.AxialRotation = _oldPoint.Z;
                    _container.Camera.YRotation = _oldPoint.Y;
                    _container.Camera.XRotation = _oldPoint.X;
                    break;
                case ItemType.Object:
                    _container.Objects[_objectIndex].ZRotation = _oldPoint.Z;
                    _container.Objects[_objectIndex].YRotation = _oldPoint.Y;
                    _container.Objects[_objectIndex].XRotation = _oldPoint.X;
                    break;
            }
            _textBoxX.Value = (int)_oldPoint.X;
            _textBoxY.Value = (int)_oldPoint.Y;
            _textBoxZ.Value = (int)_oldPoint.Z;

            //_control.Container.Render(_control, new Rectangle(new Point(0, 0), new Size(_control.Bounds.Width, _control.Bounds.Height)));
        }
    }
}
