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

namespace MainDemo
{
   public partial class AntiAliasDialog : Form
   {
      private static bool _firstTimer = true;
      private static int _initialThreshold;
      private static int _initialDimension;
      private static AntiAliasingCommandType _initialFilter;

      public int Threshold;
      public int Dimension;
      public AntiAliasingCommandType Filter;

      public AntiAliasDialog(int bitsPerPixel)
      {
         InitializeComponent();

         _numDimension.Minimum = 2;
         _numDimension.Maximum = 100;

         _numThreshold.Minimum = 0;
         switch(bitsPerPixel)
         {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 24:
            case 32:
               _numThreshold.Maximum = 255;
               break;
            case 12:
               _numThreshold.Maximum = 4095;
               break;
            case 48:
            case 64:
               _numThreshold.Maximum = 65535;
               break;
         }
      }

      private void AntiAliasDialog_Load(object sender, System.EventArgs e)
      {
         if(_firstTimer)
         {
            _firstTimer = false;
            AntiAliasingCommand command = new AntiAliasingCommand();
            _initialThreshold = command.Threshold;
            _initialDimension = (int)Math.Max(_numDimension.Minimum, Math.Min(_numDimension.Maximum, command.Dimension));
            _initialFilter = command.Filter;
         }


         Threshold = _initialThreshold;
         Dimension = _initialDimension;
         Filter = _initialFilter;

         Tools.FillComboBoxWithEnum(_cbFilter, typeof(AntiAliasingCommandType), Filter);

         _numThreshold.Value = Threshold;
         _numDimension.Value = Dimension;
      }

      private void _num_Leave(object sender, System.EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         Threshold = (int)_numThreshold.Value;
         Dimension = (int)_numDimension.Value;

         Filter = (AntiAliasingCommandType)Constants.GetValueFromName(
            typeof(AntiAliasingCommandType),
            (string)_cbFilter.SelectedItem,
            _initialFilter);

         _initialThreshold = Threshold;
         _initialDimension = Dimension;
         _initialFilter = Filter;
      }
   }
}
