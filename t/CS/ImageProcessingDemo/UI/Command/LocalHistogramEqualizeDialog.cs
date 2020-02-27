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
using Leadtools.ImageProcessing.Color;
using Leadtools.Demos;

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the LocalHistogramEqualizeCommand

   public partial class LocalHistogramEqualizeDialog : Form
   {
      private LocalHistogramEqualizeCommand _LocalHistogramEqualizeCommand;
      private int _MaxWidth, _MaxHeight;

      public LocalHistogramEqualizeDialog(RasterImage TempImage)
      {
         InitializeComponent();
         _LocalHistogramEqualizeCommand = new LocalHistogramEqualizeCommand();
         _MaxWidth = TempImage.Width;
         _MaxHeight = TempImage.Height;

         //Set command default values
         InitializeUI();
      }

      public LocalHistogramEqualizeCommand LocalHistogramEqualizeCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _LocalHistogramEqualizeCommand;
         }
         set
         {
            _LocalHistogramEqualizeCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {
         string[] names;
         names = Enum.GetNames(typeof(HistogramEqualizeType));
         foreach (string name in names)
         {
            if (name != "None")
               _cmbColorSpace.Items.Add(name);
         }
         _cmbColorSpace.SelectedIndex = 0;

         _numWidth.Maximum = _MaxWidth;
         _tbWidth.Maximum = _MaxWidth;
         _numWidth.Value = _MaxWidth;
         _tbWidth.Value = _MaxWidth;


         _numHeight.Maximum = _MaxHeight;
         _tbHeight.Maximum = _MaxHeight;
         _numHeight.Value = _MaxHeight;
         _tbHeight.Value = _MaxHeight;


         _numWidthExtension.Maximum = _MaxWidth;
         _tbWidthExtension.Maximum = _MaxWidth;

         _numHeightExtension.Maximum = _MaxHeight;
         _tbHeightExtension.Maximum = _MaxHeight;
      }

      private void UpdateCommand()
      {

         _LocalHistogramEqualizeCommand.Width = Convert.ToInt32(_numWidth.Value);
         _LocalHistogramEqualizeCommand.Height = Convert.ToInt32(_numHeight.Value);
         _LocalHistogramEqualizeCommand.WidthExtension = Convert.ToInt32(_numWidthExtension.Value);
         _LocalHistogramEqualizeCommand.HeightExtension = Convert.ToInt32(_numHeightExtension.Value);
         _LocalHistogramEqualizeCommand.Smooth = Convert.ToInt32(_numSmooth.Value);
         _LocalHistogramEqualizeCommand.Type = TranslateType();
      }

      public HistogramEqualizeType TranslateType()
      {
         switch (_cmbColorSpace.SelectedIndex)
         {
            case 0:
               return HistogramEqualizeType.Rgb;
            case 1:
               return HistogramEqualizeType.Yuv;
            case 2:
               return HistogramEqualizeType.Gray;
            default:
               return HistogramEqualizeType.Rgb;
         }
      }

      private void _numWidth_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numHeight_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numWidthExtension_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numHeightExtension_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numSmooth_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _tbWidth_Scroll(object sender, EventArgs e)
      {
         _numWidth.Value = _tbWidth.Value;
      }

      private void _tbHeight_Scroll(object sender, EventArgs e)
      {
         _numHeight.Value = _tbHeight.Value;
      }

      private void _tbWidthExtension_Scroll(object sender, EventArgs e)
      {
         _numWidthExtension.Value = _tbWidthExtension.Value;
      }

      private void _tbHeightExtension_Scroll(object sender, EventArgs e)
      {
         _numHeightExtension.Value = _tbHeightExtension.Value;
      }

      private void _tbSmooth_Scroll(object sender, EventArgs e)
      {
         _numSmooth.Value = _tbSmooth.Value;
      }

      private void _numWidth_ValueChanged(object sender, EventArgs e)
      {
         _tbWidth.Value = Convert.ToInt32(_numWidth.Value);
      }

      private void _numHeight_ValueChanged(object sender, EventArgs e)
      {
         _tbHeight.Value = Convert.ToInt32(_numHeight.Value);
      }

      private void _numWidthExtension_ValueChanged(object sender, EventArgs e)
      {
         _tbWidthExtension.Value = Convert.ToInt32(_numWidthExtension.Value);
      }

      private void _numHeightExtension_ValueChanged(object sender, EventArgs e)
      {
         _tbHeightExtension.Value = Convert.ToInt32(_numHeightExtension.Value);
      }

      private void _numSmooth_ValueChanged(object sender, EventArgs e)
      {
         _tbSmooth.Value = Convert.ToInt32(_numSmooth.Value);
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         UpdateCommand();
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
      }
   }
}
