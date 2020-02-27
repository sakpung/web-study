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
    public partial class SlabDialog : Form
    {
        private Medical3DSlab slab;
        private Medical3DSlab previousSlabValue;
        private MedicalViewer viewer;
        float SetCorrospondingTextValue(NumericTextBox textBox, TrackBar trackBar)
        {
            if (textBox.Value != trackBar.Value)
                textBox.Value = trackBar.Value;

            return trackBar.Value / 1000.0f;
        }


        void EnableControls(bool enable)
        {
            _trackBarY2.Enabled = enable;
            _trackBarZ2.Enabled = enable;
            _trackBarX2.Enabled = enable;
            _trackBarY1.Enabled = enable;
            _trackBarZ1.Enabled = enable;
            _trackBarX1.Enabled = enable;
            _textBoxX1.Enabled = enable;
            _textBoxY1.Enabled = enable;
            _textBoxZ1.Enabled = enable;
            _textBoxZ2.Enabled = enable;
            _textBoxY2.Enabled = enable;
            _textBoxX2.Enabled = enable;
            slab.Enabled = enable;
        }

        public SlabDialog(MedicalViewer medicalViewer, Medical3DContainer Medical3DContainer, Medical3DVolumeType type)
        {
           viewer = medicalViewer;
           MedicalViewer3DCell cell3D = (MedicalViewer3DCell)viewer.Cells[0];
            InitializeComponent();
            switch (type)
            {
                case Medical3DVolumeType.MIP:
                   slab = Medical3DContainer.Objects[cell3D.Container.CurrentObjectIndex].MIP.Slab;
                    break;
                case Medical3DVolumeType.VRT:
                   slab = Medical3DContainer.Objects[cell3D.Container.CurrentObjectIndex].VRT.Slab;
                    break;
            }
            previousSlabValue = new Medical3DSlab(slab);
            EnableControls(slab.Enabled);
            _chkBoxenableSlab.Checked = slab.Enabled;
            _textBoxX1.Value = (int)(slab.X1 * 1000);
            _textBoxY1.Value = (int)(slab.Y1 * 1000);
            _textBoxZ1.Value = (int)(slab.Z1 * 1000);
            _textBoxZ2.Value = (int)(slab.Z2 * 1000);
            _textBoxY2.Value = (int)(slab.Y2 * 1000);
            _textBoxX2.Value = (int)(slab.X2 * 1000);
        }

        private void _btnReset_Click(object sender, EventArgs e)
        {
            slab.SetValues(-1, 1, -1, 1, -1, 1);

            _textBoxX1.Value = -1000;
            _textBoxY1.Value = -1000;
            _textBoxZ1.Value = -1000;
            _textBoxZ2.Value = 1000;
            _textBoxY2.Value = 1000;
            _textBoxX2.Value = 1000;

            slab.Enabled = false;
            _chkBoxenableSlab.Checked = false;

        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            slab.SetValues(previousSlabValue);
        }

        private void _trackBarX1_ValueChanged(object sender, EventArgs e)
        {
            slab.X1 = SetCorrospondingTextValue(_textBoxX1, _trackBarX1);
        }

        private void _trackBarY1_ValueChanged(object sender, EventArgs e)
        {
            slab.Y1 = SetCorrospondingTextValue(_textBoxY1, _trackBarY1);
        }

        private void _trackBarZ1_ValueChanged(object sender, EventArgs e)
        {
            slab.Z1 = SetCorrospondingTextValue(_textBoxZ1, _trackBarZ1);
        }

        private void _trackBarX2_ValueChanged(object sender, EventArgs e)
        {
            slab.X2 = SetCorrospondingTextValue(_textBoxX2, _trackBarX2);
        }

        private void _trackBarY2_ValueChanged(object sender, EventArgs e)
        {
            slab.Y2 = SetCorrospondingTextValue(_textBoxY2, _trackBarY2);
        }

        private void _trackBarZ2_ValueChanged(object sender, EventArgs e)
        {
            slab.Z2 = SetCorrospondingTextValue(_textBoxZ2, _trackBarZ2);
        }

        private void _textBoxX1_TextChanged(object sender, EventArgs e)
        {
            _trackBarX1.Value = _textBoxX1.Value;
        }

        private void _textBoxY1_TextChanged(object sender, EventArgs e)
        {
            _trackBarY1.Value = _textBoxY1.Value;
        }

        private void _textBoxZ1_TextChanged(object sender, EventArgs e)
        {
            _trackBarZ1.Value = _textBoxZ1.Value;
        }

        private void _textBoxX2_TextChanged(object sender, EventArgs e)
        {
            _trackBarX2.Value = _textBoxX2.Value;
        }

        private void _textBoxY2_TextChanged(object sender, EventArgs e)
        {
            _trackBarY2.Value = _textBoxY2.Value;
        }

        private void _textBoxZ2_TextChanged(object sender, EventArgs e)
        {
            _trackBarZ2.Value = _textBoxZ2.Value;
        }

        private void _chkBoxenableSlab_CheckedChanged(object sender, EventArgs e)
        {
            EnableControls(_chkBoxenableSlab.Checked);
        }
    }
}
