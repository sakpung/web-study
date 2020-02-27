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
using Leadtools.Medical3D;
using Leadtools.MedicalViewer;

namespace Main3DDemo
{
    public partial class SeriesTreatmentDialog : Form
    {
       private MedicalViewer _control;
       private int _maxDimensionAllowed;
       private int _width;
       private int _height;
       private MainForm _mainForm;
       private RasterImage _image;
       private Medical3DObject _object;


       private bool CheckCropParameterValidity()
       {
          if (!groupBox2.Enabled)
             return true;

          int value = _txtCropHeightTo.Value - _txtCropHeightFrom.Value;
          if (value < 2 || value > _maxDimensionAllowed)
             return false;

          value = _txtCropWidthTo.Value - _txtCropWidthFrom.Value;
          if (value < 2 || value > _maxDimensionAllowed)
             return false;

          value = _txtCropHeightTo.Value - _txtCropHeightFrom.Value;
          if (value < 2 || value > _maxDimensionAllowed)
             return false;

          value = _txtCropWidthTo.Value - _txtCropWidthFrom.Value;
          if (value < 2 || value > _maxDimensionAllowed)
             return false;

          return true;
       }

       public SeriesTreatmentDialog()
       {
          InitializeComponent();
       }

       public SeriesTreatmentDialog(Medical3DObject medical3DObject, MainForm mainForm, MedicalViewer control, int maxDimensionAllowed, int width, int height, RasterImage imageSeries)
       {
          InitializeComponent();
          
          _object = medical3DObject;
          _control = control;
          _maxDimensionAllowed = maxDimensionAllowed;
          _mainForm = mainForm;
          _width = width;
          _height = height;
          _image = imageSeries;

          _txtWidth.MinimumAllowed = 1;
          _txtHeight.MinimumAllowed = 1;
          _txtWidth.MaximumAllowed = maxDimensionAllowed;
          _txtHeight.MaximumAllowed = maxDimensionAllowed;

          _txtCropHeightFrom.MinimumAllowed = 0;
          _txtCropHeightTo.MinimumAllowed = 0;
          _txtCropWidthFrom.MinimumAllowed = 0;
          _txtCropWidthTo.MinimumAllowed = 0;

          _txtCropHeightFrom.MaximumAllowed = height;
          _txtCropHeightTo.MaximumAllowed = height;
          _txtCropWidthFrom.MaximumAllowed = width;
          _txtCropWidthTo.MaximumAllowed = width;

          _txtWidth.Value = maxDimensionAllowed;
          _txtHeight.Value = maxDimensionAllowed;

          _txtCropHeightFrom.Value = Math.Max(0, Math.Min(height, (height - maxDimensionAllowed) / 2));
          _txtCropHeightTo.Value = Math.Max(0, Math.Min(height, (height + maxDimensionAllowed) / 2));
          _txtCropWidthFrom.Value  = Math.Max(0, Math.Min(width, (width - maxDimensionAllowed) / 2));
          _txtCropWidthTo.Value = Math.Max(0, Math.Min(width, (width + maxDimensionAllowed) / 2));

          _lblFramesInfo.Text = "The series you are trying to load consist of frames with dimensions " + width + " X " + height + " which larger than what the current graphics card could handle (" + maxDimensionAllowed + " X " + maxDimensionAllowed + ")";
          groupResize.Enabled = false;

       }

