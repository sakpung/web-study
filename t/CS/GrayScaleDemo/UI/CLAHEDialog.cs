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
using Leadtools.ImageProcessing.Core;

namespace GrayScaleDemo
{
   public partial class CLAHEDialog : Form
   {
      public float AlphaFactor ;
      public int BinNumber ;
      public CLAHECommandFlags Flags ;
      public float TileHistClipLimit ;
      public int TilesNumber ;

      public CLAHEDialog()
      {
         InitializeComponent();
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         AlphaFactor = (float)_numAlpha.Value;
         BinNumber = int.Parse(_cmbBinsNumber.Text);
         TileHistClipLimit = (float)_numClipLimit.Value;
         TilesNumber = (int)_numTiles.Value;

         switch(_cmbFlags.SelectedIndex)
         {
            case 0:
               Flags = CLAHECommandFlags.ApplyNormalDistribution;
               break;
            case 1:
               Flags = CLAHECommandFlags.ApplyExponentialDistribution;
               break;
            case 2:
               Flags = CLAHECommandFlags.ApplyRayliehDistribution;
               break;
            case 3:
               Flags = CLAHECommandFlags.ApplySigmoidDistribution;
               break;
         }

         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void CLAHEDialog_Load(object sender, EventArgs e)
      {
         _cmbFlags.SelectedIndex = 0;
         _cmbBinsNumber.SelectedIndex = 6;
         _numTiles.Value = 6;
         _numAlpha.Value = (decimal)0.65;
         _numClipLimit.Value = (decimal).080;
         _numAlpha.Enabled = false;
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }


      private void _cmbFlags_SelectedIndexChanged(object sender, EventArgs e)
      {
         switch (_cmbFlags.SelectedIndex)
         {
            case 0:
               _numAlpha.Enabled = false;
               break;
            case 1:
               _numAlpha.Enabled = true;
               _numAlpha.Maximum = 1.0m;
               break;
            case 2:
               _numAlpha.Enabled = true;
               _numAlpha.Maximum = 1.0m;
               break;
            case 3:
               _numAlpha.Enabled = true;
               _numAlpha.Maximum = 5.0m;
               break;
         }
      }


   }
}
