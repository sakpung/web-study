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
using Leadtools.ImageProcessing.Effects;
using Leadtools.Demos; 

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the EdgeDetectStatisticalCommand

   public partial class EdgeDetectStatisticalDialog : Form
   {
      private EdgeDetectStatisticalCommand _EdgeDetectStatisticalCommand;
      private int _Dimension, _Threshold;
      private RasterColor _EdgeColor, _BackGroundColor;

      public EdgeDetectStatisticalDialog()
      {
         InitializeComponent();
         _EdgeDetectStatisticalCommand = new EdgeDetectStatisticalCommand();
         
         //Set command default values
         InitializeUI();

      }

      public EdgeDetectStatisticalCommand EdgeDetectStatisticalCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _EdgeDetectStatisticalCommand;
         }
         set
         {
            _EdgeDetectStatisticalCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {
         _Dimension = 1;
         _Threshold = 128;

         _BackGroundColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black);
         _EdgeColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.White);

         _numDimension.Value = _Dimension;
         _numThreshold.Value = _Threshold;

         _lblBackGroundColor.BackColor = Color.Black;
         _lblEdgeColor.BackColor = Color.White;
      }
      private void UpdateCommand()
      {
         _Dimension = Convert.ToInt32(_numDimension.Value);
         _Threshold = Convert.ToInt32(_numThreshold.Value);

         _BackGroundColor = Leadtools.Demos.Converters.FromGdiPlusColor(_lblBackGroundColor.BackColor);
         _EdgeColor = Leadtools.Demos.Converters.FromGdiPlusColor(_lblEdgeColor.BackColor);

         _EdgeDetectStatisticalCommand.BackGroundColor = _BackGroundColor;
         _EdgeDetectStatisticalCommand.EdgeColor = _EdgeColor;
         _EdgeDetectStatisticalCommand.Dimension = _Dimension;
         _EdgeDetectStatisticalCommand.Threshold = _Threshold;
      }
      private void _numDimension_ValueChanged(object sender, EventArgs e)
      {
         _tbDimension.Value = Convert.ToInt32(_numDimension.Value);
      }

      private void _numThreshold_ValueChanged(object sender, EventArgs e)
      {
         _tbThreshold.Value = Convert.ToInt32(_numThreshold.Value);
      }

      private void _numDimension_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numThreshold_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _tbDimension_Scroll(object sender, EventArgs e)
      {
         _numDimension.Value = _tbDimension.Value;
      }

      private void _tbThreshold_Scroll(object sender, EventArgs e)
      {
         _numThreshold.Value = _tbThreshold.Value;
      }

      private void _BtnEdgeColor_Click(object sender, EventArgs e)
      {
         ColorDialog ColorDlg = new ColorDialog();
         if (ColorDlg.ShowDialog(this) == DialogResult.OK)
            _lblEdgeColor.BackColor = ColorDlg.Color; 
      }

      private void _BtnBackGroundColor_Click(object sender, EventArgs e)
      {
         ColorDialog ColorDlg = new ColorDialog();
         if (ColorDlg.ShowDialog(this) == DialogResult.OK)
            _lblBackGroundColor.BackColor = ColorDlg.Color;
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
