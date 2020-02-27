// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

using Leadtools.Medical3D;
using Leadtools.MedicalViewer;
using Leadtools.Demos;

namespace Main3DDemo
{
    public partial class ContainerProperties : Form
    {
        Medical3DContainer _container;
        Medical3DControl _control3D;
        MedicalViewerMPRCell _mprCell;
        MedicalViewerMultiCell _cell;
        MedicalViewer _viewer;

        void FillDialogWithDefaultValues()
        {
            _comboBoxProjectionMethod.SelectedIndex = 0;

            _lblBoundaryBoxColor.BoxColor = Color.Red;
            _lblBackgroundColor.BoxColor = Color.Black;
            _lblFrameBoundaryColor.BoxColor = Color.Blue;
            _lblIntersectionLineColor.BoxColor = Color.White;
            _txtCameraNear.Value = 1;
            _txtCameraFar.Value = 6;

            _chkBoundaryBox.Checked = true;
            _chkIntersectionLine.Checked = false;
            _chkFrameBoundary.Checked = true;
            _chkRemoveBackground.Checked = false;

            _btnBoundaryBoxColor.Enabled =
            _lblBoundaryBoxColor.Enabled = true;

            _lblFrameBoundaryColor.Enabled =
            _btnFrameBoundaryColor.Enabled = true;

            _lblIntersectionLineColor.Enabled =
            _btnIntersectionLineColor.Enabled = false;
        }


        void FillDialogWithOldValues()
        {
            _lblFrameBoundaryColor.BoxColor = _container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].MPR.FrameBoundariesColor;
            _lblIntersectionLineColor.BoxColor = _container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].MPR.IntersectionLineColor;


