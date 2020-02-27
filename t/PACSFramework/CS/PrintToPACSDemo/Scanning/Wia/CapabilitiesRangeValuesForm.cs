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
using Leadtools.Wia;

namespace PrintToPACSDemo
{
   public partial class CapabilitiesRangeValuesForm : Form
   {
      public int _selItemIndex;
      public CapabilitiesRangeValuesForm()
      {
         InitializeComponent();
      }

      private void CapabilitiesRangeValuesForm_Load(object sender, EventArgs e)
      {
         WiaCapability capability = (WiaCapability)FrmMain._capabilitiesList[_selItemIndex];

         _tbPropertyName.Text = capability.PropertyName;

         _tbMinimumValue.Text = capability.Values.RangeValues.MinimumValue.ToString();
         _tbMaximumValue.Text = capability.Values.RangeValues.MaximumValue.ToString();
         _tbNominalValue.Text = capability.Values.RangeValues.NominalValue.ToString();
         _tbIncrementValue.Text = capability.Values.RangeValues.Step.ToString();
      }
   }
}
