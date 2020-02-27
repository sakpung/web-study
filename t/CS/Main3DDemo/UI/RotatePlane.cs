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
    public partial class RotatePlane : Form
    {
        MedicalViewer _control;
        Medical3DContainer _container;
        int _planeIndex;
        Medical3DAxis _axis;
        Medical3DSpace _space;
        Medical3DVolumeType _type;

        public RotatePlane()
        {
            InitializeComponent();
        }

        public RotatePlane(MedicalViewer control, Medical3DContainer container, int planeIndex, Medical3DVolumeType type)
        {
            InitializeComponent();
            _control = control;
            _container = container;
            _planeIndex = planeIndex;
            _type = type;
            _comboBoxAxis.SelectedIndex = 0;
            _comboBoxSpace.SelectedIndex = 0;
            MedicalViewer3DCell cell3D = (MedicalViewer3DCell)_control.Cells[0];

            if (_planeIndex == -1)
            {
               switch (_type)
               {
                  case Medical3DVolumeType.VRT:
                     _planeIndex = _container.Objects[cell3D.Container.CurrentObjectIndex].VRT.Planes.Count - 1;
                     break;

                  case Medical3DVolumeType.MIP:
                     _planeIndex = _container.Objects[cell3D.Container.CurrentObjectIndex].MIP.Planes.Count - 1;
                     break;

                  case Medical3DVolumeType.MPR:
                     _planeIndex = _container.Objects[cell3D.Container.CurrentObjectIndex].MPR.Planes.Count - 1;
                     break;
               }
            }

        }

        private void _comboBoxAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(_comboBoxAxis.SelectedIndex)
            {
                case 0:
                    _axis = Medical3DAxis.X;
                    break;
                case 1:
                    _axis = Medical3DAxis.Y;
                    break;
                case 2:
                    _axis = Medical3DAxis.Z;
                    break;
            }
        }

        private void _trackBarRotatePlane_Scroll(object sender, EventArgs e)
        {
            if (_trackBarRotatePlane.Value != _textBoxRotatePlane.Value)
                _textBoxRotatePlane.Value = _trackBarRotatePlane.Value;
        }

        private void _textBoxRotatePlane_TextChanged(object sender, EventArgs e)
        {
            _trackBarRotatePlane.Value = _textBoxRotatePlane.Value;
        }

        private void _comboBoxSpace_SelectedIndexChanged(object sender, EventArgs e)
        {
            _space = _comboBoxSpace.SelectedIndex == 0 ? Medical3DSpace.Object : Medical3DSpace.View;
        }

        private void _btnOK_Click(object sender, EventArgs e)
        {
           MedicalViewer3DCell cell3D = (MedicalViewer3DCell)_control.Cells[0];

           switch (_type)
           {
              case Medical3DVolumeType.VRT:
                 _planeIndex = _container.Objects[cell3D.Container.CurrentObjectIndex].VRT.Planes.Count - 1;
                 break;

              case Medical3DVolumeType.MIP:
                 _planeIndex = _container.Objects[cell3D.Container.CurrentObjectIndex].MIP.Planes.Count - 1;
                 break;

              case Medical3DVolumeType.MPR:
                 _planeIndex = _container.Objects[cell3D.Container.CurrentObjectIndex].MPR.Planes.Count - 1;
                 break;
           }


            switch(_type)
            {
                case Medical3DVolumeType.MIP:
                   _container.Objects[cell3D.Container.CurrentObjectIndex].MIP.Planes[_planeIndex].Rotate(_trackBarRotatePlane.Value, _axis, _space);
                    break;
                case Medical3DVolumeType.VRT:
                   _container.Objects[cell3D.Container.CurrentObjectIndex].VRT.Planes[_planeIndex].Rotate(_trackBarRotatePlane.Value, _axis, _space);
                    break;
                case Medical3DVolumeType.MPR:
                   _container.Objects[cell3D.Container.CurrentObjectIndex].MPR.Planes[_planeIndex].Rotate(_trackBarRotatePlane.Value, _axis, _space);
                    break;
            }
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
