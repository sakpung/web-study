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
    public partial class RotatePlaneActionDialog : Form
    {
       private MedicalViewer viewer;
       private Medical3DContainer container;

       public RotatePlaneActionDialog()
        {
            InitializeComponent();
        }

        public RotatePlaneActionDialog(MedicalViewer medicalViewer, Medical3DContainer medical3DContainer)
        {
            InitializeComponent();
            viewer = medicalViewer;
            container = medical3DContainer;

           Text = "Rotate Plane Action";

           MedicalViewerRotate3DPlane rotatePlane = (MedicalViewerRotate3DPlane)viewer.GetActionProperties(MedicalViewerActionType.RotatePlane);

           switch (rotatePlane.Axis)
            {
                case Medical3DAxis.X:
                    _comboBoxAxis.SelectedIndex = 0;
                    break;
                case Medical3DAxis.Y:
                    _comboBoxAxis.SelectedIndex = 1;
                    break;
                case Medical3DAxis.Z:
                    _comboBoxAxis.SelectedIndex = 2;
                    break;
            }

            if (rotatePlane.Space == Medical3DSpace.Object)
                _comboBoxOrientation.SelectedIndex = 0;
            else
                _comboBoxOrientation.SelectedIndex = 1;
        }

        private void _btnOK_Click(object sender, EventArgs e)
        {
           MedicalViewerRotate3DPlane rotatePlane = (MedicalViewerRotate3DPlane)viewer.GetActionProperties(MedicalViewerActionType.RotatePlane);
           rotatePlane.Space = _comboBoxOrientation.SelectedIndex == 0 ? Medical3DSpace.Object : Medical3DSpace.View;

           switch(_comboBoxAxis.SelectedIndex)
           {
              case 0:
                 rotatePlane.Axis = Medical3DAxis.X;
                 break;
              case 1:
                 rotatePlane.Axis = Medical3DAxis.Y;
                 break;
              case 2:
                 rotatePlane.Axis = Medical3DAxis.Z;
                 break;
           }

           viewer.SetActionProperties(MedicalViewerActionType.RotatePlane, rotatePlane);
        }
    }
}
