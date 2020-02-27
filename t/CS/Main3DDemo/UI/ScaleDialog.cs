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
    public partial class ScaleDialog : Form
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

            return trackBar.Value / 1000.0f;
        }

        public ScaleDialog()
        {
            InitializeComponent();
        }

        public ScaleDialog(MedicalViewer control, Medical3DContainer container, ItemType type, int objectIndex)
        {
            InitializeComponent();

            _oldPoint = new Medical3DPoint();
            _type = type;
            _control = control;
            _container = container;
            _objectIndex = objectIndex;

            switch (type)
            {
                case ItemType.Camera:
                    Text = "Zoom Camera Dialog";
                    _oldPoint.Y = container.Camera.Zoom;
                    break;

                case ItemType.Object:
                    Text = "Scale Object Dialog";
                    _oldPoint.X = container.Objects[objectIndex].XScale;
                    _oldPoint.Y = container.Objects[objectIndex].YScale;
                    _oldPoint.Z = container.Objects[objectIndex].ZScale;
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

            _container.Objects[_objectIndex].XScale = _trackBarX.Value / 1000.0f;
            //_control.Container.Render(_control, new Rectangle(new Point(0, 0), new Size(_control.Bounds.Width, _control.Bounds.Height)));
        }

        private void _trackBarY_Scroll(object sender, EventArgs e)
        {
            if (_trackBarY.Value != _textBoxY.Value)
                _textBoxY.Value = _trackBarY.Value;

            switch (_type)
            {
                case ItemType.Camera:
                    _container.Camera.Zoom = _trackBarY.Value / 1000.0f;
                    break;
                case ItemType.Object:
                    _container.Objects[_objectIndex].YScale = _trackBarY.Value / 1000.0f;
                    break;
            }

            //_control.Container.Render(_control, new Rectangle(new Point(0, 0), new Size(_control.Bounds.Width, _control.Bounds.Height)));
        }

        private void _trackBarZ_Scroll(object sender, EventArgs e)
        {
            if (_trackBarZ.Value != _textBoxZ.Value)
                _textBoxZ.Value = _trackBarZ.Value;
            _container.Objects[_objectIndex].ZScale = _trackBarZ.Value / 1000.0f;
            //_control.Container.Render(_control, new Rectangle(new Point(0, 0), new Size(_control.Bounds.Width, _control.Bounds.Height)));
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
                    _container.Camera.Zoom= _oldPoint.Y;
                    break;
                case ItemType.Object:
                    _container.Objects[_objectIndex].XScale = 1.0f;
                    _container.Objects[_objectIndex].YScale = 1.0f;
                    _container.Objects[_objectIndex].ZScale = 1.0f;
                    break;
            }
            _textBoxX.Value = (int)(1000);
            _textBoxY.Value = (int)(1000);
            _textBoxZ.Value = (int)(1000);

            //_control.Container.Render(_control, new Rectangle(new Point(0, 0), new Size(_control.Bounds.Width, _control.Bounds.Height)));
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
           switch (_type)
           {
              case ItemType.Camera:
                 _container.Camera.Zoom = _oldPoint.Y;
                 break;
              case ItemType.Object:
                 _container.Objects[_objectIndex].XScale = _oldPoint.X;
                 _container.Objects[_objectIndex].YScale = _oldPoint.Y;
                 _container.Objects[_objectIndex].ZScale = _oldPoint.Z;
                 break;
           }
        }
    }
}
