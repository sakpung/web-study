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
using Leadtools.ImageProcessing.Effects;
using Leadtools.ImageProcessing.Core;
using Leadtools.Drawing;

namespace MainDemo
{
   public partial class MatchHistogramDialog : Form
   {
      private ImagePreviewCtrl _DSTViewer;
      private ImagePreviewCtrl _REFViewer;
      private RasterImage _originalImage;
      private RasterImage _DSTImage;
      private RasterImage _REFImage;
      List<RasterImage> _images = new List<RasterImage>();
      private int _imageIndex;

      public int ImageIndex
      {
         get
         {
            return _imageIndex;
         }
      }

      public MatchHistogramDialog(RasterImage image, RasterPaintProperties paintProperties, Form[] ViewerForms)
      {
         try
         {
            InitializeComponent();

            if (image != null)
            {
               for (int i = 0; i < ViewerForms.Length; i++)
               {
                  if ((image.BitsPerPixel == 24 && (((ViewerForm)ViewerForms[i]).Image.BitsPerPixel == 24) || ((ViewerForm)ViewerForms[i]).Image.BitsPerPixel == 8) || (image.BitsPerPixel == 8 && ((ViewerForm)ViewerForms[i]).Image.BitsPerPixel == 8))
                  {
                     _images.Add(((ViewerForm)ViewerForms[i]).Image);
                     _cmbREFImage.Items.Add(System.IO.Path.GetFileName(ViewerForms[i].Text));
                  }
               }
               _imageIndex = 0;
               _REFImage = _images[_imageIndex];
               CloneCommand clone = new CloneCommand();
               clone.Run(image);
               _originalImage = image;
               _DSTImage = clone.DestinationImage;

               _DSTViewer = new ImagePreviewCtrl(_DSTImage, paintProperties, _lblDST.Location, _lblDST.Size);
               _REFViewer = new ImagePreviewCtrl(_REFImage, paintProperties, _lblREF.Location, _lblREF.Size);

               Controls.Add(_DSTViewer);
               Controls.Add(_REFViewer);
               _DSTViewer.BringToFront();
               _REFViewer.BringToFront();

               _DSTViewer.PanImage += new EventHandler<PanImageEvent>(_beforeViewer_PanImage);
               _REFViewer.PanImage += new EventHandler<PanImageEvent>(_afterViewer_PanImage);
               _cmbREFImage.SelectedIndex = 0;
            }
            else
            {
               _tsZoomLevel.Visible = false;
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      void _beforeViewer_PanImage(object sender, PanImageEvent e)
      {
         _REFViewer.OffsetImage(e.Offset);
      }

      void _afterViewer_PanImage(object sender, PanImageEvent e)
      {
         _DSTViewer.OffsetImage(e.Offset);
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
               if (_DSTImage != null)
               {
                  _DSTImage.Dispose();

                  _DSTImage = null;
               }

               _DSTImage = tempImage;
               _DSTViewer.Image = _DSTImage;
               _DSTViewer.OffsetImage(_DSTViewer.Offset);
               _DSTViewer.Invalidate();
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
            // AutoBinarizeCommand command = new AutoBinarizeCommand();

            //command.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);

            //if (RasterImageChangedFlags.None == command.Run(effectedImage))
            //{
            //   return false;
            //}

            ////Reset progress bar
            //_pbProgress.Value = 0;

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
            if (_DSTViewer.Image != null)
            {
               _tsbtnFit.Checked = false;
               _tsbtnNormal.Checked = true;

               _DSTViewer.FitView = false;
               _REFViewer.FitView = false;
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
            if (_DSTViewer.Image != null)
            {
               _tsbtnFit.Checked = true;
               _tsbtnNormal.Checked = false;

               _DSTViewer.FitView = true;
               _REFViewer.FitView = true;
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      private void MatchHistogramDialog_Load(object sender, EventArgs e)
      {
         try
         {
            if (_DSTViewer.Image != null)
            {
               _tsbtnFit.Checked = false;
               _tsbtnNormal.Checked = true;
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      private void _cmbREFImage_SelectedIndexChanged(object sender, EventArgs e)
      {
         _REFImage = _images[_cmbREFImage.SelectedIndex];
         _REFViewer.Image = _REFImage;
         _REFViewer.OffsetImage(_DSTViewer.Offset);
         _REFViewer.Invalidate();
         UpdateValues();
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         try
         {
            _imageIndex = _cmbREFImage.SelectedIndex;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }
   }
}

