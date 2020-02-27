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
using Leadtools;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Effects;

namespace MainDemo
{
   public partial class AddNoiseDialog : Form
   {
      private static bool _firstTimer = true;
      private static int _initialRange;
      private static RasterColorChannel _initialChannel;

      public int Range;
      public RasterColorChannel Channel;

      public AddNoiseDialog( )
      {
         InitializeComponent();
      }

      private void AddNoiseDialog_Load(object sender, System.EventArgs e)
      {
         if(_firstTimer)
         {
            _firstTimer = false;
            AddNoiseCommand command = new AddNoiseCommand();
            _initialRange = command.Range;
            _initialChannel = command.Channel;
         }

         Range = _initialRange / 10;
         Channel = _initialChannel;

         _numRange.Value = Range;
         Tools.FillComboBoxWithEnum(_cbChannel, typeof(RasterColorChannel), Channel);
      }

      private void _numRange_Leave(object sender, System.EventArgs e)
      {
         DialogUtilities.NumericOnLeave(_numRange);
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         Range = (int)_numRange.Value * 10;

         Channel = (RasterColorChannel)Constants.GetValueFromName(
            typeof(RasterColorChannel),
            (string)_cbChannel.SelectedItem,
            _initialChannel);

         _initialRange = Range;
         _initialChannel = Channel;
      }
   }
}
