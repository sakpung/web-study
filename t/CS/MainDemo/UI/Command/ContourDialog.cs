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
   public partial class ContourDialog : Form
   {
      private static bool _firstTimer = true;
      private static int _initialThreshold;
      private static int _initialDeltaDirection;
      private static int _initialMaximumError;
      private static ContourFilterCommandType _initialType = ContourFilterCommandType.Thin;

      public int Threshold;
      public int DeltaDirection;
      public int MaximumError;
      public ContourFilterCommandType Type;

      public ContourDialog( )
      {
         InitializeComponent();
      }

      private void ContourDialog_Load(object sender, System.EventArgs e)
      {
         if(_firstTimer)
         {
            _firstTimer = false;
            ContourFilterCommand command = new ContourFilterCommand();
            _initialThreshold = command.Threshold;
            _initialDeltaDirection = command.DeltaDirection;
            _initialMaximumError = command.MaximumError;
            _initialType = command.Type;
         }

         Threshold = _initialThreshold;
         DeltaDirection = _initialDeltaDirection;
         MaximumError = _initialMaximumError;
         Type = _initialType;

         _numThreshold.Value = Threshold;
         _numDeltaDirection.Value = DeltaDirection;
         _numMaximumError.Value = MaximumError;
         Tools.FillComboBoxWithEnum(_cbType, typeof(ContourFilterCommandType), Type);

         UpdateControls();
      }

      private void _num_Leave(object sender, System.EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _cbType_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         UpdateControls();
      }

      private void UpdateControls( )
      {
         Type = (ContourFilterCommandType)Constants.GetValueFromName(
            typeof(ContourFilterCommandType),
            (string)_cbType.SelectedItem,
            _initialType);
         _lblMaximumError.Enabled = Type == ContourFilterCommandType.ApproxColor;
         _numMaximumError.Enabled = Type == ContourFilterCommandType.ApproxColor;
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         Threshold = (int)_numThreshold.Value;
         DeltaDirection = (int)_numDeltaDirection.Value;
         MaximumError = (int)_numMaximumError.Value;
         Type = (ContourFilterCommandType)Constants.GetValueFromName(
            typeof(ContourFilterCommandType),
            (string)_cbType.SelectedItem,
            _initialType);

         _initialThreshold = Threshold;
         _initialDeltaDirection = DeltaDirection;
         _initialMaximumError = MaximumError;
         _initialType = Type;
      }
   }
}
