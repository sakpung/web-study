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

using Leadtools;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Color;
using Leadtools.Drawing;

namespace MainDemo
{
   public partial class BalanceColorsDialog : Form
   {
      private ImagePreviewCtrl _beforeViewer;
      private ImagePreviewCtrl _afterViewer;
      private RasterImage _originalImage;
      private RasterImage _afterImage;
      private BalanceColorCommandFactor _redWeights;
      private BalanceColorCommandFactor _greenWeights;
      private BalanceColorCommandFactor _blueWeights;
      private BalanceColorCommandFactor _internalRedWeights;
      private BalanceColorCommandFactor _internalGreenWeights;
      private BalanceColorCommandFactor _internalBlueWeights;

      public BalanceColorCommandFactor RedWeights
      {
         set
         {
            _redWeights = value;
         }
         get
         {
            return _redWeights;
         }
      }

      public BalanceColorCommandFactor GreenWeights
      {
         set
         {
            _greenWeights = value;
         }
         get
         {
            return _greenWeights;
         }
      }

      public BalanceColorCommandFactor BlueWeights
      {
         set
         {
            _blueWeights = value;
         }
         get
         {
            return _blueWeights;
         }
      }

      public BalanceColorsDialog(RasterImage image, RasterPaintProperties paintProperties)
      {
         try
         {
            InitializeComponent();

            if (image != null)
            {
               CloneCommand clone = new CloneCommand();

               clone.Run(image);

               _originalImage = image;
               _afterImage = clone.DestinationImage;

               _beforeViewer = new ImagePreviewCtrl(_originalImage, paintProperties, _lblBefore.Location, _lblBefore.Size);
               _afterViewer = new ImagePreviewCtrl(_afterImage, paintProperties, _lblAfter.Location, _lblAfter.Size);

               Controls.Add(_beforeViewer);
               Controls.Add(_afterViewer);
               _beforeViewer.BringToFront();
               _afterViewer.BringToFront();

               _beforeViewer.PanImage += new EventHandler<PanImageEvent>(_beforeViewer_PanImage);
               _afterViewer.PanImage += new EventHandler<PanImageEvent>(_afterViewer_PanImage);
            }
            else
            {
               _tsZoomLevel.Visible = false;
            }

            _redWeights = new BalanceColorCommandFactor();
            _greenWeights = new BalanceColorCommandFactor();
            _blueWeights = new BalanceColorCommandFactor();
            _internalRedWeights = new BalanceColorCommandFactor();
            _internalGreenWeights = new BalanceColorCommandFactor();
            _internalBlueWeights = new BalanceColorCommandFactor();
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      void _beforeViewer_PanImage(object sender, PanImageEvent e)
      {
         _afterViewer.OffsetImage(e.Offset);
      }

      void _afterViewer_PanImage(object sender, PanImageEvent e)
      {
         _beforeViewer.OffsetImage(e.Offset);
      }

      protected void UpdateValues()
      {
         try
         {
            RasterImage tempImage;
            CloneCommand clone = new CloneCommand();

            clone.Run(_originalImage);

            tempImage = clone.DestinationImage;

            if (DoEffect(ref tempImage))
            {
               if (_afterImage != null)
               {
                  _afterImage.Dispose();

                  _afterImage = null;
               }

               _afterImage = tempImage;

               _afterViewer.Image = _afterImage;

               _afterViewer.OffsetImage(_beforeViewer.Offset);

               _afterViewer.Invalidate();
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      protected virtual bool DoEffect(ref RasterImage effectedImage)
      {
         try
         {
            BalanceColorsCommand command = new BalanceColorsCommand(_internalRedWeights,
                                                                    _internalGreenWeights,
                                                                    _internalBlueWeights);

            command.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);

            if (RasterImageChangedFlags.None == command.Run(effectedImage))
            {
               return false;
            }

            //Reset progress bar
            _pbProgress.Value = 0;

            return true;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      void command_Progress(object sender, RasterCommandProgressEventArgs e)
      {
         _pbProgress.Value = e.Percent;
      }

      private void _tsbtnNormal_Click(object sender, EventArgs e)
      {
         try
         {
            if (_beforeViewer.Image != null)
            {
               _tsbtnFit.Checked = false;
               _tsbtnNormal.Checked = true;

               _beforeViewer.FitView = false;
               _afterViewer.FitView = false;
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      private void _tsbtnFit_Click(object sender, EventArgs e)
      {
         try
         {
            if (_beforeViewer.Image != null)
            {
               _tsbtnFit.Checked = true;
               _tsbtnNormal.Checked = false;

               _beforeViewer.FitView = true;
               _afterViewer.FitView = true;

            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      private void BalanceColorsDialog_Load(object sender, EventArgs e)
      {
         try
         {
            if (_beforeViewer.Image != null)
            {
               _tsbtnFit.Checked = false;
               _tsbtnNormal.Checked = true;
            }

            _internalRedWeights = RedWeights;
            _internalGreenWeights = GreenWeights;
            _internalBlueWeights = BlueWeights;

            _numRedinRedWeight.Value = (decimal)_internalRedWeights.ToRed * 100;
            _numGreeninRedWeight.Value = (decimal)_internalRedWeights.ToGreen * 100;
            _numBlueinRedWeight.Value = (decimal)_internalBlueWeights.ToRed * 100;

            _numRedinGreenWeight.Value = (decimal)_internalGreenWeights.ToRed * 100;
            _numGreeninGreenWeight.Value = (decimal)_internalGreenWeights.ToGreen * 100;
            _numBlueinGreenWeight.Value = (decimal)_internalBlueWeights.ToRed * 100;

            _numRedinBlueWeight.Value = (decimal)_internalBlueWeights.ToRed * 100;
            _numGreeninBlueWeight.Value = (decimal)_internalBlueWeights.ToGreen * 100;
            _numBlueinBlueWeight.Value = (decimal)_internalBlueWeights.ToRed * 100;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      private void RedWeights_Leave(object sender, System.EventArgs e)
      {
         try
         {
            if (GetUpdatedRedWeights())
            {
               UpdateValues();
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      void RedWeights_ValueChanged(object sender, System.EventArgs e)
      {
         try
         {
            if (GetUpdatedRedWeights())
            {
               UpdateValues();
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      private void GreenWeights_Leave(object sender, System.EventArgs e)
      {
         try
         {
            if (GetUpdatedGreenWeights())
            {
               UpdateValues();
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      void GreenWeights_ValueChanged(object sender, System.EventArgs e)
      {
         try
         {
            if (GetUpdatedGreenWeights())
            {
               UpdateValues();
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      private void BlueWeights_Leave(object sender, System.EventArgs e)
      {
         try
         {
            if (GetUpdatedBlueWeights())
            {
               UpdateValues();
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      void BlueWeights_ValueChanged(object sender, System.EventArgs e)
      {
         try
         {
            if (GetUpdatedBlueWeights())
            {
               UpdateValues();
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         try
         {
            RedWeights = _internalRedWeights;
            GreenWeights = _internalGreenWeights;
            BlueWeights = _internalBlueWeights;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      private bool GetUpdatedRedWeights()
      {
         try
         {
            bool valuesUpdated = false;

            if (_internalRedWeights.ToRed != (double)(_numRedinRedWeight.Value / 100))
            {
               _internalRedWeights.ToRed = (double)(_numRedinRedWeight.Value / 100);

               valuesUpdated = true;
            }

            if (_internalRedWeights.ToGreen != (double)(_numGreeninRedWeight.Value / 100))
            {
               _internalRedWeights.ToGreen = (double)(_numGreeninRedWeight.Value / 100);

               valuesUpdated = true;
            }

            if (_internalRedWeights.ToBlue != (double)(_numBlueinRedWeight.Value / 100))
            {
               _internalRedWeights.ToBlue = (double)(_numBlueinRedWeight.Value / 100);

               valuesUpdated = true;
            }

            return valuesUpdated;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      private bool GetUpdatedGreenWeights()
      {
         try
         {
            bool valuesUpdated = false;

            if (_internalGreenWeights.ToRed != (double)(_numRedinGreenWeight.Value / 100))
            {
               _internalGreenWeights.ToRed = (double)(_numRedinGreenWeight.Value / 100);

               valuesUpdated = true;
            }

            if (_internalGreenWeights.ToGreen != (double)(_numGreeninGreenWeight.Value / 100))
            {
               _internalGreenWeights.ToGreen = (double)(_numGreeninGreenWeight.Value / 100);

               valuesUpdated = true;
            }

            if (_internalGreenWeights.ToBlue != (double)(_numBlueinGreenWeight.Value / 100))
            {
               _internalGreenWeights.ToBlue = (double)(_numBlueinGreenWeight.Value / 100);

               valuesUpdated = true;
            }

            return valuesUpdated;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      private bool GetUpdatedBlueWeights()
      {
         try
         {
            bool valuesUpdated = false;

            if (_internalBlueWeights.ToRed != (double)(_numRedinBlueWeight.Value / 100))
            {
               _internalBlueWeights.ToRed = (double)(_numRedinBlueWeight.Value / 100);

               valuesUpdated = true;
            }

            if (_internalBlueWeights.ToGreen != (double)(_numGreeninBlueWeight.Value / 100))
            {
               _internalBlueWeights.ToGreen = (double)(_numGreeninBlueWeight.Value / 100);

               valuesUpdated = true;
            }

            if (_internalBlueWeights.ToBlue != (double)(_numBlueinBlueWeight.Value / 100))
            {
               _internalBlueWeights.ToBlue = (double)(_numBlueinBlueWeight.Value / 100);

               valuesUpdated = true;
            }

            return valuesUpdated;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }
   }
}

