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

namespace Leadtools.Demos
{
   struct MyItemData
   {
      int _itemData;
      string _itemName;

      public int ItemData
      {
         get
         {
            return _itemData;
         }
         set
         {
            _itemData = value;
         }
      }

      public string ItemString
      {
         get
         {
            return _itemName;
         }
         set
         {
            _itemName = value;
         }
      }

      public override string ToString()
      {
         return _itemName;
      }
   }

   public partial class WiaVersionForm : Form
   {
      public WiaVersion _selectedWiaVersion;

      public WiaVersionForm()
      {
         InitializeComponent();
      }

      private void WiaVersionForm_Load(object sender, EventArgs e)
      {
         MyItemData item = new MyItemData();

         item.ItemData = (int)WiaVersion.Version1;
         item.ItemString = "WIA Version 1.0";
         _lbWiaVersions.Items.Add(item);

         switch (System.Environment.OSVersion.Version.Major)
         {
            case 5:  // Windows Server 2003 R2, Windows Server 2003, Windows XP, or Windows 2000
               item.ItemData = (int)WiaVersion.Version2;
               item.ItemString = DemosGlobalization.GetResxString(GetType(), "Resx_WIAVersion");
               _lbWiaVersions.Items.Add(item);
               break;

            case 6:  // Windows Vista or Windows Server 2008
               item.ItemData = (int)WiaVersion.Version2;
               item.ItemString = "WIA Version 2.0";
               _lbWiaVersions.Items.Add(item);
               break;
         }

         _lbWiaVersions.SetSelected(0, true);
      }

      private void _lbWiaVersions_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (_lbWiaVersions.SelectedIndex > 0 /* WIA version 2.0 selected */ && 
             System.Environment.OSVersion.Version.Major != 6 /* Not VISTA OS */)
         {
            _btnOk.Enabled = false;
         }
         else
         {
            _btnOk.Enabled = true;
         }
      }

      private void _lbWiaVersions_DoubleClick(object sender, EventArgs e)
      {
         MyItemData item = (MyItemData)_lbWiaVersions.SelectedItem;
         if (item.ItemData == (int)WiaVersion.Version2 /* WIA version 2.0 selected */)
         {
            if (System.Environment.OSVersion.Version.Major != 6 /* Not VISTA OS */)
               return;
         }
         _selectedWiaVersion = (WiaVersion)item.ItemData;
         this.DialogResult = DialogResult.OK;
         this.Hide();
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         MyItemData item = (MyItemData)_lbWiaVersions.SelectedItem;
         _selectedWiaVersion = (WiaVersion)item.ItemData;
      }

   }
}
