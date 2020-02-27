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
   public partial class SaturationDialog : Form
   {
      private ImagePreviewCtrl _beforeViewer;
      private ImagePreviewCtrl _afterViewer;
      private RasterImage _originalImage;
      private RasterImage _afterImage;
      private int _internalSaturationValue;
      private int _saturation;

      public int Saturation
      {
         set
         {
            _saturation = value;
         }
         get
         {
            return _saturation;
         }
      }

      public SaturationDialog(RasterImage image, RasterPaintProperties paintProperties)
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

            _internalSaturationValue = 0;
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
            ChangeSaturationCommand command = new ChangeSaturationCommand(_internalSaturationValue);

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

      private void SaturationDialog_Load(object sender, EventArgs e)
      {
         try
         {
            if (_beforeViewer.Image != null)
            {
               _tsbtnFit.Checked = false;
               _tsbtnNormal.Checked = true;
            }

            _internalSaturationValue = Saturation;

            if ((_internalSaturationValue / 10) < _numValue.Minimum)
            {
               _internalSaturationValue = Saturation = (int)_numValue.Minimum;
            }

            if ((_internalSaturationValue / 10) > _numValue.Maximum)
            {
               _internalSaturationValue = Saturation = (int)_numValue.Maximum;
            }

            _numValue.Value = _internalSaturationValue / 10;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      private void _num_Leave(object sender, System.EventArgs e)
      {
         try
         {
            if (_numValue.Value < _numValue.Minimum)
            {
               _numValue.Value = _numValue.Minimum;
            }
            else if (_numValue.Value > _numValue.Maximum)
            {
               _numValue.Value = _numValue.Maximum;
            }

            _internalSaturationValue = (int)_numValue.Value * 10;

            UpdateValues();
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      void _numValue_ValueChanged(object sender, System.EventArgs e)
      {
         try
         {
            _internalSaturationValue = (int)_numValue.Value * 10;

            UpdateValues();
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
            Saturation = _internalSaturationValue;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }
   }
}

