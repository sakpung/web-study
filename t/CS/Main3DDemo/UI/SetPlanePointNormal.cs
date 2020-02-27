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
    public partial class SetPlanePointNormal : Form
    {
        Medical3DVolumeType _type;
        Medical3DContainer _container;
        MedicalViewer _viewer;
        int _planeIndex;
        Medical3DPoint point;
        Medical3DPoint normal;
        private bool _dontApply;

        public SetPlanePointNormal()
        {
            InitializeComponent();
        }

        void applyNewValue(bool old)
        {
            if (_dontApply)
                return; 

            Medical3DPoint currentPoint;
            Medical3DPoint currentNormal;

            if (old)
            {
                currentPoint = new Medical3DPoint(point.X, point.Y, point.Z);
                currentNormal = new Medical3DPoint(normal.X, normal.Y, normal.Z);
            }
            else
            {
                currentPoint = new Medical3DPoint(_textBoxPointX.Value, _textBoxPointY.Value, _textBoxPointZ.Value);
                currentNormal = new Medical3DPoint(_textBoxNormalX.Value, _textBoxNormalY.Value, _textBoxNormalZ.Value);
            }

            MedicalViewer3DCell cell3D = (MedicalViewer3DCell)_viewer.Cells[0];

            switch (_type)
            {
                case Medical3DVolumeType.MIP:
                   _container.Objects[cell3D.Container.CurrentObjectIndex].MIP.Planes[_planeIndex].Point = currentPoint;
                   _container.Objects[cell3D.Container.CurrentObjectIndex].MIP.Planes[_planeIndex].Normal = currentNormal;
                    break;
                case Medical3DVolumeType.VRT:
                   _container.Objects[cell3D.Container.CurrentObjectIndex].VRT.Planes[_planeIndex].Point = currentPoint;
                   _container.Objects[cell3D.Container.CurrentObjectIndex].VRT.Planes[_planeIndex].Normal = currentNormal;
                    break;
                case Medical3DVolumeType.MPR:
                   _container.Objects[cell3D.Container.CurrentObjectIndex].MPR.Planes[_planeIndex].Point = currentPoint;
                   _container.Objects[cell3D.Container.CurrentObjectIndex].MPR.Planes[_planeIndex].Normal = currentNormal;
                    break;
            }

            cell3D.Invalidate();
         }

        void UpdatePlanePointNormal()
        {
           MedicalViewer3DCell cell3D = (MedicalViewer3DCell)_viewer.Cells[0];
           switch (_type)
            {
                case Medical3DVolumeType.MIP:
                   normal = _container.Objects[cell3D.Container.CurrentObjectIndex].MIP.Planes[_planeIndex].Normal;
                   point = _container.Objects[cell3D.Container.CurrentObjectIndex].MIP.Planes[_planeIndex].Point;
                    break;
                case Medical3DVolumeType.VRT:
                   normal = _container.Objects[cell3D.Container.CurrentObjectIndex].VRT.Planes[_planeIndex].Normal;
                   point = _container.Objects[cell3D.Container.CurrentObjectIndex].VRT.Planes[_planeIndex].Point;
                    break;
                case Medical3DVolumeType.MPR:
                   normal = _container.Objects[cell3D.Container.CurrentObjectIndex].MPR.Planes[_planeIndex].Normal;
                   point = _container.Objects[cell3D.Container.CurrentObjectIndex].MPR.Planes[_planeIndex].Point;
                    break;
            }

            _textBoxPointX.Value = point.X;
            _textBoxPointY.Value = point.Y;
            _textBoxPointZ.Value = point.Z;
            _textBoxNormalX.Value = normal.X;
            _textBoxNormalY.Value = normal.Y;
            _textBoxNormalZ.Value = normal.Z;
        }

       public SetPlanePointNormal(MedicalViewer viewer, Medical3DContainer container, Medical3DVolumeType type, int index)
        {
           MedicalViewer3DCell cell3D = (MedicalViewer3DCell)viewer.Cells[0];
           InitializeComponent();
            _type = type;
            _container = container;
            _planeIndex = index;
            _dontApply = true;
            _viewer = viewer;
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

            UpdatePlanePointNormal();
            _dontApply = false;
        }


        private void _textBoxPointX_TextChanged(object sender, EventArgs e)
        {
            applyNewValue(false);
        }

        private void _textBoxPointY_TextChanged(object sender, EventArgs e)
        {
            applyNewValue(false);
        }

        private void _textBoxPointZ_TextChanged(object sender, EventArgs e)
        {
            applyNewValue(false);
        }

        private void _textBoxNormalX_TextChanged(object sender, EventArgs e)
        {
            applyNewValue(false);
        }

        private void _textBoxNormalY_TextChanged(object sender, EventArgs e)
        {
            applyNewValue(false);
        }

        private void _textBoxNormalZ_TextChanged(object sender, EventArgs e)
        {
            applyNewValue(false);
        }

        private void _txtBoxIndex_TextChanged(object sender, EventArgs e)
        {
            applyNewValue(true);
            UpdatePlanePointNormal();
        }

        private void _btnReset_Click(object sender, EventArgs e)
        {
            applyNewValue(true);
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            applyNewValue(true);
        }
    }
}
