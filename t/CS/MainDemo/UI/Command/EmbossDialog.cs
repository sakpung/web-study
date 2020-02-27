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
   public partial class EmbossDialog : Form
   {
      private static bool _firstTimer = true;
      private static EmbossCommandDirection _initialDirection;
      private static int _initialDepth;

      public EmbossCommandDirection Direction;
      public int Depth;

      public EmbossDialog( )
      {
         InitializeComponent();
      }

      private void EmbossDialog_Load(object sender, System.EventArgs e)
      {
         if(_firstTimer)
         {
            _firstTimer = false;
            EmbossCommand command = new EmbossCommand();
            _initialDirection = command.Direction;
            _initialDepth = command.Depth;
         }

         Direction = _initialDirection;
         Depth = _initialDepth / 10;

         Tools.FillComboBoxWithEnum(_cbDirection, typeof(EmbossCommandDirection), Direction);
         _numDepth.Value = Depth;
      }

      private void _num_Leave(object sender, System.EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         Direction = (EmbossCommandDirection)Constants.GetValueFromName(
            typeof(EmbossCommandDirection),
            (string)_cbDirection.SelectedItem,
            _initialDirection);

         Depth = (int)_numDepth.Value * 10;

         _initialDirection = Direction;
         _initialDepth = Depth;
      }
   }
}