       private void _btnOK_Click(object sender, EventArgs e)
       {
          if (radioResize.Checked)
          {
             if (_txtWidth.Value < 32)
             {
                if (_width > 32)
                {
                   MessageBox.Show("Width is too small, Must be at least 32");
                   return;
                }
             }

             if (_txtHeight.Value < 32)
             {
                if (_height > 32)
                {
                   MessageBox.Show("Height is too small, Must be at least 32");
                   return;
                }
             }


             int i;
             SizeCommand sizeCommand = new SizeCommand(_txtWidth.Value, _txtHeight.Value, RasterSizeFlags.Resample);
             GrayscaleCommand grayCommand = new GrayscaleCommand(8);
             int oldWidth = _image.Width;
             int oldHeight =_image.Height;
             for (i = 1; i <= _image.PageCount; i++)
             {
                _image.Page = i;
                grayCommand.Run(_image);
                sizeCommand.Run(_image);
             }

             _object.VoxelSpacing = new Medical3DPoint(_object.VoxelSpacing.X * oldWidth / _txtWidth.Value, _object.VoxelSpacing.Y * oldHeight / _txtHeight.Value, _object.VoxelSpacing.Z);
          }
          else
          {
             if (Math.Abs(_txtCropWidthTo.Value - _txtCropWidthFrom.Value) < 32)
             {
                if (_width > 32)
                {
                   MessageBox.Show("Width is too small, Must be at least 32");
                   return;
                }
             }

             if (_txtHeight.Value < 32)
             {
                if (_height > 32)
                {
                   MessageBox.Show("Height is too small, Must be at least 32");
                   return;
                }
             }

             if (Math.Abs(_txtCropHeightTo.Value - _txtCropHeightFrom.Value) < 32)
             {
                MessageBox.Show("Height is too small, Must be at least 32");
                return;
             }

             int i;
             CropCommand cropCommand = new CropCommand(new Rectangle(_txtCropWidthFrom.Value, _txtCropHeightFrom.Value, _txtCropWidthTo.Value - _txtCropWidthFrom.Value, _txtCropHeightTo.Value - _txtCropHeightFrom.Value));
             GrayscaleCommand grayCommand = new GrayscaleCommand(8);
             for (i = 1; i <= _image.PageCount; i++)
             {
                _image.Page = i;
                grayCommand.Run(_image);
                cropCommand.Run(_image);
             }

             _object.FirstPosition = new Medical3DPoint(_object.FirstPosition.X + _object.ImageOrientation[0] * _txtCropWidthFrom.Value + _object.ImageOrientation[3] * _txtCropHeightFrom.Value,
                                                        _object.FirstPosition.Y + _object.ImageOrientation[1] * _txtCropWidthFrom.Value + _object.ImageOrientation[4] * _txtCropHeightFrom.Value,
                                                        _object.FirstPosition.Z + _object.ImageOrientation[2] * _txtCropWidthFrom.Value + _object.ImageOrientation[5] * _txtCropHeightFrom.Value);

             _object.SecondPosition = new Medical3DPoint(_object.SecondPosition.X + _object.ImageOrientation[0] * _txtCropWidthFrom.Value + _object.ImageOrientation[3] * _txtCropHeightFrom.Value,
                                                         _object.SecondPosition.Y + _object.ImageOrientation[1] * _txtCropWidthFrom.Value + _object.ImageOrientation[4] * _txtCropHeightFrom.Value,
                                                         _object.SecondPosition.Z + _object.ImageOrientation[2] * _txtCropWidthFrom.Value + _object.ImageOrientation[5] * _txtCropHeightFrom.Value);
          }
          this.DialogResult = DialogResult.OK;
          this.Close();
       }

       private void radioResize_CheckedChanged(object sender, EventArgs e)
       {
          groupResize.Enabled = radioResize.Checked;
          groupBox2.Enabled = !radioResize.Checked;
          _btnOK.Enabled = true;
       }

       private void radioCrop_CheckedChanged(object sender, EventArgs e)
       {
          groupResize.Enabled = !radioCrop.Checked;
          groupBox2.Enabled = radioCrop.Checked;
          _btnOK.Enabled = CheckCropParameterValidity();
       }

       private void _txtCropWidthFrom_TextChanged(object sender, EventArgs e)
       {
          _btnOK.Enabled = CheckCropParameterValidity();
       }

       private void _txtCropWidthTo_TextChanged(object sender, EventArgs e)
       {
          _btnOK.Enabled = CheckCropParameterValidity();
       }

       private void _txtCropHeightFrom_TextChanged(object sender, EventArgs e)
       {
          _btnOK.Enabled = CheckCropParameterValidity();
       }

       private void _txtCropHeightTo_TextChanged(object sender, EventArgs e)
       {
          _btnOK.Enabled = CheckCropParameterValidity();

       }

       private void _txtHeight_TextChanged(object sender, EventArgs e)
       {
          _btnOK.Enabled = CheckCropParameterValidity();
       }

       private void _txtWidth_TextChanged(object sender, EventArgs e)
       {
          _btnOK.Enabled = CheckCropParameterValidity();
       }
   }
}



//L_VOID AdjustCropImagePosition( UINT CropFromLeft, UINT CropFromTop,

//                                D3DXVECTOR3 ImagePosi,

//                                D3DXVECTOR3 OrientX, D3DXVECTOR3 OrientY,

//                                D3DXVECTOR3 *NewImagePosi )

//{

//}

 

//For resize:-

//L_VOID AdjustResizeImagePosition( float ResizeRatio, float OldFX, float OldFY, float *NewFX, float *NewFY)

//{

//   *NewFX = OldFX / ResizeRation ;

//   *NewFY = OldFY / ResizeRation ;

//}
