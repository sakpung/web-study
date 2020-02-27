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

namespace PrintToPACSDemo
{
   public partial class WiaPropertiesErrorsForm : Form
   {
      public WiaPropertiesErrorsForm()
      {
         InitializeComponent();
      }

      private void WiaPropertiesErrorsForm_Load(object sender, EventArgs e)
      {
         _lvErrors.Columns.Add("Device Name"    , 150, HorizontalAlignment.Left);
         _lvErrors.Columns.Add("Item Name"      , 100, HorizontalAlignment.Left);
         _lvErrors.Columns.Add("Property Name"  , 120, HorizontalAlignment.Left);
         _lvErrors.Columns.Add("Property Value" , 100, HorizontalAlignment.Left);
         _lvErrors.Columns.Add("Error"          , 70 , HorizontalAlignment.Left);

         foreach (MyPropertiesErrors i in FrmMain._wiaerrorList)
         {
            ListViewItem item;

            item = _lvErrors.Items.Add(i.DeviceName);

            item.SubItems.Add(i.ItemName);
            item.SubItems.Add(i.PropertyName);
            item.SubItems.Add(i.PropertyValue);
            item.SubItems.Add(i.ErrorCodeString);
         }
      }

      private void _btnClear_Click(object sender, EventArgs e)
      {
         FrmMain._wiaerrorList.Clear();
         _lvErrors.Items.Clear();
      }
   }
}
