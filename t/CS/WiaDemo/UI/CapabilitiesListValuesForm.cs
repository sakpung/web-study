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
using Leadtools.Demos;

namespace WiaDemo
{
   public partial class CapabilitiesListValuesForm : Form
   {
      public int _selItemIndex;

      public CapabilitiesListValuesForm()
      {
         InitializeComponent();
      }

      private void CapabilitiesListValuesForm_Load(object sender, EventArgs e)
      {
         Int32 value;
         string valueString = string.Empty;
         WiaCapability capability = (WiaCapability)MainForm._capabilitiesList[_selItemIndex];

         _tbPropertyName.Text = capability.PropertyName;

         if ((capability.PropertyAttributes & WiaPropertyAttributesFlags.List) == WiaPropertyAttributesFlags.List)
         {
            // Set the dialog caption.
            this.Text = DemosGlobalization.GetResxString(GetType(), "Resx_WIAListPropertyValues");

            // Change the list control label text.
            _lblValues.Text = DemosGlobalization.GetResxString(GetType(), "Resx_ListValues");

            if (capability.Values.ListValues.ValuesCount <= 0)
               return;

            int index = 0;
            // Add the list values to the list.
            foreach(object i in capability.Values.ListValues.Values)
            {
               if (capability.VariableType == WiaVariableTypes.Bstr)
               {
                  valueString = Convert.ToString(capability.Values.ListValues.Values[index]);
               }
               else if (capability.VariableType == WiaVariableTypes.Clsid)
               {
                  System.Guid guidValue = (System.Guid)capability.Values.ListValues.Values[index];
                  valueString = guidValue.ToString();
               }
               else
               {
                  value = Convert.ToInt32(capability.Values.ListValues.Values[index]);
                  int ret = HelperFunctions.GetWiaListPropertyValueString(capability.PropertyId, (int)value);
                  if (ret == 0)
                  {
                     // Add the received value as is to the values list.
                     valueString = value.ToString();
                  }
                  else
                  {
                     valueString = HelperFunctions.ListPropertyValueString;
                  }
               }
               if (!string.IsNullOrEmpty(valueString))
                  _lbValues.Items.Add(valueString);

               index++;
            }
         }
         else
         {
            // Set the dialog caption.
            this.Text = DemosGlobalization.GetResxString(GetType(), "Resx_FlagPropertyValues");

            // Change the list control label text.
            _lblValues.Text = DemosGlobalization.GetResxString(GetType(), "Resx_FlagValues");

            value = capability.Values.FlagsValues.FlagValues;
            int ret = HelperFunctions.GetWiaFlagPropertyValueString(capability.PropertyId, value);
            if (ret == 0)
            {
               // add the values with their native ID's
               _lbValues.Items.Add(value.ToString());
            }
            else
            {
               foreach (string i in MainForm._flagValuesStrings)
               {
                  _lbValues.Items.Add(i);
               }
            }
         }
      }
   }
}
