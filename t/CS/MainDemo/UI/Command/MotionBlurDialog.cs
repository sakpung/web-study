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
   public partial class MotionBlurDialog : Form
   {
      private static bool _firstTimer = true;
      private static int _initialDimension;
      private static int _initialAngle;
      private static bool _initialUniDirectional;

      public int Dimension;
      public int Angle;
      public bool UniDirectional;

      public MotionBlurDialog( )
      {
         InitializeComponent();
      }

      private void MotionBlurDialog_Load(object sender, System.EventArgs e)
      {
         if(_firstTimer)
         {
            _firstTimer = false;
            MotionBlurCommand command = new MotionBlurCommand();
            _initialDimension = command.Dimension;
            _initialAngle = command.Angle;
            _initialUniDirectional = command.UniDirection;
         }

         Dimension = _initialDimension;
         Angle = _initialAngle / 100;
         UniDirectional = _initialUniDirectional;

         _numDimension.Value = Dimension;
         DialogUtilities.SetNumericValue(_numAngle, Angle);
         _cbUniDirectional.Checked = UniDirectional;
      }

      private void _num_Leave(object sender, System.EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         Dimension = (int)_numDimension.Value;
         Angle = (int)_numAngle.Value * 100;
         UniDirectional = _cbUniDirectional.Checked;
         if(Dimension > 255)
            Dimension = 255;
         _initialDimension = Dimension;
         _initialAngle = Angle;
         _initialUniDirectional = UniDirectional;
      }
   }
}
