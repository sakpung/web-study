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

using Leadtools.ImageProcessing.Core;

using Leadtools.Demos;
using Leadtools;
using Leadtools.Controls;

namespace GrayScaleDemo
{
    public partial class MultiscaleEnhancementDialog : Form
    {
        private RasterImage _originalBitmap;
        private ImageViewer _viewer;
        private ViewerForm _form;
        private MainForm _mainForm;

        public MultiscaleEnhancementDialog(MainForm mainForm, ViewerForm form)
        {
            InitializeComponent();

            _mainForm = mainForm;
            _form = form;
            _viewer = form.Viewer;
            _originalBitmap = _viewer.Image.Clone();

            int uMaxLevels = Math.Max(form.Image.Width, form.Image.Height);

            int nRangeMax = (int)Math.Ceiling(Math.Log(uMaxLevels) / Math.Log(2.0));

            _numEdgeLevel.Maximum = new decimal(nRangeMax);
            _numLatLevel.Maximum = new decimal(nRangeMax);

            _cbFilter.SelectedIndex = 3;
        }

        private void _num_Leave(object sender, System.EventArgs e)
        {
            DialogUtilities.NumericOnLeave(sender);
        }

        private void _btnOk_Click(object sender, System.EventArgs e)
        {
            ApplyFilter();
            this.Close();
        }

        private void _cbEdge_CheckedChanged(object sender, EventArgs e)
        {
            _cbEdgeLevel.Enabled = _cbEdge.Checked;
            _cbEdgeCoef.Enabled = _cbEdge.Checked;

            _numEdgeLevel.Enabled = _cbEdgeLevel.Enabled && _cbEdgeLevel.Checked;
            _numEdgeCoef.Enabled = _cbEdgeCoef.Enabled && _cbEdgeCoef.Checked;
        }

        private void cbLatitude_CheckedChanged(object sender, EventArgs e)
        {
            _cbLatLevel.Enabled = _cbLatitude.Checked;
            _cbLatCoef.Enabled = _cbLatitude.Checked;

            _numLatLevel.Enabled = _cbLatLevel.Enabled && _cbLatLevel.Checked;
            _numLatCoef.Enabled = _cbLatCoef.Enabled && _cbLatCoef.Checked;
        }

        private void _cbEdgeLevel_CheckedChanged(object sender, EventArgs e)
        {
            _numEdgeLevel.Enabled = _cbEdgeLevel.Checked;
        }

        private void _cbEdgeCoef_CheckedChanged(object sender, EventArgs e)
        {
            _numEdgeCoef.Enabled = _cbEdgeCoef.Checked;
        }

        private void _cbLatLevel_CheckedChanged(object sender, EventArgs e)
        {
            _numLatLevel.Enabled = _cbLatLevel.Checked;
        }

        private void _cbLatCoef_CheckedChanged(object sender, EventArgs e)
        {
            _numLatCoef.Enabled = _cbLatCoef.Checked;
        }

        private void ApplyFilter()
        {
            RasterImage runImage = _originalBitmap.Clone();

            try
            {

                MultiscaleEnhancementCommandType type = MultiscaleEnhancementCommandType.Gaussian;
                switch (_cbFilter.SelectedIndex)
                {
                    case 0:
                        type = MultiscaleEnhancementCommandType.Normal;
                        break;
                    case 1:
                        type = MultiscaleEnhancementCommandType.Resample;
                        break;
                    case 2:
                        type = MultiscaleEnhancementCommandType.Bicubic;
                        break;
                    case 3:
                        type = MultiscaleEnhancementCommandType.Gaussian;
                        break;
                }
                MultiscaleEnhancementCommandFlags flags = MultiscaleEnhancementCommandFlags.None;
                if (_cbEdge.Checked)
                    flags |= MultiscaleEnhancementCommandFlags.EdgeEnhancement;
                if (_cbLatitude.Checked)
                    flags |= MultiscaleEnhancementCommandFlags.LatitudeReduction;

                MultiscaleEnhancementCommand command = new MultiscaleEnhancementCommand(
                   Convert.ToInt32(_numContrast.Value * 100),
                   (_cbEdgeLevel.Checked) ? Convert.ToInt32(_numEdgeLevel.Value) : -1,
                   (_cbEdgeCoef.Checked) ? Convert.ToInt32(_numEdgeCoef.Value * 100) : -1,
                   (_cbLatLevel.Checked) ? Convert.ToInt32(_numLatLevel.Value) : -1,
                   (_cbLatCoef.Checked) ? Convert.ToInt32(_numLatCoef.Value * 100) : -1,
                   type,
                   flags);

                command.Run(runImage);

                _viewer.Image = runImage;
            }
            catch (System.Exception ex)
            {
                Messager.ShowError(this, ex);
            }
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            _viewer.Image = _originalBitmap.Clone();
            this.Close();
        }

        private void _btnApply_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void MultiscaleEnhancementDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_originalBitmap != null)
                _originalBitmap.Dispose();
        }
    }
}
