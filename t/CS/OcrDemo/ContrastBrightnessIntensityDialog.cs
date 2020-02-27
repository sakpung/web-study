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
using Leadtools.Controls;
using Leadtools.ImageProcessing.Color;

namespace OcrDemo
{
   public partial class ContrastBrightnessIntensityDialog : Form
   {
      private ImageViewer _viewer;
      private RasterImage _originalImage;
      private bool _saveAutoDisposeImages;

      private ContrastBrightnessIntensityCommand _command = new ContrastBrightnessIntensityCommand();
      public ContrastBrightnessIntensityCommand Command
      {
         get { return _command; }
      }

      public ContrastBrightnessIntensityDialog(ImageViewer viewer)
      {
         InitializeComponent();

         _contrastValueLabel.Text = _contrastTrackBar.Value.ToString();
         _brightnessValueLabel.Text = _brightnessTrackBar.Value.ToString();
         _intensityValueLabel.Text = _intensityTrackBar.Value.ToString();

         _viewer = viewer;

         // Make a copy of the image in viewer and save it
         _originalImage = _viewer.Image;

         // Set a copy in the viewer, this is the image we will change here
         _saveAutoDisposeImages = _viewer.AutoDisposeImages;
         _viewer.AutoDisposeImages = false;
         _viewer.Image = _originalImage.Clone();
         _viewer.AutoDisposeImages = true;

         RunCommand();
      }

      protected override void OnFormClosed(FormClosedEventArgs e)
      {
         RasterImage workImage = _viewer.Image;

         // Set the original image back
         if(workImage != _originalImage)
         {
            _viewer.AutoDisposeImages = false;
            _viewer.Image = _originalImage;
            workImage.Dispose();
         }

         _viewer.AutoDisposeImages = _saveAutoDisposeImages;

         base.OnFormClosed(e);
      }

      private void _contrastTrackBar_ValueChanged(object sender, EventArgs e)
      {
         RunCommand();
      }

      private void _brightnessTrackBar_ValueChanged(object sender, EventArgs e)
      {
         RunCommand();
      }

      private void _intensityTrackBar_ValueChanged(object sender, EventArgs e)
      {
         RunCommand();
      }

      private void RunCommand()
      {
         _command.Contrast = _contrastTrackBar.Value * 10;
         _command.Brightness = _brightnessTrackBar.Value * 10;
         _command.Intensity = _intensityTrackBar.Value * 10;

         _contrastValueLabel.Text = _command.Contrast.ToString();
         _brightnessValueLabel.Text = _command.Brightness.ToString();
         _intensityValueLabel.Text = _command.Intensity.ToString();

         _viewer.Image = _originalImage.Clone();
         _command.Run(_viewer.Image);
      }
   }
}
