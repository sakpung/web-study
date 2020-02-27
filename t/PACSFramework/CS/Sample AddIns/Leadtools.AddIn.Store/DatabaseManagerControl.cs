// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Leadtools.Dicom;

namespace Leadtools.AddIn.Store
{
   public partial class DatabaseManagerControl : UserControl
   {
      public bool _cancel = false;

      public DatabaseManagerControl()
      {
         InitializeComponent();
      }

      void ArrangeButtons()
      {
         int nSpaceBetweenButtons = 6;
         int nTotalButtonWidth = 
            _buttonImport.Width + 
            _buttonRemove.Width + 
            _buttonRemoveAll.Width +
            _buttonRefresh.Width +
            _buttonCancel.Width + 4 * nSpaceBetweenButtons;

         _buttonImport.Left = (_splitContainer1.Panel2.ClientSize.Width - nTotalButtonWidth) / 2;
         _buttonImport.Top = (_splitContainer1.Panel2.ClientSize.Height - _buttonImport.Height) / 2;

         _buttonRemove.Left = _buttonImport.Right + nSpaceBetweenButtons;
         _buttonRemove.Top = _buttonImport.Top;

         _buttonRemoveAll.Left = _buttonRemove.Right + nSpaceBetweenButtons;
         _buttonRemoveAll.Top = _buttonImport.Top;

         _buttonRefresh.Left = _buttonRemoveAll.Right + nSpaceBetweenButtons;
         _buttonRefresh.Top = _buttonImport.Top;

         _buttonCancel.Left = _buttonRefresh.Right + nSpaceBetweenButtons;
         _buttonCancel.Top = _buttonImport.Top;
      }

      private void EnableCancel(bool bEnable)
      {
         int nCount = _listViewDatabase.Items.Count;
         int nCheckedCount = GetCheckedCount();

         _buttonImport.Enabled = !bEnable;
         _buttonRemove.Enabled = !bEnable && (nCheckedCount > 0);
         _buttonRemoveAll.Enabled = !bEnable && (nCount > 0);
         _buttonRefresh.Enabled = !bEnable;
         _listViewDatabase.Enabled = !bEnable;
         _buttonCancel.Enabled = bEnable;

         if (bEnable == false)
         {
            if (_cancel)
            {
               MessageBox.Show(this, "Cancelled", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
               _cancel = false;
            }
         }
      }

      private void RemoveItem(string sSOPInstanceUid)
      {
         DB.DeleteDicomRecord(Module.ServerInfo.ConnectionString, sSOPInstanceUid);
      }

      private int RemoveSelectedItems()
      {
         int nCount = 0;
         EnableCancel(true);

         try
         {
            foreach (ListViewItem item in _listViewDatabase.CheckedItems)
            {
               if (!_cancel)
               {
                  string sSopInstanceUid = item.Tag.ToString();
                  RemoveItem(sSopInstanceUid);
                  nCount++;
               }
            }
         }
         catch (Exception)
         {
         }
         EnableCancel(false);

         return nCount;
      }

      private int RemoveAllItems()
      {
         int nCount = _listViewDatabase.Items.Count;
         DB.DeleteAllDicomRecords(Module.ServerInfo.ConnectionString);
         return nCount;
      }

      private bool IsDicomDir(string file, DicomDataSet ds)
      {
         string name = Path.GetFileNameWithoutExtension(file);

         return (name == "DICOMDIR" && ds.InformationClass == DicomClassType.BasicDirectory);
      }

      private void _buttonImport_Click(object sender, EventArgs e)
      {
         OpenFileDialog of = new OpenFileDialog();
         DicomDataSet ds = new DicomDataSet();
         of.Multiselect = true;
         of.Title = "Add DICOM File";
         of.Filter = "DICOM Files (*.dcm;*.dic)|*.dcm;*.dic|All files (*.*)|*.*";
         if (of.ShowDialog() == DialogResult.OK)
         {
            EnableCancel(true);
            foreach (string file in of.FileNames)
            {
               try
               {
                  if (!_cancel)
                  {
                     ds.Load(file, DicomDataSetLoadFlags.None);
                     DB.Insert(DateTime.Now, Module.ServerInfo, "LEAD", ds);
                  }
               }
               catch (Exception ex)
               {
                  MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
               Application.DoEvents();
            }
            RefreshList();
         }
         EnableCancel(false);
      }

      private int GetCheckedCount()
      {
         int nCount = 0;
         foreach (ListViewItem item in _listViewDatabase.CheckedItems)
         {
            nCount++;
         }
         return nCount;
      }

      private void _buttonRemove_Click(object sender, EventArgs e)
      {
         string sMsg;
         int nCount = GetCheckedCount();
         if (nCount > 0)
         {
            sMsg = string.Format("You are about to permananetly delete {0} item(s).  Do you want to continue?", nCount);
            DialogResult dr = MessageBox.Show(this, sMsg, "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
               nCount = RemoveSelectedItems();
               if (nCount > 0)
                  RefreshList();
            }
            else
            {
               MessageBox.Show(this, "Action Cancelled");
            }
         }
      }

      private void _buttonRemoveAll_Click(object sender, EventArgs e)
      {
         DialogResult dr = MessageBox.Show(this, "You are about to permananetly delete ALL items.  Do you want to continue?", "Remove All", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
         if (dr == DialogResult.Yes)
         {
            int nCount = RemoveAllItems();
            if (nCount > 0)
            {
               RefreshList();
               EnableCancel(false);
            }
         }
         else
         {
            MessageBox.Show(this, "Action Cancelled");
         }
      }

      private void SizeColumns()
      {
         if (_listViewDatabase.Items.Count > 0)
         {
            // Size to content
            foreach (ColumnHeader header in _listViewDatabase.Columns)
            {
               if (header.Text.Contains("Modality"))
                  header.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
               else if (header.Text.Contains("Study ID"))
                  header.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
               else if (header.Text.Contains("Instance #"))
                  header.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
               else if (header.Text.Contains("Series #"))
                  header.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
               else
                  header.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
         }
         else
         {
            // size to header
            foreach (ColumnHeader header in _listViewDatabase.Columns)
               header.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
         }
      }

      private void RefreshList()
      {
         try
         {
            DB.ListAllImages(Module.ServerInfo.ConnectionString, _listViewDatabase);
            SizeColumns();
            _listViewDatabase.Refresh();
         }
         catch (Exception)
         {
         }
      }

      private void _listViewDatabase_ItemChecked(object sender, ItemCheckedEventArgs e)
      {
         EnableCancel(false);
      }

      private void _splitContainer1_Panel2_Resize(object sender, EventArgs e)
      {
         ArrangeButtons();
      }


      private void _buttonRefresh_Click(object sender, EventArgs e)
      {
         RefreshList();
      }

      private void _buttonCancel_Click(object sender, EventArgs e)
      {
         _cancel = true;
      }

      private void DatabaseManagerControl_Load(object sender, EventArgs e)
      {
         RefreshList();
         ArrangeButtons();
         EnableCancel(false);
      }

   }
}
