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
    public partial class MovePlane : Form
    {
       MedicalViewer _viewer;
       Medical3DContainer _container;
       int _planeIndex;
       Medical3DPoint point;
       Medical3DVolumeType _type;

       private void SetPlanePoint(Medical3DPoint point)
       {
          MedicalViewer3DCell cell3D = (MedicalViewer3DCell)_viewer.Cells[0];
          switch (_type)
          {
             case Medical3DVolumeType.VRT:
                _container.Objects[cell3D.Container.CurrentObjectIndex].VRT.Planes[_planeIndex].Point = point;
                break;

             case Medical3DVolumeType.MIP:
                point = _container.Objects[cell3D.Container.CurrentObjectIndex].MIP.Planes[_planeIndex].Point = point;
                break;

             case Medical3DVolumeType.MPR:
                point = _container.Objects[cell3D.Container.CurrentObjectIndex].MPR.Planes[_planeIndex].Point = point; ;
                break;
          }
       }

       private void GetPlanePoint()
       {
          MedicalViewer3DCell cell3D = (MedicalViewer3DCell)_viewer.Cells[0];
          switch (_type)
          {
             case Medical3DVolumeType.VRT:
                point = _container.Objects[cell3D.Container.CurrentObjectIndex].VRT.Planes[_planeIndex].Point;
                break;

             case Medical3DVolumeType.MIP:
                point = _container.Objects[cell3D.Container.CurrentObjectIndex].MIP.Planes[_planeIndex].Point;
                break;

             case Medical3DVolumeType.MPR:
                point = _container.Objects[cell3D.Container.CurrentObjectIndex].MPR.Planes[_planeIndex].Point;
                break;
          }
       }

       public MovePlane()
       {
          InitializeComponent();
       }

       public MovePlane(MedicalViewer viewer, Medical3DContainer container, int planeIndex, Medical3DVolumeType type)
       {
          InitializeComponent();
          _viewer = viewer;
          _container = container;
          _planeIndex = planeIndex;
          _type = type;
          MedicalViewer3DCell cell3D = (MedicalViewer3DCell)_viewer.Cells[0];

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

          GetPlanePoint();
       }

       private void _btnCancel_Click(object sender, EventArgs e)
       {
          //SetPlanePoint(point);
       }

       private void _trackBarMovePlane_Scroll(object sender, EventArgs e)
       {
          if (_trackBarMovePlane.Value != _txtMovePlane.Value)
          {
             _txtMovePlane.Value = _trackBarMovePlane.Value;
          }
       }


       void ApplyMove()
       {
          MedicalViewer3DCell cell3D = (MedicalViewer3DCell)_viewer.Cells[0];
          switch (_container.VolumeType)
          {
             case Medical3DVolumeType.VRT:
                _container.Objects[cell3D.Container.CurrentObjectIndex].VRT.Planes[_planeIndex].Move(_trackBarMovePlane.Value / 1000.0f);
                break;

             case Medical3DVolumeType.MIP:
                _container.Objects[cell3D.Container.CurrentObjectIndex].MIP.Planes[_planeIndex].Move(_trackBarMovePlane.Value / 1000.0f);
                break;

             case Medical3DVolumeType.MPR:
                _container.Objects[cell3D.Container.CurrentObjectIndex].MPR.Planes[_planeIndex].Move(_trackBarMovePlane.Value / 1000.0f);
                break;
          }
       }


       private void _txtMovePlane_TextChanged(object sender, EventArgs e)
       {
          if (_txtMovePlane.Value != _trackBarMovePlane.Value)
             _trackBarMovePlane.Value = _txtMovePlane.Value;
       }

       private void _btnOK_Click(object sender, EventArgs e)
       {
          ApplyMove();
       }
    }
 }
