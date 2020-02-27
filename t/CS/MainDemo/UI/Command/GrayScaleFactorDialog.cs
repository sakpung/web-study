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

using Leadtools.Demos;
using Leadtools.ImageProcessing.Color;

namespace MainDemo
{
   public partial class GrayScaleFactorDialog : Form
   {
      private static bool _firstTimer = true;
      private static int _initialRedFactor;
      private static int _initialGreenFactor;
      private static int _initialBlueFactor;

      public int RedFactor;
      public int GreenFactor;
      public int BlueFactor;


      public GrayScaleFactorDialog( )
      {
         InitializeComponent();
      }

      private void GrayScaleFactorDialog_Load(object sender, System.EventArgs e)
      {
         if(_firstTimer)
         {
            _firstTimer = false;
            GrayScaleExtendedCommand command = new GrayScaleExtendedCommand();
            _initialRedFactor = command.RedFactor;
            _initialGreenFactor = command.GreenFactor;
            _initialBlueFactor = command.BlueFactor;
         }

         RedFactor = _initialRedFactor;
         GreenFactor = _initialGreenFactor;
         BlueFactor = _initialBlueFactor;

         DialogUtilities.SetNumericValue(_numRed, RedFactor);
         DialogUtilities.SetNumericValue(_numGreen, GreenFactor);
         DialogUtilities.SetNumericValue(_numBlue, BlueFactor);
      }

      private void _num_Leave(object sender, System.EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         if((_numRed.Value + _numGreen.Value + _numBlue.Value) > 1000)
         {
            Messager.ShowWarning(this, _lblMsg.Text);
            DialogResult = DialogResult.None;
            return;
         }

         RedFactor = (int)_numRed.Value;
         GreenFactor = (int)_numGreen.Value;
         BlueFactor = (int)_numBlue.Value;

         _initialRedFactor = RedFactor;
         _initialGreenFactor = GreenFactor;
         _initialBlueFactor = BlueFactor;
      }
   }
}
