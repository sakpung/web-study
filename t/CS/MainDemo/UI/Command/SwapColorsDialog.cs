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

using Leadtools.ImageProcessing.Color;
using Leadtools.Demos;

namespace MainDemo
{
   public partial class SwapColorsDialog : Form
   {
      private static bool _firstTimer = true;
      private static SwapColorsCommandType _initialType;

      public SwapColorsCommandType Type;

      public SwapColorsDialog( )
      {
         InitializeComponent();
      }

      private void SwapColorsDialog_Load(object sender, System.EventArgs e)
      {
         if(_firstTimer)
         {
            _firstTimer = false;
            SwapColorsCommand command = new SwapColorsCommand();
            _initialType = command.Type;
         }

         Type = _initialType;

         Tools.FillComboBoxWithEnum(_cbType, typeof(SwapColorsCommandType), Type);
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         Type = (SwapColorsCommandType)Constants.GetValueFromName(
            typeof(SwapColorsCommandType),
            (string)_cbType.SelectedItem,
            _initialType);

         _initialType = Type;
      }
   }
}
