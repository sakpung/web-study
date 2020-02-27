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
using Leadtools.ImageProcessing.Effects;
using Leadtools.ImageProcessing.Color;

namespace GrayScaleDemo
{
    public partial class BackgroundRemovalDialog : Form
    {
        private RasterImage _originalBitmap;
        private int _windowCenter;
        private int _windowWidth;
        private ImageViewer _viewer;
        private ViewerForm _form;
        private MainForm _mainForm;

        public BackgroundRemovalDialog(MainForm mainForm, ViewerForm form, bool invert)
        {
            InitializeComponent();

            _mainForm = mainForm;
            //cell.Image.Page = cell.ActiveSubCell + 1;
            _form = form;
            _viewer = form.Viewer;

            _cbInvert.Checked = invert;

            _windowCenter = _form.WindowLevelCenter;
            _windowWidth = _form.WindowLevelWidth;

            _originalBitmap = _viewer.Image.Clone();

            int uMaxLevels = Math.Max(form.Image.Width, form.Image.Height);

            int nRangeMax = (int)Math.Ceiling(Math.Log(uMaxLevels) / Math.Log(2.0));

            _numEdgeLevel.Maximum = new decimal(nRangeMax);
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

        private void ApplyFilter()
        {
            try
            {
                RasterImage runImage = _originalBitmap.Clone();

                if (_cbInvert.Checked)
                {
                    runImage.UseLookupTable = false;
                    InvertCommand invComd = new InvertCommand();
                    invComd.Run(runImage);
                }

                BackGroundRemovalCommand backgroundRemovalCommand = new BackGroundRemovalCommand(Convert.ToInt32(_numRemovalFactor.Value));
                backgroundRemovalCommand.Run(runImage);

                MinMaxValuesCommand minMaxCmd = new MinMaxValuesCommand();
                minMaxCmd.Run(runImage);
                int min = minMaxCmd.MinimumValue;
                int max = minMaxCmd.MaximumValue;

                if (_cbEnableEnhancements.Checked)
                {
                    AverageCommand avrcmd = new AverageCommand();
                    avrcmd.Dimension = 5;
                    avrcmd.Run(runImage);

                    MultiscaleEnhancementCommand MSECommand = new MultiscaleEnhancementCommand();
                    MSECommand.Contrast = Convert.ToInt32(_numContrast.Value * 100);
                    MSECommand.EdgeCoefficient = Convert.ToInt32(_numEdgeCoef.Value * 100);
                    MSECommand.EdgeLevels = Convert.ToInt32(_numEdgeLevel.Value);
                    MSECommand.LatitudeCoefficient = 140;
                    MSECommand.LatitudeLevels = 5;
                    MSECommand.Flags = MultiscaleEnhancementCommandFlags.EdgeEnhancement | MultiscaleEnhancementCommandFlags.LatitudeReduction;
                    MSECommand.Type = MultiscaleEnhancementCommandType.Gaussian;
                    MSECommand.Run(runImage);
                }
                else
                {
                    AverageCommand avrcmd = new AverageCommand();
                    avrcmd.Dimension = 3;
                    avrcmd.Run(runImage);
                }
                
                ApplyLinearVoiLookupTableCommand voiCmd = new ApplyLinearVoiLookupTableCommand();
                voiCmd.Center = (min + max) / 2 ;
                voiCmd.Width = max - min ;
                voiCmd.Flags = VoiLookupTableCommandFlags.UpdateMinMax;
                voiCmd.Run(runImage);

                GetLinearVoiLookupTableCommand voiLutCommand = new GetLinearVoiLookupTableCommand(GetLinearVoiLookupTableCommandFlags.None);
                voiLutCommand.Run(runImage);
                _form.WindowLevelWidth = (int)voiLutCommand.Width;
                _form.WindowLevelCenter = (int)voiLutCommand.Center;

                _viewer.Image = runImage;
            }
            catch (System.Exception /*ex*/)
            {
            	
            }
            
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            _viewer.Image = _originalBitmap.Clone();
            //_viewer.Invalidate();
            this.Close();
        }

        private void _btnApply_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void BackgroundRemovalDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_originalBitmap != null)
                _originalBitmap.Dispose();
        }
        
        private void _numRemovalFactor_Scroll(object sender, EventArgs e)
        {
            _txtRemovalFactor.Text = _numRemovalFactor.Value.ToString();
        }

        private void _cbEnableEnhancements_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            _numContrast.Enabled = cb.Checked;
            _numEdgeLevel.Enabled = cb.Checked;
            _numEdgeCoef.Enabled = cb.Checked;
        }
    }
}
