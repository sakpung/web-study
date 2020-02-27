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

using Leadtools.ImageProcessing.Effects;
using Leadtools.Demos;

namespace MainDemo
{
   public partial class BinaryDialog : Form
   {
      public enum FilterConstants
      {
         Dilation,
         Erosion
      };

      private static BinaryFilterCommandPredefined _initialFilter = BinaryFilterCommandPredefined.ErosionOmniDirectional;

      public BinaryFilterCommandPredefined Filter;

      public BinaryDialog( )
      {
         InitializeComponent();
      }

      private void BinaryDialog_Load(object sender, System.EventArgs e)
      {
         Filter = _initialFilter;

         Tools.FillComboBoxWithEnum(_cbFilter, typeof(BinaryFilterCommandPredefined), Filter);
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         Filter = (BinaryFilterCommandPredefined)Constants.GetValueFromName(
            typeof(BinaryFilterCommandPredefined),
            (string)_cbFilter.SelectedItem,
            _initialFilter);

         _initialFilter = Filter;
      }
   }
}
