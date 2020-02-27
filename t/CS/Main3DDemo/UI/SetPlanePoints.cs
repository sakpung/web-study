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
using Leadtools.Demos;
using Leadtools.MedicalViewer;

namespace Main3DDemo
{
    public partial class SetPlanePoints : Form
    {
       Medical3DContainer container;
       Medical3DVolumeType type;
       int _planeIndex;
       MedicalViewer _viewer;

        public SetPlanePoints()
        {
            InitializeComponent();
        }

        public SetPlanePoints(MedicalViewer viewer, Medical3DContainer Medical3DContainer, Medical3DVolumeType Medical3DVolumeType, int index)
        {
            InitializeComponent();

            container = Medical3DContainer;
            type = Medical3DVolumeType;
            _planeIndex = index;
           _viewer = viewer;
           Medical3DPoint[] pointArray = null;

           MedicalViewer3DCell cell3D = (MedicalViewer3DCell)_viewer.Cells[0];
            if (_planeIndex == -1)
            {
               switch (type)
               {
                  case Medical3DVolumeType.VRT:
                     _planeIndex = container.Objects[cell3D.Container.CurrentObjectIndex].VRT.Planes.Count - 1;
                     pointArray  = container.Objects[cell3D.Container.CurrentObjectIndex].VRT.Planes[_planeIndex].GetPlanePoints();
                     break;

                  case Medical3DVolumeType.MIP:
                     _planeIndex = container.Objects[cell3D.Container.CurrentObjectIndex].MIP.Planes.Count - 1;
                     pointArray  = container.Objects[cell3D.Container.CurrentObjectIndex].MIP.Planes[_planeIndex].GetPlanePoints();
                     break;

                  case Medical3DVolumeType.MPR:
                     _planeIndex = container.Objects[cell3D.Container.CurrentObjectIndex].MPR.Planes.Count - 1;
                     pointArray  = container.Objects[cell3D.Container.CurrentObjectIndex].MPR.Planes[_planeIndex].GetPlanePoints();
                     break;
               }
            }
            else 
           {
               switch (type)
               {
                  case Medical3DVolumeType.VRT:
                     pointArray  = container.Objects[cell3D.Container.CurrentObjectIndex].VRT.Planes[_planeIndex].GetPlanePoints();
                     break;

                  case Medical3DVolumeType.MIP:
                     pointArray  = container.Objects[cell3D.Container.CurrentObjectIndex].MIP.Planes[_planeIndex].GetPlanePoints();
                     break;

                  case Medical3DVolumeType.MPR:
                     pointArray  = container.Objects[cell3D.Container.CurrentObjectIndex].MPR.Planes[_planeIndex].GetPlanePoints();
                     break;
               }
           }

           _textBoxPoint1X.Value = pointArray[0].X;
           _textBoxPoint2X.Value = pointArray[1].X;
           _textBoxPoint3X.Value = pointArray[2].X;

           _textBoxPoint1Y.Value = pointArray[0].Y;
           _textBoxPoint2Y.Value = pointArray[1].Y;
           _textBoxPoint3Y.Value = pointArray[2].Y;

           _textBoxPoint1Z.Value = pointArray[0].Z;
           _textBoxPoint2Z.Value = pointArray[1].Z;
           _textBoxPoint3Z.Value = pointArray[2].Z;
        }

        private void _btnOK_Click(object sender, EventArgs e)
        {
            Medical3DPoint point1 = new Medical3DPoint(_textBoxPoint1X.Value, _textBoxPoint1Y.Value, _textBoxPoint1Z.Value);
            Medical3DPoint point2 = new Medical3DPoint(_textBoxPoint2X.Value, _textBoxPoint2Y.Value, _textBoxPoint2Z.Value);
            Medical3DPoint point3 = new Medical3DPoint(_textBoxPoint3X.Value, _textBoxPoint3Y.Value, _textBoxPoint3Z.Value);

            switch (type)
            {
               case Medical3DVolumeType.VRT:
                  _planeIndex = container.Objects[container.CurrentObjectIndex].VRT.Planes.Count - 1;
                  break;

               case Medical3DVolumeType.MIP:
                  _planeIndex = container.Objects[container.CurrentObjectIndex].MIP.Planes.Count - 1;
                  break;

               case Medical3DVolumeType.MPR:
                  _planeIndex = container.Objects[container.CurrentObjectIndex].MPR.Planes.Count - 1;
                  break;
            }

            try
            {
                switch (type)
                {
                    case Medical3DVolumeType.MIP:
                        container.Objects[container.CurrentObjectIndex].MIP.Planes[_planeIndex].SetPlanePoints(point1, point2, point3);
                        break;
                    case Medical3DVolumeType.VRT:
                        container.Objects[container.CurrentObjectIndex].VRT.Planes[_planeIndex].SetPlanePoints(point1, point2, point3);
                        break;
                    case Medical3DVolumeType.MPR:
                        container.Objects[container.CurrentObjectIndex].MPR.Planes[_planeIndex].SetPlanePoints(point1, point2, point3);
                        break;
                }
            }
            catch (System.Exception ex)
            {
                Messager.ShowError(this, ex);
            }
        }

        private void _btnReset_Click(object sender, EventArgs e)
        {
            _textBoxPoint1X.Value = 0;
            _textBoxPoint1Y.Value = 0;
            _textBoxPoint1Z.Value = 0;
            _textBoxPoint2X.Value = 0;
            _textBoxPoint2Y.Value = 0;
            _textBoxPoint2Z.Value = 0;
            _textBoxPoint3X.Value = 0;
            _textBoxPoint3Y.Value = 0;
            _textBoxPoint3Z.Value = 0;
        }
    }
}
