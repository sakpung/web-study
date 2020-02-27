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
using Leadtools.ImageProcessing.Effects;

namespace DicomDemo
{
   public partial class UnsharpMaskDialog : Form
   {
      private static bool _firstTimer = true;
      private static int _initialAmount;
      private static int _initialRadius;
      private static int _initialThreshold;
      private static UnsharpMaskCommandColorType _initialColorSpace;

      public int Amount;
      public int Radius;
      public int Threshold;
      public UnsharpMaskCommandColorType ColorSpace;

      public UnsharpMaskDialog( )
      {
         InitializeComponent();
      }

      private void UnsharpMaskDialog_Load(object sender, System.EventArgs e)
      {
         if(_firstTimer)
         {
            _firstTimer = false;
            UnsharpMaskCommand command = new UnsharpMaskCommand();
            _initialAmount = command.Amount;
            _initialRadius = command.Radius;
            _initialThreshold = command.Threshold;
            _initialColorSpace = command.ColorType;
         }

         Amount = _initialAmount;
         Radius = _initialRadius;
         Threshold = _initialThreshold;
         ColorSpace = _initialColorSpace;

         _numAmount.Value = Amount;
         _numRadius.Value = Radius;
         _numThreshold.Value = Threshold;

         _cbColorSpace.Items.AddRange(Enum.GetNames(typeof(UnsharpMaskCommandColorType)));
         _cbColorSpace.Items.RemoveAt(0);
         _cbColorSpace.SelectedIndex = 0;
      }

      private void _num_Leave(object sender, System.EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         Amount = (int)_numAmount.Value;
         Radius = (int)_numRadius.Value;
         Threshold = (int)_numThreshold.Value;

         ColorSpace = (UnsharpMaskCommandColorType)Enum.Parse(typeof(UnsharpMaskCommandColorType), (string)_cbColorSpace.SelectedItem);

         _initialAmount = Amount;
         _initialRadius = Radius;
         _initialThreshold = Threshold;
         _initialColorSpace = ColorSpace;
      }
   }
}
