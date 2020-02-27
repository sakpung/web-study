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
   public partial class WiaDeviceItemsForm : Form
   {
      public WiaDeviceItemsForm()
      {
         InitializeComponent();
      }

      private void WiaDeviceItemsForm_Load(object sender, EventArgs e)
      {
         FrmMain._selectedItemIndex = -1;

         // Enumerate the device child items.
         EnumWiaDeviceItems();

         // Disable the OK button since there will be no initial selection
         _btnOk.Enabled = false;
      }

      private void EnumWiaDeviceItems()
      {
         string      deviceName;
         string      itemName;
         int         value;

         try
         {
            if (FrmMain._enumeratedItemsList.Count > 0)
            {
               FrmMain._enumeratedItemsList.Clear();
               _tvWiaDeviceItems.Nodes.Clear();
            }

            Object rootItem = FrmMain._wiaSession.GetRootItem(null);

            // Get the selected device name.
            deviceName = FrmMain._wiaSession.GetPropertyString(rootItem, null, WiaPropertyId.DeviceInfoDevName);

            // Add the root item as the first item in the array.
            FrmMain._enumeratedItemsList.Add(rootItem);

            // Enable the enumerate items event.
            FrmMain._wiaSession.EnumItemsEvent += new EventHandler<WiaEnumItemsEventArgs>(wiaSession_EnumItemsEvent);

            // Enumerate the child items for the root item.
            FrmMain._wiaSession.EnumChildItems(rootItem);

            // Disable the enumerate items event.
            FrmMain._wiaSession.EnumItemsEvent -= new EventHandler<WiaEnumItemsEventArgs>(wiaSession_EnumItemsEvent);

            // Loop through the items array adding them all to the items list.
            foreach (object i in FrmMain._enumeratedItemsList)
            {
               itemName = FrmMain._wiaSession.GetPropertyString(i, null, WiaPropertyId.ItemName);

               if (FrmMain._wiaVersion == WiaVersion.Version1)
               {
                  if (i == rootItem) // This is the root item.
                  {
                     if (FrmMain._wiaSession.SelectedDeviceType == WiaDeviceType.Scanner)
                     {
                        // Get the selected device source type (Feeder or Flatbed)
                        value = FrmMain._wiaSession.GetPropertyLong(i, null, WiaPropertyId.ScannerDeviceDocumentHandlingSelect);
                        if ((value & (int)WiaScanningModeFlags.Feeder) == (int)WiaScanningModeFlags.Feeder)
                        {
                           itemName += " - Feeder";
                        }
                        if ((value & (int)WiaScanningModeFlags.Flatbed) == (int)WiaScanningModeFlags.Flatbed)
                        {
                           itemName += " - Flatbed";
                        }
                     }
                  }
               }

               if (string.IsNullOrEmpty(itemName))
                  itemName = "Item";

               AddTreeViewNode(itemName);
            }

            // Expand the tree items
            _tvWiaDeviceItems.ExpandAll();
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
            DialogResult = DialogResult.Cancel;
         }
      }

      void wiaSession_EnumItemsEvent(object sender, WiaEnumItemsEventArgs e)
      {
         FrmMain._enumeratedItemsList.Add(e.Item);
      }

      private void AddTreeViewNode(string nodeName)
      {
         if (_tvWiaDeviceItems.Nodes.Count == 0)
            _tvWiaDeviceItems.Nodes.Add(nodeName);
         else
            _tvWiaDeviceItems.Nodes[_tvWiaDeviceItems.Nodes.Count-1].Nodes.Add(nodeName);
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         FrmMain._selectedItemIndex = _tvWiaDeviceItems.SelectedNode.Index + _tvWiaDeviceItems.SelectedNode.Level;
         DialogResult = DialogResult.OK;
      }

      private void _tvWiaDeviceItems_AfterSelect(object sender, TreeViewEventArgs e)
      {
         FrmMain._selectedItemIndex = _tvWiaDeviceItems.SelectedNode.Index + _tvWiaDeviceItems.SelectedNode.Level;

         if (!FrmMain._forCapabilities)
         {
            if (FrmMain._selectedItemIndex <= 0)
            {
               _btnOk.Enabled = false;
            }
            else
            {
               // If the OK button is disabled then enable it unless the root item is selected.
               if (!_btnOk.Enabled)
                  _btnOk.Enabled = true;
            }
         }
         else
         {
            _btnOk.Enabled = true;
         }
      }

      private void _tvWiaDeviceItems_DoubleClick(object sender, EventArgs e)
      {
         FrmMain._selectedItemIndex = _tvWiaDeviceItems.SelectedNode.Index + _tvWiaDeviceItems.SelectedNode.Level;

         if (FrmMain._selectedItemIndex > 0)
         {
            DialogResult = DialogResult.OK;
         }
      }
   }
}
