// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections;
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
   public partial class WiaDeviceItemsForm : Form
   {
      private ItemData _itemData;
      private ArrayList _enumeratedItems = new ArrayList();

      public WiaDeviceItemsForm()
      {
         InitializeComponent();
      }

      private void WiaDeviceItemsForm_Load(object sender, EventArgs e)
      {
         Object rootItem = null;
         string itemName = string.Empty;

#if !LEADTOOLS_V17_OR_LATER
         MainForm._wiaSession.GetRootItem(null);
         rootItem = MainForm._wiaSession.RootItem;
         MainForm._wiaSession.GetPropertyString(rootItem, null, WiaPropertyId.DeviceInfoDevName);
         itemName = MainForm._wiaSession.StringValue;
#else
         rootItem = MainForm._wiaSession.GetRootItem(null);
         itemName = MainForm._wiaSession.GetPropertyString(rootItem, null, WiaPropertyId.DeviceInfoDevName);
#endif //#if !LEADTOOLS_V17_OR_LATER

         _tvWiaDeviceItems.Nodes.Clear();

         _itemData = new ItemData(rootItem);

         // Enable the enumerate items event.
         MainForm._wiaSession.EnumItemsEvent += new EventHandler<WiaEnumItemsEventArgs>(wiaSession_EnumItemsEvent);

         TreeNode rootNode = new TreeNode(itemName);
         _itemData.Node = rootNode;
         rootNode.Tag = _itemData;

         using (WaitCursor wait = new WaitCursor())
         {
            // Enumerate the device child items.
            EnumerateItems(rootNode, rootItem);
         }

         _tvWiaDeviceItems.Nodes.Add(rootNode);

         _tvWiaDeviceItems.SelectedNode = rootNode;
         _tvWiaDeviceItems.ExpandAll();

         // Disable the enumerate items event.
         MainForm._wiaSession.EnumItemsEvent -= new EventHandler<WiaEnumItemsEventArgs>(wiaSession_EnumItemsEvent);
      }

      private void EnumerateItems(TreeNode parentNode, Object item)
      {
         try
         {
            _enumeratedItems.Clear();

            try
            {
               MainForm._wiaSession.EnumChildItems(item);
            }
            catch (System.Exception /*e*/)
            {
               // Do nothing here since this function throws an error if the item doesn't have childs and
               // we don't want to abort the process.
            }

            Object[] childs = new Object[_enumeratedItems.Count];
            _enumeratedItems.CopyTo(childs);
            foreach(Object wiaItem in childs)
            {
               ItemData childHolder = new ItemData(wiaItem);
               string itemName = string.Empty;

#if !LEADTOOLS_V17_OR_LATER
               MainForm._wiaSession.GetPropertyString(wiaItem, null, WiaPropertyId.ItemName);
               itemName = MainForm._wiaSession.StringValue;
#else
               itemName = MainForm._wiaSession.GetPropertyString(wiaItem, null, WiaPropertyId.ItemName);
#endif //#if !LEADTOOLS_V17_OR_LATER

               if (string.IsNullOrEmpty(itemName))
                  itemName = "Item";

               TreeNode newNode = new TreeNode(itemName);
               childHolder.Node = newNode;
               newNode.Tag = childHolder;
               EnumerateItems(newNode, wiaItem);
               parentNode.Nodes.Add(newNode);
            }
         }
         catch (System.Exception ex)
         {
            Messager.ShowError(this, ex);
            DialogResult = DialogResult.Cancel;
         }
      }

      void wiaSession_EnumItemsEvent(object sender, WiaEnumItemsEventArgs e)
      {
         _enumeratedItems.Add(e.Item);
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         MainForm._selectedWiaItem = ((ItemData)(_tvWiaDeviceItems.SelectedNode.Tag)).Item;
         DialogResult = DialogResult.OK;
      }

      private void _tvWiaDeviceItems_AfterSelect(object sender, TreeViewEventArgs e)
      {
         MainForm._selectedWiaItem = ((ItemData)(_tvWiaDeviceItems.SelectedNode.Tag)).Item;

         if (!MainForm._forCapabilities)
         {
            Object rootItem = null;
#if !LEADTOOLS_V17_OR_LATER
            MainForm._wiaSession.GetRootItem(null);
            rootItem = MainForm._wiaSession.RootItem;
#else
            rootItem = MainForm._wiaSession.GetRootItem(null);
#endif //#if !LEADTOOLS_V17_OR_LATER

            if (MainForm._selectedWiaItem.Equals(rootItem))
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
         Object rootItem = null;
#if !LEADTOOLS_V17_OR_LATER
         MainForm._wiaSession.GetRootItem(null);
         rootItem = MainForm._wiaSession.RootItem;
#else
         rootItem = MainForm._wiaSession.GetRootItem(null);
#endif //#if !LEADTOOLS_V17_OR_LATER

         MainForm._selectedWiaItem = ((ItemData)(_tvWiaDeviceItems.SelectedNode.Tag)).Item;
         if (!MainForm._selectedWiaItem.Equals(rootItem))
         {
            DialogResult = DialogResult.OK;
         }
      }
   }
}
