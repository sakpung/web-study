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
using Leadtools;

namespace MainDemo
{
   public partial class EdgeDetectorDialog : Form
   {
      private static bool _firstTimer = true;
      private static int _initialThreshold = 255;
      private static EdgeDetectorCommandType _initialFilter = EdgeDetectorCommandType.SobelVertical;
      private int _bitsPerPixel;
      private RasterImage _image;

      public int Threshold;
      public EdgeDetectorCommandType Filter;

      public EdgeDetectorDialog(RasterImage image)
      {
         InitializeComponent();

         _bitsPerPixel = image.BitsPerPixel;
         _image = image;
      }

      private void EdgeDetectorDialog_Load(object sender, System.EventArgs e)
      {
         if(_firstTimer)
         {
            _firstTimer = false;
            EdgeDetectorCommand command = new EdgeDetectorCommand();
            _initialThreshold = command.Threshold;
            _initialFilter = command.Filter;
         }

         Threshold = _initialThreshold;
         Filter = _initialFilter;

         Tools.FillComboBoxWithEnum(_cbFilter, typeof(EdgeDetectorCommandType), Filter);

         switch(_bitsPerPixel)
         {
            case 12:
               _numThreshold.Maximum = 4095;
               break;

            case 16:
            case 48:
            case 64:
               _numThreshold.Maximum = 65535;
               break;

            default:
               _numThreshold.Maximum = 255;
               break;
         }

         if (_image.Signed)
         {
            _numThreshold.Maximum /= 2;
            _numThreshold.Minimum = -_numThreshold.Maximum;
         }


         DialogUtilities.SetNumericValue(_numThreshold, Threshold);
      }

      private void _num_Leave(object sender, System.EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         Threshold = (int)_numThreshold.Value;

         Filter = (EdgeDetectorCommandType)Constants.GetValueFromName(
            typeof(EdgeDetectorCommandType),
            (string)_cbFilter.SelectedItem,
            _initialFilter);

         _initialThreshold = Threshold;
         _initialFilter = Filter;
      }
   }
}
