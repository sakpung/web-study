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

namespace WiaDemo
{
   public partial class WiaPropertiesErrorsForm : Form
   {
      public WiaPropertiesErrorsForm()
      {
         InitializeComponent();
      }

      private void WiaPropertiesErrorsForm_Load(object sender, EventArgs e)
      {
         _lvErrors.Columns.Add(DemosGlobalization.GetResxString(GetType(), "Resx_DeviceName"), 150, HorizontalAlignment.Left);
         _lvErrors.Columns.Add(DemosGlobalization.GetResxString(GetType(), "Resx_ItemName"), 100, HorizontalAlignment.Left);
         _lvErrors.Columns.Add(DemosGlobalization.GetResxString(GetType(), "Resx_PropertyName"), 120, HorizontalAlignment.Left);
         _lvErrors.Columns.Add(DemosGlobalization.GetResxString(GetType(), "Resx_PropertyValue"), 100, HorizontalAlignment.Left);
         _lvErrors.Columns.Add(DemosGlobalization.GetResxString(GetType(), "Resx_Error"), 70 , HorizontalAlignment.Left);

         foreach (MyPropertiesErrors i in MainForm._errorList)
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
         MainForm._errorList.Clear();
         _lvErrors.Items.Clear();
      }
   }
}
