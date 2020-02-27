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
using Leadtools.ImageProcessing.Core;

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the ResizeInterpolateCommand

   public partial class ResizeInterpolateDialog : Form
   {
      private ResizeInterpolateCommand _ResizeInterpolateCommand;
      private RasterImage RasImage;

      public int ImageWidth;
      public int ImageHeight;

      public ResizeInterpolateDialog()
      {
         InitializeComponent();
         _ResizeInterpolateCommand = new ResizeInterpolateCommand();
         
         //Set command default values
         InitializeUI();
      }

      public ResizeInterpolateDialog(RasterImage TempImage)
      {
         InitializeComponent();
         _ResizeInterpolateCommand = new ResizeInterpolateCommand();
         RasImage = TempImage;
         InitializeUI();
      }

      public ResizeInterpolateCommand ResizeInterpolatecommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _ResizeInterpolateCommand;
         }
         set
         {
            _ResizeInterpolateCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {

         string[] names;
         names = Enum.GetNames(typeof(ResizeInterpolateCommandType));
         foreach (string name in names)
         {
            _cmbInterpolation.Items.Add(name);
         }
         _cmbInterpolation.SelectedIndex = _cmbInterpolation.Items.IndexOf(_ResizeInterpolateCommand.ResizeType.ToString());

         ImageWidth = RasImage.Width;
         ImageHeight = RasImage.Height;

         _numWidth.Value = ImageWidth;
         _numHeight.Value = ImageHeight;
      }

      private void UpdateCommand()
      {
         ImageWidth = Convert.ToInt32(_numWidth.Value);
         ImageHeight = Convert.ToInt32(_numHeight.Value);

         _ResizeInterpolateCommand.Width = ImageWidth;
         _ResizeInterpolateCommand.Height = ImageHeight;
         _ResizeInterpolateCommand.ResizeType = TranslateDirection();
      }


      public ResizeInterpolateCommandType TranslateDirection()
      {
         switch (_cmbInterpolation.SelectedIndex)
         {
            case 0:
               return ResizeInterpolateCommandType.Normal;
            case 1:
               return ResizeInterpolateCommandType.Resample;
            case 2:
               return ResizeInterpolateCommandType.Bicubic;
            case 3:
               return ResizeInterpolateCommandType.Triangle;
            case 4:
               return ResizeInterpolateCommandType.Hermite;
            case 5:
               return ResizeInterpolateCommandType.Bell;
            case 6:
               return ResizeInterpolateCommandType.QuadraticBSpline;
            case 7:
               return ResizeInterpolateCommandType.CubicBSpline;
            case 8:
               return ResizeInterpolateCommandType.BoxFilter;
            case 9:
               return ResizeInterpolateCommandType.Lanczos;
            case 10:
               return ResizeInterpolateCommandType.Michell;
            case 11:
               return ResizeInterpolateCommandType.Cosine;
            case 12:
               return ResizeInterpolateCommandType.Catrom;
            case 13:
               return ResizeInterpolateCommandType.Quadratic;
            case 14:
               return ResizeInterpolateCommandType.CubicConvolution;
            case 15:
               return ResizeInterpolateCommandType.Bilinear;
            case 16:
               return ResizeInterpolateCommandType.Bresenham;
            default:
               return ResizeInterpolateCommandType.Normal;
         }
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         UpdateCommand();
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         InitializeUI();
         this.DialogResult = DialogResult.Cancel;
      }
   }
}