            _chkIntersectionLine.Checked = _container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].MPR.EnableIntersectionLines;
            _chkFrameBoundary.Checked = _container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].MPR.EnableFrameBoundaries;
            _chkRemoveBackground.Checked = _container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].MPR.RemoveBackground;
            _btnBoundaryBoxColor.Enabled =
            _lblBoundaryBoxColor.Enabled = _chkBoundaryBox.Checked;

            _lblFrameBoundaryColor.Enabled =
             _btnFrameBoundaryColor.Enabled = _chkFrameBoundary.Checked;

            _lblIntersectionLineColor.Enabled =
            _btnIntersectionLineColor.Enabled = _chkIntersectionLine.Checked;


            _comboBoxProjectionMethod.SelectedIndex = (_container.Camera.ProjectionMethod == Medical3DProjectionMethod.Perspective) ? 0 : 1;
            _lblBoundaryBoxColor.BoxColor = _container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].BoundaryBoxColor;
            _lblBackgroundColor.BoxColor = _container.BackgroundColor;
            _txtCameraNear.Value = (int)_container.Camera.Near;
            _txtCameraFar.Value = (int)_container.Camera.Far;
            _chkBoundaryBox.Checked = _container.Objects[_control3D.ObjectsContainer.CurrentObjectIndex].EnableBoundaryBox;

            if (_container.VolumeType == Medical3DVolumeType.SSD)
            {
                _lblFrameBoundaryColor.Enabled = false;
                _lblIntersectionLineColor.Enabled = false;

                _chkIntersectionLine.Enabled = false;
                _chkFrameBoundary.Enabled = false;
                _chkRemoveBackground.Enabled = false;

                _lblFrameBoundaryColor.Enabled =
                _btnFrameBoundaryColor.Enabled = false;

                _lblIntersectionLineColor.Enabled =

                _btnIntersectionLineColor.Enabled = false;

            }
        }

        public ContainerProperties()
        {
            InitializeComponent();
        }

        private MedicalViewerMPRCell FindFirstMPRCell(MedicalViewer viewer)
        {
            foreach (Control control in viewer.Cells)
            {
               if (control is MedicalViewerMPRCell)
                  return (MedicalViewerMPRCell)control;
            }

            return null;
        }

        private MedicalViewerMultiCell FindFirstMultiCell(MedicalViewer viewer)
        {
            foreach (Control control in viewer.Cells)
            {
                if (control is MedicalViewerMultiCell)
                    return (MedicalViewerMultiCell)control;
            }

            return null;
        }

        public ContainerProperties(Medical3DControl control3D, MedicalViewer viewer, Medical3DContainer container)
        {
            _container = container;
            _control3D = control3D;
            _viewer = viewer;

            _mprCell = FindFirstMPRCell(viewer);
            _cell = FindFirstMultiCell(viewer);


            InitializeComponent();
            FillDialogWithOldValues();
        }

        private void _btnOK_Click(object sender, EventArgs e)
        {
            int index;

            for (index = 0; index < _control3D.ObjectsContainer.Objects.Count; index++)
            {
                {
                    _container.Objects[index].EnableBoundaryBox = _chkBoundaryBox.Checked;
                    _container.BackgroundColor = _lblBackgroundColor.BoxColor;
                    _container.Camera.ProjectionMethod = _comboBoxProjectionMethod.SelectedIndex == 0 ? Medical3DProjectionMethod.Perspective : Medical3DProjectionMethod.Orthogonal;
                    _container.Objects[index].BoundaryBoxColor = _lblBoundaryBoxColor.BoxColor;

                    if (_txtCameraNear.Value > _txtCameraFar.Value)
                    {
                        MessageBox.Show(DemosGlobalization.GetResxString(GetType(), "Resx_NearValue"),DemosGlobalization.GetResxString(GetType(), "Resx_FarValues"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        if (_txtCameraNear.Value > _container.Camera.Far)
                        {
                            _container.Camera.Far = Math.Max(1, _txtCameraFar.Value);
                            _container.Camera.Near = Math.Max(1, _txtCameraNear.Value);
                        }
                        else
                        {
                            _container.Camera.Near = Math.Max(1, _txtCameraNear.Value);
                            _container.Camera.Far = Math.Max(1, _txtCameraFar.Value);
                        }
                    }
                }

                if (_container.VolumeType != Medical3DVolumeType.SSD)
                {
                    _container.Objects[index].MPR.EnableFrameBoundaries = _chkFrameBoundary.Checked;
                    _container.Objects[index].MPR.EnableIntersectionLines = _chkIntersectionLine.Checked;
                    _container.Objects[index].MPR.FrameBoundariesColor = _lblFrameBoundaryColor.BoxColor;
                    _container.Objects[index].MPR.IntersectionLineColor = _lblIntersectionLineColor.BoxColor;
                    _container.Objects[index].MPR.RemoveBackground = _chkRemoveBackground.Checked;
                }
            }

            _control3D.Invalidate();
            _control3D.Update();
        }

        private void _btnReset_Click(object sender, EventArgs e)
        {
            FillDialogWithDefaultValues();
        }

        private void _btnBoundaryBoxColor_Click(object sender, EventArgs e)
        {
            ShowColorDialog(_lblBoundaryBoxColor);
        }

        private void _btnBackgroundColor_Click(object sender, EventArgs e)
        {
            ShowColorDialog(_lblBackgroundColor);
        }

        private void _btnFrameBoundaryColor_Click(object sender, EventArgs e)
        {
            ShowColorDialog(_lblFrameBoundaryColor);
        }

        private void _btnIntersectionLineColor_Click(object sender, EventArgs e)
        {
            ShowColorDialog(_lblIntersectionLineColor);
        }

        private void _chkBoundaryBox_CheckedChanged(object sender, EventArgs e)
        {
            _lblBoundaryBoxColor.Enabled = _chkBoundaryBox.Checked;
            _btnBoundaryBoxColor.Enabled = _chkBoundaryBox.Checked;
        }

        private void _chkFrameBoundary_CheckedChanged(object sender, EventArgs e)
        {
            _lblFrameBoundaryColor.Enabled = _chkFrameBoundary.Checked;
            _btnFrameBoundaryColor.Enabled = _chkFrameBoundary.Checked;
        }

        private void _chkIntersectionLine_CheckedChanged(object sender, EventArgs e)
        {
            _lblIntersectionLineColor.Enabled = _chkIntersectionLine.Checked;
            _btnIntersectionLineColor.Enabled = _chkIntersectionLine.Checked;

        }

        private void _btnApply_Click(object sender, EventArgs e)
        {
            _btnOK_Click(sender, e);
        }

        public static void ShowColorDialog(Label label)
        {
            ColorDialog colorDlg = new ColorDialog();

            colorDlg.Color = label.BackColor;
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                label.BackColor = colorDlg.Color;
            }
        }



    }
}






