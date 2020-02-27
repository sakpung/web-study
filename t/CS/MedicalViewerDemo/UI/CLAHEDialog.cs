// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Leadtools.ImageProcessing.Core;
using Leadtools;
using Leadtools.MedicalViewer;
using Leadtools.Demos;

namespace MedicalViewerDemo
{
    public partial class CLAHEDialog : Form
    {
       private bool _firstTime;
       private RasterImage _originalBitmap;
       private MainForm _mainForm;
       private MedicalViewerMultiCell _cell;
       private int _oldWindowWidth;
       private int _oldWindowCenter;
       private CLAHECommand _command;

       public CLAHEDialog(MainForm mainForm, MedicalViewerCell cell)
       {
          _mainForm = mainForm;
          _cell = (MedicalViewerMultiCell)cell;
          _command = new CLAHECommand();

          InitializeComponent();

          _firstTime = true;

          _cbFlags.SelectedIndex = 0;
          _cbBinsNumber.SelectedIndex = 6;
          
          _numAlpha.Value = (decimal)_command.AlphaFactor;
          _numTilesNumber.Value = (decimal)_command.TilesNumber;
          _numClipLimit.Value = (decimal)_command.TileHistClipLimit;

          _oldWindowWidth = _cell.GetWindowLevelWidth();
          _oldWindowCenter = _cell.GetWindowLevelCenter();

          switch (_command.Flags)
          {
             case CLAHECommandFlags.ApplyNormalDistribution:
                _cbFlags.SelectedIndex = 0;
                break;
             case CLAHECommandFlags.ApplyExponentialDistribution:
                _cbFlags.SelectedIndex = 1;
                break;
             case CLAHECommandFlags.ApplyRayliehDistribution:
                _cbFlags.SelectedIndex = 2;
                break;
             case CLAHECommandFlags.ApplySigmoidDistribution:
                _cbFlags.SelectedIndex = 3;
                break;
          }
       }
                
        private void _cbFlags_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (_cbFlags.SelectedIndex)
            {
                case 0:
                    _numAlpha.Enabled = false;
                    _command.Flags = CLAHECommandFlags.ApplyNormalDistribution;
                    break;
                case 1:
                    _command.Flags = CLAHECommandFlags.ApplyExponentialDistribution;
                    _numAlpha.Enabled = true;
                    _numAlpha.Maximum = 1.0m;
                    break;
                case 2:
                    _command.Flags = CLAHECommandFlags.ApplyRayliehDistribution;
                    _numAlpha.Enabled = true;
                    _numAlpha.Maximum = 1.0m;
                    break;
                case 3:
                    _command.Flags = CLAHECommandFlags.ApplySigmoidDistribution;
                    _numAlpha.Enabled = true;
                    _numAlpha.Maximum = 5.0m;
                    break;
            }
        }
        
        private void _btnApply_Click(object sender, EventArgs e)
        {
           _mainForm.FilterApply_Click(ref _firstTime, ref _originalBitmap, ApplyFilter);  
        }

        private void _numAlpha_ValueChanged(object sender, EventArgs e)
        {
           _command.AlphaFactor = (float)_numAlpha.Value;
        }

        private void CLAHEDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
           if (_originalBitmap != null)
              _originalBitmap.Dispose();
        }

        private void _numTilesNumber_ValueChanged(object sender, EventArgs e)
        {
           _command.TilesNumber = (int)_numTilesNumber.Value;
        }

        private void _numClipLimit_ValueChanged(object sender, EventArgs e)
        {
           _command.TileHistClipLimit = (float)_numClipLimit.Value;
        }

        private void _cbBinsNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
           _command.BinNumber = int.Parse(_cbBinsNumber.Text);
        }

        private void _btnOK_Click(object sender, EventArgs e)
        {
           _mainForm.FilterOk_Click(_originalBitmap, _firstTime, ApplyFilter);
        }

        private void ApplyFilter()
        {
           _mainForm.FilterRunCommand(_command, false, false);

           if (_cell.Image.BitsPerPixel == 16)
           {
              int orignalPage = _cell.Image.Page;
              _cell.Image.Page = _cell.ActiveSubCell + 1;

              GetLinearVoiLookupTableCommand voiLut = new GetLinearVoiLookupTableCommand();
              voiLut.Run(_cell.Image);

              _cell.Image.Page = orignalPage;

              _cell.SetWindowLevel(_cell.ActiveSubCell, (int)voiLut.Width, (int)voiLut.Center);
           }

           _cell.Invalidate();
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
           _mainForm.FilterCancel_Click(_firstTime, _originalBitmap, false);

           _cell.SetWindowLevel(_oldWindowWidth, _oldWindowCenter);
           _cell.Invalidate();
        }
    }
}
