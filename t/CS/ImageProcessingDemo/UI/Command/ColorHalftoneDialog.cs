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
using Leadtools.Demos;
using Leadtools.ImageProcessing.Effects;

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the ColorHalftoneCommand

   public partial class ColorHalftoneDialog : Form
   {
      private ColorHalftoneCommand _ColorHalftoneCommand;
      private int _Cyan, _Magenta, _Yellow, _Black, _Radius;

      public ColorHalftoneDialog()
      {
         InitializeComponent();
         _ColorHalftoneCommand = new ColorHalftoneCommand();
         _Cyan = 108;
         _Magenta = 163;
         _Yellow = 90;
         _Black = 45;
         _Radius = 8;

         //Set command default values
         InitializeUI();
      }

      public ColorHalftoneCommand ColorHalftoneCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _ColorHalftoneCommand;
         }
         set
         {
            _ColorHalftoneCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {
         _numBlackAngle.Value = _Black;
         _numCyanAngle.Value = _Cyan;
         _numMagentaAngle.Value = _Magenta;
         _numYellowAngle.Value = _Yellow;
         _numRadius.Value = _Radius;
      }

      private void UpdateCommand()
      {
         _Black = Convert.ToInt32(_numBlackAngle.Value);
         _Cyan = Convert.ToInt32(_numCyanAngle.Value);
         _Magenta = Convert.ToInt32(_numMagentaAngle.Value);
         _Yellow = Convert.ToInt32(_numYellowAngle.Value);
         _Radius = Convert.ToInt32(_numRadius.Value);

         _ColorHalftoneCommand.BlackAngle = _Black;
         _ColorHalftoneCommand.CyanAngle = _Cyan;
         _ColorHalftoneCommand.MagentaAngle = _Magenta;
         _ColorHalftoneCommand.YellowAngle = _Yellow;
         _ColorHalftoneCommand.MaximumRadius = _Radius;

      }
      private void _numBlackAngle_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numCyanAngle_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numMagentaAngle_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numYellowAngle_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numRadius_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _tbBlackAngle_Scroll(object sender, EventArgs e)
      {
         _numBlackAngle.Value = _tbBlackAngle.Value;
      }

      private void _tbCyanAngle_Scroll(object sender, EventArgs e)
      {
         _numCyanAngle.Value = _tbCyanAngle.Value;
      }

      private void _tbMagentaAngle_Scroll(object sender, EventArgs e)
      {
         _numMagentaAngle.Value = _tbMagentaAngle.Value;
      }

      private void _tbYellowAngle_Scroll(object sender, EventArgs e)
      {
         _numYellowAngle.Value = _tbYellowAngle.Value;
      }

      private void _tbRadius_Scroll(object sender, EventArgs e)
      {
         _numRadius.Value = _tbRadius.Value;
      }

      private void _numBlackAngle_ValueChanged(object sender, EventArgs e)
      {
         _tbBlackAngle.Value = Convert.ToInt32(_numBlackAngle.Value);
      }

      private void _numCyanAngle_ValueChanged(object sender, EventArgs e)
      {
         _tbCyanAngle.Value = Convert.ToInt32(_numCyanAngle.Value);

      }

      private void _numMagentaAngle_ValueChanged(object sender, EventArgs e)
      {
         _tbMagentaAngle.Value = Convert.ToInt32(_numMagentaAngle.Value);

      }

      private void _numYellowAngle_ValueChanged(object sender, EventArgs e)
      {
         _tbYellowAngle.Value = Convert.ToInt32(_numYellowAngle.Value);

      }

      private void _numRadius_ValueChanged(object sender, EventArgs e)
      {
         _tbRadius.Value = Convert.ToInt32(_numRadius.Value);
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
