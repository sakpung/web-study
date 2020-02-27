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
using Leadtools.ImageProcessing.Effects;
using Leadtools.ImageProcessing.Core;


namespace MainDemo
{
   public partial class HalftoneDialog : Form
   {
      private static bool _firstTimer = true;
      private static HalfToneCommandType _initialType;
      private static int _initialAngle;
      private static int _initialDimension;

      public HalfToneCommandType Type;
      public int Angle;
      public int Dimension;

      public HalftoneDialog( )
      {
         InitializeComponent();
      }

      private void HalftoneDialog_Load(object sender, System.EventArgs e)
      {
         if(_firstTimer)
         {
            _firstTimer = false;
            HalfToneCommand command = new HalfToneCommand();
            _initialType = command.Type;
            _initialAngle = command.Angle;
            _initialDimension = command.Dimension;
         }

         Type = _initialType;
         Angle = _initialAngle / 100;
         Dimension = _initialDimension;

         Tools.FillComboBoxWithEnum(_cbType, typeof(HalfToneCommandType), Type, new object[] { HalfToneCommandType.UserDefined });
         UpdateMyControls();
      }

      private void UpdateMyControls( )
      {
         HalfToneCommandType t = (HalfToneCommandType)Constants.GetValueFromName(
            typeof(HalfToneCommandType),
            (string)_cbType.SelectedItem,
            _initialType);

         bool noAngle =
            t == HalfToneCommandType.Rectangular ||
            t == HalfToneCommandType.Circular ||
            t == HalfToneCommandType.Random;
         _numAngle.Enabled = !noAngle;

         bool noDimension =
            t == HalfToneCommandType.View ||
            t == HalfToneCommandType.Print;
         _numDimension.Enabled = !noDimension;
      }

      private void _cbType_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         UpdateMyControls();
      }

      private void _num_Leave(object sender, System.EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         Type = (HalfToneCommandType)Constants.GetValueFromName(
            typeof(HalfToneCommandType),
            (string)_cbType.SelectedItem,
            _initialType);
         Angle = (int)_numAngle.Value * 100;
         Dimension = (int)_numDimension.Value;

         _initialType = Type;
         _initialAngle = Angle;
         _initialDimension = Dimension;
      }
   }
}
