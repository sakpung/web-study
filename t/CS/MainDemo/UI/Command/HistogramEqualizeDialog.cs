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
   public partial class HistogramEqualizeDialog : Form
   {
      private static bool _firstTimer = true;
      private static HistogramEqualizeType _initialColorSpace;

      public HistogramEqualizeType ColorSpace;

      public HistogramEqualizeDialog( )
      {
         InitializeComponent();
      }

      private void HistogramEqualizeDialog_Load(object sender, System.EventArgs e)
      {
         if(_firstTimer)
         {
            _firstTimer = false;
            HistogramEqualizeCommand command = new HistogramEqualizeCommand();
            _initialColorSpace = command.Type;
         }

         ColorSpace = _initialColorSpace;

         Tools.FillComboBoxWithEnum(_cbColorSpace, typeof(HistogramEqualizeType), ColorSpace, new object[] { HistogramEqualizeType.None });
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         ColorSpace = (HistogramEqualizeType)Constants.GetValueFromName(
            typeof(HistogramEqualizeType),
            (string)_cbColorSpace.SelectedItem,
            _initialColorSpace);

         _initialColorSpace = ColorSpace;
      }
   }
}
