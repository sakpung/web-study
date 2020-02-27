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

namespace PrintToPACSDemo
{
   public partial class SupportedCapabilitiesForm : Form
   {
      public SupportedCapabilitiesForm()
      {
         InitializeComponent();
      }

      private void SupportedCapabilitiesForm_Load(object sender, EventArgs e)
      {
         // Add the list view columns.
         _lvCapabilities.Columns.Add("Property ID", 230, HorizontalAlignment.Left);
         _lvCapabilities.Columns.Add("Property Name", 165, HorizontalAlignment.Left);
         _lvCapabilities.Columns.Add("Property Type", 80, HorizontalAlignment.Left);
         _lvCapabilities.Columns.Add("Property Access", 150, HorizontalAlignment.Left);

         try
         {
            FrmMain._capabilitiesList.Clear();

            // Enable the EnumCapabilities event.
            FrmMain._wiaSession.EnumCapabilitiesEvent += new EventHandler<Leadtools.Wia.WiaEnumCapabilitiesEventArgs>(_wiaSession_EnumCapabilitiesEvent);

            // enumerate the selected WIA item capabilities.
            FrmMain._wiaSession.EnumCapabilities(FrmMain._enumeratedItemsList[FrmMain._selectedItemIndex], 0);

            // Disable the EnumCapabilities event.
            FrmMain._wiaSession.EnumCapabilitiesEvent -= new EventHandler<Leadtools.Wia.WiaEnumCapabilitiesEventArgs>(_wiaSession_EnumCapabilitiesEvent);

            // Loop through the capabilities array adding them to the capabilities list.
            foreach (WiaCapability i in FrmMain._capabilitiesList)
            {
               ListViewItem item;

               item = _lvCapabilities.Items.Add(i.PropertyId.ToString());

               item.SubItems.Add(i.PropertyName);
               item.SubItems.Add(i.VariableType.ToString());
               item.SubItems.Add(i.PropertyAttributes.ToString());
            }

            _lblCapabilitiesCount.Text = FrmMain._capabilitiesList.Count.ToString();
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      void _wiaSession_EnumCapabilitiesEvent(object sender, Leadtools.Wia.WiaEnumCapabilitiesEventArgs e)
      {
         if (e.CapabilitiesCount > 0)
         {
            FrmMain._capabilitiesList.Add(e.Capability);
         }
      }

      private void _lvCapabilities_MouseDoubleClick(object sender, MouseEventArgs e)
      {
         if (_lvCapabilities.FocusedItem.Index < 0)
            return;

         ShowCapabilityValidValues(_lvCapabilities.FocusedItem.Index);
      }

      private void ShowCapabilityValidValues(int itemIndex)
      {
         WiaCapability capability = (WiaCapability)FrmMain._capabilitiesList[itemIndex];
         if (((capability.PropertyAttributes & WiaPropertyAttributesFlags.List) == WiaPropertyAttributesFlags.List) ||
             ((capability.PropertyAttributes & WiaPropertyAttributesFlags.Flag) == WiaPropertyAttributesFlags.Flag))
         {
            using (CapabilitiesListValuesForm CapsListValuesDlg = new CapabilitiesListValuesForm())
            {
               CapsListValuesDlg._selItemIndex = itemIndex;
               CapsListValuesDlg.ShowDialog(this);
            }
         }
         else if ((capability.PropertyAttributes & WiaPropertyAttributesFlags.Range) == WiaPropertyAttributesFlags.Range)
         {
            using (CapabilitiesRangeValuesForm CapsRangeValuesDlg = new CapabilitiesRangeValuesForm())
            {
               CapsRangeValuesDlg._selItemIndex = itemIndex;
               CapsRangeValuesDlg.ShowDialog(this);
            }
         }
      }
   }
}
